'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: HorizontalReferenceDatumDB.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Data access class for the HorizontalReferenceDatum table of the Geography database.
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

    <Serializable()> Friend Class HorizontalReferenceDatumDB

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        'field ordinal positions (for use with datareader object)
        Private Structure FieldOrdinal
            Private _trash As String
            Public Shared HorizontalReferenceDatumID As Int32 'primary key
            Public Shared HorizontalReferenceDatumName As Int32
            Public Shared DatumAbbreviation As Int32
            Public Shared DatumEPACode As Int32
            Public Shared Comment As Int32
        End Structure

        Private Structure StoredProcedure
            Private _trash As String
            Public Const Insert As String = "HorizontalReferenceDatum_Insert"
            Public Const Update As String = "HorizontalReferenceDatum_Update"
            Public Const Delete As String = "HorizontalReferenceDatum_Delete"
            Public Const GetByPrimaryKey As String = "HorizontalReferenceDatum_GetByPrimaryKey"
            Public Const GetAll As String = "HorizontalReferenceDatum_GetAll"
            Public Const GetLookupTable As String = "HorizontalReferenceDatum_GetLookupTable"
            Public Const GetByLookupName As String = "HorizontalReferenceDatum_GetByLookupName"
        End Structure

        'enums
        Private Enum DMLType As Integer
            Insert
            Update
            Delete
        End Enum

        'sqlClient parameters
        Private m_prmintHorizontalReferenceDatumID As OleDbParameter 'primary key
        Private m_prmstrHorizontalReferenceDatumName As OleDbParameter
        Private m_prmstrDatumAbbreviation As OleDbParameter
        Private m_prmstrDatumEPACode As OleDbParameter
        Private m_prmstrComment As OleDbParameter

        Private Structure ParameterName
            Private _trash As String
            Public Const HorizontalReferenceDatumID As String = "@HorizontalReferenceDatumID"
            Public Const HorizontalReferenceDatumName As String = "@HorizontalReferenceDatumName"
            Public Const DatumAbbreviation As String = "@DatumAbbreviation"
            Public Const DatumEPACode As String = "@DatumEPACode"
            Public Const Comment As String = "@Comment"
        End Structure

#End Region '----- Member Variables -----

#Region "----- DML -----"

        Friend Function Insert(ByVal objHorizontalReferenceDatum As HorizontalReferenceDatum, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objHorizontalReferenceDatum, DMLType.Insert, cmd)

        End Function

        Friend Function Update(ByVal objHorizontalReferenceDatum As HorizontalReferenceDatum, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objHorizontalReferenceDatum, DMLType.Update, cmd)

        End Function

        Friend Function Delete(ByVal objHorizontalReferenceDatum As HorizontalReferenceDatum, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objHorizontalReferenceDatum, DMLType.Delete, cmd)

        End Function

        Private Function DMLHelper(ByVal objHorizontalReferenceDatum As HorizontalReferenceDatum, ByVal iDMLType As DMLType, ByVal cmd As OleDbCommand) As Int32

            Dim intReturnValue As Int32
            Dim commandParameters() As OleDbParameter = Nothing

            With Me
                Call .InitializeParameterObjects()
                Call .AssignParameterValues(objHorizontalReferenceDatum, iDMLType)
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

            Me.m_prmintHorizontalReferenceDatumID = Nothing
            Me.m_prmintHorizontalReferenceDatumID = New OleDbParameter

            Me.m_prmstrHorizontalReferenceDatumName = Nothing
            Me.m_prmstrHorizontalReferenceDatumName = New OleDbParameter

            Me.m_prmstrDatumAbbreviation = Nothing
            Me.m_prmstrDatumAbbreviation = New OleDbParameter

            Me.m_prmstrDatumEPACode = Nothing
            Me.m_prmstrDatumEPACode = New OleDbParameter

            Me.m_prmstrComment = Nothing
            Me.m_prmstrComment = New OleDbParameter

        End Sub

        Private Sub AssignParameterValues(ByVal objHorizontalReferenceDatum As HorizontalReferenceDatum, ByVal DMLOperation As DMLType)

            With Me
                Select Case DMLOperation

                    Case DMLType.Insert

                        With .m_prmintHorizontalReferenceDatumID
                            .ParameterName = ParameterName.HorizontalReferenceDatumID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objHorizontalReferenceDatum.HorizontalReferenceDatumID
                        End With

                        With .m_prmstrHorizontalReferenceDatumName
                            .ParameterName = ParameterName.HorizontalReferenceDatumName
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objHorizontalReferenceDatum.HorizontalReferenceDatumName
                        End With

                        With .m_prmstrDatumAbbreviation
                            .ParameterName = ParameterName.DatumAbbreviation
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objHorizontalReferenceDatum.DatumAbbreviation
                        End With

                        With .m_prmstrDatumEPACode
                            .ParameterName = ParameterName.DatumEPACode
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objHorizontalReferenceDatum.DatumEPACode
                        End With

                        With .m_prmstrComment
                            .ParameterName = ParameterName.Comment
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objHorizontalReferenceDatum.Comment
                        End With

                    Case DMLType.Update

                        With .m_prmintHorizontalReferenceDatumID
                            .ParameterName = "@HorizontalReferenceDatumID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objHorizontalReferenceDatum.HorizontalReferenceDatumID
                        End With

                        With .m_prmstrHorizontalReferenceDatumName
                            .ParameterName = "@HorizontalReferenceDatumName"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objHorizontalReferenceDatum.HorizontalReferenceDatumName
                        End With

                        With .m_prmstrDatumAbbreviation
                            .ParameterName = "@DatumAbbreviation"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objHorizontalReferenceDatum.DatumAbbreviation
                        End With

                        With .m_prmstrDatumEPACode
                            .ParameterName = "@DatumEPACode"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objHorizontalReferenceDatum.DatumEPACode
                        End With

                        With .m_prmstrComment
                            .ParameterName = "@Comment"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objHorizontalReferenceDatum.Comment
                        End With

                    Case DMLType.Delete

                        With .m_prmintHorizontalReferenceDatumID
                            .ParameterName = "@HorizontalReferenceDatumID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objHorizontalReferenceDatum.HorizontalReferenceDatumID
                        End With

                End Select 'DMLOperation

            End With 'Me

        End Sub

        Private Function GetParameterArray(ByVal DMLOperation As DMLType) As OleDbParameter()

            Dim commandParameters() As OleDbParameter = Nothing

            Select Case DMLOperation
                Case DMLType.Insert
                    commandParameters = New OleDbParameter(4) {}
                    commandParameters(0) = Me.m_prmintHorizontalReferenceDatumID
                    commandParameters(1) = Me.m_prmstrHorizontalReferenceDatumName
                    commandParameters(2) = Me.m_prmstrDatumAbbreviation
                    commandParameters(3) = Me.m_prmstrDatumEPACode
                    commandParameters(4) = Me.m_prmstrComment
                Case DMLType.Update
                    commandParameters = New OleDbParameter(4) {}
                    commandParameters(0) = Me.m_prmintHorizontalReferenceDatumID
                    commandParameters(1) = Me.m_prmstrHorizontalReferenceDatumName
                    commandParameters(2) = Me.m_prmstrDatumAbbreviation
                    commandParameters(3) = Me.m_prmstrDatumEPACode
                    commandParameters(4) = Me.m_prmstrComment
                Case DMLType.Delete
                    commandParameters = New OleDbParameter(0) {}
                    commandParameters(0) = Me.m_prmintHorizontalReferenceDatumID
            End Select
            Return commandParameters

        End Function

        Private Sub SetFieldOrdinalValues(ByVal dr As OleDbDataReader)

            FieldOrdinal.HorizontalReferenceDatumID = dr.GetOrdinal(HorizontalReferenceDatumConstants.FieldName.HorizontalReferenceDatumID)
            FieldOrdinal.HorizontalReferenceDatumName = dr.GetOrdinal(HorizontalReferenceDatumConstants.FieldName.HorizontalReferenceDatumName)
            FieldOrdinal.DatumAbbreviation = dr.GetOrdinal(HorizontalReferenceDatumConstants.FieldName.DatumAbbreviation)
            FieldOrdinal.DatumEPACode = dr.GetOrdinal(HorizontalReferenceDatumConstants.FieldName.DatumEPACode)
            FieldOrdinal.Comment = dr.GetOrdinal(HorizontalReferenceDatumConstants.FieldName.Comment)

        End Sub

#End Region '----- Helper Methods -----

#Region "----- Lookup Methods -----"

        Friend Function GetAll() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetAll)

        End Function

        Friend Function GetLookupTable() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetLookupTable)

        End Function

        Friend Function GetByLookupName(ByVal strHorizontalReferenceDatumName As String) As HorizontalReferenceDatum

            Dim objHorizontalReferenceDatum As HorizontalReferenceDatum = Nothing
            Dim cnGeography As OleDbConnection
            Dim drHorizontalReferenceDatum As OleDbDataReader
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmstrHorizontalReferenceDatumName As OleDbParameter = New OleDbParameter

            With prmstrHorizontalReferenceDatumName
                .ParameterName = ParameterName.HorizontalReferenceDatumName
                .Direction = ParameterDirection.Input
                .Value = strHorizontalReferenceDatumName
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmstrHorizontalReferenceDatumName

            cnGeography = New OleDbConnection(GlobalVariables.ConnectionString)
            cnGeography.Open()
            drHorizontalReferenceDatum = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByLookupName, commandParameters)
            If (drHorizontalReferenceDatum.HasRows) Then
                objHorizontalReferenceDatum = New HorizontalReferenceDatum
                Call SetFieldOrdinalValues(drHorizontalReferenceDatum)
                drHorizontalReferenceDatum.Read()
                With objHorizontalReferenceDatum
                    If (Not IsDBNull(drHorizontalReferenceDatum(FieldOrdinal.HorizontalReferenceDatumID))) Then
                        .HorizontalReferenceDatumID = drHorizontalReferenceDatum(FieldOrdinal.HorizontalReferenceDatumID)
                    End If
                    If (Not IsDBNull(drHorizontalReferenceDatum(FieldOrdinal.HorizontalReferenceDatumName))) Then
                        .HorizontalReferenceDatumName = drHorizontalReferenceDatum(FieldOrdinal.HorizontalReferenceDatumName)
                    End If
                    If (Not IsDBNull(drHorizontalReferenceDatum(FieldOrdinal.DatumAbbreviation))) Then
                        .DatumAbbreviation = drHorizontalReferenceDatum(FieldOrdinal.DatumAbbreviation)
                    End If
                    If (Not IsDBNull(drHorizontalReferenceDatum(FieldOrdinal.DatumEPACode))) Then
                        .DatumEPACode = drHorizontalReferenceDatum(FieldOrdinal.DatumEPACode)
                    End If
                    If (Not IsDBNull(drHorizontalReferenceDatum(FieldOrdinal.Comment))) Then
                        .Comment = drHorizontalReferenceDatum(FieldOrdinal.Comment)
                    End If
                End With
            End If
            drHorizontalReferenceDatum.Close()
            cnGeography.Close()

            Return objHorizontalReferenceDatum

        End Function

        Friend Function GetByPrimaryKey(ByVal intHorizontalReferenceDatumID As Int32) As HorizontalReferenceDatum

            Dim objHorizontalReferenceDatum As HorizontalReferenceDatum = Nothing
            Dim cnGeography As OleDbConnection
            Dim drHorizontalReferenceDatum As OleDbDataReader
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmintHorizontalReferenceDatumID As OleDbParameter = New OleDbParameter

            With prmintHorizontalReferenceDatumID
                .ParameterName = ParameterName.HorizontalReferenceDatumID
                .Direction = ParameterDirection.Input
                .Value = intHorizontalReferenceDatumID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintHorizontalReferenceDatumID

            cnGeography = New OleDbConnection(GlobalVariables.ConnectionString)
            cnGeography.Open()
            drHorizontalReferenceDatum = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByPrimaryKey, commandParameters)
            If (drHorizontalReferenceDatum.HasRows) Then
                objHorizontalReferenceDatum = New HorizontalReferenceDatum
                Call SetFieldOrdinalValues(drHorizontalReferenceDatum)
                drHorizontalReferenceDatum.Read()
                With objHorizontalReferenceDatum
                    If (Not IsDBNull(drHorizontalReferenceDatum(FieldOrdinal.HorizontalReferenceDatumID))) Then
                        .HorizontalReferenceDatumID = drHorizontalReferenceDatum(FieldOrdinal.HorizontalReferenceDatumID)
                    End If
                    If (Not IsDBNull(drHorizontalReferenceDatum(FieldOrdinal.HorizontalReferenceDatumName))) Then
                        .HorizontalReferenceDatumName = drHorizontalReferenceDatum(FieldOrdinal.HorizontalReferenceDatumName)
                    End If
                    If (Not IsDBNull(drHorizontalReferenceDatum(FieldOrdinal.DatumAbbreviation))) Then
                        .DatumAbbreviation = drHorizontalReferenceDatum(FieldOrdinal.DatumAbbreviation)
                    End If
                    If (Not IsDBNull(drHorizontalReferenceDatum(FieldOrdinal.DatumEPACode))) Then
                        .DatumEPACode = drHorizontalReferenceDatum(FieldOrdinal.DatumEPACode)
                    End If
                    If (Not IsDBNull(drHorizontalReferenceDatum(FieldOrdinal.Comment))) Then
                        .Comment = drHorizontalReferenceDatum(FieldOrdinal.Comment)
                    End If
                End With
            End If
            drHorizontalReferenceDatum.Close()
            cnGeography.Close()

            Return objHorizontalReferenceDatum

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
