Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    Public Class Patologico
        Inherits Antecedente

        Private _diagnostico As String
        Private _mes As String
        Private _ano As String

#Region "Propiedades"
        Public Property Diagnostico() As String
            Get
                Return _diagnostico
            End Get
            Set(ByVal Value As String)
                _diagnostico = Value
            End Set
        End Property


        Public Property Mes() As String
            Get
                Return _mes
            End Get
            Set(ByVal Value As String)
                _mes = Value
            End Set
        End Property

        Public Property Ano() As String
            Get
                Return _ano
            End Get
            Set(ByVal Value As String)
                _ano = Value
            End Set
        End Property
#End Region

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal strCodigo As String, ByVal strDiagnostico As String,
                       ByVal strMes As String, ByVal strAno As String, ByVal strAntecedente As String)

            Codigo = strCodigo
            _diagnostico = strDiagnostico
            _mes = strMes
            _ano = strAno
            Antecedente = strAntecedente

        End Sub

        Public Sub New(ByVal strAntecedente As String)
            Antecedente = strAntecedente
        End Sub

        Public Function consultarPatologias(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
                   ByVal strCod_sucur As String, ByVal strTipDoc As String,
                   ByVal strNumDoc As String, ByVal strLogin As String,
                   ByVal fechaHistoria As String, ByVal strTip_admision As String,
                   ByVal lano_adm As String, ByVal dnum_adm As String, Optional ByVal fec_ini As String = "",
                   Optional ByVal fec_fin As String = "", Optional ByVal AntHst As Boolean = True) As List(Of Patologico)

            Dim patologia As Patologico
            Dim drPatologias As IDataReader
            Dim listaPatologias As New List(Of Patologico)

            gpmDataObj.setSQLSentence("HC_RPT_ANTECEDENTESPATOLOGICOS", CommandType.StoredProcedure)

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

            drPatologias = gpmDataObj.ExecRdr()

            While drPatologias.Read()
                patologia = New Patologico(drPatologias("ANTECEDENTE").ToString)
                patologia.NombreMedico = drPatologias("PROFESIONAL").ToString
                patologia.Fecha = drPatologias("FECHA").ToString
                listaPatologias.Add(patologia)
            End While

            If drPatologias.IsClosed = False Then
                drPatologias.Close()
            End If

            Return listaPatologias
        End Function
    End Class
End Namespace

