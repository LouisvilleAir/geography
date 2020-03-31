'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: HorizontalReferenceDatumUtility.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Utility class for the HorizontalReferenceDatum table of the Geography database.
'             Provides shared methods for accesssing the database as well as other utility functions.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Geography.Business
Imports APCD.Geography.Collections
Imports APCD.Geography.Data

Namespace APCD.Geography.Utility

    <Serializable()> Public Class HorizontalReferenceDatumUtility

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Lookup Methods -----"

        Public Shared Function GetAll() As DataTable

            Dim objHorizontalReferenceDatumDB As HorizontalReferenceDatumDB
            objHorizontalReferenceDatumDB = New HorizontalReferenceDatumDB
            Return objHorizontalReferenceDatumDB.GetAll

        End Function

        Public Shared Function GetLookupTable() As DataTable

            Dim objHorizontalReferenceDatumDB As HorizontalReferenceDatumDB
            objHorizontalReferenceDatumDB = New HorizontalReferenceDatumDB
            Return objHorizontalReferenceDatumDB.GetLookupTable

        End Function

        Public Shared Function GetByLookupName(ByVal strHorizontalReferenceDatumName As String) As HorizontalReferenceDatum

            Dim objHorizontalReferenceDatumDB As HorizontalReferenceDatumDB
            objHorizontalReferenceDatumDB = New HorizontalReferenceDatumDB
            Return objHorizontalReferenceDatumDB.GetByLookupName(strHorizontalReferenceDatumName)

        End Function

        Public Shared Function GetByPrimaryKey(ByVal intHorizontalReferenceDatumID As Int32) As HorizontalReferenceDatum

            Dim objHorizontalReferenceDatumDB As HorizontalReferenceDatumDB
            objHorizontalReferenceDatumDB = New HorizontalReferenceDatumDB
            Return objHorizontalReferenceDatumDB.GetByPrimaryKey(intHorizontalReferenceDatumID)

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
