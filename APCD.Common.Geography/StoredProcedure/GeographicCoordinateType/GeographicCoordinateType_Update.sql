USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[GeographicCoordinateType_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[GeographicCoordinateType_Update]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: GeographicCoordinateType_Update
Author: Mike Farris
Date: 11/01/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.GeographicCoordinateType_Update(
    @GeographicCoordinateTypeID    int,
    @GeographicCoordinateTypeName    varchar(80),
    @Comment    varchar(255)
)

AS

BEGIN

    UPDATE GeographicCoordinateType
    SET 
        GeographicCoordinateTypeName = @GeographicCoordinateTypeName,
        Comment = @Comment
    WHERE
        GeographicCoordinateTypeID = @GeographicCoordinateTypeID


END

RETURN

GO

