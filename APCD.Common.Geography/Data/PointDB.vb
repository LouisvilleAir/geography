'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: PointDB.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Data access class for the Point table of the Geography database.
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

    <Serializable()> Friend Class PointDB

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
            Public Shared GeographicCoordinateTypeID As Int32
            Public Shared CoordinateZone As Int32
            Public Shared GeometricTypeID As Int32
            Public Shared XCoordinate As Int32
            Public Shared YCoordinate As Int32
            Public Shared Elevation As Int32
            Public Shared UnitOfMeasurementID As Int32
            Public Shared HorizontalCollectionMethodID As Int32
            Public Shared HorizontalReferenceDatumID As Int32
            Public Shared SourceMapScaleNumber As Int32
            Public Shared CoordinateVerificationMethodID As Int32
            Public Shared CoordinateDataSourceID As Int32
            Public Shared HorizontalCollectionDate As Int32
            Public Shared VerticalCollectionMethodID As Int32
            Public Shared VerticalReferenceDatumID As Int32
            Public Shared VerticalCollectionDate As Int32
            Public Shared GeographicPointComment As Int32
            Public Shared AddDate As Int32
            Public Shared AddedBy As Int32
        End Structure

        Private Structure StoredProcedure
            Private _trash As String
            Public Const Insert As String = "Point_Insert"
            Public Const Update As String = "Point_Update"
            Public Const Delete As String = "Point_Delete"
            Public Const GetByPrimaryKey As String = "Point_GetByPrimaryKey"
            Public Const GetAll As String = "Point_GetAll"
            Public Const GetByCoordinateDataSourceID As String = "Point_GetByCoordinateDataSourceID"
            Public Const GetByCoordinateVerificationMethodID As String = "Point_GetByCoordinateVerificationMethodID"
            Public Const GetByGeographicCoordinateTypeID As String = "Point_GetByGeographicCoordinateTypeID"
            Public Const GetByHorizontalCollectionMethodID As String = "Point_GetByHorizontalCollectionMethodID"
            Public Const GetByHorizontalReferenceDatumID As String = "Point_GetByHorizontalReferenceDatumID"
            Public Const GetByVerticalCollectionMethodID As String = "Point_GetByVerticalCollectionMethodID"
            Public Const GetByVerticalReferenceDatumID As String = "Point_GetByVerticalReferenceDatumID"
        End Structure

        'enums
        Private Enum DMLType As Integer
            Insert
            Update
            Delete
        End Enum

        'sqlClient parameters
        Private m_prmintPointID As OleDbParameter 'primary key
        Private m_prmintGeographicCoordinateTypeID As OleDbParameter
        Private m_prmintCoordinateZone As OleDbParameter
        Private m_prmintGeometricTypeID As OleDbParameter
        Private m_prmdblXCoordinate As OleDbParameter
        Private m_prmdblYCoordinate As OleDbParameter
        Private m_prmdblElevation As OleDbParameter
        Private m_prmintUnitOfMeasurementID As OleDbParameter
        Private m_prmintHorizontalCollectionMethodID As OleDbParameter
        Private m_prmintHorizontalReferenceDatumID As OleDbParameter
        Private m_prmintSourceMapScaleNumber As OleDbParameter
        Private m_prmintCoordinateVerificationMethodID As OleDbParameter
        Private m_prmintCoordinateDataSourceID As OleDbParameter
        Private m_prmdtHorizontalCollectionDate As OleDbParameter
        Private m_prmintVerticalCollectionMethodID As OleDbParameter
        Private m_prmintVerticalReferenceDatumID As OleDbParameter
        Private m_prmdtVerticalCollectionDate As OleDbParameter
        Private m_prmstrGeographicPointComment As OleDbParameter
        Private m_prmdtAddDate As OleDbParameter
        Private m_prmintAddedBy As OleDbParameter

        Private Structure ParameterName
            Private _trash As String
            Public Const PointID As String = "@PointID"
            Public Const GeographicCoordinateTypeID As String = "@GeographicCoordinateTypeID"
            Public Const CoordinateZone As String = "@CoordinateZone"
            Public Const GeometricTypeID As String = "@GeometricTypeID"
            Public Const XCoordinate As String = "@XCoordinate"
            Public Const YCoordinate As String = "@YCoordinate"
            Public Const Elevation As String = "@Elevation"
            Public Const UnitOfMeasurementID As String = "@UnitOfMeasurementID"
            Public Const HorizontalCollectionMethodID As String = "@HorizontalCollectionMethodID"
            Public Const HorizontalReferenceDatumID As String = "@HorizontalReferenceDatumID"
            Public Const SourceMapScaleNumber As String = "@SourceMapScaleNumber"
            Public Const CoordinateVerificationMethodID As String = "@CoordinateVerificationMethodID"
            Public Const CoordinateDataSourceID As String = "@CoordinateDataSourceID"
            Public Const HorizontalCollectionDate As String = "@HorizontalCollectionDate"
            Public Const VerticalCollectionMethodID As String = "@VerticalCollectionMethodID"
            Public Const VerticalReferenceDatumID As String = "@VerticalReferenceDatumID"
            Public Const VerticalCollectionDate As String = "@VerticalCollectionDate"
            Public Const GeographicPointComment As String = "@GeographicPointComment"
            Public Const AddDate As String = "@AddDate"
            Public Const AddedBy As String = "@AddedBy"
        End Structure

#End Region '----- Member Variables -----

#Region "----- DML -----"

        Friend Function Insert(ByVal objPoint As Point, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objPoint, DMLType.Insert, cmd)

        End Function

        Friend Function Update(ByVal objPoint As Point, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objPoint, DMLType.Update, cmd)

        End Function

        Friend Function Delete(ByVal objPoint As Point, ByVal cmd As OleDbCommand) As Int32

            Return Me.DMLHelper(objPoint, DMLType.Delete, cmd)

        End Function

        Private Function DMLHelper(ByVal objPoint As Point, ByVal iDMLType As DMLType, ByVal cmd As OleDbCommand) As Int32

            Dim intReturnValue As Int32
            Dim commandParameters() As OleDbParameter = Nothing

            With Me
                Call .InitializeParameterObjects()
                Call .AssignParameterValues(objPoint, iDMLType)
                commandParameters = .GetParameterArray(iDMLType)
                Select Case iDMLType
                    Case DMLType.Insert
                        intReturnValue = OleDbHelper.ExecuteNonQuery(cmd, StoredProcedure.Insert, commandParameters, objPoint.PointID)
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

            Me.m_prmintPointID = Nothing
            Me.m_prmintPointID = New OleDbParameter

            Me.m_prmintGeographicCoordinateTypeID = Nothing
            Me.m_prmintGeographicCoordinateTypeID = New OleDbParameter

            Me.m_prmintCoordinateZone = Nothing
            Me.m_prmintCoordinateZone = New OleDbParameter

            Me.m_prmintGeometricTypeID = Nothing
            Me.m_prmintGeometricTypeID = New OleDbParameter

            Me.m_prmdblXCoordinate = Nothing
            Me.m_prmdblXCoordinate = New OleDbParameter

            Me.m_prmdblYCoordinate = Nothing
            Me.m_prmdblYCoordinate = New OleDbParameter

            Me.m_prmdblElevation = Nothing
            Me.m_prmdblElevation = New OleDbParameter

            Me.m_prmintUnitOfMeasurementID = Nothing
            Me.m_prmintUnitOfMeasurementID = New OleDbParameter

            Me.m_prmintHorizontalCollectionMethodID = Nothing
            Me.m_prmintHorizontalCollectionMethodID = New OleDbParameter

            Me.m_prmintHorizontalReferenceDatumID = Nothing
            Me.m_prmintHorizontalReferenceDatumID = New OleDbParameter

            Me.m_prmintSourceMapScaleNumber = Nothing
            Me.m_prmintSourceMapScaleNumber = New OleDbParameter

            Me.m_prmintCoordinateVerificationMethodID = Nothing
            Me.m_prmintCoordinateVerificationMethodID = New OleDbParameter

            Me.m_prmintCoordinateDataSourceID = Nothing
            Me.m_prmintCoordinateDataSourceID = New OleDbParameter

            Me.m_prmdtHorizontalCollectionDate = Nothing
            Me.m_prmdtHorizontalCollectionDate = New OleDbParameter

            Me.m_prmintVerticalCollectionMethodID = Nothing
            Me.m_prmintVerticalCollectionMethodID = New OleDbParameter

            Me.m_prmintVerticalReferenceDatumID = Nothing
            Me.m_prmintVerticalReferenceDatumID = New OleDbParameter

            Me.m_prmdtVerticalCollectionDate = Nothing
            Me.m_prmdtVerticalCollectionDate = New OleDbParameter

            Me.m_prmstrGeographicPointComment = Nothing
            Me.m_prmstrGeographicPointComment = New OleDbParameter

            Me.m_prmdtAddDate = Nothing
            Me.m_prmdtAddDate = New OleDbParameter

            Me.m_prmintAddedBy = Nothing
            Me.m_prmintAddedBy = New OleDbParameter

        End Sub

        Private Sub AssignParameterValues(ByVal objPoint As Point, ByVal DMLOperation As DMLType)

            With Me
                Select Case DMLOperation

                    Case DMLType.Insert

                        With .m_prmintPointID
                            .ParameterName = ParameterName.PointID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.PointID
                        End With

                        With .m_prmintGeographicCoordinateTypeID
                            .ParameterName = ParameterName.GeographicCoordinateTypeID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.GeographicCoordinateTypeID
                        End With

                        With .m_prmintCoordinateZone
                            .ParameterName = ParameterName.CoordinateZone
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.CoordinateZone
                        End With

                        With .m_prmintGeometricTypeID
                            .ParameterName = ParameterName.GeometricTypeID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.GeometricTypeID
                        End With

                        With .m_prmdblXCoordinate
                            .ParameterName = ParameterName.XCoordinate
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Decimal
                            .Value = objPoint.XCoordinate
                        End With

                        With .m_prmdblYCoordinate
                            .ParameterName = ParameterName.YCoordinate
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Decimal
                            .Value = objPoint.YCoordinate
                        End With

                        With .m_prmdblElevation
                            .ParameterName = ParameterName.Elevation
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Decimal
                            .Value = objPoint.Elevation
                        End With

                        With .m_prmintUnitOfMeasurementID
                            .ParameterName = ParameterName.UnitOfMeasurementID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.UnitOfMeasurementID
                        End With

                        With .m_prmintHorizontalCollectionMethodID
                            .ParameterName = ParameterName.HorizontalCollectionMethodID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.HorizontalCollectionMethodID
                        End With

                        With .m_prmintHorizontalReferenceDatumID
                            .ParameterName = ParameterName.HorizontalReferenceDatumID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.HorizontalReferenceDatumID
                        End With

                        With .m_prmintSourceMapScaleNumber
                            .ParameterName = ParameterName.SourceMapScaleNumber
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.SourceMapScaleNumber
                        End With

                        With .m_prmintCoordinateVerificationMethodID
                            .ParameterName = ParameterName.CoordinateVerificationMethodID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.CoordinateVerificationMethodID
                        End With

                        With .m_prmintCoordinateDataSourceID
                            .ParameterName = ParameterName.CoordinateDataSourceID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.CoordinateDataSourceID
                        End With

                        With .m_prmdtHorizontalCollectionDate
                            .ParameterName = ParameterName.HorizontalCollectionDate
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Date
                            .Value = objPoint.HorizontalCollectionDate
                        End With

                        With .m_prmintVerticalCollectionMethodID
                            .ParameterName = ParameterName.VerticalCollectionMethodID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.VerticalCollectionMethodID
                        End With

                        With .m_prmintVerticalReferenceDatumID
                            .ParameterName = ParameterName.VerticalReferenceDatumID
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.VerticalReferenceDatumID
                        End With

                        With .m_prmdtVerticalCollectionDate
                            .ParameterName = ParameterName.VerticalCollectionDate
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Date
                            If (objPoint.VerticalCollectionDate = Nothing) Then
                                .Value = DBNull.Value
                            Else
                                .Value = objPoint.VerticalCollectionDate
                            End If
                        End With

                        With .m_prmstrGeographicPointComment
                            .ParameterName = ParameterName.GeographicPointComment
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPoint.GeographicPointComment
                        End With

                        With .m_prmdtAddDate
                            .ParameterName = ParameterName.AddDate
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Date
                            .Value = objPoint.AddDate
                        End With

                        With .m_prmintAddedBy
                            .ParameterName = ParameterName.AddedBy
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.AddedBy
                        End With

                    Case DMLType.Update

                        With .m_prmintPointID
                            .ParameterName = "@PointID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.PointID
                        End With

                        With .m_prmintGeographicCoordinateTypeID
                            .ParameterName = "@GeographicCoordinateTypeID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.GeographicCoordinateTypeID
                        End With

                        With .m_prmintCoordinateZone
                            .ParameterName = "@CoordinateZone"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.CoordinateZone
                        End With

                        With .m_prmintGeometricTypeID
                            .ParameterName = "@GeometricTypeID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.GeometricTypeID
                        End With

                        With .m_prmdblXCoordinate
                            .ParameterName = "@XCoordinate"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Decimal
                            .Value = objPoint.XCoordinate
                        End With

                        With .m_prmdblYCoordinate
                            .ParameterName = "@YCoordinate"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Decimal
                            .Value = objPoint.YCoordinate
                        End With

                        With .m_prmdblElevation
                            .ParameterName = "@Elevation"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Decimal
                            .Value = objPoint.Elevation
                        End With

                        With .m_prmintUnitOfMeasurementID
                            .ParameterName = "@UnitOfMeasurementID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.UnitOfMeasurementID
                        End With

                        With .m_prmintHorizontalCollectionMethodID
                            .ParameterName = "@HorizontalCollectionMethodID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.HorizontalCollectionMethodID
                        End With

                        With .m_prmintHorizontalReferenceDatumID
                            .ParameterName = "@HorizontalReferenceDatumID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.HorizontalReferenceDatumID
                        End With

                        With .m_prmintSourceMapScaleNumber
                            .ParameterName = "@SourceMapScaleNumber"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.SourceMapScaleNumber
                        End With

                        With .m_prmintCoordinateVerificationMethodID
                            .ParameterName = "@CoordinateVerificationMethodID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.CoordinateVerificationMethodID
                        End With

                        With .m_prmintCoordinateDataSourceID
                            .ParameterName = "@CoordinateDataSourceID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.CoordinateDataSourceID
                        End With

                        With .m_prmdtHorizontalCollectionDate
                            .ParameterName = "@HorizontalCollectionDate"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Date
                            .Value = objPoint.HorizontalCollectionDate
                        End With

                        With .m_prmintVerticalCollectionMethodID
                            .ParameterName = "@VerticalCollectionMethodID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.VerticalCollectionMethodID
                        End With

                        With .m_prmintVerticalReferenceDatumID
                            .ParameterName = "@VerticalReferenceDatumID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.VerticalReferenceDatumID
                        End With

                        With .m_prmdtVerticalCollectionDate
                            .ParameterName = "@VerticalCollectionDate"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Date
                            .Value = objPoint.VerticalCollectionDate
                        End With

                        With .m_prmstrGeographicPointComment
                            .ParameterName = "@GeographicPointComment"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.VarChar
                            .Value = objPoint.GeographicPointComment
                        End With

                        With .m_prmdtAddDate
                            .ParameterName = "@AddDate"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Date
                            .Value = objPoint.AddDate
                        End With

                        With .m_prmintAddedBy
                            .ParameterName = "@AddedBy"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.AddedBy
                        End With

                    Case DMLType.Delete

                        With .m_prmintPointID
                            .ParameterName = "@PointID"
                            .Direction = ParameterDirection.Input
                            .OleDbType = OleDbType.Integer
                            .Value = objPoint.PointID
                        End With

                End Select 'DMLOperation

            End With 'Me

        End Sub

        Private Function GetParameterArray(ByVal DMLOperation As DMLType) As OleDbParameter()

            Dim commandParameters() As OleDbParameter = Nothing

            Select Case DMLOperation
                Case DMLType.Insert
                    commandParameters = New OleDbParameter(18) {}
                    commandParameters(0) = Me.m_prmintGeographicCoordinateTypeID
                    commandParameters(1) = Me.m_prmintCoordinateZone
                    commandParameters(2) = Me.m_prmintGeometricTypeID
                    commandParameters(3) = Me.m_prmdblXCoordinate
                    commandParameters(4) = Me.m_prmdblYCoordinate
                    commandParameters(5) = Me.m_prmdblElevation
                    commandParameters(6) = Me.m_prmintUnitOfMeasurementID
                    commandParameters(7) = Me.m_prmintHorizontalCollectionMethodID
                    commandParameters(8) = Me.m_prmintHorizontalReferenceDatumID
                    commandParameters(9) = Me.m_prmintSourceMapScaleNumber
                    commandParameters(10) = Me.m_prmintCoordinateVerificationMethodID
                    commandParameters(11) = Me.m_prmintCoordinateDataSourceID
                    commandParameters(12) = Me.m_prmdtHorizontalCollectionDate
                    commandParameters(13) = Me.m_prmintVerticalCollectionMethodID
                    commandParameters(14) = Me.m_prmintVerticalReferenceDatumID
                    commandParameters(15) = Me.m_prmdtVerticalCollectionDate
                    commandParameters(16) = Me.m_prmstrGeographicPointComment
                    commandParameters(17) = Me.m_prmdtAddDate
                    commandParameters(18) = Me.m_prmintAddedBy
                Case DMLType.Update
                    commandParameters = New OleDbParameter(19) {}
                    commandParameters(0) = Me.m_prmintPointID
                    commandParameters(1) = Me.m_prmintGeographicCoordinateTypeID
                    commandParameters(2) = Me.m_prmintCoordinateZone
                    commandParameters(3) = Me.m_prmintGeometricTypeID
                    commandParameters(4) = Me.m_prmdblXCoordinate
                    commandParameters(5) = Me.m_prmdblYCoordinate
                    commandParameters(6) = Me.m_prmdblElevation
                    commandParameters(7) = Me.m_prmintUnitOfMeasurementID
                    commandParameters(8) = Me.m_prmintHorizontalCollectionMethodID
                    commandParameters(9) = Me.m_prmintHorizontalReferenceDatumID
                    commandParameters(10) = Me.m_prmintSourceMapScaleNumber
                    commandParameters(11) = Me.m_prmintCoordinateVerificationMethodID
                    commandParameters(12) = Me.m_prmintCoordinateDataSourceID
                    commandParameters(13) = Me.m_prmdtHorizontalCollectionDate
                    commandParameters(14) = Me.m_prmintVerticalCollectionMethodID
                    commandParameters(15) = Me.m_prmintVerticalReferenceDatumID
                    commandParameters(16) = Me.m_prmdtVerticalCollectionDate
                    commandParameters(17) = Me.m_prmstrGeographicPointComment
                    commandParameters(18) = Me.m_prmdtAddDate
                    commandParameters(19) = Me.m_prmintAddedBy
                Case DMLType.Delete
                    commandParameters = New OleDbParameter(0) {}
                    commandParameters(0) = Me.m_prmintPointID
            End Select
            Return commandParameters

        End Function

        Private Sub SetFieldOrdinalValues(ByVal dr As OleDbDataReader)

            FieldOrdinal.PointID = dr.GetOrdinal(PointConstants.FieldName.PointID)
            FieldOrdinal.GeographicCoordinateTypeID = dr.GetOrdinal(PointConstants.FieldName.GeographicCoordinateTypeID)
            FieldOrdinal.CoordinateZone = dr.GetOrdinal(PointConstants.FieldName.CoordinateZone)
            FieldOrdinal.GeometricTypeID = dr.GetOrdinal(PointConstants.FieldName.GeometricTypeID)
            FieldOrdinal.XCoordinate = dr.GetOrdinal(PointConstants.FieldName.XCoordinate)
            FieldOrdinal.YCoordinate = dr.GetOrdinal(PointConstants.FieldName.YCoordinate)
            FieldOrdinal.Elevation = dr.GetOrdinal(PointConstants.FieldName.Elevation)
            FieldOrdinal.UnitOfMeasurementID = dr.GetOrdinal(PointConstants.FieldName.UnitOfMeasurementID)
            FieldOrdinal.HorizontalCollectionMethodID = dr.GetOrdinal(PointConstants.FieldName.HorizontalCollectionMethodID)
            FieldOrdinal.HorizontalReferenceDatumID = dr.GetOrdinal(PointConstants.FieldName.HorizontalReferenceDatumID)
            FieldOrdinal.SourceMapScaleNumber = dr.GetOrdinal(PointConstants.FieldName.SourceMapScaleNumber)
            FieldOrdinal.CoordinateVerificationMethodID = dr.GetOrdinal(PointConstants.FieldName.CoordinateVerificationMethodID)
            FieldOrdinal.CoordinateDataSourceID = dr.GetOrdinal(PointConstants.FieldName.CoordinateDataSourceID)
            FieldOrdinal.HorizontalCollectionDate = dr.GetOrdinal(PointConstants.FieldName.HorizontalCollectionDate)
            FieldOrdinal.VerticalCollectionMethodID = dr.GetOrdinal(PointConstants.FieldName.VerticalCollectionMethodID)
            FieldOrdinal.VerticalReferenceDatumID = dr.GetOrdinal(PointConstants.FieldName.VerticalReferenceDatumID)
            FieldOrdinal.VerticalCollectionDate = dr.GetOrdinal(PointConstants.FieldName.VerticalCollectionDate)
            FieldOrdinal.GeographicPointComment = dr.GetOrdinal(PointConstants.FieldName.GeographicPointComment)
            FieldOrdinal.AddDate = dr.GetOrdinal(PointConstants.FieldName.AddDate)
            FieldOrdinal.AddedBy = dr.GetOrdinal(PointConstants.FieldName.AddedBy)

        End Sub

#End Region '----- Helper Methods -----

#Region "----- Lookup Methods -----"

        Friend Function GetAll() As DataTable

            Return OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetAll)

        End Function

        Friend Function GetByPrimaryKey(ByVal intPointID As Int32) As Point

            Dim objPoint As Point = Nothing
            Dim cnGeography As OleDbConnection
            Dim drPoint As OleDbDataReader
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmintPointID As OleDbParameter = New OleDbParameter

            With prmintPointID
                .ParameterName = ParameterName.PointID
                .Direction = ParameterDirection.Input
                .Value = intPointID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintPointID

            cnGeography = New OleDbConnection(GlobalVariables.ConnectionString)
            cnGeography.Open()
            drPoint = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByPrimaryKey, commandParameters)
            If (drPoint.HasRows) Then
                objPoint = New Point
                Call SetFieldOrdinalValues(drPoint)
                drPoint.Read()
                With objPoint
                    If (Not IsDBNull(drPoint(FieldOrdinal.PointID))) Then
                        .PointID = drPoint(FieldOrdinal.PointID)
                    End If
                    If (Not IsDBNull(drPoint(FieldOrdinal.GeographicCoordinateTypeID))) Then
                        .GeographicCoordinateTypeID = drPoint(FieldOrdinal.GeographicCoordinateTypeID)
                    End If
                    If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateZone))) Then
                        .CoordinateZone = drPoint(FieldOrdinal.CoordinateZone)
                    End If
                    If (Not IsDBNull(drPoint(FieldOrdinal.GeometricTypeID))) Then
                        .GeometricTypeID = drPoint(FieldOrdinal.GeometricTypeID)
                    End If
                    If (Not IsDBNull(drPoint(FieldOrdinal.XCoordinate))) Then
                        .XCoordinate = drPoint(FieldOrdinal.XCoordinate)
                    End If
                    If (Not IsDBNull(drPoint(FieldOrdinal.YCoordinate))) Then
                        .YCoordinate = drPoint(FieldOrdinal.YCoordinate)
                    End If
                    If (Not IsDBNull(drPoint(FieldOrdinal.Elevation))) Then
                        .Elevation = drPoint(FieldOrdinal.Elevation)
                    End If
                    If (Not IsDBNull(drPoint(FieldOrdinal.UnitOfMeasurementID))) Then
                        .UnitOfMeasurementID = drPoint(FieldOrdinal.UnitOfMeasurementID)
                    End If
                    If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalCollectionMethodID))) Then
                        .HorizontalCollectionMethodID = drPoint(FieldOrdinal.HorizontalCollectionMethodID)
                    End If
                    If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalReferenceDatumID))) Then
                        .HorizontalReferenceDatumID = drPoint(FieldOrdinal.HorizontalReferenceDatumID)
                    End If
                    If (Not IsDBNull(drPoint(FieldOrdinal.SourceMapScaleNumber))) Then
                        .SourceMapScaleNumber = drPoint(FieldOrdinal.SourceMapScaleNumber)
                    End If
                    If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateVerificationMethodID))) Then
                        .CoordinateVerificationMethodID = drPoint(FieldOrdinal.CoordinateVerificationMethodID)
                    End If
                    If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateDataSourceID))) Then
                        .CoordinateDataSourceID = drPoint(FieldOrdinal.CoordinateDataSourceID)
                    End If
                    If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalCollectionDate))) Then
                        .HorizontalCollectionDate = drPoint(FieldOrdinal.HorizontalCollectionDate)
                    End If
                    If (Not IsDBNull(drPoint(FieldOrdinal.VerticalCollectionMethodID))) Then
                        .VerticalCollectionMethodID = drPoint(FieldOrdinal.VerticalCollectionMethodID)
                    End If
                    If (Not IsDBNull(drPoint(FieldOrdinal.VerticalReferenceDatumID))) Then
                        .VerticalReferenceDatumID = drPoint(FieldOrdinal.VerticalReferenceDatumID)
                    End If
                    If (Not IsDBNull(drPoint(FieldOrdinal.VerticalCollectionDate))) Then
                        .VerticalCollectionDate = drPoint(FieldOrdinal.VerticalCollectionDate)
                    End If
                    If (Not IsDBNull(drPoint(FieldOrdinal.GeographicPointComment))) Then
                        .GeographicPointComment = drPoint(FieldOrdinal.GeographicPointComment)
                    End If
                    If (Not IsDBNull(drPoint(FieldOrdinal.AddDate))) Then
                        .AddDate = drPoint(FieldOrdinal.AddDate)
                    End If
                    If (Not IsDBNull(drPoint(FieldOrdinal.AddedBy))) Then
                        .AddedBy = drPoint(FieldOrdinal.AddedBy)
                    End If
                End With
            End If
            drPoint.Close()
            cnGeography.Close()

            Return objPoint

        End Function

        Friend Function GetByCoordinateDataSourceID(ByVal intCoordinateDataSourceID As Int32) As DataTable

            Dim dtbPoint As DataTable
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmintCoordinateDataSourceID As OleDbParameter = New OleDbParameter

            With prmintCoordinateDataSourceID
                .ParameterName = ParameterName.CoordinateDataSourceID
                .Direction = ParameterDirection.Input
                .Value = intCoordinateDataSourceID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintCoordinateDataSourceID

            dtbPoint = OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetByCoordinateDataSourceID, commandParameters)

            Return dtbPoint

        End Function

        Friend Function GetByCoordinateDataSourceID_Collection(ByVal intCoordinateDataSourceID As Int32) As Points

            Dim cnGeography As OleDbConnection
            Dim objPoints As Points = New Points
            Dim objPoint As Point = New Point
            Dim drPoint As OleDbDataReader
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
            drPoint = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByCoordinateDataSourceID, commandParameters)
            If (drPoint.HasRows) Then
                Call SetFieldOrdinalValues(drPoint)
                While drPoint.Read()

                    objPoint = New Point
                    With objPoint
                        If (Not IsDBNull(drPoint(FieldOrdinal.PointID))) Then
                            .PointID = drPoint(FieldOrdinal.PointID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.GeographicCoordinateTypeID))) Then
                            .GeographicCoordinateTypeID = drPoint(FieldOrdinal.GeographicCoordinateTypeID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateZone))) Then
                            .CoordinateZone = drPoint(FieldOrdinal.CoordinateZone)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.GeometricTypeID))) Then
                            .GeometricTypeID = drPoint(FieldOrdinal.GeometricTypeID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.XCoordinate))) Then
                            .XCoordinate = drPoint(FieldOrdinal.XCoordinate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.YCoordinate))) Then
                            .YCoordinate = drPoint(FieldOrdinal.YCoordinate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.Elevation))) Then
                            .Elevation = drPoint(FieldOrdinal.Elevation)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.UnitOfMeasurementID))) Then
                            .UnitOfMeasurementID = drPoint(FieldOrdinal.UnitOfMeasurementID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalCollectionMethodID))) Then
                            .HorizontalCollectionMethodID = drPoint(FieldOrdinal.HorizontalCollectionMethodID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalReferenceDatumID))) Then
                            .HorizontalReferenceDatumID = drPoint(FieldOrdinal.HorizontalReferenceDatumID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.SourceMapScaleNumber))) Then
                            .SourceMapScaleNumber = drPoint(FieldOrdinal.SourceMapScaleNumber)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateVerificationMethodID))) Then
                            .CoordinateVerificationMethodID = drPoint(FieldOrdinal.CoordinateVerificationMethodID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateDataSourceID))) Then
                            .CoordinateDataSourceID = drPoint(FieldOrdinal.CoordinateDataSourceID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalCollectionDate))) Then
                            .HorizontalCollectionDate = drPoint(FieldOrdinal.HorizontalCollectionDate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.VerticalCollectionMethodID))) Then
                            .VerticalCollectionMethodID = drPoint(FieldOrdinal.VerticalCollectionMethodID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.VerticalReferenceDatumID))) Then
                            .VerticalReferenceDatumID = drPoint(FieldOrdinal.VerticalReferenceDatumID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.VerticalCollectionDate))) Then
                            .VerticalCollectionDate = drPoint(FieldOrdinal.VerticalCollectionDate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.GeographicPointComment))) Then
                            .GeographicPointComment = drPoint(FieldOrdinal.GeographicPointComment)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.AddDate))) Then
                            .AddDate = drPoint(FieldOrdinal.AddDate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.AddedBy))) Then
                            .AddedBy = drPoint(FieldOrdinal.AddedBy)
                        End If
                    End With
                    objPoints.Add(objPoint)
                    objPoint = Nothing
                End While
            End If
            drPoint.Close()
            cnGeography.Close()

            Return objPoints

        End Function

        Friend Function GetByCoordinateVerificationMethodID(ByVal intCoordinateVerificationMethodID As Int32) As DataTable

            Dim dtbPoint As DataTable
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmintCoordinateVerificationMethodID As OleDbParameter = New OleDbParameter

            With prmintCoordinateVerificationMethodID
                .ParameterName = ParameterName.CoordinateVerificationMethodID
                .Direction = ParameterDirection.Input
                .Value = intCoordinateVerificationMethodID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintCoordinateVerificationMethodID

            dtbPoint = OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetByCoordinateVerificationMethodID, commandParameters)

            Return dtbPoint

        End Function

        Friend Function GetByCoordinateVerificationMethodID_Collection(ByVal intCoordinateVerificationMethodID As Int32) As Points

            Dim cnGeography As OleDbConnection
            Dim objPoints As Points = New Points
            Dim objPoint As Point = New Point
            Dim drPoint As OleDbDataReader
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
            drPoint = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByCoordinateVerificationMethodID, commandParameters)
            If (drPoint.HasRows) Then
                Call SetFieldOrdinalValues(drPoint)
                While drPoint.Read()

                    objPoint = New Point
                    With objPoint
                        If (Not IsDBNull(drPoint(FieldOrdinal.PointID))) Then
                            .PointID = drPoint(FieldOrdinal.PointID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.GeographicCoordinateTypeID))) Then
                            .GeographicCoordinateTypeID = drPoint(FieldOrdinal.GeographicCoordinateTypeID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateZone))) Then
                            .CoordinateZone = drPoint(FieldOrdinal.CoordinateZone)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.GeometricTypeID))) Then
                            .GeometricTypeID = drPoint(FieldOrdinal.GeometricTypeID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.XCoordinate))) Then
                            .XCoordinate = drPoint(FieldOrdinal.XCoordinate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.YCoordinate))) Then
                            .YCoordinate = drPoint(FieldOrdinal.YCoordinate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.Elevation))) Then
                            .Elevation = drPoint(FieldOrdinal.Elevation)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.UnitOfMeasurementID))) Then
                            .UnitOfMeasurementID = drPoint(FieldOrdinal.UnitOfMeasurementID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalCollectionMethodID))) Then
                            .HorizontalCollectionMethodID = drPoint(FieldOrdinal.HorizontalCollectionMethodID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalReferenceDatumID))) Then
                            .HorizontalReferenceDatumID = drPoint(FieldOrdinal.HorizontalReferenceDatumID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.SourceMapScaleNumber))) Then
                            .SourceMapScaleNumber = drPoint(FieldOrdinal.SourceMapScaleNumber)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateVerificationMethodID))) Then
                            .CoordinateVerificationMethodID = drPoint(FieldOrdinal.CoordinateVerificationMethodID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateDataSourceID))) Then
                            .CoordinateDataSourceID = drPoint(FieldOrdinal.CoordinateDataSourceID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalCollectionDate))) Then
                            .HorizontalCollectionDate = drPoint(FieldOrdinal.HorizontalCollectionDate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.VerticalCollectionMethodID))) Then
                            .VerticalCollectionMethodID = drPoint(FieldOrdinal.VerticalCollectionMethodID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.VerticalReferenceDatumID))) Then
                            .VerticalReferenceDatumID = drPoint(FieldOrdinal.VerticalReferenceDatumID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.VerticalCollectionDate))) Then
                            .VerticalCollectionDate = drPoint(FieldOrdinal.VerticalCollectionDate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.GeographicPointComment))) Then
                            .GeographicPointComment = drPoint(FieldOrdinal.GeographicPointComment)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.AddDate))) Then
                            .AddDate = drPoint(FieldOrdinal.AddDate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.AddedBy))) Then
                            .AddedBy = drPoint(FieldOrdinal.AddedBy)
                        End If
                    End With
                    objPoints.Add(objPoint)
                    objPoint = Nothing
                End While
            End If
            drPoint.Close()
            cnGeography.Close()

            Return objPoints

        End Function

        Friend Function GetByGeographicCoordinateTypeID(ByVal intGeographicCoordinateTypeID As Int32) As DataTable

            Dim dtbPoint As DataTable
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmintGeographicCoordinateTypeID As OleDbParameter = New OleDbParameter

            With prmintGeographicCoordinateTypeID
                .ParameterName = ParameterName.GeographicCoordinateTypeID
                .Direction = ParameterDirection.Input
                .Value = intGeographicCoordinateTypeID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintGeographicCoordinateTypeID

            dtbPoint = OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetByGeographicCoordinateTypeID, commandParameters)

            Return dtbPoint

        End Function

        Friend Function GetByGeographicCoordinateTypeID_Collection(ByVal intGeographicCoordinateTypeID As Int32) As Points

            Dim cnGeography As OleDbConnection
            Dim objPoints As Points = New Points
            Dim objPoint As Point = New Point
            Dim drPoint As OleDbDataReader
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
            drPoint = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByGeographicCoordinateTypeID, commandParameters)
            If (drPoint.HasRows) Then
                Call SetFieldOrdinalValues(drPoint)
                While drPoint.Read()

                    objPoint = New Point
                    With objPoint
                        If (Not IsDBNull(drPoint(FieldOrdinal.PointID))) Then
                            .PointID = drPoint(FieldOrdinal.PointID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.GeographicCoordinateTypeID))) Then
                            .GeographicCoordinateTypeID = drPoint(FieldOrdinal.GeographicCoordinateTypeID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateZone))) Then
                            .CoordinateZone = drPoint(FieldOrdinal.CoordinateZone)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.GeometricTypeID))) Then
                            .GeometricTypeID = drPoint(FieldOrdinal.GeometricTypeID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.XCoordinate))) Then
                            .XCoordinate = drPoint(FieldOrdinal.XCoordinate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.YCoordinate))) Then
                            .YCoordinate = drPoint(FieldOrdinal.YCoordinate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.Elevation))) Then
                            .Elevation = drPoint(FieldOrdinal.Elevation)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.UnitOfMeasurementID))) Then
                            .UnitOfMeasurementID = drPoint(FieldOrdinal.UnitOfMeasurementID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalCollectionMethodID))) Then
                            .HorizontalCollectionMethodID = drPoint(FieldOrdinal.HorizontalCollectionMethodID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalReferenceDatumID))) Then
                            .HorizontalReferenceDatumID = drPoint(FieldOrdinal.HorizontalReferenceDatumID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.SourceMapScaleNumber))) Then
                            .SourceMapScaleNumber = drPoint(FieldOrdinal.SourceMapScaleNumber)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateVerificationMethodID))) Then
                            .CoordinateVerificationMethodID = drPoint(FieldOrdinal.CoordinateVerificationMethodID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateDataSourceID))) Then
                            .CoordinateDataSourceID = drPoint(FieldOrdinal.CoordinateDataSourceID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalCollectionDate))) Then
                            .HorizontalCollectionDate = drPoint(FieldOrdinal.HorizontalCollectionDate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.VerticalCollectionMethodID))) Then
                            .VerticalCollectionMethodID = drPoint(FieldOrdinal.VerticalCollectionMethodID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.VerticalReferenceDatumID))) Then
                            .VerticalReferenceDatumID = drPoint(FieldOrdinal.VerticalReferenceDatumID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.VerticalCollectionDate))) Then
                            .VerticalCollectionDate = drPoint(FieldOrdinal.VerticalCollectionDate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.GeographicPointComment))) Then
                            .GeographicPointComment = drPoint(FieldOrdinal.GeographicPointComment)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.AddDate))) Then
                            .AddDate = drPoint(FieldOrdinal.AddDate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.AddedBy))) Then
                            .AddedBy = drPoint(FieldOrdinal.AddedBy)
                        End If
                    End With
                    objPoints.Add(objPoint)
                    objPoint = Nothing
                End While
            End If
            drPoint.Close()
            cnGeography.Close()

            Return objPoints

        End Function

        Friend Function GetByHorizontalCollectionMethodID(ByVal intHorizontalCollectionMethodID As Int32) As DataTable

            Dim dtbPoint As DataTable
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmintHorizontalCollectionMethodID As OleDbParameter = New OleDbParameter

            With prmintHorizontalCollectionMethodID
                .ParameterName = ParameterName.HorizontalCollectionMethodID
                .Direction = ParameterDirection.Input
                .Value = intHorizontalCollectionMethodID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintHorizontalCollectionMethodID

            dtbPoint = OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetByHorizontalCollectionMethodID, commandParameters)

            Return dtbPoint

        End Function

        Friend Function GetByHorizontalCollectionMethodID_Collection(ByVal intHorizontalCollectionMethodID As Int32) As Points

            Dim cnGeography As OleDbConnection
            Dim objPoints As Points = New Points
            Dim objPoint As Point = New Point
            Dim drPoint As OleDbDataReader
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
            drPoint = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByHorizontalCollectionMethodID, commandParameters)
            If (drPoint.HasRows) Then
                Call SetFieldOrdinalValues(drPoint)
                While drPoint.Read()

                    objPoint = New Point
                    With objPoint
                        If (Not IsDBNull(drPoint(FieldOrdinal.PointID))) Then
                            .PointID = drPoint(FieldOrdinal.PointID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.GeographicCoordinateTypeID))) Then
                            .GeographicCoordinateTypeID = drPoint(FieldOrdinal.GeographicCoordinateTypeID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateZone))) Then
                            .CoordinateZone = drPoint(FieldOrdinal.CoordinateZone)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.GeometricTypeID))) Then
                            .GeometricTypeID = drPoint(FieldOrdinal.GeometricTypeID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.XCoordinate))) Then
                            .XCoordinate = drPoint(FieldOrdinal.XCoordinate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.YCoordinate))) Then
                            .YCoordinate = drPoint(FieldOrdinal.YCoordinate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.Elevation))) Then
                            .Elevation = drPoint(FieldOrdinal.Elevation)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.UnitOfMeasurementID))) Then
                            .UnitOfMeasurementID = drPoint(FieldOrdinal.UnitOfMeasurementID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalCollectionMethodID))) Then
                            .HorizontalCollectionMethodID = drPoint(FieldOrdinal.HorizontalCollectionMethodID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalReferenceDatumID))) Then
                            .HorizontalReferenceDatumID = drPoint(FieldOrdinal.HorizontalReferenceDatumID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.SourceMapScaleNumber))) Then
                            .SourceMapScaleNumber = drPoint(FieldOrdinal.SourceMapScaleNumber)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateVerificationMethodID))) Then
                            .CoordinateVerificationMethodID = drPoint(FieldOrdinal.CoordinateVerificationMethodID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateDataSourceID))) Then
                            .CoordinateDataSourceID = drPoint(FieldOrdinal.CoordinateDataSourceID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalCollectionDate))) Then
                            .HorizontalCollectionDate = drPoint(FieldOrdinal.HorizontalCollectionDate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.VerticalCollectionMethodID))) Then
                            .VerticalCollectionMethodID = drPoint(FieldOrdinal.VerticalCollectionMethodID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.VerticalReferenceDatumID))) Then
                            .VerticalReferenceDatumID = drPoint(FieldOrdinal.VerticalReferenceDatumID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.VerticalCollectionDate))) Then
                            .VerticalCollectionDate = drPoint(FieldOrdinal.VerticalCollectionDate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.GeographicPointComment))) Then
                            .GeographicPointComment = drPoint(FieldOrdinal.GeographicPointComment)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.AddDate))) Then
                            .AddDate = drPoint(FieldOrdinal.AddDate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.AddedBy))) Then
                            .AddedBy = drPoint(FieldOrdinal.AddedBy)
                        End If
                    End With
                    objPoints.Add(objPoint)
                    objPoint = Nothing
                End While
            End If
            drPoint.Close()
            cnGeography.Close()

            Return objPoints

        End Function

        Friend Function GetByHorizontalReferenceDatumID(ByVal intHorizontalReferenceDatumID As Int32) As DataTable

            Dim dtbPoint As DataTable
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmintHorizontalReferenceDatumID As OleDbParameter = New OleDbParameter

            With prmintHorizontalReferenceDatumID
                .ParameterName = ParameterName.HorizontalReferenceDatumID
                .Direction = ParameterDirection.Input
                .Value = intHorizontalReferenceDatumID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintHorizontalReferenceDatumID

            dtbPoint = OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetByHorizontalReferenceDatumID, commandParameters)

            Return dtbPoint

        End Function

        Friend Function GetByHorizontalReferenceDatumID_Collection(ByVal intHorizontalReferenceDatumID As Int32) As Points

            Dim cnGeography As OleDbConnection
            Dim objPoints As Points = New Points
            Dim objPoint As Point = New Point
            Dim drPoint As OleDbDataReader
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
            drPoint = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByHorizontalReferenceDatumID, commandParameters)
            If (drPoint.HasRows) Then
                Call SetFieldOrdinalValues(drPoint)
                While drPoint.Read()

                    objPoint = New Point
                    With objPoint
                        If (Not IsDBNull(drPoint(FieldOrdinal.PointID))) Then
                            .PointID = drPoint(FieldOrdinal.PointID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.GeographicCoordinateTypeID))) Then
                            .GeographicCoordinateTypeID = drPoint(FieldOrdinal.GeographicCoordinateTypeID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateZone))) Then
                            .CoordinateZone = drPoint(FieldOrdinal.CoordinateZone)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.GeometricTypeID))) Then
                            .GeometricTypeID = drPoint(FieldOrdinal.GeometricTypeID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.XCoordinate))) Then
                            .XCoordinate = drPoint(FieldOrdinal.XCoordinate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.YCoordinate))) Then
                            .YCoordinate = drPoint(FieldOrdinal.YCoordinate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.Elevation))) Then
                            .Elevation = drPoint(FieldOrdinal.Elevation)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.UnitOfMeasurementID))) Then
                            .UnitOfMeasurementID = drPoint(FieldOrdinal.UnitOfMeasurementID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalCollectionMethodID))) Then
                            .HorizontalCollectionMethodID = drPoint(FieldOrdinal.HorizontalCollectionMethodID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalReferenceDatumID))) Then
                            .HorizontalReferenceDatumID = drPoint(FieldOrdinal.HorizontalReferenceDatumID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.SourceMapScaleNumber))) Then
                            .SourceMapScaleNumber = drPoint(FieldOrdinal.SourceMapScaleNumber)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateVerificationMethodID))) Then
                            .CoordinateVerificationMethodID = drPoint(FieldOrdinal.CoordinateVerificationMethodID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateDataSourceID))) Then
                            .CoordinateDataSourceID = drPoint(FieldOrdinal.CoordinateDataSourceID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalCollectionDate))) Then
                            .HorizontalCollectionDate = drPoint(FieldOrdinal.HorizontalCollectionDate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.VerticalCollectionMethodID))) Then
                            .VerticalCollectionMethodID = drPoint(FieldOrdinal.VerticalCollectionMethodID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.VerticalReferenceDatumID))) Then
                            .VerticalReferenceDatumID = drPoint(FieldOrdinal.VerticalReferenceDatumID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.VerticalCollectionDate))) Then
                            .VerticalCollectionDate = drPoint(FieldOrdinal.VerticalCollectionDate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.GeographicPointComment))) Then
                            .GeographicPointComment = drPoint(FieldOrdinal.GeographicPointComment)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.AddDate))) Then
                            .AddDate = drPoint(FieldOrdinal.AddDate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.AddedBy))) Then
                            .AddedBy = drPoint(FieldOrdinal.AddedBy)
                        End If
                    End With
                    objPoints.Add(objPoint)
                    objPoint = Nothing
                End While
            End If
            drPoint.Close()
            cnGeography.Close()

            Return objPoints

        End Function

        Friend Function GetByVerticalCollectionMethodID(ByVal intVerticalCollectionMethodID As Int32) As DataTable

            Dim dtbPoint As DataTable
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmintVerticalCollectionMethodID As OleDbParameter = New OleDbParameter

            With prmintVerticalCollectionMethodID
                .ParameterName = ParameterName.VerticalCollectionMethodID
                .Direction = ParameterDirection.Input
                .Value = intVerticalCollectionMethodID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintVerticalCollectionMethodID

            dtbPoint = OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetByVerticalCollectionMethodID, commandParameters)

            Return dtbPoint

        End Function

        Friend Function GetByVerticalCollectionMethodID_Collection(ByVal intVerticalCollectionMethodID As Int32) As Points

            Dim cnGeography As OleDbConnection
            Dim objPoints As Points = New Points
            Dim objPoint As Point = New Point
            Dim drPoint As OleDbDataReader
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
            drPoint = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByVerticalCollectionMethodID, commandParameters)
            If (drPoint.HasRows) Then
                Call SetFieldOrdinalValues(drPoint)
                While drPoint.Read()

                    objPoint = New Point
                    With objPoint
                        If (Not IsDBNull(drPoint(FieldOrdinal.PointID))) Then
                            .PointID = drPoint(FieldOrdinal.PointID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.GeographicCoordinateTypeID))) Then
                            .GeographicCoordinateTypeID = drPoint(FieldOrdinal.GeographicCoordinateTypeID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateZone))) Then
                            .CoordinateZone = drPoint(FieldOrdinal.CoordinateZone)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.GeometricTypeID))) Then
                            .GeometricTypeID = drPoint(FieldOrdinal.GeometricTypeID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.XCoordinate))) Then
                            .XCoordinate = drPoint(FieldOrdinal.XCoordinate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.YCoordinate))) Then
                            .YCoordinate = drPoint(FieldOrdinal.YCoordinate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.Elevation))) Then
                            .Elevation = drPoint(FieldOrdinal.Elevation)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.UnitOfMeasurementID))) Then
                            .UnitOfMeasurementID = drPoint(FieldOrdinal.UnitOfMeasurementID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalCollectionMethodID))) Then
                            .HorizontalCollectionMethodID = drPoint(FieldOrdinal.HorizontalCollectionMethodID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalReferenceDatumID))) Then
                            .HorizontalReferenceDatumID = drPoint(FieldOrdinal.HorizontalReferenceDatumID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.SourceMapScaleNumber))) Then
                            .SourceMapScaleNumber = drPoint(FieldOrdinal.SourceMapScaleNumber)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateVerificationMethodID))) Then
                            .CoordinateVerificationMethodID = drPoint(FieldOrdinal.CoordinateVerificationMethodID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateDataSourceID))) Then
                            .CoordinateDataSourceID = drPoint(FieldOrdinal.CoordinateDataSourceID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalCollectionDate))) Then
                            .HorizontalCollectionDate = drPoint(FieldOrdinal.HorizontalCollectionDate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.VerticalCollectionMethodID))) Then
                            .VerticalCollectionMethodID = drPoint(FieldOrdinal.VerticalCollectionMethodID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.VerticalReferenceDatumID))) Then
                            .VerticalReferenceDatumID = drPoint(FieldOrdinal.VerticalReferenceDatumID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.VerticalCollectionDate))) Then
                            .VerticalCollectionDate = drPoint(FieldOrdinal.VerticalCollectionDate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.GeographicPointComment))) Then
                            .GeographicPointComment = drPoint(FieldOrdinal.GeographicPointComment)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.AddDate))) Then
                            .AddDate = drPoint(FieldOrdinal.AddDate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.AddedBy))) Then
                            .AddedBy = drPoint(FieldOrdinal.AddedBy)
                        End If
                    End With
                    objPoints.Add(objPoint)
                    objPoint = Nothing
                End While
            End If
            drPoint.Close()
            cnGeography.Close()

            Return objPoints

        End Function

        Friend Function GetByVerticalReferenceDatumID(ByVal intVerticalReferenceDatumID As Int32) As DataTable

            Dim dtbPoint As DataTable
            Dim commandParameters() As OleDbParameter = Nothing
            Dim prmintVerticalReferenceDatumID As OleDbParameter = New OleDbParameter

            With prmintVerticalReferenceDatumID
                .ParameterName = ParameterName.VerticalReferenceDatumID
                .Direction = ParameterDirection.Input
                .Value = intVerticalReferenceDatumID
            End With
            commandParameters = New OleDbParameter(0) {}
            commandParameters(0) = prmintVerticalReferenceDatumID

            dtbPoint = OleDbHelper.ExecuteDataTable(GlobalVariables.ConnectionString, StoredProcedure.GetByVerticalReferenceDatumID, commandParameters)

            Return dtbPoint

        End Function

        Friend Function GetByVerticalReferenceDatumID_Collection(ByVal intVerticalReferenceDatumID As Int32) As Points

            Dim cnGeography As OleDbConnection
            Dim objPoints As Points = New Points
            Dim objPoint As Point = New Point
            Dim drPoint As OleDbDataReader
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
            drPoint = OleDbHelper.ExecuteReader(cnGeography, StoredProcedure.GetByVerticalReferenceDatumID, commandParameters)
            If (drPoint.HasRows) Then
                Call SetFieldOrdinalValues(drPoint)
                While drPoint.Read()

                    objPoint = New Point
                    With objPoint
                        If (Not IsDBNull(drPoint(FieldOrdinal.PointID))) Then
                            .PointID = drPoint(FieldOrdinal.PointID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.GeographicCoordinateTypeID))) Then
                            .GeographicCoordinateTypeID = drPoint(FieldOrdinal.GeographicCoordinateTypeID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateZone))) Then
                            .CoordinateZone = drPoint(FieldOrdinal.CoordinateZone)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.GeometricTypeID))) Then
                            .GeometricTypeID = drPoint(FieldOrdinal.GeometricTypeID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.XCoordinate))) Then
                            .XCoordinate = drPoint(FieldOrdinal.XCoordinate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.YCoordinate))) Then
                            .YCoordinate = drPoint(FieldOrdinal.YCoordinate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.Elevation))) Then
                            .Elevation = drPoint(FieldOrdinal.Elevation)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.UnitOfMeasurementID))) Then
                            .UnitOfMeasurementID = drPoint(FieldOrdinal.UnitOfMeasurementID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalCollectionMethodID))) Then
                            .HorizontalCollectionMethodID = drPoint(FieldOrdinal.HorizontalCollectionMethodID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalReferenceDatumID))) Then
                            .HorizontalReferenceDatumID = drPoint(FieldOrdinal.HorizontalReferenceDatumID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.SourceMapScaleNumber))) Then
                            .SourceMapScaleNumber = drPoint(FieldOrdinal.SourceMapScaleNumber)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateVerificationMethodID))) Then
                            .CoordinateVerificationMethodID = drPoint(FieldOrdinal.CoordinateVerificationMethodID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.CoordinateDataSourceID))) Then
                            .CoordinateDataSourceID = drPoint(FieldOrdinal.CoordinateDataSourceID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.HorizontalCollectionDate))) Then
                            .HorizontalCollectionDate = drPoint(FieldOrdinal.HorizontalCollectionDate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.VerticalCollectionMethodID))) Then
                            .VerticalCollectionMethodID = drPoint(FieldOrdinal.VerticalCollectionMethodID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.VerticalReferenceDatumID))) Then
                            .VerticalReferenceDatumID = drPoint(FieldOrdinal.VerticalReferenceDatumID)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.VerticalCollectionDate))) Then
                            .VerticalCollectionDate = drPoint(FieldOrdinal.VerticalCollectionDate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.GeographicPointComment))) Then
                            .GeographicPointComment = drPoint(FieldOrdinal.GeographicPointComment)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.AddDate))) Then
                            .AddDate = drPoint(FieldOrdinal.AddDate)
                        End If
                        If (Not IsDBNull(drPoint(FieldOrdinal.AddedBy))) Then
                            .AddedBy = drPoint(FieldOrdinal.AddedBy)
                        End If
                    End With
                    objPoints.Add(objPoint)
                    objPoint = Nothing
                End While
            End If
            drPoint.Close()
            cnGeography.Close()

            Return objPoints

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
