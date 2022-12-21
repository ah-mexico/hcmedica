'llarias se crea clase que maneja los datos de la escala de riesgo 2015/07/03
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    ''' <summary>
    ''' Clase que encapsula los datos de la escala de riesgo
    ''' </summary>
    ''' <remarks></remarks>
    Public Class EscalaRiesgo1
        Inherits GPMDataReport

        Private _cod_historia As String    'codigo historia  
        Private _fecha As String 'fecha
   

        Public Sub New()
            MyBase.New()
        End Sub

        Public Property Cod_historia() As String
            Get
                Return _cod_historia
            End Get
            Set(ByVal value As String)
                _cod_historia = value
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

       
        Public Sub New(ByVal scod As String, ByVal dfecha As String)

            _cod_historia = scod

            _fecha = dfecha

        End Sub


        Public Shared Function crearListaRiesgo(ByVal dtRiesgo As DataTable) As List(Of EscalaRiesgo1)
            Dim lista As New List(Of EscalaRiesgo1)
            Dim objRiesgo As EscalaRiesgo1
            Dim i As Integer

            If dtRiesgo Is Nothing Then
                Return lista
            End If

            For i = 0 To dtRiesgo.Rows.Count - 1
                objRiesgo = New EscalaRiesgo1(dtRiesgo.Rows(i).Item("cod_historia").ToString, dtRiesgo.Rows(i).Item("fecha").ToString)
                lista.Add(objRiesgo)
            Next

            Return lista
        End Function

        Public Function consultarEscalaRiesgo1(ByVal objConexion As Conexion, ByVal dCod_Historia As Integer, ByVal strFechaIni As Nullable(Of Date), ByVal strFechaFin As Nullable(Of Date), ByVal iHoraIni As Nullable(Of Integer), ByVal iHoraFin As Nullable(Of Integer)) As List(Of EscalaRiesgo1)
            Dim lError As Long = 0
            Dim objEscalaRiesgoN As EscalaRiesgo1
            Dim listaEscala As New List(Of EscalaRiesgo1)
            Dim dtSetReturn As DataSet
            gpmDataObj.setSQLSentence("HCENF_TraerRiesgoDetRep", CommandType.StoredProcedure)
            gpmDataObj.addInputParameter("@codhistoria", SqlDbType.Int, dCod_Historia)
            gpmDataObj.addInputParameter("@strFechaIni", SqlDbType.DateTime, strFechaIni)
            gpmDataObj.addInputParameter("@strFechaFin", SqlDbType.DateTime, strFechaFin)
            gpmDataObj.addInputParameter("@iHoraIni", SqlDbType.Int, iHoraIni)
            gpmDataObj.addInputParameter("@iHoraFin", SqlDbType.Int, iHoraFin)
            gpmDataObj.addOutputParameter("lError", SqlDbType.Int, lError)

            dtSetReturn = gpmDataObj.execDS() 'llarias1
            'Return dtSetReturn 'llarias
            'dtSetReturn = gpmDataObj.ExecRdr 'llarias
            'Do While dtSetReturn.Read


            For i As Integer = 0 To dtSetReturn.Tables(0).Rows.Count.ToString() - 1
                objEscalaRiesgoN = New EscalaRiesgo1
                With objEscalaRiesgoN
                    ._cod_historia = dtSetReturn.Tables(1).Rows(i).Item("cod_historia").ToString()
                    ._fecha = dtSetReturn.Tables(1).Rows(i).Item("fecha").ToString
                    listaEscala.Add(objEscalaRiesgoN)
                End With

            Next


            Return listaEscala


            'Return gpmDataObj.execDT
        End Function


    End Class
End Namespace