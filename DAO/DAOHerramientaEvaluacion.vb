
Namespace Sophia.HistoriaClinica.DAO

#Region "DAO Herramientas de Evaluación"
    ''' -----------------------------------------------------------------------------
    ''' Project	 : HistoriClinica.DAO.DAOHerramientaEvaluacion
    ''' Class	 : Sophia.HistoriaClinica.DAO.DAOBasicasLocales
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Clase DAOBasicasLocales del namespace Sophia.HistoriaClinica.DAO.DAOHerramientaEvaluacion
    ''' que es la clase data de HistoriaClinica.DAO
    ''' y será usada desde este namespace para el acceso a los datos
    ''' se agrega de la application block Data.SqlHelper
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[rmzaldua]	15/12/2016	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------

    Public Class DAOHerramientaEvaluacion
        Inherits GPMData

        Public Function ConsultarPreguntasEscalas() As DataTable

            Dim dt As New DataTable

            Me.setSQLSentence("pr_HC_CpConsultaPreguntasEscalas", CommandType.StoredProcedure)
            Me.ClearParameters()
            dt = Me.execDT()

            Return dt
        End Function


        Public Function CargarCombosParametrica(ByVal intopcion As Integer) As DataTable
            Dim dt As New DataTable

            Me.setSQLSentence("pr_HC_CpConsultaParametricaescala", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("IdPregunta", SqlDbType.Int, intopcion)

            dt = Me.execDT
            Return dt
        End Function

        Public Function CargarCamposParametrica(ByVal intopcion As Integer) As DataTable
            Dim dt As New DataTable

            Me.setSQLSentence("pr_HC_CpConsultaParametricastodas", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("IdPregunta", SqlDbType.Int, intopcion)

            dt = Me.execDT
            Return dt
        End Function
        Public Function CargarParametricaRespuesta(ByVal intopcion As Integer) As DataTable
            Dim dt As New DataTable

            Me.setSQLSentence("pr_HC_CpConsultaParametricaRespEscala", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("IdRespuesta", SqlDbType.Int, intopcion)

            dt = Me.execDT
            Return dt
        End Function

        Public Function CargarDatosGraficasEscalas(ByVal strIP As String) As DataTable
            Dim dt As New DataTable

            Me.setSQLSentence("pr_HC_CpConsultaGraficaEscala", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("strIP", SqlDbType.VarChar, strIP)
            
            dt = Me.execDT
            Return dt
        End Function
        Public Function GuardarEscalas(ByVal strPrestador As String, ByVal strSucursal As String, ByVal strTip_Admision As String, _
                                       ByVal strAno_Adm As Integer, ByVal num_adm As Decimal, ByVal Pregunta As Integer, _
                                       ByVal parametrica As Integer, ByVal texto As String, ByVal puntaje As Integer, ByVal obs As String, _
                                       ByVal login As String, ByVal tabla As Integer) As String

            Dim MensajeError As String = ""
            Dim ierror As Long
            Dim intSecuencia As Integer = 0


            Me.setSQLSentence("pr_HC_Cp_grabaEscalas", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("intTabla", SqlDbType.Int, tabla)
            Me.addInputParameter("strcod_pre_sgs", SqlDbType.VarChar, strPrestador)
            Me.addInputParameter("strcod_sucur", SqlDbType.VarChar, strSucursal)
            Me.addInputParameter("strtip_admision", SqlDbType.VarChar, strTip_Admision)
            Me.addInputParameter("iano_adm", SqlDbType.Int, strAno_Adm)
            Me.addInputParameter("inum_adm", SqlDbType.Decimal, num_adm)
            Me.addInputParameter("iid_Pregunta", SqlDbType.Int, Pregunta)
            Me.addInputParameter("iid_parametrica", SqlDbType.Int, parametrica)
            Me.addInputParameter("strtexto", SqlDbType.VarChar, texto)
            Me.addInputParameter("ipuntaje", SqlDbType.Int, puntaje)
            Me.addInputParameter("strobs", SqlDbType.VarChar, obs)
            Me.addInputParameter("strlogin", SqlDbType.VarChar, login)
            Me.addOutputParameter("o_lError", SqlDbType.Int, 0)
            Me.addOutputParameter("strMensaje", SqlDbType.VarChar, 300)

            Me.Exec()
            ierror = Me.Parameters("o_lError").Value
            MensajeError = Me.Parameters("strMensaje").Value

            Return MensajeError

        End Function

        ''WACHV,INICIO,06OCT2017, GUARDAR OPCIONES DE HERRAMIENTAS DE EVALUACION
        Public Function GrabarOpcionesHerramientasEvaluacion(ByVal strCod_pre_sgs As String,
                                               ByVal strCod_sucur As String, ByVal strTip_Admision As String,
                                               ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double,
                                               ByVal strtip_doc As String, ByVal strnum_doc As String,
                                               ByVal strEvaluaciondeSintomas As String,
                                               ByVal strEvaluaciondeFuncionalidad As String,
                                               ByVal strOtrasHerramientasdeEvaluacion As String,
                                               ByVal strobs As String,
                                               ByVal strlogin As String) As Long

            Dim lError As Long

            Me.setSQLSentence("pr_HC_Cp_GrabaOpcionesHerramientasEvaluacion", CommandType.StoredProcedure)
            Me.ParametersCollection.Clear()
            Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, strCod_pre_sgs)
            Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, strCod_sucur)
            Me.addInputParameter("@tip_admision", SqlDbType.VarChar, strTip_Admision)
            Me.addInputParameter("@ano_adm", SqlDbType.Int, strAno_Adm)
            Me.addInputParameter("@num_adm", SqlDbType.Int, strNum_Adm)
            Me.addInputParameter("@tip_doc", SqlDbType.VarChar, strtip_doc)
            Me.addInputParameter("@num_doc", SqlDbType.VarChar, strnum_doc)
            Me.addInputParameter("@EvaluaciondeSintomas", SqlDbType.VarChar, strEvaluaciondeSintomas)
            Me.addInputParameter("@EvaluaciondeFuncionalidad", SqlDbType.VarChar, strEvaluaciondeFuncionalidad)
            Me.addInputParameter("@OtrasHerramientasdeEvaluacion", SqlDbType.VarChar, strOtrasHerramientasdeEvaluacion)
            Me.addInputParameter("@obs", SqlDbType.VarChar, strobs)
            Me.addInputParameter("@login", SqlDbType.VarChar, strlogin)
            Me.addInputParameter("@Error", SqlDbType.Int, lError)

            Me.Exec()
            lError = Me.Parameters("Error").Value

            Return lError
        End Function  ''WACHV,FIN,06OCT2017, GUARDAR OPCIONES DE HERRAMIENTAS DE EVALUACION

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

        Public Function ConsultarDiasHistorico(ByVal strNombre As String) As DataTable

            Dim dt As New DataTable

            Me.setSQLSentence("DB_Traergenparsophia", CommandType.StoredProcedure)
            Me.ClearParameters()            
            Me.addInputParameter("nombre_par", SqlDbType.VarChar, strNombre)

            dt = Me.execDT()

            Return dt
        End Function


        Public Function ConsultarPreguntas_x_Escala(ByVal strTabla As Integer) As DataTable

            Dim dt As New DataTable

            Me.setSQLSentence("pr_HC_CpConsultaPreguntaTablasSeccion", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("IdPregunta", SqlDbType.Int, DBNull.Value)
            Me.addInputParameter("IdTablaSeccion", SqlDbType.Int, strTabla)

            dt = Me.execDT()

            Return dt
        End Function

        Public Function InserRegHistoSophia(ByVal intTabla As Integer, ByVal strTipo_Doc As String, ByVal strNum_Doc As String, ByVal strIP As String) As String

            Dim MensajeError As String = ""
            Dim ierror As Long
            Dim intSecuencia As Integer = 0


            Me.setSQLSentence("pr_HC_Cp_grabaHistoEscalas", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("intTabla ", SqlDbType.Int, intTabla)
            Me.addInputParameter("strtipdoc", SqlDbType.VarChar, strTipo_Doc)
            Me.addInputParameter("strnumdoc", SqlDbType.VarChar, strNum_Doc)
            Me.addInputParameter("strIP", SqlDbType.VarChar, strIP)
            Me.addOutputParameter("o_lError", SqlDbType.Int, 0)
            Me.addOutputParameter("strMensaje", SqlDbType.VarChar, 300)

            Me.Exec()
            ierror = Me.Parameters("o_lError").Value
            MensajeError = Me.Parameters("strMensaje").Value

            Return MensajeError

        End Function
        Public Function InserRegHistoAvicena(ByVal idPregunta As Integer, ByVal Fecha_reg As DateTime, _
                                       ByVal Resultado As String, ByVal IP As String, ByVal obs As String) As String

            Dim MensajeError As String = ""
            Dim ierror As Long
            Dim intSecuencia As Integer = 0


            Me.setSQLSentence("pr_HC_CpInsertaHistoricoEscalas", CommandType.StoredProcedure)
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

        Public Function InserRegHistoGRaficaSophia(ByVal intTabla As Integer, ByVal strTipo_Doc As String, ByVal strNum_Doc As String, _
                                                   ByVal intIdPregunta As Integer, ByVal strIP As String) As String

            Dim MensajeError As String = ""
            Dim ierror As Long
            Dim intSecuencia As Integer = 0

            Me.setSQLSentence("pr_HC_Cp_grabarHistoGraficas", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("intTabla ", SqlDbType.Int, intTabla)
            Me.addInputParameter("strtipdoc", SqlDbType.VarChar, strTipo_Doc)
            Me.addInputParameter("strnumdoc", SqlDbType.VarChar, strNum_Doc)
            Me.addInputParameter("intidpregunta ", SqlDbType.Int, intIdPregunta)
            Me.addInputParameter("strIP", SqlDbType.VarChar, strIP)
            Me.addOutputParameter("o_lError", SqlDbType.Int, 0)
            Me.addOutputParameter("strMensaje", SqlDbType.VarChar, 300)

            Me.Exec()
            ierror = Me.Parameters("o_lError").Value
            MensajeError = Me.Parameters("strMensaje").Value

            Return MensajeError

        End Function

    End Class

#End Region

End Namespace