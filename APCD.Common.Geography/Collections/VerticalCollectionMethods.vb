'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: VerticalCollectionMethods.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Custom collection class for the VerticalCollectionMethod business object.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Geography.Business

Namespace APCD.Geography.Collections

    <Serializable()> Public Class VerticalCollectionMethods
        Inherits CollectionBase

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        Private m_htblVerticalCollectionMethod As Hashtable = New Hashtable

#End Region '----- Member Variables -----

#Region "----- Helper Methods -----"

        Public Sub Add(ByVal objVerticalCollectionMethod As VerticalCollectionMethod)

            Dim intHashCode As Int32

            Try
                intHashCode = objVerticalCollectionMethod.GetHashCode()
                Me.m_htblVerticalCollectionMethod.Add(intHashCode, objVerticalCollectionMethod)
                Me.InnerList.Add(objVerticalCollectionMethod)
            Catch ex As ArgumentException
                'thrown when a dupe is entered into the hashtble, ignore it
            End Try

        End Sub

        Public Sub Remove(ByVal objVerticalCollectionMethod As VerticalCollectionMethod)

            Dim intHashCode As Int32

            intHashCode = objVerticalCollectionMethod.GetHashCode()
            If (Me.m_htblVerticalCollectionMethod.Contains(intHashCode)) Then
                Me.m_htblVerticalCollectionMethod.Remove(intHashCode)
            End If

        End Sub

        Default Public ReadOnly Property Item(ByVal intIndex As Int32) As VerticalCollectionMethod

            Get
                Return CType(Me.InnerList(intIndex), VerticalCollectionMethod)
            End Get

        End Property

        Default Public ReadOnly Property Item(ByVal hashCode As Object) As VerticalCollectionMethod

            Get
                Return CType(Me.m_htblVerticalCollectionMethod.Item(hashCode), VerticalCollectionMethod)
            End Get

        End Property

        Public Function Contains(ByVal objVerticalCollectionMethod As VerticalCollectionMethod) As Boolean

            Dim intHashCode As Int32

            intHashCode = objVerticalCollectionMethod.GetHashCode()
            Return Me.m_htblVerticalCollectionMethod.Contains(intHashCode)

        End Function

#End Region '----- Helper Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
