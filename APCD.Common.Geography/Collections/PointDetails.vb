'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: PointDetails.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Custom collection class for the PointDetail business object.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Geography.Business

Namespace APCD.Geography.Collections

    <Serializable()> Public Class PointDetails
        Inherits CollectionBase

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        Private m_htblPointDetail As Hashtable = New Hashtable

#End Region '----- Member Variables -----

#Region "----- Helper Methods -----"

        Public Sub Add(ByVal objPointDetail As PointDetail)

            Dim intHashCode As Int32

            Try
                intHashCode = objPointDetail.GetHashCode()
                Me.m_htblPointDetail.Add(intHashCode, objPointDetail)
                Me.InnerList.Add(objPointDetail)
            Catch ex As ArgumentException
                'thrown when a dupe is entered into the hashtble, ignore it
            End Try

        End Sub

        Public Sub Remove(ByVal objPointDetail As PointDetail)

            Dim intHashCode As Int32

            intHashCode = objPointDetail.GetHashCode()
            If (Me.m_htblPointDetail.Contains(intHashCode)) Then
                Me.m_htblPointDetail.Remove(intHashCode)
            End If

        End Sub

        Default Public ReadOnly Property Item(ByVal intIndex As Int32) As PointDetail

            Get
                Return CType(Me.InnerList(intIndex), PointDetail)
            End Get

        End Property

        Default Public ReadOnly Property Item(ByVal hashCode As Object) As PointDetail

            Get
                Return CType(Me.m_htblPointDetail.Item(hashCode), PointDetail)
            End Get

        End Property

        Public Function Contains(ByVal objPointDetail As PointDetail) As Boolean

            Dim intHashCode As Int32

            intHashCode = objPointDetail.GetHashCode()
            Return Me.m_htblPointDetail.Contains(intHashCode)

        End Function

#End Region '----- Helper Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
