Imports System.Linq
Imports System.Net
Imports System.Net.NetworkInformation
Imports System.Net.Sockets
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports HistoriaClinica.wsResultadosLaboratorio

''' <summary>
''' Expone la funcionalidad para el formulario de resultados de laboratorio
''' </summary>
''' <author>Jimmy Leandro Guevara Sanabria - jguevara@intergrupo.com.</author>
''' <datetime>24/01/2018.</datetime>
Public Class frmConsultaResultadosLab
    Private objDatosGenerales As Generales
    Dim objBl As New Sophia.HistoriaClinica.BL.BLRptHC_Enf_Med
#Region "Variables"

    ''' <summary>
    ''' Variable que define el tipo de servicio para la consulta de los parametros
    ''' </summary>
    ''' <author>Jimmy Leandro Guevara Sanabria - jguevara@intergrupo.com.</author>
    ''' <datetime>24/01/2018.</datetime>
    Public Const TipoServicio As String = "RL"

    ''' <summary>
    ''' Variable que define el nombre del parametro que se quiere consultar en base de datos 
    ''' </summary>
    ''' <author>Jimmy Leandro Guevara Sanabria - jguevara@intergrupo.com.</author>
    ''' <datetime>24/01/2018.</datetime>
    Public Const MetodoServicioDatosConsulta As String = "fncGetSolicitudesByPacienteByFechas"

    ''' <summary>
    ''' Variable que define el nombre del parametro que se quiere consultar en base de datos 
    ''' </summary>
    ''' <author>Jimmy Leandro Guevara Sanabria - jguevara@intergrupo.com.</author>
    ''' <datetime>24/01/2018.</datetime>
    Public Const MetodoServicioDatosPdf As String = "fncGetURLPDF"

    ''' <summary>
    ''' Objeto que contiene los datos generales de la aplicacion
    ''' </summary>
    ''' <author>Jimmy Leandro Guevara Sanabria - jguevara@intergrupo.com.</author>
    ''' <datetime>24/01/2018.</datetime>
    Private objGeneral As Generales

    ''' <summary>
    ''' Objeto que contiene los datos generales del paciente
    ''' </summary>
    ''' <author>Jimmy Leandro Guevara Sanabria - jguevara@intergrupo.com.</author>
    ''' <datetime>24/01/2018.</datetime>
    Private objPaciente As Sophia.HistoriaClinica.DatosPaciente.Paciente

    ''' <summary>
    ''' Objeto que instancia la clase DAOHerramientaEvaluacion para la consulta de parametros
    ''' </summary>
    ''' <author>Jimmy Leandro Guevara Sanabria - jguevara@intergrupo.com.</author>
    ''' <datetime>24/01/2018.</datetime>
    Dim objEscalas As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOHerramientaEvaluacion

    ''' <summary>
    ''' Variable que contendra los rangos de tiempo
    ''' </summary>
    ''' <author>Jimmy Leandro Guevara Sanabria - jguevara@intergrupo.com.</author>
    ''' <datetime>24/01/2018.</datetime>
    Dim rangoTiempo As DataTable

#End Region

    ''' <summary>
    ''' Constructor de la clase
    ''' </summary>
    ''' <author>Jimmy Leandro Guevara Sanabria - jguevara@intergrupo.com.</author>
    ''' <datetime>24/01/2018.</datetime>
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        objPaciente = Sophia.HistoriaClinica.DatosPaciente.Paciente.Instancia
        Dim objLocal As New BLBasicasLocales
        objDatosGenerales = Generales.Instancia
        objGeneral = Generales.Instancia

        InitializeComponent()

        If objPaciente.NumeroDocumento Is Nothing Then
            txtCodigoTipoDocumento.Enabled = True
            txtDescTipoDocumento.Enabled = True
            txtNumeroDocumento.Enabled = True
            With txtCodigoTipoDocumento
                .NombreCampoBusqueda = "tip_doc"
                .NombreCampoBuscado = "descripcion"
                .ControlTextoEnlace = txtDescTipoDocumento
            End With
            With txtDescTipoDocumento
                .NombreCampoDatos = "descripcion"
                .ControlTextoEnlace = txtCodigoTipoDocumento
                .OrigenDeDatos = objLocal.TraerDatosTablasBasicasLocales(objDatosGenerales.CadenaLocal, "gentipdo", "tip_doc,descripcion", "")
                .CargarDatosDescripcion()
            End With

            'MsgBox("No hay datos del paciente.", MsgBoxStyle.Information)
        Else
            txtCodigoTipoDocumento.Enabled = False
            txtDescTipoDocumento.Enabled = False
            txtNumeroDocumento.Enabled = False
            txtCodigoTipoDocumento.Text = objPaciente.TipoDocumento
            txtDescTipoDocumento.Text = objPaciente.DescripcionTipoDocumento
            txtNumeroDocumento.Text = objPaciente.NumeroDocumento
            txtPrimerNombre.Text = objPaciente.PrimerNombre
            txtSegundoNombre.Text = objPaciente.SegundoNombre
            txtPrimerApellido.Text = objPaciente.PrimerApellido
            txtSegundoApellido.Text = objPaciente.SegundoApellido
            ' Add any initialization after the InitializeComponent() call.
            rangofecha()
        End If

    End Sub

    Private Sub TextosBuscador_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumeroDocumento.TextChanged, txtDescTipoDocumento.TextChanged, txtCodigoTipoDocumento.TextChanged
        Dim objc As New DAOTraerInfoPaciente
        Dim info_paciente As DataSet
        If txtCodigoTipoDocumento.Text <> "" And txtNumeroDocumento.Text <> "" And txtDescTipoDocumento.Text <> "" Then
            info_paciente = objc.DAOTraerInfoPaciente(txtCodigoTipoDocumento.Text, txtNumeroDocumento.Text)
            If info_paciente.Tables(0).Rows.Count > 0 Then
                txtPrimerNombre.Text = info_paciente.Tables(0).Rows(0)("Primer_Nombre").ToString()
                txtSegundoNombre.Text = info_paciente.Tables(0).Rows(0)("Segundo_Nombre").ToString()
                txtPrimerApellido.Text = info_paciente.Tables(0).Rows(0)("Primer_Apellido").ToString()
                txtSegundoApellido.Text = info_paciente.Tables(0).Rows(0)("Segundo_apellido").ToString()
            End If
        End If
    End Sub

#Region "Eventos"

    ''' <summary>
    ''' Evento que contiene la Funcionalidad de salir
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <author>Jimmy Leandro Guevara Sanabria - jguevara@intergrupo.com.</author>
    ''' <datetime>24/01/2018.</datetime>
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub

    ''' <summary>
    ''' Evento que contiene la Funcionalidad de buscar
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <author>Jimmy Leandro Guevara Sanabria - jguevara@intergrupo.com.</author>
    ''' <datetime>24/01/2018.</datetime>
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click

        If dtpFechaInicial.Value > dtpFechaFinal.Value Then
            MsgBox("La fecha inicial no puede ser mayor a la fecha final.", MsgBoxStyle.Information)
        Else
            consultarResultadosLab()
        End If
    End Sub

    Private Function ip_equipo() As String
        Dim indice As Int32 = 0
        Dim Ip As String = ""
        Try
            Dim n() As NetworkInterface = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces().ToArray().Where(
                Function(x)
                    Return _
                        x.NetworkInterfaceType = NetworkInterfaceType.Ethernet And
                        x.NetworkInterfaceType <> NetworkInterfaceType.Loopback And
                        x.NetworkInterfaceType <> NetworkInterfaceType.Tunnel And
                        Not x.Name.ToUpper().Contains("VIRTUAL")
                End Function
                ).ToArray()

            'Dim i As Int32 = 0

            For Each item As NetworkInterface In n
                'indice = i 'le apunta al siguiente adaptador ethernet , el primero es virtualbox
                For Each unicast As UnicastIPAddressInformation In item.GetIPProperties().UnicastAddresses
                    If unicast.Address.AddressFamily = AddressFamily.InterNetwork Then
                        Ip = unicast.Address.ToString()
                        Exit For
                    End If
                Next
                Exit For
            Next
        Catch
        End Try

        Return Ip
    End Function

    ''' <summary>
    ''' Evento que contiene la funcionlidad de mostrar el resultado de laboratorio
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <author>Jimmy Leandro Guevara Sanabria - jguevara@intergrupo.com.</author>
    ''' <datetime>24/01/2018.</datetime>
    Private Sub dgvResultadoLaboratorio_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvResultadoLaboratorio.CellContentClick
        Dim objconex As New Conexion
        Dim Cadena As String = ""
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = dgvResultadoLaboratorio.Rows(e.RowIndex)
            Dim modulos As String = dgvResultadoLaboratorio.Rows(e.RowIndex).Cells("Modulo").Value
            Dim numeroPeticion As String = dgvResultadoLaboratorio.Rows(e.RowIndex).Cells("Orden").Value
            Dim fecha As String = dgvResultadoLaboratorio.Rows(e.RowIndex).Cells("Fecha").Value
            Dim ruta As String = consultarResultadosLabUrl(fecha, numeroPeticion, modulos)
            ' WebBrowser1.Navigate(New Uri(ruta))
            Dim frm1 As frmVisualizarPdf = New frmVisualizarPdf(ruta)
            Try
                Dim ip As String
                Dim Equipo As String = Dns.GetHostName

                ip = ip_equipo()

                Cadena = "Tipo Documento: " & txtCodigoTipoDocumento.Text & " - No. Documento: " & txtNumeroDocumento.Text & " - Fecha: " & dgvResultadoLaboratorio.Rows(e.RowIndex).Cells("Fecha").Value & " - Orden: " & dgvResultadoLaboratorio.Rows(e.RowIndex).Cells("Orden").Value & " - Equipo: " & Equipo & " - IP: " & ip
                objBl.GrabarAuditoria(objconex, 0, "", "", "", 0, 0, objGeneral.Login, "LB", Cadena, "84")
                frm1.ShowDialog()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

    ''' <summary>
    ''' Evento que contiene la funcionalidad de evaluar el rango de fecha
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <author>Jimmy Leandro Guevara Sanabria - jguevara@intergrupo.com.</author>
    ''' <datetime>24/01/2018.</datetime>
    Private Sub dtpFechaFinal_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub dgvResultadoLaboratorio_SelectionChanged(sender As Object, e As EventArgs) Handles dgvResultadoLaboratorio.SelectionChanged
        Dim objconex As New Conexion
        Dim Cadena As String = ""
        If dgvResultadoLaboratorio.SelectedRows.Count > 0 Then
            Dim items As DataGridViewRow = dgvResultadoLaboratorio.SelectedRows.Item(0)
            Dim modulos As String = items.Cells(7).Value
            Dim numeroPeticion As String = items.Cells(3).Value
            Dim fecha As String = items.Cells(1).Value
            Dim ruta As String = consultarResultadosLabUrl(fecha, numeroPeticion, modulos)
            'WebBrowser1.Navigate(New Uri(ruta))
            Dim frm1 As frmVisualizarPdf = New frmVisualizarPdf(ruta)
            Try
                Dim ip As String
                Dim Equipo As String = Dns.GetHostName

                ip = ip_equipo()

                Cadena = "Tipo Documento: " & txtCodigoTipoDocumento.Text & " - No. Documento: " & txtNumeroDocumento.Text & " - Fecha: " & items.Cells(1).Value & " - Orden: " & items.Cells(2).Value & " - Equipo: " & Equipo & " - IP: " & ip
                objBl.GrabarAuditoria(objconex, 0, "", "", "", 0, 0, objGeneral.Login, "LB", Cadena, "84")
                frm1.ShowDialog()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        End If
    End Sub

#End Region

#Region "Meodos"

    ''' <summary>
    ''' Metodo encargado de la funcionalidad de consultar los resultados de laboratorios para un paciente
    ''' </summary>
    ''' <author>Jimmy Leandro Guevara Sanabria - jguevara@intergrupo.com.</author>
    ''' <datetime>24/01/2018.</datetime>
    Public Sub consultarResultadosLab()
        Dim tipodocumento As String
        Dim numerodocumento As String
        Dim dtInformacion As DataTable = New DataTable
        Dim colfecha As DataColumn = New DataColumn("FechaOrdena", GetType(Date))

        dtInformacion.Columns.Add("Ano")
        dtInformacion.Columns.Add(colfecha)
        dtInformacion.Columns.Add("Fecha")
        dtInformacion.Columns.Add("Orden")
        dtInformacion.Columns.Add("Pruebas")
        dtInformacion.Columns.Add("Validado")
        dtInformacion.Columns.Add("Interpretacion")
        dtInformacion.Columns.Add("Modulo")

        objGeneral = Generales.Instancia
        objPaciente = Sophia.HistoriaClinica.DatosPaciente.Paciente.Instancia

        If Not objPaciente.NumeroDocumento Is Nothing Then
            tipodocumento = objPaciente.TipoDocumento
            numerodocumento = objPaciente.NumeroDocumento
        Else
            tipodocumento = txtCodigoTipoDocumento.Text
            numerodocumento = txtNumeroDocumento.Text
        End If

        'If Not objPaciente.NumeroDocumento Is Nothing Then
        Dim ruta As String = consultarRutaServicio(MetodoServicioDatosConsulta)

        'Metodo de consulta web service
        Dim webResultadoServicio As New HistoriaClinica.wsResultadosLaboratorio.Consulta()
        Dim srvServicioWeb As New HistoriaClinica.wsResultadosLaboratorio.WebService()
        srvServicioWeb.Url = ruta
        'srvServicioWeb.fncGetSolicitudesByPacienteByFechas(homologarDocumento(objPaciente.TipoDocumento), objPaciente.NumeroDocumento, dtpFechaInicial.Value.ToShortDateString(), dtpFechaFinal.Value.ToShortDateString())
        srvServicioWeb.fncGetSolicitudesByPacienteByFechas(homologarDocumento(tipodocumento), numerodocumento, dtpFechaInicial.Value.ToShortDateString(), dtpFechaFinal.Value.ToShortDateString())

        'For Each item As HistoriaClinica.wsResultadosLaboratorio.Consulta In srvServicioWeb.fncGetSolicitudesByPacienteByFechas(homologarDocumento(objPaciente.TipoDocumento), objPaciente.NumeroDocumento, dtpFechaInicial.Value.ToShortDateString(), dtpFechaFinal.Value.ToShortDateString())
        For Each item As HistoriaClinica.wsResultadosLaboratorio.Consulta In srvServicioWeb.fncGetSolicitudesByPacienteByFechas(homologarDocumento(tipodocumento), numerodocumento, dtpFechaInicial.Value.ToShortDateString(), dtpFechaFinal.Value.ToShortDateString())
            If Not item.Paciente Is Nothing Then
                If Not item.Paciente.Peticiones Is Nothing Then
                    For Each items As HistoriaClinica.wsResultadosLaboratorio.Peticion In item.Paciente.Peticiones
                        Dim ano As DateTime = DateTime.Parse(items.FechaPeticion)
                        Dim estado As String

                        If items.EstadoPeticion = "T" Then
                            estado = "Totalmente Validado"
                        ElseIf items.EstadoPeticion = "p" Then
                            estado = "Parcialmente Validado"
                        ElseIf items.EstadoPeticion = "p" Then
                            estado = "Ninguno Validado"
                        Else
                            estado = "Sin información"
                        End If
                        dtInformacion.Rows.Add(ano.Year.ToString(), items.FechaPeticion, items.FechaPeticion, items.NumeroPeticion, items.Descripcion, estado, "", items.Modulo)
                    Next
                End If
            End If
        Next

        If dtInformacion.Rows.Count > 0 Then

            Dim dataView As New DataView(dtInformacion)
            dataView.Sort = "FechaOrdena DESC"
            Dim dataTable As DataTable = dataView.ToTable()

            dgvResultadoLaboratorio.DataSource = dataTable
        Else
            MsgBox("No existen datos de laboratorio para este paciente.", MsgBoxStyle.Information)
        End If

        'End If
    End Sub

    ''' <summary>
    ''' Metodo encargado de consultar la url del certificado del laboratorio y mostrarlo
    ''' </summary>
    ''' <param name="fechaPeticion">fecha de la peticion</param>
    ''' <param name="numeroPeticion">numero de la peticion</param>
    ''' <param name="modulo">modulo de la peticion</param>
    ''' <returns>string</returns>
    ''' <author>Jimmy Leandro Guevara Sanabria - jguevara@intergrupo.com.</author>
    ''' <datetime>24/01/2018.</datetime>
    Public Function consultarResultadosLabUrl(ByVal fechaPeticion As String, ByVal numeroPeticion As String, ByVal modulo As String) As String
        Dim ruta As String = consultarRutaServicio(MetodoServicioDatosPdf)
        Dim urlPdf As String
        'web servie
        Dim webResultadoServicio As New HistoriaClinica.wsResultadosLaboratorio.RutaPDF()
        Dim srvServicioWeb As New HistoriaClinica.wsResultadosLaboratorio.WebService()
        srvServicioWeb.Url = ruta
        webResultadoServicio = srvServicioWeb.fncGetURLPDF(fechaPeticion, numeroPeticion, modulo)

        If Not String.IsNullOrEmpty(webResultadoServicio.URL_PDF) Then
            urlPdf = webResultadoServicio.URL_PDF
        Else
            urlPdf = String.Empty
        End If
        Return urlPdf
    End Function

    ''' <summary>
    ''' Metodo encargado de consultar los datos del servicio.
    ''' </summary>
    ''' <param name="MetodoServicio">Metodo del servicio.</param>
    ''' <returns>string</returns>
    ''' <author>Jimmy Leandro Guevara Sanabria - jguevara@intergrupo.com.</author>
    ''' <datetime>24/01/2018.</datetime>
    Public Function consultarRutaServicio(ByVal MetodoServicio As String) As String
        Dim DAOCP As New DAOCuidadosPaliativos()
        Dim ruta As String
        ruta = DAOCP.ConsultarUrlServicioUT(objGeneral.Prestador, objGeneral.Sucursal, TipoServicio, MetodoServicio)

        If String.IsNullOrEmpty(ruta) Then
            Throw New Exception("No fue posible obtener el resultado de laboratorio.")
            MsgBox("No fue posible obtener el resultado de laboratorio.", MsgBoxStyle.Information)
        End If
        Return ruta
    End Function

    ''' <summary>
    ''' Metodo encargado de definir el rango de la fecha al momento de cargar el formulario.
    ''' </summary>
    ''' <author>Jimmy Leandro Guevara Sanabria - jguevara@intergrupo.com.</author>
    ''' <datetime>24/01/2018.</datetime>
    Public Sub rangofecha()
        Dim dias As Int32
        rangoTiempo = objEscalas.ConsultarDiasHistorico("RangoDiasResultadoLaboratorio")
        If rangoTiempo.Rows.Count > 0 Then
            dias = Int32.Parse(rangoTiempo.Rows(0).Item("valor").ToString)
        End If

        dtpFechaInicial.Value = DateTime.Now.AddDays(dias * -1)

    End Sub

    ''' <summary>
    ''' Metodo encargado de homologar el tipo de documento
    ''' </summary>
    ''' <param name="tipoDoc"></param>
    ''' <returns>string</returns>
    ''' <author>Jimmy Leandro Guevara Sanabria - jguevara@intergrupo.com.</author>
    ''' <datetime>24/01/2018.</datetime>
    Public Function homologarDocumento(ByVal tipoDoc As String) As String
        Return BLOrdenes.ConsultarHomologacionTipoDocumento(tipoDoc)
    End Function

#End Region
End Class