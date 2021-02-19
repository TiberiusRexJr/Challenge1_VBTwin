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
                    End If
                Next
            Catch ex As Exception

            End Try

            Return status
        End Function
        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        Public Function GetData() As List(Of BillHeader)
            Dim returnData As List(Of BillHeader) = Nothing

            Return returnData
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="billData"></param>
        ''' <returns></returns>
        Private Function PrepareCustomerCommand(ByVal billData As BillHeader) As OleDbCommand

            Dim returnCommand As OleDbCommand = Nothing

            Return returnCommand
        End Function

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="b"></param>
        ''' <returns></returns>
        Private Function PrepareBillCommand(ByVal b As BillHeader) As OleDbCommand

            Dim returnCommand As OleDbCommand = Nothing

            Throw New NotImplementedException()
        End Function



#End Region


    End Class

End Namespace
