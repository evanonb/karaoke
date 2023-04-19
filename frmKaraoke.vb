' Program Name: Karaoke Music Night Application
' Purpose:      Karaoke Music Night Application

Option Strict On

Public Class frmKaraoke

    Private _decSong As Decimal = 2.99D
    Private _decHourlyRate As Decimal = 8.99D
    Private Sub frmKaraoke_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' The frm Karaoke_Load event holds the splash screen for approximately 6 seconds
        Threading.Thread.Sleep(3000)
        ClearForm()
    End Sub
    Private Function ValidateInput() As Boolean
        ' This procedure validates the input
        Dim intNumber As Integer
        Dim blnValid As Boolean = False
        Try
            ' Converts the target amount to an integer value
            intNumber = Convert.ToInt32(txtValue.Text)
            If intNumber > 0D Then
                blnValid = True
                Return blnValid
            Else
                MsgBox("Please enter a number greater than 0", , "Error")
            End If
        Catch ex As FormatException
            ' This catch block detects letters, symbols, blank entries, etc
            MsgBox("Please enter a valid amount", , "Error")
        Catch ex As OverflowException
            ' This catch block detects numbers that are too large or too small
            MsgBox("Please enter a reasonable amount", , "Error")
        Catch ex As SystemException
            ' This catch block detects a generic exception not caught by earlier catch blocks
            MsgBox("Entry invalid. Please enter a valid number representing the number in your party", , "Error")
        End Try
        ' Place focus back onto the textbox
        txtValue.Focus()
        txtValue.Clear()
        Return blnValid

    End Function

    Private Function ComputeSongCost(ByVal intPass As Integer) As Decimal
        Dim decPassCost As Decimal
        decPassCost = intPass * _decSong

        Return decPassCost
    End Function

    Private Function ComputeRoomCost(ByVal intPass As Integer) As Decimal
        Dim decTicketCost As Decimal
        decTicketCost = intPass * _decHourlyRate

        Return decTicketCost
    End Function


    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ' The btnClear click event clears the form
        ClearForm()
    End Sub

    Private Sub ClearForm()
        ' Clears the form
        cboSelectAction.SelectedIndex = -1
        lblDisplay.Visible = False
        txtValue.Visible = False
        btnCost.Visible = False

        btnClear.Visible = False
        lblCost.Visible = False
        txtValue.Clear()
    End Sub


    Private Sub btnCost_Click(sender As Object, e As EventArgs) Handles btnCost.Click
        Dim blnAmountIsValid As Boolean = False
        Dim intValue As Integer
        Dim decTotal As Decimal

        ' A function procedure is called to validate the value entered
        blnAmountIsValid = ValidateInput()
        If blnAmountIsValid = True Then
            ' Input is assigned to variable
            intValue = Convert.ToInt32(txtValue.Text)
            If cboSelectAction.SelectedIndex = 0 Then
                decTotal = ComputeSongCost(intValue)
            Else
                decTotal = ComputeRoomCost(intValue)
            End If

            lblCost.Visible = True
            lblCost.Text = "Total Cost of Karaoke Night - " & decTotal.ToString("C")
        End If

    End Sub

    Private Sub cboSelectAction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSelectAction.SelectedIndexChanged
        ' The cboSelectAction SelectedIndexChanged event places the objects on the form
        If cboSelectAction.SelectedIndex = 0 Then
            lblDisplay.Text = "Number of Karaoke Songs"
            lblDisplay.Visible = True
            txtValue.Visible = True
            btnCost.Visible = True
            btnClear.Visible = True
            ' Place focus on the textbox
            txtValue.Focus()
        End If
        If cboSelectAction.SelectedIndex = 1 Then
            lblDisplay.Text = "Hourly Rental of Karaoke Room"
            lblDisplay.Visible = True
            txtValue.Visible = True
            btnCost.Visible = True
            btnClear.Visible = True
            ' Place focus on the textbox
            txtValue.Focus()
        End If
    End Sub
End Class
