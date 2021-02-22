Imports System.IO
Imports System.Xml

Namespace FileOps
    Public Class Io

#Region "Constants"
        Private _FieldTable As Dictionary(Of String, String) = New Dictionary(Of String, String)

        Private ReadOnly RPT_FILENAME As String = "BilFile"
        Private ReadOnly CSV_FILENAME As String = "BillingReport"


#End Region

#Region "Constructor"
        Public Sub New()
            _FieldTable.Add("2", "8203ACC7-2094-43CC-8F7A-B8F19AA9BDA2")
            _FieldTable.Add("5", "Count of IH records")
            _FieldTable.Add("6", "SUM of BILL_AMOUNT values ")
            _FieldTable.Add("JJ", "8E2FEA69-5D77-4D0F-898E-DFA25677D19E")
            _FieldTable.Add("OO", "5 days after the current date")
            _FieldTable.Add("PP", "3 days before the Due Date (MM)")
        End Sub

#End Region

#Region "ReadFiles"

        Public Function GetXmlData(ByVal filePath As String, ByVal nodeName As String) As XmlNodeList

            Dim xml As XmlDocument = New XmlDocument()
            Dim Bill_Header As XmlNodeList = Nothing

            If String.IsNullOrEmpty(filePath) Or String.IsNullOrEmpty(nodeName) Then
                Return Bill_Header
            End If
            Try
                Dim fs As FileStream = New FileStream(filePath, FileMode.Open, FileAccess.Read)

                xml.Load(fs)
                Bill_Header = xml.GetElementsByTagName(nodeName)

            Catch ex As Exception
                Return Bill_Header
            End Try

            Return Bill_Header
        End Function



#End Region

#Region "WriteFiles"

#End Region

#Region "Create Write Data"

#End Region


    End Class
End Namespace