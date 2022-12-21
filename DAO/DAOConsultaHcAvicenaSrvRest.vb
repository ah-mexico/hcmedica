Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion

Imports System.Text
Imports System.IO
Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports System.Net

Namespace Sophia.HistoriaClinica.DAO

    Public Class DAOConsultaHcAvicenaSrvRest
        Dim objParametros As New DAO.DAOHerramientaEvaluacion
        Dim TParametro As New DataTable

        ''' <summary>
        ''' Metodo que consulta la información de los folios de la HC de un paciente  en avicena por medio de un servicio REST
        ''' </summary>
        ''' <param name="Tipo_Doc">Tipo Documento</param>
        ''' <param name="Num_Doc">Número Documento</param>
        ''' <param name="Fecha_ini">Fecha inicial de la Consulta</param>
        ''' <param name="Ip">Ip de la maquina donde se esta consultando</param>
        ''' <param name="login">Usuario quien consulta la HC</param>
        ''' <returns>Autor Raul Cruz Romero Fecha 2019/08/09</returns>
        Public Function consultaInformacionFoliosHCPaciente(ByVal Tipo_Doc As String, ByVal Num_Doc As String, ByVal Fecha_ini As String,
                                                            ByVal Ip As String, ByVal login As String) As List(Of JsonResultadoCunsultaFolios)


            Dim urlToPost As String = Nothing

            Dim webClient As New WebClient()
            Dim resByte As Byte()
            Dim resString As String
            Dim reqString() As Byte
            Dim resultado As New List(Of JsonResultadoCunsultaFolios)()


            'Se formatea la fecha de acuerdo a la solicitud de la capacidad de avicena
            Fecha_ini = Mid(Fecha_ini, 7, 10) + "-" + Mid(Fecha_ini, 4, 2) + "-" + Mid(Fecha_ini, 1, 2) + " 00:00:00"

            Dim dictData As New Dictionary(Of String, Object)
            dictData.Add("aplicacionSolicita", "SOPHIA")
            dictData.Add("codigoExternoTipoIdentificacion", Tipo_Doc)
            dictData.Add("fechaConsulta", Fecha_ini) '    
            dictData.Add("ipUsuarioSolicita", Ip)
            dictData.Add("loginUsuarioSolicita", login)
            dictData.Add("motivoSolicita", "Consultar folios en Avicena")
            dictData.Add("numeroIdentificacion", Num_Doc)

            Try
                'busco la url del servicio rest 
                urlToPost = ConsultarParametros("consultaHCAvicenaFolios")

                'Concateno la url mas la capacidad que voy a consumir
                urlToPost = urlToPost + "consultaInformacionFoliosHCPaciente"

                webClient.Headers("content-type") = "application/json"
                reqString = Encoding.Default.GetBytes(JsonConvert.SerializeObject(dictData, Formatting.Indented))
                resByte = webClient.UploadData(urlToPost, "post", reqString)
                resString = Encoding.Default.GetString(resByte)


                Dim ms As New MemoryStream(Encoding.Unicode.GetBytes(resString))
                Dim serializer As New System.Runtime.Serialization.Json.DataContractJsonSerializer(resultado.[GetType]())
                resultado = DirectCast(serializer.ReadObject(ms), List(Of JsonResultadoCunsultaFolios))
                ms.Close()
                ms.Dispose()

                webClient.Dispose()

                If resultado.Count = 1 Then
                    If resultado.Item(0).codigoMensajeServicio <> "0" Then

                        MsgBox(resultado.Item(0).mensajeServicio, MsgBoxStyle.Information)
                        resultado = Nothing

                    End If

                End If

            Catch ex As Exception
                MsgBox("Error consumiendo el metodo CONSULTAINFORMACIONFOLIOSHCPACIENTE del web services REST de avicena. " + ex.Message, MsgBoxStyle.Critical)

            End Try

            Return resultado

        End Function

        ''' <summary>
        ''' Metodo que consulta la información del folio en especifico de la HC de un paciente  en avicena por medio de un servicio REST
        ''' </summary>
        ''' <param name="Folio">Número de folio de la hc de avicena</param>
        ''' <param name="Ip">Ip de la maquina donde se genera la consulta</param>
        ''' <param name="login">Usuario quien genera la consulta</param>
        ''' <returns></returns>
        Public Function consultaHCFolioPaciente(ByVal Folio As String, ByVal Ip As String, ByVal login As String) As String


            Dim urlToPost As String

            Dim webClient As New WebClient()
            Dim resByte As Byte()
            Dim strRutaReporte As String
            Dim reqString() As Byte
            Dim resultado As New JsonResultadoUrlReporte()
            Dim dictData As New Dictionary(Of String, Object)

            Try
                'busco la url del servicio rest 
                urlToPost = ConsultarParametros("consultaHCAvicenaFolios")

                'Concateno la url mas la capacidad que voy a consumir
                urlToPost = urlToPost + "consultaHCFolioPaciente"

                dictData.Add("aplicacionSolicita", "SOPHIA")
                dictData.Add("folio", Folio)
                dictData.Add("ipUsuarioSolicita", Ip)
                dictData.Add("loginUsuarioSolicita", login)
                dictData.Add("motivoSolicita", "Consultar por folio en Avicena")

                webClient.Headers("content-type") = "application/json"
                reqString = Encoding.Default.GetBytes(JsonConvert.SerializeObject(dictData, Formatting.Indented))
                resByte = webClient.UploadData(urlToPost, "post", reqString)
                strRutaReporte = Encoding.Default.GetString(resByte)

                Dim ms As New MemoryStream(Encoding.Unicode.GetBytes(strRutaReporte))
                Dim serializer As New System.Runtime.Serialization.Json.DataContractJsonSerializer(resultado.[GetType]())
                resultado = DirectCast(serializer.ReadObject(ms), JsonResultadoUrlReporte)
                ms.Close()
                ms.Dispose()

                webClient.Dispose()

                If resultado.codigoMensajeServicio <> "0" Then

                    MsgBox("IDMensaje: " + resultado.codigoMensajeServicio.ToString + " Mensaje " + resultado.mensajeServicio, MsgBoxStyle.Critical)
                    Return ""
                End If

                Return resultado.urlReporteHC

            Catch ex As Exception
                MsgBox("Error consultando la URL reporte  del webservice RES. " + ex.Message, MsgBoxStyle.Information)
                Return ""
            End Try



        End Function
        ''' <summary>
        ''' Función que consulta el parámetro solicitado
        ''' </summary>
        ''' <param name="Parametro">Variable del parámetro a consultar</param>
        ''' <returns></returns>
        Private Function ConsultarParametros(Parametro As String) As String
            Dim ValorParametro As String = ""
            Try

                TParametro = objParametros.ConsultarDiasHistorico(Parametro)

                If TParametro.Rows.Count > 0 Then
                    ValorParametro = TParametro.Rows(0).Item("valor").ToString

                Else
                    MsgBox("No se encontró el parámetro (" + Parametro + " en la tabla Genparsophia), contáctese con el administrador del sistema.", MsgBoxStyle.Critical)

                End If

            Catch ex As Exception
                MsgBox("Error al validar" + Parametro + " : " + ex.Message, MsgBoxStyle.Critical)
            End Try

            Return ValorParametro
        End Function


    End Class




    ''' <summary>
    ''' Clase que retorna el Json del metodo consultaInformacionFoliosHCPaciente
    ''' </summary>
    Public Class JsonResultadoCunsultaFolios
        Public Property folio As Integer?
        Public Property codigoExternoTipoIdentificacion As String
        Public Property tipoDocumento As String
        Public Property numeroIdentificacion As String
        Public Property nombrePaciente As String
        Public Property fechaFolio As String
        Public Property nombreMedico As String
        Public Property codigoEspecialidad As String
        Public Property codExternoEspecialidad As String
        Public Property especialidad As String
        Public Property codSucursal As String
        Public Property codExternoSucursal As String
        Public Property sucursal As String
        Public Property servicioMedico As String
        Public Property tipoAdmision As String
        Public Property tipoFolio As String
        Public Property programaPYP As String
        Public Property codigoMensajeServicio As String
        Public Property mensajeServicio As String
    End Class

    ''' <summary>
    ''' Clase que retorna el Json del metodo consultaHCFolioPaciente
    ''' </summary>
    Public Class JsonResultadoUrlReporte
        Public Property urlReporteHC As String
        Public Property codigoMensajeServicio As String
        Public Property mensajeServicio As String
    End Class

End Namespace