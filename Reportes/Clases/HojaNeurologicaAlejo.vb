Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    ''' <summary>
    ''' Clase que encapsula los datos de una nota de evolucion
    ''' </summary>
    ''' <remarks></remarks>
    Public Class HojaNeurologica
        Inherits GPMDataReport


        Public Function consultarTraerHojaNeurologica(ByVal objConexion As Conexion, ByVal dCod_Historia As Decimal, ByVal strFechaIni As Nullable(Of Date), ByVal strFechaFin As Nullable(Of Date), ByVal iHoraIni As Nullable(Of Integer), ByVal iHoraFin As Nullable(Of Integer)) As DataTable
            Dim lError As Long = 0

            gpmDataObj.setSQLSentence("HCENF_TraerHojaNeurologica", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("@intCodhistoria", SqlDbType.Int, dCod_Historia)
            gpmDataObj.addInputParameter("@strFechaIni", SqlDbType.DateTime, strFechaIni)
            gpmDataObj.addInputParameter("@strFechaFin", SqlDbType.DateTime, strFechaFin)
            gpmDataObj.addInputParameter("@iHoraIni", SqlDbType.Int, iHoraIni)
            gpmDataObj.addInputParameter("@iHoraFin", SqlDbType.Int, iHoraFin)
            gpmDataObj.addInputParameter("lError", SqlDbType.Int, lError)

            Return gpmDataObj.execDT
        End Function

    End Class
End Namespace