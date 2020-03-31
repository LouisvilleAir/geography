USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CoordinateVerificationMethod_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[CoordinateVerificationMethod_Insert]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: CoordinateVerificationMethod_Insert
Author: Mike Farris
Date: 11/01/2011
Description:  Inserts a record into the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.CoordinateVerificationMethod_Insert(
    @CoordinateVerificationMethodID    int,
    @CoordinateVerificationMethodName    varchar(50),
    @CoordinateVerificationMethodDescription    varchar(255)
)

AS

BEGIN

    INSERT INTO CoordinateVerificationMethod
    (
        CoordinateVerificationMethodID,
        CoordinateVerificationMethodName,
        CoordinateVerificationMethodDescription
    )
    VALUES
    (
        @CoordinateVerificationMethodID,
        @CoordinateVerificationMethodName,
        @CoordinateVerificationMethodDescription
    )


END

RETURN

GO

