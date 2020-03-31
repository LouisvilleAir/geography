USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[HorizontalReferenceDatum_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HorizontalReferenceDatum_Delete]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: HorizontalReferenceDatum_Delete
Author: Mike Farris
Date: 11/01/2011
Description:  Deletes the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.HorizontalReferenceDatum_Delete(
    @HorizontalReferenceDatumID    int
)

AS

BEGIN

    DELETE FROM HorizontalReferenceDatum
    WHERE
        HorizontalReferenceDatumID = @HorizontalReferenceDatumID

END

RETURN

GO

