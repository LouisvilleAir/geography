USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[HorizontalCollectionMethod_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HorizontalCollectionMethod_Delete]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: HorizontalCollectionMethod_Delete
Author: Mike Farris
Date: 11/01/2011
Description:  Deletes the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.HorizontalCollectionMethod_Delete(
    @HorizontalCollectionMethodID    int
)

AS

BEGIN

    DELETE FROM HorizontalCollectionMethod
    WHERE
        HorizontalCollectionMethodID = @HorizontalCollectionMethodID

END

RETURN

GO

