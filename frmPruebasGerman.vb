Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion

Public Class frmPruebasGerman
    Private dblAltoControlPaciente As Double
    Private dblPosY As Double
    Public objDatosGenerales As objGeneral.Generales
    Public objConexion As objCon.Conexion


    Private Sub frmPruebasGerman_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        objDatosGenerales = objGeneral.Generales.Instancia
        objConexion = objCon.Conexion.Instancia

        With objDatosGenerales
            .Cadena = "Persist Security Info=False;User ID=sophia;PWD=sophia;Initial Catalog=Sophia;Data Source=pruebasdesa;"
            .CadenaLocal = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\WINDOWS\system32\SOPHIA\Sophia.mdb"
            .Prestador = "1100109887"
            .DescripcionPrestador = ""
            .Sucursal = "0008"
            .DescripcionSucursal = ""
            .Ciudad = ""
            .DescripcionCiudad = ""
            .Pais = ""
            .DescripcionPais = ""
            .Departamento = ""
            .DescripcionDepartamento = ""
            .CentroCosto = "centroCosto"
            .DescripcionCentroCosto = ""
            .Login = "16356201"
            .Clave = "190477"
            .NombreMedico = "NombreMedico"
            .RegistroMedico = "RegistroMedico"
            .CodigoEspecialidad = "004"
            .DescripcionEspecialidad = ""
            .FormatoFechaCorta = "yyyy/MM/dd"
            .FormatoFechaLargo = "yyyy/MM/dd HH:mm:ss.fff"
            .ManejaRips = True
            .EstadoInstancia = True
        End With

        With objConexion
            .strBaseDatos = "Sophia"
            .strServidor = "Pruebasdesa"
            .strUsuarioBD = "Sophia"
            .strClaveUsuarioBD = "Sophia"
            .EstadoInstancia = True
        End With

        CargarListaEspera()
        dblAltoControlPaciente = pnlContenedorDatosPaciente.Height
    End Sub


    Private Sub cmdHistoriaBasica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHistoriaBasica.Click
        Dim ctlPantallaDatosPaciente As New ctlDatosPaciente
        Dim ctlPantallaHistoriaBasica As New HCBasica

        pnlContenedorListaEspera.Visible = False
        pnlContenedorPantallas.Visible = True

        Me.pnlContenedorDatosPaciente.Controls.Clear()
        ctlPantallaDatosPaciente.Dock = DockStyle.Fill

        ctlPantallaDatosPaciente.Size = pnlContenedorDatosPaciente.Size
        Me.pnlContenedorDatosPaciente.Controls.Add(ctlPantallaDatosPaciente)
        ctlPantallaDatosPaciente.Show()

        Me.pnlContenedorDatos.Controls.Clear()
        ctlPantallaHistoriaBasica.Dock = DockStyle.Fill
        ctlPantallaHistoriaBasica.Size = pnlContenedorDatos.Size
        ctlPantallaHistoriaBasica.AutoSize = True
        ctlPantallaHistoriaBasica.AutoScroll = True
        Me.pnlContenedorDatos.Controls.Add(ctlPantallaHistoriaBasica)
        ctlPantallaHistoriaBasica.Show()


    End Sub

    Private Sub pnlContenedorDatosPaciente_XPanderCollapsed(ByVal x As XPanderControl.XPander) Handles pnlContenedorDatosPaciente.XPanderCollapsed
        'Me.pnlContenedorDatos.Height = (Me.pnlContenedorDatos.Height + dblAltoControlPaciente) - Me.pnlContenedorDatosPaciente.Height
        Me.pnlContenedorDatos.Height = (Me.pnlContenedorDatos.Height + dblAltoControlPaciente) - Me.pnlContenedorDatosPaciente.CaptionHeight
        'dblAltoControlPacienteCollapsed = Me.pnlContenedorDatosPaciente.Height
    End Sub

    Private Sub pnlContenedorDatosPaciente_XPanderExpanded(ByVal x As XPanderControl.XPander) Handles pnlContenedorDatosPaciente.XPanderExpanded
        'Me.pnlContenedorDatos.Height = (Me.pnlContenedorDatos.Height - dblAltoControlPaciente) + dblAltoControlPacienteCollapsed
        Me.pnlContenedorDatos.Height = (Me.pnlContenedorDatos.Height - dblAltoControlPaciente) + Me.pnlContenedorDatosPaciente.CaptionHeight
    End Sub

    Private Sub cmdListaEspera_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdListaEspera.Click
        CargarListaEspera()
    End Sub

    Private Sub CargarListaEspera()
        Dim ctlPantallaListaEspera As New ListaEspera

        pnlContenedorPantallas.Visible = False
        pnlContenedorListaEspera.Visible = True

        pnlContenedorListaEspera.Controls.Clear()
        ctlPantallaListaEspera.Dock = DockStyle.Fill
        ctlPantallaListaEspera.Size = pnlContenedorListaEspera.Size
        Me.pnlContenedorListaEspera.Controls.Add(ctlPantallaListaEspera)
        ctlPantallaListaEspera.Show()

    End Sub

    'Ordenes Médicas
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click

        Dim ctlPantallaOrdenes As New ctlOrdenesMedicas
        
        pnlContenedorListaEspera.Visible = False
        pnlContenedorPantallas.Visible = True

        Me.pnlContenedorDatos.Controls.Clear()
        ctlPantallaOrdenes.Dock = DockStyle.Fill
        ctlPantallaOrdenes.Size = pnlContenedorDatos.Size
        ctlPantallaOrdenes.AutoScroll = True
        Me.pnlContenedorDatos.Controls.Add(ctlPantallaOrdenes)
        ctlPantallaOrdenes.Show()
    End Sub
End Class

