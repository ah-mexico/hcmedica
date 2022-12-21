Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Namespace Sophia.HistoriaClinica.Reportes
    ''' <summary>
    ''' Superclase generada para crear la conexion y parametros en comun para 
    ''' las clases de reportes.
    ''' </summary>
    ''' <remarks>
    ''' create: cavila@colsanitas.com 113/122007
    ''' </remarks>
    Public Class GPMDataReport
        ''' <summary>
        ''' Objeto que Realizara las transacciones en la base de datos.
        ''' </summary>
        ''' <remarks></remarks>
        Protected Shared gpmDataObj As New GPMData()

        ''' <summary>
        ''' Constructor de la clase 
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            gpmDataObj = New GPMData()
        End Sub
    End Class
End Namespace
