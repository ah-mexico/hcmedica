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
    Public Class Balances1
        Inherits GPMDataReport

        Private _fecha As String
        Private _Bal12 As Double
        Private _Bal18 As Double
        Private _Bal6 As Double
        Private _BalAcum As Double
        Private _Gu As Double


#Region "Propiedades"

        Public Property Fecha() As String
            Get
                Return _fecha
            End Get
            Set(ByVal value As String)
                _fecha = value
            End Set
        End Property
        Public Property Bal12() As Double
            Get
                Return _Bal12
            End Get
            Set(ByVal value As Double)
                _Bal12 = value
            End Set
        End Property
        Public Property Bal18() As Double
            Get
                Return _Bal18
            End Get
            Set(ByVal value As Double)
                _Bal18 = value
            End Set
        End Property
        Public Property Bal6() As Double
            Get
                Return _Bal6
            End Get
            Set(ByVal value As Double)
                _Bal6 = value
            End Set
        End Property
        Public Property BalAcum() As Double
            Get
                Return _BalAcum
            End Get
            Set(ByVal value As Double)
                _BalAcum = value
            End Set
        End Property
        Public Property Gu() As Double
            Get
                Return _Gu
            End Get
            Set(ByVal value As Double)
                _Gu = value
            End Set
        End Property

#End Region

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal fechan As String, ByVal bal12n As Double, ByVal bal18n As Double,
        ByVal bal6n As Double, ByVal balAcumn As Double, ByVal Gun As Double)

            '_codLiquidoAdmin = nCodigoAdmin12
            '_descripcionAdmin = nDescrAdmin24
            '_cantidadAdmin = ncantidadAdmin24
            '_hora = nHora

        End Sub

        Public Function consultarBalance(ByVal objConexion As Conexion, ByVal dCod_Historia As Decimal, ByVal strFechaIni_RecNac As String, ByVal strFechaFin_RecNac As String, ByVal iHoraIni_RecNac As Integer, ByVal iHoraFin_RecNac As Integer) As List(Of Balances1)

            Dim dtReader As DbDataReader
            Dim objBalances As Balances1
            Dim listaBalances As New List(Of Balances1)
            Dim lError As Long = 0

            gpmDataObj.setSQLSentence("HCENFREP_TraerBalances", CommandType.StoredProcedure)

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

            Return listaBalances

        End Function

        Public Function consultarRepBalances(ByVal objConexion As Conexion, ByVal dCod_Historia As Integer, ByVal strFechaIni As Nullable(Of DateTime), ByVal strFechaFin As Nullable(Of DateTime), ByVal iHoraIni As Nullable(Of Integer), ByVal iHoraFin As Nullable(Of Integer)) As List(Of Balances1)
            Dim listaBalances As New List(Of Balances1)
            Dim lError As Long = 0
            Dim dtReader As DataTable
            Dim objBalances As Balances1
            Dim drFila As DataRow

            gpmDataObj.ClearParameters()
            gpmDataObj.setSQLSentence("HCENFREP_TraerBalances", CommandType.StoredProcedure)
            gpmDataObj.addInputParameter("@intCodhistoria", SqlDbType.Int, dCod_Historia)
            gpmDataObj.addInputParameter("@strFechaIni", SqlDbType.DateTime, strFechaIni)
            gpmDataObj.addInputParameter("@strFechaFin", SqlDbType.DateTime, strFechaFin)
            gpmDataObj.addInputParameter("@iHoraIni", SqlDbType.Int, iHoraIni)
            gpmDataObj.addInputParameter("@iHoraFin", SqlDbType.Int, iHoraFin)
            gpmDataObj.addOutputParameter("@lError", SqlDbType.Int, lError)

            dtReader = gpmDataObj.execDT
            'dtReader = Configuradescripcionconcatenada(dtReader)

            For Each drFila In dtReader.Rows
                objBalances = New Balances1
                With objBalances
                    .Fecha = drFila.Item("fecha").ToString
                    .Bal12 = drFila.Item("Bal12").ToString
                    .Bal18 = drFila.Item("Bal18").ToString
                    .Bal6 = drFila.Item("Bal6").ToString
                    .BalAcum = drFila.Item("balAcumulado").ToString
                    .Gu = drFila.Item("Gu").ToString
                    '' .CantidadAdminTotal = drFila.Item("CantidadTotal").ToString
                End With
                listaBalances.Add(objBalances)
            Next

            Return listaBalances

        End Function
    End Class
End Namespace