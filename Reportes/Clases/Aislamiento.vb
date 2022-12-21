Imports System.Collections.Generic
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    Public Class Aislamiento

        Private _tipoAislamiento As String
        Private _fecha As String
        Private _hora As String
        Private _tratamiento As String
        Private _medico As String
        Private _especialidad As String
        Private _observaciones As String
        Private _numeroOrden As String

        Public Sub New()

        End Sub

        Public Sub New(ByVal strTipoAislamiento As String, ByVal strFecha As String,
                       ByVal strTratamiento As String, ByVal strMedico As String, ByVal strEspecialidad As String,
                       ByVal strObservaciones As String)

            _tipoAislamiento = strTipoAislamiento
            _fecha = strFecha
            _tratamiento = strTratamiento
            _medico = strMedico
            _especialidad = strEspecialidad
            _observaciones = strObservaciones

        End Sub
#Region "Propiedades"

        Public Property TipoAislamiento() As String
            Get
                Return _tipoAislamiento
            End Get
            Set(ByVal Value As String)
                _tipoAislamiento = Value
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
        Public Shared Function crearListaAislamiento(ByVal dtAislamiento) As List(Of Aislamiento)

            Dim lista As New List(Of Aislamiento)
            Dim objAislamiento As Aislamiento
            Dim i As Integer

            If dtAislamiento Is Nothing Then
                Return lista
            End If

            For i = 0 To dtAislamiento.Rows.Count - 1
                objAislamiento = New Aislamiento(dtAislamiento.Rows(i).Item("desc_aislamiento").ToString, dtAislamiento.Rows(i).Item("fec_con").ToString,
                                     dtAislamiento.Rows(i).Item("Tratamiento").ToString, "", "", BL.BLOrdenes.ConsultarMedidasAislamiento(dtAislamiento.Rows(i).Item("desc_aislamiento").ToString()))
                objAislamiento.NumeroOrden = dtAislamiento.Rows(i).Item("NroOrden").ToString
                lista.Add(objAislamiento)
            Next

            Return lista

        End Function

    End Class

End Namespace