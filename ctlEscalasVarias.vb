Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.Util
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes.FuncionesGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO


Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion

Imports System.Drawing
Public Class ctlEscalasVarias
    Private Shared _Instancia As ctlEscalasVarias
    Private objDao As New DAOGeneral
    Private _Ordenes As OrdenMedica
    Private datosconexion As objCon
    Private General As objGeneral
    Private AGrilla As New ArrayList
    Private strObsMed As String
    Private ControlGrabar As Integer
    Private datosSinAlmacenar As Boolean = False
    Private TipoOrden As String
    Private datosPaciente As Paciente
    Private datosLogin As Generales
    Private objPaciente As Paciente
    Private objConexion As Conexion
    Private iHora As Integer
    Private alarmaRiesgo As ctlDatosPaciente
    'Private Cuidados As CtlPlaneacion
    Private dtRiesgoPuntaje As New DataTable
    Private sumriesgo As Integer
    Private sum1, sum2, sum3, sum4, sum5 As Integer
    Private i As Integer


    Private cont As Integer
    Private cont1 As Integer
    Private cuidadosenfermeria As Boolean = False

    Private _IdEscala As Integer
    Private _dtRiesgo As New DataTable
    Private _DiasSarnatFN As Integer = 0
    Private _dtriesgoTemp2 As New DataTable
#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As ctlEscalasVarias
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlEscalasVarias
            End If
            Return _Instancia
        End Get

    End Property
#End Region
    Private Sub ctlEscalasVarias_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        frmHistoriaPrincipal.blnFirstOrdenesMedicas = False

        datosLogin = Generales.Instancia()
        datosPaciente = Paciente.Instancia()
        datosconexion = Conexion.Instancia()
        _Ordenes = OrdenMedica.Instancia()

        Me.pnlRiesgo.Visible = False


    End Sub

#Region "CargarFecha"
    Private Sub CargarFecha()
        Dim dtFecha As Date

        dtFecha = FuncionesGenerales.FechaServidor()


        mtFechaR.Text = Format(dtFecha, "dd/MM/yyyy") ''cpgaray mostrar las horas reales de registro
        tbHoraR.Text = Hour(dtFecha)
        tbMinutoR.Text = Minute(dtFecha)




        ''cpgaray mostrar las horas reales de registro Septiembre 2013 tk 542766-20130903	

        ''martovar se comentarea y se ocultan los registros 
        'Me.mtFechaReal.Visible = False
        ''Me.tbHoraReal.Visible = False
        ''Me.tbMinutoReal.Visible = False
        'Me.Label47.Visible = False
        'Me.Label48.Visible = False
        'Me.Label49.Visible = False
        ''fin martovar
        CargarFechaRiesgo()


    End Sub
    ''cpgaray mostrar las horas reales de registro

    Private Sub CargarFechaRiesgo()
        Dim dtFecha As Date
        dtFecha = FuncionesGenerales.FechaServidor()

        'mtFechaReal.Text = Format(dtFecha, "dd/MM/yyyy")
        'tbHoraReal.Text = Hour(dtFecha)
        'tbMinutoReal.Text = Minute(dtFecha)

    End Sub

#End Region

#Region "LimpiarDatos"
    Private Sub LimpiarDatos()

        'txtDescripRass.ResetText()
        ChkRiesgo.ResetText()


        'For i As Integer = 0 To ChkRiesgo.Items.Count - 1
        '    ChkRiesgo.SetItemChecked(i, False)
        'Next
        cont = 0
        cont1 = 0
        sumriesgo = 0
        Me.TxtPuntaje2.Text = ""
        Me.TxtRiesgo.Text = ""
        Me.txtResultadoRelaconEP.Text = ""
        Me.txtResultadoEsc2.Text = ""
        Me.pnlEscala2.Visible = False
        Me.pnlEscala4Riss.Visible = False


        For i As Integer = 0 To DataGridView1.RowCount - 1
            Me.DataGridView1.Rows(i).Cells(1).Style.BackColor = Color.White
            Me.DataGridView1.Rows(i).Cells(0).Value = False
        Next

    End Sub
#End Region

#Region "cargarTiposRiesgo"
    Public Sub cargarTiposRiesgo()
        Dim objBl As New Sophia.HistoriaClinica.BL.BLEscalas
        Dim dtRiesgo As New DataTable
        objPaciente = Paciente.Instancia
        General = Generales.Instancia
        dtRiesgo = BLEscalas.consultarTiposRiesgo(datosconexion)
        ChkRiesgo.DataSource = dtRiesgo
        ChkRiesgo.DisplayMember = "desc_tiporiesgo"
        ChkRiesgo.ValueMember = "cod_tiporiesgo"

    End Sub
#End Region

#Region "ConsultarPlantillaEscala"
    Public Sub ConsultarPlantillaEscala(IdEscalaSeleccionada As Int16)
        Dim objBl As New Sophia.HistoriaClinica.BL.BLEscalas
        Dim dtRiesgo As New DataTable
        objPaciente = Paciente.Instancia
        General = Generales.Instancia
        _IdEscala = IdEscalaSeleccionada
        Dim mensaje As String
        Me.pnlRiesgo.Visible = False

        Dim años As Int16 = 0
        Dim fecha As Date = CDate(objPaciente.FechaNacimiento)
        Dim hoy As Date = DateAdd(DateInterval.Day, -1, Now)
        años = DateDiff(DateInterval.Year, fecha, hoy)
        _DiasSarnatFN = DateDiff(DateInterval.Day, fecha, hoy)

        datosLogin = Generales.Instancia()
        datosPaciente = Paciente.Instancia()
        datosconexion = Conexion.Instancia()
        _Ordenes = OrdenMedica.Instancia()

        mensaje = ValidacionAlCargar(_IdEscala)
        If mensaje <> "" Then
            MsgBox(mensaje, MsgBoxStyle.Critical)

            Exit Sub
        End If


        Try

            CargarFecha()
            LimpiarDatos()
            cargarTiposRiesgo()



            If _IdEscala = 2 Then

                Me.Panel3.BackgroundImage = Global.HistoriaClinica.My.Resources.imag_Sarnat
                Me.pnlEscala2.Visible = True
                Me.pnlEscalas.Visible = False
            ElseIf _IdEscala = 5 Then
                Me.Panel3.BackgroundImage = Global.HistoriaClinica.My.Resources.imag_DolorNeonatos
                Me.pnlEscala2.Visible = False
                Me.pnlEscalas.Visible = True

            End If

            dtRiesgo = BLEscalas.ConsultarPlantillaEscala(datosconexion, _IdEscala)
            DataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True
            Me.DataGridView1.DataSource = dtRiesgo

            ValidacionCamposEscala(_IdEscala)

            Me.pnlRiesgo.Visible = True
            ConsultarEscalaHistorico(_IdEscala)

            ConsultarEscalaClasificacionRiesgo()

            Me.TxtPuntaje2.Text = "0"
            Me.TxtRiesgo.BackColor = Color.White

            If _IdEscala = 5 Then 'Valoración Dolor Neonatos 
                DataGridView1.Columns("Proceso").Visible = True
            Else
                DataGridView1.Columns("Proceso").Visible = False
            End If

            Me.pnlRiesgo.Visible = True

        Catch ex As Exception
            MsgBox("Error al cargar la escala: " + ex.Message, MsgBoxStyle.Critical)
        End Try


    End Sub
#End Region

#Region "ConsultarEscalaClasificacionRiesgo"
    Private Sub ConsultarEscalaClasificacionRiesgo()

        Dim objBl As New Sophia.HistoriaClinica.BL.BLEscalas
        Dim dtRiesgo As New DataTable

        Try
            dtRiesgo = objBl.ConsultarEscalaClasificacionRiesgo(datosconexion, _IdEscala)
            _dtRiesgo = dtRiesgo

        Catch ex As Exception
            MsgBox("Error al cargar la clasificación de la escala: " + ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

#End Region

#Region "Calcular Riesgo"
    Private Sub CalcularRiesgo()
        Try
            Me.pnlEscala4Riss.Visible = False

            For i As Integer = 0 To _dtRiesgo.Rows.Count - 1




                If _IdEscala = 2 Then 'Sarnat
                    If _dtRiesgo.Rows(i).Item(1) <= CInt(Me.TxtPuntaje2.Text) And _dtRiesgo.Rows(i).Item(2) >= CInt(Me.TxtPuntaje2.Text) Then
                        txtResultadoEsc2.Text = _dtRiesgo.Rows(i).Item(3)

                        If _dtRiesgo.Rows(i).Item(3) = "Encefalopatía Hipóxico - Isquémica SEVERO" Then
                            Me.txtResultadoEsc2.BackColor = Color.DarkRed
                        End If
                        If _dtRiesgo.Rows(i).Item(3) = "Encefalopatía Hipóxico - Isquémica MODERADA" Then
                            Me.txtResultadoEsc2.BackColor = Color.Orange
                        End If
                        If _dtRiesgo.Rows(i).Item(3) = "Encefalopatía Hipóxico - Isquémica LEVE" Then
                            Me.txtResultadoEsc2.BackColor = Color.Yellow
                        End If

                        If Me.TxtPuntaje2.Text = "0" Then
                            Me.txtResultadoEsc2.BackColor = Color.White
                            Me.txtResultadoEsc2.Text = ""
                        End If
                        Exit Sub
                    End If
                End If



                If _IdEscala = 5 Then 'Valoración Dolor Neonatos 
                    If _dtRiesgo.Rows(i).Item(1) <= CInt(Me.TxtPuntaje2.Text) And _dtRiesgo.Rows(i).Item(2) >= CInt(Me.TxtPuntaje2.Text) Then
                        TxtRiesgo.Text = _dtRiesgo.Rows(i).Item(3)

                        If _dtRiesgo.Rows(i).Item(3) = "Consultar al grupo médico" Then
                            Me.TxtRiesgo.BackColor = Color.DarkRed
                        End If
                        If _dtRiesgo.Rows(i).Item(3) = "Ofrecer Medidas de Confort" Then
                            Me.TxtRiesgo.BackColor = Color.Orange
                        End If
                        If _dtRiesgo.Rows(i).Item(3) = "No Requiere Intervención" Then
                            Me.TxtRiesgo.BackColor = Color.White
                        End If

                        If Me.TxtPuntaje2.Text = "0" Then
                            Me.TxtRiesgo.BackColor = Color.White
                            Me.TxtRiesgo.Text = "No Requiere Intervención"
                        End If
                        Exit Sub
                    End If
                End If



            Next

        Catch ex As Exception
            MsgBox("Error al calcular el riesgo: " + ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub
#End Region


#Region "Validación reglas de negocio antes de cargar la escala"
    Private Function ValidacionAlCargar(IdEscala As Int16) As String
        Dim mensaje As String = ""



        If IdEscala = 2 Then 'Escala Sarnat 
            If _DiasSarnatFN > 60 Then
                mensaje = "La edad del paciente no está en el rango para diligenciar la escala: SARNAT"
            End If
        End If

        If IdEscala = 5 Then ' Escala Valoración Dolor Neonatos 'ER OSI 628

            If _DiasSarnatFN > 60 Then
                mensaje = "La edad del paciente no está en el rango para diligenciar la escala: VALORACIÓN DOLOR NEONATOS"
            End If
        End If



        Return mensaje

    End Function

#End Region

#Region "Validación reglas de negocio despues de cargar la escala"
    Private Sub ValidacionCamposEscala(IdEscala As Int16)

        Dim mensaje As String = ""
        Dim años As Int16 = 0
        Dim fecha As Date = datosPaciente.FechaNacimiento
        Dim hoy As Date = Now

        años = DateDiff(DateInterval.Year, fecha, hoy)


        For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1

            If IdEscala = 1 Then ' Riesgo de Caída en Pediatría - ER OSI 627
                If DataGridView1.Rows(i).Cells(6).Value = 1 Then 'Edad
                    If DataGridView1.Rows(i).Cells(3).Value = "< de 3 años" And (años >= 0 And años <= 3) Then
                        DataGridView1.Rows(i).Cells(0).Value = 1
                    End If
                    If DataGridView1.Rows(i).Cells(3).Value = "3 a 7 años" And (años > 3 And años <= 7) Then
                        DataGridView1.Rows(i).Cells(0).Value = 1
                    End If
                    If DataGridView1.Rows(i).Cells(3).Value = ">7 años a 13 años" And (años > 7 And años < 13) Then
                        DataGridView1.Rows(i).Cells(0).Value = 1
                    End If
                    If DataGridView1.Rows(i).Cells(3).Value = "> a 13 años" And (años > 13) Then
                        DataGridView1.Rows(i).Cells(0).Value = 1
                    End If

                    DataGridView1.Rows(i).Cells(0).ReadOnly = True

                End If


                If DataGridView1.Rows(i).Cells(6).Value = 2 Then 'Genero
                    If DataGridView1.Rows(i).Cells(3).Value = "Hombre" And (datosPaciente.DescripcionGenero = "MASCULINO") Then
                        DataGridView1.Rows(i).Cells(0).Value = 1
                    End If

                    If DataGridView1.Rows(i).Cells(3).Value = "Femenino" And (datosPaciente.DescripcionGenero = "FEMENINO") Then
                        DataGridView1.Rows(i).Cells(0).Value = 1
                    End If

                    If datosPaciente.DescripcionGenero <> "INDETERMINADO" Then 'cuando el genero es indefinido se deben habilitar los checkbox para que el profesional lo seleccione
                        DataGridView1.Rows(i).Cells(0).ReadOnly = True 'con esto se bloque el check
                    End If

                End If
            End If

            If IdEscala = 2 Then 'Escala Sarnat - ER OSI 639
                If DataGridView1.Rows(i).Cells(6).Value = 12 Then
                    If _DiasSarnatFN >= 3 Then 'Otras manifestaciones
                        DataGridView1.Rows(i).Cells(0).ReadOnly = False
                    Else
                        DataGridView1.Rows(i).Cells(0).ReadOnly = True
                    End If

                End If

            End If
        Next






    End Sub

#End Region

#Region "Validación reglas de negocio al momento de diligenciar la escala"
    Private Sub dataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick



        Dim fila As Int16 = e.RowIndex
        Dim temCod As Int32
        Dim mensajeValidacion As String = ""

        Dim TextoValidar As String = ""

        If fila = -1 Then 'para evitar que se genere el error de excepción
            Exit Sub
        End If

        'If (DataGridView1.Rows(fila).Cells(0).Value = 0 Or DataGridView1.Rows(fila).Cells(0).Value = Nothing) And DataGridView1.Rows(fila).Cells(0).ReadOnly = False Then
        '    DataGridView1.Rows(fila).Cells(0).Value = 1
        'End If

        TextoValidar = DataGridView1.Rows(fila).Cells(3).Value.ToString()






        If _IdEscala = 2 Then 'Escala Sarnat - ER OSI 639

            For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1



                If DataGridView1.Rows(i).Cells(6).Value = 8 And DataGridView1.Rows(fila).Cells(6).Value = 8 Then 'Capacidad para despertar - seleccion unica
                    If DataGridView1.Rows(i).Cells(3).Value <> TextoValidar Then
                        DataGridView1.Rows(i).Cells(0).Value = 0
                    End If
                End If

                If DataGridView1.Rows(i).Cells(6).Value = 9 And DataGridView1.Rows(fila).Cells(6).Value = 9 Then 'Tono Muscular - seleccion unica
                    If DataGridView1.Rows(i).Cells(3).Value <> TextoValidar Then
                        DataGridView1.Rows(i).Cells(0).Value = 0
                    End If
                End If

                If DataGridView1.Rows(i).Cells(6).Value = 10 And DataGridView1.Rows(fila).Cells(6).Value = 10 Then 'Respuesta Motora - seleccion unica
                    If DataGridView1.Rows(i).Cells(3).Value <> TextoValidar Then
                        DataGridView1.Rows(i).Cells(0).Value = 0
                    End If
                End If

                If DataGridView1.Rows(i).Cells(6).Value = 11 And DataGridView1.Rows(fila).Cells(6).Value = 11 Then 'Reactividad - seleccion unica
                    If DataGridView1.Rows(i).Cells(3).Value <> TextoValidar Then
                        DataGridView1.Rows(i).Cells(0).Value = 0
                    End If
                End If

                If DataGridView1.Rows(i).Cells(6).Value = 12 And DataGridView1.Rows(fila).Cells(6).Value = 12 And DataGridView1.Rows(fila).Cells(0).Value = 1 Then 'Otras manifestaciones - seleccion unica
                    If DataGridView1.Rows(i).Cells(3).Value <> TextoValidar Then
                        DataGridView1.Rows(i).Cells(0).Value = 0
                    End If
                End If

            Next

        End If



        If _IdEscala = 5 Then 'Escala Valoración Dolor Neonatos  - ER OSI 628
            For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                If DataGridView1.Rows(i).Cells(6).Value = 27 And DataGridView1.Rows(fila).Cells(6).Value = 27 Then 'Edad Gestacional - seleccion unica
                    If DataGridView1.Rows(i).Cells(3).Value <> TextoValidar Then
                        DataGridView1.Rows(i).Cells(0).Value = 0
                    End If
                End If

                If DataGridView1.Rows(i).Cells(6).Value = 28 And DataGridView1.Rows(fila).Cells(6).Value = 28 Then 'Actividad - seleccion unica
                    If DataGridView1.Rows(i).Cells(3).Value <> TextoValidar Then
                        DataGridView1.Rows(i).Cells(0).Value = 0
                    End If
                End If

                If DataGridView1.Rows(i).Cells(6).Value = 29 And DataGridView1.Rows(fila).Cells(6).Value = 29 Then 'Aumento frecuencia cardiaca - seleccion unica
                    If DataGridView1.Rows(i).Cells(3).Value <> TextoValidar Then
                        DataGridView1.Rows(i).Cells(0).Value = 0
                    End If
                End If

                If DataGridView1.Rows(i).Cells(6).Value = 30 And DataGridView1.Rows(fila).Cells(6).Value = 30 Then 'Sat O2 min - seleccion unica
                    If DataGridView1.Rows(i).Cells(3).Value <> TextoValidar Then
                        DataGridView1.Rows(i).Cells(0).Value = 0
                    End If
                End If

                If DataGridView1.Rows(i).Cells(6).Value = 31 And DataGridView1.Rows(fila).Cells(6).Value = 31 Then 'Entrecejo Fruncido - seleccion unica
                    If DataGridView1.Rows(i).Cells(3).Value <> TextoValidar Then
                        DataGridView1.Rows(i).Cells(0).Value = 0
                    End If
                End If

                If DataGridView1.Rows(i).Cells(6).Value = 32 And DataGridView1.Rows(fila).Cells(6).Value = 32 Then 'Ojos apretados - seleccion unica
                    If DataGridView1.Rows(i).Cells(3).Value <> TextoValidar Then
                        DataGridView1.Rows(i).Cells(0).Value = 0
                    End If
                End If

                If DataGridView1.Rows(i).Cells(6).Value = 33 And DataGridView1.Rows(fila).Cells(6).Value = 33 Then 'Surco Nasolabial- seleccion unica
                    If DataGridView1.Rows(i).Cells(3).Value <> TextoValidar Then
                        DataGridView1.Rows(i).Cells(0).Value = 0
                    End If
                End If
            Next
        End If


        If _IdEscala = 6 Then 'Escala Riesgo de Caída  - ER_OSI 614
            For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1

                If DataGridView1.Rows(i).Cells(6).Value = 34 And DataGridView1.Rows(fila).Cells(6).Value = 34 Then 'Caídas Previas - seleccion unica
                    If DataGridView1.Rows(i).Cells(3).Value <> TextoValidar Then
                        DataGridView1.Rows(i).Cells(0).Value = 0
                    End If
                End If
                If DataGridView1.Rows(i).Cells(6).Value = 37 And DataGridView1.Rows(fila).Cells(6).Value = 37 Then 'Estado Mental - seleccion unica
                    If DataGridView1.Rows(i).Cells(3).Value <> TextoValidar Then
                        DataGridView1.Rows(i).Cells(0).Value = 0
                    End If
                End If
                If DataGridView1.Rows(i).Cells(6).Value = 38 And DataGridView1.Rows(fila).Cells(6).Value = 38 Then 'Deambulación - seleccion unica
                    If DataGridView1.Rows(i).Cells(3).Value <> TextoValidar Then
                        DataGridView1.Rows(i).Cells(0).Value = 0
                    End If
                End If

                If DataGridView1.Rows(i).Cells(6).Value = 35 And DataGridView1.Rows(fila).Cells(6).Value = 35 Then 'Medicamentos - seleccion unica
                    If TextoValidar = "Ninguno" And DataGridView1.Rows(i).Cells(0).Value = 1 Then 'Ninguno seleción multiple o unica
                        If TextoValidar <> DataGridView1.Rows(i).Cells(3).Value Then ' aqui bloqueo las otras preguntas
                            DataGridView1.Rows(i).Cells(0).ReadOnly = True
                            DataGridView1.Rows(i).Cells(0).Value = 0
                        End If
                    End If

                    If TextoValidar = "Ninguno" And DataGridView1.Rows(i).Cells(0).Value = 0 Then
                        If TextoValidar <> DataGridView1.Rows(i).Cells(3).Value Then
                            DataGridView1.Rows(i).Cells(0).ReadOnly = False
                        End If
                    End If
                    If TextoValidar <> DataGridView1.Rows(i).Cells(3).Value And DataGridView1.Rows(i).Cells(0).Value = 1 Then 'cuando marcan una opcion <> a ninguno de ese grupo
                        If "Ninguno" = DataGridView1.Rows(i).Cells(3).Value Then
                            DataGridView1.Rows(i).Cells(0).ReadOnly = True
                            DataGridView1.Rows(i).Cells(0).Value = 0
                        End If
                    End If

                    If TextoValidar <> DataGridView1.Rows(i).Cells(3).Value And DataGridView1.Rows(i).Cells(0).Value = 0 Then 'cuando marcan una opcion <> a ninguno de ese grupo
                        If "Ninguno" = DataGridView1.Rows(i).Cells(3).Value Then
                            DataGridView1.Rows(i).Cells(0).ReadOnly = False
                        End If
                    End If

                End If

                If DataGridView1.Rows(i).Cells(6).Value = 36 And DataGridView1.Rows(fila).Cells(6).Value = 36 Then 'Déficit Sensorial - seleccion unica
                    If TextoValidar = "Ninguno" And DataGridView1.Rows(i).Cells(0).Value = 1 Then 'Ninguno seleción multiple o unica
                        If TextoValidar <> DataGridView1.Rows(i).Cells(3).Value Then ' aqui bloqueo las otras preguntas
                            DataGridView1.Rows(i).Cells(0).ReadOnly = True
                            DataGridView1.Rows(i).Cells(0).Value = 0
                        End If
                    End If

                    If TextoValidar = "Ninguno" And DataGridView1.Rows(i).Cells(0).Value = 0 Then
                        If TextoValidar <> DataGridView1.Rows(i).Cells(3).Value Then
                            DataGridView1.Rows(i).Cells(0).ReadOnly = False
                        End If
                    End If
                    If TextoValidar <> DataGridView1.Rows(i).Cells(3).Value And DataGridView1.Rows(i).Cells(0).Value = 1 Then 'cuando marcan una opcion <> a ninguno de ese grupo
                        If "Ninguno" = DataGridView1.Rows(i).Cells(3).Value Then
                            DataGridView1.Rows(i).Cells(0).ReadOnly = True
                            DataGridView1.Rows(i).Cells(0).Value = 0
                        End If
                    End If

                    If TextoValidar <> DataGridView1.Rows(i).Cells(3).Value And DataGridView1.Rows(i).Cells(0).Value = 0 Then 'cuando marcan una opcion <> a ninguno de ese grupo
                        If "Ninguno" = DataGridView1.Rows(i).Cells(3).Value Then
                            DataGridView1.Rows(i).Cells(0).ReadOnly = False
                        End If
                    End If
                End If



            Next
        End If


        'con esta rutina calculo el valor
        If DataGridView1.Rows(i).Cells(0).Value = 1 Then
            Dim parametro As Int16
            parametro = DataGridView1.Rows(i).Cells(6).Value

            For x As Integer = 0 To DataGridView1.RowCount - 1
                If DataGridView1.Rows(x).Cells(6).Value = parametro Then
                    Me.DataGridView1.Rows(x).Cells(2).Style.BackColor = Color.White
                End If

            Next
        End If

        mensajeValidacion = ValidarEscalaDiligenciada()

    End Sub
#End Region

#Region "Eventos del DataGridView1"
    Private Sub DataGridView1_CellFormatting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting

        'Celda donde actualmente se encuentra el puntero del ratón

        Dim cell As DataGridViewCell = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex)

        If _IdEscala <> 5 Then
            If DataGridView1.Columns(e.ColumnIndex).Name = "categoria" Then
                cell.ToolTipText = DataGridView1.Rows(e.RowIndex).Cells(2).Value
            End If
        Else
            If DataGridView1.Columns(e.ColumnIndex).Name = "proceso" Then
                cell.ToolTipText = DataGridView1.Rows(e.RowIndex).Cells(2).Value
            End If
        End If

    End Sub

    Private Sub DataGridView1_CellPainting(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles DataGridView1.CellPainting

        If _IdEscala <> 5 Then
            If e.ColumnIndex <> 2 Then Exit Sub

            'Only the Serial Number column

            'Is the value of the next row the same
            If e.RowIndex + 1 < DataGridView1.Rows.Count Then
                If e.Value = DataGridView1.Rows(e.RowIndex + 1).Cells(e.ColumnIndex).Value And e.ColumnIndex <> 0 Then
                    e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None
                End If
            End If

            'Is the previous column cell value the same
            If e.RowIndex >= 1 Then
                If e.Value = DataGridView1.Rows(e.RowIndex - 1).Cells(e.ColumnIndex).Value And e.ColumnIndex <> 0 Then
                    e.Graphics.FillRectangle(New SolidBrush(e.CellStyle.BackColor), e.CellBounds)
                    e.PaintBackground(e.CellBounds, False)
                    e.Handled = True
                End If
            End If
        End If

        If _IdEscala = 5 Then
            If e.ColumnIndex <> 1 And e.ColumnIndex <> 2 Then Exit Sub

            'Only the Serial Number column

            'Is the value of the next row the same
            If e.RowIndex + 1 < DataGridView1.Rows.Count Then
                If e.Value = DataGridView1.Rows(e.RowIndex + 1).Cells(e.ColumnIndex).Value And e.ColumnIndex <> 0 Then
                    e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None
                End If
            End If

            'Is the previous column cell value the same
            If e.RowIndex >= 1 Then
                If e.Value = DataGridView1.Rows(e.RowIndex - 1).Cells(e.ColumnIndex).Value And e.ColumnIndex <> 0 Then
                    e.Graphics.FillRectangle(New SolidBrush(e.CellStyle.BackColor), e.CellBounds)
                    e.PaintBackground(e.CellBounds, False)
                    e.Handled = True
                End If
            End If
        End If

    End Sub

    Private Sub DataGridView1_CurrentCellDirtyStateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.CurrentCellDirtyStateChanged
        If DataGridView1.IsCurrentCellDirty Then
            DataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DataGridView1_ColumnAdded(sender As Object, e As DataGridViewColumnEventArgs) Handles DataGridView1.ColumnAdded
        e.Column.SortMode = DataGridViewColumnSortMode.NotSortable
    End Sub
#End Region

#Region "Eventos del historico dtgRiesgoD"
    Private Sub dtgRiesgoD_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dtgRiesgoD.CellFormatting

        Dim cell As DataGridViewCell = dtgRiesgoD.Rows(e.RowIndex).Cells(e.ColumnIndex)

        If dtgRiesgoD.Columns(e.ColumnIndex).Name = "Puntaje" Then
            cell.ToolTipText = dtgRiesgoD.Rows(e.RowIndex).Cells("descripcion").Value
        End If
        If _IdEscala = 2 Then 'Escala Sarnat
            If dtgRiesgoD.Columns(8).Visible Then
                cell.ToolTipText = dtgRiesgoD.Rows(e.RowIndex).Cells("descripcion").Value
            End If
        End If
    End Sub
#End Region


#Region "cargarGrillaRiesgo"
    Public Sub ConsultarEscalaHistorico(idescala As Int16)
        Dim objBl As New Sophia.HistoriaClinica.BL.BLEscalas
        Dim dtRiesgoD As New DataTable
        objPaciente = Paciente.Instancia
        General = Generales.Instancia
        'dtRiesgoD = objBl.ConsultarRiesgo(objPaciente.CodHistoria, datosconexion)
        dtRiesgoD = objBl.ConsultarEscalaHistorico(datosconexion, idescala, objPaciente.CodHistoria)

        If objPaciente.Edad >= 65 Then
            For i As Integer = 0 To dtRiesgoD.Rows.Count - 1
                dtRiesgoD.Rows(i).Item("valorriesgo") = dtRiesgoD.Rows(i).Item("valorriesgo") + 1
                If dtRiesgoD.Rows(i).Item("valorriesgo") >= 3 Then
                    dtRiesgoD.Rows(i).Item("riesgo") = "Alto Riesgo"
                End If
                If dtRiesgoD.Rows(i).Item("valorriesgo") = 1 Or dtRiesgoD.Rows(i).Item("valorriesgo") = 2 Then
                    dtRiesgoD.Rows(i).Item("riesgo") = "Bajo Riesgo"
                End If
                If dtRiesgoD.Rows(i).Item("valorriesgo") = 0 Then
                    dtRiesgoD.Rows(i).Item("riesgo") = "Sin Riesgo"
                End If
            Next
        End If
        dtgRiesgoD.DataSource = dtRiesgoD
        FormatoGrillaHistorico()

    End Sub
#End Region

#Region "cargarGrillaRiesgoFormato"
    Private Sub FormatoGrillaHistorico()

        dtgRiesgoD.Columns(9).Visible = False 'solo para la escala 4 Relación Enfermera/Paciente

        If _IdEscala = 2 Then 'Escala Sarnat
            dtgRiesgoD.Columns(7).Visible = False
            dtgRiesgoD.Columns(8).HeaderText = "Interpretación de la gravedad"
        Else
            dtgRiesgoD.Columns(7).Visible = True
            dtgRiesgoD.Columns(8).HeaderText = "Riesgo"
        End If

        If _IdEscala = 4 Then 'Escala TISS 28
            dtgRiesgoD.Columns(9).Visible = True
            dtgRiesgoD.Columns(8).HeaderText = "Clasificación"
        End If

        If _IdEscala = 5 Then 'Escala Sarnat
            dtgRiesgoD.Columns(8).HeaderText = "Interpretación"
        End If


    End Sub
#End Region

#Region "Guardar Escala"
    Private Sub cmdGuardarRiesgo_Click(sender As Object, e As EventArgs) Handles cmdGuardarRiesgo.Click
        Dim dtRiesgoD As DataTable
        Dim mensaje As String = ""
        Dim HorasMinimo As Int32 = 0
        datosconexion = objCon.Instancia
        General = objGeneral.Instancia

        Dim objBlEcalas As New Sophia.HistoriaClinica.BL.BLEscalas

        If IsNothing(dtgRiesgoD) Then
            Exit Sub
        End If

        dtRiesgoD = dtgRiesgoD.DataSource
        If dtRiesgoD Is Nothing Then
            Exit Sub
        End If

        If tbHoraR.Text = "" Then
            MsgBox("Digite el camopo Hora.", MsgBoxStyle.Information)
            tbHoraR.Focus()
            Exit Sub
        Else
            If tbMinutoR.Text = "" Then
                MsgBox("Digite el campo Minuto.", MsgBoxStyle.Information)
                tbMinutoR.Focus()
                Exit Sub
            End If
        End If

        If Not IsDate(mtFechaR.Text) Then
            MsgBox("Fecha invalida, ingrésela nuevamente por favor.", MsgBoxStyle.Information)
            mtFechaR.Focus()
            Exit Sub
        End If

        If CInt(tbHoraR.Text) > 23 Then
            MsgBox("Error en la Hora, fuera del rango permitido.", MsgBoxStyle.Information)
            tbHoraR.Focus()
            Exit Sub
        End If

        If CInt(tbMinutoR.Text) > 59 Then
            MsgBox("Error en los minutos, fuera del rango permitido", MsgBoxStyle.Information)
            tbMinutoR.Focus()
            Exit Sub
        End If

        HorasMinimo = objBlEcalas.consultarHoraDif(datosconexion, _IdEscala)

        If Not BLFechas.validarFecMenor(datosconexion, mtFechaR.Text, tbHoraR.Text, tbMinutoR.Text, mensaje) Then
            If mensaje = "Fecha Inferior a el límite Permitidos  de " Then
                MsgBox(mensaje & Str(HorasMinimo) & " Horas.", MsgBoxStyle.Information)
                Exit Sub
            End If
            MsgBox(mensaje, MsgBoxStyle.Information)
            mtFechaR.Focus()
            Exit Sub
        End If


        If (Hour(FuncionesGenerales.FechaServidor()) - Hour(CDate(mtFechaR.Text + " " + CStr(tbHoraR.Text) + ":" + CStr(tbMinutoR.Text)))) >= HorasMinimo Then
            MsgBox("Fecha Inferior a el límite Permitidos  de " & Str(HorasMinimo) & " Horas.", MsgBoxStyle.Information)
            mtFechaR.Focus()
            Exit Sub
        Else
            AlmacenarRiesgo()
            CargarFecha()
            CargarFechaRiesgo() ''cpgaray mostrar las horas reales de registro Septiembre 2013 tk 542766-20130903
        End If
    End Sub
#End Region


#Region "AlmacenarRiesgo"
    Private Sub AlmacenarRiesgo()

        Dim lError As Long
        Dim indexChecked As Integer
        Dim dtriesgo As New DataTable
        Dim dtriesgoTemp As New DataTable
        Dim intHoraR As Integer
        Dim intMinutoR As Integer
        Dim strFechaR As String = ""
        Dim strErrorR As String = ""
        Dim bErrorR As Boolean = True
        Dim contador As Integer = 0
        Dim contador1 As Integer = 0
        Dim contador2 As Integer = 0
        Dim contador3 As Integer = 0
        Dim contador4 As Integer = 0
        Dim mensaje As String = String.Empty
        Dim valor As Integer
        Dim mensajeValidacion As String = ""



        Dim objBl As New Sophia.HistoriaClinica.BL.BLEscalas

        If Me.TxtPuntaje2.Text = "" Then
            Me.TxtPuntaje2.Text = 0
        End If

        valor = Me.TxtPuntaje2.Text

        'dtriesgo = BLEscalas.consultarTiposRiesgoVal(datosconexion)
        dtriesgo = BLEscalas.ConsultarEscalaPuntaje(datosconexion, _IdEscala)
        dtriesgoTemp = dtriesgo.Clone

        mensajeValidacion = ValidarEscalaDiligenciada()

        If mensajeValidacion <> "" Then
            MsgBox(mensajeValidacion, MsgBoxStyle.Information)
            Exit Sub
        End If


        For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1
            If DataGridView1.Rows(i).Cells(0).Value = 1 Then

                Dim newRow As DataRow = dtriesgoTemp.NewRow()

                newRow(0) = DataGridView1.Rows(i).Cells(5).Value
                newRow(1) = DataGridView1.Rows(i).Cells(4).Value
                newRow(2) = DataGridView1.Rows(i).Cells(4).Value
                dtriesgoTemp.Rows.Add(newRow)

            End If
        Next

        '  dtriesgoTemp = BLEscalas.filtrarTablaEsc(dtriesgo, "valor=1", dtriesgoTemp)

        If bErrorR Then
            intHoraR = tbHoraR.Text
            intMinutoR = tbMinutoR.Text
            strFechaR = mtFechaR.Text

            If MessageBox.Show("Una vez el dato sea guardado no podra ser modificado,desea continuar con la transaccion?", "Historia Clinica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                datosconexion = objCon.Instancia
                General = objGeneral.Instancia

                'objBl.GrabarEscalaRiesgo
                lError = objBl.GrabarEscala(datosconexion, objPaciente.CodHistoria,
                            dtriesgoTemp, CDate(mtFechaR.Text & " " & tbHoraR.Text & ":" & tbMinutoR.Text), intHoraR, intMinutoR, General.Login, _IdEscala)
                'lError = objBl.GrabarEscalaRiesgo(datosconexion, objPaciente.CodHistoria, _
                '            dtriesgoTemp, strFechaR, intHoraR, intMinutoR, General.Login)

                If lError <> 0 Then
                    MsgBox("Error en el proceso de grabación", MsgBoxStyle.Information)
                Else
                    ' MsgBox("Grabación Exitosa.", MsgBoxStyle.Information)
                    datosSinAlmacenar = False
                    ConsultarEscalaHistorico(_IdEscala)
                    alarmaRiesgo = ctlDatosPaciente.Instancia
                    alarmaRiesgo.PrenderAlarmasPac()

                    'limpia la plantilla de la escala para empesar de nuevo
                    For i As Integer = 0 To DataGridView1.RowCount - 1
                        Me.DataGridView1.Rows(i).Cells(1).Style.BackColor = Color.White
                        Me.DataGridView1.Rows(i).Cells(0).Value = False
                    Next

                    GuardarCuidados() ' valida si se debe guardar cuidados para la escala

                    valor = Me.TxtPuntaje2.Text

                    Me.TxtPuntaje2.Text = ""
                    Me.TxtRiesgo.Text = ""
                    Me.TxtRiesgo.BackColor = Color.White
                    Me.txtResultadoEsc2.Text = ""
                    Me.txtResultadoEsc2.BackColor = Color.White

                    Me.cmdGuardarRiesgo.Visible = True
                    Me.sumriesgo = 0
                    ConsultarPlantillaEscala(_IdEscala)



                End If

            End If
        End If

    End Sub
#End Region

#Region "GuardarCuidados"
    Private Sub GuardarCuidados()

        Dim dtDatos As New DataTable
        Dim dtCuidados As New DataTable
        Dim dtCuidadosPac As New DataTable
        Dim drNew As DataRow
        Dim resultado() As DataRow
        Dim lError As Long

        Dim valor As Int16 = Me.TxtPuntaje2.Text

        Dim _Escala As String = dtgRiesgoD.Rows(0).Cells("Escala").Value

        If (_IdEscala = 6 And valor >= 3) Or (_IdEscala = 1 And valor >= 12) Then ''Riesgo Alto

            dtCuidados = BLPlaneacion.consultarCuidadosRiesgoCaida(datosconexion)
            ' dtCuidados = BLPlaneacion.CONSULTARCUIDADOSESCALAS(datosconexion, _IdEscala)

            dtDatos.Columns.Add("cod_historia", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("cod_cuidado", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("login", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("descripcion", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("estado", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("obs", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("consecutivo", System.Type.GetType("System.String"))
            dtDatos.Columns.Add("fec_con", System.Type.GetType("System.String"))

            If dtCuidados.Rows.Count > 0 Then

                '  If _IdEscala = 1 Or _IdEscala = 6 Then



                For i As Integer = 0 To dtCuidados.Rows.Count - 1

                        dtCuidadosPac = BLPlaneacion.consultarCuidadosPaciente(datosconexion, objPaciente.CodHistoria)
                        'CREA LA NUEVA FILA

                        drNew = dtDatos.NewRow

                        drNew("cod_historia") = objPaciente.CodHistoria
                        drNew("cod_cuidado") = dtCuidados.Rows(i).Item("codigo")
                        '        drNew("cod_cuidado") = txtCodigo.Text
                        drNew("login") = General.Login
                        drNew("descripcion") = dtCuidados.Rows(i).Item("descripcion")
                        drNew("estado") = "I"
                        drNew("obs") = _Escala '"Riesgo caida"
                        drNew("fec_con") = mtFechaR.Text

                        resultado = dtCuidadosPac.Select("cod_cuidado = '" & drNew("cod_cuidado") & "'")
                        If resultado.Length = 0 Then
                            dtDatos.Rows.Add(drNew)
                        End If

                    Next

                ' If valor > 0 Then
                lError = BLPlaneacion.GuardarCuidados(datosconexion, dtDatos, 0)

                If lError <> 0 Then
                    MsgBox("Error en el proceso de Grabación", MsgBoxStyle.Information, "Cuidados de Enfermeria")
                End If
                ' End If

            End If

        End If
    End Sub


#End Region

#Region "Validaciones de la escla diligenciada"
    Private Function ValidarEscalaDiligenciada() As String


        Dim dtriesgo As DataTable
        Dim filaAnterior As Int16 = 0
        Dim filaActual As Int16 = 0
        Dim parametro As Boolean = False
        Dim puntaje As Int32 = 0
        Dim puntajeEsc2 As Int32 = 0

        dtriesgo = BLEscalas.ConsultarEscalaPuntaje(datosconexion, _IdEscala)
        _dtriesgoTemp2 = dtriesgo.Clone

        'creo tabla temporal, la recorro tomo el parametro unico y valido si esta marcado
        Dim x As Int16 = 0
        Dim y As Boolean = False
        ' Dim z As Boolean = False
        For i As Integer = 0 To Me.DataGridView1.Rows.Count - 1

            Dim newRow2 As DataRow = _dtriesgoTemp2.NewRow()
            filaActual = DataGridView1.Rows(i).Cells(6).Value
            filaAnterior = DataGridView1.Rows(x).Cells(6).Value

            If y = False Then 'la primera vez
                newRow2(0) = filaActual
                y = True
                For j As Integer = 0 To DataGridView1.Rows.Count - 1 'recorre la grilla de los campos con check
                    If filaActual = DataGridView1.Rows(j).Cells(6).Value And DataGridView1.Rows(j).Cells(0).Value = 1 Then
                        newRow2(1) = 1
                        newRow2(2) = 1
                        Exit For
                    End If
                    If filaActual = DataGridView1.Rows(j).Cells(6).Value And DataGridView1.Rows(j).Cells(0).Value = 0 Then
                        newRow2(1) = 0
                        newRow2(2) = 0
                    End If
                Next

                _dtriesgoTemp2.Rows.Add(newRow2) 'se adiciona la fila

            ElseIf filaActual <> filaAnterior Then


                newRow2(0) = filaActual

                For j As Integer = 0 To DataGridView1.Rows.Count - 1 'recorre la grilla de los campos con check
                    If filaActual = DataGridView1.Rows(j).Cells(6).Value And DataGridView1.Rows(j).Cells(0).Value = 1 Then
                        newRow2(1) = 1
                        newRow2(2) = 1
                        Exit For
                    End If

                    If filaActual = DataGridView1.Rows(j).Cells(6).Value And DataGridView1.Rows(j).Cells(0).Value = 0 Then
                        newRow2(1) = 0
                        newRow2(2) = 0
                    End If
                Next
                _dtriesgoTemp2.Rows.Add(newRow2)
            End If

            If i = 0 Then ' por primera vez
                x = 0
            Else
                x = i
            End If

            filaActual = 0
            filaAnterior = 0


        Next


        If _IdEscala = 2 And _DiasSarnatFN < 3 Then 'borro el registro que por logica de negocio en este caso no se diligencia
            _dtriesgoTemp2.Rows(4).Delete()
        End If

        Dim vandera As String = ""

        For Renglones As Integer = 0 To _dtriesgoTemp2.Rows.Count - 1
            For Renglones2 As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                Try

                    If _dtriesgoTemp2.Rows(Renglones).Item(0) = DataGridView1.Rows(Renglones2).Cells(6).Value And _dtriesgoTemp2.Rows(Renglones).Item(1) = 0 Then
                        Me.DataGridView1.Rows(Renglones2).Cells(2).Style.BackColor = Color.DodgerBlue
                        vandera = "Categorias evaluadas incompletas"
                    End If
                    If _dtriesgoTemp2.Rows(Renglones).Item(0) = DataGridView1.Rows(Renglones2).Cells(6).Value And _dtriesgoTemp2.Rows(Renglones).Item(1) = 1 Then
                        Me.DataGridView1.Rows(Renglones2).Cells(2).Style.BackColor = Color.White
                    End If
                Catch ex As Exception
                    vandera = "Error al calcular los items: " + ex.Message
                End Try


            Next
        Next

        If vandera = "" Then
            For Renglones2 As Integer = 0 To Me.DataGridView1.Rows.Count - 1
                If DataGridView1.Rows(Renglones2).Cells(0).Value = 1 Then
                    puntaje = puntaje + DataGridView1.Rows(Renglones2).Cells(4).Value
                    If _IdEscala = 2 Then 'este caso es solo para esta escala de acuerdo al requerimiento
                        If DataGridView1.Rows(Renglones2).Cells(4).Value > puntajeEsc2 Then ' se deja el puntaje mas alto de los que seleccionaron
                            puntajeEsc2 = DataGridView1.Rows(Renglones2).Cells(4).Value
                        End If
                    End If
                End If
            Next

            If _IdEscala = 2 Then 'este caso es solo para esta escala de acuerdo al requerimiento
                Me.TxtPuntaje2.Text = puntajeEsc2
            Else
                Me.TxtPuntaje2.Text = puntaje
            End If

            CalcularRiesgo()
        Else
            Me.TxtPuntaje2.Text = 0
            Me.TxtRiesgo.BackColor = Color.White
            Me.txtResultadoEsc2.Text = 0
            Me.txtResultadoEsc2.BackColor = Color.White
            Me.TxtRiesgo.Text = ""
        End If

        Return vandera

    End Function
#End Region


#Region "Impresión"
    Private Sub btImprimirRiesgo_Click(sender As Object, e As EventArgs) Handles btImprimirRiesgo.Click
        'ImprimirEscalasEnfermeria

        Try
            'Riesgo de Caída en Pediatría
            If _IdEscala = 1 Then
                '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
                'Juan Carlos Jaramillo Lozano - IG
                RptHC_Enf_Med.Show()
                RptHC_Enf_Med.ImprimirHistoriaClinica(datosconexion, "|RepEnfEscalas|", "13", Date.Now, Date.Now, Nothing, Nothing, _IdEscala, Date.Now)
                '2019-03-11 Fin
            End If

            'Sarnat
            If _IdEscala = 2 Then
                '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
                'Juan Carlos Jaramillo Lozano - IG
                RptHC_Enf_Med.Show()
                RptHC_Enf_Med.ImprimirHistoriaClinica(datosconexion, "|RepEnfEscalas|", "45", Date.Now, Date.Now, Nothing, Nothing, _IdEscala, Date.Now)
                '2019-03-11 Fin
            End If

            'Riesgo Lesión de Piel
            If _IdEscala = 3 Then

                '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
                'Juan Carlos Jaramillo Lozano - IG
                RptHC_Enf_Med.Show()
                RptHC_Enf_Med.ImprimirHistoriaClinica(datosconexion, "|RepEnfEscalas|", "14", Date.Now, Date.Now, Nothing, Nothing, _IdEscala, Date.Now)
                '2019-03-11 Fin
            End If

            'TISS 28
            If _IdEscala = 4 Then
                '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
                'Juan Carlos Jaramillo Lozano - IG
                RptHC_Enf_Med.Show()
                RptHC_Enf_Med.ImprimirHistoriaClinica(datosconexion, "|RepEnfEscalas|", "16", Date.Now, Date.Now, Nothing, Nothing, _IdEscala, Date.Now)
                '2019-03-11 Fin
            End If

            'Valoración Dolor Neonatos
            If _IdEscala = 5 Then
                '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
                'Juan Carlos Jaramillo Lozano - IG
                RptHC_Enf_Med.Show()
                RptHC_Enf_Med.ImprimirHistoriaClinica(datosconexion, "|RepEnfEscalas|", "46", Date.Now, Date.Now, Nothing, Nothing, _IdEscala, Date.Now)
                '2019-03-11 Fin
            End If

            'Riesgo de Caída
            If _IdEscala = 6 Then
                '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
                'Juan Carlos Jaramillo Lozano - IG
                RptHC_Enf_Med.Show()
                RptHC_Enf_Med.ImprimirHistoriaClinica(datosconexion, "|RepEnfEscalas|", "12", Date.Now, Date.Now, Nothing, Nothing, _IdEscala, Date.Now)
                '2019-03-11 Fin
            End If

            'RptHC.ImprimirEscalasEnfermeria(datosconexion, General.Prestador,
            '                                 General.Sucursal, objPaciente.TipoAdmision,
            '                                 objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
            '                                 IIf(String.IsNullOrEmpty(objPaciente.TipoDocumento), datosPaciente.TipoDocumento, objPaciente.TipoDocumento),
            '                                 IIf(String.IsNullOrEmpty(objPaciente.NumeroDocumento), datosPaciente.NumeroDocumento, objPaciente.NumeroDocumento),
            '                                 datosLogin.NombreMedico, _IdEscala,
            '                                 Now, Now)


            'RptHC.ShowDialog()
            'RptHC.Close()
        Catch ex As Exception
            MsgBox("Error al imprimir el reporte :" + " " + ex.Message, MsgBoxStyle.Critical)
        End Try


    End Sub
#End Region


End Class
