
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports objPaciente = HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente.Paciente
Namespace Sophia.HistoriaClinica.BL

#Region "blNotasEnfermeria"

    Public Class BLNotasEnfermeria

#Region "consultargenero"
        Public Shared Function consultarGenero(ByVal objConexion As objCon) As DataTable
            Dim daoNotasEnf As New DAONotasEnfermeria()
            Return daoNotasEnf.consultarGenero(objConexion)
        End Function
#End Region
#Region "consultargeneroRn"

        Public Shared Function consultarGeneroRn(ByVal objConexion As objCon, ByVal strTipDocRn As String, ByVal strNumDocRn As String) As String
            Dim daoNotasEnf As New DAONotasEnfermeria()
            Return daoNotasEnf.consultarGeneroRn(objConexion, strTipDocRn, strNumDocRn)
        End Function
#End Region
#Region "consultarhcenfnacimiento"
        Public Function consultarhcEnfNacimiento(ByVal dblCodHistoria As Long, ByVal objConexion As objCon) As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long

            Return obj.EjecutarSPConParametros("HCENF_TraerRecienNacido", objConexion, lError, dblCodHistoria, lError)
        End Function
#End Region

#Region "consultaRecienNacido"
        Public Function consultarRecienNacido(ByVal dblCodHistoria As Long, ByVal intManilla As Integer, ByVal objConexion As objCon) As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long

            Return obj.EjecutarSPConParametros("HCENF_TraerRecienNacidoManilla", objConexion, lError, dblCodHistoria, intManilla, lError)
        End Function
#End Region


#Region "consultarhcenfManEvaPost"
        ''RecienNacido = New Sophia.HistoriaClinica.BL.BLNotasEnfermeria().consultarhcEnfEvaPost(objConexion, dCod_Historia, intManilla, 2, strFechaIni, strFechaFin, iHoraIni, iHoraFin)

        Public Function consultarhcenfManEvaPost(ByVal objConexion As objCon, ByVal dblCodHistoria As Integer, ByVal intManilla As Long, ByVal intOpcion As Integer, ByVal strFechaIni As Nullable(Of Date), ByVal strFechaFin As Nullable(Of Date), ByVal iHoraIni As Nullable(Of Integer), ByVal iHoraFin As Nullable(Of Integer)) As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long

            Return obj.EjecutarSPConParametros("HCENF_RepManTraerEvaluacionesPost", objConexion, lError, dblCodHistoria, intManilla, strFechaIni, strFechaFin, iHoraIni, iHoraFin, lError)
        End Function
#End Region


#Region "consultarhcenfEvaPost"
        ''RecienNacido = New Sophia.HistoriaClinica.BL.BLNotasEnfermeria().consultarhcEnfEvaPost(objConexion, dCod_Historia, intManilla, 2, strFechaIni, strFechaFin, iHoraIni, iHoraFin)

        Public Function consultarhcEnfEvaPost(ByVal objConexion As objCon, ByVal dblCodHistoria As Integer, ByVal strFechaIni As Nullable(Of Date), ByVal strFechaFin As Nullable(Of Date), ByVal iHoraIni As Nullable(Of Integer), ByVal iHoraFin As Nullable(Of Integer)) As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lError As Long

            Return obj.EjecutarSPConParametros("HCENF_RepTraerEvaluacionesPost", objConexion, lError, dblCodHistoria, strFechaIni, strFechaFin, iHoraIni, iHoraFin, lError)
        End Function
#End Region

#Region "Grabar Recien Nacido"
        'Public Function GrabarNacimiento(ByVal objConexion As objCon, ByVal intmanilla As Integer, _
        '    ByVal dteFecha As String, ByRef intHoraNac As Integer, ByRef intMinNac As Integer, ByVal strSexo As String, _
        '    ByVal intPeso As Integer, ByVal intTalla As Integer, ByVal intCefalico As Integer, _
        '    ByVal intToracico As Integer, ByVal intAbdominal As Integer, ByVal intApgarNac As Integer, _
        '    ByVal intApgarMin As Integer, ByVal intApgar10Min As Integer, ByVal strvacBCG As String, _
        '    ByVal strVacAHB As String, ByVal strVacPolio As String, ByVal strUmbilical As String, _
        '    ByVal strOcular As String, ByVal strVitaminaK As String, ByVal strHemo As String, _
        '    ByVal strCondicion As String) As Long

        Public Function GrabarNacimiento(ByVal objConexion As objCon, ByVal intmanilla As Integer, _
            ByVal dteFecha As String, ByRef intHoraNac As Integer, ByRef intMinNac As Integer, ByVal strSexo As String, _
            ByVal intPeso As Integer, ByVal intTalla As Decimal, ByVal intCefalico As Decimal, _
            ByVal intToracico As Decimal, ByVal intAbdominal As Decimal, ByVal intApgarNac As Integer, _
            ByVal intApgarMin As Integer, ByVal intApgar10Min As Integer, ByVal strvacBCG As String, _
            ByVal strVacAHB As String, ByVal strUmbilical As String, _
            ByVal strOcular As String, ByVal strVitaminaK As String, ByVal strHemo As String, _
            ByVal strCondicion As String) As Long


            Dim obj As New Sophia.HistoriaClinica.DAO.DAONotasEnfermeria

            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia

            Dim lError As Long

            lError = obj.GrabarNacimiento(objConexion, objP.CodHistoria, intmanilla, dteFecha, intHoraNac, intMinNac, _
                                        strSexo, intPeso, intTalla, intCefalico, intToracico, intAbdominal, _
                                        intApgarNac, intApgarMin, intApgar10Min, strvacBCG, strVacAHB, _
                                        strUmbilical, strOcular, strVitaminaK, strHemo, strCondicion, objG.Login)

            'lError = obj.GrabarNacimiento(objConexion, objP.CodHistoria, intmanilla, dteFecha, intHoraNac, intMinNac, _
            '                            strSexo, intPeso, intTalla, intCefalico, intToracico, intAbdominal, _
            '                            intApgarNac, intApgarMin, intApgar10Min, strvacBCG, strVacAHB, strVacPolio, _
            '                            strUmbilical, strOcular, strVitaminaK, strHemo, strCondicion, objG.Login)

            Return lError

        End Function

#End Region

#Region "ModificacionRecienNacido"
        Public Function ModificarRecienNacido(ByVal objConexion As objCon, ByVal intmanilla As String, _
                                              ByVal strHemo As String) As Long

            Dim obj As New Sophia.HistoriaClinica.DAO.DAONotasEnfermeria

            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia

            Dim lError As Long

            lError = obj.ModificarRecienNacido(objConexion, objP.CodHistoria, intmanilla, strHemo, objG.Login)

            Return lError

        End Function

#End Region

#Region "Grabar Evaluacion Posterior"
        Public Function GrabarEvaluacionPost(ByVal objConexion As objCon, ByVal intmanilla As Integer, _
            ByVal dteFecha As Date, ByVal strHora As String, ByVal strMin As String, ByRef intFR As String, _
            ByVal intFC As String, ByVal intTemp As String, ByVal intSat As String, ByVal intGlucom As String, _
            ByVal strSuccion As String, ByVal strDiuresis As String, ByVal strDeposicion As String, _
            ByVal strViaoral As String, ByVal strObs As String) As Long

            Dim obj As New Sophia.HistoriaClinica.DAO.DAONotasEnfermeria

            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia

            Dim lError As Long

            lError = obj.GrabarEvaluacionPost(objConexion, objP.CodHistoria, intmanilla, dteFecha, strHora, strMin, _
                                              intFR, intFC, intTemp, intSat, intGlucom, strSuccion, strDiuresis, _
                                              strDeposicion, strViaoral, strObs, objG.Login)

            Return lError

        End Function

#End Region

#Region "ConsultarNotasEvolucion"
        Public Function ConsultarNotasEvolucion(ByVal objConexion As objCon, ByRef dtNotasEvolucion As DataTable) As Long

            Dim obj As New Sophia.HistoriaClinica.DAO.DAONotasEnfermeria

            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia

            Dim lError As Long
            lError = obj.ConsultarNotasEvolucion(objConexion, CInt(objP.CodHistoria), dtNotasEvolucion)

            Return lError
        End Function
#End Region

#Region "ConsultarGruposNotasEvolucion"
        Public Function ConsultarGruposNotasEvolucion(ByVal objConexion As objCon, ByRef dtNotasEvolucion As DataTable) As Long

            Dim obj As New Sophia.HistoriaClinica.DAO.DAONotasEnfermeria

            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia

            Dim lError As Long
            lError = obj.ConsultarGruposNotasEvolucion(objConexion, CInt(objP.CodHistoria), dtNotasEvolucion)

            Return lError
        End Function
#End Region

#Region "ConsultarParametros"
        Public Shared Function ConsultarParametros(ByVal objConexion As objCon, ByVal cod_grupoparametricas As Integer) As DataTable
            Dim daoNotas As New DAONotasEnfermeria()
            Return daoNotas.consultarParametros(objConexion, cod_grupoparametricas)
        End Function
#End Region

#Region "GrabarParametros"
        Public Function GrabarParametros(ByVal objConexion As objCon, ByVal ParametrosChecked As ArrayList, ByRef Consecutivo As Integer, ByVal Fecha As DateTime, ByVal Hora As String, ByVal Minuto As String) As Long

            Dim obj As New Sophia.HistoriaClinica.DAO.DAONotasEnfermeria

            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia

            Dim lError As Long
            lError = obj.GrabarParametros(objConexion, objP.CodHistoria, objG.Login, ParametrosChecked, Consecutivo, Fecha, Hora, Minuto)

            Return lError
        End Function
#End Region

#Region "GrabarEvolucion"
        Public Function GrabarEvolucion(ByVal objConexion As objCon, ByVal iConsecutivo As Integer, ByVal sNotaEvolucion As String, ByVal fecha As DateTime, ByVal hora As String, ByVal minuto As String) As Long

            Dim obj As New Sophia.HistoriaClinica.DAO.DAONotasEnfermeria

            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia

            Dim lError As Long
            lError = obj.GrabarEvolucion(objConexion, CInt(objP.CodHistoria), objG.Login, iConsecutivo, sNotaEvolucion, fecha, hora, minuto)

            Return lError
        End Function
#End Region


#Region "consultarIndicacion"
        Public Shared Function consultarIndicacion(ByVal objConexion As objCon) As DataTable
            Dim daoNotas As New DAONotasEnfermeria()
            Return daoNotas.consultarIndicacion(objConexion)
        End Function
#End Region
#Region "consultarComplicacion"
        Public Shared Function consultarComplicacion(ByVal objConexion As objCon) As DataTable
            Dim daoNotas As New DAONotasEnfermeria()
            Return daoNotas.consultarComplicacion(objConexion)
        End Function
#End Region
#Region "consultarElementosUsados"
        Public Shared Function consultarElementosUsados(ByVal objConexion As objCon) As DataTable
            Dim daoNotas As New DAONotasEnfermeria()
            Return daoNotas.consultarElementosUsados(objConexion)
        End Function
#End Region
#Region "consultarTipocateter"
        Public Shared Function consultarTipocateter(ByVal objConexion As objCon) As DataTable
            Dim daoNotas As New DAONotasEnfermeria()
            Return daoNotas.consultarTipocateter(objConexion)
        End Function
#End Region
#Region "consultarEstadoInsercion"
        Public Shared Function consultarEstadoInsercion(ByVal objConexion As objCon) As DataTable
            Dim daoNotas As New DAONotasEnfermeria()
            Return daoNotas.consultarEstadoInsercion(objConexion)
        End Function
#End Region
#Region "consultarCausaRetiro"
        Public Shared Function consultarCausaRetiro(ByVal objConexion As objCon) As DataTable
            Dim daoNotas As New DAONotasEnfermeria()
            Return daoNotas.consultarCausaRetiro(objConexion)
        End Function
#End Region
#Region "consultarSitioInserccion"
        Public Shared Function consultarSitioInserccion(ByVal objConexion As objCon) As DataTable
            Dim daoNotas As New DAONotasEnfermeria()
            Return daoNotas.consultarSitioInserccion(objConexion)
        End Function
#End Region
#Region "consultarTecnicaInserccion"
        Public Shared Function consultarTecnicaInserccion(ByVal objConexion As objCon) As DataTable
            Dim daoNotas As New DAONotasEnfermeria()
            Return daoNotas.consultarTecnicaInserccion(objConexion)
        End Function
#End Region
#Region "GrabarCateter"
        Public Function GrabarCateter(ByVal objConexion As objCon, ByVal strTipoCateter As Integer, _
            ByVal fdtFecha As DateTime, ByVal strhora_cateter As String, ByVal strmin_cateter As String, ByVal intcalibre As Integer, _
            ByVal strluzcateter As String, ByVal strviainscentral As Boolean, ByVal strviainsPeriferica As Boolean, ByVal strviainsArterial As Boolean, ByVal strlateralidad_izquierda As Boolean, _
            ByVal strlateralidad_derecha As Boolean, ByVal intsitioinsercion As Integer, ByVal inttecinsercion As Integer, ByVal strnumpuntuacion As String, _
            ByVal strcontrolradio_si As Boolean, ByVal strcontrolradio_no As Boolean, ByVal strlocalizacion As String, _
            ByVal chklsIndicacion As Array, ByVal strComplicacion_Si As Boolean, ByVal strComplicacion_No As Boolean, ByVal chklsComplicacion As Array, ByVal strpers_cateter As String, ByVal ArrayComplicacion As Array, ByVal ArrayIndicacion As Array) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAONotasEnfermeria
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia
            Dim lError As Long
            lError = obj.GrabarCateter(objConexion, objP.CodHistoria, strTipoCateter, fdtFecha, strhora_cateter, strmin_cateter, _
            intcalibre, strluzcateter, strviainscentral, strviainsPeriferica, strviainsArterial, strlateralidad_izquierda, strlateralidad_derecha, _
            intsitioinsercion, inttecinsercion, strnumpuntuacion, strcontrolradio_si, strcontrolradio_no, strlocalizacion, _
            chklsIndicacion, strComplicacion_Si, strComplicacion_No, chklsComplicacion, strpers_cateter, objG.Login, ArrayComplicacion, ArrayIndicacion)
            Return lError
        End Function
#End Region
#Region "GrabarSeguimiento"
        Public Function GrabarSeguimiento(ByVal objConexion As objCon, ByVal iconsecutivo As Integer, ByVal fdtFecha As DateTime, ByVal strhora_seguimiento As String, _
            ByVal strmin_seguimiento As String, ByVal intEstado_insercion As Integer, ByVal strObservaciones As String, _
            ByVal chklsElementos_Usados As Array, ByVal ArrayElementos_Usados As Array) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAONotasEnfermeria
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia
            Dim lError As Long
            lError = obj.GrabarSeguimiento(objConexion, objP.CodHistoria, iconsecutivo, fdtFecha, strhora_seguimiento, strmin_seguimiento, _
            intEstado_insercion, strObservaciones, chklsElementos_Usados, ArrayElementos_Usados, objG.Login)

            Return lError
        End Function
#End Region
#Region "GrabarRetiroBL"
        Public Function GrabarRetiroBL(ByVal objConexion As objCon, ByVal dConsecutivo As Integer, _
            ByVal intcod_causaretiro As Integer, ByVal fdtFecha As DateTime, ByVal strhora_retiro As String, ByVal strmin_retiro As String) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAONotasEnfermeria
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia
            Dim lError As Long
            lError = obj.GrabarRetiroDAO(objConexion, objP.CodHistoria, dConsecutivo, intcod_causaretiro, fdtFecha, strhora_retiro, strmin_retiro, _
             objG.Login)

            Return lError
        End Function
#End Region
#Region "ConsultarDataGridViewInserccionBL"
        Public Function ConsultarDataGridViewInserccionBL(ByVal objConexion As objCon, ByRef dt As DataTable) As Long
            Dim obj As New DAONotasEnfermeria()
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia
            Dim lError As Long
            lError = obj.ConsultarDataGridViewInserccionDAO(objConexion, CInt(objP.CodHistoria), dt)
            Return lError
        End Function
#End Region
#Region "ConsultarGrillaBuscarFuncionario"
        Public Function ConsultarGrillaBuscarFuncionario(ByVal objConexion As objCon, ByVal Nombre As String, ByVal Apellido As String, ByRef dt As DataTable) As Long
            Dim obj As New DAONotasEnfermeria()
            Dim lError As Long
            lError = obj.ConsultarGrillaBuscarFuncionario(objConexion, Nombre, Apellido, dt)
            Return lError
        End Function
#End Region
#Region "ConsultarGrillaSeguimientoEstadoBL"
        Public Function ConsultarGrillaSeguimientoEstadoBL(ByVal objConexion As objCon, ByRef dt As DataTable) As Long
            Dim obj As New DAONotasEnfermeria()
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia
            Dim lError As Long
            lError = obj.ConsultarGrillaSeguimientoEstadoDAO(objConexion, CInt(objP.CodHistoria), dt)
            Return lError
        End Function
#End Region
#Region "ConsultarGrillaDatosRetiradosBL"
        Public Function ConsultarGrillaDatosRetiradosBL(ByVal objConexion As objCon, ByRef dt As DataTable) As Long
            Dim obj As New DAONotasEnfermeria()
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia
            Dim lError As Long
            lError = obj.ConsultarGrillaDatosRetiradosDAO(objConexion, CInt(objP.CodHistoria), dt)
            Return lError
        End Function
#End Region
#Region "ValidarGrillaSeguimientoBL"
        Public Function ValidarGrillaSeguimientoBL(ByVal objConexion As objCon, ByRef dt As DataTable) As Long
            Dim obj As New DAONotasEnfermeria()
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia
            Dim lError As Long
            lError = obj.ValidarGrillaSeguimientoDAO(objConexion, CInt(objP.CodHistoria), dt)
            Return lError
        End Function
#End Region
#Region "ValidarGrillaRetiroBL"
        Public Function ValidarGrillaRetiroBL(ByVal objConexion As objCon, ByRef dt As DataTable) As Long
            Dim obj As New DAONotasEnfermeria()
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia
            Dim lError As Long
            lError = obj.ValidarGrillaRetiroDAO(objConexion, CInt(objP.CodHistoria), dt)
            Return lError
        End Function
#End Region
#Region "consultarCalibreCentral"
        Public Shared Function consultarCalibreCentral(ByVal objConexion As objCon) As DataTable
            Dim daoNotas As New DAONotasEnfermeria()
            Return daoNotas.consultarCalibreCentral(objConexion)
        End Function
#End Region
#Region "consultarCalibrePeriferica"
        Public Shared Function consultarCalibrePeriferica(ByVal objConexion As objCon) As DataTable
            Dim daoNotas As New DAONotasEnfermeria()
            Return daoNotas.consultarCalibrePeriferica(objConexion)
        End Function
#End Region
#Region "consultarCalibreArterial"
        Public Shared Function consultarCalibreArterial(ByVal objConexion As objCon) As DataTable
            Dim daoNotas As New DAONotasEnfermeria()
            Return daoNotas.consultarCalibreArterial(objConexion)
        End Function
#End Region
#Region "consultarherida"
        Public Shared Function consultarherida(ByVal objConexion As objCon) As DataTable
            Dim daoNotas As New DAONotasEnfermeria()
            Return daoNotas.consultarherida(objConexion)
        End Function
#End Region
#Region "Reporte Heridas"
        Public Shared Function ReporteHeridas(ByVal objConexion As objCon, ByVal dNumeroHistoria As Double, ByVal strFechaIni As Nullable(Of Date), ByVal strFechaFin As Nullable(Of Date), ByVal iHoraIni As Nullable(Of Integer), ByVal iHoraFin As Nullable(Of Integer)) As DataTable

            Dim obj As New Sophia.HistoriaClinica.DAO.DAOGeneral
            Dim lerror As Long

            Return obj.EjecutarSPConParametros("HCENF_ReporteHerida", objConexion, lerror, dNumeroHistoria, strFechaIni, strFechaFin, iHoraIni, iHoraFin)
        End Function
#End Region
#Region "consultarColorExudado"
        Public Shared Function consultarColorExudado(ByVal objConexion As objCon) As DataTable
            Dim daoNotas As New DAONotasEnfermeria()
            Return daoNotas.consultarColorExudado(objConexion)
        End Function
#End Region
#Region "consultarCantidadExudado"
        Public Shared Function consultarCantidadExudado(ByVal objConexion As objCon) As DataTable
            Dim daoNotas As New DAONotasEnfermeria()
            Return daoNotas.consultarCantidadExudado(objConexion)
        End Function
#End Region
#Region "HeridaEnGrilla"
        Public Shared Function HeridaEnGrilla(ByVal objConexion As objCon) As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAONotasEnfermeria
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia
            Dim daoNotas As New DAONotasEnfermeria()
            Return daoNotas.HeridaEnGrilla(objConexion, objP.CodHistoria)
        End Function
#End Region
#Region "HeridaEnSegGrilla"
        Public Shared Function HeridaEnSegGrilla(ByVal objConexion As objCon, ByVal ConsecutivoSeg As Integer) As DataTable
            Dim obj As New Sophia.HistoriaClinica.DAO.DAONotasEnfermeria
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia
            Dim daoNotas As New DAONotasEnfermeria()
            Return daoNotas.HeridaEnSegGrilla(objConexion, objP.CodHistoria, ConsecutivoSeg)
        End Function
#End Region
#Region "ValSeaNumero"
        Public Function ValSeaNumero(ByVal campo As String) As Boolean
            Dim er As New System.Text.RegularExpressions.Regex("^[0-9]+$")
            Return (er.IsMatch(campo))
        End Function
#End Region
#Region "GrabarHerida"
        Public Function GrabarHerida(ByVal objConexion As objCon, _
                        ByVal datmskDigFecha As Date, _
                        ByVal strtxtDigHora As String, _
                        ByVal strtxtDigMinutos As String, _
                        ByVal intcmbLocHeras As Integer, _
                        ByVal inttxtEdaHerCan As Integer, _
                        ByVal strcmbEdaHer As String, _
                        ByVal inttxtLongitud As Decimal, _
                        ByVal inttxtAncho As Decimal, _
                        ByVal inttxtProfundidad As Decimal, _
                        ByVal inttxtCavitaciones As Nullable(Of Decimal), _
                        ByVal inttxtFistula As Nullable(Of Decimal), _
                        ByVal strcmbForma As String, _
                        ByVal strchkEpidermis As String, _
                        ByVal strchkDermis As String, _
                        ByVal strchkTCS As String, _
                        ByVal strchkMusculo As String, _
                        ByVal strchkFascia As String, _
                        ByVal strchkOrgano As String, _
                        ByVal strchkTejNecSec As String, _
                        ByVal strchkTejNecHum As String, _
                        ByVal strchkConMenFib As String, _
                        ByVal strchkTejGra As String, _
                        ByVal strchkTejEpi As String, _
                        ByVal strcmbTraumatica As String, _
                        ByVal strcmbQuirurgica As String, _
                        ByVal strcmbMetabolicas As String, _
                        ByVal strcmbVasculares As String, _
                        ByVal strcmbDermatologicas As String, _
                        ByVal intcmbColExu As Integer, _
                        ByVal intcmbCanExu As Integer, _
                        ByVal strchkSigDolor As String, _
                        ByVal strchkSigCalor As String, _
                        ByVal strchkSigEdema As String, _
                        ByVal strchkSigOloFet As String, _
                        ByVal strchkSigRubor As String, _
                        ByVal strchkSigTumefaccion As String, _
                        ByVal strchkPieCal As String, _
                        ByVal strchkPieDes As String, _
                        ByVal strchkPieEde As String, _
                        ByVal strchkPieEpi As String, _
                        ByVal strchkPieEri As String, _
                        ByVal strchkPieInt As String, _
                        ByVal strchkPieMac As String, _
                        ByVal strchkPiePal As String, _
                        ByVal strchkPieNeo As String, _
                        ByVal strchkPieTum As String, _
                        ByVal strtxtProIns As String) As Long

            Dim obj As New Sophia.HistoriaClinica.DAO.DAONotasEnfermeria
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia
            Dim lError As Long
            lError = obj.GrabarHerida(objConexion, objP.CodHistoria, _
                                  datmskDigFecha, strtxtDigHora, strtxtDigMinutos, _
                                  intcmbLocHeras, inttxtEdaHerCan, strcmbEdaHer, _
                                  inttxtLongitud, inttxtAncho, inttxtProfundidad, inttxtCavitaciones, _
                                  inttxtFistula, strcmbForma, strchkEpidermis, _
                                  strchkDermis, strchkTCS, strchkMusculo, strchkFascia, strchkOrgano, _
                                  strchkTejNecSec, strchkTejNecHum, strchkConMenFib, strchkTejGra, strchkTejEpi, _
                                  strcmbTraumatica, strcmbQuirurgica, _
                                  strcmbMetabolicas, strcmbVasculares, strcmbDermatologicas, _
                                  intcmbColExu, intcmbCanExu, _
                                  strchkSigDolor, strchkSigCalor, strchkSigEdema, _
                                  strchkSigOloFet, strchkSigRubor, strchkSigTumefaccion, _
                                  strchkPieCal, strchkPieDes, strchkPieEde, _
                                  strchkPieEpi, strchkPieEri, strchkPieInt, _
                                  strchkPieMac, strchkPiePal, strchkPieNeo, _
                                  strchkPieTum, strtxtProIns, objG.Login)
            Return lError
        End Function
#End Region
#Region "GrabarEvolucionH"
        Public Function GrabarEvolucionH(ByVal objConexion As objCon, ByVal HistoriaSeg As Double, ByVal datDigmskDigFechaSeg As Date, _
                             ByVal strtxtDigHoraSeg As Integer, ByVal strtxtDigMinutosSeg As Integer, ByVal ConsecutivoSeg As Integer, _
                             ByVal strHerEvo As String) As Long
            Dim obj As New Sophia.HistoriaClinica.DAO.DAONotasEnfermeria
            Dim objG As objGeneral = objGeneral.Instancia
            Dim objP As objPaciente = objPaciente.Instancia
            Dim lError As Long
            lError = obj.GrabarEvolucionH(objConexion, HistoriaSeg, datDigmskDigFechaSeg, strtxtDigHoraSeg, _
                       strtxtDigMinutosSeg, ConsecutivoSeg, strHerEvo, objG.Login)
            Return lError
            Return lError
        End Function
#End Region
#Region "ValNoContCom"
        Public Function ValNoContCom(ByVal campo As String) As Boolean
            Dim er As New System.Text.RegularExpressions.Regex("(^[^']+$)")
            Return (er.IsMatch(campo))
        End Function
#End Region

#Region "consultarTiposEstFinal"
        Public Shared Function consultarTiposEstFinal(ByVal objConexion As objCon) As DataTable
            Dim daoNotasEnfermeria As New DAONotasEnfermeria()

            Return daoNotasEnfermeria.consultarTiposEstFinal(objConexion)
        End Function
#End Region
    End Class
#End Region

End Namespace
