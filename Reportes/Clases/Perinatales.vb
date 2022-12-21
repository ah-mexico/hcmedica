
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports System.Collections.Generic
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    Public Class Perinatales
        Inherits Antecedente

        Private _fecha As String
        Private _peso As String
        Private _talla As String
        Private _perimetroCefalico As String
        Private _tipoParto As String
        Private _gestacion As String
        Private _membrana As String
        Private _oxigenoterapia As String
        Private _hipoglicemia As String
        Private _incompatibilidadGrupo As String
        Private _incompatibilidadRH As String
        Private _taquipnea As String
        Private _ventilacion As String


#Region "Propiedades"

        Public Property Peso() As String
            Get
                Return _peso
            End Get
            Set(ByVal value As String)
                _peso = value
            End Set
        End Property

        Public Property Talla() As String
            Get
                Return _talla
            End Get
            Set(ByVal value As String)
                _talla = value
            End Set
        End Property

        Public Property PerimetroCefalico() As String
            Get
                Return _perimetroCefalico
            End Get
            Set(ByVal value As String)
                _perimetroCefalico = value
            End Set
        End Property

        Public Property TipoParto() As String
            Get
                Return _tipoParto
            End Get
            Set(ByVal value As String)
                _tipoParto = value
            End Set
        End Property

        Public Property Gestacion() As String
            Get
                Return _gestacion
            End Get
            Set(ByVal value As String)
                _gestacion = value
            End Set
        End Property

        Public Property Membrana() As String
            Get
                Return _membrana
            End Get
            Set(ByVal value As String)
                _membrana = value
            End Set
        End Property

        Public Property Oxigenoterapia() As String
            Get
                Return _oxigenoterapia
            End Get
            Set(ByVal value As String)
                _oxigenoterapia = value
            End Set
        End Property

        Public Property Hipoglicemia() As String
            Get
                Return _hipoglicemia
            End Get
            Set(ByVal value As String)
                _hipoglicemia = value
            End Set
        End Property

        Public Property IncompatibilidadGrupo() As String
            Get
                Return _incompatibilidadGrupo
            End Get
            Set(ByVal value As String)
                _incompatibilidadGrupo = value
            End Set
        End Property

        Public Property IncompatibilidadRH() As String
            Get
                Return _incompatibilidadRH
            End Get
            Set(ByVal value As String)
                _incompatibilidadRH = value
            End Set
        End Property

        Public Property Taquipnea() As String
            Get
                Return _taquipnea
            End Get
            Set(ByVal value As String)
                _taquipnea = value
            End Set
        End Property

        Public Property Ventilacion() As String
            Get
                Return _ventilacion
            End Get
            Set(ByVal value As String)
                _ventilacion = value
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

        Public Function consultarAntecedentesPerinatales(ByVal objconexion As Conexion, ByVal strTipDoc As String,
                                ByVal strNumDoc As String, ByVal strLogin As String, ByVal strFecha As String,
                                ByVal strTip_admision As String, ByVal lano_adm As String, ByVal dnum_adm As String,
                                Optional ByVal fec_ini As String = "", Optional ByVal fec_fin As String = "", Optional ByVal AntHst As Boolean = True) As List(Of Perinatales)

            Dim listaAntecedentes As New List(Of Perinatales)
            Dim objAntecedente As Perinatales
            Dim objDAOGeneral As New DAOGeneral
            Dim drDatos As IDataReader

            gpmDataObj.setSQLSentence("HC_RPT_ANTECEDENTESPERINATALES", CommandType.StoredProcedure)

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

                objAntecedente = New Perinatales()
                With objAntecedente

                    .NombreMedico = drDatos.Item("PROFESIONAL").ToString
                    .Fecha = drDatos("FECHA").ToString
                    .Antecedente = drDatos("ANTECEDENTE").ToString

                End With
                listaAntecedentes.Add(objAntecedente)
            End While

            If drDatos.IsClosed = False Then
                drDatos.Close()
            End If

            Return listaAntecedentes

        End Function

    End Class
End Namespace

