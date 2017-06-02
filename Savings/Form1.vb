Imports System.IO

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim f1 As FileStream = New FileStream("ta.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
        Dim fw As StreamWriter = New StreamWriter(f1)
        Dim fr As StreamReader = New StreamReader(f1)
        Dim a As Integer


        If fr.ReadLine() = "" Then
            fw.WriteLine(TextBox1.Text)
            fw.Close()
            fr.Close()
            f1.Close()
            Me.Hide()
            Form2.Show()

        Else
            a = MessageBox.Show("Savings scheme already exists. Do you want to overwrite?", "Error", MessageBoxButtons.OKCancel)

            If a = vbOK Then
                fw.WriteLine(TextBox1.Text)

                Dim deposit As FileStream = New FileStream("dep.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite)
                Dim fw2 As StreamWriter = New StreamWriter(deposit)
                fw2.WriteLine("")
                fw2.Close()

                deposit.Close()
                fw.Close()
                fr.Close()

                f1.Close()
                MessageBox.Show("You have set new target to " & TextBox1.Text & "! Happy saving!", "Congratulations!")
                Me.Hide()
                Form2.Show()
            Else

                fw.Close()
                fr.Close()

                f1.Close()
                Me.Hide()
                Form2.Show()
            End If

        End If








    End Sub
End Class
