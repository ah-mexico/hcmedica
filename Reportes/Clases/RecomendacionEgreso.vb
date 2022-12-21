Imports System.Data.Common
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente

''''////
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Namespace Sophia.HistoriaClinica.Reportes
    ''' --------------------------------------------------------------------------------------------------
    ''' Project	 : HistoriaClinica.Reportes.Clases
    ''' Class	 : Sophia.HistoriaClinica.Reportes.RecomendacionEgreso
    ''' --------------------------------------------------------------------------------------------------
    ''' <summary>
    ''' Clase RecomendacionEgreso del namespace Sophia.HistoriaClinica.Reportes que es la clase base
    ''' Esta clase se utiliza para almacenar la información correspondiente a las recomendaciones
    ''' al egreso para los reportes y se utilizados en la aplicación Window 2005 
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' [mvargas]	19/05/2006 Created
    ''' </history>
    ''' ---------------------------------------------------------------------------------------------------
    Public Class RecomendacionEgreso
        Inherits GPMDataReport

        Private _descSucursal As String
        Private _nombreCompania As String
        Private _nombreUsuario As String
        Private _apellidoUsuario As String
        Private _numeroAdmision As String
        Private _tipoAdmision As String
        Private _anoAdmision As String
        Private _documentoUsuario As String
        Private _fechaIngreso As String
        Private _fechaEgreso As String
        Private _edadUsuario As String
        Private _unidadTiempo As String
        Private _numeroHabitacion As String
        Private _nombreMedico As String
        Private _documentoMedico As String
        Private _registroMedico As String
        Private _procedimientos As List(Of ObjetoSimple)
        Private _medicamentos As List(Of ObjetoAuxiliar)
        Private _consultarSiPresenta As String
        Private _fiebre As String
        Private _calorHerida As String
        Private _enrojecimiento As String
        Private _secrecion As String
        Private _actividadFisica As String
        Private _recomNutricional As String
        Private _recomGenerales As String
        Private _resultadoExamenes As String
        Private _diasIncapacidad As String
        Private _fechaControl As String
        Private _lugarControl As String
        Private _telefonoMedico As String
        Private _hora As String
        Private _con_cita As String
        Private _Entidad As String
        Private _ProgramEduca As DataTable ''Claudia Garay Acreditacion Diciembre 14 de 2010
        ''Private _ObsProgramEduca As String ''Claudia Garay Acreditacion Diciembre 14 de 2010
        Private _strConciliacionMedicamentos As String
        Private _PaisTemp As String

#Region "Propiedades"
        Public ReadOnly Property PaisTemp() As String
            Get
                Return _PaisTemp
            End Get
        End Property

        Public ReadOnly Property DescSucursal() As String
            Get
                Return _descSucursal
            End Get
        End Property

        Public ReadOnly Property NombreCompania() As String
            Get
                Return _nombreCompania
            End Get
        End Property

        Public ReadOnly Property NombreUsuario() As String
            Get
                Return _nombreUsuario
            End Get
        End Property

        Public ReadOnly Property ApellidoUsuario() As String
            Get
                Return _apellidoUsuario
            End Get
        End Property
        Public ReadOnly Property NumeroAdmision() As String
            Get
                Return _numeroAdmision
            End Get
        End Property
        Public ReadOnly Property TipoAdmision() As String
            Get
                Return _tipoAdmision
            End Get
        End Property
        Public ReadOnly Property AnoAdmision() As String
            Get
                Return _anoAdmision
            End Get
        End Property
        Public ReadOnly Property DocumentoUsuario() As String
            Get
                Return _documentoUsuario
            End Get
        End Property
        Public ReadOnly Property FechaIngreso() As String
            Get
                Return _fechaIngreso
            End Get
        End Property
        Public ReadOnly Property FechaEgreso() As String
            Get
                Return _fechaEgreso
            End Get
        End Property
        Public ReadOnly Property EdadUsuario() As String
            Get
                Return _edadUsuario
            End Get
        End Property
        Public ReadOnly Property UnidadTiempo() As String
            Get
                Return _unidadTiempo
            End Get
        End Property
        Public ReadOnly Property NumeroHabitacion() As String
            Get
                Return _numeroHabitacion
            End Get
        End Property
        Public ReadOnly Property NombreMedico() As String
            Get
                Return _nombreMedico
            End Get
        End Property
        Public ReadOnly Property DocumentoMedico() As String
            Get
                Return _documentoMedico
            End Get
        End Property
        Public ReadOnly Property RegistroMedico() As String
            Get
                Return _registroMedico
            End Get
        End Property

        Public ReadOnly Property Procedimientos() As List(Of ObjetoSimple)
            Get
                Return _procedimientos
            End Get
        End Property
        Public ReadOnly Property Medicamentos() As List(Of ObjetoAuxiliar)
            Get
                Return _medicamentos
            End Get
        End Property

        Public ReadOnly Property ConsultarSiPresenta() As String
            Get
                Return _consultarSiPresenta
            End Get
        End Property

        Public ReadOnly Property Fiebre() As String
            Get
                Return _fiebre
            End Get
        End Property

        Public ReadOnly Property CalorEnHerida() As String
            Get
                Return _calorHerida
            End Get
        End Property

        Public ReadOnly Property Enrojecimiento() As String
            Get
                Return _enrojecimiento
            End Get
        End Property

        Public ReadOnly Property Secrecion() As String
            Get
                Return _secrecion
            End Get
        End Property

        Public ReadOnly Property ActividadFisica() As String
            Get
                Return _actividadFisica
            End Get
        End Property

        Public ReadOnly Property RecomendacionNutricional() As String
            Get
                Return _recomNutricional
            End Get
        End Property

        Public ReadOnly Property RecomendacionGeneral() As String
            Get
                Return _recomGenerales
            End Get
        End Property

        Public ReadOnly Property ResultadoExamenes() As String
            Get
                Return _resultadoExamenes
            End Get
        End Property

        Public ReadOnly Property DiasIncapacidad() As String
            Get
                Return _diasIncapacidad
            End Get
        End Property

        Public ReadOnly Property FechaControl() As String
            Get
                Return _fechaControl
            End Get
        End Property

        Public ReadOnly Property LugarControl() As String
            Get
                Return _lugarControl
            End Get
        End Property

        Public ReadOnly Property TelefonoMedico() As String
            Get
                Return _telefonoMedico
            End Get
        End Property

        Public ReadOnly Property Hora() As String
            Get
                Return _hora
            End Get
        End Property

        Public ReadOnly Property Consecutivo() As String
            Get
                Return _con_cita
            End Get
        End Property

        Public ReadOnly Property Entidad() As String
            Get
                Return _Entidad
            End Get
        End Property
        Public ReadOnly Property ProgramaEducacion() As DataTable
            Get
                Return _ProgramEduca
            End Get
        End Property
        ''cpgaray
        Public ReadOnly Property ConciliacionMedicamentos() As String
            Get
                Return _strConciliacionMedicamentos
            End Get
        End Property
        'Public ReadOnly Property ObsProgramaEducacion() As String
        '    Get
        '        Return _ObsProgramEduca
        '    End Get
        'End Property
#End Region

        Public Sub New()

        End Sub
        Public Sub New(ByVal strCompania As String, ByVal strNombreUsuario As String, ByVal strApellidoUsuario As String,
        ByVal strNumeroAdmision As String, ByVal strDocumentoUsurio As String, ByVal strFechaIngreso As String,
        ByVal strFechaEgreso As String, ByVal strEdadUsuario As String, ByVal strNumeroHabitacion As String,
        ByVal strNombreMedico As String, ByVal strDocumentoMedico As String, ByVal strRegistroMedico As String,
        ByVal strUnidadTiempo As String, ByVal Procedimiento As List(Of ObjetoSimple), ByVal Medicamento As List(Of ObjetoAuxiliar), ByVal ProgramaEdu As String, ByVal ObsPE As String, ByVal strPais As String)
            _nombreCompania = strCompania
            _nombreUsuario = strNombreUsuario
            _apellidoUsuario = strApellidoUsuario
            _numeroAdmision = strNumeroAdmision
            _documentoUsuario = strDocumentoUsurio
            _fechaIngreso = strFechaIngreso
            _fechaEgreso = strFechaEgreso
            _edadUsuario = strEdadUsuario
            _numeroHabitacion = strNumeroHabitacion
            _nombreMedico = strNombreMedico
            _documentoMedico = strDocumentoMedico
            _registroMedico = strRegistroMedico
            _unidadTiempo = strUnidadTiempo
            _procedimientos = New List(Of ObjetoSimple)
            _medicamentos = New List(Of ObjetoAuxiliar)
            _PaisTemp = strPais
            '_ProgramEduca = ProgramaEdu
            '_ObsProgramEduca = ObsPE
        End Sub
        Public Function crearRecomendacionEgreso(ByVal strCodigoPrestador As String, ByVal strCodigoSucursal As String,
                                            ByVal strTipDoc As String, ByVal strNumDoc As String,
                                            ByVal strTipAdm As String, ByVal iAnoAdm As Integer,
                                            ByVal lNumAdm As Long, ByVal objRecomendacion As RecomEgreso) As Boolean
            Dim ds As DataSet
            Dim dtRec As New DataTable
            Dim dtProc As New DataTable
            Dim dtFor As New DataTable
            Dim dtProEdu As New DataTable



            ds = consultarRecomendacionEgreso(strCodigoPrestador, strCodigoSucursal, strTipDoc, strNumDoc,
                                              strTipAdm, iAnoAdm, lNumAdm)

            Try
                dtRec = ds.Tables(0)
            Catch ex As Exception
            End Try

            Try
                dtFor = ds.Tables(1)
            Catch ex As Exception
            End Try
            Try
                dtProc = ds.Tables(2)
            Catch ex As Exception
            End Try
            Try
                dtProEdu = ds.Tables(3)
            Catch ex As Exception
            End Try

            Return inicializarRecomendacion(dtRec, objRecomendacion, dtFor, dtProc, dtProEdu)

        End Function
        Private Function consultarRecomendacionEgreso(ByVal strCodigoPrestador As String, ByVal strCodigoSucursal As String,
                                              ByVal strTipDoc As String, ByVal strNumDoc As String,
                                              ByVal strTipAdm As String, ByVal iAnoAdm As Integer,
                                               ByVal lNumAdm As Long) As DataSet

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 14/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim dtSet As DataSet
            Dim objC As objCon = objCon.Instancia
            Dim strsql As String
            Dim TbHorMin As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim Hora As String
            Dim Minuto As String
            Dim dtRec As DataTable
            Dim fecha As String

            Dim OrigenBD As String
            Dim objDatosGenerales As objGeneral.Generales
            objDatosGenerales = objGeneral.Generales.Instancia
            OrigenBD = objDatosGenerales.OrigenAdm

            fecha = ""




            '' ''db = DynamicDatabaseFactory.CreateDatabase(objC.strServidor, objC.strBaseDatos, objC.strUsuarioBD, objC.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''Using cmd
            '' ''    cmd = db.GetStoredProcCommandWrapper("HC_Reportes_RecomendacionEgreso")

            '' ''    With cmd
            '' ''        .AddInParameter("strCodigoPrestador", DbType.String, strCodigoPrestador)
            '' ''        .AddInParameter("strCodigoSucursal", DbType.String, strCodigoSucursal)
            '' ''        .AddInParameter("strTipoDocumento", DbType.String, strTipDoc)
            '' ''        .AddInParameter("strNumDoc", DbType.String, strNumDoc)
            '' ''        .AddInParameter("strTipoAdmision", DbType.String, strTipAdm)
            '' ''        .AddInParameter("lAnoAdmision", DbType.Int32, iAnoAdm)
            '' ''        .AddInParameter("dNumeroAdmision", DbType.Double, lNumAdm)
            '' ''    End With

            '' ''    ds = db.ExecuteDataSet(cmd)
            '' ''End Using

            ' gpmDataObj.setSQLSentence("HC_Reportes_RecomendacionEgreso", CommandType.StoredProcedure)

            gpmDataObj.setSQLSentence("Exec " + OrigenBD + "HC_Reportes_RecomendacionEgreso " + "'" +
                                      strCodigoPrestador + "'" + "," + "'" + strCodigoSucursal + "'" +
                                     "," + "'" + strTipDoc + "'" + "," + "'" + strNumDoc + "'" +
                                      "," + "'" + strTipAdm + "'" + "," + "'" + CStr(iAnoAdm) + "'" + "," +
                                      "'" + CStr(lNumAdm) + "'" + "", CommandType.Text)
            gpmDataObj.addInputParameter("strCodigoPrestador", SqlDbType.VarChar, strCodigoPrestador)
            gpmDataObj.addInputParameter("strCodigoSucursal", SqlDbType.VarChar, strCodigoSucursal)
            gpmDataObj.addInputParameter("strTipoDocumento", SqlDbType.VarChar, strTipDoc)
            gpmDataObj.addInputParameter("strNumDoc", SqlDbType.VarChar, strNumDoc)
            gpmDataObj.addInputParameter("strTipoAdmision", SqlDbType.VarChar, strTipAdm)
            gpmDataObj.addInputParameter("lAnoAdmision", SqlDbType.Int, iAnoAdm)
            gpmDataObj.addInputParameter("dNumeroAdmision", SqlDbType.Decimal, lNumAdm)

            dtSet = gpmDataObj.execDS()



            ''Claudia Garay
            ''17 Septiembre 2009
            ''Consultar la hora de la cita de control

            dtRec = dtSet.Tables(0)

            ''Validacion que determina si existen datos para el paciente en recomendaciones al egreso
            ''Claudia Garay
            ''01 feb 2010
            If dtRec.Rows.Count > 0 Then
                If dtRec.Rows(0).Item("FechaProxCtrl").ToString <> "" Then
                    fecha = " and a.fec_ingreso='" & Format(CDate(dtRec.Rows(0).Item("FechaProxCtrl").ToString), "yyyy/MM/dd") & "'"

                End If

                TbHorMin = obj.EjecutarSQLConParametros("admlises a (nolock) inner join hcRecomendacionAlegreso b (nolock)" &
                         " on a.cod_pre_sgs=b.cod_pre_sgs and a.cod_sucur=b.cod_sucur and a.tip_admision=b.tip_admision", objC, "a.hor_ingreso,a.min_ingreso,a.con_cita", " b.tip_admision='" & strTipAdm & "' and b.ano_adm='" & iAnoAdm & "'and b.num_adm='" & lNumAdm &
                         "' and a.medico='" & objGeneral.Generales.Instancia.Login & "'and a.num_doc='" & strNumDoc & "'" + fecha)



                If TbHorMin.Rows.Count > 0 Then

                    Hora = TbHorMin.Rows(0).Item(0).ToString
                    Minuto = TbHorMin.Rows(0).Item(1).ToString
                    _con_cita = TbHorMin.Rows(0).Item(2).ToString

                    If Minuto < 10 Then
                        _hora = Hora & ":0" & Minuto
                    Else
                        _hora = Hora & ":" & Minuto
                    End If

                Else
                    _hora = ""
                End If
            End If
            Return dtSet
        End Function

        Public Function inicializarRecomendacion(ByVal dtRec As DataTable, ByVal objRecomendacion As RecomEgreso,
                                            ByVal dtFor As DataTable, ByVal dtProc As DataTable, ByVal dtProEdu As DataTable) As Boolean
            Dim objRE As RecomendacionEgreso
            Dim listaRE As New List(Of RecomendacionEgreso)

            If dtRec.Rows.Count <= 0 Then
                Return False
            End If

            With dtRec.Rows(0)
                _descSucursal = .Item("descSucursal").ToString
                _nombreCompania = .Item("Empresa").ToString
                _nombreUsuario = .Item("Nombre").ToString
                _apellidoUsuario = .Item("Apellido").ToString
                _tipoAdmision = .Item("TipoAdmision").ToString
                _anoAdmision = .Item("AnoAdmision").ToString
                _numeroAdmision = .Item("NumeroAdmision").ToString()
                _documentoUsuario = .Item("NumeroDocumento").ToString
                _fechaIngreso = .Item("FechaIngreso").ToString
                _fechaEgreso = .Item("FechaEgreso").ToString
                _edadUsuario = .Item("edad").ToString
                _numeroHabitacion = .Item("Habitacion").ToString
                _nombreMedico = .Item("NombreMedico").ToString
                _documentoMedico = .Item("DocumentoMedico").ToString

                If objGeneral.Generales.Instancia.Pais = "482" Then ''agregar segundo registro médico para Perú. Cpgaray Octubre 21 de 2013
                    If Len(.Item("RegistroMedico2").ToString) = 0 Then
                        _registroMedico = .Item("RegistroMedico").ToString
                    Else
                        _registroMedico = .Item("RegistroMedico").ToString & " - " & .Item("RegistroMedico2").ToString
                    End If

                Else
                    _registroMedico = .Item("RegistroMedico").ToString
                End If
                _unidadTiempo = .Item("UnidadTiempo").ToString
                _procedimientos = crearListaProcedim(dtProc)
                _medicamentos = crearListaMedicamentos(dtFor)
                _consultarSiPresenta = .Item("SignosAlarma").ToString
                _strConciliacionMedicamentos = IIf(IsDBNull(.Item("con_med").ToString), "", .Item("con_med").ToString) ''cpgaray

                _fiebre = .Item("Fiebre").ToString
                If _fiebre = "N" Then
                    _fiebre = ""
                ElseIf _fiebre = "S" Then
                    _fiebre = "SI"
                End If

                _calorHerida = .Item("CalorHerida").ToString
                If _calorHerida = "N" Then
                    _calorHerida = ""
                ElseIf _calorHerida = "S" Then
                    _calorHerida = "SI"
                End If

                _enrojecimiento = .Item("EnrojeHerida").ToString
                If _enrojecimiento = "N" Then
                    _enrojecimiento = ""
                ElseIf _enrojecimiento = "S" Then
                    _enrojecimiento = "SI"
                End If

                _secrecion = .Item("SecrecionHerida").ToString
                If _secrecion = "N" Then
                    _secrecion = ""
                ElseIf _secrecion = "S" Then
                    _secrecion = "SI"
                End If

                _actividadFisica = .Item("ActividadFisica").ToString
                _recomNutricional = .Item("RecomendacionNut").ToString
                _recomGenerales = .Item("RecomendacionGral").ToString
                _resultadoExamenes = .Item("ResultadoExamenes").ToString
                _diasIncapacidad = .Item("dias_incapa").ToString
                _fechaControl = .Item("FechaProxCtrl").ToString
                If IsDate(_fechaControl) Then
                    _fechaControl = Format(CDate(_fechaControl), "dd/MM/yyyy")
                End If
                _lugarControl = .Item("LugarProxCtrl").ToString
                _telefonoMedico = .Item("TelefonosMedico").ToString
                _PaisTemp = objGeneral.Generales.Instancia.Pais '.Item("Pais").ToString
            End With

            'objRE = New RecomendacionEgreso(_nombreCompania, _nombreUsuario, _apellidoUsuario, _numeroAdmision, _documentoUsuario, _
            '        _fechaIngreso, _fechaEgreso, _edadUsuario, _numeroHabitacion, _nombreMedico, _documentoMedico, _registroMedico, _unidadTiempo, _
            '        _procedimientos, _medicamentos, dtRec.Rows(i).Item("DescrPrograma").ToString, dtRec.Rows(i).Item("obsPrograma").ToString)

            _ProgramEduca = dtProc
            '_ObsProgramEduca = dtRec.Rows(i).Item("obsPrograma").ToString

            ''Ingresado por Claudia Garay
            ''Se agrega campo de entidad al reporte
            ''Solicitado por Ricardo Zaldua
            ''28/12/2009
            _Entidad = objPaciente.Paciente.Instancia.DescripcionEntidad

            Return True

        End Function

        Private Function crearListaProcedim(ByVal dtProc As DataTable) As List(Of ObjetoSimple)
            '// Crear la lista para los procedimientos \\
            Dim i As Integer
            Dim obj As ObjetoSimple
            Dim lista As List(Of ObjetoSimple)

            lista = New List(Of ObjetoSimple)

            If Not IsNothing(dtProc) Then



                For i = 0 To dtProc.Rows.Count - 1
                    obj = New ObjetoSimple
                    obj.strDato = i
                    obj.strValor = dtProc.Rows(i).Item("Procedimiento").ToString()
                    lista.Add(obj)
                Next

            End If

            Return lista
        End Function


        Private Function crearListaMedicamentos(ByVal dtFor As DataTable) As List(Of ObjetoAuxiliar)
            '// Crear la lista para los medicamentos \\
            Dim i As Integer
            Dim obj As ObjetoAuxiliar
            Dim lista As List(Of ObjetoAuxiliar)

            lista = New List(Of ObjetoAuxiliar)
            If Not IsNothing(dtFor) Then


                For i = 0 To dtFor.Rows.Count - 1
                    obj = New ObjetoAuxiliar
                    obj.strDatoAux = i
                    obj.strValorAux = dtFor.Rows(i).Item("Medicamento").ToString()
                    lista.Add(obj)
                Next

            End If

            Return lista
        End Function
    End Class

End Namespace
