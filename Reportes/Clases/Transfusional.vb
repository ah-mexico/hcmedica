Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    Public Class Transfusional
        Inherits Antecedente

        Private _IdComponente As Integer
        Private _OtroComponente As String
        Private _ReaccionAdversa As String
        Private _tiempomes As Short
        Private _tiempoano As Short
        Private _Confirma As Integer
        Private _Niega As Integer


#Region "Propiedades"
        Public Property IdComponente() As Integer
            Get
                Return _IdComponente
            End Get
            Set(ByVal Value As Integer)
                _IdComponente = Value
            End Set
        End Property

        Public Property OtroComponente() As String
            Get
                Return _OtroComponente
            End Get
            Set(ByVal Value As String)
                _OtroComponente = Value
            End Set
        End Property

        Public Property ReaccionAdversa() As String
            Get
                Return _ReaccionAdversa
            End Get
            Set(ByVal Value As String)
                _ReaccionAdversa = Value
            End Set
        End Property

        Public Property tiempomes() As Short
            Get
                Return _tiempomes
            End Get
            Set(ByVal Value As Short)
                _tiempomes = Value
            End Set
        End Property

        Public Property tiempoano() As Short
            Get
                Return _tiempoano
            End Get
            Set(ByVal Value As Short)
                _tiempoano = Value
            End Set
        End Property

        Public Property Confirma() As Integer
            Get
                Return _Confirma
            End Get
            Set(ByVal Value As Integer)
                _Confirma = Value
            End Set
        End Property

        Public Property Niega() As Integer
            Get
                Return _Niega
            End Get
            Set(ByVal Value As Integer)
                _Niega = Value
            End Set
        End Property

#End Region

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal strAntecedente As String)

            Antecedente = strAntecedente
        End Sub

        Public Function consultaAntTransfusionales(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
                   ByVal strCod_sucur As String, ByVal strTipDoc As String,
                   ByVal strNumDoc As String, ByVal strLogin As String,
                   ByVal fechaHistoria As String, ByVal strTip_admision As String, ByVal lano_adm As String,
                   ByVal dnum_adm As String, Optional ByVal fec_ini As String = "",
                   Optional ByVal fec_fin As String = "", Optional ByVal AntHst As Boolean = True) As List(Of Transfusional)

            Dim antTransfusional As Transfusional
            Dim drDatos As IDataReader
            Dim listaTransfusionales As New List(Of Transfusional)

            gpmDataObj.setSQLSentence("HC_RPT_ANTECEDENTESTRANSFUSIONALES", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("TIPDOC", SqlDbType.VarChar, strTipDoc)
            gpmDataObj.addInputParameter("NUMDOC", SqlDbType.VarChar, strNumDoc)
            gpmDataObj.addInputParameter("ANTECEDENTES_HST", SqlDbType.Bit, AntHst)

            If fec_fin <> "" Or fec_fin <> "" Then
                gpmDataObj.addInputParameter("FEC_INI", SqlDbType.DateTime, fec_ini)
                gpmDataObj.addInputParameter("FEC_FIN", SqlDbType.DateTime, fec_fin)
            Else
                gpmDataObj.addInputParameter("FEC_INI", SqlDbType.DateTime, Nothing)
                gpmDataObj.addInputParameter("FEC_FIN", SqlDbType.DateTime, Nothing)
            End If

            drDatos = gpmDataObj.ExecRdr()

            While drDatos.Read()
                antTransfusional = New Transfusional(drDatos("ANTECEDENTE").ToString)

                With antTransfusional
                    .NombreMedico = drDatos("PROFESIONAL").ToString
                    .Fecha = drDatos("FECHA").ToString
                End With
                listaTransfusionales.Add(antTransfusional)

            End While

            If drDatos.IsClosed = False Then
                drDatos.Close()
            End If

            Return listaTransfusionales
        End Function


    End Class
End Namespace
