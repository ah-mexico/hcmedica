Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Namespace Sophia.HistoriaClinica.BL


    Public Class BLNotasAclaratorias



        Public Shared Sub BLActualizaNotasAclatorias(ByVal objdatosNotasAclaratoria As datosNotasAclaratoria, ByVal strNotaAclara As String, ByVal strObservaciones As String, ByVal intadmisionExistente As Integer)

            With objdatosNotasAclaratoria
                If .Prestadora.Length = 0 Then
                    Throw New Exception("Falta el c�digo de la prestadora.")
                End If
                If .Sucursal.Length = 0 Then
                    Throw New Exception("Falta el c�digo de la sucursal.")
                End If
                If .Admision.Length = 0 Then
                    Throw New Exception("Falta el n�mero de admisi�n.")
                End If
                If .AnnoAdmision.Length = 0 Then
                    Throw New Exception("Falta el a�o de la admisi�n.")
                End If
                If .TipoAdmision.Length = 0 Then
                    Throw New Exception("Falta el codigo de tipo de admisi�n.")
                End If

            End With

            Dim daoNts As New DAONotas()
            daoNts.DAOActualizaNotasAclaratorias(objdatosNotasAclaratoria, strNotaAclara, "", intadmisionExistente)

        End Sub


        Public Shared Function BLTraerNotas(ByVal objNotas As datosNotasAclaratoria) As DataTable
            Dim dtResultado As DataTable

            With objNotas
                If .Prestadora.Length = 0 Then
                    Throw New Exception("Falta el c�digo de la prestadora.")
                End If
                If .Sucursal.Length = 0 Then
                    Throw New Exception("Falta el c�digo de la sucursal.")
                End If
                If .Admision.Length = 0 Then
                    Throw New Exception("Falta el n�mero de admisi�n.")
                End If
                If .AnnoAdmision.Length = 0 Then
                    Throw New Exception("Falta el a�o de la admisi�n.")
                End If
                If .TipoAdmision.Length = 0 Then
                    Throw New Exception("Falta el codigo de tipo de admisi�n.")
                End If
            End With

            Dim daoNts As New DAONotas()
            dtResultado = daoNts.DAOTraerNotas(objNotas)

            Return dtResultado
        End Function


        Public Shared Function BLTraerHistorias(ByVal strTipoDoc As String, ByVal strNumDoc As String, ByVal strXMLUnificados As String) As DataSet
            Dim dtsHistorias As New DataSet

            If strTipoDoc.Length = 0 Then
                Throw New Exception("Falta el tipo de documento.")
            End If

            If strNumDoc.Length = 0 Then
                Throw New Exception("Falta el n�mero del documento.")
            End If

            Dim daoNts As New DAONotas()
            dtsHistorias = daoNts.DAOTraerHistorias(strTipoDoc, strNumDoc, strXMLUnificados)
            Return dtsHistorias

        End Function



        Public Structure datosNotasAclaratoria
            Public Prestadora As String
            Public Sucursal As String
            Public TipoAdmision As String
            Public Admision As String
            Public AnnoAdmision As String
            Public HoraNota As Date
        End Structure

    End Class



End Namespace
