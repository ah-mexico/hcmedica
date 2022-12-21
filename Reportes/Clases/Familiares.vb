Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic

Namespace Sophia.HistoriaClinica.Reportes
    Public Class Familiares
        Inherits Antecedente

        Private _diagnostico As String
        Public Property Diagnostico() As String
            Get
                Return _diagnostico
            End Get
            Set(ByVal Value As String)
                _diagnostico = Value
            End Set
        End Property

        Private _parentesco As String
        Public Property Parentesco() As String
            Get
                Return _parentesco
            End Get
            Set(ByVal Value As String)
                _parentesco = Value
            End Set
        End Property

        'Private _Fecha As String
        'Public Property FechaFam() As String
        '    Get
        '        Return _Fecha
        '    End Get
        '    Set(ByVal value As String)
        '        _Fecha = value
        '    End Set
        'End Property


        ''' <summary>
        ''' constructor por defecto de la clase.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal strAntecedente As String)

            Antecedente = strAntecedente

        End Sub

        Public Function consultarAntFamiliares(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
                                                      ByVal strCod_sucur As String, ByVal strTipDoc As String,
                                                      ByVal strNumDoc As String, ByVal strLogin As String,
                                                      ByVal fechaHistoria As String, ByVal strTip_admision As String,
                                                      ByVal lano_adm As String, ByVal dnum_adm As String, Optional ByVal fec_ini As String = "",
                                                      Optional ByVal fec_fin As String = "", Optional ByVal AntHst As Boolean = True) As List(Of Familiares)

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim antFamiliares As Familiares
            Dim drDatos As IDataReader
            Dim listaFamiliares As New List(Of Familiares)

            gpmDataObj.setSQLSentence("HC_RPT_ANTECEDENTESFAMILIARES", CommandType.StoredProcedure)

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
                antFamiliares = New Familiares(drDatos("ANTECEDENTE").ToString)
                antFamiliares.NombreMedico = drDatos("PROFESIONAL").ToString
                antFamiliares.Fecha = drDatos("FECHA").ToString
                listaFamiliares.Add(antFamiliares)

            End While

            If drDatos.IsClosed = False Then
                drDatos.Close()
            End If

            Return listaFamiliares
        End Function

    End Class
End Namespace

