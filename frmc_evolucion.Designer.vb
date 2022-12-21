<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmc_evolucion
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dtgEvolucion = New System.Windows.Forms.DataGridView
        Me.cod_pre_sgsEv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cod_sucurEv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tip_docEv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.num_docEv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tip_admisionEv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ano_admEv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.num_admEv = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fecha_evol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Hora_Evol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Min_Evol = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Medico = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.notas = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Login = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fec_Con = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Obs = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.orden = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.confidencial = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DiagActual = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.subjetivo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.interpParaclic = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtNotasIngr = New System.Windows.Forms.TextBox
        Me.tbPlanManejo = New System.Windows.Forms.TextBox
        Me.tbObjetivo = New System.Windows.Forms.TextBox
        Me.tbSubjetivo = New System.Windows.Forms.TextBox
        Me.tbParaclinicos = New System.Windows.Forms.TextBox
        Me.tbDiagnostico = New System.Windows.Forms.TextBox
        Me.lblNotas = New System.Windows.Forms.Label
        Me.lbSubjetivo = New System.Windows.Forms.Label
        Me.lbObjetivo = New System.Windows.Forms.Label
        Me.lbParaclinicos = New System.Windows.Forms.Label
        Me.lbPlanManejo = New System.Windows.Forms.Label
        Me.lbDiagnostico = New System.Windows.Forms.Label
        Me.lnkNota = New System.Windows.Forms.LinkLabel
        Me.lnkSubjetivo = New System.Windows.Forms.LinkLabel
        Me.lnkObjetivo = New System.Windows.Forms.LinkLabel
        Me.lnkParaclinicos = New System.Windows.Forms.LinkLabel
        Me.lnkPlan = New System.Windows.Forms.LinkLabel
        Me.lnkDiagnostico = New System.Windows.Forms.LinkLabel
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnSalir = New System.Windows.Forms.Button
        CType(Me.dtgEvolucion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dtgEvolucion
        '
        Me.dtgEvolucion.AllowUserToAddRows = False
        Me.dtgEvolucion.AllowUserToResizeColumns = False
        Me.dtgEvolucion.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        Me.dtgEvolucion.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgEvolucion.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllHeaders
        Me.dtgEvolucion.BackgroundColor = System.Drawing.Color.White
        Me.dtgEvolucion.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgEvolucion.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dtgEvolucion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgEvolucion.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.cod_pre_sgsEv, Me.cod_sucurEv, Me.tip_docEv, Me.num_docEv, Me.tip_admisionEv, Me.ano_admEv, Me.num_admEv, Me.fecha_evol, Me.Hora_Evol, Me.Min_Evol, Me.Medico, Me.notas, Me.Login, Me.Fec_Con, Me.Obs, Me.orden, Me.confidencial, Me.DiagActual, Me.subjetivo, Me.interpParaclic})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgEvolucion.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtgEvolucion.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dtgEvolucion.GridColor = System.Drawing.Color.Gray
        Me.dtgEvolucion.Location = New System.Drawing.Point(11, 277)
        Me.dtgEvolucion.MultiSelect = False
        Me.dtgEvolucion.Name = "dtgEvolucion"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgEvolucion.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dtgEvolucion.RowHeadersWidth = 30
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black
        Me.dtgEvolucion.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dtgEvolucion.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dtgEvolucion.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgEvolucion.Size = New System.Drawing.Size(621, 111)
        Me.dtgEvolucion.TabIndex = 51
        '
        'cod_pre_sgsEv
        '
        Me.cod_pre_sgsEv.DataPropertyName = "cod_pre_sgs"
        Me.cod_pre_sgsEv.HeaderText = "cod_pre_sgs"
        Me.cod_pre_sgsEv.Name = "cod_pre_sgsEv"
        Me.cod_pre_sgsEv.Visible = False
        '
        'cod_sucurEv
        '
        Me.cod_sucurEv.DataPropertyName = "cod_sucur"
        Me.cod_sucurEv.HeaderText = "cod_sucur"
        Me.cod_sucurEv.Name = "cod_sucurEv"
        Me.cod_sucurEv.Visible = False
        '
        'tip_docEv
        '
        Me.tip_docEv.DataPropertyName = "tip_doc"
        Me.tip_docEv.HeaderText = "tip_doc"
        Me.tip_docEv.Name = "tip_docEv"
        Me.tip_docEv.Visible = False
        '
        'num_docEv
        '
        Me.num_docEv.DataPropertyName = "num_doc"
        Me.num_docEv.HeaderText = "num_doc"
        Me.num_docEv.Name = "num_docEv"
        Me.num_docEv.Visible = False
        '
        'tip_admisionEv
        '
        Me.tip_admisionEv.DataPropertyName = "tip_admision"
        Me.tip_admisionEv.HeaderText = "tip_admision"
        Me.tip_admisionEv.Name = "tip_admisionEv"
        Me.tip_admisionEv.Visible = False
        '
        'ano_admEv
        '
        Me.ano_admEv.DataPropertyName = "ano_adm"
        Me.ano_admEv.HeaderText = "ano_adm"
        Me.ano_admEv.Name = "ano_admEv"
        Me.ano_admEv.Visible = False
        '
        'num_admEv
        '
        Me.num_admEv.DataPropertyName = "num_adm"
        Me.num_admEv.HeaderText = "num_adm"
        Me.num_admEv.Name = "num_admEv"
        Me.num_admEv.Visible = False
        '
        'fecha_evol
        '
        Me.fecha_evol.DataPropertyName = "fecha_evol"
        Me.fecha_evol.HeaderText = "Fecha_Evolucion"
        Me.fecha_evol.Name = "fecha_evol"
        '
        'Hora_Evol
        '
        Me.Hora_Evol.DataPropertyName = "Hora_Evol"
        Me.Hora_Evol.HeaderText = "Hora_Evolucion"
        Me.Hora_Evol.Name = "Hora_Evol"
        '
        'Min_Evol
        '
        Me.Min_Evol.DataPropertyName = "Min_Evol"
        Me.Min_Evol.HeaderText = "Min_Evolucion"
        Me.Min_Evol.Name = "Min_Evol"
        '
        'Medico
        '
        Me.Medico.DataPropertyName = "Medico"
        Me.Medico.HeaderText = "Medico"
        Me.Medico.Name = "Medico"
        '
        'notas
        '
        Me.notas.DataPropertyName = "notas"
        Me.notas.HeaderText = "Objetivo"
        Me.notas.Name = "notas"
        '
        'Login
        '
        Me.Login.DataPropertyName = "Login"
        Me.Login.HeaderText = "Login"
        Me.Login.Name = "Login"
        Me.Login.Visible = False
        '
        'Fec_Con
        '
        Me.Fec_Con.DataPropertyName = "Fec_Con"
        Me.Fec_Con.HeaderText = "Fec_Con"
        Me.Fec_Con.Name = "Fec_Con"
        Me.Fec_Con.Visible = False
        '
        'Obs
        '
        Me.Obs.DataPropertyName = "Obs"
        Me.Obs.HeaderText = "Obs"
        Me.Obs.Name = "Obs"
        Me.Obs.Visible = False
        '
        'orden
        '
        Me.orden.DataPropertyName = "orden"
        Me.orden.HeaderText = "Plan_de_Manejo"
        Me.orden.Name = "orden"
        '
        'confidencial
        '
        Me.confidencial.DataPropertyName = "confidencial"
        Me.confidencial.HeaderText = "confidencial"
        Me.confidencial.Name = "confidencial"
        Me.confidencial.Visible = False
        '
        'DiagActual
        '
        Me.DiagActual.DataPropertyName = "DiagActual"
        Me.DiagActual.HeaderText = "Diagnostico_Actual"
        Me.DiagActual.Name = "DiagActual"
        '
        'subjetivo
        '
        Me.subjetivo.DataPropertyName = "subjetivo"
        Me.subjetivo.HeaderText = "subjetivo"
        Me.subjetivo.Name = "subjetivo"
        '
        'interpParaclic
        '
        Me.interpParaclic.DataPropertyName = "interpParaclic"
        Me.interpParaclic.HeaderText = "Interpretacion"
        Me.interpParaclic.Name = "interpParaclic"
        '
        'txtNotasIngr
        '
        Me.txtNotasIngr.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNotasIngr.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNotasIngr.Location = New System.Drawing.Point(12, 22)
        Me.txtNotasIngr.MaxLength = 5000
        Me.txtNotasIngr.Multiline = True
        Me.txtNotasIngr.Name = "txtNotasIngr"
        Me.txtNotasIngr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtNotasIngr.Size = New System.Drawing.Size(307, 68)
        Me.txtNotasIngr.TabIndex = 52
        '
        'tbPlanManejo
        '
        Me.tbPlanManejo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbPlanManejo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbPlanManejo.Location = New System.Drawing.Point(12, 200)
        Me.tbPlanManejo.MaxLength = 1500
        Me.tbPlanManejo.Multiline = True
        Me.tbPlanManejo.Name = "tbPlanManejo"
        Me.tbPlanManejo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbPlanManejo.Size = New System.Drawing.Size(307, 68)
        Me.tbPlanManejo.TabIndex = 56
        '
        'tbObjetivo
        '
        Me.tbObjetivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbObjetivo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbObjetivo.Location = New System.Drawing.Point(12, 111)
        Me.tbObjetivo.MaxLength = 5000
        Me.tbObjetivo.Multiline = True
        Me.tbObjetivo.Name = "tbObjetivo"
        Me.tbObjetivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbObjetivo.Size = New System.Drawing.Size(307, 68)
        Me.tbObjetivo.TabIndex = 54
        '
        'tbSubjetivo
        '
        Me.tbSubjetivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbSubjetivo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbSubjetivo.Location = New System.Drawing.Point(332, 22)
        Me.tbSubjetivo.MaxLength = 500
        Me.tbSubjetivo.Multiline = True
        Me.tbSubjetivo.Name = "tbSubjetivo"
        Me.tbSubjetivo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbSubjetivo.Size = New System.Drawing.Size(307, 68)
        Me.tbSubjetivo.TabIndex = 53
        '
        'tbParaclinicos
        '
        Me.tbParaclinicos.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbParaclinicos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbParaclinicos.Location = New System.Drawing.Point(332, 111)
        Me.tbParaclinicos.MaxLength = 3000
        Me.tbParaclinicos.Multiline = True
        Me.tbParaclinicos.Name = "tbParaclinicos"
        Me.tbParaclinicos.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbParaclinicos.Size = New System.Drawing.Size(307, 68)
        Me.tbParaclinicos.TabIndex = 55
        '
        'tbDiagnostico
        '
        Me.tbDiagnostico.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.tbDiagnostico.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDiagnostico.Location = New System.Drawing.Point(332, 199)
        Me.tbDiagnostico.MaxLength = 500
        Me.tbDiagnostico.Multiline = True
        Me.tbDiagnostico.Name = "tbDiagnostico"
        Me.tbDiagnostico.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbDiagnostico.Size = New System.Drawing.Size(307, 68)
        Me.tbDiagnostico.TabIndex = 57
        '
        'lblNotas
        '
        Me.lblNotas.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblNotas.Location = New System.Drawing.Point(12, 4)
        Me.lblNotas.Name = "lblNotas"
        Me.lblNotas.Size = New System.Drawing.Size(155, 18)
        Me.lblNotas.TabIndex = 58
        Me.lblNotas.Text = "Notas De Ingreso"
        '
        'lbSubjetivo
        '
        Me.lbSubjetivo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSubjetivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbSubjetivo.Location = New System.Drawing.Point(329, 4)
        Me.lbSubjetivo.Name = "lbSubjetivo"
        Me.lbSubjetivo.Size = New System.Drawing.Size(77, 15)
        Me.lbSubjetivo.TabIndex = 59
        Me.lbSubjetivo.Text = "Subjetivo"
        '
        'lbObjetivo
        '
        Me.lbObjetivo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbObjetivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbObjetivo.Location = New System.Drawing.Point(12, 90)
        Me.lbObjetivo.Name = "lbObjetivo"
        Me.lbObjetivo.Size = New System.Drawing.Size(77, 19)
        Me.lbObjetivo.TabIndex = 60
        Me.lbObjetivo.Text = "Objetivo"
        '
        'lbParaclinicos
        '
        Me.lbParaclinicos.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbParaclinicos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbParaclinicos.Location = New System.Drawing.Point(329, 91)
        Me.lbParaclinicos.Name = "lbParaclinicos"
        Me.lbParaclinicos.Size = New System.Drawing.Size(193, 19)
        Me.lbParaclinicos.TabIndex = 61
        Me.lbParaclinicos.Text = "Interpretación Paraclínicos"
        '
        'lbPlanManejo
        '
        Me.lbPlanManejo.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPlanManejo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbPlanManejo.Location = New System.Drawing.Point(12, 182)
        Me.lbPlanManejo.Name = "lbPlanManejo"
        Me.lbPlanManejo.Size = New System.Drawing.Size(174, 18)
        Me.lbPlanManejo.TabIndex = 62
        Me.lbPlanManejo.Text = "Plan de Manejo"
        '
        'lbDiagnostico
        '
        Me.lbDiagnostico.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDiagnostico.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lbDiagnostico.Location = New System.Drawing.Point(329, 182)
        Me.lbDiagnostico.Name = "lbDiagnostico"
        Me.lbDiagnostico.Size = New System.Drawing.Size(201, 18)
        Me.lbDiagnostico.TabIndex = 63
        Me.lbDiagnostico.Text = "Diagnóstico Actual"
        '
        'lnkNota
        '
        Me.lnkNota.AutoSize = True
        Me.lnkNota.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lnkNota.LinkColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lnkNota.Location = New System.Drawing.Point(231, 4)
        Me.lnkNota.Name = "lnkNota"
        Me.lnkNota.Size = New System.Drawing.Size(83, 13)
        Me.lnkNota.TabIndex = 64
        Me.lnkNota.TabStop = True
        Me.lnkNota.Text = "Copiar Nota"
        '
        'lnkSubjetivo
        '
        Me.lnkSubjetivo.AutoSize = True
        Me.lnkSubjetivo.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lnkSubjetivo.LinkColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lnkSubjetivo.Location = New System.Drawing.Point(517, 5)
        Me.lnkSubjetivo.Name = "lnkSubjetivo"
        Me.lnkSubjetivo.Size = New System.Drawing.Size(115, 13)
        Me.lnkSubjetivo.TabIndex = 65
        Me.lnkSubjetivo.TabStop = True
        Me.lnkSubjetivo.Text = "Copiar Subjetivo"
        '
        'lnkObjetivo
        '
        Me.lnkObjetivo.AutoSize = True
        Me.lnkObjetivo.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lnkObjetivo.LinkColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lnkObjetivo.Location = New System.Drawing.Point(206, 91)
        Me.lnkObjetivo.Name = "lnkObjetivo"
        Me.lnkObjetivo.Size = New System.Drawing.Size(108, 13)
        Me.lnkObjetivo.TabIndex = 66
        Me.lnkObjetivo.TabStop = True
        Me.lnkObjetivo.Text = "Copiar Objetivo"
        '
        'lnkParaclinicos
        '
        Me.lnkParaclinicos.AutoSize = True
        Me.lnkParaclinicos.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lnkParaclinicos.LinkColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lnkParaclinicos.Location = New System.Drawing.Point(517, 92)
        Me.lnkParaclinicos.Name = "lnkParaclinicos"
        Me.lnkParaclinicos.Size = New System.Drawing.Size(117, 13)
        Me.lnkParaclinicos.TabIndex = 67
        Me.lnkParaclinicos.TabStop = True
        Me.lnkParaclinicos.Text = "Copiar Paraclínic"
        '
        'lnkPlan
        '
        Me.lnkPlan.AutoSize = True
        Me.lnkPlan.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lnkPlan.LinkColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lnkPlan.Location = New System.Drawing.Point(162, 182)
        Me.lnkPlan.Name = "lnkPlan"
        Me.lnkPlan.Size = New System.Drawing.Size(152, 13)
        Me.lnkPlan.TabIndex = 68
        Me.lnkPlan.TabStop = True
        Me.lnkPlan.Text = "Copiar Plan de Manejo"
        '
        'lnkDiagnostico
        '
        Me.lnkDiagnostico.AutoSize = True
        Me.lnkDiagnostico.Font = New System.Drawing.Font("Verdana", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lnkDiagnostico.LinkColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lnkDiagnostico.Location = New System.Drawing.Point(505, 183)
        Me.lnkDiagnostico.Name = "lnkDiagnostico"
        Me.lnkDiagnostico.Size = New System.Drawing.Size(129, 13)
        Me.lnkDiagnostico.TabIndex = 69
        Me.lnkDiagnostico.TabStop = True
        Me.lnkDiagnostico.Text = "Copiar Diagnóstico"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "cod_pre_sgs"
        Me.DataGridViewTextBoxColumn1.HeaderText = "cod_pre_sgs"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.Visible = False
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "cod_sucur"
        Me.DataGridViewTextBoxColumn2.HeaderText = "cod_sucur"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.Visible = False
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "tip_doc"
        Me.DataGridViewTextBoxColumn3.HeaderText = "tip_doc"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.Visible = False
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "num_doc"
        Me.DataGridViewTextBoxColumn4.HeaderText = "num_doc"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.Visible = False
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "tip_admision"
        Me.DataGridViewTextBoxColumn5.HeaderText = "tip_admision"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.Visible = False
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "ano_adm"
        Me.DataGridViewTextBoxColumn6.HeaderText = "ano_adm"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.Visible = False
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "num_adm"
        Me.DataGridViewTextBoxColumn7.HeaderText = "num_adm"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.Visible = False
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "fecha_evol"
        Me.DataGridViewTextBoxColumn8.HeaderText = "Fecha_Evolucion"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "Hora_Evol"
        Me.DataGridViewTextBoxColumn9.HeaderText = "Hora_Evolucion"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Min_Evol"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Min_Evolucion"
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "Medico"
        Me.DataGridViewTextBoxColumn11.HeaderText = "Medico"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "notas"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Objetivo"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "Login"
        Me.DataGridViewTextBoxColumn13.HeaderText = "Login"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.Visible = False
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "Fec_Con"
        Me.DataGridViewTextBoxColumn14.HeaderText = "Fec_Con"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Visible = False
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "Obs"
        Me.DataGridViewTextBoxColumn15.HeaderText = "Obs"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.Visible = False
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "orden"
        Me.DataGridViewTextBoxColumn16.HeaderText = "Plan_de_Manejo"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "confidencial"
        Me.DataGridViewTextBoxColumn17.HeaderText = "confidencial"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.Visible = False
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "DiagActual"
        Me.DataGridViewTextBoxColumn18.HeaderText = "Diagnostico_Actual"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "subjetivo"
        Me.DataGridViewTextBoxColumn19.HeaderText = "subjetivo"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "interpParaclic"
        Me.DataGridViewTextBoxColumn20.HeaderText = "Interpretacion"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.Color.Transparent
        Me.btnSalir.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_salir
        Me.btnSalir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSalir.ForeColor = System.Drawing.Color.Transparent
        Me.btnSalir.Location = New System.Drawing.Point(520, 403)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(104, 22)
        Me.btnSalir.TabIndex = 70
        Me.btnSalir.UseVisualStyleBackColor = False
        '
        'frmc_evolucion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(235, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(230, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(644, 433)
        Me.Controls.Add(Me.btnSalir)
        Me.Controls.Add(Me.lnkDiagnostico)
        Me.Controls.Add(Me.lnkPlan)
        Me.Controls.Add(Me.lnkParaclinicos)
        Me.Controls.Add(Me.lnkObjetivo)
        Me.Controls.Add(Me.lnkSubjetivo)
        Me.Controls.Add(Me.lnkNota)
        Me.Controls.Add(Me.lbDiagnostico)
        Me.Controls.Add(Me.lbPlanManejo)
        Me.Controls.Add(Me.lbParaclinicos)
        Me.Controls.Add(Me.lbObjetivo)
        Me.Controls.Add(Me.lbSubjetivo)
        Me.Controls.Add(Me.lblNotas)
        Me.Controls.Add(Me.txtNotasIngr)
        Me.Controls.Add(Me.tbPlanManejo)
        Me.Controls.Add(Me.tbObjetivo)
        Me.Controls.Add(Me.tbSubjetivo)
        Me.Controls.Add(Me.tbParaclinicos)
        Me.Controls.Add(Me.tbDiagnostico)
        Me.Controls.Add(Me.dtgEvolucion)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmc_evolucion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Evolución"
        CType(Me.dtgEvolucion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgEvolucion As System.Windows.Forms.DataGridView
    Friend WithEvents cod_pre_sgsEv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cod_sucurEv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tip_docEv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents num_docEv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tip_admisionEv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ano_admEv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents num_admEv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fecha_evol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Hora_Evol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Min_Evol As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Medico As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents notas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Login As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fec_Con As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Obs As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents orden As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents confidencial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiagActual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents subjetivo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents interpParaclic As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtNotasIngr As System.Windows.Forms.TextBox
    Friend WithEvents tbPlanManejo As System.Windows.Forms.TextBox
    Friend WithEvents tbObjetivo As System.Windows.Forms.TextBox
    Friend WithEvents tbSubjetivo As System.Windows.Forms.TextBox
    Friend WithEvents tbParaclinicos As System.Windows.Forms.TextBox
    Friend WithEvents tbDiagnostico As System.Windows.Forms.TextBox
    Friend WithEvents lblNotas As System.Windows.Forms.Label
    Friend WithEvents lbSubjetivo As System.Windows.Forms.Label
    Friend WithEvents lbObjetivo As System.Windows.Forms.Label
    Friend WithEvents lbParaclinicos As System.Windows.Forms.Label
    Friend WithEvents lbPlanManejo As System.Windows.Forms.Label
    Friend WithEvents lbDiagnostico As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lnkNota As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkSubjetivo As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkObjetivo As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkParaclinicos As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkPlan As System.Windows.Forms.LinkLabel
    Friend WithEvents lnkDiagnostico As System.Windows.Forms.LinkLabel
    Friend WithEvents btnSalir As System.Windows.Forms.Button
End Class
