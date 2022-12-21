Imports objGeneral = HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales.Generales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports objCon = HistoriaClinica.Sophia.HistoriaClinica.DatosConexion.Conexion
Imports HistoriaClinica.Sophia.HistoriaClinica.Comunes
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO

Namespace Sophia.HistoriaClinica.BL
    Public Class BLFechas
        Inherits GPMData
        Private datosconexion As objCon
#Region "BLFechas"

#Region "consultarHoraDif"
        Public Shared Function consultarHoraDif(ByVal objConexion As Conexion) As Integer
            Dim daoFechas As New DAOFechas()

            Return daoFechas.consultarHoraDif(objConexion)
        End Function
#End Region

#Region "validarFecMenor"
        Public Shared Function validarFecMenor(ByVal objConexion As Conexion, ByVal strFecha As String, ByVal intHora As Integer, _
                                ByVal intMinuto As Integer, Optional ByRef mensaje As String = "") As Boolean
            Dim lMinutosDif As Integer
            Dim lMinDif As Integer
            Dim strError As String = ""
            Dim intHoraS As Integer
            Dim intMinutoS As Integer
            Dim strFechaS As String = ""
            Dim strFechaD As String = ""
            Dim dtFechaServidor As Date
            Dim dtFechaServidorD As Date
            Dim strhoras As Integer
            Dim strminutos As Integer
            Dim lHorDif As Integer
            Dim intHoraD As Integer


            dtFechaServidor = FuncionesGenerales.FechaServidor()
            dtFechaServidorD = FuncionesGenerales.FechaServidor()
            dtFechaServidorD = dtFechaServidorD.AddDays(1)

            strFechaD = Format(dtFechaServidorD, "dd/MM/yyyy")
            strFechaS = Format(dtFechaServidor, "dd/MM/yyyy")
            intHoraS = Hour(dtFechaServidor)
            intMinutoS = Minute(dtFechaServidor)

            strhoras = intHoraS - intHora
            strminutos = intMinutoS - intMinuto
            lMinutosDif = strminutos + (strhoras * 60)

            lMinDif = consultarHoraDif(objConexion) * 60
            lHorDif = consultarHoraDif(objConexion)

            intHoraD = intHora + lHorDif
            Try
                If intHoraD >= 24 Then
                    intHoraD = 0

                    If CDate(strFechaD + " " + CStr(intHoraD) + ":" + CStr(intMinuto)) < dtFechaServidor Then
                        mensaje = ("Fecha Inferior a el límite Permitidos  de " & lHorDif & " Horas.")
                        Return False
                    End If

                    If Not IsDate(strFecha) Or strFecha = "  /  /" Or Len(intHora) = 0 Or Len(intMinuto) = 0 Or Len(strFecha) < 10 Then
                        mensaje = "Debe ingresar la fecha correctamente."
                        Return False
                    End If

                    If CDate(strFecha + " " + CStr(intHora) + ":" + CStr(intMinuto)) > dtFechaServidor Then
                        mensaje = "Fecha excede el límite superior permitido."
                        Return False
                    End If

                Else

                    If CDate(strFecha + " " + CStr(intHoraD) + ":" + CStr(intMinuto)) < dtFechaServidor Then

                        mensaje = ("Fecha Inferior a el límite Permitidos  de " & lHorDif & " Horas.")
                        Return False
                    End If

                    If Not IsDate(strFecha) Or strFecha = "  /  /" Or Len(intHora) = 0 Or Len(intMinuto) = 0 Or Len(strFecha) < 10 Then
                        mensaje = "Debe ingresar la fecha correctamente."
                        Return False
                    End If

                    If CDate(strFecha + " " + CStr(intHora) + ":" + CStr(intMinuto)) > dtFechaServidor Then
                        mensaje = "Fecha excede el límite superior permitido."
                        Return False
                    End If
                End If
            Catch ex As Exception
                MsgBox("Error al validar fechas:" + ex.Message, MsgBoxStyle.Critical)
                Return False
            End Try

            Return True
        End Function
#End Region

#Region "validarFecNormal"
        Public Shared Function validarFecNormal(ByVal objConexion As Conexion, ByVal strFecha As String, ByVal intHora As Integer, _
                                ByVal intMinuto As Integer, Optional ByRef mensaje As String = "") As Boolean
            Dim lMinutosDif As Integer
            Dim lMinDif As Integer
            Dim strError As String = ""
            Dim intHoraS As Integer
            Dim intMinutoS As Integer
            Dim strFechaS As String = ""
            Dim dtFechaServidor As Date

            Dim strhoras As Integer
            Dim strminutos As Integer
            Dim lHorDif As Integer

            dtFechaServidor = FuncionesGenerales.FechaServidor()

            strFechaS = Format(dtFechaServidor, "dd/MM/yyyy")
            intHoraS = Hour(dtFechaServidor)
            intMinutoS = Minute(dtFechaServidor)

            strhoras = intHoraS - intHora
            strminutos = intMinutoS - intMinuto
            lMinutosDif = strminutos + (strhoras * 60)

            lMinDif = consultarHoraDif(objConexion) * 60
            lHorDif = consultarHoraDif(objConexion)


            If Not IsDate(strFecha) Or strFecha = "  /  /" Or Len(intHora) = 0 Or Len(intMinuto) = 0 Or Len(strFecha) < 10 Then
                mensaje = "Debe ingresar la fecha correctamente."
                Return False
            End If

            If CDate(strFecha + " " + CStr(intHora) + ":" + CStr(intMinuto)) > dtFechaServidor Then
                mensaje = "Fecha excede el límite superior permitido."

                Return False
            End If

            If CDate(strFecha) < strFechaS Then
                mensaje = ("Fecha Inferior a el límite Permitidos.")
                Return False
            End If



            Return True
        End Function
#End Region

#End Region
    End Class

End Namespace