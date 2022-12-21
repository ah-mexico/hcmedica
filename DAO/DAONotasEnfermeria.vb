Imports System

Imports objComun = HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports objDatosGenerales = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion

Namespace Sophia.HistoriaClinica.DAO
    Public Class DAONotasEnfermeria
        Inherits GPMData

#Region "ConsultarGenero"
        Public Function consultarGenero(ByVal objConexion As objCon) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("select sexo, descripcion from gensexo with(nolock)", CommandType.Text)
            dtTable = Me.execDT()

            Return dtTable
        End Function
#End Region

#Region "ConsultarGeneroRn"

        Public Function consultarGeneroRn(ByVal objConexion As objCon, ByVal strTipDocRn As String, ByVal strNumDocRn As String) As String
            Dim strGeneroRn As String

            Me.setSQLSentence("SELECT sexo from genpacie (nolock)WHERE tip_doc = '" & strTipDocRn & "' and num_doc = '" & strNumDocRn & "'", CommandType.Text)
            strGeneroRn = Me.executeScalar

            Return strGeneroRn
        End Function
#End Region

#Region "Grabar Recien Nacido"
        Public Function GrabarNacimiento(ByVal objConexion As objCon, ByVal dNumeroHistoria As Double, _
            ByVal intmanilla As Integer, ByVal dteFecha As String, ByRef intHoraNac As Integer, ByRef intMinNac As Integer, _
            ByVal strSexo As String, ByVal intPeso As Integer, ByVal intTalla As Decimal, ByVal intCefalico As Decimal, _
            ByVal intToracico As Decimal, ByVal intAbdominal As Decimal, ByVal intApgarNac As Integer, _
            ByVal intApgarMin As Integer, ByVal intApgar10Min As Integer, ByVal strvacBCG As String, _
            ByVal strVacAHB As String, ByVal strUmbilical As String, _
            ByVal strOcular As String, ByVal strVitaminaK As String, ByVal strHemo As String, _
            ByVal strCondicion As String, ByVal strLogin As String) As Long

            Dim lError As Long

            Me.setSQLSentence("HCEnf_GrabarNacimiento", CommandType.StoredProcedure)

            Me.addInputParameter("intCodhistoria", SqlDbType.Int, dNumeroHistoria)
            Me.addInputParameter("intManilla", SqlDbType.Int, intmanilla)

            Me.addInputParameter("dteFecha", SqlDbType.SmallDateTime, dteFecha)
            Me.addInputParameter("intHoraNac", SqlDbType.VarChar, intHoraNac)
            Me.addInputParameter("intMinNac", SqlDbType.VarChar, intMinNac)
            Me.addInputParameter("strSexo", SqlDbType.VarChar, strSexo)

            Me.addInputParameter("intPeso", SqlDbType.Int, intPeso)
            Me.addInputParameter("intTalla", SqlDbType.Decimal, intTalla)
            Me.addInputParameter("intCefalico", SqlDbType.Decimal, intCefalico)
            Me.addInputParameter("intToracico", SqlDbType.Decimal, intToracico)
            Me.addInputParameter("intAbdominal", SqlDbType.Decimal, intAbdominal)
            Me.addInputParameter("intApgarNac", SqlDbType.Int, intApgarNac)
            Me.addInputParameter("intApgarMin", SqlDbType.Int, intApgarMin)
            Me.addInputParameter("intApgar10Min", SqlDbType.Int, intApgar10Min)

            Me.addInputParameter("strvacBCG", SqlDbType.VarChar, strvacBCG)
            Me.addInputParameter("strVacAHB", SqlDbType.VarChar, strVacAHB)
            Me.addInputParameter("strUmbilical", SqlDbType.VarChar, strUmbilical)
            Me.addInputParameter("strOcular", SqlDbType.VarChar, strOcular)
            Me.addInputParameter("strVitaminaK", SqlDbType.VarChar, strVitaminaK)
            Me.addInputParameter("strHemo", SqlDbType.VarChar, strHemo)
            Me.addInputParameter("strCondicion", SqlDbType.VarChar, strCondicion)
            Me.addInputParameter("strlogin", SqlDbType.VarChar, strLogin)
            Me.addOutputParameter("lError", SqlDbType.Int)

            Me.Exec()

            lError = Val(Me.Parameters("lError").Value)
            Return lError

        End Function
#End Region

#Region "ModificarRecienNacido"
        Public Function ModificarRecienNacido(ByVal objConexion As objCon, ByVal dNumeroHistoria As Double, _
                                              ByVal intmanilla As Integer, ByVal strHemo As String, _
                                              ByVal strLogin As String) As Long

            Dim lError As Long

            Me.setSQLSentence("HCEnf_ModificarRecienNacido", CommandType.StoredProcedure)

            Me.addInputParameter("@intCodhistoria", SqlDbType.Int, dNumeroHistoria)
            Me.addInputParameter("@intManilla", SqlDbType.Int, intmanilla)
            Me.addInputParameter("@strHemo", SqlDbType.VarChar, strHemo)
            Me.addInputParameter("@strlogin", SqlDbType.VarChar, strLogin)
            Me.addOutputParameter("lError", SqlDbType.Int)

            Me.Exec()

            lError = Val(Me.Parameters("lError").Value)
            Return lError

        End Function
#End Region
#Region "Grabar Evaluacion Posterior"
        Public Function GrabarEvaluacionPost(ByVal objConexion As objCon, ByVal dNumeroHistoria As Double, _
            ByVal intManilla As Integer, ByVal dteFecha As String, ByVal strHora As String, ByVal strMin As String, _
            ByRef intFR As String, ByVal intFC As String, ByVal intTemp As String, ByVal intSat As String, _
            ByVal intGlucom As String, ByVal strSuccion As String, ByVal strDiuresis As String, _
            ByVal strDeposicion As String, ByVal strViaoral As String, ByVal strObs As String, ByVal strLogin As String) As Long

            Dim lError As Long

            If intTemp = "" Then
                intTemp = 0

            End If
            Me.setSQLSentence("HCEnf_GrabarEvaluacionPost", CommandType.StoredProcedure)
            Me.addInputParameter("intCodhistoria", SqlDbType.Int, dNumeroHistoria)
            Me.addInputParameter("intManilla", SqlDbType.Int, intManilla)
            Me.addInputParameter("dteFecha", SqlDbType.SmallDateTime, dteFecha)
            Me.addInputParameter("strhora_EP", SqlDbType.VarChar, strHora)
            Me.addInputParameter("strmin_EP", SqlDbType.VarChar, strMin)
            Me.addInputParameter("intFR", SqlDbType.VarChar, intFR)
            Me.addInputParameter("intFC", SqlDbType.VarChar, intFC)
            Me.addInputParameter("intTemp", SqlDbType.VarChar, intTemp)
            Me.addInputParameter("intSat", SqlDbType.VarChar, intSat)
            Me.addInputParameter("intGlucom", SqlDbType.VarChar, intGlucom)
            Me.addInputParameter("strSuccion", SqlDbType.VarChar, strSuccion)
            Me.addInputParameter("strDiuresis", SqlDbType.VarChar, strDiuresis)
            Me.addInputParameter("strDeposicion", SqlDbType.VarChar, strDeposicion)
            Me.addInputParameter("strViaoral", SqlDbType.VarChar, strViaoral)
            Me.addInputParameter("strObs", SqlDbType.VarChar, strObs)
            Me.addInputParameter("strlogin", SqlDbType.VarChar, strLogin)
            Me.addOutputParameter("lError", SqlDbType.Int)

            Me.Exec()

            lError = Val(Me.Parameters("lError").Value)
            Return lError

        End Function
#End Region
#Region "ConsultarNotasEvolucion"
        Public Function ConsultarNotasEvolucion(ByVal objConexion As objCon, ByVal dNumeroHistoria As Integer, _
        ByRef dtNotasEvolucion As DataTable) As Long

            Dim lError As Long

            Me.setSQLSentence("HCEnf_ConsultarNotasEvolucion", CommandType.StoredProcedure)

            Me.addInputParameter("@intCodhistoria", SqlDbType.Int, dNumeroHistoria)
            Me.addOutputParameter("lError", SqlDbType.Int)

            dtNotasEvolucion = Me.execDT()

            lError = Val(Me.Parameters("lError").Value)
            Return lError

        End Function
#End Region
#Region "ConsultarGruposNotasEvolucion"
        Public Function ConsultarGruposNotasEvolucion(ByVal objConexion As objCon, ByVal dNumeroHistoria As Integer, _
        ByRef dtNotasEvolucion As DataTable) As Long

            Dim lError As Long

            Me.setSQLSentence("HCEnf_ConsultarGruposNotasEvolucion", CommandType.StoredProcedure)

            Me.addOutputParameter("lError", SqlDbType.Int)

            dtNotasEvolucion = Me.execDT()

            lError = Val(Me.Parameters("lError").Value)
            Return lError

        End Function
#End Region
#Region "GrabarEvolucion"
        Public Function GrabarEvolucion(ByVal objConexion As objCon, ByVal dNumeroHistoria As Integer, _
            ByVal strLogin As String, ByRef iConsecutivo As Integer, ByVal sNotaEvolucion As String, ByVal fecha As DateTime, ByVal hora As String, ByVal minuto As String) As Long

            Dim lError As Long


            Me.setSQLSentence("HC_GrabarEvolucionEnfermeria", CommandType.StoredProcedure)

            Me.addInputParameter("@intCodhistoria", SqlDbType.Int, dNumeroHistoria)
            Me.addInputParameter("@strNotaEvolucion", SqlDbType.VarChar, sNotaEvolucion)
            Me.addInputParameter("@fecha", SqlDbType.DateTime, fecha)
            Me.addInputParameter("@hora_evolucion", SqlDbType.VarChar, hora)
            Me.addInputParameter("@min_evolucion", SqlDbType.VarChar, minuto)
            Me.addInputParameter("@strlogin", SqlDbType.VarChar, strLogin)
            Me.addOutputParameter("lError", SqlDbType.Int)

            Try
                Me.BeginTransaction()
                Me.Exec()
                Me.Commit()
                lError = Val(Me.Parameters("lError").Value)
                Return lError

            Catch ex As Exception
                lError = -1
                Me.Rollback()
                Return lError
            End Try


        End Function
#End Region


#Region "GrabarEvolucionH"
        Public Function GrabarEvolucionH(ByVal objConexion As objCon, ByVal HistoriaSeg As Double, _
                   ByVal datmskDigFechaSeg As Date, ByVal strtxtDigHoraSeg As Integer, _
                   ByVal strtxtDigMinutosSeg As Integer, ByVal ConsecutivoSeg As Integer, _
                   ByRef strHerEvo As String, ByRef LoginSeg As String) As Long


            Dim lError As Long
            Me.setSQLSentence("[HCEnf_GrabarSegHerida]", CommandType.StoredProcedure)
            Me.addInputParameter("@dNumeroHistoria", SqlDbType.Int, HistoriaSeg)
            Me.addInputParameter("@ConsecutivoSeg", SqlDbType.VarChar, ConsecutivoSeg)
            Me.addInputParameter("@strHerEvo", SqlDbType.VarChar, strHerEvo)
            Me.addInputParameter("@datmskDigFechaSeg", SqlDbType.DateTime, datmskDigFechaSeg)
            Me.addInputParameter("@strtxtDigHoraSeg", SqlDbType.Int, strtxtDigHoraSeg)
            Me.addInputParameter("@strtxtDigMinutosSeg", SqlDbType.Int, strtxtDigMinutosSeg)
            Me.addInputParameter("@strLogin", SqlDbType.VarChar, LoginSeg)
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()
            lError = Val(Me.Parameters("lError").Value)
            Return lError
        End Function
#End Region

        '#Region "GrabarEvolucionH"
        '        Public Function GrabarEvolucionH(ByVal objConexion As objCon, ByVal HistoriaSeg As Double, _
        '                   ByVal datmskDigFechaSeg As Date, ByVal strtxtDigHoraSeg As String, _
        '                   ByVal strtxtDigMinutosSeg As String, ByVal ConsecutivoSeg As Integer, _
        '                   ByRef strHerEvo As String, ByRef LoginSeg As String) As Long


        '            Dim lError As Long
        '            Me.setSQLSentence("[HCEnf_GrabarSegHerida]", CommandType.StoredProcedure)
        '            Me.addInputParameter("@dNumeroHistoria", SqlDbType.Int, HistoriaSeg)
        '            Me.addInputParameter("@ConsecutivoSeg", SqlDbType.VarChar, ConsecutivoSeg)
        '            Me.addInputParameter("@strHerEvo", SqlDbType.VarChar, strHerEvo)
        '            Me.addInputParameter("@datmskDigFechaSeg", SqlDbType.DateTime, datmskDigFechaSeg)
        '            Me.addInputParameter("@strtxtDigHoraSeg", SqlDbType.VarChar, strtxtDigHoraSeg)
        '            Me.addInputParameter("@strtxtDigMinutosSeg", SqlDbType.VarChar, strtxtDigMinutosSeg)
        '            Me.addInputParameter("@strLogin", SqlDbType.VarChar, LoginSeg)
        '            Me.addOutputParameter("lError", SqlDbType.Int)
        '            Me.Exec()
        '            lError = Val(Me.Parameters("lError").Value)
        '            Return lError
        '        End Function
        '#End Region
#Region "ConsultarParametros"
        Public Function consultarParametros(ByVal objConexion As objCon, ByVal cod_grupoparametricas As Integer) As DataTable
            Dim dtTable As DataTable
            'Me.addInputParameter("@intDestino", SqlDbType.Int, 1)
            Me.setSQLSentence("select [cod_parametricas] ,[desc_parametricas] ,[fec_con] ,[login] ,[obs]  FROM [hcenftipoparametricas] with(nolock) where cod_grupoparametricas = " & cod_grupoparametricas, CommandType.Text)
            dtTable = Me.execDT()

            Return dtTable
        End Function
#End Region
#Region "GrabarParametros"
        Public Function GrabarParametros(ByVal objConexion As objCon, ByVal dNumeroHistoria As Double, _
            ByVal strLogin As String, ByVal ParametrosChecked As ArrayList, ByRef Consecutivo As Integer, ByVal Fecha As DateTime, ByVal Hora As String, ByVal Minuto As String) As Long

            Dim lError As Long

            Me.setSQLSentence("HC_GrabarParametrosEnfermeria", CommandType.StoredProcedure)

            Me.addInputParameter("@intDestino", SqlDbType.Int, 1)
            Me.addInputParameter("@intCodhistoria", SqlDbType.Int, CInt(dNumeroHistoria))
            Me.addInputParameter("@intConsecutivo", SqlDbType.Int, 0)
            Me.addInputParameter("@fecha", SqlDbType.DateTime, Fecha)
            Me.addInputParameter("@hora_parametrica", SqlDbType.VarChar, Hora)
            Me.addInputParameter("@min_parametrica", SqlDbType.VarChar, Minuto)

            Me.addInputParameter("@strlogin", SqlDbType.VarChar, strLogin)
            Me.addInputParameter("@cod_parametricas", SqlDbType.Int, 0)
            Me.addInputParameter("@cod_grupoparametricas", SqlDbType.Int, 0)
            Me.addOutputParameter("intConsecutivoOUT", SqlDbType.Int)
            Me.addOutputParameter("lError", SqlDbType.Int)

            Try
                Me.BeginTransaction()
                Me.Exec()

                Consecutivo = Me.Parameters("intConsecutivoOUT").Value

                For i As Integer = 0 To ParametrosChecked.Count - 1

                    Me.ClearParameters()
                    'Me.setSQLSentence("HC_GrabarParametrosEnfermeria", CommandType.StoredProcedure)

                    Me.addInputParameter("@intDestino", SqlDbType.Int, 2)
                    Me.addInputParameter("@intCodhistoria", SqlDbType.Int, CInt(dNumeroHistoria))
                    Me.addInputParameter("@intConsecutivo", SqlDbType.Int, Consecutivo)
                    Me.addInputParameter("@fecha", SqlDbType.DateTime, Fecha)
                    Me.addInputParameter("@hora_parametrica", SqlDbType.VarChar, Hora)
                    Me.addInputParameter("@min_parametrica", SqlDbType.VarChar, Minuto)

                    Me.addInputParameter("@strlogin", SqlDbType.VarChar, strLogin)
                    Me.addInputParameter("@cod_parametricas", SqlDbType.Int, CInt(ParametrosChecked(i).ToString().Split(New [Char]() {"|"c})(0)))
                    Me.addInputParameter("@cod_grupoparametricas", SqlDbType.Int, CInt(ParametrosChecked(i).ToString().Split(New [Char]() {"|"c})(1)))
                    Me.addOutputParameter("intConsecutivoOUT", SqlDbType.Int)
                    Me.addOutputParameter("lError", SqlDbType.Int)
                    Me.Exec()
                Next

                Me.Commit()

                lError = Val(Me.Parameters("lError").Value)
                Return lError
            Catch ex As Exception
                lError = Val(Me.Parameters("lError").Value)
                Me.Rollback()
                Return lError
            End Try

        End Function
#End Region
#Region "ConsultarIndicacion"
        Public Function consultarIndicacion(ByVal objConexion As objCon) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("select cod_indicacion, desc_indicacion from hcenftipoindicacion with(nolock)", CommandType.Text)
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region
#Region "ConsultarComplicacion"
        Public Function consultarComplicacion(ByVal objConexion As objCon) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("select cod_complicacion, desc_complicacion from hcenftipocomplicacion with(nolock)", CommandType.Text)
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region
#Region "ConsultarElementosUsados"
        Public Function consultarElementosUsados(ByVal objConexion As objCon) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("select cod_elemenusu, desc_elemenusu from hcenftipoelemenusu with(nolock)", CommandType.Text)
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region
#Region "consultarTipocateter"
        Public Function consultarTipocateter(ByVal objConexion As objCon) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("select cod_tipocateter, desc_tipocateter from hcenftipocateter with(nolock)", CommandType.Text)
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region
#Region "consultarEstadoInsercion"
        Public Function consultarEstadoInsercion(ByVal objConexion As objCon) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("select cod_estadoinsercion, desc_estadoinsercion from hcenfestadoinsercion with(nolock)", CommandType.Text)
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region
#Region "consultarCausaRetiro"
        Public Function consultarCausaRetiro(ByVal objConexion As objCon) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("select cod_causaretiro, desc_causaretiro from hcenfcausaretiro with(nolock)", CommandType.Text)
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region
#Region "consultarSitioInserccion"
        Public Function consultarSitioInserccion(ByVal objConexion As objCon) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("select cod_sitioinsercion, desc_sitioinsercion from hcenfsitioinsercion with(nolock)", CommandType.Text)
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region
#Region "consultarTecnicaInserccion"
        Public Function consultarTecnicaInserccion(ByVal objConexion As objCon) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("select cod_tecinsercion, desc_tecinsercion from hcenftecinsercion with(nolock)", CommandType.Text)
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region
#Region "ConsultarDataGridViewInserccionDAO"
        Public Function ConsultarDataGridViewInserccionDAO(ByVal objConexion As objCon, ByVal dNumeroHistoria As Integer, ByRef dt As DataTable) As Long
            Dim lError As Long
            Me.setSQLSentence("HCENF_GrillaInsercciom", CommandType.StoredProcedure)
            Me.addInputParameter("@intCodhistoria", SqlDbType.Int, dNumeroHistoria)
            Me.addOutputParameter("lError", SqlDbType.Int)
            dt = Me.execDT()
            lError = Val(Me.Parameters("lError").Value)
            Return lError
        End Function
#End Region
#Region "ConsultarGrillaBuscarFuncionario"
        Public Function ConsultarGrillaBuscarFuncionario(ByVal objConexion As objCon, ByVal Nombre As String, ByVal Apellido As String, ByRef dt As DataTable) As Long
            Dim lError As Long
            Me.setSQLSentence("HCENF_consultafuncionario", CommandType.StoredProcedure)
            Me.addInputParameter("@strnombre", SqlDbType.VarChar, Nombre)
            Me.addInputParameter("@strapellido", SqlDbType.VarChar, Apellido)
            Me.addOutputParameter("lError", SqlDbType.Int)
            dt = Me.execDT()
            lError = Val(Me.Parameters("lError").Value)
            Return lError
        End Function
#End Region
#Region "ValidarGrillaSeguimientoDAO"
        Public Function ValidarGrillaSeguimientoDAO(ByVal objConexion As objCon, ByVal dNumeroHistoria As Integer, ByRef dt As DataTable) As Long
            Dim lError As Long
            Me.setSQLSentence("HCENF_ValidarSeguimiento", CommandType.StoredProcedure)
            Me.addInputParameter("@intCodhistoria", SqlDbType.Int, dNumeroHistoria)
            Me.addOutputParameter("lError", SqlDbType.Int)
            dt = Me.execDT()
            lError = Val(Me.Parameters("lError").Value)
            Return lError
        End Function
#End Region
#Region "ConsultarGrillaSeguimientoEstadoDAO"
        Public Function ConsultarGrillaSeguimientoEstadoDAO(ByVal objConexion As objCon, ByVal dNumeroHistoria As Integer, ByRef dt As DataTable) As Long
            Dim lError As Long
            Me.setSQLSentence("HENF_GrillaSeguimientoEstado", CommandType.StoredProcedure)
            Me.addInputParameter("@intCodhistoria", SqlDbType.Int, dNumeroHistoria)
            Me.addOutputParameter("lError", SqlDbType.Int)
            dt = Me.execDT()
            lError = Val(Me.Parameters("lError").Value)
            Return lError
        End Function
#End Region
#Region "ConsultarGrillaDatosRetiradosDAO"
        Public Function ConsultarGrillaDatosRetiradosDAO(ByVal objConexion As objCon, ByVal dNumeroHistoria As Integer, ByRef dt As DataTable) As Long
            Dim lError As Long
            Me.setSQLSentence("HENF_GrillaRetiradoCateter", CommandType.StoredProcedure)
            Me.addInputParameter("@intCodhistoria", SqlDbType.Int, dNumeroHistoria)
            Me.addOutputParameter("lError", SqlDbType.Int)
            dt = Me.execDT()
            lError = Val(Me.Parameters("lError").Value)
            Return lError
        End Function
#End Region
#Region "ValidarGrillaRetiroDAO"
        Public Function ValidarGrillaRetiroDAO(ByVal objConexion As objCon, ByVal dNumeroHistoria As Integer, ByRef dt As DataTable) As Long
            Dim lError As Long
            Me.setSQLSentence("HCENF_ValidarRetiro", CommandType.StoredProcedure)
            Me.addInputParameter("@intCodhistoria", SqlDbType.Int, dNumeroHistoria)
            Me.addOutputParameter("lError", SqlDbType.Int)
            dt = Me.execDT()
            lError = Val(Me.Parameters("lError").Value)
            Return lError
        End Function
#End Region
#Region "consultarCalibreCentral"
        Public Function consultarCalibreCentral(ByVal objConexion As objCon) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("select DISTINCT cod_vianser, num_Calibre from hcenfCalibre with(nolock) where cod_vianser = 'C'", CommandType.Text)
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region
#Region "consultarCalibrePeriferica"
        Public Function consultarCalibrePeriferica(ByVal objConexion As objCon) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("select DISTINCT cod_vianser, num_Calibre from hcenfCalibre with(nolock) where cod_vianser = 'P'", CommandType.Text)
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region
#Region "consultarCalibreArterial"
        Public Function consultarCalibreArterial(ByVal objConexion As objCon) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("select DISTINCT cod_vianser,num_Calibre from hcenfCalibre with(nolock) where cod_vianser <> 'T'", CommandType.Text)
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region
#Region "GrabarCateter"
        Public Function GrabarCateter(ByVal objConexion As objCon, ByVal dNumeroHistoria As Integer, ByVal strTipoCateter As String, _
            ByVal fdtFecha As DateTime, ByVal strhora_cateter As String, ByVal strmin_cateter As String, ByVal intcalibre As Integer, _
            ByVal strluzcateter As String, ByVal strviainscentral As Boolean, ByVal strviainsPeriferica As Boolean, ByVal strviainsArterial As Boolean, ByVal strlateralidad_izquierda As Boolean, _
            ByVal strlateralidad_derecha As Boolean, ByVal intsitioinsercion As Integer, ByVal inttecinsercion As Integer, ByVal strnumpuntuacion As String, _
            ByVal strcontrolradio_si As Boolean, ByVal strcontrolradio_no As Boolean, ByVal strlocalizacion As String, _
            ByVal chklsIndicacion As Array, ByVal strComplicacion_Si As Boolean, ByVal strComplicacion_No As Boolean, ByVal chklsComplicacion As Array, ByVal strpers_cateter As String, ByVal login As String, ByVal ArrayComplicacion As Array, ByVal ArrayIndicacion As Array) As Long
            Dim lError As Long
            Me.setSQLSentence("HCENF_insertcateter", CommandType.StoredProcedure)
            Me.addInputParameter("@intCodhistoria", SqlDbType.Int, dNumeroHistoria)
            Me.addInputParameter("@intcod_tipocateter", SqlDbType.Int, strTipoCateter)
            Me.addInputParameter("@fdtfecha", SqlDbType.DateTime, fdtFecha)
            Me.addInputParameter("@strhora_cateter", SqlDbType.VarChar, strhora_cateter)
            Me.addInputParameter("@strmin_cateter", SqlDbType.VarChar, strmin_cateter)
            Me.addInputParameter("@intcalibre", SqlDbType.Decimal, intcalibre)
            Me.addInputParameter("@strluzcateter", SqlDbType.VarChar, strluzcateter)
            If strviainscentral = True Then
                Me.addInputParameter("@strviainsercion", SqlDbType.VarChar, "Central")
            ElseIf strviainsPeriferica = True Then
                Me.addInputParameter("@strviainsercion", SqlDbType.VarChar, "Periferica")
            ElseIf strviainsArterial = True Then
                Me.addInputParameter("@strviainsercion", SqlDbType.VarChar, "Arterial")
            End If
            If strlateralidad_izquierda = True Then
                Me.addInputParameter("@strlateralidad", SqlDbType.VarChar, "Izquierda")
            ElseIf strlateralidad_derecha = True Then
                Me.addInputParameter("@strlateralidad", SqlDbType.VarChar, "Derecha")
            End If
            Me.addInputParameter("@intcod_sitioinsercion", SqlDbType.Int, intsitioinsercion)
            Me.addInputParameter("@intcod_tecinsercion", SqlDbType.Int, inttecinsercion)
            Me.addInputParameter("@strnumpuntuacion", SqlDbType.VarChar, strnumpuntuacion)
            If Not strcontrolradio_si = False Then
                Me.addInputParameter("@strcontrolradio", SqlDbType.VarChar, "Si")
            ElseIf Not strcontrolradio_no = False Then
                Me.addInputParameter("@strcontrolradio", SqlDbType.VarChar, "No")
            Else
                Me.addInputParameter("@strcontrolradio", SqlDbType.VarChar, "")
            End If
            Me.addInputParameter("@strlocalizacion", SqlDbType.VarChar, strlocalizacion)

            If strComplicacion_Si = True Then
                Me.addInputParameter("@strcomplicacion", SqlDbType.VarChar, "Si")
            ElseIf strComplicacion_No = True Then
                Me.addInputParameter("@strcomplicacion", SqlDbType.VarChar, "No")
            Else
                Me.addInputParameter("@strcomplicacion", SqlDbType.VarChar, "Si")
            End If
            Me.addInputParameter("@strpers_catater", SqlDbType.VarChar, strpers_cateter)
            Me.addInputParameter("@strLogin", SqlDbType.VarChar, login)
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.addOutputParameter("intConsecutivoOut", SqlDbType.Int)
            Me.Exec()
            Dim intConsecutivo As Integer = Val(Me.Parameters("intConsecutivoOut").Value)
            lError = Val(Me.Parameters("lError").Value)
            For i As Integer = 0 To ArrayComplicacion.Length - 1
                GrabarComplicacion(objConexion, dNumeroHistoria, intConsecutivo, ArrayComplicacion(i))
            Next

            lError = Val(Me.Parameters("lError").Value)
            For i As Integer = 0 To ArrayIndicacion.Length - 1
                GrabarIndicacion(objConexion, dNumeroHistoria, intConsecutivo, ArrayIndicacion(i))
            Next
            Return lError
        End Function
#End Region
#Region "GrabarComplicacion"
        Public Function GrabarComplicacion(ByVal objConexion As objCon, ByVal dNumeroHistoria As Integer, _
        ByVal dConsecutivo As Integer, ByVal dCod_Complicacion As Integer) As Long
            Dim lError As Long
            Me.setSQLSentence("HCENF_insertcomplicacion", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("@intCodhistoria", SqlDbType.Int, dNumeroHistoria)
            Me.addInputParameter("@intConsecutivo", SqlDbType.Int, dConsecutivo)
            Me.addInputParameter("@intcod_complicacion", SqlDbType.Int, dCod_Complicacion)
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()
            lError = Val(Me.Parameters("lError").Value)
            Return lError
        End Function
#End Region
#Region "GrabarIndicacion"
        Public Function GrabarIndicacion(ByVal objConexion As objCon, ByVal dNumeroHistoria As Integer, _
        ByVal dConsecutivo As Integer, ByVal dCod_Indicacion As Integer) As Long
            Dim lError As Long
            Me.setSQLSentence("HCENF_insertindicacion", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("@intCodhistoria", SqlDbType.Int, dNumeroHistoria)
            Me.addInputParameter("@intConsecutivo", SqlDbType.Int, dConsecutivo)
            Me.addInputParameter("@intcod_indicacion", SqlDbType.Int, dCod_Indicacion)
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()
            lError = Val(Me.Parameters("lError").Value)
            Return lError
        End Function
#End Region
#Region "GrabarSeguimiento"
        Public Function GrabarSeguimiento(ByVal objConexion As objCon, ByVal dNumeroHistoria As Integer, ByVal dConsecutivo As Integer, _
            ByVal fdtFecha As DateTime, ByVal strhora_seguimiento As String, ByVal strmin_seguimiento As String, ByVal intEstado_insercion As Integer, _
            ByVal strObservaciones As String, ByVal chklsElementos_Usados As Array, ByVal ArrayElementos_Usados As Array, ByVal login As String) As Long
            Dim lError As Long
            Me.setSQLSentence("HCENF_insertseguimientocateter", CommandType.StoredProcedure)
            Me.addInputParameter("@intCod_historia", SqlDbType.Int, dNumeroHistoria)
            Me.addInputParameter("@intConsecutivo", SqlDbType.Int, dConsecutivo)
            Me.addInputParameter("@fdtfecha", SqlDbType.DateTime, fdtFecha)
            Me.addInputParameter("@strhora_segcateter", SqlDbType.VarChar, strhora_seguimiento)
            Me.addInputParameter("@strmin_segcateter", SqlDbType.VarChar, strmin_seguimiento)
            Me.addInputParameter("@intcod_estadoinsercion", SqlDbType.Decimal, intEstado_insercion)
            Me.addInputParameter("@strobs", SqlDbType.VarChar, strObservaciones)
            Me.addInputParameter("@strLogin", SqlDbType.VarChar, login)
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.addOutputParameter("intConsecutivoOut", SqlDbType.Int)
            Me.Exec()
            Dim intConsecutivo As Integer = Val(Me.Parameters("intConsecutivoOut").Value)
            lError = Val(Me.Parameters("lError").Value)
            For i As Integer = 0 To ArrayElementos_Usados.Length - 1
                GrabarElementos_Usados(objConexion, dNumeroHistoria, dConsecutivo, intConsecutivo, ArrayElementos_Usados(i))
            Next
            Return lError
        End Function
#End Region
#Region "GrabarElementos_Usados"
        Public Function GrabarElementos_Usados(ByVal objConexion As objCon, ByVal dNumeroHistoria As Integer, _
        ByVal dConsecutivo As Integer, ByVal dCod_Consecutivo_seg As Integer, ByVal intcod_elementousu As Integer) As Long
            Dim lError As Long
            Me.setSQLSentence("HCENF_insertsegcateterelementousuario", CommandType.StoredProcedure)
            Me.ClearParameters()
            Me.addInputParameter("@intcod_historia", SqlDbType.Int, dNumeroHistoria)
            Me.addInputParameter("@intConsecutivo", SqlDbType.Int, dConsecutivo)
            Me.addInputParameter("@intConsecutivo_seg", SqlDbType.Int, dCod_Consecutivo_seg)
            Me.addInputParameter("@intcod_elementousu", SqlDbType.Decimal, intcod_elementousu)
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()
            lError = Val(Me.Parameters("lError").Value)
            Return lError
        End Function
#End Region
#Region "GrabarRetiroDAO"
        Public Function GrabarRetiroDAO(ByVal objConexion As objCon, ByVal dNumeroHistoria As Integer, ByVal dConsecutivo As Integer, _
            ByVal intcod_causaretiro As Integer, ByVal fdtFecha As DateTime, ByVal strhora_retiro As String, ByVal strmin_retiro As String, _
             ByVal strLogin_retiro As String) As Long
            Dim lError As Long
            Me.setSQLSentence("HCENF_UpdateRetiroCateter", CommandType.StoredProcedure)
            Me.addInputParameter("@intCod_historia", SqlDbType.Int, dNumeroHistoria)
            Me.addInputParameter("@intConsecutivo", SqlDbType.Int, dConsecutivo)
            Me.addInputParameter("@intcod_causaretiro", SqlDbType.Int, intcod_causaretiro)
            Me.addInputParameter("@fdtfecha_retiro", SqlDbType.DateTime, fdtFecha)
            Me.addInputParameter("@strhora_retiro", SqlDbType.VarChar, strhora_retiro)
            Me.addInputParameter("@strmin_retiro", SqlDbType.VarChar, strmin_retiro)
            Me.addInputParameter("@strlogin_retiro", SqlDbType.VarChar, strLogin_retiro)
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()
            lError = Val(Me.Parameters("lError").Value)
            Return lError
        End Function
#End Region
#Region "GrabarHerida"
        Public Function GrabarHerida(ByVal objConexion As objCon, _
                                            ByVal dNumeroHistoria As Double, _
                                            ByVal datmskDigFecha As Date, _
                                            ByVal strtxtDigHora As String, _
                                            ByVal strtxtDigMinutos As String, _
                                            ByVal intcmbLocHeras As Integer, _
                                            ByRef inttxtEdaHerCan As Integer, _
                                            ByRef strcmbEdaHer As String, _
                                            ByRef inttxtLongitud As Decimal, _
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
                                            ByVal strtxtProIns As String, _
                                            ByVal strLogin As String) As Long

            Dim lError As Long
            Me.setSQLSentence("HCenf_GrabarHerida", CommandType.StoredProcedure)
            Me.addInputParameter("@dNumeroHistoria", SqlDbType.Int, dNumeroHistoria)
            Me.addInputParameter("@datmskDigFecha", SqlDbType.DateTime, datmskDigFecha)
            Me.addInputParameter("@strtxtDigHora", SqlDbType.VarChar, strtxtDigHora)
            Me.addInputParameter("@strtxtDigMinutos", SqlDbType.VarChar, strtxtDigMinutos)
            Me.addInputParameter("@intcmbLocHeras", SqlDbType.Int, intcmbLocHeras)
            Me.addInputParameter("@inttxtEdaHerCan", SqlDbType.Int, inttxtEdaHerCan)
            Me.addInputParameter("@strcmbEdaHer", SqlDbType.VarChar, strcmbEdaHer)
            Me.addInputParameter("@inttxtLongitud", SqlDbType.Decimal, inttxtLongitud)
            Me.addInputParameter("@inttxtAncho", SqlDbType.Decimal, inttxtAncho)
            Me.addInputParameter("@inttxtProfundidad", SqlDbType.Decimal, inttxtProfundidad)
            Me.addInputParameter("@inttxtCavitaciones", SqlDbType.Decimal, inttxtCavitaciones)
            Me.addInputParameter("@inttxtFistula", SqlDbType.Decimal, inttxtFistula)
            Me.addInputParameter("@strcmbForma", SqlDbType.VarChar, strcmbForma)
            Me.addInputParameter("@strchkEpidermis", SqlDbType.VarChar, strchkEpidermis)
            Me.addInputParameter("@strchkDermis", SqlDbType.VarChar, strchkDermis)
            Me.addInputParameter("@strchkTCS", SqlDbType.VarChar, strchkTCS)
            Me.addInputParameter("@strchkMusculo", SqlDbType.VarChar, strchkMusculo)
            Me.addInputParameter("@strchkFascia", SqlDbType.VarChar, strchkFascia)
            Me.addInputParameter("@strchkOrgano", SqlDbType.VarChar, strchkOrgano)
            Me.addInputParameter("@strchkTejNecSec", SqlDbType.VarChar, strchkTejNecSec)
            Me.addInputParameter("@strchkTejNecHum", SqlDbType.VarChar, strchkTejNecHum)
            Me.addInputParameter("@strchkConMenFib", SqlDbType.VarChar, strchkConMenFib)
            Me.addInputParameter("@strchkTejGra", SqlDbType.VarChar, strchkTejGra)
            Me.addInputParameter("@strchkTejEpi", SqlDbType.VarChar, strchkTejEpi)
            Me.addInputParameter("@strcmbTraumatica", SqlDbType.VarChar, strcmbTraumatica)
            Me.addInputParameter("@strcmbQuirurgica", SqlDbType.VarChar, strcmbQuirurgica)
            Me.addInputParameter("@strcmbMetabolicas", SqlDbType.VarChar, strcmbMetabolicas)
            Me.addInputParameter("@strcmbVasculares", SqlDbType.VarChar, strcmbVasculares)
            Me.addInputParameter("@strcmbDermatologicas", SqlDbType.VarChar, strcmbDermatologicas)
            Me.addInputParameter("@intcmbColExu", SqlDbType.Int, intcmbColExu)
            Me.addInputParameter("@intcmbCanExu", SqlDbType.Int, intcmbCanExu)
            Me.addInputParameter("@strchkSigDolor", SqlDbType.VarChar, strchkSigDolor)
            Me.addInputParameter("@strchkSigCalor", SqlDbType.VarChar, strchkSigCalor)
            Me.addInputParameter("@strchkSigEdema", SqlDbType.VarChar, strchkSigEdema)
            Me.addInputParameter("@strchkSigOloFet", SqlDbType.VarChar, strchkSigOloFet)
            Me.addInputParameter("@strchkSigRubor", SqlDbType.VarChar, strchkSigRubor)
            Me.addInputParameter("@strchkSigTumefaccion", SqlDbType.VarChar, strchkSigTumefaccion)
            Me.addInputParameter("@strchkPieCal", SqlDbType.VarChar, strchkPieCal)
            Me.addInputParameter("@strchkPieDes", SqlDbType.VarChar, strchkPieDes)
            Me.addInputParameter("@strchkPieEde", SqlDbType.VarChar, strchkPieEde)
            Me.addInputParameter("@strchkPieEpi", SqlDbType.VarChar, strchkPieEpi)
            Me.addInputParameter("@strchkPieEri", SqlDbType.VarChar, strchkPieEri)
            Me.addInputParameter("@strchkPieInt", SqlDbType.VarChar, strchkPieInt)
            Me.addInputParameter("@strchkPieMac", SqlDbType.VarChar, strchkPieMac)
            Me.addInputParameter("@strchkPiePal", SqlDbType.VarChar, strchkPiePal)
            Me.addInputParameter("@strchkPieNeo", SqlDbType.VarChar, strchkPieNeo)
            Me.addInputParameter("@strchkPieTum", SqlDbType.VarChar, strchkPieTum)
            Me.addInputParameter("@strtxtProIns", SqlDbType.VarChar, strtxtProIns)
            Me.addInputParameter("@strLogin", SqlDbType.VarChar, strLogin)
            Me.addOutputParameter("lError", SqlDbType.Int)
            Me.Exec()
            lError = Val(Me.Parameters("lError").Value)
            Return lError
        End Function
#End Region

#Region "consultarherida"
        Public Function consultarherida(ByVal objConexion As objCon) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("select cod_localherida, desc_localherida from hcenflocalherida with(nolock)", CommandType.Text)
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region
#Region "consultarColorExudado"
        Public Function consultarColorExudado(ByVal objConexion As objCon) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("select cod_colorexudado, desc_colorexudado from hcenfcolorexudado with(nolock)", CommandType.Text)    ' larbselect
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region
#Region "consultarCantidadExudado"
        Public Function consultarCantidadExudado(ByVal objConexion As objCon) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("select cod_cantexudado, desc_cantexudado from hcenfcantexudado with(nolock)", CommandType.Text)    ' larbselect
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region
#Region "HeridaEnGrilla"
        Public Function HeridaEnGrilla(ByVal objConexion As objCon, ByVal dNumeroHistoria As Double) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("HCEnf_HeridaEnGrilla", CommandType.StoredProcedure)
            Me.addInputParameter("@dNumeroHistoria", SqlDbType.Int, dNumeroHistoria)
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region
#Region "HeridaEnSegGrilla"
        Public Function HeridaEnSegGrilla(ByVal objConexion As objCon, ByVal dNumeroHistoria As Double, ByVal ConsecutivoSeg As Integer) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("HCEnf_HeridaEnSegGrilla", CommandType.StoredProcedure)
            Me.addInputParameter("@dNumeroHistoria", SqlDbType.Int, dNumeroHistoria)
            Me.addInputParameter("@ConsecutivoSeg", SqlDbType.Int, ConsecutivoSeg)
            dtTable = Me.execDT()
            Return dtTable
        End Function

#End Region
#Region "consultarTiposEstFinal"
        Public Function consultarTiposEstFinal(ByVal objConexion As objCon) As DataTable
            Dim dtTable As DataTable
            Me.setSQLSentence("SELECT est_final,descripcion FROM genestfi (nolock)", CommandType.Text)
            dtTable = Me.execDT()
            Return dtTable
        End Function
#End Region
    End Class
End Namespace
