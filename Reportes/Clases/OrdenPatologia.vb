
Imports System.Data.Common
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.Controles
Imports HistoriaClinica.Sophia.HistoriaClinica.HistoriaBasica
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Namespace Sophia.HistoriaClinica.Reportes
    Public Class OrdenPatologia

        Inherits GPMDataReport

        Private dtDiagnosticos As New List(Of Diagnostico)
        Private strmedico_solicita As String
        Private strdes_medico As String
        Private strtipo_cirugia As String
        Private strhallazgos As String
        Private strseccion As String
        Private strdes_seccion As String
        Private strestudio_sol As String
        Private strcod_muestra As String
        Private strdes_muestra As String
        Private strorgano As String
        Private strprocedimiento As String
        Private strdes_procedimiento As String
        Private strespecialidad_sol As String

#Region "Propiedades"

        Public Property Diagnosticos() As List(Of Diagnostico)
            Get
                Return dtDiagnosticos
            End Get
            Set(ByVal value As List(Of Diagnostico))
                dtDiagnosticos = value
            End Set
        End Property

        Public Property especialidad_sol() As String
            Get
                Return strespecialidad_sol
            End Get
            Set(ByVal value As String)
                strespecialidad_sol = value
            End Set
        End Property
        Public Property procedimiento() As String
            Get
                Return strprocedimiento
            End Get
            Set(ByVal value As String)
                strprocedimiento = value
            End Set
        End Property

        Public Property des_procedimiento() As String
            Get
                Return strdes_procedimiento
            End Get
            Set(ByVal value As String)
                strdes_procedimiento = value
            End Set
        End Property

        Public Property medico_solicita() As String
            Get
                Return strmedico_solicita
            End Get
            Set(ByVal value As String)
                strmedico_solicita = value
            End Set
        End Property


        Public Property organo() As String
            Get
                Return strorgano
            End Get
            Set(ByVal value As String)
                strorgano = value
            End Set
        End Property

        Public Property des_medico() As String
            Get
                Return strdes_medico
            End Get
            Set(ByVal value As String)
                strdes_medico = value
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
        Public Property seccion() As String
            Get
                Return strseccion
            End Get
            Set(ByVal value As String)
                strseccion = value
            End Set
        End Property
        Public Property des_seccion() As String
            Get
                Return strdes_seccion
            End Get
            Set(ByVal value As String)
                strdes_seccion = value
            End Set
        End Property
        Public Property estudio_sol() As String
            Get
                Return strestudio_sol
            End Get
            Set(ByVal value As String)
                strestudio_sol = value
            End Set
        End Property
        Public Property cod_muestra() As String
            Get
                Return strcod_muestra
            End Get
            Set(ByVal value As String)
                strcod_muestra = value
            End Set
        End Property
        Public Property des_muestra() As String
            Get
                Return strdes_muestra
            End Get
            Set(ByVal value As String)
                strdes_muestra = value
            End Set
        End Property



#End Region



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

        Public Function CargarReporteOrdenPatologia(ByVal dt As DataTable) As List(Of OrdenPatologia)

            Dim objDescQx As New DAODescripcionQX
            Dim listadescripcion As New List(Of OrdenPatologia)
            Dim listaDiagnostico As New List(Of Diagnostico)
            Dim diagnos As New Diagnostico
            Dim objDescripcion As OrdenPatologia
            Dim dsResultado As New DataSet
            Dim drFila As DataRow
            Dim objfrmdescripcion As New frmRepDescripcionQX




            For Each drFila In dt.Rows
                objDescripcion = New OrdenPatologia()

                With objDescripcion
                    .organo = drFila.Item("organo").ToString
                    .medico_solicita = drFila.Item("medico_solicita").ToString
                    .des_medico = drFila.Item("des_medico").ToString
                    .Hallazgos = drFila.Item("hallazgos").ToString
                    .seccion = drFila.Item("seccion").ToString
                    .des_seccion = drFila.Item("des_seccion").ToString
                    .cod_muestra = drFila.Item("cod_muestra").ToString
                    .des_muestra = drFila.Item("des_muestra").ToString
                    .procedimiento = drFila.Item("procedim").ToString
                    .des_procedimiento = drFila.Item("des_procedim").ToString
                    .estudio_sol = drFila.Item("estudio_sol").ToString
                    .especialidad_sol = drFila.Item("especialidadSolicita").ToString
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

