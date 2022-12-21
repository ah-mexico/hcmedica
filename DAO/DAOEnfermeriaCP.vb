Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Namespace Sophia.HistoriaClinica.DAO
    Public Class DAOEnfermeriaCP
        Inherits GPMData

#Region "Cuestionarios Enfermería"

        'Santiago Balcero, se adicionan combos para insercion y seguimientos de cateter
        Public Function CargarCombo(ByVal idCombo As Integer, Optional ByVal strFiltro As String = Nothing) As DataTable
            Dim dt As New DataTable
            Me.ParametersCollection.Clear()
            Select Case idCombo
                Case 1  'Vía de administración de medicamento
                    setSQLSentence("pr_HC_CpConsultaViaAdministracion", CommandType.StoredProcedure)
                Case 2  'Tipo de catéter                
                    setSQLSentence("pr_HC_CpConsultaTipoCateter", CommandType.StoredProcedure)
                    addInputParameter("@tip_registro", SqlDbType.VarChar, strFiltro)
                Case 3  'Lateralidad
                    setSQLSentence("pr_HC_CpConsultaLateralidad", CommandType.StoredProcedure)
                Case 4  'Indicaciones
                    setSQLSentence("pr_HC_CpConsultaIndicaciones", CommandType.StoredProcedure)
                Case 5  'Signos catéter
                    setSQLSentence("pr_HC_CpConsultaSignosCateter", CommandType.StoredProcedure)
                    addInputParameter("@tip_cat", SqlDbType.VarChar, strFiltro)
                Case 6 'Elementos curación
                    setSQLSentence("pr_HC_CpConsultaElementosCuracion", CommandType.StoredProcedure)
                Case 7 'Motivo de retiro de catéter
                    setSQLSentence("pr_HC_CpConsultaMotivoRetiroCateter", CommandType.StoredProcedure)
                    addInputParameter("@tip_cat", SqlDbType.VarChar, strFiltro)
                Case 8  'Tipos de herida
                    setSQLSentence("pr_HC_CpConsultaTipoHerida", CommandType.StoredProcedure)
                Case 9  'Tejidos comprometidos
                    setSQLSentence("pr_HC_CpConsultaTejidoComprometido", CommandType.StoredProcedure)
                Case 10 'Grados de lesión
                    setSQLSentence("pr_HC_CpConsultaGradoLesion", CommandType.StoredProcedure)
                Case 11 'Exudado
                    setSQLSentence("pr_HC_CpConsultaExudado", CommandType.StoredProcedure)
                Case 12 'Caracteristicas del exudado
                    setSQLSentence("pr_HC_CpConsultaCaractExudado", CommandType.StoredProcedure)
                Case 13 'Signos de infección de la herida
                    setSQLSentence("pr_HC_CpConsultaSignosInfeccionHerida", CommandType.StoredProcedure)
                Case 14 'Piel circundante
                    setSQLSentence("pr_HC_CpConsultaPielCircundante", CommandType.StoredProcedure)
                Case 15 'Estados de los bordes
                    setSQLSentence("pr_HC_CpConsultaEstadoBordes", CommandType.StoredProcedure)
                Case 16
                    setSQLSentence("pr_HC_CpConsultaTipoDesbridamiento", CommandType.StoredProcedure)
                Case 17
                    setSQLSentence("pr_HC_CpConsultaJustNoDesbridamiento", CommandType.StoredProcedure)
                Case 18
                    setSQLSentence("pr_HC_CpConsultaFrecuenciaCuracion", CommandType.StoredProcedure)
                Case 19  ''WACHV,NUEVO se agrega, 08Nov2017, Consulta de Tipo Cateter Nuevo              
                    setSQLSentence("pr_HC_CpConsultaTipoCateterNvo", CommandType.StoredProcedure)
                Case 20 ''WACHV,NUEVO se agrega, 07Nov2017, Consulta de Calibre de Cateter
                    setSQLSentence("pr_HC_CpConsultaCalibre", CommandType.StoredProcedure)
                Case 21 ''WACHV,NUEVO se agrega, 07Nov2017, Consulta Zona de Insercion
                    setSQLSentence("pr_HC_CpConsultaZonaInsercion", CommandType.StoredProcedure)
                    addInputParameter("@tip_registro", SqlDbType.VarChar, strFiltro)
                Case 22 ''WACHV,NUEVO se agrega, 08Nov2017, Consulta de Punciones
                    setSQLSentence("pr_HC_CpConsultaPunciones", CommandType.StoredProcedure)
                Case 23 ''WACHV,NUEVO se agrega, 08Nov2017, Consulta Indicaciones Nueva
                    setSQLSentence("pr_HC_CpConsultaIndicacionesNva", CommandType.StoredProcedure)
                Case 24 ''WACHV,NUEVO se agrega, 08Nov2017, Consulta Complicaciones
                    setSQLSentence("pr_HC_CpConsultaComplicaciones", CommandType.StoredProcedure)
                    addInputParameter("@tip_registro", SqlDbType.VarChar, strFiltro)
                Case 25 ''Santiago Balcero,NUEVO se agrega, 09Nov2017, Consulta Estado Sitio de Insercion
                    setSQLSentence("pr_HC_CpEstadoSitioInsercion", CommandType.StoredProcedure)
                    addInputParameter("@tip_registro", SqlDbType.VarChar, strFiltro)
                Case 26 ''Santiago Balcero,NUEVO se agrega, 09Nov2017, Consulta Curacion
                    setSQLSentence("pr_HC_CpConsultaCuracion", CommandType.StoredProcedure)
                Case 27 ''Santiago Balcero,NUEVO se agrega, 09Nov2017, Consulta Se Verifica
                    setSQLSentence("pr_HC_CpConsultaSeVerifica", CommandType.StoredProcedure)
                Case 28 ''Santiago Balcero,NUEVO se agrega, 09Nov2017, Gestión Final
                    setSQLSentence("pr_HC_CpConsultaGestionFinal", CommandType.StoredProcedure)
                Case 29 ''Santiago Balcero,NUEVO se agrega, 09Nov2017, Consulta Motivo Retiro
                    setSQLSentence("pr_HC_CpConsultaMotivoRetiro", CommandType.StoredProcedure)
                    addInputParameter("@tip_registro", SqlDbType.VarChar, strFiltro)
            End Select

            dt = Me.execDT()

            Return dt
        End Function

        Public Function ConsultarPreguntas(ByVal oPreguntaCP As PreguntaCP, ByVal seccion As Long) As List(Of PreguntaCP)
            Dim objDAPreguntaCP As New HistoriaClinica.DAO.DAOCuidadosPaliativos
            oPreguntaCP.seccion = seccion
            Return objDAPreguntaCP.ConsultarPreguntas(oPreguntaCP)
        End Function

        ''' <summary>
        ''' Consulta la Ultima Respuesta de Enfermería registrados para paciente.
        ''' </summary>
        ''' <param name="IdPregunta"></param>
        ''' <param name="Respuesta"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ConsultarUREnfermeria(ByVal IdPregunta As Integer, ByVal Respuesta As String) As Enfermeria
            Dim dtEnfermeria As New DataTable
            Dim objEnfermeria As New Enfermeria


            Me.setSQLSentence("pr_HC_CpConsultaUREnfermeria", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("IdPregunta", SqlDbType.VarChar, IdPregunta)
            Me.addInputParameter("Respuesta", SqlDbType.VarChar, Respuesta)

            dtEnfermeria = Me.execDT

            For Each row As DataRow In dtEnfermeria.Rows

                objEnfermeria.Nom_profesional = IIf(row.Item("NomProfesional").ToString() = "", 0, row.Item("NomProfesional"))
                objEnfermeria.Nom_medicamento = IIf(row.Item("NomMedicamento").ToString() = "", 0, row.Item("NomMedicamento"))
                objEnfermeria.Dosis = IIf(row.Item("Dosis").ToString() = "", 0, row.Item("Dosis"))
                objEnfermeria.Via_Administracion = IIf(row.Item("ViaAdmin").ToString() = "", 0, row.Item("ViaAdmin"))
                objEnfermeria.EsAdministrado = IIf(row.Item("EsAdministrado").ToString() = "", "", row.Item("EsAdministrado"))
                objEnfermeria.Fec_Hora_Administracion = IIf(row.Item("FechaHoraAdmin").ToString() = "", "", row.Item("FechaHoraAdmin"))
                objEnfermeria.Obs_Administracion = IIf(row.Item("CuidadosEnf").ToString() = "", "", row.Item("CuidadosEnf"))
                objEnfermeria.Cuidados_Enfermeria = IIf(row.Item("EvolucionEnf").ToString() = "", 0, row.Item("EvolucionEnf"))
                objEnfermeria.Evolucion_Enfermeria = IIf(row.Item("ObsAdmin").ToString() = "", "", row.Item("ObsAdmin"))
                objEnfermeria.PresentaHeridas = IIf(row.Item("TieneHeridas").ToString() = "", "", row.Item("TieneHeridas"))

            Next

            Return objEnfermeria

        End Function

        Public Function ConsultaParametrica(ByVal IdParam As Integer) As DataTable
            Dim dt As New DataTable

            'Call Especialidades
            Me.setSQLSentence("pr_HC_CpConsultaParametrica", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("id_pregunta", SqlDbType.Int, System.DBNull.Value)
            Me.addInputParameter("descripcion", SqlDbType.VarChar, System.DBNull.Value)
            Me.addInputParameter("id_seccion", SqlDbType.Int, System.DBNull.Value)
            Me.addInputParameter("id_av", SqlDbType.VarChar, System.DBNull.Value)
            Me.addInputParameter("puntaje", SqlDbType.Int, System.DBNull.Value)
            Me.addInputParameter("login", SqlDbType.Int, System.DBNull.Value)
            Me.addInputParameter("fec_con", SqlDbType.DateTime, System.DBNull.Value)
            Me.addInputParameter("obs", SqlDbType.VarChar, System.DBNull.Value)
            Me.addInputParameter("id", SqlDbType.Int, IdParam)
            dt = Me.execDT
            Return dt
        End Function

        Public Function ConsultaParametricaSeccion(ByVal IdSeccion As Integer) As DataTable
            Dim dt As New DataTable

            'Call Especialidades
            Me.setSQLSentence("pr_HC_CpConsultaParametrica", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("id_pregunta", SqlDbType.Int, System.DBNull.Value)
            Me.addInputParameter("descripcion", SqlDbType.VarChar, System.DBNull.Value)
            Me.addInputParameter("id_seccion", SqlDbType.Int, IdSeccion)
            Me.addInputParameter("id_av", SqlDbType.VarChar, System.DBNull.Value)
            Me.addInputParameter("puntaje", SqlDbType.Int, System.DBNull.Value)
            Me.addInputParameter("login", SqlDbType.Int, System.DBNull.Value)
            Me.addInputParameter("fec_con", SqlDbType.DateTime, System.DBNull.Value)
            Me.addInputParameter("obs", SqlDbType.VarChar, System.DBNull.Value)
            Me.addInputParameter("id", SqlDbType.Int, System.DBNull.Value)
            dt = Me.execDT
            Return dt
        End Function
        ''' <summary>
        ''' Función que permite guardar el registro del cuestionario de enfermería
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GuardarRegistroEnfermeria(ByVal objEnfermeria As Enfermeria) As Boolean
            Dim esValido As Boolean = True
            setSQLSentence("pr_HC_CpInsertaEnfermeria", CommandType.StoredProcedure)
            Me.ParametersCollection.Clear()
            Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, objEnfermeria.Cod_pre_sgs)
            Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, objEnfermeria.Cod_sucur)
            Me.addInputParameter("@tip_admision", SqlDbType.VarChar, objEnfermeria.Tip_admision)
            Me.addInputParameter("@ano_adm", SqlDbType.Int, objEnfermeria.Ano_adm)
            Me.addInputParameter("@num_adm", SqlDbType.Int, objEnfermeria.Num_adm)
            Me.addInputParameter("@tip_doc", SqlDbType.VarChar, objEnfermeria.Tip_doc)
            Me.addInputParameter("@num_doc", SqlDbType.VarChar, objEnfermeria.Num_doc)
            Me.addInputParameter("@nom_prof", SqlDbType.VarChar, objEnfermeria.Nom_profesional)
            Me.addInputParameter("@cuidados_enf", SqlDbType.VarChar, objEnfermeria.Cuidados_Enfermeria)
            Me.addInputParameter("@evol_enf", SqlDbType.VarChar, objEnfermeria.Evolucion_Enfermeria)
            Me.addInputParameter("@pres_herida", SqlDbType.VarChar, objEnfermeria.PresentaHeridas)
            Me.addInputParameter("@obs", SqlDbType.VarChar, objEnfermeria.Obs)
            Me.addInputParameter("@login", SqlDbType.VarChar, objEnfermeria.Login)
            Me.addOutputParameter("@Mensaje", SqlDbType.VarChar, 500)

            Try
                Me.Exec()
                esValido = (Me.Parameters("@Mensaje").Value = String.Empty)
            Catch ex As Exception
                esValido = False
            End Try

            Return esValido
        End Function
        ''' <summary>
        ''' Función que permite consultar el último registro del cuestionario de enfermería
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ConsultarRegistroEnfermeria() As DataSet
            Dim ds As DataSet = New DataSet
            Return ds
        End Function

        Public Function BorrarGrillaEnfermeria(ByVal tipoDoc As String, ByVal numDoc As String, ByVal cadenaOpciones As String, ByVal idGrilla As String) As Boolean
            Dim esValido As Boolean = True
            setSQLSentence("pr_HC_BorraRegistroGrillaEnfermeria", CommandType.StoredProcedure)
            Me.ParametersCollection.Clear()
            Me.addInputParameter("@tip_doc", SqlDbType.VarChar, tipoDoc)
            Me.addInputParameter("@num_doc", SqlDbType.VarChar, numDoc)
            Me.addInputParameter("@id_grilla", SqlDbType.VarChar, idGrilla)
            Me.addInputParameter("@idRegistros", SqlDbType.VarChar, cadenaOpciones)
            Me.addOutputParameter("@mensaje", SqlDbType.VarChar, 500)
            Try
                Me.Exec()
                esValido = (Me.Parameters("@mensaje").Value = String.Empty)
            Catch ex As Exception
                esValido = False
            End Try

            Return esValido

        End Function
#End Region

#Region "Control Medicamentos"
        Public Function GuardarRegistroMedicamentos(ByVal objEnfermeria As Enfermeria) As Boolean
            Dim esValido As Boolean = True
            setSQLSentence("pr_HC_CpInsertaAdminMedicamento", CommandType.StoredProcedure)
            Me.ParametersCollection.Clear()
            Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, objEnfermeria.Cod_pre_sgs)
            Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, objEnfermeria.Cod_sucur)
            Me.addInputParameter("@tip_admision", SqlDbType.VarChar, objEnfermeria.Tip_admision)
            Me.addInputParameter("@ano_adm", SqlDbType.Int, objEnfermeria.Ano_adm)
            Me.addInputParameter("@num_adm", SqlDbType.Int, objEnfermeria.Num_adm)
            Me.addInputParameter("@tip_doc", SqlDbType.VarChar, objEnfermeria.Tip_doc)
            Me.addInputParameter("@num_doc", SqlDbType.VarChar, objEnfermeria.Num_doc)
            Me.addInputParameter("@nom_prof", SqlDbType.VarChar, objEnfermeria.Nom_profesional)
            Me.addInputParameter("@nom_med", SqlDbType.VarChar, objEnfermeria.Nom_medicamento)
            Me.addInputParameter("@dosis", SqlDbType.VarChar, objEnfermeria.Dosis)
            Me.addInputParameter("@via_admin", SqlDbType.Int, objEnfermeria.Via_Administracion)
            Me.addInputParameter("@es_admin", SqlDbType.VarChar, objEnfermeria.EsAdministrado)
            Me.addInputParameter("@fec_hor_admin", SqlDbType.VarChar, objEnfermeria.Fec_Hora_Administracion)
            Me.addInputParameter("@obs_admin", SqlDbType.VarChar, objEnfermeria.Obs_Administracion)
            Me.addInputParameter("@obs", SqlDbType.VarChar, objEnfermeria.Obs)
            Me.addInputParameter("@login", SqlDbType.VarChar, objEnfermeria.Login)
            Me.addOutputParameter("@Mensaje", SqlDbType.VarChar, 500)

            Try
                Me.Exec()
                esValido = (Me.Parameters("@Mensaje").Value = String.Empty)
            Catch ex As Exception
                esValido = False
            End Try

            Return esValido
        End Function

        Public Function ConsultarRegistrosMedicamentos(ByVal Tip_doc As String, ByVal Num_doc As String) As DataTable
            Dim dt As DataTable = New DataTable
            Me.ParametersCollection.Clear()
            setSQLSentence("pr_HC_CpConsultaAdminMedicamento", CommandType.StoredProcedure)
            Me.addInputParameter("@tip_doc", SqlDbType.VarChar, Tip_doc)
            Me.addInputParameter("@num_doc", SqlDbType.VarChar, Num_doc)
            Me.addInputParameter("@tip_res", SqlDbType.VarChar, "L")
            dt = Me.execDT()
            Return dt
        End Function

        Public Function ConsultaURMedicamentos(ByVal Tip_doc As String, ByVal Num_doc As String) As DataTable
            Dim dt As DataTable = New DataTable
            Me.ParametersCollection.Clear()
            setSQLSentence("pr_HC_CpConsultaURAdminMedicamento", CommandType.StoredProcedure)
            Me.addInputParameter("@tip_doc", SqlDbType.VarChar, Tip_doc)
            Me.addInputParameter("@num_doc", SqlDbType.VarChar, Num_doc)
            dt = Me.execDT()
            Return dt
        End Function

#End Region

#Region "Novedades Catéter"
        ''' <summary>
        ''' Función que permite guardar el registro de novedades de catéter
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GuardarRegistroCateter(ByVal objCateter As RegistroCateter) As Boolean
            Dim esValido As Boolean = True
            setSQLSentence("pr_HC_CpInsertaRegistroCateter", CommandType.StoredProcedure)
            Me.ParametersCollection.Clear()
            Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, objCateter.Cod_pre_sgs)
            Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, objCateter.Cod_sucur)
            Me.addInputParameter("@tip_admision", SqlDbType.VarChar, objCateter.Tip_admision)
            Me.addInputParameter("@ano_adm", SqlDbType.Int, objCateter.Ano_adm)
            Me.addInputParameter("@num_adm", SqlDbType.Int, objCateter.Num_adm)
            Me.addInputParameter("@tip_doc", SqlDbType.VarChar, objCateter.Tip_Doc)
            Me.addInputParameter("@num_doc", SqlDbType.VarChar, objCateter.Num_Doc)
            Me.addInputParameter("@tip_reg", SqlDbType.VarChar, objCateter.Tip_Registro)
            Me.addInputParameter("@tip_cat", SqlDbType.Int, objCateter.Tip_Cateter)
            Me.addInputParameter("@fec_ins", SqlDbType.VarChar, objCateter.Fec_Insercion)
            Me.addInputParameter("@sit_ins", SqlDbType.VarChar, objCateter.Sitio_Insercion)
            Me.addInputParameter("@cal_cat", SqlDbType.VarChar, objCateter.Calibre)
            Me.addInputParameter("@lat_cat", SqlDbType.Int, objCateter.Lateralidad)
            Me.addInputParameter("@num_pun", SqlDbType.Int, objCateter.NroPunciones)
            Me.addInputParameter("@ind_cat", SqlDbType.VarChar, objCateter.Indicaciones)
            Me.addInputParameter("@comp_cat", SqlDbType.VarChar, objCateter.Complicaciones)
            Me.addInputParameter("@seg_cat", SqlDbType.VarChar, objCateter.Seguimiento_del_cateter)
            Me.addInputParameter("@fec_cur", SqlDbType.VarChar, objCateter.Fec_Curacion)
            Me.addInputParameter("@sig_pre", SqlDbType.VarChar, objCateter.SignosPresentados)
            Me.addInputParameter("@rea_cur", SqlDbType.VarChar, objCateter.RealizoCuracion)
            Me.addInputParameter("@ele_cur", SqlDbType.VarChar, objCateter.ElementosCuracion)
            Me.addInputParameter("@fec_ret", SqlDbType.VarChar, objCateter.Fec_Retiro)
            Me.addInputParameter("@mot_ret", SqlDbType.Int, objCateter.MotivoRetiro)
            Me.addInputParameter("@espec_login", SqlDbType.VarChar, objCateter.Especialidad)    ''cod. especialidad del login
            Me.addInputParameter("@Med_login", SqlDbType.VarChar, objCateter.LoginMedico)       ''Login medico
            Me.addInputParameter("@EsSophia", SqlDbType.VarChar, objCateter.EsSophia) ''Si es Sophia, NO =Avicena WS
            Me.addInputParameter("@obs", SqlDbType.VarChar, objCateter.Obs)
            Me.addInputParameter("@login", SqlDbType.VarChar, objCateter.Login)
            Me.addOutputParameter("@Mensaje", SqlDbType.VarChar, 500)

            Try
                Me.Exec()
                esValido = (Me.Parameters("@Mensaje").Value = String.Empty)
            Catch ex As Exception
                esValido = False
            End Try

            Return esValido
        End Function
        'Santiago Balcero, se crea funcion para guardar seguimiento de cateter
        Public Function GuardaSeguimientoCateter(ByVal objCateter As RegistroCateter) As Boolean
            Dim esValido As Boolean = True
            setSQLSentence("pr_HC_CpInsertaRegistroCateter", CommandType.StoredProcedure)
            Me.ParametersCollection.Clear()
            Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, objCateter.Cod_pre_sgs)
            Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, objCateter.Cod_sucur)
            Me.addInputParameter("@tip_admision", SqlDbType.VarChar, objCateter.Tip_admision)
            Me.addInputParameter("@ano_adm", SqlDbType.Int, objCateter.Ano_adm)
            Me.addInputParameter("@num_adm", SqlDbType.Int, objCateter.Num_adm)
            Me.addInputParameter("@tip_doc", SqlDbType.VarChar, objCateter.Tip_Doc)
            Me.addInputParameter("@num_doc", SqlDbType.VarChar, objCateter.Num_Doc)
            Me.addInputParameter("@tip_reg", SqlDbType.VarChar, objCateter.Tip_Registro)
            Me.addInputParameter("@fec_ins", SqlDbType.VarChar, objCateter.Fec_Insercion)
            Me.addInputParameter("@fec_cur", SqlDbType.VarChar, objCateter.Fec_Curacion)
            Me.addInputParameter("@sig_pre", SqlDbType.VarChar, objCateter.SignosPresentados)
            Me.addInputParameter("@dias_cateter", SqlDbType.Int, objCateter.Dias_Cateter)
            Me.addInputParameter("@rea_cur", SqlDbType.VarChar, objCateter.RealizoCuracion)
            Me.addInputParameter("@ele_cur", SqlDbType.VarChar, objCateter.ElementosCuracion)
            Me.addInputParameter("@se_verifica", SqlDbType.VarChar, objCateter.SeVerifica)
            Me.addInputParameter("@ges_final", SqlDbType.VarChar, objCateter.GestionFinal)
            Me.addInputParameter("@mretiro", SqlDbType.VarChar, objCateter.MRetiro)
            Me.addInputParameter("@espec_login", SqlDbType.VarChar, objCateter.Especialidad) ''cod. especialidad del login
            Me.addInputParameter("@Med_login", SqlDbType.VarChar, objCateter.LoginMedico)    ''Login medico
            Me.addInputParameter("@codcateter", SqlDbType.VarChar, objCateter.CodCateter)
            Me.addInputParameter("@EsSophia", SqlDbType.VarChar, objCateter.EsSophia) ''Si es Sophia, NO =Avicena WS
            Me.addInputParameter("@obs", SqlDbType.VarChar, objCateter.Obs)
            Me.addInputParameter("@login", SqlDbType.VarChar, objCateter.Login)
            Me.addOutputParameter("@Mensaje", SqlDbType.VarChar, 500)

            Try
                Me.Exec()
                esValido = (Me.Parameters("@Mensaje").Value = String.Empty)
            Catch ex As Exception
                esValido = False
            End Try

            Return esValido
        End Function
        ''' <summary>
        ''' Función que permite consultar todos los registros de novedades de catéter para un paciente
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ConsultarRegistrosCateter(ByVal Tip_doc As String, ByVal Num_doc As String) As DataTable
            Dim dt As DataTable = New DataTable
            Me.ParametersCollection.Clear()
            setSQLSentence("pr_HC_CpConsultaCateter", CommandType.StoredProcedure)
            Me.addInputParameter("@tip_doc", SqlDbType.VarChar, Tip_doc)
            Me.addInputParameter("@num_doc", SqlDbType.VarChar, Num_doc)
            Me.addInputParameter("@tip_res", SqlDbType.VarChar, "L")
            dt = Me.execDT()
            Return dt
        End Function
        '' WACHV, BUSCAR LA COMBINACION DE tipo de Catéter, Zona de Inserción y Lateralidad
        Public Function BuscarCombinacionCateter(ByVal Tip_doc As String,
                                                 ByVal Num_doc As String,
                                                 ByVal fecInsercionCateter As String,
                                                 ByVal intTipoCateter As Integer,
                                                 ByVal intZonaInsercion As Integer,
                                                 ByVal intLateralidad As Integer) As Boolean
            Dim esValido As Boolean = False ''SI ES FALSO NO EXISTE
            Me.ParametersCollection.Clear()
            setSQLSentence("pr_HC_CpBuscaCombinacionCateter", CommandType.StoredProcedure)
            Me.addInputParameter("@tip_doc", SqlDbType.VarChar, Tip_doc)
            Me.addInputParameter("@num_doc", SqlDbType.VarChar, Num_doc)
            Me.addInputParameter("@fecInsercionCateter", SqlDbType.VarChar, fecInsercionCateter)
            Me.addInputParameter("@tip_cat", SqlDbType.Int, intTipoCateter)
            Me.addInputParameter("@sit_ins", SqlDbType.Int, intZonaInsercion)
            Me.addInputParameter("@lat_cat", SqlDbType.Int, intLateralidad)
            Me.addOutputParameter("@Mensaje", SqlDbType.VarChar, 500)
            Try
                Me.Exec()
                If Me.Parameters("@Mensaje").Value.ToString() = "SI" Then
                    esValido = True  ''Si Existe es True
                ElseIf Me.Parameters("@Mensaje").Value.ToString() = "NO" Then
                    esValido = False  'Si No Existe es falso
                End If
            Catch ex As Exception

            End Try

            Return esValido
        End Function
        Public Function ConsultaURCateter(ByVal Tip_doc As String, ByVal Num_doc As String) As DataTable
            Dim dt As DataTable = New DataTable
            Me.ParametersCollection.Clear()
            setSQLSentence("pr_HC_CpConsultaURCateter", CommandType.StoredProcedure)
            Me.addInputParameter("@tip_doc", SqlDbType.VarChar, Tip_doc)
            Me.addInputParameter("@num_doc", SqlDbType.VarChar, Num_doc)
            dt = Me.execDT()
            Return dt
        End Function
#End Region

#Region "Registro Heridas"
        ''' <summary>
        ''' Función que permite guardar el registro de heridas en la historia clínica
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GuardarRegistroHerida(ByVal objHerida As RegistroHerida) As Boolean
            Dim esValido As Boolean = True
            setSQLSentence("pr_HC_CpInsertaRegistroHerida", CommandType.StoredProcedure)
            Me.ParametersCollection.Clear()
            Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, objHerida.Cod_pre_sgs)
            Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, objHerida.Cod_sucur)
            Me.addInputParameter("@tip_admision", SqlDbType.VarChar, objHerida.Tip_admision)
            Me.addInputParameter("@ano_adm", SqlDbType.Int, objHerida.Ano_adm)
            Me.addInputParameter("@num_adm", SqlDbType.Int, objHerida.Num_adm)
            Me.addInputParameter("@tip_doc", SqlDbType.VarChar, objHerida.Tip_Doc)
            Me.addInputParameter("@num_doc", SqlDbType.VarChar, objHerida.Num_Doc)
            Me.addInputParameter("@loc_her", SqlDbType.VarChar, objHerida.Loc_Herida)
            Me.addInputParameter("@tip_her", SqlDbType.VarChar, objHerida.Tip_Herida)
            Me.addInputParameter("@lon_her", SqlDbType.VarChar, objHerida.Long_Herida)
            Me.addInputParameter("@tie_tun", SqlDbType.VarChar, objHerida.Tunelizacion)
            Me.addInputParameter("@ubi_tun", SqlDbType.VarChar, objHerida.Ubi_Tunelizacion)
            Me.addInputParameter("@prf_tun", SqlDbType.VarChar, objHerida.Prof_Tunelizacion)
            Me.addInputParameter("@tie_fis", SqlDbType.VarChar, objHerida.Fistula)
            Me.addInputParameter("@ubi_fis", SqlDbType.VarChar, objHerida.Ubi_Fistula)
            Me.addInputParameter("@prf_fis", SqlDbType.VarChar, objHerida.Prof_Fistula)
            Me.addInputParameter("@tej_com", SqlDbType.VarChar, objHerida.Tejido_Comprometido)
            Me.addInputParameter("@gra_les", SqlDbType.Int, objHerida.Grado)
            Me.addInputParameter("@nec_sec", SqlDbType.VarChar, objHerida.Nec_Seco)
            Me.addInputParameter("@nec_hum", SqlDbType.VarChar, objHerida.Nec_Humedo)
            Me.addInputParameter("@por_fib", SqlDbType.VarChar, objHerida.Fibrina)
            Me.addInputParameter("@por_epi", SqlDbType.VarChar, objHerida.Epitelizacion)
            Me.addInputParameter("@por_gra", SqlDbType.VarChar, objHerida.Granulacion)
            Me.addInputParameter("@exudado", SqlDbType.Int, objHerida.Exudado)
            Me.addInputParameter("@car_exu", SqlDbType.Int, objHerida.Car_Exudado)
            Me.addInputParameter("@sig_inf", SqlDbType.VarChar, objHerida.Signo_Infeccion)
            Me.addInputParameter("@pie_cir", SqlDbType.VarChar, objHerida.Piel_Circundante)
            Me.addInputParameter("@est_bor", SqlDbType.VarChar, objHerida.Estado_Bordes)
            Me.addInputParameter("@tie_des", SqlDbType.VarChar, objHerida.Tiene_Desbridamiento)
            Me.addInputParameter("@tip_des", SqlDbType.VarChar, objHerida.Tipo_Desbridamiento)
            Me.addInputParameter("@jus_des", SqlDbType.VarChar, objHerida.Justif_No_Desbridamiento)
            Me.addInputParameter("@pro_ins", SqlDbType.VarChar, objHerida.Protocolo)
            Me.addInputParameter("@fre_cur", SqlDbType.Int, objHerida.Frec_Curacion)
            Me.addInputParameter("@obs_her", SqlDbType.VarChar, objHerida.Obs_Herida)
            Me.addInputParameter("@obs", SqlDbType.VarChar, objHerida.Obs)
            Me.addInputParameter("@login", SqlDbType.VarChar, objHerida.Login)
            Me.addOutputParameter("@Mensaje", SqlDbType.VarChar, 500)

            Try

                Me.Exec()
                esValido = (Me.Parameters("@Mensaje").Value = String.Empty)
            Catch ex As Exception
                esValido = False
            End Try

            Return esValido
        End Function
        '' <summary>
        ''' Función que permite obtener el registro histórico de heridas presentadas por uhn paciente
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ConsultarRegistrosHeridas(ByVal Tip_doc As String, ByVal Num_doc As String) As DataTable
            Dim dt As DataTable = New DataTable
            Me.ParametersCollection.Clear()
            setSQLSentence("pr_HC_CpConsultaHeridas", CommandType.StoredProcedure)
            Me.addInputParameter("@tip_doc", SqlDbType.VarChar, Tip_doc)
            Me.addInputParameter("@num_doc", SqlDbType.VarChar, Num_doc)
            Me.addInputParameter("@tip_res", SqlDbType.VarChar, "L")
            dt = Me.execDT()
            Return dt
        End Function

        Public Function ConsultarURHeridas(ByVal Tip_doc As String, ByVal Num_doc As String) As DataTable
            Dim dt As DataTable = New DataTable
            Me.ParametersCollection.Clear()
            setSQLSentence("pr_HC_CpConsultaURHeridas", CommandType.StoredProcedure)
            Me.addInputParameter("@tip_doc", SqlDbType.VarChar, Tip_doc)
            Me.addInputParameter("@num_doc", SqlDbType.VarChar, Num_doc)
            dt = Me.execDT()
            Return dt
        End Function
#End Region

#Region "Gestion Cateteres"
        ''' <summary>
        '' Función que permite consultar todos los registros cateteres para la gestion del mismo.
        Public Function ConsultarGestionCateter(ByVal Tip_doc As String, ByVal Num_doc As String,
         ByVal strCodPreSgs As String, ByVal strCodSucur As String, ByVal tip_admision As String,
         ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double) As DataTable
            Dim dt As DataTable = New DataTable
            ''Llamar a historico para armar un solo registro
            Me.ParametersCollection.Clear()
            setSQLSentence("pr_HC_CpConsultaInsercionCateteres", CommandType.StoredProcedure)
            Me.addInputParameter("@tip_doc", SqlDbType.VarChar, Tip_doc)
            Me.addInputParameter("@num_doc", SqlDbType.VarChar, Num_doc)
            Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, strCodPreSgs)
            Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, strCodSucur)
            Me.addInputParameter("@tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("@ano_adm", SqlDbType.Int, strAno_Adm)
            Me.addInputParameter("@num_adm", SqlDbType.Int, strNum_Adm)
            dt = Me.execDT()
            Return dt
        End Function
        'Santiago Balcero funcion para llamado a consulta cateter
        Public Function ConsultarSeguimientoCateter(ByVal Bandera As Integer,
                                                    ByVal Tip_doc As String,
                                                    ByVal Num_doc As String,
                                                    ByVal CodCat As String,
                                                    ByVal FechaCat As String,
                                                    ByVal strCodPreSgs As String,
                                                    ByVal strCodSucur As String,
                                                    ByVal tip_admision As String,
         ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double) As DataTable
            Dim dt As DataTable = New DataTable
            ''Llamar a historico para armar un solo registro

            Me.ParametersCollection.Clear()
            setSQLSentence("pr_HC_CpConsultaInsercionSeguimiento", CommandType.StoredProcedure)
            Me.addInputParameter("@bandera", SqlDbType.BigInt, Bandera)
            Me.addInputParameter("@tip_doc", SqlDbType.VarChar, Tip_doc)
            Me.addInputParameter("@num_doc", SqlDbType.VarChar, Num_doc)
            Me.addInputParameter("@codcateter", SqlDbType.VarChar, CodCat)
            Me.addInputParameter("@fecinsercateter", SqlDbType.VarChar, FechaCat)
            Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, strCodPreSgs)
            Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, strCodSucur)
            Me.addInputParameter("@tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("@ano_adm", SqlDbType.Int, strAno_Adm)
            Me.addInputParameter("@num_adm", SqlDbType.Int, strNum_Adm)
            Me.addOutputParameter("@Mensaje", SqlDbType.VarChar, 500)
            dt = Me.execDT()
            Return dt
        End Function
        'Santiago Balcero, se crea funcion para guardar seguimiento de cateter
        Public Function ValidacierreHC(ByVal Bandera As Integer, ByVal objCateter As RegistroCateter) As Boolean
            Dim esValido As Boolean = True
            setSQLSentence("pr_HC_CpConsultaInsercionSeguimiento", CommandType.StoredProcedure)
            Me.ParametersCollection.Clear()
            Me.addInputParameter("@bandera", SqlDbType.BigInt, Bandera)
            Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, objCateter.Cod_pre_sgs)
            Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, objCateter.Cod_sucur)
            Me.addInputParameter("@tip_admision", SqlDbType.VarChar, objCateter.Tip_admision)
            Me.addInputParameter("@ano_adm", SqlDbType.Int, objCateter.Ano_adm)
            Me.addInputParameter("@num_adm", SqlDbType.Int, objCateter.Num_adm)
            Me.addOutputParameter("@Mensaje", SqlDbType.VarChar, 500)
            Try
                Me.Exec()
                esValido = (Me.Parameters("@Mensaje").Value = String.Empty)
            Catch ex As Exception
                esValido = False
            End Try

            Return esValido
        End Function
        'Santiago Balcero, se crea funcion para guardar seguimiento de cateter
        Public Function ConsultarEspecialidad(ByVal Bandera As Integer, ByVal strCodPreSgs As String, ByVal strCodSucur As String, ByVal responsable As String) As String
            Dim Res As String
            Dim dt As DataTable = New DataTable
            setSQLSentence("pr_HC_CpConsultaInsercionSeguimiento", CommandType.StoredProcedure)
            Me.ParametersCollection.Clear()
            Me.addInputParameter("@bandera", SqlDbType.BigInt, Bandera)
            Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, strCodPreSgs)
            Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, strCodSucur)
            Me.addInputParameter("@login", SqlDbType.VarChar, responsable)
            Me.addOutputParameter("@Mensaje", SqlDbType.VarChar, 500)

            Try
                Me.Exec()
                Res = Me.Parameters("@Mensaje").Value
            Catch ex As Exception

            End Try

            Return Res
        End Function

        'Santiago Balcero, se crea funcion para validar gestion final en cateteres asignados a la admisión del paciente
        Public Function ValidacierreHCCateter(ByVal Bandera As Integer, ByVal objCateter As RegistroCateter) As Boolean
            Dim esValido As Boolean = True
            setSQLSentence("pr_HC_CpConsultaInsercionSeguimiento", CommandType.StoredProcedure)
            Me.ParametersCollection.Clear()
            Me.addInputParameter("@bandera", SqlDbType.BigInt, Bandera)
            Me.addInputParameter("@tip_doc", SqlDbType.VarChar, objCateter.Tip_Doc)
            Me.addInputParameter("@num_doc", SqlDbType.VarChar, objCateter.Num_Doc)
            Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, objCateter.Cod_pre_sgs)
            Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, objCateter.Cod_sucur)
            Me.addInputParameter("@tip_admision", SqlDbType.VarChar, objCateter.Tip_admision)
            Me.addInputParameter("@ano_adm", SqlDbType.Int, objCateter.Ano_adm)
            Me.addInputParameter("@num_adm", SqlDbType.Int, objCateter.Num_adm)
            Me.addOutputParameter("@Mensaje", SqlDbType.VarChar, 500)
            Try
                Me.Exec()
                esValido = (Me.Parameters("@Mensaje").Value = String.Empty)
            Catch ex As Exception
                esValido = False
            End Try

            Return esValido
        End Function

#End Region

#Region "Historicos Cateteres"

        ''WACHV, 23NOV2017,SE AGREGA PARA OBTEBNER SOLO LOS CATETERES NUEVOS
        Public Function ConsultaParametricaCateteres() As DataTable
            Dim dt As New DataTable
            Me.setSQLSentence("pr_HC_CpConsultaParametricaCateteres", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("id_pregunta", SqlDbType.Int, System.DBNull.Value)
            Me.addInputParameter("descripcion", SqlDbType.VarChar, System.DBNull.Value)
            Me.addInputParameter("id_seccion", SqlDbType.Int, System.DBNull.Value)
            Me.addInputParameter("id_av", SqlDbType.VarChar, System.DBNull.Value)
            Me.addInputParameter("puntaje", SqlDbType.Int, System.DBNull.Value)
            Me.addInputParameter("login", SqlDbType.Int, System.DBNull.Value)
            Me.addInputParameter("fec_con", SqlDbType.DateTime, System.DBNull.Value)
            Me.addInputParameter("obs", SqlDbType.VarChar, System.DBNull.Value)
            Me.addInputParameter("id", SqlDbType.Int, System.DBNull.Value)
            dt = Me.execDT
            Return dt
        End Function

        ''WACHV, Inserta el Historico para despues consultarlo
        Public Function ConsultarDiasHistorico(ByVal strNombre As String) As DataTable

            Dim dt As New DataTable

            Me.setSQLSentence("DB_Traergenparsophia", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("nombre_par", SqlDbType.VarChar, strNombre)

            dt = Me.execDT()

            Return dt
        End Function

        ''WACHV, Inserta el Historico para despues consultarlo
        Public Function InserRegHistoCateteresAvicena(ByVal idPregunta As Integer,
                                                      ByVal IdParametrica As Integer,
                                                      ByVal Texto As String,
                                                      ByVal Fecha_reg As DateTime,
                                                      ByVal Resultado As String,
                                                      ByVal IP As String,
                                                      ByVal obs As String) As String

            Dim MensajeError As String = ""
            Dim ierror As Long
            Dim intSecuencia As Integer = 0

            Me.setSQLSentence("pr_HC_Cp_InsertaHistoricoControlCateter", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("IdPregunta", SqlDbType.Int, idPregunta)
            Me.addInputParameter("Fecha_reg", SqlDbType.DateTime, Fecha_reg)
            Me.addInputParameter("Resultado", SqlDbType.VarChar, Resultado)
            Me.addInputParameter("IP", SqlDbType.VarChar, IP)
            Me.addInputParameter("obs", SqlDbType.VarChar, obs)

            Me.Exec()
            'ierror = Me.Parameters("o_lError").Value
            'MensajeError = Me.Parameters("strMensaje").Value

            Return MensajeError

        End Function
        ''WACHV, OBTENER LA INFORMACION INSERTADA POR IP
        Public Function ConsultarHistoricoEscalas(ByVal strIP As String) As DataTable

            Dim dt As New DataTable

            Me.setSQLSentence("pr_HC_Cp_historicosEscalas", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("strIP", SqlDbType.VarChar, strIP)
            Me.addOutputParameter("o_lError", SqlDbType.Int, 0)
            Me.addOutputParameter("strMensaje", SqlDbType.VarChar, 300)
            dt = Me.execDT()

            Return dt
        End Function
#End Region

    End Class
End Namespace

