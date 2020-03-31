USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Point_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Point_GetByPrimaryKey]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: Point_GetByPrimaryKey
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Point_GetByPrimaryKey(
    @PointID    int
)

AS

BEGIN

    SELECT 
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
    FROM Point
    WHERE
        PointID = @PointID

END

RETURN

GO

