Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion

Public Class frm_DetCantidadLiquido



    Private m_NombreLiquido As String
    Private m_CodHistoria As Integer
    Private m_TipoLiquido As String
    Private m_Cantidad As Double
    Private m_hora As String
    Private m_fechaConsulta As String

    Private Sub frm_DetCantidadLiquido_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        CargarInformacionDetalle()

    End Sub

    ''Se crea metodo para inicializar variables - dsanchez 30/08/2017
    Public Sub Mostrar(ByVal nombreLiquido As String, ByVal codHistoria As Integer, ByVal tipoLiquido As String, ByVal cantidad As Double,
                       ByVal hora As String, ByVal fechaConsulta As String)

        m_NombreLiquido = nombreLiquido
        m_CodHistoria = codHistoria
        m_TipoLiquido = tipoLiquido
        m_Cantidad = cantidad
        m_hora = hora
        m_fechaConsulta = fechaConsulta

        Me.ShowDialog()

    End Sub

    Private Sub CargarInformacionDetalle()

        Dim dtInfo As DataTable
        Dim Nombre As Array

        dtInfo = BLPlaneacion.ObtenerDetalleCantLiquido(m_CodHistoria, m_NombreLiquido, m_Cantidad, m_TipoLiquido, m_hora, m_fechaConsulta, objGeneral.Instancia.Login)

        LblCantidad.Text = m_Cantidad.ToString() + " CC"

        If m_hora.ToString().Length < 2 Then

            lblHora.Text = "0" + m_hora.ToString() + ":00"

        Else

            lblHora.Text = m_hora.ToString() + ":00"

        End If

        For Each fila As DataRow In dtInfo.Rows

            Me.Text = "ELEMENTO" + " : " + fila("ELEMENTO").ToString()
            ' lblElemento.AutoSize = True
            txtObs.Text = fila("obsDet").ToString()
            txtObs.Enabled = False
            lblLogin.Text = fila("login").ToString()
        Next

        If Me.Text = "" Then
            nombre = Split(m_NombreLiquido, "|")
            Me.Text = "ELEMENTO" + " : " + Nombre(0).ToString
            txtObs.Enabled = False
        End If

        Me.lblElemento.Visible = False

    End Sub

End Class