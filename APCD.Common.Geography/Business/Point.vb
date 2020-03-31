'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: Point.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Business class for the Point table of the Geography database.
'             Provides an object model as well as Insert, Update, and Delete operations for the table.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Imports APCD.Geography.Data
Imports System.Data.OleDb

Namespace APCD.Geography.Business

    <Serializable()> Public Class Point

#Region "----- Constructors -----"

        Public Sub New()
            MyBase.New()
        End Sub

#End Region '----- Constructors -----

#Region "----- Member Variables -----"

        '----- Property Variables -----
        Private m_intPointID As Int32 'primary key
        Private m_intGeographicCoordinateTypeID As Int32
        Private m_intCoordinateZone As Int32
        Private m_intGeometricTypeID As Int32
        Private m_decXCoordinate As Decimal
        Private m_decYCoordinate As Decimal
        Private m_decElevation As Decimal
        Private m_intUnitOfMeasurementID As Int32
        Private m_intHorizontalCollectionMethodID As Int32
        Private m_intHorizontalReferenceDatumID As Int32
        Private m_intSourceMapScaleNumber As Int32
        Private m_intCoordinateVerificationMethodID As Int32
        Private m_intCoordinateDataSourceID As Int32
        Private m_dtHorizontalCollectionDate As DateTime
        Private m_intVerticalCollectionMethodID As Int32
        Private m_intVerticalReferenceDatumID As Int32
        Private m_dtVerticalCollectionDate As DateTime
        Private m_strGeographicPointComment As String
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

        Public Property GeographicCoordinateTypeID() As Int32
            Get
                Return Me.m_intGeographicCoordinateTypeID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intGeographicCoordinateTypeID = Value
            End Set
        End Property

        Public Property CoordinateZone() As Int32
            Get
                Return Me.m_intCoordinateZone
            End Get
            Set(ByVal Value As Int32)
                Me.m_intCoordinateZone = Value
            End Set
        End Property

        Public Property GeometricTypeID() As Int32
            Get
                Return Me.m_intGeometricTypeID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intGeometricTypeID = Value
            End Set
        End Property

        Public Property XCoordinate() As Decimal
            Get
                Return Me.m_decXCoordinate
            End Get
            Set(ByVal Value As Decimal)
                Me.m_decXCoordinate = Value
            End Set
        End Property

        Public Property YCoordinate() As Decimal
            Get
                Return Me.m_decYCoordinate
            End Get
            Set(ByVal Value As Decimal)
                Me.m_decYCoordinate = Value
            End Set
        End Property

        Public Property Elevation() As Decimal
            Get
                Return Me.m_decElevation
            End Get
            Set(ByVal Value As Decimal)
                Me.m_decElevation = Value
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

        Public Property HorizontalCollectionMethodID() As Int32
            Get
                Return Me.m_intHorizontalCollectionMethodID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intHorizontalCollectionMethodID = Value
            End Set
        End Property

        Public Property HorizontalReferenceDatumID() As Int32
            Get
                Return Me.m_intHorizontalReferenceDatumID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intHorizontalReferenceDatumID = Value
            End Set
        End Property

        Public Property SourceMapScaleNumber() As Int32
            Get
                Return Me.m_intSourceMapScaleNumber
            End Get
            Set(ByVal Value As Int32)
                Me.m_intSourceMapScaleNumber = Value
            End Set
        End Property

        Public Property CoordinateVerificationMethodID() As Int32
            Get
                Return Me.m_intCoordinateVerificationMethodID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intCoordinateVerificationMethodID = Value
            End Set
        End Property

        Public Property CoordinateDataSourceID() As Int32
            Get
                Return Me.m_intCoordinateDataSourceID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intCoordinateDataSourceID = Value
            End Set
        End Property

        Public Property HorizontalCollectionDate() As DateTime
            Get
                Return Me.m_dtHorizontalCollectionDate
            End Get
            Set(ByVal Value As DateTime)
                Me.m_dtHorizontalCollectionDate = Value
            End Set
        End Property

        Public Property VerticalCollectionMethodID() As Int32
            Get
                Return Me.m_intVerticalCollectionMethodID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intVerticalCollectionMethodID = Value
            End Set
        End Property

        Public Property VerticalReferenceDatumID() As Int32
            Get
                Return Me.m_intVerticalReferenceDatumID
            End Get
            Set(ByVal Value As Int32)
                Me.m_intVerticalReferenceDatumID = Value
            End Set
        End Property

        Public Property VerticalCollectionDate() As DateTime
            Get
                Return Me.m_dtVerticalCollectionDate
            End Get
            Set(ByVal Value As DateTime)
                Me.m_dtVerticalCollectionDate = Value
            End Set
        End Property

        Public Property GeographicPointComment() As String
            Get
                Return Me.m_strGeographicPointComment
            End Get
            Set(ByVal Value As String)
                Me.m_strGeographicPointComment = Value
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
            Dim objPointDB As PointDB

            Try
                objPointDB = New PointDB
                intReutrnValue = objPointDB.Insert(Me, cmd)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Update(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objPointDB As PointDB

            Try
                objPointDB = New PointDB
                intReutrnValue = objPointDB.Update(Me, cmd)
            Catch ex As Exception
                Throw
            End Try

            Return intReutrnValue

        End Function

        Public Function Delete(ByVal cmd As OleDbCommand) As Int32

            Dim intReutrnValue As Int32
            Dim objPointDB As PointDB

            Try
                objPointDB = New PointDB
                intReutrnValue = objPointDB.Delete(Me, cmd)
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

                .Append(Constants.PointConstants.FieldName.PointID)
                .Append(":")
                .Append(Me.PointID)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointConstants.FieldName.GeographicCoordinateTypeID)
                .Append(":")
                .Append(Me.GeographicCoordinateTypeID)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointConstants.FieldName.CoordinateZone)
                .Append(":")
                .Append(Me.CoordinateZone)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointConstants.FieldName.GeometricTypeID)
                .Append(":")
                .Append(Me.GeometricTypeID)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointConstants.FieldName.XCoordinate)
                .Append(":")
                .Append(Me.XCoordinate)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointConstants.FieldName.YCoordinate)
                .Append(":")
                .Append(Me.YCoordinate)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointConstants.FieldName.Elevation)
                .Append(":")
                .Append(Me.Elevation)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointConstants.FieldName.UnitOfMeasurementID)
                .Append(":")
                .Append(Me.UnitOfMeasurementID)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointConstants.FieldName.HorizontalCollectionMethodID)
                .Append(":")
                .Append(Me.HorizontalCollectionMethodID)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointConstants.FieldName.HorizontalReferenceDatumID)
                .Append(":")
                .Append(Me.HorizontalReferenceDatumID)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointConstants.FieldName.SourceMapScaleNumber)
                .Append(":")
                .Append(Me.SourceMapScaleNumber)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointConstants.FieldName.CoordinateVerificationMethodID)
                .Append(":")
                .Append(Me.CoordinateVerificationMethodID)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointConstants.FieldName.CoordinateDataSourceID)
                .Append(":")
                .Append(Me.CoordinateDataSourceID)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointConstants.FieldName.HorizontalCollectionDate)
                .Append(":")
                .Append(Me.HorizontalCollectionDate)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointConstants.FieldName.VerticalCollectionMethodID)
                .Append(":")
                .Append(Me.VerticalCollectionMethodID)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointConstants.FieldName.VerticalReferenceDatumID)
                .Append(":")
                .Append(Me.VerticalReferenceDatumID)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointConstants.FieldName.VerticalCollectionDate)
                .Append(":")
                .Append(Me.VerticalCollectionDate)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointConstants.FieldName.GeographicPointComment)
                .Append(":")
                .Append(Me.GeographicPointComment)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointConstants.FieldName.AddDate)
                .Append(":")
                .Append(Me.AddDate)
                .Append(ControlChars.CrLf)

                .Append(Constants.PointConstants.FieldName.AddedBy)
                .Append(":")
                .Append(Me.AddedBy)
                .Append(ControlChars.CrLf)

            End With

            Return strbToString.ToString()

        End Function

        Public Overrides Function GetHashCode() As Int32

            Dim intHashCode As Int32
            intHashCode = Me.PointID.GetHashCode()
            Return intHashCode

        End Function

        Public Overloads Function Equals(ByVal objPoint As Point) As Boolean

            Dim blnEquals As Boolean

            If ((Me.PointID = objPoint.PointID) _
                AndAlso (Me.GeographicCoordinateTypeID = objPoint.GeographicCoordinateTypeID) _
                AndAlso (Me.CoordinateZone = objPoint.CoordinateZone) _
                AndAlso (Me.GeometricTypeID = objPoint.GeometricTypeID) _
                AndAlso (Me.XCoordinate = objPoint.XCoordinate) _
                AndAlso (Me.YCoordinate = objPoint.YCoordinate) _
                AndAlso (Me.Elevation = objPoint.Elevation) _
                AndAlso (Me.UnitOfMeasurementID = objPoint.UnitOfMeasurementID) _
                AndAlso (Me.HorizontalCollectionMethodID = objPoint.HorizontalCollectionMethodID) _
                AndAlso (Me.HorizontalReferenceDatumID = objPoint.HorizontalReferenceDatumID) _
                AndAlso (Me.SourceMapScaleNumber = objPoint.SourceMapScaleNumber) _
                AndAlso (Me.CoordinateVerificationMethodID = objPoint.CoordinateVerificationMethodID) _
                AndAlso (Me.CoordinateDataSourceID = objPoint.CoordinateDataSourceID) _
                AndAlso (Me.HorizontalCollectionDate = objPoint.HorizontalCollectionDate) _
                AndAlso (Me.VerticalCollectionMethodID = objPoint.VerticalCollectionMethodID) _
                AndAlso (Me.VerticalReferenceDatumID = objPoint.VerticalReferenceDatumID) _
                AndAlso (Me.VerticalCollectionDate = objPoint.VerticalCollectionDate) _
                AndAlso (Me.GeographicPointComment = objPoint.GeographicPointComment) _
                AndAlso (Me.AddDate = objPoint.AddDate) _
                AndAlso (Me.AddedBy = objPoint.AddedBy)) Then
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
