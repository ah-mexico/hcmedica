Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
Namespace Sophia.HistoriaClinica.BL
    Public Class BLPlasmaferesis
#Region "blPlasmaferesis"

#Region "Reporte Plasmaferesis"
        Public Shared Function ReportePlasmeresis(ByVal objConexion As objCon, ByVal dNumeroHistoria As Double, ByVal strFechaIni As Nullable(Of Date), ByVal strFechaFin As Nullable(Of Date), ByVal iHoraIni As Nullable(Of Integer), ByVal iHoraFin As Nullable(Of Integer)) As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lerror As Long
            Return obj.EjecutarSPConParametros("HCENF_ReportePlasmaferesis", objConexion, lerror, dNumeroHistoria, strFechaIni, strFechaFin, iHoraIni, iHoraFin)
        End Function
#End Region

#Region "PlasmaferesisProEnGrilla"
        Public Shared Function PlasmaferesisProEnGrilla(ByVal objConexion As objCon) As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOPlasmaferesis
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia
            Dim daoNotas As New DAOPlasmaferesis()
            Return daoNotas.PlasmaferesisProEnGrilla(objConexion, objP.CodHistoria)
        End Function
#End Region

#Region "PlasmaferesisProEnSegGrilla"
        Public Shared Function PlasmaferesisProEnSegGrilla(ByVal objConexion As objCon, ByVal ConsecutivoSeg As Integer) As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOPlasmaferesis
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia
            Dim daoNotas As New DAOPlasmaferesis()
            Return daoNotas.PlasmaferesisProEnSegGrilla(objConexion, objP.CodHistoria, ConsecutivoSeg)
        End Function
#End Region

#Region "GrabarPlasmaferisisPro"
        Public Function GrabarPlasmaferisisPro(ByVal objConexion As objCon, _
                     ByVal mskPlaDigFecha As Date, ByVal inttxtPlaDigHora As Integer, ByVal inttxtPlaDigMinutos As Integer, _
                     ByVal strcmbAccVas As String, ByVal inttxtTieProHor As Integer, ByVal inttxtTieProMin As Integer, _
                     ByVal inttxtVolPla As Integer, _
                     ByVal strchkSolReeSolSalina As String, _
                     ByVal strchkSolReePlasma As String, _
                     ByVal strchkSolReeAlbumina As String, _
                     ByVal strchkSolReeVoluven As String, _
                     ByVal inttxtHep As Integer, _
                     ByVal inttxtFluSan As Integer, ByVal inttxtPFPro As Integer, _
                     ByVal tmpfecha_ret As Nullable(Of Date), ByVal inttmphora_ret As Integer, ByVal inttmpmin_ret As Integer, ByVal inttmppftotal As Integer, _
                     ByVal inttmpttotalhor As Integer, ByVal inttmpttotalmin As Integer, ByVal strtmpobs_ret As String, _
                     ByVal strtxtPlaProObs As String) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOPlasmaferesis
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia
            Dim lError As Long
            lError = obj.GrabarPlasmaferisisPro(objConexion, objP.CodHistoria, _
                                  mskPlaDigFecha, inttxtPlaDigHora, inttxtPlaDigMinutos, _
                                  strcmbAccVas, inttxtTieProHor, inttxtTieProMin, _
                                  inttxtVolPla, _
                                  strchkSolReeSolSalina, strchkSolReePlasma, strchkSolReeAlbumina, _
                                  strchkSolReeVoluven, inttxtHep, _
                                  inttxtFluSan, inttxtPFPro, _
                                  tmpfecha_ret, inttmphora_ret, inttmpmin_ret, inttmppftotal, _
                                  inttmpttotalhor, inttmpttotalmin, strtmpobs_ret, _
                                  strtxtPlaProObs, objG.Login)
            Return lError
        End Function
#End Region

#Region "GrabarPlasmaSeg"
        Public Function GrabarPlasmaSeg(ByVal objConexion As objCon, ByVal HistoriaSeg As Double, _
                ByVal datDigmskDigFechaSeg As Date, ByVal inttxtDigHoraSeg As Integer, ByVal inttxtDigMinutosSeg As Integer, _
                ByVal ConsecutivoSeg As Integer, ByVal inttxtFluSanSeg As Integer, ByVal inttxtSolRepSeg As Integer, _
                ByVal inttxtPFMedio As Integer, ByVal strtxtObsSeg As String) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOPlasmaferesis
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia
            Dim lError As Long
            lError = obj.GrabarPlasmaSeg(objConexion, HistoriaSeg, datDigmskDigFechaSeg, inttxtDigHoraSeg, _
                       inttxtDigMinutosSeg, ConsecutivoSeg, inttxtFluSanSeg, _
                       inttxtSolRepSeg, inttxtPFMedio, strtxtObsSeg, objG.Login)
            Return lError
        End Function
#End Region

#Region "GrabarPlasmaRet"
        Public Function GrabarPlasmaRet(ByVal objConexion As objCon, ByVal HistoriaSeg As Double, _
                ByVal datmskDigFechaRet As Date, ByVal inttxtDigHoraRet As Integer, ByVal inttxtDigMinutosRet As Integer, _
                ByVal intConsecutivoRet As Integer, ByVal inttxtUFFinal As Integer, ByVal inttxtTieEfeHor As Integer, _
                ByVal inttxtTieEfeMin As Integer, ByVal strtxtObsRet As String) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOPlasmaferesis
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia
            Dim lError As Long
            lError = obj.GrabarPlasmaRet(objConexion, HistoriaSeg, datmskDigFechaRet, inttxtDigHoraRet, _
                       inttxtDigMinutosRet, intConsecutivoRet, inttxtUFFinal, _
                       inttxtTieEfeHor, inttxtTieEfeMin, strtxtObsRet, objG.Login)
            Return lError
        End Function
#End Region

#Region "Validaciones"
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

#Region "ValSeaNumero"
        Public Function ValSeaNumero(ByVal campo As String) As Boolean
            Dim er As New System.Text.RegularExpressions.Regex("^[0-9]+$")
            Return (er.IsMatch(campo))
        End Function
#End Region

#Region "ValNoContCom"
        Public Function ValNoContCom(ByVal campo As String) As Boolean
            Dim er As New System.Text.RegularExpressions.Regex("(^[^']+$)")
            Return (er.IsMatch(campo))
        End Function
#End Region
#End Region

#End Region
    End Class

End Namespace
