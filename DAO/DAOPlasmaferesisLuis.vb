Imports System
Imports objComun = HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports objDatosGenerales = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Namespace Sophia.HistoriaClinica.DAO
    Public Class DAOPlasmaferesis
        Inherits GPMData

#Region "PlasmaferesisProEnGrilla"
        Public Function PlasmaferesisProEnGrilla(ByVal objConexion As objCon, ByVal dNumeroHistoria As Double) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("HCEnf_PlasmaferesisProEnGrilla", CommandType.StoredProcedure)
            Me.addInputParameter("@dNumeroHistoria", SqlDbType.Int, dNumeroHistoria)
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region

#Region "PlasmaferesisProEnSegGrilla"
        Public Function PlasmaferesisProEnSegGrilla(ByVal objConexion As objCon, ByVal dNumeroHistoria As Double, ByVal ConsecutivoSeg As Integer) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("HCEnf_PlasmaferesisProEnSegGrilla", CommandType.StoredProcedure)
            Me.addInputParameter("@dNumeroHistoria", SqlDbType.Int, dNumeroHistoria)
            Me.addInputParameter("@ConsecutivoSeg", SqlDbType.Int, ConsecutivoSeg)
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region

#Region "GrabarPlasmaferisisPro"
        Public Function GrabarPlasmaferisisPro(ByVal objConexion As objCon, ByVal dNumeroHistoria As Double, _
            ByVal mskPlaDigFecha As Date, ByVal inttxtPlaDigHora As Integer, ByVal inttxtPlaDigMinutos As Integer, _
            ByVal strcmbAccVas As String, ByRef inttxtTieProHor As Integer, ByRef inttxtTieProMin As Integer, _
            ByVal inttxtVolPla As Integer, _
            ByVal strchkSolReeSolSalina As String, _
            ByVal strchkSolReePlasma As String, _
            ByVal strchkSolReeAlbumina As String, _
            ByVal strchkSolReeVoluven As String, _
            ByVal inttxtHep As Integer, _
            ByVal inttxtFluSan As Integer, ByVal inttxtPFPro As Integer, _
            ByVal tmpfecha_ret As Nullable(Of Date), ByVal inttmphora_ret As Integer, ByVal inttmpmin_ret As Integer, ByVal inttmppftotal As Integer, _
            ByVal inttmpttotalhor As Integer, ByVal inttmpttotalmin As Integer, ByVal strtmpobs_ret As String, _
            ByVal strtxtPlaProObs As String, ByVal strLogin As String) As Long
            Dim lError As Long
            Me.setSQLSentence("HCenf_GrabarPlasmaferesisPro", CommandType.StoredProcedure)
            Me.addInputParameter("@dNumeroHistoria", SqlDbType.Int, dNumeroHistoria)
            Me.addInputParameter("@mskPlaDigFecha", SqlDbType.DateTime, mskPlaDigFecha)
            Me.addInputParameter("@inttxtPlaDigHora", SqlDbType.Int, inttxtPlaDigHora)
            Me.addInputParameter("@inttxtPlaDigMinutos", SqlDbType.Int, inttxtPlaDigMinutos)
            Me.addInputParameter("@strcmbAccVas", SqlDbType.VarChar, strcmbAccVas)
            Me.addInputParameter("@inttxtTieProHor", SqlDbType.Int, inttxtTieProHor)
            Me.addInputParameter("@inttxtTieProMin", SqlDbType.Int, inttxtTieProMin)
            Me.addInputParameter("@inttxtVolPla", SqlDbType.Int, inttxtVolPla)
            Me.addInputParameter("@strchkSolReeSolSalina", SqlDbType.VarChar, strchkSolReeSolSalina)
            Me.addInputParameter("@strchkSolReePlasma", SqlDbType.VarChar, strchkSolReePlasma)
            Me.addInputParameter("@strchkSolReeAlbumina", SqlDbType.VarChar, strchkSolReeAlbumina)
            Me.addInputParameter("@strchkSolReeVoluven", SqlDbType.VarChar, strchkSolReeVoluven)
            Me.addInputParameter("@inttxtHep", SqlDbType.Int, inttxtHep)
            Me.addInputParameter("@inttxtFluSan", SqlDbType.Int, inttxtFluSan)
            Me.addInputParameter("@inttxtPFPro", SqlDbType.Int, inttxtPFPro)
            Me.addInputParameter("@tmpfecha_ret", SqlDbType.DateTime, tmpfecha_ret)
            Me.addInputParameter("@inttmphora_ret", SqlDbType.Int, inttmphora_ret)
            Me.addInputParameter("@inttmpmin_ret", SqlDbType.Int, inttmpmin_ret)
            Me.addInputParameter("@inttmppftotal", SqlDbType.Int, inttmppftotal)
            Me.addInputParameter("@inttmpttotalhor", SqlDbType.Int, inttmpttotalhor)
            Me.addInputParameter("@inttmpttotalmin", SqlDbType.Int, inttmpttotalmin)
            Me.addInputParameter("@strtmpobs_ret", SqlDbType.VarChar, strtmpobs_ret)
            Me.addInputParameter("@strtxtPlaProObs", SqlDbType.VarChar, strtxtPlaProObs)
            Me.addInputParameter("@strLogin", SqlDbType.VarChar, strLogin)
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()
            lError = Val(Me.Parameters("lError").Value)
            Return lError
        End Function
#End Region

#Region "GrabarPlasmaSeg"
        Public Function GrabarPlasmaSeg(ByVal objConexion As objCon, ByVal HistoriaSeg As Double, _
                   ByVal datmskDigFechaSeg As Date, ByVal inttxtDigHoraSeg As Integer, _
                   ByVal inttxtDigMinutosSeg As Integer, ByVal ConsecutivoSeg As Integer, _
                   ByRef inttxtFluSanSeg As Integer, _
                   ByRef inttxtSolRepSeg As Integer, _
                   ByRef inttxtPFMedio As Integer, _
                   ByRef strtxtObsSeg As String, ByRef LoginSeg As String) As Long
            Dim lError As Long
            Me.setSQLSentence("[HCenf_GrabarPlasmaferesisProSeg]", CommandType.StoredProcedure)
            Me.addInputParameter("@dNumeroHistoria", SqlDbType.Int, HistoriaSeg)
            Me.addInputParameter("@ConsecutivoSeg", SqlDbType.Int, ConsecutivoSeg)
            Me.addInputParameter("@datmskDigFechaSeg", SqlDbType.DateTime, datmskDigFechaSeg)
            Me.addInputParameter("@inttxtDigHoraSeg", SqlDbType.Int, inttxtDigHoraSeg)
            Me.addInputParameter("@inttxtDigMinutosSeg", SqlDbType.Int, inttxtDigMinutosSeg)
            Me.addInputParameter("@inttxtFluSanSeg", SqlDbType.Int, inttxtFluSanSeg)
            Me.addInputParameter("@inttxtSolRepSeg", SqlDbType.VarChar, inttxtSolRepSeg)
            Me.addInputParameter("@inttxtPFMedio", SqlDbType.Int, inttxtPFMedio)
            Me.addInputParameter("@strtxtObsSeg", SqlDbType.VarChar, strtxtObsSeg)
            Me.addInputParameter("@strLogin", SqlDbType.VarChar, LoginSeg)
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()
            lError = Val(Me.Parameters("lError").Value)
            Return lError
        End Function
#End Region

#Region "GrabarPlasmaRet"
        Public Function GrabarPlasmaRet(ByVal objConexion As objCon, ByVal HistoriaSeg As Double, _
                   ByVal datmskDigFechaRet As Date, ByVal inttxtDigHoraRet As Integer, _
                   ByVal inttxtDigMinutosRet As Integer, ByVal intConsecutivoRet As Integer, _
                   ByRef inttxtUFFinal As Integer, _
                   ByRef inttxtTieEfeHor As Integer, _
                   ByRef inttxtTieEfeMin As Integer, _
                   ByRef strtxtObsRet As String, ByRef LoginSeg As String) As Long
            Dim lError As Long
            Me.setSQLSentence("[HCenf_GrabarPlasmaferesisProRet]", CommandType.StoredProcedure)
            Me.addInputParameter("@dNumeroHistoria", SqlDbType.Int, HistoriaSeg)
            Me.addInputParameter("@intConsecutivoRet", SqlDbType.Int, intConsecutivoRet)
            Me.addInputParameter("@datmskDigFechaRet", SqlDbType.DateTime, datmskDigFechaRet)
            Me.addInputParameter("@inttxtDigHoraRet", SqlDbType.Int, inttxtDigHoraRet)
            Me.addInputParameter("@inttxtDigMinutosRet", SqlDbType.Int, inttxtDigMinutosRet)
            Me.addInputParameter("@inttxtUFFinal", SqlDbType.Int, inttxtUFFinal)
            Me.addInputParameter("@inttxtTieEfeHor", SqlDbType.VarChar, inttxtTieEfeHor)
            Me.addInputParameter("@inttxtTieEfeMin", SqlDbType.Int, inttxtTieEfeMin)
            Me.addInputParameter("@strtxtObsRet", SqlDbType.VarChar, strtxtObsRet)
            Me.addInputParameter("@strLogin", SqlDbType.VarChar, LoginSeg)
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()
            lError = Val(Me.Parameters("lError").Value)
            Return lError
        End Function
#End Region
    End Class
End Namespace
