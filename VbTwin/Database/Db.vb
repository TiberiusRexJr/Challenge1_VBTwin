Imports System.Data.Oledb
Imports VbTwin.Model

Namespace Database

Public Class Db

#Region "Variables"

 Private readonly _dbFileName As String="Billing.mdb"
 Private _conn As OleDbConnection= Empty

#End Region

#Region "Properties"


#End Region

#Region  "Constructor"
    Public Sub New()
        SetDbConnection()
    End Sub
#End Region

#Region "Methods"

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="dataList"></param>
        ''' <returns></returns>
        Public Function PutData(ByVal dataList As List(of BillHeader))

        Dim status As boolean=Nothing
        Dim _ =AppDomain.CurrentDomain.BaseDirectory

                

    End Function



#End Region


End Class

End Namespace
