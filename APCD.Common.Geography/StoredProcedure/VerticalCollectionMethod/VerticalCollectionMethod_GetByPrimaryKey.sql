USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[VerticalCollectionMethod_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[VerticalCollectionMethod_GetByPrimaryKey]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: VerticalCollectionMethod_GetByPrimaryKey
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.VerticalCollectionMethod_GetByPrimaryKey(
    @VerticalCollectionMethodID    int
)

AS

BEGIN

    SELECT 
        VerticalCollectionMethodID,
        VerticalCollectionMethodName,
        VerticalCollectionMethodDescription
    FROM VerticalCollectionMethod
    WHERE
        VerticalCollectionMethodID = @VerticalCollectionMethodID

END

RETURN

GO

