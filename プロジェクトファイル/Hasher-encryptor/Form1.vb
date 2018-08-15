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
    End Sub
End Class
