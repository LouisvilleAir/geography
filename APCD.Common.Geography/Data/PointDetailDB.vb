'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: PointDetailDB.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Data access class for the PointDetail table of the Geography database.
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

    <Serializable()> Friend Class PointDetailDB

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        'field ordinal positions (for use with datareader object)
        Private Structure FieldOrdinal
            Private _trash As String
            Public Shared PointID As Int32 'primary key
            Public Shared PointDetailTypeID As Int32 'primary key
            Public Shared PointDetailValue As Int32
            Public Shared UnitOfMeasurementID As Int32
            Public Shared AddDate As Int32
            Public Shared AddedBy As Int32
        End Structure

        Private Structure StoredProcedure
            Private _trash As String
            Public Const Insert As String = "PointDetail_Insert"
            Public Const Update As String = "PointDetail_Update"
            Public Const Delete As String = "PointDetail_Delete"
            Public Const GetByPrimaryKey As String = "PointDetail_GetByPrimaryKey"
            Public Const GetAll As String = "PointDetail_GetAll"
            Public Const GetByPointID As String = "PointDetail_GetByPointID"
            Public Const GetByPointDetailTypeID As String = "PointDetail_GetByPointDetailTypeID"
        End Structure

        'enums
        Private Enum DMLType As Integer
            Insert
            Update
            Delete
        End Enum

        'sqlClient parameters
        Private m_prmintPointID As OleDbParameter 'primary key
        Private m_prmintPointDetailTypeID As OleDbParameter 'primary key
        Private m_prmdblPointDetailValue As OleDbParameter
        Private m_prmintUnitOfMeasurementID As OleDbParameter
        Private m_prmdtAddDate As OleDbParameter
        Private m_prmintAddedBy As OleDbParameter

        Private Structure ParameterName
            Private _trash As String
            Public Const PointID As String = "@PointID"
            Public Const PointDetailTypeID As String = "@PointDetailTypeID"
            Public Const PointDetailValue As String = "@PointDetailValue"
            Public Const UnitOfMeasurementID As String = "@UnitOfMeasurementID"
            Public Const AddDate As String = "@AddDate"
            Public Const AddedBy As String = "@AddedBy"
        End Structure

#End Region '----- Member Variables -----

#Region "----- DML -----"

        Friend Function Insert(ByVal objPointDetail As PointDetail, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objPointDetail, DMLType.Insert, cmd)

        End Function

        Friend Function Update(ByVal objPointDetail As PointDetail, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objPointDetail, DMLType.Update, cmd)

        End Function

        Friend Function Delete(ByVal objPointDetail As PointDetail, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objPointDetail, DMLType.Delete, cmd)

        End Function

        Private Function DMLHelper(ByVal objPointDetail As PointDetail, ByVal iDMLType As DMLType, ByVal cmd As OleDbCommand) As Int32

            Dim intReturnValue As Int32
            Dim commandParameters() As OleDbParameter = Nothing

            With Me
                Call .InitializeParameterObjects()
                Call .AssignParameterValues(objPointDetail, iDMLType)
                commandParameters = .GetParameterArray(iDMLType)
                Select Case iDMLType
                    Case DMLType.Insert

                        intReturnValue = OleDbHelper.ExecuteNonQuery(GlobalVariables.ConnectionString, StoredProcedure.Insert, commandParameters)
                    Case DMLType.Update

                        intReturnValue = OleDbHelper.ExecuteNonQuery(GlobalVariables.ConnectionString, StoredProcedure.Update, commandParameters)
                    Case DMLType.Delete

                        intReturnValue = OleDbHelper.ExecuteNonQuery(GlobalVariables.ConnectionString, StoredProcedure.Delete, commandParameters)
                End Select
            End With

            Return intReturnValue

        End Function

#End Region '----- DML -----

#Region "----- Helper Methods -----"

        Private Sub InitializeParameterObjects()

            Me.m_prmintPointID = Nothing
            Me.m_prmintPointID = New OleDbParameter

            Me.m_prmintPointDetailTypeID = Nothing
            Me.m_prmintPointDetailTypeID = New OleDbParameter

            Me.m_prmdblPointDetailValue = Nothing
            Me.m_prmdblPointDetailValue = New OleDbParameter

            Me.m_prmintUnitOfMeasurementID = Nothing
            Me.m_prmintUnitOfMeasurementID = New OleDbParameter

            Me.m_prmdtAddDate = Nothing
            Me.m_prmdtAddDate = New OleDbParameter

            Me.m_prmintAddedBy = Nothing
            Me.m_prmintAddedBy = New OleDbParameter

        End Sub

        Private Sub AssignParameterValues(ByVal objPointDetail As PointDetail, ByVal DMLOperation As DMLType)

            With Me
                Select Case DMLOperation

                    Case DMLType.Insert

                        With .m_prmintPointID
                            .ParameterName = ParameterName.PointID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPointDetail.PointID
                        End With

                        With .m_prmintPointDetailTypeID
                            .ParameterName = ParameterName.PointDetailTypeID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPointDetail.PointDetailTypeID
                        End With

                        With .m_prmdblPointDetailValue
                            .ParameterName = ParameterName.PointDetailValue
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Double
                            .Value = objPointDetail.PointDetailValue
                        End With

                        With .m_prmintUnitOfMeasurementID
                            .ParameterName = ParameterName.UnitOfMeasurementID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPointDetail.UnitOfMeasurementID
                        End With

                        With .m_prmdtAddDate
                            .ParameterName = ParameterName.AddDate
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Date
                            .Value = objPointDetail.AddDate
                        End With

                        With .m_prmintAddedBy
                            .ParameterName = ParameterName.AddedBy
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPointDetail.AddedBy
                        End With

                    Case DMLType.Update

                        With .m_prmintPointID
                            .ParameterName = "@PointID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPointDetail.PointID
                        End With

                        With .m_prmintPointDetailTypeID
                            .ParameterName = "@PointDetailTypeID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPointDetail.PointDetailTypeID
                        End With

                        With .m_prmdblPointDetailValue
                            .ParameterName = "@PointDetailValue"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Double
                            .Value = objPointDetail.PointDetailValue
                        End With

                        With .m_prmintUnitOfMeasurementID
                            .ParameterName = "@UnitOfMeasurementID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPointDetail.UnitOfMeasurementID
                        End With

                        With .m_prmdtAddDate
                            .ParameterName = "@AddDate"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Date
                            .Value = objPointDetail.AddDate
                        End With

                        With .m_prmintAddedBy
                            .ParameterName = "@AddedBy"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPointDetail.AddedBy
                        End With

                    Case DMLType.Delete

                        With .m_prmintPointID
                            .ParameterName = "@PointID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPointDetail.PointID
                        End With

                        With .m_prmintPointDetailTypeID
                            .ParameterName = "@PointDetailTypeID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPointDetail.PointDetailTypeID
                        End With

                End Select 'DMLOperation

            End With 'Me

        End Sub

        Private Function GetParameterArray(ByVal DMLOperation As DMLType) As OleDbParameter()

            Dim commandParameters() As OleDbParameter = Nothing

            Select Case DMLOperation
                Case DMLType.Insert
                    commandParameters = New OleDbParameter(5) {}
                    commandParameters(0) = Me.m_prmintPointID
                    commandParameters(1) = Me.m_prmintPointDetailTypeID
                    commandParameters(2) = Me.m_prmdblPointDetailValue
                    commandParameters(3) = Me.m_prmintUnitOfMeasurementID
                    commandParameters(4) = Me.m_prmdtAddDate
                    commandParameters(5) = Me.m_prmintAddedBy
                Case DMLType.Update
                    commandParameters = New OleDbParameter(5) {}
                    commandParameters(0) = Me.m_prmintPointID
                    commandParameters(1) = Me.m_prmintPointDetailTypeID
                    commandParameters(2) = Me.m_prmdblPointDetailValue
                    commandParameters(3) = Me.m_prmintUnitOfMeasurementID
                    commandParameters(4) = Me.m_prmdtAddDate
                    commandParameters(5) = Me.m_prmintAddedBy
                Case DMLType.Delete
                    commandParameters = New OleDbParameter(1) {}
                    commandParameters(0) = Me.m_prmintPointID
                    commandParameters(1) = Me.m_prmintPointDetailTypeID
            End Select
            Return commandParameters

        End Function

        Private Sub SetFieldOrdinalValues(ByVal dr As OleDbDataReader)

            FieldOrdinal.PointID = dr.GetOrdinal(PointDetailConstants.FieldName.PointID)
            FieldOrdinal.PointDetailTypeID = dr.GetOrdinal(PointDetailConstants.FieldName.PointDetailTypeID)
            FieldOrdinal.PointDetailValue = dr.GetOrdinal(PointDetailConstants.FieldName.PointDetailValue)
            FieldOrdinal.UnitOfMeasurementID = dr.GetOrdinal(PointDetailConstants.FieldName.UnitOfMeasurementID)
            FieldOrdinal.AddDate = dr.GetOrdinal(PointDetailConstants.FieldName.AddDate)
            FieldOrdinal.AddedBy = dr.GetOrdinal(PointDetailConstants.FieldName.AddedBy)

        End Sub

#End Region '----- Helper Methods -----

#Region "----- Lookup Methods -----"

        Friend Function GetAll() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetAll)

        End Function

        Friend Function GetByPrimaryKey(ByVal intPointID As Int32, ByVal intPointDetailTypeID As Int32) As PointDetail

            Dim objPointDetail As PointDetail = Nothing
            Dim cnGeography As OleDbConnection
            Dim drPointDetail As OleDbDataReader
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmintPointID As OleDbParameter = New OleDbParameter
            Dim prmintPointDetailTypeID As OleDbParameter = New OleDbParameter

            With prmintPointID
                .ParameterName = ParameterName.PointID
                .Direction = ParameterDirection.Input
                .Value = intPointID
            End With
            With prmintPointDetailTypeID
                .ParameterName = ParameterName.PointDetailTypeID
                .Direction = ParameterDirection.Input
                .Value = intPointDetailTypeID
            End With
            commandParameters = New OleDbParameter(1) {}
            commandParameters(0) = prmintPointID
            commandParameters(1) = prmintPointDetailTypeID

            cnGeography = New OleDbConnection(GlobalVariables.ConnectionString)
            cnGeography.Open()
            drPointDetail = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByPrimaryKey, commandParameters)
            If (drPointDetail.HasRows) Then
                objPointDetail = New PointDetail
                Call SetFieldOrdinalValues(drPointDetail)
                drPointDetail.Read()
                With objPointDetail
                    If (Not IsDBNull(drPointDetail(FieldOrdinal.PointID))) Then
                        .PointID = drPointDetail(FieldOrdinal.PointID)
                    End If
                    If (Not IsDBNull(drPointDetail(FieldOrdinal.PointDetailTypeID))) Then
                        .PointDetailTypeID = drPointDetail(FieldOrdinal.PointDetailTypeID)
                    End If
                    If (Not IsDBNull(drPointDetail(FieldOrdinal.PointDetailValue))) Then
                        .PointDetailValue = drPointDetail(FieldOrdinal.PointDetailValue)
                    End If
                    If (Not IsDBNull(drPointDetail(FieldOrdinal.UnitOfMeasurementID))) Then
                        .UnitOfMeasurementID = drPointDetail(FieldOrdinal.UnitOfMeasurementID)
                    End If
                    If (Not IsDBNull(drPointDetail(FieldOrdinal.AddDate))) Then
                        .AddDate = drPointDetail(FieldOrdinal.AddDate)
                    End If
                    If (Not IsDBNull(drPointDetail(FieldOrdinal.AddedBy))) Then
                        .AddedBy = drPointDetail(FieldOrdinal.AddedBy)
                    End If
                End With
            End If
            drPointDetail.Close()
            cnGeography.Close()

            Return objPointDetail

        End Function

        Friend Function GetByPointID(ByVal intPointID As Int32) As DataTable

            Dim dtbPointDetail As DataTable
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmintPointID As OleDbParameter = New OleDbParameter

            With prmintPointID
                .ParameterName = ParameterName.PointID
                .Direction = ParameterDirection.Input
                .Value = intPointID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintPointID

            dtbPointDetail = OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetByPointID, commandParameters)

            Return dtbPointDetail

        End Function

        Friend Function GetByPointDetailTypeID(ByVal intPointDetailTypeID As Int32) As DataTable

            Dim dtbPointDetail As DataTable
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmintPointDetailTypeID As OleDbParameter = New OleDbParameter

            With prmintPointDetailTypeID
                .ParameterName = ParameterName.PointDetailTypeID
                .Direction = ParameterDirection.Input
                .Value = intPointDetailTypeID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintPointDetailTypeID

            dtbPointDetail = OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetByPointDetailTypeID, commandParameters)

            Return dtbPointDetail

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
