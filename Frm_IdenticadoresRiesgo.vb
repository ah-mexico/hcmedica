Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes.FuncionesGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales




Public Class Frm_IdenticadoresRiesgo
    Private alarmaRiesgo As ctlDatosPaciente

    Private objConexion As Conexion
    Private datosPaciente As Paciente
    Private txtLogin As String
    Private txtNombre As String
    Private txtEspecialidad As String
    Private txtTipoUsuario As String
    Private txtIdEspecialidad As String
    Private IdHistoria As Int64
    Private _dtFactoresRiesgo As DataTable
    Private _resultado As DataTable
    Dim _Registro As Int64
    Private _IDIdentificadorRiesgo As Int32
    Private _tipousuarioregistro As String




    Private Sub Frm_IdenticadoresRiesgo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.dgIdenticadores.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            Me.dgIdenticadores.Columns(0).Width = 120
            Me.dgIdenticadores.Columns(1).Width = 160
            Me.dgIdenticadores.Columns(2).Width = 200
            Me.dgIdenticadores.Columns(3).Width = 120
            Me.dgIdenticadores.Columns(4).Width = 60
            Me.dgIdenticadores.Columns(5).Width = 60

            datosPaciente = Paciente.Instancia()

            txtLogin = objGeneral.Instancia.Login
            txtNombre = objGeneral.Instancia.NombreMedico
            txtTipoUsuario = objGeneral.Instancia.TipoUsuario


            IdHistoria = CInt(datosPaciente.CodHistoria)

            CargaCombo()
            ConsultarHistoricos()

            If objGeneral.Instancia.CodigoEspecialidad = "" Then
                txtIdEspecialidad = 0
            Else
                txtIdEspecialidad = objGeneral.Instancia.CodigoEspecialidad
            End If




        Catch ex As Exception
            MsgBox("Error al cargar el formulario Identificador de Riesgo: " + ex.Message, MsgBoxStyle.Critical)
        End Try


    End Sub
    Public Sub Mostrar()

        Me.ShowDialog()

    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    ''' <summary>
    ''' Evento donde carga el combobox de tipo de factores
    ''' </summary>
    Private Sub CargaCombo()
        Dim Resultado As DataTable
        Try
            Resultado = BLFactoresRiesgo.consultarTiposFactoresRiesgo(objConexion)

            If txtTipoUsuario <> "M" Then '' REQ 634 e.     Nutricional. Esta opción No debe mostrarse para el usuario “Otros” Enfermería. raucruz 20190211
                For i As Integer = 0 To Resultado.Rows.Count - 1
                    Dim dr As DataRow = Resultado.Rows(i)
                    If dr("ID") = "6" Then dr.Delete()
                Next
                Resultado.AcceptChanges()
            End If

            ddl_IdentRiesgo.DataSource = Resultado
            ddl_IdentRiesgo.DisplayMember = "DESCRIPCION"
            ddl_IdentRiesgo.ValueMember = "ID"
            ddl_IdentRiesgo.Text = ""
            ddl_IdentRiesgo.EndUpdate()
            ddl_IdentRiesgo.SelectedValue = 0
        Catch ex As Exception
            MsgBox("Error al consultar los tipos factor de riesgo: " + ex.Message, MsgBoxStyle.Critical)
        End Try


    End Sub
    ''' <summary>
    ''' Evento para consultar el historico de factores de riesgo de la IdHistoria en especifico
    ''' </summary>
    Private Sub ConsultarHistoricos()
        Try
            Dim objBl As New Sophia.HistoriaClinica.BL.BLFactoresRiesgo


            _resultado = objBl.GrabarActivaciónfactor(objConexion, _resultado, IdHistoria, 2)

            dgIdenticadores.DataSource = _resultado

            ValidadorColumnas()

        Catch ex As Exception
            MsgBox("error al consultar el hístorico factor de riesgo : " + ex.Message, MsgBoxStyle.Information)
        End Try

    End Sub
    ''' <summary>
    ''' Evento del cargue de registros factor de riesgos a la grilla
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnAgragar_Click(sender As Object, e As EventArgs) Handles btnAgragar.Click

        Dim repetido As Int16 = 0

        Dim años As Int16
        Dim fecha As Date = CDate(datosPaciente.FechaNacimiento)


        If datosPaciente.CodigoUnidadMedidaEdad = "A" Then
            años = datosPaciente.Edad
        Else
            años = 0
        End If


        ' los tipo de usuarios M con especialidad Nutricion clinica pueden inactivar el idenficador NUTRICIONAL
        If txtTipoUsuario <> "M" And ddl_IdentRiesgo.SelectedValue = 6 Then
            MsgBox("No tiene permisos para Activar el identificador NUTRICIONAL. ", MsgBoxStyle.Information)
            Me.ddl_IdentRiesgo.SelectedValue = 0
            Me.txtObservaciones.Text = ""
            Exit Sub
        End If

        Dim Permiso As Boolean
        Permiso = BLFactoresRiesgo.ConsultaPermisosEspecialidad(objConexion, objGeneral.Instancia.CodigoEspecialidad)

        If txtTipoUsuario = "M" And ddl_IdentRiesgo.SelectedValue <> 6 And Permiso = True Then
            ' solo la especialidad 450 esta autorizada para activar/desactivar

            MsgBox("Solo tiene permisos para Activar el identificador NUTRICIONAL. ", MsgBoxStyle.Information)
            Me.ddl_IdentRiesgo.SelectedValue = 0
            Me.txtObservaciones.Text = ""
            Exit Sub

        End If

        If txtTipoUsuario = "M" And ddl_IdentRiesgo.SelectedValue = 6 And Permiso = False Then
            MsgBox("No tiene permisos para Activar el identificador  NUTRICIONAL. ", MsgBoxStyle.Information)
            Me.ddl_IdentRiesgo.SelectedValue = 0
            Me.txtObservaciones.Text = ""
            Exit Sub
        End If



        If Me.ddl_IdentRiesgo.SelectedValue = 0 Then

            MsgBox("No ha diligenciado el identificador del riesgo : ", MsgBoxStyle.Exclamation)
            Me.ddl_IdentRiesgo.Focus()
            Exit Sub
        End If

        For i As Integer = 0 To Me.dgIdenticadores.Rows.Count - 1

            If CInt(dgIdenticadores.Rows(i).Cells(6).Value) = Me.ddl_IdentRiesgo.SelectedValue And CInt(dgIdenticadores.Rows(i).Cells(6).Value) = 2 Then 'ANTIGOAGULADO
                repetido = 1
            End If
            If CInt(dgIdenticadores.Rows(i).Cells(6).Value) = Me.ddl_IdentRiesgo.SelectedValue And CInt(dgIdenticadores.Rows(i).Cells(6).Value) = 5 Then 'FUGA
                repetido = 1
            End If
            If CInt(dgIdenticadores.Rows(i).Cells(6).Value) = Me.ddl_IdentRiesgo.SelectedValue And CInt(dgIdenticadores.Rows(i).Cells(6).Value) = 6 Then 'NUTRICIONAL
                repetido = 1
            End If
        Next

        If repetido = 1 Then
            MsgBox("Identificador de riesgo ya se encuentra en la grilla: ", MsgBoxStyle.Exclamation)
            Me.ddl_IdentRiesgo.Focus()
            Me.txtObservaciones.Text = Nothing
            Exit Sub
        End If


        If Me.txtObservaciones.Text = "" And (ddl_IdentRiesgo.SelectedValue = 1 Or ddl_IdentRiesgo.SelectedValue = 4) Then
            MsgBox("No ha diligenciado la observación  del riesgo, este es obligatorio para el identificador del riesgo seleccionado. ", MsgBoxStyle.Exclamation)
            Me.txtObservaciones.Focus()
            Exit Sub
        End If


        Dim txtObserbaciones As String = ""
        Dim Identificador As String = ""
        Identificador = DirectCast(ddl_IdentRiesgo.SelectedItem, System.Data.DataRowView).Row.ItemArray(1).ToString

        txtObserbaciones = Me.txtObservaciones.Text

        Try
            Dim filadt As DataRow = _resultado.NewRow
            filadt(0) = Identificador
            filadt(1) = txtObserbaciones
            filadt(2) = txtNombre
            filadt(3) = txtEspecialidad
            filadt(4) = ddl_IdentRiesgo.SelectedValue
            filadt(5) = 0
            filadt(6) = txtTipoUsuario
            filadt(7) = txtIdEspecialidad
            filadt(8) = IdHistoria
            filadt(9) = 0
            filadt(10) = 0
            filadt(11) = txtLogin

            _resultado.Rows.Add(filadt)

            dgIdenticadores.DataSource = _resultado

            ValidadorColumnas()
            Me.ddl_IdentRiesgo.SelectedValue = 0
            Me.txtObservaciones.Text = ""
        Catch ex As Exception
            MsgBox("error al cargar el registro a la grilla : " + ex.Message, MsgBoxStyle.Information)
        End Try



    End Sub
    ''' <summary>
    ''' Evento donde inactivan el checkbox de la columna inactivar
    ''' </summary>
    Private Sub ValidadorColumnas()

        Dim Repetidos As Integer = 0
        Dim nombreauxiliar As String = ""
        Dim comodin As String = ""
        Dim NumeroEnLetras As String = Nothing

        Try

            For i As Integer = 0 To Me.dgIdenticadores.Rows.Count - 1

                If CInt(dgIdenticadores.Rows(i).Cells(7).Value) = 0 And dgIdenticadores.Rows(i).Cells(3).Value <> "" Then
                    dgIdenticadores.Rows(i).Cells(0).ReadOnly = True
                    Me.dgIdenticadores.Rows(i).Cells(2).Style.BackColor = Color.CadetBlue
                    Me.dgIdenticadores.Rows(i).Cells(3).Style.BackColor = Color.CadetBlue
                    Me.dgIdenticadores.Rows(i).Cells(4).Style.BackColor = Color.CadetBlue
                    Me.dgIdenticadores.Rows(i).Cells(5).Style.BackColor = Color.CadetBlue
                    Me.dgIdenticadores.Rows(i).Cells(6).Style.BackColor = Color.CadetBlue
                End If
            Next


        Catch ex As Exception
            MsgBox("error validador ulceras en la grilla : " + ex.Message, MsgBoxStyle.Information)
        End Try


    End Sub
    ''' <summary>
    ''' evento donde se pasa la grilla de factores de riesgo a una tabla
    ''' </summary>
    Public Sub PasarATabla()
        Try
            _dtFactoresRiesgo = New DataTable

            If dgIdenticadores.RowCount > 0 Then

                Dim dt As New DataTable()

                For Each col As DataGridViewColumn In dgIdenticadores.Columns
                    Dim column As New DataColumn(col.Name, Type.GetType("System.String"))
                    dt.Columns.Add(column)
                Next
                For Each viewRow As DataGridViewRow In dgIdenticadores.Rows
                    Dim row As DataRow = dt.NewRow()

                    For Each col As DataGridViewColumn In dgIdenticadores.Columns

                        Dim value As Object = viewRow.Cells(col.Name).Value
                        row.Item(col.Name) = If(value Is Nothing, DBNull.Value, value)

                    Next col        ' Siguiente columna

                    If row.ItemArray(1).ToString <> "" Then
                        dt.Rows.Add(row)
                    End If



                Next viewRow ' Siguiente fila

                With dt.Columns 'remuevo las filas que no necesito pasar
                    .Remove("IdentRiesgo")
                    .Remove("Usuario")
                    .Remove("Especialidad")
                    .Remove("Desactivar")
                    .Remove("eliminar")
                    .Remove("IdEstado")
                End With


                _dtFactoresRiesgo = dt
            End If
        Catch ex As Exception
            MsgBox("error al ejecutar el metodo 'PasarATabla' : " + ex.Message, MsgBoxStyle.Information)
        End Try



    End Sub
    ''' <summary>
    ''' Evento del guardado  de factores de riego
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Try
            Dim objBl As New Sophia.HistoriaClinica.BL.BLFactoresRiesgo

            _resultado = objBl.GrabarActivaciónfactor(objConexion, _resultado, IdHistoria, 1)

            dgIdenticadores.DataSource = _resultado

            ValidadorColumnas()

            Alarmas()

        Catch ex As Exception
            MsgBox("error al grabar factor de riesgo : " + ex.Message, MsgBoxStyle.Information)
        End Try



    End Sub
    ''' <summary>
    ''' Eventos de inactivar y eliminar registro
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub dgIdenticadores_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgIdenticadores.CellContentClick

        Dim colum As Int16 = e.ColumnIndex
        Dim fila As Int16 = e.RowIndex
        Dim tipousuarioregistro As String = ""

        _IDIdentificadorRiesgo = 0
        _tipousuarioregistro = ""

        Dim row As DataGridViewRow = dgIdenticadores.CurrentRow

        Try
            tipousuarioregistro = row.Cells("IdTipoUsuario").Value
            _IDIdentificadorRiesgo = row.Cells(6).Value
            _tipousuarioregistro = row.Cells("IdTipoUsuario").Value


            If txtTipoUsuario <> tipousuarioregistro And _IDIdentificadorRiesgo = 1 Then
                MsgBox("No tiene permisos para desactivar el identificador de ALERGIA. ", MsgBoxStyle.Information)
                ConsultarHistoricos()
                Exit Sub
            End If

            'If txtTipoUsuario = "O" And _IDIdentificadorRiesgo = 1 Then 'Alergias solo la puede inactivar el medico
            '    MsgBox("No tiene permisos para desactivar el identificador. ", MsgBoxStyle.Information)
            '    ConsultarHistoricos()
            '    Exit Sub
            'End If

            ''Solo los tipo de usuarios M pueden incativar registros de tipo usuario O y no a la inversa como esta acontinuación

            'If tipousuarioregistro = "M" And txtTipoUsuario = "O" And colum = 0 Then
            '    MsgBox("No tiene permisos para desactivar el identificador. ", MsgBoxStyle.Information)
            '    ConsultarHistoricos()
            '    Exit Sub
            'End If

            ' los tipo de usuarios M con especialidad Nutricion clinica pueden inactivar el idenficador NUTRICIONAL
            If txtTipoUsuario <> "M" And colum = 0 And _IDIdentificadorRiesgo = 6 Then
                Dim Permiso As Boolean
                Permiso = BLFactoresRiesgo.ConsultaPermisosEspecialidad(objConexion, objGeneral.Instancia.CodigoEspecialidad)
                If Permiso = False Then
                    MsgBox("No tiene permisos para desactivar el identificador NUTRICIONAL. ", MsgBoxStyle.Information)
                    ConsultarHistoricos()
                    Exit Sub
                End If

            End If

            ' los tipo de usuarios M con especialidad Nutricion clinica pueden inactivar el idenficador NUTRICIONAL
            If txtTipoUsuario = "M" And colum = 0 And _IDIdentificadorRiesgo = 6 Then
                Dim Permiso As Boolean
                Permiso = BLFactoresRiesgo.ConsultaPermisosEspecialidad(objConexion, objGeneral.Instancia.CodigoEspecialidad)

                If Permiso = False Then
                    MsgBox("No tiene permisos para desactivar el identificador NUTRICIONAL. ", MsgBoxStyle.Information)
                    ConsultarHistoricos()
                    Exit Sub
                End If


            End If


            ' los tipo de usuarios M con especialidad Nutricion clinica NO pueden inactivar idenficador <> NUTRICIONAL
            If txtTipoUsuario = "M" And colum = 0 And _IDIdentificadorRiesgo <> 6 Then
                Dim Permiso As Boolean
                Permiso = BLFactoresRiesgo.ConsultaPermisosEspecialidad(objConexion, objGeneral.Instancia.CodigoEspecialidad)

                If Permiso = True Then
                    MsgBox("No tiene permisos para desactivar el identificador. ", MsgBoxStyle.Information)
                    ConsultarHistoricos()
                    Exit Sub
                End If
            End If


            If colum = 1 And row.Cells(0).ReadOnly = True Then 'elimino la fila
                Dim EliminaFila As DataGridViewRow = Me.dgIdenticadores.CurrentRow()
                dgIdenticadores.Rows.Remove(EliminaFila)
                Exit Sub
            End If

            If colum = 1 And row.Cells(0).ReadOnly = False Then 'elimino la fila
                MsgBox("No se puede eliminar un registro que ya fue guardado. ", MsgBoxStyle.Information)
                Exit Sub
            End If


            If colum = 0 And row.Cells(0).ReadOnly = False Then
                _Registro = 0
                _Registro = row.Cells("irIdRegistro").Value

                pnlInactivacion.Visible = True
                pnlIdenRiesgo.Enabled = False

            End If


        Catch ex As Exception

        End Try


        '3.3.	REGLAS GENERALES DE LA FUNCIONALIDAD DE IDENTIFICADORES DE RIESGO
        '3.	Si el tipo de usuario “otros” va a desactivar un identificador activado por el tipo de usuario “médico”, al marcar “DESACT”, el sistema debe generar la alerta “No tiene permisos para desactivar el identificador" y no permitir continuar.



        'recorro la grilla y dejo solo activa la que marque
        'For i As Integer = 0 To Me.dgIdenticadores.Rows.Count - 1
        'Next

    End Sub
    ''' <summary>
    ''' Evento de cancelacion del proceso de inactivación
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnCancelarInac_Click(sender As Object, e As EventArgs) Handles btnCancelarInac.Click
        Me.pnlIdenRiesgo.Enabled = True
        Me.pnlInactivacion.Visible = False

        For i As Integer = 0 To Me.dgIdenticadores.Rows.Count - 1
            dgIdenticadores.Rows(i).Cells(0).Value = False
        Next


    End Sub
    ''' <summary>
    ''' Evento para inactivar un factor de riesgo
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnGuardarInac_Click(sender As Object, e As EventArgs) Handles btnGuardarInac.Click

        If Me.txtJustificación.Text = "" Then
            MsgBox("Debe ingresar la justificación para continuar.", MsgBoxStyle.Information)
            Me.txtJustificación.Focus()
            Exit Sub
        End If

        If txtTipoUsuario <> _tipousuarioregistro And _IDIdentificadorRiesgo = 1 Then
            MsgBox("No tiene permisos para desactivar el identificador de ALERGIA. ", MsgBoxStyle.Information)
            _IDIdentificadorRiesgo = 0
            Me.txtJustificación.Text = ""

            Me.txtJustificación.Text = ""
            pnlInactivacion.Visible = False
            pnlIdenRiesgo.Enabled = True

            For i As Integer = 0 To Me.dgIdenticadores.Rows.Count - 1
                dgIdenticadores.Rows(i).Cells(0).Value = False
            Next
            Exit Sub
        End If

        If MessageBox.Show("¿Está seguro de Desactivar este Identificador de Riesgo?", "Hístoria Clínica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then

            Me.txtJustificación.Text = ""
            pnlInactivacion.Visible = False
            pnlIdenRiesgo.Enabled = True

            For i As Integer = 0 To Me.dgIdenticadores.Rows.Count - 1
                dgIdenticadores.Rows(i).Cells(0).Value = False
            Next

            Exit Sub
        End If

        Try
            Dim objBl As New Sophia.HistoriaClinica.BL.BLFactoresRiesgo
            Dim resultado As Int64 = 0

            resultado = objBl.InactivarfactorRiesgo(objConexion, _Registro, IdHistoria, Me.txtJustificación.Text, txtLogin, txtTipoUsuario, objGeneral.Instancia.CodigoEspecialidad)

            ConsultarHistoricos()
            Alarmas()

            pnlInactivacion.Visible = False
            pnlIdenRiesgo.Enabled = True
            Me.txtJustificación.Text = ""

        Catch ex As Exception
            MsgBox("error al grabar la inactivación del  factor de riesgo : " + ex.Message, MsgBoxStyle.Information)
        End Try
    End Sub

    ''' <summary>
    ''' Evento que dispara el recalculo de los factores de riesgo
    ''' </summary>
    Private Sub Alarmas()

        alarmaRiesgo = ctlDatosPaciente.Instancia
        alarmaRiesgo.PrenderAlarmasPac()
    End Sub
    'Private Sub ddl_IdentRiesgo_SelectedValueChanged(sender As Object, e As EventArgs) Handles ddl_IdentRiesgo.SelectedValueChanged
    '    If _BanderaObservaciones = 0 Then
    '        If Me.txtObservaciones.Text = "" And (ddl_IdentRiesgo.SelectedValue = 1 Or ddl_IdentRiesgo.SelectedValue = 4) Then
    '            Me.lblObservaciones.Text = "Observaciones     *"
    '        End If
    '    End If
    'End Sub

    Private Sub ddl_IdentRiesgo_LostFocus(sender As Object, e As EventArgs) Handles ddl_IdentRiesgo.LostFocus
        If (ddl_IdentRiesgo.SelectedValue = 1 Or ddl_IdentRiesgo.SelectedValue = 4) Then
            Me.lbl_observaciones1.Visible = True
        Else
            Me.lbl_observaciones1.Visible = False
        End If
    End Sub
End Class