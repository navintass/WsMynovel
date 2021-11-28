Public Class PRODUCT_CLS
    Private _id As String
    Public Property id() As String
        Get
            Return _id
        End Get
        Set(ByVal value As String)
            _id = value
        End Set
    End Property


    Private _Ida As Integer
    Public Property Ida() As Integer
        Get
            Return _Ida
        End Get
        Set(ByVal value As Integer)
            _Ida = value
        End Set
    End Property


    Private _ProductPrice As Double
    Public Property ProductPrice() As Double
        Get
            Return _ProductPrice
        End Get
        Set(ByVal value As Double)
            _ProductPrice = value
        End Set
    End Property


    Private _ProductName As String
    Public Property ProductName() As String
        Get
            Return _ProductName
        End Get
        Set(ByVal value As String)
            _ProductName = value
        End Set
    End Property


    Private _ProductIntro As String
    Public Property ProductIntro() As String
        Get
            Return _ProductIntro
        End Get
        Set(ByVal value As String)
            _ProductIntro = value
        End Set
    End Property

    Private _CreateBy As String
    Public Property CreateBy() As String
        Get
            Return _CreateBy
        End Get
        Set(ByVal value As String)
            _CreateBy = value
        End Set
    End Property

    Private _CreateId As String
    Public Property CreateId() As String
        Get
            Return _CreateId
        End Get
        Set(ByVal value As String)
            _CreateId = value
        End Set
    End Property

    Private _ProductView As Integer
    Public Property ProductView() As Integer
        Get
            Return _ProductView
        End Get
        Set(ByVal value As Integer)
            _ProductView = value
        End Set
    End Property

    Private _ProductGroup As String
    Public Property ProductGroup() As String
        Get
            Return _ProductGroup
        End Get
        Set(ByVal value As String)
            _ProductGroup = value
        End Set
    End Property

    Private _ProductTypeSet As String
    Public Property ProductTypeSet() As String
        Get
            Return _ProductTypeSet
        End Get
        Set(ByVal value As String)
            _ProductTypeSet = value
        End Set
    End Property

    Private _isPublish As Boolean
    Public Property isPublish() As Boolean
        Get
            Return _isPublish
        End Get
        Set(ByVal value As Boolean)
            _isPublish = value
        End Set
    End Property

    Private _isFinished As Boolean
    Public Property isFinished() As Boolean
        Get
            Return _isFinished
        End Get
        Set(ByVal value As Boolean)
            _isFinished = value
        End Set
    End Property



    Private _ImageUrl As String
    Public Property ImageUrl() As String
        Get
            Return _ImageUrl
        End Get
        Set(ByVal value As String)
            _ImageUrl = value
        End Set
    End Property

    Private _ImageBanner As String
    Public Property ImageBanner() As String
        Get
            Return _ImageBanner
        End Get
        Set(ByVal value As String)
            _ImageBanner = value
        End Set
    End Property

    Private _EpCountPublised As Integer
    Public Property EpCountPublised() As Integer
        Get
            Return _EpCountPublised
        End Get
        Set(ByVal value As Integer)
            _EpCountPublised = value
        End Set
    End Property

    Private _ProductRate As String
    Public Property ProductRate() As String
        Get
            Return _ProductRate
        End Get
        Set(ByVal value As String)
            _ProductRate = value
        End Set
    End Property



    Private _ProductPublisher As String
    Public Property ProductPublisher() As String
        Get
            Return _ProductPublisher
        End Get
        Set(ByVal value As String)
            _ProductPublisher = value
        End Set
    End Property


    Private _isAccept As Boolean
    Public Property isAccept() As Boolean
        Get
            Return _isAccept
        End Get
        Set(ByVal value As Boolean)
            _isAccept = value
        End Set
    End Property

    'Private _EpLastUpdate As DateTime
    'Public Property EpLastUpdate() As DateTime
    '    Get
    '        Return _EpLastUpdate
    '    End Get
    '    Set(ByVal value As DateTime)
    '        _EpLastUpdate = value
    '    End Set
    'End Property


    Private _ProductType As String
    Public Property ProductType() As String
        Get
            Return _ProductType
        End Get
        Set(ByVal value As String)
            _ProductType = value
        End Set
    End Property

    Private _isCopyright As Boolean
    Public Property isCopyright() As Boolean
        Get
            Return _isCopyright
        End Get
        Set(ByVal value As Boolean)
            _isCopyright = value
        End Set
    End Property

    Private _FanClubTranslate As String
    Public Property FanClubTranslate() As String
        Get
            Return _FanClubTranslate
        End Get
        Set(ByVal value As String)
            _FanClubTranslate = value
        End Set
    End Property
End Class


Public Class type_banner
    Private _type As String
    Public Property type() As String
        Get
            Return _type
        End Get
        Set(ByVal value As String)
            _type = value
        End Set
    End Property

    Private _type_set As String
    Public Property type_set() As String
        Get
            Return _type_set
        End Get
        Set(ByVal value As String)
            _type_set = value
        End Set
    End Property

    Private _section As String
    Public Property section() As String
        Get
            Return _section
        End Get
        Set(ByVal value As String)
            _section = value
        End Set
    End Property
End Class


Public Class filter_product
    Private _fanClubTranslate As String
    Public Property fanClubTranslate() As String
        Get
            Return _fanClubTranslate
        End Get
        Set(ByVal value As String)
            _fanClubTranslate = value
        End Set
    End Property

    Private _isCopyright As String
    Public Property isCopyright() As String
        Get
            Return _isCopyright
        End Get
        Set(ByVal value As String)
            _isCopyright = value
        End Set
    End Property

    Private _ProductTypeSet As String
    Public Property ProductTypeSet() As String
        Get
            Return _ProductTypeSet
        End Get
        Set(ByVal value As String)
            _ProductTypeSet = value
        End Set
    End Property
End Class
