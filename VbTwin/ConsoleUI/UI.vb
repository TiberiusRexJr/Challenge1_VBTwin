Imports VbTwin.Model
Imports VbTwin.Database
Imports VbTwin.FileOps
Imports System.Windows
Imports System.Windows.Forms
Imports System.IO

Namespace ConsoleUI
    Public Class UI

#Region " Variables"

        Private _parse As Parsing = New Parsing()
        Private _io As Io = New Io()
        Private _ut As FileOpUtil = New FileOpUtil
        Private _bh As BillHeader = New BillHeader()
        Private _ui As MessengerUI = New MessengerUI()
        Private _db As Db = New Db()
        Private _msType As MessageType = Nothing


#End Region

#Region "Main Functionality"

        Public Sub MainLoop()
            'need to add shit here
        End Sub
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

                _ui.ConsoleMessage(_msType.Failure, "Please select a valid Directory and Try Again")

                MainLoop()

            End If

            Return outputDir

        End Function

        Public Function GetFileAndFormat(filter As FilterFileExt) As (FilePath As String, FileFormat As String)

            Dim FilePath As String = String.Empty
            Dim FileFormat As String = String.Empty

            Dim fdb As OpenFileDialog = New OpenFileDialog()

            fdb.Filter = filter.Value
            fdb.FilterIndex = 1
            fdb.Multiselect = False

            If fdb.ShowDialog() = DialogResult.OK Then
                FilePath = fdb.FileName
                FileFormat = Path.GetExtension(fdb.FileName)
            End If

            If String.IsNullOrEmpty(FilePath) Then
                _ui.ConsoleMessage(_msType.Failure, "Please Select A valid File and try again")

                MainLoop()

            End If

            Return (FilePath, FileFormat)

        End Function
#End Region

    End Class

End Namespace