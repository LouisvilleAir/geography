USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[GeographicCoordinateType_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[GeographicCoordinateType_Insert]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: GeographicCoordinateType_Insert
Author: Mike Farris
Date: 11/01/2011
Description:  Inserts a record into the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.GeographicCoordinateType_Insert(
    @GeographicCoordinateTypeID    int,
    @GeographicCoordinateTypeName    varchar(80),
    @Comment    varchar(255)
)

AS

BEGIN

    INSERT INTO GeographicCoordinateType
    (
        GeographicCoordinateTypeID,
        GeographicCoordinateTypeName,
        Comment
    )
    VALUES
    (
        @GeographicCoordinateTypeID,
        @GeographicCoordinateTypeName,
        @Comment
    )


END

RETURN

GO

