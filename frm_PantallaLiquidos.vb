
'Desarrollado por Leonardo Alfonso Coba
'para la visualización de los liquidos
'Diciembre de 2011
'Enfermeria - 2da fase
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports objcon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes

Public Class Frm_PantallaLiquidos
    Private datosconexion As objcon
    Private codhistoria As String
    Dim dttemporal As New DataTable
    Dim fechauno As String
    Dim fechados As String
    Dim fechatres As String
    Private objDao As New DAOGeneral
    Private General As objGeneral
    Private objLiquidos As New Liquidos
    Private fecha As String
    Private AGrilla As New ArrayList
    Private arrColLiqAdmin As New ArrayList
    Private arrColLiqElim As New ArrayList
  


    Public Sub New(ByVal dCod_Historia As String, ByVal strFechaIni_RecNac As Nullable(Of DateTime), ByVal strFechaFin_RecNac As Nullable(Of DateTime), ByVal iHoraIni_RecNac As Nullable(Of Integer), ByVal iHoraFin_RecNac As Nullable(Of Integer))

        codhistoria = dCod_Historia

        ' Llamada necesaria para el Diseñador de Windows Forms.
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        InitializeComponent()

    End Sub

    'Se organiza la data para mostrarla segun los solicitado
    Public Function ConfiguraDatosGrillaLiqAdministrados(ByVal dsDatos As DataTable, ByRef arrColumnas As ArrayList) As DataTable

        Dim dtTemp As New DataTable
        Dim arrCaposDistinct As String() = {"descripcion", "secuencia"}
        Dim drFila As DataRow
        Dim dtVisorLiq As DataTable = New DataTable("visorLiq")
        Dim totalFila As Double
        Dim totalColumna As Double


        'ActualizaSecuencia(dsDatos)

        dtTemp = dsDatos.DefaultView.ToTable(True, arrCaposDistinct)
        '''Se arman encabezados
        ''' 

        dtVisorLiq.Columns.Add("Hora", Type.GetType("System.String"))
        For Each drFila In dtTemp.Rows
            ' & drFila.Item("secuencia").ToString, Type.GetType("System.String")
            dtVisorLiq.Columns.Add(drFila.Item("descripcion").ToString.Substring(0, IIf(Len(drFila.Item("descripcion")) > 10, 10, Len(drFila.Item("descripcion")))) & drFila.Item("secuencia").ToString, Type.GetType("System.String"))
            arrColumnas.Add(drFila.Item("descripcion").ToString)

        Next
        dtVisorLiq.Columns.Add("Total", Type.GetType("System.Int32"))
        '

        AgregarAlArreglo()
        totalColumna = 0
        'agregar filas
        For i As Integer = 0 To 26
            Dim dr As DataRow = dtVisorLiq.NewRow
            dtVisorLiq.Rows.Add(dr)

            dtVisorLiq.Rows(i).Item("Hora") = AGrilla(i).ToString
            'recorremos las columnas del visor
            totalFila = 0
            For j As Integer = 1 To dtVisorLiq.Columns.Count - 1
                'recorremos la tabla base para insertar datos.

                'For fd As Integer = 0 To dtVisorLiq.Columns.Count - 1 'dsDatos.Rows.Count - 1

                For cd As Integer = 0 To dsDatos.Rows.Count - 1
                    'se empieza a comparar datos
                    If dtVisorLiq.Rows(i).Item("Hora").ToString = dsDatos.Rows(cd).Item("hora").ToString Then
                        'primero comparamos el producto
                        If dtVisorLiq.Columns.Item(j).ToString = dsDatos.Rows(cd).Item("descripcion").ToString.Substring(0, IIf(Len(dsDatos.Rows(cd).Item("descripcion")) > 10, 10, Len(dsDatos.Rows(cd).Item("descripcion")))) & dsDatos.Rows(cd).Item("secuencia").ToString Then

                            dtVisorLiq.Rows(i).Item(j) = dsDatos.Rows(cd).Item("cantidad").ToString
                            If Trim(dsDatos.Rows(cd).Item("cantidad")) <> "+" And Trim(dsDatos.Rows(cd).Item("cantidad")) <> "-" Then
                                totalFila += CDbl(dsDatos.Rows(cd).Item("cantidad"))
                            End If

                        End If
                        dtVisorLiq.Rows(i).Item("Total") = totalFila
                    End If
                Next
            Next
        Next

        ''''''''''''''
        'suma por columnas
        'jlalfonso 

        Try
            For j As Integer = 1 To dtVisorLiq.Columns.Count - 1
                'mañana
                For i As Integer = 0 To 6
                    If Not String.IsNullOrEmpty(dtVisorLiq.Rows(i).Item(j).ToString) Then
                        If Trim(dtVisorLiq.Rows(i).Item(j)) <> "+" And Trim(dtVisorLiq.Rows(i).Item(j)) <> "-" Then
                            totalColumna += CDbl(dtVisorLiq.Rows(i).Item(j))
                        End If

                    End If

                Next
                dtVisorLiq.Rows(6).Item(j) = totalColumna
                totalColumna = 0
                'Tarde
                For i As Integer = 6 To 13
                    If Not String.IsNullOrEmpty(dtVisorLiq.Rows(i).Item(j).ToString) Then
                        If Trim(dtVisorLiq.Rows(i).Item(j)) <> "+" And Trim(dtVisorLiq.Rows(i).Item(j)) <> "-" Then
                            totalColumna += CDbl(dtVisorLiq.Rows(i).Item(j))
                        End If

                    End If

                Next
                dtVisorLiq.Rows(13).Item(j) = totalColumna
                totalColumna = 0
                'Noche
                For i As Integer = 13 To 26
                    If Not String.IsNullOrEmpty(dtVisorLiq.Rows(i).Item(j).ToString) Then
                        If Trim(dtVisorLiq.Rows(i).Item(j)) <> "+" And Trim(dtVisorLiq.Rows(i).Item(j)) <> "-" Then
                            totalColumna += CDbl(dtVisorLiq.Rows(i).Item(j))
                        End If

                    End If

                Next
                dtVisorLiq.Rows(26).Item(j) = totalColumna
                totalColumna = 0

            Next

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try




        Return dtVisorLiq

    End Function

    ''Claudia Garay Febrero 1 2012. 
    Private Function ActualizaSecuencia(ByRef dt As DataTable) As DataTable


        If Not dt Is Nothing Then

            If dt.Rows.Count > 0 Then

                For i As Integer = 0 To dt.Rows.Count - 1

                    dt.Rows(i).Item("secuencia") = i


                Next

            End If

        End If

        Return dt
    End Function



    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnImprimirPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirPlan.Click

        Dim iHoraIni_RecNac As Nullable(Of Integer)
        Dim iHoraFin_RecNac As Nullable(Of Integer)

        Dim fechavisor As Date

        If mskFechaHasta.Text <> "  /  /" Then
            fechavisor = mskFechaHasta.Text
            fecha = Format(fechavisor, General.FormatoFechaCorta)
        Else
            fecha = Format(objDao.traerFechaServidor(), General.FormatoFechaCorta)
        End If


        If General Is Nothing Then
            MsgBox("No existen parametros de entrada.", MsgBoxStyle.Information)
            Exit Sub
        End If

        frmRepLiquidos.Show()
        frmRepLiquidos.imprimirRepLiquidosAdmin(datosconexion, codhistoria, fecha, fecha, iHoraIni_RecNac, iHoraFin_RecNac)

    End Sub



    Private Sub btnVisor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisor.Click
        If mskFechaHasta.Text = "  /  /" Then
            Exit Sub
        End If
        dtgLiqAdmin.DataSource = Nothing
        dtgLiqElim.DataSource = Nothing
        cargarDatos(mskFechaHasta.Text, mskFechaHasta.Text)
    End Sub


    Private Sub mskFechaHasta_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskFechaHasta.Validating
        If mskFechaHasta.Text <> "  /  /" Then
            If Not IsDate(mskFechaHasta.Text) Then
                MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Frm_PantallaLiquidos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        General = objGeneral.Instancia
        fecha = Format(objDao.traerFechaServidor(), General.FormatoFechaCorta)
        cargarDatos(fecha, fecha)
        mskFechaHasta.Text = Format(CDate(fecha), "dd/MM/yyyy")

    End Sub
    Private Sub AgregarAlArreglo()

        AGrilla.Clear()
        AGrilla.Add("7")
        AGrilla.Add("8")
        AGrilla.Add("9")
        AGrilla.Add("10")
        AGrilla.Add("11")
        AGrilla.Add("12")
        AGrilla.Add("SUBT")
        AGrilla.Add("13")
        AGrilla.Add("14")
        AGrilla.Add("15")
        AGrilla.Add("16")
        AGrilla.Add("17")
        AGrilla.Add("18")
        AGrilla.Add("SUBT")
        AGrilla.Add("19")
        AGrilla.Add("20")
        AGrilla.Add("21")
        AGrilla.Add("22")
        AGrilla.Add("23")
        AGrilla.Add("0")
        AGrilla.Add("1")
        AGrilla.Add("2")
        AGrilla.Add("3")
        AGrilla.Add("4")
        AGrilla.Add("5")
        AGrilla.Add("6")
        AGrilla.Add("SUBT")

    End Sub
    Public Function traerDatosLiquidos(ByVal strFechaIni_RecNac As Nullable(Of DateTime), ByVal strFechaFin_RecNac As Nullable(Of DateTime)) As DataTable

        Dim dsDatos As DataTable
        datosconexion = objcon.Instancia

        dsDatos = objLiquidos.consultarLiquidos(datosconexion, Me.codhistoria, strFechaIni_RecNac, strFechaFin_RecNac)

        Return dsDatos
    End Function
    Public Sub cargarDatos(ByVal strFechaIni_RecNac As Nullable(Of DateTime), ByVal strFechaFin_RecNac As Nullable(Of DateTime))



        Dim dtLiquidos As New DataTable
        Dim dtLiquidosAdm As New DataTable
        Dim dtLiquidosElim As New DataTable

        Dim dtRows() As DataRow
        Dim dtRow As DataRow
        'cargamos grilla de liquidos administrados
        dtLiquidos = traerDatosLiquidos(strFechaIni_RecNac, strFechaFin_RecNac)
        dtLiquidosAdm = dtLiquidos.Copy
        dtLiquidosElim = dtLiquidos.Copy

        dtRows = dtLiquidosAdm.Select("tipo = 'LE'")
        For Each dtRow In dtRows
            dtLiquidosAdm.Rows.Remove(dtRow)
        Next

        dtRows = dtLiquidosElim.Select("tipo = 'LA'")
        For Each dtRow In dtRows
            dtLiquidosElim.Rows.Remove(dtRow)
        Next
        arrColLiqAdmin.Clear()
        Me.dtgLiqAdmin.DataSource = ConfiguraDatosGrillaLiqAdministrados(dtLiquidosAdm, arrColLiqAdmin)
        arrColLiqElim.Clear()
        Me.dtgLiqElim.DataSource = ConfiguraDatosGrillaLiqAdministrados(dtLiquidosElim, arrColLiqElim)

    End Sub

    Private Sub dtgLiqAdmin_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgLiqAdmin.CellContentClick

    End Sub

    Public Sub dtgLiqAdmin_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dtgLiqAdmin.CellPainting

        If (e.RowIndex = -1 And e.ColumnIndex > 0 And e.ColumnIndex < dtgLiqAdmin.Columns.Count - 1) Then


            e.PaintBackground(e.CellBounds, True)
            e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom)
            e.Graphics.RotateTransform(-90)
            e.Graphics.DrawString(e.FormattedValue.ToString(), e.CellStyle.Font, Brushes.Black, 5, 5)
            e.Graphics.ResetTransform()
            e.Handled = True
            dtgLiqAdmin.Columns(e.ColumnIndex).Width = 50
            dtgLiqAdmin.Columns(e.ColumnIndex).ToolTipText = arrColLiqAdmin(e.ColumnIndex - 1).ToString

        End If
        dtgLiqAdmin.Columns(0).Width = 40
        dtgLiqAdmin.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        If e.RowIndex = 6 Or e.RowIndex = 13 Or e.RowIndex = 26 Then
            e.CellStyle.Font = New System.Drawing.Font("Verdana", 8.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End If
    End Sub

    Private Sub dtgLiqElim_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dtgLiqElim.CellPainting

        If (e.RowIndex = -1 And e.ColumnIndex > 0 And e.ColumnIndex < dtgLiqElim.Columns.Count - 1) Then
            e.PaintBackground(e.CellBounds, True)
            e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom)
            e.Graphics.RotateTransform(-90)
            e.Graphics.DrawString(e.FormattedValue.ToString(), e.CellStyle.Font, Brushes.Black, 5, 5)
            e.Graphics.ResetTransform()
            e.Handled = True
            dtgLiqElim.Columns(e.ColumnIndex).Width = 50
            dtgLiqElim.Columns(e.ColumnIndex).ToolTipText = arrColLiqElim(e.ColumnIndex - 1).ToString

        End If
        dtgLiqElim.Columns(0).Width = 40
        dtgLiqElim.Columns("Total").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight


        If e.RowIndex = 6 Or e.RowIndex = 13 Or e.RowIndex = 26 Then
            e.CellStyle.Font = New System.Drawing.Font("Verdana", 8.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End If
    End Sub
  
End Class