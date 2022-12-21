<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ctlSeguimientoCateter
    Inherits System.Windows.Forms.UserControl

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grbSeguimientoCateter = New System.Windows.Forms.GroupBox()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.btnAgSeg = New System.Windows.Forms.Button()
        Me.dtgsegcateter = New System.Windows.Forms.DataGridView()
        Me.Fec_con = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DiaCateter = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodEstSitIns = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstSitIns = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.valcuracion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codCuracion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Curacion = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codverifica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.verifica = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.codgestionf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.gestionf = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CodMotivoret = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Motivoret = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EstadoReg = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Responsable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Especialidad = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GrpInfCateter = New System.Windows.Forms.GroupBox()
        Me.txtfecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtespecialidad = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtresponsable = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtnpuncion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtcomplicaciones = New System.Windows.Forms.TextBox()
        Me.lblind = New System.Windows.Forms.Label()
        Me.txtindicaciones = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtlateralidad = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtzonains = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txttipcateter = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.grbSeguimientoCateter.SuspendLayout()
        CType(Me.dtgsegcateter, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GrpInfCateter.SuspendLayout()
        Me.SuspendLayout()
        '
        'grbSeguimientoCateter
        '
        Me.grbSeguimientoCateter.Controls.Add(Me.BtnGuardar)
        Me.grbSeguimientoCateter.Controls.Add(Me.btnAgSeg)
        Me.grbSeguimientoCateter.Controls.Add(Me.dtgsegcateter)
        Me.grbSeguimientoCateter.Controls.Add(Me.GrpInfCateter)
        Me.grbSeguimientoCateter.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
        Me.grbSeguimientoCateter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.grbSeguimientoCateter.Location = New System.Drawing.Point(3, 2)
        Me.grbSeguimientoCateter.Name = "grbSeguimientoCateter"
        Me.grbSeguimientoCateter.Size = New System.Drawing.Size(816, 368)
        Me.grbSeguimientoCateter.TabIndex = 184
        Me.grbSeguimientoCateter.TabStop = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Location = New System.Drawing.Point(719, 322)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(80, 20)
        Me.BtnGuardar.TabIndex = 298
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.UseVisualStyleBackColor = True
        '
        'btnAgSeg
        '
        Me.btnAgSeg.Location = New System.Drawing.Point(520, 321)
        Me.btnAgSeg.Name = "btnAgSeg"
        Me.btnAgSeg.Size = New System.Drawing.Size(175, 23)
        Me.btnAgSeg.TabIndex = 297
        Me.btnAgSeg.Text = "Agregar Seguimiento"
        Me.btnAgSeg.UseVisualStyleBackColor = True
        '
        'dtgsegcateter
        '
        Me.dtgsegcateter.AllowUserToAddRows = False
        Me.dtgsegcateter.AllowUserToDeleteRows = False
        Me.dtgsegcateter.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.dtgsegcateter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgsegcateter.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Fec_con, Me.DiaCateter, Me.CodEstSitIns, Me.EstSitIns, Me.valcuracion, Me.codCuracion, Me.Curacion, Me.codverifica, Me.verifica, Me.codgestionf, Me.gestionf, Me.CodMotivoret, Me.Motivoret, Me.EstadoReg, Me.Responsable, Me.Especialidad})
        Me.dtgsegcateter.Location = New System.Drawing.Point(11, 152)
        Me.dtgsegcateter.Name = "dtgsegcateter"
        Me.dtgsegcateter.ReadOnly = True
        DataGridViewCellStyle2.Format = "G"
        Me.dtgsegcateter.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgsegcateter.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgsegcateter.Size = New System.Drawing.Size(800, 163)
        Me.dtgsegcateter.TabIndex = 296
        '
        'Fec_con
        '
        Me.Fec_con.DataPropertyName = "Fec_con"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Fec_con.DefaultCellStyle = DataGridViewCellStyle1
        Me.Fec_con.HeaderText = "Fecha y Hora"
        Me.Fec_con.Name = "Fec_con"
        Me.Fec_con.ReadOnly = True
        Me.Fec_con.Width = 150
        '
        'DiaCateter
        '
        Me.DiaCateter.DataPropertyName = "DiaCateter"
        Me.DiaCateter.HeaderText = "Día Catéter"
        Me.DiaCateter.Name = "DiaCateter"
        Me.DiaCateter.ReadOnly = True
        Me.DiaCateter.Width = 70
        '
        'CodEstSitIns
        '
        Me.CodEstSitIns.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.CodEstSitIns.DataPropertyName = "CodEstSitIns"
        Me.CodEstSitIns.HeaderText = "Codigo Estado Sitio Insercion"
        Me.CodEstSitIns.Name = "CodEstSitIns"
        Me.CodEstSitIns.ReadOnly = True
        Me.CodEstSitIns.Visible = False
        Me.CodEstSitIns.Width = 5
        '
        'EstSitIns
        '
        Me.EstSitIns.DataPropertyName = "EstSitIns"
        Me.EstSitIns.HeaderText = "Estado Sitio de Insercción"
        Me.EstSitIns.Name = "EstSitIns"
        Me.EstSitIns.ReadOnly = True
        Me.EstSitIns.Width = 150
        '
        'valcuracion
        '
        Me.valcuracion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.valcuracion.DataPropertyName = "valcuracion"
        Me.valcuracion.HeaderText = "Valida Curacion"
        Me.valcuracion.Name = "valcuracion"
        Me.valcuracion.ReadOnly = True
        Me.valcuracion.Visible = False
        Me.valcuracion.Width = 5
        '
        'codCuracion
        '
        Me.codCuracion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.codCuracion.DataPropertyName = "codCuracion"
        Me.codCuracion.HeaderText = "Codigo Curación"
        Me.codCuracion.Name = "codCuracion"
        Me.codCuracion.ReadOnly = True
        Me.codCuracion.Visible = False
        Me.codCuracion.Width = 5
        '
        'Curacion
        '
        Me.Curacion.DataPropertyName = "Curacion"
        Me.Curacion.HeaderText = "Curación"
        Me.Curacion.Name = "Curacion"
        Me.Curacion.ReadOnly = True
        Me.Curacion.Width = 150
        '
        'codverifica
        '
        Me.codverifica.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.codverifica.DataPropertyName = "codverifica"
        Me.codverifica.HeaderText = "Codigo Verifica"
        Me.codverifica.Name = "codverifica"
        Me.codverifica.ReadOnly = True
        Me.codverifica.Visible = False
        Me.codverifica.Width = 5
        '
        'verifica
        '
        Me.verifica.DataPropertyName = "verifica"
        Me.verifica.HeaderText = "Se Verifica"
        Me.verifica.Name = "verifica"
        Me.verifica.ReadOnly = True
        Me.verifica.Width = 150
        '
        'codgestionf
        '
        Me.codgestionf.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.codgestionf.DataPropertyName = "codgestionf"
        Me.codgestionf.HeaderText = "Codigo gestion Final"
        Me.codgestionf.Name = "codgestionf"
        Me.codgestionf.ReadOnly = True
        Me.codgestionf.Visible = False
        Me.codgestionf.Width = 5
        '
        'gestionf
        '
        Me.gestionf.DataPropertyName = "gestionf"
        Me.gestionf.HeaderText = "Gestion Final"
        Me.gestionf.Name = "gestionf"
        Me.gestionf.ReadOnly = True
        Me.gestionf.Width = 150
        '
        'CodMotivoret
        '
        Me.CodMotivoret.DataPropertyName = "CodMotivoret"
        Me.CodMotivoret.HeaderText = "Codigo Motivo Retiro"
        Me.CodMotivoret.Name = "CodMotivoret"
        Me.CodMotivoret.ReadOnly = True
        Me.CodMotivoret.Visible = False
        '
        'Motivoret
        '
        Me.Motivoret.DataPropertyName = "Motivoret"
        Me.Motivoret.HeaderText = "Motivo de Retiro"
        Me.Motivoret.Name = "Motivoret"
        Me.Motivoret.ReadOnly = True
        Me.Motivoret.Width = 110
        '
        'EstadoReg
        '
        Me.EstadoReg.DataPropertyName = "EstadoReg"
        Me.EstadoReg.HeaderText = "Estado Registro"
        Me.EstadoReg.Name = "EstadoReg"
        Me.EstadoReg.ReadOnly = True
        Me.EstadoReg.Visible = False
        '
        'Responsable
        '
        Me.Responsable.DataPropertyName = "Responsable"
        Me.Responsable.HeaderText = "Responsable"
        Me.Responsable.Name = "Responsable"
        Me.Responsable.ReadOnly = True
        '
        'Especialidad
        '
        Me.Especialidad.DataPropertyName = "Especialidad"
        Me.Especialidad.HeaderText = "Especialidad"
        Me.Especialidad.Name = "Especialidad"
        Me.Especialidad.ReadOnly = True
        '
        'GrpInfCateter
        '
        Me.GrpInfCateter.Controls.Add(Me.txtfecha)
        Me.GrpInfCateter.Controls.Add(Me.Label8)
        Me.GrpInfCateter.Controls.Add(Me.txtespecialidad)
        Me.GrpInfCateter.Controls.Add(Me.Label7)
        Me.GrpInfCateter.Controls.Add(Me.txtresponsable)
        Me.GrpInfCateter.Controls.Add(Me.Label6)
        Me.GrpInfCateter.Controls.Add(Me.txtnpuncion)
        Me.GrpInfCateter.Controls.Add(Me.Label5)
        Me.GrpInfCateter.Controls.Add(Me.txtcomplicaciones)
        Me.GrpInfCateter.Controls.Add(Me.lblind)
        Me.GrpInfCateter.Controls.Add(Me.txtindicaciones)
        Me.GrpInfCateter.Controls.Add(Me.Label4)
        Me.GrpInfCateter.Controls.Add(Me.txtlateralidad)
        Me.GrpInfCateter.Controls.Add(Me.Label3)
        Me.GrpInfCateter.Controls.Add(Me.txtzonains)
        Me.GrpInfCateter.Controls.Add(Me.Label2)
        Me.GrpInfCateter.Controls.Add(Me.txttipcateter)
        Me.GrpInfCateter.Controls.Add(Me.Label1)
        Me.GrpInfCateter.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrpInfCateter.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.GrpInfCateter.Location = New System.Drawing.Point(6, 16)
        Me.GrpInfCateter.Name = "GrpInfCateter"
        Me.GrpInfCateter.Size = New System.Drawing.Size(806, 130)
        Me.GrpInfCateter.TabIndex = 295
        Me.GrpInfCateter.TabStop = False
        Me.GrpInfCateter.Text = "Información del Catéter"
        '
        'txtfecha
        '
        Me.txtfecha.Font = New System.Drawing.Font("Verdana", 8.25!)
        Me.txtfecha.Location = New System.Drawing.Point(10, 38)
        Me.txtfecha.Mask = "00/00/0000 00:00"
        Me.txtfecha.Name = "txtfecha"
        Me.txtfecha.Size = New System.Drawing.Size(113, 21)
        Me.txtfecha.TabIndex = 18
        Me.txtfecha.ValidatingType = GetType(Date)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(597, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Especialidad"
        '
        'txtespecialidad
        '
        Me.txtespecialidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtespecialidad.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtespecialidad.Location = New System.Drawing.Point(597, 90)
        Me.txtespecialidad.Name = "txtespecialidad"
        Me.txtespecialidad.Size = New System.Drawing.Size(202, 21)
        Me.txtespecialidad.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(397, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Responsable"
        '
        'txtresponsable
        '
        Me.txtresponsable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtresponsable.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtresponsable.Location = New System.Drawing.Point(399, 90)
        Me.txtresponsable.Name = "txtresponsable"
        Me.txtresponsable.Size = New System.Drawing.Size(194, 21)
        Me.txtresponsable.TabIndex = 14
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(276, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 13)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "# de Punciones"
        '
        'txtnpuncion
        '
        Me.txtnpuncion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtnpuncion.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtnpuncion.Location = New System.Drawing.Point(280, 90)
        Me.txtnpuncion.Name = "txtnpuncion"
        Me.txtnpuncion.Size = New System.Drawing.Size(114, 21)
        Me.txtnpuncion.TabIndex = 12
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 70)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "Complicaciones"
        '
        'txtcomplicaciones
        '
        Me.txtcomplicaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtcomplicaciones.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtcomplicaciones.Location = New System.Drawing.Point(12, 90)
        Me.txtcomplicaciones.Name = "txtcomplicaciones"
        Me.txtcomplicaciones.Size = New System.Drawing.Size(263, 21)
        Me.txtcomplicaciones.TabIndex = 10
        '
        'lblind
        '
        Me.lblind.AutoSize = True
        Me.lblind.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblind.Location = New System.Drawing.Point(543, 18)
        Me.lblind.Name = "lblind"
        Me.lblind.Size = New System.Drawing.Size(78, 13)
        Me.lblind.TabIndex = 9
        Me.lblind.Text = "Indicaciones"
        '
        'txtindicaciones
        '
        Me.txtindicaciones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtindicaciones.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtindicaciones.Location = New System.Drawing.Point(536, 38)
        Me.txtindicaciones.Name = "txtindicaciones"
        Me.txtindicaciones.Size = New System.Drawing.Size(266, 21)
        Me.txtindicaciones.TabIndex = 8
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(407, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Lateralidad"
        '
        'txtlateralidad
        '
        Me.txtlateralidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtlateralidad.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtlateralidad.Location = New System.Drawing.Point(404, 38)
        Me.txtlateralidad.Name = "txtlateralidad"
        Me.txtlateralidad.Size = New System.Drawing.Size(129, 21)
        Me.txtlateralidad.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(246, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(111, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Zona de Inserción"
        '
        'txtzonains
        '
        Me.txtzonains.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtzonains.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtzonains.Location = New System.Drawing.Point(247, 38)
        Me.txtzonains.Name = "txtzonains"
        Me.txtzonains.Size = New System.Drawing.Size(152, 21)
        Me.txtzonains.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(125, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Tipo Catéter"
        '
        'txttipcateter
        '
        Me.txttipcateter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txttipcateter.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txttipcateter.Location = New System.Drawing.Point(126, 38)
        Me.txttipcateter.Name = "txttipcateter"
        Me.txttipcateter.Size = New System.Drawing.Size(117, 21)
        Me.txttipcateter.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(10, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha y Hora"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "Fec_con"
        DataGridViewCellStyle3.Format = "G"
        DataGridViewCellStyle3.NullValue = " "
        Me.DataGridViewTextBoxColumn1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridViewTextBoxColumn1.HeaderText = "Fecha y Hora"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 120
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "DiaCateter"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Día Catéter"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 120
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "CodEstSitIns"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Estado Sitio de Insercción"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Visible = False
        Me.DataGridViewTextBoxColumn3.Width = 5
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "EstSitIns"
        Me.DataGridViewTextBoxColumn4.HeaderText = "Curación"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Visible = False
        Me.DataGridViewTextBoxColumn4.Width = 110
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "valcuracion"
        Me.DataGridViewTextBoxColumn5.HeaderText = "Se Verifica"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Visible = False
        Me.DataGridViewTextBoxColumn5.Width = 5
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "codCuracion"
        Me.DataGridViewTextBoxColumn6.HeaderText = "Gestion Final"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        Me.DataGridViewTextBoxColumn6.Width = 5
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "Curacion"
        Me.DataGridViewTextBoxColumn7.HeaderText = "Motivo de Retiro"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 110
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "codverifica"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Motivo de Retiro"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Visible = False
        Me.DataGridViewTextBoxColumn8.Width = 110
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "verifica"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Motivo de Retiro"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 110
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "codgestionf"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Motivo de Retiro"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Visible = False
        Me.DataGridViewTextBoxColumn10.Width = 110
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "gestionf"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Gestion Final"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 110
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "CodMotivoret"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Codigo Motivo Retiro"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Visible = False
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "Motivoret"
        Me.DataGridViewTextBoxColumn13.HeaderText = "Motivo de Retiro"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 110
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "EstadoReg"
        Me.DataGridViewTextBoxColumn14.HeaderText = "Estado Registro"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.ReadOnly = True
        Me.DataGridViewTextBoxColumn14.Visible = False
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "Responsable"
        Me.DataGridViewTextBoxColumn15.HeaderText = "Responsable"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "especialidad"
        Me.DataGridViewTextBoxColumn16.HeaderText = "Especialidad"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        '
        'ctlSeguimientoCateter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.grbSeguimientoCateter)
        Me.Name = "ctlSeguimientoCateter"
        Me.Size = New System.Drawing.Size(822, 370)
        Me.grbSeguimientoCateter.ResumeLayout(False)
        CType(Me.dtgsegcateter, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GrpInfCateter.ResumeLayout(False)
        Me.GrpInfCateter.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grbSeguimientoCateter As System.Windows.Forms.GroupBox
    Friend WithEvents GrpInfCateter As GroupBox
    Friend WithEvents txtfecha As MaskedTextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtespecialidad As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtresponsable As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtnpuncion As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtcomplicaciones As TextBox
    Friend WithEvents lblind As Label
    Friend WithEvents txtindicaciones As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtlateralidad As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtzonains As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txttipcateter As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtgsegcateter As DataGridView
    Friend WithEvents btnAgSeg As Button
    Friend WithEvents BtnGuardar As Button
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
    Friend WithEvents Fec_con As DataGridViewTextBoxColumn
    Friend WithEvents DiaCateter As DataGridViewTextBoxColumn
    Friend WithEvents CodEstSitIns As DataGridViewTextBoxColumn
    Friend WithEvents EstSitIns As DataGridViewTextBoxColumn
    Friend WithEvents valcuracion As DataGridViewTextBoxColumn
    Friend WithEvents codCuracion As DataGridViewTextBoxColumn
    Friend WithEvents Curacion As DataGridViewTextBoxColumn
    Friend WithEvents codverifica As DataGridViewTextBoxColumn
    Friend WithEvents verifica As DataGridViewTextBoxColumn
    Friend WithEvents codgestionf As DataGridViewTextBoxColumn
    Friend WithEvents gestionf As DataGridViewTextBoxColumn
    Friend WithEvents CodMotivoret As DataGridViewTextBoxColumn
    Friend WithEvents Motivoret As DataGridViewTextBoxColumn
    Friend WithEvents EstadoReg As DataGridViewTextBoxColumn
    Friend WithEvents Responsable As DataGridViewTextBoxColumn
    Friend WithEvents Especialidad As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn
    Friend WithEvents ToolTip1 As ToolTip
End Class
