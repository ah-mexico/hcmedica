Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Namespace Sophia.HistoriaClinica.DAO
    Public Class DAOEgresoCP
        Inherits GPMData

        Public Function GrabarEgresoCP(ByVal objConexion As Conexion, ByVal strCod_pre_sgs As String,
                                               ByVal strCod_sucur As String, ByVal strTip_Admision As String,
                                               ByVal strAno_Adm As Integer, ByVal strNum_Adm As Double,
                                               ByVal strtip_doc As String, ByVal strnum_doc As String,
                                               ByVal strFechaEgreso As String,
                                               ByVal numEstanciaPrograma As String,
                                               ByVal intMotivoEgreso As String,
                                               ByVal intCausasAdministrativas As String,
                                               ByVal intDondeFallece As String,
                                               ByVal strEnqueHospitalfueradelared As String,
                                               ByVal strIntervencionPsicologicaPostFallecimiento As String,
                                               ByVal strExpliquelarazon As String,
                                               ByVal strobs As String,
                                               ByVal strlogin As String) As Long

            Dim lError As Long

            Me.setSQLSentence("pr_HC_CpInsertaEgresoPrograma", CommandType.StoredProcedure)
            Me.ParametersCollection.Clear()
            Me.addInputParameter("@cod_pre_sgs", SqlDbType.VarChar, strCod_pre_sgs)
            Me.addInputParameter("@cod_sucur", SqlDbType.VarChar, strCod_sucur)
            Me.addInputParameter("@tip_admision", SqlDbType.VarChar, strTip_Admision)
            Me.addInputParameter("@ano_adm", SqlDbType.Int, strAno_Adm)
            Me.addInputParameter("@num_adm", SqlDbType.Int, strNum_Adm)
            Me.addInputParameter("@tip_doc", SqlDbType.VarChar, strtip_doc)
            Me.addInputParameter("@num_doc", SqlDbType.VarChar, strnum_doc)
            Me.addInputParameter("@FechaEgreso", SqlDbType.VarChar, strFechaEgreso)
            Me.addInputParameter("@EstanciaPrograma", SqlDbType.VarChar, numEstanciaPrograma)
            Me.addInputParameter("@MotivoEgreso", SqlDbType.VarChar, intMotivoEgreso)
            Me.addInputParameter("@CausasAdministrativas", SqlDbType.VarChar, intCausasAdministrativas)
            Me.addInputParameter("@DondeFallece", SqlDbType.VarChar, intDondeFallece)
            Me.addInputParameter("@EnqueHospitalfueradelared", SqlDbType.VarChar, strEnqueHospitalfueradelared)
            Me.addInputParameter("@IntervencionPsicologicaPostFallecimiento", SqlDbType.VarChar, strIntervencionPsicologicaPostFallecimiento)
            Me.addInputParameter("@Expliquelarazon", SqlDbType.VarChar, strExpliquelarazon)
            Me.addInputParameter("@obs", SqlDbType.VarChar, strobs)
            Me.addInputParameter("@login", SqlDbType.VarChar, strlogin)
            Me.addInputParameter("@Error", SqlDbType.Int, lError)

            Me.Exec()
            lError = Me.Parameters("Error").Value

            Return lError
        End Function

        'Inicia: CCGUTIEREZ - OSI. 25/03/2020
        'Proyecto: Sophia 
        'Cambio: Se corrige el tipo de Funcion de Integer a DataTable
        'Solicitud: CA_5845702
        Public Function dtbCalcularEstanciaPrograma(ByVal strtip_doc As String, ByVal strnum_doc As String,
                                                    Optional ByVal strFechaEgreso As String = "") As DataTable
            Dim dt As New DataTable
            Dim iCalTiempo As Integer = 0
            Dim strFecPrograma As String = ""

            Me.setSQLSentence("pr_HC_CpCalculaTiempoInstancia", CommandType.StoredProcedure)
            Me.ParametersCollection.Clear()
            Me.addInputParameter("@tip_doc", SqlDbType.VarChar, strtip_doc)
            Me.addInputParameter("@num_doc", SqlDbType.VarChar, strnum_doc)
            Me.addInputParameter("@vcFechaEgreso", SqlDbType.VarChar, strFechaEgreso)

            dt = Me.execDT()

            dtbCalcularEstanciaPrograma = dt

            'Public Function intCalcularEstanciaPrograma(ByVal strtip_doc As String, ByVal strnum_doc As String, Optional ByVal strFechaEgreso As String = "") As Integer
            '    Dim dt As New DataTable
            '    Dim iCalTiempo As Integer = 0

            '    Me.setSQLSentence("pr_HC_CpCalculaTiempoInstancia", CommandType.StoredProcedure)
            '    Me.ParametersCollection.Clear()
            '    Me.addInputParameter("@tip_doc", SqlDbType.VarChar, strtip_doc)
            '    Me.addInputParameter("@num_doc", SqlDbType.VarChar, strnum_doc)
            '    Me.addInputParameter("@vcFechaEgreso", SqlDbType.VarChar, strFechaEgreso)
            '    dt = Me.execDT
            '    If dt.Rows.Count > 0 Then
            '        iCalTiempo = Convert.ToInt32(dt.Rows(0).Item(0))
            '    End If
            '    intCalcularEstanciaPrograma = iCalTiempo
            'End Function

            'Fin. CCGUTIEREZ

        End Function

    End Class
End Namespace

