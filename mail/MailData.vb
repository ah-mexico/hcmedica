
Imports System.Net.Mail
Imports System.Collections.Generic

Namespace Mail
    Public Class MailData

        Private mailFrom As MailAddress = Nothing
        Private mailTo As New List(Of MailAddress)

        Private mailSubject As String = Nothing
        Private mailBody As String = Nothing
        Private mailCC As New List(Of MailAddress)
        Private mailBCC As New List(Of MailAddress)
        Private mailPriority As MailPriority = mailPriority.Normal
        Private mailAttachments As New List(Of Attachment)
        Private bodyHtml As Boolean

        ''' <summary>
        ''' Determina la direccion de remitente para el correo
        ''' </summary>
        ''' <value>Direccion de correo valida con formato xxxxx@xxxxx.xxx</value>
        ''' <returns>Direccion del remitente</returns>
        ''' <remarks></remarks>
        Public Property from() As MailAddress
            Get
                Return Me.mailFrom
            End Get
            Set(ByVal fromEmail As MailAddress)
                Me.mailFrom = fromEmail
            End Set
        End Property

        ''' <summary>
        ''' Determina las direcciones de destino para el correo
        ''' </summary>
        ''' <returns>Lista de direcciones de destino</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property toMail() As List(Of MailAddress)
            Get
                Return Me.mailTo
            End Get
        End Property

        ''' <summary>
        ''' Cuerpo o contenido del correo
        ''' </summary>
        ''' <value>Cadena de texto que determina el contenido del correo</value>
        ''' <returns>Cadena de texto que determina el contenido del correo</returns>
        ''' <remarks></remarks>
        Public Property body() As String
            Get
                Return Me.mailBody
            End Get
            Set(ByVal mailBody As String)
                Me.mailBody = mailBody
            End Set
        End Property

        ''' <summary>
        ''' Determina el asunto con el que se envira el correo
        ''' </summary>
        ''' <value>Asunto del correo</value>
        ''' <returns>Asunto del correo</returns>
        ''' <remarks></remarks>
        Public Property subject() As String
            Get
                Return Me.mailSubject
            End Get
            Set(ByVal mailSubject As String)
                Me.mailSubject = mailSubject
            End Set
        End Property

        ''' <summary>
        ''' Determina a que direcciones de correo les sera reenviada una copia del correo
        ''' </summary>
        ''' <returns>Lista de direcciones</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property CC() As List(Of MailAddress)
            Get
                Return Me.mailCC
            End Get
        End Property

        ''' <summary>
        ''' Determina a que direcciones de correo les sera reenviada una 
        ''' copia del correo, de forma oculta
        ''' </summary>
        ''' <returns>Lista de direcciones</returns>
        ''' <remarks></remarks>
        Public ReadOnly Property BCC() As List(Of MailAddress)
            Get
                Return Me.mailBCC
            End Get
        End Property

        ''' <summary>
        ''' Prioridad del correo
        ''' </summary>
        ''' <value>Prioridad del correo</value>
        ''' <returns>Prioridad del correo</returns>
        ''' <remarks></remarks>
        Public Property priority() As MailPriority
            Get
                Return Me.mailPriority
            End Get
            Set(ByVal mailPriority As MailPriority)
                Me.mailPriority = mailPriority
            End Set
        End Property

        ''' <summary>
        ''' Contiene una lista con los archivos y/u objetos attachados para ser 
        ''' enviados adjuntos al correo
        ''' </summary>
        ''' <value>Lista con los archivos y/u objetos que seran
        ''' enviados adjuntos al correo</value>
        ''' <remarks></remarks>
        Public ReadOnly Property attachmets() As List(Of Attachment)
            Get
                Return Me.mailAttachments
            End Get
        End Property

        ''' <summary>
        ''' Determina si el contenido del correo es de tipo HTML
        ''' </summary>
        ''' <value>True para enviar el contenido del mail con tipo HTML</value>
        ''' <remarks></remarks>
        Public Property isBodyHtml() As Boolean
            Get
                Return Me.bodyHtml
            End Get
            Set(ByVal bodyHtml As Boolean)
                Me.bodyHtml = bodyHtml
            End Set
        End Property

    End Class
End Namespace