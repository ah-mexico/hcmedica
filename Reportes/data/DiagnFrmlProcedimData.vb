Namespace Sophia.HistoriaClinica.Reportes.Data
    Public Class DiagnFrmlProcedimData

        ''' <summary>
        ''' Define el texto para el diagnostico principal
        ''' </summary>
        ''' <remarks></remarks>
        Public Const DIAG_PRINCIPAL As String = "Diagnóstico principal"

        ''' <summary>
        ''' Define el texto para los diagnosticos relacionados
        ''' </summary>
        ''' <remarks></remarks>
        Public Const DIAG_RELACIONADO As String = "Diagnóstico relacionado"

        Private defDiagnostico As String = Nothing
        'CodDiagn
        Private codigoDiagnostico As String = Nothing
        'DesDiagn
        Private desDiagnostico As String = Nothing
        'GrupoDiag
        Private _GrupoDiag As String = Nothing
        ''' <summary>
        ''' Descripcion del diagnostico
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property desDiagn() As String
            Get
                Return desDiagnostico
            End Get
            Set(ByVal value As String)
                desDiagnostico = value
            End Set
        End Property

        ''' <summary>
        ''' Codigo del diagnostico
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property codDiagnostico() As String
            Get
                Return codigoDiagnostico
            End Get
            Set(ByVal value As String)
                codigoDiagnostico = value
            End Set
        End Property

        ''' <summary>
        ''' Determina la definicion del diagnostico
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property definicion() As String
            Get
                Return defDiagnostico
            End Get
            Set(ByVal value As String)
                defDiagnostico = value
            End Set
        End Property

        Public Property GrupoDiag() As String
            Get
                Return _GrupoDiag
            End Get
            Set(ByVal value As String)
                _GrupoDiag = value
            End Set
        End Property
    End Class
End Namespace
