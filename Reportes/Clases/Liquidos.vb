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
    Public Class Liquidos
        Inherits GPMDataReport

        Private _codLiquidoAdmin As String
        Private _descripcionAdmin As String
        Private _cantidadAdmin As String
        Private _hora As String
        Private _fecha As String
        Private _tipo As String
        Private _elemento As String
        Private _usuario As String
        Private _cantidadAdminTotal As String

#Region "Propiedades"
        Public Property Elemento() As String
            Get
                Return _elemento
            End Get
            Set(ByVal value As String)
                _elemento = value
            End Set
        End Property

        Public Property Usuario() As String
            Get
                Return _usuario
            End Get
            Set(ByVal value As String)
                _usuario = value
            End Set
        End Property

        Public Property Tipo() As String
            Get
                Return _tipo
            End Get
            Set(ByVal value As String)
                _tipo = value
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
        Public Property Hora() As String
            Get
                Return _hora
            End Get
            Set(ByVal value As String)
                _hora = value
            End Set
        End Property

        Public Property CodLiquidoAdministrado() As String
            Get
                Return _codLiquidoAdmin
            End Get
            Set(ByVal value As String)
                _codLiquidoAdmin = value
            End Set
        End Property

        Public Property DescripcionAdmin() As String
            Get
                Return _descripcionAdmin
            End Get
            Set(ByVal value As String)
                _descripcionAdmin = value
            End Set
        End Property

        Public Property CantidadAdmin() As String ''Cpgaray Se cambia tipo de dato 2012-03-07
            Get
                Return _cantidadAdmin
            End Get
            Set(ByVal value As String)
                _cantidadAdmin = value
            End Set
        End Property
        Public Property CantidadAdminTotal() As String
            Get
                Return _cantidadAdminTotal
            End Get
            Set(ByVal value As String)
                _cantidadAdminTotal = value
            End Set
        End Property

#End Region

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal nCodigoAdmin12 As String, ByVal nDescrAdmin12 As String, ByVal ncantidadAdmin12 As Double,
        ByVal nCodigoAdmin18 As String, ByVal nDescrAdmin18 As String, ByVal ncantidadAdmin18 As Double, ByVal nCodigoAdmin24 As String, ByVal nDescrAdmin24 As String, ByVal ncantidadAdmin24 As Double,
        ByVal nCodigoElim As String, ByVal nDescrElim As String, ByVal ncantidadElim As Double, ByVal nHora As String)

            _codLiquidoAdmin = nCodigoAdmin12
            _descripcionAdmin = nDescrAdmin24
            _cantidadAdmin = ncantidadAdmin24
            _hora = nHora

        End Sub

        Public Function consultarLiquidosAdministrados(ByVal objConexion As Conexion, ByVal dCod_Historia As Decimal, ByVal strFechaIni_RecNac As String, ByVal strFechaFin_RecNac As String, ByVal iHoraIni_RecNac As Integer, ByVal iHoraFin_RecNac As Integer) As List(Of Liquidos)

            Dim dtReader As DbDataReader
            Dim objLiqui As Liquidos
            Dim listaLiquidos As New List(Of Liquidos)
            Dim lError As Long = 0

            gpmDataObj.setSQLSentence("HCENFREP_TraerLiquidosAdmin", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("@intCodhistoria", SqlDbType.Int, dCod_Historia)
            gpmDataObj.addInputParameter("lError", SqlDbType.Int, lError)

            dtReader = gpmDataObj.ExecRdr()


            'While dtReader.Read()
            '    objLiqui = New Liquidos(dtReader("cod_liquido").ToString, dtReader("descripcion").ToString, _
            '    dtReader("cantidad").ToString, "", "", "")
            'End While

            If dtReader.IsClosed = False Then
                dtReader.Close()
            End If

            Return listaLiquidos

        End Function

        Public Function consultarLiquidosAdmin(ByVal objConexion As Conexion, ByVal dCod_Historia As Integer, ByVal fechaInicial As String, ByVal tipo As String, ByVal cantDias As Integer) As List(Of Liquidos)
            Dim listaLiquidos As New List(Of Liquidos)
            Dim lError As Long = 0
            Dim dtReader As DataTable
            Dim objLiquidos As Liquidos
            Dim drFila As DataRow


            gpmDataObj.ClearParameters()
            gpmDataObj.setSQLSentence("HCENF_ReporteLiquidosAdministrados", CommandType.StoredProcedure)
            gpmDataObj.addInputParameter("@fecha", SqlDbType.VarChar, fechaInicial)
            gpmDataObj.addInputParameter("@cantDif", SqlDbType.Int, cantDias)
            gpmDataObj.addInputParameter("@codHistoria", SqlDbType.Int, dCod_Historia)
            gpmDataObj.addInputParameter("@tipo", SqlDbType.VarChar, tipo)

            dtReader = gpmDataObj.execDT
            'dtReader = Configuradescripcionconcatenada(dtReader)

            For Each drFila In dtReader.Rows
                objLiquidos = New Liquidos
                With objLiquidos
                    '.CodLiquidoAdministrado = drFila.Item("cod_liquido").ToString
                    '.CantidadAdmin = drFila.Item("cantidad").ToString
                    .Fecha = drFila.Item("fecha").ToString
                    .Hora = drFila.Item("hora").ToString
                    .DescripcionAdmin = drFila.Item("OBSERVACIONES").ToString
                    .Tipo = drFila.Item("tipo").ToString
                    .CantidadAdmin = drFila.Item("cantidad").ToString
                    .Elemento = drFila.Item("elemento").ToString
                    .Usuario = drFila.Item("usuario").ToString
                    '' .CantidadAdminTotal = drFila.Item("CantidadTotal").ToString
                End With
                listaLiquidos.Add(objLiquidos)
            Next

            Return listaLiquidos

        End Function

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
            Dim tipo As String
            Dim Dsubtotales As Integer = 0
            Dim IntCantidad As Integer = 0


            If dttable.Rows.Count > 0 Then
                dtRow = dtconfig.NewRow
                dtconfig.Rows.Add(dtRow)
                dtconfig.Rows(0).Item("hora") = dttable.Rows(0).Item("hora")
                dtconfig.Rows(0).Item("cod_liquido") = dttable.Rows(0).Item("cod_liquido")
                dtconfig.Rows(0).Item("fecha") = dttable.Rows(0).Item("fecha")
                dtconfig.Rows(0).Item("tipo") = dttable.Rows(0).Item("tipo")
                dtconfig.Rows(0).Item("cantidad") = "0.0"

                For i As Integer = 0 To dttable.Rows.Count - 1
                    codMed = dttable.Rows(i).Item("hora")
                    fecha = dttable.Rows(i).Item("Fecha")
                    tipo = dttable.Rows(i).Item("tipo")
                    ''And dtconfig.Rows(cont).Item("Fecha") = fecha 
                    'If tipo = "LA" And dttable.Rows(i).Item("cod_liquido") = "13" Then
                    '    dttable.Rows(i).Item("cantidad") = "0"
                    'End If
                    'If tipo = "LE" And dttable.Rows(i).Item("cod_liquido") = "34" Then
                    '    dttable.Rows(i).Item("cantidad") = "0"
                    'End If
                    If dtconfig.Rows(cont).Item("hora") = codMed And dtconfig.Rows(cont).Item("fecha") = fecha And dtconfig.Rows(cont).Item("tipo") = tipo Then

                        dtconfig.Rows(cont).Item("descripcion") = dtconfig.Rows(cont).Item("descripcion") & " " & dttable.Rows(i).Item("descripcion") & " " & dttable.Rows(i).Item("cantidad") & ",  "

                        If (tipo = "LE" And dttable.Rows(i).Item("cod_liquido") = "34") _
                        Or (tipo = "LA" And dttable.Rows(i).Item("cod_liquido") = "13") Then
                            dtconfig.Rows(cont).Item("cantidad") = CInt(IIf(dtconfig.Rows(cont).Item("cantidad") = "", 0, dtconfig.Rows(cont).Item("cantidad")))
                        Else

                            If tipo = "LE" And (dttable.Rows(i).Item("cod_liquido") = "1" Or dttable.Rows(i).Item("cod_liquido") = "3") Then

                                'If Trim(dttable.Rows(i).Item("cantidad")) = "+" Or Trim(dttable.Rows(i).Item("cantidad")) = "-" Then
                                '    dtconfig.Rows(cont).Item("cantidad") += Trim(dttable.Rows(i).Item("cantidad"))
                                'Else
                                If Trim(dttable.Rows(i).Item("cantidad")) = "+" Or Trim(dttable.Rows(i).Item("cantidad")) = "-" Then
                                    dttable.Rows(i).Item("cantidad") = 0
                                    'Else
                                    '    IntCantidad = dtconfig.Rows(i).Item("cantidad")
                                End If
                                dtconfig.Rows(cont).Item("cantidad") = CInt(IIf(dtconfig.Rows(cont).Item("cantidad") = "", 0, dtconfig.Rows(cont).Item("cantidad"))) + CInt(IIf(dttable.Rows(i).Item("cantidad") = "", 0, dttable.Rows(i).Item("cantidad")))
                                'End If
                            Else
                                If Trim(dtconfig.Rows(cont).Item("cantidad")) = "+" Or Trim(dtconfig.Rows(cont).Item("cantidad")) = "-" Then
                                    dttable.Rows(i).Item("cantidad") = 0
                                    'Else
                                    '    IntCantidad = dtconfig.Rows(cont).Item("cantidad")
                                End If

                                dtconfig.Rows(cont).Item("cantidad") = CInt(IIf(dtconfig.Rows(cont).Item("cantidad") = "", 0, dtconfig.Rows(cont).Item("cantidad"))) + CInt(IIf(dttable.Rows(i).Item("cantidad") = "", 0, dttable.Rows(i).Item("cantidad")))
                            End If


                        End If


                        'dtconfig.Rows(cont).Item("fecha") = dttable.Rows(i).Item("fecha")
                    Else
                        dtconfig.Rows.Add(dtconfig.NewRow)
                        cont = cont + 1
                        dtconfig.Rows(cont).Item("hora") = dttable.Rows(i).Item("hora")
                        dtconfig.Rows(cont).Item("descripcion") = dtconfig.Rows(cont).Item("descripcion") & " " & dttable.Rows(i).Item("descripcion") & " " & dttable.Rows(i).Item("cantidad") & ",  "
                        dtconfig.Rows(cont).Item("fecha") = dttable.Rows(i).Item("fecha")
                        dtconfig.Rows(cont).Item("tipo") = dttable.Rows(i).Item("tipo")
                        'If tipo = "LE" And (dtconfig.Rows(cont).Item("cod_liquido") = "1" Or dtconfig.Rows(cont).Item("cod_liquido") = "3") Then
                        If Trim(dttable.Rows(i).Item("cantidad")) = "+" Or Trim(dttable.Rows(i).Item("cantidad")) = "-" Then
                            dttable.Rows(i).Item("cantidad") = 0
                        End If
                        'End If
                        dtconfig.Rows(cont).Item("cantidad") = dttable.Rows(i).Item("cantidad")
                    End If

                Next
            End If

            Return dtconfig
        End Function
        Public Function consultarLiquidos(ByVal objConexion As Conexion, ByVal dCod_Historia As Decimal, ByVal strFechaIni As Nullable(Of DateTime), ByVal strFechaFin As Nullable(Of DateTime)) As DataTable

            Dim dtTable As DataTable
            Dim listaLiquidos As New List(Of Liquidos)
            Dim lError As Long = 0

            gpmDataObj.setSQLSentence("HCENFREP_TraerLiquidosvisor", CommandType.StoredProcedure)
            gpmDataObj.ClearParameters()
            gpmDataObj.addInputParameter("@intCodhistoria", SqlDbType.Int, dCod_Historia)
            gpmDataObj.addInputParameter("@strFechaIni", SqlDbType.DateTime, strFechaIni)
            gpmDataObj.addInputParameter("@strFechaFin", SqlDbType.DateTime, strFechaFin)
            gpmDataObj.addInputParameter("lError", SqlDbType.Int, lError)

            dtTable = gpmDataObj.execDT


            Return dtTable

        End Function
    End Class
End Namespace