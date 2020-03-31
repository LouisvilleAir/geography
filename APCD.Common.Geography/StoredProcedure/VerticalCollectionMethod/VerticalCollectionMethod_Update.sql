USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[VerticalCollectionMethod_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[VerticalCollectionMethod_Update]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: VerticalCollectionMethod_Update
Author: Mike Farris
Date: 11/01/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.VerticalCollectionMethod_Update(
    @VerticalCollectionMethodID    int,
    @VerticalCollectionMethodName    varchar(50),
    @VerticalCollectionMethodDescription    varchar(255)
)

AS

BEGIN

    UPDATE VerticalCollectionMethod
    SET 
        VerticalCollectionMethodName = @VerticalCollectionMethodName,
        VerticalCollectionMethodDescription = @VerticalCollectionMethodDescription
    WHERE
        VerticalCollectionMethodID = @VerticalCollectionMethodID


END

RETURN

GO

