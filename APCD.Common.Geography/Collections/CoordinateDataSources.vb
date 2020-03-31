'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: CoordinateDataSources.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Custom collection class for the CoordinateDataSource business object.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Geography.Business

Namespace APCD.Geography.Collections

    <Serializable()> Public Class CoordinateDataSources
        Inherits CollectionBase

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        Private m_htblCoordinateDataSource As Hashtable = New Hashtable

#End Region '----- Member Variables -----

#Region "----- Helper Methods -----"

        Public Sub Add(ByVal objCoordinateDataSource As CoordinateDataSource)

            Dim intHashCode As Int32

            Try
                intHashCode = objCoordinateDataSource.GetHashCode()
                Me.m_htblCoordinateDataSource.Add(intHashCode, objCoordinateDataSource)
                Me.InnerList.Add(objCoordinateDataSource)
            Catch ex As ArgumentException
                'thrown when a dupe is entered into the hashtble, ignore it
            End Try

        End Sub

        Public Sub Remove(ByVal objCoordinateDataSource As CoordinateDataSource)

            Dim intHashCode As Int32

            intHashCode = objCoordinateDataSource.GetHashCode()
            If (Me.m_htblCoordinateDataSource.Contains(intHashCode)) Then
                Me.m_htblCoordinateDataSource.Remove(intHashCode)
            End If

        End Sub

        Default Public ReadOnly Property Item(ByVal intIndex As Int32) As CoordinateDataSource

            Get
                Return CType(Me.InnerList(intIndex), CoordinateDataSource)
            End Get

        End Property

        Default Public ReadOnly Property Item(ByVal hashCode As Object) As CoordinateDataSource

            Get
                Return CType(Me.m_htblCoordinateDataSource.Item(hashCode), CoordinateDataSource)
            End Get

        End Property

        Public Function Contains(ByVal objCoordinateDataSource As CoordinateDataSource) As Boolean

            Dim intHashCode As Int32

            intHashCode = objCoordinateDataSource.GetHashCode()
            Return Me.m_htblCoordinateDataSource.Contains(intHashCode)

        End Function

#End Region '----- Helper Methods -----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
