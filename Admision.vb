Imports Microsoft.Practices.EnterpriseLibrary.Data
Imports EnterpriseLibrary.Extensions.Data
Imports System.Data.Common


Namespace Sophia.HistoriaClinica.Reportes
    Public Class Admision

        Private _servicio As String
        Private _sucursal As String
        Private _numAdmision As String
        Private _cama As String
        Private _tipoCama As String
        Private _seccion As String
        Private _fechaIngreso As String
        Private _horaIngreso As String
        Private _idMedicoTratante As String
        Private _nombreMedicoTratante As String
        Private _idMedicoHospital As String
        Private _nombreMedicoHospital As String
        Private _entidad As String
        Private _autoriza As String
        Private _autorizacion As String
        Private _loginCreacion As String
        Private _clasificacion As String
        Private _paciente As Paciente
        Private _numAnticipo As String
        Private _valAnticipo As String
        Private _labelNumAnticipo As String
        Private _labelValAnticipo As String
        Private _login As String
        Private _fecha As String
        Private _ObsAdmision As String
        Private _copia As String

#Region "Propiedades"
        Public ReadOnly Property Servicio() As String
            Get
                Return _servicio
            End Get
        End Property
        Public ReadOnly Property Sucursal() As String
            Get
                Return _sucursal
            End Get
        End Property
        Public ReadOnly Property NumeroAdmision() As String
            Get
                Return _numAdmision
            End Get
        End Property
        Public ReadOnly Property Cama() As String
            Get
                Return _cama
            End Get
        End Property
        Public ReadOnly Property TipoCama() As String
            Get
                Return _tipoCama
            End Get
        End Property
        Public ReadOnly Property Seccion() As String
            Get
                Return _seccion
            End Get
        End Property
        Public ReadOnly Property FechaIngreso() As String
            Get
                Return _fechaIngreso
            End Get
        End Property
        Public ReadOnly Property HoraIngreso() As String
            Get
                Return _horaIngreso
            End Get
        End Property
        Public ReadOnly Property IDMedicoTratante() As String
            Get
                Return _idMedicoTratante
            End Get
        End Property
        Public ReadOnly Property NombreMedicoTratante() As String
            Get
                Return _nombreMedicoTratante
            End Get
        End Property
        Public ReadOnly Property IDMedicoHospital() As String
            Get
                Return _idMedicoHospital
            End Get
        End Property
        Public ReadOnly Property NombreMedicoHospital() As String
            Get
                Return _nombreMedicoHospital
            End Get
        End Property
        Public ReadOnly Property Entidad() As String
            Get
                Return _entidad
            End Get
        End Property
        Public ReadOnly Property Actualiza() As String
            Get
                Return _autoriza
            End Get
        End Property
        Public ReadOnly Property Actualizacion() As String
            Get
                Return _autorizacion
            End Get
        End Property
        Public ReadOnly Property LoginCreacion() As String
            Get
                Return _loginCreacion
            End Get
        End Property
        Public ReadOnly Property Clasificacion() As String
            Get
                Return _clasificacion
            End Get
        End Property
        Public ReadOnly Property Paciente() As Paciente
            Get
                Return _paciente
            End Get
        End Property
        Public ReadOnly Property NumeroAnticipo() As String
            Get
                Return _numAnticipo
            End Get
        End Property
        Public ReadOnly Property ValorAnticipo() As String
            Get
                Return _valAnticipo
            End Get
        End Property
        Public ReadOnly Property Login() As String
            Get
                Return _login
            End Get
        End Property
        Public ReadOnly Property Fecha() As String
            Get
                Return _fecha
            End Get
        End Property
        Public ReadOnly Property Observaciones() As String
            Get
                Return _ObsAdmision
            End Get
        End Property
        Public ReadOnly Property LabelNumAnticipo() As String
            Get
                Return _labelNumAnticipo
            End Get
        End Property
        Public ReadOnly Property LabelValAnticipo() As String
            Get
                Return _labelValAnticipo
            End Get
        End Property
        Public ReadOnly Property Copia() As String
            Get
                Return _copia
            End Get
        End Property


#End Region

        Public Function llenarAdmision(ByVal intAccion As Integer, ByVal strcod_pre_sgs As String, _
                                    ByVal strCod_sucur As String, ByVal strTipDoc As String, _
                                    ByVal strNumDoc As String, ByVal strTipAdm As String, _
                                    ByVal intAnoAdm As Integer, ByVal dNumAdm As Double, _
                                    ByVal strLogin As String) As Integer

            Dim cmd As DBCommandWrapper
            Dim iError As Integer
            Dim objPaciente As Paciente
            Dim dtDatosAdm As DataTable
            Dim dtAdmisionesAnt As DataTable

            dtDatosAdm = New DataTable
            dtAdmisionesAnt = New DataTable

            Try
                iError = traerDatosReimpresion(intAccion, strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strTipAdm, _
                                               intAnoAdm, dNumAdm, strLogin, dtDatosAdm, dtAdmisionesAnt, cmd)
            Catch ex As Exception
                Throw ex
            End Try

            If iError = 0 Then
                If dtDatosAdm.Rows.Count = 0 Then
                    Return 999
                End If
                objPaciente = crearPaciente(dtDatosAdm, dtAdmisionesAnt, cmd)
                inicializar(dtDatosAdm, objPaciente, cmd)
            End If

            Return iError
        End Function
        Private Function traerDatosReimpresion(ByVal intAccion As Integer, ByVal strcod_pre_sgs As String, _
                                    ByVal strCod_sucur As String, ByVal strTipDoc As String, _
                                    ByVal strNumDoc As String, ByVal strTipAdm As String, _
                                    ByVal intAnoAdm As Integer, ByVal dNumAdm As Double, _
                                    ByVal strLogin As String, ByRef dtDatosAdmision As DataTable, _
                                    ByRef dtAdmisionesAnteriores As DataTable, _
                                    ByRef cmd As DBCommandWrapper) As Integer
            Dim db As Database
            Dim dts As DataSet
            Dim dataFactory As DbProviderFactory


            dataFactory = DbProviderFactories.GetFactory("System.Data.SqlClient")
            db = DynamicDatabaseFactory.CreateDatabase("pruebasdesa", "sophia", "sophia", "sophia", DBProviderType.SqlServer)
            cmd = db.GetStoredProcCommandWrapper("pa_Reportes_ReImpAdmision")

            With cmd
                .AddInParameter("intAccion", DbType.Int32, intAccion)
                .AddInParameter("strCodPreSgs", DbType.String, strcod_pre_sgs)
                .AddInParameter("strCodSucur", DbType.String, strCod_sucur)
                .AddInParameter("strTipDoc", DbType.String, strTipDoc)
                .AddInParameter("strNumDoc", DbType.String, strNumDoc)
                .AddInParameter("strTipAdm", DbType.String, strTipAdm)
                .AddInParameter("intAnoAdm", DbType.Int32, intAnoAdm)
                .AddInParameter("dblNumAdm", DbType.Double, dNumAdm)
                .AddInParameter("intEntAdmadmen", DbType.Int32, 1)
                .AddInParameter("strFlagPrincipal", DbType.String, "S")
                .AddInParameter("strLogin", DbType.String, strLogin)
                .AddOutParameter("strAutorizacion", DbType.String, 28)
                .AddOutParameter("dblNumAnticipo", DbType.Double, 9)
                .AddOutParameter("dblValAnticipo", DbType.Double, 9)
                .AddOutParameter("intCantAdm", DbType.Int32, 4)
                .AddOutParameter("strTipoDocumento", DbType.String, 50)
                .AddOutParameter("strCarnet", DbType.String, 25)
                .AddOutParameter("lError", DbType.Int32, 4)
            End With

            dts = db.ExecuteDataSet(cmd)
            dtDatosAdmision = dts.Tables(0)
            dtAdmisionesAnteriores = dts.Tables(1)

            Return cmd.GetParameterValue("@lError")

        End Function
        Private Sub inicializar(ByVal dtDatosAdm As DataTable, ByVal objPaciente As Paciente, ByVal cmd As DBCommandWrapper)
            Dim fecha As Date

            If dtDatosAdm.Rows.Count > 0 Then
                With dtDatosAdm.Rows(0)
                    _servicio = .Item("servicio").ToString
                    _sucursal = .Item("sucursal").ToString
                    _numAdmision = .Item("admision").ToString
                    _cama = .Item("cama").ToString
                    _tipoCama = .Item("tip_cama").ToString
                    _seccion = .Item("seccion").ToString
                    fecha = .Item("fec_ingreso").ToString
                    _horaIngreso = .Item("hor_ingreso").ToString
                    _idMedicoTratante = .Item("med_trat").ToString
                    _nombreMedicoTratante = .Item("nom_med_tra").ToString
                    _idMedicoHospital = .Item("med_hos").ToString
                    _nombreMedicoHospital = .Item("nom_med_hos").ToString
                    _entidad = .Item("entidad").ToString
                    _autoriza = .Item("autoriza").ToString
                    _loginCreacion = .Item("login_creacion").ToString
                    _clasificacion = .Item("clasificacion").ToString
                    _paciente = objPaciente
                    _ObsAdmision = .Item("ObsAdmision").ToString
                End With
            End If

            If cmd.GetParameterValue("@strAutorizacion").ToString = "" Then
                _autorizacion = ""
            Else
                _autorizacion = cmd.GetParameterValue("@strAutorizacion").ToString
            End If

            If Len(cmd.GetParameterValue("@dblNumAnticipo").ToString) <= 0 Then
                _numAnticipo = ""
            Else
                _numAnticipo = cmd.GetParameterValue("@dblNumAnticipo")
            End If

            If Len(cmd.GetParameterValue("@dblValAnticipo").ToString) <= 0 Then
                _valAnticipo = ""
            Else
                _valAnticipo = cmd.GetParameterValue("@dblValAnticipo")
            End If


            If Left(_numAdmision, 1) = "H" Then
                _labelNumAnticipo = "NÚMERO ANTICIPO:"
                _labelValAnticipo = "VALOR ANTICIPO:"
            End If

            _login = cmd.GetParameterValue("@strLogin").ToString
            _fecha = Format(Now(), "dd/MMMM/yyyy hh:mm tt")
            _fechaIngreso = Format(fecha, "dd/MMMM/yyyy")
            _copia = "COPIA"

        End Sub

        Private Function crearPaciente(ByVal dtDatosAdm As DataTable, ByVal dtAdmisionesAnt As DataTable, _
                                       ByVal cmdDatosAdm As DBCommandWrapper) As Paciente


            Return New Paciente(dtDatosAdm, dtAdmisionesAnt, cmdDatosAdm.GetParameterValue("@intCantAdm"), _
                                cmdDatosAdm.GetParameterValue("@strTipoDocumento").ToString, cmdDatosAdm.GetParameterValue("@strCarnet").ToString)

        End Function

    End Class

End Namespace
