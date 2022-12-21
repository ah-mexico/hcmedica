Imports System.Linq
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes.FuncionesGenerales


''' <summary>
''' Esta clase tiene la funcionalidad del control de usuario para los egresos
''' y será usado en la aplicación cliente en Windows Form 2005
''' </summary>
''' <remarks></remarks>
Public Class CtlEgresos

    Private Shared _Instancia As CtlEgresos
    Private objGeneral As Generales
    Private objPaciente As Paciente
    Private strCadenaLocal As String
    Private objEgreso As Egreso
    Private objConexion As HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion = Sophia.HistoriaClinica.DatosConexion.Conexion.Instancia
    Private intAux As Integer
    Private strDatoModificado As String
    Private strISesion As String

#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As CtlEgresos
        Get
            If _Instancia Is Nothing Then
                _Instancia = New CtlEgresos
            End If
            Return _Instancia
        End Get
    End Property
#End Region

    Private Sub FinalizarEgresos()
        AdicionarDatosEgreso()
        'objEgreso.dtDiagnostico = dgLista.DataSource
    End Sub

#Region "Load"

    Private Sub CtlEgresos_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave

        FinalizarEgresos()

        'While dgLista.DataSource.Rows.Count > 0
        '    If dgLista.Rows.Count > 0 Then
        '        dgLista.Rows.RemoveAt(0)
        '        dgLista.DataSource.Rows.Count = dgLista.DataSource.Rows.Count - 1
        '    End If
        'End While
        'If dgLista.Rows.Count > 0 Then
        '    For i = 0 To dgLista.Rows.Count - 1
        '        dgLista.Rows.RemoveAt(0)
        '    Next
        'End If
    End Sub

    ''' <summary>
    ''' Contiene los eventos Necesarios del Cargue del Control Egreso
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub CtlEgresos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        frmHistoriaPrincipal.blnFirstEgresos = False

        objGeneral = Generales.Instancia
        objPaciente = Paciente.Instancia
        objConexion = Conexion.Instancia
        objEgreso = Egreso.Instancia
        strCadenaLocal = objGeneral.CadenaLocal

        DatosIniciales()
        IniciarEgresos()
        'Me.AutoScrollPosition = New Point(0, 0)

        ''Ingresado por Claudia Garay para determinar segun el tipo de admision el acceso a 
        '' los links para incapacidad y recomendaciones al egreso
        '' Solicitado por Enrique Forero
        '' 13 agosto 2009

        If objPaciente.TipoAdmision = "U" Or objPaciente.TipoAdmision = "H" Or objPaciente.TipoAdmision = "A" Then

            LnkIncapacidad.Visible = True
            LnkRec_Egreso.Visible = True

        End If
        Me.ctlDiagnostico.LoadControl()

    End Sub



#End Region

    ''' <summary>
    ''' Cargar los valores iniciales cuando es instanciado nuevamente
    ''' </summary>
    ''' <remarks></remarks>
#Region "CargarValoresIniciales - Load"

    Private Sub IniciarEgresos()
        Dim dtFecha As Date


        dtFecha = FuncionesGenerales.FechaServidor()
        mtFechaInicial.Text = Format(dtFecha, "dd/MM/yyyy HH:mm")

        'If objEgreso.Estado <> "" Then
        'CargarCombos()
        'End If

        'If objEgreso.Estado = "" Then
        strISesion = "N"
        ConsultarValores()
        'ctlDiagnostico.LoadControl()
        'End If
        CargarValoresIniciales()

        mtFechaInicial.Enabled = False

        tbCodDestinoFinal.Focus()
        tbDesDestinoFinal.Focus()

    End Sub

    Private Sub CargarValoresIniciales()


        If objEgreso.EstadoSalida = "2" Then
            rbSalidaMuerto.Checked = True
        Else
            rbSalidaMuerto.Checked = False
        End If
        tbCodMuerte.Text = objEgreso.CausaMuerte
        cbDesMuerte.Focus()
        tbEvolucion.Text = objEgreso.ResumenEvolucion

        tbCodDestinoFinal.Text = objEgreso.DestinoFinal
        tbDesDestinoFinal.Focus()
        tbEvolucion.Focus()

    End Sub
#End Region

    ''' <summary>
    ''' Consulta Valores Inciales de la Historia Clínica y asigna valores 
    ''' en cada uno de los controles y objetos del Formulario
    ''' </summary>
    ''' <remarks></remarks>
#Region "ConsultarValores"
    Private Sub ConsultarValores()
        Dim objBl As New Sophia.HistoriaClinica.BL.BLEgresos

        Dim dtDatosEgreso As New DataTable
        Dim dtDiagnostico As New DataTable
        Dim i As Integer

        Try

            '// Consultar valores iniciales cuando no se cierra la historia \\
            dtDiagnostico = objBl.ConsultarDiagnosticoReingreso(objGeneral.Prestador, objGeneral.Sucursal,
                                    objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                    "E", objGeneral.Login, objConexion)

            dtDatosEgreso = objBl.ConsultarDatoEgresoReingreso(objGeneral.Prestador, objGeneral.Sucursal,
                            objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, objConexion)

        Catch ex As Exception
            MsgBox("Error al consultar datos", MsgBoxStyle.Exclamation)
        End Try
        If dtDatosEgreso.Rows.Count > 0 Then
            'If Not dtDatosEgreso Is Nothing Then
            For i = 0 To dtDatosEgreso.Rows.Count - 1
                ' Select Case dtDatosEgreso.Rows(i).Item("Dato").ToString()
                '// Validadr los datos retornados \\

                ' Case "estado_salida"
                objEgreso.EstadoSalida = dtDatosEgreso.Rows(i).Item("estado_salida").ToString()
                If dtDatosEgreso.Rows(i).Item("estado_salida").ToString() = "2" Then
                    rbSalidaMuerto.Checked = True
                    rbSalidaVivo.Checked = False
                Else
                    rbSalidaVivo.Checked = True
                    rbSalidaMuerto.Checked = False
                End If

                ' Case "causa_muerte"
                objEgreso.CausaMuerte = dtDatosEgreso.Rows(i).Item("causa_muerte").ToString()
                tbCodMuerte.Text = dtDatosEgreso.Rows(i).Item("causa_muerte").ToString()
                ' Case "fec_egreso"
                'PFecha.Enabled = False
                'PFecha.Visible = True
                If dtDatosEgreso.Rows(i).Item("fec_egreso").ToString().Length > 0 Then
                    mtFechaInicial.Text = Format(dtDatosEgreso.Rows(i).Item("fec_egreso"), "dd/MM/yyyy HH:mm")
                End If
                objEgreso.FechaEgreso = dtDatosEgreso.Rows(i).Item("fec_egreso").ToString()
                'Case "hora_egreso"

                'Case "DestinoFinal"
                objEgreso.DestinoFinal = dtDatosEgreso.Rows(i).Item("DestinoFinal").ToString()
                tbCodDestinoFinal.Text = dtDatosEgreso.Rows(i).Item("DestinoFinal").ToString()
                'Case "resumen"
                objEgreso.ResumenEvolucion = dtDatosEgreso.Rows(i).Item("resumen").ToString()
                tbEvolucion.Text = dtDatosEgreso.Rows(i).Item("resumen").ToString()

                'jlalfonso- traer dato post-Egreso
                '2008/
                If dtDatosEgreso.Rows(i).Item("postegreso").ToString() = "S" Then
                    rbPostEgrSi.Checked = True
                    rbPostEgrNo.Checked = False
                ElseIf dtDatosEgreso.Rows(i).Item("postegreso").ToString() = "N" Then ''cpgaray
                    rbPostEgrSi.Checked = False
                    rbPostEgrNo.Checked = True
                Else
                    rbPostEgrSi.Checked = False ''cpgaray No debe marcar ninguno por defecto Septiembre 13 de 2012
                    rbPostEgrNo.Checked = False ''cpgaray
                End If

                ''Claudia Garay Obs Postegreso Acerditacion Noviembre 29 de 2010
                objEgreso.ObsPostEgreso = dtDatosEgreso.Rows(i).Item("obsPostegreso").ToString()

                'End Select
            Next
            ' End If
        Else
            Exit Sub
        End If
    End Sub
#End Region


    ''' <summary>
    ''' Llamado al Método ConsultarDiagnosticoReingreso  de la clase  
    ''' Sophia.HistoriaClinica.BL.BLEgresos y de acuerdo a su estado
    ''' Asgna Valores en cada uno de los controles y objetos de ctlEgreso
    ''' </summary>
    ''' <remarks></remarks>
#Region "CargarValoresReIngreso"
    Private Sub CargarValoresReIngreso()
        Dim objBl As New Sophia.HistoriaClinica.BL.BLEgresos

        Dim dtDatosEgreso As New DataTable
        Dim dtDiagnostico As New DataTable
        Dim i As Integer

        '// Cargar valores iniciales cuando es un Reingreso \\
        dtDiagnostico = objBl.ConsultarDiagnosticoReingreso(objGeneral.Prestador, objGeneral.Sucursal, _
                                objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, _
                                "E", objGeneral.Login, objConexion)

        dtDatosEgreso = objBl.ConsultarDatoEgresoReingreso(objGeneral.Prestador, objGeneral.Sucursal, _
                        objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, objConexion)


        '// Ingresar los valores a la variable Global \\
        objEgreso.Estado = "R" 'porque es Reingreso
        objEgreso.dtDiagnostico = dtDiagnostico

        If dtDatosEgreso.Rows.Count > 0 Then
            'If Not dtDatosEgreso Is Nothing Then
            For i = 0 To dtDatosEgreso.Rows.Count - 1
                'Select Case dtDatosEgreso.Rows(i).Item("Dato").ToString()
                '// Validadr los datos retornados \\

                'Case "estado_salida"
                objEgreso.EstadoSalida = dtDatosEgreso.Rows(i).Item("estado_salida").ToString()
                If dtDatosEgreso.Rows(i).Item("estado_salida").ToString() = "2" Then
                    rbSalidaMuerto.Checked = True
                    rbSalidaVivo.Checked = False
                Else
                    rbSalidaMuerto.Checked = False
                    rbSalidaVivo.Checked = True

                End If

                'rbSalidaVivo.Enabled = False
                'rbSalidaMuerto.Enabled = False

                ' Case "causa_muerte"
                objEgreso.CausaMuerte = dtDatosEgreso.Rows(i).Item("causa_muerte").ToString()
                tbCodMuerte.Text = dtDatosEgreso.Rows(i).Item("causa_muerte").ToString()
                tbCodMuerte.Enabled = False
                cbDesMuerte.Enabled = False
                'Case "fec_egreso"
                'PFecha.Enabled = False
                'PFecha.Visible = True
                If dtDatosEgreso.Rows(i).Item("fec_egreso").ToString().Length > 0 Then
                    mtFechaInicial.Text = Format(dtDatosEgreso.Rows(i).Item("fec_egreso").ToString(), "dd/MM/yyyy HH:mm")
                    objEgreso.FechaEgreso = dtDatosEgreso.Rows(i).Item("fec_egreso").ToString()
                End If
                ' Case "hora_egreso"
                If dtDatosEgreso.Rows(i).Item("hora_egreso").ToString().Length > 0 Then
                    objEgreso.HoraEgreso = CInt(dtDatosEgreso.Rows(i).Item("hora_egreso").ToString())
                End If

                'Case "min_egreso"
                If dtDatosEgreso.Rows(i).Item("min_egreso").ToString().Length > 0 Then
                    objEgreso.MinutoEgreso = CInt(dtDatosEgreso.Rows(i).Item("min_egreso").ToString())
                End If
                'Case "DestinoFinal"
                objEgreso.DestinoFinal = dtDatosEgreso.Rows(i).Item("DestinoFinal").ToString()

                If Len(dtDatosEgreso.Rows(i).Item("DestinoFinal").ToString()) = 0 Then
                    tbCodDestinoFinal.Text = dtDatosEgreso.Rows(i).Item("DestinoFinal").ToString()
                    tbCodDestinoFinal.Enabled = True
                    tbDesDestinoFinal.Enabled = True
                Else
                    tbCodDestinoFinal.Text = dtDatosEgreso.Rows(i).Item("DestinoFinal").ToString()
                    If tbCodDestinoFinal.Text <> "M" Then
                        tbCodDestinoFinal.Enabled = True
                        tbDesDestinoFinal.Enabled = True
                    Else
                        tbCodDestinoFinal.Enabled = False
                        tbDesDestinoFinal.Enabled = False
                    End If
                End If

                ''Claudia Garay Obs Postegreso Acreditacion Noviembre 29 de 2010
                txtObsPostegreso.Text = dtDatosEgreso.Rows(i).Item("obsPostegreso").ToString()

                'Case "resumen"
                objEgreso.ResumenEvolucion = dtDatosEgreso.Rows(i).Item("resumen").ToString()
                If Len(dtDatosEgreso.Rows(i).Item("resumen").ToString()) = 0 Then
                    tbEvolucion.Text = dtDatosEgreso.Rows(i).Item("resumen").ToString()
                    tbEvolucion.Enabled = True
                Else
                    tbEvolucion.Text = dtDatosEgreso.Rows(i).Item("resumen").ToString()

                    If strISesion = "S" Then
                        tbEvolucion.Enabled = True
                    Else
                        tbEvolucion.Enabled = False
                    End If

                End If

                'End Select
            Next
            'End If
        Else
            Exit Sub
        End If
    End Sub
#End Region


    ''' <summary>
    ''' Carga los Controles de tipo ComboBox del Formulario
    ''' </summary>
    ''' <remarks></remarks>
#Region "CargarCombos"
    Private Sub CargarCombos()
        Dim obj As New Sophia.HistoriaClinica.BL.BLEgresos
        Dim objLocal As New Sophia.HistoriaClinica.BL.BLBasicasLocales
        '/// Llenamos los controles para las listas Inciales \\\

        '/ para causa de muerte \
        tbCodMuerte.ControlComboEnlace = cbDesMuerte
        cbDesMuerte.CampoMostrar = "descripcion"
        cbDesMuerte.ControlTextoEnlace = tbCodMuerte
        cbDesMuerte.CampoEnlazado = "codigo"
        cbDesMuerte.CategoriaDatos = CategoriaDatos.Diagnosticos
        cbDesMuerte.Login = objGeneral.Login
        cbDesMuerte.SexoPaciente = objPaciente.Genero
        cbDesMuerte.EdadPaciente = objPaciente.Edad
        cbDesMuerte.CargarDatos()
        cbDesMuerte.CargarButton()


        '/ para el destino final \
        tbDesDestinoFinal.NombreCampoDatos = "Descripcion"
        tbCodDestinoFinal.NombreCampoBusqueda = "EST_FINAL"
        tbCodDestinoFinal.NombreCampoBuscado = "Descripcion"
        tbCodDestinoFinal.ControlTextoEnlace = tbDesDestinoFinal
        tbDesDestinoFinal.ControlTextoEnlace = tbCodDestinoFinal
        'tbDesDestinoFinal.OrigenDeDatos = obj.ConsultarDestinoFinal
        tbDesDestinoFinal.OrigenDeDatos = objLocal.TraerDatosTablasBasicasLocales(strCadenaLocal, "genestfi", "EST_FINAL,descripcion", "")
        tbDesDestinoFinal.CargarDatosDescripcion()

        '/Predefinir Estado de salida vivo\
        'rbSalidaVivo.Checked = True
        tbCodMuerte.Enabled = False
        cbDesMuerte.Enabled = False

        obj = Nothing
        objLocal = Nothing

    End Sub
#End Region

    ''' <summary>
    ''' Carga Combos y Definir Datos Para la grilla
    ''' </summary>
    ''' <remarks></remarks>
#Region "AsignarDatosIniciales-Load"
    Private Sub DatosIniciales()

        CargarCombos()

    End Sub
#End Region






    ''' <summary>
    ''' Habilitar la selección para las causas de la muerte
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
#Region "Estado-Salida - Muerto"
    Private Sub rbSalidaMuerto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSalidaMuerto.CheckedChanged

        '/ habilitar la selección para las causas de< la muerte \
        If rbSalidaMuerto.Checked = True Then
            tbCodDestinoFinal.Text = "M"
            tbDesDestinoFinal.Text = "MUERTE"
            tbCodMuerte.Enabled = True
            cbDesMuerte.Enabled = True
            tbCodDestinoFinal.Enabled = False
            tbDesDestinoFinal.Enabled = False
            tbCodMuerte.Focus()
        Else
            rbSalidaVivo.Checked = True
            tbCodDestinoFinal.Enabled = True
            tbDesDestinoFinal.Enabled = True
        End If
    End Sub
#End Region

    ''' <summary>
    ''' Habilita la Seccion para ingresatr valores de Estado a la Salida
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
#Region "Estado-Salida - Vivo"
    Private Sub rbSalidaVivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSalidaVivo.CheckedChanged
        If rbSalidaVivo.Checked = True Then
            tbCodMuerte.Enabled = False
            cbDesMuerte.Enabled = False
            tbCodDestinoFinal.Text = ""
            tbDesDestinoFinal.Text = ""
            tbCodMuerte.Text = ""
            cbDesMuerte.Text = ""
            rbSalidaMuerto.Checked = False
            tbCodDestinoFinal.Enabled = True
            tbDesDestinoFinal.Enabled = True
            tbEvolucion.Focus()
        Else
            rbSalidaMuerto.Checked = True

        End If
    End Sub
#End Region

    ''' <summary>
    ''' Ejecuta la validacion VerificarDatosGrabar y El Guardar del Egreso
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
#Region "Grabar"
    Private Sub btGrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btGrabar.Click
        Dim objBlEgreso As New Sophia.HistoriaClinica.BL.BLEgresos
        Dim dtDatosEgreso As New DataTable
        Dim dtDiagnosticos As New DataTable
        Dim bError As Boolean = True
        ' Dim intAccion As Integer
        Dim lerror As Long
        Dim ValidaDxPrincipal As Boolean = True

        bError = VerificarDatosGrabar()

        If bError Then
            AdicionarDatosEgreso()

            Try
                ValidaDxPrincipal = Me.ctlDiagnostico.validateUxPrincipalActivo(objEgreso.DestinoFinal)
                If objEgreso.DestinoFinal <> "3" And ValidaDxPrincipal Then 'TRASLADO INTRAHOSPITALARIO
                    ValidaDxPrincipal = Me.ctlDiagnostico.validateUxPrincipal()
                End If
                If ValidaDxPrincipal And Me.ctlDiagnostico.plstDiagnostico.Count > 0 Then

                    For Each oDiagnostico As Diagnostico In Me.ctlDiagnostico.plstDiagnostico.ToList()
                        oDiagnostico.CLASE_DIAG = FuncionesGenerales.EnumDescription(Diagnostico.ClaseDiagnostico.Egreso)
                        oDiagnostico.ANTECEDENTE = "N"
                        oDiagnostico.CONFIDENCIAL = "N"
                        oDiagnostico.LOGIN = objGeneral.Login
                        lerror = oDiagnostico.addDiagnostico(objConexion, lerror, oDiagnostico)
                    Next
                    Me.ctlDiagnostico.LoadControl()
                    Me.ctlDiagnostico.plstDiagNuevos = New List(Of Diagnostico)
                Else
                    Exit Sub
                End If
            Catch ex As Exception
                MsgBox("Se presentó un error guardando los Diagnósticos. " & ex.Message, MsgBoxStyle.Exclamation)
                End Try
            Try
                If ValidaDxPrincipal Then

                    lerror = objBlEgreso.GrabarEgresoDatos(objConexion, objGeneral.Prestador,
                                    objGeneral.Sucursal, objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                                    objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                                    objGeneral.Login, objEgreso.EstadoSalida, objEgreso.CausaMuerte,
                                    objEgreso.DestinoFinal, objEgreso.ResumenEvolucion, objEgreso.FechaEgreso,
                                    objEgreso.HoraEgreso, objEgreso.MinutoEgreso, objGeneral.CodigoEspecialidad, objEgreso.PostEgreso, objEgreso.ObsPostEgreso)

                    '// Ingresar los valores a la variable Global - Antes Verificar que exista \\
                    If lerror = 0 Then
                        'cargar valores a objeto control
                        'objEgreso.Estado = "G"
                        objGeneral.HistoriaClinicaTieneModificaciones = True
                        AdicionarDatosEgreso()

                        'btGrabar.Enabled = False
                        MsgBox("El egreso se grabó correctamente", MsgBoxStyle.Exclamation)
                        If objEgreso.Estado = "R" Then
                            btGrabar.Enabled = False
                        End If
                    Else
                        If objEgreso.Estado = "R" Then
                            objEgreso.Estado = "R"
                        Else
                            objEgreso.Estado = "N"
                        End If
                        btGrabar.Enabled = True
                        MsgBox("El egreso no se grabó, por favor verifique los datos", MsgBoxStyle.Exclamation)
                    End If
                End If

            Catch ex As Exception
                MessageBox.Show("El proceso de grabación del egreso falló por: " & ex.Message, "Historia Clínica", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            End Try
        End If

    End Sub
#End Region

    ''' <summary>
    ''' Adiciona Todos los datos del Egreso y valida el Estado del paciente(1:Vivo, 2:Muerto)
    ''' </summary>
    ''' <remarks></remarks>
#Region "AdicionarDatosEgreso - Para grabar"
    Private Sub AdicionarDatosEgreso()
        '// Para adicionar todos los datos del Egreso \\

        If rbSalidaMuerto.Checked = True Then
            objEgreso.EstadoSalida = "2" 'Estado muerto
        Else
            objEgreso.EstadoSalida = "1" 'Estado Vivo
        End If

        If rbPostEgrSi.Checked = True Then
            objEgreso.PostEgreso = "S"
        Else
            objEgreso.PostEgreso = "N"
        End If
        objEgreso.CausaMuerte = tbCodMuerte.Text
        objEgreso.ResumenEvolucion = tbEvolucion.Text
        objEgreso.DestinoFinal = tbCodDestinoFinal.Text

        'If Trim(mtFechaInicial.Text.Length) = 10 Then
        'objEgreso.FechaEgreso = Trim(mtFechaInicial.Text)
        'Else
        objEgreso.FechaEgreso = ""
        'End If

        'If Trim(tbHora.Text.Length) > 0 Then
        'objEgreso.HoraEgreso = CInt(Trim(tbHora.Text))
        'Else
        objEgreso.HoraEgreso = 0
        'End If

        ' If Trim(tbMinuto.Text.Length) > 0 Then
        'objEgreso.MinutoEgreso = CInt(Trim(tbMinuto.Text))
        'Else
        objEgreso.MinutoEgreso = 0
        objEgreso.ObsPostEgreso = txtObsPostegreso.Text
        ' End If
    End Sub
#End Region

    ''' <summary>
    ''' Validacion del control tbCodDestinoFinal sobre el valor digitado
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
#Region "CodDestinoFinal Muerte"
    Private Sub tbCodDestinoFinal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbCodDestinoFinal.TextChanged
        If tbCodDestinoFinal.Text = "M" Then
            tbCodMuerte.Enabled = True
            cbDesMuerte.Enabled = True
            If tbCodMuerte.Text = "" Or cbDesMuerte.Text = "" Then
                tbCodMuerte.Focus()
                rbSalidaMuerto.Checked = True
                rbSalidaVivo.Checked = False
            Else
                rbSalidaMuerto.Checked = True
                rbSalidaVivo.Checked = False
            End If
        End If
    End Sub
#End Region

    ''' <summary>
    ''' Validación sobre el control tbDesDestinoFinal al ser modificado
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
#Region "DesDestinoFinal Muerte"
    Private Sub tbDesDestinoFinal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbDesDestinoFinal.TextChanged
        If tbCodDestinoFinal.Text = "MUERTE" Then
            tbCodMuerte.Enabled = True
            cbDesMuerte.Enabled = True
            If tbCodMuerte.Text = "" Or cbDesMuerte.Text = "" Then
                tbCodMuerte.Focus()
                rbSalidaMuerto.Checked = True
                rbSalidaVivo.Checked = False
            Else
                rbSalidaMuerto.Checked = True
                rbSalidaVivo.Checked = False
            End If
        End If
    End Sub
#End Region

    ''' <summary>
    ''' Método para validar, Obligatoriedad, Verificar los datos antes de grabar, 
    ''' Verificar los egresos en la grilla que haya una categoría principal,
    ''' Verificar la fecha cuando es contingencia,
    ''' Verificar causa de muerte,
    ''' Verificar si destino final es M -muerte,
    ''' Verificar el destino final
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
#Region "VerificarDatos - Grabar"

    Private Function VerificarDatosGrabar() As Boolean
        '/ Verificar los datos antes de grabar \
        Dim bError As Boolean = True
        Dim objBl As New Sophia.HistoriaClinica.BL.BLEgresos

        '/ Verificar la fecha cuando es contingencia \
        'If objGeneral.Contingencia Then
        If Not IsDate(mtFechaInicial.Text) Or mtFechaInicial.Text = "  /  /" Then
            MsgBox("Debe ingresar la fecha correctamente", MsgBoxStyle.Exclamation)
            mtFechaInicial.Focus()
            bError = False
        End If

        '/ Verificar causa de muerte \
        If bError Then
            If rbSalidaMuerto.Checked = True Then
                If tbCodMuerte.Text = "" Then
                    MsgBox("Por favor seleccione la causa de muerte", MsgBoxStyle.Exclamation)
                    tbCodMuerte.Focus()
                    bError = False
                End If
            End If
        End If
        '/ Verificar si destino final es M -muerte \
        If bError Then
            If tbCodDestinoFinal.Text = "M" Then
                If rbSalidaMuerto.Checked = True And tbCodMuerte.Text <> "" And cbDesMuerte.Text <> "" Then
                    rbSalidaVivo.Checked = False
                Else
                    rbSalidaMuerto.Checked = True
                    tbCodMuerte.Enabled = True
                    cbDesMuerte.Enabled = True
                    MsgBox("Por favor seleccione la causa de muerte", MsgBoxStyle.Exclamation)
                    tbCodMuerte.Focus()
                    bError = False
                End If
            End If
        End If

        '/Verificar el destino final \
        If bError Then
            If tbCodDestinoFinal.Text = "" Then
                MsgBox("Por favor seleccione el destino final", MsgBoxStyle.Exclamation)
                tbCodMuerte.Focus()
                bError = False
            End If
        End If


        ''Verificar la seleccion del seguimiento postegreso
        If bError Then
            If rbPostEgrSi.Checked = False And rbPostEgrNo.Checked = False Then
                MsgBox("Por favor seleccione el Seguimiento Post Egreso", MsgBoxStyle.Exclamation)
                bError = False
            End If
        End If


        'If bError Then
        '    If tbEvolucion.Text.Length = 0 Then
        '        MsgBox("Por favor ingrese el resumen de la evolución", MsgBoxStyle.Exclamation)
        '        tbEvolucion.Focus()
        '        bError = False
        '    End If
        'End If

        '/Verificar el destino final es P o S: Cierra la ventana con el mensaje y redirige la pantalla “Formulación Externa””. \
        If bError Then

            Try
                Dim lerror As Long = objBl.ValidarConciliacionMedicamentos(objGeneral.Prestador, objGeneral.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision, objConexion)

                If (tbCodDestinoFinal.Text = "P" Or tbCodDestinoFinal.Text = "S") And lerror <> 0 Then
                    MsgBox("Debe realizar la conciliación de medicamentos de manejo Externo", MsgBoxStyle.Exclamation)
                    bError = False
                    frmHistoriaPrincipal.PintarOpcionesManejoExterno()
                    frmHistoriaPrincipal.IniciaFormulacionExterna()
                End If
            Catch ex As Exception
                MsgBox("Error al validar conciliación medicamentos ", MsgBoxStyle.Exclamation)
            End Try
        End If

        Return bError
    End Function
#End Region

    ''' <summary>
    ''' Validaciones Necesarias en el codigo para la navegación en los controles del Formulario
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
#Region "Navegacion"

    Private Sub cbAgregar_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        'ckConfidencial.Focus()
    End Sub

    Private Sub cbAgregar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

    Private Sub ckConfidencial_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub ckConfidencial_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) 
        If e.KeyChar = Convert.ToChar(Keys.Return) Then
            SendKeys.Send("{TAB}")
            e.Handled = True
        End If
    End Sub

#End Region

    ''' <summary>
    ''' Método ValidarCamposObligatorios que Valida la obligatoriedad otorgada en tiempo de Diseño
    ''' a el control TextoConFormato
    ''' </summary>
    ''' <param name="ctlContenedor"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
#Region "Funciones Comunes Procesos Egreso"

    Private Function ValidarCamposObligatorios(ByVal ctlContenedor As GroupBox) As Boolean
        Dim ctlControlTexto As TextBoxConFormato
        Dim ctlControlCombo As ComboBusqueda
        Dim intControl As Integer
        Dim blnRespuesta As Boolean

        blnRespuesta = True
        For intControl = 0 To ctlContenedor.Controls.Count - 1
            If TypeOf (ctlContenedor.Controls(intControl)) Is TextBoxConFormato Then
                ctlControlTexto = ctlContenedor.Controls(intControl)
                If ctlControlTexto.Obligatorio = True Then
                    If ctlControlTexto.Text.Trim.Length = 0 Then
                        ctlControlTexto.Focus()
                        blnRespuesta = False
                        Exit For
                    End If
                End If
            Else
                If TypeOf (ctlContenedor.Controls(intControl)) Is ComboBusqueda Then
                    ctlControlCombo = ctlContenedor.Controls(intControl)
                    If ctlControlCombo.Obligatorio = True Then
                        If ctlControlCombo.Text.Trim.Length = 0 Then
                            ctlControlCombo.Focus()
                            blnRespuesta = False
                            Exit For
                        End If
                    End If
                End If
            End If
        Next

        Return blnRespuesta
    End Function

    Public Sub actualizarIncapacidad(ByVal strCodDiagnostico As String, ByVal strDescDiagnostico As String, _
                                    ByVal txtObs As String, ByVal codCategoria As String)
        Dim objIncapacidad As PlanIncapacidad

        If codCategoria.Trim = "P" Then
            objIncapacidad = PlanIncapacidad.Instancia()
            With objIncapacidad
                .CodigoDiagnostico = strCodDiagnostico
                .Diagnostico = strDescDiagnostico
                .Observacion = txtObs
            End With
        End If
    End Sub

#End Region

    Private Sub CtlEgresos_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If sender.Visible = True Then
            LimpiarDatos()
            IniciarEgresos()
            If frmHistoriaPrincipal.blnFirstEgresos = True Then
                frmHistoriaPrincipal.blnFirstEgresos = False
            End If


            ctlDiagnostico.Enabled = True
            ctlDiagnostico.LoadControl()
        Else
            FinalizarEgresos()
        End If
    End Sub

    Private Sub LimpiarDatos()

        mtFechaInicial.ResetText()
        rbSalidaVivo.Checked = False
        rbSalidaMuerto.Checked = False
        tbCodMuerte.ResetText()
        cbDesMuerte.ResetText()
        tbEvolucion.ResetText()
        tbCodDestinoFinal.ResetText()
        tbDesDestinoFinal.ResetText()

    End Sub

    Private Sub LnkRec_Egreso_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkRec_Egreso.LinkClicked
        frmHistoriaPrincipal.PintarOpcionesManejoExterno()
        frmHistoriaPrincipal.IraRecomendaciones()

    End Sub

    Private Sub LnkIncapacidad_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LnkIncapacidad.LinkClicked
        frmHistoriaPrincipal.PintarOpcionesManejoExterno()
        frmHistoriaPrincipal.IniciaIncapacidad()
    End Sub



    Private Sub gbDatosAdicion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbDatosAdicion.Click
        Txtscroll1.Visible = True
        Txtscroll1.Focus()
        Txtscroll1.Visible = False
    End Sub

    Private Sub tbCodDiag_Click(ByVal sender As Object, ByVal e As System.EventArgs) 

    End Sub


    Private Sub rbPostEgrSi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPostEgrSi.CheckedChanged
        If rbPostEgrSi.Checked = True Then
            txtObsPostegreso.Enabled = True
        End If
    End Sub

    Private Sub rbPostEgrNo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPostEgrNo.CheckedChanged
        If rbPostEgrNo.Checked = True Then
            txtObsPostegreso.Enabled = False
        End If
    End Sub
End Class
