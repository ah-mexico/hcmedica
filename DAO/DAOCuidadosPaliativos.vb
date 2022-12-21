Imports System
Imports System.Collections.Generic
Imports System.Data.DataSetExtensions
Namespace Sophia.HistoriaClinica.DAO
    Public Class DAOCuidadosPaliativos
        Inherits GPMData
    
#Region "Valoracion de Ingreso"


        Public Function CargarCombosCP(ByVal intopcion As Integer, Optional ByVal strmedico As String = "", _
       Optional ByVal strPrestador As String = "", Optional ByVal strSucursal As String = "") As DataTable
            Dim dt As New DataTable


            Select Case intopcion
                Case 1
                    Me.setSQLSentence("HC_CpDicotomica", CommandType.StoredProcedure)
                    Me.ClearParameters()
                    Me.addInputParameter("descripcion", SqlDbType.VarChar, "Dicotomica")
                Case 2
                    Me.setSQLSentence("HC_CpIntervenciones", CommandType.StoredProcedure)
                    Me.ClearParameters()
                Case 3
                    Me.setSQLSentence("HC_CpMotEgreso", CommandType.StoredProcedure)
                    Me.ClearParameters()
                Case 4
                    Me.setSQLSentence("HC_CpLugarFallecimiento", CommandType.StoredProcedure)
                    Me.ClearParameters()
                Case 5
                    Me.setSQLSentence("HC_CpDiagnosticos", CommandType.StoredProcedure)
                    Me.ClearParameters()
                    Me.addInputParameter("Diagnostico", SqlDbType.VarChar, strmedico)
                Case 6
                    Me.setSQLSentence("HC_CpCausasAdministrativas", CommandType.StoredProcedure)
                    Me.ClearParameters()
            End Select

            dt = Me.execDT
            Return dt
        End Function

        ''' <summary>
        ''' Consulta la Ultima Respuesta de Valoracion de Ingreso registrados para paciente.
        ''' </summary>
        ''' <param name="IdPregunta"></param>
        ''' <param name="Respuesta"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ConsultarURValoraciondeIngreso(ByVal IdPregunta As Integer, ByVal Respuesta As String) As ValoraciondeIngreso

            Dim dtValoraciondeIngreso As New DataTable
            Dim oValoraciondeIngreso As New ValoraciondeIngreso

            Me.setSQLSentence("pr_HC_CpConsultaURValoraciondeIngreso", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("IdPregunta", SqlDbType.VarChar, IdPregunta)
            Me.addInputParameter("Respuesta", SqlDbType.VarChar, Respuesta)

            dtValoraciondeIngreso = Me.execDT

            For Each row As DataRow In dtValoraciondeIngreso.Rows
                oValoraciondeIngreso.CriteriodeIngreso = IIf(row.Item("CriteriodeIngreso").ToString() = "", 0, row.Item("CriteriodeIngreso"))
                oValoraciondeIngreso.Diagnostico_oncologico = IIf(row.Item("Diagnostico_oncologico").ToString() = "", 0, row.Item("Diagnostico_oncologico"))
                oValoraciondeIngreso.Diagnostico_no_oncologico = IIf(row.Item("Diagnostico_no_oncologico").ToString() = "", 0, row.Item("Diagnostico_no_oncologico"))
                oValoraciondeIngreso.CumpleCI = IIf(row.Item("CumpleCI").ToString() = "", 0, row.Item("CumpleCI"))
                oValoraciondeIngreso.Req_JP = IIf(row.Item("Req_JP").ToString() = "", "", row.Item("Req_JP"))
                oValoraciondeIngreso.ObsJuntaP = IIf(row.Item("ObsJuntaP").ToString() = "", "", row.Item("ObsJuntaP"))
                oValoraciondeIngreso.IngPrograma = IIf(row.Item("IngPrograma").ToString() = "", 0, row.Item("IngPrograma"))
            Next

            Return oValoraciondeIngreso

        End Function

        Public Function ConsultarDiagnostico_Criterio(ByVal intopcion As Integer, Optional ByVal strDiagnostico As String = "", _
     Optional ByVal strPrestador As String = "", Optional ByVal strSucursal As String = "") As Integer
            Dim result As Integer


            Me.setSQLSentence("HC_CpDiagnosticos_criterio", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("Diagnostico", SqlDbType.VarChar, strDiagnostico)
            Me.addOutputParameter("result", SqlDbType.Int, result)
            Me.Exec()

            result = Me.Parameters("result").Value

            Return result

        End Function

        Public Function ConsultarpermisosProgramas(ByVal strPrestador As String, ByVal strSucursal As String) As String
            Dim result As Integer


            Me.setSQLSentence("HC_CpConsultaAccesoProgramas", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("strCodPreSgs", SqlDbType.VarChar, strPrestador)
            Me.addInputParameter("strCodSucur", SqlDbType.VarChar, strSucursal)
            Me.addOutputParameter("result", SqlDbType.Int, result)
            Me.Exec()

            result = Me.Parameters("result").Value

            Return result

        End Function

        Public Function GuardarValoraciondeIngreso(ByVal oValoraciondeIngreso As ValoraciondeIngreso, ByVal strAVC As String) As Long

            Dim lError As Long
            Dim intSecuencia As Integer = 0

            Me.setSQLSentence("HC_CPGuardarValoracioneIngreso", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("strCodPreSgs", SqlDbType.VarChar, oValoraciondeIngreso.cod_pre_sgs)
            Me.addInputParameter("strCodSucur", SqlDbType.VarChar, oValoraciondeIngreso.cod_sucur)
            Me.addInputParameter("strTipAdm", SqlDbType.VarChar, oValoraciondeIngreso.tip_admision)
            Me.addInputParameter("iAnoAdm", SqlDbType.Int, oValoraciondeIngreso.ano_adm)
            Me.addInputParameter("dNumAdm", SqlDbType.Decimal, oValoraciondeIngreso.num_adm)
            Me.addInputParameter("tip_doc", SqlDbType.VarChar, oValoraciondeIngreso.tip_doc)
            ''Inicio llarias Se cambia variable de entero a varchar ya que generaba error
            '' CA 3052585 2019-02-21
            Me.addInputParameter("num_doc", SqlDbType.VarChar, oValoraciondeIngreso.Num_doc)
            '' Fin llarias
            Me.addInputParameter("CriteriodeIngreso", SqlDbType.VarChar, oValoraciondeIngreso.CriteriodeIngreso)
            Me.addInputParameter("Diagnostico_oncologico", SqlDbType.VarChar, oValoraciondeIngreso.Diagnostico_oncologico)
            Me.addInputParameter("Diagnostico_no_oncologico", SqlDbType.VarChar, oValoraciondeIngreso.Diagnostico_no_oncologico)
            Me.addInputParameter("CumpleCI", SqlDbType.VarChar, oValoraciondeIngreso.CumpleCI)
            Me.addInputParameter("Req_JP", SqlDbType.VarChar, oValoraciondeIngreso.Req_JP)
            Me.addInputParameter("ObsJuntaP", SqlDbType.VarChar, oValoraciondeIngreso.ObsJuntaP)
            Me.addInputParameter("IngPrograma", SqlDbType.VarChar, oValoraciondeIngreso.IngPrograma)
            Me.addInputParameter("obs", SqlDbType.VarChar, oValoraciondeIngreso.obs)
            Me.addInputParameter("login", SqlDbType.VarChar, oValoraciondeIngreso.login)
            Me.addInputParameter("esAVC", SqlDbType.VarChar, strAVC) 'CCGUTIEREZ. 02/07/2020. CA_6353881 
            Me.addInputParameter("FecIngreAVC", SqlDbType.VarChar, IIf(strAVC = "S", oValoraciondeIngreso.FecIngProgAV, "")) 'CCGUTIEREZ. 02/07/2020. CA_6353881
            Me.addOutputParameter("Error", SqlDbType.Int, lError)
            Me.Exec()

            lError = Me.Parameters("Error").Value

            Return lError

        End Function

        Public Function ConsultarConsultarEstadoPaliativo(ByVal tip_doc As String, ByVal num_doc As String) As DataTable
            Dim dt As New DataTable

            Me.setSQLSentence("HC_ConsultarEstadoPaliativo", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("tip_doc", SqlDbType.VarChar, tip_doc)
            Me.addInputParameter("num_doc", SqlDbType.VarChar, num_doc)
            dt = Me.execDT
            Return dt
        End Function


#End Region

#Region "Egreso del Programa"

        ''' <summary>
        ''' Consulta la Ultima Respuesta de Aspectos sociales registrados para paciente.
        ''' </summary>
        ''' <param name="IdPregunta"></param>
        ''' <param name="Respuesta"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ConsultarUREgresoPrograma(ByVal IdPregunta As Integer, ByVal Respuesta As String) As EgresoCP
            Dim dtEgresoCP As New DataTable
            Dim oEgresoCP As New EgresoCP

            Me.setSQLSentence("pr_HC_CpConsultaUREgresoPrograma", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("IdPregunta", SqlDbType.VarChar, IdPregunta)
            Me.addInputParameter("Respuesta", SqlDbType.VarChar, Respuesta)

            dtEgresoCP = Me.execDT

            For Each row As DataRow In dtEgresoCP.Rows

                oEgresoCP.Fecha_de_egreso = IIf(row.Item("FechaEgreso").ToString() = "", 0, row.Item("FechaEgreso"))
                oEgresoCP.EstanciadePrograma = IIf(row.Item("EstanciaPrograma").ToString() = "", 0, row.Item("EstanciaPrograma"))
                oEgresoCP.MotivoEgreso = IIf(row.Item("MotivoEgreso").ToString() = "", 0, row.Item("MotivoEgreso"))
                oEgresoCP.LugarFallece = IIf(row.Item("DondeFallece").ToString() = "", 0, row.Item("DondeFallece"))
                oEgresoCP.HospitalfueradeRed = IIf(row.Item("EnqueHospitalfueradelared").ToString() = "", "", row.Item("EnqueHospitalfueradelared"))
                oEgresoCP.IntervencionSicologicapostFallecimiento = IIf(row.Item("IntervencionPsicologicaPostFallecimiento").ToString() = "", "", row.Item("IntervencionPsicologicaPostFallecimiento"))
                oEgresoCP.ExpliqueRazon = IIf(row.Item("Expliquelarazon").ToString() = "", 0, row.Item("Expliquelarazon"))
            Next

            Return oEgresoCP

        End Function


#End Region

#Region "Aspectos Emocionales"

        ''' <summary>
        ''' Consulta la Ultima Respuesta de Aspectos sociales registrados para paciente.
        ''' </summary>
        ''' <param name="IdPregunta"></param>
        ''' <param name="Respuesta"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ConsultarURAspectosEmocionales(ByVal IdPregunta As Integer, ByVal Respuesta As String) As AspectosEmocionales
            Dim dtAspectosEmocionales As New DataTable
            Dim oAspectosEmocionales As New AspectosEmocionales

            Me.setSQLSentence("HC_CpConsultaURAspectosEmocionales", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("IdPregunta", SqlDbType.VarChar, IdPregunta)
            Me.addInputParameter("Respuesta", SqlDbType.VarChar, Respuesta)

            dtAspectosEmocionales = Me.execDT

            For Each row As DataRow In dtAspectosEmocionales.Rows

                oAspectosEmocionales.ExamenMental = IIf(row.Item("Examen_mental").ToString() = "", 0, row.Item("Examen_mental"))
                oAspectosEmocionales.Expectativasycreencias = IIf(row.Item("Expectativas_y_creencias").ToString() = "", 0, row.Item("Expectativas_y_creencias"))
                oAspectosEmocionales.Afrontamientodelaenfermedad = IIf(row.Item("Afrontamiento_de_la_enfermedad").ToString() = "", 0, row.Item("Afrontamiento_de_la_enfermedad"))
                oAspectosEmocionales.Afrontamientodelafamiliaalasituacion = IIf(row.Item("Afrontamiento_de_la_familia_a_la_situacion").ToString() = "", 0, row.Item("Afrontamiento_de_la_familia_a_la_situacion"))
                oAspectosEmocionales.Problemasidentificados = IIf(row.Item("Problemas_identificados").ToString() = "", "", row.Item("Problemas_identificados"))
                oAspectosEmocionales.Plandeintervencion = IIf(row.Item("Plan_de_intervencion").ToString() = "", "", row.Item("Plan_de_intervencion"))
                oAspectosEmocionales.Niveldesufrimientoexistencial = IIf(row.Item("Nivel_de_sufrimiento_existencial").ToString() = "", 0, row.Item("Nivel_de_sufrimiento_existencial"))
                oAspectosEmocionales.Evaluaciondenecesidadesespirituales = IIf(row.Item("Evaluacion_de_necesidades_espirituales").ToString() = "", 0, row.Item("Evaluacion_de_necesidades_espirituales"))
                oAspectosEmocionales.Plandeintervencion_E_E = IIf(row.Item("Plan_de_intervencion_E_E").ToString() = "", 0, row.Item("Plan_de_intervencion_E_E"))
                oAspectosEmocionales.Intervenciondeduelo = IIf(row.Item("Intervencion_de_duelo").ToString() = "", 0, row.Item("Intervencion_de_duelo"))
                oAspectosEmocionales.DiagnosticoZ63_4 = IIf(row.Item("Diagnostico_Z_63_4").ToString() = "", 0, row.Item("Diagnostico_Z_63_4"))
                oAspectosEmocionales.Otrodiagnosticopsicologico = IIf(row.Item("Otro_diagnostico_psicologico").ToString() = "", 0, row.Item("Otro_diagnostico_psicologico"))

            Next

            Return oAspectosEmocionales

        End Function


#End Region

#Region "CAM"

        Public Const TipoServicio As String = "CP"
        Public Const MetodoServicio As String = "ultimasrespuestas"

#Region "AspectosSociales"
        ''' <summary>
        ''' Obtiene la información de los combos de los aspectos sociales de cuidados paliativos
        ''' </summary>
        ''' <param name="intopcion"></param>
        ''' <param name="ID"></param>
        ''' <param name="Descripcion"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function CargarCombosCPAspectosSociales(ByVal intopcion As Integer, Optional ByVal ID As String = "", Optional ByVal Descripcion As String = "") As DataTable
            Try

                Dim dt As New DataTable

                Select Case intopcion
                    Case 1 'Convivencia
                        Me.setSQLSentence("pr_HC_CpConsultaConvivencia", CommandType.StoredProcedure)
                        Me.ClearParameters()
                    Case 2 'Tipo de Vivienda"
                        Me.setSQLSentence("pr_HC_CpConsultaTipoVivienda", CommandType.StoredProcedure)
                        Me.ClearParameters()
                    Case 3 'Tipo de Tenencia
                        Me.setSQLSentence("pr_HC_CpConsultaTenenciaVivienda", CommandType.StoredProcedure)
                        Me.ClearParameters()
                    Case 4 'Estrato Social
                        Me.setSQLSentence("pr_HC_CpConsultaEstratoSocial", CommandType.StoredProcedure)
                        Me.ClearParameters()
                    Case 5 'NIvel Educativo
                        Me.setSQLSentence("pr_HC_CpConsultaNivelEscolaridad", CommandType.StoredProcedure)
                        Me.ClearParameters()
                    Case 6 'Ocupación
                        Me.setSQLSentence("pr_HC_CpConsultaOcupacion", CommandType.StoredProcedure)
                        Me.ClearParameters()
                        Me.addInputParameter("ocupacion", SqlDbType.VarChar, DBNull.Value)
                        Me.addInputParameter("descripcion", SqlDbType.VarChar, DBNull.Value)
                    Case 7 'Nivel de Ingresos
                        Me.setSQLSentence("pr_HC_CpConsultaNivelIngresos", CommandType.StoredProcedure)
                        Me.ClearParameters()
                    Case 8 'Tipo de Familia
                        Me.setSQLSentence("pr_HC_CpConsultaTipoFamilia", CommandType.StoredProcedure)
                        Me.ClearParameters()
                    Case 9 'Parentesco
                        Me.setSQLSentence("pr_HC_CpConsultaParentesco", CommandType.StoredProcedure)
                        Me.ClearParameters()
                    Case 10 'Tipo Documento
                        Me.setSQLSentence("pr_HC_CpConsultaTipoDocumento", CommandType.StoredProcedure)
                        Me.ClearParameters()
                    Case 11 'Estado civil
                        Me.setSQLSentence("pr_HC_CpConsultaEstadoCivil", CommandType.StoredProcedure)
                        Me.ClearParameters()
                    Case 12 'Condicion de la Madre
                        Me.setSQLSentence("pr_HC_CpConsultaCondicionMadre", CommandType.StoredProcedure)
                        Me.ClearParameters()
                    Case 13 'Condicion del Padre
                        Me.setSQLSentence("pr_HC_CpConsultaCondicionPadre", CommandType.StoredProcedure)
                        Me.ClearParameters()


                End Select

                dt = Me.execDT
                Return dt

            Catch ex As Exception
                Throw (ex)
            End Try
        End Function

        ''' <summary>
        ''' Almacena los familiares del paciente
        ''' </summary>
        ''' <param name="oComposicionFamiliar"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GuardarFamiliar(ByVal oComposicionFamiliar As ComposicionFamiliar) As String

            Dim MensajeError As String = ""
            Dim intSecuencia As Integer = 0


            Me.setSQLSentence("pr_HC_CpInsertaComposicionFamiliar", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("IdPariente", SqlDbType.Int, oComposicionFamiliar.IdPariente)
            Me.addInputParameter("tip_doc", SqlDbType.VarChar, oComposicionFamiliar.tip_doc)
            Me.addInputParameter("Num_doc", SqlDbType.VarChar, oComposicionFamiliar.Num_doc)
            Me.addInputParameter("ParentescoDelIntegranteDeLaFamilia", SqlDbType.VarChar, oComposicionFamiliar.ParentescoDelIntegranteDeLaFamilia)
            Me.addInputParameter("NombreDelIntegranteDeLaFamilia", SqlDbType.VarChar, oComposicionFamiliar.NombreDelIntegranteDeLaFamilia)
            Me.addInputParameter("EdadDelIntegranteDeLaFamilia", SqlDbType.Int, oComposicionFamiliar.EdadDelIntegranteDeLaFamilia)
            Me.addInputParameter("OcupacionDelIntegranteDeLaFamilia ", SqlDbType.VarChar, oComposicionFamiliar.OcupacionDelIntegranteDeLaFamilia)
            'Me.addInputParameter("fec_con", SqlDbType.DateTime, oComposicionFamiliar.fec_con)
            Me.addInputParameter("obs", SqlDbType.VarChar, IIf(oComposicionFamiliar.obs = "", DBNull.Value, oComposicionFamiliar.obs))
            Me.addInputParameter("login", SqlDbType.VarChar, IIf(oComposicionFamiliar.login = "", DBNull.Value, oComposicionFamiliar.login))
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, oComposicionFamiliar.cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, oComposicionFamiliar.cod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, oComposicionFamiliar.tip_admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, oComposicionFamiliar.ano_adm)
            Me.addInputParameter("num_adm", SqlDbType.Decimal, oComposicionFamiliar.num_adm)
            Me.addOutputParameter("Mensaje", SqlDbType.VarChar, 500)

            Me.Exec()

            MensajeError = Me.Parameters("Mensaje").Value

            Return MensajeError

        End Function

        ''' <summary>
        ''' Almacena los Aspectos Sociales del Programa de Cuidados Paliativos.
        ''' </summary>
        ''' <param name="oAspectosSociales"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GuardarAspectoSocial(ByVal oAspectosSociales As AspectosSociales) As String

            Dim MensajeError As String = ""
            Dim intSecuencia As Integer = 0


            Me.setSQLSentence("pr_HC_CpInsertaAspectosSociales", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, oAspectosSociales.cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, oAspectosSociales.cod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, oAspectosSociales.tip_admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, oAspectosSociales.ano_adm)
            Me.addInputParameter("num_adm", SqlDbType.Decimal, oAspectosSociales.num_adm)
            Me.addInputParameter("tip_doc", SqlDbType.VarChar, oAspectosSociales.tip_doc)
            Me.addInputParameter("Num_doc", SqlDbType.VarChar, oAspectosSociales.Num_doc)
            Me.addInputParameter("ConQuienVive", SqlDbType.Int, oAspectosSociales.ConQuienVive)
            Me.addInputParameter("TipoDeVivienda", SqlDbType.Int, oAspectosSociales.TipoDeVivienda)
            Me.addInputParameter("TenenciaDeLaVivienda", SqlDbType.Int, oAspectosSociales.TenenciaDeLaVivienda)
            Me.addInputParameter("EstratoDeLaVivienda", SqlDbType.Int, oAspectosSociales.EstratoDeLaVivienda)
            Me.addInputParameter("NivelEscolaridad", SqlDbType.VarChar, IIf(oAspectosSociales.NivelEscolaridad = "", DBNull.Value, oAspectosSociales.NivelEscolaridad))
            Me.addInputParameter("Ocupacion", SqlDbType.VarChar, IIf(oAspectosSociales.Ocupacion = "", DBNull.Value, oAspectosSociales.Ocupacion))
            Me.addInputParameter("CuentaConUnTrabajoEstable ", SqlDbType.Int, oAspectosSociales.CuentaConUnTrabajoEstable)
            Me.addInputParameter("Ingresos ", SqlDbType.Int, oAspectosSociales.Ingresos)
            Me.addInputParameter("CondicionDelPadre ", SqlDbType.Int, oAspectosSociales.CondicionDelPadre)
            Me.addInputParameter("CondicionDeLaMadre ", SqlDbType.Int, oAspectosSociales.CondicionDeLaMadre)
            Me.addInputParameter("NumeroDeHermanos ", SqlDbType.Int, oAspectosSociales.NumeroDeHermanos)
            Me.addInputParameter("Lugar ", SqlDbType.Int, oAspectosSociales.Lugar)
            Me.addInputParameter("TieneHijos ", SqlDbType.Int, oAspectosSociales.TieneHijos)
            Me.addInputParameter("TipoDeFamilia ", SqlDbType.Int, oAspectosSociales.TipoDeFamilia)
            Me.addInputParameter("NumeroDeIntegrantesDeLaFamilia ", SqlDbType.Int, oAspectosSociales.NumeroDeIntegrantesDeLaFamilia)
            Me.addInputParameter("PersonasACargo ", SqlDbType.Int, oAspectosSociales.PersonasACargo)
            Me.addInputParameter("NombreDelCuidador", SqlDbType.VarChar, IIf(oAspectosSociales.NombreDelCuidador = "", DBNull.Value, oAspectosSociales.NombreDelCuidador))
            Me.addInputParameter("TipoDeDocumentoDelCuidador", SqlDbType.VarChar, IIf(oAspectosSociales.TipoDeDocumentoDelCuidador = "", DBNull.Value, oAspectosSociales.TipoDeDocumentoDelCuidador))
            Me.addInputParameter("NumeroDeDocumentoDelCuidador", SqlDbType.VarChar, IIf(oAspectosSociales.NumeroDeDocumentoDelCuidador = "", DBNull.Value, oAspectosSociales.NumeroDeDocumentoDelCuidador))
            Me.addInputParameter("ParentescoDelCuidador", SqlDbType.VarChar, IIf(oAspectosSociales.ParentescoDelCuidador = "", DBNull.Value, oAspectosSociales.ParentescoDelCuidador))
            Me.addInputParameter("DireccionDelCuidador", SqlDbType.VarChar, IIf(oAspectosSociales.DireccionDelCuidador = "", DBNull.Value, oAspectosSociales.DireccionDelCuidador))
            Me.addInputParameter("EscolaridadDelCuidador", SqlDbType.VarChar, IIf(oAspectosSociales.EscolaridadDelCuidador = "", DBNull.Value, oAspectosSociales.EscolaridadDelCuidador))
            Me.addInputParameter("OcupacionDelCuidador", SqlDbType.VarChar, IIf(oAspectosSociales.OcupacionDelCuidador = "", DBNull.Value, oAspectosSociales.OcupacionDelCuidador))
            Me.addInputParameter("EstadoCivilDelCuidador", SqlDbType.VarChar, IIf(oAspectosSociales.EstadoCivilDelCuidador = "", DBNull.Value, oAspectosSociales.EstadoCivilDelCuidador))
            Me.addInputParameter("ProblemasIdentificados", SqlDbType.VarChar, IIf(oAspectosSociales.ProblemasIdentificados = "", DBNull.Value, oAspectosSociales.ProblemasIdentificados))
            Me.addInputParameter("PlanDeIntervencion", SqlDbType.VarChar, IIf(oAspectosSociales.PlanDeIntervencion = "", DBNull.Value, oAspectosSociales.PlanDeIntervencion))
            Me.addInputParameter("obs", SqlDbType.VarChar, oAspectosSociales.obs)
            Me.addInputParameter("login", SqlDbType.VarChar, oAspectosSociales.login)
            Me.addOutputParameter("Mensaje", SqlDbType.VarChar, 500)

            Me.Exec()

            MensajeError = Me.Parameters("Mensaje").Value

            Return MensajeError

        End Function

        ''' <summary>
        ''' Consulta los familiares registrados del paciente.
        ''' </summary>
        ''' <param name="oComposicionFamiliar">Familiar con los criterios de búsqueda</param>
        ''' <returns>Listado de familiares del paciente</returns>
        ''' <remarks></remarks>
        Public Function ConsultarFamiliar(ByVal oComposicionFamiliar As ComposicionFamiliar) As List(Of ComposicionFamiliar)
            Dim dtFamiliares As New DataTable
            Dim lstFamiliares As New List(Of ComposicionFamiliar)


            Me.setSQLSentence("pr_HC_CpConsultaComposicionFamiliar", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("tip_doc", SqlDbType.VarChar, IIf(oComposicionFamiliar.tip_doc = "", DBNull.Value, oComposicionFamiliar.tip_doc))
            Me.addInputParameter("Num_doc", SqlDbType.VarChar, IIf(oComposicionFamiliar.Num_doc = "", DBNull.Value, oComposicionFamiliar.Num_doc))
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, IIf(oComposicionFamiliar.cod_pre_sgs = "", DBNull.Value, oComposicionFamiliar.cod_pre_sgs))
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, IIf(oComposicionFamiliar.cod_sucur = "", DBNull.Value, oComposicionFamiliar.cod_sucur))
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, IIf(oComposicionFamiliar.tip_admision = "", DBNull.Value, oComposicionFamiliar.tip_admision))
            Me.addInputParameter("ano_adm", SqlDbType.Int, IIf(oComposicionFamiliar.ano_adm = 0, DBNull.Value, oComposicionFamiliar.ano_adm))
            Me.addInputParameter("num_adm", SqlDbType.Decimal, IIf(oComposicionFamiliar.num_adm = 0, DBNull.Value, oComposicionFamiliar.num_adm))

            dtFamiliares = Me.execDT

            For Each row As DataRow In dtFamiliares.Rows
                Dim oFamiliar As New ComposicionFamiliar()

                oFamiliar.IdPariente = row.Item("IdPariente")
                oFamiliar.tip_doc = row.Item("tip_doc")
                oFamiliar.Num_doc = row.Item("Num_doc")

                oFamiliar.cod_pre_sgs = row.Item("cod_pre_sgs")
                oFamiliar.cod_sucur = row.Item("cod_sucur")
                oFamiliar.tip_admision = row.Item("tip_admision")

                oFamiliar.ano_adm = row.Item("ano_adm")
                oFamiliar.num_adm = row.Item("num_adm")
                oFamiliar.NombreDelIntegranteDeLaFamilia = IIf(row.Item("NombreDelIntegranteDeLaFamilia").ToString() = "", "", row.Item("NombreDelIntegranteDeLaFamilia"))

                oFamiliar.EdadDelIntegranteDeLaFamilia = IIf(row.Item("EdadDelIntegranteDeLaFamilia").ToString() = "", 0, row.Item("EdadDelIntegranteDeLaFamilia"))
                oFamiliar.ParentescoDelIntegranteDeLaFamilia = IIf(row.Item("ParentescoDelIntegranteDeLaFamilia").ToString() = "", "", row.Item("ParentescoDelIntegranteDeLaFamilia"))
                oFamiliar.dscParentescoDelIntegranteDeLaFamilia = IIf(row.Item("dscParentescoDelIntegranteDeLaFamilia").ToString() = "", "", row.Item("dscParentescoDelIntegranteDeLaFamilia"))

                oFamiliar.OcupacionDelIntegranteDeLaFamilia = IIf(row.Item("OcupacionDelIntegranteDeLaFamilia").ToString() = "", 0, row.Item("OcupacionDelIntegranteDeLaFamilia"))
                oFamiliar.dscOcupacionDelIntegranteDeLaFamilia = IIf(row.Item("dscOcupacionDelIntegranteDeLaFamilia").ToString() = "", "", row.Item("dscOcupacionDelIntegranteDeLaFamilia"))

                lstFamiliares.Add(oFamiliar)

            Next

            Return lstFamiliares

        End Function

        ''' <summary>
        ''' Consulta los familiares registrados del paciente.
        ''' </summary>
        ''' <param name="oComposicionFamiliar">Familiar con los criterios de búsqueda</param>
        ''' <returns>Listado de familiares del paciente</returns>
        ''' <remarks></remarks>
        Public Function ConsultarFamiliarDt(ByVal oComposicionFamiliar As ComposicionFamiliar) As DataTable
            Dim dtFamiliares As New DataTable
            Dim lstFamiliares As New List(Of ComposicionFamiliar)


            Me.setSQLSentence("pr_HC_CpConsultaComposicionFamiliar", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("tip_doc", SqlDbType.VarChar, IIf(oComposicionFamiliar.tip_doc = "", DBNull.Value, oComposicionFamiliar.tip_doc))
            Me.addInputParameter("Num_doc", SqlDbType.VarChar, IIf(oComposicionFamiliar.Num_doc = "", DBNull.Value, oComposicionFamiliar.Num_doc))
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, IIf(oComposicionFamiliar.cod_pre_sgs = "", DBNull.Value, oComposicionFamiliar.cod_pre_sgs))
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, IIf(oComposicionFamiliar.cod_sucur = "", DBNull.Value, oComposicionFamiliar.cod_sucur))
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, IIf(oComposicionFamiliar.tip_admision = "", DBNull.Value, oComposicionFamiliar.tip_admision))
            Me.addInputParameter("ano_adm", SqlDbType.Int, IIf(oComposicionFamiliar.ano_adm = 0, DBNull.Value, oComposicionFamiliar.ano_adm))
            Me.addInputParameter("num_adm", SqlDbType.Decimal, IIf(oComposicionFamiliar.num_adm = 0, DBNull.Value, oComposicionFamiliar.num_adm))

            dtFamiliares = Me.execDT

            'For Each row As DataRow In dtFamiliares.Rows
            '    Dim oFamiliar As New ComposicionFamiliar()

            '    oFamiliar.IdPariente = row.Item("IdPariente")
            '    oFamiliar.tip_doc = row.Item("tip_doc")
            '    oFamiliar.Num_doc = row.Item("Num_doc")

            '    oFamiliar.cod_pre_sgs = row.Item("cod_pre_sgs")
            '    oFamiliar.cod_sucur = row.Item("cod_sucur")
            '    oFamiliar.tip_admision = row.Item("tip_admision")

            '    oFamiliar.ano_adm = row.Item("ano_adm")
            '    oFamiliar.num_adm = row.Item("num_adm")
            '    oFamiliar.NombreDelIntegranteDeLaFamilia = IIf(row.Item("NombreDelIntegranteDeLaFamilia").ToString() = "", "", row.Item("NombreDelIntegranteDeLaFamilia"))

            '    oFamiliar.EdadDelIntegranteDeLaFamilia = IIf(row.Item("EdadDelIntegranteDeLaFamilia").ToString() = "", 0, row.Item("EdadDelIntegranteDeLaFamilia"))
            '    oFamiliar.ParentescoDelIntegranteDeLaFamilia = IIf(row.Item("ParentescoDelIntegranteDeLaFamilia").ToString() = "", "", row.Item("ParentescoDelIntegranteDeLaFamilia"))
            '    oFamiliar.dscParentescoDelIntegranteDeLaFamilia = IIf(row.Item("dscParentescoDelIntegranteDeLaFamilia").ToString() = "", "", row.Item("dscParentescoDelIntegranteDeLaFamilia"))

            '    oFamiliar.OcupacionDelIntegranteDeLaFamilia = IIf(row.Item("OcupacionDelIntegranteDeLaFamilia").ToString() = "", 0, row.Item("OcupacionDelIntegranteDeLaFamilia"))
            '    oFamiliar.dscOcupacionDelIntegranteDeLaFamilia = IIf(row.Item("dscOcupacionDelIntegranteDeLaFamilia").ToString() = "", "", row.Item("dscOcupacionDelIntegranteDeLaFamilia"))

            '    lstFamiliares.Add(oFamiliar)

            'Next

            Return dtFamiliares

        End Function

        ''' <summary>
        ''' Consulta la Ultima Respuesta de Aspectos sociales registrados para paciente.
        ''' </summary>
        ''' <param name="id_Pregunta">Id de la Pregunta</param>
        ''' <param name="Respuesta">Respuesta obtenida por el servicio.</param>
        ''' <returns>Aspecto social con la respuesta del servicio</returns>
        ''' <remarks></remarks>
        Public Function ConsultarURAspectoSocial(ByVal id_Pregunta As Integer, ByVal Respuesta As String) As AspectosSociales
            Dim dtAspectosSociales As New DataTable
            Dim oAspectosSociales As New AspectosSociales


            Me.setSQLSentence("pr_HC_CpConsultaURAspectosSociales", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("id_Pregunta", SqlDbType.VarChar, id_Pregunta)
            Me.addInputParameter("Respuesta", SqlDbType.VarChar, Respuesta)

            dtAspectosSociales = Me.execDT

            For Each row As DataRow In dtAspectosSociales.Rows

                oAspectosSociales.ConQuienVive = IIf(row.Item("ConQuienVive").ToString() = "", 0, row.Item("ConQuienVive"))
                oAspectosSociales.TipoDeVivienda = IIf(row.Item("TipoDeVivienda").ToString() = "", 0, row.Item("TipoDeVivienda"))
                oAspectosSociales.TenenciaDeLaVivienda = IIf(row.Item("TenenciaDeLaVivienda").ToString() = "", 0, row.Item("TenenciaDeLaVivienda"))
                oAspectosSociales.EstratoDeLaVivienda = IIf(row.Item("EstratoDeLaVivienda").ToString() = "", 0, row.Item("EstratoDeLaVivienda"))
                oAspectosSociales.NivelEscolaridad = IIf(row.Item("NivelEscolaridad").ToString() = "", "", row.Item("NivelEscolaridad"))
                oAspectosSociales.Ocupacion = IIf(row.Item("Ocupacion").ToString() = "", "", row.Item("Ocupacion"))
                oAspectosSociales.CuentaConUnTrabajoEstable = IIf(row.Item("CuentaConUnTrabajoEstable").ToString() = "", 0, row.Item("CuentaConUnTrabajoEstable"))
                oAspectosSociales.Ingresos = IIf(row.Item("Ingresos").ToString() = "", 0, row.Item("Ingresos"))
                oAspectosSociales.CondicionDelPadre = IIf(row.Item("CondicionDelPadre").ToString() = "", 0, row.Item("CondicionDelPadre"))
                oAspectosSociales.CondicionDeLaMadre = IIf(row.Item("CondicionDeLaMadre").ToString() = "", 0, row.Item("CondicionDeLaMadre"))
                oAspectosSociales.NumeroDeHermanos = IIf(row.Item("NumeroDeHermanos").ToString() = "", 0, row.Item("NumeroDeHermanos"))
                oAspectosSociales.Lugar = IIf(row.Item("Lugar").ToString() = "", 0, row.Item("Lugar"))
                oAspectosSociales.TieneHijos = IIf(row.Item("TieneHijos").ToString() = "", 0, row.Item("TieneHijos"))
                oAspectosSociales.TipoDeFamilia = IIf(row.Item("TipoDeFamilia").ToString() = "", 0, row.Item("TipoDeFamilia"))
                oAspectosSociales.NumeroDeIntegrantesDeLaFamilia = IIf(row.Item("NumeroDeIntegrantesDeLaFamilia").ToString() = "", 0, row.Item("NumeroDeIntegrantesDeLaFamilia"))
                oAspectosSociales.PersonasACargo = IIf(row.Item("PersonasACargo").ToString() = "", 0, row.Item("PersonasACargo"))
                oAspectosSociales.NombreDelCuidador = IIf(row.Item("NombreDelCuidador").ToString() = "", "", row.Item("NombreDelCuidador"))
                oAspectosSociales.TipoDeDocumentoDelCuidador = IIf(row.Item("TipoDeDocumentoDelCuidador").ToString() = "", "", row.Item("TipoDeDocumentoDelCuidador"))
                oAspectosSociales.NumeroDeDocumentoDelCuidador = IIf(row.Item("NumeroDeDocumentoDelCuidador").ToString() = "", 0, row.Item("NumeroDeDocumentoDelCuidador"))
                oAspectosSociales.ParentescoDelCuidador = IIf(row.Item("ParentescoDelCuidador").ToString() = "", "", row.Item("ParentescoDelCuidador"))
                oAspectosSociales.DireccionDelCuidador = IIf(row.Item("DireccionDelCuidador").ToString() = "", "", row.Item("DireccionDelCuidador"))
                oAspectosSociales.EscolaridadDelCuidador = IIf(row.Item("EscolaridadDelCuidador").ToString() = "", 0, row.Item("EscolaridadDelCuidador"))
                oAspectosSociales.OcupacionDelCuidador = IIf(row.Item("OcupacionDelCuidador").ToString() = "", 0, row.Item("OcupacionDelCuidador"))
                oAspectosSociales.EstadoCivilDelCuidador = IIf(row.Item("EstadoCivilDelCuidador").ToString() = "", "", row.Item("EstadoCivilDelCuidador"))
                oAspectosSociales.ProblemasIdentificados = IIf(row.Item("ProblemasIdentificados").ToString() = "", "", row.Item("ProblemasIdentificados"))
                oAspectosSociales.PlanDeIntervencion = IIf(row.Item("PlanDeIntervencion").ToString() = "", "", row.Item("PlanDeIntervencion"))

            Next

            Return oAspectosSociales

        End Function

        ''' <summary>
        ''' Elimina un familiar del paciente
        ''' </summary>
        ''' <param name="oComposicionFamiliar"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function EliminarFamiliar(ByVal oFamiliar As ComposicionFamiliar) As String

            Dim MensajeError As String = ""
            Dim intSecuencia As Integer = 0


            Me.setSQLSentence("pr_HC_CpEliminaComposicionFamiliar", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("IdPariente", SqlDbType.Int, oFamiliar.IdPariente)
            Me.addInputParameter("tip_doc", SqlDbType.VarChar, oFamiliar.tip_doc)
            Me.addInputParameter("Num_doc", SqlDbType.VarChar, oFamiliar.Num_doc)
            Me.addOutputParameter("Mensaje", SqlDbType.VarChar, 500)

            Me.Exec()

            MensajeError = Me.Parameters("Mensaje").Value

            Return MensajeError

        End Function

#End Region

#Region "CriterioIngreso"

        ''' <summary>
        ''' Almacena los Criterios de Ingreso del Programa de Cuidados Paliativos.
        ''' </summary>
        ''' <param name="oCriterioIngreso">Criterio de Ingreso a ser almacenado</param> 
        ''' <returns>Resultado de la insesrción</returns>
        ''' <remarks></remarks>
        Public Function GuardarCriterioIngreso(ByVal oCriterioIngreso As CriterioIngreso) As String

            Dim MensajeError As String = ""
            Dim intSecuencia As Integer = 0


            Me.setSQLSentence("pr_HC_CpInsertaCriterioIngreso", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, oCriterioIngreso.cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, oCriterioIngreso.cod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, oCriterioIngreso.tip_admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, oCriterioIngreso.ano_adm)
            Me.addInputParameter("num_adm", SqlDbType.Decimal, oCriterioIngreso.num_adm)
            Me.addInputParameter("tip_doc", SqlDbType.VarChar, oCriterioIngreso.tip_doc)
            Me.addInputParameter("Num_doc", SqlDbType.VarChar, oCriterioIngreso.Num_doc)
            Me.addInputParameter("Oncologica_Diagnostico", SqlDbType.Int, oCriterioIngreso.Oncologica_Diagnostico)
            Me.addInputParameter("Oncologica_Deterioro", SqlDbType.Int, oCriterioIngreso.Oncologica_Deterioro)
            Me.addInputParameter("Oncologica_Sintomas", SqlDbType.Int, oCriterioIngreso.Oncologica_Sintomas)
            Me.addInputParameter("Oncologica_Cumple", SqlDbType.Int, oCriterioIngreso.Oncologica_Cumple)
            Me.addInputParameter("VIHSIDA_Criterio", SqlDbType.Int, oCriterioIngreso.VIHSIDA_Criterio)
            Me.addInputParameter("VIHSIDA_Aprobado", SqlDbType.Int, oCriterioIngreso.VIHSIDA_Aprobado)
            Me.addInputParameter("VIHSIDA_Cumple", SqlDbType.Int, oCriterioIngreso.VIHSIDA_Cumple)
            Me.addInputParameter("Demencia_Incapacidad_Vestirse", SqlDbType.Int, oCriterioIngreso.Demencia_Incapacidad_Vestirse)
            Me.addInputParameter("Demencia_Aparicion_Incontinencia", SqlDbType.Int, oCriterioIngreso.Demencia_Aparicion_Incontinencia)
            Me.addInputParameter("Demencia_Incapacidad_Hablar", SqlDbType.Int, oCriterioIngreso.Demencia_Incapacidad_Hablar)
            Me.addInputParameter("Demencia_Perdida", SqlDbType.Int, oCriterioIngreso.Demencia_Perdida)
            Me.addInputParameter("Demencia_Aparicion_Dificultad", SqlDbType.Int, oCriterioIngreso.Demencia_Aparicion_Dificultad)
            Me.addInputParameter("Demencia_Multiples", SqlDbType.Int, oCriterioIngreso.Demencia_Multiples)
            Me.addInputParameter("Cumple_Demencia", SqlDbType.Int, oCriterioIngreso.Cumple_Demencia)
            Me.addInputParameter("Parkinson_Deterioro", SqlDbType.Int, oCriterioIngreso.Parkinson_Deterioro)
            Me.addInputParameter("Parkinson_Sintomas", SqlDbType.Int, oCriterioIngreso.Parkinson_Sintomas)
            Me.addInputParameter("Parkinson_Problemas", SqlDbType.Int, oCriterioIngreso.Parkinson_Problemas)
            Me.addInputParameter("Parkinson_Disfagia", SqlDbType.Int, oCriterioIngreso.Parkinson_Disfagia)
            Me.addInputParameter("Parkinson_Neumonia", SqlDbType.Int, oCriterioIngreso.Parkinson_Neumonia)
            Me.addInputParameter("Parkinson_Cumple", SqlDbType.Int, oCriterioIngreso.Parkinson_Cumple)
            Me.addInputParameter("Motoneurona_Deterioro", SqlDbType.Int, oCriterioIngreso.Motoneurona_Deterioro)
            Me.addInputParameter("Motoneurona_Sintomas", SqlDbType.Int, oCriterioIngreso.Motoneurona_Sintomas)
            Me.addInputParameter("Motoneurona_Problemas", SqlDbType.Int, oCriterioIngreso.Motoneurona_Problemas)
            Me.addInputParameter("Motoneurona_Disfagia", SqlDbType.Int, oCriterioIngreso.Motoneurona_Disfagia)
            Me.addInputParameter("Motoneurona_Neumonia", SqlDbType.Int, oCriterioIngreso.Motoneurona_Neumonia)
            Me.addInputParameter("Motoneurona_Cumple", SqlDbType.Int, oCriterioIngreso.Motoneurona_Cumple)
            Me.addInputParameter("Esclerosis_Multiple_Deterioro", SqlDbType.Int, oCriterioIngreso.Esclerosis_Multiple_Deterioro)
            Me.addInputParameter("Esclerosis_Multiple_Sintomas", SqlDbType.Int, oCriterioIngreso.Esclerosis_Multiple_Sintomas)
            Me.addInputParameter("Esclerosis_Multiple_Problemas", SqlDbType.Int, oCriterioIngreso.Esclerosis_Multiple_Problemas)
            Me.addInputParameter("Esclerosis_Multiple_Disfagia", SqlDbType.Int, oCriterioIngreso.Esclerosis_Multiple_Disfagia)
            Me.addInputParameter("Esclerosis_Multiple_Neumonia", SqlDbType.Int, oCriterioIngreso.Esclerosis_Multiple_Neumonia)
            Me.addInputParameter("Esclerosis_Multiple_Cumple", SqlDbType.Int, oCriterioIngreso.Esclerosis_Multiple_Cumple)
            Me.addInputParameter("Cardiaca_Cronica_Insuficiencia_Cardiaca", SqlDbType.Int, oCriterioIngreso.Cardiaca_Cronica_Insuficiencia_Cardiaca)
            Me.addInputParameter("Cardiaca_Cronica_Disnea", SqlDbType.Int, oCriterioIngreso.Cardiaca_Cronica_Disnea)
            Me.addInputParameter("Cardiaca_Cronica_Sintomas", SqlDbType.Int, oCriterioIngreso.Cardiaca_Cronica_Sintomas)
            Me.addInputParameter("Cardiaca_Cronica_Ecocardiograma", SqlDbType.Int, oCriterioIngreso.Cardiaca_Cronica_Ecocardiograma)
            Me.addInputParameter("Cardiaca_Cronica_Insuficiencia_Renal", SqlDbType.Int, oCriterioIngreso.Cardiaca_Cronica_Insuficiencia_Renal)
            Me.addInputParameter("Cardiaca_Cronica_Ingresos", SqlDbType.Int, oCriterioIngreso.Cardiaca_Cronica_Ingresos)
            Me.addInputParameter("Cardiaca_Cronica_Cumple", SqlDbType.Int, oCriterioIngreso.Cardiaca_Cronica_Cumple)
            Me.addInputParameter("Cerebro_Vascular_Cumple_Fragilidad", SqlDbType.Int, oCriterioIngreso.Cerebro_Vascular_Cumple_Fragilidad)
            Me.addInputParameter("Cerebro_Vascular_Aprobado", SqlDbType.Int, oCriterioIngreso.Cerebro_Vascular_Aprobado)
            Me.addInputParameter("Cerebro_Vascular_Cumple", SqlDbType.Int, oCriterioIngreso.Cerebro_Vascular_Cumple)
            Me.addInputParameter("Pulmonar_Cronica_Disnea", SqlDbType.Int, oCriterioIngreso.Pulmonar_Cronica_Disnea)
            Me.addInputParameter("Pulmonar_Cronica_Sintomas", SqlDbType.Int, oCriterioIngreso.Pulmonar_Cronica_Sintomas)
            Me.addInputParameter("Pulmonar_Cronica_Criterios", SqlDbType.Int, oCriterioIngreso.Pulmonar_Cronica_Criterios) ''WACHV, 20 SEPT2017, AQUI LA RESPUESTA DE LA NUEVA PREGUNTA Criterios de oxigenoterapia domiciliaria permanente
            Me.addInputParameter("Pulmonar_Cronica_En", SqlDbType.Int, oCriterioIngreso.Pulmonar_Cronica_En) ''WACHV, 20 SEPT2017, AQUI LA RESPUESTA DE LA NUEVA PREGUNTA  En caso de disponer de pruebas funcionales    respiratorias,Criterios de   obstrucción severa:     VEF1<30% o criterios de  déficit restrictivo severo: CV forzada <40/DLCO<40%
            Me.addInputParameter("Pulmonar_Cronica_Insuficiencia", SqlDbType.Int, oCriterioIngreso.Pulmonar_Cronica_Insuficiencia)
            Me.addInputParameter("Pulmonar_Cronica_Ingresos", SqlDbType.Int, oCriterioIngreso.Pulmonar_Cronica_Ingresos)
            Me.addInputParameter("Pulmonar_Cronica_Cumple", SqlDbType.Int, oCriterioIngreso.Pulmonar_Cronica_Cumple)
            Me.addInputParameter("Hepatica_Cronica_Cirrosis", SqlDbType.Int, oCriterioIngreso.Hepatica_Cronica_Cirrosis)
            Me.addInputParameter("Hepatica_Cronica_Puntuacion", SqlDbType.Int, oCriterioIngreso.Hepatica_Cronica_Puntuacion)
            Me.addInputParameter("Hepatica_Cronica_Presencia", SqlDbType.Int, oCriterioIngreso.Hepatica_Cronica_Presencia)
            Me.addInputParameter("Hepatica_Cronica_Carcinoma", SqlDbType.Int, oCriterioIngreso.Hepatica_Cronica_Carcinoma)
            Me.addInputParameter("Hepatica_Cronica_Cumple", SqlDbType.Int, oCriterioIngreso.Hepatica_Cronica_Cumple)
            Me.addInputParameter("Renal_Cronica_Insuficiencia", SqlDbType.Int, oCriterioIngreso.Renal_Cronica_Insuficiencia)
            Me.addInputParameter("Renal_Cronica_CriterioFragilidadSevera", SqlDbType.Int, oCriterioIngreso.Renal_Cronica_CriterioFragilidadSevera) '''WACHV,20SEPT2017,SE GAREGA NUEVO PARAMETRO
            Me.addInputParameter("Renal_Cronica_AprobadoJuntaPaliativa", SqlDbType.Int, oCriterioIngreso.Renal_Cronica_AprobadoJuntaPaliativa)     '''WACHV,20SEPT2017,SE GAREGA NUEVO PARAMETRO
            Me.addInputParameter("Renal_Cronica_Cumple", SqlDbType.Int, oCriterioIngreso.Renal_Cronica_Cumple)
            Me.addInputParameter("Fragilidad_Severa_Deterioro", SqlDbType.Int, oCriterioIngreso.Fragilidad_Severa_Deterioro)
            Me.addInputParameter("Fragilidad_Severa_Perdida_Peso", SqlDbType.Int, oCriterioIngreso.Fragilidad_Severa_Perdida_Peso)
            Me.addInputParameter("Fragilidad_Severa_Albumina", SqlDbType.Int, oCriterioIngreso.Fragilidad_Severa_Albumina)
            Me.addInputParameter("Fragilidad_Severa_Impresion", SqlDbType.Int, oCriterioIngreso.Fragilidad_Severa_Impresion)
            Me.addInputParameter("Fragilidad_Severa_Barthel", SqlDbType.Int, oCriterioIngreso.Fragilidad_Severa_Barthel)
            Me.addInputParameter("Fragilidad_Severa_Pps", SqlDbType.Int, oCriterioIngreso.Fragilidad_Severa_Pps)
            Me.addInputParameter("Fragilidad_Severa_Perdida_Actividades", SqlDbType.Int, oCriterioIngreso.Fragilidad_Severa_Perdida_Actividades)
            Me.addInputParameter("Fragilidad_Severa_Ulceras", SqlDbType.Int, oCriterioIngreso.Fragilidad_Severa_Ulceras)
            Me.addInputParameter("Fragilidad_Severa_Infecciones", SqlDbType.Int, oCriterioIngreso.Fragilidad_Severa_Infecciones)
            Me.addInputParameter("Fragilidad_Severa_Delirium", SqlDbType.Int, oCriterioIngreso.Fragilidad_Severa_Delirium)
            Me.addInputParameter("Fragilidad_Severa_Disfagia", SqlDbType.Int, oCriterioIngreso.Fragilidad_Severa_Disfagia)
            Me.addInputParameter("Fragilidad_Severa_Caidas", SqlDbType.Int, oCriterioIngreso.Fragilidad_Severa_Caidas)
            Me.addInputParameter("Fragilidad_Severa_Sintomas", SqlDbType.Int, oCriterioIngreso.Fragilidad_Severa_Sintomas)
            Me.addInputParameter("Fragilidad_Severa_Mas_Ingresos", SqlDbType.Int, oCriterioIngreso.Fragilidad_Severa_Mas_Ingresos)
            Me.addInputParameter("Fragilidad_Severa_Necesidad", SqlDbType.Int, oCriterioIngreso.Fragilidad_Severa_Necesidad)
            Me.addInputParameter("Fragilidad_Severa_Mas_Patologias", SqlDbType.Int, oCriterioIngreso.Fragilidad_Severa_Mas_Patologias)
            Me.addInputParameter("Fragilidad_Severa_Cumple", SqlDbType.Int, oCriterioIngreso.Fragilidad_Severa_Cumple)
            Me.addInputParameter("obs", SqlDbType.VarChar, oCriterioIngreso.obs)
            Me.addInputParameter("login", SqlDbType.VarChar, oCriterioIngreso.login)
            Me.addOutputParameter("Mensaje", SqlDbType.VarChar, 500)

            Me.Exec()

            MensajeError = Me.Parameters("Mensaje").Value

            Return MensajeError

        End Function

        ''' <summary>
        ''' Consulta la Ultima Respuesta de Criterios de Ingreso registrados para paciente.
        ''' </summary>
        ''' <param name="id_Pregunta">Id de la Pregunta</param>
        ''' <param name="Respuesta">Respuesta obtenida del servicio</param>
        ''' <returns>Criterio de Ingreso con la respuesta obtenida del servicio</returns>
        ''' <remarks></remarks>
        Public Function ConsultarURCriterioIngreso(ByVal id_Pregunta As Integer, ByVal Respuesta As String) As CriterioIngreso
            Dim dtCriterioIngreso As New DataTable
            Dim oCriterioIngreso As New CriterioIngreso


            Me.setSQLSentence("pr_HC_CpConsultaURCriterioIngreso", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("id_Pregunta", SqlDbType.VarChar, id_Pregunta)
            Me.addInputParameter("Respuesta", SqlDbType.VarChar, Respuesta)

            dtCriterioIngreso = Me.execDT

            For Each row As DataRow In dtCriterioIngreso.Rows

                oCriterioIngreso.Oncologica_Diagnostico = IIf(row.Item("Oncologica_Diagnostico").ToString() = "", 0, row.Item("Oncologica_Diagnostico"))
                oCriterioIngreso.Oncologica_Deterioro = IIf(row.Item("Oncologica_Deterioro").ToString() = "", 0, row.Item("Oncologica_Deterioro"))
                oCriterioIngreso.Oncologica_Sintomas = IIf(row.Item("Oncologica_Sintomas").ToString() = "", 0, row.Item("Oncologica_Sintomas"))
                'oCriterioIngreso.Oncologica_Cumple = IIf(row.Item("Oncologica_Cumple").ToString() = "", 0, row.Item("Oncologica_Cumple"))
                oCriterioIngreso.VIHSIDA_Criterio = IIf(row.Item("VIHSIDA_Criterio").ToString() = "", 0, row.Item("VIHSIDA_Criterio"))
                oCriterioIngreso.VIHSIDA_Aprobado = IIf(row.Item("VIHSIDA_Aprobado").ToString() = "", 0, row.Item("VIHSIDA_Aprobado"))
                'oCriterioIngreso.VIHSIDA_Cumple = IIf(row.Item("VIHSIDA_Cumple").ToString() = "", 0, row.Item("VIHSIDA_Cumple"))
                oCriterioIngreso.Demencia_Incapacidad_Vestirse = IIf(row.Item("Demencia_Incapacidad_Vestirse").ToString() = "", 0, row.Item("Demencia_Incapacidad_Vestirse"))
                oCriterioIngreso.Demencia_Aparicion_Incontinencia = IIf(row.Item("Demencia_Aparicion_Incontinencia").ToString() = "", 0, row.Item("Demencia_Aparicion_Incontinencia"))
                oCriterioIngreso.Demencia_Incapacidad_Hablar = IIf(row.Item("Demencia_Incapacidad_Hablar").ToString() = "", 0, row.Item("Demencia_Incapacidad_Hablar"))
                oCriterioIngreso.Demencia_Perdida = IIf(row.Item("Demencia_Perdida").ToString() = "", 0, row.Item("Demencia_Perdida"))
                oCriterioIngreso.Demencia_Aparicion_Dificultad = IIf(row.Item("Demencia_Aparicion_Dificultad").ToString() = "", 0, row.Item("Demencia_Aparicion_Dificultad"))
                oCriterioIngreso.Demencia_Multiples = IIf(row.Item("Demencia_Multiples").ToString() = "", 0, row.Item("Demencia_Multiples"))
                'oCriterioIngreso.Cumple_Demencia = IIf(row.Item("Cumple_Demencia").ToString() = "", 0, row.Item("Cumple_Demencia"))
                oCriterioIngreso.Parkinson_Deterioro = IIf(row.Item("Parkinson_Deterioro").ToString() = "", 0, row.Item("Parkinson_Deterioro"))
                oCriterioIngreso.Parkinson_Sintomas = IIf(row.Item("Parkinson_Sintomas").ToString() = "", 0, row.Item("Parkinson_Sintomas"))
                oCriterioIngreso.Parkinson_Problemas = IIf(row.Item("Parkinson_Problemas").ToString() = "", 0, row.Item("Parkinson_Problemas"))
                oCriterioIngreso.Parkinson_Disfagia = IIf(row.Item("Parkinson_Disfagia").ToString() = "", 0, row.Item("Parkinson_Disfagia"))
                oCriterioIngreso.Parkinson_Neumonia = IIf(row.Item("Parkinson_Neumonia").ToString() = "", 0, row.Item("Parkinson_Neumonia"))
                'oCriterioIngreso.Parkinson_Cumple = IIf(row.Item("Parkinson_Cumple").ToString() = "", 0, row.Item("Parkinson_Cumple"))
                oCriterioIngreso.Motoneurona_Deterioro = IIf(row.Item("Motoneurona_Deterioro").ToString() = "", 0, row.Item("Motoneurona_Deterioro"))
                oCriterioIngreso.Motoneurona_Sintomas = IIf(row.Item("Motoneurona_Sintomas").ToString() = "", 0, row.Item("Motoneurona_Sintomas"))
                oCriterioIngreso.Motoneurona_Problemas = IIf(row.Item("Motoneurona_Problemas").ToString() = "", 0, row.Item("Motoneurona_Problemas"))
                oCriterioIngreso.Motoneurona_Disfagia = IIf(row.Item("Motoneurona_Disfagia").ToString() = "", 0, row.Item("Motoneurona_Disfagia"))
                oCriterioIngreso.Motoneurona_Neumonia = IIf(row.Item("Motoneurona_Neumonia").ToString() = "", 0, row.Item("Motoneurona_Neumonia"))
                'oCriterioIngreso.Motoneurona_Cumple = IIf(row.Item("Motoneurona_Cumple").ToString() = "", 0, row.Item("Motoneurona_Cumple"))
                oCriterioIngreso.Esclerosis_Multiple_Deterioro = IIf(row.Item("Esclerosis_Multiple_Deterioro").ToString() = "", 0, row.Item("Esclerosis_Multiple_Deterioro"))
                oCriterioIngreso.Esclerosis_Multiple_Sintomas = IIf(row.Item("Esclerosis_Multiple_Sintomas").ToString() = "", 0, row.Item("Esclerosis_Multiple_Sintomas"))
                oCriterioIngreso.Esclerosis_Multiple_Problemas = IIf(row.Item("Esclerosis_Multiple_Problemas").ToString() = "", 0, row.Item("Esclerosis_Multiple_Problemas"))
                oCriterioIngreso.Esclerosis_Multiple_Disfagia = IIf(row.Item("Esclerosis_Multiple_Disfagia").ToString() = "", 0, row.Item("Esclerosis_Multiple_Disfagia"))
                oCriterioIngreso.Esclerosis_Multiple_Neumonia = IIf(row.Item("Esclerosis_Multiple_Neumonia").ToString() = "", 0, row.Item("Esclerosis_Multiple_Neumonia"))
                'oCriterioIngreso.Esclerosis_Multiple_Cumple = IIf(row.Item("Esclerosis_Multiple_Cumple").ToString() = "", 0, row.Item("Esclerosis_Multiple_Cumple"))
                oCriterioIngreso.Cardiaca_Cronica_Insuficiencia_Cardiaca = IIf(row.Item("Cardiaca_Cronica_Insuficiencia_Cardiaca").ToString() = "", 0, row.Item("Cardiaca_Cronica_Insuficiencia_Cardiaca"))
                oCriterioIngreso.Cardiaca_Cronica_Disnea = IIf(row.Item("Cardiaca_Cronica_Disnea").ToString() = "", 0, row.Item("Cardiaca_Cronica_Disnea"))
                oCriterioIngreso.Cardiaca_Cronica_Sintomas = IIf(row.Item("Cardiaca_Cronica_Sintomas").ToString() = "", 0, row.Item("Cardiaca_Cronica_Sintomas"))
                oCriterioIngreso.Cardiaca_Cronica_Ecocardiograma = IIf(row.Item("Cardiaca_Cronica_Ecocardiograma").ToString() = "", 0, row.Item("Cardiaca_Cronica_Ecocardiograma"))
                oCriterioIngreso.Cardiaca_Cronica_Insuficiencia_Renal = IIf(row.Item("Cardiaca_Cronica_Insuficiencia_Renal").ToString() = "", 0, row.Item("Cardiaca_Cronica_Insuficiencia_Renal"))
                oCriterioIngreso.Cardiaca_Cronica_Ingresos = IIf(row.Item("Cardiaca_Cronica_Ingresos").ToString() = "", 0, row.Item("Cardiaca_Cronica_Ingresos"))
                'oCriterioIngreso.Cardiaca_Cronica_Cumple = IIf(row.Item("Cardiaca_Cronica_Cumple").ToString() = "", 0, row.Item("Cardiaca_Cronica_Cumple"))
                oCriterioIngreso.Cerebro_Vascular_Cumple_Fragilidad = IIf(row.Item("Cerebro_Vascular_Cumple_Fragilidad").ToString() = "", 0, row.Item("Cerebro_Vascular_Cumple_Fragilidad"))
                oCriterioIngreso.Cerebro_Vascular_Aprobado = IIf(row.Item("Cerebro_Vascular_Aprobado").ToString() = "", 0, row.Item("Cerebro_Vascular_Aprobado"))
                'oCriterioIngreso.Cerebro_Vascular_Cumple = IIf(row.Item("Cerebro_Vascular_Cumple").ToString() = "", 0, row.Item("Cerebro_Vascular_Cumple"))
                oCriterioIngreso.Pulmonar_Cronica_Disnea = IIf(row.Item("Pulmonar_Cronica_Disnea").ToString() = "", 0, row.Item("Pulmonar_Cronica_Disnea"))
                oCriterioIngreso.Pulmonar_Cronica_Sintomas = IIf(row.Item("Pulmonar_Cronica_Sintomas").ToString() = "", 0, row.Item("Pulmonar_Cronica_Sintomas"))
                oCriterioIngreso.Pulmonar_Cronica_Criterios = IIf(row.Item("Pulmonar_Cronica_Criterios").ToString() = "", 0, row.Item("Pulmonar_Cronica_Criterios"))
                oCriterioIngreso.Pulmonar_Cronica_En = IIf(row.Item("Pulmonar_Cronica_En").ToString() = "", 0, row.Item("Pulmonar_Cronica_En"))
                oCriterioIngreso.Pulmonar_Cronica_Insuficiencia = IIf(row.Item("Pulmonar_Cronica_Insuficiencia").ToString() = "", 0, row.Item("Pulmonar_Cronica_Insuficiencia"))
                oCriterioIngreso.Pulmonar_Cronica_Ingresos = IIf(row.Item("Pulmonar_Cronica_Ingresos").ToString() = "", 0, row.Item("Pulmonar_Cronica_Ingresos"))
                'oCriterioIngreso.Pulmonar_Cronica_Cumple = IIf(row.Item("Pulmonar_Cronica_Cumple").ToString() = "", 0, row.Item("Pulmonar_Cronica_Cumple"))
                oCriterioIngreso.Hepatica_Cronica_Cirrosis = IIf(row.Item("Hepatica_Cronica_Cirrosis").ToString() = "", 0, row.Item("Hepatica_Cronica_Cirrosis"))
                oCriterioIngreso.Hepatica_Cronica_Puntuacion = IIf(row.Item("Hepatica_Cronica_Puntuacion").ToString() = "", 0, row.Item("Hepatica_Cronica_Puntuacion"))
                oCriterioIngreso.Hepatica_Cronica_Presencia = IIf(row.Item("Hepatica_Cronica_Presencia").ToString() = "", 0, row.Item("Hepatica_Cronica_Presencia"))
                oCriterioIngreso.Hepatica_Cronica_Carcinoma = IIf(row.Item("Hepatica_Cronica_Carcinoma").ToString() = "", 0, row.Item("Hepatica_Cronica_Carcinoma"))
                'oCriterioIngreso.Hepatica_Cronica_Cumple = IIf(row.Item("Hepatica_Cronica_Cumple").ToString() = "", 0, row.Item("Hepatica_Cronica_Cumple"))
                oCriterioIngreso.Renal_Cronica_Insuficiencia = IIf(row.Item("Renal_Cronica_Insuficiencia").ToString() = "", 0, row.Item("Renal_Cronica_Insuficiencia"))
                oCriterioIngreso.Renal_Cronica_CriterioFragilidadSevera = IIf(row.Item("Renal_Cronica_CriterioFragilidadSevera").ToString() = "", 0, row.Item("Renal_Cronica_CriterioFragilidadSevera")) '''NUEVA PREGUNTA WACHV,19SEPT2017
                oCriterioIngreso.Renal_Cronica_AprobadoJuntaPaliativa = IIf(row.Item("Renal_Cronica_AprobadoJuntaPaliativa").ToString() = "", 0, row.Item("Renal_Cronica_AprobadoJuntaPaliativa"))       '''NUEVA PREGUNTA WACHV,19SEPT2017
                'oCriterioIngreso.Renal_Cronica_Cumple = IIf(row.Item("Renal_Cronica_Cumple").ToString() = "", 0, row.Item("Renal_Cronica_Cumple"))
                oCriterioIngreso.Fragilidad_Severa_Deterioro = IIf(row.Item("Fragilidad_Severa_Deterioro").ToString() = "", 0, row.Item("Fragilidad_Severa_Deterioro"))
                oCriterioIngreso.Fragilidad_Severa_Perdida_Peso = IIf(row.Item("Fragilidad_Severa_Perdida_Peso").ToString() = "", 0, row.Item("Fragilidad_Severa_Perdida_Peso"))
                oCriterioIngreso.Fragilidad_Severa_Albumina = IIf(row.Item("Fragilidad_Severa_Albumina").ToString() = "", 0, row.Item("Fragilidad_Severa_Albumina"))
                oCriterioIngreso.Fragilidad_Severa_Impresion = IIf(row.Item("Fragilidad_Severa_Impresion").ToString() = "", 0, row.Item("Fragilidad_Severa_Impresion"))
                oCriterioIngreso.Fragilidad_Severa_Barthel = IIf(row.Item("Fragilidad_Severa_Barthel").ToString() = "", 0, row.Item("Fragilidad_Severa_Barthel"))
                oCriterioIngreso.Fragilidad_Severa_Pps = IIf(row.Item("Fragilidad_Severa_Pps").ToString() = "", 0, row.Item("Fragilidad_Severa_Pps"))
                oCriterioIngreso.Fragilidad_Severa_Perdida_Actividades = IIf(row.Item("Fragilidad_Severa_Perdida_Actividades").ToString() = "", 0, row.Item("Fragilidad_Severa_Perdida_Actividades"))
                oCriterioIngreso.Fragilidad_Severa_Ulceras = IIf(row.Item("Fragilidad_Severa_Ulceras").ToString() = "", 0, row.Item("Fragilidad_Severa_Ulceras"))
                oCriterioIngreso.Fragilidad_Severa_Infecciones = IIf(row.Item("Fragilidad_Severa_Infecciones").ToString() = "", 0, row.Item("Fragilidad_Severa_Infecciones"))
                oCriterioIngreso.Fragilidad_Severa_Delirium = IIf(row.Item("Fragilidad_Severa_Delirium").ToString() = "", 0, row.Item("Fragilidad_Severa_Delirium"))
                oCriterioIngreso.Fragilidad_Severa_Disfagia = IIf(row.Item("Fragilidad_Severa_Disfagia").ToString() = "", 0, row.Item("Fragilidad_Severa_Disfagia"))
                oCriterioIngreso.Fragilidad_Severa_Caidas = IIf(row.Item("Fragilidad_Severa_Caidas").ToString() = "", 0, row.Item("Fragilidad_Severa_Caidas"))
                oCriterioIngreso.Fragilidad_Severa_Sintomas = IIf(row.Item("Fragilidad_Severa_Sintomas").ToString() = "", 0, row.Item("Fragilidad_Severa_Sintomas"))
                oCriterioIngreso.Fragilidad_Severa_Mas_Ingresos = IIf(row.Item("Fragilidad_Severa_Mas_Ingresos").ToString() = "", 0, row.Item("Fragilidad_Severa_Mas_Ingresos"))
                oCriterioIngreso.Fragilidad_Severa_Necesidad = IIf(row.Item("Fragilidad_Severa_Necesidad").ToString() = "", 0, row.Item("Fragilidad_Severa_Necesidad"))
                oCriterioIngreso.Fragilidad_Severa_Mas_Patologias = IIf(row.Item("Fragilidad_Severa_Mas_Patologias").ToString() = "", 0, row.Item("Fragilidad_Severa_Mas_Patologias"))
                'oCriterioIngreso.Fragilidad_Severa_Cumple = IIf(row.Item("Fragilidad_Severa_Cumple").ToString() = "", 0, row.Item("Fragilidad_Severa_Cumple"))

            Next

            Return oCriterioIngreso

        End Function

#End Region

#Region "Preguntas"

        ''' <summary>
        ''' Consulta las Preguntas de Cuidados Palitivos.
        ''' </summary>
        ''' <param name="oPreguntaCP">Pregunta con los Filtros de búsqueda</param>
        ''' <returns>Listado de Preguntas</returns>
        ''' <remarks></remarks>
        Public Function ConsultarPreguntas(ByVal oPreguntaCP As PreguntaCP) As List(Of PreguntaCP)
            Dim dtPreguntaCP As New DataTable
            Dim lstPreguntaCP As New List(Of PreguntaCP)


            Me.setSQLSentence("pr_HC_CpConsultaPreguntasCP", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("id", SqlDbType.Int, IIf(oPreguntaCP.id = 0, DBNull.Value, oPreguntaCP.id))
            Me.addInputParameter("descripcion", SqlDbType.VarChar, IIf(oPreguntaCP.descripcion = "", DBNull.Value, oPreguntaCP.descripcion))
            Me.addInputParameter("seccion", SqlDbType.Int, IIf(oPreguntaCP.seccion = 0, DBNull.Value, oPreguntaCP.seccion))
            Me.addInputParameter("Tabla_Movimiento", SqlDbType.VarChar, IIf(oPreguntaCP.Tabla_Movimiento = "", DBNull.Value, oPreguntaCP.Tabla_Movimiento))
            Me.addInputParameter("Pregunta_Campo", SqlDbType.VarChar, IIf(oPreguntaCP.Pregunta_Campo = "", DBNull.Value, oPreguntaCP.Pregunta_Campo))
            Me.addInputParameter("id_av", SqlDbType.Int, IIf(oPreguntaCP.id_av = 0, DBNull.Value, oPreguntaCP.id_av))
            Me.addInputParameter("id_respuestaav", SqlDbType.VarChar, IIf(oPreguntaCP.id_respuestaav = "", DBNull.Value, oPreguntaCP.id_respuestaav))
            Me.addInputParameter("login", SqlDbType.VarChar, IIf(oPreguntaCP.login = "", DBNull.Value, oPreguntaCP.login))

            dtPreguntaCP = Me.execDT

            For Each row As DataRow In dtPreguntaCP.Rows
                oPreguntaCP = New PreguntaCP

                oPreguntaCP.id = row.Item("id")
                oPreguntaCP.descripcion = row.Item("descripcion")
                oPreguntaCP.seccion = row.Item("seccion")
                oPreguntaCP.Tabla_Movimiento = row.Item("Tabla_Movimiento")
                oPreguntaCP.Pregunta_Campo = row.Item("Pregunta_Campo")
                oPreguntaCP.id_av = row.Item("id_av")
                oPreguntaCP.id_respuestaav = row.Item("id_respuestaav")
                oPreguntaCP.fec_con = row.Item("fec_con")
                oPreguntaCP.obs = row.Item("obs")
                oPreguntaCP.login = row.Item("login")
                lstPreguntaCP.Add(oPreguntaCP)
            Next

            Return lstPreguntaCP

        End Function

#End Region

#Region "Parametros Web Service Última Respuesta"

        ''' <summary>
        ''' Consulta la URL del servicio de Ultima Respuesta de Cuidados Paliativos.
        ''' </summary>
        ''' <param name=" cod_pre_sgs">Código del Prestados</param>
        ''' <param name=" cod_sucur">Código de la sucursal</param>
        ''' <param name=" tip_servicio">Tipo de Servicio</param>
        ''' <param name=" Nombre">Nombre de la capacidad</param>
        ''' <returns>Retorna la URL del servicio.</returns>
        ''' <remarks></remarks>
        Public Function ConsultarUrlServicioUT(ByVal cod_pre_sgs As String, ByVal cod_sucur As String, ByVal tip_servicio As String, ByVal Nombre As String) As String
            Try
                Dim dtServicio As New DataTable


                Me.setSQLSentence("pa_consultarservicio", CommandType.StoredProcedure)
                Me.ClearParameters()
                Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
                Me.addInputParameter("cod_sucur", SqlDbType.VarChar, cod_sucur)
                Me.addInputParameter("tip_servicio", SqlDbType.VarChar, tip_servicio)
                Me.addInputParameter("metodo", SqlDbType.VarChar, Nombre)

                dtServicio = Me.execDT

                If dtServicio.Rows.Count > 0 Then
                    Return dtServicio.Rows(0).Item("SoapAction")
                Else
                    Return ""
                End If

            Catch ex As Exception
                Throw (ex)
            End Try
        End Function

#End Region

#Region "Reporte Cuidados Paliativos"

        Public Function ConsultaDatosReporteCuidadosPaliativos(ByVal strPrestador As String, ByVal strsucursal As String, _
        Optional ByVal strTipAdmision As String = "", Optional ByVal ianoAdm As Integer = 0, Optional ByVal num_adm As Decimal = 0, _
        Optional ByVal strTip_Doc As String = "", Optional ByVal strNum_Doc As String = "") As DataSet

            Dim ds As DataSet
            Me.setSQLSentence("pr_HC_CpRptHistorico", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strPrestador)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strsucursal)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, strTipAdmision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ianoAdm)
            Me.addInputParameter("num_adm", SqlDbType.Decimal, num_adm)
            Me.addInputParameter("tip_doc", SqlDbType.VarChar, strTip_Doc)
            Me.addInputParameter("num_doc", SqlDbType.VarChar, strNum_Doc)
            Me.addInputParameter("idSeccion", SqlDbType.VarChar, DBNull.Value)

            ds = Me.execDS

            Return ds
        End Function

#End Region

#End Region

#Region "Regional para Consumir el WS"
        ''WACHV, 22DIC2017, Se Creo esta funcion para obtener de cada bd su referencia de regional
        Public Function ConsultarRegional() As String
            Dim dtregional As New DataTable
            Dim strParametroFijoPaliativos As String = "HCPAL_REGIONAL"
            Me.setSQLSentence("DB_Traergenparsophia", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("nombre_par", SqlDbType.VarChar, strParametroFijoPaliativos)
            dtregional = Me.execDT
            If dtregional.Rows.Count > 0 Then
                Return dtregional.Rows(0).Item("Valor")
            Else
                Return ""
            End If
        End Function
#End Region
#Region "RMZC"
        Public Const MetodoServicioH As String = "historicoRespuestas"
        Public Const ProgramaH As String = "PALIATIVOS"
        Public Const SeccionH As String = "SEG_PROG"
        Public Const SubSeccionH As String = "HER_EVAL"
        Public Const SubSeccionHCateter As String = "CAT_PAL"  ''WACHV,NOV232017, SE AGREGA AL DEFINICIONM DE ESTA SECCION
#End Region


    End Class
End Namespace