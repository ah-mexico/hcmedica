Imports System.IO
Imports System.Collections
Imports System.Net
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports Newtonsoft
Imports Newtonsoft.Json
Imports System.Linq

Public Class frm_360Layout
    Private dtAdmisiones As DataTable
    Private dtMedicamentos As DataTable
    Private dtProcedimientos As DataTable
    Private dtDiagnosticos As DataTable
    Private dtFormulacion As DataTable
    Private dtProcedimientosExternos As DataTable

    Private Shared _Instancia As frm_360Layout
    Public Shared ReadOnly Property Instancia() As frm_360Layout
        Get
            If _Instancia Is Nothing Then
                _Instancia = New frm_360Layout
            End If
            Return _Instancia
        End Get
    End Property

    Friend Property _TipoDocumento As String
    Friend Property _NumeroDocumento As String

    Public Property TipoDocumento() As String
        Get
            Return _TipoDocumento
        End Get
        Friend Set(ByVal value As String)
            _TipoDocumento = value
        End Set
    End Property

    Public Property NumeroDocumento() As String
        Get
            Return _NumeroDocumento
        End Get
        Friend Set(ByVal value As String)
            _NumeroDocumento = value
        End Set
    End Property


    Friend Property _objConexion As HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
    Public Property objConexion() As HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
        Get
            Return _objConexion
        End Get
        Friend Set(ByVal value As HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion)
            _objConexion = value
        End Set
    End Property

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub frm_360Layout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim peticion As WebRequest = WebRequest.Create("http://localhost:49220/api/paciente/getadmisiones?id=1")
        peticion.Credentials = CredentialCache.DefaultCredentials
        Dim respuestaCompleta As String = String.Empty
        Me.lblTxtForm.Width = (Me.Width - 50)
        Me.lblTxtForm.Location = New Point(16, 1)
        Try
            Dim tabla As New DataTable
            'Dim respuesta As WebResponse = peticion.GetResponse()
            'Dim estado As String = DirectCast(respuesta, System.Net.HttpWebResponse).StatusDescription
            'If estado.Trim().ToUpperInvariant() = "OK" Then
            '    Using dataStream As Stream = respuesta.GetResponseStream()
            '        Dim reader As StreamReader = New StreamReader(dataStream)
            '        respuestaCompleta = reader.ReadToEnd()
            '    End Using

            lstAdmisiones.Items.Clear()
            lstAdmisiones.View = View.Details

            '    tabla = JsonConvert.DeserializeObject(Of DataTable)(respuestaCompleta)

            tabla = BLOrdenes.ConsultaGeneral_PAC360(Me.TipoDocumento, Me.NumeroDocumento)
            If Not IsNothing(tabla.Rows) Then
                If tabla.Rows.Count > 0 Then
                    dtAdmisiones = PopulateDataTable(tabla.Select("Indicador = 'Admisiones'"), tabla.Columns, columnasAdmisiones)
                    dtMedicamentos = PopulateDataTable(tabla.Select("Indicador = 'Medicamentos'"), tabla.Columns, columnasMedicamentos)
                    dtFormulacion = PopulateDataTable(tabla.Select("Indicador = 'MedicamentosExt'"), tabla.Columns, columnasMedicamentos)
                    dtDiagnosticos = PopulateDataTable(tabla.Select("Indicador = 'Diagnosticos'"), tabla.Columns, columnasDiagnosticos)
                    dtProcedimientos = PopulateDataTable(tabla.Select("Indicador = 'Procedimientos'"), tabla.Columns, columnasProcedimient)
                    dtProcedimientosExternos = PopulateDataTable(tabla.Select("Indicador = 'ProcedimientosExt'"), tabla.Columns, columnasProcedExter)

                    dtAdmisiones.DefaultView.Sort = "Fecha Admision DESC"
                    dtAdmisiones = dtAdmisiones.DefaultView.ToTable()
                    'Select Case ("", "Fecha Admision DESC")
                    dtAdmisiones = dtAdmisiones.Rows.Cast(Of DataRow).Take(5).CopyToDataTable()
                    For Each fila As DataRow In dtAdmisiones.Rows
                        Dim tt As New ToolTip
                        Dim lst As ListViewItem

                        lst = lstAdmisiones.Items.Add(If(fila(0) IsNot Nothing, fila(0).ToString, ""))
                        For i As Integer = 1 To dtAdmisiones.Columns.Count - 1
                            lst.SubItems.Add(If(fila(i) IsNot Nothing, fila(i).ToString, ""))
                            lst.ToolTipText = fila(i).ToString
                            tt.SetToolTip(lstAdmisiones, fila(i).ToString)
                        Next
                    Next
                    lstAdmisiones.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)

                    ' Trae el primer registro de la consulta
                    Me.DataSourceGrids()
                    ResizeDataTablesColumns()
                Else
                    MessageBox.Show("No se encontraron resultados para la vista", "Paciente360")
                    Me.Close()
                    Return
                End If
            End If

            'respuesta.Close()
        Catch errorComunicacion As WebException
            MessageBox.Show(errorComunicacion.Message, "Consulta General")
            Me.Close()
            Return
        Catch consultaDetalles As EvaluateException
            MessageBox.Show(consultaDetalles.Message, "Consulta Detalles")
            Me.Close()
            Return
        End Try

    End Sub

    Private Sub lstAdmisiones_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstAdmisiones.SelectedIndexChanged
        Dim strNumAdmision As String = lstAdmisiones.FocusedItem.Text
        Dim datosAdmision() As String = {strNumAdmision.Substring(0, 1),
                                          strNumAdmision.Substring(1, 4),
                                          strNumAdmision.Substring(5, (strNumAdmision.Length - 5)),
                                          lstAdmisiones.FocusedItem.SubItems.Item(4).Text,
                                          lstAdmisiones.FocusedItem.SubItems.Item(5).Text}
        'MessageBox.Show(strNumAdmision)

        Dim tabla As DataTable = BLOrdenes.ConsultaGeneral_PAC360(Me.TipoDocumento, Me.NumeroDocumento, 1, datosAdmision)
        If Not IsNothing(tabla) Then
            If tabla.Columns.Count < 1 Then
                tabla = PopulateDataTable(tabla.Select(""), tabla.Columns, columnasAdmisiones)
                tabla.Columns.Add(New DataColumn("Indicador", GetType(String)))
            End If
        End If

        dtMedicamentos = PopulateDataTable(tabla.Select("Indicador = 'Medicamentos'"), tabla.Columns, columnasMedicamentos)
        dtFormulacion = PopulateDataTable(tabla.Select("Indicador = 'MedicamentosExt'"), tabla.Columns, columnasMedicamentos)
        dtDiagnosticos = PopulateDataTable(tabla.Select("Indicador = 'Diagnosticos'"), tabla.Columns, columnasDiagnosticos)
        dtProcedimientos = PopulateDataTable(tabla.Select("Indicador = 'Procedimientos'"), tabla.Columns, columnasProcedimient)
        dtProcedimientosExternos = PopulateDataTable(tabla.Select("Indicador = 'ProcedimientosExt'"), tabla.Columns, columnasProcedExter)
        Me.DataSourceGrids()
        Exit Sub
    End Sub

    Private Function PopulateDataTable(rowCollection As DataRow(), columnsCollection As DataColumnCollection, columnsToView() As String) As DataTable
        Dim targetDataTable As New DataTable

        Try
            ' Crear Columnas
            For Each columnItem As DataColumn In columnsCollection
                targetDataTable.Columns.Add(New DataColumn(columnItem.ColumnName, columnItem.DataType))
            Next
            If Not IsNothing(rowCollection) Then
                If rowCollection.Length > 0 Then
                    'Poblar Tabla
                    For Each rowItem As DataRow In rowCollection
                        targetDataTable.ImportRow(rowItem)
                    Next
                End If
            End If

            'Limpiar Tabla
            Dim ColumnNameToSet, ColumnNameToSearch As String
            Dim retArr As String()
            'El parametro columnsToView es una coleccion tipo cadena, con elementos que conforman NombredeColumna:Titulo a mostrar
            For Each columna As DataColumn In columnsCollection
                ColumnNameToSearch = Array.Find(columnsToView, Function(x) (x.ToLowerInvariant().Trim().Contains(columna.ColumnName.ToLowerInvariant().Trim())))
                ColumnNameToSet = ColumnNameToSearch

                If String.IsNullOrEmpty(ColumnNameToSearch) Then
                    targetDataTable.Columns.Remove(columna.ColumnName)
                Else
                    If ColumnNameToSearch.Contains(":") Then
                        retArr = ColumnNameToSearch.Split(":")
                        ColumnNameToSearch = retArr(0)
                        ColumnNameToSet = retArr(1)
                    End If
                    If targetDataTable.Columns.IndexOf(ColumnNameToSet) < 0 Then
                        targetDataTable.Columns(columna.ColumnName).ColumnName = ColumnNameToSet
                    End If
                End If
            Next

            targetDataTable = FuncionesGenerales.ReOrganizarColumnasEnDatatable(targetDataTable, columnsToView)
            targetDataTable.AcceptChanges()
        Catch populateException As Exception
            MessageBox.Show(populateException.Message, "Seleccionando Registros")
            Return targetDataTable
        End Try

        Return targetDataTable
    End Function
    Private Sub DataSourceGrids()
        Me.grdMedicamentos.DataSource = dtMedicamentos
        Me.grdFormulacion.DataSource = dtFormulacion
        Me.grdDiagnosticos.DataSource = dtDiagnosticos
        Me.grdProcedimientos.DataSource = dtProcedimientos
        Me.grdProcedimientosExternos.DataSource = dtProcedimientosExternos
        Me.grdDiagnosticos.DataSource = dtDiagnosticos
    End Sub

    Public Sub ResizeDataTablesColumns()
        Dim SizeToAdd As Integer = 90

        grdDiagnosticos.Columns(0).Width = grdDiagnosticos.Columns(0).Width + SizeToAdd
        grdFormulacion.Columns(0).Width = grdDiagnosticos.Columns(0).Width + SizeToAdd
        grdMedicamentos.Columns(0).Width = grdDiagnosticos.Columns(0).Width + SizeToAdd
        grdProcedimientos.Columns(0).Width = grdDiagnosticos.Columns(0).Width + SizeToAdd
        grdProcedimientosExternos.Columns(0).Width = grdDiagnosticos.Columns(0).Width + SizeToAdd

    End Sub


    Public Shared ReadOnly columnasAdmisiones() As String = {"Admision:Admision", "FechaAdmision:Fecha Admision", "Descripcion:Sede", "Descripcion2:Ciudad", "cod_pre_sgs:cod_pre_sgs", "cod_sucur:cod_sucur"}
    Public Shared ReadOnly columnasDiagnosticos() As String = {"fecha:DIAGNOSTICO", "Descripcion2:CATEGORIA", "ADMISION:ORIGEN"} '"num_adm:FEC. DIAGNOSTICO", 
    Public Shared ReadOnly columnasProcedimient() As String = {"Descripcion:DESCRIPCION", "Descripcion2:OBSERVACIONES"}
    Public Shared ReadOnly columnasProcedExter() As String = {"Admision:PROCEDIMIENTO", "Descripcion:BILATERAL", "Descripcion2:OBSERVACIONES"}
    Public Shared ReadOnly columnasMedicamentos() As String = {"Descripcion:DESCRIPCION", "Descripcion2:PRESCRIPCION"}
    Public Shared ReadOnly columnasGenerales() As String = {"Descripcion:DESCRIPCION", "Descripcion2:OBSERVACIONES"}


End Class