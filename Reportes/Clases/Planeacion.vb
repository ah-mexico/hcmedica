Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports System.Collections.Generic
Imports System.Data.Common
''Claudia Garay Planeacion de medicamentos
Namespace Sophia.HistoriaClinica.Reportes
    ''' <summary>
    ''' Clase que encapsula los datos de una nota de evolucion
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Planeacion
        Inherits GPMDataReport

        Private _fecha As String    'Fecha de planeacion
        Private _descripcion As String 'Descripcion de planeacion
        Private _descripcionplaneado As String 'Descripcion de planeacion
        Private _medicamento As String 'Descripcion del medicamento
        Private _medico As String 'Descripcion del medicamento
        Private _obs As String 'Descripcion del medicamento
        Private _hora As String 'Descripcion del medicamento
        Private _estado As String 'Descripcion del medicamento

#Region "Propiedades"

        Public Property fecha() As String
            Get
                Return _fecha
            End Get
            Set(ByVal value As String)
                _fecha = value
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
        Public Property DescripcionPlaneado() As String
            Get
                Return _descripcionplaneado
            End Get
            Set(ByVal value As String)
                _descripcionplaneado = value
            End Set
        End Property
        Public Property Estado() As String
            Get
                Return _estado
            End Get
            Set(ByVal value As String)
                _estado = value
            End Set
        End Property
        Public Property Hora() As String
            Get
                Return _hora
            End Get
            Set(ByVal value As String)
                _hora = value
            End Set
        End Property
        Public Property Obs() As String
            Get
                Return _obs
            End Get
            Set(ByVal value As String)
                _obs = value
            End Set
        End Property
        Public Property Medico() As String
            Get
                Return _medico
            End Get
            Set(ByVal value As String)
                _medico = value
            End Set
        End Property
        Public Property Medicamento() As String
            Get
                Return _medicamento
            End Get
            Set(ByVal value As String)
                _medicamento = value
            End Set
        End Property
#End Region

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal dfecha As DateTime, ByVal sDescr As String, ByVal smedicamento As String, ByVal sestado As String, ByVal shora As String, ByVal smedico As String, ByVal sobs As String, ByVal sdescplanea As String)

            _fecha = dfecha
            _descripcion = sDescr
            _medicamento = smedicamento
            _estado = sestado
            _hora = shora
            _medico = smedico
            _obs = sobs
            _descripcionplaneado = sdescplanea
        End Sub

        Public Function consultarPlaneacionMedicamentos(ByVal objConexion As Conexion, ByVal dCod_Historia As Decimal, ByVal strFechaIni_RecNac As String, ByVal strFechaFin_RecNac As String, ByVal iHoraIni_RecNac As Integer, ByVal iHoraFin_RecNac As Integer) As List(Of Planeacion)

            Dim dtReader As DbDataReader
            Dim objplaneacion As Planeacion
            Dim listaPlaneacion As New List(Of Planeacion)
            Dim lError As Long = 0

            gpmDataObj.setSQLSentence("HCENFREP_TraePlaneacionMedicamento", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("@intCodhistoria", SqlDbType.Int, dCod_Historia)
            gpmDataObj.addInputParameter("lError", SqlDbType.Int, lError)

            dtReader = gpmDataObj.ExecRdr()


            While dtReader.Read()
                objplaneacion = New Planeacion(CDate(dtReader("fecha").ToString), dtReader("cargo").ToString,
                dtReader("medicamento").ToString, dtReader("estado").ToString, dtReader("hora").ToString,
                dtReader("medico").ToString, dtReader("obs").ToString, dtReader("MedPlaneados").ToString)
                listaPlaneacion.Add(objplaneacion)
            End While

            If dtReader.IsClosed = False Then
                dtReader.Close()
            End If

            Return listaPlaneacion

        End Function


        Public Function consultarPlaneacionDT(ByVal objConexion As Conexion, ByVal dCod_Historia As Integer, ByVal strFechaIni_RecNac As Nullable(Of DateTime), ByVal strFechaFin_RecNac As Nullable(Of DateTime), ByVal iHoraIni_RecNac As Nullable(Of Integer), ByVal iHoraFin_RecNac As Nullable(Of Integer)) As List(Of Planeacion)
            Dim listaPlaneacion As New List(Of Planeacion)
            Dim lError As Long = 0
            Dim dtReader As DataTable
            Dim objPlaneacion As Planeacion
            Dim drFila As DataRow


            gpmDataObj.setSQLSentence("HCENFREP_TraePlaneacionYAdministracionMedicamento", CommandType.StoredProcedure)
            gpmDataObj.addInputParameter("@intCodhistoria", SqlDbType.Int, dCod_Historia)
            gpmDataObj.addInputParameter("@strFechaIni", SqlDbType.DateTime, strFechaIni_RecNac)
            gpmDataObj.addInputParameter("@strFechaFin", SqlDbType.DateTime, strFechaFin_RecNac)
            'gpmDataObj.addInputParameter("@strFechaIni", SqlDbType.DateTime, Format(strFechaIni_RecNac.Value, "yyyy/MM/dd"))
            'gpmDataObj.addInputParameter("@strFechaFin", SqlDbType.DateTime, Format(strFechaFin_RecNac.Value, "yyyy/MM/dd"))
            gpmDataObj.addInputParameter("@iHoraIni", SqlDbType.Int, iHoraIni_RecNac)
            gpmDataObj.addInputParameter("@iHoraFin", SqlDbType.Int, iHoraFin_RecNac)
            gpmDataObj.addOutputParameter("@lError", SqlDbType.Int, lError)
            dtReader = gpmDataObj.execDT
            ''dtReader = Configuradescripcionconcatenada(dtReader)

            For Each drFila In dtReader.Rows
                objPlaneacion = New Planeacion
                With objPlaneacion
                    .Descripcion = drFila.Item("desc_administrados").ToString
                    .fecha = drFila.Item("Fecha").ToString
                    .Medicamento = drFila.Item("descprograma").ToString
                    .DescripcionPlaneado = drFila.Item("desc_planeados").ToString
                    ' .Estado = drFila.Item("estado").ToString
                    '.Hora = drFila.Item("hora").ToString
                    ' .Obs = drFila.Item("obs").ToString
                    '.Medico = drFila.Item("login").ToString
                End With
                listaPlaneacion.Add(objPlaneacion)
            Next
            Return listaPlaneacion

        End Function

        'Private Function Configuradescripcionconcatenada(ByVal dttable As DataTable) As DataTable
        '    Dim dtconfig As DataTable = dttable.Clone
        '    Dim codMed As String
        '    Dim fecha As String
        '    Dim dtRow As DataRow
        '    Dim descr As String = ""
        '    Dim cont As Integer = 0

        '    If dttable.Rows.Count > 0 Then
        '        dtRow = dtconfig.NewRow
        '        dtconfig.Rows.Add(dtRow)
        '        dtconfig.Rows(0).Item("Fecha") = dttable.Rows(0).Item("Fecha")
        '        dtconfig.Rows(0).Item("cod_programa") = dttable.Rows(0).Item("cod_programa")
        '        dtconfig.Rows(0).Item("medicamento") = dttable.Rows(0).Item("medicamento")
        '        dtconfig.Rows(0).Item("Planeacion") = dttable.Rows(0).Item("Planeacion")
        '        For i As Integer = 0 To dttable.Rows.Count - 1
        '            codMed = dttable.Rows(i).Item("cod_programa")
        '            fecha = dttable.Rows(i).Item("Fecha")
        '            ''And dtconfig.Rows(cont).Item("Fecha") = fecha 
        '            If dtconfig.Rows(cont).Item("cod_programa") = codMed Then
        '                descr = descr & dttable.Rows(i).Item("Planeacion") & ", "
        '                dtconfig.Rows(cont).Item("Planeacion") = descr
        '            Else
        '                dtconfig.Rows.Add(dtconfig.NewRow)
        '                cont = cont + 1
        '                dtconfig.Rows(cont).Item("Fecha") = dttable.Rows(i).Item("Fecha")
        '                dtconfig.Rows(cont).Item("cod_programa") = dttable.Rows(i).Item("cod_programa")
        '                dtconfig.Rows(cont).Item("medicamento") = dttable.Rows(i).Item("medicamento")
        '                dtconfig.Rows(cont).Item("Planeacion") = dttable.Rows(i).Item("Planeacion")

        '                descr = ""
        '            End If

        '        Next

        '    End If
        '    Return dtconfig
        'End Function
        Private Function Configuradescripcionconcatenada(ByVal dttable As DataTable) As DataTable
            Dim dtconfig As DataTable = dttable.Clone
            Dim dtCopyplaneado As DataTable = dttable.Clone
            Dim dtCopyAdmin As DataTable = dttable.Clone
            Dim codMed As String
            Dim fecha As String
            Dim dtRow As DataRow
            Dim descr As String = ""
            Dim cont As Integer = 0
            Dim contP As Integer = 0


            If dttable.Rows.Count > 0 Then
                dtRow = dtconfig.NewRow
                dtconfig.Rows.Add(dtRow)
                dtconfig.Rows(0).Item("Fecha") = dttable.Rows(0).Item("Fecha")
                dtconfig.Rows(0).Item("cod_programa") = dttable.Rows(0).Item("cod_programa")
                dtconfig.Rows(0).Item("medicamento") = dttable.Rows(0).Item("medicamento")

                For i As Integer = 0 To dttable.Rows.Count - 1
                    codMed = dttable.Rows(i).Item("cod_programa")
                    fecha = dttable.Rows(i).Item("Fecha")
                    ''And dtconfig.Rows(cont).Item("Fecha") = fecha 
                    If dtconfig.Rows(cont).Item("cod_programa") = codMed Then
                        ''                        descr = descr & dttable.Rows(i).Item("HoraPlaneacion") & dttable.Rows(i).Item("Planeacion") & dttable.Rows(i).Item("EstadoP") & dttable.Rows(i).Item("obs") & ", "
                        If dttable.Rows(i).Item("EstadoPlanea") = "P" Then
                            ''descr = descr & dttable.Rows(i).Item("HoraPlaneacion") & dttable.Rows(i).Item("Planeacion") & dttable.Rows(i).Item("EstadoP") & dttable.Rows(i).Item("obs") & ", "
                            dtconfig.Rows(cont).Item("MedPlaneados") = dtconfig.Rows(cont).Item("MedPlaneados") & " " & dttable.Rows(i).Item("HoraPlaneacion") & " " & dttable.Rows(i).Item("obs") & ",  "
                            dtconfig.Rows(cont).Item("login") = dttable.Rows(i).Item("planeacion")
                        Else
                            'descr = descr & dttable.Rows(i).Item("horaAdmin") & dttable.Rows(i).Item("Planeacion") & dttable.Rows(i).Item("EstadoP") & dttable.Rows(i).Item("obs") & ", "
                            dtconfig.Rows(cont).Item("MedAdmin") = dtconfig.Rows(cont).Item("MedAdmin") & " " & dttable.Rows(i).Item("horaAdmin") & " " & dttable.Rows(i).Item("Planeacion") & " " & dttable.Rows(i).Item("EstadoP") & " " & dttable.Rows(i).Item("obs") & ",  "
                        End If

                    Else
                        dtconfig.Rows.Add(dtconfig.NewRow)
                        cont = cont + 1
                        dtconfig.Rows(cont).Item("Fecha") = dttable.Rows(i).Item("Fecha")
                        dtconfig.Rows(cont).Item("cod_programa") = dttable.Rows(i).Item("cod_programa")
                        dtconfig.Rows(cont).Item("medicamento") = dttable.Rows(i).Item("medicamento")
                        If dttable.Rows(i).Item("EstadoPlanea") = "P" Then
                            dtconfig.Rows(cont).Item("MedPlaneados") = dttable.Rows(i).Item("HoraPlaneacion") & " " & dttable.Rows(i).Item("obs") & ",  "
                            dtconfig.Rows(cont).Item("login") = dttable.Rows(i).Item("planeacion")
                        Else
                            dtconfig.Rows(cont).Item("MedAdmin") = dttable.Rows(i).Item("horaAdmin") & " " & dttable.Rows(i).Item("Planeacion") & " " & dttable.Rows(i).Item("EstadoP") & " " & dttable.Rows(i).Item("obs") & ",  "
                        End If

                        descr = ""
                    End If

                Next
            End If

            Return dtconfig
        End Function

        ''REQUERIMIENTON DE LIQUIDO DANIEL IG
        Public Shared Function obtenerFecha(ByVal fecDato As Date) As String

            Dim fecha As String = String.Empty
            Dim fCalculo As Date = fecDato

            fecha = fCalculo.Year.ToString()

            If fCalculo.Month().ToString().Length() = 1 Then

                fecha = fecha + "0" + fCalculo.Month().ToString()

            Else

                fecha = fecha + fCalculo.Month().ToString()

            End If

            If fCalculo.Day().ToString().Length() = 1 Then

                fecha = fecha + "0" + fCalculo.Day.ToString()

            Else

                fecha = fecha + fCalculo.Day.ToString()

            End If

            Return fecha

        End Function


        ''Se crea metodo para obtener diferencia de dias entre 2 fechas - dsanchez 11/09/2017
        Public Shared Function obtenerDiferenciaDia(ByVal fechaInicial As String, ByVal fechaFinal As String) As Integer

            Dim resultado As Integer = 0
            Dim daobasica As New HistoriaClinica.DAO.DAOHistoriaBasica()


            resultado = daobasica.ObtenerDiferenciaDias(fechaInicial, fechaFinal)

            Return resultado

        End Function


        ' Se crea metodo para obtener peso del paciente - control de liquidos - dsanchez 21/08/2017
        Public Shared Function ObtenerPeso(ByVal prestador As String, ByVal sucursal As String, ByVal numAdmision As Double, ByVal anoAdmision As Integer, ByVal tipoAdmision As String) As String

            Dim dtInfo As DataTable = New DataTable
            Dim daobasica As New HistoriaClinica.DAO.DAOHistoriaBasica()
            Dim resultado As String = String.Empty

            dtInfo = daobasica.ObtenerPesoPaciente(prestador, sucursal, numAdmision, anoAdmision, tipoAdmision)

            For Each fila As DataRow In dtInfo.Rows

                resultado = fila("peso").ToString()

            Next

            If resultado = String.Empty Then

                resultado = "0"

            End If

            Return resultado

        End Function

        ''Se crea metodo para obtener la edad del paciente - dsanchez 15/09/2017
        Public Shared Function ObtenerEdadPaciente(ByVal prestador As String, ByVal sucursal As String, ByVal numAdmision As Double, ByVal anoAdmision As Integer, ByVal tipAdmision As String) As Integer

            Dim resultado As Integer = 0
            Dim daobasica As New HistoriaClinica.DAO.DAOHistoriaBasica()

            resultado = daobasica.ObtenerEdadPaciente(prestador, sucursal, numAdmision, anoAdmision, tipAdmision)

            Return resultado

        End Function

    End Class





End Namespace