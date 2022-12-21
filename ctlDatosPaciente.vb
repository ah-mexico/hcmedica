Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes

Public Class ctlDatosPaciente
    Inherits System.Windows.Forms.UserControl
    Private Shared _Instancia As ctlDatosPaciente

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'UserControl reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents pnlDatosPersonales As System.Windows.Forms.Panel
    Friend WithEvents lblDPTipoDoc As System.Windows.Forms.Label
    Friend WithEvents lblDpNombre As System.Windows.Forms.Label
    Friend WithEvents lblDpDocumento As System.Windows.Forms.Label
    Friend WithEvents lblDpGenero As System.Windows.Forms.Label
    Friend WithEvents lblDpEdad As System.Windows.Forms.Label
    Friend WithEvents lblTipoDocumento As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents lblNumeroDocumento As System.Windows.Forms.Label
    Friend WithEvents lblGenero As System.Windows.Forms.Label
    Friend WithEvents lblEdad As System.Windows.Forms.Label
    Friend WithEvents lblAdm As System.Windows.Forms.Label
    Friend WithEvents lblAdmision As System.Windows.Forms.Label
    Friend WithEvents lblEnt As System.Windows.Forms.Label
    Friend WithEvents lblEntidad As System.Windows.Forms.Label
    Friend WithEvents pnlAlarmas As System.Windows.Forms.Panel
    Friend WithEvents btnCaida As System.Windows.Forms.Button
    Friend WithEvents btnQuirurgico As System.Windows.Forms.Button
    Friend WithEvents btnAlergico As System.Windows.Forms.Button
    Friend WithEvents btnMedica As System.Windows.Forms.Button
    Friend WithEvents btnPalitivo As System.Windows.Forms.Button
    Friend WithEvents lblReligion As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblFechaAdm As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblUbicacion As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblGrupoRH As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnLesionPiel As Button
    Friend WithEvents btnFuga As Button
    Friend WithEvents btnAnticuagulado As Button
    Friend WithEvents btnAlergico1 As Button
    Friend WithEvents lkHistorico As LinkLabel
    Friend WithEvents lkActDes As LinkLabel
    Friend WithEvents imBtnResistencia As Button
    Friend WithEvents imBtnContacto As Button
    Friend WithEvents imBtnNutricional As Button
    Friend WithEvents imBtnDeterioro As Button
    Friend WithEvents imBtnAerosol As Button
    Friend WithEvents imBtnProtector As Button
    Friend WithEvents imBtnVectores As Button
    Friend WithEvents imBtnGotas As Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlDatosPersonales = New System.Windows.Forms.Panel()
        Me.lblGrupoRH = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblUbicacion = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblFechaAdm = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblReligion = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.pnlAlarmas = New System.Windows.Forms.Panel()
        Me.lkHistorico = New System.Windows.Forms.LinkLabel()
        Me.lkActDes = New System.Windows.Forms.LinkLabel()
        Me.imBtnResistencia = New System.Windows.Forms.Button()
        Me.imBtnContacto = New System.Windows.Forms.Button()
        Me.imBtnNutricional = New System.Windows.Forms.Button()
        Me.imBtnDeterioro = New System.Windows.Forms.Button()
        Me.imBtnAerosol = New System.Windows.Forms.Button()
        Me.imBtnProtector = New System.Windows.Forms.Button()
        Me.imBtnVectores = New System.Windows.Forms.Button()
        Me.imBtnGotas = New System.Windows.Forms.Button()
        Me.btnAnticuagulado = New System.Windows.Forms.Button()
        Me.btnAlergico1 = New System.Windows.Forms.Button()
        Me.btnFuga = New System.Windows.Forms.Button()
        Me.btnLesionPiel = New System.Windows.Forms.Button()
        Me.btnPalitivo = New System.Windows.Forms.Button()
        Me.btnCaida = New System.Windows.Forms.Button()
        Me.btnQuirurgico = New System.Windows.Forms.Button()
        Me.btnAlergico = New System.Windows.Forms.Button()
        Me.btnMedica = New System.Windows.Forms.Button()
        Me.lblEnt = New System.Windows.Forms.Label()
        Me.lblEntidad = New System.Windows.Forms.Label()
        Me.lblAdmision = New System.Windows.Forms.Label()
        Me.lblAdm = New System.Windows.Forms.Label()
        Me.lblEdad = New System.Windows.Forms.Label()
        Me.lblGenero = New System.Windows.Forms.Label()
        Me.lblNumeroDocumento = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.lblTipoDocumento = New System.Windows.Forms.Label()
        Me.lblDpEdad = New System.Windows.Forms.Label()
        Me.lblDpGenero = New System.Windows.Forms.Label()
        Me.lblDpDocumento = New System.Windows.Forms.Label()
        Me.lblDpNombre = New System.Windows.Forms.Label()
        Me.lblDPTipoDoc = New System.Windows.Forms.Label()
        Me.pnlDatosPersonales.SuspendLayout()
        Me.pnlAlarmas.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlDatosPersonales
        '
        Me.pnlDatosPersonales.AutoSize = True
        Me.pnlDatosPersonales.BackColor = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.pnlDatosPersonales.Controls.Add(Me.lblGrupoRH)
        Me.pnlDatosPersonales.Controls.Add(Me.Label14)
        Me.pnlDatosPersonales.Controls.Add(Me.Label8)
        Me.pnlDatosPersonales.Controls.Add(Me.lblUbicacion)
        Me.pnlDatosPersonales.Controls.Add(Me.Label9)
        Me.pnlDatosPersonales.Controls.Add(Me.Label5)
        Me.pnlDatosPersonales.Controls.Add(Me.lblFechaAdm)
        Me.pnlDatosPersonales.Controls.Add(Me.Label13)
        Me.pnlDatosPersonales.Controls.Add(Me.Label12)
        Me.pnlDatosPersonales.Controls.Add(Me.lblReligion)
        Me.pnlDatosPersonales.Controls.Add(Me.Label11)
        Me.pnlDatosPersonales.Controls.Add(Me.pnlAlarmas)
        Me.pnlDatosPersonales.Controls.Add(Me.lblEnt)
        Me.pnlDatosPersonales.Controls.Add(Me.lblEntidad)
        Me.pnlDatosPersonales.Controls.Add(Me.lblAdmision)
        Me.pnlDatosPersonales.Controls.Add(Me.lblAdm)
        Me.pnlDatosPersonales.Controls.Add(Me.lblEdad)
        Me.pnlDatosPersonales.Controls.Add(Me.lblGenero)
        Me.pnlDatosPersonales.Controls.Add(Me.lblNumeroDocumento)
        Me.pnlDatosPersonales.Controls.Add(Me.lblNombre)
        Me.pnlDatosPersonales.Controls.Add(Me.lblTipoDocumento)
        Me.pnlDatosPersonales.Controls.Add(Me.lblDpEdad)
        Me.pnlDatosPersonales.Controls.Add(Me.lblDpGenero)
        Me.pnlDatosPersonales.Controls.Add(Me.lblDpDocumento)
        Me.pnlDatosPersonales.Controls.Add(Me.lblDpNombre)
        Me.pnlDatosPersonales.Controls.Add(Me.lblDPTipoDoc)
        Me.pnlDatosPersonales.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlDatosPersonales.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatosPersonales.Name = "pnlDatosPersonales"
        Me.pnlDatosPersonales.Size = New System.Drawing.Size(1100, 216)
        Me.pnlDatosPersonales.TabIndex = 0
        '
        'lblGrupoRH
        '
        Me.lblGrupoRH.BackColor = System.Drawing.Color.Transparent
        Me.lblGrupoRH.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrupoRH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblGrupoRH.Location = New System.Drawing.Point(980, 56)
        Me.lblGrupoRH.Name = "lblGrupoRH"
        Me.lblGrupoRH.Size = New System.Drawing.Size(73, 16)
        Me.lblGrupoRH.TabIndex = 49
        Me.lblGrupoRH.Text = "GrupoRH"
        Me.lblGrupoRH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label14.Location = New System.Drawing.Point(816, 55)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(124, 16)
        Me.Label14.TabIndex = 48
        Me.Label14.Text = "G.Sanguineo/RH"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Gainsboro
        Me.Label8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(3, 146)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(1094, 17)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "Identificadores de Riesgo"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblUbicacion
        '
        Me.lblUbicacion.BackColor = System.Drawing.Color.Transparent
        Me.lblUbicacion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUbicacion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblUbicacion.Location = New System.Drawing.Point(585, 126)
        Me.lblUbicacion.Name = "lblUbicacion"
        Me.lblUbicacion.Size = New System.Drawing.Size(491, 16)
        Me.lblUbicacion.TabIndex = 46
        Me.lblUbicacion.Text = "Ubicación"
        Me.lblUbicacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(352, 126)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(133, 16)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "Ubicación"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(352, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(258, 16)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Fecha y hora de Admisión"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFechaAdm
        '
        Me.lblFechaAdm.BackColor = System.Drawing.Color.Transparent
        Me.lblFechaAdm.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaAdm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblFechaAdm.Location = New System.Drawing.Point(645, 102)
        Me.lblFechaAdm.Name = "lblFechaAdm"
        Me.lblFechaAdm.Size = New System.Drawing.Size(233, 16)
        Me.lblFechaAdm.TabIndex = 43
        Me.lblFechaAdm.Text = "Fecha Admisión"
        Me.lblFechaAdm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.Gainsboro
        Me.Label13.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(3, 81)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(1094, 16)
        Me.Label13.TabIndex = 42
        Me.Label13.Text = "Datos Administrativos"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.Gainsboro
        Me.Label12.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(3, 5)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(1094, 16)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "Datos Personales"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblReligion
        '
        Me.lblReligion.BackColor = System.Drawing.Color.Transparent
        Me.lblReligion.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblReligion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblReligion.Location = New System.Drawing.Point(646, 56)
        Me.lblReligion.Name = "lblReligion"
        Me.lblReligion.Size = New System.Drawing.Size(141, 16)
        Me.lblReligion.TabIndex = 40
        Me.lblReligion.Text = "Religion"
        Me.lblReligion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(544, 55)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 16)
        Me.Label11.TabIndex = 39
        Me.Label11.Text = "Religión"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlAlarmas
        '
        Me.pnlAlarmas.Controls.Add(Me.lkHistorico)
        Me.pnlAlarmas.Controls.Add(Me.lkActDes)
        Me.pnlAlarmas.Controls.Add(Me.imBtnResistencia)
        Me.pnlAlarmas.Controls.Add(Me.imBtnContacto)
        Me.pnlAlarmas.Controls.Add(Me.imBtnNutricional)
        Me.pnlAlarmas.Controls.Add(Me.imBtnDeterioro)
        Me.pnlAlarmas.Controls.Add(Me.imBtnAerosol)
        Me.pnlAlarmas.Controls.Add(Me.imBtnProtector)
        Me.pnlAlarmas.Controls.Add(Me.imBtnVectores)
        Me.pnlAlarmas.Controls.Add(Me.imBtnGotas)
        Me.pnlAlarmas.Controls.Add(Me.btnAnticuagulado)
        Me.pnlAlarmas.Controls.Add(Me.btnAlergico1)
        Me.pnlAlarmas.Controls.Add(Me.btnFuga)
        Me.pnlAlarmas.Controls.Add(Me.btnLesionPiel)
        Me.pnlAlarmas.Controls.Add(Me.btnPalitivo)
        Me.pnlAlarmas.Controls.Add(Me.btnCaida)
        Me.pnlAlarmas.Controls.Add(Me.btnQuirurgico)
        Me.pnlAlarmas.Controls.Add(Me.btnAlergico)
        Me.pnlAlarmas.Controls.Add(Me.btnMedica)
        Me.pnlAlarmas.Location = New System.Drawing.Point(17, 167)
        Me.pnlAlarmas.Name = "pnlAlarmas"
        Me.pnlAlarmas.Size = New System.Drawing.Size(1080, 46)
        Me.pnlAlarmas.TabIndex = 37
        '
        'lkHistorico
        '
        Me.lkHistorico.AutoSize = True
        Me.lkHistorico.LinkColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lkHistorico.Location = New System.Drawing.Point(988, 30)
        Me.lkHistorico.Name = "lkHistorico"
        Me.lkHistorico.Size = New System.Drawing.Size(88, 13)
        Me.lkHistorico.TabIndex = 56
        Me.lkHistorico.TabStop = True
        Me.lkHistorico.Text = "Ver Historial"
        '
        'lkActDes
        '
        Me.lkActDes.AutoSize = True
        Me.lkActDes.LinkColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lkActDes.Location = New System.Drawing.Point(839, 30)
        Me.lkActDes.Name = "lkActDes"
        Me.lkActDes.Size = New System.Drawing.Size(132, 13)
        Me.lkActDes.TabIndex = 55
        Me.lkActDes.TabStop = True
        Me.lkActDes.Text = "Activar/Desactivar"
        '
        'imBtnResistencia
        '
        Me.imBtnResistencia.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.imBtnResistencia.BackColor = System.Drawing.Color.Transparent
        Me.imBtnResistencia.Image = Global.HistoriaClinica.My.Resources.Resources.FRresitenciaMicrobiana
        Me.imBtnResistencia.Location = New System.Drawing.Point(568, 3)
        Me.imBtnResistencia.Name = "imBtnResistencia"
        Me.imBtnResistencia.Size = New System.Drawing.Size(41, 42)
        Me.imBtnResistencia.TabIndex = 54
        Me.imBtnResistencia.UseVisualStyleBackColor = False
        Me.imBtnResistencia.Visible = False
        '
        'imBtnContacto
        '
        Me.imBtnContacto.BackColor = System.Drawing.Color.Transparent
        Me.imBtnContacto.Image = Global.HistoriaClinica.My.Resources.Resources.FR2contacto
        Me.imBtnContacto.Location = New System.Drawing.Point(380, 3)
        Me.imBtnContacto.Name = "imBtnContacto"
        Me.imBtnContacto.Size = New System.Drawing.Size(41, 42)
        Me.imBtnContacto.TabIndex = 53
        Me.imBtnContacto.UseVisualStyleBackColor = False
        Me.imBtnContacto.Visible = False
        '
        'imBtnNutricional
        '
        Me.imBtnNutricional.BackColor = System.Drawing.Color.Transparent
        Me.imBtnNutricional.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.imBtnNutricional.Image = Global.HistoriaClinica.My.Resources.Resources.FRriesgoNutricional
        Me.imBtnNutricional.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.imBtnNutricional.Location = New System.Drawing.Point(615, 3)
        Me.imBtnNutricional.Name = "imBtnNutricional"
        Me.imBtnNutricional.Size = New System.Drawing.Size(41, 42)
        Me.imBtnNutricional.TabIndex = 51
        Me.imBtnNutricional.UseVisualStyleBackColor = False
        Me.imBtnNutricional.Visible = False
        '
        'imBtnDeterioro
        '
        Me.imBtnDeterioro.Image = Global.HistoriaClinica.My.Resources.Resources.FRriesgoBajo
        Me.imBtnDeterioro.Location = New System.Drawing.Point(662, 3)
        Me.imBtnDeterioro.Name = "imBtnDeterioro"
        Me.imBtnDeterioro.Size = New System.Drawing.Size(41, 42)
        Me.imBtnDeterioro.TabIndex = 52
        Me.imBtnDeterioro.Visible = False
        '
        'imBtnAerosol
        '
        Me.imBtnAerosol.BackColor = System.Drawing.Color.Transparent
        Me.imBtnAerosol.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.imBtnAerosol.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.imBtnAerosol.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.imBtnAerosol.Image = Global.HistoriaClinica.My.Resources.Resources.FR2aerosol
        Me.imBtnAerosol.Location = New System.Drawing.Point(333, 3)
        Me.imBtnAerosol.Name = "imBtnAerosol"
        Me.imBtnAerosol.Size = New System.Drawing.Size(41, 42)
        Me.imBtnAerosol.TabIndex = 47
        Me.imBtnAerosol.UseVisualStyleBackColor = False
        Me.imBtnAerosol.Visible = False
        '
        'imBtnProtector
        '
        Me.imBtnProtector.BackColor = System.Drawing.Color.Transparent
        Me.imBtnProtector.Image = Global.HistoriaClinica.My.Resources.Resources.FR2protector
        Me.imBtnProtector.Location = New System.Drawing.Point(474, 3)
        Me.imBtnProtector.Name = "imBtnProtector"
        Me.imBtnProtector.Size = New System.Drawing.Size(41, 42)
        Me.imBtnProtector.TabIndex = 48
        Me.imBtnProtector.UseVisualStyleBackColor = False
        Me.imBtnProtector.Visible = False
        '
        'imBtnVectores
        '
        Me.imBtnVectores.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.imBtnVectores.BackColor = System.Drawing.Color.Transparent
        Me.imBtnVectores.Image = Global.HistoriaClinica.My.Resources.Resources.FR2vector
        Me.imBtnVectores.Location = New System.Drawing.Point(521, 3)
        Me.imBtnVectores.Name = "imBtnVectores"
        Me.imBtnVectores.Size = New System.Drawing.Size(41, 42)
        Me.imBtnVectores.TabIndex = 50
        Me.imBtnVectores.UseVisualStyleBackColor = False
        Me.imBtnVectores.Visible = False
        '
        'imBtnGotas
        '
        Me.imBtnGotas.BackColor = System.Drawing.Color.Transparent
        Me.imBtnGotas.Image = Global.HistoriaClinica.My.Resources.Resources.FR2gotas
        Me.imBtnGotas.Location = New System.Drawing.Point(427, 3)
        Me.imBtnGotas.Name = "imBtnGotas"
        Me.imBtnGotas.Size = New System.Drawing.Size(41, 42)
        Me.imBtnGotas.TabIndex = 49
        Me.imBtnGotas.UseVisualStyleBackColor = False
        '
        'btnAnticuagulado
        '
        Me.btnAnticuagulado.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.btnAnticuagulado.BackColor = System.Drawing.Color.Transparent
        Me.btnAnticuagulado.Image = Global.HistoriaClinica.My.Resources.Resources.anticoagulado
        Me.btnAnticuagulado.Location = New System.Drawing.Point(191, 3)
        Me.btnAnticuagulado.Name = "btnAnticuagulado"
        Me.btnAnticuagulado.Size = New System.Drawing.Size(41, 42)
        Me.btnAnticuagulado.TabIndex = 40
        Me.btnAnticuagulado.UseVisualStyleBackColor = False
        Me.btnAnticuagulado.Visible = False
        '
        'btnAlergico1
        '
        Me.btnAlergico1.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.btnAlergico1.BackColor = System.Drawing.Color.Transparent
        Me.btnAlergico1.Image = Global.HistoriaClinica.My.Resources.Resources.alergias
        Me.btnAlergico1.Location = New System.Drawing.Point(144, 3)
        Me.btnAlergico1.Name = "btnAlergico1"
        Me.btnAlergico1.Size = New System.Drawing.Size(41, 42)
        Me.btnAlergico1.TabIndex = 39
        Me.btnAlergico1.UseVisualStyleBackColor = False
        Me.btnAlergico1.Visible = False
        '
        'btnFuga
        '
        Me.btnFuga.BackColor = System.Drawing.Color.Transparent
        Me.btnFuga.Image = Global.HistoriaClinica.My.Resources.Resources.riesgoFuga
        Me.btnFuga.Location = New System.Drawing.Point(50, 3)
        Me.btnFuga.Name = "btnFuga"
        Me.btnFuga.Size = New System.Drawing.Size(41, 42)
        Me.btnFuga.TabIndex = 38
        Me.btnFuga.UseVisualStyleBackColor = False
        Me.btnFuga.Visible = False
        '
        'btnLesionPiel
        '
        Me.btnLesionPiel.BackColor = System.Drawing.Color.Transparent
        Me.btnLesionPiel.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnLesionPiel.Image = Global.HistoriaClinica.My.Resources.Resources.lesionPiel
        Me.btnLesionPiel.Location = New System.Drawing.Point(238, 3)
        Me.btnLesionPiel.Name = "btnLesionPiel"
        Me.btnLesionPiel.Size = New System.Drawing.Size(41, 42)
        Me.btnLesionPiel.TabIndex = 35
        Me.btnLesionPiel.UseVisualStyleBackColor = False
        Me.btnLesionPiel.Visible = False
        '
        'btnPalitivo
        '
        Me.btnPalitivo.BackColor = System.Drawing.Color.Transparent
        Me.btnPalitivo.ForeColor = System.Drawing.SystemColors.ButtonHighlight
        Me.btnPalitivo.Image = Global.HistoriaClinica.My.Resources.Resources.FR2paliativos
        Me.btnPalitivo.Location = New System.Drawing.Point(286, 3)
        Me.btnPalitivo.Name = "btnPalitivo"
        Me.btnPalitivo.Size = New System.Drawing.Size(41, 42)
        Me.btnPalitivo.TabIndex = 34
        Me.btnPalitivo.UseVisualStyleBackColor = False
        Me.btnPalitivo.Visible = False
        '
        'btnCaida
        '
        Me.btnCaida.BackColor = System.Drawing.Color.Transparent
        Me.btnCaida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnCaida.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.btnCaida.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.btnCaida.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.btnCaida.Image = Global.HistoriaClinica.My.Resources.Resources.riesgoCaida
        Me.btnCaida.Location = New System.Drawing.Point(3, 3)
        Me.btnCaida.Name = "btnCaida"
        Me.btnCaida.Size = New System.Drawing.Size(41, 42)
        Me.btnCaida.TabIndex = 30
        Me.btnCaida.UseVisualStyleBackColor = False
        Me.btnCaida.Visible = False
        '
        'btnQuirurgico
        '
        Me.btnQuirurgico.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnQuirurgico.Location = New System.Drawing.Point(709, 3)
        Me.btnQuirurgico.Name = "btnQuirurgico"
        Me.btnQuirurgico.Size = New System.Drawing.Size(41, 42)
        Me.btnQuirurgico.TabIndex = 31
        Me.btnQuirurgico.UseVisualStyleBackColor = False
        Me.btnQuirurgico.Visible = False
        '
        'btnAlergico
        '
        Me.btnAlergico.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.btnAlergico.BackColor = System.Drawing.Color.Red
        Me.btnAlergico.Location = New System.Drawing.Point(28, 3)
        Me.btnAlergico.Name = "btnAlergico"
        Me.btnAlergico.Size = New System.Drawing.Size(16, 16)
        Me.btnAlergico.TabIndex = 33
        Me.btnAlergico.UseVisualStyleBackColor = False
        Me.btnAlergico.Visible = False
        '
        'btnMedica
        '
        Me.btnMedica.BackColor = System.Drawing.Color.Yellow
        Me.btnMedica.Image = Global.HistoriaClinica.My.Resources.Resources.alertaMedica
        Me.btnMedica.Location = New System.Drawing.Point(97, 3)
        Me.btnMedica.Name = "btnMedica"
        Me.btnMedica.Size = New System.Drawing.Size(41, 42)
        Me.btnMedica.TabIndex = 32
        Me.btnMedica.UseVisualStyleBackColor = False
        Me.btnMedica.Visible = False
        '
        'lblEnt
        '
        Me.lblEnt.BackColor = System.Drawing.Color.Transparent
        Me.lblEnt.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEnt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblEnt.Location = New System.Drawing.Point(136, 126)
        Me.lblEnt.Name = "lblEnt"
        Me.lblEnt.Size = New System.Drawing.Size(105, 16)
        Me.lblEnt.TabIndex = 26
        Me.lblEnt.Text = "Entidad"
        Me.lblEnt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEntidad
        '
        Me.lblEntidad.BackColor = System.Drawing.Color.Transparent
        Me.lblEntidad.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEntidad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblEntidad.Location = New System.Drawing.Point(3, 126)
        Me.lblEntidad.Name = "lblEntidad"
        Me.lblEntidad.Size = New System.Drawing.Size(73, 16)
        Me.lblEntidad.TabIndex = 25
        Me.lblEntidad.Text = "Entidad"
        Me.lblEntidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAdmision
        '
        Me.lblAdmision.BackColor = System.Drawing.Color.Transparent
        Me.lblAdmision.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdmision.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblAdmision.Location = New System.Drawing.Point(2, 102)
        Me.lblAdmision.Name = "lblAdmision"
        Me.lblAdmision.Size = New System.Drawing.Size(113, 16)
        Me.lblAdmision.TabIndex = 24
        Me.lblAdmision.Text = "Admisión"
        Me.lblAdmision.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAdm
        '
        Me.lblAdm.BackColor = System.Drawing.Color.Transparent
        Me.lblAdm.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdm.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblAdm.Location = New System.Drawing.Point(135, 102)
        Me.lblAdm.Name = "lblAdm"
        Me.lblAdm.Size = New System.Drawing.Size(105, 16)
        Me.lblAdm.TabIndex = 23
        Me.lblAdm.Text = "Admisión"
        Me.lblAdm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEdad
        '
        Me.lblEdad.BackColor = System.Drawing.Color.Transparent
        Me.lblEdad.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEdad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblEdad.Location = New System.Drawing.Point(75, 55)
        Me.lblEdad.Name = "lblEdad"
        Me.lblEdad.Size = New System.Drawing.Size(176, 16)
        Me.lblEdad.TabIndex = 19
        Me.lblEdad.Text = "Edad Años Meses Días"
        Me.lblEdad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblGenero
        '
        Me.lblGenero.BackColor = System.Drawing.Color.Transparent
        Me.lblGenero.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGenero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblGenero.Location = New System.Drawing.Point(356, 56)
        Me.lblGenero.Name = "lblGenero"
        Me.lblGenero.Size = New System.Drawing.Size(143, 16)
        Me.lblGenero.TabIndex = 18
        Me.lblGenero.Text = "Género"
        Me.lblGenero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNumeroDocumento
        '
        Me.lblNumeroDocumento.BackColor = System.Drawing.Color.Transparent
        Me.lblNumeroDocumento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroDocumento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblNumeroDocumento.Location = New System.Drawing.Point(956, 29)
        Me.lblNumeroDocumento.Name = "lblNumeroDocumento"
        Me.lblNumeroDocumento.Size = New System.Drawing.Size(120, 18)
        Me.lblNumeroDocumento.TabIndex = 17
        Me.lblNumeroDocumento.Text = "No. Documento"
        Me.lblNumeroDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNombre
        '
        Me.lblNombre.BackColor = System.Drawing.Color.Transparent
        Me.lblNombre.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblNombre.Location = New System.Drawing.Point(172, 27)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(278, 16)
        Me.lblNombre.TabIndex = 15
        Me.lblNombre.Text = "Nombre Paciente"
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTipoDocumento
        '
        Me.lblTipoDocumento.BackColor = System.Drawing.Color.Transparent
        Me.lblTipoDocumento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoDocumento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblTipoDocumento.Location = New System.Drawing.Point(646, 27)
        Me.lblTipoDocumento.Name = "lblTipoDocumento"
        Me.lblTipoDocumento.Size = New System.Drawing.Size(159, 18)
        Me.lblTipoDocumento.TabIndex = 14
        Me.lblTipoDocumento.Text = "TipoDocumento"
        Me.lblTipoDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDpEdad
        '
        Me.lblDpEdad.BackColor = System.Drawing.Color.Transparent
        Me.lblDpEdad.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDpEdad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblDpEdad.Location = New System.Drawing.Point(5, 54)
        Me.lblDpEdad.Name = "lblDpEdad"
        Me.lblDpEdad.Size = New System.Drawing.Size(61, 17)
        Me.lblDpEdad.TabIndex = 9
        Me.lblDpEdad.Text = "Edad"
        Me.lblDpEdad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDpGenero
        '
        Me.lblDpGenero.BackColor = System.Drawing.Color.Transparent
        Me.lblDpGenero.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDpGenero.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblDpGenero.Location = New System.Drawing.Point(283, 55)
        Me.lblDpGenero.Name = "lblDpGenero"
        Me.lblDpGenero.Size = New System.Drawing.Size(61, 16)
        Me.lblDpGenero.TabIndex = 7
        Me.lblDpGenero.Text = "Género"
        Me.lblDpGenero.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDpDocumento
        '
        Me.lblDpDocumento.AutoSize = True
        Me.lblDpDocumento.BackColor = System.Drawing.Color.Transparent
        Me.lblDpDocumento.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDpDocumento.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblDpDocumento.Location = New System.Drawing.Point(816, 29)
        Me.lblDpDocumento.Name = "lblDpDocumento"
        Me.lblDpDocumento.Size = New System.Drawing.Size(127, 14)
        Me.lblDpDocumento.TabIndex = 6
        Me.lblDpDocumento.Text = "No. de Documento"
        Me.lblDpDocumento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDpNombre
        '
        Me.lblDpNombre.BackColor = System.Drawing.Color.Transparent
        Me.lblDpNombre.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDpNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblDpNombre.Location = New System.Drawing.Point(3, 27)
        Me.lblDpNombre.Name = "lblDpNombre"
        Me.lblDpNombre.Size = New System.Drawing.Size(153, 16)
        Me.lblDpNombre.TabIndex = 4
        Me.lblDpNombre.Text = "Nombres y Apellidos"
        Me.lblDpNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDPTipoDoc
        '
        Me.lblDPTipoDoc.BackColor = System.Drawing.Color.Transparent
        Me.lblDPTipoDoc.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDPTipoDoc.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
        Me.lblDPTipoDoc.Location = New System.Drawing.Point(474, 25)
        Me.lblDPTipoDoc.Name = "lblDPTipoDoc"
        Me.lblDPTipoDoc.Size = New System.Drawing.Size(153, 18)
        Me.lblDPTipoDoc.TabIndex = 3
        Me.lblDPTipoDoc.Text = "Tipo de Documento"
        Me.lblDPTipoDoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ctlDatosPaciente
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.pnlDatosPersonales)
        Me.Name = "ctlDatosPaciente"
        Me.Size = New System.Drawing.Size(1100, 216)
        Me.pnlDatosPersonales.ResumeLayout(False)
        Me.pnlDatosPersonales.PerformLayout()
        Me.pnlAlarmas.ResumeLayout(False)
        Me.pnlAlarmas.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private objDatosPaciente As Paciente
    Private objDatosGenerales As Generales
    Private objConexion As Conexion
    Private dtfarmaco As DataTable

#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As ctlDatosPaciente
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlDatosPaciente
            End If
            Return _Instancia
        End Get
    End Property
#End Region

    Private Sub ctlDatosPaciente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        frmHistoriaPrincipal.blnFirstDatosPaciente = False
        objDatosPaciente = Paciente.Instancia
        objDatosGenerales = Generales.Instancia
        objConexion = Conexion.Instancia
        IniciarDatosPaciente()

        If objDatosGenerales.Pais = "482" Then
            Me.lblEnt.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End If

        Dim toolTip1 As New ToolTip()
        toolTip1.SetToolTip(Me.btnPalitivo, "Cuidados Paliativos")


    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks>
    ''' 2017-06-14 cariasm se incluyen nuevos campos de la admisión
    ''' </remarks>
    Private Sub IniciarDatosPaciente()
        lblTipoDocumento.Text = objDatosPaciente.DescripcionTipoDocumento.ToString
        Me.lblNumeroDocumento.Text = objDatosPaciente.NumeroDocumento.ToString
        '2017-06-14 cariasm
        Me.lblNombre.Text = objDatosPaciente.NombreCompleto
        lblGenero.Text = objDatosPaciente.DescripcionGenero
        lblEdad.Text = objDatosPaciente.EdadAMD
        lblReligion.Text = objDatosPaciente.Religion
        lblGrupoRH.Text = objDatosPaciente.GrupoRH
        lblAdm.Text = objDatosPaciente.Admision
        lblFechaAdm.Text = objDatosPaciente.FechaHoraAdmision
        lblUbicacion.Text = objDatosPaciente.Ubicacion
        'jlalfonso-2008-12-20.  agregregar entidad y admision paciente 
        lblEnt.Text = objDatosPaciente.DescripcionEntidad.ToString

        '2017-06-14 cariasm
        'If objDatosPaciente.GrupoSanguineo.Trim.Length > 0 Then
        '    Me.lblGrupoSanguineo.Text = objDatosPaciente.GrupoSanguineo.ToString
        '    Me.lblGrupoSanguineo.Visible = True
        '    Me.cboGrupoSanguineo.Visible = False
        '    'Me.cmdGrabarInfoPaciente.Visible = False
        'Else
        '    Me.lblGrupoSanguineo.Visible = False
        '    Me.cboGrupoSanguineo.Visible = True
        '    Me.cboGrupoSanguineo.SelectedIndex = -1
        '    Me.cmdGrabarInfoPaciente.Visible = True
        'End If
        'If objDatosPaciente.RH.Trim.Length > 0 Then
        '    Me.lblFactorRH.Text = objDatosPaciente.RH.ToString
        '    Me.lblFactorRH.Visible = True
        '    Me.cboFactorRH.Visible = False
        '    'Me.cmdGrabarInfoPaciente.Visible = False
        'Else
        '    Me.lblFactorRH.Visible = False
        '    Me.cboFactorRH.Visible = True
        '    Me.cboFactorRH.SelectedIndex = -1
        '    Me.cmdGrabarInfoPaciente.Visible = True
        'End If
        ' ''Ingresado por Claudia Garay 2009-12-22
        'If objDatosPaciente.Cronico.ToString = "SI" Then
        '    rbSiCronico.Checked = True
        'Else
        '    rbnoCronico.Checked = True
        '    cmdGrabarInfoPaciente.Visible = True
        'End If
        'Me.picFotoPaciente.Image = objDatosPaciente.FotoPaciente

        ''Consultar las alarmas  Claudia Garay Sept 28 de 2010
        PrenderAlarmasPac()
        'Consultar si el paciente esta ingresado si existe prende alarma
        AlarmaPaliativo()
        ''Consultar las recomendaciones de farmacovigilancia 13 de enero 2014
        ''ConsultarRecomendacionesFarmaco()

    End Sub

    'Private Sub cboGrupoSanguineo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    cboFactorRH.Focus()
    'End Sub

    'Private Sub cboFactorRH_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    --cmdGrabarInfoPaciente.Focus()
    'End Sub


    'Private Sub cmdGrabarInfoPaciente_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim objActualizarAP As New BLHistoriaBasica
    '    Dim Datos() As Object
    '    Dim lError As Long
    '    Dim StrgrupoSanguineo As String
    '    Dim StrFactorRh As String

    '    ''Ingresado por Claudia Garay 2009-12-28

    '    'If cboGrupoSanguineo.Text = "" Then
    '    '    StrgrupoSanguineo = lblGrupoSanguineo.Text
    '    'Else
    '    '    StrgrupoSanguineo = cboGrupoSanguineo.Text
    '    'End If

    '    'If cboFactorRH.Text = "" Then
    '    '    StrFactorRh = lblFactorRH.Text
    '    'Else
    '    '    StrFactorRh = cboFactorRH.Text
    '    'End If


    '    ReDim Datos(6)
    '    Datos(0) = objDatosPaciente.TipoDocumento
    '    Datos(1) = objDatosPaciente.NumeroDocumento
    '    Datos(2) = StrgrupoSanguineo
    '    Datos(3) = StrFactorRh
    '    Datos(4) = objDatosGenerales.Login
    '    ''Agregado por Claudia Garay
    '    ''2009-12-22
    '    'If rbSiCronico.Checked = True Then
    '    '    Datos(5) = "SI"
    '    'Else
    '    '    Datos(5) = "NO"
    '    'End If
    '    Datos(6) = lError

    '    'If cboGrupoSanguineo.Text = "" And lblGrupoSanguineo.Text = "" Then
    '    '    MsgBox("Por favor seleccione el grupo sanguíneo", MsgBoxStyle.Exclamation)
    '    '    Exit Sub
    '    'End If

    '    'If cboFactorRH.Text = "" And lblFactorRH.Text = "" Then
    '    '    MsgBox("Por favor seleccione el factor RH", MsgBoxStyle.Exclamation)
    '    '    Exit Sub
    '    'End If
    '    'If cboFactorRH.Text <> "" And cboGrupoSanguineo.Text <> "" Then
    '    Try
    '        lError = objActualizarAP.ActualizarDatosPaciente(objConexion, lError, Datos)
    '        If lError <> 0 Then
    '            MessageBox.Show("Error al Grabar Datos Paciente")
    '        Else
    '            objDatosGenerales.HistoriaClinicaTieneModificaciones = True
    '            'lblGrupoSanguineo.Text = StrgrupoSanguineo
    '            'objDatosPaciente.GrupoSanguineo = lblGrupoSanguineo.Text
    '            'lblFactorRH.Text = StrFactorRh
    '            'objDatosPaciente.RH = lblFactorRH.Text
    '            'cboGrupoSanguineo.Visible = False
    '            'cboFactorRH.Visible = False
    '            'lblGrupoSanguineo.Visible = True
    '            'lblFactorRH.Visible = True
    '            'cmdGrabarInfoPaciente.Visible = False
    '        End If
    '    Catch ex As Exception
    '        MessageBox.Show("Error al Grabar Datos Paciente")
    '    End Try
    '    ' Else

    '    'End If
    'End Sub

    Public Sub ctlDatosPaciente_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If sender.Visible = True Then
            If frmHistoriaPrincipal.blnFirstDatosPaciente = True Then
                LimpiarDatos()
                IniciarDatosPaciente()
                frmHistoriaPrincipal.blnFirstDatosPaciente = False
                AlarmaPaliativo()
            End If
        End If
    End Sub

    Private Sub LimpiarDatos()
        lblNumeroDocumento.ResetText()
        lblNombre.ResetText()
        'lblApellidos.ResetText()
        lblGenero.ResetText()
        lblEdad.ResetText()
        'lblGrupoSanguineo.ResetText()
        'lblFactorRH.ResetText()
        'cboGrupoSanguineo.ResetText()
        'cboFactorRH.ResetText()
        'Me.picFotoPaciente.Image = Nothing
    End Sub
    ''Claudia Garay Enfermeria
    Public Sub PrenderAlarmasPac()
        Dim dsAlarmasXPac As DataSet
        Dim descr As String

        Dim toolTip1 As ToolTip = New ToolTip()
        toolTip1.IsBalloon = True
        toolTip1.ShowAlways = True

        toolTip1.SetToolTip(btnCaida, "Riesgo de Caida")
        toolTip1.SetToolTip(btnAlergico1, "Alérgico")
        toolTip1.SetToolTip(btnMedica, "Alerta Médica")
        toolTip1.SetToolTip(btnQuirurgico, "Alerta Quirúrgica")
        toolTip1.SetToolTip(btnLesionPiel, "Riesgo Lesión de Piel")

        toolTip1.SetToolTip(btnAnticuagulado, "Anticoagulado")
        toolTip1.SetToolTip(btnFuga, "Riesgo de fuga")

        toolTip1.SetToolTip(imBtnAerosol, "Aislamiento Aerosol")
        toolTip1.SetToolTip(imBtnContacto, "Aislamiento Contacto")
        toolTip1.SetToolTip(imBtnGotas, "Aislamiento Gotas")
        toolTip1.SetToolTip(imBtnProtector, "Aislamiento Protector")
        toolTip1.SetToolTip(imBtnVectores, "Aislamiento Vectores")
        toolTip1.SetToolTip(imBtnResistencia, "Resistencia Antimicrobiana")
        toolTip1.SetToolTip(imBtnNutricional, "Nutricional")
        toolTip1.SetToolTip(btnPalitivo, "Cuidados Paliativos")
        toolTip1.SetToolTip(imBtnDeterioro, "Deterioro Clínico")

        dsAlarmasXPac = ConsultarAlamasPac()


        btnCaida.Visible = False
        btnFuga.Visible = False
        btnMedica.Visible = False
        btnQuirurgico.Visible = False
        btnAlergico1.Visible = False
        btnAnticuagulado.Visible = False
        btnLesionPiel.Visible = False
        btnPalitivo.Visible = False

        If dsAlarmasXPac.Tables(1).Rows.Count > 0 Then
            btnCaida.Visible = True
        End If
        'If dsAlarmasXPac.Tables(2).Rows.Count > 0 Then
        '    If dsAlarmasXPac.Tables(2).Rows.Count = 1 Then
        '        If dsAlarmasXPac.Tables(2).Rows(0).Item("descripcion").ToString = "NIEGA ALÉRGIA MÉDICA" Then
        '            btnAlergico1.Visible = False
        '        Else
        '            btnAlergico1.Visible = True
        '        End If
        '    Else
        '        btnAlergico1.Visible = True
        '    End If
        'End If

        'Se inactiva esta funcionalidad de acuerdo a solicitud del 
        'req 634 3.7.1.       DESCRIPCIÓN DE LA FUNCIONALIDAD: Quitar la opción y el Icono de identificación (cuadro verde)  que actualmente identifica el Riesgo Quirúrgico.
        'Raul Cruz 20190208
        'For i As Integer = 0 To dsAlarmasXPac.Tables(0).Rows.Count - 1
        '    If dsAlarmasXPac.Tables(0).Rows(i).Item("cod_riesgo") = 6 And dsAlarmasXPac.Tables(0).Rows(i).Item("estado") = "S" Then
        '        btnQuirurgico.Visible = True
        '    End If
        'Next

        '20180712 raucruz Lesión de piel ER_OSI_615 Escala Riesgo Lesión de Piel 
        btnLesionPiel.Visible = False


        If dsAlarmasXPac.Tables(4).Rows.Count > 0 Then
            btnLesionPiel.Visible = True
            If dsAlarmasXPac.Tables(4).Rows(0).Item("Valor") > 18 Then
                btnLesionPiel.Visible = False
            End If
        End If


        '20180918 ER OSI 634 Gestión de Identificadores de Riesgo
        Me.btnAnticuagulado.Visible = False
        Me.btnFuga.Visible = False
        Me.btnMedica.Visible = False
        Me.imBtnResistencia.Visible = False
        Me.imBtnNutricional.Visible = False

        For i As Integer = 0 To dsAlarmasXPac.Tables(5).Rows.Count - 1
            If dsAlarmasXPac.Tables(5).Rows(i).Item("ID") = 2 Then
                btnAnticuagulado.Visible = True
            ElseIf dsAlarmasXPac.Tables(5).Rows(i).Item("ID") = 1 Then
                btnAlergico1.Visible = True
            ElseIf dsAlarmasXPac.Tables(5).Rows(i).Item("ID") = 5 Then
                btnFuga.Visible = True
            ElseIf dsAlarmasXPac.Tables(5).Rows(i).Item("ID") = 4 Then
                Me.btnMedica.Visible = True
            ElseIf dsAlarmasXPac.Tables(5).Rows(i).Item("ID") = 3 Then
                Me.imBtnResistencia.Visible = True
            ElseIf dsAlarmasXPac.Tables(5).Rows(i).Item("ID") = 6 Then
                Me.imBtnNutricional.Visible = True
            End If

        Next

        imBtnAerosol.Visible = False
        imBtnContacto.Visible = False
        imBtnGotas.Visible = False
        imBtnProtector.Visible = False
        imBtnVectores.Visible = False

        For i As Integer = 0 To dsAlarmasXPac.Tables(6).Rows.Count - 1
            If dsAlarmasXPac.Tables(6).Rows(i).Item("ID") = 8 Then
                imBtnAerosol.Visible = True
            ElseIf dsAlarmasXPac.Tables(6).Rows(i).Item("ID") = 9 Then
                imBtnContacto.Visible = True
            ElseIf dsAlarmasXPac.Tables(6).Rows(i).Item("ID") = 10 Then
                imBtnGotas.Visible = True
            ElseIf dsAlarmasXPac.Tables(6).Rows(i).Item("ID") = 218 Then
                imBtnProtector.Visible = True
            ElseIf dsAlarmasXPac.Tables(6).Rows(i).Item("ID") = 219 Then
                imBtnVectores.Visible = True
            End If
        Next

        btnPalitivo.Visible = False
        If dsAlarmasXPac.Tables(7).Rows.Count Then
            If dsAlarmasXPac.Tables(7).Rows(0).Item("ID") = 1 Then
                btnPalitivo.Visible = True
            End If
        End If

        'ER OSI 649 Gestión de Riesgo Deterioro Clínico raulcruz
        imBtnDeterioro.Visible = False

        If objDatosPaciente.CodigoUnidadMedidaEdad = "A" And objDatosPaciente.Edad >= 16 Then

            If dsAlarmasXPac.Tables(8).Rows.Count Then
                If dsAlarmasXPac.Tables(8).Rows(0).Item("Calificacion") = "RIESGO BAJO NEWS" Then
                    imBtnDeterioro.Visible = True
                    imBtnDeterioro.Image = HistoriaClinica.My.Resources.Resources.FRriesgoBajo
                End If
                If dsAlarmasXPac.Tables(8).Rows(0).Item("Calificacion") = "RIESGO MEDIO NEWS" Then
                    imBtnDeterioro.Visible = True
                    imBtnDeterioro.Image = HistoriaClinica.My.Resources.Resources.FRriesgoMedio
                End If
                If dsAlarmasXPac.Tables(8).Rows(0).Item("Calificacion") = "RIESGO ALTO NEWS" Then
                    imBtnDeterioro.Visible = True
                    imBtnDeterioro.Image = HistoriaClinica.My.Resources.Resources.FRriesgoAlto
                End If

                If dsAlarmasXPac.Tables(8).Rows(0).Item("Calificacion") = "SIN RIESGO NEWS" Then
                    Exit Sub
                End If

            End If
        End If

    End Sub
    ''Claudia Garay Alarmas

    Public Function ConsultarAlamasPac() As DataSet
        Dim dsAlarmasXPac As DataSet
        dsAlarmasXPac = BLHistoriaBasica.ConsultarAlarmasXPac(objConexion, objDatosGenerales.Prestador, objDatosGenerales.Sucursal, objDatosPaciente.TipoAdmision, objDatosPaciente.AnoAdmision, objDatosPaciente.NumeroAdmision, objDatosPaciente.TipoDocumento, objDatosPaciente.NumeroDocumento)
        Return dsAlarmasXPac
    End Function
    Private Sub ConsultarRecomendacionesFarmaco()
        Dim dtAlarmasXPac As DataTable
        dtAlarmasXPac = BLHistoriaBasica.ConsultarRecomendacionesFarmacoXPac(objDatosPaciente.TipoDocumento, objDatosPaciente.NumeroDocumento)

        'If dtAlarmasXPac.Rows.Count > 0 Then
        '    lnkFarmacovigilancia.Visible = True
        '    dtfarmaco = dtAlarmasXPac
        'Else
        '    lnkFarmacovigilancia.Visible = False
        'End If


    End Sub

    Private Sub btnCaida_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCaida.Click
        'Se inactiva esta funcionalidad de acuerdo a solicitud del 
        'req 634 3.9.1. DESCRIPCIÓN DE LA FUNCIONALIDAD: Activar  y desactivar el icono que identifica el Riesgo de Caída.
        'Raul Cruz 20190208

        'Dim dsAlarmasXPac As DataSet
        'Dim frmAlarma As New frmc_TraeAlarmas
        'Dim dtriesgo As New DataTable
        '''Tabla 0 Alarmas por historia
        '''Tabla 1 riesgo caida
        '''Tabla 2 Antecedentes alergicos
        '''Tabla 3 Trae las descripciones del riesgo de caida

        'dsAlarmasXPac = ConsultarAlamasPac()
        'If dsAlarmasXPac.Tables(1).Rows.Count > 0 Then
        '    frmAlarma.Mostrar(dsAlarmasXPac.Tables(3), "Riesgo de Caida")
        'ElseIf dsAlarmasXPac.Tables(0).Rows.Count > 0 Then
        '    dtriesgo = dsAlarmasXPac.Tables(0).Clone
        '    dtriesgo = filtrarTabla(dsAlarmasXPac.Tables(0), "cod_riesgo=1 and estado='S'", dtriesgo)
        '    dtriesgo.Columns.Remove("cod_riesgo")
        '    dtriesgo.Columns.Remove("estado")
        '    dtriesgo.Columns.Remove("cod_historia")
        '    dtriesgo.Columns.Remove("consecutivo")
        '    frmAlarma.Mostrar(dtriesgo, "Riesgo de Caida")
        'End If
        'frmAlarma.Mostrar(dsAlarmasXPac.Tables(0), "Riesgo de Fuga")
    End Sub
    'Public Shared Function filtrarTabla(ByVal dtBase As DataTable, ByVal filtro As String, ByVal dtContenedor As DataTable) As DataTable

    '    Dim rowsFiltradas() As DataRow

    '    rowsFiltradas = dtBase.Select(filtro)
    '    dtContenedor = FuncionesGenerales.copyArrayToDataTable(dtContenedor, rowsFiltradas)
    '    Return dtContenedor

    'End Function

    'Private Sub btnAlergico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlergico.Click
    '    Dim dsAlarmasXPac As DataSet
    '    Dim frmAlarma As New frmc_TraeAlarmas

    '    ''Tabla 0 Alarmas por historia
    '    ''Tabla 1 riesgo caida
    '    ''Tabla 2 Antecedentes alergicos
    '    ''Tabla 3 Trae las descripciones del riesgo de caida

    '    dsAlarmasXPac = ConsultarAlamasPac()
    '    If dsAlarmasXPac.Tables(2).Rows.Count > 0 Then
    '        frmAlarma.Mostrar(dsAlarmasXPac.Tables(2), "Alérgias")
    '    End If
    '    frmAlarma.Mostrar(dsAlarmasXPac.Tables(0), "Anticoagulado")

    'End Sub

    'Private Sub btnMedica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMedica.Click
    '    Dim dsAlarmasXPac As DataSet
    '    Dim frmAlarma As New frmc_TraeAlarmas

    '    ''Tabla 0 Alarmas por historia
    '    ''Tabla 1 riesgo caida
    '    ''Tabla 2 Antecedentes alergicos
    '    ''Tabla 3 Trae las descripciones del riesgo de caida

    '    dsAlarmasXPac = ConsultarAlamasPac()
    '    frmAlarma.Mostrar(dsAlarmasXPac.Tables(0), "Alerta Médica")
    'End Sub

    'Private Sub btnQuirurgico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuirurgico.Click
    '    Dim dsAlarmasXPac As DataSet
    '    Dim frmAlarma As New frmc_TraeAlarmas

    '    ''Tabla 0 Alarmas por historia
    '    ''Tabla 1 riesgo caida
    '    ''Tabla 2 Antecedentes alergicos
    '    ''Tabla 3 Trae las descripciones del riesgo de caida

    '    dsAlarmasXPac = ConsultarAlamasPac()
    '    frmAlarma.Mostrar(dsAlarmasXPac.Tables(0), "Quirúrgico")
    'End Sub

    Private Sub lnkFarmacovigilancia_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        frmc_RecomFarmaco.Mostrar(dtfarmaco)
        frmc_RecomFarmaco.ShowDialog()

    End Sub

    ''WACHV,27dic2016, alarma para paliativo
    Public Sub AlarmaPaliativo()
        If (BLValoracioneIngreso.intAlarmaPaliativo(objDatosGenerales, objDatosPaciente) = 1) Then
            btnPalitivo.Visible = True
        Else
            btnPalitivo.Visible = False
        End If
    End Sub

    Public Shared Function filtrarTabla(ByVal dtBase As DataTable, ByVal filtro As String, ByVal dtContenedor As DataTable) As DataTable

        Dim rowsFiltradas() As DataRow

        rowsFiltradas = dtBase.Select(filtro)
        dtContenedor = FuncionesGenerales.copyArrayToDataTable(dtContenedor, rowsFiltradas)
        Return dtContenedor

    End Function
    Private Sub btnFuga_Click(sender As Object, e As EventArgs) Handles btnFuga.Click
        MostrarDetalleBoton("Riesgo de Fuga", 5)
    End Sub
    Private Sub btnAlergico1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlergico1.Click
        MostrarDetalleBoton("Alérgias", 5)
    End Sub

    Private Sub btnAnticuagulado_Click(sender As Object, e As EventArgs) Handles btnAnticuagulado.Click
        MostrarDetalleBoton("Anticoagulado", 5)
    End Sub

    Private Sub btnMedica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMedica.Click
        MostrarDetalleBoton("Alerta Médica", 5)
    End Sub
    'Se inactiva esta funcionalidad de acuerdo a solicitud del 
    'req 634 3.7.1.       DESCRIPCIÓN DE LA FUNCIONALIDAD: Quitar la opción y el Icono de identificación (cuadro verde)  que actualmente identifica el Riesgo Quirúrgico.
    'Raul Cruz 20190208
    'Private Sub btnQuirurgico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuirurgico.Click
    '    MostrarDetalleBoton("Quirúrgico", 0)
    'End Sub
    Private Sub imBtnAerosol_Click(sender As Object, e As EventArgs) Handles imBtnAerosol.Click
        MostrarDetalleBoton("Aislamiento por Aerosol", 6)
    End Sub
    Private Sub imBtnContacto_Click(sender As Object, e As EventArgs) Handles imBtnContacto.Click
        MostrarDetalleBoton("Aislamiento por Contacto", 6)
    End Sub
    Private Sub imBtnGotas_Click(sender As Object, e As EventArgs) Handles imBtnGotas.Click
        MostrarDetalleBoton("Aislamiento por Gotas", 6)
    End Sub
    Private Sub imBtnProtector_Click(sender As Object, e As EventArgs) Handles imBtnProtector.Click
        MostrarDetalleBoton("Aislamiento por Protector", 6)
    End Sub
    Private Sub imBtnVectores_Click(sender As Object, e As EventArgs) Handles imBtnVectores.Click
        MostrarDetalleBoton("Aislamiento por Vectores", 6)
    End Sub
    Private Sub imBtnResistencia_Click(sender As Object, e As EventArgs) Handles imBtnResistencia.Click
        MostrarDetalleBoton("Resistencia", 5)
    End Sub

    Private Sub imBtnNutricional_Click(sender As Object, e As EventArgs) Handles imBtnNutricional.Click
        MostrarDetalleBoton("Nutricional", 5)
    End Sub

    Private Sub btnPalitivo_Click(sender As Object, e As EventArgs) Handles btnPalitivo.Click
        MostrarDetalleBoton("Paliativo", 7)
    End Sub
    Private Sub imBtnDeterioro_Click(sender As Object, e As EventArgs) Handles imBtnDeterioro.Click
        MostrarDetalleBoton("Deterioro Clínico", 8)
    End Sub
    ''WACHV,27dic2016, alarma para paliativo
    'Public Sub AlarmaPaliativo()
    '    If (BLValoracioneIngreso.intAlarmaPaliativo(objDatosGenerales, objDatosPaciente) = 1) Then
    '        btnPalitivo.Visible = True
    '    Else
    '        btnPalitivo.Visible = False
    '    End If
    'End Sub

    Private Sub lkActDes_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lkActDes.LinkClicked
        Dim form As New Frm_IdenticadoresRiesgo
        form.Mostrar()
    End Sub


    Private Sub MostrarDetalleBoton(Boton As String, ByVal tabla As Int16)

        ''Tabla 0 Alarmas por historia
        ''Tabla 1 riesgo caida
        ''Tabla 2 Antecedentes alergicos
        ''Tabla 3 Trae las descripciones del riesgo de caida
        Dim dsAlarmasXPac As DataSet
        Dim frmAlarma As New frmc_TraeAlarmas

        dsAlarmasXPac = ConsultarAlamasPac()
        frmAlarma.Mostrar(dsAlarmasXPac.Tables(tabla), Boton)
    End Sub

    Private Sub lkHistorico_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lkHistorico.LinkClicked
        Dim form As New Frm_IdenticadoresRiesgoHistorico
        form.Mostrar()
    End Sub


End Class
