Imports System.Collections.Generic
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    Public Class Dieta
        Private _tipoDieta As String
        Private _fecha As String
        Private _hora As String
        Private _tratamiento As String
        Private _medico As String
        Private _especialidad As String  
        Private _observaciones As String
        Private _numeroOrden As String
        Private _ResHidrica As String

     

        Public Sub New()

        End Sub

        Public Sub New(ByVal strTipoDieta As String, ByVal strFecha As String, _
                       ByVal strTratamiento As String, ByVal strMedico As String, ByVal strEspecialidad As String, _
                       ByVal strObservaciones As String, ByVal strreshidrica As String)

            _tipoDieta = strTipoDieta
            _fecha = strFecha
            _tratamiento = strTratamiento
            _medico = strMedico
            _especialidad = strEspecialidad
            _observaciones = strObservaciones
            _ResHidrica = strreshidrica
        End Sub


#Region "Propiedades"
        Public Property TipoDieta() As String
            Get
                Return _tipoDieta
            End Get
            Set(ByVal Value As String)
                _tipoDieta = Value
            End Set
        End Property

        Public Property reshidrica() As String
            Get
                Return _ResHidrica
            End Get
            Set(ByVal Value As String)
                _ResHidrica = Value
            End Set
        End Property

        Public Property Fecha() As String
            Get
                Return _fecha
            End Get
            Set(ByVal Value As String)
                _fecha = Value
            End Set
        End Property

        Public Property Hora() As String
            Get
                Return _hora
            End Get
            Set(ByVal Value As String)
                _hora = Value
            End Set
        End Property

        Public Property Tratamiento() As String
            Get
                Return _tratamiento
            End Get
            Set(ByVal Value As String)
                _tratamiento = Value
            End Set
        End Property

        Public Property Especialidad() As String
            Get
                Return _especialidad
            End Get
            Set(ByVal Value As String)
                _especialidad = Value
            End Set
        End Property

        Public Property Medico() As String
            Get
                Return _medico
            End Get
            Set(ByVal Value As String)
                _medico = Value
            End Set
        End Property

        Public Property Observaciones() As String
            Get
                Return _observaciones
            End Get
            Set(ByVal Value As String)
                _observaciones = Value
            End Set
        End Property

        Public Property NumeroOrden() As String
            Get
                Return _numeroOrden
            End Get
            Set(ByVal Value As String)
                _numeroOrden = Value
            End Set
        End Property
#End Region

        Public Shared Function crearListaDietas(ByVal dtDietas As DataTable) As List(Of Dieta)
            Dim lista As New List(Of Dieta)
            Dim objDieta As Dieta
            Dim i As Integer

            If dtDietas Is Nothing Then
                Return lista
            End If

            For i = 0 To dtDietas.Rows.Count - 1
                objDieta = New Dieta(dtDietas.Rows(i).Item("DescriDieta").ToString, dtDietas.Rows(i).Item("fec_con").ToString, _
                                     dtDietas.Rows(i).Item("Tratamiento").ToString, "", "", dtDietas.Rows(i).Item("obs").ToString, dtDietas.Rows(i).Item("reshidrica").ToString)
                objDieta.NumeroOrden = dtDietas.Rows(i).Item("NroOrden").ToString
                lista.Add(objDieta)
            Next

            Return lista
        End Function

    End Class
End Namespace

