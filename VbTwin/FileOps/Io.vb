Imports System.IO
Imports System.Xml
Imports System.Text
Imports VbTwin.Model

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

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="writeToDir"></param>
        ''' <param name="header"></param>
        ''' <param name="writeData"></param>
        ''' <returns></returns>
        Public Function WriteToRPT(ByVal writeToDir As String, ByVal header As String, ByVal writeData As LinkedList(Of InvoiceBill)) As Boolean

            Dim status As Boolean = False

            If String.IsNullOrEmpty(writeToDir) Or String.IsNullOrEmpty(header) Then
                Return status
            End If

            Dim sb As New StringBuilder("")

            sb.Append(writeToDir)
            sb.Append("/" + RPT_FILENAME)
            sb.Append("_")
            sb.Append(DateTime.Today.ToString("mm/dd/yyyy"))
            sb.Append(".rpt")

            Try
                Using sw As New StreamWriter(sb.ToString)
                    sw.WriteLine(header)

                    For Each b As InvoiceBill In writeData
                        sw.WriteLine(b.AddressLine)
                        sw.WriteLine(b.InvoiceLine)
                    Next

                    status = True
                End Using
            Catch ex As Exception
                Return status = False
            End Try

            Return status
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="writeToDir"></param>
        ''' <param name="header"></param>
        ''' <param name="writeData"></param>
        ''' <returns></returns>
        Public Function WriteToCSV(ByVal writeToDir As String, ByVal header As String, ByVal writeData As LinkedList(Of String)) As Boolean

            Dim status As Boolean = False
            Dim sb As StringBuilder = New StringBuilder("")

            If String.IsNullOrEmpty(writeToDir) Or String.IsNullOrEmpty(header) Then
                Return status
            End If

            sb.Append(writeToDir)
            sb.Append("/" + CSV_FILENAME + ".txt")

            Try
                Using sw As New StreamWriter(sb.ToString)
                    sw.WriteLine(header)

                    For Each s As String In writeData
                        sw.WriteLine(s)
                    Next

                    status = True
                End Using
            Catch ex As Exception
                Return status = False
            End Try

            Return status
        End Function


#End Region

#Region "Create Write Data"


#Region "Create Write Data Csv"
        Public Function CreateWriteDataCSV(ByVal header As String, ByVal lineData As List(Of String)) As (Header As String, LineData As List(Of String))
            Dim Head As String = String.Empty
            Dim LineD As List(Of String) = Nothing



            Return (Head, LineD)
        End Function

        Private Function CreateLineDataCSV(ByVal headerList As List(Of BillHeader)) As List(Of String))
            Dim lineData As List(Of String) = New List(Of String)

            If headerList Is Nothing Then
                Return lineData
            End If

            For Each b As BillHeader In headerList
                Dim sb As StringBuilder = New StringBuilder("")
                sb.Append(b.CustomerName + ",")
                sb.Append(b.AccountNo + ",")
                sb.Append(b.AddressInformation.City + ",")
                sb.Append(b.AddressInformation.State + ",")
                sb.Append(b.AddressInformation.Zip + ",")
                sb.Append(b.BillInfo.ID.ToString() + ",")
                sb.Append(b.BillDate.ToString("MM/dd/yyyy") + ",")
                sb.Append(b.BillInfo.BillNumber + ",")
                sb.Append(b.BillInfo.BalanceDue.ToString() + ",")
                sb.Append(b.DueDate.ToString("MM/dd/yyyy") + ",")
                sb.Append(b.BillInfo.BillAmount.ToString() + ",")
                sb.Append(b.BillInfo.FormateGUID + ",")
                sb.Append(b.DateAdded.ToString("MM/dd/yyyy") + ",")

                lineData.Add(sb.ToString)
            Next

            Return lineData
        End Function

        Private Function CreateInvoiceHeaderCSV(ByVal billList As List(Of BillHeader)) As String
            Dim sb As StringBuilder = New StringBuilder("")

            Dim data = GetHeaderStatistics(billList)


            sb.Append(_FieldTable("2") + ",")
            sb.Append(data.CurrentDate + ",")
            sb.Append(data.RecordCount.ToString())
            sb.Append(data.RecordInvoiceTotal.ToString())

            Return sb.ToString

        End Function
#End Region

#Region "Create Wrie Data RPT"


#End Region

#Region "Statistics"

#End Region
#End Region


    End Class
End Namespace