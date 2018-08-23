Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports PlaceTheBall.BE

Namespace PlaceTheBall.DL

    Public Class clsDLCreditHistory
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add credit_history data.
        ''' </summary>
        Public Function AddCreditHistory(ByVal objBECreditHistory As clsBECreditHistory) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spCreditHistory"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddCreditHistory")
                cmd.Parameters.AddWithValue("UserId", objBECreditHistory.UserId)
                cmd.Parameters.AddWithValue("Creditx", objBECreditHistory.Creditx)
                cmd.Parameters.AddWithValue("Whenx", objBECreditHistory.Whenx)
                cmd.Parameters.AddWithValue("PaymentMethodId", objBECreditHistory.PaymentMethodId)
                cmd.Parameters.AddWithValue("AmountTaken", objBECreditHistory.AmountTaken)
                cmd.Parameters.AddWithValue("Ref", objBECreditHistory.Ref)
                
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddCreditHistory")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get credit_history by userid.
        ''' </summary>
        Public Function GetCreditHistoryByUId(ByVal intUserId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spCreditHistory"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetCreditHistoryByUId")
                cmd.Parameters.AddWithValue("UserId", intUserId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetCreditHistoryByUId")
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

