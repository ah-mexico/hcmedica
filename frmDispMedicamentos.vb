Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports System.Text.RegularExpressions
Imports System.Collections.Generic
Imports System.Data.Common
Imports gpm_crypto


Public Class frmDispMedicamentos
    ' Private Shared _Instancia As frmc_ConsultaMedicoQx
    Private objConexion As Conexion

    Private Const cSOAPID As String = _
        "<soapenv:Envelope xmlns:soapenv=""http://schemas.xmlsoap.org/soap/envelope/"" xmlns:ejb=""http://ejb.control.osi.com/"">" & _
        "<soapenv:Header/>" & _
        "<soapenv:Body>" & _
        "	<ejb1:consultarEntregas xmlns:ejb1=""http://ejb.business.control.osi.com/"">" & _
        "   <tipoId>String</tipoId>" & _
        "   <numeroId>String</numeroId>" & _
        "</ejb1:consultarEntregas>" & _
        "</soapenv:Body>" & _
        "</soapenv:Envelope>"

    Private m_NumDoc As String
    Private m_TipDoc As String

#Region "Load"
    Private Sub frmDispMedicamentos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strTrama As String
        Dim rsMedEntre As New DataTable
        Dim rsMedFutu As New DataTable
        objConexion = Conexion.Instancia
        Dim objDao As New DAOHistoriaBasica
        Dim lError As Long
        Dim rsTipDoc As DataTable

        Try
            rsTipDoc = objDao.CargarTipDocAlias(objConexion, m_TipDoc, lError)
            'strTrama = Consulta_JWS_Dispensacion("C", "51902085", 0)
            If rsTipDoc.Rows.Count > 0 Then
                strTrama = Consulta_JWS_Dispensacion(rsTipDoc.Rows(0).Item("alias_dispen"), m_NumDoc, 0) '"51902085"
                If Len(strTrama) = 0 Then
                    MsgBox("En este momento la consulta de dispensación de medicamentos no se encuentra disponible") ''cpgaray
                    'MessageBox.Show("El Web Service consultarEntregas no retorna datos.")
                    Me.Close()
                Else
                    rsMedEntre = InterpretarRespuestas_JWS_MedEntre(strTrama)
                    rsMedFutu = InterpretarRespuestas_JWS_MedFutu(strTrama)
                    If rsMedEntre.Rows.Count = 0 And rsMedFutu.Rows.Count = 0 Then
                        MessageBox.Show("El paciente consultado no tiene medicamentos dispensados durante los últimos treinta (30) días")
                        Me.Close()
                    Else
                        Me.dtgDespachadas.DataSource = rsMedEntre
                        Me.dtgFuTuras.DataSource = rsMedFutu
                    End If
                End If
            End If
        Catch ex As Exception
            'MessageBox.Show("El proceso de mostrar información de dispensación de Medicamentos falló por: " & ex.Message, "Historia Clínica")
            MsgBox("En este momento la consulta de dispensación de medicamentos no se encuentra disponible" & ex.Message, MsgBoxStyle.Information) ''cpgaray
        End Try
    End Sub

    Public Sub mostrar(ByVal strTip_doc As String, ByVal strNum_doc As String)
        If strTip_doc.Trim.Length > 0 And strNum_doc.Trim.Length > 0 Then
            m_TipDoc = strTip_doc
            m_NumDoc = strNum_doc
        End If
        Me.ShowDialog()
    End Sub
#End Region

#Region "Consumir Web Service"
    Public Function Consulta_JWS_Dispensacion(ByVal iID As String, ByVal iDoc As String, Optional ByRef o_lError As Long = 0) As String

        Dim vObjeto As Object
        Dim objDOM As MSXML2.DOMDocument30
        Dim oHttReq As MSXML2.XMLHTTP
        Dim objDao As New DAOHistoriaBasica
        Dim rsServicio As New DataTable
        objConexion = Conexion.Instancia
        Dim lError As Long
        Dim xmlDatos As String
        Dim url As String

        xmlDatos = ""
        Try
            rsServicio = objDao.CargarServicio(objConexion, "FO", "consultarEntregas", lError)

            If rsServicio.Rows.Count = 0 Then
                MsgBox("No existe la parametrización del servicio solicitado", MsgBoxStyle.Information)
            End If

            objDOM = New MSXML2.DOMDocument30

            ' CARGA CODIGO SOAP PARA CONSULTAR POR TIPO DE DOCUMENTO Y NÚMERO DE DOCUMENTO
            objDOM.loadXML(cSOAPID)


            objDOM.selectSingleNode("/soapenv:Envelope/soapenv:Body/ejb1:consultarEntregas/tipoId").text = CStr(iID)
            objDOM.selectSingleNode("/soapenv:Envelope/soapenv:Body/ejb1:consultarEntregas/numeroId").text = CStr(iDoc)

            ' Enviar el comando al Web Service
            oHttReq = New MSXML2.XMLHTTP

            url = "http://" & Trim(rsServicio.Rows(0).Item("Servidor")) & ":" & Trim(rsServicio.Rows(0).Item("PuertoSOAP")) & "/" & Trim(rsServicio.Rows(0).Item("Servicio"))

            oHttReq.open("POST", url, False)

            'las cabeceras a enviar al servicio Web
            '(no incluir los dos puntos en el nombre de la cabecera)
            oHttReq.setRequestHeader("Content-Type", "text/xml; charset=utf-8")
            oHttReq.setRequestHeader("SOAPAction", url)

            'Enviar el comando al Web Service
            oHttReq.send(objDOM.xml)

            'Este será el texto recibido del Web Service
            vObjeto = oHttReq.responseXML

            'Pasa y valida el NODO en XML
            If Not vObjeto.selectSingleNode("env:Envelope/env:Body/env:Fault") Is Nothing Then
                MsgBox(vObjeto.selectSingleNode("env:Envelope/env:Body/env:Fault/faultstring").Text, vbCritical)
            ElseIf Not vObjeto.selectSingleNode("env:Envelope/env:Body/ns2:consultarEntregasResponse") Is Nothing Then
                xmlDatos = vObjeto.selectSingleNode("env:Envelope/env:Body/ns2:consultarEntregasResponse").xml
            End If

        Catch ex As Exception
            MsgBox("En este momento la consulta de dispensación de medicamentos no se encuentra disponible" & ex.Message, MsgBoxStyle.Information) ''cpgaray
            'MessageBox.Show("El proceso de mostrar información de dispensación de Medicamentos falló por: " & ex.Message, "Historia Clínica")
            Consulta_JWS_Dispensacion = ""
            Exit Function
        End Try
        Consulta_JWS_Dispensacion = xmlDatos
    End Function
#End Region

#Region "Interpretar Respuesta y Mostrar en Grid"
    Private Function InterpretarRespuestas_JWS_MedEntre(ByVal strXML As String) As DataTable

        Dim rsDespachadas As New DataTable

        Dim objDOM As MSXML2.DOMDocument30
        Dim oNode As MSXML2.IXMLDOMElement
        Dim iCC As Integer
        Dim iCU As Integer
        Dim iCD As Integer
        Dim iCF As Integer
        Dim lstNodeC As MSXML2.IXMLDOMNodeList
        Dim encripta As Object 

        '        strXML = "<ns2:consultarEntregasResponse xmlns:ns2=""http://ejb.control.osi.com/""><return><incidencias>0</incidencias><nombreAfiliado>JULIAN ALBERTO DURAN </nombreAfiliado>" & _
        '"<numeroIdentificacion>86039922</numeroIdentificacion><producto><ATCProductoPedido>M01AD01502230000860022139</ATCProductoPedido><codigoProductoPedido>17378</codigoProductoPedido>" & _
        '"<entrega><cantidadPedida>0</cantidadPedida><cantidadPendiente>9</cantidadPendiente><documento>0093 - 37345</documento><estado>Pendiente</estado><fechaEntrega>28-FEB-12</fechaEntrega>" & _
        '"<id>1</id><idProducto>1</idProducto><identificacionMedico>30081914</identificacionMedico><medicoPrestador>LINA MARIA GARCIA EUSSE</medicoPrestador>" & _
        '"<nombreUnidadPendiente>TABLETA</nombreUnidadPendiente><numeroEntrega>1</numeroEntrega><presentacion>CAJA X ALGO</presentacion><unidadPendiente>21</unidadPendiente></entrega>" & _
        '"<entrega><cantidadPedida>0</cantidadPedida><cantidadPendiente>0</cantidadPendiente><despacho><ATCProductoDespachado>A11CC00310110000802006279</ATCProductoDespachado>" & _
        '"<cantidadDespachada>1</cantidadDespachada><codigoProductoDespachado>17378</codigoProductoDespachado><contrato>0300100000965409000101</contrato><fechaDespacho>01/03/2012</fechaDespacho>" & _
        '"<id>1</id><idEntrega>2</idEntrega><nombreProductoDespachado>DICLOFENAC 50MG GRAG GENFAR CAJ X 30</nombreProductoDespachado><nombreUnidadDespachada>TABLETA</nombreUnidadDespachada>" & _
        '"<presentacion>CAJA POR ALGO</presentacion><unidadDespachada>21</unidadDespachada></despacho><documento>0093-37345</documento><estado>Entregada</estado>" & _
        '"<fechaEntrega>05/03/2012 16:25:14</fechaEntrega><id>2</id><idProducto>1</idProducto><identificacionMedico>30081914</identificacionMedico><medicoPrestador>LINA MARIA GARCIA EUSSE</medicoPrestador>" & _
        '"<nombreUnidadPendiente></nombreUnidadPendiente><numeroEntrega>0</numeroEntrega><presentacion></presentacion><unidadPendiente></unidadPendiente></entrega>" & _
        '"<entrega><cantidadPedida>10</cantidadPedida><cantidadPendiente>8</cantidadPendiente><despacho><ATCProductoDespachado>A11CC00310110000802006279</ATCProductoDespachado>" & _
        '"<cantidadDespachada>2</cantidadDespachada><codigoProductoDespachado>17378</codigoProductoDespachado><contrato>0300100000965409000101</contrato><fechaDespacho>03/03/2012</fechaDespacho>" & _
        '"<id>1</id><idEntrega>2</idEntrega><nombreProductoDespachado>DICLOFENAC 50MG GRAG GENFAR CAJ X 30</nombreProductoDespachado><nombreUnidadDespachada>TABLETA</nombreUnidadDespachada>" & _
        '"<presentacion>CAJA POR ALGO</presentacion><unidadDespachada>21</unidadDespachada></despacho><documento>0093-37345</documento><estado>Pendiente</estado>" & _
        '"<fechaEntrega>05/03/2012 16:25:14</fechaEntrega><id>2</id><idProducto>1</idProducto><identificacionMedico>30081914</identificacionMedico><medicoPrestador>LINA MARIA GARCIA EUSSE</medicoPrestador>" & _
        '"<nombreUnidadPendiente></nombreUnidadPendiente><numeroEntrega>0</numeroEntrega><presentacion></presentacion><unidadPendiente></unidadPendiente></entrega><idProducto>1</idProducto>" & _
        '"<nombreProductoPedido>DICLOFENAC 50MG GRAG GENFAR CAJ X 30</nombreProductoPedido></producto><producto><ATCProductoPedido>S01AG00361111000830121423</ATCProductoPedido><codigoProductoPedido>78523</codigoProductoPedido>" & _
        '"<entrega><cantidadPedida>0</cantidadPedida><cantidadPendiente>1</cantidadPendiente><documento>0093 - 37345</documento>" & _
        '"<estado>Pendiente</estado><fechaEntrega>28-FEB-12</fechaEntrega><id>3</id><idProducto>2</idProducto><identificacionMedico>30081914</identificacionMedico>" & _
        '"<medicoPrestador>LINA MARIA GARCIA EUSSE</medicoPrestador><nombreUnidadPendiente>TABLETA</nombreUnidadPendiente><numeroEntrega>1</numeroEntrega><presentacion>CAJA X ALGO</presentacion>" & _
        '"<unidadPendiente>43</unidadPendiente></entrega><entrega><cantidadPedida>15</cantidadPedida><cantidadPendiente>15</cantidadPendiente><documento>0093 - 37345</documento>" & _
        '"<estado>Futura</estado><fechaEntrega>28-MAR-12</fechaEntrega><id>3</id><idProducto>2</idProducto><identificacionMedico>30081914</identificacionMedico>" & _
        '"<medicoPrestador>LINA MARIA GARCIA EUSSE</medicoPrestador><nombreUnidadPendiente>TABLETA</nombreUnidadPendiente><numeroEntrega>1</numeroEntrega><presentacion>CAJA X ALGO</presentacion>" & _
        '"<unidadPendiente>43</unidadPendiente></entrega><entrega><cantidadPedida>30</cantidadPedida><cantidadPendiente>30</cantidadPendiente><documento>0093 - 37345</documento>" & _
        '"<estado>Futura</estado><fechaEntrega>18-MAR-12</fechaEntrega><id>3</id><idProducto>2</idProducto><identificacionMedico>30081914</identificacionMedico>" & _
        '"<medicoPrestador>LINA MARIA GARCIA EUSSE</medicoPrestador><nombreUnidadPendiente>TABLETA</nombreUnidadPendiente><numeroEntrega>1</numeroEntrega><presentacion>CAJA X ALGO</presentacion>" & _
        '"<unidadPendiente>43</unidadPendiente></entrega><idProducto>2</idProducto><nombreProductoPedido>PURPUCINA 0.3% UNG OFT TUB X 5GR</nombreProductoPedido></producto>" & _
        '"<tipoIdentificacion>C</tipoIdentificacion></return></ns2:consultarEntregasResponse>"

        objDOM = New MSXML2.DOMDocument30
        objDOM.async = False
        objDOM.loadXML(strXML)
        encripta = New gpm_crypto.clsOSICadenaSeg()

        rsDespachadas.Columns.Add("Fecha Dispensación", System.Type.GetType("System.String"))
        'rsDespachadas.Columns.Add("Estado", System.Type.GetType("System.String"))
        rsDespachadas.Columns.Add("Medicamento Dispensado / Pendiente", System.Type.GetType("System.String"))
        rsDespachadas.Columns.Add("Cantidad Despachada", System.Type.GetType("System.String"))
        rsDespachadas.Columns.Add("Unidad", System.Type.GetType("System.String"))
        rsDespachadas.Columns.Add("Cantidad Pendiente", System.Type.GetType("System.String"))
        Try
            oNode = objDOM.selectSingleNode("ns2:consultarEntregasResponse/return")

            lstNodeC = oNode.getElementsByTagName("producto")
            For iCC = 0 To lstNodeC.length - 1
                If Not oNode Is Nothing Then
                    If oNode.childNodes.length > 0 Then
                        For iCU = 0 To lstNodeC(iCC).childNodes.length - 1
                            Dim dtRow As DataRow = rsDespachadas.NewRow()
                            If lstNodeC(iCC).childNodes(iCU).nodeName = "entrega" Then
                                'dtRow("Estado") = lstNodeC(iCC).childNodes(iCU).selectSingleNode("estado").nodeTypedValue
                                If encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).selectSingleNode("estado").nodeTypedValue) = "Entregada" Then 'Entregada
                                    For iCD = 0 To lstNodeC(iCC).childNodes(iCU).childNodes.length - 1
                                        If lstNodeC(iCC).childNodes(iCU).childNodes(iCD).nodeName = "despacho" Then
                                            dtRow("Fecha Dispensación") = IIf(Len(Mid(encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).childNodes(iCD).selectSingleNode("fechaDespacho").nodeTypedValue), 1, 10)) = 0, "", Mid(encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).childNodes(iCD).selectSingleNode("fechaDespacho").nodeTypedValue), 1, 10))
                                            dtRow("Medicamento Dispensado / Pendiente") = IIf(Len(encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).childNodes(iCD).selectSingleNode("nombreProductoDespachado").nodeTypedValue)) = 0, "", encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).childNodes(iCD).selectSingleNode("nombreProductoDespachado").nodeTypedValue))
                                            dtRow("Cantidad Despachada") = IIf(Len(encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).childNodes(iCD).selectSingleNode("cantidadDespachada").nodeTypedValue)) = 0, "", encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).childNodes(iCD).selectSingleNode("cantidadDespachada").nodeTypedValue))
                                            dtRow("Unidad") = IIf(Len(encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).childNodes(iCD).selectSingleNode("nombreUnidadDespachada").nodeTypedValue)) = 0, "", encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).childNodes(iCD).selectSingleNode("nombreUnidadDespachada").nodeTypedValue))
                                            rsDespachadas.Rows.Add(dtRow)
                                            dtRow = rsDespachadas.NewRow()
                                        End If
                                    Next iCD
                                    'ElseIf lstNodeC(iCC).childNodes(iCU).selectSingleNode("estado").nodeTypedValue = "Pendiente" And lstNodeC(iCC).childNodes(iCU).selectSingleNode("despacho") Is Nothing Then 'Pendientes Sin Despacho 
                                ElseIf encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).selectSingleNode("estado").nodeTypedValue) = "Pendiente" Then
                                    If lstNodeC(iCC).childNodes(iCU).selectSingleNode("despacho") Is Nothing Then 'Pendientes Sin Despacho 
                                        dtRow("Cantidad Pendiente") = IIf(Len(encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).selectSingleNode("cantidadPendiente").nodeTypedValue)) = 0, "", encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).selectSingleNode("cantidadPendiente").nodeTypedValue))
                                        dtRow("Fecha Dispensación") = ""
                                        dtRow("Medicamento Dispensado / Pendiente") = IIf(Len(encripta.DesCifrar(lstNodeC(iCC).selectSingleNode("nombreProductoPedido").nodeTypedValue)) = 0, "", encripta.DesCifrar(lstNodeC(iCC).selectSingleNode("nombreProductoPedido").nodeTypedValue))
                                        dtRow("Cantidad Despachada") = ""
                                        dtRow("Unidad") = IIf(Len(encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).selectSingleNode("nombreUnidadPendiente").nodeTypedValue)) = 0, "", encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).selectSingleNode("nombreUnidadPendiente").nodeTypedValue))
                                        rsDespachadas.Rows.Add(dtRow)
                                        dtRow = rsDespachadas.NewRow()
                                    Else 'Pendientes Con Despacho
                                        For iCF = 0 To lstNodeC(iCC).childNodes(iCU).childNodes.length - 1
                                            If lstNodeC(iCC).childNodes(iCU).childNodes(iCF).nodeName = "despacho" Then
                                                dtRow("Fecha Dispensación") = IIf(Len(Mid(encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).childNodes(iCF).selectSingleNode("fechaDespacho").nodeTypedValue), 1, 10)) = 0, "", Mid(encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).childNodes(iCF).selectSingleNode("fechaDespacho").nodeTypedValue), 1, 10))
                                                dtRow("Medicamento Dispensado / Pendiente") = IIf(Len(encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).childNodes(iCF).selectSingleNode("nombreProductoDespachado").nodeTypedValue)) = 0, "", encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).childNodes(iCF).selectSingleNode("nombreProductoDespachado").nodeTypedValue))
                                                dtRow("Cantidad Despachada") = IIf(Len(encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).childNodes(iCF).selectSingleNode("cantidadDespachada").nodeTypedValue)) = 0, "", encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).childNodes(iCF).selectSingleNode("cantidadDespachada").nodeTypedValue))
                                                dtRow("Unidad") = IIf(Len(encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).childNodes(iCF).selectSingleNode("nombreUnidadDespachada").nodeTypedValue)) = 0, "", encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).childNodes(iCF).selectSingleNode("nombreUnidadDespachada").nodeTypedValue))
                                                If lstNodeC(iCC).childNodes(iCU).childNodes(iCF + 1).nodeName = "documento" Then
                                                    dtRow("Cantidad Pendiente") = IIf(Len(encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).selectSingleNode("cantidadPendiente").nodeTypedValue)) = 0, "", encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).selectSingleNode("cantidadPendiente").nodeTypedValue))
                                                End If
                                                rsDespachadas.Rows.Add(dtRow)
                                                dtRow = rsDespachadas.NewRow()
                                            End If
                                        Next iCF
                                    End If
                                ElseIf encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).selectSingleNode("estado").nodeTypedValue) = "Vencida" Then
                                    'Estado Vencida
                                End If
                            End If
                        Next iCU
                    Else
                    End If
                Else
                End If
            Next iCC
        Catch ex As Exception
            InterpretarRespuestas_JWS_MedEntre = Nothing
            Exit Function
        End Try
        InterpretarRespuestas_JWS_MedEntre = rsDespachadas

    End Function

    Private Function InterpretarRespuestas_JWS_MedFutu(ByVal strXML As String) As DataTable

        Dim rsFuturas As New DataTable

        Dim objDOM As MSXML2.DOMDocument30
        Dim oNode As MSXML2.IXMLDOMElement
        Dim iCC As Integer
        Dim iCU As Integer
        Dim lstNodeC As MSXML2.IXMLDOMNodeList
        Dim encripta As Object

        '        strXML = "<ns2:consultarEntregasResponse xmlns:ns2=""http://ejb.control.osi.com/""><return><incidencias>0</incidencias><nombreAfiliado>JULIAN ALBERTO DURAN </nombreAfiliado>" & _
        '"<numeroIdentificacion>86039922</numeroIdentificacion><producto><ATCProductoPedido>M01AD01502230000860022139</ATCProductoPedido><codigoProductoPedido>17378</codigoProductoPedido>" & _
        '"<entrega><cantidadPedida>0</cantidadPedida><cantidadPendiente>9</cantidadPendiente><documento>0093 - 37345</documento><estado>Pendiente</estado><fechaEntrega>28-FEB-12</fechaEntrega>" & _
        '"<id>1</id><idProducto>1</idProducto><identificacionMedico>30081914</identificacionMedico><medicoPrestador>LINA MARIA GARCIA EUSSE</medicoPrestador>" & _
        '"<nombreUnidadPendiente>TABLETA</nombreUnidadPendiente><numeroEntrega>1</numeroEntrega><presentacion>CAJA X ALGO</presentacion><unidadPendiente>21</unidadPendiente></entrega>" & _
        '"<entrega><cantidadPedida>0</cantidadPedida><cantidadPendiente>0</cantidadPendiente><despacho><ATCProductoDespachado>A11CC00310110000802006279</ATCProductoDespachado>" & _
        '"<cantidadDespachada>1</cantidadDespachada><codigoProductoDespachado>17378</codigoProductoDespachado><contrato>0300100000965409000101</contrato><fechaDespacho>01/03/2012</fechaDespacho>" & _
        '"<id>1</id><idEntrega>2</idEntrega><nombreProductoDespachado>DICLOFENAC 50MG GRAG GENFAR CAJ X 30</nombreProductoDespachado><nombreUnidadDespachada>TABLETA</nombreUnidadDespachada>" & _
        '"<presentacion>CAJA POR ALGO</presentacion><unidadDespachada>21</unidadDespachada></despacho><documento>0093-37345</documento><estado>Entregada</estado>" & _
        '"<fechaEntrega>05/03/2012 16:25:14</fechaEntrega><id>2</id><idProducto>1</idProducto><identificacionMedico>30081914</identificacionMedico><medicoPrestador>LINA MARIA GARCIA EUSSE</medicoPrestador>" & _
        '"<nombreUnidadPendiente></nombreUnidadPendiente><numeroEntrega>0</numeroEntrega><presentacion></presentacion><unidadPendiente></unidadPendiente></entrega>" & _
        '"<entrega><cantidadPedida>10</cantidadPedida><cantidadPendiente>8</cantidadPendiente><despacho><ATCProductoDespachado>A11CC00310110000802006279</ATCProductoDespachado>" & _
        '"<cantidadDespachada>2</cantidadDespachada><codigoProductoDespachado>17378</codigoProductoDespachado><contrato>0300100000965409000101</contrato><fechaDespacho>03/03/2012</fechaDespacho>" & _
        '"<id>1</id><idEntrega>2</idEntrega><nombreProductoDespachado>DICLOFENAC 50MG GRAG GENFAR CAJ X 30</nombreProductoDespachado><nombreUnidadDespachada>TABLETA</nombreUnidadDespachada>" & _
        '"<presentacion>CAJA POR ALGO</presentacion><unidadDespachada>21</unidadDespachada></despacho><documento>0093-37345</documento><estado>Pendiente</estado>" & _
        '"<fechaEntrega>05/03/2012 16:25:14</fechaEntrega><id>2</id><idProducto>1</idProducto><identificacionMedico>30081914</identificacionMedico><medicoPrestador>LINA MARIA GARCIA EUSSE</medicoPrestador>" & _
        '"<nombreUnidadPendiente></nombreUnidadPendiente><numeroEntrega>0</numeroEntrega><presentacion></presentacion><unidadPendiente></unidadPendiente></entrega><idProducto>1</idProducto>" & _
        '"<nombreProductoPedido>DICLOFENAC 50MG GRAG GENFAR CAJ X 30</nombreProductoPedido></producto><producto><ATCProductoPedido>S01AG00361111000830121423</ATCProductoPedido><codigoProductoPedido>78523</codigoProductoPedido>" & _
        '"<entrega><cantidadPedida>0</cantidadPedida><cantidadPendiente>1</cantidadPendiente><documento>0093 - 37345</documento>" & _
        '"<estado>Pendiente</estado><fechaEntrega>28-FEB-12</fechaEntrega><id>3</id><idProducto>2</idProducto><identificacionMedico>30081914</identificacionMedico>" & _
        '"<medicoPrestador>LINA MARIA GARCIA EUSSE</medicoPrestador><nombreUnidadPendiente>TABLETA</nombreUnidadPendiente><numeroEntrega>1</numeroEntrega><presentacion>CAJA X ALGO</presentacion>" & _
        '"<unidadPendiente>43</unidadPendiente></entrega><entrega><cantidadPedida>15</cantidadPedida><cantidadPendiente>15</cantidadPendiente><documento>0093 - 37345</documento>" & _
        '"<estado>Futura</estado><fechaEntrega>18-MAR-12</fechaEntrega><id>3</id><idProducto>2</idProducto><identificacionMedico>30081914</identificacionMedico>" & _
        '"<medicoPrestador>LINA MARIA GARCIA EUSSE</medicoPrestador><nombreUnidadPendiente>TABLETA</nombreUnidadPendiente><numeroEntrega>1</numeroEntrega><presentacion>CAJA X ALGO</presentacion>" & _
        '"<unidadPendiente>43</unidadPendiente></entrega><entrega><cantidadPedida>30</cantidadPedida><cantidadPendiente>30</cantidadPendiente><documento>0093 - 37345</documento>" & _
        '"<estado>Futura</estado><fechaEntrega>28-MAR-12</fechaEntrega><id>3</id><idProducto>2</idProducto><identificacionMedico>30081914</identificacionMedico>" & _
        '"<medicoPrestador>LINA MARIA GARCIA EUSSE</medicoPrestador><nombreUnidadPendiente>TABLETA</nombreUnidadPendiente><numeroEntrega>1</numeroEntrega><presentacion>CAJA X ALGO</presentacion>" & _
        '"<unidadPendiente>43</unidadPendiente></entrega><idProducto>2</idProducto><nombreProductoPedido>PURPUCINA 0.3% UNG OFT TUB X 5GR</nombreProductoPedido></producto>" & _
        '"<tipoIdentificacion>C</tipoIdentificacion></return></ns2:consultarEntregasResponse>"

        objDOM = New MSXML2.DOMDocument30
        objDOM.async = False
        objDOM.loadXML(strXML)

        encripta = New gpm_crypto.clsOSICadenaSeg

        rsFuturas.Columns.Add("Medicamento Solicitado", System.Type.GetType("System.String"))
        'rsFuturas.Columns.Add("Estado", System.Type.GetType("System.String"))
        rsFuturas.Columns.Add("Cantidad Solicitada Por Entrega", System.Type.GetType("System.String"))
        rsFuturas.Columns.Add("Entregas Pendientes", System.Type.GetType("System.String"))
        rsFuturas.Columns.Add("Próxima Entrega", System.Type.GetType("System.String"))

        Dim i As Integer

        oNode = objDOM.selectSingleNode("ns2:consultarEntregasResponse/return")
        Try
            lstNodeC = oNode.getElementsByTagName("producto")
            For iCC = 0 To lstNodeC.length - 1
                If Not oNode Is Nothing Then
                    If oNode.childNodes.length > 0 Then
                        For iCU = 0 To lstNodeC(iCC).childNodes.length - 1
                            Dim dtRow As DataRow = rsFuturas.NewRow()
                            If lstNodeC(iCC).childNodes(iCU).nodeName = "entrega" Then
                                ' dtRow("Estado") = lstNodeC(iCC).childNodes(iCU).selectSingleNode("estado").nodeTypedValue                            
                                If encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).selectSingleNode("estado").nodeTypedValue) = "Futura" Then
                                    i = i + 1
                                    dtRow("Medicamento Solicitado") = IIf(Len(encripta.DesCifrar(lstNodeC(iCC).selectSingleNode("nombreProductoPedido").nodeTypedValue)) = 0, "", encripta.DesCifrar(lstNodeC(iCC).selectSingleNode("nombreProductoPedido").nodeTypedValue))
                                    dtRow("Cantidad Solicitada Por Entrega") = IIf(Len(encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).selectSingleNode("cantidadPendiente").nodeTypedValue)) = 0, "", encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).selectSingleNode("cantidadPendiente").nodeTypedValue))
                                    dtRow("Entregas Pendientes") = i
                                    dtRow("Próxima Entrega") = IIf(Len(Mid(encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).selectSingleNode("fechaEntrega").nodeTypedValue), 1, 10)) = 0, "", Mid(encripta.DesCifrar(lstNodeC(iCC).childNodes(iCU).selectSingleNode("fechaEntrega").nodeTypedValue), 1, 10))
                                    rsFuturas.Rows.Add(dtRow)
                                    dtRow = rsFuturas.NewRow()
                                End If
                                dtRow = Nothing
                            End If
                        Next iCU
                    Else
                    End If
                Else
                End If
                i = 0
            Next iCC
        Catch ex As Exception
            InterpretarRespuestas_JWS_MedFutu = Nothing
            Exit Function
        End Try

        rsFuturas = FiltrarGrilla(rsFuturas)
        InterpretarRespuestas_JWS_MedFutu = rsFuturas

    End Function

    Public Function FiltrarGrilla(ByVal dt As DataTable) As DataTable

        Dim rsFuturas2 As DataTable = dt.Clone
        Dim strmedicamento As String
        Dim contador As Integer = 0

        Try
            If dt.Rows.Count > 0 Then
                strmedicamento = dt.Rows(0).Item("Medicamento Solicitado")
            Else
                Return dt
            End If

            rsFuturas2.Rows.Add(rsFuturas2.NewRow)

            For i As Integer = 0 To dt.Rows.Count - 1

                If i = dt.Rows.Count - 1 Then
                    rsFuturas2.Rows(contador).Item("Entregas Pendientes") = dt.Rows(i).Item("Entregas Pendientes")
                End If
                If strmedicamento = dt.Rows(i).Item("Medicamento Solicitado") Then

                    If rsFuturas2.Rows(contador).Item("Próxima Entrega").ToString = "" Then
                        rsFuturas2.Rows(contador).Item("Próxima Entrega") = dt.Rows(i).Item("Próxima Entrega")
                    End If

                    If rsFuturas2.Rows(contador).Item("Medicamento Solicitado").ToString = "" Then
                        rsFuturas2.Rows(contador).Item("Medicamento Solicitado") = dt.Rows(i).Item("Medicamento Solicitado")
                    End If

                    If rsFuturas2.Rows(contador).Item("Cantidad Solicitada Por Entrega").ToString = "" Then
                        rsFuturas2.Rows(contador).Item("Cantidad Solicitada Por Entrega") = dt.Rows(i).Item("Cantidad Solicitada Por Entrega")
                    End If
                Else
                    contador = contador + 1                 
                    rsFuturas2.Rows.Add(rsFuturas2.NewRow)
                    If i = dt.Rows.Count - 1 Then
                        rsFuturas2.Rows(contador).Item("Entregas Pendientes") = dt.Rows(i).Item("Entregas Pendientes")
                    End If
                    rsFuturas2.Rows(contador).Item("Medicamento Solicitado") = dt.Rows(i).Item("Medicamento Solicitado")
                    rsFuturas2.Rows(contador).Item("Cantidad Solicitada Por Entrega") = dt.Rows(i).Item("Cantidad Solicitada Por Entrega")
                    rsFuturas2.Rows(contador - 1).Item("Entregas Pendientes") = dt.Rows(i - 1).Item("Entregas Pendientes")
                    rsFuturas2.Rows(contador).Item("Próxima Entrega") = dt.Rows(i).Item("Próxima Entrega")
                    strmedicamento = dt.Rows(i).Item("Medicamento Solicitado")
                End If
            Next
        Catch ex As Exception

        End Try

        Return rsFuturas2
    End Function
#End Region

#Region "Salir"
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.dtgDespachadas.DataSource = Nothing
        Me.dtgFuTuras.DataSource = Nothing
        Me.Close()
    End Sub
#End Region


End Class