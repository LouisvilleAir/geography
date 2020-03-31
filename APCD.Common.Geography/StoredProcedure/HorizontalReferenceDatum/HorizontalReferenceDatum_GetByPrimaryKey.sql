USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[HorizontalReferenceDatum_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HorizontalReferenceDatum_GetByPrimaryKey]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: HorizontalReferenceDatum_GetByPrimaryKey
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.HorizontalReferenceDatum_GetByPrimaryKey(
    @HorizontalReferenceDatumID    int
)

AS

BEGIN

    SELECT 
        HorizontalReferenceDatumID,
        HorizontalReferenceDatumName,
        DatumAbbreviation,
        DatumEPACode,
        Comment
    FROM HorizontalReferenceDatum
    WHERE
        HorizontalReferenceDatumID = @HorizontalReferenceDatumID

END

RETURN

GO

