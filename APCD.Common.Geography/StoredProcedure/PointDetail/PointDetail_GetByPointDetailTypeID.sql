USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PointDetail_GetByPointDetailTypeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PointDetail_GetByPointDetailTypeID]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: PointDetail_GetByPointDetailTypeID
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records for the given PointDetailTypeID passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PointDetail_GetByPointDetailTypeID
(
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
        PointDetailTypeID = @PointDetailTypeID

END

RETURN

GO

