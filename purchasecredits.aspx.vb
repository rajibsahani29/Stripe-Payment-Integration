Imports System.Data
Imports PlaceTheBall.BE
Imports PlaceTheBall.DL

Partial Class purchasecredits
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()

    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            If Not objFunction.ValidateLogin() Then
                Response.Redirect("~/Default.aspx")
            End If

            If Not Page.IsPostBack Then
                Dim intCompanyId As Integer = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("CompanyId"))
                Dim intGameCostCredit As Integer = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("GameCostCredit"))
                Dim dstGameCosts As DataSet = (New clsDLGameCosts()).GetGameCostsByCompanyIdAndCredx(intCompanyId, intGameCostCredit)
                If objFunction.CheckDataSet(dstGameCosts) Then
                    LABEL_COST.Text = objFunction.ReturnDouble(dstGameCosts.Tables(0).Rows(0)("amount")).ToString("0.00")
                End If

                Dim dstData As DataSet = (New clsDLClientDetails()).GetClientDetailByClientId(objFunction.ReturnInteger(Session("LoginUserId")))
                If objFunction.CheckDataSet(dstData) Then
                    Dim intBuyVisited As Integer = objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("buy_visited")) + 1
                    Dim objBEClientDetails As clsBEClientDetails = New clsBEClientDetails
                    objBEClientDetails.ClientDetailsId = objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("id"))
                    objBEClientDetails.BuyVisited = intBuyVisited
                    Dim intAffectedRow As Integer = (New clsDLClientDetails()).UpdateClientDetailsBuyVisitedById(objBEClientDetails)
                End If

            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try

    End Sub

    ''' <summary>
    ''' This event is used to pass total credit amount to payment.
    ''' </summary>
    Protected Sub BUT_Buy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Buy.Click
        Try
            Dim objBEGameStatsClick As clsBEGameStatsClick = New clsBEGameStatsClick
            objBEGameStatsClick.GameId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("GameId"))
            objBEGameStatsClick.DateAdded = DateTime.Now
            objBEGameStatsClick.Typex = 4
            Dim intAffectedRow As Integer = (New clsDLGameStatsClick()).AddGameStatsClick(objBEGameStatsClick)

            Session("TotalCreditAmount") = hdnTotalAmount.Value
            Session("NoOfCredit") = TB_No_Of_Credits.Text
            'Response.Redirect("payment_process1_1.asp")
            Response.Redirect("payment_process1.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to pass total credit amount to payment.
    ''' </summary>
    Protected Sub BUT_Buy_Paydoo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BUT_Buy_Paydoo.Click
        Try
            Dim objBEGameStatsClick As clsBEGameStatsClick = New clsBEGameStatsClick
            objBEGameStatsClick.GameId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("GameId"))
            objBEGameStatsClick.DateAdded = DateTime.Now
            objBEGameStatsClick.Typex = 4
            Dim intAffectedRow As Integer = (New clsDLGameStatsClick()).AddGameStatsClick(objBEGameStatsClick)

            Session("TotalCreditAmount") = hdnTotalAmount.Value
            Session("NoOfCredit") = TB_No_Of_Credits.Text
            Response.Redirect("payment_process2.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to pass total credit amount to payment.
    ''' </summary>
    Protected Sub BUT_Buy_Paytogather_Click(sender As Object, e As System.EventArgs) Handles BUT_Buy_Paytogather.Click
        Try
            Dim objBEGameStatsClick As clsBEGameStatsClick = New clsBEGameStatsClick
            objBEGameStatsClick.GameId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("GameId"))
            objBEGameStatsClick.DateAdded = DateTime.Now
            objBEGameStatsClick.Typex = 4
            Dim intAffectedRow As Integer = (New clsDLGameStatsClick()).AddGameStatsClick(objBEGameStatsClick)

            Session("TotalCreditAmount") = hdnTotalAmount.Value
            Session("NoOfCredit") = TB_No_Of_Credits.Text
            Response.Redirect("payment_process3.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to pass total credit amount to payment.
    ''' </summary>
    Protected Sub BUT_Buy_CliqPay_Click(sender As Object, e As System.EventArgs) Handles BUT_Buy_CliqPay.Click
        Try
            Dim objBEGameStatsClick As clsBEGameStatsClick = New clsBEGameStatsClick
            objBEGameStatsClick.GameId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("GameId"))
            objBEGameStatsClick.DateAdded = DateTime.Now
            objBEGameStatsClick.Typex = 4
            Dim intAffectedRow As Integer = (New clsDLGameStatsClick()).AddGameStatsClick(objBEGameStatsClick)

            Session("TotalCreditAmount") = hdnTotalAmount.Value
            Session("NoOfCredit") = TB_No_Of_Credits.Text
            'Response.Redirect("payment_process_cliq.aspx")
            Dim javaScript As String = ""
            javaScript += "<script type='text/javascript'>"
            javaScript += "alert('If you do not receive your credits once your payment has been processed, please allow up to 4 hours for your credits to show. However if they still do not appear, then please contact us using the special form at the bottom of the page. One of our support team will be in touch within 24 hours.');"
            javaScript += "window.location = 'payment_process_cliq.aspx';"
            javaScript += "</script>"
            ClientScript.RegisterStartupScript(Me.GetType(), "scriptKey", javaScript)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to pass total credit amount to payment.
    ''' </summary>
    Protected Sub BUT_Buy_Stripe_Click(sender As Object, e As EventArgs) Handles BUT_Buy_Stripe.Click
        Try
            Dim objBEGameStatsClick As clsBEGameStatsClick = New clsBEGameStatsClick
            objBEGameStatsClick.GameId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("GameId"))
            objBEGameStatsClick.DateAdded = DateTime.Now
            objBEGameStatsClick.Typex = 4
            Dim intAffectedRow As Integer = (New clsDLGameStatsClick()).AddGameStatsClick(objBEGameStatsClick)

            Session("TotalCreditAmount") = hdnTotalAmount.Value
            Session("NoOfCredit") = TB_No_Of_Credits.Text
            Response.Redirect("payment_process_stripe.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub

    ''' <summary>
    ''' This event is used to pass total credit amount to payment.
    ''' </summary>
    Protected Sub BUT_Buy_Paypal_Click(sender As Object, e As EventArgs) Handles BUT_Buy_Paypal.Click
        Try
            Dim objBEGameStatsClick As clsBEGameStatsClick = New clsBEGameStatsClick
            objBEGameStatsClick.GameId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("GameId"))
            objBEGameStatsClick.DateAdded = DateTime.Now
            objBEGameStatsClick.Typex = 4
            Dim intAffectedRow As Integer = (New clsDLGameStatsClick()).AddGameStatsClick(objBEGameStatsClick)

            Session("TotalCreditAmount") = hdnTotalAmount.Value
            Session("NoOfCredit") = TB_No_Of_Credits.Text
            Response.Redirect("payment_process_paypal.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
    Protected Sub BUT_Buy_CCAvenue_Click(sender As Object, e As EventArgs) Handles BUT_Buy_CCAvenue.Click
        Try
            Dim objBEGameStatsClick As clsBEGameStatsClick = New clsBEGameStatsClick
            objBEGameStatsClick.GameId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("GameId"))
            objBEGameStatsClick.DateAdded = DateTime.Now
            objBEGameStatsClick.Typex = 4
            Dim intAffectedRow As Integer = (New clsDLGameStatsClick()).AddGameStatsClick(objBEGameStatsClick)

            Session("TotalCreditAmount") = hdnTotalAmount.Value
            Session("NoOfCredit") = TB_No_Of_Credits.Text
            Response.Redirect("payment_process_ccavenue.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
    Protected Sub BUT_Buy_Paytm_Click(sender As Object, e As EventArgs) Handles BUT_Buy_Paytm.Click
        Try
            Dim objBEGameStatsClick As clsBEGameStatsClick = New clsBEGameStatsClick
            objBEGameStatsClick.GameId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("GameId"))
            objBEGameStatsClick.DateAdded = DateTime.Now
            objBEGameStatsClick.Typex = 4
            Dim intAffectedRow As Integer = (New clsDLGameStatsClick()).AddGameStatsClick(objBEGameStatsClick)

            Session("TotalCreditAmount") = hdnTotalAmount.Value
            Session("NoOfCredit") = TB_No_Of_Credits.Text
            Response.Redirect("payment_process_paytm.aspx")
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
        End Try
    End Sub
End Class
