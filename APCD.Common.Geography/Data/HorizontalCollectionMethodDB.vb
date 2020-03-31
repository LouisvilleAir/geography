'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: HorizontalCollectionMethodDB.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Data access class for the HorizontalCollectionMethod table of the Geography database.
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

    <Serializable()> Friend Class HorizontalCollectionMethodDB

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        'field ordinal positions (for use with datareader object)
        Private Structure FieldOrdinal
            Private _trash As String
            Public Shared HorizontalCollectionMethodID As Int32 'primary key
            Public Shared HorizontalCollectionMethodName As Int32
            Public Shared MethodEPACode As Int32
            Public Shared Description As Int32
        End Structure

        Private Structure StoredProcedure
            Private _trash As String
            Public Const Insert As String = "HorizontalCollectionMethod_Insert"
            Public Const Update As String = "HorizontalCollectionMethod_Update"
            Public Const Delete As String = "HorizontalCollectionMethod_Delete"
            Public Const GetByPrimaryKey As String = "HorizontalCollectionMethod_GetByPrimaryKey"
            Public Const GetAll As String = "HorizontalCollectionMethod_GetAll"
            Public Const GetLookupTable As String = "HorizontalCollectionMethod_GetLookupTable"
            Public Const GetByLookupName As String = "HorizontalCollectionMethod_GetByLookupName"
        End Structure

        'enums
        Private Enum DMLType As Integer
            Insert
            Update
            Delete
        End Enum

        'sqlClient parameters
        Private m_prmintHorizontalCollectionMethodID As OleDbParameter 'primary key
        Private m_prmstrHorizontalCollectionMethodName As OleDbParameter
        Private m_prmstrMethodEPACode As OleDbParameter
        Private m_prmstrDescription As OleDbParameter

        Private Structure ParameterName
            Private _trash As String
            Public Const HorizontalCollectionMethodID As String = "@HorizontalCollectionMethodID"
            Public Const HorizontalCollectionMethodName As String = "@HorizontalCollectionMethodName"
            Public Const MethodEPACode As String = "@MethodEPACode"
            Public Const Description As String = "@Description"
        End Structure

#End Region '----- Member Variables -----

#Region "----- DML -----"

        Friend Function Insert(ByVal objHorizontalCollectionMethod As HorizontalCollectionMethod, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objHorizontalCollectionMethod, DMLType.Insert, cmd)

        End Function

        Friend Function Update(ByVal objHorizontalCollectionMethod As HorizontalCollectionMethod, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objHorizontalCollectionMethod, DMLType.Update, cmd)

        End Function

        Friend Function Delete(ByVal objHorizontalCollectionMethod As HorizontalCollectionMethod, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objHorizontalCollectionMethod, DMLType.Delete, cmd)

        End Function

        Private Function DMLHelper(ByVal objHorizontalCollectionMethod As HorizontalCollectionMethod, ByVal iDMLType As DMLType, ByVal cmd As OleDbCommand) As Int32

            Dim intReturnValue As Int32
            Dim commandParameters() As OleDbParameter = Nothing

            With Me
                Call .InitializeParameterObjects()
                Call .AssignParameterValues(objHorizontalCollectionMethod, iDMLType)
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

            Me.m_prmintHorizontalCollectionMethodID = Nothing
            Me.m_prmintHorizontalCollectionMethodID = New OleDbParameter

            Me.m_prmstrHorizontalCollectionMethodName = Nothing
            Me.m_prmstrHorizontalCollectionMethodName = New OleDbParameter

            Me.m_prmstrMethodEPACode = Nothing
            Me.m_prmstrMethodEPACode = New OleDbParameter

            Me.m_prmstrDescription = Nothing
            Me.m_prmstrDescription = New OleDbParameter

        End Sub

        Private Sub AssignParameterValues(ByVal objHorizontalCollectionMethod As HorizontalCollectionMethod, ByVal DMLOperation As DMLType)

            With Me
                Select Case DMLOperation

                    Case DMLType.Insert

                        With .m_prmintHorizontalCollectionMethodID
                            .ParameterName = ParameterName.HorizontalCollectionMethodID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objHorizontalCollectionMethod.HorizontalCollectionMethodID
                        End With

                        With .m_prmstrHorizontalCollectionMethodName
                            .ParameterName = ParameterName.HorizontalCollectionMethodName
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objHorizontalCollectionMethod.HorizontalCollectionMethodName
                        End With

                        With .m_prmstrMethodEPACode
                            .ParameterName = ParameterName.MethodEPACode
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objHorizontalCollectionMethod.MethodEPACode
                        End With

                        With .m_prmstrDescription
                            .ParameterName = ParameterName.Description
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objHorizontalCollectionMethod.Description
                        End With

                    Case DMLType.Update

                        With .m_prmintHorizontalCollectionMethodID
                            .ParameterName = "@HorizontalCollectionMethodID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objHorizontalCollectionMethod.HorizontalCollectionMethodID
                        End With

                        With .m_prmstrHorizontalCollectionMethodName
                            .ParameterName = "@HorizontalCollectionMethodName"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objHorizontalCollectionMethod.HorizontalCollectionMethodName
                        End With

                        With .m_prmstrMethodEPACode
                            .ParameterName = "@MethodEPACode"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objHorizontalCollectionMethod.MethodEPACode
                        End With

                        With .m_prmstrDescription
                            .ParameterName = "@Description"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objHorizontalCollectionMethod.Description
                        End With

                    Case DMLType.Delete

                        With .m_prmintHorizontalCollectionMethodID
                            .ParameterName = "@HorizontalCollectionMethodID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objHorizontalCollectionMethod.HorizontalCollectionMethodID
                        End With

                End Select 'DMLOperation

            End With 'Me

        End Sub

        Private Function GetParameterArray(ByVal DMLOperation As DMLType) As OleDbParameter()

            Dim commandParameters() As OleDbParameter = Nothing

            Select Case DMLOperation
                Case DMLType.Insert
                    commandParameters = New OleDbParameter(3) {}
                    commandParameters(0) = Me.m_prmintHorizontalCollectionMethodID
                    commandParameters(1) = Me.m_prmstrHorizontalCollectionMethodName
                    commandParameters(2) = Me.m_prmstrMethodEPACode
                    commandParameters(3) = Me.m_prmstrDescription
                Case DMLType.Update
                    commandParameters = New OleDbParameter(3) {}
                    commandParameters(0) = Me.m_prmintHorizontalCollectionMethodID
                    commandParameters(1) = Me.m_prmstrHorizontalCollectionMethodName
                    commandParameters(2) = Me.m_prmstrMethodEPACode
                    commandParameters(3) = Me.m_prmstrDescription
                Case DMLType.Delete
                    commandParameters = New OleDbParameter(0) {}
                    commandParameters(0) = Me.m_prmintHorizontalCollectionMethodID
            End Select
            Return commandParameters

        End Function

        Private Sub SetFieldOrdinalValues(ByVal dr As OleDbDataReader)

            FieldOrdinal.HorizontalCollectionMethodID = dr.GetOrdinal(HorizontalCollectionMethodConstants.FieldName.HorizontalCollectionMethodID)
            FieldOrdinal.HorizontalCollectionMethodName = dr.GetOrdinal(HorizontalCollectionMethodConstants.FieldName.HorizontalCollectionMethodName)
            FieldOrdinal.MethodEPACode = dr.GetOrdinal(HorizontalCollectionMethodConstants.FieldName.MethodEPACode)
            FieldOrdinal.Description = dr.GetOrdinal(HorizontalCollectionMethodConstants.FieldName.Description)

        End Sub

#End Region '----- Helper Methods -----

#Region "----- Lookup Methods -----"

        Friend Function GetAll() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetAll)

        End Function

        Friend Function GetLookupTable() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetLookupTable)

        End Function

        Friend Function GetByLookupName(ByVal strHorizontalCollectionMethodName As String) As HorizontalCollectionMethod

            Dim objHorizontalCollectionMethod As HorizontalCollectionMethod = Nothing
            Dim cnGeography As OleDbConnection
            Dim drHorizontalCollectionMethod As OleDbDataReader
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmstrHorizontalCollectionMethodName As OleDbParameter = New OleDbParameter

            With prmstrHorizontalCollectionMethodName
                .ParameterName = ParameterName.HorizontalCollectionMethodName
                .Direction = ParameterDirection.Input
                .Value = strHorizontalCollectionMethodName
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmstrHorizontalCollectionMethodName

            cnGeography = New OleDbConnection(GlobalVariables.ConnectionString)
            cnGeography.Open()
            drHorizontalCollectionMethod = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByLookupName, commandParameters)
            If (drHorizontalCollectionMethod.HasRows) Then
                objHorizontalCollectionMethod = New HorizontalCollectionMethod
                Call SetFieldOrdinalValues(drHorizontalCollectionMethod)
                drHorizontalCollectionMethod.Read()
                With objHorizontalCollectionMethod
                    If (Not IsDBNull(drHorizontalCollectionMethod(FieldOrdinal.HorizontalCollectionMethodID))) Then
                        .HorizontalCollectionMethodID = drHorizontalCollectionMethod(FieldOrdinal.HorizontalCollectionMethodID)
                    End If
                    If (Not IsDBNull(drHorizontalCollectionMethod(FieldOrdinal.HorizontalCollectionMethodName))) Then
                        .HorizontalCollectionMethodName = drHorizontalCollectionMethod(FieldOrdinal.HorizontalCollectionMethodName)
                    End If
                    If (Not IsDBNull(drHorizontalCollectionMethod(FieldOrdinal.MethodEPACode))) Then
                        .MethodEPACode = drHorizontalCollectionMethod(FieldOrdinal.MethodEPACode)
                    End If
                    If (Not IsDBNull(drHorizontalCollectionMethod(FieldOrdinal.Description))) Then
                        .Description = drHorizontalCollectionMethod(FieldOrdinal.Description)
                    End If
                End With
            End If
            drHorizontalCollectionMethod.Close()
            cnGeography.Close()

            Return objHorizontalCollectionMethod

        End Function

        Friend Function GetByPrimaryKey(ByVal intHorizontalCollectionMethodID As Int32) As HorizontalCollectionMethod

            Dim objHorizontalCollectionMethod As HorizontalCollectionMethod = Nothing
            Dim cnGeography As OleDbConnection
            Dim drHorizontalCollectionMethod As OleDbDataReader
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmintHorizontalCollectionMethodID As OleDbParameter = New OleDbParameter

            With prmintHorizontalCollectionMethodID
                .ParameterName = ParameterName.HorizontalCollectionMethodID
                .Direction = ParameterDirection.Input
                .Value = intHorizontalCollectionMethodID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintHorizontalCollectionMethodID

            cnGeography = New OleDbConnection(GlobalVariables.ConnectionString)
            cnGeography.Open()
            drHorizontalCollectionMethod = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByPrimaryKey, commandParameters)
            If (drHorizontalCollectionMethod.HasRows) Then
                objHorizontalCollectionMethod = New HorizontalCollectionMethod
                Call SetFieldOrdinalValues(drHorizontalCollectionMethod)
                drHorizontalCollectionMethod.Read()
                With objHorizontalCollectionMethod
                    If (Not IsDBNull(drHorizontalCollectionMethod(FieldOrdinal.HorizontalCollectionMethodID))) Then
                        .HorizontalCollectionMethodID = drHorizontalCollectionMethod(FieldOrdinal.HorizontalCollectionMethodID)
                    End If
                    If (Not IsDBNull(drHorizontalCollectionMethod(FieldOrdinal.HorizontalCollectionMethodName))) Then
                        .HorizontalCollectionMethodName = drHorizontalCollectionMethod(FieldOrdinal.HorizontalCollectionMethodName)
                    End If
                    If (Not IsDBNull(drHorizontalCollectionMethod(FieldOrdinal.MethodEPACode))) Then
                        .MethodEPACode = drHorizontalCollectionMethod(FieldOrdinal.MethodEPACode)
                    End If
                    If (Not IsDBNull(drHorizontalCollectionMethod(FieldOrdinal.Description))) Then
                        .Description = drHorizontalCollectionMethod(FieldOrdinal.Description)
                    End If
                End With
            End If
            drHorizontalCollectionMethod.Close()
            cnGeography.Close()

            Return objHorizontalCollectionMethod

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
