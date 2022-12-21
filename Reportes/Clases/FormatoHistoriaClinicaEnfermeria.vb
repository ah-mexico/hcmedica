Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports System.Collections.Generic
Imports System.Data.Common
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente

Namespace Sophia.HistoriaClinica.Reportes
    Public Class FormatoHistoriaClinicaEnfermeria
        Inherits GPMDataReport

        Private _encabezado As HCEncabezado
        Private _motivoConsulta As MotivoConsulta
        Private _revisionSistemasEA As List(Of Revision)
        Private _antecedentesPerinatales As List(Of Perinatales)
        Private _desarrolloPsicomotor As List(Of DesarrolloPsicoMotor)
        Private _antecedentesPalotogicos As List(Of Patologico)
        Private _antecedentesGinecologicos As List(Of Ginecologico)
        Private _antecedentesQuirurgicos As List(Of Quirurgico)
        Private _antecedentesFarmacologicos As List(Of Farmacologico)
        Private _antecedentesAlergicos As List(Of Alergico)
        Private _antecedentesInmunologicos As List(Of Inmunologico)
        Private _antecedentesToxicos As List(Of Toxico)
        Private _antecedentesFamiliares As List(Of Familiares)
        Private _otrosAntecedentes As List(Of Antecedente)
        Private _examenFisico As ExamenFisico
        Private _diagnosticos As List(Of Diagnostico)
        Private _evoluciones As List(Of Evolucion)
        Private _medicamentos As List(Of Medicamento)
        Private _procedimientos As List(Of Procedimiento)
        Private _egresos As List(Of Admision)
        Private _diagnosticosEgreso As List(Of Diagnostico)
        Private _notas As List(Of Nota)
        Private _revisionSistemas As List(Of Revision)
        Private _medicoIngreso As HCEncabezado
        Private _resumenEvolucion As ResumenEvolucion
        Private _encabezadoOrdenes As List(Of Orden)
        Private _detalleOrdenesAislamientos As List(Of Aislamiento)
        Private _detalleOrdenesDietas As List(Of Dieta)
        Private _detalleOrdenesMedica As List(Of Medicamento)
        Private _detalleOrdenesProce As List(Of Procedimiento)
        Private _detalleOrdenesGen As List(Of OrdenGeneral)
        Private _remision As RemisionPlanManejo
        Private _recomendaciones As RecomendacionEgreso
        Private _triage As Triage
        Private _secciones As Secciones
        Private _ProcedimQxPracticados As List(Of Procedimiento)


#Region "Propiedades"
        Public Property Encabezado() As HCEncabezado
            Get
                Return _encabezado
            End Get
            Set(ByVal Value As HCEncabezado)
                _encabezado = Value
            End Set
        End Property
        Public Property MotivoConsulta() As MotivoConsulta
            Get
                Return _motivoConsulta
            End Get
            Set(ByVal Value As MotivoConsulta)
                _motivoConsulta = Value
            End Set
        End Property

        Public Property AntecedentesPerinatales() As List(Of Perinatales)
            Get
                Return _antecedentesPerinatales
            End Get
            Set(ByVal value As List(Of Perinatales))
                _antecedentesPerinatales = value
            End Set
        End Property

        Public Property AntecedentesDesarrolloPsicomotor() As List(Of DesarrolloPsicoMotor)
            Get
                Return _desarrolloPsicomotor
            End Get
            Set(ByVal value As List(Of DesarrolloPsicoMotor))
                _desarrolloPsicomotor = value
            End Set
        End Property
        Public Property AntecedentesPalotogicos() As List(Of Patologico)
            Get
                Return _antecedentesPalotogicos
            End Get
            Set(ByVal Value As List(Of Patologico))
                _antecedentesPalotogicos = Value
            End Set
        End Property
        Public Property AntecedentesGinecologicos() As List(Of Ginecologico)
            Get
                Return _antecedentesGinecologicos
            End Get
            Set(ByVal Value As List(Of Ginecologico))
                _antecedentesGinecologicos = Value
            End Set
        End Property
        Public Property AntecedentesQuirurgicos() As List(Of Quirurgico)
            Get
                Return _antecedentesQuirurgicos
            End Get
            Set(ByVal Value As List(Of Quirurgico))
                _antecedentesQuirurgicos = Value
            End Set
        End Property
        Public Property AntecedentesFarmacologicos() As List(Of Farmacologico)
            Get
                Return _antecedentesFarmacologicos
            End Get
            Set(ByVal Value As List(Of Farmacologico))
                _antecedentesFarmacologicos = Value
            End Set
        End Property

        Public Property AntecedentesAlergicos() As List(Of Alergico)
            Get
                Return _antecedentesAlergicos
            End Get
            Set(ByVal Value As List(Of Alergico))
                _antecedentesAlergicos = Value
            End Set
        End Property

        Public Property AntecedentesInmunologicos() As List(Of Inmunologico)
            Get
                Return _antecedentesInmunologicos
            End Get
            Set(ByVal Value As List(Of Inmunologico))
                _antecedentesInmunologicos = Value
            End Set
        End Property
        Public Property AntecedentesToxicos() As List(Of Toxico)
            Get
                Return _antecedentesToxicos
            End Get
            Set(ByVal Value As List(Of Toxico))
                _antecedentesToxicos = Value
            End Set
        End Property

        Public Property AntecedentesFamiliares() As List(Of Familiares)
            Get
                Return _antecedentesFamiliares
            End Get
            Set(ByVal Value As List(Of Familiares))
                _antecedentesFamiliares = Value
            End Set
        End Property
        Public Property OtrosAntecedentes() As List(Of Antecedente)
            Get
                Return _otrosAntecedentes
            End Get
            Set(ByVal Value As List(Of Antecedente))
                _otrosAntecedentes = Value
            End Set
        End Property
        Public Property ExamenFisico() As ExamenFisico
            Get
                Return _examenFisico
            End Get
            Set(ByVal Value As ExamenFisico)
                _examenFisico = Value
            End Set
        End Property

        Public Property Diagnosticos() As List(Of Diagnostico)
            Get
                Return _diagnosticos
            End Get
            Set(ByVal Value As List(Of Diagnostico))
                _diagnosticos = Value
            End Set
        End Property

        Public Property Evoluciones() As List(Of Evolucion)
            Get
                Return _evoluciones
            End Get
            Set(ByVal Value As List(Of Evolucion))
                _evoluciones = Value
            End Set
        End Property

        Public Property Medicamentos() As List(Of Medicamento)
            Get
                Return _medicamentos
            End Get
            Set(ByVal Value As List(Of Medicamento))
                _medicamentos = Value
            End Set
        End Property
        Public Property Procedimientos() As List(Of Procedimiento)
            Get
                Return _procedimientos
            End Get
            Set(ByVal Value As List(Of Procedimiento))
                _procedimientos = Value
            End Set
        End Property
        Public Property Egresos() As List(Of Admision)
            Get
                Return _egresos
            End Get
            Set(ByVal Value As List(Of Admision))
                _egresos = Value
            End Set
        End Property
        Public Property DiagnosticosEgreso() As List(Of Diagnostico)
            Get
                Return _diagnosticosEgreso
            End Get
            Set(ByVal Value As List(Of Diagnostico))
                _diagnosticosEgreso = Value
            End Set
        End Property
        Public Property Notas() As List(Of Nota)
            Get
                Return _notas
            End Get
            Set(ByVal Value As List(Of Nota))
                _notas = Value
            End Set
        End Property
        Public Property RevisionSistemas() As List(Of Revision)
            Get
                Return _revisionSistemas
            End Get
            Set(ByVal Value As List(Of Revision))
                _revisionSistemas = Value
            End Set
        End Property
        Public Property MedicoIngreso() As HCEncabezado
            Get
                Return _medicoIngreso
            End Get
            Set(ByVal Value As HCEncabezado)
                _medicoIngreso = Value
            End Set
        End Property
        Public Property ResumenEvolucion() As ResumenEvolucion
            Get
                Return _resumenEvolucion
            End Get
            Set(ByVal Value As ResumenEvolucion)
                _resumenEvolucion = Value
            End Set
        End Property
        Public Property RevisionSistemasEA() As List(Of Revision)
            Get
                Return _revisionSistemasEA
            End Get
            Set(ByVal Value As List(Of Revision))
                _revisionSistemasEA = Value
            End Set
        End Property

        Public Property EncabezadoOrdenes() As List(Of Orden)
            Get
                Return _encabezadoOrdenes
            End Get
            Set(ByVal value As List(Of Orden))
                _encabezadoOrdenes = value
            End Set
        End Property
        Public Property DetalleOrdenesDietas() As List(Of Dieta)
            Get
                Return _detalleOrdenesDietas
            End Get
            Set(ByVal Value As List(Of Dieta))
                _detalleOrdenesDietas = Value
            End Set
        End Property
        Public Property DetalleOrdenesMedica() As List(Of Medicamento)
            Get
                Return _detalleOrdenesMedica
            End Get
            Set(ByVal Value As List(Of Medicamento))
                _detalleOrdenesMedica = Value
            End Set
        End Property
        Public Property DetalleOrdenesProce() As List(Of Procedimiento)
            Get
                Return _detalleOrdenesProce
            End Get
            Set(ByVal Value As List(Of Procedimiento))
                _detalleOrdenesProce = Value
            End Set
        End Property
        Public Property DetalleOrdenesGenerales() As List(Of OrdenGeneral)
            Get
                Return _detalleOrdenesGen
            End Get
            Set(ByVal Value As List(Of OrdenGeneral))
                _detalleOrdenesGen = Value
            End Set
        End Property

        Public Property Remision() As RemisionPlanManejo
            Get
                Return _remision
            End Get
            Set(ByVal value As RemisionPlanManejo)
                _remision = value
            End Set
        End Property

        Public Property Recomendaciones() As RecomendacionEgreso
            Get
                Return _recomendaciones
            End Get
            Set(ByVal value As RecomendacionEgreso)
                _recomendaciones = value
            End Set
        End Property

        Public Property Triage() As Triage
            Get
                Return _triage
            End Get
            Set(ByVal value As Triage)
                _triage = value
            End Set
        End Property

        Public Property SeccionesHC() As Secciones
            Get
                Return _secciones
            End Get
            Set(ByVal value As Secciones)
                _secciones = value
            End Set
        End Property
        Public Property ProcedimQxPracticados() As List(Of Procedimiento)
            Get
                Return _ProcedimQxPracticados
            End Get
            Set(ByVal Value As List(Of Procedimiento))
                _ProcedimQxPracticados = Value
            End Set
        End Property

#End Region

        Public Sub New()
            _encabezado = New HCEncabezado()
            _motivoConsulta = New MotivoConsulta()
            _revisionSistemasEA = New List(Of Revision)
            _antecedentesPerinatales = New List(Of Perinatales)
            _desarrolloPsicomotor = New List(Of DesarrolloPsicoMotor)
            _antecedentesPalotogicos = New List(Of Patologico)
            _antecedentesGinecologicos = New List(Of Ginecologico)
            _antecedentesQuirurgicos = New List(Of Quirurgico)
            _antecedentesFarmacologicos = New List(Of Farmacologico)
            _antecedentesAlergicos = New List(Of Alergico)
            _antecedentesInmunologicos = New List(Of Inmunologico)
            _antecedentesToxicos = New List(Of Toxico)
            _antecedentesFamiliares = New List(Of Familiares)
            _otrosAntecedentes = New List(Of Antecedente)
            _examenFisico = New ExamenFisico()
            _diagnosticos = New List(Of Diagnostico)
            _evoluciones = New List(Of Evolucion)
            _medicamentos = New List(Of Medicamento)
            _procedimientos = New List(Of Procedimiento)
            _egresos = New List(Of Admision)
            _diagnosticosEgreso = New List(Of Diagnostico)
            _notas = New List(Of Nota)
            _revisionSistemas = New List(Of Revision)
            _medicoIngreso = New HCEncabezado
            _encabezadoOrdenes = New List(Of Orden)
            _detalleOrdenesDietas = New List(Of Dieta)
            _detalleOrdenesMedica = New List(Of Medicamento)
            _detalleOrdenesProce = New List(Of Procedimiento)
            _detalleOrdenesGen = New List(Of OrdenGeneral)
            _secciones = New Secciones()
            _ProcedimQxPracticados = New List(Of Procedimiento)
        End Sub

        Public Sub consultarHistoriaClinica(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
                                           ByVal strCod_sucur As String, ByVal strTip_admision As String,
                                           ByVal lano_adm As Long, ByVal dnum_adm As Double,
                                           ByVal strTipDoc As String, ByVal strNumDoc As String,
                                           ByVal strTip_historia As String, ByVal strLogin As String,
                                           ByVal secciones As Secciones)


            _encabezado.consultarHcEncabezado(objConexion, strcod_pre_sgs, strCod_sucur,
                                              strTip_admision, lano_adm, dnum_adm)

            _motivoConsulta.consultarMotivoConsulta(objConexion, strTipDoc, strNumDoc, strcod_pre_sgs, strCod_sucur,
                                                    strTip_admision, lano_adm, dnum_adm)
            _motivoConsulta.Visible = True

            _revisionSistemasEA = New Revision().consultarRevisionXSistemasEA(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                      lano_adm, dnum_adm)

            _desarrolloPsicomotor = New DesarrolloPsicoMotor().consultarDesarrolloPsicomotor(objConexion, strTipDoc, strNumDoc, strLogin, _encabezado.FechaConFormato)

            _antecedentesPerinatales = New Perinatales().consultarAntecedentesPerinatales(objConexion, strTipDoc, strNumDoc, strLogin, _encabezado.FechaConFormato, "", "", "")

            _antecedentesPalotogicos = New Patologico().consultarPatologias(objConexion, strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strLogin, _encabezado.FechaConFormato,
                                        strTip_admision, lano_adm, dnum_adm)

            _antecedentesGinecologicos = New Ginecologico().consultaAntGinecologicos(objConexion, strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strLogin, _encabezado.FechaConFormato, "", "", "")

            _antecedentesQuirurgicos = New Quirurgico().consultarAntQuirurgicos(objConexion, strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strLogin, _encabezado.FechaConFormato, "", "", "")

            _antecedentesFarmacologicos = New Farmacologico().consultarAntFarmacologicos(objConexion, strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strLogin, _encabezado.FechaConFormato, "", "", "")

            _antecedentesAlergicos = New Alergico().consultarAntAlergicos(objConexion, strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strLogin, _encabezado.FechaConFormato, "", "", "")

            _antecedentesInmunologicos = New Inmunologico().consultarAntInmunologico(objConexion, strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strLogin, _encabezado.FechaConFormato, "", "", "")

            _antecedentesToxicos = New Toxico().consultarAntToxicos(objConexion, strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strLogin, _encabezado.FechaConFormato, "", "", "")

            _antecedentesFamiliares = New Familiares().consultarAntFamiliares(objConexion, strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strLogin, _encabezado.FechaConFormato, "", "", "")

            _otrosAntecedentes = New Antecedente().consultarAntecedentes(objConexion, strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strLogin, _encabezado.FechaConFormato, "", "", "")

            _examenFisico.consultarExamenFisico(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                      lano_adm, dnum_adm, strLogin)
            _examenFisico.IsVisible = True

            _revisionSistemas = New Revision().consultarRevision(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                      lano_adm, dnum_adm)

            _diagnosticos = New Diagnostico().consultaDiagnosticos(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                      lano_adm, dnum_adm, strLogin, "I")

            _evoluciones = New Evolucion().consultarEvolucion(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                      lano_adm, dnum_adm, "", -1, -1, strLogin)

            _medicamentos = New Medicamento().consultarMedicamentos(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                      lano_adm, dnum_adm)

            _procedimientos = New Procedimiento().consultarProcedimientos(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                      lano_adm, dnum_adm)

            _egresos = New Admision().consultarEgresos(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                      lano_adm, dnum_adm)
            _diagnosticosEgreso = New Diagnostico().consultaDiagnosticos(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                      lano_adm, dnum_adm, strLogin, "E")

            _notas = New Nota().consultarNotas(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                         lano_adm, dnum_adm)

            _medicoIngreso = New HCEncabezado()
            _medicoIngreso.consultarHcEncabezado(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                         lano_adm, dnum_adm)

            Me._encabezadoOrdenes = New Orden().ConsultarOrdenesMedicas(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                         lano_adm, dnum_adm, _detalleOrdenesAislamientos, _detalleOrdenesDietas, _detalleOrdenesMedica, _detalleOrdenesProce,
                                         _detalleOrdenesGen)


            consultarSeccionesAdicionales(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                          lano_adm, dnum_adm, strTipDoc, strNumDoc, strTip_historia,
                                          strLogin, _encabezado.Paciente.Edad, secciones)
        End Sub

        'Ingresado por Claudia Garay para consultar la historia clinica sin los antecedentes
        '24 julio 2009

        Public Sub consultarHistoriaClinicaSinAntecedentes(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
                                           ByVal strCod_sucur As String, ByVal strTip_admision As String,
                                           ByVal lano_adm As Long, ByVal dnum_adm As Double,
                                           ByVal strTipDoc As String, ByVal strNumDoc As String,
                                           ByVal strTip_historia As String, ByVal strLogin As String,
                                           ByVal secciones As Secciones)


            _encabezado.consultarHcEncabezado(objConexion, strcod_pre_sgs, strCod_sucur,
                                             strTip_admision, lano_adm, dnum_adm)

            _motivoConsulta.consultarMotivoConsulta(objConexion, strTipDoc, strNumDoc, strcod_pre_sgs, strCod_sucur,
                                                    strTip_admision, lano_adm, dnum_adm)
            _motivoConsulta.Visible = True

            _revisionSistemasEA = New Revision().consultarRevisionXSistemasEA(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                      lano_adm, dnum_adm)

            _desarrolloPsicomotor = New DesarrolloPsicoMotor().consultarDesarrolloPsicomotor(objConexion, strTipDoc, strNumDoc, strLogin, _encabezado.FechaConFormato)

            _antecedentesPerinatales = New Perinatales().consultarAntecedentesPerinatales(objConexion, strTipDoc, strNumDoc, strLogin, _encabezado.FechaConFormato, strTip_admision, lano_adm, dnum_adm)

            _antecedentesPalotogicos = New Patologico().consultarPatologias(objConexion, strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strLogin, _encabezado.FechaConFormato,
                                        strTip_admision, lano_adm, dnum_adm)

            _antecedentesGinecologicos = New Ginecologico().consultaAntGinecologicos(objConexion, strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strLogin, _encabezado.FechaConFormato, strTip_admision, lano_adm, dnum_adm)

            _antecedentesQuirurgicos = New Quirurgico().consultarAntQuirurgicos(objConexion, strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strLogin, _encabezado.FechaConFormato, strTip_admision, lano_adm, dnum_adm)

            _antecedentesFarmacologicos = New Farmacologico().consultarAntFarmacologicos(objConexion, strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strLogin, _encabezado.FechaConFormato, strTip_admision, lano_adm, dnum_adm)

            _antecedentesAlergicos = New Alergico().consultarAntAlergicos(objConexion, strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strLogin, _encabezado.FechaConFormato, strTip_admision, lano_adm, dnum_adm)

            _antecedentesInmunologicos = New Inmunologico().consultarAntInmunologico(objConexion, strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strLogin, _encabezado.FechaConFormato, strTip_admision, lano_adm, dnum_adm)

            _antecedentesToxicos = New Toxico().consultarAntToxicos(objConexion, strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strLogin, _encabezado.FechaConFormato, strTip_admision, lano_adm, dnum_adm)

            _antecedentesFamiliares = New Familiares().consultarAntFamiliares(objConexion, strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strLogin, _encabezado.FechaConFormato, strTip_admision, lano_adm, dnum_adm)

            _otrosAntecedentes = New Antecedente().consultarAntecedentes(objConexion, strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strLogin, _encabezado.FechaConFormato, strTip_admision, lano_adm, dnum_adm)

            _examenFisico.consultarExamenFisico(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                      lano_adm, dnum_adm, strLogin)
            _examenFisico.IsVisible = True

            _revisionSistemas = New Revision().consultarRevision(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                      lano_adm, dnum_adm)

            _diagnosticos = New Diagnostico().consultaDiagnosticos(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                      lano_adm, dnum_adm, strLogin, "I")

            _evoluciones = New Evolucion().consultarEvolucion(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                      lano_adm, dnum_adm, "", -1, -1, strLogin)

            _medicamentos = New Medicamento().consultarMedicamentos(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                      lano_adm, dnum_adm)

            _procedimientos = New Procedimiento().consultarProcedimientos(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                      lano_adm, dnum_adm)

            _egresos = New Admision().consultarEgresos(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                      lano_adm, dnum_adm)
            _diagnosticosEgreso = New Diagnostico().consultaDiagnosticos(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                      lano_adm, dnum_adm, strLogin, "E")

            _notas = New Nota().consultarNotas(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                         lano_adm, dnum_adm)

            _medicoIngreso = New HCEncabezado()
            _medicoIngreso.consultarHcEncabezado(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                         lano_adm, dnum_adm)

            Me._encabezadoOrdenes = New Orden().ConsultarOrdenesMedicas(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                         lano_adm, dnum_adm, _detalleOrdenesAislamientos, _detalleOrdenesDietas, _detalleOrdenesMedica, _detalleOrdenesProce,
                                         _detalleOrdenesGen)


            consultarSeccionesAdicionales(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                          lano_adm, dnum_adm, strTipDoc, strNumDoc, strTip_historia,
                                          strLogin, _encabezado.Paciente.Edad, secciones)
        End Sub



        Public Sub consultarRevisionSistemasExamenFisicoCorregido(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
                                           ByVal strCod_sucur As String, ByVal strTip_admision As String,
                                           ByVal lano_adm As Long, ByVal dnum_adm As Double)


            _revisionSistemas = New Revision().consultarRevision(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                      lano_adm, dnum_adm)

        End Sub

        Public Sub consultarNotasExamenFisicoCorregido(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
                                                    ByVal strCod_sucur As String, ByVal strTip_Admision As String,
                                                    ByVal lano_adm As Long, ByVal dnum_adm As Double)
            _notas = Nota.consultarNotas(objConexion, strcod_pre_sgs, strCod_sucur, strTip_Admision, lano_adm, dnum_adm)
        End Sub


        Public Sub consultarResumenHistoriaClinica(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
                   ByVal strCod_sucur As String, ByVal strTip_admision As String,
                   ByVal lano_adm As Long, ByVal dnum_adm As Double)

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper
            Dim fecha As Date
            Dim dtHistoria As DataSet
            Dim dtEncabezado As DataTable
            Dim dtDiagnIngreso As DataTable
            Dim dtDiagnEgreso As DataTable
            Dim dtProcedimientos As DataTable
            Dim dtRevisionSistemaEA As DataTable
            Dim dtRevisionSistema As DataTable

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetStoredProcCommandWrapper("pa_Reportes_traerResumenEpicrisis")

            '' ''With command
            '' ''    .AddInParameter("strcod_pre_sgs", DbType.String, strcod_pre_sgs)
            '' ''    .AddInParameter("strCod_sucur", DbType.String, strCod_sucur)
            '' ''    .AddInParameter("strTip_admision", DbType.String, strTip_admision)
            '' ''    .AddInParameter("iano_adm", DbType.Int16, lano_adm)
            '' ''    .AddInParameter("lnum_adm", DbType.Double, dnum_adm)
            '' ''End With

            '' ''dtHistoria = db.ExecuteDataSet(command)


            gpmDataObj.setSQLSentence("pa_Reportes_traerResumenEpicrisis", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("strcod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            gpmDataObj.addInputParameter("strCod_sucur", SqlDbType.VarChar, strCod_sucur)
            gpmDataObj.addInputParameter("strTip_admision", SqlDbType.VarChar, strTip_admision)
            gpmDataObj.addInputParameter("iano_adm", SqlDbType.Int, lano_adm)
            gpmDataObj.addInputParameter("lnum_adm", SqlDbType.Decimal, dnum_adm)

            dtHistoria = gpmDataObj.execDS()

            ''Consulta "Encabezado"
            dtEncabezado = dtHistoria.Tables(0)
            ''Siguiente Consulta "Diagnosticos de Ingreso"
            dtDiagnIngreso = dtHistoria.Tables(1)
            ''Siguiente Consulta "Diagnosticos de Egreso"
            dtDiagnEgreso = dtHistoria.Tables(2)
            ''Siguiente Consulta "Procedimientos quirurgicos"
            dtProcedimientos = dtHistoria.Tables(3)
            'Cambio realizado Ricardo Mauricio Zaldúa C.
            'Fecha 21-11-2008
            'Motivo ingreso de nuevo datos al reporte 
            'Solicitado por Enrique Forero
            ''Siguiente Consulta "Revision Sistemas EA"
            dtRevisionSistemaEA = dtHistoria.Tables(4)
            ''Siguiente Consulta "Revision Sistema"
            dtRevisionSistema = dtHistoria.Tables(5)

            _motivoConsulta = New MotivoConsulta()
            _motivoConsulta.Inicializar(dtEncabezado.CreateDataReader)

            _examenFisico = New ExamenFisico()
            _examenFisico.inicializar(dtEncabezado.CreateDataReader)

            _resumenEvolucion = New ResumenEvolucion()
            _resumenEvolucion.inicializar(dtEncabezado.CreateDataReader)

            _egresos = New Admision().crearListaEgresos(dtEncabezado.CreateDataReader)

            _encabezado = New HCEncabezado()

            If dtEncabezado.Rows.Count > 0 Then
                With dtEncabezado.Rows(0)
                    _encabezado.inicializarHCEncabezado(objConexion, dtEncabezado.CreateDataReader)
                    _encabezado.buscarAdmision(objConexion, strTip_admision, .Item("cod_adm_des").ToString)
                    fecha = FuncionesGenerales.FechaServidor()
                    _encabezado.Fecha = Format(fecha, "dd/MM/yyyy")
                    _encabezado.Hora = Hour(fecha) & " : " & Minute(fecha)

                    If .Item("fec_ingreso").ToString.Trim.Length > 0 Then
                        fecha = .Item("fec_ingreso").ToString
                        _encabezado.fechaIngreso = Format(fecha, "dd/MM/yyyy")
                    Else
                        _encabezado.fechaIngreso = ""
                    End If
                    _encabezado.HoraIngreso = .Item("hor_ingreso").ToString & " : " & .Item("min_ingreso").ToString
                    If .Item("fec_egreso").ToString.Trim.Length > 0 Then
                        fecha = .Item("fec_egreso").ToString
                        _encabezado.FechaEgreso = Format(fecha, "dd/MM/yyyy")
                        _encabezado.Estancia = DateDiff(DateInterval.Day, .Item("fec_ingreso"), .Item("fec_egreso"))
                    Else
                        _encabezado.FechaEgreso = ""
                        _encabezado.Estancia = DateDiff(DateInterval.Day, .Item("fec_ingreso"), Date.Parse(_encabezado.Fecha))
                    End If
                    _encabezado.HoraEgreso = .Item("hora_egreso").ToString & " : " & .Item("min_egreso").ToString
                    _encabezado.MedicoTratante = .Item("medicoTratante").ToString
                    _encabezado.Cama = .Item("cama").ToString
                    _encabezado.Prestador = .Item("prestador").ToString
                    _examenFisico.Observaciones = .Item("TextoExamen").ToString
                End With
            End If

            If dtDiagnIngreso.Rows.Count > 0 Then
                _diagnosticos = New Diagnostico().crearListaDiagnosticos(dtDiagnIngreso, dtDiagnIngreso.Rows(0).Item("clase_diag").ToString)
            End If

            If dtDiagnEgreso.Rows.Count > 0 Then
                _diagnosticosEgreso = New Diagnostico().crearListaDiagnosticos(dtDiagnEgreso, dtDiagnEgreso.Rows(0).Item("clase_diag").ToString)
            End If
            'jlalfonso
            '2009-07-08
            'se instancia objeto diferente para procedimientosQX practicados ya que no existia
            'solicitado por eforero
            _ProcedimQxPracticados = New Procedimiento().crearListaProcedimQuirurgicos(dtProcedimientos.CreateDataReader)

            'Cambio realizado Ricardo Mauricio Zaldúa C.
            'Fecha 21-11-2008
            'Motivo ingreso de nuevo datos al reporte 
            'Solicitado por Enrique Forero
            If dtRevisionSistemaEA.Rows.Count > 0 Then
                _revisionSistemasEA = New Revision().crearListaRevisionSistema(dtRevisionSistemaEA)
            End If

            If dtRevisionSistema.Rows.Count > 0 Then
                _revisionSistemas = New Revision().crearListaRevisionSistema(dtRevisionSistema)
            End If
            'Cambio realizado por Ricardo Mauricio Zaldúa C.
            'Fecha 24-11-2008
            'Motivo ingreso de los subreportes al resumen de historia clinica egreso
            'Solicitado por Enrique Forero
            _antecedentesAlergicos = New Alergico().consultarAntAlergicos(objConexion, strcod_pre_sgs, strCod_sucur, frmConsultaHC.tbCodigoTipDoc.Text, frmConsultaHC.txtNumDoc.Text, DatosGenerales.Generales.Instancia.Login, _encabezado.FechaConFormato, strTip_admision, lano_adm, dnum_adm)
            _antecedentesFamiliares = New Familiares().consultarAntFamiliares(objConexion, strcod_pre_sgs, strCod_sucur, frmConsultaHC.tbCodigoTipDoc.Text, frmConsultaHC.txtNumDoc.Text, DatosGenerales.Generales.Instancia.Login, _encabezado.FechaConFormato, strTip_admision, lano_adm, dnum_adm)
            _antecedentesFarmacologicos = New Farmacologico().consultarAntFarmacologicos(objConexion, strcod_pre_sgs, strCod_sucur, frmConsultaHC.tbCodigoTipDoc.Text, frmConsultaHC.txtNumDoc.Text, DatosGenerales.Generales.Instancia.Login, _encabezado.FechaConFormato, strTip_admision, lano_adm, dnum_adm)
            _antecedentesGinecologicos = New Ginecologico().consultaAntGinecologicos(objConexion, strcod_pre_sgs, strCod_sucur, frmConsultaHC.tbCodigoTipDoc.Text, frmConsultaHC.txtNumDoc.Text, DatosGenerales.Generales.Instancia.Login, _encabezado.FechaConFormato, strTip_admision, lano_adm, dnum_adm)
            _antecedentesInmunologicos = New Inmunologico().consultarAntInmunologico(objConexion, strcod_pre_sgs, strCod_sucur, frmConsultaHC.tbCodigoTipDoc.Text, frmConsultaHC.txtNumDoc.Text, DatosGenerales.Generales.Instancia.Login, _encabezado.FechaConFormato, strTip_admision, lano_adm, dnum_adm)
            _otrosAntecedentes = New Antecedente().consultarAntecedentes(objConexion, strcod_pre_sgs, strCod_sucur, frmConsultaHC.tbCodigoTipDoc.Text, frmConsultaHC.txtNumDoc.Text, DatosGenerales.Generales.Instancia.Login, _encabezado.FechaConFormato, strTip_admision, lano_adm, dnum_adm)
            _antecedentesPalotogicos = New Patologico().consultarPatologias(objConexion, strcod_pre_sgs, strCod_sucur, frmConsultaHC.tbCodigoTipDoc.Text, frmConsultaHC.txtNumDoc.Text, DatosGenerales.Generales.Instancia.Login, _encabezado.FechaConFormato,
                            strTip_admision, lano_adm, dnum_adm)
            _antecedentesPerinatales = New Perinatales().consultarAntecedentesPerinatales(objConexion, frmConsultaHC.tbCodigoTipDoc.Text, frmConsultaHC.txtNumDoc.Text, DatosGenerales.Generales.Instancia.Login, _encabezado.FechaConFormato, strTip_admision, lano_adm, dnum_adm)
            _antecedentesQuirurgicos = New Quirurgico().consultarAntQuirurgicos(objConexion, strcod_pre_sgs, strCod_sucur, frmConsultaHC.tbCodigoTipDoc.Text, frmConsultaHC.txtNumDoc.Text, DatosGenerales.Generales.Instancia.Login, _encabezado.FechaConFormato, strTip_admision, lano_adm, dnum_adm)
            _antecedentesToxicos = New Toxico().consultarAntToxicos(objConexion, strcod_pre_sgs, strCod_sucur, frmConsultaHC.tbCodigoTipDoc.Text, frmConsultaHC.txtNumDoc.Text, DatosGenerales.Generales.Instancia.Login, _encabezado.FechaConFormato, strTip_admision, lano_adm, dnum_adm)


            'Me._encabezadoOrdenes = New Orden().ConsultarOrdenesMedicas(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision, _
            '                             lano_adm, dnum_adm, _detalleOrdenesDietas, _detalleOrdenesMedica, _detalleOrdenesProce, _
            '                             _detalleOrdenesGen)

            _medicamentos = New Medicamento().consultarMedicamentos(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                               lano_adm, dnum_adm)
            _procedimientos = New Procedimiento().consultarProcedimientos(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                      lano_adm, dnum_adm)


        End Sub

        'Public Shared Function traerHistoriasXPaciente(ByVal objConexion As Conexion, ByVal objPaciente As Paciente, ByVal fechaInicial As Date, _
        '                                               ByVal fechaFinal As Date) As DataTable
        '    '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
        '    '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
        '    '' ''Dim db As Database
        '    '' ''Dim command As DBCommandWrapper
        '    Dim dsHistorias As DataSet
        '    Dim dtResultado As New DataTable
        '    Dim strSQL As String = ""


        '    Select Case objPaciente.Unificado
        '        Case "U"
        '            If Not New Paciente().PacienteVacio(objPaciente.PacienteUnificador) Then
        '                strSQL = strSQL & formarSQLHistoriaClinica(objPaciente.PacienteUnificador, _
        '                                                           fechaInicial, fechaFinal)
        '            End If

        '            For Each unificado As Paciente In objPaciente.PacientesUnificados
        '                strSQL = strSQL & formarSQLHistoriaClinica(unificado, fechaInicial, fechaFinal)
        '            Next

        '        Case "UU"
        '            strSQL = strSQL & formarSQLHistoriaClinica(objPaciente, fechaInicial, fechaFinal)

        '            For Each unificado As Paciente In objPaciente.PacientesUnificados
        '                strSQL = strSQL & formarSQLHistoriaClinica(unificado, fechaInicial, fechaFinal)
        '            Next
        '        Case Else
        '            strSQL = strSQL & "HCENF_TraerPaciente_Impresion"



        '    End Select

        '    '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
        '    '' ''command = db.GetSqlStringCommandWrapper(strSQL)
        '    '' ''dsHistorias = db.ExecuteDataSet(command)

        '    gpmDataObj.setSQLSentence(strSQL, CommandType.StoredProcedure)
        '    gpmDataObj.ClearParameters()

        '    gpmDataObj.addInputParameter("@tip_doc", SqlDbType.VarChar, objPaciente.TipoDocumento)
        '    gpmDataObj.addInputParameter("@Num_doc", SqlDbType.VarChar, objPaciente.NumeroDocumento)

        '    If fechaInicial.CompareTo(Nothing) <> 0 And fechaFinal.CompareTo(Nothing) <> 0 Then
        '        gpmDataObj.addInputParameter("@fechaInicial", SqlDbType.DateTime, fechaInicial)
        '        gpmDataObj.addInputParameter("@fechaFinal", SqlDbType.DateTime, fechaFinal)
        '    End If

        '    Dim dtReader As IDataReader

        '    dtReader = gpmDataObj.ExecRdr()
        '    dtResultado.Load(dtReader)

        '    Return dtResultado

        'End Function

        Public Shared Function formarSQLHistoriaClinica(ByVal objPaciente As Paciente, ByVal fechaInicial As Date,
                                                    ByVal fechaFinal As Date) As String


            Dim strSQL As String = ""
            ''Inicio llarias Se agrega espacio antes del select ya que para pacientes unificados generaba error porque
            ''la consulta quedaba unida a la anterios CA 4162268 2019-06-26
            strSQL = " SELECT m.cod_historia, a.cod_pre_sgs, a.cod_sucur,  a.tip_admision, " &
               "a.ano_adm, a.num_adm, a.tip_hc, a.tip_doc, a.num_doc, b.edad, " &
               "a.fec_hc, a.hor_hc, a.min_hc, l.descripcion as Especialidad, " &
               "c.pri_ape + ' ' + isnull(c.seg_ape,'') + ' ' +  c.pri_nom + ' ' + isnull(c.seg_nom,'') as medico, " &
               "c.reg_med, c.medico as id_med, j.descripcion as sucursal, a.estado_salida, j.direccion, j.telefono, a.entidad " & vbCrLf
            ''Fin llarias

            strSQL = strSQL & "FROM HCENCABEZADO a (nolock) " &
               "INNER JOIN ADMMOVIM b (nolock) ON " &
               "a.cod_pre_sgs = b.cod_pre_sgs " &
               "AND a.cod_sucur = b.cod_sucur " &
               "AND a.tip_admision = b.tip_admision " &
               "AND a.ano_adm = b.ano_adm " &
               "AND a.num_adm = b.num_adm " &
               "LEFT JOIN GENMEDIC C (nolock) ON " &
               "c.medico = isnull(a.login_egreso,a.login) " & vbCrLf

            strSQL = strSQL & "LEFT JOIN GENSUCUR j (nolock) ON " &
               "j.cod_pre_sgs = a.cod_pre_sgs " &
               "AND j.cod_sucur = a.cod_sucur " &
               "LEFT OUTER JOIN GENMEDSU k (nolock) on " &
               "k.cod_pre_sgs = a.cod_pre_sgs  " &
               "and k.cod_sucur = a.cod_sucur " &
               "and k.medico = b.medico_tratante " &
               "and k.especialidad = isnull(b.especialidad,k.especialidad) " &
               "LEFT OUTER JOIN genespec l (nolock) on " &
               "k.especialidad = l.especialidad " & vbCrLf

            strSQL = strSQL & " INNER JOIN hcenfermeria m (nolock) ON m.cod_pre_sgs = a.cod_pre_sgs AND m.cod_sucur = a.cod_sucur AND m.tip_admision = a.tip_admision AND m.ano_adm = a.ano_adm AND m.num_adm = a.num_adm " & vbCrLf

            strSQL = strSQL & "WHERE  a.tip_doc = '" & objPaciente.TipoDocumento & "' " & "AND a.Num_doc = '" & objPaciente.NumeroDocumento & "' " & vbCrLf ''& _
            ''"AND a.estado <> 'P' AND a.estado <> 'L'"

            If fechaInicial.CompareTo(Nothing) <> 0 And fechaFinal.CompareTo(Nothing) <> 0 Then
                strSQL = strSQL & "AND a.fec_hc >= '" & Format$(fechaInicial, "yyyy/MM/dd") & "' " & "AND a.fec_hc <= '" & Format$(fechaFinal, "yyyy/MM/dd") & "' "
            End If


            Return strSQL



        End Function


        Public Shared Function traerHistoriasXPaciente(ByVal objConexion As Conexion, ByVal objPaciente As Paciente, ByVal fechaInicial As Date,
                                                    ByVal fechaFinal As Date, ByVal Sucursal As String,
                                                       ByVal prestador As String) As DataTable
            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            '' ''Dim db As Database
            '' ''Dim command As DBCommandWrapper

            Dim dtbUnificados As DataTable
            Dim strSQL As String = ""
            Dim objResultadoAdm As New BLHistoriaBasica
            Dim dtDatos As New DataTable

            Select Case objPaciente.Unificado
                Case "U"
                    If Not New Paciente().PacienteVacio(objPaciente.PacienteUnificador) Then
                        'strSQL = strSQL & formarSQLHistoriaClinica(objPaciente.PacienteUnificador,
                        '                                           fechaInicial, fechaFinal)

                        dtDatos = objResultadoAdm.ConsultaAdminNacional_HCEnf(objConexion, objPaciente.PacienteUnificador.TipoDocumento,
                                                         objPaciente.PacienteUnificador.NumeroDocumento, fechaInicial, fechaFinal, Sucursal, prestador, 0)
                    End If

                    For Each unificado As Paciente In objPaciente.PacientesUnificados

                        ''Se unen las filas iniciales con las unificadas en el DataTable
                        dtbUnificados = objResultadoAdm.ConsultaAdminNacional_HCEnf(objConexion, unificado.TipoDocumento,
                                 unificado.NumeroDocumento, fechaInicial, fechaFinal, Sucursal, prestador, 0)

                        If (dtbUnificados.Rows.Count > 0) Then
                            dtDatos.Merge(dtbUnificados)
                        End If

                        'strSQL = strSQL & formarSQLHistoriaClinica(unificado, fechaInicial, fechaFinal)
                        'dtDatos = objResultadoAdm.ConsultaAdminNacional_HCEnf(objConexion, unificado.TipoDocumento,
                        '                                 unificado.NumeroDocumento, fechaInicial, fechaFinal, Sucursal, prestador, 0)
                    Next

                Case "UU"
                    'strSQL = strSQL & formarSQLHistoriaClinica(objPaciente, fechaInicial, fechaFinal)
                    dtDatos = objResultadoAdm.ConsultaAdminNacional_HCEnf(objConexion, objPaciente.TipoDocumento,
                                                         objPaciente.NumeroDocumento, fechaInicial, fechaFinal, Sucursal, prestador, 0)
                    For Each unificado As Paciente In objPaciente.PacientesUnificados

                        ''Se unen las filas iniciales con las unificadas en el DataTable
                        dtbUnificados = objResultadoAdm.ConsultaAdminNacional_HCEnf(objConexion, unificado.TipoDocumento,
                                 unificado.NumeroDocumento, fechaInicial, fechaFinal, Sucursal, prestador, 0)

                        If (dtbUnificados.Rows.Count > 0) Then
                            dtDatos.Merge(dtbUnificados)
                        End If

                        ' strSQL = strSQL & formarSQLHistoriaClinica(unificado, fechaInicial, fechaFinal)
                        'dtDatos = objResultadoAdm.ConsultaAdminNacional_HCEnf(objConexion, unificado.TipoDocumento,
                        '                                 unificado.NumeroDocumento, fechaInicial, fechaFinal, Sucursal, prestador, 0)

                    Next
                Case Else
                    ' strSQL = strSQL & formarSQLHistoriaClinica(objPaciente, fechaInicial, fechaFinal)
                    dtDatos = objResultadoAdm.ConsultaAdminNacional_HCEnf(objConexion, objPaciente.TipoDocumento,
                                                         objPaciente.NumeroDocumento, fechaInicial, fechaFinal, Sucursal, prestador, 0)

            End Select

            '' ''db = DynamicDatabaseFactory.CreateDatabase(objConexion.strServidor, objConexion.strBaseDatos, objConexion.strUsuarioBD, objConexion.strClaveUsuarioBD, DBProviderType.SqlServer)
            '' ''command = db.GetSqlStringCommandWrapper(strSQL)
            '' ''dsHistorias = db.ExecuteDataSet(command)

            'gpmDataObj.setSQLSentence(strSQL, CommandType.Text)
            'dsHistorias = gpmDataObj.execDS()
            'dtResultado = dsHistorias.Tables(0).Clone

            'For Each tabla As DataTable In dsHistorias.Tables
            '    dtResultado.Merge(tabla)
            'Next

            Return dtDatos


        End Function


        Public Sub consultarSeccionesAdicionales(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String,
                                           ByVal strCod_sucur As String, ByVal strTip_admision As String,
                                           ByVal lano_adm As Long, ByVal dnum_adm As Double,
                                           ByVal strTipDoc As String, ByVal strNumDoc As String,
                                           ByVal strTip_historia As String, ByVal strLogin As String,
                                           ByVal edadPaciente As Integer, ByVal secciones As Secciones)
            _secciones = secciones

            If _secciones.Remision = True Then
                Dim hayRemision As Boolean
                _remision = New RemisionPlanManejo()
                hayRemision = _remision.crearRemision(strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strTip_admision,
                                               lano_adm, dnum_adm)
                If hayRemision Then
                    BLPlanManejo.ConsultarRemision(objConexion, strcod_pre_sgs, strCod_sucur, strTip_admision,
                                                   lano_adm, dnum_adm, _remision)
                Else
                    _remision = Nothing
                End If
            End If

            If _secciones.Recomendaciones = True Then
                Dim hayRecomendaciones As Boolean
                _recomendaciones = New RecomendacionEgreso()
                hayRecomendaciones = _recomendaciones.crearRecomendacionEgreso(strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strTip_admision,
                                               lano_adm, dnum_adm, Nothing)
                If Not hayRecomendaciones Then
                    _recomendaciones = Nothing
                End If
            End If

            If _secciones.Triage = True Then
                Dim hayTriage As Boolean
                _triage = New Triage()
                hayTriage = _triage.llenarTriage(objConexion, strcod_pre_sgs, strCod_sucur, strTipDoc, strNumDoc, strTip_admision,
                                                 lano_adm, dnum_adm, HistoriaClinica.DatosPaciente.Paciente.TipoPacienteTriage(edadPaciente))
                If Not hayTriage Then
                    _triage = Nothing
                End If
            End If
        End Sub


        Public Shared Function traerInfoLaboratorio(ByVal objConexion As Conexion, ByVal objPaciente As Paciente, ByVal objgeneral As objPaciente, ByVal objgeneral1 As Generales) As DataTable

            Dim dsHistorias As DataSet
            Dim dtResultado As DataTable
            Dim strSQL As String = ""

            strSQL = "SELECT distinct b.con_solicitu as Pedido, format(a.fec_pedido,'yyyy-MM-dd hh:mm') as fec_Pedido, g.descripcionlaboratorio as Examen, isnull(f.des_estado,'SOLICITADO') as Estado " & vbCrLf

            strSQL = strSQL & "FROM carencpe AS a (nolock) INNER JOIN " &
               " cardetpe AS b (nolock) ON a.cod_pre_sgs = b.cod_pre_sgs AND a.cod_sucur = b.cod_sucur AND a.con_solicitu = b.con_solicitu  INNER JOIN " &
               " genprocelabordet AS e (nolock) ON b.procedim = e.procedim and b.codigolaboratorio = e.codigolaboratorio INNER JOIN " &
               " genprocelabor AS g (nolock) ON  g.codigolaboratorio = e.codigolaboratorio  INNER JOIN " &
               " admmovim AS c ON a.cod_pre_sgs = c.cod_pre_sgs AND a.cod_sucur = c.cod_sucur AND a.tip_admision = c.tip_admision AND a.ano_adm = c.ano_adm AND a.num_adm = c.num_adm  LEFT OUTER JOIN " &
               " genestadolabo as f (nolock) on f.cod_estado = b.estadolaboratorio " & vbCrLf

            strSQL = strSQL & "WHERE  c.cod_pre_sgs = '" & objgeneral1.Prestador & "' " & "AND c.cod_sucur = '" & objgeneral1.Sucursal & "' " & vbCrLf &
               "AND c.tip_admision = '" & objgeneral.TipoAdmision & "' AND c.ano_adm = " & objgeneral.AnoAdmision & "  AND c.num_adm = " & objgeneral.NumeroAdmision & "    "

            strSQL = strSQL & " UNION ALL SELECT distinct b.con_solicitu as Pedido, format(a.fec_pedido,'yyyy-MM-dd hh:mm') as fec_Pedido, g.descripcionlaboratorio as Examen, isnull(f.des_estado,'SOLICITADO') as Estado " & vbCrLf

            strSQL = strSQL & "FROM carencpe AS a (nolock) INNER JOIN " &
               " cardetpe AS b (nolock) ON a.cod_pre_sgs = b.cod_pre_sgs AND a.cod_sucur = b.cod_sucur AND a.con_solicitu = b.con_solicitu  INNER JOIN " &
               " genprocelabordet AS e (nolock) ON b.procedim = e.procedim and b.codigolaboratorio = e.codigolaboratorio INNER JOIN " &
               " genprocelabor AS g (nolock) ON  g.codigolaboratorio = e.codigolaboratorio INNER JOIN " &
               " admmovim AS c ON a.cod_pre_sgs = c.cod_pre_sgs AND a.cod_sucur = c.cod_sucur AND c.cod_adm_des = a.tip_admision + CONVERT(varchar(4), a.ano_adm) + CONVERT(varchar(10), a.num_adm)  LEFT OUTER JOIN  " &
               " genestadolabo as f (nolock) on f.cod_estado = b.estadolaboratorio " & vbCrLf

            strSQL = strSQL & "WHERE  c.cod_pre_sgs = '" & objgeneral1.Prestador & "' " & "AND c.cod_sucur = '" & objgeneral1.Sucursal & "' " & vbCrLf &
               "AND c.tip_admision = '" & objgeneral.TipoAdmision & "' AND c.ano_adm = " & objgeneral.AnoAdmision & "  AND c.num_adm = " & objgeneral.NumeroAdmision & "  order by fec_Pedido desc       "


            gpmDataObj.setSQLSentence(strSQL, CommandType.Text)
            dsHistorias = gpmDataObj.execDS()
            dtResultado = dsHistorias.Tables(0).Clone

            For Each tabla As DataTable In dsHistorias.Tables
                dtResultado.Merge(tabla)
            Next

            Return dtResultado


        End Function


    End Class
End Namespace

