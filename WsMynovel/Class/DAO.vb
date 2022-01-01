Namespace DAO
    Public MustInherit Class MAINCONTEXT1
        Public db As New Linq_dbDataContext
        Public datas


        Public Interface MAIN
            Sub insert()
            Sub delete()
            Sub update()
        End Interface
    End Class


    Public Class tb_product
        Inherits MAINCONTEXT1
        Public fields As New product
        Private _Details As New List(Of product)
        Public Property Details() As List(Of product)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of product))
                _Details = value
            End Set
        End Property
        Public Sub AddDetails()
            Details.Add(fields)
            fields = New product
        End Sub
        Public Sub delete()
            db.products.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub insert()
            db.products.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub update()
            db.SubmitChanges()
        End Sub



        Public Sub Getdata_byid(ByVal id As String)
            datas = (From q In db.products Where q.id = id Select q)
            For Each Me.fields In datas

            Next
        End Sub


        Public Sub Getdata_byid_createId(ByVal id As String, ByVal create_id As String)
            datas = (From q In db.products Where q.id = id And q.CreateId = create_id Select q)
            For Each Me.fields In datas

            Next
        End Sub

        Public Sub GET_DATA_BY_CREATE_ID(ByVal id As String)
            datas = (From p In db.products Where p.isPublish = True And p.isAccept = True And p.CreateId = id Select p Order By p.ProductName Ascending)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.products Where p.isPublish = True And p.isAccept = True Select p Order By p.ProductName Ascending)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

        Public Sub GetDataFilter(ByVal fanClubTranslate As String, ByVal isCopyright As String, ByVal ProductTypeSet As String)
            datas = (From p In db.products Where p.fanClubTranslate = fanClubTranslate And p.isCopyright = isCopyright And p.ProductTypeSet = ProductTypeSet Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

        Public Sub Getverify()
            datas = (From p In db.products Where p.isPublish = True And p.isAccept = False Select p Order By p.EpLastUpdate Ascending)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

        Public Sub GetNovel()
            datas = (From p In db.products Where p.isCopyright = True And p.isAccept = True And p.isPublish = True And p.ProductTypeSet = "Novel" Select p Order By p.EpLastUpdate Descending).Take(18)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

        Public Sub GetProductGroup(ByVal group As String, ByVal type As String, ByVal id As String, ByVal main_group As String)
            datas = (From p In db.products Where p.ProductTypeSet = type And p.isAccept = True And p.isPublish = True And p.id <> id And p.EpCountPublised > 9 And (p.ProductType = main_group Or p.ProductGroup = group) Select p Order By p.ProductView Ascending).Take(6)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

        Public Sub GetNovelFic()
            datas = (From p In db.products Where p.isCopyright = False And p.isAccept = True And p.isPublish = True And p.ProductTypeSet = "Novel" And p.fanClubTranslate = "นิยายแต่ง" Select p Order By p.EpLastUpdate Descending).Take(18)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub


        Public Sub GetNovelFan()
            datas = (From p In db.products Where p.isCopyright = False And p.isAccept = True And p.isPublish = True And p.ProductTypeSet = "Novel" And p.fanClubTranslate = "นิยายแปล" Select p Order By p.EpLastUpdate Descending).Take(18)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

        Public Sub GetCartoon()
            datas = (From p In db.products Where p.isCopyright = False And p.isAccept = True And p.isPublish = True And p.ProductTypeSet = "Cartoon" Select p Order By p.EpLastUpdate Descending).Take(18)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

        Public Sub GetCartoonThai()
            datas = (From p In db.products Where p.isCopyright = True And p.isAccept = True And p.ProductTypeSet = "Cartoon" Select p Order By p.EpLastUpdate Descending).Take(18)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

        Public Sub GetEbookNew()
            datas = (From p In db.products Where p.ProductTypeSet = "Ebook" Select p Order By p.EpLastUpdate Descending).Take(18)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub


        Public Sub GetDataByType(ByVal type As String)
            datas = (From p In db.products Where p.ProductTypeSet = type Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub


    End Class


    Public Class tb_history
        Inherits MAINCONTEXT1
        Public fields As New UserReadHistory
        Private _Details As New List(Of UserReadHistory)
        Public Property Details() As List(Of UserReadHistory)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of UserReadHistory))
                _Details = value
            End Set
        End Property
        Public Sub AddDetails()
            Details.Add(fields)
            fields = New UserReadHistory
        End Sub
        Public Sub delete()
            db.UserReadHistories.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub insert()
            db.UserReadHistories.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub GET_READ_HISTORY(ByVal product_id As String, ByVal user_id As String)
            datas = (From q In db.UserReadHistories Where q.userId = user_id And q.ProductId = product_id Select q)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

        Public Sub GetDataAll()
            datas = (From p In db.UserReadHistories Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub

        Public Sub Getdata_byEpid(ByVal EpId As String, ByVal userId As String, ByVal ProductId As String)
            datas = (From q In db.UserReadHistories Where q.EpId = EpId And q.userId = userId And q.ProductId = ProductId Select q)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub


        Public Sub Getdata_byEp(ByVal EpId As String, ByVal userId As String, ByVal ProductId As String)
            datas = (From q In db.UserReadHistories Where q.EpId = EpId And q.userId = userId And q.ProductId = ProductId Select q)
            For Each Me.fields In datas

            Next
        End Sub


        Public Sub Getdata_byUserid(ByVal ProductId As String, ByVal userId As String)
            datas = (From q In db.UserReadHistories Where q.ProductId = ProductId And q.userId = userId Select q)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub






    End Class


    Public Class tb_product_banner
        Inherits MAINCONTEXT1
        Public fields As New ProductBanner
        Private _Details As New List(Of ProductBanner)
        Public Property Details() As List(Of ProductBanner)
            Get
                Return _Details
            End Get
            Set(ByVal value As List(Of ProductBanner))
                _Details = value
            End Set
        End Property
        Public Sub AddDetails()
            Details.Add(fields)
            fields = New ProductBanner
        End Sub
        Public Sub delete()
            db.ProductBanners.DeleteOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub insert()
            db.ProductBanners.InsertOnSubmit(fields)
            db.SubmitChanges()
        End Sub

        Public Sub update()
            db.SubmitChanges()
        End Sub

        Public Sub GetDataAll(ByVal type As String, ByVal section As String, ByVal type_set As String)
            datas = (From p In db.ProductBanners Where p.Type = type And p.Section = section And p.TypeSet = type_set Select p)
            For Each Me.fields In datas
                AddDetails()
            Next
        End Sub


        Public Sub Getdata_byIda(ByVal IDA As Integer)
            datas = (From q In db.ProductBanners Where q.Ida = IDA Select q)
            For Each Me.fields In datas

            Next
        End Sub
    End Class




End Namespace