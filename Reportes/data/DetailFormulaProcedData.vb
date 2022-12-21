
Namespace Sophia.HistoriaClinica.Reportes.Data

    Public Class DetailFormulaProcedData
        'codcups
        Private codCups As String = Nothing
        'cant
        Private cant As String = Nothing
        'des
        Private des As String = Nothing
        'Grupo
        Private _Grupo As String = Nothing

        Public Property codigoCups() As String
            Get
                Return codCups
            End Get
            Set(ByVal value As String)
                codCups = value
            End Set
        End Property

        Public Property cantidad() As String
            Get
                Return cant
            End Get
            Set(ByVal value As String)
                cant = value
            End Set
        End Property

        Public Property descripcion() As String
            Get
                Return des
            End Get
            Set(ByVal value As String)
                des = value
            End Set
        End Property

        Public Property Grupo() As String
            Get
                Return _Grupo
            End Get
            Set(ByVal value As String)
                _Grupo = value
            End Set
        End Property

    End Class
End Namespace
