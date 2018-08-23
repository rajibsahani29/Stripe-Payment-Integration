Imports Microsoft.VisualBasic

Namespace PlaceTheBall.BE

    Public Class clsBECreditHistory

        Private intCreditHistoryId As Integer
        Public Property CreditHistoryId() As Integer
            Get
                Return intCreditHistoryId
            End Get
            Set(ByVal value As Integer)
                intCreditHistoryId = value
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

    End Class

End Namespace
