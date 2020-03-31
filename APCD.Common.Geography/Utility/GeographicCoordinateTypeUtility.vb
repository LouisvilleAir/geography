'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: GeographicCoordinateTypeUtility.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Utility class for the GeographicCoordinateType table of the Geography database.
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

    <Serializable()> Public Class GeographicCoordinateTypeUtility

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Lookup Methods -----"

        Public Shared Function GetAll() As DataTable

            Dim objGeographicCoordinateTypeDB As GeographicCoordinateTypeDB
            objGeographicCoordinateTypeDB = New GeographicCoordinateTypeDB
            Return objGeographicCoordinateTypeDB.GetAll

        End Function

        Public Shared Function GetLookupTable() As DataTable

            Dim objGeographicCoordinateTypeDB As GeographicCoordinateTypeDB
            objGeographicCoordinateTypeDB = New GeographicCoordinateTypeDB
            Return objGeographicCoordinateTypeDB.GetLookupTable

        End Function

        Public Shared Function GetByLookupName(ByVal strGeographicCoordinateTypeName As String) As GeographicCoordinateType

            Dim objGeographicCoordinateTypeDB As GeographicCoordinateTypeDB
            objGeographicCoordinateTypeDB = New GeographicCoordinateTypeDB
            Return objGeographicCoordinateTypeDB.GetByLookupName(strGeographicCoordinateTypeName)

        End Function

        Public Shared Function GetByPrimaryKey(ByVal intGeographicCoordinateTypeID As Int32) As GeographicCoordinateType

            Dim objGeographicCoordinateTypeDB As GeographicCoordinateTypeDB
            objGeographicCoordinateTypeDB = New GeographicCoordinateTypeDB
            Return objGeographicCoordinateTypeDB.GetByPrimaryKey(intGeographicCoordinateTypeID)

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
