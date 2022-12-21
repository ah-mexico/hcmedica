Imports System
Imports System.Collections.Generic
Imports System.Data.DataSetExtensions
Namespace Sophia.HistoriaClinica.DAO
    Public Class DAOIngresoaPrograma
        Inherits GPMData

#Region "ValoracioneIngreso"
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
            End Select

            dt = Me.execDT
            Return dt
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

        ''' <summary>
        ''' Almacena los Aspectos Sociales del Programa de Cuidados Paliativos.
        ''' </summary>
        ''' <param name="oAspectosSociales"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GuardarIngresoaPrograma(ByVal oIngresoaPrograma As IngresoaPrograma) As Long

            Dim lerror As Long = 0

            Me.setSQLSentence("HC_CPGuardarIngresoaPrograma", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("strCodPreSgs", SqlDbType.VarChar, oIngresoaPrograma.cod_pre_sgs)
            Me.addInputParameter("strCodSucur", SqlDbType.VarChar, oIngresoaPrograma.cod_sucur)
            Me.addInputParameter("strTipAdm", SqlDbType.VarChar, oIngresoaPrograma.tip_admision)
            Me.addInputParameter("iAnoAdm", SqlDbType.Int, oIngresoaPrograma.ano_adm)
            Me.addInputParameter("dNumAdm", SqlDbType.Decimal, oIngresoaPrograma.num_adm)
            Me.addInputParameter("tip_doc", SqlDbType.VarChar, oIngresoaPrograma.tip_doc)
            Me.addInputParameter("Num_doc", SqlDbType.VarChar, oIngresoaPrograma.Num_doc)
            Me.addInputParameter("Fec_Ingreso", SqlDbType.VarChar, oIngresoaPrograma.FechaIngreso)
            Me.addInputParameter("AtencPrev", SqlDbType.VarChar, oIngresoaPrograma.Harecibidoatencionpreviaporcuidadospaliativos)
            Me.addInputParameter("LugarAtencion", SqlDbType.VarChar, oIngresoaPrograma.Donderecibioatencionporcuidadospaliativos)
            Me.addInputParameter("Fec_Diagnostico", SqlDbType.VarChar, oIngresoaPrograma.FechaDiagnostico)
            Me.addInputParameter("ReqAten_HospUrg", SqlDbType.VarChar, oIngresoaPrograma.Harequeridoatencionporurgenciasuhospitalizacionenelultimomes)
            Me.addInputParameter("Fec_Aten_HospUrg", SqlDbType.VarChar, oIngresoaPrograma.Fechadelaatencionporurgencias_Hospitalizacion)
            Me.addInputParameter("Aten_Asoc_DiagBase", SqlDbType.VarChar, oIngresoaPrograma.Laatencionporurgencias_hospitalizacionestaasociadacoeldiagnosticodebase)
            Me.addInputParameter("Obs_Aten_HospUrg", SqlDbType.VarChar, oIngresoaPrograma.Observacionesdelaatencion_Urgencias_Hospitalizacion)
            Me.addInputParameter("Aten_AmbUMes", SqlDbType.VarChar, oIngresoaPrograma.Harequeridoatencionporcirugiaambulatoriaenelultimomes)
            Me.addInputParameter("Intervenciones", SqlDbType.VarChar, oIngresoaPrograma.Elpacienteestarecibiendoalgunadelassiguientesintervenciones)
            Me.addInputParameter("ObsIntervenciones", SqlDbType.VarChar, oIngresoaPrograma.Observacionesintervencionespaliativos)
            Me.addInputParameter("ConDiagnPac", SqlDbType.VarChar, oIngresoaPrograma.Conoceeldiagnostico_Paciente)
            Me.addInputParameter("ConPronPac", SqlDbType.VarChar, oIngresoaPrograma.Conoceelpronostico_Paciente)
            Me.addInputParameter("PideInfoPac", SqlDbType.VarChar, oIngresoaPrograma.Pideinformacion_Paciente)
            Me.addInputParameter("PideNoInfPac", SqlDbType.VarChar, oIngresoaPrograma.Pidequenoseleinforme_Paciente)
            Me.addInputParameter("ConDiagnFam", SqlDbType.VarChar, oIngresoaPrograma.Conoceeldiagnostico_Familia)
            Me.addInputParameter("ConPronFam", SqlDbType.VarChar, oIngresoaPrograma.Conoceelpronostico_Familia)
            Me.addInputParameter("PideInfoFam", SqlDbType.VarChar, oIngresoaPrograma.Pideinformacion_Familia)
            Me.addInputParameter("PideNoInfFam", SqlDbType.VarChar, oIngresoaPrograma.Pidequenoseleinforme_Familia)
            Me.addInputParameter("CercoSilen", SqlDbType.VarChar, oIngresoaPrograma.CercodeSilencio)
            Me.addInputParameter("InfSuf", SqlDbType.VarChar, oIngresoaPrograma.Informacioninsuficiente)
            Me.addInputParameter("obs", SqlDbType.VarChar, oIngresoaPrograma.obs)
            Me.addInputParameter("login", SqlDbType.VarChar, oIngresoaPrograma.login)
            Me.addOutputParameter("Error", SqlDbType.Int, lerror)

            Me.Exec()

            lerror = Me.Parameters("Error").Value

            Return lerror

        End Function

#End Region

#Region "Preguntas"


        ''' <summary>
        ''' Consulta las Preguntas de CUidados Palitivos.
        ''' </summary>
        ''' <param name="oPreguntaCP"></param>
        ''' <returns></returns>
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

#Region "IngresoaPrograma"

        ''' <summary>
        ''' Consulta la Ultima Respuesta de Aspectos sociales registrados para paciente.
        ''' </summary>
        ''' <param name="IdPregunta"></param>
        ''' <param name="Respuesta"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ConsultarURIngresoaPrograma(ByVal IdPregunta As Integer, ByVal Respuesta As String) As IngresoaPrograma
            Dim dtIngresoaPrograma As New DataTable
            Dim oIngresoaPrograma As New IngresoaPrograma

            Me.setSQLSentence("pr_HC_CpConsultaURIngresoaPrograma", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("IdPregunta", SqlDbType.VarChar, IdPregunta)
            Me.addInputParameter("Respuesta", SqlDbType.VarChar, Respuesta)

            dtIngresoaPrograma = Me.execDT

            For Each row As DataRow In dtIngresoaPrograma.Rows

                oIngresoaPrograma.FechaIngreso = IIf(row.Item("Fec_Ingreso").ToString() = "", 0, row.Item("Fec_Ingreso"))
                oIngresoaPrograma.Harecibidoatencionpreviaporcuidadospaliativos = IIf(row.Item("AtencPrev").ToString() = "", 0, row.Item("AtencPrev"))
                oIngresoaPrograma.Donderecibioatencionporcuidadospaliativos = IIf(row.Item("LugarAtencion").ToString() = "", 0, row.Item("LugarAtencion"))
                oIngresoaPrograma.FechaDiagnostico = IIf(row.Item("Fec_Diagnostico").ToString() = "", 0, row.Item("Fec_Diagnostico"))
                oIngresoaPrograma.Harequeridoatencionporurgenciasuhospitalizacionenelultimomes = IIf(row.Item("ReqAten_HospUrg").ToString() = "", "", row.Item("ReqAten_HospUrg"))
                oIngresoaPrograma.Fechadelaatencionporurgencias_Hospitalizacion = IIf(row.Item("Fec_Aten_HospUrg").ToString() = "", "", row.Item("Fec_Aten_HospUrg"))
                oIngresoaPrograma.Laatencionporurgencias_hospitalizacionestaasociadacoeldiagnosticodebase = IIf(row.Item("Aten_Asoc_DiagBase").ToString() = "", 0, row.Item("Aten_Asoc_DiagBase"))
                oIngresoaPrograma.Observacionesdelaatencion_Urgencias_Hospitalizacion = IIf(row.Item("Obs_Aten_HospUrg").ToString() = "", 0, row.Item("Obs_Aten_HospUrg"))
                oIngresoaPrograma.Harequeridoatencionporcirugiaambulatoriaenelultimomes = IIf(row.Item("Aten_AmbUMes").ToString() = "", 0, row.Item("Aten_AmbUMes"))
                oIngresoaPrograma.Elpacienteestarecibiendoalgunadelassiguientesintervenciones = IIf(row.Item("Intervenciones").ToString() = "", 0, row.Item("Intervenciones"))
                oIngresoaPrograma.Observacionesintervencionespaliativos = IIf(row.Item("ObsIntervenciones").ToString() = "", 0, row.Item("ObsIntervenciones"))
                oIngresoaPrograma.Conoceeldiagnostico_Paciente = IIf(row.Item("ConDiagnPac").ToString() = "", 0, row.Item("ConDiagnPac"))
                oIngresoaPrograma.Conoceelpronostico_Paciente = IIf(row.Item("ConPronPac").ToString() = "", 0, row.Item("ConPronPac"))
                oIngresoaPrograma.Pideinformacion_Paciente = IIf(row.Item("PideInfoPac").ToString() = "", 0, row.Item("PideInfoPac"))
                oIngresoaPrograma.Pidequenoseleinforme_Paciente = IIf(row.Item("PideNoInfPac").ToString() = "", 0, row.Item("PideNoInfPac"))
                oIngresoaPrograma.Conoceeldiagnostico_Familia = IIf(row.Item("ConDiagnFam").ToString() = "", 0, row.Item("ConDiagnFam"))
                oIngresoaPrograma.Conoceelpronostico_Familia = IIf(row.Item("ConPronFam").ToString() = "", 0, row.Item("ConPronFam"))
                oIngresoaPrograma.Pideinformacion_Familia = IIf(row.Item("PideInfoFam").ToString() = "", 0, row.Item("PideInfoFam"))
                oIngresoaPrograma.Pidequenoseleinforme_Familia = IIf(row.Item("PideNoInfFam").ToString() = "", 0, row.Item("PideNoInfFam"))
                oIngresoaPrograma.CercodeSilencio = IIf(row.Item("CercoSilen").ToString() = "", 0, row.Item("CercoSilen"))
                oIngresoaPrograma.Informacioninsuficiente = IIf(row.Item("InfSuf").ToString() = "", 0, row.Item("InfSuf"))
            Next

            Return oIngresoaPrograma

        End Function


#End Region

#Region "Parametros Web Service Última Respuesta"

        ''' <summary>
        ''' Consulta la URL del servicio de Ultima Respuesta de Cuidados Paliativos.
        ''' </summary>
        ''' <param name=" cod_pre_sgs"></param>
        ''' <param name=" cod_sucur"></param>
        ''' <param name=" tip_servicio"></param>
        ''' <param name=" Nombre"></param>
        ''' <returns></returns>
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

    End Class
End Namespace