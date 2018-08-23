Imports System
Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Imports PlaceTheBall.BE

Namespace PlaceTheBall.DL

    Public Class clsDLBalls
        Inherits BaseDB

        Dim objFunction As New clsCommon()

        ''' <summary>
        ''' This function is used to add credit_history data.
        ''' </summary>
        Public Function AddBalls(ByVal objBEBalls As clsBEBalls) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spBalls"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "AddBalls")
                cmd.Parameters.AddWithValue("UserId", objBEBalls.UserId)
                cmd.Parameters.AddWithValue("GameId", objBEBalls.GameId)
                cmd.Parameters.AddWithValue("Posx", objBEBalls.Posx)
                cmd.Parameters.AddWithValue("Posy", objBEBalls.Posy)
                cmd.Parameters.AddWithValue("Whenx", objBEBalls.Whenx)
                cmd.Parameters.AddWithValue("Verifyx", objBEBalls.Verifyx)
                cmd.Parameters.AddWithValue("Randomx", objBEBalls.Randomx)
                cmd.Parameters.AddWithValue("Wonx", objBEBalls.Wonx)
                cmd.Parameters.AddWithValue("Distx", objBEBalls.Distx)
                
                Dim intAffectedRow As Integer = ExecuteScalarByCommandReturnAffectedRow(cmd, "AddBalls")
                Return intAffectedRow

            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to update balls wonx and distx by id.
        ''' </summary>
        Public Function UpdateBallsWonxDistxById(ByVal objBEBalls As clsBEBalls) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spBalls"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "UpdateBallsWonxDistxById")
                cmd.Parameters.AddWithValue("BallId", objBEBalls.BallId)
                cmd.Parameters.AddWithValue("Wonx", objBEBalls.Wonx)
                cmd.Parameters.AddWithValue("Distx", objBEBalls.Distx)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "UpdateBallsWonxDistxById")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to delete balls entry by gameid.
        ''' </summary>
        Public Function DeleteBallsByGameId(ByVal intGameId As Integer) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spBalls"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteBallsByGameId")
                cmd.Parameters.AddWithValue("GameId", intGameId)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteBallsByGameId")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to delete balls entry by id.
        ''' </summary>
        Public Function DeleteBallsById(ByVal intBallId As Integer) As Integer
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spBalls"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "DeleteBallsById")
                cmd.Parameters.AddWithValue("BallId", intBallId)
                Return ExecuteScalarByCommandReturnAffectedRow(cmd, "DeleteBallsById")
            Catch ex As Exception
                HttpContext.Current.Trace.Warn("Exception message:  ::", ex.Message)
                HttpContext.Current.Trace.Warn("Error Stack Trace ::", ex.StackTrace)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' This function is used to get ball details by userid.
        ''' </summary>
        Public Function GetBallDetailsByUId(ByVal intUserId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spBalls"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBallDetailsByUId")
                cmd.Parameters.AddWithValue("UserId", intUserId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBallDetailsByUId")
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
        ''' This function is used to get ball details by gameid.
        ''' </summary>
        Public Function GetBallDetailsByGameId(ByVal intGameId As Integer, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spBalls"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBallDetailsByGameId")
                cmd.Parameters.AddWithValue("GameId", intGameId)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBallDetailsByGameId")
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
        ''' This function is used to get ball details by gameid and wonx.
        ''' </summary>
        Public Function GetBallDetailsByGameIdAndWonx(ByVal objBEBalls As clsBEBalls, ByVal intCompanyId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spBalls"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetBallDetailsByGameIdAndWonx")
                cmd.Parameters.AddWithValue("GameId", objBEBalls.GameId)
                cmd.Parameters.AddWithValue("Wonx", objBEBalls.Wonx)
                cmd.Parameters.AddWithValue("CompanyId", intCompanyId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetBallDetailsByGameIdAndWonx")
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
        ''' This function is used to get games winner by gameid.
        ''' </summary>
        Public Function GetWinnerByGameId(ByVal intGameId As Integer) As DataSet
            Dim cmd As New SqlCommand()
            Try
                cmd.CommandText = "STB_FE_spBalls"
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.AddWithValue("Action", "GetWinnerByGameId")
                cmd.Parameters.AddWithValue("GameId", intGameId)
                Dim dstData As DataSet = FillDataSetByCommand(cmd, "GetWinnerByGameId")
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
