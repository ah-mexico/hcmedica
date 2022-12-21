Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Namespace Sophia.HistoriaClinica.DAO
    Public Class DAOAspectosEmocionales
        Inherits GPMData

        Public Function ConsultarAspectosEmocionales( _
        ByVal strCodPreSgs As String, _
        ByVal strCodSucur As String, _
        ByVal tip_admision As String, _
        ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double) As DataTable
            Dim dt As DataTable
            Me.ParametersCollection.Clear()
            Me.setSQLSentence("pr_HC_CpConsultaAspectosEmocionales", CommandType.StoredProcedure)
            Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, strCodPreSgs) ''strId)
            Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, strCodSucur)
            Me.addInputParameter("@tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("@ano_adm", SqlDbType.Int, strAno_Adm)
            Me.addInputParameter("@num_adm", SqlDbType.Int, strNum_Adm)
            dt = Me.execDT

            Return dt
        End Function

        Public Function CargarCombo() As DataTable
            Dim dt As New DataTable

            Me.setSQLSentence("pr_HC_CpConsultaNivelSufrimiento", CommandType.Text)
            dt = Me.execDT
            Return dt
        End Function


        Public Function GrabarAspectosEmocionales(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String, _
                                               ByVal strCod_sucur As String, ByVal strTip_Admision As String, _
                                               ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double, _
                                               ByVal strtip_doc As String, ByVal strnum_doc As String, _
                                               ByVal strExamen_mental As String, ByVal strExpectativas_y_creencias As String, _
                                               ByVal strAfrontamiento_de_la_enfermedad As String, ByVal strAfrontamiento_de_la_familia_a_la_situacion As String, _
                                               ByVal strProblemas_identificados As String, ByVal strPlan_de_intervencion As String, _
                                               ByVal intNivel_de_sufrimiento_existencial As Integer, _
                                               ByVal strEvaluacion_de_necesidades_espirituales As String, _
                                               ByVal strPlan_de_intervencion_E_E As String, _
                                               ByVal strIntervencion_de_duelo As String, _
                                               ByVal strDiagnostico_Z_63_4 As String, _
                                               ByVal strOtro_diagnostico_psicologico As String, _
                                               ByVal strobs As String, _
                                               ByVal strlogin As String) As Long

            Dim lError As Long

            Me.setSQLSentence("pr_Hc_ingresoAspectosEmocionales", CommandType.StoredProcedure)
            Me.ParametersCollection.Clear()
            Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, strCod_pre_sgs)
            Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, strCod_sucur)
            Me.addInputParameter("@tip_admision", SqlDbType.VarChar, strTip_Admision)
            Me.addInputParameter("@ano_adm", SqlDbType.Int, strAno_Adm)
            Me.addInputParameter("@num_adm", SqlDbType.Int, strNum_Adm)
            Me.addInputParameter("@tip_doc", SqlDbType.VarChar, strtip_doc)
            Me.addInputParameter("@num_doc", SqlDbType.VarChar, strnum_doc)
            Me.addInputParameter("@Examen_mental", SqlDbType.VarChar, strExamen_mental)
            Me.addInputParameter("@Expectativas_y_creencias", SqlDbType.VarChar, strExpectativas_y_creencias)
            Me.addInputParameter("@Afrontamiento_de_la_enfermedad", SqlDbType.VarChar, strAfrontamiento_de_la_enfermedad)
            Me.addInputParameter("@Afrontamiento_de_la_familia_a_la_situacion", SqlDbType.VarChar, strAfrontamiento_de_la_familia_a_la_situacion)
            Me.addInputParameter("@Problemas_identificados", SqlDbType.VarChar, strProblemas_identificados)
            Me.addInputParameter("@Plan_de_intervencion", SqlDbType.VarChar, strPlan_de_intervencion)
            Me.addInputParameter("@Nivel_de_sufrimiento_existencial", SqlDbType.Int, intNivel_de_sufrimiento_existencial)
            Me.addInputParameter("@Evaluacion_de_necesidades_espirituales", SqlDbType.VarChar, strEvaluacion_de_necesidades_espirituales)
            Me.addInputParameter("@Plan_de_intervencion_E_E", SqlDbType.VarChar, strPlan_de_intervencion_E_E)
            Me.addInputParameter("@Intervencion_de_duelo", SqlDbType.VarChar, strIntervencion_de_duelo)
            Me.addInputParameter("@Diagnostico_Z_63_4", SqlDbType.VarChar, strDiagnostico_Z_63_4)
            Me.addInputParameter("@Otro_diagnostico_psicologico", SqlDbType.VarChar, strOtro_diagnostico_psicologico)
            Me.addInputParameter("@obs", SqlDbType.VarChar, strobs)
            Me.addInputParameter("@login", SqlDbType.VarChar, strlogin)
            Me.addInputParameter("@Error", SqlDbType.Int, lError)

            Me.Exec()
            lError = Me.Parameters("Error").Value

            Return lError
        End Function


    End Class
End Namespace

