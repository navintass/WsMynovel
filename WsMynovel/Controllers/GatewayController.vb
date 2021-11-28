Imports System.IO
Imports System.Net
Imports System.Web.Mvc
Imports System.Web.Script.Serialization

Namespace Controllers
    Public Class GatewayController
        Inherits Controller

        ' GET: Gateway
        Function Index() As ActionResult
            Return View()
        End Function

        Function test() As ActionResult
            Return View()
        End Function

        Function update_product() As ActionResult
            Return View()
        End Function



        Function SET_FULL_MODEL() As JsonResult
            Dim CLS_MODEL As New MODEL_APP
            Return Json(CLS_MODEL, JsonRequestBehavior.AllowGet)
        End Function

        <HttpPost>
        Function GET_DATA_ALL() As JsonResult
            Dim dao As New DAO.tb_product
            dao.GetDataAll()
            Return Json(dao.Details, JsonRequestBehavior.AllowGet)
        End Function

        <HttpPost>
        Function GET_NOVEL() As JsonResult
            Dim dao As New DAO.tb_product
            dao.GetNovel()
            Return Json(dao.Details, JsonRequestBehavior.AllowGet)
        End Function


        <HttpPost>
        Function GET_NOVEL_FIC() As JsonResult
            Dim dao As New DAO.tb_product
            dao.GetNovelFic()
            Return Json(dao.Details, JsonRequestBehavior.AllowGet)
        End Function

        <HttpPost>
        Function GET_NOVEL_FAN() As JsonResult
            Dim dao As New DAO.tb_product
            dao.GetNovelFan()
            Return Json(dao.Details, JsonRequestBehavior.AllowGet)
        End Function

        <HttpPost>
        Function GET_CARTOON() As JsonResult
            Dim dao As New DAO.tb_product
            dao.GetCartoon()
            Return Json(dao.Details, JsonRequestBehavior.AllowGet)
        End Function

        <HttpPost>
        Function GET_CARTOON_THAI() As JsonResult
            Dim dao As New DAO.tb_product
            dao.GetCartoonThai()
            Return Json(dao.Details, JsonRequestBehavior.AllowGet)
        End Function


        <HttpPost>
        Function GET_NEW_EBOOK() As JsonResult
            Dim dao As New DAO.tb_product
            dao.GetEbookNew()
            Return Json(dao.Details, JsonRequestBehavior.AllowGet)
        End Function


        <HttpGet>
        Function GET_PRODUCT_GROUP(ByVal group As String, ByVal type As String, ByVal id As String, ByVal main_group As String) As JsonResult
            Dim dao As New DAO.tb_product
            dao.GetProductGroup(group, type, id, main_group)
            Return Json(dao.Details, JsonRequestBehavior.AllowGet)
        End Function





        <HttpGet>
        Function UPDATE_TIME_EP(ByVal id As String) As JsonResult
            Dim dao As New DAO.tb_product
            dao.Getdata_byid(id)
            dao.fields.EpLastUpdate = Date.Now
            dao.update()
            Return Json("success", JsonRequestBehavior.AllowGet)
        End Function


        Function INSERT_DATA(ByVal MODEL As String) As JsonResult
            Dim MODEL_APP As New MODEL_APP
            Dim jss As New JavaScriptSerializer
            MODEL_APP = jss.Deserialize(JSON_CONVERT_DATE(MODEL), GetType(MODEL_APP))
            For Each row In MODEL_APP.LIST_PRODUCT
                Dim dao As New DAO.tb_product
                dao.Getdata_byid(row.id)
                If dao.fields.ida = 0 Then
                    dao.fields = row
                    dao.fields.ProductView = 1
                    If row.ProductTypeSet = "Ebook" Then
                        dao.fields.isCopyright = 1
                        dao.fields.ProductView = 1
                        dao.fields.EpCountPublised = 0
                        dao.fields.isFinished = 1
                    End If
                    dao.insert()
                Else
                    dao.fields.ImageUrl = row.ImageUrl
                    dao.fields.isCopyright = row.isCopyright Or 0
                    dao.fields.CreateBy = row.CreateBy
                    dao.fields.CreateId = row.CreateId
                    dao.fields.EpCountPublised = row.EpCountPublised Or 0
                    dao.fields.fanClubTranslate = row.fanClubTranslate
                    dao.fields.isPublish = row.isPublish Or 0
                    dao.fields.ProductType = row.ProductType
                    dao.fields.ProductTypeSet = row.ProductTypeSet
                    dao.fields.ProductView = row.ProductView Or 0
                    dao.fields.ProductName = row.ProductName
                    dao.fields.ProductIntro = row.ProductIntro
                    dao.fields.ProductRate = row.ProductRate
                    dao.fields.ProductGroup = row.ProductGroup
                    dao.fields.ProductPublisher = row.CreateBy
                    dao.fields.isFinished = row.isFinished Or 0
                    dao.fields.ProductPrice = row.ProductPrice Or 0
                    If row.ProductTypeSet = "Ebook" Then
                        dao.fields.isCopyright = 1
                        dao.fields.ProductView = 1
                        dao.fields.EpCountPublised = 0
                        dao.fields.isFinished = 1
                    End If
                    dao.update()
                End If
            Next
            Return Json("success", JsonRequestBehavior.AllowGet)
        End Function

        Function ADD_PRODUCT(ByVal model As String) As JsonResult
            Dim MODEL_APP As New MODEL_APP
            Dim jss As New JavaScriptSerializer
            Dim dao As New DAO.tb_product
            Try
                MODEL_APP.PRODUCT = jss.Deserialize(JSON_CONVERT_DATE(model), GetType(product))
                dao.Getdata_byid(MODEL_APP.PRODUCT.id)
                If dao.fields.ida = 0 Then
                    dao.fields = MODEL_APP.PRODUCT
                    dao.fields.EpLastUpdate = Date.Now
                    dao.fields.ProductView = 1
                    dao.fields.isAccept = False
                    If MODEL_APP.PRODUCT.ProductTypeSet = "Ebook" Then
                        dao.fields.isCopyright = 1
                        dao.fields.ProductView = 1
                        dao.fields.EpCountPublised = 0
                    End If
                    dao.insert()
                    If MODEL_APP.PRODUCT.isPublish = True Then
                        PREPARE_NOTIFY_LINE(MODEL_APP.PRODUCT)
                    End If
                Else
                    dao.fields.ImageUrl = MODEL_APP.PRODUCT.ImageUrl
                    dao.fields.isCopyright = MODEL_APP.PRODUCT.isCopyright Or 0
                    'dao.fields.CreateBy = MODEL_APP.PRODUCT.CreateBy
                    '    dao.fields.ProductPublisher = MODEL_APP.PRODUCT.CreateBy
                    dao.fields.CreateId = MODEL_APP.PRODUCT.CreateId
                    dao.fields.EpCountPublised = MODEL_APP.PRODUCT.EpCountPublised Or 0
                    dao.fields.fanClubTranslate = MODEL_APP.PRODUCT.fanClubTranslate
                    dao.fields.isPublish = MODEL_APP.PRODUCT.isPublish Or 0
                    dao.fields.ProductGroup = MODEL_APP.PRODUCT.ProductGroup
                    dao.fields.ProductType = MODEL_APP.PRODUCT.ProductType
                    dao.fields.ProductTypeSet = MODEL_APP.PRODUCT.ProductTypeSet
                    dao.fields.ProductView = MODEL_APP.PRODUCT.ProductView Or 1
                    dao.fields.ProductName = MODEL_APP.PRODUCT.ProductName
                    dao.fields.ProductIntro = MODEL_APP.PRODUCT.ProductIntro
                    dao.fields.ProductRate = MODEL_APP.PRODUCT.ProductRate
                    dao.fields.isFinished = MODEL_APP.PRODUCT.isFinished Or 0
                    dao.fields.ProductPrice = MODEL_APP.PRODUCT.ProductPrice Or 0
                    dao.fields.isAccept = True
                    If MODEL_APP.PRODUCT.ProductTypeSet = "Ebook" Then
                        dao.fields.isCopyright = 1
                        dao.fields.ProductView = 1
                        dao.fields.EpCountPublised = 0
                        dao.fields.isFinished = True
                    End If
                    dao.update()
                End If
                Return Json("success", JsonRequestBehavior.AllowGet)
            Catch ex As Exception
                Return Json("error" + ex.ToString, JsonRequestBehavior.AllowGet)
            End Try
            Return Json("success", JsonRequestBehavior.AllowGet)
        End Function

        Function UPDATE_ACCEPT(ByVal model As String) As JsonResult
            Dim MODEL_APP As New MODEL_APP
            Dim jss As New JavaScriptSerializer
            Dim dao As New DAO.tb_product
            Try
                MODEL_APP.PRODUCT = jss.Deserialize(JSON_CONVERT_DATE(model), GetType(product))
                dao.Getdata_byid(MODEL_APP.PRODUCT.id)
                If dao.fields.ida <> 0 Then
                    dao.fields.isAccept = MODEL_APP.PRODUCT.isAccept
                    dao.update()
                End If
                Return Json("success", JsonRequestBehavior.AllowGet)
            Catch ex As Exception
                Return Json("error" + ex.ToString, JsonRequestBehavior.AllowGet)
            End Try
            Return Json("success", JsonRequestBehavior.AllowGet)
        End Function


        <HttpGet>
        Function GET_PRODUCT_VERIFY() As JsonResult
            Dim dao As New DAO.tb_product
            dao.Getverify()
            Return Json(dao.Details, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Function GET_READ_HISTORY(ByVal productId As String, ByVal userId As String) As JsonResult
            Dim dao As New DAO.tb_history
            Dim model_app As New MODEL_APP
            dao.GET_READ_HISTORY(productId, userId)
            Return Json(dao.Details, JsonRequestBehavior.AllowGet)
        End Function

        <HttpPost>
        Function INSERT_HISTORY(ByVal MODEL As UserReadHistory) As JsonResult
            Dim dao As New DAO.tb_history
            dao.Getdata_byEpid(MODEL.EpId, MODEL.userId, MODEL.ProductId)
            If dao.Details.Count = 0 Then
                dao.fields = MODEL
                dao.fields.createDate = Date.Now
                dao.fields.LastRead = True
                dao.insert()
            Else
                Dim dao_update As New DAO.tb_history
                dao_update.Getdata_byEp(MODEL.EpId, MODEL.userId, MODEL.ProductId)
                dao_update.fields.LastRead = True
                dao_update.update()
                'For Each row In dao.Details
                '    If row.EpId <> MODEL.EpId Then
                '        dao.fields = MODEL
                '        dao.fields.createDate = Date.Now
                '        dao.fields.LastRead = True
                '        dao.insert()
                '    ElseIf row.EpId = MODEL.EpId Then
                '        dao.fields.createDate = Date.Now
                '        dao.fields.LastRead = True
                '        dao.update()
                '    Else
                '        'dao.fields.createDate = Date.Now
                '        dao.fields.LastRead = False
                '        dao.update()
                '    End If
                'Next
            End If
            UPDATE_CURENT_READ(MODEL)
            Return Json("SUCCESS", JsonRequestBehavior.AllowGet)
        End Function


        Function UPDATE_CURENT_READ(ByVal MODEL As UserReadHistory)
            Dim dao As New DAO.tb_history
            dao.Getdata_byUserid(MODEL.ProductId, MODEL.userId)
            For Each row In dao.Details
                If row.EpId <> MODEL.EpId Then
                    Dim dao_update As New DAO.tb_history
                    dao_update.Getdata_byEp(row.EpId, row.userId, row.ProductId)
                    dao_update.fields.LastRead = 0
                    dao_update.update()
                End If
            Next
        End Function

        <HttpGet>
        Function UPDATE_EP_DATE(ByVal p_id As String) As JsonResult
            Dim dao As New DAO.tb_product
            dao.Getdata_byid(p_id)
            If dao.fields.ida <> 0 Then
                dao.fields.EpLastUpdate = Date.Now
                dao.update()
            End If
            Return Json("SUCCESS", JsonRequestBehavior.AllowGet)
        End Function


        Sub PREPARE_NOTIFY_LINE(ByVal model As product)
            Dim msg As String = ""
            Dim token As String = "fljbYhDZ9bAOPWMPB8zZoLQYeJEYwo0fDC3uHFFEQoU"
            msg &= "เรื่อง: " & model.ProductName & Environment.NewLine
            msg &= "ผู้เผยแพร่ : " & model.ProductPublisher & Environment.NewLine
            msg &= "Link : " & "https://mynovel.co/Bookverify?Pid=" & model.id & Environment.NewLine
            SEND_NOTIFY_LINE(token, msg)
        End Sub

        Sub SEND_NOTIFY_LINE(ByVal token As String, ByVal msg As String)
            System.Net.ServicePointManager.Expect100Continue = False
            Dim request = DirectCast(WebRequest.Create(“https://notify-api.line.me/api/notify”), HttpWebRequest)
            Dim postData = String.Format("message={0}", msg)
            Dim data = Encoding.UTF8.GetBytes(postData)
            request.Method = “POST”
            request.ContentType = “application/x-www-form-urlencoded”
            request.ContentLength = data.Length
            Dim str_bearer As String = "Bearer " & token
            'request.Headers.Add(“Authorization”, “Bearer FRfBlkdfSq3bNtaBVYtIL9kMqWpohO7TlPjBL0SVApe”)
            request.Headers.Add(“Authorization”, str_bearer)
            request.AllowWriteStreamBuffering = True
            request.KeepAlive = False
            request.Credentials = CredentialCache.DefaultCredentials
            Using stream = request.GetRequestStream()
                stream.Write(data, 0, data.Length)
            End Using
            Dim response = DirectCast(request.GetResponse(), HttpWebResponse)
            Dim responseString = New StreamReader(response.GetResponseStream()).ReadToEnd()
        End Sub

        Public Function JSON_CONVERT_DATE(ByVal json As String) As String

            Dim reg = New Regex(""".*?""")
            Dim matches = reg.Matches(json)

            Dim temp As String = ""
            For Each item In matches
                If temp = "" Then
                    temp = item.ToString()
                Else
                    temp = temp & "," & item.ToString()
                End If
            Next

            Dim tempd As String = ""

            For Each ddd As String In temp.Split(",")
                If ddd.Contains("Date(") Then
                    If tempd = "" Then
                        tempd = ddd
                    Else
                        tempd = tempd & "," & ddd
                    End If
                End If
            Next

            For Each Val As String In tempd.Split(",")
                Try
                    Dim reg2 = New Regex("\(.*?\)")
                    Dim matches2 = reg2.Matches(Val)
                    For Each item2 In matches2
                        'item2 = {({(1050035680333)})}
                        Dim datas As String = item2.ToString().Replace("{", "").Replace("}", "").Replace("(", "").Replace(")", "")
                        Dim timestamp As Double = datas
                        Dim dateTime As System.DateTime = New System.DateTime(1970, 1, 1, 0, 0, 0, 0)
                        dateTime = dateTime.AddMilliseconds(timestamp)
                        If dateTime.Year > 2500 Then
                            json = json.Replace(Val, """" & dateTime.AddYears(-543).ToShortDateString() & """")
                        Else
                            Try

                            Catch ex As Exception

                            End Try
                            json = json.Replace(Val, """" & dateTime.ToShortDateString() & """")
                        End If

                    Next
                Catch ex As Exception

                End Try
            Next

            matches = reg.Matches(json)

            temp = ""
            For Each item In matches
                If temp = "" Then
                    temp = item.ToString()
                Else
                    temp = temp & "," & item.ToString()
                End If
            Next

            Dim tempd2 As String = ""
            For Each ddd As String In temp.Split(",")

                If ddd.Contains("/") Then
                    Dim aa As Array = ddd.Split("/")
                    If tempd2 = "" Then

                        If aa.Length >= 2 Then
                            tempd2 = ddd
                        End If

                    Else
                        If aa.Length >= 2 Then
                            tempd2 = tempd2 & "," & ddd
                        End If
                    End If

                End If
            Next
            For Each Val As String In tempd2.Split(",")

                Try
                    'Val = Val.Replace("""", "")
                    Dim ar As Array = Val.Replace("""", "").Split("/")
                    Dim chk_date As String = ""
                    Dim ar2 As Array = ar(2).ToString.Split(" ")

                    If IsNumeric(ar(0)) = False Then

                        'json = Val.Replace("""", "")

                    Else

                        If ar2(0) > 2500 Then
                            ar2(0) = CInt(ar2(0)) - 543
                            Try

                                chk_date = ar(1) & "/" & ar(0) & "/" & ar2(0) & " " & ar2(1)

                            Catch ex As Exception
                                Try
                                    chk_date = ar(1) & "/" & ar(0) & "/" & ar2(0)
                                Catch ex2 As Exception
                                    chk_date = Val
                                End Try

                            End Try

                        Else
                            Try
                                chk_date = ar(0) & "/" & ar(1) & "/" & ar2(0) & " " & ar2(1)
                            Catch ex As Exception
                                Try
                                    chk_date = ar(0) & "/" & ar(1) & "/" & ar2(0)

                                Catch ex2 As Exception
                                    chk_date = Val
                                End Try
                            End Try

                        End If
                        json = json.Replace(Val, """" & chk_date & """")
                    End If

                Catch ex As Exception

                End Try
            Next
            Return json
        End Function



        <HttpPost>
        Function GET_BANNER_PRODUCT(ByVal data As type_banner) As JsonResult
            Dim dao As New DAO.tb_product_banner
            Dim cls As New MODEL_APP
            dao.GetDataAll(data.type, data.section, data.type_set)
            For Each row In dao.Details
                Dim cls_product As New PRODUCT_CLS
                Dim dao_product As New DAO.tb_product
                dao_product.Getdata_byid(row.FkProductId)
                cls_product.ProductGroup = dao_product.fields.ProductGroup
                cls_product.CreateBy = dao_product.fields.CreateId
                cls_product.CreateId = dao_product.fields.CreateBy
                cls_product.FanClubTranslate = dao_product.fields.fanClubTranslate
                cls_product.id = dao_product.fields.id
                cls_product.ImageUrl = dao_product.fields.ImageUrl
                cls_product.ImageBanner = row.ImageUrl
                If dao_product.fields.ida <> 0 Then
                    cls_product.isCopyright = dao_product.fields.isCopyright
                    cls_product.isPublish = dao_product.fields.isPublish
                    cls_product.ProductView = dao_product.fields.ProductView
                    cls_product.EpCountPublised = dao_product.fields.EpCountPublised
                    cls_product.isFinished = dao_product.fields.isFinished
                End If
                cls_product.ProductIntro = dao_product.fields.ProductIntro
                cls_product.ProductName = dao_product.fields.ProductName
                cls_product.ProductPublisher = dao_product.fields.ProductPublisher
                cls_product.ProductRate = dao_product.fields.ProductRate
                cls_product.ProductType = dao_product.fields.ProductType
                cls_product.ProductTypeSet = dao_product.fields.ProductTypeSet
                cls_product.ProductPrice = dao_product.fields.ProductPrice
                cls_product.Ida = row.Ida
                cls.LIST_PRODUCT_BANNER.Add(cls_product)
            Next
            Return Json(cls.LIST_PRODUCT_BANNER, JsonRequestBehavior.AllowGet)
        End Function

    End Class
End Namespace