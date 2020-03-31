USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PointDetail_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PointDetail_GetByPrimaryKey]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: PointDetail_GetByPrimaryKey
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PointDetail_GetByPrimaryKey(
    @PointID    int,
    @PointDetailTypeID    int
)

AS

BEGIN

    SELECT 
        PointID,
        PointDetailTypeID,
        PointDetailValue,
        UnitOfMeasurementID,
        AddDate,
        AddedBy
    FROM PointDetail
    WHERE
        PointID = @PointID
        AND     PointDetailTypeID = @PointDetailTypeID

END

RETURN

GO

