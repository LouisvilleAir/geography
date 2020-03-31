USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CoordinateDataSource_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[CoordinateDataSource_Insert]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: CoordinateDataSource_Insert
Author: Mike Farris
Date: 11/01/2011
Description:  Inserts a record into the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.CoordinateDataSource_Insert(
    @CoordinateDataSourceID    int,
    @CoordinateDataSourceName    varchar(100),
    @CoordinateDataSourceEISCode    varchar(3)
)

AS

BEGIN

    INSERT INTO CoordinateDataSource
    (
        CoordinateDataSourceID,
        CoordinateDataSourceName,
        CoordinateDataSourceEISCode
    )
    VALUES
    (
        @CoordinateDataSourceID,
        @CoordinateDataSourceName,
        @CoordinateDataSourceEISCode
    )


END

RETURN

GO

