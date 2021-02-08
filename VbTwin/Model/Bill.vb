Imports System

Namespace Model
    Public Class Bill

#Region "Variables"
        Private _billAmount As Decimal = Decimal.Zero
        Private _balanceDue As Decimal = Decimal.Zero
        Private _formateGUID As String = String.Empty
        Private _firstEmailDate As Date = Date.Now.ToString("MM/dd/yyyy")
        Private _secondEmailDate As Date = Date.Now.ToString("MM/dd/yyyy")
        Private _nodeName As String = String.Empty
        Private _parentNodeName As String = String.Empty
        Private _customerId As Integer = Nothing
        Private _ID As Integer = Nothing
        Private _BillNumber As String = String.Empty
        Private _dateAdded As Date = Date.Now.ToString("MM/dd/yyyy")
        Private _serviceAddress As String = String.Empty

#End Region

#Region "Properties"
        Public Property BillAmount As Decimal
            Get
                Return _billAmount
            End Get
            Set(value As Decimal)
                _billAmount = value
            End Set
        End Property
        Public Property BalanceDue As Decimal
            Get
                Return _balanceDue
            End Get
            Set(value As Decimal)
                _balanceDue = value
            End Set
        End Property
        Public Property FormateGUID As String
            Get
                Return _formateGUID
            End Get
            Set(value As String)
                _formateGUID = value
            End Set
        End Property
        Public Property FirstEmailDate As Date
            Get
                Return _firstEmailDate
            End Get
            Set(value As Date)
                _firstEmailDate = value
            End Set
        End Property
        Public Property SecondEmailDate As Date
            Get
                Return _secondEmailDate
            End Get
            Set(value As Date)
                _secondEmailDate = value
            End Set
        End Property
        Public Property Nodename As String
            Get
                Return _nodeName
            End Get
            Set(value As String)
                _nodeName = value
            End Set
        End Property
        Public Property ParentNodeName As String
            Get
                Return _parentNodeName
            End Get
            Set(value As String)
                _parentNodeName = value
            End Set
        End Property
        Public Property CustomerID As String
            Get
                Return _customerId
            End Get
            Set(value As String)
                _customerId = value
            End Set
        End Property
        Public Property ID As Integer
            Get
                Return _ID
            End Get
            Set(value As Integer)
                _ID = value
            End Set
        End Property
        Public Property BillNumber As Integer
            Get
                Return _BillNumber
            End Get
            Set(value As Integer)
                _BillNumber = value
            End Set
        End Property

        Public Property DateAdded As Date
            Get
                Return _dateAdded
            End Get
            Set(value As Date)
                _dateAdded = value
            End Set
        End Property

        Public Property ServiceAddress As String
            Get
                Return _serviceAddress
            End Get
            Set(value As String)
                _serviceAddress = value
            End Set
        End Property
#End Region
#Region "XMLProperties"

#End Region
#Region "DataTable Properies"

#End Region
    End Class
End Namespace