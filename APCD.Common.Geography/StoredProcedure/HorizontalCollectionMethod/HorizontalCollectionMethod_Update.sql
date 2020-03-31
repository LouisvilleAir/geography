USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[HorizontalCollectionMethod_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HorizontalCollectionMethod_Update]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: HorizontalCollectionMethod_Update
Author: Mike Farris
Date: 11/01/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.HorizontalCollectionMethod_Update(
    @HorizontalCollectionMethodID    int,
    @HorizontalCollectionMethodName    varchar(100),
    @MethodEPACode    varchar(3),
    @Description    varchar(255)
)

AS

BEGIN

    UPDATE HorizontalCollectionMethod
    SET 
        HorizontalCollectionMethodName = @HorizontalCollectionMethodName,
        MethodEPACode = @MethodEPACode,
        Description = @Description
    WHERE
        HorizontalCollectionMethodID = @HorizontalCollectionMethodID


END

RETURN

GO

