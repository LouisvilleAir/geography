USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[VerticalCollectionMethod_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[VerticalCollectionMethod_Insert]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: VerticalCollectionMethod_Insert
Author: Mike Farris
Date: 11/01/2011
Description:  Inserts a record into the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.VerticalCollectionMethod_Insert(
    @VerticalCollectionMethodID    int,
    @VerticalCollectionMethodName    varchar(50),
    @VerticalCollectionMethodDescription    varchar(255)
)

AS

BEGIN

    INSERT INTO VerticalCollectionMethod
    (
        VerticalCollectionMethodID,
        VerticalCollectionMethodName,
        VerticalCollectionMethodDescription
    )
    VALUES
    (
        @VerticalCollectionMethodID,
        @VerticalCollectionMethodName,
        @VerticalCollectionMethodDescription
    )


END

RETURN

GO

