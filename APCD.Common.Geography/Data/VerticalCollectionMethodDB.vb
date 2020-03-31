'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: VerticalCollectionMethodDB.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Data access class for the VerticalCollectionMethod table of the Geography database.
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

    <Serializable()> Friend Class VerticalCollectionMethodDB

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        'field ordinal positions (for use with datareader object)
        Private Structure FieldOrdinal
            Private _trash As String
            Public Shared VerticalCollectionMethodID As Int32 'primary key
            Public Shared VerticalCollectionMethodName As Int32
            Public Shared VerticalCollectionMethodDescription As Int32
        End Structure

        Private Structure StoredProcedure
            Private _trash As String
            Public Const Insert As String = "VerticalCollectionMethod_Insert"
            Public Const Update As String = "VerticalCollectionMethod_Update"
            Public Const Delete As String = "VerticalCollectionMethod_Delete"
            Public Const GetByPrimaryKey As String = "VerticalCollectionMethod_GetByPrimaryKey"
            Public Const GetAll As String = "VerticalCollectionMethod_GetAll"
            Public Const GetLookupTable As String = "VerticalCollectionMethod_GetLookupTable"
            Public Const GetByLookupName As String = "VerticalCollectionMethod_GetByLookupName"
        End Structure

        'enums
        Private Enum DMLType As Integer
            Insert
            Update
            Delete
        End Enum

        'sqlClient parameters
        Private m_prmintVerticalCollectionMethodID As OleDbParameter 'primary key
        Private m_prmstrVerticalCollectionMethodName As OleDbParameter
        Private m_prmstrVerticalCollectionMethodDescription As OleDbParameter

        Private Structure ParameterName
            Private _trash As String
            Public Const VerticalCollectionMethodID As String = "@VerticalCollectionMethodID"
            Public Const VerticalCollectionMethodName As String = "@VerticalCollectionMethodName"
            Public Const VerticalCollectionMethodDescription As String = "@VerticalCollectionMethodDescription"
        End Structure

#End Region '----- Member Variables -----

#Region "----- DML -----"

        Friend Function Insert(ByVal objVerticalCollectionMethod As VerticalCollectionMethod, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objVerticalCollectionMethod, DMLType.Insert, cmd)

        End Function

        Friend Function Update(ByVal objVerticalCollectionMethod As VerticalCollectionMethod, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objVerticalCollectionMethod, DMLType.Update, cmd)

        End Function

        Friend Function Delete(ByVal objVerticalCollectionMethod As VerticalCollectionMethod, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objVerticalCollectionMethod, DMLType.Delete, cmd)

        End Function

        Private Function DMLHelper(ByVal objVerticalCollectionMethod As VerticalCollectionMethod, ByVal iDMLType As DMLType, ByVal cmd As OleDbCommand) As Int32

            Dim intReturnValue As Int32
            Dim commandParameters() As OleDbParameter = Nothing

            With Me
                Call .InitializeParameterObjects()
                Call .AssignParameterValues(objVerticalCollectionMethod, iDMLType)
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

            Me.m_prmintVerticalCollectionMethodID = Nothing
            Me.m_prmintVerticalCollectionMethodID = New OleDbParameter

            Me.m_prmstrVerticalCollectionMethodName = Nothing
            Me.m_prmstrVerticalCollectionMethodName = New OleDbParameter

            Me.m_prmstrVerticalCollectionMethodDescription = Nothing
            Me.m_prmstrVerticalCollectionMethodDescription = New OleDbParameter

        End Sub

        Private Sub AssignParameterValues(ByVal objVerticalCollectionMethod As VerticalCollectionMethod, ByVal DMLOperation As DMLType)

            With Me
                Select Case DMLOperation

                    Case DMLType.Insert

                        With .m_prmintVerticalCollectionMethodID
                            .ParameterName = ParameterName.VerticalCollectionMethodID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objVerticalCollectionMethod.VerticalCollectionMethodID
                        End With

                        With .m_prmstrVerticalCollectionMethodName
                            .ParameterName = ParameterName.VerticalCollectionMethodName
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objVerticalCollectionMethod.VerticalCollectionMethodName
                        End With

                        With .m_prmstrVerticalCollectionMethodDescription
                            .ParameterName = ParameterName.VerticalCollectionMethodDescription
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objVerticalCollectionMethod.VerticalCollectionMethodDescription
                        End With

                    Case DMLType.Update

                        With .m_prmintVerticalCollectionMethodID
                            .ParameterName = "@VerticalCollectionMethodID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objVerticalCollectionMethod.VerticalCollectionMethodID
                        End With

                        With .m_prmstrVerticalCollectionMethodName
                            .ParameterName = "@VerticalCollectionMethodName"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objVerticalCollectionMethod.VerticalCollectionMethodName
                        End With

                        With .m_prmstrVerticalCollectionMethodDescription
                            .ParameterName = "@VerticalCollectionMethodDescription"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objVerticalCollectionMethod.VerticalCollectionMethodDescription
                        End With

                    Case DMLType.Delete

                        With .m_prmintVerticalCollectionMethodID
                            .ParameterName = "@VerticalCollectionMethodID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objVerticalCollectionMethod.VerticalCollectionMethodID
                        End With

                End Select 'DMLOperation

            End With 'Me

        End Sub

        Private Function GetParameterArray(ByVal DMLOperation As DMLType) As OleDbParameter()

            Dim commandParameters() As OleDbParameter = Nothing

            Select Case DMLOperation
                Case DMLType.Insert
                    commandParameters = New OleDbParameter(2) {}
                    commandParameters(0) = Me.m_prmintVerticalCollectionMethodID
                    commandParameters(1) = Me.m_prmstrVerticalCollectionMethodName
                    commandParameters(2) = Me.m_prmstrVerticalCollectionMethodDescription
                Case DMLType.Update
                    commandParameters = New OleDbParameter(2) {}
                    commandParameters(0) = Me.m_prmintVerticalCollectionMethodID
                    commandParameters(1) = Me.m_prmstrVerticalCollectionMethodName
                    commandParameters(2) = Me.m_prmstrVerticalCollectionMethodDescription
                Case DMLType.Delete
                    commandParameters = New OleDbParameter(0) {}
                    commandParameters(0) = Me.m_prmintVerticalCollectionMethodID
            End Select
            Return commandParameters

        End Function

        Private Sub SetFieldOrdinalValues(ByVal dr As OleDbDataReader)

            FieldOrdinal.VerticalCollectionMethodID = dr.GetOrdinal(VerticalCollectionMethodConstants.FieldName.VerticalCollectionMethodID)
            FieldOrdinal.VerticalCollectionMethodName = dr.GetOrdinal(VerticalCollectionMethodConstants.FieldName.VerticalCollectionMethodName)
            FieldOrdinal.VerticalCollectionMethodDescription = dr.GetOrdinal(VerticalCollectionMethodConstants.FieldName.VerticalCollectionMethodDescription)

        End Sub

#End Region '----- Helper Methods -----

#Region "----- Lookup Methods -----"

        Friend Function GetAll() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetAll)

        End Function

        Friend Function GetLookupTable() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetLookupTable)

        End Function

        Friend Function GetByLookupName(ByVal strVerticalCollectionMethodName As String) As VerticalCollectionMethod

            Dim objVerticalCollectionMethod As VerticalCollectionMethod = Nothing
            Dim cnGeography As OleDbConnection
            Dim drVerticalCollectionMethod As OleDbDataReader
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmstrVerticalCollectionMethodName As OleDbParameter = New OleDbParameter

            With prmstrVerticalCollectionMethodName
                .ParameterName = ParameterName.VerticalCollectionMethodName
                .Direction = ParameterDirection.Input
                .Value = strVerticalCollectionMethodName
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmstrVerticalCollectionMethodName

            cnGeography = New OleDbConnection(GlobalVariables.ConnectionString)
            cnGeography.Open()
            drVerticalCollectionMethod = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByLookupName, commandParameters)
            If (drVerticalCollectionMethod.HasRows) Then
                objVerticalCollectionMethod = New VerticalCollectionMethod
                Call SetFieldOrdinalValues(drVerticalCollectionMethod)
                drVerticalCollectionMethod.Read()
                With objVerticalCollectionMethod
                    If (Not IsDBNull(drVerticalCollectionMethod(FieldOrdinal.VerticalCollectionMethodID))) Then
                        .VerticalCollectionMethodID = drVerticalCollectionMethod(FieldOrdinal.VerticalCollectionMethodID)
                    End If
                    If (Not IsDBNull(drVerticalCollectionMethod(FieldOrdinal.VerticalCollectionMethodName))) Then
                        .VerticalCollectionMethodName = drVerticalCollectionMethod(FieldOrdinal.VerticalCollectionMethodName)
                    End If
                    If (Not IsDBNull(drVerticalCollectionMethod(FieldOrdinal.VerticalCollectionMethodDescription))) Then
                        .VerticalCollectionMethodDescription = drVerticalCollectionMethod(FieldOrdinal.VerticalCollectionMethodDescription)
                    End If
                End With
            End If
            drVerticalCollectionMethod.Close()
            cnGeography.Close()

            Return objVerticalCollectionMethod

        End Function

        Friend Function GetByPrimaryKey(ByVal intVerticalCollectionMethodID As Int32) As VerticalCollectionMethod

            Dim objVerticalCollectionMethod As VerticalCollectionMethod = Nothing
            Dim cnGeography As OleDbConnection
            Dim drVerticalCollectionMethod As OleDbDataReader
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmintVerticalCollectionMethodID As OleDbParameter = New OleDbParameter

            With prmintVerticalCollectionMethodID
                .ParameterName = ParameterName.VerticalCollectionMethodID
                .Direction = ParameterDirection.Input
                .Value = intVerticalCollectionMethodID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintVerticalCollectionMethodID

            cnGeography = New OleDbConnection(GlobalVariables.ConnectionString)
            cnGeography.Open()
            drVerticalCollectionMethod = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByPrimaryKey, commandParameters)
            If (drVerticalCollectionMethod.HasRows) Then
                objVerticalCollectionMethod = New VerticalCollectionMethod
                Call SetFieldOrdinalValues(drVerticalCollectionMethod)
                drVerticalCollectionMethod.Read()
                With objVerticalCollectionMethod
                    If (Not IsDBNull(drVerticalCollectionMethod(FieldOrdinal.VerticalCollectionMethodID))) Then
                        .VerticalCollectionMethodID = drVerticalCollectionMethod(FieldOrdinal.VerticalCollectionMethodID)
                    End If
                    If (Not IsDBNull(drVerticalCollectionMethod(FieldOrdinal.VerticalCollectionMethodName))) Then
                        .VerticalCollectionMethodName = drVerticalCollectionMethod(FieldOrdinal.VerticalCollectionMethodName)
                    End If
                    If (Not IsDBNull(drVerticalCollectionMethod(FieldOrdinal.VerticalCollectionMethodDescription))) Then
                        .VerticalCollectionMethodDescription = drVerticalCollectionMethod(FieldOrdinal.VerticalCollectionMethodDescription)
                    End If
                End With
            End If
            drVerticalCollectionMethod.Close()
            cnGeography.Close()

            Return objVerticalCollectionMethod

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
