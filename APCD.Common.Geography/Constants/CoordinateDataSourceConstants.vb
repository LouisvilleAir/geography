'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: CoordinateDataSourceConstants.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Constants class for the CoordinateDataSource table of the Geography database.
'             Provides constants for working with the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Namespace APCD.Geography.Constants

    <Serializable()> Public Class CoordinateDataSourceConstants

#Region "----- DatabaseFields -----"

        Public Structure FieldName
            Private _trash As String
            Public Const CoordinateDataSourceID As String = "CoordinateDataSourceID" 'primary key
            Public Const CoordinateDataSourceName As String = "CoordinateDataSourceName"
            Public Const CoordinateDataSourceEISCode As String = "CoordinateDataSourceEISCode"
        End Structure

#End Region '----- DatabaseFields -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
