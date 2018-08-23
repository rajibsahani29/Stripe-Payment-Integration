Imports Microsoft.VisualBasic

Namespace PlaceTheBall.BE

    Public Class clsBEClientDetails

        Private intClientDetailsId As Integer
        Public Property ClientDetailsId() As Integer
            Get
                Return intClientDetailsId
            End Get
            Set(ByVal value As Integer)
                intClientDetailsId = value
            End Set
        End Property

        Private intClientId As Integer
        Public Property ClientId() As Integer
            Get
                Return intClientId
            End Get
            Set(ByVal value As Integer)
                intClientId = value
            End Set
        End Property

        Private strName2 As String
        Public Property Name2() As String
            Get
                Return strName2
            End Get
            Set(ByVal value As String)
                strName2 = value
            End Set
        End Property

        Private strAddress1 As String
        Public Property Address1() As String
            Get
                Return strAddress1
            End Get
            Set(ByVal value As String)
                strAddress1 = value
            End Set
        End Property

        Private strAddress2 As String
        Public Property Address2() As String
            Get
                Return strAddress2
            End Get
            Set(ByVal value As String)
                strAddress2 = value
            End Set
        End Property

        Private strCity As String
        Public Property City() As String
            Get
                Return strCity
            End Get
            Set(ByVal value As String)
                strCity = value
            End Set
        End Property

        Private strSexID As String
        Public Property SexID() As String
            Get
                Return strSexID
            End Get
            Set(ByVal value As String)
                strSexID = value
            End Set
        End Property

        Private strPostCode As String
        Public Property PostCode() As String
            Get
                Return strPostCode
            End Get
            Set(ByVal value As String)
                strPostCode = value
            End Set
        End Property

        Private strPhone1 As String
        Public Property Phone1() As String
            Get
                Return strPhone1
            End Get
            Set(ByVal value As String)
                strPhone1 = value
            End Set
        End Property

        Private strPhone2 As String
        Public Property Phone2() As String
            Get
                Return strPhone2
            End Get
            Set(ByVal value As String)
                strPhone2 = value
            End Set
        End Property

        Private strAdditionalInfo As String
        Public Property AdditionalInfo() As String
            Get
                Return strAdditionalInfo
            End Get
            Set(ByVal value As String)
                strAdditionalInfo = value
            End Set
        End Property

        Private intPlayVisited As Integer
        Public Property PlayVisited() As Integer
            Get
                Return intPlayVisited
            End Get
            Set(ByVal value As Integer)
                intPlayVisited = value
            End Set
        End Property

        Private intBuyVisited As Integer
        Public Property BuyVisited() As Integer
            Get
                Return intBuyVisited
            End Get
            Set(ByVal value As Integer)
                intBuyVisited = value
            End Set
        End Property

        Private intUnsubscribe As Integer
        Public Property Unsubscribe() As Integer
            Get
                Return intUnsubscribe
            End Get
            Set(ByVal value As Integer)
                intUnsubscribe = value
            End Set
        End Property

        Private intBlocked As Integer
        Public Property Blocked() As Integer
            Get
                Return intBlocked
            End Get
            Set(ByVal value As Integer)
                intBlocked = value
            End Set
        End Property

        Private dtBlockedWhenx As DateTime
        Public Property BlockedWhenx() As DateTime
            Get
                Return dtBlockedWhenx
            End Get
            Set(ByVal value As DateTime)
                dtBlockedWhenx = value
            End Set
        End Property

    End Class

End Namespace
