Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.BL

Namespace Sophia.HistoriaClinica.Reportes
    Public Class Procedimiento
        Inherits GPMDataReport

        Private _codigo As String
        Private _descripcion As String
        Private _recomendaciones As String
        Private _autorizacion As String
        Private _cantidad As Integer
        Private _entidad As String
        Private _entidadPrestadora As String
        Private _institucionPrestadora As String
        Private _medico As String
        Private _observaciones As String
        Private _numeroOrden As String
        Private _codCentroDeCostoDestino As String
        Private _descrCentroCostoDestino As String
        Private _subGrupo As String
        Private _bilateral As String
        Private _tieneConvenio As String
        Private _Respuesta As String
        Private _Interpretacion As String
        Private _FechaRespuesta As String
        Private _numPedido As String
        Private _codigo_RIS As String
        Private _nombre_RIS As String
        Private _diagnosticoPrincipal As String
        Private _practicaOsi As String
        Private _Cod_SISPRO As String ''rmzaldua 2017-03-28




#Region "Propiedades"
        Public Property Codigo() As String
            Get
                Return _codigo
            End Get
            Set(ByVal value As String)
                _codigo = value
            End Set
        End Property
        Public Property Descripcion() As String
            Get
                Return _descripcion
            End Get
            Set(ByVal value As String)
                _descripcion = value
            End Set
        End Property
        Public ReadOnly Property Recomendaciones() As String
            Get
                Return _recomendaciones
            End Get
        End Property
        Public ReadOnly Property Autorizacion() As String
            Get
                Return _autorizacion
            End Get
        End Property
        Public Property Cantidad() As String
            Get
                Return _cantidad
            End Get
            Set(ByVal value As String)
                _cantidad = value
            End Set
        End Property
        Public Property Entidad() As String
            Get
                Return _entidad
            End Get
            Set(ByVal Value As String)
                _entidad = Value
            End Set
        End Property
        Public Property EntidadPrestadora() As String
            Get
                Return _entidadPrestadora
            End Get
            Set(ByVal Value As String)
                _entidadPrestadora = Value
            End Set
        End Property
        Public Property InstitucionPrestadora() As String
            Get
                Return _institucionPrestadora
            End Get
            Set(ByVal Value As String)
                _institucionPrestadora = Value
            End Set
        End Property
        Public Property Medico() As String
            Get
                Return _medico
            End Get
            Set(ByVal Value As String)
                _medico = Value
            End Set
        End Property
        Public Property Observaciones() As String
            Get
                Return _observaciones
            End Get
            Set(ByVal Value As String)
                _observaciones = Value
            End Set
        End Property

        Public Property NumeroOrden() As String
            Get
                Return _numeroOrden
            End Get
            Set(ByVal Value As String)
                _numeroOrden = Value
            End Set
        End Property
        Public Property CodigoCentroDeCostoDestino() As String
            Get
                Return _codCentroDeCostoDestino
            End Get
            Set(ByVal value As String)
                _codCentroDeCostoDestino = value
            End Set
        End Property
        Public Property DescripcionCentroDeCostoDestino() As String
            Get
                Return _descrCentroCostoDestino
            End Get
            Set(ByVal value As String)
                _descrCentroCostoDestino = value
            End Set
        End Property
        Public Property SubGrupo() As String
            Get
                Return _subGrupo
            End Get
            Set(ByVal value As String)
                _subGrupo = value
            End Set
        End Property
        Public Property Bilateral() As String
            Get
                Return _bilateral
            End Get
            Set(ByVal value As String)
                _bilateral = value
            End Set
        End Property
        Public Property TieneConvenio() As String
            Get
                Return _tieneConvenio
            End Get
            Set(ByVal value As String)
                _tieneConvenio = value
            End Set
        End Property

        Public Property Respuesta() As String
            Get
                Return _Respuesta
            End Get
            Set(ByVal value As String)
                _Respuesta = value
            End Set
        End Property

        Public Property Interpretacion() As String
            Get
                Return _Interpretacion
            End Get
            Set(ByVal value As String)
                _Interpretacion = value
            End Set
        End Property

        Public Property FechaRespuesta() As String
            Get
                Return _FechaRespuesta
            End Get
            Set(ByVal value As String)
                _FechaRespuesta = value
            End Set
        End Property
        'jlalfonso, se adiciona numero de pedido 
        'solicitado por Enrique Forero -2009-01-07
        Public Property NumPedido() As String
            Get
                Return _numPedido
            End Get
            Set(ByVal value As String)
                _numPedido = value
            End Set
        End Property

        Public Property codigo_RIS() As String
            Get
                Return _codigo_RIS
            End Get
            Set(ByVal value As String)
                _codigo_RIS = value
            End Set
        End Property

        Public Property nombre_RIS() As String
            Get
                Return _nombre_RIS
            End Get
            Set(ByVal value As String)
                _nombre_RIS = value
            End Set
        End Property
        ''Claudia Garay Nov 15 de 2012 Diagnostico en las ordenes de procedimiento
        Public Property DiagnosticoPrincipal() As String
            Get
                Return _diagnosticoPrincipal
            End Get
            Set(ByVal value As String)
                _diagnosticoPrincipal = value
            End Set
        End Property
        ''Claudia Garay Enero 22 2014 
        Public Property PracticaOSi() As String
            Get
                Return _practicaOsi
            End Get
            Set(ByVal value As String)
                _practicaOsi = value
            End Set
        End Property

        Public Property Cod_SISPRO() As String
            Get
                Return _Cod_SISPRO
            End Get
            Set(ByVal value As String)
                _Cod_SISPRO = value
            End Set
        End Property
#End Region

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal codigo As String, ByVal descripcion As String, ByVal recomendacion As String, _
                       ByVal autorizacion As String, ByVal cantidad As String, _
                       Optional ByVal strEntidad As String = "", Optional ByVal strEntPrestadora As String = "", _
                       Optional ByVal strInstPrestadora As String = "", Optional ByVal strMedico As String = "", _
                       Optional ByVal strRespuesta As String = "", Optional ByVal strInterpretacion As String = "", _
                       Optional ByVal strFechaRespuesta As String = "", Optional ByVal strcodigo_RIS As String = "", _
                       Optional ByVal strnombre_RIS As String = "", Optional ByVal codSISPRO As String = "")

            _codigo = codigo
            _descripcion = descripcion
            _recomendaciones = recomendacion
            _autorizacion = autorizacion
            _cantidad = cantidad
            _entidad = strEntidad
            _entidadPrestadora = strEntPrestadora
            _institucionPrestadora = strInstPrestadora
            _medico = strMedico
            _Respuesta = strRespuesta
            _Interpretacion = strInterpretacion
            _FechaRespuesta = strFechaRespuesta
            _codigo_RIS = strcodigo_RIS
            _nombre_RIS = strnombre_RIS
            _Cod_SISPRO = codSISPRO '' rmzaldua 2017-03-28
        End Sub

        Public Function consultarProcedimientos(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, _
                   ByVal strCod_sucur As String, ByVal strTip_admision As String, _
                   ByVal iano_adm As Long, ByVal lnum_adm As Double) As List(Of Procedimiento)

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim objProcedimiento As Procedimiento
            Dim drDatos As IDataReader
            Dim listaProcedimiento As New List(Of Procedimiento)

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)

            '' ''command = db.GetStoredProcCommandWrapper("pa_Reportes_Procedimientos")

            '' ''With command
            '' ''    .AddInParameter("strcod_pre_sgs", DbType.String, strcod_pre_sgs)
            '' ''    .AddInParameter("strCod_sucur", DbType.String, strCod_sucur)
            '' ''    .AddInParameter("strTip_admision", DbType.String, strTip_admision)
            '' ''    .AddInParameter("iano_adm", DbType.Int16, iano_adm)
            '' ''    .AddInParameter("lnum_adm", DbType.Double, lnum_adm)
            '' ''End With

            '' ''drDatos = db.ExecuteReader(command)

            gpmDataObj.setSQLSentence("pa_Reportes_Procedimientos", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("strcod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            gpmDataObj.addInputParameter("strCod_sucur", SqlDbType.VarChar, strCod_sucur)
            gpmDataObj.addInputParameter("strTip_admision", SqlDbType.VarChar, strTip_admision)
            gpmDataObj.addInputParameter("iano_adm", SqlDbType.Int, iano_adm)
            gpmDataObj.addInputParameter("lnum_adm", SqlDbType.VarChar, lnum_adm)

            drDatos = gpmDataObj.ExecRdr()

            While drDatos.Read()
                objProcedimiento = New Procedimiento(drDatos("procedim").ToString, drDatos("bDescripcion").ToString,
                                       "", "", drDatos("cantidad").ToString, drDatos("cDescripcion").ToString,
                                       drDatos("dDescripcion").ToString, drDatos("eDescripcion").ToString, drDatos("resultado").ToString,
                                       drDatos("interpretacion").ToString, drDatos("FecResultado").ToString, drDatos("autosispro").ToString)

                objProcedimiento._numeroOrden = drDatos("con_procedim").ToString
                listaProcedimiento.Add(objProcedimiento)
            End While

            If drDatos.IsClosed = False Then
                drDatos.Close()
            End If
            '' ''command.Command.Connection.Close()
            '' ''command.Command.Connection.Dispose()

            Return listaProcedimiento

        End Function

        Public Function crearListaProcedimQuirurgicos(ByVal drDatos As IDataReader) As List(Of Procedimiento)

            Dim objProcedimiento As Procedimiento
            Dim listaProcedimiento As New List(Of Procedimiento)
            Try
                While drDatos.Read()
                    'jlalfonso
                    'se realiza comentario debido a problemas en la impresion de resumen de hc
                    'este no estaba mostrando los procedimientos qx
                    'soporte enviado por eforero.
                    'objProcedimiento = New Procedimiento(drDatos("procedim").ToString, drDatos("Descripcion").ToString, "", "", "", _
                    '                       strMedico:=drDatos("NombreMedico").ToString, strRespuesta:=drDatos("resultado").ToString, _
                    '                       strinterpretacion:=drDatos("interpretacion").ToString, strfecharespuesta:=drDatos("FecRespuesta").ToString)
                    objProcedimiento = New Procedimiento(drDatos("procedim").ToString, drDatos("Descripcion").ToString, "", "", 0, _
                                           strMedico:=drDatos("NombreMedico").ToString, strRespuesta:="", strinterpretacion:="", strfecharespuesta:="", _
                                           codSISPRO:=drDatos("autosispro").ToString)


                    listaProcedimiento.Add(objProcedimiento)

                End While


            Catch ex As Exception
                MsgBox("error en crear lista procedimientos QX practicados." & ex.Message)
            End Try
            Return listaProcedimiento
        End Function

        Public Function crearListaProcedimOrdenMedica(ByVal dtProcedim As DataTable, Optional ByVal strPracticaosi As String = "") As List(Of Procedimiento)
            Dim lista As New List(Of Procedimiento)
            Dim objProcedimiento As Procedimiento
            Dim i As Integer
            Dim rowsProcedimientos() As DataRow


            If dtProcedim Is Nothing Then
                Return lista
            End If


            Dim dtmedcopy As DataTable = dtProcedim.Copy

            ' herojas agfa orm in 2014/09/23 para filtar los procedimientos que no son de radiologia y los que realiza la sede

            rowsProcedimientos = dtProcedim.Select("numconsulta in(1,2,5)") ' La consulta  devuelve 1 para los procedimientos que no estan en genproceris
            dtProcedim = copyArrayToDataTable(dtmedcopy.Clone, rowsProcedimientos)

            If dtProcedim Is Nothing Then
                Return lista
            End If


            For i = 0 To dtProcedim.Rows.Count - 1
                objProcedimiento = New Procedimiento()
                With objProcedimiento
                    ._codigo = dtProcedim.Rows(i).Item("procedim").ToString
                    ._descripcion = dtProcedim.Rows(i).Item("descripcion_proce").ToString
                    ._cantidad = dtProcedim.Rows(i).Item("Cantidad").ToString
                    ._observaciones = dtProcedim.Rows(i).Item("obs").ToString
                    .NumeroOrden = dtProcedim.Rows(i).Item("NroOrden").ToString
                    'jlalfonso
                    'asigna numero de pedido 2009-01-07
                    .NumPedido = dtProcedim.Rows(i).Item("NroPedido").ToString
                    .DiagnosticoPrincipal = dtProcedim.Rows(i).Item("Diagnostico").ToString ''cpgaray Nov 15 de 2012
                    If dtProcedim.Rows(i).Item("cen_cos_des").ToString.Trim.Length = 0 Then 'Val(dtProcedim.Rows(i).Item("tip_proced").ToString) = BLOrdenes.tiposProcedim.ConsultaMedica Then
                        objProcedimiento.calcularSubgrupo()
                        ._codCentroDeCostoDestino = ._subGrupo
                    Else
                        ._codCentroDeCostoDestino = dtProcedim.Rows(i).Item("cen_cos_des").ToString
                    End If
                    ._descrCentroCostoDestino = dtProcedim.Rows(i).Item("descri_cen_cos_des").ToString
                    If dtProcedim.Columns.Contains("tieneConvenio") = True Then
                        ._tieneConvenio = dtProcedim.Rows(i).Item("tieneConvenio").ToString
                    End If
                    If dtProcedim.Columns.Contains("resultado") = True Then
                        ._Respuesta = dtProcedim.Rows(i).Item("resultado").ToString
                    End If
                    If dtProcedim.Columns.Contains("interpretacion") = True Then
                        ._Interpretacion = dtProcedim.Rows(i).Item("interpretacion").ToString
                    End If
                    If dtProcedim.Columns.Contains("FecResultado") = True Then
                        ._FechaRespuesta = dtProcedim.Rows(i).Item("FecResultado").ToString
                    End If
                    If dtProcedim.Columns.Contains("codigo_RIS") = True Then
                        ._codigo_RIS = dtProcedim.Rows(i).Item("codigo_RIS").ToString
                    End If
                    If dtProcedim.Columns.Contains("nombre_RIS") = True Then
                        ._nombre_RIS = dtProcedim.Rows(i).Item("nombre_RIS").ToString
                    End If
                    ._practicaOsi = ""
                    ._Cod_SISPRO = dtProcedim.Rows(i).Item("autoSISPRO").ToString 'rmzaldua 2017-03-28

                End With
                lista.Add(objProcedimiento)
            Next

            Return lista
        End Function

        Public Sub calcularSubgrupo()
            Dim grupo As String
            grupo = _codigo.Substring(0, 3)
            If grupo = "401" Then
                _subGrupo = grupo
            Else
                _subGrupo = _codigo.Substring(0, 5)
            End If
        End Sub
        Public Shared Function copyArrayToDataTable(ByVal dtTabla As DataTable, ByVal array As DataRow()) As DataTable
            Dim row As DataRow

            For Each row In array
                dtTabla.ImportRow(row)
            Next

            Return dtTabla

        End Function
    End Class
End Namespace

