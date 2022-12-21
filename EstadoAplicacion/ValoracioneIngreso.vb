Imports System.Collections.Generic
Public Class ValoracioneIngreso
    Private Shared _Instancia As ValoracioneIngreso

    Private _CriteriodeIngreso As String
    Private _Diagnostico_oncologico As String
    Private _Diagnostico_no_oncologico As String
    Private _CumpleCI As String
    Private _Req_JP As String
    Private _ObsJuntaP As String
    Private _IngPrograma As String
    Private _Fec_Ingreso As String
    Private _AtencPrev As String
    Private _LugarAtencion As String
    Private _Fec_Diagnostico As String
    Private _ReqAten_HospUrg As String
    Private _Fec_Aten_HospUrg As String
    Private _Aten_Asoc_DiagBase As String
    Private _Obs_Aten_HospUrg As String
    Private _Aten_AmbUMes As String
    Private _Intervenciones As String
    Private _ObsIntervenciones As String
    Private _ConDiagnPac As String
    Private _ConPronPac As String
    Private _PideInfoPac As String
    Private _PideNoInfPac As String
    Private _ConDiagnFam As String
    Private _ConPronFam As String
    Private _PideInfoFam As String
    Private _PideNoInfFam As String
    Private _CercoSilen As String
    Private _InfSuf As String
    Private _criterio As String

    Public ReadOnly SeccionValeIng As Integer = 1



#Region "Propiedades"



    Public Shared ReadOnly Property Instancia() As ValoracioneIngreso
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ValoracioneIngreso
            End If
            Return _Instancia
        End Get
    End Property

    Public Property Fec_Ingreso() As String
        Get
            Return _Fec_Ingreso
        End Get
        Set(ByVal value As String)
            _Fec_Ingreso = value
        End Set

    End Property

    Public Property CriteriodeIngreso() As String
        Get
            Return _CriteriodeIngreso
        End Get
        Set(ByVal value As String)
            _CriteriodeIngreso = value
        End Set

    End Property
    Public Property Criterio() As String
        Get
            Return _criterio
        End Get
        Set(ByVal value As String)
            _criterio = value
        End Set

    End Property

    Public Property Diagnostico_oncologico() As String
        Get
            Return _Diagnostico_oncologico
        End Get
        Set(ByVal value As String)
            _Diagnostico_oncologico = value
        End Set
    End Property

    Public Property Diagnostico_no_oncologico() As String
        Get
            Return _Diagnostico_no_oncologico
        End Get
        Set(ByVal value As String)
            _Diagnostico_no_oncologico = value
        End Set
    End Property

    Public Property CumpleCI() As String
        Get
            Return _CumpleCI
        End Get
        Set(ByVal value As String)
            _CumpleCI = value
        End Set

    End Property

    Public Property Req_JP() As String
        Get
            Return _Req_JP
        End Get
        Set(ByVal value As String)
            _Req_JP = value
        End Set

    End Property

    Public Property ObsJuntaP() As String
        Get
            Return _ObsJuntaP
        End Get
        Set(ByVal value As String)
            _ObsJuntaP = value
        End Set

    End Property
    Public Property IngPrograma() As String
        Get
            Return _IngPrograma
        End Get
        Set(ByVal value As String)
            _IngPrograma = value
        End Set

    End Property

    Public Property AtencPrev() As String
        Get
            Return _AtencPrev
        End Get
        Set(ByVal value As String)
            _AtencPrev = value
        End Set

    End Property

    Public Property LugarAtencion() As String
        Get
            Return _LugarAtencion
        End Get
        Set(ByVal value As String)
            _LugarAtencion = value
        End Set

    End Property

    Public Property Fec_Diagnostico() As String
        Get
            Return _Fec_Diagnostico
        End Get
        Set(ByVal value As String)
            _Fec_Diagnostico = value
        End Set

    End Property
    Public Property ReqAten_HospUrg() As String
        Get
            Return _ReqAten_HospUrg
        End Get
        Set(ByVal value As String)
            _ReqAten_HospUrg = value
        End Set

    End Property
    Public Property Fec_Aten_HospUrg() As String
        Get
            Return _Fec_Aten_HospUrg
        End Get
        Set(ByVal value As String)
            _Fec_Aten_HospUrg = value
        End Set

    End Property

    Public Property Aten_Asoc_DiagBase() As String
        Get
            Return _Aten_Asoc_DiagBase
        End Get
        Set(ByVal value As String)
            _Aten_Asoc_DiagBase = value
        End Set

    End Property

    Public Property Obs_Aten_HospUrg() As String
        Get
            Return _Obs_Aten_HospUrg
        End Get
        Set(ByVal value As String)
            _Obs_Aten_HospUrg = value
        End Set

    End Property

    Public Property Aten_AmbUMes() As String
        Get
            Return _Aten_AmbUMes
        End Get
        Set(ByVal value As String)
            _Aten_AmbUMes = value
        End Set

    End Property
    Public Property Intervenciones() As String
        Get
            Return _Intervenciones
        End Get
        Set(ByVal value As String)
            _Intervenciones = value
        End Set

    End Property

    Public Property ObsIntervenciones() As String
        Get
            Return _ObsIntervenciones
        End Get
        Set(ByVal value As String)
            _ObsIntervenciones = value
        End Set

    End Property

    Public Property ConDiagnFam() As String
        Get
            Return _ConDiagnFam
        End Get
        Set(ByVal value As String)
            _ConDiagnFam = value
        End Set

    End Property

    Public Property ConPronFam() As String
        Get
            Return _ConPronFam
        End Get
        Set(ByVal value As String)
            _ConPronFam = value
        End Set

    End Property


    Public Property PideInfoFam() As String
        Get
            Return _PideInfoFam
        End Get
        Set(ByVal value As String)
            _PideInfoFam = value
        End Set

    End Property

    Public Property PideNoInfFam() As String
        Get
            Return _PideNoInfFam
        End Get
        Set(ByVal value As String)
            _PideNoInfFam = value
        End Set

    End Property



    Public Property ConDiagnPac() As String
        Get
            Return _ConDiagnPac
        End Get
        Set(ByVal value As String)
            _ConDiagnPac = value
        End Set

    End Property

    Public Property ConPronPac() As String
        Get
            Return _ConPronPac
        End Get
        Set(ByVal value As String)
            _ConPronPac = value
        End Set

    End Property


    Public Property PideInfoPac() As String
        Get
            Return _PideInfoPac
        End Get
        Set(ByVal value As String)
            _PideInfoPac = value
        End Set

    End Property

    Public Property PideNoInfPac() As String
        Get
            Return _PideNoInfPac
        End Get
        Set(ByVal value As String)
            _PideNoInfPac = value
        End Set

    End Property
    Public Property CercoSilen() As String
        Get
            Return _CercoSilen
        End Get
        Set(ByVal value As String)
            _CercoSilen = value
        End Set

    End Property
    Public Property InfSuf() As String
        Get
            Return _InfSuf
        End Get
        Set(ByVal value As String)
            _InfSuf = value
        End Set

    End Property




#End Region

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub Limpiar()


        _CriteriodeIngreso = ""
        _Diagnostico_oncologico = ""
        _Diagnostico_no_oncologico = ""
        _CumpleCI = ""
        _Req_JP = ""
        _ObsJuntaP = ""
        _IngPrograma = ""
        _Fec_Ingreso = ""
        _AtencPrev = ""
        _LugarAtencion = ""
        _Fec_Diagnostico = ""
        _ReqAten_HospUrg = ""
        _Fec_Aten_HospUrg = ""
        _Aten_Asoc_DiagBase = ""
        _Obs_Aten_HospUrg = ""
        _Aten_AmbUMes = ""
        _Intervenciones = ""
        _ObsIntervenciones = ""
        _ConDiagnPac = ""
        _ConPronPac = ""
        _PideInfoPac = ""
        _PideNoInfPac = ""
        _ConDiagnFam = ""
        _ConPronFam = ""
        _PideInfoFam = ""
        _PideNoInfFam = ""
        _CercoSilen = ""
        _InfSuf = ""
        _criterio = ""

        
    End Sub
    Public Function ConsultarPreguntas(ByVal oPreguntaCP As PreguntaCP) As List(Of PreguntaCP)
        Dim objDAPreguntaCP As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
        oPreguntaCP.seccion = Me.SeccionValeIng
        Return objDAPreguntaCP.ConsultarPreguntas(oPreguntaCP)
    End Function

End Class
