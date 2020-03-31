'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: PointDetailTypes.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Custom collection class for the PointDetailType business object.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Geography.Business

Namespace APCD.Geography.Collections

    <Serializable()> Public Class PointDetailTypes
        Inherits CollectionBase

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        Private m_htblPointDetailType As Hashtable = New Hashtable

#End Region '----- Member Variables -----

#Region "----- Helper Methods -----"

        Public Sub Add(ByVal objPointDetailType As PointDetailType)

            Dim intHashCode As Int32

            Try
                intHashCode = objPointDetailType.GetHashCode()
                Me.m_htblPointDetailType.Add(intHashCode, objPointDetailType)
                Me.InnerList.Add(objPointDetailType)
            Catch ex As ArgumentException
                'thrown when a dupe is entered into the hashtble, ignore it
            End Try

        End Sub

        Public Sub Remove(ByVal objPointDetailType As PointDetailType)

            Dim intHashCode As Int32

            intHashCode = objPointDetailType.GetHashCode()
            If (Me.m_htblPointDetailType.Contains(intHashCode)) Then
                Me.m_htblPointDetailType.Remove(intHashCode)
            End If

        End Sub

        Default Public ReadOnly Property Item(ByVal intIndex As Int32) As PointDetailType

            Get
                Return CType(Me.InnerList(intIndex), PointDetailType)
            End Get

        End Property

        Default Public ReadOnly Property Item(ByVal hashCode As Object) As PointDetailType

            Get
                Return CType(Me.m_htblPointDetailType.Item(hashCode), PointDetailType)
            End Get

        End Property

        Public Function Contains(ByVal objPointDetailType As PointDetailType) As Boolean

            Dim intHashCode As Int32

            intHashCode = objPointDetailType.GetHashCode()
            Return Me.m_htblPointDetailType.Contains(intHashCode)

        End Function

#End Region '----- Helper Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
