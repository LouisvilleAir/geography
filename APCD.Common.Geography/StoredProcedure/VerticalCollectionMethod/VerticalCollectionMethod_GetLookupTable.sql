USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[VerticalCollectionMethod_GetLookupTable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[VerticalCollectionMethod_GetLookupTable]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: VerticalCollectionMethod_GetLookupTable
Author: Mike Farris
Date: 11/01/2011
Description:  Returns a lookup table sorted by the name of the field.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.VerticalCollectionMethod_GetLookupTable
AS

BEGIN

    SELECT 
        VerticalCollectionMethodID,
        VerticalCollectionMethodName
    FROM VerticalCollectionMethod
    ORDER BY VerticalCollectionMethodName

END

RETURN

GO

