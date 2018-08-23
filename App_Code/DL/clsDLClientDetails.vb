Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports PlaceTheBall.BE

Namespace PlaceTheBall.DL

    Public Class clsDLClientDetails
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add client_detail data.
        ''' </summary>
        Public Function AddClientDetails(ByVal objBEClientDetails As clsBEClientDetails) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClientDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddClientDetails")
                cmd.Parameters.AddWithValue("ClientId", objBEClientDetails.ClientId)
                cmd.Parameters.AddWithValue("Name2", objBEClientDetails.Name2)
                cmd.Parameters.AddWithValue("Address1", objBEClientDetails.Address1)
                cmd.Parameters.AddWithValue("Address2", objBEClientDetails.Address2)
                cmd.Parameters.AddWithValue("City", objBEClientDetails.City)
                cmd.Parameters.AddWithValue("SexID", objBEClientDetails.SexID)
                cmd.Parameters.AddWithValue("PostCode", objBEClientDetails.PostCode)
                cmd.Parameters.AddWithValue("Phone1", objBEClientDetails.Phone1)
                cmd.Parameters.AddWithValue("Phone2", objBEClientDetails.Phone2)
                cmd.Parameters.AddWithValue("AdditionalInfo", objBEClientDetails.AdditionalInfo)
                cmd.Parameters.AddWithValue("Unsubscribe", objBEClientDetails.Unsubscribe)

                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddClientDetails")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update client details.
        ''' </summary>
        Public Function UpdateClientDetails(ByVal objBEClientDetails As clsBEClientDetails) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClientDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateClientDetails")
                cmd.Parameters.AddWithValue("ClientId", objBEClientDetails.ClientId)
                cmd.Parameters.AddWithValue("Name2", objBEClientDetails.Name2)
                cmd.Parameters.AddWithValue("Address1", objBEClientDetails.Address1)
                cmd.Parameters.AddWithValue("Address2", objBEClientDetails.Address2)
                cmd.Parameters.AddWithValue("City", objBEClientDetails.City)
                cmd.Parameters.AddWithValue("SexID", objBEClientDetails.SexID)
                cmd.Parameters.AddWithValue("PostCode", objBEClientDetails.PostCode)
                cmd.Parameters.AddWithValue("Phone1", objBEClientDetails.Phone1)
                cmd.Parameters.AddWithValue("Phone2", objBEClientDetails.Phone2)
                cmd.Parameters.AddWithValue("Unsubscribe", objBEClientDetails.Unsubscribe)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateClientDetails")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update client_details play_visited by id.
        ''' </summary>
        Public Function UpdateClientDetailsPlayVisitedById(ByVal objBEClientDetails As clsBEClientDetails) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClientDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateClientDetailsPlayVisitedById")
                cmd.Parameters.AddWithValue("ClientDetailsId", objBEClientDetails.ClientDetailsId)
                cmd.Parameters.AddWithValue("PlayVisited", objBEClientDetails.PlayVisited)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateClientDetailsPlayVisitedById")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update client_details buy_visited by id.
        ''' </summary>
        Public Function UpdateClientDetailsBuyVisitedById(ByVal objBEClientDetails As clsBEClientDetails) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClientDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateClientDetailsBuyVisitedById")
                cmd.Parameters.AddWithValue("ClientDetailsId", objBEClientDetails.ClientDetailsId)
                cmd.Parameters.AddWithValue("BuyVisited", objBEClientDetails.BuyVisited)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateClientDetailsBuyVisitedById")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update client_details additionalinfo by id.
        ''' </summary>
        Public Function UpdateClientDetailsAdditionalInfoById(ByVal objBEClientDetails As clsBEClientDetails) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClientDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateClientDetailsAdditionalInfoById")
                cmd.Parameters.AddWithValue("ClientDetailsId", objBEClientDetails.ClientDetailsId)
                cmd.Parameters.AddWithValue("AdditionalInfo", objBEClientDetails.AdditionalInfo)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateClientDetailsAdditionalInfoById")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update client_details blocked and blocked_whenx by id.
        ''' </summary>
        Public Function UpdateClientDetailsBlockedAndBlockedWhenxById(ByVal objBEClientDetails As clsBEClientDetails) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClientDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateClientDetailsBlockedAndBlockedWhenxById")
                cmd.Parameters.AddWithValue("ClientDetailsId", objBEClientDetails.ClientDetailsId)
                cmd.Parameters.AddWithValue("Blocked", objBEClientDetails.Blocked)
                cmd.Parameters.AddWithValue("BlockedWhenx", objBEClientDetails.BlockedWhenx)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateClientDetailsBlockedAndBlockedWhenxById")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get client_detail data by clientid.
        ''' </summary>
        Public Function GetClientDetailByClientId(ByVal intClientId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClientDetails"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetClientDetailByClientId")
                cmd.Parameters.AddWithValue("ClientId", intClientId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetClientDetailByClientId")
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
