Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports System.Globalization
Imports System.Threading
Imports System.Math
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes




Public Class frm_ConsultaLiquidos
    Private General As objGeneral
    Private Paciente As objPaciente
    Private m_CodHistoria As Integer
    Private m_peso As Double = 0
    Private m_edad As Double = 0
    Private m_edadmeses As Double = 0
    Private m_edaddias As Double = 0
    Private m_DtliquAdmin As DataTable = New DataTable()
    Private m_DtliquElim As DataTable
    Private fechaRep As String
    Private objDao As New DAOGeneral
    Private datosconexion As objCon
    Private m_fechaConsulta As String = String.Empty
    Private formulaGastoPeso As Boolean = False
    Private formulaGastoCorporal As Boolean = False
    Private valor As String = String.Empty
    Private valorUnidadMedida As String = String.Empty
    Private valorGastoUrinario As Double = 0
    Private m_prestador As String = String.Empty
    Private m_numAdmision As Integer = 0
    Private m_sucursal As String = String.Empty
    Private m_anoAdmision As Integer = 0
    Private m_tipoAdmision As String = String.Empty
    Private m_CalculoPrimeraSeccion As Boolean = False
    Private m_CalculoSegundaSeccion As Boolean = False
    Private m_CalculoTerceraSeccion As Boolean = False
    Private m_CalculoCuartaSeccion As Boolean = False
    Private m_AdmisionDiaEnCurso As Boolean = False
    Private m_horaInicio As Integer = 0


    Public Sub New(ByVal dCod_Historia As String, ByVal strFechaIni_RecNac As Nullable(Of DateTime), ByVal strFechaFin_RecNac As Nullable(Of DateTime), ByVal iHoraIni_RecNac As Nullable(Of Integer), ByVal iHoraFin_RecNac As Nullable(Of Integer))

        m_CodHistoria = dCod_Historia

        ' Llamada necesaria para el Diseñador de Windows Forms.
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        InitializeComponent()

    End Sub

    Private Sub btnImprimirPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirPlan.Click

        Dim fechaInicial As Date
        Dim fechaFinal As Date
        Dim strFechaInicial As String = String.Empty
        Dim strFechaFinal As String = String.Empty
        Dim diferenciaDias As Integer = 0
        Dim g_iMes As Integer = 4

        If mskFechaInicial.Text <> "  /  /" Then
            If Val(Mid(mskFechaInicial.Text, g_iMes, 2)) > 12 Then    'Validacion del Mes
                MessageBox.Show("La fecha inicial es incorrecta", "Validacion Fecha", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            fechaInicial = CDate(mskFechaInicial.Text)
            strFechaInicial = BLPlaneacion.obtenerFecha(fechaInicial)

            If mskFechaFinal.Text <> "  /  /" Then
                If Val(Mid(mskFechaFinal.Text, g_iMes, 2)) > 12 Then    'Validacion del Mes
                    MessageBox.Show("La fecha Final es incorrecta", "Validacion Fecha", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub
                End If

                fechaFinal = CDate(mskFechaFinal.Text)

                If fechaInicial > fechaFinal Then

                    MessageBox.Show("La fecha inicial no debe ser mayor a la fecha final", "Validacion Fecha", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Exit Sub

                End If

                strFechaFinal = BLPlaneacion.obtenerFecha(fechaFinal)
                diferenciaDias = BLPlaneacion.obtenerDiferenciaDia(strFechaInicial, strFechaFinal)

                '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
                'Juan Carlos Jaramillo Lozano - IG
                RptHC_Enf_Med.Show()
                RptHC_Enf_Med.ImprimirHistoriaClinica(datosconexion, "|srptEnfLiquidosAdminDet1|", "41", Format(fechaInicial, "yyyy/MM/dd"), Format(fechaFinal, "yyyy/MM/dd"), Nothing, Nothing, "0", Format(Date.Now, "yyyy/MM/dd"))
                '2019-03-11 Fin

                'frmRepLiquidos.Show()
                'frmRepLiquidos.imprimirRepLiquidosAdmin(datosconexion, m_CodHistoria, strFechaInicial, diferenciaDias, m_peso, m_edad)

                Exit Sub

            End If
            '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
            'Juan Carlos Jaramillo Lozano - IG
            RptHC_Enf_Med.Show()
            RptHC_Enf_Med.ImprimirHistoriaClinica(datosconexion, "|srptEnfLiquidosAdminDet1|", "41", Format(fechaInicial, "yyyy/MM/dd"), Format(fechaFinal, "yyyy/MM/dd"), Nothing, Nothing, "0", Format(Date.Now, "yyyy/MM/dd"))
            '2019-03-11 Fin

            'frmRepLiquidos.Show()
            'frmRepLiquidos.imprimirRepLiquidosAdmin(datosconexion, m_CodHistoria, strFechaInicial, 0, m_peso, m_edad)

        Else

            MessageBox.Show("Debe diligenciar la fecha inicial", "Validacion Fecha", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If

    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click

        Me.Close()

    End Sub
    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Label5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label5.Click

    End Sub

    Private Sub frm_ConsultaLiquidos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        mskFechaFinal.Text = String.Empty
        mskFechaHasta.Text = String.Empty
        mskFechaInicial.Text = String.Empty

        General = objGeneral.Instancia
        Paciente = objPaciente.Instancia

        CargarLiquidosAdministrados(obtenerFechaAnterior())

        CargarLiquidosEliminados(obtenerFechaAnterior())

        If m_peso = 0 Then

            MessageBox.Show("No se puede realizar el cálculo de Gasto Urinario porque no se ha registrado el peso del paciente en la sección Signos Vitales", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Information)

        End If



        AsignarFechaAnterior()

        cargarBalance()

    End Sub

    'Dsanchez IG - 24/10/2017, Metodo que se usa para asignar fecha anterior en campo
    Private Sub AsignarFechaAnterior()

        Dim fechaAnterior As Date = Date.Now.AddDays(-1)
        Dim dia As String = String.Empty
        Dim mes As String = String.Empty
        Dim ano As String = String.Empty

        If fechaAnterior.Hour <= 6 Then
            fechaAnterior = Date.Now.AddDays(-2)
        End If

        If fechaAnterior.Day().ToString().Length() = 1 Then

            dia = "0" + fechaAnterior.Day().ToString()

        Else

            dia = fechaAnterior.Day().ToString()

        End If

        If fechaAnterior.Month().ToString().Length() = 1 Then

            mes = "0" + fechaAnterior.Month().ToString()

        Else

            mes = fechaAnterior.Month().ToString()

        End If

        ano = fechaAnterior.Year().ToString()

        mskFechaHasta.Text = dia + mes + ano


    End Sub
    Private Sub EstablecerValoresCalculoBalance(ByVal horaAdmision As Integer, ByVal horaActual As Integer)

        If horaAdmision >= 7 And horaAdmision <= 12 Then

            m_CalculoPrimeraSeccion = True

            If horaActual >= 7 And horaActual <= 12 Then

                m_CalculoPrimeraSeccion = True

            End If

            If horaActual >= 13 And horaActual <= 18 Then
                m_CalculoPrimeraSeccion = True
                m_CalculoSegundaSeccion = True

            End If

            If (horaActual >= 19 And horaActual <= 23) Or horaActual = 0 Then

                m_CalculoPrimeraSeccion = True
                m_CalculoSegundaSeccion = True
                m_CalculoTerceraSeccion = True

            End If

            If horaActual >= 1 And horaActual <= 6 Then

                m_CalculoPrimeraSeccion = True
                m_CalculoSegundaSeccion = True
                m_CalculoTerceraSeccion = True
                m_CalculoCuartaSeccion = True

            End If

        End If

        If horaAdmision >= 13 And horaAdmision <= 18 Then

            m_CalculoSegundaSeccion = True

            If horaActual >= 13 And horaActual <= 18 Then

                m_CalculoSegundaSeccion = True

            End If

            If (horaActual >= 19 And horaActual <= 23) Or horaActual = 0 Then

                m_CalculoSegundaSeccion = True
                m_CalculoTerceraSeccion = True

            End If

            If horaActual >= 1 And horaActual <= 6 Then

                m_CalculoSegundaSeccion = True
                m_CalculoTerceraSeccion = True
                m_CalculoCuartaSeccion = True

            End If

        End If

        If (horaAdmision >= 19 And horaAdmision <= 23) Or horaAdmision = 0 Then

            m_CalculoTerceraSeccion = True

            If (horaActual >= 19 And horaActual <= 23) Or horaActual = 0 Then

                m_CalculoTerceraSeccion = True

            End If

            If horaActual >= 1 And horaActual <= 6 Then

                m_CalculoTerceraSeccion = True
                m_CalculoCuartaSeccion = True

            End If

        End If

        If horaAdmision >= 1 And horaAdmision <= 6 Then

            m_CalculoCuartaSeccion = True

        End If

    End Sub

    Private Function obtenerFechaActual() As String

        Dim fecha As String = String.Empty
        Dim fActual As Date = Date.Now()

        fecha = fActual.Year.ToString()

        If fActual.Month().ToString().Length() = 1 Then

            fecha = fecha + "0" + fActual.Month().ToString()

        Else

            fecha = fecha + fActual.Month().ToString()

        End If

        If fActual.Day().ToString().Length() = 1 Then

            fecha = fecha + "0" + fActual.Day.ToString()

        Else

            fecha = fecha + fActual.Day.ToString()

        End If

        Return fecha

    End Function

    Private Sub CargarLiquidosAdministrados(ByVal fecha As String)

        Dim dtInfo As DataTable
        Dim dtliquidosAdminInfo As DataTable = New DataTable()
        Dim dtAuxiliar As DataTable
        Dim indexCol As Integer
        Dim sNombreColumna As String
        Dim valor As Double = 0
        Dim suma As Double = 0

        m_fechaConsulta = fecha
        m_DtliquAdmin = dtliquidosAdminInfo
        dtgLiqAdmin.DataSource = Nothing

        dtInfo = BLPlaneacion.ConsulLiqAdmin(m_CodHistoria, fecha)

        dtInfo.Columns.Add("TOTAL", Type.GetType("System.String"))

        For Each columna As DataColumn In dtInfo.Columns

            Dim dc As New DataColumn(columna.ColumnName, columna.DataType)

            m_DtliquAdmin.Columns.Add(dc)

        Next

        For Each fila As DataRow In dtInfo.Rows

            suma = 0

            For i As Integer = 0 To dtInfo.Columns.Count - 1

                If Not dtInfo.Columns(i).Caption.ToString = "HORA" And Not dtInfo.Columns(i).Caption.ToString = "ID" _
                                                                               And Not dtInfo.Columns(i).Caption.ToString = "TOTAL" Then

                    If fila(i).ToString().Equals(String.Empty) Then

                        valor = 0

                    Else

                        valor = Convert.ToDouble(fila(i).ToString())

                    End If

                    suma = suma + valor

                End If

            Next

            Dim filaNueva As DataRow = m_DtliquAdmin.NewRow

            For j As Integer = 0 To m_DtliquAdmin.Columns.Count - 1

                filaNueva(j) = fila(j)





            Next

            If suma.Equals(0) Then

                filaNueva("TOTAL") = String.Empty

            Else

                filaNueva("TOTAL") = suma.ToString()

            End If

            m_DtliquAdmin.Rows.Add(filaNueva)

        Next

        m_DtliquAdmin.Columns(0).SetOrdinal(m_DtliquAdmin.Columns.Count - 1)

        dtgLiqAdmin.DataSource = m_DtliquAdmin

        dtgLiqAdmin.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        dtgLiqAdmin.Columns("ID").Visible = False

        For i As Integer = 0 To dtgLiqAdmin.Columns.Count - 1

            If dtgLiqAdmin.Columns(i).Name.Contains("|") Then

                'dtAuxiliar = BLPlaneacion.ConsultaHeaderColumna(fecha, m_CodHistoria, BLPlaneacion.obtenerNombreLiquido(dtgLiqAdmin.Columns(i).Name, "LA"), BLPlaneacion.ObtenerNroOrden(dtgLiqAdmin.Columns(i).Name, "LA"))
                'sNombreColumna = BLPlaneacion.obtenerNombreLiquido(dtgLiqAdmin.Columns(i).Name, "LA")
                dtAuxiliar = BLPlaneacion.ConsultaHeaderColumna(fecha, m_CodHistoria, dtgLiqAdmin.Columns(i).Name, 0)

                indexCol = dtgLiqAdmin.Columns(i).Name.IndexOf("|")
                sNombreColumna = dtgLiqAdmin.Columns(i).Name.Substring(0, indexCol)

                If sNombreColumna.Length > 25 Then

                    dtgLiqAdmin.Columns(i).HeaderText = sNombreColumna.Substring(0, 25)

                Else

                    dtgLiqAdmin.Columns(i).HeaderText = sNombreColumna

                End If

                For Each fila As DataRow In dtAuxiliar.Rows

                    dtgLiqAdmin.Columns(i).ToolTipText = fila(0).ToString()

                Next

            End If

            dtgLiqAdmin.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            dtgLiqAdmin.AutoResizeColumns()
            dtgLiqAdmin.Columns("HORA").Frozen = True
            dtgLiqAdmin.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader

            For j As Integer = 0 To dtgLiqAdmin.Columns.Count() - 1

                dtgLiqAdmin.Columns(j).SortMode = DataGridViewColumnSortMode.NotSortable

            Next

        Next

    End Sub

    Private Function obtenerFechaAnterior() As String

        Dim fecha As String = String.Empty
        Dim fActual As Date = Date.Now().AddDays(-1)


        If fActual.Hour <= 6 Then
            fActual = Date.Now.AddDays(-2)
        End If

        fecha = fActual.Year.ToString()

        If fActual.Month().ToString().Length() = 1 Then

            fecha = fecha + "0" + fActual.Month().ToString()

        Else

            fecha = fecha + fActual.Month().ToString()

        End If

        If fActual.Day().ToString().Length() = 1 Then

            fecha = fecha + "0" + fActual.Day.ToString()

        Else

            fecha = fecha + fActual.Day.ToString()

        End If

        Return fecha

    End Function

    Public Sub Mostrar(ByVal codHistoria As Integer, ByVal peso As Double, ByVal edad As Double, ByVal prestador As String, ByVal sucursal As String, ByVal numAdmision As Integer, ByVal anoAdmision As Integer, ByVal tipoAdmision As String)

        m_CodHistoria = codHistoria
        m_peso = peso
        m_edad = edad
        m_prestador = prestador
        m_sucursal = sucursal
        m_tipoAdmision = tipoAdmision
        m_anoAdmision = anoAdmision
        m_numAdmision = numAdmision

        Me.ShowDialog()

    End Sub

    Private Sub CargarLiquidosEliminados(ByVal fecha As String)
        Dim dtliquidosElim As DataTable
        Dim dtliquidosElimInfo As DataTable = New DataTable()
        Dim valor As Double = 0
        Dim suma As Double = 0

        Try

            m_fechaConsulta = fecha
            dtgLiqElim.DataSource = Nothing
            m_DtliquElim = dtliquidosElimInfo

            dtliquidosElim = BLPlaneacion.ConsultaLiquidoEliminado(m_CodHistoria, fecha)

            dtliquidosElim.Columns.Add("TOTAL", Type.GetType("System.String"))

            For Each columna As DataColumn In dtliquidosElim.Columns

                Dim dc As New DataColumn(columna.ColumnName, columna.DataType)

                m_DtliquElim.Columns.Add(dc)

            Next

            For Each fila As DataRow In dtliquidosElim.Rows

                suma = 0

                For i As Integer = 0 To dtliquidosElim.Columns.Count - 1

                    If Not dtliquidosElim.Columns(i).Caption.ToString = "HORA" And Not dtliquidosElim.Columns(i).Caption.ToString = "ID" _
                                                                               And Not dtliquidosElim.Columns(i).Caption.ToString = "TOTAL" Then

                        If fila(i).ToString().Equals(String.Empty) Then

                            valor = 0

                        Else

                            If fila(i).ToString() = "+" Or fila(i).ToString() = "-" Then

                                valor = 0

                            Else

                                valor = Convert.ToDouble(fila(i).ToString())

                            End If

                        End If

                        suma = suma + valor

                    End If

                Next

                Dim filaNueva As DataRow = m_DtliquElim.NewRow

                For j As Integer = 0 To m_DtliquElim.Columns.Count - 1

                    filaNueva(j) = fila(j)

                Next

                If suma.Equals(0) Then

                    filaNueva("TOTAL") = String.Empty

                Else

                    filaNueva("TOTAL") = suma.ToString()

                End If

                m_DtliquElim.Rows.Add(filaNueva)

            Next

            m_DtliquElim.Columns(0).SetOrdinal(m_DtliquElim.Columns.Count - 1)

            dtgLiqElim.DataSource = m_DtliquElim

            dtgLiqElim.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
            dtgLiqElim.Columns("ID").Visible = False

            For i As Integer = 0 To dtgLiqElim.Columns.Count - 1

                dtgLiqElim.Columns(i).HeaderText = fixNameColumnLiqElim(dtgLiqElim.Columns(i).Name)
                dtgLiqElim.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            Next

            dtgLiqElim.AutoResizeColumns()
            dtgLiqElim.Columns("HORA").Frozen = True
            dtgLiqElim.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader

            For j As Integer = 0 To dtgLiqElim.Columns.Count() - 1

                dtgLiqElim.Columns(j).SortMode = DataGridViewColumnSortMode.NotSortable

            Next

        Catch ex As Exception
            MsgBox("Error al cargar grilla de Liquidos Eliminados. " & ex.Message, MsgBoxStyle.Information)
        End Try

    End Sub

    Private Function fixNameColumnLiqElim(ByVal nombreLiquido As String) As String

        Dim nroOrden As String
        Dim lateral As Char
        Dim resultado As String

        If nombreLiquido.Contains("|") Then

            lateral = BLPlaneacion.obtenerLateralidad(nombreLiquido, "LE")
            nroOrden = BLPlaneacion.ObtenerNroOrden(nombreLiquido, "LE")
            resultado = BLPlaneacion.obtenerNombreLiquido(nombreLiquido, "LE")



            If lateral = "I" Then

                resultado = resultado + "(" + "IZQ" + ")"

            End If

            If lateral = "D" Then

                resultado = resultado + "(" + "DER" + ")"

            End If

            If Convert.ToInt32(nroOrden) > 0 Then

                resultado = resultado + "(" + nroOrden + ")"

            End If

        Else

            resultado = nombreLiquido

        End If

        Return resultado

    End Function

    Private Sub dtgLiqAdmin_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtgLiqAdmin.Sorted

        For Each columna As DataGridViewColumn In dtgLiqAdmin.Columns

            columna.SortMode = DataGridViewColumnSortMode.NotSortable

        Next

    End Sub

    Private Sub dtgLiqAdmin_ColumnSortModeChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs)

        For Each columna As DataGridViewColumn In dtgLiqAdmin.Columns

            columna.SortMode = DataGridViewColumnSortMode.NotSortable

        Next

    End Sub

    Private Sub dtgLiqAdmin_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dtgLiqAdmin.Scroll

        If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then

            If Me.dtgLiqElim.Rows.Count > 0 And Me.dtgLiqAdmin.Rows.Count > 0 Then

                dtgLiqElim.FirstDisplayedScrollingRowIndex = dtgLiqAdmin.FirstDisplayedScrollingRowIndex

            End If

        End If

        If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then

            If Me.dtgConsultaBalance.Rows.Count > 0 And Me.dtgLiqAdmin.Rows.Count > 0 Then

                dtgConsultaBalance.FirstDisplayedScrollingRowIndex = dtgLiqAdmin.FirstDisplayedScrollingRowIndex

            End If

        End If

    End Sub

    Private Sub dtgLiqElim_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dtgLiqElim.Scroll

        If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then

            If Me.dtgLiqAdmin.Rows.Count > 0 And Me.dtgLiqElim.Rows.Count > 0 Then

                dtgLiqAdmin.FirstDisplayedScrollingRowIndex = dtgLiqElim.FirstDisplayedScrollingRowIndex

            End If

        End If

        If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then

            If Me.dtgConsultaBalance.Rows.Count > 0 And Me.dtgLiqElim.Rows.Count > 0 Then

                dtgConsultaBalance.FirstDisplayedScrollingRowIndex = dtgLiqElim.FirstDisplayedScrollingRowIndex

            End If

        End If

    End Sub

    Private Sub dtgLiqElim_Sorted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtgLiqElim.Sorted

        For Each columna As DataGridViewColumn In dtgLiqElim.Columns

            columna.SortMode = DataGridViewColumnSortMode.NotSortable

        Next

    End Sub

    Private Sub dtgLiqElim_ColumnSortModeChanged(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewColumnEventArgs) Handles dtgLiqElim.ColumnSortModeChanged, dtgLiqAdmin.ColumnSortModeChanged

        For Each columna As DataGridViewColumn In dtgLiqElim.Columns

            columna.SortMode = DataGridViewColumnSortMode.NotSortable

        Next

    End Sub

    Private Sub btnVisor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisor.Click

        Dim fecha As Date
        Dim fechacero As DataTable
        Dim fechaval As String

        If mskFechaHasta.Text = "  /  /" Then
            Exit Sub
        End If

        fecha = CDate(mskFechaHasta.Text)

        If fecha > Date.Now Then

            MessageBox.Show("La fecha consultada es mayor a la actual", "Fecha", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub

        End If

        CargarLiquidosAdministrados(BLPlaneacion.obtenerFecha(fecha))
        CargarLiquidosEliminados(BLPlaneacion.obtenerFecha(fecha))

        fechacero = objDao.ConsultarDiasHistorico("horaceroliquidos")

        If fechacero.Rows.Count > 0 Then
            fechaval = fechacero.Rows(0).Item("valor").ToString
        End If
        'rmzaldua  
        'se valida la fecha en que sale la version para que no muestre los balances de fecha anterior al despliegue
        If Format(fecha, "yyyyMMdd") >= fechaval Then
            cargarBalance()
        Else
            dtgConsultaBalance.DataSource = Nothing
        End If
    End Sub

    Private Sub cargarBalance()

        Dim dtAdministrados As DataTable = New DataTable()
        Dim dtEliminados As DataTable = New DataTable()
        Dim dtBalance As DataTable = New DataTable()
        Dim iFilas As Integer = 29
        Dim valorAdministrado As Double = 0
        Dim valorEliminado As Double = 0
        Dim valorBal As Double = 0
        Dim iCantidadHoras As Integer = 0
        Dim horas(3) As Integer

        horas(0) = 0
        horas(1) = 0
        horas(2) = 0
        horas(3) = 0

        dtAdministrados = dtgLiqAdmin.DataSource
        dtEliminados = dtgLiqElim.DataSource

        If dtAdministrados.Columns.Count > 3 Or dtEliminados.Columns.Count > 3 Then

            dtBalance.Columns.Add("HORA")
            dtBalance.Columns.Add("BALANCE_HORARIO")
            dtBalance.Columns.Add("GASTO_URINARIO")

            For i As Integer = 1 To iFilas

                Dim dtFila As DataRow = dtBalance.NewRow
                Dim hora As String = String.Empty

                If i <= 6 Then

                    hora = Convert.ToString(i + 6)

                End If

                If i > 7 And i <= 13 Then

                    hora = Convert.ToString(i + 5)

                End If

                If i > 14 And i <= 19 Then

                    hora = Convert.ToString(i + 4)

                End If
                If i = 20 Then

                    hora = Convert.ToString(0)

                End If

                If i > 21 And i <= 27 Then

                    hora = Convert.ToString(i - 21)

                End If
                If i = 7 Or i = 14 Or i = 21 Or i = 28 Then

                    hora = "SUBTOTAL"

                End If

                If i = 29 Then

                    hora = "TOTAL"

                End If


                dtFila("HORA") = hora
                dtBalance.Rows.Add(dtFila)

            Next

            For i As Integer = 0 To dtBalance.Rows.Count - 1

                If dtgLiqAdmin.Rows(i).Cells("TOTAL").Value.ToString() = String.Empty And dtgLiqElim.Rows(i).Cells("TOTAL").Value.ToString() = String.Empty Then

                    dtBalance.Rows(i)("BALANCE_HORARIO") = String.Empty
                    If dtgLiqAdmin.Rows(i).Cells("TOTAL").Value.ToString() = String.Empty Then

                        valorAdministrado = 0

                    Else

                        valorAdministrado = Convert.ToDouble(dtgLiqAdmin.Rows(i).Cells("TOTAL").Value)

                    End If

                    If dtgLiqElim.Rows(i).Cells("TOTAL").Value.ToString() = String.Empty Then

                        valorEliminado = 0

                    Else

                        valorEliminado = Convert.ToDouble(dtgLiqElim.Rows(i).Cells("TOTAL").Value)

                    End If
                    valorBal = valorAdministrado - valorEliminado
                    If i = 6 Then
                        dtBalance.Rows(i)("BALANCE_HORARIO") = Convert.ToString(Round(valorBal, 1))
                    End If

                    If i = 13 Then
                        dtBalance.Rows(i)("BALANCE_HORARIO") = Convert.ToString(Round(valorBal, 1))
                    End If

                    If i = 20 Then
                        dtBalance.Rows(i)("BALANCE_HORARIO") = Convert.ToString(Round(valorBal, 1))
                    End If

                    If i = 27 Then
                        dtBalance.Rows(i)("BALANCE_HORARIO") = Convert.ToString(Round(valorBal, 1))
                    End If

                    If i = 28 Then
                        dtBalance.Rows(i)("BALANCE_HORARIO") = Convert.ToString(Round(valorBal, 1))
                    End If
                Else

                    If dtgLiqAdmin.Rows(i).Cells("TOTAL").Value.ToString() = String.Empty Then

                        valorAdministrado = 0

                    Else

                        valorAdministrado = Convert.ToDouble(dtgLiqAdmin.Rows(i).Cells("TOTAL").Value)

                    End If

                    If dtgLiqElim.Rows(i).Cells("TOTAL").Value.ToString() = String.Empty Then

                        valorEliminado = 0

                    Else

                        valorEliminado = Convert.ToDouble(dtgLiqElim.Rows(i).Cells("TOTAL").Value)

                    End If

                    valorBal = valorAdministrado - valorEliminado

                    dtBalance.Rows(i)("BALANCE_HORARIO") = Convert.ToString(Round(valorBal, 1))

                End If

            Next

            dtgConsultaBalance.DataSource = dtBalance

            For i As Integer = 0 To dtgConsultaBalance.Columns.Count - 1

                dtgConsultaBalance.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            Next

            dtgConsultaBalance.Columns("HORA").HeaderText = "HORA"
            dtgConsultaBalance.Columns("BALANCE_HORARIO").HeaderText = "BALANCE HORARIO"
            dtgConsultaBalance.Columns("GASTO_URINARIO").HeaderText = "GASTO URINARIO ACUMULADO"

            dtgConsultaBalance.AutoResizeColumns()
            dtgConsultaBalance.Columns("HORA").Frozen = True
            dtgConsultaBalance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader

            'iCantidadHoras = validaHora(horas)
            'calculoGastoUrinario(iCantidadHoras, dtgConsultaBalance.DataSource)

            iCantidadHoras = obtenerHora(horas)

            If m_AdmisionDiaEnCurso Then

                calculoGastoUrinarioDiaEnCurso(dtgConsultaBalance.DataSource, horas)

            Else

                calculoGastoUrinario(iCantidadHoras, dtgConsultaBalance.DataSource, horas)

        End If


        Else

            dtBalance.Columns.Add("HORA")
            dtBalance.Columns.Add("BALANCE_HORARIO")
            dtBalance.Columns.Add("GASTO_URINARIO")

            For i As Integer = 1 To iFilas

                Dim dtFila As DataRow = dtBalance.NewRow
                Dim hora As String = String.Empty

                If i <= 6 Then

                    hora = Convert.ToString(i + 6)

                End If

                If i > 7 And i <= 13 Then

                    hora = Convert.ToString(i + 5)

                End If

                If i > 14 And i <= 19 Then

                    hora = Convert.ToString(i + 4)

                End If

                If i = 20 Then

                    hora = Convert.ToString(0)

                End If


                If i > 21 And i <= 27 Then

                    hora = Convert.ToString(i - 21)

                End If

                If i = 7 Or i = 14 Or i = 21 Or i = 28 Then

                    hora = "SUBTOTAL"

                End If

                If i = 29 Then

                    hora = "TOTAL"

                End If

                dtFila("HORA") = hora
                dtBalance.Rows.Add(dtFila)

            Next

            dtgConsultaBalance.DataSource = dtBalance

            For i As Integer = 0 To dtgConsultaBalance.Columns.Count - 1

                dtgConsultaBalance.Columns(i).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            Next

            dtgConsultaBalance.Columns("HORA").HeaderText = "HORA"
            dtgConsultaBalance.Columns("BALANCE_HORARIO").HeaderText = "BALANCE HORARIO"
            dtgConsultaBalance.Columns("GASTO_URINARIO").HeaderText = "GASTO URINARIO ACUMULADO"

            dtgConsultaBalance.AutoResizeColumns()
            dtgConsultaBalance.Columns("HORA").Frozen = True
            dtgConsultaBalance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader

            For j As Integer = 0 To dtgConsultaBalance.Columns.Count() - 1

                dtgConsultaBalance.Columns(j).SortMode = DataGridViewColumnSortMode.NotSortable

            Next

        End If


    End Sub

    Private Function validaHora(ByRef horas() As Integer) As Integer

        Dim fechActual As String = String.Empty

        fechActual = BLPlaneacion.obtenerFecha(Date.Now.Date)

        If fechActual = m_fechaConsulta Then

            Return obtenerHora(horas)

        Else

            Return 24

        End If

    End Function

    Private Function obtenerHora(ByRef horas() As Integer) As Integer

        Dim fechaActual As Date = Date.Now()
        Dim strFechaActual As String = String.Empty
        Dim HoraIngresoAdmision As Integer = 0
        Dim fechaAdmision As String = String.Empty
        Dim resultado As Integer = 0
        Dim horaMinima As Integer = 0
        Dim horaMaxima As Integer = 0
        Dim fechActual As String = String.Empty
        Dim fechConsulta As String = String.Empty

        datosconexion = objCon.Instancia

        fechActual = BLPlaneacion.obtenerFecha(Date.Now.Date)
        Me.m_AdmisionDiaEnCurso = False
        BLPlaneacion.ObtenerFechaHoraAdmision(datosconexion, General.Prestador, General.Sucursal, Paciente.NumeroAdmision, Paciente.AnoAdmision, Paciente.TipoAdmision, fechaAdmision, HoraIngresoAdmision)
        'BLPlaneacion.ObtenerFechaHoraAdmision(General.Prestador, General.Sucursal, Paciente.NumeroAdmision, Paciente.AnoAdmision, Paciente.TipoAdmision, fechaAdmision, HoraIngresoAdmision)

        If Date.Now().Day().ToString().Length() = 1 Then

            strFechaActual = "0" + Date.Now().Day().ToString() + "/"

        Else

            strFechaActual = Date.Now().Day().ToString() + "/"

        End If

        If Date.Now().Month().ToString().Length() = 1 Then

            strFechaActual = strFechaActual + "0" + Date.Now().Month().ToString() + "/"

        Else

            strFechaActual = strFechaActual + Date.Now().Month().ToString() + "/"

        End If

        strFechaActual = strFechaActual + Date.Now.Year().ToString()
        'strFechaActual = Me.mskFechaHasta.Text
        fechConsulta = Me.mskFechaHasta.Text

        If fechaAdmision = strFechaActual Then

            Me.m_AdmisionDiaEnCurso = True
            Me.EstablecerValoresCalculoBalance(HoraIngresoAdmision, Date.Now().Hour())
            horas = Me.calculoHorasPorIntervalo(HoraIngresoAdmision, Date.Now().Hour())
            m_horaInicio = HoraIngresoAdmision

        Else
            If fechaAdmision = fechConsulta Then
                horas = Me.calculoHorasPorIntervalo2(HoraIngresoAdmision)
                m_CalculoPrimeraSeccion = True
                m_CalculoSegundaSeccion = True
                m_CalculoTerceraSeccion = True
                m_CalculoCuartaSeccion = True
                Me.m_AdmisionDiaEnCurso = True
            Else
                If strFechaActual = fechConsulta Then
                    horas = Me.calculoHorasPorIntervalo(7, Date.Now().Hour())
                Else
                    horas = Me.calculoHorasPorIntervalo3(HoraIngresoAdmision)
                End If
                m_horaInicio = 0
                m_AdmisionDiaEnCurso = False
                m_CalculoPrimeraSeccion = True
                m_CalculoSegundaSeccion = True
                m_CalculoTerceraSeccion = True
                m_CalculoCuartaSeccion = True
            End If
            horaMinima = 7
            horaMaxima = Date.Now().Hour()
        End If

        resultado = (horaMaxima - horaMinima) + 1

        If resultado >= 0 Then

            If fechActual = m_fechaConsulta Then
                Return resultado
            Else
                resultado = 24
                Return resultado
            End If
        Else
            If fechaAdmision = Me.mskFechaHasta.Text Then
                resultado = resultado + 24
            Else
                resultado = 24
            End If

            Return resultado

        End If
    End Function
    Private Function calculoHorasPorIntervalo(ByVal horaAdmision As Integer, ByVal horaActual As Integer) As Integer()

        Dim horas(3) As Integer

        If horaAdmision >= 7 And horaAdmision <= 12 Then

            If horaActual >= 7 And horaActual <= 12 Then

                horas(0) = (horaActual - horaAdmision) + 1

            End If

            If horaActual >= 13 And horaActual <= 18 Then

                horas(0) = (12 - horaAdmision) + 1
                horas(1) = (horaActual - horaAdmision) + 1

            End If

            If (horaActual >= 19 And horaActual <= 23) Or horaActual = 0 Then

                horas(0) = (12 - horaAdmision) + 1
                horas(1) = (18 - horaAdmision) + 1

                If horaActual <= 23 Then

                    horas(2) = (horaActual - horaAdmision) + 1

                End If

                If horaActual = 0 Then

                    horas(2) = (24 - horaAdmision) + 1

                End If

            End If

            If horaActual >= 1 And horaActual <= 6 Then

                horas(0) = (12 - horaAdmision) + 1
                horas(1) = (18 - horaAdmision) + 1
                horas(2) = (24 - horaAdmision) + 1
                horas(3) = ((24 + horaActual) - horaAdmision) + 1

            End If

        End If

        If horaAdmision >= 13 And horaAdmision <= 18 Then

            horas(0) = 0

            If horaActual >= 13 And horaActual <= 18 Then

                horas(1) = (horaActual - horaAdmision) + 1

            End If

            If (horaActual >= 19 And horaActual <= 23) Or horaActual = 0 Then

                horas(1) = (18 - horaAdmision) + 1

                If horaActual <= 23 Then

                    horas(2) = (horaActual - horaAdmision) + 1

                End If

                If horaActual = 0 Then

                    horas(2) = (24 - horaAdmision) + 1

                End If

            End If

            If horaActual >= 1 And horaActual <= 6 Then


                horas(1) = (18 - horaAdmision) + 1
                horas(2) = (24 - horaAdmision) + 1
                horas(3) = ((24 + horaActual) - horaAdmision) + 1

            End If

        End If

        If (horaAdmision >= 19 And horaAdmision <= 23) Or horaAdmision = 0 Then

            horas(0) = 0
            horas(1) = 0

            If (horaActual >= 19 And horaActual <= 23) Or horaActual = 0 Then

                If horaActual <= 23 Then

                    horas(2) = (horaActual - horaAdmision) + 1

                End If

                If horaActual = 0 Then

                    horas(2) = (24 - horaAdmision) + 1

                End If

            End If

            If horaActual >= 1 And horaActual <= 6 Then

                horas(2) = (24 - horaAdmision) + 1
                horas(3) = ((24 + horaActual) - horaAdmision) + 1

            End If

        End If

        If horaAdmision >= 1 And horaAdmision <= 6 Then

            horas(0) = 0
            horas(1) = 0
            horas(2) = 0
            horas(3) = ((24 + horaActual) - horaAdmision) + 1

        End If

        Return horas

    End Function

    Private Function calculoHorasPorIntervalo2(ByVal horaAdmision As Integer) As Integer()

        Dim horas(3) As Integer

        horas(0) = IIf(((12 - horaAdmision) + 1) < 0, 0, ((12 - horaAdmision) + 1))

        horas(1) = IIf(((18 - horaAdmision) + 1) < 0, 0, ((18 - horaAdmision) + 1))
        horas(2) = IIf(((24 - horaAdmision) + 1) < 0, 0, ((24 - horaAdmision) + 1))
        horas(3) = ((24 + 6) - horaAdmision) + 1

        Return horas

    End Function
    Private Function calculoHorasPorIntervalo3(ByVal horaAdmision As Integer) As Integer()

        Dim horas(3) As Integer

        horas(0) = 6
        horas(1) = 12
        horas(2) = 18
        horas(3) = 24

        Return horas

    End Function
    'Dsanchez IG - 24/10/2017, Calculode gasto urinario para el día en curso
    Private Sub calculoGastoUrinarioDiaEnCurso(ByVal dtBalance As DataTable, ByVal horasCalculo() As Integer)

        Dim dtColumnas As New DataTable
        Dim horaInicial As Integer = 7
        dtColumnas.Columns.Add("NOMBRE_COLUMNA")
        Dim sumaPrimeraSeccion As Double = 0
        Dim sumaSegundaSeccion As Double = 0
        Dim sumaTerceraSeccion As Double = 0
        Dim sumaCuartaSeccion As Double = 0
        Dim resultadoPrimeraSeccion As Double = 0
        Dim resultadoSegundaSeccion As Double = 0
        Dim resultadoTerceraSeccion As Double = 0
        Dim resultadoCuartaSeccion As Double = 0
        Dim unidadMedida As String = String.Empty
        Dim resultadoInsert As Integer = 0
        Dim intervaloCerrado As Boolean = False


        For i As Integer = 0 To dtgLiqElim.Columns.Count - 1

            If dtgLiqElim.Columns(i).Name.ToString() <> "HORA" And
                dtgLiqElim.Columns(i).Name.ToString() <> "TOTAL" And
                dtgLiqElim.Columns(i).Name.ToString() <> "ID" Then

                If BLPlaneacion.ValidaLiquidoDiuresis(BLPlaneacion.obtenerNombreLiquido(dtgLiqElim.Columns(i).Name, "LE")) Then

                    Dim dtFila As DataRow = dtColumnas.NewRow
                    dtFila("NOMBRE_COLUMNA") = dtgLiqElim.Columns(i).Name

                    dtColumnas.Rows.Add(dtFila)

                End If

            End If

        Next

        'PRIMERA SECCION
        If m_CalculoPrimeraSeccion Then


            sumaPrimeraSeccion = ObtenerSumatoriaDiuresisDiaEnCurso(dtColumnas, horasCalculo(0), m_horaInicio)
            intervaloCerrado = BLPlaneacion.ValidaIntervaloCerrado(Paciente.CodHistoria, BLPlaneacion.obtenerFecha(CDate(BLPlaneacion.ObtenerFechaMedico())), 1)
            resultadoPrimeraSeccion = gastoUrinario(sumaPrimeraSeccion, horasCalculo(0), unidadMedida, intervaloCerrado, 1)

            intervaloCerrado = False

            If Not m_CalculoSegundaSeccion Then

                resultadoInsert = BLPlaneacion.InsertarBalance(Paciente.CodHistoria, resultadoPrimeraSeccion, m_peso, m_edad, m_edadmeses, m_edaddias, unidadMedida, 0, 1)

            Else

                resultadoInsert = BLPlaneacion.InsertarBalance(Paciente.CodHistoria, resultadoPrimeraSeccion, m_peso, m_edad, m_edadmeses, m_edaddias, unidadMedida, 1, 1)

            End If

            If formulaGastoCorporal Or formulaGastoPeso Then

                BLPlaneacion.ConsultarBalanceXCorte(Paciente.CodHistoria, BLPlaneacion.obtenerFecha(CDate(BLPlaneacion.ObtenerFechaMedico())), 1, m_peso, unidadMedida)

                For i As Integer = 0 To 6

                    'GASTO_URINARIO
                    'UNIDAD_MEDIDA

                    If m_peso = 0 Then

                        dtBalance.Rows(i)("GASTO_URINARIO") = "NO SE PUEDE CALCULAR"
                        dtBalance.Rows(28)("GASTO_URINARIO") = "NO SE PUEDE CALCULAR"

                    Else

                        dtBalance.Rows(i)("GASTO_URINARIO") = unidadMedida
                        dtBalance.Rows(28)("GASTO_URINARIO") = unidadMedida

                    End If

                Next

                formulaGastoCorporal = False
                formulaGastoPeso = False

            End If

        End If

        'SEGUNDA SECCION
        If m_CalculoSegundaSeccion Then


            sumaSegundaSeccion = ObtenerSumatoriaDiuresisDiaEnCurso(dtColumnas, horasCalculo(1), m_horaInicio)
            intervaloCerrado = BLPlaneacion.ValidaIntervaloCerrado(Paciente.CodHistoria, BLPlaneacion.obtenerFecha(CDate(BLPlaneacion.ObtenerFechaMedico())), 2)
            resultadoSegundaSeccion = gastoUrinario(sumaSegundaSeccion, horasCalculo(1), unidadMedida, intervaloCerrado, 2)

            If Not m_CalculoTerceraSeccion Then

                resultadoInsert = BLPlaneacion.InsertarBalance(Paciente.CodHistoria, resultadoSegundaSeccion, m_peso, m_edad, m_edadmeses, m_edaddias, unidadMedida, 0, 2)

            Else

                resultadoInsert = BLPlaneacion.InsertarBalance(Paciente.CodHistoria, resultadoSegundaSeccion, m_peso, m_edad, m_edadmeses, m_edaddias, unidadMedida, 1, 2)

            End If

            If formulaGastoCorporal Or formulaGastoPeso Then

                BLPlaneacion.ConsultarBalanceXCorte(Paciente.CodHistoria, BLPlaneacion.obtenerFecha(CDate(BLPlaneacion.ObtenerFechaMedico())), 2, m_peso, unidadMedida)

                For i As Integer = 7 To 13

                    'GASTO_URINARIO
                    'UNIDAD_MEDIDA

                    If m_peso = 0 Then

                        dtBalance.Rows(i)("GASTO_URINARIO") = "NO SE PUEDE CALCULAR"
                        dtBalance.Rows(28)("GASTO_URINARIO") = "NO SE PUEDE CALCULAR"

                    Else

                        dtBalance.Rows(i)("GASTO_URINARIO") = " " + unidadMedida
                        dtBalance.Rows(28)("GASTO_URINARIO") = " " + unidadMedida

                    End If

                Next

                formulaGastoCorporal = False
                formulaGastoPeso = False

            End If

        End If

        'TERCERA SECCION
        If m_CalculoTerceraSeccion Then

            If Not m_CalculoCuartaSeccion Then

                sumaTerceraSeccion = ObtenerSumatoriaDiuresisDiaEnCurso(dtColumnas, horasCalculo(2), m_horaInicio)
                intervaloCerrado = BLPlaneacion.ValidaIntervaloCerrado(Paciente.CodHistoria, BLPlaneacion.obtenerFecha(CDate(BLPlaneacion.ObtenerFechaMedico())), 3)
                resultadoTerceraSeccion = gastoUrinario(sumaTerceraSeccion, horasCalculo(2), unidadMedida, intervaloCerrado, 3)
                resultadoInsert = BLPlaneacion.InsertarBalance(Paciente.CodHistoria, resultadoTerceraSeccion, m_peso, m_edad, m_edadmeses, m_edaddias, unidadMedida, 0, 3)

                intervaloCerrado = False

            Else

                sumaTerceraSeccion = ObtenerSumatoriaDiuresisDiaEnCurso(dtColumnas, horasCalculo(2), m_horaInicio)
                intervaloCerrado = BLPlaneacion.ValidaIntervaloCerrado(Paciente.CodHistoria, BLPlaneacion.obtenerFecha(CDate(BLPlaneacion.ObtenerFechaMedico())), 3)
                resultadoTerceraSeccion = gastoUrinario(sumaTerceraSeccion, horasCalculo(2), unidadMedida, intervaloCerrado, 3)
                resultadoInsert = BLPlaneacion.InsertarBalance(Paciente.CodHistoria, resultadoTerceraSeccion, m_peso, m_edad, m_edadmeses, m_edaddias, unidadMedida, 1, 3)

                intervaloCerrado = False

            End If



            If formulaGastoCorporal Or formulaGastoPeso Then

                BLPlaneacion.ConsultarBalanceXCorte(Paciente.CodHistoria, BLPlaneacion.obtenerFecha(CDate(BLPlaneacion.ObtenerFechaMedico())), 3, m_peso, unidadMedida)

                For i As Integer = 14 To 20

                    'GASTO_URINARIO
                    'UNIDAD_MEDIDA

                    If m_peso = 0 Then

                        dtBalance.Rows(i)("GASTO_URINARIO") = "NO SE PUEDE CALCULAR"
                        dtBalance.Rows(28)("GASTO_URINARIO") = "NO SE PUEDE CALCULAR"

                    Else

                        dtBalance.Rows(i)("GASTO_URINARIO") = "  " + unidadMedida
                        dtBalance.Rows(28)("GASTO_URINARIO") = "  " + unidadMedida

                    End If

                Next

                formulaGastoCorporal = False
                formulaGastoPeso = False

            End If

        End If

        'CUARTA SECCION
        If m_CalculoCuartaSeccion Then

            sumaCuartaSeccion = ObtenerSumatoriaDiuresisDiaEnCurso(dtColumnas, horasCalculo(3), m_horaInicio)
            intervaloCerrado = BLPlaneacion.ValidaIntervaloCerrado(Paciente.CodHistoria, BLPlaneacion.obtenerFecha(CDate(BLPlaneacion.ObtenerFechaMedico())), 4)
            resultadoCuartaSeccion = gastoUrinario(sumaCuartaSeccion, horasCalculo(3), unidadMedida, intervaloCerrado, 4)

            intervaloCerrado = False

            resultadoInsert = BLPlaneacion.InsertarBalance(Paciente.CodHistoria, resultadoCuartaSeccion, m_peso, m_edad, m_edadmeses, m_edaddias, unidadMedida, 0, 4)

            If formulaGastoCorporal Or formulaGastoPeso Then

                BLPlaneacion.ConsultarBalanceXCorte(Paciente.CodHistoria, BLPlaneacion.obtenerFecha(CDate(BLPlaneacion.ObtenerFechaMedico())), 4, m_peso, unidadMedida)

                For i As Integer = 21 To 28

                    'GASTO_URINARIO
                    'UNIDAD_MEDIDA

                    If m_peso = 0 Then

                        dtBalance.Rows(i)("GASTO_URINARIO") = "NO SE PUEDE CALCULAR"
                        dtBalance.Rows(28)("GASTO_URINARIO") = "NO SE PUEDE CALCULAR"

                    Else

                        dtBalance.Rows(i)("GASTO_URINARIO") = "   " + unidadMedida
                        dtBalance.Rows(28)("GASTO_URINARIO") = "   " + unidadMedida

                    End If

                Next

                formulaGastoCorporal = False
                formulaGastoPeso = False

            End If

        End If

        dtgConsultaBalance.DataSource = dtBalance

        'ValidarGastoUrinario()

    End Sub


    Private Sub calculoGastoUrinario(ByVal horas As Integer, ByVal dtBalance As DataTable, ByVal horasCalculo() As Integer)

        Dim dtColumnas As New DataTable
        Dim horaInicial As Integer = 7
        dtColumnas.Columns.Add("NOMBRE_COLUMNA")
        Dim sumaPrimeraSeccion As Double = 0
        Dim sumaSegundaSeccion As Double = 0
        Dim sumaTerceraSeccion As Double = 0
        Dim sumaCuartaSeccion As Double = 0
        Dim resultadoPrimeraSeccion As Double = 0
        Dim resultadoSegundaSeccion As Double = 0
        Dim resultadoTerceraSeccion As Double = 0
        Dim resultadoCuartaSeccion As Double = 0
        Dim unidadMedida As String = String.Empty
        Dim intervaloCerrado As Boolean = False

        If horas > 0 Then

            For i As Integer = 0 To dtgLiqElim.Columns.Count - 1

                If dtgLiqElim.Columns(i).Name.ToString() <> "HORA" And
                   dtgLiqElim.Columns(i).Name.ToString() <> "TOTAL" And
                   dtgLiqElim.Columns(i).Name.ToString() <> "ID" Then


                    If BLPlaneacion.ValidaLiquidoDiuresis(BLPlaneacion.obtenerNombreLiquido(dtgLiqElim.Columns(i).Name, "LE")) Then

                        Dim dtFila As DataRow = dtColumnas.NewRow
                        dtFila("NOMBRE_COLUMNA") = dtgLiqElim.Columns(i).Name

                        dtColumnas.Rows.Add(dtFila)

                    End If

                End If

            Next

            'PRIMERA SECCION
            If horas > 6 Then

                If Not BLPlaneacion.ValidaExisteBalanceCorte(m_CodHistoria, m_fechaConsulta, 1) Then

                    sumaPrimeraSeccion = ObtenerSumatoriaDiuresis(dtColumnas, 6)
                    resultadoPrimeraSeccion = gastoUrinario(sumaPrimeraSeccion, horasCalculo(0), unidadMedida, intervaloCerrado, 1)

                Else

                    If BLPlaneacion.ValidaExisteBalanceCorte(m_CodHistoria, m_fechaConsulta, 1) Then

                        BLPlaneacion.ConsultarBalanceXCorteHIS(m_CodHistoria, m_fechaConsulta, 1, m_peso, unidadMedida)
                        formulaGastoCorporal = True
                        formulaGastoPeso = True
                        If unidadMedida = "0" Then
                            If m_peso <> 0 Then
                                sumaPrimeraSeccion = ObtenerSumatoriaDiuresis(dtColumnas, 6)
                                resultadoPrimeraSeccion = gastoUrinario(sumaPrimeraSeccion, horasCalculo(0), unidadMedida, intervaloCerrado, 1)
                                unidadMedida = Convert.ToString(Math.Sign(resultadoPrimeraSeccion) * Math.Floor(Math.Abs(resultadoPrimeraSeccion) * 100) / 100.0) + "-" + unidadMedida
                            End If
                        End If

                    Else

                        sumaPrimeraSeccion = ObtenerSumatoriaDiuresis(dtColumnas, 6)
                        resultadoPrimeraSeccion = gastoUrinario(sumaPrimeraSeccion, horasCalculo(0), unidadMedida, intervaloCerrado, 1)

                    End If
                End If

            End If

            If horasCalculo(0) <= 6 Then

                If Not BLPlaneacion.ValidaExisteBalanceCorte(m_CodHistoria, m_fechaConsulta, 1) Then
                    BLPlaneacion.ConsultarBalanceXCorteHIS(m_CodHistoria, m_fechaConsulta, 1, m_peso, unidadMedida)
                    sumaPrimeraSeccion = ObtenerSumatoriaDiuresis(dtColumnas, horasCalculo(0))
                    resultadoPrimeraSeccion = gastoUrinario(sumaPrimeraSeccion, horasCalculo(0), unidadMedida, intervaloCerrado, 1)

                Else

                    BLPlaneacion.ConsultarBalanceXCorteHIS(m_CodHistoria, m_fechaConsulta, 1, m_peso, unidadMedida)
                    formulaGastoCorporal = True
                    formulaGastoPeso = True
                    If unidadMedida = "0" Then
                        If m_peso <> 0 Then
                            sumaPrimeraSeccion = ObtenerSumatoriaDiuresis(dtColumnas, horasCalculo(0))
                            resultadoPrimeraSeccion = gastoUrinario(sumaPrimeraSeccion, horasCalculo(0), unidadMedida, intervaloCerrado, 1)
                            unidadMedida = Convert.ToString(Math.Sign(resultadoPrimeraSeccion) * Math.Floor(Math.Abs(resultadoPrimeraSeccion) * 100) / 100.0) + "-" + unidadMedida
                        End If
                    End If

                End If

            End If

            If formulaGastoCorporal Or formulaGastoPeso Then

                For i As Integer = 0 To 6

                    'GASTO_URINARIO
                    'UNIDAD_MEDIDA
                    If m_peso = 0 Then

                        dtBalance.Rows(i)("GASTO_URINARIO") = "NO SE PUEDE CALCULAR"
                        dtBalance.Rows(6)("GASTO_URINARIO") = ""
                        dtBalance.Rows(28)("GASTO_URINARIO") = "NO SE PUEDE CALCULAR"

                    Else

                        If Not BLPlaneacion.ValidaExisteBalanceCorte(m_CodHistoria, m_fechaConsulta, 1) Then
                            If resultadoPrimeraSeccion = 0 Then
                                dtBalance.Rows(i)("GASTO_URINARIO") = ""
                            Else
                                dtBalance.Rows(i)("GASTO_URINARIO") = Convert.ToString(Math.Sign(resultadoPrimeraSeccion) * Math.Floor(Math.Abs(resultadoPrimeraSeccion) * 100) / 100.0) + "-" + unidadMedida
                                dtBalance.Rows(28)("GASTO_URINARIO") = Convert.ToString(Math.Sign(resultadoPrimeraSeccion) * Math.Floor(Math.Abs(resultadoPrimeraSeccion) * 100) / 100.0) + "-" + unidadMedida

                            End If

                        Else

                            If BLPlaneacion.ValidaExisteBalanceCorte(m_CodHistoria, m_fechaConsulta, 1) Then
                                If unidadMedida = "0-CC/Kg/h" Or unidadMedida = "0-CC/M2/h" Then
                                    dtBalance.Rows(i)("GASTO_URINARIO") = ""
                                Else
                                    dtBalance.Rows(i)("GASTO_URINARIO") = unidadMedida
                                    dtBalance.Rows(6)("GASTO_URINARIO") = ""
                                    dtBalance.Rows(28)("GASTO_URINARIO") = unidadMedida
                                End If
                            Else

                                dtBalance.Rows(i)("GASTO_URINARIO") = Convert.ToString(Math.Sign(resultadoPrimeraSeccion) * Math.Floor(Math.Abs(resultadoPrimeraSeccion) * 100) / 100.0) + "-" + unidadMedida
                                dtBalance.Rows(28)("GASTO_URINARIO") = Convert.ToString(Math.Sign(resultadoPrimeraSeccion) * Math.Floor(Math.Abs(resultadoPrimeraSeccion) * 100) / 100.0) + "-" + unidadMedida

                            End If

                        End If

                    End If

                Next

                formulaGastoCorporal = False
                formulaGastoPeso = False

            End If

            'SEGUNDA SECCION
            If horas > 12 Then

                If Not BLPlaneacion.ValidaExisteBalanceCorte(m_CodHistoria, m_fechaConsulta, 2) Then

                    sumaSegundaSeccion = ObtenerSumatoriaDiuresis(dtColumnas, 12)
                    resultadoSegundaSeccion = gastoUrinario(sumaSegundaSeccion, horasCalculo(1), unidadMedida, intervaloCerrado, 2)

                Else

                    If BLPlaneacion.ValidaExisteBalanceCorte(m_CodHistoria, m_fechaConsulta, 2) Then

                        BLPlaneacion.ConsultarBalanceXCorteHIS(m_CodHistoria, m_fechaConsulta, 2, m_peso, unidadMedida)
                        formulaGastoCorporal = True
                        formulaGastoPeso = True
                        If unidadMedida = "0" Then
                            If m_peso <> 0 Then
                                sumaSegundaSeccion = ObtenerSumatoriaDiuresis(dtColumnas, 12)
                                resultadoSegundaSeccion = gastoUrinario(sumaSegundaSeccion, horasCalculo(1), unidadMedida, intervaloCerrado, 2)
                                unidadMedida = Convert.ToString(Math.Sign(resultadoSegundaSeccion) * Math.Floor(Math.Abs(resultadoSegundaSeccion) * 100) / 100.0) + "-" + unidadMedida
                            End If
                        End If

                    Else

                        sumaSegundaSeccion = ObtenerSumatoriaDiuresis(dtColumnas, 12)
                        resultadoSegundaSeccion = gastoUrinario(sumaSegundaSeccion, horasCalculo(1), unidadMedida, intervaloCerrado, 2)

                    End If

                End If

            End If

            If horas > 6 And horas <= 12 Then

                If Not BLPlaneacion.ValidaExisteBalanceCorte(m_CodHistoria, m_fechaConsulta, 2) Then
                    BLPlaneacion.ConsultarBalanceXCorteHIS(m_CodHistoria, m_fechaConsulta, 2, m_peso, unidadMedida)
                    sumaSegundaSeccion = ObtenerSumatoriaDiuresis(dtColumnas, horasCalculo(1))
                    resultadoSegundaSeccion = gastoUrinario(sumaSegundaSeccion, horasCalculo(1), unidadMedida, intervaloCerrado, 2)

                Else

                    BLPlaneacion.ConsultarBalanceXCorteHIS(m_CodHistoria, m_fechaConsulta, 2, m_peso, unidadMedida)
                    formulaGastoCorporal = True
                    formulaGastoPeso = True

                End If

            End If

            If formulaGastoCorporal Or formulaGastoPeso Then

                For i As Integer = 7 To 13

                    'GASTO_URINARIO
                    'UNIDAD_MEDIDA

                    If m_peso = 0 Then

                        dtBalance.Rows(i)("GASTO_URINARIO") = "NO SE PUEDE CALCULAR"
                        dtBalance.Rows(13)("GASTO_URINARIO") = ""
                        dtBalance.Rows(28)("GASTO_URINARIO") = "NO SE PUEDE CALCULAR"
                    Else

                        If Not BLPlaneacion.ValidaExisteBalanceCorte(m_CodHistoria, m_fechaConsulta, 2) Then
                            If resultadoSegundaSeccion = 0 Then
                                dtBalance.Rows(i)("GASTO_URINARIO") = " " + Convert.ToString(resultadoSegundaSeccion) + " - " + unidadMedida
                                dtBalance.Rows(13)("GASTO_URINARIO") = ""
                                dtBalance.Rows(28)("GASTO_URINARIO") = Convert.ToString(resultadoSegundaSeccion) + " - " + unidadMedida
                            Else

                                dtBalance.Rows(i)("GASTO_URINARIO") = " " + Convert.ToString(Math.Sign(resultadoSegundaSeccion) * Math.Floor(Math.Abs(resultadoSegundaSeccion) * 100) / 100.0) + "-" + unidadMedida
                                dtBalance.Rows(28)("GASTO_URINARIO") = Convert.ToString(Math.Sign(resultadoSegundaSeccion) * Math.Floor(Math.Abs(resultadoSegundaSeccion) * 100) / 100.0) + "-" + unidadMedida
                            End If
                        Else

                            If BLPlaneacion.ValidaExisteBalanceCorte(m_CodHistoria, m_fechaConsulta, 2) Then

                                If unidadMedida = "0-CC/Kg/h" Or unidadMedida = "0-CC/M2/h" Then
                                    dtBalance.Rows(i)("GASTO_URINARIO") = ""
                                Else
                                    dtBalance.Rows(i)("GASTO_URINARIO") = " " + unidadMedida
                                    dtBalance.Rows(13)("GASTO_URINARIO") = ""
                                    dtBalance.Rows(28)("GASTO_URINARIO") = unidadMedida
                                End If

                            Else

                                dtBalance.Rows(i)("GASTO_URINARIO") = " " + Convert.ToString(Math.Sign(resultadoSegundaSeccion) * Math.Floor(Math.Abs(resultadoSegundaSeccion) * 100) / 100.0) + "-" + unidadMedida
                                dtBalance.Rows(28)("GASTO_URINARIO") = Convert.ToString(Math.Sign(resultadoSegundaSeccion) * Math.Floor(Math.Abs(resultadoSegundaSeccion) * 100) / 100.0) + "-" + unidadMedida

                            End If

                        End If

                    End If

                Next

                formulaGastoCorporal = False
                formulaGastoPeso = False

            End If

            'TERCERA SECCION
            If horas > 18 Then

                If Not BLPlaneacion.ValidaExisteBalanceCorte(m_CodHistoria, m_fechaConsulta, 3) Then

                    sumaTerceraSeccion = ObtenerSumatoriaDiuresis(dtColumnas, 18)
                    resultadoTerceraSeccion = gastoUrinario(sumaTerceraSeccion, horasCalculo(2), unidadMedida, intervaloCerrado, 3)

                Else

                    If BLPlaneacion.ValidaExisteBalanceCorte(m_CodHistoria, m_fechaConsulta, 3) Then

                        BLPlaneacion.ConsultarBalanceXCorteHIS(m_CodHistoria, m_fechaConsulta, 3, m_peso, unidadMedida)
                        formulaGastoCorporal = True
                        formulaGastoPeso = True

                        If unidadMedida = "0" Then
                            If m_peso <> 0 Then
                                sumaTerceraSeccion = ObtenerSumatoriaDiuresis(dtColumnas, 18)
                                resultadoTerceraSeccion = gastoUrinario(sumaTerceraSeccion, horasCalculo(2), unidadMedida, intervaloCerrado, 3)
                                unidadMedida = Convert.ToString(Math.Sign(resultadoTerceraSeccion) * Math.Floor(Math.Abs(resultadoTerceraSeccion) * 100) / 100.0) + "-" + unidadMedida
                            End If
                        End If
                    Else

                        sumaTerceraSeccion = ObtenerSumatoriaDiuresis(dtColumnas, 18)
                        resultadoTerceraSeccion = gastoUrinario(sumaTerceraSeccion, horasCalculo(2), unidadMedida, intervaloCerrado, 3)

                    End If

                End If

            End If

            If horas > 12 And horas <= 18 Then

                If Not BLPlaneacion.ValidaExisteBalanceCorte(m_CodHistoria, m_fechaConsulta, 3) Then
                    BLPlaneacion.ConsultarBalanceXCorteHIS(m_CodHistoria, m_fechaConsulta, 3, m_peso, unidadMedida)
                    sumaTerceraSeccion = ObtenerSumatoriaDiuresis(dtColumnas, horasCalculo(2))
                    resultadoTerceraSeccion = gastoUrinario(sumaTerceraSeccion, horasCalculo(2), unidadMedida, intervaloCerrado, 3)

                Else

                    BLPlaneacion.ConsultarBalanceXCorteHIS(m_CodHistoria, m_fechaConsulta, 3, m_peso, unidadMedida)
                    formulaGastoCorporal = True
                    formulaGastoPeso = True

                End If

            End If

            If formulaGastoCorporal Or formulaGastoPeso Then

                For i As Integer = 14 To 20

                    'GASTO_URINARIO
                    'UNIDAD_MEDIDA

                    If m_peso = 0 Then
                        dtBalance.Rows(i)("GASTO_URINARIO") = "NO SE PUEDE CALCULAR"
                        dtBalance.Rows(20)("GASTO_URINARIO") = ""
                        dtBalance.Rows(28)("GASTO_URINARIO") = "NO SE PUEDE CALCULAR"
                    Else

                        If Not BLPlaneacion.ValidaExisteBalanceCorte(m_CodHistoria, m_fechaConsulta, 3) Then
                            If resultadoTerceraSeccion = 0 Then
                                dtBalance.Rows(i)("GASTO_URINARIO") = " " + Convert.ToString(resultadoTerceraSeccion) + " - " + unidadMedida
                                dtBalance.Rows(20)("GASTO_URINARIO") = ""
                                dtBalance.Rows(28)("GASTO_URINARIO") = Convert.ToString(resultadoTerceraSeccion) + " - " + unidadMedida
                            Else

                                dtBalance.Rows(i)("GASTO_URINARIO") = "  " + Convert.ToString(Math.Sign(resultadoTerceraSeccion) * Math.Floor(Math.Abs(resultadoTerceraSeccion) * 100) / 100.0) + "-" + unidadMedida
                                dtBalance.Rows(28)("GASTO_URINARIO") = Convert.ToString(Math.Sign(resultadoTerceraSeccion) * Math.Floor(Math.Abs(resultadoTerceraSeccion) * 100) / 100.0) + "-" + unidadMedida
                            End If
                        Else

                            If BLPlaneacion.ValidaExisteBalanceCorte(m_CodHistoria, m_fechaConsulta, 3) Then

                                If unidadMedida = "0-CC/Kg/h" Or unidadMedida = "0-CC/M2/h" Then
                                    dtBalance.Rows(i)("GASTO_URINARIO") = ""
                                Else
                                    dtBalance.Rows(i)("GASTO_URINARIO") = "  " + unidadMedida
                                    dtBalance.Rows(20)("GASTO_URINARIO") = ""
                                    dtBalance.Rows(28)("GASTO_URINARIO") = unidadMedida
                                End If

                            Else

                                dtBalance.Rows(i)("GASTO_URINARIO") = "  " + Convert.ToString(Math.Sign(resultadoTerceraSeccion) * Math.Floor(Math.Abs(resultadoTerceraSeccion) * 100) / 100.0) + "-" + unidadMedida
                                dtBalance.Rows(28)("GASTO_URINARIO") = Convert.ToString(Math.Sign(resultadoTerceraSeccion) * Math.Floor(Math.Abs(resultadoTerceraSeccion) * 100) / 100.0) + "-" + unidadMedida

                            End If

                        End If

                    End If

                Next

                formulaGastoCorporal = False
                formulaGastoPeso = False

            End If

            'CUARTA SECCION
            If horas > 18 Then

                If Not BLPlaneacion.ValidaExisteBalanceCorte(m_CodHistoria, m_fechaConsulta, 4) Then

                    sumaCuartaSeccion = ObtenerSumatoriaDiuresis(dtColumnas, 24)
                    resultadoCuartaSeccion = gastoUrinario(sumaCuartaSeccion, horasCalculo(3), unidadMedida, intervaloCerrado, 4)

                Else

                    BLPlaneacion.ConsultarBalanceXCorteHIS(m_CodHistoria, m_fechaConsulta, 4, m_peso, unidadMedida)

                    If unidadMedida = "0" Then
                        sumaCuartaSeccion = ObtenerSumatoriaDiuresis(dtColumnas, 24)
                        resultadoCuartaSeccion = gastoUrinario(sumaCuartaSeccion, horasCalculo(3), unidadMedida, intervaloCerrado, 4)
                        unidadMedida = Convert.ToString(Math.Sign(resultadoCuartaSeccion) * Math.Floor(Math.Abs(resultadoCuartaSeccion) * 100) / 100.0) + "-" + unidadMedida
                    End If

                    formulaGastoCorporal = True
                    formulaGastoPeso = True

                End If

            End If

            If formulaGastoCorporal Or formulaGastoPeso Then

                For i As Integer = 21 To 27

                    'GASTO_URINARIO
                    'UNIDAD_MEDIDA

                    If m_peso = 0 Then

                        dtBalance.Rows(i)("GASTO_URINARIO") = "NO SE PUEDE CALCULAR"
                        dtBalance.Rows(27)("GASTO_URINARIO") = ""
                        dtBalance.Rows(28)("GASTO_URINARIO") = "NO SE PUEDE CALCULAR"

                    Else

                        If Not BLPlaneacion.ValidaExisteBalanceCorte(m_CodHistoria, m_fechaConsulta, 4) Then
                            If resultadoCuartaSeccion = 0 Then
                                dtBalance.Rows(i)("GASTO_URINARIO") = "   " + Convert.ToString(resultadoCuartaSeccion) + " - " + unidadMedida
                                dtBalance.Rows(27)("GASTO_URINARIO") = ""
                                dtBalance.Rows(28)("GASTO_URINARIO") = Convert.ToString(resultadoCuartaSeccion) + " - " + unidadMedida
                            Else

                                dtBalance.Rows(i)("GASTO_URINARIO") = "   " + Convert.ToString(Math.Sign(resultadoCuartaSeccion) * Math.Floor(Math.Abs(resultadoCuartaSeccion) * 100) / 100.0) + "-" + unidadMedida
                                dtBalance.Rows(28)("GASTO_URINARIO") = Convert.ToString(Math.Sign(resultadoCuartaSeccion) * Math.Floor(Math.Abs(resultadoCuartaSeccion) * 100) / 100.0) + "-" + unidadMedida
                            End If
                        Else

                            If unidadMedida = "0-CC/Kg/h" Or unidadMedida = "0-CC/M2/h" Then
                                dtBalance.Rows(i)("GASTO_URINARIO") = ""
                            Else
                                dtBalance.Rows(i)("GASTO_URINARIO") = "   " + unidadMedida
                                dtBalance.Rows(27)("GASTO_URINARIO") = ""
                                dtBalance.Rows(28)("GASTO_URINARIO") = unidadMedida
                            End If

                        End If

                    End If

                Next

                formulaGastoCorporal = False
                formulaGastoPeso = False

            End If

            dtgConsultaBalance.DataSource = dtBalance

            ValidarGastoUrinario()

        End If

    End Sub

    Private Function ObtenerSumatoriaDiuresisDiaEnCurso(ByVal dtColumnas As DataTable, ByVal horas As Integer, ByVal horaInicio As Integer) As Double

        Dim nombreColumna As String = String.Empty
        Dim contador As Integer = 1
        Dim suma As Double = 0
        Dim valor As Double = 0

        While contador <= horas

            For i As Integer = 0 To dtgLiqElim.Rows.Count - 1

                If dtgLiqElim.Rows(i).Cells("HORA").Value.ToString() = horaInicio.ToString() Then

                    For k As Integer = 0 To dtColumnas.Rows.Count - 1

                        nombreColumna = dtColumnas.Rows(k)("NOMBRE_COLUMNA").ToString()

                        If dtgLiqElim.Rows(i).Cells(nombreColumna).Value.ToString() = String.Empty Or
                           dtgLiqElim.Rows(i).Cells(nombreColumna).Value.ToString() = "+" Or
                           dtgLiqElim.Rows(i).Cells(nombreColumna).Value.ToString() = "-" Then

                            valor = 0

                        Else

                            valor = Convert.ToDouble(dtgLiqElim.Rows(i).Cells(nombreColumna).Value.ToString())

                        End If

                        suma = suma + valor

                    Next

                End If

            Next

            horaInicio = horaInicio + 1
            contador = contador + 1
            If horaInicio >= 24 Then
                horaInicio = horaInicio - 24
            End If
        End While

        Return suma

    End Function

    ''Se crea metodo para la sumatoria de liquidos de diuresis - dsanchez 30/08/2017
    Private Function ObtenerSumatoriaDiuresis(ByVal dtColumnas As DataTable, ByVal horas As Integer) As Double

        Dim horaInicial As Integer = 7
        Dim nombreColumna As String = String.Empty
        Dim suma As Double = 0
        Dim valor As Double = 0

        For i As Integer = 1 To horas

            If horaInicial > 24 Then

                horaInicial = horaInicial - 24

            End If

            For j As Integer = 0 To dtgLiqElim.Rows.Count - 1

                If dtgLiqElim.Rows(j).Cells("HORA").Value.ToString() = horaInicial.ToString() Then

                    For k As Integer = 0 To dtColumnas.Rows.Count - 1

                        nombreColumna = dtColumnas.Rows(k)("NOMBRE_COLUMNA").ToString()

                        If dtgLiqElim.Rows(j).Cells(nombreColumna).Value.ToString() = String.Empty Or
                           dtgLiqElim.Rows(j).Cells(nombreColumna).Value.ToString() = "+" Or
                           dtgLiqElim.Rows(j).Cells(nombreColumna).Value.ToString() = "-" Then

                            valor = 0

                        Else

                            valor = Convert.ToDouble(dtgLiqElim.Rows(j).Cells(nombreColumna).Value.ToString())

                        End If

                        suma = suma + valor

                    Next

                End If

            Next

            horaInicial = horaInicial + 1
            If horaInicial >= 24 Then
                horaInicial = horaInicial - 24
            End If

        Next

        Return suma

    End Function

    ''Se crea metodo para obtener el gasto urinario - dsanchez 30/08/2017
    Private Function gastoUrinario(ByVal suma As Double, ByVal horas As Double, ByRef unidadMedida As String, ByVal intervaloCerrado As Boolean, ByVal corte As Integer) As Double

        Dim peso As Double = 0
        Dim edad As Integer = 0
        Dim EdadMeses As Integer = 0
        Dim EdadDias As Integer = 0
        Dim resultado As Double = 0
        Dim dtDatosEdad As DataTable
        Dim fecha As Date

        fecha = CDate(mskFechaHasta.Text)
        formulaGastoPeso = False
        formulaGastoCorporal = False

        If Not intervaloCerrado Then
            If corte = 4 Or corte = 3 Then
                dtDatosEdad = BLPlaneacion.ObtenerEdadIntervalo(Paciente.CodHistoria, BLPlaneacion.obtenerFecha(fecha), corte)

                If dtDatosEdad.Rows.Count > 0 Then
                    edad = dtDatosEdad.Rows(0).Item(0).ToString
                    EdadMeses = dtDatosEdad.Rows(0).Item(1).ToString
                    EdadDias = dtDatosEdad.Rows(0).Item(2).ToString
                End If
                peso = BLPlaneacion.ObtenerPesoIntervalo(Paciente.CodHistoria, BLPlaneacion.obtenerFecha(fecha), corte)
            End If


            If edad = 0 Then
                peso = Convert.ToDouble(BLPlaneacion.ObtenerPesoConsulta(General.Prestador, General.Sucursal, Paciente.NumeroAdmision, Paciente.AnoAdmision, Paciente.TipoAdmision, Paciente.CodHistoria, BLPlaneacion.obtenerFecha(fecha), corte))

                dtDatosEdad = BLPlaneacion.ObtenerEdadPacienteLiquidosconsulta(General.Prestador, General.Sucursal, Paciente.NumeroAdmision, Paciente.AnoAdmision, Paciente.TipoAdmision, Paciente.CodHistoria, BLPlaneacion.obtenerFecha(fecha))

                If dtDatosEdad.Rows.Count > 0 Then
                    edad = dtDatosEdad.Rows(0).Item(1).ToString
                    EdadMeses = dtDatosEdad.Rows(1).Item(1).ToString
                    EdadDias = dtDatosEdad.Rows(2).Item(1).ToString
                    If corte = 4 Or corte = 3 Then
                        EdadDias = EdadDias + 1
                    End If
                End If
            End If

        Else

            peso = BLPlaneacion.ObtenerPesoIntervalo(Paciente.CodHistoria, BLPlaneacion.obtenerFecha(fecha), corte)
            dtDatosEdad = BLPlaneacion.ObtenerEdadIntervalo(Paciente.CodHistoria, BLPlaneacion.obtenerFecha(fecha), corte)
            If dtDatosEdad.Rows.Count > 0 Then
                edad = dtDatosEdad.Rows(0).Item(0).ToString
                EdadMeses = dtDatosEdad.Rows(0).Item(1).ToString
                EdadDias = dtDatosEdad.Rows(0).Item(2).ToString
            End If
        End If
        m_peso = peso


        m_edad = edad
        m_edaddias = EdadDias
        m_edadmeses = EdadMeses

        If (edad < 16 And peso < 10) Or edad >= 16 Or (edad = 16 And EdadMeses = 0 And EdadDias = 0 And peso < 10) Then

            Dim dividendoPeso As Double = 0

            formulaGastoPeso = True
            If suma = 0 Then
                dividendoPeso = 0
            Else
                dividendoPeso = suma / horas
            End If

            resultado = dividendoPeso / peso

            unidadMedida = "CC/Kg/h"

        End If

        If (edad < 16 And peso >= 10) Or (edad = 16 And EdadMeses = 0 And EdadDias = 0 And peso >= 10) Then

            Dim dividendoCorporal As Double = 0
            Dim divisorCorporal As Double = 0

            formulaGastoCorporal = True
            If suma = 0 Then
                dividendoCorporal = 0
            Else
                dividendoCorporal = suma / horas
            End If
            divisorCorporal = ((peso * 4) + 7) / (peso + 90)
            resultado = dividendoCorporal / divisorCorporal

            unidadMedida = "CC/M2/h"

        End If

        Return resultado

    End Function

    Private Sub ValidarGastoUrinario()

        Dim iIndex As Integer = 0
        Dim cadena As Integer = 0
        'Validacion de primera seccion
        valor = dtgConsultaBalance.Rows(0).Cells("GASTO_URINARIO").Value.ToString()
        'CC/M2/h
        'CC/Kg/h
        If valor <> String.Empty Then

            If valor <> "NO SE PUEDE CALCULAR" Then

                iIndex = valor.IndexOf("-")
                cadena = valor.Length - iIndex
                valorUnidadMedida = valor.Substring(iIndex + 1, cadena - 1)
                valor = valor.Substring(0, iIndex)

                valorGastoUrinario = CDbl(valor.Trim())

                If valorUnidadMedida.Trim() = "CC/M2/h" Then

                    If (valorGastoUrinario > 4.2 And valorGastoUrinario < 12) Or valorGastoUrinario > 90 Then

                        PintarCeldas(0, 6, Color.Yellow)

                    End If

                    If valorGastoUrinario <= 4.2 Then

                        PintarCeldas(0, 6, Color.Orange)

                    End If

                End If

                If valorUnidadMedida.Trim() = "CC/Kg/h" Then

                    If valorGastoUrinario > 0.5 And valorGastoUrinario < 1 Then

                        PintarCeldas(0, 6, Color.Yellow)

                    End If

                    If valorGastoUrinario > 5 Then

                        PintarCeldas(0, 6, Color.Yellow)

                    End If

                    If valorGastoUrinario <= 0.5 Then

                        PintarCeldas(0, 6, Color.Orange)

                    End If

                End If

                valor = String.Empty

            End If

        End If

        'Validacion de segunda seccion seccion
        valor = dtgConsultaBalance.Rows(7).Cells("GASTO_URINARIO").Value.ToString()
        'CC/M2/h
        'CC/Kg/h
        If valor <> String.Empty Then


            If valor <> "NO SE PUEDE CALCULAR" Then

                iIndex = valor.IndexOf("-")
                cadena = valor.Length - iIndex
                valorUnidadMedida = valor.Substring(iIndex + 1, cadena - 1)
                valor = valor.Substring(0, iIndex)

                valorGastoUrinario = CDbl(valor.Trim())

                If valorUnidadMedida.Trim() = "CC/M2/h" Then

                    If (valorGastoUrinario > 4.2 And valorGastoUrinario < 12) Or valorGastoUrinario > 90 Then

                        PintarCeldas(7, 13, Color.Yellow)

                    End If

                    If valorGastoUrinario <= 4.2 Then

                        PintarCeldas(7, 13, Color.Orange)

                    End If

                End If

                If valorUnidadMedida.Trim() = "CC/Kg/h" Then

                    If valorGastoUrinario > 0.5 And valorGastoUrinario < 1 Then

                        PintarCeldas(7, 13, Color.Yellow)

                    End If

                    If valorGastoUrinario > 5 Then

                        PintarCeldas(7, 13, Color.Yellow)

                    End If

                    If valorGastoUrinario <= 0.5 Then

                        PintarCeldas(7, 13, Color.Orange)

                    End If

                End If

                valor = String.Empty

            End If

        End If

        'Validacion de tercera seccion
        valor = dtgConsultaBalance.Rows(14).Cells("GASTO_URINARIO").Value.ToString()
        'CC/M2/h
        'CC/Kg/h
        If valor <> String.Empty Then

            If valor <> "NO SE PUEDE CALCULAR" Then

                iIndex = valor.IndexOf("-")
                cadena = valor.Length - iIndex
                valorUnidadMedida = valor.Substring(iIndex + 1, cadena - 1)
                valor = valor.Substring(0, iIndex)

                valorGastoUrinario = CDbl(valor.Trim())

                If valorUnidadMedida.Trim() = "CC/M2/h" Then

                    If (valorGastoUrinario > 4.2 And valorGastoUrinario < 12) Or valorGastoUrinario > 90 Then

                        PintarCeldas(14, 20, Color.Yellow)

                    End If

                    If valorGastoUrinario <= 4.2 Then

                        PintarCeldas(14, 20, Color.Orange)

                    End If

                End If

                If valorUnidadMedida.Trim() = "CC/Kg/h" Then

                    If valorGastoUrinario > 0.5 And valorGastoUrinario < 1 Then

                        PintarCeldas(14, 20, Color.Yellow)

                    End If

                    If valorGastoUrinario > 5 Then

                        PintarCeldas(14, 20, Color.Yellow)

                    End If

                    If valorGastoUrinario <= 0.5 Then

                        PintarCeldas(14, 20, Color.Orange)

                    End If

                End If

                valor = String.Empty

            End If

        End If

        'Validacion de cuarta seccion
        valor = dtgConsultaBalance.Rows(21).Cells("GASTO_URINARIO").Value.ToString()
        'CC/M2/h
        'CC/Kg/h
        If valor <> String.Empty Then

            If valor <> "NO SE PUEDE CALCULAR" Then

                iIndex = valor.IndexOf("-")
                cadena = valor.Length - iIndex
                valorUnidadMedida = valor.Substring(iIndex + 1, cadena - 1)
                valor = valor.Substring(0, iIndex)

                valorGastoUrinario = CDbl(valor.Trim())

                If valorUnidadMedida.Trim() = "CC/M2/h" Then

                    If (valorGastoUrinario > 4.2 And valorGastoUrinario < 12) Or valorGastoUrinario > 90 Then

                        PintarCeldas(21, 27, Color.Yellow)

                    End If

                    If valorGastoUrinario <= 4.2 Then

                        PintarCeldas(21, 27, Color.Orange)

                    End If

                End If

                If valorUnidadMedida.Trim() = "CC/Kg/h" Then

                    If valorGastoUrinario > 0.5 And valorGastoUrinario < 1 Then

                        PintarCeldas(21, 27, Color.Yellow)

                    End If

                    If valorGastoUrinario > 5 Then

                        PintarCeldas(21, 27, Color.Yellow)

                    End If

                    If valorGastoUrinario <= 0.5 Then

                        PintarCeldas(21, 27, Color.Orange)

                    End If

                End If

                valor = String.Empty

            End If

        End If



    End Sub

    Private Sub PintarCeldas(ByVal limiteInferior As Integer, ByVal limiteSuperior As Integer, ByVal color As Color)

        For i As Integer = limiteInferior To limiteSuperior

            dtgConsultaBalance.Rows(i).Cells("GASTO_URINARIO").Style.BackColor = color

        Next

    End Sub

    Private Sub dtgConsultaBalance_CellFormatting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dtgConsultaBalance.CellFormatting

        If e.RowIndex = 0 Then

            Return

        End If
        If e.ColumnIndex <> 1 Then
            If ValorMismaCelda(e.ColumnIndex, e.RowIndex) Then

                e.Value = String.Empty
                e.FormattingApplied = True

            End If
        End If
    End Sub

    ''Se crea metodo para validar si las celdas contiene el mismo valor - dsanchez 30/08/2017
    Private Function ValorMismaCelda(ByVal columna As Integer, ByVal fila As Integer) As Boolean

        Dim cell1 As DataGridViewCell = dtgConsultaBalance.Rows(fila).Cells(columna)
        Dim cell2 As DataGridViewCell = dtgConsultaBalance.Rows(fila - 1).Cells(columna)
        Dim valorCell1 As Object = cell1.Value
        Dim valorCell2 As Object = cell2.Value
        Dim valor1 As String = String.Empty
        Dim valor2 As String = String.Empty

        If IsDBNull(valorCell1) Or IsDBNull(valorCell2) Then

            Return False

        End If

        If Not IsDBNull(valorCell1) Then

            If valorCell1 <> Nothing Then

                valor1 = valorCell1.ToString()

            End If

        End If

        If Not IsDBNull(valorCell2) Then

            If valorCell2 <> Nothing Then

                valor2 = valorCell2.ToString()

            End If

        End If

        Return valor1 = valor2

    End Function

    Private Sub dtgConsultaBalance_CellPainting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dtgConsultaBalance.CellPainting

        If e.ColumnIndex >= 0 Then

            If dtgConsultaBalance.Columns(e.ColumnIndex).Name.ToString() <> "HORA" And dtgConsultaBalance.Columns(e.ColumnIndex).Name.ToString() <> "BALANCE_HORARIO" Then

                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None

                If e.RowIndex < 1 Or e.ColumnIndex < 0 Then
                    Return
                End If

                If ValorMismaCelda(e.ColumnIndex, e.RowIndex) Then

                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None

                Else

                    e.AdvancedBorderStyle.Top = dtgConsultaBalance.AdvancedCellBorderStyle.Top

                End If

            End If

        End If

    End Sub

    Private Sub dtgConsultaBalance_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dtgConsultaBalance.Scroll

        If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then

            If Me.dtgLiqAdmin.Rows.Count > 0 And Me.dtgConsultaBalance.Rows.Count > 0 Then

                dtgLiqAdmin.FirstDisplayedScrollingRowIndex = dtgConsultaBalance.FirstDisplayedScrollingRowIndex

            End If

        End If

        If e.ScrollOrientation = ScrollOrientation.VerticalScroll Then

            If Me.dtgLiqElim.Rows.Count > 0 And Me.dtgConsultaBalance.Rows.Count > 0 Then

                dtgLiqElim.FirstDisplayedScrollingRowIndex = dtgConsultaBalance.FirstDisplayedScrollingRowIndex

            End If

        End If


    End Sub

    Private Sub dtgLiqAdmin_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dtgLiqAdmin.CellDoubleClick

        Dim strValorColumna As String = String.Empty
        Dim formDetalle As frm_DetCantidadLiquido = New frm_DetCantidadLiquido()
        Dim formCantidades As frmc_LiquidosCantidades = New frmc_LiquidosCantidades()
        Dim diferenciaDias As Integer = 0
        Dim strFechaActual As String = BLPlaneacion.obtenerFecha(Date.Now.Date)
        Dim horaFila As Integer = 0
        Dim horaActual As Integer = 0
        Dim diferenciaHoras As Integer = 0
        Dim minimoHoras As Integer = 6 + CInt(My.Resources.MinimoHorasLiquidos.ToString())

        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then
            If Not dtgLiqAdmin.Columns(e.ColumnIndex).Name = "HORA" And Not dtgLiqAdmin.Columns(e.ColumnIndex).Name = "TOTAL" Then

                If Not dtgLiqAdmin.Rows(e.RowIndex).Cells("HORA").Value.Equals("SUBTOTAL") And Not dtgLiqAdmin.Rows(e.RowIndex).Cells("HORA").Value.Equals("TOTAL") _
                   And Not dtgLiqAdmin.Columns(e.ColumnIndex).Name = "TOTAL" Then

                    strValorColumna = dtgLiqAdmin.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()

                    If Not strValorColumna = String.Empty Then

                        formDetalle.Mostrar(dtgLiqAdmin.Columns(e.ColumnIndex).Name, m_CodHistoria, "LA",
                                            Convert.ToDouble(dtgLiqAdmin.Rows(e.RowIndex).Cells(e.ColumnIndex).Value),
                                            dtgLiqAdmin.Rows(e.RowIndex).Cells("hora").Value.ToString(), m_fechaConsulta)

                    Else

                        diferenciaDias = BLPlaneacion.obtenerDiferenciaDia(m_fechaConsulta, strFechaActual)
                        horaFila = CInt(dtgLiqAdmin.Rows(e.RowIndex).Cells("HORA").Value.ToString())
                        horaActual = Date.Now.Hour

                        If diferenciaDias = 1 Then

                            If horaFila >= 3 And horaFila <= 6 And horaActual >= 7 And horaActual <= minimoHoras Then

                                horaActual = Date.Now.Hour
                                horaFila = CInt(dtgLiqAdmin.Rows(e.RowIndex).Cells("HORA").Value.ToString())

                                diferenciaHoras = horaActual - horaFila

                                If diferenciaHoras <= CInt(My.Resources.MinimoHorasLiquidos.ToString()) Then

                                    'formCantidades.Mostrar(dtgLiqAdmin.Columns(e.ColumnIndex).Name, horaFila.ToString(), 0, 0, "LA", m_fechaConsulta)

                                    'CargarLiquidosAdministrados(m_fechaConsulta)
                                    'CargarLiquidosEliminados(m_fechaConsulta)
                                    'cargarBalance()
                                    dtgLiqAdmin.CurrentCell = dtgLiqAdmin.Rows(e.RowIndex).Cells(e.ColumnIndex)
                                End If

                            End If

                        End If

                    End If

                End If

            End If
        End If

    End Sub

    Private Sub dtgLiqElim_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dtgLiqElim.CellMouseDoubleClick

        Dim strValorColumna As String = String.Empty
        Dim formDetalle As frm_DetCantidadLiquido = New frm_DetCantidadLiquido()
        Dim formCantidades As frmc_LiquidosCantidades = New frmc_LiquidosCantidades()
        Dim diferenciaDias As Integer = 0
        Dim strFechaActual As String = BLPlaneacion.obtenerFecha(Date.Now.Date)
        Dim horaFila As Integer = 0
        Dim horaActual As Integer = 0
        Dim diferenciaHoras As Integer = 0
        Dim minimoHoras As Integer = 6 + CInt(My.Resources.MinimoHorasLiquidos.ToString())

        If e.RowIndex >= 0 And e.ColumnIndex >= 0 Then

            If Not dtgLiqElim.Columns(e.ColumnIndex).Name = "HORA" And Not dtgLiqElim.Columns(e.ColumnIndex).Name = "TOTAL" Then



                If Not dtgLiqElim.Rows(e.RowIndex).Cells("HORA").Value.Equals("SUBTOTAL") And Not dtgLiqElim.Rows(e.RowIndex).Cells("HORA").Value.Equals("TOTAL") _
               And Not dtgLiqElim.Columns(e.ColumnIndex).Name = "TOTAL" Then

                    strValorColumna = dtgLiqElim.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()

                    If Not strValorColumna = String.Empty Then

                        Dim cantidadHora As Double

                        If dtgLiqElim.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString() = "+" Or
                               dtgLiqElim.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString() = "-" Then

                            cantidadHora = 0

                        Else

                            cantidadHora = Convert.ToDouble(dtgLiqElim.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

                        End If

                        formDetalle.Mostrar(dtgLiqElim.Columns(e.ColumnIndex).Name, m_CodHistoria, "LE",
                                            cantidadHora,
                                            dtgLiqElim.Rows(e.RowIndex).Cells("hora").Value.ToString(), m_fechaConsulta)

                    Else

                        diferenciaDias = BLPlaneacion.obtenerDiferenciaDia(m_fechaConsulta, strFechaActual)
                        horaActual = Date.Now.Hour
                        horaFila = CInt(dtgLiqElim.Rows(e.RowIndex).Cells("HORA").Value.ToString())

                        If diferenciaDias = 1 Then

                            If horaFila >= 3 And horaFila <= 6 And horaActual >= 7 And horaActual <= minimoHoras Then

                                horaActual = Date.Now.Hour
                                horaFila = CInt(dtgLiqElim.Rows(e.RowIndex).Cells("HORA").Value.ToString())

                                diferenciaHoras = horaActual - horaFila

                                If diferenciaHoras <= CInt(My.Resources.MinimoHorasLiquidos.ToString()) Then

                                    'formCantidades.Mostrar(dtgLiqElim.Columns(e.ColumnIndex).Name, horaFila.ToString(), 0, 0, "LE", m_fechaConsulta)

                                    'CargarLiquidosAdministrados(m_fechaConsulta)
                                    'CargarLiquidosEliminados(m_fechaConsulta)
                                    'cargarBalance()
                                    dtgLiqElim.CurrentCell = dtgLiqElim.Rows(e.RowIndex).Cells(e.ColumnIndex)
                                End If

                            End If

                        End If

                    End If

                End If

            End If
        End If
    End Sub

    Private Sub mskFechaHasta_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles mskFechaHasta.MaskInputRejected

    End Sub

    Private Sub mskFechaHasta_Validated(sender As Object, e As EventArgs) Handles mskFechaHasta.Validated
        Dim isValidDate As Boolean = IsDate(mskFechaHasta.Text)

        If isValidDate = False Then
            MsgBox("fecha no valida, favor digitar una fecha valida ")
            AsignarFechaAnterior()

        End If
    End Sub
End Class