Public Class AddressInformation

#Region "Variables"
    Private _mailingaddress1 As String = String.Empty
    Private _mailingaddress2 As String = String.Empty
    Private _city As String = String.Empty
    Private _state As String = String.Empty
    Private _zip As String = String.Empty
#End Region
#Region "Properties"
    Public Property Mailing_Address_1 As String
        Get
            Return _mailingaddress1
        End Get
        Set(value As String)
            _mailingaddress1 = value
        End Set
    End Property

    Public Property Mailing_Address_2 As String
        Get
            Return _mailingaddress2
        End Get
        Set(value As String)
            _mailingaddress2 = value
        End Set
    End Property

    Public Property City As String
        Get
            Return _city
        End Get
        Set(value As String)
            _city = value
        End Set
    End Property

    Public Property State As String
        Get
            Return _state
        End Get
        Set(value As String)
            _state = value
        End Set
    End Property

    Public Property Zip As String
        Get
            Return _zip
        End Get
        Set(value As String)
            _zip = value
        End Set
    End Property
#End Region
#Region "XMLProperties"
    Public ReadOnly NODENAME = "Address_Information"
    Public ReadOnly PARENT_NODENAME = "BILL_HEADER"
#End Region
End Class