Imports System.Data.Common
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Util
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales

Namespace Sophia.HistoriaClinica.Reportes
    Public Class Orden
        Inherits GPMDataReport

        Private _numeroOrden As String
        Private _compa?ia As String
        Private _codigoSucursal As String
        Private _sucursal As String
        Private _dirSucur As String
        Private _telefonoSucur As String
        Private _entidadAfilia As String
        Private _nit As String
        Private _ciudad As String
        Private _entidadPresta As String
        Private _paciente As Paciente
        Private _fecha As String
        Private _aislamientos As List(Of Aislamiento)
        Private _dietas As List(Of Dieta)
        Private _procedimientos As List(Of Procedimiento)
        'herojas agfa_orm_in 2014/09/24
        Private _procedimientosN As List(Of ProcedimientoNoPractica)
        Private _procedimientosNoSede As List(Of ProcedimientoNoSede) ''OS8201184
        Private _medicamentos As List(Of Medicamento)
        Private _Alarma As List(Of Alarma)
        Private _medicamentosControl As List(Of MedicamentoControl)
        Private _ordenesGenerales As List(Of OrdenGeneral)
        Private _nombreMedico As String
        Private _tipocontrato As String
        Private _identificacionMedico As String
        Private _NumDocMedico As String
        Private _registroMedico As String
        Private _cronico As String
        Private _entregas As Integer
        Private _especialidad As String
        Private _observaciones As String
        Private _tipoUsuarioEntidad As String
        Private _tipoAdmision As String
        Private _numeroAdmision As Double
        Private _anoAdmision As Integer
        Private _codCentroDeCostoOrigen As String
        Private _descrCentroCostoOrigen As String
        Private _reimpresion As Boolean
        Private _PyP As String
        Private _motremision As String
        Private _PlanManejo As String
        Private _ta_dia As String
        Private _ta_sis As String
        Private _fre_respira As String
        Private _fre_cardiaca As String
        Private _talla As String
        Private _peso As String
        Private _Diagnosticos As List(Of Diagnostico)
        Private _escontrolado As String
        Private _sexo As String ''cpgaray 10 Febrero 2012
        Private _uni_med_tie As String ''cpgaray 10 Febrero< 2012
        Private _edad As String ''cpgaray 10 Febrero 2012
        Private _textovalidopor As String ''cpgaray Marzo 14 de 2013
        Private objFormuExt As PlanFormuExterna
        Public objDatosGenerales As objGeneral.Generales

#Region "Propiedades"
        Public Property NumeroOrden() As String
            Get
                Return _numeroOrden
            End Get
            Set(ByVal value As String)
                _numeroOrden = value
            End Set
        End Property
        Public ReadOnly Property Compa?ia() As String
            Get
                Return _compa?ia
            End Get
        End Property
        Public ReadOnly Property Sucursal() As String
            Get
                Return _sucursal
            End Get
        End Property
        Public ReadOnly Property DireccionSucursal() As String
            Get
                Return _dirSucur
            End Get
        End Property
        Public ReadOnly Property TelefonoSucursal() As String
            Get
                Return _telefonoSucur
            End Get
        End Property
        Public ReadOnly Property EntidadAfiliacion() As String
            Get
                Return _entidadAfilia
            End Get
        End Property
        Public ReadOnly Property Nit() As String
            Get
                Return _nit
            End Get
        End Property
        Public ReadOnly Property Ciudad() As String
            Get
                Return _ciudad
            End Get
        End Property
        Public ReadOnly Property EntidadPrestadora() As String
            Get
                Return _entidadPresta
            End Get
        End Property
        Public ReadOnly Property Paciente() As Paciente
            Get
                Return _paciente
            End Get
        End Property
        Public Property Fecha() As String
            Get
                Return _fecha
            End Get
            Set(ByVal value As String)
                _fecha = value
            End Set
        End Property
        Public Property Procedimientos() As List(Of Procedimiento)
            Get
                Return _procedimientos
            End Get
            Set(ByVal value As List(Of Procedimiento))
                _procedimientos = value
            End Set
        End Property
        Public Property ProcedimientosN() As List(Of ProcedimientoNoPractica)
            Get
                Return _procedimientosN
            End Get
            Set(ByVal value As List(Of ProcedimientoNoPractica))
                _procedimientosN = value
            End Set
        End Property
        Public Property ProcedimientosNoSede() As List(Of ProcedimientoNoSede)
            Get
                Return _procedimientosNoSede
            End Get
            Set(ByVal value As List(Of ProcedimientoNoSede))
                _procedimientosNoSede = value
            End Set
        End Property
        Public Property Medicamentos() As List(Of Medicamento)
            Get
                Return _medicamentos
            End Get
            Set(ByVal value As List(Of Medicamento))
                _medicamentos = value
            End Set
        End Property
        ''Claudia Garay Controlados Noviembre 23 de 2010
        Public Property MedicamentosControl() As List(Of MedicamentoControl)
            Get
                Return _medicamentosControl
            End Get
            Set(ByVal value As List(Of MedicamentoControl))
                _medicamentosControl = value
            End Set
        End Property
        Public Property Diagnosticos() As List(Of Diagnostico)
            Get
                Return _Diagnosticos
            End Get
            Set(ByVal value As List(Of Diagnostico))
                _Diagnosticos = value
            End Set
        End Property
        Public Property NombreMedico() As String
            Get
                Return _nombreMedico
            End Get
            Set(ByVal value As String)
                _nombreMedico = value
            End Set
        End Property
        Public Property TipoContrato() As String
            Get
                Return _tipocontrato
            End Get
            Set(ByVal value As String)
                _tipocontrato = value
            End Set
        End Property
        Public Property Cronico() As String
            Get
                Return _cronico
            End Get
            Set(ByVal value As String)
                _cronico = value
            End Set
        End Property
        Public Property Entregas() As Integer
            Get
                Return _entregas
            End Get
            Set(ByVal value As Integer)
                _entregas = value
            End Set
        End Property
        Public ReadOnly Property IdentificacionMedico() As String
            Get
                Return _identificacionMedico
            End Get
        End Property
        Public ReadOnly Property NumDocMedico() As String
            Get
                Return _NumDocMedico
            End Get
        End Property
        Public Property RegistroMedico() As String
            Get
                Return _registroMedico
            End Get
            Set(ByVal value As String)
                _registroMedico = value
            End Set
        End Property
        Public ReadOnly Property Observaciones() As String
            Get
                Return _observaciones
            End Get
        End Property
        Public ReadOnly Property TipoUsuarioEntidad() As String
            Get
                Return _tipoUsuarioEntidad
            End Get
        End Property

        Public Property Aislamientos() As List(Of Aislamiento)
            Get
                Return _aislamientos
            End Get
            Set(value As List(Of Aislamiento))
                _aislamientos = value
            End Set
        End Property

        Public Property Dietas() As List(Of Dieta)
            Get
                Return _dietas
            End Get
            Set(ByVal Value As List(Of Dieta))
                _dietas = Value
            End Set
        End Property
        Public Property Alarma() As List(Of Alarma)
            Get
                Return _Alarma
            End Get
            Set(ByVal Value As List(Of Alarma))
                _Alarma = Value
            End Set
        End Property
        Public Property OrdenesGenerales() As List(Of OrdenGeneral)
            Get
                Return _ordenesGenerales
            End Get
            Set(ByVal Value As List(Of OrdenGeneral))
                _ordenesGenerales = Value
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
        Public Property TipoAdmision() As String
            Get
                Return _tipoAdmision
            End Get
            Set(ByVal value As String)
                _tipoAdmision = value
            End Set
        End Property
        Public Property NumeroAdmision() As Double
            Get
                Return _numeroAdmision
            End Get
            Set(ByVal value As Double)
                _numeroAdmision = value
            End Set
        End Property
        Public Property AnoAdmision() As Integer
            Get
                Return _anoAdmision
            End Get
            Set(ByVal value As Integer)
                _anoAdmision = value
            End Set
        End Property
        Public Property CodigoCentroDeCostoOrigen() As String
            Get
                Return _codCentroDeCostoOrigen
            End Get
            Set(ByVal value As String)
                _codCentroDeCostoOrigen = value
            End Set
        End Property
        Public Property DescripcionCentroDeCostoOrigen() As String
            Get
                Return _descrCentroCostoOrigen
            End Get
            Set(ByVal value As String)
                _descrCentroCostoOrigen = value
            End Set
        End Property
        Public Property EsReimpresion() As Boolean
            Get
                Return _reimpresion
            End Get
            Set(ByVal value As Boolean)
                _reimpresion = value
            End Set
        End Property
        Public Property PyP() As String
            Get
                Return _PyP
            End Get
            Set(ByVal value As String)
                _PyP = value
            End Set
        End Property
        Public Property CodigoSucursal() As String
            Get
                Return _codigoSucursal
            End Get
            Set(ByVal value As String)
                _codigoSucursal = value
            End Set
        End Property
        Public Property MotivoRemision() As String
            Get
                Return _motremision
            End Get
            Set(ByVal value As String)
                _motremision = value
            End Set
        End Property
        Public Property Plan_Manejo() As String
            Get
                Return _PlanManejo
            End Get
            Set(ByVal value As String)
                _PlanManejo = value
            End Set
        End Property
        Public Property ta_dia() As String
            Get
                Return _ta_dia
            End Get
            Set(ByVal value As String)
                _ta_dia = value
            End Set
        End Property
        Public Property ta_sis() As String
            Get
                Return _ta_sis
            End Get
            Set(ByVal value As String)
                _ta_sis = value
            End Set
        End Property
        Public Property fre_respira() As String
            Get
                Return _fre_respira
            End Get
            Set(ByVal value As String)
                _fre_respira = value
            End Set
        End Property
        Public Property fre_cardiaca() As String
            Get
                Return _fre_cardiaca
            End Get
            Set(ByVal value As String)
                _fre_cardiaca = value
            End Set
        End Property
        Public Property talla() As String
            Get
                Return _talla
            End Get
            Set(ByVal value As String)
                _talla = value
            End Set
        End Property
        Public Property peso() As String
            Get
                Return _peso
            End Get
            Set(ByVal value As String)
                _peso = value
            End Set
        End Property
        ''cpgaray Medicamentos controlados formulacion externa
        Public Property EsControlado() As String
            Get
                Return _escontrolado
            End Get
            Set(ByVal value As String)
                _escontrolado = value
            End Set
        End Property
        ''cpgaray informacion a mostrar en el encabezado del reporte
        Public Property Sexo() As String
            Get
                Return _sexo
            End Get
            Set(ByVal value As String)
                _sexo = value
            End Set
        End Property
        Public Property UnidadMedidaTiempo() As String
            Get
                Return _uni_med_tie
            End Get
            Set(ByVal value As String)
                _uni_med_tie = value
            End Set
        End Property
        Public Property Edad() As String
            Get
                Return _edad
            End Get
            Set(ByVal value As String)
                _edad = value
            End Set
        End Property
        Public Property TextoValidoPor() As String
            Get
                Return _textovalidopor
            End Get
            Set(ByVal value As String)
                _textovalidopor = value
            End Set
        End Property


        ''cpgaray 10 Febrero 2012

#End Region

        Public Sub New()
            MyBase.New()
            _procedimientos = New List(Of Procedimiento)
            'herojas agfa_orm_in 2014/09/24
            _procedimientosN = New List(Of ProcedimientoNoPractica)
            _procedimientosNoSede = New List(Of ProcedimientoNoSede)
            _medicamentos = New List(Of Medicamento)
            _Diagnosticos = New List(Of Diagnostico)
            _medicamentosControl = New List(Of MedicamentoControl)
        End Sub


#Region "Orden Procedimientos"

        Public Function crearOrdenProcedimientos(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String,
                                                 ByVal strTipAdm As String, ByVal iAno As Integer,
                                                 ByVal lNumAdm As Long, ByVal dCon_procedim As Double) As Long
            Dim dtOrden As DataTable
            Dim dtOrdenDiag As DataTable
            dtOrden = consultarOrdenProcedimientos(objConexion, strcod_pre_sgs, strCod_sucur, strTipAdm, iAno,
                                               lNumAdm, dCon_procedim)
            dtOrdenDiag = consultarOrdenDiagnosticos(objConexion, strcod_pre_sgs, strCod_sucur, strTipAdm, iAno,
                                               lNumAdm)
            If dtOrden.Rows.Count <= 0 Then
                Return 99
            End If

            inicializarOrdenProcedim(dtOrden, dtOrdenDiag)

            Return 0

        End Function

        Private Function consultarOrdenProcedimientos(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String,
                                                  ByVal strTipAdm As String, ByVal iAno As Integer,
                                                  ByVal lNumAdm As Long, ByVal dCon_procedim As Double) As DataTable

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            '' ''Dim dsetOrden As DataSet
            Dim dtOrden As DataTable = Nothing

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''Using cmd
            '' ''    cmd = db.GetStoredProcCommandWrapper("pa_Reportes_RepFomulaProcedim")

            '' ''    With cmd
            '' ''        .AddInParameter("strcod_pre_sgs", DbType.String, strcod_pre_sgs)
            '' ''        .AddInParameter("strCod_sucur", DbType.String, strCod_sucur)
            '' ''        .AddInParameter("strTipAdm", DbType.String, strTipAdm)
            '' ''        .AddInParameter("iAno", DbType.Int32, iAno)
            '' ''        .AddInParameter("lNumAdm", DbType.Double, lNumAdm)
            '' ''        .AddInParameter("dCon_procedim", DbType.Double, dCon_procedim)
            '' ''    End With

            '' ''    dsetOrden = db.ExecuteDataSet(cmd)
            '' ''    dtOrden = dsetOrden.Tables(0)
            '' ''End Using
            Dim OrigenBD As String
            Dim objDatosGenerales As objGeneral.Generales
            objDatosGenerales = objGeneral.Generales.Instancia
            OrigenBD = objDatosGenerales.OrigenAdm


            '  gpmDataObj.setSQLSentence("pa_Reportes_RepFomulaProcedim", CommandType.StoredProcedure)

            gpmDataObj.setSQLSentence("Exec " + OrigenBD + "pa_Reportes_RepFomulaProcedim " + "'" +
                                      strcod_pre_sgs + "'" + "," + "'" + strCod_sucur + "'" +
                                      "," + "'" + strTipAdm + "'" + "," + "'" + CStr(iAno) + "'" + "," +
                                      "'" + CStr(lNumAdm) + "'" + "," + "'" + CStr(dCon_procedim) + "'" + "", CommandType.Text)


            gpmDataObj.addInputParameter("strcod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            gpmDataObj.addInputParameter("strCod_sucur", SqlDbType.VarChar, strCod_sucur)
            gpmDataObj.addInputParameter("strTipAdm", SqlDbType.VarChar, strTipAdm)
            gpmDataObj.addInputParameter("iAno", SqlDbType.VarChar, iAno)
            gpmDataObj.addInputParameter("lNumAdm", SqlDbType.VarChar, lNumAdm)
            gpmDataObj.addInputParameter("dCon_procedim", SqlDbType.VarChar, dCon_procedim)

            dtOrden = gpmDataObj.execDS().Tables(0)

            Return dtOrden
        End Function

        Private Function consultarOrdenDiagnosticos(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String,
                                                  ByVal strTipAdm As String, ByVal iAno As Integer,
                                                  ByVal lNumAdm As Long) As DataTable


            Dim dtOrden As DataTable = Nothing
            Dim OrigenBD As String
            Dim objDatosGenerales As objGeneral.Generales
            objDatosGenerales = objGeneral.Generales.Instancia
            OrigenBD = objDatosGenerales.OrigenAdm


            '  gpmDataObj.setSQLSentence("pa_Reportes_RepFomulaProcedim", CommandType.StoredProcedure)

            gpmDataObj.setSQLSentence("Exec " + OrigenBD + "pa_Reportes_RepFomulaProcedim_ID " + "'" +
                                      strcod_pre_sgs + "'" + "," + "'" + strCod_sucur + "'" +
                                      "," + "'" + strTipAdm + "'" + "," + "'" + CStr(iAno) + "'" + "," +
                                      "'" + CStr(lNumAdm) + "'" + "," + "'" + strTipAdm + "'" + "", CommandType.Text)



            '   gpmDataObj.setSQLSentence("pa_Reportes_RepFomulaProcedim_ID", CommandType.StoredProcedure)
            If gpmDataObj.ParametersCollection.Count > 0 Then
                gpmDataObj.ParametersCollection.Clear()
            End If
            gpmDataObj.addInputParameter("strcod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            gpmDataObj.addInputParameter("strCod_sucur", SqlDbType.VarChar, strCod_sucur)
            gpmDataObj.addInputParameter("strTip_admision", SqlDbType.VarChar, strTipAdm)
            gpmDataObj.addInputParameter("iAno_adm", SqlDbType.Int, iAno)
            gpmDataObj.addInputParameter("lNum_Adm", SqlDbType.Decimal, lNumAdm)
            gpmDataObj.addInputParameter("strlogin", SqlDbType.VarChar, strTipAdm)

            dtOrden = gpmDataObj.execDT


            Return dtOrden
        End Function

        Public Sub inicializarOrdenProcedim(ByVal dtOrden As DataTable, ByVal dtOrdenDiag As DataTable)

            Dim fecha As Date
            Dim objPaciente As Sophia.HistoriaClinica.DatosPaciente.Paciente
            objDatosGenerales = objGeneral.Generales.Instancia

            If dtOrden.Rows.Count <= 0 Then
                Exit Sub
            End If

            With dtOrden.Rows(0)
                _numeroOrden = .Item("Con_procedim").ToString
                _compa?ia = .Item("Compania").ToString
                _nit = .Item("nit").ToString
                _sucursal = .Item("Sucursal").ToString
                _telefonoSucur = .Item("telefono").ToString
                _dirSucur = .Item("direccion").ToString
                _entidadAfilia = .Item("entidadAfilia").ToString
                _ciudad = .Item("Ciudad").ToString
                _entidadPresta = .Item("entidadpr").ToString
                objPaciente = Sophia.HistoriaClinica.DatosPaciente.Paciente.Instancia
                '_paciente = New Paciente(.Item("tipdoc").ToString, .Item("numdoc").ToString, _
                '                         nombre:=.Item("nombre").ToString, sexo:=objPaciente.DescripcionGenero, _
                '                         edad:=objPaciente.Edad, uniEdad:=objPaciente.DescripcionUnidadMedidaEdad, _
                '                         direccionCasa:=.Item("dirPaciente").ToString, telefonoCasa:=.Item("telPaciente").ToString, _
                '                         plan:=.Item("plan1").ToString, carnet:=.Item("carnet").ToString)
                _paciente = New Paciente(.Item("tipdoc").ToString, .Item("numdoc").ToString,
                                         nombre:= .Item("nombre").ToString, sexo:= .Item("desGenero").ToString,
                                         edad:= .Item("edad").ToString, uniEdad:= .Item("unidadEdad").ToString,
                                        direccionCasa:= .Item("dirPaciente").ToString, telefonoCasa:= .Item("telPaciente").ToString,
                                         plan:= .Item("plan1").ToString, carnet:= .Item("carnet").ToString)
                fecha = .Item("fecha").ToString
                _fecha = Format(fecha, "dd/MM/yyyy HH:mm")
                _procedimientos = crearListaProcedim(dtOrden)
                _nombreMedico = .Item("nombremed").ToString
                _identificacionMedico = .Item("tipdocmed").ToString & "  " & .Item("numdocmed").ToString

                If objDatosGenerales.Pais = "482" Then ''agregar segundo registro m?dico para Per?. Cpgaray Octubre 21 de 2013
                    If Len(.Item("regmed2").ToString) = 0 Then
                        _registroMedico = .Item("regmed").ToString
                    Else
                        _registroMedico = .Item("regmed").ToString & " - " & .Item("regmed2").ToString
                    End If

                Else
                    _registroMedico = .Item("regmed").ToString
                End If

                _observaciones = .Item("obs").ToString
                _PyP = .Item("PyP").ToString
                _motremision = .Item("motremision").ToString
                _PlanManejo = .Item("PlanManejo").ToString
                _ta_dia = .Item("ta_dias").ToString
                _ta_sis = .Item("ta_sist").ToString
                _fre_respira = .Item("fre_respira").ToString
                _fre_cardiaca = .Item("fre_cardiaca").ToString
                _talla = .Item("talla").ToString
                _peso = .Item("peso").ToString
                _Diagnosticos = crearListaDiagnosticos(dtOrdenDiag)
            End With

        End Sub

        Private Function crearListaProcedim(ByVal dtOrden As DataTable) As List(Of Procedimiento)
            Dim i As Integer
            Dim procedim As Procedimiento
            Dim lista As List(Of Procedimiento)

            lista = New List(Of Procedimiento)

            For i = 0 To dtOrden.Rows.Count - 1
                With dtOrden.Rows(i)
                    procedim = New Procedimiento(.Item("cod").ToString, .Item("des").ToString,
                                                 .Item("recomendacion").ToString, .Item("autorizacionEnt").ToString,
                                                 .Item("cant").ToString, , , , , .Item("resultado").ToString,
                                                 .Item("interpretacion").ToString, .Item("fecresultado").ToString)
                    procedim.Bilateral = .Item("bil").ToString
                    procedim.Observaciones = .Item("obs").ToString
                    procedim.Cod_SISPRO = .Item("autosispro").ToString
                End With

                procedim.calcularSubgrupo()
                lista.Add(procedim)
            Next

            Return lista
        End Function

        Private Function crearListaDiagnosticos(ByVal dtOrden As DataTable) As List(Of Diagnostico)
            Dim i As Integer
            Dim Diagnos As Diagnostico
            Dim lista As List(Of Diagnostico)

            lista = New List(Of Diagnostico)

            For i = 0 To dtOrden.Rows.Count - 1
                With dtOrden.Rows(i)
                    Diagnos = New Diagnostico("", .Item("Categoria").ToString, .Item("Diagnostico").ToString,
                             .Item("Descripcion").ToString, .Item("Obs").ToString, "", "", "")
                End With
                lista.Add(Diagnos)
            Next

            Return lista
        End Function

        Public Function requiereAutorizacion() As Boolean
            Dim i As Integer

            For i = 0 To _procedimientos.Count - 1
                If _procedimientos(i).Autorizacion = "S" Then
                    Return True
                End If
            Next
            Return False
        End Function

#End Region

#Region "Orden Medicamentos"

        Public Sub crearOrdenMedicamentos(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String,
                                             ByVal strTipAdm As String, ByVal iAno As Integer,
                                             ByVal lNumAdm As Long, ByVal dNroFormula As Double,
                                             ByVal esReimpresion As Boolean)

            Dim dtOrden As DataTable

            dtOrden = New DataTable


            dtOrden = consultarOrdenMedicamentos(objConexion, strcod_pre_sgs, strCod_sucur, strTipAdm, iAno, lNumAdm, dNroFormula)

            inicializarOrdenMedicamentos(dtOrden)

        End Sub

        Private Function consultarOrdenMedicamentos(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String,
                                             ByVal strTipAdm As String, ByVal iAno As Integer,
                                             ByVal lNumAdm As Long, ByVal dNroFormula As Double) As DataTable

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            '' ''Dim dsetOrden As DataSet
            Dim dtOrden As DataTable = Nothing
            Dim OrigenBD As String
            Dim objDatosGenerales As objGeneral.Generales
            objDatosGenerales = objGeneral.Generales.Instancia

            OrigenBD = objDatosGenerales.OrigenAdm


            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''cmd = db.GetStoredProcCommandWrapper("pa_Reportes_RepFormulaMedica")
            '' ''With cmd
            '' ''    .AddInParameter("strcod_pre_sgs", DbType.String, strcod_pre_sgs)
            '' ''    .AddInParameter("strCod_sucur", DbType.String, strCod_sucur)
            '' ''    .AddInParameter("strTipAdm", DbType.String, strTipAdm)
            '' ''    .AddInParameter("iAno", DbType.String, iAno)
            '' ''    .AddInParameter("lNumAdm", DbType.String, lNumAdm)
            '' ''    .AddInParameter("dNro_Formula", DbType.Double, dNroFormula)
            '' ''End With

            '' ''dsetOrden = db.ExecuteDataSet(cmd)
            '' ''dtOrden = dsetOrden.Tables(0)
            gpmDataObj.setSQLSentence(OrigenBD & "pa_Reportes_RepFormulaMedica", CommandType.StoredProcedure)
            gpmDataObj.ClearParameters()
            gpmDataObj.addInputParameter("strcod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            gpmDataObj.addInputParameter("strCod_sucur", SqlDbType.VarChar, strCod_sucur)
            gpmDataObj.addInputParameter("strTipAdm", SqlDbType.VarChar, strTipAdm)
            gpmDataObj.addInputParameter("iAno", SqlDbType.VarChar, iAno)
            gpmDataObj.addInputParameter("lNumAdm", SqlDbType.VarChar, lNumAdm)
            gpmDataObj.addInputParameter("dNro_Formula", SqlDbType.VarChar, dNroFormula)


            dtOrden = gpmDataObj.execDS().Tables(0)
            dtOrden.Columns.Add("Observ", System.Type.GetType("System.String"))

            Return dtOrden

        End Function

        Private Sub inicializarOrdenMedicamentos(ByVal dtOrden As DataTable)

            Dim fecha As Date
            objDatosGenerales = objGeneral.Generales.Instancia

            If dtOrden.Rows.Count <= 0 Then

                Exit Sub
            End If

            With dtOrden.Rows(0)
                _numeroOrden = .Item("nro_formula").ToString

                _compa?ia = .Item("compania").ToString
                _sucursal = .Item("sucursal").ToString
                _codigoSucursal = .Item("cod_sucur").ToString
                _entidadAfilia = .Item("EntAfi").ToString
                _nit = .Item("nit").ToString
                _ciudad = .Item("Ciudad").ToString
                _entidadPresta = .Item("entidadpr").ToString
                _paciente = New Paciente(.Item("tipdoc").ToString, .Item("numdoc").ToString,
                                         .Item("nombre").ToString, direccionCasa:= .Item("dirpaciente").ToString,
                                         telefonoCasa:= .Item("telpaciente").ToString, plan:= .Item("plan1").ToString,
                                         carnet:= .Item("carnet").ToString, edad:= .Item("edad").ToString,
                                         uniEdad:= .Item("UniMedtie").ToString, sexo:= .Item("sexo").ToString, fecNacim:=Format(CDate(.Item("fec_nac").ToString), "yyyy/MM/dd"))
                fecha = .Item("fecha").ToString
                _fecha = Format(fecha, "dd/MM/yyyy HH:mm")
                _medicamentos = crearListaMedicamentos(dtOrden)
                _nombreMedico = .Item("nombremed").ToString
                _tipocontrato = .Item("tipoContrato").ToString
                _identificacionMedico = .Item("tipdocmed").ToString & "  " + .Item("numdocmed").ToString
                _NumDocMedico = .Item("numdocmed").ToString
                'llarias se agrega especialidad
                _especialidad = .Item("especialidad").ToString



                If objDatosGenerales.Pais = "482" Then ''agregar segundo registro m?dico para Per?. Cpgaray Octubre 21 de 2013
                    If Len(.Item("regmed2").ToString) = 0 Then
                        _registroMedico = .Item("regmed").ToString
                    Else
                        _registroMedico = .Item("regmed").ToString & " - " & .Item("regmed2").ToString
                    End If

                Else
                    _registroMedico = .Item("regmed").ToString
                End If
                _observaciones = .Item("obs").ToString
                _nit = .Item("nit").ToString
                _telefonoSucur = .Item("telefono").ToString
                _dirSucur = .Item("direccion").ToString
                _tipoAdmision = .Item("tip_admision").ToString
                _anoAdmision = .Item("ano_adm").ToString
                _numeroAdmision = .Item("num_adm").ToString
                _cronico = .Item("Cronico").ToString
                _entregas = .Item("duraciontrat").ToString
                '_escontrolado = .Item("MedControl").ToString ''cpgaray
                '_sexo = .Item("sexo").ToString ''cpgaray
                '_uni_med_tie = .Item("UniMedtie").ToString ''cpgaray
                '_edad = .Item("edad").ToString ''cpgaray

                Select Case UCase(Mid(.Item("tip_entidad").ToString, 1, 3))
                    Case "ARS"
                        _tipoUsuarioEntidad = "SUBSIDIADO"

                    Case "EPS"
                        _tipoUsuarioEntidad = "CONTRIBUTIVO"

                    Case "PAR"
                        _tipoUsuarioEntidad = "PARTICULAR"

                    Case Else
                        _tipoUsuarioEntidad = "OTRO"

                End Select

                ''cpgaray Marzo 14 2013 

                objFormuExt = PlanFormuExterna.Instancia

                If objDatosGenerales.Pais = "482" Then


                    If .Item("TipoEntidad").ToString = "PRE" Then
                        _textovalidopor = "V?LIDO POR 72 HORAS A PARTIR DEL D?A SIGUIENTE A LA FECHA DE EXPEDICION"
                    Else
                        _textovalidopor = ""
                    End If
                Else
                    'If .Item("TipoEntidad").ToString = "EPS" Then
                    '    _textovalidopor = "V?LIDO POR 30 DIAS A PARTIR DE LA FECHA DE EXPEDICI?N"
                    'Else
                    _textovalidopor = "V?LIDO POR 72 HORAS A PARTIR DE LA FECHA DE EXPEDICI?N"
                    'End If
                End If



            End With
        End Sub

        Private Function crearListaMedicamentos(ByVal dtOrden As DataTable) As List(Of Medicamento)
            Dim i As Integer
            Dim medica As Medicamento
            Dim objNumero As New Num2Words
            Dim lista As List(Of Medicamento)

            lista = New List(Of Medicamento)

            For i = 0 To dtOrden.Rows.Count - 1
                With dtOrden.Rows(i)
                    medica = New Medicamento(.Item("cod").ToString, .Item("des").ToString,
                                               .Item("prescripcion").ToString, .Item("cant").ToString, , , , .Item("cantDisp").ToString)
                    objNumero.number = .Item("cant").ToString
                    medica.UnidadPrescripcion = .Item("DesUnidadPrescripcion").ToString
                    If .Item("cant") <> 0 Then
                        medica.CantidadLetras = objNumero.monto()
                    Else
                        medica.CantidadLetras = ""
                    End If
                    objNumero.number = .Item("cantDisp").ToString
                    medica.UnidadDispensacion = .Item("DesUnidadDispensacion").ToString
                    If .Item("cantDisp") <> 0 Then
                        medica.CantidadDispensacionLetras = objNumero.monto()
                    Else
                        medica.CantidadDispensacionLetras = ""
                    End If

                    medica.ObservacionesFormula = ""
                    ' medica.CantidadMedControl = .Item("cantidadcontrol").ToString ''cpgaray
                    ' medica.CantidadLetrasMedControl = .Item("cantidadletrascontrol").ToString ''cpgaray
                    ' medica.TiempoMedControl = .Item("tiempomedcontrol").ToString ''cpgaray
                    If i = dtOrden.Rows.Count - 1 Then
                        medica.ObservacionesFormula = dtOrden.Rows(0).Item("obs").ToString
                    End If
                End With
                lista.Add(medica)
            Next

            Return lista
        End Function

#End Region

#Region "Ordenes Medicas"
        Public Sub crearOrdenMedica(ByVal dtDietas As DataTable, ByVal dtMedicamentos As DataTable,
                                    ByVal dtProcedim As DataTable, ByVal dtOrdenGeneral As DataTable)

            _dietas = Dieta.crearListaDietas(dtDietas)
            _medicamentos = New Medicamento().crearListaMedicamentos(dtMedicamentos)
            _procedimientos = New Procedimiento().crearListaProcedimOrdenMedica(dtProcedim)
            ' herojas agfa_orm_in 2014/09/24
            _procedimientosN = New ProcedimientoNoPractica().crearListaProcedimOrdenMedicano(dtProcedim, "", "", "")
            _procedimientosNoSede = New ProcedimientoNoSede().crearListaProcedimOrdenMedicaNoSede(dtProcedim, "", "", "")
            _ordenesGenerales = OrdenGeneral.crearListaOrdenesGenerales(dtOrdenGeneral)
            _medicamentosControl = New MedicamentoControl().crearListaMedicamentos(dtMedicamentos) ''Controlados Noviembre 23 de 2010

        End Sub

        Public Function crearOrdenMedicaReimpresion(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String,
                                     ByVal cod_sucur As String, ByVal tip_admision As String, ByVal ano_adm As String,
                                     ByVal num_adm As String, ByVal NroOrden As Double, Optional ByVal strPracticaOsi As String = "") As Long

            Dim objGenerales As New DAOGeneral()
            Dim dtOrdenEncabezado As DataTable
            Dim dtCentroCostoOrigen As DataTable
            Dim dsResultado As DataSet
            Dim edad As Integer
            Dim unidadEdad As String = String.Empty
            Dim codEntidad As String
            Dim strDiagnostico As String = ""
            objDatosGenerales = objGeneral.Generales.Instancia


            dtOrdenEncabezado = objGenerales.EjecutarSPConParametros("HC_ConsultarEncabezadoOrdenPorNumero", objConexion,
                                                                     -1, cod_pre_sgs, cod_sucur, tip_admision, ano_adm,
                                                                     num_adm, NroOrden)

            If dtOrdenEncabezado.Rows.Count <= 0 Then
                Return 99
            End If

            With dtOrdenEncabezado.Rows(0)
                _tipoAdmision = tip_admision
                _anoAdmision = ano_adm
                _numeroAdmision = num_adm
                _fecha = .Item("fec_con").ToString
                _nombreMedico = .Item("NombreMedico").ToString
                _especialidad = .Item("especialidad").ToString

                If objDatosGenerales.Pais = "482" Then ''agregar segundo registro m?dico para Per?. Cpgaray Octubre 21 de 2013
                    If Len(.Item("reg_med2").ToString) = 0 Then
                        _registroMedico = .Item("reg_med").ToString
                    Else
                        objDatosGenerales.RegistroMedico = .Item("reg_med").ToString & " - " & .Item("reg_med2").ToString
                        _registroMedico = .Item("reg_med").ToString & " - " & .Item("reg_med2").ToString
                    End If

                Else
                    _registroMedico = .Item("reg_med").ToString
                End If

            End With

            dsResultado = objGenerales.EjecutarSPConParametrosDataSet("HC_ConsultarOrdenReimpresion", objConexion,
                                                                      -1, cod_pre_sgs, cod_sucur, NroOrden, _tipoAdmision,
                                                                      _anoAdmision, _numeroAdmision)

            ''Agregar el diagnostico principal a las ordenes de procedimientos


            dsResultado.Tables(4).Columns.Add("Diagnostico", System.Type.GetType("System.String"))


            If dsResultado.Tables(4).Rows.Count > 0 And dsResultado.Tables(6).Rows.Count > 0 Then


                For i As Integer = 0 To dsResultado.Tables(6).Rows.Count - 1
                    strDiagnostico = strDiagnostico & dsResultado.Tables(6).Rows(i).Item("diagnost").ToString & " " & dsResultado.Tables(6).Rows(i).Item("descripcion").ToString & " ,"
                Next

                For i As Integer = 0 To dsResultado.Tables(4).Rows.Count - 1
                    dsResultado.Tables(4).Rows(i).Item("Diagnostico") = strDiagnostico
                Next

            End If

            With dsResultado
                dtOrdenEncabezado = .Tables(0)
                _aislamientos = Aislamiento.crearListaAislamiento(.Tables(1))
                _dietas = Dieta.crearListaDietas(.Tables(2))
                _medicamentos = New Medicamento().crearListaMedicamentos(.Tables(3))
                _medicamentosControl = New MedicamentoControl().crearListaMedicamentos(.Tables(3))
                _procedimientos = New Procedimiento().crearListaProcedimOrdenMedica(.Tables(4), strPracticaOsi)
                _procedimientosN = New ProcedimientoNoPractica().crearListaProcedimOrdenMedicano(.Tables(4), "", "", "")
                _procedimientosNoSede = New ProcedimientoNoSede().crearListaProcedimOrdenMedicaNoSede(.Tables(4), "", "", "")
                _ordenesGenerales = OrdenGeneral.crearListaOrdenesGenerales(.Tables(5))
            End With

            If dtOrdenEncabezado.Rows.Count <= 0 Then
                Return 99
            End If

            With dtOrdenEncabezado.Rows(0)
                _codigoSucursal = .Item("cod_sucur").ToString 'llarias agregado c?digo sucursal para consultar carnet ya que no lo traia
                _sucursal = .Item("sucursal").ToString

                _paciente = New Paciente(.Item("tip_doc").ToString, .Item("Num_doc").ToString,
                                            nombre:= .Item("paciente").ToString, sexo:= .Item("sexo").ToString,
                                            fecNacim:= .Item("fec_nac").ToString,
                                            grupoSanguineo:= .Item("gru_sanguineo").ToString, factorRH:= .Item("rh").ToString)
                edad = _paciente.calcularEdad(.Item("fec_nac").ToString, unidadEdad)
                _paciente.Edad = edad
                _paciente.UnidadEdad = unidadEdad
                _entidadPresta = .Item("entidad").ToString
                codEntidad = .Item("codEntidad").ToString
            End With



            _numeroOrden = NroOrden
            _codCentroDeCostoOrigen = New Admision().consultarCentroDeCostoOrigen(objConexion, cod_pre_sgs, cod_sucur,
                                                                            _tipoAdmision, _anoAdmision, _numeroAdmision,
                                                                            codEntidad)
            dtCentroCostoOrigen = DAOOrdenes.traerInformacionCentroCosto(objConexion, cod_pre_sgs, cod_sucur, _codCentroDeCostoOrigen)

            If dtCentroCostoOrigen.Rows.Count > 0 Then
                _descrCentroCostoOrigen = dtCentroCostoOrigen.Rows(0).Item("Descripcion").ToString
            Else
                _descrCentroCostoOrigen = ""
            End If


            Return 0
        End Function

        Public Function crearOrdenMedicaReimpresionControl(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String,
                                     ByVal cod_sucur As String, ByVal tip_admision As String, ByVal ano_adm As String,
                                     ByVal num_adm As String, ByVal NroOrden As Double, Optional ByVal strPracticaOsi As String = "") As Long

            Dim objGenerales As New DAOGeneral()
            Dim dtOrdenEncabezado As DataTable
            Dim dtCentroCostoOrigen As DataTable
            Dim dsResultado As DataSet
            Dim edad As Integer
            Dim unidadEdad As String = String.Empty
            Dim codEntidad As String
            Dim strDiagnostico As String = ""


            objDatosGenerales = objGeneral.Generales.Instancia


            dtOrdenEncabezado = objGenerales.EjecutarSPConParametros("HC_ConsultarEncabezadoOrdenPorNumeroControl", objConexion,
                                                                     -1, cod_pre_sgs, cod_sucur, tip_admision, ano_adm,
                                                                     num_adm, NroOrden)

            If dtOrdenEncabezado.Rows.Count <= 0 Then
                Return 99
            End If

            With dtOrdenEncabezado.Rows(0)
                _tipoAdmision = tip_admision
                _anoAdmision = ano_adm
                _numeroAdmision = num_adm
                _fecha = .Item("fec_con").ToString
                _nombreMedico = .Item("NombreMedico").ToString
                _especialidad = .Item("especialidad").ToString

                If objDatosGenerales.Pais = "482" Then ''agregar segundo registro m?dico para Per?. Cpgaray Octubre 21 de 2013
                    If Len(.Item("reg_med2").ToString) = 0 Then
                        _registroMedico = .Item("reg_med").ToString
                    Else
                        objDatosGenerales.RegistroMedico = .Item("reg_med").ToString & " - " & .Item("reg_med2").ToString
                        _registroMedico = .Item("reg_med").ToString & " - " & .Item("reg_med2").ToString
                    End If

                Else
                    _registroMedico = .Item("reg_med").ToString
                End If

            End With

            dsResultado = objGenerales.EjecutarSPConParametrosDataSet("HC_ConsultarOrdenReimpresionControl", objConexion,
                                                                      -1, cod_pre_sgs, cod_sucur, NroOrden, _tipoAdmision,
                                                                      _anoAdmision, _numeroAdmision)

            ''Agregar el diagnostico principal a las ordenes de procedimientos




            With dsResultado
                dtOrdenEncabezado = .Tables(0)
                '_dietas = Dieta.crearListaDietas(.Tables(1))
                '_medicamentos = New Medicamento().crearListaMedicamentos(.Tables(2))
                _medicamentosControl = New MedicamentoControl().crearListaMedicamentos(.Tables(1))
                '_procedimientos = New Procedimiento().crearListaProcedimOrdenMedica(.Tables(3), strPracticaOsi)
                '_procedimientosN = New ProcedimientoNoPractica().crearListaProcedimOrdenMedicano(.Tables(3), "", "", "")
                '_procedimientosNoSede = New ProcedimientoNoSede().crearListaProcedimOrdenMedicaNoSede(.Tables(3), "", "", "")
                '_ordenesGenerales = OrdenGeneral.crearListaOrdenesGenerales(.Tables(4))               
            End With

            If dtOrdenEncabezado.Rows.Count <= 0 Then
                Return 99
            End If

            With dtOrdenEncabezado.Rows(0)
                _codigoSucursal = .Item("cod_sucur").ToString 'llarias agregado c?digo sucursal para consultar carnet ya que no lo traia
                _sucursal = .Item("sucursal").ToString

                _paciente = New Paciente(.Item("tip_doc").ToString, .Item("Num_doc").ToString,
                                            nombre:= .Item("paciente").ToString, sexo:= .Item("sexo").ToString,
                                            fecNacim:= .Item("fec_nac").ToString,
                                            grupoSanguineo:= .Item("gru_sanguineo").ToString, factorRH:= .Item("rh").ToString)
                edad = _paciente.calcularEdad(.Item("fec_nac").ToString, unidadEdad)
                _paciente.Edad = edad
                _paciente.UnidadEdad = unidadEdad
                _entidadPresta = .Item("entidad").ToString
                codEntidad = .Item("codEntidad").ToString
            End With


            _numeroOrden = _medicamentosControl.Item(0).NumeroOrden.ToString()
            '_numeroOrden = NroOrden
            _codCentroDeCostoOrigen = New Admision().consultarCentroDeCostoOrigen(objConexion, cod_pre_sgs, cod_sucur,
                                                                            _tipoAdmision, _anoAdmision, _numeroAdmision,
                                                                            codEntidad)
            dtCentroCostoOrigen = DAOOrdenes.traerInformacionCentroCosto(objConexion, cod_pre_sgs, cod_sucur, _codCentroDeCostoOrigen)

            If dtCentroCostoOrigen.Rows.Count > 0 Then
                _descrCentroCostoOrigen = dtCentroCostoOrigen.Rows(0).Item("Descripcion").ToString
            Else
                _descrCentroCostoOrigen = ""
            End If


            Return 0
        End Function


        Public Function crearOrdenMedicaReimpresionPeru(ByVal objConexion As Conexion, ByVal cod_pre_sgs As String,
                                     ByVal cod_sucur As String, ByVal tip_admision As String, ByVal ano_adm As String,
                                     ByVal num_adm As String) As Long

            Dim objGenerales As New DAOGeneral()
            Dim dtOrdenEncabezado As DataTable
            Dim dtCentroCostoOrigen As DataTable
            Dim dsResultado As DataSet
            Dim edad As Integer
            Dim unidadEdad As String = String.Empty
            Dim codEntidad As String
            Dim strDiagnostico As String = ""
            objDatosGenerales = objGeneral.Generales.Instancia


            dsResultado = objGenerales.EjecutarSPConParametrosDataSet("HC_ConsultarOrdenProcedimientos", objConexion,
                                                                      -1, cod_pre_sgs, cod_sucur, tip_admision,
                                                                      ano_adm, num_adm)

            If dsResultado.Tables(0).Rows.Count <= 0 Then
                Return 99
            End If

            With dsResultado.Tables(0).Rows(0)
                _tipoAdmision = tip_admision
                _anoAdmision = ano_adm
                _numeroAdmision = num_adm
                _fecha = .Item("fec_con").ToString
                _nombreMedico = .Item("NombreMedico").ToString
                _especialidad = .Item("especialidad").ToString

                If objDatosGenerales.Pais = "482" Then ''agregar segundo registro m?dico para Per?. Cpgaray Octubre 21 de 2013
                    If Len(.Item("reg_med2").ToString) = 0 Then
                        _registroMedico = .Item("reg_med").ToString
                    Else
                        _registroMedico = .Item("reg_med").ToString & " - " & .Item("reg_med2").ToString
                    End If

                Else
                    _registroMedico = .Item("reg_med").ToString
                End If
                _sucursal = .Item("sucursal").ToString
                _paciente = New Paciente(.Item("tip_doc").ToString, .Item("Num_doc").ToString,
                                            nombre:= .Item("paciente").ToString, sexo:= .Item("sexo").ToString,
                                            fecNacim:= .Item("fec_nac").ToString,
                                            grupoSanguineo:= .Item("gru_sanguineo").ToString, factorRH:= .Item("rh").ToString)
                edad = _paciente.calcularEdad(.Item("fec_nac").ToString, unidadEdad)
                _paciente.Edad = edad
                _paciente.UnidadEdad = unidadEdad
                _entidadPresta = .Item("entidad").ToString
                codEntidad = .Item("codEntidad").ToString
            End With


            ''Agregar el diagnostico principal a las ordenes de procedimientos


            dsResultado.Tables(1).Columns.Add("Diagnostico", System.Type.GetType("System.String"))


            'If dsResultado.Tables(3).Rows.Count > 0 And dsResultado.Tables(5).Rows.Count > 0 Then


            '    For i As Integer = 0 To dsResultado.Tables(5).Rows.Count - 1
            '        strDiagnostico = strDiagnostico & dsResultado.Tables(5).Rows(i).Item("diagnost").ToString & " " & dsResultado.Tables(5).Rows(i).Item("descripcion").ToString & " ,"
            '    Next

            '    For i As Integer = 0 To dsResultado.Tables(3).Rows.Count - 1
            '        dsResultado.Tables(3).Rows(i).Item("Diagnostico") = strDiagnostico
            '    Next

            'End If

            With dsResultado
                dtOrdenEncabezado = .Tables(0)
                _dietas = Nothing ''Dieta.crearListaDietas(.Tables(1))
                _medicamentos = Nothing ' New Medicamento().crearListaMedicamentos(.Tables(2))
                _medicamentosControl = Nothing 'New MedicamentoControl().crearListaMedicamentos(.Tables(2))
                _procedimientos = New Procedimiento().crearListaProcedimOrdenMedica(.Tables(1))
                _ordenesGenerales = Nothing ' OrdenGeneral.crearListaOrdenesGenerales(.Tables(4))
            End With

            'If dtOrdenEncabezado.Rows.Count <= 0 Then
            '    Return 99
            'End If

            'With dtOrdenEncabezado.Rows(0)
            '    _sucursal = .Item("sucursal").ToString
            '    _paciente = New Paciente(.Item("tip_doc").ToString, .Item("Num_doc").ToString, _
            '                                nombre:=.Item("paciente").ToString, Sexo:=.Item("sexo").ToString, _
            '                                fecNacim:=.Item("fec_nac").ToString, _
            '                                grupoSanguineo:=.Item("gru_sanguineo").ToString, factorRH:=.Item("rh").ToString)
            '    edad = _paciente.calcularEdad(.Item("fec_nac").ToString, unidadEdad)
            '    _paciente.Edad = edad
            '    _paciente.UnidadEdad = unidadEdad
            '    _entidadPresta = .Item("entidad").ToString
            '    codEntidad = .Item("codEntidad").ToString
            'End With



            _numeroOrden = "0" 'NroOrden
            _codCentroDeCostoOrigen = New Admision().consultarCentroDeCostoOrigen(objConexion, cod_pre_sgs, cod_sucur,
                                                                            _tipoAdmision, _anoAdmision, _numeroAdmision,
                                                                            codEntidad)
            dtCentroCostoOrigen = DAOOrdenes.traerInformacionCentroCosto(objConexion, cod_pre_sgs, cod_sucur, _codCentroDeCostoOrigen)

            If dtCentroCostoOrigen.Rows.Count > 0 Then
                _descrCentroCostoOrigen = dtCentroCostoOrigen.Rows(0).Item("Descripcion").ToString
            Else
                _descrCentroCostoOrigen = ""
            End If


            Return 0
        End Function


        Public Function ConsultarOrdenesMedicas(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String,
                                           ByVal strTipAdm As String, ByVal iAno As Integer, ByVal lNumAdm As Long, ByRef listaAislamientos As List(Of Aislamiento),
                                           ByRef listaDietas As List(Of Dieta), ByRef listaMedica As List(Of Medicamento), ByRef listaProcedim As List(Of Procedimiento),
                                           ByRef listaOrdenGenerales As List(Of OrdenGeneral), Optional ByRef dtEncabezadoOrden As DataTable = Nothing,
                                           Optional ByVal fec_ini As String = "", Optional ByVal fec_fin As String = "") As List(Of Orden)

            Dim row As DataRow
            Dim dsResultado As DataSet
            Dim dtOrdenes As DataTable
            Dim objGenerales As New DAOGeneral()
            Dim listaOrdenes As New List(Of Orden)
            Dim objOrden As Orden
            Dim strDiagnostico As String = "" ''cpgaray
            objDatosGenerales = objGeneral.Generales.Instancia


            If fec_ini = "" Then
                dsResultado = objGenerales.EjecutarSPConParametrosDataSet("HC_ConsultarGeneralOrdenes", objConexion, -1,
                                                                 strcod_pre_sgs, strCod_sucur, strTipAdm, iAno, lNumAdm, Nothing, Nothing)
            Else
                dsResultado = objGenerales.EjecutarSPConParametrosDataSet("HC_ConsultarGeneralOrdenes", objConexion, -1,
                                                                                 strcod_pre_sgs, strCod_sucur, strTipAdm, iAno, lNumAdm, fec_ini, fec_fin)
            End If

            ''cpgaray Nov 15 de 2012
            ''Agregar el diagnostico principal a las ordenes de procedimientos

            dsResultado.Tables(3).Columns.Add("Diagnostico", System.Type.GetType("System.String"))


            If dsResultado.Tables(3).Rows.Count > 0 And dsResultado.Tables(6).Rows.Count > 0 Then


                For i As Integer = 0 To dsResultado.Tables(6).Rows.Count - 1
                    strDiagnostico = strDiagnostico & dsResultado.Tables(6).Rows(i).Item("diagnost").ToString & " " & dsResultado.Tables(6).Rows(i).Item("descripcion").ToString & " ,"
                Next

                For i As Integer = 0 To dsResultado.Tables(3).Rows.Count - 1
                    dsResultado.Tables(3).Rows(i).Item("Diagnostico") = strDiagnostico
                Next

            End If

            With dsResultado

                dtOrdenes = .Tables(0)
                listaAislamientos = Aislamiento.crearListaAislamiento(.Tables(7))
                listaDietas = Dieta.crearListaDietas(.Tables(1))
                listaMedica = New Medicamento().crearListaMedicamentosN(.Tables(2)) ''Controlados Noviembre Claudia Garay
                listaProcedim = New Procedimiento().crearListaProcedimOrdenMedica(.Tables(3))
                listaOrdenGenerales = OrdenGeneral.crearListaOrdenesGenerales(.Tables(4))
                dtEncabezadoOrden = .Tables(5)
            End With

            dtOrdenes.Select("", "fec_con DESC")
            For Each row In dtOrdenes.Rows
                objOrden = New Orden()
                objOrden.NumeroOrden = row.Item("NroOrden").ToString
                objOrden.Fecha = row.Item("fec_con").ToString
                objOrden.NombreMedico = row.Item("NombreMedico").ToString

                If objDatosGenerales.Pais = "482" Then ''agregar segundo registro m?dico para Per?. Cpgaray Octubre 21 de 2013
                    If Len(row.Item("reg_med2").ToString) = 0 Then
                        objOrden.RegistroMedico = row.Item("reg_med").ToString
                    Else
                        objOrden.RegistroMedico = row.Item("reg_med").ToString & " - " & row.Item("reg_med2").ToString
                    End If

                Else
                    objOrden.RegistroMedico = row.Item("reg_med").ToString
                End If
                objOrden.Especialidad = row.Item("especialidad").ToString
                listaOrdenes.Add(objOrden)
            Next

            Return listaOrdenes
        End Function

        Public Function ConsultarOrdenesMedicas(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String,
                                           ByVal strTipAdm As String, ByVal iAno As Integer, ByVal lNumAdm As Long, ByRef listaProcedim As List(Of Procedimiento),
                                           Optional ByRef dtEncabezadoOrden As DataTable = Nothing,
                                           Optional ByVal fec_ini As String = "", Optional ByVal fec_fin As String = "") As List(Of Orden)

            Dim row As DataRow
            Dim dsResultado As DataSet
            Dim dtOrdenes As DataTable
            Dim objGenerales As New DAOGeneral()
            Dim listaOrdenes As New List(Of Orden)
            Dim objOrden As Orden
            Dim strDiagnostico As String = "" ''cpgaray
            objDatosGenerales = objGeneral.Generales.Instancia


            If fec_ini = "" Then
                dsResultado = objGenerales.EjecutarSPConParametrosDataSet("HC_ConsultarOrdenProcedimientos", objConexion, -1,
                                                                 strcod_pre_sgs, strCod_sucur, strTipAdm, iAno, lNumAdm, Nothing, Nothing)
            Else
                dsResultado = objGenerales.EjecutarSPConParametrosDataSet("HC_ConsultarOrdenProcedimientos", objConexion, -1,
                                                                                 strcod_pre_sgs, strCod_sucur, strTipAdm, iAno, lNumAdm, fec_ini, fec_fin)
            End If

            ''cpgaray Nov 15 de 2012
            ''Agregar el diagnostico principal a las ordenes de procedimientos

            dsResultado.Tables(1).Columns.Add("Diagnostico", System.Type.GetType("System.String"))


            'If dsResultado.Tables(3).Rows.Count > 0 And dsResultado.Tables(6).Rows.Count > 0 Then


            '    For i As Integer = 0 To dsResultado.Tables(6).Rows.Count - 1
            '        strDiagnostico = strDiagnostico & dsResultado.Tables(6).Rows(i).Item("diagnost").ToString & " " & dsResultado.Tables(6).Rows(i).Item("descripcion").ToString & " ,"
            '    Next

            '    For i As Integer = 0 To dsResultado.Tables(3).Rows.Count - 1
            '        dsResultado.Tables(3).Rows(i).Item("Diagnostico") = strDiagnostico
            '    Next

            'End If

            With dsResultado

                dtOrdenes = .Tables(0)
                'listaDietas = Dieta.crearListaDietas(.Tables(1))
                'listaMedica = New Medicamento().crearListaMedicamentosN(.Tables(2)) ''Controlados Noviembre Claudia Garay
                listaProcedim = New Procedimiento().crearListaProcedimOrdenMedica(.Tables(1))
                ' listaOrdenGenerales = OrdenGeneral.crearListaOrdenesGenerales(.Tables(4))
                dtEncabezadoOrden = .Tables(2)
            End With

            dtOrdenes.Select("", "fec_con DESC")
            For Each row In dtOrdenes.Rows
                objOrden = New Orden()
                objOrden.NumeroOrden = row.Item("NroOrden").ToString
                objOrden.Fecha = row.Item("fec_con").ToString
                objOrden.NombreMedico = row.Item("NombreMedico").ToString

                If objDatosGenerales.Pais = "482" Then ''agregar segundo registro m?dico para Per?. Cpgaray Octubre 21 de 2013
                    If Len(row.Item("reg_med2").ToString) = 0 Then
                        objOrden.RegistroMedico = row.Item("reg_med").ToString
                    Else
                        objOrden.RegistroMedico = row.Item("reg_med").ToString & " - " & row.Item("reg_med2").ToString
                    End If

                Else
                    objOrden.RegistroMedico = row.Item("reg_med").ToString
                End If
                objOrden.Especialidad = row.Item("especialidad").ToString
                listaOrdenes.Add(objOrden)
            Next

            Return listaOrdenes
        End Function
#End Region




    End Class
End Namespace
