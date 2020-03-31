'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: VerticalCollectionMethodConstants.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Constants class for the VerticalCollectionMethod table of the Geography database.
'             Provides constants for working with the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Namespace APCD.Geography.Constants

    <Serializable()> Public Class VerticalCollectionMethodConstants

#Region "----- DatabaseFields -----"

        Public Structure FieldName
            Private _trash As String
            Public Const VerticalCollectionMethodID As String = "VerticalCollectionMethodID" 'primary key
            Public Const VerticalCollectionMethodName As String = "VerticalCollectionMethodName"
            Public Const VerticalCollectionMethodDescription As String = "VerticalCollectionMethodDescription"
        End Structure

#End Region '----- DatabaseFields -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
