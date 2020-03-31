USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PointDetail_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PointDetail_Insert]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: PointDetail_Insert
Author: Mike Farris
Date: 11/01/2011
Description:  Inserts a record into the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PointDetail_Insert(
    @PointID    int,
    @PointDetailTypeID    int,
    @PointDetailValue    float,
    @UnitOfMeasurementID    int,
    @AddDate    datetime,
    @AddedBy    int
)

AS

BEGIN

    INSERT INTO PointDetail
    (
        PointID,
        PointDetailTypeID,
        PointDetailValue,
        UnitOfMeasurementID,
        AddDate,
        AddedBy
    )
    VALUES
    (
        @PointID,
        @PointDetailTypeID,
        @PointDetailValue,
        @UnitOfMeasurementID,
        @AddDate,
        @AddedBy
    )


END

RETURN

GO

