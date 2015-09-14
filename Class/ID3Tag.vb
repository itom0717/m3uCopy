Imports System

Public Class ID3Tag

  ''' <summary>
  ''' No
  ''' </summary>
  Public Const ID3TagDetailsNo As String = "No"

  ''' <summary>
  ''' タイトル
  ''' </summary>
  Public Const ID3TagDetailsTitle As String = "タイトル"

  ''' <summary>
  ''' アルバム
  ''' </summary>
  Public Const ID3TagDetailsAlbum As String = "アルバム"

  ''' <summary>
  ''' 参加アーティスト
  ''' </summary>
  Public Const ID3TagDetailsParticipatingArtists As String = "参加アーティスト"

  ''' <summary>
  ''' アルバムのアーティスト
  ''' </summary>
  Public Const ID3TagDetailsAlbumOfArtist As String = "アルバムのアーティスト"

  ''' <summary>
  ''' 年
  ''' </summary>
  Public Const ID3TagDetailsYear As String = "年"

  ''' <summary>
  ''' ジャンル
  ''' </summary>
  Public Const ID3TagDetailsGenre As String = "ジャンル"


  ''' <summary>
  ''' 初期値
  ''' </summary>
  Public Const DefaultFilename As String = "<" & ID3TagDetailsNo & "> - <" & ID3TagDetailsTitle & ">"




  ''' <summary>
  ''' GetShell32NameSpace
  ''' </summary>
  ''' <param name="folder"></param>
  ''' <returns>
  ''' 参考
  ''' http://techitongue.blogspot.jp/2012/06/shell32-code-compiled-on-windows-7.html
  ''' </returns>
  Public Shared Function GetShell32NameSpace(folder As Object) As Shell32.Folder
    Dim shellAppType As Type = Type.GetTypeFromProgID("Shell.Application")
    Dim Shell As Object = Activator.CreateInstance(shellAppType)
    Return shellAppType.InvokeMember("NameSpace", System.Reflection.BindingFlags.InvokeMethod, Nothing, Shell, New Object() {folder})
  End Function


  ''' <summary>
  ''' ID3タグ情報を取得する
  ''' </summary>
  ''' <returns></returns>
  ''' <remarks>
  ''' 参考
  ''' http://www.atmarkit.co.jp/fdotnet/dotnettips/591mp3tags/mp3tags.html
  ''' </remarks>
  Public Shared Function GetID3TagInfo(mp3FileName As String) As Common.HashtableEx
    Try


      Dim tagInfo As New Common.HashtableEx

      Dim dir As String = Common.File.GetDirectoryName(mp3FileName)
      Dim file As String = Common.File.GetFileName(mp3FileName)

      Dim shell As New Shell32.ShellClass()
      Dim f As Shell32.Folder = GetShell32NameSpace(dir)
      Dim item As Shell32.FolderItem = f.ParseName(file)


      Dim value As String
      For i As Integer = 0 To 100 '適当な大きな値
        Dim name As String = f.GetDetailsOf(Nothing, i)
        If Not String.IsNullOrEmpty(name) Then

          value = f.GetDetailsOf(item, i)
          Select Case name
            Case ID3TagDetailsTitle 'タイトル'
              value = f.GetDetailsOf(item, i)

              If value = "" Then
                value = Common.File.GetWithoutExtension(Common.File.GetFileName(mp3FileName))
              End If

              tagInfo.Add(name, value)

            Case ID3TagDetailsParticipatingArtists '参加アーティスト
              value = f.GetDetailsOf(item, i)
              tagInfo.Add(name, value)

            Case ID3TagDetailsAlbum 'アルバム
              value = f.GetDetailsOf(item, i)
              tagInfo.Add(name, value)

            Case ID3TagDetailsAlbumOfArtist 'アルバムのアーティスト
              value = f.GetDetailsOf(item, i)
              tagInfo.Add(name, value)

            Case ID3TagDetailsYear '年
              value = f.GetDetailsOf(item, i)
              tagInfo.Add(name, value)

            Case ID3TagDetailsGenre 'ジャンル
              value = f.GetDetailsOf(item, i)
              tagInfo.Add(name, value)


          End Select
        End If
      Next


      Return tagInfo

    Catch ex As Exception
      Throw
    End Try

  End Function


End Class
