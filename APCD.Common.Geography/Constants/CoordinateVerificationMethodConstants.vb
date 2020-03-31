'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: CoordinateVerificationMethodConstants.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Constants class for the CoordinateVerificationMethod table of the Geography database.
'             Provides constants for working with the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Namespace APCD.Geography.Constants

    <Serializable()> Public Class CoordinateVerificationMethodConstants

#Region "----- DatabaseFields -----"

        Public Structure FieldName
            Private _trash As String
            Public Const CoordinateVerificationMethodID As String = "CoordinateVerificationMethodID" 'primary key
            Public Const CoordinateVerificationMethodName As String = "CoordinateVerificationMethodName"
            Public Const CoordinateVerificationMethodDescription As String = "CoordinateVerificationMethodDescription"
        End Structure

#End Region '----- DatabaseFields -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
