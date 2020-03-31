USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PointDetailType_GetLookupTable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PointDetailType_GetLookupTable]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: PointDetailType_GetLookupTable
Author: Mike Farris
Date: 11/01/2011
Description:  Returns a lookup table sorted by the name of the field.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PointDetailType_GetLookupTable
AS

BEGIN

    SELECT 
        PointDetailTypeID,
        PointDetailTypeName
    FROM PointDetailType
    ORDER BY PointDetailTypeName

END

RETURN

GO

