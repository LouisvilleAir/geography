'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: HorizontalReferenceDatums.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Custom collection class for the HorizontalReferenceDatum business object.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Geography.Business

Namespace APCD.Geography.Collections

    <Serializable()> Public Class HorizontalReferenceDatums
        Inherits CollectionBase

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        Private m_htblHorizontalReferenceDatum As Hashtable = New Hashtable

#End Region '----- Member Variables -----

#Region "----- Helper Methods -----"

        Public Sub Add(ByVal objHorizontalReferenceDatum As HorizontalReferenceDatum)

            Dim intHashCode As Int32

            Try
                intHashCode = objHorizontalReferenceDatum.GetHashCode()
                Me.m_htblHorizontalReferenceDatum.Add(intHashCode, objHorizontalReferenceDatum)
                Me.InnerList.Add(objHorizontalReferenceDatum)
            Catch ex As ArgumentException
                'thrown when a dupe is entered into the hashtble, ignore it
            End Try

        End Sub

        Public Sub Remove(ByVal objHorizontalReferenceDatum As HorizontalReferenceDatum)

            Dim intHashCode As Int32

            intHashCode = objHorizontalReferenceDatum.GetHashCode()
            If (Me.m_htblHorizontalReferenceDatum.Contains(intHashCode)) Then
                Me.m_htblHorizontalReferenceDatum.Remove(intHashCode)
            End If

        End Sub

        Default Public ReadOnly Property Item(ByVal intIndex As Int32) As HorizontalReferenceDatum

            Get
                Return CType(Me.InnerList(intIndex), HorizontalReferenceDatum)
            End Get

        End Property

        Default Public ReadOnly Property Item(ByVal hashCode As Object) As HorizontalReferenceDatum

            Get
                Return CType(Me.m_htblHorizontalReferenceDatum.Item(hashCode), HorizontalReferenceDatum)
            End Get

        End Property

        Public Function Contains(ByVal objHorizontalReferenceDatum As HorizontalReferenceDatum) As Boolean

            Dim intHashCode As Int32

            intHashCode = objHorizontalReferenceDatum.GetHashCode()
            Return Me.m_htblHorizontalReferenceDatum.Contains(intHashCode)

        End Function

#End Region '----- Helper Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
