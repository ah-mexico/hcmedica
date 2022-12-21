Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports Microsoft.Reporting.WinForms

''' <summary>
''' Forma que contiene el control para generar el reporte de reimpresion de admisiones
''' </summary>
''' <remarks></remarks>
''' 
Public Class frmReimpresionAdm

    Private Sub frmReimpresionAdm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ReimprirAdmision(3, "1100109887", "0003", "RC", "1014858204", "H", 2006, 1030, "GROJAS")
        'ReimprirAdmision(3, "1100109887", "0003", "CC", "52793449", "H", 2005, 11240, "GROJAS")
        'ReimprirAdmision(3, "1100109887", "0003", "RC", "2004021038823751", "H", 2006, 2691, "JNAVARRO")
        'ReimprirAdmision(3, "1100109887", "0003", "CC", "23265446", "A", 2006, 2384)
    End Sub
    '''' <summary>
    '''' Funcion que crea un objeto admision de acuerdo a los parametros de entrada, pasa este objeto como 
    '''' fuente de datos para el reporte y lo pinta. 
    '''' </summary>
    '''' <param name="objConexion">Datos que se usan para armar la cadena de conexion a la BD</param>
    '''' <param name="intAccion">Si es 2 se buscan los datos basicos de la admision con base en los parametros. Para otro valor trae toda la informacion del reporte de reimpresion</param>
    '''' <param name="strcod_pre_sgs">Codigo del Prestador</param>
    '''' <param name="strCod_sucur">Codigo de la sucursal</param>
    '''' <param name="strTipDoc">Tipo de documento del paciente</param>
    '''' <param name="strNumDoc">Nuemro de documento del paciente</param>
    '''' <param name="strTipAdm">Tipo de admision</param>
    '''' <param name="intAnoAdm">Año de admision</param>
    '''' <param name="dNumAdm">Numero de la Admision</param>
    '''' <remarks></remarks>
    'Public Sub ReimprirAdmision(ByVal objConexion As Conexion, ByVal intAccion As Integer, ByVal strcod_pre_sgs As String,
    '                            ByVal strCod_sucur As String, ByVal strTipDoc As String,
    '                            ByVal strNumDoc As String, ByVal strTipAdm As String,
    '                            ByVal intAnoAdm As Integer, ByVal dNumAdm As Double)

    '    Dim objAdmision As admision  'Objeto que encapsula la informacion de la admision
    '    Dim lerror As Integer

    '    objAdmision = New admision() 'creacion del objeto

    '    Try
    '        ''Realiza la consulta a la base de datos y deja la informacion en el objeto admision
    '        lerror = objAdmision.llenarAdmision(objConexion, intAccion, strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strTipAdm,
    '                                            intAnoAdm, dNumAdm)
    '        ''Muestra los mensajes de error
    '        mensajeErrores(lerror)

    '        ''se enlaza el objeto que contiene la informacion de la admision con la fuente de datos del reporte
    '        Me.AdmisionBindingSource.DataSource = objAdmision
    '        ''se enlaza el objeto que contiene la informacion del paciente con la fuente de datos del reporte para
    '        ''los datos del paciente.
    '        Me.PacienteBindingSource.DataSource = objAdmision.Paciente

    '    Catch ex As Exception
    '        MsgBox("Error en la impresión del reporte.", MsgBoxStyle.Critical)
    '    End Try

    '    Me.RepAdmisionU.RefreshReport()

    'End Sub

    Private Sub RepAdmisionU_RenderingComplete(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.RenderingCompleteEventArgs) Handles RepAdmisionU.RenderingComplete
        'Me.RepAdmisionU.SetDisplayMode(DisplayMode.PrintLayout)
        Me.RepAdmisionU.ZoomMode = ZoomMode.PageWidth
    End Sub

    ''' <summary>
    ''' Impresion de los mensajes de error
    ''' </summary>
    ''' <param name="lerror">numero del error</param>
    ''' <remarks></remarks>
    Private Sub mensajeErrores(ByVal lerror As Integer)
        Select Case lerror
            Case 0
            Case 999
                MsgBox("No exiten datos para esta admision y paciente", MsgBoxStyle.Information)
            Case Else
                MsgBox("Error en la consulta del procedimiento pa_Reportes_ReImpAdmision", MsgBoxStyle.Critical)
        End Select
    End Sub

    Private Sub RepAdmisionU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RepAdmisionU.Load

    End Sub
End Class