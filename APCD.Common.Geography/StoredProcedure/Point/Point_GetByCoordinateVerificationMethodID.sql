USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Point_GetByCoordinateVerificationMethodID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Point_GetByCoordinateVerificationMethodID]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: Point_GetByCoordinateVerificationMethodID
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records for the given CoordinateVerificationMethodID passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Point_GetByCoordinateVerificationMethodID
(
    @CoordinateVerificationMethodID    int
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
        CoordinateVerificationMethodID = @CoordinateVerificationMethodID

END

RETURN

GO

