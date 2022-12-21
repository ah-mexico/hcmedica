Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.HistoriaBasica

Namespace Sophia.HistoriaClinica.BL

#Region "BLEgresos"
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

    Public Class BLEgresos
#Region "Métodos BLEgresos"

#Region "ConsultarEgresosPaciente"
      
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Retorna los tipos de Diagnósticos
        ''' </summary>
        ''' <returns>DataTable con los registros seleccionados</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas]	31/03/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConsultarTiposDiagnostico() As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOEgresos

            Return obj.ConsultarTiposDiagnostico()

        End Function
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Retorna las categorías
        ''' </summary>
        ''' <returns>DataTable con los registros seleccionados</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas]	31/03/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConsultarCategorias() As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOEgresos

            Return obj.ConsultarCategorias

        End Function

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Retorna las causas externas
        ''' </summary>
        ''' <returns>DataTable con los registros seleccionados</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas]	31/03/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConsultarCausasExternas() As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOEgresos
            Return obj.ConsultarCausasExternas()

        End Function

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Retorna las condiciones de los usuarios
        ''' </summary>
        ''' <returns>DataTable con los registros seleccionados</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas]	31/03/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConsultarCondicionUsuario() As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOEgresos

            Return obj.ConsultarCondicionUsuario

        End Function

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Retorna los tipos de discapacidad
        ''' </summary>
        ''' <returns>DataTable con los registros seleccionados</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas]	31/03/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConsultarTiposDiscapacidad() As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOEgresos

            Return obj.ConsultarTiposDiscapacidad

        End Function

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Retorna los grados de discapacidad
        ''' </summary>
        ''' <returns>DataTable con los registros seleccionados</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas]	31/03/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConsultarGradosDiscapacidad() As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOEgresos

            Return obj.ConsultarGradosDiscapacidad

        End Function

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Retorna los destinos finales
        ''' </summary>
        ''' <returns>DataTable con los registros seleccionados</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas]	31/03/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConsultarDestinoFinal() As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOEgresos
            Return obj.ConsultarDestinoFinal

        End Function

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Consultar los diagnóstico cuando es un reingreso (procedimiento DB_TraerHistoriaImpresionDx)
        ''' </summary>
        ''' <param name="strCod_pre_sgs">Parámetro de tipo string que indica el código del prestador</param>
        ''' <param name="strCod_sucur">Parámetro de tipo string que indica el código de la sucursal</param>
        ''' <param name="strTip_Admision">Parámetro de tipo string que indica el tipo de admisión</param>
        ''' <param name="lano_adm">Parámetro de tipo integer que indica el año de admisión</param>
        ''' <param name="dnum_adm">Parámetro de tipo long que indica el número de la admisión</param>
        ''' <param name="strClase_Diag">Parámetro de tipo string que indica la clase de diagnóstico</param>
        ''' <param name="strLogin">Parámetro de tipo string indica el login</param>
        ''' <returns>DataTable con los registros para los diagnósticos</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas] 20/04/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConsultarDiagnosticoReingreso(ByVal strCod_pre_sgs As String, ByVal strCod_Sucur As String, _
                                                     ByVal strTip_Admision As String, ByVal lano_adm As Long, _
                                                     ByVal dnum_adm As Long, ByVal strClase_Diag As String, _
                                                     ByVal strLogin As String, ByVal objConexion As objCon) As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long

            Return obj.EjecutarSPConParametros("HC_TraerHistoriaImpresionDx", objConexion, lError, strCod_pre_sgs, strCod_Sucur, _
                                 strTip_Admision, lano_adm, dnum_adm, strClase_Diag, strLogin, lError)

        End Function

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Consultar los diagnóstico cuando es un reingreso (procedimiento DB_TraerHistoriaImpresionDx)
        ''' </summary>
        ''' <param name="strCod_pre_sgs">Parámetro de tipo string que indica el código del prestador</param>
        ''' <param name="strCod_sucur">Parámetro de tipo string que indica el código de la sucursal</param>
        ''' <param name="strTip_Admision">Parámetro de tipo string que indica el tipo de admisión</param>
        ''' <param name="lano_adm">Parámetro de tipo integer que indica el año de admisión</param>
        ''' <param name="dnum_adm">Parámetro de tipo long que indica el número de la admisión</param>
        ''' <param name="strClase_Diag">Parámetro de tipo string que indica la clase de diagnóstico</param>
        ''' <param name="strLogin">Parámetro de tipo string indica el login</param>
        ''' <returns>DataTable con los registros para los diagnósticos</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas] 20/04/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConsultarDiagnosticoReingreso_evo(ByVal strCod_pre_sgs As String, ByVal strCod_Sucur As String, _
                                                     ByVal strTip_Admision As String, ByVal lano_adm As Long, _
                                                     ByVal dnum_adm As Long, ByVal strClase_Diag As String, _
                                                     ByVal strLogin As String, ByVal objConexion As objCon) As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long

            Return obj.EjecutarSPConParametros("HC_TraerHistoriaImpresionDx_evo", objConexion, lError, strCod_pre_sgs, strCod_Sucur, _
                                 strTip_Admision, lano_adm, dnum_adm, strClase_Diag, strLogin, lError)

        End Function

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Consultar los datos del egreso cuando es un reingreso (procedimiento DB_TraerHistoriaImpresionDxEgreso)
        ''' </summary>
        ''' <param name="strCod_pre_sgs">Parámetro de tipo string que indica el código del prestador</param>
        ''' <param name="strCod_sucur">Parámetro de tipo string que indica el código de la sucursal</param>
        ''' <param name="strTip_Admision">Parámetro de tipo string que indica el tipo de admisión</param>
        ''' <param name="lano_adm">Parámetro de tipo integer que indica el año de admisión</param>
        ''' <param name="dnum_adm">Parámetro de tipo long que indica el número de la admisión</param>
        ''' <returns>DataTable con los registros para los diagnósticos</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas] 20/04/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ConsultarDatoEgresoReingreso(ByVal strCod_pre_sgs As String, ByVal strCod_Sucur As String, _
                                                     ByVal strTip_Admision As String, ByVal lano_adm As Long, _
                                                     ByVal dnum_adm As Long, ByVal objConexion As objCon) As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long

            Return obj.EjecutarSPConParametros("HC_TraerHistoriaImpresionDxEgreso", objConexion, lError, strCod_pre_sgs, strCod_Sucur, _
                                 strTip_Admision, lano_adm, dnum_adm, lError)

        End Function

        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Proceso de grabar datos del egreso (procedimiento pa_BusHC_GrabarTransaccionEgreso)
        ''' </summary>
        ''' <param name="intAccion">Parámetro de tipo integer que indica la acción</param>
        ''' <param name="dtDiagnosticos">Parámetro de tipo datatable que contiene los registros de los diagnóstico</param>
        ''' <param name="objConexion">Parámetro de tipo objConexión</param>
        ''' <param name="strEstadoSalida">Parámetro de tipo string que indica el estado de a la salida</param>
        ''' <param name="strCausaMuerte">Parámetro de tipo string que indica la causa de muerte</param>
        ''' <param name="strResumenEvolucion">Parámetro de tipo string que indica el resumen de la evolución</param>
        ''' <param name="strDestinoFinal">Parámetro de tipo string que indica el destino final</param>
        ''' <param name="strFechaEgreso">Parámetro de tipo string que indica la fecha del egreso</param>
        ''' <param name="intHoraEgreso">Parámetro de tipo entero que indica la hora del egreso</param>
        ''' <param name="intMinutoEgreso">Parámetro de tipo entero que indica el minuto del egreso</param>
        ''' <returns>string con respuesta de la transacción</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas] 22/04/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function GrabarEgreso(ByVal intAccion As Integer, ByVal dtDiagnosticos As DataTable, _
                        ByVal objConexion As objCon, ByVal strEstadoSalida As String, _
                        ByVal strCausaMuerte As String, ByVal strResumenEvolucion As String, _
                        ByVal strDestinoFinal As String, ByVal strFechaEgreso As String, _
                        ByVal intHoraEgreso As Integer, ByVal intMinutoEgreso As Integer) As Long
            'Dim obj As New Sophia.HistoriaClinica.DAO.DAOEgresos
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral

            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia

            Dim xmlDiagnostico As String = ""

            Dim lError As Long


            xmlDiagnostico = FuncionesGenerales.GenerarXMLxProcedimiento(dtDiagnosticos)
            'xmlDatosEgreso = objGenerales.GenerarXMLxProcedimiento(dtDatosEgreso)

            lError = obj.EjecutarSPConParametrosTran("HC_GrabarEgreso", objConexion, intAccion, _
                                                    objG.Prestador, objG.Sucursal, _
                                                    objP.TipoDocumento, objP.NumeroDocumento, _
                                                    objP.TipoAdmision, objP.AnoAdmision, _
                                                    objP.NumeroAdmision, "E", _
                                                    objG.Login, xmlDiagnostico, _
                                                    strEstadoSalida, strCausaMuerte, _
                                                    strDestinoFinal, strResumenEvolucion, _
                                                    strFechaEgreso, intHoraEgreso, intMinutoEgreso, lError)

            Return lError

        End Function

        
      
#End Region

#Region "SalidaHistoriaClinica"

        ''' <summary>
        ''' Enumeracion que clasifica las configuraciones de los botones que 
        ''' se muestran al usuario cuando este intenta salir de la historia clinica
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum configuracionOpciones
            CerrarCancelar          ''Muestra el boton cerrar Historia y Cancelar
            CerrarObservaCancelar   ''Muestra el boton cerrar Historia, Observacion y cancelar
            ObservacionCancelar     ''Muestra el boton observacion y cancelar
            PendienteCancelar       ''Muestra el boton pendiente y cancelar
            Cancelar                ''Muestra el boton cancelar
            CerrarHistoriaAdmision  ''Muestra el boton cerrar historia, cerrar historia y admision y Cancelar
        End Enum

        ''' <summary>
        ''' Enumeración que representa la opcion elegida por el usuario cuando 
        ''' intenta salir de la historia clinica
        ''' </summary>
        ''' <remarks></remarks>
        Public Enum OpcionSalida
            CerrarHistoria = 1  ''Cerrar la historia clinica
            Observacion = 2     ''Deja la historia clinica en observacion
            Pendiente = 3       ''Deja la historia clinica pendiente
            Cancelar = 4        ''Cancela la salida de la historia clinica y no permite salir

        End Enum

        Public Enum CondicionesObligatorias
            MotivoConsulta = 1
            EstadoDeConciencia = 2
            Ninguna = 3
            DiagnosticoImpresionDiagnostica = 4
        End Enum


        Public Shared Function cumpleCondicionesObligatoriasDeSalida(ByVal objConexion As objCon, ByVal strCod_pre_sgs As String, ByVal strcod_sucur As String, _
                                                                     ByRef condicionIncumple As CondicionesObligatorias, Optional ByRef mensaje As String = "") As Boolean
            Dim dsConsulta As DataSet
            Dim dtTabla As DataTable
            Dim cumpleCondiciones As Boolean
            Dim pacienteHC As objPaciente
            Dim i As Integer

            pacienteHC = objPaciente.Instancia()
            dsConsulta = DAOEgresos.consultarCondicionesObligatoriasDeSalida(objConexion, strCod_pre_sgs, strcod_sucur, pacienteHC.TipoAdmision, _
                                                                             pacienteHC.AnoAdmision, pacienteHC.NumeroAdmision)
            If dsConsulta.Tables.Count <= 0 Then
                Return False
            End If

            mensaje = ""
            cumpleCondiciones = True
            condicionIncumple = CondicionesObligatorias.Ninguna

            For i = 0 To dsConsulta.Tables.Count - 1
                dtTabla = dsConsulta.Tables(i)

                ''Se selecciona la condicion de salida a evaluar (Tabla de la que se hizo la consulta)
                Select Case i
                    Case 0
                        If dtTabla.Rows.Count <= 0 Then
                            mensaje += vbNewLine & "- Causa externa, motivo de consulta, información suministrada por y enfermedad actual."
                            If condicionIncumple = CondicionesObligatorias.Ninguna Then
                                condicionIncumple = CondicionesObligatorias.MotivoConsulta
                            End If
                            cumpleCondiciones = False
                            Exit Select
                        End If

                        If dtTabla.Rows(0).Item("Inf_SumPor").ToString.Trim.Length <= 0 Then
                            mensaje += vbNewLine & "- El campo Información suministrada por. "
                            If condicionIncumple = CondicionesObligatorias.Ninguna Then
                                condicionIncumple = CondicionesObligatorias.MotivoConsulta
                            End If
                            cumpleCondiciones = False
                        End If

                        If dtTabla.Rows(0).Item("mot_consulta").ToString.Trim.Length <= 0 Then
                            mensaje += vbNewLine & "- El motivo de la consulta. "
                            If condicionIncumple = CondicionesObligatorias.Ninguna Then
                                condicionIncumple = CondicionesObligatorias.MotivoConsulta
                            End If
                            cumpleCondiciones = False
                        End If

                        If dtTabla.Rows(0).Item("Enf_actual").ToString.Trim.Length <= 0 Then
                            mensaje += vbNewLine & "- La información de la enfermedad actual. "
                            If condicionIncumple = CondicionesObligatorias.Ninguna Then
                                condicionIncumple = CondicionesObligatorias.MotivoConsulta
                            End If
                            cumpleCondiciones = False
                        End If
                    Case 1
                        If dtTabla.Rows.Count <= 0 Then
                            If pacienteHC.TipoAdmision = objPaciente.URGENCIAS Then
                                mensaje += vbNewLine & "- El estado de conciencia. "
                                If condicionIncumple = CondicionesObligatorias.Ninguna Then
                                    condicionIncumple = CondicionesObligatorias.EstadoDeConciencia
                                End If
                                cumpleCondiciones = False
                            End If
                            Exit Select
                        End If

                        If dtTabla.Rows(0).Item("alerta").ToString.Trim.Length <= 0 And pacienteHC.TipoAdmision = objPaciente.URGENCIAS Then
                            mensaje += vbNewLine & "- El estado de conciencia. "
                            If condicionIncumple = CondicionesObligatorias.Ninguna Then
                                condicionIncumple = CondicionesObligatorias.EstadoDeConciencia
                            End If
                            cumpleCondiciones = False
                        End If

                    Case 2

                        If dtTabla.Rows.Count <= 0 And pacienteHC.TipoHistoria <> "E" Then
                            mensaje += vbNewLine & "- Por lo menos un diagnóstico en la Impresión Diagnóstica."
                            If condicionIncumple = CondicionesObligatorias.Ninguna Then
                                condicionIncumple = CondicionesObligatorias.DiagnosticoImpresionDiagnostica
                            End If
                            cumpleCondiciones = False
                            Exit Select
                        End If
                End Select
            Next

            Return cumpleCondiciones

        End Function
        ''' <summary>
        ''' Funcion que consulta si se cumplen las condiciones de salida de la 
        ''' historia clinica: Grabacion de diagnostico principal (Para tipos de 
        ''' admision E y P valida diagnosticos de ingreso, para admisiones A, U y H se 
        ''' valida diagnosticos de egreso), grabacion de causa externa y 
        ''' registro de recomendaciones al egreso.
        ''' Ademas consulta el estado de la historia clinica
        ''' </summary>
        ''' <param name="objConexion">Datos de la conexion a la bd</param>
        ''' <param name="strCod_pre_sgs">Codigo prestador</param>
        ''' <param name="strcod_sucur">Codigo sucursal</param>
        ''' <param name="strTip_admision">Tipo de admision</param>
        ''' <param name="strAno_adm">Año de admision</param>
        ''' <param name="strNum_Adm">Numero de admision</param>
        ''' <param name="estado">Variable en la que se devuelve el estado de la historia</param>
        ''' <returns>Booleano que indica si cumple o no las condiciones de salida</returns>
        ''' <remarks></remarks>
        Public Shared Function cumpleCondicionesEgreso(ByVal objConexion As objCon, ByVal strCod_pre_sgs As String, ByVal strcod_sucur As String, _
                                                            ByVal strTip_admision As String, ByVal strAno_adm As String, _
                                                            ByVal strNum_Adm As String, ByRef estado As String, _
                                                            Optional ByRef mensaje As String = "") As Boolean
            Dim dsConsulta As DataSet
            Dim dtTabla As DataTable
            Dim resumenEvolucion As String = ""
            Dim i As Integer

            dsConsulta = DAOEgresos.consultarCondicionesEgreso(objConexion, strCod_pre_sgs, strcod_sucur, strTip_admision, strAno_adm, strNum_Adm)

            ''Si la consulta no arroja resultados 
            If dsConsulta.Tables.Count <= 0 Then
                estado = ""
                Return False
            End If

            ''se atrapa el estado de la historia clinica
            If dsConsulta.Tables(0).Rows.Count > 0 Then
                estado = dsConsulta.Tables(0).Rows(0).Item("estado").ToString
            Else
                estado = ""
            End If

            ''Se evalua que las condiciones sea cumplidas, o sea que se haya
            ''grabado diagnostico pricipal, causa externa y recomendaciones
            For i = 0 To dsConsulta.Tables.Count - 1
                'If dtTabla.Rows.Count <= 0 Then
                '    Return False
                'End If
                dtTabla = dsConsulta.Tables(i)

                Select Case i
                    'HCENCABEZADO : VALIDA CAUSA EXTERNA Y EL RESUMEN DE EVOLUCION
                    Case 0
                        If dtTabla.Rows.Count <= 0 Then
                            mensaje = "Para cerrar la historia debe: " & vbNewLine & "Digitar causa externa, motivo de consulta, información suministrada por y enfermedad actual."
                            Return False
                        End If

                        If dtTabla.Rows(0).Item("causaext").ToString.Trim.Length <= 0 Then
                            mensaje = "Para cerrar la historia debe: " & vbNewLine & "Digitar la causa externa. "
                            Return False
                        End If

                        resumenEvolucion = dtTabla.Rows(0).Item("resumen").ToString

                        'VALIDA DIAGNOSTICO PRINCIPAL
                    Case 1
                        If dtTabla.Rows.Count <= 0 Then
                            mensaje = "Para cerrar la historia debe: " & vbNewLine & "Digitar el diagnostico principal de Egreso "
                            Return False
                        End If

                        If resumenEvolucion.Trim.Length <= 0 And strTip_admision = objPaciente.HOSPITALIZACION Then
                            mensaje = "Para cerrar la historia debe: " & vbNewLine & "Digitar el resumen de evolución. "
                            Return False
                        End If

                        'VALIDA EL DESTINO FINAL
                    Case 2
                        If dtTabla.Rows.Count <= 0 And (strTip_admision <> objPaciente.CONSULTAEXTERNA And strTip_admision <> objPaciente.ADT) Then
                            mensaje = "Para cerrar la historia debe: " & vbNewLine & "Digitar el destino final. "
                            Return False
                        End If

                        If dtTabla.Rows.Count > 0 Then
                            If dtTabla.Rows(0).Item("est_final").ToString.Trim.Length <= 0 And (strTip_admision <> objPaciente.CONSULTAEXTERNA And strTip_admision <> objPaciente.ADT) Then
                                mensaje = "Para cerrar la historia debe: " & vbNewLine & "Digitar el destino final. "
                                Return False
                            End If
                            ''Si el destino final es traslado intrahospitalario el egreso ser hara automaticamente
                            ''Cuando se realice el traslado administrativo
                            ''Claudia Garay Marzo 2011 Solicitado Por Hernan Rojas
                            If dtTabla.Rows(0).Item("est_final") = "3" And (strTip_admision <> objPaciente.CONSULTAEXTERNA And strTip_admision <> objPaciente.ADT) Then
                                Return False
                            End If
                        End If

                        'VALIDA RECOMENDACIONES AL EGRESO
                        'No se obliga a grabar recomendaciones al egreso para consulta externa
                    Case 3
                        If dtTabla.Rows.Count <= 0 And strTip_admision <> objPaciente.CONSULTAEXTERNA Then

                            ''Si el status del paciente es M no se exigen recomendaciones al egreso. cpgaray Enero 15 2015 OS 229177
                            If dsConsulta.Tables(2).Rows(0).Item("status") <> "M" Then
                                ''Si el estado final es 3 (Remision) no se exigen recomendaciones al egreso
                                ''14 de julio de 2010
                                ''Claudia Garay
                                If IsDBNull(dsConsulta.Tables(2).Rows(0).Item("est_final")) Then
                                    mensaje = "Para cerrar la historia debe: " & vbNewLine & "Digitar recomendaciones al egreso. "
                                    Return False
                                End If
                                If dsConsulta.Tables(2).Rows(0).Item("est_final") <> "3" Then
                                    mensaje = "Para cerrar la historia debe: " & vbNewLine & "Digitar recomendaciones al egreso. "
                                    Return False
                                End If
                            End If
                        End If

                End Select
            Next

            Return True

        End Function

        ''' <summary>
        ''' Funcion que determina que opciones se le presentaran al usuario 
        ''' en el momento que desee salir de la historia clinica
        ''' Estas opciones son "cerrar Historia ", "Observacion", "Pendiente"
        ''' y "Cancelar". De acuerdo al estado de la historia y el cumplimiento 
        ''' de las condiciones de salida se muestra una combinacion de las 
        ''' anteriores opciones. Estas posibles combinaciones esta en la 
        ''' enumeracion ConfiguracionOpciones.
        ''' </summary>
        ''' <param name="objConexion">datos de la conexion a la bd</param>
        ''' <param name="objDatosGenerales">Parametros de entrada a la historia clinica (Vienen de sophia)</param>
        ''' <returns>Combinacion de opciones de salida que seran mostradas al cliente</returns>
        ''' <remarks></remarks>
        Public Shared Function determinarOpcionesCliente(ByVal objConexion As objCon, ByVal objDatosGenerales As objGeneral, _
                                                         Optional ByRef estadoHC As String = "", Optional ByRef mensaje As String = "") As configuracionOpciones
            Dim pacienteHC As objPaciente
            Dim cumpleCondicionesSalida As Boolean
            Dim objG As objGeneral = objGeneral.Instancia
            Dim estadoHistoria As String = ""

            pacienteHC = objPaciente.Instancia()
            cumpleCondicionesSalida = BLEgresos.cumpleCondicionesEgreso(objConexion, objDatosGenerales.Prestador, _
                                                                    objDatosGenerales.Sucursal, pacienteHC.TipoAdmision, _
                                                                    pacienteHC.AnoAdmision, pacienteHC.NumeroAdmision, _
                                                                    estadoHistoria, mensaje)

            estadoHC = estadoHistoria


            '' Para Perú las condiciones de salida deben permitir elegir cerrar la historia y la admision o
            '' solo cerrar la historia cpgaray oct 28 de 2013
            If objG.Pais = "482" Then
                If cumpleCondicionesSalida = True And estadoHistoria = objPaciente.PENDIENTE Then
                    Return configuracionOpciones.CerrarHistoriaAdmision
                End If
            Else
                If cumpleCondicionesSalida = True And estadoHistoria = objPaciente.PENDIENTE Then
                    Return configuracionOpciones.CerrarCancelar
                End If
            End If


            If cumpleCondicionesSalida = True And estadoHistoria = objPaciente.OBSERVACION Then
                Return configuracionOpciones.CerrarObservaCancelar

            ElseIf cumpleCondicionesSalida = False And (pacienteHC.TipoAdmision = objPaciente.HOSPITALIZACION Or _
                   pacienteHC.TipoAdmision = objPaciente.URGENCIAS Or pacienteHC.TipoAdmision = objPaciente.CIRUGIA) Then
                Return configuracionOpciones.ObservacionCancelar

            ElseIf cumpleCondicionesSalida = False And (pacienteHC.TipoAdmision = objPaciente.CONSULTAEXTERNA Or _
                   pacienteHC.TipoAdmision = objPaciente.ADT) Then
                Return configuracionOpciones.PendienteCancelar
            Else
                Return configuracionOpciones.Cancelar
            End If
        End Function

        ''' <summary>
        ''' Funcion que obtiene la instancia vigente de paciente y llama
        ''' el procedimiento que actualiza la base de datos para permitir
        ''' cerrar la historia
        ''' </summary>
        ''' <param name="objconexion">Datos de la conexion</param>
        ''' <param name="strCod_pre_sgs">Codigo del prestador</param>
        ''' <param name="strcod_sucur">Codigo de la sucursal</param>
        ''' <param name="strLogin">Login</param>
        ''' <returns>El numero de error devuelto por el stored procedure</returns>
        ''' <remarks></remarks>
        Public Shared Function cerrarHistoriaClinica(ByVal objconexion As objCon, ByVal strCod_pre_sgs As String, ByVal strcod_sucur As String, _
                                                     ByVal strLogin As String) As Long

            Dim pacienteHC As objPaciente

            pacienteHC = objPaciente.Instancia()

            Return DAOEgresos.cerrarHistoriaClinica(objconexion, strCod_pre_sgs, strcod_sucur, pacienteHC.TipoAdmision, pacienteHC.AnoAdmision, _
                                                    pacienteHC.NumeroAdmision, pacienteHC.TipoDocumento, pacienteHC.NumeroDocumento, strLogin)
        End Function
        Public Shared Function cerrarHistoriaClinicaCE(ByVal objconexion As objCon, ByVal strCod_pre_sgs As String, ByVal strcod_sucur As String, _
                                             ByVal strLogin As String) As Long

            Dim pacienteHC As objPaciente

            pacienteHC = objPaciente.Instancia()

            Return DAOEgresos.cerrarHistoriaClinicaCE(objconexion, strCod_pre_sgs, strcod_sucur, pacienteHC.TipoAdmision, pacienteHC.AnoAdmision, _
                                                    pacienteHC.NumeroAdmision, strLogin)
        End Function

        ''' <summary>
        ''' Funcion que obtiene la instancia vigente de paciente y llama
        ''' el procedimiento que actualiza la base de datos para permitir
        ''' dejar la historia clinica en observacion 
        ''' </summary>
        ''' <param name="objconexion">Datos de la conexion</param>
        ''' <param name="strCod_pre_sgs">Codigo del prestador</param>
        ''' <param name="strcod_sucur">Codigo de la sucursal</param>
        ''' <returns>El error que genera el stored procedure</returns>
        ''' <remarks></remarks>
        Public Shared Function observacionHistoriaClinica(ByVal objconexion As objCon, ByVal strCod_pre_sgs As String, ByVal strcod_sucur As String) As Long

            Dim pacienteHC As objPaciente

            pacienteHC = objPaciente.Instancia()

            Return DAOEgresos.observacionHistoriaClinica(objconexion, strCod_pre_sgs, strcod_sucur, pacienteHC.TipoAdmision, _
                                                         pacienteHC.AnoAdmision, pacienteHC.NumeroAdmision)
        End Function

        ''' <summary>
        ''' Procedimiento que limpia los objetos que contiene el estado de la 
        ''' historia clinica osea la informacion que el usuario registro en 
        ''' cada una de las secciones.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub eliminarObjetosHistoriaClinica()

            Dim pacienteHC As objPaciente
            Dim objEgreso As Egreso
            Dim objEvolucion As Evolucion
            Dim objHCBAsica As DatosHistoriaBasica
            Dim objOrdenMedica As OrdenMedica
            Dim objFormulaExterna As PlanFormuExterna
            Dim objIncapacidad As PlanIncapacidad
            Dim objProcExternos As PlanProcExternos
            Dim objRemision As PlanRemision
            Dim objRecomendacion As RecomEgreso
            Dim objDatosGenerales As objGeneral


            ctlOrdenesMedicas.Instancia.intload = 0

            ctlOrdenesMedicas.Instancia.datosSinAlmacenar = False

            ''Se reinicia el flag que nos permite saber si se han grabado 
            ''datos en la diferentes secciones de la historia. Si no se
            ''ha modificado datos permite salir de la Historia sin actualizar nada
            objDatosGenerales = objGeneral.Instancia()
            objDatosGenerales.HistoriaClinicaTieneModificaciones = False

            ''Se obtinen las instancias de los objetos singleton 
            ''que contienen la informacion de la historia clinica
            pacienteHC = objPaciente.Instancia()
            objHCBAsica = DatosHistoriaBasica.Instancia()
            objEgreso = Egreso.Instancia()
            objEvolucion = Evolucion.Instancia()
            objOrdenMedica = OrdenMedica.Instancia()
            objFormulaExterna = PlanFormuExterna.Instancia()
            objIncapacidad = PlanIncapacidad.Instancia()
            objProcExternos = PlanProcExternos.Instancia()
            objRemision = PlanRemision.Instancia()
            objRecomendacion = RecomEgreso.Instancia()

            pacienteHC.Limpiar()
            objHCBAsica.Limpiar()
            objEgreso.Limpiar()
            objEvolucion.Limpiar()
            objOrdenMedica.Limpiar()
            objFormulaExterna.Limpiar()
            objIncapacidad.Limpiar()
            objProcExternos.Limpiar()
            objRemision.Limpiar()
            objRecomendacion.Limpiar()



            ''Se llama el metodo dispose de cada objeto que asigna a la 
            ''instancia sigleton el valor de nothing de tal manera que la 
            ''proxima vez que alguen quiera instanciarlo se cree un nuevo objeto limpio
            'pacienteHC.Dispose()
            'objHCBAsica.Dispose()
            'objEgreso.Dispose()
            'objEvolucion.Dispose()
            'objOrdenMedica.Dispose()
            'objFormulaExterna.Dispose()
            'objIncapacidad.Dispose()
            'objProcExternos.Dispose()
            'objRemision.Dispose()
            'objRecomendacion.Dispose()

        End Sub

        ''' <summary>
        ''' Procedimiento que elimina los objetos que contienen la informacion
        ''' inicial pasada por parametros desde sophia, tal como el codigo
        ''' del prestador, codigo de la sucursal, cadena de conexion, etc.
        ''' </summary>
        ''' <remarks></remarks>
        Public Shared Sub eliminarParametrosIniciales()
            Dim objConexion As objCon
            Dim objDatosGenerales As objGeneral

            objConexion = objCon.Instancia()
            objDatosGenerales = objGeneral.Instancia()

            objConexion.Dispose()
            objDatosGenerales.Dispose()

        End Sub

        Public Shared Function actualizarEstadoHistoriaClinica(ByVal objConexion As objCon, ByVal strCod_pre_sgs As String, _
                                                               ByVal strCod_sucur As String) As Long

            Dim pacienteHC As objPaciente

            pacienteHC = objPaciente.Instancia()
            Return DAOEgresos.actualizarEstadoHistoriaClinica(objConexion, strCod_pre_sgs, strCod_sucur, pacienteHC.TipoAdmision, _
                                                pacienteHC.AnoAdmision, pacienteHC.NumeroAdmision, pacienteHC.EstadoInicialHistoria)
        End Function

#End Region

#Region "GrabarEgresoDiagnostico"
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Proceso de grabar datos de los diagnosticos para el egreso (procedimiento HC_GrabarEgresoDiagnostico)
        ''' </summary>
         ''' <returns>string con respuesta de la transacción</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas] 15/06/2006	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function GrabarEgresoDiagnostico(ByVal objconexion As objCon, _
                    ByVal strCodigoPrestador As String, ByVal strCodSucur As String, _
                    ByVal strTipDoc As String, ByVal strNumDoc As String, _
                    ByVal strTipAdm As String, ByVal lNumAdm As Long, _
                    ByVal intAnoAdm As Integer, ByVal strClaseDiag As String, _
                    ByVal strTipDiag As String, ByVal strDiagnostico As String, _
                    ByVal strAntecedente As String, ByVal strObservaciones As String, _
                    ByVal strConfidencial As String, ByVal strClasificacion As String, _
                    ByVal strCategoria As String, ByVal intSecuencia As Integer, _
                    ByVal intAccion As Integer, ByVal strLogin As String) As Long

            Dim objDao As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long

            lError = objDao.EjecutarSPConParametrosTran("HC_GrabarEgresoDiagnostico", objconexion, _
                                            strCodigoPrestador, strCodSucur, strTipDoc, _
                                            strNumDoc, strTipAdm, lNumAdm, intAnoAdm, _
                                            strClaseDiag, strTipDiag, strDiagnostico, _
                                            strAntecedente, strObservaciones, strConfidencial, _
                                            strClasificacion, strCategoria, intSecuencia, _
                                            intAccion, strLogin, lError)
            Return lError

        End Function
#End Region

#Region "GrabarEgresoDatos"
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Proceso de grabar datos del egreso (procedimiento HC_GrabarEgresoDatos)
        ''' </summary>
        ''' <returns>string con respuesta de la transacción</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[mvargas] 15/06/2006	Created
        ''' </history>
        ''' ---------
        ''' --------------------------------------------------------------------
        ''Claudia Garay Acreditacion
        ''Se agrega campo de acreditacion PostEgreso
        ''Noviembre 26 de 2010
        Public Function GrabarEgresoDatos(ByVal objconexion As objCon, _
                    ByVal strCodigoPrestador As String, ByVal strCodSucur As String, _
                    ByVal strTipDoc As String, ByVal strNumDoc As String, _
                    ByVal strTipAdm As String, ByVal intAnoAdm As Integer, _
                    ByVal lNumAdm As Long, ByVal strLogin As String, _
                    ByVal strEstadoSalida As String, ByVal strCausaMuerte As String, _
                    ByVal strDestinoFinal As String, ByVal strResumen As String, _
                    ByVal strFechaEgreso As String, ByVal intHoraEgreso As Integer, _
                    ByVal intMinEgreso As Integer, ByVal codEspecialidad As String, _
                    ByVal strPostEgreso As String, ByVal strObsPostEgreso As String) As Long

            Dim objDao As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long

            'jlalfonso-2008/12/16- agregar postegreso
            lError = objDao.EjecutarSPConParametrosTran("HC_GrabarEgresoDatos", objconexion, _
                                            strCodigoPrestador, strCodSucur, strTipDoc, _
                                            strNumDoc, strTipAdm, intAnoAdm, lNumAdm, _
                                            strLogin, strEstadoSalida, strCausaMuerte, _
                                            strDestinoFinal, strResumen, strFechaEgreso, _
                                            intHoraEgreso, intMinEgreso, codEspecialidad, strPostEgreso, strObsPostEgreso, lError)
            Return lError

        End Function
#End Region

#Region "Validar Medicamentos Conciliados"
        '''-----------------------------------------------------------------------------
        ''' <summary>
        ''' Proceso Validar Conciliacion Medicamentos (procedimiento )
        ''' </summary>
        ''' <param name="strCod_pre_sgs">Entidad Prestadora</param>
        ''' <param name="strCod_Sucur">Sucursal</param>
        ''' <param name="strTip_Admision">Tipo Admision</param>
        ''' <param name="lano_adm">Año Admision</param>
        ''' <param name="dnum_adm">Numero Admision</param>
        ''' <param name="objConexion">La conexión para ejecutar el SP</param>
        ''' <returns>string con respuesta de la transacción</returns>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[fabaicue] 07/03/2022	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Public Function ValidarConciliacionMedicamentos(ByVal strCod_pre_sgs As String, ByVal strCod_Sucur As String,
                                                     ByVal strTip_Admision As String, ByVal lano_adm As Long,
                                                     ByVal dnum_adm As Long, ByVal objConexion As objCon) As Long

            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim objP As objPaciente = objPaciente.Instancia

            Dim lError As Long

            Return obj.EjecutarSPConParametrosTran("HC_ValidarConciliacionEgreso", objConexion, strCod_pre_sgs, strCod_Sucur,
                                 strTip_Admision, lano_adm, dnum_adm, objP.TipoDocumento, objP.NumeroDocumento, lError)

        End Function
#End Region

#End Region

    End Class
#End Region

End Namespace