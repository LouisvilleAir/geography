'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: CoordinateDataSourceUtility.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Utility class for the CoordinateDataSource table of the Geography database.
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

    <Serializable()> Public Class CoordinateDataSourceUtility

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Lookup Methods -----"

        Public Shared Function GetAll() As DataTable

            Dim objCoordinateDataSourceDB As CoordinateDataSourceDB
            objCoordinateDataSourceDB = New CoordinateDataSourceDB
            Return objCoordinateDataSourceDB.GetAll

        End Function

        Public Shared Function GetLookupTable() As DataTable

            Dim objCoordinateDataSourceDB As CoordinateDataSourceDB
            objCoordinateDataSourceDB = New CoordinateDataSourceDB
            Return objCoordinateDataSourceDB.GetLookupTable

        End Function

        Public Shared Function GetByLookupName(ByVal strCoordinateDataSourceName As String) As CoordinateDataSource

            Dim objCoordinateDataSourceDB As CoordinateDataSourceDB
            objCoordinateDataSourceDB = New CoordinateDataSourceDB
            Return objCoordinateDataSourceDB.GetByLookupName(strCoordinateDataSourceName)

        End Function

        Public Shared Function GetByPrimaryKey(ByVal intCoordinateDataSourceID As Int32) As CoordinateDataSource

            Dim objCoordinateDataSourceDB As CoordinateDataSourceDB
            objCoordinateDataSourceDB = New CoordinateDataSourceDB
            Return objCoordinateDataSourceDB.GetByPrimaryKey(intCoordinateDataSourceID)

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
