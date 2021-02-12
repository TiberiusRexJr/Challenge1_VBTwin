Imports System.Collections.Generic
Imports System.IO
Imports VbTwin.Model
                  imp
Namespace FileOps
    Public Class FileOp

#Region "Methods"

        Public Function FillInExtraData(ByVal dataList As List(Of BillHeader))
            For Each b As BillHeader In dataList
                b.ServiceAddress = b.SERVICE_ADDRESS
            Next
            Return dataList
        End Function


        Public Function GetOutputDir() As String
            Dim outputDir As String = String.Empty

            Return outputDir
        End Function

#End Region
    End Class
End Namespace