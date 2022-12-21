Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    Public Class Traumatologico
        Inherits Antecedente

        Private _CodDiagnostico As String
        Private _Diagnostico As String
        Private _Observacion As String
        Private _tiempomes As Short
        Private _tiempoano As Short
        Private _Confirma As Integer
        Private _Niega As Integer


#Region "Propiedades"

        Public Property CodDiagnostico() As String
            Get
                Return _CodDiagnostico
            End Get
            Set(ByVal Value As String)
                _CodDiagnostico = Value
            End Set
        End Property

        Public Property Diagnostico() As String
            Get
                Return _Diagnostico
            End Get
            Set(ByVal Value As String)
                _Diagnostico = Value
            End Set
        End Property

        Public Property Observacion() As String
            Get
                Return _Observacion
            End Get
            Set(ByVal Value As String)
                _Observacion = Value
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

        Public Function consultaAntTraumatologicos(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
                   ByVal strCod_sucur As String, ByVal strTipDoc As String,
                   ByVal strNumDoc As String, ByVal strLogin As String,
                   ByVal fechaHistoria As String, ByVal strTip_admision As String, ByVal lano_adm As String,
                   ByVal dnum_adm As String, Optional ByVal fec_ini As String = "",
                   Optional ByVal fec_fin As String = "", Optional ByVal AntHst As Boolean = True) As List(Of Traumatologico)

            Dim antTraumatologico As Traumatologico
            Dim drDatos As IDataReader
            Dim listaTraumatologicos As New List(Of Traumatologico)

            gpmDataObj.setSQLSentence("HC_RPT_ANTECEDENTESTRAUMATOLOGICO", CommandType.StoredProcedure)

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
                antTraumatologico = New Traumatologico(drDatos("ANTECEDENTE").ToString)

                With antTraumatologico
                    .NombreMedico = drDatos("PROFESIONAL").ToString
                    .Fecha = drDatos("FECHA").ToString
                End With
                listaTraumatologicos.Add(antTraumatologico)

            End While

            If drDatos.IsClosed = False Then
                drDatos.Close()
            End If

            Return listaTraumatologicos
        End Function


    End Class
End Namespace
