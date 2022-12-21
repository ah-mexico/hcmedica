Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms

Public Class frmRepResumenHistoriaClinica

    Private _resumenHistoriaClinica As FormatoHistoriaClinica

    ''' <summary>
    ''' Crea y llena el objeto que encapsula la informacion del resumende la historia clinica
    ''' ademas enlaza este objeto con la fuente de datos del reporte
    ''' </summary>
    ''' <param name="objConexion">Datos de la conexion</param>
    ''' <param name="strcod_pre_sgs">Codigo del prestador</param>
    ''' <param name="strCod_sucur">Codigo de la sucursal</param>
    ''' <param name="strTip_admision">Tipo de admision</param>
    ''' <param name="lano_adm">Año de la admision</param>
    ''' <param name="dnum_adm">Numero de la admision</param>
    ''' <remarks></remarks>
    Public Sub ImprimirResumenHistoriaClinica(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, _
                   ByVal strCod_sucur As String, ByVal strTip_admision As String, _
                   ByVal lano_adm As Long, ByVal dnum_adm As Double)

        _resumenHistoriaClinica = New FormatoHistoriaClinica()

        Try
            ''Se consulta en la base de datos la informacion de la historia clinica y se presenta resumidamente
            ''Con la informacion resultante se llena el objeto _resumenHistoriaClinica
            _resumenHistoriaClinica.consultarResumenHistoriaClinica(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision, lano_adm, dnum_adm)

            ''Se enlaza el objeto Encabezado del objeto _resumenHistoriaClinica con el origen de datos del reporte
            ''para acceder a los datos del encabezado
            PacienteBindingSource.DataSource = _resumenHistoriaClinica.Encabezado.Paciente
            ''Se enlaza el objeto Paciente del objeto _resumenHistoriaClinica con el origen de datos del reporte
            ''para acceder a los datos del Paciente
            HCEncabezadoBindingSource.DataSource = _resumenHistoriaClinica.Encabezado
            iniciarParametros()

        Catch ex As Exception
            MsgBox("Error en la consulta de reporte." & ex.Message)
        End Try

        ''Se define que el metodo SubreportProcessingEventHandler maneja el evento ReportViewer1.LocalReport.SubreportProcessing 
        ''del Reporte. Este evento ocurre cuando se procesan los subreportes contenidos en el reporte principal
        AddHandler ReportViewer1.LocalReport.SubreportProcessing, AddressOf SubreportProcessingEventHandler

        setParametrosReporte()

        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles ReportViewer1.RenderingComplete
        ''Me.ReportViewer1.SetDisplayMode(DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = ZoomMode.PageWidth
    End Sub

    ''' <summary>
    ''' Debido a que el encabezado debe aparecer en todas las paginas del reporte, esta informacion 
    ''' debe ser pasada como parametro al reporte para que pueda ser pintada en el header
    ''' </summary>
    ''' <remarks></remarks>
    ''' 
    Public Sub iniciarParametros()
        Dim parameters(21) As ReportParameter

        With _resumenHistoriaClinica.Encabezado
            parameters(0) = New ReportParameter("Sucursal", .Sucursal)
            parameters(1) = New ReportParameter("Prestador", .Prestador)
            parameters(2) = New ReportParameter("Fecha", .Fecha)
            parameters(3) = New ReportParameter("Hora", .Hora)
            parameters(4) = New ReportParameter("NroAdmision", .TipoAdmision & " " & .AnoAdmision & " " & .NumeroAdmision)
            parameters(5) = New ReportParameter("Nombre", .Paciente.Nombre)
            parameters(6) = New ReportParameter("HistoriaClinica", .Paciente.NumeroDocumento)
            parameters(7) = New ReportParameter("FechaIngreso", .fechaIngreso)
            parameters(8) = New ReportParameter("HoraIngreso", .HoraIngreso)
            parameters(9) = New ReportParameter("FechaEgreso", .FechaEgreso)
            parameters(10) = New ReportParameter("HoraEgreso", .HoraEgreso)
            parameters(11) = New ReportParameter("Estancia", .Estancia)
            parameters(12) = New ReportParameter("Cama", .Cama)
            parameters(13) = New ReportParameter("MedicoTratante", .MedicoTratante)
            parameters(14) = New ReportParameter("Edad", .Paciente.Edad)
            parameters(15) = New ReportParameter("UnidadEdad", .Paciente.UnidadEdad)
            parameters(16) = New ReportParameter("Sexo", .Paciente.DescripSexo)
            parameters(17) = New ReportParameter("TipoID", .Paciente.DescripTipoDocumento)
            parameters(18) = New ReportParameter("NumID", .Paciente.NumeroDocumento)
            parameters(19) = New ReportParameter("TipoAdmIngreso", .TipoAdmIngreso)
            parameters(20) = New ReportParameter("TipoAdmEgreso", .TipoAdmEgreso)
            parameters(21) = New ReportParameter("CausaExterna", .CausaExterna)
        End With
        
        ReportViewer1.LocalReport.SetParameters(parameters)

    End Sub

    ''' <summary>
    ''' Metodo que asigna la informacion consultada para cada una de las secciones de la historia clinica
    ''' a los origenes de datos de sus correspondientes subreportes. Este metodo se ejecuta cuando se 
    ''' dispara el evento ReportViewer1.LocalReport.SubreportProcessing que sucede en el momento que se 
    ''' se procesan los subreportes contenidos en el reporte principal  
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Public Sub SubreportProcessingEventHandler(ByVal sender As Object, ByVal e As SubreportProcessingEventArgs)
        Dim source As BindingSource

        source = New BindingSource()
        source.DataSource = _resumenHistoriaClinica.MotivoConsulta
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_MotivoConsulta", source))

        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_RevisionEA", _resumenHistoriaClinica.RevisionSistemasEA))

        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Alergico", _resumenHistoriaClinica.AntecedentesAlergicos))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Familiares", _resumenHistoriaClinica.AntecedentesFamiliares))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Farmacologico", _resumenHistoriaClinica.AntecedentesFarmacologicos))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Ginecologico", _resumenHistoriaClinica.AntecedentesGinecologicos))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Inmunologico", _resumenHistoriaClinica.AntecedentesInmunologicos))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Antecedente", _resumenHistoriaClinica.OtrosAntecedentes))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Patologico", _resumenHistoriaClinica.AntecedentesPalotogicos))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Perinatales", _resumenHistoriaClinica.AntecedentesPerinatales))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Quirurgico", _resumenHistoriaClinica.AntecedentesQuirurgicos))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Toxico", _resumenHistoriaClinica.AntecedentesToxicos))

        source = New BindingSource()
        source.DataSource = _resumenHistoriaClinica.ExamenFisico
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_ExamenFisico", source))

        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Revision", _resumenHistoriaClinica.RevisionSistemas))

        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Diagnostico", _resumenHistoriaClinica.Diagnosticos))

        source = New BindingSource()
        source.DataSource = _resumenHistoriaClinica.ResumenEvolucion
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_ResumenEvolucion", source))

        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_DiagnosticoEgreso", _resumenHistoriaClinica.DiagnosticosEgreso))

        'e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Medicamento", _resumenHistoriaClinica.DetalleOrdenesMedica))
        'e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Procedimiento", _resumenHistoriaClinica.DetalleOrdenesProce))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_MedicamentoExt", _resumenHistoriaClinica.Medicamentos))
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_ProcedimientoExt", _resumenHistoriaClinica.Procedimientos))

        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Admision", _resumenHistoriaClinica.Egresos))
        'se agrega subreporte procedimientosQx
        e.DataSources.Add(New ReportDataSource("HistoriaClinica_Sophia_HistoriaClinica_Reportes_Procedimiento", _resumenHistoriaClinica.ProcedimQxPracticados))
        '_resumenHistoriaClinica.consultarResumenHistoriaClinica

    End Sub

    Public Sub setParametrosReporte()
        Dim aParametros As New List(Of ReportParameter)

        aParametros.Add(New ReportParameter("FechaImpresion", Format(FuncionesGenerales.FechaServidor(), "dd/MM/yyyy HH:mm")))
        ReportViewer1.LocalReport.SetParameters(aParametros)

    End Sub

    Private Sub ReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportViewer1.Load

    End Sub

    Private Sub frmRepResumenHistoriaClinica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class