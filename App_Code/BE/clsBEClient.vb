Imports Microsoft.VisualBasic

Namespace PlaceTheBall.BE

    Public Class clsBEClient

        Private intClientId As Integer
        Public Property ClientId() As Integer
            Get
                Return intClientId
            End Get
            Set(ByVal value As Integer)
                intClientId = value
            End Set
        End Property

        Private strName1 As String
        Public Property Name1() As String
            Get
                Return strName1
            End Get
            Set(ByVal value As String)
                strName1 = value
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

        Private intCompanyId As Integer
        Public Property CompanyId() As Integer
            Get
                Return intCompanyId
            End Get
            Set(ByVal value As Integer)
                intCompanyId = value
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

        Private dtLastLogin As DateTime
        Public Property LastLogin() As DateTime
            Get
                Return dtLastLogin
            End Get
            Set(ByVal value As DateTime)
                dtLastLogin = value
            End Set
        End Property

        Private dtDateAdded As DateTime
        Public Property DateAdded() As DateTime
            Get
                Return dtDateAdded
            End Get
            Set(ByVal value As DateTime)
                dtDateAdded = value
            End Set
        End Property

        Private strPasswordx As String
        Public Property Passwordx() As String
            Get
                Return strPasswordx
            End Get
            Set(ByVal value As String)
                strPasswordx = value
            End Set
        End Property

        Private blnExhibitionx As Boolean
        Public Property Exhibitionx() As Boolean
            Get
                Return blnExhibitionx
            End Get
            Set(ByVal value As Boolean)
                blnExhibitionx = value
            End Set
        End Property

        Private strVerifiedx As String
        Public Property Verifiedx() As String
            Get
                Return strVerifiedx
            End Get
            Set(ByVal value As String)
                strVerifiedx = value
            End Set
        End Property

    End Class

End Namespace