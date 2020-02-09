Namespace TKPC.Entity
    Public Class RentBookEnt
        Private mRentBookID As String
        Private mBarcodeID As String
        Private mBookID As String
        Private mBookTitle As String
        Private mBookSubtitle As String
        Private mBookAuthor As String
        Private mBookPublisher As String
        Private mBookType As String
        Private mReturnDate As String
        Private mLost As Boolean
        Private mPenalty As String
        Private mNote As String
        Private mLastUpdateDate As String
        Private mFlag As Integer
        Private mRentDate As String
        Private mPersonID As String
        Private mPersonName As String
        Private mBarcode As String
        Private mStatus As String

        Public Property rentBookID() As String
            Get
                Return mRentBookID
            End Get
            Set(ByVal a As String)
                mRentBookID = a
            End Set
        End Property

        Public Property barcodeID() As String
            Get
                Return mBarcodeID
            End Get
            Set(ByVal a As String)
                mBarcodeID = a
            End Set
        End Property

        Public Property bookID() As String
            Get
                Return mBookID
            End Get
            Set(ByVal a As String)
                mBookID = a
            End Set
        End Property

        Public Property bookTitle() As String
            Get
                Return mBookTitle
            End Get
            Set(ByVal a As String)
                mBookTitle = a
            End Set
        End Property

        Public Property bookSubtitle() As String
            Get
                Return mBookSubtitle
            End Get
            Set(ByVal a As String)
                mBookSubtitle = a
            End Set
        End Property

        Public Property bookAuthor() As String
            Get
                Return mBookAuthor
            End Get
            Set(ByVal a As String)
                mBookAuthor = a
            End Set
        End Property

        Public Property bookPublisher() As String
            Get
                Return mBookPublisher
            End Get
            Set(ByVal a As String)
                mBookPublisher = a
            End Set
        End Property

        Public Property bookType() As String
            Get
                Return mBookType
            End Get
            Set(ByVal a As String)
                mBookType = a
            End Set
        End Property

        Public Property returnDate() As String
            Get
                Return mReturnDate
            End Get
            Set(ByVal a As String)
                mReturnDate = a
            End Set
        End Property

        Public Property lost() As Boolean
            Get
                Return mLost
            End Get
            Set(ByVal a As Boolean)
                mLost = a
            End Set
        End Property

        Public Property penalty() As String
            Get
                Return mPenalty
            End Get
            Set(ByVal a As String)
                mPenalty = a
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

        Public Property flag() As Integer
            Get
                Return mFlag
            End Get
            Set(ByVal a As Integer)
                mFlag = a
            End Set
        End Property

        Public Property rentDate() As String
            Get
                Return mRentDate
            End Get
            Set(ByVal a As String)
                mRentDate = a
            End Set
        End Property

        Public Property personID() As String
            Get
                Return mPersonID
            End Get
            Set(ByVal a As String)
                mPersonID = a
            End Set
        End Property

        Public Property personName() As String
            Get
                Return mPersonName
            End Get
            Set(ByVal a As String)
                mPersonName = a
            End Set
        End Property

        Public Property barcode() As String
            Get
                Return mBarcode
            End Get
            Set(ByVal a As String)
                mBarcode = a
            End Set
        End Property

        Public Property status() As String
            Get
                Return mStatus
            End Get
            Set(ByVal a As String)
                mStatus = a
            End Set
        End Property
    End Class
End Namespace
