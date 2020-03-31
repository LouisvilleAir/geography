USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Point_GetAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Point_GetAll]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: Point_GetAll
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records in the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Point_GetAll
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

END

RETURN

GO

