'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: HorizontalCollectionMethod.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Business class for the HorizontalCollectionMethod table of the Geography database.
'             Provides an object model as well as Insert, Update, and Delete operations for the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Geography.Data
Imports System.Data.OleDb

Namespace APCD.Geography.Business

    <Serializable()> Public Class HorizontalCollectionMethod

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        '----- Property Variables -----
        Private m_intHorizontalCollectionMethodID As Int32 'primary key
        Private m_strHorizontalCollectionMethodName As String
        Private m_strMethodEPACode As String
        Private m_strDescription As String

#End Region '----- Member Variables -----

#Region "----- Properties -----"

        Public Property HorizontalCollectionMethodID() As Int32
            Get
                Return Me.m_intHorizontalCollectionMethodID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intHorizontalCollectionMethodID = Value
            End Set
        End Property

        Public Property HorizontalCollectionMethodName() As String
            Get
                Return Me.m_strHorizontalCollectionMethodName
            End Get
            Set(ByVal Value As String)
                Me.m_strHorizontalCollectionMethodName = Value
            End Set
        End Property

        Public Property MethodEPACode() As String
            Get
                Return Me.m_strMethodEPACode
            End Get
            Set(ByVal Value As String)
                Me.m_strMethodEPACode = Value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return Me.m_strDescription
            End Get
            Set(ByVal Value As String)
                Me.m_strDescription = Value
            End Set
        End Property

#End Region '----- Properties -----

#Region "----- DML -----"

        Public Function Insert(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objHorizontalCollectionMethodDB As HorizontalCollectionMethodDB

            Try
                objHorizontalCollectionMethodDB = New HorizontalCollectionMethodDB
                intReutrnValue = objHorizontalCollectionMethodDB.Insert(Me, cmd)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Update(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objHorizontalCollectionMethodDB As HorizontalCollectionMethodDB

            Try
                objHorizontalCollectionMethodDB = New HorizontalCollectionMethodDB
                intReutrnValue = objHorizontalCollectionMethodDB.Update(Me, cmd)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Delete(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objHorizontalCollectionMethodDB As HorizontalCollectionMethodDB

            Try
                objHorizontalCollectionMethodDB = New HorizontalCollectionMethodDB
                intReutrnValue = objHorizontalCollectionMethodDB.Delete(Me, cmd)
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

                .Append(Constants.HorizontalCollectionMethodConstants.FieldName.HorizontalCollectionMethodID)
                .Append(":")
                .Append(Me.HorizontalCollectionMethodID)
                .Append(ControlChars.CrLf)

                .Append(Constants.HorizontalCollectionMethodConstants.FieldName.HorizontalCollectionMethodName)
                .Append(":")
                .Append(Me.HorizontalCollectionMethodName)
                .Append(ControlChars.CrLf)

                .Append(Constants.HorizontalCollectionMethodConstants.FieldName.MethodEPACode)
                .Append(":")
                .Append(Me.MethodEPACode)
                .Append(ControlChars.CrLf)

                .Append(Constants.HorizontalCollectionMethodConstants.FieldName.Description)
                .Append(":")
                .Append(Me.Description)
                .Append(ControlChars.CrLf)

            End With

            Return strbToString.ToString()

        End Function

        Public Overrides Function GetHashCode() As Int32

            Dim intHashCode As Int32
            intHashCode = Me.HorizontalCollectionMethodID.GetHashCode()
            Return intHashCode

        End Function

        Public Overloads Function Equals(ByVal objHorizontalCollectionMethod As HorizontalCollectionMethod) As Boolean

            Dim blnEquals As Boolean

            If ((Me.HorizontalCollectionMethodID = objHorizontalCollectionMethod.HorizontalCollectionMethodID) _
                AndAlso (Me.HorizontalCollectionMethodName = objHorizontalCollectionMethod.HorizontalCollectionMethodName) _
                AndAlso (Me.MethodEPACode = objHorizontalCollectionMethod.MethodEPACode) _
                AndAlso (Me.Description = objHorizontalCollectionMethod.Description)) Then
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
