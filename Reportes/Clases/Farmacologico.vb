Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic

Namespace Sophia.HistoriaClinica.Reportes
    Public Class Farmacologico
        Inherits Antecedente

        Private _farmaco As String
        Public Property Farmaco() As String
            Get
                Return _farmaco
            End Get
            Set(ByVal Value As String)
                _farmaco = Value
            End Set
        End Property

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal strAntecedente As String)
            Antecedente = strAntecedente
        End Sub

        Public Function consultarAntFarmacologicos(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
                   ByVal strCod_sucur As String, ByVal strTipDoc As String,
                                                    ByVal strNumDoc As String, ByVal strLogin As String,
                                                    ByVal fechaHistoria As String, ByVal strTip_admision As String,
                                                    ByVal lano_adm As String, ByVal dnum_adm As String, Optional ByVal fec_ini As String = "",
                                                    Optional ByVal fec_fin As String = "", Optional ByVal AntHst As Boolean = True) As List(Of Farmacologico)

            Dim antFarmaco As Farmacologico
            Dim drDatos As System.Data.Common.DbDataReader
            Dim listaFarmacologicos As New List(Of Farmacologico)

            gpmDataObj.setSQLSentence("HC_RPT_ANTECEDENTESFARMACOLOGICO", CommandType.StoredProcedure)

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
                antFarmaco = New Farmacologico(drDatos("ANTECEDENTE").ToString)
                antFarmaco.NombreMedico = drDatos("PROFESIONAL").ToString
                antFarmaco.Fecha = drDatos("FECHA").ToString
                listaFarmacologicos.Add(antFarmaco)
            End While

            If drDatos.IsClosed = False Then
                drDatos.Close()
            End If

            Return listaFarmacologicos
        End Function
    End Class
End Namespace

