
Imports System.Data.Common
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.HistoriaBasica
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Namespace Sophia.HistoriaClinica.Reportes
    Public Class DescripcionQx

        Inherits GPMDataReport

        Private dtDiagnosticos As New List(Of Diagnostico)
        Private strTejidos As String
        Private strIntervencion As String
        Private strtipo_cirugia As String
        Private strhallazgos As String
        Private strtiempo_qx As String
        Private strdesc_intervencion As String
        Private strcomplicaciones As String
        Private strrecuentoMaterial As String
        Private strSangrado As String
        Private strMedico As String
        Private strAnestesia As String
        Private strEspecialdiad As String
        Private strFechaIni As String
        Private strFechaFin As String
        Private _HorIni As String
        Private _HorFin As String
        Private _MinIni As String
        Private _MinFin As String
        Private _Profilaxis As String
#Region "Propiedades"
        Public Property Diagnosticos() As List(Of Diagnostico)
            Get
                Return dtDiagnosticos
            End Get
            Set(ByVal value As List(Of Diagnostico))
                dtDiagnosticos = value
            End Set
        End Property
        Public Property Tejidos() As String
            Get
                Return strTejidos
            End Get
            Set(ByVal value As String)
                strTejidos = value
            End Set
        End Property
        Public Property Intervencion() As String
            Get
                Return strIntervencion
            End Get
            Set(ByVal value As String)
                strIntervencion = value
            End Set
        End Property
        Public Property TipoCirugia() As String
            Get
                Return strtipo_cirugia
            End Get
            Set(ByVal value As String)
                strtipo_cirugia = value
            End Set
        End Property
        Public Property Hallazgos() As String
            Get
                Return strhallazgos
            End Get
            Set(ByVal value As String)
                strhallazgos = value
            End Set
        End Property
        Public Property TiempoQx() As String
            Get
                Return strtiempo_qx
            End Get
            Set(ByVal value As String)
                strtiempo_qx = value
            End Set
        End Property
        Public Property DescIntervencion() As String
            Get
                Return strdesc_intervencion
            End Get
            Set(ByVal value As String)
                strdesc_intervencion = value
            End Set
        End Property
        Public Property Complicaciones() As String
            Get
                Return strcomplicaciones
            End Get
            Set(ByVal value As String)
                strcomplicaciones = value
            End Set
        End Property
        Public Property RecuentoMaterial() As String
            Get
                Return strrecuentoMaterial
            End Get
            Set(ByVal value As String)
                strrecuentoMaterial = value
            End Set
        End Property
        Public Property Sangrado() As String
            Get
                Return strSangrado
            End Get
            Set(ByVal value As String)
                strSangrado = value
            End Set
        End Property
        Public Property Medico() As String
            Get
                Return strMedico
            End Get
            Set(ByVal value As String)
                strMedico = value
            End Set
        End Property
        Public Property Anestesia() As String
            Get
                Return strAnestesia
            End Get
            Set(ByVal value As String)
                strAnestesia = value
            End Set
        End Property
        Public Property Especialidad() As String
            Get
                Return strEspecialdiad
            End Get
            Set(ByVal value As String)
                strEspecialdiad = value
            End Set
        End Property
        Public Property FechaIni() As String
            Get
                Return strFechaIni
            End Get
            Set(ByVal value As String)
                strFechaIni = value
            End Set
        End Property
        Public Property FechaFin() As String
            Get
                Return strFechaFin
            End Get
            Set(ByVal value As String)
                strFechaFin = value
            End Set
        End Property
        Public Property HorIni() As String
            Get
                Return _HorIni
            End Get
            Set(ByVal value As String)
                _HorIni = value
            End Set
        End Property
        Public Property MinIni() As String
            Get
                Return _MinIni
            End Get
            Set(ByVal value As String)
                _MinIni = value
            End Set
        End Property
        Public Property HorFin() As String
            Get
                Return _HorFin
            End Get
            Set(ByVal value As String)
                _HorFin = value
            End Set
        End Property
        Public Property MinFin() As String
            Get
                Return _MinFin
            End Get
            Set(ByVal value As String)
                _MinFin = value
            End Set
        End Property
        Public Property Profilaxis() As String
            Get
                Return _Profilaxis
            End Get
            Set(ByVal value As String)
                _Profilaxis = value
            End Set
        End Property
       
#End Region

        Public Function ConsultarReporteDescripcionQX(ByVal strcod_pre_sgs As String, _
                   ByVal strCod_sucur As String, ByVal strProcedim As String, ByVal strConsecutivo As Decimal, ByVal secuencia As Integer, _
                   Optional ByVal strTipAdmision As String = "", Optional ByVal ianoAdm As Integer = 0, Optional ByVal num_adm As Decimal = 0, _
                   Optional ByVal strTip_Doc As String = "", Optional ByVal strNum_Doc As String = "") As DataSet

            Dim objDescQx As New DAODescripcionQX
            Dim dsResultado As New DataSet


            dsResultado = objDescQx.ConsultaDatosReporteDescQx(strcod_pre_sgs, strCod_sucur, strProcedim, strConsecutivo, _
            secuencia, strTipAdmision, ianoAdm, num_adm, strTip_Doc, strNum_Doc)

            Return dsResultado
        End Function

        Public Function ConsultarReporteOrdenPatologia(ByVal strcod_pre_sgs As String, _
           ByVal strCod_sucur As String, ByVal strProcedim As String, ByVal strConsecutivo As Decimal, _
           Optional ByVal strTipAdmision As String = "", Optional ByVal ianoAdm As Integer = 0, Optional ByVal num_adm As Decimal = 0, _
           Optional ByVal strTip_Doc As String = "", Optional ByVal strNum_Doc As String = "") As DataSet

            Dim objDescQx As New DAODescripcionQX
            Dim dsResultado As New DataSet


            dsResultado = objDescQx.ConsultaDatosOrdenPatologia(strcod_pre_sgs, strCod_sucur, strProcedim, strConsecutivo, _
            strTipAdmision, ianoAdm, num_adm, strTip_Doc, strNum_Doc)

            Return dsResultado
        End Function

        Public Function CargarDescripcionQX(ByVal dt As DataTable, ByVal dtProfilaxis As DataTable) As List(Of DescripcionQx)

            Dim objDescQx As New DAODescripcionQX
            Dim listadescripcion As New List(Of DescripcionQx)
            Dim listaDiagnostico As New List(Of Diagnostico)
            Dim diagnos As New Diagnostico
            Dim objDescripcion As DescripcionQx
            Dim dsResultado As New DataSet
            Dim drFila As DataRow
            Dim objfrmdescripcion As New frmRepDescripcionQX




            For Each drFila In dt.Rows
                objDescripcion = New DescripcionQx()

                With objDescripcion
                    .Tejidos = drFila.Item("tejidos").ToString
                    .Intervencion = drFila.Item("NombreIntervencion").ToString
                    .TipoCirugia = drFila.Item("tipo_cirugia").ToString
                    .Hallazgos = drFila.Item("hallazgos").ToString
                    .TiempoQx = drFila.Item("tiempo_qx").ToString
                    .DescIntervencion = drFila.Item("desc_intervencion").ToString
                    .Complicaciones = drFila.Item("complicaciones").ToString
                    '     .Medico = drFila.Item("Medico").ToString
                    .Sangrado = drFila.Item("sangrado").ToString
                    .RecuentoMaterial = drFila.Item("recuento_material").ToString
                    .Anestesia = drFila.Item("Anestesia").ToString
                    .FechaIni = drFila.Item("FechaInicial").ToString
                    .FechaFin = drFila.Item("FechaFin").ToString
                    .HorIni = drFila.Item("HoraIni").ToString
                    .HorFin = drFila.Item("HorFin").ToString
                    .MinIni = drFila.Item("MinIni").ToString
                    .MinFin = drFila.Item("MinFin").ToString
                    If dtProfilaxis.Rows.Count > 0 Then

                        For i As Integer = 0 To dtProfilaxis.Rows.Count - 1
                            .Profilaxis = .Profilaxis & "- " & dtProfilaxis.Rows(i).Item("ProfilaxisAnt").ToString
                        Next

                    End If
                End With
                listadescripcion.Add(objDescripcion)
            Next

            Return listadescripcion
        End Function

        Public Function CargarDiagnosticoDescripcionQX(ByVal dt As DataTable) As List(Of Diagnostico)

            Dim objDescQx As New DAODescripcionQX
            Dim listaDiagnostico As New List(Of Diagnostico)
            Dim objDiagnostico As Diagnostico
            Dim dsResultado As New DataSet
            Dim drFila As DataRow



            For Each drFila In dt.Rows
                objDiagnostico = New Diagnostico()

                With objDiagnostico
                    .Codigo = drFila.Item("diagnost").ToString
                    .DescripDiagnostico = drFila.Item("descripcion").ToString
                    .Clase = drFila.Item("clase").ToString
                End With
                listaDiagnostico.Add(objDiagnostico)
            Next


            Return listaDiagnostico
        End Function
        Public Function ConsultarDiagnosticoDescripcionQX(ByVal dttable As DataTable) As List(Of Diagnostico)

            Dim objDescQx As New DAODescripcionQX
            Dim listaDiagnostico As New List(Of Diagnostico)
            Dim objDiagnostico As Diagnostico
            Dim dsResultado As New DataSet
            Dim drFila As DataRow

            '' dsResultado = objDescQx.ConsultaDatosReporteDescQx(strcod_pre_sgs, strCod_sucur, strProcedim, strConsecutivo)


            For Each drFila In dttable.Rows
                objDiagnostico = New Diagnostico()

                With objDiagnostico
                    .Codigo = drFila.Item("diagnost").ToString
                    .DescripDiagnostico = drFila.Item("descripcion").ToString
                    .Clase = drFila.Item("clase").ToString
                End With
                listaDiagnostico.Add(objDiagnostico)
            Next

            Me.Diagnosticos = listaDiagnostico
            Return Diagnosticos
        End Function




    End Class
End Namespace

