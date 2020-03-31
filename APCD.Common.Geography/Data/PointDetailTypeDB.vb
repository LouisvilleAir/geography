'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: PointDetailTypeDB.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Data access class for the PointDetailType table of the Geography database.
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

    <Serializable()> Friend Class PointDetailTypeDB

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        'field ordinal positions (for use with datareader object)
        Private Structure FieldOrdinal
            Private _trash As String
            Public Shared PointDetailTypeID As Int32 'primary key
            Public Shared PointDetailTypeName As Int32
        End Structure

        Private Structure StoredProcedure
            Private _trash As String
            Public Const Insert As String = "PointDetailType_Insert"
            Public Const Update As String = "PointDetailType_Update"
            Public Const Delete As String = "PointDetailType_Delete"
            Public Const GetByPrimaryKey As String = "PointDetailType_GetByPrimaryKey"
            Public Const GetAll As String = "PointDetailType_GetAll"
            Public Const GetLookupTable As String = "PointDetailType_GetLookupTable"
            Public Const GetByLookupName As String = "PointDetailType_GetByLookupName"
        End Structure

        'enums
        Private Enum DMLType As Integer
            Insert
            Update
            Delete
        End Enum

        'sqlClient parameters
        Private m_prmintPointDetailTypeID As OleDbParameter 'primary key
        Private m_prmstrPointDetailTypeName As OleDbParameter

        Private Structure ParameterName
            Private _trash As String
            Public Const PointDetailTypeID As String = "@PointDetailTypeID"
            Public Const PointDetailTypeName As String = "@PointDetailTypeName"
        End Structure

#End Region '----- Member Variables -----

#Region "----- DML -----"

        Friend Function Insert(ByVal objPointDetailType As PointDetailType, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objPointDetailType, DMLType.Insert, cmd)

        End Function

        Friend Function Update(ByVal objPointDetailType As PointDetailType, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objPointDetailType, DMLType.Update, cmd)

        End Function

        Friend Function Delete(ByVal objPointDetailType As PointDetailType, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objPointDetailType, DMLType.Delete, cmd)

        End Function

        Private Function DMLHelper(ByVal objPointDetailType As PointDetailType, ByVal iDMLType As DMLType, ByVal cmd As OleDbCommand) As Int32

            Dim intReturnValue As Int32
            Dim commandParameters() As OleDbParameter = Nothing

            With Me
                Call .InitializeParameterObjects()
                Call .AssignParameterValues(objPointDetailType, iDMLType)
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

            Me.m_prmintPointDetailTypeID = Nothing
            Me.m_prmintPointDetailTypeID = New OleDbParameter

            Me.m_prmstrPointDetailTypeName = Nothing
            Me.m_prmstrPointDetailTypeName = New OleDbParameter

        End Sub

        Private Sub AssignParameterValues(ByVal objPointDetailType As PointDetailType, ByVal DMLOperation As DMLType)

            With Me
                Select Case DMLOperation

                    Case DMLType.Insert

                        With .m_prmintPointDetailTypeID
                            .ParameterName = ParameterName.PointDetailTypeID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPointDetailType.PointDetailTypeID
                        End With

                        With .m_prmstrPointDetailTypeName
                            .ParameterName = ParameterName.PointDetailTypeName
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPointDetailType.PointDetailTypeName
                        End With

                    Case DMLType.Update

                        With .m_prmintPointDetailTypeID
                            .ParameterName = "@PointDetailTypeID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPointDetailType.PointDetailTypeID
                        End With

                        With .m_prmstrPointDetailTypeName
                            .ParameterName = "@PointDetailTypeName"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPointDetailType.PointDetailTypeName
                        End With

                    Case DMLType.Delete

                        With .m_prmintPointDetailTypeID
                            .ParameterName = "@PointDetailTypeID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPointDetailType.PointDetailTypeID
                        End With

                End Select 'DMLOperation

            End With 'Me

        End Sub

        Private Function GetParameterArray(ByVal DMLOperation As DMLType) As OleDbParameter()

            Dim commandParameters() As OleDbParameter = Nothing

            Select Case DMLOperation
                Case DMLType.Insert
                    commandParameters = New OleDbParameter(1) {}
                    commandParameters(0) = Me.m_prmintPointDetailTypeID
                    commandParameters(1) = Me.m_prmstrPointDetailTypeName
                Case DMLType.Update
                    commandParameters = New OleDbParameter(1) {}
                    commandParameters(0) = Me.m_prmintPointDetailTypeID
                    commandParameters(1) = Me.m_prmstrPointDetailTypeName
                Case DMLType.Delete
                    commandParameters = New OleDbParameter(0) {}
                    commandParameters(0) = Me.m_prmintPointDetailTypeID
            End Select
            Return commandParameters

        End Function

        Private Sub SetFieldOrdinalValues(ByVal dr As OleDbDataReader)

            FieldOrdinal.PointDetailTypeID = dr.GetOrdinal(PointDetailTypeConstants.FieldName.PointDetailTypeID)
            FieldOrdinal.PointDetailTypeName = dr.GetOrdinal(PointDetailTypeConstants.FieldName.PointDetailTypeName)

        End Sub

#End Region '----- Helper Methods -----

#Region "----- Lookup Methods -----"

        Friend Function GetAll() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetAll)

        End Function

        Friend Function GetLookupTable() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetLookupTable)

        End Function

        Friend Function GetByLookupName(ByVal strPointDetailTypeName As String) As PointDetailType

            Dim objPointDetailType As PointDetailType = Nothing
            Dim cnGeography As OleDbConnection
            Dim drPointDetailType As OleDbDataReader
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmstrPointDetailTypeName As OleDbParameter = New OleDbParameter

            With prmstrPointDetailTypeName
                .ParameterName = ParameterName.PointDetailTypeName
                .Direction = ParameterDirection.Input
                .Value = strPointDetailTypeName
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmstrPointDetailTypeName

            cnGeography = New OleDbConnection(GlobalVariables.ConnectionString)
            cnGeography.Open()
            drPointDetailType = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByLookupName, commandParameters)
            If (drPointDetailType.HasRows) Then
                objPointDetailType = New PointDetailType
                Call SetFieldOrdinalValues(drPointDetailType)
                drPointDetailType.Read()
                With objPointDetailType
                    If (Not IsDBNull(drPointDetailType(FieldOrdinal.PointDetailTypeID))) Then
                        .PointDetailTypeID = drPointDetailType(FieldOrdinal.PointDetailTypeID)
                    End If
                    If (Not IsDBNull(drPointDetailType(FieldOrdinal.PointDetailTypeName))) Then
                        .PointDetailTypeName = drPointDetailType(FieldOrdinal.PointDetailTypeName)
                    End If
                End With
            End If
            drPointDetailType.Close()
            cnGeography.Close()

            Return objPointDetailType

        End Function

        Friend Function GetByPrimaryKey(ByVal intPointDetailTypeID As Int32) As PointDetailType

            Dim objPointDetailType As PointDetailType = Nothing
            Dim cnGeography As OleDbConnection
            Dim drPointDetailType As OleDbDataReader
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmintPointDetailTypeID As OleDbParameter = New OleDbParameter

            With prmintPointDetailTypeID
                .ParameterName = ParameterName.PointDetailTypeID
                .Direction = ParameterDirection.Input
                .Value = intPointDetailTypeID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintPointDetailTypeID

            cnGeography = New OleDbConnection(GlobalVariables.ConnectionString)
            cnGeography.Open()
            drPointDetailType = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByPrimaryKey, commandParameters)
            If (drPointDetailType.HasRows) Then
                objPointDetailType = New PointDetailType
                Call SetFieldOrdinalValues(drPointDetailType)
                drPointDetailType.Read()
                With objPointDetailType
                    If (Not IsDBNull(drPointDetailType(FieldOrdinal.PointDetailTypeID))) Then
                        .PointDetailTypeID = drPointDetailType(FieldOrdinal.PointDetailTypeID)
                    End If
                    If (Not IsDBNull(drPointDetailType(FieldOrdinal.PointDetailTypeName))) Then
                        .PointDetailTypeName = drPointDetailType(FieldOrdinal.PointDetailTypeName)
                    End If
                End With
            End If
            drPointDetailType.Close()
            cnGeography.Close()

            Return objPointDetailType

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
