Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports Microsoft.Reporting.WinForms

Public Class frmRepFormuMedica

    Private _strTipoUsuario As String
    Private StrMedico As String
    Private objDatosGenerales As objGeneral.Generales

    Private Sub frmRepFormuMedica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'imprimirFormulaMedica("1100109887", "0010", "MSI", "519182231", "PRE001", 59)
    End Sub

    ''' <summary>
    ''' Funcion que crea el objeto con la info de la Orden de acuerdo a los parametros de entrada y lo enlaza
    ''' a las fuentes de datos del reporte
    ''' </summary>
    ''' <param name="objConexion">Datos de la conexion</param>
    ''' <param name="strCod_pre_sgs">Codigo del prestador</param>
    ''' <param name="strCod_sucur">Codigo de la sucursal</param>
    ''' <param name="dNroFormula">Numero de orden de la formulacion de medicamentos</param>
    ''' <remarks></remarks>
    Public Sub imprimirFormulaMedica(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String, _
                                            ByVal strTipAdm As String, ByVal iAno As Integer, _
                                            ByVal lNumAdm As Long, ByVal dNroFormula As Double, _
                                            ByVal esReimpresion As Boolean, ByVal strTipoUsuario As String)

        Dim objOrden As Orden       ''Objeto que encapsula la informacion de la orden
        objDatosGenerales = objGeneral.Generales.Instancia

        objOrden = New Orden()      ''Creacion del objeto

        Try

            _strTipoUsuario = strTipoUsuario
            ''Consulta en la base de datos de acuerdo a los parametros de entrada. Los datos encontrados
            ''se encapsulan en al objeto objOrden
            objOrden.crearOrdenMedicamentos(objConexion, strcod_pre_sgs, strCod_sucur, _
                                            strTipAdm, iAno, lNumAdm, dNroFormula, esReimpresion)

            ''Variable que maneja el label de copia en el reporte
            objOrden.EsReimpresion = esReimpresion


            'If objDatosGenerales.Pais = "482" Then
            '    If objFormuExt.TipoEntidad = "PRE" Then
            '        _textovalidopor = "VÁLIDO POR 72 HORAS A PARTIR DEL DÍA SIGUIENTE A LA FECHA DE EXPEDICION"
            '    Else
            '        _textovalidopor = ""
            '    End If
            'Else
            '    If objFormuExt.TipoEntidad = "EPS" Then
            '        _textovalidopor = "VÁLIDO POR 30 DIAS A PARTIR DE LA FECHA DE EXPEDICIÓN"
            '    Else
            '        _textovalidopor = "VÁLIDO POR 72 HORAS A PARTIR DE LA FECHA DE EXPEDICIÓN"
            '    End If
            'End If


            'objOrden.TextoValidoPor
            ''Ingresado por Claudia Garay
            StrMedico = objOrden.NumDocMedico

            ''Se enlaza el objeto objOrden con la fuente de datos del reporte para este acceda a la info del encabezado 
            OrdenBindingSource.DataSource = objOrden
            ''Se enlaza el objeto Paciente contenido en objOrden con la fuente de datos del reporte para este acceda a la info del paciente 
            PacienteBindingSource.DataSource = objOrden.Paciente
            ''Se enlaza la Lista de Medicamentos contenido en objOrden con la fuente de datos del reporte para este acceda a la info de los medicamentos 
            MedicamentoBindingSource.DataSource = objOrden.Medicamentos

        Catch ex As Exception
            MsgBox("Error en la impresión de la orden. ", MsgBoxStyle.Critical)
        End Try

        If objDatosGenerales.Pais = "484" Then
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepFormulaMedicaVenezuela.rdlc"
        ElseIf objDatosGenerales.Pais = "482" Then
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepFormulaMedicaPeru.rdlc"
        Else
            Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "HistoriaClinica.RepFormulaMedica.rdlc"
        End If
        'llarias Se agrega objeto objOrden para poder consultar la especialidad del médico 2014-11-16
        setParametrosReporte(objOrden)


        ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles ReportViewer1.RenderingComplete
        ''Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
    End Sub



    Public Sub setParametrosReporte(ByVal objOrden As Orden)
        Dim aParametros(3) As ReportParameter
        Dim objConsulta As New Sophia.HistoriaClinica.BL.BLBasicasGenerales
        Dim objGeneral As Sophia.HistoriaClinica.DatosGenerales.Generales
        Dim objPaciente As Sophia.HistoriaClinica.DatosPaciente.Paciente
        Dim objConexion As Sophia.HistoriaClinica.DatosConexion.Conexion
        Dim lError As Long
        Dim lError2 As Long
        Dim strIndica As String
        Dim strEspecialidad As String

        strEspecialidad = ""
        strIndica = ""

        objGeneral = Sophia.HistoriaClinica.DatosGenerales.Generales.Instancia
        objPaciente = Sophia.HistoriaClinica.DatosPaciente.Paciente.Instancia
        objConexion = Sophia.HistoriaClinica.DatosConexion.Conexion.Instancia
        ''Modificado por Claudia Garay 
        ''Solicitud Juan Diego Arenas
        ''Se modifica parametro medico login por medico que formula
        ''14 Diciembre de 2009
        strIndica = objConsulta.ConsultarMedicoPuertaEntrada(objConexion, objGeneral.Prestador, objGeneral.Sucursal, objPaciente.Entidad, StrMedico, lError)
        If strIndica <> "S" Then
            'llarias Se crea función para consultar la especialidad del médico que realiza la orden 2014-11-16
            strEspecialidad = objConsulta.ConsultarEspecialidad(objConexion, objOrden.Especialidad, lError2)
            strIndica = strEspecialidad
            'strIndica = objGeneral.DescripcionEspecialidad
        End If

        aParametros(0) = New ReportParameter("FechaImpresion", Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy HH:mm"))
        aParametros(1) = New ReportParameter("Copia", "N")
        aParametros(2) = New ReportParameter("TipoUsuario", _strTipoUsuario)
        aParametros(3) = New ReportParameter("MedicoPE", strIndica)


        ReportViewer1.LocalReport.SetParameters(aParametros)

    End Sub

End Class