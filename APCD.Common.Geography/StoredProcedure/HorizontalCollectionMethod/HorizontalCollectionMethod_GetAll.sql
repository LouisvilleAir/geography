USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[HorizontalCollectionMethod_GetAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HorizontalCollectionMethod_GetAll]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: HorizontalCollectionMethod_GetAll
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records in the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.HorizontalCollectionMethod_GetAll
AS

BEGIN

    SELECT 
        HorizontalCollectionMethodID,
        HorizontalCollectionMethodName,
        MethodEPACode,
        Description
    FROM HorizontalCollectionMethod

END

RETURN

GO

