'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: HorizontalReferenceDatum.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Business class for the HorizontalReferenceDatum table of the Geography database.
'             Provides an object model as well as Insert, Update, and Delete operations for the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Geography.Data
Imports System.Data.OleDb

Namespace APCD.Geography.Business

    <Serializable()> Public Class HorizontalReferenceDatum

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        '----- Property Variables -----
        Private m_intHorizontalReferenceDatumID As Int32 'primary key
        Private m_strHorizontalReferenceDatumName As String
        Private m_strDatumAbbreviation As String
        Private m_strDatumEPACode As String
        Private m_strComment As String

#End Region '----- Member Variables -----

#Region "----- Properties -----"

        Public Property HorizontalReferenceDatumID() As Int32
            Get
                Return Me.m_intHorizontalReferenceDatumID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intHorizontalReferenceDatumID = Value
            End Set
        End Property

        Public Property HorizontalReferenceDatumName() As String
            Get
                Return Me.m_strHorizontalReferenceDatumName
            End Get
            Set(ByVal Value As String)
                Me.m_strHorizontalReferenceDatumName = Value
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

        Public Property DatumEPACode() As String
            Get
                Return Me.m_strDatumEPACode
            End Get
            Set(ByVal Value As String)
                Me.m_strDatumEPACode = Value
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
            Dim objHorizontalReferenceDatumDB As HorizontalReferenceDatumDB

            Try
                objHorizontalReferenceDatumDB = New HorizontalReferenceDatumDB
                intReutrnValue = objHorizontalReferenceDatumDB.Insert(Me, cmd)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Update(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objHorizontalReferenceDatumDB As HorizontalReferenceDatumDB

            Try
                objHorizontalReferenceDatumDB = New HorizontalReferenceDatumDB
                intReutrnValue = objHorizontalReferenceDatumDB.Update(Me, cmd)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Delete(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objHorizontalReferenceDatumDB As HorizontalReferenceDatumDB

            Try
                objHorizontalReferenceDatumDB = New HorizontalReferenceDatumDB
                intReutrnValue = objHorizontalReferenceDatumDB.Delete(Me, cmd)
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

                .Append(Constants.HorizontalReferenceDatumConstants.FieldName.HorizontalReferenceDatumID)
                .Append(":")
                .Append(Me.HorizontalReferenceDatumID)
                .Append(ControlChars.CrLf)

                .Append(Constants.HorizontalReferenceDatumConstants.FieldName.HorizontalReferenceDatumName)
                .Append(":")
                .Append(Me.HorizontalReferenceDatumName)
                .Append(ControlChars.CrLf)

                .Append(Constants.HorizontalReferenceDatumConstants.FieldName.DatumAbbreviation)
                .Append(":")
                .Append(Me.DatumAbbreviation)
                .Append(ControlChars.CrLf)

                .Append(Constants.HorizontalReferenceDatumConstants.FieldName.DatumEPACode)
                .Append(":")
                .Append(Me.DatumEPACode)
                .Append(ControlChars.CrLf)

                .Append(Constants.HorizontalReferenceDatumConstants.FieldName.Comment)
                .Append(":")
                .Append(Me.Comment)
                .Append(ControlChars.CrLf)

            End With

            Return strbToString.ToString()

        End Function

        Public Overrides Function GetHashCode() As Int32

            Dim intHashCode As Int32
            intHashCode = Me.HorizontalReferenceDatumID.GetHashCode()
            Return intHashCode

        End Function

        Public Overloads Function Equals(ByVal objHorizontalReferenceDatum As HorizontalReferenceDatum) As Boolean

            Dim blnEquals As Boolean

            If ((Me.HorizontalReferenceDatumID = objHorizontalReferenceDatum.HorizontalReferenceDatumID) _
                AndAlso (Me.HorizontalReferenceDatumName = objHorizontalReferenceDatum.HorizontalReferenceDatumName) _
                AndAlso (Me.DatumAbbreviation = objHorizontalReferenceDatum.DatumAbbreviation) _
                AndAlso (Me.DatumEPACode = objHorizontalReferenceDatum.DatumEPACode) _
                AndAlso (Me.Comment = objHorizontalReferenceDatum.Comment)) Then
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
