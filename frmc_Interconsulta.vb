Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
''Claudia Garay
''Acreditacion Medico Residente
''2011-04-05
Public Class frmc_Interconsulta
    Private Shared _Instancia As frmc_Interconsulta
    Private objConexion As Conexion
    Public ValidaSeleccion As Boolean
    Private objEvolucion As Evolucion
    Private objGenerales As Generales
    Private objPaciente As Paciente
    Private _strMedico As String
    Private _StrMotivo As String
    Private _StrEspecialidad As String
    Private objQx As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAODescripcionQX



    Public Property strMedico() As String
        Get
            Return _strMedico

        End Get
        Set(ByVal value As String)
            _strMedico = value
        End Set
    End Property

    Public Property strEspecialidad() As String
        Get
            Return _strEspecialidad

        End Get
        Set(ByVal value As String)
            _strEspecialidad = value
        End Set
    End Property


    Public Property StrMotivo() As String
        Get
            Return _StrMotivo

        End Get
        Set(ByVal value As String)
            _StrMotivo = value
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



    Public Sub New(ByVal strMedico As String, ByVal StrMotivo As String)
        Dim dt As New DataTable
        ' Llamada necesaria para el Diseñador de Windows Forms.
        InitializeComponent()
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().

        cmbEspecialidad.DataSource = objQx.CargarCombosDescQX(3)
        cmbEspecialidad.DisplayMember = "descripcion"
        cmbEspecialidad.ValueMember = "especialidad"
        cmbEspecialidad.EndUpdate()

    End Sub


    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        _strMedico = Me.txtMedicInterconsulta.Text
        _StrMotivo = Me.TxtMotivo.Text
        If Len(strMedico) > 0 And Len(StrMotivo) > 0 Then
            Me.Close()
            Exit Sub
        End If
    End Sub

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        _strMedico = Me.txtMedicInterconsulta.Text
        _StrMotivo = Me.TxtMotivo.Text
        _StrEspecialidad = cmbEspecialidad.SelectedValue
        If Len(strMedico) > 0 And Len(StrMotivo) > 0 And Len(strEspecialidad) > 0 Then
            Me.Close()
            Exit Sub
        End If
    End Sub

    Private Sub Label3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label3.Click

    End Sub
End Class