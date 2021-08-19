<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.RadioButton_Address = New System.Windows.Forms.RadioButton()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox_OutputFRM2 = New System.Windows.Forms.RadioButton()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(404, 60)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Select Vocaloid DDB File"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 78)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(404, 60)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Select Output Path"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 144)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(404, 60)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Start Extraction"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'RadioButton_Address
        '
        Me.RadioButton_Address.AutoSize = True
        Me.RadioButton_Address.Location = New System.Drawing.Point(12, 237)
        Me.RadioButton_Address.Name = "RadioButton_Address"
        Me.RadioButton_Address.Size = New System.Drawing.Size(130, 21)
        Me.RadioButton_Address.TabIndex = 3
        Me.RadioButton_Address.TabStop = True
        Me.RadioButton_Address.Text = "Name as Address"
        Me.RadioButton_Address.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(12, 210)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(183, 21)
        Me.CheckBox1.TabIndex = 4
        Me.CheckBox1.Text = "Output FRA2 (Include ENV)"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox_OutputFRM2
        '
        Me.CheckBox_OutputFRM2.AutoSize = True
        Me.CheckBox_OutputFRM2.Location = New System.Drawing.Point(148, 237)
        Me.CheckBox_OutputFRM2.Name = "CheckBox_OutputFRM2"
        Me.CheckBox_OutputFRM2.Size = New System.Drawing.Size(130, 21)
        Me.CheckBox_OutputFRM2.TabIndex = 5
        Me.CheckBox_OutputFRM2.TabStop = True
        Me.CheckBox_OutputFRM2.Text = "Name as Number"
        Me.CheckBox_OutputFRM2.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 264)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(404, 23)
        Me.ProgressBar1.TabIndex = 6
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(428, 296)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.CheckBox_OutputFRM2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.RadioButton_Address)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.Text = "VDB Extractor - Compliled By Krunk"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents RadioButton_Address As RadioButton
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents CheckBox_OutputFRM2 As RadioButton
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
