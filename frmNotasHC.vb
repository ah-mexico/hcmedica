Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.UI.Escritrio
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes

Imports System.Text.RegularExpressions
Imports System.Collections.Generic
Imports System.Data.Common

Public Class frmNotasHC

    ''' <summary>
    ''' Tabla auxiliar para guardar los datos temporales de los notas parciales de cada admision
    ''' </summary>
    ''' <remarks></remarks>
    Private _dtFechaNota As New DataTable


    ''' <summary>
    ''' Bandera que indica si es una nota nueva o vieja
    ''' </summary>
    ''' <remarks></remarks>
    Private _intadmisionExistente As Integer = 0


    ''' <summary>
    ''' Datos del paciente
    ''' </summary>
    ''' <remarks></remarks>
    Private _paciente As Paciente

    ''' <summary>
    ''' Datos de la conexion
    ''' </summary>
    ''' <remarks></remarks>
    Private _objConexion As conexion


    ''' <summary>
    ''' Estructura interna para enviar datos
    ''' </summary>
    ''' <remarks></remarks>
    Private objdatosNotasAclaratoria As BLNotasAclaratorias.datosNotasAclaratoria

#Region "      Eventos propios de la forma Load, LostFocus"


    Public Sub CargarTiposDocumento()
        Dim objTablasBasicas As New BLBasicasLocales
        Dim strCadenaLocal As String
        '= "Provider=sqloledb;Data Source=etiopia;Initial Catalog=sophiabog;User Id=sophia;Password=sophia;"
        Try
            Dim strDB As String = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion.Instancia.strBaseDatos
            Dim strClaveUsuarioBD As String = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion.Instancia.strClaveUsuarioBD
            Dim strServidor As String = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion.Instancia.strServidor
            Dim strUsuarioBD As String = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion.Instancia.strUsuarioBD

            strCadenaLocal = "Provider=sqloledb;Data Source=" + strServidor + ";Initial Catalog=" + strDB + ";User Id=" + strUsuarioBD + ";Password=" + strClaveUsuarioBD + ";"
            With tbCodigoTipDoc
                .NombreCampoBuscado = "descripcion"
                .NombreCampoBusqueda = "tip_doc"
                .ControlTextoEnlace = tbDescTipDoc
            End With

            With tbDescTipDoc
                .NombreCampoDatos = "descripcion"
                .ControlTextoEnlace = tbCodigoTipDoc
                .OrigenDeDatos = objTablasBasicas.TraerDatosTablasBasicasLocales(strCadenaLocal, "gentipdo", "tip_doc, descripcion", "")
                .CargarDatosDescripcion()
            End With
        Catch ex As Exception
#If DEBUG Then
            MessageBox.Show(ex.Message)
#Else
            MensajeError.Mensaje (10)
#End If
        End Try

    End Sub


    Private Sub frmNotasHC_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargarTiposDocumento()
        _objConexion = Conexion.Instancia
    End Sub

    Private Sub frmNotasHC_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        ' Controla que si la nota aclaratoria no se grabo, se graba automaticamente

    End Sub

#End Region

    Private Sub btnTraerHCNotas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTraerHCNotas.Click
        Dim dt As DataSet
        Dim objHCB As New BLHistoriaBasica
        Dim lError As Long
        Dim Datos() As Object
        Dim dtUnifi As DataTable
        Dim XMLDocumentosUnificados As String

        ReDim Datos(2)
        Datos(0) = Me.txtNumDoc.Text
        Datos(1) = Me.tbCodigoTipDoc.Text
        Datos(2) = Me._paciente.Unificado
        Try

            dtUnifi = objHCB.ConsultarDocumentosUnificados(HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion.Instancia, lError, Datos)
            LimpiarControlesNuevaBusquedaHC()
            If dtUnifi.Rows.Count > 0 Then
                XMLDocumentosUnificados = FuncionesGenerales.GenerarXMLxProcedimiento(dtUnifi)
            Else
                XMLDocumentosUnificados = ""
            End If
            dt = BLNotasAclaratorias.BLTraerHistorias(_paciente.TipoDocumento, _paciente.NumeroDocumento, XMLDocumentosUnificados)

            Me.dtgNotasAclaratorias.DataSource = dt.Tables(0)
        Catch ex As Exception
#If DEBUG Then
            MessageBox.Show(ex.Message)
#Else
            MensajeError.Mensaje (10)
#End If
        End Try

    End Sub

    Private Sub btnBuscarPaciente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarPaciente.Click
        'Dim _paciente As New Paciente
        Dim bPacienteEncontrado As Boolean

        Try
            'Busqueda por documento
            If Len(tbCodigoTipDoc.Text) > 0 And Len(txtNumDoc.Text) > 0 Then
                txtNumDoc.Text = Replace(Replace(Replace(Replace(Replace(Replace(txtNumDoc.Text, "=", "", 1), "OR", ""), "%", "", 1), "&", "", 1), "DELETE", "", 1), "'", "", 1)
                _paciente = New Paciente().buscarDocumento(_objConexion, tbCodigoTipDoc.Text, txtNumDoc.Text)

                If Not New Paciente().PacienteVacio(_paciente) Then

                    If _paciente.Unificado = "U" And Not New Paciente().PacienteVacio(_paciente.PacienteUnificador) Then
                        With _paciente.PacienteUnificador
                            MsgBox("Este documento se ha unificado a el documento " _
                                   & .TipoDocumento & " " & .NumeroDocumento)
                            tbCodigoTipDoc.Text = .TipoDocumento
                            txtNumDoc.Text = .NumeroDocumento
                            txtPrimerNombre.Text = .PrimerNombre
                            txtSegundoNombre.Text = .SegundoNombre
                            txtPrimerApellido.Text = .PrimerApellido
                            txtSegundoApellido.Text = .SegundoApellido
                        End With
                    Else
                        With _paciente
                            txtPrimerNombre.Text = .PrimerNombre
                            txtSegundoNombre.Text = .SegundoNombre
                            txtPrimerApellido.Text = .PrimerApellido
                            txtSegundoApellido.Text = .SegundoApellido
                        End With
                    End If
                Else
                    MsgBox("Registro no existe.", MsgBoxStyle.Information)
                End If
            Else 'Busqueda por Nombre
                If Not String.IsNullOrEmpty(txtPrimerApellido.Text) And _
                   Not String.IsNullOrEmpty(txtPrimerNombre.Text) Then

                    _paciente.PrimerApellido = txtPrimerApellido.Text
                    _paciente.PrimerNombre = txtPrimerNombre.Text
                    bPacienteEncontrado = frmConsultaPorNombre.mostrar(_paciente)

                    If bPacienteEncontrado = True Then
                        '_paciente = objPaciente
                        With _paciente
                            tbCodigoTipDoc.Text = .TipoDocumento
                            txtNumDoc.Text = .NumeroDocumento
                            txtPrimerNombre.Text = .PrimerNombre
                            txtSegundoNombre.Text = .SegundoNombre
                            txtPrimerApellido.Text = .PrimerApellido
                            txtSegundoApellido.Text = .SegundoApellido
                        End With
                    Else
                        MsgBox("Registro no existe.", MsgBoxStyle.Information)
                    End If
                Else
                    MsgBox("Datos incompletos.", MsgBoxStyle.Information)
                End If
            End If

            Me.btnTraerHCNotas.Focus()

        Catch ex As Exception
#If DEBUG Then
            MessageBox.Show(ex.Message)
#Else
            MensajeError.Mensaje(10)
#End If
            'MsgBox("Error en la busqueda del paciente. " & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnGrabarNotas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGrabarNotas.Click

        Try
            btnGrabarNotas.Enabled = False
            BLNotasAclaratorias.BLActualizaNotasAclatorias(objdatosNotasAclaratoria, Me.txtNotaAclaratoria.Text, "", _intadmisionExistente)
            inhabilitarGrabar(True)
        Catch ex As Exception
#If DEBUG Then
            MessageBox.Show(ex.Message)
#Else
            MensajeError.Mensaje(10)
#End If

        End Try

    End Sub


#Region "      Eventos que controlan la grilla de las admisiones del paciente"

    Private Sub dtgNotasAclaratorias_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgNotasAclaratorias.Click

        BuscarFechasNotasAclaratorias()
    End Sub

    Private Sub dtgNotasAclaratorias_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgNotasAclaratorias.DoubleClick
        BuscarFechasNotasAclaratorias()
    End Sub

    Private Sub BuscarFechasNotasAclaratorias()
        Dim ireg As Integer = 0
        Dim i As Integer = 0
        If dtgNotasAclaratorias.Rows.Count > 0 Then
            Me.Cursor = Cursors.WaitCursor
            Try
                LimpiarControlesNuevaBusquedaNotasAclaratorias()


                Dim strCodpresgs As String = dtgNotasAclaratorias.CurrentRow.Cells("Cod_pre_sgs").Value
                Dim strCod_sucur As String = dtgNotasAclaratorias.CurrentRow.Cells("Cod_sucur").Value
                Dim strAno_adm As String = dtgNotasAclaratorias.CurrentRow.Cells("Ano_adm").Value
                Dim strNum_adm As String = dtgNotasAclaratorias.CurrentRow.Cells("Num_adm").Value
                Dim strTipo_adm As String = dtgNotasAclaratorias.CurrentRow.Cells("tip_admision").Value

                objdatosNotasAclaratoria = New BLNotasAclaratorias.datosNotasAclaratoria
                objdatosNotasAclaratoria.Prestadora = strCodpresgs
                objdatosNotasAclaratoria.Sucursal = strCod_sucur
                objdatosNotasAclaratoria.Admision = strNum_adm
                objdatosNotasAclaratoria.TipoAdmision = strTipo_adm
                objdatosNotasAclaratoria.AnnoAdmision = strAno_adm

                _dtFechaNota = BLNotasAclaratorias.BLTraerNotas(objdatosNotasAclaratoria)

                ireg = _dtFechaNota.Rows.Count - 1

                For i = 0 To ireg
                    lstvFechas.Items.Add(_dtFechaNota.Rows(i).Item("hora_nota"))
                Next
                lstvFechas.Items.Add("Nueva Nota")
                inhabilitarGrabar(False)
            Catch ex As Exception
#If DEBUG Then
                MessageBox.Show(ex.Message)
#Else
                MensajeError.Mensaje (10)
#End If
            Finally
                Me.Cursor = Cursors.Default
            End Try

        End If
    End Sub


#End Region


#Region "      Evento del ListView que controla las notas aclaratorias"

    Private Sub lstvFechas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstvFechas.Click
        
        Try
            btnGrabarNotas.Enabled = True
            Dim iIndiceFechas As Integer = lstvFechas.Items.Count - 2
            Dim ireg As Integer = Me._dtFechaNota.Rows.Count - 1
            Dim i As Integer = 0
            For i = 0 To iIndiceFechas

                If Me._dtFechaNota.Rows(i).Item("hora_nota").ToString = lstvFechas.SelectedItems(0).Text Then
                    txtNotaAclaratoria.Text = Me._dtFechaNota.Rows(i).Item("nota")
                    Me.objdatosNotasAclaratoria.HoraNota = Me._dtFechaNota.Rows(i).Item("hora_nota")
                    'Dim ss As String = Me._dtFechaNota.Rows(i).Item("hora_nota")
                    _intadmisionExistente = 1
                    Exit For
                Else
                    _intadmisionExistente = 0
                End If

            Next
            If _intadmisionExistente = 0 Then
                txtNotaAclaratoria.Text = ""
                txtNotaAclaratoria.Focus()
            End If
        Catch ex As Exception
#If DEBUG Then
            MessageBox.Show(ex.Message)
#Else
            MensajeError.Mensaje(10)
#End If
        End Try
    End Sub

#End Region


#Region "      Rutinas para Limpiar Controles"

    Private Sub inhabilitarGrabar(ByVal binhabilitar As Boolean)
        If binhabilitar = True Then
            Me.txtNotaAclaratoria.Enabled = False
            Me.lstvFechas.Enabled = False
        Else
            Me.txtNotaAclaratoria.Enabled = True
            Me.lstvFechas.Enabled = True
        End If
        
    End Sub

    Private Sub LimpiarControlesNuevaBusquedaNotasAclaratorias()
        Me._dtFechaNota = Nothing
        Me.txtNotaAclaratoria.Text = ""
        Me.lstvFechas.Clear()

    End Sub

    Private Sub LimpiarControlesNuevaBusquedaHC()
        Me._dtFechaNota = Nothing
        Me.txtNotaAclaratoria.Text = ""
        Me.lstvFechas.Clear()
        If Not Me.dtgNotasAclaratorias.DataSource Is Nothing Then
            CType(Me.dtgNotasAclaratorias.DataSource, DataTable).Rows.Clear()
        End If

    End Sub
#End Region

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub

  
    Private Sub txtNumDoc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumDoc.TextChanged

    End Sub
End Class