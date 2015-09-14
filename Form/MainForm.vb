Imports System.ComponentModel

Public Class MainForm





  ''' <summary>
  ''' フォームLoadイベント
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load

    '設定の読み込み
    Me.SavePathTextBox.Text = My.Settings.SavePath
    Me.FileNameTextBox.Text = Trim(My.Settings.FileName)

    If Me.FileNameTextBox.Text.Trim.Equals("") Then
      Me.FileNameTextBox.Text = ID3Tag.DefaultFilename
    End If

    '右クリックメニュー登録
    Me.TagIDContextMenuStrip.Items.Add(ID3Tag.ID3TagDetailsNo,
                                    Nothing, AddressOf Me.ContextMenuStrip_Click)
    Me.TagIDContextMenuStrip.Items.Add(ID3Tag.ID3TagDetailsTitle,
                                    Nothing, AddressOf Me.ContextMenuStrip_Click)
    Me.TagIDContextMenuStrip.Items.Add(ID3Tag.ID3TagDetailsParticipatingArtists,
                                    Nothing, AddressOf Me.ContextMenuStrip_Click)
    Me.TagIDContextMenuStrip.Items.Add(ID3Tag.ID3TagDetailsAlbum,
                                    Nothing, AddressOf Me.ContextMenuStrip_Click)
    Me.TagIDContextMenuStrip.Items.Add(ID3Tag.ID3TagDetailsAlbumOfArtist,
                                    Nothing, AddressOf Me.ContextMenuStrip_Click)
    Me.TagIDContextMenuStrip.Items.Add(ID3Tag.ID3TagDetailsYear,
                                    Nothing, AddressOf Me.ContextMenuStrip_Click)
    Me.TagIDContextMenuStrip.Items.Add(ID3Tag.ID3TagDetailsGenre,
                                    Nothing, AddressOf Me.ContextMenuStrip_Click)


    'ボタン類を有効にする
    Me.EnableButtons(True)

  End Sub

  ''' <summary>
  ''' 選択項目設定
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub ContextMenuStrip_Click(sender As System.Object, e As System.EventArgs)
    Dim menu As ToolStripMenuItem = CType(sender, ToolStripMenuItem)
    Me.FileNameTextBox.SelectedText = "<" & menu.Text & ">"
  End Sub

  ''' <summary>
  ''' フォームを閉じたとき
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
    '設定の保存
    My.Settings.SavePath = Me.SavePathTextBox.Text
    My.Settings.FileName = Me.FileNameTextBox.Text
  End Sub


  ''' <summary>
  ''' フォルダ選択ダイアログ
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub FilePathButton_Click(sender As Object, e As EventArgs) Handles FilePathButton.Click

    Dim savePath As String = Me.SavePathTextBox.Text
    If Common.File.ExistsDirectory(savePath) Then
      Me.FolderBrowserDialog.SelectedPath = savePath
    End If

    'フォルダ選択
    If Me.FolderBrowserDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
      Me.SavePathTextBox.Text = Me.FolderBrowserDialog.SelectedPath
    End If

  End Sub

  ''' <summary>
  ''' FileNameTextBox_TextChanged
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub FileNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles FileNameTextBox.TextChanged

    '空欄は初期値とする
    If Me.FileNameTextBox.Text.Trim.Equals("") Then
      Me.FileNameTextBox.Text = ID3Tag.DefaultFilename
    End If

  End Sub

  ''' <summary>
  ''' 閉じるボタン
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
    Me.Close()
  End Sub

  ''' <summary>
  ''' DragEnter
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub MainForm_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter

    'ドラッグされたとき実行される
    If e.Data.GetDataPresent(DataFormats.FileDrop) Then
      'ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
      e.Effect = DragDropEffects.Copy
    Else
      'ファイル以外は受け付けない
      e.Effect = DragDropEffects.None
    End If

  End Sub

  ''' <summary>
  ''' ドロップされたファイル一覧
  ''' </summary>
  Private DropFileName As String()

  ''' <summary>
  ''' 保存パス
  ''' </summary>
  Private SavePath As String = ""

  ''' <summary>
  ''' 新しいファイル名パターン
  ''' </summary>
  Private NewFileNamePattern As String = ""


  ''' <summary>
  ''' DragDrop
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  ''' <remarks></remarks>
  Private Sub MainForm_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop

    '保存先フォルダを作成
    Me.SavePath = Common.File.AddDirectorySeparator(SavePathTextBox.Text)

    If Trim(Me.SavePath) = "" Then
      MessageBox.Show("保存先フォルダの指定がありませんので処理を中止します。",
                        My.Application.Info.AssemblyName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
      Exit Sub
    End If

    If Not Common.File.ExistsDirectory(Me.SavePath) Then
      MessageBox.Show("保存先フォルダが見つかりませんので処理を中止します。",
                        My.Application.Info.AssemblyName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
      Exit Sub
    End If

#If DEBUG Then
#Else
    If Not Common.File.IsEmptyDirectory(Me.SavePath) Then
      MessageBox.Show("保存先フォルダが空ではありませんので処理を中止します。",
                        My.Application.Info.AssemblyName,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
      Exit Sub
    End If
#End If


    'ドロップされたファイル一覧のファイル名を配列に入れる
    Me.DropFileName = CType(e.Data.GetData(DataFormats.FileDrop, False), String())

    ' 新しいファイル名パターン
    Me.NewFileNamePattern = Me.FileNameTextBox.Text.Trim()
    If Me.NewFileNamePattern.Equals("") Then
      Me.NewFileNamePattern = ID3Tag.DefaultFilename
    End If


    Me.ResultListBox.Items.Clear()

    'ボタン類を無効にする
    Me.EnableButtons(False)

    'バックグラウンド処理を開始する
    Me.CopyBackgroundWorker.WorkerSupportsCancellation = True
    Me.CopyBackgroundWorker.RunWorkerAsync()

  End Sub

  ''' <summary>
  ''' ログテキスト表示
  ''' </summary>
  ''' <param name="text"></param>
  Private Sub AddLogText(Optional text As String = "")
    Me.ResultListBox.Items.Add(text)
    Me.ResultListBox.SelectedIndex = Me.ResultListBox.Items.Count - 1
  End Sub

  ''' <summary>
  ''' ボタン類のDisable/Enable切り替え
  ''' </summary>
  Private Sub EnableButtons(isEnable As Boolean)
    '各ボタンの操作を無効にする
    Me.FilePathButton.Enabled = isEnable
    Me.FileNameTextBox.Enabled = isEnable
    Me.SavePathTextBox.Enabled = isEnable
    Me.CloseButton.Enabled = isEnable
    Me.StopButton.Enabled = Not isEnable

    Me.AllowDrop = isEnable
  End Sub

  ''' <summary>
  ''' MainForm_FormClosing
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing

    If Me.CopyBackgroundWorker.IsBusy Then
      e.Cancel = Not Me.StopCopy()
    End If

  End Sub

  ''' <summary>
  ''' 中止ボタン
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub StopButton_Click(sender As Object, e As EventArgs) Handles StopButton.Click
    If Me.CopyBackgroundWorker.IsBusy Then
      Me.StopCopy()
    End If
  End Sub

  ''' <summary>
  ''' 中止処理
  ''' </summary>
  ''' <return>中止したらTrueを返す</return>
  Private Function StopCopy() As Boolean

    If MessageBox.Show("中止しますか？",
                         My.Application.Info.AssemblyName,
                         MessageBoxButtons.OKCancel,
                         MessageBoxIcon.Question) <> DialogResult.OK Then

      Return False
    End If

    'キャンセル
    If Me.CopyBackgroundWorker.IsBusy Then
      Me.CopyBackgroundWorker.CancelAsync()
    End If

    Return True
  End Function

  ''' <summary>
  ''' バックグラウンド処理完了時の処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub CopyBackgroundWorker_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles CopyBackgroundWorker.RunWorkerCompleted

    If Not (e.Error Is Nothing) Then
      Me.AddLogText()
      Me.AddLogText(e.Error.Message)
      Me.AddLogText()
    ElseIf e.Cancelled Then
      'キャンセルされた
      Me.AddLogText()
      Me.AddLogText("処理がキャンセルされました。")
      Me.AddLogText()
    Else
      '正常終了
    End If

    'ボタン類を有効にする
    Me.EnableButtons(True)
  End Sub


  ''' <summary>
  ''' Copy処理
  ''' </summary>
  ''' <param name="sender"></param>
  ''' <param name="e"></param>
  Private Sub CopyBackgroundWorker_DoWork(sender As Object, e As DoWorkEventArgs) Handles CopyBackgroundWorker.DoWork

    Try
      Dim addLog As New Action(Of String)(AddressOf AddLogText)
      Dim totalFileCount As Integer = 0

      Me.Invoke(addLog, "■■■処理開始■■■")
      Me.Invoke(addLog, "")

      'ドロップファイル数分ループ
      For Each m3uFile As String In Me.DropFileName

        Me.Invoke(addLog, "処理ファイル：" & Common.File.GetFileName(m3uFile))
        Me.Invoke(addLog, "")

        If Not Common.File.GetExtension(m3uFile).Equals("M3U", StringComparison.CurrentCultureIgnoreCase) Then
          '拡張子がm3u以外は処理しない
          Me.Invoke(addLog, "Error:未対応のファイルです。")
          Me.Invoke(addLog, "")
          Return
        End If

        'ファイルオープンして、データを取得する
        Dim mp3List As New List(Of String)
        Try
          Using sr As New System.IO.StreamReader(m3uFile, System.Text.Encoding.GetEncoding("UTF-8"))
            While (sr.Peek() >= 0)
              Dim line As String = sr.ReadLine()
              If Not line.Trim.Equals("") Then
                mp3List.Add(line)
              End If
            End While
          End Using
        Catch ex As Exception
          Me.Invoke(addLog, "Error:m3uファイルをオープンできません。")
          Me.Invoke(addLog, "")
          Return
        End Try

        '拡張子無しのベース
        Dim m3uBase As String = Common.File.GetWithoutExtension(Common.File.GetFileName(m3uFile))

        '保存先
        Dim newPath As String = Me.SavePath & Common.File.AddDirectorySeparator(m3uBase)

        'コピー先のフォルダを作成
        If System.Text.RegularExpressions.Regex.IsMatch(m3uBase, "^\d\d_") Then
          '先頭に数値_ がある場合は、サブフォルダを作成する
          Dim subDir As String = m3uBase.Substring(3)
          newPath &= Common.File.AddDirectorySeparator(subDir)
        End If
        If Not Common.File.ExistsDirectory(newPath) Then
          Common.File.CreateDirectory(newPath)
        End If


        'ファイルをコピーする
        Dim fileCount As Integer = 1
        For Each srcFile As String In mp3List
          '処理中にキャンセルされていないかを定期的にチェックする
          If Me.CopyBackgroundWorker.CancellationPending Then
            e.Cancel = True
            Return
          End If

          'コピー先のファイル名生成
          Dim dstFile As String
          Try
            dstFile = newPath & Me.CreateNewFileName(fileCount, mp3List.Count, srcFile)
          Catch ex As Exception
            Me.Invoke(addLog, ex.Message)
            Me.Invoke(addLog, "")
            Return
          End Try


          Me.Invoke(addLog, "  Copy：" & Common.File.GetFileName(srcFile) & " → " & Common.File.GetFileName(dstFile))

          If Not Common.File.ExistsFile(srcFile) Then
            Me.Invoke(addLog, "Error:ファイルが存在しないので処理を中止します。")
            Me.Invoke(addLog, "")
            Return
          End If


#If DEBUG Then
#Else
          If Common.File.ExistsFile(dstFile) Then
            Me.Invoke(addLog, "Error:すでに同名のファイルが存在しますので処理をを中止します。")
            Me.Invoke(addLog, "")
            Return
          End If
#End If

          'ファイルコピー
          Try
            Common.File.CopyFile(srcFile, dstFile, True)
          Catch ex As Exception
            Me.Invoke(addLog, "Error:ファイルのコピーに失敗しましたので処理を中止します。")
            Me.Invoke(addLog, "")
            Return
          End Try

          fileCount += 1
        Next

        totalFileCount += fileCount
        Me.Invoke(addLog, "")
      Next

      Me.Invoke(addLog, "合計:" & totalFileCount & "ファイル")
      Me.Invoke(addLog, "■■■処理終了■■■")

    Catch ex As Exception
      Throw
    End Try
  End Sub



  ''' <summary>
  ''' ファイル名を生成
  ''' </summary>
  ''' <param name="index"></param>
  ''' <param name="srcFile"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Function CreateNewFileName(index As Integer, maxNum As Integer, srcFile As String) As String

    'Dim srcBaseFilename As String = Common.File.GetFileName(srcFile)
    'Dim dstBaseFilename As String = srcBaseFilename


    'ID3タグ情報取得
    Dim tagInfo As Common.HashtableEx
    Try
      tagInfo = ID3Tag.GetID3TagInfo(srcFile)
    Catch ex As Exception
      Throw New Exception("Error:ID3タグの取得ができないので処理を中止します。")
    End Try

    'Noを生成
    Dim no As String = ""
    If maxNum < 100 Then
      no = Format(index, "00")
    Else
      no = Format(index, "".PadRight(maxNum.ToString("D").Length, "0"c))
    End If
    tagInfo.Add(ID3Tag.ID3TagDetailsNo, no)



    Dim dstBaseFilename As String = Me.NewFileNamePattern
    For Each key As String In tagInfo.Keys
      dstBaseFilename = dstBaseFilename.Replace("<" & key & ">", tagInfo(key))
    Next


    '新しいファイル名を返す
    Return ChangeInvalidFileNameChars(dstBaseFilename) & "." & Common.File.GetExtension(srcFile)
  End Function


  ''' <summary>
  ''' ファイル名に使用不可の文字を変更
  ''' </summary>
  ''' <param name="fileName"></param>
  ''' <returns></returns>
  ''' <remarks></remarks>
  Private Function ChangeInvalidFileNameChars(ByVal fileName As String) As String

    Try
      For Each invalidChar As Char In System.IO.Path.GetInvalidFileNameChars
        fileName = fileName.Replace(invalidChar, "_")
      Next
    Catch ex As Exception
    End Try

    Return fileName
  End Function



End Class
