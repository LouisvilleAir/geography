'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: CoordinateDataSourceDB.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Data access class for the CoordinateDataSource table of the Geography database.
'             Provides Insert, Update, Delete, and Select operations for the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports System.Data.OleDb
Imports Tools.Data
Imports APCD.Geography.Business
Imports APCD.Geography.Collections
Imports APCD.Geography.Constants
Imports APCD.Geography.Globals

Namespace APCD.Geography.Data

    <Serializable()> Friend Class CoordinateDataSourceDB

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        'field ordinal positions (for use with datareader object)
        Private Structure FieldOrdinal
            Private _trash As String
            Public Shared CoordinateDataSourceID As Int32 'primary key
            Public Shared CoordinateDataSourceName As Int32
            Public Shared CoordinateDataSourceEISCode As Int32
        End Structure

        Private Structure StoredProcedure
            Private _trash As String
            Public Const Insert As String = "CoordinateDataSource_Insert"
            Public Const Update As String = "CoordinateDataSource_Update"
            Public Const Delete As String = "CoordinateDataSource_Delete"
            Public Const GetByPrimaryKey As String = "CoordinateDataSource_GetByPrimaryKey"
            Public Const GetAll As String = "CoordinateDataSource_GetAll"
            Public Const GetLookupTable As String = "CoordinateDataSource_GetLookupTable"
            Public Const GetByLookupName As String = "CoordinateDataSource_GetByLookupName"
        End Structure

        'enums
        Private Enum DMLType As Integer
            Insert
            Update
            Delete
        End Enum

        'sqlClient parameters
        Private m_prmintCoordinateDataSourceID As OleDbParameter 'primary key
        Private m_prmstrCoordinateDataSourceName As OleDbParameter
        Private m_prmstrCoordinateDataSourceEISCode As OleDbParameter

        Private Structure ParameterName
            Private _trash As String
            Public Const CoordinateDataSourceID As String = "@CoordinateDataSourceID"
            Public Const CoordinateDataSourceName As String = "@CoordinateDataSourceName"
            Public Const CoordinateDataSourceEISCode As String = "@CoordinateDataSourceEISCode"
        End Structure

#End Region '----- Member Variables -----

#Region "----- DML -----"

        Friend Function Insert(ByVal objCoordinateDataSource As CoordinateDataSource, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objCoordinateDataSource, DMLType.Insert, cmd)

        End Function

        Friend Function Update(ByVal objCoordinateDataSource As CoordinateDataSource, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objCoordinateDataSource, DMLType.Update, cmd)

        End Function

        Friend Function Delete(ByVal objCoordinateDataSource As CoordinateDataSource, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objCoordinateDataSource, DMLType.Delete, cmd)

        End Function

        Private Function DMLHelper(ByVal objCoordinateDataSource As CoordinateDataSource, ByVal iDMLType As DMLType, ByVal cmd As OleDbCommand) As Int32

            Dim intReturnValue As Int32
            Dim commandParameters() As OleDbParameter = Nothing

            With Me
                Call .InitializeParameterObjects()
                Call .AssignParameterValues(objCoordinateDataSource, iDMLType)
                commandParameters = .GetParameterArray(iDMLType)
                Select Case iDMLType
                    Case DMLType.Insert

                        intReturnValue = OleDbHelper.ExecuteNonQuery(cmd, StoredProcedure.Insert, commandParameters)
                    Case DMLType.Update

                        intReturnValue = OleDbHelper.ExecuteNonQuery(cmd, StoredProcedure.Update, commandParameters)
                    Case DMLType.Delete

                        intReturnValue = OleDbHelper.ExecuteNonQuery(cmd, StoredProcedure.Delete, commandParameters)
                End Select
            End With

            Return intReturnValue

        End Function

#End Region '----- DML -----

#Region "----- Helper Methods -----"

        Private Sub InitializeParameterObjects()

            Me.m_prmintCoordinateDataSourceID = Nothing
            Me.m_prmintCoordinateDataSourceID = New OleDbParameter

            Me.m_prmstrCoordinateDataSourceName = Nothing
            Me.m_prmstrCoordinateDataSourceName = New OleDbParameter

            Me.m_prmstrCoordinateDataSourceEISCode = Nothing
            Me.m_prmstrCoordinateDataSourceEISCode = New OleDbParameter

        End Sub

        Private Sub AssignParameterValues(ByVal objCoordinateDataSource As CoordinateDataSource, ByVal DMLOperation As DMLType)

            With Me
                Select Case DMLOperation

                    Case DMLType.Insert

                        With .m_prmintCoordinateDataSourceID
                            .ParameterName = ParameterName.CoordinateDataSourceID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objCoordinateDataSource.CoordinateDataSourceID
                        End With

                        With .m_prmstrCoordinateDataSourceName
                            .ParameterName = ParameterName.CoordinateDataSourceName
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objCoordinateDataSource.CoordinateDataSourceName
                        End With

                        With .m_prmstrCoordinateDataSourceEISCode
                            .ParameterName = ParameterName.CoordinateDataSourceEISCode
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objCoordinateDataSource.CoordinateDataSourceEISCode
                        End With

                    Case DMLType.Update

                        With .m_prmintCoordinateDataSourceID
                            .ParameterName = "@CoordinateDataSourceID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objCoordinateDataSource.CoordinateDataSourceID
                        End With

                        With .m_prmstrCoordinateDataSourceName
                            .ParameterName = "@CoordinateDataSourceName"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objCoordinateDataSource.CoordinateDataSourceName
                        End With

                        With .m_prmstrCoordinateDataSourceEISCode
                            .ParameterName = "@CoordinateDataSourceEISCode"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objCoordinateDataSource.CoordinateDataSourceEISCode
                        End With

                    Case DMLType.Delete

                        With .m_prmintCoordinateDataSourceID
                            .ParameterName = "@CoordinateDataSourceID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objCoordinateDataSource.CoordinateDataSourceID
                        End With

                End Select 'DMLOperation

            End With 'Me

        End Sub

        Private Function GetParameterArray(ByVal DMLOperation As DMLType) As OleDbParameter()

            Dim commandParameters() As OleDbParameter = Nothing

            Select Case DMLOperation
                Case DMLType.Insert
                    commandParameters = New OleDbParameter(2) {}
                    commandParameters(0) = Me.m_prmintCoordinateDataSourceID
                    commandParameters(1) = Me.m_prmstrCoordinateDataSourceName
                    commandParameters(2) = Me.m_prmstrCoordinateDataSourceEISCode
                Case DMLType.Update
                    commandParameters = New OleDbParameter(2) {}
                    commandParameters(0) = Me.m_prmintCoordinateDataSourceID
                    commandParameters(1) = Me.m_prmstrCoordinateDataSourceName
                    commandParameters(2) = Me.m_prmstrCoordinateDataSourceEISCode
                Case DMLType.Delete
                    commandParameters = New OleDbParameter(0) {}
                    commandParameters(0) = Me.m_prmintCoordinateDataSourceID
            End Select
            Return commandParameters

        End Function

        Private Sub SetFieldOrdinalValues(ByVal dr As OleDbDataReader)

            FieldOrdinal.CoordinateDataSourceID = dr.GetOrdinal(CoordinateDataSourceConstants.FieldName.CoordinateDataSourceID)
            FieldOrdinal.CoordinateDataSourceName = dr.GetOrdinal(CoordinateDataSourceConstants.FieldName.CoordinateDataSourceName)
            FieldOrdinal.CoordinateDataSourceEISCode = dr.GetOrdinal(CoordinateDataSourceConstants.FieldName.CoordinateDataSourceEISCode)

        End Sub

#End Region '----- Helper Methods -----

#Region "----- Lookup Methods -----"

        Friend Function GetAll() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetAll)

        End Function

        Friend Function GetLookupTable() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetLookupTable)

        End Function

        Friend Function GetByLookupName(ByVal strCoordinateDataSourceName As String) As CoordinateDataSource

            Dim objCoordinateDataSource As CoordinateDataSource = Nothing
            Dim cnGeography As OleDbConnection
            Dim drCoordinateDataSource As OleDbDataReader
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmstrCoordinateDataSourceName As OleDbParameter = New OleDbParameter

            With prmstrCoordinateDataSourceName
                .ParameterName = ParameterName.CoordinateDataSourceName
                .Direction = ParameterDirection.Input
                .Value = strCoordinateDataSourceName
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmstrCoordinateDataSourceName

            cnGeography = New OleDbConnection(GlobalVariables.ConnectionString)
            cnGeography.Open()
            drCoordinateDataSource = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByLookupName, commandParameters)
            If (drCoordinateDataSource.HasRows) Then
                objCoordinateDataSource = New CoordinateDataSource
                Call SetFieldOrdinalValues(drCoordinateDataSource)
                drCoordinateDataSource.Read()
                With objCoordinateDataSource
                    If (Not IsDBNull(drCoordinateDataSource(FieldOrdinal.CoordinateDataSourceID))) Then
                        .CoordinateDataSourceID = drCoordinateDataSource(FieldOrdinal.CoordinateDataSourceID)
                    End If
                    If (Not IsDBNull(drCoordinateDataSource(FieldOrdinal.CoordinateDataSourceName))) Then
                        .CoordinateDataSourceName = drCoordinateDataSource(FieldOrdinal.CoordinateDataSourceName)
                    End If
                    If (Not IsDBNull(drCoordinateDataSource(FieldOrdinal.CoordinateDataSourceEISCode))) Then
                        .CoordinateDataSourceEISCode = drCoordinateDataSource(FieldOrdinal.CoordinateDataSourceEISCode)
                    End If
                End With
            End If
            drCoordinateDataSource.Close()
            cnGeography.Close()

            Return objCoordinateDataSource

        End Function

        Friend Function GetByPrimaryKey(ByVal intCoordinateDataSourceID As Int32) As CoordinateDataSource

            Dim objCoordinateDataSource As CoordinateDataSource = Nothing
            Dim cnGeography As OleDbConnection
            Dim drCoordinateDataSource As OleDbDataReader
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmintCoordinateDataSourceID As OleDbParameter = New OleDbParameter

            With prmintCoordinateDataSourceID
                .ParameterName = ParameterName.CoordinateDataSourceID
                .Direction = ParameterDirection.Input
                .Value = intCoordinateDataSourceID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintCoordinateDataSourceID

            cnGeography = New OleDbConnection(GlobalVariables.ConnectionString)
            cnGeography.Open()
            drCoordinateDataSource = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByPrimaryKey, commandParameters)
            If (drCoordinateDataSource.HasRows) Then
                objCoordinateDataSource = New CoordinateDataSource
                Call SetFieldOrdinalValues(drCoordinateDataSource)
                drCoordinateDataSource.Read()
                With objCoordinateDataSource
                    If (Not IsDBNull(drCoordinateDataSource(FieldOrdinal.CoordinateDataSourceID))) Then
                        .CoordinateDataSourceID = drCoordinateDataSource(FieldOrdinal.CoordinateDataSourceID)
                    End If
                    If (Not IsDBNull(drCoordinateDataSource(FieldOrdinal.CoordinateDataSourceName))) Then
                        .CoordinateDataSourceName = drCoordinateDataSource(FieldOrdinal.CoordinateDataSourceName)
                    End If
                    If (Not IsDBNull(drCoordinateDataSource(FieldOrdinal.CoordinateDataSourceEISCode))) Then
                        .CoordinateDataSourceEISCode = drCoordinateDataSource(FieldOrdinal.CoordinateDataSourceEISCode)
                    End If
                End With
            End If
            drCoordinateDataSource.Close()
            cnGeography.Close()

            Return objCoordinateDataSource

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
