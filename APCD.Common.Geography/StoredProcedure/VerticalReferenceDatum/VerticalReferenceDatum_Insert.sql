USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[VerticalReferenceDatum_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[VerticalReferenceDatum_Insert]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: VerticalReferenceDatum_Insert
Author: Mike Farris
Date: 11/01/2011
Description:  Inserts a record into the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.VerticalReferenceDatum_Insert(
    @VerticalReferenceDatumID    int,
    @VerticalReferenceDatumName    varchar(100),
    @DatumAbbreviation    varchar(10)
)

AS

BEGIN

    INSERT INTO VerticalReferenceDatum
    (
        VerticalReferenceDatumID,
        VerticalReferenceDatumName,
        DatumAbbreviation
    )
    VALUES
    (
        @VerticalReferenceDatumID,
        @VerticalReferenceDatumName,
        @DatumAbbreviation
    )


END

RETURN

GO

