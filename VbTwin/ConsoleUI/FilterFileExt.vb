Namespace ConsoleUI
    Public Class FilterFileExt
#Region "Constructor"
        Private Sub New(ByVal val As String)
            Value = val
        End Sub
#End Region

#Region "Variables"
        Public Value As String = String.Empty
#End Region

#Region "Properties"
        Public ReadOnly Property xml As FilterFileExt
            Get
                Dim ft As New FilterFileExt("xml files (*.xml)|*.xml")
                Return ft
            End Get
        End Property

        Public ReadOnly Property rpt As FilterFileExt
            Get
                Dim ft As New FilterFileExt("rpt Files (*.rpt)|*.rpt")
                Return ft
            End Get
        End Property
#End Region

    End Class
End Namespace