Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports System.Data.Common
Namespace Sophia.HistoriaClinica.Reportes
    Public Class IdentificadoresRiesgo
        Inherits GPMDataReport

        Private _irIdRegistro As String    'Id Del registro  
        Private _identificadorRiesgo As String 'Identificador del riesgo
        Private _fechaAcivacion As String  'Fecha activacion del Identicador del riesgo
        Private _observacionActiva As String 'Observacion Activación
        Private _UsuarioActiva As String 'usuario Activación
        Private _EspecialidadActiva As String 'Especialidad o Cargo activación
        Private _FechaInacivacion As String ''Fecha inactivación del Identicador del riesgo
        Private _ObservacionInacivacion As String 'Observacion inactivación
        Private _UsuarioInacivacion As String ''usuario inactivación
        Private _EspecialidadInacivacion As String 'Especialidad o Cargo _EspecialidadInacivacion
        Private _fecha As String



        Public Sub New()
            MyBase.New()
        End Sub
        Public Property Fecha() As String
            Get
                Return _fecha
            End Get
            Set(ByVal value As String)
                _fecha = value
            End Set
        End Property
        Public Property IrIdRegistro() As String
            Get
                Return _irIdRegistro
            End Get
            Set(ByVal value As String)
                _irIdRegistro = value
            End Set
        End Property
        Public Property IdentificadorRiesgo() As String
            Get
                Return _identificadorRiesgo
            End Get
            Set(ByVal value As String)
                _identificadorRiesgo = value
            End Set
        End Property
        Public Property FechaAcivacion() As String
            Get
                Return _fechaAcivacion
            End Get
            Set(ByVal value As String)
                _fechaAcivacion = value
            End Set
        End Property
        Public Property ObservacionActiva() As String
            Get
                Return _observacionActiva
            End Get
            Set(ByVal value As String)
                _observacionActiva = value
            End Set
        End Property
        Public Property UsuarioActiva() As String
            Get
                Return _UsuarioActiva
            End Get
            Set(ByVal value As String)
                _UsuarioActiva = value
            End Set
        End Property
        Public Property EspecialidadActiva() As String
            Get
                Return _EspecialidadActiva
            End Get
            Set(ByVal value As String)
                _EspecialidadActiva = value
            End Set
        End Property
        Public Property FechaInacivacion() As String
            Get
                Return _FechaInacivacion
            End Get
            Set(ByVal value As String)
                _FechaInacivacion = value
            End Set
        End Property
        Public Property ObservacionInacivacion() As String
            Get
                Return _ObservacionInacivacion
            End Get
            Set(ByVal value As String)
                _ObservacionInacivacion = value
            End Set
        End Property
        Public Property UsuarioInacivacion() As String
            Get
                Return _UsuarioInacivacion
            End Get
            Set(ByVal value As String)
                _UsuarioInacivacion = value
            End Set
        End Property
        Public Property EspecialidadInacivacion() As String
            Get
                Return _EspecialidadInacivacion
            End Get
            Set(ByVal value As String)
                _EspecialidadInacivacion = value
            End Set
        End Property


        Public Sub New(ByVal irIdRegistro As String, ByVal fechaAcivacion As String, ByVal observacionActiva As String, ByVal UsuarioActiva As String,
                           ByVal EspecialidadActiva As String, ByVal FechaInacivacion As String, ByVal ObservacionInacivacion As String,
                           ByVal UsuarioInacivacion As String, ByVal EspecialidadInacivacion As String, fecha As String)

            _irIdRegistro = irIdRegistro
            _fechaAcivacion = fechaAcivacion
            _observacionActiva = observacionActiva
            _UsuarioActiva = UsuarioActiva
            _EspecialidadActiva = EspecialidadActiva
            _FechaInacivacion = FechaInacivacion
            _ObservacionInacivacion = ObservacionInacivacion
            _UsuarioInacivacion = UsuarioInacivacion
            _EspecialidadInacivacion = EspecialidadInacivacion
            _fecha = fecha

        End Sub

        Public Function consultarIdentificadoresRiesgo(ByVal objConexion As Conexion, ByVal dCod_Historia As Integer, ByVal strFechaIni As Nullable(Of Date),
                                                           ByVal strFechaFin As Nullable(Of Date), ByVal iHoraIni As Nullable(Of Integer),
                                                           ByVal iHoraFin As Nullable(Of Integer)) As List(Of IdentificadoresRiesgo)
            Dim lError As Long = 0
            Dim objIdentificadoresRiesgo As IdentificadoresRiesgo
            Dim listaIdentificadoresRiesgo As New List(Of IdentificadoresRiesgo)
            Dim dtSetReturn As DataSet
            gpmDataObj.setSQLSentence("HC_CONSULTAR_HISTORICOS_IDENTIFICADOR_RIESGO", CommandType.StoredProcedure)
            gpmDataObj.addInputParameter("@codHistoria", SqlDbType.Int, dCod_Historia)
            gpmDataObj.addInputParameter("@strFechaIni", SqlDbType.DateTime, strFechaIni)
            gpmDataObj.addInputParameter("@strFechaFin", SqlDbType.DateTime, strFechaFin)
            gpmDataObj.addInputParameter("@iHoraIni", SqlDbType.Int, iHoraIni)
            gpmDataObj.addInputParameter("@iHoraFin", SqlDbType.Int, iHoraFin)


            dtSetReturn = gpmDataObj.execDS() 'llarias1


            For i As Integer = 0 To dtSetReturn.Tables(0).Rows.Count.ToString() - 1
                objIdentificadoresRiesgo = New IdentificadoresRiesgo
                With objIdentificadoresRiesgo

                    .IrIdRegistro = dtSetReturn.Tables(0).Rows(i).Item("IrIdRegistro").ToString()
                    .IdentificadorRiesgo = dtSetReturn.Tables(0).Rows(i).Item("IdentificadorRiesgo").ToString()
                    .FechaAcivacion = dtSetReturn.Tables(0).Rows(i).Item("FechaAcivacion").ToString()
                    .ObservacionActiva = dtSetReturn.Tables(0).Rows(i).Item("ObservacionActiva").ToString()
                    .UsuarioActiva = dtSetReturn.Tables(0).Rows(i).Item("UsuarioActiva").ToString()
                    .EspecialidadActiva = dtSetReturn.Tables(0).Rows(i).Item("EspecialidadActiva").ToString()
                    .FechaInacivacion = dtSetReturn.Tables(0).Rows(i).Item("FechaInacivacion").ToString()
                    .ObservacionInacivacion = dtSetReturn.Tables(0).Rows(i).Item("ObservacionInacivacion").ToString()
                    .UsuarioInacivacion = dtSetReturn.Tables(0).Rows(i).Item("UsuarioInacivacion").ToString()
                    .EspecialidadInacivacion = dtSetReturn.Tables(0).Rows(i).Item("EspecialidadInacivacion").ToString()
                    .Fecha = dtSetReturn.Tables(0).Rows(i).Item("Fecha").ToString()


                    listaIdentificadoresRiesgo.Add(objIdentificadoresRiesgo)
                End With

            Next


            Return listaIdentificadoresRiesgo


            'Return gpmDataObj.execDT
        End Function





    End Class

    Public Class IdentificadoresRiesgoConsolidado
        Inherits GPMDataReport

        Private _irIdRegistro As String    'Id Del registro  
        Private _identificadorRiesgo As String 'Identificador del riesgo
        Private _fechaAcivacion As String  'Fecha activacion del Identicador del riesgo
        Private _observacionActiva As String 'Observacion Activación
        Private _UsuarioActiva As String 'usuario Activación
        Private _EspecialidadActiva As String 'Especialidad o Cargo activación
        Private _FechaInacivacion As String ''Fecha inactivación del Identicador del riesgo
        Private _ObservacionInacivacion As String 'Observacion inactivación
        Private _UsuarioInacivacion As String ''usuario inactivación
        Private _EspecialidadInacivacion As String 'Especialidad o Cargo _EspecialidadInacivacion
        Private _fecha As String




        Public Sub New()
            MyBase.New()
        End Sub
        Public Property Fecha() As String
            Get
                Return _fecha
            End Get
            Set(ByVal value As String)
                _fecha = value
            End Set
        End Property
        Public Property IrIdRegistro() As String
            Get
                Return _irIdRegistro
            End Get
            Set(ByVal value As String)
                _irIdRegistro = value
            End Set
        End Property
        Public Property IdentificadorRiesgo() As String
            Get
                Return _identificadorRiesgo
            End Get
            Set(ByVal value As String)
                _identificadorRiesgo = value
            End Set
        End Property
        Public Property FechaAcivacion() As String
            Get
                Return _fechaAcivacion
            End Get
            Set(ByVal value As String)
                _fechaAcivacion = value
            End Set
        End Property
        Public Property ObservacionActiva() As String
            Get
                Return _observacionActiva
            End Get
            Set(ByVal value As String)
                _observacionActiva = value
            End Set
        End Property
        Public Property UsuarioActiva() As String
            Get
                Return _UsuarioActiva
            End Get
            Set(ByVal value As String)
                _UsuarioActiva = value
            End Set
        End Property
        Public Property EspecialidadActiva() As String
            Get
                Return _EspecialidadActiva
            End Get
            Set(ByVal value As String)
                _EspecialidadActiva = value
            End Set
        End Property
        Public Property FechaInacivacion() As String
            Get
                Return _FechaInacivacion
            End Get
            Set(ByVal value As String)
                _FechaInacivacion = value
            End Set
        End Property
        Public Property ObservacionInacivacion() As String
            Get
                Return _ObservacionInacivacion
            End Get
            Set(ByVal value As String)
                _ObservacionInacivacion = value
            End Set
        End Property
        Public Property UsuarioInacivacion() As String
            Get
                Return _UsuarioInacivacion
            End Get
            Set(ByVal value As String)
                _UsuarioInacivacion = value
            End Set
        End Property
        Public Property EspecialidadInacivacion() As String
            Get
                Return _EspecialidadInacivacion
            End Get
            Set(ByVal value As String)
                _EspecialidadInacivacion = value
            End Set
        End Property

        Public Sub New(ByVal irIdRegistro As String, ByVal fechaAcivacion As String, ByVal observacionActiva As String, ByVal UsuarioActiva As String,
                           ByVal EspecialidadActiva As String, ByVal FechaInacivacion As String, ByVal ObservacionInacivacion As String,
                           ByVal UsuarioInacivacion As String, ByVal EspecialidadInacivacion As String, fecha As String)


            _irIdRegistro = irIdRegistro
            _fechaAcivacion = fechaAcivacion
            _observacionActiva = observacionActiva
            _UsuarioActiva = UsuarioActiva
            _EspecialidadActiva = EspecialidadActiva
            _FechaInacivacion = FechaInacivacion
            _ObservacionInacivacion = ObservacionInacivacion
            _UsuarioInacivacion = UsuarioInacivacion
            _EspecialidadInacivacion = EspecialidadInacivacion
            _fecha = fecha

        End Sub

        Public Function consultarIdentificadoresRiesgoCon(ByVal objConexion As Conexion, ByVal dCod_Historia As Integer, ByVal strFechaIni As Nullable(Of Date),
                                                           ByVal strFechaFin As Nullable(Of Date), ByVal iHoraIni As Nullable(Of Integer),
                                                           ByVal iHoraFin As Nullable(Of Integer), ByVal strPrestador As String, ByVal strSucursal As String,
                                                           ByVal strTipoAdmision As String, ByVal anoadmision As Int64, ByVal admision As Int64,
                                                           ByVal tip_doc As String, ByVal num_doc As String) As List(Of IdentificadoresRiesgoConsolidado)
            Dim lError As Long = 0
            Dim objIdentificadoresRiesgo As IdentificadoresRiesgoConsolidado
            Dim listaIdentificadoresRiesgo As New List(Of IdentificadoresRiesgoConsolidado)
            Dim dtSetReturn As DataSet
            gpmDataObj.setSQLSentence("HC_CONSULTAR_HISTORICOS_IDENTIFICADOR_RIESGO_CON", CommandType.StoredProcedure)
            gpmDataObj.addInputParameter("@Tip_Doc", SqlDbType.NVarChar, tip_doc)
            gpmDataObj.addInputParameter("@Num_doc", SqlDbType.NVarChar, num_doc)
            gpmDataObj.addInputParameter("@cod_pre_sgs", SqlDbType.NVarChar, strPrestador)
            gpmDataObj.addInputParameter("@cod_sucur", SqlDbType.NVarChar, strSucursal)
            gpmDataObj.addInputParameter("@tip_admision", SqlDbType.NVarChar, strTipoAdmision)
            gpmDataObj.addInputParameter("@ano_adm", SqlDbType.Int, anoadmision)
            gpmDataObj.addInputParameter("@num_adm", SqlDbType.Int, admision)
            gpmDataObj.addInputParameter("@strFechaIni", SqlDbType.DateTime, strFechaIni)
            gpmDataObj.addInputParameter("@strFechaFin", SqlDbType.DateTime, strFechaFin)
            gpmDataObj.addInputParameter("@iHoraIni", SqlDbType.Int, iHoraIni)
            gpmDataObj.addInputParameter("@iHoraFin", SqlDbType.Int, iHoraFin)


            dtSetReturn = gpmDataObj.execDS()


            For i As Integer = 0 To dtSetReturn.Tables(0).Rows.Count.ToString() - 1
                objIdentificadoresRiesgo = New IdentificadoresRiesgoConsolidado
                With objIdentificadoresRiesgo
                    IrIdRegistro = dtSetReturn.Tables(0).Rows(i).Item("IrIdRegistro").ToString()
                    .IdentificadorRiesgo = dtSetReturn.Tables(0).Rows(i).Item("IdentificadorRiesgo").ToString()
                    .FechaAcivacion = dtSetReturn.Tables(0).Rows(i).Item("FechaAcivacion").ToString()
                    .ObservacionActiva = dtSetReturn.Tables(0).Rows(i).Item("ObservacionActiva").ToString()
                    .UsuarioActiva = dtSetReturn.Tables(0).Rows(i).Item("UsuarioActiva").ToString()
                    .EspecialidadActiva = dtSetReturn.Tables(0).Rows(i).Item("EspecialidadActiva").ToString()
                    .FechaInacivacion = dtSetReturn.Tables(0).Rows(i).Item("FechaInacivacion").ToString()
                    .ObservacionInacivacion = dtSetReturn.Tables(0).Rows(i).Item("ObservacionInacivacion").ToString()
                    .UsuarioInacivacion = dtSetReturn.Tables(0).Rows(i).Item("UsuarioInacivacion").ToString()
                    .EspecialidadInacivacion = dtSetReturn.Tables(0).Rows(i).Item("EspecialidadInacivacion").ToString()
                    .Fecha = dtSetReturn.Tables(0).Rows(i).Item("Fecha").ToString()

                    listaIdentificadoresRiesgo.Add(objIdentificadoresRiesgo)
                End With

            Next


            Return listaIdentificadoresRiesgo


            'Return gpmDataObj.execDT
        End Function

    End Class
End Namespace


