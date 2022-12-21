''Claudia Garay Marzo 26 de 2012 Ctc's

Imports System.Collections.Generic
Imports System.Data.Common
Namespace Sophia.HistoriaClinica.Reportes
    Public Class ExcepcionesMot
        Inherits GPMDataReport

        ''Motivo de Consulta
        Private _MotConsulta As String

        Public Property MotConsulta() As String
            Get
                Return _MotConsulta
            End Get
            Set(ByVal value As String)
                _MotConsulta = value
            End Set
        End Property


    End Class
End Namespace

