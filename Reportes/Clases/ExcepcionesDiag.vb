''Claudia Garay Marzo 26 de 2012 Ctc's

Imports System.Collections.Generic
Imports System.Data.Common
Namespace Sophia.HistoriaClinica.Reportes
    Public Class ExcepcionesDiag
        Inherits GPMDataReport

        ''Evolucion Diagnosticos

        Private _DescDiagn As String

        Public Property DescDiagn() As String
            Get
                Return _DescDiagn
            End Get
            Set(ByVal value As String)
                _DescDiagn = value
            End Set
        End Property
      

       
    End Class
End Namespace

