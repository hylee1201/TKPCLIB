Namespace TKPC.Entity
    Public Class ReserveBookEnt
        Private mReserveID As String
        Private mBookID As String
        Private mPersonID As String
        Private mReserveDate As String
        Private mLastUpdateDate As String
        Private mBarcode As String

        Public Property reserveID() As String
            Get
                Return mReserveID
            End Get
            Set(ByVal a As String)
                mReserveID = a
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

        Public Property personID() As String
            Get
                Return mPersonID
            End Get
            Set(ByVal a As String)
                mPersonID = a
            End Set
        End Property

        Public Property reserveDate() As String
            Get
                Return mReserveDate
            End Get
            Set(ByVal a As String)
                mReserveDate = a
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
        Public Property barcode() As String
            Get
                Return mBarcode
            End Get
            Set(ByVal a As String)
                mBarcode = a
            End Set
        End Property
    End Class
End Namespace