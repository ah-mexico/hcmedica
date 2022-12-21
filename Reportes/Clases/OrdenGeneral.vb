Imports System.Collections.Generic

Namespace Sophia.HistoriaClinica.Reportes
    Public Class OrdenGeneral

        Private _descripcion As String
        Private _fecha As String
        Private _tratamiento As String
        Private _medico As String
        Private _especialidad As String
        Private _numeroOrden As String
        Private _Frecuencia As String
        Private _Observaciones As String
        Private _cada As String
        Private _tiempo As String

#Region "Propiedades"

        Public Property Descripcion() As String
            Get
                Return _descripcion
            End Get
            Set(ByVal Value As String)
                _descripcion = Value
            End Set
        End Property
        Public Property Frecuencia() As String
            Get
                Return _Frecuencia
            End Get
            Set(ByVal Value As String)
                _Frecuencia = Value
            End Set
        End Property
        Public Property Observaciones() As String
            Get
                Return _Observaciones
            End Get
            Set(ByVal Value As String)
                _Observaciones = Value
            End Set
        End Property
        Public Property cada() As String
            Get
                Return _cada
            End Get
            Set(ByVal Value As String)
                _cada = Value
            End Set
        End Property
        Public Property tiempo() As String
            Get
                Return _tiempo
            End Get
            Set(ByVal Value As String)
                _tiempo = Value
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

        Public Property Tratamiento() As String
            Get
                Return _tratamiento
            End Get
            Set(ByVal Value As String)
                _tratamiento = Value
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

        Public Property Especialidad() As String
            Get
                Return _especialidad
            End Get
            Set(ByVal Value As String)
                _especialidad = Value
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

        Public Shared Function crearListaOrdenesGenerales(ByVal dtGenerales As DataTable) As List(Of OrdenGeneral)
            Dim lista As New List(Of OrdenGeneral)
            Dim objOrdenGeneral As OrdenGeneral
            Dim i As Integer

            If dtGenerales Is Nothing Then
                Return lista
            End If

            For i = 0 To dtGenerales.Rows.Count - 1
                objOrdenGeneral = New OrdenGeneral()
                With objOrdenGeneral
                    ._descripcion = dtGenerales.Rows(i).Item("TextoOrden").ToString
                    ._fecha = dtGenerales.Rows(i).Item("fec_con").ToString
                    ._tratamiento = dtGenerales.Rows(i).Item("Tratamiento").ToString
                    '._medico = dtGenerales.Rows(i).Item("nombreMedico").ToString
                    '._especialidad = dtGenerales.Rows(i).Item("especialidad").ToString
                    ._numeroOrden = dtGenerales.Rows(i).Item("NroOrden").ToString
                    ._Frecuencia = dtGenerales.Rows(i).Item("Frecuencia").ToString
                    ._Observaciones = dtGenerales.Rows(i).Item("Obs").ToString
                    ._cada = dtGenerales.Rows(i).Item("cada").ToString
                    ._tiempo = dtGenerales.Rows(i).Item("Tiempo").ToString
                End With
                lista.Add(objOrdenGeneral)
            Next

            Return lista
        End Function

    End Class
End Namespace

