Namespace Model
    Public Class BillHeader

#Region "Constants"
        Public ReadOnly SERVICE_ADDRESS As String = "1655 Ruben M Torres Blvd STE 101, Brownsville, TX 78526"
#End Region

#Region "Variables"

#End Region

#Region "Properties"
        Public Property InvoiceNo As String = String.Empty
        Public Property AccountNo As String = String.Empty
        Public Property CustomerName As String = String.Empty
        Public Property BillDate As Date = Date.Today.ToString("MM/dd/yyyy")
        Public Property DueDate As Date = Date.Today.ToString("MM/dd/yyyy")
        Public Property AddressInformation As AddressInformation = Nothing
        Public Property BillInfo As Bill = Nothing



#End Region

#Region "XmlProperties"
        Public ReadOnly NodeName As String = "BILL_HEADER"
        Public ReadOnly ParentNodeName As String = "BILL_HEADER_Dataset"
#End Region

#Region "DataTable Properties"
        Public Property DateAdded As Date = Date.Today.ToString("MM/dd/yyyy")
        Public Property FromatGUID As String = String.Empty
#End Region

#Region "ForRPT"
        Public ServiceAddress As String = String.Empty
#End Region

#Region "Constructor"
        Public Sub BillHeader()
            BillInfo = New Bill()
            AddressInformation = New AddressInformation()
        End Sub
#End Region

    End Class
End Namespace
