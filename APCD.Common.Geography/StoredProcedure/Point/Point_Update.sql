USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Point_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Point_Update]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: Point_Update
Author: Mike Farris
Date: 11/01/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Point_Update(
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

    UPDATE Point
    SET 
        GeographicCoordinateTypeID = @GeographicCoordinateTypeID,
        CoordinateZone = @CoordinateZone,
        GeometricTypeID = @GeometricTypeID,
        XCoordinate = @XCoordinate,
        YCoordinate = @YCoordinate,
        Elevation = @Elevation,
        UnitOfMeasurementID = @UnitOfMeasurementID,
        HorizontalCollectionMethodID = @HorizontalCollectionMethodID,
        HorizontalReferenceDatumID = @HorizontalReferenceDatumID,
        SourceMapScaleNumber = @SourceMapScaleNumber,
        CoordinateVerificationMethodID = @CoordinateVerificationMethodID,
        CoordinateDataSourceID = @CoordinateDataSourceID,
        HorizontalCollectionDate = @HorizontalCollectionDate,
        VerticalCollectionMethodID = @VerticalCollectionMethodID,
        VerticalReferenceDatumID = @VerticalReferenceDatumID,
        VerticalCollectionDate = @VerticalCollectionDate,
        GeographicPointComment = @GeographicPointComment,
        AddDate = @AddDate,
        AddedBy = @AddedBy
    WHERE
        PointID = @PointID


END

RETURN

GO

