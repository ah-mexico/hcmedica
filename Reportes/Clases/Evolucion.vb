Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.Reportes
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports Microsoft.Reporting.WinForms
Imports System.Collections.Generic
Imports System.Data.Common


Namespace Sophia.HistoriaClinica.Reportes
    ''' <summary>
    ''' Clase que encapsula los datos de una nota de evolucion
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Evolucion
        Inherits GPMDataReport

        Private _fecha As String                'Fecha de la evolucion
        Private _hora As String                 'Hora de la evolucion
        Private _minuto As String               'Minuto de la evolucion
        Private _diagnostico As String          'Nota de evolucion
        Private _sujetivo As String
        Private _interpretacion As String
        Private _objetivo As String
        Private _planManejo As String
        Private _strNotaIngreso As String       'Notas de ingreso
        Private _medico As String               'Nombre del medico
        Private _registroMedico As String       'Registro del Medico
        Private _exp_pla As String       'Registro del Medico
        Private _con_med As String       'Registro del Medico
        Private _secuencia As String
        Private _pais As String
        Private _Interconsulta As String
        Private _EspecialidadMedico As String
        Private _cierre As String
        Private objDatosGenerales As objGeneral.Generales


#Region "Propiedades"

        Public ReadOnly Property EspecialidadMedico() As String
            Get
                Return _EspecialidadMedico
            End Get
        End Property

        Public ReadOnly Property Interconsulta() As String
            Get
                Return _Interconsulta
            End Get
        End Property

        Public ReadOnly Property cierre() As String
            Get
                Return _cierre
            End Get
        End Property

        Public ReadOnly Property Fecha() As String
            Get
                Return _fecha
            End Get
        End Property
        Public ReadOnly Property Hora() As String
            Get
                Return _hora
            End Get
        End Property
        Public ReadOnly Property Minuto() As String
            Get
                Return _minuto
            End Get
        End Property
        Public ReadOnly Property Diagnostico() As String
            Get
                Return _diagnostico
            End Get
        End Property
        Public ReadOnly Property Subjetivo() As String
            Get
                Return _sujetivo
            End Get
        End Property
        Public ReadOnly Property Interpretacion() As String
            Get
                Return _interpretacion
            End Get
        End Property
        Public ReadOnly Property Objetivo() As String
            Get
                Return _objetivo
            End Get
        End Property
        Public ReadOnly Property PlanDeManejo() As String
            Get
                Return _planManejo
            End Get
        End Property
        Public ReadOnly Property NotasIngreso() As String  ''Claudia Garay 2010-06-09
            Get
                Return _strNotaIngreso
            End Get
        End Property
        Public ReadOnly Property Medico() As String
            Get
                Return _medico
            End Get
        End Property
        Public ReadOnly Property RegistroMedico() As String
            Get
                Return _registroMedico
            End Get
        End Property
        Public ReadOnly Property exp_pla() As String
            Get
                Return _exp_pla
            End Get
        End Property

        Public Property secuencia() As String
            Get
                Return _secuencia
            End Get
            Set(ByVal value As String)
                _secuencia = value
            End Set
        End Property

        Public Property Pais() As String
            Get
                Return _pais
            End Get
            Set(ByVal value As String)
                _pais = value
            End Set
        End Property




        Public ReadOnly Property con_med() As String
            Get
                Return _con_med
            End Get
        End Property
#End Region

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal strfecha As String, ByVal strhora As String, ByVal strminuto As String, _
            ByVal strdiagnostico As String, ByVal strsubjetivo As String, ByVal strInterpretacion As String, _
            ByVal strobjetivo As String, ByVal strplanManejo As String, ByVal strMedico As String, ByVal strReg As String, _
            ByVal strNotaIngreso As String, ByVal strexp_pla As String, ByVal strcon_med As String, ByVal strinterconsulta As String, ByVal strcierre As String, ByVal strespecialidad As String)
            Dim fecha As Date


            If strfecha.Length > 0 Then
                fecha = strfecha
                _fecha = Format(fecha, "dd/MMMM/yyyy")
            Else
                _fecha = ""
            End If

            _hora = strhora
            _minuto = strminuto
            _diagnostico = strdiagnostico
            _sujetivo = strsubjetivo
            _interpretacion = strInterpretacion
            _objetivo = strobjetivo
            _planManejo = strplanManejo
            _medico = strMedico
            _registroMedico = strReg
            _strNotaIngreso = strNotaIngreso ''Claudia Garay
            _exp_pla = strexp_pla
            _con_med = strcon_med
            _Interconsulta = strinterconsulta
            _EspecialidadMedico = strespecialidad ''cpgaray OS 7509755
            _cierre = strcierre



        End Sub

   

        ''' <summary>
        ''' Consulta el stored Procedure que devuelve la informacion 
        ''' de una determinada evolucion 
        ''' </summary>
        ''' <param name="strcod_pre_sgs">Codigo del prestador</param>
        ''' <param name="strCod_sucur">Codigo de la sucursal</param>
        ''' <param name="strTip_admision">Tipo de Admision</param>
        ''' <param name="iAno_adm">Año de la Admision</param>
        ''' <param name="lNum_adm">Numero de la admision a la que se le hace la nota</param>
        ''' <param name="strFecha_evol">Fecha de realizacion de la nota</param>
        ''' <param name="iHora_evol">Hora de realizacion de la nota</param>
        ''' <param name="iMin_evol">Minuto de realizacion de la nota</param>
        ''' <param name="strLogin">Login que realizo la nota</param>
        ''' <remarks></remarks>
        Public Function consultarEvolucion(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, _
               ByVal strCod_sucur As String, ByVal strTip_admision As String, _
               ByVal iAno_adm As String, ByVal lNum_adm As Long, _
               ByVal strFecha_evol As String, ByVal iHora_evol As Integer, _
               ByVal iMin_evol As Integer, ByVal strLogin As String, Optional ByVal fec_ini As String = "", _
               Optional ByVal fec_fin As String = "") As List(Of Evolucion)

            '' ''cavila@colsanitas.com unificacion, cambio acceso a base de datos de librerias microsoft a
            '' '' la clase DataLayer en este caso llamada GPMData 13/12/2007
            Dim dtReader As DbDataReader
            Dim objEvolucion As Evolucion
            Dim listaEvoluciones As New List(Of Evolucion)
            Dim strRegMedico As String = ""

            objDatosGenerales = objGeneral.Generales.Instancia

            gpmDataObj.setSQLSentence("HC_Reportes_Evolucion", CommandType.StoredProcedure)

            gpmDataObj.addInputParameter("strcod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            gpmDataObj.addInputParameter("strCod_sucur", SqlDbType.VarChar, strCod_sucur)
            gpmDataObj.addInputParameter("strTip_admision", SqlDbType.VarChar, strTip_admision)
            gpmDataObj.addInputParameter("lano_adm", SqlDbType.Int, iAno_adm)
            gpmDataObj.addInputParameter("dnum_adm", SqlDbType.Decimal, lNum_adm)
            gpmDataObj.addInputParameter("fecha_evol", SqlDbType.VarChar, strFecha_evol)
            gpmDataObj.addInputParameter("hora_evol", SqlDbType.Int, iHora_evol)
            gpmDataObj.addInputParameter("min_evol", SqlDbType.Int, iMin_evol)
            gpmDataObj.addInputParameter("strLogin", SqlDbType.VarChar, strLogin)
            'If fec_ini <> "" Then
            '    gpmDataObj.addInputParameter("fec_ini", SqlDbType.DateTime, fec_ini)
            '    gpmDataObj.addInputParameter("fec_fin", SqlDbType.DateTime, fec_fin)
            'End If
            dtReader = gpmDataObj.ExecRdr()



            While dtReader.Read()
                If strFecha_evol.Length = 0 Then
                    If dtReader("interconsulta").ToString = "" Or dtReader("interconsulta").ToString = "N" Then
                        strRegMedico = ""
                        strRegMedico = dtReader("reg_med").ToString


                        _pais = "480" '' dtReader("Pais").ToString

                        If objDatosGenerales.Pais = "482" Then ''agregar segundo registro médico para Perú. Cpgaray Octubre 21 de 2013
                            If Len(dtReader("reg_med2").ToString) = 0 Then
                                strRegMedico = dtReader("reg_med").ToString
                            Else
                                strRegMedico = dtReader("reg_med").ToString & " - " & dtReader("reg_med2").ToString
                            End If
                            _secuencia = dtReader("Secuencia").ToString
                        End If

                        objEvolucion = New Evolucion(dtReader("fecha_evol").ToString, _
                                                      dtReader("hora_evol").ToString, dtReader("min_evol").ToString, _
                                                      dtReader("diagnostico").ToString, dtReader("subjetivo").ToString, _
                                                      dtReader("paraclinico").ToString, dtReader("Objetivo").ToString, _
                                                      dtReader("planmanejo").ToString, dtReader("NombreMedico").ToString, _
                                                      strRegMedico, dtReader("NotasIngreso").ToString, _
                                                      dtReader("exp_pla").ToString, dtReader("con_med").ToString, dtReader("interconsulta").ToString, dtReader("flagcierre").ToString, dtReader("especialidad").ToString) ''cpgaray OS 7509755
                        listaEvoluciones.Add(objEvolucion)
                    End If
                Else

                    strRegMedico = ""
                    strRegMedico = dtReader("reg_med").ToString


                    _pais = "480" '' dtReader("Pais").ToString

                    If objDatosGenerales.Pais = "482" Then ''agregar segundo registro médico para Perú. Cpgaray Octubre 21 de 2013
                        If Len(dtReader("reg_med2").ToString) = 0 Then
                            strRegMedico = dtReader("reg_med").ToString
                        Else
                            strRegMedico = dtReader("reg_med").ToString & " - " & dtReader("reg_med2").ToString
                        End If
                        _secuencia = dtReader("Secuencia").ToString
                    End If

                    objEvolucion = New Evolucion(dtReader("fecha_evol").ToString, _
                                                  dtReader("hora_evol").ToString, dtReader("min_evol").ToString, _
                                                  dtReader("diagnostico").ToString, dtReader("subjetivo").ToString, _
                                                  dtReader("paraclinico").ToString, dtReader("Objetivo").ToString, _
                                                  dtReader("planmanejo").ToString, dtReader("NombreMedico").ToString, _
                                                  strRegMedico, dtReader("NotasIngreso").ToString, _
                                                  dtReader("exp_pla").ToString, dtReader("con_med").ToString, dtReader("interconsulta").ToString, dtReader("flagcierre").ToString, dtReader("especialidad").ToString)
                    listaEvoluciones.Add(objEvolucion)
                End If

            End While

            If dtReader.IsClosed = False Then
                dtReader.Close()
            End If

            Return listaEvoluciones

        End Function

        'Martovar 2014-08-21  se agrega validacion si existe una orden de interconsulta para la especialidad del medico que ingresa
        Public Function consultarEspecialidadInterconsulta(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, _
                   ByVal strCod_sucur As String, ByVal strTip_admision As String, _
                   ByVal iAno_adm As String, ByVal lNum_adm As Long, ByVal medico As String, ByVal EspecialidadMedico As String) As String

            Dim lError As Long = 0
            Dim dtReader2 As DbDataReader
            Dim RecordCount As Long
            gpmDataObj.setSQLSentence("Hc_TraerOrdenInterconsulta", CommandType.StoredProcedure)
            gpmDataObj.ClearParameters()
            gpmDataObj.addInputParameter("strcod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            gpmDataObj.addInputParameter("strCod_sucur", SqlDbType.VarChar, strCod_sucur)
            gpmDataObj.addInputParameter("strTip_admision", SqlDbType.VarChar, strTip_admision)
            gpmDataObj.addInputParameter("iAno_adm", SqlDbType.Int, iAno_adm)
            gpmDataObj.addInputParameter("lNum_adm", SqlDbType.Decimal, lNum_adm)
            gpmDataObj.addInputParameter("strmedico", SqlDbType.VarChar, medico)
            gpmDataObj.addInputParameter("strespecialidad", SqlDbType.VarChar, EspecialidadMedico)

            dtReader2 = gpmDataObj.ExecRdr()

            While dtReader2.Read()
                RecordCount = RecordCount + 1
            End While

            If dtReader2.IsClosed = False Then
                dtReader2.Close()
            End If

            If RecordCount > 0 Then
                Return "SI" 'ENCONTRO DATOS DE ORDEN 
            Else
                Return "NO" 'NO ENCONTRO DATOS DE ORDEN
            End If

        End Function

        'Martovar 2014-08-21  se agraga validacion de medico tratante
        Public Function consultarMedicoTratante(ByVal objConexion As Conexion, ByVal strcod_pre_sgs As String, _
                   ByVal strCod_sucur As String, ByVal strTip_admision As String, _
                   ByVal iAno_adm As String, ByVal lNum_adm As Long, ByVal medico As String, ByVal especialidadmedico As String) As String

            Dim lError As Long = 0
            Dim dtReader1 As DbDataReader
            Dim RecordCount As Long
            gpmDataObj.setSQLSentence("Hc_TraerMedTratante", CommandType.StoredProcedure)
            gpmDataObj.ClearParameters()
            gpmDataObj.addInputParameter("strcod_pre_sgs", SqlDbType.VarChar, strcod_pre_sgs)
            gpmDataObj.addInputParameter("strCod_sucur", SqlDbType.VarChar, strCod_sucur)
            gpmDataObj.addInputParameter("strTip_admision", SqlDbType.VarChar, strTip_admision)
            gpmDataObj.addInputParameter("iAno_adm ", SqlDbType.Int, iAno_adm)
            gpmDataObj.addInputParameter("lNum_adm ", SqlDbType.Decimal, lNum_adm)
            gpmDataObj.addInputParameter("strmedico", SqlDbType.VarChar, medico)
            gpmDataObj.addInputParameter("strespecialidadmedico", SqlDbType.VarChar, especialidadmedico)

            dtReader1 = gpmDataObj.ExecRdr()

            While dtReader1.Read()
                RecordCount = RecordCount + 1
            End While
            If dtReader1.IsClosed = False Then
                dtReader1.Close()
            End If

            If RecordCount > 0 Then
                Return "NO" 'SI ES LA MISMA ESPECIALIDAD

            Else
                Return "SI" 'NO ES LA MISMA ESPECIALIDAD
            End If

        End Function


    End Class
End Namespace
