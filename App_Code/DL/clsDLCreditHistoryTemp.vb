Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports PlaceTheBall.BE

Namespace PlaceTheBall.DL

    Public Class clsDLCreditHistoryTemp
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add credit_history_temp data.
        ''' </summary>
        Public Function AddCreditHistoryTemp(ByVal objBECreditHistoryTemp As clsBECreditHistoryTemp) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spCreditHistoryTemp"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddCreditHistoryTemp")
                cmd.Parameters.AddWithValue("UserId", objBECreditHistoryTemp.UserId)
                cmd.Parameters.AddWithValue("Creditx", objBECreditHistoryTemp.Creditx)
                cmd.Parameters.AddWithValue("Whenx", objBECreditHistoryTemp.Whenx)
                cmd.Parameters.AddWithValue("PaymentMethodId", objBECreditHistoryTemp.PaymentMethodId)
                cmd.Parameters.AddWithValue("AmountTaken", objBECreditHistoryTemp.AmountTaken)
                cmd.Parameters.AddWithValue("Ref", objBECreditHistoryTemp.Ref)
                cmd.Parameters.AddWithValue("History", objBECreditHistoryTemp.History)
                cmd.Parameters.AddWithValue("Authorised", objBECreditHistoryTemp.Authorised)
                cmd.Parameters.AddWithValue("Emailx", objBECreditHistoryTemp.Emailx)

                Dim intCreditHistoryTempId As Integer = ExecuteNoneQueryByCommand(cmd, "AddCreditHistoryTemp", "Y")
                Return intCreditHistoryTempId

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update authotised by id.
        ''' </summary>
        Public Function UpdateCreditHistoryTempAuthorisedById(ByVal objBECreditHistoryTemp As clsBECreditHistoryTemp) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spCreditHistoryTemp"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateCreditHistoryTempAuthorisedById")
                cmd.Parameters.AddWithValue("CreditHistoryTempId", objBECreditHistoryTemp.CreditHistoryTempId)
                cmd.Parameters.AddWithValue("Authorised", objBECreditHistoryTemp.Authorised)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateCreditHistoryTempAuthorisedById")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update history by id.
        ''' </summary>
        Public Function UpdateCreditHistoryTempHistoryById(ByVal objBECreditHistoryTemp As clsBECreditHistoryTemp) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spCreditHistoryTemp"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateCreditHistoryTempHistoryById")
                cmd.Parameters.AddWithValue("CreditHistoryTempId", objBECreditHistoryTemp.CreditHistoryTempId)
                cmd.Parameters.AddWithValue("History", objBECreditHistoryTemp.History)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateCreditHistoryTempHistoryById")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get credit_history_temp by id.
        ''' </summary>
        Public Function GetCreditHistoryTempById(ByVal intCreditHistoryTempId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spCreditHistoryTemp"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetCreditHistoryTempById")
                cmd.Parameters.AddWithValue("CreditHistoryTempId", intCreditHistoryTempId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetCreditHistoryTempById")
                If objFunction.CheckDataSet(dstData) Then
                    Return dstData
                End If
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get credit_history_temp with client detail by id.
        ''' </summary>
        Public Function GetCreditHistoryTempWithClientById(ByVal intCreditHistoryTempId As Integer, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spCreditHistoryTemp"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetCreditHistoryTempWithClientById")
                cmd.Parameters.AddWithValue("CreditHistoryTempId", intCreditHistoryTempId)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetCreditHistoryTempWithClientById")
                If objFunction.CheckDataSet(dstData) Then
                    Return dstData
                End If
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get credit_history_temp by emailx.
        ''' </summary>
        Public Function GetCreditHistoryTempByEmailx(ByVal strEmailx As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spCreditHistoryTemp"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetCreditHistoryTempByEmailx")
                cmd.Parameters.AddWithValue("Emailx", strEmailx)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetCreditHistoryTempByEmailx")
                If objFunction.CheckDataSet(dstData) Then
                    Return dstData
                End If
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get credit_history_temp with clientid & companyid.
        ''' </summary>
        Public Function GetCreditHistoryTempByClientId(ByVal intUserId As Integer, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spCreditHistoryTemp"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetCreditHistoryTempByClientId")
                cmd.Parameters.AddWithValue("UserId", intUserId)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetCreditHistoryTempByClientId")
                If objFunction.CheckDataSet(dstData) Then
                    Return dstData
                End If
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get top 500 record of credit_history_temp order by whenx.
        ''' </summary>
        Public Function GetCreditHistoryTempTop500Rec(ByVal intPaymentMethodId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spCreditHistoryTemp"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetCreditHistoryTempTop500Rec")
                cmd.Parameters.AddWithValue("PaymentMethodId", intPaymentMethodId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetCreditHistoryTempTop500Rec")
                If objFunction.CheckDataSet(dstData) Then
                    Return dstData
                End If
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

    End Class

End Namespace
