
'Desarrollado por Claudia Patricia Garay Guerrero
'para la visualización de las planeaciones y administraciones de los
'medicamentos con un rango de 3 dias
'Noviembre de 2011
'Enfermeria - 2da fase

Imports objcon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales

Public Class Frm_PantallaPlaneacion
    Private datosconexion As objcon
    Private codhistoria As String
    Dim dttemporal As New DataTable
    Dim fechauno As String
    Dim fechados As String
    Dim fechatres As String

    Public Sub New(ByVal cod As String, ByVal Fecha As DateTime)

        codhistoria = cod

        ' Llamada necesaria para el Diseñador de Windows Forms.
        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        InitializeComponent()

        CargasDatosPantalla(Fecha)
        mskFechaHasta.Text = Fecha

    End Sub
    ''Configuracion de las columnas de la grilla 
    Private Sub CargarDatosGrilla(ByVal dsDatos As DataTable, ByVal FechaInic As DateTime, ByVal FechaFin As DateTime)
        Dim dttemp As New DataTable
        Dim dttemp2 As New DataTable
        dttemporal = New DataTable

        dttemporal.Columns.Add("Medicamentos", System.Type.GetType("System.String"))
        fechauno = FechaInic
        dttemporal.Columns.Add(fechauno, System.Type.GetType("System.String"))

        dttemporal.Columns.Add("Adm", System.Type.GetType("System.String"))
        dttemporal.Columns.Add("Responsable", System.Type.GetType("System.String"))
        dttemporal.Columns.Add("Observacion", System.Type.GetType("System.String"))


        fechados = DateAdd(DateInterval.Day, -1, FechaFin)
        dttemporal.Columns.Add(fechados, System.Type.GetType("System.String"))
        dttemporal.Columns.Add("Adm ", System.Type.GetType("System.String"))
        dttemporal.Columns.Add("Responsable ", System.Type.GetType("System.String"))
        dttemporal.Columns.Add("Observacion ", System.Type.GetType("System.String"))


        fechatres = FechaFin
        dttemporal.Columns.Add(fechatres, System.Type.GetType("System.String"))
        dttemporal.Columns.Add("Adm  ", System.Type.GetType("System.String"))
        dttemporal.Columns.Add("Responsable  ", System.Type.GetType("System.String"))
        dttemporal.Columns.Add("Observacion  ", System.Type.GetType("System.String"))

        dttemp2 = ConfiguraDatosGrilla(dsDatos)


        Me.dtgPantallaplaneacion.DataSource = dttemp2



        Me.ConfigurarGrilla()

    End Sub
    'Se organiza la data para mostrarla segun los solicitado
    Private Function ConfiguraDatosGrilla(ByVal dttable As DataTable) As DataTable
        Dim medicamento As String
        Dim fechatempo As String = ""
        Dim i As Integer = 0
        Dim cont As Integer = 0
        Dim contfec As Integer = 0
        Dim contfec2 As Integer = 0
        Dim contfec3 As Integer = 0
        Dim planeadosfec1 As String = ""
        Dim planeadosfec2 As String = ""
        Dim planeados As String = ""
        Dim dsplanea As New DataSet
        Dim ds As New DataSet
        Dim a As Integer = 0
        Dim cuentatablas As Integer = 0
        Dim ArrayPlaneados As New ArrayList

        medicamento = dttable.Rows(0).Item("medicamento")


        Me.dtgPantallaplaneacion.DataSource = dttemporal

        dttemporal.Rows.Add(dttemporal.NewRow())
        For j As Integer = 0 To dttable.Rows.Count - 1

            If medicamento = dttable.Rows(j).Item("medicamento") Then
                fechatempo = dttable.Rows(j).Item("Fecha")
                dttemporal.Rows(0).Item("Medicamentos") = dttable.Rows(j).Item("medicamento")
                Select Case fechatempo

                    Case fechauno
                        If dttable.Rows(j).Item("EstadoP") = "P" Then
                            planeados += " " + dttable.Rows(j).Item("HoraPlaneacion")
                        Else
                            dttemporal.Rows.Add(dttemporal.NewRow())
                            dttemporal.Rows(i).Item(fechauno) = dttable.Rows(j).Item("horaAdmin")
                            dttemporal.Rows(i).Item("Adm") = dttable.Rows(j).Item("EstadoP")
                            dttemporal.Rows(i).Item("Responsable") = dttable.Rows(j).Item("Planeacion")
                            dttemporal.Rows(i).Item("Observacion") = dttable.Rows(j).Item("obs")
                            i = i + 1

                        End If
                    Case fechados
                        If dttable.Rows(j).Item("EstadoP") = "P" Then
                            planeados += " " + dttable.Rows(j).Item("HoraPlaneacion")
                        Else
                            If i > 0 And contfec2 <= i Then

                                dttemporal.Rows(contfec2).Item(fechados) = dttable.Rows(j).Item("horaAdmin")
                                dttemporal.Rows(contfec2).Item("Adm ") = dttable.Rows(j).Item("EstadoP")
                                dttemporal.Rows(contfec2).Item("Responsable ") = dttable.Rows(j).Item("Planeacion")
                                dttemporal.Rows(contfec2).Item("Observacion ") = dttable.Rows(j).Item("obs")
                                contfec2 = contfec2 + 1
                            Else
                                dttemporal.Rows.Add(dttemporal.NewRow())
                                dttemporal.Rows(contfec2).Item(fechados) = dttable.Rows(j).Item("horaAdmin")
                                dttemporal.Rows(contfec2).Item("Adm ") = dttable.Rows(j).Item("EstadoP")
                                dttemporal.Rows(contfec2).Item("Responsable ") = dttable.Rows(j).Item("Planeacion")
                                dttemporal.Rows(contfec2).Item("Observacion ") = dttable.Rows(j).Item("obs")
                                contfec2 = contfec2 + 1

                            End If

                        End If
                    Case fechatres
                        If dttable.Rows(j).Item("EstadoP") = "P" Then
                            planeados += " " + dttable.Rows(j).Item("HoraPlaneacion")
                        Else

                            If contfec2 > i Then
                                i = contfec2
                            End If
                            If i > 0 And contfec3 <= i Then
                                dttemporal.Rows(contfec3).Item(fechatres) = dttable.Rows(j).Item("horaAdmin")
                                dttemporal.Rows(contfec3).Item("Adm  ") = dttable.Rows(j).Item("EstadoP")
                                dttemporal.Rows(contfec3).Item("Responsable  ") = dttable.Rows(j).Item("Planeacion")
                                dttemporal.Rows(contfec3).Item("Observacion  ") = dttable.Rows(j).Item("obs")
                                contfec3 = contfec3 + 1

                            Else
                                dttemporal.Rows.Add(dttemporal.NewRow())
                                dttemporal.Rows(contfec3).Item(fechatres) = dttable.Rows(j).Item("horaAdmin")
                                dttemporal.Rows(contfec3).Item("Adm  ") = dttable.Rows(j).Item("EstadoP")
                                dttemporal.Rows(contfec3).Item("Responsable  ") = dttable.Rows(j).Item("Planeacion")
                                dttemporal.Rows(contfec3).Item("Observacion  ") = dttable.Rows(j).Item("obs")
                                contfec3 = contfec3 + 1
                            End If


                        End If
                End Select

            Else


                medicamento = dttable.Rows(j).Item("medicamento")

                If dttemporal.Rows.Count = 1 Then
                    dttemporal.Rows.Add(dttemporal.NewRow())
                End If

                dttemporal.Rows(dttemporal.Rows.Count - 1).Item("Medicamentos") = "PLANEACION " & planeados
                ArrayPlaneados.Add(dttemporal.Rows.Count - 1)

                Dim dttabla As New DataTable
                dttabla = dttemporal.Copy
                dttabla.TableName = "Tabla" & cuentatablas
                dsplanea.Tables.Add(dttabla)
                cuentatablas = cuentatablas + 1

                dttemporal.Clear()
                planeados = ""

                i = 0
                contfec = 0
                contfec2 = 0
                contfec3 = 0

                dttemporal.Rows.Add(dttemporal.NewRow())
                medicamento = dttable.Rows(j).Item("medicamento")

                dttemporal.Rows(i).Item("Medicamentos") = dttable.Rows(j).Item("medicamento")
                j = j - 1

            End If


        Next

        If dttemporal.Rows.Count = 1 Then
            dttemporal.Rows.Add(dttemporal.NewRow())
        End If
        dttemporal.Rows(dttemporal.Rows.Count - 1).Item("Medicamentos") = "PLANEACION " & planeados
        dttemporal.TableName = "Tabla" & cuentatablas
        ' dttemporal.Rows.Add(dttemporal.NewRow())

        Dim dtResultado As New DataTable

        dsplanea.Tables.Add(dttemporal)
        For Each tabla As DataTable In dsplanea.Tables
            dtResultado.Merge(tabla)
        Next


        Return dtResultado
    End Function
    Private Sub ConfigurarGrilla()

        Me.dtgPantallaplaneacion.Columns("Medicamentos").Width = 300
        Me.dtgPantallaplaneacion.Columns("Medicamentos").SortMode = DataGridViewColumnSortMode.Automatic
        Me.dtgPantallaplaneacion.Columns(fechauno).Width = 75
        Me.dtgPantallaplaneacion.Columns(fechados).Width = 75
        Me.dtgPantallaplaneacion.Columns(fechatres).Width = 75
        Me.dtgPantallaplaneacion.Columns("Adm").Width = 35
        Me.dtgPantallaplaneacion.Columns("Adm ").Width = 35
        Me.dtgPantallaplaneacion.Columns("Adm  ").Width = 43
        Me.dtgPantallaplaneacion.Columns("Responsable").Width = 80
        Me.dtgPantallaplaneacion.Columns("Responsable ").Width = 80
        Me.dtgPantallaplaneacion.Columns("Responsable  ").Width = 90
        Me.dtgPantallaplaneacion.Columns("Observacion").Width = 80
        Me.dtgPantallaplaneacion.Columns("Observacion ").Width = 80
        Me.dtgPantallaplaneacion.Columns("Observacion  ").Width = 85
        dtgPantallaplaneacion.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True
        dtgPantallaplaneacion.Columns(0).Frozen = True
    End Sub

    Private Sub CargasDatosPantalla(ByVal FechaFin As DateTime)
        Dim dsDatos As New DataSet
        Dim FechaInic As String
        Dim FechaF As String
        Dim objPlanea As New Planeacion

        datosconexion = objcon.Instancia


        FechaInic = Format(DateAdd(DateInterval.Day, -2, FechaFin), "yyyy/MM/dd")
        FechaF = Format(FechaFin, "yyyy/MM/dd")

        dsDatos = objPlanea.TraerConsultaPantallaPlaneacion(datosconexion, codhistoria, FechaInic, FechaF)

        If Not dsDatos Is Nothing Then
            If dsDatos.Tables(0).Rows.Count = 0 Then
                MsgBox("No existen datos para la fecha ingresada")
                dttemporal.Clear()
                Me.dtgPantallaplaneacion.DataSource = dttemporal
                Exit Sub
            End If
        Else
            MsgBox("No existen datos para la fecha ingresada")
            dttemporal.Clear()
            Me.dtgPantallaplaneacion.DataSource = dttemporal
            Exit Sub
        End If


        CargarDatosGrilla(dsDatos.Tables(0), FechaInic, FechaFin)
        Me.lbldesde.Text = FechaInic
        Me.Lblhasta.Text = FechaF
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnImprimirPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimirPlan.Click
        Dim iHoraIni As Nullable(Of Integer)
        Dim iHoraFin As Nullable(Of Integer)
        Dim objDao As New DAOGeneral
        Dim objGenerales As Generales
        Dim fecha As String
        Dim fechavisor As Date

        objGenerales = Generales.Instancia

        If mskFechaHasta.Text <> "  /  /" Then
            fechavisor = mskFechaHasta.Text
            fecha = Format(fechavisor, objGenerales.FormatoFechaCorta)
        Else
            fecha = Format(objDao.traerFechaServidor(), objGenerales.FormatoFechaCorta)
        End If


        frmRepPlaneacionMed.Show()
        frmRepPlaneacionMed.imprimirRepPlaneacionMed(datosconexion, Me.codhistoria, fecha, fecha, iHoraIni, iHoraFin)
    End Sub



    Private Sub btnVisor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisor.Click
        If mskFechaHasta.Text = "  /  /" Then
            Exit Sub
        End If
        dttemporal.Clear()
        Me.dtgPantallaplaneacion.DataSource = dttemporal
        CargasDatosPantalla(mskFechaHasta.Text)
    End Sub


    Private Sub mskFechaHasta_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles mskFechaHasta.Validating
        If mskFechaHasta.Text <> "  /  /" Then
            If Not IsDate(mskFechaHasta.Text) Then
                MsgBox("Fecha invalida. Debe digitar una fecha valida.", MsgBoxStyle.Information)
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub dtgPantallaplaneacion_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dtgPantallaplaneacion.CellPainting

        Dim dato As String
        dato = IIf(IsDBNull(e.Value), "", e.Value)

        If dato.Contains("PLANEACION") Then
            e.CellStyle.Font = New System.Drawing.Font("Verdana", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End If

    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim iHoraIni As Nullable(Of Integer)
        Dim iHoraFin As Nullable(Of Integer)

        If mskFechaHasta.Text <> "  /  /" Then
            frmRepPlaneacionMed.Show()
            frmRepPlaneacionMed.imprimirRepPlaneacionMed(datosconexion, Me.codhistoria, mskFechaHasta.Text, mskFechaHasta.Text, iHoraIni, iHoraFin, 1)
        Else
            MsgBox("Ingrese la fecha")
        End If

        
    End Sub
End Class