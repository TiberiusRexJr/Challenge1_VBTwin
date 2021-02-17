Imports System.Threading

Namespace ConsoleUI
    Public Class MessengerUI
        Public Property MessageType As MessageType = Nothing


#Region "Sub"
        Public Sub ConsoleMessage(ByVal messageType As MessageType, ByVal message As String)

            Select Case messageType.Value
                Case "Success"
                    Console.ForegroundColor = ConsoleColor.Green
                    Exit Select
                Case "Failure"
                    Console.ForegroundColor = ConsoleColor.Red
                    Exit Select
                Case "CallToAction"
                    Console.ForegroundColor = ConsoleColor.Blue
                    Exit Select

            End Select


            Console.WriteLine(Environment.NewLine)
            Console.WriteLine(message)
            Console.WriteLine(Environment.NewLine)
            Console.ResetColor()
        End Sub

        Public Sub ConsolePause()
            Dim miliseconds As Integer = 1000
            Thread.Sleep(miliseconds)
        End Sub

#End Region


    End Class
End Namespace