''Claudia Garay Marzo 26 de 2012 Ctc's

Imports System.Collections.Generic
Imports System.Data.Common
Namespace Sophia.HistoriaClinica.Reportes
    Public Class Excepciones
        Inherits GPMDataReport
        ''Paciente
        Private _ApellidosPac As String
        Private _NombresPac As String
        Private _TipDoc As String
        Private _NumDoc As String
        Private _Edad As String
        Private _Sexo As String
        Private _DirPac As String
        Private _TelPac As String
        Private _CiuPac As String
        Private _Carnet As String
        Private _Email As String

      
#Region "Paciente"


        Public Property ApellidosPac() As String
            Get
                Return _ApellidosPac
            End Get
            Set(ByVal value As String)
                _ApellidosPac = value
            End Set
        End Property
        Public Property NombresPac() As String
            Get
                Return _NombresPac
            End Get
            Set(ByVal value As String)
                _NombresPac = value
            End Set
        End Property
        Public Property TipDoc() As String
            Get
                Return _TipDoc
            End Get
            Set(ByVal value As String)
                _TipDoc = value
            End Set
        End Property
        Public Property NumDoc() As String
            Get
                Return _NumDoc
            End Get
            Set(ByVal value As String)
                _NumDoc = value
            End Set
        End Property
        Public Property Edad() As String
            Get
                Return _Edad
            End Get
            Set(ByVal value As String)
                _Edad = value
            End Set
        End Property
        Public Property Sexo() As String
            Get
                Return _Sexo
            End Get
            Set(ByVal value As String)
                _Sexo = value
            End Set
        End Property
        Public Property DirPac() As String
            Get
                Return _DirPac
            End Get
            Set(ByVal value As String)
                _DirPac = value
            End Set
        End Property
        Public Property TelPac() As String
            Get
                Return _TelPac
            End Get
            Set(ByVal value As String)
                _TelPac = value
            End Set
        End Property
        Public Property CiuPac() As String
            Get
                Return _CiuPac
            End Get
            Set(ByVal value As String)
                _CiuPac = value
            End Set
        End Property
        Public Property Carnet() As String
            Get
                Return _Carnet
            End Get
            Set(ByVal value As String)
                _Carnet = value
            End Set
        End Property
        Public Property Email() As String
            Get
                Return _Email
            End Get
            Set(ByVal value As String)
                _Email = value
            End Set
        End Property
#End Region



        'Claudia Garay Ctc's Marzo 23 de 2012

        Public Function TraerReporteCtc(ByVal strcod_pre_sgs As String, _
                          ByVal strCod_sucur As String, ByVal strTip_admision As String, _
                          ByVal iano_adm As Long, ByVal lnum_adm As Double, ByVal strTipDoc As String, _
                          ByVal strNumDoc As String, ByVal nroOrden As Decimal, ByVal strCodPro As String, ByVal intopcion As Integer, ByVal secuencia As Integer) As DataSet

            Dim dsDatos As New DataSet

            gpmDataObj.setSQLSentence("HC_ReporteOrdenesIExcepciones", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            gpmDataObj.addInputParameter("cod_sucur", SqlDbType.VarChar, strCod_sucur)
            gpmDataObj.addInputParameter("tip_admision", SqlDbType.VarChar, strTip_admision)
            gpmDataObj.addInputParameter("tip_doc", SqlDbType.VarChar, strTipDoc)
            gpmDataObj.addInputParameter("num_doc", SqlDbType.VarChar, strNumDoc)
            gpmDataObj.addInputParameter("num_adm", SqlDbType.Decimal, lnum_adm)
            gpmDataObj.addInputParameter("ano_adm", SqlDbType.Int, iano_adm)
            gpmDataObj.addInputParameter("NroOrden", SqlDbType.Decimal, nroOrden)
            gpmDataObj.addInputParameter("codigoPr", SqlDbType.Decimal, strCodPro)
            gpmDataObj.addInputParameter("Origen", SqlDbType.Decimal, intopcion)
            gpmDataObj.addInputParameter("secuencia", SqlDbType.Decimal, secuencia)
            dsDatos = gpmDataObj.execDS



            Return dsDatos
        End Function
        Public Function CargarObjetoExcepcionesPac(ByVal dt As DataTable) As List(Of Excepciones)

            Dim listaExcepcion As New List(Of Excepciones)
            Dim objExcepcion As Excepciones
            Dim drFila As DataRow



            For Each drFila In dt.Rows
                objExcepcion = New Excepciones()

                With objExcepcion
                    .ApellidosPac = drFila.Item("Apellido").ToString
                    .NombresPac = drFila.Item("Nombre").ToString
                    .TipDoc = drFila.Item("tip_doc").ToString
                    .NumDoc = drFila.Item("num_doc").ToString
                    .Edad = drFila.Item("edad").ToString
                    .Sexo = drFila.Item("sexo").ToString
                    .DirPac = drFila.Item("dir_cas_pac").ToString
                    .TelPac = drFila.Item("tel_cas_pac1").ToString
                    .CiuPac = drFila.Item("ciu_nacimien").ToString
                    .Carnet = drFila.Item("carnet").ToString
                    .Email = drFila.Item("ema_pac").ToString
                End With
                listaExcepcion.Add(objExcepcion)
            Next


            Return listaExcepcion
        End Function
        Public Function CargarObjetoExcepcionesProd_Proc(ByVal dt As DataTable) As List(Of ExcepcionesProd)

            Dim listaExcepcion As New List(Of ExcepcionesProd)
            Dim objExcepcion As ExcepcionesProd
            Dim drFila As DataRow



            For Each drFila In dt.Rows
                objExcepcion = New ExcepcionesProd()

                With objExcepcion
                    .DescripcionProd = drFila.Item("descripcion_pa").ToString
                    .DescripcionProdNoPos = drFila.Item("DescripcionNoPos").ToString
                    .Concentracion = drFila.Item("concentracion").ToString
                    .ConcentracionNoPos = drFila.Item("concentracionNoPos").ToString
                    .ForFarma = drFila.Item("FormaFarma").ToString
                    .ForFarmaNoPos = drFila.Item("for_farmaNoPos").ToString
                    .Cums = drFila.Item("cod_cums").ToString
                    .CumsNoPos = drFila.Item("cod_cumsNoPos").ToString
                    .DiasTratamiento = drFila.Item("DiasTrata").ToString
                    .DosisDia = drFila.Item("DosisDia").ToString
                    .DosisDiaNoPos = drFila.Item("DosisXDiaNoPos").ToString
                    .TipDocMed = drFila.Item("tip_doc").ToString
                    .NumDocMed = drFila.Item("num_doc").ToString
                    .ApellidosMed = drFila.Item("ApellidosMed").ToString
                    .NombresMed = drFila.Item("NombresMed").ToString
                    .Especialidad = drFila.Item("Especialidad").ToString
                    .RegMed = drFila.Item("reg_med").ToString
                    .DirSucur = drFila.Item("direccion").ToString
                    .CiuSucur = drFila.Item("Ciudad").ToString
                    .TeleSucur = drFila.Item("telefono").ToString
                    .JustificacionExcep = drFila.Item("Justificacion").ToString
                    .Dia = drFila.Item("Dia").ToString
                    .Mes = drFila.Item("Mes").ToString
                    .Ano = drFila.Item("Ano").ToString
                    .DosisDia = drFila.Item("DosisDia").ToString
                    .DiaDesde = drFila.Item("DiaDesde").ToString
                    .MesDesde = drFila.Item("MesDesde").ToString
                    .AnoDesde = drFila.Item("AnoDesde").ToString
                    .DiaHasta = drFila.Item("DiaHasta").ToString
                    .MesHasta = drFila.Item("MesHasta").ToString
                    .AnoHasta = drFila.Item("AnoHasta").ToString
                    .Email = drFila.Item("email").ToString
                End With
                listaExcepcion.Add(objExcepcion)
            Next


            Return listaExcepcion
        End Function
        Public Function CargarObjetoExcepcionesEvolucion(ByVal dt As DataTable) As List(Of ExcepcionesEvo)

            Dim listaExcepcion As New List(Of ExcepcionesEvo)
            Dim objExcepcion As ExcepcionesEvo
            Dim drFila As DataRow



            For Each drFila In dt.Rows
                objExcepcion = New ExcepcionesEvo()
                With objExcepcion
                    .Evolucion = Replace(Replace(drFila.Item("Evolucion").ToString, Chr(10), " "), Chr(13), " ")
                    'Replace(Trim(drFila.Item("Evolucion").ToString), Chr(10), "")

                End With
                listaExcepcion.Add(objExcepcion)
            Next

            Return listaExcepcion
        End Function
        Public Function CargarObjetoExcepcionesDiagnostico(ByVal dt As DataTable) As List(Of ExcepcionesDiag)

            Dim listaExcepcion As New List(Of ExcepcionesDiag)
            Dim objExcepcion As ExcepcionesDiag
            Dim drFila As DataRow



            For Each drFila In dt.Rows
                objExcepcion = New ExcepcionesDiag()

                With objExcepcion
                    .DescDiagn = drFila.Item("descripcion").ToString

                End With
                listaExcepcion.Add(objExcepcion)
            Next

            Return listaExcepcion
        End Function
        Public Function CargarObjetoExcepcionesMotivo(ByVal dt As DataTable) As List(Of ExcepcionesMot)

            Dim listaExcepcion As New List(Of ExcepcionesMot)
            Dim objExcepcion As ExcepcionesMot
            Dim drFila As DataRow



            For Each drFila In dt.Rows
                objExcepcion = New ExcepcionesMot()

                With objExcepcion
                    .MotConsulta = Replace(Replace(drFila.Item("Enf_actual").ToString, Chr(10), " "), Chr(13), " ")
                End With
                listaExcepcion.Add(objExcepcion)
            Next


            Return listaExcepcion
        End Function
    End Class
End Namespace

