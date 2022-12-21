Public Class frmc_TraeAlarmas

    Public Sub Mostrar(ByVal dttable As DataTable, ByVal strTipoAlarma As String)

        If dttable.Rows.Count > 0 Then
            ConfiguraGrillaAlarma(dttable, strTipoAlarma)

            Me.Text = strTipoAlarma
            Me.ShowDialog()
        End If

    End Sub
    Private Sub ConfiguraGrillaAlarma(ByVal dttable As DataTable, ByVal strAlarma As String)
        Dim i As Integer = 0
        Dim dtfilter As DataTable
        Dim dtRow As DataRow
        Dim widthgrilla As Integer


        dtfilter = dttable.Clone
        dtRow = dtfilter.NewRow
        With dtgAlarmas
            .DataSource = dttable
            Select Case strAlarma
                Case "Riesgo de Caida"
                    .Columns("fec_con").HeaderText = "Fecha"
                Case "Riesgo de Fuga"

                    For i = 0 To dttable.Rows.Count - 1

                        If dttable.Rows(i).Item("Id") = "5" Then
                            dtRow = dtfilter.NewRow()

                            dtRow(0) = dttable.Rows(i).Item("Id")
                            dtRow(1) = dttable.Rows(i).Item("IdentificadorRiesgo")
                            dtRow(2) = dttable.Rows(i).Item("irObservacion")
                            dtRow(3) = dttable.Rows(i).Item("login")
                            dtRow(4) = dttable.Rows(i).Item("Especialidad")
                            dtRow(5) = dttable.Rows(i).Item("irFechaAcivacion")
                            dtfilter.Rows.Add(dtRow)
                        End If
                        .DataSource = dtfilter
                    Next
                    .Columns("Id").Visible = False
                    .Columns("IdentificadorRiesgo").HeaderText = "Identificador de Riesgo"
                    .Columns("login").HeaderText = "Usuario"
                    '.Columns("login").Width = 160
                    .Columns("Especialidad").HeaderText = "Especialidad / Cargo"
                    .Columns("irFechaAcivacion").HeaderText = "Fecha Activación"
                    .Columns("irFechaAcivacion").DefaultCellStyle.Format = "G"
                    .Columns("irObservacion").HeaderText = "Observación"
                    '.Columns("irFechaAcivacion").Width = 160

                Case "Alérgias"
                    For i = 0 To dttable.Rows.Count - 1

                        If dttable.Rows(i).Item("Id") = "1" Then
                            dtRow = dtfilter.NewRow()

                            dtRow(0) = dttable.Rows(i).Item("Id")
                            dtRow(1) = dttable.Rows(i).Item("IdentificadorRiesgo")
                            dtRow(2) = dttable.Rows(i).Item("irObservacion")
                            dtRow(3) = dttable.Rows(i).Item("login")
                            dtRow(4) = dttable.Rows(i).Item("Especialidad")
                            dtRow(5) = dttable.Rows(i).Item("irFechaAcivacion")
                            dtfilter.Rows.Add(dtRow)
                        End If
                        .DataSource = dtfilter
                    Next
                    .Columns("Id").Visible = False
                    .Columns("IdentificadorRiesgo").HeaderText = "Identificador de Riesgo"
                    .Columns("login").HeaderText = "Usuario"
                    .Columns("irFechaAcivacion").HeaderText = "Fecha Activación"
                    .Columns("irFechaAcivacion").DefaultCellStyle.Format = "G"
                    .Columns("irObservacion").HeaderText = "Observación"
                    .Columns("Especialidad").HeaderText = "Especialidad / Cargo"
                Case "Anticoagulado"
                    For i = 0 To dttable.Rows.Count - 1

                        If dttable.Rows(i).Item("Id") = "2" Then
                            dtRow = dtfilter.NewRow()

                            dtRow(0) = dttable.Rows(i).Item("Id")
                            dtRow(1) = dttable.Rows(i).Item("IdentificadorRiesgo")
                            dtRow(2) = dttable.Rows(i).Item("irObservacion")
                            dtRow(3) = dttable.Rows(i).Item("login")
                            dtRow(4) = dttable.Rows(i).Item("Especialidad")
                            dtRow(5) = dttable.Rows(i).Item("irFechaAcivacion")
                            dtfilter.Rows.Add(dtRow)
                        End If
                        .DataSource = dtfilter
                    Next
                    .Columns("Id").Visible = False
                    .Columns("IdentificadorRiesgo").HeaderText = "Identificador de Riesgo"
                    .Columns("login").HeaderText = "Usuario"
                    .Columns("irFechaAcivacion").HeaderText = "Fecha Activación"
                    .Columns("irFechaAcivacion").DefaultCellStyle.Format = "G"
                    .Columns("irObservacion").HeaderText = "Observación"
                    .Columns("Especialidad").HeaderText = "Especialidad / Cargo"
                Case "Alerta Médica"
                    For i = 0 To dttable.Rows.Count - 1

                        If dttable.Rows(i).Item("Id") = "4" Then
                            dtRow = dtfilter.NewRow()

                            dtRow(0) = dttable.Rows(i).Item("Id")
                            dtRow(1) = dttable.Rows(i).Item("IdentificadorRiesgo")
                            dtRow(2) = dttable.Rows(i).Item("irObservacion")
                            dtRow(3) = dttable.Rows(i).Item("login")
                            dtRow(4) = dttable.Rows(i).Item("Especialidad")
                            dtRow(5) = dttable.Rows(i).Item("irFechaAcivacion")

                            dtfilter.Rows.Add(dtRow)
                        End If
                        .DataSource = dtfilter
                    Next
                    .Columns("Id").Visible = False
                    .Columns("IdentificadorRiesgo").HeaderText = "Identificador de Riesgo"
                    .Columns("login").HeaderText = "Usuario"
                    .Columns("irFechaAcivacion").HeaderText = "Fecha Activación"
                    .Columns("irFechaAcivacion").DefaultCellStyle.Format = "G"
                    .Columns("irObservacion").HeaderText = "Observación"
                    .Columns("Especialidad").HeaderText = "Especialidad / Cargo"
                Case "Quirúrgico"
                    For i = 0 To dttable.Rows.Count - 1
                        If dttable.Rows(i).Item("cod_riesgo") = "6" And dttable.Rows(i).Item("estado") = "S" Then
                            dtfilter.Rows.Add(dtRow)
                            dtfilter.Rows(0).Item("fec_con") = dttable.Rows(i).Item("fec_con")
                            dtfilter.Rows(0).Item("login") = dttable.Rows(i).Item("login")
                            dtfilter.Rows(0).Item("descripcion") = dttable.Rows(i).Item("descripcion")

                        End If
                        .DataSource = dtfilter
                    Next
                    .Columns("fec_con").HeaderText = "Fecha"
                    .Columns("fec_con").DefaultCellStyle.Format = "G"
                    .Columns("consecutivo").Visible = False
                    .Columns("cod_historia").Visible = False
                    .Columns("cod_riesgo").Visible = False
                    .Columns("estado").Visible = False
                    .Columns("fec_con").Width = 80
                    .Columns("descripcion").Width = 200
                    .Columns("descripcion").HeaderText = "DESCRIPCION"
                    .Columns("login").Width = 80
                Case "Aislamiento por Aerosol"
                    For i = 0 To dttable.Rows.Count - 1

                        If dttable.Rows(i).Item("Id") = "8" Then
                            dtRow = dtfilter.NewRow()

                            dtRow(0) = dttable.Rows(i).Item("Id")
                            dtRow(1) = dttable.Rows(i).Item("descripcion")
                            dtRow(2) = dttable.Rows(i).Item("Observacion")
                            dtRow(3) = dttable.Rows(i).Item("login")
                            dtRow(4) = dttable.Rows(i).Item("Especialidad")
                            dtRow(5) = dttable.Rows(i).Item("FechaActivacion")
                            dtfilter.Rows.Add(dtRow)
                        End If
                        .DataSource = dtfilter
                    Next
                    .Columns("Id").Visible = False
                    .Columns("descripcion").HeaderText = "Identificador de Riesgo"
                    .Columns("Observacion").HeaderText = "Observación"
                    .Columns("login").HeaderText = "Usuario"
                    .Columns("Especialidad").HeaderText = "Especialidad / Cargo"
                    .Columns("FechaActivacion").HeaderText = "Fecha Activación"
                    .Columns("FechaActivacion").DefaultCellStyle.Format = "G"

                Case "Aislamiento por Contacto"
                    For i = 0 To dttable.Rows.Count - 1

                        If dttable.Rows(i).Item("Id") = "9" Then
                            dtRow = dtfilter.NewRow()

                            dtRow(0) = dttable.Rows(i).Item("Id")
                            dtRow(1) = dttable.Rows(i).Item("descripcion")
                            dtRow(2) = dttable.Rows(i).Item("Observacion")
                            dtRow(3) = dttable.Rows(i).Item("login")
                            dtRow(5) = dttable.Rows(i).Item("FechaActivacion")
                            dtRow(4) = dttable.Rows(i).Item("Especialidad")
                            dtfilter.Rows.Add(dtRow)
                        End If
                        .DataSource = dtfilter
                    Next
                    .Columns("Id").Visible = False
                    .Columns("descripcion").HeaderText = "Identificador de Riesgo"
                    .Columns("Observacion").HeaderText = "Observación"
                    .Columns("login").HeaderText = "Usuario"
                    .Columns("FechaActivacion").HeaderText = "Fecha Activación"
                    .Columns("FechaActivacion").DefaultCellStyle.Format = "G"
                    .Columns("Especialidad").HeaderText = "Especialidad / Cargo"
                Case "Aislamiento por Gotas"
                    For i = 0 To dttable.Rows.Count - 1

                        If dttable.Rows(i).Item("Id") = "10" Then
                            dtRow = dtfilter.NewRow()

                            dtRow(0) = dttable.Rows(i).Item("Id")
                            dtRow(1) = dttable.Rows(i).Item("descripcion")
                            dtRow(2) = dttable.Rows(i).Item("Observacion")
                            dtRow(3) = dttable.Rows(i).Item("login")
                            dtRow(5) = dttable.Rows(i).Item("FechaActivacion")
                            dtRow(4) = dttable.Rows(i).Item("Especialidad")
                            dtfilter.Rows.Add(dtRow)
                        End If
                        .DataSource = dtfilter
                    Next
                    .Columns("Id").Visible = False
                    .Columns("descripcion").HeaderText = "Identificador de Riesgo"
                    .Columns("Observacion").HeaderText = "Observación"
                    .Columns("login").HeaderText = "Usuario"
                    .Columns("FechaActivacion").HeaderText = "Fecha Activación"
                    .Columns("FechaActivacion").DefaultCellStyle.Format = "G"
                    .Columns("Especialidad").HeaderText = "Especialidad / Cargo"
                Case "Aislamiento por Protector"
                    For i = 0 To dttable.Rows.Count - 1

                        If dttable.Rows(i).Item("Id") = "218" Then
                            dtRow = dtfilter.NewRow()

                            dtRow(0) = dttable.Rows(i).Item("Id")
                            dtRow(1) = dttable.Rows(i).Item("descripcion")
                            dtRow(2) = dttable.Rows(i).Item("Observacion")
                            dtRow(3) = dttable.Rows(i).Item("login")
                            dtRow(5) = dttable.Rows(i).Item("FechaActivacion")
                            dtRow(4) = dttable.Rows(i).Item("Especialidad")
                            dtfilter.Rows.Add(dtRow)
                        End If
                        .DataSource = dtfilter
                    Next
                    .Columns("Id").Visible = False
                    .Columns("descripcion").HeaderText = "Identificador de Riesgo"
                    .Columns("Observacion").HeaderText = "Observación"
                    .Columns("login").HeaderText = "Usuario"
                    .Columns("FechaActivacion").HeaderText = "Fecha Activación"
                    .Columns("FechaActivacion").DefaultCellStyle.Format = "G"
                    .Columns("Especialidad").HeaderText = "Especialidad / Cargo"
                Case "Aislamiento por Vectores"
                    For i = 0 To dttable.Rows.Count - 1

                        If dttable.Rows(i).Item("Id") = "219" Then
                            dtRow = dtfilter.NewRow()

                            dtRow(0) = dttable.Rows(i).Item("Id")
                            dtRow(1) = dttable.Rows(i).Item("descripcion")
                            dtRow(2) = dttable.Rows(i).Item("Observacion")
                            dtRow(3) = dttable.Rows(i).Item("login")
                            dtRow(5) = dttable.Rows(i).Item("FechaActivacion")
                            dtRow(4) = dttable.Rows(i).Item("Especialidad")
                            dtfilter.Rows.Add(dtRow)
                        End If
                        .DataSource = dtfilter
                    Next
                    .Columns("Id").Visible = False
                    .Columns("descripcion").HeaderText = "Identificador de Riesgo"
                    .Columns("Observacion").HeaderText = "Observación"
                    .Columns("login").HeaderText = "Usuario"
                    .Columns("FechaActivacion").HeaderText = "Fecha Activación"
                    .Columns("FechaActivacion").DefaultCellStyle.Format = "G"
                    .Columns("Especialidad").HeaderText = "Especialidad / Cargo"
                Case "Resistencia"
                    For i = 0 To dttable.Rows.Count - 1

                        If dttable.Rows(i).Item("Id") = "3" Then
                            dtRow = dtfilter.NewRow()

                            dtRow(0) = dttable.Rows(i).Item("Id")
                            dtRow(1) = dttable.Rows(i).Item("IdentificadorRiesgo")
                            dtRow(2) = dttable.Rows(i).Item("irObservacion")
                            dtRow(3) = dttable.Rows(i).Item("login")
                            dtRow(4) = dttable.Rows(i).Item("Especialidad")
                            dtRow(5) = dttable.Rows(i).Item("irFechaAcivacion")
                            dtfilter.Rows.Add(dtRow)
                        End If
                        .DataSource = dtfilter
                    Next
                    .Columns("Id").Visible = False
                    .Columns("IdentificadorRiesgo").HeaderText = "Identificador de Riesgo"
                    .Columns("login").HeaderText = "Usuario"
                    .Columns("irFechaAcivacion").HeaderText = "Fecha Activación"
                    .Columns("irFechaAcivacion").DefaultCellStyle.Format = "G"
                    .Columns("irObservacion").HeaderText = "Observación"
                    .Columns("Especialidad").HeaderText = "Especialidad / Cargo"
                Case "Nutricional"
                    For i = 0 To dttable.Rows.Count - 1

                        If dttable.Rows(i).Item("Id") = "6" Then
                            dtRow = dtfilter.NewRow()

                            dtRow(0) = dttable.Rows(i).Item("Id")
                            dtRow(1) = dttable.Rows(i).Item("IdentificadorRiesgo")
                            dtRow(2) = dttable.Rows(i).Item("irObservacion")
                            dtRow(3) = dttable.Rows(i).Item("login")
                            dtRow(4) = dttable.Rows(i).Item("Especialidad")
                            dtRow(5) = dttable.Rows(i).Item("irFechaAcivacion")
                            dtfilter.Rows.Add(dtRow)
                        End If
                        .DataSource = dtfilter
                    Next
                    .Columns("Id").Visible = False
                    .Columns("IdentificadorRiesgo").HeaderText = "Identificador de Riesgo"
                    .Columns("login").HeaderText = "Usuario"
                    .Columns("irFechaAcivacion").HeaderText = "Fecha Activación"
                    .Columns("irFechaAcivacion").DefaultCellStyle.Format = "G"
                    .Columns("irObservacion").HeaderText = "Observación"
                    .Columns("Especialidad").HeaderText = "Especialidad / Cargo"
                Case "Paliativo"
                    For i = 0 To dttable.Rows.Count - 1

                        If dttable.Rows(i).Item("Id") = "1" Then
                            dtRow = dtfilter.NewRow()

                            dtRow(0) = dttable.Rows(i).Item("Id")
                            dtRow(1) = dttable.Rows(i).Item("descripcion")
                            dtRow(2) = dttable.Rows(i).Item("Observacion")
                            dtRow(3) = dttable.Rows(i).Item("login")
                            dtRow(4) = dttable.Rows(i).Item("Cargo")
                            dtRow(5) = dttable.Rows(i).Item("FechaActivacion")
                            dtfilter.Rows.Add(dtRow)
                        End If
                        .DataSource = dtfilter
                    Next
                    .Columns("Id").Visible = False
                    .Columns("descripcion").HeaderText = "Identificador de Riesgo"
                    .Columns("login").HeaderText = "Usuario"
                    .Columns("FechaActivacion").HeaderText = "Fecha Activación"
                    .Columns("FechaActivacion").DefaultCellStyle.Format = "G"
                    .Columns("Observacion").HeaderText = "Observación"
                    .Columns("Cargo").HeaderText = "Especialidad / Cargo"
                Case "Deterioro Clínico"
                    For i = 0 To dttable.Rows.Count - 1
                        dtRow = dtfilter.NewRow()

                        dtRow(0) = dttable.Rows(i).Item("Resultado")
                        dtRow(1) = dttable.Rows(i).Item("Resultado")
                        dtRow(2) = dttable.Rows(i).Item("Observacion")
                        dtRow(3) = dttable.Rows(i).Item("fecha")
                        dtRow(4) = dttable.Rows(i).Item("Usuario")
                        dtRow(5) = dttable.Rows(i).Item("Cargo")
                        dtfilter.Rows.Add(dtRow)
                        .DataSource = dtfilter
                    Next
                    .Columns("Resultado").Visible = False
                    .Columns("Calificacion").HeaderText = "Puntaje Total"
                    .Columns("observacion").HeaderText = "Descripción"
                    .Columns("fecha").HeaderText = "Fecha Activación"
                    .Columns("fecha").DefaultCellStyle.Format = "G"
                    .Columns("Usuario").HeaderText = "Usuario"
                    .Columns("Cargo").HeaderText = "Especialidad / Cargo"
            End Select
            ' Me.Size = dtgAlarmas.Size
            '
            ConfigurararColumnasGrilla(dttable.TableName)

        End With





    End Sub

    Private Sub frmc_TraeAlarmas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub ConfigurararColumnasGrilla(ByVal nombretabla As String)
        Try
            Me.dtgAlarmas.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            If nombretabla = "Table6" Then
                Me.dtgAlarmas.Columns(1).Width = 200
                Me.dtgAlarmas.Columns(2).Width = 200
                Me.dtgAlarmas.Columns(3).Width = 200
                Me.dtgAlarmas.Columns(4).Width = 120
                Me.dtgAlarmas.Columns(5).Width = 150
            End If

            If nombretabla = "Table5" Or nombretabla = "Table7" Then
                Me.dtgAlarmas.Columns(1).Width = 160
                Me.dtgAlarmas.Columns(2).Width = 200
                Me.dtgAlarmas.Columns(3).Width = 150
                Me.dtgAlarmas.Columns(4).Width = 120
                Me.dtgAlarmas.Columns(3).Width = 150
            End If
            If nombretabla = "Table8" Then
                Me.dtgAlarmas.Columns(1).Width = 150
                Me.dtgAlarmas.Columns(2).Width = 300
                Me.dtgAlarmas.Columns(3).Width = 120
                Me.dtgAlarmas.Columns(4).Width = 155
                Me.dtgAlarmas.Columns(4).Width = 155
            End If

        Catch ex As Exception

        End Try

    End Sub
End Class