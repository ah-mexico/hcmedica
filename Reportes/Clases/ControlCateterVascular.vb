Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports System.Collections.Generic
Imports System.Data.Common


Namespace Sophia.HistoriaClinica.Reportes
    ''' <summary>
    ''' Clase que encapsula los datos de una nota de evolucion
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ControlCateterVascular
        Inherits GPMDataReport

        Private _Cod_Historia As Integer
        Private _Consecutivo As String
        Private _desc_tipocateter As String
        Private _fecha As String
        Private _hora_cateter As String
        Private _min_cateter As String
        Private _calibre As Decimal
        Private _luzcateter As String
        Private _viainsercion As String
        Private _lateralidad As String
        Private _login As String
        Private _desc_sitioinsercion As String
        Private _desc_tecinsercion As String
        Private _numpuntuacion As String
        Private _controlradio As String
        Private _localizacion As String
        Private _desc_complicacion As String
        Private _desc_indicacion As String
        Private _Consecutivo_seg As String
        Private _desc_estadoinsercion As String
        Private _fechaSegui As String
        Private _hora_segcateter As Integer
        Private _min_segcateter As Integer
        Private _obsseg As String
        Private _loginseg As String
        Private _elementosusados As String
        Private _desc_causaretiro As String
        Private _fecha_retiro As String
        Private _hora_retiro As Integer
        Private _min_retiro As Integer
        Private _DuracionH As Integer
        Private _login_retiro As String











#Region "Propiedades"
        Public Property Cod_Historia() As Integer
            Get
                Return _Cod_Historia
            End Get
            Set(ByVal value As Integer)
                _Cod_Historia = value
            End Set
        End Property
        Public Property Consecutivo() As String
            Get
                Return _Consecutivo
            End Get
            Set(ByVal value As String)
                _Consecutivo = value
            End Set
        End Property
        Public Property Desc_tipocateter() As String
            Get
                Return _desc_tipocateter
            End Get
            Set(ByVal value As String)
                _desc_tipocateter = value
            End Set
        End Property
        Public Property Fecha() As String
            Get
                Return _fecha
            End Get
            Set(ByVal value As String)
                _fecha = value
            End Set
        End Property
        Public Property Hora_cateter() As String
            Get
                Return _hora_cateter
            End Get
            Set(ByVal value As String)
                _hora_cateter = value
            End Set
        End Property
        Public Property Min_cateter() As Integer
            Get
                Return _min_cateter
            End Get
            Set(ByVal value As Integer)
                _min_cateter = value
            End Set
        End Property
        Public Property Calibre() As Integer
            Get
                Return _calibre
            End Get
            Set(ByVal value As Integer)
                _calibre = value
            End Set
        End Property
        Public Property Luzcateter() As Integer
            Get
                Return _luzcateter
            End Get
            Set(ByVal value As Integer)
                _luzcateter = value
            End Set
        End Property
        Public Property Viainsercion() As String
            Get
                Return _viainsercion
            End Get
            Set(ByVal value As String)
                _viainsercion = value
            End Set
        End Property
        Public Property Lateralidad() As String
            Get
                Return _lateralidad
            End Get
            Set(ByVal value As String)
                _lateralidad = value
            End Set
        End Property
        Public Property Login() As String
            Get
                Return _login
            End Get
            Set(ByVal value As String)
                _login = value
            End Set
        End Property
        Public Property Desc_sitioinsercion() As String
            Get
                Return _desc_sitioinsercion
            End Get
            Set(ByVal value As String)
                _desc_sitioinsercion = value
            End Set
        End Property
        Public Property Desc_tecinsercion() As String
            Get
                Return _desc_tecinsercion
            End Get
            Set(ByVal value As String)
                _desc_tecinsercion = value
            End Set
        End Property
        Public Property Numpuntuacion() As String ''cpgaray OS 776455 se cambia tipo de dato
            Get
                Return _numpuntuacion
            End Get
            Set(ByVal value As String)
                _numpuntuacion = value
            End Set
        End Property
        Public Property Controlradio() As String
            Get
                Return _controlradio
            End Get
            Set(ByVal value As String)
                _controlradio = value
            End Set
        End Property
        Public Property Localizacion() As String
            Get
                Return _localizacion
            End Get
            Set(ByVal value As String)
                _localizacion = value
            End Set
        End Property
        Public Property Desc_complicacion() As String
            Get
                Return _desc_complicacion
            End Get
            Set(ByVal value As String)
                _desc_complicacion = value
            End Set
        End Property
        Public Property CosecutivoSeg() As String
            Get
                Return _Consecutivo_seg
            End Get
            Set(ByVal value As String)
                _Consecutivo_seg = value
            End Set
        End Property
        Public Property Desc_EstadoInsercion() As String
            Get
                Return _desc_estadoinsercion
            End Get
            Set(ByVal value As String)
                _desc_estadoinsercion = value
            End Set
        End Property
        Public Property Fecha_seguimiento() As String
            Get
                Return _fechaSegui
            End Get
            Set(ByVal value As String)
                _fechaSegui = value
            End Set
        End Property
        Public Property HoraSeguimiento() As Integer
            Get
                Return _hora_segcateter
            End Get
            Set(ByVal value As Integer)
                _hora_segcateter = value
            End Set
        End Property
        Public Property MinSeguimiento() As Integer
            Get
                Return _min_segcateter
            End Get
            Set(ByVal value As Integer)
                _min_segcateter = value
            End Set
        End Property
        Public Property ObsSeguimiento() As String
            Get
                Return _obsseg
            End Get
            Set(ByVal value As String)
                _obsseg = value
            End Set
        End Property
        Public Property LoginSeguimiento() As String
            Get
                Return _loginseg
            End Get
            Set(ByVal value As String)
                _loginseg = value
            End Set
        End Property
        Public Property ElementosUsados() As String
            Get
                Return _elementosusados
            End Get
            Set(ByVal value As String)
                _elementosusados = value
            End Set
        End Property
        Public Property Desc_indicacion() As String
            Get
                Return _desc_indicacion
            End Get
            Set(ByVal value As String)
                _desc_indicacion = value
            End Set
        End Property
        Public Property Desc_CausaRetiro() As String
            Get
                Return _desc_causaretiro
            End Get
            Set(ByVal value As String)
                _desc_causaretiro = value
            End Set
        End Property
        Public Property Fecha_Retiro() As String
            Get
                Return _fecha_retiro
            End Get
            Set(ByVal value As String)
                _fecha_retiro = value
            End Set
        End Property
        Public Property HoraRetiro() As Integer
            Get
                Return _hora_retiro
            End Get
            Set(ByVal value As Integer)
                _hora_retiro = value
            End Set
        End Property
        Public Property Min_Retiro() As Integer
            Get
                Return _min_retiro
            End Get
            Set(ByVal value As Integer)
                _min_retiro = value
            End Set
        End Property
        Public Property DuracionH() As Integer
            Get
                Return _DuracionH
            End Get
            Set(ByVal value As Integer)
                _DuracionH = value
            End Set
        End Property
        Public Property LoginRetiro() As String
            Get
                Return _login_retiro
            End Get
            Set(ByVal value As String)
                _login_retiro = value
            End Set
        End Property
#End Region
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal intCod_Historia As Integer, ByVal intConsecutivo As Integer, ByVal strdesc_tipocateter As String, ByVal fdtfecha As DateTime, _
                       ByVal strhora_cateter As String, ByVal strmin_cateter As String, ByVal intcalibre As Decimal, _
                       ByVal strluzcateter As String, ByVal strviainsercion As String, ByVal strlateralidad As String, _
                       ByVal strdesc_sitioinsercion As String, ByVal strdesc_tecinsercion As String, ByVal strnumpuntuacion As String, _
                       ByVal strcontrolradio As String, ByVal strlocalizacion As String, ByVal strdesc_complicacion As String, _
                       ByVal strdesc_indicacion As String)

            _Cod_Historia = intCod_Historia
            _Consecutivo = intConsecutivo
            _desc_tipocateter = strdesc_tipocateter
            _fecha = Format(fdtfecha, "dd/MM/yyyy")
            _hora_cateter = strhora_cateter
            _min_cateter = strmin_cateter
            _calibre = intcalibre
            _luzcateter = strluzcateter
            _viainsercion = strviainsercion
            _lateralidad = strlateralidad
            _desc_sitioinsercion = strdesc_sitioinsercion
            _desc_tecinsercion = strdesc_tecinsercion
            _numpuntuacion = strnumpuntuacion
            _controlradio = strcontrolradio
            _localizacion = strlocalizacion
            _desc_complicacion = strdesc_complicacion
            _desc_indicacion = strdesc_indicacion
        End Sub
        Public Function consultarInsercionCateter(ByVal objConexion As Conexion, _
                                              ByVal dCod_Historia As Integer) As List(Of ControlCateterVascular)
            Dim dtReader As DbDataReader
            Dim objinsertaCateter As ControlCateterVascular
            Dim listainsertaCateter As New List(Of ControlCateterVascular)
            Dim lError As Long = 0
            gpmDataObj.setSQLSentence("HCENF_reporteInsercioncateter", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("@intCod_Historia", SqlDbType.Int, dCod_Historia)
            gpmDataObj.addInputParameter("lError", SqlDbType.Int, lError)
            dtReader = gpmDataObj.ExecRdr()
            While dtReader.Read()
                objinsertaCateter = New ControlCateterVascular(dtReader("cod_historia").ToString, dtReader("Consecutivo").ToString, _
                                                   dtReader("desc_tipocateter").ToString, dtReader("fecha").ToString, _
                                                   dtReader("hora_cateter").ToString, dtReader("min_cateter").ToString, _
                                                   dtReader("calibre").ToString, dtReader("luzcateter").ToString, _
                                                   dtReader("viainsercion").ToString, dtReader("lateralidad").ToString, _
                                                   dtReader("desc_sitioinsercion").ToString, dtReader("desc_tecinsercion").ToString, _
                                                   dtReader("numpuntuacion").ToString, dtReader("controlradio").ToString, _
                                                   dtReader("localizacion").ToString, dtReader("desc_complicacion").ToString, _
                                                   dtReader("desc_indicacion").ToString)
                listainsertaCateter.Add(objinsertaCateter)
            End While

            If dtReader.IsClosed = False Then
                dtReader.Close()
            End If
            Return listainsertaCateter
        End Function
        Public Function consultarControlCateterVascular(ByVal objConexion As Conexion, ByVal dCod_Historia As Integer, ByVal strFechaIni As Nullable(Of Date), ByVal strFechaFin As Nullable(Of Date), ByVal iHoraIni As Nullable(Of Integer), ByVal iHoraFin As Nullable(Of Integer)) As DataTable
            Dim lError As Long = 0
            Dim DS As DataSet
            Dim DT As DataTable
            gpmDataObj.setSQLSentence("HCENF_ReporteControlCateterVascular", CommandType.StoredProcedure)
            gpmDataObj.addInputParameter("@intCod_Historia", SqlDbType.Int, dCod_Historia)
            gpmDataObj.addInputParameter("@strFechaIni", SqlDbType.DateTime, strFechaIni)
            gpmDataObj.addInputParameter("@strFechaFin", SqlDbType.DateTime, strFechaFin)
            gpmDataObj.addInputParameter("@iHoraIni", SqlDbType.Int, iHoraIni)
            gpmDataObj.addInputParameter("@iHoraFin", SqlDbType.Int, iHoraFin)
            gpmDataObj.addInputParameter("lError", SqlDbType.Int, lError)
            DS = gpmDataObj.execDS


            Return DT
        End Function
        ''Claudia Garay
        Public Function consultarControlCateterVascular_1(ByVal objConexion As Conexion, ByVal dCod_Historia As Integer, ByVal strFechaIni As Nullable(Of Date), ByVal strFechaFin As Nullable(Of Date), ByVal iHoraIni As Nullable(Of Integer), ByVal iHoraFin As Nullable(Of Integer)) As List(Of ControlCateterVascular)
            Dim lError As Long = 0
            Dim dsCateter As DataSet
            Dim dtcateter As DataTable
            Dim drFila As DataRow
            Dim objCateter As ControlCateterVascular
            Dim listaCateter As New List(Of ControlCateterVascular)

            gpmDataObj.setSQLSentence("HCENF_ReporteControlCateterVascular_1", CommandType.StoredProcedure)
            gpmDataObj.addInputParameter("@Cod_historia", SqlDbType.Int, dCod_Historia)
            'gpmDataObj.addInputParameter("@strFechaIni", SqlDbType.DateTime, strFechaIni)
            'gpmDataObj.addInputParameter("@strFechaFin", SqlDbType.DateTime, strFechaFin)
            'gpmDataObj.addInputParameter("@iHoraIni", SqlDbType.Int, iHoraIni)
            'gpmDataObj.addInputParameter("@iHoraFin", SqlDbType.Int, iHoraFin)
            'gpmDataObj.addInputParameter("lError", SqlDbType.Int, lError)

            dsCateter = gpmDataObj.execDS
            dtcateter = ConcatenarInsercionCateter(dsCateter.Tables(0), dsCateter.Tables(1), dsCateter.Tables(2))
            dtcateter = ConcatenarElementosUsadosCateter(dtcateter, dsCateter.Tables(3))

            For i As Integer = 0 To dtcateter.Rows.Count - 1
                objCateter = New ControlCateterVascular
                With objCateter
                    .Cod_Historia = dtcateter.Rows(i).Item("cod_historia")
                    .Consecutivo = IIf(IsDBNull(dtcateter.Rows(i).Item("Consecutivo")), "", dtcateter.Rows(i).Item("Consecutivo"))
                    .Desc_tipocateter = IIf(IsDBNull(dtcateter.Rows(i).Item("desc_tipocateter")), "", dtcateter.Rows(i).Item("desc_tipocateter"))
                    .Calibre = IIf(IsDBNull(dtcateter.Rows(i).Item("calibre")), 0, dtcateter.Rows(i).Item("calibre"))
                    .Luzcateter = IIf(IsDBNull(dtcateter.Rows(i).Item("luzcateter")), "", dtcateter.Rows(i).Item("luzcateter"))
                    .Viainsercion = IIf(IsDBNull(dtcateter.Rows(i).Item("viainsercion")), "", dtcateter.Rows(i).Item("viainsercion"))
                    .Lateralidad = IIf(IsDBNull(dtcateter.Rows(i).Item("lateralidad")), "", dtcateter.Rows(i).Item("lateralidad"))
                    .Login = IIf(IsDBNull(dtcateter.Rows(i).Item("login")), "", dtcateter.Rows(i).Item("login"))
                    .Fecha = IIf(IsDBNull(dtcateter.Rows(i).Item("fecha")), "", dtcateter.Rows(i).Item("fecha"))
                    .Hora_cateter = IIf(IsDBNull(dtcateter.Rows(i).Item("hora_cateter")), 0, dtcateter.Rows(i).Item("hora_cateter"))
                    .Min_cateter = IIf(IsDBNull(dtcateter.Rows(i).Item("min_cateter")), 0, dtcateter.Rows(i).Item("min_cateter"))
                    .Desc_sitioinsercion = IIf(IsDBNull(dtcateter.Rows(i).Item("desc_sitioinsercion")), "", dtcateter.Rows(i).Item("desc_sitioinsercion"))
                    .Desc_tecinsercion = IIf(IsDBNull(dtcateter.Rows(i).Item("desc_tecinsercion")), "", dtcateter.Rows(i).Item("desc_tecinsercion"))
                    .Numpuntuacion = IIf(IsDBNull(dtcateter.Rows(i).Item("numpuntuacion")), 0, dtcateter.Rows(i).Item("numpuntuacion"))
                    .Controlradio = IIf(IsDBNull(dtcateter.Rows(i).Item("controlradio")), "", dtcateter.Rows(i).Item("controlradio"))
                    .Localizacion = IIf(IsDBNull(dtcateter.Rows(i).Item("localizacion")), "", dtcateter.Rows(i).Item("localizacion"))
                    .Desc_indicacion = IIf(IsDBNull(dtcateter.Rows(i).Item("indicacion")), "", dtcateter.Rows(i).Item("indicacion"))
                    .Desc_complicacion = IIf(IsDBNull(dtcateter.Rows(i).Item("complicacion")), "", dtcateter.Rows(i).Item("complicacion"))
                    .CosecutivoSeg = IIf(IsDBNull(dtcateter.Rows(i).Item("Consecutivo_seg")), "", dtcateter.Rows(i).Item("Consecutivo_seg"))
                    .Desc_EstadoInsercion = IIf(IsDBNull(dtcateter.Rows(i).Item("desc_estadoinsercion")), "", dtcateter.Rows(i).Item("desc_estadoinsercion"))
                    .Fecha_seguimiento = IIf(IsDBNull(dtcateter.Rows(i).Item("FechaSegui")), "", dtcateter.Rows(i).Item("FechaSegui"))
                    .HoraSeguimiento = IIf(IsDBNull(dtcateter.Rows(i).Item("hora_segcateter")), 0, dtcateter.Rows(i).Item("hora_segcateter"))
                    .MinSeguimiento = IIf(IsDBNull(dtcateter.Rows(i).Item("min_segcateter")), 0, dtcateter.Rows(i).Item("min_segcateter"))
                    .ObsSeguimiento = IIf(IsDBNull(dtcateter.Rows(i).Item("obsSeg")), "", dtcateter.Rows(i).Item("obsSeg"))
                    .LoginSeguimiento = IIf(IsDBNull(dtcateter.Rows(i).Item("LoginSeg")), "", dtcateter.Rows(i).Item("LoginSeg"))
                    .ElementosUsados = IIf(IsDBNull(dtcateter.Rows(i).Item("ElementosUsados")), "", dtcateter.Rows(i).Item("ElementosUsados"))
                    .Desc_CausaRetiro = IIf(IsDBNull(dtcateter.Rows(i).Item("desc_causaretiro")), "", dtcateter.Rows(i).Item("desc_causaretiro"))
                    .Fecha_Retiro = IIf(IsDBNull(dtcateter.Rows(i).Item("fecha_retiro")), "", dtcateter.Rows(i).Item("fecha_retiro"))
                    .HoraRetiro = IIf(IsDBNull(dtcateter.Rows(i).Item("hora_retiro")), 0, dtcateter.Rows(i).Item("hora_retiro"))
                    .Min_Retiro = IIf(IsDBNull(dtcateter.Rows(i).Item("min_retiro")), 0, dtcateter.Rows(i).Item("min_retiro"))
                    .DuracionH = IIf(IsDBNull(dtcateter.Rows(i).Item("DuracionH")), 0, dtcateter.Rows(i).Item("DuracionH"))
                    .LoginRetiro = IIf(IsDBNull(dtcateter.Rows(i).Item("login_retiro")), "", dtcateter.Rows(i).Item("login_retiro"))
                End With
                listaCateter.Add(objCateter)
            Next

            Return listaCateter



        End Function
        Private Function ConcatenarElementosUsadosCateter(ByVal dtSegui As DataTable, ByVal dtElement As DataTable) As DataTable
            Dim dtCat As DataTable = dtSegui.Clone
            Dim strElementos As String = ""
            Dim strComplicacion As String = ""
            Dim dtFil As DataTable = dtElement.Clone


            If dtSegui.Rows.Count > 0 Then
                ''Elementos usados
                For i As Integer = 0 To dtSegui.Rows.Count - 1
                    If Not IsDBNull(dtSegui.Rows(i).Item("Consecutivo_seg")) Then
                        strElementos = filtrarTabla(dtElement, "consecutivo=" & dtSegui.Rows(i).Item("consecutivo") & " and Consecutivo_seg= " & dtSegui.Rows(i).Item("Consecutivo_seg"), dtFil, "desc_elemenusu")
                        dtSegui.Rows(i).Item("ElementosUsados") = strElementos
                        dtFil.Clear()
                    End If
                   
                Next
            End If

            Return dtSegui
        End Function
        Private Function ConcatenarInsercionCateter(ByVal dtInsercion As DataTable, ByVal dtIndicacion As DataTable, ByVal dtComplicacion As DataTable) As DataTable
            Dim dtCat As DataTable = dtInsercion.Clone
            Dim strIndicacion As String = ""
            Dim strComplicacion As String = ""
            Dim dtFil As DataTable = dtIndicacion.Clone
            Dim dtFilC As DataTable = dtComplicacion.Clone

            If dtInsercion.Rows.Count > 0 Then
                ''Indicacion
                For i As Integer = 0 To dtInsercion.Rows.Count - 1
                    strIndicacion = filtrarTabla(dtIndicacion, "consecutivo=" & dtInsercion.Rows(i).Item("consecutivo"), dtFil, "desc_indicacion")
                    dtInsercion.Rows(i).Item("indicacion") = strIndicacion
                    dtFil.Clear()
                Next
                ''Complicacion 
                For i As Integer = 0 To dtInsercion.Rows.Count - 1
                    strComplicacion = filtrarTabla(dtComplicacion, "consecutivo=" & dtInsercion.Rows(i).Item("consecutivo"), dtFilC, "desc_complicacion")
                    dtInsercion.Rows(i).Item("complicacion") = strComplicacion
                    dtFilC.Clear()
                Next


            End If

            Return dtInsercion
        End Function
        Private Function ConcatenarSeguimiento(ByVal dtInsercion As DataTable, ByVal dtSeguimiento As DataTable, ByVal dtElementos As DataTable) As DataTable
            Dim dtCat As DataTable = dtInsercion.Clone
            Dim strIndicacion As String = ""
            Dim strElementos As String = ""
            Dim dtFil As DataTable = dtSeguimiento.Clone
            Dim dtFilC As DataTable = dtElementos.Clone
            Dim dtseguim As New DataTable

            If dtInsercion.Rows.Count > 0 Then
                ''Seguimiento

                For i As Integer = 0 To dtInsercion.Rows.Count - 1
                    dtseguim = CopiarSeguimiento(dtSeguimiento, "consecutivo=" & dtInsercion.Rows(i).Item("consecutivo"), dtFil, "desc_estadoinsercion")
                    dtInsercion.Rows(i).Item("desc_estadoinsercion") = dtseguim.Rows(0).Item("desc_estadoinsercion")
                    dtInsercion.Rows(i).Item("fechaSeg") = dtseguim.Rows(0).Item("fecha")
                    dtInsercion.Rows(i).Item("HoraSeg") = dtseguim.Rows(0).Item("hora_Segcateter")
                    dtInsercion.Rows(i).Item("MinSeg") = dtseguim.Rows(0).Item("min_segcateter")
                    dtInsercion.Rows(i).Item("obsSeg") = dtseguim.Rows(0).Item("obs")
                    dtInsercion.Rows(i).Item("LoginSeg") = dtseguim.Rows(0).Item("Login")
                    dtFil.Clear()
                Next

                For i As Integer = 0 To dtInsercion.Rows.Count - 1
                    strIndicacion = filtrarTabla(dtSeguimiento, "consecutivo=" & dtInsercion.Rows(i).Item("consecutivo"), dtFil, "desc_estadoinsercion")
                    dtInsercion.Rows(i).Item("desc_estadoinsercion") = strIndicacion
                    dtFil.Clear()
                Next
                ''Elementos Usados 
                For i As Integer = 0 To dtInsercion.Rows.Count - 1
                    strElementos = filtrarTabla(dtElementos, "consecutivo=" & dtInsercion.Rows(i).Item("consecutivo"), dtFilC, "desc_elemenusu")
                    dtInsercion.Rows(i).Item("ElementosUsados") = strElementos
                    dtFilC.Clear()
                Next


            End If

            Return dtInsercion
        End Function
        Private Function filtrarTabla(ByVal dtBase As DataTable, ByVal filtro As String, ByVal dtContenedor As DataTable, ByVal item As String) As String

            Dim rowsFiltradas() As DataRow
            Dim descripcion As String = ""
            rowsFiltradas = dtBase.Select(filtro)
            dtContenedor = FuncionesGenerales.copyArrayToDataTable(dtContenedor, rowsFiltradas)

            For i As Integer = 0 To dtContenedor.Rows.Count - 1
                descripcion = descripcion & dtContenedor.Rows(i).Item(item) & " - "
            Next

            Return descripcion
        End Function
        Private Function CopiarSeguimiento(ByVal dtBase As DataTable, ByVal filtro As String, ByVal dtContenedor As DataTable, ByVal item As String) As DataTable

            Dim rowsFiltradas() As DataRow
            Dim descripcion As String = ""
            rowsFiltradas = dtBase.Select(filtro)

            dtContenedor = FuncionesGenerales.copyArrayToDataTable(dtContenedor, rowsFiltradas)

            Return dtContenedor
        End Function
        Private Function filtrarTablaComplicacion(ByVal dtBase As DataTable, ByVal filtro As String, ByVal dtContenedor As DataTable) As String

            Dim rowsFiltradas() As DataRow
            Dim descripcion As String = ""
            rowsFiltradas = dtBase.Select(filtro)
            dtContenedor = FuncionesGenerales.copyArrayToDataTable(dtContenedor, rowsFiltradas)

            For i As Integer = 0 To dtContenedor.Rows.Count - 1
                descripcion = descripcion & dtContenedor.Rows(i).Item("desc_complicacion") & " - "
            Next

            Return descripcion
        End Function

        Private Function filtrarElementosUsados(ByVal dtBase As DataTable, ByVal filtro As String, ByVal dtContenedor As DataTable) As String

            Dim rowsFiltradas() As DataRow
            Dim descripcion As String = ""
            rowsFiltradas = dtBase.Select(filtro)
            dtContenedor = FuncionesGenerales.copyArrayToDataTable(dtContenedor, rowsFiltradas)

            For i As Integer = 0 To dtContenedor.Rows.Count - 1
                descripcion = descripcion & dtContenedor.Rows(i).Item("desc_elemenusu") & " - "
            Next

            Return descripcion
        End Function


    End Class
End Namespace
