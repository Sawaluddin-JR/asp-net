Imports System.Runtime.InteropServices.JavaScript.JSType

Public Class Form1
    Dim data1 As Double
    Dim data2 As Double
    Dim total As Double
    Dim operasi As String

    Private Sub button1_Click(sender As Object, e As EventArgs) Handles button1.Click
        TextBox1.Text = ""
        TextBox2.Text = ""
        label1.Text = ""
    End Sub

    Private Sub button5_Click(sender As Object, e As EventArgs)
        If label1.Text = "0" Then
            label1.Text = "3"
        Else label1.Text = label1.Text & "3"
        End If
    End Sub

    Private Sub button15_Click(sender As Object, e As EventArgs) Handles button15.Click
        data1 = Val(TextBox1.Text)
        data2 = Val(TextBox2.Text)
        total = data1 / data2
        operasi = ":"
        label1.Text = total
    End Sub

    Private Sub button16_Click(sender As Object, e As EventArgs) Handles button16.Click
        data1 = Val(TextBox1.Text)
        data2 = Val(TextBox2.Text)
        total = data1 * data2
        operasi = "x"
        label1.Text = total
    End Sub

    Private Sub button18_Click(sender As Object, e As EventArgs) Handles button18.Click
        data1 = Val(TextBox1.Text)
        data2 = Val(TextBox2.Text)
        total = data1 + data2
        operasi = "+"
        label1.Text = total
    End Sub

    Private Sub button17_Click(sender As Object, e As EventArgs) Handles button17.Click
        data1 = Val(TextBox1.Text)
        data2 = Val(TextBox2.Text)
        total = data1 - data2
        operasi = "-"
        label1.Text = total
    End Sub

    Private Sub button19_Click(sender As Object, e As EventArgs) Handles button19.Click
        Select Case operasi
            Case "+"
                total = data1 + data2
            Case "-"
                total = data1 - data2
            Case "x"
                total = data1 * data2
            Case ":"
                total = data1 / data2
        End Select
        label1.Text = total
    End Sub
End Class
