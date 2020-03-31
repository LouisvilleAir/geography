'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: PointDetailUtility.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Utility class for the PointDetail table of the Geography database.
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

    <Serializable()> Public Class PointDetailUtility

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Lookup Methods -----"

        Public Shared Function GetAll() As DataTable

            Dim objPointDetailDB As PointDetailDB
            objPointDetailDB = New PointDetailDB
            Return objPointDetailDB.GetAll

        End Function

        Public Shared Function GetByPrimaryKey(ByVal intPointID As Int32, ByVal intPointDetailTypeID As Int32) As PointDetail

            Dim objPointDetailDB As PointDetailDB
            objPointDetailDB = New PointDetailDB
            Return objPointDetailDB.GetByPrimaryKey(intPointID, intPointDetailTypeID)

        End Function

        Public Shared Function GetByPointID(ByVal intPointID As Int32) As DataTable

            Dim objPointDetailDB As PointDetailDB
            objPointDetailDB = New PointDetailDB
            Return objPointDetailDB.GetByPointID(intPointID)

        End Function

        Public Shared Function GetByPointDetailTypeID(ByVal intPointDetailTypeID As Int32) As DataTable

            Dim objPointDetailDB As PointDetailDB
            objPointDetailDB = New PointDetailDB
            Return objPointDetailDB.GetByPointDetailTypeID(intPointDetailTypeID)

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
