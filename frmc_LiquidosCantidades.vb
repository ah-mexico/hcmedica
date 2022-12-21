Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports System.ComponentModel

Public Class frmc_LiquidosCantidades

    Private Shared _Instancia As frmc_LiquidosCantidades
    Private datosconexion As objCon
    Private General As objGeneral
    Private Paciente As objPaciente
    Private m_liquido As String = String.Empty
    Private m_horaliq As String = String.Empty
    Private m_ConseEnc As String = String.Empty
    Private m_Nroorden As String = String.Empty
    Private m_Lateralidad As String = String.Empty
    Private m_tipo As String = String.Empty
    Private m_secuencia As Integer
    Private m_NombreLiquido As String = String.Empty
    Private m_fechaInsert As String = String.Empty
    Private m_perdidas As Boolean = False

#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As frmc_LiquidosCantidades
        Get
            If _Instancia Is Nothing Then
                _Instancia = New frmc_LiquidosCantidades
            End If
            Return _Instancia
        End Get

    End Property
#End Region


    Private Sub cmdGuardarAlarma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGuardarAlarma.Click

        If m_tipo = "LA" Then
            GuardarLiquidoAdministrado()
        ElseIf m_tipo = "LE" Then
            GuardarLiquidoEliminado()
        End If
    End Sub

    ''Se modifica metodo de guardado de liquidos eliminados - dsanchez 15/08/2017
    Private Sub GuardarLiquidoEliminado()
        Dim lError As Long
        Dim strObs As String = String.Empty
        Dim seleccionado As Boolean = False
        If txtCantidad1.Text = String.Empty Or txtCantidad1.Text = "    ." Then
            MessageBox.Show("No existen datos por almacenar.", "Liquidos Eliminados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        If chkListBoxCar.Enabled = True Then

            For i As Integer = 0 To chkListBoxCar.Items.Count - 1

                If chkListBoxCar.GetItemChecked(i) = True Then

                    seleccionado = True
                    Exit For

                End If

            Next

            For i As Integer = 0 To chkListBoxCar.Items.Count - 1

                If chkListBoxCar.GetItemChecked(i) = True Then

                    strObs = strObs + chkListBoxCar.Items(i).ToString() + ","

                End If

            Next
            If strObs <> String.Empty Then

                strObs = strObs.Substring(0, strObs.Length() - 1)

            End If

        End If

        If chkmas.Checked = True Then
            strObs = strObs + " +"
        End If

        If chkmenos.Checked = True Then
            strObs = "-"
        End If

        If chkmas.Checked = False And chkmenos.Checked = False Then

            strObs = strObs

        End If

        If m_perdidas = True Then

            strObs = txtobs.Text

        End If

        If MessageBox.Show("Una vez los datos sean guardados no podrán ser modificados. Desea continuar con la transacción?", "Monitoreos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Try
                lError = BLPlaneacion.GuardarMonitoreoLiquidosElim(datosconexion, Paciente.CodHistoria, m_liquido, m_Nroorden, m_Lateralidad, strObs, CDbl(txtCantidad1.Text), General.Login, m_tipo, m_horaliq, m_fechaInsert)
                If lError = 0 Then
                    txtCantidad1.Text = String.Empty
                    txtobs.Text = String.Empty
                    Me.Close()
                End If

            Catch ex As Exception
                MsgBox("Error al almanenar monitoreo " & ex.Message, MsgBoxStyle.Information)
            End Try

        Else
            Exit Sub
        End If
    End Sub

    ''Se crea meotdo para guardar liquidos administrados - dsanchez 24/08/2017
    Private Sub GuardarLiquidoAdministrado()
        Dim lError As Long
        If txtCantidad1.Text = String.Empty Or txtCantidad1.Text = "    ." Then
            MessageBox.Show("No existen datos por almacenar.", "Liquidos Administrados", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If
        If MessageBox.Show("Una vez los datos sean guardados no podrán ser modificados. Desea continuar con la transacción?", "Monitoreos", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK Then
            Try
                lError = BLPlaneacion.GuardarMonitoreoLiquidos(datosconexion, Paciente.CodHistoria, m_NombreLiquido, m_horaliq, txtCantidad1.Text, General.Login, m_secuencia, m_tipo, txtobs.Text, m_fechaInsert)
                If lError = 0 Then
                    txtCantidad1.Text = String.Empty
                    txtobs.Text = String.Empty
                    Me.Close()
                End If

            Catch ex As Exception
                MsgBox("Error al almanenar monitoreo " & ex.Message, MsgBoxStyle.Information)
            End Try

        Else
            Exit Sub
        End If
    End Sub

    Private Sub frmc_LiquidosCantidades_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        datosconexion = objCon.Instancia
        General = objGeneral.Instancia
        Paciente = objPaciente.Instancia
        Me.txtCantidad.Visible = False
        txtCantidad1.Focus()

    End Sub

    ''Se modifica metodo de mostrar - dsanchez 10/08/2017
    Public Sub Mostrar(ByVal nombreLiquido As String, ByVal hora As String, ByVal consecutivoenc As String, ByVal secuencia As Integer, ByVal tipo As String, ByVal fechaInsert As String)
        Me.txtCantidad1.Text = ""
        Me.txtobs.Text = ""
        txtCantidad1.Focus()
        m_NombreLiquido = nombreLiquido
        m_liquido = ObtenerNombreLiquido(nombreLiquido, tipo)
        m_Nroorden = ObtenerNroOrden(nombreLiquido, tipo)
        m_Lateralidad = ObtenerLateralidad(nombreLiquido, tipo)
        m_horaliq = hora
        m_ConseEnc = consecutivoenc
        m_tipo = tipo
        m_secuencia = secuencia
        m_fechaInsert = fechaInsert
        txtCantidad1.ReadOnly = False
        txtobs.MaxLength = 50
        Dim strPerdidas As String = "Pérdidas Insensibles "
        Me.LblCarateristicas.Visible = False
        Me.Label3.Visible = True


        If tipo = "LE" Then

            Me.Text = "Liquido Eliminado - " & m_liquido

            If m_liquido = strPerdidas.ToUpper.ToUpper() Then

                m_perdidas = True

                pnlLiqElim.Visible = False
                pnlLiqAdm.Visible = True
                Me.LblCarateristicas.Visible = True
                Me.Label3.Visible = False

            Else

                GroupBox1.Visible = True
                GroupBox1.Enabled = True
                pnlLiqElim.Visible = True
                pnlLiqAdm.Visible = False
                Me.Width = 482
                CargarCaracteristicas()
                chkListBoxCar.Enabled = True
                Me.LblCarateristicas.Visible = False
                Me.Label3.Visible = True
            End If

        Else

            Me.Text = "Liquido Administrado - " & m_liquido

            GroupBox1.Visible = False
            pnlLiqElim.Visible = False
            pnlLiqAdm.Visible = True
            txtobs.Enabled = True
            Me.Width = 646

        End If

        chkmas.Checked = False
        chkmenos.Checked = False

        Me.ShowDialog()
        txtCantidad1.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.txtCantidad1.Text = ""
        Me.txtobs.Text = ""
        Me.Close()
    End Sub

    ''Se modifica evento de checkbox - dsanchez 24/08/2017
    Private Sub chkmas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkmas.Click

        If chkmas.Checked = True Then

            chkmenos.Checked = False
            txtCantidad1.Text = "   0"
            txtCantidad1.ReadOnly = True
            chkListBoxCar.Enabled = True
            txtobs.Enabled = True

        Else

            chkmenos.Checked = False
            txtCantidad1.Text = String.Empty
            txtCantidad1.ReadOnly = False
            txtobs.Text = String.Empty

        End If

    End Sub

    ''Se modifica evento de checkbox - dsanchez 24/08/2017
    Private Sub chkmenos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkmenos.Click

        If chkmenos.Checked = True Then

            chkmas.Checked = False
            txtCantidad1.Text = "   0"
            txtCantidad1.ReadOnly = True
            CargarCaracteristicas()
            chkListBoxCar.Enabled = False
            txtobs.Enabled = False

        Else

            chkmas.Checked = False
            txtCantidad1.Text = String.Empty
            txtCantidad1.ReadOnly = False
            chkListBoxCar.Enabled = True
            chkListBoxCar.Items.Clear()
            txtobs.Text = String.Empty

        End If

    End Sub

    ''Se crea metodo para obtener lateralidad - dsanchez 24/08/2017
    Private Function ObtenerLateralidad(ByVal nombreLiquido As String, ByVal tipo As String) As String

        Dim lateral As Char
        Dim iIndex As Integer

        If tipo = "LE" Then

            iIndex = nombreLiquido.IndexOf("|")

            lateral = nombreLiquido.Substring(0, iIndex)

        Else

            lateral = "N"

        End If

        Return lateral

    End Function

    ''Se crea metodo para obtener el numero de orden - dsanchez 24/08/2017
    Private Function ObtenerNroOrden(ByVal nombreLiquido As String, ByVal tipo As String) As String

        Dim iIndex As Integer
        Dim cantCar As Integer
        Dim nroOrden As String

        If tipo = "LA" Then

            iIndex = nombreLiquido.IndexOf("|")
            cantCar = nombreLiquido.Length
            cantCar = cantCar - iIndex

            nroOrden = nombreLiquido.Substring(iIndex + 1, cantCar - 1)

        Else

            iIndex = nombreLiquido.IndexOf("|")
            iIndex = nombreLiquido.IndexOf("|", iIndex + 1)
            cantCar = nombreLiquido.Length
            cantCar = cantCar - iIndex

            nroOrden = nombreLiquido.Substring(iIndex + 1, cantCar - 1)

        End If

        Return nroOrden

    End Function

    ''Se crea metodo para obtener el nombre del liquido - dsanchez 24/08/2017
    Private Function ObtenerNombreLiquido(ByVal nombreLiquido As String, ByVal tipo As String) As String

        Dim iIndex As Integer
        Dim liquido As String
        Dim inicioCadena As String
        Dim finCadena As String

        If tipo = "LA" Then

            iIndex = nombreLiquido.IndexOf("|")
            liquido = nombreLiquido.Substring(0, iIndex)

        Else

            inicioCadena = ObtenerLateralidad(nombreLiquido, tipo) + "|"
            finCadena = "|" + ObtenerNroOrden(nombreLiquido, tipo)

            liquido = nombreLiquido.Replace(finCadena, String.Empty)
            liquido = liquido.Replace(inicioCadena, String.Empty)

        End If

        Return liquido

    End Function

    ''Se crea metodo para cargar las caracteristicas de liquidos eliminados - dsanchez 24/08/2017
    Private Sub CargarCaracteristicas()

        Dim dtDatos As DataTable

        chkListBoxCar.Items.Clear()

        dtDatos = BLPlaneacion.ObtenerCaractLiquidoElim(m_liquido)

        If dtDatos.Rows.Count > 0 Then
            dtDatos.Rows.InsertAt(dtDatos.NewRow(), 0)
        End If

        For i As Integer = 0 To dtDatos.Rows.Count - 1

            If i <> 0 Then

                chkListBoxCar.Items.Add(dtDatos.Rows(i)("descripcion").ToString(), False)

            End If

        Next

    End Sub



    Private Sub MaskedTextBox1_Validating(sender As Object, e As CancelEventArgs)

        Dim s, x As String

        s = txtCantidad1.Text
        s = s.Substring(0, 4)
        x = txtCantidad1.Text
        x = s.Substring(3)
        If x = " " Or x = "" Then
            s = s.Replace(" ", "")
            If Len(s) = 1 Then
                txtCantidad1.Text = "___" + s
            End If
            If Len(s) = 2 Then
                txtCantidad1.Text = "__" + s
            End If
            If Len(s) = 3 Then
                txtCantidad1.Text = "_" + s
            End If
            If Len(s) = 0 Then
                txtCantidad1.Text = ""
            End If
        End If
    End Sub

    Private Sub MaskedTextBox1_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim s As String
        If e.KeyChar = Chr(46) Or e.KeyChar = Chr(44) Then
            s = txtCantidad1.Text
            s = s.Substring(0, 4)
            s = s.Replace(" ", "")
            If Len(s) = 1 Then
                txtCantidad1.Text = "___" + txtCantidad1.Text
            End If
            If Len(s) = 2 Then
                txtCantidad1.Text = "__" + txtCantidad1.Text
            End If
            If Len(s) = 3 Then
                txtCantidad1.Text = "_" + txtCantidad1.Text
            End If
            txtCantidad1.SelectionStart = 5
        End If
    End Sub


End Class