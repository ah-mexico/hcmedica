Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente

Namespace Sophia.HistoriaClinica.BL
    Public Class BLMonitoreoHemo

#Region "BLMonitoreoHemo"

#Region "MonitoreoEnGrilla"
        Public Shared Function MonitoreoEnGrilla(ByVal objConexion As objCon) As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOMonitoreoHemoLuis
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia
            Dim daoNotas As New DAOMonitoreoHemoLuis()
            Return daoNotas.MonitoreoEnGrilla(objConexion, objP.CodHistoria)
        End Function
#End Region

#Region "GrabarMonitoreo"

        Public Function GrabarMonitoreo(ByVal objConexion As objCon, _
                     ByVal datmskDigFecha As Date, ByVal inttxtDigHora As Integer, ByVal inttxtDigMinutos As Integer, _
                     ByVal inttxtPreArtPulSis As Integer, ByVal inttxtPreArtPulDia As Integer, ByVal inttxtPreArtPulMed As Integer, _
                     ByVal inttxtPreCapPul As Integer, _
                     ByVal iTGasCar As Nullable(Of Decimal), _
                     ByVal iTIndCar As Nullable(Of Decimal), _
                     ByVal iTIndSis As Nullable(Of Decimal), _
                     ByVal inttxtIndResVasSis As Integer, ByVal inttxtIndResVasPul As Integer, _
                     ByVal inttxtIndTraVenIzq As Integer, ByVal inttxtIndTraVenDer As Integer, ByVal inttxtPreIntAbd As Integer, _
                     ByVal strtxtObservaciones As String) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOMonitoreoHemoLuis
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia
            Dim lError As Long
            lError = obj.GrabarMonitoreo(objConexion, objP.CodHistoria, _
                                   datmskDigFecha, inttxtDigHora, inttxtDigMinutos, _
                                   inttxtPreArtPulSis, inttxtPreArtPulDia, inttxtPreArtPulMed, _
                                   inttxtPreCapPul, iTGasCar, iTIndCar, _
                                   iTIndSis, inttxtIndResVasSis, inttxtIndResVasPul, _
                                   inttxtIndTraVenIzq, inttxtIndTraVenDer, inttxtPreIntAbd, _
                                   strtxtObservaciones, objG.Login)

            Return lError
        End Function
#End Region

#Region "ValidarLongitud"
        Public Function ValidarLongitud(ByVal objConexion As objCon, ByVal HistoriaSeg As Double, ByVal datDigmskDigFechaSeg As Date, _
                             ByVal strtxtDigHoraSeg As String, ByVal strtxtDigMinutosSeg As String, ByVal ConsecutivoSeg As Integer, _
                             ByVal strHerEvo As String) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAONotasEnfermeria
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia
            Dim lError As Long
            lError = obj.GrabarEvolucionH(objConexion, HistoriaSeg, datDigmskDigFechaSeg, strtxtDigHoraSeg, _
                       strtxtDigMinutosSeg, ConsecutivoSeg, strHerEvo, objG.Login)
            Return lError
            Return lError
        End Function
#End Region

#Region "ValSeaNumero"
        Public Function ValSeaNumero(ByVal campo As String) As Boolean
            Dim er As New System.Text.RegularExpressions.Regex("^[0-9]+$")
            Return (er.IsMatch(campo))
        End Function
#End Region

#Region "ReporteMonitoreoHemo"
        Public Shared Function ReporteMonitoreoHemo(ByVal objConexion As objCon, ByVal dNumeroHistoria As Double, ByVal strFechaIni As Nullable(Of Date), ByVal strFechaFin As Nullable(Of Date), ByVal iHoraIni As Nullable(Of Integer), ByVal iHoraFin As Nullable(Of Integer)) As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lerror As Long
            Return obj.EjecutarSPConParametros("HCENF_ReporteMonitoreoHemo", objConexion, lerror, dNumeroHistoria, strFechaIni, strFechaFin, iHoraIni, iHoraFin)
        End Function
#End Region

#End Region
    End Class
End Namespace