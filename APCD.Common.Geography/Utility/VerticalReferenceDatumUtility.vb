'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: VerticalReferenceDatumUtility.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Utility class for the VerticalReferenceDatum table of the Geography database.
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

    <Serializable()> Public Class VerticalReferenceDatumUtility

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Lookup Methods -----"

        Public Shared Function GetAll() As DataTable

            Dim objVerticalReferenceDatumDB As VerticalReferenceDatumDB
            objVerticalReferenceDatumDB = New VerticalReferenceDatumDB
            Return objVerticalReferenceDatumDB.GetAll

        End Function

        Public Shared Function GetLookupTable() As DataTable

            Dim objVerticalReferenceDatumDB As VerticalReferenceDatumDB
            objVerticalReferenceDatumDB = New VerticalReferenceDatumDB
            Return objVerticalReferenceDatumDB.GetLookupTable

        End Function

        Public Shared Function GetByLookupName(ByVal strVerticalReferenceDatumName As String) As VerticalReferenceDatum

            Dim objVerticalReferenceDatumDB As VerticalReferenceDatumDB
            objVerticalReferenceDatumDB = New VerticalReferenceDatumDB
            Return objVerticalReferenceDatumDB.GetByLookupName(strVerticalReferenceDatumName)

        End Function

        Public Shared Function GetByPrimaryKey(ByVal intVerticalReferenceDatumID As Int32) As VerticalReferenceDatum

            Dim objVerticalReferenceDatumDB As VerticalReferenceDatumDB
            objVerticalReferenceDatumDB = New VerticalReferenceDatumDB
            Return objVerticalReferenceDatumDB.GetByPrimaryKey(intVerticalReferenceDatumID)

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
