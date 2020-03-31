'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: PointConstants.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Constants class for the Point table of the Geography database.
'             Provides constants for working with the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Namespace APCD.Geography.Constants

    <Serializable()> Public Class PointConstants

#Region "----- DatabaseFields -----"

        Public Structure FieldName
            Private _trash As String
            Public Const PointID As String = "PointID" 'primary key
            Public Const GeographicCoordinateTypeID As String = "GeographicCoordinateTypeID"
            Public Const CoordinateZone As String = "CoordinateZone"
            Public Const GeometricTypeID As String = "GeometricTypeID"
            Public Const XCoordinate As String = "XCoordinate"
            Public Const YCoordinate As String = "YCoordinate"
            Public Const Elevation As String = "Elevation"
            Public Const UnitOfMeasurementID As String = "UnitOfMeasurementID"
            Public Const HorizontalCollectionMethodID As String = "HorizontalCollectionMethodID"
            Public Const HorizontalReferenceDatumID As String = "HorizontalReferenceDatumID"
            Public Const SourceMapScaleNumber As String = "SourceMapScaleNumber"
            Public Const CoordinateVerificationMethodID As String = "CoordinateVerificationMethodID"
            Public Const CoordinateDataSourceID As String = "CoordinateDataSourceID"
            Public Const HorizontalCollectionDate As String = "HorizontalCollectionDate"
            Public Const VerticalCollectionMethodID As String = "VerticalCollectionMethodID"
            Public Const VerticalReferenceDatumID As String = "VerticalReferenceDatumID"
            Public Const VerticalCollectionDate As String = "VerticalCollectionDate"
            Public Const GeographicPointComment As String = "GeographicPointComment"
            Public Const AddDate As String = "AddDate"
            Public Const AddedBy As String = "AddedBy"
        End Structure

#End Region '----- DatabaseFields -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
