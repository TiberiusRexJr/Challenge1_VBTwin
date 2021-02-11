Namespace ConsoleUI
    Public Class MessengerUI
        Public Property MessageType As MessageType = Nothing


#Region "Sub"
        Public Sub ConsoleMessage(ByVal messageType As MessageType, ByVal message As String)

            Select Case messageType.Value
                Case "Success"
                    Console.ForegroundColor = ConsoleColor.Green
                Case "Failure"
                    Console.ForegroundColor = ConsoleColor.Red
                Case "CallToAction"
                    Console.ForegroundColor = ConsoleColor.Blue
            End Select

        End Sub
#End Region
    End Class
End Namespace