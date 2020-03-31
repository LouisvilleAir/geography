'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: PointUtility.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Utility class for the Point table of the Geography database.
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

    <Serializable()> Public Class PointUtility

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Lookup Methods -----"

        Public Shared Function GetAll() As DataTable

            Dim objPointDB As PointDB
            objPointDB = New PointDB
            Return objPointDB.GetAll

        End Function

        Public Shared Function GetByPrimaryKey(ByVal intPointID As Int32) As Point

            Dim objPointDB As PointDB
            objPointDB = New PointDB
            Return objPointDB.GetByPrimaryKey(intPointID)

        End Function

        Public Shared Function GetByCoordinateDataSourceID(ByVal intCoordinateDataSourceID As Int32) As DataTable

            Dim objPointDB As PointDB
            objPointDB = New PointDB
            Return objPointDB.GetByCoordinateDataSourceID(intCoordinateDataSourceID)

        End Function

        Public Shared Function GetByCoordinateDataSourceID_Collection(ByVal intCoordinateDataSourceID As Int32) As Points

            Dim objPointDB As PointDB
            objPointDB = New PointDB
            Return objPointDB.GetByCoordinateDataSourceID_Collection(intCoordinateDataSourceID)

        End Function

        Public Shared Function GetByCoordinateVerificationMethodID(ByVal intCoordinateVerificationMethodID As Int32) As DataTable

            Dim objPointDB As PointDB
            objPointDB = New PointDB
            Return objPointDB.GetByCoordinateVerificationMethodID(intCoordinateVerificationMethodID)

        End Function

        Public Shared Function GetByCoordinateVerificationMethodID_Collection(ByVal intCoordinateVerificationMethodID As Int32) As Points

            Dim objPointDB As PointDB
            objPointDB = New PointDB
            Return objPointDB.GetByCoordinateVerificationMethodID_Collection(intCoordinateVerificationMethodID)

        End Function

        Public Shared Function GetByGeographicCoordinateTypeID(ByVal intGeographicCoordinateTypeID As Int32) As DataTable

            Dim objPointDB As PointDB
            objPointDB = New PointDB
            Return objPointDB.GetByGeographicCoordinateTypeID(intGeographicCoordinateTypeID)

        End Function

        Public Shared Function GetByGeographicCoordinateTypeID_Collection(ByVal intGeographicCoordinateTypeID As Int32) As Points

            Dim objPointDB As PointDB
            objPointDB = New PointDB
            Return objPointDB.GetByGeographicCoordinateTypeID_Collection(intGeographicCoordinateTypeID)

        End Function

        Public Shared Function GetByHorizontalCollectionMethodID(ByVal intHorizontalCollectionMethodID As Int32) As DataTable

            Dim objPointDB As PointDB
            objPointDB = New PointDB
            Return objPointDB.GetByHorizontalCollectionMethodID(intHorizontalCollectionMethodID)

        End Function

        Public Shared Function GetByHorizontalCollectionMethodID_Collection(ByVal intHorizontalCollectionMethodID As Int32) As Points

            Dim objPointDB As PointDB
            objPointDB = New PointDB
            Return objPointDB.GetByHorizontalCollectionMethodID_Collection(intHorizontalCollectionMethodID)

        End Function

        Public Shared Function GetByHorizontalReferenceDatumID(ByVal intHorizontalReferenceDatumID As Int32) As DataTable

            Dim objPointDB As PointDB
            objPointDB = New PointDB
            Return objPointDB.GetByHorizontalReferenceDatumID(intHorizontalReferenceDatumID)

        End Function

        Public Shared Function GetByHorizontalReferenceDatumID_Collection(ByVal intHorizontalReferenceDatumID As Int32) As Points

            Dim objPointDB As PointDB
            objPointDB = New PointDB
            Return objPointDB.GetByHorizontalReferenceDatumID_Collection(intHorizontalReferenceDatumID)

        End Function

        Public Shared Function GetByVerticalCollectionMethodID(ByVal intVerticalCollectionMethodID As Int32) As DataTable

            Dim objPointDB As PointDB
            objPointDB = New PointDB
            Return objPointDB.GetByVerticalCollectionMethodID(intVerticalCollectionMethodID)

        End Function

        Public Shared Function GetByVerticalCollectionMethodID_Collection(ByVal intVerticalCollectionMethodID As Int32) As Points

            Dim objPointDB As PointDB
            objPointDB = New PointDB
            Return objPointDB.GetByVerticalCollectionMethodID_Collection(intVerticalCollectionMethodID)

        End Function

        Public Shared Function GetByVerticalReferenceDatumID(ByVal intVerticalReferenceDatumID As Int32) As DataTable

            Dim objPointDB As PointDB
            objPointDB = New PointDB
            Return objPointDB.GetByVerticalReferenceDatumID(intVerticalReferenceDatumID)

        End Function

        Public Shared Function GetByVerticalReferenceDatumID_Collection(ByVal intVerticalReferenceDatumID As Int32) As Points

            Dim objPointDB As PointDB
            objPointDB = New PointDB
            Return objPointDB.GetByVerticalReferenceDatumID_Collection(intVerticalReferenceDatumID)

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
