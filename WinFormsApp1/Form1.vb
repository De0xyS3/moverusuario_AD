Imports System.Data
Imports System.DirectoryServices
Imports System.IO
Imports System.Windows.Forms

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        comboBoxOU.Enabled = False
        btnMoveAndDisable.Enabled = False

        ' Configurar DataGridView para que ocupe todo el espacio disponible en el GroupBox
        DataGridView1.Dock = DockStyle.Fill

        ' Inicializar la barra de progreso
        progressBar1.Visible = False
        progressBar1.Minimum = 0
        progressBar1.Step = 1
    End Sub

    Private Sub btnLoadCSV_Click(sender As Object, e As EventArgs) Handles btnLoadCSV.Click
        OpenFileDialog1.Filter = "CSV files (*.csv)|*.csv"
        OpenFileDialog1.Title = "Select a CSV file"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            progressBar1.Visible = True
            progressBar1.Value = 0

            Dim lines As String() = File.ReadAllLines(OpenFileDialog1.FileName)
            Dim dt As New DataTable()
            Dim headers As String() = lines(0).Split(","c)

            For Each header As String In headers
                dt.Columns.Add(header)
            Next

            progressBar1.Maximum = lines.Length - 1

            For i As Integer = 1 To lines.Length - 1
                Dim rows As String() = lines(i).Split(","c)
                Dim dr As DataRow = dt.NewRow()
                For j As Integer = 0 To headers.Length - 1
                    dr(j) = rows(j)
                Next
                dt.Rows.Add(dr)

                ' Actualizar la barra de progreso
                progressBar1.PerformStep()
            Next

            DataGridView1.DataSource = dt

            ' Deshabilitar comboBoxOU y btnMoveAndDisable después de cargar un nuevo CSV
            comboBoxOU.Enabled = False
            btnMoveAndDisable.Enabled = False

            ' Ocultar la barra de progreso
            progressBar1.Visible = False
        End If
    End Sub

    Private Sub checkBoxFirstName_CheckedChanged(sender As Object, e As EventArgs) Handles checkBoxFirstName.CheckedChanged
        If checkBoxFirstName.Checked Then
            checkBoxLastName.Checked = False
            checkBoxDisplayName.Checked = False
        End If
    End Sub

    Private Sub checkBoxLastName_CheckedChanged(sender As Object, e As EventArgs) Handles checkBoxLastName.CheckedChanged
        If checkBoxLastName.Checked Then
            checkBoxFirstName.Checked = False
            checkBoxDisplayName.Checked = False
        End If
    End Sub

    Private Sub checkBoxDisplayName_CheckedChanged(sender As Object, e As EventArgs) Handles checkBoxDisplayName.CheckedChanged
        If checkBoxDisplayName.Checked Then
            checkBoxFirstName.Checked = False
            checkBoxLastName.Checked = False
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim domainName As String = txtDomainName.Text.Trim()
        If String.IsNullOrEmpty(domainName) Then
            MessageBox.Show("Por favor, ingrese el nombre del dominio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim searchResults As New DataTable()
        searchResults.Columns.Add("FirstName")
        searchResults.Columns.Add("LastName")
        searchResults.Columns.Add("DisplayName")
        searchResults.Columns.Add("ADPath")

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.IsNewRow Then Continue For

            Dim searchString As String = BuildSearchFilter(row)
            If String.IsNullOrEmpty(searchString) Then Continue For

            Dim result As SearchResult = FindUserInAD(searchString, domainName)
            If result IsNot Nothing Then
                Dim dr As DataRow = searchResults.NewRow()
                dr("FirstName") = row.Cells("FirstName").Value
                dr("LastName") = row.Cells("LastName").Value
                dr("DisplayName") = row.Cells("DisplayName").Value
                dr("ADPath") = result.Path
                searchResults.Rows.Add(dr)
            End If
        Next

        DataGridView1.DataSource = searchResults
        comboBoxOU.Enabled = True
        btnMoveAndDisable.Enabled = True
        LoadOrganizationalUnits(domainName)
    End Sub

    Private Sub btnMoveAndDisable_Click(sender As Object, e As EventArgs) Handles btnMoveAndDisable.Click
        Dim newOU As String = comboBoxOU.SelectedItem.ToString()
        Dim domainName As String = txtDomainName.Text.Trim()

        progressBar1.Visible = True
        progressBar1.Value = 0
        progressBar1.Maximum = DataGridView1.Rows.Count - 1

        For Each row As DataGridViewRow In DataGridView1.Rows
            If row.IsNewRow Then Continue For

            Dim adPath As String = row.Cells("ADPath").Value.ToString()
            Dim entry As New DirectoryEntry(adPath)

            Try
                MoveUserToOU(entry, newOU)
                DisableADUser(entry)
                MessageBox.Show($"Usuario {entry.Name} movido y deshabilitado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show($"Error al mover o deshabilitar al usuario {entry.Name}: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            ' Actualizar la barra de progreso
            progressBar1.PerformStep()
        Next

        ' Ocultar la barra de progreso
        progressBar1.Visible = False
    End Sub

    Private Sub LoadOrganizationalUnits(domainName As String)
        Dim ouList As List(Of String) = GetOrganizationalUnits(domainName)
        comboBoxOU.DataSource = ouList
    End Sub

    Private Function GetOrganizationalUnits(domainName As String) As List(Of String)
        Dim ouList As New List(Of String)()
        Dim entry As New DirectoryEntry($"LDAP://DC={domainName.Replace(".", ",DC=")}")
        Dim searcher As New DirectorySearcher(entry)

        searcher.Filter = "(objectCategory=organizationalUnit)"
        searcher.SearchScope = SearchScope.Subtree
        searcher.PropertiesToLoad.Add("distinguishedName")

        For Each result As SearchResult In searcher.FindAll()
            If result.Properties.Contains("distinguishedName") Then
                ouList.Add(result.Properties("distinguishedName")(0).ToString())
            End If
        Next

        Return ouList
    End Function

    Private Function BuildSearchFilter(row As DataGridViewRow) As String
        Dim filter As String = String.Empty

        If checkBoxFirstName.Checked Then
            filter &= $"(givenName={row.Cells("FirstName").Value})"
        End If
        If checkBoxLastName.Checked Then
            filter &= $"(sn={row.Cells("LastName").Value})"
        End If
        If checkBoxDisplayName.Checked Then
            filter &= $"(displayName={row.Cells("DisplayName").Value})"
        End If

        If Not String.IsNullOrEmpty(filter) Then
            filter = $"(|{filter})"
        End If

        Return filter
    End Function

    Private Function FindUserInAD(searchString As String, domainName As String) As SearchResult
        Dim entry As New DirectoryEntry($"LDAP://DC={domainName.Replace(".", ",DC=")}")
        Dim search As New DirectorySearcher(entry)
        search.Filter = searchString
        search.PropertiesToLoad.Add("cn")
        Return search.FindOne()
    End Function

    Private Sub MoveUserToOU(entry As DirectoryEntry, newOU As String)
        Dim newPath As String = $"LDAP://{newOU}"
        entry.MoveTo(New DirectoryEntry(newPath))
    End Sub

    Private Sub DisableADUser(entry As DirectoryEntry)
        entry.Properties("userAccountControl").Value = &H202 ' Disable account
        entry.CommitChanges()
    End Sub
End Class
