Imports System.Collections.Generic
Imports System.Linq
Imports System.Xml.Serialization
Imports HistoriaClinica.Sophia.HistoriaClinica.BL
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosConexion
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosGenerales
Imports HistoriaClinica.Sophia.HistoriaClinica.DatosPaciente

''' <summary>
''' Control Particularidades procedimiento.
''' Autor: Joseph Moreno (IG)
''' </summary>
Public Class ctlParticularidadesProc
    Private Shared _Instancia As ctlParticularidadesProc
#Region "Instancia de Control"
    Public Shared ReadOnly Property Instancia() As ctlParticularidadesProc
        Get
            If _Instancia Is Nothing Then
                _Instancia = New ctlParticularidadesProc
            End If
            Return _Instancia
        End Get
    End Property
#End Region
    ''' <summary>
    ''' Diccionario de grupos de particularidades asociados al procedimiento
    ''' </summary>
    Private grupos As Dictionary(Of Integer, GrupoParticularidadProc)
    ''' <summary>
    ''' Diccionario de particularidades asociadas a los grupos de particularidades asociados al procedimiento
    ''' </summary>
    Private particularidades As Dictionary(Of Integer, ParticularidadProc)
    ''' <summary>
    ''' Pares grupo-particularidad seleccionados para el procedimiento
    ''' </summary>
    Private datos As HashSet(Of Grupo_Particularidad)
    ''' <summary>
    ''' Diccionario de controles generados dinámicamente asociados a la instancia del grupo de particularidades
    ''' </summary>
    Private controles As Dictionary(Of Control, Grupo_Particularidad)


    ''' <summary>
    ''' Listado de descripciones informativas segun las particularidades seleccionadas
    ''' </summary>
    Private informativos As HashSet(Of String)
    ''' <summary>
    ''' Cantidad del procedimiento actual, calculado segun las particularidades seleccionadas
    ''' </summary>
    Private cant As Integer
    ''' <summary>
    ''' Listado de descripciones diferenciadoras segun las particularidades seleccionadas
    ''' </summary>
    Private diferenciadores As HashSet(Of String)
    ''' <summary>
    ''' Listado de procedimientos asociados al procedimiento principal segun las particularidades seleccionadas
    ''' </summary>
    Private procedimientos As Dictionary(Of String, Procedimiento_Particularidad)

    ''' <summary>
    ''' Código de procedimiento principal
    ''' </summary>
    Private procedim As String
    ''' <summary>
    ''' Descripción original del procedimiento
    ''' </summary>
    Private desc As String
    ''' <summary>
    ''' Delegado para ejecución de actualización de datos
    ''' </summary>
    Private actDatos As ActDatosParticularidades
    ''' <summary>
    ''' Altura anterior del control para redimensionamiento efectivo.
    ''' </summary>
    Private antAltura As Integer
    ''' <summary>
    ''' Máxima altura que tomaría la instancia
    ''' </summary>
    Private maxH As Integer
    ''' <summary>
    ''' Offset en la altura que tomaría la instancia
    ''' </summary>
    Private offH As Integer

    ''' <summary>
    ''' Objeto conexión
    ''' </summary>
    Private objConexion As Conexion
    ''' <summary>
    ''' Objeto general
    ''' </summary>
    Private objGeneral As Generales
    ''' <summary>
    ''' Objeto de paciente
    ''' </summary>
    Private objPaciente As Paciente

    ''' <summary>
    ''' Espacio horizontal entre controles
    ''' </summary>
    Private Const wSpan As Integer = 9
    ''' <summary>
    ''' Espacio vertical entre controles
    ''' </summary>
    Private Const hSpan As Integer = 9
    ''' <summary>
    ''' Tamaño de la fuente del texto del groupbox
    ''' </summary>
    Private Const szGrp As Integer = 7
    ''' <summary>
    ''' Tamaño de la fuente del texto del checkbox/radiobutton
    ''' </summary>
    Private Const szBut As Integer = 7

    ''' <summary>
    ''' Valor por defecto de altura máxima
    ''' </summary>
    Public Const MaxHeight As Integer = 250
    ''' <summary>
    ''' Altura mínima del control
    ''' </summary>
    Public Const MinHeight As Integer = 30

    ''' <summary>
    ''' Si aplica, etiqueta que acompaña al control.
    ''' </summary>
    Private etiqueta As Label

    ''' <summary>
    ''' Cambia la altura del control segun la información recolectada de la base de datos
    ''' </summary>
    ''' <param name="alto"></param>
    Private Sub ActualizarAltura(ByVal alto As Integer)
        antAltura = IIf(Me.Height > MinHeight, Me.Height, 0)
        Me.Height = alto + IIf(alto > MinHeight, 3, 0)
        Me.pCont.Height = alto

        ActualizarTamanoPadre()
    End Sub

    ''' <summary>
    ''' Despliega el cambio de altura de la instancia al padre y niveles superiores.
    ''' </summary>
    Private Sub ActualizarTamanoPadre()
        Dim mostrar As Boolean
        Dim hijo As Control = Nothing
        Dim padre As Control = Nothing
        Dim continuar As Boolean = True
        Dim tieneOffset As Boolean = offH > 0

        mostrar = (Me.Height <> MinHeight)
        Me.Visible = mostrar
        If Not IsNothing(etiqueta) Then
            etiqueta.Visible = mostrar
        End If
        hijo = Me
        padre = hijo.Parent
        Do While Not IsNothing(padre) AndAlso continuar
            If GetType(Panel).IsAssignableFrom(padre.GetType()) Then
                continuar = Not CType(padre, Panel).AutoScroll
            End If
            If continuar Then
                padre.Height = padre.Height + IIf(mostrar, Me.Height + IIf(tieneOffset, offH, 0), 0) - (antAltura + IIf(tieneOffset And antAltura > MinHeight, offH, 0))
                If GetType(ContainerControl).IsAssignableFrom(padre.GetType()) Then
                    continuar = False
                End If
            End If
            For Each ctl As Control In padre.Controls
                If ctl.Top >= hijo.Top Then
                    If Not ctl.Equals(hijo) AndAlso (IsNothing(etiqueta) OrElse Not ctl.Equals(etiqueta)) Then
                        ctl.Top = ctl.Top + IIf(mostrar, Me.Height + IIf(tieneOffset, offH, 0), 0) - (antAltura + IIf(tieneOffset And antAltura > MinHeight, offH, 0))
                    End If
                End If
            Next
            hijo = padre
            padre = hijo.Parent
            tieneOffset = False
        Loop
    End Sub

    ''' <summary>
    ''' Método que inicializa el control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Sub Inicializar(sender As Object, e As EventArgs) Handles Me.Load
        Me.pCont.Width = Me.Width - 20
        Me.Height = MinHeight
        Me.Visible = False
    End Sub

    ''' <summary>
    ''' Método para pasar los parámetros al control
    ''' </summary>
    ''' <param name="ctl">Etiqueta que acompaña al control.</param>
    ''' <param name="max">Altura máxima que pueda tomar el control.</param>
    ''' <param name="offset">Offset en la altura que debe tener el control.</param>
    Public Sub PasarParametros(Optional ByRef ctl As Label = Nothing, Optional ByVal max As Integer = MaxHeight, Optional ByVal offset As Integer = 0)
        etiqueta = ctl
        maxH = max
        offH = offset
    End Sub

    ''' <summary>
    ''' Método para pasar los datos del procedimiento.
    ''' </summary>
    ''' <param name="strCodProced">Código del procedimiento.</param>
    ''' <param name="strDesProced">Descripción original del procedimiento.</param>
    ''' <param name="actualizarDesc">Delegado para actualizar los datos del procedimiento segun selección.</param>
    ''' <param name="strXmlGrpXPart">Datos precargados de las particularidades.</param>
    Public Sub PasarDatos(
                         Optional ByVal strCodProced As String = "", Optional ByVal strDesProced As String = "",
                         Optional ByVal actualizarDesc As ActDatosParticularidades = Nothing,
                         Optional ByVal strXmlGrpXPart As String = "")
        Dim listadoGrupos As List(Of GrupoParticularidadProc) = Nothing
        Dim listadoParticularidades As List(Of ParticularidadProc) = Nothing

        Limpiar()
        If strCodProced <> "" Then
            procedim = strCodProced
            desc = strDesProced
            actDatos = actualizarDesc

            objConexion = Conexion.Instancia
            objGeneral = Generales.Instancia
            objPaciente = Paciente.Instancia

            Dim param() As Object = {objGeneral.Prestador, objGeneral.Sucursal, objPaciente.Entidad, strCodProced}
            Dim table As DataTable

            table = BLParticularidadesProc.TraerParticularidades(objConexion, param)
            For Each row As DataRow In table.Rows
                If (Not IsDBNull(row("XmlGrupos")) AndAlso Not IsDBNull(row("XmlParticularidades"))) Then
                    listadoGrupos = BLParticularidadesProc.DeserializeXml(Of List(Of GrupoParticularidadProc))(row("XmlGrupos").ToString(), New XmlRootAttribute("Raiz"))
                    listadoParticularidades = BLParticularidadesProc.DeserializeXml(Of List(Of ParticularidadProc))(row("XmlParticularidades").ToString(), New XmlRootAttribute("Raiz"))
                End If
            Next

            If (Not IsNothing(listadoGrupos) AndAlso Not IsNothing(listadoParticularidades)) Then
                grupos = New Dictionary(Of Integer, GrupoParticularidadProc)
                particularidades = New Dictionary(Of Integer, ParticularidadProc)
                For Each grupo As GrupoParticularidadProc In listadoGrupos
                    grupos.Add(grupo.Id, grupo)
                Next
                For Each part As ParticularidadProc In listadoParticularidades
                    particularidades.Add(part.Id, part)
                Next
                Dibujar(strXmlGrpXPart)
            Else
                ActualizarAltura(MinHeight)
            End If
        Else
            ActualizarAltura(MinHeight)
        End If
    End Sub

    ''' <summary>
    ''' Bloquea o desbloquea los controles internos según el parámetro indicado. No bloquea el panel con scroll.
    ''' </summary>
    ''' <param name="act">Indica si se debe activar o desactivar los controles.</param>
    Public Sub Activar(ByVal act As Boolean)
        For Each ctl As Control In Me.pCont.Controls
            ctl.Enabled = act
        Next
    End Sub

    ''' <summary>
    ''' Crea dinámicamente los controles de las particularidades y los asigna si trae información precargada.
    ''' </summary>
    ''' <param name="strXmlGrpXPart">Información de particularidades precargada.</param>
    Private Sub Dibujar(ByVal strXmlGrpXPart As String)
        Dim gTop As Integer = 0
        Dim left As Integer = 0
        Dim top As Integer = 0

        datos = New HashSet(Of Grupo_Particularidad)
        controles = New Dictionary(Of Control, Grupo_Particularidad)

        If Not String.IsNullOrEmpty(strXmlGrpXPart) Then
            For Each dato As Grupo_Particularidad In BLParticularidadesProc.DeserializeXml(Of ListadoSophiaDB(Of Grupo_Particularidad))(strXmlGrpXPart).Filas
                datos.Add(dato)
            Next
        End If

        For Each grupo As GrupoParticularidadProc In grupos.Values
            'Joseph Moreno (IG) Fec:2019/11/27 Excluir grupos sin particularidades asociadas
            If grupo.Particularidades.Count > 0 Then
                left = wSpan
                top = hSpan
                grupo.Control = New GroupBox()
                grupo.Control.Height = hSpan
                grupo.Control.Width = Me.pCont.Width - 20
                grupo.Control.Name = "grp_" & grupo.Id
                'Joseph Moreno (IG) Fec:2019/12/17 Se comenta línea por solicitud de Mónica Astrid Poveda Moreno
                'grupo.Control.Text = grupo.Descripcion
                grupo.Control.Enabled = grupo.Activo
                grupo.Control.Top = gTop
                grupo.Control.Font = New Font(New FontFamily("Verdana"), szGrp, FontStyle.Bold)
                grupo.Control.ForeColor = Color.FromArgb(18, 120, 156)

                AddHandler grupo.Control.DoubleClick, AddressOf DClickGroupBox
                For Each id_par As Integer In grupo.Particularidades
                    If grupo.Tipo = "E" Then
                        CrearRadioButton(grupo, particularidades(id_par), left, top)
                    Else
                        CrearCheckBox(grupo, particularidades(id_par), left, top)
                    End If
                Next
                'Joseph Moreno (IG) Fec:2019/11/27 Cambio de condición para modificación de altura.
                grupo.Control.Height = grupo.Control.Height + 2
                'grupo.Control.Height = grupo.Control.Height + IIf(szBut < hSpan AndAlso grupo.Control.Height > hSpan, szBut, 0)
                gTop = gTop + grupo.Control.Height
                Me.pCont.Controls.Add(grupo.Control)
            End If
        Next

        If gTop >= maxH Then
            ActualizarAltura(maxH)
        ElseIf gTop >= 2 * hSpan Then
            ActualizarAltura(gTop)
        Else
            ActualizarAltura(MinHeight)
        End If

        Me.ResizeRedraw = True
    End Sub

    ''' <summary>
    ''' Crea una instancia tipo CheckBox para particularidades en grupos inclyentes
    ''' </summary>
    ''' <param name="grupo">Instancia del grupo</param>
    ''' <param name="particularidad">Instancia de la particularidad</param>
    ''' <param name="left">Posición izquierda del control.</param>
    ''' <param name="top">Posición superior del control</param>
    Private Sub CrearCheckBox(ByRef grupo As GrupoParticularidadProc, ByRef particularidad As ParticularidadProc, ByRef left As Integer, ByRef top As Integer)
        Dim chk As CheckBox = New CheckBox()
        Dim key As Grupo_Particularidad
        key = New Grupo_Particularidad(grupo.Id, particularidad.Id)
        chk.Name = "chk_" & key.Grupo & "_" & key.Particularidad
        chk.Text = particularidad.Descripcion

        'Inicia: CCGUTIEREZ - OSI. ALM 115. 03/01/2020
        'Proyecto: Sophia - Codificacion
        'Cambio: Se define el ancho del control para dar simetría al visualizarlo
        chk.Width = 240
        chk.Height = 24
        'Fin. CCGUTIEREZ

        chk.Checked = datos.Contains(key)
        chk.Enabled = grupo.Activo AndAlso particularidad.Activo
        AgregarControl(grupo.Control, chk, left, top)
        AddHandler chk.Click, AddressOf ClickCheckBox
        grupo.Control.Controls.Add(chk)
        controles.Add(chk, key)
    End Sub

    ''' <summary>
    ''' Crea una instancia tipo RadioButton para particularidades en grupos excluyentes
    ''' </summary>
    ''' <param name="grupo">Instancia del grupo</param>
    ''' <param name="particularidad">Instancia de la particularidad</param>
    ''' <param name="left">Posición izquierda del control.</param>
    ''' <param name="top">Posición superior del control</param>
    Private Sub CrearRadioButton(ByRef grupo As GrupoParticularidadProc, ByRef particularidad As ParticularidadProc, ByRef left As Integer, ByRef top As Integer)
        Dim rad As RadioButton = New RadioButton()
        Dim key As Grupo_Particularidad
        key = New Grupo_Particularidad(grupo.Id, particularidad.Id)
        rad.Name = "rad_" & key.Grupo & "_" & key.Particularidad
        rad.Text = particularidad.Descripcion

        'Inicia: CCGUTIEREZ - OSI. ALM 115. 03/01/2020
        'Proyecto: Sophia - Codificacion
        'Cambio: Se define el ancho del control x error al visualizarlo
        rad.Width = 240
        rad.Height = 24
        'Fin. CCGUTIEREZ

        rad.Checked = datos.Contains(key)
        rad.Enabled = grupo.Activo AndAlso particularidad.Activo
        AgregarControl(grupo.Control, rad, left, top)
        AddHandler rad.Click, AddressOf ClickRadio
        grupo.Control.Controls.Add(rad)
        controles.Add(rad, key)
    End Sub

    ''' <summary>
    ''' Agrega un control hijo sobre un control padre.
    ''' </summary>
    ''' <param name="parent">Control padre.</param>
    ''' <param name="child">Control hijo.</param>
    ''' <param name="left">Posición izquierda del control.</param>
    ''' <param name="top">Posición derecha del control.</param>
    Private Sub AgregarControl(ByRef parent As Control, ByRef child As Control, ByRef left As Integer, ByRef top As Integer)
        If (left + child.Width > parent.Width) And left <> wSpan Then
            left = wSpan
            top = parent.Height + hSpan
        End If
        If top + child.Height + hSpan > parent.Height Then
            parent.Height = parent.Height + child.Height + hSpan
        End If
        child.Top = top
        child.Left = left
        child.Font = New Font(New FontFamily("Verdana"), szBut, FontStyle.Bold)
        left = left + child.Width + hSpan
    End Sub

    ''' <summary>
    ''' Evento al hacer clic sobre CheckBox. (Incluyente)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ClickCheckBox(ByVal sender As Object, ByVal e As EventArgs)
        Dim key As Grupo_Particularidad = BuscarGrupo_Particularidad(sender)
        If CType(sender, CheckBox).Checked Then
            If Not datos.Contains(key) Then
                datos.Add(key)
            End If
        Else
            If datos.Contains(key) Then
                datos.Remove(key)
            End If
        End If
        ActualizarPadre()
    End Sub

    ''' <summary>
    ''' Evento al hacer clic sobre RadioButton. (Excluyente)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ClickRadio(ByVal sender As Object, ByVal e As EventArgs)
        Dim key As Grupo_Particularidad = BuscarGrupo_Particularidad(sender)
        If CType(sender, RadioButton).Checked Then
            datos.RemoveWhere(Function(val) val.Grupo = key.Grupo AndAlso val.Particularidad <> key.Particularidad)
            If Not datos.Contains(key) Then
                datos.Add(key)
            End If
        Else
            If datos.Contains(key) Then
                datos.Remove(key)
            End If
        End If
        ActualizarPadre()
    End Sub

    ''' <summary>
    ''' Función para traer la instancia del grupo segun la instancia del control seleccionado
    ''' </summary>
    ''' <param name="ctl"></param>
    ''' <returns></returns>
    Private Function BuscarGrupo_Particularidad(ByRef ctl As Control) As Grupo_Particularidad
        Dim resultado As Grupo_Particularidad = CType(Nothing, Grupo_Particularidad)
        If controles.ContainsKey(ctl) Then
            resultado = controles(ctl)
        Else
            Dim ctlName = ctl.Name
            Dim ctlType = ctl.GetType()
            Dim ctl2 As Control = controles.Keys.FirstOrDefault(
                Function(c)
                    Return c.Name = ctlName AndAlso c.GetType() = ctlType
                End Function
                )
            If Not IsNothing(ctl2) Then
                resultado = controles(ctl2)
                If GetType(CheckBox).IsAssignableFrom(ctlType) Then
                    CType(ctl2, CheckBox).Checked = CType(ctl, CheckBox).Checked
                ElseIf GetType(RadioButton).IsAssignableFrom(ctlType) Then
                    CType(ctl2, RadioButton).Checked = CType(ctl, RadioButton).Checked
                End If
            End If
        End If
        Return resultado
    End Function

    ''' <summary>
    ''' Evento al hacer doble clic sobre el GroupBox
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub DClickGroupBox(ByVal sender As Object, ByVal e As EventArgs)
        For Each ctl As Control In CType(sender, Control).Controls
            If TypeOf ctl Is RadioButton Then
                CType(ctl, RadioButton).Checked = False
            ElseIf TypeOf ctl Is CheckBox Then
                CType(ctl, CheckBox).Checked = False
            End If
            datos.Remove(controles(ctl))
        Next
        ActualizarPadre()
    End Sub

    ''' <summary>
    ''' Función final para actualización de datos en el padre.
    ''' </summary>
    Private Sub ActualizarPadre()
        RecalcularDatos()
        If Not IsNothing(actDatos) Then
            actDatos(DescripcionTotal, Cantidad, XmlGrpXPar, XmlProcPar)
        End If
    End Sub

    ''' <summary>
    ''' Evento para finalizar el control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Public Sub Finalizar(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Disposed
        Limpiar()
    End Sub

    ''' <summary>
    ''' Limpia el control y lo redimensiona si se indica.
    ''' </summary>
    ''' <param name="booRedim">Indica si se debe redimensionar el control.</param>
    Public Sub Limpiar(Optional ByVal booRedim As Boolean = False)
        For Each ctl_0 As Control In Me.pCont.Controls
            For Each ctl_1 As Control In ctl_0.Controls
                If Not ctl_1.IsDisposed Then
                    ctl_1.Dispose()
                End If
                If Not IsNothing(controles) Then
                    controles.Remove(ctl_1)
                End If
            Next
            If Not ctl_0.IsDisposed Then
                ctl_0.Dispose()
            End If
            ctl_0.Controls.Clear()
        Next
        Me.pCont.Controls.Clear()

        desc = ""
        procedim = ""
        cant = 0

        If Not IsNothing(controles) Then
            For Each ctl As Control In controles.Keys
                If Not ctl.IsDisposed Then
                    ctl.Dispose()
                End If
            Next
            controles.Clear()
        End If
        controles = Nothing
        If Not IsNothing(datos) Then
            datos.Clear()
        End If
        datos = Nothing
        If Not IsNothing(particularidades) Then
            particularidades.Clear()
        End If
        particularidades = Nothing
        If Not IsNothing(grupos) Then
            grupos.Clear()
        End If
        grupos = Nothing
        If Not IsNothing(procedimientos) Then
            procedimientos.Clear()
        End If
        procedimientos = Nothing
        If Not IsNothing(diferenciadores) Then
            diferenciadores.Clear()
        End If
        diferenciadores = Nothing
        If Not IsNothing(informativos) Then
            informativos.Clear()
        End If
        informativos = Nothing

        If booRedim Then
            ActualizarAltura(MinHeight)
        End If
    End Sub

    ''' <summary>
    ''' Recalcula los datos del procedimiento segun las particularidades seleccionadas.
    ''' </summary>
    Private Sub RecalcularDatos()
        If Not IsNothing(datos) Then

            informativos = New HashSet(Of String)
            cant = 0
            diferenciadores = New HashSet(Of String)
            procedimientos = New Dictionary(Of String, Procedimiento_Particularidad)

            Dim proc As Procedimiento_Particularidad
            For Each key As Grupo_Particularidad In datos
                If particularidades(key.Particularidad).Tipo = "I" Then
                    informativos.Add(particularidades(key.Particularidad).Descripcion)
                    If cant < particularidades(key.Particularidad).Cantidad Then
                        cant = particularidades(key.Particularidad).Cantidad
                    End If
                Else
                    diferenciadores.Add(particularidades(key.Particularidad).Descripcion)
                    If procedimientos.ContainsKey(particularidades(key.Particularidad).Procedimiento) Then
                        proc = procedimientos(particularidades(key.Particularidad).Procedimiento)
                    Else
                        proc = New Procedimiento_Particularidad(particularidades(key.Particularidad).Procedimiento)
                        procedimientos.Add(particularidades(key.Particularidad).Procedimiento, proc)
                    End If
                    proc.AumentarCantidad()
                End If
            Next
        Else
            informativos = Nothing
            cant = 0
            diferenciadores = Nothing
            procedimientos = Nothing
        End If
    End Sub

    ''' <summary>
    ''' Trae la descripción original del procedimiento
    ''' </summary>
    ''' <returns>Descripción original del procedimiento</returns>
    Public Function DescripcionOriginal() As String
        Return desc
    End Function

    ''' <summary>
    ''' Traer la descripción adicional generada por descripciones informativas.
    ''' </summary>
    ''' <returns>Descripción adicional informativa</returns>
    Public Function DescripcionInformativa() As String
        Dim result As String = ""
        If Not IsNothing(informativos) Then
            'Joseph Moreno (IG) Fec:2019/12/27 Ajuste separador
            'result = String.Join(" ", informativos)
            result = String.Join(" - ", informativos)
        End If
        Return result
    End Function

    ''' <summary>
    ''' Traer la descripción adicional generada por descripciones informativas.
    ''' </summary>
    ''' <returns>Descripción adicional diferenciadora</returns>
    Public Function DescripcionDiferenciadora() As String
        Dim result As String = ""
        'Joseph Moreno (IG) Fec:2019/12/27 Ajuste separador
        'Dim arr As String()
        If Not IsNothing(diferenciadores) AndAlso diferenciadores.Count > 0 Then
            'Joseph Moreno (IG) Fec:2019/12/27 Ajuste separador
            'arr = diferenciadores.ToArray()
            'For i As Integer = 0 To arr.Length - 2
            '    result = result & IIf(result <> "", ", ", "") & arr(i)
            'Next
            'result = result & IIf(result <> "", " Y ", "") & arr(arr.Length - 1)
            result = String.Join(" - ", diferenciadores)
        End If
        Return result
    End Function

    ''' <summary>
    ''' Trae descripción total del procedimiento segun las particularidades seleccionadas y su descripción original
    ''' </summary>
    ''' <returns>Descripción completa del procedimiento</returns>
    Public Function DescripcionTotal() As String
        'Joseph Moreno (IG) Fec:2019/12/27 Ajuste separador
        'Return DescripcionOriginal() & IIf(DescripcionInformativa() <> "", " " & DescripcionInformativa(), "") & IIf(DescripcionDiferenciadora() <> "", " CON " & DescripcionDiferenciadora(), "")
        Return DescripcionOriginal() & IIf(DescripcionInformativa() <> "", " - " & DescripcionInformativa(), "") & IIf(DescripcionDiferenciadora() <> "", " - " & DescripcionDiferenciadora(), "")
    End Function

    ''' <summary>
    ''' Trae la cantidad calculada del procedimiento segun las particularidades seleccionadas.
    ''' </summary>
    ''' <returns>Cantidad total</returns>
    Public Function Cantidad() As Integer
        Return cant
    End Function

    ''' <summary>
    ''' Genera XML válido para procesar los pares grupo-particularidad en Sophia.
    ''' </summary>
    ''' <returns>XML de particularidades.</returns>
    Public Function XmlGrpXPar() As String
        If IsNothing(datos) OrElse (datos.Count = 0 AndAlso Validar()) Then
            Return ""
        End If
        Return BLParticularidadesProc.Serialize(New ListadoSophiaDB(Of Grupo_Particularidad)() With {.Filas = datos})
    End Function

    ''' <summary>
    ''' Genera XML válido para procesar los procedimientos adicionales en Sophia. 
    ''' </summary>
    ''' <returns>XML de procedimientos.</returns>
    Public Function XmlProcPar() As String
        If IsNothing(procedimientos) Then
            Return ""
        End If
        Return BLParticularidadesProc.Serialize(New ListadoSophiaDB(Of Procedimiento_Particularidad)() With {.Filas = New HashSet(Of Procedimiento_Particularidad)(procedimientos.Values.ToArray())})
    End Function

    ''' <summary>
    ''' Vector de procedimientos asociados a las particularidades seleccionadas.
    ''' </summary>
    ''' <returns>Procedimientos asociados.</returns>
    Public Function ProcedimientosAsociados() As Procedimiento_Particularidad()
        If Not IsNothing(procedimientos) Then
            Return procedimientos.Values.ToArray()
        End If
        Return {}
    End Function

    ''' <summary>
    ''' Vector de pares grupo-particularidad segun las particularidades seleccionadas.
    ''' </summary>
    ''' <returns>Pares grupo-articularidad asociados.</returns>
    Public Function ParticularidadesAsociadas() As Grupo_Particularidad()
        If Not IsNothing(datos) Then
            datos.ToArray()
        End If
        Return {}
    End Function

    ''' <summary>
    ''' Indica si se ha seleccionado alguna particularidad de nombre "Bilateral"
    ''' </summary>
    ''' <returns>Bilateralidad</returns>
    Public Function Bilateral() As Boolean
        If Not IsNothing(particularidades) AndAlso Not IsNothing(datos) Then
            Dim partList As HashSet(Of Integer) = New HashSet(Of Integer)
            For Each gp As Grupo_Particularidad In datos
                partList.Add(gp.Particularidad)
            Next
            Return (particularidades.Values.Where(
                Function(val)
                    Return partList.Contains(val.Id) AndAlso val.Descripcion.ToUpper().Contains("BILATERAL")
                End Function).Count > 0)
        End If
        Return False
    End Function

    ''' <summary>
    ''' Valida los datos seleccionados del control
    ''' </summary>
    ''' <returns>Validación del control</returns>
    Public Function Validar() As Boolean
        Dim activos As Integer
        Dim validados As Integer
        If Not IsNothing(datos) AndAlso Not IsNothing(controles) Then
            validados = datos.Count
            activos = controles.Where(Function(k, v) k.Key.Enabled).Count
            Return activos = 0 OrElse validados > 0
        End If
        Return True
    End Function
End Class