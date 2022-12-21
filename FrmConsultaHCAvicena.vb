Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.Util
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes.FuncionesGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports System.Drawing
Imports System.Net
Imports System.Linq
Imports System.Net.NetworkInformation
Imports System.Net.Sockets

Imports System
Imports System.Threading.Tasks

Imports System.Text
Imports System.IO

Imports Newtonsoft.Json
Imports System.Collections.Generic
Imports System.ComponentModel

Public Class FrmConsultaHCAvicena

    Private datosconexion As objCon
    Private datosPaciente As Paciente
    Private datosLogin As Generales
    Dim objParametros As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOHerramientaEvaluacion

    Dim objConsultaAvicena As New Sophia.HistoriaClinica.DAO.DAOConsultaHcAvicenaSrvRest

    Dim objBl As New Sophia.HistoriaClinica.BL.BLRptHC_Enf_Med

    Dim TParametro As New DataTable

    Private Servidor As String = ""
    Private Carpeta As String = ""
    Private RutaReporte As String = ""
    Private ip As String = "", Obeservacion As String = ""
    Private Equipo As String = Dns.GetHostName



    Private dias As Int32
    Private Sub FrmConsultaHCAvicena_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    ''' <summary>
    ''' Metodo encargado de cargar parámetros y datos al formulario
    ''' </summary>
    Public Sub Mostrar()
        Dim mensaje As String = Nothing
        ''prueba de compilado 
        Try
            datosLogin = Generales.Instancia()
            datosPaciente = Paciente.Instancia()
            datosconexion = Conexion.Instancia()

            rangofecha()

            Servidor = ConsultarParametros("URLREPORTESAVICENA")
            RutaReporte = ConsultarParametros("AVICENAHCBasica")
            Carpeta = ConsultarParametros("AVICENAPATHREPORTE")

            ip = ip_equipo()

            Me.txtPrimerNombre.Text = datosPaciente.PrimerNombre
            Me.txtSegundoNombre.Text = datosPaciente.SegundoNombre
            Me.txtPrimerApellido.Text = datosPaciente.PrimerApellido
            Me.txtSegundoApellido.Text = datosPaciente.SegundoApellido

            dgvFolio.AutoGenerateColumns = False
            dgvFolio.Sort(dgvFolio.Columns("fechaFolio"), ListSortDirection.Descending)

            Me.ShowDialog()
        Catch ex As Exception
            MsgBox("Error al cargar el formulario de consulta: " + ex.Message, MsgBoxStyle.Critical)
        End Try



    End Sub
    ''' <summary>
    ''' Metodo encargado de definir el rango de la fecha al momento de cargar el formulario.
    ''' </summary>
    ''' <author>Raul Cruz Romero</author>
    ''' <datetime>10/07/2019.</datetime>

    Private Sub rangofecha()

        Dim dtFecha As Date
        Try

            TParametro = objParametros.ConsultarDiasHistorico("RangoDiasConsultaHcAvicena") ''se consulta el parametro para el rango en días

            If TParametro.Rows.Count > 0 Then
                dias = Int32.Parse(TParametro.Rows(0).Item("valor").ToString)
                mskFechaDesde.Text = DateTime.Now.AddDays(dias * -1)
                dtFecha = FuncionesGenerales.FechaServidor()
                mskFechaHasta.Text = Format(dtFecha, "dd/MM/yyyy")
                Me.btnBuscar.Enabled = True
            Else
                MsgBox("No se encontró el parámetro (RangoDiasConsultaHcAvicena en la tabla Genparsophia), contáctese con el administrador del sistema.", MsgBoxStyle.Critical)
                Me.btnBuscar.Enabled = False
            End If
        Catch ex As Exception
            MsgBox("Error al validar rango de días para la consulta en Avicena: " + ex.Message, MsgBoxStyle.Critical)
        End Try


    End Sub

    ''' <summary>
    ''' Función que consulta los parametros que se requieren para el formulario
    ''' </summary>
    ''' <param name="Parametro"></param>
    Private Function ConsultarParametros(Parametro As String) As String
        Dim ValorParametro As String = ""
        Try

            TParametro = objParametros.ConsultarDiasHistorico(Parametro)

            If TParametro.Rows.Count > 0 Then
                ValorParametro = TParametro.Rows(0).Item("valor").ToString

            Else
                MsgBox("No se encontró el parámetro (" + Parametro + " en la tabla Genparsophia), contáctese con el administrador del sistema.", MsgBoxStyle.Critical)
                Me.btnBuscar.Enabled = False
            End If

        Catch ex As Exception
            MsgBox("Error al validar" + Parametro + " : " + ex.Message, MsgBoxStyle.Critical)
        End Try

        Return ValorParametro
    End Function

    Sub cargarDatos()

        Try
            Me.dgvFolio.DataSource = objConsultaAvicena.consultaInformacionFoliosHCPaciente(datosPaciente.TipoDocumento, datosPaciente.NumeroDocumento, Me.mskFechaDesde.Text, ip, datosLogin.Login)
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information)
        End Try

    End Sub
    ''' <summary>
    ''' Metodo que arma la url para generar el reporte de HC en avicena
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgvFolio_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvFolio.CellContentClick


        Dim fila As Int16 = e.RowIndex
        Dim folio As String = ""
        Dim urlToPost As String

        Try

            If fila = -1 Then 'para evitar que se genere el error de excepción
                Exit Sub
            End If

            folio = dgvFolio.Rows(fila).Cells(0).Value.ToString()

            urlToPost = objConsultaAvicena.consultaHCFolioPaciente(folio, ip, datosLogin.Login)

            If urlToPost IsNot "" Then
                Process.Start(urlToPost)
            End If


        Catch ex As Exception
            MsgBox("Error consultando la URL reporte  del webservice avicena. " + ex.Message, MsgBoxStyle.Information)

        End Try

    End Sub
    Private Function ip_equipo() As String
        Dim indice As Int32 = 0
        Dim Ip As String = ""
        Try
            Dim n() As NetworkInterface = NetworkInterface.GetAllNetworkInterfaces().ToArray().Where(
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
    '''Método de validación de campos de fecha
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim DifDias As Int32 = 0

        Me.dgvFolio.DataSource = Nothing ''limpio la grilla de folios

        Try
            If Not IsDate(Me.mskFechaDesde.Text) Then
                MsgBox("Fecha invalida, ingrésela nuevamente por favor.", MsgBoxStyle.Information)
                mskFechaDesde.Focus()
                Exit Sub
            End If

            If Not IsDate(Me.mskFechaHasta.Text) Then
                MsgBox("Fecha invalida, ingrésela nuevamente por favor.", MsgBoxStyle.Information)
                mskFechaHasta.Focus()
                Exit Sub
            End If

            If CDate(mskFechaDesde.Text) > Now Then
                MsgBox("Fecha inicio, no puede ser mayor que la Fecha actual, ingrésela nuevamente por favor.", MsgBoxStyle.Information)
                mskFechaDesde.Focus()
                Exit Sub
            End If

            If CDate(mskFechaHasta.Text) > Now Then
                MsgBox("Fecha final, no puede ser mayor que la Fecha actual, ingrésela nuevamente por favor.", MsgBoxStyle.Information)
                mskFechaHasta.Focus()
                Exit Sub
            End If

            If CDate(mskFechaDesde.Text) > CDate(mskFechaHasta.Text) Then
                MsgBox("Fecha inicio, no puede ser mayor a la Fecha final, ingrésela nuevamente por favor.", MsgBoxStyle.Information)
                mskFechaDesde.Focus()
                Exit Sub
            End If

            DifDias = DateDiff(DateInterval.Day, CDate(mskFechaDesde.Text), CDate(mskFechaHasta.Text))

            If DifDias > dias Then
                MsgBox("No es posible realizar búsqueda de Historia Clínica en Avicena, por favor verifique el rango de fechas.", MsgBoxStyle.Information)
                mskFechaDesde.Focus()
                Exit Sub
            End If

            cargarDatos()
        Catch ex As Exception
            MsgBox("Error al validar campos de fecha: " + ex.Message, MsgBoxStyle.Critical)
        End Try


    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
        Me.Dispose()
    End Sub


    Public Class JsonResultadoCunsultaFolios
        Public Property folio As Integer
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

    Public Class JsonResultadoUrlReporte
        Public Property urlReporteHC As String
        Public Property codigoMensajeServicio As String
        Public Property mensajeServicio As String
    End Class

End Class