USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PointDetailType_GetByLookupName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PointDetailType_GetByLookupName]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: PointDetailType_GetByLookupName
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given lookup name passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PointDetailType_GetByLookupName(
    @PointDetailTypeName    varchar(100)
)

AS

BEGIN

    SELECT 
        PointDetailTypeID,
        PointDetailTypeName
    FROM PointDetailType
    WHERE
        PointDetailTypeName = @PointDetailTypeName

END

RETURN

GO

