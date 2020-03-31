'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: VerticalReferenceDatum.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Business class for the VerticalReferenceDatum table of the Geography database.
'             Provides an object model as well as Insert, Update, and Delete operations for the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Geography.Data
Imports System.Data.OleDb

Namespace APCD.Geography.Business

    <Serializable()> Public Class VerticalReferenceDatum

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        '----- Property Variables -----
        Private m_intVerticalReferenceDatumID As Int32 'primary key
        Private m_strVerticalReferenceDatumName As String
        Private m_strDatumAbbreviation As String

#End Region '----- Member Variables -----

#Region "----- Properties -----"

        Public Property VerticalReferenceDatumID() As Int32
            Get
                Return Me.m_intVerticalReferenceDatumID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intVerticalReferenceDatumID = Value
            End Set
        End Property

        Public Property VerticalReferenceDatumName() As String
            Get
                Return Me.m_strVerticalReferenceDatumName
            End Get
            Set(ByVal Value As String)
                Me.m_strVerticalReferenceDatumName = Value
            End Set
        End Property

        Public Property DatumAbbreviation() As String
            Get
                Return Me.m_strDatumAbbreviation
            End Get
            Set(ByVal Value As String)
                Me.m_strDatumAbbreviation = Value
            End Set
        End Property

#End Region '----- Properties -----

#Region "----- DML -----"

        Public Function Insert(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objVerticalReferenceDatumDB As VerticalReferenceDatumDB

            Try
                objVerticalReferenceDatumDB = New VerticalReferenceDatumDB
                intReutrnValue = objVerticalReferenceDatumDB.Insert(Me, cmd)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Update(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objVerticalReferenceDatumDB As VerticalReferenceDatumDB

            Try
                objVerticalReferenceDatumDB = New VerticalReferenceDatumDB
                intReutrnValue = objVerticalReferenceDatumDB.Update(Me, cmd)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Delete(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objVerticalReferenceDatumDB As VerticalReferenceDatumDB

            Try
                objVerticalReferenceDatumDB = New VerticalReferenceDatumDB
                intReutrnValue = objVerticalReferenceDatumDB.Delete(Me, cmd)
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

                .Append(Constants.VerticalReferenceDatumConstants.FieldName.VerticalReferenceDatumID)
                .Append(":")
                .Append(Me.VerticalReferenceDatumID)
                .Append(ControlChars.CrLf)

                .Append(Constants.VerticalReferenceDatumConstants.FieldName.VerticalReferenceDatumName)
                .Append(":")
                .Append(Me.VerticalReferenceDatumName)
                .Append(ControlChars.CrLf)

                .Append(Constants.VerticalReferenceDatumConstants.FieldName.DatumAbbreviation)
                .Append(":")
                .Append(Me.DatumAbbreviation)
                .Append(ControlChars.CrLf)

            End With

            Return strbToString.ToString()

        End Function

        Public Overrides Function GetHashCode() As Int32

            Dim intHashCode As Int32
            intHashCode = Me.VerticalReferenceDatumID.GetHashCode()
            Return intHashCode

        End Function

        Public Overloads Function Equals(ByVal objVerticalReferenceDatum As VerticalReferenceDatum) As Boolean

            Dim blnEquals As Boolean

            If ((Me.VerticalReferenceDatumID = objVerticalReferenceDatum.VerticalReferenceDatumID) _
                AndAlso (Me.VerticalReferenceDatumName = objVerticalReferenceDatum.VerticalReferenceDatumName) _
                AndAlso (Me.DatumAbbreviation = objVerticalReferenceDatum.DatumAbbreviation)) Then
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
