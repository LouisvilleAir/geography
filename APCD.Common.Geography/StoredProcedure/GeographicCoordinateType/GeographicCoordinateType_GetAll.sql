USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[GeographicCoordinateType_GetAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[GeographicCoordinateType_GetAll]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: GeographicCoordinateType_GetAll
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records in the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.GeographicCoordinateType_GetAll
AS

BEGIN

    SELECT 
        GeographicCoordinateTypeID,
        GeographicCoordinateTypeName,
        Comment
    FROM GeographicCoordinateType

END

RETURN

GO

