USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CoordinateVerificationMethod_GetLookupTable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[CoordinateVerificationMethod_GetLookupTable]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: CoordinateVerificationMethod_GetLookupTable
Author: Mike Farris
Date: 11/01/2011
Description:  Returns a lookup table sorted by the name of the field.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.CoordinateVerificationMethod_GetLookupTable
AS

BEGIN

    SELECT 
        CoordinateVerificationMethodID,
        CoordinateVerificationMethodName
    FROM CoordinateVerificationMethod
    ORDER BY CoordinateVerificationMethodName

END

RETURN

GO

