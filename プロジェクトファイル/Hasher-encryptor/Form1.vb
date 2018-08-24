Public Class Form1
    Dim executePath As String
    Private Sub TextBox1_DragEnter(sender As Object, e As DragEventArgs) Handles TextBox1.DragEnter
        'ドラッグ処理、ファイルのみ受け付ける
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub TextBox1_DragDrop(sender As Object, e As DragEventArgs) Handles TextBox1.DragDrop
        executePath = e.Data.GetData(DataFormats.FileDrop)(0)
        TextBox1.Text = executePath
        buttonenable(True)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.Text = executePath
    End Sub
    Public Sub buttonenable(ByVal change As Boolean)
        Select Case change
            Case True
                GroupBox2.Enabled = True
            Case False
                GroupBox2.Enabled = False
        End Select
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        buttonenable(False)
        MessageBox.Show(SHA256(False, InputBox("ハッシュ化するも字は？")))
    End Sub

    Public Function SHA256(ByVal isFile As Boolean, pathanpass As Boolean)
        'SHA256ハッシュ値を計算する文字列
        Dim s As String = pathanpass
        Select Case isFile

            Case True 'ファイルである
                'MD5ハッシュ値を計算するファイル 
                Dim fileName As String = s
                'ファイルを開く
                Dim fs As New System.IO.FileStream(
    fileName,
    System.IO.FileMode.Open,
    System.IO.FileAccess.Read,
    System.IO.FileShare.Read)

                'MD5CryptoServiceProviderオブジェクトを作成 
                Dim md5 As New System.Security.Cryptography.MD5CryptoServiceProvider()

                'ハッシュ値を計算する 
                Dim bs As Byte() = md5.ComputeHash(fs)

                'リソースを解放する
                md5.Clear()
                'ファイルを閉じる 
                fs.Close()

                'byte型配列を16進数の文字列に変換 
                Dim result As New System.Text.StringBuilder()
                For Each b As Byte In bs
                    result.Append(b.ToString("x2"))
                Next
                Return result
            Case False 'パスワードである
                '文字列をbyte型配列に変換する
                Dim data As Byte() = System.Text.Encoding.UTF8.GetBytes(s)

                'SHA256CryptoServiceProviderオブジェクトを作成
                Dim sha256cy As New System.Security.Cryptography.SHA256CryptoServiceProvider()
                'ハッシュ値を計算する
                Dim bs As Byte() = sha256cy.ComputeHash(data)

                'リソースを解放する
                sha256cy.Clear()

                'byte型配列を16進数の文字列に変換
                Dim result As New System.Text.StringBuilder()
                Dim b As Byte
                For Each b In bs
                    result.Append(b.ToString("x2"))
                Next b
                Return result
        End Select
    End Function
End Class
