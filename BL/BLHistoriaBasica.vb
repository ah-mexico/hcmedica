Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO

Namespace Sophia.HistoriaClinica.BL
    Public Class BLHistoriaBasica
        Public Function ConsultarDatosPacientes(ByVal strProcedimiento As String, ByVal objConexion As Conexion,
                                                       ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable

            Dim dtDatos As DataTable
            Dim objDAOGeneral As New DAOGeneral

            dtDatos = objDAOGeneral.EjecutarSPConParametros(strProcedimiento, objConexion, lError, Datos)

            If dtDatos.Rows.Count <= 0 Then
                lError = 9999
            End If

            Return dtDatos

        End Function

        Public Function ConsultarFotoPaciente(ByVal strProcedimiento As String, ByVal objConexion As Conexion,
                                              ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable
            Dim dtFoto As DataTable
            Dim objDAOGeneral As New DAOGeneral

            dtFoto = objDAOGeneral.EjecutarSPConParametros(strProcedimiento, objConexion, -1, Datos)

            If dtFoto.Rows.Count <= 0 Then
                lError = 9999
            End If

            Return dtFoto

        End Function

        Public Function ConsultarTablasBasicas(ByVal strTabla As String, ByVal objConexion As Conexion, ByVal strCampos As String, ByVal strcondicion As String) As DataTable

            Dim objDAOGeneral As New DAOGeneral
            Dim dtDatos As New DataTable

            dtDatos = objDAOGeneral.EjecutarSQLConParametros(strTabla, objConexion, strCAmpos, strcondicion)

            Return dtDatos


        End Function

        Public Function CrearEncabezadoHistoriaClinica(ByVal objConexion As Conexion,
                                                       ByVal ParamArray Datos() As Object) As Long

            Dim objGeneralDAO As New DAOGeneral
            Dim lError As Long

            lError = objGeneralDAO.EjecutarSPConParametrosTran("HC_CrearEncabezadoHistoriaClinica", objConexion, Datos)

            Return lError

        End Function

        Public Function ConsultarDatosMotivoConsulta(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataSet

            Dim dtDatos As DataSet
            Dim objDAOGeneral As New DAOGeneral

            dtDatos = objDAOGeneral.EjecutarSPConParametrosDataSet("HC_MotivoDeConsulta", objConexion, lError, Datos)

            Return dtDatos

        End Function

        Public Function ConsultarDatosRevisionXSistema(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable

            Dim dtDatos As DataTable
            Dim objDAOGeneral As New DAOGeneral

            dtDatos = objDAOGeneral.EjecutarSPConParametros("HCL_REVSIS_LSTREVSISTEMAS", objConexion, lError, Datos)

            Return dtDatos

        End Function


        Public Function ConsultarServidorReporte(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable


            Dim dtDatos As DataTable
            Dim objDAOGeneral As New DAOGeneral

            dtDatos = objDAOGeneral.EjecutarSPConParametros("HCL_CONFIG_SRV_REPORTES", objConexion, lError, Datos)

            Return dtDatos

        End Function

        Public Function ConsultarDatosRiesgoNutricional(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable

            Dim dtDatos As DataTable
            Dim objDAOGeneral As New DAOGeneral

            dtDatos = objDAOGeneral.EjecutarSPConParametros("HCL_LSTRNUTRICION", objConexion, lError, Datos)

            Return dtDatos

        End Function

        Public Function ConsultarDatosAntecedentesPatologicos(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable

            Dim dtDatos As DataTable
            Dim objDAOGeneral As New DAOGeneral

            dtDatos = objDAOGeneral.EjecutarSPConParametros("HCL_LSTANTPATOLOGICO", objConexion, lError, Datos)
            'dtDatos.Columns.Add("EstadoUsu", System.Type.GetType("System.String"))

            'comentario cdqf
            'dtDatos = objDAOGeneral.EjecutarSPConParametros("HC_AntecedentesPatologicos", objConexion, lError, Datos)
            'dtDatos.Columns.Add("EstadoUsu", System.Type.GetType("System.String"))


            Return dtDatos

        End Function
        'cdqf
        Public Function ConsultarDatosAntecedentesTraumatologicos(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable

            Dim dtDatos As DataTable
            Dim objDAOGeneral As New DAOGeneral
            dtDatos = objDAOGeneral.EjecutarSPConParametros("HCL_LSTANTTRAUMA", objConexion, lError, Datos)
            Return dtDatos

        End Function


        Public Function NEliminaAntecedenteTraumatologicos(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long

            Dim objDAOGeneral As New DAOGeneral
            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_DELANTTRAUMA", objConexion, Datos)
            Return lError

        End Function

        Public Function NAdicionarAntecedentesTraumatologicos(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long

            Dim objDAOGeneral As New DAOGeneral
            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_ADDANTTRAUMA", objConexion, Datos)
            Return lError

        End Function
        'cdqf


        Public Function ConsultarDatosAntecedentesGinecologicos(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable

            Dim dtDatos As DataTable
            Dim objDAOGeneral As New DAOGeneral

            dtDatos = objDAOGeneral.EjecutarSPConParametros("HCL_LSTANTGINECOLOGICOS", objConexion, lError, Datos)
            dtDatos.Columns.Add("EstadoUsu", System.Type.GetType("System.String"))


            Return dtDatos

        End Function

        Public Function ConsultarDatosAntecedentesQuirurgicos(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable

            Dim dtDatos As DataTable
            Dim objDAOGeneral As New DAOGeneral

            dtDatos = objDAOGeneral.EjecutarSPConParametros("HCL_LSTANTQUIRURGICOS", objConexion, lError, Datos)
            dtDatos.Columns.Add("EstadoUsu", System.Type.GetType("System.String"))

            'Inicia: CCGUTIEREZ - OSI. 20/01/2020
            'Proyecto: Sophia - Codificacion 
            'Cambio: Se agrega al Grid la columna que contiene las Particularidades
            dtDatos.Columns.Add("xmlGrupPar", System.Type.GetType("System.String"))
            'Fin. CCGUTIEREZ

            Return dtDatos

        End Function

        Public Function ConsultarDatosAntecedentesTransfusional(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataSet

            Dim dsDatos As DataSet
            Dim objDAOGeneral As New DAOGeneral

            dsDatos = objDAOGeneral.EjecutarSPConParametrosDataSet("HCL_LSTANTTRANSFUSIONAL", objConexion, lError, Datos)
            dsDatos.Tables(0).Columns.Add("EstadoUsu", System.Type.GetType("System.String"))

            Return dsDatos
        End Function
        Public Function ConsultarDatosAntecedentesFarmacologicos(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable

            Dim dtDatos As DataTable
            Dim objDAOGeneral As New DAOGeneral

            'comento cdqf
            'dtDatos = objDAOGeneral.EjecutarSPConParametros("HC_AntecedentesFarmacologicos", objConexion, lError, Datos)
            dtDatos = objDAOGeneral.EjecutarSPConParametros("HCL_LSTANTFARMACOLOGICO", objConexion, lError, Datos)
            dtDatos.Columns.Add("EstadoUsu", System.Type.GetType("System.String"))


            Return dtDatos

        End Function

        Public Function ConsultarDatosAntecedentesAlergicos(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable

            Dim dtDatos As DataTable
            Dim objDAOGeneral As New DAOGeneral

            dtDatos = objDAOGeneral.EjecutarSPConParametros("HCL_LSTANTALERGICOS", objConexion, lError, Datos)
            dtDatos.Columns.Add("EstadoUsu", System.Type.GetType("System.String"))

            Return dtDatos

        End Function

        Public Function ConsultarDatosAntecedentesToxicos(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable

            Dim dtDatos As DataTable
            Dim objDAOGeneral As New DAOGeneral


            'comento cdqf
            'dtDatos = objDAOGeneral.EjecutarSPConParametros("HC_AntecedentesToxicos", objConexion, lError, Datos)
            dtDatos = objDAOGeneral.EjecutarSPConParametros("HCL_LSTANTTOXICOS", objConexion, lError, Datos)
            dtDatos.Columns.Add("EstadoUsu", System.Type.GetType("System.String"))


            Return dtDatos

        End Function

        Public Function ConsultarDatosAntecedentesFamiliares(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable

            Dim dtDatos As DataTable
            Dim objDAOGeneral As New DAOGeneral



            dtDatos = objDAOGeneral.EjecutarSPConParametros("HCL_LSTANTFAMILIARES", objConexion, lError, Datos)
            dtDatos.Columns.Add("EstadoUsu", System.Type.GetType("System.String"))


            Return dtDatos

        End Function

        Public Function ConsultarDatosVacunas(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataSet

            Dim dtDatos As DataSet
            Dim objDAOGeneral As New DAOGeneral

            'comento cdqf
            dtDatos = objDAOGeneral.EjecutarSPConParametrosDataSet("HC_AntecedentesVacunas", objConexion, lError, Datos)
            Return dtDatos

        End Function
        'ingreso cdqf
        Public Function NuevaConsultaDatosVacunas(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable

            Dim dtDatos As DataTable
            Dim objDAOGeneral As New DAOGeneral

            'comento cdqf
            'dtDatos = objDAOGeneral.EjecutarSPConParametrosDataSet("HC_AntecedentesVacunas", objConexion, lError, Datos)
            dtDatos = objDAOGeneral.EjecutarSPConParametros("HCL_LSTANTVACUNAS", objConexion, lError, Datos)

            Return dtDatos

        End Function

        Public Function ConsultarDatosExamenFisico(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataSet

            Dim dtDatos As DataSet
            Dim objDAOGeneral As New DAOGeneral

            dtDatos = objDAOGeneral.EjecutarSPConParametrosDataSet("HC_ExamenFisico", objConexion, lError, Datos)
            Return dtDatos

        End Function

        Public Function ConsultarDatosImpresionDiagnostica(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataSet

            Dim dtDatos As DataSet
            Dim objDAOGeneral As New DAOGeneral
            Dim intRow As Integer


            dtDatos = objDAOGeneral.EjecutarSPConParametrosDataSet("HC_ImpresionDiagnostica", objConexion, lError, Datos)
            dtDatos.Tables(0).Columns.Add("EstadoUsu", System.Type.GetType("System.String"))

            For intRow = 0 To dtDatos.Tables(0).Rows.Count - 1
                Select Case dtDatos.Tables(0).Rows(intRow).Item("categoria_diag").ToString
                    Case "I"
                        dtDatos.Tables(0).Rows(intRow).Item("categoria_diag") = "INGRESO"
                    Case "A"
                        'dtDatos.Tables(0).Rows(intRow).Item("categoria_diag") = "ASOCIADO"
                        dtDatos.Tables(0).Rows(intRow).Item("categoria_diag") = "RELACIONADO"
                    Case "P"
                        dtDatos.Tables(0).Rows(intRow).Item("categoria_diag") = "PRINCIPAL"
                    Case "C"
                        dtDatos.Tables(0).Rows(intRow).Item("categoria_diag") = "COMPLICACION"
                End Select
            Next

            Return dtDatos

        End Function

        Public Function ConsultarDocumentosUnificados(ByVal objConexion As Conexion,
                                              ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable
            Dim dtDocs As DataTable
            Dim objDAOGeneral As New DAOGeneral

            dtDocs = objDAOGeneral.EjecutarSPConParametros("spTraerDocumentosUnificacion", objConexion, -1, Datos)

            If dtDocs.Rows.Count <= 0 Then
                lError = 9999
            End If

            Return dtDocs

        End Function
        ''' WACHV, INICIO, 12OCT2017, Requerimiento 2. REQ.F02 Condicion paliativa, Cambiar la entidad de Cuidados Paliativos en la admisión tipo U.
        Public Function ActualizarEntidadCuidadoPaliativo(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral
            ''WACHV, 01DIC2017, SE Cambia al sp que Cambia el estado de la condicion paliativa
            lError = objDAOGeneral.EjecutarSPConParametrosTran("HC_CambiaEstadoCondicionEntidadPaliativa", objConexion, Datos)
            Return lError

        End Function   ''' WACHV, INICIO, 12OCT2017, Requerimiento 2. REQ.F02 Condicion paliativa, Cambiar la entidad de Cuidados Paliativos en la admisión tipo U.

        Public Function ActualizarDatosPaciente(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HC_ActualizarDatosPaciente", objConexion, Datos)

            Return lError

        End Function


        Public Function ActualizarMotivoDeConsulta(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HC_MotivoDeConsulta", objConexion, Datos)

            Return lError

        End Function

        Public Function ActualizarRevisionXSistema(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_REVSIS_ADDUPDREVSISTEMAS", objConexion, Datos)

            Return lError

        End Function

        Public Function ActualizarRiesgoNutricional(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_ADDRNUTRICION", objConexion, Datos)

            Return lError

        End Function

        Public Function ActualizarAntecedentePatologico(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            'comento cdqf
            'lError = objDAOGeneral.EjecutarSPConParametrosTran("HC_AntecedentesPatologicos", objConexion, Datos)

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_ADDANTPATOLOGICO", objConexion, Datos)

            Return lError

        End Function

        'cdqf ingreso

        Public Function NEliminaAntecedentePatologico(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral
            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_DELANTPATOLOGICO", objConexion, Datos)
            Return lError
        End Function

        Public Function NEliminaAntecedenteToxico(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral
            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_DELANTTOXICO", objConexion, Datos)
            Return lError
        End Function

        Public Function NEliminaAntecedenteFarmacologico(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral
            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_DELANTFARMACOLOGICO", objConexion, Datos)
            Return lError
        End Function

        Public Function NEliminaAntecedenteNoVademecum(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral
            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_DELANTFNOVADEMECUM", objConexion, Datos)
            Return lError
        End Function

        Public Function NControlFinalizarHcb(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral
            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_ERRORESGRABACIONHCB", objConexion, Datos)
            Return lError
        End Function

        Public Function NControlAntecedentesHb(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral
            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_ERRORESANTECEDENTESHB", objConexion, Datos)
            Return lError
        End Function

        Public Function NFinalizarHcb(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral
            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_GRABACIONFINAL", objConexion, Datos)
            Return lError
        End Function

        'Public Function NVALIDAGRABACIONFINALHcb(ByVal objConexion As Conexion, ByRef lExiste As Long, ByVal ParamArray Datos() As Object) As Long
        '    Dim objDAOGeneral As New DAOGeneral
        '    lExiste = objDAOGeneral.EjecutarSPConParametros execProcedure(  executeScalar("HCL_VALIDAGRABACIONFINAL", objConexion, Datos)
        '    Return lExiste
        'End Function
        Public Function NVALIDAGRABACIONFINALHcb(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable

            Dim dtDatos As DataTable
            Dim objDAOGeneral As New DAOGeneral
            dtDatos = objDAOGeneral.EjecutarSPConParametros("HCL_VALIDAGRABACIONFINAL", objConexion, lError, Datos)
            Return dtDatos

        End Function

        Public Function ConsultarListaNoRefiereAntecedentes(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable

            Dim dtDatos As DataTable
            Dim objDAOGeneral As New DAOGeneral
            dtDatos = objDAOGeneral.EjecutarSPConParametros("HCL_LSTNOREFIEREANT", objConexion, lError, Datos)
            Return dtDatos

        End Function

        'cdqf ingreso FIN
        Public Function ActualizarAntecedenteGinecologico(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral
            If Datos.Length > 7 Then
                lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_ADDANTGINECOLOGICO", objConexion, Datos)
            Else
                lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_ADDANTGINECOMETODO", objConexion, Datos)
            End If
            Return lError


        End Function

        Public Function EliminaAntecedenteGinecologico(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_DELANTGINECOLOGICO", objConexion, Datos)

            Return lError

        End Function

        Public Function ActualizarAntecedenteQuirurgico(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_ADDANTQUIRURGICO", objConexion, Datos)

            Return lError

        End Function

        Public Function EliminaAntecedenteQuirurgico(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_DELANTQUIRURGICO", objConexion, Datos)

            Return lError

        End Function
        Public Function EliminaAntecedenteTransfusional(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_DELANTTRANSFUSIONAL", objConexion, Datos)

            Return lError

        End Function

        Public Function ActualizarAntecedenteTransfusional(ByVal objConexion As Conexion, ByRef IdAntTransfusional As Integer, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral
            If Datos.Length > 3 Then
                IdAntTransfusional = objDAOGeneral.EjecutarSPConParametrosTran("HCL_ADDANTTRANSFUSIONAL", objConexion, Datos)
            Else
                IdAntTransfusional = objDAOGeneral.EjecutarSPConParametrosTran("HCL_ADDANTTRANSFUSIONALCOMPONENTE", objConexion, Datos)

            End If

            Return IdAntTransfusional

        End Function

        Public Function EliminaAntecedenteAlergico(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_DELANTALERGICO", objConexion, Datos)

            Return lError

        End Function

        Public Function EliminaAntecedenteFamiliar(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_DELANTFAMILIAR", objConexion, Datos)

            Return lError

        End Function

        Public Function ActualizarNoRefiereAntecedente(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_ADDNOREFIEREANT", objConexion, Datos)

            Return lError

        End Function

        Public Function ActualizarEsquemaVacunacion(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_ADDESQUEMAVACUNACION", objConexion, Datos)

            Return lError

        End Function

        Public Function ActualizarAntecedenteFarmacologico(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_ADDANTFARMACOLOGICO", objConexion, Datos)
            'lError = objDAOGeneral.EjecutarSPConParametrosTran("HC_AntecedentesFarmacologicos", objConexion, Datos)

            Return lError

        End Function
        Public Function IngresarNoVademecum(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_ADDANTNOVADEMECUM", objConexion, Datos)
            Return lError

        End Function

        Public Function ActualizarAntecedenteAlergico(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_ADDANTALERGICO", objConexion, Datos)

            Return lError

        End Function

        Public Function ActualizarAntecedenteToxico(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            'comento cdqf
            'lError = objDAOGeneral.EjecutarSPConParametrosTran("HC_AntecedentesToxicos", objConexion, Datos)
            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_ADDANTTOXICO", objConexion, Datos)

            Return lError

        End Function

        Public Function ActualizarAntecedenteFamiliar(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_ADDANTFAMILIAR", objConexion, Datos)

            Return lError

        End Function

        Public Function ActualizarVacunas(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HC_AntecedentesVacunas", objConexion, Datos)

            Return lError

        End Function

        Public Function ActualizarExamenFisico(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HC_ExamenFisico", objConexion, Datos)

            Return lError

        End Function

        Public Function ValidaSignosVitales(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable

            Dim dtDatos As DataTable
            Dim objDAOGeneral As New DAOGeneral

            dtDatos = objDAOGeneral.EjecutarSPConParametros("HCL_ValidaRangoSignoVital", objConexion, lError, Datos)

            Return dtDatos

        End Function

        Public Function ActualizarImpresionDiagnostica(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HC_ImpresionDiagnostica", objConexion, Datos)

            Return lError

        End Function

        Public Function ConsultarDatosAntecedentesPerinatales(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataSet

            Dim dsDatos As DataSet
            Dim objDAOGeneral As New DAOGeneral

            'dtDatos = objDAOGeneral.EjecutarSPConParametros("HCL_LSTANTPERINATALES", objConexion, lError, Datos)
            dsDatos = objDAOGeneral.EjecutarSPConParametrosDataSet("HCL_LSTANTPERINATALES", objConexion, lError, Datos)
            dsDatos.Tables(0).Columns.Add("EstadoUsu", System.Type.GetType("System.String"))

            Return dsDatos

        End Function 'GVA


        Public Function ConsultarDatosDesarrolloPsicoMotor(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable

            Dim dtDatos As DataTable
            Dim objDAOGeneral As New DAOGeneral

            dtDatos = objDAOGeneral.EjecutarSPConParametros("HC_DesarrolloPsicoMotor", objConexion, lError, Datos)
            dtDatos.Columns.Add("EstadoUsu", System.Type.GetType("System.String"))

            Return dtDatos

        End Function 'GVA

        Public Function ActualizarAntecedentePerinatal(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_ADDANTPERINATAL", objConexion, Datos)

            Return lError

        End Function 'GVA

        Public Function ActualizarAntecedentePerinatalComplicacion(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_ADDANTPERINATALCOMPLICACION", objConexion, Datos)

            Return lError

        End Function 'GVA

        Public Function EliminaAntecedentePerinatalComplicacion(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral
            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_DELANTPERINATALCOMPLICACION", objConexion, Datos)
            Return lError
        End Function


        Public Function EliminaAntecedenteTransFusionalComponente(ByVal objConexion As Conexion, ByRef IdAntTransfusional As Integer, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral
            IdAntTransfusional = objDAOGeneral.EjecutarSPConParametrosTran("HCL_DELANTPERINATALCOMPLICACION", objConexion, Datos)
            Return IdAntTransfusional
        End Function

        Public Function ActualizarAntecedentePerinatalTipoParto(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_ADDANTPERINATALTIPOPARTO", objConexion, Datos)

            Return lError

        End Function 'GVA

        Public Function EliminaAntecedentePerinatalTipoParto(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral
            lError = objDAOGeneral.EjecutarSPConParametrosTran("HCL_DELANTPERINATALTIPOPARTO", objConexion, Datos)
            Return lError
        End Function

        Public Function ActualizarDesarrolloPsicoMotor(ByVal objConexion As Conexion, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New DAOGeneral

            lError = objDAOGeneral.EjecutarSPConParametrosTran("HC_DesarrolloPsicoMotor", objConexion, Datos)

            Return lError

        End Function 'GVA
        ''Claudia Garay Permisos de consulta hc
        ''Solicitado por Hernan Rojas
        '' 2011-03-29
        Public Shared Function ConsultarPermisosConsulta(ByVal objConexion As Conexion, ByRef lError As Long, ByVal strlogin As String) As DataTable
            Dim objDAOGeneral As New DAOGeneral
            Dim dtresultado As New DataTable

            dtresultado = objDAOGeneral.EjecutarSPConParametros("HC_ConsultaPermisosConsulta", objConexion, lError, strlogin)

            Return dtresultado

        End Function 'GVA

        Public Function ConsultarLoginEstadoEncabezadoHC(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String,
                                      ByVal strCod_sucur As String, ByVal strTip_admision As String,
                                      ByVal iAno_adm As Integer, ByVal lNum_adm As Long, ByRef lError As Long) As DataTable
            Dim dtDatos As DataTable
            Dim objDAOGeneral As New DAOGeneral

            dtDatos = objDAOGeneral.EjecutarSQLConParametros("hcencabezado", objConexion, "login,estado",
                        "cod_pre_sgs='" & strCod_pre_sgs & "' AND cod_sucur='" & strCod_sucur & "' AND tip_admision='" & strTip_admision &
                        "' AND ano_adm='" & iAno_adm & "' AND num_adm='" & lNum_adm & "'")

            Return dtDatos
        End Function

        'rmzaldua cambio solicitado por german para que no muestre los estado del laboratorio si esta apagada el flag de WSlabor en la sucursal
        Public Function ConsultarLoginEstadoEncabezadoHC(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String,
                              ByVal strCod_sucur As String, ByRef lError As Long) As DataTable
            Dim dtDatos As DataTable
            Dim objDAOGeneral As New DAOGeneral

            dtDatos = objDAOGeneral.EjecutarSQLConParametros("gensucur", objConexion, "man_wslabo",
                        "cod_pre_sgs='" & strCod_pre_sgs & "' AND cod_sucur='" & strCod_sucur)

            Return dtDatos
        End Function

        ''Claudia Garay Alarmas sept 28 de 2010
        Public Shared Function ConsultarAlarmas(ByVal objConexion As Conexion) As DataTable
            Dim daoGeneral As New DAOGeneral
            Dim dtdatos As DataTable

            dtdatos = daoGeneral.EjecutarSQLConParametros("hcEnfgenAlarma", objConexion, "'' as cod_historia,'' as consecutivo,'' as login,cod_riesgo,descripcion,'' as estado", "")

            Return dtdatos
        End Function
        Public Shared Function ConsultarAlarmasXPac(ByVal objConexion As Conexion, ByVal Prestador As String, ByVal Sucursal As String, ByVal Tip_Adm As String,
                                                   ByVal Ano_Adm As String, ByVal Num_adm As String, ByVal tip_doc As String, ByVal num_doc As String) As DataSet
            Dim daoHB As New DAOHistoriaBasica
            Dim dsdatos As DataSet

            dsdatos = daoHB.ConsultarAlarmasXPac(objConexion, Prestador, Sucursal, Tip_Adm, Ano_Adm, Num_adm, tip_doc, num_doc)
            Return dsdatos
        End Function
        Public Shared Function ConsultarRecomendacionesFarmacoXPac(ByVal tip_doc As String, ByVal num_doc As String) As DataTable
            Dim daoHB As New DAOHistoriaBasica
            Dim dtdatos As DataTable

            dtdatos = daoHB.ConsultarRecomendacionesFarmaco(tip_doc, num_doc)
            Return dtdatos
        End Function
        ''Claudia Garay Alarmas sept 28 de 2010
        Public Shared Function ConsultarHistoricoAlarmasPac(ByVal objConexion As Conexion, ByVal cod_historia As String) As DataSet
            Dim daoHB As New DAOHistoriaBasica
            Dim dsdatos As DataSet

            dsdatos = daoHB.ConsultarHistoricoAlarmasXPac(objConexion, cod_historia)
            Return dsdatos
        End Function
        Public Shared Function GuardarAlarmas(ByVal objConexion As Conexion, ByVal cod_historia As String, ByVal login As String, ByVal dtAlarma As DataTable) As Long
            Dim lError As Long
            Dim daoHB As New DAOHistoriaBasica
            Dim xmlAlarmas As String

            AsignarConsecutivoAlarma(objConexion, dtAlarma, cod_historia, login)
            xmlAlarmas = FuncionesGenerales.GenerarXMLxProcedimiento(dtAlarma)
            lError = daoHB.AlmacenarAlarmas(objConexion, xmlAlarmas)
            Return lError
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
        ''Auditoria de apertura y cierres de historia
        ''Claudia Garay 
        ''Abril 5 de 2011
        Public Function ActualizaTablaAuditoria(ByVal objconexion As Conexion, ByVal cod_historia As Decimal, ByVal strPrestador As String, ByVal strSucur As String, ByVal TipAdmision As String,
                                        ByVal Ano_adm As String, ByVal Num_Adm As String, ByVal medico As String, ByVal estado As String, ByVal obs As String) As Long
            Dim daoHB As New DAOHistoriaBasica
            Dim lError As Long = 0
            Try
                lError = daoHB.AuditoriaAperturaHC(objconexion, cod_historia, strPrestador, strSucur, TipAdmision, Ano_adm, Num_Adm, medico, estado, obs)
            Catch ex As Exception

            End Try

            Return lError

        End Function

        Public Shared Function ConsultarPerfilUsuario(ByVal strProcedimiento As String, ByVal objConexion As Conexion,
                                               ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable

            Dim dtDatos As DataTable
            Dim objDAOGeneral As New DAOGeneral

            dtDatos = objDAOGeneral.EjecutarSPConParametros(strProcedimiento, objConexion, lError, Datos)

            If dtDatos.Rows.Count <= 0 Then
                lError = 9999
            End If

            Return dtDatos

        End Function

        Public Shared Function ConsultarVersion(ByVal strProcedimiento As String, ByVal objConexion As Conexion,
                                               ByRef lError As Long, ByVal ParamArray Datos() As Object) As DataTable

            Dim dtDatos As DataTable
            Dim objDAOGeneral As New DAOGeneral

            dtDatos = objDAOGeneral.EjecutarSPConParametros(strProcedimiento, objConexion, lError, Datos)

            If dtDatos.Rows.Count <= 0 Then
                lError = 9999
            End If

            Return dtDatos
        End Function
        ''' <summary>
        ''' Consulta las admisiones de HC_Medica de un paciente a nivel nacional que tenga permiso en la tabla de parametrización  sos.AUTORIZACION_SUCURSAL_REGION
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

            Dim dtDatos As DataTable
            Dim objDAOGeneral As New DAOHistoriaBasica

            dtDatos = objDAOGeneral.ConsultaAdminNacional(objconexion, strTip_Doc, strNum_Doc,
                                                         dFechaInicial, dFechaFinal, strSucursal, strPrestador, o_lError)

            If dtDatos.Rows.Count <= 0 Then
                o_lError = 9999
            End If

            Return dtDatos

        End Function

        ''' <summary>
        ''' Consulta las admisiones de HC_Enfermeria de un paciente a nivel nacional que tenga permiso en la tabla de parametrización  sos.AUTORIZACION_SUCURSAL_REGION
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

            Dim dtDatos As DataTable
            Dim objDAOGeneral As New DAOHistoriaBasica

            dtDatos = objDAOGeneral.ConsultaAdminNacional_HCEnf(objconexion, strTip_Doc, strNum_Doc,
                                                         dFechaInicial, dFechaFinal, strSucursal, strPrestador,
                                                          o_lError)

            If dtDatos.Rows.Count <= 0 Then
                o_lError = 9999
            End If

            Return dtDatos

        End Function

        'Inicia: INDRA/OJPARRA  04/03/2022
        'Proyecto: Sophia - Conciliación Medicamentos (VISUALIZAR CONCILIACIÓN DE MEDICAMENTOS EN ANTECEDENTES FARMACOLOGICOS CU1)
        Public Shared Function ConsultarUnidadMedida(ByVal objConexion As Conexion) As DataTable
            Dim daoHistoriaBasica As New DAOHistoriaBasica

            Return daoHistoriaBasica.ConsultarUnidadMedida(objConexion)
        End Function

        Public Shared Function ConsultarViasAdmin(ByVal objConexion As Conexion) As DataTable
            Dim daoHistoriaBasica As New DAOHistoriaBasica
            Return daoHistoriaBasica.ConsultarViasAdmin(objConexion)
        End Function

        Public Shared Function ConsultarFrecuencia(ByVal objConexion As Conexion) As DataTable
            Dim daoHistoriaBasica As New DAOHistoriaBasica
            Return daoHistoriaBasica.ConsultarFrecuencia(objConexion)
        End Function

    End Class

End Namespace
