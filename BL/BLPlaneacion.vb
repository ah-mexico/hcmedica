Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO




Namespace Sophia.HistoriaClinica.BL
    Public Class BLPlaneacion
        Public Shared AGrillaD As New ArrayList
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
        Public Const MODIFICA As String = "N"
        Public Const ACTIVO As String = "A"
        Public Const INACTIVO As String = "I"
        Public Const UNICADOSIS As String = "S"
        Public Const VARIASDOSIS As String = "N"
        Public Const EGRESADA As String = "E"
        Public Const TRASLADADA As String = "T"
        Public Const ANULADA As String = "A"
        Public Const PENDIENTE As String = "P"
        Public Const CAIDA As Integer = 1
        Public Const FUGA As Integer = 2
        Public Const ALERGICO As Integer = 3
        Public Const ANTICOAGULADO As Integer = 4
        Public Const MEDICA As Integer = 5
        Public Const QUIRURGICO As Integer = 6
#End Region

        Public Shared Function consultarOrdenesEnf(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String, ByVal strCod_sucur As String,
                                               ByVal strTip_Admision As String, ByVal strAno_Adm As Integer,
                                               ByVal strNum_Adm As Double) As DataSet

            Dim dsDatos As DataSet
            Dim daoOrden As New DAOOrdenes()


            dsDatos = daoOrden.consultarOrdenes(objConexion, strCod_pre_sgs, strCod_sucur, strTip_Admision,
                                  strAno_Adm, strNum_Adm)

            Try
                With dsDatos
                    .Tables(0).TableName = "DIETAS"
                    .Tables(1).TableName = "MEDICAMENTOS"
                    .Tables(2).TableName = "ORDENGENERAL"
                    .Tables(3).TableName = "PROCEDIMIENTOS"
                    .Tables(4).TableName = "CUIDADOS"
                    procesarCampoTratamiento(.Tables("DIETAS"), INICIA, Accion.Cargar)
                    procesarCampoTratamiento(.Tables("MEDICAMENTOS"), INICIA, Accion.Cargar)
                    procesarCampoTratamiento(.Tables("ORDENGENERAL"), INICIA, Accion.Cargar)
                    procesarCampoTratamiento(.Tables("PROCEDIMIENTOS"), INICIA, Accion.Cargar)
                    procesarCampoTratamiento(.Tables("CUIDADOS"), INICIA, Accion.Cargar)
                End With


            Catch ex As Exception
                MsgBox("Error consultarOrdenesEnf " & ex.Message, MsgBoxStyle.Information)
            End Try

            Return dsDatos

        End Function

        ''Enfermeria
        Public Shared Function validarCuidados(ByVal drow As DataRow, ByVal dtGenerales As DataTable, ByRef mensaje As String) As Boolean
            Dim resultado() As DataRow

            resultado = dtGenerales.Select("cod_cuidado = '" & drow("cod_cuidado") & "'")
            If resultado.Length > 0 Then
                mensaje = "El registro ya existe en la grilla."
                Return False
            End If

            'If drow("Orden") = 106 And drow("TextoOrden").Trim.Length <= 0 Then
            '    mensaje = "Debe digitar la descripción para la orden."
            '    Return False
            'ElseIf drow("TextoOrden").Trim.Length <= 0 Then
            '    mensaje = "Debe seleccionar una Orden."
            '    Return False
            'Else
            '    If drow("Orden") <> 106 Then
            '        resultado = dtGenerales.Select("orden = '" & drow("Orden") & "'")
            '        If resultado.Length > 0 Then
            '            mensaje = "El registro ya existe en la grilla."
            '            Return False
            '        End If
            '    End If

            'End If

            Return True
        End Function

        ''martovar no se puede suspender si el ultimo riesgo es alto
        Public Shared Function validarUltimoRiesgo(ByVal objConexion As Conexion, ByVal cod_historia As Double) As DataTable

            Dim daoPlanea As New DAOPlaneacion()
            Return daoPlanea.consultarUltimoRiesgocaida(objConexion, cod_historia)

        End Function



        ''Claudia Garay Enfermeria
        Public Shared Function ValidarHoraSel(ByVal HoraSel As Integer, ByVal Fechaplanea As String) As Boolean
            Dim DFecha As Date

            Dim DHora As Integer

            Dim objDao As New DAOGeneral


            DFecha = Format(objDao.traerFechaServidor(), objGeneral.Instancia.FormatoFechaLargo)
            ''DFecha = Format(Now, objGeneral.Instancia.FormatoFechaLargo)



            DHora = DatePart(DateInterval.Hour, DFecha)

            'If DHora < 9 Then


            If HoraSel = 0 Or HoraSel = 1 Or HoraSel = 2 Or HoraSel = 3 Or HoraSel = 4 Or HoraSel = 5 Or
            HoraSel = 6 Or HoraSel = 7 Or HoraSel = 8 Then
                HoraSel = (24 + HoraSel)
            End If


            If HoraSel < DHora Then
                If (DHora - HoraSel) <= 2 Then
                    Return True
                End If
                MsgBox("No puede Seleccionar una hora menor a la sistema", MsgBoxStyle.Information)
                Return False
            Else
                Return True
            End If

        End Function
        ''Claudia Garay Enfermeria
        Public Shared Function ValidarHoraSelMed(ByVal HoraSel As Integer) As Long
            Dim DFecha As Date
            Dim DHora As Integer

            Dim objDao As New DAOGeneral

            DFecha = Format(objDao.traerFechaServidor(), objGeneral.Instancia.FormatoFechaLargo)

            DHora = DatePart(DateInterval.Hour, DFecha)

            If HoraSel = 0 Or HoraSel = 1 Or HoraSel = 2 Or HoraSel = 3 Or HoraSel = 4 Or HoraSel = 5 Or
            HoraSel = 6 Or HoraSel = 7 Or HoraSel = 8 Then
                HoraSel = (24 + HoraSel)
            End If

            If HoraSel = DHora Then
                Return 0   ''Puede Cambiar
            End If

            If (DHora - HoraSel) <= 5 And (DHora - HoraSel) > 0 Then
                Return 1 ''Puede cambiar con justificacion

            Else
                MsgBox("No se puede modificar", MsgBoxStyle.Information)
                Return 2 ''No puede cambiar
            End If

        End Function
        ''Enfermeria
        Public Shared Function consultarCuidados(ByVal objConexion As Conexion) As DataTable
            Dim daoPlanea As New DAOPlaneacion()
            Return daoPlanea.consultarCuidadosEnf(objConexion)
        End Function
        ''Enfermeria

        ''martovar riesgo caida
        Public Shared Function consultarCuidadosRiesgoCaida(ByVal objConexion As Conexion) As DataTable
            Dim daoPlanea As New DAOPlaneacion()
            Return daoPlanea.consultarCuidadosEnfRiesgocaida(objConexion)
        End Function


        Public Shared Function consultarCuidadosPaciente(ByVal objConexion As Conexion, ByVal cod_historia As Double) As DataTable
            Dim daoPlanea As New DAOPlaneacion()
            Return daoPlanea.consultarCuidadosEnfXPac(objConexion, cod_historia)
        End Function
        Public Shared Function GuardarPlaneacionCuidados(ByVal objConexion As Conexion, ByVal dtPlaneacion As DataTable, ByVal Esnuevaplaneacion As Integer) As Long
            Dim xmlPlaneacionCuidados As String = ""
            Dim daoPlanea As New DAOPlaneacion()
            Dim lError As Long
            Dim dtCuidadosModificados As New DataTable
            Dim dtCuidadosNuevos As New DataTable
            Dim xmlPlaneacionCuidadosModificados As String = ""

            dtCuidadosModificados = dtPlaneacion.Clone()
            dtCuidadosNuevos = dtPlaneacion.Clone()

            ''Se buscan los medicamentos modificados 

            If Esnuevaplaneacion = 1 Then
                dtCuidadosModificados = filtrarTablaPlanea(dtPlaneacion, "consecutivo <> 0", dtCuidadosModificados)

                ''Se buscan  losk medicamentos/procedimientos/dietas/ordenes nuevos
                dtCuidadosNuevos = filtrarTablaPlanea(dtPlaneacion, "consecutivo=0", dtCuidadosNuevos)
            Else
                dtCuidadosModificados = filtrarTablaPlanea(dtPlaneacion, "consecutivo is not null", dtCuidadosModificados)

                ''Se buscan  los medicamentos/procedimientos/dietas/ordenes nuevos
                dtCuidadosNuevos = filtrarTablaPlanea(dtPlaneacion, "consecutivo is null", dtCuidadosNuevos)
            End If
            'If dtMedicaModificados.Rows.Count > 0 Then
            dtCuidadosModificados = configurarDataTableCuidadosParaGrabar(dtCuidadosModificados)
            xmlPlaneacionCuidadosModificados = FuncionesGenerales.GenerarXMLxProcedimiento(dtCuidadosModificados)
            'End If


            If dtCuidadosNuevos.Rows.Count > 0 Then
                dtCuidadosNuevos = AsignarConsecutivo(objConexion, dtCuidadosNuevos, "hcEnfPlaneaciondet")
            End If

            dtCuidadosNuevos = configurarDataTableCuidadosParaGrabar(dtCuidadosNuevos)
            xmlPlaneacionCuidados = FuncionesGenerales.GenerarXMLxProcedimiento(dtCuidadosNuevos)
            '' lError = daoPlanea.GuardarplaneacionMed(objConexion, xmlPlaneacionCuidados, xmlPlaneacionCuidadosModificados)

        End Function
        Public Shared Function GuardarPlaneacionGenerales(ByVal objConexion As Conexion, ByVal dtPlaneacion As DataTable, ByVal Esnuevaplaneacion As Integer) As Long
            Dim xmlPlaneacionGener As String = ""
            Dim daoPlanea As New DAOPlaneacion()
            Dim lError As Long
            Dim dtGenerModificados As New DataTable
            Dim dtGenerNuevos As New DataTable
            Dim xmlPlaneacionGenerModificados As String = ""

            dtGenerModificados = dtPlaneacion.Clone()
            dtGenerNuevos = dtPlaneacion.Clone()

            ''Se buscan los medicamentos modificados 

            If Esnuevaplaneacion = 1 Then
                dtGenerModificados = filtrarTablaPlanea(dtPlaneacion, "consecutivo <> 0", dtGenerModificados)

                ''Se buscan  los medicamentos/procedimientos/dietas/ordenes nuevos
                dtGenerNuevos = filtrarTablaPlanea(dtPlaneacion, "consecutivo=0", dtGenerNuevos)
            Else
                dtGenerModificados = filtrarTablaPlanea(dtPlaneacion, "consecutivo is not null", dtGenerModificados)

                ''Se buscan  los medicamentos/procedimientos/dietas/ordenes nuevos
                dtGenerNuevos = filtrarTablaPlanea(dtPlaneacion, "consecutivo is null", dtGenerNuevos)
            End If
            'If dtMedicaModificados.Rows.Count > 0 Then
            dtGenerModificados = configurarDataTableOrdenGenParaGrabar(dtGenerModificados)
            xmlPlaneacionGenerModificados = FuncionesGenerales.GenerarXMLxProcedimiento(dtGenerModificados)
            'End If


            If dtGenerNuevos.Rows.Count > 0 Then
                dtGenerNuevos = AsignarConsecutivo(objConexion, dtGenerNuevos, "hcEnfPlaneaciondet")
            End If

            dtGenerNuevos = configurarDataTableOrdenGenParaGrabar(dtGenerNuevos)
            xmlPlaneacionGener = FuncionesGenerales.GenerarXMLxProcedimiento(dtGenerNuevos)
            '' lError = daoPlanea.GuardarplaneacionMed(objConexion, xmlPlaneacionGener, xmlPlaneacionGenerModificados)

        End Function
        Public Shared Function GuardarPlaneacionDieta(ByVal objConexion As Conexion, ByVal dtPlaneacion As DataTable, ByVal Esnuevaplaneacion As Integer) As Long
            Dim xmlPlaneacionDieta As String = ""
            Dim daoPlanea As New DAOPlaneacion()
            Dim lError As Long
            Dim dtDietaModificados As New DataTable
            Dim dtDietaNuevos As New DataTable
            Dim xmlPlaneacionDietaModificados As String = ""

            dtDietaModificados = dtPlaneacion.Clone()
            dtDietaNuevos = dtPlaneacion.Clone()

            ''Se buscan los medicamentos modificados 

            If Esnuevaplaneacion = 1 Then
                dtDietaModificados = filtrarTablaPlanea(dtPlaneacion, "consecutivo <> 0", dtDietaModificados)

                ''Se buscan  los medicamentos/procedimientos/dietas/ordenes nuevos
                dtDietaNuevos = filtrarTablaPlanea(dtPlaneacion, "consecutivo=0", dtDietaNuevos)
            Else
                dtDietaModificados = filtrarTablaPlanea(dtPlaneacion, "consecutivo is not null", dtDietaModificados)

                ''Se buscan  los medicamentos/procedimientos/dietas/ordenes nuevos
                dtDietaNuevos = filtrarTablaPlanea(dtPlaneacion, "consecutivo is null", dtDietaNuevos)
            End If
            'If dtMedicaModificados.Rows.Count > 0 Then
            dtDietaModificados = configurarDataTableDietaParaGrabar(dtDietaModificados)
            xmlPlaneacionDietaModificados = FuncionesGenerales.GenerarXMLxProcedimiento(dtDietaModificados)
            'End If


            If dtDietaNuevos.Rows.Count > 0 Then
                dtDietaNuevos = AsignarConsecutivo(objConexion, dtDietaNuevos, "hcEnfPlaneaciondet")
            End If
            dtDietaNuevos = configurarDataTableDietaParaGrabar(dtDietaNuevos)
            xmlPlaneacionDieta = FuncionesGenerales.GenerarXMLxProcedimiento(dtDietaNuevos)

            ''   lError = daoPlanea.GuardarplaneacionMed(objConexion, xmlPlaneacionDieta, xmlPlaneacionDietaModificados)

        End Function

        ''Claudia Garay Enfermeria
        Public Shared Function GuardarPlaneacionMed(ByVal objConexion As Conexion, ByVal dtPlaneacion As DataTable, ByVal Esnuevaplaneacion As Integer, ByVal login As String) As Long
            Dim xmlPlaneacionMed As String = ""
            Dim consecutivoEncabeza As String
            Dim daoPlanea As New DAOPlaneacion()
            Dim DAOGeneral As New DAOGeneral
            Dim lError As Long
            Dim dtMedModificada As New DataTable
            Dim dtMedicaNuevos As New DataTable
            Dim dtMedicaDetNuevos As New DataTable
            Dim xmlPlaneacionMedModificados As String = ""
            Dim Datos() As Object

            dtMedModificada = dtPlaneacion.Clone()
            dtMedicaNuevos = dtPlaneacion.Clone()

            dtMedModificada = filtrarTablaPlanea(dtPlaneacion, "EstadoPlanea='S'", dtMedModificada)
            dtMedicaNuevos = AsignarConsecutivo(objConexion, dtMedModificada, "hcEnfPlaneaciondet")

            ''Claudia Garay Consecutivo
            'For i As Integer = 0 To dtMedicaNuevos.Rows.Count - 1
            '    consecutivoEncabeza = DAOGeneral.EjecutarSQLStrValor("HCENFPLANEACION", objConexion, " max(consecutivo)", " cod_historia=" & dtMedicaNuevos.Rows(0).Item("cod_historia") & " and tipo='" & _
            '    dtMedicaNuevos.Rows(0).Item("tipo") & "'and cod_programa='" & dtMedicaNuevos.Rows(0).Item("cod_programa") & "' and NroOrden='" & dtMedicaNuevos.Rows(0).Item("NroOrden") & "' and secuencia='" & dtMedicaNuevos.Rows(0).Item("secuencia") & "' AND ESTADOPLANEACION='A'")
            '    If consecutivoEncabeza = 0 Then
            '        consecutivoEncabeza = consecutivoEncabeza + 1
            '    End If
            'Next

            AgregarAlArregloD()
            dtMedicaDetNuevos = CrearTablaDetalle(dtMedModificada, objConexion)



            For i As Integer = 0 To dtMedicaDetNuevos.Rows.Count - 1

                ''Claudia Garay Bloqueos en Enfermeria
                consecutivoEncabeza = daoPlanea.TraerConsecutivosPlaneacion(dtMedicaDetNuevos.Rows(i).Item("cod_historia"), dtMedicaDetNuevos.Rows(i).Item("tipo"), dtMedicaDetNuevos.Rows(i).Item("cod_programa"), dtMedicaDetNuevos.Rows(i).Item("NroOrden"), IIf(IsDBNull(dtMedicaDetNuevos.Rows(i).Item("secuencia")), 0, dtMedicaDetNuevos.Rows(i).Item("secuencia")), "A")

                'consecutivoEncabeza = DAOGeneral.EjecutarSQLStrValor("HCENFPLANEACION", objConexion, " max(consecutivo)", " cod_historia=" & dtMedicaDetNuevos.Rows(i).Item("cod_historia") & " and tipo='" & _
                'dtMedicaDetNuevos.Rows(i).Item("tipo") & "'and cod_programa='" & dtMedicaDetNuevos.Rows(i).Item("cod_programa") & "' and NroOrden='" & dtMedicaDetNuevos.Rows(i).Item("NroOrden") & "' and secuencia='" & IIf(IsDBNull(dtMedicaDetNuevos.Rows(i).Item("secuencia")), 0, dtMedicaDetNuevos.Rows(i).Item("secuencia")) & "' AND ESTADOPLANEACION='A'")
                If consecutivoEncabeza = 0 Then
                    consecutivoEncabeza = consecutivoEncabeza + 1
                End If
                ReDim Datos(13)
                Datos(0) = dtMedicaDetNuevos.Rows(i).Item("cod_historia")
                Datos(1) = dtMedicaDetNuevos.Rows(i).Item("consecutivo")
                Datos(2) = consecutivoEncabeza
                Datos(3) = dtMedicaDetNuevos.Rows(i).Item("cod_programa")
                Datos(4) = dtMedicaDetNuevos.Rows(i).Item("hora")
                Datos(5) = dtMedicaDetNuevos.Rows(i).Item("estado")
                Datos(6) = "A"
                Datos(7) = dtMedicaDetNuevos.Rows(i).Item("NroOrden")
                Datos(8) = login
                Datos(9) = dtMedicaDetNuevos.Rows(i).Item("tipo")
                Datos(10) = ""
                Datos(11) = IIf(IsDBNull(dtMedicaDetNuevos.Rows(i).Item("secuencia")), 0, dtMedicaDetNuevos.Rows(i).Item("secuencia"))
                Datos(12) = 1
                Datos(13) = lError
                Try
                    lError = daoPlanea.GuardarplaneacionMed(objConexion, lError, Datos)


                    Try
                        If dtMedicaDetNuevos.Rows(i).Item("DosisUnica").ToString = "S" And
                                            (dtMedicaDetNuevos.Rows(i).Item("estado") = "A" Or dtMedicaDetNuevos.Rows(i).Item("estado") = "NA" Or
                                            dtMedicaDetNuevos.Rows(i).Item("estado") = "R" Or dtMedicaDetNuevos.Rows(i).Item("estado") = "S") Then


                            daoPlanea.CambiarEstadoOrdenUnicaDosis(objGeneral.Instancia.Prestador, objGeneral.Instancia.Sucursal, objPaciente.Instancia.TipoAdmision, objPaciente.Instancia.NumeroAdmision, objPaciente.Instancia.AnoAdmision, dtMedicaDetNuevos.Rows(i).Item("Nroorden"), dtMedicaDetNuevos.Rows(i).Item("cod_programa"), dtMedicaDetNuevos.Rows(i).Item("secuencia"))

                        End If

                    Catch a As Exception

                    End Try

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Information)
                End Try
            Next

        End Function


        Public Shared Function GuardarPlaneacionMed1(ByVal objConexion As Conexion, ByVal dtPlaneacion As DataTable, ByVal Esnuevaplaneacion As Integer, ByVal login As String) As Long
            Dim xmlPlaneacionMed As String = ""
            Dim consecutivoEncabeza As String
            Dim daoPlanea As New DAOPlaneacion()
            Dim DAOGeneral As New DAOGeneral
            Dim lError As Long
            Dim dtMedModificada As New DataTable
            Dim dtMedicaNuevos As New DataTable
            Dim dtMedicaDetNuevos As New DataTable
            Dim xmlPlaneacionMedModificados As String = ""
            Dim Datos() As Object

            dtMedModificada = dtPlaneacion.Clone()
            dtMedicaNuevos = dtPlaneacion.Clone()

            dtMedModificada = filtrarTablaPlanea(dtPlaneacion, "EstadoPlanea='S'", dtMedModificada)
            dtMedicaNuevos = AsignarConsecutivo(objConexion, dtMedModificada, "hcEnfPlaneaciondet")


            AgregarAlArregloD()
            dtMedicaDetNuevos = CrearTablaDetalle(dtMedModificada, objConexion)



            For i As Integer = 0 To dtMedicaDetNuevos.Rows.Count - 1

                consecutivoEncabeza = daoPlanea.TraerConsecutivosPlaneacion(dtMedicaDetNuevos.Rows(i).Item("cod_historia"), dtMedicaDetNuevos.Rows(i).Item("tipo"), dtMedicaDetNuevos.Rows(i).Item("cod_programa"), dtMedicaDetNuevos.Rows(i).Item("NroOrden"), IIf(IsDBNull(dtMedicaDetNuevos.Rows(i).Item("secuencia")), 0, dtMedicaDetNuevos.Rows(i).Item("secuencia")), "A")

                If consecutivoEncabeza = 0 Then
                    consecutivoEncabeza = consecutivoEncabeza + 1
                End If
                ReDim Datos(13)
                Datos(0) = dtMedicaDetNuevos.Rows(i).Item("cod_historia")
                Datos(1) = dtMedicaDetNuevos.Rows(i).Item("consecutivo")
                Datos(2) = consecutivoEncabeza
                Datos(3) = dtMedicaDetNuevos.Rows(i).Item("cod_programa")
                Datos(4) = dtMedicaDetNuevos.Rows(i).Item("hora")
                Datos(5) = dtMedicaDetNuevos.Rows(i).Item("estado")
                Datos(6) = "A"
                Datos(7) = dtMedicaDetNuevos.Rows(i).Item("NroOrden")
                Datos(8) = login
                Datos(9) = dtMedicaDetNuevos.Rows(i).Item("tipo")
                Datos(10) = ""
                Datos(11) = IIf(IsDBNull(dtMedicaDetNuevos.Rows(i).Item("secuencia")), 0, dtMedicaDetNuevos.Rows(i).Item("secuencia"))
                Datos(12) = 1
                Datos(13) = lError
                Try
                    lError = daoPlanea.GuardarplaneacionMed1(objConexion, lError, Datos)


                    Try
                        If dtMedicaDetNuevos.Rows(i).Item("DosisUnica").ToString = "S" And
                                            (dtMedicaDetNuevos.Rows(i).Item("estado") = "A" Or dtMedicaDetNuevos.Rows(i).Item("estado") = "NA" Or
                                            dtMedicaDetNuevos.Rows(i).Item("estado") = "R" Or dtMedicaDetNuevos.Rows(i).Item("estado") = "S") Then


                            daoPlanea.CambiarEstadoOrdenUnicaDosis(objGeneral.Instancia.Prestador, objGeneral.Instancia.Sucursal, objPaciente.Instancia.TipoAdmision, objPaciente.Instancia.NumeroAdmision, objPaciente.Instancia.AnoAdmision, dtMedicaDetNuevos.Rows(i).Item("Nroorden"), dtMedicaDetNuevos.Rows(i).Item("cod_programa"), dtMedicaDetNuevos.Rows(i).Item("secuencia"))

                        End If

                    Catch a As Exception

                    End Try

                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Information)
                End Try
            Next

        End Function
        Public Shared Function GuardarPlaneacionDiaSiguiente(ByVal objConexion As Conexion, ByVal cod_historia As Double, ByVal fechaAnt As String) As Long
            Dim daoPlanea As New DAOPlaneacion()
            Dim lError As Long

            Try
                lError = daoPlanea.GuardarPlaneacionDiaS(objConexion, cod_historia, fechaAnt)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information)
            End Try

            Return lError
        End Function
        'Public Shared Function GuardarPlaneacionDiaSiguiente(ByVal objConexion As Conexion, ByVal dtPlaneacionN As DataTable, ByVal dtPlaneacion As DataTable) As Long
        '    Dim xmlPlaneacionMed As String = ""
        '    Dim dtMedModificada As New DataTable
        '    Dim dtMedicaNuevos As New DataTable
        '    Dim dtMedicaDetNuevos As New DataTable
        '    Dim xmlPlaneacionMedModificados As String = ""

        '    Dim daoGeneral As New DAOGeneral

        '    '' Actualizamos Estado de la planeacion Anterior
        '    AgregarAlArregloD()
        '    Guardar(objConexion, dtPlaneacion, 3, "I")
        '    dtPlaneacion = AsignarConsecutivo(objConexion, dtPlaneacion, "hcEnfPlaneaciondet")

        '    ''Guardamos la planeacion para el dia
        '    'dtPlaneacionN = AsignarConsecutivo(objConexion, dtPlaneacionN, "hcEnfPlaneaciondet")
        '    'Guardar(objConexion, dtPlaneacionN, 1, "A")



        'End Function
        'Public Shared Sub Guardar(ByVal objConexion As Conexion, ByVal dtPlaneacion As DataTable, ByVal intAccion As Integer, ByVal estado As String)
        '    Dim Datos() As Object
        '    Dim lError As Long
        '    Dim daoPlanea As New DAOPlaneacion()
        '    Dim consecutivoEncabeza As String
        '    Dim DAOGeneral As New DAOGeneral

        '    ''Claudia Garay Consecutivo
        '    '' dtPlaneacion = CrearTablaDetalleNuevaPlaneacion(dtPlaneacion, objConexion)

        '    'If intAccion = 1 Then
        '    '    consecutivoEncabeza = DAOGeneral.EjecutarSQLStrValor("HCENFPLANEACION", objConexion, " max(consecutivo)", " cod_historia=" & dtPlaneacion.Rows(0).Item("cod_historia"))
        '    '    consecutivoEncabeza = consecutivoEncabeza + 1
        '    'Else
        '    'consecutivoEncabeza = dtPlaneacion.Rows(0).Item("consecutivo")
        '    'End If

        '    For i As Integer = 0 To dtPlaneacion.Rows.Count - 1
        '        ReDim Datos(12)

        '        Datos(0) = dtPlaneacion.Rows(i).Item("cod_historia")
        '        Datos(1) = dtPlaneacion.Rows(i).Item("consecutivo")
        '        Datos(2) = dtPlaneacion.Rows(i).Item("consecutivo")
        '        Datos(3) = dtPlaneacion.Rows(i).Item("cod_programa")
        '        Datos(4) = 0
        '        Datos(5) = dtPlaneacion.Rows(i).Item("estado")
        '        Datos(6) = estado
        '        Datos(7) = dtPlaneacion.Rows(i).Item("NroOrden")
        '        Datos(8) = objGeneral.Instancia.Login
        '        Datos(9) = dtPlaneacion.Rows(i).Item("tipo")
        '        Datos(10) = ""
        '        Datos(11) = intAccion
        '        Datos(12) = lError
        '        Try
        '            lError = daoPlanea.GuardarplaneacionMedDiaS(objConexion, lError, Datos)
        '        Catch ex As Exception
        '            MsgBox(ex.Message, MsgBoxStyle.Information)
        '        End Try
        '    Next
        'End Sub
        Public Shared Function GuardarCuidados(ByVal objConexion As Conexion, ByVal dtCuidados As DataTable, ByVal Esnuevaplaneacion As Integer) As Long

            Dim daoPlanea As New DAOPlaneacion()
            Dim lError As Long
            Dim dtCuidadoModificados As New DataTable
            Dim dtCuidadoNuevos As New DataTable
            Dim xmlCuidadoModificados As String = ""
            Dim xmlCuidados As String = ""

            dtCuidadoModificados = dtCuidados.Clone()
            dtCuidadoNuevos = dtCuidados.Clone()

            ''Se buscan los medicamentos modificados 

            If Esnuevaplaneacion = 1 Then
                dtCuidadoModificados = filtrarTablaPlanea(dtCuidados, "consecutivo <> 0", dtCuidadoModificados)

                ''Se buscan  los medicamentos/procedimientos/dietas/ordenes nuevos
                dtCuidadoNuevos = filtrarTablaPlanea(dtCuidados, "consecutivo=0", dtCuidadoNuevos)
            Else
                dtCuidadoModificados = filtrarTablaPlanea(dtCuidados, "estado='S'", dtCuidadoModificados)

                ''Se buscan  los medicamentos/procedimientos/dietas/ordenes nuevos
                dtCuidadoNuevos = filtrarTablaPlanea(dtCuidados, "consecutivo is null ", dtCuidadoNuevos)
            End If
            'If dtMedicaModificados.Rows.Count > 0 Then
            dtCuidadoModificados = configurarDataTableCuidadoXraGrabar(dtCuidadoModificados)
            '' dtMedicaModificados = AsignarConsecutivo(objConexion, dtMedicaModificados)
            xmlCuidadoModificados = FuncionesGenerales.GenerarXMLxProcedimiento(dtCuidadoModificados)
            'End If


            If dtCuidadoNuevos.Rows.Count > 0 Then
                dtCuidadoNuevos = AsignarConsecutivoCuidado(objConexion, dtCuidadoNuevos)
            End If
            dtCuidadoNuevos = configurarDataTableCuidadoXraGrabar(dtCuidadoNuevos)
            xmlCuidados = FuncionesGenerales.GenerarXMLxProcedimiento(dtCuidadoNuevos)
            Try


                lError = daoPlanea.GuardarCuidados(objConexion, xmlCuidados, xmlCuidadoModificados)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information)
                lError = 1
            End Try

            Return lError

        End Function
        Public Shared Function AsignarConsecutivo(ByVal objconexion As Conexion, ByVal dttable As DataTable, ByVal strTabla As String) As DataTable
            Dim daoGeneral As New DAOGeneral
            Dim daoplanea As New DAOPlaneacion
            Dim consecutivo As Integer
            Dim i As Integer



            ''Claudia Garay Bloqueos Enfermeria
            consecutivo = daoplanea.TraerConsecutivosPlaneacionDet(dttable.Rows(0).Item("cod_historia"))

            ''consecutivo = daoGeneral.EjecutarSQLStrValor(strTabla, objconexion, " max(consecutivo)", " cod_historia=" & dttable.Rows(0).Item("cod_historia"))
            'If dttable.Rows(0).Item("consecutivo") <> 0 Then
            consecutivo = consecutivo + 1
            'End If

            For i = 0 To dttable.Rows.Count - 1
                dttable.Rows(i).Item("consecutivo") = consecutivo

            Next

            Return dttable
        End Function

        Public Shared Function AsignarConsecutivoCuidado(ByVal objconexion As Conexion, ByVal dttable As DataTable) As DataTable
            Dim daoGeneral As New DAOGeneral
            Dim consecutivo As Integer
            Dim i As Integer



            consecutivo = daoGeneral.EjecutarSQLStrValor("HcEnfcuidadosXPac", objconexion, " max(consecutivo)", " cod_historia=" & dttable.Rows(0).Item("cod_historia"))
            'If dttable.Rows(0).Item("consecutivo") <> 0 Then
            consecutivo = consecutivo + 1
            'End If

            For i = 0 To dttable.Rows.Count - 1
                dttable.Rows(i).Item("consecutivo") = consecutivo
                consecutivo = consecutivo + 1
            Next

            Return dttable
        End Function
        Public Shared Function AsignarConsecutivoAlarma(ByVal objconexion As Conexion, ByVal dttable As DataTable, ByVal cod_historia As String, ByVal login As String) As DataTable
            Dim daoGeneral As New DAOGeneral
            Dim consecutivo As Integer
            Dim i As Integer



            consecutivo = daoGeneral.EjecutarSQLStrValor("hcEnfAlarma", objconexion, " max(consecutivo)", " cod_historia=" & cod_historia)
            'If dttable.Rows(0).Item("consecutivo") <> 0 Then
            consecutivo = consecutivo + 1
            'End If

            For i = 0 To dttable.Rows.Count - 1
                dttable.Rows(i).Item("consecutivo") = consecutivo
                dttable.Rows(i).Item("cod_historia") = cod_historia
                dttable.Rows(i).Item("login") = login
            Next

            Return dttable
        End Function
        Public Shared Function GuardarPlaneacionProc(ByVal objConexion As Conexion, ByVal dtPlaneacion As DataTable, ByVal Esnuevaplaneacion As Integer) As Long
            Dim xmlPlaneacionProc As String = ""
            Dim daoPlanea As New DAOPlaneacion()
            Dim lError As Long
            Dim dtProcModificados As New DataTable
            Dim dtProcNuevos As New DataTable
            Dim xmlPlaneacionProcModificados As String = ""

            dtProcModificados = dtPlaneacion.Clone()
            dtProcNuevos = dtPlaneacion.Clone()

            ''Se buscan los medicamentos modificados 

            If Esnuevaplaneacion = 1 Then
                dtProcModificados = filtrarTablaPlanea(dtPlaneacion, "consecutivo <> 0", dtProcModificados)

                ''Se buscan  los medicamentos/procedimientos/dietas/ordenes nuevos
                dtProcNuevos = filtrarTablaPlanea(dtPlaneacion, "consecutivo=0", dtProcNuevos)
            Else
                dtProcModificados = filtrarTablaPlanea(dtPlaneacion, "consecutivo is not null", dtProcModificados)

                ''Se buscan  los medicamentos/procedimientos/dietas/ordenes nuevos
                dtProcNuevos = filtrarTablaPlanea(dtPlaneacion, "consecutivo is null", dtProcNuevos)
            End If
            'If dtMedicaModificados.Rows.Count > 0 Then
            dtProcModificados = configurarDataTableProcParaGrabar(dtProcModificados)
            xmlPlaneacionProcModificados = FuncionesGenerales.GenerarXMLxProcedimiento(dtProcModificados)
            'End If


            If dtProcNuevos.Rows.Count > 0 Then
                dtProcNuevos = AsignarConsecutivo(objConexion, dtProcNuevos, "hcEnfPlaneaciondet")
            End If

            dtProcNuevos = configurarDataTableProcParaGrabar(dtProcNuevos)
            xmlPlaneacionProc = FuncionesGenerales.GenerarXMLxProcedimiento(dtProcNuevos)

            ''lError = daoPlanea.GuardarplaneacionMed(objConexion, xmlPlaneacionProc, xmlPlaneacionProcModificados)

        End Function
        ''Enfermeria
#Region "ConfigurarTablasGrabar"
        Public Shared Function configurarDataTableDietaParaGrabar(ByVal dtProcedim As DataTable) As DataTable
            Dim dtFiltrado As New DataTable
            Dim i As Integer

            With dtProcedim.Columns
                .Remove("DescriDieta")
                .Remove("NombreMedico")
                .Remove("especialidad")
                .Remove("Tratamiento")
                ''.Remove("NroOrden")
                .Remove("estado")
                .Remove("medico")
                ''.Remove("FechaPlanea")
                .Remove("Secuencia")
            End With

            ''Actualizar login con el usuario de la sesion 14 sept 2010

            For i = 0 To dtProcedim.Rows.Count - 1
                dtProcedim.Rows(i).Item("login") = objGeneral.Instancia.Login
            Next

            Return dtProcedim

        End Function
        ''Enfermeria
        Public Shared Function configurarDataTableCuidadosParaGrabar(ByVal dtOrdenGeneral As DataTable) As DataTable
            Dim dtFiltrado As DataTable
            Dim i As Integer

            dtFiltrado = dtOrdenGeneral.Copy()
            With dtFiltrado.Columns
                .Remove("descripcion")
                .Remove("estado")
                .Remove("tratamiento")
                .Remove("fec_con")
                .Remove("NroOrden")
            End With

            For i = 0 To dtFiltrado.Rows.Count - 1
                dtFiltrado.Rows(i).Item("login") = objGeneral.Instancia.Login
            Next

            Return dtFiltrado

        End Function
        ''Enfermeria
        Public Shared Function configurarDataTableOrdenGenParaGrabar(ByVal dtOrdenGeneral As DataTable) As DataTable
            Dim dtFiltrado As DataTable
            Dim i As Integer

            dtFiltrado = dtOrdenGeneral.Copy()
            With dtFiltrado.Columns
                .Remove("nombreMedico")
                .Remove("especialidad")
                ''.Remove("FechaPlanea")
            End With

            For i = 0 To dtFiltrado.Rows.Count - 1
                dtFiltrado.Rows(i).Item("login") = objGeneral.Instancia.Login
            Next

            Return dtFiltrado

        End Function
        ''Enfermeria
        Public Shared Function configurarDataTableCuidadoXraGrabar(ByVal dtMed As DataTable) As DataTable

            Dim i As Integer
            With dtMed.Columns
                .Remove("fec_con")
                .Remove("descripcion")
            End With

            ''Actualizar login con el usuario de la sesion 14 sept 2010

            For i = 0 To dtMed.Rows.Count - 1
                dtMed.Rows(i).Item("login") = objGeneral.Instancia.Login
            Next

            Return dtMed

        End Function
        ''Enfermeria
        Public Shared Function configurarDataTableMedParaGrabar(ByVal dtMed As DataTable) As DataTable
            Dim dtFiltrado As New DataTable
            Dim i As Integer
            With dtMed.Columns
                .Remove("descripcion")
                .Remove("prescripcion")
                .Remove("FormaFarma")
                .Remove("Presentacion")
                .Remove("Contenido")
                .Remove("Concentracion")
                .Remove("Dosis")
                .Remove("UniMedDosis")
                .Remove("ViaAdministra")
                .Remove("Frecuencia")
                .Remove("CadaNrohoras")
                .Remove("TecnicaAdministra")
                .Remove("UnicaDosis")
                .Remove("Tratamiento")
                .Remove("Secuencia")
                .Remove("programacion")
                .Remove("hor_ini")
                .Remove("hor_fin")
                .Remove("HoraOrden")
                .Remove("MinOrden")
                .Remove("FechaOrden")
                .Remove("NombreMedico")
                .Remove("estado")
                ''.Remove("FechaPlanea")
            End With

            ''Actualizar login con el usuario de la sesion 14 sept 2010

            For i = 0 To dtMed.Rows.Count - 1
                dtMed.Rows(i).Item("login") = objGeneral.Instancia.Login
            Next

            Return dtMed

        End Function
        ''Enfermeria
        Public Shared Function configurarDataTableProcParaGrabar(ByVal dtProcedim As DataTable) As DataTable
            Dim dtFiltrado As New DataTable
            Dim i As Integer

            With dtProcedim.Columns
                .Remove("descripcion")
                .Remove("Cantidad")
                .Remove("medico")
                .Remove("NroPedido")
                .Remove("Tratamiento")
                ''.Remove("FechaPlanea")
            End With

            For i = 0 To dtProcedim.Rows.Count - 1
                dtProcedim.Rows(i).Item("login") = objGeneral.Instancia.Login
            Next
            Return dtProcedim

        End Function
        Public Shared Function configurarDataTableAlergia(ByVal dtAlergia As DataTable) As DataTable

            With dtAlergia.Columns
                .Remove("origen")
                .Remove("fec_con")
                .Remove("hor_ingreso")
                .Remove("min_ingreso")
                .Remove("descripcion")
                .Remove("descrclase")
            End With

            Return dtAlergia

        End Function
#End Region
        Public Shared Function filtrarTabla(ByVal dtBase As DataTable, ByVal filtro As DataViewRowState, ByVal dtContenedor As DataTable) As DataTable

            Dim rowsFiltradas() As DataRow

            rowsFiltradas = dtBase.Select("", "", filtro)
            dtContenedor = FuncionesGenerales.copyArrayToDataTable(dtContenedor, rowsFiltradas)
            Return dtContenedor

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

        ''Enfermeria
        Public Shared Sub actualizarEstadoEnf(ByRef drDatos As DataRow, ByVal tratamiento As String, ByVal valorCheck As Object)

            drDatos.BeginEdit()
            ''If IsDBNull(valorCheck) Then

            If tratamiento = BLOrdenes.SUSPENDE Then
                drDatos.Item("estado") = BLOrdenes.SUSPENDE
                valorCheck = BLOrdenes.SUSPENDE
            Else
                drDatos.Item("estado") = BLOrdenes.INICIA
                valorCheck = BLOrdenes.INICIA
            End If
            'drDatos.Item("fec_con") = FuncionesGenerales.FechaServidor()
            'Else
            'If valorCheck = BLOrdenes.CONTINUA Then
            '    '' drDatos.Item("Tratamiento") = BLOrdenes.SUSPENDE
            '    drDatos.Item("estado") = BLOrdenes.INACTIVO
            '    'drDatos.Item("fec_con") = FuncionesGenerales.FechaServidor()
            'Else
            '    ''drDatos.Item("Tratamiento") = BLOrdenes.CONTINUA
            '    drDatos.Item("estado") = BLOrdenes.ACTIVO
            '    'drDatos.Item("fec_con") = FuncionesGenerales.FechaServidor()
            'End If
            'End If
            drDatos.EndEdit()
        End Sub

        Public Shared Function filtrarTablaPlanea(ByVal dtBase As DataTable, ByVal filtro As String, ByVal dtContenedor As DataTable) As DataTable

            Dim rowsFiltradas() As DataRow

            rowsFiltradas = dtBase.Select(filtro)
            dtContenedor = FuncionesGenerales.copyArrayToDataTable(dtContenedor, rowsFiltradas)
            Return dtContenedor

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
            End With

            Return dtFiltrado

        End Function

        Public Shared Function configurarDataTableProcedimParaGrabar(ByVal dtProcedim As DataTable) As DataTable
            Dim dtFiltrado As DataTable

            dtFiltrado = dtProcedim.Copy()
            With dtFiltrado.Columns
                .Remove("descripcion_proce")
                .Remove("descri_cen_cos_des")
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
        Public Shared Function ConsultarAlarmas(ByVal objConexion As Conexion) As DataTable
            Dim daoGeneral As New DAOGeneral
            Dim dtdatos As DataTable

            ''dtdatos = daoGeneral.EjecutarSQLConParametros("hcEnfgenAlarma", objConexion, "'' as cod_historia,'' as consecutivo,'' as login,cod_riesgo,descripcion,'' as estado", "")
            dtdatos = daoGeneral.EjecutarSQLConParametros("hcEnfgenAlarma", objConexion, "'' as cod_historia,'' as consecutivo,'' as login,cod_riesgo,descripcion,'' as estado", "")

            Return dtdatos
        End Function
        Public Shared Function ConsultarAlarmasXPac(ByVal objConexion As Conexion, ByVal Prestador As String, ByVal Sucursal As String, ByVal Tip_Adm As String,
                                                    ByVal Ano_Adm As String, ByVal Num_adm As String, ByVal tip_doc As String, ByVal num_doc As String) As DataSet
            Dim daoplanea As New DAOPlaneacion
            Dim dsdatos As DataSet

            dsdatos = daoplanea.ConsultarAlarmasXPac(objConexion, Prestador, Sucursal, Tip_Adm, Ano_Adm, Num_adm, tip_doc, num_doc)
            Return dsdatos
        End Function

        Public Shared Function ConsultarHistoricoAlarmasPac(ByVal objConexion As Conexion, ByVal cod_historia As String) As DataSet
            Dim daoplanea As New DAOPlaneacion
            Dim dsdatos As DataSet

            dsdatos = daoplanea.ConsultarHistoricoAlarmasXPac(objConexion, cod_historia)
            Return dsdatos
        End Function
        Public Shared Function GuardarAlarmas(ByVal objConexion As Conexion, ByVal tip_doc As String, ByVal num_doc As String, ByVal cod_historia As String, ByVal login As String, ByVal dtAlarma As DataTable) As Long
            Dim lError As Long
            Dim daoPlanea As New DAOPlaneacion()
            Dim xmlAlarmas As String

            AsignarConsecutivoAlarma(objConexion, dtAlarma, cod_historia, login)
            xmlAlarmas = FuncionesGenerales.GenerarXMLxProcedimiento(dtAlarma)
            lError = daoPlanea.AlmacenarAlarmas(objConexion, tip_doc, num_doc, xmlAlarmas)
            Return lError
        End Function
        ''Consulta de Alarma alergico Claudia Garay 30 sept 2010
        Public Shared Function ConsultarAlergicoPac(ByVal objConexion As Conexion, ByVal tip_doc As String, ByVal num_doc As String) As DataSet
            Dim daoplanea As New DAOPlaneacion
            Dim dsdatos As DataSet

            dsdatos = daoplanea.ConsultarAlergiasXPac(objConexion, tip_doc, num_doc)
            Return dsdatos
        End Function

        Public Shared Sub actualizarEstado(ByRef drDatos As DataRow, ByVal tratamiento As String, ByVal valorCheck As Object)

            drDatos.BeginEdit()
            'If tratamiento = BLOrdenes.MODIFICA Then
            '    drDatos.Item("estado_alarma") = BLPlaneacion.INACTIVO
            '    Exit Sub
            'End If

            If drDatos.Item("estado_alarma") = "" Then
                drDatos.Item("estado_alarma") = BLPlaneacion.MODIFICA
                Exit Sub
            End If
            If drDatos.Item("estado_alarma") = BLPlaneacion.MODIFICA Then
                drDatos.Item("estado_alarma") = ""
                Exit Sub
            End If

            drDatos.EndEdit()
        End Sub
        ''Claudia Garay 04 de octubre 2010 
        Public Shared Function ActualizaEstadoAlergias(ByVal objConexion As Conexion, ByVal Prestador As String, ByVal Sucursal As String, ByVal Tip_Adm As String,
                                                       ByVal Ano_Adm As String, ByVal Num_adm As String, ByVal tip_doc As String, ByVal num_doc As String,
                                                       ByVal min_ingreso As Integer, ByVal hor_ingreso As Integer, ByVal clase As String, ByVal accionA As Integer, ByVal nom_tabla As String) As Long
            Dim daoPlanea As New DAOPlaneacion()
            Dim lError As Long

            lError = daoPlanea.ActualizaEstadoAlergia(objConexion, Prestador, Sucursal, Tip_Adm, Ano_Adm, Num_adm, tip_doc, num_doc, min_ingreso, hor_ingreso, clase, accionA, nom_tabla)

            Return lError
        End Function
        ''Claudia Garay 04 de octubre 2010
        Public Shared Function AlmacenaAlergiasNuevas(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String, ByVal cod_sucur As String,
        ByVal tip_doc As String, ByVal Num_doc As String, ByVal tip_admision As String, ByVal ano_adm As Integer, ByVal num_adm As Integer,
        ByVal alergico As String, ByVal clase As String, ByVal login As String, ByVal obs As String, ByVal confidencial As String,
        ByVal tiempomes As Integer, ByVal tiempoano As Integer, ByVal estado_alarma As String) As Long

            Dim daoPlanea As New DAOPlaneacion()
            Dim lError As Long


            lError = daoPlanea.GuardarAlergiasNuevas(objConexion, cod_pre_sgs, cod_sucur, tip_doc, Num_doc,
            tip_admision, ano_adm, num_adm, alergico, clase, login, obs, confidencial, tiempomes, tiempoano, estado_alarma)

        End Function

        Public Shared Function ActualizaReprogramados(ByVal objConexion As Conexion, ByVal cod_historia As Double, ByVal consecutivo As Integer,
       ByVal cod_programa As String, ByVal hora As Integer, ByVal estado As String, ByVal NroOrden As Double, ByVal secuencia As Integer,
       ByVal obs As String, ByVal login As String) As Long

            Dim daoPlanea As New DAOPlaneacion()
            Dim lError As Long


            lError = daoPlanea.GuardarReprogramados(objConexion, cod_historia, consecutivo, cod_programa, hora,
            estado, NroOrden, secuencia, obs, login)

        End Function
        Public Shared Function CrearTablaDetalle(ByVal dtgrilla As DataTable, ByVal objConexion As Conexion) As DataTable
            Dim dtDetalle As New DataTable
            Dim objDAOGeneral As New DAOGeneral
            Dim dtrow As DataRow
            Dim contador As Integer = 0

            With dtDetalle
                .Columns.Add("cod_historia", System.Type.GetType("System.String"))
                .Columns.Add("consecutivo", System.Type.GetType("System.String"))
                .Columns.Add("cod_programa", System.Type.GetType("System.String"))
                .Columns.Add("hora", System.Type.GetType("System.String"))
                .Columns.Add("estado", System.Type.GetType("System.String"))
                .Columns.Add("NroOrden", System.Type.GetType("System.String"))
                .Columns.Add("login", System.Type.GetType("System.String"))
                .Columns.Add("tipo", System.Type.GetType("System.String"))
                .Columns.Add("secuencia", System.Type.GetType("System.String"))
                .Columns.Add("DosisUnica", System.Type.GetType("System.String")) ''cpgaray
            End With

            ' dtDetalle = objDAOGeneral.EjecutarSQLConParametros("hcEnfPlaneacionDet", objConexion, "cod_historia,consecutivo,cod_programa,hora,estado,NroOrden,login,tipo,secuencia", "hora=90")
            dtrow = dtDetalle.NewRow
            dtDetalle.Rows.Add(dtrow)

            For ii As Integer = 0 To dtgrilla.Rows.Count - 1
                For i As Integer = 0 To AGrillaD.Count - 1
                    If Not IsDBNull(dtgrilla.Rows(ii).Item(AGrillaD(i))) Then
                        If dtgrilla.Rows(ii).Item(AGrillaD(i)) <> "" And dtgrilla.Rows(ii).Item("EstadoPlanea") = "S" Then
                            dtDetalle.Rows(contador).Item("cod_historia") = dtgrilla.Rows(ii).Item("cod_historia")
                            dtDetalle.Rows(contador).Item("consecutivo") = dtgrilla.Rows(ii).Item("consecutivo")
                            dtDetalle.Rows(contador).Item("cod_programa") = dtgrilla.Rows(ii).Item("cod_programa")
                            dtDetalle.Rows(contador).Item("hora") = AGrillaD(i)
                            dtDetalle.Rows(contador).Item("estado") = dtgrilla.Rows(ii).Item(AGrillaD(i))
                            dtDetalle.Rows(contador).Item("NroOrden") = dtgrilla.Rows(ii).Item("NroOrden")
                            dtDetalle.Rows(contador).Item("login") = dtgrilla.Rows(ii).Item("login")
                            dtDetalle.Rows(contador).Item("tipo") = dtgrilla.Rows(ii).Item("tipo")
                            dtDetalle.Rows(contador).Item("secuencia") = dtgrilla.Rows(ii).Item("secuencia")

                            If dtgrilla.Columns.Contains("UnicaDosis") Then
                                dtDetalle.Rows(contador).Item("DosisUnica") = dtgrilla.Rows(ii).Item("UnicaDosis")
                            End If

                            dtDetalle.Rows.Add(dtDetalle.NewRow)
                            contador = contador + 1
                        End If
                    End If
                Next
            Next

            dtDetalle.Rows.RemoveAt(dtDetalle.Rows.Count - 1)
            Return dtDetalle
        End Function
        Public Shared Function CrearTablaDetalleNuevaPlaneacion(ByVal dtgrilla As DataTable, ByVal objConexion As Conexion) As DataTable
            Dim dtDetalle As DataTable
            Dim objDAOGeneral As New DAOGeneral
            Dim dtrow As DataRow
            Dim contador As Integer = 0
            dtDetalle = objDAOGeneral.EjecutarSQLConParametros("hcEnfPlaneacionDet", objConexion, "cod_historia,consecutivo,cod_programa,hora,estado,NroOrden,login,tipo", "hora=90")
            dtrow = dtDetalle.NewRow
            dtDetalle.Rows.Add(dtrow)
            '' No se usa
            For ii As Integer = 0 To dtgrilla.Rows.Count - 1
                For i As Integer = 0 To AGrillaD.Count - 1
                    If Not IsDBNull(dtgrilla.Rows(ii).Item(AGrillaD(i))) Then
                        dtDetalle.Rows(contador).Item("cod_historia") = dtgrilla.Rows(ii).Item("cod_historia")
                        dtDetalle.Rows(contador).Item("consecutivo") = dtgrilla.Rows(ii).Item("consecutivo")
                        dtDetalle.Rows(contador).Item("cod_programa") = dtgrilla.Rows(ii).Item("cod_programa")
                        dtDetalle.Rows(contador).Item("hora") = AGrillaD(i)
                        dtDetalle.Rows(contador).Item("estado") = dtgrilla.Rows(ii).Item(AGrillaD(i))
                        dtDetalle.Rows(contador).Item("NroOrden") = dtgrilla.Rows(ii).Item("NroOrden")
                        dtDetalle.Rows(contador).Item("login") = dtgrilla.Rows(ii).Item("login")
                        dtDetalle.Rows(contador).Item("tipo") = dtgrilla.Rows(ii).Item("tipo")
                        dtDetalle.Rows.Add(dtDetalle.NewRow)
                        contador = contador + 1
                    End If
                Next
            Next

            dtDetalle.Rows.RemoveAt(dtDetalle.Rows.Count - 1)
            Return dtDetalle
        End Function

        Public Shared Sub AgregarAlArregloD()
            AGrillaD.Clear()
            AGrillaD.Add("9")
            AGrillaD.Add("10")
            AGrillaD.Add("11")
            AGrillaD.Add("12")
            AGrillaD.Add("13")
            AGrillaD.Add("14")
            AGrillaD.Add("15")
            AGrillaD.Add("16")
            AGrillaD.Add("17")
            AGrillaD.Add("18")
            AGrillaD.Add("19")
            AGrillaD.Add("20")
            AGrillaD.Add("21")
            AGrillaD.Add("22")
            AGrillaD.Add("23")
            AGrillaD.Add("24")
            AGrillaD.Add("25")
            AGrillaD.Add("26")
            AGrillaD.Add("27")
            AGrillaD.Add("28")
            AGrillaD.Add("29")
            AGrillaD.Add("30")
            AGrillaD.Add("31")
            AGrillaD.Add("32")
        End Sub

        Public Shared Function Consultarlogin(ByVal objConexion As Conexion, ByVal strlogin As String) As DataTable
            Dim daoPlanea As New DAOPlaneacion
            Return daoPlanea.consultarLogin(objConexion, strlogin)
        End Function

        '' Monitoreos Claudia Garay 27 Octubre de 2010

        Public Shared Function ConsultarLiquidosAdministrados(ByVal objConexion As Conexion) As DataTable
            Dim daoPlanea As New DAOPlaneacion
            Return daoPlanea.consultarLiquidosAdministrados(objConexion)
        End Function

        '' Monitoreos Claudia Garay 27 Octubre de 2010

        Public Shared Function ConsultarLiquidosEliminados(ByVal objConexion As Conexion) As DataTable
            Dim daoPlanea As New DAOPlaneacion
            Return daoPlanea.consultarLiquidosEliminados(objConexion)
        End Function
        Public Shared Function ConsultarLiquidos5Eliminados(ByVal objConexion As Conexion) As DataTable
            Dim daoPlanea As New DAOPlaneacion
            Return daoPlanea.consultarLiquidos5Eliminados(objConexion)
        End Function

        'rmzaldua 2018-05-23 traer datos admision
        Public Shared Function Traerfechahoraadmision(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String, ByVal strCod_sucur As String,
                                             ByVal strTip_Admision As String, ByVal strAno_Adm As Integer,
                                             ByVal strNum_Adm As Double) As DataTable

            Dim dtDatos As DataTable
            Dim daoPlanea As New DAOPlaneacion
            dtDatos = daoPlanea.Traerfechahoraadmision(objConexion, strCod_pre_sgs, strCod_sucur, strTip_Admision,
                                              strAno_Adm, strNum_Adm)

            Return dtDatos
        End Function

        Public Shared Function TraerLiquidosGrilla(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String, ByVal strCod_sucur As String,
                                             ByVal strTip_Admision As String, ByVal strAno_Adm As Integer,
                                             ByVal strNum_Adm As Double) As DataTable

            Dim dtDatos As DataTable
            Dim daoPlanea As New DAOPlaneacion
            dtDatos = daoPlanea.TraerLiquidosGrilla(objConexion, strCod_pre_sgs, strCod_sucur, strTip_Admision,
                                              strAno_Adm, strNum_Adm)

            Return dtDatos
        End Function
        Public Shared Function TraerLiquidosGrilla1(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String, ByVal strCod_sucur As String,
                                             ByVal strTip_Admision As String, ByVal strAno_Adm As Integer,
                                             ByVal strNum_Adm As Double) As DataTable

            Dim dtDatos As DataTable
            Dim daoPlanea As New DAOPlaneacion
            dtDatos = daoPlanea.TraerLiquidosGrilla1(objConexion, strCod_pre_sgs, strCod_sucur, strTip_Admision,
                                              strAno_Adm, strNum_Adm)

            Return dtDatos
        End Function
        Public Shared Function TraerLiquidosGrillaElim(ByVal objConexion As Conexion, ByVal cod_historia As String, ByVal strCod_pre_sgs As String, ByVal strCod_sucur As String,
                                            ByVal strTip_Admision As String, ByVal strAno_Adm As Integer,
                                            ByVal strNum_Adm As Double) As DataTable

            Dim dtDatos As DataTable
            Dim daoPlanea As New DAOPlaneacion
            dtDatos = daoPlanea.TraerLiquidosGrillaElim(objConexion, cod_historia, strCod_pre_sgs, strCod_sucur, strTip_Admision, strAno_Adm, strNum_Adm)

            Return dtDatos
        End Function
        Public Shared Function TraerLiquidosGrillaElim1(ByVal objConexion As Conexion, ByVal cod_historia As String, ByVal strCod_pre_sgs As String, ByVal strCod_sucur As String,
                                            ByVal strTip_Admision As String, ByVal strAno_Adm As Integer,
                                            ByVal strNum_Adm As Double) As DataTable

            Dim dtDatos As DataTable
            Dim daoPlanea As New DAOPlaneacion
            dtDatos = daoPlanea.TraerLiquidosGrillaElim1(objConexion, cod_historia, strCod_pre_sgs, strCod_sucur, strTip_Admision, strAno_Adm, strNum_Adm)

            Return dtDatos
        End Function

        ''Se crea metodo para traer texto tool tip de columna - dsanchez 11/08/2017
        Public Shared Function TraerAuxiliarColumna(ByVal objConexion As Conexion, ByVal nombreLiquido As String, ByVal strCod_pre_sgs As String,
                                                    ByVal strCod_sucur As String, ByVal strTip_Admision As String, ByVal strAno_Adm As Integer,
                                                    ByVal strNum_Adm As Double) As DataTable

            Dim dtDatos As DataTable
            Dim daoPlanea As New DAOPlaneacion

            dtDatos = daoPlanea.TraerColumnaAuxiliar(objConexion, nombreLiquido, strCod_pre_sgs, strCod_sucur, strTip_Admision, strAno_Adm, strNum_Adm)

            Return dtDatos

        End Function




        ''Claudia Garay Monitoreos  Octubre 28 de 2010
        ''Se modifica metodo de guardado de cantidades en liquidos - dsanchez 15/08/2017
        Public Shared Function GuardarMonitoreoLiquidos(ByVal objConexion As Conexion, ByVal cod_historia As Double, ByVal nombreLiquido As String, ByVal hora As String, ByVal cantidad As Double, ByVal login As String, ByVal secuencia As Integer, ByVal tipo As String, ByVal obs As String, ByVal fechaInsert As String) As Long

            Dim xmlPlaneacionMed As String = ""
            Dim consecutivodetalle As String
            Dim daoPlanea As New DAOPlaneacion()
            Dim DAOGeneral As New DAOGeneral
            Dim lError As Long
            Dim dtMedModificada As New DataTable
            Dim dtMedicaNuevos As New DataTable
            Dim dtMedicaDetNuevos As New DataTable
            Dim xmlPlaneacionMedModificados As String = ""
            Dim Datos() As Object

            ReDim Datos(11)

            Datos(0) = fechaInsert
            Datos(1) = nombreLiquido
            Datos(2) = cod_historia
            Datos(3) = CInt(hora)
            Datos(4) = cantidad
            Datos(5) = "A"
            Datos(6) = secuencia
            Datos(7) = login
            Datos(8) = tipo
            Datos(9) = obs
            Datos(10) = lError
            Try
                lError = daoPlanea.GuardarLiquidos(objConexion, lError, Datos)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information)
            End Try


            Return lError
        End Function

        ''Claudia Garay Monitoreos  Octubre 28 de 2010
        Public Shared Function GuardarMonitoreoLiquidos1(ByVal objConexion As Conexion, ByVal cod_historia As Double, ByVal cod_liquido As String, ByVal consecutivoenc As String, ByVal hora As String, ByVal cantidad As Double, ByVal login As String, ByVal secuencia As Integer, ByVal tipo As String, ByVal obs As String, ByVal nroorden As String, ByVal intAccion As Integer) As Long

            Dim xmlPlaneacionMed As String = ""
            Dim consecutivodetalle As String
            Dim daoPlanea As New DAOPlaneacion()
            Dim DAOGeneral As New DAOGeneral
            Dim lError As Long
            Dim dtMedModificada As New DataTable
            Dim dtMedicaNuevos As New DataTable
            Dim dtMedicaDetNuevos As New DataTable
            Dim xmlPlaneacionMedModificados As String = ""
            Dim Datos() As Object

            ''Monitoreos

            ''Claudia Garay Consecutivo
            consecutivodetalle = DAOGeneral.EjecutarSQLStrValor("hcenfControlLiquidodet (nolock)", objConexion, " max(consecutivo)", " cod_historia=" & cod_historia & "and tipo='" & tipo & "' and cod_liquido='" & cod_liquido & "'")

            If intAccion <> 3 Then
                consecutivodetalle = consecutivodetalle + 1
            End If

            ReDim Datos(14)

            Datos(0) = cod_historia
            Datos(1) = CInt(consecutivodetalle)
            Datos(2) = cod_liquido
            Datos(3) = CInt(hora)
            Datos(4) = cantidad
            Datos(5) = "A"
            Datos(6) = secuencia
            Datos(7) = login
            Datos(8) = tipo
            Datos(9) = obs
            Datos(10) = IIf(consecutivoenc = "", 0, consecutivoenc)
            Datos(11) = nroorden
            Datos(12) = intAccion
            Datos(13) = lError
            Try
                lError = daoPlanea.GuardarLiquidos1(objConexion, lError, Datos)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information)
            End Try


            Return lError
        End Function

        'Se modifica metodo de grabado de liquidos - dsanchez 10/08/2017
        Public Shared Function GuardarhcenfControlLiquido(ByVal objConexion As Conexion, ByVal cod_historia As Double, ByVal cod_liquido As String, ByVal login As String, ByVal tipo As String, ByVal secuencia As Integer, ByVal lateralidad As Char) As Long


            Dim daoPlanea As New DAOPlaneacion()
            Dim DAOGeneral As New DAOGeneral
            Dim lError As Long
            Dim Datos() As Object

            ReDim Datos(7)

            Datos(0) = cod_historia
            Datos(1) = cod_liquido
            Datos(2) = login
            Datos(3) = secuencia
            Datos(4) = tipo
            Datos(5) = lateralidad
            Datos(6) = lError
            Try
                lError = daoPlanea.GuardarhcenfControlLiquido(objConexion, lError, Datos)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information)
            End Try


            Return lError
        End Function

        Public Shared Function GuardarhcenfControlLiquido1(ByVal objConexion As Conexion, ByVal cod_historia As Double, ByVal cod_liquido As String, ByVal login As String, ByVal tipo As String, ByVal secuencia As Integer) As Long


            Dim daoPlanea As New DAOPlaneacion()
            Dim DAOGeneral As New DAOGeneral
            Dim lError As Long
            Dim Datos() As Object

            ReDim Datos(6)

            Datos(0) = cod_historia
            Datos(1) = cod_liquido
            Datos(2) = login
            Datos(3) = secuencia
            Datos(4) = tipo
            Datos(5) = lError
            Try
                lError = daoPlanea.GuardarhcenfControlLiquido1(objConexion, lError, Datos)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information)
            End Try


            Return lError
        End Function

        Public Shared Function ConsultaObsLiquidos(ByVal objConexion As Conexion, ByVal cod_historia As Double, ByVal cod_liquido As String, ByVal consecutivoenc As String, ByVal hora As String, ByVal cantidad As Double, ByVal login As String, ByVal tipo As String, ByVal obs As String, ByVal Nroorden As String, ByVal intAccion As Integer) As DataSet

            Dim xmlPlaneacionMed As String = ""
            Dim consecutivodetalle As String
            Dim daoPlanea As New DAOPlaneacion()
            Dim DAOGeneral As New DAOGeneral
            Dim lError As Long
            Dim dtMedModificada As New DataTable
            Dim dtMedicaNuevos As New DataTable
            Dim dtObs As New DataSet
            Dim xmlPlaneacionMedModificados As String = ""
            Dim Datos() As Object



            ''Claudia Garay Consecutivo
            consecutivodetalle = DAOGeneral.EjecutarSQLStrValor("hcenfControlLiquidodet (nolock)", objConexion, " max(consecutivo)", " cod_historia=" & cod_historia & "and tipo='" & tipo & "' and cod_liquido='" & cod_liquido & "'")

            consecutivodetalle = consecutivodetalle + 1

            ''            AgregarAlArregloD()
            ''dtMedicaDetNuevos = CrearTablaDetalle(dtMedModificada, objConexion)


            ReDim Datos(13)

            Datos(0) = cod_historia
            Datos(1) = CInt(consecutivodetalle)
            Datos(2) = cod_liquido
            Datos(3) = CInt(hora)
            Datos(4) = cantidad
            Datos(5) = "A"
            Datos(6) = 0
            Datos(7) = login
            Datos(8) = tipo
            Datos(9) = obs
            Datos(10) = 0
            Datos(11) = IIf(Nroorden = "", 0, Nroorden)
            Datos(12) = 2
            Datos(13) = lError
            Try
                dtObs = daoPlanea.ConsultaObsLiquidos(objConexion, lError, Datos)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information)
            End Try

            Return dtObs
        End Function
        ''Claudia Garay
        ''Consulta de las planeaciones y las administraciones en un rango de fecha
        ''Enfermeria - 2da fase
        ''Noviembre 2011
        Public Shared Function TraerDatosPantallaPlaneacion(ByVal objConexion As Conexion, ByVal cod_historia As Double, ByVal fec_ini As String, ByVal fec_fin As String) As DataSet
            Dim dsDatos As New DataSet
            Dim daoPlanea As New DAOPlaneacion()

            ''            dsDatos = daoPlanea.TraerConsultaPantallaPlaneacion(objConexion, cod_historia, fec_ini, fec_fin)
            dsDatos = daoPlanea.TraerConsultaPantallaPlaneacion(objConexion, cod_historia, fec_ini, fec_fin)

            Return dsDatos
        End Function

        ''Se crea metodo para obtener el detalle de una cantidad en liquidos - dsanchez 15/08/2017
        Public Shared Function ObtenerDetalleCantLiquido(ByVal codHistoria As Integer, ByVal nombreLiquido As String, ByVal cantidad As Integer, ByVal tipoLiquido As String, ByVal hora As Integer, ByVal fechaConsulta As String, ByVal strlogin As String) As DataTable

            Dim dt As DataTable
            Dim daoPlanea As New DAOPlaneacion()

            dt = daoPlanea.ObtenerDetalleCantidadLiquido(codHistoria, nombreLiquido, cantidad, tipoLiquido, hora, fechaConsulta, strlogin)

            Return dt

        End Function

        ''Se valida si el liquido se encuentra o no suspendido - dsanchez 18/08/2017
        Public Shared Function ValidaSuspensionLiquido(ByVal codHistoria As Integer, ByVal nombreLiquido As String) As Boolean

            Dim liquidoSuspendido As Boolean
            Dim dtInfo As DataTable
            Dim daoPlanea As New DAOPlaneacion()

            dtInfo = daoPlanea.ValidaSuspensionLiquido(codHistoria, nombreLiquido)

            For Each fila As DataRow In dtInfo.Rows

                liquidoSuspendido = Convert.ToBoolean(fila("SUSPENDIDO"))

            Next

            Return liquidoSuspendido

        End Function


        ''Se valida la hora del liquido suspendido - martovar 2017/02/01
        Public Shared Function ValidaHoraSuspensionLiquido(ByVal codHistoria As Integer, ByVal nombreLiquido As String) As Integer

            Dim HoraliquidoSuspendido As Integer
            Dim dtInfo As DataTable
            Dim daoPlanea As New DAOPlaneacion()

            dtInfo = daoPlanea.ValidaHoraSuspensionLiquido(codHistoria, nombreLiquido)

            For Each fila As DataRow In dtInfo.Rows

                HoraliquidoSuspendido = (fila("Hora"))

            Next

            Return HoraliquidoSuspendido

        End Function

        ''Se crea metodo para validar si el liquido eliminado es de diuresis - dsanchez 30/08/2017
        Public Shared Function ValidaLiquidoDiuresis(ByVal nombreLiquido As String) As Boolean

            Dim bResultado As Boolean
            Dim daoPlanea As New DAOPlaneacion()

            bResultado = daoPlanea.ValidaLiquidoDiuresis(nombreLiquido)

            Return bResultado

        End Function

        ''Se crea metodo para obtener caracteristicas de liquidos eliminados - dsanchez 24/08/2017
        Public Shared Function ObtenerCaractLiquidoElim(ByVal nombreLiquido As String) As DataTable

            Dim dtInfo As DataTable
            Dim daoPlanea As New DAOPlaneacion()

            dtInfo = daoPlanea.ObtenerCaractLiquidoElim(nombreLiquido)

            Return dtInfo

        End Function

        ''Se modifica metodo de guardado de cantidades en liquidos eliminados - dsanchez 24/08/2017
        Public Shared Function GuardarMonitoreoLiquidosElim(ByVal objConexion As Conexion, ByVal cod_historia As Double,
        ByVal nombreLiquido As String, ByVal nroOrden As String, ByVal lateralidad As String, ByVal obs As String,
        ByVal cantidad As Double, ByVal login As String, ByVal tipo As String, ByVal hora As Integer, ByVal fechaInsert As String) As Long
            Dim xmlPlaneacionMed As String = String.Empty
            Dim daoPlanea As New DAOPlaneacion()
            Dim DAOGeneral As New DAOGeneral
            Dim lError As Long
            Dim dtMedModificada As New DataTable
            Dim dtMedicaNuevos As New DataTable
            Dim dtMedicaDetNuevos As New DataTable
            Dim xmlPlaneacionMedModificados As String = String.Empty
            Dim Datos() As Object

            ReDim Datos(11)

            Datos(0) = fechaInsert
            Datos(1) = cod_historia
            Datos(2) = nombreLiquido
            Datos(3) = CInt(nroOrden)
            Datos(4) = lateralidad
            Datos(5) = obs
            Datos(6) = CDbl(cantidad)
            Datos(7) = login
            Datos(8) = tipo
            Datos(9) = CInt(hora)
            Datos(10) = lError

            Try
                lError = daoPlanea.GuardarLiquidosElim(objConexion, lError, Datos)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information)
            End Try


            Return lError
        End Function

        ''Se crea metodo para borrar liquidos administrados o eliminados - dsanchez 24/08/2017
        Public Shared Function BorrarLiquido(ByVal objConexion As Conexion, ByVal cod_historia As Double,
        ByVal nombreLiquido As String, ByVal nroOrden As String, ByVal lateralidad As String, ByVal tipo As String) As Long
            Dim xmlPlaneacionMed As String = String.Empty
            Dim daoPlanea As New DAOPlaneacion()
            Dim DAOGeneral As New DAOGeneral
            Dim lError As Long
            Dim dtMedModificada As New DataTable
            Dim dtMedicaNuevos As New DataTable
            Dim dtMedicaDetNuevos As New DataTable
            Dim xmlPlaneacionMedModificados As String = String.Empty
            Dim Datos() As Object

            ReDim Datos(6)

            Datos(0) = cod_historia
            Datos(1) = nombreLiquido
            Datos(2) = CInt(nroOrden)
            Datos(3) = lateralidad
            Datos(4) = tipo
            Datos(5) = lError

            Try
                lError = daoPlanea.BorrarLiquido(objConexion, lError, Datos)
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information)
            End Try


            Return lError
        End Function

        ''Se crea metodo para consultar liquido administrado - dsanchez 05/09/2017
        Public Shared Function ConsulLiqAdmin(ByVal codHistoria As Integer, ByVal fecha As String) As DataTable

            Dim daoPlanea As New DAOPlaneacion()
            Dim dtInfo As DataTable = New DataTable()

            dtInfo = daoPlanea.ConsultaLiquidoAdministrado(codHistoria, fecha)

            Return dtInfo

        End Function

        ' Se crea metodo para obtener peso del paciente - control de liquidos - dsanchez 21/08/2017
        Public Shared Function ObtenerPeso(ByVal prestador As String, ByVal sucursal As String, ByVal numAdmision As Double, ByVal anoAdmision As Integer, ByVal tipoAdmision As String, ByVal codHistoria As Integer) As String

            Dim dtInfo As DataTable = New DataTable
            Dim daoPlanea As New DAOPlaneacion
            Dim resultado As String = String.Empty

            dtInfo = daoPlanea.ObtenerPesoPaciente(prestador, sucursal, numAdmision, anoAdmision, tipoAdmision, codHistoria)

            For Each fila As DataRow In dtInfo.Rows

                resultado = fila("peso").ToString()

            Next

            If resultado = String.Empty Then

                resultado = "0"

            End If

            Return resultado

        End Function

        ' Se crea metodo para obtener peso del paciente - control de liquidos - dsanchez 21/08/2017
        Public Shared Function ObtenerPesoConsulta(ByVal prestador As String, ByVal sucursal As String, ByVal numAdmision As Double, ByVal anoAdmision As Integer, ByVal tipoAdmision As String, ByVal codHistoria As Integer, ByVal fechaConsulta As String, ByVal corte As String) As String

            Dim dtInfo As DataTable = New DataTable
            Dim daoPlanea As New DAOPlaneacion
            Dim resultado As String = String.Empty

            dtInfo = daoPlanea.ObtenerPesoPacienteconsulta(prestador, sucursal, numAdmision, anoAdmision, tipoAdmision, codHistoria, fechaConsulta, corte)

            For Each fila As DataRow In dtInfo.Rows

                resultado = fila("peso").ToString()

            Next

            If resultado = String.Empty Then

                resultado = "0"

            End If

            Return resultado

        End Function

        ''Se crea metodo para obtener la edad del paciente - dsanchez 15/09/2017
        Public Shared Function ObtenerEdadPaciente(ByVal prestador As String, ByVal sucursal As String, ByVal numAdmision As Double, ByVal anoAdmision As Integer, ByVal tipAdmision As String) As Integer

            Dim resultado As Integer = 0
            Dim daoPlanea As New DAOPlaneacion()

            resultado = daoPlanea.ObtenerEdadPaciente(prestador, sucursal, numAdmision, anoAdmision, tipAdmision)

            Return resultado

        End Function

        ''Se crea metodo para obtener la edad del paciente - dsanchez 15/09/2017
        Public Shared Function ObtenerEdadPacienteLiquidos(ByVal prestador As String, ByVal sucursal As String, ByVal numAdmision As Double, ByVal anoAdmision As Integer, ByVal tipAdmision As String, ByVal codHistoria As Integer) As DataTable

            Dim daoPlanea As New DAOPlaneacion()
            Dim dtInfo As DataTable = New DataTable()

            dtInfo = daoPlanea.ObtenerEdadPacienteLiquidos(prestador, sucursal, numAdmision, anoAdmision, tipAdmision, codHistoria)

            Return dtInfo

        End Function

        ''Se crea metodo para obtener la edad del paciente - dsanchez 15/09/2017
        Public Shared Function ObtenerEdadPacienteLiquidosconsulta(ByVal prestador As String, ByVal sucursal As String, ByVal numAdmision As Double, ByVal anoAdmision As Integer, ByVal tipAdmision As String, ByVal codHistoria As Integer, ByVal fechaConsulta As String) As DataTable

            Dim daoPlanea As New DAOPlaneacion()
            Dim dtInfo As DataTable = New DataTable()

            dtInfo = daoPlanea.ObtenerEdadPacienteLiquidosConsulta(prestador, sucursal, numAdmision, anoAdmision, tipAdmision, codHistoria, fechaConsulta)

            Return dtInfo

        End Function
        ''Se crea metodo para obtener la diferencia de horas - dsanchez 05/09/2017
        Public Shared Function ObtenerDiferenciaHora(ByVal prestador As String, ByVal sucursal As String, ByVal numAdmision As Double,
                                              ByVal anoAdmision As Integer, ByVal tipAdmision As String, ByVal nombreProducto As String,
                                              ByVal nroOrden As String) As Boolean

            Dim iResultado As Integer = 0
            Dim daoPlanea As New DAOPlaneacion()

            iResultado = daoPlanea.ObtenerDiferenciaHora(prestador, sucursal, numAdmision, anoAdmision, tipAdmision, nombreProducto, nroOrden)

            If iResultado > 24 Then

                Return True

            Else

                Return False

            End If

        End Function

        ''Se crea metodo para obtener la fecha y hora de admision - dsanchez 05/09/2017
        Public Shared Sub ObtenerFechaHoraAdmision(ByVal objConexion As Conexion, ByVal prestador As String, ByVal sucursal As String, ByVal numAdmision As Integer, ByVal anoAdmision As Integer, ByVal tipoAdmision As String, ByRef fecha As String, ByRef hora As Integer)

            Dim daoPlanea As New DAOPlaneacion()
            Dim dtInfo As DataTable = New DataTable()

            dtInfo = BLPlaneacion.Traerfechahoraadmision(objConexion, prestador, sucursal, tipoAdmision, anoAdmision, numAdmision)

            'dtInfo = daoPlanea.ObtenerFechaHoraAdmision(prestador, sucursal, numAdmision, anoAdmision, tipoAdmision)

            For Each fila As DataRow In dtInfo.Rows

                fecha = fila("fec_ingreso").ToString().Replace(" 00:00:00", String.Empty)
                hora = CInt(fila("hora_ingreso").ToString())

            Next

        End Sub

        ''Se crea metodo para obtener la lateralidadde un item - dsanchez 05/09/2017
        Public Shared Function obtenerLateralidad(ByVal nombreLiquido As String, ByVal tipo As String) As String

            Dim iIndex As Integer, lateralidad As String

            If tipo = "LE" Then
                iIndex = nombreLiquido.IndexOf("|")
                lateralidad = nombreLiquido.Substring(0, iIndex)
            Else

                lateralidad = "N"

            End If

            Return lateralidad

        End Function

        ''Se crea metodo para obtener el nombre del liquido - dsanchez 05/09/2017
        Public Shared Function obtenerNombreLiquido(ByVal nombreLiquido As String, ByVal tipo As String) As String

            Dim iIndex As Integer
            Dim liquido As String
            Dim inicioCadena As String
            Dim finCadena As String

            If tipo = "LA" Then

                iIndex = nombreLiquido.IndexOf("|")
                liquido = nombreLiquido.Substring(0, iIndex)

            Else

                inicioCadena = obtenerLateralidad(nombreLiquido, tipo) + "|"
                finCadena = "|" + ObtenerNroOrden(nombreLiquido, tipo)

                liquido = nombreLiquido.Replace(finCadena, String.Empty)
                liquido = liquido.Replace(inicioCadena, String.Empty)

            End If

            Return liquido

        End Function

        ''Se crea metodo para obtener el numero de orden - dsanchez 05/09/2017
        Public Shared Function ObtenerNroOrden(ByVal nombreLiquido As String, ByVal tipo As String) As String

            Dim iIndex As Integer
            Dim cantCar As Integer
            Dim nroOrden As String

            If tipo = "LA" Then

                iIndex = nombreLiquido.IndexOf("|")
                cantCar = nombreLiquido.Length
                cantCar = cantCar - iIndex

                nroOrden = nombreLiquido.Substring(iIndex + 1, cantCar - 1)

            Else

                iIndex = nombreLiquido.IndexOf("|")
                iIndex = nombreLiquido.IndexOf("|", iIndex + 1)
                cantCar = nombreLiquido.Length
                cantCar = cantCar - iIndex

                nroOrden = nombreLiquido.Substring(iIndex + 1, cantCar - 1)

            End If

            Return nroOrden

        End Function

        ''Se crea metodo para consultar el header de las columnas - dsanchez 05/09/2017
        Public Shared Function ConsultaHeaderColumna(ByVal fecha As String, ByVal codHistoria As Integer, ByVal nombreLiquido As String, ByVal nroOrden As Integer) As DataTable

            Dim daoPlanea As New DAOPlaneacion()
            Dim dt As DataTable = New DataTable()

            dt = daoPlanea.ConsultaHeaderColumna(fecha, codHistoria, nombreLiquido, nroOrden)

            Return dt

        End Function

        ''Se crea metodo para consultar liquido eliminado - dsanchez 05/09/2017
        Public Shared Function ConsultaLiquidoEliminado(ByVal codHistoria As Integer, ByVal fecha As String) As DataTable

            Dim daoPlanea As New DAOPlaneacion()
            Dim dtInfo As DataTable = New DataTable()

            dtInfo = daoPlanea.ConsultaLiquidoEliminado(codHistoria, fecha)

            Return dtInfo

        End Function

        ''Se crea metodo para obtener diferencia de dias entre 2 fechas - dsanchez 11/09/2017
        Public Shared Function obtenerDiferenciaDia(ByVal fechaInicial As String, ByVal fechaFinal As String) As Integer

            Dim resultado As Integer = 0
            Dim daoPlanea As New DAOPlaneacion()

            resultado = daoPlanea.ObtenerDiferenciaDias(fechaInicial, fechaFinal)

            Return resultado

        End Function

        ''Se crea metodo para sumar un dia a una fecha - dsanchez 15/09/2017
        Public Shared Function SumarDiaFecha(ByVal fecha As String) As String

            Dim dt As DataTable = New DataTable()
            Dim daoPlanea As New DAOPlaneacion()
            Dim resultado As String = String.Empty

            dt = daoPlanea.SumarDiaFecha(fecha)

            For Each fila As DataRow In dt.Rows

                resultado = fila("FECHA")

            Next

            Return resultado

        End Function

        Public Shared Function obtenerFecha(ByVal fecDato As Date) As String

            Dim fecha As String = String.Empty
            Dim fCalculo As Date = fecDato

            fecha = fCalculo.Year.ToString()

            If fCalculo.Month().ToString().Length() = 1 Then

                fecha = fecha + "0" + fCalculo.Month().ToString()

            Else

                fecha = fecha + fCalculo.Month().ToString()

            End If

            If fCalculo.Day().ToString().Length() = 1 Then

                fecha = fecha + "0" + fCalculo.Day.ToString()

            Else

                fecha = fecha + fCalculo.Day.ToString()

            End If

            Return fecha

        End Function

        'Dsanchez IG - 23-10-2017, Metodo para insertar el balance calculado por corte
        Public Shared Function InsertarBalance(ByVal CodHistoria As Integer, ByVal balance As Double, ByVal peso As Double, ByVal edad As Double, ByVal mes As Double, ByVal dia As Double, ByVal unidad_medida As String, ByVal finalizado As Integer, ByVal corte As Integer) As Integer

            Dim daoPlanea As New DAOPlaneacion()
            Dim resultado As Integer = 0

            If peso = 0 Then

                balance = 0

            End If

            resultado = daoPlanea.InsertarBalance(CodHistoria, balance, peso, edad, mes, dia, unidad_medida, finalizado, corte)

            Return resultado

        End Function

        'Dsanchez IG - 23-10-2017, Metodo para obtener el balance calculado segun el corte
        Public Shared Sub ConsultarBalanceXCorte(ByVal codHistoria As Integer, ByVal fechaLiquido As String, ByVal corte As Integer, ByRef peso As Double, ByRef balance As String)

            Dim dtInfo As DataTable = New DataTable()
            Dim daoPlanea As New DAOPlaneacion()
            Dim unidad_medida As String = String.Empty

            dtInfo = daoPlanea.ConsultarBalanceXCorte(codHistoria, fechaLiquido, corte)

            For Each fila As DataRow In dtInfo.Rows

                unidad_medida = fila("unidad_medida").ToString()
                peso = CInt(fila("peso").ToString())
                balance = CDbl(fila("balance").ToString())

            Next

            balance = balance + " - " + unidad_medida

        End Sub

        Public Shared Sub ConsultarBalanceXCorteHIS(ByVal codHistoria As Integer, ByVal fechaLiquido As String, ByVal corte As Integer, ByRef peso As Double, ByRef balance As String)

            'Dim dtInfo As DataTable = New DataTable()
            'Dim daoPlanea As New DAOPlaneacion()
            'Dim unidad_medida As String = String.Empty

            'dtInfo = daoPlanea.ConsultarBalanceXCorte(codHistoria, fechaLiquido, corte)


            'For Each fila As DataRow In dtInfo.Rows

            '    unidad_medida = fila("unidad_medida").ToString()
            '    If CInt(fila("peso").ToString()) = 0 Then
            '        peso = peso
            '    Else
            '        peso = CInt(fila("peso").ToString())
            '    End If

            '    balance = CDbl(fila("balance").ToString())

            '    If CDbl(fila("balance").ToString()) = 0 Then
            '        balance = balance
            '    Else
            '        balance = balance + " - " + unidad_medida
            '    End If

            'Next


            Dim dtInfo As DataTable = New DataTable()
            Dim daoPlanea As New DAOPlaneacion()
            Dim unidad_medida As String = String.Empty

            dtInfo = daoPlanea.ConsultarBalanceXCorte(codHistoria, fechaLiquido, corte)

            For Each fila As DataRow In dtInfo.Rows

                unidad_medida = fila("unidad_medida").ToString()
                peso = CInt(fila("peso").ToString())
                balance = CDbl(fila("balance").ToString())

            Next

            balance = balance + " - " + unidad_medida
        End Sub

        'Dsanchez IG - 23-10-2017, Metodo para obtener la fecha de horario medico
        Public Shared Function ObtenerFechaMedico() As String

            Dim dtInfo As DataTable = New DataTable()
            Dim daoPlanea As New DAOPlaneacion()
            Dim fecha As String = String.Empty

            dtInfo = daoPlanea.ObtenerFechaMedico()

            For Each fila As DataRow In dtInfo.Rows

                fecha = fila("fecha").ToString()

            Next

            Return fecha

        End Function

        'Dsanchez IG - 23-10-2017, Metodo para validar si existe balance registrado
        Public Shared Function ValidaExisteBalanceCorte(ByVal codHistoria As Integer, ByVal fechaLiquido As String, ByVal corte As Integer) As Boolean

            Dim resultado As Integer = 0
            Dim respuesta As Boolean = False
            Dim daoPlanea As New DAOPlaneacion()

            resultado = daoPlanea.ValidaExisteBalanceCorte(codHistoria, fechaLiquido, corte)

            If resultado = 1 Then

                respuesta = True

            End If

            Return respuesta

        End Function

        'Dsanchez IG - 24/10/2017, Metodo que obtiene el valor que indica si el corte ya finalizo
        Public Shared Function ValidaIntervaloCerrado(ByVal codHistoria As Integer, ByVal fechaLiquido As String, ByVal corte As Integer) As Boolean

            Dim dtInfo As DataTable = New DataTable()
            Dim respuesta As Boolean = False
            Dim daoPlanea As New DAOPlaneacion()

            dtInfo = daoPlanea.ValidaIntervaloCerrado(codHistoria, fechaLiquido, corte)

            For Each fila As DataRow In dtInfo.Rows

                respuesta = CBool(fila("finalizado").ToString())

            Next

            Return respuesta

        End Function

        'Dsanchez IG - 24/10/2017, Metodo que obtiene el valor que indica si el corte ya finalizo
        Public Shared Function ObtenerPesoIntervalo(ByVal codHistoria As Integer, ByVal fechaLiquido As String, ByVal corte As Integer) As Double

            Dim dtInfo As DataTable = New DataTable
            Dim daoPlanea As New DAOPlaneacion()
            Dim respuesta As Double = 0

            dtInfo = daoPlanea.ObtenerPesoIntervalo(codHistoria, fechaLiquido, corte)

            For Each fila As DataRow In dtInfo.Rows

                respuesta = CDbl(fila("peso").ToString())

            Next

            Return respuesta

        End Function

        ''Se crea metodo para consultar la edad del pacientes de aceurdo al intervalo - rmzaldua 13/06/2018
        Public Shared Function ObtenerEdadIntervalo(ByVal codHistoria As Integer, ByVal fechaLiquido As String, ByVal corte As Integer) As DataTable

            Dim daoPlanea As New DAOPlaneacion()
            Dim dtInfo As DataTable = New DataTable()

            dtInfo = daoPlanea.ObteneredadIntervalo(codHistoria, fechaLiquido, corte)

            Return dtInfo

        End Function

    End Class

End Namespace
