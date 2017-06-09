Imports System.IO

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Try
            Dim file As FileStream = New FileStream("target.txt", FileMode.Open, FileAccess.Read)
            Dim fr As StreamReader = New StreamReader(file)
            Dim target, collect As Integer
            file.Seek(0, 0)
            target = CInt(fr.ReadLine)

            fr.Close()
            file.Close()

            file = New FileStream("collection.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
            fr = New StreamReader(file)
            file.Seek(0, 0)
            collect = CInt(fr.ReadLine)


            fr.Close()
            file.Close()

            ProgressBar1.Value = collect
            ProgressBar1.Maximum = target
            Label2.Text = "Target=" & (target)
            Label3.Text = "Collected=" & collect

            Console.WriteLine(target)
            Console.Write(collect)

        Catch ex As System.IO.FileNotFoundException
            Dim a As Integer

            a = MessageBox.Show("No previous entries found. Create a new one?", "Help", MessageBoxButtons.YesNo)

            If a = CInt(vbYes) Then
                Form2.Show()
                Me.Close()


            Else
                Me.Close()
            End If
        End Try



    End Sub

    Private Sub NewToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NewToolStripMenuItem.Click
        Form2.Show()
        Me.Close()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Form2.Close()
        Me.Close()

    End Sub
End Class
