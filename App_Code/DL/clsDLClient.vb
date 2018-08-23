Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports PlaceTheBall.BE

Namespace PlaceTheBall.DL

    Public Class clsDLClient
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add client data.
        ''' </summary>
        Public Function AddClient(ByVal objBEClient As clsBEClient) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClient"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddClient")
                cmd.Parameters.AddWithValue("Name1", objBEClient.Name1)
                cmd.Parameters.AddWithValue("Emailx", objBEClient.Emailx)
                cmd.Parameters.AddWithValue("CompanyId", objBEClient.CompanyId)
                cmd.Parameters.AddWithValue("Creditx", objBEClient.Creditx)
                cmd.Parameters.AddWithValue("DateAdded", objBEClient.DateAdded)
                cmd.Parameters.AddWithValue("Passwordx", objBEClient.Passwordx)
                cmd.Parameters.AddWithValue("Exhibitionx", objBEClient.Exhibitionx)
                cmd.Parameters.AddWithValue("Verifiedx", objBEClient.Verifiedx)

                Dim intClientId As Integer = ExecuteNoneQueryByCommand(cmd, "AddClient", "Y")
                Return intClientId

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update client data.
        ''' </summary>
        Public Function UpdateClient(ByVal objBEClient As clsBEClient) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClient"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateClient")
                cmd.Parameters.AddWithValue("ClientId", objBEClient.ClientId)
                cmd.Parameters.AddWithValue("Name1", objBEClient.Name1)
                cmd.Parameters.AddWithValue("Emailx", objBEClient.Emailx)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateClient")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update verifiedx by id.
        ''' </summary>
        Public Function UpdateClientVerifiedxStatus(ByVal objBEClient As clsBEClient) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClient"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateClientVerifiedxStatus")
                cmd.Parameters.AddWithValue("Verifiedx", objBEClient.Verifiedx)
                cmd.Parameters.AddWithValue("ClientId", objBEClient.ClientId)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateClientVerifiedxStatus")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update password by id.
        ''' </summary>
        Public Function UpdateClientPassword(ByVal objBEClient As clsBEClient) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClient"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateClientPassword")
                cmd.Parameters.AddWithValue("Passwordx", objBEClient.Passwordx)
                cmd.Parameters.AddWithValue("ClientId", objBEClient.ClientId)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateClientPassword")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update creditx by id.
        ''' </summary>
        Public Function UpdateClientCreditx(ByVal objBEClient As clsBEClient) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClient"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateClientCreditx")
                cmd.Parameters.AddWithValue("Creditx", objBEClient.Creditx)
                cmd.Parameters.AddWithValue("ClientId", objBEClient.ClientId)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateClientCreditx")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update lastlogin by id.
        ''' </summary>
        Public Function UpdateClientLastLogin(ByVal objBEClient As clsBEClient) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClient"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateClientLastLogin")
                cmd.Parameters.AddWithValue("LastLogin", objBEClient.LastLogin)
                cmd.Parameters.AddWithValue("ClientId", objBEClient.ClientId)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateClientLastLogin")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update dateadded by id.
        ''' </summary>
        Public Function UpdateClientDateAdded(ByVal objBEClient As clsBEClient) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClient"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateClientDateAdded")
                cmd.Parameters.AddWithValue("DateAdded", objBEClient.DateAdded)
                cmd.Parameters.AddWithValue("ClientId", objBEClient.ClientId)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateClientDateAdded")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to check client email id.
        ''' </summary>
        Public Function CheckClientEmail(ByVal objBEClient As clsBEClient) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClient"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "CheckClientEmail")
                cmd.Parameters.AddWithValue("Emailx", objBEClient.Emailx)
                cmd.Parameters.AddWithValue("CompanyId", objBEClient.CompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "CheckClientEmail")
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
        ''' This function is used to get client data by id.
        ''' </summary>
        Public Function GetClientById(ByVal objBEClient As clsBEClient) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClient"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetClientById")
                cmd.Parameters.AddWithValue("ClientId", objBEClient.ClientId)
                cmd.Parameters.AddWithValue("CompanyId", objBEClient.CompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetClientById")
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
        ''' This function is used to get sum of client credit by company_id.
        ''' </summary>
        Public Function GetSumOfClientCreditByCompanyId(ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClient"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetSumOfClientCreditByCompanyId")
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetSumOfClientCreditByCompanyId")
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
        ''' This function is used to get client and client_details data by clientid.
        ''' </summary>
        Public Function GetClientAndClientDetailById(ByVal objBEClient As clsBEClient) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClient"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetClientAndClientDetailById")
                cmd.Parameters.AddWithValue("ClientId", objBEClient.ClientId)
                cmd.Parameters.AddWithValue("CompanyId", objBEClient.CompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetClientAndClientDetailById")
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
        ''' This function is used to get client and client_details data by company_id and verifiedx.
        ''' </summary>
        Public Function GetClientAndClientDetailByCompanyIdAndVerifiedx(ByVal objBEClient As clsBEClient) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClient"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetClientAndClientDetailByCompanyIdAndVerifiedx")
                cmd.Parameters.AddWithValue("CompanyId", objBEClient.CompanyId)
                cmd.Parameters.AddWithValue("Verifiedx", objBEClient.Verifiedx)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetClientAndClientDetailByCompanyIdAndVerifiedx")
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
        ''' This function is used to check the login credential of client.
        ''' </summary>
        Public Function CheckClientLogin(ByVal objBEClient As clsBEClient) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClient"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "CheckClientLogin")
                cmd.Parameters.AddWithValue("Emailx", objBEClient.Emailx)
                cmd.Parameters.AddWithValue("Passwordx", objBEClient.Passwordx)
                cmd.Parameters.AddWithValue("CompanyId", objBEClient.CompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "CheckClientLogin")
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
        ''' This function is used to get client data by company_id and verifiedx.
        ''' </summary>
        Public Function GetClientByCompanyIdAndVerifiedx(ByVal objBEClient As clsBEClient) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClient"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetClientByCompanyIdAndVerifiedx")
                cmd.Parameters.AddWithValue("CompanyId", objBEClient.CompanyId)
                cmd.Parameters.AddWithValue("Verifiedx", objBEClient.Verifiedx)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetClientByCompanyIdAndVerifiedx")
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
        ''' This function is used to get client data by name1,email,phone1 and verifiedx.
        ''' </summary>
        Public Function GetClientDetailByNameEmailPhoneAndVerifiedx(ByVal objBEClient As clsBEClient, ByVal strPhoneNo As String) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClient"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetClientDetailByNameEmailPhoneAndVerifiedx")
                cmd.Parameters.AddWithValue("Name1", objBEClient.Name1)
                cmd.Parameters.AddWithValue("Emailx", objBEClient.Emailx)
                cmd.Parameters.AddWithValue("Phone1", strPhoneNo)
                cmd.Parameters.AddWithValue("Verifiedx", objBEClient.Verifiedx)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetClientDetailByNameEmailPhoneAndVerifiedx")
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
        ''' This function is used to get dashboard quick stats details.
        ''' </summary>
        Public Function DownloadClientData(ByVal strAction As String, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClient"
                cmd.CommandType = CommandType.StoredProcedure
                If strAction = "DownloadAll" Then
                    cmd.Parameters.AddWithValue("Action", "DownloadAll")
                    cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                ElseIf strAction = "DownloadNotLoggedIn" Then
                    cmd.Parameters.AddWithValue("Action", "DownloadNotLoggedIn")
                    cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                ElseIf strAction = "DownloadNotPressedBuy" Then
                    cmd.Parameters.AddWithValue("Action", "DownloadNotPressedBuy")
                    cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                ElseIf strAction = "DownloadNotPressedPlay" Then
                    cmd.Parameters.AddWithValue("Action", "DownloadNotPressedPlay")
                    cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                ElseIf strAction = "DownloadVerifiedOnly" Then
                    cmd.Parameters.AddWithValue("Action", "DownloadVerifiedOnly")
                    cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                ElseIf strAction = "DownloadNotVerified" Then
                    cmd.Parameters.AddWithValue("Action", "DownloadNotVerified")
                    cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                ElseIf strAction = "DownloadPurchasedCredits" Then
                    cmd.Parameters.AddWithValue("Action", "DownloadPurchasedCredits")
                    cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                ElseIf strAction = "DownloadNeverPurchasedCredits" Then
                    cmd.Parameters.AddWithValue("Action", "DownloadNeverPurchasedCredits")
                    cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                End If

                Dim dstData As DataSet = FillDataSetByCommand(cmd, "DownloadClientData")
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
        ''' This function is used to get client data by id.
        ''' </summary>
        Public Function GetClientByNameAndEmailx(ByVal objBEClient As clsBEClient) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClient"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetClientByNameAndEmailx")
                cmd.Parameters.AddWithValue("Name1", objBEClient.Name1)
                cmd.Parameters.AddWithValue("Emailx", objBEClient.Emailx)
                cmd.Parameters.AddWithValue("CompanyId", objBEClient.CompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetClientByNameAndEmailx")
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
        ''' This function is used to update client data.
        ''' </summary>
        Public Function UpdateClientData(ByVal objBEClient As clsBEClient) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spClient"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateClientData")
                cmd.Parameters.AddWithValue("ClientId", objBEClient.ClientId)
                cmd.Parameters.AddWithValue("Name1", objBEClient.Name1)
                cmd.Parameters.AddWithValue("Emailx", objBEClient.Emailx)
                cmd.Parameters.AddWithValue("Creditx", objBEClient.Creditx)
                cmd.Parameters.AddWithValue("Passwordx", objBEClient.Passwordx)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateClientData")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

    End Class

End Namespace