'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: VerticalReferenceDatumDB.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Data access class for the VerticalReferenceDatum table of the Geography database.
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

    <Serializable()> Friend Class VerticalReferenceDatumDB

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        'field ordinal positions (for use with datareader object)
        Private Structure FieldOrdinal
            Private _trash As String
            Public Shared VerticalReferenceDatumID As Int32 'primary key
            Public Shared VerticalReferenceDatumName As Int32
            Public Shared DatumAbbreviation As Int32
        End Structure

        Private Structure StoredProcedure
            Private _trash As String
            Public Const Insert As String = "VerticalReferenceDatum_Insert"
            Public Const Update As String = "VerticalReferenceDatum_Update"
            Public Const Delete As String = "VerticalReferenceDatum_Delete"
            Public Const GetByPrimaryKey As String = "VerticalReferenceDatum_GetByPrimaryKey"
            Public Const GetAll As String = "VerticalReferenceDatum_GetAll"
            Public Const GetLookupTable As String = "VerticalReferenceDatum_GetLookupTable"
            Public Const GetByLookupName As String = "VerticalReferenceDatum_GetByLookupName"
        End Structure

        'enums
        Private Enum DMLType As Integer
            Insert
            Update
            Delete
        End Enum

        'sqlClient parameters
        Private m_prmintVerticalReferenceDatumID As OleDbParameter 'primary key
        Private m_prmstrVerticalReferenceDatumName As OleDbParameter
        Private m_prmstrDatumAbbreviation As OleDbParameter

        Private Structure ParameterName
            Private _trash As String
            Public Const VerticalReferenceDatumID As String = "@VerticalReferenceDatumID"
            Public Const VerticalReferenceDatumName As String = "@VerticalReferenceDatumName"
            Public Const DatumAbbreviation As String = "@DatumAbbreviation"
        End Structure

#End Region '----- Member Variables -----

#Region "----- DML -----"

        Friend Function Insert(ByVal objVerticalReferenceDatum As VerticalReferenceDatum, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objVerticalReferenceDatum, DMLType.Insert, cmd)

        End Function

        Friend Function Update(ByVal objVerticalReferenceDatum As VerticalReferenceDatum, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objVerticalReferenceDatum, DMLType.Update, cmd)

        End Function

        Friend Function Delete(ByVal objVerticalReferenceDatum As VerticalReferenceDatum, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objVerticalReferenceDatum, DMLType.Delete, cmd)

        End Function

        Private Function DMLHelper(ByVal objVerticalReferenceDatum As VerticalReferenceDatum, ByVal iDMLType As DMLType, ByVal cmd As OleDbCommand) As Int32

            Dim intReturnValue As Int32
            Dim commandParameters() As OleDbParameter = Nothing

            With Me
                Call .InitializeParameterObjects()
                Call .AssignParameterValues(objVerticalReferenceDatum, iDMLType)
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

            Me.m_prmintVerticalReferenceDatumID = Nothing
            Me.m_prmintVerticalReferenceDatumID = New OleDbParameter

            Me.m_prmstrVerticalReferenceDatumName = Nothing
            Me.m_prmstrVerticalReferenceDatumName = New OleDbParameter

            Me.m_prmstrDatumAbbreviation = Nothing
            Me.m_prmstrDatumAbbreviation = New OleDbParameter

        End Sub

        Private Sub AssignParameterValues(ByVal objVerticalReferenceDatum As VerticalReferenceDatum, ByVal DMLOperation As DMLType)

            With Me
                Select Case DMLOperation

                    Case DMLType.Insert

                        With .m_prmintVerticalReferenceDatumID
                            .ParameterName = ParameterName.VerticalReferenceDatumID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objVerticalReferenceDatum.VerticalReferenceDatumID
                        End With

                        With .m_prmstrVerticalReferenceDatumName
                            .ParameterName = ParameterName.VerticalReferenceDatumName
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objVerticalReferenceDatum.VerticalReferenceDatumName
                        End With

                        With .m_prmstrDatumAbbreviation
                            .ParameterName = ParameterName.DatumAbbreviation
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objVerticalReferenceDatum.DatumAbbreviation
                        End With

                    Case DMLType.Update

                        With .m_prmintVerticalReferenceDatumID
                            .ParameterName = "@VerticalReferenceDatumID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objVerticalReferenceDatum.VerticalReferenceDatumID
                        End With

                        With .m_prmstrVerticalReferenceDatumName
                            .ParameterName = "@VerticalReferenceDatumName"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objVerticalReferenceDatum.VerticalReferenceDatumName
                        End With

                        With .m_prmstrDatumAbbreviation
                            .ParameterName = "@DatumAbbreviation"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objVerticalReferenceDatum.DatumAbbreviation
                        End With

                    Case DMLType.Delete

                        With .m_prmintVerticalReferenceDatumID
                            .ParameterName = "@VerticalReferenceDatumID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objVerticalReferenceDatum.VerticalReferenceDatumID
                        End With

                End Select 'DMLOperation

            End With 'Me

        End Sub

        Private Function GetParameterArray(ByVal DMLOperation As DMLType) As OleDbParameter()

            Dim commandParameters() As OleDbParameter = Nothing

            Select Case DMLOperation
                Case DMLType.Insert
                    commandParameters = New OleDbParameter(2) {}
                    commandParameters(0) = Me.m_prmintVerticalReferenceDatumID
                    commandParameters(1) = Me.m_prmstrVerticalReferenceDatumName
                    commandParameters(2) = Me.m_prmstrDatumAbbreviation
                Case DMLType.Update
                    commandParameters = New OleDbParameter(2) {}
                    commandParameters(0) = Me.m_prmintVerticalReferenceDatumID
                    commandParameters(1) = Me.m_prmstrVerticalReferenceDatumName
                    commandParameters(2) = Me.m_prmstrDatumAbbreviation
                Case DMLType.Delete
                    commandParameters = New OleDbParameter(0) {}
                    commandParameters(0) = Me.m_prmintVerticalReferenceDatumID
            End Select
            Return commandParameters

        End Function

        Private Sub SetFieldOrdinalValues(ByVal dr As OleDbDataReader)

            FieldOrdinal.VerticalReferenceDatumID = dr.GetOrdinal(VerticalReferenceDatumConstants.FieldName.VerticalReferenceDatumID)
            FieldOrdinal.VerticalReferenceDatumName = dr.GetOrdinal(VerticalReferenceDatumConstants.FieldName.VerticalReferenceDatumName)
            FieldOrdinal.DatumAbbreviation = dr.GetOrdinal(VerticalReferenceDatumConstants.FieldName.DatumAbbreviation)

        End Sub

#End Region '----- Helper Methods -----

#Region "----- Lookup Methods -----"

        Friend Function GetAll() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetAll)

        End Function

        Friend Function GetLookupTable() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetLookupTable)

        End Function

        Friend Function GetByLookupName(ByVal strVerticalReferenceDatumName As String) As VerticalReferenceDatum

            Dim objVerticalReferenceDatum As VerticalReferenceDatum = Nothing
            Dim cnGeography As OleDbConnection
            Dim drVerticalReferenceDatum As OleDbDataReader
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmstrVerticalReferenceDatumName As OleDbParameter = New OleDbParameter

            With prmstrVerticalReferenceDatumName
                .ParameterName = ParameterName.VerticalReferenceDatumName
                .Direction = ParameterDirection.Input
                .Value = strVerticalReferenceDatumName
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmstrVerticalReferenceDatumName

            cnGeography = New OleDbConnection(GlobalVariables.ConnectionString)
            cnGeography.Open()
            drVerticalReferenceDatum = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByLookupName, commandParameters)
            If (drVerticalReferenceDatum.HasRows) Then
                objVerticalReferenceDatum = New VerticalReferenceDatum
                Call SetFieldOrdinalValues(drVerticalReferenceDatum)
                drVerticalReferenceDatum.Read()
                With objVerticalReferenceDatum
                    If (Not IsDBNull(drVerticalReferenceDatum(FieldOrdinal.VerticalReferenceDatumID))) Then
                        .VerticalReferenceDatumID = drVerticalReferenceDatum(FieldOrdinal.VerticalReferenceDatumID)
                    End If
                    If (Not IsDBNull(drVerticalReferenceDatum(FieldOrdinal.VerticalReferenceDatumName))) Then
                        .VerticalReferenceDatumName = drVerticalReferenceDatum(FieldOrdinal.VerticalReferenceDatumName)
                    End If
                    If (Not IsDBNull(drVerticalReferenceDatum(FieldOrdinal.DatumAbbreviation))) Then
                        .DatumAbbreviation = drVerticalReferenceDatum(FieldOrdinal.DatumAbbreviation)
                    End If
                End With
            End If
            drVerticalReferenceDatum.Close()
            cnGeography.Close()

            Return objVerticalReferenceDatum

        End Function

        Friend Function GetByPrimaryKey(ByVal intVerticalReferenceDatumID As Int32) As VerticalReferenceDatum

            Dim objVerticalReferenceDatum As VerticalReferenceDatum = Nothing
            Dim cnGeography As OleDbConnection
            Dim drVerticalReferenceDatum As OleDbDataReader
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmintVerticalReferenceDatumID As OleDbParameter = New OleDbParameter

            With prmintVerticalReferenceDatumID
                .ParameterName = ParameterName.VerticalReferenceDatumID
                .Direction = ParameterDirection.Input
                .Value = intVerticalReferenceDatumID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintVerticalReferenceDatumID

            cnGeography = New OleDbConnection(GlobalVariables.ConnectionString)
            cnGeography.Open()
            drVerticalReferenceDatum = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByPrimaryKey, commandParameters)
            If (drVerticalReferenceDatum.HasRows) Then
                objVerticalReferenceDatum = New VerticalReferenceDatum
                Call SetFieldOrdinalValues(drVerticalReferenceDatum)
                drVerticalReferenceDatum.Read()
                With objVerticalReferenceDatum
                    If (Not IsDBNull(drVerticalReferenceDatum(FieldOrdinal.VerticalReferenceDatumID))) Then
                        .VerticalReferenceDatumID = drVerticalReferenceDatum(FieldOrdinal.VerticalReferenceDatumID)
                    End If
                    If (Not IsDBNull(drVerticalReferenceDatum(FieldOrdinal.VerticalReferenceDatumName))) Then
                        .VerticalReferenceDatumName = drVerticalReferenceDatum(FieldOrdinal.VerticalReferenceDatumName)
                    End If
                    If (Not IsDBNull(drVerticalReferenceDatum(FieldOrdinal.DatumAbbreviation))) Then
                        .DatumAbbreviation = drVerticalReferenceDatum(FieldOrdinal.DatumAbbreviation)
                    End If
                End With
            End If
            drVerticalReferenceDatum.Close()
            cnGeography.Close()

            Return objVerticalReferenceDatum

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
