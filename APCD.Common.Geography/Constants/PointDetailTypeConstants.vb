'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: PointDetailTypeConstants.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Constants class for the PointDetailType table of the Geography database.
'             Provides constants for working with the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Namespace APCD.Geography.Constants

    <Serializable()> Public Class PointDetailTypeConstants

#Region "----- DatabaseFields -----"

        Public Structure FieldName
            Private _trash As String
            Public Const PointDetailTypeID As String = "PointDetailTypeID" 'primary key
            Public Const PointDetailTypeName As String = "PointDetailTypeName"
        End Structure

#End Region '----- DatabaseFields -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
