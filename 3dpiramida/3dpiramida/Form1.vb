Public Class Form1

    Dim strFileName As String
    Dim komanda As String
    Dim appPath As String = Application.StartupPath()
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        fd.Title = "Choose video"
        fd.InitialDirectory = "C:\"
        fd.Filter = "All files (*.*)|*.*|All files (*.*)|*.*"
        fd.FilterIndex = 2
        fd.RestoreDirectory = True

        If fd.ShowDialog() = DialogResult.OK Then
            strFileName = fd.FileName
            Label1.Text += fd.SafeFileName
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim formitic As String
        formitic = TextBox1.Text
        'Process.Start("CMD", "/C ffmpeg -i " & strFileName & " -filter_complex ""[0:v]split=4[a][b][c][d]; [a]pad=iw+2*ih:iw+2*ih:ih:0:black[base]; [b]transpose=cclock[br]; [c]transpose=clock[cr]; [d]hflip,vflip[dr]; [base][br]overlay=0:w[two]; [two][cr]overlay=W-w:w[three]; [three][dr]overlay=h:H-h[v]"" -map ""[v]""  " & formitic & " ")
        Dim p As Process = Process.Start("CMD", "/C ffmpeg -i " & strFileName & " -filter_complex ""[0:v]split=4[a][b][c][d]; [a]rotate=180*(PI/180),pad=iw+2*ih:iw+2*ih:ih:0:black[base]; [b]rotate=180*(PI/180),transpose=cclock[br]; [c]rotate=180*(PI/180),transpose=clock[cr]; [d]rotate=180*(PI/180),hflip,vflip[dr]; [base][br]overlay=0:w[two]; [two][cr]overlay=W-w:w[three]; [three][dr]overlay=h:H-h[v]"" -map ""[v]""  " & formitic & " ")
    End Sub

    Private Sub AboutToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem.Click
        MessageBox.Show("Created by: Dusan Grabovica" & vbNewLine & "Version: 0.1" & vbNewLine & "Site: www.elskolapd.com", _
                        "Credits")
    End Sub

    Private Sub AboutToolStripMenuItem_Click_2(sender As Object, e As EventArgs) Handles AboutToolStripMenuItem1.Click
        MessageBox.Show("Program witch will make video for 3d hologram.",
                        "About")
    End Sub
End Class
