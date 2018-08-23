Imports Microsoft.VisualBasic

Namespace PlaceTheBall.BE

    Public Class clsBECreditHistoryTemp

        Private intCreditHistoryTempId As Integer
        Public Property CreditHistoryTempId() As Integer
            Get
                Return intCreditHistoryTempId
            End Get
            Set(ByVal value As Integer)
                intCreditHistoryTempId = value
            End Set
        End Property

        Private intUserId As Integer
        Public Property UserId() As Integer
            Get
                Return intUserId
            End Get
            Set(ByVal value As Integer)
                intUserId = value
            End Set
        End Property

        Private intCreditx As Integer
        Public Property Creditx() As Integer
            Get
                Return intCreditx
            End Get
            Set(ByVal value As Integer)
                intCreditx = value
            End Set
        End Property

        Private dtWhenx As DateTime
        Public Property Whenx() As DateTime
            Get
                Return dtWhenx
            End Get
            Set(ByVal value As DateTime)
                dtWhenx = value
            End Set
        End Property

        Private intPaymentMethodId As Integer
        Public Property PaymentMethodId() As Integer
            Get
                Return intPaymentMethodId
            End Get
            Set(ByVal value As Integer)
                intPaymentMethodId = value
            End Set
        End Property

        Private dblAmountTaken As Double
        Public Property AmountTaken() As Double
            Get
                Return dblAmountTaken
            End Get
            Set(ByVal value As Double)
                dblAmountTaken = value
            End Set
        End Property

        Private strRef As String
        Public Property Ref() As String
            Get
                Return strRef
            End Get
            Set(ByVal value As String)
                strRef = value
            End Set
        End Property

        Private strHistory As String
        Public Property History() As String
            Get
                Return strHistory
            End Get
            Set(ByVal value As String)
                strHistory = value
            End Set
        End Property

        Private intAuthorised As Integer
        Public Property Authorised() As Integer
            Get
                Return intAuthorised
            End Get
            Set(ByVal value As Integer)
                intAuthorised = value
            End Set
        End Property

        Private strEmailx As String
        Public Property Emailx() As String
            Get
                Return strEmailx
            End Get
            Set(ByVal value As String)
                strEmailx = value
            End Set
        End Property

    End Class

End Namespace

