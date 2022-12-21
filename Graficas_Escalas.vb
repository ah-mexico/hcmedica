Imports System.IO
Imports System.Collections
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.HistoriaBasica
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports System.Collections.Generic
Imports HistoriaClinica.wsCuidadoPaliativo
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Graficas_Escalas

    Inherits System.Windows.Forms.Form
    Private objGeneral As Generales
    Private objPaciente As Paciente

    Public Sub Mostrar(ByVal intOpcion As Integer, ByVal strTipo_Doc As String, ByVal strNum_Doc As String, ByVal intIdPregunta As Integer, _
                       ByVal strTitulo As String)

        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia

        Dim dtGrafica As New DataTable
        Dim objEscalas As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOHerramientaEvaluacion
        Dim srvHerramientaEvaluacion As New CuidadosPaleativosServiceImpService()
        Dim aPreHisAvicena As New UltimaRespuestaResquestType
        Dim aPreHisPreguntas(1) As Long
        Dim aUltimaRespuesta() As GrupoFechaType
        Dim DAOCP As New DAOCuidadosPaliativos()
        Dim Resultado As String
        Dim appOrigen As String = objPaciente.AppOrigenCP.ToUpper()
        Dim Fecha As String
        Dim dtDato As New DataTable
        Dim Dias As Integer = 0
        Dim strIP As String = ""
        Dim strHostName As String
        Dim strMensaje As String = ""

        strHostName = System.Net.Dns.GetHostName()
        strIP = System.Net.Dns.GetHostByName(strHostName).AddressList(0).ToString()

        strMensaje = objEscalas.InserRegHistoGRaficaSophia(intOpcion, Me.objPaciente.TipoDocumento, Me.objPaciente.NumeroDocumento, intIdPregunta, strIP)

        Try

            srvHerramientaEvaluacion.Url = DAOCP.ConsultarUrlServicioUT(objGeneral.Prestador, objGeneral.Sucursal, DAOCP.TipoServicio, DAOCP.MetodoServicioH)
            If srvHerramientaEvaluacion.Url = "" Then
                Throw New Exception("No fue posible consultar el servicio de últimas respuestas (URL).")
            End If

            dtDato = objEscalas.ConsultarDiasHistorico("Historico_Paliativos")
            If dtDato.Rows.Count = 0 Then
                MsgBox("No existen parametros para el calulo de dias historico paliativos")
            Else
                Dias = dtDato.Rows(0).Item("valor").ToString
            End If

            aPreHisAvicena.tipoDocumento = objPaciente.TipoDocumento
            aPreHisAvicena.numeroDocumento = objPaciente.NumeroDocumento
            aPreHisPreguntas(0) = intIdPregunta
            aPreHisAvicena.preguntas = aPreHisPreguntas
            aPreHisAvicena.origen = appOrigen
            ''WACHV, 22Dic2017, Se agrega Obtener la ref regional en cada Bd
            '',se cambia parametro de regional objPaciente.Ciudad.ToUpper() por lo retornado en strRegionalRefBD
            Dim strRegionalRefBD As String = DAOCP.ConsultarRegional()
            aPreHisAvicena.regional = strRegionalRefBD.ToUpper()
            Fecha = Format(DateTime.Now, "yyyy-MM-dd")
            Fecha = Fecha & " 23:59:59"

            Resultado = srvHerramientaEvaluacion.historicoRespuestas(aPreHisAvicena, Dias, Fecha, DAOCP.ProgramaH.ToUpper(), DAOCP.SeccionH.ToUpper(), DAOCP.SubSeccionH.ToUpper(), aUltimaRespuesta)

            For i As Integer = aUltimaRespuesta.Length - 1 To 0 Step -1
                Dim pr As GrupoFechaType = aUltimaRespuesta(i)
                If Not pr.resultadosHist Is Nothing Then
                    If pr.resultadosHist.Length > 0 Then
                        For j As Integer = 0 To pr.resultadosHist.Length - 1
                            strMensaje = objEscalas.InserRegHistoAvicena(pr.resultadosHist(j).idPregunta, pr.fecha, pr.resultadosHist(j).interpretacion, strIP, "AVICENA")
                        Next
                    End If
                End If
            Next

        Catch ex As Exception
            'Throw ex                
            'MsgBox("No existen datos para la grafica de AVICENA")
        End Try

        dtGrafica = objEscalas.CargarDatosGraficasEscalas(strIP)
        Dim dvGrafica As New DataView(dtGrafica)
        'dvGrafica.Sort = "Fechareg"

        Dim DTOrdenado As DataTable = dvGrafica.ToTable

        If DTOrdenado.Rows.Count = 0 Then
            MsgBox("No existen datos para la grafica")
        Else
            If intOpcion = 3 Then
                Me.GrafEscalas.ChartAreas("GrSophia").AxisY.Maximum = 11
                Me.GrafEscalas.ChartAreas("GrSophia").AxisY.Minimum = 0
                Me.GrafEscalas.ChartAreas("GrAvicena").AxisY.Maximum = 11
                Me.GrafEscalas.ChartAreas("GrAvicena").AxisY.Minimum = 0
            End If
            If intOpcion = 4 Then
                Me.GrafEscalas.ChartAreas("GrSophia").AxisY.Maximum = 25
                Me.GrafEscalas.ChartAreas("GrSophia").AxisY.Minimum = -1
                Me.GrafEscalas.ChartAreas("GrAvicena").AxisY.Maximum = 25
                Me.GrafEscalas.ChartAreas("GrAvicena").AxisY.Minimum = -1
            End If
            Me.GrafEscalas.Series("Sophia").Points.Clear()
            Me.GrafEscalas.Series("Avicena").Points.Clear()
            For i As Integer = 0 To dtGrafica.Rows.Count - 1
                'If DTOrdenado.Rows(i).Item("obs").ToString = "SOPHIA" Then                    
                Me.GrafEscalas.Series("Sophia").Points.AddXY(DTOrdenado.Rows(i).Item("fec_reg").ToString, DTOrdenado.Rows(i).Item("Respuesta").ToString)
                'Me.GrafEscalas.Series("Avicena").Points.AddXY(DBNull.Value, DBNull.Value)
                'End If
                'If DTOrdenado.Rows(i).Item("obs").ToString = "AVICENA" Then
                'Me.GrafEscalas.Series("Avicena").Points.AddXY(DTOrdenado.Rows(i).Item("fec_reg").ToString, DTOrdenado.Rows(i).Item("Respuesta").ToString)
                'Me.GrafEscalas.Series("Sophia").Points.AddXY(DBNull.Value, DBNull.Value)
                'End If
            Next
            Me.Text = "GRAFICA"
            Me.GrafEscalas.Titles("TituloEscala").Text = strTitulo

            Me.ShowDialog()
        End If

       

    End Sub
End Class