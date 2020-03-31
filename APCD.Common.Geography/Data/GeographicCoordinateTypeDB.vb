'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: GeographicCoordinateTypeDB.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Data access class for the GeographicCoordinateType table of the Geography database.
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

    <Serializable()> Friend Class GeographicCoordinateTypeDB

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        'field ordinal positions (for use with datareader object)
        Private Structure FieldOrdinal
            Private _trash As String
            Public Shared GeographicCoordinateTypeID As Int32 'primary key
            Public Shared GeographicCoordinateTypeName As Int32
            Public Shared Comment As Int32
        End Structure

        Private Structure StoredProcedure
            Private _trash As String
            Public Const Insert As String = "GeographicCoordinateType_Insert"
            Public Const Update As String = "GeographicCoordinateType_Update"
            Public Const Delete As String = "GeographicCoordinateType_Delete"
            Public Const GetByPrimaryKey As String = "GeographicCoordinateType_GetByPrimaryKey"
            Public Const GetAll As String = "GeographicCoordinateType_GetAll"
            Public Const GetLookupTable As String = "GeographicCoordinateType_GetLookupTable"
            Public Const GetByLookupName As String = "GeographicCoordinateType_GetByLookupName"
        End Structure

        'enums
        Private Enum DMLType As Integer
            Insert
            Update
            Delete
        End Enum

        'sqlClient parameters
        Private m_prmintGeographicCoordinateTypeID As OleDbParameter 'primary key
        Private m_prmstrGeographicCoordinateTypeName As OleDbParameter
        Private m_prmstrComment As OleDbParameter

        Private Structure ParameterName
            Private _trash As String
            Public Const GeographicCoordinateTypeID As String = "@GeographicCoordinateTypeID"
            Public Const GeographicCoordinateTypeName As String = "@GeographicCoordinateTypeName"
            Public Const Comment As String = "@Comment"
        End Structure

#End Region '----- Member Variables -----

#Region "----- DML -----"

        Friend Function Insert(ByVal objGeographicCoordinateType As GeographicCoordinateType, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objGeographicCoordinateType, DMLType.Insert, cmd)

        End Function

        Friend Function Update(ByVal objGeographicCoordinateType As GeographicCoordinateType, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objGeographicCoordinateType, DMLType.Update, cmd)

        End Function

        Friend Function Delete(ByVal objGeographicCoordinateType As GeographicCoordinateType, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objGeographicCoordinateType, DMLType.Delete, cmd)

        End Function

        Private Function DMLHelper(ByVal objGeographicCoordinateType As GeographicCoordinateType, ByVal iDMLType As DMLType, ByVal cmd As OleDbCommand) As Int32

            Dim intReturnValue As Int32
            Dim commandParameters() As OleDbParameter = Nothing

            With Me
                Call .InitializeParameterObjects()
                Call .AssignParameterValues(objGeographicCoordinateType, iDMLType)
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

            Me.m_prmintGeographicCoordinateTypeID = Nothing
            Me.m_prmintGeographicCoordinateTypeID = New OleDbParameter

            Me.m_prmstrGeographicCoordinateTypeName = Nothing
            Me.m_prmstrGeographicCoordinateTypeName = New OleDbParameter

            Me.m_prmstrComment = Nothing
            Me.m_prmstrComment = New OleDbParameter

        End Sub

        Private Sub AssignParameterValues(ByVal objGeographicCoordinateType As GeographicCoordinateType, ByVal DMLOperation As DMLType)

            With Me
                Select Case DMLOperation

                    Case DMLType.Insert

                        With .m_prmintGeographicCoordinateTypeID
                            .ParameterName = ParameterName.GeographicCoordinateTypeID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objGeographicCoordinateType.GeographicCoordinateTypeID
                        End With

                        With .m_prmstrGeographicCoordinateTypeName
                            .ParameterName = ParameterName.GeographicCoordinateTypeName
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objGeographicCoordinateType.GeographicCoordinateTypeName
                        End With

                        With .m_prmstrComment
                            .ParameterName = ParameterName.Comment
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objGeographicCoordinateType.Comment
                        End With

                    Case DMLType.Update

                        With .m_prmintGeographicCoordinateTypeID
                            .ParameterName = "@GeographicCoordinateTypeID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objGeographicCoordinateType.GeographicCoordinateTypeID
                        End With

                        With .m_prmstrGeographicCoordinateTypeName
                            .ParameterName = "@GeographicCoordinateTypeName"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objGeographicCoordinateType.GeographicCoordinateTypeName
                        End With

                        With .m_prmstrComment
                            .ParameterName = "@Comment"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objGeographicCoordinateType.Comment
                        End With

                    Case DMLType.Delete

                        With .m_prmintGeographicCoordinateTypeID
                            .ParameterName = "@GeographicCoordinateTypeID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objGeographicCoordinateType.GeographicCoordinateTypeID
                        End With

                End Select 'DMLOperation

            End With 'Me

        End Sub

        Private Function GetParameterArray(ByVal DMLOperation As DMLType) As OleDbParameter()

            Dim commandParameters() As OleDbParameter = Nothing

            Select Case DMLOperation
                Case DMLType.Insert
                    commandParameters = New OleDbParameter(2) {}
                    commandParameters(0) = Me.m_prmintGeographicCoordinateTypeID
                    commandParameters(1) = Me.m_prmstrGeographicCoordinateTypeName
                    commandParameters(2) = Me.m_prmstrComment
                Case DMLType.Update
                    commandParameters = New OleDbParameter(2) {}
                    commandParameters(0) = Me.m_prmintGeographicCoordinateTypeID
                    commandParameters(1) = Me.m_prmstrGeographicCoordinateTypeName
                    commandParameters(2) = Me.m_prmstrComment
                Case DMLType.Delete
                    commandParameters = New OleDbParameter(0) {}
                    commandParameters(0) = Me.m_prmintGeographicCoordinateTypeID
            End Select
            Return commandParameters

        End Function

        Private Sub SetFieldOrdinalValues(ByVal dr As OleDbDataReader)

            FieldOrdinal.GeographicCoordinateTypeID = dr.GetOrdinal(GeographicCoordinateTypeConstants.FieldName.GeographicCoordinateTypeID)
            FieldOrdinal.GeographicCoordinateTypeName = dr.GetOrdinal(GeographicCoordinateTypeConstants.FieldName.GeographicCoordinateTypeName)
            FieldOrdinal.Comment = dr.GetOrdinal(GeographicCoordinateTypeConstants.FieldName.Comment)

        End Sub

#End Region '----- Helper Methods -----

#Region "----- Lookup Methods -----"

        Friend Function GetAll() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetAll)

        End Function

        Friend Function GetLookupTable() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetLookupTable)

        End Function

        Friend Function GetByLookupName(ByVal strGeographicCoordinateTypeName As String) As GeographicCoordinateType

            Dim objGeographicCoordinateType As GeographicCoordinateType = Nothing
            Dim cnGeography As OleDbConnection
            Dim drGeographicCoordinateType As OleDbDataReader
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmstrGeographicCoordinateTypeName As OleDbParameter = New OleDbParameter

            With prmstrGeographicCoordinateTypeName
                .ParameterName = ParameterName.GeographicCoordinateTypeName
                .Direction = ParameterDirection.Input
                .Value = strGeographicCoordinateTypeName
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmstrGeographicCoordinateTypeName

            cnGeography = New OleDbConnection(GlobalVariables.ConnectionString)
            cnGeography.Open()
            drGeographicCoordinateType = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByLookupName, commandParameters)
            If (drGeographicCoordinateType.HasRows) Then
                objGeographicCoordinateType = New GeographicCoordinateType
                Call SetFieldOrdinalValues(drGeographicCoordinateType)
                drGeographicCoordinateType.Read()
                With objGeographicCoordinateType
                    If (Not IsDBNull(drGeographicCoordinateType(FieldOrdinal.GeographicCoordinateTypeID))) Then
                        .GeographicCoordinateTypeID = drGeographicCoordinateType(FieldOrdinal.GeographicCoordinateTypeID)
                    End If
                    If (Not IsDBNull(drGeographicCoordinateType(FieldOrdinal.GeographicCoordinateTypeName))) Then
                        .GeographicCoordinateTypeName = drGeographicCoordinateType(FieldOrdinal.GeographicCoordinateTypeName)
                    End If
                    If (Not IsDBNull(drGeographicCoordinateType(FieldOrdinal.Comment))) Then
                        .Comment = drGeographicCoordinateType(FieldOrdinal.Comment)
                    End If
                End With
            End If
            drGeographicCoordinateType.Close()
            cnGeography.Close()

            Return objGeographicCoordinateType

        End Function

        Friend Function GetByPrimaryKey(ByVal intGeographicCoordinateTypeID As Int32) As GeographicCoordinateType

            Dim objGeographicCoordinateType As GeographicCoordinateType = Nothing
            Dim cnGeography As OleDbConnection
            Dim drGeographicCoordinateType As OleDbDataReader
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmintGeographicCoordinateTypeID As OleDbParameter = New OleDbParameter

            With prmintGeographicCoordinateTypeID
                .ParameterName = ParameterName.GeographicCoordinateTypeID
                .Direction = ParameterDirection.Input
                .Value = intGeographicCoordinateTypeID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintGeographicCoordinateTypeID

            cnGeography = New OleDbConnection(GlobalVariables.ConnectionString)
            cnGeography.Open()
            drGeographicCoordinateType = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByPrimaryKey, commandParameters)
            If (drGeographicCoordinateType.HasRows) Then
                objGeographicCoordinateType = New GeographicCoordinateType
                Call SetFieldOrdinalValues(drGeographicCoordinateType)
                drGeographicCoordinateType.Read()
                With objGeographicCoordinateType
                    If (Not IsDBNull(drGeographicCoordinateType(FieldOrdinal.GeographicCoordinateTypeID))) Then
                        .GeographicCoordinateTypeID = drGeographicCoordinateType(FieldOrdinal.GeographicCoordinateTypeID)
                    End If
                    If (Not IsDBNull(drGeographicCoordinateType(FieldOrdinal.GeographicCoordinateTypeName))) Then
                        .GeographicCoordinateTypeName = drGeographicCoordinateType(FieldOrdinal.GeographicCoordinateTypeName)
                    End If
                    If (Not IsDBNull(drGeographicCoordinateType(FieldOrdinal.Comment))) Then
                        .Comment = drGeographicCoordinateType(FieldOrdinal.Comment)
                    End If
                End With
            End If
            drGeographicCoordinateType.Close()
            cnGeography.Close()

            Return objGeographicCoordinateType

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
