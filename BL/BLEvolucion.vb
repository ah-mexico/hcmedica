Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.HistoriaBasica
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion

Namespace Sophia.HistoriaClinica.BL
    Public Class BLEvolucion

        'Public Function ConsultarInterconsultas(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable
        '    Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral

        '    Return obj.EjecutarSPConParametros("", objConexion, lError, Datos)


        'End Function
        Public Function ConsultarProcedimientoInterconsultas(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable
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
            Return obj.EjecutarSPConParametros("HC_EV_GET_PROCEDIMIENTOINTERCONSULTA", objConexion, lError, Datos)
        End Function
        Public Function ConsultarDiagnostico(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable
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


    End Class
End Namespace