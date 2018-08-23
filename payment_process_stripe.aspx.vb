Imports System.Data
Imports PlaceTheBall.BE
Imports PlaceTheBall.DL

Partial Class payment_process_stripe
    Inherits System.Web.UI.Page

    Public strDataKey As String = "", strResponseSuccessURL As String = "", strTotalAmount As String = "", strUserName As String = "", strNoOfCredit As String = "", strCreditHistoryTempId As String = "", strExtraParameter As String = "", strDataDescription As String = ""

    Dim objFunction As New clsCommon()

    Protected Sub Page_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        Try

            If Not objFunction.ValidateLogin() Then
                Response.Redirect("~/Default.aspx")
            End If

            If objFunction.ReturnString(Session("TotalCreditAmount")) = "" Then
                Response.Redirect("~/purchasecredits.aspx")
            End If

            If objFunction.ReturnString(Session("NoOfCredit")) = "" Or objFunction.ReturnInteger(Session("NoOfCredit")) <= 0 Then
                Response.Redirect("~/purchasecredits.aspx")
            End If

            'strDataKey = "pk_test_j3CRrmlGida4uKJ3aqD1M99N" 'Test Key
            strDataKey = objFunction.ReturnString(System.Configuration.ConfigurationManager.AppSettings("StripePublishableKey")) 'Test Key
            'strDataKey = "" 'Live Key
            strResponseSuccessURL = objFunction.ReturnString(System.Configuration.ConfigurationManager.AppSettings("ServerLoc")) + "thankyou_stripe_temp.aspx"
            strTotalAmount = objFunction.ReturnDouble(Session("TotalCreditAmount")).ToString("0.00").Replace(".", "")
            strUserName = objFunction.ReturnString(Session("ClientFullName"))
            strDataDescription = objFunction.ReturnString(System.Configuration.ConfigurationManager.AppSettings("StripeDataDescription"))
            Trace.Warn("strTotalAmount = " + strTotalAmount)
            Trace.Warn("strUserName = " + strUserName)
            Trace.Warn("strDataKey = " + strDataKey)

            strNoOfCredit = objFunction.ReturnString(Session("NoOfCredit"))
            LABEL_NoOfCredit.Text = strNoOfCredit
            LABEL_TotalCost.Text = objFunction.ReturnDouble(Session("TotalCreditAmount")).ToString("0.00")
            LABEL_Name.Text = strUserName

            Trace.Warn("CreditHistoryTempEntryFlag = " + objFunction.ReturnString(Session("CreditHistoryTempEntryFlag")))
            'Session("CreditHistoryTempEntryFlag") = Nothing
            If objFunction.ReturnString(Session("CreditHistoryTempEntryFlag")) = "Success" Then
                If objFunction.ReturnInteger(Session("CreditHistoryTempId")) > 0 Then
                    strCreditHistoryTempId = objFunction.ReturnString(objFunction.ReturnInteger(Session("CreditHistoryTempId")) + 141275)
                Else
                    Response.Redirect("~/purchasecredits.aspx")
                End If
            Else
                Dim intCreditHistoryTempId As Integer = AddCreditHistoryTemp()
                If intCreditHistoryTempId > 0 Then
                    strCreditHistoryTempId = objFunction.ReturnString(intCreditHistoryTempId)
                Else
                    Response.Redirect("~/purchasecredits.aspx")
                End If
            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    Function AddCreditHistoryTemp() As Integer
        Try
            Dim objBECreditHistoryTemp As clsBECreditHistoryTemp = New clsBECreditHistoryTemp
            objBECreditHistoryTemp.UserId = objFunction.ReturnInteger(Session("LoginUserId"))
            objBECreditHistoryTemp.Creditx = objFunction.ReturnInteger(Session("NoOfCredit"))
            objBECreditHistoryTemp.Whenx = DateTime.Now
            objBECreditHistoryTemp.PaymentMethodId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("StripePaymentId"))
            objBECreditHistoryTemp.AmountTaken = objFunction.ReturnDouble(Session("TotalCreditAmount"))
            objBECreditHistoryTemp.Ref = ""
            objBECreditHistoryTemp.History = ""
            objBECreditHistoryTemp.Authorised = 0
            objBECreditHistoryTemp.Emailx = objFunction.ReturnString(Session("ClientEmailId"))

            Dim intCreditHistoryTempId As Integer = (New clsDLCreditHistoryTemp()).AddCreditHistoryTemp(objBECreditHistoryTemp)
            If intCreditHistoryTempId > 0 Then

                Session("CreditHistoryTempEntryFlag") = "Success"
                Session("CreditHistoryTempId") = objFunction.ReturnString(intCreditHistoryTempId)

                Dim myCookie As HttpCookie = New HttpCookie(objFunction.ReturnString(System.Configuration.ConfigurationManager.AppSettings("VariablePrefix")) + "UserSettings")
                myCookie("CreditHistoryTempId") = objFunction.ReturnString((141275 + intCreditHistoryTempId))
                myCookie("NoOfCredit") = objFunction.ReturnString(Session("NoOfCredit"))
                myCookie.Expires = Now.AddDays(1)
                Response.Cookies.Add(myCookie)

                'If (Request.Cookies("UserSettings") IsNot Nothing) Then
                '    Trace.Warn("Cookie UserId = " + objFunction.ReturnString(Request.Cookies("UserSettings")("UserId")))
                '    Trace.Warn("Cookie NoOfCredit = " + objFunction.ReturnString(Request.Cookies("UserSettings")("NoOfCredit")))
                'End If

                Return (intCreditHistoryTempId + 141275)
            End If
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
        Return 0
    End Function

End Class
