<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frm_360Layout
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lstAdmisiones = New System.Windows.Forms.ListView()
        Me.Admision = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.fechaAdmision = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Sede = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Ciudad = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.grdMedicamentos = New System.Windows.Forms.DataGridView()
        Me.grdProcedimientos = New System.Windows.Forms.DataGridView()
        Me.grdFormulacion = New System.Windows.Forms.DataGridView()
        Me.grdProcedimientosExternos = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox5 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.lblTxtForm = New System.Windows.Forms.Label()
        Me.grdDiagnosticos = New System.Windows.Forms.DataGridView()
        CType(Me.grdMedicamentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProcedimientos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdFormulacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdProcedimientosExternos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdDiagnosticos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Silver
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue
        Me.Button1.Location = New System.Drawing.Point(1127, 587)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(133, 30)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Cerrar Vista"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lstAdmisiones
        '
        Me.lstAdmisiones.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lstAdmisiones.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Admision, Me.fechaAdmision, Me.Sede, Me.Ciudad})
        Me.lstAdmisiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAdmisiones.FullRowSelect = True
        Me.lstAdmisiones.HotTracking = True
        Me.lstAdmisiones.HoverSelection = True
        Me.lstAdmisiones.Location = New System.Drawing.Point(11, 73)
        Me.lstAdmisiones.Name = "lstAdmisiones"
        Me.lstAdmisiones.ShowItemToolTips = True
        Me.lstAdmisiones.Size = New System.Drawing.Size(440, 215)
        Me.lstAdmisiones.TabIndex = 1
        Me.lstAdmisiones.UseCompatibleStateImageBehavior = False
        '
        'Admision
        '
        Me.Admision.Text = "Admision"
        Me.Admision.Width = 80
        '
        'fechaAdmision
        '
        Me.fechaAdmision.Text = "Fecha Admision"
        Me.fechaAdmision.Width = 150
        '
        'Sede
        '
        Me.Sede.Text = "Sede"
        Me.Sede.Width = 150
        '
        'Ciudad
        '
        Me.Ciudad.Text = "Ciudad"
        Me.Ciudad.Width = 150
        '
        'grdMedicamentos
        '
        Me.grdMedicamentos.AllowUserToAddRows = False
        Me.grdMedicamentos.AllowUserToDeleteRows = False
        Me.grdMedicamentos.AllowUserToResizeRows = False
        Me.grdMedicamentos.BackgroundColor = System.Drawing.Color.White
        Me.grdMedicamentos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grdMedicamentos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.grdMedicamentos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.grdMedicamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.NullValue = "--"
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdMedicamentos.DefaultCellStyle = DataGridViewCellStyle1
        Me.grdMedicamentos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grdMedicamentos.GridColor = System.Drawing.Color.LightSteelBlue
        Me.grdMedicamentos.Location = New System.Drawing.Point(457, 73)
        Me.grdMedicamentos.MultiSelect = False
        Me.grdMedicamentos.Name = "grdMedicamentos"
        Me.grdMedicamentos.ReadOnly = True
        Me.grdMedicamentos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdMedicamentos.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.grdMedicamentos.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.NullValue = "--"
        Me.grdMedicamentos.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.grdMedicamentos.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.grdMedicamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdMedicamentos.ShowEditingIcon = False
        Me.grdMedicamentos.ShowRowErrors = False
        Me.grdMedicamentos.Size = New System.Drawing.Size(440, 215)
        Me.grdMedicamentos.TabIndex = 2
        '
        'grdProcedimientos
        '
        Me.grdProcedimientos.AllowUserToAddRows = False
        Me.grdProcedimientos.AllowUserToDeleteRows = False
        Me.grdProcedimientos.AllowUserToResizeRows = False
        Me.grdProcedimientos.BackgroundColor = System.Drawing.Color.White
        Me.grdProcedimientos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grdProcedimientos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.grdProcedimientos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.grdProcedimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.NullValue = "--"
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdProcedimientos.DefaultCellStyle = DataGridViewCellStyle4
        Me.grdProcedimientos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grdProcedimientos.GridColor = System.Drawing.Color.LightSteelBlue
        Me.grdProcedimientos.Location = New System.Drawing.Point(457, 349)
        Me.grdProcedimientos.MultiSelect = False
        Me.grdProcedimientos.Name = "grdProcedimientos"
        Me.grdProcedimientos.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdProcedimientos.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.grdProcedimientos.RowHeadersVisible = False
        Me.grdProcedimientos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.NullValue = "--"
        Me.grdProcedimientos.RowsDefaultCellStyle = DataGridViewCellStyle6
        Me.grdProcedimientos.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.grdProcedimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdProcedimientos.ShowEditingIcon = False
        Me.grdProcedimientos.ShowRowErrors = False
        Me.grdProcedimientos.Size = New System.Drawing.Size(440, 215)
        Me.grdProcedimientos.TabIndex = 3
        '
        'grdFormulacion
        '
        Me.grdFormulacion.AllowUserToAddRows = False
        Me.grdFormulacion.AllowUserToDeleteRows = False
        Me.grdFormulacion.AllowUserToResizeRows = False
        Me.grdFormulacion.BackgroundColor = System.Drawing.Color.White
        Me.grdFormulacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grdFormulacion.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.grdFormulacion.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.grdFormulacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.NullValue = "--"
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdFormulacion.DefaultCellStyle = DataGridViewCellStyle7
        Me.grdFormulacion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grdFormulacion.GridColor = System.Drawing.Color.LightSteelBlue
        Me.grdFormulacion.Location = New System.Drawing.Point(903, 73)
        Me.grdFormulacion.MultiSelect = False
        Me.grdFormulacion.Name = "grdFormulacion"
        Me.grdFormulacion.ReadOnly = True
        Me.grdFormulacion.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdFormulacion.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.grdFormulacion.RowHeadersVisible = False
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.NullValue = "--"
        Me.grdFormulacion.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.grdFormulacion.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.grdFormulacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdFormulacion.ShowEditingIcon = False
        Me.grdFormulacion.ShowRowErrors = False
        Me.grdFormulacion.Size = New System.Drawing.Size(440, 215)
        Me.grdFormulacion.TabIndex = 5
        '
        'grdProcedimientosExternos
        '
        Me.grdProcedimientosExternos.AllowUserToAddRows = False
        Me.grdProcedimientosExternos.AllowUserToDeleteRows = False
        Me.grdProcedimientosExternos.AllowUserToResizeRows = False
        Me.grdProcedimientosExternos.BackgroundColor = System.Drawing.Color.White
        Me.grdProcedimientosExternos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grdProcedimientosExternos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.grdProcedimientosExternos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.grdProcedimientosExternos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle10.NullValue = "--"
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdProcedimientosExternos.DefaultCellStyle = DataGridViewCellStyle10
        Me.grdProcedimientosExternos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grdProcedimientosExternos.GridColor = System.Drawing.Color.LightSteelBlue
        Me.grdProcedimientosExternos.Location = New System.Drawing.Point(903, 349)
        Me.grdProcedimientosExternos.MultiSelect = False
        Me.grdProcedimientosExternos.Name = "grdProcedimientosExternos"
        Me.grdProcedimientosExternos.ReadOnly = True
        Me.grdProcedimientosExternos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdProcedimientosExternos.RowHeadersDefaultCellStyle = DataGridViewCellStyle11
        Me.grdProcedimientosExternos.RowHeadersVisible = False
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.NullValue = "--"
        Me.grdProcedimientosExternos.RowsDefaultCellStyle = DataGridViewCellStyle12
        Me.grdProcedimientosExternos.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.grdProcedimientosExternos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdProcedimientosExternos.ShowEditingIcon = False
        Me.grdProcedimientosExternos.ShowRowErrors = False
        Me.grdProcedimientosExternos.Size = New System.Drawing.Size(440, 215)
        Me.grdProcedimientosExternos.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Olive
        Me.Label1.Location = New System.Drawing.Point(52, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 18)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Admisiones: 5 Últimas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Olive
        Me.Label2.Location = New System.Drawing.Point(498, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 18)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Medicamentos"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Olive
        Me.Label3.Location = New System.Drawing.Point(498, 316)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 18)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Procedimientos"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Olive
        Me.Label4.Location = New System.Drawing.Point(944, 318)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(187, 18)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Procedimientos Externos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Olive
        Me.Label5.Location = New System.Drawing.Point(943, 45)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(154, 18)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Formulación Externa"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Olive
        Me.Label6.Location = New System.Drawing.Point(54, 316)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 18)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Diagnósticos"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.Image = Global.HistoriaClinica.My.Resources.Resources.IconoDiagnostico
        Me.PictureBox1.Location = New System.Drawing.Point(14, 304)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(36, 39)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 14
        Me.PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = Global.HistoriaClinica.My.Resources.Resources.IconoProcedimientos
        Me.PictureBox2.Location = New System.Drawing.Point(453, 304)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(36, 39)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 15
        Me.PictureBox2.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox3.Image = Global.HistoriaClinica.My.Resources.Resources.IconoProcedimientos
        Me.PictureBox3.Location = New System.Drawing.Point(901, 306)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(36, 39)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 16
        Me.PictureBox3.TabStop = False
        '
        'PictureBox4
        '
        Me.PictureBox4.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox4.Image = Global.HistoriaClinica.My.Resources.Resources.IconoMedicina
        Me.PictureBox4.Location = New System.Drawing.Point(456, 31)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(36, 39)
        Me.PictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox4.TabIndex = 17
        Me.PictureBox4.TabStop = False
        '
        'PictureBox5
        '
        Me.PictureBox5.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox5.Image = Global.HistoriaClinica.My.Resources.Resources.IconoMedicina
        Me.PictureBox5.Location = New System.Drawing.Point(901, 32)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(36, 39)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 18
        Me.PictureBox5.TabStop = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox6.Image = Global.HistoriaClinica.My.Resources.Resources.IconoAdmisiones
        Me.PictureBox6.Location = New System.Drawing.Point(14, 31)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(36, 39)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 19
        Me.PictureBox6.TabStop = False
        '
        'lblTxtForm
        '
        Me.lblTxtForm.AutoEllipsis = True
        Me.lblTxtForm.BackColor = System.Drawing.Color.White
        Me.lblTxtForm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTxtForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblTxtForm.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTxtForm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.lblTxtForm.Location = New System.Drawing.Point(16, 1)
        Me.lblTxtForm.Name = "lblTxtForm"
        Me.lblTxtForm.Size = New System.Drawing.Size(1327, 27)
        Me.lblTxtForm.TabIndex = 13
        Me.lblTxtForm.Text = "Paciente 360 Vista Rápida: "
        Me.lblTxtForm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdDiagnosticos
        '
        Me.grdDiagnosticos.AllowUserToAddRows = False
        Me.grdDiagnosticos.AllowUserToDeleteRows = False
        Me.grdDiagnosticos.AllowUserToResizeRows = False
        Me.grdDiagnosticos.BackgroundColor = System.Drawing.Color.White
        Me.grdDiagnosticos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grdDiagnosticos.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.grdDiagnosticos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        Me.grdDiagnosticos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdDiagnosticos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.grdDiagnosticos.GridColor = System.Drawing.Color.LightSteelBlue
        Me.grdDiagnosticos.Location = New System.Drawing.Point(11, 349)
        Me.grdDiagnosticos.MultiSelect = False
        Me.grdDiagnosticos.Name = "grdDiagnosticos"
        Me.grdDiagnosticos.ReadOnly = True
        Me.grdDiagnosticos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        DataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.grdDiagnosticos.RowHeadersDefaultCellStyle = DataGridViewCellStyle13
        Me.grdDiagnosticos.RowHeadersVisible = False
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
        DataGridViewCellStyle14.NullValue = "--"
        Me.grdDiagnosticos.RowsDefaultCellStyle = DataGridViewCellStyle14
        Me.grdDiagnosticos.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grdDiagnosticos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdDiagnosticos.ShowEditingIcon = False
        Me.grdDiagnosticos.ShowRowErrors = False
        Me.grdDiagnosticos.Size = New System.Drawing.Size(440, 215)
        Me.grdDiagnosticos.TabIndex = 21
        '
        'frm_360Layout
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1352, 614)
        Me.ControlBox = False
        Me.Controls.Add(Me.grdDiagnosticos)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.PictureBox5)
        Me.Controls.Add(Me.PictureBox4)
        Me.Controls.Add(Me.PictureBox3)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblTxtForm)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.grdProcedimientosExternos)
        Me.Controls.Add(Me.grdFormulacion)
        Me.Controls.Add(Me.grdProcedimientos)
        Me.Controls.Add(Me.grdMedicamentos)
        Me.Controls.Add(Me.lstAdmisiones)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frm_360Layout"
        Me.Padding = New System.Windows.Forms.Padding(10)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.TopMost = True
        CType(Me.grdMedicamentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProcedimientos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdFormulacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdProcedimientosExternos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdDiagnosticos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents lstAdmisiones As ListView
    Friend WithEvents grdMedicamentos As DataGridView
    Friend WithEvents grdProcedimientos As DataGridView
    Friend WithEvents grdFormulacion As DataGridView
    Friend WithEvents grdProcedimientosExternos As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Admision As ColumnHeader
    Friend WithEvents Sede As ColumnHeader
    Friend WithEvents Ciudad As ColumnHeader
    Friend WithEvents fechaAdmision As ColumnHeader
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents lblTxtForm As Label
    Friend WithEvents grdDiagnosticos As DataGridView
End Class
