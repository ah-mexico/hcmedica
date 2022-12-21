Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    Public Class Medicamento
        Inherits GPMDataReport

        Private _codigo As String
        Private _descripcion As String
        Private _prescripcion As String
        Private _cantidad As String
        Private _cantidadLetras As String
        Private _formula As String
        Private _entidad As String
        Private _autorizacion As String
        Private _fecha As String
        Private _tratamiento As String
        Private _medico As String
        Private _especialidad As String
        Private _numeroOrden As String
        Private _UnidadPrescripcion As String
        Private _UnidadDispensacion As String
        Private _cantidadDispensacion As String
        Private _cantidadDispensacionLetras As String
        Private _Observaciones As String
        Private _tiempoMedControl As String  ''cpgaray
        Private _cantidadMedControl As String ''cpgaray
        Private _cantidadLetrasMedControl As String ''cpgaray
        Private _Cod_SISPRO As String ''rmzaldua 2016-11-30



#Region "Propiedades"
        Public ReadOnly Property Codigo() As String
            Get
                Return _codigo
            End Get
        End Property
        Public Property Descripcion() As String
            Get
                Return _descripcion
            End Get
            Set(ByVal value As String)
                _descripcion = value
            End Set
        End Property
        Public Property Prescripcion() As String
            Get
                Return _prescripcion
            End Get
            Set(ByVal value As String)
                _prescripcion = value
            End Set
        End Property
        Public Property Cantidad() As String
            Get
                Return _cantidad
            End Get
            Set(ByVal value As String)
                _cantidad = value
            End Set
        End Property
        Public Property CantidadLetras() As String
            Get
                Return _cantidadLetras
            End Get
            Set(ByVal value As String)
                _cantidadLetras = value
            End Set
        End Property
        Public Property Formula() As String
            Get
                Return _formula
            End Get
            Set(ByVal Value As String)
                _formula = Value
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
        Public Property Autorizacion() As String
            Get
                Return _autorizacion
            End Get
            Set(ByVal Value As String)
                _autorizacion = Value
            End Set
        End Property
        Public Property Fecha() As String
            Get
                Return _fecha
            End Get
            Set(ByVal Value As String)
                _fecha = Value
            End Set
        End Property

        Public Property Tratamiento() As String
            Get
                Return _tratamiento
            End Get
            Set(ByVal Value As String)
                _tratamiento = Value
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
        Public Property Especialidad() As String
            Get
                Return _especialidad
            End Get
            Set(ByVal Value As String)
                _especialidad = Value
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

        Public Property UnidadPrescripcion() As String
            Get
                Return _UnidadPrescripcion
            End Get
            Set(ByVal value As String)
                _UnidadPrescripcion = value
            End Set
        End Property

        Public Property UnidadDispensacion() As String
            Get
                Return _UnidadDispensacion
            End Get
            Set(ByVal value As String)
                _UnidadDispensacion = value
            End Set
        End Property

        Public Property CantidadDispensacion() As String
            Get
                Return _cantidadDispensacion
            End Get
            Set(ByVal value As String)
                _cantidadDispensacion = value
            End Set
        End Property

        Public Property CantidadDispensacionLetras() As String
            Get
                Return _cantidadDispensacionLetras
            End Get
            Set(ByVal value As String)
                _cantidadDispensacionLetras = value
            End Set
        End Property
        ''cpgaray Medicamentos regulados Enero 11 de 2012
        Public Property TiempoMedControl() As String
            Get
                Return _tiempoMedControl
            End Get
            Set(ByVal value As String)
                _tiempoMedControl = value
            End Set
        End Property
        Public Property CantidadMedControl() As String
            Get
                Return _cantidadMedControl
            End Get
            Set(ByVal value As String)
                _cantidadMedControl = value
            End Set
        End Property
        Public Property CantidadLetrasMedControl() As String
            Get
                Return _cantidadLetrasMedControl
            End Get
            Set(ByVal value As String)
                _cantidadLetrasMedControl = value
            End Set
        End Property
        ''Fin cpgaray
        Public Property ObservacionesFormula() As String
            Get
                Return _Observaciones
            End Get
            Set(ByVal value As String)
                _Observaciones = value
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
        Public Sub New(ByVal codigo As String, ByVal descripcion As String, _
                       ByVal prescripcion As String, ByVal cant As String, _
                       Optional ByVal strFormula As String = "", Optional ByVal strEntidad As String = "", _
                       Optional ByVal strAutorizacion As String = "", Optional ByVal cantDisp As String = "", _
                       Optional ByVal obs As String = "", Optional ByVal codSISPRO As String = "")

            _codigo = codigo
            _descripcion = descripcion
            _prescripcion = prescripcion
            _cantidad = cant
            _formula = strFormula
            _entidad = strEntidad
            _autorizacion = strAutorizacion
            _cantidadDispensacion = cantDisp
            _Observaciones = obs  ''Claudia Garay 19 Abril 2010
            _Cod_SISPRO = codSISPRO '' rmzaldua 2016-11-30
        End Sub

        Public Function consultarMedicamentos(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, _
                   ByVal strCod_sucur As String, ByVal strTip_admision As String, _
                   ByVal iano_adm As Long, ByVal lnum_adm As Double) As List(Of Medicamento)

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim objMedicamento As Medicamento
            Dim drDatos As IDataReader
            Dim listaMedicamentos As New List(Of Medicamento)

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)

            '' ''command = db.GetStoredProcCommandWrapper("pa_Reportes_Medicamentos")

            '' ''With command
            '' ''    .AddInParameter("strcod_pre_sgs", DbType.String, strcod_pre_sgs)
            '' ''    .AddInParameter("strCod_sucur", DbType.String, strCod_sucur)
            '' ''    .AddInParameter("strTip_admision", DbType.String, strTip_admision)
            '' ''    .AddInParameter("iano_adm", DbType.Int16, iano_adm)
            '' ''    .AddInParameter("lnum_adm", DbType.Double, lnum_adm)
            '' ''End With

            '' ''drDatos = db.ExecuteReader(command)
            gpmDataObj.setSQLSentence("pa_Reportes_Medicamentos", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("strcod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            gpmDataObj.addInputParameter("strCod_sucur", SqlDbType.VarChar, strCod_sucur)
            gpmDataObj.addInputParameter("strTip_admision", SqlDbType.VarChar, strTip_admision)
            gpmDataObj.addInputParameter("iano_adm", SqlDbType.Int, iano_adm)
            gpmDataObj.addInputParameter("lnum_adm", SqlDbType.Decimal, lnum_adm)

            drDatos = gpmDataObj.ExecRdr()

            While drDatos.Read()
                'Claudia Garay 19 Abril 2010
                ''Se agrega Obs
                objMedicamento = New Medicamento(drDatos("producto").ToString, drDatos("bdescripcion").ToString, _
                                        drDatos("prescripcion").ToString, "", drDatos("nro_formula").ToString, _
                                        drDatos("cdescripcion").ToString, drDatos("nroautoriza").ToString, "", _
                                        drDatos("obs").ToString, drDatos("autosispro").ToString)

                listaMedicamentos.Add(objMedicamento)

            End While

            If drDatos.IsClosed = False Then
                drDatos.Close()
            End If
            '' ''Command.Command.Connection.Close()
            '' ''Command.Command.Connection.Dispose()

            Return listaMedicamentos
        End Function

        Public Function crearListaMedicamentos(ByVal dtMedicamentos As DataTable) As List(Of Medicamento)
            Dim lista As New List(Of Medicamento)
            Dim objMedicamento As Medicamento
            Dim i As Integer
            Dim dtmedcopy As DataTable = dtMedicamentos.Copy

            'rowsProcedimientos = dtMedicamentos.Select("MedControl<>'S'")
            'dtMedicamentos = copyArrayToDataTable(dtmedcopy.Clone, rowsProcedimientos)

            If dtMedicamentos Is Nothing Then
                Return lista
            End If

            For i = 0 To dtMedicamentos.Rows.Count - 1
                objMedicamento = New Medicamento()
                With objMedicamento
                    .Descripcion = dtMedicamentos.Rows(i).Item("descripcion").ToString
                    .Prescripcion = dtMedicamentos.Rows(i).Item("prescripcion").ToString
                    .Fecha = dtMedicamentos.Rows(i).Item("fec_con").ToString
                    .Tratamiento = dtMedicamentos.Rows(i).Item("Tratamiento").ToString
                    '.Medico = dtMedicamentos.Rows(i).Item("nombreMedico").ToString
                    '.Especialidad = dtMedicamentos.Rows(i).Item("especialidad").ToString
                    .NumeroOrden = dtMedicamentos.Rows(i).Item("NroOrden").ToString
                    .ObservacionesFormula = dtMedicamentos.Rows(i).Item("obs").ToString       'Claudia Garay 19 Abril 2010
                    .Cod_SISPRO = dtMedicamentos.Rows(i).Item("autoSISPRO").ToString 'rmzaldua 2016-11-30
                End With

                lista.Add(objMedicamento)
            Next

            Return lista
        End Function
        Public Function crearListaMedicamentosN(ByVal dtMedicamentos As DataTable) As List(Of Medicamento)
            Dim lista As New List(Of Medicamento)
            Dim objMedicamento As Medicamento
            Dim i As Integer
            ' Dim rowsProcedimientos() As DataRow
            'Dim dtmedcopy As DataTable = dtMedicamentos.Copy

            ' rowsProcedimientos = dtMedicamentos.Select("MedControl<>'S'")
            'dtMedicamentos = copyArrayToDataTable(dtmedcopy.Clone, rowsProcedimientos)

            If dtMedicamentos Is Nothing Then
                Return lista
            End If

            For i = 0 To dtMedicamentos.Rows.Count - 1
                objMedicamento = New Medicamento()
                With objMedicamento
                    .Descripcion = dtMedicamentos.Rows(i).Item("descripcion").ToString
                    .Prescripcion = dtMedicamentos.Rows(i).Item("prescripcion").ToString
                    .Fecha = dtMedicamentos.Rows(i).Item("fec_con").ToString
                    .Tratamiento = dtMedicamentos.Rows(i).Item("Tratamiento").ToString
                    '.Medico = dtMedicamentos.Rows(i).Item("nombreMedico").ToString
                    '.Especialidad = dtMedicamentos.Rows(i).Item("especialidad").ToString
                    .NumeroOrden = dtMedicamentos.Rows(i).Item("NroOrden").ToString
                    .ObservacionesFormula = dtMedicamentos.Rows(i).Item("obs").ToString       'Claudia Garay 19 Abril 2010
                    .Cod_SISPRO = dtMedicamentos.Rows(i).Item("autoSISPRO").ToString 'rmzaldua 2016-11-30
                End With

                lista.Add(objMedicamento)
            Next

            Return lista
        End Function

        Public Shared Function copyArrayToDataTable(ByVal dtTabla As DataTable, ByVal array As DataRow()) As DataTable
            Dim row As DataRow

            For Each row In array
                dtTabla.ImportRow(row)
            Next

            Return dtTabla

        End Function
       
    End Class
End Namespace
