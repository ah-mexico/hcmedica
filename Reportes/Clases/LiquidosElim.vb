Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports System.Collections.Generic
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    Public Class LiquidosElim

        Inherits GPMDataReport

        Private _codLiquidoAdmin As String
        Private _descripcionAdmin As String
        Private _cantidadAdmin As String
        Private _hora As String
        Private _fecha As String
        Private _tipo As String
        Private _elemento As String
        Private _cantidadAdminTotal As String
        Private _usuario As String

#Region "Propiedades"

        Public Property ElementoElim() As String
            Get
                Return _elemento
            End Get
            Set(ByVal value As String)
                _elemento = value
            End Set
        End Property

        Public Property TipoElim() As String
            Get
                Return _tipo
            End Get
            Set(ByVal value As String)
                _tipo = value
            End Set
        End Property

        Public Property FechaElim() As String
            Get
                Return _fecha
            End Get
            Set(ByVal value As String)
                _fecha = value
            End Set
        End Property
        Public Property HoraElim() As String
            Get
                Return _hora
            End Get
            Set(ByVal value As String)
                _hora = value
            End Set
        End Property

        Public Property CodLiquidoElim() As String
            Get
                Return _codLiquidoAdmin
            End Get
            Set(ByVal value As String)
                _codLiquidoAdmin = value
            End Set
        End Property

        Public Property DescripcionElim() As String
            Get
                Return _descripcionAdmin
            End Get
            Set(ByVal value As String)
                _descripcionAdmin = value
            End Set
        End Property

        Public Property CantidadElim() As String ''Cpgaray Se cambia tipo de dato 2012-03-07
            Get
                Return _cantidadAdmin
            End Get
            Set(ByVal value As String)
                _cantidadAdmin = value
            End Set
        End Property

        Public Property UsuarioElim() As String ''dsanchez se crea la propiedad para usuario 2017-09-13
            Get
                Return _usuario
            End Get
            Set(ByVal value As String)
                _usuario = value
            End Set
        End Property

        Public Property CantidadElimTotal() As String
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


        Public Function consultarLiquidosEliminados(ByVal objConexion As Conexion, ByVal dCod_Historia As Integer, ByVal fechaInicial As String, ByVal tipo As String, ByVal cantDias As Integer) As List(Of LiquidosElim)

            Dim listaLiquidos As New List(Of LiquidosElim)
            Dim lError As Long = 0
            Dim dtReader As DataTable
            Dim objLiquidos As LiquidosElim
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
                objLiquidos = New LiquidosElim
                With objLiquidos
                    '.CodLiquidoAdministrado = drFila.Item("cod_liquido").ToString
                    '.CantidadAdmin = drFila.Item("cantidad").ToString
                    .FechaElim = drFila.Item("fecha").ToString
                    .HoraElim = drFila.Item("hora").ToString
                    .DescripcionElim = drFila.Item("OBSERVACIONES").ToString
                    .TipoElim = drFila.Item("tipo").ToString
                    .CantidadElim = drFila.Item("cantidad").ToString
                    .ElementoElim = drFila.Item("elemento").ToString
                    .UsuarioElim = drFila.Item("usuario").ToString
                    '' .CantidadAdminTotal = drFila.Item("CantidadTotal").ToString
                End With
                listaLiquidos.Add(objLiquidos)
            Next

            Return listaLiquidos

        End Function

    End Class
End Namespace
