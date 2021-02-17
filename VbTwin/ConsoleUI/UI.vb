Imports VbTwin.Model
Imports VbTwin.FileOps
Imports System.Windows
Imports System.Windows.Forms

Namespace ConsoleUI
    Public Class UI

#Region " Variables"

        Private _parse As Parsing = New Parsing()
        Private _io As Io = New Io()
        Private _ut As FileOp = New FileOp
        Private _bh As BillHeader = New BillHeader()
        Private _ui As MessengerUI = New MessengerUI()
        Private _db As Db = New Db()


#End Region

#Region "Main Functionality"
        ''Missing need to create actual functions in thier repsects classes first
#End Region

#Region "Get Output Dir & File Path"
        Public Function GetOutputDir()
            Dim outputDir As String = String.Empty
            Dim folderDlg As New FolderBrowserDialog

            folderDlg.Description = "Select A File Destination"
            folderDlg.RootFolder = Environment.SpecialFolder.Desktop

            Try
                Dim form As New Form()
                form.TopMost = True

                If folderDlg.ShowDialog(form) = DialogResult.OK Then
                    outputDir = folderDlg.SelectedPath
                End If



            Catch ex As Exception
                System.Console.WriteLine(ex.Message)
            Finally

            End Try

            If String.IsNullOrEmpty(outputDir) Then
                _ui.ConsoleMessage(MessageType.)
            End If

            Return outputDir
        End Function
#End Region

    End Class

End Namespace