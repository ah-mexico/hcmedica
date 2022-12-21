Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.HistoriaBasica
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion


Namespace Sophia.HistoriaClinica.BL
    Public Class BLSignosVitales

        ''' <summary>
        ''' Consulta los SignosVitaless asociados a una admisión.
        ''' </summary>
        ''' <param name="objConexion"></param>
        ''' <param name="lError"></param>
        ''' <param name="Datos"></param>
        ''' <returns></returns>
        Public Function ConsultarSignosVitaless(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim dtProInterconsulta As New DataTable
            Dim Respuesta As Boolean = 0
            'dtProInterconsulta = obj.EjecutarSPConParametros("HC_EV_GET_PROCEDIMIENTOINTERCONSULTA", objConexion, lError, Datos)
            'If dtProInterconsulta.Rows.Count > 0 Then
            '    If dtProInterconsulta.Rows(0)("MENSAJERTA") = "" Then
            '        Respuesta = 1
            '    End If
            'End If
            'Return Respuesta
            Return obj.EjecutarSPConParametros("HC_EV_GET_SignosVitalesS", objConexion, lError, Datos)
        End Function
        ''' <summary>
        ''' Guarda y actualiza los SignosVitaless asociados a una admisión.
        ''' </summary>
        ''' <param name="objconexion"></param>
        ''' <param name="oSignosVitales"></param>
        ''' <returns></returns>
        Public Function addSignosVitales(ByVal objconexion As objCon, ByVal oSignosVitales As SignosVitales) As Long

            Dim objDao As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long

            lError = objDao.EjecutarSPConParametrosTran("HC_ADD_SIGNOSVITALES", objconexion, oSignosVitales.cod_pre_sgs, oSignosVitales.cod_sucur _
                , oSignosVitales.tip_doc, oSignosVitales.Num_doc, oSignosVitales.tip_admision, oSignosVitales.ano_adm, oSignosVitales.num_adm _
                , oSignosVitales.peso, oSignosVitales.talla, oSignosVitales.imc, FuncionesGenerales.ReemplazarString(Val(oSignosVitales.P_Cefalico), 0, DBNull.Value), oSignosVitales.ta_dias, oSignosVitales.ta_sist _
                , oSignosVitales.temperatura, oSignosVitales.fre_cardiaca, oSignosVitales.fre_respira, oSignosVitales.fec_con, oSignosVitales.login, oSignosVitales.obs _
                , oSignosVitales.confidencial, oSignosVitales.alerta, FuncionesGenerales.ReemplazarString(Val(oSignosVitales.glasgow), 0, DBNull.Value), oSignosVitales.embriaguez, FuncionesGenerales.ReemplazarString(Val(oSignosVitales.P_abdominal), 0, DBNull.Value), oSignosVitales.satoxi _
                , oSignosVitales.EAnaloga_dolor, oSignosVitales.ORIGEN, lError, oSignosVitales.idEspecialidad)
            Return lError

        End Function

        Public Function getSignosVitales(ByVal objconexion As objCon, ByVal oSignosVitales As SignosVitales) As Long

            Dim objDao As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long

            'lError = objDao.EjecutarSPConParametros("HC_GET_SIGNOSVITALES", objconexion, oSignosVitales.cod_pre_sgs, oSignosVitales.cod_sucur _
            '    , oSignosVitales.tip_doc, oSignosVitales.Num_doc, oSignosVitales.tip_admision, oSignosVitales.ano_adm, oSignosVitales.num_adm, lError)
            Return lError

        End Function

        Public Function BorrarSignosVitales(ByVal objconexion As objCon,
                   ByVal strCodigoPrestador As String, ByVal strCodSucur As String,
                   ByVal strTipDoc As String, ByVal strNumDoc As String,
                   ByVal strTipAdm As String, ByVal lNumAdm As Long,
                   ByVal intAnoAdm As Integer, ByVal strSignosVitales As String) As Long

            Dim objDao As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long

            lError = objDao.EjecutarSPConParametrosTran("HC_DEL_SignosVitales", objconexion,
                                            strCodigoPrestador, strCodSucur, strTipDoc,
                                            strNumDoc, strTipAdm, lNumAdm, intAnoAdm,
                                            strSignosVitales, lError)
            Return lError

        End Function

    End Class
End Namespace