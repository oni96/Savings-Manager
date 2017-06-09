Imports System.IO

Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click


        Dim main As Form1
        Dim file As FileStream = New FileStream("target.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim fw As StreamWriter = New StreamWriter(file)
        Dim formedit As Form1 = New Form1


        file.Seek(0, 0)

        fw.WriteLine(TextBox1.Text)
        fw.Close()
        file.Close()

        file = New FileStream("collection.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
        fw = New StreamWriter(file)
        file.Seek(0, 0)

        fw.WriteLine("0")


        fw.Close()
        file.Close()
        'setval(Val(TextBox1.Text), 0)
        formedit.Refresh()
        formedit.Invalidate()
        formedit.Show()

        Me.Close()

    End Sub

    Private Function setval(ByVal max, ByVal val)
        Dim formedit As Form1 = New Form1


        formedit.ProgressBar1.Maximum = max
        formedit.ProgressBar1.Value = val
        formedit.Label2.Text = "Target=" & max

        formedit.Label3.Text = "Collected=" & "0"
        Console.WriteLine(max)
        formedit.Refresh()
        formedit.Invalidate()
        formedit.Show()




        Return 0

    End Function
End Class