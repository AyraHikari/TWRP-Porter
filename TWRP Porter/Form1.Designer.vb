<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.basenya = New System.Windows.Forms.TextBox()
        Me.targetnya = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.WillRemove = New System.Windows.Forms.CheckBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(384, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(88, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Browse base"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'basenya
        '
        Me.basenya.Location = New System.Drawing.Point(13, 15)
        Me.basenya.Name = "basenya"
        Me.basenya.ReadOnly = True
        Me.basenya.Size = New System.Drawing.Size(365, 20)
        Me.basenya.TabIndex = 1
        Me.basenya.Text = "Browse base TWRP from your device"
        '
        'targetnya
        '
        Me.targetnya.Location = New System.Drawing.Point(13, 55)
        Me.targetnya.Name = "targetnya"
        Me.targetnya.ReadOnly = True
        Me.targetnya.Size = New System.Drawing.Size(365, 20)
        Me.targetnya.TabIndex = 2
        Me.targetnya.Text = "Browse target TWRP you want port"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(385, 53)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(87, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Browse target"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(189, 98)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(99, 53)
        Me.Button3.TabIndex = 4
        Me.Button3.Text = "Auto Port"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(13, 157)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(458, 76)
        Me.RichTextBox1.TabIndex = 5
        Me.RichTextBox1.Text = "Ready!"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(71, 98)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(112, 23)
        Me.Button4.TabIndex = 6
        Me.Button4.Text = "Extract base"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(294, 98)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(121, 23)
        Me.Button5.TabIndex = 7
        Me.Button5.Text = "Extract target"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(71, 128)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(112, 23)
        Me.Button6.TabIndex = 8
        Me.Button6.Text = "Build base"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(295, 127)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(120, 23)
        Me.Button7.TabIndex = 9
        Me.Button7.Text = "Build target"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(399, 486)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(73, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "By Ayra Hikari"
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(13, 98)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(52, 52)
        Me.Button8.TabIndex = 11
        Me.Button8.Text = "Delete base"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(421, 98)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(51, 52)
        Me.Button9.TabIndex = 12
        Me.Button9.Text = "Delete target"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'RichTextBox2
        '
        Me.RichTextBox2.Location = New System.Drawing.Point(12, 269)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.ReadOnly = True
        Me.RichTextBox2.Size = New System.Drawing.Size(459, 207)
        Me.RichTextBox2.TabIndex = 13
        Me.RichTextBox2.Text = resources.GetString("RichTextBox2.Text")
        '
        'WillRemove
        '
        Me.WillRemove.AutoSize = True
        Me.WillRemove.Location = New System.Drawing.Point(12, 482)
        Me.WillRemove.Name = "WillRemove"
        Me.WillRemove.Size = New System.Drawing.Size(228, 17)
        Me.WillRemove.TabIndex = 14
        Me.WillRemove.Text = "Remove folder base/target instead rename"
        Me.WillRemove.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(13, 240)
        Me.ProgressBar1.MarqueeAnimationSpeed = 20
        Me.ProgressBar1.Maximum = 10
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(458, 23)
        Me.ProgressBar1.Step = 2
        Me.ProgressBar1.TabIndex = 15
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(484, 511)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.WillRemove)
        Me.Controls.Add(Me.RichTextBox2)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.targetnya)
        Me.Controls.Add(Me.basenya)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "TWRP Porter for Qualcomm devices v1.1.2"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents basenya As TextBox
    Friend WithEvents targetnya As TextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents WillRemove As CheckBox
    Friend WithEvents ProgressBar1 As ProgressBar
End Class
