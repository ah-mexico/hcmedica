Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO

Namespace Sophia.HistoriaClinica.BL

#Region "BLPlanManejo"


    ''' -----------------------------------------------------------------------------
    ''' Project	 : HistoriaClinica.BL.BLEgresos
    ''' Class	 : Sophia.HistoriaClinica.Egresos.Bl.BLEgresos
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Clase Egresos del namespace Sophia.HistoriaClinica.Egresos.Bl que es la clase base
    ''' HistoriaClinica.BL
    ''' y será usada desde este namespace para el proceso de la funcionalidad de los Egresos
    ''' en la aplicación cliente en Windows Form 2005
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[mvargas]	28/03/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------

    Public Class BLPlanManejo


#Region "Enumeraciones"
        Enum Accion
            Cargar = 1
            Grabar = 2
        End Enum
#End Region

#Region "Constantes"
        Public Const INICIA As String = "I"
        Public Const SUSPENDE As String = "S"
        Public Const CONTINUA As String = "C"
#End Region

#Region "GrabarProcedimientosExternos"

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Proceso de grabar datos de los procedimientos externos (procedimiento pa_busHC_GrabarOrdenesProcedimientosNuevo)
        ''' </summary>
        ''' <param name="dtProcedimientos">Parámetro de tipo datatable que contiene los datos de los Procedimientos externos</param>
        ''' <returns>long con respuesta de la transacción</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas] 5/05/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function GrabarProcExternos(ByVal objConexion As objCon, ByVal dtProcedimientos As DataTable, ByRef NroOrden As Double) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOPlanManejo
            Dim objG As objGeneral = objGeneral.Instancia

            Dim xmlProcedimientos As String = ""
            Dim lError As Long

            'Joseph Moreno (IG) Fec:2019/11/26 Particularidades
            'xmlProcedimientos = FuncionesGenerales.GenerarXMLxProcedimiento(dtProcedimientos)
            xmlProcedimientos = FuncionesGenerales.GenerarXMLxProcedimiento(
                                       dtProcedimientos,
                                       New HashSet(Of String)({"xmlGrpXPar"})
                                 )

            'lError = obj.EjecutarSPConParametrosTran("pa_busHC_GrabarOrdenesProcedimientosNuevo", objConexion, _
            lError = obj.GrabarProcExternos(objConexion, xmlProcedimientos, objG.Sucursal, NroOrden)
            Return lError

        End Function

        Public Function GrabarHC_insertmotivoremisionprocedimientos(ByVal objConexion As objCon, ByVal NroOrden As Double, ByVal strMotRem As String) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOPlanManejo
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objD As DatosPaciente.Paciente = DatosPaciente.Paciente.Instancia

            Dim lError As Long

            lError = obj.GrabarHC_insertmotivoremisionprocedimientos(objConexion, objG.Prestador, objG.Sucursal, objD.TipoAdmision, objD.AnoAdmision, objD.NumeroAdmision, NroOrden, strMotRem, objG.Login, "")
            Return lError

        End Function

        Public Function GrabarProcContrarreferencia(ByVal objConexion As objCon,
                        ByVal dtProcedimientos As DataTable, ByVal codPreSgs_Origen As String,
                        ByVal codSucur_Origen As String, ByVal tipAdm_Origen As String,
                        ByVal anoAdm_Origen As Integer, ByVal numAdm_Origen As Double,
                        ByVal strCodPreSgs_Prac As String, ByVal strCodSucur_Prac As String,
                        ByVal strTipAdm_Prac As String, ByVal anoAdm_Prac As Integer,
                        ByVal numAdm_Prac As Double) As Long

            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim xmlProcedimientos As String = ""
            Dim dtProcModificados As DataTable
            Dim lError As Long
            Dim i As Integer

            If IsNothing(dtProcedimientos) Then
                Return 17
            End If

            dtProcModificados = dtProcedimientos.Clone()
            dtProcModificados = BLOrdenes.filtrarTabla(dtProcedimientos, DataViewRowState.ModifiedCurrent, dtProcModificados)
            dtProcModificados = configurarDataTableProcedim(dtProcModificados)

            If IsNothing(dtProcModificados) Then
                Return 17
            ElseIf dtProcModificados.Rows.Count <= 0 Then
                Return 17
            End If

            For i = 0 To dtProcModificados.Rows.Count - 1
                If dtProcModificados.Rows(i).Item("resultado").ToString.Trim.Length > 0 And
                   dtProcModificados.Rows(i).Item("interpretacion").ToString.Trim.Length > 0 Then
                    dtProcModificados.Rows(i).Item("cerrado") = "S"
                End If
            Next i

            xmlProcedimientos = FuncionesGenerales.GenerarXMLxProcedimiento(dtProcModificados)

            lError = obj.EjecutarSPConParametrosTran("HC_ActualizarProcedimContrareferencia",
                     objConexion, codPreSgs_Origen, codSucur_Origen, tipAdm_Origen, anoAdm_Origen,
                     numAdm_Origen, strCodPreSgs_Prac, strCodSucur_Prac, strTipAdm_Prac, anoAdm_Prac,
                     numAdm_Prac, xmlProcedimientos, lError)

            Return lError

        End Function

        Public Shared Function configurarDataTableProcedim(ByVal dtProcedim As DataTable) As DataTable
            Dim dtFiltrado As DataTable

            dtFiltrado = dtProcedim.Copy()
            With dtFiltrado.Columns
                .Remove("cod_pre_sgs")
                .Remove("cod_sucur")
                .Remove("tip_admision")
                .Remove("ano_adm")
                .Remove("num_adm")
                .Remove("tip_doc")
                .Remove("Num_doc")
                .Remove("entidad")
                .Remove("cantidad")
                .Remove("can_aplicada")
                .Remove("fecha")
                .Remove("medico")
                .Remove("estado")
                .Remove("pais")
                .Remove("departamen")
                .Remove("ciudad")
                .Remove("fec_con")
                .Remove("login")
                .Remove("obs")
                .Remove("bilateral")
                .Remove("recomendacion")
                .Remove("Descripcion")
                .Remove("Nuevo")
                .Remove("tipoprocedim")
                .Remove("desctipo")
                .Remove("PyP")
            End With

            Return dtFiltrado

        End Function


#End Region

#Region "GrabarFormulacionExterna"
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Proceso de grabar datos de las formulaciones externas (procedimiento pa_busHC_GrabarOrdenesMedicamentosNuevo)
        ''' </summary>
        ''' <param name="dtMedicamento">Parámetro de tipo datatable que contiene los datos de los medicamentos</param>
        ''' <returns>long con respuesta de la transacción</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas] 09/05/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------

        Public Function GrabarFormulacionExterna(ByVal objConexion As objCon, ByVal dtMedicamento As DataTable, ByRef NroOrden As Double,
                                                ByVal strPrestador As String, ByVal strSucursal As String, ByVal strTipoAdm As String,
                                                ByVal dNumeroAdmision As Double, ByVal iAnoAdm As Integer, ByVal tmpFormula As Double, ByVal tmpCodsucur As String, ByVal FlagUpdate As Integer) As String
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOPlanManejo

            Dim xmlMedicamento As String = ""
            Dim lError As Long
            Dim rtornoFormulas As String
            procesarCampoTratamiento(dtMedicamento, INICIA, Accion.Grabar)

            xmlMedicamento = FuncionesGenerales.GenerarXMLxProcedimiento(dtMedicamento)
            rtornoFormulas = obj.GrabarFormulacionExterna(objConexion, xmlMedicamento, strPrestador, strSucursal, NroOrden, strTipoAdm, dNumeroAdmision, iAnoAdm, tmpFormula, tmpCodsucur, FlagUpdate)
            Return rtornoFormulas

        End Function

        Public Function EliminarMedicamentoFormulacionExterna(ByVal objConexion As objCon, ByVal dblNroFormula As Double, ByVal strProducto As String,
                                                              ByVal strPrestador As String, ByVal strSucursal As String, ByVal strTipoAdmision As String,
                                                              ByVal intAnoAdmision As Integer, ByVal dblNumeroAdmision As Double) As Long

            Dim obj As New Sophia.HistoriaClinica.DAO.DAOPlanManejo

            Dim lError As Long

            lError = obj.EliminarMedicamentoFormulacionExterna(objConexion, dblNroFormula, strProducto, strPrestador, strSucursal, strTipoAdmision, intAnoAdmision, dblNumeroAdmision)
            Return lError

        End Function

        Public Shared Sub procesarCampoTratamiento(ByRef dtDatos As DataTable, ByVal valor As String, ByVal eAccion As Accion)

            Dim rowArray() As DataRow
            Dim row As DataRow

            If eAccion = Accion.Cargar Then ''Cargar
                rowArray = dtDatos.Select("tratamiento = '" & valor & "'")

                For Each row In rowArray
                    row.Item("tratamiento") = Nothing
                Next

            ElseIf eAccion = Accion.Grabar Then ''Grabar
                rowArray = dtDatos.Select("tratamiento is null")

                For Each row In rowArray
                    row.Item("tratamiento") = valor
                Next

            End If
        End Sub

#End Region

#Region "GrabarIncapacidad"
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Proceso de grabar datos de la incapacidad (procedimiento pa_busHC_GrabarIncapacidad)
        ''' </summary>
        ''' <param name="objConexion">Parámetro de tipo conexion</param>
        ''' <param name="strDiagnostico">Parámetro de tipo string que indica el código del diagnóstico</param>
        ''' <param name="intCantidad">Parámetro de tipo integer que indica la cantidad de días</param>
        ''' <param name="strFechaIncapacidad">Parámetro de tipo date que indica la fecha inicial de incapacidad</param>
        ''' <returns>long con respuesta de la operación</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas] 09/05/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------

        Public Function GrabarIncapacidad(ByVal objConexion As objCon, ByVal strDiagnostico As String,
                                          ByVal intCantidad As Integer, ByVal strFechaIncapacidad As String, ByVal Observaciones As String) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia

            Dim lError As Long

            lError = obj.EjecutarSPConParametrosTran("HC_GrabarIncapacidad", objConexion,
                                                     objG.Prestador, objG.Sucursal, objP.TipoAdmision,
                                                     objP.AnoAdmision, objP.NumeroAdmision, strDiagnostico,
                                                     intCantidad, Format(CDate(strFechaIncapacidad), objG.FormatoFechaCorta), objG.CodigoEspecialidad, objG.Login, lError, Observaciones)
            Return lError

        End Function
#End Region

#Region "ConsultarDatosIncapacidad"
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Función para consultar los datos para la incapacidad (se arma sql)
        ''' </summary>
        ''' <param name="objConexion">Parámetro de tipo conexion</param>
        ''' <returns>arraylist con datos de la consulta</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas] 10/05/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------

        Public Function ConsultarDatosIncapacidad(ByVal objConexion As objCon) As ArrayList
            '// para consultar los datos de una incapacidad \\
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia
            Dim arIncapacidad As New ArrayList
            Dim strsql As String

            strsql = "Select a.diagnost, b.descripcion, a.obs from hcimpdiagn a, gendiagn b where a.diagnost = b.diagnost" &
               " and a.cod_pre_sgs = '" & objG.Prestador & "' and a.cod_sucur= '" & objG.Sucursal & "'" &
             " and a.tip_admision = '" & objP.TipoAdmision & "' and a.ano_adm = " & objP.AnoAdmision &
             " and a.num_adm = " & objP.NumeroAdmision & " and categoria_diag = 'P'"
            '       " and a.cod_pre_sgs = '830051232' and a.cod_sucur= '0102'" & _
            '       " and a.tip_admision = 'E' and a.ano_adm = 2004  and a.num_adm = 103289 and categoria_diag = 'P'"


            arIncapacidad = obj.EjecutarSQLArrayList(objConexion, strsql)
            Return arIncapacidad

        End Function
#End Region

#Region "GrabarEvolucion"

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Proceso de grabar datos de la evolucion
        ''' </summary>
        ''' <param name="objConexion">Parámetro de tipo conexion</param>
        ''' <param name="strDiagnostico">Parámetro de tipo string que indica el código del diagnóstico</param>
        ''' <param name = "strObjetivo">Parámetro de tipo string que indica el objetivo</param>
        ''' <param name = "strParaclinico">Parámetro de tipo string que indica el resumen paraclínico</param>
        ''' <param name = "strPlanManejo">Parámetro de tipo string que indica el resumen del plan de manejo</param>
        ''' <param name="strSubjetivo">Parámetro de tipo string que indica el resumen de subjetivo</param>
        ''' <param name="strFecha">Parámetro de tipo string que indica la fecha</param>
        ''' <param name="intHora">Parámetro de tipo entero que indica la hora</param>
        ''' <param name="intMinuto">Parámetro de tipo entero que indica minuto</param>
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

        Public Function GrabarEvolucion(ByVal objConexion As objCon, ByVal strDiagnostico As String,
            ByVal strObjetivo As String, ByVal strParaclinico As String,
            ByVal strPlanManejo As String, ByVal strSubjetivo As String, ByVal strNotaIngreso As String,
            ByRef strFecha As String, ByRef intHora As Integer, ByRef intMinuto As Integer,
            ByVal strexp_pla As String, ByVal strcon_med As String, ByVal strInterconsulta As String,
            ByVal strEspecialidad As String, ByVal strMedico As String, ByVal strMotivo As String, ByVal strcierre As String, ByVal strespecMedSol As String,
            Optional ByVal NroOrden As String = Nothing, Optional ByVal IdTipoEvolucion As Integer = Nothing) As Long

            'martovar 2014-08-08 req.03 version 2.9.0 Generacion de interconsultas se egregan especialidad,medico,motivo,cierre

            Dim obj As New Sophia.HistoriaClinica.DAO.DAOPlanManejo

            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia
            'If strFecha.Length < 5 Then
            '    strFecha = ""
            'End If
            Dim lError As Long

            lError = obj.GrabarEvolucion(objConexion, objG.Prestador, objG.Sucursal,
                                        objP.TipoDocumento, objP.NumeroDocumento,
                                        objP.TipoAdmision, objP.AnoAdmision,
                                        objP.NumeroAdmision, objG.Login,
                                        strDiagnostico, strObjetivo, strParaclinico,
                                        strPlanManejo, strSubjetivo, strNotaIngreso, strFecha,
                                        intHora, intMinuto, strexp_pla, strcon_med, strInterconsulta,
                                         strEspecialidad, strMedico, strMotivo, strcierre, strespecMedSol, NroOrden, IdTipoEvolucion)


            Return lError

        End Function

#End Region

#Region "GrabarRecomendacionEgreso"

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Proceso de grabar datos de las recomendaciones al egreso (procedimiento pa_busHC_GrabarRecomendacionEgreso)
        ''' </summary>
        ''' <param name="objConexion">Parámetro de tipo conexion</param>
        ''' <param name="strSignos">Parámetro de tipo string que indica los signos de alarma</param>
        ''' <param name="strFiebre">Parámetro de tipo string que indica signo de infeccion fiebre</param>
        ''' <param name="strCalor">Parámetro de tipo string que indica signo de infeccion calor heridad</param>
        ''' <param name="strSecrecion">Parámetro de tipo string que indica signo de infeccion secrecion heridad</param>
        ''' <param name="strEnrojecimiento">Parámetro de tipo string que indica signo de infeccion enrojecimiento heridad</param>
        ''' <param name="strActividad">Parámetro de tipo string que indica actividad física</param>
        ''' <param name="strNutricionales">Parámetro de tipo string que indica recomendaciones nutricionales</param>
        ''' <param name="strGenerales">Parámetro de tipo string que indica recomendaciones generales</param>
        ''' <param name="strResultado">Parámetro de tipo string que indica resultado de examenenes</param>
        ''' <param name="strFechaControl">Parámetro de tipo string que indica la fecha control</param>
        ''' <param name="strLugar">Parámetro de tipo string que indica lugar control</param>
        ''' <param name="strTelefono">Parámetro de tipo string que indica telefono médico</param>
        ''' <returns>long con respuesta de la operación</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas] 129/05/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------

        Public Function GrabarRecomendacionEgreso(ByVal objConexion As objCon, ByVal intAction As Integer, ByVal strSignos As String,
                                ByVal strFiebre As String, ByVal strCalor As String, ByVal strSecrecion As String,
                                ByVal strEnrojecimiento As String, ByVal strActividad As String, ByVal strNutricionales As String,
                                ByVal strGenerales As String, ByVal strResultado As String, ByVal strFechaControl As String,
                                ByVal strLugar As String, ByVal strTelefono As String, ByVal strConciliacion As String) As Long

            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia

            Dim lError As Long

            lError = obj.EjecutarSPConParametrosTran("HC_GrabarRecomendacionEgreso", objConexion,
                                                     intAction, objG.Prestador, objG.Sucursal, objP.TipoAdmision,
                                                     objP.AnoAdmision, objP.NumeroAdmision,
                                                      strSignos, strFiebre, strCalor, strSecrecion, strEnrojecimiento,
                                                      strActividad, strNutricionales, strGenerales,
                                                      strResultado, strFechaControl, strLugar, strTelefono,
                                                     strConciliacion, objG.Login, lError)
            Return lError

        End Function

#End Region

#Region "GrabarRemision"

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Proceso de grabar datos de las remisiones en el plan de manejo (procedimiento pa_busHC_GrabarRecomendacionEgreso)
        ''' </summary>
        ''' <param name="objConexion">Parámetro de tipo conexion</param>
        ''' <param name="strEntidad">Parámetro de tipo string que indica el código de la entidad donde se remite</param>
        ''' <param name="strDesEntidad">Parámetro de tipo string que indica la descripción de la entidad</param>
        ''' <param name="strServicio">Parámetro de tipo string que indica el servicio</param>
        ''' <param name="strMedicoConfirma">Parámetro de tipo string que indica el médico que confirma</param>
        ''' <param name="strCargoMedico">Parámetro de tipo string que indica el cargo del médico que confirma</param>
        ''' <param name="strCodigoAmbulancia">Parámetro de tipo string que indica el código empresa ambulancia</param>
        ''' <param name="strDesAmbulancia">Parámetro de tipo string que indica la descripción empresa ambulancia </param>
        ''' <param name="intNivel">Parámetro de tipo string que indica el nivel</param>
        ''' <param name="strAnamnesis">Parámetro de tipo string que indica resumen anamnesis</param>
        ''' <param name="strAuxiliares">Parámetro de tipo string que indica resumen de auxiliares </param>
        ''' <param name="strDiagnostico">Parámetro de tipo string que indica el resumen del diagnóstico</param>
        ''' <param name="strComplicaciones">Parámetro de tipo string que indica el resumen de las complicaciones </param>
        ''' <param name="strTratamientos ">Parámetro de tipo string que indica el resumen del tratamiento </param>
        ''' <param name="strMotivos">Parámetro de tipo string que indica resumen de motivos</param>
        ''' <param name="strEstadoPaciente">Parámetro de tipo string que indica resumen del estado</param>
        ''' <param name="strFecha">Parámetro de tipo string que indica la fecha </param>
        ''' <param name = "intHora">Parámetro de tipo entero que indica la hora</param>
        ''' <param name = "intMinuto">Parámetro de tipo entero que indica el minuto</param>
        ''' <param name = "strNumeroAutoriza">Parámetro de tipo string que indica el número de la admisión</param>
        ''' <param name = "strFechaAutorizacion">Parámetro de tipo string que indica la fecha de autorización</param>
        ''' <param name = "intHoraAutorizacion">Parámetro de tipo entero que indica la hora de autorización</param>
        ''' <param name = "intMinutoAutorizacion">Parámetro de tipo entero que indica minuto de autorización</param>
        ''' <param name="strEvolucion">Parámetro de tipo string que indica resumen de la evolución</param>
        ''' <returns>long con respuesta de la operación</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas] 12/05/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------

        Public Function GrabarPlanRemision(ByVal objConexion As objCon, ByVal intAction As Integer, ByVal strEntidad As String,
                ByVal strDesEntidad As String, ByVal strServicio As String, ByVal strMedicoConfirma As String,
                ByVal strCargoMedico As String, ByVal strCodigoAmbulancia As String,
                ByVal strDesAmbulancia As String, ByVal intNivel As Integer,
                ByVal strAnamnesis As String, ByVal strAuxiliares As String,
                ByVal strEvolucion As String, ByVal strDiagnostico As String,
                ByVal strComplicaciones As String, ByVal strTratamientos As String,
                ByVal strMotivos As String, ByVal strEstadoPaciente As String,
                ByVal strFecha As String, ByVal intHora As Integer,
                ByVal intMinuto As Integer, ByVal strFechaAnterior As String, ByVal intHoraAnterior As Integer,
                ByVal intMinutoAnterior As Integer, ByVal strNumeroAutoriza As String,
                ByVal strFechaAutorizacion As String, ByVal intHoraAutorizacion As Integer,
                ByVal intMinutoAutorizacion As Integer, ByVal strObs As String, ByVal TrasladoAmb As String) As Long

            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia

            Dim lError As Long

            lError = obj.EjecutarSPConParametrosTran("HC_GrabarRemision", objConexion, intAction,
                                                    objG.Prestador, objG.Sucursal, objP.TipoDocumento,
                                                    objP.NumeroDocumento, strEntidad,
                                                    strServicio, strMedicoConfirma,
                                                    strCargoMedico, strCodigoAmbulancia,
                                                    "RA", "I",
                                                    intNivel, objG.Login, strObs,
                                                    strAnamnesis, strAuxiliares,
                                                    strEvolucion, strDiagnostico,
                                                    strComplicaciones, strTratamientos,
                                                    strMotivos, strEstadoPaciente,
                                                    strFecha, intHora, intMinuto, strFechaAnterior,
                                                    intHoraAnterior, intMinutoAnterior, strNumeroAutoriza,
                                                    strFechaAutorizacion, intHoraAutorizacion, intMinutoAutorizacion,
                                                    objP.TipoAdmision, objP.NumeroAdmision, objP.AnoAdmision, TrasladoAmb, lError)
            Return lError


        End Function

        Public Function GrabarPlanRemisionContrareferencia(ByVal objConexion As objCon,
        ByVal strCodPreSgsOrigen As String, ByVal strCodSucurOrigen As String,
        ByVal strTip_doc As String, ByVal strNum_doc As String,
        ByVal strFechaRemision As String, ByVal intHoraRemision As Integer,
        ByVal intMinRemision As Integer, ByVal strCodpresgs_prac As String,
        ByVal strCodsucur_prac As String, ByVal strTipadmi_prac As String,
        ByVal anoadm_prac As Integer, ByVal numadm_prac As Double,
        ByVal strResultado As String, ByVal strFecResultado As String,
        ByVal strCerrado As String) As Long

            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim fechaRemision As Date
            Dim fechaResultado As Date
            Dim lError As Long

            If strResultado.Trim.Length <= 0 Then
                Return 17
            End If

            fechaRemision = CDate(strFechaRemision)
            fechaResultado = CDate(strFecResultado)

            lError = obj.EjecutarSPConParametrosTran("HC_ActualizarRemisionContrareferencia",
                     objConexion, strCodPreSgsOrigen, strCodSucurOrigen, strTip_doc, strNum_doc,
                     Format(fechaRemision, "yyyy/MM/dd"), intHoraRemision, intMinRemision, strCodpresgs_prac,
                     strCodsucur_prac, strTipadmi_prac, anoadm_prac, numadm_prac, strResultado,
                     Format(fechaResultado, "yyyy/MM/dd"), strCerrado, lError)


            Return lError

        End Function

#End Region

#Region "ConsultarEmpresaAmbulancias"

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Retorna las empresas de ambulancias
        ''' </summary>
        ''' <returns>DataTable con los registros seleccionados</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas]	12/05/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConsultarEmpresaAmbulancia(ByVal objConexion As objCon) As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long

            Return obj.EjecutarSPSinParametros("HC_TraerEmpresaAmbulancia", objConexion, lError)
        End Function

#End Region

#Region "ConsultarNiveles"

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Consultar los niveles (se crea un datatable con las categoría)
        ''' </summary>
        ''' <returns>DataTable con los registros de los niveles</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas]	12/05/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConsultarNiveles() As DataTable
            Dim dtTable As New DataTable
            dtTable.Columns.Add("Nivel", System.Type.GetType("System.String"))
            dtTable.Columns.Add("Descripcion", System.Type.GetType("System.String"))
            Dim dtRow As DataRow = dtTable.NewRow()
            dtRow("Nivel") = "0"
            dtRow("Descripcion") = "ALTO"
            dtTable.Rows.Add(dtRow)
            Dim dtRow1 As DataRow = dtTable.NewRow()
            dtRow1("Nivel") = "1"
            dtRow1("Descripcion") = "MEDIO"
            dtTable.Rows.Add(dtRow1)
            Dim dtRow2 As DataRow = dtTable.NewRow()
            dtRow2("Nivel") = "2"
            dtRow2("Descripcion") = "BAJO"
            dtTable.Rows.Add(dtRow2)
            Return dtTable
        End Function

#End Region

#Region "ConsultarRemision"
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Función que consulta la información de la remisión
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas]	12/05/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConsultarRemision(ByVal objConexion As objCon, ByRef objRem As Sophia.HistoriaClinica.Controles.PlanRemision) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia

            Dim lError As Long
            Dim dtRemision As New DataSet

            dtRemision = obj.EjecutarSPConParametrosDataSet("HC_ConsultarRemision", objConexion,
                                                    lError, objG.Prestador, objG.Sucursal,
                                                    objP.TipoAdmision, objP.AnoAdmision,
                                                    objP.NumeroAdmision, lError)

            If dtRemision.Tables.Count <= 0 Or lError > 0 Then
                Return lError
            End If

            'If dtRemision.Tables(1).Rows.Count > 0 Then
            '    objRem.Evolucion = Trim(dtRemision.Tables(1).Rows(0).Item("strEvolucion").ToString)
            'End If

            If dtRemision.Tables(0).Rows.Count > 0 Then
                With dtRemision.Tables(0).Rows(0)


                    If dtRemision.Tables(0).Rows(0).Item("fec_remision").ToString = "" Then
                        objRem.Estado = ""
                    Else
                        objRem.Estado = "G"
                    End If


                    objRem.CodigoInstitucion = Trim(.Item("strCodigoInstitucion").ToString)
                    objRem.DesInstitucion = Trim(.Item("strDesInstitucion").ToString)
                    objRem.Servicio = Trim(.Item("strServicio").ToString)
                    objRem.MedicoConfirma = Trim(.Item("strMedicoConfirma").ToString)
                    objRem.CargoMedico = Trim(.Item("strCargoMedico").ToString)
                    objRem.DesAmbulancia = Trim(.Item("strDesAmbulancia").ToString)
                    objRem.CodigoAmbulancia = Trim(.Item("strCodigoAmbulancia").ToString)
                    objRem.Nivel = Trim(.Item("strNivel").ToString)
                    objRem.DesNivel = Trim(.Item("strDesNivel").ToString)
                    objRem.Ananmesis = Trim(.Item("strAnanmesis").ToString)
                    objRem.NumeroAutorizacion = Trim(.Item("strNroAutoriza").ToString)
                    objRem.AuxiliarDiagnostico = Trim(.Item("strAuxiliarDiagnostico").ToString)
                    objRem.Diagnostico = Trim(.Item("strDiagnostico").ToString)
                    objRem.Complicaciones = Trim(.Item("strComplicaciones").ToString)
                    objRem.Tratamientos = Trim(.Item("strTratamientos").ToString)
                    objRem.Motivos = Trim(.Item("strMotivos").ToString)
                    objRem.EstadoPaciente = Trim(.Item("strEstadoPaciente").ToString)
                    objRem.FechaAutorizacion = Trim(.Item("strFechaAutoriza").ToString)
                    objRem.HoraAutorizacion = CInt(Trim(.Item("strHoraAutoriza").ToString))
                    objRem.MinutoAutorizacion = CInt(Trim(.Item("strMinutoAutoriza").ToString))
                    objRem.Observaciones = .Item("strObservaciones").ToString
                    objRem.FechaRemision = Trim(.Item("fec_remision").ToString)
                    objRem.HoraRemision = CInt(Trim(.Item("hor_remision").ToString))
                    objRem.MinutoRemision = CInt(Trim(.Item("min_remision").ToString))
                End With
            Else
                objRem.Estado = "N"
            End If

        End Function

        Public Function consultarResumenEvolucion(ByVal objConexion As objCon, ByRef objRem As Sophia.HistoriaClinica.Controles.PlanRemision) As Long

            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia

            Dim lError As Long
            Dim dtResumen As New DataSet

            dtResumen = obj.EjecutarSPConParametrosDataSet("HC_ConsultarResumenEvolucion", objConexion,
                                                    lError, objG.Prestador, objG.Sucursal,
                                                    objP.TipoAdmision, objP.AnoAdmision,
                                                    objP.NumeroAdmision, lError)

            If dtResumen.Tables.Count <= 0 Or lError > 0 Then
                Return lError
            End If

            If dtResumen.Tables(0).Rows.Count > 0 Then
                objRem.Evolucion = Trim(dtResumen.Tables(0).Rows(0).Item("strEvolucion").ToString)
            End If

            Return 0

        End Function

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Función que consulta la información de la remisión y la graba en un objeto
        ''' para poderlo imprimir
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas]	12/05/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Shared Function ConsultarRemision(ByVal objConexion As objCon, ByVal Prestador As String, ByVal Sucursal As String,
                                                 ByVal TipoAdmision As String, ByVal AnoAdmision As String, ByVal NumeroAdmision As String,
                                                 ByRef objReporte As Sophia.HistoriaClinica.Reportes.RemisionPlanManejo) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral

            Dim lError As Long
            Dim dtRemision As New DataSet

            dtRemision = obj.EjecutarSPConParametrosDataSet("HC_ConsultarRemision", objConexion,
                                                    lError, Prestador, Sucursal,
                                                    TipoAdmision, AnoAdmision,
                                                    NumeroAdmision, lError)
            If dtRemision.Tables.Count <= 0 Or lError > 0 Then
                Return lError
            End If

            If dtRemision.Tables(0).Rows.Count > 0 Then
                objReporte.Evolucion = Trim(dtRemision.Tables(0).Rows(0).Item("strEvolucion").ToString)
            End If

            If dtRemision.Tables(0).Rows.Count > 0 Then
                With dtRemision.Tables(0).Rows(0)
                    objReporte.DesInstitucion = Trim(.Item("strDesInstitucion").ToString)
                    objReporte.Servicio = Trim(.Item("strServicio").ToString)
                    objReporte.MedicoConfirma = Trim(.Item("strMedicoConfirma").ToString)
                    objReporte.CargoMedico = Trim(.Item("strCargoMedico").ToString)
                    objReporte.DesAmbulancia = Trim(.Item("strDesAmbulancia").ToString)
                    objReporte.DesNivel = Trim(.Item("strDesNivel").ToString)
                    objReporte.Ananmesis = Trim(.Item("strAnanmesis").ToString)
                    objReporte.NumeroAutoriza = Trim(.Item("strNroAutoriza").ToString)
                    objReporte.AuxiliarDiagnostico = Trim(.Item("strAuxiliarDiagnostico").ToString)
                    objReporte.Diagnostico = Trim(.Item("strDiagnostico").ToString)
                    objReporte.Complicaciones = Trim(.Item("strComplicaciones").ToString)
                    objReporte.Tratamientos = Trim(.Item("strTratamientos").ToString)
                    objReporte.Motivos = Trim(.Item("strMotivos").ToString)
                    objReporte.EstadoPaciente = Trim(.Item("strEstadoPaciente").ToString)
                    objReporte.FechaAutoriza = Trim(.Item("strFechaAutoriza").ToString)
                    objReporte.HoraAutoriza = CInt(Trim(.Item("strHoraAutoriza").ToString))
                    objReporte.MinutoAutoriza = CInt(Trim(.Item("strMinutoAutoriza").ToString))
                    objReporte.Observaciones = .Item("strObservaciones").ToString
                End With
            End If

        End Function
#End Region

#Region "ConsultarIncapacidad"
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Función que consulta la información de la incapacidad
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas]	14/06/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConsultarIncapacidad(ByVal objConexion As objCon, ByRef objIncap As Sophia.HistoriaClinica.Controles.PlanIncapacidad) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia

            Dim lError As Long
            Dim dtIncapacidad As New DataTable

            dtIncapacidad = obj.EjecutarSPConParametros("HC_ConsultarIncapacidad", objConexion,
                                                    lError, objG.Prestador, objG.Sucursal,
                                                    objP.TipoAdmision, objP.AnoAdmision,
                                                    objP.NumeroAdmision, lError)
            If dtIncapacidad.Rows.Count <= 0 Or lError > 0 Then
                Exit Function
            Else
                If dtIncapacidad.Rows(0).Item("CodigoDiagnostico").ToString.Trim.Length = 0 Then
                    Exit Function
                End If
                With dtIncapacidad.Rows(0)
                    objIncap.Estado = "G"
                    objIncap.CodigoDiagnostico = Trim(.Item("CodigoDiagnostico").ToString)
                    If Trim(.Item("NumeroDias").ToString).Length > 0 Then
                        objIncap.Cantidad = Trim(.Item("NumeroDias").ToString)
                    End If
                    objIncap.Diagnostico = Trim(.Item("Diagnostico").ToString)
                    objIncap.FechaFinal = Trim(.Item("FechaFinal").ToString)
                    objIncap.FechaInicial = Trim(.Item("FechaInicial").ToString)
                    objIncap.Observacion = Trim(.Item("Observaciones").ToString)
                End With
            End If

        End Function

        Public Shared Function ConsultarIncapacidad(ByVal objConexion As objCon, ByRef incapacidadReporte As Sophia.HistoriaClinica.Reportes.Incapacidad,
        ByVal strPrestador As String, ByVal strSucursal As String, ByVal strTipoAdmision As String, ByVal IntAnoAdmision As Integer, ByVal LNumeroAdmision As Long) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia

            Dim lError As Long
            Dim dtIncapacidad As New DataTable

            ''cpgaray se corrige el envio de parametros para que no tome los parametros del objeto sino los que vienen en la función. Febrero 18 de 2013

            dtIncapacidad = obj.EjecutarSPConParametros("HC_ConsultarIncapacidad", objConexion,
                                                    lError, strPrestador, strSucursal,
                                                    strTipoAdmision, IntAnoAdmision,
                                                    LNumeroAdmision, lError)
            If dtIncapacidad.Rows.Count <= 0 Or lError > 0 Then
                Return lError
            Else

                With dtIncapacidad.Rows(0)
                    If Trim(.Item("NumeroDias").ToString).Length > 0 Then
                        incapacidadReporte.Dias = Trim(.Item("NumeroDias").ToString)
                    End If
                    incapacidadReporte.Diagnostico = Trim(.Item("Diagnostico").ToString)
                    incapacidadReporte.FechaFinal = Trim(.Item("FechaFinal").ToString)
                    incapacidadReporte.FechaInicial = Trim(.Item("FechaInicial").ToString)
                    incapacidadReporte.Observaciones = Trim(.Item("Observaciones").ToString)
                    incapacidadReporte.Especialidad = Trim(.Item("Especialidad").ToString)
                    incapacidadReporte.MedicoIncapacidad = Trim(.Item("Medico").ToString)
                End With
            End If

        End Function
#End Region

#Region "ConsultarRecomendacionEgreso"
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Función que consulta la información de las Recomendaciones al Egreso
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas]	14/06/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConsultarRecomendacionEgreso(ByVal objConexion As objCon, ByRef objRecomendacion As Sophia.HistoriaClinica.Controles.RecomEgreso) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia

            Dim lError As Long
            Dim dtRecomendacion As New DataTable


            dtRecomendacion = obj.EjecutarSPConParametros("HC_ConsultarRecomendacionEgreso", objConexion,
                                                    lError, objG.Prestador, objG.Sucursal,
                                                    objP.TipoAdmision, objP.AnoAdmision,
                                                    objP.NumeroAdmision, lError)
            If dtRecomendacion.Rows.Count <= 0 Or lError > 0 Then
                Exit Function
            Else

                With dtRecomendacion.Rows(0)
                    objRecomendacion.Estado = "G"
                    objRecomendacion.ActividadFisica = Trim(.Item("ActividadFisica").ToString)
                    objRecomendacion.FechaControl = Trim(.Item("FechaControl").ToString)
                    objRecomendacion.LugarControl = Trim(.Item("LugarControl").ToString)
                    objRecomendacion.RecomendacionGeneral = Trim(.Item("RecomendacionGeneral").ToString)
                    objRecomendacion.RecomendacionNutricional = Trim(.Item("RecomendacionNutricional").ToString)
                    objRecomendacion.ResultadoDiagnostico = Trim(.Item("ResultadoDiagnostico").ToString)
                    objRecomendacion.SignoCalor = IIf(Trim(.Item("SignoColorHerida").ToString) = "S", True, False)
                    objRecomendacion.SignoEnrojecimiento = IIf(Trim(.Item("SignoEnrojecimiento").ToString) = "S", True, False)
                    objRecomendacion.SignoFiebre = IIf(Trim(.Item("signoFiebre").ToString) = "S", True, False)
                    objRecomendacion.SignosAlarma = Trim(.Item("SignosAlarma").ToString)
                    objRecomendacion.SignoSecrecion = IIf(Trim(.Item("SignoSecrecion").ToString) = "S", True, False)
                    objRecomendacion.TelefonoMedico = Trim(.Item("TelefonoMedico").ToString)
                    objRecomendacion.Incapacidad = Val(.Item("Incapacidad").ToString())
                    objRecomendacion.ConciliacionMedicamentos = IIf(IsDBNull(.Item("con_med").ToString()), "", .Item("con_med").ToString()) ''cpgaray
                End With
            End If

        End Function
#End Region

#Region "ConsultarFormulaCronicaActiva"

        Public Shared Function consultarFormulaCronicaActiva(ByVal objConexion As objCon, ByVal strTipDoc As String,
                                                             ByVal strNumDoc As String) As DataTable

            Dim objGeneral As New Sophia.HistoriaClinica.DAO.DAOGeneral

            Return objGeneral.EjecutarSPConParametros("HC_TraerFormulaCronicaActiva", objConexion, -1,
                                                      strTipDoc, strNumDoc)

        End Function

#End Region

#Region "TieneConvenioUnMedicamento"
        Public Shared Function medicamentoTieneConvenio(ByVal objconexion As objCon, ByVal codProducto As String, ByVal cod_pre_sgs As String, ByVal cod_sucur As String,
                                                        ByVal entidad As String) As Boolean
            Dim daoManage As New Sophia.HistoriaClinica.DAO.DAOPlanManejo()

            Return daoManage.consultarConvenioMedicamento(objconexion, codProducto, cod_pre_sgs, cod_sucur, entidad)

        End Function
#End Region

#Region "Consulta Procedimientos por Paciente"

        Public Shared Function traerProcedimientosXPaciente(ByVal objConexion As objCon,
                               ByVal strCerrado As String, ByVal strMedico As String) As DataTable

            Dim lError As Long
            Dim dtProcedim As DataTable
            Dim objDatosPaciente As objPaciente = objPaciente.Instancia
            Dim objDAO As New Sophia.HistoriaClinica.DAO.DAOGeneral

            dtProcedim = objDAO.EjecutarSPConParametros("HC_TraerProcedimientos", objConexion,
                         lError, objDatosPaciente.TipoDocumento, objDatosPaciente.NumeroDocumento,
                         strCerrado, strMedico, lError)

            Return dtProcedim

        End Function

#End Region

#Region "Consulta Remisiones por Paciente"

        Public Shared Function traerRemisionesXPaciente(ByVal objConexion As objCon,
                               ByVal strCerrado As String, ByVal strMedico As String) As DataTable

            Dim lError As Long
            Dim dtProcedim As DataTable
            Dim objDatosPaciente As objPaciente = objPaciente.Instancia
            Dim objDAO As New Sophia.HistoriaClinica.DAO.DAOGeneral

            dtProcedim = objDAO.EjecutarSPConParametros("HC_TraerRemisiones", objConexion,
                         lError, objDatosPaciente.TipoDocumento, objDatosPaciente.NumeroDocumento,
                         strCerrado, strMedico, lError)

            Return dtProcedim

        End Function

        Public Shared Sub cargarObjetoRemision(ByVal dtdatosRemision As DataTable)

        End Sub

#End Region
        'hrariza@ CU05
        'Inicio
#Region "Consultar Tabla Informativa"
        Public Function ConsultarTblInformativa(ByVal objConexion As objCon, ByRef objTblInformativa As DataSet) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia

            Dim lError As Long
            Dim dtsTblInformativa As New DataSet
            Dim dtTblInformativa As New DataTable
            Dim dtNroFormulasMedEndo As New DataTable


            dtsTblInformativa = obj.EjecutarSPConParametrosDataSet("HC_ConsultarOrdenesMedInf_Alternativa_CQ", objConexion,
                                        -1, objG.Prestador, objG.Sucursal,
                                        objP.TipoAdmision, objP.AnoAdmision,
                                        objP.NumeroAdmision, objP.TipoDocumento, objP.NumeroDocumento)
            If lError > 0 Then
                Return lError
            Else
                'dtTblInformativa = dtsTblInformativa.Tables(0)
                objTblInformativa = dtsTblInformativa
                'With dtTblInformativa
                '.Columns.Add("entidad_ant", System.Type.GetType("System.String"))
                '.Columns.Add("producto_ant", System.Type.GetType("System.String"))
                '.Columns.Add("prescripcion_ant", System.Type.GetType("System.String"))
                '.Columns.Add("cantidad_ant", System.Type.GetType("System.Int32"))
                '.Columns.Add("cantidadDispensacion_ant", System.Type.GetType("System.Int32"))
                '.Columns.Add("cronico_ant", System.Type.GetType("System.String"))
                '.Columns.Add("duraciontrat_ant", System.Type.GetType("System.Int32"))
                '.Columns.Add("obs_ant", System.Type.GetType("System.String"))
                '.Columns.Add("adicionado", System.Type.GetType("System.String"))
                'End With

                ' dtTblInformativa = dtsTblInformativa.Tables(0)
                'objTblInformativa.dtFormulacion = dtTblInformativa

                ' .dtNroFormulas = dtNroFormulas
                '.Estado = "G"
                'If dtNroFormulas.Rows.Count > 0 Then
                '.ObservacionesFormula = dtNroFormulas.Rows(0).Item("obs").ToString
                'End If
                'End With

            End If

            Return 0

        End Function
#End Region
        'Fin

#Region "Consulta Formulación Externa"
        Public Function ConsultarFormulacion(ByVal objConexion As objCon, ByRef objFormulas As Sophia.HistoriaClinica.Controles.PlanFormuExterna) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia

            Dim lError As Long
            Dim dtsFormulas As New DataSet
            Dim dtFormulas As New DataTable
            Dim dtNroFormulas As New DataTable

            dtsFormulas = obj.EjecutarSPConParametrosDataSet("HC_ConsultarOrdenesMedicamentos_CQ", objConexion,
                                        -1, objG.Prestador, objG.Sucursal,
                                        objP.TipoAdmision, objP.AnoAdmision,
                                        objP.NumeroAdmision)


            If lError > 0 Then
                Return lError
            Else
                dtFormulas = dtsFormulas.Tables(0)
                dtNroFormulas = dtsFormulas.Tables(1)
                With dtFormulas
                    .Columns.Add("entidad_ant", System.Type.GetType("System.String"))
                    .Columns.Add("producto_ant", System.Type.GetType("System.String"))
                    .Columns.Add("prescripcion_ant", System.Type.GetType("System.String"))
                    .Columns.Add("cantidad_ant", System.Type.GetType("System.String"))
                    .Columns.Add("cantidadDispensacion_ant", System.Type.GetType("System.String"))
                    .Columns.Add("cronico_ant", System.Type.GetType("System.String"))
                    .Columns.Add("duraciontrat_ant", System.Type.GetType("System.Int32"))
                    .Columns.Add("obs_ant", System.Type.GetType("System.String"))
                    .Columns.Add("adicionado", System.Type.GetType("System.String"))
                End With

                dtFormulas.DefaultView.Sort = "nro_formula"
                dtNroFormulas.Columns.Add("posic", System.Type.GetType("System.Int32"))
                dtNroFormulas.DefaultView.Sort = "posic, nro_formula"
                With objFormulas
                    .dtFormulacion = dtFormulas
                    .dtNroFormulas = dtNroFormulas
                    .Estado = "G"
                    If dtNroFormulas.Rows.Count > 0 Then
                        .ObservacionesFormula = dtNroFormulas.Rows(0).Item("obs").ToString
                    End If
                End With
            End If

            Return 0

        End Function
        Public Function ConsultarDiasTratOsi(ByVal objConexion As objCon, ByRef DiaTraMin As Integer, ByRef DiaTraMax As Integer, ByVal DiasEntiad As String) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOPlanManejo
            Dim objG As objGeneral = objGeneral.Instancia

            Dim lError As Long
            Dim dtDiasTrat As New DataTable

            dtDiasTrat = obj.EjecutarSPConsultarDiasTratOsi(objConexion, DiasEntiad)

            If dtDiasTrat.Rows.count > 0 Then
                DiaTraMin = dtDiasTrat.Rows(0).Item("DiasTraMin").ToString
                DiaTraMax = dtDiasTrat.Rows(0).Item("DiasTraMax").ToString
            End If

            Return lError

        End Function

#End Region

#Region "Consulta Formulación Cronico"

        Public Shared Function consultarFormulaCronica(ByVal objConexion As objCon, ByVal strTipDoc As String,
                                                             ByVal strNumDoc As String) As DataTable

            Dim objGeneral As New Sophia.HistoriaClinica.DAO.DAOGeneral

            Return objGeneral.EjecutarSPConParametros("HC_ConsultarOrdenesMedicamentosCronicos", objConexion, -1,
                                                      strTipDoc, strNumDoc)

        End Function

#End Region


#Region "Consulta Evolucion"
        Public Function ConsultarEvolucion(ByVal objConexion As objCon, ByRef evolucion As Sophia.HistoriaClinica.Controles.Evolucion) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia

            Dim lError As Long
            Dim dtsEvolucion As New DataSet
            Dim dtEvolucion As New DataTable

            dtsEvolucion = obj.EjecutarSPConParametrosDataSet("HC_ConsultarEvolucion", objConexion,
                                        -1, objG.Prestador, objG.Sucursal,
                                        objP.TipoAdmision, objP.AnoAdmision,
                                        objP.NumeroAdmision)


            If lError > 0 Then
                Return lError
            Else
                dtEvolucion = dtsEvolucion.Tables(0)
                'ctlEvolucion.Instancia.dtgEvolucion.DataSource = dtEvolucion
                'dtsEvolucion = Nothing
            End If

            Return 0

        End Function
#End Region
        ''Claudia Garay Marzo 1 de 2012
        Public Shared Function ConsultarEvolucion(ByVal objConexion As objCon) As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia


            Dim dtsEvolucion As New DataSet
            Dim dtEvolucion As New DataTable

            dtsEvolucion = obj.EjecutarSPConParametrosDataSet("HC_ConsultarEvolucion", objConexion,
                                        -1, objG.Prestador, objG.Sucursal,
                                        objP.TipoAdmision, objP.AnoAdmision,
                                        objP.NumeroAdmision)



            dtEvolucion = dtsEvolucion.Tables(0)


            Return dtEvolucion

        End Function
        ''Claudia Garay. Acreditacion 9 de diciembre
        Public Shared Function consultarProgramasEdu(ByVal objConexion As objCon) As DataTable
            Dim DaoGen As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Return DaoGen.consultarProgramasEduc(objConexion)
        End Function

        Public Function TraeProgramasEducacion(ByVal objConexion As objCon, ByVal strCod_pre_sgs As String, ByVal strCod_sucur As String, ByVal strTipAdm As String,
        ByVal intAnoAdm As Integer, ByVal LNumAdm As Decimal, ByVal CodPrograma As String, ByVal strLogin As String, ByVal strObs As String, ByVal Intaccion As Integer) As DataTable

            Dim DaoPlan As New Sophia.HistoriaClinica.DAO.DAOPlanManejo
            Return DaoPlan.ProgramasEducacionRE(objConexion, strCod_pre_sgs, strCod_sucur, strTipAdm, intAnoAdm, LNumAdm, CodPrograma, strLogin, strObs, Intaccion)
        End Function
        Public Function Consultausuariosseccion(ByVal cod_pre_sgs As String, ByVal cod_sucur As String, ByVal tip_admision As String _
                                               , ByVal num_adm As Int64, ByVal ano_adm As Integer, ByVal strmodulo As String,
                                               ByVal FechainicioSesion As DateTime) As String

            Dim obj As New Sophia.HistoriaClinica.DAO.DAOOrdenes
            Dim Flag As String
            Flag = obj.Consultausuariosseccion(cod_pre_sgs, cod_sucur, tip_admision, num_adm, ano_adm, strmodulo, FechainicioSesion)
            Return Flag

        End Function
    End Class

#End Region
End Namespace

