Imports System
Imports System.Collections.Generic
Imports HistoriaClinica.wsCuidadoPaliativo

Namespace Sophia.HistoriaClinica.DAO
    Public Class DAOComplejidadDerivacion
        Inherits GPMData

        Public Function GuardarPreguntasComplejidadDerivacion(ByRef complejidadDerivacion As ComplejidadDerivacion) As String
            Dim MensajeError As String = ""
            Dim codError As Integer = 0

            Me.setSQLSentence("pr_HC_CpInsertaComplejidadDerivacion", CommandType.StoredProcedure)
            Me.ClearParameters()
            With complejidadDerivacion
                Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, .Prestador)
                Me.addInputParameter("cod_sucur", SqlDbType.VarChar, .Sucursal)
                Me.addInputParameter("tip_admision", SqlDbType.VarChar, .TipoAdmision)
                Me.addInputParameter("ano_adm", SqlDbType.Int, .AnoAdmision)
                Me.addInputParameter("num_adm", SqlDbType.Decimal, .NumeroAdmision)
                Me.addInputParameter("tip_doc", SqlDbType.VarChar, .TipoDocumento)
                Me.addInputParameter("num_doc", SqlDbType.VarChar, .NumeroDocumento)
                Me.addInputParameter("obs", SqlDbType.VarChar, .Observaciones)
                Me.addInputParameter("login", SqlDbType.VarChar, .Login)
                For Each preg As PreguntaComplejidad In .itemsComplejidadClinica
                    Me.addInputParameter(preg.NombreCampo, SqlDbType.VarChar, preg.RespuestaPregunta)
                Next
                For Each preg As PreguntaComplejidad In .itemsComplejidadPsicosocial
                    Me.addInputParameter(preg.NombreCampo, SqlDbType.VarChar, preg.RespuestaPregunta)
                Next
                For Each preg As PreguntaComplejidad In .itemsComplejidadAtencion
                    Me.addInputParameter(preg.NombreCampo, SqlDbType.VarChar, preg.RespuestaPregunta)
                Next
                For Each preg As PreguntaComplejidad In .itemsDerivacion
                    Me.addInputParameter(preg.NombreCampo, SqlDbType.VarChar, preg.RespuestaPregunta)
                Next

                Me.addInputParameter("Preg523", SqlDbType.VarChar, .LugarDerivacionNva)  '''WACHV,24OCT2017, PARA LA NVA VARIBALE 
                ''WACHV, INICIO, 25SEPT2017, SE GUARDAN NUEVAS PREGUNTAS
                Me.addInputParameter("Preg524", SqlDbType.VarChar, .TotalComplejidadClinica)       ''Total Complejidad Clinica
                Me.addInputParameter("Preg525", SqlDbType.VarChar, .TotalComplejidadPsicoSocial)   ''Total Complejidad Psicosocial	
                Me.addInputParameter("Preg526", SqlDbType.VarChar, .TotalComplejidadAtencion)      ''Total Complejidad Atencion	

                ''WACHV, FIN, 25SEPT2017, SE GUARDAN NUEVAS PREGUNTAS
            End With

            Me.addOutputParameter("Error", SqlDbType.BigInt)
            Me.addOutputParameter("strMensaje", SqlDbType.VarChar, 300)

            Me.Exec()

            MensajeError = Me.Parameters("strMensaje").Value
            codError = Me.Parameters("Error").Value

            Return MensajeError
        End Function

        Public Function ConsultarEscalaComplejidadDerivacion(ByVal escala As String, ByVal codPreSgs As String,
        ByVal codSucur As String, ByVal tipAdmision As String, ByVal anoAdm As Short, ByVal numAdm As Decimal) As Short
            Dim mensajeError As String = ""
            Dim codError As Integer = 0
            Dim puntajeEscala As Short

            Me.setSQLSentence("pr_HC_CpConsultarEscalaComplejidadDerivacion", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, codPreSgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, codSucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tipAdmision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, anoAdm)
            Me.addInputParameter("num_adm", SqlDbType.Decimal, numAdm)
            Me.addInputParameter("escala", SqlDbType.VarChar, escala)
            Me.addOutputParameter("puntaje", SqlDbType.Int)
            Me.addOutputParameter("Error", SqlDbType.BigInt)
            Me.addOutputParameter("strMensaje", SqlDbType.VarChar, 300)

            Me.Exec()

            mensajeError = Me.Parameters("strMensaje").Value
            codError = Me.Parameters("Error").Value

            puntajeEscala = Me.Parameters("puntaje").Value

            Return puntajeEscala
        End Function

        ''' <summary>
        ''' Consulta la Ultima Respuesta del módulo Complejidad Derivación registrados para paciente.
        ''' </summary>
        ''' <param name="IdPregunta"></param>
        ''' <param name="Respuesta"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ConsultarURComplejidadDerivacion(ByVal ultimasRespuestas() As PreguntaType) As ComplejidadDerivacion
            Dim dtComplejidaDerivaion As New DataTable
            Dim oComplejidaDerivaion As New ComplejidadDerivacion
            Me.setSQLSentence("pr_HC_CpConsultaURComplejidadDerivacion", CommandType.StoredProcedure)

            Try

                For Each pr As PreguntaType In ultimasRespuestas
                    If (Not pr.respuestas.listadoIdRespuesta Is Nothing AndAlso pr.respuestas.listadoIdRespuesta.Length > 0) _
                OrElse pr.respuestas.textoRespuesta <> Nothing Then
                        Me.ClearParameters()
                        Me.addInputParameter("IdPregunta", SqlDbType.VarChar, pr.idPregunta)
                        If Not pr.respuestas.textoRespuesta Is Nothing Then
                            Me.addInputParameter("Respuesta", SqlDbType.VarChar, pr.respuestas.textoRespuesta)
                        Else
                            Me.addInputParameter("Respuesta", SqlDbType.VarChar, pr.respuestas.listadoIdRespuesta(0).ToString())
                        End If

                        dtComplejidaDerivaion = Me.execDT

                        For Each row As DataRow In dtComplejidaDerivaion.Rows
                            Dim item As New PreguntaComplejidad()
                            For i As Integer = 1 To 26
                                With item
                                    .NombreCampo = "Preg5" & IIf(i.ToString.Length = 2, i, "0" & i)
                                    If (Not row.Item(.NombreCampo).ToString() = "") Then
                                        Select Case i
                                            Case 1 To 3
                                                .RespuestaPregunta = row.Item(.NombreCampo)
                                                oComplejidaDerivaion.itemsComplejidadClinica.Add(item)
                                                Exit For
                                            Case 4 To 13
                                                .RespuestaPregunta = row.Item(.NombreCampo)
                                                oComplejidaDerivaion.itemsComplejidadPsicosocial.Add(item)
                                                Exit For
                                            Case 14 To 19
                                                .RespuestaPregunta = row.Item(.NombreCampo)
                                                oComplejidaDerivaion.itemsComplejidadAtencion.Add(item)
                                                Exit For
                                            Case 20 To 22
                                                .RespuestaPregunta = row.Item(.NombreCampo)
                                                oComplejidaDerivaion.itemsComplejidadAtencion.Add(item)
                                                Exit For
                                            Case 23 ''LUgar derivacion
                                                .RespuestaPregunta = row.Item(.NombreCampo)
                                                oComplejidaDerivaion.LugarDerivacionNva = item.RespuestaPregunta
                                                Exit For
                                            Case 24 ''Total Complejidad Clinica
                                                .RespuestaPregunta = row.Item(.NombreCampo)
                                                oComplejidaDerivaion.TotalComplejidadClinica = pr.respuestas.textoRespuesta
                                                Exit For
                                            Case 25 '' Total Complejidad Psicosocial
                                                .RespuestaPregunta = row.Item(.NombreCampo)
                                                oComplejidaDerivaion.TotalComplejidadPsicoSocial = pr.respuestas.textoRespuesta
                                                Exit For
                                            Case 26 '' Total Complejidad de la Atencion
                                                .RespuestaPregunta = row.Item(.NombreCampo)
                                                oComplejidaDerivaion.TotalComplejidadAtencion = pr.respuestas.textoRespuesta
                                                Exit For
                                        End Select
                                    End If
                                End With
                            Next

                            'If item.NombreCampo.ToString() = "Preg524" Then  ''TotalComplejidadClinica
                            '    oComplejidaDerivaion.TotalComplejidadClinica = pr.respuestas.textoRespuesta
                            '    Exit For
                            'End If
                            'If item.NombreCampo.ToString() = "Preg525" Then  ''TotalComplejidadPsicoSocial
                            '    oComplejidaDerivaion.TotalComplejidadPsicoSocial = pr.respuestas.textoRespuesta
                            '    Exit For
                            'End If
                            'If item.NombreCampo.ToString() = "Preg526" Then  ''TotalComplejidadAtencion
                            '    oComplejidaDerivaion.TotalComplejidadPsicoSocial = pr.respuestas.textoRespuesta
                            '    Exit For
                            'End If
                        Next
                    End If
                Next
                Return oComplejidaDerivaion
            Catch ex As Exception
                Throw (ex)
            End Try

        End Function

        ''WACHV, 24OCT2017, SE CREA PARA CARGAR EL COMBO
        Public Function CargarCombo(ByVal idCombo As Integer, Optional ByVal strFiltro As String = Nothing) As DataTable
            Dim dt As New DataTable
            Me.ParametersCollection.Clear()
            Select Case idCombo
                Case 1  'Consulta Lugar Derivacion
                    setSQLSentence("pr_HC_CpConsultaLugarDerivacion", CommandType.StoredProcedure)
            End Select

            dt = Me.execDT()

            Return dt
        End Function

    End Class
End Namespace