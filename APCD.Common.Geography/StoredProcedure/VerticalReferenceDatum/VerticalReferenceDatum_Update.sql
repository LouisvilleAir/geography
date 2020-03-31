USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[VerticalReferenceDatum_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[VerticalReferenceDatum_Update]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: VerticalReferenceDatum_Update
Author: Mike Farris
Date: 11/01/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.VerticalReferenceDatum_Update(
    @VerticalReferenceDatumID    int,
    @VerticalReferenceDatumName    varchar(100),
    @DatumAbbreviation    varchar(10)
)

AS

BEGIN

    UPDATE VerticalReferenceDatum
    SET 
        VerticalReferenceDatumName = @VerticalReferenceDatumName,
        DatumAbbreviation = @DatumAbbreviation
    WHERE
        VerticalReferenceDatumID = @VerticalReferenceDatumID


END

RETURN

GO

