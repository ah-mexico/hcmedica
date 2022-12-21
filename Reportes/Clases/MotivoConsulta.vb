Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes

    Public Class MotivoConsulta
        Inherits GPMDataReport

        ''' <summary>
        ''' Informacion Suminitrada por
        ''' </summary>
        Private _FuenteInformacion As String
        ''' <summary>
        ''' Descripcion Motivo de la consulta
        ''' </summary>
        Private _MotivoConsulta As String
        ''' <summary>
        ''' Descripcion Enfermedad
        ''' </summary>
        Private _EnfermedadActual As String
        ''' <summary>
        ''' Define si es visible la seccion en el reporte
        ''' </summary>
        Private _visibleImpresion As Boolean
        ''' <summary>
        ''' Fecha HC Básica
        ''' </summary>
        Private _FechaHCBasica As DateTime

#Region "Propiedades"
        Public Property FuenteInformacion() As String
            Get
                Return _FuenteInformacion
            End Get
            Set(ByVal value As String)
                _FuenteInformacion = value
            End Set
        End Property

        Public Property MotivoConsulta() As String
            Get
                Return _MotivoConsulta
            End Get
            Set(ByVal value As String)
                _MotivoConsulta = value
            End Set
        End Property

        Public Property EnfermedadActual() As String
            Get
                Return _EnfermedadActual
            End Get
            Set(ByVal value As String)
                _EnfermedadActual = value
            End Set
        End Property
        Public Property Visible() As Boolean
            Get
                Return _visibleImpresion
            End Get
            Set(ByVal value As Boolean)
                _visibleImpresion = value
            End Set
        End Property

        Public Property FechaHCBasica() As String
            Get
                Return _FechaHCBasica
            End Get
            Set(ByVal value As String)
                _FechaHCBasica = value
            End Set
        End Property
#End Region

        Public Sub New()
            _visibleImpresion = False
        End Sub

        Public Sub consultarMotivoConsulta(ByVal objConexion As Conexion, ByVal strTipDoc As String,
                   ByVal strNumDoc As String, ByVal strcod_pre_sgs As String,
                   ByVal strCod_sucur As String, ByVal strTip_admision As String,
                   ByVal lano_adm As Long, ByVal dnum_adm As Double)

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim drMotivos As IDataReader

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetStoredProcCommandWrapper("pa_Reportes_MotivoConsulta")

            '' ''With command
            '' ''    .AddInParameter("strcod_pre_sgs", DbType.String, strcod_pre_sgs)
            '' ''    .AddInParameter("strCod_sucur", DbType.String, strCod_sucur)
            '' ''    .AddInParameter("strTip_admision", DbType.String, strTip_admision)
            '' ''    .AddInParameter("lano_adm", DbType.String, lano_adm)
            '' ''    .AddInParameter("dnum_adm", DbType.String, dnum_adm)
            '' ''End With

            '' ''drMotivos = db.ExecuteReader(command)
            gpmDataObj.setSQLSentence("hc_rpt_motivoconsulta", CommandType.StoredProcedure)
            gpmDataObj.addInputParameter("strtipdoc", SqlDbType.VarChar, strTipDoc)
            gpmDataObj.addInputParameter("strnumdoc", SqlDbType.VarChar, strNumDoc)
            gpmDataObj.addInputParameter("fec_ini", SqlDbType.DateTime, Nothing)
            gpmDataObj.addInputParameter("fec_fin", SqlDbType.DateTime, Nothing)
            gpmDataObj.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            gpmDataObj.addInputParameter("cod_sucur", SqlDbType.VarChar, strCod_sucur)
            gpmDataObj.addInputParameter("tip_admision", SqlDbType.VarChar, strTip_admision)
            gpmDataObj.addInputParameter("ano_adm", SqlDbType.VarChar, lano_adm)
            gpmDataObj.addInputParameter("num_adm", SqlDbType.VarChar, dnum_adm)

            drMotivos = gpmDataObj.ExecRdr()

            Inicializar(drMotivos)

            If drMotivos.IsClosed = False Then
                drMotivos.Close()
            End If

            '' ''command.Command.Connection.Close()
            '' ''command.Command.Connection.Dispose()

        End Sub

        Public Sub Inicializar(ByVal drmotivos As IDataReader)
            While drmotivos.Read()
                _FuenteInformacion = drmotivos("Inf_SumPor").ToString
                _MotivoConsulta = drmotivos("mot_consulta").ToString
                _EnfermedadActual = drmotivos("Enf_actual").ToString
                _FechaHCBasica = drmotivos("FechaHCBasica").ToString
            End While

        End Sub

        Public Sub Inicializar(ByVal dtmotivos As DataTable)
            For Each motcon As DataRow In dtmotivos.Rows
                _FuenteInformacion = motcon("Inf_SumPor").ToString
                _MotivoConsulta = motcon("mot_consulta").ToString
                _EnfermedadActual = motcon("Enf_actual").ToString
                _FechaHCBasica = motcon("FechaHCBasica").ToString
            Next


        End Sub
    End Class

End Namespace

