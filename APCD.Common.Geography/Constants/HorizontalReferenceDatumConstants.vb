'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: HorizontalReferenceDatumConstants.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Constants class for the HorizontalReferenceDatum table of the Geography database.
'             Provides constants for working with the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Namespace APCD.Geography.Constants

    <Serializable()> Public Class HorizontalReferenceDatumConstants

#Region "----- DatabaseFields -----"

        Public Structure FieldName
            Private _trash As String
            Public Const HorizontalReferenceDatumID As String = "HorizontalReferenceDatumID" 'primary key
            Public Const HorizontalReferenceDatumName As String = "HorizontalReferenceDatumName"
            Public Const DatumAbbreviation As String = "DatumAbbreviation"
            Public Const DatumEPACode As String = "DatumEPACode"
            Public Const Comment As String = "Comment"
        End Structure

#End Region '----- DatabaseFields -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
