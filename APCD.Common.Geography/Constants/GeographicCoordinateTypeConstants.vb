'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: GeographicCoordinateTypeConstants.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Constants class for the GeographicCoordinateType table of the Geography database.
'             Provides constants for working with the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Namespace APCD.Geography.Constants

    <Serializable()> Public Class GeographicCoordinateTypeConstants

#Region "----- DatabaseFields -----"

        Public Structure FieldName
            Private _trash As String
            Public Const GeographicCoordinateTypeID As String = "GeographicCoordinateTypeID" 'primary key
            Public Const GeographicCoordinateTypeName As String = "GeographicCoordinateTypeName"
            Public Const Comment As String = "Comment"
        End Structure

#End Region '----- DatabaseFields -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
