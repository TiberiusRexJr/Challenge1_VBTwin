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
            Catch ex As Exception

            End Try

        End Sub




        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="dataList"></param>
        ''' <returns></returns>
        Public Function PutData(ByVal dataList As List(of BillHeader))

        Dim status As boolean=Nothing



        End Function



#End Region


End Class

End Namespace
