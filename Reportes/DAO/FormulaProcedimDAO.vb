
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes.Data
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales


Namespace Sophia.HistoriaClinica.Reportes.DAO
    Public Class FormulaProcedimDAO
        Inherits GPMDataReport

        ''' <summary>
        ''' Consulta los datos para la formula de procedimientos
        ''' </summary>
        ''' <param name="codPrestador">Codigo prestador</param>
        ''' <param name="codSucursal">Codigo sucursal</param>
        ''' <param name="tipAdmin">Tipo Admision</param>
        ''' <param name="iAno">Año de admision</param>
        ''' <param name="lNumAdm">Numero de admision</param>
        ''' <param name="dConProcedim">Procedimiento</param>
        ''' <returns>Objeto con la informacion para la formula de procedimientos</returns>
        ''' <remarks></remarks>
        Public Function consultFormulProcedim(ByVal codPrestador As String, ByVal codSucursal As String, _
                                            ByVal tipAdmin As String, ByVal iAno As Long, _
                                            ByVal lNumAdm As Long, ByVal dConProcedim As Long, ByVal FlagConsulta As Long) As FormulaProcedimData

            Dim dtSetReturn As DataSet

            ''Carga de parametros para ejecucion del procedimiento
            gpmDataObj.setSQLSentence("pa_Reportes_RepFomulaProcedimPDF", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("strcod_pre_sgs", SqlDbType.VarChar, codPrestador)
            gpmDataObj.addInputParameter("strCod_sucur", SqlDbType.VarChar, codSucursal)
            gpmDataObj.addInputParameter("strTipAdm", SqlDbType.VarChar, tipAdmin)
            gpmDataObj.addInputParameter("iAno", SqlDbType.Int, iAno)
            gpmDataObj.addInputParameter("lNumAdm", SqlDbType.BigInt, lNumAdm)
            gpmDataObj.addInputParameter("dCon_procedim", SqlDbType.BigInt, dConProcedim)
            gpmDataObj.addInputParameter("FlagConsulta", SqlDbType.BigInt, FlagConsulta)

            ''Ejecucion del procedimiento
            dtSetReturn = gpmDataObj.execDS()

            Return processDataSet(dtSetReturn)
        End Function

        ''' <summary>
        ''' Procesa la salida de la ejecucion del store procedure retornando un objeto con la informacion 
        ''' obtenida
        ''' </summary>
        ''' <param name="dtSet">DataSet retultado de la transaccion</param>
        ''' <returns>Objeto con la informacion para la formula de procedimientos</returns>
        ''' <remarks></remarks>
        Private Function processDataSet(ByVal dtSet As DataSet) As FormulaProcedimData
            Dim formula As FormulaProcedimData = Nothing
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim dt As DataTable
            Dim strTabla As String = ""
            Dim strCondicion As String = ""
            Dim objConexion As objCon
            Dim tmpGrupo As String
            Dim tmptipadm As String
            Dim tmpcodigoexcep As String

            If (Not dtSet Is Nothing) Then

                If (Not IsDBNull(dtSet)) Then
                    Dim tblGeneral As DataTable = dtSet.Tables(0)

                    If tblGeneral.Rows.Count > 0 Then

                        formula = New FormulaProcedimData()
                        If Len(Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("fecha"))) > 0 Then
                            formula.fecha = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("fecha"))
                        Else
                            formula.fecha = Now
                        End If
                        'parametro para enviar por correo el reporte 
                        formula.tmpMail = 0
                        ''numero de solicitud
                        formula.Codadmision = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("codadmision"))
                        ''Informacion prestador
                        formula.sucursal = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("sucursal"))
                        formula.pagador = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("entidadAfilia"))
                        formula.CodInt = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("cod_interno"))
                        formula.nit = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("nit"))
                        formula.codigoRips = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("codigoRips"))
                        formula.direccion = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("direccion"))

                        formula.telefono = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("telefono"))
                        formula.dptoSucursal = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("dptoSucursal"))
                        formula.codDepSucursal = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("codDepSucursal"))
                        formula.ciudad = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("Ciudad"))
                        formula.codMunSucursal = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("CodMunSucursal"))

                        ''Informacion paciente
                        formula.primApe = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("pri_ape"))
                        formula.segApe = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("seg_ape"))
                        formula.priNom = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("Pri_Nom"))
                        formula.segNom = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("seg_nom"))
                        formula.tipDoc = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("destipdoc"))

                        formula.numDoc = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("numdoc"))
                        formula.fecNac = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("fec_nac"))
                        formula.dirPaciente = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("dirpaciente"))
                        formula.telPaciente = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("telpaciente"))
                        formula.codDep = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("coddep"))

                        formula.departamentoPac = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("departamentopac"))
                        formula.codMunPaciente = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("codmun"))
                        formula.municipioPac = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("municipiopac"))
                        formula.celular = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("celular"))
                        formula.eMail = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("email"))
                        'Cambio raelizado por Ing. Ricardo Mauricio Zaldúa C.
                        '2009-01-28
                        'Solicitado por Mauricio Forero 

                        'Cobertura en salud
                        If Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("Tip_entidad")) = "EPS" Then
                            formula.coberturaSalud = "Regimen Contributivo"
                        Else
                            If Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("Tip_entidad")) = "ARS" Then
                                formula.coberturaSalud = "Regimen Subsidiado"
                            Else
                                If Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("Tip_entidad")) = "PRE" Then
                                    formula.coberturaSalud = "Plan Adicional de Salud"
                                Else
                                    formula.coberturaSalud = "Otros"
                                End If
                            End If
                        End If

                        formula.causaExt = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("CausaExt"))
                        ''?Tipo de servicio solicitado
                        'Cambio raelizado por Ing. Ricardo Mauricio Zaldúa C.
                        '2009-01-28
                        'Solicitado por Mauricio Forero 
                        ''formula.tipServSolicitado = headerTable.Rows(0).Item("?????????")
                        If Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("TipServ")) = "1" Then
                            formula.tipServSolicitado = "Posterior a la atención inicial de urgencias"
                            formula.prioridadAtencion = ""
                        Else
                            formula.tipServSolicitado = "Servicios electivos"
                            If Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("Priori")) = "1" Then
                                formula.prioridadAtencion = "Prioritaria"
                            Else
                                formula.prioridadAtencion = "No prioritaria"
                            End If
                        End If
                        ''Justificacion
                        formula.justificacion_Salud = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("Justificacion"))
                        'Guia
                        formula.Guia_Salud = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("Guia"))

                        formula.admision = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("admision"))
                        formula.cama = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("cama"))
                        formula.emailDestinatario = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("EmailSucur"))
                        'Cambio raelizado por Ing. Ricardo Mauricio Zaldúa C.
                        '2009-01-28
                        'Solicitado por Mauricio Forero 
                        'medico quien informa
                        formula.Medico = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("nombremed"))

                        strTabla = "genmedsu AS a INNER JOIN genespec AS b ON a.especialidad = b.especialidad"
                        strCondicion = "(a.medico = '" & Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("numdocmed")) & "' ) AND (a.cod_pre_sgs = '" & objGeneral.Instancia.Prestador & "') AND (a.cod_sucur = '" & objGeneral.Instancia.Sucursal & "')"

                        dt = obj.EjecutarSQLConParametros(strTabla, objConexion, "b.descripcion", strCondicion)
                        If dt.Rows.Count > 0 Then
                            formula.CargoMed = dt.Rows(0).Item("descripcion").ToString()
                        End If

                        ''llenado del detalle
                        For Each detalle As DataRow In tblGeneral.Rows
                            Dim detailData As New DetailFormulaProcedData()
                            detailData.codigoCups = Me.ifIsDBNullReturnNull(detalle.Item("codcups"))
                            detailData.cantidad = Me.ifIsDBNullReturnNull(detalle.Item("cant"))
                            detailData.descripcion = Me.ifIsDBNullReturnNull(detalle.Item("des"))
                            'Cambio raelizado por Ing. Ricardo Mauricio Zaldúa C.
                            '2009-01-28
                            'Solicitado por Mauricio Forero 
                            'para seleccional el grupo para poder realizar el rompimiento de informe
                            tmpGrupo = Me.ifIsDBNullReturnNull(detalle.Item("cod"))
                            tmpGrupo = tmpGrupo.Substring(0, 5)
                            If tmpGrupo.Substring(0, 3) = "401" Then
                                detailData.Grupo = tmpGrupo.Substring(0, 3)
                            Else
                                detailData.Grupo = tmpGrupo
                            End If
                            formula.detalle.Add(detailData)
                            'cambio realizado por Ing. Ricardo Mauricio Zaldúa C.
                            'fecha 2009-03-03
                            'solicitado por Mauricio Forero
                            'Motivo para las admisiones E y P no enviar por correo codigos de procedimientos que se encuentran en la tabla temporal a_tempProcexcep
                            If formula.tmpMail = 0 Then                                
                                tmptipadm = Me.ifIsDBNullReturnNull(tblGeneral.Rows(0).Item("codadmision"))
                                If tmptipadm.Substring(0, 1) = "P" Or tmptipadm.Substring(0, 1) = "E" Then
                                    strCondicion = "(codigo = '" & Me.ifIsDBNullReturnNull(detalle.Item("cod")) & "' )"
                                    tmpcodigoexcep = obj.EjecutarSQLStrValor("carexpProc3047", objConexion, "Codigo", strCondicion)
                                    If Len(tmpcodigoexcep) > 0 Then
                                        formula.tmpMail = 1
                                    Else
                                        If tmpGrupo.Substring(0, 1) <> "3" Then
                                            formula.tmpMail = 1
                                        End If
                                    End If
                                End If
                            End If
                        Next
                        'cambio realizado por Ing. Ricardo Mauricio Zaldúa C.
                        'Fecha 2009-01-28
                        'se cambio la forma de llenar los diagnositcos en el reporte no se hace por una tabla sino por variables
                        'Solicitado por Mauricio Forero
                        ''llenado de diagnosticos
                        For i As Integer = 0 To dtSet.Tables(1).Rows.Count - 1
                            Dim diagnostico As DataRow = dtSet.Tables(1).Rows(i)
                            'Dim diagData As New DiagnFrmlProcedimData()
                            ''Definir el tipo del diagnostico
                            If (i = 0) Then
                                formula.codDiagnosticoPrin = Me.ifIsDBNullReturnNull(diagnostico.Item("CodDiagn"))
                                formula.desDiagnPrin = Me.ifIsDBNullReturnNull(diagnostico.Item("DesDiagn"))
                            End If
                            If (i = 1) Then
                                formula.codDiagnosticoRela1 = Me.ifIsDBNullReturnNull(diagnostico.Item("CodDiagn"))
                                formula.desDiagnRela1 = Me.ifIsDBNullReturnNull(diagnostico.Item("DesDiagn"))
                            End If
                            If (i = 2) Then
                                formula.codDiagnosticoRela2 = Me.ifIsDBNullReturnNull(diagnostico.Item("CodDiagn"))
                                formula.desDiagnRela2 = Me.ifIsDBNullReturnNull(diagnostico.Item("DesDiagn"))
                            End If
                            ''Solo se puede ingresar la cantidad maxima de diagnosticos permitidos
                            If (i = 3) Then
                                Exit For
                            End If
                        Next
                    End If
                End If
            End If
            Return formula
        End Function

        Private Function ifIsDBNullReturnNull(ByVal objValidate As Object) As Object
            If (IsDBNull(objValidate)) Then
                Return Nothing
            Else
                Return objValidate
            End If
        End Function

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class
End Namespace
