
Namespace Sophia.HistoriaClinica.DatosConexion

    ''' -----------------------------------------------------------------------------
    ''' Project	 : HistoriaClinica.Conexion
    ''' Class	 : Sophia.HistoriaClinica.Conexion
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Clase Conexion del namespace Sophia.HistoriaClinica.Conexion que es la clase base
    ''' Esta clase se utiliza para almacenar la información para conectar a la BD
    ''' se utiliza en la aplicación Window 2005
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[mvargas]	06/05/2006 	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    ''' 
    Public Class Conexion
        Implements IDisposable

        Private _strServidor As String
        Private _strBaseDatos As String
        Private _strUsuarioBD As String
        Private _strClaveUsuarioBD As String
        Private Shared _Instancia As Conexion
        Private _blnEstadoInstancia As Boolean


        Public Sub New()

        End Sub

        Public Shared ReadOnly Property Instancia() As Conexion
            Get
                If _Instancia Is Nothing Then
                    _Instancia = New Conexion
                End If
                Return _Instancia
            End Get
        End Property


        Public Property EstadoInstancia() As Boolean
            Get
                Return _blnEstadoInstancia
            End Get
            Set(ByVal Value As Boolean)
                _blnEstadoInstancia = Value
            End Set
        End Property

        Public Property strServidor() As String
            Get
                Return _strServidor
            End Get
            Set(ByVal value As String)
                _strServidor = value
            End Set
        End Property

        Public Property strBaseDatos() As String
            Get
                Return _strBaseDatos
            End Get
            Set(ByVal value As String)
                _strBaseDatos = value
            End Set
        End Property

        Public Property strUsuarioBD() As String
            Get
                Return _strUsuarioBD
            End Get
            Set(ByVal value As String)
                _strUsuarioBD = value
            End Set
        End Property

        Public Property strClaveUsuarioBD() As String
            Get
                Return _strClaveUsuarioBD
            End Get
            Set(ByVal value As String)
                _strClaveUsuarioBD = value
            End Set
        End Property
        ''' <summary>
        ''' Retorna la cadena de coneccion.
        ''' </summary>
        ''' <returns>Cadena de conexion</returns>
        ''' <remarks>cavila@colsanitas.com 19/12/2007</remarks>
        Public Function getStringConnection() As String
            Dim strConnectionReturn As String = Nothing

            If ((Not Me.strBaseDatos Is Nothing) And (Not Me.strClaveUsuarioBD Is Nothing) And (Not Me.strServidor Is Nothing) And (Not Me.strUsuarioBD Is Nothing)) Then
                strConnectionReturn = "Data Source=" & Me.strServidor & " ;Initial Catalog=" & Me.strBaseDatos & ";User Id=" & Me.strUsuarioBD & ";Password=" & Me.strClaveUsuarioBD & ";"
            End If

            Return strConnectionReturn
        End Function


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

    End Class


End Namespace