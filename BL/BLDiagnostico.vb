Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.HistoriaBasica
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion

Namespace Sophia.HistoriaClinica.BL
    Public Class BLDiagnostico

        ''' <summary>
        ''' Consulta los diagnosticos asociados a una admisión.
        ''' </summary>
        ''' <param name="objConexion"></param>
        ''' <param name="lError"></param>
        ''' <param name="Datos"></param>
        ''' <returns></returns>
        Public Function ConsultarDiagnosticos(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable
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
            Return obj.EjecutarSPConParametros("HC_EV_GET_DIAGNOSTICOS", objConexion, lError, Datos)
        End Function
        ''' <summary>
        ''' Guarda y actualiza los diagnosticos asociados a una admisión.
        ''' </summary>
        ''' <param name="objconexion"></param>
        ''' <param name="strCodigoPrestador"></param>
        ''' <param name="strCodSucur"></param>
        ''' <param name="strTipDoc"></param>
        ''' <param name="strNumDoc"></param>
        ''' <param name="strTipAdm"></param>
        ''' <param name="lNumAdm"></param>
        ''' <param name="intAnoAdm"></param>
        ''' <param name="strClaseDiag"></param>
        ''' <param name="strTipDiag"></param>
        ''' <param name="strDiagnostico"></param>
        ''' <param name="strAntecedente"></param>
        ''' <param name="strObservaciones"></param>
        ''' <param name="strConfidencial"></param>
        ''' <param name="strClasificacion"></param>
        ''' <param name="strCategoria"></param>
        ''' <param name="intSecuencia"></param>
        ''' <param name="strLogin"></param>
        ''' <param name="Estado"></param>
        ''' <returns></returns>
        Public Function GrabarDiagnostico(ByVal objconexion As objCon,
                   ByVal strCodigoPrestador As String, ByVal strCodSucur As String,
                   ByVal strTipDoc As String, ByVal strNumDoc As String,
                   ByVal strTipAdm As String, ByVal lNumAdm As Long,
                   ByVal intAnoAdm As Integer, ByVal strClaseDiag As String,
                   ByVal strTipDiag As String, ByVal strDiagnostico As String,
                   ByVal strAntecedente As String, ByVal strObservaciones As String,
                   ByVal strConfidencial As String, ByVal strClasificacion As String,
                   ByVal strCategoria As String, ByVal intSecuencia As Integer,
                   ByVal strLogin As String, ByVal Estado As Integer) As Long

            Dim objDao As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long

            lError = objDao.EjecutarSPConParametrosTran("HC_ADD_DIAGNOSTICO", objconexion,
                                            strCodigoPrestador, strCodSucur, strTipDoc,
                                            strNumDoc, strTipAdm, lNumAdm, intAnoAdm,
                                            strClaseDiag, strTipDiag, strDiagnostico,
                                            strAntecedente, strObservaciones, strConfidencial,
                                            strClasificacion, strCategoria, intSecuencia,
                                            strLogin, Estado, lError)
            Return lError

        End Function

        Public Function BorrarDiagnostico(ByVal objconexion As objCon,
                   ByVal strCodigoPrestador As String, ByVal strCodSucur As String,
                   ByVal strTipDoc As String, ByVal strNumDoc As String,
                   ByVal strTipAdm As String, ByVal lNumAdm As Long,
                   ByVal intAnoAdm As Integer, ByVal strDiagnostico As String) As Long

            Dim objDao As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long

            lError = objDao.EjecutarSPConParametrosTran("HC_DEL_DIAGNOSTICO", objconexion,
                                            strCodigoPrestador, strCodSucur, strTipDoc,
                                            strNumDoc, strTipAdm, lNumAdm, intAnoAdm,
                                            strDiagnostico, lError)
            Return lError

        End Function

    End Class
End Namespace