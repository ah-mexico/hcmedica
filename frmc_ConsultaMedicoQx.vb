Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
''Claudia Garay
''Acreditacion Medico Residente
''2011-04-05
Public Class frmc_ConsultaMedicoQx
    Private Shared _Instancia As frmc_ConsultaMedicoQx
    Private objConexion As Conexion
    Public ValidaSeleccion As Boolean
    Private objEvolucion As Evolucion
    Private objGenerales As Generales
    Private objPaciente As Paciente
    Private _codigoMedico As String
    Private _nombreMedico As String
    Private _apellidoMedico As String
    Private _pri_nom As String
    Private _pri_ape As String
    Private _seg_nom As String
    Private _seg_ape As String
    Private StrTipEmpleado As String

    Public Property CodigoMedico() As String
        Get
            Return _codigoMedico
        End Get
        Set(ByVal value As String)
            _codigoMedico = value
        End Set
    End Property
    Public Property NombreMedico() As String
        Get
            Return _nombreMedico

        End Get
        Set(ByVal value As String)
            _nombreMedico = value
        End Set
    End Property
    Public Property ApellidoMedico() As String
        Get
            Return _apellidoMedico

        End Get
        Set(ByVal value As String)
            _apellidoMedico = value
        End Set
    End Property
    Public Property pri_ape() As String
        Get
            Return _pri_ape

        End Get
        Set(ByVal value As String)
            _pri_ape = value
        End Set
    End Property
    Public Property pri_nom() As String
        Get
            Return _pri_nom

        End Get
        Set(ByVal value As String)
            _pri_nom = value
        End Set
    End Property
    Public Property seg_nom() As String
        Get
            Return _seg_nom

        End Get
        Set(ByVal value As String)
            _seg_nom = value
        End Set
    End Property
    Public Property seg_ape() As String
        Get
            Return _seg_ape

        End Get
        Set(ByVal value As String)
            _seg_ape = value
        End Set
    End Property


    'Public Shared ReadOnly Property Instancia() As frmc_ConsultaMedicoQx
    '    Get
    '        If _Instancia Is Nothing Then
    '            _Instancia = New frmc_ConsultaMedicoQx
    '        End If
    '        Return _Instancia
    '    End Get

    'End Property

    Private Sub cmdbuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdbuscar.Click

        'If txtNombre.Text = String.Empty Then
        '    MsgBox("No existen parametros de busqueda", MsgBoxStyle.Information)
        '    Exit Sub
        'End If

        ConsultarMedico()


    End Sub
    Private Sub ConsultarMedico()
        If Len(Trim(txtNombre.Text)) > 0 Or Len(txtApellido.Text) > 0 Then
            consultarNombreMedico(Trim(txtNombre.Text), Trim(txtApellido.Text), StrTipEmpleado)
        End If
    End Sub
    Public Sub New(ByVal strApellido As String, ByVal tip_emp As String, ByVal strNombre As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        txtApellido.Text = strApellido
        txtNombre.Text = strNombre
        StrTipEmpleado = tip_emp
        ConsultarMedico()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Public Sub New(ByVal tip_emp As String)

        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        StrTipEmpleado = tip_emp
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

    End Sub
    Private Sub consultarNombreMedico(ByVal strNombre As String, ByVal strApellido As String, ByVal tip_emp As String)
        Dim objDao As New DAOHistoriaBasica
        Dim dtdatos As New DataTable
        objConexion = Conexion.Instancia

        If strNombre <> "" Then
            strNombre = "%" & strNombre & "%"
        End If

        If strApellido <> "" Then
            strApellido = "%" & strApellido & "%"
        End If

        dtdatos = objDao.ConsultarDatosMedico(objConexion, strNombre, strApellido, tip_emp, 0)
        If dtdatos.Rows.Count = 0 Then
            MsgBox("No existen datos para esta consulta", MsgBoxStyle.Information)
        End If
        dtgmedico.DataSource = dtdatos
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.Close()
        ValidaSeleccion = 0
    End Sub

    Private Sub dtgmedico_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgmedico.CellDoubleClick
        RegistroSeleccionado()
    End Sub
    Private Sub RegistroSeleccionado()
        Dim dt As New DataTable

        dt = dtgmedico.DataSource

        If dtgmedico.CurrentRow Is Nothing Then
            MessageBox.Show("Seleccione un Registro de la Lista", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        _codigoMedico = dtgmedico.CurrentRow.Cells("medico").Value.ToString
        _nombreMedico = dtgmedico.CurrentRow.Cells("Nombres").Value.ToString
        _apellidoMedico = dtgmedico.CurrentRow.Cells("Apellidos").Value.ToString
        _pri_nom = dtgmedico.CurrentRow.Cells("pri_nom").Value.ToString
        _pri_ape = dtgmedico.CurrentRow.Cells("pri_ape").Value.ToString
        _seg_nom = dtgmedico.CurrentRow.Cells("seg_nom").Value.ToString
        _seg_ape = dtgmedico.CurrentRow.Cells("seg_ape").Value.ToString
        Me.Close()
    End Sub

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        RegistroSeleccionado()
    End Sub

    Private Sub frmc_ConsultaMedicoQx_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmdbuscar_Click(sender, e)
    End Sub
End Class