'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: PointDetail.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Business class for the PointDetail table of the Geography database.
'             Provides an object model as well as Insert, Update, and Delete operations for the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Geography.Data
Imports System.Data.OleDb

Namespace APCD.Geography.Business

    <Serializable()> Public Class PointDetail

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        '----- Property Variables -----
        Private m_intPointID As Int32 'primary key
        Private m_intPointDetailTypeID As Int32 'primary key
        Private m_dblPointDetailValue As Double
        Private m_intUnitOfMeasurementID As Int32
        Private m_dtAddDate As DateTime
        Private m_intAddedBy As Int32

#End Region '----- Member Variables -----

#Region "----- Properties -----"

        Public Property PointID() As Int32
            Get
                Return Me.m_intPointID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intPointID = Value
            End Set
        End Property

        Public Property PointDetailTypeID() As Int32
            Get
                Return Me.m_intPointDetailTypeID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intPointDetailTypeID = Value
            End Set
        End Property

        Public Property PointDetailValue() As Double
            Get
                Return Me.m_dblPointDetailValue
            End Get
            Set(ByVal Value As Double)
                Me.m_dblPointDetailValue = Value
            End Set
        End Property

        Public Property UnitOfMeasurementID() As Int32
            Get
                Return Me.m_intUnitOfMeasurementID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intUnitOfMeasurementID = Value
            End Set
        End Property

        Public Property AddDate() As DateTime
            Get
                Return Me.m_dtAddDate
            End Get
            Set(ByVal Value As DateTime)
                Me.m_dtAddDate = Value
            End Set
        End Property

        Public Property AddedBy() As Int32
            Get
                Return Me.m_intAddedBy
            End Get
            Set(ByVal Value As Int32)
                Me.m_intAddedBy = Value
            End Set
        End Property

#End Region '----- Properties -----

#Region "----- DML -----"

        Public Function Insert(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objPointDetailDB As PointDetailDB

            Try
                objPointDetailDB = New PointDetailDB
                intReutrnValue = objPointDetailDB.Insert(Me, cmd)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Update(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objPointDetailDB As PointDetailDB

            Try
                objPointDetailDB = New PointDetailDB
                intReutrnValue = objPointDetailDB.Update(Me, cmd)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Delete(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objPointDetailDB As PointDetailDB

            Try
                objPointDetailDB = New PointDetailDB
                intReutrnValue = objPointDetailDB.Delete(Me, cmd)
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

                .Append(Constants.PointDetailConstants.FieldName.PointID)
                .Append(":")
                .Append(Me.PointID)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointDetailConstants.FieldName.PointDetailTypeID)
                .Append(":")
                .Append(Me.PointDetailTypeID)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointDetailConstants.FieldName.PointDetailValue)
                .Append(":")
                .Append(Me.PointDetailValue)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointDetailConstants.FieldName.UnitOfMeasurementID)
                .Append(":")
                .Append(Me.UnitOfMeasurementID)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointDetailConstants.FieldName.AddDate)
                .Append(":")
                .Append(Me.AddDate)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointDetailConstants.FieldName.AddedBy)
                .Append(":")
                .Append(Me.AddedBy)
                .Append(ControlChars.CrLf)

            End With

            Return strbToString.ToString()

        End Function

        Public Overrides Function GetHashCode() As Int32

            Dim intHashCode As Int32
            intHashCode = (Me.PointID.GetHashCode() Xor Me.PointDetailTypeID.GetHashCode())
            Return intHashCode

        End Function

        Public Overloads Function Equals(ByVal objPointDetail As PointDetail) As Boolean

            Dim blnEquals As Boolean

            If ((Me.PointID = objPointDetail.PointID) _
                AndAlso (Me.PointDetailTypeID = objPointDetail.PointDetailTypeID) _
                AndAlso (Me.PointDetailValue = objPointDetail.PointDetailValue) _
                AndAlso (Me.UnitOfMeasurementID = objPointDetail.UnitOfMeasurementID) _
                AndAlso (Me.AddDate = objPointDetail.AddDate) _
                AndAlso (Me.AddedBy = objPointDetail.AddedBy)) Then
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
