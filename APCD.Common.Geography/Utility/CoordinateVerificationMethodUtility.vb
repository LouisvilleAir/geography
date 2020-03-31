'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: CoordinateVerificationMethodUtility.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Utility class for the CoordinateVerificationMethod table of the Geography database.
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

    <Serializable()> Public Class CoordinateVerificationMethodUtility

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Lookup Methods -----"

        Public Shared Function GetAll() As DataTable

            Dim objCoordinateVerificationMethodDB As CoordinateVerificationMethodDB
            objCoordinateVerificationMethodDB = New CoordinateVerificationMethodDB
            Return objCoordinateVerificationMethodDB.GetAll

        End Function

        Public Shared Function GetLookupTable() As DataTable

            Dim objCoordinateVerificationMethodDB As CoordinateVerificationMethodDB
            objCoordinateVerificationMethodDB = New CoordinateVerificationMethodDB
            Return objCoordinateVerificationMethodDB.GetLookupTable

        End Function

        Public Shared Function GetByLookupName(ByVal strCoordinateVerificationMethodName As String) As CoordinateVerificationMethod

            Dim objCoordinateVerificationMethodDB As CoordinateVerificationMethodDB
            objCoordinateVerificationMethodDB = New CoordinateVerificationMethodDB
            Return objCoordinateVerificationMethodDB.GetByLookupName(strCoordinateVerificationMethodName)

        End Function

        Public Shared Function GetByPrimaryKey(ByVal intCoordinateVerificationMethodID As Int32) As CoordinateVerificationMethod

            Dim objCoordinateVerificationMethodDB As CoordinateVerificationMethodDB
            objCoordinateVerificationMethodDB = New CoordinateVerificationMethodDB
            Return objCoordinateVerificationMethodDB.GetByPrimaryKey(intCoordinateVerificationMethodID)

        End Function

#End Region '----- Lookup Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
