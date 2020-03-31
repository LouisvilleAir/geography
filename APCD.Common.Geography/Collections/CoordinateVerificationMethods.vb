'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: CoordinateVerificationMethods.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Custom collection class for the CoordinateVerificationMethod business object.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Geography.Business

Namespace APCD.Geography.Collections

    <Serializable()> Public Class CoordinateVerificationMethods
        Inherits CollectionBase

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        Private m_htblCoordinateVerificationMethod As Hashtable = New Hashtable

#End Region '----- Member Variables -----

#Region "----- Helper Methods -----"

        Public Sub Add(ByVal objCoordinateVerificationMethod As CoordinateVerificationMethod)

            Dim intHashCode As Int32

            Try
                intHashCode = objCoordinateVerificationMethod.GetHashCode()
                Me.m_htblCoordinateVerificationMethod.Add(intHashCode, objCoordinateVerificationMethod)
                Me.InnerList.Add(objCoordinateVerificationMethod)
            Catch ex As ArgumentException
                'thrown when a dupe is entered into the hashtble, ignore it
            End Try

        End Sub

        Public Sub Remove(ByVal objCoordinateVerificationMethod As CoordinateVerificationMethod)

            Dim intHashCode As Int32

            intHashCode = objCoordinateVerificationMethod.GetHashCode()
            If (Me.m_htblCoordinateVerificationMethod.Contains(intHashCode)) Then
                Me.m_htblCoordinateVerificationMethod.Remove(intHashCode)
            End If

        End Sub

        Default Public ReadOnly Property Item(ByVal intIndex As Int32) As CoordinateVerificationMethod

            Get
                Return CType(Me.InnerList(intIndex), CoordinateVerificationMethod)
            End Get

        End Property

        Default Public ReadOnly Property Item(ByVal hashCode As Object) As CoordinateVerificationMethod

            Get
                Return CType(Me.m_htblCoordinateVerificationMethod.Item(hashCode), CoordinateVerificationMethod)
            End Get

        End Property

        Public Function Contains(ByVal objCoordinateVerificationMethod As CoordinateVerificationMethod) As Boolean

            Dim intHashCode As Int32

            intHashCode = objCoordinateVerificationMethod.GetHashCode()
            Return Me.m_htblCoordinateVerificationMethod.Contains(intHashCode)

        End Function

#End Region '----- Helper Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
