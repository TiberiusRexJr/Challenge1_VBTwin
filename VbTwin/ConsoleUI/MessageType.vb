Namespace ConsoleUI
    Public Class MessageType

#Region "Variables"
        Public Value As String = String.Empty

#End Region

#Region "Properties"
        Public ReadOnly Property Success As MessageType
            Get
                Dim mt As New MessageType("Success")
                Return mt
            End Get
        End Property

        Public ReadOnly Property Failure As MessageType
            Get
                Dim mt As New MessageType("Failure")
                Return mt
            End Get
        End Property

        Public ReadOnly Property CallToAction As MessageType
            Get
                Dim mt As New MessageType("CallToAction")
                Return mt
            End Get
        End Property

        Public ReadOnly Property Status As MessageType
            Get
                Dim mt As New MessageType("Status")
                Return mt
            End Get
        End Property
#End Region

#Region "Constructor"
        Private Sub New(ByVal val As String)
            Value = val
        End Sub
#End Region


    End Class

End Namespace