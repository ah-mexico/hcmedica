''Claudia Garay Marzo 26 de 2012 Ctc's

Imports System.Collections.Generic
Imports System.Data.Common
Namespace Sophia.HistoriaClinica.Reportes
    Public Class ExcepcionesEvo
        Inherits GPMDataReport
        Private _Evolucion As String

        Public Property Evolucion() As String
            Get
                Return _Evolucion
            End Get
            Set(ByVal value As String)
                _Evolucion = value
            End Set
        End Property
    End Class
End Namespace

