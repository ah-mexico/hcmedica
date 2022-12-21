Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Namespace Sophia.HistoriaClinica.Buscador

    Public Class frmBuscador
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
        'agfa_orm_in herojas 2014/10/10 
        Private dtDatos1 As DataTable


        Private Sub frmBuscador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Dim objDatos As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim dtDatos As New DataTable
            Dim intCol As Integer
            Dim strTextos() As String
            Dim objConexion As Sophia.HistoriaClinica.DatosConexion.Conexion = Sophia.HistoriaClinica.DatosConexion.Conexion.Instancia
            Dim fecha As Date
            Dim result As DialogResult

            Me.rb1.Checked = False
            Me.rb2.Checked = False
            Me.rb3.Checked = False
            Me.rb4.Checked = False
            Me.rb5.Checked = False
            Me.rb6.Checked = False
            Me.rb7.Checked = False
            Me.rb9.Checked = False
            Me.rb10.Checked = False

            objGeneral = Generales.Instancia
            objPaciente = Paciente.Instancia
            strDescripcionOriginal = strDescripcion

            '' Ingresado por Claudia Garay
            '' Se controla la cantidad minima de caracteres para realizar la busqueda ya
            '' que al ingresar menos de 3 genera error
            '' Solicitado por Ricardo Zaluda
            '' 2009-12-29

            If strDescripcion.Length <= 2 Then
                MsgBox("Ingrese mínimo 3 caracteres para realizar la búsqueda")
                Me.Close()
                Exit Sub
            End If

            'agfa_orm_in herojas 2014/10/10 
            If strClasificacion <> "ORDENMEDICAMENTOSCODIGO" And strClasificacion <> "PROCEDIMIENTOS" And strClasificacion <> "PROCEDIMIENTOCODIGOVARIOS" Then ' agfa_orm_in herojas 2014/10/10
                strTextos = Split(strDescripcion, " ")
                strDescripcion = ""
                For intCol = 0 To UBound(strTextos)
                    If strTextos(intCol).Trim.Length > 2 Then

                        strDescripcion = strDescripcion & ChrW(34) & strTextos(intCol).Trim & "*" & ChrW(34) & " AND "
                    End If
                Next
                strDescripcion = Mid(strDescripcion, 1, Len(Trim(strDescripcion)) - 5) & ChrW(34)
                GBOpciones.Visible = False
                Me.Height = 349
            End If

            If strClasificacion = "PROCEDIMIENTOS" Then
                strDescripcion = "%" & strDescripcion & "%"
                strCodprocedimiento = ""
                GBOpciones.Visible = True
                Me.Height = 440
            End If

            If strClasificacion = "ENTIDADES" Then
                strDescripcion = Mid(strDescripcion, 1, Len(Trim(strDescripcion)) - 2)
                strDescripcion = Replace(strDescripcion, ChrW(34), "")
                GBOpciones.Visible = False
                Me.Height = 349
            End If

            If strClasificacion = "ENTIDADESNOIPS" Then
                strDescripcion = Mid(strDescripcion, 1, Len(Trim(strDescripcion)) - 2)
                strDescripcion = Replace(strDescripcion, ChrW(34), "")
                GBOpciones.Visible = False
                Me.Height = 349
            End If

            If strClasificacion = "PROCEDIMIENTOS" Then
                strEntidad = objPaciente.Entidad
                fecha = objDatos.traerFechaServidor()
                strFechaInicial = Format(fecha, objGeneral.Instancia.FormatoFechaCorta)
            End If

            If strClasificacion = "PROCEDIMIENTOSRIS" And objGeneral.Pais = "484" Then
                strClasificacion = "PROCEDIMIENTOS"
            End If

            Try
                ''Me.strClasificacion
                ' agfa_orm_in herojas 2014/10/10
                Dim proced As String
                proced = "HC_BuscarDescripcion"
                If strClasificacion = "PROCEDIMIENTOCODIGOVARIOS" Then
                    proced = "HC_BuscarCodigo"
                    'strClasificacion = "PROCEDIMIENTOS"
                End If
                '

                ' dtDatos = objDatos.EjecutarSPConParametros(proced, objConexion, -1, strClasificacion, Me.strDescripcion, Me.intEdad, Me.strSexo, _
                '                                       Me.strManejaConvenio, Me.strMedicamento, Me.intConSinEstado, objGeneral.Prestador, objGeneral.Sucursal, _
                '                                      Me.strEntidad, Me.strFechaInicial, Me.strCodprocedimiento)

                ''cpgaray OS9673589, no se está refrescando el genero y la edad del paciente lo que genera errores en la busqueda de diagnosticos
                dtDatos = objDatos.EjecutarSPConParametros(proced, objConexion, -1, strClasificacion, Me.strDescripcion, objPaciente.Edad, objPaciente.Genero,
                                                       Me.strManejaConvenio, Me.strMedicamento, Me.intConSinEstado, objGeneral.Prestador, objGeneral.Sucursal,
                                                       Me.strEntidad, Me.strFechaInicial, Me.strCodprocedimiento)
                If dtDatos.Rows.Count <= 0 Then
                    cboBusqueda.UltimaDescripcionDeBusqueda = "ITEM$NO$ENCONTRADO$" & Trim(strDescripcionOriginal)


                    'cdqf adiciona la funcionalidad especifica que solicitaron en antecedentes farmacologicos
                    'CU_CONC_01 (Conciliación Medicamentos) Se modifica la condición para la strClasificacion, se reempleza PRODUCTOS por la lista de productos que se ven en la orden médica. INDRA/OJPARRA 25/03/2022
                    If proced = "HC_BuscarDescripcion" And strClasificacion = "ORDENMEDICAMENTOSDESCRIPCION" And cboBusqueda.Name = "cboMedicamentosAF" Then

                        result = MessageBox.Show("No existen registros para esta búsqueda, registre medicamento fuera del listado", "Buscador", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

                        If result = DialogResult.OK Then
                            objGeneral.strNoVademecum = True
                        End If

                    Else
                        MessageBox.Show("No existen registros para esta búsqueda", "Buscador", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If

                    Me.Close()
                    Exit Sub

                Else
                    objGeneral.strNoVademecum = False
                    'cdqf
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
            dtgBusqueda.DataSource = dtDatos
            DtProcedim = dtDatos.Copy

            For intCol = 2 To dtgBusqueda.Columns.Count - 1
                dtgBusqueda.Columns(intCol).Visible = False
            Next

            If strClasificacion = "PRODUCTOS" Or
             strClasificacion = "ORDENMEDICAMENTOSDESCRIPCION" Or strClasificacion = "ORDENMEDICAMENTOSCODIGO" Or
             strClasificacion = "PRODUCTOSEX" Or strClasificacion = "PRODUCTOSCONVENIO" Then

                With dtgBusqueda

                    .Columns(1).Visible = True
                    .Columns(0).ReadOnly = True
                    .Columns(0).HeaderText = "CODIGO"
                    .Columns(0).Visible = True
                    .Columns(1).Width = 320
                    .Columns(1).ReadOnly = True
                    .Columns(1).HeaderText = "DESCRIPCION"
                    If .RowCount > 13 Then
                        .Columns(0).Width = 79
                    Else
                        .Columns(0).Width = 97
                    End If
                    'MsgBox("flag_pos")
                    .Columns("flag_pos").Visible = True
                    .Columns("flag_pos").HeaderText = "POS"
                    .Columns("flag_pos").ReadOnly = True
                    .Columns("flag_pos").Width = 50
                    'MsgBox("despues_flag_pos")
                    If strClasificacion = "PRODUCTOSCONVENIO" Then
                        .Columns("flag_pos").DefaultCellStyle.BackColor = Color.Silver
                        .Columns("codSISPRO").Visible = True
                        .Columns("desSISPRO").Visible = True
                        .Columns("codSISPRO").Width = 90
                        .Columns("desSISPRO").Width = 140
                    Else
                        .Columns("flag_pos").DefaultCellStyle.BackColor = Color.BlueViolet
                    End If

                    .Columns("flag_pos").DefaultCellStyle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                    If strClasificacion = "ORDENMEDICAMENTOSDESCRIPCION" Then
                        .Columns("codSISPRO").Visible = True
                        .Columns("desSISPRO").Visible = True
                        .Columns("codSISPRO").Width = 90
                        .Columns("desSISPRO").Width = 150
                    End If

                End With

            Else

                With dtgBusqueda

                    .Columns(1).Visible = True
                    .Columns(0).ReadOnly = True
                    .Columns(0).HeaderText = "CODIGO"
                    ''CCGUTIEREZ. ALM-189. 30/09/2021
                    ''Se cambia la propiedad a Visible = True para visualizar el codigo del procedimiento en el grid
                    If strClasificacion = "PROCEDIMIENTOS" Then
                        .Columns(0).Visible = True
                        '.Columns(0).Visible = False
                        .Columns(1).Width = 400
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

                    If strClasificacion = "PROCEDIMIENTOS" Then
                        .Columns("flag_pos").DefaultCellStyle.BackColor = Color.BlueViolet
                        .Columns("flag_pos").Visible = True
                        .Columns("flag_pos").HeaderText = "POS"
                        .Columns("flag_pos").ReadOnly = True
                        .Columns("flag_pos").Width = 50
                        .Columns("flag_pos").DefaultCellStyle.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
                        .Columns("codSISPRO").Visible = True
                        .Columns("desSISPRO").Visible = True
                        .Columns("codSISPRO").Width = 90
                        .Columns("desSISPRO").Width = 150
                    End If

                End With
            End If

        End Sub

        Private Sub dtgBusqueda_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgBusqueda.DoubleClick
            SeleccionarRegistro()
        End Sub

        Private Sub SeleccionarRegistro()
            Dim dtTable As New DataTable
            Dim dtRowSel As DataRow
            Dim dtDatos As New DataTable
            Dim intIndex As Integer

            ''''''Recuperacion del registro seleccionado
            Dim cm As CurrencyManager = CType(Me.BindingContext(dtgBusqueda.DataSource, dtgBusqueda.DataMember), CurrencyManager)
            Dim dv As DataView = CType(cm.List, DataView)
            Dim dr As DataRow
            If blnSeleccionadoConEnter = True Then
                dr = dv.Item(IIf(cm.Position = 0, 1, cm.Position) - 1).Row
                blnSeleccionadoConEnter = False
            Else
                dr = dv.Item(cm.Position).Row
            End If

            '''''''''

            dtTable = dtgBusqueda.DataSource

            If dtTable Is Nothing Then
                Exit Sub
            End If

            If Me.strClasificacion = "PRODUCTOSCONVENIO" And Me.strManejaConvenio = "S" Then
                If dr.Item("convenio").ToString = "N" Then
                    cboBusqueda.UltimaDescripcionDeBusqueda = "ITEM$NO$ENCONTRADO$" & Trim(strDescripcionOriginal)
                    MessageBox.Show("Este medicamento no es cubierto por la entidad seleccionada." & vbCrLf & "Debe ser formulado por otra entidad.", "Historia clínica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                    Exit Sub
                End If
            End If

            If cboBusqueda.OrigenDeDatos Is Nothing Then
                dtTable = dtgBusqueda.DataSource
                If blnSeleccionadoConEnter = True Then
                    intIndex = IIf(dtgBusqueda.CurrentRow.Index = dtgBusqueda.Rows.Count, dtgBusqueda.CurrentRow.Index, dtgBusqueda.CurrentRow.Index - 1)
                    blnSeleccionadoConEnter = False
                Else
                    intIndex = dtgBusqueda.CurrentRow.Index
                End If
                dtRowSel = dr 'dtTable.Rows(intIndex)
                dtDatos = dtTable.Clone
                dtDatos.ImportRow(dtRowSel)
                If dtDatos.Rows.Count = 0 Then
                    cboBusqueda.UltimaDescripcionDeBusqueda = "X"
                    Me.Close()
                    Exit Sub
                End If
                dtDatos.Rows(0).Item("cons") = 1
                dtDatos.Rows(0).Item("Login") = strLogin
                cboBusqueda.OrigenDeDatos = dtDatos
                cboBusqueda.Text = dtDatos.Rows(0).Item("descripcion").ToString()
                'cboBusqueda.ControlTextoEnlace.AutoCompleteCustomSource.Add(dtDatos.Rows(0).Item("codigo").ToString())
                cboBusqueda.ControlTextoEnlace.Text = dtDatos.Rows(0).Item("codigo").ToString()
                cboBusqueda.UltimaDescripcionDeBusqueda = dtDatos.Rows(0).Item("descripcion").ToString()
                cboBusqueda.lanzaEventoActualizarDatosElegidos(dr)
                Me.Close()
                Exit Sub
            End If
            'agfa_orm_in herojas 2014/10/10  se agrega este if hata el else
            If Me.strClasificacion = "PROCEDIMIENTOCODIGOVARIOS" Then
                'cboBusqueda.CampoEnlazado = "descripcion"
                dtTable = dtgBusqueda.DataSource
                If blnSeleccionadoConEnter = True Then
                    intIndex = IIf(dtgBusqueda.CurrentRow.Index = dtgBusqueda.Rows.Count, dtgBusqueda.CurrentRow.Index, dtgBusqueda.CurrentRow.Index - 1)
                    blnSeleccionadoConEnter = False
                Else
                    intIndex = dtgBusqueda.CurrentRow.Index
                End If
                dtRowSel = dr 'dtTable.Rows(intIndex)
                dtRowSel("Login") = strLogin
                dtRowSel("cons") = 1

                cboBusqueda.UltimaDescripcionDeBusqueda = dtRowSel("descripcion").ToString
                'cboBusqueda.AdicionarDato(dtRowSel)
                dtDatos1 = dtTable.Clone
                dtDatos1 = filtrarTabla(dtTable, "codigo_ris='" & dtRowSel("Codigo_Ris") & "'", dtDatos1)
            Else

                If cboBusqueda.OrigenDeDatos.Rows.Count <= 0 Then
                    dtTable = dtgBusqueda.DataSource
                    If blnSeleccionadoConEnter = True Then
                        intIndex = IIf(dtgBusqueda.CurrentRow.Index = dtgBusqueda.Rows.Count, dtgBusqueda.CurrentRow.Index, dtgBusqueda.CurrentRow.Index - 1)
                        blnSeleccionadoConEnter = False
                    Else
                        intIndex = dtgBusqueda.CurrentRow.Index
                    End If
                    dtRowSel = dr 'dtTable.Rows(intIndex)
                    dtDatos = dtTable.Clone
                    dtDatos.ImportRow(dtRowSel)
                    dtDatos.Rows(0).Item("cons") = 1
                    dtDatos.Rows(0).Item("Login") = strLogin
                    cboBusqueda.OrigenDeDatos = dtDatos
                    cboBusqueda.Text = dtDatos.Rows(0).Item("descripcion").ToString()
                    'cboBusqueda.ControlTextoEnlace.AutoCompleteCustomSource.Add(dtDatos.Rows(0).Item("codigo").ToString())
                    cboBusqueda.ControlTextoEnlace.Text = dtDatos.Rows(0).Item("codigo").ToString()
                    cboBusqueda.UltimaDescripcionDeBusqueda = dtDatos.Rows(0).Item("descripcion").ToString()
                Else
                    dtTable = dtgBusqueda.DataSource
                    If blnSeleccionadoConEnter = True Then
                        intIndex = IIf(dtgBusqueda.CurrentRow.Index = dtgBusqueda.Rows.Count, dtgBusqueda.CurrentRow.Index, dtgBusqueda.CurrentRow.Index - 1)
                        blnSeleccionadoConEnter = False
                    Else
                        intIndex = dtgBusqueda.CurrentRow.Index
                    End If
                    dtRowSel = dr 'dtTable.Rows(intIndex)
                    dtRowSel("Login") = strLogin
                    dtRowSel("cons") = 1
                    cboBusqueda.UltimaDescripcionDeBusqueda = dtRowSel("descripcion").ToString
                    cboBusqueda.AdicionarDato(dtRowSel)
                End If
                'System.Threading.Thread.Sleep(1000)

                ''Lanza el evento que permite le permite a otros controles 
                ''saber que datos han sido escogidos
                cboBusqueda.lanzaEventoActualizarDatosElegidos(dr)
            End If
            Me.Close()

            'Me.Dispose()
        End Sub

        'agfa_orm_in herojas 2014/10/10 se agrega el parametro optional datarow
        Public Sub Mostrar(ByVal EClasificacion As CategoriaDatos, ByVal cboBusqueda As ComboBusqueda, _
                           ByVal strDescripcion As String, Optional ByRef dt As DataTable = Nothing)

            Select Case EClasificacion
                Case CategoriaDatos.Diagnosticos
                    strClasificacion = "DIAGNOSTICOS"
                Case CategoriaDatos.DiagnosticosPatologicos
                    strClasificacion = "DIAGNOSTICOSPATOLOGICOS"
                Case CategoriaDatos.DiagnosticosTraumatologicos
                    strClasificacion = "DIAGNOSTICOSTRAUMATOLOGICOS"
                Case CategoriaDatos.Procedimientos
                    strClasificacion = "PROCEDIMIENTOS"
                Case CategoriaDatos.DiagnosticosOncologicos
                    strClasificacion = "DIAGNOSTICOSONCOLOGICOS"
                Case CategoriaDatos.DiagnosticosNoOncologicos
                    strClasificacion = "DIAGNOSTICOSNOONCOLOGICOS"
                    'If Not cboBusqueda.CodigoTipoProcedimiento Is Nothing Then
                    '    If cboBusqueda.CodigoTipoProcedimiento.Equals(String.Empty) Then
                    '        MessageBox.Show("El tipo de procedimiento es requerido.", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '        'SE EJECUTA EL PROCEDIMIENTO ACTUALIZARDATOSELEGIDOS DEL OBJETO
                    '        cboBusqueda.lanzaEventoActualizarDatosElegidos(Nothing)
                    '        Exit Sub
                    '    End If
                    'Else
                    '    MessageBox.Show("El tipo de procedimiento es requerido.", "Historia Clinica", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    '    'SE EJECUTA EL PROCEDIMIENTO ACTUALIZARDATOSELEGIDOS DEL OBJETO
                    '    cboBusqueda.lanzaEventoActualizarDatosElegidos(Nothing)
                    '    Exit Sub
                    'End If
                Case CategoriaDatos.Productos
                    strClasificacion = "PRODUCTOS"
                Case CategoriaDatos.OrdenMedicamentosDescripcion
                    strClasificacion = "ORDENMEDICAMENTOSDESCRIPCION"
                Case CategoriaDatos.OrdenMedicamentosCodigo
                    strClasificacion = "ORDENMEDICAMENTOSCODIGO"
                Case CategoriaDatos.Entidades
                    strClasificacion = "ENTIDADES"
                Case CategoriaDatos.EntidadesNIPS
                    strClasificacion = "ENTIDADESNOIPS"
                Case CategoriaDatos.ProductosConvenio
                    strClasificacion = "PRODUCTOSCONVENIO"
                Case CategoriaDatos.ProcedimientosEx
                    strClasificacion = "PROCEDIMIENTOSEX"
                Case CategoriaDatos.ProductosEx
                    strClasificacion = "PRODUCTOSEX"
                Case CategoriaDatos.ProcedimientoCodigoVarios
                    strClasificacion = "PROCEDIMIENTOCODIGOVARIOS"  ' agfa_orm_in herojas 2014/10/10
                Case CategoriaDatos.Ordenindicaciones 'ER_OSI 598 Indicaciones Médicas MARTOVAR 2017/09/26
                    strClasificacion = "INDICACIONES"
                Case CategoriaDatos.ProcedimientosQX
                    strClasificacion = "PROCEDIMIENTOSQX"
            End Select
            '//////Enviar parametros 
            Me.cboBusqueda = cboBusqueda
            Me.strDescripcion = strDescripcion
            Me.strCodPreSgs = IIf(cboBusqueda.Prestador Is Nothing, "", cboBusqueda.Prestador)
            Me.strCodSucur = IIf(cboBusqueda.Sucursal Is Nothing, "", cboBusqueda.Sucursal)
            Me.strEntidad = IIf(cboBusqueda.Entidad Is Nothing, "", cboBusqueda.Entidad)
            Me.strFechaInicial = IIf(cboBusqueda.FechaInicialMedicamento Is Nothing, "", cboBusqueda.FechaInicialMedicamento)
            Me.strManejaConvenio = IIf(cboBusqueda.ConvenioMedicamento = False, "N", "S")
            Me.strMedicamento = IIf(cboBusqueda.Medicamento Is Nothing, "", cboBusqueda.Medicamento)
            Me.intConSinEstado = IIf(cboBusqueda.EstadoMedicamento = False, 0, 1)
            Me.strCodprocedimiento = IIf(cboBusqueda.CodigoTipoProcedimiento Is Nothing, "", cboBusqueda.CodigoTipoProcedimiento)
            Me.strLogin = cboBusqueda.Login
            Me.intEdad = cboBusqueda.EdadPaciente
            Me.strSexo = IIf(cboBusqueda.SexoPaciente Is Nothing, "", cboBusqueda.SexoPaciente)
            Me.ShowDialog()
            dt = dtDatos1 'agfa_orm_in herojas 2014/10/10 
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

        Private Sub opcionelegida_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rb1.CheckedChanged, rb7.CheckedChanged, rb6.CheckedChanged, rb5.CheckedChanged, rb4.CheckedChanged, rb3.CheckedChanged, rb2.CheckedChanged, Rb8.CheckedChanged, rb9.CheckedChanged, rb10.CheckedChanged
            Dim stropcion As String
            Dim ctlOpcion As New RadioButton
            Dim dtfiltra As DataTable = DtProcedim.Clone

            ctlOpcion = sender
            stropcion = ctlOpcion.Text.ToString.ToUpper
            If ctlOpcion.Checked = True Then
                Select Case stropcion
                    Case "CONSULTA MEDICA"
                        dtfiltra = filtrarTabla(DtProcedim, "tip_proced='1'", dtfiltra)
                    Case "TRATAMIENTO MEDICO"
                        dtfiltra = filtrarTabla(DtProcedim, "tip_proced='2'", dtfiltra)
                    Case "PROCEDIMIENTOS QUIRURGICOS"
                        dtfiltra = filtrarTabla(DtProcedim, "tip_proced='3'", dtfiltra)
                    Case "APOYO DIAGNOSTICO"
                        dtfiltra = filtrarTabla(DtProcedim, "tip_proced='4' and origen='genproce'", dtfiltra)
                    Case "APOYO TERAPEUTICO"
                        dtfiltra = filtrarTabla(DtProcedim, "tip_proced='5'", dtfiltra)
                    Case "SERVICIOS CLINICAS Y HOSPITALES"
                        dtfiltra = filtrarTabla(DtProcedim, "tip_proced='6'", dtfiltra)
                    Case "AYUDANTIAS QUIRURGICAS"
                        dtfiltra = filtrarTabla(DtProcedim, "tip_proced='7'", dtfiltra)
                    Case "RADIOLOGIA"
                        dtfiltra = filtrarTabla(DtProcedim, "origen='ris'", dtfiltra)
                    Case "LABORATORIO"
                        dtfiltra = filtrarTabla(DtProcedim, "origen='LABORATORIO'", dtfiltra)

                    Case Else
                        dtfiltra = DtProcedim
                End Select

                dtgBusqueda.DataSource = dtfiltra
            End If

        End Sub


        Public Shared Function filtrarTabla(ByVal dtBase As DataTable, ByVal filtro As String, ByVal dtContenedor As DataTable) As DataTable

            Dim rowsFiltradas() As DataRow

            rowsFiltradas = dtBase.Select(filtro)
            dtContenedor = FuncionesGenerales.copyArrayToDataTable(dtContenedor, rowsFiltradas)
            Return dtContenedor

        End Function


    End Class
End Namespace