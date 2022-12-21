Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente

Imports objGenerales = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports System.Collections.Generic
Imports Newtonsoft
Imports System.Text
Imports Newtonsoft.Json
Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports System.Net.Http.Headers

Namespace Sophia.HistoriaClinica.BL
    Public Class BLOrdenes

#Region "Enumeraciones"
        Enum Accion
            Cargar = 1
            Grabar = 2
        End Enum
        Enum tiposProcedim
            ConsultaMedica = 1
            TratamientoMedico = 2
            ProcedimQuirurgicos = 3
            ApoyoDiagnostico = 4
            ApoyoTerapeutico = 5
            ServicioClinicas = 6
            Ayudantias = 7
        End Enum

#End Region

#Region "Constantes"
        Public Const INICIA As String = "I"
        Public Const SUSPENDE As String = "S"
        Public Const CONTINUA As String = "C"
        Public Const MODIFICA As String = "M" ''CLAUDIA GARAY 04/06/2010
        ''Public Const NOMODIFICA As String = "N"
        Public Const ACTIVO As String = "A"
        Public Const INACTIVO As String = "I"
        Public Const UNICADOSIS As String = "S"
        Public Const VARIASDOSIS As String = "N"
        Public Const EGRESADA As String = "E"
        Public Const TRASLADADA As String = "T"
        Public Const ANULADA As String = "A"
        Public Const PENDIENTE As String = "P"
#End Region

        Public Shared Function consultarOrdenes(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String, ByVal strCod_sucur As String,
                                               ByVal strTip_Admision As String, ByVal strAno_Adm As Integer,
                                               ByVal strNum_Adm As Double) As DataSet

            Dim dsDatos As DataSet
            Dim daoOrden As New DAOOrdenes()
            dsDatos = daoOrden.consultarOrdenes(objConexion, strCod_pre_sgs, strCod_sucur, strTip_Admision,
                                              strAno_Adm, strNum_Adm)
            With dsDatos
                .Tables(0).TableName = "AISLAMIENTO"
                .Tables(1).TableName = "DIETAS"
                .Tables(2).TableName = "MEDICAMENTOS"
                .Tables(3).TableName = "ORDENGENERAL"
                procesarCampoTratamiento1(.Tables("DIETAS"), INICIA, Accion.Cargar) ''ER_OSI_593_Modificacion_Funcionalidad_de_Dietas martovar
                procesarCampoTratamiento1(.Tables("AISLAMIENTO"), INICIA, Accion.Cargar) ''ER_OSI_594_Aislamientos dsanchez
                procesarCampoTratamiento(.Tables("MEDICAMENTOS"), INICIA, Accion.Cargar)
                procesarCampoTratamiento(.Tables("ORDENGENERAL"), INICIA, Accion.Cargar)
            End With


            Return dsDatos
        End Function












        Public Shared Function consultarTiposDieta(ByVal objConexion As Conexion) As DataTable
            Dim daoOrden As New DAOOrdenes()
            Dim dtDieta As DataTable

            dtDieta = daoOrden.consultarTiposDieta(objConexion)
            Return dtDieta
        End Function
        ''Claudia Garay Julio 19 de 2010
        Public Shared Function consultarTiposOrden(ByVal objConexion As Conexion) As DataTable
            Dim daoOrden As New DAOOrdenes()
            Return daoOrden.consultarTiposOrden(objConexion)
        End Function
        Public Shared Function consultarUnidadMedida(ByVal objConexion As Conexion) As DataTable
            Dim daoOrden As New DAOOrdenes()
            Return daoOrden.consultarUnidadMedida(objConexion)
        End Function

        Public Shared Function consultarViasAdmin(ByVal objConexion As Conexion) As DataTable
            Dim daoOrden As New DAOOrdenes()
            Return daoOrden.consultarViasAdmin(objConexion)
        End Function



        Public Shared Function consultarFrecuencia(ByVal objConexion As Conexion) As DataTable
            Dim daoOrden As New DAOOrdenes()
            Return daoOrden.consultarFrecuencia(objConexion)
        End Function
        ''martovar ER_OSI_596_Indicaciones_Medicas 2017/09/25
        Public Shared Function consultarTiempo(ByVal objConexion As Conexion) As DataTable
            Dim daoOrden As New DAOOrdenes()
            Return daoOrden.consultarTiempo(objConexion)
        End Function
        Public Shared Function validarDieta(ByVal tipoDieta As String, ByVal descripDieta As String,
                                ByVal dtDietas As DataTable, Optional ByRef mensaje As String = "") As Boolean
            'Dim resultado() As DataRow

            'resultado = dtDietas.Select("Dieta = '" & tipoDieta & "'")
            'If resultado.Length > 0 Then
            '    mensaje = "El registro ya existe en la grilla."
            '    Return False
            'End If

            If Len(Trim(tipoDieta)) <= 0 Or Len(Trim(descripDieta)) <= 0 Then
                mensaje = "Debe digitar la información de la dieta."
                Return False
            End If

            Return True
        End Function

        Public Shared Function ValidarDieta24Horas1(ByVal fecha As DateTime) As Boolean


            Dim fechavalida As Date = Now
            Dim fechaactual As Date = Now
            Dim Fecvalida As Date
            Dim Fecactual As Date
            Dim result As Integer

            fechavalida = DateAdd(DateInterval.Day, 1, fecha)

            Fecactual = Format(fechaactual, "dd-MM-yyyy")
            Fecvalida = Format(fechavalida, "dd-MM-yyyy")
            result = DateTime.Compare(Fecactual, Fecvalida)

            If result < 0 Then
                Return False
            ElseIf result = 0 Then
                Return True
            Else
                Return True
            End If
        End Function

        Public Shared Function validarMedicamento(ByVal CodigoMedica As String, ByVal descripMedica As String,
                                                  ByVal dosis As String, ByVal unidadMedida As String, ByVal via As String,
                                                  ByVal codFrecuencia As String, ByVal descFrecuencia As String,
                                                  ByVal unicaDosis As Boolean, ByVal dtMedica As DataTable, ByRef mensaje As String) As Boolean

            'Dim resultado() As DataRow

            'resultado = dtMedica.Select("producto = '" & CodigoMedica & "'")
            'If resultado.Length > 0 Then
            '    mensaje = "El registro ya existe en la grilla."
            '    Return False
            'End If

            If Len(Trim(CodigoMedica)) <= 0 Or Len(Trim(descripMedica)) <= 0 Then
                mensaje = "Debe digitar la información del producto."
                Return False
            End If
            'jlalfonso -2009-02-05
            'se realiza comentario para no tener en cuenta estas validaciones en ordenes medicas
            'solicitado por eforero

            'If Len(Trim(dosis)) <= 0 Then
            '    mensaje = "Debe digitar la dosis."
            '    Return False
            'End If

            'If Len(Trim(unidadMedida)) <= 0 Then
            '    mensaje = "Debe digitar la unidad de medida."
            '    Return False
            'End If

            'If Len(Trim(via)) <= 0 Then
            '    mensaje = "Debe digitar la via de administración."
            '    Return False
            'End If

            'If unicaDosis = False And (Len(Trim(codFrecuencia)) <= 0 Or Len(Trim(descFrecuencia)) <= 0) Then
            '    mensaje = "Debe digitar la información completa de la frecuencia."
            '    Return False
            'End If

            Return True
        End Function

        'Joseph Moreno (IG) Fec:2019/11/21 Particularidades
        Public Shared Function validarProcedimientos(ByVal codigo As String, ByVal procedimiento As String, ByVal tipoProcedim As String,
                                               ByVal cantidad As String, ByVal centrosCostoDestino As DataTable,
                                               ByVal ccDestinoElegido As String, ByVal dtProcedim As DataTable,
                                               ByVal Guia As String, ByVal Justificacion As String,
                                               ByRef mensaje As String, ByVal strEntidad As String, ByVal strTipAdmision As String,
                                               ByVal ProcedimElegido As String, ByVal CodigoRis As String, ByVal Practica As String,
                                               ByVal Observaciones As String,
                                               Optional ByVal booValidacionPart As Boolean = True) As Boolean

            Dim resultado() As DataRow
            Dim tipoProce As Integer
            Dim objGeneral As objGenerales
            Dim objpaciente As Paciente

            objpaciente = Paciente.Instancia
            objGeneral = objGenerales.Instancia



            '' herojas agfa_orm_in Interfaz ORM Un codigo_ris puede tener aleas duplicados
            'If UCase(ProcedimElegido) <> "RIS" And UCase(ProcedimElegido) <> "LABORATORIO" Then
            '    resultado = dtProcedim.Select("procedim = '" & codigo & "'")
            '    If resultado.Length > 0 Then
            '        mensaje = "El registro ya existe en la grilla."
            '        Return False
            '    Else
            '        'agfa_orm_in  herojas 2014/10/10
            '        If Len(Practica) > 0 Then
            '            MsgBox(Practica)
            '        End If
            '    End If
            'Else
            '    resultado = dtProcedim.Select("codigo_ris = '" & CodigoRis & "'")
            '    If resultado.Length > 0 Then
            '        mensaje = "El registro ya existe en la grilla."
            '        Return False
            '    Else
            '        'agfa_orm_in  herojas 2014/10/10
            '        If Len(Practica) > 0 Then
            '            MsgBox(Practica)
            '        End If
            '    End If
            'End If

            'RMZALDUA 2016/04/19

            ' herojas agfa_orm_in Interfaz ORM Un codigo_ris puede tener aleas duplicados
            If UCase(ProcedimElegido) <> "RIS" And UCase(ProcedimElegido) <> "LABORATORIO" Then
                resultado = dtProcedim.Select("procedim = '" & codigo & "'")
                If resultado.Length > 0 Then
                    mensaje = "El registro ya existe en la grilla."
                    Return False
                Else
                    'agfa_orm_in  herojas 2014/10/10
                    If Len(Practica) > 0 Then
                        MsgBox(Practica)
                    End If
                End If
            Else
                If CodigoRis = " " Then
                    resultado = dtProcedim.Select("procedim = '" & codigo & "'")
                    If resultado.Length > 0 Then
                        mensaje = "El registro ya existe en la grilla."
                        Return False
                    Else
                        'agfa_orm_in  herojas 2014/10/10
                        If Len(Practica) > 0 Then
                            MsgBox(Practica)
                        End If
                    End If

                Else

                    resultado = dtProcedim.Select("codigo_ris = '" & CodigoRis & "'")
                    If resultado.Length > 0 Then
                        mensaje = "El registro ya existe en la grilla."
                        Return False
                    Else
                        'agfa_orm_in  herojas 2014/10/10
                        If Len(Practica) > 0 Then
                            MsgBox(Practica)
                        End If
                    End If
                End If
            End If



            If Len(Trim(codigo)) <= 0 Or Len(Trim(procedimiento)) <= 0 Then
                mensaje = "Debe digitar la información del procedimiento"
                Return False
            End If

            If IsNumeric(tipoProcedim) Then
                tipoProce = CInt(tipoProcedim)
            Else
                tipoProce = 0
            End If

            'Joseph Moreno (IG) Fec:2019/11/21 Particularidades
            If Not booValidacionPart Then
                mensaje = "Seleccione al menos una particularidad para continuar."
                Return False
            End If

            'Si el procedimiento tiene parametrizado centro(s) de costo obliga al usuario a 
            'elegir uno. Si el procedimiento es de tipo "Consulta Externa"
            'o "Procedimientos Quirurgicos" no debe hacer la validacion.


            'rmzaldua 2016-03-28 para validar HL7
            If UCase(ProcedimElegido) = "LABORATORIO" Then
                If Not centrosCostoDestino Is Nothing Then
                    If ccDestinoElegido.Trim.Length = 0 _
                        And (tipoProce <> tiposProcedim.ConsultaMedica) Then 'And tipoProce <> tiposProcedim.ProcedimQuirurgicos) Then ''cpgaray OS 750259 centro de costo obligatorio para tipo 3 indicado por herojas
                        mensaje = "Debe seleccionar un centro de costo destino." 'centrosCostoDestino.Rows.Count = 0 And
                        Return False
                    End If
                End If
            Else
                If Not centrosCostoDestino Is Nothing Then
                    If centrosCostoDestino.Rows.Count > 0 And ccDestinoElegido.Trim.Length = 0 _
                        And (tipoProce <> tiposProcedim.ConsultaMedica) Then 'And tipoProce <> tiposProcedim.ProcedimQuirurgicos) Then ''cpgaray OS 750259 centro de costo obligatorio para tipo 3 indicado por herojas
                        mensaje = "Debe seleccionar un centro de costo destino."
                        Return False
                    End If
                End If
            End If
            If Len(Trim(cantidad)) <= 0 Then
                mensaje = "Debe digitar la cantidad"
                Return False
            End If


            ' Validacion observaciones para procedimientos ris. Se
            If Len(Trim(Observaciones)) = 0 And UCase(ProcedimElegido) = "RIS" Then
                mensaje = "Para este procedimiento es obligatorio ingresar observaciones."
                Return False
            End If

            'martovar codificacion se agregan prestador y sucursal

            If ValidaAutorizacionProcedimiento(codigo, strEntidad, strTipAdmision, objGeneral.Prestador, objGeneral.Sucursal) = True Then
                If Len(Trim(Guia)) <= 0 And objGeneral.Pais <> "482" Then
                    mensaje = "Debe digitar Manejo Integral según guía de"
                    Return False
                End If



            End If


            'agfa_orm_in validar justificacion 2014/11/26

            If UCase(ProcedimElegido) = "RIS" Then
                If Len(Trim(Justificacion)) = 0 Then
                    mensaje = "Debe digitar la Justificacion"
                    Return False
                End If
            End If

            'If Valida_ordenes_examen_laboratorio(objGeneral.Prestador, objGeneral.Sucursal, objpaciente.TipoAdmision, objpaciente.AnoAdmision, objpaciente.NumeroAdmision, codigo) = True Then
            '    Return True
            'Else
            '    Return False
            'End If


            Return True
        End Function
        ''Modificado por Claudia Garay Julio 19 de 2010
        ''Modificado martovar ER_OSI 598 Indicaciones Médicas 2017/09/26 se cambian los mensajes
        Public Shared Function validarGenerales(ByVal drow As DataRow, ByVal dtGenerales As DataTable, ByRef mensaje As String) As Boolean
            Dim resultado() As DataRow


            If drow("Orden") = 106 And drow("TextoOrden").Trim.Length <= 0 Then
                mensaje = "Debe digitar la descripción para la Indicacion."
                Return False
            ElseIf drow("TextoOrden").Trim.Length <= 0 Then
                mensaje = "Debe seleccionar una Indicacion."
                Return False
            Else
                If drow("Orden") <> 106 Then
                    resultado = dtGenerales.Select("orden = '" & drow("Orden") & "'")
                    If resultado.Length > 0 Then
                        mensaje = "Indicación ya agregada."
                        Return False
                    End If
                End If

            End If

            Return True
        End Function
        Public Shared Function medicamentoTieneConvenio(ByVal objconexion As Conexion, ByVal codProducto As String, ByVal cod_pre_sgs As String, ByVal cod_sucur As String,
                                                        ByVal entidad As String) As Boolean
            Dim daoOrden As New DAOOrdenes()
            Return daoOrden.consultarConvenioMedicamento(objconexion, codProducto, cod_pre_sgs, cod_sucur, entidad)

        End Function


        Public Shared Function consultarRIS(ByVal objconexion As Conexion, ByVal codigo As String, ByRef codigo_RIS As String, ByRef nombre_RIS As String) As Boolean
            Dim daoOrden As New DAOOrdenes()
            Return daoOrden.consultarRIS(objconexion, codigo, codigo_RIS, nombre_RIS)
        End Function

        Public Shared Function ValidaAutorizacionProcedimiento(ByVal strProcedim As String, ByVal strEntidad As String, ByVal strTipAdmision As String, ByVal strCod_pre_sgs As String, ByVal strCod_sucur As String) As Boolean
            'Joseph Moreno (IG) Fec:2019/11/05 Corrección Branch
            Dim daoOrden As New DAOOrdenes()
            Dim dt As New DataTable

            'Joseph Moreno (IG) Fec:2019/11/05 Corrección Branch
            dt = daoOrden.consultarautorizacionProcedimientos(strProcedim, strEntidad, strCod_pre_sgs, strCod_sucur)


            If Not dt Is Nothing Then

                If dt.Rows.Count > 0 Then
                    If IIf(IsDBNull(dt.Rows(0).Item("autoriza").ToString), "", dt.Rows(0).Item("autoriza").ToString) = "A" Then

                        Select Case strTipAdmision
                            Case "A"
                                If IIf(IsDBNull(dt.Rows(0).Item("aut_cirugia").ToString), "", dt.Rows(0).Item("aut_cirugia").ToString) = "S" Then
                                    Return True
                                End If
                            Case "E"
                                If IIf(IsDBNull(dt.Rows(0).Item("aut_consultaexterna").ToString), "", dt.Rows(0).Item("aut_consultaexterna").ToString) = "S" Then
                                    Return True
                                End If
                            Case "U"
                                If IIf(IsDBNull(dt.Rows(0).Item("aut_urgencias").ToString), "", dt.Rows(0).Item("aut_urgencias").ToString) = "S" Then
                                    Return True
                                End If
                            Case "P"
                                If IIf(IsDBNull(dt.Rows(0).Item("aut_cirugia").ToString), "", dt.Rows(0).Item("aut_cirugia").ToString) = "S" Then
                                    Return True
                                End If
                            Case "H"
                                If IIf(IsDBNull(dt.Rows(0).Item("aut_hospitalizacion").ToString), "", dt.Rows(0).Item("aut_hospitalizacion").ToString) = "S" Then
                                    Return True
                                End If
                            Case Else
                                Return False
                        End Select

                    Else
                        Return False

                    End If

                Else
                    Return False
                End If
            Else
                Return False
            End If

        End Function

        Public Shared Function Valida_ordenes_examen_laboratorio(ByVal strcodpresgs As String, ByVal strcodsucur As String, ByVal strTipAdmision As String,
                                                                   ByVal ano_adm As Integer, ByVal num_adm As Integer, ByVal strprocedim As String) As Boolean
            Dim daoOrden As New DAOOrdenes()
            Dim dt As New DataTable

            dt = daoOrden.consultar_Ordenes_Laboratorio_Procedimiento(strcodpresgs, strcodsucur, strTipAdmision, ano_adm, num_adm, strprocedim)

            If Not dt Is Nothing Then

                If dt.Rows.Count > 0 Then
                    If IIf(IsDBNull(dt.Rows(0).Item("estado").ToString), "", dt.Rows(0).Item("estado").ToString) = "P" Then
                        If MessageBox.Show("El laboratorio clínico ya se encuentra SOLICITADO por: " + dt.Rows(0).Item("Usuario").ToString + ", fecha solicitud: " + dt.Rows(0).Item("fecha_orden").ToString + ", desea solicitarlo nuevamente", "Examenes de Laboratorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                            Return False
                        Else
                            Return True
                        End If
                    Else
                        If IIf(IsDBNull(dt.Rows(0).Item("estado").ToString), "", dt.Rows(0).Item("estado").ToString) = "D" Then
                            If MessageBox.Show("El laboratorio clínico ya se encuentra SOLICITADO por: " + dt.Rows(0).Item("Usuario").ToString + ", fecha solicitud: " + dt.Rows(0).Item("fecha_orden").ToString + ", estado: " + UCase(dt.Rows(0).Item("des_estado").ToString) + ", desea solicitarlo nuevamente", "Examenes de Laboratorio", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.No Then
                                Return False
                            Else
                                Return True
                            End If
                        Else
                            Return True
                        End If
                    End If

                Else
                    Return True
                End If
            Else
                Return True
            End If

        End Function

        Public Shared Function procedimientoTieneConvenio(ByVal objconexion As Conexion, ByVal codProducto As String, ByVal cod_pre_sgs As String, ByVal cod_sucur As String,
                                                        ByVal entidad As String, ByRef ProcedimHomologo As String, ByVal cCosto As String) As Boolean

            Dim daoOrden As New DAOOrdenes()
            Return daoOrden.consultarConvenioProcedimiento(objconexion, codProducto, cod_pre_sgs, cod_sucur, entidad, ProcedimHomologo, cCosto)

        End Function

        Public Shared Function CentroCostoLaboratorio(ByVal objconexion As Conexion, ByVal cod_pre_sgs As String, ByVal cod_sucur As String,
                                                        ByVal Ccosto As String) As Boolean

            Dim daoCcosto As New DAOOrdenes()
            Return daoCcosto.consultarCcostoLabo(objconexion, Ccosto, cod_pre_sgs, cod_sucur)

        End Function
        'mzaldua 2016-03-09
        Public Shared Function existeEntidadAdmadmentrec(ByVal objconexion As Conexion, ByVal cod_pre_sgs As String, ByVal cod_sucur As String,
                                                        ByVal strTip_Admision As String, ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double,
                                                        ByVal strEntidadRec As String) As Boolean

            Dim daoCcosto As New DAOOrdenes()
            Return daoCcosto.consultarADmAdmEntRec(objconexion, cod_pre_sgs, cod_sucur, strTip_Admision, strAno_Adm, strNum_Adm, strEntidadRec)

        End Function

        'mzaldua 2016-11-21
        Public Shared Function existePosCondicionado(ByVal objconexion As Conexion, ByVal cod_pre_sgs As String, ByVal cod_sucur As String,
                                                        ByVal strTip_Admision As String, ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double,
                                                        ByVal strTipo_Producto As String, ByVal strProducto As String) As Boolean

            Dim daoposcondi As New DAOOrdenes()
            Return daoposcondi.consultarPosCondicionado(objconexion, cod_pre_sgs, cod_sucur, strTip_Admision, strAno_Adm, strNum_Adm, strTipo_Producto, strProducto)

        End Function
        Public Shared Function EpsRecobrable(ByVal objconexion As Conexion, ByVal strEntidad As String) As String

            Dim daoCcosto As New DAOOrdenes()
            Return daoCcosto.consultarEpsRecobrable(objconexion, strEntidad)

        End Function

        '' herojas 2015/03/16
        Public Shared Function EsHonorarioVariable(ByVal cod_pre_sgs As String,
                                            ByVal cod_sucur As String,
                                            ByVal Medico As String,
                                            ByVal Especialidad As String,
                                            ByVal procedim As String,
                                            ByVal entidad As String,
                                            ByVal Fec_cargo As String,
                                            ByRef Porcentaje As Integer) As Boolean

            Dim daoOrden As New DAOOrdenes()
            Return daoOrden.consultarHonorarioVariable(cod_pre_sgs, cod_sucur, Medico, Especialidad, procedim, entidad, Fec_cargo, Porcentaje)

        End Function



        'Public Shared Function traerFechaServidor() As Date
        '    Return DAOGeneral.traerFechaServidor()
        'End Function

        ''' <summary>
        ''' Funcion que guarda todas la ordenes medicas que han sido modificadas o
        ''' adicionadas. Retorna el numero de orden que se genera en el stored procedure
        ''' </summary>
        ''' <param name="objConexion">Datos de la conexion</param>
        ''' <param name="dtDietas">Data table con la informacion de las dietas</param>
        ''' <returns>Numero de Orden</returns>
        ''' <remarks></remarks>
        'Public Shared Function guardarOrdenes(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String, _
        '                                         ByVal strCodSucur As String, ByVal tip_admision As String, _
        '                                         ByVal num_adm As String, ByVal ano_adm As String, ByVal strLogin As String, _
        '                                         ByVal medico As String, ByVal strCodEspecialidad As String, ByVal entidad As String, _
        '                                         ByVal dtDietas As DataTable, ByVal dtMedicamentos As DataTable, _
        '                                         ByVal dtProcedimientos As DataTable, ByVal dtGenerales As DataTable, _
        '                                         ByRef NroOrden As Double, ByRef fechaOrden As Date, _
        '                                         ByRef centroCostoOrigen As String, ByRef strGuia As String, _
        '                                         ByRef strJustificacion As String, ByRef strTipoServicio As String, _
        '                                         ByRef strPrioridad As String, ByVal CodProcedim As String, ByVal DescripProcedim As String, ByVal CCDestino As String) As Long

        '    Dim dtDietasModificadas As New DataTable
        '    Dim dtDietasNuevas As New DataTable
        '    Dim xmlDietasModifica As String = ""
        '    Dim xmlDietasNuevas As String = ""

        '    Dim dtMedicaModificados As New DataTable
        '    Dim dtMedicaNuevos As New DataTable
        '    Dim xmlMedicaModificados As String = ""
        '    Dim xmlMedicaNuevos As String = ""

        '    Dim dtproceNuevos As New DataTable
        '    Dim dtProcedimXCentroCosto As ArrayList
        '    Dim xmlProceNuevos As String

        '    Dim dtGeneralesModificados As New DataTable
        '    Dim dtGeneralesNuevos As New DataTable
        '    Dim xmlGeneralesModificados As String
        '    Dim xmlGeneralesNuevos As String

        '    ''Claudia Garay Abril 05 2011 Auditoria Ordenes
        '    Dim intCountDietas As Integer = 0
        '    Dim intCountMedicamento As Integer = 0
        '    Dim intCountProcedimiento As Integer = 0
        '    Dim intCountGenerales As Integer = 0
        '    Dim objpaciente As Paciente
        '    objpaciente = Paciente.Instancia

        '    Dim lError As Long
        '    Dim i As Integer


        '    dtDietasModificadas = dtDietas.Clone()
        '    dtDietasNuevas = dtDietas.Clone()

        '    dtMedicaModificados = dtMedicamentos.Clone()
        '    dtMedicaNuevos = dtMedicamentos.Clone()

        '    dtproceNuevos = dtProcedimientos.Clone()

        '    dtGeneralesModificados = dtGenerales.Clone
        '    dtGeneralesNuevos = dtGenerales.Clone

        '    '----------------------------DIETAS-----------------------------------
        '    ''Se buscan las dietas que han sido modificadas 
        '    dtDietasModificadas = filtrarTabla(dtDietas, DataViewRowState.ModifiedCurrent, dtDietasModificadas)
        '    ''Cambia el campo tratamiento cuando es Null al valor I por 
        '    procesarCampoTratamiento(dtDietasModificadas, INICIA, Accion.Grabar)

        '    asignarSecuencia(dtDietas)
        '    ''Se buscan las dietas nuevas.Tambien se adicionan los registros 
        '    ''modificados ya que estos se insertan con un nuevo numero de orden quedando activos en la nueva orden.
        '    dtDietasNuevas = filtrarTabla(dtDietas, DataViewRowState.Added, dtDietasNuevas)
        '    dtDietasNuevas = filtrarTabla(dtDietas, DataViewRowState.ModifiedCurrent, dtDietasNuevas)

        '    ''Cambia el campo tratamiento cuando es Null al valor I por 
        '    procesarCampoTratamiento(dtDietasNuevas, INICIA, Accion.Grabar)

        '    ''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
        '    dtDietasModificadas = configurarDataTableDietasParaGrabar(dtDietasModificadas)
        '    dtDietasNuevas = configurarDataTableDietasParaGrabar(dtDietasNuevas)

        '    If dtDietasNuevas.Rows.Count > 0 Then
        '        intCountDietas = dtDietasNuevas.Rows.Count
        '    End If


        '    ''Se generan los xml que contienen la informacion de las dietas
        '    xmlDietasModifica = FuncionesGenerales.GenerarXMLxProcedimiento(dtDietasModificadas)
        '    xmlDietasNuevas = FuncionesGenerales.GenerarXMLxProcedimiento(dtDietasNuevas)

        '    '--------------------------MEDICAMENTOS--------------------------------
        '    ''Se buscan los medicamentos modificados 
        '    dtMedicaModificados = filtrarTabla(dtMedicamentos, DataViewRowState.ModifiedCurrent, dtMedicaModificados)
        '    ''Cambia el campo tratamiento que esta en null por I Iniciado
        '    procesarCampoTratamiento(dtMedicaModificados, INICIA, Accion.Grabar)

        '    asignarSecuencia(dtMedicamentos)
        '    ''Se buscan  los medicamentos nuevos.Tambien se adicionan los registros 
        '    ''modificados ya que estos se insertan con un nuevo numero de orden quedando activos en la nueva orden.
        '    dtMedicaNuevos = filtrarTabla(dtMedicamentos, DataViewRowState.Added, dtMedicaNuevos)
        '    dtMedicaNuevos = filtrarTabla(dtMedicamentos, DataViewRowState.ModifiedCurrent, dtMedicaNuevos)
        '    ''Cambia el campo tratamiento que esta en null por I Iniciado
        '    procesarCampoTratamiento(dtMedicaNuevos, INICIA, Accion.Grabar)

        '    ''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
        '    dtMedicaModificados = configurarDataTableMedicaParaGrabar(dtMedicaModificados)
        '    dtMedicaNuevos = configurarDataTableMedicaParaGrabar(dtMedicaNuevos)

        '    If dtMedicaNuevos.Rows.Count > 0 Then
        '        intCountMedicamento = dtMedicaNuevos.Rows.Count
        '    End If

        '    ''Se generan los xml que contiene la informacion de los medicamentos
        '    xmlMedicaModificados = FuncionesGenerales.GenerarXMLxProcedimiento(dtMedicaModificados)
        '    xmlMedicaNuevos = FuncionesGenerales.GenerarXMLxProcedimiento(dtMedicaNuevos)


        '    '-------------------------PROCEDIMIENTOS--------------------------------

        '    ''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
        '    dtProcedimientos = configurarDataTableProcedimParaGrabar(dtProcedimientos)

        '    ''Se buscan los registro nuevos de los procedimientos. 
        '    'dtproceNuevos = filtrarTabla(dtProcedimientos, DataViewRowState.Added, dtproceNuevos)
        '    dtProcedimXCentroCosto = filtrarProcedimientosXCentroDeCosto(dtProcedimientos)
        '    ''Se genera el xml que contiene la informacion de los registro a insertar
        '    xmlProceNuevos = ""

        '    If dtProcedimientos.Rows.Count > 0 Then
        '        intCountProcedimiento = dtProcedimientos.Rows.Count
        '    End If


        '    For i = 0 To dtProcedimXCentroCosto.Count - 1
        '        asignarSecuencia(dtProcedimXCentroCosto.Item(i))
        '        xmlProceNuevos = xmlProceNuevos & FuncionesGenerales.GenerarXMLxProcedimiento(dtProcedimXCentroCosto.Item(i))
        '    Next


        '    '----------------------------ORDENES GENERALES----------------------------  
        '    'Se buscan los registros modificados de las ordenes generales. Estas ordenes se inactivan
        '    'y se crea una nueva orden con los nuevos datos(Continuar, suspender)
        '    dtGeneralesModificados = filtrarTabla(dtGenerales, DataViewRowState.ModifiedCurrent, dtGeneralesModificados)
        '    ''Cambia el campo tratamiento que esta en null por I Iniciado
        '    procesarCampoTratamiento(dtGeneralesModificados, INICIA, Accion.Grabar)

        '    ''Se buscan los registros nuevos de las ordenes generales
        '    asignarSecuencia(dtGenerales)
        '    dtGeneralesNuevos = filtrarTabla(dtGenerales, DataViewRowState.Added, dtGeneralesNuevos)
        '    dtGeneralesNuevos = filtrarTabla(dtGenerales, DataViewRowState.ModifiedCurrent, dtGeneralesNuevos)
        '    ''Cambia el campo tratamiento que esta en null por I Iniciado
        '    procesarCampoTratamiento(dtGeneralesNuevos, INICIA, Accion.Grabar)

        '    ''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
        '    dtGeneralesModificados = configurarDataTableOrdenGeneralParaGrabar(dtGeneralesModificados)
        '    dtGeneralesNuevos = configurarDataTableOrdenGeneralParaGrabar(dtGeneralesNuevos)

        '    If dtGeneralesNuevos.Rows.Count > 0 Then
        '        intCountGenerales = dtGeneralesNuevos.Rows.Count
        '    End If

        '    xmlGeneralesModificados = FuncionesGenerales.GenerarXMLxProcedimiento(dtGeneralesModificados)
        '    xmlGeneralesNuevos = FuncionesGenerales.GenerarXMLxProcedimiento(dtGeneralesNuevos)


        '    ''Validar si existen datos para grabar 
        '    If dtDietasModificadas.Rows.Count <= 0 And dtDietasNuevas.Rows.Count <= 0 And _
        '        dtMedicaModificados.Rows.Count <= 0 And dtMedicaNuevos.Rows.Count <= 0 And _
        '        dtProcedimientos.Rows.Count <= 0 And dtGeneralesModificados.Rows.Count <= 0 And _
        '        dtGeneralesNuevos.Rows.Count <= 0 Then
        '        Return 999  ''No existen datos para guardar
        '    End If
        '    Dim daoOrden As New DAOOrdenes()


        '    ''Procedimiento que llama al stored procedure que graba

        '    lError = daoOrden.guardarOrdenes(objConexion, cod_pre_sgs, strCodSucur, tip_admision, num_adm, _
        '                            ano_adm, strLogin, medico, strCodEspecialidad, entidad, _
        '                            xmlDietasModifica, xmlDietasNuevas, xmlMedicaModificados, _
        '                            xmlMedicaNuevos, xmlProceNuevos, xmlGeneralesModificados, _
        '                            xmlGeneralesNuevos, NroOrden, fechaOrden, centroCostoOrigen, _
        '                            strGuia, strJustificacion, strTipoServicio, strPrioridad)
        '    ''cpgaray se cambia variable de centro de costo la otra iba vacia

        '    If lError <> 0 Then
        '        Return lError
        '    Else
        '        Dim objP As objPaciente = objpaciente.Instancia
        '        Dim strPrioridadtmp As String = strPrioridad

        '        If strPrioridadtmp = "" Then
        '            strPrioridadtmp = "3"
        '        End If

        '        For Each dr As DataRow In dtProcedimientos.Rows

        '            '           If dr("OrigenProcedim") = "ris" Then


        '            lError = daoOrden.guardarOrdenesAGFA(objConexion, "N", FuncionesGenerales.FechaServidor(), objpaciente.TipoDocumento & objpaciente.NumeroDocumento, objpaciente.PrimerNombre, objpaciente.PrimerApellido, objpaciente.FechaNacimiento, _
        '                                                    objpaciente.Genero, "", objpaciente.TipoAdmision, objpaciente.TipoAdmision & objpaciente.AnoAdmision & objpaciente.NumeroAdmision, NroOrden, dr("cod_sucur"), "", _
        '                                                    FuncionesGenerales.FechaServidor(), FuncionesGenerales.FechaServidor().AddDays(1), strPrioridadtmp, strLogin, strLogin, 0, dr("codigo_ris"), dr("codigo_ris"), fechaOrden, strJustificacion, dr("obs"), _
        '                                                    centroCostoOrigen, CCDestino, 0, strCodSucur, cod_pre_sgs)
        '            'End If
        '        Next
        '    End If


        '    Try
        '        daoOrden.GrabarAuditOrdenes(objConexion, cod_pre_sgs, strCodSucur, tip_admision, ano_adm, num_adm, _
        '        objpaciente.TipoDocumento & objpaciente.NumeroDocumento, strLogin, intCountMedicamento, intCountGenerales, _
        '        intCountDietas, intCountProcedimiento, NroOrden, "", "OR")
        '    Catch ex As Exception

        '    End Try

        '    Return lError
        'End Function
        Public Shared Function guardarOrdenes(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String,
                                                  ByVal strCodSucur As String, ByVal tip_admision As String,
                                                  ByVal num_adm As String, ByVal ano_adm As String, ByVal strLogin As String,
                                                  ByVal medico As String, ByVal strCodEspecialidad As String, ByVal entidad As String,
                                                  ByVal dtAislamientos As DataTable, ByVal dtDietas As DataTable, ByVal dtMedicamentos As DataTable,
                                                  ByVal dtProcedimientos As DataTable, ByVal dtGenerales As DataTable,
                                                  ByVal dtDatosPaciente As DataTable, ByRef NroOrden As Double, ByRef fechaOrden As Date,
                                                  ByRef centroCostoOrigen As String, ByRef strGuia As String,
                                                  ByRef strJustificacion As String, ByRef strTipoServicio As String,
                                                  ByRef strPrioridad As String, ByVal CodProcedim As String, ByVal DescripProcedim As String, ByRef InicioSesion As DateTime, Optional ByRef Practicaosi As String = "") As Long

            ''Dsanchez IG - Req 594 - 09/10/2017
            Dim dtAislamientosModificados As New DataTable
            Dim dtAislamientosNuevos As New DataTable
            Dim xmlAislamientosModificados As String = String.Empty
            Dim xmlAislamientosNuevos As String = String.Empty

            Dim dtDietasModificadas As New DataTable
            Dim dtDietasNuevas As New DataTable
            Dim xmlDietasModifica As String = ""
            Dim xmlDietasNuevas As String = ""

            Dim dtMedicaModificados As New DataTable
            Dim dtMedicaNuevos As New DataTable
            Dim xmlMedicaModificados As String = ""
            Dim xmlMedicaNuevos As String = ""

            Dim dtproceNuevos As New DataTable
            Dim dtProcedimXCentroCosto As ArrayList
            Dim xmlProceNuevos As String

            Dim dtGeneralesModificados As New DataTable
            Dim dtGeneralesNuevos As New DataTable
            Dim xmlGeneralesModificados As String
            Dim xmlGeneralesNuevos As String

            ''Claudia Garay Abril 05 2011 Auditoria Ordenes
            Dim intCountAislamientos As Integer = 0
            Dim intCountDietas As Integer = 0
            Dim intCountMedicamento As Integer = 0
            Dim intCountProcedimiento As Integer = 0
            Dim intCountGenerales As Integer = 0
            Dim objpaciente As Paciente
            Dim ObjGeneral As objGenerales
            objpaciente = Paciente.Instancia
            ObjGeneral = objGenerales.Instancia

            Dim lError As Long
            Dim i As Integer
            Dim intGuardar As Integer = 0
            Dim strMensaje As String = ""

            Dim daoOrden As New DAOOrdenes()
            Dim daogeneral As New DAOGeneral
            Dim Agfa As String

            Dim procedimHomologo As String = ""
            Dim entidadvalida As String = ""
            Dim strGeneraPedido As String = ""
            Dim strGeneraPedidoLabo As String = ""

            Dim dtproceris As New DataTable
            Dim intris As Integer = 0
            Dim intValida As Integer = 0
            Dim intGraba As Integer = 0

            Dim strCodSucuragfa As String

            Dim numPedido As Decimal

            dtAislamientosModificados = dtAislamientos.Clone()
            dtAislamientosNuevos = dtAislamientos.Clone()

            dtDietasModificadas = dtDietas.Clone()
            dtDietasNuevas = dtDietas.Clone()

            dtMedicaModificados = dtMedicamentos.Clone()
            dtMedicaNuevos = dtMedicamentos.Clone()

            dtproceNuevos = dtProcedimientos.Clone()

            dtGeneralesModificados = dtGenerales.Clone
            dtGeneralesNuevos = dtGenerales.Clone



            'consecutivo = daoGeneral.EjecutarSQLStrValor("hcEnfAlarma", objconexion, " max(consecutivo)", " cod_historia=" & cod_historia)

            ''intGuardar = daogeneral.EjecutarSQLStrValor("hcgrabarOrdenes", objConexion, "modo_guardar", " cod_pre_sgs='" & cod_pre_sgs & "' and cod_sucur='" & strCodSucur & "'")

            If IsDBNull(intGuardar) Then
                intGuardar = 0
            End If

            If intGuardar = 0 Then


                ''Dsanchez IG - Req 594 - 09/10/2017
                '----------------------------AISLAMIENTOS-----------------------------------
                ''Se buscan los aislamientos que han sido modificados
                dtAislamientosModificados = filtrarTabla(dtAislamientos, DataViewRowState.ModifiedCurrent, dtAislamientosModificados)
                ''Cambia el campo tratamiento cuando es Null al valor I por 
                procesarCampoTratamiento(dtAislamientosModificados, INICIA, Accion.Grabar)

                asignarSecuencia(dtAislamientos)

                ''Se buscan los aislamientos nuevos.Tambien se adicionan los registros 
                ''modificados ya que estos se insertan con un nuevo numero de orden quedando activos en la nueva orden.
                dtAislamientosNuevos = filtrarTabla(dtAislamientos, DataViewRowState.Added, dtAislamientosNuevos)
                dtAislamientosNuevos = filtrarTabla(dtAislamientos, DataViewRowState.ModifiedCurrent, dtAislamientosNuevos)

                ''Cambia el campo tratamiento cuando es Null al valor I por 
                procesarCampoTratamiento(dtAislamientosNuevos, INICIA, Accion.Grabar)

                ''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
                ''dtAislamientosModificados = configurarDataTableDietasParaGrabar(dtAislamientosModificados)
                ''dtAislamientosNuevos = configurarDataTableDietasParaGrabar(dtAislamientosNuevos)

                If dtAislamientosNuevos.Rows.Count > 0 Then
                    intCountDietas = dtAislamientosNuevos.Rows.Count
                End If

                ''Se generan los xml que contienen la informacion de las dietas
                xmlAislamientosModificados = FuncionesGenerales.GenerarXMLxProcedimiento(dtAislamientosModificados)
                xmlAislamientosNuevos = FuncionesGenerales.GenerarXMLxProcedimiento(dtAislamientosNuevos)

                '----------------------------DIETAS-----------------------------------
                ''Se buscan las dietas que han sido modificadas 
                dtDietasModificadas = filtrarTabla(dtDietas, DataViewRowState.ModifiedCurrent, dtDietasModificadas)
                ''Cambia el campo tratamiento cuando es Null al valor I por 
                procesarCampoTratamiento(dtDietasModificadas, INICIA, Accion.Grabar)

                asignarSecuencia(dtDietas)
                ''Se buscan las dietas nuevas.Tambien se adicionan los registros 
                ''modificados ya que estos se insertan con un nuevo numero de orden quedando activos en la nueva orden.
                dtDietasNuevas = filtrarTabla(dtDietas, DataViewRowState.Added, dtDietasNuevas)
                dtDietasNuevas = filtrarTabla(dtDietas, DataViewRowState.ModifiedCurrent, dtDietasNuevas)

                ''Cambia el campo tratamiento cuando es Null al valor I por 
                procesarCampoTratamiento(dtDietasNuevas, INICIA, Accion.Grabar)

                ''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
                dtDietasModificadas = configurarDataTableDietasParaGrabar(dtDietasModificadas)
                dtDietasNuevas = configurarDataTableDietasParaGrabar(dtDietasNuevas)

                If dtDietasNuevas.Rows.Count > 0 Then
                    intCountDietas = dtDietasNuevas.Rows.Count
                End If


                ''Se generan los xml que contienen la informacion de las dietas
                xmlDietasModifica = FuncionesGenerales.GenerarXMLxProcedimiento(dtDietasModificadas)
                xmlDietasNuevas = FuncionesGenerales.GenerarXMLxProcedimiento(dtDietasNuevas)

                '--------------------------MEDICAMENTOS--------------------------------
                ''Se buscan los medicamentos modificados 
                'If dtMedicaModificados.Rows.Count > 0 Then
                dtMedicaModificados = filtrarTabla(dtMedicamentos, DataViewRowState.ModifiedCurrent, dtMedicaModificados)
                ''Cambia el campo tratamiento que esta en null por I Iniciado
                procesarCampoTratamiento(dtMedicaModificados, INICIA, Accion.Grabar)
                'End If

                asignarSecuencia(dtMedicamentos)
                ''Se buscan  los medicamentos nuevos.Tambien se adicionan los registros 
                ''modificados ya que estos se insertan con un nuevo numero de orden quedando activos en la nueva orden.
                dtMedicaNuevos = filtrarTabla(dtMedicamentos, DataViewRowState.Added, dtMedicaNuevos)
                dtMedicaNuevos = filtrarTabla(dtMedicamentos, DataViewRowState.ModifiedCurrent, dtMedicaNuevos)
                ''Cambia el campo tratamiento que esta en null por I Iniciado
                procesarCampoTratamiento(dtMedicaNuevos, INICIA, Accion.Grabar)

                ''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
                'If dtMedicaModificados.Rows.Count > 0 Then
                dtMedicaModificados = configurarDataTableMedicaParaGrabar(dtMedicaModificados)
                'End If

                dtMedicaNuevos = configurarDataTableMedicaParaGrabar(dtMedicaNuevos)

                If dtMedicaNuevos.Rows.Count > 0 Then
                    intCountMedicamento = dtMedicaNuevos.Rows.Count
                End If

                ''Se generan los xml que contiene la informacion de los medicamentos
                xmlMedicaModificados = FuncionesGenerales.GenerarXMLxProcedimiento(dtMedicaModificados)
                xmlMedicaNuevos = FuncionesGenerales.GenerarXMLxProcedimiento(dtMedicaNuevos)


                '-------------------------PROCEDIMIENTOS --------------------------------

                ''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
                dtProcedimientos = configurarDataTableProcedimParaGrabar(dtProcedimientos)

                strGeneraPedidoLabo = "N"
                If dtProcedimientos.Rows.Count > 0 Then
                    procedimHomologo = ""
                    entidadvalida = ""
                    strGeneraPedido = ""
                    'strGeneraPedidoLabo = ""
                    For i = 0 To dtProcedimientos.Rows.Count - 1
                        daoOrden.ConsultarDatosGrabacionPedidosRis(cod_pre_sgs, strCodSucur, tip_admision, num_adm, ano_adm,
                        dtProcedimientos.Rows(i).Item("procedim").ToString, strGeneraPedido, procedimHomologo, IIf(IsDBNull(dtProcedimientos.Rows(i).Item("entidad")), "", dtProcedimientos.Rows(i).Item("entidad")), dtProcedimientos.Rows(i).Item("cen_cos_des").ToString)
                        ' agfa_orm_in herojas 2014/10/10 Si el procedimiento se realiza en la sede se hace pedido
                        If strGeneraPedido = "S" And (dtProcedimientos.Rows(i).Item("numconsulta").ToString = "1" _
                         Or dtProcedimientos.Rows(i).Item("numconsulta").ToString = "2" Or dtProcedimientos.Rows(i).Item("numconsulta").ToString = "5") Then
                            dtProcedimientos.Rows(i).Item("procedimhomologo") = procedimHomologo
                            dtProcedimientos.Rows(i).Item("entidadpedido") = IIf(IsDBNull(dtProcedimientos.Rows(i).Item("entidad")), "", dtProcedimientos.Rows(i).Item("entidad"))
                            If dtProcedimientos.Rows(i).Item("numconsulta").ToString = "5" Then
                                dtProcedimientos.Rows(i).Item("cod_Labor") = IIf(IsDBNull(dtProcedimientos.Rows(i).Item("codigo_ris")), "0", dtProcedimientos.Rows(i).Item("codigo_ris"))
                                dtProcedimientos.Rows(i).Item("codigo_ris") = ""
                                If dtProcedimientos.Rows(i).Item("grabaPedido") = "N" Then
                                    dtProcedimientos.Rows(i).Item("cod_Labor") = "0"
                                End If
                            Else
                                dtProcedimientos.Rows(i).Item("cod_Labor") = "0"
                                dtProcedimientos.Rows(i).Item("grabaPedido") = "S"
                            End If

                        Else
                            dtProcedimientos.Rows(i).Item("grabaPedido") = "N"
                            If dtProcedimientos.Rows(i).Item("numconsulta").ToString = "5" Then
                                dtProcedimientos.Rows(i).Item("cod_Labor") = IIf(IsDBNull(dtProcedimientos.Rows(i).Item("codigo_ris")), "0", dtProcedimientos.Rows(i).Item("codigo_ris"))
                                dtProcedimientos.Rows(i).Item("codigo_ris") = ""
                            Else
                                dtProcedimientos.Rows(i).Item("cod_Labor") = "0"
                            End If

                        End If
                        If dtProcedimientos.Rows(i).Item("tieneCcostoLabo") = "S" Then
                            strGeneraPedidoLabo = dtProcedimientos.Rows(i).Item("tieneCcostoLabo")
                        End If
                    Next

                End If

                ''Se buscan los registro nuevos de los procedimientos. 
                'dtproceNuevos = filtrarTabla(dtProcedimientos, DataViewRowState.Added, dtproceNuevos)                
                If strGeneraPedidoLabo = "N" Then
                    dtProcedimXCentroCosto = filtrarProcedimientosXCentroDeCosto(dtProcedimientos)
                Else
                    dtProcedimXCentroCosto = filtrarProcedimientosxEnt(dtProcedimientos)
                End If
                ''Se genera el xml que contiene la informacion de los registro a insertar
                xmlProceNuevos = ""

                If dtProcedimientos.Rows.Count > 0 Then
                    intCountProcedimiento = dtProcedimientos.Rows.Count
                End If

                For i = 0 To dtProcedimXCentroCosto.Count - 1
                    asignarSecuencia(dtProcedimXCentroCosto.Item(i))
                    'Joseph Moreno (IG) Fec:2019/11/25 Particularidades
                    'xmlProceNuevos = xmlProceNuevos & FuncionesGenerales.GenerarXMLxProcedimiento(dtProcedimXCentroCosto.Item(i))
                    xmlProceNuevos = xmlProceNuevos _
                                   & FuncionesGenerales.GenerarXMLxProcedimiento(
                                        dtProcedimXCentroCosto.Item(i),
                                        New HashSet(Of String)({"particularidades", "procedimientos"}
                                        )
                                   )
                Next

                '----------------------------ORDENES GENERALES----------------------------  
                'Se buscan los registros modificados de las ordenes generales. Estas ordenes se inactivan
                'y se crea una nueva orden con los nuevos datos(Continuar, suspender)
                dtGeneralesModificados = filtrarTabla(dtGenerales, DataViewRowState.ModifiedCurrent, dtGeneralesModificados)
                ''Cambia el campo tratamiento que esta en null por I Iniciado
                procesarCampoTratamiento(dtGeneralesModificados, INICIA, Accion.Grabar)

                ''Se buscan los registros nuevos de las ordenes generales
                asignarSecuencia(dtGenerales)
                dtGeneralesNuevos = filtrarTabla(dtGenerales, DataViewRowState.Added, dtGeneralesNuevos)
                dtGeneralesNuevos = filtrarTabla(dtGenerales, DataViewRowState.ModifiedCurrent, dtGeneralesNuevos)
                ''Cambia el campo tratamiento que esta en null por I Iniciado
                procesarCampoTratamiento(dtGeneralesNuevos, INICIA, Accion.Grabar)

                ''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
                dtGeneralesModificados = configurarDataTableOrdenGeneralParaGrabar(dtGeneralesModificados)
                dtGeneralesNuevos = configurarDataTableOrdenGeneralParaGrabar(dtGeneralesNuevos)

                If dtGeneralesNuevos.Rows.Count > 0 Then
                    intCountGenerales = dtGeneralesNuevos.Rows.Count
                End If

                xmlGeneralesModificados = FuncionesGenerales.GenerarXMLxProcedimiento(dtGeneralesModificados)
                xmlGeneralesNuevos = FuncionesGenerales.GenerarXMLxProcedimiento(dtGeneralesNuevos)


                ''Validar si existen datos para grabar 
                If dtAislamientosModificados.Rows.Count <= 0 And dtAislamientosNuevos.Rows.Count <= 0 And
                   dtDietasModificadas.Rows.Count <= 0 And dtDietasNuevas.Rows.Count <= 0 And
                   dtMedicaModificados.Rows.Count <= 0 And dtMedicaNuevos.Rows.Count <= 0 And
                   dtProcedimientos.Rows.Count <= 0 And dtGeneralesModificados.Rows.Count <= 0 And
                    dtGeneralesNuevos.Rows.Count <= 0 Then
                    Return 999  ''No existen datos para guardar
                End If



                ''Procedimiento que llama al stored procedure que graba
                Try
                    ''

                    BLOrdenes.GrabarErroresOrdenesMedicas("HistoriaMedicaCTC" & Mid(xmlMedicaNuevos, 1, 5000))
                    BLOrdenes.GrabarErroresOrdenesMedicas("HistoriaMedicaCTC" & Mid(xmlProceNuevos, 1, 5000))
                    BLOrdenes.GrabarErroresOrdenesMedicas("ORDENMEDICA" & Mid(xmlMedicaModificados, 1, 5000))

                    '' eloaiza@intergrupo - 30-08-2019
                    '' cambio en parametros para guardar ordenes.
                    Dim tipoParametro As String = BLOrdenes.ConsultarParametros("ParamObjsEnviarOrdenesMedicas")

                    If (String.IsNullOrEmpty(tipoParametro) Or tipoParametro.ToUpperInvariant().Trim() = "XML") Then
                        If strGeneraPedidoLabo = "N" Then
                            lError = daoOrden.guardarOrdenes(objConexion, cod_pre_sgs, strCodSucur, tip_admision, num_adm,
                                                                               ano_adm, strLogin, medico, strCodEspecialidad, entidad,
                                                                               xmlAislamientosModificados, xmlAislamientosNuevos,
                                                                               xmlDietasModifica, xmlDietasNuevas, xmlMedicaModificados,
                                                                               xmlMedicaNuevos, xmlProceNuevos, xmlGeneralesModificados,
                                                                               xmlGeneralesNuevos, NroOrden, fechaOrden, centroCostoOrigen,
                                                                               strGuia, strJustificacion, strTipoServicio, strPrioridad, InicioSesion)
                        Else
                            lError = daoOrden.guardarOrdenesLabo(objConexion, cod_pre_sgs, strCodSucur, tip_admision, num_adm,
                                                                               ano_adm, strLogin, medico, strCodEspecialidad, entidad,
                                                                               xmlAislamientosModificados, xmlAislamientosNuevos,
                                                                               xmlDietasModifica, xmlDietasNuevas, xmlMedicaModificados,
                                                                               xmlMedicaNuevos, xmlProceNuevos, xmlGeneralesModificados,
                                                                               xmlGeneralesNuevos, NroOrden, fechaOrden, centroCostoOrigen,
                                                                               strGuia, strJustificacion, strTipoServicio, strPrioridad)

                        End If
                    ElseIf (tipoParametro.ToUpperInvariant().Trim() = "DATATABLE") Then
                        'Es necesario asegurar que el orden de las colunas sea el mismo que los Type de la BD para evitar errores al momento de pasar los parametros 
                        'en el procedimiento'
                        dtAislamientosNuevos = Comunes.FuncionesGenerales.ReOrganizarColumnasEnDatatable(dtAislamientosNuevos, columnasAislamientos)
                        dtAislamientosModificados = Comunes.FuncionesGenerales.ReOrganizarColumnasEnDatatable(dtAislamientosModificados, columnasAislamientos)

                        dtDietasNuevas = Comunes.FuncionesGenerales.ReOrganizarColumnasEnDatatable(dtDietasNuevas, columnasDietas)
                        dtDietasModificadas = Comunes.FuncionesGenerales.ReOrganizarColumnasEnDatatable(dtDietasModificadas, columnasDietas)

                        dtGeneralesNuevos = Comunes.FuncionesGenerales.ReOrganizarColumnasEnDatatable(dtGeneralesNuevos, columnasGenerales)
                        dtGeneralesNuevos.Columns.Remove("Frecuencia")
                        dtGeneralesNuevos.Columns.Remove("Observaciones")

                        dtGeneralesModificados = Comunes.FuncionesGenerales.ReOrganizarColumnasEnDatatable(dtGeneralesModificados, columnasGenerales)
                        dtGeneralesModificados.Columns.Remove("Frecuencia")
                        dtGeneralesModificados.Columns.Remove("Observaciones")

                        dtMedicaNuevos.Columns.Remove("tmp_suspender_med")
                        dtMedicaNuevos.Columns.Remove("tmp_modificar_med")
                        dtMedicaModificados.Columns.Remove("tmp_suspender_med")
                        dtMedicaModificados.Columns.Remove("tmp_modificar_med")

                        dtMedicaNuevos = Comunes.FuncionesGenerales.ReOrganizarColumnasEnDatatable(dtMedicaNuevos, columnasMedicamentos)
                        dtMedicaModificados = Comunes.FuncionesGenerales.ReOrganizarColumnasEnDatatable(dtMedicaModificados, columnasMedicamentos)

                        dtProcedimientos = Comunes.FuncionesGenerales.ReOrganizarColumnasEnDatatable(dtProcedimientos, columnasProcedimientos)
                        ' Se eliminan estas dos columnas que son temporales

                        lError = daoOrden.guardarOrdenes(objConexion, cod_pre_sgs, strCodSucur, tip_admision, num_adm,
                                                         ano_adm, strLogin, medico, strCodEspecialidad, entidad,
                                                         dtAislamientosModificados, dtAislamientosNuevos,
                                                         dtDietasModificadas, dtDietasNuevas, dtMedicaModificados,
                                                         dtMedicaNuevos, dtProcedimientos, dtGeneralesModificados,
                                                         dtGeneralesNuevos, dtDatosPaciente, NroOrden, fechaOrden, centroCostoOrigen,
                                                         strGuia, strJustificacion, strTipoServicio, strPrioridad, InicioSesion)
                    Else
                        Throw New Exception("El valor para el parametro ParamObjsEnviarOrdenesMedicas no es válido")
                    End If


                Catch ex As Exception
                    BLOrdenes.GrabarErroresOrdenesMedicas("HistoriaMedica" & ex.Message)
                    MsgBox("Error al guardar ordenes " & ex.Message)
                End Try

                If lError <> 0 Then
                    Return lError
                Else
                    Dim objP As objPaciente = objpaciente.Instancia
                    Dim strPrioridadtmp As String = strPrioridad

                    If strPrioridadtmp = "" Then
                        ' se le agrega cambio de prioridad por urgente cuando el procedimiento es para U o para una H
                        ' Realizado herojas, cambio solicitado por ORM - Agfa
                        If objpaciente.TipoAdmision = "U" Or objpaciente.TipoAdmision = "H" Then
                            strPrioridadtmp = "1"
                        Else
                            strPrioridadtmp = "3"
                        End If
                    End If



                    Agfa = daogeneral.EjecutarSQLStrValor("gensucur (nolock)", objConexion, " agfa", " cod_sucur='" & strCodSucur & "'")
                    If IIf(IsDBNull(Agfa), "N", Agfa) = "S" Then

                        If Len(strCodSucur) = 3 Then
                            strCodSucuragfa = "0" & strCodSucur
                        Else
                            strCodSucuragfa = strCodSucur
                        End If


                        For Each dr As DataRow In dtProcedimientos.Rows

                            ' Evalua procedimiento ris es realizado en la sede numconsulta="2"

                            If dr("OrigenProcedim") = "RIS" And dr("numconsulta") = 2 Then

                                'agfa_orm_in herojas traer el numero del pedido en la variable nuor mPedido
                                daoOrden.ConsultarDatosPedidoOrdenRis(dr("cod_pre_sgs"), dr("cod_sucur"), objpaciente.TipoAdmision, objpaciente.NumeroAdmision, objpaciente.AnoAdmision, NroOrden, dr("procedim"), numPedido)

                                dtproceris = daogeneral.EjecutarSQLConParametros("genproceris", objConexion, "cod_sucur", " codigo_ris='" & dr("codigo_ris") & "' and procedim='" & dr("procedim") & "'")

                                intGraba = intGraba + 1
                                ' se concatena la sucursal a la admision. Solicitud agfa proyecto agfa_orm_in herojas
                                ' se le agrega la entidad 2014/09/15 agfa_orm_in
                                ' se le agregan los parametros tipo, año y numero de admision herojas 2015/02/11
                                'CCGUTIEREZ - OSI. 07/09/2020. Se agrega parametro dr("particularidades")
                                ''CCGUTIEREZ - OSI. 28/06/2021. Se agrega parametro dr("procedimientos")
                                lError = daoOrden.guardarOrdenesAGFA(objConexion, "N", FuncionesGenerales.FechaServidor(), objpaciente.TipoDocumento & objpaciente.NumeroDocumento,
                                         objpaciente.PrimerNombre, objpaciente.PrimerApellido, objpaciente.FechaNacimiento,
                                         objpaciente.Genero, "", objpaciente.TipoAdmision,
                                         objpaciente.TipoAdmision & objpaciente.AnoAdmision & objpaciente.NumeroAdmision & "-" & strCodSucuragfa,
                                         NroOrden, dr("cod_sucur"), NroOrden, FuncionesGenerales.FechaServidor(),
                                         FuncionesGenerales.FechaServidor().AddDays(1), strPrioridadtmp, strLogin, strLogin,
                                         0, dr("codigo_ris"), dr("descripcion_proce"), fechaOrden, strJustificacion, dr("obs"),
                                        dr("cen_cos_origen"), dr("cen_cos_des"), numPedido, strCodSucur, cod_pre_sgs,
                                        dr("entidad"), dr("procedim"), ObjGeneral.NombreMedico,
                                        objpaciente.AnoAdmision, objpaciente.NumeroAdmision, dr("particularidades"), dr("procedimientos"), intGraba)


                            End If
                        Next
                    End If
                    'If IIf(IsDBNull(Agfa), "N", Agfa) = "S" Then

                    '            If Len(strCodSucur) = 3 Then
                    '                strCodSucuragfa = "0" & strCodSucur
                    '            Else
                    '                strCodSucuragfa = strCodSucur
                    '            End If


                    '    For Each dr As DataRow In dtProcedimientos.Rows

                    '        If dr("OrigenProcedim") = "ris" Then

                    '                    'agfa_orm_in herojas traer el numero del pedido en la variable numPedido
                    '                    daoOrden.ConsultarDatosPedidoOrdenRis(dr("cod_pre_sgs"), dr("cod_sucur"), objpaciente.TipoAdmision, objpaciente.NumeroAdmision, objpaciente.AnoAdmision, NroOrden, dr("procedim"), numPedido)

                    '            dtproceris = daogeneral.EjecutarSQLConParametros("genproceris", objConexion, "cod_sucur", " codigo_ris='" & dr("codigo_ris") & "' and procedim='" & dr("procedim") & "'")

                    '            If dtproceris.Rows.Count > 0 Then

                    '                If dtproceris.Rows.Count = 1 Then

                    '                    If dtproceris.Rows(intris).Item("cod_sucur").ToString = strCodSucur Then '' se practica en la sucursal
                    '                        intGraba = intGraba + 1
                    '                                ' se concatena la sucursal a la admision. Solicitud agfa proyecto agfa_orm_in herojas
                    '                                ' se le agrega la entidad 2014/09/15 agfa_orm_in
                    '                                lError = daoOrden.guardarOrdenesAGFA(objConexion, "N", FuncionesGenerales.FechaServidor(), objpaciente.TipoDocumento & objpaciente.NumeroDocumento, _
                    '                                         objpaciente.PrimerNombre, objpaciente.PrimerApellido, objpaciente.FechaNacimiento, _
                    '                                         objpaciente.Genero, "", objpaciente.TipoAdmision, _
                    '                                         objpaciente.TipoAdmision & objpaciente.AnoAdmision & objpaciente.NumeroAdmision & "-" & strCodSucuragfa, _
                    '                                         NroOrden, dr("cod_sucur"), "", FuncionesGenerales.FechaServidor(), _
                    '                                         FuncionesGenerales.FechaServidor().AddDays(1), strPrioridadtmp, strLogin, strLogin, _
                    '                                         0, dr("codigo_ris"), dr("descripcion_proce"), fechaOrden, strJustificacion, dr("obs"), _
                    '                                        dr("cen_cos_origen"), dr("cen_cos_des"), numPedido, strCodSucur, cod_pre_sgs, _
                    '                                        dr("entidad"), dr("procedim"), ObjGeneral.NombreMedico, intGraba)
                    '                    Else
                    '                        'Practicaosi = "EL PROCEDIMIENTO NO SE REALIZA EN ESTA INSTITUCIÓN"
                    '                        Practicaosi = "EL PROCEDIMIENTO NO SE REALIZA EN ESTA SEDE"
                    '                                If numPedido > 0 Then
                    '                                    daoOrden.AnulaPedidoSophia(dr("cod_pre_sgs"), dr("cod_sucur"), dr("cen_cos_des"), numPedido, strLogin, Practicaosi)
                    '                                End If
                    '                    End If

                    '                Else

                    '                    For intris = 0 To dtproceris.Rows.Count - 1

                    '                        If dtproceris.Rows(intris).Item("cod_sucur").ToString = strCodSucur Then '' se practica en la sucursal
                    '                                    ' se concatena la sucursal a la admision. Solicitud agfa proyecto orm herojas
                    '                                    intGraba = intGraba + 1 'intValida = intValida + 1
                    '                                    lError = daoOrden.guardarOrdenesAGFA(objConexion, "N", FuncionesGenerales.FechaServidor(), _
                    '                                        objpaciente.TipoDocumento & objpaciente.NumeroDocumento, objpaciente.PrimerNombre, _
                    '                                        objpaciente.PrimerApellido, objpaciente.FechaNacimiento, objpaciente.Genero, "", _
                    '                                        objpaciente.TipoAdmision, objpaciente.TipoAdmision & objpaciente.AnoAdmision & objpaciente.NumeroAdmision & "-" & strCodSucuragfa, _
                    '                                        NroOrden, dr("cod_sucur"), "", FuncionesGenerales.FechaServidor(), _
                    '                                        FuncionesGenerales.FechaServidor().AddDays(1), strPrioridadtmp, strLogin, strLogin, 0, _
                    '                                        dr("codigo_ris"), dr("descripcion_proce"), fechaOrden, strJustificacion, dr("obs"), _
                    '                                        dr("cen_cos_origen"), dr("cen_cos_des"), numPedido, strCodSucur, cod_pre_sgs, _
                    '                                        dr("entidad"), dr("procedim"), ObjGeneral.NombreMedico, intGraba)
                    '                            Exit For
                    '                        End If

                    '                    Next
                    '                End If
                    '            Else

                    '                Practicaosi = "EL PROCEDIMIENTO NO SE REALIZA EN ESTA INSTITUCIÓN"
                    '                        If numPedido > 0 Then
                    '                            daoOrden.AnulaPedidoSophia(dr("cod_pre_sgs"), dr("cod_sucur"), dr("cen_cos_des"), numPedido, strLogin, Practicaosi)
                    '                        End If

                    '            End If


                    '        Else

                    '            If Mid(dr("procedim"), 1, 3) = "402" Then ''Procedimientos de radiologia

                    '                dtproceris = daogeneral.EjecutarSQLConParametros("genproceris", objConexion, "cod_sucur", "procedim='" & dr("procedim") & "'")

                    '                If dtproceris.Rows.Count > 0 Then

                    '                    If dtproceris.Rows.Count = 1 Then

                    '                        If dtproceris.Rows(intris).Item("cod_sucur").ToString <> strCodSucur Then
                    '                            Practicaosi = "EL PROCEDIMIENTO NO SE REALIZA EN ESTA SEDE"
                    '                                    If numPedido > 0 Then
                    '                                        daoOrden.AnulaPedidoSophia(dr("cod_pre_sgs"), dr("cod_sucur"), dr("cen_cos_des"), numPedido, strLogin, Practicaosi)
                    '                                    End If
                    '                        End If

                    '                    Else

                    '                        For intris = 0 To dtproceris.Rows.Count - 1

                    '                            If dtproceris.Rows(intris).Item("cod_sucur").ToString = strCodSucur Then '' se practica en la sucursal
                    '                                intValida = 0
                    '                                Exit For
                    '                            Else
                    '                                intValida = intValida + 1
                    '                            End If

                    '                        Next
                    '                    End If

                    '                End If

                    '            End If
                    '        End If
                    '                If intValida = 0 Then
                    '            Practicaosi = "EL PROCEDIMIENTO NO SE REALIZA EN ESTA SEDE"
                    '                    If numPedido > 0 Then
                    '                        daoOrden.AnulaPedidoSophia(dr("cod_pre_sgs"), dr("cod_sucur"), dr("cen_cos_des"), numPedido, strLogin, Practicaosi)
                    '                    End If
                    '        End If
                    '    Next
                    'End If
                    'End If
                End If

            Else

                lError = GrabarOrdenesNutricion(objConexion, cod_pre_sgs, strCodSucur, tip_admision, num_adm, ano_adm,
                         strLogin, medico, strCodEspecialidad, entidad, dtDietas, NroOrden, fechaOrden, intCountDietas)

                If lError <> 0 Then
                    strMensaje = " -Dietas"
                End If


                lError = GrabarOrdenesMedicamentos(objConexion, cod_pre_sgs, strCodSucur, tip_admision, num_adm, ano_adm,
                strLogin, medico, strCodEspecialidad, entidad, dtMedicamentos, NroOrden, fechaOrden, intCountMedicamento)

                If lError <> 0 Then
                    strMensaje = +" -Medicamentos"
                End If

                lError = GrabarOrdenesProcedimientos(objConexion, cod_pre_sgs, strCodSucur, tip_admision, num_adm, ano_adm,
                strLogin, medico, strCodEspecialidad, entidad, dtProcedimientos, NroOrden, fechaOrden, centroCostoOrigen, strGuia,
                strJustificacion, strTipoServicio, strPrioridad, CodProcedim, intCountProcedimiento)

                If lError <> 0 Then
                    strMensaje = +" -Procedimientos"
                End If

                lError = GrabarOrdenesGenerales(objConexion, cod_pre_sgs, strCodSucur, tip_admision, num_adm, ano_adm,
                strLogin, medico, strCodEspecialidad, entidad, dtGenerales, NroOrden, fechaOrden, intCountGenerales)

                If lError <> 0 Then
                    strMensaje = +" -Generales"
                End If

                If Len(strMensaje) > 0 Then
                    MsgBox("Error al grabar Ordenes " & strMensaje)
                End If


            End If

            Try
                daoOrden.GrabarAuditOrdenes(objConexion, cod_pre_sgs, strCodSucur, tip_admision, ano_adm, num_adm,
                objpaciente.TipoDocumento & objpaciente.NumeroDocumento, strLogin, intCountMedicamento, intCountGenerales,
                intCountDietas, intCountProcedimiento, NroOrden, strMensaje & CStr(lError), "OR")
            Catch ex As Exception

            End Try

            Return lError
        End Function
        Public Shared Function GrabarOrdenesNutricion(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String,
                                                     ByVal strCodSucur As String, ByVal tip_admision As String,
                                                     ByVal num_adm As String, ByVal ano_adm As String, ByVal strLogin As String,
                                                     ByVal medico As String, ByVal strCodEspecialidad As String, ByVal entidad As String,
                                                     ByVal dtDietas As DataTable, ByRef NroOrden As Double, ByRef fechaOrden As Date,
                                                     ByRef intCountDietas As Integer) As Long



            Dim dtDietasModificadas As New DataTable
            Dim dtDietasNuevas As New DataTable
            Dim xmlDietasModifica As String = ""
            Dim xmlDietasNuevas As String = ""


            Dim objpaciente As Paciente
            objpaciente = Paciente.Instancia

            Dim lError As Long

            Dim daoOrden As New DAOOrdenes()
            Dim daogeneral As New DAOGeneral

            dtDietasModificadas = dtDietas.Clone()
            dtDietasNuevas = dtDietas.Clone()

            '----------------------------DIETAS-----------------------------------
            ''Se buscan las dietas que han sido modificadas 
            dtDietasModificadas = filtrarTabla(dtDietas, DataViewRowState.ModifiedCurrent, dtDietasModificadas)
            ''Cambia el campo tratamiento cuando es Null al valor I por 
            procesarCampoTratamiento(dtDietasModificadas, INICIA, Accion.Grabar)

            asignarSecuencia(dtDietas)
            ''Se buscan las dietas nuevas.Tambien se adicionan los registros 
            ''modificados ya que estos se insertan con un nuevo numero de orden quedando activos en la nueva orden.
            dtDietasNuevas = filtrarTabla(dtDietas, DataViewRowState.Added, dtDietasNuevas)
            dtDietasNuevas = filtrarTabla(dtDietas, DataViewRowState.ModifiedCurrent, dtDietasNuevas)

            ''Cambia el campo tratamiento cuando es Null al valor I por 
            procesarCampoTratamiento(dtDietasNuevas, INICIA, Accion.Grabar)

            ''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
            dtDietasModificadas = configurarDataTableDietasParaGrabar(dtDietasModificadas)
            dtDietasNuevas = configurarDataTableDietasParaGrabar(dtDietasNuevas)

            If dtDietasNuevas.Rows.Count > 0 Then
                intCountDietas = dtDietasNuevas.Rows.Count
            End If


            ''Se generan los xml que contienen la informacion de las dietas
            xmlDietasModifica = FuncionesGenerales.GenerarXMLxProcedimiento(dtDietasModificadas)
            xmlDietasNuevas = FuncionesGenerales.GenerarXMLxProcedimiento(dtDietasNuevas)


            ''Validar si existen datos para grabar 
            If dtDietasModificadas.Rows.Count <= 0 And dtDietasNuevas.Rows.Count <= 0 Then
                Exit Function
            End If

            ''Procedimiento que llama al stored procedure que graba

            lError = daoOrden.guardarOrdenesNutricion(objConexion, cod_pre_sgs, strCodSucur, tip_admision, num_adm,
                                               ano_adm, strLogin, medico, strCodEspecialidad, entidad,
                                               xmlDietasModifica, xmlDietasNuevas, NroOrden, fechaOrden)


        End Function
        Public Shared Function GrabarOrdenesMedicamentos(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String,
                                                    ByVal strCodSucur As String, ByVal tip_admision As String,
                                                    ByVal num_adm As String, ByVal ano_adm As String, ByVal strLogin As String,
                                                    ByVal medico As String, ByVal strCodEspecialidad As String, ByVal entidad As String,
                                                    ByVal dtMedicamentos As DataTable, ByRef NroOrden As Double, ByRef fechaOrden As Date,
                                                    ByRef intCountMedicamento As Integer) As Long




            Dim dtMedicaModificados As New DataTable
            Dim dtMedicaNuevos As New DataTable
            Dim xmlMedicaModificados As String = ""
            Dim xmlMedicaNuevos As String = ""

            Dim objpaciente As Paciente
            objpaciente = Paciente.Instancia

            Dim lError As Long

            Dim daoOrden As New DAOOrdenes()
            Dim daogeneral As New DAOGeneral

            dtMedicaModificados = dtMedicamentos.Clone()
            dtMedicaNuevos = dtMedicamentos.Clone()
            '--------------------------MEDICAMENTOS--------------------------------
            ''Se buscan los medicamentos modificados 
            dtMedicaModificados = filtrarTabla(dtMedicamentos, DataViewRowState.ModifiedCurrent, dtMedicaModificados)
            ''Cambia el campo tratamiento que esta en null por I Iniciado
            procesarCampoTratamiento(dtMedicaModificados, INICIA, Accion.Grabar)

            asignarSecuencia(dtMedicamentos)
            ''Se buscan  los medicamentos nuevos.Tambien se adicionan los registros 
            ''modificados ya que estos se insertan con un nuevo numero de orden quedando activos en la nueva orden.
            dtMedicaNuevos = filtrarTabla(dtMedicamentos, DataViewRowState.Added, dtMedicaNuevos)
            dtMedicaNuevos = filtrarTabla(dtMedicamentos, DataViewRowState.ModifiedCurrent, dtMedicaNuevos)
            ''Cambia el campo tratamiento que esta en null por I Iniciado
            procesarCampoTratamiento(dtMedicaNuevos, INICIA, Accion.Grabar)

            ''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
            dtMedicaModificados = configurarDataTableMedicaParaGrabar(dtMedicaModificados)
            dtMedicaNuevos = configurarDataTableMedicaParaGrabar(dtMedicaNuevos)

            If dtMedicaNuevos.Rows.Count > 0 Then
                intCountMedicamento = dtMedicaNuevos.Rows.Count
            End If

            ''Se generan los xml que contiene la informacion de los medicamentos
            xmlMedicaModificados = FuncionesGenerales.GenerarXMLxProcedimiento(dtMedicaModificados)
            xmlMedicaNuevos = FuncionesGenerales.GenerarXMLxProcedimiento(dtMedicaNuevos)




            ''Validar si existen datos para grabar 
            If dtMedicaModificados.Rows.Count <= 0 And dtMedicaNuevos.Rows.Count <= 0 Then
                Exit Function
            End If

            ''Procedimiento que llama al stored procedure que graba

            lError = daoOrden.guardarOrdenesMedicamentos(objConexion, cod_pre_sgs, strCodSucur, tip_admision, num_adm,
                                               ano_adm, strLogin, medico, strCodEspecialidad, entidad,
                                               xmlMedicaModificados, xmlMedicaNuevos, NroOrden, fechaOrden)


        End Function
        Public Shared Function GrabarOrdenesProcedimientos(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String,
                                                    ByVal strCodSucur As String, ByVal tip_admision As String,
                                                    ByVal num_adm As String, ByVal ano_adm As String, ByVal strLogin As String,
                                                    ByVal medico As String, ByVal strCodEspecialidad As String, ByVal entidad As String,
                                                    ByVal dtProcedimientos As DataTable, ByRef NroOrden As Double, ByRef fechaOrden As Date,
                                                    ByRef centroCostoOrigen As String, ByRef strGuia As String,
                                                    ByRef strJustificacion As String, ByRef strTipoServicio As String,
                                                    ByRef strPrioridad As String, ByVal CodProcedim As String, ByRef intCountProcedimiento As Integer) As Long




            Dim dtproceNuevos As New DataTable
            Dim dtProcedimXCentroCosto As ArrayList
            Dim xmlProceNuevos As String


            Dim objpaciente As Paciente
            objpaciente = Paciente.Instancia

            Dim lError As Long
            Dim i As Integer

            Dim daoOrden As New DAOOrdenes()
            Dim daogeneral As New DAOGeneral


            dtproceNuevos = dtProcedimientos.Clone()

            '-------------------------PROCEDIMIENTOS--------------------------------

            ''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
            dtProcedimientos = configurarDataTableProcedimParaGrabar(dtProcedimientos)

            ''Se buscan los registro nuevos de los procedimientos. 
            'dtproceNuevos = filtrarTabla(dtProcedimientos, DataViewRowState.Added, dtproceNuevos)
            dtProcedimXCentroCosto = filtrarProcedimientosXCentroDeCosto(dtProcedimientos)
            ''Se genera el xml que contiene la informacion de los registro a insertar
            xmlProceNuevos = ""

            If dtProcedimientos.Rows.Count > 0 Then
                intCountProcedimiento = dtProcedimientos.Rows.Count
            End If


            For i = 0 To dtProcedimXCentroCosto.Count - 1
                asignarSecuencia(dtProcedimXCentroCosto.Item(i))
                'Joseph Moreno (IG) Fec:2019/11/26 Particularidades
                'xmlProceNuevos = xmlProceNuevos & FuncionesGenerales.GenerarXMLxProcedimiento(dtProcedimXCentroCosto.Item(i))
                xmlProceNuevos = xmlProceNuevos _
                               & FuncionesGenerales.GenerarXMLxProcedimiento(
                                       dtProcedimXCentroCosto.Item(i),
                                       New HashSet(Of String)({"particularidades", "procedimientos"})
                                 )
            Next



            ''Validar si existen datos para grabar 
            If dtProcedimientos.Rows.Count <= 0 Then
                Exit Function
            End If

            ''Procedimiento que llama al stored procedure que graba

            lError = daoOrden.guardarOrdenesProcedimientos(objConexion, cod_pre_sgs, strCodSucur, tip_admision, num_adm,
                                               ano_adm, strLogin, medico, strCodEspecialidad, entidad,
                                               xmlProceNuevos, NroOrden, fechaOrden, centroCostoOrigen,
                                               strGuia, strJustificacion, strTipoServicio, strPrioridad)


        End Function
        Public Shared Function GrabarOrdenesGenerales(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String,
                                                    ByVal strCodSucur As String, ByVal tip_admision As String,
                                                    ByVal num_adm As String, ByVal ano_adm As String, ByVal strLogin As String,
                                                    ByVal medico As String, ByVal strCodEspecialidad As String, ByVal entidad As String,
                                                    ByVal dtGenerales As DataTable, ByRef NroOrden As Double, ByRef fechaOrden As Date,
                                                    ByRef intCountGenerales As Integer) As Long




            Dim dtGeneralesModificados As New DataTable
            Dim dtGeneralesNuevos As New DataTable
            Dim xmlGeneralesModificados As String
            Dim xmlGeneralesNuevos As String


            Dim objpaciente As Paciente
            objpaciente = Paciente.Instancia

            Dim lError As Long
            Dim i As Integer
            Dim intGuardar As Integer

            Dim daoOrden As New DAOOrdenes()
            Dim daogeneral As New DAOGeneral



            dtGeneralesModificados = dtGenerales.Clone
            dtGeneralesNuevos = dtGenerales.Clone



            '----------------------------ORDENES GENERALES----------------------------  
            'Se buscan los registros modificados de las ordenes generales. Estas ordenes se inactivan
            'y se crea una nueva orden con los nuevos datos(Continuar, suspender)
            dtGeneralesModificados = filtrarTabla(dtGenerales, DataViewRowState.ModifiedCurrent, dtGeneralesModificados)
            ''Cambia el campo tratamiento que esta en null por I Iniciado
            procesarCampoTratamiento(dtGeneralesModificados, INICIA, Accion.Grabar)

            ''Se buscan los registros nuevos de las ordenes generales
            asignarSecuencia(dtGenerales)
            dtGeneralesNuevos = filtrarTabla(dtGenerales, DataViewRowState.Added, dtGeneralesNuevos)
            dtGeneralesNuevos = filtrarTabla(dtGenerales, DataViewRowState.ModifiedCurrent, dtGeneralesNuevos)
            ''Cambia el campo tratamiento que esta en null por I Iniciado
            procesarCampoTratamiento(dtGeneralesNuevos, INICIA, Accion.Grabar)

            ''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
            dtGeneralesModificados = configurarDataTableOrdenGeneralParaGrabar(dtGeneralesModificados)
            dtGeneralesNuevos = configurarDataTableOrdenGeneralParaGrabar(dtGeneralesNuevos)

            If dtGeneralesNuevos.Rows.Count > 0 Then
                intCountGenerales = dtGeneralesNuevos.Rows.Count
            End If

            xmlGeneralesModificados = FuncionesGenerales.GenerarXMLxProcedimiento(dtGeneralesModificados)
            xmlGeneralesNuevos = FuncionesGenerales.GenerarXMLxProcedimiento(dtGeneralesNuevos)


            ''Validar si existen datos para grabar 
            If dtGeneralesModificados.Rows.Count <= 0 And dtGeneralesNuevos.Rows.Count <= 0 Then
                Exit Function
            End If

            ''Procedimiento que llama al stored procedure que graba

            lError = daoOrden.guardarOrdenesGenerales(objConexion, cod_pre_sgs, strCodSucur, tip_admision, num_adm,
                                               ano_adm, strLogin, medico, strCodEspecialidad, entidad,
                                               xmlGeneralesModificados, xmlGeneralesNuevos, NroOrden, fechaOrden)


        End Function

        Public Shared Function verificoOrdenes(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String,
                                                    ByVal strCodSucur As String, ByVal tip_admision As String,
                                                    ByVal num_adm As String, ByVal ano_adm As String, ByVal strLogin As String,
                                                    ByVal medico As String, ByVal strCodEspecialidad As String, ByVal entidad As String,
                                                    ByVal dtDietas As DataTable, ByVal dtMedicamentos As DataTable,
                                                    ByVal dtProcedimientos As DataTable, ByVal dtGenerales As DataTable,
                                                    ByRef NroOrden As Double, ByRef fechaOrden As Date,
                                                    ByRef centroCostoOrigen As String) As Long

            Dim dtDietasModificadas As New DataTable
            Dim dtDietasNuevas As New DataTable
            Dim xmlDietasModifica As String = ""
            Dim xmlDietasNuevas As String = ""

            Dim dtMedicaModificados As New DataTable
            Dim dtMedicaNuevos As New DataTable
            Dim xmlMedicaModificados As String = ""
            Dim xmlMedicaNuevos As String = ""

            Dim dtproceNuevos As New DataTable
            Dim dtProcedimXCentroCosto As ArrayList
            Dim xmlProceNuevos As String

            Dim dtGeneralesModificados As New DataTable
            Dim dtGeneralesNuevos As New DataTable
            Dim xmlGeneralesModificados As String
            Dim xmlGeneralesNuevos As String

            Dim lError As Long
            Dim i As Integer


            dtDietasModificadas = dtDietas.Clone()
            dtDietasNuevas = dtDietas.Clone()

            dtMedicaModificados = dtMedicamentos.Clone()
            dtMedicaNuevos = dtMedicamentos.Clone()

            dtproceNuevos = dtProcedimientos.Clone()

            dtGeneralesModificados = dtGenerales.Clone
            dtGeneralesNuevos = dtGenerales.Clone

            '----------------------------DIETAS-----------------------------------
            ''Se buscan las dietas que han sido modificadas 
            dtDietasModificadas = filtrarTabla(dtDietas, DataViewRowState.ModifiedCurrent, dtDietasModificadas)
            ''Cambia el campo tratamiento cuando es Null al valor I por 
            procesarCampoTratamiento(dtDietasModificadas, INICIA, Accion.Grabar)

            asignarSecuencia(dtDietas)
            ''Se buscan las dietas nuevas.Tambien se adicionan los registros 
            ''modificados ya que estos se insertan con un nuevo numero de orden quedando activos en la nueva orden.
            dtDietasNuevas = filtrarTabla(dtDietas, DataViewRowState.Added, dtDietasNuevas)
            dtDietasNuevas = filtrarTabla(dtDietas, DataViewRowState.ModifiedCurrent, dtDietasNuevas)

            ''Cambia el campo tratamiento cuando es Null al valor I por 
            procesarCampoTratamiento(dtDietasNuevas, INICIA, Accion.Grabar)

            ''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
            dtDietasModificadas = configurarDataTableDietasParaGrabar(dtDietasModificadas)
            dtDietasNuevas = configurarDataTableDietasParaGrabar(dtDietasNuevas)

            ''Se generan los xml que contienen la informacion de las dietas
            xmlDietasModifica = FuncionesGenerales.GenerarXMLxProcedimiento(dtDietasModificadas)
            xmlDietasNuevas = FuncionesGenerales.GenerarXMLxProcedimiento(dtDietasNuevas)

            '--------------------------MEDICAMENTOS--------------------------------
            ''Se buscan los medicamentos modificados 
            dtMedicaModificados = filtrarTabla(dtMedicamentos, DataViewRowState.ModifiedCurrent, dtMedicaModificados)
            ''Cambia el campo tratamiento que esta en null por I Iniciado
            procesarCampoTratamiento(dtMedicaModificados, INICIA, Accion.Grabar)

            asignarSecuencia(dtMedicamentos)
            ''Se buscan  los medicamentos nuevos.Tambien se adicionan los registros 
            ''modificados ya que estos se insertan con un nuevo numero de orden quedando activos en la nueva orden.
            dtMedicaNuevos = filtrarTabla(dtMedicamentos, DataViewRowState.Added, dtMedicaNuevos)
            dtMedicaNuevos = filtrarTabla(dtMedicamentos, DataViewRowState.ModifiedCurrent, dtMedicaNuevos)
            ''Cambia el campo tratamiento que esta en null por I Iniciado
            procesarCampoTratamiento(dtMedicaNuevos, INICIA, Accion.Grabar)

            ''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
            dtMedicaModificados = configurarDataTableMedicaParaGrabar(dtMedicaModificados)
            dtMedicaNuevos = configurarDataTableMedicaParaGrabar(dtMedicaNuevos)

            ''Se generan los xml que contiene la informacion de los medicamentos
            xmlMedicaModificados = FuncionesGenerales.GenerarXMLxProcedimiento(dtMedicaModificados)
            xmlMedicaNuevos = FuncionesGenerales.GenerarXMLxProcedimiento(dtMedicaNuevos)


            '-------------------------PROCEDIMIENTOS--------------------------------

            ''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
            dtProcedimientos = configurarDataTableProcedimParaGrabar(dtProcedimientos)

            ''Se buscan los registro nuevos de los procedimientos. 
            'dtproceNuevos = filtrarTabla(dtProcedimientos, DataViewRowState.Added, dtproceNuevos)
            dtProcedimXCentroCosto = filtrarProcedimientosXCentroDeCosto(dtProcedimientos)
            ''Se genera el xml que contiene la informacion de los registro a insertar
            xmlProceNuevos = ""
            For i = 0 To dtProcedimXCentroCosto.Count - 1
                asignarSecuencia(dtProcedimXCentroCosto.Item(i))
                'Joseph Moreno (IG) Fec:2019/11/26 Particularidades
                'xmlProceNuevos = xmlProceNuevos & FuncionesGenerales.GenerarXMLxProcedimiento(dtProcedimXCentroCosto.Item(i))
                xmlProceNuevos = xmlProceNuevos _
                              & FuncionesGenerales.GenerarXMLxProcedimiento(
                                      dtProcedimXCentroCosto.Item(i),
                                      New HashSet(Of String)({"particularidades", "procedimientos"})
                                )
            Next


            '----------------------------ORDENES GENERALES----------------------------  
            'Se buscan los registros modificados de las ordenes generales. Estas ordenes se inactivan
            'y se crea una nueva orden con los nuevos datos(Continuar, suspender)
            dtGeneralesModificados = filtrarTabla(dtGenerales, DataViewRowState.ModifiedCurrent, dtGeneralesModificados)
            ''Cambia el campo tratamiento que esta en null por I Iniciado
            procesarCampoTratamiento(dtGeneralesModificados, INICIA, Accion.Grabar)

            ''Se buscan los registros nuevos de las ordenes generales
            asignarSecuencia(dtGenerales)
            dtGeneralesNuevos = filtrarTabla(dtGenerales, DataViewRowState.Added, dtGeneralesNuevos)
            dtGeneralesNuevos = filtrarTabla(dtGenerales, DataViewRowState.ModifiedCurrent, dtGeneralesNuevos)
            ''Cambia el campo tratamiento que esta en null por I Iniciado
            procesarCampoTratamiento(dtGeneralesNuevos, INICIA, Accion.Grabar)

            ''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
            dtGeneralesModificados = configurarDataTableOrdenGeneralParaGrabar(dtGeneralesModificados)
            dtGeneralesNuevos = configurarDataTableOrdenGeneralParaGrabar(dtGeneralesNuevos)

            xmlGeneralesModificados = FuncionesGenerales.GenerarXMLxProcedimiento(dtGeneralesModificados)
            xmlGeneralesNuevos = FuncionesGenerales.GenerarXMLxProcedimiento(dtGeneralesNuevos)


            ''Validar si existen datos para grabar 
            If dtDietasModificadas.Rows.Count <= 0 And dtDietasNuevas.Rows.Count <= 0 And
                dtMedicaModificados.Rows.Count <= 0 And dtMedicaNuevos.Rows.Count <= 0 And
                dtProcedimientos.Rows.Count <= 0 And dtGeneralesModificados.Rows.Count <= 0 And
                dtGeneralesNuevos.Rows.Count <= 0 Then
                Return 999  ''No existen datos para guardar
            End If


        End Function


        Public Shared Function RegistrosModificadosAdicionados(ByVal dsOrigen As DataSet) As DataSet
            Dim tabla As DataTable
            Dim tablaFiltrada As DataTable
            Dim dsFiltrado As New DataSet()

            For Each tabla In dsOrigen.Tables
                tablaFiltrada = tabla.Clone
                tablaFiltrada = filtrarTabla(tabla, DataViewRowState.Added, tablaFiltrada)
                tablaFiltrada = filtrarTabla(tabla, DataViewRowState.ModifiedCurrent, tablaFiltrada)
                dsFiltrado.Tables.Add(tablaFiltrada)
            Next

            Return dsFiltrado
        End Function

        Public Shared Sub procesarCampoTratamiento(ByRef dtDatos As DataTable, ByVal valor As String, ByVal eAccion As Accion)

            Dim rowArray() As DataRow
            Dim row As DataRow

            If eAccion = Accion.Cargar Then ''Cargar
                rowArray = dtDatos.Select("tratamiento = '" & valor & "'")

                For Each row In rowArray
                    'row.BeginEdit()
                    row.Item("tratamiento") = Nothing
                    'row.EndEdit()
                Next

            ElseIf eAccion = Accion.Grabar Then ''Grabar
                rowArray = dtDatos.Select("tratamiento is null")

                For Each row In rowArray
                    'row.BeginEdit()
                    row.Item("tratamiento") = valor
                    'row.EndEdit()
                Next

            End If
        End Sub
        ''ER_OSI_593_Modificacion_Funcionalidad_de_Dietas se crea funcion martovar 
        Public Shared Sub procesarCampoTratamiento1(ByRef dtDatos As DataTable, ByVal valor As String, ByVal eAccion As Accion)

            Dim rowArray() As DataRow
            Dim row As DataRow

            If eAccion = Accion.Cargar Then ''Cargar
                rowArray = dtDatos.Select("tratamiento = '" & valor & "'")

                ' For Each row In rowArray
                'row.BeginEdit()
                'row.Item("tratamiento") = Nothing
                'row.EndEdit()
                ' Next

            ElseIf eAccion = Accion.Grabar Then ''Grabar
                rowArray = dtDatos.Select("tratamiento is null")

                For Each row In rowArray
                    'row.BeginEdit()
                    row.Item("tratamiento") = valor
                    'row.EndEdit()
                Next

            End If
        End Sub


        Public Shared Sub actualizarEstado(ByRef drDatos As DataRow, ByVal tratamiento As String, ByVal valorCheck As Object, ByVal flag_sispro As String)


            drDatos.BeginEdit()

            If valorCheck Is Nothing Then
                If tratamiento = BLOrdenes.MODIFICA Then
                    drDatos.Item("estado") = BLOrdenes.ACTIVO
                    drDatos.Item("obs") = "M"
                    Exit Sub
                End If
            End If

            If IsDBNull(valorCheck) Then
                drDatos.Item("Tratamiento") = tratamiento
                If tratamiento = BLOrdenes.SUSPENDE Then
                    drDatos.Item("estado") = BLOrdenes.INACTIVO
                Else
                    drDatos.Item("estado") = BLOrdenes.ACTIVO
                End If
            Else
                If valorCheck = BLOrdenes.INICIA Then
                    drDatos.Item("Tratamiento") = tratamiento
                    If tratamiento = BLOrdenes.SUSPENDE Then
                        drDatos.Item("estado") = BLOrdenes.INACTIVO
                    Else
                        drDatos.Item("estado") = BLOrdenes.ACTIVO
                    End If
                    'drDatos.Item("fec_con") = FuncionesGenerales.FechaServidor()
                ElseIf valorCheck = BLOrdenes.CONTINUA Then 'Cambios. ALM_376
                    ' drDatos.Item("Tratamiento") = BLOrdenes.MODIFICA
                    drDatos.Item("Tratamiento") = BLOrdenes.CONTINUA
                    drDatos.Item("estado") = BLOrdenes.ACTIVO
                    'drDatos.Item("fec_con") = FuncionesGenerales.FechaServidor()
                ElseIf valorCheck = BLOrdenes.SUSPENDE Then
                    drDatos.Item("Tratamiento") = BLOrdenes.SUSPENDE
                    drDatos.Item("estado") = BLOrdenes.INACTIVO
                    'drDatos.Item("fec_con") = FuncionesGenerales.FechaServidor()
                ElseIf valorCheck = BLOrdenes.MODIFICA Then
                    drDatos.Item("Tratamiento") = BLOrdenes.SUSPENDE
                    drDatos.Item("estado") = BLOrdenes.INACTIVO
                    'drDatos.Item("estado") = BLOrdenes.ACTIVO
                    'drDatos.Item("obs") = "M"
                ElseIf valorCheck = "N" Then
                    If flag_sispro = "N" Then
                        drDatos.Item("Tratamiento") = BLOrdenes.CONTINUA
                        drDatos.Item("estado") = BLOrdenes.ACTIVO
                    End If
                End If
            End If
            'CU03 hrariza@
            'Inicio
            If drDatos.Table.ToString = "MEDICAMENTOS" Then
                If drDatos.Item("Tratamiento") = BLOrdenes.CONTINUA Or drDatos.Item("Tratamiento") = BLOrdenes.SUSPENDE Then
                    drDatos.Item("conciliado") = "S"
                End If
            End If
            'Fin
            drDatos.AcceptChanges()
            drDatos.SetModified()
            drDatos.EndEdit()
            'drDatos.BeginEdit()

            'If valorCheck Is Nothing Then

            '    If tratamiento = BLOrdenes.MODIFICA Then
            '        drDatos.Item("estado") = BLOrdenes.ACTIVO
            '        If Not IsDBNull(drDatos.Item("obs")) Then
            '            If drDatos.Item("obs") = "M" Then
            '                drDatos.Item("obs") = ""
            '                drDatos.RejectChanges()
            '                drDatos.Item("tratamiento") = Nothing
            '                drDatos.AcceptChanges()
            '            Else
            '                drDatos.Item("obs") = "M"
            '            End If
            '        Else
            '            drDatos.Item("obs") = "M"
            '        End If

            '        Exit Sub
            '    End If
            'End If

            'If IsDBNull(valorCheck) Then
            '    drDatos.Item("Tratamiento") = tratamiento
            '    If tratamiento = BLOrdenes.SUSPENDE Then
            '        drDatos.Item("estado") = BLOrdenes.INACTIVO
            '    Else
            '        drDatos.Item("estado") = BLOrdenes.ACTIVO
            '    End If
            '    'drDatos.Item("fec_con") = FuncionesGenerales.FechaServidor()
            'Else
            '    If valorCheck = BLOrdenes.CONTINUA Then
            '        drDatos.Item("Tratamiento") = BLOrdenes.SUSPENDE
            '        drDatos.Item("estado") = BLOrdenes.INACTIVO
            '        'drDatos.Item("fec_con") = FuncionesGenerales.FechaServidor()
            '    ElseIf valorCheck = BLOrdenes.SUSPENDE Then

            '        drDatos.Item("Tratamiento") = BLOrdenes.CONTINUA
            '        drDatos.Item("estado") = BLOrdenes.ACTIVO
            '        'drDatos.Item("fec_con") = FuncionesGenerales.FechaServidor()

            '    ElseIf valorCheck = BLOrdenes.MODIFICA Then
            '        drDatos.Item("estado") = BLOrdenes.ACTIVO
            '        If Not IsDBNull(drDatos.Item("obs")) Then
            '            If drDatos.Item("obs") = "M" Then
            '                drDatos.Item("obs") = ""
            '                'drDatos.RejectChanges()
            '                'drDatos.Item("Tratamiento") = BLOrdenes.ACTIVO
            '                drDatos.Item("estado") = BLOrdenes.VARIASDOSIS
            '                'drDatos.AcceptChanges()
            '            Else
            '                drDatos.Item("obs") = "M"
            '            End If
            '        Else
            '            drDatos.Item("obs") = "M"
            '        End If
            '    ElseIf valorCheck = "N" Then
            '        drDatos.Item("estado") = BLOrdenes.ACTIVO
            '        drDatos.Item("obs") = "M"
            '    End If
            'End If
            'drDatos.EndEdit()
        End Sub

        Public Shared Sub deshacerActualizacionEstado(ByRef drDatos As DataRow)
            drDatos.RejectChanges()
            drDatos.Item("tratamiento") = Nothing
            drDatos.AcceptChanges()
        End Sub

        Public Shared Function filtrarTabla(ByVal dtBase As DataTable, ByVal filtro As DataViewRowState, ByVal dtContenedor As DataTable) As DataTable

            Dim rowsFiltradas() As DataRow

            rowsFiltradas = dtBase.Select("", "", filtro)
            dtContenedor = FuncionesGenerales.copyArrayToDataTable(dtContenedor, rowsFiltradas)
            Return dtContenedor

        End Function

        Public Shared Function filtrarProcedimientosXCentroDeCosto(ByVal dtProcedim As DataTable) As ArrayList
            Dim arrayCentrosDeCosto As New ArrayList
            Dim strCentroDeCosto As String
            Dim rowsProcedimientos() As DataRow
            Dim dtResultado As New ArrayList
            Dim indice As Integer

            For indice = 0 To dtProcedim.Rows.Count - 1
                strCentroDeCosto = dtProcedim.Rows(indice).Item("cen_cos_des").ToString
                If Not arrayCentrosDeCosto.Contains(strCentroDeCosto) Then
                    ''Filta los procedimientos que tienen convenio para realizar el 
                    ''pedido correspondiente.
                    rowsProcedimientos = dtProcedim.Select("cen_cos_des = '" & strCentroDeCosto & "' and tieneConvenio <> 'N'")
                    If rowsProcedimientos.Length > 0 Then
                        dtResultado.Add(FuncionesGenerales.copyArrayToDataTable(dtProcedim.Clone, rowsProcedimientos))
                    End If

                    ''Filtra los procedimientos que no tienen pedido con el fin de no 
                    ''realizar el pedido.
                    rowsProcedimientos = dtProcedim.Select("cen_cos_des = '" & strCentroDeCosto & "' and tieneConvenio = 'N'")
                    If rowsProcedimientos.Length > 0 Then
                        dtResultado.Add(FuncionesGenerales.copyArrayToDataTable(dtProcedim.Clone, rowsProcedimientos))
                    End If

                    arrayCentrosDeCosto.Add(strCentroDeCosto)
                End If
            Next

            Return dtResultado
        End Function

        Public Shared Function filtrarProcedimientosxEnt(ByVal dtProcedim As DataTable) As ArrayList
            Dim arrayEntidad As New ArrayList
            Dim strEntidad As String
            Dim arrayCentrosDeCosto As New ArrayList
            Dim strCentroDeCosto As String
            Dim rowsProcedimientos() As DataRow
            Dim dtResultado As New ArrayList
            Dim indice As Integer

            For indice = 0 To dtProcedim.Rows.Count - 1
                strEntidad = dtProcedim.Rows(indice).Item("entidad").ToString
                If dtProcedim.Rows(indice).Item("tieneCcostoLabo").ToString = "S" Then
                    If Not arrayEntidad.Contains(strEntidad) Then
                        ''Filta los procedimientos que tienen convenio y entidad para realizar el 
                        ''pedido correspondiente.
                        rowsProcedimientos = dtProcedim.Select("entidad = '" & strEntidad & "' and tieneConvenio <> 'N' and tieneCcostoLabo = 'S'")
                        If rowsProcedimientos.Length > 0 Then
                            dtResultado.Add(FuncionesGenerales.copyArrayToDataTable(dtProcedim.Clone, rowsProcedimientos))
                        End If

                        ''Filtra los procedimientos que no tienen pedido con el fin de no  
                        ''realizar el pedido.
                        rowsProcedimientos = dtProcedim.Select("entidad = '" & strEntidad & "' and tieneConvenio = 'N' and tieneCcostoLabo = 'S'")
                        If rowsProcedimientos.Length > 0 Then
                            dtResultado.Add(FuncionesGenerales.copyArrayToDataTable(dtProcedim.Clone, rowsProcedimientos))
                        End If

                        arrayEntidad.Add(strEntidad)
                    End If
                Else
                    strCentroDeCosto = dtProcedim.Rows(indice).Item("cen_cos_des").ToString
                    If Not arrayCentrosDeCosto.Contains(strCentroDeCosto) Then
                        ''Filta los procedimientos que tienen convenio para realizar el 
                        ''pedido correspondiente.
                        rowsProcedimientos = dtProcedim.Select("cen_cos_des = '" & strCentroDeCosto & "' and tieneConvenio <> 'N' and tieneCcostoLabo = 'N'")
                        If rowsProcedimientos.Length > 0 Then
                            dtResultado.Add(FuncionesGenerales.copyArrayToDataTable(dtProcedim.Clone, rowsProcedimientos))
                        End If

                        ''Filtra los procedimientos que no tienen pedido con el fin de no 
                        ''realizar el pedido.
                        rowsProcedimientos = dtProcedim.Select("cen_cos_des = '" & strCentroDeCosto & "' and tieneConvenio = 'N' and tieneCcostoLabo = 'N'")
                        If rowsProcedimientos.Length > 0 Then
                            dtResultado.Add(FuncionesGenerales.copyArrayToDataTable(dtProcedim.Clone, rowsProcedimientos))
                        End If

                        arrayCentrosDeCosto.Add(strCentroDeCosto)
                    End If

                End If
            Next

            Return dtResultado
        End Function

        Public Shared Sub asignarSecuencia(ByRef dtGenerales As DataTable)
            Dim secuencia As Integer
            Dim rowsBusqueda() As DataRow
            Dim row As DataRow

            secuencia = 1
            rowsBusqueda = dtGenerales.Select("", "", DataViewRowState.ModifiedCurrent)
            For Each row In rowsBusqueda
                row.Item("Secuencia") = secuencia
                secuencia += 1
            Next

            rowsBusqueda = dtGenerales.Select("", "", DataViewRowState.Added)
            For Each row In rowsBusqueda
                row.Item("Secuencia") = secuencia
                secuencia += 1
            Next
        End Sub
        ''Se agrega CCorigen Claudia Garay Junio 2011
        Public Shared Function consultarCentroCostoDestinoXProcedim(ByVal objconexion As Conexion, ByVal strCodPreSgs As String, ByVal strCodSucur As String, ByVal strCodProcedim As String, ByVal strCCOrigen As String) As DataTable
            Return DAOOrdenes.consultarCentroCostoDestinoXProcedim(objconexion, strCodPreSgs, strCodSucur, strCodProcedim, strCCOrigen)
        End Function

        Public Shared Function traerInformacionCentroCosto(ByVal objconexion As Conexion, ByVal strCod_pre_sgs As String, ByVal strCod_sucur As String, ByVal strCodigoCentroCosto As String) As DataTable
            Return DAOOrdenes.traerInformacionCentroCosto(objconexion, strCod_pre_sgs, strCod_sucur, strCodigoCentroCosto)
        End Function

        Public Shared Function traerDescripcionCentroCosto(ByVal objconexion As Conexion, ByVal strCod_pre_sgs As String, ByVal strCod_sucur As String, ByVal strCodigoCentroCosto As String) As String
            Dim dtDatosCentroCosto As DataTable
            dtDatosCentroCosto = BLOrdenes.traerInformacionCentroCosto(objconexion, strCod_pre_sgs, strCod_sucur, strCodigoCentroCosto)

            If Not dtDatosCentroCosto Is Nothing Then
                If dtDatosCentroCosto.Rows.Count > 0 Then
                    Return dtDatosCentroCosto.Rows(0).Item("Descripcion").ToString
                Else
                    Return ""
                End If
            Else
                Return ""
            End If
        End Function

        Public Shared Function configurarDataTableDietasParaGrabar(ByVal dtDietas As DataTable) As DataTable
            Dim dtFiltrado As DataTable

            dtFiltrado = dtDietas.Copy()
            With dtFiltrado.Columns
                .Remove("DescriDieta")
                .Remove("NombreMedico")
                .Remove("especialidad")
            End With

            Return dtFiltrado

        End Function

        Public Shared Function configurarDataTableMedicaParaGrabar(ByVal dtMedicamentos As DataTable) As DataTable
            Dim dtFiltrado As DataTable

            dtFiltrado = dtMedicamentos.Copy()
            With dtFiltrado.Columns
                .Remove("prescripcion")
                .Remove("descripcion")
                .Remove("nombreMedico")
                .Remove("especialidad")
                .Remove("conciliacion")
            End With

            Return dtFiltrado

        End Function

        Public Shared Function configurarDataTableProcedimParaGrabar(ByVal dtProcedim As DataTable) As DataTable
            Dim dtFiltrado As DataTable

            dtFiltrado = dtProcedim.Copy()
            With dtFiltrado.Columns
                '.Remove("descripcion_proce") ' agfa_orm_in herojas se necesita la descripcion del procedimiento
                .Remove("descri_cen_cos_des")
                .Add("procedimhomologo", System.Type.GetType("System.String"))
                .Add("entidadpedido", System.Type.GetType("System.String"))
                .Add("cod_Labor", System.Type.GetType("System.String"))
                '.Add("tieneCcostoLabo", System.Type.GetType("System.String"))
            End With

            Return dtFiltrado

        End Function

        Public Shared Function configurarDataTableOrdenGeneralParaGrabar(ByVal dtOrdenGeneral As DataTable) As DataTable
            Dim dtFiltrado As DataTable

            dtFiltrado = dtOrdenGeneral.Copy()
            With dtFiltrado.Columns
                .Remove("nombreMedico")
                .Remove("especialidad")
            End With

            Return dtFiltrado

        End Function

        Public Shared Function tamanoFilaXmlDietas(ByVal drFila As DataRow) As Integer
            Dim tam As Integer

            ''Numero de caracteres que son constantes en el 
            ''documento Xml Ejm: Encabezado, nombres de los tags etc..
            tam = 168

            tam += Trim(drFila("Obs").ToString).Length
            tam += Trim(drFila("fec_con").ToString).Length
            tam += 1  'drFila("Tratamiento") 
            tam += Trim(drFila("NroOrden").ToString).Length
            tam += Trim(drFila("Dieta").ToString).Length
            tam += Trim(drFila("estado").ToString).Length
            tam += Trim(drFila("Login").ToString).Length
            tam += Trim(drFila("medico").ToString).Length
            tam += Trim(drFila("cod_pre_sgs").ToString).Length
            tam += Trim(drFila("cod_sucur").ToString).Length
            tam += Trim(drFila("tip_admision").ToString).Length
            tam += Trim(drFila("ano_adm").ToString).Length
            tam += Trim(drFila("num_adm").ToString).Length
            tam += Trim(drFila("ResHidrica").ToString).Length
            tam += 2 'drFila("secuencia")

            Return tam

        End Function

        Public Shared Function tamanoFilaXmlMedica(ByVal drFila As DataRow) As Integer
            Dim tam As Integer

            ''Numero de caracteres que son constantes en el 
            ''documento Xml Ejm: Encabezado, nombres de los tags etc..
            tam = 321

            tam += Trim(drFila("fec_con").ToString).Length
            tam += Trim(drFila("cod_pre_sgs").ToString).Length
            tam += Trim(drFila("cod_sucur").ToString).Length
            tam += Trim(drFila("tip_admision").ToString).Length
            tam += Trim(drFila("ano_adm").ToString).Length
            tam += Trim(drFila("num_adm").ToString).Length
            tam += Trim(drFila("NroOrden").ToString).Length
            tam += Trim(drFila("producto").ToString).Length
            tam += Trim(drFila("FormaFarma").ToString).Length
            tam += Trim(drFila("Presentacion").ToString).Length
            tam += Trim(drFila("Contenido").ToString).Length
            tam += Trim(drFila("Concentracion").ToString).Length
            tam += Trim(drFila("Dosis").ToString).Length
            tam += Trim(drFila("UniMedDosis").ToString).Length
            tam += Trim(drFila("ViaAdministra").ToString).Length
            tam += Trim(drFila("Frecuencia").ToString).Length
            tam += Trim(drFila("TecnicaAdministra").ToString).Length
            tam += Trim(drFila("UnicaDosis").ToString).Length
            tam += 1 ''drFila("Tratamiento")
            tam += Trim(drFila("medico").ToString).Length
            tam += Trim(drFila("estado").ToString).Length
            tam += Trim(drFila("login").ToString).Length
            tam += Trim(drFila("obs").ToString).Length
            tam += 2 ''drFila("Secuencia")

            Return tam

        End Function

        Public Shared Function tamanoFilaXmlOrdenGeneral(ByVal drFila As DataRow) As Integer
            Dim tam As Integer

            ''Numero de caracteres que son constantes en el 
            ''documento Xml Ejm: Encabezado, nombres de los tags etc..
            tam = 173

            tam += Trim(drFila("cod_pre_sgs").ToString).Length
            tam += Trim(drFila("cod_sucur").ToString).Length
            tam += Trim(drFila("tip_admision").ToString).Length
            tam += Trim(drFila("num_adm").ToString).Length
            tam += Trim(drFila("ano_adm").ToString).Length
            tam += Trim(drFila("NroOrden").ToString).Length
            tam += 2  'drFila("Secuencia")
            tam += Trim(drFila("TextoOrden").ToString).Length
            tam += 1  'drFila("Tratamiento")
            tam += Trim(drFila("medico").ToString).Length
            tam += Trim(drFila("estado").ToString).Length
            tam += Trim(drFila("fec_con").ToString).Length
            tam += Trim(drFila("login").ToString).Length
            tam += Trim(drFila("obs").ToString).Length

            Return tam
        End Function

        Public Shared Function tamanoFilaXmlProcedim(ByVal drFila As DataRow, ByVal dtProcedim As DataTable) As Integer
            Dim tam As Integer
            Dim arrayResultado() As DataRow

            tam = 246

            arrayResultado = dtProcedim.Select("cen_cos_des = '" & drFila.Item("cen_cos_des") & "'")
            If arrayResultado.Length <= 0 Then
                tam += 57
            End If

            tam += Trim(drFila("Cantidad").ToString).Length
            tam += Trim(drFila("obs").ToString).Length
            tam += Trim(drFila("cod_pre_sgs").ToString).Length
            tam += Trim(drFila("cod_sucur").ToString).Length
            tam += Trim(drFila("tip_admision").ToString).Length
            tam += Trim(drFila("num_adm").ToString).Length
            tam += Trim(drFila("ano_adm").ToString).Length
            tam += Trim(drFila("NroOrden").ToString).Length
            tam += Trim(drFila("procedim").ToString).Length
            tam += Trim(drFila("medico").ToString).Length
            tam += Trim(drFila("fec_con").ToString).Length
            tam += Trim(drFila("login").ToString).Length
            tam += 2 'drFila("Secuencia")
            tam += Trim(drFila("uni_solicit").ToString).Length
            tam += Trim(drFila("uni_aplicada").ToString).Length
            tam += Trim(drFila("uni_suministrada").ToString).Length
            tam += Trim(drFila("durante").ToString).Length
            tam += Trim(drFila("cen_cos_des").ToString).Length
            tam += Trim(drFila("entidad").ToString).Length

            Return tam

        End Function

        Public Shared Function puedeModificarTratamiento(ByVal drFila As DataRow) As Boolean

            ''Controla que no se pueda modificar el campo "Tratamiento" de las filas nuevas 
            If drFila.RowState = DataRowState.Added Then
                drFila.Item("tratamiento") = Nothing
                Return False
            End If




            Return True

        End Function

        Public Shared Function puedeModificarTratamientoconciliacion(ByVal drFila As DataRow, valororigen As String) As Boolean

            ''Controla que no se pueda modificar el campo "Tratamiento" de las filas nuevas 
            If drFila.RowState = DataRowState.Added Then
                drFila.Item("tratamiento") = Nothing
                Return False
            End If

            'If valororigen = "OrdenMed" Then

            '    '    dgtMedicaConcil.Rows(e.RowIndex).Cells("modificar_med").Value = "N"
            '    Return False

            'End If



            Return True

        End Function



        Public Shared Function puedeGenerarOrdenes(ByVal objConexion As Conexion, ByVal codPreSgs As String,
                                                   ByVal codSucur As String, ByVal tipoAdmision As String,
                                                   ByVal anoAdm As String, ByVal numAdm As String,
                                                   ByRef mensaje As String) As Boolean

            Dim dtAdmision As DataTable

            dtAdmision = DAOOrdenes.consultarAdmision(objConexion, codPreSgs, codSucur,
                                                      tipoAdmision, anoAdm, numAdm)

            If dtAdmision Is Nothing Then
                mensaje = "Error en la consulta de la admisión. "
                Return False
            End If

            If dtAdmision.Rows.Count <= 0 Then
                mensaje = "No existen datos para la admisión. "
                Return False
            End If

            Select Case dtAdmision.Rows(0).Item("estado").ToString
                Case BLOrdenes.EGRESADA
                    mensaje = "No se pueden generar ordenes a una admisión egresada. "
                    Return False
                Case BLOrdenes.ANULADA
                    mensaje = "No se pueden generar ordenes a una admisión anulada. "
                    Return False
                Case BLOrdenes.TRASLADADA
                    mensaje = "No se pueden generar ordenes a una admisión trasladada. "
                    Return False
                Case BLOrdenes.PENDIENTE
                    mensaje = "No se pueden generar ordenes a una admisión pendiente. "
                    Return False
            End Select

            Return True

        End Function

        Public Shared Function generaPedidoProcedim(ByVal tipoProcedim As String, ByVal centroCosto As String) As Boolean

            Dim tipProce As Integer

            If IsNumeric(tipoProcedim) Then
                tipProce = CInt(tipoProcedim)
            Else
                tipProce = 0
                Return False
            End If

            If tipProce = tiposProcedim.ConsultaMedica Then  ''1
                Return False
            End If

            'If objGenerales.Instancia.Pais <> "482" Then ''cpgaray OS 750259 genera pedido para tipo 3 indicado por herojas
            '    If tipProce = tiposProcedim.ProcedimQuirurgicos Then ''3
            '        Return False
            '    End If
            'End If

            If tipProce = tiposProcedim.ServicioClinicas Then ''6 cpgaray Junio 2011 pedidos en las ordenes de procedimientos
                Return False
            End If

            If tipProce = tiposProcedim.Ayudantias Then ''7 cpgaray Junio 2011 pedidos en las ordenes de procedimientos
                Return False
            End If

            If centroCosto.Trim.Length = 0 Then
                Return False
            End If

            Return True

        End Function
        ''Claudia Garay Ctc's Marzo 21 de 2012
        Public Shared Function ConsultaExcepciones(ByVal strEntidad As String, ByVal strCodPrograma As String) As Boolean

            Dim daoOrden As New DAOOrdenes

            If daoOrden.ValidaExcepciones(strEntidad, strCodPrograma) = 0 Then
                Return False
            Else
                Return True
            End If


        End Function
        ''Claudia Garay Ctc's Marzo 21 de 2012
        Public Shared Function ConsultaExcepcionesProce(ByVal strEntidad As String, ByVal strCodPrograma As String) As Boolean

            Dim daoOrden As New DAOOrdenes

            If daoOrden.ValidaExcepcionesProce(strEntidad, strCodPrograma) = 0 Then
                Return False
            Else
                Return True
            End If


        End Function

        ''Claudia Garay Ctc's Noviembre 23 de 2012
        Public Shared Function ConsultaMedicamentosEquivalentes(ByVal strcod_corto As String) As DataTable

            Dim daoOrden As New DAOOrdenes
            Dim dt As New DataTable

            dt = daoOrden.ConsultaMedicamentosEquivalentes(strcod_corto)

            Return dt
        End Function


        ''ER_OSI_596_Indicaciones_Medicas
        ''Martovar 2017/09/27
        Public Shared Function ConsultaIndicaciones(ByVal codigo As Integer) As DataTable

            Dim daoOrden As New DAOOrdenes
            Dim dt As New DataTable

            dt = daoOrden.ConsultaIndicaciones(codigo)

            Return dt
        End Function

        ''Claudia Garay Diciembre 19 de Diciembre tk 480890-20121207
        Public Shared Sub GrabarErroresOrdenesMedicas(ByVal Descripcion As String)

            Dim daoOrden As New DAOOrdenes


            daoOrden.GrabarErroresOrdenesMed(Descripcion)


        End Sub

        Public Shared Sub GrabarErroresOrdenesMedicasHomolo(ByVal Descripcion As String, ByVal linkedServer As String)
            Dim daoOrden As New DAOOrdenes
            daoOrden.GrabarErroresOrdenesMedHomolo(Descripcion, linkedServer)
        End Sub

        Private Shared Function lF_sDireccionIP() As String
            Dim query As New System.Management.ManagementObjectSearcher("Select * From WIN32_NetworkAdapterConfiguration Where IPEnabled = 'TRUE'")
            Dim queryCollection As System.Management.ManagementObjectCollection = query.Get()
            Dim mo As New System.Management.ManagementObject
            Dim strIPAddress As String = ""
            For Each mo In queryCollection
                Dim strAddresses() As String = CType(mo("IPAddress"), String())
                For Each strIPAddress In strAddresses
                    Exit For
                Next
                If strIPAddress <> "" Then Exit For
            Next
            '--Liberando Memoria--
            query.Dispose()
            query = Nothing
            queryCollection.Dispose()
            queryCollection = Nothing
            mo.Dispose()
            mo = Nothing
            '---------------------
            Return strIPAddress
        End Function
        ''Hernan Rojas 2014/05/15
        ''Se verifica que no exista el CTC
        ''Solicitado por Mauricio Forero

        Public Shared Function MedicamentoTieneCTC(ByVal Prestador As String, ByVal Sucursal As String,
                                ByVal TipoAdmision As String, ByVal AnoAdmision As String,
                                ByVal NumeroAdmision As String, ByVal Producto As String) As Boolean


            Dim daoOrden As New DAOOrdenes


            Return daoOrden.MedicamentoTieneCTC(Prestador, Sucursal,
                                 TipoAdmision, AnoAdmision,
                                NumeroAdmision, Producto)
        End Function

        'Version 3.0.0 CTC para medicina prepagada herojas 2015/01/15
        Public Shared Function PideCTCMP(ByVal Prestador As String, ByVal Sucursal As String,
                                ByVal TipoAdmision As String, ByVal AnoAdmision As String,
                                ByVal NumeroAdmision As String, ByVal Producto As String) As String


            Dim daoOrden As New DAOOrdenes


            Return daoOrden.ValidarSegundaEntidadNoPOS(Prestador, Sucursal,
                                 TipoAdmision, AnoAdmision,
                                NumeroAdmision, Producto)
        End Function


        '' Desarrollo realizado por Jimmy Leandro Guevara (Intergrupo)

        ''' <summary>
        ''' Metodo que se encarga de consultar los datos de homologacion de la sucursal
        ''' </summary>
        ''' <param name="strCod_pre_sgs"></param>
        ''' <param name="strCod_sucur"></param>
        ''' <returns>DataTable</returns>
        Public Shared Function ConsultarHomologacion(ByVal strCod_pre_sgs As String,
                                                               ByVal strCod_sucur As String) As DataTable
            Dim daoOrden As New DAOOrdenes
            Return daoOrden.ConsultarHomologacion(strCod_pre_sgs, strCod_sucur)

        End Function

        ''' <summary>
        ''' Metodo escargado de consultar el linked sever para la homologacion
        ''' </summary>
        ''' <param name="idLocalizacion"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ConsultarLinkedServer(ByVal idLocalizacion As Int32) As String

            Dim daoOrden As New DAOOrdenes
            Return daoOrden.ConsultarLinkedServer(idLocalizacion)

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
        Public Shared Function ConsultarProcedimientoPorCodigo(ByVal dtProcediminentos As DataTable, ByVal LinkedServer As String, ByVal CodigoPrestador As String, ByVal CodigoSucursal As String) As DataTable

            Dim daoOrden As New DAOOrdenes
            Dim datosPorcedientoRetorno As New DataTable
            Dim datosPorcedientoConsulta As DataTable
            Dim dtProcediminentosTemp As New DataTable
            dtProcediminentosTemp = dtProcediminentos.Clone()

            For Each row As DataRow In dtProcediminentos.Rows

                If row("numconsulta") = "4" Or row("numconsulta") = "2" Then
                    datosPorcedientoConsulta = daoOrden.ConsultarProcedimientoPorCodigo("PROCEDIMIENTOSTRIAGEAVANZADO",
                String.Empty,
                0,
                String.Empty,
                "N",
                String.Empty,
                0,
                CodigoPrestador,
                row("entidad").ToString(),
                String.Empty,
                row("procedim").ToString(),
                CodigoSucursal,
                LinkedServer)
                End If

                If Not datosPorcedientoConsulta Is Nothing Then
                    If datosPorcedientoConsulta.Rows.Count > 0 Then
                        dtProcediminentosTemp.ImportRow(row)
                    End If
                End If
            Next
            Return dtProcediminentosTemp
        End Function

        ''' <summary>
        ''' Metodo que consulta el consecutio para la admision
        ''' </summary>
        ''' <param name="strCodSucur"></param>
        ''' <param name="strCentroCosto"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ConsultarConsecutivo(ByVal strCodSucur As String, ByVal strCentroCosto As String, ByVal LinkedServer As String) As Int32
            Dim daoOrden As New DAOOrdenes
            Return daoOrden.ConsultarConsecutivo(strCodSucur, strCentroCosto, LinkedServer)
        End Function

        ''' <summary>
        ''' Consulta las entidades relacionadas con una admision en particular
        ''' </summary>
        ''' <param name="Anno"></param>
        ''' <param name="TipoAdmision"></param>
        ''' <param name="NumeroAdmision"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ConsultarEntidadesPorAdmision(ByVal Anno As Integer, ByVal TipoAdmision As String, ByVal NumeroAdmision As Integer) As DataTable
            Dim daoOrden As New DAOOrdenes
            Return daoOrden.ConsultarEntidadesPorAdmision(Anno, TipoAdmision, NumeroAdmision)
        End Function

        ''' <summary>
        ''' Metodo encargado de consultar el cargo automatico
        ''' </summary>
        ''' <param name="sEntidadPrestadora"></param>
        ''' <param name="sCodigoSucursal"></param>
        ''' <param name="sEntidad"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ConsultarCargoAutmatico(ByVal sEntidadPrestadora As String, ByVal sCodigoSucursal As String, ByVal sEntidad As String, ByVal sTipoAdmision As String, ByVal sTipoPlan As String, ByVal dFecha As Date, ByVal sEspecialidad As String, ByVal sMotivoIngreso As String, ByVal sRedondeo As String, ByVal nCantidad As Int32, ByVal nEdad As Int32, ByVal sTipoDocumento As String, ByVal sNumeroDocumento As String, ByVal sMedico As String, ByVal sNumeroProcedimiento As String, ByVal linkedServer As String, ByVal IdlocalizacionDesdtino As Int32) As DataTable
            Dim daoOrden As New DAOOrdenes
            Return daoOrden.ConsultarCargoAutmatico(sEntidadPrestadora, sCodigoSucursal, sEntidad, sTipoAdmision, sTipoPlan, dFecha, sEspecialidad, sMotivoIngreso, sRedondeo, nCantidad, nEdad, sTipoDocumento, sNumeroDocumento, sMedico, sNumeroProcedimiento, linkedServer, IdlocalizacionDesdtino)
        End Function

        ''' <summary>
        ''' Metodo encargado de consultar el cargo automatico
        ''' </summary>
        ''' <param name="sEntidadPrestadora"></param>
        ''' <param name="sCodigoSucursal"></param>
        ''' <param name="sEntidad"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GuardarAdmisionHomologada(ByVal datosAdmision As DataTable, ByVal LinkedServer As String) As DataTable
            Dim daoOrden As New DAOOrdenes
            Return daoOrden.GuardarAdmisionHomologada(datosAdmision, LinkedServer)
        End Function

        Public Shared Function guardarOrdenesHomologada(ByVal objConexion As Conexion, ByVal LinkedServer As String, ByVal cod_pre_sgs As String,
                                                        ByVal strCodSucur As String, ByVal tip_admision As String,
                                                        ByVal num_adm As String, ByVal ano_adm As String, ByVal strLogin As String,
                                                        ByVal medico As String, ByVal strCodEspecialidad As String, ByVal entidad As String,
                                                        ByVal dtAislamientosAnt As DataTable, ByVal dtDietasAnt As DataTable, ByVal dtMedicamentosAnt As DataTable,
                                                        ByVal dtProcedimientosAnt As DataTable, ByVal dtGeneralesAnt As DataTable,
                                                        ByRef NroOrden As Double, ByRef fechaOrden As Date,
                                                        ByRef centroCostoOrigen As String, ByRef strGuia As String,
                                                        ByRef strJustificacion As String, ByRef strTipoServicio As String,
                                                        ByRef strPrioridad As String, ByVal CodProcedim As String, ByVal DescripProcedim As String, Optional ByRef Practicaosi As String = "") As DataTable

            Dim dtRespuesta As New DataTable
            Dim dtAislamientosModificados As New DataTable
            Dim dtAislamientosNuevos As New DataTable
            Dim xmlAislamientosModifica As String = ""
            Dim xmlAislamientosNuevos As String = ""

            Dim dtDietasModificadas As New DataTable
            Dim dtDietasNuevas As New DataTable
            Dim xmlDietasModifica As String = ""
            Dim xmlDietasNuevas As String = ""

            Dim dtMedicaModificados As New DataTable
            Dim dtMedicaNuevos As New DataTable
            Dim xmlMedicaModificados As String = ""
            Dim xmlMedicaNuevos As String = ""

            Dim dtproceNuevos As New DataTable
            Dim dtProcedimXCentroCosto As ArrayList
            Dim xmlProceNuevos As String

            Dim dtGeneralesModificados As New DataTable
            Dim dtGeneralesNuevos As New DataTable
            Dim xmlGeneralesModificados As String
            Dim xmlGeneralesNuevos As String

            ''Claudia Garay Abril 05 2011 Auditoria Ordenes
            Dim intCountAislamientos As Integer = 0
            Dim intCountDietas As Integer = 0
            Dim intCountMedicamento As Integer = 0
            Dim intCountProcedimiento As Integer = 0
            Dim intCountGenerales As Integer = 0
            Dim objpaciente As Paciente
            Dim ObjGeneral As objGenerales
            objpaciente = Paciente.Instancia
            ObjGeneral = objGenerales.Instancia

            Dim lError As Long
            Dim i As Integer
            Dim intGuardar As Integer = 0
            Dim strMensaje As String = ""

            Dim daoOrden As New DAOOrdenes()
            Dim daogeneral As New DAOGeneral
            Dim Agfa As String

            Dim procedimHomologo As String = ""
            Dim entidadvalida As String = ""
            Dim strGeneraPedido As String = ""
            Dim strGeneraPedidoLabo As String = ""

            Dim dtproceris As New DataTable
            Dim intris As Integer = 0
            Dim intValida As Integer = 0
            Dim intGraba As Integer = 0

            Dim strCodSucuragfa As String

            Dim numPedido As Decimal
            Dim loginHomologacion As String = String.Empty
            loginHomologacion = BLOrdenes.ConsultarLoginHomologacion(LinkedServer)

            ''Dsanchez IG - REQ594 - 10/10/2017
            ' dtAislamientosModificados = dtAislamientosAnt.Clone()
            'For Each row As DataRow In dtAislamientosAnt.Rows
            '    row("cod_pre_sgs") = cod_pre_sgs
            '    row("cod_sucur") = strCodSucur
            '    row("num_adm") = num_adm

            'Next

            Dim comodinAisla As DataTable
            comodinAisla = dtAislamientosAnt.Clone()
            dtAislamientosNuevos = comodinAisla.Clone()

            'dtDietasModificadas = dtDietasAnt.Clone()

            'For Each row As DataRow In dtDietasAnt.Rows
            '    row("cod_pre_sgs") = cod_pre_sgs
            '    row("cod_sucur") = strCodSucur
            '    row("num_adm") = num_adm
            'Next

            Dim comodinDieta As DataTable
            comodinDieta = dtDietasAnt.Clone()
            dtDietasNuevas = comodinDieta.Clone()
            dtDietasNuevas.Rows.Clear()
            ' dtMedicaModificados = dtMedicamentosAnt.Clone()

            'For Each row As DataRow In dtMedicamentosAnt.Rows
            '    row("cod_pre_sgs") = cod_pre_sgs
            '    row("cod_sucur") = strCodSucur
            '    row("num_adm") = num_adm
            'Next

            Dim comodinMedica As DataTable
            comodinMedica = dtMedicamentosAnt.Clone()
            dtMedicaNuevos = comodinMedica.Clone()
            dtMedicaNuevos.Rows.Clear()

            dtproceNuevos = dtProcedimientosAnt.Clone()
            dtproceNuevos = dtProcedimientosAnt.Copy()

            For Each row As DataRow In dtproceNuevos.Rows
                row("cod_pre_sgs") = cod_pre_sgs
                row("cod_sucur") = strCodSucur
                row("num_adm") = num_adm
                row("ano_adm") = ano_adm
            Next


            ' dtproceNuevos = dtProcedimientosAnt.Clone()

            'For Each row As DataRow In dtGeneralesAnt.Rows
            '    row("cod_pre_sgs") = cod_pre_sgs
            '    row("cod_sucur") = strCodSucur
            'Next

            Dim comodinGenera As DataTable
            comodinGenera = dtGeneralesAnt.Clone()
            dtGeneralesNuevos = comodinGenera.Clone
            dtGeneralesNuevos.Rows.Clear()


            'consecutivo = daoGeneral.EjecutarSQLStrValor("hcEnfAlarma", objconexion, " max(consecutivo)", " cod_historia=" & cod_historia)

            ''intGuardar = daogeneral.EjecutarSQLStrValor("hcgrabarOrdenes", objConexion, "modo_guardar", " cod_pre_sgs='" & cod_pre_sgs & "' and cod_sucur='" & strCodSucur & "'")

            If IsDBNull(intGuardar) Then
                intGuardar = 0
            End If

            If intGuardar = 0 Then

                '----------------------------AISLAMIENTOS-----------------------------------
                ''Se buscan los aislamientos que han sido modificados
                dtAislamientosModificados = filtrarTabla(dtAislamientosAnt, DataViewRowState.ModifiedCurrent, dtAislamientosModificados)
                ''QUITAR
                ''If dtAislamientosModificados.Rows.Count > 0 Then
                ''Cambia el campo tratamiento cuando es Null al valor I por 
                ''procesarCampoTratamiento(dtAislamientosModificados, INICIA, Accion.Grabar)
                ''End If


                asignarSecuencia(dtAislamientosAnt)
                ''Se buscan los aislamientos nuevos.Tambien se adicionan los registros 
                ''modificados ya que estos se insertan con un nuevo numero de orden quedando activos en la nueva orden.
                dtAislamientosNuevos = filtrarTabla(dtAislamientosAnt, DataViewRowState.Added, dtAislamientosNuevos)
                dtAislamientosNuevos = filtrarTabla(dtAislamientosAnt, DataViewRowState.ModifiedCurrent, dtAislamientosNuevos)


                If dtAislamientosNuevos.Rows.Count > 0 And dtAislamientosNuevos.Columns.Contains("tratamiento") Then

                    ''Cambia el campo tratamiento cuando es Null al valor I por 
                    procesarCampoTratamiento(dtAislamientosNuevos, INICIA, Accion.Grabar)
                End If


                ''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
                ''dtAislamientosModificados = configurarDataTableDietasParaGrabar(dtAislamientosModificados)
                ''dtAislamientosNuevos = configurarDataTableDietasParaGrabar(dtAislamientosNuevos)

                If dtAislamientosNuevos.Rows.Count > 0 Then
                    intCountAislamientos = dtAislamientosNuevos.Rows.Count
                End If

                ''QUITAR
                ''Se generan los xml que contienen la informacion de los aislamientos
                ' If dtAislamientosModificados.Rows.Count > 0 Then
                xmlAislamientosModifica = FuncionesGenerales.GenerarXMLxProcedimiento(dtAislamientosModificados)
                'End If

                xmlAislamientosNuevos = FuncionesGenerales.GenerarXMLxProcedimiento(dtAislamientosNuevos)

                '----------------------------DIETAS-----------------------------------
                ''Se buscan las dietas que han sido modificadas 
                If dtDietasModificadas.Rows.Count > 0 Then
                    dtDietasModificadas = filtrarTabla(dtDietasAnt, DataViewRowState.ModifiedCurrent, dtDietasModificadas)
                    procesarCampoTratamiento(dtDietasModificadas, INICIA, Accion.Grabar)
                End If

                ''Cambia el campo tratamiento cuando es Null al valor I por 


                asignarSecuencia(dtDietasAnt)
                ''Se buscan las dietas nuevas.Tambien se adicionan los registros 
                ''modificados ya que estos se insertan con un nuevo numero de orden quedando activos en la nueva orden.
                dtDietasNuevas = filtrarTabla(dtDietasAnt, DataViewRowState.Added, dtDietasNuevas)
                dtDietasNuevas = filtrarTabla(dtDietasAnt, DataViewRowState.ModifiedCurrent, dtDietasNuevas)

                ''Cambia el campo tratamiento cuando es Null al valor I por 
                procesarCampoTratamiento(dtDietasNuevas, INICIA, Accion.Grabar)

                ''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
                If dtDietasModificadas.Rows.Count > 0 Then
                    dtDietasModificadas = configurarDataTableDietasParaGrabar(dtDietasModificadas)
                End If

                dtDietasNuevas = configurarDataTableDietasParaGrabar(dtDietasNuevas)

                If dtDietasNuevas.Rows.Count > 0 Then
                    intCountDietas = dtDietasNuevas.Rows.Count
                End If


                ''Se generan los xml que contienen la informacion de las dietas
                dtDietasModificadas.Rows.Clear()
                xmlDietasModifica = FuncionesGenerales.GenerarXMLxProcedimiento(dtDietasModificadas)

                dtDietasNuevas.Rows.Clear()
                xmlDietasNuevas = FuncionesGenerales.GenerarXMLxProcedimiento(dtDietasNuevas)

                '--------------------------MEDICAMENTOS--------------------------------
                ''Se buscan los medicamentos modificados 
                If dtMedicaModificados.Rows.Count > 0 Then
                    dtMedicaModificados = filtrarTabla(dtMedicamentosAnt, DataViewRowState.ModifiedCurrent, dtMedicaModificados)
                    ''Cambia el campo tratamiento que esta en null por I Iniciado
                    procesarCampoTratamiento(dtMedicaModificados, INICIA, Accion.Grabar)
                End If


                asignarSecuencia(dtMedicamentosAnt)
                ''Se buscan  los medicamentos nuevos.Tambien se adicionan los registros 
                ''modificados ya que estos se insertan con un nuevo numero de orden quedando activos en la nueva orden.
                dtMedicaNuevos = filtrarTabla(dtMedicamentosAnt, DataViewRowState.Added, dtMedicaNuevos)
                dtMedicaNuevos = filtrarTabla(dtMedicamentosAnt, DataViewRowState.ModifiedCurrent, dtMedicaNuevos)
                ''Cambia el campo tratamiento que esta en null por I Iniciado
                procesarCampoTratamiento(dtMedicaNuevos, INICIA, Accion.Grabar)

                ''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
                If dtMedicaModificados.Rows.Count > 0 Then
                    dtMedicaModificados = configurarDataTableMedicaParaGrabar(dtMedicaModificados)
                End If

                dtMedicaNuevos = configurarDataTableMedicaParaGrabar(dtMedicaNuevos)

                If dtMedicaNuevos.Rows.Count > 0 Then
                    intCountMedicamento = dtMedicaNuevos.Rows.Count
                End If

                ''Se generan los xml que contiene la informacion de los medicamentos
                dtMedicaModificados.Rows.Clear()
                xmlMedicaModificados = FuncionesGenerales.GenerarXMLxProcedimiento(dtMedicaModificados)
                dtMedicaNuevos.Rows.Clear()
                xmlMedicaNuevos = FuncionesGenerales.GenerarXMLxProcedimiento(dtMedicaNuevos)


                '-------------------------PROCEDIMIENTOS--------------------------------

                ''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
                dtproceNuevos = configurarDataTableProcedimParaGrabar(dtproceNuevos)

                strGeneraPedidoLabo = "N"
                If dtproceNuevos.Rows.Count > 0 Then
                    procedimHomologo = ""
                    entidadvalida = ""
                    strGeneraPedido = ""
                    'strGeneraPedidoLabo = ""
                    For i = 0 To dtproceNuevos.Rows.Count - 1
                        daoOrden.ConsultarDatosGrabacionPedidosRisHomolo(cod_pre_sgs, strCodSucur, tip_admision, num_adm, ano_adm,
                        dtproceNuevos.Rows(i).Item("procedim").ToString, strGeneraPedido, procedimHomologo, IIf(IsDBNull(dtproceNuevos.Rows(i).Item("entidad")), "", dtproceNuevos.Rows(i).Item("entidad")), dtproceNuevos.Rows(i).Item("cen_cos_des").ToString, LinkedServer)
                        ' agfa_orm_in herojas 2014/10/10 Si el procedimiento se realiza en la sede se hace pedido
                        If strGeneraPedido = "S" And (dtproceNuevos.Rows(i).Item("numconsulta").ToString = "1" _
                         Or dtproceNuevos.Rows(i).Item("numconsulta").ToString = "2" Or dtproceNuevos.Rows(i).Item("numconsulta").ToString = "5") Then
                            dtproceNuevos.Rows(i).Item("procedimhomologo") = procedimHomologo
                            dtproceNuevos.Rows(i).Item("entidadpedido") = IIf(IsDBNull(dtproceNuevos.Rows(i).Item("entidad")), "", dtproceNuevos.Rows(i).Item("entidad"))
                            If dtproceNuevos.Rows(i).Item("numconsulta").ToString = "5" Then
                                dtproceNuevos.Rows(i).Item("cod_Labor") = IIf(IsDBNull(dtproceNuevos.Rows(i).Item("codigo_ris")), "0", dtproceNuevos.Rows(i).Item("codigo_ris"))
                                dtproceNuevos.Rows(i).Item("codigo_ris") = ""
                                If dtproceNuevos.Rows(i).Item("grabaPedido") = "N" Then
                                    dtproceNuevos.Rows(i).Item("cod_Labor") = "0"
                                End If
                            Else
                                dtproceNuevos.Rows(i).Item("cod_Labor") = "0"
                                dtproceNuevos.Rows(i).Item("grabaPedido") = "S"
                            End If

                        Else
                            dtproceNuevos.Rows(i).Item("grabaPedido") = "N"
                            If dtproceNuevos.Rows(i).Item("numconsulta").ToString = "5" Then
                                dtproceNuevos.Rows(i).Item("cod_Labor") = IIf(IsDBNull(dtproceNuevos.Rows(i).Item("codigo_ris")), "0", dtproceNuevos.Rows(i).Item("codigo_ris"))
                                dtproceNuevos.Rows(i).Item("codigo_ris") = ""
                            Else
                                dtproceNuevos.Rows(i).Item("cod_Labor") = "0"
                            End If

                        End If
                        If dtproceNuevos.Rows(i).Item("tieneCcostoLabo") = "S" Then
                            strGeneraPedidoLabo = dtproceNuevos.Rows(i).Item("tieneCcostoLabo")
                        End If
                    Next

                End If

                ''Se buscan los registro nuevos de los procedimientos. 
                'dtproceNuevos = filtrarTabla(dtProcedimientos, DataViewRowState.Added, dtproceNuevos)                
                If strGeneraPedidoLabo = "N" Then
                    dtProcedimXCentroCosto = filtrarProcedimientosXCentroDeCosto(dtproceNuevos)
                Else
                    dtProcedimXCentroCosto = filtrarProcedimientosxEnt(dtproceNuevos)
                End If
                ''Se genera el xml que contiene la informacion de los registro a insertar
                xmlProceNuevos = ""

                If dtproceNuevos.Rows.Count > 0 Then
                    intCountProcedimiento = dtproceNuevos.Rows.Count
                End If

                Dim TABLE_PROCEDIMIETNOS As DataTable
                TABLE_PROCEDIMIETNOS = dtproceNuevos.Clone()

                For X As Integer = 0 To dtproceNuevos.Rows.Count - 1
                    If dtproceNuevos.Rows(X)("numconsulta") = "2" Or dtproceNuevos.Rows(X)("numconsulta") = "4" Then
                        TABLE_PROCEDIMIETNOS.ImportRow(dtproceNuevos.Rows(X))
                    End If
                Next

                'For i = 0 To dtProcedimXCentroCosto.Count - 1
                '    'TABLE_PROCEDIMIETNOS = dtProcedimXCentroCosto.Item(i)
                '    TABLE_PROCEDIMIETNOS = New DataTable
                '    Dim j As Integer
                '    For j = 0 To dtProcedimXCentroCosto.Item(i).Rows.Count - 1
                '        If dtProcedimXCentroCosto.Item(i).Rows(j)("numconsulta") = "2" Or dtProcedimXCentroCosto.Item(i).Rows(j)("numconsulta") = "4" Then
                '            TABLE_PROCEDIMIETNOS.Rows.Add(dtProcedimXCentroCosto.Item(i).Rows(j))
                '        End If
                '    Next
                '    '  asignarSecuencia(dtProcedimXCentroCosto.Item(i))
                '    ' xmlProceNuevos = xmlProceNuevos & FuncionesGenerales.GenerarXMLxProcedimiento(dtProcedimXCentroCosto.Item(i))
                'Next

                asignarSecuencia(TABLE_PROCEDIMIETNOS)
                'Joseph Moreno (IG) Fec:2019/11/26 Particularidades
                'xmlProceNuevos = xmlProceNuevos & FuncionesGenerales.GenerarXMLxProcedimiento(TABLE_PROCEDIMIETNOS)
                xmlProceNuevos = FuncionesGenerales.GenerarXMLxProcedimiento(
                                       TABLE_PROCEDIMIETNOS,
                                       New HashSet(Of String)({"particularidades", "procedimientos"})
                                 )


                '----------------------------ORDENES GENERALES----------------------------  
                'Se buscan los registros modificados de las ordenes generales. Estas ordenes se inactivan
                'y se crea una nueva orden con los nuevos datos(Continuar, suspender)
                dtGeneralesModificados.Rows.Clear()
                If dtGeneralesModificados.Rows.Count > 0 Then
                    dtGeneralesModificados = filtrarTabla(dtGeneralesAnt, DataViewRowState.ModifiedCurrent, dtGeneralesModificados)
                    ''Cambia el campo tratamiento que esta en null por I Iniciado
                    procesarCampoTratamiento(dtGeneralesModificados, INICIA, Accion.Grabar)
                End If



                ''Se buscan los registros nuevos de las ordenes generales
                dtGeneralesNuevos.Rows.Clear()
                asignarSecuencia(dtGeneralesNuevos)
                dtGeneralesNuevos = filtrarTabla(dtGeneralesAnt, DataViewRowState.Added, dtGeneralesNuevos)
                dtGeneralesNuevos = filtrarTabla(dtGeneralesAnt, DataViewRowState.ModifiedCurrent, dtGeneralesNuevos)
                ''Cambia el campo tratamiento que esta en null por I Iniciado
                procesarCampoTratamiento(dtGeneralesNuevos, INICIA, Accion.Grabar)

                dtGeneralesModificados.Rows.Clear()
                ''Se eliminan las colunmas que contienen informacion innecesaria para la grabacion
                If dtGeneralesModificados.Rows.Count > 0 Then
                    dtGeneralesModificados = configurarDataTableOrdenGeneralParaGrabar(dtGeneralesModificados)
                End If

                dtGeneralesNuevos.Rows.Clear()

                dtGeneralesNuevos = configurarDataTableOrdenGeneralParaGrabar(dtGeneralesNuevos)

                If dtGeneralesNuevos.Rows.Count > 0 Then
                    intCountGenerales = dtGeneralesNuevos.Rows.Count
                End If


                xmlGeneralesModificados = FuncionesGenerales.GenerarXMLxProcedimiento(dtGeneralesModificados)
                xmlGeneralesNuevos = FuncionesGenerales.GenerarXMLxProcedimiento(dtGeneralesNuevos)


                ''Validar si existen datos para grabar 
                If dtDietasModificadas.Rows.Count <= 0 And dtDietasNuevas.Rows.Count <= 0 And
                    dtMedicaModificados.Rows.Count <= 0 And dtMedicaNuevos.Rows.Count <= 0 And
                    dtproceNuevos.Rows.Count <= 0 And dtGeneralesModificados.Rows.Count <= 0 And
                    dtGeneralesNuevos.Rows.Count <= 0 Then
                    dtRespuesta.Rows.Add("", "", "", 999)
                    Return dtRespuesta  ''No existen datos para guardar
                End If



                ''Procedimiento que llama al stored procedure que graba
                Try
                    ''

                    BLOrdenes.GrabarErroresOrdenesMedicasHomolo("HistoriaMedicaCTC" & Mid(xmlMedicaNuevos, 1, 5000), LinkedServer)

                    xmlAislamientosNuevos = "<?xml version='1.0' encoding='ISO-8859-1' ?><Raiz></Raiz>"
                    xmlAislamientosModifica = "<?xml version='1.0' encoding='ISO-8859-1' ?><Raiz></Raiz>"
                    xmlDietasModifica = "<?xml version='1.0' encoding='ISO-8859-1' ?><Raiz></Raiz>"
                    xmlDietasNuevas = "<?xml version='1.0' encoding='ISO-8859-1' ?><Raiz></Raiz>"
                    xmlMedicaModificados = "<?xml version='1.0' encoding='ISO-8859-1' ?><Raiz></Raiz>"
                    xmlMedicaNuevos = "<?xml version='1.0' encoding='ISO-8859-1' ?><Raiz></Raiz>"
                    xmlGeneralesModificados = "<?xml version='1.0' encoding='ISO-8859-1' ?><Raiz></Raiz>"
                    xmlGeneralesNuevos = "<?xml version='1.0' encoding='ISO-8859-1' ?><Raiz></Raiz>"

                    If strGeneraPedidoLabo = "N" Then

                        dtRespuesta = daoOrden.guardarOrdenesHomologadas(objConexion, LinkedServer, cod_pre_sgs, strCodSucur, tip_admision, num_adm,
                                                                           ano_adm, loginHomologacion, medico, strCodEspecialidad, entidad,
                                                                           xmlAislamientosModifica, xmlAislamientosNuevos,
                                                                           xmlDietasModifica, xmlDietasNuevas, xmlMedicaModificados,
                                                                           xmlMedicaNuevos, xmlProceNuevos, xmlGeneralesModificados,
                                                                           xmlGeneralesNuevos, NroOrden, fechaOrden, centroCostoOrigen,
                                                                           strGuia, strJustificacion, strTipoServicio, strPrioridad)
                    Else
                        dtRespuesta = daoOrden.guardarOrdenesLaboHomologada(objConexion, LinkedServer, cod_pre_sgs, strCodSucur, tip_admision, num_adm,
                                                                           ano_adm, loginHomologacion, medico, strCodEspecialidad, entidad,
                                                                           xmlAislamientosModifica, xmlAislamientosNuevos,
                                                                           xmlDietasModifica, xmlDietasNuevas, xmlMedicaModificados,
                                                                           xmlMedicaNuevos, xmlProceNuevos, xmlGeneralesModificados,
                                                                           xmlGeneralesNuevos, NroOrden, fechaOrden, centroCostoOrigen,
                                                                           strGuia, strJustificacion, strTipoServicio, strPrioridad)

                    End If
                Catch ex As Exception
                    BLOrdenes.GrabarErroresOrdenesMedicasHomolo("HistoriaMedicaCTC" & Mid(xmlMedicaNuevos, 1, 5000) & ex.Source & " - " & Environment.MachineName.ToString & " - " & " - " & ex.StackTrace & " - " & ex.TargetSite.ToString, LinkedServer)
                    MsgBox("Error al guardar ordenes " & ex.Message)
                End Try

                If lError <> 0 Then
                    dtRespuesta.Rows.Add("", "", "", lError)
                    Return dtRespuesta
                Else
                    Dim objP As objPaciente = objpaciente.Instancia
                    Dim strPrioridadtmp As String = strPrioridad

                    If strPrioridadtmp = "" Then
                        ' se le agrega cambio de prioridad por urgente cuando el procedimiento es para U o para una H
                        ' Realizado herojas, cambio solicitado por ORM - Agfa
                        If objpaciente.TipoAdmision = "U" Or objpaciente.TipoAdmision = "H" Then
                            strPrioridadtmp = "1"
                        Else
                            strPrioridadtmp = "3"
                        End If
                    End If



                    Agfa = daogeneral.EjecutarSQLStrValor(LinkedServer + "[dbo].[gensucur] with (nolock)", objConexion, " agfa", " cod_sucur='" & strCodSucur & "'")
                    If IIf(IsDBNull(Agfa), "N", Agfa) = "S" Then

                        If Len(strCodSucur) = 3 Then
                            strCodSucuragfa = "0" & strCodSucur
                        Else
                            strCodSucuragfa = strCodSucur
                        End If



                        For Each dr As DataRow In dtProcedimientosAnt.Rows

                            ' Evalua procedimiento ris es realizado en la sede numconsulta="2"

                            If dr("OrigenProcedim") = "RIS" And dr("numconsulta") = 2 Then

                                'agfa_orm_in herojas traer el numero del pedido en la variable nuor mPedido
                                daoOrden.ConsultarDatosPedidoOrdenRisHomolo(cod_pre_sgs, strCodSucur, tip_admision, num_adm, ano_adm, NroOrden, dr("procedim"), numPedido, LinkedServer)

                                dtproceris = daogeneral.EjecutarSQLConParametros(LinkedServer + "[dbo].[genproceris]", objConexion, "cod_sucur", " codigo_ris='" & dr("codigo_ris") & "' and procedim='" & dr("procedim") & "'")

                                intGraba = intGraba + 1
                                ' se concatena la sucursal a la admision. Solicitud agfa proyecto agfa_orm_in herojas
                                ' se le agrega la entidad 2014/09/15 agfa_orm_in
                                ' se le agregan los parametros tipo, año y numero de admision herojas 2015/02/11
                                lError = daoOrden.guardarOrdenesAGFAhomologacion(objConexion, "N", FuncionesGenerales.FechaServidor(), objpaciente.TipoDocumento & objpaciente.NumeroDocumento,
                                         objpaciente.PrimerNombre, objpaciente.PrimerApellido, objpaciente.FechaNacimiento,
                                         objpaciente.Genero, "", tip_admision,
                                         tip_admision & ano_adm & num_adm & "-" & strCodSucuragfa,
                                         NroOrden, strCodSucur, NroOrden, FuncionesGenerales.FechaServidor(),
                                         FuncionesGenerales.FechaServidor().AddDays(1), strPrioridadtmp, loginHomologacion, loginHomologacion,
                                         0, dr("codigo_ris"), dr("descripcion_proce"), fechaOrden, strJustificacion, dr("obs"),
                                        dr("cen_cos_origen"), dr("cen_cos_des"), numPedido, strCodSucur, cod_pre_sgs,
                                        dr("entidad"), dr("procedim"), ObjGeneral.NombreMedico,
                                        ano_adm, num_adm, LinkedServer, intGraba)


                            End If
                        Next
                    End If

                End If

            Else

                lError = GrabarOrdenesNutricion(objConexion, cod_pre_sgs, strCodSucur, tip_admision, num_adm, ano_adm,
                         strLogin, medico, strCodEspecialidad, entidad, dtDietasAnt, NroOrden, fechaOrden, intCountDietas)

                If lError <> 0 Then
                    strMensaje = " -Dietas"
                End If


                lError = GrabarOrdenesMedicamentos(objConexion, cod_pre_sgs, strCodSucur, tip_admision, num_adm, ano_adm,
                strLogin, medico, strCodEspecialidad, entidad, dtMedicamentosAnt, NroOrden, fechaOrden, intCountMedicamento)

                If lError <> 0 Then
                    strMensaje = +" -Medicamentos"
                End If

                lError = GrabarOrdenesProcedimientos(objConexion, cod_pre_sgs, strCodSucur, tip_admision, num_adm, ano_adm,
                strLogin, medico, strCodEspecialidad, entidad, dtProcedimientosAnt, NroOrden, fechaOrden, centroCostoOrigen, strGuia,
                strJustificacion, strTipoServicio, strPrioridad, CodProcedim, intCountProcedimiento)

                If lError <> 0 Then
                    strMensaje = +" -Procedimientos"
                End If

                lError = GrabarOrdenesGenerales(objConexion, cod_pre_sgs, strCodSucur, tip_admision, num_adm, ano_adm,
                strLogin, medico, strCodEspecialidad, entidad, dtGeneralesAnt, NroOrden, fechaOrden, intCountGenerales)

                If lError <> 0 Then
                    strMensaje = +" -Generales"
                End If

                If Len(strMensaje) > 0 Then
                    MsgBox("Error al grabar Ordenes " & strMensaje)
                End If


            End If

            Try
                daoOrden.GrabarAuditOrdenes(objConexion, cod_pre_sgs, strCodSucur, tip_admision, ano_adm, num_adm,
                objpaciente.TipoDocumento & objpaciente.NumeroDocumento, strLogin, intCountMedicamento, intCountGenerales,
                intCountDietas, intCountProcedimiento, NroOrden, strMensaje & CStr(lError), "OR")
            Catch ex As Exception

            End Try

            Return dtRespuesta
        End Function

        ''' <summary>
        ''' Metodo encargado de guardar el log de homologacion
        ''' </summary>
        ''' <param name="sEntidadPrestadora"></param>
        ''' <param name="sCodigoSucursal"></param>
        ''' <param name="sEntidad"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GuardarLogHomologacion(ByVal Codigo_Admision_Origen As Decimal,
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
            Dim daoOrden As New DAOOrdenes
            Return daoOrden.GuardarLogHomologacion(Codigo_Admision_Origen, Ano_Admision_Origen, Tipo_Admision_Origen,
                    Codigo_Admision_Destino, Ano_Admision_Destino, Tipo_Admision_Destino, Codigo_Orden_Origen, Codigo_Orden_Destino,
                    cod_pre_sgs_origen, cod_pre_sgs_destino, cod_sucur_origen, cod_sucur_destino, Numero_Documento, Tipo_Documento,
                    Id_Localizacion_Origen, Id_Localizacion_Destino, fec_con, login, obs, LinkedServer)
        End Function

        ''Daniel Sanchez 04-Octubre-2017 - IG
        Public Shared Function consultarAislamiento(ByVal objConexion As Conexion, ByVal condicion As String) As DataTable

            Dim daoOrden As New DAOOrdenes()
            Dim dtInfo As DataTable

            dtInfo = daoOrden.consultarAislamiento(objConexion, condicion)
            Return dtInfo

        End Function

        ''Daniel Sanchez 06-Octubre-2017 - ID
        Public Shared Function consultarIdAislamiento(ByVal objConexion As Conexion, ByVal nombreAislamiento As String) As Integer

            Dim daoOrden As New DAOOrdenes()
            Dim id As Integer

            If nombreAislamiento = My.Resources.aislaNoRequerido.ToString() Then

                id = 0

            Else

                id = daoOrden.consultarIdAislamiento(objConexion, nombreAislamiento)

            End If

            Return id

        End Function

        'Dsanchez IG - 26/10/2017, Metodo que se usa para obtener las medidas asociadas a un aislamiento
        Public Shared Function ConsultarMedidasAislamiento(ByVal nombreAislamiento As String) As String

            Dim daoOrden As New DAOOrdenes()
            Dim dtInfo As DataTable = New DataTable()
            Dim resultado As String = String.Empty

            dtInfo = daoOrden.ConsultarMedidasAislamiento(nombreAislamiento)

            For Each fila As DataRow In dtInfo.Rows

                resultado = fila("Medida").ToString()

            Next

            Return resultado

        End Function

        Public Shared Function ConsultarLoginHomologacion(ByVal LinkedServer As String) As String
            Dim daoOrden As New DAOOrdenes
            Return daoOrden.ConsultarLoginHomologacion(LinkedServer)
        End Function

        Public Shared Function ConsultarHomologacionTipoDocumento(ByVal tipoDocumento As String) As String
            Dim daoOrden As New DAOOrdenes
            Return daoOrden.ConsultarHomologacionTipoDocumento(tipoDocumento)
        End Function
        ''' <summary>
        ''' eloaiza@intergrupo
        ''' 30-08-2019
        ''' Recuperar el valor de un parametro de la tabla de parametros dado el nombre del mismo
        ''' </summary>
        ''' <param name="paramName">Nombre del parametro a buscar</param>
        ''' <param name="LinkedServer">Opcional - Nombre o Direccion del servidor vinculado que se consultara</param>
        ''' <returns>String</returns>
        Public Shared Function ConsultarParametros(ByVal paramName As String, Optional ByVal LinkedServer As String = "") As String
            Dim daoOrden As New DAOOrdenes
            Return daoOrden.ConsultarParametrosGenerico(paramName, LinkedServer)
        End Function

        Public Shared Function ConsultaGeneral_PAC360(ByVal strTipoDocumento As String, strNumDocumento As String, ByVal Optional intEjecucion As Integer = 0, ByVal Optional arrDatosAdmision() As String = Nothing) As DataTable
            Return New DAOOrdenes().ConsultaGeneral_PAC360(strTipoDocumento, strNumDocumento, intEjecucion, arrDatosAdmision)
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
            Return New DAOOrdenes().AuditoriaConsultasPAC360(cod_historia, strPrestador, strSucur, TipAdmision, Ano_adm, Num_Adm, medico, estado, obs)
        End Function

        Public Function ConsultarFrecuenciasHomologadas(ByVal codFrecuencia As String) As DataTable
            Return New DAOOrdenes().ConsultarFrecuenciasHomologadas(codFrecuencia)
        End Function


        Public Shared Function Consultarparametros_Pyxis() As DataTable
            Return New DAOOrdenes().Consultar_Parametros_PYXIS()
        End Function


        Public Shared Function CreateJsonObjectPyxis(ByVal DatosPaciente As DataTable, ByVal Medicamentos As DataTable, nroOrden As String, cencosto As String) As String
            Dim ObjetoSerializado As String

            CreateJsonObjectPyxis = 0

            Try


                Dim entAdmision As admision = New admision()
                Dim entUbicacion As ubicacion = New ubicacion()
                Dim listaMedicamentos As List(Of medicamentos) = New List(Of medicamentos)()
                Dim entPrescribe As prescribe = New prescribe()
                Dim peticionPx As New RequestPyxis()
                Dim marcaOrdendia As String


                Dim dtMedicaModificados As New DataTable
                Dim dtMedicaNuevos As New DataTable

                dtMedicaModificados = Medicamentos.Clone()
                dtMedicaNuevos = Medicamentos.Clone()


                dtMedicaModificados = filtrarTabla(Medicamentos, DataViewRowState.ModifiedCurrent, dtMedicaModificados)
                'Cambia el campo tratamiento que esta en null por I Iniciado
                procesarCampoTratamiento(dtMedicaModificados, INICIA, Accion.Grabar)

                asignarSecuencia(Medicamentos)
                dtMedicaNuevos = filtrarTabla(Medicamentos, DataViewRowState.Added, dtMedicaNuevos)
                dtMedicaNuevos = filtrarTabla(Medicamentos, DataViewRowState.ModifiedCurrent, dtMedicaNuevos)

                procesarCampoTratamiento(dtMedicaNuevos, INICIA, Accion.Grabar)

                dtMedicaModificados = configurarDataTableMedicaParaGrabar(dtMedicaModificados)

                dtMedicaNuevos = configurarDataTableMedicaParaGrabar(dtMedicaNuevos)

                ' Llamar procedimiento almacenado para centros de costo
                'Dim dtCenCosto As DataTable = New DAOOrdenes().ConsultaCenCosto_Pyxis(objGenerales.Instancia.Prestador, objGenerales.Instancia.Sucursal, DatosPaciente.Rows(0)("TipoAdmision").ToString(),
                'DatosPaciente.Rows(0)("NumeroAdmision").ToString(), DatosPaciente.Rows(0)("AnoAdmision").ToString())

                'HCEnf_ConsultaexisteORpyxis
                'ConsultaOrdenmed_Pyxis

                dtMedicaNuevos.Columns.Remove("tmp_suspender_med")
                dtMedicaNuevos.Columns.Remove("tmp_modificar_med")
                dtMedicaModificados.Columns.Remove("tmp_suspender_med")
                dtMedicaModificados.Columns.Remove("tmp_modificar_med")

                dtMedicaNuevos = Comunes.FuncionesGenerales.ReOrganizarColumnasEnDatatable(dtMedicaNuevos, columnasMedicamentos)
                dtMedicaModificados = Comunes.FuncionesGenerales.ReOrganizarColumnasEnDatatable(dtMedicaModificados, columnasMedicamentos)


                Dim dtOrdenMeddia As DataTable = New DAOOrdenes().ConsultaOrdenmedDia_Pyxis(objGenerales.Instancia.Prestador, objGenerales.Instancia.Sucursal, DatosPaciente.Rows(0)("TipoAdmision").ToString(), DatosPaciente.Rows(0)("AnoAdmision").ToString(), DatosPaciente.Rows(0)("NumeroAdmision").ToString(), nroOrden, dtMedicaModificados, dtMedicaNuevos)

                marcaOrdendia = dtOrdenMeddia.Rows(0).Item("ExisteOrden").ToString()


                If marcaOrdendia = "N" Then
                    Dim dtOrdenMed As DataTable = New DAOOrdenes().ConsultaOrdenmed_Pyxis(objGenerales.Instancia.Prestador, objGenerales.Instancia.Sucursal, DatosPaciente.Rows(0)("TipoAdmision").ToString(),
                                                                                        DatosPaciente.Rows(0)("AnoAdmision").ToString(), DatosPaciente.Rows(0)("NumeroAdmision").ToString())
                    If dtOrdenMed.Rows(0).Item("ExisteOrden").ToString() = "N" Then

                        ' Datos Admision
                        Dim dtAdmicsion As DataTable = New DAOOrdenes().ConsultaAdmisionSer_Pyxis(objGenerales.Instancia.Prestador, objGenerales.Instancia.Sucursal, DatosPaciente.Rows(0)("TipoAdmision").ToString(),
                                                                                        DatosPaciente.Rows(0)("AnoAdmision").ToString(), DatosPaciente.Rows(0)("NumeroAdmision").ToString())

                        entAdmision.id_Admision = dtAdmicsion.Rows(0).Item("id_Admision").ToString()
                        entAdmision.id_Admision_Anterior = dtAdmicsion.Rows(0).Item("Idadmision_anterior").ToString()
                        entAdmision.tipo_Documento = dtAdmicsion.Rows(0).Item("tipo_Documento").ToString()
                        entAdmision.id_Paciente = dtAdmicsion.Rows(0).Item("id_Paciente").ToString()
                        entAdmision.tipo_Admision = dtAdmicsion.Rows(0).Item("tipo_Admision").ToString()
                        entAdmision.fecha_Admision = dtAdmicsion.Rows(0).Item("fecha_Admision").ToString()
                        entAdmision.apellido_Paterno = dtAdmicsion.Rows(0).Item("apellido_Paterno").ToString()
                        entAdmision.apellido_Materno = dtAdmicsion.Rows(0).Item("apellido_Materno").ToString()
                        entAdmision.nombres = dtAdmicsion.Rows(0).Item("nombres").ToString()
                        entAdmision.sexo = dtAdmicsion.Rows(0).Item("sexo").ToString()
                        entAdmision.peso = dtAdmicsion.Rows(0).Item("peso").ToString()
                        entAdmision.edad = dtAdmicsion.Rows(0).Item("edad").ToString()
                        entAdmision.fecha_Nacimiento = dtAdmicsion.Rows(0).Item("fecha_Nacimiento").ToString()
                        entAdmision.fecha_Alta_Paciente = dtAdmicsion.Rows(0).Item("fecha_Alta_Paciente").ToString()
                        entAdmision.estado_Procesamiento = dtAdmicsion.Rows(0).Item("estado_Procesamiento").ToString()
                        entAdmision.estado_Admision = dtAdmicsion.Rows(0).Item("estado_Admision").ToString()

                        'entAdmision.Id_Alternativo = dtAdmicsion.Rows(0).Item("Id_Alternativo").ToString()
                        'entAdmision.tipo_Documento = DatosPaciente.Rows(0)("TipoDocumento").ToString()
                        ''entAdmision.id_Alternativo = String.Empty
                        'entAdmision.id_Paciente = DatosPaciente.Rows(0)("NumeroDocumento").ToString()
                        'entAdmision.fecha_Admision = DatosPaciente.Rows(0)("FechaHoraAdmision") '.ToString("MM-dd-yyyy HH:mm:ss")
                        'entAdmision.apellido_Paterno = DatosPaciente.Rows(0)("PrimerApellido").ToString()
                        'entAdmision.apellido_Materno = DatosPaciente.Rows(0)("SegundoApellido").ToString()
                        'entAdmision.nombres = DatosPaciente.Rows(0)("NombreCompleto").ToString()
                        'entAdmision.sexo = DatosPaciente.Rows(0)("Genero").ToString()
                        'entAdmision.fecha_Nacimiento = DatosPaciente.Rows(0)("FechaNacimiento") '.ToString("MM-dd-yyyy")
                        'entAdmision.fecha_Alta_Paciente = String.Empty
                        'entAdmision.estado_Procesamiento = "N"
                        'entAdmision.tipo_Admision = DatosPaciente.Rows(0)("TipoAdmision").ToString()
                        'entAdmision.estado_Admision = "I" ' DatosPaciente.Rows(0)("EstadoAdmision").ToString()
                        'entAdmision.fecha_Upd_Estado = String.Empty
                        ''entAdmision.estado_Proceso_Alta = "N"
                        ''entAdmision.mensaje_Error = String.Empty
                        ''entAdmision.fecha_Hora_Procesamiento = String.Empty 'DateTime.Now.ToString("MM-dd-yyyy HH:mi:ss")
                        ''entAdmision.fecha_Hora_Proc_Alta = String.Empty
                        ''entAdmision.fecha_Creacion = String.Empty 'DatosPaciente.Rows(0)("FechaHoraAdmision").ToString()
                        'entAdmision.fecha_Ultima_Actualizacion = String.Empty 'DateTime.Now.ToString("MM-dd-yyyy HH:mi:ss")
                        ''entAdmision.sitio_Dispensacion = objGenerales.Instancia.Prestador & "-" & objGenerales.Instancia.Sucursal
                        'entAdmision.id_Admision = objGenerales.Instancia.Prestador & "-" & objGenerales.Instancia.Sucursal & "-" &
                        '                          DatosPaciente.Rows(0)("TipoAdmision").ToString() & "-" & DatosPaciente.Rows(0)("AnoAdmision").ToString() & "-" &
                        '                          DatosPaciente.Rows(0)("NumeroAdmision").ToString()

                        peticionPx.admision = entAdmision

                        'Datos Ubicación

                        Dim dtUbicacion As DataTable = New DAOOrdenes().ConsultaUbicacionSer_Pyxis(objGenerales.Instancia.Prestador, objGenerales.Instancia.Sucursal, DatosPaciente.Rows(0)("TipoAdmision").ToString(),
                                                                                          DatosPaciente.Rows(0)("AnoAdmision").ToString(), DatosPaciente.Rows(0)("NumeroAdmision").ToString())

                        entUbicacion.id_Admision = dtUbicacion.Rows(0).Item("id_Admision").ToString()
                        entUbicacion.id_Ubicacion = dtUbicacion.Rows(0).Item("id_Ubicacion").ToString()
                        entUbicacion.unidad_Enfermeria = dtUbicacion.Rows(0).Item("Unidad_Enfermeria").ToString()
                        entUbicacion.id_Cama = dtUbicacion.Rows(0).Item("id_cama").ToString()
                        entUbicacion.estado_Procesamiento = dtUbicacion.Rows(0).Item("Estado_procesamiento").ToString()

                        'entUbicacion.sec_Ubicacion = String.Empty
                        'entUbicacion.id_Ubicacion = "1" 'String.Empty
                        'entUbicacion.id_Admision = entAdmision.id_Admision
                        'entUbicacion.unidad_Enfermeria = "1" 'IIf(String.IsNullOrEmpty(dtCenCosto.Rows(0).Item("CCORIGEN").ToString()), "", dtCenCosto.Rows(0).Item("CCORIGEN").ToString())
                        'entUbicacion.sala = String.Empty
                        'entUbicacion.id_Cama = "Cons1" 'DatosPaciente.Rows(0)("Cama").ToString()
                        'entUbicacion.id_Medico = objGenerales.Instancia.RegistroMedico
                        ''entUbicacion.nombre_Medico = objGenerales.Instancia.NombreMedico
                        ''entUbicacion.episodio = String.Empty
                        'entUbicacion.estado_Procesamiento = "N"
                        ''entUbicacion.mensaje_Error = String.Empty
                        ''entUbicacion.fecha_Hora_Procesamiento = String.Empty
                        ''entUbicacion.fecha_Creacion = entAdmision.fecha_Creacion
                        ''entUbicacion.fecha_Ultima_Actualizacion = String.Empty
                        'entUbicacion.sitio_Dispensacion = objGenerales.Instancia.Prestador & "-" & objGenerales.Instancia.Sucursal
                        peticionPx.ubicacion = entUbicacion
                    End If






                    Dim dtPrescripcion As DataTable = New DAOOrdenes().ConsultaPrescripcionSer_Pyxis(objGenerales.Instancia.Prestador, objGenerales.Instancia.Sucursal, DatosPaciente.Rows(0)("TipoAdmision").ToString(),
                                                                                      DatosPaciente.Rows(0)("AnoAdmision").ToString(), DatosPaciente.Rows(0)("NumeroAdmision").ToString(), nroOrden, cencosto, dtMedicaModificados, dtMedicaNuevos)

                    If dtPrescripcion.Rows.Count > 0 Then
                        'Dim ItemMedicamentosMod As medicamentos = New medicamentos()


                        'For Each fila As DataRow In dtMedicaModificados.Rows
                        '    ItemMedicamentosMod.sec_Prescripciones = "1" 'String.Empty 'fila("sec_Prescripciones").ToString()
                        '    ItemMedicamentosMod.frecuencia = fila("Frecuencia").ToString()
                        '    ItemMedicamentosMod.dosis = Decimal.ToInt32(Convert.ToDecimal(fila("Dosis").ToString())).ToString()
                        '    'ItemMedicamentosMod.numero_Orden_Sofia = nroOrden + fila("secuencia").ToString()
                        '    ItemMedicamentosMod.unidad_Dosis = fila("UniMedDosis").ToString()
                        '    ItemMedicamentosMod.volumen = String.Empty
                        '    ItemMedicamentosMod.unidad_De_Volumen = String.Empty
                        '    ItemMedicamentosMod.horas_De_Toma = String.Empty
                        '    ItemMedicamentosMod.fecha_Hora_Inicio = String.Empty
                        '    ItemMedicamentosMod.fecha_Hora_Termino = String.Empty
                        '    ItemMedicamentosMod.codigo_Articulo = fila("producto").ToString()
                        '    ItemMedicamentosMod.descripcion_Articulo = fila("descripcion").ToString()
                        '    ItemMedicamentosMod.via_Administracion = fila("ViaAdministra").ToString()
                        '    ItemMedicamentosMod.observacion = fila("obs").ToString()
                        '    ItemMedicamentos.estado_Procesamiento = "N"
                        '    'ItemMedicamentosMod.estado_ebs = String.Empty
                        '    'ItemMedicamentosMod.atc = String.Empty
                        '    'ItemMedicamentosMod.cod_barras = String.Empty
                        '    'ItemMedicamentosMod.acción_detalle = "CA"
                        '    listaMedicamentos.Add(ItemMedicamentosMod)
                        'Next


                        'For i As Integer = 0 To List.Count - 1 Console.WriteLine("FOR: {0}", list.Item(i)) 

                        'Next i

                        For Each fila As DataRow In dtPrescripcion.Rows
                            Dim ItemMedicamentos As medicamentos = New medicamentos()
                            ItemMedicamentos.numero_Orden_Detalle = fila("numero_Orden_Detalle").ToString()
                            ItemMedicamentos.codigo_Articulo = fila("codigo_Articulo").ToString()
                            ItemMedicamentos.descripcion_Articulo = fila("descripcion_Articulo").ToString()
                            ItemMedicamentos.via_Administracion = fila("via_Administracion").ToString()
                            ItemMedicamentos.frecuencia = fila("Frecuencia").ToString()
                            ItemMedicamentos.dosis = fila("dosis").ToString()
                            ItemMedicamentos.unidad_Dosis = fila("unidad_Dosis").ToString()
                            ItemMedicamentos.estado_Procesamiento_Detalle = fila("estado_Procesamiento_Detalle").ToString()
                            ItemMedicamentos.horas_De_Toma = fila("horas_De_Toma").ToString()
                            ItemMedicamentos.fecha_Hora_Inicio = fila("fecha_Hora_Inicio").ToString()
                            ItemMedicamentos.fecha_Hora_Termino = fila("fecha_Hora_Termino").ToString()
                            ItemMedicamentos.observacion = fila("observacion").ToString()


                            'ItemMedicamentos.sec_Prescripciones = "1" ' String.Empty 'fila("sec_Prescripciones").ToString()
                            'ItemMedicamentos.numero_Orden_Sofia = nroOrden + fila("secuencia").ToString()
                            'ItemMedicamentos.volumen = String.Empty
                            'ItemMedicamentos.unidad_De_Volumen = String.Empty
                            'ItemMedicamentos.estado_ebs = String.Empty
                            'ItemMedicamentos.atc = String.Empty
                            'ItemMedicamentos.cod_barras = String.Empty
                            'ItemMedicamentos.acción_detalle = "NW"
                            listaMedicamentos.Add(ItemMedicamentos)

                        Next fila
                        'If dtPrescripcion.Rows.ToString > 0 Then

                        entPrescribe.id_Admision = dtPrescripcion.Rows(0).Item("id_Admision").ToString()
                        entPrescribe.numero_Orden = dtPrescripcion.Rows(0).Item("numero_Orden").ToString()
                        entPrescribe.tipo_De_Orden = dtPrescripcion.Rows(0).Item("Tipo_de_orden").ToString()
                        entPrescribe.id_Medico = dtPrescripcion.Rows(0).Item("ID_Medico").ToString()
                        entPrescribe.nombre_Medico = dtPrescripcion.Rows(0).Item("Nombre_Medico").ToString()
                        entPrescribe.primer_Apellido_Medico = dtPrescripcion.Rows(0).Item("Primer_Apellido_Medico").ToString()
                        entPrescribe.segundo_Apellido_Medico = dtPrescripcion.Rows(0).Item("Segundo_Apellido_Medico").ToString()
                        entPrescribe.estado_Procesamiento = dtPrescripcion.Rows(0).Item("estado_Procesamiento").ToString()

                        'entPrescribe.sec_Prescripciones = "1" 'String.Empty
                        'entPrescribe.sitio_Dispensacion = entAdmision.sitio_Dispensacion
                        'entPrescribe.id_Admision = entAdmision.id_Admision
                        'entPrescribe.numero_Orden = nroOrden
                        'entPrescribe.tipo_De_Orden = "NW"
                        'entPrescribe.id_Medico = entUbicacion.id_Medico

                        'entPrescribe.estado_Procesamiento = "N"
                        'entPrescribe.tipo_Transaccion = "PI"
                        'entPrescribe.id_Comprador = String.Empty
                        'entPrescribe.login_Ped = String.Emptyr
                        'entPrescribe.login_Des = String.Empty
                        ' entPrescribe.tipo_Id_Comprador = String.Empty
                        'entPrescribe.estado_Ebs = String.Empty
                        'entPrescribe.tipo_Pedido = "P"
                        'entPrescribe.acción = String.Empty
                        'entPrescribe.motivo_Anulación = String.Empty
                        'entPrescribe.fecha_Anulacion = String.Empty
                        'entPrescribe.estado_Anulacion = String.Empty
                        'entPrescribe.mensaje_error_Anulacion = String.Empty
                        'entPrescribe.mensaje_Error = String.Empty
                        'entPrescribe.fecha_Hora_Procesamiento = entUbicacion.fecha_Hora_Procesamiento
                        'entPrescribe.fecha_Creacion = entAdmision.fecha_Creacion
                        'entPrescribe.fecha_Ultima_Actualizacion = entUbicacion.fecha_Ultima_Actualizacion
                        'entPrescribe.observacionGeneral = String.Empty
                        entPrescribe.medicamentos = listaMedicamentos

                        'Dim objetoCompleto = New Dictionary(Of String, Object) From {
                        '    {"admision", entAdmision},
                        '    {"ubicacion", entUbicacion},
                        '    {"prescribe", entPrescribe}
                        '}


                        peticionPx.prescribe = entPrescribe

                        Dim resultado As Object = New Object()
                        Dim parametrospyxis As New DataTable

                        Dim EndPointTransaccionServicioPyxis As String
                        Dim EndPointTokenServicioPyxis As String
                        Dim AuthorizationTypeServicioPyxis As String
                        Dim AuthorizationUsernameServicioPyxis As String
                        Dim AuthorizationPasswordServicioPyxis As String
                        Dim Grant_TypeServicioPyxis As String
                        Dim UserNameServicioPyxis As String
                        Dim PasswordServicioPyxis As String



                        Dim marcaTiempoPeticion As String = Date.Now


                        parametrospyxis = BLOrdenes.Consultarparametros_Pyxis()
                        If parametrospyxis.Rows.Count > 0 Then
                            EndPointTransaccionServicioPyxis = parametrospyxis.Rows(0).Item("EndPointTransaccionServicioPyxis").ToString()
                            EndPointTokenServicioPyxis = parametrospyxis.Rows(0).Item("EndPointTokenServicioPyxis").ToString()
                            AuthorizationTypeServicioPyxis = parametrospyxis.Rows(0).Item("AuthorizationTypeServicioPyxis").ToString()
                            AuthorizationUsernameServicioPyxis = parametrospyxis.Rows(0).Item("AuthorizationUsernameServicioPyxis").ToString()
                            AuthorizationPasswordServicioPyxis = parametrospyxis.Rows(0).Item("AuthorizationPasswordServicioPyxis").ToString()
                            Grant_TypeServicioPyxis = parametrospyxis.Rows(0).Item("Grant_TypeServicioPyxis").ToString()
                            UserNameServicioPyxis = parametrospyxis.Rows(0).Item("UserNameServicioPyxis").ToString()
                            PasswordServicioPyxis = parametrospyxis.Rows(0).Item("PasswordServicioPyxis").ToString()
                        Else
                            EndPointTransaccionServicioPyxis = BLOrdenes.ConsultarParametros("EndPointServicioPixys")
                        End If







                        Dim urlParameters As String = "?grant_type=" + Grant_TypeServicioPyxis + "&username=" + UserNameServicioPyxis + "&password=" + PasswordServicioPyxis

                        Dim client As New HttpClient()
                        client.BaseAddress = New Uri(EndPointTokenServicioPyxis)
                        client.DefaultRequestHeaders.Accept.Add(
                                     New MediaTypeWithQualityHeaderValue("application/json"))

                        Dim securityTokenRequest As New HttpRequestMessage(HttpMethod.Post, "relativeAddress/token")

                        Dim credentials As String = Convert.ToBase64String(ASCIIEncoding.ASCII.GetBytes(AuthorizationUsernameServicioPyxis + ":" + AuthorizationPasswordServicioPyxis))

                        client.DefaultRequestHeaders.Authorization = New System.Net.Http.Headers.AuthenticationHeaderValue(AuthorizationTypeServicioPyxis, credentials)

                        Dim respuestassecurity As HttpResponseMessage
                        Dim respuestasecurity As Object

                        Try
                            respuestassecurity = client.PostAsync(urlParameters, securityTokenRequest.Content).Result
                            respuestasecurity = respuestassecurity.Content.ReadAsStringAsync().Result

                        Catch ex As Exception
                            Dim marcaTiempoRespuesta1 As String = Date.Now
                            Dim registraLog1 As Long = New DAOOrdenes().PyxisGuardarLog(objGenerales.Instancia.Prestador, objGenerales.Instancia.Sucursal,
                                                                                               DatosPaciente.Rows(0)("TipoAdmision").ToString(), DatosPaciente.Rows(0)("NumeroAdmision").ToString(),
                                                                                               DatosPaciente.Rows(0)("AnoAdmision").ToString(), marcaTiempoPeticion, marcaTiempoRespuesta1, "",
                                                                                               "El validador NO esta disponible", "500")

                            'MessageBox.Show(ex.Message)
                            MsgBox("El validador NO esta disponible")
                            CreateJsonObjectPyxis = 1
                            'Exit Function
                        End Try
                        'Dim codtocken As New Token


                        Dim sJsonObj As Token
                        sJsonObj = JsonConvert.DeserializeObject(Of Token)(respuestasecurity)

                        ObjetoSerializado = Json.JsonConvert.SerializeObject(peticionPx)


                        Dim urlParameterstoken As String = "?access_token=" + sJsonObj.access_token.ToString()

                        Dim httpClient As New HttpClient()

                        httpClient.BaseAddress = New Uri(EndPointTransaccionServicioPyxis)
                        Dim request As New HttpRequestMessage(HttpMethod.Put, "relativeAddress")


                        request.Content = New StringContent(ObjetoSerializado.ToString(),
                                            Encoding.UTF8,
                                            "application/json")

                        Dim respuestas As HttpResponseMessage
                        respuestas = httpClient.PutAsync(urlParameterstoken, request.Content).Result
                        Dim respuesta As Object = respuestas.Content.ReadAsStringAsync().Result
                        Dim marcaTiempoRespuesta As String = Date.Now

                        'Dim respPyxis As CodigoResultado = CType(respuesta, CodigoResultado)

                        Dim registraLog As Long = New DAOOrdenes().PyxisGuardarLog(objGenerales.Instancia.Prestador, objGenerales.Instancia.Sucursal,
                                                                                   DatosPaciente.Rows(0)("TipoAdmision").ToString(), DatosPaciente.Rows(0)("NumeroAdmision").ToString(),
                                                                                   DatosPaciente.Rows(0)("AnoAdmision").ToString(), marcaTiempoPeticion, marcaTiempoRespuesta, ObjetoSerializado,
                                                                                   respuesta, respuestas.StatusCode.GetHashCode)

                        Dim dtPrescripciongestor As DataTable = New DAOOrdenes().ConsultaPrescripcionSer_Pyxisgestor(objGenerales.Instancia.Prestador, objGenerales.Instancia.Sucursal, DatosPaciente.Rows(0)("TipoAdmision").ToString(),
                                                                                          DatosPaciente.Rows(0)("AnoAdmision").ToString(), DatosPaciente.Rows(0)("NumeroAdmision").ToString(), nroOrden, cencosto, dtMedicaModificados, dtMedicaNuevos)
                    End If
                End If

            Catch ex As Exception
                Dim marcaTiempoPeticion2 As String = Date.Now
                Dim marcaTiempoRespuesta2 As String = Date.Now
                Dim registraLog1 As Long = New DAOOrdenes().PyxisGuardarLog(objGenerales.Instancia.Prestador, objGenerales.Instancia.Sucursal,
                                                                                               DatosPaciente.Rows(0)("TipoAdmision").ToString(), DatosPaciente.Rows(0)("NumeroAdmision").ToString(),
                                                                                               DatosPaciente.Rows(0)("AnoAdmision").ToString(), marcaTiempoPeticion2, marcaTiempoRespuesta2, "",
                                                                                               "El validador NO estas disponible", "500")

                'MessageBox.Show(ex.Message)
                MsgBox("El validador NO esta disponible")
                CreateJsonObjectPyxis = 1
            End Try

        End Function

        Public Shared ReadOnly columnasGenerales As String() = {"cod_pre_sgs", "cod_sucur", "tip_admision", "num_adm", "ano_adm", "NroOrden", "Secuencia", "TextoOrden",
                                                                "Tratamiento", "medico", "Especialidad", "estado ", "fec_con ", "login", "obs", "Orden ", "entidad", "cada", "Tiempo"}


        Public Shared ReadOnly columnasDietas As String() = {"obs", "fec_con", "Tratamiento", "NroOrden", "Dieta", "estado", "login", "medico", "cod_pre_sgs", "cod_sucur",
                                                                             "tip_admision", "ano_adm", "num_adm", "Secuencia", "ResHidrica"}

                        Public Shared ReadOnly columnasAislamientos As String() = {"cod_pre_sgs", "cod_sucur", "tip_admision", "num_adm", "ano_adm", "NroOrden", "Secuencia", "Tratamiento", "medico",
                                                                                   "estado", "aisla_fecha_hora", "login", "aisla_aislamiento", "aisla_obs", "aisla_medico", "aisla_especialidad",
                                                                                   "TextoOrden", "tipo_aislamiento", "aisla_continuar", "aisla_suspender", "aisla_nuevo"}

                        Public Shared ReadOnly columnasProcedimientos As String() = {"descripcion_proce", "Cantidad", "obs", "cod_pre_sgs", "cod_sucur", "tip_admision", "num_adm",
                                                                                     "ano_adm", "NroOrden", "procedim", "medico", "fec_con", "login", "tieneConvenio", "codigo_ris",
                                                                                     "numconsulta", "mensaje", "grabaPedido", "secuencia", "uni_solicit", "uni_aplicada",
                                                                                     "uni_suministrada", "durante", "cen_cos_des", "cen_cos_origen", "entidad", "tip_proced",
                                                                                     "NroPedido", "OrigenProcedim", "JustificaSinConve", "tieneCcostoLabo", "CodSISPRO", "DesSISPRO",
                                                                                     "autoSISPRO", "EstadoInterconsulta", "procedimhomologo", "entidadpedido", "cod_Labor"}

                        Public Shared ReadOnly columnasMedicamentos As String() = {"fec_con", "diastrat", "codSISPRO", "desSISPRO", "cod_pre_sgs", "cod_sucur", "tip_admision", "ano_adm",
                                                                                   "num_adm", "NroOrden", "producto", "FormaFarma", "Presentacion", "Contenido", "Concentracion", "Dosis",
                                                                                   "UniMedDosis", "ViaAdministra", "Frecuencia", "TecnicaAdministra", "UnicaDosis", "Tratamiento",
                                                                                   "medico", "estado", "login", "obs", "Secuencia", "MedControl", "cantidadcontrol", "cantidadletrascontrol",
                                                                                   "autoSISPRO", "fecfintra", "cod_corto", "concentracionEq", "for_farma", "diasTratamiento", "DosisXDia",
                                                                                   "DosisXDiaNoPos", "fec_desde", "fec_hasta", "diagnost", "Justificacion", "clasificacion", "obsDiagn"}

        Public Function ConsultarEstadoDosisUnica(ByVal cod_pre_sgs As String, ByVal cod_sucur As String, ByVal tip_admision As String _
                                                  , ByVal num_adm As Int64, ByVal ano_adm As Integer, ByVal NroOrden As Int64, ByVal Secuencia As Int16) As String
            Return New DAOOrdenes().ConsultarEstadoDosisUnica(cod_pre_sgs, cod_sucur, tip_admision, num_adm, ano_adm, NroOrden, Secuencia)
        End Function


        Public Shared Function Consultausuariosseccion(ByVal cod_pre_sgs As String, ByVal cod_sucur As String, ByVal tip_admision As String _
                                              , ByVal num_adm As Int64, ByVal ano_adm As Integer, ByVal strmodulo As String,
                                              ByVal FechainicioSesion As DateTime) As String

            Return New DAOOrdenes().Consultausuariosseccion(cod_pre_sgs, cod_sucur, tip_admision, num_adm, ano_adm, strmodulo, FechainicioSesion)

        End Function

        Public Shared Function GrabarLogUsuario(ByVal cod_pre_sgs As String, ByVal cod_sucur As String, ByVal tip_admision As String _
                                            , ByVal num_adm As Int64, ByVal ano_adm As Integer, ByVal strmodulo As String,
                                            ByVal FechainicioSesion As DateTime, ByVal strlogin As String,
                                            ByVal strObservacion As String) As Int64

            Return New DAOOrdenes().GrabarLogUsuario(cod_pre_sgs, cod_sucur, tip_admision, num_adm, ano_adm, strmodulo,
                                                     FechainicioSesion, strlogin, strObservacion)
        End Function

    End Class

    Friend Class CodigoResultado
        Public Property codigo As String
        Public Property mensaje As String
    End Class

    Public Class Token

        Public Property access_token As String
        Public Property token_type As String
        Public Property refresh_token As String
        Public Property expires_in As String
        Public Property scope As String



    End Class
End Namespace

