<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPruebasGerman
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPruebasGerman))
        Me.pnlContenedorPantallas = New XPanderControl.XPanderList
        Me.pnlContenedorDatos = New XPanderControl.XPander
        Me.pnlContenedorDatosPaciente = New XPanderControl.XPander
        Me.cmdListaEspera = New System.Windows.Forms.Button
        Me.cmdHistoriaBasica = New System.Windows.Forms.Button
        Me.pnlContenedorListaEspera = New System.Windows.Forms.Panel
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.pnlContenedorPantallas.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlContenedorPantallas
        '
        Me.pnlContenedorPantallas.AutoScroll = True
        Me.pnlContenedorPantallas.BackColor = System.Drawing.Color.White
        Me.pnlContenedorPantallas.BackColorDark = System.Drawing.Color.White
        Me.pnlContenedorPantallas.BackColorLight = System.Drawing.Color.White
        Me.pnlContenedorPantallas.Controls.Add(Me.pnlContenedorDatos)
        Me.pnlContenedorPantallas.Controls.Add(Me.pnlContenedorDatosPaciente)
        Me.pnlContenedorPantallas.ForeColor = System.Drawing.Color.Transparent
        Me.pnlContenedorPantallas.Location = New System.Drawing.Point(100, 87)
        Me.pnlContenedorPantallas.Name = "pnlContenedorPantallas"
        Me.pnlContenedorPantallas.Size = New System.Drawing.Size(836, 654)
        Me.pnlContenedorPantallas.TabIndex = 2
        '
        'pnlContenedorDatos
        '
        Me.pnlContenedorDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlContenedorDatos.BackColor = System.Drawing.Color.Transparent
        Me.pnlContenedorDatos.BorderStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.pnlContenedorDatos.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
        Me.pnlContenedorDatos.CaptionFormatFlag = XPanderControl.XPander.FormatFlag.NoWrap
        Me.pnlContenedorDatos.CaptionStyle = XPanderControl.XPander.CaptionStyleEnum.Normal
        Me.pnlContenedorDatos.CaptionText = "      "
        Me.pnlContenedorDatos.CaptionTextAlign = XPanderControl.XPander.CaptionTextAlignment.Left
        Me.pnlContenedorDatos.ChevronStyle = XPanderControl.XPander.ChevronStyleEnum.None
        Me.pnlContenedorDatos.CollapsedHighlightImage = CType(resources.GetObject("pnlContenedorDatos.CollapsedHighlightImage"), System.Drawing.Bitmap)
        Me.pnlContenedorDatos.CollapsedImage = CType(resources.GetObject("pnlContenedorDatos.CollapsedImage"), System.Drawing.Bitmap)
        Me.pnlContenedorDatos.ExpandedHighlightImage = CType(resources.GetObject("pnlContenedorDatos.ExpandedHighlightImage"), System.Drawing.Bitmap)
        Me.pnlContenedorDatos.ExpandedImage = CType(resources.GetObject("pnlContenedorDatos.ExpandedImage"), System.Drawing.Bitmap)
        Me.pnlContenedorDatos.Location = New System.Drawing.Point(3, 205)
        Me.pnlContenedorDatos.Name = "pnlContenedorDatos"
        Me.pnlContenedorDatos.Padding = New System.Windows.Forms.Padding(0, 25, 0, 0)
        Me.pnlContenedorDatos.PaneBottomRightColor = System.Drawing.Color.White
        Me.pnlContenedorDatos.Size = New System.Drawing.Size(830, 446)
        Me.pnlContenedorDatos.TabIndex = 1
        Me.pnlContenedorDatos.Tag = 0
        Me.pnlContenedorDatos.TooltipText = Nothing
        '
        'pnlContenedorDatosPaciente
        '
        Me.pnlContenedorDatosPaciente.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnlContenedorDatosPaciente.BackColor = System.Drawing.Color.Transparent
        Me.pnlContenedorDatosPaciente.BorderStyle = System.Windows.Forms.Border3DStyle.Flat
        Me.pnlContenedorDatosPaciente.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold)
        Me.pnlContenedorDatosPaciente.CaptionFormatFlag = XPanderControl.XPander.FormatFlag.NoWrap
        Me.pnlContenedorDatosPaciente.CaptionStyle = XPanderControl.XPander.CaptionStyleEnum.Normal
        Me.pnlContenedorDatosPaciente.CaptionText = "     "
        Me.pnlContenedorDatosPaciente.CaptionTextAlign = XPanderControl.XPander.CaptionTextAlignment.Left
        Me.pnlContenedorDatosPaciente.CaptionTextColor = System.Drawing.Color.White
        Me.pnlContenedorDatosPaciente.ChevronStyle = XPanderControl.XPander.ChevronStyleEnum.Image
        Me.pnlContenedorDatosPaciente.CollapsedHighlightImage = CType(resources.GetObject("pnlContenedorDatosPaciente.CollapsedHighlightImage"), System.Drawing.Bitmap)
        Me.pnlContenedorDatosPaciente.CollapsedImage = CType(resources.GetObject("pnlContenedorDatosPaciente.CollapsedImage"), System.Drawing.Bitmap)
        Me.pnlContenedorDatosPaciente.ExpandedHighlightImage = CType(resources.GetObject("pnlContenedorDatosPaciente.ExpandedHighlightImage"), System.Drawing.Bitmap)
        Me.pnlContenedorDatosPaciente.ExpandedImage = CType(resources.GetObject("pnlContenedorDatosPaciente.ExpandedImage"), System.Drawing.Bitmap)
        Me.pnlContenedorDatosPaciente.Location = New System.Drawing.Point(3, 3)
        Me.pnlContenedorDatosPaciente.Name = "pnlContenedorDatosPaciente"
        Me.pnlContenedorDatosPaciente.Padding = New System.Windows.Forms.Padding(0, 25, 0, 0)
        Me.pnlContenedorDatosPaciente.PaneBottomRightColor = System.Drawing.Color.White
        Me.pnlContenedorDatosPaciente.Size = New System.Drawing.Size(830, 196)
        Me.pnlContenedorDatosPaciente.TabIndex = 0
        Me.pnlContenedorDatosPaciente.Tag = 1
        Me.pnlContenedorDatosPaciente.TooltipText = Nothing
        '
        'cmdListaEspera
        '
        Me.cmdListaEspera.BackColor = System.Drawing.Color.Ivory
        Me.cmdListaEspera.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdListaEspera.Location = New System.Drawing.Point(103, 12)
        Me.cmdListaEspera.Name = "cmdListaEspera"
        Me.cmdListaEspera.Size = New System.Drawing.Size(83, 23)
        Me.cmdListaEspera.TabIndex = 3
        Me.cmdListaEspera.Text = "Lista Espera"
        Me.cmdListaEspera.UseVisualStyleBackColor = False
        '
        'cmdHistoriaBasica
        '
        Me.cmdHistoriaBasica.BackColor = System.Drawing.Color.Ivory
        Me.cmdHistoriaBasica.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdHistoriaBasica.Location = New System.Drawing.Point(192, 12)
        Me.cmdHistoriaBasica.Name = "cmdHistoriaBasica"
        Me.cmdHistoriaBasica.Size = New System.Drawing.Size(92, 23)
        Me.cmdHistoriaBasica.TabIndex = 4
        Me.cmdHistoriaBasica.Text = "Historia Basica"
        Me.cmdHistoriaBasica.UseVisualStyleBackColor = False
        '
        'pnlContenedorListaEspera
        '
        Me.pnlContenedorListaEspera.Location = New System.Drawing.Point(100, 87)
        Me.pnlContenedorListaEspera.Name = "pnlContenedorListaEspera"
        Me.pnlContenedorListaEspera.Size = New System.Drawing.Size(836, 654)
        Me.pnlContenedorListaEspera.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.Ivory
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(205, 44)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 37)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "Formulación Externa"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Ivory
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(286, 44)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(89, 37)
        Me.Button2.TabIndex = 7
        Me.Button2.Text = "Procedimientos Externos"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.Ivory
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(381, 44)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(88, 37)
        Me.Button3.TabIndex = 8
        Me.Button3.Text = "Incapacidades"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.Ivory
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(475, 44)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(89, 37)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "Remisiones"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.Ivory
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Location = New System.Drawing.Point(570, 44)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(113, 37)
        Me.Button5.TabIndex = 10
        Me.Button5.Text = "Recomendaciones Al Egreso"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.Ivory
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Location = New System.Drawing.Point(290, 12)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(92, 23)
        Me.Button6.TabIndex = 11
        Me.Button6.Text = "Ordenes Médicas"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.Color.Ivory
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Location = New System.Drawing.Point(388, 12)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(92, 23)
        Me.Button7.TabIndex = 12
        Me.Button7.Text = "Evolución"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'Button8
        '
        Me.Button8.BackColor = System.Drawing.Color.Ivory
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Location = New System.Drawing.Point(486, 12)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(92, 23)
        Me.Button8.TabIndex = 13
        Me.Button8.Text = "Egreso"
        Me.Button8.UseVisualStyleBackColor = False
        '
        'Button9
        '
        Me.Button9.BackColor = System.Drawing.Color.Ivory
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Location = New System.Drawing.Point(584, 12)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(92, 23)
        Me.Button9.TabIndex = 14
        Me.Button9.Text = "Consultas"
        Me.Button9.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(100, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "PLAN DE MANEJO"
        '
        'frmPruebasGerman
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1024, 742)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdHistoriaBasica)
        Me.Controls.Add(Me.cmdListaEspera)
        Me.Controls.Add(Me.pnlContenedorPantallas)
        Me.Controls.Add(Me.pnlContenedorListaEspera)
        Me.Name = "frmPruebasGerman"
        Me.Text = "frmPruebasGerman"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlContenedorPantallas.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlContenedorPantallas As XPanderControl.XPanderList
    Friend WithEvents pnlContenedorDatos As XPanderControl.XPander
    Friend WithEvents pnlContenedorDatosPaciente As XPanderControl.XPander
    Friend WithEvents cmdListaEspera As System.Windows.Forms.Button
    Friend WithEvents cmdHistoriaBasica As System.Windows.Forms.Button
    Friend WithEvents pnlContenedorListaEspera As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
