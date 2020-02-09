Namespace TKPC.Entity
    Public Class BarcodePrintEnt
        Private mBookTypeID As String
        Private mStart As String
        Private mLastUpdateDate As String

        Public Property bookTypeID() As String
            Get
                Return mBookTypeID
            End Get
            Set(ByVal a As String)
                mBookTypeID = a
            End Set
        End Property

        Public Property start() As String
            Get
                Return mStart
            End Get
            Set(ByVal a As String)
                mStart = a
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
    End Class
End Namespace