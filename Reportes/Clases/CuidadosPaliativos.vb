Imports System.Data.Common
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.HistoriaBasica
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Namespace Sophia.HistoriaClinica.Reportes
    Public Class CuidadosPaliativos
        Inherits GPMDataReport
#Region "Propiedades"
        Private _cod_pre_sgs As String
        Public Property cod_pre_sgs() As String
            Get
                Return _cod_pre_sgs
            End Get
            Set(ByVal Value As String)
                _cod_pre_sgs = Value
            End Set
        End Property

        Private _cod_sucur As String
        Public Property cod_sucur() As String
            Get
                Return _cod_sucur
            End Get
            Set(ByVal Value As String)
                _cod_sucur = Value
            End Set
        End Property

        Private _tip_admision As String
        Public Property tip_admision() As String
            Get
                Return _tip_admision
            End Get
            Set(ByVal Value As String)
                _tip_admision = Value
            End Set
        End Property

        Private _ano_adm As Integer
        Public Property ano_adm() As Integer
            Get
                Return _ano_adm
            End Get
            Set(ByVal Value As Integer)
                _ano_adm = Value
            End Set
        End Property

        Private _num_adm As Decimal
        Public Property num_adm() As Decimal
            Get
                Return _num_adm
            End Get
            Set(ByVal Value As Decimal)
                _num_adm = Value
            End Set
        End Property

        Private _tip_doc As String
        Public Property tip_doc() As String
            Get
                Return _tip_doc
            End Get
            Set(ByVal Value As String)
                _tip_doc = Value
            End Set
        End Property

        Private _Num_doc As String
        Public Property Num_doc() As String
            Get
                Return _Num_doc
            End Get
            Set(ByVal Value As String)
                _Num_doc = Value
            End Set
        End Property

        Private _IdSeccion As Integer
        Public Property IdSeccion() As Integer
            Get
                Return _IdSeccion
            End Get
            Set(ByVal Value As Integer)
                _IdSeccion = Value
            End Set
        End Property


        Private _Seccion As String
        Public Property Seccion() As String
            Get
                Return _Seccion
            End Get
            Set(ByVal value As String)
                _Seccion = value
            End Set
        End Property


        Private _Fecha As DateTime
        Public Property Fecha() As DateTime
            Get
                Return _Fecha
            End Get
            Set(ByVal Value As DateTime)
                _Fecha = Value
            End Set
        End Property

        Private _login As String
        Public Property login() As String
            Get
                Return _login
            End Get
            Set(ByVal Value As String)
                _login = Value
            End Set
        End Property

        Private _id_Pregunta As Integer
        Public Property id_Pregunta() As Integer
            Get
                Return _id_Pregunta
            End Get
            Set(ByVal Value As Integer)
                _id_Pregunta = Value
            End Set
        End Property

        Private _Pregunta As String
        Public Property Pregunta() As String
            Get
                Return _Pregunta
            End Get
            Set(ByVal Value As String)
                _Pregunta = Value
            End Set
        End Property

        Private _Tabla_Movimiento As String
        Public Property Tabla_Movimiento() As String
            Get
                Return _Tabla_Movimiento
            End Get
            Set(ByVal Value As String)
                _Tabla_Movimiento = Value
            End Set
        End Property

        Private _Pregunta_Campo As String
        Public Property Pregunta_Campo() As String
            Get
                Return _Pregunta_Campo
            End Get
            Set(ByVal Value As String)
                _Pregunta_Campo = Value
            End Set
        End Property

        Private _id_Parametrica As Integer
        Public Property id_Parametrica() As Integer
            Get
                Return _id_Parametrica
            End Get
            Set(ByVal Value As Integer)
                _id_Parametrica = Value
            End Set
        End Property

        Private _Texto As String
        Public Property Texto() As String
            Get
                Return _Texto
            End Get
            Set(ByVal Value As String)
                _Texto = Value
            End Set
        End Property

        Private _IdRespuesta As String
        Public Property IdRespuesta() As String
            Get
                Return _IdRespuesta
            End Get
            Set(ByVal Value As String)
                _IdRespuesta = Value
            End Set
        End Property

        Private _Respuesta As String
        Public Property Respuesta() As String
            Get
                Return _Respuesta
            End Get
            Set(ByVal Value As String)
                _Respuesta = Value
            End Set
        End Property

#End Region

        Public Function ConsultarReporteCuidadosPaliativos(ByVal strcod_pre_sgs As String, ByVal strCod_sucur As String, _
                   Optional ByVal strTipAdmision As String = "", Optional ByVal ianoAdm As Integer = 0, Optional ByVal num_adm As Decimal = 0, _
                   Optional ByVal strTip_Doc As String = "", Optional ByVal strNum_Doc As String = "") As List(Of CuidadosPaliativos)

            Dim objCuidadosPaliativos As New DAOCuidadosPaliativos
            Dim dsResultado As New DataSet

            dsResultado = objCuidadosPaliativos.ConsultaDatosReporteCuidadosPaliativos(strcod_pre_sgs, strCod_sucur, _
            strTipAdmision, ianoAdm, num_adm, strTip_Doc, strNum_Doc)

            Dim lista As New List(Of CuidadosPaliativos)
            If dsResultado.Tables.Count > 0 AndAlso dsResultado.Tables(0).Rows.Count > 0 Then
                For Each row As DataRow In dsResultado.Tables(0).Rows
                    Dim obj As New CuidadosPaliativos
                    With obj
                        .IdSeccion = row.Item("idSeccion").ToString()
                        .Seccion = row.Item("Seccion").ToString()
                        .tip_doc = row.Item("tip_doc").ToString()
                        .Num_doc = row.Item("Num_doc").ToString()
                        .id_Pregunta = row.Item("id_Pregunta").ToString()
                        .Pregunta = row.Item("Pregunta").ToString()
                        .id_Parametrica = row.Item("id_Parametrica").ToString()
                        .IdRespuesta = row.Item("IdRespuesta").ToString()
                        .Respuesta = row.Item("Respuesta").ToString()
                        .Fecha = row.Item("Fecha").ToString()
                        .login = row.Item("login").ToString()
                    End With
                    lista.Add(obj)
                Next
            End If
            Return lista
        End Function
    End Class
End Namespace

