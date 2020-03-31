USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[VerticalReferenceDatum_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[VerticalReferenceDatum_GetByPrimaryKey]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: VerticalReferenceDatum_GetByPrimaryKey
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.VerticalReferenceDatum_GetByPrimaryKey(
    @VerticalReferenceDatumID    int
)

AS

BEGIN

    SELECT 
        VerticalReferenceDatumID,
        VerticalReferenceDatumName,
        DatumAbbreviation
    FROM VerticalReferenceDatum
    WHERE
        VerticalReferenceDatumID = @VerticalReferenceDatumID

END

RETURN

GO

