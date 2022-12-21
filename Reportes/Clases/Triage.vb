Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    Public Class Triage
        Inherits GPMDataReport

        Private _paciente As Paciente
        Private _sucursal As String
        Private _clasificacion As String
        Private _fecha As String
        Private _hora As String
        Private _minuto As String
        Private _motivoConsulta As String
        Private _presion1 As String
        Private _presion2 As String
        Private _frecCardiaca As String
        Private _frecRespiratoria As String
        Private _temperatura As String
        Private _escalaDolor As String
        Private _estadoConciencia As String
        Private _escalaGlasgow As String
        Private _especialidadRemision As String
        Private _remitido As String
        Private _antecedentesPato As String
        Private _alergias As String
        Private _medicamentos As String
        Private _observaciones As String
        Private _tituloHallazgos As String
        Private _hallazgos As String
        Private _loginTriage As String
        Private _idTriage As String ''cpgaray enero 13 2016 OS 8261998
        Private _destino As String

        Private Const ALERTA As String = "1"
        Private Const RESPONDEAVOZ As String = "2"
        Private Const RESPONDEADOLOR As String = "3"
        Private Const INCONSCIENTE As String = "4"

#Region "Propiedades"
        Public ReadOnly Property Sucursal() As String
            Get
                Return _sucursal
            End Get
        End Property
        Public ReadOnly Property Clasificacion() As String
            Get
                Return _clasificacion
            End Get
        End Property
        Public ReadOnly Property Fecha() As String
            Get
                Return _fecha
            End Get
        End Property
        Public ReadOnly Property Hora() As String
            Get
                Return _hora
            End Get
        End Property
        Public ReadOnly Property Minuto() As String
            Get
                Return _minuto
            End Get
        End Property

        Public ReadOnly Property MotivoConsulta() As String
            Get
                Return _motivoConsulta
            End Get
        End Property
        Public ReadOnly Property Presion1() As String
            Get
                Return _presion1
            End Get
        End Property
        Public ReadOnly Property Presion2() As String
            Get
                Return _presion2
            End Get
        End Property
        Public ReadOnly Property FrecuenciaCardiaca() As String
            Get
                Return _frecCardiaca
            End Get
        End Property
        Public ReadOnly Property FrecuenciaRespiratoria() As String
            Get
                Return _frecRespiratoria
            End Get
        End Property
        Public ReadOnly Property Temperatura() As String
            Get
                Return _temperatura
            End Get
        End Property
        Public ReadOnly Property EscalaDolor() As String
            Get
                Return _escalaDolor
            End Get
        End Property
        Public ReadOnly Property EstadoDeConciencia() As String
            Get
                Return _estadoConciencia
            End Get
        End Property
        Public ReadOnly Property EscalaGlasgow() As String
            Get
                Return _escalaGlasgow
            End Get
        End Property
        Public ReadOnly Property EspecialidadRemision() As String
            Get
                Return _especialidadRemision
            End Get
        End Property
        Public ReadOnly Property Remitido() As String
            Get
                Return _remitido
            End Get
        End Property
        Public ReadOnly Property Patologias() As String
            Get
                Return _antecedentesPato
            End Get
        End Property
        Public ReadOnly Property Alergias() As String
            Get
                Return _alergias
            End Get
        End Property
        Public ReadOnly Property LoginTriage() As String
            Get
                Return _loginTriage
            End Get
        End Property
        ''cpgaray enero 13 2016 OS 8261998
        Public ReadOnly Property IDTriage() As String
            Get
                Return _idTriage
            End Get
        End Property
        Public ReadOnly Property Medicamentos() As String
            Get
                Return _medicamentos
            End Get
        End Property
        Public ReadOnly Property Observaciones() As String
            Get
                Return _observaciones
            End Get
        End Property
        Public ReadOnly Property TituloHallazgos() As String
            Get
                Return _tituloHallazgos
            End Get
        End Property
        Public ReadOnly Property Hallazgos() As String
            Get
                Return _hallazgos
            End Get
        End Property
        Public ReadOnly Property Paciente() As Paciente
            Get
                Return _paciente
            End Get
        End Property
        Public Property Destino() As String
            Get
                Return _destino
            End Get
            Set(ByVal Value As String)
                _destino = Value
            End Set
        End Property
#End Region

        Public Function llenarTriage(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String, _
                    ByVal strCod_sucur As String, ByVal strTipDoc As String, ByVal strNumDoc As String, _
                    ByVal strTipAdm As String, ByVal intAnoAdm As Integer, ByVal dNumAdm As Double, _
                    ByVal estado As String) As Boolean

            Dim dtTriage As DataTable
            Dim existenDatos As Boolean

            Try
                dtTriage = traerTriage(objConexion, strCod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, _
                                     strTipAdm, intAnoAdm, dNumAdm)

                existenDatos = inicializar(objConexion, strCod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, _
                               dtTriage, estado)

            Catch ex As Exception
                Throw ex
            End Try

            Return existenDatos
        End Function

        Private Function traerTriage(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String, _
                    ByVal strCod_sucur As String, ByVal strTipDoc As String, ByVal strNumDoc As String, _
                    ByVal strTipAdm As String, ByVal intAnoAdm As Integer, ByVal dNumAdm As Double) As DataTable

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 14/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim dtSet As DataSet

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''cmd = db.GetStoredProcCommandWrapper("dbo.pa_Reportes_RepTriage")
            '' ''With cmd
            '' ''    .AddInParameter("strCod_pre_sgs", DbType.String, strCod_pre_sgs)
            '' ''    .AddInParameter("strCod_sucur", DbType.String, strCod_sucur)
            '' ''    .AddInParameter("strTipDoc", DbType.String, strTipDoc)
            '' ''    .AddInParameter("strNumDoc", DbType.String, strNumDoc)
            '' ''    .AddInParameter("strTip_admision", DbType.String, strTipAdm)
            '' ''    .AddInParameter("iAno_adm", DbType.Int16, intAnoAdm)
            '' ''    .AddInParameter("lNum_adm", DbType.Double, dNumAdm)
            '' ''End With

            '' ''dts = db.ExecuteDataSet(cmd)

            gpmDataObj.setSQLSentence("dbo.pa_Reportes_RepTriage", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("strCod_pre_sgs", SqlDbType.VarChar, strCod_pre_sgs)
            gpmDataObj.addInputParameter("strCod_sucur", SqlDbType.VarChar, strCod_sucur)
            gpmDataObj.addInputParameter("strTipDoc", SqlDbType.VarChar, strTipDoc)
            gpmDataObj.addInputParameter("strNumDoc", SqlDbType.VarChar, strNumDoc)
            gpmDataObj.addInputParameter("strTip_admision", SqlDbType.VarChar, strTipAdm)
            gpmDataObj.addInputParameter("iAno_adm", SqlDbType.Int, intAnoAdm)
            gpmDataObj.addInputParameter("lNum_adm", SqlDbType.Decimal, dNumAdm)

            dtSet = gpmDataObj.execDS()

            Return dtSet.Tables(0)

        End Function

        Private Function inicializar(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String, ByVal strCod_sucur As String, _
                                ByVal strTipDoc As String, ByVal strNumDoc As String, _
                                ByVal dtTriage As DataTable, ByVal estado As String) As Boolean
            Dim fecha As Date
            Dim edad As Integer
            Dim unidadEdad As String = ""

            If dtTriage.Rows.Count > 0 Then
                With dtTriage.Rows(0)
                    _sucursal = .Item("Sucursal").ToString
                    _clasificacion = .Item("clasifi").ToString
                    If .Item("fecha").ToString.Length > 0 Then
                        fecha = .Item("fecha").ToString
                        _fecha = Format(fecha, "dd/MM/yyyy")
                    Else
                        _fecha = ""
                    End If
                    _hora = .Item("hora").ToString
                    _minuto = .Item("minu").ToString
                    _paciente = New Paciente(.Item("tip_doc").ToString, _
                                             .Item("num_doc").ToString, _
                                             .Item("paciente").ToString, _
                                             sexo:=.Item("Sexo").ToString)
                    edad = _paciente.calcularEdad(.Item("fec_nac").ToString, unidadEdad)
                    _paciente.Edad = edad
                    _paciente.UnidadEdad = unidadEdad
                    _motivoConsulta = .Item("motivo").ToString
                    _presion1 = .Item("presion1").ToString
                    _presion2 = .Item("presion2").ToString
                    _frecCardiaca = .Item("freccardi").ToString
                    _frecRespiratoria = .Item("frecrespi").ToString
                    _temperatura = .Item("temperatura").ToString
                    _escalaDolor = .Item("escala").ToString
                    _especialidadRemision = .Item("EspecDesc").ToString
                    _remitido = .Item("remitido").ToString
                    _observaciones = .Item("obs").ToString
                    _tituloHallazgos = ""
                    _hallazgos = ""
                    _loginTriage = .Item("LoginTriage").ToString
                    _idTriage = .Item("Documento").ToString  ''cpgaray enero 13 2016 OS 8261998
                    _destino = .Item("destino").ToString

                    If .Item("antpatol").ToString = "" Then
                        _antecedentesPato = "No Registrado"
                    Else
                        _antecedentesPato = .Item("antpatol").ToString
                    End If

                    If .Item("alergias").ToString = "" Then
                        _alergias = "No Registrado"
                    Else
                        _alergias = .Item("alergias").ToString
                    End If

                    If .Item("medicamento").ToString = "" Then
                        _medicamentos = "No Registrado"
                    Else
                        _medicamentos = .Item("medicamento").ToString
                    End If

                    If .Item("alerta").ToString = ALERTA Then
                        _estadoConciencia = "ALERTA"
                    ElseIf .Item("alerta").ToString = INCONSCIENTE Then
                        _estadoConciencia = "INCONSCIENTE"
                    ElseIf .Item("alerta").ToString = RESPONDEADOLOR Then
                        _estadoConciencia = "RESPONDE A DOLOR"
                    ElseIf .Item("alerta").ToString = RESPONDEAVOZ Then
                        _estadoConciencia = "RESPONDE A VOZ"
                    Else
                        _estadoConciencia = ""
                    End If

                    '' Se corrige para que cuando no ingresen ningún valor en la escala no muestre 0/15, se debe mostrar vacio OS9638993 cpgaray
                    If .Item("glasgow").ToString = "" Then
                        _escalaGlasgow = ""
                    Else
                        _escalaGlasgow = .Item("glasgow").ToString & " / 15"
                    End If

                    If UCase(estado) = "PEDIATRICO" Then
                        _tituloHallazgos = "EVALUACIÓN Y CLASIFICACIÓN DE TRIAGE PEDIÁTRICO : "
                        _hallazgos = traerHallazgosXUsuarioTriagePediatrico(objConexion, strCod_pre_sgs, strCod_sucur, _
                                                               strTipDoc, strNumDoc, fecha, .Item("hora").ToString, .Item("minu").ToString)
                    End If

                End With
                Return True
            Else
                Return False
            End If
        End Function
        'Public Function traerCategoriasTriagePediatrico() As DataTable
        '    Dim db As Database
        '    Dim dsCateg As DataSet
        '    Dim strSQL As String

        '    db = DatabaseFactory.CreateDatabase()
        '    strSQL = "SELECT categSintoma, descripcion FROM HCTRIAGECATEGSINTOMAS"
        '    dsCateg = db.ExecuteDataSet(System.Data.CommandType.Text, strSQL)
        '    Return dsCateg.Tables(0)

        'End Function
        'Public Function TraerSintomasTriagePediatrico() As DataTable
        '    Dim db As Database
        '    Dim dsSintomas As DataSet
        '    Dim strSQL As String

        '    db = DatabaseFactory.CreateDatabase()
        '    strSQL = "SELECT sintoma,categsintoma, descripcion,seleccionado = '' FROM hctriagesintomas"
        '    dsSintomas = db.ExecuteDataSet(System.Data.CommandType.Text, strSQL)
        '    Return dsSintomas.Tables(0)

        'End Function

        Private Function traerHallazgosXUsuarioTriagePediatrico(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String, ByVal strCod_sucur As String, _
                                ByVal strTipDoc As String, ByVal strNumDoc As String, _
                                ByVal dteFecIni As Date, ByVal iHora As Integer, _
                                ByVal iMinuto As Integer) As String

            Dim i As Integer
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim db As Database
            Dim strSQL As String
            Dim dsUsuario As DataSet
            Dim strCategoria As String
            Dim strCategoriaAnt As String
            Dim strHallazgos As String


            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)

            ''Se agrega nolock a la consulta
            ''septiembre 25 de 2009
            ''Claudia Garay

            strSQL = "select b.descripcion as sintoma, c.descripcion as categoria " & _
                     "from hcTriageSintomasxUsu a (nolock) inner join hcTriageSintomas b (nolock) on a.sintoma = b.sintoma " & _
                     "inner join hcTriageCategSintomas c (nolock) on b.categSintoma = c.CategSintoma " & _
                     "WHERE cod_pre_sgs='" & strCod_pre_sgs & "' AND cod_sucur='" & strCod_sucur & "' " & _
                     "AND tip_doc='" & strTipDoc & "' AND num_doc='" & strNumDoc & "' AND fec_ingreso='" & Format(dteFecIni, "yyyy/MM/dd") & "' " & _
                     "AND hor_ingreso=" & iHora & " AND min_ingreso=" & iMinuto

            '' ''dsUsuario = db.ExecuteDataSet(System.Data.CommandType.Text, strSQL)
            gpmDataObj.setSQLSentence(strSQL, CommandType.Text)
            dsUsuario = gpmDataObj.execDS()

            strCategoria = ""
            strCategoriaAnt = ""
            strHallazgos = ""

            For i = 0 To dsUsuario.Tables(0).Rows.Count - 1
                strCategoria = dsUsuario.Tables(0).Rows(i).Item("categoria").ToString
                If strCategoria <> strCategoriaAnt Then
                    strHallazgos = strHallazgos & vbNewLine & strCategoria & vbNewLine
                    strHallazgos = strHallazgos & "-  "
                End If
                strHallazgos = strHallazgos & Trim(dsUsuario.Tables(0).Rows(i).Item("sintoma").ToString)
                If i < dsUsuario.Tables(0).Rows.Count - 1 Then
                    strHallazgos = strHallazgos & IIf(strCategoria = dsUsuario.Tables(0).Rows(i + 1).Item("categoria").ToString, ", ", "")
                End If
                strCategoriaAnt = strCategoria
            Next
            Return strHallazgos
        End Function

    End Class
End Namespace
    