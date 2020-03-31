'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: VerticalReferenceDatums.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Custom collection class for the VerticalReferenceDatum business object.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Geography.Business

Namespace APCD.Geography.Collections

    <Serializable()> Public Class VerticalReferenceDatums
        Inherits CollectionBase

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        Private m_htblVerticalReferenceDatum As Hashtable = New Hashtable

#End Region '----- Member Variables -----

#Region "----- Helper Methods -----"

        Public Sub Add(ByVal objVerticalReferenceDatum As VerticalReferenceDatum)

            Dim intHashCode As Int32

            Try
                intHashCode = objVerticalReferenceDatum.GetHashCode()
                Me.m_htblVerticalReferenceDatum.Add(intHashCode, objVerticalReferenceDatum)
                Me.InnerList.Add(objVerticalReferenceDatum)
            Catch ex As ArgumentException
                'thrown when a dupe is entered into the hashtble, ignore it
            End Try

        End Sub

        Public Sub Remove(ByVal objVerticalReferenceDatum As VerticalReferenceDatum)

            Dim intHashCode As Int32

            intHashCode = objVerticalReferenceDatum.GetHashCode()
            If (Me.m_htblVerticalReferenceDatum.Contains(intHashCode)) Then
                Me.m_htblVerticalReferenceDatum.Remove(intHashCode)
            End If

        End Sub

        Default Public ReadOnly Property Item(ByVal intIndex As Int32) As VerticalReferenceDatum

            Get
                Return CType(Me.InnerList(intIndex), VerticalReferenceDatum)
            End Get

        End Property

        Default Public ReadOnly Property Item(ByVal hashCode As Object) As VerticalReferenceDatum

            Get
                Return CType(Me.m_htblVerticalReferenceDatum.Item(hashCode), VerticalReferenceDatum)
            End Get

        End Property

        Public Function Contains(ByVal objVerticalReferenceDatum As VerticalReferenceDatum) As Boolean

            Dim intHashCode As Int32

            intHashCode = objVerticalReferenceDatum.GetHashCode()
            Return Me.m_htblVerticalReferenceDatum.Contains(intHashCode)

        End Function

#End Region '----- Helper Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
