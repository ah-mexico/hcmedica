Imports System
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales

Namespace Sophia.HistoriaClinica.DAO
    Public Class DAODescripcionQX
        Inherits GPMData
        Public objDatosGenerales As objGeneral.Generales

        Public Function ConsultarDescripcionQX(ByVal cod_pre_sgs As String, ByVal cod_sucur As String, ByVal tip_doc As String,
        ByVal num_doc As String, ByVal tip_admision As String, ByVal ano_adm As Integer, ByVal num_adm As Decimal) As DataSet
            Dim ds As New DataSet


            Me.setSQLSentence("HCDescripcionQX_TraerCirugiaXDoc", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, cod_sucur)
            Me.addInputParameter("tip_doc", SqlDbType.VarChar, tip_doc)
            Me.addInputParameter("num_doc", SqlDbType.Int, num_doc)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("num_adm", SqlDbType.Decimal, num_adm)
            ds = Me.execDS()

            Return ds
        End Function
        'martovar 2014-08-08 Req. 03 Descripcion Quirurgica version 2.9.0 2014-08-08
        Public Function ConsultarProcedimientosXAdmision(ByVal cod_pre_sgs As String, ByVal cod_sucur As String, ByVal tip_doc As String,
               ByVal num_doc As String, ByVal tip_admision As String, ByVal ano_adm As Integer, ByVal num_adm As Decimal, ByVal strConsulta As Integer) As DataTable

            'Public Function ConsultarProcedimientosXAdmision(ByVal cod_pre_sgs As String, ByVal cod_sucur As String, ByVal tip_doc As String, _
            'ByVal num_doc As String, ByVal tip_admision As String, ByVal ano_adm As Integer, ByVal num_adm As Decimal) As DataTable
            Dim dt As New DataTable

            Dim OrigenBD As String
            objDatosGenerales = objGeneral.Generales.Instancia

            OrigenBD = objDatosGenerales.OrigenAdm


            Me.setSQLSentence("Exec " + OrigenBD + "HCDescripcionQX_TraerProcedimientos " + "'" +
                                      cod_pre_sgs + "'" + "," + "'" + cod_sucur + "'" +
                                      "," + "'" + tip_doc + "'" + "," + "'" + num_doc + "'" + "," +
                                      "'" + tip_admision + "'" + "," + "'" + CStr(ano_adm) + "'" + "," + "'" +
                                      CStr(num_adm) + "'" + "," + "'" + CStr(strConsulta) + "'" + "", CommandType.Text)


            'Me.setSQLSentence("HCDescripcionQX_TraerProcedimientos", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, cod_sucur)
            Me.addInputParameter("tip_doc", SqlDbType.VarChar, tip_doc)
            Me.addInputParameter("num_doc", SqlDbType.VarChar, num_doc)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("num_adm", SqlDbType.Decimal, num_adm)
            Me.addInputParameter("strconsulta", SqlDbType.Int, strConsulta)
            dt = Me.execDT()


            Return dt
        End Function

        Public Function ConsultarDetalleProcedimientosXAdmision(ByVal cod_pre_sgs As String, ByVal cod_sucur As String,
        ByVal consecutivo As Decimal, ByVal procedimiento As String) As DataSet
            Dim ds As New DataSet


            Me.setSQLSentence("HCDescripcionQX_TraerDetalleProcedimiento", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, cod_sucur)
            Me.addInputParameter("consecutivo", SqlDbType.Decimal, consecutivo)
            Me.addInputParameter("procedim", SqlDbType.VarChar, procedimiento)

            ds = Me.execDS()

            Return ds
        End Function


        Public Function ConsultarOrdenPatologia(ByVal cod_pre_sgs As String, ByVal cod_sucur As String,
ByVal consecutivo As Decimal, ByVal procedimiento As String, ByVal tip_admision As String, ByVal ano_adm As Integer, ByVal num_adm As Decimal) As DataSet
            Dim ds As New DataSet


            Me.setSQLSentence("HCDescripcionQX_TraerOrdenPatologia", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, cod_pre_sgs)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, cod_sucur)
            Me.addInputParameter("consecutivo", SqlDbType.Decimal, consecutivo)
            Me.addInputParameter("procedim", SqlDbType.VarChar, procedimiento)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("num_adm", SqlDbType.Decimal, num_adm)

            ds = Me.execDS()

            Return ds
        End Function

        Public Function CargarCombosDescQX(ByVal intopcion As Integer, Optional ByVal strmedico As String = "",
        Optional ByVal strPrestador As String = "", Optional ByVal strSucursal As String = "") As DataTable
            Dim dt As New DataTable


            Select Case intopcion
                Case 1 'Tipo de profesional
                    Me.setSQLSentence("DB_TraerInfoTipoEmpleadoTodos", CommandType.StoredProcedure)
                    Me.ClearParameters()
                Case 2 'Especialidades
                    Me.setSQLSentence("DB_TraerEspecialidadMedico", CommandType.StoredProcedure)
                    Me.ClearParameters()
                    Me.addInputParameter("strmedico", SqlDbType.VarChar, strmedico)
                Case 3 'Especialidades Todas
                    Me.setSQLSentence("DB_TraerInfoEspecialidad", CommandType.StoredProcedure)
                    Me.ClearParameters()
                    Me.addInputParameter("especialidad ", SqlDbType.VarChar, "")
                    Me.addInputParameter("descripcion", SqlDbType.VarChar, "")
                Case 4 'Tipos de Anestesia
                    Me.setSQLSentence("HCDescripcionQX_TraerTipoAnestesia", CommandType.StoredProcedure)
                    Me.ClearParameters()
                Case 5 'Tipo de Cirugia
                    Me.setSQLSentence("HCDescripcionQX_Traergentielimsucur", CommandType.StoredProcedure)
                    Me.ClearParameters()
                    Me.addInputParameter("cod_pre_sgs ", SqlDbType.VarChar, strPrestador)
                    Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strSucursal)

            End Select

            dt = Me.execDT
            Return dt
        End Function

        Public Function ConsultaMedicoXDoc(ByVal strCodigomedico As String) As String
            Dim dt As New DataTable

            Me.setSQLSentence("DB_TraerInfoMedico", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("strmedico", SqlDbType.VarChar, strCodigomedico)

            dt = execDT()

            If dt.Rows.Count > 0 Then

                Return dt.Rows(0).Item("pri_ape").ToString & " " & IIf(IsDBNull(dt.Rows(0).Item("seg_ape").ToString), "", dt.Rows(0).Item("seg_ape").ToString) _
                & " " & dt.Rows(0).Item("pri_nom").ToString & " " & IIf(IsDBNull(dt.Rows(0).Item("seg_nom").ToString), "", dt.Rows(0).Item("seg_nom").ToString)
            Else
                Return ""
            End If

        End Function

        Public Function ConsultaMedicoXDoc1(ByVal strCodigomedico As String) As DataTable
            Dim dt As New DataTable

            Me.setSQLSentence("DB_TraerInfoMedico", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("strmedico", SqlDbType.VarChar, strCodigomedico)

            dt = execDT()


            Return dt

        End Function

        Public Function ConsultaDatosReporteDescQx(ByVal strPrestador As String, ByVal strsucursal As String, ByVal strProcedim As String, ByVal Consecutivo As Decimal, ByVal secuencia As Integer,
        Optional ByVal strTipAdmision As String = "", Optional ByVal ianoAdm As Integer = 0, Optional ByVal num_adm As Decimal = 0,
        Optional ByVal strTip_Doc As String = "", Optional ByVal strNum_Doc As String = "") As DataSet

            Dim ds As DataSet
            'Optional ByVal fec_ini As String = ""
            Me.setSQLSentence("HCDescripcionQX_Reporte", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strPrestador)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strsucursal)
            Me.addInputParameter("procedim", SqlDbType.VarChar, strProcedim)
            Me.addInputParameter("consecutivo", SqlDbType.Decimal, Consecutivo)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, strTipAdmision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ianoAdm)
            Me.addInputParameter("num_adm", SqlDbType.Decimal, num_adm)
            Me.addInputParameter("tip_doc", SqlDbType.VarChar, strTip_Doc)
            Me.addInputParameter("num_doc", SqlDbType.VarChar, strNum_Doc)
            Me.addInputParameter("secuencia", SqlDbType.Int, secuencia)
            ds = Me.execDS

            Return ds
        End Function

        Public Function ConsultaDatosOrdenPatologia(ByVal strPrestador As String, ByVal strsucursal As String, ByVal strProcedim As String, ByVal Consecutivo As Decimal,
     Optional ByVal strTipAdmision As String = "", Optional ByVal ianoAdm As Integer = 0, Optional ByVal num_adm As Decimal = 0,
     Optional ByVal strTip_Doc As String = "", Optional ByVal strNum_Doc As String = "") As DataSet

            Dim ds As DataSet
            'Optional ByVal fec_ini As String = ""
            Me.setSQLSentence("HCOrdenPatologia_Reporte", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strPrestador)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strsucursal)
            Me.addInputParameter("procedim", SqlDbType.VarChar, strProcedim)
            Me.addInputParameter("consecutivo", SqlDbType.Decimal, Consecutivo)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, strTipAdmision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ianoAdm)
            Me.addInputParameter("num_adm", SqlDbType.Decimal, num_adm)
            Me.addInputParameter("tip_doc", SqlDbType.VarChar, strTip_Doc)
            Me.addInputParameter("num_doc", SqlDbType.VarChar, strNum_Doc)
            ds = Me.execDS

            Return ds
        End Function

        Public Function ConsultarSeccion() As DataTable
            Dim ds As New DataTable


            Me.setSQLSentence("HC_Traerseccion", CommandType.StoredProcedure)
            Me.ClearParameters()
            ds = Me.execDT
            Return ds
        End Function

        Public Function ConsultarMuestra() As DataTable
            Dim ds As New DataTable


            Me.setSQLSentence("HC_TraerMuestra", CommandType.StoredProcedure)
            Me.ClearParameters()
            ds = Me.execDT
            Return ds
        End Function


    End Class
End Namespace