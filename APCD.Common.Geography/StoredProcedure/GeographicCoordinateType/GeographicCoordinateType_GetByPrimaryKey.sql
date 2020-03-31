USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[GeographicCoordinateType_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[GeographicCoordinateType_GetByPrimaryKey]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: GeographicCoordinateType_GetByPrimaryKey
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.GeographicCoordinateType_GetByPrimaryKey(
    @GeographicCoordinateTypeID    int
)

AS

BEGIN

    SELECT 
        GeographicCoordinateTypeID,
        GeographicCoordinateTypeName,
        Comment
    FROM GeographicCoordinateType
    WHERE
        GeographicCoordinateTypeID = @GeographicCoordinateTypeID

END

RETURN

GO

