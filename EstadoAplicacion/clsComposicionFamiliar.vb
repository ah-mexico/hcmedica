Imports System.Collections.Generic
Public Class ComposicionFamiliar

#Region "Properties"

    Private Shared _Instancia As ComposicionFamiliar
    Private _IdPariente As Integer
    Private _tip_doc As String
    Private _Num_doc As String
    Private _ParentescoDelIntegranteDeLaFamilia As String
    Private _dscParentescoDelIntegranteDeLaFamilia As String
    Private _NombreDelIntegranteDeLaFamilia As String
    Private _EdadDelIntegranteDeLaFamilia As Integer
    Private _OcupacionDelIntegranteDeLaFamilia As String
    Private _dscOcupacionDelIntegranteDeLaFamilia As String
    Private _fec_con As DateTime
    Private _obs As String
    Private _login As String
    Private _cod_pre_sgs As String
    Private _cod_sucur As String
    Private _tip_admision As String
    Private _ano_adm As Integer
    Private _num_adm As Decimal

    Public Shared ReadOnly Property Instancia() As ComposicionFamiliar
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ComposicionFamiliar
            End If
            Return _Instancia
        End Get
    End Property

    Public Property IdPariente() As Integer
        Get
            Return _IdPariente
        End Get
        Set(ByVal Value As Integer)
            _IdPariente = Value
        End Set
    End Property

    Public Property tip_doc() As String
        Get
            Return _tip_doc
        End Get
        Set(ByVal Value As String)
            _tip_doc = Value
        End Set
    End Property

    Public Property Num_doc() As String
        Get
            Return _Num_doc
        End Get
        Set(ByVal Value As String)
            _Num_doc = Value
        End Set
    End Property

    Public Property ParentescoDelIntegranteDeLaFamilia() As String
        Get
            Return _ParentescoDelIntegranteDeLaFamilia
        End Get
        Set(ByVal Value As String)
            _ParentescoDelIntegranteDeLaFamilia = Value
        End Set
    End Property

    Public Property dscParentescoDelIntegranteDeLaFamilia() As String
        Get
            Return _dscParentescoDelIntegranteDeLaFamilia
        End Get
        Set(ByVal Value As String)
            _dscParentescoDelIntegranteDeLaFamilia = Value
        End Set
    End Property

    Public Property NombreDelIntegranteDeLaFamilia() As String
        Get
            Return _NombreDelIntegranteDeLaFamilia
        End Get
        Set(ByVal Value As String)
            _NombreDelIntegranteDeLaFamilia = Value
        End Set
    End Property

    Public Property EdadDelIntegranteDeLaFamilia() As Integer
        Get
            Return _EdadDelIntegranteDeLaFamilia
        End Get
        Set(ByVal Value As Integer)
            _EdadDelIntegranteDeLaFamilia = Value
        End Set
    End Property

    Public Property OcupacionDelIntegranteDeLaFamilia() As String
        Get
            Return _OcupacionDelIntegranteDeLaFamilia
        End Get
        Set(ByVal Value As String)
            _OcupacionDelIntegranteDeLaFamilia = Value
        End Set
    End Property

    Public Property dscOcupacionDelIntegranteDeLaFamilia() As String
        Get
            Return _dscOcupacionDelIntegranteDeLaFamilia
        End Get
        Set(ByVal Value As String)
            _dscOcupacionDelIntegranteDeLaFamilia = Value
        End Set
    End Property

    Public Property fec_con() As DateTime
        Get
            Return _fec_con
        End Get
        Set(ByVal Value As DateTime)
            _fec_con = Value
        End Set
    End Property

    Public Property obs() As String
        Get
            Return _obs
        End Get
        Set(ByVal Value As String)
            _obs = Value
        End Set
    End Property

    Public Property login() As String
        Get
            Return _login
        End Get
        Set(ByVal Value As String)
            _login = Value
        End Set
    End Property

    Public Property cod_pre_sgs() As String
        Get
            Return _cod_pre_sgs
        End Get
        Set(ByVal Value As String)
            _cod_pre_sgs = Value
        End Set
    End Property

    Public Property cod_sucur() As String
        Get
            Return _cod_sucur
        End Get
        Set(ByVal Value As String)
            _cod_sucur = Value
        End Set
    End Property

    Public Property tip_admision() As String
        Get
            Return _tip_admision
        End Get
        Set(ByVal Value As String)
            _tip_admision = Value
        End Set
    End Property

    Public Property ano_adm() As Integer
        Get
            Return _ano_adm
        End Get
        Set(ByVal Value As Integer)
            _ano_adm = Value
        End Set
    End Property

    Public Property num_adm() As Decimal
        Get
            Return _num_adm
        End Get
        Set(ByVal Value As Decimal)
            _num_adm = Value
        End Set
    End Property


#End Region

#Region "Functions"

    ''' <summary>
    ''' Guarda la Información del familiar
    ''' </summary>
    ''' <param name="oComposicionFamiliar">Información del familiar</param>
    ''' <returns>Resultado de la inserción</returns>
    ''' <remarks></remarks>
    Public Function GuardarFamiliar(ByVal oComposicionFamiliar As ComposicionFamiliar) As String

        Dim objDACPComposicionFamiliar As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
        Return objDACPComposicionFamiliar.GuardarFamiliar(oComposicionFamiliar)

    End Function

    ''' <summary>
    ''' Consulta los familiares registrados para el paciente
    ''' </summary>
    ''' <param name="oComposicionFamiliar">Filtros de busqueda</param>
    ''' <returns>Listado de pacientes</returns>
    ''' <remarks></remarks>
    Public Function ConsultarFamiliar(ByVal oComposicionFamiliar As ComposicionFamiliar) As List(Of ComposicionFamiliar)
        Dim objDACPComposicionFamiliar As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
        Return objDACPComposicionFamiliar.ConsultarFamiliar(oComposicionFamiliar)
    End Function

#End Region

End Class
