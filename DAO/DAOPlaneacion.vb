Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Namespace Sophia.HistoriaClinica.DAO
    Public Class DAOPlaneacion
        Inherits GPMData
        ''Claudia Garay Enfermeria
        Public Function GuardarplaneacionMed(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long


            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCENF_GrabarPlaneacionMed", objConexion, Datos)

            Return lError

        End Function

        Public Function GuardarplaneacionMed1(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long

            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCENF_GrabarPlaneacionMed1", objConexion, Datos)

            Return lError

        End Function
        Public Function GuardarplaneacionMedDiaS(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long


            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCENF_GrabarPlaneacionMed", objConexion, Datos)

            Return lError

        End Function
        Public Function GuardarplaneacionMedCambioPlaneacion(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long


            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCENF_GrabarPlaneacionMedCambioPlaneacion", objConexion, Datos)

            Return lError

        End Function
        Public Function ConsultaObsPlaneacion(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataSet


            Dim objDAOGeneral As New DAOGeneral
            Dim dtObs As DataSet

            dtObs = objDAOGeneral.EjecutarSPConParametrosDataSet("HCENF_GrabarPlaneacionMed", objConexion, lError, Datos)

            Return dtObs

        End Function
        ''martovar riesgo caida
        Public Function consultarCuidadosEnfRiesgocaida(ByVal objConexion As Conexion) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("select codigo, descripcion from HcEnfgencuidado (nolock) where codigo in ('201','202','203','204','205','206','207') order by descripcion", CommandType.Text)
            dtTable = Me.execDT()
            Return dtTable

        End Function
        Public Function consultarUltimoRiesgocaida(ByVal objConexion As Conexion, ByVal cod_historia As Double) As DataTable

            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long
            Return obj.EjecutarSPConParametros("HCENF_TraerRiesgo", objConexion, lError, cod_historia, Nothing, Nothing, Nothing, Nothing, lError)

        End Function

        'rmzaldua consulta si la admision esta trasladada
        Public Function Traerfechahoraadmision(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String,
                                                       ByVal strCod_sucur As String, ByVal strTip_Admision As String,
                                                       ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double) As DataTable
            Dim dtdatos As DataTable

            Me.setSQLSentence("sp_consultafechahora_admisionorigen", CommandType.StoredProcedure)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, strTip_Admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, strAno_Adm)
            Me.addInputParameter("num_adm", SqlDbType.Int, strNum_Adm)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCod_sucur)
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strCod_pre_sgs)

            dtdatos = Me.execDT

            Return dtdatos

        End Function


        Public Function GuardarCuidados(ByVal objConexion As Conexion, ByVal xmlCuidado As String, ByVal xmlCuidadoMod As String) As Long


            Dim lError As Long


            Me.setSQLSentence("HCENF_GrabarCuidadosXPac", CommandType.StoredProcedure)

            Me.addInputParameter("@txtXmlCuidado", SqlDbType.VarChar, xmlCuidado)
            Me.addInputParameter("@txtXmlCuidadoModificados", SqlDbType.VarChar, xmlCuidadoMod)
            '=============
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()
            lError = Me.Parameters("lError").Value

            Return lError

        End Function
        ''Enfermeria
        Public Function consultarCuidadosEnfXPac(ByVal objConexion As Conexion, ByVal cod_historia As Double) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("select a.*,b.descripcion from HcEnfcuidadosXPac a (nolock) inner join HcEnfgencuidado b (nolock) on a.cod_cuidado=b.codigo where cod_historia=" & cod_historia & "and estado <> 'S'", CommandType.Text)
            dtTable = Me.execDT()

            Return dtTable

        End Function
        ''Enfermeria
        Public Function consultarCuidadosEnf(ByVal objConexion As Conexion) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("select codigo, descripcion from HcEnfgencuidado (nolock) order by descripcion", CommandType.Text)
            dtTable = Me.execDT()

            Return dtTable

        End Function
        ''Claudia Garay Enfermeria


        Public Function ActualizaEstadoPlaneacion(ByVal objConexion As Conexion, ByVal cod_historia As Double, ByVal cod_programa As String, ByVal id_programacion As Integer, ByVal tipo As String, ByVal login As String, ByVal obs As String, ByVal lError As Long) As Long


            Dim objGeneral As New DAOGeneral

            Return objGeneral.EjecutarSPConParametrosTran("HCENF_ActualizaEstadoPlaneacion", objConexion,
                                                      cod_historia, cod_programa, id_programacion, tipo, login, obs, lError)
        End Function

        Public Function AlmacenarAlarmas(ByVal objconexion As Conexion, ByVal tip_doc As String, ByVal num_doc As String, ByVal xmlAlarmas As String) As Long



            Dim lError As Long


            Me.setSQLSentence("HCENF_GrabarAlarmasXPac", CommandType.StoredProcedure)
            Me.addInputParameter("@strtip_doc", SqlDbType.VarChar, tip_doc)
            Me.addInputParameter("@strnum_doc", SqlDbType.VarChar, num_doc)
            Me.addInputParameter("@txtXmlAlarma", SqlDbType.VarChar, xmlAlarmas)
            '=============
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()
            lError = Me.Parameters("lError").Value

            Return lError
        End Function

        Public Function ConsultarAlarmasXPac(ByVal objconexion As Conexion, ByVal strPrestador As String, ByVal strSucur As String, ByVal TipAdmision As String,
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
        Public Function ConsultarTodasPlaneacion(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String,
                                               ByVal strCod_sucur As String, ByVal strTip_Admision As String,
                                               ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double) As DataSet
            Dim dsdatos As DataSet

            Me.setSQLSentence("HCEnf_ConsultarTodasPlaneaciones", CommandType.StoredProcedure)
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strCod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, strTip_Admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, strAno_Adm)
            Me.addInputParameter("num_adm", SqlDbType.Int, strNum_Adm)
            dsdatos = Me.execDS

            Return dsdatos

        End Function

        Public Function ConsultarHistoricoAlarmasXPac(ByVal objconexion As Conexion, ByVal cod_historia As String) As DataSet
            Dim dsdatos As DataSet

            Me.setSQLSentence("HCENF_ConsultaHistoricoAlarmasXPac", CommandType.StoredProcedure)
            Me.addInputParameter("cod_historia", SqlDbType.VarChar, cod_historia)
            dsdatos = Me.execDS()

            Return dsdatos

        End Function
        Public Function ConsultarAlergiasXPac(ByVal objconexion As Conexion, ByVal tip_doc As String, ByVal num_doc As String) As DataSet
            Dim dsdatos As DataSet
            Dim lError As Long

            Me.setSQLSentence("HCEnf_AntecedentesAlergicos", CommandType.StoredProcedure)
            Me.addInputParameter("strTipDoc", SqlDbType.VarChar, tip_doc)
            Me.addInputParameter("strNumDoc", SqlDbType.VarChar, num_doc)
            Me.addOutputParameter("lError", SqlDbType.Int)
            dsdatos = Me.execDS()

            Return dsdatos

        End Function
        Public Function ActualizaEstadoAlergia(ByVal objconexion As Conexion, ByVal strPrestador As String, ByVal strSucur As String, ByVal TipAdmision As String,
                                               ByVal Ano_adm As String, ByVal Num_Adm As String, ByVal tip_doc As String, ByVal num_doc As String,
                                               ByVal min_ingreso As Integer, ByVal hor_ingreso As Integer, ByVal clase As String, ByVal accion As Integer, ByVal nom_tabla As String) As Long

            Dim lError As Long

            Me.setSQLSentence("HCENF_ActualizaEstadoAlergia", CommandType.StoredProcedure)
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strPrestador)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strSucur)
            Me.addInputParameter("tip_doc", SqlDbType.VarChar, tip_doc)
            Me.addInputParameter("num_doc", SqlDbType.VarChar, num_doc)
            Me.addInputParameter("num_adm", SqlDbType.VarChar, Num_Adm)
            Me.addInputParameter("ano_adm", SqlDbType.VarChar, Ano_adm)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, TipAdmision)
            Me.addInputParameter("min_ingreso", SqlDbType.Int, min_ingreso)
            Me.addInputParameter("hor_ingreso", SqlDbType.Int, hor_ingreso)
            Me.addInputParameter("clase", SqlDbType.VarChar, clase)
            Me.addInputParameter("Nom_tabla", SqlDbType.VarChar, nom_tabla)
            Me.addInputParameter("accion", SqlDbType.VarChar, accion)
            Me.addOutputParameter("lError", SqlDbType.Int)

            Me.Exec()
            lError = Me.Parameters("lError").Value

            Return lError


        End Function
        ''Claudia Garay 05 Octubre de 2010
        'Public Function GuardarAlergiasNuevas(ByVal objConexion As Conexion, ByVal xmlAlergias As String) As Long


        '    Dim lError As Long


        '    Me.setSQLSentence("HCENF_GrabarAlergiasNuevas", CommandType.StoredProcedure)

        '    Me.addInputParameter("@txtXmlAlergia", SqlDbType.VarChar, xmlAlergias)
        '    '=============
        '    Me.addOutputParameter("lError", SqlDbType.Int)
        '    Me.Exec()
        '    lError = Me.Parameters("lError").Value

        '    Return lError

        'End Function
        Public Function GuardarAlergiasNuevas(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String, ByVal cod_sucur As String,
        ByVal tip_doc As String, ByVal Num_doc As String, ByVal tip_admision As String, ByVal ano_adm As Integer, ByVal num_adm As Integer,
        ByVal alergico As String, ByVal clase As String, ByVal login As String, ByVal obs As String, ByVal confidencial As String,
        ByVal tiempomes As Integer, ByVal tiempoano As Integer, ByVal estado_alarma As String) As Long


            Dim lError As Long


            Me.setSQLSentence("HCENF_GrabarAlergiasNuevas", CommandType.StoredProcedure)

            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, cod_sucur)
            Me.addInputParameter("tip_doc", SqlDbType.VarChar, tip_doc)
            Me.addInputParameter("Num_doc", SqlDbType.VarChar, Num_doc)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("num_adm", SqlDbType.Int, num_adm)
            Me.addInputParameter("alergico", SqlDbType.VarChar, alergico)
            Me.addInputParameter("clase", SqlDbType.VarChar, clase)
            Me.addInputParameter("login", SqlDbType.VarChar, login)
            Me.addInputParameter("obs", SqlDbType.VarChar, obs)
            Me.addInputParameter("confidencial", SqlDbType.VarChar, confidencial)
            Me.addInputParameter("tiempomes", SqlDbType.SmallInt, tiempomes)
            Me.addInputParameter("tiempoano", SqlDbType.SmallInt, tiempoano)
            Me.addInputParameter("estado_alarma", SqlDbType.VarChar, estado_alarma)
            '=============
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()
            lError = Me.Parameters("lError").Value

            Return lError

        End Function
        Public Function GuardarReprogramados(ByVal objConexion As Conexion, ByVal cod_historia As Double, ByVal consecutivo As Integer,
       ByVal cod_programa As String, ByVal hora As Integer, ByVal estado As String, ByVal NroOrden As Double, ByVal secuencia As Integer,
       ByVal obs As String, ByVal login As String) As Long


            Dim lError As Long


            Me.setSQLSentence("HCENF_ACTUALIZAREPROGRAMADOS", CommandType.StoredProcedure)

            Me.addInputParameter("cod_historia", SqlDbType.VarChar, cod_historia)
            Me.addInputParameter("consecutivo", SqlDbType.VarChar, consecutivo)
            Me.addInputParameter("cod_programa", SqlDbType.VarChar, cod_programa)
            Me.addInputParameter("hora", SqlDbType.VarChar, hora)
            Me.addInputParameter("estado", SqlDbType.VarChar, estado)
            Me.addInputParameter("NroOrden", SqlDbType.Int, NroOrden)
            Me.addInputParameter("secuencia", SqlDbType.Int, secuencia)
            Me.addInputParameter("obs", SqlDbType.VarChar, obs)
            Me.addInputParameter("login", SqlDbType.VarChar, login)
            '=============
            Me.addOutputParameter("lErr", SqlDbType.Int)
            Me.Exec()
            lError = Me.Parameters("lErr").Value

            Return lError

        End Function
        Public Function GuardarPlaneacionDiaS(ByVal objconexion As Conexion, ByVal cod_historia As Double, ByVal fechaAnterior As String) As Long
            Dim lError As Integer

            Me.setSQLSentence("hcenf_PlaneacionNuevoDia", CommandType.StoredProcedure)
            Me.addInputParameter("cod_historia", SqlDbType.VarChar, cod_historia)
            Me.addInputParameter("fecha_anterior", SqlDbType.VarChar, fechaAnterior)
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.execDS()

            lError = Me.Parameters("lError").Value
            Return lError
        End Function
        ''rmzaldua 2018-07-23
        Public Function consultarLogin(ByVal objConexion As Conexion, ByVal strlogin As String) As DataTable
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetSqlStringCommandWrapper("select tipDieta, descripcion from nuttipdieta")
            Dim dtTable As DataTable
            Me.setSQLSentence("select nombre + ' ' + apellido as nombre from genlogin with(nolock) where login1 = '" + strlogin + "'", CommandType.Text)
            dtTable = Me.execDT()

            Return dtTable

        End Function

        ''Monitoreos Claudia Garay 27 de octubre de 2010
        ''Se modifica consultar liquidos - dsanchez 10/08/2017
        Public Function consultarLiquidosAdministrados(ByVal objConexion As Conexion) As DataTable
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetSqlStringCommandWrapper("select tipDieta, descripcion from nuttipdieta")
            Dim dtTable As DataTable
            Me.setSQLSentence("select codigo, descripcion from genliqadmin with(nolock) where estado = 1 and visible = 1", CommandType.Text)
            dtTable = Me.execDT()

            Return dtTable

        End Function
        ''Monitoreos Claudia Garay 27 de octubre de 2010
        ''Se modifica consulta - dsanchez 10/08/2017
        Public Function consultarLiquidosEliminados(ByVal objConexion As Conexion) As DataTable
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetSqlStringCommandWrapper("select tipDieta, descripcion from nuttipdieta")
            Dim dtTable As DataTable
            'Me.setSQLSentence("select codigo, descripcion from genliqelim (nolock) where codigo not in (1,2,3,4,5) ", CommandType.Text)
            Me.setSQLSentence("select codigo, descripcion, lateralidad, categoria, Unico from genliqelim (nolock) where estado = 1 and visible = 1", CommandType.Text)
            dtTable = Me.execDT()

            Return dtTable

        End Function
        Public Function consultarLiquidos5Eliminados(ByVal objConexion As Conexion) As DataTable
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetSqlStringCommandWrapper("select tipDieta, descripcion from nuttipdieta")
            Dim dtTable As DataTable
            Me.setSQLSentence("select codigo, descripcion from genliqelim (nolock) where codigo in (1,2,3,4,5)", CommandType.Text)
            dtTable = Me.execDT()

            Return dtTable

        End Function
        Public Function TraerLiquidosGrilla(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String,
                                                       ByVal strCod_sucur As String, ByVal strTip_Admision As String,
                                                       ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double) As DataTable
            Dim dtdatos As DataTable

            Me.setSQLSentence("HCEnf_LiquidosCargarGrillaAdministradosNuevo", CommandType.StoredProcedure)
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strCod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, strTip_Admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, strAno_Adm)
            Me.addInputParameter("num_adm", SqlDbType.Int, strNum_Adm)
            dtdatos = Me.execDT

            Return dtdatos

        End Function

        Public Function TraerLiquidosGrilla1(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String,
                                                       ByVal strCod_sucur As String, ByVal strTip_Admision As String,
                                                       ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double) As DataTable
            Dim dtdatos As DataTable

            Me.setSQLSentence("HCEnf_LiquidosCargarGrillaAdministrados", CommandType.StoredProcedure)
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strCod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, strTip_Admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, strAno_Adm)
            Me.addInputParameter("num_adm", SqlDbType.Int, strNum_Adm)
            dtdatos = Me.execDT

            Return dtdatos

        End Function
        Public Function TraerLiquidosGrillaElim(ByVal objConexion As Conexion, ByVal cod_historia As String, ByVal strCod_pre_sgs As String, ByVal strCod_sucur As String, ByVal strTip_Admision As String, ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double) As DataTable
            Dim dtdatos As DataTable

            Me.setSQLSentence("HCEnf_LiquidosCargar_5EliminadosNuevo", CommandType.StoredProcedure)
            Me.addInputParameter("cod_historia", SqlDbType.VarChar, cod_historia)
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strCod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, strTip_Admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, strAno_Adm)
            Me.addInputParameter("num_adm", SqlDbType.Int, strNum_Adm)
            dtdatos = Me.execDT

            Return dtdatos

        End Function
        Public Function TraerLiquidosGrillaElim1(ByVal objConexion As Conexion, ByVal cod_historia As String, ByVal strCod_pre_sgs As String, ByVal strCod_sucur As String, ByVal strTip_Admision As String, ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double) As DataTable
            Dim dtdatos As DataTable

            Me.setSQLSentence("HCEnf_LiquidosCargar_5Eliminados", CommandType.StoredProcedure)
            Me.addInputParameter("cod_historia", SqlDbType.VarChar, cod_historia)
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strCod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strCod_sucur)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, strTip_Admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, strAno_Adm)
            Me.addInputParameter("num_adm", SqlDbType.Int, strNum_Adm)
            dtdatos = Me.execDT

            Return dtdatos

        End Function

        ''Se crea metodo para traer texto tooltip de columna - dsanchez 11/08/2017
        Public Function TraerColumnaAuxiliar(ByVal objConexion As Conexion, ByVal nombreLiquido As String, ByVal strCod_pre_sgs As String, ByVal strCod_sucur As String, ByVal strTip_Admision As String, ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double) As DataTable

            Dim dtDatos As DataTable

            Me.setSQLSentence("hcEnf_ObtenerAuxiliarColumnaLiqAdmin", CommandType.StoredProcedure)
            Me.addInputParameter("nombreLiquido", SqlDbType.VarChar, nombreLiquido)
            Me.addInputParameter("codPrestador", SqlDbType.VarChar, strCod_pre_sgs)
            Me.addInputParameter("codSucur", SqlDbType.VarChar, strCod_sucur)
            Me.addInputParameter("tipAdmision", SqlDbType.VarChar, strTip_Admision)
            Me.addInputParameter("anoAdmision", SqlDbType.Int, strAno_Adm)
            Me.addInputParameter("numAdmision", SqlDbType.Int, strNum_Adm)

            dtDatos = Me.execDT

            Return dtDatos

        End Function

        ''Monitoreos Claudia Garay Octubre 28 de 2010

        Public Function GuardarLiquidos(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long


            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCENF_GrabarMonitoreoLiquidosNuevo", objConexion, Datos)

            Return lError

        End Function
        ''Monitoreos Claudia Garay Octubre 28 de 2010

        Public Function GuardarLiquidos1(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long


            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCENF_GrabarMonitoreoLiquidos", objConexion, Datos)

            Return lError

        End Function
        Public Function GuardarhcenfControlLiquido(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long


            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCENF_GrabahcenfControlLiquidoNuevo", objConexion, Datos)

            Return lError

        End Function
        Public Function GuardarhcenfControlLiquido1(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long


            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCENF_GrabahcenfControlLiquido", objConexion, Datos)

            Return lError

        End Function
        Public Function ConsultaObsLiquidos(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataSet


            Dim objDAOGeneral As New DAOGeneral
            Dim dtObs As DataSet

            dtObs = objDAOGeneral.EjecutarSPConParametrosDataSet("HCENF_GrabarMonitoreoLiquidosNuevo", objConexion, lError, Datos)

            Return dtObs

        End Function

        ''MONITOREOS NOVIEMBRE 3 CLAUDIA GARAY

        Public Function ActualizaBalances(ByVal objConexion As Conexion, ByVal cod_historia As Double, ByVal fecha As String, ByVal bal12 As Decimal, ByVal bal18 As Decimal, ByVal bal6 As Decimal, ByVal balacum As Decimal, ByVal baltotal As Decimal, ByVal GU As Decimal) As Long
            Dim lError As Long


            Me.ClearParameters()
            Me.setSQLSentence("HCENF_ActualizaBalance", CommandType.StoredProcedure)

            Me.addInputParameter("cod_historia", SqlDbType.VarChar, cod_historia)
            Me.addInputParameter("fecha", SqlDbType.VarChar, fecha)
            Me.addInputParameter("Bal12", SqlDbType.Decimal, bal12)
            Me.addInputParameter("Bal18", SqlDbType.Decimal, bal18)
            Me.addInputParameter("Bal6", SqlDbType.Decimal, bal6)
            Me.addInputParameter("BalAcum", SqlDbType.Decimal, balacum)
            Me.addInputParameter("BalTotal", SqlDbType.Decimal, baltotal)
            Me.addInputParameter("GU", SqlDbType.Decimal, GU)
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()

            lError = Me.Parameters("lError").Value

            Return lError
        End Function
        Public Function TraeBalance(ByVal objConexion As Conexion, ByVal dCod_Historia As Integer, ByVal strFechaIni As Nullable(Of DateTime), ByVal strFechaFin As Nullable(Of DateTime), ByVal iHoraIni As Nullable(Of Integer), ByVal iHoraFin As Nullable(Of Integer)) As DataTable
            Dim lError As Long
            Dim dt As DataTable


            Me.ClearParameters()
            Me.setSQLSentence("HCENFREP_TraerBalances", CommandType.StoredProcedure)
            Me.addInputParameter("intCodhistoria ", SqlDbType.Int, dCod_Historia)
            Me.addInputParameter("strFechaIni", SqlDbType.DateTime, strFechaIni)
            Me.addInputParameter("strFechaFin", SqlDbType.DateTime, strFechaFin)
            Me.addInputParameter("iHoraIni", SqlDbType.Int, iHoraIni)
            Me.addInputParameter("iHoraFin ", SqlDbType.Int, iHoraFin)
            Me.addOutputParameter("lError", SqlDbType.Int)
            dt = Me.execDT


            Return dt
        End Function

        Public Function TraeBalanceAcumulado(ByVal objConexion As Conexion, ByVal cod_historia As Double, ByVal fechaIni As String, ByVal fechaFin As String) As DataSet
            Dim dsbal As DataSet

            Me.ClearParameters()
            Me.setSQLSentence("HCENF_ConsultaBalanceTotal_Acumulado", CommandType.StoredProcedure)

            Me.addInputParameter("cod_historia", SqlDbType.VarChar, cod_historia)
            Me.addInputParameter("fechaIni", SqlDbType.VarChar, fechaIni)
            Me.addInputParameter("fechaFin", SqlDbType.VarChar, fechaFin)
            dsbal = Me.execDS()


            Return dsbal
        End Function
        ''Claudia Garay
        ''Consulta de las planeaciones y las administraciones en un rango de fecha
        ''Enfermeria - 2da fase
        ''Noviembre 2011
        Public Function TraerConsultaPantallaPlaneacion(ByVal objConexion As Conexion, ByVal cod_historia As Double, ByVal fechaIni As String, ByVal fechaFin As String) As DataSet
            Dim dsdatos As DataSet

            Me.setSQLSentence("HCEN_PantallaDePlaneacionYAdministracion", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("intCodhistoria", SqlDbType.VarChar, cod_historia)
            Me.addInputParameter("strFechaIni", SqlDbType.VarChar, fechaIni)
            Me.addInputParameter("strFechaFin", SqlDbType.VarChar, fechaFin)
            Me.addOutputParameter("lError", SqlDbType.Int)

            dsdatos = Me.execDS()

            Return dsdatos

        End Function
        Public Function TraerConsecutivosPlaneacion(ByVal cod_historia As String, ByVal tipo As String, ByVal cod_programa As String, ByVal NroOrden As String, ByVal secuencia As String, ByVal estado As String) As Integer
            Dim dtdatos As DataTable
            Dim intConsecutivo As Integer = 0

            Me.setSQLSentence("hcenf_TraerConsecutivos_hcenfplaneacion", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_historia", SqlDbType.Int, cod_historia)
            Me.addInputParameter("tipo", SqlDbType.VarChar, tipo)
            Me.addInputParameter("cod_programa", SqlDbType.VarChar, cod_programa)
            Me.addInputParameter("NroOrden", SqlDbType.Int, NroOrden)
            Me.addInputParameter("secuencia", SqlDbType.Int, secuencia)
            Me.addInputParameter("estado", SqlDbType.VarChar, estado)

            dtdatos = Me.execDT

            If dtdatos.Rows.Count > 0 Then
                intConsecutivo = IIf(IsDBNull(dtdatos.Rows(0).Item("consecutivo")), 0, dtdatos.Rows(0).Item("consecutivo"))
            End If

            Return intConsecutivo

        End Function
        Public Function TraerConsecutivosPlaneacionDet(ByVal cod_historia As String) As Integer
            Dim dtdatos As DataTable
            Dim intConsecutivo As Integer = 0

            Me.setSQLSentence("hcenf_TraerConsecutivos_hcenfplaneaciondet", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_historia", SqlDbType.Int, cod_historia)

            dtdatos = Me.execDT

            If dtdatos.Rows.Count > 0 Then
                intConsecutivo = IIf(IsDBNull(dtdatos.Rows(0).Item("consecutivo")), 0, dtdatos.Rows(0).Item("consecutivo"))
            End If

            Return intConsecutivo

        End Function
        Public Sub CambiarEstadoOrdenUnicaDosis(ByVal cod_pre_sgs As String, ByVal cod_sucur As String, ByVal tip_admision As String, ByVal num_adm As Decimal,
        ByVal ano_adm As Integer, ByVal NroOrden As Decimal, ByVal producto As String, ByVal Secuencia As Integer)



            Dim lError As Long


            Me.setSQLSentence("HCENF_SuspendeOrdenDosisUnica", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, cod_sucur)
            Me.addInputParameter("@tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("@num_adm", SqlDbType.Decimal, num_adm)
            Me.addInputParameter("@ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("@NroOrden", SqlDbType.Decimal, NroOrden)
            Me.addInputParameter("@producto", SqlDbType.VarChar, producto)
            Me.addInputParameter("@Secuencia", SqlDbType.Int, Secuencia)
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()
            lError = Me.Parameters("lError").Value


        End Sub

        ''Se crea metodo para obtener detalle de cantidad en liquido - dsanchez 15/08/2017
        Public Function ObtenerDetalleCantidadLiquido(ByVal cod_historia As Integer, ByVal nombreLiquido As String, ByVal cantidad As Integer, ByVal tipoLiquido As String, ByVal hora As Integer, ByVal fechaConsulta As String, ByVal strlogin As String) As DataTable

            Dim dt As DataTable

            Me.ClearParameters()
            Me.setSQLSentence("HCENF_ObtenerDetalleCantLiquido", CommandType.StoredProcedure)
            Me.addInputParameter("@codHistoria", SqlDbType.Int, cod_historia)
            Me.addInputParameter("@nombreLiquido", SqlDbType.VarChar, nombreLiquido)
            Me.addInputParameter("@cantidad", SqlDbType.Int, cantidad)
            Me.addInputParameter("@tipoLiquido", SqlDbType.VarChar, tipoLiquido)
            Me.addInputParameter("@hora", SqlDbType.Int, hora)
            Me.addInputParameter("@fecha", SqlDbType.VarChar, fechaConsulta)
            Me.addInputParameter("@login", SqlDbType.VarChar, strlogin)
            dt = Me.execDT

            Return dt

        End Function

        ''Se crea metodo para validar si el liquido esta o no suspendido - dsanchez 
        Public Function ValidaSuspensionLiquido(ByVal codHistoria As Integer, ByVal nombreLiquido As String) As DataTable

            Dim dt As DataTable

            Me.ClearParameters()
            Me.setSQLSentence("HCEnf_ValidaLiquidoSuspendido", CommandType.StoredProcedure)
            Me.addInputParameter("@codHistoria", SqlDbType.Int, codHistoria)
            Me.addInputParameter("@nombreLiquido", SqlDbType.VarChar, nombreLiquido)

            dt = Me.execDT

            Return dt

        End Function

        Public Function ValidaHoraSuspensionLiquido(ByVal codHistoria As Integer, ByVal nombreLiquido As String) As DataTable

            Dim dt As DataTable

            Me.ClearParameters()
            Me.setSQLSentence("HCEnf_ValidaHoraLiquidoSuspendido", CommandType.StoredProcedure)
            Me.addInputParameter("codHistoria", SqlDbType.Int, codHistoria)
            Me.addInputParameter("nombreLiquido", SqlDbType.VarChar, nombreLiquido)

            dt = Me.execDT

            Return dt

        End Function

        ''Se crea metodo para obtener las caracteristicas de liquidos eliminados - dsanchez 24/08/2017
        Public Function ObtenerCaractLiquidoElim(ByVal nombreLiquido As String) As DataTable

            Dim dt As DataTable

            Me.ClearParameters()
            Me.setSQLSentence("HCENF_ObtenerCaracteristiciasLiquidoElim", CommandType.StoredProcedure)
            Me.addInputParameter("@nombreLiquido", SqlDbType.VarChar, nombreLiquido)

            dt = Me.execDT

            Return dt

        End Function

        ''Se crea metodo para guardar cantidades en liquidos eliminados - dsanchez 24/08/2017
        Public Function GuardarLiquidosElim(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long


            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCENF_GrabarMonitoreoLiquidosElim", objConexion, Datos)

            Return lError

        End Function

        ''Se crea metodo para borrar liquidos administrados o eliminados - dsanchez 24/08/2017
        Public Function BorrarLiquido(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long

            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCENF_borrarLiquido", objConexion, Datos)

            Return lError

        End Function

        ''Se crea metodo para validar si el liquido eliminado es diuresis - dsanchez 30/08/2017
        Public Function ValidaLiquidoDiuresis(ByVal nombreLiquido As String) As Integer

            Dim iResultado As Integer

            Me.setSQLSentence("SELECT DBO.FN_HCENF_ValidaLiquidoDiuresis('" + nombreLiquido + "') AS Valor", CommandType.Text)
            iResultado = Me.executeScalar()

            Return iResultado

        End Function

        ''Se crea metodo para obtener el peso del paciente - dsanchez 30/08/2017
        Public Function ObtenerPesoPaciente(ByVal prestador As String, ByVal sucursal As String, ByVal numAdmision As Double, ByVal anoAdmision As Integer, ByVal tipAdmision As String, ByVal codHistoria As Integer) As DataTable

            Dim dtInfo As DataTable = New DataTable

            Me.setSQLSentence("SELECT DBO.FN_HCENF_ObtenerPesoPacienteLiquidos('" & prestador & "', '" & sucursal & "', '" & tipAdmision & "', " & numAdmision.ToString() & ", " & anoAdmision.ToString() & ", " & codHistoria.ToString() & ") AS peso", CommandType.Text)

            dtInfo = Me.execDT()

            Return dtInfo

        End Function

        ''Se crea metodo para obtener el peso del paciente - dsanchez 30/08/2017
        Public Function ObtenerPesoPacienteconsulta(ByVal prestador As String, ByVal sucursal As String, ByVal numAdmision As Double, ByVal anoAdmision As Integer, ByVal tipAdmision As String, ByVal codHistoria As Integer, ByVal fechaConsulta As String, ByVal corte As String) As DataTable

            Dim dtInfo As DataTable = New DataTable

            Me.setSQLSentence("SELECT DBO.FN_HCENF_ObtenerPesoPacienteLiquidosConsulta('" & prestador & "', '" & sucursal & "', '" & tipAdmision & "', " & numAdmision.ToString() & ", " & anoAdmision.ToString() & ", " & codHistoria.ToString() & ", " & fechaConsulta.ToString() & ", " & corte.ToString() & ") AS peso", CommandType.Text)

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


        Public Function ObtenerEdadPacienteLiquidos(ByVal prestador As String, ByVal sucursal As String, ByVal numAdmision As Double, ByVal anoAdmision As Integer, ByVal tipAdmision As String, ByVal codHistoria As Integer) As DataTable


            Dim dtInfo As DataTable = New DataTable()

            Me.setSQLSentence("FN_HCENFObtenerEdadPacienteLiquidos", CommandType.StoredProcedure)
            Me.addInputParameter("@prestador", SqlDbType.VarChar, prestador)
            Me.addInputParameter("@codsucur", SqlDbType.VarChar, sucursal)
            Me.addInputParameter("@tipadmision", SqlDbType.VarChar, tipAdmision)
            Me.addInputParameter("@anoadmision", SqlDbType.Int, anoAdmision)
            Me.addInputParameter("@numadmision", SqlDbType.Int, numAdmision)
            Me.addInputParameter("@codhistoria", SqlDbType.Int, codHistoria)

            dtInfo = Me.execDT()

            Return dtInfo

        End Function


        Public Function ObtenerEdadPacienteLiquidosConsulta(ByVal prestador As String, ByVal sucursal As String, ByVal numAdmision As Double, ByVal anoAdmision As Integer, ByVal tipAdmision As String, ByVal codHistoria As Integer, ByVal fechaConsulta As String) As DataTable


            Dim dtInfo As DataTable = New DataTable()

            Me.setSQLSentence("FN_HCENFObtenerEdadPacienteLiquidosConuslta", CommandType.StoredProcedure)
            Me.addInputParameter("@prestador", SqlDbType.VarChar, prestador)
            Me.addInputParameter("@codsucur", SqlDbType.VarChar, sucursal)
            Me.addInputParameter("@tipadmision", SqlDbType.VarChar, tipAdmision)
            Me.addInputParameter("@anoadmision", SqlDbType.Int, anoAdmision)
            Me.addInputParameter("@numadmision", SqlDbType.Int, numAdmision)
            Me.addInputParameter("@codhistoria", SqlDbType.Int, codHistoria)
            Me.addInputParameter("@fechaConsulta", SqlDbType.VarChar, fechaConsulta)
            dtInfo = Me.execDT()

            Return dtInfo

        End Function

        ''Se crea metodo para obtener la diferencia en horas - dsanchez 05/09/2017
        Public Function ObtenerDiferenciaHora(ByVal prestador As String, ByVal sucursal As String, ByVal numAdmision As Double,
                                              ByVal anoAdmision As Integer, ByVal tipAdmision As String, ByVal nombreProducto As String,
                                              ByVal nroOrden As String) As Integer

            Dim iResultado As Integer = 0

            Me.ClearParameters()
            Me.setSQLSentence("HCENF_ObtenerDiferenciaHoras", CommandType.StoredProcedure)
            Me.addInputParameter("@nombreProducto", SqlDbType.VarChar, nombreProducto)
            Me.addInputParameter("@nroOrden", SqlDbType.VarChar, nroOrden)
            Me.addInputParameter("@prestador", SqlDbType.VarChar, prestador)
            Me.addInputParameter("@codSucur", SqlDbType.VarChar, sucursal)
            Me.addInputParameter("@numAdmision", SqlDbType.Int, numAdmision)
            Me.addInputParameter("@anoAdmision", SqlDbType.Int, anoAdmision)
            Me.addInputParameter("@tipAdmision", SqlDbType.VarChar, tipAdmision)

            iResultado = Me.executeScalar()

            Return iResultado

        End Function

        ''Se crea metodo para obtener fecha y hora de la admision - dsanchez 05/09/2017
        Public Function ObtenerFechaHoraAdmision(ByVal prestador As String, ByVal sucursal As String, ByVal numAdmision As Integer,
                                                 ByVal anoAdmision As String, ByVal tipoAdmision As String) As DataTable

            Dim dtInfo As DataTable = New DataTable()

            Me.setSQLSentence("select CONVERT(DATE, fec_ingreso) AS fec_ingreso, hor_ingreso FROM admmovim WITH(NOLOCK) WHERE num_adm = " + numAdmision.ToString() +
                              " AND ano_adm = " + anoAdmision + " AND tip_admision = '" + tipoAdmision + "' AND cod_pre_sgs = '" + prestador +
                              "' AND cod_sucur = '" + sucursal + "'", CommandType.Text)
            dtInfo = Me.execDT

            Return dtInfo

        End Function

        ''Se crea metodo para consultar liquido administrado - dsanchez 05/09/2017
        Public Function ConsultaLiquidoAdministrado(ByVal codHistoria As Integer, ByVal fecha As String) As DataTable

            Dim dtInfo As DataTable = New DataTable()

            Me.setSQLSentence("HCENF_ConsultaLiquidosAdministrados", CommandType.StoredProcedure)
            Me.addInputParameter("@codHistoria", SqlDbType.Int, codHistoria)
            Me.addInputParameter("@fechaLiquido", SqlDbType.VarChar, fecha)

            dtInfo = Me.execDT()

            Return dtInfo

        End Function

        ''Se crea metodo para consultar header de la columna - dsanchez 05/09/2017
        Public Function ConsultaHeaderColumna(ByVal fecha As String, ByVal codHistoria As Integer, ByVal nombreLiquido As String, ByVal nroOrden As Integer) As DataTable

            Dim dtInfo As DataTable = New DataTable()

            Me.setSQLSentence("HCENF_ObtenerHeaderTextColumnaAdmin", CommandType.StoredProcedure)
            Me.addInputParameter("@fechaLiquido", SqlDbType.VarChar, fecha)
            Me.addInputParameter("@codhistoria", SqlDbType.Int, codHistoria)
            Me.addInputParameter("@nombreLiquido", SqlDbType.VarChar, nombreLiquido)
            Me.addInputParameter("@nroOrden", SqlDbType.Int, nroOrden)

            dtInfo = Me.execDT()

            Return dtInfo

        End Function

        ''Se crea metodo para consultar liquido eliminado - dsanchez 05/09/2017
        Public Function ConsultaLiquidoEliminado(ByVal codHistoria As Integer, ByVal fecha As String) As DataTable

            Dim dtInfo As DataTable = New DataTable()

            Me.setSQLSentence("HCENF_ConsultaLiquidosEliminados", CommandType.StoredProcedure)
            Me.addInputParameter("@codHistoria", SqlDbType.Int, codHistoria)
            Me.addInputParameter("@fechaLiquido", SqlDbType.VarChar, fecha)

            dtInfo = Me.execDT()

            Return dtInfo

        End Function

        ''Se crea metodo para obtener diferencia de dias entre dos fechas - dsanchez 11/09/2017
        Public Function ObtenerDiferenciaDias(ByVal fechaInicial As String, ByVal fechaFinal As String) As Integer

            Dim resultado As Integer = 0

            Me.setSQLSentence("SELECT DATEDIFF(DAY, '" + fechaInicial + "', '" + fechaFinal + "') AS DIF", CommandType.Text)

            resultado = Me.executeScalar()

            Return resultado

        End Function

        ''Se crea metodo para sumar un dia a una fecha - dsanchez 15/09/2017
        Public Function SumarDiaFecha(ByVal fecha As String) As DataTable

            Dim dt As DataTable = New DataTable()
            Dim strSql As String = String.Empty

            strSql = "select convert(varchar(10), year(dateadd(day, 1, '" + fecha +
            "'))) + case when len(convert(varchar(10), month(dateadd(day, 1, '" + fecha +
            "')))) = 1 then '0'+convert(varchar(10), month(dateadd(day, 1, '" + fecha +
            "'))) else convert(varchar(10), month(dateadd(day, 1, '" + fecha +
            "'))) end+ case when len(convert(varchar(10), day(dateadd(day, 1, '" + fecha +
            "')))) = 1 then '0'+convert(varchar(10), day(dateadd(day, 1, '" + fecha +
            "'))) else convert(varchar(10), day(dateadd(day, 1, '" + fecha + "'))) end AS FECHA"

            Me.setSQLSentence(strSql, CommandType.Text)

            dt = Me.execDT()

            Return dt

        End Function

        'Dsanchez IG - 23-10-2017, Metodo para insertar el balance calculado por corte
        Public Function InsertarBalance(ByVal CodHistoria As Integer, ByVal balance As Double, ByVal peso As Double, ByVal edad As Double, ByVal mes As Double, ByVal dia As Double, ByVal unidad_medida As String, ByVal finalizado As Integer, ByVal corte As Integer) As Integer

            Dim resultado As Integer = 0

            Me.setSQLSentence("HCEnf_InsertarBalance", CommandType.StoredProcedure)
            Me.addInputParameter("@cod_historia", SqlDbType.Int, CodHistoria)
            Me.addInputParameter("@balance", SqlDbType.Decimal, balance)
            Me.addInputParameter("@peso", SqlDbType.Decimal, peso)
            Me.addInputParameter("@edad", SqlDbType.Int, edad)
            Me.addInputParameter("@edadmeses", SqlDbType.Int, mes)
            Me.addInputParameter("@edaddias", SqlDbType.Int, dia)
            Me.addInputParameter("@unidad_medida", SqlDbType.VarChar, unidad_medida)
            Me.addInputParameter("@corte_finalizado", SqlDbType.Bit, finalizado)
            Me.addInputParameter("@corte", SqlDbType.Int, corte)

            resultado = Me.executeScalar()

            Return resultado

        End Function

        'Dsanchez IG - 23-10-2017, Metodo para consultar balance por corte
        Public Function ConsultarBalanceXCorte(ByVal codHistoria As Integer, ByVal fechaLiquido As String, ByVal corte As Integer) As DataTable

            Dim dtInfo As DataTable = New DataTable()

            Me.setSQLSentence("HCEnf_ConsultaCorteBalance", CommandType.StoredProcedure)
            Me.addInputParameter("@cod_historia", SqlDbType.Int, codHistoria)
            Me.addInputParameter("@corte", SqlDbType.Decimal, corte)
            Me.addInputParameter("@fecha_liquido", SqlDbType.VarChar, fechaLiquido)

            dtInfo = Me.execDT()

            Return dtInfo

        End Function

        'Dsanchez IG - 23-10-2017, Metodo para obtener la fecha de horario medico
        Public Function ObtenerFechaMedico() As DataTable

            Dim dtInfo As DataTable = New DataTable()

            Me.setSQLSentence("SELECT DBO.FN_HCENF_ObtenerFechaMedico() AS fecha", CommandType.Text)

            dtInfo = Me.execDT()

            Return dtInfo

        End Function

        'Dsanchez IG - 23-10-2017, Metodo para validar si existe balance registrado
        Public Function ValidaExisteBalanceCorte(ByVal codHistoria As Integer, ByVal fechaLiquido As String, ByVal corte As Integer) As Integer

            Dim resultado As Integer = 0

            'Me.setSQLSentence("select 1 as campo from HCEnf_BalanceLiquidos where cod_historia = " & codHistoria.ToString() & " and fecha_liquido = '" & fechaLiquido & "' and corte = " & corte.ToString() & "", CommandType.Text)
            Me.setSQLSentence("select 1 as campo from HCEnf_BalanceLiquidos where cod_historia = " & codHistoria.ToString() & " and fecha_liquido = '" & fechaLiquido & "' and corte = " & corte.ToString() & " and finalizado = 1", CommandType.Text)

            resultado = Me.executeScalar()

            Return resultado

        End Function

        'Dsanchez IG - 24/10/2017, Metodo que obtiene el valor que indica si el corte ya finalizo
        Public Function ValidaIntervaloCerrado(ByVal codHistoria As Integer, ByVal fechaLiquido As String, ByVal corte As Integer) As DataTable

            Dim dtInfo As DataTable = New DataTable

            Me.setSQLSentence("SELECT finalizado FROM HCEnf_BalanceLiquidos WHERE cod_historia = " & codHistoria.ToString() & " AND fecha_liquido = '" & fechaLiquido.ToString() & "' AND corte = " & corte.ToString() & "", CommandType.Text)

            dtInfo = Me.execDT()

            Return dtInfo

        End Function

        'Dsanchez IG - 24/10/2017, Metodo que obtiene el valor que indica si el corte ya finalizo
        Public Function ObtenerPesoIntervalo(ByVal codHistoria As Integer, ByVal fechaLiquido As String, ByVal corte As Integer) As DataTable

            Dim dtInfo As DataTable = New DataTable

            Me.setSQLSentence("SELECT peso FROM HCEnf_BalanceLiquidos WHERE cod_historia = " & codHistoria.ToString() & " AND fecha_liquido = '" & fechaLiquido.ToString() & "' AND corte = " & corte.ToString() & "", CommandType.Text)
            dtInfo = Me.execDT()

            Return dtInfo

        End Function


        'rmzaldua IG - 13/06/2018, Metodo que obtiene la edad guardada
        Public Function ObteneredadIntervalo(ByVal codHistoria As Integer, ByVal fechaLiquido As String, ByVal corte As Integer) As DataTable

            Dim dtInfo As DataTable = New DataTable

            Me.setSQLSentence("SELECT edad, edadmeses, edaddias FROM HCEnf_BalanceLiquidos WHERE cod_historia = " & codHistoria.ToString() & " AND fecha_liquido = '" & fechaLiquido.ToString() & "' AND corte = " & corte.ToString() & "", CommandType.Text)
            dtInfo = Me.execDT()

            Return dtInfo

        End Function
    End Class

End Namespace
