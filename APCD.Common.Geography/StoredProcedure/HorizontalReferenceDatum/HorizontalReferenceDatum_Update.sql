USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[HorizontalReferenceDatum_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HorizontalReferenceDatum_Update]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: HorizontalReferenceDatum_Update
Author: Mike Farris
Date: 11/01/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.HorizontalReferenceDatum_Update(
    @HorizontalReferenceDatumID    int,
    @HorizontalReferenceDatumName    varchar(100),
    @DatumAbbreviation    varchar(10),
    @DatumEPACode    varchar(3),
    @Comment    varchar(255)
)

AS

BEGIN

    UPDATE HorizontalReferenceDatum
    SET 
        HorizontalReferenceDatumName = @HorizontalReferenceDatumName,
        DatumAbbreviation = @DatumAbbreviation,
        DatumEPACode = @DatumEPACode,
        Comment = @Comment
    WHERE
        HorizontalReferenceDatumID = @HorizontalReferenceDatumID


END

RETURN

GO

