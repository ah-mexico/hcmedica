
Imports System.Collections.Generic

Namespace Sophia.HistoriaClinica.Reportes.Data
    Public Class FormulaProcedimData
        ''' <summary>
        ''' Determina la cantidad de registros de diagnosticos que se aceptan como maximo
        ''' </summary>
        ''' <remarks></remarks>
        Public Const CANT_MAX_DIAGNOSTICOS As Integer = 3

        ''' <summary>
        ''' Direccion de correo destinatario para el mail
        ''' </summary>
        ''' <remarks></remarks>
        Private emailSucur As String = Nothing

        'Fecha extraer la hora
        Private fechaFormula As Date = Nothing

        '?Información del prestador 
        'Sucursal
        Private sucursalFormula As String = Nothing
        'pagador
        Private pagadorFormula As String = Nothing
        'nit
        Private nitFormula As String = Nothing
        'CodigoRips
        Private codigoRipsFormula As String = Nothing
        'Dirección
        Private direccionFormula As String = Nothing
        'Telefono
        Private telefonoFormula As String = Nothing
        'DptoSucursal
        Private dptoSucursalFormula As String = Nothing
        'CodDepSucursal
        Private codDepSucursalFormula As String = Nothing
        'Codigo Admision
        Private CodadmisionFormula As String = Nothing
        'Ciudad
        Private ciudadFormula As String = Nothing
        'CodMunSucursal
        Private codMunSucursalFormula As String = Nothing

        '?Datos paciente
        'pri_ape
        Private primApeFormula As String = Nothing
        'seg_ape
        Private segApeFormula As String = Nothing
        'Pri_Nom
        Private priNomFormula As String = Nothing
        'seg_nom
        Private segNomFormula As String = Nothing
        'tip_doc
        Private tipDocFormula As String = Nothing
        'destipdoc
        Private numDocFormula As String = Nothing
        'fec_nac
        Private fecNacFormula As Date = Nothing
        'dirpaciente	
        Private dirPacienteFormula As String = Nothing
        'telpaciente
        Private telPacienteFormula As String = Nothing
        'coddep
        Private codDepFormula As String = Nothing
        'departamentopac
        Private departamentoPacFormula As String = Nothing
        'codmun
        Private codMunFormula As String = Nothing
        'municipiopac
        Private municipioPacFormula As String = Nothing
        'celucar
        Private celularFormula As String = Nothing
        'email
        Private eMailFormula As String = Nothing
        'Cobertura en Salud
        Private coberturaSaludFormula As String = Nothing
        'justificacion
        Private JustificacionFormula As String = Nothing
        'Guia
        Private GuiaFormula As String = Nothing
        'CausaExt
        Private causaExtFormula As String = Nothing
        '?Tipo de servicio solicitado
        Private tipServSolicitFormula As String = Nothing
        'Prioridad de la atención   -default no prioritaria
        Private prioridadAtencionFormula As String = Nothing
        'admision
        Private admisionFormula As String = Nothing
        'cama
        Private camaFormula As String = Nothing
        'cambio realizado por Ing. Ricardo Mauricio Zaldúa C.
        'Fecha 2009-01-28
        'se ingreso nuevas variables para el reporte 
        'Solicitado por Mauricio Forero
        'Codigo Entidad 
        Private CodInterno As String = Nothing
        'Nombre Medico
        Private MedicoFormula As String = Nothing
        'Cargo Medico 
        Private CargoMedFormula As String = Nothing
        'Codigo diagnostico principal
        Private codigoDiagnosticoPrin As String = Nothing
        'Descripcion diagnostico principal
        Private desDiagnosticoPrin As String = Nothing
        'Codigo diagnostico relacionado 1
        Private codigoDiagnosticoRela1 As String = Nothing
        'Descripcion diagnostico relacionado 1
        Private desDiagnosticoRela1 As String = Nothing
        'Codigo diagnostico relacionado 2
        Private codigoDiagnosticoRela2 As String = Nothing
        'Descripcion diagnostico relacionado 2
        Private desDiagnosticoRela2 As String = Nothing
        'detalle procedimientos
        Private detalleFormula As New List(Of DetailFormulaProcedData)
        'flag para identificar si se envia el reporte via mail
        Private tmpMailFormula As Integer

        Public WriteOnly Property fecha() As Date
            Set(ByVal value As Date)
                fechaFormula = value
            End Set
        End Property

        Public ReadOnly Property fechaRpt() As String
            Get
                Return fechaFormula.ToString("yyyy - MM - dd")
            End Get
        End Property

        Public ReadOnly Property horaRpt() As String
            Get
                Return fechaFormula.ToString("HH : mm")
            End Get
        End Property

        Public Property sucursal() As String
            Get
                Return sucursalFormula
            End Get
            Set(ByVal value As String)
                sucursalFormula = value
            End Set
        End Property

        Public Property nit() As String
            Get
                Return nitFormula
            End Get
            Set(ByVal value As String)
                nitFormula = value
            End Set
        End Property

        Public Property codigoRips() As String
            Get
                Return codigoRipsFormula
            End Get
            Set(ByVal value As String)
                codigoRipsFormula = value
            End Set
        End Property

        Public Property direccion() As String
            Get
                Return direccionFormula
            End Get
            Set(ByVal value As String)
                direccionFormula = value
            End Set
        End Property

        Public Property telefono() As String
            Get
                Return telefonoFormula
            End Get
            Set(ByVal value As String)
                telefonoFormula = value
            End Set
        End Property

        Public Property dptoSucursal() As String
            Get
                Return dptoSucursalFormula
            End Get
            Set(ByVal value As String)
                dptoSucursalFormula = value
            End Set
        End Property

        Public Property codDepSucursal() As String
            Get
                Return codDepSucursalFormula
            End Get
            Set(ByVal value As String)
                codDepSucursalFormula = value
            End Set
        End Property

        Public Property ciudad() As String
            Get
                Return ciudadFormula
            End Get
            Set(ByVal value As String)
                ciudadFormula = value
            End Set
        End Property

        Public Property codMunSucursal() As String
            Get
                Return codMunSucursalFormula
            End Get
            Set(ByVal value As String)
                codMunSucursalFormula = value
            End Set
        End Property

        Public Property primApe() As String
            Get
                Return primApeFormula
            End Get
            Set(ByVal value As String)
                primApeFormula = value
            End Set
        End Property

        Public Property segApe() As String
            Get
                Return segApeFormula
            End Get
            Set(ByVal value As String)
                segApeFormula = value
            End Set
        End Property

        Public Property priNom() As String
            Get
                Return priNomFormula
            End Get
            Set(ByVal value As String)
                priNomFormula = value
            End Set
        End Property

        Public Property segNom() As String
            Get
                Return segNomFormula
            End Get
            Set(ByVal value As String)
                segNomFormula = value
            End Set
        End Property

        Public Property tipDoc() As String
            Get
                Return tipDocFormula
            End Get
            Set(ByVal value As String)
                tipDocFormula = value
            End Set
        End Property

        Public Property numDoc() As String
            Get
                Return numDocFormula
            End Get
            Set(ByVal value As String)
                numDocFormula = value
            End Set
        End Property

        Public Property fecNac() As Date
            Get
                Return fecNacFormula
            End Get
            Set(ByVal value As Date)
                fecNacFormula = value
            End Set
        End Property

        Public ReadOnly Property fecNacimiento() As String
            Get
                Return fecNacFormula.ToString("yyyy - MM - dd")
            End Get
        End Property

        Public Property dirPaciente() As String
            Get
                Return dirPacienteFormula
            End Get
            Set(ByVal value As String)
                dirPacienteFormula = value
            End Set
        End Property

        Public Property telPaciente() As String
            Get
                Return telPacienteFormula
            End Get
            Set(ByVal value As String)
                telPacienteFormula = value
            End Set
        End Property

        Public Property codDep() As String
            Get
                Return codDepFormula
            End Get
            Set(ByVal value As String)
                codDepFormula = value
            End Set
        End Property

        Public Property departamentoPac() As String
            Get
                Return departamentoPacFormula
            End Get
            Set(ByVal value As String)
                departamentoPacFormula = value
            End Set
        End Property

        Public Property codMunPaciente() As String
            Get
                Return codMunFormula
            End Get
            Set(ByVal value As String)
                codMunFormula = value
            End Set
        End Property

        Public Property municipioPac() As String
            Get
                Return municipioPacFormula
            End Get
            Set(ByVal value As String)
                municipioPacFormula = value
            End Set
        End Property

        Public Property celular() As String
            Get
                Return celularFormula
            End Get
            Set(ByVal value As String)
                celularFormula = value
            End Set
        End Property

        Public Property eMail() As String
            Get
                Return eMailFormula
            End Get
            Set(ByVal value As String)
                eMailFormula = value
            End Set
        End Property

        Public Property causaExt() As String
            Get
                Return causaExtFormula
            End Get
            Set(ByVal value As String)
                causaExtFormula = value
            End Set
        End Property

        Public Property tipServSolicitado() As String
            Get
                Return tipServSolicitFormula
            End Get
            Set(ByVal value As String)
                tipServSolicitFormula = value
            End Set
        End Property

        Public Property admision() As String
            Get
                Return admisionFormula
            End Get
            Set(ByVal value As String)
                admisionFormula = value
            End Set
        End Property

        Public Property Codadmision() As String
            Get
                Return CodadmisionFormula
            End Get
            Set(ByVal value As String)
                CodadmisionFormula = value
            End Set
        End Property

        Public Property cama() As String
            Get
                Return camaFormula
            End Get
            Set(ByVal value As String)
                camaFormula = value
            End Set
        End Property

        Public Property coberturaSalud() As String
            Get
                Return coberturaSaludFormula
            End Get
            Set(ByVal value As String)
                coberturaSaludFormula = value
            End Set
        End Property

        Public Property prioridadAtencion() As String
            Get
                Return prioridadAtencionFormula
            End Get
            Set(ByVal value As String)
                prioridadAtencionFormula = value
            End Set
        End Property

        ''' <summary>
        ''' Direccion de correo destinatario para el mail
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property emailDestinatario() As String
            Get
                Return emailSucur
            End Get
            Set(ByVal value As String)
                emailSucur = value
            End Set
        End Property

        Public ReadOnly Property detalle() As List(Of DetailFormulaProcedData)
            Get
                Return detalleFormula
            End Get
        End Property

        Public Property pagador() As String
            Get
                Return pagadorFormula
            End Get
            Set(ByVal value As String)
                pagadorFormula = value
            End Set
        End Property

        Public Property justificacion_Salud() As String
            Get
                Return JustificacionFormula
            End Get
            Set(ByVal value As String)
                JustificacionFormula = value
            End Set
        End Property

        Public Property Guia_Salud() As String
            Get
                Return GuiaFormula
            End Get
            Set(ByVal value As String)
                GuiaFormula = value
            End Set
        End Property

        Public Property Medico() As String
            Get
                Return MedicoFormula
            End Get
            Set(ByVal value As String)
                MedicoFormula = value
            End Set
        End Property

        Public Property CodInt() As String
            Get
                Return CodInterno
            End Get
            Set(ByVal value As String)
                CodInterno = value
            End Set
        End Property

        Public Property CargoMed() As String
            Get
                Return CargoMedFormula
            End Get
            Set(ByVal value As String)
                CargoMedFormula = value
            End Set
        End Property

        Public Property codDiagnosticoPrin() As String
            Get
                Return codigoDiagnosticoPrin
            End Get
            Set(ByVal value As String)
                codigoDiagnosticoPrin = value
            End Set
        End Property

        Public Property desDiagnPrin() As String
            Get
                Return desDiagnosticoPrin
            End Get
            Set(ByVal value As String)
                desDiagnosticoPrin = value
            End Set
        End Property

        Public Property codDiagnosticoRela1() As String
            Get
                Return codigoDiagnosticoRela1
            End Get
            Set(ByVal value As String)
                codigoDiagnosticoRela1 = value
            End Set
        End Property

        Public Property desDiagnRela1() As String
            Get
                Return desDiagnosticoRela1
            End Get
            Set(ByVal value As String)
                desDiagnosticoRela1 = value
            End Set
        End Property

        Public Property codDiagnosticoRela2() As String
            Get
                Return codigoDiagnosticoRela2
            End Get
            Set(ByVal value As String)
                codigoDiagnosticoRela2 = value
            End Set
        End Property

        Public Property desDiagnRela2() As String
            Get
                Return desDiagnosticoRela2
            End Get
            Set(ByVal value As String)
                desDiagnosticoRela2 = value
            End Set
        End Property

        Public Property tmpMail() As Integer
            Get
                Return tmpMailFormula
            End Get
            Set(ByVal value As Integer)
                tmpMailFormula = value
            End Set
        End Property

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
    End Class
End Namespace

