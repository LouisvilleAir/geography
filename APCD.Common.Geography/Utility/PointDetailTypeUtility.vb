'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: PointDetailTypeUtility.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Utility class for the PointDetailType table of the Geography database.
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

    <Serializable()> Public Class PointDetailTypeUtility

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Lookup Methods -----"

        Public Shared Function GetAll() As DataTable

            Dim objPointDetailTypeDB As PointDetailTypeDB
            objPointDetailTypeDB = New PointDetailTypeDB
            Return objPointDetailTypeDB.GetAll

        End Function

        Public Shared Function GetLookupTable() As DataTable

            Dim objPointDetailTypeDB As PointDetailTypeDB
            objPointDetailTypeDB = New PointDetailTypeDB
            Return objPointDetailTypeDB.GetLookupTable

        End Function

        Public Shared Function GetByLookupName(ByVal strPointDetailTypeName As String) As PointDetailType

            Dim objPointDetailTypeDB As PointDetailTypeDB
            objPointDetailTypeDB = New PointDetailTypeDB
            Return objPointDetailTypeDB.GetByLookupName(strPointDetailTypeName)

        End Function

        Public Shared Function GetByPrimaryKey(ByVal intPointDetailTypeID As Int32) As PointDetailType

            Dim objPointDetailTypeDB As PointDetailTypeDB
            objPointDetailTypeDB = New PointDetailTypeDB
            Return objPointDetailTypeDB.GetByPrimaryKey(intPointDetailTypeID)

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
