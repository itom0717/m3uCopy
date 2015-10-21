<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
  Inherits System.Windows.Forms.Form

  'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
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

  'Windows フォーム デザイナーで必要です。
  Private components As System.ComponentModel.IContainer

  'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
  'Windows フォーム デザイナーを使用して変更できます。  
  'コード エディターを使って変更しないでください。
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
    Me.components = New System.ComponentModel.Container()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
    Me.Label1 = New System.Windows.Forms.Label()
    Me.FolderBrowserDialog = New System.Windows.Forms.FolderBrowserDialog()
    Me.SavePathTextBox = New System.Windows.Forms.TextBox()
    Me.Label2 = New System.Windows.Forms.Label()
    Me.FileNameTextBox = New System.Windows.Forms.TextBox()
    Me.TagIDContextMenuStrip = New System.Windows.Forms.ContextMenuStrip(Me.components)
    Me.FilePathButton = New System.Windows.Forms.Button()
    Me.ResultListBox = New System.Windows.Forms.ListBox()
    Me.CopyBackgroundWorker = New System.ComponentModel.BackgroundWorker()
    Me.StopButton = New System.Windows.Forms.Button()
    Me.CloseButton = New System.Windows.Forms.Button()
    Me.SuspendLayout()
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(12, 15)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(47, 12)
    Me.Label1.TabIndex = 0
    Me.Label1.Text = "保存先："
    '
    'FolderBrowserDialog
    '
    Me.FolderBrowserDialog.Description = "保存先の指定"
    '
    'SavePathTextBox
    '
    Me.SavePathTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.SavePathTextBox.BackColor = System.Drawing.SystemColors.Window
    Me.SavePathTextBox.Location = New System.Drawing.Point(75, 12)
    Me.SavePathTextBox.Name = "SavePathTextBox"
    Me.SavePathTextBox.ReadOnly = True
    Me.SavePathTextBox.Size = New System.Drawing.Size(243, 19)
    Me.SavePathTextBox.TabIndex = 1
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(12, 45)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(57, 12)
    Me.Label2.TabIndex = 3
    Me.Label2.Text = "ファイル名："
    '
    'FileNameTextBox
    '
    Me.FileNameTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.FileNameTextBox.ContextMenuStrip = Me.TagIDContextMenuStrip
    Me.FileNameTextBox.Location = New System.Drawing.Point(75, 42)
    Me.FileNameTextBox.Name = "FileNameTextBox"
    Me.FileNameTextBox.Size = New System.Drawing.Size(243, 19)
    Me.FileNameTextBox.TabIndex = 4
    '
    'TagIDContextMenuStrip
    '
    Me.TagIDContextMenuStrip.Name = "ContextMenuStrip1"
    Me.TagIDContextMenuStrip.Size = New System.Drawing.Size(61, 4)
    '
    'FilePathButton
    '
    Me.FilePathButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.FilePathButton.Location = New System.Drawing.Point(324, 10)
    Me.FilePathButton.Name = "FilePathButton"
    Me.FilePathButton.Size = New System.Drawing.Size(27, 23)
    Me.FilePathButton.TabIndex = 2
    Me.FilePathButton.Text = "..."
    Me.FilePathButton.UseVisualStyleBackColor = True
    '
    'ResultListBox
    '
    Me.ResultListBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.ResultListBox.FormattingEnabled = True
    Me.ResultListBox.ItemHeight = 12
    Me.ResultListBox.Location = New System.Drawing.Point(13, 70)
    Me.ResultListBox.Name = "ResultListBox"
    Me.ResultListBox.Size = New System.Drawing.Size(351, 112)
    Me.ResultListBox.TabIndex = 5
    '
    'CopyBackgroundWorker
    '
    '
    'StopButton
    '
    Me.StopButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
    Me.StopButton.Location = New System.Drawing.Point(12, 188)
    Me.StopButton.Name = "StopButton"
    Me.StopButton.Size = New System.Drawing.Size(75, 23)
    Me.StopButton.TabIndex = 6
    Me.StopButton.Text = "中止"
    Me.StopButton.UseVisualStyleBackColor = True
    '
    'CloseButton
    '
    Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
    Me.CloseButton.Location = New System.Drawing.Point(289, 188)
    Me.CloseButton.Name = "CloseButton"
    Me.CloseButton.Size = New System.Drawing.Size(75, 23)
    Me.CloseButton.TabIndex = 7
    Me.CloseButton.Text = "閉じる"
    Me.CloseButton.UseVisualStyleBackColor = True
    '
    'MainForm
    '
    Me.AllowDrop = True
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(376, 220)
    Me.Controls.Add(Me.CloseButton)
    Me.Controls.Add(Me.StopButton)
    Me.Controls.Add(Me.ResultListBox)
    Me.Controls.Add(Me.FilePathButton)
    Me.Controls.Add(Me.FileNameTextBox)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.SavePathTextBox)
    Me.Controls.Add(Me.Label1)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.Name = "MainForm"
    Me.Text = "m3uCopy"
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents FolderBrowserDialog As System.Windows.Forms.FolderBrowserDialog
  Friend WithEvents SavePathTextBox As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents FileNameTextBox As System.Windows.Forms.TextBox
  Friend WithEvents FilePathButton As System.Windows.Forms.Button
  Friend WithEvents ResultListBox As System.Windows.Forms.ListBox
  Friend WithEvents TagIDContextMenuStrip As System.Windows.Forms.ContextMenuStrip
  Friend WithEvents CopyBackgroundWorker As System.ComponentModel.BackgroundWorker
  Friend WithEvents StopButton As Button
  Friend WithEvents CloseButton As Button
End Class
