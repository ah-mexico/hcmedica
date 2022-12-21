﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.ComponentModel
Imports System.Diagnostics
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Xml.Serialization

'
'This source code was auto-generated by Microsoft.VSDesigner, Version 4.0.30319.42000.
'
Namespace wsResultadosLaboratorio
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Web.Services.WebServiceBindingAttribute(Name:="WebServiceSoap", [Namespace]:="http://consultaavicena")>  _
    Partial Public Class WebService
        Inherits System.Web.Services.Protocols.SoapHttpClientProtocol
        
        Private fncGetURLPDFOperationCompleted As System.Threading.SendOrPostCallback
        
        Private consultaValueField As Consulta
        
        Private fncGetSolicitudesByPacienteByFechasOperationCompleted As System.Threading.SendOrPostCallback
        
        Private useDefaultCredentialsSetExplicitly As Boolean
        
        '''<remarks/>
        Public Sub New()
            MyBase.New
            Me.Url = Global.HistoriaClinica.MySettings.Default.HistoriaClinica_wsResultadosLaboratorio_WebService
            If (Me.IsLocalFileSystemWebService(Me.Url) = true) Then
                Me.UseDefaultCredentials = true
                Me.useDefaultCredentialsSetExplicitly = false
            Else
                Me.useDefaultCredentialsSetExplicitly = true
            End If
        End Sub
        
        Public Property ConsultaValue() As Consulta
            Get
                Return Me.consultaValueField
            End Get
            Set
                Me.consultaValueField = value
            End Set
        End Property
        
        Public Shadows Property Url() As String
            Get
                Return MyBase.Url
            End Get
            Set
                If (((Me.IsLocalFileSystemWebService(MyBase.Url) = true)  _
                            AndAlso (Me.useDefaultCredentialsSetExplicitly = false))  _
                            AndAlso (Me.IsLocalFileSystemWebService(value) = false)) Then
                    MyBase.UseDefaultCredentials = false
                End If
                MyBase.Url = value
            End Set
        End Property
        
        Public Shadows Property UseDefaultCredentials() As Boolean
            Get
                Return MyBase.UseDefaultCredentials
            End Get
            Set
                MyBase.UseDefaultCredentials = value
                Me.useDefaultCredentialsSetExplicitly = true
            End Set
        End Property
        
        '''<remarks/>
        Public Event fncGetURLPDFCompleted As fncGetURLPDFCompletedEventHandler
        
        '''<remarks/>
        Public Event fncGetSolicitudesByPacienteByFechasCompleted As fncGetSolicitudesByPacienteByFechasCompletedEventHandler
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://consultaavicena/fncGetURLPDF", RequestNamespace:="http://consultaavicena", ResponseNamespace:="http://consultaavicena", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function fncGetURLPDF(ByVal FechaPeticion As String, ByVal NumeroPeticion As String, ByVal Modulo As String) As RutaPDF
            Dim results() As Object = Me.Invoke("fncGetURLPDF", New Object() {FechaPeticion, NumeroPeticion, Modulo})
            Return CType(results(0),RutaPDF)
        End Function
        
        '''<remarks/>
        Public Overloads Sub fncGetURLPDFAsync(ByVal FechaPeticion As String, ByVal NumeroPeticion As String, ByVal Modulo As String)
            Me.fncGetURLPDFAsync(FechaPeticion, NumeroPeticion, Modulo, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub fncGetURLPDFAsync(ByVal FechaPeticion As String, ByVal NumeroPeticion As String, ByVal Modulo As String, ByVal userState As Object)
            If (Me.fncGetURLPDFOperationCompleted Is Nothing) Then
                Me.fncGetURLPDFOperationCompleted = AddressOf Me.OnfncGetURLPDFOperationCompleted
            End If
            Me.InvokeAsync("fncGetURLPDF", New Object() {FechaPeticion, NumeroPeticion, Modulo}, Me.fncGetURLPDFOperationCompleted, userState)
        End Sub
        
        Private Sub OnfncGetURLPDFOperationCompleted(ByVal arg As Object)
            If (Not (Me.fncGetURLPDFCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent fncGetURLPDFCompleted(Me, New fncGetURLPDFCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        <System.Web.Services.Protocols.SoapHeaderAttribute("ConsultaValue"),  _
         System.Web.Services.Protocols.SoapDocumentMethodAttribute("http://consultaavicena/fncGetSolicitudesByPacienteByFechas", RequestNamespace:="http://consultaavicena", ResponseNamespace:="http://consultaavicena", Use:=System.Web.Services.Description.SoapBindingUse.Literal, ParameterStyle:=System.Web.Services.Protocols.SoapParameterStyle.Wrapped)>  _
        Public Function fncGetSolicitudesByPacienteByFechas(ByVal TipoIdentificacion As String, ByVal Identificacion As String, ByVal FechaInicial As String, ByVal FechaFinal As String) As Consulta()
            Dim results() As Object = Me.Invoke("fncGetSolicitudesByPacienteByFechas", New Object() {TipoIdentificacion, Identificacion, FechaInicial, FechaFinal})
            Return CType(results(0),Consulta())
        End Function
        
        '''<remarks/>
        Public Overloads Sub fncGetSolicitudesByPacienteByFechasAsync(ByVal TipoIdentificacion As String, ByVal Identificacion As String, ByVal FechaInicial As String, ByVal FechaFinal As String)
            Me.fncGetSolicitudesByPacienteByFechasAsync(TipoIdentificacion, Identificacion, FechaInicial, FechaFinal, Nothing)
        End Sub
        
        '''<remarks/>
        Public Overloads Sub fncGetSolicitudesByPacienteByFechasAsync(ByVal TipoIdentificacion As String, ByVal Identificacion As String, ByVal FechaInicial As String, ByVal FechaFinal As String, ByVal userState As Object)
            If (Me.fncGetSolicitudesByPacienteByFechasOperationCompleted Is Nothing) Then
                Me.fncGetSolicitudesByPacienteByFechasOperationCompleted = AddressOf Me.OnfncGetSolicitudesByPacienteByFechasOperationCompleted
            End If
            Me.InvokeAsync("fncGetSolicitudesByPacienteByFechas", New Object() {TipoIdentificacion, Identificacion, FechaInicial, FechaFinal}, Me.fncGetSolicitudesByPacienteByFechasOperationCompleted, userState)
        End Sub
        
        Private Sub OnfncGetSolicitudesByPacienteByFechasOperationCompleted(ByVal arg As Object)
            If (Not (Me.fncGetSolicitudesByPacienteByFechasCompletedEvent) Is Nothing) Then
                Dim invokeArgs As System.Web.Services.Protocols.InvokeCompletedEventArgs = CType(arg,System.Web.Services.Protocols.InvokeCompletedEventArgs)
                RaiseEvent fncGetSolicitudesByPacienteByFechasCompleted(Me, New fncGetSolicitudesByPacienteByFechasCompletedEventArgs(invokeArgs.Results, invokeArgs.Error, invokeArgs.Cancelled, invokeArgs.UserState))
            End If
        End Sub
        
        '''<remarks/>
        Public Shadows Sub CancelAsync(ByVal userState As Object)
            MyBase.CancelAsync(userState)
        End Sub
        
        Private Function IsLocalFileSystemWebService(ByVal url As String) As Boolean
            If ((url Is Nothing)  _
                        OrElse (url Is String.Empty)) Then
                Return false
            End If
            Dim wsUri As System.Uri = New System.Uri(url)
            If ((wsUri.Port >= 1024)  _
                        AndAlso (String.Compare(wsUri.Host, "localHost", System.StringComparison.OrdinalIgnoreCase) = 0)) Then
                Return true
            End If
            Return false
        End Function
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://consultaavicena"),  _
     System.Xml.Serialization.XmlRootAttribute([Namespace]:="http://consultaavicena", IsNullable:=false)>  _
    Partial Public Class Consulta
        Inherits System.Web.Services.Protocols.SoapHeader
        
        Private estadoFinalField As Short
        
        Private pacienteField As Paciente
        
        '''<remarks/>
        Public Property EstadoFinal() As Short
            Get
                Return Me.estadoFinalField
            End Get
            Set
                Me.estadoFinalField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Paciente() As Paciente
            Get
                Return Me.pacienteField
            End Get
            Set
                Me.pacienteField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://consultaavicena")>  _
    Partial Public Class Paciente
        
        Private tipoIdentificacionField As String
        
        Private numeroIdentificacionField As String
        
        Private nombrePacienteField As String
        
        Private peticionesField() As Peticion
        
        '''<remarks/>
        Public Property TipoIdentificacion() As String
            Get
                Return Me.tipoIdentificacionField
            End Get
            Set
                Me.tipoIdentificacionField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property NumeroIdentificacion() As String
            Get
                Return Me.numeroIdentificacionField
            End Get
            Set
                Me.numeroIdentificacionField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property NombrePaciente() As String
            Get
                Return Me.nombrePacienteField
            End Get
            Set
                Me.nombrePacienteField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Peticiones() As Peticion()
            Get
                Return Me.peticionesField
            End Get
            Set
                Me.peticionesField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://consultaavicena")>  _
    Partial Public Class Peticion
        
        Private numeroPeticionField As String
        
        Private fechaPeticionField As String
        
        Private estadoPeticionField As String
        
        Private moduloField As String
        
        Private descripcionField As String
        
        '''<remarks/>
        Public Property NumeroPeticion() As String
            Get
                Return Me.numeroPeticionField
            End Get
            Set
                Me.numeroPeticionField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property FechaPeticion() As String
            Get
                Return Me.fechaPeticionField
            End Get
            Set
                Me.fechaPeticionField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property EstadoPeticion() As String
            Get
                Return Me.estadoPeticionField
            End Get
            Set
                Me.estadoPeticionField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Modulo() As String
            Get
                Return Me.moduloField
            End Get
            Set
                Me.moduloField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property Descripcion() As String
            Get
                Return Me.descripcionField
            End Get
            Set
                Me.descripcionField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1055.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute([Namespace]:="http://consultaavicena")>  _
    Partial Public Class RutaPDF
        
        Private uRL_PDFField As String
        
        Private strErrorField As String
        
        '''<remarks/>
        Public Property URL_PDF() As String
            Get
                Return Me.uRL_PDFField
            End Get
            Set
                Me.uRL_PDFField = value
            End Set
        End Property
        
        '''<remarks/>
        Public Property strError() As String
            Get
                Return Me.strErrorField
            End Get
            Set
                Me.strErrorField = value
            End Set
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")>  _
    Public Delegate Sub fncGetURLPDFCompletedEventHandler(ByVal sender As Object, ByVal e As fncGetURLPDFCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class fncGetURLPDFCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As RutaPDF
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),RutaPDF)
            End Get
        End Property
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0")>  _
    Public Delegate Sub fncGetSolicitudesByPacienteByFechasCompletedEventHandler(ByVal sender As Object, ByVal e As fncGetSolicitudesByPacienteByFechasCompletedEventArgs)
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Web.Services", "4.6.1055.0"),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code")>  _
    Partial Public Class fncGetSolicitudesByPacienteByFechasCompletedEventArgs
        Inherits System.ComponentModel.AsyncCompletedEventArgs
        
        Private results() As Object
        
        Friend Sub New(ByVal results() As Object, ByVal exception As System.Exception, ByVal cancelled As Boolean, ByVal userState As Object)
            MyBase.New(exception, cancelled, userState)
            Me.results = results
        End Sub
        
        '''<remarks/>
        Public ReadOnly Property Result() As Consulta()
            Get
                Me.RaiseExceptionIfNecessary
                Return CType(Me.results(0),Consulta())
            End Get
        End Property
    End Class
End Namespace
