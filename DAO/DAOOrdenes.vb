Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion

Namespace Sophia.HistoriaClinica.DAO
    Public Class DAOOrdenes
        Inherits GPMData

        Public Function consultarTiposDieta(ByVal objConexion As Conexion) As DataTable
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetSqlStringCommandWrapper("select tipDieta, descripcion from nuttipdieta")
            Dim dtTable As DataTable
            Me.setSQLSentence("select tipDieta, descripcion from nuttipdieta (nolock) WHERE estado = 'A' ", CommandType.Text)
            dtTable = Me.execDT()

            Return dtTable

        End Function

        ''Claudia Garay julio 19 de 2010
        Public Function consultarTiposOrden(ByVal objConexion As Conexion) As DataTable
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetSqlStringCommandWrapper("select tipDieta, descripcion from nuttipdieta")
            Dim dtTable As DataTable
            Me.setSQLSentence("select Orden, descripcion from hcgenorden (nolock)", CommandType.Text)
            dtTable = Me.execDT()

            Return dtTable

        End Function
        Public Function consultarUnidadMedida(ByVal objConexion As Conexion) As DataTable
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetSqlStringCommandWrapper("select concentracion, descripcion from genconcentracion")
            Dim dtTable As DataTable
            Me.setSQLSentence("select concentracion, descripcion from genconcentracion (nolock) where estado='A' order by descripcion", CommandType.Text)
            dtTable = Me.execDT()

            Return dtTable

        End Function

        Public Function consultarRIS(ByVal objconexion As Conexion, ByVal codigo As String, ByRef codigo_RIS As String, ByRef nombre_RIS As String) As Boolean
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetSqlStringCommandWrapper("select concentracion, descripcion from genconcentracion")
            Dim dtTable As DataTable
            'Me.setSQLSentence("select codigo_RIS, nombre_RIS from genproce(nolock) where procedim = '" & codigo & "'", CommandType.Text)
            '--Joseph G. Moreno Campos (IG) Fec:2018/12/05 cambio tabla Genproce -> VW_GENPROCE_DES Proy:Codificación
            Me.setSQLSentence("select codigo_RIS, nombre_RIS from VW_GENPROCE_DES(nolock) where procedim = '" & codigo & "'" & String.Format(" AND CONVERT(DATE, '{0}') BETWEEN fec_ini_proce AND fec_fin_proce ", DateTime.Now), CommandType.Text)
            dtTable = Me.execDT()
            codigo_RIS = IIf(IsDBNull(dtTable.Rows(0)("codigo_RIS")), "", dtTable.Rows(0)("codigo_RIS"))
            nombre_RIS = IIf(IsDBNull(dtTable.Rows(0)("nombre_RIS")), "", dtTable.Rows(0)("nombre_RIS"))

            Return True
        End Function

        Public Function consultarViasAdmin(ByVal objConexion As Conexion) As DataTable
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetSqlStringCommandWrapper("select via, descripcion from genViaAdministracion")
            Dim dtTable As DataTable
            Me.setSQLSentence("select via, descripcion from genViaAdministracion (nolock) where estado = 'A' order by descripcion", CommandType.Text)
            dtTable = Me.execDT()

            Return dtTable
        End Function





        Public Function consultarFrecuencia(ByVal objConexion As Conexion) As DataTable
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetSqlStringCommandWrapper("select frecuencia, descripcion from genFrecAdministracion")

            ''Claudia Garay Se agrega condicion de estado='A' para que solo traiga las frecuencias activoas
            '' 05 octubre de 2010
            Dim dtTable As DataTable

            Dim strConsulta As String = "SELECT frecuencia, descripcion,CadaNroHoras FROM genFrecAdministracion (NOLOCK) WHERE estado='A' {0} {1}"
            Dim strCondicion As String = String.Empty

            If 1 = 0 Then ' Mientras se define si hay convivencia
                strCondicion = "AND frecuencia = 34"
            End If

            strConsulta = String.Format(strConsulta, strCondicion, " ORDER BY orden ")

            Me.setSQLSentence(strConsulta, CommandType.Text)
            dtTable = Me.execDT()

            Return dtTable
        End Function

        ''martovar ER_OSI_596_Indicaciones_Medicas 2017/09/25
        Public Function consultarTiempo(ByVal objConexion As Conexion) As DataTable

            Dim dtTable As DataTable
            Me.setSQLSentence("select cod_tiempo as id,desc_tiempo as descripcion from HC_Tiempo (nolock) where estado='A' order by desc_tiempo", CommandType.Text)
            dtTable = Me.execDT()

            Return dtTable
        End Function

        Public Function consultarConvenioMedicamento(ByVal objConexion As Conexion, ByVal codProducto As String, ByVal cod_pre_sgs As String,
                                                            ByVal cod_sucur As String, ByVal entidad As String) As Boolean

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            '' ''Dim numeroRegistros As Integer

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''Command = db.GetStoredProcCommandWrapper("HC_ConsultarConvenio")
            '' ''With Command()
            '' ''    .AddInParameter("strCodPreSgs", DbType.String, cod_pre_sgs)
            '' ''    .AddInParameter("strCodSucur", DbType.String, cod_sucur)
            '' ''    .AddInParameter("strProducto", DbType.String, codProducto)
            '' ''    .AddInParameter("strEntidad", DbType.String, entidad)
            '' ''End With

            '' ''numeroRegistros = db.ExecuteScalar(Command)

            Me.setSQLSentence("HC_ConsultarConvenio", CommandType.StoredProcedure)
            Me.addInputParameter("strCodPreSgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("strCodSucur", SqlDbType.VarChar, cod_sucur)
            Me.addInputParameter("strProducto", SqlDbType.VarChar, codProducto)
            Me.addInputParameter("strEntidad", SqlDbType.VarChar, entidad)

            If Integer.Parse(Me.executeScalar()) <= 0 Then
                Return False
            Else
                Return True
            End If

        End Function

        Public Function consultarConvenioProcedimiento(ByVal objConexion As Conexion, ByRef codProcedim As String, ByVal cod_pre_sgs As String,
                                                    ByVal cod_sucur As String, ByVal entidad As String,
                                                    ByRef procedimHomologo As String, ByVal cCosto As String) As Boolean
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            '' ''Dim numeroRegistros As Integer

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetStoredProcCommandWrapper("HC_ConsultarConvenioProcedim")
            '' ''With command
            '' ''    .AddInParameter("strCodPreSgs", DbType.String, cod_pre_sgs)
            '' ''    .AddInParameter("strCodSucur", DbType.String, cod_sucur)
            '' ''    .AddInParameter("strProcedim", DbType.String, codProcedim)
            '' ''    .AddInParameter("strEntidad", DbType.String, entidad)
            '' ''End With

            '' ''numeroRegistros = db.ExecuteScalar(command)
            '' ''If numeroRegistros <= 0 Then
            '' ''    Return False
            '' ''Else
            '' ''    Return True
            '' ''End If

            'Me.setSQLSentence("HC_ConsultarConvenioProcedim", CommandType.StoredProcedure)
            'Me.ClearParameters()
            'Me.addInputParameter("strCodPreSgs", SqlDbType.VarChar, cod_pre_sgs)
            'Me.addInputParameter("strCodSucur", SqlDbType.VarChar, cod_sucur)
            'Me.addInputParameter("strProcedim", SqlDbType.VarChar, codProcedim)            
            'Me.addInputParameter("strEntidad", SqlDbType.VarChar, entidad)
            'Me.addOutputParameter("strProcedimHomologo", SqlDbType.VarChar)
            'Me.Exec()

            'If Integer.Parse(Me.executeScalar()) <= 0 Then
            '    Return False
            'Else
            '    Return True
            'End If
            Dim generaPedido As String

            Me.setSQLSentence("HC_ConsultarConvenioProcedim", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs ", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, cod_sucur)
            Me.addInputParameter("procedim", SqlDbType.VarChar, codProcedim)
            Me.addOutputParameter("generaPedido", SqlDbType.VarChar, 1)
            Me.addOutputParameter("procedimHomologo", SqlDbType.VarChar, 9)
            Me.addInputParameter("entidad", SqlDbType.VarChar, entidad)
            Me.addInputParameter("ccosto", SqlDbType.VarChar, cCosto)
            Me.Exec()

            generaPedido = Me.Parameters("generaPedido").Value

            If generaPedido = "S" Then
                consultarConvenioProcedimiento = True
            Else
                consultarConvenioProcedimiento = False
            End If
            procedimHomologo = IIf(IsDBNull(Me.Parameters("procedimHomologo").Value), "", Me.Parameters("procedimHomologo").Value)

        End Function

        Public Function consultarCcostoLabo(ByVal objConexion As Conexion, ByRef Ccosto As String, ByVal cod_pre_sgs As String,
                                                    ByVal cod_sucur As String) As Boolean
            Dim generaPedido As String

            Me.setSQLSentence("HC_ConsultarCcostoLabo", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs ", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, cod_sucur)
            Me.addInputParameter("Ccosto", SqlDbType.VarChar, Ccosto)
            Me.addOutputParameter("Ccostolabo", SqlDbType.VarChar, 1)
            Me.Exec()

            generaPedido = Me.Parameters("Ccostolabo").Value

            If generaPedido = "S" Then
                consultarCcostoLabo = True
            Else
                consultarCcostoLabo = False
            End If
        End Function

        Public Function consultarADmAdmEntRec(ByVal objConexion As Conexion, ByRef cod_pre_sgs As String, ByVal cod_sucur As String,
                                              ByVal strTip_Admision As String, ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double,
                                              ByVal Entidad As String) As Boolean
            Dim generaPedido As String

            Me.setSQLSentence("HC_ConsultarAdmAdmEntEntrecobrable", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs ", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, cod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, strTip_Admision)
            Me.addInputParameter("iAno_adm", SqlDbType.Int, strAno_Adm)
            Me.addInputParameter("num_adm", SqlDbType.Int, strNum_Adm)
            Me.addInputParameter("strEntidad", SqlDbType.VarChar, Entidad)
            Me.addOutputParameter("strentidadrec", SqlDbType.VarChar, 1)
            Me.Exec()

            generaPedido = Me.Parameters("strentidadrec").Value

            If generaPedido = "S" Then
                consultarADmAdmEntRec = True
            Else
                consultarADmAdmEntRec = False
            End If
        End Function

        Public Function consultarPosCondicionado(ByVal objConexion As Conexion, ByRef cod_pre_sgs As String, ByVal cod_sucur As String,
                                             ByVal strTip_Admision As String, ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double,
                                             ByVal strTipoProducto As String, ByVal strProducto As String) As Boolean
            Dim flagPosCondicionado As String

            Me.setSQLSentence("HC_posCondicionado", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("strcod_pre_sgs ", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("strcod_sucur", SqlDbType.VarChar, cod_sucur)
            Me.addInputParameter("strtip_admision", SqlDbType.VarChar, strTip_Admision)
            Me.addInputParameter("lAno_adm", SqlDbType.Int, strAno_Adm)
            Me.addInputParameter("dnum_adm", SqlDbType.Int, strNum_Adm)
            Me.addInputParameter("strTipoProducto", SqlDbType.VarChar, strTipoProducto)
            Me.addInputParameter("strproducto", SqlDbType.VarChar, strProducto)
            Me.addOutputParameter("strposCond", SqlDbType.VarChar, 1)
            Me.Exec()

            flagPosCondicionado = Me.Parameters("strposCond").Value

            If flagPosCondicionado = "S" Then
                consultarPosCondicionado = True
            Else
                consultarPosCondicionado = False
            End If
        End Function


        Public Function consultarEpsRecobrable(ByVal objConexion As Conexion, ByVal strEntidad As String) As String
            'Dim generaPedido As String

            Me.setSQLSentence("DB_TraerEpsRecobrablelabo", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("StrEntidad ", SqlDbType.VarChar, strEntidad)
            Me.addOutputParameter("epsRecobrable", SqlDbType.VarChar, 15)
            Me.Exec()

            consultarEpsRecobrable = Me.Parameters("epsRecobrable").Value

            'If generaPedido = "S" Then
            '    consultarEpsRecobrable = True
            'Else
            '    consultarEpsRecobrable = False
            'End If
        End Function

        '' herojas 2015/03/16

        Public Function consultarHonorarioVariable(ByVal cod_pre_sgs As String,
                                            ByVal cod_sucur As String,
                                            ByVal Medico As String,
                                            ByVal Especialidad As String,
                                            ByVal Procedim As String,
                                            ByVal Entidad As String,
                                            ByVal Fec_cargo As Date,
                                            ByRef Porcentaje As Integer) As Boolean

            Dim lError As Long
            Dim strMensaje As String
            Dim EsHonorario As String
            Dim dsCTC As DataSet

            Especialidad = Replace(Especialidad, "'", "")

            Me.setSQLSentence("pa_hvvalidasielcargoesdehonorariovar", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs ", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, cod_sucur)
            Me.addInputParameter("medico", SqlDbType.VarChar, Medico)
            Me.addInputParameter("especialidad", SqlDbType.VarChar, Especialidad)
            Me.addInputParameter("procedim", SqlDbType.VarChar, Procedim)
            Me.addInputParameter("entidad", SqlDbType.VarChar, Entidad)
            Me.addInputParameter("fec_cargo", SqlDbType.DateTime, Fec_cargo)
            Me.addOutputParameter("porcentaje", SqlDbType.SmallInt, 0)
            Me.addOutputParameter("eshonorario", SqlDbType.VarChar, 1)
            Me.addOutputParameter("lError", SqlDbType.Int, 0)
            Me.addOutputParameter("strMensaje", SqlDbType.VarChar, 300)
            Me.Exec()


            EsHonorario = Me.Parameters("eshonorario").Value
            Porcentaje = Me.Parameters("porcentaje").Value
            lError = Me.Parameters("lError").Value
            strMensaje = Me.Parameters("strMensaje").Value


            If lError <> 0 Then
                MsgBox(strMensaje)
                lError = lError
                Porcentaje = 0
                consultarHonorarioVariable = False
                Exit Function
            End If

            Porcentaje = IIf(IsDBNull(Porcentaje), 0, Porcentaje)
            consultarHonorarioVariable = IIf(EsHonorario = "S", True, False)

        End Function


        Public Function consultarOrdenes(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String,
                                               ByVal strCod_sucur As String, ByVal strTip_Admision As String,
                                               ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double) As DataSet
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            '' ''Dim numeroRegistros As Integer
            Dim dsDatos As DataSet

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetStoredProcCommandWrapper("HC_ConsultarOrdenes")
            '' ''With command
            '' ''    .AddInParameter("cod_pre_sgs", DbType.String, strCod_pre_sgs)
            '' ''    .AddInParameter("cod_sucur", DbType.String, strCod_sucur)
            '' ''    .AddInParameter("tip_admision", DbType.String, strTip_Admision)
            '' ''    .AddInParameter("ano_adm", DbType.Int16, strAno_Adm)
            '' ''    .AddInParameter("num_adm", DbType.Double, strNum_Adm)
            '' ''End With

            '' ''dsDatos = db.ExecuteDataSet(command)
            'CU03 Hrarza@
            'Inicio
            'Me.setSQLSentence("HC_ConsultarOrdenes", CommandType.StoredProcedure)
            Me.setSQLSentence("HC_ConsultarOrdenes_CQ", CommandType.StoredProcedure)
            'Fin
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strCod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, strTip_Admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, strAno_Adm)
            Me.addInputParameter("num_adm", SqlDbType.Int, strNum_Adm)
            'CU03 Hrariza@
            'Inicio
            Me.addInputParameter("flag", SqlDbType.VarChar, "CONCILIACION")
            'Fin
            dsDatos = Me.execDS()

            Return dsDatos
        End Function
        ''Hernan Rojas 2014/05/15
        ''Se verifica que no exista el CTC
        ''Solicitado por Mauricio Forero

        Public Function MedicamentoTieneCTC(ByVal Prestador As String, ByVal Sucursal As String,
                                ByVal TipoAdmision As String, ByVal AnoAdmision As String,
                                ByVal NumeroAdmision As String, ByVal Producto As String) As Boolean


            Dim dsCTC As DataSet
            Dim fec_desde As String
            Dim fec_hasta As String



            Me.setSQLSentence("HC_ConsultarCTC", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, Prestador)
            Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, Sucursal)
            Me.addInputParameter("@tip_admision", SqlDbType.VarChar, TipoAdmision)
            Me.addInputParameter("@ano_adm", SqlDbType.Int, AnoAdmision)
            Me.addInputParameter("@num_adm", SqlDbType.Decimal, NumeroAdmision)
            Me.addInputParameter("@producto", SqlDbType.VarChar, Producto)

            dsCTC = Me.execDS

            If dsCTC.Tables(0).Rows.Count > 0 Then
                fec_desde = dsCTC.Tables(0).Rows(0).Item("FEC_DESDE").ToString
                fec_hasta = dsCTC.Tables(0).Rows(0).Item("FEC_HASTA").ToString
                MsgBox("EL PRODUCTO " & Producto & " TIENE GENERADO UN CTC VIGENTE CON FECHA INICIAL " & fec_desde & " y FECHA FINAL " & fec_hasta)
                MedicamentoTieneCTC = True
            Else
                MedicamentoTieneCTC = False
            End If
        End Function

        ''' <summary>
        ''' Funcion que guarda los registros modificados y nuevos para todas las ordenes 
        ''' medicas(Dietas, medicamentos, procedimientos, ordenes generales). Para dietas,
        ''' medicamentos y procedimientos los registros modificados (Continuar - Suspender)
        ''' se inactivan y se crea un nuevo registro con una nuevo numero de orden, estado
        ''' activo y valor de tratamiento digitado por el usuario. Se insertan ademas los nuevos
        ''' registros  
        ''' </summary>
        ''' <param name="objConexion">Objeto con los datos de la conexion</param>
        ''' <param name="strCodSucur">Codigo de la sucursal</param>
        ''' <param name="xmlDietasModifica">XML con info de dietas modificadas</param>
        ''' <param name="xmlDietasNuevas">XML con info de nuevas dietas</param>
        ''' <param name="xmlMedicaModificados">XML con info de medicamentos modificados</param>
        ''' <param name="xmlMedicaNuevos">XML con info de Nuevos medicamentos</param>
        ''' <param name="xmlProceNuevos">XML con info de nuevos procedimientos</param>
        ''' <param name="NroOrden">Numero de orden que retorna el store procedure</param>
        ''' <returns>El posible numero de error generado en el store procedure</returns>
        ''' <remarks></remarks>
        Public Function guardarOrdenes(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String,
                                              ByVal strCodSucur As String, ByVal tip_admision As String,
                                              ByVal num_adm As String, ByVal ano_adm As String, ByVal strLogin As String,
                                              ByVal medico As String, ByVal strCodEspecialidad As String, ByVal entidad As String,
                                              ByVal xmlAislamientosModifica As String, ByVal xmlAislamientosNuevos As String,
                                              ByVal xmlDietasModifica As String, ByVal xmlDietasNuevas As String,
                                              ByVal xmlMedicaModificados As String, ByVal xmlMedicaNuevos As String,
                                              ByVal xmlProceNuevos As String, ByVal xmlGeneralesModificados As String,
                                              ByVal xmlGeneralesNuevos As String,
                                              ByRef NroOrden As Double, ByRef fechaOrden As Date, ByRef centroCostoOrigen As String,
                                              ByRef strGuia As String, ByRef strJustificacion As String,
                                              ByRef strTipoServicio As String, ByRef strPrioridad As String, ByRef InicioSesion As DateTime) As Long

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            '' ''Dim numeroRegistros As Integer
            Dim lError As Long

            'lError = generales.EjecutarSPConParametrosTran("HC_GrabarOrdenesMedicas", objConexion, strCodSucur, xmlDietasModifica, xmlDietasNuevas, NroOrden, lError)

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetStoredProcCommandWrapper("HC_GrabarOrdenesMedicas")
            '' ''With command
            '' ''    .AddInParameter("cod_pre_sgs", DbType.String, cod_pre_sgs)
            '' ''    .AddInParameter("cod_sucur", DbType.String, strCodSucur)
            '' ''    .AddInParameter("tip_admision", DbType.String, tip_admision)
            '' ''    .AddInParameter("num_adm", DbType.Double, num_adm)
            '' ''    .AddInParameter("ano_adm", DbType.Int16, ano_adm)
            '' ''    .AddInParameter("strLogin", DbType.String, strLogin)
            '' ''    .AddInParameter("medico", DbType.String, medico)
            '' ''    .AddInParameter("especialidad", DbType.String, strCodEspecialidad)
            '' ''    .AddInParameter("entidad", DbType.String, entidad)
            '' ''    .AddInParameter("txtXmlDietasModif", DbType.String, xmlDietasModifica)
            '' ''    .AddInParameter("txtXmlDietasNuevas", DbType.String, xmlDietasNuevas)
            '' ''    .AddInParameter("txtXmlMedicaModificados", DbType.String, xmlMedicaModificados)
            '' ''    .AddInParameter("txtXmlMedicaNuevos", DbType.String, xmlMedicaNuevos)
            '' ''    .AddInParameter("txtXmlProceNuevos", DbType.String, xmlProceNuevos)
            '' ''    .AddInParameter("txtXmlGeneralesModificados", DbType.String, xmlGeneralesModificados)
            '' ''    .AddInParameter("txtXmlGeneralesNuevos", DbType.String, xmlGeneralesNuevos)
            '' ''    .AddOutParameter("NewNroOrden", DbType.Double, 9)
            '' ''    .AddOutParameter("fechaOrden", DbType.DateTime, 8)
            '' ''    .AddOutParameter("centroDeCostoOrigen", DbType.String, 8)
            '' ''    .AddOutParameter("lError", DbType.Int16, 4)
            '' ''End With

            '' ''db.ExecuteNonQuery(command)
            '' ''lError = CType(command.GetParameterValue("@lError"), Long)

            '' ''If IsNumeric(command.GetParameterValue("@NewNroOrden").ToString) Then
            '' ''    NroOrden = CType(command.GetParameterValue("@NewNroOrden").ToString, Double)
            '' ''Else
            '' ''    NroOrden = 0
            '' ''End If

            '' ''If IsDate(command.GetParameterValue("@fechaOrden").ToString) Then
            '' ''    fechaOrden = CType(command.GetParameterValue("@fechaOrden").ToString, Date)
            '' ''End If

            '' ''centroCostoOrigen = command.GetParameterValue("@centroDeCostoOrigen").ToString

            Me.setSQLSentence("HC_GrabarOrdenesMedicas", CommandType.StoredProcedure)
            'Me.setSQLSentence("HC_GrabarOrdenesMedicas_PruebaCTC", CommandType.StoredProcedure)
            Me.ParametersCollection.Clear()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCodSucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("num_adm", SqlDbType.Int, num_adm)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("strLogin", SqlDbType.VarChar, strLogin)
            Me.addInputParameter("medico", SqlDbType.VarChar, medico)
            Me.addInputParameter("especialidad", SqlDbType.VarChar, strCodEspecialidad)
            Me.addInputParameter("entidad", SqlDbType.VarChar, entidad)
            Me.addInputParameter("txtXmlAislamientosModif", SqlDbType.VarChar, xmlAislamientosModifica)
            Me.addInputParameter("txtXmlAislamientosNuevos", SqlDbType.VarChar, xmlAislamientosNuevos)
            Me.addInputParameter("txtXmlDietasModif", SqlDbType.VarChar, xmlDietasModifica)
            Me.addInputParameter("txtXmlDietasNuevas", SqlDbType.VarChar, xmlDietasNuevas)
            Me.addInputParameter("txtXmlMedicaModificados", SqlDbType.VarChar, xmlMedicaModificados)
            Me.addInputParameter("txtXmlMedicaNuevos", SqlDbType.VarChar, xmlMedicaNuevos)
            Me.addInputParameter("txtXmlProceNuevos", SqlDbType.VarChar, xmlProceNuevos)
            Me.addInputParameter("txtXmlGeneralesModificados", SqlDbType.VarChar, xmlGeneralesModificados)
            Me.addInputParameter("txtXmlGeneralesNuevos", SqlDbType.VarChar, xmlGeneralesNuevos)
            Me.addOutputParameter("NewNroOrden", SqlDbType.Int)
            Me.addOutputParameter("fechaOrden", SqlDbType.DateTime)
            Me.addOutputParameter("centroDeCostoOrigen", SqlDbType.VarChar, 8)
            'parametros creados por Ing. Ricardo Mauricio Zaldúa C. 2009-02-03 Res 3047 solicitado por Mauricio Forero
            Me.addInputParameter("strGuia", SqlDbType.VarChar, strGuia)
            Me.addInputParameter("strJustificacion", SqlDbType.VarChar, strJustificacion)
            Me.addInputParameter("strTipoServicio", SqlDbType.VarChar, strTipoServicio)
            Me.addInputParameter("strPrioridad", SqlDbType.VarChar, strPrioridad)
            '=============
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()
            lError = Me.Parameters("lError").Value

            If IsNumeric(Me.Parameters("NewNroOrden").Value) Then
                NroOrden = CType(Me.Parameters("NewNroOrden").Value, Double)
            Else
                NroOrden = 0
            End If

            If IsDate(Me.Parameters("@fechaOrden").Value) Then
                fechaOrden = CType(Me.Parameters("@fechaOrden").Value, Date)
            End If

            If IsDBNull(Me.Parameters("@centroDeCostoOrigen").Value) Then
                centroCostoOrigen = ""
            Else
                centroCostoOrigen = Me.Parameters("@centroDeCostoOrigen").Value
            End If



            ValidarPedidoGenerado(cod_pre_sgs, strCodSucur, tip_admision, ano_adm, num_adm, NroOrden)

            Return lError

        End Function

        ''' <summary>
        ''' eloaiza@intergrupo
        '''30-08-2019
        ''' Metodo clonado de guardar funciones, los parametros de cadena que representan un xml se reemplazan
        ''' por objetos de tipo DataTable (los nombres de los parametros se mantendran) que almacenan la informacion
        ''' de todas las ordenes medicas(Dietas, medicamentos, procedimientos, ordenes generales). Para dietas,
        ''' medicamentos y procedimientos los registros modificados (Continuar - Suspender)
        ''' se inactivan y se crea un nuevo registro con una nuevo numero de orden, estado
        ''' activo y valor de tratamiento digitado por el usuario. Se insertan ademas los nuevos
        ''' registros  
        ''' </summary>
        ''' <param name="objConexion">Objeto con los datos de la conexion</param>
        ''' <param name="strCodSucur">Codigo de la sucursal</param>
        ''' <param name="xmlDietasModifica">Tabla con registros de dietas modificadas</param>
        ''' <param name="xmlDietasNuevas">Tabla con registros de nuevas dietas</param>
        ''' <param name="xmlMedicaModificados">Tabla con registros de medicamentos modificados</param>
        ''' <param name="xmlMedicaNuevos">Tabla con registros de Nuevos medicamentos</param>
        ''' <param name="xmlProceNuevos">Tabla con registros de nuevos procedimientos</param>
        ''' <param name="NroOrden">Numero de orden que retorna el store procedure</param>
        ''' <returns>El posible numero de error generado en el store procedure</returns>
        ''' <remarks></remarks>
        Public Function guardarOrdenes(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String,
                                              ByVal strCodSucur As String, ByVal tip_admision As String,
                                              ByVal num_adm As String, ByVal ano_adm As String, ByVal strLogin As String,
                                              ByVal medico As String, ByVal strCodEspecialidad As String, ByVal entidad As String,
                                              ByVal xmlAislamientosModifica As DataTable, ByVal xmlAislamientosNuevos As DataTable,
                                              ByVal xmlDietasModifica As DataTable, ByVal xmlDietasNuevas As DataTable,
                                              ByVal xmlMedicaModificados As DataTable, ByVal xmlMedicaNuevos As DataTable,
                                              ByVal xmlProceNuevos As DataTable, ByVal xmlGeneralesModificados As DataTable,
                                              ByVal xmlGeneralesNuevos As DataTable, ByVal dtDatosPaciente As DataTable,
                                              ByRef NroOrden As Double, ByRef fechaOrden As Date, ByRef centroCostoOrigen As String,
                                              ByRef strGuia As String, ByRef strJustificacion As String,
                                              ByRef strTipoServicio As String, ByRef strPrioridad As String, ByRef InicioSesion As DateTime) As Long

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            Dim lError As Long

            'Joseph Moreno (IG) Fec:2019/11/24 Particularidades
            'CU03 Hrariza@
            'Inicio
            'Me.setSQLSentence("HC_GrabarOrdenesMedicas_P", CommandType.StoredProcedure)
            Me.setSQLSentence("HC_GrabarOrdenesMedicas_CQ", CommandType.StoredProcedure)
            'Fin
            'Me.setSQLSentence("HC_GrabarOrdenesMedicas_P_Ext", CommandType.StoredProcedure)
            'Me.setSQLSentence("HC_GrabarOrdenesMedicas_PruebaCTC", CommandType.StoredProcedure)
            Me.ParametersCollection.Clear()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCodSucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("num_adm", SqlDbType.Int, num_adm)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("strLogin", SqlDbType.VarChar, strLogin)
            Me.addInputParameter("medico", SqlDbType.VarChar, medico)
            Me.addInputParameter("especialidad", SqlDbType.VarChar, strCodEspecialidad)
            Me.addInputParameter("entidad", SqlDbType.VarChar, entidad)
            Me.addInputParameter("txtXmlAislamientosModif", SqlDbType.Structured, xmlAislamientosModifica)
            Me.addInputParameter("txtXmlAislamientosNuevos", SqlDbType.Structured, xmlAislamientosNuevos)
            Me.addInputParameter("txtXmlDietasModif", SqlDbType.Structured, xmlDietasModifica)
            Me.addInputParameter("txtXmlDietasNuevas", SqlDbType.Structured, xmlDietasNuevas)
            Me.addInputParameter("txtXmlMedicaModificados", SqlDbType.Structured, xmlMedicaModificados)
            Me.addInputParameter("txtXmlMedicaNuevos", SqlDbType.Structured, xmlMedicaNuevos)
            Me.addInputParameter("txtXmlProceNuevos", SqlDbType.Structured, xmlProceNuevos)
            Me.addInputParameter("txtXmlGeneralesModificados", SqlDbType.Structured, xmlGeneralesModificados)
            Me.addInputParameter("txtXmlGeneralesNuevos", SqlDbType.Structured, xmlGeneralesNuevos)
            Me.addInputParameter("Tbl_DatosPaciente", SqlDbType.Structured, dtDatosPaciente)
            Me.addOutputParameter("NewNroOrden", SqlDbType.Int)
            Me.addOutputParameter("fechaOrden", SqlDbType.DateTime)
            Me.addOutputParameter("centroDeCostoOrigen", SqlDbType.VarChar, 8)
            'parametros creados por Ing. Ricardo Mauricio Zaldúa C. 2009-02-03 Res 3047 solicitado por Mauricio Forero
            Me.addInputParameter("strGuia", SqlDbType.VarChar, strGuia)
            Me.addInputParameter("strJustificacion", SqlDbType.VarChar, strJustificacion)
            Me.addInputParameter("strTipoServicio", SqlDbType.VarChar, strTipoServicio)
            Me.addInputParameter("strPrioridad", SqlDbType.VarChar, strPrioridad)
            'CU03 Hrariza@
            'Inicio
            Me.addInputParameter("flag", SqlDbType.VarChar, "CONCILIACION")
            'Fin
            Me.Parameters("txtXmlAislamientosModif").TypeName = "dbo.UT_Tbl_Aislamientos"
            Me.Parameters("txtXmlAislamientosNuevos").TypeName = "dbo.UT_Tbl_Aislamientos"
            Me.Parameters("txtXmlDietasModif").TypeName = "dbo.UT_Tbl_Dietas"
            Me.Parameters("txtXmlDietasNuevas").TypeName = "dbo.UT_Tbl_Dietas"
            'CU03 Hrariza@
            'Inicio
            'Me.Parameters("txtXmlMedicaModificados").TypeName = "dbo.UT_Tbl_Medicamentos"
            'Me.Parameters("txtXmlMedicaNuevos").TypeName = "dbo.UT_Tbl_Medicamentos"
            Me.Parameters("txtXmlMedicaModificados").TypeName = "dbo.UT_Tbl_Medicamentos_CQ"
            Me.Parameters("txtXmlMedicaNuevos").TypeName = "dbo.UT_Tbl_Medicamentos_CQ"
            'Fin
            'Joseph Moreno (IG) Fec:2019/11/28 Particularidades
            'Me.Parameters("txtXmlProceNuevos").TypeName = "dbo.UT_Tbl_Procedimientos"
            Me.Parameters("txtXmlProceNuevos").TypeName = "dbo.UT_Tbl_ProcedimientosExt"
            Me.Parameters("txtXmlGeneralesModificados").TypeName = "dbo.UT_Tbl_Generales"
            Me.Parameters("txtXmlGeneralesNuevos").TypeName = "dbo.UT_Tbl_Generales"
            Me.Parameters("Tbl_DatosPaciente").TypeName = "dbo.UT_Tbl_DatosPaciente"
            '=============
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.addInputParameter("FInicialSeion", SqlDbType.DateTime, InicioSesion)
            Me.Exec()

            lError = Me.Parameters("lError").Value

            If IsNumeric(Me.Parameters("NewNroOrden").Value) Then
                NroOrden = CType(Me.Parameters("NewNroOrden").Value, Double)
            Else
                NroOrden = 0
            End If

            If IsDate(Me.Parameters("fechaOrden").Value) Then
                fechaOrden = CType(Me.Parameters("fechaOrden").Value, Date)
            End If

            If IsDBNull(Me.Parameters("centroDeCostoOrigen").Value) Then
                centroCostoOrigen = ""
            Else
                centroCostoOrigen = CType(Me.Parameters("centroDeCostoOrigen").Value, String)
            End If

            ValidarPedidoGenerado(cod_pre_sgs, strCodSucur, tip_admision, ano_adm, num_adm, NroOrden)

            Return lError

        End Function




        Public Function guardarOrdenesLabo(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String,
                                              ByVal strCodSucur As String, ByVal tip_admision As String,
                                              ByVal num_adm As String, ByVal ano_adm As String, ByVal strLogin As String,
                                              ByVal medico As String, ByVal strCodEspecialidad As String, ByVal entidad As String,
                                              ByVal xmlAislamientosModifica As String, ByVal xmlAislamientosNuevos As String,
                                              ByVal xmlDietasModifica As String, ByVal xmlDietasNuevas As String,
                                              ByVal xmlMedicaModificados As String, ByVal xmlMedicaNuevos As String,
                                              ByVal xmlProceNuevos As String, ByVal xmlGeneralesModificados As String,
                                              ByVal xmlGeneralesNuevos As String, ByRef NroOrden As Double,
                                              ByRef fechaOrden As Date, ByRef centroCostoOrigen As String,
                                              ByRef strGuia As String, ByRef strJustificacion As String,
                                              ByRef strTipoServicio As String, ByRef strPrioridad As String) As Long

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            '' ''Dim numeroRegistros As Integer
            Dim lError As Long

            'lError = generales.EjecutarSPConParametrosTran("HC_GrabarOrdenesMedicas", objConexion, strCodSucur, xmlDietasModifica, xmlDietasNuevas, NroOrden, lError)

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetStoredProcCommandWrapper("HC_GrabarOrdenesMedicas")
            '' ''With command
            '' ''    .AddInParameter("cod_pre_sgs", DbType.String, cod_pre_sgs)
            '' ''    .AddInParameter("cod_sucur", DbType.String, strCodSucur)
            '' ''    .AddInParameter("tip_admision", DbType.String, tip_admision)
            '' ''    .AddInParameter("num_adm", DbType.Double, num_adm)
            '' ''    .AddInParameter("ano_adm", DbType.Int16, ano_adm)
            '' ''    .AddInParameter("strLogin", DbType.String, strLogin)
            '' ''    .AddInParameter("medico", DbType.String, medico)
            '' ''    .AddInParameter("especialidad", DbType.String, strCodEspecialidad)
            '' ''    .AddInParameter("entidad", DbType.String, entidad)
            '' ''    .AddInParameter("txtXmlDietasModif", DbType.String, xmlDietasModifica)
            '' ''    .AddInParameter("txtXmlDietasNuevas", DbType.String, xmlDietasNuevas)
            '' ''    .AddInParameter("txtXmlMedicaModificados", DbType.String, xmlMedicaModificados)
            '' ''    .AddInParameter("txtXmlMedicaNuevos", DbType.String, xmlMedicaNuevos)
            '' ''    .AddInParameter("txtXmlProceNuevos", DbType.String, xmlProceNuevos)
            '' ''    .AddInParameter("txtXmlGeneralesModificados", DbType.String, xmlGeneralesModificados)
            '' ''    .AddInParameter("txtXmlGeneralesNuevos", DbType.String, xmlGeneralesNuevos)
            '' ''    .AddOutParameter("NewNroOrden", DbType.Double, 9)
            '' ''    .AddOutParameter("fechaOrden", DbType.DateTime, 8)
            '' ''    .AddOutParameter("centroDeCostoOrigen", DbType.String, 8)
            '' ''    .AddOutParameter("lError", DbType.Int16, 4)
            '' ''End With

            '' ''db.ExecuteNonQuery(command)
            '' ''lError = CType(command.GetParameterValue("@lError"), Long)

            '' ''If IsNumeric(command.GetParameterValue("@NewNroOrden").ToString) Then
            '' ''    NroOrden = CType(command.GetParameterValue("@NewNroOrden").ToString, Double)
            '' ''Else
            '' ''    NroOrden = 0
            '' ''End If

            '' ''If IsDate(command.GetParameterValue("@fechaOrden").ToString) Then
            '' ''    fechaOrden = CType(command.GetParameterValue("@fechaOrden").ToString, Date)
            '' ''End If

            '' ''centroCostoOrigen = command.GetParameterValue("@centroDeCostoOrigen").ToString

            Me.setSQLSentence("HC_GrabarOrdenesMedicasLabo", CommandType.StoredProcedure)
            'Me.setSQLSentence("HC_GrabarOrdenesMedicas_PruebaCTC", CommandType.StoredProcedure)
            Me.ParametersCollection.Clear()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCodSucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("num_adm", SqlDbType.Int, num_adm)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("strLogin", SqlDbType.VarChar, strLogin)
            Me.addInputParameter("medico", SqlDbType.VarChar, medico)
            Me.addInputParameter("especialidad", SqlDbType.VarChar, strCodEspecialidad)
            Me.addInputParameter("entidad", SqlDbType.VarChar, entidad)
            Me.addInputParameter("@txtXmlAislamientosModif", SqlDbType.VarChar, xmlAislamientosModifica)
            Me.addInputParameter("@txtXmlAislamientosNuevos", SqlDbType.VarChar, xmlAislamientosNuevos)
            Me.addInputParameter("txtXmlDietasModif", SqlDbType.VarChar, xmlDietasModifica)
            Me.addInputParameter("txtXmlDietasNuevas", SqlDbType.VarChar, xmlDietasNuevas)
            Me.addInputParameter("txtXmlMedicaModificados", SqlDbType.VarChar, xmlMedicaModificados)
            Me.addInputParameter("txtXmlMedicaNuevos", SqlDbType.VarChar, xmlMedicaNuevos)
            Me.addInputParameter("txtXmlProceNuevos", SqlDbType.VarChar, xmlProceNuevos)
            Me.addInputParameter("txtXmlGeneralesModificados", SqlDbType.VarChar, xmlGeneralesModificados)
            Me.addInputParameter("txtXmlGeneralesNuevos", SqlDbType.VarChar, xmlGeneralesNuevos)
            Me.addOutputParameter("NewNroOrden", SqlDbType.Int)
            Me.addOutputParameter("fechaOrden", SqlDbType.DateTime)
            Me.addOutputParameter("centroDeCostoOrigen", SqlDbType.VarChar, 8)
            'parametros creados por Ing. Ricardo Mauricio Zaldúa C. 2009-02-03 Res 3047 solicitado por Mauricio Forero
            Me.addInputParameter("strGuia", SqlDbType.VarChar, strGuia)
            Me.addInputParameter("strJustificacion", SqlDbType.VarChar, strJustificacion)
            Me.addInputParameter("strTipoServicio", SqlDbType.VarChar, strTipoServicio)
            Me.addInputParameter("strPrioridad", SqlDbType.VarChar, strPrioridad)
            '=============
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()
            lError = Me.Parameters("lError").Value

            If IsNumeric(Me.Parameters("NewNroOrden").Value) Then
                NroOrden = CType(Me.Parameters("NewNroOrden").Value, Double)
            Else
                NroOrden = 0
            End If

            If IsDate(Me.Parameters("@fechaOrden").Value) Then
                fechaOrden = CType(Me.Parameters("@fechaOrden").Value, Date)
            End If

            If IsDBNull(Me.Parameters("@centroDeCostoOrigen").Value) Then
                centroCostoOrigen = ""
            Else
                centroCostoOrigen = Me.Parameters("@centroDeCostoOrigen").Value
            End If



            ValidarPedidoGenerado(cod_pre_sgs, strCodSucur, tip_admision, ano_adm, num_adm, NroOrden)

            Return lError

        End Function

        Public Sub ValidarPedidoGenerado(ByVal strCod_pre_sgs As String,
                                                       ByVal strCod_sucur As String, ByVal strTip_Admision As String,
                                                       ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double, ByVal NroOrden As Integer)

            Dim dtDatos As DataTable
            Dim strProcedimiento As String = ""

            Me.setSQLSentence("HC_ValidarPedidoGenerado", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strCod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, strTip_Admision)
            Me.addInputParameter("num_adm", SqlDbType.Int, strNum_Adm)
            Me.addInputParameter("ano_adm", SqlDbType.Int, strAno_Adm)
            Me.addInputParameter("NroOrden", SqlDbType.Int, NroOrden)

            dtDatos = Me.execDT

            For i As Integer = 0 To dtDatos.Rows.Count - 1

                strProcedimiento = strProcedimiento + dtDatos.Rows(i).Item("Procedimiento") & " " & dtDatos.Rows(i).Item("nombre_examen") & vbCrLf

            Next

            If strProcedimiento.Length > 0 Then
                '                MsgBox("No se generó pedido por el sistema para los siguientes procedimientos. Se debe generar un pedido manual. " & vbCrLf & strProcedimiento)
                MsgBox("No se generó pedido por el sistema para los siguientes procedimientos. " & vbCrLf & strProcedimiento)
            End If

        End Sub
        ''cpgaray Se independiza el proceso de guardado para cada tipo de orden
        ''Octubre 16 de 2012
        Public Function guardarOrdenesNutricion(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String,
                                                     ByVal strCodSucur As String, ByVal tip_admision As String,
                                                     ByVal num_adm As String, ByVal ano_adm As String, ByVal strLogin As String,
                                                     ByVal medico As String, ByVal strCodEspecialidad As String, ByVal entidad As String,
                                                     ByVal xmlDietasModifica As String, ByVal xmlDietasNuevas As String,
                                                     ByRef NroOrden As Double, ByRef fechaOrden As Date) As Long


            Dim lError As Long


            Me.setSQLSentence("HC_GrabarOrdenesMedicasDietas", CommandType.StoredProcedure)
            Me.ParametersCollection.Clear()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCodSucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("num_adm", SqlDbType.Int, num_adm)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("strLogin", SqlDbType.VarChar, strLogin)
            Me.addInputParameter("medico", SqlDbType.VarChar, medico)
            Me.addInputParameter("especialidad", SqlDbType.VarChar, strCodEspecialidad)
            Me.addInputParameter("entidad", SqlDbType.VarChar, entidad)
            Me.addInputParameter("txtXmlDietasModif", SqlDbType.VarChar, xmlDietasModifica)
            Me.addInputParameter("txtXmlDietasNuevas", SqlDbType.VarChar, xmlDietasNuevas)
            Me.addOutputParameter("NewNroOrden", SqlDbType.Int)
            Me.addOutputParameter("fechaOrden", SqlDbType.DateTime)
            '=============
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()
            lError = Me.Parameters("lError").Value

            If IsNumeric(Me.Parameters("NewNroOrden").Value) Then
                NroOrden = CType(Me.Parameters("NewNroOrden").Value, Double)
            Else
                NroOrden = 0
            End If

            If IsDate(Me.Parameters("@fechaOrden").Value) Then
                fechaOrden = CType(Me.Parameters("@fechaOrden").Value, Date)
            End If


            Return lError

        End Function
        Public Function guardarOrdenesMedicamentos(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String,
                                                    ByVal strCodSucur As String, ByVal tip_admision As String,
                                                    ByVal num_adm As String, ByVal ano_adm As String, ByVal strLogin As String,
                                                    ByVal medico As String, ByVal strCodEspecialidad As String, ByVal entidad As String,
                                                    ByVal xmlMedicaModificados As String, ByVal xmlMedicaNuevos As String,
                                                    ByRef NroOrden As Double, ByRef fechaOrden As Date) As Long


            Dim lError As Long


            Me.setSQLSentence("HC_GrabarOrdenesMedicasMedicamentos", CommandType.StoredProcedure)
            Me.ParametersCollection.Clear()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCodSucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("num_adm", SqlDbType.Int, num_adm)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("strLogin", SqlDbType.VarChar, strLogin)
            Me.addInputParameter("medico", SqlDbType.VarChar, medico)
            Me.addInputParameter("especialidad", SqlDbType.VarChar, strCodEspecialidad)
            Me.addInputParameter("entidad", SqlDbType.VarChar, entidad)
            Me.addInputParameter("txtXmlMedicaModificados", SqlDbType.VarChar, xmlMedicaModificados)
            Me.addInputParameter("txtXmlMedicaNuevos", SqlDbType.VarChar, xmlMedicaNuevos)
            Me.addInputParameter("NewNroOrden1", SqlDbType.Int, NroOrden)
            Me.addOutputParameter("NewNroOrden", SqlDbType.Int)
            Me.addOutputParameter("fechaOrden", SqlDbType.DateTime)
            '=============
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()
            lError = Me.Parameters("lError").Value

            If IsNumeric(Me.Parameters("NewNroOrden").Value) Then
                NroOrden = CType(Me.Parameters("NewNroOrden").Value, Double)
            Else
                NroOrden = 0
            End If

            If IsDate(Me.Parameters("@fechaOrden").Value) Then
                fechaOrden = CType(Me.Parameters("@fechaOrden").Value, Date)
            End If


            Return lError

        End Function

        Public Function guardarOrdenesProcedimientos(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String,
                                                            ByVal strCodSucur As String, ByVal tip_admision As String,
                                                            ByVal num_adm As String, ByVal ano_adm As String, ByVal strLogin As String,
                                                            ByVal medico As String, ByVal strCodEspecialidad As String, ByVal entidad As String,
                                                            ByVal xmlProceNuevos As String, ByRef NroOrden As Double, ByRef fechaOrden As Date,
                                                            ByRef centroCostoOrigen As String, ByRef strGuia As String, ByRef strJustificacion As String,
                                                            ByRef strTipoServicio As String, ByRef strPrioridad As String) As Long


            Dim lError As Long


            Me.setSQLSentence("HC_GrabarOrdenesMedicasProcedimientos", CommandType.StoredProcedure)
            Me.ParametersCollection.Clear()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCodSucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("num_adm", SqlDbType.Int, num_adm)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("strLogin", SqlDbType.VarChar, strLogin)
            Me.addInputParameter("medico", SqlDbType.VarChar, medico)
            Me.addInputParameter("especialidad", SqlDbType.VarChar, strCodEspecialidad)
            Me.addInputParameter("entidad", SqlDbType.VarChar, entidad)
            Me.addInputParameter("txtXmlProceNuevos", SqlDbType.VarChar, xmlProceNuevos)
            Me.addInputParameter("NewNroOrden1", SqlDbType.Int, NroOrden)
            Me.addOutputParameter("NewNroOrden", SqlDbType.Int)
            Me.addOutputParameter("fechaOrden", SqlDbType.DateTime)
            Me.addOutputParameter("centroDeCostoOrigen", SqlDbType.VarChar, 8)
            'parametros creados por Ing. Ricardo Mauricio Zaldúa C. 2009-02-03 Res 3047 solicitado por Mauricio Forero
            Me.addInputParameter("strGuia", SqlDbType.VarChar, strGuia)
            Me.addInputParameter("strJustificacion", SqlDbType.VarChar, strJustificacion)
            Me.addInputParameter("strTipoServicio", SqlDbType.VarChar, strTipoServicio)
            Me.addInputParameter("strPrioridad", SqlDbType.VarChar, strPrioridad)
            '=============
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()
            lError = Me.Parameters("lError").Value

            If IsNumeric(Me.Parameters("NewNroOrden").Value) Then
                NroOrden = CType(Me.Parameters("NewNroOrden").Value, Double)
            Else
                NroOrden = 0
            End If

            If IsDate(Me.Parameters("@fechaOrden").Value) Then
                fechaOrden = CType(Me.Parameters("@fechaOrden").Value, Date)
            End If

            If IsDBNull(Me.Parameters("@centroDeCostoOrigen").Value) Then
                centroCostoOrigen = ""
            Else
                centroCostoOrigen = Me.Parameters("@centroDeCostoOrigen").Value
            End If

            Return lError

        End Function

        Public Function guardarOrdenesGenerales(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String,
                                                   ByVal strCodSucur As String, ByVal tip_admision As String,
                                                   ByVal num_adm As String, ByVal ano_adm As String, ByVal strLogin As String,
                                                   ByVal medico As String, ByVal strCodEspecialidad As String, ByVal entidad As String,
                                                   ByVal xmlGeneralesModificados As String, ByVal xmlGeneralesNuevos As String,
                                                   ByRef NroOrden As Double, ByRef fechaOrden As Date) As Long


            Dim lError As Long


            Me.setSQLSentence("HC_GrabarOrdenesMedicasGenerales", CommandType.StoredProcedure)
            Me.ParametersCollection.Clear()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCodSucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("num_adm", SqlDbType.Int, num_adm)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("strLogin", SqlDbType.VarChar, strLogin)
            Me.addInputParameter("medico", SqlDbType.VarChar, medico)
            Me.addInputParameter("especialidad", SqlDbType.VarChar, strCodEspecialidad)
            Me.addInputParameter("entidad", SqlDbType.VarChar, entidad)
            Me.addInputParameter("txtXmlGeneralesModificados", SqlDbType.VarChar, xmlGeneralesModificados)
            Me.addInputParameter("txtXmlGeneralesNuevos", SqlDbType.VarChar, xmlGeneralesNuevos)
            Me.addInputParameter("NewNroOrden1", SqlDbType.Int, NroOrden)
            Me.addOutputParameter("NewNroOrden", SqlDbType.Int)
            Me.addOutputParameter("fechaOrden", SqlDbType.DateTime)
            '=============
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()
            lError = Me.Parameters("lError").Value

            If IsNumeric(Me.Parameters("NewNroOrden").Value) Then
                NroOrden = CType(Me.Parameters("NewNroOrden").Value, Double)
            Else
                NroOrden = 0
            End If

            If IsDate(Me.Parameters("@fechaOrden").Value) Then
                fechaOrden = CType(Me.Parameters("@fechaOrden").Value, Date)
            End If


            Return lError

        End Function
        Public Function guardarOrdenesAGFA(ByVal objConexion As Conexion, ByVal MSH_STATUS As String, ByVal MSH_DATE As Date,
                                              ByVal PID2_ID As String,
                                              ByVal PID5_LNAME As String, ByVal PID5_FNAME As String,
                                              ByVal PID7_BDATE As DateTime, ByVal PID8_SEX As String, ByVal PID11_ADDRESS As String,
                                              ByVal PV118_PATIENT_TYPE As String, ByVal PV119_ADMIN_NUMB As String, ByVal ORC2_ORDERNUMBER As String,
                                              ByVal ORC2_OPN_ID As String, ByVal ORC4_ORDERGROUP As String,
                                              ByVal ORC7_STARTDATE As DateTime, ByVal ORC7_ENDDATE As DateTime,
                                              ByVal ORC7_PRIORITY As Integer, ByVal ORC10_AUTHORCODE As String,
                                              ByVal ORC12_PHYSICIANCODE As String, ByVal ORC25_ORDERSTATUS As Integer,
                                              ByVal OBR4_EXAMCODE As String, ByRef OBR4_EXAMNAME As String,
                                              ByRef ORC6_ORDERDATE As Date, ByRef OBR13_CLINICALINFO As String, ByRef OBR31_STUDYREASON As String,
                                              ByVal CC_ORIGEN As String, ByVal CC_DESTINO As String, ByVal NroPedido As Decimal, ByVal sucursal As String,
                                              ByVal Prestador As String, ByVal OBX_ENTIDAD As String, ByVal OBX_CODIGO_HIS As String,
                                              ByVal NOMBRE_MEDICO As String,
                                              ByVal ano_adm As String, ByVal num_adm As String, ByVal particularidades As String,
                                              ByVal procedimientos As String, Optional ByVal intConse As Integer = 0) As Long


            Dim lError As Long
            Dim obs As String
            Dim Orden As String

            If NroPedido > 0 Then
                obs = "CON PEDIDO"
            Else
                obs = "SIN PEDIDO"
            End If
            If ORC25_ORDERSTATUS = 0 Then
                Orden = ORC4_ORDERGROUP & "-" & intConse
            Else
                Orden = ORC4_ORDERGROUP
            End If
            Me.setSQLSentence("HC_GrabarOrdenesMedicasAGFA", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("MSH_STATUS", SqlDbType.VarChar, MSH_STATUS)
            Me.addInputParameter("MSH_DATE", SqlDbType.DateTime, MSH_DATE)
            Me.addInputParameter("PID2_ID", SqlDbType.VarChar, PID2_ID)
            Me.addInputParameter("PID5_LNAME", SqlDbType.VarChar, PID5_LNAME)
            Me.addInputParameter("PID5_FNAME", SqlDbType.VarChar, PID5_FNAME)
            Me.addInputParameter("PID7_BDATE", SqlDbType.DateTime, PID7_BDATE)
            Me.addInputParameter("PID8_SEX", SqlDbType.VarChar, PID8_SEX)
            Me.addInputParameter("PID11_ADDRESS", SqlDbType.VarChar, PID11_ADDRESS)
            Me.addInputParameter("PV118_PATIENT_TYPE", SqlDbType.VarChar, PV118_PATIENT_TYPE)
            Me.addInputParameter("PV119_ADMIN_NUMB", SqlDbType.VarChar, PV119_ADMIN_NUMB)
            Me.addInputParameter("ORC2_ORDERNUMBER", SqlDbType.VarChar, ORC2_ORDERNUMBER)
            Me.addInputParameter("ORC2_OPN_ID", SqlDbType.VarChar, ORC2_OPN_ID)
            Me.addInputParameter("ORC4_ORDERGROUP", SqlDbType.VarChar, Orden)
            Me.addInputParameter("ORC7_STARTDATE", SqlDbType.DateTime, ORC7_STARTDATE)
            Me.addInputParameter("ORC7_ENDDATE", SqlDbType.DateTime, ORC7_ENDDATE)
            Me.addInputParameter("ORC7_PRIORITY", SqlDbType.TinyInt, ORC7_PRIORITY)
            Me.addInputParameter("ORC10_AUTHORCODE", SqlDbType.VarChar, ORC10_AUTHORCODE)
            Me.addInputParameter("ORC12_PHYSICIANCODE", SqlDbType.VarChar, ORC12_PHYSICIANCODE)
            Me.addInputParameter("ORC25_ORDERSTATUS", SqlDbType.Int, ORC25_ORDERSTATUS)
            Me.addInputParameter("OBR4_EXAMCODE", SqlDbType.VarChar, OBR4_EXAMCODE)
            Me.addInputParameter("OBR4_EXAMNAME", SqlDbType.VarChar, OBR4_EXAMNAME)
            Me.addInputParameter("ORC6_ORDERDATE", SqlDbType.DateTime, ORC6_ORDERDATE)
            Me.addInputParameter("OBR13_CLINICALINFO", SqlDbType.VarChar, OBR13_CLINICALINFO)
            Me.addInputParameter("OBR31_STUDYREASON", SqlDbType.VarChar, OBR31_STUDYREASON)
            Me.addInputParameter("CC_ORIGEN", SqlDbType.VarChar, CC_ORIGEN)
            Me.addInputParameter("CC_DESTINO", SqlDbType.VarChar, CC_DESTINO)
            Me.addInputParameter("NroPedido", SqlDbType.Decimal, NroPedido)
            ' herojas 2014/09/15 se le agrega el parameto entidad para que en la tabla agfa_orm_in quede guardada la entidad
            Me.addInputParameter("OBX_ENTIDAD", SqlDbType.VarChar, OBX_ENTIDAD)
            ' herojas 2014/10/09 se le agregan los parametros codigo sophia, observaciones y el nombre del medico para que sean mostrados en el log agfa
            Me.addInputParameter("OBX_CODIGO_HIS", SqlDbType.VarChar, OBX_CODIGO_HIS)
            Me.addInputParameter("OBX_NOMBRE_MEDICO", SqlDbType.VarChar, NOMBRE_MEDICO)
            Me.addInputParameter("OBX_OBS_SIS", SqlDbType.VarChar, obs)
            Me.addInputParameter("sucursal", SqlDbType.VarChar, sucursal)
            Me.addInputParameter("Prestador", SqlDbType.VarChar, Prestador)
            '=============
            Me.addOutputParameter("lError", SqlDbType.Int)
            ' herojas 2015/02/11 Para consultar la cama se envia la admision       
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("num_adm", SqlDbType.Decimal, num_adm)
            Me.addInputParameter("rsParticularidades", SqlDbType.VarChar, particularidades) ''CCGUTIEREZ - OSI. 07/09/2020. Se agrega parametro dr("particularidades")
            Me.addInputParameter("rsProcedimientos", SqlDbType.VarChar, procedimientos) ''CCGUTIEREZ - OSI. 28/06/2021. Se agrega parametro dr("procedimientos")
            Me.Exec()
            lError = Me.Parameters("lError").Value

            Return lError
        End Function

        'Metodo que guarda la interfaz de agfa cunado se realiza la homologacion
        Public Function guardarOrdenesAGFAhomologacion(ByVal objConexion As Conexion, ByVal MSH_STATUS As String, ByVal MSH_DATE As Date,
                                              ByVal PID2_ID As String,
                                              ByVal PID5_LNAME As String, ByVal PID5_FNAME As String,
                                              ByVal PID7_BDATE As DateTime, ByVal PID8_SEX As String, ByVal PID11_ADDRESS As String,
                                              ByVal PV118_PATIENT_TYPE As String, ByVal PV119_ADMIN_NUMB As String, ByVal ORC2_ORDERNUMBER As String,
                                              ByVal ORC2_OPN_ID As String, ByVal ORC4_ORDERGROUP As String,
                                              ByVal ORC7_STARTDATE As DateTime, ByVal ORC7_ENDDATE As DateTime,
                                              ByVal ORC7_PRIORITY As Integer, ByVal ORC10_AUTHORCODE As String,
                                              ByVal ORC12_PHYSICIANCODE As String, ByVal ORC25_ORDERSTATUS As Integer,
                                              ByVal OBR4_EXAMCODE As String, ByRef OBR4_EXAMNAME As String,
                                              ByRef ORC6_ORDERDATE As Date, ByRef OBR13_CLINICALINFO As String, ByRef OBR31_STUDYREASON As String,
                                              ByVal CC_ORIGEN As String, ByVal CC_DESTINO As String, ByVal NroPedido As Decimal, ByVal sucursal As String,
                                              ByVal Prestador As String, ByVal OBX_ENTIDAD As String, ByVal OBX_CODIGO_HIS As String,
                                              ByVal NOMBRE_MEDICO As String,
                                              ByVal ano_adm As String, ByVal num_adm As String, ByVal particularidades As String, ByVal LinkedServer As String,
                                              Optional ByVal intConse As Integer = 0) As Long


            Dim lError As Long
            Dim obs As String
            Dim Orden As String

            If NroPedido > 0 Then
                obs = "CON PEDIDO"
            Else
                obs = "SIN PEDIDO"
            End If
            If ORC25_ORDERSTATUS = 0 Then
                Orden = ORC4_ORDERGROUP & "-" & intConse
            Else
                Orden = ORC4_ORDERGROUP
            End If
            Me.setSQLSentence(LinkedServer + "[DBO].[HC_GrabarOrdenesMedicasAGFA]", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("MSH_STATUS", SqlDbType.VarChar, MSH_STATUS)
            Me.addInputParameter("MSH_DATE", SqlDbType.DateTime, MSH_DATE)
            Me.addInputParameter("PID2_ID", SqlDbType.VarChar, PID2_ID)
            Me.addInputParameter("PID5_LNAME", SqlDbType.VarChar, PID5_LNAME)
            Me.addInputParameter("PID5_FNAME", SqlDbType.VarChar, PID5_FNAME)
            Me.addInputParameter("PID7_BDATE", SqlDbType.DateTime, PID7_BDATE)
            Me.addInputParameter("PID8_SEX", SqlDbType.VarChar, PID8_SEX)
            Me.addInputParameter("PID11_ADDRESS", SqlDbType.VarChar, PID11_ADDRESS)
            Me.addInputParameter("PV118_PATIENT_TYPE", SqlDbType.VarChar, PV118_PATIENT_TYPE)
            Me.addInputParameter("PV119_ADMIN_NUMB", SqlDbType.VarChar, PV119_ADMIN_NUMB)
            Me.addInputParameter("ORC2_ORDERNUMBER", SqlDbType.VarChar, ORC2_ORDERNUMBER)
            Me.addInputParameter("ORC2_OPN_ID", SqlDbType.VarChar, ORC2_OPN_ID)
            Me.addInputParameter("ORC4_ORDERGROUP", SqlDbType.VarChar, Orden)
            Me.addInputParameter("ORC7_STARTDATE", SqlDbType.DateTime, ORC7_STARTDATE)
            Me.addInputParameter("ORC7_ENDDATE", SqlDbType.DateTime, ORC7_ENDDATE)
            Me.addInputParameter("ORC7_PRIORITY", SqlDbType.TinyInt, ORC7_PRIORITY)
            Me.addInputParameter("ORC10_AUTHORCODE", SqlDbType.VarChar, ORC10_AUTHORCODE)
            Me.addInputParameter("ORC12_PHYSICIANCODE", SqlDbType.VarChar, ORC12_PHYSICIANCODE)
            Me.addInputParameter("ORC25_ORDERSTATUS", SqlDbType.Int, ORC25_ORDERSTATUS)
            Me.addInputParameter("OBR4_EXAMCODE", SqlDbType.VarChar, OBR4_EXAMCODE)
            Me.addInputParameter("OBR4_EXAMNAME", SqlDbType.VarChar, OBR4_EXAMNAME)
            Me.addInputParameter("ORC6_ORDERDATE", SqlDbType.DateTime, ORC6_ORDERDATE)
            Me.addInputParameter("OBR13_CLINICALINFO", SqlDbType.VarChar, OBR13_CLINICALINFO)
            Me.addInputParameter("OBR31_STUDYREASON", SqlDbType.VarChar, OBR31_STUDYREASON)
            Me.addInputParameter("CC_ORIGEN", SqlDbType.VarChar, CC_ORIGEN)
            Me.addInputParameter("CC_DESTINO", SqlDbType.VarChar, CC_DESTINO)
            Me.addInputParameter("NroPedido", SqlDbType.Decimal, NroPedido)
            ' herojas 2014/09/15 se le agrega el parameto entidad para que en la tabla agfa_orm_in quede guardada la entidad
            Me.addInputParameter("OBX_ENTIDAD", SqlDbType.VarChar, OBX_ENTIDAD)
            ' herojas 2014/10/09 se le agregan los parametros codigo sophia, observaciones y el nombre del medico para que sean mostrados en el log agfa
            Me.addInputParameter("OBX_CODIGO_HIS", SqlDbType.VarChar, OBX_CODIGO_HIS)
            Me.addInputParameter("OBX_NOMBRE_MEDICO", SqlDbType.VarChar, NOMBRE_MEDICO)
            Me.addInputParameter("OBX_OBS_SIS", SqlDbType.VarChar, obs)
            Me.addInputParameter("sucursal", SqlDbType.VarChar, sucursal)
            Me.addInputParameter("Prestador", SqlDbType.VarChar, Prestador)
            '=============
            Me.addOutputParameter("lError", SqlDbType.Int)
            ' herojas 2015/02/11 Para consultar la cama se envia la admision       
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("num_adm", SqlDbType.Decimal, num_adm)
            Me.addInputParameter("rsParticularidades", SqlDbType.VarChar, particularidades) ''CCGUTIEREZ - OSI. 07/09/2020. Se agrega parametro dr("particularidades")
            Me.Exec()
            lError = Me.Parameters("lError").Value

            Return lError
        End Function



        ''Se agrega CCorigen Claudia Garay Junio 2011
        Public Shared Function consultarCentroCostoDestinoXProcedim(ByVal objConexion As Conexion, ByVal strCodPreSgs As String, ByVal strCodSucur As String, ByVal strCodProcedim As String, ByVal strCCOrigen As String) As DataTable
            Dim objGeneral As New DAOGeneral

            Return objGeneral.EjecutarSPConParametros("HC_TraerCentroDeCostoDestino", objConexion, -1,
                                                      strCodPreSgs, strCodSucur, strCodProcedim, strCCOrigen)
        End Function

        Public Shared Function traerInformacionCentroCosto(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String, ByVal strCod_sucur As String, ByVal strCodigoCentroCosto As String) As DataTable
            Dim objGeneral As New DAOGeneral

            Return objGeneral.EjecutarSPConParametros("DB_TraerInfoCentroCosto", objConexion, -1, strCod_pre_sgs, strCod_sucur, strCodigoCentroCosto)
        End Function

        Public Shared Function consultarAdmision(ByVal objConexion As Conexion, ByVal codPreSgs As String,
                                                   ByVal codSucur As String, ByVal tipoAdmision As String,
                                                   ByVal anoAdm As String, ByVal numAdm As String) As DataTable
            Dim objGeneral As New DAOGeneral

            Return objGeneral.EjecutarSPConParametros("DB_TraerInfoAdmision", objConexion, -1, codPreSgs,
                                                      codSucur, tipoAdmision, anoAdm, numAdm)
        End Function
        Public Shared Function consultarAdmisionEnt(ByVal objConexion As Conexion, ByVal codPreSgs As String,
                                                   ByVal codSucur As String, ByVal tipoAdmision As String,
                                                   ByVal anoAdm As String, ByVal numAdm As String, ByVal strEntidad As String) As DataTable
            Dim objGeneral As New DAOGeneral

            Return objGeneral.EjecutarSPConParametros("DB_TraerInfoAdmisionEnt", objConexion, -1, codPreSgs,
                                                      codSucur, strEntidad, tipoAdmision, anoAdm, numAdm)
        End Function
        Public Shared Function consultarExamenTipEnt(ByVal objConexion As Conexion, ByVal strCodExamen As Integer, ByVal strEntidad As String) As DataTable
            Dim objGeneral As New DAOGeneral

            Return objGeneral.EjecutarSPConParametros("HC_ExemenTipEnt", objConexion, -1, strCodExamen, strEntidad)
        End Function

        Public Shared Function consultarEntidad(ByVal objConexion As Conexion, ByVal strEntidad As String) As DataTable
            Dim objGeneral As New DAOGeneral

            Return objGeneral.EjecutarSPConParametros("DB_TraerInfoEntidad", objConexion, -1, strEntidad)
        End Function
        ''Claudia Garay Abril 5 de 2011
        Public Function GrabarAuditOrdenes(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String,
                                               ByVal strCod_sucur As String, ByVal strTip_Admision As String,
                                               ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double,
                                               ByVal paciente As String, ByVal strmedico As String,
                                               ByVal Iom As Integer, ByVal Iog As Integer, ByVal Iod As Integer,
                                               ByVal Iop As Integer, ByVal Nrorden As Decimal, ByVal strobs As String, ByVal strtipo As String) As Long

            Dim lError As Long



            Me.setSQLSentence("hc_ingresatablaAuditOrdenes", CommandType.StoredProcedure)
            Me.ParametersCollection.Clear()
            Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, strCod_pre_sgs)
            Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, strCod_sucur)
            Me.addInputParameter("@tip_admision", SqlDbType.VarChar, strTip_Admision)
            Me.addInputParameter("@ano_adm", SqlDbType.Int, strAno_Adm)
            Me.addInputParameter("@num_adm", SqlDbType.Int, strNum_Adm)
            Me.addInputParameter("@medico", SqlDbType.VarChar, strmedico)
            Me.addInputParameter("@paciente", SqlDbType.VarChar, paciente)
            Me.addInputParameter("@countom", SqlDbType.Int, Iom)
            Me.addInputParameter("@countog", SqlDbType.Int, Iog)
            Me.addInputParameter("@countod", SqlDbType.Int, Iod)
            Me.addInputParameter("@countop", SqlDbType.Int, Iop)
            Me.addInputParameter("@NroOrden", SqlDbType.Int, Nrorden)
            Me.addInputParameter("@obs", SqlDbType.VarChar, strobs)
            Me.addInputParameter("@tipo", SqlDbType.VarChar, strtipo)
            Me.addInputParameter("@Error", SqlDbType.Int, lError)

            Me.Exec()
            lError = Me.Parameters("Error").Value

            Return lError
        End Function
        Public Function consultarCCOrigen(ByVal objconexion As Conexion, ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String,
                                                           ByVal strTip_admision As String, ByVal iAno_adm As Integer,
                                                           ByVal lNum_adm As Double, ByVal strEntidad As String) As String

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim strCentroCostoOrigen As String

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objconexion.strServidor, objconexion.strBaseDatos, objconexion.strUsuarioBD, objconexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetStoredProcCommandWrapper("HC_TraerCentroDeCostoOrigen")
            '' ''With command
            '' ''    .AddInParameter("strcod_pre_sgs", DbType.String, strcod_pre_sgs)
            '' ''    .AddInParameter("strCod_sucur", DbType.String, strCod_sucur)
            '' ''    .AddInParameter("strTip_admision", DbType.String, strTip_admision)
            '' ''    .AddInParameter("lNum_adm", DbType.Double, lNum_adm)
            '' ''    .AddInParameter("iAno_adm", DbType.Int16, iAno_adm)
            '' ''    .AddInParameter("strEntidad", DbType.String, strEntidad)
            '' ''    .AddOutParameter("cen_cos_origen", DbType.String, 8)
            '' ''End With

            '' ''db.ExecuteDataSet(command)
            '' ''strCentroCostoOrigen = command.GetParameterValue("@cen_cos_origen").ToString

            Me.setSQLSentence("HC_TraerCentroDeCostoOrigen", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("strcod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            Me.addInputParameter("strCod_sucur", SqlDbType.VarChar, strCod_sucur)
            Me.addInputParameter("strTip_admision", SqlDbType.VarChar, strTip_admision)
            Me.addInputParameter("lNum_adm", SqlDbType.Decimal, lNum_adm)
            Me.addInputParameter("iAno_adm", SqlDbType.Int, iAno_adm)
            Me.addInputParameter("strEntidad", SqlDbType.VarChar, strEntidad)
            Me.addOutputParameter("cen_cos_origen", SqlDbType.VarChar, 8)

            Me.execDS()

            strCentroCostoOrigen = IIf(IsDBNull(Me.Parameters("cen_cos_origen").Value), "", Me.Parameters("cen_cos_origen").Value)

            Return strCentroCostoOrigen

        End Function

        Public Function consultarMarcaccostopedidoPyxis(ByVal objconexion As Conexion, ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String,
                                                           ByVal strcen_costo As String, ByVal strTip_admision As String, ByVal iAno_adm As Integer,
                                                           ByVal lNum_adm As Double) As String

            Dim dtDatosCentroCosto As New DataTable

            Me.setSQLSentence("HCOR_validarcentrocostoPyxis", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("strcod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            Me.addInputParameter("strCod_sucur", SqlDbType.VarChar, strCod_sucur)
            Me.addInputParameter("strcen_costo", SqlDbType.VarChar, strcen_costo)
            Me.addInputParameter("strTip_admision", SqlDbType.VarChar, strTip_admision)
            Me.addInputParameter("lNum_adm", SqlDbType.Decimal, lNum_adm)
            Me.addInputParameter("iAno_adm", SqlDbType.Int, iAno_adm)

            dtDatosCentroCosto = Me.execDT()

            If Not dtDatosCentroCosto Is Nothing Then
                If dtDatosCentroCosto.Rows.Count > 0 Then
                    Return dtDatosCentroCosto.Rows(0).Item("strexisteMarca").ToString
                Else
                    Return ""
                End If
            Else
                Return ""
            End If


        End Function
        ''Claudia Garay Ctc's Marzo 21 2012
        Public Function ValidaExcepciones(ByVal strEntidad As String, ByVal strCodPrograma As String) As Integer


            Me.setSQLSentence("pa_productosconexcepcion", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("Entidad", SqlDbType.VarChar, strEntidad)
            Me.addInputParameter("Producto", SqlDbType.VarChar, strCodPrograma)
            Me.addOutputParameter("Result", SqlDbType.VarChar, 8)

            Me.execDS()

            Return Me.Parameters("Result").Value

        End Function
        ''Claudia Garay Ctc's Marzo 27 2012
        Public Function ValidaExcepcionesProce(ByVal strEntidad As String, ByVal strCodPrograma As String) As Integer


            Me.setSQLSentence("pa_procedimientoconexcepcion", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("Entidad", SqlDbType.VarChar, strEntidad)
            Me.addInputParameter("Procedim", SqlDbType.VarChar, strCodPrograma)
            Me.addOutputParameter("Result", SqlDbType.VarChar, 8)

            Me.execDS()

            Return Me.Parameters("Result").Value

        End Function

        ''Claudia Garay Ctc's Abril 2 2012
        Public Function ConsultaOrdenesConExcepcion(ByVal cod_pre_sgs As String, ByVal cod_sucur As String,
        ByVal tip_admision As String, ByVal num_adm As Double, ByVal ano_adm As Integer) As DataTable
            Dim dt As New DataTable

            Me.setSQLSentence("HC_ConsultaOrdenesExcepciones", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, cod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("num_adm", SqlDbType.VarChar, num_adm)
            Me.addInputParameter("ano_adm", SqlDbType.VarChar, ano_adm)


            dt = Me.execDT

            Return dt

        End Function
        ''Claudia Garay Ctc's Noviembre 23 de 2012
        Public Function ConsultaMedicamentosEquivalentes(ByVal cod_corto As String) As DataTable
            Dim dt As New DataTable

            Me.setSQLSentence("pa_TraerProductoEquivalente", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_corto", SqlDbType.VarChar, cod_corto)
            dt = Me.execDT

            Return dt

        End Function

        ''ER_OSI_596_Indicaciones_Medicas
        ''Martovar 2017/09/27
        Public Function ConsultaIndicaciones(ByVal codigo As Integer) As DataTable
            Dim dt As New DataTable

            Me.setSQLSentence("pa_TraerIndicaciones", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("codigo", SqlDbType.VarChar, codigo)
            dt = Me.execDT

            Return dt

        End Function
        ''Claudia Garay Diciembre 19 de Diciembre tk 480890-20121207
        Public Sub GrabarErroresOrdenesMed(ByVal Descripcion As String)


            Me.setSQLSentence("DB_InsertarInfoGenerrorSophia", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("descripcion", SqlDbType.VarChar, Descripcion)
            Me.Exec()



        End Sub

        Public Sub GrabarErroresOrdenesMedHomolo(ByVal Descripcion As String, ByVal linkedserver As String)
            Me.setSQLSentence(linkedserver + "[dbo].[DB_InsertarInfoGenerrorSophia]", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("descripcion", SqlDbType.VarChar, Descripcion)
            Me.Exec()
        End Sub

        'martovar codificacion se agregan prestador y sucursal
        Public Function consultarautorizacionProcedimientos(ByVal procedim As String, ByVal entidad As String, ByVal cod_pre_sgs As String, ByVal cod_sucur As String) As DataTable
            Dim dt As New DataTable
            'codificacion se agregan prestador y sucursal para consulta en genproent
            Me.setSQLSentence("DB_TraerInfoProcedimietoEntidad", CommandType.StoredProcedure)
            Me.addInputParameter("strentidad", SqlDbType.VarChar, entidad)
            Me.addInputParameter("strprocedim", SqlDbType.VarChar, procedim)
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, cod_sucur)
            dt = Me.execDT

            Return dt

        End Function
        Public Function consultar_Ordenes_Laboratorio_Procedimiento(ByVal strcodpresgs As String, ByVal strcodsucur As String, ByVal strTipAdmision As String,
                                                                   ByVal ano_adm As Integer, ByVal num_adm As Integer, ByVal strprocedim As String) As DataTable
            Dim dt As New DataTable

            Me.setSQLSentence("Hc_consultaOrdenesLabotario", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("strCod_pre_sgs", SqlDbType.VarChar, strcodpresgs)
            Me.addInputParameter("strCod_sucur", SqlDbType.VarChar, strcodsucur)
            Me.addInputParameter("Tip_Admision", SqlDbType.VarChar, strTipAdmision)
            Me.addInputParameter("iAno_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("num_adm", SqlDbType.Decimal, num_adm)
            Me.addInputParameter("strprocedim", SqlDbType.VarChar, strprocedim)
            Me.addInputParameter("lError", SqlDbType.Int, 0)
            Me.addInputParameter("strMensaje", SqlDbType.VarChar, "")
            dt = Me.execDT

            Return dt

        End Function

        'agfa_orm_in 2014/10/10
        Public Sub ConsultarDatosGrabacionPedidosRis(ByVal strcod_pre_sgs As String, ByVal strcod_sucur As String,
      ByVal tip_admision As String, ByVal num_adm As Integer, ByVal ano_adm As Integer, ByVal strprocedim As String,
      ByRef generaPedido As String, ByRef procedimHomologo As String, ByRef entidadvalida As String, ByVal strCcosto As String)


            Me.setSQLSentence("HC_ValidarProcedimientosRis", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strcod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("num_adm", SqlDbType.VarChar, num_adm)
            Me.addInputParameter("ano_adm", SqlDbType.VarChar, ano_adm)
            Me.addInputParameter("procedim", SqlDbType.VarChar, strprocedim)
            Me.addOutputParameter("generaPedido", SqlDbType.VarChar, 1)
            Me.addOutputParameter("procedimHomologo", SqlDbType.VarChar, 9)
            Me.addInputParameter("entidad", SqlDbType.VarChar, entidadvalida)
            Me.addInputParameter("ccosto", SqlDbType.VarChar, strCcosto)
            Me.Exec()

            generaPedido = Me.Parameters("generaPedido").Value
            procedimHomologo = IIf(IsDBNull(Me.Parameters("procedimHomologo").Value), "", Me.Parameters("procedimHomologo").Value)

        End Sub


        Public Sub ConsultarDatosGrabacionPedidosRisHomolo(ByVal strcod_pre_sgs As String, ByVal strcod_sucur As String,
      ByVal tip_admision As String, ByVal num_adm As Integer, ByVal ano_adm As Integer, ByVal strprocedim As String,
      ByRef generaPedido As String, ByRef procedimHomologo As String, ByRef entidadvalida As String, ByVal strCcosto As String, ByVal LinkedServer As String)

            Me.setSQLSentence(LinkedServer + "[dbo].[HC_ValidarProcedimientosRis]", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strcod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("num_adm", SqlDbType.Decimal, num_adm)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("procedim", SqlDbType.VarChar, strprocedim)
            Me.addOutputParameter("generaPedido", SqlDbType.VarChar, 1)
            Me.addOutputParameter("procedimHomologo", SqlDbType.VarChar, 9)
            Me.addInputParameter("entidad", SqlDbType.VarChar, entidadvalida)
            Me.addInputParameter("ccosto", SqlDbType.VarChar, strCcosto)
            Me.Exec()

            generaPedido = Me.Parameters("generaPedido").Value
            procedimHomologo = IIf(IsDBNull(Me.Parameters("procedimHomologo").Value), "", Me.Parameters("procedimHomologo").Value)

        End Sub


        'agfa_orm_in herojas 2014/10/09 consulta el numero de pedido para una orden de procedimiento
        Public Sub ConsultarDatosPedidoOrdenRis(ByVal strcod_pre_sgs As String, ByVal strcod_sucur As String,
      ByVal tip_admision As String, ByVal num_adm As Integer, ByVal ano_adm As Integer, ByVal nroOrden As Decimal, ByVal strprocedim As String,
      ByRef numPedido As Decimal)


            Me.setSQLSentence("HC_ConsultarPedidoRis", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strcod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("num_adm", SqlDbType.VarChar, num_adm)
            Me.addInputParameter("ano_adm", SqlDbType.VarChar, ano_adm)
            Me.addInputParameter("num_orden", SqlDbType.Decimal, nroOrden)
            Me.addInputParameter("procedim", SqlDbType.VarChar, strprocedim)
            Me.addOutputParameter("num_pedido", SqlDbType.Decimal, numPedido)
            Me.Exec()

            numPedido = Me.Parameters("num_pedido").Value

        End Sub

        Public Sub ConsultarDatosPedidoOrdenRisHomolo(ByVal strcod_pre_sgs As String, ByVal strcod_sucur As String,
      ByVal tip_admision As String, ByVal num_adm As Integer, ByVal ano_adm As Integer, ByVal nroOrden As Decimal, ByVal strprocedim As String,
      ByRef numPedido As Decimal, ByVal linkedserver As String)


            Me.setSQLSentence(linkedserver + "[dbo].[HC_ConsultarPedidoRis]", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strcod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("num_adm", SqlDbType.VarChar, num_adm)
            Me.addInputParameter("ano_adm", SqlDbType.VarChar, ano_adm)
            Me.addInputParameter("num_orden", SqlDbType.Decimal, nroOrden)
            Me.addInputParameter("procedim", SqlDbType.VarChar, strprocedim)
            Me.addOutputParameter("num_pedido", SqlDbType.Decimal, numPedido)
            Me.Exec()

            numPedido = Me.Parameters("num_pedido").Value

        End Sub

        'agfa_orm_in herojas 2014/10/09 anula pedido de procedimiento en en ris
        Public Sub AnulaPedidoSophia(ByVal strcod_pre_sgs As String, ByVal strcod_sucur As String,
      ByVal cen_costo_des As String, ByVal numPedido As Decimal, ByVal strLogin As String, ByVal Obs As String)


            Me.setSQLSentence("HC_AnularPedidoRis", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strcod_sucur)
            Me.addInputParameter("cen_costo_des", SqlDbType.VarChar, cen_costo_des)
            Me.addInputParameter("num_pedido", SqlDbType.Decimal, numPedido)
            Me.addInputParameter("login", SqlDbType.VarChar, strLogin)
            Me.addInputParameter("obs", SqlDbType.VarChar, Obs)
            Me.Exec()


        End Sub

        'Version 3.0.0 CTC para medicina prepagada herojas 2015/01/15
        Public Function ValidarSegundaEntidadNoPOS(ByVal strCod_pre_sgs As String,
                                                       ByVal strCod_sucur As String, ByVal strTip_Admision As String,
                                                       ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double,
                                                       ByVal strProducto As String) As String

            Dim dtDatos As DataTable
            Dim strProcedimiento As String = ""

            Me.setSQLSentence("HC_ValidarSegundaEntidadNoPOS", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strCod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, strTip_Admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, strAno_Adm)
            Me.addInputParameter("num_adm", SqlDbType.Int, strNum_Adm)
            Me.addInputParameter("producto", SqlDbType.VarChar, strProducto)
            Me.addOutputParameter("pide_ctc", SqlDbType.VarChar, 1)

            dtDatos = Me.execDT

            ValidarSegundaEntidadNoPOS = Me.Parameters("pide_ctc").Value

        End Function



        ''Desarrollo realizado por Jimmy Guevara(Intergrupo)

        ''' <summary>
        ''' Se encarga de consultar a la base de datos la informacion correspondiente a la homologacion de la sucursal
        ''' </summary>
        ''' <param name="strCod_pre_sgs"></param>
        ''' <param name="strCod_sucur"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ConsultarHomologacion(ByVal strCod_pre_sgs As String, ByVal strCod_sucur As String) As DataTable

            Dim dtDatos As DataTable
            Dim strProcedimiento As String = ""
            Me.setSQLSentence("[dbo].[PR_TR_CONSULTAR_HOMOLOGACION_SUCURSAL]", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("strCod_pre_sgs_origen", SqlDbType.VarChar, strCod_pre_sgs)
            Me.addInputParameter("strCod_sucur_origen", SqlDbType.VarChar, strCod_sucur)
            dtDatos = Me.execDT
            Return dtDatos
        End Function

        ''' <summary>
        ''' Se encarga de consultar por el id de localizacion el linked server
        ''' </summary>
        ''' <param name="idLocalizacion"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ConsultarLinkedServer(ByVal idLocalizacion As Int32) As String

            Dim sLINKED_SERVER As String

            Dim dtDatos As DataTable
            Dim strProcedimiento As String = ""
            Me.setSQLSentence("[dbo].[PR_CONSULTAR_LINKED_SERVER_X_LOCALIZACION]", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("nID_LOCALIZACION", SqlDbType.Int, idLocalizacion)
            Me.addOutputParameter("sLINKED_SERVER", SqlDbType.VarChar, 100)
            dtDatos = Me.execDT
            sLINKED_SERVER = Me.Parameters("sLINKED_SERVER").Value
            Return sLINKED_SERVER
        End Function

        ''' <summary>
        ''' Metodo que recibe el procedimiento y si existe esta entre los permitidos
        ''' </summary>
        ''' <param name="strCategoria"></param>
        ''' <param name="strCodigo"></param>
        ''' <param name="intEdad"></param>
        ''' <param name="strSexo"></param>
        ''' <param name="ManejaConvenio"></param>
        ''' <param name="strMedicamento"></param>
        ''' <param name="intConSinEstado"></param>
        ''' <param name="strCodPreSgs"></param>
        ''' <param name="CodSucur"></param>
        ''' <param name="strEntidad"></param>
        ''' <param name="strFecIni"></param>
        ''' <param name="strCodProcedimiento"></param>
        ''' <param name="strCodSucur"></param>
        ''' <param name="LinkedServer"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ConsultarProcedimientoPorCodigo(ByVal strCategoria As String, ByVal strCodigo As String, ByVal intEdad As Int32, ByVal strSexo As String, ByVal ManejaConvenio As String, ByVal strMedicamento As String, ByVal intConSinEstado As Int32, ByVal strCodPreSgs As String, ByVal strEntidad As String, ByVal strFecIni As String, ByVal strCodProcedimiento As String, ByVal strCodSucur As String, ByVal LinkedServer As String) As DataTable

            Dim dtDatos As DataTable
            Dim strProcedimiento As String = ""
            Me.setSQLSentence(LinkedServer + "[dbo].[HC_BuscarCodigo]", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("strCategoria", SqlDbType.VarChar, strCategoria)
            Me.addInputParameter("strCodigo", SqlDbType.VarChar, strCodigo)
            Me.addInputParameter("intEdad", SqlDbType.Int, intEdad)
            Me.addInputParameter("strSexo", SqlDbType.VarChar, strSexo)
            Me.addInputParameter("strManejaConvenio", SqlDbType.VarChar, ManejaConvenio)
            Me.addInputParameter("strMedicamento", SqlDbType.VarChar, strMedicamento)
            Me.addInputParameter("intConSinEstado", SqlDbType.Int, intConSinEstado)
            Me.addInputParameter("strCodPreSgs", SqlDbType.VarChar, strCodPreSgs)
            Me.addInputParameter("strCodSucur", SqlDbType.VarChar, strCodSucur)
            Me.addInputParameter("strEntidad", SqlDbType.VarChar, strEntidad)
            Me.addInputParameter("strFecIni", SqlDbType.VarChar, strFecIni)
            Me.addInputParameter("strCodProcedimiento", SqlDbType.VarChar, strCodProcedimiento)
            dtDatos = Me.execDT
            Return dtDatos

        End Function

        ''' <summary>
        ''' Metodo que consulta el consecutio para la admision
        ''' </summary>
        ''' <param name="strCodSucur"></param>
        ''' <param name="strCentroCosto"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ConsultarConsecutivo(ByVal strCodSucur As String, ByVal strCentroCosto As String, ByVal LinkedServer As String) As Int32

            Dim iConsecutivoCarmovim As Int32
            Dim dtDatos As DataTable
            Dim strProcedimiento As String = ""
            Me.setSQLSentence(LinkedServer + "[dbo].[sp_get_Next_NumberCenso]", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("TypeID", SqlDbType.VarChar, strCentroCosto)
            Me.addInputParameter("TranDate", SqlDbType.VarChar, String.Empty)
            Me.addInputParameter("sucursal", SqlDbType.VarChar, strCodSucur)
            Me.addInputParameter("secondType", SqlDbType.VarChar, String.Empty)
            Me.addOutputParameter("seq_val", SqlDbType.VarChar, 100)
            dtDatos = Me.execDT
            If (Me.Parameters("seq_val").SqlValue.IsNull) Then
                iConsecutivoCarmovim = 0
            Else
                iConsecutivoCarmovim = Me.Parameters("seq_val").Value
            End If



            Return iConsecutivoCarmovim

        End Function

        ''' <summary>
        ''' Consulta las entidades relacionadas con una admision en particular
        ''' </summary>
        ''' <param name="Anno"></param>
        ''' <param name="TipoAdmision"></param>
        ''' <param name="NumeroAdmision"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ConsultarEntidadesPorAdmision(ByVal Anno As Integer, ByVal TipoAdmision As String, ByVal NumeroAdmision As Integer) As DataTable

            Dim iConsecutivoCarmovim As Int32
            Dim dtDatos As DataTable
            Dim strProcedimiento As String = ""
            Me.setSQLSentence("[dbo].[PR_TR_CONSULTAR_ENTIDADES_ADMISION]", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, TipoAdmision)
            Me.addInputParameter("ano_adm", SqlDbType.VarChar, Anno)
            Me.addInputParameter("num_adm", SqlDbType.VarChar, NumeroAdmision)
            dtDatos = Me.execDT
            Return dtDatos

        End Function

        ''' <summary>
        ''' Metodo encargado de consultar el cargo automatico
        ''' </summary>
        ''' <param name="sEntidadPrestadora"></param>
        ''' <param name="sCodigoSucursal"></param>
        ''' <param name="sEntidad"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ConsultarCargoAutmatico(ByVal sEntidadPrestadora As String, ByVal sCodigoSucursal As String, ByVal sEntidad As String, ByVal sTipoAdmision As String, ByVal sTipoPlan As String, ByVal dFecha As Date, ByVal sEspecialidad As String, ByVal sMotivoIngreso As String, ByVal sRedondeo As String, ByVal nCantidad As Int32, ByVal nEdad As Int32, ByVal sTipoDocumento As String, ByVal sNumeroDocumento As String, ByVal sMedico As String, ByVal sNumeroProcedimiento As String, ByVal LinkedServer As String, ByVal idLocalizacionDestino As Int32) As DataTable

            Dim iConsecutivoCarmovim As Int32
            Dim dtDatos As DataTable
            Dim strProcedimiento As String = ""
            Me.setSQLSentence(LinkedServer + "[dbo].[PR_TR_OBTENER_CARGO_AUTOMATICO]", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("sEntidadPrestadora", SqlDbType.VarChar, sEntidadPrestadora)
            Me.addInputParameter("sCodigoSucursal", SqlDbType.VarChar, sCodigoSucursal)
            Me.addInputParameter("sEntidad", SqlDbType.VarChar, sEntidad)
            Me.addInputParameter("sTipoAdmision", SqlDbType.VarChar, sTipoAdmision)
            Me.addInputParameter("sTipoPlan", SqlDbType.VarChar, sTipoPlan)
            Me.addInputParameter("dFecha", SqlDbType.DateTime, dFecha)
            Me.addInputParameter("sEspecialidad", SqlDbType.VarChar, sEspecialidad)
            Me.addInputParameter("sMotivoIngreso", SqlDbType.VarChar, sMotivoIngreso)
            Me.addInputParameter("sRedondeo", SqlDbType.VarChar, sRedondeo)
            Me.addInputParameter("nCantidad", SqlDbType.Int, nCantidad)
            Me.addInputParameter("nEdad", SqlDbType.Int, nEdad)
            Me.addInputParameter("sTipoDocumento", SqlDbType.VarChar, sTipoDocumento)
            Me.addInputParameter("sNumeroDocumento", SqlDbType.VarChar, sNumeroDocumento)
            Me.addInputParameter("sMedico", SqlDbType.VarChar, sMedico)
            Me.addInputParameter("nLocalizacion", SqlDbType.Int, idLocalizacionDestino)
            Me.addInputParameter("sNumeroProcedimiento", SqlDbType.VarChar, sNumeroProcedimiento)
            dtDatos = Me.execDT
            Return dtDatos

        End Function

        Public Function GuardarAdmisionHomologada(ByVal datosAdmision As DataTable, ByVal LinkedServer As String) As DataTable

            Dim dtDatos As DataTable
            Dim dtrRespuesta As New DataTable
            Dim numeroAdmision As String = String.Empty
            Dim erro As String = String.Empty
            dtrRespuesta.Columns.Add("NumeroAdmisionDestino")
            dtrRespuesta.Columns.Add("AnoAdmisionDestino")
            dtrRespuesta.Columns.Add("TipoAdmisionDestino")
            dtrRespuesta.Columns.Add("error")
            Me.setSQLSentence(LinkedServer + "[dbo].[pa_Urgencias_grabarAdmisionModificado]", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("strCadenaConexion", SqlDbType.VarChar, datosAdmision.Rows(0)("strCadenaConexion"))
            Me.addInputParameter("strCodPreSgs", SqlDbType.VarChar, datosAdmision.Rows(0)("strCodPreSgs"))
            Me.addInputParameter("strCodSucur", SqlDbType.VarChar, datosAdmision.Rows(0)("strCodSucur"))
            Me.addInputParameter("strTipAdm", SqlDbType.VarChar, datosAdmision.Rows(0)("strTipAdm"))
            Me.addInputParameter("strIngrInactivo", SqlDbType.VarChar, datosAdmision.Rows(0)("strIngrInactivo"))
            Me.addInputParameter("strEspec", SqlDbType.VarChar, datosAdmision.Rows(0)("strEspec"))
            Me.addInputParameter("dteFecIngreso", SqlDbType.DateTime, Format(Convert.ToDateTime(datosAdmision.Rows(0)("dteFecIngreso")), "yyyy/MM/dd"))
            Me.addInputParameter("iHorIngreso", SqlDbType.Int, datosAdmision.Rows(0)("nHoraIngreso"))
            Me.addInputParameter("iMinIngreso", SqlDbType.Int, datosAdmision.Rows(0)("iMinIngreso"))
            Me.addInputParameter("strConPriVez", SqlDbType.VarChar, datosAdmision.Rows(0)("strConPriVez"))
            Me.addInputParameter("strEntidad1", SqlDbType.VarChar, datosAdmision.Rows(0)("strEntidad1"))
            Me.addInputParameter("strEntidad2", SqlDbType.VarChar, datosAdmision.Rows(0)("strEntidad2"))
            Me.addInputParameter("bInsEntidad1", SqlDbType.Bit, 0)
            Me.addInputParameter("bInsEntidad2", SqlDbType.Bit, 0)
            Me.addInputParameter("strCarnet", SqlDbType.VarChar, datosAdmision.Rows(0)("strCarnet"))
            Me.addInputParameter("strManTriage", SqlDbType.VarChar, datosAdmision.Rows(0)("strManTriage"))
            Me.addInputParameter("rsTriage", SqlDbType.VarChar, datosAdmision.Rows(0)("rsTriage"))
            Me.addInputParameter("strCapitado", SqlDbType.VarChar, datosAdmision.Rows(0)("strCapitado"))
            Me.addInputParameter("strNumAutoriza", SqlDbType.VarChar, datosAdmision.Rows(0)("strNumAutoriza"))
            Me.addInputParameter("strNomAutoriza", SqlDbType.VarChar, datosAdmision.Rows(0)("strNomAutoriza"))
            Me.addInputParameter("strObs", SqlDbType.VarChar, datosAdmision.Rows(0)("sObservaciones"))
            Me.addInputParameter("strLogin", SqlDbType.VarChar, datosAdmision.Rows(0)("strLogin"))
            Me.addInputParameter("rspaciente", SqlDbType.VarChar, datosAdmision.Rows(0)("xPaciente"))
            Me.addInputParameter("rsPacRespon", SqlDbType.VarChar, datosAdmision.Rows(0)("xResponsable"))
            Me.addInputParameter("rsProcedim", SqlDbType.VarChar, datosAdmision.Rows(0)("xProcedimiento"))
            Me.addInputParameter("rsGenPacen", SqlDbType.VarChar, datosAdmision.Rows(0)("xGeneralPaciente"))
            Me.addInputParameter("rsAutorizacion", SqlDbType.VarChar, datosAdmision.Rows(0)("xAutorizacion"))
            Me.addInputParameter("rsSqlLlave", SqlDbType.VarChar, datosAdmision.Rows(0)("xSqlLlave"))
            Me.addInputParameter("rsInconsistencia", SqlDbType.VarChar, datosAdmision.Rows(0)("xInconsistencia"))
            Me.addOutputParameter("o_lNumAdm", SqlDbType.Int, 100)
            Me.addInputParameter("strPri_Ape", SqlDbType.VarChar, datosAdmision.Rows(0)("sPrimerApellido"))
            Me.addInputParameter("strPri_Nom", SqlDbType.VarChar, datosAdmision.Rows(0)("sPrimerNombre"))
            Me.addInputParameter("strSeg_Ape", SqlDbType.VarChar, datosAdmision.Rows(0)("sSegundoApellido"))
            Me.addInputParameter("strSeg_Nom", SqlDbType.VarChar, datosAdmision.Rows(0)("sSegundoNombre"))
            Me.addInputParameter("bAuditoria", SqlDbType.Bit, Convert.ToInt32(datosAdmision.Rows(0)("bAuditoria")))
            Me.addInputParameter("iNumCuotas", SqlDbType.Int, Convert.ToInt32(datosAdmision.Rows(0)("nNumeroCuotas")))
            Me.addOutputParameter("strRespuesta", SqlDbType.VarChar, 100)
            Me.addInputParameter("strClaseMotivInac", SqlDbType.VarChar, datosAdmision.Rows(0)("sClaseMotivoInactividad"))
            Me.addInputParameter("strTipoMotivInac", SqlDbType.VarChar, datosAdmision.Rows(0)("sTipoMotivoInactividad"))
            Me.addInputParameter("strMotivInac", SqlDbType.VarChar, datosAdmision.Rows(0)("sMotivoInactividad"))
            Me.addInputParameter("strManejarInterfaceRIS", SqlDbType.VarChar, datosAdmision.Rows(0)("sManejarInterfaceRIS"))
            Me.addInputParameter("strTip_Entidad", SqlDbType.VarChar, datosAdmision.Rows(0)("sTipoEntidad"))
            Me.addInputParameter("strusu_compartido", SqlDbType.VarChar, datosAdmision.Rows(0)("sUsuarioCompartido"))
            Me.addInputParameter("strautoriza_pac", SqlDbType.VarChar, datosAdmision.Rows(0)("sAutorizaPaciente"))
            Me.addInputParameter("strInconsistencia", SqlDbType.VarChar, datosAdmision.Rows(0)("sInconsistencia"))
            Me.addInputParameter("strIP", SqlDbType.VarChar, datosAdmision.Rows(0)("sIP"))
            Me.addOutputParameter("strConsecutivoFur", SqlDbType.Decimal, 100)
            Me.addInputParameter("o_lError", SqlDbType.Int, 0)
            Me.addInputParameter("iNumAdmision", SqlDbType.Int, Convert.ToInt32(datosAdmision.Rows(0)("iNumAdmision")))
            Me.addInputParameter("iConsecutivoCarmovim", SqlDbType.Int, Convert.ToInt32(datosAdmision.Rows(0)("iConsecutivoCarmovim")))

            dtDatos = Me.execDT
            If (Me.Parameters("o_lNumAdm").SqlValue.IsNull) Then
                numeroAdmision = "0"
            Else
                numeroAdmision = Me.Parameters("o_lNumAdm").Value
            End If

            If (Me.Parameters("o_lError").SqlValue.IsNull) Then
                erro = 0
            Else
                erro = Me.Parameters("o_lError").Value
            End If

            dtrRespuesta.Rows.Add(numeroAdmision, Date.Now.Year, datosAdmision.Rows(0)("strTipAdm"), erro)
            Return dtrRespuesta
        End Function

        ''' <summary>
        ''' Funcion que guarda los registros modificados y nuevos para todas las ordenes 
        ''' medicas(Dietas, medicamentos, procedimientos, ordenes generales). Para dietas,
        ''' medicamentos y procedimientos los registros modificados (Continuar - Suspender)
        ''' se inactivan y se crea un nuevo registro con una nuevo numero de orden, estado
        ''' activo y valor de tratamiento digitado por el usuario. Se insertan ademas los nuevos
        ''' registros  
        ''' </summary>
        ''' <param name="objConexion">Objeto con los datos de la conexion</param>
        ''' <param name="strCodSucur">Codigo de la sucursal</param>
        ''' <param name="xmlDietasModifica">XML con info de dietas modificadas</param>
        ''' <param name="xmlDietasNuevas">XML con info de nuevas dietas</param>
        ''' <param name="xmlMedicaModificados">XML con info de medicamentos modificados</param>
        ''' <param name="xmlMedicaNuevos">XML con info de Nuevos medicamentos</param>
        ''' <param name="xmlProceNuevos">XML con info de nuevos procedimientos</param>
        ''' <param name="NroOrden">Numero de orden que retorna el store procedure</param>
        ''' <returns>El posible numero de error generado en el store procedure</returns>
        ''' <remarks></remarks>
        Public Function guardarOrdenesHomologadas(ByVal objConexion As Conexion, ByVal LinkedServer As String, ByVal cod_pre_sgs As String,
                                              ByVal strCodSucur As String, ByVal tip_admision As String,
                                              ByVal num_adm As String, ByVal ano_adm As String, ByVal strLogin As String,
                                              ByVal medico As String, ByVal strCodEspecialidad As String, ByVal entidad As String,
                                              ByVal xmlAislamientosModifica As String, ByVal xmlAislamientosNuevos As String,
                                              ByVal xmlDietasModifica As String, ByVal xmlDietasNuevas As String,
                                              ByVal xmlMedicaModificados As String, ByVal xmlMedicaNuevos As String,
                                              ByVal xmlProceNuevos As String, ByVal xmlGeneralesModificados As String,
                                              ByVal xmlGeneralesNuevos As String, ByRef NroOrden As Double,
                                              ByRef fechaOrden As Date, ByRef centroCostoOrigen As String,
                                              ByRef strGuia As String, ByRef strJustificacion As String,
                                              ByRef strTipoServicio As String, ByRef strPrioridad As String) As DataTable

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007

            Dim lError As Long
            Dim respuestaOrden As New DataTable
            respuestaOrden.Columns.Add("NroOrden")
            respuestaOrden.Columns.Add("fechaOrden")
            respuestaOrden.Columns.Add("centroCostoOrigen")
            respuestaOrden.Columns.Add("lError")

            Me.setSQLSentence(LinkedServer + "[dbo].[HC_GrabarOrdenesMedicas]", CommandType.StoredProcedure)
            Me.ParametersCollection.Clear()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCodSucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("num_adm", SqlDbType.Int, num_adm)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("strLogin", SqlDbType.VarChar, strLogin)
            Me.addInputParameter("medico", SqlDbType.VarChar, medico)
            Me.addInputParameter("especialidad", SqlDbType.VarChar, strCodEspecialidad)
            Me.addInputParameter("entidad", SqlDbType.VarChar, entidad)
            Me.addInputParameter("@txtXmlAislamientosModif", SqlDbType.VarChar, xmlAislamientosModifica)
            Me.addInputParameter("@txtXmlAislamientosNuevos", SqlDbType.VarChar, xmlAislamientosNuevos)
            Me.addInputParameter("txtXmlDietasModif", SqlDbType.VarChar, xmlDietasModifica)
            Me.addInputParameter("txtXmlDietasNuevas", SqlDbType.VarChar, xmlDietasNuevas)
            Me.addInputParameter("txtXmlMedicaModificados", SqlDbType.VarChar, xmlMedicaModificados)
            Me.addInputParameter("txtXmlMedicaNuevos", SqlDbType.VarChar, xmlMedicaNuevos)
            Me.addInputParameter("txtXmlProceNuevos", SqlDbType.VarChar, xmlProceNuevos)
            Me.addInputParameter("txtXmlGeneralesModificados", SqlDbType.VarChar, xmlGeneralesModificados)
            Me.addInputParameter("txtXmlGeneralesNuevos", SqlDbType.VarChar, xmlGeneralesNuevos)
            Me.addOutputParameter("NewNroOrden", SqlDbType.Int)
            Me.addOutputParameter("fechaOrden", SqlDbType.DateTime)
            Me.addOutputParameter("centroDeCostoOrigen", SqlDbType.VarChar, 8)
            'parametros creados por Ing. Ricardo Mauricio Zaldúa C. 2009-02-03 Res 3047 solicitado por Mauricio Forero
            Me.addInputParameter("strGuia", SqlDbType.VarChar, strGuia)
            Me.addInputParameter("strJustificacion", SqlDbType.VarChar, strJustificacion)
            Me.addInputParameter("strTipoServicio", SqlDbType.VarChar, strTipoServicio)
            Me.addInputParameter("strPrioridad", SqlDbType.VarChar, strPrioridad)
            '=============
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()
            lError = Me.Parameters("lError").Value

            If IsNumeric(Me.Parameters("NewNroOrden").Value) Then
                NroOrden = CType(Me.Parameters("NewNroOrden").Value, Double)
            Else
                NroOrden = 0
            End If

            If IsDate(Me.Parameters("@fechaOrden").Value) Then
                fechaOrden = CType(Me.Parameters("@fechaOrden").Value, Date)
            End If

            If IsDBNull(Me.Parameters("@centroDeCostoOrigen").Value) Then
                centroCostoOrigen = ""
            Else
                centroCostoOrigen = Me.Parameters("@centroDeCostoOrigen").Value
            End If

            ValidarPedidoGenerado(cod_pre_sgs, strCodSucur, tip_admision, ano_adm, num_adm, NroOrden)
            respuestaOrden.Rows.Add(NroOrden, fechaOrden, centroCostoOrigen, lError)

            Return respuestaOrden

        End Function

        ''' <summary>
        ''' Metodo encargado de guardar el log de homologacion
        ''' </summary>
        ''' <param name="sEntidadPrestadora"></param>
        ''' <param name="sCodigoSucursal"></param>
        ''' <param name="sEntidad"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function GuardarLogHomologacion(ByVal Codigo_Admision_Origen As Decimal,
        ByVal Ano_Admision_Origen As Int32,
        ByVal Tipo_Admision_Origen As String,
        ByVal Codigo_Admision_Destino As Decimal,
        ByVal Ano_Admision_Destino As Int32,
        ByVal Tipo_Admision_Destino As String,
        ByVal Codigo_Orden_Origen As String,
        ByVal Codigo_Orden_Destino As String,
        ByVal cod_pre_sgs_origen As String,
        ByVal cod_pre_sgs_destino As String,
        ByVal cod_sucur_origen As String,
        ByVal cod_sucur_destino As String,
        ByVal Numero_Documento As String,
        ByVal Tipo_Documento As String,
        ByVal Id_Localizacion_Origen As Int32,
        ByVal Id_Localizacion_Destino As Int32,
        ByVal fec_con As Date,
        ByVal login As String,
        ByVal obs As String,
        ByVal LinkedServer As String) As DataTable

            Dim iConsecutivoCarmovim As Int32
            Dim dtDatos As DataTable
            Dim strProcedimiento As String = ""
            Me.setSQLSentence(LinkedServer + "[dbo].[PR_TR_INSERTA_LOG_HOMOLOGACION]", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("Codigo_Admision_Origen", SqlDbType.Decimal, Codigo_Admision_Origen)
            Me.addInputParameter("Ano_Admision_Origen", SqlDbType.Int, Ano_Admision_Origen)
            Me.addInputParameter("Tipo_Admision_Origen", SqlDbType.VarChar, Tipo_Admision_Origen)
            Me.addInputParameter("Codigo_Admision_Destino", SqlDbType.Decimal, Codigo_Admision_Destino)
            Me.addInputParameter("Ano_Admision_Destino", SqlDbType.Int, Ano_Admision_Destino)
            Me.addInputParameter("Tipo_Admision_Destino", SqlDbType.VarChar, Tipo_Admision_Destino)
            Me.addInputParameter("Codigo_Orden_Origen", SqlDbType.VarChar, Codigo_Orden_Origen)
            Me.addInputParameter("Codigo_Orden_Destino", SqlDbType.VarChar, Codigo_Orden_Destino)
            Me.addInputParameter("cod_pre_sgs_origen", SqlDbType.VarChar, cod_pre_sgs_origen)
            Me.addInputParameter("cod_pre_sgs_destino", SqlDbType.VarChar, cod_pre_sgs_destino)
            Me.addInputParameter("cod_sucur_origen", SqlDbType.VarChar, cod_sucur_origen)
            Me.addInputParameter("cod_sucur_destino", SqlDbType.VarChar, cod_sucur_destino)
            Me.addInputParameter("Numero_Documento", SqlDbType.VarChar, Numero_Documento)
            Me.addInputParameter("Tipo_Documento", SqlDbType.VarChar, Tipo_Documento)
            Me.addInputParameter("Id_Localizacion_Origen", SqlDbType.Int, Id_Localizacion_Origen)
            Me.addInputParameter("Id_Localizacion_Destino ", SqlDbType.Int, Id_Localizacion_Destino)
            Me.addInputParameter("fec_con", SqlDbType.DateTime, fec_con)
            Me.addInputParameter("login", SqlDbType.VarChar, login)
            Me.addInputParameter("obs", SqlDbType.VarChar, obs)
            Me.execDS()
            ' dtDatos = Me.execDT
            Return dtDatos

        End Function

        Public Function guardarOrdenesLaboHomologada(ByVal objConexion As Conexion, ByVal LinkedServer As String, ByVal cod_pre_sgs As String,
                                                   ByVal strCodSucur As String, ByVal tip_admision As String,
                                                   ByVal num_adm As String, ByVal ano_adm As String, ByVal strLogin As String,
                                                   ByVal medico As String, ByVal strCodEspecialidad As String, ByVal entidad As String,
                                                   ByVal xmlAislamientosModifica As String, ByVal xmlAislamientosNuevos As String,
                                                   ByVal xmlDietasModifica As String, ByVal xmlDietasNuevas As String,
                                                   ByVal xmlMedicaModificados As String, ByVal xmlMedicaNuevos As String,
                                                   ByVal xmlProceNuevos As String, ByVal xmlGeneralesModificados As String,
                                                   ByVal xmlGeneralesNuevos As String, ByRef NroOrden As Double,
                                                   ByRef fechaOrden As Date, ByRef centroCostoOrigen As String,
                                                   ByRef strGuia As String, ByRef strJustificacion As String,
                                                   ByRef strTipoServicio As String, ByRef strPrioridad As String) As DataTable

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007

            Dim respuestaOrden As New DataTable
            respuestaOrden.Columns.Add("NroOrden")
            respuestaOrden.Columns.Add("fechaOrden")
            respuestaOrden.Columns.Add("centroCostoOrigen")
            respuestaOrden.Columns.Add("lError")

            Dim lError As Long

            Me.setSQLSentence(LinkedServer + "[dbo].[HC_GrabarOrdenesMedicasLabo]", CommandType.StoredProcedure)

            Me.ParametersCollection.Clear()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCodSucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("num_adm", SqlDbType.Int, num_adm)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("strLogin", SqlDbType.VarChar, strLogin)
            Me.addInputParameter("medico", SqlDbType.VarChar, medico)
            Me.addInputParameter("especialidad", SqlDbType.VarChar, strCodEspecialidad)
            Me.addInputParameter("entidad", SqlDbType.VarChar, entidad)
            Me.addInputParameter("@txtXmlAislamientosModif", SqlDbType.VarChar, xmlAislamientosModifica)
            Me.addInputParameter("@txtXmlAislamientosNuevos", SqlDbType.VarChar, xmlAislamientosNuevos)
            Me.addInputParameter("txtXmlDietasModif", SqlDbType.VarChar, xmlDietasModifica)
            Me.addInputParameter("txtXmlDietasNuevas", SqlDbType.VarChar, xmlDietasNuevas)
            Me.addInputParameter("txtXmlMedicaModificados", SqlDbType.VarChar, xmlMedicaModificados)
            Me.addInputParameter("txtXmlMedicaNuevos", SqlDbType.VarChar, xmlMedicaNuevos)
            Me.addInputParameter("txtXmlProceNuevos", SqlDbType.VarChar, xmlProceNuevos)
            Me.addInputParameter("txtXmlGeneralesModificados", SqlDbType.VarChar, xmlGeneralesModificados)
            Me.addInputParameter("txtXmlGeneralesNuevos", SqlDbType.VarChar, xmlGeneralesNuevos)
            Me.addOutputParameter("NewNroOrden", SqlDbType.Int)
            Me.addOutputParameter("fechaOrden", SqlDbType.DateTime)
            Me.addOutputParameter("centroDeCostoOrigen", SqlDbType.VarChar, 8)
            'parametros creados por Ing. Ricardo Mauricio Zaldúa C. 2009-02-03 Res 3047 solicitado por Mauricio Forero
            Me.addInputParameter("strGuia", SqlDbType.VarChar, strGuia)
            Me.addInputParameter("strJustificacion", SqlDbType.VarChar, strJustificacion)
            Me.addInputParameter("strTipoServicio", SqlDbType.VarChar, strTipoServicio)
            Me.addInputParameter("strPrioridad", SqlDbType.VarChar, strPrioridad)
            '=============
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()
            lError = Me.Parameters("lError").Value

            If IsNumeric(Me.Parameters("NewNroOrden").Value) Then
                NroOrden = CType(Me.Parameters("NewNroOrden").Value, Double)
            Else
                NroOrden = 0
            End If

            If IsDate(Me.Parameters("@fechaOrden").Value) Then
                fechaOrden = CType(Me.Parameters("@fechaOrden").Value, Date)
            End If

            If IsDBNull(Me.Parameters("@centroDeCostoOrigen").Value) Then
                centroCostoOrigen = ""
            Else
                centroCostoOrigen = Me.Parameters("@centroDeCostoOrigen").Value
            End If



            ValidarPedidoGenerado(cod_pre_sgs, strCodSucur, tip_admision, ano_adm, num_adm, NroOrden)
            respuestaOrden.Rows.Add(NroOrden, fechaOrden, centroCostoOrigen, lError)
            Return respuestaOrden

        End Function

        ''Daniel Sanchez Octubre 4 de 2017
        Public Function consultarAislamiento(ByVal objConexion As Conexion, ByVal condicion As String) As DataTable

            Dim dtTable As DataTable

            If condicion <> String.Empty Then

                Me.setSQLSentence("select ID_TIPO_AISLAMIENTO as aislamiento, DESCRIPCION as descripcion from TIPO_AISLAMIENTO WHERE DESCRIPCION not in(" + condicion + ") order by ORDEN asc", CommandType.Text)

            Else

                Me.setSQLSentence("select ID_TIPO_AISLAMIENTO as aislamiento, DESCRIPCION as descripcion from TIPO_AISLAMIENTO order by ORDEN asc", CommandType.Text)

            End If

            dtTable = Me.execDT()

            Return dtTable

        End Function

        ''Daniel Sanchez Octubre 6 de 2017
        Public Function consultarIdAislamiento(ByVal objConexion As Conexion, ByVal nombreAislamiento As String) As Integer

            Dim id As Integer
            Me.setSQLSentence("select ID_TIPO_AISLAMIENTO as aislamiento FROM TIPO_AISLAMIENTO WHERE DESCRIPCION = '" + nombreAislamiento + "'", CommandType.Text)
            id = Me.executeScalar()

            Return id

        End Function

        'Dsanchez IG - 26/10/2017, Metodo que se usa para obtener las medidas asociadas a un aislamiento
        Public Function ConsultarMedidasAislamiento(ByVal nombreAislamiento As String) As DataTable

            Dim dtInfo As DataTable = New DataTable()

            Me.setSQLSentence("SELECT DBO.FN_HC_ObtenerMedidasAislamientos('" & nombreAislamiento & "') AS Medida", CommandType.Text)

            dtInfo = Me.execDT()

            Return dtInfo

        End Function

        Public Function ConsultarLoginHomologacion(ByVal LinkedServer As String) As String
            Dim dtregional As New DataTable
            Dim strParametroFijoPaliativos As String = "UsuarioInterfazParametro"
            Me.setSQLSentence(LinkedServer + "[dbo].[DB_Traergenparsophia]", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("nombre_par", SqlDbType.VarChar, strParametroFijoPaliativos)
            dtregional = Me.execDT
            If dtregional.Rows.Count > 0 Then
                Return dtregional.Rows(0).Item("Valor")
            Else
                Return ""
            End If
        End Function

        Public Function ConsultarHomologacionTipoDocumento(ByVal tipoDocumento As String) As String
            Dim dtTipos As New DataTable

            Me.setSQLSentence("[dbo].[PR_HC_CONSULTA_TIPO_DOCUMENTO_RL]", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("tipoDocumento", SqlDbType.VarChar, tipoDocumento)
            dtTipos = Me.execDT
            If dtTipos.Rows.Count > 0 Then
                Return dtTipos.Rows(0).Item("alias_CE")
            Else
                Return ""
            End If
        End Function
        ''' <summary>
        ''' eloaiza@intergrupo
        ''' 30-08-2019
        ''' Recuperar el valor de un parametro de la tabla de parametros dado el nombre del mismo
        ''' </summary>
        ''' <param name="paramName">Nombre del parametro a buscar</param>
        ''' <param name="LinkedServer">Opcional - Nombre o Direccion del servidor vinculado que se consultara</param>
        ''' <returns>String</returns>

        Public Function ConsultarParametrosGenerico(ByVal paramName As String, Optional ByVal LinkedServer As String = "") As String
            Dim dtParam As New DataTable

            Me.setSQLSentence(LinkedServer + "[dbo].DB_Traergenparsophia", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("nombre_par", SqlDbType.VarChar, paramName)
            dtParam = Me.execDT
            If dtParam.Rows.Count > 0 Then
                Return dtParam.Rows(0).Item("Valor")
            Else
                Return "El parametro buscado no se  ha encotrado"
            End If
        End Function
        ''' <summary>
        ''' Ejecutar Consulta en Bases de datos de sophia
        ''' </summary>
        ''' <param name="strTipoDocumento">Tipo del documento del paciente</param>
        ''' <param name="strNumDocumento">Numero del documento del paciente</param>
        ''' <param name="intEjecucion">Indicador de tipo de ejecucion 0=Búsqueda Total, 1=Consultar Datos especificos</param>
        ''' <param name="arrDatosAdmision">Arreglo que contiene los datos de la admision, aplica solo cuando intEjecucion = 1</param>
        ''' <returns></returns>
        Public Function ConsultaGeneral_PAC360(ByVal strTipoDocumento As String, strNumDocumento As String, ByVal Optional intEjecucion As Integer = 0, ByVal Optional arrDatosAdmision() As String = Nothing) As DataTable

            Dim tblResultado As New DataTable
            Me.setSQLSentence("[dbo].SP_PAC360CONSULTARBASES", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("TipoDocumento", SqlDbType.VarChar, strTipoDocumento)
            Me.addInputParameter("NumeroDocumento", SqlDbType.VarChar, strNumDocumento)
            Me.addInputParameter("Ejecucion", SqlDbType.Int, intEjecucion)
            If IsNothing(arrDatosAdmision) And intEjecucion = 1 Then
                MessageBox.Show("Debe especificar los datos de la admisión", "Paciente 360")
                Return tblResultado
            End If
            If Not IsNothing(arrDatosAdmision) And intEjecucion = 1 Then
                Me.addInputParameter("COD_PRE_SGS", SqlDbType.VarChar, arrDatosAdmision(3).ToString())
                Me.addInputParameter("COD_SUCUR", SqlDbType.VarChar, arrDatosAdmision(4).ToString())
                Me.addInputParameter("TIP_ADMISION", SqlDbType.VarChar, arrDatosAdmision(0).ToString())
                Me.addInputParameter("ANO_ADM", SqlDbType.Int, arrDatosAdmision(1).ToString())
                Me.addInputParameter("NUM_ADM", SqlDbType.Int, arrDatosAdmision(2).ToString())
            End If

            tblResultado = Me.execDT

            Return tblResultado

        End Function
        ''' <summary>
        ''' Auditoria Consulta Paciente360
        ''' </summary>
        ''' <param name="cod_historia"></param>
        ''' <param name="strPrestador"></param>
        ''' <param name="strSucur"></param>
        ''' <param name="TipAdmision"></param>
        ''' <param name="Ano_adm"></param>
        ''' <param name="Num_Adm"></param>
        ''' <param name="medico"></param>
        ''' <param name="estado"></param>
        ''' <param name="obs"></param>
        ''' <returns name="lError">Integer:Indicador de resultado de la ejecucion</returns>
        Public Function AuditoriaConsultasPAC360(ByVal cod_historia As Decimal, ByVal strPrestador As String, ByVal Optional strSucur As String = "",
                                                 ByVal Optional TipAdmision As String = "", ByVal Optional Ano_adm As Integer = 0, ByVal Optional Num_Adm As Decimal = 0,
                                                 ByVal Optional medico As String = "", ByVal Optional estado As String = "A", ByVal Optional obs As String = "") As Long
            Dim lError As Long
            Try
                Me.ClearParameters()
                Me.clearSQLSentence()
                Me.setSQLSentence("hc_ingresatablaAuditAperturaHC", CommandType.StoredProcedure)
                Me.addInputParameter("@cod_historia", SqlDbType.Decimal, 0)
                Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, strPrestador)
                Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, strSucur)
                Me.addInputParameter("@tip_admision", SqlDbType.VarChar, TipAdmision)
                Me.addInputParameter("@ano_adm", SqlDbType.Int, Ano_adm)
                Me.addInputParameter("@num_adm", SqlDbType.Decimal, Num_Adm)
                Me.addInputParameter("@medico", SqlDbType.VarChar, medico)
                Me.addInputParameter("@estado", SqlDbType.VarChar, estado)
                Me.addInputParameter("@obs", SqlDbType.VarChar, obs)
                Me.addInputParameter("@ID_programa", SqlDbType.Int, 90)
                Me.addInputParameter("@Error", SqlDbType.Int, lError)
                Me.Exec()
                lError = Me.Parameters("@Error").Value
            Catch ex As Exception
                MessageBox.Show("Se presento un incoveniente causa " + ex.Message, "Sophia")
                lError = -1
            End Try

            Return lError

        End Function

        Function ConsultarFrecuenciasHomologadas(ByVal codFrecuencia As String) As DataTable
            Dim tblResultado As New DataTable
            Me.clearSQLSentence()
            Me.ClearParameters()
            Me.setSQLSentence("SELECT CodFrecuenciaPal, Descripcion, cntDosis FROM HC_BuscarFrecuencia('" & codFrecuencia & "')", CommandType.Text)
            tblResultado = Me.execDT()
            Return tblResultado
        End Function
        Function Consultar_Parametros_PYXIS() As DataTable
            Dim tblResultado As New DataTable
            Me.setSQLSentence("SOS.CONSULTAR_PARAMETROS_PYXIS", CommandType.StoredProcedure)
            Me.ClearParameters()

            tblResultado = Me.execDT
            Return tblResultado
        End Function
        ''' <summary>
        ''' Ejecutar Consulta centro de costo para comunicación servicio pyxis
        ''' </summary>
        ''' <param name="cod_pre_sgs">Codigo del prestado</param>
        ''' <param name="cod_sucur">Codigo de la sucursal</param>
        ''' <param name="tip_admision">tipo_admision</param>
        ''' <param name="num_adm">N'umero de la admisión</param>
        ''' <param name="ano_adm">Año de la admisión</param>
        ''' <returns></returns>
        Public Function ConsultaCenCosto_Pyxis(ByVal cod_pre_sgs As String, ByVal cod_sucur As String, ByVal tip_admision As String, ByVal num_adm As Integer,
                                               ByVal ano_adm As Integer) As DataTable

            Dim tblResultado As New DataTable
            Me.setSQLSentence("[dbo].HC_OrdenesMedicas_PyxisCenCos", CommandType.StoredProcedure)
            Me.ClearParameters()

            Me.addInputParameter("COD_PRE_SGS", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("COD_SUCUR", SqlDbType.VarChar, cod_sucur)
            Me.addInputParameter("TIP_ADMISION", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("ANO_ADM", SqlDbType.Int, num_adm)
            Me.addInputParameter("NUM_ADM", SqlDbType.Int, ano_adm)

            tblResultado = Me.execDT

            Return tblResultado

        End Function

        Public Function ConsultaOrdenmed_Pyxis(ByVal cod_pre_sgs As String, ByVal cod_sucur As String, ByVal tip_admision As String, ByVal ano_adm As Integer,
                                               ByVal num_adm As Integer) As DataTable

            Dim tblResultado As New DataTable
            Me.setSQLSentence("[dbo].HCEnf_ConsultaexisteORpyxis", CommandType.StoredProcedure)
            Me.ClearParameters()

            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, cod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("num_adm", SqlDbType.Int, num_adm)

            tblResultado = Me.execDT

            Return tblResultado

        End Function

        Public Function ConsultaOrdenmedDia_Pyxis(ByVal cod_pre_sgs As String, ByVal cod_sucur As String, ByVal tip_admision As String, ByVal ano_adm As Integer,
                                               ByVal num_adm As Integer, ByVal nro_orden As Integer, ByVal xmlMedicaModificados As DataTable, ByVal xmlMedicaNuevos As DataTable) As DataTable

            Dim tblResultado As New DataTable
            Me.setSQLSentence("[dbo].HCEnf_ConsultaexisteORpyxisdia", CommandType.StoredProcedure)
            Me.ClearParameters()

            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, cod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("num_adm", SqlDbType.Int, num_adm)
            Me.addInputParameter("nro_orden", SqlDbType.Int, nro_orden)
            Me.addInputParameter("txtXmlMedicaModificados", SqlDbType.Structured, xmlMedicaModificados)
            Me.addInputParameter("txtXmlMedicaNuevos", SqlDbType.Structured, xmlMedicaNuevos)

            tblResultado = Me.execDT

            Return tblResultado

        End Function
        Public Function ConsultaAdmisionSer_Pyxis(ByVal cod_pre_sgs As String, ByVal cod_sucur As String, ByVal tip_admision As String, ByVal ano_adm As Integer,
                                               ByVal num_adm As Integer) As DataTable

            Dim tblResultado As New DataTable
            Me.setSQLSentence("[dbo].HCEnf_ConsultarAdmisionserPyxis", CommandType.StoredProcedure)
            Me.ClearParameters()

            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, cod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("num_adm", SqlDbType.Int, num_adm)

            tblResultado = Me.execDT

            Return tblResultado

        End Function
        Public Function ConsultaUbicacionSer_Pyxis(ByVal cod_pre_sgs As String, ByVal cod_sucur As String, ByVal tip_admision As String, ByVal ano_adm As Integer,
                                               ByVal num_adm As Integer) As DataTable

            Dim tblResultado As New DataTable
            Me.setSQLSentence("[dbo].HCEnf_ConsultarUbicacionserPyxis", CommandType.StoredProcedure)
            Me.ClearParameters()

            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, cod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("num_adm", SqlDbType.Int, num_adm)

            tblResultado = Me.execDT

            Return tblResultado

        End Function
        Public Function ConsultaPrescripcionSer_Pyxis(ByVal cod_pre_sgs As String, ByVal cod_sucur As String, ByVal tip_admision As String, ByVal ano_adm As Integer,
                                               ByVal num_adm As Integer, ByVal nro_orden As Integer, ByVal cencosto As String, ByVal xmlMedicaModificados As DataTable, ByVal xmlMedicaNuevos As DataTable) As DataTable

            Dim tblResultado As New DataTable
            Me.setSQLSentence("[dbo].HCEnf_ConsultarPrescripcionesserPyxisdia", CommandType.StoredProcedure)
            Me.ClearParameters()

            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, cod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("num_adm", SqlDbType.Int, num_adm)
            Me.addInputParameter("cen_costo", SqlDbType.VarChar, cencosto)
            Me.addInputParameter("nro_orden", SqlDbType.Int, nro_orden)
            Me.addInputParameter("txtXmlMedicaModificados", SqlDbType.Structured, xmlMedicaModificados)
            Me.addInputParameter("txtXmlMedicaNuevos", SqlDbType.Structured, xmlMedicaNuevos)

            tblResultado = Me.execDT

            Return tblResultado

        End Function

        Public Function ConsultaPrescripcionSer_Pyxisgestor(ByVal cod_pre_sgs As String, ByVal cod_sucur As String, ByVal tip_admision As String, ByVal ano_adm As Integer,
                                               ByVal num_adm As Integer, ByVal nro_orden As Integer, ByVal cencosto As String, ByVal xmlMedicaModificados As DataTable, ByVal xmlMedicaNuevos As DataTable) As DataTable

            Dim tblResultado As New DataTable
            Me.setSQLSentence("[dbo].HCEnf_ConsultarPrescripcionesserPyxisdiagestor", CommandType.StoredProcedure)
            Me.ClearParameters()

            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, cod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("num_adm", SqlDbType.Int, num_adm)
            Me.addInputParameter("cen_costo", SqlDbType.VarChar, cencosto)
            Me.addInputParameter("nro_orden", SqlDbType.Int, nro_orden)
            Me.addInputParameter("txtXmlMedicaModificados", SqlDbType.Structured, xmlMedicaModificados)
            Me.addInputParameter("txtXmlMedicaNuevos", SqlDbType.Structured, xmlMedicaNuevos)

            tblResultado = Me.execDT

            Return tblResultado

        End Function
        ''' <summary>
        ''' Ejecutar Consulta centro de costo para comunicación servicio pyxis
        ''' </summary>
        ''' <param name="cod_pre_sgs">Codigo del prestado</param>
        ''' <param name="cod_sucur">Codigo de la sucursal</param>
        ''' <param name="tip_admision">tipo_admision</param>
        ''' <param name="num_adm">N'umero de la admisión</param>
        ''' <param name="ano_adm">Año de la admisión</param>
        ''' <returns></returns>
        Public Function PyxisGuardarLog(ByVal cod_pre_sgs As String, ByVal cod_sucur As String, ByVal tip_admision As String, ByVal num_adm As Integer,
                                        ByVal ano_adm As Integer, ByVal marcaTiempoPeticion As String, ByVal marcaTiempoRespuesta As String, ByVal peticion As String,
                                        ByVal Respuestas As String, ByVal CodigoEstadoPyxis As String) As Long

            Dim lError As Long
            Try
                Me.ClearParameters()
                Me.clearSQLSentence()
                Me.setSQLSentence("HC_OrdenesMedicas_PyxisApiLog_Crear", CommandType.StoredProcedure)
                Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
                Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, cod_sucur)
                Me.addInputParameter("@tip_admision", SqlDbType.VarChar, tip_admision)
                Me.addInputParameter("@ano_adm", SqlDbType.Int, ano_adm)
                Me.addInputParameter("@num_adm", SqlDbType.Decimal, num_adm)
                Me.addInputParameter("@marcaTiempoPeticion", SqlDbType.DateTime, marcaTiempoPeticion)
                Me.addInputParameter("@marcaTiempoRespuesta", SqlDbType.DateTime, marcaTiempoRespuesta)
                Me.addInputParameter("@peticion", SqlDbType.VarChar, peticion)
                Me.addInputParameter("@Respuestas", SqlDbType.VarChar, Respuestas)
                Me.addInputParameter("@CodigoEstadoPyxis", SqlDbType.VarChar, CodigoEstadoPyxis)
                Me.addInputParameter("@lError", SqlDbType.Int, lError)
                Me.Exec()
                lError = Me.Parameters("@lError").Value
            Catch ex As Exception
                MessageBox.Show("Se presento un incoveniente causa " + ex.Message, "Sophia")
                lError = -1
            End Try

            Return lError


        End Function
        ''' <summary>
        ''' Ejecutar consulta para verificar el tratamiento de acuerdo a los parametros
        ''' </summary>
        ''' <param name="cod_pre_sgs">Codigo del prestado</param>
        ''' <param name="cod_sucur">Codigo de la sucursal</param>
        ''' <param name="tip_admision">tipo_admision</param>
        ''' <param name="num_adm">N'umero de la admisión</param>
        ''' <param name="ano_adm">Año de la admisión</param>
        ''' <param name="NroOrden">Número de orden</param>
        ''' <param name="Secuencia">secuencia de la orden</param>
        ''' <returns></returns>
        Public Function ConsultarEstadoDosisUnica(ByVal cod_pre_sgs As String, ByVal cod_sucur As String, ByVal tip_admision As String _
                                               , ByVal num_adm As Int64, ByVal ano_adm As Integer, ByVal NroOrden As Int64, ByVal Secuencia As Int16) As String
            Dim estado As String = String.Empty

            Try
                Dim tblResultado As New DataTable


                Me.setSQLSentence("[dbo].HC_OrdenesMedicas_Consulta_Estados_DosisUnica", CommandType.StoredProcedure)
                Me.ClearParameters()

                Me.addInputParameter("COD_PRE_SGS", SqlDbType.VarChar, cod_pre_sgs)
                Me.addInputParameter("COD_SUCUR", SqlDbType.VarChar, cod_sucur)
                Me.addInputParameter("TIP_ADMISION", SqlDbType.VarChar, tip_admision)
                Me.addInputParameter("ANO_ADM", SqlDbType.Int, ano_adm)
                Me.addInputParameter("NUM_ADM", SqlDbType.Int, num_adm)
                Me.addInputParameter("NroOrden", SqlDbType.Int, NroOrden)
                Me.addInputParameter("Secuencia", SqlDbType.Int, Secuencia)

                tblResultado = Me.execDT

                estado = tblResultado.Rows(0).Item("Tratamiento").ToString

            Catch ex As Exception
                MessageBox.Show("Se presento un incoveniente causa " + ex.Message, "Sophia")
            End Try

            Return estado

        End Function

        ''' <summary>
        ''' Consulta si otro usuario grabo una orden médica posterior a la hora de sesión del usuario
        ''' </summary>
        ''' <param name="cod_pre_sgs">Codigo del prestado</param>
        ''' <param name="cod_sucur">Codigo de la sucursal</param>
        ''' <param name="tip_admision">tipo_admision</param>
        ''' <param name="num_adm">N'umero de la admisión</param>
        ''' <param name="ano_adm">Año de la admisión</param>
        ''' <param name="strmodulo">Módulo donde se valida</param>
        ''' <param name="FechainicioSesion">Fecha de inicio de sesión del usuario en el módulo</param>
        ''' <returns>S/N</returns>
        Public Function Consultausuariosseccion(ByVal cod_pre_sgs As String, ByVal cod_sucur As String, ByVal tip_admision As String _
                                              , ByVal num_adm As Int64, ByVal ano_adm As Integer, ByVal strmodulo As String,
                                              ByVal FechainicioSesion As DateTime) As String
            Dim Respuesta As String = String.Empty
            Dim strflag As String

            Try


                Me.ClearParameters()
                Me.clearSQLSentence()
                Me.setSQLSentence("hcenf_Consultausuariosseccion", CommandType.StoredProcedure)
                Me.addInputParameter("@strcod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
                Me.addInputParameter("@strcod_sucur", SqlDbType.VarChar, cod_sucur)
                Me.addInputParameter("@strTip_Admision", SqlDbType.VarChar, tip_admision)
                Me.addInputParameter("@lAno_adm", SqlDbType.Int, ano_adm)
                Me.addInputParameter("@dNum_adm", SqlDbType.Int, num_adm)
                Me.addInputParameter("@strmodulo", SqlDbType.VarChar, strmodulo)
                Me.addInputParameter("@strFechainicio", SqlDbType.DateTime, FechainicioSesion)
                Me.addOutputParameter("@strflag", SqlDbType.VarChar, 1)
                Me.Exec()
                strflag = Me.Parameters("@strflag").Value


            Catch ex As Exception
                MessageBox.Show("Se presento un incoveniente causa " + ex.Message, "Sophia")
            End Try

            Return strflag

        End Function



        ''' <summary>
        ''' Graba en el log la información basica de la  orden médica  del usuario en sesión
        ''' </summary>
        ''' <param name="cod_pre_sgs">Codigo del prestado</param>
        ''' <param name="cod_sucur">Codigo de la sucursal</param>
        ''' <param name="tip_admision">tipo_admision</param>
        ''' <param name="num_adm">N'umero de la admisión</param>
        ''' <param name="ano_adm">Año de la admisión</param>
        ''' <param name="strmodulo">Módulo donde se valida</param>
        ''' <param name="FechainicioSesion">Fecha de inicio de sesión del usuario en el módulo</param>
        ''' <returns>S/N</returns>
        Public Function GrabarLogUsuario(ByVal cod_pre_sgs As String, ByVal cod_sucur As String, ByVal tip_admision As String _
                                              , ByVal num_adm As Int64, ByVal ano_adm As Integer, ByVal strmodulo As String,
                                              ByVal FechainicioSesion As DateTime, ByVal strlogin As String,
                                              ByVal strObservacion As String) As Int64
            Dim Respuesta As String = String.Empty
            Dim lError As Double

            Try


                Me.ClearParameters()
                Me.clearSQLSentence()
                Me.setSQLSentence("hcenf_logusuarioseccioneinsert", CommandType.StoredProcedure)
                Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
                Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, cod_sucur)
                Me.addInputParameter("@tip_admision", SqlDbType.VarChar, tip_admision)
                Me.addInputParameter("@ano_adm", SqlDbType.Int, ano_adm)
                Me.addInputParameter("@Num_adm", SqlDbType.Int, num_adm)
                Me.addInputParameter("@fechainicio", SqlDbType.DateTime, FechainicioSesion)
                Me.addInputParameter("@modulo", SqlDbType.VarChar, strmodulo)
                Me.addInputParameter("@login", SqlDbType.VarChar, strlogin)
                Me.addInputParameter("@obs", SqlDbType.VarChar, strObservacion)
                Me.addOutputParameter("@lError", SqlDbType.Int, lError)
                Me.Exec()
                lError = Me.Parameters("@lError").Value


            Catch ex As Exception
                MessageBox.Show("Se presento un incoveniente causa " + ex.Message, "Sophia")
            End Try

            Return lError

        End Function

    End Class



End Namespace

