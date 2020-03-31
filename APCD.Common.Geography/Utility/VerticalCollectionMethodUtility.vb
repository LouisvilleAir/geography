'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: VerticalCollectionMethodUtility.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Utility class for the VerticalCollectionMethod table of the Geography database.
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

    <Serializable()> Public Class VerticalCollectionMethodUtility

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Lookup Methods -----"

        Public Shared Function GetAll() As DataTable

            Dim objVerticalCollectionMethodDB As VerticalCollectionMethodDB
            objVerticalCollectionMethodDB = New VerticalCollectionMethodDB
            Return objVerticalCollectionMethodDB.GetAll

        End Function

        Public Shared Function GetLookupTable() As DataTable

            Dim objVerticalCollectionMethodDB As VerticalCollectionMethodDB
            objVerticalCollectionMethodDB = New VerticalCollectionMethodDB
            Return objVerticalCollectionMethodDB.GetLookupTable

        End Function

        Public Shared Function GetByLookupName(ByVal strVerticalCollectionMethodName As String) As VerticalCollectionMethod

            Dim objVerticalCollectionMethodDB As VerticalCollectionMethodDB
            objVerticalCollectionMethodDB = New VerticalCollectionMethodDB
            Return objVerticalCollectionMethodDB.GetByLookupName(strVerticalCollectionMethodName)

        End Function

        Public Shared Function GetByPrimaryKey(ByVal intVerticalCollectionMethodID As Int32) As VerticalCollectionMethod

            Dim objVerticalCollectionMethodDB As VerticalCollectionMethodDB
            objVerticalCollectionMethodDB = New VerticalCollectionMethodDB
            Return objVerticalCollectionMethodDB.GetByPrimaryKey(intVerticalCollectionMethodID)

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
