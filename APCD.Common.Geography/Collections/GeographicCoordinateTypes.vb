'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: GeographicCoordinateTypes.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Custom collection class for the GeographicCoordinateType business object.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Geography.Business

Namespace APCD.Geography.Collections

    <Serializable()> Public Class GeographicCoordinateTypes
        Inherits CollectionBase

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        Private m_htblGeographicCoordinateType As Hashtable = New Hashtable

#End Region '----- Member Variables -----

#Region "----- Helper Methods -----"

        Public Sub Add(ByVal objGeographicCoordinateType As GeographicCoordinateType)

            Dim intHashCode As Int32

            Try
                intHashCode = objGeographicCoordinateType.GetHashCode()
                Me.m_htblGeographicCoordinateType.Add(intHashCode, objGeographicCoordinateType)
                Me.InnerList.Add(objGeographicCoordinateType)
            Catch ex As ArgumentException
                'thrown when a dupe is entered into the hashtble, ignore it
            End Try

        End Sub

        Public Sub Remove(ByVal objGeographicCoordinateType As GeographicCoordinateType)

            Dim intHashCode As Int32

            intHashCode = objGeographicCoordinateType.GetHashCode()
            If (Me.m_htblGeographicCoordinateType.Contains(intHashCode)) Then
                Me.m_htblGeographicCoordinateType.Remove(intHashCode)
            End If

        End Sub

        Default Public ReadOnly Property Item(ByVal intIndex As Int32) As GeographicCoordinateType

            Get
                Return CType(Me.InnerList(intIndex), GeographicCoordinateType)
            End Get

        End Property

        Default Public ReadOnly Property Item(ByVal hashCode As Object) As GeographicCoordinateType

            Get
                Return CType(Me.m_htblGeographicCoordinateType.Item(hashCode), GeographicCoordinateType)
            End Get

        End Property

        Public Function Contains(ByVal objGeographicCoordinateType As GeographicCoordinateType) As Boolean

            Dim intHashCode As Int32

            intHashCode = objGeographicCoordinateType.GetHashCode()
            Return Me.m_htblGeographicCoordinateType.Contains(intHashCode)

        End Function

#End Region '----- Helper Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
