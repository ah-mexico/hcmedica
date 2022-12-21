Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente

Namespace Sophia.HistoriaClinica.BL

    ''' -----------------------------------------------------------------------------
    ''' Project	 : HistoriClinica.BL.BLBasicasLocales
    ''' Class	 : Sophia.HistoriaClinica.BL.BLBasicasGenerales
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Clase BLBasicasGenerales del namespace Sophia.HistoriaClinica.BL
    ''' que es la clase data de HistoriaClinica.BL
    ''' y será usada desde la aplicación WinForms 2005
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' -----------------------------------------------------------------------------

    Public Class BLValoracioneIngreso

        '// Evalua Si Existe Registro con estos valores en las tabla HC_CpVal_Inicial
        ''WACHV, 27-DIC-2106
        ''WACHV, 27-ENE-2107, Se agrega que valide el Ws primero y luego con la bd local, segun req adicionales.
        Public Shared Function intAlarmaPaliativo(ByVal objGeneral As Sophia.HistoriaClinica.DatosGenerales.Generales, ByVal objPaciente As DatosPaciente.Paciente) As Integer
            Dim dt As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
            Dim oValoraciondeIngreso As New ValoraciondeIngreso()
            Dim oURValoraciondeIngreso As New ValoraciondeIngreso()
            Try
                'Si existe una respuesta del servicio prima la respuesta del servicio
                'En Caso Contrario prima la respuesta de Sophia
                oURValoraciondeIngreso = oValoraciondeIngreso.SugerirRespuesta(objGeneral, objPaciente)
            Catch ex As Exception
            Finally
            End Try

            Try
                If Not (oURValoraciondeIngreso.IngPrograma = Nothing) Then
                    'Si trae el Ws, la fecha significa que ya fue ingresado en Avicena
                    If oURValoraciondeIngreso.IngPrograma.Substring(oURValoraciondeIngreso.IngPrograma.Length - 1).Contains("1") Then
                        intAlarmaPaliativo = 1 'SI Fue Ingresado en Ws
                    Else
                        intAlarmaPaliativo = 0 'No Fue Ingresado en Ws
                    End If
                Else 'Si no trae, se verifica si existe en Sophia, como se venia haciendo
                    dt = obj.ConsultarConsultarEstadoPaliativo(objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
                    If dt.Rows.Count > 0 Then 'Existe como Ingresado
                        If dt.Rows(0).Item("ESTADO").ToString() = "I" Then
                            intAlarmaPaliativo = 1 'No Existe esta Ingresado
                        Else 'Existe como Egresado
                            intAlarmaPaliativo = 0 ' Egresado
                        End If
                    Else 'No Existe equivale a No Ingresado, (Egresado)
                        intAlarmaPaliativo = 0
                    End If
                End If

            Catch ex As Exception
                Throw (ex)
            End Try

        End Function

    End Class


End Namespace
