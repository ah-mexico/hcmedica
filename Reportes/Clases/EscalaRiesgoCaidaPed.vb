'rcruzr se crea clase que maneja los datos de la escala de riesgo pediatria 2018/05/10
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports System.Collections.Generic
Imports System.Data.Common

Namespace Sophia.HistoriaClinica.Reportes
    Public Class EscalaRiesgoCaidaPed
        Inherits GPMDataReport

        Private _cod_historia As String    'codigo historia       
        Private _consecutivo As String  'consecutivo
        Private _fecha As String 'fecha
        Private _desc_tiporiesgo As String 'descripcion riesgo
        Private _medico As String 'medico
        Private _cargo As String 'cargo
        Private _total_Escala As String 'total escala
        Private _hora_riesgocaida As String
        Private _min_riesgocaida As String
        Private _desc_categoriariesgo As String
        Private _Riesgo As String
        Private _IdEscala As String

        Public Sub New()
            MyBase.New()
        End Sub
        Public Property IdEscala() As String
            Get
                Return _IdEscala
            End Get
            Set(ByVal value As String)
                _IdEscala = value
            End Set
        End Property
        Public Property Riesgo() As String
            Get
                Return _Riesgo
            End Get
            Set(ByVal value As String)
                _Riesgo = value
            End Set
        End Property
        Public Property Cod_historia() As String
            Get
                Return _cod_historia
            End Get
            Set(ByVal value As String)
                _cod_historia = value
            End Set
        End Property
        Public Property Consecutivo() As String
            Get
                Return _consecutivo
            End Get
            Set(ByVal value As String)
                _cod_historia = value
            End Set
        End Property
        Public Property Desc_tiporiesgo() As String
            Get
                Return _desc_tiporiesgo
            End Get
            Set(ByVal value As String)
                _desc_tiporiesgo = value
            End Set
        End Property
        Public Property Fecha() As String
            Get
                Return _fecha
            End Get
            Set(ByVal value As String)
                _fecha = value
            End Set
        End Property

        Public Property Medico() As String
            Get
                Return _medico
            End Get
            Set(ByVal value As String)
                _medico = value
            End Set
        End Property

        Public Property Cargo() As String
            Get
                Return _cargo
            End Get
            Set(ByVal value As String)
                _cargo = value
            End Set
        End Property
        Public Property Total_Escala() As String
            Get
                Return _total_Escala
            End Get
            Set(ByVal value As String)
                _total_Escala = value
            End Set
        End Property

        Public Property hora_riesgocaida() As String
            Get
                Return _hora_riesgocaida
            End Get
            Set(ByVal value As String)
                _hora_riesgocaida = value
            End Set
        End Property
        Public Property min_riesgocaida() As String
            Get
                Return _min_riesgocaida
            End Get
            Set(ByVal value As String)
                _min_riesgocaida = value
            End Set
        End Property

        Public Property desc_categoriariesgo() As String
            Get
                Return _desc_categoriariesgo
            End Get
            Set(ByVal value As String)
                _desc_categoriariesgo = value
            End Set
        End Property


        Public Sub New(ByVal scod As String, ByVal sconsecutivo As String, ByVal dfecha As String, ByVal sDescr As String, ByVal smedico As String, ByVal scargo As String, ByVal Itotal As String, ByVal hora As String, ByVal minuto As String, ByVal categoria_riesgo As String, ByVal Riesgo As String, ByVal IdEscala As String)

            _cod_historia = scod
            _consecutivo = sconsecutivo
            _fecha = dfecha
            _desc_tiporiesgo = sDescr
            _medico = smedico
            _cargo = scargo
            _total_Escala = Itotal
            _hora_riesgocaida = hora
            _min_riesgocaida = minuto
            _desc_categoriariesgo = categoria_riesgo
            _Riesgo = Riesgo
            _IdEscala = IdEscala


        End Sub


        Public Function consultarEscalaRiesgo(ByVal objConexion As Conexion, ByVal dCod_Historia As Integer, ByVal strFechaIni As Nullable(Of Date), ByVal strFechaFin As Nullable(Of Date), ByVal iHoraIni As Nullable(Of Integer), ByVal iHoraFin As Nullable(Of Integer), ByVal IdEscala As Integer) As List(Of EscalaRiesgoCaidaPed)
            Dim lError As Long = 0
            Dim objEscalaRiesgoN As EscalaRiesgoCaidaPed
            Dim listaEscala As New List(Of EscalaRiesgoCaidaPed)
            Dim dtSetReturn As DataSet
            gpmDataObj.setSQLSentence("HCENF_TraerRiesgoDetRep", CommandType.StoredProcedure)
            gpmDataObj.addInputParameter("@codhistoria", SqlDbType.Int, dCod_Historia)
            gpmDataObj.addInputParameter("@strFechaIni", SqlDbType.DateTime, strFechaIni)
            gpmDataObj.addInputParameter("@strFechaFin", SqlDbType.DateTime, strFechaFin)
            gpmDataObj.addInputParameter("@iHoraIni", SqlDbType.Int, iHoraIni)
            gpmDataObj.addInputParameter("@iHoraFin", SqlDbType.Int, iHoraFin)
            gpmDataObj.addInputParameter("@IdEscala", SqlDbType.Int, IdEscala) '20180508 rcruzr requerimientos escalas
            gpmDataObj.addOutputParameter("lError", SqlDbType.Int, lError)

            dtSetReturn = gpmDataObj.execDS() 'llarias1
            'Return dtSetReturn 'llarias
            'dtSetReturn = gpmDataObj.ExecRdr 'llarias
            'Do While dtSetReturn.Read



            For i As Integer = 0 To dtSetReturn.Tables(0).Rows.Count.ToString() - 1
                objEscalaRiesgoN = New EscalaRiesgoCaidaPed
                With objEscalaRiesgoN
                    ._cod_historia = dtSetReturn.Tables(0).Rows(i).Item("cod_historia").ToString()
                    ._consecutivo = dtSetReturn.Tables(0).Rows(i).Item("IDESCENCABEZADO").ToString
                    ._fecha = dtSetReturn.Tables(0).Rows(i).Item("FECHAEVENTO").ToString
                    ._desc_tiporiesgo = dtSetReturn.Tables(0).Rows(i).Item("PREGUNTA").ToString()
                    ._medico = dtSetReturn.Tables(0).Rows(i).Item("LOGIN").ToString
                    ._cargo = dtSetReturn.Tables(0).Rows(i).Item("cargo").ToString
                    ._total_Escala = dtSetReturn.Tables(0).Rows(i).Item("PUNTAJE").ToString()
                    ._hora_riesgocaida = dtSetReturn.Tables(0).Rows(i).Item("HORAEVENTO").ToString()
                    ._min_riesgocaida = dtSetReturn.Tables(0).Rows(i).Item("MINUTOEVENTO").ToString()
                    ._desc_categoriariesgo = dtSetReturn.Tables(0).Rows(i).Item("PARAMETRO").ToString()
                    ._Riesgo = dtSetReturn.Tables(0).Rows(i).Item("Riesgo").ToString()
                    ._IdEscala = dtSetReturn.Tables(0).Rows(i).Item("IdEscala").ToString()

                    '._cod_historia = dtSetReturn.Tables(1).Rows(i).Item("cod_historia").ToString()
                    '._consecutivo = dtSetReturn.Tables(1).Rows(i).Item("consecutivo").ToString
                    '._fecha = dtSetReturn.Tables(1).Rows(i).Item("fecha").ToString
                    '._desc_tiporiesgo = dtSetReturn.Tables(1).Rows(i).Item("desc_tiporiesgo").ToString()
                    '._medico = dtSetReturn.Tables(1).Rows(i).Item("medico").ToString
                    '._cargo = dtSetReturn.Tables(1).Rows(i).Item("cargo").ToString
                    '._total_Escala = dtSetReturn.Tables(1).Rows(i).Item("valor").ToString()
                    '._hora_riesgocaida = dtSetReturn.Tables(1).Rows(i).Item("hora_riesgocaida").ToString()
                    '._min_riesgocaida = dtSetReturn.Tables(1).Rows(i).Item("min_riesgocaida").ToString()
                    '._desc_categoriariesgo = dtSetReturn.Tables(1).Rows(i).Item("desc_categoriariesgo").ToString()

                    listaEscala.Add(objEscalaRiesgoN)
                End With

            Next


            Return listaEscala


            'Return gpmDataObj.execDT
        End Function



    End Class
End Namespace
