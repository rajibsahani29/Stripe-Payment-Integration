Imports Microsoft.VisualBasic

Namespace PlaceTheBall.BE

    Public Class clsBEBalls

        Private intBallId As Integer
        Public Property BallId() As Integer
            Get
                Return intBallId
            End Get
            Set(ByVal value As Integer)
                intBallId = value
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

        Private intGameId As Integer
        Public Property GameId() As Integer
            Get
                Return intGameId
            End Get
            Set(ByVal value As Integer)
                intGameId = value
            End Set
        End Property

        Private dblPosx As Double
        Public Property Posx() As Double
            Get
                Return dblPosx
            End Get
            Set(ByVal value As Double)
                dblPosx = value
            End Set
        End Property

        Private dblPosy As Double
        Public Property Posy() As Double
            Get
                Return dblPosy
            End Get
            Set(ByVal value As Double)
                dblPosy = value
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

        Private intVerifyx As Integer
        Public Property Verifyx() As Integer
            Get
                Return intVerifyx
            End Get
            Set(ByVal value As Integer)
                intVerifyx = value
            End Set
        End Property

        Private intRandomx As Integer
        Public Property Randomx() As Integer
            Get
                Return intRandomx
            End Get
            Set(ByVal value As Integer)
                intRandomx = value
            End Set
        End Property

        Private intWonx As Integer
        Public Property Wonx() As Integer
            Get
                Return intWonx
            End Get
            Set(ByVal value As Integer)
                intWonx = value
            End Set
        End Property

        Private strDistx As String
        Public Property Distx() As String
            Get
                Return strDistx
            End Get
            Set(ByVal value As String)
                strDistx = value
            End Set
        End Property

    End Class

End Namespace
