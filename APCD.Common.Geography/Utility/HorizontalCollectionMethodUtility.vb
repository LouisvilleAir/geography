'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: HorizontalCollectionMethodUtility.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Utility class for the HorizontalCollectionMethod table of the Geography database.
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

    <Serializable()> Public Class HorizontalCollectionMethodUtility

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Lookup Methods -----"

        Public Shared Function GetAll() As DataTable

            Dim objHorizontalCollectionMethodDB As HorizontalCollectionMethodDB
            objHorizontalCollectionMethodDB = New HorizontalCollectionMethodDB
            Return objHorizontalCollectionMethodDB.GetAll

        End Function

        Public Shared Function GetLookupTable() As DataTable

            Dim objHorizontalCollectionMethodDB As HorizontalCollectionMethodDB
            objHorizontalCollectionMethodDB = New HorizontalCollectionMethodDB
            Return objHorizontalCollectionMethodDB.GetLookupTable

        End Function

        Public Shared Function GetByLookupName(ByVal strHorizontalCollectionMethodName As String) As HorizontalCollectionMethod

            Dim objHorizontalCollectionMethodDB As HorizontalCollectionMethodDB
            objHorizontalCollectionMethodDB = New HorizontalCollectionMethodDB
            Return objHorizontalCollectionMethodDB.GetByLookupName(strHorizontalCollectionMethodName)

        End Function

        Public Shared Function GetByPrimaryKey(ByVal intHorizontalCollectionMethodID As Int32) As HorizontalCollectionMethod

            Dim objHorizontalCollectionMethodDB As HorizontalCollectionMethodDB
            objHorizontalCollectionMethodDB = New HorizontalCollectionMethodDB
            Return objHorizontalCollectionMethodDB.GetByPrimaryKey(intHorizontalCollectionMethodID)

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
