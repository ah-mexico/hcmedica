Namespace Sophia.HistoriaClinica.Buscador

    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmBuscadorEquiva
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBuscadorEquiva))
            Me.dtgBusqueda = New System.Windows.Forms.DataGridView
            Me.PictureBox1 = New System.Windows.Forms.PictureBox
            Me.btnCerrar = New System.Windows.Forms.Button
            CType(Me.dtgBusqueda, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
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
            Me.dtgBusqueda.Size = New System.Drawing.Size(701, 306)
            Me.dtgBusqueda.TabIndex = 0
            '
            'PictureBox1
            '
            Me.PictureBox1.ErrorImage = Nothing
            Me.PictureBox1.Image = Global.HistoriaClinica.My.Resources.Resources.header_buscador
            Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
            Me.PictureBox1.Name = "PictureBox1"
            Me.PictureBox1.Size = New System.Drawing.Size(703, 39)
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
            Me.btnCerrar.Location = New System.Drawing.Point(679, 0)
            Me.btnCerrar.Name = "btnCerrar"
            Me.btnCerrar.Size = New System.Drawing.Size(24, 20)
            Me.btnCerrar.TabIndex = 60
            Me.btnCerrar.UseVisualStyleBackColor = False
            '
            'frmBuscadorEquiva
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.SystemColors.ActiveCaptionText
            Me.ClientSize = New System.Drawing.Size(710, 350)
            Me.Controls.Add(Me.btnCerrar)
            Me.Controls.Add(Me.PictureBox1)
            Me.Controls.Add(Me.dtgBusqueda)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Name = "frmBuscadorEquiva"
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Buscador"
            CType(Me.dtgBusqueda, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents dtgBusqueda As System.Windows.Forms.DataGridView
        Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
        Friend WithEvents btnCerrar As System.Windows.Forms.Button
    End Class
End Namespace


