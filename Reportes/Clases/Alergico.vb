Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    Public Class Alergico
        Inherits Antecedente

        Private _clase As String
        Public Property Clase() As String
            Get
                Return _clase
            End Get
            Set(ByVal Value As String)
                _clase = Value
            End Set
        End Property

        Private _mes As String
        Public Property Mes() As String
            Get
                Return _mes
            End Get
            Set(ByVal value As String)
                _mes = value
            End Set
        End Property

        Private _ano As String
        Public Property Ano() As String
            Get
                Return _ano
            End Get
            Set(ByVal value As String)
                _ano = value
            End Set
        End Property
        'Private _Fecha As String
        'Public Property FechaAler() As String
        '    Get
        '        Return _Fecha
        '    End Get
        '    Set(ByVal value As String)
        '        _Fecha = value
        '    End Set
        'End Property
        ''' <summary>
        ''' constructor por defecto
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal clase As String, ByVal strAntecedente As String)
            _clase = clase
            Antecedente = strAntecedente
        End Sub
        Public Sub New(ByVal strAntecedente As String)
            Antecedente = strAntecedente
        End Sub

        Public Function consultarAntAlergicos(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
                   ByVal strCod_sucur As String, ByVal strTipDoc As String,
                   ByVal strNumDoc As String, ByVal strLogin As String,
                   ByVal fechaHistoria As String, ByVal strTip_admision As String,
                   ByVal lano_adm As String, ByVal dnum_adm As String, Optional ByVal fec_ini As String = "",
                   Optional ByVal fec_fin As String = "", Optional ByVal AntHst As Boolean = True) As List(Of Alergico)

            Dim antAlergico As Alergico
            Dim drDatos As IDataReader
            Dim listaAlergicos As New List(Of Alergico)

            gpmDataObj.setSQLSentence("HC_RPT_ANTECEDENTESALERGICOS", CommandType.StoredProcedure)

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
                antAlergico = New Alergico(drDatos("ANTECEDENTE").ToString)
                With antAlergico
                    .NombreMedico = drDatos("PROFESIONAL").ToString
                    .Fecha = drDatos("FECHA").ToString

                End With
                listaAlergicos.Add(antAlergico)
            End While

            If drDatos.IsClosed = False Then
                drDatos.Close()
            End If
            '' ''command.Command.Connection.Close()
            '' ''command.Command.Connection.Dispose()

            Return listaAlergicos
        End Function
    End Class
End Namespace

