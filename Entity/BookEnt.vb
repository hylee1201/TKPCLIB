Namespace TKPC.Entity
    Public Class BookEnt
        Private mBookID As String
        Private mISBN As String
        Private mTitle As String
        Private mSubtitle As String
        Private mAuthor As String
        Private mPublisher As String
        Private mBookType As String
        Private mBookTypeID As String
        Private mNote As String
        Private mLastUpdateDate As String
        Private mBookBarcodeEnt As BookBarcodeEnt
        Private mCompiler As String
        Private mAddDate As String

        Public Property bookID() As String
            Get
                Return mBookID
            End Get
            Set(ByVal a As String)
                mBookID = a
            End Set
        End Property
        Public Property ISBN() As String
            Get
                Return mISBN
            End Get
            Set(ByVal a As String)
                mISBN = a
            End Set
        End Property
        Public Property title() As String
            Get
                Return mTitle
            End Get
            Set(ByVal a As String)
                mTitle = a
            End Set
        End Property

        Public Property subtitle() As String
            Get
                Return mSubtitle
            End Get
            Set(ByVal a As String)
                mSubtitle = a
            End Set
        End Property

        Public Property author() As String
            Get
                Return mAuthor
            End Get
            Set(ByVal a As String)
                mAuthor = a
            End Set
        End Property

        Public Property publisher() As String
            Get
                Return mPublisher
            End Get
            Set(ByVal a As String)
                mPublisher = a
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

        Public Property bookTypeID() As String
            Get
                Return mBookTypeID
            End Get
            Set(ByVal a As String)
                mBookTypeID = a
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

        Public Property bookBarcodeEnt() As BookBarcodeEnt
            Get
                Return mBookBarcodeEnt
            End Get
            Set(ByVal a As BookBarcodeEnt)
                mBookBarcodeEnt = a
            End Set
        End Property

        Public Property compiler() As String
            Get
                Return mCompiler
            End Get
            Set(ByVal a As String)
                mCompiler = a
            End Set
        End Property

        Public Property addDate() As String
            Get
                Return mAddDate
            End Get
            Set(ByVal a As String)
                mAddDate = a
            End Set
        End Property
    End Class
End Namespace
