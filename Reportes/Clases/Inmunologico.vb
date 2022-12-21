Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic

Namespace Sophia.HistoriaClinica.Reportes
    Public Class Inmunologico
        Inherits Antecedente

        Private _vacuna As String
        Public Property Vacuna() As String
            Get
                Return _vacuna
            End Get
            Set(ByVal Value As String)
                _vacuna = Value
            End Set
        End Property

        Private _dosis As String
        Public Property Dosis() As String
            Get
                Return _dosis
            End Get
            Set(ByVal Value As String)
                _dosis = Value
            End Set
        End Property

        Private _ano As String
        Public Property Ano() As string
            Get
                Return _ano
            End Get
            Set(ByVal Value As String)
                _ano = Value
            End Set
        End Property

        Private _mes As String
        Public Property Mes() As String
            Get
                Return _mes
            End Get
            Set(ByVal Value As String)
                _mes = Value
            End Set
        End Property

        ''' <summary>
        ''' constructor por defecto de la clase.
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal vacuna As String, ByVal dosis As String, _
                       ByVal ano As String, ByVal mes As Integer, _
                       ByVal obs As String)

            _vacuna = vacuna
            _dosis = dosis
            If Not String.IsNullOrEmpty(ano) Then
                If CInt(ano) <= 0 Then
                    ano = ""
                End If
            End If
            _ano = ano
            If mes < 1 Or mes > 12 Then
                _mes = ""
            Else
                _mes = mes
            End If
            Observaciones = obs

        End Sub

        Public Function consultarAntInmunologico(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, _
                   ByVal strCod_sucur As String, ByVal strTipDoc As String, _
                   ByVal strNumDoc As String, ByVal strLogin As String, _
                   ByVal fechaHistoria As String, ByVal strTip_admision As String, ByVal lano_adm As String, _
                   ByVal dnum_adm As String, Optional ByVal fec_ini As String = "", _
                   Optional ByVal fec_fin As String = "") As List(Of Inmunologico)

            Dim cont As Integer
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim I As Integer
            Dim antInmunologico As Inmunologico
            Dim drDatos As IDataReader
            Dim listaInmunologicos As New List(Of Inmunologico)

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)

            '' ''command = db.GetStoredProcCommandWrapper("pa_Reportes_AntecedentesInmunologicos")

            '' ''With command
            '' ''    .AddInParameter("strTipDoc", DbType.String, strTipDoc)
            '' ''    .AddInParameter("strNumDoc", DbType.String, strNumDoc)
            '' ''    .AddInParameter("strLogin", DbType.String, strLogin)
            '' ''    .AddInParameter("fechaHistoria", DbType.String, fechaHistoria)
            '' ''End With

            '' ''drDatos = db.ExecuteReader(command)
            gpmDataObj.setSQLSentence("pa_Reportes_AntecedentesInmunologicos", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("strTipDoc", SqlDbType.VarChar, strTipDoc)
            gpmDataObj.addInputParameter("strNumDoc", SqlDbType.VarChar, strNumDoc)
            gpmDataObj.addInputParameter("strLogin", SqlDbType.VarChar, strLogin)
            gpmDataObj.addInputParameter("fechaHistoria", SqlDbType.VarChar, fechaHistoria)
            gpmDataObj.addInputParameter("Tip_adm", SqlDbType.VarChar, strTip_admision)
            gpmDataObj.addInputParameter("ano_adm", SqlDbType.VarChar, lano_adm)
            gpmDataObj.addInputParameter("num_adm", SqlDbType.VarChar, dnum_adm)
            If fec_fin <> "" Or fec_fin <> "" Then
                gpmDataObj.addInputParameter("fec_ini", SqlDbType.DateTime, fec_ini)
                gpmDataObj.addInputParameter("fec_fin", SqlDbType.DateTime, fec_fin)
            Else
            End If

            drDatos = gpmDataObj.ExecRdr()
            I = 1
            While drDatos.Read()
                If I = 1 Then
                    ''Se asegura que todas las dosis sean impresas en el reporte
                    For cont = 1 To 6
                        antInmunologico = New Inmunologico("VACUNAS", cont.ToString, "", 0, "")
                        listaInmunologicos.Add(antInmunologico)
                    Next cont
                End If
                antInmunologico = New Inmunologico(drDatos("vDescripcion").ToString, drDatos("dosis").ToString, _
                                                   drDatos("ano_dosis").ToString, CInt(drDatos("mes_dosis").ToString), drDatos("obs").ToString)
                antInmunologico.TipoDocumentoMedico = drDatos("tipoDocMedico").ToString
                antInmunologico.NumeroDocumentoMedico = drDatos("numDocMedico").ToString
                antInmunologico.NombreMedico = drDatos("NombreMedico").ToString
                antInmunologico.Fecha = drDatos("fechaHC").ToString
                listaInmunologicos.Add(antInmunologico)
                I = 2
            End While

            If drDatos.IsClosed = False Then
                drDatos.Close()
            End If

            '' ''command.Command.Connection.Close()
            '' ''command.Command.Connection.Dispose()

            Return listaInmunologicos

        End Function

    End Class
End Namespace

