USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PointDetail_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PointDetail_Update]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: PointDetail_Update
Author: Mike Farris
Date: 11/01/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PointDetail_Update(
    @PointID    int,
    @PointDetailTypeID    int,
    @PointDetailValue    float,
    @UnitOfMeasurementID    int,
    @AddDate    datetime,
    @AddedBy    int
)

AS

BEGIN

    UPDATE PointDetail
    SET 
        PointDetailValue = @PointDetailValue,
        UnitOfMeasurementID = @UnitOfMeasurementID,
        AddDate = @AddDate,
        AddedBy = @AddedBy
    WHERE
        PointID = @PointID
        AND     PointDetailTypeID = @PointDetailTypeID


END

RETURN

GO

