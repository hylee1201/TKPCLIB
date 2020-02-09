Namespace TKPC.Entity
    Public Class PersonEnt
        Private mPersonID As String
        Private mName As String
        Private mGender As String
        Private mPersonTitle As String
        Private mPersonTitleID As String
        Private mStreet As String
        Private mCity As String
        Private mZipCode As String
        Private mHomeTel As String
        Private mOtherTel As String
        Private mEmail As String
        Private mRegistrationDate As String
        Private mNote As String
        Private mLastUpdateDate As String
        Private mLoginLevel As String
        Private mLoginPassword As String
        Private mLoginID As String

        Public Property personID() As String
            Get
                Return mPersonID
            End Get
            Set(ByVal a As String)
                mPersonID = a
            End Set
        End Property

        Public Property name() As String
            Get
                Return mName
            End Get
            Set(ByVal a As String)
                mName = a
            End Set
        End Property

        Public Property gender() As String
            Get
                Return mGender
            End Get
            Set(ByVal a As String)
                mGender = a
            End Set
        End Property

        Public Property personTitle() As String
            Get
                Return mPersonTitle
            End Get
            Set(ByVal a As String)
                mPersonTitle = a
            End Set
        End Property

        Public Property personTitleID() As String
            Get
                Return mPersonTitleID
            End Get
            Set(ByVal a As String)
                mPersonTitleID = a
            End Set
        End Property

        Public Property street() As String
            Get
                Return mStreet
            End Get
            Set(ByVal a As String)
                mStreet = a
            End Set
        End Property

        Public Property city() As String
            Get
                Return mCity
            End Get
            Set(ByVal a As String)
                mCity = a
            End Set
        End Property

        Public Property zipCode() As String
            Get
                Return mZipCode
            End Get
            Set(ByVal a As String)
                mZipCode = a
            End Set
        End Property

        Public Property homeTel() As String
            Get
                Return mHomeTel
            End Get
            Set(ByVal a As String)
                mHomeTel = a
            End Set
        End Property

        Public Property otherTel() As String
            Get
                Return mOtherTel
            End Get
            Set(ByVal a As String)
                mOtherTel = a
            End Set
        End Property

        Public Property email() As String
            Get
                Return mEmail
            End Get
            Set(ByVal a As String)
                mEmail = a
            End Set
        End Property

        Public Property registrationDate() As String
            Get
                Return mRegistrationDate
            End Get
            Set(ByVal a As String)
                mRegistrationDate = a
            End Set
        End Property

        Public Property note() As String
            Get
                Return mNote
            End Get
            Set(ByVal a As String)
                mNote = a
            End Set
        End Property

        Public Property lastUpdateDate() As String
            Get
                Return mLastUpdateDate
            End Get
            Set(ByVal a As String)
                mLastUpdateDate = a
            End Set
        End Property

        Public Property loginLevel() As String
            Get
                Return mLoginLevel
            End Get
            Set(ByVal a As String)
                mLoginLevel = a
            End Set
        End Property

        Public Property loginPassword() As String
            Get
                Return mLoginPassword
            End Get
            Set(ByVal a As String)
                mLoginPassword = a
            End Set
        End Property

        Public Property loginID() As String
            Get
                Return mLoginID
            End Get
            Set(ByVal a As String)
                mLoginID = a
            End Set
        End Property
    End Class
End Namespace
