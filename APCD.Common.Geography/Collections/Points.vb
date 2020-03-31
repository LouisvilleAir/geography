'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: Points.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Custom collection class for the Point business object.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Geography.Business

Namespace APCD.Geography.Collections

    <Serializable()> Public Class Points
        Inherits CollectionBase

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        Private m_htblPoint As Hashtable = New Hashtable

#End Region '----- Member Variables -----

#Region "----- Helper Methods -----"

        Public Sub Add(ByVal objPoint As Point)

            Dim intHashCode As Int32

            Try
                intHashCode = objPoint.GetHashCode()
                Me.m_htblPoint.Add(intHashCode, objPoint)
                Me.InnerList.Add(objPoint)
            Catch ex As ArgumentException
                'thrown when a dupe is entered into the hashtble, ignore it
            End Try

        End Sub

        Public Sub Remove(ByVal objPoint As Point)

            Dim intHashCode As Int32

            intHashCode = objPoint.GetHashCode()
            If (Me.m_htblPoint.Contains(intHashCode)) Then
                Me.m_htblPoint.Remove(intHashCode)
            End If

        End Sub

        Default Public ReadOnly Property Item(ByVal intIndex As Int32) As Point

            Get
                Return CType(Me.InnerList(intIndex), Point)
            End Get

        End Property

        Default Public ReadOnly Property Item(ByVal hashCode As Object) As Point

            Get
                Return CType(Me.m_htblPoint.Item(hashCode), Point)
            End Get

        End Property

        Public Function Contains(ByVal objPoint As Point) As Boolean

            Dim intHashCode As Int32

            intHashCode = objPoint.GetHashCode()
            Return Me.m_htblPoint.Contains(intHashCode)

        End Function

#End Region '----- Helper Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
