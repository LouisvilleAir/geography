'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: VerticalCollectionMethod.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Business class for the VerticalCollectionMethod table of the Geography database.
'             Provides an object model as well as Insert, Update, and Delete operations for the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Geography.Data
Imports System.Data.OleDb

Namespace APCD.Geography.Business

    <Serializable()> Public Class VerticalCollectionMethod

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        '----- Property Variables -----
        Private m_intVerticalCollectionMethodID As Int32 'primary key
        Private m_strVerticalCollectionMethodName As String
        Private m_strVerticalCollectionMethodDescription As String

#End Region '----- Member Variables -----

#Region "----- Properties -----"

        Public Property VerticalCollectionMethodID() As Int32
            Get
                Return Me.m_intVerticalCollectionMethodID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intVerticalCollectionMethodID = Value
            End Set
        End Property

        Public Property VerticalCollectionMethodName() As String
            Get
                Return Me.m_strVerticalCollectionMethodName
            End Get
            Set(ByVal Value As String)
                Me.m_strVerticalCollectionMethodName = Value
            End Set
        End Property

        Public Property VerticalCollectionMethodDescription() As String
            Get
                Return Me.m_strVerticalCollectionMethodDescription
            End Get
            Set(ByVal Value As String)
                Me.m_strVerticalCollectionMethodDescription = Value
            End Set
        End Property

#End Region '----- Properties -----

#Region "----- DML -----"

        Public Function Insert(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objVerticalCollectionMethodDB As VerticalCollectionMethodDB

            Try
                objVerticalCollectionMethodDB = New VerticalCollectionMethodDB
                intReutrnValue = objVerticalCollectionMethodDB.Insert(Me, cmd)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Update(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objVerticalCollectionMethodDB As VerticalCollectionMethodDB

            Try
                objVerticalCollectionMethodDB = New VerticalCollectionMethodDB
                intReutrnValue = objVerticalCollectionMethodDB.Update(Me, cmd)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Delete(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objVerticalCollectionMethodDB As VerticalCollectionMethodDB

            Try
                objVerticalCollectionMethodDB = New VerticalCollectionMethodDB
                intReutrnValue = objVerticalCollectionMethodDB.Delete(Me, cmd)
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

                .Append(Constants.VerticalCollectionMethodConstants.FieldName.VerticalCollectionMethodID)
                .Append(":")
                .Append(Me.VerticalCollectionMethodID)
                .Append(ControlChars.CrLf)

                .Append(Constants.VerticalCollectionMethodConstants.FieldName.VerticalCollectionMethodName)
                .Append(":")
                .Append(Me.VerticalCollectionMethodName)
                .Append(ControlChars.CrLf)

                .Append(Constants.VerticalCollectionMethodConstants.FieldName.VerticalCollectionMethodDescription)
                .Append(":")
                .Append(Me.VerticalCollectionMethodDescription)
                .Append(ControlChars.CrLf)

            End With

            Return strbToString.ToString()

        End Function

        Public Overrides Function GetHashCode() As Int32

            Dim intHashCode As Int32
            intHashCode = Me.VerticalCollectionMethodID.GetHashCode()
            Return intHashCode

        End Function

        Public Overloads Function Equals(ByVal objVerticalCollectionMethod As VerticalCollectionMethod) As Boolean

            Dim blnEquals As Boolean

            If ((Me.VerticalCollectionMethodID = objVerticalCollectionMethod.VerticalCollectionMethodID) _
                AndAlso (Me.VerticalCollectionMethodName = objVerticalCollectionMethod.VerticalCollectionMethodName) _
                AndAlso (Me.VerticalCollectionMethodDescription = objVerticalCollectionMethod.VerticalCollectionMethodDescription)) Then
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
