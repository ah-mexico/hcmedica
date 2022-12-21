Imports System
Imports objComun = HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports objDatosGenerales = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Namespace Sophia.HistoriaClinica.DAO
    Public Class DAOMonitoreoHemoLuis
        Inherits GPMData
#Region "DAOMonitoreoHemo"

#Region "consultarherida"
        Public Function consultarherida(ByVal objConexion As objCon) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("select cod_localherida, desc_localherida from hcenflocalherida with(nolock)", CommandType.Text)
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region

#Region "MonitoreoEnGrilla"
        Public Function MonitoreoEnGrilla(ByVal objConexion As objCon, ByVal dNumeroHistoria As Double) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("HCEnf_MonitoreoEnGrilla", CommandType.StoredProcedure)
            Me.addInputParameter("@dNumeroHistoria", SqlDbType.Int, dNumeroHistoria)
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region

#Region "GrabarMonitoreo"

        Public Function GrabarMonitoreo(ByVal objConexion As objCon, ByVal dNumeroHistoria As Double, _
            ByVal datmskDigFecha As Date, ByVal inttxtDigHora As Integer, ByVal inttxtDigMinutos As Integer, _
            ByVal inttxtPreArtPulSis As Integer, ByRef inttxtPreArtPulDia As Integer, ByRef inttxtPreArtPulMed As Integer, _
            ByVal inttxtPreCapPul As Integer, _
            ByVal iTGasCar As Nullable(Of Decimal), _
            ByVal iTIndCar As Nullable(Of Decimal), _
            ByVal iTIndSis As Nullable(Of Decimal), _
            ByVal inttxtIndResVasSis As Integer, ByVal inttxtIndResVasPul As Integer, _
            ByVal inttxtIndTraVenIzq As Integer, ByVal inttxtIndTraVenDer As Integer, ByVal inttxtPreIntAbd As Integer, _
            ByVal strtxtObservaciones As String, ByVal strLogin As String) As Long

            Dim lError As Long
            Me.setSQLSentence("HCEnf_GrabarMonitoreoHemodinamico", CommandType.StoredProcedure)
            Me.addInputParameter("@dNumeroHistoria", SqlDbType.Int, dNumeroHistoria)
            Me.addInputParameter("@datmskDigFecha", SqlDbType.DateTime, datmskDigFecha)
            Me.addInputParameter("@inttxtDigHora", SqlDbType.Int, inttxtDigHora)
            Me.addInputParameter("@inttxtDigMinutos", SqlDbType.Int, inttxtDigMinutos)
            Me.addInputParameter("@inttxtPreArtPulSis", SqlDbType.Int, inttxtPreArtPulSis)
            Me.addInputParameter("@inttxtPreArtPulDia", SqlDbType.Int, inttxtPreArtPulDia)
            Me.addInputParameter("@inttxtPreArtPulMed", SqlDbType.Int, inttxtPreArtPulMed)
            Me.addInputParameter("@inttxtPreCapPul", SqlDbType.Int, inttxtPreCapPul)
            Me.addInputParameter("@inttxtCasCar", SqlDbType.Decimal, iTGasCar)
            Me.addInputParameter("@inttxtIndCar", SqlDbType.Decimal, iTIndCar)
            Me.addInputParameter("@inttxtIndSis", SqlDbType.Decimal, iTIndSis)
            Me.addInputParameter("@inttxtIndResVasSis", SqlDbType.Int, inttxtIndResVasSis)
            Me.addInputParameter("@inttxtIndResVasPul", SqlDbType.Int, inttxtIndResVasPul)
            Me.addInputParameter("@inttxtIndTraVenIzq", SqlDbType.Int, inttxtIndTraVenIzq)
            Me.addInputParameter("@inttxtIndTraVenDer", SqlDbType.Int, inttxtIndTraVenDer)
            Me.addInputParameter("@inttxtPreIntAbd", SqlDbType.Int, inttxtPreIntAbd)
            Me.addInputParameter("@strtxtObservaciones", SqlDbType.VarChar, strtxtObservaciones)
            Me.addInputParameter("@strLogin", SqlDbType.VarChar, strLogin)
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()
            lError = Val(Me.Parameters("lError").Value)
            Return lError
        End Function
#End Region

#End Region
    End Class
End Namespace
