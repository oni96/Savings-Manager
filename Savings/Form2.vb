Imports System.IO
Imports System.IO.File

Public Class Form2
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim deposit As FileStream = New FileStream("dep.txt", FileMode.Open, FileAccess.ReadWrite)
        Dim fw As StreamWriter = New StreamWriter(deposit)
        Dim fr As StreamReader = New StreamReader(deposit)
        Dim cdep As Double
        Dim ndep As Double

        cdep = CDbl(fr.ReadLine)

        ndep = TextBox1.Text + cdep

        ProgressBar1.Value = ndep

        fw.WriteLine(ndep)
        Label1.Text = Label1.Text + ndep


        fw.Close()
        fr.Close()
        deposit.Close()




    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim deposit As FileStream = New FileStream("dep.txt", FileMode.OpenOrCreate, FileAccess.Read)
        Dim target As FileStream = New FileStream("ta.txt", FileMode.OpenOrCreate, FileAccess.Read)
        Dim fr2 As StreamReader = New StreamReader(target)
        Dim fr1 As StreamReader = New StreamReader(deposit)


        If fr1.ReadLine = "" Then
            ProgressBar1.Value = 0
            Label1.Text = Label1.Text + "0"
        Else
            Label1.Text = Label1.Text + fr1.ReadLine
            ProgressBar1.Value = CInt(fr1.ReadLine)
        End If

        If fr2.ReadLine = "" Then
            Label2.Text = Label2.Text + "0"
        Else
            ProgressBar1.Maximum = CInt(fr2.ReadLine)
            Label2.Text = Label2.Text + fr2.ReadLine
        End If

        fr1.Close()
        fr2.Close()
        target.Close()
        deposit.Close()

        Refresh()



    End Sub
End Class