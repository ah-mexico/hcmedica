Imports System.Linq
Imports System.Reflection
Imports System.Collections.Generic
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.ComponentModel

Namespace Sophia.HistoriaClinica.Controles


    ''' <summary>
    ''' 
    ''' </summary>
    <Serializable()>
    Public Class Diagnostico
        Implements IDisposable

#Region "Enum"
        Public Enum ClaseDiagnostico
            <Description("I")> Ingreso
            <Description("EVL")> Evolucion
            <Description("E")> Egreso
            <Description("D")> DescripcionQX
        End Enum

        Public Enum CategoriaDiagnostico
            <Description("A")> Asociado
            <Description("P")> Principal
            <Description("C")> Complicacion
        End Enum

        Public Enum EstadoDiagnostico
            Activo = 1
            Resuelto = 2
            Descartado = 3
        End Enum

        'Public Shared Function EnumDescription(ByVal EnumConstant As [Enum]) As String
        '    Dim fi As Reflection.FieldInfo = EnumConstant.GetType().GetField(EnumConstant.ToString())
        '    Dim aattr() As DescriptionAttribute = DirectCast(fi.GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())
        '    If aattr.Length > 0 Then
        '        Return aattr(0).Description
        '    Else
        '        Return EnumConstant.ToString()
        '    End If
        'End Function
#End Region

#Region "Properties"


        Private _COD_PRE_SGS As String
        Private _COD_SUCUR As String
        Private _TIP_DOC As String
        Private _NUM_DOC As String
        Private _TIP_ADMISION As String
        Private _ANO_ADM As Integer
        Private _NUM_ADM As Decimal
        Private _CLASE_DIAG As String
        Private _TIP_DIAG As String
        Private _TIPO_DIAGNOSTICO As String
        Private _DIAGNOST As String
        Private _DIAGNOSTICO As String
        Private _ANTECEDENTE As String
        Private _FEC_CON As DateTime
        Private _LOGIN As String
        Private _OBS As String
        Private _CONFIDENCIAL As String
        Private _CLASIFICACION As String
        Private _CATEGORIA_DIAG As String
        Private _CATEGORIA As String

        Private _IDESTADODIAGNOSTICO As Integer
        Private _ESTADO As String
        Private _ORIGEN As Integer
        Private _SECUENCIA As Integer

        Private _LSTDIAGNOSTICO As New List(Of Diagnostico)
        Public Property COD_PRE_SGS() As String
            Get
                Return _COD_PRE_SGS
            End Get
            Set(ByVal VALUE As String)
                _COD_PRE_SGS = VALUE
            End Set
        End Property

        Public Property COD_SUCUR() As String
            Get
                Return _COD_SUCUR
            End Get
            Set(ByVal VALUE As String)
                _COD_SUCUR = VALUE
            End Set
        End Property

        Public Property TIP_DOC() As String
            Get
                Return _TIP_DOC
            End Get
            Set(ByVal VALUE As String)
                _TIP_DOC = VALUE
            End Set
        End Property

        Public Property NUM_DOC() As String
            Get
                Return _NUM_DOC
            End Get
            Set(ByVal VALUE As String)
                _NUM_DOC = VALUE
            End Set
        End Property

        Public Property TIP_ADMISION() As String
            Get
                Return _TIP_ADMISION
            End Get
            Set(ByVal VALUE As String)
                _TIP_ADMISION = VALUE
            End Set
        End Property

        Public Property ANO_ADM() As Integer
            Get
                Return _ANO_ADM
            End Get
            Set(ByVal VALUE As Integer)
                _ANO_ADM = VALUE
            End Set
        End Property

        Public Property NUM_ADM() As Decimal
            Get
                Return _NUM_ADM
            End Get
            Set(ByVal VALUE As Decimal)
                _NUM_ADM = VALUE
            End Set
        End Property

        Public Property CLASE_DIAG() As String
            Get
                Return _CLASE_DIAG
            End Get
            Set(ByVal VALUE As String)
                _CLASE_DIAG = VALUE
            End Set
        End Property

        Public Property TIP_DIAG() As String
            Get
                Return _TIP_DIAG
            End Get
            Set(ByVal VALUE As String)
                _TIP_DIAG = VALUE
            End Set
        End Property

        Public Property TIPO_DIAGNOSTICO() As String
            Get
                Return _TIPO_DIAGNOSTICO
            End Get
            Set(ByVal VALUE As String)
                _TIPO_DIAGNOSTICO = VALUE
            End Set
        End Property

        Public Property DIAGNOST() As String
            Get
                Return _DIAGNOST
            End Get
            Set(ByVal VALUE As String)
                _DIAGNOST = VALUE
            End Set
        End Property

        Public Property DIAGNOSTICO() As String
            Get
                Return _DIAGNOSTICO
            End Get
            Set(ByVal VALUE As String)
                _DIAGNOSTICO = VALUE
            End Set
        End Property

        Public Property ANTECEDENTE() As String
            Get
                Return _ANTECEDENTE
            End Get
            Set(ByVal VALUE As String)
                _ANTECEDENTE = VALUE
            End Set
        End Property

        Public Property FEC_CON() As DateTime
            Get
                Return _FEC_CON
            End Get
            Set(ByVal VALUE As DateTime)
                _FEC_CON = VALUE
            End Set
        End Property

        Public Property LOGIN() As String
            Get
                Return _LOGIN
            End Get
            Set(ByVal VALUE As String)
                _LOGIN = VALUE
            End Set
        End Property

        Public Property OBS() As String
            Get
                Return _OBS
            End Get
            Set(ByVal VALUE As String)
                _OBS = VALUE
            End Set
        End Property

        Public Property CONFIDENCIAL() As String
            Get
                Return _CONFIDENCIAL
            End Get
            Set(ByVal VALUE As String)
                _CONFIDENCIAL = VALUE
            End Set
        End Property

        Public Property CLASIFICACION() As String
            Get
                Return _CLASIFICACION
            End Get
            Set(ByVal VALUE As String)
                _CLASIFICACION = VALUE
            End Set
        End Property

        Public Property CATEGORIA_DIAG() As String
            Get
                Return _CATEGORIA_DIAG
            End Get
            Set(ByVal VALUE As String)
                _CATEGORIA_DIAG = VALUE
            End Set
        End Property

        Public Property CATEGORIA() As String
            Get
                Return _CATEGORIA
            End Get
            Set(ByVal VALUE As String)
                _CATEGORIA = VALUE
            End Set
        End Property

        Public Property IDESTADODIAGNOSTICO() As Integer
            Get
                Return _IDESTADODIAGNOSTICO
            End Get
            Set(ByVal VALUE As Integer)
                _IDESTADODIAGNOSTICO = VALUE
            End Set
        End Property

        Public Property ESTADO() As String
            Get
                Return _ESTADO
            End Get
            Set(ByVal VALUE As String)
                _ESTADO = VALUE
            End Set
        End Property

        Public Property ORIGEN() As Integer
            Get
                Return _ORIGEN
            End Get
            Set(ByVal VALUE As Integer)
                _ORIGEN = VALUE
            End Set
        End Property

        Public Property SECUENCIA() As Integer
            Get
                Return _SECUENCIA
            End Get
            Set(ByVal VALUE As Integer)
                _SECUENCIA = VALUE
            End Set
        End Property
        Public Property lstDiagnostico As List(Of Diagnostico)
            Get
                Return _LSTDIAGNOSTICO
            End Get
            Set(ByVal Value As List(Of Diagnostico))
                _LSTDIAGNOSTICO = Value
            End Set
        End Property



#End Region

        '// Constructor \\
        Public Sub New()

        End Sub

        Private Shared _Instancia As Diagnostico
        Public Shared ReadOnly Property Instancia() As Diagnostico
            Get
                If _Instancia Is Nothing Then
                    _Instancia = New Diagnostico
                End If
                Return _Instancia
            End Get
        End Property
        Private disposedValue As Boolean = False        ' To detect redundant calls

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ' TODO: free unmanaged resources when explicitly called
                End If
                _Instancia = Nothing
                ' TODO: free shared unmanaged resources
            End If
            Me.disposedValue = True
        End Sub

#Region " IDisposable Support "
        ' This code added by Visual Basic to correctly implement the disposable pattern.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' Do not change this code.  Put cleanup code in Dispose(ByVal disposing As Boolean) above.
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
#End Region

#Region "Functions"
        Public Function getDiagnostico(ByVal objConexion As Conexion, ByRef lError As Long, ByVal pDiagnostico As Diagnostico) As List(Of Diagnostico)
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim Param() As Object

            ReDim Param(5)
            Param(0) = pDiagnostico.COD_PRE_SGS
            Param(1) = pDiagnostico.COD_SUCUR
            Param(2) = pDiagnostico.TIP_ADMISION
            Param(3) = pDiagnostico.ANO_ADM
            Param(4) = pDiagnostico.NUM_ADM
            Param(5) = pDiagnostico.CLASE_DIAG

            Return obj.ConvertDataTableToList(Of Diagnostico)(obj.EjecutarSPConParametros("HC_EV_GET_DIAGNOSTICOS", objConexion, lError, Param))
        End Function

        Public Function addDiagnostico(ByVal objConexion As Conexion, ByRef lError As Long, ByVal pDiagnostico As Diagnostico) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim Param() As Object

            ReDim Param(17)

            Param(0) = pDiagnostico.COD_PRE_SGS
            Param(1) = pDiagnostico.COD_SUCUR
            Param(2) = pDiagnostico.TIP_DOC
            Param(3) = pDiagnostico.NUM_DOC
            Param(4) = pDiagnostico.TIP_ADMISION
            Param(5) = pDiagnostico.NUM_ADM
            Param(6) = pDiagnostico.ANO_ADM
            Param(7) = pDiagnostico.CLASE_DIAG
            Param(8) = pDiagnostico.TIP_DIAG
            Param(9) = pDiagnostico.DIAGNOST
            Param(10) = pDiagnostico.ANTECEDENTE
            Param(11) = pDiagnostico.OBS
            Param(12) = pDiagnostico.CONFIDENCIAL
            Param(13) = pDiagnostico.CLASIFICACION
            Param(14) = pDiagnostico.CATEGORIA_DIAG
            Param(15) = pDiagnostico.LOGIN
            Param(16) = pDiagnostico.IDESTADODIAGNOSTICO
            Param(17) = lError

            Return lError = obj.EjecutarSPConParametrosTran("HC_ADD_DIAGNOSTICO", objConexion, Param)

        End Function

        Public Function delDiagnostico(ByVal objconexion As Conexion, ByRef lError As Long, ByVal oDiagnostico As Diagnostico) As Long

            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim Param() As Object

            ReDim Param(6)

            Param(0) = oDiagnostico.COD_PRE_SGS
            Param(1) = oDiagnostico.COD_SUCUR
            Param(2) = oDiagnostico.TIP_ADMISION
            Param(3) = oDiagnostico.NUM_ADM
            Param(4) = oDiagnostico.ANO_ADM
            Param(5) = oDiagnostico.DIAGNOST
            Param(6) = lError

            Return lError = obj.EjecutarSPConParametrosTran("HC_DEL_DIAGNOSTICO", objconexion, Param)

        End Function

#End Region
    End Class

End Namespace