'***********************************************************************************************************************
'Assembly Name: Applications
'Filename: GlobalMethods.vb
'Author: Mike Farris
'Date: 08/12/2011
'Description: Provides a central point to access global variables used by the class library.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports System.Data.OleDb

Namespace Tools.Data

    <Serializable()> Friend Class OleDbHelper

        Public Shared Function ExecuteDataTable(ByVal connectionString As String, ByVal storedProcedureName As String) As DataTable

            Dim dtb As New DataTable
            Dim adp As New OleDbDataAdapter(storedProcedureName, connectionString)

            Try
                adp.SelectCommand.CommandType = CommandType.StoredProcedure
                adp.Fill(dtb)
            Catch ex As Exception
                Throw New ApplicationException(ex.Message)
            Finally
                If (adp.SelectCommand.Connection.State = ConnectionState.Open) Then adp.SelectCommand.Connection.Close()
            End Try

            Return dtb

        End Function

        Public Shared Function ExecuteDataTable(ByVal connectionString As String, ByVal storedProcedureName As String, ByVal commandParameters() As OleDbParameter) As DataTable

            Dim dtb As New DataTable
            Dim adp As New OleDbDataAdapter(storedProcedureName, connectionString)

            Try
                adp.SelectCommand.CommandType = CommandType.StoredProcedure
                For Each parameter As OleDbParameter In commandParameters
                    adp.SelectCommand.Parameters.Add(parameter)
                Next
                adp.Fill(dtb)
            Catch ex As Exception
                Throw New ApplicationException(ex.Message)
            Finally
                If (adp.SelectCommand.Connection.State = ConnectionState.Open) Then adp.SelectCommand.Connection.Close()
            End Try

            Return dtb

        End Function

        Public Shared Function ExecuteReader(ByVal cn As OleDbConnection, ByVal storedProcedureName As String, ByVal commandParameters() As OleDbParameter) As OleDbDataReader

            Dim dr As OleDbDataReader = Nothing
            Dim cmd As New OleDbCommand(storedProcedureName, cn)

            Try
                cmd.CommandType = CommandType.StoredProcedure
                For Each parameter As OleDbParameter In commandParameters
                    cmd.Parameters.Add(parameter)
                Next
                cmd.Connection = cn
                dr = cmd.ExecuteReader
            Catch ex As Exception
                Throw New ApplicationException(ex.Message)
            End Try

            Return dr

        End Function

        Public Shared Function ExecuteNonQuery(ByVal connectionString As String, ByVal storedProcedureName As String, ByVal commandParameters() As OleDbParameter) As Int32

            Dim cn As New OleDbConnection(connectionString)
            Dim cmd As New OleDbCommand(storedProcedureName, cn)
            Dim numberOfRowsAffected As Int32

            Try
                cmd.CommandType = CommandType.StoredProcedure
                For Each parameter As OleDbParameter In commandParameters
                    cmd.Parameters.Add(parameter)
                Next
                cn.Open()
                numberOfRowsAffected = cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw New ApplicationException(ex.Message)
            Finally
                If (cn.State = ConnectionState.Open) Then cn.Close()
            End Try

            Return numberOfRowsAffected

        End Function

        Public Shared Function ExecuteNonQuery(ByVal cmd As OleDbCommand, ByVal storedProcedureName As String, ByVal commandParameters() As OleDbParameter) As Int32

            Dim numberOfRowsAffected As Int32

            Try
                With cmd
                    cmd.CommandText = storedProcedureName
                    cmd.CommandType = CommandType.StoredProcedure
                    .Parameters.Clear()
                    For Each parameter As OleDbParameter In commandParameters
                        .Parameters.Add(parameter)
                    Next
                End With
                numberOfRowsAffected = cmd.ExecuteNonQuery()
            Catch ex As Exception
                Throw New ApplicationException(ex.Message)
            End Try

            Return numberOfRowsAffected

        End Function

        Public Shared Function ExecuteNonQuery(ByVal cmd As OleDbCommand, ByVal storedProcedureName As String, ByVal commandParameters() As OleDbParameter, ByRef insertedRowID As Int32) As Int32

            Dim numberOfRowsAffected As Int32

            Try
                With cmd
                    cmd.CommandText = storedProcedureName
                    cmd.CommandType = CommandType.StoredProcedure
                    .Parameters.Clear()
                    For Each parameter As OleDbParameter In commandParameters
                        .Parameters.Add(parameter)
                    Next

                    'insert the record
                    numberOfRowsAffected = .ExecuteNonQuery()

                    'get the primary key
                    .CommandText = "SELECT @@IDENTITY"
                    .CommandType = CommandType.Text
                    insertedRowID = CInt(.ExecuteScalar)
                End With
            Catch ex As Exception
                Throw New ApplicationException(ex.Message)
            End Try

            Return numberOfRowsAffected

        End Function

        Public Shared Function ExecuteNonQuery(ByVal connectionString As String, ByVal storedProcedureName As String, ByVal commandParameters() As OleDbParameter, ByRef insertedRowID As Int32) As Int32

            Dim cn As New OleDbConnection(connectionString)
            Dim cmd As New OleDbCommand(storedProcedureName, cn)
            Dim numberOfRowsAffected As Int32

            Try
                cmd.CommandType = CommandType.StoredProcedure
                For Each parameter As OleDbParameter In commandParameters
                    cmd.Parameters.Add(parameter)
                Next
                cn.Open()

                'insert the record
                numberOfRowsAffected = cmd.ExecuteNonQuery()

                'get the primary key
                cmd.CommandText = "SELECT @@IDENTITY"
                cmd.CommandType = CommandType.Text
                insertedRowID = CInt(cmd.ExecuteScalar) ' CInt(cmd.ExecuteScalar)
            Catch ex As Exception
                Throw New ApplicationException(ex.Message)
            Finally
                If (cn.State = ConnectionState.Open) Then cn.Close()
            End Try

            Return numberOfRowsAffected

        End Function

    End Class

End Namespace