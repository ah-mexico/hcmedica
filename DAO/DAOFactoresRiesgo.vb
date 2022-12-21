Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente

Namespace Sophia.HistoriaClinica.DAO
    Public Class DAOFactoresRiesgo
        Inherits GPMData

#Region "consultarTiposFactoresRiesgo"
        Public Function consultarTiposFactoresRiesgo(ByVal objConexion As Conexion) As DataTable
            Dim dtdatos As DataTable

            Me.setSQLSentence("HC_CONSULTAR_TIPOS_IDENTIFICADOR_RIESGO", CommandType.StoredProcedure)
            dtdatos = execDT()

            Return dtdatos
        End Function
#End Region


#Region "GrabarActivaciónfactor"
        Public Function GrabarActivaciónfactor(ByVal objConexion As Conexion, ByVal dtFactorRiesgo As DataTable, codHistoria As Int64, opcion As Int64) As DataTable
            Dim dtdatos As DataTable
            Dim txtXmlFactorRiego As String = ""

            If opcion = 1 Then
                txtXmlFactorRiego = FuncionesGenerales.GenerarXMLxProcedimiento(dtFactorRiesgo)
            End If


            Me.setSQLSentence("HC_INSERTAR_IDENTIFICADOR_RIESGO_ACTIVACION", CommandType.StoredProcedure)
            Me.addInputParameter("txtXmlFactorRiego", SqlDbType.Text, txtXmlFactorRiego)
            Me.addInputParameter("codHistoria", SqlDbType.Int, codHistoria)
            Me.addInputParameter("opcion", SqlDbType.Int, opcion)

            dtdatos = execDT()

            Return dtdatos
        End Function
#End Region

#Region "InactivaciónfactorRiesgo"
        Public Function InactivarfactorRiesgo(ByVal objConexion As Conexion, ByVal IdRegistro As Int64,
                                               ByVal codHistoria As Int64, ByVal Justificacion As String,
                                               ByVal usuario As String, ByVal tipousuario As String, idEspecialidad As String) As Integer
            Dim dtdatos As DataTable
            Dim txtXmlFactorRiego As String = ""

            Me.setSQLSentence("HC_INSERTAR_IDENTIFICADOR_RIESGO_INACTIVACION", CommandType.StoredProcedure)
            Me.addInputParameter("irIdRegistro", SqlDbType.Int, IdRegistro)
            Me.addInputParameter("codHistoria", SqlDbType.Int, codHistoria)
            Me.addInputParameter("inJustificacion", SqlDbType.Text, Justificacion)
            Me.addInputParameter("inUsuario", SqlDbType.Text, usuario)
            Me.addInputParameter("irIdTipoUsuario", SqlDbType.Text, tipousuario)
            Me.addInputParameter("inidspecialidad", SqlDbType.Text, idEspecialidad)


            dtdatos = execDT()

            Return dtdatos.Rows.Count

        End Function
#End Region

#Region "ConsultaHitorico"
        Public Function ConsultaHitorico(ByVal objConexion As Conexion, codHistoria As Int64) As DataTable
            Dim dtdatos As DataTable

            Me.setSQLSentence("HC_CONSULTAR_HISTORICOS_IDENTIFICADOR_RIESGO", CommandType.StoredProcedure)
            Me.addInputParameter("codHistoria", SqlDbType.Int, codHistoria)

            dtdatos = execDT()

            Return dtdatos
        End Function
#End Region


#Region "ConsultaPermisosEspecialidad"
        Public Function ConsultaPermisosEspecialidad(ByVal objConexion As Conexion, IdEspecialidad As String) As Boolean
            Dim dtdatos As DataTable

            Me.setSQLSentence("HC_CONSULTA_PERMISOS_ESPECIALIDAD_IR", CommandType.StoredProcedure)
            Me.addInputParameter("IdEspecialidad", SqlDbType.VarChar, IdEspecialidad)

            dtdatos = execDT()

            Return dtdatos.Rows(0).Item(0)

        End Function
#End Region
    End Class
End Namespace

