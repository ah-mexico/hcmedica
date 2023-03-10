Imports System
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.HistoriaBasica
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes.FuncionesGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports Historiaclinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.wsCuidadoPaliativo

Namespace Sophia.HistoriaClinica.DAO
    Public Class DAOReunionFamiliar
        Inherits GPMData

        Public Function CargarEspecialidades(ByVal IdPreg As Integer) As DataTable
            Dim dt As New DataTable
            Me.setSQLSentence("pr_HC_CpConsultaParametrica", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("id", SqlDbType.Int, System.DBNull.Value)
            Me.addInputParameter("descripcion", SqlDbType.VarChar, System.DBNull.Value)
            Me.addInputParameter("id_seccion", SqlDbType.Int, System.DBNull.Value)
            Me.addInputParameter("id_av", SqlDbType.VarChar, System.DBNull.Value)
            Me.addInputParameter("puntaje", SqlDbType.Int, System.DBNull.Value)
            Me.addInputParameter("login", SqlDbType.Int, System.DBNull.Value)
            Me.addInputParameter("fec_con", SqlDbType.DateTime, System.DBNull.Value)
            Me.addInputParameter("obs", SqlDbType.VarChar, System.DBNull.Value)
            Me.addInputParameter("id_pregunta", SqlDbType.Int, IdPreg)
            dt = Me.execDT
            Return dt
        End Function

        Public Function CargarTipoParentesco() As DataTable
            Dim dt As New DataTable
            Me.setSQLSentence("pr_HC_CpConsultaParentesco", CommandType.StoredProcedure)
            Me.ClearParameters()
            dt = Me.execDT
            Return dt
        End Function

#Region "Actualizar Información Reunión Familiar"
        Public Function DAOActualizarDataReunionFamiliar(ByVal objReunionFamiliar As BL.BLReunionFamiliar) As String
            Try
                Dim separador As String = "<|^|>"
                Dim MensajeError As String = ""
                Dim codError As Integer = 0

                Me.BeginTransaction()

                With objReunionFamiliar
                    Me.setSQLSentence("pr_Hc_CpInsertaReunionFamiliar", CommandType.StoredProcedure)
                    Me.ClearParameters()
                    EstablecerParametrosInicialesRequeridos(objReunionFamiliar)

                    Me.addInputParameter("InformacionReunion", SqlDbType.VarChar, .InformacionReunion)
                    Me.addInputParameter("PreocDifEmergentes", SqlDbType.VarChar, .PreocupacionesDificultadesEmergentes)
                    Me.addInputParameter("TemasPendientes", SqlDbType.VarChar, .TemasPendientes)
                    Me.addInputParameter("EstrategiasSeguir", SqlDbType.VarChar, .EstrategiasASeguir)

                    Me.Exec()

                    MensajeError = Me.Parameters("strMensaje").Value
                    codError = Me.Parameters("Error").Value

                    If Not codError > 0 Then
                        MensajeError = String.Empty
                        codError = 0

                        Me.setSQLSentence("pr_Hc_CpInsertaParticipantesReunionFamiliar", CommandType.StoredProcedure)
                        Me.ClearParameters()
                        EstablecerParametrosInicialesRequeridos(objReunionFamiliar)

                        Dim intIdPreguntaCaracteristica As Integer
                        Dim strIdsCaracteristicaPartipante As String = String.Empty
                        Dim strNombresCaracteristicaPartipante As String = String.Empty
                        Dim intIdPreguntaNombre As Integer
                        Dim strIdsRespuestasPreguntaNombre As String = String.Empty
                        Dim strNombresPartipante As String = String.Empty
                        Dim tmp As String

                        For Each preg As BLParticipantesReunion In .ParticipantesEquipoReunion
                            intIdPreguntaNombre = preg.IdPreguntaNombre
                            tmp = strIdsRespuestasPreguntaNombre
                            strIdsRespuestasPreguntaNombre += IIf(Not tmp = String.Empty, separador, "") + preg.IdRespuestaNombre.ToString()
                            tmp = strNombresPartipante
                            strNombresPartipante += IIf(Not tmp = String.Empty, separador, "") + preg.NombreParticipante

                            intIdPreguntaCaracteristica = preg.IdPreguntaCaracteristica
                            tmp = strIdsCaracteristicaPartipante
                            strIdsCaracteristicaPartipante += IIf(Not tmp = String.Empty, separador, "") + preg.IdCaracteriscitaParticipante.ToString()
                            tmp = strNombresCaracteristicaPartipante
                            strNombresCaracteristicaPartipante += IIf(Not tmp = String.Empty, separador, "") + preg.NombreCaracteristicaParticipante
                        Next

                        Me.addInputParameter("IdPreguntaCaracteristica", SqlDbType.Int, intIdPreguntaCaracteristica)
                        Me.addInputParameter("IdsCaracteristicaPartipante", SqlDbType.VarChar, strIdsCaracteristicaPartipante)
                        Me.addInputParameter("NombresCaracteristicaPartipante", SqlDbType.VarChar, strNombresCaracteristicaPartipante)
                        Me.addInputParameter("IdPreguntaNombre", SqlDbType.Int, intIdPreguntaNombre)
                        Me.addInputParameter("IdsRespuestasPreguntaNombre", SqlDbType.VarChar, strIdsRespuestasPreguntaNombre)
                        Me.addInputParameter("NombresPartipante", SqlDbType.VarChar, strNombresPartipante)

                        Me.Exec()

                        MensajeError = Me.Parameters("strMensaje").Value
                        codError = Me.Parameters("Error").Value

                        If Not codError > 0 Then
                            MensajeError = String.Empty
                            codError = 0

                            intIdPreguntaCaracteristica = Nothing
                            strIdsCaracteristicaPartipante = String.Empty
                            strNombresCaracteristicaPartipante = String.Empty
                            intIdPreguntaNombre = Nothing
                            strIdsRespuestasPreguntaNombre = String.Empty
                            strNombresPartipante = String.Empty
                            tmp = String.Empty

                            For Each preg As BLParticipantesReunion In .ParticipantesFamiliaReunion
                                intIdPreguntaNombre = preg.IdPreguntaNombre
                                tmp = strIdsRespuestasPreguntaNombre
                                strIdsRespuestasPreguntaNombre += IIf(Not tmp = String.Empty, separador, "") + preg.IdRespuestaNombre.ToString()
                                tmp = strNombresPartipante
                                strNombresPartipante += IIf(Not tmp = String.Empty, separador, "") + preg.NombreParticipante

                                intIdPreguntaCaracteristica = preg.IdPreguntaCaracteristica
                                tmp = strIdsCaracteristicaPartipante
                                strIdsCaracteristicaPartipante += IIf(Not tmp = String.Empty, separador, "") + preg.IdCaracteriscitaParticipante.ToString()
                                tmp = strNombresCaracteristicaPartipante
                                strNombresCaracteristicaPartipante += IIf(Not tmp = String.Empty, separador, "") + preg.NombreCaracteristicaParticipante
                            Next

                            Me.Parameters("IdPreguntaNombre").Value = intIdPreguntaNombre
                            Me.Parameters("IdsRespuestasPreguntaNombre").Value = strIdsRespuestasPreguntaNombre
                            Me.Parameters("NombresPartipante").Value = strNombresPartipante
                            Me.Parameters("IdPreguntaCaracteristica").Value = intIdPreguntaCaracteristica
                            Me.Parameters("IdsCaracteristicaPartipante").Value = strIdsCaracteristicaPartipante
                            Me.Parameters("NombresCaracteristicaPartipante").Value = strNombresCaracteristicaPartipante

                            Me.Exec()

                            MensajeError = Me.Parameters("strMensaje").Value
                            codError = Me.Parameters("Error").Value
                        End If

                        If codError > 0 Then
                            Throw New Exception("Se presento un problema al registrar la información en pr_Hc_CpInsertaParticipantesReunionFamiliar" + Environment.NewLine + Environment.NewLine _
                            + "Código Error: " + Convert.ToString(codError) + Environment.NewLine _
                            + "Mensaje Error: " + MensajeError)
                        End If
                    Else
                        Throw New Exception("Se presento un problema al registrar la información en pr_Hc_CpInsertaReunionFamiliar" + Environment.NewLine + Environment.NewLine _
                                + "Código Error: " + Convert.ToString(codError) + Environment.NewLine _
                                + "Mensaje Error: " + MensajeError)
                    End If
                End With

                Me.Commit()

                Return MensajeError
            Catch ex As Exception
                Me.Rollback()
                Throw ex
            End Try
        End Function

        Private Sub EstablecerParametrosInicialesRequeridos(ByVal obj As BLReunionFamiliar)
            With obj
                Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, .Prestador)
                Me.addInputParameter("cod_sucur", SqlDbType.VarChar, .Sucursal)
                Me.addInputParameter("tip_admision", SqlDbType.VarChar, .TipoAdmision)
                Me.addInputParameter("ano_adm", SqlDbType.Int, .AnioAdmision)
                Me.addInputParameter("num_adm", SqlDbType.Decimal, .NumAdmision)
                Me.addInputParameter("tip_doc", SqlDbType.VarChar, .TipoDocumento)
                Me.addInputParameter("num_doc", SqlDbType.VarChar, .NumDocumento)
                Me.addInputParameter("obs", SqlDbType.VarChar, IIf(.Observaciones Is Nothing, String.Empty, .Observaciones))
                Me.addInputParameter("login", SqlDbType.VarChar, .Login)

                Me.addOutputParameter("Error", SqlDbType.BigInt)
                Me.addOutputParameter("strMensaje", SqlDbType.VarChar, 8000)
            End With
        End Sub

        ''' <summary>
        ''' Consulta la Ultima Respuesta del módulo Reunion Familiar registrados para paciente.
        ''' </summary>
        ''' <param name="ultimasRespuestas"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ConsultarURReunionFamiliar(ByVal ultimasRespuestas() As PreguntaType) As BLReunionFamiliar
            Dim oReunionFamiliar As New BLReunionFamiliar
            Dim listadoParticipantesEquipo() As String
            Dim listadoEspecialidadEquipo() As String
            Dim listadoParticipantesFamilia() As String
            Dim listadoVinculoFamilia() As String

            For Each pr As PreguntaType In ultimasRespuestas
                With oReunionFamiliar
                    Select Case pr.idPregunta
                        Case 601
                            If Not pr.respuestas.listadoIdRespuesta Is Nothing AndAlso pr.respuestas.listadoIdRespuesta.Length > 0 Then
                                listadoParticipantesEquipo = pr.respuestas.listadoIdRespuesta()
                            End If
                        Case 602
                            If Not pr.respuestas.listadoIdRespuesta Is Nothing AndAlso pr.respuestas.listadoIdRespuesta.Length > 0 Then
                                listadoEspecialidadEquipo = pr.respuestas.listadoIdRespuesta()
                            End If
                        Case 603
                            If Not pr.respuestas.listadoIdRespuesta Is Nothing AndAlso pr.respuestas.listadoIdRespuesta.Length > 0 Then
                                listadoParticipantesFamilia = pr.respuestas.listadoIdRespuesta()
                            End If
                        Case 604
                            If Not pr.respuestas.listadoIdRespuesta Is Nothing AndAlso pr.respuestas.listadoIdRespuesta.Length > 0 Then
                                listadoVinculoFamilia = pr.respuestas.listadoIdRespuesta()
                            End If
                        Case 605
                            .InformacionReunion = IIf(Not pr.respuestas.textoRespuesta Is Nothing, pr.respuestas.textoRespuesta, String.Empty)
                        Case 606
                            .PreocupacionesDificultadesEmergentes = IIf(Not pr.respuestas.textoRespuesta Is Nothing, pr.respuestas.textoRespuesta, String.Empty)
                        Case 607
                            .TemasPendientes = IIf(Not pr.respuestas.textoRespuesta Is Nothing, pr.respuestas.textoRespuesta, String.Empty)
                        Case 608
                            .EstrategiasASeguir = IIf(Not pr.respuestas.textoRespuesta Is Nothing, pr.respuestas.textoRespuesta, String.Empty)
                    End Select
                End With
            Next

            'With oReunionFamiliar
            '    If Not listadoEspecialidadEquipo Is Nothing Then
            '        For index As Integer = 0 To listadoEspecialidadEquipo.Length - 1
            '            Dim tmpObj As New BLParticipantesReunion()
            '            With tmpObj
            '                .IdPreguntaNombre = 601
            '                .IdRespuestaNombre = 60101
            '                If Not listadoParticipantesEquipo Is Nothing Then
            '                    .NombreParticipante = IIf(listadoParticipantesEquipo.Length > 0, listadoParticipantesEquipo(index).ToString(), String.Empty)
            '                Else
            '                    .NombreParticipante = String.Empty
            '                End If
            '                .IdPreguntaCaracteristica = 602
            '                .IdCaracteriscitaParticipante = IIf(listadoEspecialidadEquipo.Length > 0, listadoEspecialidadEquipo(index).ToString(), 1)
            '                .NombreCaracteristicaParticipante = ""
            '            End With
            '            .ParticipantesEquipoReunion.Add(tmpObj)
            '        Next
            '    End If

            '    If Not listadoVinculoFamilia Is Nothing Then
            '        For index As Integer = 0 To listadoVinculoFamilia.Length - 1
            '            Dim tmpObj As New BLParticipantesReunion()
            '            With tmpObj
            '                .IdPreguntaNombre = 603
            '                .IdRespuestaNombre = 60301
            '                If Not listadoParticipantesFamilia Is Nothing Then
            '                    .NombreParticipante = IIf(listadoParticipantesFamilia.Length > 0, listadoParticipantesFamilia(index).ToString(), String.Empty)
            '                Else
            '                    .NombreParticipante = String.Empty
            '                End If
            '                .IdPreguntaCaracteristica = 604
            '                .IdCaracteriscitaParticipante = 60401
            '                .NombreCaracteristicaParticipante = IIf(listadoVinculoFamilia.Length > 0, listadoVinculoFamilia(index), 1)
            '            End With
            '            .ParticipantesFamiliaReunion.Add(tmpObj)
            '        Next
            '    End If
            'End With

            Return oReunionFamiliar
        End Function

        Public Function obtenerParticipantesReunion(ByVal tipoDocumento As String, ByVal numeroDocumento As String, ByVal tipoParticipante As String) As DataTable

            Me.setSQLSentence("pr_Hc_CpConsultaProponerParticipantesReunion", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("tipo_reunion", SqlDbType.VarChar, tipoParticipante)
            Me.addInputParameter("tip_doc", SqlDbType.VarChar, tipoDocumento)
            Me.addInputParameter("num_doc", SqlDbType.VarChar, numeroDocumento)

            Return Me.execDT

        End Function
#End Region
    End Class
End Namespace
