USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[HorizontalCollectionMethod_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HorizontalCollectionMethod_Insert]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: HorizontalCollectionMethod_Insert
Author: Mike Farris
Date: 11/01/2011
Description:  Inserts a record into the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.HorizontalCollectionMethod_Insert(
    @HorizontalCollectionMethodID    int,
    @HorizontalCollectionMethodName    varchar(100),
    @MethodEPACode    varchar(3),
    @Description    varchar(255)
)

AS

BEGIN

    INSERT INTO HorizontalCollectionMethod
    (
        HorizontalCollectionMethodID,
        HorizontalCollectionMethodName,
        MethodEPACode,
        Description
    )
    VALUES
    (
        @HorizontalCollectionMethodID,
        @HorizontalCollectionMethodName,
        @MethodEPACode,
        @Description
    )


END

RETURN

GO

