'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: CoordinateVerificationMethod.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Business class for the CoordinateVerificationMethod table of the Geography database.
'             Provides an object model as well as Insert, Update, and Delete operations for the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Geography.Data
Imports System.Data.OleDb

Namespace APCD.Geography.Business

    <Serializable()> Public Class CoordinateVerificationMethod

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        '----- Property Variables -----
        Private m_intCoordinateVerificationMethodID As Int32 'primary key
        Private m_strCoordinateVerificationMethodName As String
        Private m_strCoordinateVerificationMethodDescription As String

#End Region '----- Member Variables -----

#Region "----- Properties -----"

        Public Property CoordinateVerificationMethodID() As Int32
            Get
                Return Me.m_intCoordinateVerificationMethodID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intCoordinateVerificationMethodID = Value
            End Set
        End Property

        Public Property CoordinateVerificationMethodName() As String
            Get
                Return Me.m_strCoordinateVerificationMethodName
            End Get
            Set(ByVal Value As String)
                Me.m_strCoordinateVerificationMethodName = Value
            End Set
        End Property

        Public Property CoordinateVerificationMethodDescription() As String
            Get
                Return Me.m_strCoordinateVerificationMethodDescription
            End Get
            Set(ByVal Value As String)
                Me.m_strCoordinateVerificationMethodDescription = Value
            End Set
        End Property

#End Region '----- Properties -----

#Region "----- DML -----"

        Public Function Insert(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objCoordinateVerificationMethodDB As CoordinateVerificationMethodDB

            Try
                objCoordinateVerificationMethodDB = New CoordinateVerificationMethodDB
                intReutrnValue = objCoordinateVerificationMethodDB.Insert(Me, cmd)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Update(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objCoordinateVerificationMethodDB As CoordinateVerificationMethodDB

            Try
                objCoordinateVerificationMethodDB = New CoordinateVerificationMethodDB
                intReutrnValue = objCoordinateVerificationMethodDB.Update(Me, cmd)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Delete(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objCoordinateVerificationMethodDB As CoordinateVerificationMethodDB

            Try
                objCoordinateVerificationMethodDB = New CoordinateVerificationMethodDB
                intReutrnValue = objCoordinateVerificationMethodDB.Delete(Me, cmd)
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

                .Append(Constants.CoordinateVerificationMethodConstants.FieldName.CoordinateVerificationMethodID)
                .Append(":")
                .Append(Me.CoordinateVerificationMethodID)
                .Append(ControlChars.CrLf)

                .Append(Constants.CoordinateVerificationMethodConstants.FieldName.CoordinateVerificationMethodName)
                .Append(":")
                .Append(Me.CoordinateVerificationMethodName)
                .Append(ControlChars.CrLf)

                .Append(Constants.CoordinateVerificationMethodConstants.FieldName.CoordinateVerificationMethodDescription)
                .Append(":")
                .Append(Me.CoordinateVerificationMethodDescription)
                .Append(ControlChars.CrLf)

            End With

            Return strbToString.ToString()

        End Function

        Public Overrides Function GetHashCode() As Int32

            Dim intHashCode As Int32
            intHashCode = Me.CoordinateVerificationMethodID.GetHashCode()
            Return intHashCode

        End Function

        Public Overloads Function Equals(ByVal objCoordinateVerificationMethod As CoordinateVerificationMethod) As Boolean

            Dim blnEquals As Boolean

            If ((Me.CoordinateVerificationMethodID = objCoordinateVerificationMethod.CoordinateVerificationMethodID) _
                AndAlso (Me.CoordinateVerificationMethodName = objCoordinateVerificationMethod.CoordinateVerificationMethodName) _
                AndAlso (Me.CoordinateVerificationMethodDescription = objCoordinateVerificationMethod.CoordinateVerificationMethodDescription)) Then
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
