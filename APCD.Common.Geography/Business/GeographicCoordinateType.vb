'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: GeographicCoordinateType.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Business class for the GeographicCoordinateType table of the Geography database.
'             Provides an object model as well as Insert, Update, and Delete operations for the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Geography.Data
Imports System.Data.OleDb

Namespace APCD.Geography.Business

    <Serializable()> Public Class GeographicCoordinateType

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        '----- Property Variables -----
        Private m_intGeographicCoordinateTypeID As Int32 'primary key
        Private m_strGeographicCoordinateTypeName As String
        Private m_strComment As String

#End Region '----- Member Variables -----

#Region "----- Properties -----"

        Public Property GeographicCoordinateTypeID() As Int32
            Get
                Return Me.m_intGeographicCoordinateTypeID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intGeographicCoordinateTypeID = Value
            End Set
        End Property

        Public Property GeographicCoordinateTypeName() As String
            Get
                Return Me.m_strGeographicCoordinateTypeName
            End Get
            Set(ByVal Value As String)
                Me.m_strGeographicCoordinateTypeName = Value
            End Set
        End Property

        Public Property Comment() As String
            Get
                Return Me.m_strComment
            End Get
            Set(ByVal Value As String)
                Me.m_strComment = Value
            End Set
        End Property

#End Region '----- Properties -----

#Region "----- DML -----"

        Public Function Insert(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objGeographicCoordinateTypeDB As GeographicCoordinateTypeDB

            Try
                objGeographicCoordinateTypeDB = New GeographicCoordinateTypeDB
                intReutrnValue = objGeographicCoordinateTypeDB.Insert(Me, cmd)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Update(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objGeographicCoordinateTypeDB As GeographicCoordinateTypeDB

            Try
                objGeographicCoordinateTypeDB = New GeographicCoordinateTypeDB
                intReutrnValue = objGeographicCoordinateTypeDB.Update(Me, cmd)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Delete(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objGeographicCoordinateTypeDB As GeographicCoordinateTypeDB

            Try
                objGeographicCoordinateTypeDB = New GeographicCoordinateTypeDB
                intReutrnValue = objGeographicCoordinateTypeDB.Delete(Me, cmd)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

#End Region '----- DML -----

#Region "----- Object Class Overloads-----"

        Public Overrides Function ToString() As String

            Dim strbToString As Text.StringBuilder

            strbToString = New Text.StringBuilder
            With strbToString

                .Append(Constants.GeographicCoordinateTypeConstants.FieldName.GeographicCoordinateTypeID)
                .Append(":")
                .Append(Me.GeographicCoordinateTypeID)
                .Append(ControlChars.CrLf)

                .Append(Constants.GeographicCoordinateTypeConstants.FieldName.GeographicCoordinateTypeName)
                .Append(":")
                .Append(Me.GeographicCoordinateTypeName)
                .Append(ControlChars.CrLf)

                .Append(Constants.GeographicCoordinateTypeConstants.FieldName.Comment)
                .Append(":")
                .Append(Me.Comment)
                .Append(ControlChars.CrLf)

            End With

            Return strbToString.ToString()

        End Function

        Public Overrides Function GetHashCode() As Int32

            Dim intHashCode As Int32
            intHashCode = Me.GeographicCoordinateTypeID.GetHashCode()
            Return intHashCode

        End Function

        Public Overloads Function Equals(ByVal objGeographicCoordinateType As GeographicCoordinateType) As Boolean

            Dim blnEquals As Boolean

            If ((Me.GeographicCoordinateTypeID = objGeographicCoordinateType.GeographicCoordinateTypeID) _
                AndAlso (Me.GeographicCoordinateTypeName = objGeographicCoordinateType.GeographicCoordinateTypeName) _
                AndAlso (Me.Comment = objGeographicCoordinateType.Comment)) Then
                blnEquals = True
            Else
                blnEquals = False
            End If

            Return blnEquals

        End Function

#End Region '----- Object Class Overloads-----

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
