Imports System.Data.OleDb
Imports VbTwin.Model

Namespace Database

Public Class Db

#Region "Variables"

        Private ReadOnly _dbFileName As String = "Billing.mdb"
        Private _conn As OleDbConnection = Nothing
#End Region

#Region "Properties"


#End Region

#Region "Constructor"
        Public Sub New()
        SetDbConnection()
    End Sub
#End Region

#Region "Methods"

        ''' <summary>
        ''' 
        ''' </summary>
        Private Sub SetDbConnection()

            Dim b = AppDomain.CurrentDomain.BaseDirectory
            Dim dbRoot = b.Replace("\bin\Debug\", "/App_Data/")

            Dim conBuilder As OleDbConnectionStringBuilder = New OleDbConnectionStringBuilder()

            conBuilder.Provider = "Microsoft.ACE.OLEDB.12.0"
            conBuilder.DataSource = dbRoot + _dbFileName
            conBuilder.PersistSecurityInfo = True

            Try
                _conn = New OleDbConnection(conBuilder.ConnectionString)

            Catch ex As OleDbException
                Console.WriteLine(ex.Message)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

        End Sub


        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="dataList"></param>
        ''' <returns></returns>
        Public Function PutData(ByVal dataList As List(Of BillHeader)) As Boolean

            Dim status As Boolean = Nothing
            Dim queryIdentity As String = "Select @@Identity"

            Dim queryIdentityCommand As OleDbCommand = New OleDbCommand(queryIdentity, _conn)

            If dataList Is Nothing Then
                Return status
            End If

            Try
                _conn.Open()

                For Each b As BillHeader In dataList
                    Dim customerCommand = PrepareCustomerCommand(b)

                    If customerCommand.ExecuteNonQuery() = 1 Then
                        b.BillInfo.CustomerID = Convert.ToInt32(queryIdentityCommand.ExecuteScalar())

                        Dim billCommand As OleDbCommand = PrepareBillCommand(b)
                        If billCommand.ExecuteNonQuery() = 1 Then
                            status = True
                        Else
                            Return status = False
                        End If


                    Else
                        Return status = False

                    End If

                Next
            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Return status = False
            Finally
                _conn.Close()
            End Try


            Return status
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        Public Function GetData() As List(Of BillHeader)

            Dim returnData As List(Of BillHeader) = Nothing

            Dim getDataQuery As String = "SELECT b.CustomerID,c.CustomerName,c.AccountNumber,c.CustomerAddress,c.CustomerCity,c.CustomerState,c.CustomerZip,b.ID,b.BillDate,b.BillNumber,b.AccountBalance,b.DueDate,b.BillAmount,b.FormatGUID,c.DateAdded FROM Customer AS c Inner JOIN Bills as b ON c.ID=b.CustomerID"

            Dim getDataCommand = New OleDbCommand(getDataQuery, _conn)

            Try
                _conn.Open()

                Dim reader As OleDbDataReader = getDataCommand.ExecuteReader()

                While reader.Read()

                    Dim b As BillHeader = New BillHeader()

                    b.BillInfo.CustomerID = Convert.ToInt32(reader("CustomerName").ToString())
                    b.CustomerName = reader("CustomerName").ToString()
                    b.AccountNo = reader("AccountNumber").ToString()
                    b.AddressInformation.Mailing_Address_1 = reader("CustomerAddress").ToString()
                    b.AddressInformation.City = reader("CustomerCity").ToString()
                    b.AddressInformation.State = reader("CustomerState").ToString()
                    b.AddressInformation.Zip = reader("CustomerZip").ToString()

                    b.BillInfo.ID = Convert.ToInt32(reader("ID").ToString())
                    b.BillDate = Convert.ToDateTime(reader("BillDate"))
                    b.BillInfo.BillNumber = reader("BillNumber").ToString()
                    b.BillInfo.BalanceDue = Convert.ToDecimal(reader("AccountBalance"))
                    b.DueDate = Convert.ToDateTime(reader("DueDate"))
                    b.BillInfo.BillAmount = Convert.ToDecimal(reader("BillAmount").ToString())
                    b.BillInfo.FormateGUID = reader("FormatGUID").ToString()
                    b.DateAdded = Convert.ToDateTime(reader("DateAdded"))

                    returnData.Add(b)

                End While


            Catch ex As Exception
                Console.WriteLine(ex.Message.ToString)
                Return returnData
            Finally
                _conn.Close()
            End Try

            Return returnData
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="billData"></param>
        ''' <returns></returns>
        Private Function PrepareCustomerCommand(ByVal billData As BillHeader) As OleDbCommand

            Dim returnCommand As OleDbCommand = Nothing
            Dim queryInsertIntoCustomer = "Insert into Customer(CustomerName,AccountNumber,CustomerAddress,CustomerCity,CustomerState,CustomerZip,DateAdded) VALUES(?,?,?,?,?,?,?)"
            Dim customerCommand As OleDbCommand = Nothing

            Try
                customerCommand = New OleDbCommand(queryInsertIntoCustomer, _conn)
                billData.DateAdded = DateTime.Today

                customerCommand.Parameters.AddWithValue("@CustomerName", billData.CustomerName)
                customerCommand.Parameters.AddWithValue("@AccountNumber", billData.AccountNo)
                customerCommand.Parameters.AddWithValue("@CustomerAddress", billData.AddressInformation.Mailing_Address_1)
                customerCommand.Parameters.AddWithValue("@CustomerCity", billData.AddressInformation.City)
                customerCommand.Parameters.AddWithValue("@CustomerState", billData.AddressInformation.State)
                customerCommand.Parameters.AddWithValue("@CustomerZip", billData.AddressInformation.Zip)
                customerCommand.Parameters.AddWithValue("@DateAdded", billData.DateAdded)

            Catch ex As Exception
                Console.WriteLine(ex.Message)
                Return returnCommand
            End Try

            Return returnCommand
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="b"></param>
        ''' <returns></returns>
        Private Function PrepareBillCommand(ByVal b As BillHeader) As OleDbCommand

            Dim returnCommand As OleDbCommand = Nothing
            Dim queryInsertIntoBill As String = "Insert into Bills(BillDate,BillNumber,BillAmount,FormatGUID,AccountBalance,DueDate,ServiceAddress,FirstEmailDate,SecondEmailDate,CustomerID) VALUES(?,?,?,?,?,?,?,?,?,?)"

            Dim billCommand As OleDbCommand = New OleDbCommand(queryInsertIntoBill, _conn)

            billCommand.Parameters.AddWithValue("@BillDate", b.BillDate)
            billCommand.Parameters.AddWithValue("@BillNumber", b.InvoiceNo)
            billCommand.Parameters.AddWithValue("@BillAmount", b.BillInfo.BillAmount)
            billCommand.Parameters.AddWithValue("@FormatGUID", b.FromatGUID)
            billCommand.Parameters.AddWithValue("@AccountBalance", b.BillInfo.BalanceDue)
            billCommand.Parameters.AddWithValue("@DueDate", b.DueDate)
            billCommand.Parameters.AddWithValue("@ServiceAddress", b.SERVICE_ADDRESS)
            billCommand.Parameters.AddWithValue("@FirstEmailDate", b.BillInfo.FirstEmailDate)
            billCommand.Parameters.AddWithValue("@SecondEmailDate", b.BillInfo.SecondEmailDate)
            billCommand.Parameters.AddWithValue("@CustomerID", b.BillInfo.CustomerID)

            Return returnCommand
        End Function



#End Region


    End Class

End Namespace
