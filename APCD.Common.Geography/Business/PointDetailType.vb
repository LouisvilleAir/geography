'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: PointDetailType.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Business class for the PointDetailType table of the Geography database.
'             Provides an object model as well as Insert, Update, and Delete operations for the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Geography.Data
Imports System.Data.OleDb

Namespace APCD.Geography.Business

    <Serializable()> Public Class PointDetailType

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        '----- Property Variables -----
        Private m_intPointDetailTypeID As Int32 'primary key
        Private m_strPointDetailTypeName As String

#End Region '----- Member Variables -----

#Region "----- Properties -----"

        Public Property PointDetailTypeID() As Int32
            Get
                Return Me.m_intPointDetailTypeID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intPointDetailTypeID = Value
            End Set
        End Property

        Public Property PointDetailTypeName() As String
            Get
                Return Me.m_strPointDetailTypeName
            End Get
            Set(ByVal Value As String)
                Me.m_strPointDetailTypeName = Value
            End Set
        End Property

#End Region '----- Properties -----

#Region "----- DML -----"

        Public Function Insert(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objPointDetailTypeDB As PointDetailTypeDB

            Try
                objPointDetailTypeDB = New PointDetailTypeDB
                intReutrnValue = objPointDetailTypeDB.Insert(Me, cmd)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Update(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objPointDetailTypeDB As PointDetailTypeDB

            Try
                objPointDetailTypeDB = New PointDetailTypeDB
                intReutrnValue = objPointDetailTypeDB.Update(Me, cmd)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Delete(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objPointDetailTypeDB As PointDetailTypeDB

            Try
                objPointDetailTypeDB = New PointDetailTypeDB
                intReutrnValue = objPointDetailTypeDB.Delete(Me, cmd)
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

                .Append(Constants.PointDetailTypeConstants.FieldName.PointDetailTypeID)
                .Append(":")
                .Append(Me.PointDetailTypeID)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointDetailTypeConstants.FieldName.PointDetailTypeName)
                .Append(":")
                .Append(Me.PointDetailTypeName)
                .Append(ControlChars.CrLf)

            End With

            Return strbToString.ToString()

        End Function

        Public Overrides Function GetHashCode() As Int32

            Dim intHashCode As Int32
            intHashCode = Me.PointDetailTypeID.GetHashCode()
            Return intHashCode

        End Function

        Public Overloads Function Equals(ByVal objPointDetailType As PointDetailType) As Boolean

            Dim blnEquals As Boolean

            If ((Me.PointDetailTypeID = objPointDetailType.PointDetailTypeID) _
                AndAlso (Me.PointDetailTypeName = objPointDetailType.PointDetailTypeName)) Then
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
