Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    Public Class HistoriaClinica
        Private _encabezado As HCEncabezado
        Private _motivoConsulta As MotivoConsulta


#Region "Propiedades"
        Public Property Encabezado() As HCEncabezado
            Get
                Return _encabezado
            End Get
            Set(ByVal Value As HCEncabezado)
                _encabezado = Value
            End Set
        End Property
        Public Property MotivoConsulta() As MotivoConsulta
            Get
                Return _motivoConsulta
            End Get
            Set(ByVal Value As MotivoConsulta)
                _motivoConsulta = Value
            End Set
        End Property

#End Region

        Public Sub New()
            _encabezado = New HCEncabezado()
            _motivoConsulta = New MotivoConsulta()
        End Sub

        Public Sub consultarHistoriaClinica(ByVal strcod_pre_sgs As String, _
                   ByVal strCod_sucur As String, ByVal strTip_admision As String, _
                   ByVal lano_adm As Long, ByVal dnum_adm As Double, _
                   ByVal strCod_medico As String, ByVal strEspecialidad As String, _
                   ByVal strTip_historia As String, ByVal strTipoAcceso As String)

            Dim drSecciones As DbDataReader

            Try
                _encabezado.consultarHcEncabezado(strcod_pre_sgs, strCod_sucur, _
                                                  strTip_admision, lano_adm, dnum_adm)

                drSecciones = consultarSecciones(strCod_medico, strEspecialidad, strTip_historia, strTipoAcceso)

                If drSecciones.IsClosed = True Then
                    Throw New Exception("No exiten secciones configuradas.")
                End If

                While drSecciones.Read()
                    Select Case CInt(drSecciones("seccion").ToString)
                        Case Secciones.MotivoConsulta
                            _motivoConsulta.consultarMotivoConsulta(strcod_pre_sgs, strCod_sucur, _
                                                                    strTip_admision, lano_adm, dnum_adm)
                            _motivoConsulta.Visible = True
                        Case Else

                    End Select
                End While

            Catch ex As Exception
                Throw ex
            End Try

        End Sub

        Public Function consultarSecciones(ByVal strCod_medico As String, ByVal strEspecialidad As String, _
                   ByVal strTip_historia As String, ByVal strTipoAcceso As String) As DbDataReader

            Dim db As Database
            Dim command As DbCommand = Nothing
            Dim drSecciones As DbDataReader

            Try
                db = DatabaseFactory.CreateDatabase()
                command = db.GetStoredProcCommand("pa_Reportes_SeccionesHC")

                db.AddInParameter(command, "strCod_medico", DbType.String, strCod_medico)
                db.AddInParameter(command, "strEspecialidad", DbType.String, strEspecialidad)
                db.AddInParameter(command, "strTip_historia", DbType.String, strTip_historia)
                db.AddInParameter(command, "strTipoAcceso", DbType.String, strTipoAcceso)

                drSecciones = db.ExecuteReader(command)

            Catch ex As Exception
                Throw ex
            Finally
                If command Is Nothing Then
                    command.Connection.Close()
                    command.Connection.Dispose()
                End If
            End Try

            Return drSecciones

        End Function

        Enum Secciones
            ListaEspera = 1
            MotivoConsulta = 11
            AntecedentesPatologicos = 121
            AntecedentesGinecologicos = 122
            AntecedentesQuirurgicos = 123
            AntecedentesAlergicos = 124
            AntecedentesInmunologicos = 125
            AntecedentesToxicos = 126
            AntecedentesFamiliares = 13
            OtrosAntecedentes = 14
            ExamenFisico = 15
            ImpresionDiagnostica = 16
            Medicamentos = 171
            Procedimientos = 172
            Egreso = 18
            Evolucion = 19
        End Enum
    End Class
End Namespace

