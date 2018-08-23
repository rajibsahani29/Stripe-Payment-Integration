Imports System.Data
Imports PlaceTheBall.BE
Imports PlaceTheBall.DL
Imports Stripe
Imports System.IO

Partial Class thankyou_stripe_temp
    Inherits System.Web.UI.Page

    Dim objFunction As New clsCommon()
    Dim objBECreditHistory As clsBECreditHistory = New clsBECreditHistory
    Dim objDLCreditHistory As clsDLCreditHistory = New clsDLCreditHistory

    ''' <summary>
    ''' Load event of the page
    ''' </summary>
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Session("CreditHistoryTempEntryFlag") = Nothing

            Trace.Warn("CreditHistoryTempId = " + objFunction.ReturnString(Session("CreditHistoryTempId")))
            If (Request.Cookies(objFunction.ReturnString(System.Configuration.ConfigurationManager.AppSettings("VariablePrefix")) + "UserSettings") Is Nothing) And objFunction.ReturnString(Session("CreditHistoryTempId")) = "" Then

                Dim strPath As String = Server.MapPath("stripepaymentlog.txt")
                If File.Exists(strPath) Then
                    Using sw As StreamWriter = File.AppendText(strPath)
                        sw.WriteLine("UserId = " + objFunction.ReturnString(Session("LoginUserId")) + " & Date = " + objFunction.ReturnString(DateTime.Now) + "\n")
                    End Using
                End If

                Dim strMsg As String = "Something went wrong with the credit approval system. Please use the special contact form in the contact section to inform us and we will happily credit your account"
                Dim javaScript As String = ""
                javaScript += "<script type='text/javascript'>"
                javaScript += "alert('" + strMsg + "');"
                javaScript += "window.location = 'thankyou_stripe.aspx';"
                javaScript += "</script>"
                ClientScript.RegisterStartupScript(Me.GetType(), "scriptKey", javaScript)
            End If

            If Not Page.IsPostBack Then
                If Request.Cookies(objFunction.ReturnString(System.Configuration.ConfigurationManager.AppSettings("VariablePrefix")) + "UserSettings") IsNot Nothing Then
                    Dim intCreditHisTempId As Integer = objFunction.ReturnInteger(Request.Cookies(objFunction.ReturnString(System.Configuration.ConfigurationManager.AppSettings("VariablePrefix")) + "UserSettings")("CreditHistoryTempId")) - 141275
                    Trace.Warn("intCreditHisTempId = " + objFunction.ReturnString(intCreditHisTempId))
                    If intCreditHisTempId > 0 Then
                        Dim dstData As DataSet = (New clsDLCreditHistoryTemp()).GetCreditHistoryTempById(intCreditHisTempId)
                        If objFunction.CheckDataSet(dstData) Then

                            Dim strNewHistory As String = objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")) +
                                                       "---------- Thankyou_Stripe_Temp RECORD ----- PAGELOAD ENTERED(Cookie) " +
                                                       objFunction.ReturnString(DateTime.Now)
                            UpdateHistory(intCreditHisTempId, strNewHistory)

                            If objFunction.ReturnString(Session("LoginUserId")) = "" Then
                                Session("LoginUserId") = objFunction.ReturnString(dstData.Tables(0).Rows(0)("uid"))
                                Session("UserLogged") = "1"
                            End If

                            If objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("authorised")) = 0 Then
                                'ManageClientCredit(objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("uid")), objFunction.ReturnInteger(Request.Cookies("UserSettings")("NoOfCredit")), intCreditHisTempId, objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")))
                                'ManageClientCredit(objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("uid")), objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("credx")), intCreditHisTempId, objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")), objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")))
                                ManageClientCredit(objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("uid")), objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("credx")), intCreditHisTempId, strNewHistory, objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")))
                            Else
                                'UpdateCreditHistoryTemp1(intCreditHisTempId, objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")), objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")), objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("authorised")))
                                UpdateCreditHistoryTemp1(intCreditHisTempId, strNewHistory, objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")), objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("authorised")))
                                'If objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("authorised")) = 1 Then
                                '    Dim intAffectedRow As Integer = UpdateCreditHistoryTemp(intCreditHisTempId, objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")), objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")))
                                '    If intAffectedRow > 0 Then
                                '        Session("ResponseAmountTaken") = objFunction.ReturnString(dstData.Tables(0).Rows(0)("amount_taken"))
                                '        Session("ResponsePaymentStatus") = "Approved"
                                '        'Session("ResponsePaymentStatus") = "RECORD ALREADY AUTHORISED -  NOT PROCESSED"
                                '    Else
                                '        Session("ResponseAmountTaken") = ""
                                '        Session("ResponsePaymentStatus") = "There was a system error. If this error persists please contact technical support."
                                '    End If
                                'ElseIf objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("authorised")) = -99 Then
                                '    Dim intAffectedRow As Integer = UpdateCreditHistoryTemp(intCreditHisTempId, objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")), objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")))
                                '    If intAffectedRow > 0 Then
                                '        Session("ResponseAmountTaken") = objFunction.ReturnString(dstData.Tables(0).Rows(0)("amount_taken"))
                                '        Session("ResponsePaymentStatus") = "Rejected"
                                '        'Session("ResponsePaymentStatus") = "RECORD ALREADY AUTHORISED -  NOT PROCESSED"
                                '    Else
                                '        Session("ResponseAmountTaken") = ""
                                '        Session("ResponsePaymentStatus") = "There was a system error. If this error persists please contact technical support."
                                '    End If
                                'End If
                                ''Request.Cookies.Remove("UserSettings")
                                'Response.Redirect("thankyou_stripe.aspx")
                            End If
                        End If
                    End If
                ElseIf objFunction.ReturnString(Session("CreditHistoryTempId")) <> "" Then
                    Dim intCreditHisTempId As Integer = objFunction.ReturnInteger(Session("CreditHistoryTempId"))
                    Trace.Warn("intCreditHisTempId = " + objFunction.ReturnString(intCreditHisTempId))
                    If intCreditHisTempId > 0 Then
                        Dim dstData As DataSet = (New clsDLCreditHistoryTemp()).GetCreditHistoryTempById(intCreditHisTempId)
                        If objFunction.CheckDataSet(dstData) Then

                            Dim strNewHistory As String = objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")) +
                                                       "---------- Thankyou_Stripe_Temp RECORD ----- PAGELOAD ENTERED(Session) " +
                                                       objFunction.ReturnString(DateTime.Now)
                            UpdateHistory(intCreditHisTempId, strNewHistory)

                            If objFunction.ReturnString(Session("LoginUserId")) = "" Then
                                Session("LoginUserId") = objFunction.ReturnString(dstData.Tables(0).Rows(0)("uid"))
                                Session("UserLogged") = "1"
                            End If

                            If objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("authorised")) = 0 Then
                                'ManageClientCredit(objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("uid")), objFunction.ReturnInteger(Session("NoOfCredit")), intCreditHisTempId, objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")))
                                'ManageClientCredit(objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("uid")), objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("credx")), intCreditHisTempId, objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")), objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")))
                                ManageClientCredit(objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("uid")), objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("credx")), intCreditHisTempId, strNewHistory, objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")))
                            Else
                                'UpdateCreditHistoryTemp1(intCreditHisTempId, objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")), objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")), objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("authorised")))
                                UpdateCreditHistoryTemp1(intCreditHisTempId, strNewHistory, objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")), objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("authorised")))
                                'If objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("authorised")) = 1 Then
                                '    Dim intAffectedRow As Integer = UpdateCreditHistoryTemp(intCreditHisTempId, objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")), objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")))
                                '    If intAffectedRow > 0 Then
                                '        Session("ResponseAmountTaken") = objFunction.ReturnString(dstData.Tables(0).Rows(0)("amount_taken"))
                                '        Session("ResponsePaymentStatus") = "Approved"
                                '        'Session("ResponsePaymentStatus") = "RECORD ALREADY AUTHORISED -  NOT PROCESSED"
                                '    Else
                                '        Session("ResponseAmountTaken") = ""
                                '        Session("ResponsePaymentStatus") = "There was a system error. If this error persists please contact technical support."
                                '    End If
                                'ElseIf objFunction.ReturnInteger(dstData.Tables(0).Rows(0)("authorised")) = -99 Then
                                '    Dim intAffectedRow As Integer = UpdateCreditHistoryTemp(intCreditHisTempId, objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")), objFunction.ReturnDouble(dstData.Tables(0).Rows(0)("amount_taken")))
                                '    If intAffectedRow > 0 Then
                                '        Session("ResponseAmountTaken") = objFunction.ReturnString(dstData.Tables(0).Rows(0)("amount_taken"))
                                '        Session("ResponsePaymentStatus") = "Rejected"
                                '        'Session("ResponsePaymentStatus") = "RECORD ALREADY AUTHORISED -  NOT PROCESSED"
                                '    Else
                                '        Session("ResponseAmountTaken") = ""
                                '        Session("ResponsePaymentStatus") = "There was a system error. If this error persists please contact technical support."
                                '    End If
                                'End If
                                ''Request.Cookies.Remove("UserSettings")
                                'Response.Redirect("thankyou_stripe.aspx")
                            End If
                        End If
                    End If
                Else
                    'Request.Cookies.Remove("UserSettings")
                    Dim strMsg As String = "Something went wrong with the credit approval system. Please use the special contact form in the contact section to inform us and we will happily credit your account"
                    Dim javaScript As String = ""
                    javaScript += "<script type='text/javascript'>"
                    javaScript += "alert('" + strMsg + "');"
                    javaScript += "window.location = 'thankyou_stripe.aspx';"
                    javaScript += "</script>"
                    ClientScript.RegisterStartupScript(Me.GetType(), "scriptKey", javaScript)
                End If
            End If

        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)

            If ex.Message <> "Thread was being aborted." Then
                If Request.Cookies(objFunction.ReturnString(System.Configuration.ConfigurationManager.AppSettings("VariablePrefix")) + "UserSettings") IsNot Nothing Then
                    Dim intCreditHisTempId As Integer = objFunction.ReturnInteger(Request.Cookies(objFunction.ReturnString(System.Configuration.ConfigurationManager.AppSettings("VariablePrefix")) + "UserSettings")("CreditHistoryTempId")) - 141275
                    Trace.Warn("intCreditHisTempId = " + objFunction.ReturnString(intCreditHisTempId))
                    If intCreditHisTempId > 0 Then
                        Dim dstData As DataSet = (New clsDLCreditHistoryTemp()).GetCreditHistoryTempById(intCreditHisTempId)
                        If objFunction.CheckDataSet(dstData) Then
                            Dim strNewHistory As String = objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")) +
                                                           "---------- Thankyou_Stripe_Temp RECORD ----- Catch ex As Exception(Cookie) Page_load " +
                                                           objFunction.ReturnString(ex.Message) +
                                                           objFunction.ReturnString(ex.StackTrace) +
                                                           objFunction.ReturnString(ex.InnerException) +
                                                           objFunction.ReturnString(DateTime.Now)
                            UpdateHistory(intCreditHisTempId, strNewHistory)
                        End If
                    End If
                ElseIf objFunction.ReturnString(Session("CreditHistoryTempId")) <> "" Then
                    Dim intCreditHisTempId As Integer = objFunction.ReturnInteger(Session("CreditHistoryTempId"))
                    Trace.Warn("intCreditHisTempId = " + objFunction.ReturnString(intCreditHisTempId))
                    If intCreditHisTempId > 0 Then
                        Dim dstData As DataSet = (New clsDLCreditHistoryTemp()).GetCreditHistoryTempById(intCreditHisTempId)
                        If objFunction.CheckDataSet(dstData) Then
                            Dim strNewHistory As String = objFunction.ReturnString(dstData.Tables(0).Rows(0)("history")) +
                                                           "---------- Thankyou_Stripe_Temp RECORD ----- Catch ex As Exception(Session) Page_load " +
                                                           objFunction.ReturnString(ex.Message) +
                                                           objFunction.ReturnString(ex.StackTrace) +
                                                           objFunction.ReturnString(ex.InnerException) +
                                                           objFunction.ReturnString(DateTime.Now)
                            UpdateHistory(intCreditHisTempId, strNewHistory)
                        End If
                    End If
                End If
            End If

            'Session("ResponseAmountTaken") = "0"
            'Session("ResponsePaymentStatus") = "Unsuccessful. Please try again. Your card has not been charged."
            Response.Redirect("thankyou_stripe.aspx")

        End Try

    End Sub

    ''' <summary>
    ''' This function is used to manage client credit.
    ''' </summary>
    Protected Sub ManageClientCredit(ByVal intLoginUserId As Integer, ByVal intNoOfCredit As Integer, ByVal intCreditHistoryTempId As Integer, ByVal strHistory As String, ByVal dblAmountTaken As Double)
        Try
            Dim stripeToken As String = objFunction.ReturnString(Request.Form.Get("stripeToken"))
            Dim strPaymentEmail As String = objFunction.ReturnString(Request.Form.Get("stripeEmail"))
            Dim strAmountTaken As String = objFunction.ReturnString(dblAmountTaken)

            Trace.Warn("stripeToken = " + stripeToken)
            Trace.Warn("strAmountTaken = " + strAmountTaken)

            StripeConfiguration.SetApiKey(objFunction.ReturnString(System.Configuration.ConfigurationManager.AppSettings("StripeSecretKey")))
            Dim objStripeChargeService As StripeChargeService = New StripeChargeService
            Dim objStripeCharge As StripeCharge = objStripeChargeService.Create(New StripeChargeCreateOptions With {
                .Amount = objFunction.ReturnInteger(dblAmountTaken * 100),
                .Currency = "gbp",
                .SourceTokenOrExistingSourceId = stripeToken,
                .Metadata = New Dictionary(Of String, String)() From
                {
                    {"CreditHistoryTempId", objFunction.ReturnString(Session("CreditHistoryTempId"))},
                    {"NoOfCredit", objFunction.ReturnString(Session("NoOfCredit"))}
                }
            })

            Dim strPaymentStatus As String = objFunction.ReturnString(objStripeCharge.Status)

            Dim strMetaDataVal As String = ""
            If objStripeCharge.Metadata IsNot Nothing Then
                For Each kvp As KeyValuePair(Of String, String) In objStripeCharge.Metadata
                    Dim strKey As String = kvp.Key
                    Dim strVal As String = kvp.Value
                    strMetaDataVal = strKey + " = " + strVal + ","
                Next
            End If
            Trace.Warn("strPaymentStatus = " + strPaymentStatus)

            Dim strHistoryUpdate As String = strHistory + "<br/>" + "--------- THANKYOU_STRIPE_TEMP RECORD ----- Get REQUEST " + "<br/>" +
                                                  objFunction.ReturnString(objStripeCharge.Id) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Object) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Amount) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.BalanceTransactionId) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Created) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Currency) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Description) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.FailureCode) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.FailureMessage) + ", " +
                                                  strMetaDataVal.TrimEnd(",") + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.NetworkStatus) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.Reason) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.RiskLevel) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.SellerMessage) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.Type) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Paid) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Source.Id) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Status) + ", " +
                                                  strPaymentEmail +
                                                  "<br/>" + objFunction.ReturnString(DateTime.Now)

            UpdateHistory(intCreditHistoryTempId, strHistoryUpdate)

            If strPaymentStatus = "succeeded" Then

                Session("ResponseAmountTaken") = strAmountTaken
                Session("ResponsePaymentStatus") = strPaymentStatus

                Dim intCompanyId As Integer = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("CompanyId"))

                objBECreditHistory.UserId = intLoginUserId
                objBECreditHistory.Creditx = intNoOfCredit
                objBECreditHistory.Whenx = DateTime.Now
                objBECreditHistory.PaymentMethodId = objFunction.ReturnInteger(System.Configuration.ConfigurationManager.AppSettings("StripePaymentId"))
                objBECreditHistory.AmountTaken = objFunction.ReturnDouble(strAmountTaken)
                objBECreditHistory.Ref = stripeToken

                Dim intAffectedRow As Integer = objDLCreditHistory.AddCreditHistory(objBECreditHistory)
                If intAffectedRow > 0 Then

                    Dim objBEClient As clsBEClient = New clsBEClient
                    objBEClient.ClientId = intLoginUserId
                    objBEClient.CompanyId = intCompanyId
                    Dim dstClient As DataSet = (New clsDLClient()).GetClientById(objBEClient)
                    Dim intClientCredit As Integer = 0
                    If objFunction.CheckDataSet(dstClient) Then
                        intClientCredit = objFunction.ReturnInteger(dstClient.Tables(0).Rows(0)("creditx"))
                    End If

                    Dim intNewClientCredit As Integer = intClientCredit + intNoOfCredit
                    objBEClient.Creditx = intNewClientCredit

                    intAffectedRow = (New clsDLClient()).UpdateClientCreditx(objBEClient)

                    Dim objBECreditHistoryTemp As clsBECreditHistoryTemp = New clsBECreditHistoryTemp
                    objBECreditHistoryTemp.CreditHistoryTempId = intCreditHistoryTempId
                    objBECreditHistoryTemp.Authorised = 1
                    intAffectedRow = (New clsDLCreditHistoryTemp()).UpdateCreditHistoryTempAuthorisedById(objBECreditHistoryTemp)

                    Dim strNewHistory As String = strHistoryUpdate + "<br/>" + "THANKYOU_STRIPE_TEMP - succeeded " + objFunction.ReturnString(DateTime.Now) + "<br/>" +
                                                  objFunction.ReturnString(objStripeCharge.Id) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Object) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Amount) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.BalanceTransactionId) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Created) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Currency) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Description) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.FailureCode) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.FailureMessage) + ", " +
                                                  strMetaDataVal.TrimEnd(",") + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.NetworkStatus) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.Reason) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.RiskLevel) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.SellerMessage) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.Type) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Paid) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Source.Id) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Status) + ", " +
                                                  strPaymentEmail +
                                                  "<br/>" + objFunction.ReturnString(DateTime.Now)

                    objBECreditHistoryTemp.CreditHistoryTempId = intCreditHistoryTempId
                    objBECreditHistoryTemp.History = strNewHistory
                    intAffectedRow = (New clsDLCreditHistoryTemp()).UpdateCreditHistoryTempHistoryById(objBECreditHistoryTemp)

                End If
                'Request.Cookies.Remove("UserSettings")
                Response.Redirect("thankyou_stripe.aspx")
            ElseIf strPaymentStatus = "failed" Then
                Session("ResponseAmountTaken") = strAmountTaken
                Session("ResponsePaymentStatus") = strPaymentStatus

                Dim intAffectedRow As Integer = 0

                Dim objBECreditHistoryTemp As clsBECreditHistoryTemp = New clsBECreditHistoryTemp
                objBECreditHistoryTemp.CreditHistoryTempId = intCreditHistoryTempId
                objBECreditHistoryTemp.Authorised = -99
                intAffectedRow = (New clsDLCreditHistoryTemp()).UpdateCreditHistoryTempAuthorisedById(objBECreditHistoryTemp)

                Dim strNewHistory As String = strHistoryUpdate + "<br/>" + "THANKYOU_STRIPE_TEMP - failed " + objFunction.ReturnString(DateTime.Now) + "<br/>" +
                                                  objFunction.ReturnString(objStripeCharge.Id) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Object) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Amount) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.BalanceTransactionId) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Created) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Currency) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Description) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.FailureCode) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.FailureMessage) + ", " +
                                                  strMetaDataVal.TrimEnd(",") + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.NetworkStatus) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.Reason) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.RiskLevel) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.SellerMessage) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.Type) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Paid) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Source.Id) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Status) + ", " +
                                                  strPaymentEmail +
                                                  "<br/>" + objFunction.ReturnString(DateTime.Now)

                objBECreditHistoryTemp.CreditHistoryTempId = intCreditHistoryTempId
                objBECreditHistoryTemp.History = strNewHistory
                intAffectedRow = (New clsDLCreditHistoryTemp()).UpdateCreditHistoryTempHistoryById(objBECreditHistoryTemp)
                'Request.Cookies.Remove("UserSettings")
                Response.Redirect("thankyou_stripe.aspx")
            Else
                Session("ResponseAmountTaken") = strAmountTaken
                Session("ResponsePaymentStatus") = strPaymentStatus

                Dim intAffectedRow As Integer = 0

                Dim objsource As Source = objStripeCharge.Source

                Dim strNewHistory As String = strHistoryUpdate + "<br/>" + "NO DATA DELIVERED" + "<br/>" + "THANKYOU_STRIPE_TEMP " + objFunction.ReturnString(DateTime.Now) + "<br/>" +
                                                  objFunction.ReturnString(objStripeCharge.Id) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Object) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Amount) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.BalanceTransactionId) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Created) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Currency) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Description) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.FailureCode) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.FailureMessage) + ", " +
                                                  strMetaDataVal.TrimEnd(",") + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.NetworkStatus) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.Reason) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.RiskLevel) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.SellerMessage) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.Type) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Paid) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Source.Id) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Status) + ", " +
                                                  strPaymentEmail +
                                                  "<br/>" + objFunction.ReturnString(DateTime.Now)

                Dim objBECreditHistoryTemp As clsBECreditHistoryTemp = New clsBECreditHistoryTemp
                objBECreditHistoryTemp.CreditHistoryTempId = intCreditHistoryTempId
                objBECreditHistoryTemp.History = strNewHistory
                intAffectedRow = (New clsDLCreditHistoryTemp()).UpdateCreditHistoryTempHistoryById(objBECreditHistoryTemp)
                'Request.Cookies.Remove("UserSettings")
                Response.Redirect("thankyou_stripe.aspx")
            End If

        Catch ex As StripeException
            'HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            'HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            Select Case ex.StripeError.ErrorType
                Case "card_error"
                    Trace.Warn("Code : " + ex.StripeError.Code)
                    Trace.Warn("Message : " + ex.StripeError.Message)
                Case "api_connection_error", "api_error", "authentication_error", "invalid_request_error", "rate_limit_error", "validation_error"
                    Trace.Warn("Code : " + ex.StripeError.Code)
                    Trace.Warn("Message : " + ex.StripeError.Message)
                Case Else
                    Trace.Warn("Code : " + ex.StripeError.Code)
                    Trace.Warn("Message : " + ex.StripeError.Message)
            End Select

            Dim strNewHistory As String = strHistory + "---------- Thankyou_Stripe_Temp RECORD ----- Catch ex As StripeException ManageClientCredit() " +
                                                       objFunction.ReturnString(DateTime.Now)

            UpdateCreditHistoryTemp_StripePaymentException(intCreditHistoryTempId, strNewHistory, ex)

        End Try
    End Sub

    ''' <summary>
    ''' This function is used to update history of credit_history_temp.
    ''' </summary>
    Function UpdateCreditHistoryTemp(ByVal intCreditHistoryTempId As Integer, ByVal strHistory As String, ByVal dblAmountTaken As Double) As Integer
        Try
            Dim stripeToken As String = objFunction.ReturnString(Request.Form.Get("stripeToken"))
            Dim strPaymentEmail As String = objFunction.ReturnString(Request.Form.Get("stripeEmail"))

            StripeConfiguration.SetApiKey(objFunction.ReturnString(System.Configuration.ConfigurationManager.AppSettings("StripeSecretKey")))
            Dim objStripeChargeService As StripeChargeService = New StripeChargeService
            Dim objStripeCharge As StripeCharge = objStripeChargeService.Create(New StripeChargeCreateOptions With {
                .Amount = objFunction.ReturnInteger(dblAmountTaken * 100),
                .Currency = "gbp",
                .SourceTokenOrExistingSourceId = stripeToken,
                .Metadata = New Dictionary(Of String, String)() From
                {
                    {"CreditHistoryTempId", objFunction.ReturnString(Session("CreditHistoryTempId"))},
                    {"NoOfCredit", objFunction.ReturnString(Session("NoOfCredit"))}
                }
            })

            Dim strAmountTaken As String = objFunction.ReturnString((dblAmountTaken / 100))
            Dim strPaymentStatus As String = objFunction.ReturnString(Request.Form.Get("status"))

            Dim strMetaDataVal As String = ""
            If objStripeCharge.Metadata IsNot Nothing Then
                For Each kvp As KeyValuePair(Of String, String) In objStripeCharge.Metadata
                    Dim strKey As String = kvp.Key
                    Dim strVal As String = kvp.Value
                    strMetaDataVal = strKey + " = " + strVal + ","
                Next
            End If

            Dim strNewHistory As String = strHistory + "<br/>" + "Update THANKYOU_STRIPE_TEMP " + objFunction.ReturnString(DateTime.Now) + "<br/>" +
                                                  objFunction.ReturnString(objStripeCharge.Id) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Object) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Amount) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.BalanceTransactionId) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Created) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Currency) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Description) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.FailureCode) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.FailureMessage) + ", " +
                                                  strMetaDataVal.TrimEnd(",") + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.NetworkStatus) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.Reason) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.RiskLevel) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.SellerMessage) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.Type) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Paid) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Source.Id) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Status) + ", " +
                                                  strPaymentEmail +
                                                  "<br/>" + objFunction.ReturnString(DateTime.Now)

            Dim objBECreditHistoryTemp As clsBECreditHistoryTemp = New clsBECreditHistoryTemp
            objBECreditHistoryTemp.CreditHistoryTempId = intCreditHistoryTempId
            objBECreditHistoryTemp.History = strNewHistory
            Dim intAffectedRow As Integer = (New clsDLCreditHistoryTemp()).UpdateCreditHistoryTempHistoryById(objBECreditHistoryTemp)
            Return intAffectedRow
        Catch ex As StripeException
            'HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            'HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            Select Case ex.StripeError.ErrorType
                Case "card_error"
                    Trace.Warn("Code : " + ex.StripeError.Code)
                    Trace.Warn("Message : " + ex.StripeError.Message)
                Case "api_connection_error", "api_error", "authentication_error", "invalid_request_error", "rate_limit_error", "validation_error"
                    Trace.Warn("Code : " + ex.StripeError.Code)
                    Trace.Warn("Message : " + ex.StripeError.Message)
                Case Else
                    Trace.Warn("Code : " + ex.StripeError.Code)
                    Trace.Warn("Message : " + ex.StripeError.Message)
            End Select

            'UpdateCreditHistoryTemp_StripePaymentException(intCreditHistoryTempId, strHistory, ex)

        End Try
        Return 0
    End Function

    ''' <summary>
    ''' This function is used to update history of credit_history_temp.
    ''' </summary>
    Sub UpdateCreditHistoryTemp1(ByVal intCreditHistoryTempId As Integer, ByVal strHistory As String, ByVal dblAmountTaken As Double, ByVal intAuthorised As Integer)
        Try
            Dim stripeToken As String = objFunction.ReturnString(Request.Form.Get("stripeToken"))
            Dim strPaymentEmail As String = objFunction.ReturnString(Request.Form.Get("stripeEmail"))

            StripeConfiguration.SetApiKey(objFunction.ReturnString(System.Configuration.ConfigurationManager.AppSettings("StripeSecretKey")))
            Dim objStripeChargeService As StripeChargeService = New StripeChargeService
            Dim objStripeCharge As StripeCharge = objStripeChargeService.Create(New StripeChargeCreateOptions With {
                .Amount = objFunction.ReturnInteger(dblAmountTaken * 100),
                .Currency = "gbp",
                .SourceTokenOrExistingSourceId = stripeToken,
                .Metadata = New Dictionary(Of String, String)() From
                {
                    {"CreditHistoryTempId", objFunction.ReturnString(Session("CreditHistoryTempId"))},
                    {"NoOfCredit", objFunction.ReturnString(Session("NoOfCredit"))}
                }
            })

            Dim strAmountTaken As String = objFunction.ReturnString((dblAmountTaken / 100))
            Dim strPaymentStatus As String = objFunction.ReturnString(Request.Form.Get("status"))

            Dim strMetaDataVal As String = ""
            If objStripeCharge.Metadata IsNot Nothing Then
                For Each kvp As KeyValuePair(Of String, String) In objStripeCharge.Metadata
                    Dim strKey As String = kvp.Key
                    Dim strVal As String = kvp.Value
                    strMetaDataVal = strKey + " = " + strVal + ","
                Next
            End If

            Dim strNewHistory As String = strHistory + "<br/>" + "Update THANKYOU_STRIPE_TEMP UpdateCreditHistoryTemp1() " + objFunction.ReturnString(DateTime.Now) + "<br/>" +
                                                  objFunction.ReturnString(objStripeCharge.Id) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Object) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Amount) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.BalanceTransactionId) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Created) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Currency) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Description) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.FailureCode) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.FailureMessage) + ", " +
                                                  strMetaDataVal.TrimEnd(",") + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.NetworkStatus) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.Reason) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.RiskLevel) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.SellerMessage) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Outcome.Type) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Paid) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Source.Id) + ", " +
                                                  objFunction.ReturnString(objStripeCharge.Status) + ", " +
                                                  strPaymentEmail +
                                                  "<br/>" + objFunction.ReturnString(DateTime.Now)

            Dim objBECreditHistoryTemp As clsBECreditHistoryTemp = New clsBECreditHistoryTemp
            objBECreditHistoryTemp.CreditHistoryTempId = intCreditHistoryTempId
            objBECreditHistoryTemp.History = strNewHistory
            Dim intAffectedRow As Integer = (New clsDLCreditHistoryTemp()).UpdateCreditHistoryTempHistoryById(objBECreditHistoryTemp)

            If intAffectedRow > 0 Then
                If intAuthorised = 1 Then
                    Session("ResponseAmountTaken") = dblAmountTaken.ToString("0.00")
                    Session("ResponsePaymentStatus") = "succeeded"
                ElseIf intAuthorised = -99 Then
                    Session("ResponseAmountTaken") = dblAmountTaken.ToString("0.00")
                    Session("ResponsePaymentStatus") = "failed"
                Else
                    Session("ResponseAmountTaken") = ""
                    Session("ResponsePaymentStatus") = "There was a system error. If this error persists please contact technical support."
                End If
            Else
                Session("ResponseAmountTaken") = ""
                Session("ResponsePaymentStatus") = "There was a system error. If this error persists please contact technical support."
            End If

            Response.Redirect("thankyou_stripe.aspx")

        Catch ex As StripeException
            'HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            'HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            Select Case ex.StripeError.ErrorType
                Case "card_error"
                    Trace.Warn("Code : " + ex.StripeError.Code)
                    Trace.Warn("Message : " + ex.StripeError.Message)
                Case "api_connection_error", "api_error", "authentication_error", "invalid_request_error", "rate_limit_error", "validation_error"
                    Trace.Warn("Code : " + ex.StripeError.Code)
                    Trace.Warn("Message : " + ex.StripeError.Message)
                Case Else
                    Trace.Warn("Code : " + ex.StripeError.Code)
                    Trace.Warn("Message : " + ex.StripeError.Message)
            End Select

            Dim strNewHistory As String = strHistory + "---------- Thankyou_Stripe_Temp RECORD ----- Catch ex As StripeException ManageClientCredit() " +
                                                       objFunction.ReturnString(DateTime.Now)

            UpdateCreditHistoryTemp_StripePaymentException(intCreditHistoryTempId, strNewHistory, ex)

        End Try
    End Sub

    ''' <summary>
    ''' This function is used to update history of credit_history_temp when error occur.
    ''' </summary>
    Sub UpdateCreditHistoryTemp_StripePaymentException(ByVal intCreditHistoryTempId As Integer, ByVal strHistory As String, ByVal ex As StripeException)
        Try
            Dim strNewHistory As String = strHistory + "<br/>" + "PAYMENT_EXCEPTION THANKYOU_STRIPE_TEMP " + objFunction.ReturnString(DateTime.Now) + "<br/>" +
                                                  objFunction.ReturnString(ex.StripeError.Code) + ", " +
                                                  objFunction.ReturnString(ex.StripeError.Message) + ", " +
                                                  objFunction.ReturnString(ex.StripeResponse.ResponseJson) + ", " +
                                                  objFunction.ReturnString(ex.StackTrace) + ", " +
                                                  objFunction.ReturnString(ex.HttpStatusCode) + ", " +
                                                  objFunction.ReturnString(ex.StripeError.ChargeId) + ", " +
                                                  objFunction.ReturnString(ex.StripeError.DeclineCode) + ", " +
                                                  objFunction.ReturnString(ex.StripeError.Error) + ", " +
                                                  objFunction.ReturnString(ex.StripeError.ErrorDescription) + ", " +
                                                  objFunction.ReturnString(ex.StripeError.ErrorType) + ", " +
                                                  objFunction.ReturnString(ex.StripeError.Parameter) + ", " +
                                                  objFunction.ReturnString(ex.StripeError.StripeResponse.RequestDate) + ", " +
                                                  objFunction.ReturnString(ex.StripeError.StripeResponse.RequestId) +
                                                  "<br/>" + objFunction.ReturnString(DateTime.Now)

            Trace.Warn("strNewHistory = " + strNewHistory)

            Session("ResponseAmountTaken") = "0.0"
            Session("ResponsePaymentStatus") = objFunction.ReturnString(ex.StripeError.Message)

            Dim objBECreditHistoryTemp As clsBECreditHistoryTemp = New clsBECreditHistoryTemp
            objBECreditHistoryTemp.CreditHistoryTempId = intCreditHistoryTempId
            objBECreditHistoryTemp.History = strNewHistory
            Dim intAffectedRow As Integer = (New clsDLCreditHistoryTemp()).UpdateCreditHistoryTempHistoryById(objBECreditHistoryTemp)

            Response.Redirect("thankyou_stripe.aspx")
        Catch exc As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", exc.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", exc.StackTrace)

            If exc.Message <> "Thread was being aborted." Then
                Dim strNewHistory As String = strHistory + "---------- Thankyou_Stripe_Temp RECORD ----- Catch ex As Exception UpdateCreditHistoryTemp_StripePaymentException() " +
                                                       objFunction.ReturnString(exc.Message) +
                                                       objFunction.ReturnString(exc.StackTrace) +
                                                       objFunction.ReturnString(exc.InnerException) +
                                                       objFunction.ReturnString(DateTime.Now)
                UpdateHistory(intCreditHistoryTempId, strNewHistory)
            End If

            'Session("ResponseAmountTaken") = "0"
            'Session("ResponsePaymentStatus") = "Unsuccessful. Please try again. Your card has not been charged."
            Response.Redirect("thankyou_stripe.aspx")
        End Try
    End Sub

    Sub UpdateHistory(ByVal intCreditHistoryTempId As Integer, ByVal strNewHistory As String)
        Try
            Dim objBECreditHistoryTemp As clsBECreditHistoryTemp = New clsBECreditHistoryTemp
            objBECreditHistoryTemp.CreditHistoryTempId = intCreditHistoryTempId
            objBECreditHistoryTemp.History = strNewHistory
            Dim intAffectedRow As Integer = (New clsDLCreditHistoryTemp()).UpdateCreditHistoryTempHistoryById(objBECreditHistoryTemp)
        Catch ex As Exception
            HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
            HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            'Session("ResponseAmountTaken") = "0"
            'Session("ResponsePaymentStatus") = "Unsuccessful. Please try again. Your card has not been charged."
            Response.Redirect("thankyou_stripe.aspx")
        End Try
    End Sub

End Class
