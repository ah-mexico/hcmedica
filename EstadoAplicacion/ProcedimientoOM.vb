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
    Public Class ProcedimientoOM
        Implements IDisposable

#Region "Enum"

        Public Enum EstadoProcedimientoOM
            SIN_RESPONDER = 1
            PENDIENTE_CIERRE = 2
            CERRADA = 3
        End Enum

#End Region

#Region "PROPERTIES"
        Private _COD_PRE_SGS As String
        Private _COD_SUCUR As String
        Private _TIP_ADMISION As String
        Private _NUM_ADM As Decimal
        Private _ANO_ADM As Integer
        Private _NROORDEN As Decimal
        Private _PROCEDIMIENTO As String
        Private _CANTIDAD As String
        Private _MEDICO As String
        Private _ESPECIALIDAD As String
        Private _CEN_COSTO_ORIGEN As String
        Private _CEN_COSTO As String
        Private _NROPEDIDO As Decimal
        Private _FEC_CON As DateTime
        Private _LOGIN As String
        Private _OBS As String
        Private _TIPSERV As String
        Private _PRIORI As String
        Private _GUIA As String
        Private _JUSTIFICACION As String
        Private _ESTADOPLANEA As String
        Private _JUSTIFICACION_EXCEP As String
        Private _ENTIDAD As String
        Private _CODIGO_RIS As String
        Private _CODIGOLABORATORIO As Integer
        Private _AUTOSISPRO As String
        Private _IDESTADOINTERCONSULTA As Integer

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

        Public Property TIP_ADMISION() As String
            Get
                Return _TIP_ADMISION
            End Get
            Set(ByVal VALUE As String)
                _TIP_ADMISION = VALUE
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

        Public Property ANO_ADM() As Integer
            Get
                Return _ANO_ADM
            End Get
            Set(ByVal VALUE As Integer)
                _ANO_ADM = VALUE
            End Set
        End Property

        Public Property NROORDEN() As Decimal
            Get
                Return _NROORDEN
            End Get
            Set(ByVal VALUE As Decimal)
                _NROORDEN = VALUE
            End Set
        End Property

        Public Property PROCEDIMIENTO() As String
            Get
                Return _PROCEDIMIENTO
            End Get
            Set(ByVal VALUE As String)
                _PROCEDIMIENTO = VALUE
            End Set
        End Property

        Public Property CANTIDAD() As String
            Get
                Return _CANTIDAD
            End Get
            Set(ByVal VALUE As String)
                _CANTIDAD = VALUE
            End Set
        End Property

        Public Property MEDICO() As String
            Get
                Return _MEDICO
            End Get
            Set(ByVal VALUE As String)
                _MEDICO = VALUE
            End Set
        End Property

        Public Property ESPECIALIDAD() As String
            Get
                Return _ESPECIALIDAD
            End Get
            Set(ByVal VALUE As String)
                _ESPECIALIDAD = VALUE
            End Set
        End Property

        Public Property CEN_COSTO_ORIGEN() As String
            Get
                Return _CEN_COSTO_ORIGEN
            End Get
            Set(ByVal VALUE As String)
                _CEN_COSTO_ORIGEN = VALUE
            End Set
        End Property

        Public Property CEN_COSTO() As String
            Get
                Return _CEN_COSTO
            End Get
            Set(ByVal VALUE As String)
                _CEN_COSTO = VALUE
            End Set
        End Property

        Public Property NROPEDIDO() As Decimal
            Get
                Return _NROPEDIDO
            End Get
            Set(ByVal VALUE As Decimal)
                _NROPEDIDO = VALUE
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

        Public Property TIPSERV() As String
            Get
                Return _TIPSERV
            End Get
            Set(ByVal VALUE As String)
                _TIPSERV = VALUE
            End Set
        End Property

        Public Property PRIORI() As String
            Get
                Return _PRIORI
            End Get
            Set(ByVal VALUE As String)
                _PRIORI = VALUE
            End Set
        End Property

        Public Property GUIA() As String
            Get
                Return _GUIA
            End Get
            Set(ByVal VALUE As String)
                _GUIA = VALUE
            End Set
        End Property

        Public Property JUSTIFICACION() As String
            Get
                Return _JUSTIFICACION
            End Get
            Set(ByVal VALUE As String)
                _JUSTIFICACION = VALUE
            End Set
        End Property

        Public Property ESTADOPLANEA() As String
            Get
                Return _ESTADOPLANEA
            End Get
            Set(ByVal VALUE As String)
                _ESTADOPLANEA = VALUE
            End Set
        End Property

        Public Property JUSTIFICACION_EXCEP() As String
            Get
                Return _JUSTIFICACION_EXCEP
            End Get
            Set(ByVal VALUE As String)
                _JUSTIFICACION_EXCEP = VALUE
            End Set
        End Property

        Public Property ENTIDAD() As String
            Get
                Return _ENTIDAD
            End Get
            Set(ByVal VALUE As String)
                _ENTIDAD = VALUE
            End Set
        End Property

        Public Property CODIGO_RIS() As String
            Get
                Return _CODIGO_RIS
            End Get
            Set(ByVal VALUE As String)
                _CODIGO_RIS = VALUE
            End Set
        End Property

        Public Property CODIGOLABORATORIO() As Integer
            Get
                Return _CODIGOLABORATORIO
            End Get
            Set(ByVal VALUE As Integer)
                _CODIGOLABORATORIO = VALUE
            End Set
        End Property

        Public Property AUTOSISPRO() As String
            Get
                Return _AUTOSISPRO
            End Get
            Set(ByVal VALUE As String)
                _AUTOSISPRO = VALUE
            End Set
        End Property

        Public Property IDESTADOINTERCONSULTA() As Integer
            Get
                Return _IDESTADOINTERCONSULTA
            End Get
            Set(ByVal VALUE As Integer)
                _IDESTADOINTERCONSULTA = VALUE
            End Set
        End Property

        Private _CONTESTAIC As Integer
        Public Property CONTESTAIC() As Integer
            Get
                Return _CONTESTAIC
            End Get
            Set(ByVal VALUE As Integer)
                _CONTESTAIC = VALUE
            End Set
        End Property

        Private _FECHA As String
        Public Property FECHA() As String
            Get
                Return _FECHA
            End Get
            Set(ByVal VALUE As String)
                _FECHA = VALUE
            End Set
        End Property

        Private _ESTADO As String
        Public Property ESTADO() As String
            Get
                Return _ESTADO
            End Get
            Set(ByVal VALUE As String)
                _ESTADO = VALUE
            End Set
        End Property
        Private _INTERCONSULTA As String
        Public Property INTERCONSULTA() As String
            Get
                Return _INTERCONSULTA
            End Get
            Set(ByVal VALUE As String)
                _INTERCONSULTA = VALUE
            End Set
        End Property

#End Region
        '// Constructor \\
        Public Sub New()

        End Sub

        Private Shared _Instancia As ProcedimientoOM
        Public Shared ReadOnly Property Instancia() As ProcedimientoOM
            Get
                If _Instancia Is Nothing Then
                    _Instancia = New ProcedimientoOM
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
        Public Function getInterconsultas(ByVal objConexion As Conexion, ByRef lError As Long, ByVal pProcedimientoOM As ProcedimientoOM) As List(Of ProcedimientoOM)
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim Param() As Object

            ReDim Param(6)
            Param(0) = pProcedimientoOM.COD_PRE_SGS
            Param(1) = pProcedimientoOM.cod_sucur
            Param(2) = pProcedimientoOM.tip_admision
            Param(3) = pProcedimientoOM.ANO_ADM
            Param(4) = pProcedimientoOM.NUM_ADM
            Param(5) = pProcedimientoOM.ESPECIALIDAD
            Param(6) = pProcedimientoOM.LOGIN

            Return obj.ConvertDataTableToList(Of ProcedimientoOM)(obj.EjecutarSPConParametros("HC_EV_GET_INTERCONSULTAS", objConexion, lError, Param))
        End Function

        Public Function getProcedimientoOM(ByVal objConexion As Conexion, ByRef lError As Long, ByVal pProcedimientoOM As ProcedimientoOM) As List(Of ProcedimientoOM)
            'Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            'Dim Param() As Object

            'ReDim Param(5)
            'Param(0) = pProcedimientoOM.cod_pre_sgs
            'Param(1) = pProcedimientoOM.cod_sucur
            'Param(2) = pProcedimientoOM.tip_admision
            'Param(3) = pProcedimientoOM.ano_adm
            'Param(4) = pProcedimientoOM.num_adm
            'Param(5) = pProcedimientoOM.CLASE_DIAG

            'Return obj.ConvertDataTableToList(Of ProcedimientoOM)(obj.EjecutarSPConParametros("HC_EV_GET_ProcedimientoOMS", objConexion, lError, Param))
        End Function
        Public Function addProcedimientoOM(ByVal objConexion As Conexion, ByRef lError As Long, ByVal pProcedimientoOM As ProcedimientoOM) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim Param() As Object


            ReDim Param(28)
            Param(0) = COD_PRE_SGS
            Param(1) = COD_SUCUR
            Param(2) = TIP_ADMISION
            Param(3) = NUM_ADM
            Param(4) = ANO_ADM
            Param(5) = NROORDEN
            Param(6) = PROCEDIMIENTO
            Param(7) = CANTIDAD
            Param(8) = MEDICO
            Param(9) = ESPECIALIDAD
            Param(10) = CEN_COSTO_ORIGEN
            Param(11) = CEN_COSTO
            Param(12) = NROPEDIDO
            Param(13) = FEC_CON
            Param(14) = LOGIN
            Param(15) = OBS
            Param(16) = TIPSERV
            Param(17) = PRIORI
            Param(18) = GUIA
            Param(19) = JUSTIFICACION
            Param(20) = ESTADOPLANEA
            Param(21) = JUSTIFICACION_EXCEP
            Param(22) = ENTIDAD
            Param(23) = CODIGO_RIS
            Param(24) = CODIGOLABORATORIO
            Param(25) = AUTOSISPRO
            Param(26) = IDESTADOINTERCONSULTA
            Param(27) = lError

            Return lError = obj.EjecutarSPConParametrosTran("HC_ADD_ORDENPROCEDIMIENTO", objConexion, Param)

        End Function

        Public Function delProcedimientoOM(ByVal objconexion As Conexion, ByRef lError As Long, ByVal oProcedimientoOM As ProcedimientoOM) As Long

            'Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            'Dim Param() As Object

            'ReDim Param(6)

            'Param(0) = oProcedimientoOM.COD_PRE_SGS
            'Param(1) = oProcedimientoOM.COD_SUCUR
            'Param(2) = oProcedimientoOM.TIP_ADMISION
            'Param(3) = oProcedimientoOM.NUM_ADM
            'Param(4) = oProcedimientoOM.ANO_ADM
            'Param(5) = oProcedimientoOM.DIAGNOST
            'Param(6) = lError

            'Return lError = obj.EjecutarSPConParametrosTran("HC_DEL_ProcedimientoOM", objconexion, Param)

        End Function

#End Region
    End Class

End Namespace