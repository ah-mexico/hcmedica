Imports Enfermeria.Sophia.HistoriaClinica.BL
Imports Enfermeria.Sophia.HistoriaClinica.DatosConexion
Imports Enfermeria.Sophia.HistoriaClinica.Comunes
Imports System.Collections.Generic
Imports System.Data.Common
''Claudia Garay Planeacion de medicamentos
Namespace Sophia.HistoriaClinica.Reportes
    ''' <summary>
    ''' Clase que encapsula los datos de una nota de evolucion
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Balances
        Inherits GPMDataReport

        Private _periodo As String
        Private _balance As String
        Private _gastoUrinario As String
        Private _fecha As String
        Private _id As Integer
        Private _administrado As String
        Private _eliminado As String


#Region "Propiedades"

        Public Property Fecha() As String
            Get
                Return _fecha
            End Get
            Set(ByVal value As String)
                _fecha = value
            End Set
        End Property

        Public Property Administrado() As String
            Get
                Return _administrado
            End Get
            Set(ByVal value As String)
                _administrado = value
            End Set
        End Property

        Public Property Eliminado() As String
            Get
                Return _eliminado
            End Get
            Set(ByVal value As String)
                _eliminado = value
            End Set
        End Property

        Public Property Id() As Integer
            Get
                Return _id
            End Get
            Set(ByVal value As Integer)
                _id = value
            End Set
        End Property

        Public Property Periodo() As String
            Get
                Return _periodo
            End Get
            Set(ByVal value As String)
                _periodo = value
            End Set
        End Property
        Public Property Balance() As String
            Get
                Return _balance
            End Get
            Set(ByVal value As String)
                _balance = value
            End Set
        End Property
        Public Property GastoUrinario() As String
            Get
                Return _gastoUrinario
            End Get
            Set(ByVal value As String)
                _gastoUrinario = value
            End Set
        End Property

#End Region

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal fechan As String, ByVal bal12n As Double, ByVal bal18n As Double, _
        ByVal bal6n As Double, ByVal balAcumn As Double, ByVal Gun As Double)

            '_codLiquidoAdmin = nCodigoAdmin12
            '_descripcionAdmin = nDescrAdmin24
            '_cantidadAdmin = ncantidadAdmin24
            '_hora = nHora

        End Sub

        Public Function consultarRepBalances(ByVal codHistoria As Integer, ByVal fecha As String, ByVal cantDif As Integer) As List(Of Balances)

            Dim listaBalance As New List(Of Balances)
            Dim dtInfo As DataTable
            Dim objBalance As Balances
            Dim lError As Long = 0

            gpmDataObj.ClearParameters()
            gpmDataObj.setSQLSentence("HCENF_ReporteBalance", CommandType.StoredProcedure)
            gpmDataObj.addInputParameter("@fecha", SqlDbType.VarChar, fecha)
            gpmDataObj.addInputParameter("@cantDif", SqlDbType.Int, cantDif)
            gpmDataObj.addInputParameter("@codHistoria", SqlDbType.Int, codHistoria)

            dtInfo = gpmDataObj.execDT()

            For Each item As DataRow In dtInfo.Rows

                objBalance = New Balances

                With objBalance

                    .Id = CInt(item("ID").ToString())
                    .Periodo = item("PERIODO").ToString()
                    .Balance = item("BALANCE").ToString()
                    .GastoUrinario = item("GASTO_URINARIO").ToString()
                    .Fecha = item("FECHA").ToString()
                    .Administrado = item("ADMINISTRADOS").ToString()
                    .Eliminado = item("ELIMINADOS").ToString()

                End With

                listaBalance.Add(objBalance)

            Next

            Return listaBalance

        End Function



    End Class

End Namespace