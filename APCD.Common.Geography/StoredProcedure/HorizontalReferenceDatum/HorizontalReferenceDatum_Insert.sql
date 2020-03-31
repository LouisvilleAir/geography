USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[HorizontalReferenceDatum_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HorizontalReferenceDatum_Insert]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: HorizontalReferenceDatum_Insert
Author: Mike Farris
Date: 11/01/2011
Description:  Inserts a record into the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.HorizontalReferenceDatum_Insert(
    @HorizontalReferenceDatumID    int,
    @HorizontalReferenceDatumName    varchar(100),
    @DatumAbbreviation    varchar(10),
    @DatumEPACode    varchar(3),
    @Comment    varchar(255)
)

AS

BEGIN

    INSERT INTO HorizontalReferenceDatum
    (
        HorizontalReferenceDatumID,
        HorizontalReferenceDatumName,
        DatumAbbreviation,
        DatumEPACode,
        Comment
    )
    VALUES
    (
        @HorizontalReferenceDatumID,
        @HorizontalReferenceDatumName,
        @DatumAbbreviation,
        @DatumEPACode,
        @Comment
    )


END

RETURN

GO

