Imports VbTwin.Model
Imports VbTwin.FileOps
Namespace ConsoleUI
    Public Class UI
#Region "Instance Variables"
        Private _parse As Parsing = New Parsing()
        Private _io As Io = New Io()
        Private _ut As FileOp = New FileOp
        Private _bh As BillHeader = New BillHeader()
        Private _ui As MessengerUI = New MessengerUI()
        Private _db As Db = New Db()

#End Region

    End Class
End Namespace