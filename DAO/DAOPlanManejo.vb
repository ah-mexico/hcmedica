Imports System

Imports objComun = HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports objDatosGenerales = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion

Namespace Sophia.HistoriaClinica.DAO

    ''' -----------------------------------------------------------------------------
    ''' Project	 : HistoriClinica.DAO
    ''' Class	 : Sophia.HistoriaClinica.Egresos.DAO.DAOPlanManejo
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Clase DAOPlanManejo del namespace Sophia.HistoriaClinica.DAO.DAOPlanManejo que es la clase 
    ''' data de HistoriaClinica.DAO
    ''' y será usada desde este namespace para el acceso a los datos para los Planes de Manejo
    ''' se agrega de la application block Data.SqlHelper
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[mvargas]	5/05/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class DAOPlanManejo
        Inherits GPMData

        'Private objGeneral As New objDatosGenerales.DatosGenerales
        'Private objPaciente As New objComun.Paciente

#Region "GrabarProcExternos"
        ''' <summary>
        ''' Funcion que guarda los Procedimientos Externos en el plan de manejo de la
        ''' Historia Clínica
        ''' </summary>
        ''' <param name="objConexion">Objeto con los datos de la conexion</param>
        ''' <param name="xmlProcedimientos">XML con la información de los procedimientos</param>
        ''' <param name="strSucursal">parámetro de tipo string que indica el código de la sucursal</param>
        ''' <param name="NroOrden">Número de orden que retorna el stored procedure</param>
        ''' <returns>Número que indica el error (0) si no hubo error</returns>
        ''' <remarks></remarks>
        Public Function GrabarProcExternos(ByVal objConexion As objCon, ByVal xmlProcedimientos As String,
        ByVal strSucursal As String, ByRef NroOrden As Double) As Long
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim lError As Long

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetStoredProcCommandWrapper("HC_GrabarOrdenesProcedimientos")
            '' ''With command
            '' ''    .AddInParameter("strCodSucur", DbType.String, strSucursal)
            '' ''    .AddInParameter("xmlProcedimientos", DbType.String, xmlProcedimientos)
            '' ''    .AddOutParameter("lngConsec", DbType.Double, 9)
            '' ''    .AddOutParameter("lError", DbType.Int16, 4)
            '' ''End With

            '' ''db.ExecuteNonQuery(command)
            '' ''lError = CType(command.GetParameterValue("@lError"), Long)
            '' ''NroOrden = CType(command.GetParameterValue("@lngConsec"), Double)
            '' ''command.Command.Connection.Close()
            '' ''command.Dispose()
            Me.setSQLSentence("HC_GrabarOrdenesProcedimientos", CommandType.StoredProcedure)
            Me.addInputParameter("strCodSucur", SqlDbType.VarChar, strSucursal)
            Me.addInputParameter("xmlProcedimientos", SqlDbType.Text, xmlProcedimientos)
            Me.addOutputParameter("lngConsec", SqlDbType.Decimal)
            Me.addOutputParameter("lError", SqlDbType.Int)

            Me.Exec()
            lError = Me.Parameters("lError").Value
            NroOrden = Me.Parameters("lngConsec").Value
            Return lError

        End Function
#End Region

#Region "GrabarFormulacionExterna"
        ''' <summary>
        ''' Funcion que guarda los Procedimientos Externos en el plan de manejo de la
        ''' Historia Clínica
        ''' </summary>
        ''' <param name="objConexion">Objeto con los datos de la conexion</param>
        ''' <param name="xmlMedicamento">XML con la información de los Medicamentos</param>
        ''' <param name="strSucursal">parámetro de tipo string que indica el código de la sucursal</param>
        ''' <param name="NroOrden">Número de orden que retorna el stored procedure</param>
        ''' <param name="dNumAdm">Parámetro de tipo doubled que indica el número de admisión</param>
        ''' <param name="iAnoAdm">Parámetro de tipo entero que indica el año de admisión</param>
        ''' <param name="strTipoAdm">Parámetro de tipo string que indica el tipo de admisión</param>
        ''' <returns>Número que indica el error (0) si no hubo error</returns>
        ''' <remarks></remarks>
        Public Function GrabarFormulacionExterna(ByVal objConexion As objCon, ByVal xmlMedicamento As String,
                                                 ByVal strPrestador As String, ByVal strSucursal As String, ByRef NroOrden As Double,
                                                 ByVal strTipoAdm As String, ByVal dNumAdm As Double,
                                                 ByVal iAnoAdm As Integer, ByVal tmpFormula As Double, ByVal tmpCodsucur As String, ByVal FlagUpdate As Integer) As String
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim lError As Long
            Dim formulasGeneradas As String
            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetStoredProcCommandWrapper("HC_GrabarOrdenesMedicamentos")
            '' ''With command
            '' ''    .AddInParameter("strCodPreSgs", DbType.String, strPrestador)
            '' ''    .AddInParameter("strCodSucur", DbType.String, strSucursal)
            '' ''    .AddInParameter("xmlMedicamento", DbType.String, xmlMedicamento)
            '' ''    .AddOutParameter("lngConsec", DbType.Double, 9)

            '' ''    .AddInParameter("NroFormula", DbType.Double, NroOrden)
            '' ''    .AddInParameter("strTipAdm", DbType.String, strTipoAdm)
            '' ''    .AddInParameter("dNumAdm", DbType.Double, dNumAdm)
            '' ''    .AddInParameter("lAnoAdm", DbType.Int32, iAnoAdm)
            '' ''    .AddOutParameter("lError", DbType.Int16, 4)
            '' ''End With

            '' ''db.ExecuteNonQuery(command)
            '' ''lError = CType(command.GetParameterValue("@lError"), Long)
            '' ''NroOrden = CType(command.GetParameterValue("@lngConsec"), Double)
            '' ''command.Command.Connection.Close()
            '' ''command.Dispose()
            Me.setSQLSentence("HC_GrabarOrdenesMedicamentos_CQ", CommandType.StoredProcedure)
            Me.addInputParameter("strCodPreSgs", SqlDbType.VarChar, strPrestador)
            Me.addInputParameter("strCodSucur", SqlDbType.VarChar, strSucursal)
            Me.addInputParameter("xmlMedicamento", SqlDbType.VarChar, xmlMedicamento)
            Me.addOutputParameter("lngConsec", SqlDbType.Decimal, 9)
            Me.addInputParameter("NroFormula", SqlDbType.Decimal, NroOrden)
            Me.addInputParameter("strTipAdm", SqlDbType.VarChar, strTipoAdm)
            Me.addInputParameter("dNumAdm", SqlDbType.Decimal, dNumAdm)
            Me.addInputParameter("lAnoAdm", SqlDbType.Int, iAnoAdm)
            Me.addInputParameter("tmpFormula", SqlDbType.Decimal, tmpFormula)
            Me.addInputParameter("tmpCodSucur", SqlDbType.VarChar, tmpCodsucur)
            Me.addInputParameter("tmpUpdate", SqlDbType.Int, FlagUpdate)
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.addOutputParameter("formulasGeneradas", SqlDbType.VarChar, "1000")
            Me.Exec()
            lError = Me.Parameters("@lError").Value
            NroOrden = Me.Parameters("@lngConsec").Value
            formulasGeneradas = Me.Parameters("@formulasGeneradas").Value
            Return formulasGeneradas

        End Function


        Public Function EliminarMedicamentoFormulacionExterna(ByVal objConexion As objCon, ByVal dblNroFormula As Double, ByVal strProducto As String,
                                                              ByVal strPrestador As String, ByVal strSucursal As String, ByVal strTipoAdmision As String,
                                                              ByVal intAnoAdmision As Integer, ByVal dblNumeroAdmision As Double) As Long

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim lError As Long

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetStoredProcCommandWrapper("HC_GrabarOrdenesMedicamentos")
            '' ''With command
            '' ''    .AddInParameter("strCodPreSgs", DbType.String, strPrestador)
            '' ''    .AddInParameter("strCodSucur", DbType.String, strSucursal)
            '' ''    .AddInParameter("xmlMedicamento", DbType.String, strProducto)
            '' ''    .AddInParameter("lngConsec", DbType.Double, 3)
            '' ''    .AddInParameter("NroFormula", DbType.Double, dblNroFormula)
            '' ''    .AddInParameter("strTipAdm", DbType.String, strTipoAdmision)
            '' ''    .AddInParameter("dNumAdm", DbType.Double, dblNumeroAdmision)
            '' ''    .AddInParameter("lAnoAdm", DbType.Int32, intAnoAdmision)
            '' ''    .AddOutParameter("lError", DbType.Int16, 4)
            '' ''End With

            '' ''db.ExecuteNonQuery(command)
            '' ''lError = CType(command.GetParameterValue("@lError"), Long)
            '' ''command.Command.Connection.Close()
            '' ''command.Dispose()
            Me.setSQLSentence("HC_GrabarOrdenesMedicamentos_CQ", CommandType.StoredProcedure)
            Me.addInputParameter("strCodPreSgs", SqlDbType.VarChar, strPrestador)
            Me.addInputParameter("strCodSucur", SqlDbType.VarChar, strSucursal)
            Me.addInputParameter("xmlMedicamento", SqlDbType.VarChar, strProducto)
            Me.addInputParameter("lngConsec", SqlDbType.Decimal, 3)

            Me.addInputParameter("NroFormula", SqlDbType.Decimal, dblNroFormula)
            Me.addInputParameter("strTipAdm", SqlDbType.VarChar, strTipoAdmision)
            Me.addInputParameter("dNumAdm", SqlDbType.Decimal, dblNumeroAdmision)
            Me.addInputParameter("lAnoAdm", SqlDbType.Int, intAnoAdmision)
            Me.addInputParameter("tmpFormula", SqlDbType.Decimal, 0)
            Me.addInputParameter("tmpcodsucur", SqlDbType.VarChar, "")
            Me.addInputParameter("tmpUpdate", SqlDbType.Int, 0)
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.addOutputParameter("formulasGeneradas", SqlDbType.VarChar, "1000")

            Me.executeScalar()
            lError = Me.ParametersCollection("@lError").Value

            Return lError

        End Function
        Public Function EjecutarSPConsultarDiasTratOsi(ByVal objConexion As objCon, ByVal EntidadDiasTrat As String) As DataTable

            Dim lError As Long
            Dim dtDiasT As DataTable

            Me.ClearParameters()
            Me.setSQLSentence("HC_ConsultarDiasTratEPSOsi", CommandType.StoredProcedure)
            Me.addInputParameter("Entidad", SqlDbType.VarChar, EntidadDiasTrat)
            dtDiasT = Me.execDT
            Return dtDiasT
        End Function


#End Region

#Region "GrabarEVolucion"

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Proceso de grabar datos de la evolucion(procedimiento HC_GrabarEvolucion)
        ''' </summary>
        ''' <param name="objConexion">Parámetro de tipo conexion</param>
        ''' <param name="strDiagnostico">Parámetro de tipo string que indica el código del diagnóstico</param>
        ''' <param name = "strObjetivo">Parámetro de tipo string que indica el objetivo</param>
        ''' <param name = "strParaclinico">Parámetro de tipo string que indica el resumen paraclínico</param>
        ''' <param name = "strPlanManejo">Parámetro de tipo string que indica el resumen del plan de manejo</param>
        ''' <param name="dNumeroAdmin">Parámetro de tipo doubled que indica el número de admisión</param>
        ''' <param name="intAnoAdmin">Parámetro de tipo entero que indica el año de admisión</param>
        ''' <param name="intHora">Parámetro de tipo entero que indica la hora de evolución</param>
        ''' <param name="intMinuto">Parámetro de tipo entero que indica el minuto de la evolución</param>
        ''' <param name="strFecha">Parámetro de tipo string que indica la fecha de la evolución</param>
        ''' <param name="strLogin">Parámetro de tipo string que indica el login</param>
        ''' <param name="strNumDocumento">Parámetro de tipo string que indica el número del documento</param>
        ''' <param name="strPrestador">Parámetro de tipo string que indica el prestador</param>
        ''' <param name="strSubjetivo">Parámetro de tipo string que indica el resumen subjetivo</param>
        ''' <param name="strSucursal">Parámetro de tipo string que indica la sucursal</param>
        ''' <param name="strTipoAdmin">Parámetro de tipo string que indica el tipo de admisión</param>
        ''' <param name="strTipoDocumento">Parámetro de tipo string que indica el tipo de documento</param>
        ''' <returns>long con respuesta de la operación
        ''' <param name = "strFecha">Parámetro de tipo string que indica la fecha</param>
        ''' <param name = "intHora">Parámetro de tipo entero que indica la hora</param>
        ''' <param name = "intMinuto">Parámetro de tipo entero que indica el minuto</param>
        '''</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas] 09/05/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------

        Public Function GrabarEvolucion(ByVal objConexion As objCon,
        ByVal strPrestador As String, ByVal strSucursal As String,
        ByVal strTipoDocumento As String, ByVal strNumDocumento As String,
        ByVal strTipoAdmin As String, ByVal intAnoAdmin As Integer,
        ByVal dNumeroAdmin As Double, ByVal strLogin As String,
        ByVal strDiagnostico As String, ByVal strObjetivo As String,
        ByVal strParaclinico As String, ByVal strPlanManejo As String,
        ByVal strSubjetivo As String, ByVal strNotasIngreso As String, ByRef strFecha As String,
        ByRef intHora As Integer, ByRef intMinuto As Integer,
        ByVal strexp_pla As String, ByVal strcon_med As String, ByVal strInterconsulta As String,
        ByVal strEspecialidad As String, ByVal strMedico As String, ByVal strMotivo As String, ByVal strcierre As String, ByVal strespecMedSol As String,
        Optional ByVal NroOrden As String = Nothing, Optional ByVal IdTipoEvolucion As Integer = Nothing) As Long

            'martovar 2014-08-08 req.03 version 2.9.0 Generacion de interconsultas se egregan especialidad,medico,motivo,cierre

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim lError As Long

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetStoredProcCommandWrapper("HC_GrabarEvolucion")
            '' ''With command

            '' ''    .AddInParameter("strCodPreSgs", DbType.String, strPrestador)
            '' ''    .AddInParameter("strCodSucur", DbType.String, strSucursal)
            '' ''    .AddInParameter("strTipDoc", DbType.String, strTipoDocumento)
            '' ''    .AddInParameter("strNumDoc", DbType.String, strNumDocumento)
            '' ''    .AddInParameter("strTipAdm", DbType.String, strTipoAdmin)

            '' ''    .AddInParameter("intAnoAdm", DbType.Int32, intAnoAdmin)
            '' ''    .AddInParameter("dblNumAdm", DbType.Double, dNumeroAdmin)
            '' ''    .AddInParameter("strLogin", DbType.String, strLogin)
            '' ''    .AddInParameter("strDiagnostico", DbType.String, strDiagnostico)
            '' ''    .AddInParameter("strObjetivo", DbType.String, strObjetivo)

            '' ''    .AddInParameter("strParaclinico", DbType.String, strParaclinico)
            '' ''    .AddInParameter("strPlanManejo", DbType.String, strPlanManejo)
            '' ''    .AddInParameter("strSubjetivo", DbType.String, strSubjetivo)
            ''TODO: verificar los parametros de salida
            '' ''    .AddOutParameter("strFechaEvol", DbType.String, 12)
            '' ''    .AddOutParameter("intHoraEvol", DbType.Int16, 4)

            '' ''    .AddOutParameter("intMinEvol", DbType.Int16, 4)
            '' ''    .AddOutParameter("lError", DbType.Int16, 4)
            '' ''End With

            '' ''db.ExecuteNonQuery(command)
            '' ''lError = CType(command.GetParameterValue("@lError"), Long)
            '' ''strFecha = command.GetParameterValue("@strFechaEvol")
            '' ''intHora = CType(command.GetParameterValue("@intHoraEvol"), Integer)
            '' ''intMinuto = CType(command.GetParameterValue("@intMinEvol"), Integer)
            '' ''command.Command.Connection.Close()
            '' ''command.Dispose()

            Me.setSQLSentence("HC_GrabarEvolucion", CommandType.StoredProcedure)

            Me.addInputParameter("strCodPreSgs", SqlDbType.VarChar, strPrestador)
            Me.addInputParameter("strCodSucur", SqlDbType.VarChar, strSucursal)
            Me.addInputParameter("strTipDoc", SqlDbType.VarChar, strTipoDocumento)
            Me.addInputParameter("strNumDoc", SqlDbType.VarChar, strNumDocumento)
            Me.addInputParameter("strTipAdm", SqlDbType.VarChar, strTipoAdmin)

            Me.addInputParameter("intAnoAdm", SqlDbType.Int, intAnoAdmin)
            Me.addInputParameter("dblNumAdm", SqlDbType.Decimal, dNumeroAdmin)
            Me.addInputParameter("strLogin", SqlDbType.VarChar, strLogin)
            Me.addInputParameter("strDiagnostico", SqlDbType.VarChar, strDiagnostico)
            Me.addInputParameter("strObjetivo", SqlDbType.VarChar, strObjetivo)

            Me.addInputParameter("strParaclinico", SqlDbType.VarChar, strParaclinico)
            Me.addInputParameter("strPlanManejo", SqlDbType.VarChar, strPlanManejo)
            Me.addInputParameter("strSubjetivo", SqlDbType.VarChar, strSubjetivo)
            Me.addInputParameter("strNotasIngreso", SqlDbType.VarChar, strNotasIngreso)
            Me.addOutputParameter("strFechaEvol", SqlDbType.VarChar, 12)

            Me.addOutputParameter("intHoraEvol", SqlDbType.Int)
            Me.addOutputParameter("intMinEvol", SqlDbType.Int)
            Me.addInputParameter("strexp_pla", SqlDbType.VarChar, strexp_pla)
            Me.addInputParameter("strcon_med", SqlDbType.VarChar, strcon_med)
            Me.addInputParameter("strinterconsulta", SqlDbType.VarChar, strInterconsulta)

            Me.addInputParameter("strespecialidad", SqlDbType.VarChar, strEspecialidad) 'martovar 2.9.0
            Me.addInputParameter("strmedico_sol", SqlDbType.VarChar, strMedico) 'martovar 2.9.0
            Me.addInputParameter("strmotivo", SqlDbType.VarChar, strMotivo) 'martovar 2.9.0
            Me.addInputParameter("strcierre", SqlDbType.VarChar, strcierre) 'martovar 2.9.0
            Me.addInputParameter("strespecMedSol", SqlDbType.VarChar, strespecMedSol) 'martovar control de cambios  2015/08/14

            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.addInputParameter("NroOrden", SqlDbType.VarChar, NroOrden) 'cariasm Se agrega NroOrden de interconsulta 5.3.0
            Me.addInputParameter("IdTipoEvolucion", SqlDbType.Int, IdTipoEvolucion) 'cariasm Se agrega Tipo de Evolucion. 5.3.0

            Me.Exec()

            lError = Val(Me.Parameters("lError").Value)
            strFecha = Me.Parameters("strFechaEvol").Value
            intHora = Val(Me.Parameters("intHoraEvol").Value)
            intMinuto = Val(Me.Parameters("intMinEvol").Value)
            Return lError

        End Function
#End Region

#Region "ConsultarConvenio"
        Public Function consultarConvenioMedicamento(ByVal objConexion As objCon, ByVal codProducto As String, ByVal cod_pre_sgs As String,
                                                                       ByVal cod_sucur As String, ByVal entidad As String) As Boolean

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 12/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            '' ''Dim numeroRegistros As Integer

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetStoredProcCommandWrapper("HC_ConsultarConvenio")
            '' ''With command
            '' ''    .AddInParameter("strCodPreSgs", DbType.String, cod_pre_sgs)
            '' ''    .AddInParameter("strCodSucur", DbType.String, cod_sucur)
            '' ''    .AddInParameter("strProducto", DbType.String, codProducto)
            '' ''    .AddInParameter("strEntidad", DbType.String, entidad)
            '' ''End With

            '' ''numeroRegistros = db.ExecuteScalar(command)
            '' ''If numeroRegistros <= 0 Then
            '' ''    Return False
            '' ''Else
            '' ''    Return True
            '' ''End If
            Me.setSQLSentence("HC_ConsultarConvenio", CommandType.StoredProcedure)
            Me.addInputParameter("strCodPreSgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("strCodSucur", SqlDbType.VarChar, cod_sucur)
            Me.addInputParameter("strProducto", SqlDbType.VarChar, codProducto)
            Me.addInputParameter("strEntidad", SqlDbType.VarChar, entidad)

            If (Integer.Parse(Me.executeScalar()) <= 0) Then
                Return False
            Else
                Return True
            End If

        End Function
#End Region

#Region "GrabarMotRemision"
        ''' <summary>
        ''' Funcion que guarda datos en la tabla HCEncOtros
        ''' En este caso se grabaran los Motivos de Remision en el plan de manejo de la
        ''' Historia Clínica
        ''' </summary>
        ''' ''Claudia Garay Acreditacion Diciembre 9 de 2010
        Public Function ProgramasEducacionRE(ByVal objConexion As objCon, ByVal CodPreSgs As String,
           ByVal strSucursal As String, ByVal Tip_Admision As String, ByVal ano_adm As Integer,
           ByVal num_adm As Decimal, ByVal codigo_programa As String,
           ByVal Login As String, ByVal Obs As String, ByVal intAccion As Integer) As DataTable

            Dim lError As Long
            Dim dtPrograma As DataTable

            Me.ClearParameters()
            Me.setSQLSentence("HC_ProgramaEducacion", CommandType.StoredProcedure)
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, CodPreSgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strSucursal)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, Tip_Admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("num_adm", SqlDbType.Decimal, num_adm)
            Me.addInputParameter("codigo_programa", SqlDbType.VarChar, codigo_programa)
            Me.addInputParameter("login", SqlDbType.VarChar, Login)
            Me.addInputParameter("obs", SqlDbType.VarChar, Obs)
            Me.addInputParameter("intAccion", SqlDbType.Int, intAccion)
            Me.addOutputParameter("lError", SqlDbType.Int, 0)

            dtPrograma = Me.execDT
            lError = Me.Parameters("lError").Value
            Return dtPrograma

        End Function
#End Region

        Public Function GrabarHC_insertmotivoremisionprocedimientos(ByVal objConexion As objCon, ByVal CodPreSgs As String,
           ByVal strSucursal As String, ByVal Tip_Admision As String, ByVal ano_adm As Integer,
           ByVal num_adm As Long, ByVal NroOrden As Double, ByVal strMotRem As String,
           ByVal Login As String, ByVal Obs As String) As Long

            Dim lError As Long

            Me.setSQLSentence("HC_insertmotivoremisionprocedimientos", CommandType.StoredProcedure)
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, CodPreSgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strSucursal)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, Tip_Admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("num_adm", SqlDbType.Decimal, num_adm)
            Me.addInputParameter("NroOrden", SqlDbType.Decimal, NroOrden)
            Me.addInputParameter("strMotRem", SqlDbType.Text, strMotRem)
            Me.addInputParameter("login", SqlDbType.VarChar, Login)
            Me.addInputParameter("obs", SqlDbType.Text, Obs)
            Me.addOutputParameter("lError", SqlDbType.Int, 0)

            Me.Exec()
            lError = Me.Parameters("lError").Value
            Return lError

        End Function

    End Class
End Namespace
