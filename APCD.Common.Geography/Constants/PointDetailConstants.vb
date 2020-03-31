'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: PointDetailConstants.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Constants class for the PointDetail table of the Geography database.
'             Provides constants for working with the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Namespace APCD.Geography.Constants

    <Serializable()> Public Class PointDetailConstants

#Region "----- DatabaseFields -----"

        Public Structure FieldName
            Private _trash As String
            Public Const PointID As String = "PointID" 'primary key
            Public Const PointDetailTypeID As String = "PointDetailTypeID" 'primary key
            Public Const PointDetailValue As String = "PointDetailValue"
            Public Const UnitOfMeasurementID As String = "UnitOfMeasurementID"
            Public Const AddDate As String = "AddDate"
            Public Const AddedBy As String = "AddedBy"
        End Structure

#End Region '----- DatabaseFields -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
