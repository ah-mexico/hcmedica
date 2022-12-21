Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Namespace Sophia.HistoriaClinica.Buscador

    Public Class frmBuscadorEquiva
        Private strClasificacion As String
        Private strDescripcion As String
        Private cboBusqueda As ComboBusqueda
        Private strCodPreSgs As String
        Private strCodSucur As String
        Private strEntidad As String
        Private strFechaInicial As String
        Private strManejaConvenio As String
        Private strMedicamento As String
        Private intConSinEstado As Integer
        Private strLogin As String
        Private intEdad As Integer
        Private strSexo As String
        Private strCodprocedimiento As String
        Private blnSeleccionadoConEnter As Boolean = False
        Private indiceGrilla As Integer
        Private strDescripcionOriginal As String
        Private objGeneral As Generales
        Private objPaciente As Paciente
        Public DtProcedim As DataTable
        Public strCodMedicamentoequiva As String
        Public strDescMedicamentoequiva As String
        Public strForFarma As String
        Public strConcentracion As String
        Public strClasificacionDiagn As String

        Private Sub dtgBusqueda_DockChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgBusqueda.DockChanged

        End Sub


        Private Sub dtgBusqueda_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgBusqueda.DoubleClick
            SeleccionarRegistro()
        End Sub

        Private Sub SeleccionarRegistro()

            If dtgBusqueda.CurrentRow Is Nothing Then
                MessageBox.Show("Seleccione un Registro de la Lista", "Buscador", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            With dtgBusqueda.CurrentRow
                Select Case strClasificacion
                    Case "DIAGNOSTICOS"
                        Me.strCodMedicamentoequiva = .Cells.Item("codigo").Value
                        Me.strDescMedicamentoequiva = .Cells.Item("descripcion").Value
                        Me.strClasificacionDiagn = .Cells.Item("clasificacion").Value
                    Case "ORDENMEDICAMENTOSDESCRIPCIONCTC"
                        Me.strCodMedicamentoequiva = .Cells.Item("codigo").Value
                        Me.strDescMedicamentoequiva = .Cells.Item("descProducto").Value
                        Me.strForFarma = IIf(Not IsDBNull(.Cells.Item("descrForma").Value), .Cells.Item("descrForma").Value, "")
                        Me.strConcentracion = IIf(Not IsDBNull(.Cells.Item("concentracion").Value), .Cells.Item("concentracion").Value, "")
                    Case "ORDENMEDICAMENTOSCODIGOCTC"
                        Me.strCodMedicamentoequiva = .Cells.Item("codigo").Value
                        Me.strDescMedicamentoequiva = .Cells.Item("descProducto").Value
                        Me.strForFarma = IIf(Not IsDBNull(.Cells.Item("descrForma").Value), .Cells.Item("descrForma").Value, "")
                        Me.strConcentracion = IIf(Not IsDBNull(.Cells.Item("concentracion").Value), .Cells.Item("concentracion").Value, "")
                End Select

               
            End With

            Me.Close()

            'Me.Dispose()
        End Sub

        Public Sub Mostrar(ByVal EClasificacion As CategoriaDatos, ByVal strDescripcion As String, Optional ByVal strcodigo As String = "")

            Dim objDatos As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim dtDatos As New DataTable
            Dim intCol As Integer
            Dim strTextos() As String
            Dim objConexion As Sophia.HistoriaClinica.DatosConexion.Conexion = Sophia.HistoriaClinica.DatosConexion.Conexion.Instancia
            objPaciente = Paciente.Instancia

            Select Case EClasificacion
                Case CategoriaDatos.Diagnosticos
                    strClasificacion = "DIAGNOSTICOS"
                Case CategoriaDatos.OrdenMedicamentosDescripcion
                    strClasificacion = "ORDENMEDICAMENTOSDESCRIPCIONCTC"

            End Select

            Try

                If Len(Trim(strcodigo)) > 0 Then

                    strClasificacion = "ORDENMEDICAMENTOSCODIGOCTC"

                    dtDatos = objDatos.EjecutarSPConParametros("HC_BuscarCodigo", objConexion, -1, "ORDENMEDICAMENTOSCODIGOCTC", strcodigo, 0, "", _
                                                                          "N", "", 0, "", _
                                                                          "", "", "", "")


                    If dtDatos.Rows.Count <= 0 Then
                        MessageBox.Show("No existen registros para esta búsqueda", "Buscador", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                        Exit Sub
                    Else
                        dtgBusqueda.DataSource = dtDatos

                    End If
                Else



                    strTextos = Split(strDescripcion, " ")
                    strDescripcion = ""
                    For intCol = 0 To UBound(strTextos)
                        If strTextos(intCol).Trim.Length > 2 Then

                            strDescripcion = strDescripcion & ChrW(34) & strTextos(intCol).Trim & "*" & ChrW(34) & " AND "
                        End If
                    Next
                    strDescripcion = Mid(strDescripcion, 1, Len(Trim(strDescripcion)) - 5) & ChrW(34)
                    Me.Height = 349

                    dtDatos = objDatos.EjecutarSPConParametros("HC_BuscarDescripcion", objConexion, -1, Me.strClasificacion, strDescripcion, objPaciente.Edad, objPaciente.Genero, _
                                       "", "", Me.intConSinEstado, "", "", _
                                       "", "", "")
                    If dtDatos.Rows.Count <= 0 Then
                        MessageBox.Show("No existen registros para esta búsqueda", "Buscador", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Close()
                        Exit Sub
                    Else
                        dtgBusqueda.DataSource = dtDatos

                    End If
                End If


            Catch ex As Exception
                If Err.Number = 5 Then
                    MsgBox("No existe información. El criterio de búsqueda no es válido. ", MsgBoxStyle.Information)
                Else
                    MsgBox("Error en la busqueda. " & Err.Number & ": " & ex.Message)
                End If
            End Try
            dtDatos.Columns.Add("login", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("cons", System.Type.GetType("System.Int32"))
            dtDatos.Columns.Add("EstadoUsu", System.Type.GetType("System.String"))

            For intCol = 2 To dtgBusqueda.Columns.Count - 1
                dtgBusqueda.Columns(intCol).Visible = False
            Next
            If Len(strDescripcion) > 3 Then ' herojas 2014/11/25
                With dtgBusqueda

                    .Columns(1).Visible = True
                    .Columns(0).ReadOnly = True
                    .Columns(0).HeaderText = "CODIGO"
                    If strClasificacion = "PROCEDIMIENTOS" Then
                        .Columns(0).Visible = False
                        .Columns(1).Width = 679
                    Else
                        .Columns(0).Visible = True
                        .Columns(1).Width = 600
                    End If
                    .Columns(1).ReadOnly = True
                    .Columns(1).HeaderText = "DESCRIPCION"
                    If .RowCount > 13 Then
                        .Columns(0).Width = 79
                    Else
                        .Columns(0).Width = 97
                    End If
                End With
            Else
                MsgBox("La busqueda debe ser mayor a 3 caracteres")
            End If


            Me.ShowDialog()

        End Sub

        Private Sub dtgBusqueda_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtgBusqueda.KeyPress
            If Asc(e.KeyChar) = 13 Then
                blnSeleccionadoConEnter = True
                SeleccionarRegistro()
            End If
        End Sub


        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
            'cboBusqueda.UltimaDescripcionDeBusqueda = "X"
            Me.Close()
        End Sub

        Public Shared Function filtrarTabla(ByVal dtBase As DataTable, ByVal filtro As String, ByVal dtContenedor As DataTable) As DataTable

            Dim rowsFiltradas() As DataRow

            rowsFiltradas = dtBase.Select(filtro)
            dtContenedor = FuncionesGenerales.copyArrayToDataTable(dtContenedor, rowsFiltradas)
            Return dtContenedor

        End Function


     

        Private Sub frmBuscadorEquiva_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            'Dim objDatos As New Sophia.HistoriaClinica.DAO.DAOGeneral
            'Dim dtDatos As New DataTable
            'Dim intCol As Integer
            'Dim strTextos() As String
            'Dim objConexion As Sophia.HistoriaClinica.DatosConexion.Conexion = Sophia.HistoriaClinica.DatosConexion.Conexion.Instancia
            'Dim fecha As Date


            'Me.rb1.Checked = False
            'Me.rb2.Checked = False
            'Me.rb3.Checked = False
            'Me.rb4.Checked = False
            'Me.rb5.Checked = False
            'Me.rb6.Checked = False
            'Me.rb7.Checked = False

            'objGeneral = Generales.Instancia
            'objPaciente = Paciente.Instancia
            'strDescripcionOriginal = strDescripcion

            ' '' Ingresado por Claudia Garay
            ' '' Se controla la cantidad minima de caracteres para realizar la busqueda ya
            ' '' que al ingresar menos de 3 genera error
            ' '' Solicitado por Ricardo Zaluda
            ' '' 2009-12-29

            'If strDescripcion.Length <= 2 Then
            '    MsgBox("Ingrese mínimo 3 caracteres para realizar la busqueda")
            '    Me.Close()
            '    Exit Sub
            'End If

            ' ''

            'If strClasificacion <> "ORDENMEDICAMENTOSCODIGO" And strClasificacion <> "PROCEDIMIENTOS" Then
            '    strTextos = Split(strDescripcion, " ")
            '    strDescripcion = ""
            '    For intCol = 0 To UBound(strTextos)
            '        If strTextos(intCol).Trim.Length > 2 Then

            '            strDescripcion = strDescripcion & ChrW(34) & strTextos(intCol).Trim & "*" & ChrW(34) & " AND "
            '        End If
            '    Next
            '    strDescripcion = Mid(strDescripcion, 1, Len(Trim(strDescripcion)) - 5) & ChrW(34)
            '    GBOpciones.Visible = False
            '    Me.Height = 349
            'End If

            'If strClasificacion = "PROCEDIMIENTOS" Then
            '    strDescripcion = "%" & strDescripcion & "%"
            '    strCodprocedimiento = ""
            '    GBOpciones.Visible = True
            '    Me.Height = 440
            'End If

            'If strClasificacion = "ENTIDADES" Then
            '    strDescripcion = Mid(strDescripcion, 1, Len(Trim(strDescripcion)) - 2)
            '    strDescripcion = Replace(strDescripcion, ChrW(34), "")
            '    GBOpciones.Visible = False
            '    Me.Height = 349
            'End If


            'If strClasificacion = "ENTIDADESNOIPS" Then
            '    strDescripcion = Mid(strDescripcion, 1, Len(Trim(strDescripcion)) - 2)
            '    strDescripcion = Replace(strDescripcion, ChrW(34), "")
            '    GBOpciones.Visible = False
            '    Me.Height = 349
            'End If

            'If strClasificacion = "PROCEDIMIENTOSQX" Then
            '    strEntidad = objPaciente.Entidad
            '    fecha = objDatos.traerFechaServidor()
            '    strFechaInicial = Format(fecha, objGeneral.Instancia.FormatoFechaCorta)
            'End If

            'Try
            '    dtDatos = objDatos.EjecutarSPConParametros("HC_BuscarDescripcion", objConexion, -1, Me.strClasificacion, Me.strDescripcion, Me.intEdad, Me.strSexo, _
            '                                           Me.strManejaConvenio, Me.strMedicamento, Me.intConSinEstado, objGeneral.Prestador, objGeneral.Sucursal, _
            '                                           Me.strEntidad, Me.strFechaInicial, Me.strCodprocedimiento)
            '    If dtDatos.Rows.Count <= 0 Then
            '        cboBusqueda.UltimaDescripcionDeBusqueda = "ITEM$NO$ENCONTRADO$" & Trim(strDescripcionOriginal)
            '        MessageBox.Show("No existen registros para esta búsqueda", "Buscador", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '        Me.Close()
            '        Exit Sub
            '    End If
            'Catch ex As Exception
            '    If Err.Number = 5 Then
            '        MsgBox("No existe información. El criterio de búsqueda no es válido. ", MsgBoxStyle.Information)
            '    Else
            '        MsgBox("Error en la busqueda. " & Err.Number & ": " & ex.Message)
            '    End If
            'End Try

            'dtDatos.Columns.Add("login", System.Type.GetType("System.String"))
            'dtDatos.Columns.Add("cons", System.Type.GetType("System.Int32"))
            'dtDatos.Columns.Add("EstadoUsu", System.Type.GetType("System.String"))
            'dtgBusqueda.DataSource = dtDatos
            'DtProcedim = dtDatos.Copy
            'For intCol = 2 To dtgBusqueda.Columns.Count - 1
            '    dtgBusqueda.Columns(intCol).Visible = False
            'Next

            'With dtgBusqueda

            '    .Columns(1).Visible = True
            '    .Columns(0).ReadOnly = True
            '    .Columns(0).HeaderText = "CODIGO"
            '    If strClasificacion = "PROCEDIMIENTOS" Then
            '        .Columns(0).Visible = False
            '        .Columns(1).Width = 679
            '    Else
            '        .Columns(0).Visible = True
            '        .Columns(1).Width = 600
            '    End If
            '    .Columns(1).ReadOnly = True
            '    .Columns(1).HeaderText = "DESCRIPCION"
            '    If .RowCount > 13 Then
            '        .Columns(0).Width = 79
            '    Else
            '        .Columns(0).Width = 97
            '    End If

            'End With
        End Sub
    End Class
End Namespace