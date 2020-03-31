'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: CoordinateDataSource.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Business class for the CoordinateDataSource table of the Geography database.
'             Provides an object model as well as Insert, Update, and Delete operations for the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Geography.Data
Imports System.Data.OleDb

Namespace APCD.Geography.Business

    <Serializable()> Public Class CoordinateDataSource

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        '----- Property Variables -----
        Private m_intCoordinateDataSourceID As Int32 'primary key
        Private m_strCoordinateDataSourceName As String
        Private m_strCoordinateDataSourceEISCode As String

#End Region '----- Member Variables -----

#Region "----- Properties -----"

        Public Property CoordinateDataSourceID() As Int32
            Get
                Return Me.m_intCoordinateDataSourceID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intCoordinateDataSourceID = Value
            End Set
        End Property

        Public Property CoordinateDataSourceName() As String
            Get
                Return Me.m_strCoordinateDataSourceName
            End Get
            Set(ByVal Value As String)
                Me.m_strCoordinateDataSourceName = Value
            End Set
        End Property

        Public Property CoordinateDataSourceEISCode() As String
            Get
                Return Me.m_strCoordinateDataSourceEISCode
            End Get
            Set(ByVal Value As String)
                Me.m_strCoordinateDataSourceEISCode = Value
            End Set
        End Property

#End Region '----- Properties -----

#Region "----- DML -----"

        Public Function Insert(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objCoordinateDataSourceDB As CoordinateDataSourceDB

            Try
                objCoordinateDataSourceDB = New CoordinateDataSourceDB
                intReutrnValue = objCoordinateDataSourceDB.Insert(Me, cmd)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Update(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objCoordinateDataSourceDB As CoordinateDataSourceDB

            Try
                objCoordinateDataSourceDB = New CoordinateDataSourceDB
                intReutrnValue = objCoordinateDataSourceDB.Update(Me, cmd)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Delete(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objCoordinateDataSourceDB As CoordinateDataSourceDB

            Try
                objCoordinateDataSourceDB = New CoordinateDataSourceDB
                intReutrnValue = objCoordinateDataSourceDB.Delete(Me, cmd)
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

                .Append(Constants.CoordinateDataSourceConstants.FieldName.CoordinateDataSourceID)
                .Append(":")
                .Append(Me.CoordinateDataSourceID)
                .Append(ControlChars.CrLf)

                .Append(Constants.CoordinateDataSourceConstants.FieldName.CoordinateDataSourceName)
                .Append(":")
                .Append(Me.CoordinateDataSourceName)
                .Append(ControlChars.CrLf)

                .Append(Constants.CoordinateDataSourceConstants.FieldName.CoordinateDataSourceEISCode)
                .Append(":")
                .Append(Me.CoordinateDataSourceEISCode)
                .Append(ControlChars.CrLf)

            End With

            Return strbToString.ToString()

        End Function

        Public Overrides Function GetHashCode() As Int32

            Dim intHashCode As Int32
            intHashCode = Me.CoordinateDataSourceID.GetHashCode()
            Return intHashCode

        End Function

        Public Overloads Function Equals(ByVal objCoordinateDataSource As CoordinateDataSource) As Boolean

            Dim blnEquals As Boolean

            If ((Me.CoordinateDataSourceID = objCoordinateDataSource.CoordinateDataSourceID) _
                AndAlso (Me.CoordinateDataSourceName = objCoordinateDataSource.CoordinateDataSourceName) _
                AndAlso (Me.CoordinateDataSourceEISCode = objCoordinateDataSource.CoordinateDataSourceEISCode)) Then
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
