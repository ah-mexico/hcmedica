Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    Public Class Ginecologico
        Inherits Antecedente

        Private _ciclo As String
        Private _fechaUltimaRegla As String
        Private _fechaUltimoParto As String
        Private _gestaciones As Integer
        Private _partos As Integer
        Private _abortos As Integer
        Private _hijosVivos As Integer
        Private _hijosMuertos As Integer
        Private _cesareas As String
        Private _metodoPlanifica As String
        Private _menarquia As String
        Private _fecha As String

        Private _anoCitologia As Integer
        Private _mesCitologia As Integer
        Private _anoMamografia As Integer
        Private _mesMamografia As Integer

        
#Region "Propiedades"
        Public Property Ciclo() As String
            Get
                Return _ciclo
            End Get
            Set(ByVal Value As String)
                _ciclo = Value
            End Set
        End Property


        Public Property FechaUltimaRegla() As String
            Get
                Return _fechaUltimaRegla
            End Get
            Set(ByVal Value As String)
                _fechaUltimaRegla = Value
            End Set
        End Property


        Public Property FechaUltimoParto() As String
            Get
                Return _fechaUltimoParto
            End Get
            Set(ByVal Value As String)
                _fechaUltimoParto = Value
            End Set
        End Property


        Public Property MesMamografia() As Integer
            Get
                Return Me._mesMamografia
            End Get
            Set(ByVal Value As Integer)
                Me._mesMamografia = Value
            End Set
        End Property


        Public Property AnnoMamografia() As Integer
            Get
                Return Me._anoMamografia
            End Get
            Set(ByVal Value As Integer)
                Me._anoMamografia = Value
            End Set
        End Property


        Public Property MesCitologia() As Integer
            Get
                Return Me._mesCitologia
            End Get
            Set(ByVal Value As Integer)
                Me._mesCitologia = Value
            End Set
        End Property


        Public Property AnnoCitologia() As Integer
            Get
                Return Me._anoCitologia
            End Get
            Set(ByVal Value As Integer)
                Me._anoCitologia = Value
            End Set
        End Property


        Public Property Gestaciones() As Integer
            Get
                Return _gestaciones
            End Get
            Set(ByVal Value As Integer)
                _gestaciones = Value
            End Set
        End Property


        Public Property Partos() As Integer
            Get
                Return _partos
            End Get
            Set(ByVal Value As Integer)
                _partos = Value
            End Set
        End Property


        Public Property Abortos() As Integer
            Get
                Return _abortos
            End Get
            Set(ByVal Value As Integer)
                _abortos = Value
            End Set
        End Property


        Public Property HijosVivos() As Integer
            Get
                Return _hijosVivos
            End Get
            Set(ByVal Value As Integer)
                _hijosVivos = Value
            End Set
        End Property


        Public Property HijosMuertos() As Integer
            Get
                Return _hijosMuertos
            End Get
            Set(ByVal Value As Integer)
                _hijosMuertos = Value
            End Set
        End Property


        Public Property Cesareas() As String
            Get
                Return _cesareas
            End Get
            Set(ByVal Value As String)
                _cesareas = Value
            End Set
        End Property

        Public Property MetodoPlanifica() As String
            Get
                Return _metodoPlanifica
            End Get
            Set(ByVal Value As String)
                _metodoPlanifica = Value
            End Set
        End Property

        Public Property Menarquia() As String
            Get
                Return _menarquia
            End Get
            Set(ByVal value As String)
                _menarquia = value
            End Set
        End Property

        Public Property Fecha() As String
            Get
                Return _fecha
            End Get
            Set(ByVal value As String)
                _fecha = value
            End Set
        End Property

#End Region

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal strAntecedente As String)
            Antecedente = strAntecedente
        End Sub

        Public Function consultaAntGinecologicos(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
                   ByVal strCod_sucur As String, ByVal strTipDoc As String,
                   ByVal strNumDoc As String, ByVal strLogin As String,
                   ByVal fechaHistoria As String, ByVal strTip_admision As String, ByVal lano_adm As String,
                   ByVal dnum_adm As String, Optional ByVal fec_ini As String = "",
                   Optional ByVal fec_fin As String = "", Optional ByVal AntHst As Boolean = True) As List(Of Ginecologico)

            Dim antGinecologico As Ginecologico
            Dim drDatos As IDataReader
            Dim listaGinecologicos As New List(Of Ginecologico)

            gpmDataObj.setSQLSentence("HC_RPT_ANTECEDENTESGINECOLOGICOS", CommandType.StoredProcedure)

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
                antGinecologico = New Ginecologico(drDatos("ANTECEDENTE").ToString)

                With antGinecologico
                    .NombreMedico = drDatos("PROFESIONAL").ToString
                    .Fecha = drDatos("FECHA").ToString
                End With
                listaGinecologicos.Add(antGinecologico)

            End While

            If drDatos.IsClosed = False Then
                drDatos.Close()
            End If

            Return listaGinecologicos
        End Function


    End Class
End Namespace
