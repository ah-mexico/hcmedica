Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports System.Xml.Serialization
Imports System.Collections.Generic
Imports System.IO
Imports System.Xml
Imports System.Text.RegularExpressions

Namespace Sophia.HistoriaClinica.BL
    ''' <summary>
    ''' Delegado para actualizar datos de procedimiento.
    ''' </summary>
    ''' <param name="strDescripcionTotal">Descripción total del procedimiento</param>
    ''' <param name="iCantidad">Cantidad total del procedimiento.</param>
    ''' <param name="strXmlParticularidades">XML de particularides</param>
    ''' <param name="strXmlProcedimientos">XML de procedimentos</param>
    Public Delegate Sub ActDatosParticularidades(ByVal strDescripcionTotal As String, ByVal iCantidad As Integer, ByVal strXmlParticularidades As String, ByVal strXmlProcedimientos As String)

    ''' <summary>
    ''' BL Particularidades procedimiento.
    ''' Autor: Joseph Moreno (IG)
    ''' </summary>
    Public Module BLParticularidadesProc
        ''' <summary>
        ''' Consulta en base de datos las particularidades asociadas al procedimiento
        ''' </summary>
        ''' <param name="objConexion">Objeto de conexion</param>
        ''' <param name="Datos">Parámetros del SP</param>
        ''' <returns></returns>
        Public Function TraerParticularidades(ByVal objConexion As objCon, ByVal ParamArray Datos() As Object) As DataTable
            Dim objDAOGeneral As New DAO.DAOGeneral
            Dim data As DataSet = objDAOGeneral.EjecutarSPConParametrosDataSet("HC_TraerPartProc", objConexion, -1, Datos)
            If Not IsNothing(data) Then
                Return data.Tables(0)
            End If
            Return Nothing
        End Function

        ''' <summary>
        ''' Deserializa XML segun la definición de Sophia basado en atributos (/Raiz/Row)
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="strXml"></param>
        ''' <param name="root"></param>
        ''' <returns></returns>
        Public Function DeserializeXml(Of T)(ByVal strXml As String, Optional ByVal root As XmlRootAttribute = Nothing) As T
            Dim ser As XmlSerializer = IIf(IsNothing(root), New XmlSerializer(GetType(T)), New XmlSerializer(GetType(T), root))
            Using sr As StringReader = New StringReader(strXml)
                Return ser.Deserialize(sr)
            End Using
        End Function

        ''' <summary>
        ''' Serializa objeto en XML segun la definición de Sophia basado en atributos (/Raiz/Row)
        ''' </summary>
        ''' <typeparam name="T"></typeparam>
        ''' <param name="ObjectToSerialize"></param>
        ''' <returns></returns>
        Public Function Serialize(Of T)(ByVal ObjectToSerialize As T) As String
            Dim xmlSerializer As XmlSerializer = New XmlSerializer(ObjectToSerialize.[GetType]())
            Dim strXml As String
            Dim xmlObj As XmlDocument = New XmlDocument()
            Dim element As XmlElement = Nothing

            Using textWriter As StringWriter = New StringWriter()
                Using xmlWriter As XmlWriter = XmlWriter.Create(textWriter, New XmlWriterSettings With {.OmitXmlDeclaration = True})
                    xmlSerializer.Serialize(xmlWriter, ObjectToSerialize)
                    strXml = textWriter.ToString()
                    strXml = Regex.Replace(strXml, "\sxmlns:xsd=""http(.+)XMLSchema(-instance){0,1}""", "")
                End Using
            End Using

            Return strXml
        End Function
    End Module

    ''' <summary>
    ''' Entidad equivalente al Grupo de particularidades
    ''' </summary>
    <Serializable>
    Public Class GrupoParticularidadProc
        <XmlAttribute>
        Public Id As Integer
        <XmlAttribute>
        Public Descripcion As String
        <XmlAttribute>
        Public Activo As Boolean
        <XmlAttribute>
        Public Tipo As String
        <XmlArray("Particularidades")>
        <XmlArrayItem("Particularidad")>
        Public Particularidades As List(Of Integer)
        <XmlIgnore>
        Public Property Control As GroupBox
            Get
                Return groupBox
            End Get
            Set(value As GroupBox)
                groupBox = value
            End Set
        End Property
        <XmlIgnore>
        Private groupBox As GroupBox = Nothing
    End Class

    ''' <summary>
    ''' Entidad equivalente a la Particularidad
    ''' </summary>
    <Serializable>
    Public Class ParticularidadProc
        <XmlAttribute>
        Public Id As Integer
        <XmlAttribute>
        Public Descripcion As String
        <XmlAttribute>
        Public Activo As Boolean
        <XmlAttribute>
        Public Tipo As String
        <XmlAttribute>
        Public Cantidad As Integer
        <XmlAttribute>
        Public Procedimiento As String
    End Class

    ''' <summary>
    ''' Entidad par grupo-particularidad
    ''' </summary>
    <Serializable>
    Public Structure Grupo_Particularidad
        Implements IComparable(Of Grupo_Particularidad), IEquatable(Of Grupo_Particularidad)
        <XmlAttribute>
        Public Grupo As Integer
        <XmlAttribute>
        Public Particularidad As Integer

        Public Sub New(ByVal grp As Integer, ByVal part As Integer)
            Grupo = grp
            Particularidad = part
        End Sub

        ''' <summary>
        ''' Compara la instancia con otro par grupo-particularidad
        ''' </summary>
        ''' <param name="other"></param>
        ''' <returns></returns>
        Public Function CompareTo(other As Grupo_Particularidad) As Integer Implements IComparable(Of Grupo_Particularidad).CompareTo
            If Grupo > other.Grupo Then
                Return +1
            ElseIf Grupo = other.Grupo Then
                If Particularidad > other.Particularidad Then
                    Return +1
                ElseIf Particularidad = other.Particularidad Then
                    Return 0
                Else
                    Return -1
                End If
            Else
                Return -1
            End If
        End Function

        ''' <summary>
        ''' Determina igualdad de la instancia con otro par grupo-particularidad
        ''' </summary>
        ''' <param name="other"></param>
        ''' <returns></returns>
        Public Overloads Function Equals(other As Grupo_Particularidad) As Boolean Implements IEquatable(Of Grupo_Particularidad).Equals
            Return CompareTo(CType(other, Grupo_Particularidad)) = 0
        End Function
    End Structure

    ''' <summary>
    ''' Entidad de procedimientos asociados a procedimiento por particularidades
    ''' </summary>
    <Serializable>
    Public Class Procedimiento_Particularidad
        Implements IComparable(Of Procedimiento_Particularidad)
        <XmlAttribute>
        Public Codigo As String
        <XmlAttribute>
        Public Cantidad As Integer

        Public Sub New()
            Codigo = ""
            Cantidad = 0
        End Sub

        Public Sub New(ByRef strCodigo As String)
            Codigo = strCodigo
            Cantidad = 0
        End Sub

        ''' <summary>
        ''' Aumenta la cantidad del procedimiento indicado en 1
        ''' </summary>
        Public Sub AumentarCantidad()
            Cantidad = +1
        End Sub

        ''' <summary>
        ''' Reduce la cantidad del procedimiento indicado en 0
        ''' </summary>
        Public Sub ReducirCantidad()
            Cantidad = -1
        End Sub

        Public Function CompareTo(other As Procedimiento_Particularidad) As Integer Implements IComparable(Of Procedimiento_Particularidad).CompareTo
            If Codigo > other.Codigo Then
                Return +1
            ElseIf Codigo = other.Codigo Then
                Return 0
            Else
                Return -1
            End If
        End Function
    End Class

    ''' <summary>
    ''' Contenedor de objetos serializables segun la definición de Sophia (/Raiz/Row)
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    <Serializable>
    <XmlRoot("Raiz")>
    Public Class ListadoSophiaDB(Of T)
        <XmlElement("Row")>
        Public Filas As HashSet(Of T)
    End Class
End Namespace

