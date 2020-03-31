USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CoordinateDataSource_GetAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[CoordinateDataSource_GetAll]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: CoordinateDataSource_GetAll
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records in the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.CoordinateDataSource_GetAll
AS

BEGIN

    SELECT 
        CoordinateDataSourceID,
        CoordinateDataSourceName,
        CoordinateDataSourceEISCode
    FROM CoordinateDataSource

END

RETURN

GO

