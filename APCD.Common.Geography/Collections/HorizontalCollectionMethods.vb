'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: HorizontalCollectionMethods.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Custom collection class for the HorizontalCollectionMethod business object.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Geography.Business

Namespace APCD.Geography.Collections

    <Serializable()> Public Class HorizontalCollectionMethods
        Inherits CollectionBase

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        Private m_htblHorizontalCollectionMethod As Hashtable = New Hashtable

#End Region '----- Member Variables -----

#Region "----- Helper Methods -----"

        Public Sub Add(ByVal objHorizontalCollectionMethod As HorizontalCollectionMethod)

            Dim intHashCode As Int32

            Try
                intHashCode = objHorizontalCollectionMethod.GetHashCode()
                Me.m_htblHorizontalCollectionMethod.Add(intHashCode, objHorizontalCollectionMethod)
                Me.InnerList.Add(objHorizontalCollectionMethod)
            Catch ex As ArgumentException
                'thrown when a dupe is entered into the hashtble, ignore it
            End Try

        End Sub

        Public Sub Remove(ByVal objHorizontalCollectionMethod As HorizontalCollectionMethod)

            Dim intHashCode As Int32

            intHashCode = objHorizontalCollectionMethod.GetHashCode()
            If (Me.m_htblHorizontalCollectionMethod.Contains(intHashCode)) Then
                Me.m_htblHorizontalCollectionMethod.Remove(intHashCode)
            End If

        End Sub

        Default Public ReadOnly Property Item(ByVal intIndex As Int32) As HorizontalCollectionMethod

            Get
                Return CType(Me.InnerList(intIndex), HorizontalCollectionMethod)
            End Get

        End Property

        Default Public ReadOnly Property Item(ByVal hashCode As Object) As HorizontalCollectionMethod

            Get
                Return CType(Me.m_htblHorizontalCollectionMethod.Item(hashCode), HorizontalCollectionMethod)
            End Get

        End Property

        Public Function Contains(ByVal objHorizontalCollectionMethod As HorizontalCollectionMethod) As Boolean

            Dim intHashCode As Int32

            intHashCode = objHorizontalCollectionMethod.GetHashCode()
            Return Me.m_htblHorizontalCollectionMethod.Contains(intHashCode)

        End Function

#End Region '----- Helper Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
