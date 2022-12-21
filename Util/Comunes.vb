Imports System.ComponentModel
Imports System
Imports System.Windows.Forms
Imports System.Data
Imports HistoriaClinica.Sophia.HistoriaClinica.DAO
Imports System.Net.Mail
Imports System.Collections.Generic

Namespace Sophia.HistoriaClinica.Comunes


    ''' -----------------------------------------------------------------------------
    ''' Project	 : HistoriaClinica.Comunes
    ''' Class	 : Sophia.HistoriaClinica.Comunes.ObjetoSimple
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Clase ObjetoSimple del namespace Sophia.HistoriaClinica.Comunes que es la clase base
    ''' Esta clase se utiliza para declarar un objeto simple
    ''' y se utilizados en la aplicación Window 2005 para egresos
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' [mvargas]	08/04/2006 Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class ObjetoSimple
        Public strDato As String
        Public strValor As String
        Public Sub New()

        End Sub
        Public Property Dato() As String
            Get
                Return strDato
            End Get
            Set(ByVal value As String)
                strDato = value
            End Set
        End Property
        Public Property Valor() As String
            Get
                Return strValor
            End Get
            Set(ByVal value As String)
                strValor = value
            End Set
        End Property
        Public Sub New(ByVal strDato As String, ByVal strValor As String)
            strDato = strDato
            strValor = strValor
        End Sub

    End Class

    ''' -----------------------------------------------------------------------------
    ''' Project	 : HistoriaClinica.Comunes
    ''' Class	 : Sophia.HistoriaClinica.Comunes.ObjetoAuxiliar
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Clase ObjetoAuxiliar del namespace Sophia.HistoriaClinica.Comunes que es la clase base
    ''' Esta clase se utiliza para declarar un objeto simple auxiliar
    ''' y se utilizados en la aplicación Window 2005 para egresos
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' [mvargas]	08/04/2006 Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class ObjetoAuxiliar
        Public strDatoAux As String
        Public strValorAux As String
        Public Sub New()

        End Sub
        Public Property DatoAux() As String
            Get
                Return strDatoAux
            End Get
            Set(ByVal value As String)
                strDatoAux = value
            End Set
        End Property
        Public Property ValorAux() As String
            Get
                Return strValorAux
            End Get
            Set(ByVal value As String)
                strValorAux = value
            End Set
        End Property
        Public Sub New(ByVal strDato As String, ByVal strValor As String)
            strDatoAux = strDato
            strValorAux = strValor
        End Sub

    End Class

    Public Class FuncionesGenerales

        ''' -----------------------------------------------------------------------------
        ''' Project	 : HistoriaClinica.Comunes
        ''' Class	 : Sophia.HistoriaClinica.Comunes.FuncionesGenerales
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Clase FuncionesGenerales del namespace Sophia.HistoriaClinica.Comunes que es la clase base
        ''' Esta clase se utiliza para las funciones de fines generales 
        ''' y se utilizados en la aplicación Window 2005 para HistoriaClínica
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' [mvargas]	25/04/2006 Created
        ''' </history>

        Public Shared Function GenerarXMLxProcedimientoTA(ByVal dt As DataTable) As String
            '// Funcion que transforma un datatable e un string xml con formato simple

            Dim Xml As String = ""
            Dim i As Integer
            Dim j As Integer
            Dim Dato As String
            Dim Valor As String
            Dim strCol As String
            Dim strEnc As String = "<Raiz>"
            GenerarXMLxEntidades(dt)
            For i = 0 To dt.Rows.Count - 1
                strCol = "<Row"
                For j = 0 To dt.Columns.Count - 1
                    Dato = dt.Columns(j).ColumnName.ToString()
                    Valor = Replace(dt.Rows(i).Item(j).ToString(), Chr(34), "'")
                    strCol = strCol & " " & Dato & "=""" & Valor & """"
                Next
                strCol = strCol & "/>"
                Xml = Xml & strCol
            Next

            Xml = strEnc & Xml & "</Raiz>"
            Return Xml
        End Function

        ''' <summary>
        ''' Funcion que crea el xml de entidades para el guardado de admision homologada
        ''' </summary>
        ''' <param name="dt"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GenerarXMLxEntidades(ByVal dt As DataTable) As String
            '// Funcion que transforma un datatable e un string xml con formato simple
            Dim Xml As String = ""
            Dim i As Integer
            Dim j As Integer
            Dim Dato As String
            Dim Valor As String
            Dim strCol As String
            Dim strEnc As String = "<Raiz>"

            For i = 0 To dt.Rows.Count - 1
                strCol = "<Row>"
                For j = 0 To dt.Columns.Count - 1
                    Dato = "<" + dt.Columns(j).ColumnName.ToString() + ">"
                    Valor = Replace(dt.Rows(i).Item(j).ToString(), Chr(34), "") + "</" + Replace(dt.Columns(j).ColumnName.ToString(), Chr(34), "") + ">"
                    strCol = strCol & " " & Dato & "" & Valor & ""
                Next
                strCol = strCol & "</Row>"
                Xml = Xml & strCol
            Next

            Xml = strEnc & Xml & "</Raiz>"
            Return Xml

        End Function


        ''' -----------------------------------------------------------------------------
        ''' Project	 : HistoriaClinica.Comunes
        ''' Class	 : Sophia.HistoriaClinica.Comunes.FuncionesGenerales
        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' Clase FuncionesGenerales del namespace Sophia.HistoriaClinica.Comunes que es la clase base
        ''' Esta clase se utiliza para las funciones de fines generales 
        ''' y se utilizados en la aplicación Window 2005 para HistoriaClínica
        ''' </summary>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' [mvargas]	25/04/2006 Created
        ''' </history>
        Public Shared Function GenerarXMLxProcedimiento(ByVal dt As DataTable, Optional ByRef elementos As HashSet(Of String) = Nothing) As String
            '// Funcion que transforma un datatable e un string xml con formato simple
            Dim Xml As String = ""
            Dim i As Integer
            Dim j As Integer
            Dim Dato As String
            Dim Valor As String
            Dim strCol As String
            'Joseph Moreno (IG) Fec:2019/11/25 Particularidades
            Dim strColElement As String
            Dim strEnc As String = "<?xml version=""1.0"" encoding=""ISO-8859-1"" ?><Raiz>"

            For i = 0 To dt.Rows.Count - 1
                strCol = "<Row"
                'Joseph Moreno (IG) Fec:2019/11/25 Particularidades
                strColElement = ""
                For j = 0 To dt.Columns.Count - 1
                    Dato = dt.Columns(j).ColumnName.ToString()
                    'Joseph Moreno (IG) Fec:2019/11/25 Particularidades
                    If IsNothing(elementos) OrElse Not elementos.Contains(Dato) Then
                        Valor = Replace(dt.Rows(i).Item(j).ToString(), Chr(34), "'")
                        strCol = strCol & " " & Dato & "=""" & Valor & """"
                    Else
                        Valor = dt.Rows(i).Item(j).ToString()
                        If Valor <> "" Then
                            strColElement = strColElement & "<" & Dato & ">" & Valor & "</" & Dato & ">"
                        End If
                    End If
                Next
                'strCol = strCol & "/>"
                'Joseph Moreno (IG) Fec:2019/11/20 Particularidades
                If strColElement = "" Then
                    strCol = strCol & "/>"
                Else
                    strCol = strCol & ">" & strColElement & "</Row>"
                End If
                Xml = Xml & strCol
            Next

            Xml = strEnc & Xml & "</Raiz>"
            Return Xml

        End Function

        Public Shared Function copyArrayToDataTable(ByVal dtTabla As DataTable, ByVal array As DataRow()) As DataTable
            Dim row As DataRow

            For Each row In array
                dtTabla.ImportRow(row)
            Next

            Return dtTabla

        End Function

        Public Function SetPhoto(ByVal b As Byte()) As Bitmap
            Dim bmp As Bitmap
            Dim ms As System.IO.MemoryStream
            Dim offset As Integer

            bmp = New Bitmap(1, 1)

            If Not b Is Nothing Then

                ms = New System.IO.MemoryStream()
                offset = 0
                ms.Write(b, offset, b.Length - offset)

                Try
                    bmp = New Bitmap(ms)
                Catch ex As Exception

                End Try

                ms.Close()
            End If

            Return bmp


        End Function

        Public Shared Function NVL(ByVal Value As Object) As String
            If IsDBNull(Value) Then
                Return ""
            Else
                Return Value.ToString
            End If
        End Function

        Public Shared Function FechaServidor() As Date

            Return New DAOGeneral().traerFechaServidor()

        End Function

        Public Shared Function CalcularIndiceDeMasaCorporal(ByVal sngPeso As Single, ByVal sngTalla As Single, ByRef strDescripcionIMC As String) As Single

            Dim sngValorIMC As Single

            sngValorIMC = 0

            If sngPeso > 0 And sngTalla > 0 Then
                sngValorIMC = Math.Round(sngPeso / sngTalla ^ 2, 1)
                Select Case sngValorIMC
                    Case 0 To 18.4
                        strDescripcionIMC = "Bajo Peso"
                    Case 18.5 To 24.9
                        strDescripcionIMC = "Normal"
                    Case 25.0 To 29.9
                        strDescripcionIMC = "Sobrepeso"
                    Case 30.0 To 34.9
                        strDescripcionIMC = "Obesidad Grado I"
                    Case 35.0 To 39.9
                        strDescripcionIMC = "Obesidad Grado II"
                    Case Is >= 40.0
                        strDescripcionIMC = "Obesidad Grado III"
                End Select
            End If

            Return sngValorIMC
        End Function

        Public Shared Function DescripcionIndiceDeMasaCorporal(ByVal sngValorIMC As Single) As String
            Dim strDescripcionIMC As String

            strDescripcionIMC = ""

            If sngValorIMC = 0 Then
                Return strDescripcionIMC
            End If

            Select Case sngValorIMC
                Case 0 To 18.4
                    strDescripcionIMC = "Bajo Peso"
                Case 18.5 To 24.9
                    strDescripcionIMC = "Normal"
                Case 25.0 To 29.9
                    strDescripcionIMC = "Sobrepeso"
                Case 30.0 To 34.9
                    strDescripcionIMC = "Obesidad Grado I"
                Case 35.0 To 39.9
                    strDescripcionIMC = "Obesidad Grado II"
                Case Is >= 40.0
                    strDescripcionIMC = "Obesidad Grado III"
            End Select

            Return strDescripcionIMC

        End Function

        Public Shared Function EnumDescription(ByVal EnumConstant As [Enum]) As String
            Dim fi As Reflection.FieldInfo = EnumConstant.GetType().GetField(EnumConstant.ToString())
            Dim aattr() As DescriptionAttribute = DirectCast(fi.GetCustomAttributes(GetType(DescriptionAttribute), False), DescriptionAttribute())
            If aattr.Length > 0 Then
                Return aattr(0).Description
            Else
                Return EnumConstant.ToString()
            End If
        End Function
        Public Shared Function ReemplazarString(ByVal strValorActual As Object, ByVal strValorComparacion As Object, ByVal strValorReemplazo As Object) As Object
            If strValorActual.ToString.Trim = strValorComparacion.ToString.Trim Then
                Return strValorReemplazo
            Else
                Return strValorActual
            End If
        End Function

        Public Shared Function EscribirError(ByVal strError As String, ByVal strPila As String,
                                ByVal strUsuario As String, ByVal strEstacion As String) As Long
            Dim strDestino As String = "c:\ErrorLogHC" & DateAndTime.Year(Now) & DateAndTime.Day(Now) & ".txt"
            Dim strFecha As String = Now.ToString



            Dim sw As New System.IO.StreamWriter(strDestino, True)
            sw.WriteLine("**** Error generado : " & strFecha & "******")
            sw.WriteLine(strError & Chr(13) & strPila)
            sw.Close()


            'Try
            '    Dim MailMsg As New MailMessage(New MailAddress("Errores_HC@colsanitas.com"), New MailAddress("ggarzon@colsanitas.com"))
            '    MailMsg.Subject = "Reporte de error en Historia Clinica"
            '    MailMsg.Body = "Máq.:" & strEstacion & " " & strUsuario & vbCrLf & _
            '                   "**** Error generado:" & strFecha & "******" & vbCrLf & _
            '                   strError & vbCrLf & strPila
            '    MailMsg.Priority = MailPriority.High
            '    MailMsg.IsBodyHtml = False

            '    'Dim MsgAttach As New Attachment("c:\ErrorLogHC" & DateAndTime.Year(Now) & DateAndTime.Day(Now) & ".txt")
            '    'MailMsg.Attachments.Add(MsgAttach)

            '    Dim SmtpMail As New SmtpClient
            '    SmtpMail.Host = "mailbog.colsanitas.com"
            '    SmtpMail.Send(MailMsg)
            'Catch ex As Exception
            '    'Siga
            'End Try
            '// Enviamos el email \\



            'Dim mensaje As New MailMessage()
            'Dim cliente As New SmtpClient()
            'mensaje.From = New MailAddress("ggarzon@colsanitas.com")
            'mensaje.To.Add("ggarzon@colsanitas.com")
            'mensaje.Subject = "Error Historia Clícina - Equipo " & strEstacion
            'mensaje.Body = strUsuario & Chr(13) & strError & Chr(13) & strPila
            'cliente.Send(mensaje)

            'mensaje.BodyFormat = MailFormat.Html;
            'mensaje.Body = "<html><body><h1>Ha ocurrido un error en la aplicacion " + LogName +
            '				 ", en la url " + Request.Path + "</h1>" + Server.GetLastError().Message + "</body></html>";
            'SmtpMail.Send(mensaje);*/


        End Function
        ''' <summary>
        ''' eloaiza@intergrupo
        ''' 30-08-2019
        ''' Reordenar las columnas de un datatable
        ''' </summary>
        ''' <param name="tablaAOrdenar">Objeto datatable a ordenar</param>
        ''' <param name="OrdenNuevo">Arreglo que contiene los nombre de las columnas en su nuevo orden</param>
        ''' <returns>String</returns>
        Public Shared Function ReOrganizarColumnasEnDatatable(ByVal tablaAOrdenar As DataTable, ByVal OrdenNuevo As String()) As DataTable

            Dim columnIndex As Integer = 0
            Dim retArr As String()

            For Each columnName As String In OrdenNuevo
                columnName = columnName.Trim()
                If columnName.Contains(":") Then
                    retArr = columnName.Split(":")
                    columnName = retArr(1)
                End If
                If Not tablaAOrdenar.Columns.Contains(columnName) Then
                    tablaAOrdenar.Columns.Add(columnName)
                End If
                tablaAOrdenar.Columns(columnName).SetOrdinal(columnIndex)
                columnIndex = columnIndex + 1
            Next
            Return tablaAOrdenar
        End Function

    End Class

    Public Class CeldaNumerica
        Inherits DataGridViewColumn

        'Protected strMask As String

        Public Sub New()
            MyBase.New(New NumericCell())
        End Sub

        Public Overrides Property CellTemplate() As DataGridViewCell
            Get
                Return MyBase.CellTemplate
            End Get
            Set(ByVal value As DataGridViewCell)

                ' Ensure that the cell used for the template is a CalendarCell.
                If (value IsNot Nothing) AndAlso _
                    Not value.GetType().IsAssignableFrom(GetType(NumericCell)) _
                    Then
                    Throw New InvalidCastException("Deberá Ser NumericCell")
                End If
                MyBase.CellTemplate = value

            End Set
        End Property

        Private _intTipoControlCelda As tbTipoControl
        Public Property TipoControlCelda() As tbTipoControl
            Get
                Return _intTipoControlCelda
            End Get
            Set(ByVal Value As tbTipoControl)
                _intTipoControlCelda = Value
            End Set
        End Property

        Private _intFormatCelda As tbFormats
        Public Property FormatCelda() As tbFormats
            Get
                Return _intFormatCelda
            End Get
            Set(ByVal Value As tbFormats)
                _intFormatCelda = Value
            End Set
        End Property

        Private _intNumeroDecimals As Integer
        Public Property NumeroDecimals() As Integer
            Get
                Return _intNumeroDecimals
            End Get
            Set(ByVal Value As Integer)
                _intNumeroDecimals = Value
            End Set
        End Property

        Private _strSeparadorDecimal As Char
        Public Property SeparadorDecimal() As Char
            Get
                Return _strSeparadorDecimal
            End Get
            Set(ByVal Value As Char)
                _strSeparadorDecimal = Value
            End Set
        End Property

        Private _intLongitud As Integer
        Public Property Longitud() As Integer
            Get
                Return _intLongitud
            End Get
            Set(ByVal Value As Integer)
                _intLongitud = Value
            End Set
        End Property

        Private _intValorMinimo As Integer
        Public Property ValorMinimo() As Integer
            Get
                Return _intValorMinimo
            End Get
            Set(ByVal Value As Integer)
                _intValorMinimo = Value
            End Set
        End Property

        Private _intValorMaximo As Integer
        Public Property ValorMaximo() As Integer
            Get
                Return _intValorMaximo
            End Get
            Set(ByVal Value As Integer)
                _intValorMaximo = Value
            End Set
        End Property
    End Class

    Public Class NumericCell
        Inherits DataGridViewTextBoxCell

        Public Sub New()
            Me.Style.Format = "G"
        End Sub

        Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, _
            ByVal initialFormattedValue As Object, _
            ByVal dataGridViewCellStyle As DataGridViewCellStyle)

            ' Set the value of the editing control to the current cell value.
            MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, _
                dataGridViewCellStyle)

            Dim ctl As NumericEditingControl = _
                CType(DataGridView.EditingControl, NumericEditingControl)

            Dim colNum As CeldaNumerica

            colNum = Me.OwningColumn
            With ctl
                '.Tag = Me.OwningColumn.Index
                '.TipoControl = colNum.TipoControlCelda
                '.Format = colNum.FormatCelda
                '.Decimals = colNum.NumeroDecimals
                '.DecSeparator = colNum.SeparadorDecimal
                '.MaxLength = colNum.Longitud
                '.ValorMinimo = colNum.ValorMinimo
                '.ValorMaximo = colNum.ValorMaximo
                .TipoControl = tbTipoControl.Celda
                .Format = tbFormats.NúmericoEnteroSinSigno
                If Me.OwningColumn.DataPropertyName <> "codcorrecto" Then
                    Select Case Me.OwningColumn.Index
                        Case 3, 7, 11, 15, 19, 23
                            .MaxLength = 2
                            .ValorMinimo = 1
                            .ValorMaximo = 12
                        Case 4, 8, 12, 16, 20, 24
                            .MaxLength = 4
                            .ValorMinimo = 1783
                            .ValorMaximo = 9999
                    End Select
                Else
                    .MaxLength = 2
                    .ValorMinimo = 1
                    .ValorMaximo = 18
                    .Multiline = False
                End If
                If Not Me.Value Is Nothing Then
                    If Not IsDBNull(Me.Value) Then
                        .Text = Me.Value
                    End If
                End If
            End With

        End Sub

        Public Overrides ReadOnly Property EditType() As Type
            Get
                ' Return the type of the editing contol that CalendarCell uses.
                Return GetType(NumericEditingControl)
            End Get
        End Property

        Public Overrides ReadOnly Property ValueType() As Type
            Get
                ' Return the type of the value that CalendarCell contains.
                Return GetType(Integer)
            End Get
        End Property

        Public Overrides ReadOnly Property DefaultNewRowValue() As Object
            Get
                ' Use the current date and time as the default value.
                Return ""
            End Get
        End Property


    End Class

    Class NumericEditingControl
        Inherits TextBoxConFormato
        Implements IDataGridViewEditingControl

        Private dataGridViewControl As DataGridView
        Private valueIsChanged As Boolean = False
        Private rowIndexNum As Integer

        Public Sub New()
            'Me.Mask =
        End Sub

        Public Property EditingControlFormattedValue() As Object _
            Implements IDataGridViewEditingControl.EditingControlFormattedValue

            Get
                Return Me.Text
            End Get

            Set(ByVal value As Object)
                If TypeOf value Is String Then
                    Me.Text = value
                End If
            End Set

        End Property

        Public Function GetEditingControlFormattedValue(ByVal context _
            As DataGridViewDataErrorContexts) As Object _
            Implements IDataGridViewEditingControl.GetEditingControlFormattedValue

            Return Me.Text

        End Function

        Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As _
            DataGridViewCellStyle) _
            Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl

            Me.Font = dataGridViewCellStyle.Font
            'Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
            'Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor

        End Sub

        Public Property EditingControlRowIndex() As Integer _
            Implements IDataGridViewEditingControl.EditingControlRowIndex

            Get
                Return rowIndexNum
            End Get
            Set(ByVal value As Integer)
                rowIndexNum = value
            End Set

        End Property

        Public Function EditingControlWantsInputKey(ByVal key As Keys, _
            ByVal dataGridViewWantsInputKey As Boolean) As Boolean _
            Implements IDataGridViewEditingControl.EditingControlWantsInputKey

            Select Case key And Keys.KeyCode
                Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
                    Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp

                    Return True

            End Select
            Return dataGridViewWantsInputKey

        End Function

        Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) _
            Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

            ' Ninguna Preparación para el Control

        End Sub

        Public ReadOnly Property RepositionEditingControlOnValueChange() _
            As Boolean Implements _
            IDataGridViewEditingControl.RepositionEditingControlOnValueChange

            Get
                Return False
            End Get

        End Property

        Public Property EditingControlDataGridView() As DataGridView _
            Implements IDataGridViewEditingControl.EditingControlDataGridView

            Get
                Return dataGridViewControl
            End Get
            Set(ByVal value As DataGridView)
                dataGridViewControl = value
            End Set

        End Property

        Public Property EditingControlValueChanged() As Boolean _
            Implements IDataGridViewEditingControl.EditingControlValueChanged

            Get
                Return valueIsChanged
            End Get
            Set(ByVal value As Boolean)
                valueIsChanged = value
            End Set

        End Property

        Public ReadOnly Property EditingControlCursor() As Cursor _
            Implements IDataGridViewEditingControl.EditingPanelCursor

            Get
                Return MyBase.Cursor
            End Get

        End Property

        Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
            valueIsChanged = True
            Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)

            MyBase.OnTextChanged(e)
        End Sub
    End Class

End Namespace
