Public Class MODEL_APP
    Private _FUNC_RESULT As New Object
    Public Property FUNC_RESULT() As Object
        Get
            Return _FUNC_RESULT
        End Get
        Set(ByVal value As Object)
            _FUNC_RESULT = value
        End Set
    End Property

    Private _ID As String
    Public Property ID() As String
        Get
            Return _ID
        End Get
        Set(ByVal value As String)
            _ID = value
        End Set
    End Property


    Private _PRODUCT As New product
    Public Property PRODUCT() As product
        Get
            Return _PRODUCT
        End Get
        Set(ByVal value As product)
            _PRODUCT = value
        End Set
    End Property


    Private _LIST_PRODUCT As New List(Of product)
    Public Property LIST_PRODUCT() As List(Of product)
        Get
            Return _LIST_PRODUCT
        End Get
        Set(ByVal value As List(Of product))
            _LIST_PRODUCT = value
        End Set
    End Property



    Private _LIST_PRODUCT_BANNER As New List(Of PRODUCT_CLS)
    Public Property LIST_PRODUCT_BANNER() As List(Of PRODUCT_CLS)
        Get
            Return _LIST_PRODUCT_BANNER
        End Get
        Set(ByVal value As List(Of PRODUCT_CLS))
            _LIST_PRODUCT_BANNER = value
        End Set
    End Property


    Private _ListUserReadHistory As New List(Of UserReadHistory)
    Public Property ListUserReadHistory() As List(Of UserReadHistory)
        Get
            Return _ListUserReadHistory
        End Get
        Set(ByVal value As List(Of UserReadHistory))
            _ListUserReadHistory = value
        End Set
    End Property



    Private _UserReadHistory As New UserReadHistory
    Public Property UserReadHistory() As UserReadHistory
        Get
            Return _UserReadHistory
        End Get
        Set(ByVal value As UserReadHistory)
            _UserReadHistory = value
        End Set
    End Property

End Class
