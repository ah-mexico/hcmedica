
Imports System.IO


#Region "Enumeración de formatos"

'Listado de todos los formatos que es capaz de gestionar la
'caja de texto
Public Enum tbFormats
    'Todos los caracteres y números con espacios. Valor por
    'defecto de la propiedad Format
    AlfaNúmericoConEspacios

    'Todos los caracteres y números sin espacios
    AlfaNúmericoSinEspacios

    'Sólo las letras con espacios
    AlfabéticoConEspacios

    'Sólo las letras sin espacios
    AlfabéticoSinEspacios

    'Sólo números enteros sin signo
    NúmericoEnteroSinSigno

    'Sólo números enteros con signo
    NúmericoEnteroConSigno

    'Sólo números con coma decimal flotante sin signo
    NúmericoPuntoFlotanteSinSigno

    'Sólo números con coma decimal flotante con signo
    NúmericoPuntoFlotanteConSigno

    'Sólo números con coma decimal fija sin signo. El número
    'de decimales se debe especificar en la propiedad Decimals
    NúmericoDecimalFijoSinSigno


    'Sólo números con coma decimal fija con signo. El número
    'de decimales se debe especificar en la propiedad Decimals
    NúmericoDecimalFijoConSigno

    'Sólo números en formato hexadecimal
    Hexadecimal


    'Sólo números en formato octal
    Octal

    'Sólo números en formato binario
    Binario

    'Fecha
    'Fecha

    'Definido por usuario
    DefinidoPorUsuario
End Enum

'Public Enum tbFormatosFecha
'    DiaMesAño
'    AñoMesDia
'    MesDiaAño
'End Enum

Public Enum tbPosicionLista
    Bottom = 0
    Top = 1
End Enum

Public Enum tbTipoControl
    Normal
    CodigoBusqueda
    ListaAutoComplete
    BuscadorCodigo
    Celda
End Enum


#End Region

Public Class TextBoxConFormato
    Inherits System.Windows.Forms.TextBox
    Event ValidarTexto(ByVal sender As Object)
    Private cmdButton As New Button


#Region "Campos protected y private"

    'Almacena el valor de la propiedad Format
    Protected mFormat As tbFormats = tbFormats.AlfaNúmericoSinEspacios

    'Mete las teclas TAB, RETORNO e INTRO para aceptar siempre
    'estas teclas
    Protected ControlKeys As String = Chr(8) & Chr(9) & Chr(13)

    'Almacena el valor de la propiedad UserValues
    Protected mUserValues As String

    'Almacena el valor de la propiedad DecSeparator
    Protected mDecSeparator As Char = "."

    'Almacena el valor de la propiedad Decimals
    Protected mDecimals As Byte = 2

    'Almacena los dígitos válidos para algunos formatos
    Private okValues As String

    'Protected mFormatFecha As tbFormatosFecha = tbFormatosFecha.DiaMesAño
    Protected mTipoControl As tbTipoControl = tbTipoControl.Normal

    Protected mDataSource As DataTable
    Protected mNombreCampoDatos As String
    Protected mNombreCampoBusqueda As String
    Protected mNombreCampoBuscado As String
    Protected mblnClicDerecho As Boolean = False
    Protected mctlTextoEnlace As TextBoxConFormato
    Protected mValorMinimo As Long = 0.0
    Protected mValorMaximo As Long = 0.0
    Protected mblnAgregado As Boolean = False
    Protected mstrCeros As String = ""
    Protected mValidoEnter As Boolean = False
    Protected mBorrarPreCero As Boolean = False
    Protected mBorrarSepDec As Boolean = False
    Protected mObligatorio As Boolean = False
    Protected mComboEnlace As ComboBusqueda
    Protected mDatoRelacionado As String
    Protected mDescripcionCodigo As String
    Protected mPermitirCero As Boolean
    Protected lstLista As ListBox
    Private _BotonBusqueda As Button
    Dim lSignal As Boolean = False

    Friend Property _keyReceived As String
    Public Property keyReceived() As Char
        Get
            Return _keyReceived
        End Get
        Friend Set(ByVal value As Char)
            _keyReceived = value
        End Set
    End Property


#End Region

#Region "Constructor y método protected Dispose"
    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
        mFormat = tbFormats.AlfaNúmericoConEspacios

    End Sub

    'UserControl1 reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
#End Region

#Region " Código generado por el Diseñador de Windows Forms "
    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
    End Sub

#End Region

#Region "Métodos privados de apoyo"
    'Valida el mensaje WM_CHAR recibido desde WndProc.
    'Devuelve true si es válido y false si no lo es
    Private Function validar(ByRef m As Message) As Boolean

        Dim values As String = ""
        Dim blnNumerico As Boolean
        Dim strValor As String
        Dim strValoresNoPreCero As String = "0123456789"

        Select Case mFormat
            Case tbFormats.AlfaNúmericoConEspacios
                Return True

            Case tbFormats.AlfaNúmericoSinEspacios
                If m.WParam.ToInt32 <> Asc(" ") Then
                    Return True
                Else
                    Return False
                End If

            Case tbFormats.NúmericoEnteroConSigno
                values = "0123456789" & Me.ControlKeys

                Me.ComprobarSigno(values)
                blnNumerico = True

            Case tbFormats.NúmericoPuntoFlotanteSinSigno
                values = "0123456789" & Me.ControlKeys

                'Si es una coma o un punto se convierte al
                'separador decimal establecido en la propiedad
                'DecSeparator
                If m.WParam.ToInt32 = CInt(Asc(".")) OrElse
                   m.WParam.ToInt32 = CInt(Asc(",")) Then
                    m.WParam = New IntPtr(CInt(Asc(Me.DecSeparator)))
                End If

                Me.ComprobarComa(values)
                blnNumerico = True

            Case tbFormats.NúmericoPuntoFlotanteConSigno
                values = "0123456789" & Me.ControlKeys

                If m.WParam.ToInt32 = CInt(Asc(".")) OrElse
                   m.WParam.ToInt32 = CInt(Asc(",")) Then
                    m.WParam = New IntPtr(CInt(Asc(Me.DecSeparator)))
                End If

                Me.ComprobarComa(values)
                Me.ComprobarSigno(values)
                blnNumerico = True

            Case tbFormats.NúmericoDecimalFijoSinSigno
                values = Me.ControlKeys

                If m.WParam.ToInt32 = CInt(Asc(".")) OrElse
                   m.WParam.ToInt32 = CInt(Asc(",")) Then
                    m.WParam = New IntPtr(CInt(Asc(Me.DecSeparator)))
                End If

                Me.ComprobarPosicion(values)
                blnNumerico = True

            Case tbFormats.NúmericoDecimalFijoConSigno
                values = Me.ControlKeys

                If m.WParam.ToInt32 = CInt(Asc(".")) OrElse
                   m.WParam.ToInt32 = CInt(Asc(",")) Then
                    m.WParam = New IntPtr(CInt(Asc(Me.DecSeparator)))
                End If

                Me.ComprobarSigno(values)
                Me.ComprobarPosicion(values)
                blnNumerico = True

            Case tbFormats.NúmericoEnteroSinSigno
                values = okValues
                blnNumerico = True

            Case Else
                values = okValues

        End Select

        If values.IndexOf(Chr(m.WParam.ToInt32())) >= 0 Then
            If ControlKeys.IndexOf(Chr(m.WParam.ToInt32())) >= 0 Then
                Return True
            End If
            If blnNumerico = True Then
                If mValorMinimo = 0 And mValorMaximo = 0 Then
                    Return True
                End If
                If MyBase.Text.Trim.Length = 0 Then
                    strValor = ""
                Else
                    strValor = Replace(MyBase.Text, Mid(MyBase.Text, MyBase.SelectionStart + 1, MyBase.SelectionLength), "")
                    'MyBase.Text = strValor
                End If
                If Val(strValor.Trim & Chr(m.WParam.ToInt32())) < mValorMinimo And
                   Val(strValor.Trim & Chr(m.WParam.ToInt32())) > 0 Then
                    mstrCeros = ""
                    'Do While Val(strValor.Trim & Chr(m.WParam.ToInt32()) & mstrCeros) <= mValorMaximo And _
                    '         Val(strValor.Trim & Chr(m.WParam.ToInt32()) & mstrCeros) > 0
                    '    If Val(strValor.Trim & Chr(m.WParam.ToInt32()) & mstrCeros & "0") >= mValorMinimo Then
                    '        mstrCeros &= "0"
                    '        Exit Do
                    '    Else
                    '        mstrCeros &= "0"
                    '    End If
                    '    'If Val(strValor.Trim & Chr(m.WParam.ToInt32()) & mstrCeros & "0") <= mValorMaximo Then
                    '    '    mstrCeros &= "0"
                    '    'Else
                    '    '    Exit Do
                    '    'End If
                    'Loop
                    Do While Val(strValor.Trim & Chr(m.WParam.ToInt32()) & mstrCeros) < mValorMinimo And
                               Val(strValor.Trim & Chr(m.WParam.ToInt32()) & mstrCeros) > 0
                        If Val(strValor.Trim & Chr(m.WParam.ToInt32()) & mstrCeros & "0") <= mValorMaximo Then
                            mstrCeros &= "0"
                        Else
                            Exit Do
                        End If
                    Loop

                    If Val(strValor.Trim & Chr(m.WParam.ToInt32()) & mstrCeros) <= mValorMinimo Then
                        mstrCeros = mValorMinimo.ToString.Substring((mValorMinimo.ToString.Length - mstrCeros.Length))
                    End If
                    If Val(strValor.Trim & Chr(m.WParam.ToInt32()) & mstrCeros) >= mValorMinimo And
                       Val(strValor.Trim & Chr(m.WParam.ToInt32()) & mstrCeros) <= mValorMaximo Then
                        mblnAgregado = True
                        Return True
                    Else
                        Return False
                    End If
                Else
                    Select Case strValor
                        Case "-"
                            If Chr(m.WParam.ToInt32()) = "0" Then
                                mBorrarSepDec = True
                            End If
                        Case "0"
                            If strValoresNoPreCero.IndexOf(Chr(m.WParam.ToInt32())) >= 0 Then
                                mBorrarPreCero = True
                            End If

                    End Select
                    If Val(strValor.Trim & Chr(m.WParam.ToInt32())) < mValorMinimo Or
                       Val(strValor.Trim & Chr(m.WParam.ToInt32())) > mValorMaximo Then
                        Return False
                    End If
                End If
            End If
            Return True
        Else
            Return False
        End If
    End Function

    'Comprueba si el formato es de algún tipo de número decimal
    'Retorna true si es decimal, false si no lo es
    Private Function EsFormatoDecimal() As Boolean
        Return (CInt(mFormat) >= 6 AndAlso CInt(mFormat) <= 9)
    End Function

    'Comprueba si se puede poner la coma en un formato decimal
    Private Sub ComprobarComa(ByRef values As String)
        If MyBase.Text.IndexOf(mDecSeparator) >= 0 Then
            If MyBase.SelectedText.IndexOf(mDecSeparator) >= 0 Then
                values &= mDecSeparator
            End If
        Else
            values &= mDecSeparator
        End If
    End Sub

    'Comprueba si se puede poner el signo con un formato Signed
    'según la posición del cursor
    Private Sub ComprobarSigno(ByRef values As String)

        If MyBase.Text.IndexOf("-") >= 0 Then
            If MyBase.SelectedText.IndexOf("-") >= 0 Then
                values &= "-"
            End If
        Else
            If MyBase.SelectionStart = 0 Then
                values &= "-"
            End If
        End If

    End Sub


    'Comprueba si se pueden seguir escribiendo números
    'en un formato FixedPointNumber según la posición del cursor
    Private Sub ComprobarPosicion(ByRef values As String)

        If MyBase.Text.Length - (MyBase.SelectionStart + MyBase.SelectionLength) <= Me.mDecimals Then
            Me.ComprobarComa(values)
        End If

        Dim pos As Integer = MyBase.Text.IndexOf(Me.mDecSeparator)

        If pos >= 0 Then
            If MyBase.SelectionStart > pos Then

                If MyBase.SelectionLength > 0 OrElse MyBase.Text.Length - pos <= Me.mDecimals Then
                    values &= "0123456789"
                End If
            Else
                values &= "0123456789"
            End If
        Else
            values &= "0123456789"
        End If

    End Sub

    'Actualiza el separador decimal
    Private Sub ActualizarSeparador()
        Dim s() As Char = MyBase.Text.ToCharArray()
        Dim i As Integer

        MyBase.Text = ""

        For i = 0 To s.Length - 1
            If s(i) = "." OrElse s(i) = "," Then
                s(i) = Me.mDecSeparator
            End If

            MyBase.Text &= s(i).ToString()
        Next i

    End Sub

    'Cambia a base decimal un número escrito en cualquier base
    Private Function BaseADecimal(ByVal base As Integer) As Long
        Dim s() As Char = Me.Text.ToUpper().ToCharArray()
        Dim i As Integer
        Dim res As Long = 0
        Dim digito As Double

        For i = s.Length - 1 To 0 Step -1
            Try
                'Si el dígito es un número lo obtenemos
                digito = Double.Parse(s(i).ToString())
            Catch
                'Si el dígito es una letra, calculamos su valor
                digito = CDbl(Asc(s(i)) - Asc("A") + 10)
            End Try

            res += CLng(Math.Pow(CDbl(base), CDbl(s.Length - 1 - i)) * digito)

        Next i

        Return res

    End Function

    'Cambia a cualquier base un número escrito en base decimal
    Private Function DecimalABase(ByVal num As Long, ByVal base As Integer) As String
        Dim resto As Integer
        Dim res As String = ""

        Do
            resto = CInt(num Mod CLng(base))

            If resto < 10 Then
                'Si es menor que 10 lo ponemos en la cadena
                res = resto.ToString() & res
            Else
                'Si es mayor o igual 10 calculamos la letra
                res = Chr(Asc("A") - 10 + resto).ToString() & res
            End If

            num \= base
        Loop Until num = 0

        Return res
    End Function

    Private Function BuscarDescripcion(ByVal strValue As String) As String
        Dim EncontrarFila As DataRow = Nothing
        Dim strRespuesta As String
        Dim dtTable As DataTable

        strRespuesta = ""

        If mctlTextoEnlace.OrigenDeDatos Is Nothing Then
            Return strRespuesta
            Exit Function
        End If

        dtTable = mctlTextoEnlace.OrigenDeDatos

        dtTable.PrimaryKey = New DataColumn() {dtTable.Columns(Me.mNombreCampoBusqueda)}

        If dtTable.Rows.Count > 0 Then
            EncontrarFila = dtTable.Rows.Find(MyBase.Text)
        End If


        If Not EncontrarFila Is Nothing Then
            strRespuesta = EncontrarFila(Me.mNombreCampoBuscado)
        End If

        Return strRespuesta
    End Function

    Private Function BuscarCodigo(ByVal strValue As String) As String
        Dim EncontrarFila As DataRow()
        Dim strRespuesta As String

        strRespuesta = ""

        If mDataSource Is Nothing Then
            Return strRespuesta
            Exit Function
        End If

        EncontrarFila = mDataSource.Select(mctlTextoEnlace.mNombreCampoBuscado & "='" & MyBase.Text.Trim & "'")

        'mDataSource.PrimaryKey = New DataColumn() {mDataSource.Columns(mctlTextoEnlace.mNombreCampoBuscado)}

        If EncontrarFila.Length > 0 Then
            strRespuesta = EncontrarFila(0)(mctlTextoEnlace.mNombreCampoBusqueda).ToString
        End If

        'EncontrarFila = mDataSource.Rows.Find(MyBase.Text)

        'If Not EncontrarFila Is Nothing Then
        'strRespuesta = EncontrarFila(mctlTextoEnlace.mNombreCampoBusqueda)
        'End If

        Return strRespuesta

    End Function

    Private Function BuscarCodigoCombo(ByVal strValue As String) As String
        Dim EncontrarFila() As DataRow
        Dim strRespuesta As String

        strRespuesta = ""

        If Me.mComboEnlace.OrigenDeDatos Is Nothing Then ' And Not lSignal Then
            strRespuesta = Me.mComboEnlace.BuscarCodigo(strValue)
            RaiseEvent ValidarTexto(Me)
            Return strRespuesta
        End If

        If Not IsNothing(Me.mComboEnlace.OrigenDeDatos) And Me.mComboEnlace.OrigenDeDatos.Rows.Count > 0 Then

            EncontrarFila = mComboEnlace.OrigenDeDatos.Select(mComboEnlace.CampoEnlazado & " = '" & MyBase.Text & "'")
            'mComboEnlace.OrigenDeDatos.PrimaryKey = New DataColumn() {mComboEnlace.OrigenDeDatos.Columns(mComboEnlace.CampoEnlazado)
            'EncontrarFila = mComboEnlace.OrigenDeDatos.Rows.Find(MyBase.Text)
            'If EncontrarFila.Length > 0 Then
            ' strRespuesta = EncontrarFila(0).Item(mComboEnlace.CampoMostrar)
            ' mComboEnlace.lanzaEventoActualizarDatosElegidos(EncontrarFila(0))
            'Else
            '   strRespuesta = Me.mComboEnlace.BuscarCodigo(strValue)
            'End If
            strRespuesta = Me.mComboEnlace.BuscarCodigo(strValue)
        Else
            strRespuesta = ""
        End If

        'If Not EncontrarFila Is Nothing Then
        '    strRespuesta = EncontrarFila(mComboEnlace.CampoMostrar)
        'Else
        '    strRespuesta = Me.mComboEnlace.BuscarCodigo(strValue)
        'End If
        Return strRespuesta

    End Function

    Private Sub ClickLista(ByVal sender As Object, ByVal e As System.EventArgs)

        If lstLista Is Nothing Then
            SiguienteControl(Me.Parent.Controls(sender.tag)).Focus()
            Exit Sub
        End If

        With Me
            .Text = lstLista.SelectedValue
            .SelectionStart = 0
            .SelectionLength = .Text.Length

            SiguienteControl(Me.Parent.Controls(sender.tag)).Focus()
            If Not Me.ControlComboEnlace Is Nothing Then
                Me.ControlComboEnlace.lanzaEventoActualizarDatosElegidos(Nothing)
            End If
            PerderFoco()
            Me.Parent.Controls.Remove(lstLista)
            lstLista = Nothing

        End With

    End Sub

    Private Sub KeyPressLista(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Asc(e.KeyChar) = 13 Then
            If lstLista Is Nothing Then
                Exit Sub
            End If

            With Me
                .Text = lstLista.SelectedValue
                .SelectionStart = 0
                .SelectionLength = .Text.Length
                .Focus()
            End With
            Me.Parent.Controls.Remove(lstLista)
            lstLista = Nothing
        ElseIf Asc(e.KeyChar) = 27 Then
            Me.SelectionStart = 0
            Me.SelectionLength = Me.Text.Length
            Me.Focus()

            Me.Parent.Controls.Remove(lstLista)
            lstLista = Nothing
        End If
        If Not Me.ControlComboEnlace Is Nothing Then
            Me.ControlComboEnlace.lanzaEventoActualizarDatosElegidos(Nothing)
        End If


    End Sub

    Private Sub ListaSinFoco(ByVal sender As Object, ByVal e As System.EventArgs)
        'Me.SelectionStart = 0
        'Me.SelectionLength = Me.Text.Length
        Me.Focus()
        Me.Parent.Controls.Remove(lstLista)
        lstLista = Nothing
    End Sub

#End Region

#Region "Propiedad Text sobreescrita"
    'Devuelve o establece el texto del control
    Public Overrides Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal Value As String)
            'En lugar de poner la cadena de un sólo golpe
            'se valida dígito a dígito según el formato
            'establecido
            '*******
            Const WM_CHAR As Integer = 258
            If Value Is Nothing Then
                Value = ""
            End If
            Dim s() As Char = Value.ToCharArray()
            Dim c As Char
            Dim wParam As New IntPtr
            Dim lParam As New IntPtr(0)
            Dim m As Message

            MyBase.Text = ""

            For Each c In s
                Try
                    wParam = New IntPtr(Asc(c))
                    m = Message.Create(Me.Handle, WM_CHAR, wParam, lParam)

                    If Me.validar(m) Then
                        MyBase.Text &= c.ToString()
                        'If mFormat = tbFormats.Fecha Then
                        '    If MyBase.Text.Length - (MyBase.SelectionStart + MyBase.SelectionLength) = 2 Or _
                        '       MyBase.Text.Length - (MyBase.SelectionStart + MyBase.SelectionLength) = 5 Then
                        '        MyBase.Text &= "/"
                        '        MyBase.SelectionStart = MyBase.Text.Length
                        '    End If
                        'End If
                    End If

                Catch ex As Exception
                    MessageBox.Show("Error")
                End Try
            Next
            '*************
        End Set
    End Property

    Protected Overrides Sub OnKeyUp(ByVal e As System.Windows.Forms.KeyEventArgs)

        Dim strDescripcion As String
        Dim strCodigo As String
        Dim ctlControl As Control
        lSignal = False

        If e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Back Then
            If Val(MyBase.Text) < Me.mValorMinimo Then
                MyBase.Text = ""
            End If
            RaiseEvent ValidarTexto(Me)
            Exit Sub
        End If

        If e.KeyCode = Keys.Right Then
            If Me.AutoCompleteCustomSource.Count <= 0 Then
                RaiseEvent ValidarTexto(Me)
                Exit Sub
            End If
            lstLista = New ListBox
            Me.Parent.Controls.Add(lstLista)
            With lstLista
                If _tbPosicionListaDesplegable = tbPosicionLista.Bottom Then
                    .Location = New System.Drawing.Point(Me.Location.X, Me.Location.Y + Me.Height)
                Else
                    .Location = New System.Drawing.Point(Me.Location.X, Me.Location.Y - lstLista.Height)
                End If
                .Width = Me.Width
                .DataSource = Me.AutoCompleteCustomSource
                .SelectedIndex = IIf(Me.Text.Trim.Length > 0, .FindString(Me.Text, 0), 0)
                .Tag = Me.Name
                .BorderStyle = Windows.Forms.BorderStyle.FixedSingle
                .BringToFront()
                AddHandler .Click, AddressOf ClickLista
                AddHandler .KeyPress, AddressOf KeyPressLista
                'AddHandler .LostFocus, AddressOf ListaSinFoco
                .Focus()
            End With
        End If

        If e.KeyCode = Keys.Enter Then
            mValidoEnter = True
            e.Handled = False
            lSignal = True
            Me.PerderFoco()
            'Me.SelectAll()
            My.Computer.Keyboard.SendKeys("{TAB}")
            RaiseEvent ValidarTexto(Me)
            Exit Sub


            'If Me.Format = tbFormats.NúmericoDecimalFijoConSigno Or Me.Format = tbFormats.NúmericoDecimalFijoSinSigno Or _
            '   Me.Format = tbFormats.NúmericoEnteroConSigno Or Me.Format = tbFormats.NúmericoEnteroSinSigno Or _
            '   Me.Format = tbFormats.NúmericoPuntoFlotanteConSigno Or Me.Format = tbFormats.NúmericoPuntoFlotanteSinSigno Then
            '    If Not (mValorMinimo <= Val(MyBase.Text) And Val(MyBase.Text) < mValorMaximo) Then
            '        e.Handled = False
            '        MyBase.OnKeyUp(e)
            '        Exit Sub
            '    End If
            'End If

            If MyBase.Text.Trim.Length = 0 Then
                Select Case mTipoControl
                    Case tbTipoControl.BuscadorCodigo, tbTipoControl.CodigoBusqueda, tbTipoControl.Normal, tbTipoControl.ListaAutoComplete
                        'Me.Parent.GetNextControl(Me, True).Focus()
                        SiguienteControl(Me).Focus()
                        RaiseEvent ValidarTexto(Me)
                        Exit Sub
                End Select
            End If

            If Me.mTipoControl = tbTipoControl.CodigoBusqueda Then
                strDescripcion = BuscarDescripcion(MyBase.Text.Trim)
                Me.ControlTextoEnlace.Text = strDescripcion
                If strDescripcion.Trim.Length <= 0 Then
                    Me.SelectionStart = 0
                    Me.SelectionLength = MyBase.Text.Length
                    RaiseEvent ValidarTexto(Me)
                    Exit Sub
                End If
                ctlControl = Me.Parent.GetNextControl(Me, True)
                'Me.Parent.GetNextControl(ctlControl, True).Focus()
                SiguienteControl(ctlControl).Focus()
            End If

            If Me.mTipoControl = tbTipoControl.ListaAutoComplete Then
                If MyBase.Text.Trim.Length = 0 Then
                    RaiseEvent ValidarTexto(Me)
                    Exit Sub
                End If
                strCodigo = BuscarCodigo(MyBase.Text.Trim)
                Me.ControlTextoEnlace.Text = strCodigo
                If strCodigo.Trim.Length <= 0 Then
                    Me.SelectionStart = 0
                    Me.SelectionLength = MyBase.Text.Length
                    RaiseEvent ValidarTexto(Me)
                    Exit Sub
                End If
                'Me.Parent.GetNextControl(Me, True).Focus()
                SiguienteControl(Me).Focus()
            End If


            If Me.mTipoControl = tbTipoControl.BuscadorCodigo Then
                If MyBase.Text.Trim.Length > 0 Then
                    Me.ControlComboEnlace.CategoriaDatos = CategoriaDatos.OrdenMedicamentosCodigo
                    Me.ControlComboEnlace.BotonBusqueda.Focus()
                    RaiseEvent ValidarTexto(Me)
                    Exit Sub
                Else
                    'Me.Parent.GetNextControl(Me, True).Focus()
                    SiguienteControl(Me).Focus()
                    RaiseEvent ValidarTexto(Me)
                    Exit Sub
                End If
            End If

            If Not Me.mComboEnlace Is Nothing Then
                strDescripcion = BuscarCodigoCombo(MyBase.Text.Trim)
                If strDescripcion.Trim.Length <= 0 Then
                    Me.SelectionStart = 0
                    Me.SelectionLength = MyBase.Text.Length
                    RaiseEvent ValidarTexto(Me)
                    Exit Sub
                Else
                    'Me.AutoCompleteCustomSource.Add(MyBase.Text)
                    Me.mComboEnlace.Text = strDescripcion
                    ctlControl = Me.Parent.GetNextControl(Me, True)
                    'Me.Parent.GetNextControl(ctlControl, True).Focus()
                    SiguienteControl(ctlControl).Focus()
                End If
            End If

            If Me.mTipoControl = tbTipoControl.Celda Then
                e.Handled = True
                My.Computer.Keyboard.SendKeys("{TAB}")
                RaiseEvent ValidarTexto(Me)
                Exit Sub
            End If

            If Me.mTipoControl = tbTipoControl.Normal And (Me.mComboEnlace Is Nothing And Me.mctlTextoEnlace Is Nothing) Then
                'Me.Parent.GetNextControl(Me, True).Focus()
                SiguienteControl(Me).Focus()
            End If

            If MyBase.Multiline AndAlso MyBase.AcceptsReturn Then
                e.Handled = False
                MyBase.OnKeyUp(e)
                RaiseEvent ValidarTexto(Me)
                Exit Sub
            End If
            e.Handled = True
        End If
        RaiseEvent ValidarTexto(Me)

    End Sub

    Public Sub CargarButton()

        If Not Me.Parent Is Nothing Then
            Me.Parent.Controls.Add(cmdButton)
        End If
        With cmdButton
            .Width = 22
            .Height = 22
            Me.Width = Me.Width - (.Width + 1)
            .Location = New Point(Me.Location.X + Me.Width + 1, Me.Location.Y)
            .FlatStyle = Windows.Forms.FlatStyle.Flat
            .Image = My.Resources.flecha_combo
            .FlatAppearance.BorderSize = 0
            .BackColor = Color.White
            AddHandler .Click, AddressOf ClickEvent
            .Cursor = Cursors.Hand
        End With

        _BotonBusqueda = (cmdButton)

    End Sub

    Private Sub ClickEvent(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.AutoCompleteCustomSource.Count <= 0 Then
            RaiseEvent ValidarTexto(Me)
            Exit Sub
        End If
        lstLista = New ListBox
        Me.Parent.Controls.Add(lstLista)
        With lstLista
            If _tbPosicionListaDesplegable = tbPosicionLista.Bottom Then
                .Location = New System.Drawing.Point(Me.Location.X, Me.Location.Y + Me.Height)
            Else
                .Location = New System.Drawing.Point(Me.Location.X, Me.Location.Y - lstLista.Height)
            End If
            .Width = Me.Width
            .DataSource = Me.AutoCompleteCustomSource
            .SelectedIndex = IIf(Me.Text.Trim.Length > 0, .FindString(Me.Text, 0), 0)
            .Tag = Me.Name
            .BorderStyle = Windows.Forms.BorderStyle.FixedSingle
            .BringToFront()
            AddHandler .Click, AddressOf ClickLista
            AddHandler .KeyPress, AddressOf KeyPressLista
            AddHandler .LostFocus, AddressOf ListaSinFoco
            .Focus()
        End With
        RaiseEvent ValidarTexto(Me)

    End Sub

    Protected Overrides Sub OnLostFocus(ByVal e As System.EventArgs)
        PerderFoco()
    End Sub

    Public Sub PerderFoco()
        Dim strdescripcion As String
        Dim strCodigo As String

        If MyBase.Text.Trim.Length = 0 Then
            Exit Sub
        End If
        If mValidoEnter = True Then
            mValidoEnter = False
            Exit Sub
        End If
        If Me.mTipoControl = tbTipoControl.CodigoBusqueda Then
            strdescripcion = BuscarDescripcion(MyBase.Text.Trim)
            Me.ControlTextoEnlace.Text = strdescripcion
        End If
        If Me.mTipoControl = tbTipoControl.ListaAutoComplete Then
            strCodigo = BuscarCodigo(MyBase.Text.Trim)
            Me.ControlTextoEnlace.Text = strCodigo
        End If
        If Not mComboEnlace Is Nothing Then
            strdescripcion = BuscarCodigoCombo(Me.Text.Trim)
            Me.mComboEnlace.Text = strdescripcion
        End If

    End Sub
#End Region

#Region "Método WndProc sobreescrito"
    'Procesa los mensajes recibidos del sistema operativo   
    Protected Overrides Sub WndProc(ByRef m As Message)
        Const WM_CHAR As Integer = 258

        If m.Msg = WM_CHAR Then

            If Me.validar(m) Then
                MyBase.WndProc(m)
                'If mFormat = tbFormats.Fecha Then
                '    If MyBase.Text.Length - MyBase.SelectionLength = 2 Or _
                '       MyBase.Text.Length - MyBase.SelectionLength = 5 Then
                '        MyBase.Text &= "/"
                '        MyBase.SelectionStart = MyBase.Text.Length
                '    End If

                'End If
                If mblnAgregado = True Then
                    MyBase.Text = Replace(MyBase.Text, Mid(MyBase.Text, MyBase.SelectionStart + 1, MyBase.SelectionLength), "")
                    If Val(MyBase.Text & mstrCeros) <= mValorMaximo Then
                        MyBase.Text &= mstrCeros
                        MyBase.SelectionStart = 1
                        MyBase.SelectionStart = MyBase.Text.Trim.Length - mstrCeros.Trim.Length
                        MyBase.SelectionLength = mstrCeros.Trim.Length
                    End If
                    mblnAgregado = False
                End If
                If mBorrarPreCero = True Then
                    MyBase.Text = Replace(MyBase.Text, "0", "", 1, 1)
                    MyBase.SelectionStart = MyBase.Text.Trim.Length
                    mBorrarPreCero = False
                End If
                If mBorrarSepDec = True Then
                    MyBase.Text = Replace(MyBase.Text, "-", "", 1, 1)
                    MyBase.SelectionStart = MyBase.Text.Trim.Length
                    mBorrarSepDec = False
                End If

            End If

        Else
            MyBase.WndProc(m)
        End If

    End Sub

#End Region

#Region "Propiedades públicas nuevas"
    'Devuelve o establece el número de decimales para un formato
    'FixedPointNumber
    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("Devuelve o establece el número de decimales para un formato Númerico con Decimales")>
    Public Property Decimals() As Byte
        Get
            Return Me.mDecimals
        End Get
        Set(ByVal Value As Byte)
            Me.mDecimals = Value
        End Set
    End Property

    'Es el origen de datos asociado al control, el cual da la información 
    'de autocomplete y es donde se hacen las búsquedas por código.
    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("Es el origen de datos asociado al control, el cual da la información de autocomplete y es donde se hacen las búsquedas por código.")>
    Public Property OrigenDeDatos() As DataTable
        Get
            If mTipoControl = tbTipoControl.ListaAutoComplete Then
                OrigenDeDatos = mDataSource
            Else
                OrigenDeDatos = Nothing
            End If
        End Get
        Set(ByVal NewDataSource As DataTable)
            If mTipoControl = tbTipoControl.ListaAutoComplete Or mTipoControl = tbTipoControl.CodigoBusqueda Then
                mDataSource = NewDataSource
            End If
        End Set
    End Property

    'Define cual es el comportamiento para el control:
    '- Normal: Se comporta como cualquier Caja de Texto
    '- CodigoBusqueda: Hace una Búsqueda en el OrigenDeDatos del Control Asociado
    '                  y coloca el dato requerido en el control asociado.
    '- ListaAutoComplete: Debe tener un OrigenDeDatos para la lista de AutoComplete
    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("Define cual es el comportamiento para el control")>
    Public Property TipoControl() As tbTipoControl
        Get
            Return Me.mTipoControl
        End Get
        Set(ByVal Value As tbTipoControl)
            Me.mTipoControl = Value
            If mTipoControl = tbTipoControl.ListaAutoComplete Then
                MyBase.AutoCompleteMode = Windows.Forms.AutoCompleteMode.Suggest
                MyBase.AutoCompleteSource = Windows.Forms.AutoCompleteSource.CustomSource
            End If
        End Set

    End Property

    'Devuelve o establece el separador decimal
    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("Devuelve o establece el separador decimal")>
    Public Property DecSeparator() As Char
        Get
            Return Me.mDecSeparator
        End Get
        Set(ByVal Value As Char)
            If Value = "." OrElse Value = "," Then
                Me.mDecSeparator = Value
            End If

            If Me.EsFormatoDecimal() Then
                Me.ActualizarSeparador()
            End If
        End Set
    End Property

    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("Es el nombre del campo de datos del OrigenDeDatos del AutoComplete")>
    Public Property NombreCampoDatos() As String
        Get
            Return Me.mNombreCampoDatos
        End Get
        Set(ByVal Value As String)
            Me.mNombreCampoDatos = Value
        End Set
    End Property

    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("El Control Texto donde se escribe el valor buscado en un Control Tipo CódigoBusqueda")>
    Public Property ControlTextoEnlace() As TextBox
        Get
            Return Me.mctlTextoEnlace
        End Get
        Set(ByVal Value As TextBox)
            Me.mctlTextoEnlace = Value
        End Set
    End Property

    Public Property ControlComboEnlace() As ComboBusqueda
        Get
            Return Me.mComboEnlace
        End Get
        Set(ByVal Value As ComboBusqueda)
            Me.mComboEnlace = Value
        End Set
    End Property

    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("Nombre del Campo por el cual se hace la busqueda en el OrigenDeDatos para un control Tipo CodigoBusqueda")>
    Public Property NombreCampoBusqueda() As String
        Get
            Return Me.mNombreCampoBusqueda
        End Get
        Set(ByVal Value As String)
            Me.mNombreCampoBusqueda = Value
        End Set
    End Property

    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("Es el nombre del campo del OrigenDeDatos para recuperar en la Busqueda por Código")>
    Public Property NombreCampoBuscado() As String
        Get
            Return Me.mNombreCampoBuscado
        End Get
        Set(ByVal Value As String)
            Me.mNombreCampoBuscado = Value
        End Set
    End Property


    'Devuelve o establece el formato de entrada en la caja
    'de texto
    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("Devuelve o establece el formato de entrada en la caja de texto")>
    Public Property Format() As tbFormats
        Get
            Return Me.mFormat
        End Get
        Set(ByVal Value As tbFormats)
            Me.mFormat = Value

            Select Case Value
                Case tbFormats.Binario
                    okValues = "01"
                Case tbFormats.Hexadecimal
                    okValues = "0123456789AaBbCcDdEeFf"
                Case tbFormats.AlfabéticoSinEspacios
                    okValues = "abcdefghijklmnñopqrstuvwxyzáéíóúäëïöüàèìòùâêîôû"
                    okValues &= okValues.ToUpper()
                Case tbFormats.Octal
                    okValues = "01234567"
                Case tbFormats.AlfabéticoConEspacios
                    okValues = "abcdefghijklmnñopqrstuvwxyzáéíóúäëïöüàèìòùâêîôû"
                    okValues &= okValues.ToUpper() & " "
                Case tbFormats.NúmericoEnteroSinSigno
                    okValues = "0123456789"
                    'Case tbFormats.Fecha
                    '    okValues = "0123456789"
                Case tbFormats.DefinidoPorUsuario
                    okValues = Me.mUserValues
                Case Else
                    okValues = ""
            End Select

            okValues &= Me.ControlKeys

            Me.Text = MyBase.Text
        End Set
    End Property

    'Devuelve o establece la cadena de dígitos válidos para
    'un formato UserDefined
    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("Devuelve o establece la cadena de dígitos válidos para un formato UserDefined")>
    Public Property UserValues() As String
        Get
            Return Me.mUserValues
        End Get
        Set(ByVal Value As String)
            Me.mUserValues = Value

            If Me.Format = tbFormats.DefinidoPorUsuario Then
                okValues = Value & Me.ControlKeys
                Me.Text = MyBase.Text
            End If
        End Set
    End Property

    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("Devuelve o establece El Valor Minimo del Control")>
    Public Property ValorMinimo() As Long
        Get
            Return Me.mValorMinimo
        End Get
        Set(ByVal Value As Long)
            Me.mValorMinimo = Value
        End Set
    End Property

    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("Devuelve o establece El Valor Máximo del Control")>
    Public Property ValorMaximo() As Long
        Get
            Return Me.mValorMaximo
        End Get
        Set(ByVal Value As Long)
            Me.mValorMaximo = Value
        End Set
    End Property

    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("Devuelve o establece Si el Dato es Obligatorio")>
    Public Property Obligatorio() As Boolean
        Get
            Return Me.mObligatorio
        End Get
        Set(ByVal Value As Boolean)
            Me.mObligatorio = Value
        End Set
    End Property

    <System.ComponentModel.Category("Misc"), System.ComponentModel.Description("Devuelve o establece cualquier texto, del usuario, con el control")>
    Public Property DatoRelacionado() As String
        Get
            Return Me.mDatoRelacionado
        End Get
        Set(ByVal Value As String)
            Me.mDatoRelacionado = Value
        End Set
    End Property

    Public ReadOnly Property DescripcionCodigo() As String
        Get
            If MyBase.Text.Trim.Length = 0 Then
                Return ""
            End If
            If Not mComboEnlace Is Nothing Then
                Return BuscarCodigoCombo(MyBase.Text)
            Else
                Return BuscarDescripcion(MyBase.Text)
            End If

        End Get
    End Property

    Private _mPermitirCero As Boolean
    Public Property PermitirValorCero() As Boolean
        Get
            Return _mPermitirCero
        End Get
        Set(ByVal Value As Boolean)
            _mPermitirCero = Value
        End Set
    End Property

    Private _tbPosicionListaDesplegable As tbPosicionLista = tbPosicionLista.Bottom
    Public Property PosicionListaDesplegable() As tbPosicionLista
        Get
            Return _tbPosicionListaDesplegable
        End Get
        Set(ByVal Value As tbPosicionLista)
            _tbPosicionListaDesplegable = Value
        End Set
    End Property

    Public ReadOnly Property BotonBusqueda() As Button
        Get
            Return _BotonBusqueda
        End Get
    End Property

#End Region

#Region "Métodos nuevos de conversión"
    'Devuelve el contenido de la caja de texto como un valor
    'de tipo Double, considerando el formato actual de entrada
    Public Function ToDouble() As Double
        Select Case Me.Format
            Case tbFormats.Hexadecimal
                Return CDbl(Me.BaseADecimal(16))

            Case tbFormats.Octal
                Return CDbl(Me.BaseADecimal(8))

            Case tbFormats.Binario
                Return CDbl(Me.BaseADecimal(2))
            Case tbFormats.AlfabéticoSinEspacios,
                 tbFormats.AlfaNúmericoSinEspacios,
                 tbFormats.AlfabéticoConEspacios,
                 tbFormats.AlfaNúmericoConEspacios, tbFormats.DefinidoPorUsuario

                Try
                    Return Double.Parse(Me.Text)
                Catch
                    Return 0D
                End Try

            Case tbFormats.NúmericoEnteroConSigno, tbFormats.NúmericoEnteroSinSigno
                Return CDbl(Me.Text)

            Case Else
                Dim s() As Char = Me.Text.ToCharArray()
                Dim stext As String = ""
                Dim i As Integer

                For i = 0 To s.Length - 1
                    If s(i) = "." Then
                        s(i) = ","
                    End If

                    stext &= s(i).ToString()
                Next i

                Return Double.Parse(stext, Globalization.NumberStyles.Float)
        End Select
    End Function

    'Devuelve el contenido del TextBox como un valor de tipo
    'Long, considerando el formato actual de entrada
    Public Function ToInt64() As Long
        Return CLng(Me.ToDouble())
    End Function

    'Devuelve una cadena con el contenido del TextBox en base
    'octal, considerando el formato actual de entrada
    Public Function ToOctal() As String
        Return Me.DecimalABase(Me.ToInt64(), 8)
    End Function

    'Devuelve una cadena con el contenido del TextBox en base
    'hexadecimal, considerando el formato actual de entrada
    Public Function ToHexadecimal() As String
        Return Me.DecimalABase(Me.ToInt64(), 16)
    End Function

    'Devuelve una cadena con el contenido del TextBox en base
    'binaria, considerando el formato actual de entrada
    Public Function ToBynary() As String
        Return Me.DecimalABase(Me.ToInt64(), 2)
    End Function

    Public Sub CargarDatosDescripcion()
        Dim intRow As Integer

        Me.CargarButton()
        If Not mDataSource Is Nothing Then
            If mDataSource.Rows.Count > 0 Then
                If mTipoControl = tbTipoControl.ListaAutoComplete Then
                    Dim ListaDatos As New AutoCompleteStringCollection()

                    For intRow = 0 To mDataSource.Rows.Count - 1
                        ListaDatos.Add(mDataSource.Rows(intRow)(Me.mNombreCampoDatos))
                    Next
                    MyBase.AutoCompleteCustomSource = Nothing
                    MyBase.AutoCompleteCustomSource = ListaDatos
                End If
            End If
        End If
    End Sub

#End Region

#Region "Eventos Modificados"

    Private Sub TextBoxConFormato_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.EnabledChanged

        If Not BotonBusqueda Is Nothing Then
            _BotonBusqueda.Enabled = sender.Enabled
        End If
    End Sub

    Private Sub TextBoxConFormato_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Not BotonBusqueda Is Nothing Then
            _BotonBusqueda.Visible = sender.Visible
        End If
    End Sub


    Private Sub TextBoxConFormato_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleCreated

        If Me.Enabled Then
            cmdButton.Enabled = True
        Else
            cmdButton.Enabled = False
        End If

        If Me.Visible Then
            cmdButton.Visible = True
        Else
            cmdButton.Visible = False
        End If

    End Sub

    Private Sub TextBoxConFormato_ModifiedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ModifiedChanged
        If Me.mblnClicDerecho = True Then
            Const WM_CHAR As Integer = 258
            Dim s() As Char = MyBase.Text.ToCharArray()
            Dim c As Char
            Dim wParam As IntPtr
            Dim lParam As New IntPtr(0)
            Dim m As Message

            MyBase.Text = ""

            For Each c In s
                wParam = New IntPtr(Asc(c))
                m = Message.Create(Me.Handle, WM_CHAR, wParam, lParam)

                If Me.validar(m) Then
                    MyBase.Text &= c.ToString()
                End If
            Next
            System.Windows.Forms.Clipboard.Clear()
            Me.mblnClicDerecho = False
        End If
    End Sub

    Private Sub TextBoxConFormato_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Me.mblnClicDerecho = True
        End If

    End Sub
#End Region

    Private Function SiguienteControl(ByVal ctlControl As Control) As Control
        Dim blnRespuesta As Boolean
        Dim ctlControlFocus As Control
        Dim ctlControlActual As Control

        ctlControlActual = ctlControl
        Do
            ctlControlFocus = Me.Parent.GetNextControl(ctlControlActual, True)
            If ctlControlFocus.CanFocus = True Then
                blnRespuesta = True
            Else
                ctlControlActual = ctlControlFocus
            End If
        Loop While blnRespuesta = False
        Return ctlControlFocus
    End Function

End Class
