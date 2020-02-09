Namespace TKPC.Entity
    Public Class BookBarcodeEnt
        Private mBarcodeID As String
        Private mBookID As String
        Private mBarcode As String
        Private mPurchaseOrDonateDate As String
        Private mPurchaseOrDonateSource As String
        Private mPurchaseOrDonate As String
        Private mNote As String
        Private mLastUpdateDate As String
        Private mPrice As String
        Private mRentPersonID As String
        Private mRentPersonName As String
        Private mRentPersonTitle As String
        Private mStatus As String

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

        Public Property barcode() As String
            Get
                Return mBarcode
            End Get
            Set(ByVal a As String)
                mBarcode = a
            End Set
        End Property

        Public Property purchaseOrDonateDate() As String
            Get
                Return mPurchaseOrDonateDate
            End Get
            Set(ByVal a As String)
                mPurchaseOrDonateDate = a
            End Set
        End Property

        Public Property purchaseOrDonateSource() As String
            Get
                Return mPurchaseOrDonateSource
            End Get
            Set(ByVal a As String)
                mPurchaseOrDonateSource = a
            End Set
        End Property

        Public Property purchaseOrDonate() As String
            Get
                Return mPurchaseOrDonate
            End Get
            Set(ByVal a As String)
                mPurchaseOrDonate = a
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

        Public Property price() As String
            Get
                Return mPrice
            End Get
            Set(ByVal a As String)
                mPrice = a
            End Set
        End Property

        Public Property rentPersonID() As String
            Get
                Return mRentPersonID
            End Get
            Set(ByVal a As String)
                mRentPersonID = a
            End Set
        End Property
        Public Property rentPersonName() As String
            Get
                Return mRentPersonName
            End Get
            Set(ByVal a As String)
                mRentPersonName = a
            End Set
        End Property

        Public Property rentPersonTitle() As String
            Get
                Return mRentPersonTitle
            End Get
            Set(ByVal a As String)
                mRentPersonTitle = a
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
