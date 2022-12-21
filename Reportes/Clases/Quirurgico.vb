Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    Public Class Quirurgico
        Inherits Antecedente

        Private _descripcion As String
        Public Property Descripcion() As String
            Get
                Return _descripcion
            End Get
            Set(ByVal Value As String)
                _descripcion = Value
            End Set
        End Property

        'Private _ano As String
        'Public Property Ano() As String
        '    Get
        '        Return _ano
        '    End Get
        '    Set(ByVal Value As String)
        '        _ano = Value
        '    End Set
        'End Property

        'Private _mes As String
        'Public Property Mes() As String
        '    Get
        '        Return _mes
        '    End Get
        '    Set(ByVal Value As String)
        '        _mes = Value
        '    End Set
        'End Property

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal strcodigo As String, ByVal descripcion As String, ByVal sAntecedente As String)
            Codigo = strcodigo
            _descripcion = descripcion
            Antecedente = sAntecedente
        End Sub

        Public Sub New(ByVal sAntecedente As String)
            Antecedente = sAntecedente
        End Sub

        Public Function consultarAntQuirurgicos(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
                   ByVal strCod_sucur As String, ByVal strTipDoc As String,
                   ByVal strNumDoc As String, ByVal strLogin As String,
                   ByVal fechaHistoria As String, ByVal strTip_admision As String, ByVal lano_adm As String,
                   ByVal dnum_adm As String, Optional ByVal fec_ini As String = "",
                   Optional ByVal fec_fin As String = "", Optional ByVal AntHst As Boolean = True) As List(Of Quirurgico)

            Dim antQuirurgico As Quirurgico
            Dim drDatos As IDataReader
            Dim listaQuirurgicos As New List(Of Quirurgico)

            gpmDataObj.setSQLSentence("HC_RPT_ANTECEDENTESQUIRURGICOS", CommandType.StoredProcedure)

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
                antQuirurgico = New Quirurgico(drDatos("ANTECEDENTE").ToString)
                antQuirurgico.NombreMedico = drDatos("PROFESIONAL").ToString
                antQuirurgico.Fecha = drDatos("FECHA").ToString
                listaQuirurgicos.Add(antQuirurgico)

            End While

            If drDatos.IsClosed = False Then
                drDatos.Close()
            End If

            Return listaQuirurgicos

        End Function

    End Class
End Namespace

