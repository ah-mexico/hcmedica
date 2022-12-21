Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente

Public Class frmOpcionesSalidaHC

    ''' <summary>
    ''' Opcion que el usuario eligio cuando cierra la historia clinica
    ''' El valor de este miembro hace parte de la enumeracion OpcionSalida
    ''' </summary>
    ''' <remarks></remarks>
    Private _opcionElegida As BLEgresos.OpcionSalida

    ''' <summary>
    ''' Funcion que recibe la configuracion de opciones que tiene que mostrar de acuerdo al tipo de admision y 
    ''' el estado de la historia 
    ''' </summary>
    ''' <param name="opcionElegida"></param>
    ''' <param name="opcionesMostradas"></param>
    ''' <remarks></remarks>
    Public Sub mostrar(ByRef opcionElegida As BLEgresos.OpcionSalida, ByVal opcionesMostradas As BLEgresos.configuracionOpciones)

        Me.Width = 550
        Select Case opcionesMostradas
            Case BLEgresos.configuracionOpciones.CerrarCancelar
                btnCerrarHistoria.Left = 143
                btnCancelar.Left = 269
                btnCerrarHistoria.Visible = True
                btnObservacion.Visible = False
                btnPendiente.Visible = False                
            Case BLEgresos.configuracionOpciones.CerrarObservaCancelar
                btnObservacion.Left = 85
                btnCerrarHistoria.Left = 213
                btnCancelar.Left = 341
                btnCerrarHistoria.Visible = True
                btnObservacion.Visible = True
                btnPendiente.Visible = False                
            Case BLEgresos.configuracionOpciones.ObservacionCancelar
                btnObservacion.Left = 143
                btnCancelar.Left = 269
                btnCerrarHistoria.Visible = False
                btnObservacion.Visible = True
                btnPendiente.Visible = False
            Case BLEgresos.configuracionOpciones.PendienteCancelar
                btnPendiente.Left = 143
                btnCancelar.Left = 269
                btnCerrarHistoria.Visible = False
                btnObservacion.Visible = False
                btnPendiente.Visible = True
            Case BLEgresos.configuracionOpciones.Cancelar
                btnCerrarHistoria.Visible = False
                btnObservacion.Visible = False
                btnPendiente.Visible = False
                btnCancelar.Left = 200
            Case BLEgresos.configuracionOpciones.CerrarHistoriaAdmision
                btnPendiente.Visible = True
                btnCerrarHistoria.Visible = True
                btnObservacion.Visible = False
                btnPendiente.Left = 223
                btnCancelar.Left = 346
                btnCerrarHistoria.Left = 100
            Case BLEgresos.configuracionOpciones.CerrarHistoriaAdmision
                btnCerrarHistoria.Left = 143
                btnCancelar.Left = 465
                btnCerrarHistoria.Visible = True
                btnObservacion.Visible = False
                btnPendiente.Visible = False
                Me.Width = 737
        End Select

        Me.ShowDialog()
        opcionElegida = _opcionElegida
    End Sub


    Private Sub btnCerrarHistoria_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrarHistoria.Click
        _opcionElegida = BLEgresos.OpcionSalida.CerrarHistoria
        Me.Hide()
    End Sub

    Private Sub btnObservacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnObservacion.Click
        _opcionElegida = BLEgresos.OpcionSalida.Observacion
        Me.Hide()
    End Sub

    Private Sub btnPendiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPendiente.Click
        _opcionElegida = BLEgresos.OpcionSalida.Pendiente
        Me.Hide()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        _opcionElegida = BLEgresos.OpcionSalida.Cancelar
        Me.Hide()
    End Sub

End Class