Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports objGenerales = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports System.Globalization
Imports System.Threading

'Ultima versi?n 11/12/2007 GGM


Public Class frmHistoriaPrincipal
    Private dblPosY As Double
    Private dblAltoControlPaciente As Double
    Public Shared objConexion As objCon.Conexion
    Public objDatosGenerales As objGeneral.Generales
    Private blnListaEsperaError As Boolean
    Public blnCtlHCBasica As Boolean = False
    Public blnCtlListaEspera As Boolean = False
    Public blnCtlDatosPaciente As Boolean = False
    Public blnCtlEgresos As Boolean = False
    Public blnCtlEvolucion As Boolean = False
    Public blnCtlOrdenesMedicas As Boolean = False
    Public blnCtlPlanFormuExterna As Boolean = False
    Public blnCtlPlanIncapacidad As Boolean = False
    Public blnCtlPlanProcExternos As Boolean = False
    Public blnCtlPlanRemision As Boolean = False
    Public blnCtlRecomEgreso As Boolean = False
    Public strNameControlLoad As String = ""
    Public blnFirstHCBasica As Boolean = True
    Public blnFirstDatosPaciente As Boolean = True
    Public blnFirstEgresos As Boolean = True
    Public blnFirstEvolucion As Boolean = True
    Public blnFirstOrdenesMedicas As Boolean = True
    Public blnFirstPlanFormuExterna As Boolean = True
    Public blnFirstPlanIncapacidad As Boolean = True
    Public blnFirstPlanProcExternos As Boolean = True
    Public blnFirstPlanRemision As Boolean = True
    Public blnFirstRecomEgreso As Boolean = True
    Public blnCtlCuidadospaliativos As Boolean = False
    Private objCP As New HistoriaClinica.Sophia.HistoriaClinica.DAO.DAOCuidadosPaliativos
    Private datosLogin As Generales

    'Req. ER_OSI_584(eloaiza@intergrupo.com )
    Public ctlPaciente As ctlDatosPaciente
    Public ctlHistoria As HCBasica
    Private datosConexion As objCon.Conexion


#Region "Enumeraciones"
    Enum OpcionesMenu
        ListaEspera
        PlanManejo
        Formulacion
        Procedimientos
        Recomendaciones
        Remision
        Incapacidad
        HistoriaClinica     ''Cuando se abre la historia clinica
        HistoriaBasica      ''Cuando se pulsa el boton del menu HistoriaBasica
        OrdenesMedicas
        Evolucion
        Egreso
        Consultas
        NotasAclaratorias
        SinOpciones = 5
        ConsultasListaEsperaError
        CuidadosPaliativos = 17
    End Enum
#End Region

    Public Const TIPOUSUARIO_MEDICO As String = "M"


    Private Sub frmHistoriaPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        datosLogin = Generales.Instancia()


        ''Contiene los argumentos de entrada al programa
        Dim strArgumentos As String = ""
        ''Xml que contiene los parametros iniciales
        Dim xmlParametrosIniciales As String = ""
        ''Manejo de errores
        Dim lError As Integer
        'Dim dtresul As DataTable
        Dim intVersion As Integer
        Dim strDescripcion As String



        'Fija el punto como separador decimal para la aplicaci?n.
        Dim Cultura As New Globalization.CultureInfo(Globalization.CultureInfo.CurrentCulture.Name)
        Cultura.NumberFormat.NumberDecimalSeparator = "."
        Cultura.DateTimeFormat.DateSeparator = "/"  ''Claudia Garay el separador de fechas debe ser /
        Thread.CurrentThread.CurrentCulture = Cultura

        If Environment.GetCommandLineArgs.Length > 1 Then
            strArgumentos = Environment.CommandLine.ToString
        Else
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "pruebasdesa" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophia" & Chr(34) & " PWD=" & Chr(34) & "sophia" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0139" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "79937859" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "79937859" & Chr(34) & " nom_medico=" & Chr(34) & Chr(34) & " especialidad=" & Chr(34) & "310" & Chr(34) & " des_especialidad=" & Chr(34) & Chr(34) & " reg_medico=" & Chr(34) & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & "/></Raiz>"

            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "XUE" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophia" & Chr(34) & " PWD=" & Chr(34) & "sophia" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0008" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "39684255" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "39684255" & Chr(34) & " nom_medico=" & Chr(34) & "Ricardo Mauricio Zald?a C." & Chr(34) & " especialidad=" & Chr(34) & "004" & Chr(34) & " des_especialidad=" & Chr(34) & Chr(34) & " reg_medico=" & Chr(34) & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & "/></Raiz>"            
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "XUE" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophia" & Chr(34) & " PWD=" & Chr(34) & "sophia" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0003" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "79334158" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "79334158" & Chr(34) & " nom_medico=" & Chr(34) & "Ricardo Mauricio Zald?a C." & Chr(34) & " especialidad=" & Chr(34) & "310" & Chr(34) & " des_especialidad=" & Chr(34) & Chr(34) & " reg_medico=" & Chr(34) & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & "/></Raiz>"
            'xue115strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "xue" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophia" & Chr(34) & " PWD=" & Chr(34) & "sophia" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "115" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "76321113" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "76321113" & Chr(34) & " nom_medico=" & Chr(34) & "Ricardo Mauricio Zald?a C." & Chr(34) & " especialidad=" & Chr(34) & "004" & Chr(34) & " des_especialidad=" & Chr(34) & Chr(34) & " reg_medico=" & Chr(34) & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & "/></Raiz>"
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "PRUEBASDESA" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophia" & Chr(34) & " PWD=" & Chr(34) & "sophia" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "115" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "MED" & Chr(34) & " nom_medico=" & Chr(34) & Chr(34) & " especialidad=" & Chr(34) & "310" & Chr(34) & " des_especialidad=" & Chr(34) & Chr(34) & " reg_medico=" & Chr(34) & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & "/></Raiz>"
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "pruebasdesa" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophia" & Chr(34) & " PWD=" & Chr(34) & "sophia" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0003" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "MED" & Chr(34) & " nom_medico=" & Chr(34) & "Ricardo Mauricio Zald?a C." & Chr(34) & " especialidad=" & Chr(34) & "341" & Chr(34) & " des_especialidad=" & Chr(34) & Chr(34) & " reg_medico=" & Chr(34) & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & "/></Raiz>"
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "pruebasdesa" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophia" & Chr(34) & " PWD=" & Chr(34) & "sophia" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0139" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "52409720" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "52409720" & Chr(34) & " nom_medico=" & Chr(34) & "Ricardo Mauricio Zald?a C." & Chr(34) & " especialidad=" & Chr(34) & "385" & Chr(34) & " des_especialidad=" & Chr(34) & Chr(34) & " reg_medico=" & Chr(34) & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & "/></Raiz>"
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "PRUEBASDESA" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophia" & Chr(34) & " PWD=" & Chr(34) & "sophia" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "151" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "52318838" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "52318838" & Chr(34) & " nom_medico=" & Chr(34) & "Claudia Patricia Garay." & Chr(34) & " especialidad=" & Chr(34) & "341" & Chr(34) & " des_especialidad=" & Chr(34) & Chr(34) & " reg_medico=" & Chr(34) & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & "/></Raiz>"
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "192.168.1.201,1450" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophiad" & Chr(34) & " PWD=" & Chr(34) & "sophiad" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0003" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "78696841" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "78696841" & Chr(34) & " nom_medico=" & Chr(34) & "Claudia Patricia Garay." & Chr(34) & " especialidad=" & Chr(34) & "137" & Chr(34) & " des_especialidad=" & Chr(34) & Chr(34) & " reg_medico=" & Chr(34) & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & "/></Raiz>"
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "192.168.1.201,1450" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophiad" & Chr(34) & " PWD=" & Chr(34) & "sophiad" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "115" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "MED" & Chr(34) & " nom_medico=" & Chr(34) & "Claudia Patricia Garay." & Chr(34) & " especialidad=" & Chr(34) & "137" & Chr(34) & " des_especialidad=" & Chr(34) & Chr(34) & " reg_medico=" & Chr(34) & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & "/></Raiz>"
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "TICUNA" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophiabog" & Chr(34) & " PWD=" & Chr(34) & "pruebas" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0003" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "MED" & Chr(34) & " nom_medico=" & Chr(34) & Chr(34) & " especialidad=" & Chr(34) & "310" & Chr(34) & " des_especialidad=" & Chr(34) & Chr(34) & " reg_medico=" & Chr(34) & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & "/></Raiz>"
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "192.168.136.171,1450" & Chr(34) & " BaseDatos=" & Chr(34) & "sophiacal" & Chr(34) & " UserID=" & Chr(34) & "sophia8" & Chr(34) & " PWD=" & Chr(34) & "prueba" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0005" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "MED" & Chr(34) & " nom_medico=" & Chr(34) & Chr(34) & " especialidad=" & Chr(34) & "310" & Chr(34) & " des_especialidad=" & Chr(34) & Chr(34) & " reg_medico=" & Chr(34) & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & "/></Raiz>"
            'venstrArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "192.168.203.83" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophia" & Chr(34) & " PWD=" & Chr(34) & "sophia" & Chr(34) & " Prestadora=" & Chr(34) & "1" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0001" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "6283964" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "6283964" & Chr(34) & " nom_medico=" & Chr(34) & "Claudia Patricia Garay." & Chr(34) & " especialidad=" & Chr(34) & "004" & Chr(34) & " des_especialidad=" & Chr(34) & Chr(34) & " reg_medico=" & Chr(34) & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "484" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & "/></Raiz>"
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "192.168.1.201,1450" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophiad" & Chr(34) & " PWD=" & Chr(34) & "sophiad" & Chr(34) & " Prestadora=" & Chr(34) & "900022253" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0007" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "16675240" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "16675240" & Chr(34) & " nom_medico=" & Chr(34) & "Claudia Patricia Garay." & Chr(34) & " especialidad=" & Chr(34) & "137" & Chr(34) & " des_especialidad=" & Chr(34) & Chr(34) & " reg_medico=" & Chr(34) & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "482" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & "/></Raiz>"
            'PerustrArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "sophiapreprod,1450" & Chr(34) & " BaseDatos=" & Chr(34) & "sophiacal" & Chr(34) & " UserID=" & Chr(34) & "mforero" & Chr(34) & " PWD=" & Chr(34) & "mforero" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0005" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "1000" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "1000" & Chr(34) & " nom_medico=" & Chr(34) & Chr(34) & " especialidad=" & Chr(34) & "310" & Chr(34) & " des_especialidad=" & Chr(34) & Chr(34) & " reg_medico=" & Chr(34) & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "482" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & "/></Raiz>"
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "192.168.203.83" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophia" & Chr(34) & " PWD=" & Chr(34) & "sophia" & Chr(34) & " Prestadora=" & Chr(34) & "1" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0001" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "12501347" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "12501347" & Chr(34) & " nom_medico=" & Chr(34) & Chr(34) & " especialidad=" & Chr(34) & "310" & Chr(34) & " des_especialidad=" & Chr(34) & Chr(34) & " reg_medico=" & Chr(34) & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "484" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & "/></Raiz>"
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "192.168.203.83" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia_nueva" & Chr(34) & " UserID=" & Chr(34) & "sophia" & Chr(34) & " PWD=" & Chr(34) & "sophia" & Chr(34) & " Prestadora=" & Chr(34) & "1" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0001" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "12501347" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "12501347" & Chr(34) & " nom_medico=" & Chr(34) & Chr(34) & " especialidad=" & Chr(34) & "310" & Chr(34) & " des_especialidad=" & Chr(34) & Chr(34) & " reg_medico=" & Chr(34) & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "484" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & "/></Raiz>"
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "192.168.200.170" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophia" & Chr(34) & " PWD=" & Chr(34) & "sophia" & Chr(34) & " Prestadora=" & Chr(34) & "1" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0001" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "669884" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "669884" & Chr(34) & " nom_medico=" & Chr(34) & Chr(34) & " especialidad=" & Chr(34) & "310" & Chr(34) & " des_especialidad=" & Chr(34) & Chr(34) & " reg_medico=" & Chr(34) & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "484" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & "/></Raiz>"
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "sophiapreprodt,1450" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophiap" & Chr(34) & " PWD=" & Chr(34) & "sophiap" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0003" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "52266371" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "52266371" & Chr(34) & " nom_medico=" & Chr(34) & Chr(34) & " especialidad=" & Chr(34) & "004" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & "/></Raiz>"
            'desarrollo()
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "srvvsqldesa01,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophiad" & Chr(34) & " PWD=" & Chr(34) & "d3s4rr0ll02016" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "115" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "MED" & Chr(34) & " nom_medico=" & Chr(34) & "Medico Pruebas" & Chr(34) & " especialidad=" & Chr(34) & "004" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & "52266371" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "4.0.1" & Chr(34) & "/></Raiz>"
            'preproduccion REina 0003
            'cardiologia
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "srvsophiapredb1,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophiap" & Chr(34) & " PWD=" & Chr(34) & "SkPx5J3Z76vws9fe" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0003" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "PSS8082912" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "med" & Chr(34) & " nom_medico=" & Chr(34) & "KARLA TATIANA RESTREPO ROJAS " & Chr(34) & " especialidad=" & Chr(34) & "450" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & "med" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "2.6.1" & Chr(34) & "/></Raiz>"
            'Ortopedia
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "srvsophiapredb1,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophiap" & Chr(34) & " PWD=" & Chr(34) & "SkPx5J3Z76vws9fe" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0003" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "PSS8082912" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "med" & Chr(34) & " nom_medico=" & Chr(34) & "KARLA TATIANA RESTREPO ROJAS " & Chr(34) & " especialidad=" & Chr(34) & "514" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & "med" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "2.6.1" & Chr(34) & "/></Raiz>"
            'Med general
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "srvsophiapredb1,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophiap" & Chr(34) & " PWD=" & Chr(34) & "SkPx5J3Z76vws9fe" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0003" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "MED" & Chr(34) & " nom_medico=" & Chr(34) & "KARLA TATIANA RESTREPO ROJAS " & Chr(34) & " especialidad=" & Chr(34) & "004" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & "med" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "2.6.1" & Chr(34) & "/></Raiz>"
            ''preproduccion Colombia 115
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "srvsophiapredb1,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophiap" & Chr(34) & " PWD=" & Chr(34) & "SkPx5J3Z76vws9fe" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "115" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA UNIVERSITARIA COLOMBIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "med" & Chr(34) & " nom_medico=" & Chr(34) & "KARLA	TATIANA	RESTREPO	ROJAS " & Chr(34) & " especialidad=" & Chr(34) & "120" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & "med" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "2.6.1" & Chr(34) & "/></Raiz>"
            ''preproduccion EPS
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "srvsophiapredb2,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophiaeps" & Chr(34) & " UserID=" & Chr(34) & "sophiap" & Chr(34) & " PWD=" & Chr(34) & "SkPx5J3Z76vws9fe" & Chr(34) & " Prestadora=" & Chr(34) & "1100124826" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0524" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA UNIVERSITARIA COLOMBIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "med" & Chr(34) & " nom_medico=" & Chr(34) & "KARLA TATIANA	RESTREPO ROJAS " & Chr(34) & " especialidad=" & Chr(34) & "120" & Chr(34) & " des_especialidad=" & Chr(34) & "CARDIOLOGIA" & Chr(34) & " reg_medico=" & Chr(34) & "med" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "5.0.0" & Chr(34) & "/></Raiz>"
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "srvsophiapredb2,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophiaeps" & Chr(34) & " UserID=" & Chr(34) & "sophiap" & Chr(34) & " PWD=" & Chr(34) & "SkPx5J3Z76vws9fe" & Chr(34) & " Prestadora=" & Chr(34) & "1100124826" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0524" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA UNIVERSITARIA COLOMBIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "med" & Chr(34) & " nom_medico=" & Chr(34) & "KARLA TATIANA	RESTREPO ROJAS " & Chr(34) & " especialidad=" & Chr(34) & "002" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & "med" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "5.0.0" & Chr(34) & "/></Raiz>"
            'preproduccion MDE
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "srvsophiapredb2,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophiaMED" & Chr(34) & " UserID=" & Chr(34) & "sophiap" & Chr(34) & " PWD=" & Chr(34) & "SkPx5J3Z76vws9fe" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0028" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA UNIVERSITARIA COLOMBIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "med" & Chr(34) & " nom_medico=" & Chr(34) & "KARLA TATIANA	RESTREPO ROJAS " & Chr(34) & " especialidad=" & Chr(34) & "002" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & "med" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "5.0.0" & Chr(34) & "/></Raiz>"
            'preproduccion BUC
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "srvsophiapredb2,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophiabuc" & Chr(34) & " UserID=" & Chr(34) & "sophiap" & Chr(34) & " PWD=" & Chr(34) & "SkPx5J3Z76vws9fe" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0026" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA UNIVERSITARIA COLOMBIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "med" & Chr(34) & " nom_medico=" & Chr(34) & "KARLA TATIANA RESTREPO ROJAS" & Chr(34) & " especialidad=" & Chr(34) & "002" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & "med" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "5.0.0" & Chr(34) & "/></Raiz>"
            'preproduccion PAS
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "srvsophiapredb2,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophiaPAS" & Chr(34) & " UserID=" & Chr(34) & "sophiap" & Chr(34) & " PWD=" & Chr(34) & "SkPx5J3Z76vws9fe" & Chr(34) & " Prestadora=" & Chr(34) & "1000100001" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "1401" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA UNIVERSITARIA COLOMBIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "med" & Chr(34) & " nom_medico=" & Chr(34) & "KARLA TATIANA	RESTREPO ROJAS " & Chr(34) & " especialidad=" & Chr(34) & "002" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & "med" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "5.0.0" & Chr(34) & "/></Raiz>"
            'preproduccion IBE
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "srvsophiapredb2,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophiaibe" & Chr(34) & " UserID=" & Chr(34) & "sophiap" & Chr(34) & " PWD=" & Chr(34) & "SkPx5J3Z76vws9fe" & Chr(34) & " Prestadora=" & Chr(34) & "900397763" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0130" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA UNIVERSITARIA COLOMBIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "med" & Chr(34) & " nom_medico=" & Chr(34) & "KARLA TATIANA	RESTREPO ROJAS " & Chr(34) & " especialidad=" & Chr(34) & "009" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & "med" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "5.0.0" & Chr(34) & "/></Raiz>"
            'preproduccion QUILLA
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "srvsophiapredb2,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophiabar" & Chr(34) & " UserID=" & Chr(34) & "sophiap" & Chr(34) & " PWD=" & Chr(34) & "SkPx5J3Z76vws9fe" & Chr(34) & " Prestadora=" & Chr(34) & "1100124826" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0615" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA UNIVERSITARIA COLOMBIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "med" & Chr(34) & " nom_medico=" & Chr(34) & "KARLA TATIANA	RESTREPO ROJAS " & Chr(34) & " especialidad=" & Chr(34) & "002" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & "med" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "5.0.0" & Chr(34) & "/></Raiz>"
            'preproduccion CAL
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "srvsophiapredb2,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophiacal" & Chr(34) & " UserID=" & Chr(34) & "sophiap" & Chr(34) & " PWD=" & Chr(34) & "SkPx5J3Z76vws9fe" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0005" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA UNIVERSITARIA COLOMBIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "MED" & Chr(34) & " nom_medico=" & Chr(34) & "KARLA TATIANA	RESTREPO ROJAS " & Chr(34) & " especialidad=" & Chr(34) & "120" & Chr(34) & " des_especialidad=" & Chr(34) & "CARDIOLOGIA" & Chr(34) & " reg_medico=" & Chr(34) & "med" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "5.3.0" & Chr(34) & "/></Raiz>"
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "srvsophiapredb2,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophiacal" & Chr(34) & " UserID=" & Chr(34) & "sophiap" & Chr(34) & " PWD=" & Chr(34) & "SkPx5J3Z76vws9fe" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "115" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA UNIVERSITARIA COLOMBIA" & Chr(34) & " Login=" & Chr(34) & "PSS1019041" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "med" & Chr(34) & " nom_medico=" & Chr(34) & "KARLA TATIANA	RESTREPO ROJAS " & Chr(34) & " especialidad=" & Chr(34) & "450" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & "med" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "5.3.0" & Chr(34) & "/></Raiz>"
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "srvsophiapredb2,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophiacal" & Chr(34) & " UserID=" & Chr(34) & "sophiap" & Chr(34) & " PWD=" & Chr(34) & "SkPx5J3Z76vws9fe" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0005" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA UNIVERSITARIA COLOMBIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "med" & Chr(34) & " nom_medico=" & Chr(34) & "KARLA TATIANA RESTREPO ROJAS " & Chr(34) & " especialidad=" & Chr(34) & "002" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & "med" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "2.6.1" & Chr(34) & "/></Raiz>"
            'sostenibilidad t
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "172.18.46.76,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "tsophia" & Chr(34) & " UserID=" & Chr(34) & "sostenibilidad" & Chr(34) & " PWD=" & Chr(34) & "msHY5CyKHFyMuU9c" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "115" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "MED" & Chr(34) & " nom_medico=" & Chr(34) & "Claudia Patricia Garay." & Chr(34) & " especialidad=" & Chr(34) & "137" & Chr(34) & " des_especialidad=" & Chr(34) & Chr(34) & " reg_medico=" & Chr(34) & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & "/></Raiz>"
            'DesarrolloTSophia 0013
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "srvvsqldesa01,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "TSOPHIA" & Chr(34) & " UserID=" & Chr(34) & "sostenibilidad" & Chr(34) & " PWD=" & Chr(34) & "msHY5CyKHFyMuU9c" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0003" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "med" & Chr(34) & " nom_medico=" & Chr(34) & "KARLA TATIANA RESTREPO ROJAS " & Chr(34) & " especialidad=" & Chr(34) & "002" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & "med" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "2.6.1" & Chr(34) & "/></Raiz>"
            'Pre PHD 0013
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "srvsophiapredb1,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophiap" & Chr(34) & " PWD=" & Chr(34) & "SkPx5J3Z76vws9fe" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0013" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "PSS8021658" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "med" & Chr(34) & " nom_medico=" & Chr(34) & "KARLA TATIANA RESTREPO ROJAS " & Chr(34) & " especialidad=" & Chr(34) & "009" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & "med" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "2.6.1" & Chr(34) & "/></Raiz>"
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "sqlcluster1,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "crs_sis" & Chr(34) & " PWD=" & Chr(34) & "Kn0xv1ll30s12013" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "115" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "52266371" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "52266371" & Chr(34) & " nom_medico=" & Chr(34) & Chr(34) & " especialidad=" & Chr(34) & "310" & Chr(34) & " des_especialidad=" & Chr(34) & Chr(34) & " reg_medico=" & Chr(34) & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "2.6.1" & Chr(34) & "/></Raiz>"
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "sophiapreprod,1450" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophiap" & Chr(34) & " PWD=" & Chr(34) & "sophiap" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0013" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "1000" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "1000" & Chr(34) & " nom_medico=" & Chr(34) & Chr(34) & " especialidad=" & Chr(34) & "310" & Chr(34) & " des_especialidad=" & Chr(34) & Chr(34) & " reg_medico=" & Chr(34) & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & "/></Raiz>"
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & "?><Raiz><Row Servidor= " & Chr(34) & "SQLCLUSTERA,1450" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "crs_sis" & Chr(34) & " PWD=" & Chr(34) & "Kn0xv1ll30s12013" & Chr(34) & " prestadora=" & Chr(34) & 1100109887 & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS S.A." & Chr(34) & " sucursal=" & Chr(34) & "0003" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "MED" & Chr(34) & " nom_medico=" & Chr(34) & "PRUEBAS . . ." & Chr(34) & " especialidad=" & Chr(34) & "004" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & "INSTI." & Chr(34) & " cen_costo=" & Chr(34) & "0044" & Chr(34) & " ciudad=" & Chr(34) & "175" & Chr(34) & " des_ciudad=" & Chr(34) & "" & Chr(34) & " depart=" & Chr(34) & "25" & Chr(34) & " des_depart=" & Chr(34) & "" & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & "" & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "2.7.0" & Chr(34) & "/></Raiz>"
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "172.18.46.76,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "tsophia" & Chr(34) & " UserID=" & Chr(34) & "sostenibilidad" & Chr(34) & " PWD=" & Chr(34) & "msHY5CyKHFyMuU9c" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "115" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "MED" & Chr(34) & " nom_medico=" & Chr(34) & "Claudia Patricia Garay." & Chr(34) & " especialidad=" & Chr(34) & "450" & Chr(34) & " des_especialidad=" & Chr(34) & Chr(34) & " reg_medico=" & Chr(34) & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & "/></Raiz>"
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "srvsophiapredb2,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophiaibe" & Chr(34) & " UserID=" & Chr(34) & "sophiap" & Chr(34) & " PWD=" & Chr(34) & "SkPx5J3Z76vws9fe" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0005" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA REINA SOFIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "med" & Chr(34) & " nom_medico=" & Chr(34) & "KARLA	TATIANA	RESTREPO	ROJAS " & Chr(34) & " especialidad=" & Chr(34) & "002" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & "med" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "2.6.1" & Chr(34) & "/></Raiz>"

            'preproduccion Colombia 115
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "srvsophiapredb1,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophiap" & Chr(34) & " PWD=" & Chr(34) & "SkPx5J3Z76vws9fe" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "115" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA UNIVERSITARIA COLOMBIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "med" & Chr(34) & " nom_medico=" & Chr(34) & "KARLA TATIANA RESTREPO ROJAS" & Chr(34) & " especialidad=" & Chr(34) & "120" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & "med" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "2.6.1" & Chr(34) & "/></Raiz>"

            'preproduccion IBERO 0130
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "srvsophiapredb2,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophiaIBE" & Chr(34) & " UserID=" & Chr(34) & "sophiap" & Chr(34) & " PWD=" & Chr(34) & "SkPx5J3Z76vws9fe" & Chr(34) & " Prestadora=" & Chr(34) & "900397763" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA IBEROAMERICA" & Chr(34) & " Sucursal=" & Chr(34) & "0130" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA IBEROAMERICA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "med" & Chr(34) & " nom_medico=" & Chr(34) & "KARLA TATIANA RESTREPO ROJAS" & Chr(34) & " especialidad=" & Chr(34) & "120" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & "med" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "2.6.1" & Chr(34) & "/></Raiz>"
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "172.18.46.210,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophian" & Chr(34) & " UserID=" & Chr(34) & "sophiad" & Chr(34) & " PWD=" & Chr(34) & "6cow7brDPi847L1BSNGE" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "0003" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA UNIVERSITARIA COLOMBIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "med" & Chr(34) & " nom_medico=" & Chr(34) & "KARLA TATIANA RESTREPO ROJAS" & Chr(34) & " especialidad=" & Chr(34) & "120" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & "med" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "2.6.1" & Chr(34) & "/></Raiz>"
            'preproduccion Colombia 115
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "srvsophiapredb1,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophiap" & Chr(34) & " PWD=" & Chr(34) & "SkPx5J3Z76vws9fe" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "115" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA UNIVERSITARIA COLOMBIA" & Chr(34) & " Login=" & Chr(34) & "MEDTEST" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "MEDTEST" & Chr(34) & " nom_medico=" & Chr(34) & "KARLA TATIANA RESTREPO ROJAS" & Chr(34) & " especialidad=" & Chr(34) & "120" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & "1030538949" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "2.6.1" & Chr(34) & "/></Raiz>"

            'preproduccion Colombia 115 
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "srvsophiapredb1,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "SOPHIA" & Chr(34) & " UserID=" & Chr(34) & "sophiap" & Chr(34) & " PWD=" & Chr(34) & "SkPx5J3Z76vws9fe" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "115" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINISANITAS BUCARAMANGA" & Chr(34) & " Login=" & Chr(34) & "MEDTEST" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "MEDTEST" & Chr(34) & " nom_medico=" & Chr(34) & "MEDICO PRUEBAS COVID" & Chr(34) & " especialidad=" & Chr(34) & "430" & Chr(34) & " des_especialidad=" & Chr(34) & "NEUMOLOGIA" & Chr(34) & " reg_medico=" & Chr(34) & "1030538949" & Chr(34) & " cen_costo=" & Chr(34) & "0041" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "2.6.1" & Chr(34) & "/></Raiz>"

            'Pre-producci?n Conciliaci?n medicamentos????????????
            'strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "172.18.46.117,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophia" & Chr(34) & " UserID=" & Chr(34) & "sophiap" & Chr(34) & " PWD=" & Chr(34) & "SkPx5J3Z76vws9fe" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "115" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA UNIVERSITARIA COLOMBIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "med" & Chr(34) & " nom_medico=" & Chr(34) & "KARLA TATIANA RESTREPO ROJAS" & Chr(34) & " especialidad=" & Chr(34) & "120" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & "med" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "2.6.1" & Chr(34) & "/></Raiz>"
            'Desarrollo Conciliaci?n medicamentos????????????
            strArgumentos = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & " ?><Raiz><Row Servidor=" & Chr(34) & "172.18.46.210,1470" & Chr(34) & " BaseDatos=" & Chr(34) & "sophian" & Chr(34) & " UserID=" & Chr(34) & "sophiad" & Chr(34) & " PWD=" & Chr(34) & "6cow7brDPi847L1BSNGE" & Chr(34) & " Prestadora=" & Chr(34) & "1100109887" & Chr(34) & " des_prestadora=" & Chr(34) & "CLINICA COLSANITAS" & Chr(34) & " Sucursal=" & Chr(34) & "115" & Chr(34) & " des_Sucursal=" & Chr(34) & "CLINICA UNIVERSITARIA COLOMBIA" & Chr(34) & " Login=" & Chr(34) & "MED" & Chr(34) & " TipoUsuario=" & Chr(34) & "M" & Chr(34) & " medico=" & Chr(34) & "med" & Chr(34) & " nom_medico=" & Chr(34) & "KARLA TATIANA RESTREPO ROJAS" & Chr(34) & " especialidad=" & Chr(34) & "120" & Chr(34) & " des_especialidad=" & Chr(34) & "MEDICINA GENERAL" & Chr(34) & " reg_medico=" & Chr(34) & "med" & Chr(34) & " cen_costo=" & Chr(34) & "0023" & Chr(34) & " ciudad=" & Chr(34) & "001" & Chr(34) & " des_ciudad=" & Chr(34) & Chr(34) & " depart=" & Chr(34) & "11" & Chr(34) & " des_depart=" & Chr(34) & Chr(34) & " pais=" & Chr(34) & "480" & Chr(34) & " des_pais=" & Chr(34) & Chr(34) & " contingencia=" & Chr(34) & "S" & Chr(34) & " man_rips=" & Chr(34) & "S" & Chr(34) & " Corregir=" & Chr(34) & "N" & Chr(34) & " Version=" & Chr(34) & "2.6.1" & Chr(34) & "/></Raiz>"


            'MsgBox("No existen par?metros de entrada", MsgBoxStyle.Information)
            'Me.Close()
            'Exit Sub
            '#End If

        End If

            'Se parte la cadena para solo obtener el xml de parametros
            xmlParametrosIniciales = Mid(strArgumentos, InStr(strArgumentos, "<?"), Len(strArgumentos))

        If xmlParametrosIniciales.Trim.Length <= 0 Then
            MsgBox("No existen parametros de entrada", MsgBoxStyle.Information)

            '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
            'Juan Carlos Jaramillo Lozano - IG
            RptHC_Enf_Med.RptHC_Enf_Med_FormEstado(objConexion, "1", "C", "No existen parametros de entrada")
            '2019-03-11 Fin

            Me.Close()
            Exit Sub
        End If

        'Creacion de los objetos sigleton que guardan la informacion general y los datos de la conexion 
        objDatosGenerales = objGeneral.Generales.Instancia
        objConexion = objCon.Conexion.Instancia
        'Se cargan los objetos con la informacion que es recibida en el xml
        'Try
        lError = objDatosGenerales.cargarParametrosIniciales(xmlParametrosIniciales, objConexion)
        If lError <> 0 Then
            MsgBox("Errores de carga del documento XML.", MsgBoxStyle.Information)

            '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
            'Juan Carlos Jaramillo Lozano - IG
            RptHC_Enf_Med.RptHC_Enf_Med_FormEstado(objConexion, "1", "C", "Errores de carga del documento XML.")
            '2019-03-11 Fin

            Me.Close()
            Exit Sub
        End If

        ''Claudia Garay Para mostrar imagen Venezuela Septiembre de 2012
        If objDatosGenerales.Pais = "484" Then
            Me.PictureBox1.Image = Global.HistoriaClinica.My.Resources.Resources.sanitasmodificado
            Me.btnIncapacidad.Image = Global.HistoriaClinica.My.Resources.Resources.Reposo
            btnIncapacidad.Size = New System.Drawing.Size(74, 30)
            btnRemisiones.Location = New System.Drawing.Point(375, 0)
            btnRecomendaciones.Location = New System.Drawing.Point(453, 0)
            btnContrareferencia.Location = New System.Drawing.Point(629, 0)
        ElseIf objDatosGenerales.Pais = "482" Then
            Me.PictureBox1.Image = Global.HistoriaClinica.My.Resources.Resources.Peru1
            pnlMenuPlanManejo.Location = New System.Drawing.Point(88, 82)
            pnlMenuPlanManejo.Size = New System.Drawing.Size(919, 34)
            btnFormulacion.Location = New System.Drawing.Point(0, 0)
            btnProcedimientos.Location = New System.Drawing.Point(144, 0)
            btnIncapacidad.Location = New System.Drawing.Point(306, 0)
            btnIncapacidad.Size = New System.Drawing.Size(147, 30)
            btnRemisiones.Location = New System.Drawing.Point(450, 0)
            btnRecomendaciones.Location = New System.Drawing.Point(446, 0)
            btnContrareferencia.Location = New System.Drawing.Point(801, 0)
            Me.btnIncapacidad.Image = Global.HistoriaClinica.My.Resources.Resources.DescansoMedicoPorIincapacidad1
        Else
            'martovar se comentarea el logo de la clinica version 3.0
            'Me.PictureBox1.Image = Global.HistoriaClinica.My.Resources.Resources.logo_clinica
        End If

        'Try
        'objDatosGenerales.Version = "5.3.3"
        'Label2.Text = "Versi?n " & objDatosGenerales.Version

        Dim version As Version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version

        Dim buildDate As New DateTime(2000, 1, 1)
        buildDate.AddDays(version.Major).AddSeconds(version.Minor * 2)

        objDatosGenerales.Version = version.ToString()
        'Label2.Text = "Versi?n Beta: " & version.ToString() '& buildDate.ToString()
        Label2.Text = "Versi?n: " & version.ToString() '& buildDate.ToString()

        strDescripcion = ""
        intVersion = TraerVersion("EXHIS", strDescripcion)
        'intVersion = 2100
        If intVersion > CInt(Replace(version.ToString(), ".", "")) Then
            MsgBox("La versi?n de " & UCase(strDescripcion) & " se encuentra desactualizada." & vbCr & vbCr & "El equipo debe tener instalada la versi?n " & intVersion &
            vbCr & vbCr & "Para poder ingresar apague y vuelva a prender el equipo. " & vbCr & vbCr & "Si el problema continua despues de reiniciar comuniquese con el MAS a la extensi?n 5711000 ", vbCritical)

            '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
            'Juan Carlos Jaramillo Lozano - IG
            RptHC_Enf_Med.RptHC_Enf_Med_FormEstado(objConexion, "1", "C", "La versi?n de " & UCase(strDescripcion) & " se encuentra desactualizada. El equipo debe tener instalada la versi?n " & intVersion &
            " Para poder ingresar apague y vuelva a prender el equipo.  Si el problema continua despues de reiniciar comuniquese con el MAS a la extensi?n 5711000 ")
            '2019-03-11 Fin

            Me.Close()
            Exit Sub
        End If


        'Catch ex As Exception
        '    MsgBox("Error al obtener el numero de la version.", MsgBoxStyle.Information)
        '    Me.Close()
        '    Exit Sub
        'End Try

        If objDatosGenerales.TipoUsuario <> TIPOUSUARIO_MEDICO Then

            ValidaPerfilusuario()

            If objDatosGenerales.SoloConsulta = False And objDatosGenerales.SoloConsultaFarma = False Then
                MsgBox("Usuario no autorizado para esta opci?n.", MsgBoxStyle.Information)

                '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
                'Juan Carlos Jaramillo Lozano - IG
                RptHC_Enf_Med.RptHC_Enf_Med_FormEstado(objConexion, "1", "C", "Usuario no autorizado para esta opci?n.")
                '2019-03-11 Fin

                Me.Close()
                Exit Sub
            End If

        Else
            'ValidaPerfilusuario()
        End If

        'End If
        'If dtresul.Rows.Count > 0 Then
        '    If Not IsDBNull(dtresul.Rows(0).Item("consultahistoria")) Then
        '        If dtresul.Rows(0).Item("consultahistoria") = "S" Then
        '            objDatosGenerales.PuedeConsultarHC = "S"
        '        End If
        '    End If
        'End If

        'Catch ex As Exception
        '    MsgBox("Errores de carga de los parametros iniciales.", MsgBoxStyle.Information)
        '    Me.Close()
        '    Exit Sub
        'End Try

        'Try

        '**HDCPCEF (Habilitar - Deshabilitar C?digo Para Correcci?n Examen Fisico**
        If objDatosGenerales.MedicoRealizaCorreccion = "S" Or objDatosGenerales.MedicoRealizaCorreccion = "T" Then
            CargarListaEsperaError()
        Else
            CargarListaEspera()
        End If
        '**/
        'Catch ex As Exception
        '    MsgBox(ex.Message & "   " & ex.StackTrace)
        'End Try

        dblAltoControlPaciente = pnlContenedorDatosPaciente.Height
        Me.Text = Me.Text & " " & objDatosGenerales.DescripcionPrestador & "," & objDatosGenerales.DescripcionSucursal &
                 " Opciones para " & objDatosGenerales.Login & " en " & objConexion.strServidor


        Me.lbl_Nombremedico.Text = "Dr(a).  " & objDatosGenerales.NombreMedico & " (" & objDatosGenerales.DescripcionEspecialidad & ")"

        'Se adiciona validacion para mostrar el boton de paciente 360
        ' eloaiza@intergrupo.com   17/09/2019
        If btn360Layout.Visible = True Then
            btn360Layout.Visible = False
        End If

        Exit Sub
Salir:
        End
    End Sub
    Private Sub ValidaPerfilusuario()
        ''Se valida si el perfil del usuario es solo con opci?n de consulta cpgaray Octubre 2 de 2013
        Dim Datos() As Object = Nothing
        Dim dt As New DataTable
        Dim iconfarma As Integer = 0

        ReDim Datos(3)
        Datos(0) = objDatosGenerales.Prestador
        Datos(1) = objDatosGenerales.Sucursal
        Datos(2) = objDatosGenerales.Login
        Datos(3) = 1

        dt = BLHistoriaBasica.ConsultarPerfilUsuario("HC_ConsultarPerfilusuario", objConexion, 0, Datos)


        If dt.Rows.Count > 0 Then

            For i As Integer = 0 To dt.Rows.Count - 1

                If dt.Rows(i).Item("codperfil").ToString = "FAR" Then
                    iconfarma = 1
                End If

            Next

            If iconfarma = 1 Then
                objDatosGenerales.SoloConsultaFarma = True '' cpgaray OS 7531913 perfil farmacia

            Else
                objDatosGenerales.SoloConsulta = True
            End If


        Else
            objDatosGenerales.SoloConsulta = False
            objDatosGenerales.SoloConsultaFarma = False
        End If

    End Sub


    Private Function TraerVersion(ByVal strModulo As String, ByRef strDescripcion As String) As Integer
        ''Se valida si el perfil del usuario es solo con opci?n de consulta cpgaray Octubre 2 de 2013
        Dim Datos() As Object = Nothing
        Dim dt As New DataTable

        ReDim Datos(0)
        Datos(0) = strModulo

        dt = BLHistoriaBasica.ConsultarVersion("pa_TraerVersion", objConexion, 0, Datos)


        If dt.Rows.Count > 0 Then
            TraerVersion = dt.Rows(0).Item("COD_VER").ToString
            strDescripcion = dt.Rows(0).Item("DESCRIPCION").ToString
        Else
            strDescripcion = ""
            TraerVersion = 0
        End If

    End Function

    'cambio solicitado por German Garzon para revisar si muestra las ordenes de laboratorio si esta activo el falg de WS_Labor de la sucursal
    Private Function TraerWSLabo_Sucursal(ByVal strCodpresgs As String, ByRef strCodSucur As String) As String
        ''Se valida si el perfil del usuario es solo con opci?n de consulta cpgaray Octubre 2 de 2013
        Dim Datos() As Object = Nothing
        Dim dt As New DataTable

        ReDim Datos(3)
        Datos(0) = 24
        Datos(1) = strCodpresgs
        Datos(2) = strCodSucur
        Datos(3) = 0


        dt = BLHistoriaBasica.ConsultarVersion("DB_TraerGensucur", objConexion, 0, Datos)

        If dt.Rows.Count > 0 Then
            TraerWSLabo_Sucursal = dt.Rows(0).Item("man_wslabo").ToString
        Else
            TraerWSLabo_Sucursal = "N"
        End If

    End Function

    Private Sub cmdHistoriaBasica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdHistoriaBasica.Click
        Dim ctlOrdMedicas As ctlOrdenesMedicas
        ctlOrdMedicas = ctlOrdenesMedicas.Instancia

        If Not ctlOrdMedicas Is Nothing Then
            If ctlOrdMedicas.existenDatosSinAlmacenar() Then
                If ctlOrdMedicas.Visible = False Then
                    Me.btnOrdenes_Click(Me.btnOrdenes, New EventArgs())
                End If
                Select Case MessageBox.Show("No se ha guardado la informaci?n registrada, perder? los cambios realizados ?desea continuar?", "Historia Clinica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    Case Windows.Forms.DialogResult.OK
                        ctlOrdenesMedicas.Instancia.datosSinAlmacenar = False
                    Case Windows.Forms.DialogResult.Cancel
                        Exit Sub
                End Select
            End If
        End If

        If Me.strNameControlLoad.Trim.Length > 0 And strNameControlLoad.ToUpper <> "HCBasica" Then
            pnlContenedorDatos.Controls(strNameControlLoad).Visible = False

        End If

        'If Me.strNameControlLoad.Trim.Length > 0 Then
        '    pnlContenedorDatos.Controls(strNameControlLoad).Visible = False

        'End If

        'Dim sControl As ctlOrdenesMedicas
        'sControl = ctlOrdenesMedicas.Instancia
        'sControl.Mostrar()

        IniciaHistoriaBasica()
    End Sub
    Public Sub IniciaHistoriaBasica()
        Dim ctlPantallaDatosPaciente As ctlDatosPaciente
        Dim ctlPantallaHistoriaBasica As HCBasica


        ''Claudia Garay 8 septiembre de 2011
        ''Validar que se guarden las evoluciones
        'se elimina validaci?n a solicitud del requerimiento ER_OSI_602
        '
        'If Not ctlEvolucion.Instancia.ValidarSiEvolucionSeGuardo Then
        '    MsgBox("Guarde las evoluciones antes de continuar", MsgBoxStyle.Exclamation)
        '    Exit Sub
        'End If
        ''Fin

        ctlPantallaDatosPaciente = ctlDatosPaciente.Instancia
        ctlPantallaHistoriaBasica = HCBasica.Instancia

        pintarMenu(OpcionesMenu.HistoriaBasica)
        cambiarFondo(OpcionesMenu.HistoriaBasica)

        pnlContenedorListaEspera.Visible = False
        pnlContenedorPantallas.Visible = True

        'Me.pnlContenedorDatosPaciente.Controls.Clear()

        If blnCtlDatosPaciente = False Then
            ctlPantallaDatosPaciente.Dock = DockStyle.Fill
            ctlPantallaDatosPaciente.Size = pnlContenedorDatosPaciente.Size
            Me.pnlContenedorDatosPaciente.Controls.Add(ctlPantallaDatosPaciente)
            blnCtlDatosPaciente = True
            ctlPantallaDatosPaciente.Show()
        End If

        'Me.pnlContenedorDatos.Controls.Clear()

        If Me.strNameControlLoad.Trim.Length > 0 And Me.strNameControlLoad.ToUpper <> "HCBASICA" Then
            pnlContenedorDatos.Controls(strNameControlLoad).Visible = False
            strNameControlLoad = "HCBasica"
        End If

        If blnCtlHCBasica = False Then
            ctlPantallaHistoriaBasica.Dock = DockStyle.Fill
            ctlPantallaHistoriaBasica.Size = pnlContenedorDatos.Size
            ctlPantallaHistoriaBasica.AutoSize = True
            ctlPantallaHistoriaBasica.AutoScroll = True
            Me.pnlContenedorDatos.Controls.Add(ctlPantallaHistoriaBasica)
            blnCtlHCBasica = True
            ctlPantallaHistoriaBasica.Show()
        Else
            pnlContenedorDatos.Controls("HCBasica").Visible = True
        End If
        'Se adiciona validacion para mostrar el boton de paciente 360
        ' eloaiza@intergrupo.com   17/09/2019
        'If pnlContenedorDatos.Controls("HCBasica").Visible = True Then
        '    If btn360Layout.Visible = True Then
        '        btn360Layout.Visible = False
        '    End If
        'End If

    End Sub
    Private Sub cmdListaEspera_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdListaEspera.Click
        Dim ctlOrdMedicas As ctlOrdenesMedicas
        ctlOrdMedicas = ctlOrdenesMedicas.Instancia

        If Not ctlOrdMedicas Is Nothing Then
            If ctlOrdMedicas.existenDatosSinAlmacenar() Then
                If ctlOrdMedicas.Visible = False Then
                    Me.btnOrdenes_Click(Me.btnOrdenes, New EventArgs())
                End If
                Select Case MessageBox.Show("No se ha guardado la informaci?n registrada, perder? los cambios realizados ?desea continuar?", "Historia Clinica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    Case Windows.Forms.DialogResult.OK
                        ctlOrdenesMedicas.Instancia.datosSinAlmacenar = False
                    Case Windows.Forms.DialogResult.Cancel
                        Exit Sub
                End Select
            End If
        End If

        If Me.strNameControlLoad.Trim.Length > 0 Then
            pnlContenedorDatos.Controls(strNameControlLoad).Visible = False

        End If

        Dim ctlPantallaHistoriaBasica As HCBasica
        Dim cEvolucion As ctlEvolucion
        Dim x As DataTable

        ctlPantallaHistoriaBasica = HCBasica.Instancia
        cEvolucion = ctlEvolucion.Instancia
        cEvolucion.LimpiarPantalla()

        If salirHistoriaClinica() = False Then
            Exit Sub
        End If
        ''Ingresado por Claudia Garay para limipar la grilla de examen fisico
        ''cuando se vaya a lista de espera
        ''Solicitado por Juan Diego Arenas
        ''11 marzo 2010
        x = ctlPantallaHistoriaBasica.dtgHallazgosEF.DataSource
        x.Clear()
        ctlPantallaHistoriaBasica.dtgHallazgosEF.DataSource = x
        CargarListaEspera()
        'Se adiciona validacion para mostrar el boton de paciente 360
        ' eloaiza@intergrupo.com   17/09/2019
        If btn360Layout.Visible = True Then
            btn360Layout.Visible = False
        End If


    End Sub

    Public Sub CargarListaEspera()
        Dim ctlPantallaListaEspera As ListaEspera

        Timer1.Enabled = False
        lblError1.Visible = False
        lblError2.Visible = False

        ctlPantallaListaEspera = ListaEspera.Instancia
        ctlPantallaListaEspera.Show()

        pintarMenu(OpcionesMenu.ListaEspera)
        cambiarFondo(OpcionesMenu.ListaEspera)

        pnlInfoDatosPaciente.Visible = False
        pnlContenedorPantallas.Visible = False
        pnlContenedorListaEspera.Visible = True

        If Me.strNameControlLoad.Trim.Length > 0 And strNameControlLoad.ToUpper <> "LISTAESPERA" Then
            pnlContenedorDatos.Controls(strNameControlLoad).Visible = False
            strNameControlLoad = "HCBasica"
        End If

        'pnlContenedorListaEspera.Controls.Clear()
        If blnCtlListaEspera = False Then
            ctlPantallaListaEspera.Dock = DockStyle.Fill
            ctlPantallaListaEspera.Size = pnlContenedorListaEspera.Size
            Me.pnlContenedorListaEspera.Controls.Add(ctlPantallaListaEspera)
            blnCtlListaEspera = True
        End If
        Me.pnlContenedorSecciones.Visible = False
        Me.pnlContenedorSeccionesOM.Visible = False
        pnlContenedorEnf.Visible = False ''cpgaray
        blnListaEsperaError = False
        'ctlPantallaListaEspera.Show()

    End Sub

    Private Sub CargarListaEsperaError()
        Dim ctlPantallaListaEspera As New ListaEsperaError

        pintarMenu(OpcionesMenu.ListaEspera)
        cambiarFondo(OpcionesMenu.ListaEspera)

        pnlInfoDatosPaciente.Visible = False
        pnlContenedorPantallas.Visible = False
        pnlContenedorListaEspera.Visible = True

        pnlContenedorListaEspera.Controls.Clear()
        ctlPantallaListaEspera.Dock = DockStyle.Fill
        ctlPantallaListaEspera.Size = pnlContenedorListaEspera.Size
        Me.pnlContenedorListaEspera.Controls.Add(ctlPantallaListaEspera)
        Me.pnlContenedorSecciones.Visible = False
        Me.pnlContenedorSeccionesOM.Visible = False
        blnListaEsperaError = True
        Me.btnNotas.Enabled = False
        'Me.btnConsultas.Enabled = False

        'ctlPantallaListaEspera.Show()

    End Sub

    ''Cuidados Paliativos
    Private Sub btnCuidadosPaliativos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCuidadosPaliativos.Click
        ''Nota: WACHV,03DIC2017, Se debe tener en cuenta que el control que esta llamanado sea "ctlCuidadoPaliativo"
        ''es decir, como esta nombrado el control fisicamente el archivo, en caso contrario no funciona.
        Dim ctlCuidadosPaliativos As ctlCuidadoPaliativo = pnlContenedorDatos.Controls("ctlCuidadoPaliativo")

        ctlCuidadosPaliativos = ctlCuidadoPaliativo.Instancia
        pintarMenu(OpcionesMenu.CuidadosPaliativos)
        cambiarFondo(OpcionesMenu.CuidadosPaliativos)

        pnlContenedorListaEspera.Visible = False
        pnlContenedorPantallas.Visible = True

        'Me.pnlContenedorDatos.Controls.Clear()

        If Me.strNameControlLoad.Trim.Length > 0 And strNameControlLoad.ToUpper <> "CTLCUIDADOPALIATIVO" Then
            pnlContenedorDatos.Controls(strNameControlLoad).Visible = False
            strNameControlLoad = "ctlCuidadoPaliativo"
        End If

        If blnCtlCuidadospaliativos = False Then
            ctlCuidadosPaliativos.Dock = DockStyle.Fill
            ctlCuidadosPaliativos.Size = pnlContenedorDatos.Size
            ctlCuidadosPaliativos.AutoScroll = True
            Me.pnlContenedorDatos.Controls.Add(ctlCuidadosPaliativos)
            ctlCuidadosPaliativos.Show()
            ctlCuidadosPaliativos.AutoScrollPosition = New Point(0, 0)
            ctlCuidadosPaliativos.IniciarCuidadosPaliativos() ''CCGUTIEREZ. 31/07/2020. CA_6353881    
            blnCtlCuidadospaliativos = True
        Else
            pnlContenedorDatos.Controls("ctlCuidadoPaliativo").Visible = True
        End If

    End Sub

    Private Sub btnEgreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEgreso.Click
        Dim ctlPantallaEgreso As CtlEgresos
        ctlPantallaEgreso = CtlEgresos.Instancia

        Dim ctlOrdMedicas As ctlOrdenesMedicas
        ctlOrdMedicas = ctlOrdenesMedicas.Instancia

        If Not ctlOrdMedicas Is Nothing Then
            If ctlOrdMedicas.existenDatosSinAlmacenar() Then
                If ctlOrdMedicas.Visible = False Then
                    Me.btnOrdenes_Click(Me.btnOrdenes, New EventArgs())
                End If
                Select Case MessageBox.Show("No se ha guardado la informaci?n registrada, perder? los cambios realizados ?desea continuar?", "Historia Clinica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    Case Windows.Forms.DialogResult.OK
                        ctlOrdenesMedicas.Instancia.datosSinAlmacenar = False
                    Case Windows.Forms.DialogResult.Cancel
                        Exit Sub
                End Select
            End If
        End If

        pintarMenu(OpcionesMenu.Egreso)
        cambiarFondo(OpcionesMenu.Egreso)

        pnlContenedorListaEspera.Visible = False
        pnlContenedorPantallas.Visible = True

        'Me.pnlContenedorDatos.Controls.Clear()

        If Me.strNameControlLoad.Trim.Length > 0 And strNameControlLoad.ToUpper <> "CTLEGRESOS" Then
            pnlContenedorDatos.Controls(strNameControlLoad).Visible = False
            strNameControlLoad = "CtlEgresos"
        End If

        If blnCtlEgresos = False Then
            ctlPantallaEgreso.Dock = DockStyle.Fill
            ctlPantallaEgreso.Size = pnlContenedorDatos.Size
            ctlPantallaEgreso.AutoScroll = True
            Me.pnlContenedorDatos.Controls.Add(ctlPantallaEgreso)
            ctlPantallaEgreso.Show()
            ctlPantallaEgreso.AutoScrollPosition = New Point(0, 0)
            blnCtlEgresos = True
        Else

            pnlContenedorDatos.Controls("CtlEgresos").Visible = True
        End If
    End Sub


    'Ordenes M?dicas
    Private Sub btnOrdenes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOrdenes.Click

        If ValidarTraslado() = True Then
            Exit Sub
        End If


        Dim ctlPantallaOrdenes As ctlOrdenesMedicas = pnlContenedorDatos.Controls("ctlOrdenesMedicas")
        Dim puedeGenerarOrdenes As Boolean
        Dim objPaciente As Paciente
        Dim mensaje As String = ""

        ' Validar existencia de historia b?sica - Eloaiza@intergrupo.com - 18-11-2019
        If Not ValidarDatosHisBasica(Paciente.Instancia()) Then
            Exit Sub
        End If

        'aqui no entra
        If Not ctlPantallaOrdenes Is Nothing Then
            If ctlPantallaOrdenes.IsAccessible = False Then
                ctlPantallaOrdenes = Nothing
            End If
        End If

        If ctlPantallaOrdenes Is Nothing Then
            ''Validacion del estado de la admision para no permitir generar
            ''ordenes a las admisiones egresadas, trasladadas, anuladas o
            ''pendiente de pago
            objPaciente = Paciente.Instancia()
            puedeGenerarOrdenes = BLOrdenes.puedeGenerarOrdenes(objConexion, objDatosGenerales.Prestador,
                                  objDatosGenerales.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision,
                                  objPaciente.NumeroAdmision, mensaje)
            If Not puedeGenerarOrdenes Then
                MsgBox(mensaje, MsgBoxStyle.Information)
                Exit Sub
            End If

            ctlPantallaOrdenes = ctlOrdenesMedicas.Instancia
            blnCtlOrdenesMedicas = False
        Else
            blnCtlOrdenesMedicas = True
        End If

        'ctlPantallaOrdenes = ctlOrdenesMedicas.Instancia
        ''Inicia la carga del control
        pintarMenu(OpcionesMenu.OrdenesMedicas)
        cambiarFondo(OpcionesMenu.OrdenesMedicas)

        pnlContenedorListaEspera.Visible = False
        pnlContenedorPantallas.Visible = True

        'Me.pnlContenedorDatos.Controls.Clear()



        If Me.strNameControlLoad.Trim.Length > 0 And strNameControlLoad.ToUpper <> "CTLORDENESMEDICAS" Then
            pnlContenedorDatos.Controls(strNameControlLoad).Visible = False
            strNameControlLoad = "ctlOrdenesMedicas"
        End If


        If blnCtlOrdenesMedicas = False Then
            ctlPantallaOrdenes.Dock = DockStyle.Fill
            ctlPantallaOrdenes.Size = pnlContenedorDatos.Size
            ctlPantallaOrdenes.AutoScroll = True
            Me.pnlContenedorDatos.Controls.Add(ctlPantallaOrdenes)
            blnCtlOrdenesMedicas = True
            ctlPantallaOrdenes.Show()
        Else
            pnlContenedorDatos.Controls(strNameControlLoad).Visible = True
        End If

    End Sub

    Private Sub btnEvolucion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEvolucion.Click

        Dim ctlOrdMedicas As ctlOrdenesMedicas
        ctlOrdMedicas = ctlOrdenesMedicas.Instancia

        If Not ctlOrdMedicas Is Nothing Then
            If ctlOrdMedicas.existenDatosSinAlmacenar() Then
                If ctlOrdMedicas.Visible = False Then
                    Me.btnOrdenes_Click(Me.btnOrdenes, New EventArgs())
                End If
                Select Case MessageBox.Show("No se ha guardado la informaci?n registrada, perder? los cambios realizados ?desea continuar?", "Historia Clinica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    Case Windows.Forms.DialogResult.OK
                        ctlOrdenesMedicas.Instancia.datosSinAlmacenar = False
                    Case Windows.Forms.DialogResult.Cancel
                        Exit Sub
                End Select
            End If
        End If

        If Me.strNameControlLoad.Trim.Length > 0 And strNameControlLoad.ToUpper <> "ctlEvolucion" Then
            pnlContenedorDatos.Controls(strNameControlLoad).Visible = False

        End If

        'If Me.strNameControlLoad.Trim.Length > 0 Then
        '    pnlContenedorDatos.Controls(strNameControlLoad).Visible = False

        'End If
        'pnlContenedorDatos.Controls(strNameControlLoad).Visible = False

        CarcarPatallaEvolucion()
    End Sub

    Private Sub CarcarPatallaEvolucion()
        Dim ctlPantallaEvolucion As ctlEvolucion



        ctlPantallaEvolucion = ctlEvolucion.Instancia
        pintarMenu(OpcionesMenu.Evolucion)
        cambiarFondo(OpcionesMenu.Evolucion)

        pnlContenedorListaEspera.Visible = False
        pnlContenedorPantallas.Visible = True

        'Me.pnlContenedorDatos.Controls.Clear()

        If Me.strNameControlLoad.Trim.Length > 0 And strNameControlLoad.ToUpper <> "CTLEVOLUCION" Then
            pnlContenedorDatos.Controls(strNameControlLoad).Visible = False
            strNameControlLoad = "ctlEvolucion"
        End If

        If blnCtlEvolucion = False Then
            ctlPantallaEvolucion.Dock = DockStyle.Fill
            ctlPantallaEvolucion.Size = pnlContenedorDatos.Size
            ctlPantallaEvolucion.AutoScroll = True
            Me.pnlContenedorDatos.Controls.Add(ctlPantallaEvolucion)
            ctlPantallaEvolucion.Show()
            ctlPantallaEvolucion.AutoScrollPosition = New Point(0, 0)
            blnCtlEvolucion = True
        Else
            pnlContenedorDatos.Controls("ctlEvolucion").Visible = True
        End If
        pnlContenedorEnf.Visible = True ''cpgaray
    End Sub

    Private Sub btnFormulacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormulacion.Click
        Dim ctlPantallaFormulacionExt As CtlPlanFormuExterna

        ctlPantallaFormulacionExt = CtlPlanFormuExterna.Instancia

        cambiarFondo(OpcionesMenu.Formulacion)

        pnlContenedorListaEspera.Visible = False
        pnlContenedorPantallas.Visible = True
        pnlContenedorSecciones.Visible = False
        pnlContenedorSeccionesOM.Visible = False
        pnlContenedorEnf.Visible = False ''cpgaray

        'Me.pnlContenedorDatos.Controls.Clear()

        If Me.strNameControlLoad.Trim.Length > 0 And strNameControlLoad.ToUpper <> "CTLPLANFORMUEXTERNA" Then
            pnlContenedorDatos.Controls(strNameControlLoad).Visible = False
            strNameControlLoad = "CtlPlanFormuExterna"
        End If


        If blnCtlPlanFormuExterna = False Then
            ctlPantallaFormulacionExt.Dock = DockStyle.Fill
            ctlPantallaFormulacionExt.Size = pnlContenedorDatos.Size
            ctlPantallaFormulacionExt.AutoScroll = True

            Me.pnlContenedorDatos.Controls.Add(ctlPantallaFormulacionExt)
            blnCtlPlanFormuExterna = True
            ctlPantallaFormulacionExt.Show()
        Else
            pnlContenedorDatos.Controls("CtlPlanFormuExterna").Visible = True
        End If
    End Sub

    Public Sub btnProcedimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcedimientos.Click

        Dim ctlPantallaProcedimExt As ctlPlanProcExternos = pnlContenedorDatos.Controls("ctlPlanProcExternos")

        If ctlPantallaProcedimExt Is Nothing Then
            ctlPantallaProcedimExt = ctlPlanProcExternos.Instancia
            blnCtlPlanProcExternos = False
        Else
            blnCtlPlanProcExternos = True
        End If

        cambiarFondo(OpcionesMenu.Procedimientos)

        pnlContenedorListaEspera.Visible = False
        pnlContenedorPantallas.Visible = True
        pnlContenedorSecciones.Visible = False
        pnlContenedorSeccionesOM.Visible = False
        pnlContenedorEnf.Visible = False ''cpgaray

        'Me.pnlContenedorDatos.Controls.Clear()

        If Me.strNameControlLoad.Trim.Length > 0 And strNameControlLoad.ToUpper <> "CTLPLANPROCEXTERNOS" Then
            pnlContenedorDatos.Controls(strNameControlLoad).Visible = False
            strNameControlLoad = "ctlPlanProcExternos"
        End If


        If blnCtlPlanProcExternos = False Then
            ctlPantallaProcedimExt.Dock = DockStyle.Fill
            ctlPantallaProcedimExt.Size = pnlContenedorDatos.Size
            ctlPantallaProcedimExt.AutoScroll = True
            Me.pnlContenedorDatos.Controls.Add(ctlPantallaProcedimExt)
            blnCtlPlanProcExternos = True
            ctlPantallaProcedimExt.Show()
        Else
            If pnlContenedorDatos.Controls("ctlPlanProcExternos").Visible = True Then
                pnlContenedorDatos.Controls("ctlPlanProcExternos").Visible = False
            End If
            pnlContenedorDatos.Controls("ctlPlanProcExternos").Visible = True
            'ctlPantallaProcedimExt.Visible = True
        End If
    End Sub

    Private Sub btnIncapacidad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncapacidad.Click

        IniciaIncapacidad()

        '' El siguiente codigo se recoje en el metodo IniciaIncapacidad con el 
        '' fin de acceder a el desde otras formas
        '' Claudia Garay
        '' 12/agosto/2009

        'Dim ctlPantallaIncapacidad As ctlPlanIncapacidad

        'cambiarFondo(OpcionesMenu.Incapacidad)

        'ctlPantallaIncapacidad = ctlPlanIncapacidad.Instancia

        'pnlContenedorListaEspera.Visible = False
        'pnlContenedorPantallas.Visible = True
        'pnlContenedorSecciones.Visible = False
        'pnlContenedorSeccionesOM.Visible = False

        ''Me.pnlContenedorDatos.Controls.Clear()

        'If Me.strNameControlLoad.Trim.Length > 0 And strNameControlLoad.ToUpper <> "CTLPLANINCAPACIDAD" Then
        '    pnlContenedorDatos.Controls(strNameControlLoad).Visible = False
        '    strNameControlLoad = "ctlPlanIncapacidad"
        'End If


        'If blnCtlPlanIncapacidad = False Then
        '    ctlPantallaIncapacidad.Dock = DockStyle.Fill
        '    ctlPantallaIncapacidad.Size = pnlContenedorDatos.Size
        '    ctlPantallaIncapacidad.AutoScroll = True
        '    Me.pnlContenedorDatos.Controls.Add(ctlPantallaIncapacidad)
        '    blnCtlPlanIncapacidad = True
        '    ctlPantallaIncapacidad.Show()
        'Else
        '    pnlContenedorDatos.Controls("ctlPlanIncapacidad").Visible = True
        'End If
    End Sub

    Public Sub IniciaIncapacidad()
        Dim ctlPantallaIncapacidad As ctlPlanIncapacidad

        cambiarFondo(OpcionesMenu.Incapacidad)

        ctlPantallaIncapacidad = ctlPlanIncapacidad.Instancia

        pnlContenedorListaEspera.Visible = False
        pnlContenedorPantallas.Visible = True
        pnlContenedorSecciones.Visible = False
        pnlContenedorSeccionesOM.Visible = False
        pnlContenedorEnf.Visible = False ''cpgaray

        'Me.pnlContenedorDatos.Controls.Clear()

        If Me.strNameControlLoad.Trim.Length > 0 And strNameControlLoad.ToUpper <> "CTLPLANINCAPACIDAD" Then
            pnlContenedorDatos.Controls(strNameControlLoad).Visible = False
            strNameControlLoad = "ctlPlanIncapacidad"
        End If


        If blnCtlPlanIncapacidad = False Then
            ctlPantallaIncapacidad.Dock = DockStyle.Fill
            ctlPantallaIncapacidad.Size = pnlContenedorDatos.Size
            ctlPantallaIncapacidad.AutoScroll = True
            Me.pnlContenedorDatos.Controls.Add(ctlPantallaIncapacidad)
            blnCtlPlanIncapacidad = True
            ctlPantallaIncapacidad.Show()
        Else
            pnlContenedorDatos.Controls("ctlPlanIncapacidad").Visible = True
        End If
    End Sub

    Public Sub IniciaFormulacionExterna()
        Dim ctlFormulacionExterna As CtlPlanFormuExterna

        cambiarFondo(OpcionesMenu.PlanManejo)

        ctlFormulacionExterna = CtlPlanFormuExterna.Instancia

        pnlContenedorListaEspera.Visible = False
        pnlContenedorPantallas.Visible = True
        pnlContenedorSecciones.Visible = False
        pnlContenedorSeccionesOM.Visible = False
        pnlContenedorEnf.Visible = False

        If Me.strNameControlLoad.Trim.Length > 0 And strNameControlLoad.ToUpper <> "CTLPLANFORMUEXTERNA" Then
            pnlContenedorDatos.Controls(strNameControlLoad).Visible = False
            strNameControlLoad = "CtlPlanFormuExterna"
        End If


        If blnCtlPlanFormuExterna = False Then
            ctlFormulacionExterna.Dock = DockStyle.Fill
            ctlFormulacionExterna.Size = pnlContenedorDatos.Size
            ctlFormulacionExterna.AutoScroll = True
            Me.pnlContenedorDatos.Controls.Add(ctlFormulacionExterna)
            blnCtlPlanFormuExterna = True
            ctlFormulacionExterna.Show()
        Else
            pnlContenedorDatos.Controls("CtlPlanFormuExterna").Visible = True
        End If
    End Sub



    Public Sub btnRemisiones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemisiones.Click
        Dim ctlPantallaRemision As ctlPlanRemision

        ctlPantallaRemision = ctlPlanRemision.Instancia
        cambiarFondo(OpcionesMenu.Remision)

        pnlContenedorListaEspera.Visible = False
        pnlContenedorPantallas.Visible = True
        pnlContenedorSecciones.Visible = False
        pnlContenedorSeccionesOM.Visible = False
        pnlContenedorEnf.Visible = False ''cpgaray

        'Me.pnlContenedorDatos.Controls.Clear()

        If Me.strNameControlLoad.Trim.Length > 0 And strNameControlLoad.ToUpper <> "CTLPLANREMISION" Then
            pnlContenedorDatos.Controls(strNameControlLoad).Visible = False
            strNameControlLoad = "ctlPlanRemision"
        End If


        If blnCtlPlanRemision = False Then
            ctlPantallaRemision.Dock = DockStyle.Fill
            ctlPantallaRemision.Size = pnlContenedorDatos.Size
            ctlPantallaRemision.AutoScroll = True
            Me.pnlContenedorDatos.Controls.Add(ctlPantallaRemision)
            blnCtlPlanRemision = True
            ctlPantallaRemision.Show()
        Else
            If pnlContenedorDatos.Controls("ctlPlanRemision").Visible = True Then
                pnlContenedorDatos.Controls("ctlPlanRemision").Visible = True = False
            End If
            pnlContenedorDatos.Controls("ctlPlanRemision").Visible = True
        End If
    End Sub

    Private Sub btnRecomendaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRecomendaciones.Click

        IraRecomendaciones()

        '' El siguiente codigo se recoje en el metodo IraRecomendaciones con el 
        '' fin de acceder a el desde otras formas
        '' Claudia Garay
        '' 12/agosto/2009

        'Dim ctlPantallaRecomEgreso As ctlRecomEgreso

        'ctlPantallaRecomEgreso = ctlRecomEgreso.Instancia

        'cambiarFondo(OpcionesMenu.Recomendaciones)

        'pnlContenedorListaEspera.Visible = False
        'pnlContenedorPantallas.Visible = True
        'pnlContenedorSecciones.Visible = False
        'pnlContenedorSeccionesOM.Visible = False

        ''Me.pnlContenedorDatos.Controls.Clear()

        'If Me.strNameControlLoad.Trim.Length > 0 And strNameControlLoad.ToUpper <> "CTLRECOMEGRESO" Then
        '    pnlContenedorDatos.Controls(strNameControlLoad).Visible = False
        '    strNameControlLoad = "ctlRecomEgreso"
        'End If


        'If blnCtlRecomEgreso = False Then
        '    ctlPantallaRecomEgreso.Dock = DockStyle.Fill
        '    ctlPantallaRecomEgreso.Size = pnlContenedorDatos.Size
        '    ctlPantallaRecomEgreso.AutoScroll = True
        '    Me.pnlContenedorDatos.Controls.Add(ctlPantallaRecomEgreso)
        '    blnCtlRecomEgreso = True
        '    ctlPantallaRecomEgreso.Show()
        'Else
        '    pnlContenedorDatos.Controls("ctlRecomEgreso").Visible = True
        'End If
    End Sub

    Public Sub IraRecomendaciones()
        Dim ctlPantallaRecomEgreso As ctlRecomEgreso

        ctlPantallaRecomEgreso = ctlRecomEgreso.Instancia

        cambiarFondo(OpcionesMenu.Recomendaciones)

        pnlContenedorListaEspera.Visible = False
        pnlContenedorPantallas.Visible = True
        pnlContenedorSecciones.Visible = False
        pnlContenedorSeccionesOM.Visible = False
        pnlContenedorEnf.Visible = False ''cpgaray

        'Me.pnlContenedorDatos.Controls.Clear()

        If Me.strNameControlLoad.Trim.Length > 0 And strNameControlLoad.ToUpper <> "CTLRECOMEGRESO" Then
            pnlContenedorDatos.Controls(strNameControlLoad).Visible = False
            strNameControlLoad = "ctlRecomEgreso"
        End If


        If blnCtlRecomEgreso = False Then
            ctlPantallaRecomEgreso.Dock = DockStyle.Fill
            ctlPantallaRecomEgreso.Size = pnlContenedorDatos.Size
            ctlPantallaRecomEgreso.AutoScroll = True
            Me.pnlContenedorDatos.Controls.Add(ctlPantallaRecomEgreso)
            blnCtlRecomEgreso = True
            ctlPantallaRecomEgreso.Show()
        Else
            pnlContenedorDatos.Controls("ctlRecomEgreso").Visible = True
        End If
    End Sub

    ''' <summary>
    ''' Evento que muestra las opciones de consulta
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnConsultas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultas.Click

        If Me.strNameControlLoad.Trim.Length > 0 Then
            pnlContenedorDatos.Controls(strNameControlLoad).Visible = False

        End If

        If blnListaEsperaError = True Then
            pintarMenu(OpcionesMenu.ConsultasListaEsperaError)
        Else
            pintarMenu(OpcionesMenu.Consultas)
        End If
    End Sub

    ''' <summary>
    ''' Evento que muestra la forma de consulta de las historias clinicas
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnConsultaHC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaHC.Click
        Dim objPaciente As Paciente
        Dim dtgPacientes As DataGridView
        Dim controlListaEspera As ListaEspera
        ' Dim DatosPac As New ListaEspera

        ''Validacion de los parametros de entrada suministrador por sophia
        If objDatosGenerales Is Nothing Then
            MsgBox("No existen parametros de entrada.", MsgBoxStyle.Information)
            Exit Sub
        End If

        ''Se obtiene el control Activo del contenedor de datos
        'controlListaEspera = pnlContenedorListaEspera.Controls("ListaEspera")
        controlListaEspera = ListaEspera.Instancia

        ''Si el control activo es la lista de espera
        If Not controlListaEspera Is Nothing Then
            dtgPacientes = controlListaEspera.dtgLista

            If dtgPacientes.CurrentRow Is Nothing Then

                If controlListaEspera.DatosBasicosPac.Count > 0 Then
                    frmConsultaHC.mostrar(controlListaEspera.DatosBasicosPac(1), controlListaEspera.DatosBasicosPac(0))
                    Exit Sub
                Else
                    frmConsultaHC.Show()
                    Exit Sub
                End If
            End If
            With dtgPacientes.CurrentRow
                If Len(.Cells("nombre").Value.ToString.Trim) <= 0 Then
                    frmConsultaHC.ShowDialog()
                Else



                    If controlListaEspera.DatosBasicosPac.Count > 0 Then

                        frmConsultaHC.mostrar(controlListaEspera.DatosBasicosPac(1), controlListaEspera.DatosBasicosPac(0))
                    Else
                        frmConsultaHC.mostrar(.Cells("tip_doc").Value, .Cells("num_doc").Value)
                    End If
                End If
            End With
        Else
            objPaciente = Paciente.Instancia()
            If Not objPaciente Is Nothing Then
                frmConsultaHC.mostrar(objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
            End If
        End If

    End Sub

    ''' <summary>
    ''' Evento que invoca el metodo para consultar y pintar el reporte del 
    ''' ultimo triage grabado para el cliente. Si el medico esta en la lista
    ''' de espera los datos se toman de la grilla de pacientes en la fila
    ''' seleccionada. Si la historia clinica esta abierta la informacion del
    ''' paciente se toma del objeto singleton Paciente que es creado y llenado
    ''' por el control ListaEspera cuando abre la historia.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>

    Private Sub btnTriage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTriage.Click
        Dim objPaciente As Paciente
        Dim dtgPacientes As DataGridView
        Dim controlListaEspera As ListaEspera

        ''Validacion de los parametros de entrada suministrador por sophia
        If objDatosGenerales Is Nothing Then
            MsgBox("No existen parametros de entrada.", MsgBoxStyle.Information)
            Exit Sub
        End If

        ''Se obtiene el control Activo del contenedor de datos
        'controlListaEspera = pnlContenedorListaEspera.Controls("ListaEspera")
        controlListaEspera = ListaEspera.Instancia

        ''Si el control activo es la lista de espera
        If Not controlListaEspera Is Nothing Then
            Dim objP As Paciente
            'Los datos del paciente se toman del regitro seleccionado
            'en la grilla de pacientes
            dtgPacientes = controlListaEspera.dtgLista
            objP = Paciente.Instancia()
            If dtgPacientes.CurrentRow Is Nothing Then
                MsgBox("Debe elegir primero un paciente.", MsgBoxStyle.Information)
                Exit Sub
            End If

            With dtgPacientes.CurrentRow
                If Len(.Cells("nombre").Value.ToString.Trim) <= 0 Then
                    MsgBox("Debe elegir primero un paciente.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
                'Juan Carlos Jaramillo Lozano - IG
                RptHC_Enf_Med.Show()
                RptHC_Enf_Med.ImprimirHistoriaClinica_Triage_1(objConexion, "53", objDatosGenerales.Prestador,
                                    objDatosGenerales.Sucursal,
                                    .Cells("tip_doc").Value, .Cells("num_doc").Value,
                                    .Cells("tip_admision").Value, .Cells("ano_adm").Value,
                                    .Cells("num_adm").Value, objP.CodHistoria)
                '2019-03-11 Fin
            End With
        Else
            ''Si la historia esta abierta se obtiene la instancia del paciente
            ''creada cuando de abre la historia.
            objPaciente = Paciente.Instancia()
            If Not objPaciente Is Nothing Then
                '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
                'Juan Carlos Jaramillo Lozano - IG
                RptHC_Enf_Med.Show()
                RptHC_Enf_Med.ImprimirHistoriaClinica_Triage(objConexion, "53")
                '2019-03-11 Fin

                'frmRepTriage.Show()
                'frmRepTriage.imprimirTriage(objConexion, objDatosGenerales.Prestador, objDatosGenerales.Sucursal,
                '                        objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                '                        objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
                '                        Paciente.TipoPacienteTriage(objPaciente.Edad))
            End If
        End If
        'Dim objPaciente As Paciente
        'Dim dtgPacientes As DataGridView
        'Dim controlListaEspera As ListaEspera

        '''Validacion de los parametros de entrada suministrador por sophia
        'If objDatosGenerales Is Nothing Then
        '    MsgBox("No existen parametros de entrada.", MsgBoxStyle.Information)
        '    Exit Sub
        'End If

        '''Se obtiene el control Activo del contenedor de datos
        ''controlListaEspera = pnlContenedorListaEspera.Controls("ListaEspera")
        'controlListaEspera = ListaEspera.Instancia

        '''Si el control activo es la lista de espera
        'If Not controlListaEspera Is Nothing Then

        '    'Los datos del paciente se toman del regitro seleccionado
        '    'en la grilla de pacientes
        '    dtgPacientes = controlListaEspera.dtgLista

        '    If dtgPacientes.CurrentRow Is Nothing Then
        '        MsgBox("Debe elegir primero un paciente.", MsgBoxStyle.Information)
        '        Exit Sub
        '    End If

        '    With dtgPacientes.CurrentRow
        '        If Len(.Cells("nombre").Value.ToString.Trim) <= 0 Then
        '            MsgBox("Debe elegir primero un paciente.", MsgBoxStyle.Information)
        '            Exit Sub
        '        End If

        '        frmRepTriage.Show()
        '        frmRepTriage.imprimirTriage(objConexion, objDatosGenerales.Prestador,
        '                            objDatosGenerales.Sucursal,
        '                            .Cells("tip_doc").Value, .Cells("num_doc").Value,
        '                            .Cells("tip_admision").Value, .Cells("ano_adm").Value,
        '                            .Cells("num_adm").Value,
        '                            Paciente.TipoPacienteTriage(.Cells("edad").Value))
        '    End With
        'Else
        '    ''Si la historia esta abierta se obtiene la instancia del paciente
        '    ''creada cuando de abre la historia.
        '    objPaciente = Paciente.Instancia()
        '    If Not objPaciente Is Nothing Then
        '        frmRepTriage.Show()
        '        frmRepTriage.imprimirTriage(objConexion, objDatosGenerales.Prestador, objDatosGenerales.Sucursal,
        '                                objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
        '                                objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision,
        '                                Paciente.TipoPacienteTriage(objPaciente.Edad))
        '    End If
        'End If

    End Sub

    ''' <summary>
    ''' Evento que invoca el reporte de reimpresion de admision para la admision 
    ''' del paciente elegido en la grilla de la lista de espera o el paciente 
    ''' para el cual esta abierta la historia clinica. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAdmision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdmision.Click
        Dim objPaciente As Paciente
        Dim dtgPacientes As DataGridView
        Dim controlListaEspera As ListaEspera
        Dim objP As Paciente
        objP = Paciente.Instancia()
        ''Validacion de los parametros de entrada suministrador por sophia
        If objDatosGenerales Is Nothing Then
            MsgBox("No existen parametros de entrada.", MsgBoxStyle.Information)
            Exit Sub
        End If

        ''Se obtiene el control Activo del contenedor de datos
        'controlListaEspera = pnlContenedorListaEspera.Controls("ListaEspera")
        controlListaEspera = ListaEspera.Instancia

        ''Si el control activo es la lista de espera
        If Not controlListaEspera Is Nothing Then

            'Los datos del paciente se toman del regitro seleccionado
            'en la grilla de pacientes
            dtgPacientes = controlListaEspera.dtgLista

            If dtgPacientes.CurrentRow Is Nothing Then
                MsgBox("Debe elegir primero un paciente.", MsgBoxStyle.Information)
                Exit Sub
            End If

            With dtgPacientes.CurrentRow
                If Len(.Cells("nombre").Value.ToString.Trim) <= 0 Then
                    MsgBox("Debe elegir primero un paciente.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
                'Juan Carlos Jaramillo Lozano - IG
                RptHC_Enf_Med.Show()
                RptHC_Enf_Med.ImprimirHistoriaClinica_Admision_1(objConexion, "54", objDatosGenerales.Prestador, objDatosGenerales.Sucursal,
                                                   .Cells("tip_doc").Value.ToString, .Cells("num_doc").Value,
                                                   .Cells("tip_admision").Value, .Cells("ano_adm").Value,
                                                   .Cells("num_adm").Value, objP.CodHistoria)
                '2019-03-11 Fin

                'frmReimpresionAdm.Show()
                'frmReimpresionAdm.ReimprirAdmision(objConexion, 3, objDatosGenerales.Prestador, objDatosGenerales.Sucursal,
                '                                   .Cells("tip_doc").Value.ToString, .Cells("num_doc").Value,
                '                                   .Cells("tip_admision").Value, .Cells("ano_adm").Value,
                '                                   .Cells("num_adm").Value)
            End With
        Else
            ''Si la historia esta abierta se obtiene la instancia del paciente
            ''creada cuando de abre la historia.
            objPaciente = Paciente.Instancia()
            If Not objPaciente Is Nothing Then
                '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
                'Juan Carlos Jaramillo Lozano - IG
                RptHC_Enf_Med.Show()
                RptHC_Enf_Med.ImprimirHistoriaClinica_Admision(objConexion, "54")
                '2019-03-11 Fin

                'frmReimpresionAdm.Show()
                'frmReimpresionAdm.ReimprirAdmision(objConexion, 3, objDatosGenerales.Prestador, objDatosGenerales.Sucursal,
                '                                   objPaciente.TipoDocumento, objPaciente.NumeroDocumento,
                '                                   objPaciente.TipoAdmision, objPaciente.AnoAdmision, objPaciente.NumeroAdmision)
            End If
        End If
    End Sub

    ''' <summary>
    ''' Pinta las opciones desplegadas para el plan de manejo
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPlanManejo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlanManejo.Click
        Dim ctlOrdMedicas As ctlOrdenesMedicas
        ctlOrdMedicas = ctlOrdenesMedicas.Instancia

        If Not ctlOrdMedicas Is Nothing Then
            If ctlOrdMedicas.existenDatosSinAlmacenar() Then
                If ctlOrdMedicas.Visible = False Then
                    Me.btnOrdenes_Click(Me.btnOrdenes, New EventArgs())
                End If
                Select Case MessageBox.Show("No se ha guardado la informaci?n registrada, perder? los cambios realizados ?desea continuar?", "Historia Clinica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    Case Windows.Forms.DialogResult.OK
                        ctlOrdenesMedicas.Instancia.datosSinAlmacenar = False
                    Case Windows.Forms.DialogResult.Cancel
                        Exit Sub
                End Select
            End If
        End If

        If Me.strNameControlLoad.Trim.Length > 0 Then
            pnlContenedorDatos.Controls(strNameControlLoad).Visible = False

        End If

        PintarOpcionesManejoExterno()
    End Sub
    Public Sub PintarOpcionesManejoExterno()
        pintarMenu(OpcionesMenu.PlanManejo)
        cambiarFondo(OpcionesMenu.PlanManejo)
    End Sub


    ''' <summary>
    ''' Funcion que pinta el menu de acuerdo a las posibles configuraciones
    ''' que se encuentran en la enumeracion OpcionesMenu. Esta opcion se 
    ''' determina de acuerdo al tipo de admision y si esta en la lista de
    ''' espera o en la historia clinica como tal. 
    ''' </summary>
    ''' <param name="opcion"></param>
    ''' <remarks></remarks>
    Public Sub pintarMenu(ByVal opcion As OpcionesMenu)
        inicializarBotones()
        Select Case opcion
            Case OpcionesMenu.ListaEspera
                pnlListaHCBasica.Visible = False
                btnPlanManejo.Visible = False
                pnlMenuPlanManejo.Visible = False
                pnlOrdenesEvolEgreso.Visible = False
                pnlMenuInicial.Visible = True
                pnlMenuConsultas.Visible = False
                btnResultadosLaboratorio.Visible = False
                pnlMenuInicial.Location = pnlListaHCBasica.Location
                pnlContenedorSecciones.Visible = False
                pnlContenedorSeccionesOM.Visible = False
                pnlContenedorEnf.Visible = False ''cpgaray
                Me.PnlProgramas.Visible = False
                Me.btnProgramas.Visible = False

            Case OpcionesMenu.HistoriaClinica
                pnlListaHCBasica.Visible = True
                btnPlanManejo.Visible = True
                pnlMenuPlanManejo.Visible = False
                pnlOrdenesEvolEgreso.Visible = True
                pnlMenuInicial.Visible = True
                pnlMenuConsultas.Visible = False
                btnResultadosLaboratorio.Visible = False
                pnlMenuInicial.Left = pnlMenuInicial.Left + pnlListaHCBasica.Size.Width
                pnlContenedorSecciones.Visible = False
                pnlContenedorSeccionesOM.Visible = False
                pnlContenedorEnf.Visible = False ''cpgaray
                Me.PnlProgramas.Visible = False
                Me.btnProgramas.Visible = True

            Case OpcionesMenu.PlanManejo
                btnPlanManejo.Image = My.Resources.act_ManejoExt
                pnlMenuConsultas.Visible = False
                btnResultadosLaboratorio.Visible = False
                pnlMenuPlanManejo.Visible = True
                pnlMenuPlanManejo.Left = pnlListaHCBasica.Left
                pnlContenedorEnf.Visible = False ''cpgaray
                Me.PnlProgramas.Visible = False

            Case OpcionesMenu.HistoriaBasica
                cmdHistoriaBasica.Image = My.Resources.act_10
                pnlMenuConsultas.Visible = False
                btnResultadosLaboratorio.Visible = False
                pnlMenuPlanManejo.Visible = False
                pnlContenedorSecciones.Visible = True
                pnlContenedorSeccionesOM.Visible = False
                pnlContenedorEnf.Visible = False ''cpgaray
                Me.PnlProgramas.Visible = False

            Case OpcionesMenu.OrdenesMedicas
                btnOrdenes.Image = My.Resources.act_3
                pnlMenuConsultas.Visible = False
                btnResultadosLaboratorio.Visible = False
                pnlMenuPlanManejo.Visible = False
                pnlContenedorSecciones.Visible = False
                pnlContenedorSeccionesOM.Visible = True
                pnlContenedorEnf.Visible = False ''cpgaray
                Me.PnlProgramas.Visible = False

            Case OpcionesMenu.Evolucion
                btnEvolucion.Image = My.Resources.act_4
                pnlMenuConsultas.Visible = False
                btnResultadosLaboratorio.Visible = False
                pnlMenuPlanManejo.Visible = False
                pnlContenedorSecciones.Visible = False
                pnlContenedorSeccionesOM.Visible = False
                pnlContenedorEnf.Visible = True ''cpgaray
                Me.PnlProgramas.Visible = False

            Case OpcionesMenu.Egreso
                btnEgreso.Image = My.Resources.act_5
                pnlMenuConsultas.Visible = False
                btnResultadosLaboratorio.Visible = False
                pnlMenuPlanManejo.Visible = False
                pnlContenedorSecciones.Visible = False
                pnlContenedorSeccionesOM.Visible = False
                pnlContenedorEnf.Visible = False ''cpgaray
                Me.PnlProgramas.Visible = False

            Case OpcionesMenu.Consultas ''lista
                btnConsultas.Image = My.Resources.act_6
                pnlMenuConsultas.Visible = True
                btnResultadosLaboratorio.Visible = True
                pnlMenuPlanManejo.Visible = False
                pnlContenedorEnf.Visible = False ''cpgaray
                pnlMenuConsultas.Left = pnlListaHCBasica.Left 'pnlMenuInicial.Left
                If (pnlMenuConsultas.Size.Width + pnlMenuConsultas.Left) > Me.Size.Width Then
                    pnlMenuConsultas.Left = 420
                End If
                Me.PnlProgramas.Visible = False

            Case OpcionesMenu.NotasAclaratorias
                btnNotas.Image = My.Resources.act_9
                pnlMenuConsultas.Visible = False
                btnResultadosLaboratorio.Visible = False
                pnlMenuPlanManejo.Visible = False
                pnlContenedorSecciones.Visible = False
                pnlContenedorSeccionesOM.Visible = False
                pnlContenedorEnf.Visible = False ''cpgaray
                Me.PnlProgramas.Visible = False
            Case OpcionesMenu.ConsultasListaEsperaError
                btnConsultas.Image = My.Resources.act_6
                pnlMenuConsultas.Visible = True
                btnResultadosLaboratorio.Visible = True
                btnAdmision.Visible = False
                btnConsultaOrdenesMedicas.Visible = False
                btnConsultaResultados.Visible = False
                btnTriage.Visible = False
                btnConsultaHC.Left = btnTriage.Left
                pnlMenuPlanManejo.Visible = False
                pnlContenedorEnf.Visible = False ''cpgaray
                pnlMenuConsultas.Left = pnlMenuInicial.Left
                If (pnlMenuConsultas.Size.Width + pnlMenuConsultas.Left) > Me.Size.Width Then
                    pnlMenuConsultas.Left = 420
                End If
                Me.PnlProgramas.Visible = False

            Case OpcionesMenu.CuidadosPaliativos ''Cuidados Paliativos
                PnlProgramas.Visible = True
            Case Else
                pnlMenuConsultas.Visible = False
                pnlMenuPlanManejo.Visible = False
                pnlContenedorSecciones.Visible = False
                pnlContenedorSeccionesOM.Visible = False
                pnlContenedorEnf.Visible = False ''cpgaray
                Me.PnlProgramas.Visible = False
        End Select

    End Sub

    Public Sub inicializarBotones()
        btnPlanManejo.Image = My.Resources.bot_ManejoExt
        cmdHistoriaBasica.Image = My.Resources.bot_10
        btnOrdenes.Image = My.Resources.bot_3
        btnEvolucion.Image = My.Resources.bot_4
        btnEgreso.Image = My.Resources.bot_5
        btnConsultas.Image = My.Resources.bot_6
        btnNotas.Image = My.Resources.bot_9
    End Sub

    Public Sub cambiarFondo(ByVal opcion As OpcionesMenu)
        Select Case opcion
            Case OpcionesMenu.ListaEspera
                pcTitulo.Image = My.Resources.tit_lista
            'Me.BackgroundImage = My.Resources.fondo_espera
            Case OpcionesMenu.PlanManejo
                'Me.BackgroundImage = My.Resources.fondo_manejo
            Case OpcionesMenu.Formulacion
                pcTitulo.Image = My.Resources.tit_formulacion
            Case OpcionesMenu.Procedimientos
                pcTitulo.Image = My.Resources.tit_procedimientos
            Case OpcionesMenu.Recomendaciones
                pcTitulo.Image = My.Resources.tit_recomendaciones
            Case OpcionesMenu.Remision
                pcTitulo.Image = My.Resources.tit_remision
            Case OpcionesMenu.Incapacidad
                pcTitulo.Image = My.Resources.tit_incapacidad
            Case OpcionesMenu.HistoriaBasica
                'TODO: CAMBIAR LA IMAGEN AL TITULO DE HISTORIA BASICA
                pcTitulo.Image = My.Resources.tit_historia_basica
            'Me.BackgroundImage = My.Resources.fondo_historia
            Case OpcionesMenu.OrdenesMedicas
                'TODO: COLOCAR LA IMAGEN DE ORDENES MEDICAS
                pcTitulo.Image = My.Resources.tit_ordenes_medicas
            'Me.BackgroundImage = My.Resources.fondo_ordenes
            Case OpcionesMenu.Evolucion
                pcTitulo.Image = My.Resources.tit_evolucion
            'Me.BackgroundImage = My.Resources.fondo_evolucion
            Case OpcionesMenu.Egreso
                pcTitulo.Image = My.Resources.tit_egreso
                'Me.BackgroundImage = My.Resources.fondo_egreso

        End Select
    End Sub

    ''' <summary>
    ''' Evento que despliega la forma de notas aclaratorias 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnNotas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNotas.Click
        Dim ctlOrdMedicas As ctlOrdenesMedicas
        ctlOrdMedicas = ctlOrdenesMedicas.Instancia

        If Not ctlOrdMedicas Is Nothing Then
            If ctlOrdMedicas.existenDatosSinAlmacenar() Then
                If ctlOrdMedicas.Visible = False Then
                    Me.btnOrdenes_Click(Me.btnOrdenes, New EventArgs())
                End If
                Select Case MessageBox.Show("No se ha guardado la informaci?n registrada, perder? los cambios realizados ?desea continuar?", "Historia Clinica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    Case Windows.Forms.DialogResult.OK
                        ctlOrdenesMedicas.Instancia.datosSinAlmacenar = False
                    Case Windows.Forms.DialogResult.Cancel
                        Exit Sub
                End Select
            End If
        End If

        If Me.strNameControlLoad.Trim.Length > 0 Then
            pnlContenedorDatos.Controls(strNameControlLoad).Visible = False

        End If

        pintarMenu(OpcionesMenu.NotasAclaratorias)
        frmNotasHC.ShowDialog()
    End Sub

    ''' <summary>
    ''' Evento que invoca la funcion salirHistoriaClinica con la cual se
    ''' presentan las opciones pertinentes al usuario para que escoja que 
    ''' quiere hacer al salir de la historia. Si el usuario elige cancelar
    ''' la funcion devuelve false pues no debe cerrar la pantalla principal
    ''' de historia clinica. Si el usuario elige salir se eliminan los objetos
    ''' que contiene los parametros de entrada. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmHistoriaPrincipal_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        ' se hace la validacion de datos de acuerdo a si ya fueron 
        ' almacenados los datos ingresados en procedimientos externos
        Dim ctlPantallaProcedimExt As ctlPlanProcExternos = pnlContenedorDatos.Controls("ctlPlanProcExternos")
        Dim ctlOrdMedicas As ctlOrdenesMedicas = pnlContenedorDatos.Controls("ctlOrdenesMedicas")

        'Procedimientos externos
        If Not ctlPantallaProcedimExt Is Nothing Then
            If ctlPantallaProcedimExt.existenDatosSinAlmacenar() Then
                If ctlPantallaProcedimExt.Visible = False Then
                    Me.btnProcedimientos_Click(Me.btnProcedimientos, New EventArgs())
                End If

                Select Case MessageBox.Show("Existe informaci?n sin Guardar correspondiente a los procedimientos registrados. Desea almacenar esta informaci?n?", "Historia Clinica", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case Windows.Forms.DialogResult.Yes
                        ''se almacenan los datos
                        ctlPantallaProcedimExt.guardarDatosGrid()
                    Case Windows.Forms.DialogResult.No
                        'La informaci?n registrada en esta pantalla  que no ha sido guardada se perder? definitivamente
                        Select Case MessageBox.Show("La informaci?n registrada en esta pantalla  que no ha sido guardada se perder? definitivamente.", "Historia Clinica", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                            Case Windows.Forms.DialogResult.OK
                                'Exit Sub
                            Case Windows.Forms.DialogResult.Cancel
                                e.Cancel = True
                        End Select
                End Select
            End If
        End If

        'Ordenes Medicas
        If Not ctlOrdMedicas Is Nothing Then
            If ctlOrdMedicas.existenDatosSinAlmacenar() Then
                If ctlOrdMedicas.Visible = False Then
                    Me.btnOrdenes_Click(Me.btnOrdenes, New EventArgs())
                End If

                Select Case MessageBox.Show("Existe informaci?n sin Guardar correspondiente a Ordenes m?dicas. Desea almacenar esta informaci?n?", "Historia Clinica", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    Case Windows.Forms.DialogResult.Yes
                        ctlOrdMedicas.guardarDatosOrdenesMedicas()
                    Case Windows.Forms.DialogResult.No
                        'La informaci?n registrada en esta pantalla  que no ha sido guardada se perder? definitivamente
                        Select Case MessageBox.Show("La informaci?n registrada en esta pantalla  que no ha sido guardada se perder? definitivamente.", "Historia Clinica", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                            Case Windows.Forms.DialogResult.OK
                                'Exit Sub
                            Case Windows.Forms.DialogResult.Cancel
                                e.Cancel = True
                        End Select
                End Select
            End If
        End If

        If e.Cancel = False Then
            ''Si el paciente elige la opcion cancelar no se sale de la historia clinica
            If blnListaEsperaError = True Then
                Exit Sub
            End If
            If salirHistoriaClinica() = False Then
                e.Cancel = True
            Else
                'Si escoge salir de la historia clinica elimina los objetos que 
                'contienen los parametros iniciales
                BLEgresos.eliminarParametrosIniciales()
            End If
        End If

    End Sub

    ''' <summary>
    ''' Evento que cierra la forma principal. Solo invoca la 
    ''' funcion close de la forma ya que la salida se maneja en el evento formClosing
    ''' </summary>
    ''' <param name="sender"></param>0
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Dim ctlOrdMedicas As ctlOrdenesMedicas
        ctlOrdMedicas = ctlOrdenesMedicas.Instancia

        If Not ctlOrdMedicas Is Nothing Then
            If ctlOrdMedicas.existenDatosSinAlmacenar() Then
                If ctlOrdMedicas.Visible = False Then
                    Me.btnOrdenes_Click(Me.btnOrdenes, New EventArgs())
                End If
                Select Case MessageBox.Show("No se ha guardado la informaci?n registrada, perder? los cambios realizados ?desea continuar?", "Historia Clinica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    Case Windows.Forms.DialogResult.OK
                        ctlOrdenesMedicas.Instancia.datosSinAlmacenar = False
                    Case Windows.Forms.DialogResult.Cancel
                        Exit Sub
                End Select
            End If
        End If

        If Me.strNameControlLoad.Trim.Length > 0 Then
            pnlContenedorDatos.Controls(strNameControlLoad).Visible = False

        End If

        '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
        'Juan Carlos Jaramillo Lozano - IG
        RptHC_Enf_Med.RptHC_Enf_Med_FormEstado(objConexion, "1", "C", "")
        '2019-03-11 Fin

        Me.Close()
    End Sub

    ''' <summary>
    ''' Funcion que realiza las validaciones y respectivas actualizaciones a 
    ''' la historia clinica cuando el usuario quiere salirse de la misma, bien
    ''' sea pulsando en el boton lista de espera, en el boton salir o el 
    ''' icono de salir(X) de la forma principal.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function salirHistoriaClinica() As Boolean
        Dim lError As Long = 0
        Dim lErrorR As Long = 0
        Dim mensaje As String = ""
        Dim estadoHistoria As String = ""
        Dim controlListaEspera As ListaEspera
        Dim opcionSalidaElegida As BLEgresos.OpcionSalida
        Dim opcionesMostradas As BLEgresos.configuracionOpciones
        Dim cumpleCondicionesObligatoriasDeSalida As Boolean
        Dim condicionIncumple As BLEgresos.CondicionesObligatorias
        Dim strResidente As String = ""
        Dim objdao As New DAOGeneral
        Dim objDaoBasica As New DAOHistoriaBasica
        Dim frmConsulta As New frmc_ConsultaMedico

        If objDatosGenerales Is Nothing Or objConexion Is Nothing Then
            Return True
        End If

        ''Si esta en la lista de espera se sale pues no hay historia abierta
        'controlListaEspera = pnlContenedorListaEspera.Controls("ListaEspera")
        controlListaEspera = ListaEspera.Instancia

        If controlListaEspera.Visible = True Then
            BLEgresos.eliminarObjetosHistoriaClinica()
            Return True
        End If

        ''Si no se realizaron modificaciones a la historia clinica se 
        ''devulve el estado de la historia clinica al estado que tenia en 
        ''el momento de abrir la historia. Ademas se destruyen los objetos 
        ''que guardan la informacion del paciente y las secciones de la HC
        If objDatosGenerales.HistoriaClinicaTieneModificaciones = False Then
            Try
                lError = BLEgresos.actualizarEstadoHistoriaClinica(objConexion, objDatosGenerales.Prestador, objDatosGenerales.Sucursal)
                If lError <> 0 Then
                    MsgBox("Error actualizando el estado en el encabezado de la histora clinica." & "Error " & lError, MsgBoxStyle.Information)
                End If
            Catch ex As Exception
                MsgBox("Error actualizando el estado en el encabezado de la histora clinica.", MsgBoxStyle.Information)
            End Try
            BLEgresos.eliminarObjetosHistoriaClinica()
            Return True
        End If


        ''Se validan las condiciones obligatorias de salida de la historia clinica
        cumpleCondicionesObligatoriasDeSalida = BLEgresos.cumpleCondicionesObligatoriasDeSalida(objConexion,
                                                                        objDatosGenerales.Prestador,
                                                                        objDatosGenerales.Sucursal,
                                                                        condicionIncumple, mensaje)
        If Not cumpleCondicionesObligatoriasDeSalida Then
            MsgBox("Debe digitar los siguientes datos obligatorios para salir: " & mensaje, MsgBoxStyle.Information)
            colocarFocoEnCampoRequerido(condicionIncumple)
            Return False
        End If

        ''Residente acreditacion marzo de 2011
        Try
            strResidente = objdao.EjecutarSQLStrValor("genmedic", objConexion, "residente", "medico='" & objGeneral.Generales.Instancia.Login & "'")
            If Not IsDBNull(strResidente) Then
                If strResidente <> "" Then
                    If strResidente = "S" Then
                        If MsgBox("La asistencia del paciente la realizo en compa??a de su instructor", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                            frmConsulta.ShowDialog()
                            If frmConsulta.ValidaSeleccion = 0 Then
                                Return False
                            End If
                        Else
                            lErrorR = objDaoBasica.AlmacenaMedicoResidente(objConexion, objDatosGenerales.Prestador, objDatosGenerales.Sucursal, Paciente.Instancia.TipoAdmision, Paciente.Instancia.AnoAdmision, Paciente.Instancia.NumeroAdmision, Paciente.Instancia.TipoDocumento, Paciente.Instancia.NumeroDocumento, "", objDatosGenerales.Login, objDatosGenerales.Login, "Sin Medico Acompa?ante")
                            If lErrorR <> 0 Then
                                MsgBox("Error al guardar los datos del residente", MsgBoxStyle.Critical, "Medico Residente")
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox("Error al guardar los datos del residente" & ex.Message, MsgBoxStyle.Critical)
        End Try

        ''Se determinan que opciones se deben presentar al usuario teniendo 
        ''en cuenta el estado de la historia clinica y el cumplimiento de las 
        ''condiciones de salida no obligatorias(Grabacion de algunos datos de egreso). Ademas
        ''se devuelve por referencia el estado de la historia clinica traida desde la bd.
        opcionesMostradas = BLEgresos.determinarOpcionesCliente(objConexion, objDatosGenerales, estadoHistoria, mensaje)

        If mensaje.Trim.Length > 0 Then
            MsgBox(mensaje, MsgBoxStyle.Information)
        End If

        ''Se pinta la forma que contiene los botones de acuedo a la configuracion
        ''de opciones determinada anteriormente(opcionesMostradas). La funcion retorna
        ''por referencia la opcion elegida por el usuario.
        frmOpcionesSalidaHC.mostrar(opcionSalidaElegida, opcionesMostradas)

        Select Case opcionSalidaElegida
            ''CERRAR LA HISTORIA CLINICA
            Case BLEgresos.OpcionSalida.CerrarHistoria And objDatosGenerales.Pais = "482"
                Try
                    lError = BLEgresos.cerrarHistoriaClinicaCE(objConexion, objDatosGenerales.Prestador, objDatosGenerales.Sucursal,
                                                    objDatosGenerales.Login)
                    If lError <> 0 Then
                        MsgBox("Se ha presentado un error en el proceso de grabacion al cerrar la historia clinica.", MsgBoxStyle.Exclamation)
                    End If
                Catch ex As Exception
                    MsgBox("Se ha generado Se ha presentado un error en el proceso de grabacion al cerrar la historia clinica. " & Err.Number, MsgBoxStyle.Exclamation)
                End Try

            Case BLEgresos.OpcionSalida.CerrarHistoria
                Try
                    lError = BLEgresos.cerrarHistoriaClinica(objConexion, objDatosGenerales.Prestador, objDatosGenerales.Sucursal,
                                                    objDatosGenerales.Login)
                    If lError <> 0 Then
                        MsgBox("Se ha presentado un error en el proceso de grabacion al cerrar la historia clinica.", MsgBoxStyle.Exclamation)
                    End If
                Catch ex As Exception
                    MsgBox("Se ha generado Se ha presentado un error en el proceso de grabacion al cerrar la historia clinica. " & Err.Number, MsgBoxStyle.Exclamation)
                End Try
            ''DEJAR EN OBSERVACION LA HISTORIA CLINICA
            Case BLEgresos.OpcionSalida.Observacion
                Try
                    If estadoHistoria <> Paciente.OBSERVACION And estadoHistoria <> "" Then
                        lError = BLEgresos.observacionHistoriaClinica(objConexion, objDatosGenerales.Prestador, objDatosGenerales.Sucursal)

                        If lError <> 0 Then
                            MsgBox("Se ha presentado un error en el proceso de grabacion al dejar en observaci?n la historia clinica.", MsgBoxStyle.Exclamation)
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("Se ha presentado un error en el proceso de grabacion al dejar en observaci?n la historia clinica. " & Err.Number, MsgBoxStyle.Exclamation)
                End Try

            ''DEJAR LA HISTORIA CLINICA PENDIENTE
            Case BLEgresos.OpcionSalida.Pendiente

                ''CANCELAR LA SALIDA DE LA HISTORIA CLINICA
            Case BLEgresos.OpcionSalida.Cancelar
                ''Si el usuario elige cancelar no se debe salirse de la pantalla 
                ''de actual de la historia clinica y no borra los objetos que 
                ''mantienen el estado
                Return False

        End Select

        ''Auditoria de apertura y cierres de historia
        ''Claudia Garay 
        ''Abril 5 de 2011
        Dim objHCB As New BLHistoriaBasica

        objHCB.ActualizaTablaAuditoria(objConexion, 0, objDatosGenerales.Prestador, objDatosGenerales.Sucursal,
        Paciente.Instancia.TipoAdmision, Paciente.Instancia.AnoAdmision, Paciente.Instancia.NumeroAdmision, objDatosGenerales.Login, "C", "")

        ''Elimina las instancias de los objetos que guardan el estado de 
        ''las diferentes secciones de la historia clinica(Datos digitados 
        ''y guardados por el usuario en la pantallas)
        BLEgresos.eliminarObjetosHistoriaClinica()




        Return True
    End Function

    Private Sub colocarFocoEnCampoRequerido(ByVal condicionIncumplida As BLEgresos.CondicionesObligatorias)

        Dim control As HCBasica


        If condicionIncumplida = BLEgresos.CondicionesObligatorias.MotivoConsulta Then
            cmdHistoriaBasica_Click(Me, New System.EventArgs())
            control = HCBasica.Instancia
            control.txtInfoSuministradaPor.Focus()
        ElseIf condicionIncumplida = BLEgresos.CondicionesObligatorias.EstadoDeConciencia Then
            cmdHistoriaBasica_Click(Me, New System.EventArgs())
            control = HCBasica.Instancia
            control.pnlDatosEF.Focus()
            control.txtCodEstadoConcienciaEF.Focus()
        ElseIf condicionIncumplida = BLEgresos.CondicionesObligatorias.DiagnosticoImpresionDiagnostica Then
            cmdHistoriaBasica_Click(Me, New System.EventArgs())
            control = HCBasica.Instancia
            control.pnlDatosImpresionDiagnostica.Focus()
            control.txtCodTipoDiagnosticoID.Focus()
        End If

    End Sub

    'Private Sub btnConsultaOrdenesMedicas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaOrdenesMedicas.Click
    '    Dim objPaciente As Paciente
    '    Dim dtgPacientes As DataGridView
    '    Dim controlListaEspera As ListaEspera

    '    ''Validacion de los parametros de entrada suministrador por sophia
    '    If objDatosGenerales Is Nothing Then
    '        MsgBox("No existen parametros de entrada.", MsgBoxStyle.Information)
    '        Exit Sub
    '    End If

    '    ''Se obtiene el control Activo del contenedor de datos
    '    'controlListaEspera = pnlContenedorListaEspera.Controls("ListaEspera")
    '    controlListaEspera = ListaEspera.Instancia

    '    ''Si el control activo es la lista de espera
    '    If Not controlListaEspera Is Nothing Then

    '        'Los datos del paciente se toman del regitro seleccionado
    '        'en la grilla de pacientes
    '        dtgPacientes = controlListaEspera.dtgLista

    '        If dtgPacientes.CurrentRow Is Nothing Then
    '            MsgBox("Debe elegir primero un paciente.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        With dtgPacientes.CurrentRow
    '            If Len(.Cells("nombre").Value.ToString.Trim) <= 0 Then
    '                MsgBox("Debe elegir primero un paciente.", MsgBoxStyle.Information)
    '                Exit Sub
    '            End If


    '            'With dsOrdenesNuevasModif
    '            '    frmRepOrdenMedica.imprimirOrdenMedica(.Tables(1), .Tables(2), .Tables(3), _
    '            '                                          .Tables(4), datosLogin, datosPaciente, NroOrden, _
    '            '                                          strCentroCostoOrigen)
    '            'End With

    '            objDatosGenerales = objGeneral.Generales.Instancia
    '            objPaciente = Paciente.Instancia

    '            If objDatosGenerales.Pais = "482" Then
    '                frmRepOrdenMedica.Show()


    '                frmRepOrdenMedica.reimprimirOrdenMedica(objConexion, objDatosGenerales.Prestador,
    '                                                       objDatosGenerales.Sucursal, .Cells("tip_admision").Value.ToString,
    '                                                       .Cells("ano_adm").Value.ToString, .Cells("num_adm").Value.ToString, 0, objPaciente)
    '            Else
    '                frmRepOrdenesMedicasXAdmision.Show()
    '                frmRepOrdenesMedicasXAdmision.imprimirOrdenMedica(objConexion, objDatosGenerales.Prestador,
    '                                              objDatosGenerales.Sucursal, .Cells("tip_admision").Value.ToString,
    '                                              .Cells("ano_adm").Value.ToString, .Cells("num_adm").Value.ToString, objPaciente)
    '            End If




    '        End With
    '    Else
    '        ''Si la historia esta abierta se obtiene la instancia del paciente
    '        ''creada cuando de abre la historia.
    '        objPaciente = Paciente.Instancia()
    '        If Not objPaciente Is Nothing Then
    '            frmRepOrdenesMedicasXAdmision.Show()
    '            frmRepOrdenesMedicasXAdmision.imprimirOrdenMedica(objConexion, objDatosGenerales.Prestador,
    '                                          objDatosGenerales.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision,
    '                                          objPaciente.NumeroAdmision, objPaciente)
    '        End If
    '    End If
    'End Sub

    Private Sub btnConsultaOrdenesMedicas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaOrdenesMedicas.Click
        Dim objPaciente As Paciente
        Dim dtgPacientes As DataGridView
        Dim controlListaEspera As ListaEspera

        ''Validacion de los parametros de entrada suministrador por sophia
        If objDatosGenerales Is Nothing Then
            MsgBox("No existen parametros de entrada.", MsgBoxStyle.Information)
            Exit Sub
        End If

        ''Se obtiene el control Activo del contenedor de datos
        'controlListaEspera = pnlContenedorListaEspera.Controls("ListaEspera")
        controlListaEspera = ListaEspera.Instancia

        ''Si el control activo es la lista de espera
        If Not controlListaEspera Is Nothing Then

            'Los datos del paciente se toman del regitro seleccionado
            'en la grilla de pacientes
            dtgPacientes = controlListaEspera.dtgLista

            If dtgPacientes.CurrentRow Is Nothing Then
                MsgBox("Debe elegir primero un paciente.", MsgBoxStyle.Information)
                Exit Sub
            End If

            With dtgPacientes.CurrentRow
                If Len(.Cells("nombre").Value.ToString.Trim) <= 0 Then
                    MsgBox("Debe elegir primero un paciente.", MsgBoxStyle.Information)
                    Exit Sub
                End If


                'With dsOrdenesNuevasModif
                '    frmRepOrdenMedica.imprimirOrdenMedica(.Tables(1), .Tables(2), .Tables(3), _
                '                                          .Tables(4), datosLogin, datosPaciente, NroOrden, _
                '                                          strCentroCostoOrigen)
                'End With

                objDatosGenerales = objGeneral.Generales.Instancia
                objPaciente = Paciente.Instancia

                If objDatosGenerales.Pais = "482" Then
                    frmRepOrdenMedica.Show()


                    frmRepOrdenMedica.reimprimirOrdenMedica(objConexion, objDatosGenerales.Prestador,
                                                           objDatosGenerales.Sucursal, .Cells("tip_admision").Value.ToString,
                                                           .Cells("ano_adm").Value.ToString, .Cells("num_adm").Value.ToString, 0, objPaciente)
                Else
                    Try

                        RptHC.ImprimirOrdenMedica("57", datosLogin.Prestador, datosLogin.Sucursal, .Cells("tip_admision").Value.ToString,
                              .Cells("ano_adm").Value.ToString, .Cells("num_adm").Value.ToString, objPaciente.CodHistoria, Nothing,
                              datosLogin.NombreMedico, datosLogin.RegistroMedico, datosLogin.DescripcionEspecialidad)
                        RptHC.ShowDialog()
                        RptHC.Close()

                    Catch ex As Exception
                        'frmRepOrdenesMedicasXAdmision.imprimirOrdenMedica(objConexion, objDatosGenerales.Prestador,
                        '                          objDatosGenerales.Sucursal, .Cells("tip_admision").Value.ToString,
                        '                          .Cells("ano_adm").Value.ToString, .Cells("num_adm").Value.ToString, objPaciente)

                        'frmRepOrdenesMedicasXAdmision.Show()
                    End Try

                End If




            End With
        Else
            ''Si la historia esta abierta se obtiene la instancia del paciente
            ''creada cuando de abre la historia.
            objPaciente = Paciente.Instancia()
            If Not objPaciente Is Nothing Then
                frmRepOrdenesMedicasXAdmision.Show()
                frmRepOrdenesMedicasXAdmision.imprimirOrdenMedica(objConexion, objDatosGenerales.Prestador,
                                              objDatosGenerales.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision,
                                              objPaciente.NumeroAdmision, objPaciente)
            End If
        End If
    End Sub

    Private Sub cmdCollapse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCollapse.Click
        Dim objPaciente As Paciente = Paciente.Instancia

        If pnlContenedorDatosPaciente.Visible = True Then
            pnlContenedorDatosPaciente.Visible = False
            cmdCollapse.Image = My.Resources.Collapse
            pnlContenedorDatos.Height += pnlContenedorDatosPaciente.Height
            lblDatosPaciente.Text = objPaciente.NombreCompleto & " " & objPaciente.TipoDocumento.Trim & " - " & objPaciente.NumeroDocumento.Trim
            lblDatosPaciente.Visible = True
        Else
            pnlContenedorDatosPaciente.Visible = True
            cmdCollapse.Image = My.Resources.Expand
            pnlContenedorDatos.Height -= pnlContenedorDatosPaciente.Height
            lblDatosPaciente.Text = ""
            lblDatosPaciente.Visible = False
        End If
    End Sub

    Private Sub MostrarOcultarPanel(ByRef pPanel As Panel, ByRef lblInfo As Label, ByRef btnCollapse As Button)

        If pPanel.Visible = True Then
            pPanel.Visible = False
            btnCollapse.Image = My.Resources.Collapse
            pnlContenedorDatos.Height += pPanel.Height
            lblInfo.Text = "Cantidad"
            lblInfo.Visible = True
        Else
            pPanel.Visible = True
            btnCollapse.Image = My.Resources.Expand
            pnlContenedorDatos.Height -= pPanel.Height
            lblInfo.Text = ""
            lblInfo.Visible = False
        End If
    End Sub

    'NAVEGACION IN PANELS BY GILBERTO VARGAS 
    Private Sub lnkMotivoConsulta_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkMotivoConsulta.LinkClicked

        Dim sControl As HCBasica

        sControl = HCBasica.Instancia
        'sControl = Me.pnlContenedorPantallas.Controls("pnlContenedorDatos").Controls("HCBasica")
        sControl.AutoScrollPosition = New Point(0, 0)
    End Sub


    Private Sub lnkDesPsicoMotor_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        Dim sControl As HCBasica
        sControl = HCBasica.Instancia
        'sControl = Me.pnlContenedorPantallas.Controls("pnlContenedorDatos").Controls("HCBasica")
        sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPerinatales.Height)
    End Sub

    Private Sub lnkAntPatologicos_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)

        Dim sControl As HCBasica
        sControl = HCBasica.Instancia
        'sControl = Me.pnlContenedorPantallas.Controls("pnlContenedorDatos").Controls("HCBasica")
        sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPerinatales.Height)
    End Sub


    Private Sub lnkAntQuirurgicos_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAntQuirurgicos.LinkClicked

        Dim sControl As HCBasica
        Dim sDatosP As ctlDatosPaciente

        sControl = HCBasica.Instancia
        sDatosP = ctlDatosPaciente.Instancia


        'sDatosP = Me.pnlContenedorPantallas.Controls("pnlContenedorDatosPaciente").Controls("ctlDatosPaciente")
        'sControl = Me.pnlContenedorPantallas.Controls("pnlContenedorDatos").Controls("HCBasica")
        'If sDatosP.lblGenero.Text = "FEMENINO" Then
        '    sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPerinatales.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesGinecologicos.Height)
        'Else
        '    sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPerinatales.Height + sControl.pnlAntecedentesPatologicos.Height)
        'End If

        sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPatologicos.Height)

    End Sub

    Private Sub lnkAntFarmacologicos_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAntFarmacologicos.LinkClicked

        Dim sControl As HCBasica
        Dim sDatosP As ctlDatosPaciente

        sControl = HCBasica.Instancia
        sDatosP = ctlDatosPaciente.Instancia

        'sDatosP = Me.pnlContenedorPantallas.Controls("pnlContenedorDatosPaciente").Controls("ctlDatosPaciente")
        'sControl = Me.pnlContenedorPantallas.Controls("pnlContenedorDatos").Controls("HCBasica")
        'If sDatosP.lblGenero.Text = "FEMENINO" Then
        '    sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPerinatales.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesGinecologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height)
        'Else
        '    sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPerinatales.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height)
        'End If
        sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedenteTransfusional.Height + sControl.pnlAntecedenteTraumatologico.Height)
    End Sub

    Private Sub lnkAntAlergicos_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAntAlergicos.LinkClicked

        Dim sControl As HCBasica
        Dim sDatosP As ctlDatosPaciente

        sControl = HCBasica.Instancia
        sDatosP = ctlDatosPaciente.Instancia

        'sDatosP = Me.pnlContenedorPantallas.Controls("pnlContenedorDatosPaciente").Controls("ctlDatosPaciente")
        'sControl = Me.pnlContenedorPantallas.Controls("pnlContenedorDatos").Controls("HCBasica")
        'If sDatosP.lblGenero.Text = "FEMENINO" Then
        '    sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPerinatales.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesGinecologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesFarmacologicos.Height)
        'Else
        '    sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPerinatales.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesFarmacologicos.Height)
        'End If

        sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height)

    End Sub

    Private Sub lnkAntToxicos_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAntToxicos.LinkClicked

        Dim sControl As HCBasica
        Dim sDatosP As ctlDatosPaciente

        sControl = HCBasica.Instancia
        sDatosP = ctlDatosPaciente.Instancia

        'sDatosP = Me.pnlContenedorPantallas.Controls("pnlContenedorDatosPaciente").Controls("ctlDatosPaciente")
        'sControl = Me.pnlContenedorPantallas.Controls("pnlContenedorDatos").Controls("HCBasica")
        'If sDatosP.lblGenero.Text = "FEMENINO" Then
        '    sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPerinatales.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesGinecologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesAlergicos.Height)
        'Else
        '    sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPerinatales.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesAlergicos.Height)
        'End If
        sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesAlergicos.Height)
    End Sub
    Private Sub lnkAntTransfusional_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAntTransfusional.LinkClicked

        Dim sControl As HCBasica
        Dim sDatosP As ctlDatosPaciente

        sControl = HCBasica.Instancia
        sDatosP = ctlDatosPaciente.Instancia

        sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height)

    End Sub

    Private Sub lnkAntFamiliares_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAntFamiliares.LinkClicked

        Dim sControl As HCBasica
        Dim sDatosP As ctlDatosPaciente

        sControl = HCBasica.Instancia
        sDatosP = ctlDatosPaciente.Instancia

        'sDatosP = Me.pnlContenedorPantallas.Controls("pnlContenedorDatosPaciente").Controls("ctlDatosPaciente")
        'sControl = Me.pnlContenedorPantallas.Controls("pnlContenedorDatos").Controls("HCBasica")
        'If sDatosP.lblGenero.Text = "FEMENINO" Then
        '    sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPerinatales.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesGinecologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height)
        'Else
        '    sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPerinatales.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height)
        'End If

        sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedenteTransfusional.Height + sControl.pnlAntecedenteTraumatologico.Height + sControl.pnlAntecedentesFarmacologicos.Height)

    End Sub

    Private Sub lnkVacunas_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkVacunas.LinkClicked

        Dim sControl As HCBasica
        Dim sDatosP As ctlDatosPaciente

        sControl = HCBasica.Instancia
        sDatosP = ctlDatosPaciente.Instancia

        'sDatosP = Me.pnlContenedorPantallas.Controls("pnlContenedorDatosPaciente").Controls("ctlDatosPaciente")
        'sControl = Me.pnlContenedorPantallas.Controls("pnlContenedorDatos").Controls("HCBasica")
        'If sDatosP.lblGenero.Text = "FEMENINO" Then
        '    sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPerinatales.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesGinecologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedentesFamiliares.Height)
        'Else
        '    sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPerinatales.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedentesFamiliares.Height)
        'End If
        If (sControl.pnlTitAntPerinatales.Visible) Then
            sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedenteTransfusional.Height + sControl.pnlAntecedenteTraumatologico.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesFamiliares.Height + sControl.pnlAntecedentesPerinatales.Height)
        End If

        If (sControl.pnlTitAntGineco.Visible) Then
            sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedenteTransfusional.Height + sControl.pnlAntecedenteTraumatologico.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesFamiliares.Height + sControl.pnlAntecedentesGinecologicos.Height)
        End If

        If (sControl.pnlTitAntGineco.Visible = False And sControl.pnlTitAntPerinatales.Visible = False) Then
            sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedenteTransfusional.Height + sControl.pnlAntecedenteTraumatologico.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesFamiliares.Height + 3)
        End If




    End Sub

    Private Sub lnkExamenFisico_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkExamenFisico.LinkClicked

        Dim sControl As HCBasica
        Dim sDatosP As ctlDatosPaciente

        sControl = HCBasica.Instancia
        sDatosP = ctlDatosPaciente.Instancia

        'sDatosP = Me.pnlContenedorPantallas.Controls("pnlContenedorDatosPaciente").Controls("ctlDatosPaciente")
        'sControl = Me.pnlContenedorPantallas.Controls("pnlContenedorDatos").Controls("HCBasica")
        'If sDatosP.lblGenero.Text = "FEMENINO" Then
        '    sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPerinatales.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesGinecologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedentesFamiliares.Height + sControl.pnlVacunas.Height)
        'Else
        '    sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPerinatales.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedentesFamiliares.Height + sControl.pnlVacunas.Height)
        'End If

        If (sControl.pnlTitAntPerinatales.Visible) Then
            sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedenteTransfusional.Height + sControl.pnlAntecedenteTraumatologico.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesFamiliares.Height + sControl.pnlAntecedentesPerinatales.Height + sControl.pnlVacunas.Height)
        End If

        If (sControl.pnlTitAntGineco.Visible) Then
            sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedenteTransfusional.Height + sControl.pnlAntecedenteTraumatologico.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesFamiliares.Height + sControl.pnlAntecedentesGinecologicos.Height + sControl.pnlVacunas.Height)
        End If

        If (sControl.pnlTitAntGineco.Visible = False And sControl.pnlTitAntPerinatales.Visible = False) Then
            sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedenteTransfusional.Height + sControl.pnlAntecedenteTraumatologico.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesFamiliares.Height + sControl.pnlVacunas.Height + 3)
        End If

    End Sub

    Private Sub lnkImpDiagnostica_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkImpDiagnostica.LinkClicked

        Dim sControl As HCBasica
        Dim sDatosP As ctlDatosPaciente

        sControl = HCBasica.Instancia
        sDatosP = ctlDatosPaciente.Instancia

        'sDatosP = Me.pnlContenedorPantallas.Controls("pnlContenedorDatosPaciente").Controls("ctlDatosPaciente")
        'sControl = Me.pnlContenedorPantallas.Controls("pnlContenedorDatos").Controls("HCBasica")
        'If sDatosP.lblGenero.Text = "FEMENINO" Then
        '    sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPerinatales.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesGinecologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedentesFamiliares.Height + sControl.pnlVacunas.Height + sControl.pnlExamenFisico.Height)
        'Else
        '    sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPerinatales.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedentesFamiliares.Height + sControl.pnlVacunas.Height + sControl.pnlExamenFisico.Height)
        'End If

        If (sControl.pnlTitAntPerinatales.Visible) Then
            sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedenteTransfusional.Height + sControl.pnlAntecedenteTraumatologico.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesFamiliares.Height + sControl.pnlAntecedentesPerinatales.Height + sControl.pnlVacunas.Height + sControl.pnlExamenFisico.Height)
        End If

        If (sControl.pnlTitAntGineco.Visible) Then
            sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedenteTransfusional.Height + sControl.pnlAntecedenteTraumatologico.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesFamiliares.Height + sControl.pnlAntecedentesGinecologicos.Height + sControl.pnlVacunas.Height + sControl.pnlExamenFisico.Height)
        End If

        If (sControl.pnlTitAntGineco.Visible = False And sControl.pnlTitAntPerinatales.Visible = False) Then
            sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedenteTransfusional.Height + sControl.pnlAntecedenteTraumatologico.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesFamiliares.Height + sControl.pnlVacunas.Height + sControl.pnlExamenFisico.Height + 3)
        End If

    End Sub

    Private Sub lnkDietas_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkDietas.LinkClicked

        Dim sControl As ctlOrdenesMedicas

        sControl = ctlOrdenesMedicas.Instancia
        'sControl = Me.pnlContenedorPantallas.Controls("pnlContenedorDatos").Controls("ctlOrdenesMedicas")
        sControl.AutoScrollPosition = New Point(0, 0)

    End Sub

    Private Sub lnkMedLiqEndovenosos_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkMedLiqEndovenosos.LinkClicked

        Dim sControl As ctlOrdenesMedicas

        sControl = ctlOrdenesMedicas.Instancia
        'sControl = Me.pnlContenedorPantallas.Controls("pnlContenedorDatos").Controls("ctlOrdenesMedicas")
        sControl.AutoScrollPosition = New Point(0, sControl.Panel2.Height + sControl.pnlAislamientos.Height + sControl.Panel6.Height + sControl.panelDietas.Height)

    End Sub

    Private Sub lnkProcedimientos_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkProcedimientos.LinkClicked

        Dim sControl As ctlOrdenesMedicas

        sControl = ctlOrdenesMedicas.Instancia
        'sControl = Me.pnlContenedorPantallas.Controls("pnlContenedorDatos").Controls("ctlOrdenesMedicas")
        sControl.AutoScrollPosition = New Point(0, sControl.Panel2.Height + sControl.pnlAislamientos.Height + sControl.Panel6.Height + sControl.panelDietas.Height + sControl.Panel3.Height + sControl.panelMedica.Height)

    End Sub

    Private Sub lnkOrdenesG_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkOrdenesG.LinkClicked

        Dim sControl As ctlOrdenesMedicas

        sControl = ctlOrdenesMedicas.Instancia
        'sControl = Me.pnlContenedorPantallas.Controls("pnlContenedorDatos").Controls("ctlOrdenesMedicas")
        sControl.AutoScrollPosition = New Point(0, sControl.Panel2.Height + sControl.pnlAislamientos.Height + sControl.Panel6.Height + sControl.panelDietas.Height + sControl.Panel3.Height + sControl.panelMedica.Height + sControl.Panel4.Height + sControl.panelProce.Height)

    End Sub

    Private Sub btnConsultaResultados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaResultados.Click
        Me.cMnuReimpresion.Show(btnConsultaResultados, 0, btnConsultaResultados.Height)
    End Sub

    Private Sub cMnuReimpresionOrdenes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cMnuReimpresionOrdenes.Click
        Dim objPaciente As Paciente
        Dim dtgPacientes As DataGridView
        Dim controlListaEspera As ListaEspera

        ''Validacion de los parametros de entrada suministrador por sophia
        If objDatosGenerales Is Nothing Then
            MsgBox("No existen parametros de entrada.", MsgBoxStyle.Information)
            Exit Sub
        End If

        ''Se obtiene el control Activo del contenedor de datos
        'controlListaEspera = pnlContenedorListaEspera.Controls("ListaEspera")
        controlListaEspera = ListaEspera.Instancia

        ''Si el control activo es la lista de espera
        If Not controlListaEspera Is Nothing Then

            'Los datos del paciente se toman del regitro seleccionado
            'en la grilla de pacientes
            dtgPacientes = controlListaEspera.dtgLista

            If dtgPacientes.CurrentRow Is Nothing Then
                MsgBox("Debe elegir primero un paciente.", MsgBoxStyle.Information)
                Exit Sub
            End If

            With dtgPacientes.CurrentRow
                If Len(.Cells("nombre").Value.ToString.Trim) <= 0 Then
                    MsgBox("Debe elegir primero un paciente.", MsgBoxStyle.Information)
                    Exit Sub
                End If

                reimprimirOrdenMedica(.Cells("tip_admision").Value.ToString,
                                      .Cells("ano_adm").Value.ToString,
                                      .Cells("num_adm").Value.ToString)
            End With
        Else
            ''Si la historia esta abierta se obtiene la instancia del paciente
            ''creada cuando de abre la historia.
            objPaciente = Paciente.Instancia()
            If Not objPaciente Is Nothing Then
                reimprimirOrdenMedica(objPaciente.TipoAdmision,
                                      objPaciente.AnoAdmision,
                                      objPaciente.NumeroAdmision)
            End If
        End If
    End Sub

    Private Sub reimprimirOrdenMedica(ByVal tip_admision As String, ByVal ano_adm As String, ByVal num_adm As String)
        Dim strNroOrden As String
        Dim objPaciente As Paciente
        objPaciente = Paciente.Instancia()
        strNroOrden = InputBox("Digite el n?mero de orden m?dica", "Reimpresi?n de Ordenes M?dicas")

        If strNroOrden.Trim.Length <= 0 Then
            MsgBox("Debe digitar el n?mero de orden m?dica. ")
            Exit Sub
        ElseIf Not IsNumeric(strNroOrden) Then
            MsgBox("Debe digitar datos num?ricos. ")
            Exit Sub
        End If

        objDatosGenerales = objGeneral.Generales.Instancia
        objPaciente = Paciente.Instancia

        If objDatosGenerales.Pais = "482" Then
            frmRepOrdenMedica.Show()
            frmRepOrdenMedica.reimprimirOrdenMedica(objConexion, objDatosGenerales.Prestador,
                                                   objDatosGenerales.Sucursal, tip_admision,
                                                   ano_adm, num_adm, strNroOrden, objPaciente)
        Else
            Try
                RptHC.ImprimirOrdenMedica("58", datosLogin.Prestador, datosLogin.Sucursal, tip_admision,
                                    ano_adm, num_adm, objPaciente.CodHistoria, strNroOrden,
                                    datosLogin.NombreMedico, datosLogin.RegistroMedico, datosLogin.DescripcionEspecialidad, True)
                RptHC.ShowDialog()
                RptHC.Close()

            Catch ex As Exception
                'frmRepOrdenMedica.Show()
                'frmRepOrdenMedica.reimprimirOrdenMedica(objConexion, objDatosGenerales.Prestador,
                '                            objDatosGenerales.Sucursal, tip_admision,
                '                            ano_adm, num_adm, strNroOrden, objPaciente)
            End Try
        End If




    End Sub
    Private Sub reimprimirOrdenMedicaControl(ByVal tip_admision As String, ByVal ano_adm As String, ByVal num_adm As String)

        Dim strNroOrden As String
        Dim objPaciente As Paciente
        objPaciente = Paciente.Instancia()

        strNroOrden = InputBox("Digite el n?mero de orden m?dica de control", "Reimpresi?n de Ordenes M?dicas de control")

        If strNroOrden.Trim.Length <= 0 Then
            MsgBox("Debe digitar el n?mero de orden m?dica de control. ")
            Exit Sub
        ElseIf Not IsNumeric(strNroOrden) Then
            MsgBox("Debe digitar datos num?ricos. ")
            Exit Sub
        End If


        'frmRepOrdenMedica.Show()
        'frmRepOrdenMedica.reimprimirOrdenMedicaControl(objConexion, objDatosGenerales.Prestador,
        '                                       objDatosGenerales.Sucursal, tip_admision,
        '                                       ano_adm, num_adm, strNroOrden, objPaciente)

        RptHC.ImprimirOrdenMedica("61", objDatosGenerales.Prestador, objDatosGenerales.Sucursal, tip_admision,
                                ano_adm, num_adm, objPaciente.CodHistoria, strNroOrden,
                                datosLogin.NombreMedico, datosLogin.RegistroMedico, datosLogin.DescripcionEspecialidad, True, False, True)
        RptHC.ShowDialog()
        RptHC.Close()
    End Sub

    Private Sub cMnuReimpresionProcedim_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cMnuReimpresionProcedim.Click
        Dim objPaciente As Paciente
        Dim dtgPacientes As DataGridView
        Dim controlListaEspera As ListaEspera

        ''Validacion de los parametros de entrada suministrador por sophia
        If objDatosGenerales Is Nothing Then
            MsgBox("No existen parametros de entrada.", MsgBoxStyle.Information)
            Exit Sub
        End If

        ''Se obtiene el control Activo del contenedor de datos
        'controlListaEspera = pnlContenedorListaEspera.Controls("ListaEspera")
        controlListaEspera = ListaEspera.Instancia

        ''Si el control activo es la lista de espera
        If Not controlListaEspera Is Nothing Then

            'Los datos del paciente se toman del regitro seleccionado
            'en la grilla de pacientes
            dtgPacientes = controlListaEspera.dtgLista

            If dtgPacientes.CurrentRow Is Nothing Then
                MsgBox("Debe elegir primero un paciente.", MsgBoxStyle.Information)
                Exit Sub
            End If

            With dtgPacientes.CurrentRow
                If Len(.Cells("nombre").Value.ToString.Trim) <= 0 Then
                    MsgBox("Debe elegir primero un paciente.", MsgBoxStyle.Information)
                    Exit Sub
                End If

                reimprimirProcedimientosExternos(.Cells("tip_admision").Value.ToString,
                                                 .Cells("ano_adm").Value.ToString,
                                                 .Cells("num_adm").Value.ToString)
            End With
        Else
            ''Si la historia esta abierta se obtiene la instancia del paciente
            ''creada cuando de abre la historia.
            objPaciente = Paciente.Instancia()
            If Not objPaciente Is Nothing Then
                reimprimirProcedimientosExternos(objPaciente.TipoAdmision,
                                      objPaciente.AnoAdmision,
                                      objPaciente.NumeroAdmision)
            End If
        End If
    End Sub

    Private Sub reimprimirProcedimientosExternos(ByVal tip_admision As String, ByVal ano_adm As String,
                                                 ByVal num_adm As String)
        Dim strNroOrden As String
        Dim objP As Paciente

        objP = Paciente.Instancia

        strNroOrden = InputBox("Digite el n?mero de formula de procedimientos. ", "Reimpresi?n de Procedimientos Externos")

        If strNroOrden.Trim.Length <= 0 Then
            MsgBox("Debe digitar el n?mero de formula de procedimientos. ")
            Exit Sub
        ElseIf Not IsNumeric(strNroOrden) Then
            MsgBox("Debe digitar datos num?ricos. ")
            Exit Sub
        End If
        Dim objDatosGenerales As objGenerales.Generales

        objDatosGenerales = objGenerales.Generales.Instancia

        Dim objOrden As Sophia.HistoriaClinica.Reportes.Orden       ''Objeto que encapula la informacion de la orden
        Dim lerror As Long

        objOrden = New Sophia.HistoriaClinica.Reportes.Orden

        Try
            ''Se consulta la base de datos con base en los parametros y se llena el objeto Orden con los
            ''datos obtenidos.
            lerror = objOrden.crearOrdenProcedimientos(objConexion, objDatosGenerales.Prestador, objDatosGenerales.Sucursal,
                                                       tip_admision, ano_adm, num_adm, strNroOrden)

            If lerror <> 0 Then
                If lerror = 99 Then
                    MsgBox("No existen datos para el n?mero de formula. ")
                Else
                    MsgBox("Error en la consulta de la formula. ")
                End If
                Exit Sub
            End If

            objOrden.EsReimpresion = True

        Catch ex As Exception
            MsgBox("Error en la impresi?n de la orden. " & ex.Message, MsgBoxStyle.Critical)
        End Try

        If objDatosGenerales.Pais = "482" Then ''Peru 
            frmRepFormulaProcedim.Show()
            frmRepFormulaProcedim.imprimirFormulaProcedim(objConexion, objDatosGenerales.Prestador,
                                                       objDatosGenerales.Sucursal, tip_admision,
                                                         ano_adm, num_adm, strNroOrden, True, False)
        Else
            '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
            'Juan Carlos Jaramillo Lozano - IG
            RptHC_Enf_Med.Show()
            RptHC_Enf_Med.ImprimirHistoriaClinica_Procedimientos_externos(objConexion, "59", objDatosGenerales.Prestador,
                                                                      objDatosGenerales.Sucursal, tip_admision,
                                                                      ano_adm, num_adm,
                                                                      True, False, strNroOrden, objP.CodHistoria)
            '2019-03-11 Fin
        End If
    End Sub
    Private Sub cMnuReimpresionFormulacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cMnuReimpresionFormulacion.Click
        Dim objPaciente As Paciente
        Dim dtgPacientes As DataGridView
        Dim controlListaEspera As ListaEspera
        Dim objConseguirDatosS As New BLHistoriaBasica
        Dim dtEntidad As DataTable
        Dim strTipoUsuario As String = ""

        ''Validacion de los parametros de entrada suministrador por sophia
        If objDatosGenerales Is Nothing Then
            MsgBox("No existen parametros de entrada.", MsgBoxStyle.Information)
            Exit Sub
        End If

        ''Se obtiene el control Activo del contenedor de datos
        'controlListaEspera = pnlContenedorListaEspera.Controls("ListaEspera")
        controlListaEspera = ListaEspera.Instancia

        ''Si el control activo es la lista de espera
        If Not controlListaEspera Is Nothing Then

            'Los datos del paciente se toman del regitro seleccionado
            'en la grilla de pacientes
            dtgPacientes = controlListaEspera.dtgLista

            If dtgPacientes.CurrentRow Is Nothing Then
                MsgBox("Debe elegir primero un paciente.", MsgBoxStyle.Information)
                Exit Sub
            End If

            With dtgPacientes.CurrentRow
                If Len(.Cells("nombre").Value.ToString.Trim) <= 0 Then
                    MsgBox("Debe elegir primero un paciente.", MsgBoxStyle.Information)
                    Exit Sub
                End If

                dtEntidad = objConseguirDatosS.ConsultarTablasBasicas("genentid", objConexion, "descripcion,man_conv_med,tip_usuario,nro_med_for", "entidad='" & .Cells("entidad").Value.ToString & "'")
                If dtEntidad.Rows.Count > 0 Then
                    strTipoUsuario = dtEntidad.Rows(0).Item("tip_usuario").ToString
                End If
                '.TipoUsuario = dtEntidad.Rows(0)("tip_usuario").ToString

                reimprimirFormulacionExterna(.Cells("tip_admision").Value.ToString,
                                                 .Cells("ano_adm").Value.ToString,
                                                 .Cells("num_adm").Value.ToString,
                                                 strTipoUsuario)
            End With
        Else
            ''Si la historia esta abierta se obtiene la instancia del paciente
            ''creada cuando de abre la historia.
            objPaciente = Paciente.Instancia()
            If Not objPaciente Is Nothing Then
                reimprimirFormulacionExterna(objPaciente.TipoAdmision,
                                      objPaciente.AnoAdmision,
                                      objPaciente.NumeroAdmision)
            End If
        End If
    End Sub

    Private Sub reimprimirFormulacionExterna(ByVal tip_admision As String, ByVal ano_adm As String,
                                             ByVal num_adm As String, Optional ByVal strTipoUsuario As String = "")

        Dim strNroOrden As String
        Dim objPaciente As Paciente
        Dim strTipoUsu As String

        strNroOrden = InputBox("Digite el n?mero de formula m?dica. ", "Reimpresi?n de Formulaci?n Externa")

        If strNroOrden.Trim.Length <= 0 Then
            MsgBox("Debe digitar el n?mero de formula m?dica. ")
            Exit Sub
        ElseIf Not IsNumeric(strNroOrden) Then
            MsgBox("Debe digitar datos num?ricos. ")
            Exit Sub
        End If

        objPaciente = Paciente.Instancia()
        'frmRepFormuMedica.Show()
        If strTipoUsuario.Trim.Length > 0 Then
            strTipoUsu = strTipoUsuario
        Else
            strTipoUsu = objPaciente.TipoUsuario.ToString
        End If
        Dim objDatosGenerales As objGenerales.Generales

        objDatosGenerales = objGenerales.Generales.Instancia

        If objDatosGenerales.Pais = "482" Or objDatosGenerales.Pais = "484" Then ''Peru ? Venezuela
            frmRepFormuMedica.Show()
            frmRepFormuMedica.imprimirFormulaMedica(objConexion, objDatosGenerales.Prestador,
                                                objDatosGenerales.Sucursal, tip_admision,
                                                ano_adm, num_adm, strNroOrden, True, strTipoUsu)
        Else
            '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
            'Juan Carlos Jaramillo Lozano - IG
            RptHC_Enf_Med.Show()
            RptHC_Enf_Med.ImprimirHistoriaClinica_imprimirFormulaMedica(objConexion, "60", objDatosGenerales.Prestador,
                                                                                objDatosGenerales.Sucursal, tip_admision,
                                                                                ano_adm, num_adm,
                                                                            strNroOrden, True, strTipoUsu, objPaciente.CodHistoria)
            '2019-03-11 Fin
        End If
    End Sub

    Private Sub btnContrareferencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContrareferencia.Click
        frmReferencias.Show()
        'Me.cMnuContrareferencia.Show(btnContrareferencia, 0, btnContrareferencia.Height)
    End Sub

    'Private Sub cMnuContrareferenciaProcedimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cMnuContrareferenciaProcedimientos.Click
    '    frmReferencias.mostrar(objConexion, frmReferencias.TipoReferencia.procedimientos)
    'End Sub

    'Private Sub cMnuContrareferenciaRemision_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cMnuContrareferenciaRemision.Click
    '    frmReferencias.mostrar(objConexion, frmReferencias.TipoReferencia.remision)
    'End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblError1.Visible = Not lblError1.Visible
        lblError2.Visible = Not lblError2.Visible
    End Sub

    Private Sub lblError_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblError2.Click, lblError1.Click
        Dim objPaciente As Paciente
        objPaciente = Paciente.Instancia()

        Dim dtDatos As DataTable
        Dim dtRows() As DataRow
        Dim dtRow As DataRow
        Dim intHCs As Integer

        If frmCorreccionEF_tmp.Mostrar() = True Then
            Timer1.Enabled = False
            lblError1.Visible = False
            lblError2.Visible = False
        Else
            If objPaciente.HistoriasConErroresEF.Rows.Count > 1 Then
                dtDatos = objPaciente.HistoriasConErroresEF
                dtRows = dtDatos.Select("Estado='M'")
                For Each dtRow In dtRows
                    dtDatos.Rows.Remove(dtRow)
                Next
                objPaciente.HistoriasConErroresEF = dtDatos
                intHCs = dtDatos.Rows.Count
                lblError1.Text = lblError1.Text.Replace(lblError1.Text.Substring(lblError1.Text.IndexOf("(")),
                                                                                                  "(" & intHCs & " Historia" & IIf(intHCs > 1, "s", "") & " por Corregir - Clic Aqu? para Corregir)")
                lblError2.Text = lblError1.Text
            End If
        End If

    End Sub

    'Private Sub pnlContenedorDatos_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) _
    '        Handles pnlContenedorDatos.ControlAdded
    '    ''revisar, esta hacinedo invisible el control y no lo esta eliminando
    '    Dim ctrlProcExternos As ctlPlanProcExternos = Nothing

    '    If pnlContenedorDatos.HasChildren Then
    '        For Each ctrl As Control In pnlContenedorDatos.Controls
    '            If ctrl.GetType().Equals(New ctlPlanProcExternos().GetType()) Then
    '                ctrlProcExternos = ctrl
    '                Exit For
    '            End If
    '        Next
    '    End If

    '    If Not ctrlProcExternos Is Nothing Then
    '        If ctrlProcExternos.dgProcedimiento.RowCount > 0 Then
    '            If MessageBox.Show("Desea Guardar la informaci?n de los procedimientos registrados?", "Historia Clinica", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
    '                'ctrlProcExternos.btGrabar_Click(New Object(), New System.EventArgs())
    '                'objProcExternos.Dispose()
    '                ''TODO: Guardar la informacion en el formulario.
    '                pnlContenedorDatos.Controls.Remove(ctrlProcExternos)

    '                ctrlProcExternos.Visible = False
    '                ctrlProcExternos.Dispose()

    '                pnlContenedorDatos.Controls.Add(e.Control)
    '            End If
    '        End If
    '    End If
    'End Sub




    Private Sub lnkAntPerinatales_LinkClicked_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAntPerinatales.LinkClicked
        Dim sControl As HCBasica
        sControl = HCBasica.Instancia
        'sControl = Me.pnlContenedorPantallas.Controls("pnlContenedorDatos").Controls("HCBasica")
        'sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height)

        If (sControl.pnlTitAntPerinatales.Visible) Then
            sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedenteTransfusional.Height + sControl.pnlAntecedenteTraumatologico.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesFamiliares.Height)
        End If

    End Sub

    Private Sub lnkDesTraumatologico_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkDesTraumatologicos.LinkClicked
        Dim sControl As HCBasica
        sControl = HCBasica.Instancia
        'sControl = Me.pnlContenedorPantallas.Controls("pnlContenedorDatos").Controls("HCBasica")
        sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedenteTransfusional.Height)
    End Sub

    Private Sub lnkAntPatologicos_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAntPatologicos.LinkClicked

        Dim sControl As HCBasica
        sControl = HCBasica.Instancia
        'sControl = Me.pnlContenedorPantallas.Controls("pnlContenedorDatos").Controls("HCBasica")
        sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height)
    End Sub

    Private Sub lnkAntGinecologicos_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAntGinecologicos.LinkClicked

        Dim sControl As HCBasica
        Dim sDatosP As ctlDatosPaciente

        sControl = HCBasica.Instancia
        sDatosP = ctlDatosPaciente.Instancia

        'sDatosP = Me.pnlContenedorPantallas.Controls("pnlContenedorDatosPaciente").Controls("ctlDatosPaciente")
        'sControl = Me.pnlContenedorPantallas.Controls("pnlContenedorDatos").Controls("HCBasica")

        If sDatosP.lblGenero.Text = "FEMENINO" Then
            sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedenteTransfusional.Height + sControl.pnlAntecedenteTraumatologico.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesFamiliares.Height)
        End If

    End Sub
    ''Claudia Garay Alarmas 28 sept 2010
    Private Sub lnkAlarmas_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkAlarmas.LinkClicked
        Dim sControl As HCBasica
        Dim sDatosP As ctlDatosPaciente

        sControl = HCBasica.Instancia
        sDatosP = ctlDatosPaciente.Instancia

        'sDatosP = Me.pnlContenedorPantallas.Controls("pnlContenedorDatosPaciente").Controls("ctlDatosPaciente")
        'sControl = Me.pnlContenedorPantallas.Controls("pnlContenedorDatos").Controls("HCBasica")
        If sDatosP.lblGenero.Text = "FEMENINO" Then
            sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPerinatales.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesGinecologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedentesFamiliares.Height + sControl.pnlVacunas.Height + sControl.pnlExamenFisico.Height + sControl.pnlImpresionDiagnostica.Height)
        Else
            sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPerinatales.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedentesFamiliares.Height + sControl.pnlVacunas.Height + sControl.pnlExamenFisico.Height + sControl.pnlImpresionDiagnostica.Height)
        End If
    End Sub

    Private Sub btnBeeblos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBeeblos.Click
        Dim objPaciente As Paciente
        Dim dtgPacientes As DataGridView
        Dim controlListaEspera As ListaEspera
        ' Dim DatosPac As New ListaEspera

        ''Validacion de los parametros de entrada suministrador por sophia
        If objDatosGenerales Is Nothing Then
            MsgBox("No existen parametros de entrada.", MsgBoxStyle.Information)
            Exit Sub
        End If

        ''Se obtiene el control Activo del contenedor de datos
        'controlListaEspera = pnlContenedorListaEspera.Controls("ListaEspera")
        controlListaEspera = ListaEspera.Instancia

        ''Si el control activo es la lista de espera
        If Not controlListaEspera Is Nothing Then
            dtgPacientes = controlListaEspera.dtgLista

            If dtgPacientes.CurrentRow Is Nothing Then

                If controlListaEspera.DatosBasicosPac.Count > 0 Then
                    frmConsultaBeeblos2.mostrar(controlListaEspera.DatosBasicosPac(1), controlListaEspera.DatosBasicosPac(0))
                    Exit Sub
                Else
                    If controlListaEspera.txtCodigoTipoDocumento.Text.Trim <> "" And controlListaEspera.txtNumeroDocumento.Text.Trim <> "" Then
                        frmConsultaBeeblos2.mostrar(controlListaEspera.txtCodigoTipoDocumento.Text.Trim, controlListaEspera.txtNumeroDocumento.Text.Trim)
                        Exit Sub
                    Else
                        frmConsultaBeeblos2.Show()
                        Exit Sub
                    End If
                End If
            End If
            With dtgPacientes.CurrentRow
                If Len(.Cells("nombre").Value.ToString.Trim) <= 0 Then
                    frmConsultaBeeblos2.ShowDialog()
                Else
                    If controlListaEspera.DatosBasicosPac.Count > 0 Then

                        frmConsultaBeeblos2.mostrar(controlListaEspera.DatosBasicosPac(1), controlListaEspera.DatosBasicosPac(0))
                    Else
                        frmConsultaBeeblos2.mostrar(.Cells("tip_doc").Value, .Cells("num_doc").Value)
                    End If
                End If
            End With
        Else
            objPaciente = Paciente.Instancia()
            If Not objPaciente Is Nothing Then
                frmConsultaBeeblos2.mostrar(objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
            End If
        End If
    End Sub

    Private Sub cmdParaclinico_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdParaclinico.Click
        Try

            frmConsultaParaclinico.Show()

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub lnkLiquidos_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkLiquidos.LinkClicked
        CarcarPatallaEvolucion()

        Dim objdao As New DAOGeneral
        Dim objdaoenfermeria As New DAOEnfermeriaCP
        Dim objPaciente As Paciente
        Dim dtparametro As DataTable
        Dim peso, edad As Integer

        objPaciente = Paciente.Instancia()

        dtparametro = objdaoenfermeria.ConsultarDiasHistorico("Liquidos")
        If dtparametro.Rows.Count > 0 Then
            If dtparametro.Rows(0).Item("valor").ToString = "1" Then
                Dim ctlpantallaLiq As New frm_ConsultaLiquidos(objPaciente.CodHistoria, Format(objdao.traerFechaServidor(), objDatosGenerales.FormatoFechaCorta), Format(objdao.traerFechaServidor(), objDatosGenerales.FormatoFechaCorta), 0, 0)
                peso = Convert.ToDouble(BLPlaneacion.ObtenerPeso(objDatosGenerales.Prestador, objDatosGenerales.Sucursal, objPaciente.NumeroAdmision, objPaciente.AnoAdmision, objPaciente.TipoAdmision, objPaciente.CodHistoria))
                edad = BLPlaneacion.ObtenerEdadPaciente(objDatosGenerales.Prestador, objDatosGenerales.Sucursal, objPaciente.NumeroAdmision, objPaciente.AnoAdmision, objPaciente.TipoAdmision)

                ctlpantallaLiq.Mostrar(objPaciente.CodHistoria, peso, edad, objDatosGenerales.Prestador, objDatosGenerales.Sucursal, objPaciente.NumeroAdmision, objPaciente.AnoAdmision, objPaciente.TipoAdmision)
                'ctlpantallaLiq.ShowDialog()
            Else
                Dim ctlpantallaLiq As New Frm_PantallaLiquidos(objPaciente.CodHistoria, Format(objdao.traerFechaServidor(), objDatosGenerales.FormatoFechaCorta), Format(objdao.traerFechaServidor(), objDatosGenerales.FormatoFechaCorta), 0, 0)
                ctlpantallaLiq.ShowDialog()
            End If
        End If

    End Sub

    Private Sub lnkSeguimientoDolor_LinkClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkSeguimientoDolor.LinkClicked
        CarcarPatallaEvolucion()

        '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
        'Juan Carlos Jaramillo Lozano - IG
        RptHC_Enf_Med.Show()
        RptHC_Enf_Med.ImprimirHistoriaClinica(objConexion, "|srptEnfSeguimientoDolor|", "43", Date.Now, Date.Now, Nothing, Nothing, "0", Date.Now)
        '2019-03-11 Fin

        'Dim objPaciente As Paciente

        'objPaciente = Paciente.Instancia()
        'frmRepSegDolor.Show()
        'frmRepSegDolor.ImprimirReporteSeguimientoDolor(objConexion, objPaciente.CodHistoria, Nothing, Nothing, Nothing, Nothing)
    End Sub

    Private Sub cmdLaboratorio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLaboratorio.Click
        consultar_ordenes_laboratorio(objDatosGenerales)
    End Sub



    Private Sub PictureBox8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ctlCuidadosPaliativos As ctlCuidadoPaliativo



        ctlCuidadosPaliativos = ctlCuidadoPaliativo.Instancia
        pintarMenu(OpcionesMenu.CuidadosPaliativos)
        cambiarFondo(OpcionesMenu.CuidadosPaliativos)

        pnlContenedorListaEspera.Visible = False
        pnlContenedorPantallas.Visible = True

        'Me.pnlContenedorDatos.Controls.Clear()

        If Me.strNameControlLoad.Trim.Length > 0 And strNameControlLoad.ToUpper <> "CTLCUIDADOPALIATIVO" Then
            pnlContenedorDatos.Controls(strNameControlLoad).Visible = False
            strNameControlLoad = "ctlcuidadopaliativo"
        End If

        ctlCuidadosPaliativos.Dock = DockStyle.Fill
        ctlCuidadosPaliativos.Size = pnlContenedorDatos.Size
        ctlCuidadosPaliativos.AutoScroll = True
        Me.pnlContenedorDatos.Controls.Add(ctlCuidadosPaliativos)
        ctlCuidadosPaliativos.Show()
        ctlCuidadosPaliativos.AutoScrollPosition = New Point(0, 0)
        ' blnCtlEvolucion = True
    End Sub


    Private Sub btnProgramas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProgramas.Click
        Dim ctlOrdMedicas As ctlOrdenesMedicas
        ctlOrdMedicas = ctlOrdenesMedicas.Instancia

        If Not ctlOrdMedicas Is Nothing Then
            If ctlOrdMedicas.existenDatosSinAlmacenar() Then
                If ctlOrdMedicas.Visible = False Then
                    Me.btnOrdenes_Click(Me.btnOrdenes, New EventArgs())
                End If
                Select Case MessageBox.Show("No se ha guardado la informaci?n registrada, perder? los cambios realizados ?desea continuar?", "Historia Clinica", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)
                    Case Windows.Forms.DialogResult.OK
                        ctlOrdenesMedicas.Instancia.datosSinAlmacenar = False
                    Case Windows.Forms.DialogResult.Cancel
                        Exit Sub
                End Select
            End If
        End If

        If Me.strNameControlLoad.Trim.Length > 0 Then
            pnlContenedorDatos.Controls(strNameControlLoad).Visible = False

        End If

        Dim puedeGenerarProgramas As Integer

        Dim objPaciente As Paciente
        objPaciente = Paciente.Instancia()


        puedeGenerarProgramas = Me.objCP.ConsultarpermisosProgramas(objDatosGenerales.Prestador, objDatosGenerales.Sucursal)

        If puedeGenerarProgramas <> "1" Then
            MsgBox("La seccion programas no esta disponible para la sucursal", MsgBoxStyle.Information)
            Me.PnlProgramas.Visible = False
            Exit Sub
        End If



        Me.PnlProgramas.Visible = True
        Me.pnlMenuPlanManejo.Visible = False
        Me.pnlMenuConsultas.Visible = False
    End Sub


    Public Function consultar_ordenes_laboratorio(ByVal objDatosGenerales1 As Object)
        Dim objPaciente As Paciente
        Dim dtgPacientes As DataGridView
        Dim controlListaEspera As ListaEspera
        Dim strwsLabor As String
        ' Dim DatosPac As New ListaEspera

        ''Validacion de los parametros de entrada suministrador por sophia
        If objDatosGenerales1 Is Nothing Then
            MsgBox("No existen parametros de entrada.", MsgBoxStyle.Information)
            Exit Function
        End If

        ''Se obtiene el control Activo del contenedor de datos
        'controlListaEspera = pnlContenedorListaEspera.Controls("ListaEspera")
        controlListaEspera = ListaEspera.Instancia

        ''Si el control activo es la lista de espera

        'rmzaldua cambio solicitado por German Garzon para identificar si la sucursar tiene el flag del manejo de la interfaz de examenes de laboratorio 

        strwsLabor = TraerWSLabo_Sucursal(objDatosGenerales1.Prestador, objDatosGenerales1.Sucursal)
        'strwsLabor = "N"
        If strwsLabor = "S" Then
            If Not controlListaEspera Is Nothing Then
                dtgPacientes = controlListaEspera.dtgLista

                If dtgPacientes.CurrentRow Is Nothing Then

                    If controlListaEspera.DatosBasicosPac.Count > 0 Then
                        frmConsultaHCLaboratorio.mostrar(controlListaEspera.DatosBasicosPac(1), controlListaEspera.DatosBasicosPac(0))
                        Exit Function
                    Else
                        If controlListaEspera.txtCodigoTipoDocumento.Text.Trim <> "" And controlListaEspera.txtNumeroDocumento.Text.Trim <> "" Then
                            frmConsultaHCLaboratorio.mostrar(controlListaEspera.txtCodigoTipoDocumento.Text.Trim, controlListaEspera.txtNumeroDocumento.Text.Trim)
                            Exit Function
                        Else
                            frmConsultaHCLaboratorio.Show()
                            Exit Function
                        End If
                    End If
                End If
                With dtgPacientes.CurrentRow
                    If Len(.Cells("nombre").Value.ToString.Trim) <= 0 Then
                        frmConsultaHCLaboratorio.ShowDialog()
                    Else
                        If controlListaEspera.DatosBasicosPac.Count > 0 Then

                            frmConsultaHCLaboratorio.mostrar(controlListaEspera.DatosBasicosPac(1), controlListaEspera.DatosBasicosPac(0))
                        Else
                            frmConsultaHCLaboratorio.mostrar(.Cells("tip_doc").Value, .Cells("num_doc").Value)
                        End If
                    End If
                End With
            Else
                objPaciente = Paciente.Instancia()
                If Not objPaciente Is Nothing Then
                    frmConsultaHCLaboratorio.mostrar(objPaciente.TipoDocumento, objPaciente.NumeroDocumento)
                End If
            End If
        Else
            MsgBox("ESTA CONSULTA NO ESTA DISPONIBLE.")
        End If

    End Function

    Private Sub OrdenesMedicamentosControladosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrdenesMedicamentosControladosToolStripMenuItem.Click
        Dim objPaciente As Paciente
        Dim dtgPacientes As DataGridView
        Dim controlListaEspera As ListaEspera

        ''Validacion de los parametros de entrada suministrador por sophia
        If objDatosGenerales Is Nothing Then
            MsgBox("No existen parametros de entrada.", MsgBoxStyle.Information)
            Exit Sub
        End If

        ''Se obtiene el control Activo del contenedor de datos
        'controlListaEspera = pnlContenedorListaEspera.Controls("ListaEspera")
        controlListaEspera = ListaEspera.Instancia

        ''Si el control activo es la lista de espera
        If Not controlListaEspera Is Nothing Then

            'Los datos del paciente se toman del regitro seleccionado
            'en la grilla de pacientes
            dtgPacientes = controlListaEspera.dtgLista

            If dtgPacientes.CurrentRow Is Nothing Then
                MsgBox("Debe elegir primero un paciente.", MsgBoxStyle.Information)
                Exit Sub
            End If

            With dtgPacientes.CurrentRow
                If Len(.Cells("nombre").Value.ToString.Trim) <= 0 Then
                    MsgBox("Debe elegir primero un paciente.", MsgBoxStyle.Information)
                    Exit Sub
                End If

                reimprimirOrdenMedicaControl(.Cells("tip_admision").Value.ToString,
                                      .Cells("ano_adm").Value.ToString,
                                      .Cells("num_adm").Value.ToString)
            End With
        Else
            ''Si la historia esta abierta se obtiene la instancia del paciente
            ''creada cuando de abre la historia.
            objPaciente = Paciente.Instancia()
            If Not objPaciente Is Nothing Then
                reimprimirOrdenMedicaControl(objPaciente.TipoAdmision,
                                      objPaciente.AnoAdmision,
                                      objPaciente.NumeroAdmision)
            End If
        End If

    End Sub

    Private Sub LnkEnfActual_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkEnfActual.LinkClicked

        Dim sControl As HCBasica
        sControl = HCBasica.Instancia
        sControl.AutoScrollPosition = New Point(0, 130)
    End Sub

    Private Sub LnkRevSistemas_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkRevSistemas.LinkClicked
        Dim sControl As HCBasica
        sControl = HCBasica.Instancia
        sControl.AutoScrollPosition = New Point(0, 340)
    End Sub

    Private Sub LnkAnalisisPlan_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkAnalisisPlan.LinkClicked
        Dim sControl As HCBasica
        Dim sDatosP As ctlDatosPaciente

        sControl = HCBasica.Instancia
        sDatosP = ctlDatosPaciente.Instancia

        'sDatosP = Me.pnlContenedorPantallas.Controls("pnlContenedorDatosPaciente").Controls("ctlDatosPaciente")
        'sControl = Me.pnlContenedorPantallas.Controls("pnlContenedorDatos").Controls("HCBasica")
        'If sDatosP.lblGenero.Text = "FEMENINO" Then
        '    sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPerinatales.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesGinecologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedentesFamiliares.Height + sControl.pnlVacunas.Height + sControl.pnlExamenFisico.Height)
        'Else
        '    sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPerinatales.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedentesFamiliares.Height + sControl.pnlVacunas.Height + sControl.pnlExamenFisico.Height)
        'End If

        If (sControl.pnlTitAntPerinatales.Visible) Then
            sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedenteTransfusional.Height + sControl.pnlAntecedenteTraumatologico.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesFamiliares.Height + sControl.pnlAntecedentesPerinatales.Height + sControl.pnlVacunas.Height + sControl.pnlExamenFisico.Height + 500)
        End If

        If (sControl.pnlTitAntGineco.Visible) Then
            sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedenteTransfusional.Height + sControl.pnlAntecedenteTraumatologico.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesFamiliares.Height + sControl.pnlAntecedentesGinecologicos.Height + sControl.pnlVacunas.Height + sControl.pnlExamenFisico.Height + 500)
        End If

        If (sControl.pnlTitAntGineco.Visible = False And sControl.pnlTitAntPerinatales.Visible = False) Then
            sControl.AutoScrollPosition = New Point(0, sControl.pnlMotivoDeConsulta.Height + sControl.pnlAntecedentesPatologicos.Height + sControl.pnlAntecedentesQuirurgicos.Height + sControl.pnlAntecedentesAlergicos.Height + sControl.pnlAntecedentesToxicos.Height + sControl.pnlAntecedenteTransfusional.Height + sControl.pnlAntecedenteTraumatologico.Height + sControl.pnlAntecedentesFarmacologicos.Height + sControl.pnlAntecedentesFamiliares.Height + sControl.pnlVacunas.Height + sControl.pnlExamenFisico.Height + 500)
        End If

    End Sub

    Private Sub lnkAislamientos_Click(sender As Object, e As EventArgs) Handles lnkAislamientos.Click

        Dim sControl As ctlOrdenesMedicas

        sControl = ctlOrdenesMedicas.Instancia
        'sControl = Me.pnlContenedorPantallas.Controls("pnlContenedorDatos").Controls("ctlOrdenesMedicas")
        sControl.AutoScrollPosition = New Point(0, sControl.Panel2.Height + sControl.pnlAislamientos.Height)

    End Sub

    Private Sub btnResultadosLaboratorio_Click(sender As Object, e As EventArgs) Handles btnResultadosLaboratorio.Click
        consultar_resultados_laboratorio()
    End Sub


    Public Function consultar_resultados_laboratorio()
        Dim objPaciente As Paciente
        Dim mensaje As String = ""

        objPaciente = Paciente.Instancia()
        If Not objPaciente.NumeroDocumento Is Nothing Then
            frmConsultaResultadosLab.Show()
        Else
            MsgBox("No existen parametros de entrada.", MsgBoxStyle.Information)
            Exit Function
        End If

    End Function

    Private Sub lkResultadosLboratorio_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lkResultadosLboratorio.LinkClicked
        CarcarPatallaEvolucion()
        consultar_resultados_laboratorio()
    End Sub

    Private Sub lnkAislamientos_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAislamientos.LinkClicked

    End Sub

    Private Sub LnkRevSistemas_ContextMenuChanged(sender As Object, e As EventArgs) Handles LnkRevSistemas.ContextMenuChanged

    End Sub

    Private Sub lnkLiquidos_BindingContextChanged(sender As Object, e As EventArgs) Handles lnkLiquidos.BindingContextChanged

    End Sub

    Private Sub lkEscalaDolor_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lkEscalaDolor.LinkClicked

        Dim form As New Frm_EscalasVarias
        form.Mostrar(5)
    End Sub
    Private Sub lkSarnat_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lkSarnat.LinkClicked
        Dim sControl As ctlEscalasVarias
        sControl = ctlEscalasVarias.Instancia

        Dim form As New Frm_EscalasVarias
        form.Mostrar(2)

    End Sub

    Private Sub CargarEscalas(ByVal IdEscala As Int16)
        Dim sControl As ctlEscalasVarias
        sControl = ctlEscalasVarias.Instancia



        Dim ctlPantallaEscalasVarias As ctlEscalasVarias

        ctlPantallaEscalasVarias = ctlEscalasVarias.Instancia
        pintarMenu(OpcionesMenu.Evolucion)
        cambiarFondo(OpcionesMenu.Evolucion)

        pnlContenedorListaEspera.Visible = False
        pnlContenedorPantallas.Visible = True

        'Me.pnlContenedorDatos.Controls.Clear()

        If Me.strNameControlLoad.Trim.Length > 0 And strNameControlLoad.ToUpper <> "CTLESCALASVARIAS" Then
            pnlContenedorDatos.Controls(strNameControlLoad).Visible = False
            strNameControlLoad = "ctlEscalasVarias"
        End If

        blnCtlEvolucion = False

        If blnCtlEvolucion = False Then
            ctlPantallaEscalasVarias.Dock = DockStyle.Fill
            ctlPantallaEscalasVarias.Size = pnlContenedorDatos.Size
            ctlPantallaEscalasVarias.AutoScroll = True
            Me.pnlContenedorDatos.Controls.Add(ctlPantallaEscalasVarias)
            ctlPantallaEscalasVarias.Show()
            ctlPantallaEscalasVarias.AutoScrollPosition = New Point(0, 0)
            blnCtlEvolucion = True
        Else
            pnlContenedorDatos.Controls("ctlEvolucion").Visible = True
        End If
        pnlContenedorEnf.Visible = True ''cpgaray
        sControl.ConsultarPlantillaEscala(IdEscala)
        sControl.AutoScrollPosition = New Point(0, 0)
    End Sub

    Private Sub lnkSignosVitales_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkSignosVitales.LinkClicked
        'Dim objPaciente As Paciente
        Try
            'objPaciente = Paciente.Instancia()

            '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
            'Juan Carlos Jaramillo Lozano - IG
            RptHC_Enf_Med.Show()
            RptHC_Enf_Med.ImprimirHistoriaClinica(objConexion, "|srptEnfSignosVitales|", "42", Date.Now, Date.Now, Nothing, Nothing, "0", Date.Now)
            '2019-03-11 Fin

            'RptHC.ReporteSignosVitalesEnfermeria(objConexion, objDatosGenerales.Prestador, objDatosGenerales.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision,
            '                              objPaciente.NumeroAdmision, objDatosGenerales.NombreMedico)
            'RptHC.ShowDialog()
            'RptHC.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar el reporte de signos vitales")
        End Try
    End Sub

    Private Sub lnkNotasEnfermeria_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkNotasEnfermeria.LinkClicked
        Dim objPaciente As Paciente
        Try
            objPaciente = Paciente.Instancia()

            '2019-03-11 Inicio. Se direcciona el reporte al Servidor De Reporte Consolidado
            'Juan Carlos Jaramillo Lozano - IG
            RptHC_Enf_Med.Show()
            RptHC_Enf_Med.ImprimirHistoriaClinica(objConexion, "|srptEnfNotasHistorico|", "44", Date.Now, Date.Now, Nothing, Nothing, "0", Date.Now)
            '2019-03-11 Fin
            'RptHC.ReporteEvoluvionNotasEnfermeria(objConexion, objDatosGenerales.Prestador, objDatosGenerales.Sucursal, objPaciente.TipoAdmision, objPaciente.AnoAdmision,
            '                              objPaciente.NumeroAdmision, objDatosGenerales.NombreMedico, objPaciente.CodHistoria)
            'RptHC.ShowDialog()
            'RptHC.Close()
        Catch ex As Exception
            MessageBox.Show("Error al mostrar el reporte de signos vitales")
        End Try
    End Sub

    Private Sub btn360Layout_Click(sender As Object, e As EventArgs) Handles btn360Layout.Click
        Dim frm360 As New frm_360Layout()
        Try
            Dim objPaciente As Paciente = Paciente.Instancia()
            Dim DatosPaciente As String = String.Empty
            DatosPaciente += pnlContenedorDatosPaciente.Controls("ctlDatosPaciente").Controls(0).Controls("lblNombre").Text + Convert.ToChar(Keys.Space) + "|"
            DatosPaciente += pnlContenedorDatosPaciente.Controls("ctlDatosPaciente").Controls(0).Controls("lblTipoDocumento").Text + Convert.ToChar(Keys.Space) + " " + Convert.ToChar(Keys.Space)
            DatosPaciente += pnlContenedorDatosPaciente.Controls("ctlDatosPaciente").Controls(0).Controls("lblNumeroDocumento").Text + Convert.ToChar(Keys.Space)

            ' frm360.Text += DatosPaciente
            frm360.lblTxtForm.Text += DatosPaciente
            frm360.TipoDocumento = objPaciente.TipoDocumento ' pnlContenedorDatosPaciente.Controls("ctlDatosPaciente").Controls(0).Controls("lblTipoDocumento").Text
            frm360.NumeroDocumento = pnlContenedorDatosPaciente.Controls("ctlDatosPaciente").Controls(0).Controls("lblNumeroDocumento").Text
            Dim EnviaAuditoria As Long = New BLOrdenes().AuditoriaConsultasPAC360(0, objDatosGenerales.Prestador, objDatosGenerales.Sucursal, "", Year(DateTime.Now), 0, objDatosGenerales.RegistroMedico, "", "Consulta Paciente 360. Paciente: " + DatosPaciente)

            'If EnviaAuditoria > 0 Then
            '    If MessageBox.Show("No se logr? generar la auditoria, desea continuar?", "Paciente 360") = DialogResult.Cancel Then
            '        Exit Sub
            '    End If
            'Else
            frm360._objConexion = objConexion
            frm360.Show()
            'End If

        Catch
            Return
        End Try
    End Sub

    Private Function ValidarFinalizarHcb(ByVal datosPaciente As Paciente) As Boolean
        Dim objFinalizarHcb As New BLHistoriaBasica

        Dim Datos() As Object
        Dim lExistencia As Long
        Dim dtExistencia As DataTable

        ReDim Datos(4)
        Datos(0) = objGenerales.Generales.Instancia.Prestador
        Datos(1) = objGenerales.Generales.Instancia.Sucursal
        Datos(2) = datosPaciente.TipoAdmision
        Datos(3) = datosPaciente.AnoAdmision
        Datos(4) = datosPaciente.NumeroAdmision

        Try

            dtExistencia = objFinalizarHcb.NVALIDAGRABACIONFINALHcb(datosConexion, lExistencia, Datos)
            If dtExistencia.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Error Validacion Finalizar Historia Basica")
        End Try
    End Function

    Private Function ValidarDatosHisBasica(ByVal objDatosPaciente As Paciente) As Boolean
        ' V?lidar si los datos de Historia B?sica se encuentran grabados
        ' eloaiza@intergrupo.com
        ' Req. ER_OSI_584

        If objDatosPaciente.TipoAdmision <> "P" Then
            If Not ValidarFinalizarHcb() Then
                MessageBox.Show("Debe diligenciar primero Historia B?sica de Ingreso del paciente")
                Return False
            End If
        End If
        Return True
    End Function

    Private Function ValidarFinalizarHcb() As Boolean
        Dim objFinalizarHcb As New BLHistoriaBasica

        Dim Datos() As Object
        Dim lExistencia As Long
        Dim dtExistencia As DataTable
        Dim datosPaciente As Paciente = Paciente.Instancia

        ReDim Datos(4)
        Datos(0) = objGenerales.Generales.Instancia.Prestador
        Datos(1) = objGenerales.Generales.Instancia.Sucursal
        Datos(2) = datosPaciente.TipoAdmision
        Datos(3) = datosPaciente.AnoAdmision
        Datos(4) = datosPaciente.NumeroAdmision

        Try
            'Control de cambios CU ELIMINAR RESTRICCI?N HISTORIA BASICA
            'Solicitado por Luis Nieto / William Ruiz por salida proyecto pyxis
            'cdquiroga 16/03/2021
            'dtExistencia = objFinalizarHcb.NVALIDAGRABACIONFINALHcb(datosConexion, lExistencia, Datos)
            'If dtExistencia.Rows.Count > 0 Then
            '    Return True
            'Else
            '    Return False
            'End If
            Return True

        Catch ex As Exception
            MessageBox.Show("Error Validacion Finalizar Historia Basica")
        End Try
    End Function
    'Private Sub btnPConsultaHCAvicena_Click(sender As Object, e As EventArgs) Handles btnPConsultaHCAvicena.Click
    '    Dim form As New FrmConsultaHCAvicena
    '    form.Mostrar()
    'End Sub


    Private Function ValidarTraslado() As Boolean

        Dim AdmDestino As String
        Dim objPaciente = Paciente.Instancia()

        AdmDestino = datosLogin.ValidadAdmTrasladada(datosConexion, datosLogin.Prestador, datosLogin.Sucursal, objPaciente.TipoAdmision,
                                              objPaciente.AnoAdmision, objPaciente.NumeroAdmision)

        If AdmDestino <> objPaciente.TipoAdmision.ToString & "-" &
                                              objPaciente.AnoAdmision.ToString & "-" & objPaciente.NumeroAdmision.ToString Then

            MessageBox.Show("El paciente ha sido trasladada a est?  admisi?n " & AdmDestino &
                                        ", debe buscarlo en la Lista de Espera.", "Historia Cl?nica", MessageBoxButtons.OK, MessageBoxIcon.Information)

            CargarListaEspera()
            Return True
        Else
            Return False

        End If



    End Function

    Private Sub pnlContenedorDatos_Paint(sender As Object, e As PaintEventArgs) Handles pnlContenedorDatos.Paint

    End Sub

    Private Sub btnPConsultaHCAvicena_Click(sender As Object, e As EventArgs) Handles btnPConsultaHCAvicena.Click
        Dim formulario As New FrmConsultaHCAvicena()
        formulario.Mostrar()
        FrmConsultaHCAvicena.Show()
    End Sub

    Private Sub pnlContenedorDatosPaciente_Paint(sender As Object, e As PaintEventArgs) Handles pnlContenedorDatosPaciente.Paint

    End Sub
End Class



