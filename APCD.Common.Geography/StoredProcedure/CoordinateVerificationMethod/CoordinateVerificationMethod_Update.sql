USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CoordinateVerificationMethod_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[CoordinateVerificationMethod_Update]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: CoordinateVerificationMethod_Update
Author: Mike Farris
Date: 11/01/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.CoordinateVerificationMethod_Update(
    @CoordinateVerificationMethodID    int,
    @CoordinateVerificationMethodName    varchar(50),
    @CoordinateVerificationMethodDescription    varchar(255)
)

AS

BEGIN

    UPDATE CoordinateVerificationMethod
    SET 
        CoordinateVerificationMethodName = @CoordinateVerificationMethodName,
        CoordinateVerificationMethodDescription = @CoordinateVerificationMethodDescription
    WHERE
        CoordinateVerificationMethodID = @CoordinateVerificationMethodID


END

RETURN

GO

