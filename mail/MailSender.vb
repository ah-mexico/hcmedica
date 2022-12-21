
Imports System.Net.Mail
Imports System.Net.Security
Imports System.Security.Cryptography.X509Certificates
Imports System.Net

Namespace Mail
    Public Class MailSender
        Private host As String = Nothing
        Private delivMethod As SmtpDeliveryMethod = SmtpDeliveryMethod.Network
        Private port As Integer

        ''' <summary>
        ''' Crea una instancia de la clase
        ''' </summary>
        ''' <param name="host">Nombre o direccion ip del host de correo</param>
        ''' <param name="port">Puerto</param>
        ''' <param name="delivMethod">Metodo de envio del correo</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal host As String, ByVal port As Integer, ByVal delivMethod As SmtpDeliveryMethod)
            Me.host = host
            Me.delivMethod = delivMethod
            ''si el puerto ingresado es 0 o menor se asigna uno por defecto
            If (port < 0) Then
                port = 25
            End If
            Me.port = port
        End Sub

        ''' <summary>
        ''' Envia un correo via smtp
        ''' </summary>
        ''' <param name="mail">Contenido o informacion del correo</param>
        ''' <remarks></remarks>
        Public Sub sendMail(ByVal mail As MailData)

            Dim mailMsg As New MailMessage()

            mailMsg.BodyEncoding = System.Text.Encoding.Default

            ''Insertar informacion para enviar el correo
            ''añadir direcciones de destino
            For Each dirMail As MailAddress In mail.toMail
                mailMsg.To.Add(dirMail)
            Next
            Try

          
                mailMsg.From = mail.from
                mailMsg.Subject = mail.subject
                mailMsg.Body = mail.body
                mailMsg.Priority = mail.priority
                mailMsg.IsBodyHtml = mail.isBodyHtml

                ''añadir direcciones de correo para enviar copias ocultas
                For Each dirMail As MailAddress In mail.BCC
                    mailMsg.Bcc.Add(dirMail)
                Next

                ''añadir direcciones de correo para enviar copias
                For Each dirMail As MailAddress In mail.CC
                    mailMsg.CC.Add(dirMail)
                Next

                ''añadir direcciones de correo para enviar copias
                For Each contentFile As Attachment In mail.attachmets
                    mailMsg.Attachments.Add(contentFile)
                Next

                ''Creando el cliente smtp
                Dim smtpMailClient As New SmtpClient

                smtpMailClient.Host = Me.host
                smtpMailClient.Port = Me.port
                smtpMailClient.DeliveryMethod = Me.delivMethod
                smtpMailClient.EnableSsl = True
                'smtpMailClient.EnableSsl = False


                ' larb inicio
                ''objSMTPUserInfo = New System.Net.NetworkCredential("User name", "Password","Domain");
                Dim objSMTPUserInfo As New System.Net.NetworkCredential("info-sophia@colsanitas.com", "info-sophia2013")
                smtpMailClient.Credentials = objSMTPUserInfo
                mail.from = New MailAddress("info-sophia@colsanitas.com")
                '' larb final
                ''Obtiene o establece la devolución de llamada para validar un certificado de servidor.
                Dim instance As New RemoteCertificateValidationCallback(AddressOf ValidarCertificado)
                ServicePointManager.ServerCertificateValidationCallback = New RemoteCertificateValidationCallback(AddressOf ValidarCertificado)


                ''Envia el correo
                smtpMailClient.Send(mailMsg)
                smtpMailClient = Nothing
                mailMsg = Nothing
            Catch ex As Exception
                MsgBox(ex.Message)
                'System.Net.Mail.SmtpFailedRecipientsException()
            End Try
            ''Destruccion de objetos
          

        End Sub

        Private Shared Function ValidarCertificado(ByVal sender As Object, ByVal certificate As X509Certificate, ByVal chain As X509Chain, ByVal sslPolicyErrors As System.Net.Security.SslPolicyErrors) As Boolean
            'bypass de la validación del certificado (aplicar aquí validación personalizada si fuera el caso)
            Return True
        End Function


        Public Function RemoteCertificateValidationCallback( _
        ByVal sender As Object, _
        ByVal certificate As X509Certificate, _
        ByVal chain As X509Chain, _
        ByVal sslPolicyErrors As Net.Security.SslPolicyErrors _
        ) As Boolean
            Return True
        End Function
    End Class
End Namespace