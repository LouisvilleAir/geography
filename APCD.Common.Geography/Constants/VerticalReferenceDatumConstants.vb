'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: VerticalReferenceDatumConstants.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Constants class for the VerticalReferenceDatum table of the Geography database.
'             Provides constants for working with the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Namespace APCD.Geography.Constants

    <Serializable()> Public Class VerticalReferenceDatumConstants

#Region "----- DatabaseFields -----"

        Public Structure FieldName
            Private _trash As String
            Public Const VerticalReferenceDatumID As String = "VerticalReferenceDatumID" 'primary key
            Public Const VerticalReferenceDatumName As String = "VerticalReferenceDatumName"
            Public Const DatumAbbreviation As String = "DatumAbbreviation"
        End Structure

#End Region '----- DatabaseFields -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
