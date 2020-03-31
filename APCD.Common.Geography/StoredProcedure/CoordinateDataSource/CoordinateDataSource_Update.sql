USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CoordinateDataSource_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[CoordinateDataSource_Update]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: CoordinateDataSource_Update
Author: Mike Farris
Date: 11/01/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.CoordinateDataSource_Update(
    @CoordinateDataSourceID    int,
    @CoordinateDataSourceName    varchar(100),
    @CoordinateDataSourceEISCode    varchar(3)
)

AS

BEGIN

    UPDATE CoordinateDataSource
    SET 
        CoordinateDataSourceName = @CoordinateDataSourceName,
        CoordinateDataSourceEISCode = @CoordinateDataSourceEISCode
    WHERE
        CoordinateDataSourceID = @CoordinateDataSourceID


END

RETURN

GO

