<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Graficas_Escalas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series
        Dim Title1 As System.Windows.Forms.DataVisualization.Charting.Title = New System.Windows.Forms.DataVisualization.Charting.Title
        Me.GrafEscalas = New System.Windows.Forms.DataVisualization.Charting.Chart
        CType(Me.GrafEscalas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GrafEscalas
        '
        ChartArea1.AxisX.IntervalAutoMode = System.Windows.Forms.DataVisualization.Charting.IntervalAutoMode.VariableCount
        ChartArea1.AxisX.IsLabelAutoFit = False
        ChartArea1.AxisX.LabelAutoFitMaxFontSize = 6
        ChartArea1.AxisX.LabelAutoFitStyle = CType((((((System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.IncreaseFont Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.DecreaseFont) _
                    Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.StaggeredLabels) _
                    Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep30) _
                    Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.LabelsAngleStep45) _
                    Or System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles.WordWrap), System.Windows.Forms.DataVisualization.Charting.LabelAutoFitStyles)
        ChartArea1.AxisX.LabelStyle.Angle = 90
        ChartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro
        ChartArea1.AxisX.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated90
        ChartArea1.AxisX2.LineColor = System.Drawing.Color.WhiteSmoke
        ChartArea1.AxisY.Interval = 1
        ChartArea1.AxisY.LabelAutoFitMaxFontSize = 6
        ChartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro
        ChartArea1.AxisY.Maximum = 11
        ChartArea1.AxisY2.LineColor = System.Drawing.Color.WhiteSmoke
        ChartArea1.BackColor = System.Drawing.Color.Transparent
        ChartArea1.BackImageTransparentColor = System.Drawing.Color.White
        ChartArea1.BackSecondaryColor = System.Drawing.Color.Transparent
        ChartArea1.BorderColor = System.Drawing.Color.Transparent
        ChartArea1.CursorX.SelectionColor = System.Drawing.Color.WhiteSmoke
        ChartArea1.CursorY.SelectionColor = System.Drawing.Color.WhiteSmoke
        ChartArea1.Name = "GrSophia"
        ChartArea1.Position.Auto = False
        ChartArea1.Position.Height = 85.0!
        ChartArea1.Position.Width = 100.0!
        ChartArea1.Position.Y = 15.0!
        ChartArea1.ShadowColor = System.Drawing.Color.WhiteSmoke
        ChartArea2.AxisX.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated90
        ChartArea2.BackColor = System.Drawing.Color.Transparent
        ChartArea2.BackImageTransparentColor = System.Drawing.Color.Transparent
        ChartArea2.BackSecondaryColor = System.Drawing.Color.Transparent
        ChartArea2.BorderColor = System.Drawing.Color.Transparent
        ChartArea2.Name = "GrAvicena"
        ChartArea2.Position.Auto = False
        ChartArea2.Position.Height = 85.0!
        ChartArea2.Position.Width = 100.0!
        ChartArea2.Position.Y = 15.0!
        ChartArea2.ShadowColor = System.Drawing.Color.Transparent
        Me.GrafEscalas.ChartAreas.Add(ChartArea1)
        Me.GrafEscalas.ChartAreas.Add(ChartArea2)
        Legend1.AutoFitMinFontSize = 10
        Legend1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Legend1.ForeColor = System.Drawing.Color.Transparent
        Legend1.IsTextAutoFit = False
        Legend1.Name = "LSophia"
        Legend1.Position.Auto = False
        Legend1.Position.Height = 10.0!
        Legend1.Position.Width = 20.0!
        Legend1.Position.X = 1.0!
        Legend1.Position.Y = 5.0!
        Legend2.Enabled = False
        Legend2.Name = "LAvicena"
        Legend2.Position.Auto = False
        Legend2.Position.Height = 10.0!
        Legend2.Position.Width = 20.0!
        Legend2.Position.X = 15.0!
        Legend2.Position.Y = 5.0!
        Me.GrafEscalas.Legends.Add(Legend1)
        Me.GrafEscalas.Legends.Add(Legend2)
        Me.GrafEscalas.Location = New System.Drawing.Point(12, 12)
        Me.GrafEscalas.Name = "GrafEscalas"
        Me.GrafEscalas.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None
        Series1.BackImageTransparentColor = System.Drawing.Color.Transparent
        Series1.BackSecondaryColor = System.Drawing.Color.Transparent
        Series1.BorderColor = System.Drawing.Color.Transparent
        Series1.ChartArea = "GrSophia"
        Series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series1.Color = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer))
        Series1.EmptyPointStyle.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.TileFlipXY
        Series1.EmptyPointStyle.BorderColor = System.Drawing.Color.Transparent
        Series1.EmptyPointStyle.Color = System.Drawing.Color.Transparent
        Series1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
        Series1.LabelBackColor = System.Drawing.Color.Transparent
        Series1.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Dash
        Series1.LabelForeColor = System.Drawing.Color.Transparent
        Series1.Legend = "LSophia"
        Series1.MarkerColor = System.Drawing.Color.Cyan
        Series1.MarkerImageTransparentColor = System.Drawing.Color.Transparent
        Series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square
        Series1.Name = "Sophia"
        Series1.ShadowColor = System.Drawing.Color.Transparent
        Series1.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.Transparent
        Series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime
        Series1.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Series2.BackImageTransparentColor = System.Drawing.Color.Transparent
        Series2.BackSecondaryColor = System.Drawing.Color.Transparent
        Series2.BorderColor = System.Drawing.Color.Transparent
        Series2.ChartArea = "GrSophia"
        Series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line
        Series2.Color = System.Drawing.Color.Red
        Series2.CustomProperties = "EmptyPointValue=Zero"
        Series2.EmptyPointStyle.BackImageWrapMode = System.Windows.Forms.DataVisualization.Charting.ChartImageWrapMode.TileFlipXY
        Series2.EmptyPointStyle.BorderColor = System.Drawing.Color.Transparent
        Series2.EmptyPointStyle.Color = System.Drawing.Color.Transparent
        Series2.LabelForeColor = System.Drawing.Color.Transparent
        Series2.Legend = "LAvicena"
        Series2.MarkerColor = System.Drawing.Color.Green
        Series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Square
        Series2.Name = "Avicena"
        Series2.ShadowColor = System.Drawing.Color.Transparent
        Series2.SmartLabelStyle.CalloutLineColor = System.Drawing.Color.Transparent
        Series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime
        Series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32
        Me.GrafEscalas.Series.Add(Series1)
        Me.GrafEscalas.Series.Add(Series2)
        Me.GrafEscalas.Size = New System.Drawing.Size(707, 535)
        Me.GrafEscalas.TabIndex = 0
        Me.GrafEscalas.Text = "Graficas Escalas"
        Title1.Alignment = System.Drawing.ContentAlignment.TopCenter
        Title1.DockedToChartArea = "GrSophia"
        Title1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold)
        Title1.Name = "TituloEscala"
        Title1.Position.Auto = False
        Title1.Position.Height = 3.962664!
        Title1.Position.Width = 90.42355!
        Title1.Position.X = 6.348634!
        Title1.Position.Y = 1.5!
        Title1.Text = "ESCALA"
        Title1.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Horizontal
        Me.GrafEscalas.Titles.Add(Title1)
        '
        'Graficas_Escalas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(728, 559)
        Me.Controls.Add(Me.GrafEscalas)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Graficas_Escalas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Grafica"
        CType(Me.GrafEscalas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GrafEscalas As System.Windows.Forms.DataVisualization.Charting.Chart
End Class
