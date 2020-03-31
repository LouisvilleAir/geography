USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[HorizontalCollectionMethod_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HorizontalCollectionMethod_GetByPrimaryKey]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: HorizontalCollectionMethod_GetByPrimaryKey
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.HorizontalCollectionMethod_GetByPrimaryKey(
    @HorizontalCollectionMethodID    int
)

AS

BEGIN

    SELECT 
        HorizontalCollectionMethodID,
        HorizontalCollectionMethodName,
        MethodEPACode,
        Description
    FROM HorizontalCollectionMethod
    WHERE
        HorizontalCollectionMethodID = @HorizontalCollectionMethodID

END

RETURN

GO

