USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[HorizontalReferenceDatum_GetByLookupName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HorizontalReferenceDatum_GetByLookupName]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: HorizontalReferenceDatum_GetByLookupName
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given lookup name passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.HorizontalReferenceDatum_GetByLookupName(
    @HorizontalReferenceDatumName    varchar(100)
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
        HorizontalReferenceDatumName = @HorizontalReferenceDatumName

END

RETURN

GO

