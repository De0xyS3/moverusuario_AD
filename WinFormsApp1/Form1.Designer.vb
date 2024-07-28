<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form1))
        btnLoadCSV = New Button()
        btnSearch = New Button()
        Label1 = New Label()
        DataGridView1 = New DataGridView()
        checkBoxFirstName = New CheckBox()
        checkBoxLastName = New CheckBox()
        checkBoxDisplayName = New CheckBox()
        comboBoxOU = New ComboBox()
        OpenFileDialog1 = New OpenFileDialog()
        btnMoveAndDisable = New Button()
        txtDomainName = New TextBox()
        GroupBox1 = New GroupBox()
        progressBar1 = New ProgressBar()
        CType(DataGridView1, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnLoadCSV
        ' 
        btnLoadCSV.Location = New Point(463, 37)
        btnLoadCSV.Name = "btnLoadCSV"
        btnLoadCSV.Size = New Size(121, 23)
        btnLoadCSV.TabIndex = 0
        btnLoadCSV.Text = "Cargar CSV"
        btnLoadCSV.UseVisualStyleBackColor = True
        ' 
        ' btnSearch
        ' 
        btnSearch.Location = New Point(430, 66)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(154, 23)
        btnSearch.TabIndex = 1
        btnSearch.Text = "Buscar Coincidencias"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(349, 41)
        Label1.Name = "Label1"
        Label1.Size = New Size(108, 15)
        Label1.TabIndex = 2
        Label1.Text = "Cargar archivo CSV"
        ' 
        ' DataGridView1
        ' 
        DataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridView1.Dock = DockStyle.Fill
        DataGridView1.Location = New Point(3, 19)
        DataGridView1.Name = "DataGridView1"
        DataGridView1.RowTemplate.Height = 25
        DataGridView1.Size = New Size(624, 296)
        DataGridView1.TabIndex = 3
        ' 
        ' checkBoxFirstName
        ' 
        checkBoxFirstName.AutoSize = True
        checkBoxFirstName.Location = New Point(12, 45)
        checkBoxFirstName.Name = "checkBoxFirstName"
        checkBoxFirstName.Size = New Size(165, 19)
        checkBoxFirstName.TabIndex = 4
        checkBoxFirstName.Text = "Buscar por nombre de pila"
        checkBoxFirstName.UseVisualStyleBackColor = True
        ' 
        ' checkBoxLastName
        ' 
        checkBoxLastName.AutoSize = True
        checkBoxLastName.Location = New Point(12, 70)
        checkBoxLastName.Name = "checkBoxLastName"
        checkBoxLastName.Size = New Size(132, 19)
        checkBoxLastName.TabIndex = 5
        checkBoxLastName.Text = "Buscar por apellidos"
        checkBoxLastName.UseVisualStyleBackColor = True
        ' 
        ' checkBoxDisplayName
        ' 
        checkBoxDisplayName.AutoSize = True
        checkBoxDisplayName.Location = New Point(12, 96)
        checkBoxDisplayName.Name = "checkBoxDisplayName"
        checkBoxDisplayName.Size = New Size(197, 19)
        checkBoxDisplayName.TabIndex = 6
        checkBoxDisplayName.Text = "Buscar por nombre para mostrar"
        checkBoxDisplayName.UseVisualStyleBackColor = True
        ' 
        ' comboBoxOU
        ' 
        comboBoxOU.FormattingEnabled = True
        comboBoxOU.Location = New Point(249, 12)
        comboBoxOU.Name = "comboBoxOU"
        comboBoxOU.Size = New Size(208, 23)
        comboBoxOU.TabIndex = 8
        ' 
        ' OpenFileDialog1
        ' 
        OpenFileDialog1.FileName = "OpenFileDialog1"
        ' 
        ' btnMoveAndDisable
        ' 
        btnMoveAndDisable.Location = New Point(430, 96)
        btnMoveAndDisable.Name = "btnMoveAndDisable"
        btnMoveAndDisable.Size = New Size(154, 23)
        btnMoveAndDisable.TabIndex = 9
        btnMoveAndDisable.Text = "Mover y Deshabilitar"
        btnMoveAndDisable.UseVisualStyleBackColor = True
        ' 
        ' txtDomainName
        ' 
        txtDomainName.Location = New Point(12, 12)
        txtDomainName.Name = "txtDomainName"
        txtDomainName.PlaceholderText = "Ingrese el nombre del dominio"
        txtDomainName.Size = New Size(221, 23)
        txtDomainName.TabIndex = 10
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(DataGridView1)
        GroupBox1.Location = New Point(3, 120)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(630, 318)
        GroupBox1.TabIndex = 11
        GroupBox1.TabStop = False
        ' 
        ' progressBar1
        ' 
        progressBar1.Location = New Point(6, 441)
        progressBar1.Name = "progressBar1"
        progressBar1.Size = New Size(624, 23)
        progressBar1.TabIndex = 4
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(636, 471)
        Controls.Add(progressBar1)
        Controls.Add(GroupBox1)
        Controls.Add(txtDomainName)
        Controls.Add(btnMoveAndDisable)
        Controls.Add(comboBoxOU)
        Controls.Add(checkBoxDisplayName)
        Controls.Add(checkBoxLastName)
        Controls.Add(checkBoxFirstName)
        Controls.Add(Label1)
        Controls.Add(btnSearch)
        Controls.Add(btnLoadCSV)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        MdiChildrenMinimizedAnchorBottom = False
        MinimizeBox = False
        Name = "Form1"
        Text = "https://github.com/De0xyS3"
        CType(DataGridView1, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnLoadCSV As Button
    Friend WithEvents btnSearch As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents checkBoxFirstName As CheckBox
    Friend WithEvents checkBoxLastName As CheckBox
    Friend WithEvents checkBoxDisplayName As CheckBox
    Friend WithEvents comboBoxOU As ComboBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents btnMoveAndDisable As Button
    Friend WithEvents txtDomainName As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents progressBar1 As ProgressBar
End Class
