Imports System.Web.Mvc
Imports System.Web.Script.Serialization

Namespace Controllers
    Public Class ProductsController
        Inherits Controller


        <HttpPost>
        Function GET_PRODUCT_FILTER(ByVal data As filter_product) As JsonResult
            Dim dao As New DAO.tb_product
            Dim cls As New MODEL_APP
            dao.GetDataFilter(data.fanClubTranslate, data.isCopyright, data.ProductTypeSet)
            Return Json(dao.Details, JsonRequestBehavior.AllowGet)
        End Function

        <HttpGet>
        Function GET_PRODUCT_BY_CREATE_ID(ByVal CREATE_ID As String)
            Dim dao As New DAO.tb_product
            dao.GET_DATA_BY_CREATE_ID(CREATE_ID)
            Return Json(dao.Details, JsonRequestBehavior.AllowGet)
        End Function

        <HttpPost>
        Function INSERT_BANNER_PRODDUCT(ByVal MODEL As ProductBanner) As JsonResult
            Dim dao As New DAO.tb_product_banner
            dao.Getdata_byIda(MODEL.Ida)
            If dao.fields.Ida = 0 Then
                dao.fields = MODEL
                dao.insert()
            Else
                dao.fields.ImageUrl = MODEL.ImageUrl
                dao.fields.FkProductId = MODEL.FkProductId
                dao.update()
            End If
            Return Json("SUCCESS", JsonRequestBehavior.AllowGet)
        End Function


        <HttpPost>
        Function DEL_PRODUCT_BANNER(ByVal MODEL As ProductBanner) As JsonResult
            Dim dao As New DAO.tb_product_banner
            dao.Getdata_byIda(MODEL.Ida)
            If dao.fields.Ida <> 0 Then
                dao.delete()
            End If

            Return Json("SUCCESS", JsonRequestBehavior.AllowGet)
        End Function

        <HttpPost>
        Function DELETE_PRODUCT(ByVal model As String) As JsonResult
            Dim MODEL_APP As New MODEL_APP
            Dim jss As New JavaScriptSerializer
            Dim dao As New DAO.tb_product
            Try
                MODEL_APP.PRODUCT = jss.Deserialize(JSON_CONVERT_DATE(model), GetType(product))
                dao.Getdata_byid_createId(MODEL_APP.PRODUCT.id, MODEL_APP.PRODUCT.CreateId)
                If dao.fields.ida <> 0 Then
                    dao.fields.isAccept = False
                    dao.update()
                End If
                Return Json("success", JsonRequestBehavior.AllowGet)
            Catch ex As Exception
                Return Json("error" + ex.ToString, JsonRequestBehavior.AllowGet)
            End Try
            Return Json("success", JsonRequestBehavior.AllowGet)
        End Function


        <HttpPost>
        Function UPDATE_VIEW(ByVal model As String) As JsonResult
            Dim MODEL_APP As New MODEL_APP
            Dim jss As New JavaScriptSerializer
            Dim dao As New DAO.tb_product
            Try
                MODEL_APP.PRODUCT = jss.Deserialize(JSON_CONVERT_DATE(model), GetType(product))
                dao.Getdata_byid(MODEL_APP.PRODUCT.id)
                If dao.fields.ida <> 0 Then
                    dao.fields.ProductView += 1
                    dao.update()
                End If
                Return Json("success", JsonRequestBehavior.AllowGet)
            Catch ex As Exception
                Return Json("error" + ex.ToString, JsonRequestBehavior.AllowGet)
            End Try
            Return Json("success", JsonRequestBehavior.AllowGet)
        End Function


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


    End Class
End Namespace