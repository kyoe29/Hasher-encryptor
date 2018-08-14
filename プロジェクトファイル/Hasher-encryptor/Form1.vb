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
    End Sub
End Class
