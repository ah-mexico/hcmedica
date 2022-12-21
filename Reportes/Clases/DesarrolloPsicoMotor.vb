Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports System.Collections.Generic
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    Public Class DesarrolloPsicoMotor
        Inherits Antecedente

        Private _fecha As String
        Private _sonrisaSocial As String
        Private _levantaCabeza As String
        Private _sostieneCabeza As String
        Private _seSentoSolo As String
        Private _seParoConAyuda As String
        Private _gateo As String
        Private _camino As String
        Private _inicioLenguaje As String
        Private _integracionLenguaje As String
        Private _controlEsfinteres As String
        Private _inicioEscolaridad As String
        Private _primaria As String
        Private _aprovechaEscolaridad As String

#Region "Propiedades"

        Public Property Fecha() As String
            Get
                Return _fecha
            End Get
            Set(ByVal value As String)
                _fecha = value
            End Set
        End Property

        Public Property SonrisaSocial() As String
            Get
                Return _sonrisaSocial
            End Get
            Set(ByVal value As String)
                _sonrisaSocial = value
            End Set
        End Property

        Public Property LevantaCabeza() As String
            Get
                Return _levantaCabeza
            End Get
            Set(ByVal value As String)
                _levantaCabeza = value
            End Set
        End Property

        Public Property SostieneCabeza() As String
            Get
                Return _sostieneCabeza
            End Get
            Set(ByVal value As String)
                _sostieneCabeza = value
            End Set
        End Property

        Public Property SeSentoSolo() As String
            Get
                Return _seSentoSolo
            End Get
            Set(ByVal value As String)
                _seSentoSolo = value
            End Set
        End Property

        Public Property SeParoConAyuda() As String
            Get
                Return _seParoConAyuda
            End Get
            Set(ByVal value As String)
                _seParoConAyuda = value
            End Set
        End Property

        Public Property Gateo() As String
            Get
                Return _gateo
            End Get
            Set(ByVal value As String)
                _gateo = value
            End Set
        End Property

        Public Property Camino() As String
            Get
                Return _camino
            End Get
            Set(ByVal value As String)
                _camino = value
            End Set
        End Property

        Public Property InicioLenguaje() As String
            Get
                Return _inicioLenguaje
            End Get
            Set(ByVal value As String)
                _inicioLenguaje = value
            End Set
        End Property

        Public Property IntegracionLenguaje() As String
            Get
                Return _integracionLenguaje
            End Get
            Set(ByVal value As String)
                _integracionLenguaje = value
            End Set
        End Property

        Public Property ControlEsfinteres() As String
            Get
                Return _controlEsfinteres
            End Get
            Set(ByVal value As String)
                _controlEsfinteres = value
            End Set
        End Property

        Public Property InicioEscolaridad() As String
            Get
                Return _inicioEscolaridad
            End Get
            Set(ByVal value As String)
                _inicioEscolaridad = value
            End Set
        End Property

        Public Property Primaria() As String
            Get
                Return _primaria
            End Get
            Set(ByVal value As String)
                _primaria = value
            End Set
        End Property

        Public Property AprovechaEscolaridad() As String
            Get
                Return _aprovechaEscolaridad
            End Get
            Set(ByVal value As String)
                _aprovechaEscolaridad = value
            End Set
        End Property

#End Region


        Public Sub New()
            MyBase.New()
        End Sub

        Public Function consultarDesarrolloPsicomotor(ByVal objconexion As Conexion, ByVal strTipDoc As String, _
        ByVal strNumDoc As String, ByVal strLogin As String, ByVal strFecha As String, Optional ByVal fec_ini As String = "", _
        Optional ByVal fec_fin As String = "") As List(Of DesarrolloPsicoMotor)

            Dim listaAntecedentes As New List(Of DesarrolloPsicoMotor)
            Dim objAntecedente As DesarrolloPsicoMotor
            Dim objDAOGeneral As New DAOGeneral
            Dim dtResultado As DataTable
            Dim drFila As DataRow

            If fec_fin = "" Or fec_fin = "" Then
                dtResultado = objDAOGeneral.EjecutarSPConParametros("pa_Reportes_DesarrolloPsicoMotor", objconexion, -1, _
                                                      strTipDoc, strNumDoc, strLogin, strFecha, Nothing, Nothing)
            Else
                dtResultado = objDAOGeneral.EjecutarSPConParametros("pa_Reportes_DesarrolloPsicoMotor", objconexion, -1, _
                                                      strTipDoc, strNumDoc, strLogin, strFecha, fec_ini, fec_fin)
            End If

            For Each drFila In dtResultado.Rows
                objAntecedente = New DesarrolloPsicoMotor()
                With objAntecedente
                    .Fecha = drFila.Item("fec_con").ToString
                    .SonrisaSocial = drFila.Item("Sonrisa").ToString
                    .LevantaCabeza = drFila.Item("LevantaCabeza").ToString
                    .SostieneCabeza = drFila.Item("SostieneCabeza").ToString
                    .SeSentoSolo = drFila.Item("Sentado").ToString
                    .SeParoConAyuda = drFila.Item("Parado").ToString
                    .Gateo = drFila.Item("Gateo").ToString
                    .Camino = drFila.Item("Camino").ToString
                    .InicioLenguaje = drFila.Item("InicioLenguaje").ToString
                    .IntegracionLenguaje = drFila.Item("IntegroLenguaje").ToString
                    .ControlEsfinteres = drFila.Item("ControlEsfinteres").ToString
                    .InicioEscolaridad = drFila.Item("InicioEscolaridad").ToString
                    .Primaria = drFila.Item("Primaria").ToString
                    .AprovechaEscolaridad = drFila.Item("AprovechaEscolaridad").ToString
                    .Observaciones = drFila.Item("obs").ToString
                    .NombreMedico = drFila.Item("medico").ToString
                    .TipoDocumentoMedico = drFila.Item("tipoDocMedico").ToString
                    .NumeroDocumentoMedico = drFila.Item("numDocMedico").ToString
                End With
                listaAntecedentes.Add(objAntecedente)
            Next

            Return listaAntecedentes
        End Function

    End Class
End Namespace

