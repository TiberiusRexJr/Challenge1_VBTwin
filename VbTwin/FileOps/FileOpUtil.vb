Imports System.Collections.Generic
Imports System.IO
Imports VbTwin.Model

Namespace FileOps
    Public Class FileOpUtil

#Region "Methods"

        Public Function FillInExtraData(ByVal dataList As List(Of BillHeader))
            For Each b As BillHeader In dataList
                b.ServiceAddress = b.SERVICE_ADDRESS
            Next
            Return dataList
        End Function



#End Region

    End Class
End Namespace