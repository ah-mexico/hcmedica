Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente


Namespace Sophia.HistoriaClinica.BL
    Public Class BLFactoresRiesgo
        Inherits GPMData
        Private datosconexion As objCon

#Region "consultarTiposFactoresRiesgo"
        Public Shared Function consultarTiposFactoresRiesgo(ByVal objConexion As Conexion) As DataTable
            Dim Resultado As New DAOFactoresRiesgo()
            Return Resultado.consultarTiposFactoresRiesgo(objConexion)
        End Function
#End Region

#Region "GrabarActivaciónfactor"
        Public Function GrabarActivaciónfactor(ByVal objConexion As Conexion, dtFactorRiesgo As DataTable, codHistoria As Int64, opcion As Int16) As DataTable
            Dim Resultado As New DAOFactoresRiesgo()
            Return Resultado.GrabarActivaciónfactor(objConexion, dtFactorRiesgo, codHistoria, opcion)
        End Function
#End Region

#Region "InactivaciónfactorRiesgo"
        Public Function InactivarfactorRiesgo(ByVal objConexion As Conexion, ByVal IdRegistro As Int64,
                                               ByVal codHistoria As Int64, ByVal Justificacion As String,
                                               ByVal usuario As String, ByVal tipousuario As String, idEspecialidad As String) As Integer

            Dim Resultado As New DAOFactoresRiesgo()
            Return Resultado.InactivarfactorRiesgo(objConexion, IdRegistro, codHistoria, Justificacion, usuario, tipousuario, idEspecialidad)

        End Function
#End Region

#Region "ConsultaHitorico"
        Public Function ConsultaHitorico(ByVal objConexion As Conexion, codHistoria As Int64) As DataTable
            Dim Resultado As New DAOFactoresRiesgo()
            Return Resultado.ConsultaHitorico(objConexion, codHistoria)
        End Function
#End Region


#Region "ConsultaPermisosEspecialidad "
        Public Shared Function ConsultaPermisosEspecialidad(ByVal objConexion As Conexion, IdEspecialidad As String) As Boolean
            Dim Resultado As New DAOFactoresRiesgo()
            Return Resultado.ConsultaPermisosEspecialidad(objConexion, IdEspecialidad)
        End Function
#End Region

    End Class
End Namespace

