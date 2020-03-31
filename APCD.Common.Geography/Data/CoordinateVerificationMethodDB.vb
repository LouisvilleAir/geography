'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: CoordinateVerificationMethodDB.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Data access class for the CoordinateVerificationMethod table of the Geography database.
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

    <Serializable()> Friend Class CoordinateVerificationMethodDB

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        'field ordinal positions (for use with datareader object)
        Private Structure FieldOrdinal
            Private _trash As String
            Public Shared CoordinateVerificationMethodID As Int32 'primary key
            Public Shared CoordinateVerificationMethodName As Int32
            Public Shared CoordinateVerificationMethodDescription As Int32
        End Structure

        Private Structure StoredProcedure
            Private _trash As String
            Public Const Insert As String = "CoordinateVerificationMethod_Insert"
            Public Const Update As String = "CoordinateVerificationMethod_Update"
            Public Const Delete As String = "CoordinateVerificationMethod_Delete"
            Public Const GetByPrimaryKey As String = "CoordinateVerificationMethod_GetByPrimaryKey"
            Public Const GetAll As String = "CoordinateVerificationMethod_GetAll"
            Public Const GetLookupTable As String = "CoordinateVerificationMethod_GetLookupTable"
            Public Const GetByLookupName As String = "CoordinateVerificationMethod_GetByLookupName"
        End Structure

        'enums
        Private Enum DMLType As Integer
            Insert
            Update
            Delete
        End Enum

        'sqlClient parameters
        Private m_prmintCoordinateVerificationMethodID As OleDbParameter 'primary key
        Private m_prmstrCoordinateVerificationMethodName As OleDbParameter
        Private m_prmstrCoordinateVerificationMethodDescription As OleDbParameter

        Private Structure ParameterName
            Private _trash As String
            Public Const CoordinateVerificationMethodID As String = "@CoordinateVerificationMethodID"
            Public Const CoordinateVerificationMethodName As String = "@CoordinateVerificationMethodName"
            Public Const CoordinateVerificationMethodDescription As String = "@CoordinateVerificationMethodDescription"
        End Structure

#End Region '----- Member Variables -----

#Region "----- DML -----"

        Friend Function Insert(ByVal objCoordinateVerificationMethod As CoordinateVerificationMethod, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objCoordinateVerificationMethod, DMLType.Insert, cmd)

        End Function

        Friend Function Update(ByVal objCoordinateVerificationMethod As CoordinateVerificationMethod, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objCoordinateVerificationMethod, DMLType.Update, cmd)

        End Function

        Friend Function Delete(ByVal objCoordinateVerificationMethod As CoordinateVerificationMethod, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objCoordinateVerificationMethod, DMLType.Delete, cmd)

        End Function

        Private Function DMLHelper(ByVal objCoordinateVerificationMethod As CoordinateVerificationMethod, ByVal iDMLType As DMLType, ByVal cmd As OleDbCommand) As Int32

            Dim intReturnValue As Int32
            Dim commandParameters() As OleDbParameter = Nothing

            With Me
                Call .InitializeParameterObjects()
                Call .AssignParameterValues(objCoordinateVerificationMethod, iDMLType)
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

            Me.m_prmintCoordinateVerificationMethodID = Nothing
            Me.m_prmintCoordinateVerificationMethodID = New OleDbParameter

            Me.m_prmstrCoordinateVerificationMethodName = Nothing
            Me.m_prmstrCoordinateVerificationMethodName = New OleDbParameter

            Me.m_prmstrCoordinateVerificationMethodDescription = Nothing
            Me.m_prmstrCoordinateVerificationMethodDescription = New OleDbParameter

        End Sub

        Private Sub AssignParameterValues(ByVal objCoordinateVerificationMethod As CoordinateVerificationMethod, ByVal DMLOperation As DMLType)

            With Me
                Select Case DMLOperation

                    Case DMLType.Insert

                        With .m_prmintCoordinateVerificationMethodID
                            .ParameterName = ParameterName.CoordinateVerificationMethodID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objCoordinateVerificationMethod.CoordinateVerificationMethodID
                        End With

                        With .m_prmstrCoordinateVerificationMethodName
                            .ParameterName = ParameterName.CoordinateVerificationMethodName
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objCoordinateVerificationMethod.CoordinateVerificationMethodName
                        End With

                        With .m_prmstrCoordinateVerificationMethodDescription
                            .ParameterName = ParameterName.CoordinateVerificationMethodDescription
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objCoordinateVerificationMethod.CoordinateVerificationMethodDescription
                        End With

                    Case DMLType.Update

                        With .m_prmintCoordinateVerificationMethodID
                            .ParameterName = "@CoordinateVerificationMethodID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objCoordinateVerificationMethod.CoordinateVerificationMethodID
                        End With

                        With .m_prmstrCoordinateVerificationMethodName
                            .ParameterName = "@CoordinateVerificationMethodName"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objCoordinateVerificationMethod.CoordinateVerificationMethodName
                        End With

                        With .m_prmstrCoordinateVerificationMethodDescription
                            .ParameterName = "@CoordinateVerificationMethodDescription"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objCoordinateVerificationMethod.CoordinateVerificationMethodDescription
                        End With

                    Case DMLType.Delete

                        With .m_prmintCoordinateVerificationMethodID
                            .ParameterName = "@CoordinateVerificationMethodID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objCoordinateVerificationMethod.CoordinateVerificationMethodID
                        End With

                End Select 'DMLOperation

            End With 'Me

        End Sub

        Private Function GetParameterArray(ByVal DMLOperation As DMLType) As OleDbParameter()

            Dim commandParameters() As OleDbParameter = Nothing

            Select Case DMLOperation
                Case DMLType.Insert
                    commandParameters = New OleDbParameter(2) {}
                    commandParameters(0) = Me.m_prmintCoordinateVerificationMethodID
                    commandParameters(1) = Me.m_prmstrCoordinateVerificationMethodName
                    commandParameters(2) = Me.m_prmstrCoordinateVerificationMethodDescription
                Case DMLType.Update
                    commandParameters = New OleDbParameter(2) {}
                    commandParameters(0) = Me.m_prmintCoordinateVerificationMethodID
                    commandParameters(1) = Me.m_prmstrCoordinateVerificationMethodName
                    commandParameters(2) = Me.m_prmstrCoordinateVerificationMethodDescription
                Case DMLType.Delete
                    commandParameters = New OleDbParameter(0) {}
                    commandParameters(0) = Me.m_prmintCoordinateVerificationMethodID
            End Select
            Return commandParameters

        End Function

        Private Sub SetFieldOrdinalValues(ByVal dr As OleDbDataReader)

            FieldOrdinal.CoordinateVerificationMethodID = dr.GetOrdinal(CoordinateVerificationMethodConstants.FieldName.CoordinateVerificationMethodID)
            FieldOrdinal.CoordinateVerificationMethodName = dr.GetOrdinal(CoordinateVerificationMethodConstants.FieldName.CoordinateVerificationMethodName)
            FieldOrdinal.CoordinateVerificationMethodDescription = dr.GetOrdinal(CoordinateVerificationMethodConstants.FieldName.CoordinateVerificationMethodDescription)

        End Sub

#End Region '----- Helper Methods -----

#Region "----- Lookup Methods -----"

        Friend Function GetAll() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetAll)

        End Function

        Friend Function GetLookupTable() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetLookupTable)

        End Function

        Friend Function GetByLookupName(ByVal strCoordinateVerificationMethodName As String) As CoordinateVerificationMethod

            Dim objCoordinateVerificationMethod As CoordinateVerificationMethod = Nothing
            Dim cnGeography As OleDbConnection
            Dim drCoordinateVerificationMethod As OleDbDataReader
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmstrCoordinateVerificationMethodName As OleDbParameter = New OleDbParameter

            With prmstrCoordinateVerificationMethodName
                .ParameterName = ParameterName.CoordinateVerificationMethodName
                .Direction = ParameterDirection.Input
                .Value = strCoordinateVerificationMethodName
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmstrCoordinateVerificationMethodName

            cnGeography = New OleDbConnection(GlobalVariables.ConnectionString)
            cnGeography.Open()
            drCoordinateVerificationMethod = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByLookupName, commandParameters)
            If (drCoordinateVerificationMethod.HasRows) Then
                objCoordinateVerificationMethod = New CoordinateVerificationMethod
                Call SetFieldOrdinalValues(drCoordinateVerificationMethod)
                drCoordinateVerificationMethod.Read()
                With objCoordinateVerificationMethod
                    If (Not IsDBNull(drCoordinateVerificationMethod(FieldOrdinal.CoordinateVerificationMethodID))) Then
                        .CoordinateVerificationMethodID = drCoordinateVerificationMethod(FieldOrdinal.CoordinateVerificationMethodID)
                    End If
                    If (Not IsDBNull(drCoordinateVerificationMethod(FieldOrdinal.CoordinateVerificationMethodName))) Then
                        .CoordinateVerificationMethodName = drCoordinateVerificationMethod(FieldOrdinal.CoordinateVerificationMethodName)
                    End If
                    If (Not IsDBNull(drCoordinateVerificationMethod(FieldOrdinal.CoordinateVerificationMethodDescription))) Then
                        .CoordinateVerificationMethodDescription = drCoordinateVerificationMethod(FieldOrdinal.CoordinateVerificationMethodDescription)
                    End If
                End With
            End If
            drCoordinateVerificationMethod.Close()
            cnGeography.Close()

            Return objCoordinateVerificationMethod

        End Function

        Friend Function GetByPrimaryKey(ByVal intCoordinateVerificationMethodID As Int32) As CoordinateVerificationMethod

            Dim objCoordinateVerificationMethod As CoordinateVerificationMethod = Nothing
            Dim cnGeography As OleDbConnection
            Dim drCoordinateVerificationMethod As OleDbDataReader
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmintCoordinateVerificationMethodID As OleDbParameter = New OleDbParameter

            With prmintCoordinateVerificationMethodID
                .ParameterName = ParameterName.CoordinateVerificationMethodID
                .Direction = ParameterDirection.Input
                .Value = intCoordinateVerificationMethodID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintCoordinateVerificationMethodID

            cnGeography = New OleDbConnection(GlobalVariables.ConnectionString)
            cnGeography.Open()
            drCoordinateVerificationMethod = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByPrimaryKey, commandParameters)
            If (drCoordinateVerificationMethod.HasRows) Then
                objCoordinateVerificationMethod = New CoordinateVerificationMethod
                Call SetFieldOrdinalValues(drCoordinateVerificationMethod)
                drCoordinateVerificationMethod.Read()
                With objCoordinateVerificationMethod
                    If (Not IsDBNull(drCoordinateVerificationMethod(FieldOrdinal.CoordinateVerificationMethodID))) Then
                        .CoordinateVerificationMethodID = drCoordinateVerificationMethod(FieldOrdinal.CoordinateVerificationMethodID)
                    End If
                    If (Not IsDBNull(drCoordinateVerificationMethod(FieldOrdinal.CoordinateVerificationMethodName))) Then
                        .CoordinateVerificationMethodName = drCoordinateVerificationMethod(FieldOrdinal.CoordinateVerificationMethodName)
                    End If
                    If (Not IsDBNull(drCoordinateVerificationMethod(FieldOrdinal.CoordinateVerificationMethodDescription))) Then
                        .CoordinateVerificationMethodDescription = drCoordinateVerificationMethod(FieldOrdinal.CoordinateVerificationMethodDescription)
                    End If
                End With
            End If
            drCoordinateVerificationMethod.Close()
            cnGeography.Close()

            Return objCoordinateVerificationMethod

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
