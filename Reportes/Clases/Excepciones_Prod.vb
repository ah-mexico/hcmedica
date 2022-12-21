''Claudia Garay Marzo 26 de 2012 Ctc's

Imports System.Collections.Generic
Imports System.Data.Common
Namespace Sophia.HistoriaClinica.Reportes
    Public Class ExcepcionesProd
        Inherits GPMDataReport

        ''Producto,procedim,medico
        Private _DescripcionProd As String
        Private _DescripcionProdNoPos As String
        Private _Concentracion As String
        Private _ConcentracionNoPos As String
        Private _Cums As String
        Private _CumsNoPos As String
        Private _ForFarma As String
        Private _ForFarmaNoPos As String
        Private _DiasTratamiento As String
        Private _DosisDia As String
        Private _DosisDiaNoPos As String
        Private _TipDocMed As String
        Private _NumDocMed As String
        Private _ApellidosMed As String
        Private _NombresMed As String
        Private _Especialidad As String
        Private _RegMed As String
        Private _CiuSucur As String
        Private _DirSucur As String
        Private _TeleSucur As String
        Private _JustificacionExcep As String
        Private _Dia As String
        Private _Mes As String
        Private _Ano As String
        Private _DiaDesde As String
        Private _MesDesde As String
        Private _AnoDesde As String
        Private _DiaHasta As String
        Private _MesHasta As String
        Private _AnoHasta As String
        Private _email As String

       


#Region "Producto"
        Public Property DescripcionProd() As String
            Get
                Return _DescripcionProd
            End Get
            Set(ByVal value As String)
                _DescripcionProd = value
            End Set
        End Property
        Public Property DescripcionProdNoPos() As String
            Get
                Return _DescripcionProdNoPos
            End Get
            Set(ByVal value As String)
                _DescripcionProdNoPos = value
            End Set
        End Property
        Public Property Concentracion() As String
            Get
                Return _Concentracion
            End Get
            Set(ByVal value As String)
                _Concentracion = value
            End Set
        End Property
        Public Property ConcentracionNoPos() As String
            Get
                Return _ConcentracionNoPos
            End Get
            Set(ByVal value As String)
                _ConcentracionNoPos = value
            End Set
        End Property
        Public Property Cums() As String
            Get
                Return _Cums
            End Get
            Set(ByVal value As String)
                _Cums = value
            End Set
        End Property
        Public Property CumsNoPos() As String
            Get
                Return _CumsNoPos
            End Get
            Set(ByVal value As String)
                _CumsNoPos = value
            End Set
        End Property
        Public Property ForFarma() As String
            Get
                Return _ForFarma
            End Get
            Set(ByVal value As String)
                _ForFarma = value
            End Set
        End Property
        Public Property ForFarmaNoPos() As String
            Get
                Return _ForFarmaNoPos
            End Get
            Set(ByVal value As String)
                _ForFarmaNoPos = value
            End Set
        End Property


        Public Property DiasTratamiento() As String
            Get
                Return _DiasTratamiento
            End Get
            Set(ByVal value As String)
                _DiasTratamiento = value
            End Set
        End Property
        Public Property DosisDia() As String
            Get
                Return _DosisDia
            End Get
            Set(ByVal value As String)
                _DosisDia = value
            End Set
        End Property
        Public Property DosisDiaNoPos() As String
            Get
                Return _DosisDiaNoPos
            End Get
            Set(ByVal value As String)
                _DosisDiaNoPos = value
            End Set
        End Property
        Public Property TipDocMed() As String
            Get
                Return _TipDocMed
            End Get
            Set(ByVal value As String)
                _TipDocMed = value
            End Set
        End Property
        Public Property NumDocMed() As String
            Get
                Return _NumDocMed
            End Get
            Set(ByVal value As String)
                _NumDocMed = value
            End Set
        End Property
        Public Property ApellidosMed() As String
            Get
                Return _ApellidosMed
            End Get
            Set(ByVal value As String)
                _ApellidosMed = value
            End Set
        End Property
        Public Property NombresMed() As String
            Get
                Return _NombresMed
            End Get
            Set(ByVal value As String)
                _NombresMed = value
            End Set
        End Property
        Public Property Especialidad() As String
            Get
                Return _Especialidad
            End Get
            Set(ByVal value As String)
                _Especialidad = value
            End Set
        End Property
        Public Property RegMed() As String
            Get
                Return _RegMed
            End Get
            Set(ByVal value As String)
                _RegMed = value
            End Set
        End Property
        Public Property CiuSucur() As String
            Get
                Return _CiuSucur
            End Get
            Set(ByVal value As String)
                _CiuSucur = value
            End Set
        End Property
        Public Property DirSucur() As String
            Get
                Return _DirSucur
            End Get
            Set(ByVal value As String)
                _DirSucur = value
            End Set
        End Property
        Public Property TeleSucur() As String
            Get
                Return _TeleSucur
            End Get
            Set(ByVal value As String)
                _TeleSucur = value
            End Set
        End Property
        Public Property JustificacionExcep() As String
            Get
                Return _JustificacionExcep
            End Get
            Set(ByVal value As String)
                _JustificacionExcep = value
            End Set
        End Property
        Public Property Dia() As String
            Get
                Return _Dia
            End Get
            Set(ByVal value As String)
                _Dia = value
            End Set
        End Property
        Public Property Mes() As String
            Get
                Return _Mes
            End Get
            Set(ByVal value As String)
                _Mes = value
            End Set
        End Property
        Public Property Ano() As String
            Get
                Return _Ano
            End Get
            Set(ByVal value As String)
                _Ano = value
            End Set
        End Property
        Public Property DiaDesde() As String
            Get
                Return _DiaDesde
            End Get
            Set(ByVal value As String)
                _DiaDesde = value
            End Set
        End Property
        Public Property MesDesde() As String
            Get
                Return _MesDesde
            End Get
            Set(ByVal value As String)
                _MesDesde = value
            End Set
        End Property
        Public Property AnoDesde() As String
            Get
                Return _AnoDesde
            End Get
            Set(ByVal value As String)
                _AnoDesde = value
            End Set
        End Property
        Public Property DiaHasta() As String
            Get
                Return _DiaHasta
            End Get
            Set(ByVal value As String)
                _DiaHasta = value
            End Set
        End Property
        Public Property MesHasta() As String
            Get
                Return _MesHasta
            End Get
            Set(ByVal value As String)
                _MesHasta = value
            End Set
        End Property
        Public Property AnoHasta() As String
            Get
                Return _AnoHasta
            End Get
            Set(ByVal value As String)
                _AnoHasta = value
            End Set
        End Property
        Public Property Email() As String
            Get
                Return _email
            End Get
            Set(ByVal value As String)
                _email = value
            End Set
        End Property
#End Region

       
    End Class
End Namespace

