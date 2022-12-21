Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports System.Collections.Generic

Namespace Sophia.HistoriaClinica.Reportes
    Public Class Diagnostico
        Inherits GPMDataReport

        Private _tipoDiagnostico As String
        Private _categoria As String
        Private _codigo As String
        Private _descripDiagnostico As String
        Private _observaciones As String
        Private _planManejo As String
        Private _clase As String
        Private _Analisis As String
        Private _exp_pla As String
        Private _Estado As String


#Region "Propiedades"
        Public Property TipoDiagnostico() As String
            Get
                Return _tipoDiagnostico
            End Get
            Set(ByVal Value As String)
                _tipoDiagnostico = Value
            End Set
        End Property

        Public Property Categoria() As String
            Get
                Return _categoria
            End Get
            Set(ByVal value As String)
                _categoria = value
            End Set
        End Property

        Public Property Codigo() As String
            Get
                Return _codigo
            End Get
            Set(ByVal Value As String)
                _codigo = Value
            End Set
        End Property

        Public Property DescripDiagnostico() As String
            Get
                Return _descripDiagnostico
            End Get
            Set(ByVal Value As String)
                _descripDiagnostico = Value
            End Set
        End Property

        Public Property Observaciones() As String
            Get
                Return _observaciones
            End Get
            Set(ByVal Value As String)
                _observaciones = Value
            End Set
        End Property

        Public Property PlanManejo() As String
            Get
                Return _planManejo
            End Get
            Set(ByVal Value As String)
                _planManejo = Value
            End Set
        End Property

        Public Property Clase() As String
            Get
                Return _clase
            End Get
            Set(ByVal Value As String)
                _clase = Value
            End Set
        End Property
        Public Property Analisis() As String
            Get
                Return _Analisis
            End Get
            Set(ByVal Value As String)
                _Analisis = Value
            End Set
        End Property

        Public Property Exp_Pla() As String
            Get
                Return _exp_pla
            End Get
            Set(ByVal Value As String)
                _exp_pla = Value
            End Set
        End Property

        Public Property Estado() As String
            Get
                Return _Estado
            End Get
            Set(ByVal Value As String)
                _Estado = Value
            End Set
        End Property
#End Region

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal strTipDiagn As String, ByVal StrCategoria As String, ByVal strCodigo As String, ByVal strdesDiagn As String,
        ByVal obs As String, ByVal strclase As String, Optional ByVal strPlanManejo As String = "", Optional ByVal strAnalisis As String = "",
                        Optional ByVal strExpPlanManejo As String = "", Optional ByVal strEstado As String = "")

            _tipoDiagnostico = strTipDiagn
            _categoria = StrCategoria
            _codigo = strCodigo
            _descripDiagnostico = strdesDiagn
            _observaciones = obs
            _planManejo = strPlanManejo
            _clase = strclase
            _Analisis = strAnalisis
            _exp_pla = strExpPlanManejo
            _Estado = strEstado

        End Sub
        Public Function consultaDiagnosticos(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
                   ByVal strCod_sucur As String, ByVal strTip_admision As String,
                   ByVal iano_adm As Long, ByVal lnum_adm As Double,
                   ByVal strLogin As String, Optional ByVal clase As String = "I") As List(Of Diagnostico)

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            Dim dtDatos As DataTable
            Dim lista As List(Of Diagnostico)

            gpmDataObj.setSQLSentence("pa_Reportes_Diagnosticos", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("strcod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            gpmDataObj.addInputParameter("strCod_sucur", SqlDbType.VarChar, strCod_sucur)
            gpmDataObj.addInputParameter("strTip_admision", SqlDbType.VarChar, strTip_admision)
            gpmDataObj.addInputParameter("iAno_adm", SqlDbType.Int, iano_adm)
            gpmDataObj.addInputParameter("lNum_adm", SqlDbType.Decimal, lnum_adm)
            gpmDataObj.addInputParameter("strLogin", SqlDbType.VarChar, strLogin)
            gpmDataObj.addInputParameter("strclase_diag", SqlDbType.VarChar, clase)

            Dim dtSet As DataSet = gpmDataObj.execDS()
            If Not dtSet Is Nothing Then
                If Not dtSet.Tables Is Nothing Then
                    dtDatos = dtSet.Tables(0)
                End If
            End If

            lista = crearListaDiagnosticos(dtDatos, clase)

            Return lista

        End Function

        Public Function crearListaDiagnosticos(ByVal dtdatos As DataTable, ByVal clase As String) As List(Of Diagnostico)

            Dim antDiagnostico As Diagnostico
            Dim listaDiagnostico As New List(Of Diagnostico)
            Dim arrayDiagn() As DataRow
            Dim cont As Integer
            Dim objDAOEgreso As New DAOEgresos
            Dim dtCategorias As DataTable
            Dim arrayCategoria() As DataRow

            ''Carga en un datatable las categorias de los diagnosticos disponibles
            dtCategorias = objDAOEgreso.ConsultarCategorias()
            ''Se ordenan los diagnosticos por fecha de grabacion
            arrayDiagn = dtdatos.Select("")

            For cont = 0 To arrayDiagn.Length - 1
                antDiagnostico = New Diagnostico(arrayDiagn(cont).Item("tDescripcion").ToString, arrayDiagn(cont).Item("categoria_diag").ToString,
                                     arrayDiagn(cont).Item("diagnost").ToString,
                                     arrayDiagn(cont).Item("descripcion").ToString, arrayDiagn(cont).Item("obs").ToString, clase,
                                     arrayDiagn(cont).Item("planManejo").ToString, arrayDiagn(cont).Item("Analisis").ToString,
                                                 arrayDiagn(cont).Item("exp_pla").ToString, arrayDiagn(cont).Item("Estado").ToString)


                'antDiagnostico = New Diagnostico(arrayDiagn(cont).Item("tDescripcion").ToString, arrayDiagn(cont).Item("diagnost").ToString, _
                '                                    arrayDiagn(cont).Item("descripcion").ToString, arrayDiagn(cont).Item("obs").ToString, clase, _
                '                                    arrayDiagn(cont).Item("planManejo").ToString)

                ''Busca la descripcion de la categoria del diagnostico
                arrayCategoria = dtCategorias.Select("categoria_diag = '" & arrayDiagn(cont).Item("categoria_diag").ToString & "'")

                If arrayCategoria.Length > 0 Then
                    antDiagnostico.Categoria = arrayCategoria(0).Item("Descripcion").ToString
                Else
                    antDiagnostico.Categoria = ""
                End If

                listaDiagnostico.Add(antDiagnostico)

            Next cont

            Return listaDiagnostico

        End Function

    End Class
End Namespace

