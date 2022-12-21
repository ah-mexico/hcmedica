Imports System
Namespace Sophia.HistoriaClinica.DAO

    Public Class DAODescripcionQXManejoDeDatos
        Inherits GPMData
        'martovar 2014-10-10 version 2.9.0 descripcion quirurgica 
        'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
        Public Function GuardarProcedimiento(ByVal strPrestador As String, ByVal strSucursal As String, ByVal DConsecutivo As Decimal,
        ByVal strprocedim As String, ByVal FechaReal As Nullable(Of Date), ByVal HoraReal As Integer, ByVal MinReal As Integer, ByVal FechaRealFin As Nullable(Of Date),
        ByVal strTiempoQx As String, ByVal intsangrado As Integer, ByVal strtejidos As String, ByVal strdesc_intervencion As String,
        ByVal strrecuento_material As String, ByVal strcomplicaciones As String, ByVal strhallazgos As String,
        ByVal HoraRealFin As Integer, ByVal MinRealFin As Integer, ByVal strTipAnestesia As String, ByVal strEntidad As String,
        ByVal strTiempoLimpieza As String, ByVal strbilateral As String, ByVal loginModif As String, ByVal intAccion As Integer,
        ByVal secuencia As Integer, ByVal especloginmodif As String, ByVal tip_admision As String, ByVal ano_adm As Integer, ByVal num_adm As Decimal,
        Optional ByVal strParticularidades As String = "",
        Optional ByVal strautoSISPRO As String = "") As String

            Dim MensajeError As String = ""
            Dim intSecuencia As Integer = 0

            If (String.IsNullOrEmpty(strTiempoLimpieza)) Then
                strTiempoLimpieza = ""
            End If

            Me.setSQLSentence("HCDescripcionQX_GuardarCambiosDescripcionQX", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strPrestador)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strSucursal)
            Me.addInputParameter("consecutivo", SqlDbType.Decimal, DConsecutivo)
            Me.addInputParameter("procedim", SqlDbType.VarChar, strprocedim)
            Me.addInputParameter("fecha_real", SqlDbType.DateTime, FechaReal)
            Me.addInputParameter("hor_inicialreal", SqlDbType.Int, HoraReal)
            Me.addInputParameter("min_inicialreal ", SqlDbType.Int, MinReal)
            Me.addInputParameter("fecha_realfin", SqlDbType.DateTime, FechaRealFin)
            Me.addInputParameter("hor_finalreal", SqlDbType.Int, HoraRealFin)
            Me.addInputParameter("min_finalreal", SqlDbType.Int, MinRealFin)
            Me.addInputParameter("tiempo_qx", SqlDbType.VarChar, strTiempoQx)
            Me.addInputParameter("sangrado", SqlDbType.Int, intsangrado)
            Me.addInputParameter("tejidos", SqlDbType.VarChar, strtejidos)
            Me.addInputParameter("desc_intervencion", SqlDbType.VarChar, strdesc_intervencion)
            Me.addInputParameter("recuento_material", SqlDbType.VarChar, strrecuento_material)
            Me.addInputParameter("complicaciones", SqlDbType.VarChar, strcomplicaciones)
            Me.addInputParameter("hallazgos", SqlDbType.VarChar, strhallazgos)
            Me.addInputParameter("tip_anestesia", SqlDbType.VarChar, strTipAnestesia)
            Me.addInputParameter("entidad", SqlDbType.VarChar, strEntidad)
            Me.addInputParameter("tie_limpieza", SqlDbType.VarChar, strTiempoLimpieza)
            Me.addInputParameter("bilateral", SqlDbType.VarChar, strbilateral)
            Me.addInputParameter("login_modif", SqlDbType.VarChar, loginModif)
            Me.addInputParameter("espec_login_modif", SqlDbType.VarChar, especloginmodif)
            Me.addInputParameter("intaccion", SqlDbType.Int, intAccion)
            Me.addInputParameter("secuencia", SqlDbType.Int, secuencia)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, tip_admision)
            Me.addInputParameter("ano_adm", SqlDbType.Int, ano_adm)
            Me.addInputParameter("num_adm", SqlDbType.Decimal, num_adm)
            Me.addInputParameter("autoSISPRO", SqlDbType.VarChar, strautoSISPRO)
            Me.addOutputParameter("Mensaje", SqlDbType.VarChar, 500)
            'Joseph Moreno (IG) Fec:2019/11/18 Particularidades
            If strParticularidades <> "" Then
                Me.addInputParameter("strParticularidades", SqlDbType.VarChar, strParticularidades)
            End If

            Me.Exec()

            MensajeError = Me.Parameters("Mensaje").Value

            Return MensajeError

        End Function
        Public Function GuardarEquipoMedico(ByVal strPrestador As String, ByVal strSucursal As String, ByVal DConsecutivo As Decimal,
              ByVal strprocedim As String, ByVal strcodMedico As String, ByVal strTipEmpleado As String, ByVal strEspecialidad As String,
              ByVal strEstado As String, ByVal strBilateral As String, ByVal strNumAutoriza As String, ByVal strObs As String,
              ByVal strLogin As String, ByVal strcirujano_invitado As String) As String

            Dim MensajeError As String = ""

            Me.setSQLSentence("HCDescripcionQX_GuardarCambiosEquipoMedico", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strPrestador)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strSucursal)
            Me.addInputParameter("consecutivo", SqlDbType.Decimal, DConsecutivo)
            Me.addInputParameter("procedim", SqlDbType.VarChar, strprocedim)
            Me.addInputParameter("cod_permedas", SqlDbType.VarChar, strcodMedico)
            Me.addInputParameter("tip_empleado", SqlDbType.VarChar, strTipEmpleado)
            Me.addInputParameter("especialidad", SqlDbType.VarChar, strEspecialidad)
            Me.addInputParameter("estado", SqlDbType.VarChar, strEstado)
            Me.addInputParameter("bilateral", SqlDbType.VarChar, strBilateral)
            Me.addInputParameter("nro_autoriza", SqlDbType.VarChar, strNumAutoriza)
            Me.addInputParameter("obs", SqlDbType.VarChar, strObs)
            Me.addInputParameter("login", SqlDbType.VarChar, strLogin)
            Me.addInputParameter("cirujano_invitado", SqlDbType.VarChar, strcirujano_invitado)
            Me.addOutputParameter("Mensaje", SqlDbType.VarChar, 500)

            Me.Exec()

            MensajeError = Me.Parameters("Mensaje").Value

            Return MensajeError

        End Function

        Public Function ActualizaEquipoMedico(ByVal strPrestador As String, ByVal strSucursal As String, ByVal DConsecutivo As Decimal,
             ByVal strprocedim As String, ByVal strcodMedico As String, ByVal strTipEmpleado As String,
             ByVal strLogin As String) As String

            Dim MensajeError As String = ""

            Me.setSQLSentence("HCDescripcionQX_ActualizaEstadoEquipoMedico", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strPrestador)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strSucursal)
            Me.addInputParameter("consecutivo", SqlDbType.Decimal, DConsecutivo)
            Me.addInputParameter("procedim", SqlDbType.VarChar, strprocedim)
            Me.addInputParameter("cod_permedas", SqlDbType.VarChar, strcodMedico)
            Me.addInputParameter("tip_empleado", SqlDbType.VarChar, strTipEmpleado)
            Me.addInputParameter("login", SqlDbType.VarChar, strLogin)
            Me.addOutputParameter("Mensaje", SqlDbType.VarChar, 500)

            Me.Exec()

            MensajeError = Me.Parameters("Mensaje").Value

            Return MensajeError

        End Function
        Public Function GuardarDiagnosticos(ByVal strPrestador As String, ByVal strSucursal As String, ByVal DConsecutivo As Decimal,
              ByVal strprocedim As String, ByVal strDiagnostico As String, ByVal strclasifica As String,
              ByVal strclase As String, ByVal strObs As String, ByVal strLogin As String) As String

            Dim MensajeError As String = ""

            Me.setSQLSentence("HCDescripcionQX_GuardarDiagnosticos", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strPrestador)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strSucursal)
            Me.addInputParameter("consecutivo", SqlDbType.Decimal, DConsecutivo)
            Me.addInputParameter("procedim", SqlDbType.VarChar, strprocedim)
            ' Me.addInputParameter("tip_diag", SqlDbType.VarChar, strtipDiagn)
            Me.addInputParameter("diagnost", SqlDbType.VarChar, strDiagnostico)
            Me.addInputParameter("login", SqlDbType.VarChar, strLogin)
            Me.addInputParameter("obs", SqlDbType.VarChar, strObs)
            Me.addInputParameter("clasificacion", SqlDbType.VarChar, strclasifica)
            Me.addInputParameter("clase", SqlDbType.VarChar, strclase)
            Me.addOutputParameter("Mensaje", SqlDbType.VarChar, 500)

            Me.Exec()

            MensajeError = Me.Parameters("Mensaje").Value

            Return MensajeError

        End Function
        Public Function ActualizaDiagnosticos(ByVal strPrestador As String, ByVal strSucursal As String, ByVal DConsecutivo As Decimal,
             ByVal strprocedim As String, ByVal strDiagnostico As String,
             ByVal strclase As String, ByVal strLogin As String) As String

            Dim MensajeError As String = ""

            Me.setSQLSentence("HCDescripcionQX_ActualizaDiagnosticos", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strPrestador)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strSucursal)
            Me.addInputParameter("consecutivo", SqlDbType.Decimal, DConsecutivo)
            Me.addInputParameter("procedim", SqlDbType.VarChar, strprocedim)
            Me.addInputParameter("diagnost", SqlDbType.VarChar, strDiagnostico)
            Me.addInputParameter("login", SqlDbType.VarChar, strLogin)
            Me.addInputParameter("clase", SqlDbType.VarChar, strclase)
            Me.addOutputParameter("Mensaje", SqlDbType.VarChar, 500)

            Me.Exec()

            MensajeError = Me.Parameters("Mensaje").Value

            Return MensajeError

        End Function
        Public Sub GrabarLogErrores(ByVal strMensaje As String, ByVal strSucursal As String, ByVal strProcedimiento As String, ByVal dConsecutivo As Decimal, ByVal strLogin As String)


            Me.setSQLSentence("HC_GrabarErroresDescripcionQX", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("mensaje", SqlDbType.VarChar, strMensaje)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strSucursal)
            Me.addInputParameter("procedim", SqlDbType.VarChar, strProcedimiento)
            Me.addInputParameter("consecutivo_qx", SqlDbType.Decimal, dConsecutivo)
            Me.addInputParameter("login", SqlDbType.VarChar, strLogin)
            Me.Exec()

        End Sub
        Public Function GrabarProfilaxis(ByVal strPrestador As String, ByVal strSucursal As String, ByVal strProcedimiento As String, ByVal dConsecutivo As Decimal,
         ByVal strcod_corto As String, ByVal intaccion As Integer, ByVal strLogin As String, ByVal strObs As String) As String

            Dim MensajeError As String = ""
            Me.setSQLSentence("HCDescripcionQX_GuardarProfilaxis", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strPrestador)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strSucursal)
            Me.addInputParameter("consecutivo", SqlDbType.Decimal, dConsecutivo)
            Me.addInputParameter("procedim", SqlDbType.VarChar, strProcedimiento)
            Me.addInputParameter("cod_corto", SqlDbType.VarChar, strcod_corto)
            Me.addInputParameter("login", SqlDbType.VarChar, strLogin)
            Me.addInputParameter("obs", SqlDbType.VarChar, strObs)
            Me.addInputParameter("intaccion", SqlDbType.Int, intaccion)
            Me.addOutputParameter("Mensaje", SqlDbType.VarChar, 500)
            Me.Exec()

            MensajeError = Me.Parameters("Mensaje").Value

            Return MensajeError

        End Function


        Public Function GuardarOrdenPatologia(ByVal strPrestador As String, ByVal strSucursal As String, ByVal DConsecutivo As Decimal,
     ByVal fecha As Nullable(Of Date), ByVal Hora As Integer, ByVal Min As Integer, ByVal strTipAdmision As String, ByVal strAnoadmision As String,
     ByVal strNumadm As String, ByVal strmedico As String, ByVal strespecialidad As String, ByVal strhallazgos As String,
     ByVal strseccion As String, ByVal strorgano As String, ByVal strestudio As String, ByVal strmuestra As String, ByVal strprocedim As String, ByVal strespecialidadS As String) As String

            Dim MensajeError As String = ""
            Dim intSecuencia As Integer = 0


            Me.setSQLSentence("HCDescripcionQX_GuardarCambiosOrdenDePatologia", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("cod_pre_sgs", SqlDbType.VarChar, strPrestador)
            Me.addInputParameter("cod_sucur", SqlDbType.VarChar, strSucursal)
            Me.addInputParameter("consecutivo", SqlDbType.Decimal, DConsecutivo)
            Me.addInputParameter("procedim", SqlDbType.VarChar, strprocedim)
            Me.addInputParameter("tip_admision", SqlDbType.VarChar, strTipAdmision)
            Me.addInputParameter("ano_adm", SqlDbType.VarChar, strAnoadmision)
            Me.addInputParameter("num_adm", SqlDbType.VarChar, strNumadm)
            Me.addInputParameter("fec_solicitud", SqlDbType.DateTime, fecha)
            Me.addInputParameter("hor_muestra", SqlDbType.Int, Hora)
            Me.addInputParameter("min_muestra", SqlDbType.Int, Min)
            Me.addInputParameter("medico_solicita", SqlDbType.VarChar, strmedico)
            Me.addInputParameter("especialidadMS", SqlDbType.VarChar, strespecialidad)
            Me.addInputParameter("especialidadS", SqlDbType.VarChar, strespecialidadS)
            Me.addInputParameter("hallazgos", SqlDbType.VarChar, strhallazgos)
            Me.addInputParameter("seccion", SqlDbType.VarChar, strseccion)
            Me.addInputParameter("organo", SqlDbType.VarChar, strorgano)
            Me.addInputParameter("estudio_sol", SqlDbType.VarChar, strestudio)
            Me.addInputParameter("cod_muestra", SqlDbType.VarChar, strmuestra)
            Me.addOutputParameter("Mensaje", SqlDbType.VarChar, 500)

            Me.Exec()

            MensajeError = Me.Parameters("Mensaje").Value

            Return MensajeError

        End Function

    End Class
End Namespace

