USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Point_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Point_Insert]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: Point_Insert
Author: Mike Farris
Date: 11/01/2011
Description:  Inserts a record into the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Point_Insert(
    @PointID    int,
    @GeographicCoordinateTypeID    int,
    @CoordinateZone    int,
    @GeometricTypeID    int = null,
    @XCoordinate    decimal(19,9),
    @YCoordinate    decimal(19,9),
    @Elevation    decimal(9,3),
    @UnitOfMeasurementID    int,
    @HorizontalCollectionMethodID    int,
    @HorizontalReferenceDatumID    int,
    @SourceMapScaleNumber    int,
    @CoordinateVerificationMethodID    int,
    @CoordinateDataSourceID    int,
    @HorizontalCollectionDate    datetime,
    @VerticalCollectionMethodID    int,
    @VerticalReferenceDatumID    int,
    @VerticalCollectionDate    datetime,
    @GeographicPointComment    varchar(255),
    @AddDate    datetime,
    @AddedBy    int
)

AS

BEGIN

    INSERT INTO Point
    (
        PointID,
        GeographicCoordinateTypeID,
        CoordinateZone,
        GeometricTypeID,
        XCoordinate,
        YCoordinate,
        Elevation,
        UnitOfMeasurementID,
        HorizontalCollectionMethodID,
        HorizontalReferenceDatumID,
        SourceMapScaleNumber,
        CoordinateVerificationMethodID,
        CoordinateDataSourceID,
        HorizontalCollectionDate,
        VerticalCollectionMethodID,
        VerticalReferenceDatumID,
        VerticalCollectionDate,
        GeographicPointComment,
        AddDate,
        AddedBy
    )
    VALUES
    (
        @PointID,
        @GeographicCoordinateTypeID,
        @CoordinateZone,
        @GeometricTypeID,
        @XCoordinate,
        @YCoordinate,
        @Elevation,
        @UnitOfMeasurementID,
        @HorizontalCollectionMethodID,
        @HorizontalReferenceDatumID,
        @SourceMapScaleNumber,
        @CoordinateVerificationMethodID,
        @CoordinateDataSourceID,
        @HorizontalCollectionDate,
        @VerticalCollectionMethodID,
        @VerticalReferenceDatumID,
        @VerticalCollectionDate,
        @GeographicPointComment,
        @AddDate,
        @AddedBy
    )


END

RETURN

GO

