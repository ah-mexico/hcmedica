Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales

Namespace Sophia.HistoriaClinica.BL

    ''' -----------------------------------------------------------------------------
    ''' Project	 : HistoriClinica.BL.BLBasicasLocales
    ''' Class	 : Sophia.HistoriaClinica.BL.BLBasicasGenerales
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Clase BLBasicasGenerales del namespace Sophia.HistoriaClinica.BL
    ''' que es la clase data de HistoriaClinica.BL
    ''' y será usada desde la aplicación WinForms 2005
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[ggarzon]	05/04/2006	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------

    Public Class BLBasicasGenerales
        '// Traer consulta Sql y retornar String
        Public Function TraerConsultaSql(ByVal objConexion As objCon, ByVal strTabla As String, ByVal strCampos As String, ByVal strCondicion As String) As String
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral

            Return obj.EjecutarSQLStrValor(strTabla, objConexion, strCampos, strCondicion)
        End Function

        Public Function ConsultarDescripcionItemPorCodigo(ByVal objConexion As objCon, ByVal intCategoria As CategoriaDatos, ByVal strValue As String, _
                                                          Optional ByVal strEntidadManejaConvenio As String = "", Optional ByVal strSucursal As String = "", _
                                                          Optional ByVal strEntidad As String = "", Optional ByVal strPrestador As String = "") As String
            Dim strTabla As String = ""
            Dim strNombreCampoCodigo As String = ""
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim strDescripcion As String = ""
            Dim dt As DataTable
            Dim strDescFormaFarm As String = ""
            Dim strCondicion As String = ""
            Dim strCampos As String = "descripcion"

            Select Case intCategoria
                Case CategoriaDatos.Diagnosticos
                    strTabla = "Gendiagn"
                    strNombreCampoCodigo = "diagnost"
                Case CategoriaDatos.Procedimientos
                    strTabla = "Genproce"
                    strNombreCampoCodigo = "procedim"
                'Case CategoriaDatos.Procedimientos
                '    'strTabla = "Genproce"
                '    '--Joseph G. Moreno Campos (IG) Fec:2018/12/05 cambio tabla Genproce -> VW_GENPROCE_DES Proy:Codificación
                '    strTabla = "VW_GENPROCE_DES"
                '    strNombreCampoCodigo = "procedim"
                '    strCondicion = String.Format(" AND CONVERT(DATE, '{0}') BETWEEN fec_ini_proce AND fec_fin_proce ", DateTime.Now)
                Case CategoriaDatos.Productos
                    strTabla = "Genprodu"
                    strNombreCampoCodigo = "cod_corto"
                    'Case CategoriaDatos.ProductosConvenio
                    '    strTabla = "Genprodu"
                    '    strNombreCampoCodigo = "cod_corto"
                Case CategoriaDatos.ProductosConvenio
                    If strEntidadManejaConvenio = "S" Then
                        strTabla = "Genconvemed"
                        strNombreCampoCodigo = "producto"
                        ''Se quita parametro de sucursal
                        ''29/01/2010 
                        ''Claudia Patricia Garay Guerrero
                        strCondicion = " AND cod_pre_sgs='" & strPrestador & "' AND entidad='" & strEntidad & "'"
                    Else
                        strTabla = "Genprodu"
                        strNombreCampoCodigo = "cod_corto"
                        'strCampos = "descripcion = case when len(des_generico)> 1 then des_generico else descripcion end " 'descripcion = case when des_generico is null then descripcion	else des_generico end

                        ''Insertado por Claudia Garay para traer la descripcion correcta del medicamento
                        '' 24 Agosto 2009
                        strCampos = "descripcion = case when len(descripcion_pa)> 1 then descripcion_pa else descripcion end " 'descripcion = case when des_generico is null then descripcion	else des_generico end
                    End If
            End Select

            'dt = obj.EjecutarSQLConParametros(strTabla, objConexion, "descripcion" & IIf(intCategoria = CategoriaDatos.ProductosConvenio, ", des_generico, des_corta, concentracion, for_farma", ""), strNombreCampoCodigo & "='" & strValue & "'")

            dt = obj.EjecutarSQLConParametros(strTabla, objConexion, strCampos, strNombreCampoCodigo & "='" & strValue & "'" & strCondicion)

            'If dt.Rows.Count > 0 Then
            '    If intCategoria = CategoriaDatos.ProductosConvenio Then
            '        If strCodSucur = "0138" Or strCodSucur = "0139" Then
            '            dtFormaFarm = obj.EjecutarSQLConParametros("genforfarma", objConexion, "descripcion", "for_farma" & "='" & dt.Rows(0).Item("for_farma").ToString & "'")
            '            If dtFormaFarm.Rows.Count > 0 Then
            '                strDescFormaFarm = dtFormaFarm.Rows(0).Item("descripcion").ToString.Trim.ToUpper
            '            End If
            '            If dt.Rows(0).Item("des_generico").ToString.Trim.Length = 0 Then
            '                strDescripcion = dt.Rows(0).Item("descripcion").ToString.Trim.ToUpper
            '            ElseIf dt.Rows(0).Item("des_corta").ToString.Trim.Length > 0 Then
            '                strDescripcion = dt.Rows(0).Item("des_generico").ToString.Trim.ToUpper & " " & strDescFormaFarm & " " & dt.Rows(0).Item("concentracion").ToString.Trim & " (" & dt.Rows(0).Item("des_corta").ToString.Trim.ToUpper & ")"
            '            ElseIf dt.Rows(0).Item("des_corta").ToString.Trim.Length = 0 Then
            '                strDescripcion = dt.Rows(0).Item("des_generico").ToString.Trim & " " & strDescFormaFarm & " " & dt.Rows(0).Item("concentracion").ToString.Trim
            '            End If
            '        Else
            '            strDescripcion = dt.Rows(0).Item("descripcion").ToString()
            '        End If
            '    Else
            '        strDescripcion = dt.Rows(0).Item("descripcion").ToString()
            '    End If

            'End If

            If dt.Rows.Count > 0 Then
                strDescripcion = dt.Rows(0).Item("descripcion").ToString()
            End If


            Return strDescripcion

        End Function

        Public Function ConsultarMedicoPuertaEntrada(ByVal objConexion As objCon, ByVal strCod_pre_sgs As String, _
                                     ByVal strCod_sucur As String, ByVal strEntidad As String, ByVal strMedico As String, _
                                     ByRef lError As Long) As String
            Dim dtDatos As DataTable
            Dim objDAOGeneral As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim strRespuesta As String
            Dim OrigenBD As String
            Dim objDatosGenerales As objGeneral.Generales
            objDatosGenerales = objGeneral.Generales.Instancia

            OrigenBD = objDatosGenerales.OrigenAdm
            strRespuesta = ""

            dtDatos = objDAOGeneral.EjecutarSQLConParametros(OrigenBD & "genmedsuent", objConexion, "med_familiar",
                        "cod_pre_sgs='" & strCod_pre_sgs & "' AND cod_sucur='" & strCod_sucur & "' AND entidad='" & strEntidad &
                        "' AND medico='" & strMedico & "'")

            If dtDatos.Rows.Count > 0 Then
                strRespuesta = dtDatos.Rows(0).Item("med_familiar").ToString
            End If

            Return strRespuesta
        End Function

        'llarias creada para consultar la especialidad del médico
        Public Function ConsultarEspecialidad(ByVal objConexion As objCon, ByVal codEspec As String, ByRef lError As Long) As String
            Dim dtDatos As DataTable
            Dim objDAOGeneral As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim strRespuesta As String
            Dim _objDatosGenerales As objGeneral.Generales
            Dim OrigenBD As String
            _objDatosGenerales = objGeneral.Generales.Instancia

            OrigenBD = _objDatosGenerales.OrigenAdm
            strRespuesta = ""

            dtDatos = objDAOGeneral.EjecutarSQLConParametros(OrigenBD & "genespec", objConexion, "descripcion",
                        "especialidad='" & codEspec & "'")

            If dtDatos.Rows.Count > 0 Then
                strRespuesta = dtDatos.Rows(0).Item("descripcion").ToString

            End If

            Return strRespuesta



        End Function

        'Martovar Manejo de errores 2017/12/05
        Public Function NErroresHC(ByVal objConexion As objCon, ByRef lError As Long, ByVal ParamArray Datos() As Object) As Long
            Dim objDAOGeneral As New Sophia.HistoriaClinica.DAO.DAOGeneral
            lError = objDAOGeneral.EjecutarSPConParametrosTran("HC_GrabarGenerror", objConexion, Datos)
            Return lError
        End Function

    End Class


End Namespace
