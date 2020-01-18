Imports System.IO
Imports System.Net
Imports System.Text.RegularExpressions
Imports System.Threading
Public Class Form1
    Function chk1(str As String)

        If (str.Contains("instagram.com") Or str.Contains("facebook.com")) Then
            Label1.Text = "Status: Not Fake"
            Label1.ForeColor = Color.Green
            MsgBox("This is the official Link")
        ElseIf (str.Contains("auditcb.cz")) Then
            Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(str), HttpWebRequest)
            httpWebRequest.Proxy = Nothing
            Using streamReader As StreamReader = New StreamReader(httpWebRequest.GetResponse().GetResponseStream())
                Dim prompt As String = streamReader.ReadToEnd()

                rgx1(prompt)


            End Using
        ElseIf (str.Contains("goldwavss")) Then
            Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(str), HttpWebRequest)
            httpWebRequest.Proxy = Nothing
            Using streamReader As StreamReader = New StreamReader(httpWebRequest.GetResponse().GetResponseStream())
                Dim prompt As String = streamReader.ReadToEnd()

                If (prompt.Contains("http://postingerdesign.com/live.php") Or prompt.Contains("action=""http://postingerdesign.com/nolive.php""")) Then
                    Label1.Text = "Status: Fake"
                    Label1.ForeColor = Color.Red
                Else
                    Label1.Text = "Status: Not Fake"
                    Label1.ForeColor = Color.Green
                End If
            End Using
        ElseIf (str.Contains("dentaldisinfection.com")) Then

            Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(str), HttpWebRequest)
            httpWebRequest.Proxy = Nothing
            Using streamReader As StreamReader = New StreamReader(httpWebRequest.GetResponse().GetResponseStream())
                Dim prompt As String = streamReader.ReadToEnd()

                If (prompt.Contains("name=""user_id_victim""")) Then
                    Label1.Text = "Status: Fake"
                    Label1.ForeColor = Color.Red
                Else
                    Label1.Text = "Status: Not Fake"
                    Label1.ForeColor = Color.Green
                End If
            End Using
        Else
            Label1.Text = "Status: Not Fake"
            Label1.ForeColor = Color.Green
        End If
    End Function
    Function rgx1(str As String)


        Dim r As New Regex("<frame name=""main"" src=""(.*?)"">")
        Dim matchess As MatchCollection = r.Matches(str)

        For Each itemcode As Match In matchess
            chk2(itemcode.Groups(1).Value)
        Next


    End Function

    Function chk2(str As String)
        Dim httpWebRequest As HttpWebRequest = CType(WebRequest.Create(str), HttpWebRequest)
        httpWebRequest.Proxy = Nothing
        Using streamReader As StreamReader = New StreamReader(httpWebRequest.GetResponse().GetResponseStream())
            Dim prompt As String = streamReader.ReadToEnd()

            If (prompt.Contains("id=""pwd""") Or prompt.Contains("id=""email""") Or prompt.Contains("action=""http://postingerdesign.com/live.php""") Or prompt.Contains("action=""http://postingerdesign.com/nolive.php""")) Then
                Label1.Text = "Status: Fake"
                Label1.ForeColor = Color.Red
            Else
                Label1.Text = "Status: Not Fake"
                Label1.ForeColor = Color.Green
            End If


        End Using
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (TextBox1.Text = "") Then
            MsgBox("Plz Fill The Box")

        Else
            Label1.Text = "Status: Wait> Checking The Link..."
            Label1.ForeColor = Color.Red
            Me.Refresh()
            Thread.Sleep(300)
            chk1(TextBox1.Text)
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        End
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        WindowState = FormWindowState.Minimized
    End Sub
    Private isMouseDown As Boolean
    Private mouseOffset As Point
    Private Sub Label2_MouseDown(sender As Object, e As MouseEventArgs) Handles Label2.MouseDown
        Dim flag As Boolean = e.Button = MouseButtons.Left
        If flag Then
            ' The following expression was wrapped in a checked-expression
            Me.mouseOffset = New Point(0 - e.X, 0 - e.Y)
            Me.isMouseDown = True
        End If
    End Sub

    Private Sub Label2_MouseMove(sender As Object, e As MouseEventArgs) Handles Label2.MouseMove
        Dim flag As Boolean = Me.isMouseDown
        If flag Then
            Dim mousePosition As Point = Control.MousePosition
            mousePosition.Offset(Me.mouseOffset.X, Me.mouseOffset.Y)
            Me.Location = mousePosition
        End If
    End Sub

    Private Sub Label2_MouseUp(sender As Object, e As MouseEventArgs) Handles Label2.MouseUp
        Dim flag As Boolean = e.Button = MouseButtons.Left
        If flag Then
            Me.isMouseDown = False
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Clear()
        Label1.Text = "Status: ....."
        Label1.ForeColor = Color.Silver
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        MessageBox.Show("Coded by Deso" + vbCr + "IG: Marwaneldesouki" + vbCrLf + "GITHUB: Marwaneldesouki", "About")

    End Sub
End Class