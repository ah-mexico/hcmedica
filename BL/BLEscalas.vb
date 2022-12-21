Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente

Namespace Sophia.HistoriaClinica.BL
    Public Class BLEscalas
        Inherits GPMData
        Private datosconexion As objCon
#Region "BLEscalas"

#Region "consultarTiposRass"
        Public Shared Function consultarTiposRass(ByVal objConexion As Conexion) As DataTable
            Dim daoEscalas As New DAOEscalas()
            Return daoEscalas.consultarTiposRass(objConexion)
        End Function
#End Region

#Region "consultarTiposRiesgo"
        Public Shared Function consultarTiposRiesgo(ByVal objConexion As Conexion) As DataTable
            Dim daoEscalas As New DAOEscalas()
            Return daoEscalas.consultarTiposRiesgo(objConexion)
        End Function
#End Region

#Region "consultarTiposRiesgoNuevo"
        Public Shared Function consultarTiposRiesgoNuevo(ByVal objConexion As Conexion) As DataTable
            Dim daoEscalas As New DAOEscalas()
            Return daoEscalas.consultarTiposRiesgoNuevo(objConexion)
        End Function
#End Region
#Region "consultarTiposRiesgoVal"
        Public Shared Function consultarTiposRiesgoVal(ByVal objConexion As Conexion) As DataTable
            Dim daoEscalas As New DAOEscalas()
            Return daoEscalas.consultarTiposRiesgoVal(objConexion)
        End Function
#End Region

#Region "consultarTiposRiesgoDet"
        Public Function consultarTiposRiesgoDet(ByVal strCodHistoria As Long, ByVal objConexion As objCon) As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long
            Return obj.EjecutarSPConParametros("HCENF_TraerRiesgoDet", objConexion, lError, strCodHistoria, lError)
        End Function
#End Region

#Region "ConsultarEscalasRass"
        Public Function ConsultarEscalasRass(ByVal strCodHistoria As Long, ByVal objConexion As objCon) As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long
            Return obj.EjecutarSPConParametros("HCENF_TraerEscalaRass", objConexion, lError, strCodHistoria, Nothing, Nothing, Nothing, Nothing, lError)
        End Function
#End Region

#Region "validarEscalas"
        Public Shared Function validarEscalas(ByVal codRass As String, ByVal desRass As String, _
                                ByVal dtRass As DataTable, Optional ByRef mensaje As String = "") As Boolean
            If Len(Trim(codRass)) <= 0 Or Len(Trim(desRass)) <= 0 Then
                mensaje = "Debe digitar la información del Tipo de Rass."
                Return False
            End If
            Return True
        End Function
#End Region

#Region "GrabarEscalasRass"
        Public Function GrabarEscalasRass(ByVal objconexion As objCon, _
                    ByVal strCodHistoria As Long, _
                    ByVal strCodRass As String, _
                    ByVal strFecha As String, _
                    ByVal intHora As Integer, _
                    ByVal intMinuto As Integer, _
                    ByVal strLogin As String) As Long

            Dim objDao As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long

            lError = objDao.EjecutarSPConParametrosTran("HCENF_GrabarEscalaRass", objconexion, _
                                            strCodHistoria, strCodRass, strFecha, intHora, intMinuto, strLogin, lError)
            Return lError
        End Function
#End Region

#Region "ConsultarCamIcu"
        Public Function ConsultarCamIcu(ByVal strCodHistoria As Long, ByVal objConexion As objCon) As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long

            Return obj.EjecutarSPConParametros("HCENF_TraerCamIcu", objConexion, lError, strCodHistoria, Nothing, Nothing, Nothing, Nothing, lError)
        End Function
#End Region

#Region "ConsultarRiesgo"
        Public Function ConsultarRiesgo(ByVal strCodHistoria As Long, ByVal objConexion As objCon) As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long
            Return obj.EjecutarSPConParametros("HCENF_TraerRiesgo", objConexion, lError, strCodHistoria, Nothing, Nothing, Nothing, Nothing, lError)
        End Function
#End Region

#Region "ConsultarRiesgoDet"
        Public Function ConsultarRiesgoDet(ByVal strCodHistoria As Long, ByVal strSecRiesgo As Integer, ByVal objConexion As objCon) As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long
            Return obj.EjecutarSPConParametros("HCENF_TraerRiesgoDet", objConexion, lError, strCodHistoria, strSecRiesgo, lError)
        End Function
#End Region

#Region "GrabarEscalaCamIcu"
        Public Function GrabarEscalaCamIcu(ByVal objconexion As objCon, _
                    ByVal strCodHistoria As Long, _
                    ByVal strCamIcu As String, _
                    ByVal strCamIcu2 As String, _
                    ByVal strFecha As String, _
                    ByVal intHora As Integer, _
                    ByVal intMinuto As Integer, _
                    ByVal strLogin As String) As Long

            Dim objDao As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long
            lError = objDao.EjecutarSPConParametrosTran("HCENF_GrabarEscalaCamIcu", objconexion, _
                                            strCodHistoria, strCamIcu, strCamIcu2, strFecha, intHora, intMinuto, strLogin, lError)
            Return lError
        End Function
#End Region

#Region "GrabarEscalaRiesgo"
        Public Function GrabarEscalaRiesgo(ByVal objconexion As objCon, _
                    ByVal strCodHistoria As Long, _
                    ByVal dtRiesgo As DataTable, _
                    ByVal strFecha As String, _
                    ByVal intHora As Integer, _
                    ByVal intMinuto As Integer, _
                    ByVal strLogin As String) As Long

            Dim objDao As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long

            Dim xmlRiesgoCaida As String = ""
            Dim dtRiesgoModificados As New DataTable
            dtRiesgoModificados = dtRiesgo.Clone()
            dtRiesgoModificados = configurarDataTableRiesgoParaGrabar(dtRiesgo)

            xmlRiesgoCaida = FuncionesGenerales.GenerarXMLxProcedimiento(dtRiesgoModificados)
            lError = objDao.EjecutarSPConParametrosTran("HCENF_GrabarEscalaRiesgo", objconexion, _
                                            strCodHistoria, xmlRiesgoCaida, strFecha, intHora, intMinuto, strLogin, lError)
            Return lError
        End Function
#End Region

#Region "configurarDataTableRiesgoParaGrabar"
        Public Shared Function configurarDataTableRiesgoParaGrabar(ByVal dtRiesgoModificados As DataTable) As DataTable
            Dim dtFiltrado As New DataTable

            With dtRiesgoModificados.Columns
                .Remove("valor")
            End With

            Return dtRiesgoModificados

        End Function
#End Region

#Region "filtrarTablaEsc"
        Public Shared Function filtrarTablaEsc(ByVal dtBase As DataTable, ByVal filtro As String, ByVal dtContenedor As DataTable) As DataTable

            Dim rowsFiltradas() As DataRow

            rowsFiltradas = dtBase.Select(filtro)
            dtContenedor = FuncionesGenerales.copyArrayToDataTable(dtContenedor, rowsFiltradas)
            Return dtContenedor

        End Function
#End Region

#Region "ConsultarNotasTISS"
        Public Function ConsultarNotasTISS(ByVal objConexion As objCon, ByRef dtNotasTISS As DataTable) As Long

            Dim obj As New Sophia.HistoriaClinica.DAO.DAOEscalas

            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia

            Dim lError As Long
            lError = obj.ConsultarNotasTISS(objConexion, CInt(objP.CodHistoria), dtNotasTISS)

            Return lError
        End Function
#End Region


#Region "GrabarTISS"
        Public Function GrabarTISS(ByVal objConexion As objCon, ByVal fecha As DateTime, ByVal hora As String, ByVal minuto As String, ByVal dTISS As Decimal) As Long

            Dim obj As New Sophia.HistoriaClinica.DAO.DAOEscalas

            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia

            Dim lError As Long
            lError = obj.GrabarTISS(objConexion, CInt(objP.CodHistoria), fecha, hora, minuto, dTISS, objG.Login)

            Return lError
        End Function
#End Region

#Region "ValidarTISS"
        Public Function ValidarTISS(ByVal objConexion As objCon, ByVal fecha As DateTime, ByVal hora As String, ByVal minuto As String) As Boolean

            Dim obj As New Sophia.HistoriaClinica.DAO.DAOEscalas
            Dim objP As objPaciente = objPaciente.Instancia

            Return obj.ValidarTISS(objConexion, objP.CodHistoria, fecha, hora, minuto)

        End Function
#End Region

#Region "ConsultarPlantillaEscala"
        ''' <summary>
        ''' Trae los datos de la escala en especifico que se encuentra parametrizada
        ''' </summary>
        ''' <param name="objConexion">cadena de conexión a base de datos</param>
        ''' <param name="idEscala">identificador de la escala a consultar</param>
        ''' <returns>datatable</returns>
        Public Shared Function ConsultarPlantillaEscala(ByVal objConexion As Conexion, IdEscala As Int16) As DataTable
            Dim plantillaEscala As New DAOEscalas()
            Return plantillaEscala.ConsultarPlantillaEscala(objConexion, IdEscala)
        End Function
#End Region
        ''' <summary>
        ''' Carga el historico de escalas de acuerdo a los parametros suministrados
        ''' </summary>
        ''' <param name="objConexion">cadena de conexión a base de datos</param>
        ''' <param name="idEscala">identificador de la escala a consultar</param>
        ''' <param name="codhistoria">identificador de la HC a consultar</param>
        ''' <returns></returns>
        Public Shared Function ConsultarEscalaHistorico(ByVal objConexion As Conexion, IdEscala As Int16, codhistoria As Int64) As DataTable
            Dim objHistoricoEscala As New DAOEscalas()
            Return objHistoricoEscala.ConsultarEscalaHistorico(objConexion, IdEscala, codhistoria)
        End Function

        Public Function GrabarEscala(ByVal objconexion As objCon,
                    ByVal strCodHistoria As Long,
                    ByVal dtRiesgo As DataTable,
                    ByVal strFecha As String,
                    ByVal intHora As Integer,
                    ByVal intMinuto As Integer,
                    ByVal strLogin As String,
                    ByVal intIdEscala As Integer) As Long

            Dim objDao As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long

            Dim xmlRiesgoCaida As String = ""
            Dim xmlUlceras As String = ""
            Dim dtRiesgoModificados As New DataTable
            dtRiesgoModificados = dtRiesgo.Clone()
            dtRiesgoModificados = configurarDataTableRiesgoParaGrabar(dtRiesgo)

            xmlRiesgoCaida = FuncionesGenerales.GenerarXMLxProcedimiento(dtRiesgoModificados)
            lError = objDao.EjecutarSPConParametrosTran("HCENF_GrabarEscala", objconexion,
                                            strCodHistoria, xmlRiesgoCaida, strFecha, intHora, intMinuto, strLogin, intIdEscala, xmlUlceras, lError)
            Return lError
        End Function
        ''' <summary>
        ''' Consulta el puntaje de la escala suministrada
        ''' </summary>
        ''' <param name="objConexion">cadena de conexión a base de datos</param>
        ''' <param name="idEscala">identificador de la escala a consultar</param>
        ''' <returns>Datatable</returns>
        Public Shared Function ConsultarEscalaPuntaje(ByVal objConexion As Conexion, IdEscala As Int16) As DataTable
            Dim objHistoricoEscala As New DAOEscalas()
            Return objHistoricoEscala.ConsultarEscalaPuntaje(objConexion, IdEscala)
        End Function

        Public Shared Function ConsultarEscalaClasificacionRiesgo(ByVal objConexion As Conexion, IdEscala As Int16) As DataTable
            Dim ObjTable As New DAOEscalas()
            Return ObjTable.ConsultarEscalaClasificacionRiesgo(objConexion, IdEscala)
        End Function


        Public Shared Function consultarHoraDif(ByVal objConexion As Conexion, ByVal IdEscala As Int16) As Int32
            Dim ObjTable As New DAOEscalas()
            Return ObjTable.consultarHoraDif(objConexion, IdEscala)
        End Function

        Public Shared Function consultarLinkedBD(ByVal objConexion As Conexion, Basedatos As String) As DataTable
            Dim ObjTable As New DAOEscalas()
            Return ObjTable.consultarLinkedBD(objConexion, Basedatos)
        End Function


#End Region
    End Class

End Namespace