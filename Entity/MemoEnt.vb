Namespace TKPC.Entity
    Public Class MemoEnt
        Private mNote As String
        Private mType As String

        Public Property note() As String
            Get
                Return mNote
            End Get
            Set(ByVal a As String)
                mNote = a
            End Set
        End Property

        Public Property type() As String
            Get
                Return mType
            End Get
            Set(ByVal a As String)
                mType = a
            End Set
        End Property
    End Class
End Namespace
