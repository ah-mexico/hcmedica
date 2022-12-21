Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales

'Public Class frmCancelaOrden
'    Private Sub frmCancelaOrden_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        Dim objDatos As New Sophia.HistoriaClinica.DAO.DAOGeneral
'        Dim dtDatos As New DataTable
'        Dim objConexion As Sophia.HistoriaClinica.DatosConexion.Conexion = Sophia.HistoriaClinica.DatosConexion.Conexion.Instancia
'    End Sub
'End Class

Public Class frmCancelaOrden

    Private Sub CancelaOrden_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TraerOrden()
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnCancelarSelec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarSelec.Click
        Try
            For i As Integer = 0 To dgvOrdenes.Rows.Count - 1

                Dim objConexion As Sophia.HistoriaClinica.DatosConexion.Conexion = Sophia.HistoriaClinica.DatosConexion.Conexion.Instancia
                Dim objG As objGeneral = objGeneral.Instancia
                Dim objP As objPaciente = objPaciente.Instancia
                Dim lError As Long

                Dim daoOrden As New DAOOrdenes()
                Dim NroOrden As String
                Dim GrupoOrden As String
                Dim cod_sucur As String
                Dim strPrioridadtmp As String
                Dim codigo_RIS As String
                Dim FechaOrden As Date
                Dim strJustificacion As String
                Dim sObservaciones As String
                Dim daoGeneral As New DAOGeneral
                Dim Agfa As String
                Dim strcodSucurAgfa As String
                Dim strEntidad As String
                Dim codigo_his As String
                Dim numPedido As Decimal
                Dim nombre_examen As String
                Dim CC_Origen As String
                Dim particularidades As String ''CCGUTIEREZ - OSI. 07/09/2020. Se agrega parametro "particularidades"
                Dim procedimientos As String

                If dgvOrdenes.Rows(i).Cells("Cancelar").Value = "True" Then
                    NroOrden = dgvOrdenes.Rows(i).Cells("ORC2_ORDERNUMBER").Value 'dgvOrdenes.Rows(i).Cells("NRO_ORDEN").Value
                    GrupoOrden = dgvOrdenes.Rows(i).Cells("ORC4_ORDERGROUP").Value 'dgvOrdenes.Rows(i).Cells("NRO_ORDEN").Value
                    cod_sucur = objG.Sucursal
                    strPrioridadtmp = dgvOrdenes.Rows(i).Cells("PRIORIDAD").Value
                    codigo_RIS = dgvOrdenes.Rows(i).Cells("CODIGO_RIS").Value
                    fechaOrden = dgvOrdenes.Rows(i).Cells("FECHA_ORDEN").Value
                    strJustificacion = IIf(IsDBNull(dgvOrdenes.Rows(i).Cells("JUSTIFICACION").Value), "", dgvOrdenes.Rows(i).Cells("JUSTIFICACION").Value)
                    sObservaciones = IIf(IsDBNull(dgvOrdenes.Rows(i).Cells("OBSERVACIONES").Value), "", dgvOrdenes.Rows(i).Cells("OBSERVACIONES").Value)
                    strEntidad = IIf(IsDBNull(dgvOrdenes.Rows(i).Cells("ENTIDAD").Value), "", dgvOrdenes.Rows(i).Cells("ENTIDAD").Value)
                    codigo_his = dgvOrdenes.Rows(i).Cells("PROCEDIM").Value
                    nombre_examen = dgvOrdenes.Rows(i).Cells("DESCRIPCION").Value
                    CC_Origen = dgvOrdenes.Rows(i).Cells("CC_ORIGEN").Value
                    numPedido = dgvOrdenes.Rows(i).Cells("PEDIDO").Value
                    ''//Se corrige el valor asignado en el contol. Caso # 60. Incidencias
                    particularidades = IIf(IsDBNull(dgvOrdenes.Rows(i).Cells("PARTICULARIDADES").Value), "", dgvOrdenes.Rows(i).Cells("PARTICULARIDADES").Value)
                    ''particularidades = dgvOrdenes.Rows(i).Cells("particularidades").Value ''CCGUTIEREZ - OSI. 07/09/2020. Se agrega parametro "particularidades"
                    ''CCGUTIEREZ - OSI. 28/06/2021. Se agrega parametro dr("procedimientos")
                    procedimientos = IIf(IsDBNull(dgvOrdenes.Rows(i).Cells("procedimientos").Value), "", dgvOrdenes.Rows(i).Cells("procedimientos").Value)

                    Agfa = daoGeneral.EjecutarSQLStrValor("gensucur (nolock)", objConexion, " agfa", " cod_sucur='" & objG.Instancia.Sucursal & "'")

                    If IIf(IsDBNull(Agfa), "N", Agfa) = "S" Then

                        ' se concatena la sucursal a la admision. Solicitud agfa proyecto orm herojas
                        strcodSucurAgfa = objG.Sucursal
                        If Len(strcodSucurAgfa) = 3 Then
                            strcodSucurAgfa = "0" & strcodSucurAgfa
                        End If
                        ' se le agregan los parametros tipo, año y numero de admision herojas 2015/02/11
                        ''CCGUTIEREZ - OSI. 07/09/2020. Se agrega parametro "particularidades"
                        ''CCGUTIEREZ - OSI. 28/06/2021. Se agrega parametro dr("procedimientos")
                        lError = daoOrden.guardarOrdenesAGFA(objConexion, "N", FuncionesGenerales.FechaServidor(),
                                     objP.TipoDocumento & objP.NumeroDocumento,
                                     objP.PrimerNombre, objP.PrimerApellido, objP.FechaNacimiento,
                                     objP.Genero, "", objP.TipoAdmision, objP.TipoAdmision & objP.AnoAdmision &
                                     objP.NumeroAdmision & "-" & strcodSucurAgfa, NroOrden, cod_sucur, GrupoOrden,
                                     FuncionesGenerales.FechaServidor(), FuncionesGenerales.FechaServidor().AddDays(1), strPrioridadtmp, objG.Login,
                                     objG.Login, 1, codigo_RIS, nombre_examen, FechaOrden, strJustificacion, sObservaciones, CC_Origen, "",
                                     numPedido, objG.Sucursal, objG.Prestador, strEntidad, codigo_his, objG.NombreMedico,
                                     objP.AnoAdmision, objP.NumeroAdmision, particularidades, procedimientos)
                    End If
                End If
            Next
            MessageBox.Show("Cancelados Exitosamente!")
            TraerOrden()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

    Private Sub TraerOrden()
        Dim objDatos As New Sophia.HistoriaClinica.DAO.DAOGeneral
        Dim dtDatos As New DataTable
        Dim objConexion As Sophia.HistoriaClinica.DatosConexion.Conexion = Sophia.HistoriaClinica.DatosConexion.Conexion.Instancia
        Dim pacienteHC As objPaciente = objPaciente.Instancia()
        Dim sSql As String = "HC_LeerOrdenesMedicas"
        Dim lError As Long

        Try
            dtDatos.Clear()
            dgvOrdenes.DataSource = dtDatos
            dgvOrdenes.Refresh()
            dtDatos = objDatos.EjecutarSPConParametros(sSql, objConexion, lError, objGeneral.Instancia.Prestador, objGeneral.Instancia.Sucursal, _
                    pacienteHC.TipoAdmision, pacienteHC.AnoAdmision, pacienteHC.NumeroAdmision, _
                    pacienteHC.TipoDocumento & pacienteHC.NumeroDocumento, lError)

            dgvOrdenes.DataSource = dtDatos
            dgvOrdenes.Columns.Item("tip_admision").Visible = False
            dgvOrdenes.Columns.Item("num_adm").Visible = False
            dgvOrdenes.Columns.Item("ano_adm").Visible = False
            dgvOrdenes.Columns.Item("ENTIDAD").Visible = False
            dgvOrdenes.Columns.Item("PEDIDO").Visible = False
            dgvOrdenes.Columns.Item("PV119_ADMIN_NUMB").Visible = False
            dgvOrdenes.Columns.Item("ORC2_ORDERNUMBER").Visible = False
            dgvOrdenes.Columns.Item("PROCEDIM").Visible = False
            dgvOrdenes.Columns.Item("CODIGO_RIS").Visible = False
            dgvOrdenes.Columns.Item("PRIORIDAD").Visible = False
            dgvOrdenes.Columns.Item("JUSTIFICACION").Visible = False
            dgvOrdenes.Columns.Item("OBSERVACIONES").Visible = False
            dgvOrdenes.Columns.Item("CC_ORIGEN").Visible = False
            dgvOrdenes.Columns.Item("MEDICO").Visible = False
            dgvOrdenes.Columns.Item("ORC4_ORDERGROUP").Visible = False
            dgvOrdenes.Columns.Item("ORC25_ORDERSTATUS").Visible = False
            ''//Se oculta la columna del control. Caso #60 Incidencias
            dgvOrdenes.Columns.Item("PARTICULARIDADES").Visible = False

            dgvOrdenes.Columns.Item("CANCELAR").Width = 60
            dgvOrdenes.Columns.Item("FECHA_ORDEN").Width = 130
            dgvOrdenes.Columns.Item("NRO_ORDEN").Width = 60
            dgvOrdenes.Columns.Item("DESCRIPCION").Width = 185
            dgvOrdenes.Columns.Item("NOMBREMEDICO").Width = 185

            dgvOrdenes.Columns.Item("CANCELAR").HeaderText = "Cancelar"
            dgvOrdenes.Columns.Item("FECHA_ORDEN").HeaderText = "Fecha Orden"
            dgvOrdenes.Columns.Item("NRO_ORDEN").HeaderText = "No.Orden"
            dgvOrdenes.Columns.Item("DESCRIPCION").HeaderText = "Descripción"
            dgvOrdenes.Columns.Item("NOMBREMEDICO").HeaderText = "Medico"
            dgvOrdenes.Update()
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
    End Sub

End Class