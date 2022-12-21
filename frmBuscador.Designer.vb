Namespace Sophia.HistoriaClinica.Buscador

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmBuscador
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscador))
            Me.dtgBusqueda = New System.Windows.Forms.DataGridView()
            Me.PictureBox1 = New System.Windows.Forms.PictureBox()
            Me.btnCerrar = New System.Windows.Forms.Button()
            Me.GBOpciones = New System.Windows.Forms.GroupBox()
            Me.rb10 = New System.Windows.Forms.RadioButton()
            Me.rb9 = New System.Windows.Forms.RadioButton()
            Me.Rb8 = New System.Windows.Forms.RadioButton()
            Me.rb2 = New System.Windows.Forms.RadioButton()
            Me.rb3 = New System.Windows.Forms.RadioButton()
            Me.rb4 = New System.Windows.Forms.RadioButton()
            Me.rb5 = New System.Windows.Forms.RadioButton()
            Me.rb7 = New System.Windows.Forms.RadioButton()
            Me.rb6 = New System.Windows.Forms.RadioButton()
            Me.rb1 = New System.Windows.Forms.RadioButton()
            CType(Me.dtgBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.GBOpciones.SuspendLayout()
            Me.SuspendLayout()
            '
            'dtgBusqueda
            '
            Me.dtgBusqueda.AllowUserToDeleteRows = False
            Me.dtgBusqueda.AllowUserToOrderColumns = True
            Me.dtgBusqueda.AllowUserToResizeRows = False
            Me.dtgBusqueda.BackgroundColor = System.Drawing.Color.White
            DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
            DataGridViewCellStyle1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
            DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dtgBusqueda.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
            Me.dtgBusqueda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
            DataGridViewCellStyle2.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
            DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
            Me.dtgBusqueda.DefaultCellStyle = DataGridViewCellStyle2
            Me.dtgBusqueda.Location = New System.Drawing.Point(2, 38)
            Me.dtgBusqueda.MultiSelect = False
            Me.dtgBusqueda.Name = "dtgBusqueda"
            DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
            DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(217, Byte), Integer), CType(CType(196, Byte), Integer))
            DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            DataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(210, Byte), Integer))
            DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
            Me.dtgBusqueda.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
            Me.dtgBusqueda.RowHeadersVisible = False
            Me.dtgBusqueda.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.dtgBusqueda.Size = New System.Drawing.Size(710, 306)
            Me.dtgBusqueda.TabIndex = 0
            '
            'PictureBox1
            '
            Me.PictureBox1.ErrorImage = Nothing
            Me.PictureBox1.Image = Global.HistoriaClinica.My.Resources.Resources.header_buscador
            Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
            Me.PictureBox1.Name = "PictureBox1"
            Me.PictureBox1.Size = New System.Drawing.Size(803, 39)
            Me.PictureBox1.TabIndex = 59
            Me.PictureBox1.TabStop = False
            '
            'btnCerrar
            '
            Me.btnCerrar.BackColor = System.Drawing.Color.Silver
            Me.btnCerrar.BackgroundImage = Global.HistoriaClinica.My.Resources.Resources.bot_x
            Me.btnCerrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
            Me.btnCerrar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.btnCerrar.Location = New System.Drawing.Point(688, 0)
            Me.btnCerrar.Name = "btnCerrar"
            Me.btnCerrar.Size = New System.Drawing.Size(24, 20)
            Me.btnCerrar.TabIndex = 60
            Me.btnCerrar.UseVisualStyleBackColor = False
            '
            'GBOpciones
            '
            Me.GBOpciones.BackColor = System.Drawing.Color.Silver
            Me.GBOpciones.Controls.Add(Me.rb10)
            Me.GBOpciones.Controls.Add(Me.rb9)
            Me.GBOpciones.Controls.Add(Me.Rb8)
            Me.GBOpciones.Controls.Add(Me.rb2)
            Me.GBOpciones.Controls.Add(Me.rb3)
            Me.GBOpciones.Controls.Add(Me.rb4)
            Me.GBOpciones.Controls.Add(Me.rb5)
            Me.GBOpciones.Controls.Add(Me.rb7)
            Me.GBOpciones.Controls.Add(Me.rb6)
            Me.GBOpciones.Controls.Add(Me.rb1)
            Me.GBOpciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.GBOpciones.ForeColor = System.Drawing.Color.Black
            Me.GBOpciones.Location = New System.Drawing.Point(2, 348)
            Me.GBOpciones.Name = "GBOpciones"
            Me.GBOpciones.Size = New System.Drawing.Size(710, 88)
            Me.GBOpciones.TabIndex = 61
            Me.GBOpciones.TabStop = False
            Me.GBOpciones.Text = "Filtrar Por :"
            Me.GBOpciones.Visible = False
            '
            'rb10
            '
            Me.rb10.AutoSize = True
            Me.rb10.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
            Me.rb10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.rb10.Location = New System.Drawing.Point(25, 70)
            Me.rb10.Name = "rb10"
            Me.rb10.Size = New System.Drawing.Size(102, 18)
            Me.rb10.TabIndex = 10
            Me.rb10.TabStop = True
            Me.rb10.Text = "Laboratorio"
            Me.rb10.UseVisualStyleBackColor = True
            '
            'rb9
            '
            Me.rb9.AutoSize = True
            Me.rb9.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
            Me.rb9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.rb9.Location = New System.Drawing.Point(599, 49)
            Me.rb9.Name = "rb9"
            Me.rb9.Size = New System.Drawing.Size(94, 18)
            Me.rb9.TabIndex = 9
            Me.rb9.TabStop = True
            Me.rb9.Text = "Radiologia"
            Me.rb9.UseVisualStyleBackColor = True
            '
            'Rb8
            '
            Me.Rb8.AutoSize = True
            Me.Rb8.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
            Me.Rb8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.Rb8.Location = New System.Drawing.Point(569, 64)
            Me.Rb8.Name = "Rb8"
            Me.Rb8.Size = New System.Drawing.Size(64, 18)
            Me.Rb8.TabIndex = 8
            Me.Rb8.TabStop = True
            Me.Rb8.Text = "Todas"
            Me.Rb8.UseVisualStyleBackColor = True
            Me.Rb8.Visible = False
            '
            'rb2
            '
            Me.rb2.AutoSize = True
            Me.rb2.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
            Me.rb2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.rb2.Location = New System.Drawing.Point(163, 24)
            Me.rb2.Name = "rb2"
            Me.rb2.Size = New System.Drawing.Size(155, 18)
            Me.rb2.TabIndex = 7
            Me.rb2.TabStop = True
            Me.rb2.Text = "Tratamiento Medico"
            Me.rb2.UseVisualStyleBackColor = True
            '
            'rb3
            '
            Me.rb3.AutoSize = True
            Me.rb3.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
            Me.rb3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.rb3.Location = New System.Drawing.Point(318, 24)
            Me.rb3.Name = "rb3"
            Me.rb3.Size = New System.Drawing.Size(208, 18)
            Me.rb3.TabIndex = 6
            Me.rb3.TabStop = True
            Me.rb3.Text = "Procedimientos Quirurgicos"
            Me.rb3.UseVisualStyleBackColor = True
            '
            'rb4
            '
            Me.rb4.AutoSize = True
            Me.rb4.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
            Me.rb4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.rb4.Location = New System.Drawing.Point(532, 24)
            Me.rb4.Name = "rb4"
            Me.rb4.Size = New System.Drawing.Size(147, 18)
            Me.rb4.TabIndex = 5
            Me.rb4.TabStop = True
            Me.rb4.Text = "Apoyo Diagnostico"
            Me.rb4.UseVisualStyleBackColor = True
            '
            'rb5
            '
            Me.rb5.AutoSize = True
            Me.rb5.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
            Me.rb5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.rb5.Location = New System.Drawing.Point(25, 49)
            Me.rb5.Name = "rb5"
            Me.rb5.Size = New System.Drawing.Size(148, 18)
            Me.rb5.TabIndex = 4
            Me.rb5.TabStop = True
            Me.rb5.Text = "Apoyo Terapeutico"
            Me.rb5.UseVisualStyleBackColor = True
            '
            'rb7
            '
            Me.rb7.AutoSize = True
            Me.rb7.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
            Me.rb7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.rb7.Location = New System.Drawing.Point(411, 49)
            Me.rb7.Name = "rb7"
            Me.rb7.Size = New System.Drawing.Size(179, 18)
            Me.rb7.TabIndex = 3
            Me.rb7.TabStop = True
            Me.rb7.Text = "Ayudantias Quirurgicas"
            Me.rb7.UseVisualStyleBackColor = True
            '
            'rb6
            '
            Me.rb6.AutoSize = True
            Me.rb6.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
            Me.rb6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.rb6.Location = New System.Drawing.Point(179, 49)
            Me.rb6.Name = "rb6"
            Me.rb6.Size = New System.Drawing.Size(226, 18)
            Me.rb6.TabIndex = 1
            Me.rb6.TabStop = True
            Me.rb6.Text = "Servicios Clinicas y Hospitales"
            Me.rb6.UseVisualStyleBackColor = True
            '
            'rb1
            '
            Me.rb1.AutoSize = True
            Me.rb1.Font = New System.Drawing.Font("Verdana", 9.0!, System.Drawing.FontStyle.Bold)
            Me.rb1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(18, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(154, Byte), Integer))
            Me.rb1.Location = New System.Drawing.Point(25, 24)
            Me.rb1.Name = "rb1"
            Me.rb1.Size = New System.Drawing.Size(132, 18)
            Me.rb1.TabIndex = 0
            Me.rb1.TabStop = True
            Me.rb1.Text = "Consulta Medica"
            Me.rb1.UseVisualStyleBackColor = True
            '
            'frmBuscador
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.ClientSize = New System.Drawing.Size(714, 440)
            Me.Controls.Add(Me.GBOpciones)
            Me.Controls.Add(Me.btnCerrar)
            Me.Controls.Add(Me.PictureBox1)
            Me.Controls.Add(Me.dtgBusqueda)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "frmBuscador"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Buscador"
            CType(Me.dtgBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.GBOpciones.ResumeLayout(False)
            Me.GBOpciones.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents dtgBusqueda As System.Windows.Forms.DataGridView
        Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
        Friend WithEvents btnCerrar As System.Windows.Forms.Button
        Friend WithEvents GBOpciones As System.Windows.Forms.GroupBox
        Friend WithEvents rb1 As System.Windows.Forms.RadioButton
        Friend WithEvents rb2 As System.Windows.Forms.RadioButton
        Friend WithEvents rb3 As System.Windows.Forms.RadioButton
        Friend WithEvents rb4 As System.Windows.Forms.RadioButton
        Friend WithEvents rb5 As System.Windows.Forms.RadioButton
        Friend WithEvents rb7 As System.Windows.Forms.RadioButton
        Friend WithEvents rb6 As System.Windows.Forms.RadioButton
        Friend WithEvents Rb8 As System.Windows.Forms.RadioButton
        Friend WithEvents rb9 As System.Windows.Forms.RadioButton
        Friend WithEvents rb10 As System.Windows.Forms.RadioButton
    End Class
End Namespace


