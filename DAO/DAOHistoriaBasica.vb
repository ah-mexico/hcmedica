Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion

Namespace Sophia.HistoriaClinica.DAO
    Public Class DAOHistoriaBasica
        Inherits GPMData
        ''TODO:Verificar si es necesario eliminar esta clase.
        '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
        '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007

        '' '' se comentarea el codigo ya que este metodo no esta siendo llamado por ninguna instancia en la aplicacion

        '' ''Public Function CrearEncabezadoHistoriaClinica(ByVal objConexion As Conexion, ByVal strCodPreSgs As String, ByVal strCodSucur As String, _
        '' ''                                               ByVal strTipDoc As String, ByVal strNumDoc As String, ByVal strTipAdm As String, ByVal intAnoAdm As Integer, _
        '' ''                                               ByVal dblNumAdm As Double, ByVal strTipoHistoria As String, ByVal strEntidad As String, _
        '' ''                                               ByVal strFechaHC As String, ByVal intHoraHC As Integer, ByVal intMinutoHC As Integer, _
        '' ''                                               ByVal strEspecialidad As String, ByVal strLogin As String) As Long

        '' ''    Dim db As Database
        '' ''    Dim command As DBCommandWrapper
        '' ''    Dim lError As Long


        '' ''    db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
        '' ''    command = db.GetStoredProcCommandWrapper("HC_CrearEncabezadoHistoriaClinica")
        '' ''    With command
        '' ''        .AddInParameter("strCodPreSgs", DbType.String, strCodSucur)
        '' ''        .AddInParameter("strCodSucur", DbType.String, strCodSucur)
        '' ''        .AddInParameter("strTipDoc", DbType.String, strTipDoc)
        '' ''        .AddInParameter("strNumDoc", DbType.String, strNumDoc)
        '' ''        .AddInParameter("strTipAdm", DbType.String, strTipAdm)
        '' ''        .AddInParameter("intAnnoAdm", DbType.Int16, intAnoAdm)
        '' ''        .AddOutParameter("dblNumAdm", DbType.Double, dblNumAdm)
        '' ''        .AddInParameter("strTipoHistoria", DbType.String, strTipoHistoria)
        '' ''        .AddInParameter("strEntidad", DbType.String, strEntidad)
        '' ''        .AddInParameter("strFechaHC", DbType.String, strFechaHC)
        '' ''        .AddInParameter("intHoraHC", DbType.Int16, intHoraHC)
        '' ''        .AddInParameter("intMinutoHC", DbType.Int16, intMinutoHC)
        '' ''        .AddInParameter("strEspecialidad", DbType.String, strEspecialidad)
        '' ''        .AddInParameter("strLogin", DbType.String, strLogin)
        '' ''        .AddOutParameter("lError", DbType.Int16, 4)
        '' ''    End With

        '' ''    db.ExecuteNonQuery(command)
        '' ''    lError = CType(command.GetParameterValue("@lError"), Long)

        '' ''    Return lError

        '' ''End Function
#Region "Alarmas"
        ''Alarmas Claudia Garay Sept 28 2010
        Public Function AlmacenarAlarmas(ByVal objconexion As Conexion, ByVal xmlAlarmas As String) As Long



            Dim lError As Long


            Me.setSQLSentence("HCENF_GrabarAlarmasXPac", CommandType.StoredProcedure)

            Me.addInputParameter("@txtXmlAlarma", SqlDbType.VarChar, xmlAlarmas)
            '=============
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()
            lError = Me.Parameters("lError").Value

            Return lError
        End Function
        ''Alarmas Claudia Garay Sept 28 2010
        Public Function ConsultarAlarmasXPac(ByVal objconexion As Conexion, ByVal strPrestador As String, ByVal strSucur As String, ByVal TipAdmision As String, _
                                                ByVal Ano_adm As String, ByVal Num_Adm As String, ByVal tip_doc As String, ByVal num_doc As String) As DataSet
            Dim dsdatos As DataSet

            Me.setSQLSentence("HCENF_ConsultaAlarmasXPac", CommandType.StoredProcedure)
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strPrestador)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strSucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, TipAdmision)
            Me.addInputParameter("ano_adm", SqlDbType.VarChar, Ano_adm)
            Me.addInputParameter("num_adm", SqlDbType.VarChar, Num_Adm)
            Me.addInputParameter("tip_doc", SqlDbType.VarChar, tip_doc)
            Me.addInputParameter("num_doc", SqlDbType.VarChar, num_doc)

            dsdatos = Me.execDS()

            Return dsdatos

        End Function
        ''Alarmas Claudia Garay Sept 28 2010
        Public Function ConsultarHistoricoAlarmasXPac(ByVal objconexion As Conexion, ByVal cod_historia As String) As DataSet
            Dim dsdatos As DataSet

            Me.setSQLSentence("HCENF_ConsultaHistoricoAlarmasXPac", CommandType.StoredProcedure)
            Me.addInputParameter("cod_historia", SqlDbType.VarChar, cod_historia)
            dsdatos = Me.execDS()

            Return dsdatos

        End Function
        ''Claudia Garay Acreditacion Residente marzo 2011
        Public Function ConsultarDatosMedico(ByVal objconexion As Conexion, ByVal Nombre As String, ByVal Apellido As String, ByVal tip_empleado As String, ByVal intaccion As Integer) As DataTable
            Dim dsdatos As DataTable

            Me.setSQLSentence("HC_ConsultarNombreMedico", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("@Nombres", SqlDbType.VarChar, Nombre)
            Me.addInputParameter("@Apellidos", SqlDbType.VarChar, Apellido)
            Me.addInputParameter("@tip_empleado", SqlDbType.VarChar, tip_empleado)
            Me.addInputParameter("@intaccion", SqlDbType.VarChar, intaccion)
            dsdatos = Me.execDT()

            Return dsdatos

        End Function

        ''Claudia Garay Acreditacion Residente Abril 2011
        Public Function AlmacenaMedicoResidente(ByVal objconexion As Conexion, ByVal Prestador As String, ByVal Sucursal As String, ByVal TipAdmision As String, _
        ByVal AnoAdm As Integer, ByVal NumAdm As Decimal, ByVal TipDoc As String, ByVal NumDoc As String, ByVal Medico As String, ByVal Residente As String, _
        ByVal login As String, ByVal Obs As String) As Long

            Dim lError As Long

            Me.setSQLSentence("HC_GuardarMedicoResidente", CommandType.StoredProcedure)
            Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, Prestador)
            Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, Sucursal)
            Me.addInputParameter("@tip_admision", SqlDbType.VarChar, TipAdmision)
            Me.addInputParameter("@ano_adm", SqlDbType.Int, AnoAdm)
            Me.addInputParameter("@num_adm", SqlDbType.Decimal, NumAdm)
            Me.addInputParameter("@tip_doc", SqlDbType.VarChar, TipDoc)
            Me.addInputParameter("@num_doc", SqlDbType.VarChar, NumDoc)
            Me.addInputParameter("@medico", SqlDbType.VarChar, Medico)
            Me.addInputParameter("@residente", SqlDbType.VarChar, Residente)
            Me.addInputParameter("@login", SqlDbType.VarChar, login)
            Me.addInputParameter("@obs", SqlDbType.VarChar, Obs)
            Me.addInputParameter("@Error", SqlDbType.VarChar, lError)
            Me.Exec()
            lError = Me.Parameters("@Error").Value
            Return lError

        End Function
        ''Auditoria de apertura y cierres de historia
        ''Claudia Garay 
        ''Abril 5 de 2011
        Public Function AuditoriaAperturaHC(ByVal objconexion As Conexion, ByVal cod_historia As Decimal, ByVal strPrestador As String, ByVal strSucur As String, ByVal TipAdmision As String, _
                                        ByVal Ano_adm As String, ByVal Num_Adm As String, ByVal medico As String, ByVal estado As String, ByVal obs As String) As Long
            Dim lError As Long

            Me.setSQLSentence("hc_ingresatablaAuditAperturaHC", CommandType.StoredProcedure)
            Me.addInputParameter("@cod_historia", SqlDbType.Decimal, cod_historia)
            Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, strPrestador)
            Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, strSucur)
            Me.addInputParameter("@tip_admision", SqlDbType.VarChar, TipAdmision)
            Me.addInputParameter("@ano_adm", SqlDbType.Int, Ano_adm)
            Me.addInputParameter("@num_adm", SqlDbType.Decimal, Num_Adm)
            Me.addInputParameter("@medico", SqlDbType.VarChar, medico)
            Me.addInputParameter("@estado", SqlDbType.VarChar, estado)
            Me.addInputParameter("@obs", SqlDbType.VarChar, obs)
            Me.addInputParameter("@Error", SqlDbType.Int, lError)
            Me.Exec()
            lError = Me.Parameters("@Error").Value

            Return lError

        End Function
        ''Alarmas Claudia Garay Sept 28 2010
        Public Function ConsultarRecomendacionesFarmaco(ByVal tip_doc As String, ByVal num_doc As String) As DataTable
            Dim dtdatos As DataTable

            Me.setSQLSentence("hc_RecomendacionesFarmaco", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("tip_doc", SqlDbType.VarChar, tip_doc)
            Me.addInputParameter("num_doc", SqlDbType.VarChar, num_doc)
            Me.addInputParameter("recomendacion", SqlDbType.VarChar, "")
            Me.addInputParameter("login", SqlDbType.VarChar, "")
            Me.addInputParameter("intaccion", SqlDbType.VarChar, 1)

            dtdatos = Me.execDT()

            Return dtdatos

        End Function
#End Region


        ''Alejandro Sanabria Consulta Servicio Marzo 2012
        Public Function CargarServicio(ByVal objconexion As Conexion, ByVal strTip_servicio As String, ByVal strServicio As String, ByRef o_lError As Long) As DataTable
            Dim dsdatos As DataTable

            Me.setSQLSentence("DB_CargarServicioSP", CommandType.StoredProcedure)
            Me.addInputParameter("@strCodpresgs", SqlDbType.VarChar, "1100109887")
            Me.addInputParameter("@strCodsucur", SqlDbType.VarChar, "0003")
            Me.addInputParameter("@strTipoServ", SqlDbType.VarChar, strTip_servicio)
            Me.addInputParameter("@strNombreServ", SqlDbType.VarChar, strServicio)
            dsdatos = Me.execDT()

            Return dsdatos

        End Function
        ''Alejandro Sanabria Consulta Servicio Marzo 2012
        Public Function CargarTipDocAlias(ByVal objconexion As Conexion, ByVal strTip_Doc As String, ByRef o_lError As Long) As DataTable
            Dim dsdatos As DataTable

            Me.setSQLSentence("DB_CargarTipDocAlias", CommandType.StoredProcedure)
            Me.addInputParameter("@strTipoDoc", SqlDbType.VarChar, strTip_Doc)
            dsdatos = Me.execDT()

            Return dsdatos

        End Function

        ''Se crea metodo para obtener diferencia de dias entre dos fechas - dsanchez 11/09/2017
        Public Function ObtenerDiferenciaDias(ByVal fechaInicial As String, ByVal fechaFinal As String) As Integer

            Dim resultado As Integer = 0

            Me.setSQLSentence("SELECT DATEDIFF(DAY, '" + fechaInicial + "', '" + fechaFinal + "') AS DIF", CommandType.Text)

            resultado = Me.executeScalar()

            Return resultado

        End Function

        ''Se crea metodo para obtener el peso del paciente - dsanchez 30/08/2017 
        Public Function ObtenerPesoPaciente(ByVal prestador As String, ByVal sucursal As String, ByVal numAdmision As Double, ByVal anoAdmision As Integer, ByVal tipAdmision As String) As DataTable

            Dim dtInfo As DataTable = New DataTable

            Me.setSQLSentence("SELECT peso FROM hcsigvitales WHERE num_adm = " + CInt(numAdmision).ToString() +
                                            " AND ano_adm = " + anoAdmision.ToString() +
                                            " AND tip_admision = '" + tipAdmision +
                                            "' AND cod_pre_sgs = '" + prestador +
                                            "' AND cod_sucur = '" + sucursal + "'", CommandType.Text)

            dtInfo = Me.execDT()

            Return dtInfo

        End Function


        ''Se crea metodo para obtener la edad del paciente - dsanchez 15/09/2017
        Public Function ObtenerEdadPaciente(ByVal prestador As String, ByVal sucursal As String, ByVal numAdmision As Double, ByVal anoAdmision As Integer, ByVal tipAdmision As String) As Integer

            Dim resultado As Integer = 0

            Me.setSQLSentence("SELECT edad FROM ADMMOVIM WHERE num_adm = " + numAdmision.ToString() +
                                            " AND ano_adm = " + anoAdmision.ToString() +
                                            " AND tip_admision = '" + tipAdmision +
                                            "' AND cod_pre_sgs = '" + prestador +
                                            "' AND cod_sucur = '" + sucursal + "'", CommandType.Text)

            resultado = Me.executeScalar()

            Return resultado

        End Function

        ''' <summary>
        ''' Consulta las admisiones de un paciente a nivel nacional que tenga permiso en la tabla de parametrización  sos.AUTORIZACION_SUCURSAL_REGION
        ''' </summary>
        ''' <param name="objconexion"></param>
        ''' <param name="strTip_Doc"></param>
        ''' <param name="strNum_Doc"></param>
        ''' <param name="dFechaInicial"></param>
        ''' <param name="dFechaFinal"></param>
        ''' <param name="o_lError"></param>
        ''' <returns>Creado 20210325 por Raul Cruz</returns>
        Public Function ConsultaAdminNacional(ByVal objconexion As Conexion, ByVal strTip_Doc As String,
                                              ByVal strNum_Doc As String, ByVal dFechaInicial As Date,
                                              ByVal dFechaFinal As Date, ByVal strSucursal As String,
                                              ByVal strPrestador As String, ByRef o_lError As Long) As DataTable
            Dim dsdatos As New DataTable
            Try
                Me.setSQLSentence("HC_ConsultarAdmisionesxBD", CommandType.StoredProcedure)
                Me.addInputParameter("@strTip_Doc", SqlDbType.VarChar, strTip_Doc)
                Me.addInputParameter("@strNum_Doc", SqlDbType.VarChar, strNum_Doc)
                Me.addInputParameter("@dFechaInicial", SqlDbType.Date, dFechaInicial)
                Me.addInputParameter("@dFechaFinal", SqlDbType.Date, dFechaFinal)
                Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, strSucursal)
                Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, strPrestador)

                dsdatos = Me.execDT()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Return dsdatos

        End Function

        ''' <summary>
        ''' Consulta las admisiones de un paciente a nivel nacional que tenga permiso en la tabla de parametrización  sos.AUTORIZACION_SUCURSAL_REGION
        ''' </summary>
        ''' <param name="objconexion"></param>
        ''' <param name="strTip_Doc"></param>
        ''' <param name="strNum_Doc"></param>
        ''' <param name="dFechaInicial"></param>
        ''' <param name="dFechaFinal"></param>
        ''' <param name="o_lError"></param>
        ''' <returns>Creado 20210325 por Raul Cruz</returns>
        Public Function ConsultaAdminNacional_HCEnf(ByVal objconexion As Conexion, ByVal strTip_Doc As String,
                                              ByVal strNum_Doc As String, ByVal dFechaInicial As Date,
                                              ByVal dFechaFinal As Date, ByVal strSucursal As String,
                                              ByVal strPrestador As String, ByRef o_lError As Long) As DataTable
            Dim dsdatos As DataTable

            Me.setSQLSentence("HCEnf_ConsultarAdmisionesxBD", CommandType.StoredProcedure)
            Me.addInputParameter("@strTip_Doc", SqlDbType.VarChar, strTip_Doc)
            Me.addInputParameter("@strNum_Doc", SqlDbType.VarChar, strNum_Doc)
            Me.addInputParameter("@dFechaInicial", SqlDbType.Date, dFechaInicial)
            Me.addInputParameter("@dFechaFinal", SqlDbType.Date, dFechaFinal)
            Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, strSucursal)
            Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, strPrestador)

            dsdatos = Me.execDT()

            Return dsdatos

        End Function

        'Inicia: INDRA/OJPARRA  04/03/2022
        'Proyecto: Sophia - Conciliación Medicamentos (VISUALIZAR CONCILIACIÓN DE MEDICAMENTOS EN ANTECEDENTES FARMACOLOGICOS CU1)
        'Cambio: Consulta de la unidad de medida para Antecedentes Farmacológicos.
        Public Function ConsultarUnidadMedida(ByVal objConexion As Conexion) As DataTable

            Dim dtTable As DataTable
            Me.setSQLSentence("select concentracion, descripcion from genconcentracion (nolock) where estado='A' order by descripcion", CommandType.Text)
            dtTable = Me.execDT()

            Return dtTable

        End Function

        'Inicia: INDRA/OJPARRA  04/03/2022
        'Proyecto: Sophia - Conciliación Medicamentos (VISUALIZAR CONCILIACIÓN DE MEDICAMENTOS EN ANTECEDENTES FARMACOLOGICOS CU1)
        'Cambio: Consulta de la Via de administración para Antecedentes Farmacológicos.
        Public Function ConsultarViasAdmin(ByVal objConexion As Conexion) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("select via, descripcion from genViaAdministracion (NOLOCK) where estado = 'A'  order by descripcion", CommandType.Text)
            dtTable = Me.execDT()

            Return dtTable
        End Function

        'Inicia: INDRA/OJPARRA  04/03/2022
        'Proyecto: Sophia - Conciliación Medicamentos (VISUALIZAR CONCILIACIÓN DE MEDICAMENTOS EN ANTECEDENTES FARMACOLOGICOS CU1)
        'Cambio: Consulta de la Frecuencia para Antecedentes Farmacológicos.
        Public Function ConsultarFrecuencia(ByVal objConexion As Conexion) As DataTable
            Dim dtTable As DataTable
            'Se ajusta ordenamiento de la lista descripción a orden como se esta enviando en frecuecia Orden médica. INDRA/OJPARRA 24/004/2022
            Dim strConsulta As String = "SELECT frecuencia, descripcion,CadaNroHoras FROM genFrecAdministracion (NOLOCK) WHERE estado='A'  order by orden"
            Me.setSQLSentence(strConsulta, CommandType.Text)
            dtTable = Me.execDT()

            Return dtTable
        End Function

    End Class
   
End Namespace