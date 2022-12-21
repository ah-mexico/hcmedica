Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    Public Class Vacunacion
        Inherits Antecedente

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal strAntecedente As String, ByVal Profesional As String)

            Antecedente = strAntecedente
            NombreMedico = Profesional
        End Sub

        Public Function consultaAntVacunaciones(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
                   ByVal strCod_sucur As String, ByVal strTipDoc As String,
                   ByVal strNumDoc As String, ByVal strLogin As String,
                   ByVal fechaHistoria As String, ByVal strTip_admision As String, ByVal lano_adm As String,
                   ByVal dnum_adm As String, Optional ByVal fec_ini As String = "",
                   Optional ByVal fec_fin As String = "") As List(Of Vacunacion)

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007

            Dim antVacunacion As Vacunacion
            Dim drDatos As IDataReader
            Dim listaVacunaciones As New List(Of Vacunacion)

            gpmDataObj.setSQLSentence("HC_RPT_VACUNACION", CommandType.StoredProcedure)

            'gpmDataObj.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            'gpmDataObj.addInputParameter("cod_sucur", SqlDbType.VarChar, strCod_sucur)
            'gpmDataObj.addInputParameter("tip_admision", SqlDbType.VarChar, strTip_admision)
            'gpmDataObj.addInputParameter("ano_adm", SqlDbType.Int, lano_adm)
            'gpmDataObj.addInputParameter("num_adm", SqlDbType.Decimal, dnum_adm)
            gpmDataObj.addInputParameter("TIPDOC", SqlDbType.VarChar, strTipDoc)
            gpmDataObj.addInputParameter("NUMDOC", SqlDbType.VarChar, strNumDoc)
            If fec_fin <> "" Or fec_fin <> "" Then
                gpmDataObj.addInputParameter("FEC_INI", SqlDbType.DateTime, fec_ini)
                gpmDataObj.addInputParameter("FEC_FIN", SqlDbType.DateTime, fec_fin)
            Else
                gpmDataObj.addInputParameter("FEC_INI", SqlDbType.DateTime, Nothing)
                gpmDataObj.addInputParameter("FEC_FIN", SqlDbType.DateTime, Nothing)
            End If

            drDatos = gpmDataObj.ExecRdr()

            While drDatos.Read()
                antVacunacion = New Vacunacion(drDatos("VACUNACION").ToString, drDatos("PROFESIONAL").ToString)

                'With antVacunacion
                '    .NombreMedico = drDatos("Medico").ToString
                '    .Fecha = drDatos("Fecha_Ant").ToString
                'End With
                listaVacunaciones.Add(antVacunacion)

            End While

            If drDatos.IsClosed = False Then
                drDatos.Close()
            End If

            Return listaVacunaciones
        End Function


    End Class
End Namespace
