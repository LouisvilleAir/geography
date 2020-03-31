USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CoordinateDataSource_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[CoordinateDataSource_Insert]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: CoordinateDataSource_Insert
Author: Mike Farris
Date: 11/01/2011
Description:  Inserts a record into the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.CoordinateDataSource_Insert(
    @CoordinateDataSourceID    int,
    @CoordinateDataSourceName    varchar(100),
    @CoordinateDataSourceEISCode    varchar(3)
)

AS

BEGIN

    INSERT INTOCoordinateDataSource
    (
        CoordinateDataSourceID,
        CoordinateDataSourceName,
        CoordinateDataSourceEISCode
    )
    VALUES
    (
        @CoordinateDataSourceID,
        @CoordinateDataSourceName,
        @CoordinateDataSourceEISCode
    )


END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CoordinateDataSource_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[CoordinateDataSource_Update]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: CoordinateDataSource_Update
Author: Mike Farris
Date: 11/01/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.CoordinateDataSource_Update(
    @CoordinateDataSourceID    int,
    @CoordinateDataSourceName    varchar(100),
    @CoordinateDataSourceEISCode    varchar(3)
)

AS

BEGIN

    UPDATE CoordinateDataSource
    SET 
        CoordinateDataSourceName = @CoordinateDataSourceName,
        CoordinateDataSourceEISCode = @CoordinateDataSourceEISCode
    WHERE
        CoordinateDataSourceID = @CoordinateDataSourceID


END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CoordinateDataSource_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[CoordinateDataSource_Delete]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: CoordinateDataSource_Delete
Author: Mike Farris
Date: 11/01/2011
Description:  Deletes the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.CoordinateDataSource_Delete(
    @CoordinateDataSourceID    int
)

AS

BEGIN

    DELETE FROMCoordinateDataSource
    WHERE
        CoordinateDataSourceID = @CoordinateDataSourceID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CoordinateDataSource_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[CoordinateDataSource_GetByPrimaryKey]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: CoordinateDataSource_GetByPrimaryKey
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.CoordinateDataSource_GetByPrimaryKey(
    @CoordinateDataSourceID    int
)

AS

BEGIN

    SELECT 
        CoordinateDataSourceID,
        CoordinateDataSourceName,
        CoordinateDataSourceEISCode
    FROM CoordinateDataSource
    WHERE
        CoordinateDataSourceID = @CoordinateDataSourceID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CoordinateDataSource_GetAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[CoordinateDataSource_GetAll]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: CoordinateDataSource_GetAll
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records in the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.CoordinateDataSource_GetAll
AS

BEGIN

    SELECT 
        CoordinateDataSourceID,
        CoordinateDataSourceName,
        CoordinateDataSourceEISCode
    FROM CoordinateDataSource

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CoordinateDataSource_GetLookupTable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[CoordinateDataSource_GetLookupTable]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: CoordinateDataSource_GetLookupTable
Author: Mike Farris
Date: 11/01/2011
Description:  Returns a lookup table sorted by the name of the field.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.CoordinateDataSource_GetLookupTable
AS

BEGIN

    SELECT 
        CoordinateDataSourceID,
        CoordinateDataSourceName
    FROM CoordinateDataSource
    ORDER BY CoordinateDataSourceName

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CoordinateDataSource_GetByLookupName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[CoordinateDataSource_GetByLookupName]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: CoordinateDataSource_GetByLookupName
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given lookup name passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.CoordinateDataSource_GetByLookupName(
    @CoordinateDataSourceName    varchar(100)
)

AS

BEGIN

    SELECT 
        CoordinateDataSourceID,
        CoordinateDataSourceName,
        CoordinateDataSourceEISCode
    FROM CoordinateDataSource
    WHERE
        CoordinateDataSourceName = @CoordinateDataSourceName

END

RETURN

GO

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

    INSERT INTOCoordinateVerificationMethod
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

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CoordinateVerificationMethod_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[CoordinateVerificationMethod_Delete]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: CoordinateVerificationMethod_Delete
Author: Mike Farris
Date: 11/01/2011
Description:  Deletes the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.CoordinateVerificationMethod_Delete(
    @CoordinateVerificationMethodID    int
)

AS

BEGIN

    DELETE FROMCoordinateVerificationMethod
    WHERE
        CoordinateVerificationMethodID = @CoordinateVerificationMethodID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CoordinateVerificationMethod_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[CoordinateVerificationMethod_GetByPrimaryKey]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: CoordinateVerificationMethod_GetByPrimaryKey
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.CoordinateVerificationMethod_GetByPrimaryKey(
    @CoordinateVerificationMethodID    int
)

AS

BEGIN

    SELECT 
        CoordinateVerificationMethodID,
        CoordinateVerificationMethodName,
        CoordinateVerificationMethodDescription
    FROM CoordinateVerificationMethod
    WHERE
        CoordinateVerificationMethodID = @CoordinateVerificationMethodID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CoordinateVerificationMethod_GetAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[CoordinateVerificationMethod_GetAll]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: CoordinateVerificationMethod_GetAll
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records in the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.CoordinateVerificationMethod_GetAll
AS

BEGIN

    SELECT 
        CoordinateVerificationMethodID,
        CoordinateVerificationMethodName,
        CoordinateVerificationMethodDescription
    FROM CoordinateVerificationMethod

END

RETURN

GO

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

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CoordinateVerificationMethod_GetByLookupName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[CoordinateVerificationMethod_GetByLookupName]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: CoordinateVerificationMethod_GetByLookupName
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given lookup name passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.CoordinateVerificationMethod_GetByLookupName(
    @CoordinateVerificationMethodName    varchar(50)
)

AS

BEGIN

    SELECT 
        CoordinateVerificationMethodID,
        CoordinateVerificationMethodName,
        CoordinateVerificationMethodDescription
    FROM CoordinateVerificationMethod
    WHERE
        CoordinateVerificationMethodName = @CoordinateVerificationMethodName

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[GeographicCoordinateType_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[GeographicCoordinateType_Insert]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: GeographicCoordinateType_Insert
Author: Mike Farris
Date: 11/01/2011
Description:  Inserts a record into the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.GeographicCoordinateType_Insert(
    @GeographicCoordinateTypeID    int,
    @GeographicCoordinateTypeName    varchar(80),
    @Comment    varchar(255)
)

AS

BEGIN

    INSERT INTOGeographicCoordinateType
    (
        GeographicCoordinateTypeID,
        GeographicCoordinateTypeName,
        Comment
    )
    VALUES
    (
        @GeographicCoordinateTypeID,
        @GeographicCoordinateTypeName,
        @Comment
    )


END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[GeographicCoordinateType_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[GeographicCoordinateType_Update]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: GeographicCoordinateType_Update
Author: Mike Farris
Date: 11/01/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.GeographicCoordinateType_Update(
    @GeographicCoordinateTypeID    int,
    @GeographicCoordinateTypeName    varchar(80),
    @Comment    varchar(255)
)

AS

BEGIN

    UPDATE GeographicCoordinateType
    SET 
        GeographicCoordinateTypeName = @GeographicCoordinateTypeName,
        Comment = @Comment
    WHERE
        GeographicCoordinateTypeID = @GeographicCoordinateTypeID


END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[GeographicCoordinateType_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[GeographicCoordinateType_Delete]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: GeographicCoordinateType_Delete
Author: Mike Farris
Date: 11/01/2011
Description:  Deletes the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.GeographicCoordinateType_Delete(
    @GeographicCoordinateTypeID    int
)

AS

BEGIN

    DELETE FROMGeographicCoordinateType
    WHERE
        GeographicCoordinateTypeID = @GeographicCoordinateTypeID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[GeographicCoordinateType_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[GeographicCoordinateType_GetByPrimaryKey]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: GeographicCoordinateType_GetByPrimaryKey
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.GeographicCoordinateType_GetByPrimaryKey(
    @GeographicCoordinateTypeID    int
)

AS

BEGIN

    SELECT 
        GeographicCoordinateTypeID,
        GeographicCoordinateTypeName,
        Comment
    FROM GeographicCoordinateType
    WHERE
        GeographicCoordinateTypeID = @GeographicCoordinateTypeID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[GeographicCoordinateType_GetAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[GeographicCoordinateType_GetAll]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: GeographicCoordinateType_GetAll
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records in the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.GeographicCoordinateType_GetAll
AS

BEGIN

    SELECT 
        GeographicCoordinateTypeID,
        GeographicCoordinateTypeName,
        Comment
    FROM GeographicCoordinateType

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[GeographicCoordinateType_GetLookupTable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[GeographicCoordinateType_GetLookupTable]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: GeographicCoordinateType_GetLookupTable
Author: Mike Farris
Date: 11/01/2011
Description:  Returns a lookup table sorted by the name of the field.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.GeographicCoordinateType_GetLookupTable
AS

BEGIN

    SELECT 
        GeographicCoordinateTypeID,
        GeographicCoordinateTypeName
    FROM GeographicCoordinateType
    ORDER BY GeographicCoordinateTypeName

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[GeographicCoordinateType_GetByLookupName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[GeographicCoordinateType_GetByLookupName]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: GeographicCoordinateType_GetByLookupName
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given lookup name passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.GeographicCoordinateType_GetByLookupName(
    @GeographicCoordinateTypeName    varchar(80)
)

AS

BEGIN

    SELECT 
        GeographicCoordinateTypeID,
        GeographicCoordinateTypeName,
        Comment
    FROM GeographicCoordinateType
    WHERE
        GeographicCoordinateTypeName = @GeographicCoordinateTypeName

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[HorizontalCollectionMethod_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HorizontalCollectionMethod_Insert]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: HorizontalCollectionMethod_Insert
Author: Mike Farris
Date: 11/01/2011
Description:  Inserts a record into the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.HorizontalCollectionMethod_Insert(
    @HorizontalCollectionMethodID    int,
    @HorizontalCollectionMethodName    varchar(100),
    @MethodEPACode    varchar(3),
    @Description    varchar(255)
)

AS

BEGIN

    INSERT INTOHorizontalCollectionMethod
    (
        HorizontalCollectionMethodID,
        HorizontalCollectionMethodName,
        MethodEPACode,
        Description
    )
    VALUES
    (
        @HorizontalCollectionMethodID,
        @HorizontalCollectionMethodName,
        @MethodEPACode,
        @Description
    )


END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[HorizontalCollectionMethod_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HorizontalCollectionMethod_Update]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: HorizontalCollectionMethod_Update
Author: Mike Farris
Date: 11/01/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.HorizontalCollectionMethod_Update(
    @HorizontalCollectionMethodID    int,
    @HorizontalCollectionMethodName    varchar(100),
    @MethodEPACode    varchar(3),
    @Description    varchar(255)
)

AS

BEGIN

    UPDATE HorizontalCollectionMethod
    SET 
        HorizontalCollectionMethodName = @HorizontalCollectionMethodName,
        MethodEPACode = @MethodEPACode,
        Description = @Description
    WHERE
        HorizontalCollectionMethodID = @HorizontalCollectionMethodID


END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[HorizontalCollectionMethod_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HorizontalCollectionMethod_Delete]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: HorizontalCollectionMethod_Delete
Author: Mike Farris
Date: 11/01/2011
Description:  Deletes the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.HorizontalCollectionMethod_Delete(
    @HorizontalCollectionMethodID    int
)

AS

BEGIN

    DELETE FROMHorizontalCollectionMethod
    WHERE
        HorizontalCollectionMethodID = @HorizontalCollectionMethodID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[HorizontalCollectionMethod_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HorizontalCollectionMethod_GetByPrimaryKey]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: HorizontalCollectionMethod_GetByPrimaryKey
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.HorizontalCollectionMethod_GetByPrimaryKey(
    @HorizontalCollectionMethodID    int
)

AS

BEGIN

    SELECT 
        HorizontalCollectionMethodID,
        HorizontalCollectionMethodName,
        MethodEPACode,
        Description
    FROM HorizontalCollectionMethod
    WHERE
        HorizontalCollectionMethodID = @HorizontalCollectionMethodID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[HorizontalCollectionMethod_GetAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HorizontalCollectionMethod_GetAll]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: HorizontalCollectionMethod_GetAll
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records in the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.HorizontalCollectionMethod_GetAll
AS

BEGIN

    SELECT 
        HorizontalCollectionMethodID,
        HorizontalCollectionMethodName,
        MethodEPACode,
        Description
    FROM HorizontalCollectionMethod

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[HorizontalCollectionMethod_GetLookupTable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HorizontalCollectionMethod_GetLookupTable]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: HorizontalCollectionMethod_GetLookupTable
Author: Mike Farris
Date: 11/01/2011
Description:  Returns a lookup table sorted by the name of the field.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.HorizontalCollectionMethod_GetLookupTable
AS

BEGIN

    SELECT 
        HorizontalCollectionMethodID,
        HorizontalCollectionMethodName
    FROM HorizontalCollectionMethod
    ORDER BY HorizontalCollectionMethodName

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[HorizontalCollectionMethod_GetByLookupName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HorizontalCollectionMethod_GetByLookupName]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: HorizontalCollectionMethod_GetByLookupName
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given lookup name passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.HorizontalCollectionMethod_GetByLookupName(
    @HorizontalCollectionMethodName    varchar(100)
)

AS

BEGIN

    SELECT 
        HorizontalCollectionMethodID,
        HorizontalCollectionMethodName,
        MethodEPACode,
        Description
    FROM HorizontalCollectionMethod
    WHERE
        HorizontalCollectionMethodName = @HorizontalCollectionMethodName

END

RETURN

GO

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

    INSERT INTOHorizontalReferenceDatum
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

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[HorizontalReferenceDatum_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HorizontalReferenceDatum_Update]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: HorizontalReferenceDatum_Update
Author: Mike Farris
Date: 11/01/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.HorizontalReferenceDatum_Update(
    @HorizontalReferenceDatumID    int,
    @HorizontalReferenceDatumName    varchar(100),
    @DatumAbbreviation    varchar(10),
    @DatumEPACode    varchar(3),
    @Comment    varchar(255)
)

AS

BEGIN

    UPDATE HorizontalReferenceDatum
    SET 
        HorizontalReferenceDatumName = @HorizontalReferenceDatumName,
        DatumAbbreviation = @DatumAbbreviation,
        DatumEPACode = @DatumEPACode,
        Comment = @Comment
    WHERE
        HorizontalReferenceDatumID = @HorizontalReferenceDatumID


END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[HorizontalReferenceDatum_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HorizontalReferenceDatum_Delete]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: HorizontalReferenceDatum_Delete
Author: Mike Farris
Date: 11/01/2011
Description:  Deletes the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.HorizontalReferenceDatum_Delete(
    @HorizontalReferenceDatumID    int
)

AS

BEGIN

    DELETE FROMHorizontalReferenceDatum
    WHERE
        HorizontalReferenceDatumID = @HorizontalReferenceDatumID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[HorizontalReferenceDatum_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HorizontalReferenceDatum_GetByPrimaryKey]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: HorizontalReferenceDatum_GetByPrimaryKey
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.HorizontalReferenceDatum_GetByPrimaryKey(
    @HorizontalReferenceDatumID    int
)

AS

BEGIN

    SELECT 
        HorizontalReferenceDatumID,
        HorizontalReferenceDatumName,
        DatumAbbreviation,
        DatumEPACode,
        Comment
    FROM HorizontalReferenceDatum
    WHERE
        HorizontalReferenceDatumID = @HorizontalReferenceDatumID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[HorizontalReferenceDatum_GetAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HorizontalReferenceDatum_GetAll]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: HorizontalReferenceDatum_GetAll
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records in the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.HorizontalReferenceDatum_GetAll
AS

BEGIN

    SELECT 
        HorizontalReferenceDatumID,
        HorizontalReferenceDatumName,
        DatumAbbreviation,
        DatumEPACode,
        Comment
    FROM HorizontalReferenceDatum

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[HorizontalReferenceDatum_GetLookupTable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HorizontalReferenceDatum_GetLookupTable]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: HorizontalReferenceDatum_GetLookupTable
Author: Mike Farris
Date: 11/01/2011
Description:  Returns a lookup table sorted by the name of the field.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.HorizontalReferenceDatum_GetLookupTable
AS

BEGIN

    SELECT 
        HorizontalReferenceDatumID,
        HorizontalReferenceDatumName
    FROM HorizontalReferenceDatum
    ORDER BY HorizontalReferenceDatumName

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[HorizontalReferenceDatum_GetByLookupName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[HorizontalReferenceDatum_GetByLookupName]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: HorizontalReferenceDatum_GetByLookupName
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given lookup name passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.HorizontalReferenceDatum_GetByLookupName(
    @HorizontalReferenceDatumName    varchar(100)
)

AS

BEGIN

    SELECT 
        HorizontalReferenceDatumID,
        HorizontalReferenceDatumName,
        DatumAbbreviation,
        DatumEPACode,
        Comment
    FROM HorizontalReferenceDatum
    WHERE
        HorizontalReferenceDatumName = @HorizontalReferenceDatumName

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Point_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Point_Insert]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: Point_Insert
Author: Mike Farris
Date: 11/01/2011
Description:  Inserts a record into the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Point_Insert(
    @PointID    int,
    @GeographicCoordinateTypeID    int,
    @CoordinateZone    int,
    @GeometricTypeID    int = null,
    @XCoordinate    decimal(19,9),
    @YCoordinate    decimal(19,9),
    @Elevation    decimal(9,3),
    @UnitOfMeasurementID    int,
    @HorizontalCollectionMethodID    int,
    @HorizontalReferenceDatumID    int,
    @SourceMapScaleNumber    int,
    @CoordinateVerificationMethodID    int,
    @CoordinateDataSourceID    int,
    @HorizontalCollectionDate    datetime,
    @VerticalCollectionMethodID    int,
    @VerticalReferenceDatumID    int,
    @VerticalCollectionDate    datetime,
    @GeographicPointComment    varchar(255),
    @AddDate    datetime,
    @AddedBy    int
)

AS

BEGIN

    INSERT INTOPoint
    (
        PointID,
        GeographicCoordinateTypeID,
        CoordinateZone,
        GeometricTypeID,
        XCoordinate,
        YCoordinate,
        Elevation,
        UnitOfMeasurementID,
        HorizontalCollectionMethodID,
        HorizontalReferenceDatumID,
        SourceMapScaleNumber,
        CoordinateVerificationMethodID,
        CoordinateDataSourceID,
        HorizontalCollectionDate,
        VerticalCollectionMethodID,
        VerticalReferenceDatumID,
        VerticalCollectionDate,
        GeographicPointComment,
        AddDate,
        AddedBy
    )
    VALUES
    (
        @PointID,
        @GeographicCoordinateTypeID,
        @CoordinateZone,
        @GeometricTypeID,
        @XCoordinate,
        @YCoordinate,
        @Elevation,
        @UnitOfMeasurementID,
        @HorizontalCollectionMethodID,
        @HorizontalReferenceDatumID,
        @SourceMapScaleNumber,
        @CoordinateVerificationMethodID,
        @CoordinateDataSourceID,
        @HorizontalCollectionDate,
        @VerticalCollectionMethodID,
        @VerticalReferenceDatumID,
        @VerticalCollectionDate,
        @GeographicPointComment,
        @AddDate,
        @AddedBy
    )


END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Point_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Point_Update]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: Point_Update
Author: Mike Farris
Date: 11/01/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Point_Update(
    @PointID    int,
    @GeographicCoordinateTypeID    int,
    @CoordinateZone    int,
    @GeometricTypeID    int = null,
    @XCoordinate    decimal(19,9),
    @YCoordinate    decimal(19,9),
    @Elevation    decimal(9,3),
    @UnitOfMeasurementID    int,
    @HorizontalCollectionMethodID    int,
    @HorizontalReferenceDatumID    int,
    @SourceMapScaleNumber    int,
    @CoordinateVerificationMethodID    int,
    @CoordinateDataSourceID    int,
    @HorizontalCollectionDate    datetime,
    @VerticalCollectionMethodID    int,
    @VerticalReferenceDatumID    int,
    @VerticalCollectionDate    datetime,
    @GeographicPointComment    varchar(255),
    @AddDate    datetime,
    @AddedBy    int
)

AS

BEGIN

    UPDATE Point
    SET 
        GeographicCoordinateTypeID = @GeographicCoordinateTypeID,
        CoordinateZone = @CoordinateZone,
        GeometricTypeID = @GeometricTypeID,
        XCoordinate = @XCoordinate,
        YCoordinate = @YCoordinate,
        Elevation = @Elevation,
        UnitOfMeasurementID = @UnitOfMeasurementID,
        HorizontalCollectionMethodID = @HorizontalCollectionMethodID,
        HorizontalReferenceDatumID = @HorizontalReferenceDatumID,
        SourceMapScaleNumber = @SourceMapScaleNumber,
        CoordinateVerificationMethodID = @CoordinateVerificationMethodID,
        CoordinateDataSourceID = @CoordinateDataSourceID,
        HorizontalCollectionDate = @HorizontalCollectionDate,
        VerticalCollectionMethodID = @VerticalCollectionMethodID,
        VerticalReferenceDatumID = @VerticalReferenceDatumID,
        VerticalCollectionDate = @VerticalCollectionDate,
        GeographicPointComment = @GeographicPointComment,
        AddDate = @AddDate,
        AddedBy = @AddedBy
    WHERE
        PointID = @PointID


END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Point_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Point_Delete]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: Point_Delete
Author: Mike Farris
Date: 11/01/2011
Description:  Deletes the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Point_Delete(
    @PointID    int
)

AS

BEGIN

    DELETE FROMPoint
    WHERE
        PointID = @PointID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Point_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Point_GetByPrimaryKey]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: Point_GetByPrimaryKey
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Point_GetByPrimaryKey(
    @PointID    int
)

AS

BEGIN

    SELECT 
        PointID,
        GeographicCoordinateTypeID,
        CoordinateZone,
        GeometricTypeID,
        XCoordinate,
        YCoordinate,
        Elevation,
        UnitOfMeasurementID,
        HorizontalCollectionMethodID,
        HorizontalReferenceDatumID,
        SourceMapScaleNumber,
        CoordinateVerificationMethodID,
        CoordinateDataSourceID,
        HorizontalCollectionDate,
        VerticalCollectionMethodID,
        VerticalReferenceDatumID,
        VerticalCollectionDate,
        GeographicPointComment,
        AddDate,
        AddedBy
    FROM Point
    WHERE
        PointID = @PointID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Point_GetAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Point_GetAll]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: Point_GetAll
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records in the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Point_GetAll
AS

BEGIN

    SELECT 
        PointID,
        GeographicCoordinateTypeID,
        CoordinateZone,
        GeometricTypeID,
        XCoordinate,
        YCoordinate,
        Elevation,
        UnitOfMeasurementID,
        HorizontalCollectionMethodID,
        HorizontalReferenceDatumID,
        SourceMapScaleNumber,
        CoordinateVerificationMethodID,
        CoordinateDataSourceID,
        HorizontalCollectionDate,
        VerticalCollectionMethodID,
        VerticalReferenceDatumID,
        VerticalCollectionDate,
        GeographicPointComment,
        AddDate,
        AddedBy
    FROM Point

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Point_GetByCoordinateDataSourceID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Point_GetByCoordinateDataSourceID]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: Point_GetByCoordinateDataSourceID
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records for the given CoordinateDataSourceID passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Point_GetByCoordinateDataSourceID
(
    @CoordinateDataSourceID    int
)

AS

BEGIN

    SELECT 
        PointID,
        GeographicCoordinateTypeID,
        CoordinateZone,
        GeometricTypeID,
        XCoordinate,
        YCoordinate,
        Elevation,
        UnitOfMeasurementID,
        HorizontalCollectionMethodID,
        HorizontalReferenceDatumID,
        SourceMapScaleNumber,
        CoordinateVerificationMethodID,
        CoordinateDataSourceID,
        HorizontalCollectionDate,
        VerticalCollectionMethodID,
        VerticalReferenceDatumID,
        VerticalCollectionDate,
        GeographicPointComment,
        AddDate,
        AddedBy
    FROM Point
    WHERE
        CoordinateDataSourceID = @CoordinateDataSourceID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Point_GetByCoordinateVerificationMethodID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Point_GetByCoordinateVerificationMethodID]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: Point_GetByCoordinateVerificationMethodID
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records for the given CoordinateVerificationMethodID passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Point_GetByCoordinateVerificationMethodID
(
    @CoordinateVerificationMethodID    int
)

AS

BEGIN

    SELECT 
        PointID,
        GeographicCoordinateTypeID,
        CoordinateZone,
        GeometricTypeID,
        XCoordinate,
        YCoordinate,
        Elevation,
        UnitOfMeasurementID,
        HorizontalCollectionMethodID,
        HorizontalReferenceDatumID,
        SourceMapScaleNumber,
        CoordinateVerificationMethodID,
        CoordinateDataSourceID,
        HorizontalCollectionDate,
        VerticalCollectionMethodID,
        VerticalReferenceDatumID,
        VerticalCollectionDate,
        GeographicPointComment,
        AddDate,
        AddedBy
    FROM Point
    WHERE
        CoordinateVerificationMethodID = @CoordinateVerificationMethodID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Point_GetByGeographicCoordinateTypeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Point_GetByGeographicCoordinateTypeID]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: Point_GetByGeographicCoordinateTypeID
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records for the given GeographicCoordinateTypeID passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Point_GetByGeographicCoordinateTypeID
(
    @GeographicCoordinateTypeID    int
)

AS

BEGIN

    SELECT 
        PointID,
        GeographicCoordinateTypeID,
        CoordinateZone,
        GeometricTypeID,
        XCoordinate,
        YCoordinate,
        Elevation,
        UnitOfMeasurementID,
        HorizontalCollectionMethodID,
        HorizontalReferenceDatumID,
        SourceMapScaleNumber,
        CoordinateVerificationMethodID,
        CoordinateDataSourceID,
        HorizontalCollectionDate,
        VerticalCollectionMethodID,
        VerticalReferenceDatumID,
        VerticalCollectionDate,
        GeographicPointComment,
        AddDate,
        AddedBy
    FROM Point
    WHERE
        GeographicCoordinateTypeID = @GeographicCoordinateTypeID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Point_GetByHorizontalCollectionMethodID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Point_GetByHorizontalCollectionMethodID]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: Point_GetByHorizontalCollectionMethodID
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records for the given HorizontalCollectionMethodID passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Point_GetByHorizontalCollectionMethodID
(
    @HorizontalCollectionMethodID    int
)

AS

BEGIN

    SELECT 
        PointID,
        GeographicCoordinateTypeID,
        CoordinateZone,
        GeometricTypeID,
        XCoordinate,
        YCoordinate,
        Elevation,
        UnitOfMeasurementID,
        HorizontalCollectionMethodID,
        HorizontalReferenceDatumID,
        SourceMapScaleNumber,
        CoordinateVerificationMethodID,
        CoordinateDataSourceID,
        HorizontalCollectionDate,
        VerticalCollectionMethodID,
        VerticalReferenceDatumID,
        VerticalCollectionDate,
        GeographicPointComment,
        AddDate,
        AddedBy
    FROM Point
    WHERE
        HorizontalCollectionMethodID = @HorizontalCollectionMethodID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Point_GetByHorizontalReferenceDatumID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Point_GetByHorizontalReferenceDatumID]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: Point_GetByHorizontalReferenceDatumID
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records for the given HorizontalReferenceDatumID passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Point_GetByHorizontalReferenceDatumID
(
    @HorizontalReferenceDatumID    int
)

AS

BEGIN

    SELECT 
        PointID,
        GeographicCoordinateTypeID,
        CoordinateZone,
        GeometricTypeID,
        XCoordinate,
        YCoordinate,
        Elevation,
        UnitOfMeasurementID,
        HorizontalCollectionMethodID,
        HorizontalReferenceDatumID,
        SourceMapScaleNumber,
        CoordinateVerificationMethodID,
        CoordinateDataSourceID,
        HorizontalCollectionDate,
        VerticalCollectionMethodID,
        VerticalReferenceDatumID,
        VerticalCollectionDate,
        GeographicPointComment,
        AddDate,
        AddedBy
    FROM Point
    WHERE
        HorizontalReferenceDatumID = @HorizontalReferenceDatumID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Point_GetByVerticalCollectionMethodID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Point_GetByVerticalCollectionMethodID]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: Point_GetByVerticalCollectionMethodID
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records for the given VerticalCollectionMethodID passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Point_GetByVerticalCollectionMethodID
(
    @VerticalCollectionMethodID    int
)

AS

BEGIN

    SELECT 
        PointID,
        GeographicCoordinateTypeID,
        CoordinateZone,
        GeometricTypeID,
        XCoordinate,
        YCoordinate,
        Elevation,
        UnitOfMeasurementID,
        HorizontalCollectionMethodID,
        HorizontalReferenceDatumID,
        SourceMapScaleNumber,
        CoordinateVerificationMethodID,
        CoordinateDataSourceID,
        HorizontalCollectionDate,
        VerticalCollectionMethodID,
        VerticalReferenceDatumID,
        VerticalCollectionDate,
        GeographicPointComment,
        AddDate,
        AddedBy
    FROM Point
    WHERE
        VerticalCollectionMethodID = @VerticalCollectionMethodID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Point_GetByVerticalReferenceDatumID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[Point_GetByVerticalReferenceDatumID]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: Point_GetByVerticalReferenceDatumID
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records for the given VerticalReferenceDatumID passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.Point_GetByVerticalReferenceDatumID
(
    @VerticalReferenceDatumID    int
)

AS

BEGIN

    SELECT 
        PointID,
        GeographicCoordinateTypeID,
        CoordinateZone,
        GeometricTypeID,
        XCoordinate,
        YCoordinate,
        Elevation,
        UnitOfMeasurementID,
        HorizontalCollectionMethodID,
        HorizontalReferenceDatumID,
        SourceMapScaleNumber,
        CoordinateVerificationMethodID,
        CoordinateDataSourceID,
        HorizontalCollectionDate,
        VerticalCollectionMethodID,
        VerticalReferenceDatumID,
        VerticalCollectionDate,
        GeographicPointComment,
        AddDate,
        AddedBy
    FROM Point
    WHERE
        VerticalReferenceDatumID = @VerticalReferenceDatumID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PointDetail_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PointDetail_Insert]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: PointDetail_Insert
Author: Mike Farris
Date: 11/01/2011
Description:  Inserts a record into the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PointDetail_Insert(
    @PointID    int,
    @PointDetailTypeID    int,
    @PointDetailValue    float,
    @UnitOfMeasurementID    int,
    @AddDate    datetime,
    @AddedBy    int
)

AS

BEGIN

    INSERT INTOPointDetail
    (
        PointID,
        PointDetailTypeID,
        PointDetailValue,
        UnitOfMeasurementID,
        AddDate,
        AddedBy
    )
    VALUES
    (
        @PointID,
        @PointDetailTypeID,
        @PointDetailValue,
        @UnitOfMeasurementID,
        @AddDate,
        @AddedBy
    )


END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PointDetail_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PointDetail_Update]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: PointDetail_Update
Author: Mike Farris
Date: 11/01/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PointDetail_Update(
    @PointID    int,
    @PointDetailTypeID    int,
    @PointDetailValue    float,
    @UnitOfMeasurementID    int,
    @AddDate    datetime,
    @AddedBy    int
)

AS

BEGIN

    UPDATE PointDetail
    SET 
        PointDetailValue = @PointDetailValue,
        UnitOfMeasurementID = @UnitOfMeasurementID,
        AddDate = @AddDate,
        AddedBy = @AddedBy
    WHERE
        PointID = @PointID
        AND     PointDetailTypeID = @PointDetailTypeID


END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PointDetail_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PointDetail_Delete]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: PointDetail_Delete
Author: Mike Farris
Date: 11/01/2011
Description:  Deletes the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PointDetail_Delete(
    @PointID    int,
    @PointDetailTypeID    int
)

AS

BEGIN

    DELETE FROMPointDetail
    WHERE
        PointID = @PointID
        AND     PointDetailTypeID = @PointDetailTypeID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PointDetail_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PointDetail_GetByPrimaryKey]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: PointDetail_GetByPrimaryKey
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PointDetail_GetByPrimaryKey(
    @PointID    int,
    @PointDetailTypeID    int
)

AS

BEGIN

    SELECT 
        PointID,
        PointDetailTypeID,
        PointDetailValue,
        UnitOfMeasurementID,
        AddDate,
        AddedBy
    FROM PointDetail
    WHERE
        PointID = @PointID
        AND     PointDetailTypeID = @PointDetailTypeID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PointDetail_GetAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PointDetail_GetAll]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: PointDetail_GetAll
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records in the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PointDetail_GetAll
AS

BEGIN

    SELECT 
        PointID,
        PointDetailTypeID,
        PointDetailValue,
        UnitOfMeasurementID,
        AddDate,
        AddedBy
    FROM PointDetail

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PointDetail_GetByPointID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PointDetail_GetByPointID]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: PointDetail_GetByPointID
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records for the given PointID passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PointDetail_GetByPointID
(
    @PointID    int
)

AS

BEGIN

    SELECT 
        PointID,
        PointDetailTypeID,
        PointDetailValue,
        UnitOfMeasurementID,
        AddDate,
        AddedBy
    FROM PointDetail
    WHERE
        PointID = @PointID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PointDetail_GetByPointDetailTypeID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PointDetail_GetByPointDetailTypeID]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: PointDetail_GetByPointDetailTypeID
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records for the given PointDetailTypeID passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PointDetail_GetByPointDetailTypeID
(
    @PointDetailTypeID    int
)

AS

BEGIN

    SELECT 
        PointID,
        PointDetailTypeID,
        PointDetailValue,
        UnitOfMeasurementID,
        AddDate,
        AddedBy
    FROM PointDetail
    WHERE
        PointDetailTypeID = @PointDetailTypeID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PointDetailType_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PointDetailType_Insert]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: PointDetailType_Insert
Author: Mike Farris
Date: 11/01/2011
Description:  Inserts a record into the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PointDetailType_Insert(
    @PointDetailTypeID    int,
    @PointDetailTypeName    varchar(100)
)

AS

BEGIN

    INSERT INTOPointDetailType
    (
        PointDetailTypeID,
        PointDetailTypeName
    )
    VALUES
    (
        @PointDetailTypeID,
        @PointDetailTypeName
    )


END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PointDetailType_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PointDetailType_Update]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: PointDetailType_Update
Author: Mike Farris
Date: 11/01/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PointDetailType_Update(
    @PointDetailTypeID    int,
    @PointDetailTypeName    varchar(100)
)

AS

BEGIN

    UPDATE PointDetailType
    SET 
        PointDetailTypeName = @PointDetailTypeName
    WHERE
        PointDetailTypeID = @PointDetailTypeID


END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PointDetailType_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PointDetailType_Delete]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: PointDetailType_Delete
Author: Mike Farris
Date: 11/01/2011
Description:  Deletes the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PointDetailType_Delete(
    @PointDetailTypeID    int
)

AS

BEGIN

    DELETE FROMPointDetailType
    WHERE
        PointDetailTypeID = @PointDetailTypeID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PointDetailType_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PointDetailType_GetByPrimaryKey]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: PointDetailType_GetByPrimaryKey
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PointDetailType_GetByPrimaryKey(
    @PointDetailTypeID    int
)

AS

BEGIN

    SELECT 
        PointDetailTypeID,
        PointDetailTypeName
    FROM PointDetailType
    WHERE
        PointDetailTypeID = @PointDetailTypeID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[PointDetailType_GetAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[PointDetailType_GetAll]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: PointDetailType_GetAll
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records in the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.PointDetailType_GetAll
AS

BEGIN

    SELECT 
        PointDetailTypeID,
        PointDetailTypeName
    FROM PointDetailType

END

RETURN

GO

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

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_Insert]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: sysdiagrams_Insert
Author: Mike Farris
Date: 11/01/2011
Description:  Inserts a record into the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_Insert(
    @name    nvarchar(256),
    @principal_id    int,
    @diagram_id    int OUTPUT,
    @version    int = null,
    @definition    varbinary = null
)

AS

BEGIN

    INSERT INTOsysdiagrams
    (
        name,
        principal_id,
        version,
        definition
    )
    VALUES
    (
        @name,
        @principal_id,
        @version,
        @definition
    )


END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_Update]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: sysdiagrams_Update
Author: Mike Farris
Date: 11/01/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_Update(
    @name    nvarchar(256),
    @principal_id    int,
    @diagram_id    int,
    @version    int = null,
    @definition    varbinary = null
)

AS

BEGIN

    UPDATE sysdiagrams
    SET 
        principal_id = @principal_id,
        diagram_id = @diagram_id,
        version = @version,
        definition = @definition
    WHERE
        name = @name


END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_Delete]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: sysdiagrams_Delete
Author: Mike Farris
Date: 11/01/2011
Description:  Deletes the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_Delete(
    @name    nvarchar(256)
)

AS

BEGIN

    DELETE FROMsysdiagrams
    WHERE
        name = @name

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_GetByPrimaryKey]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: sysdiagrams_GetByPrimaryKey
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_GetByPrimaryKey(
    @name    nvarchar(256)
)

AS

BEGIN

    SELECT 
        name,
        principal_id,
        diagram_id,
        version,
        definition
    FROM sysdiagrams
    WHERE
        name = @name

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_GetAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_GetAll]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: sysdiagrams_GetAll
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records in the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_GetAll
AS

BEGIN

    SELECT 
        name,
        principal_id,
        diagram_id,
        version,
        definition
    FROM sysdiagrams

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_GetByprincipal_id_name]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_GetByprincipal_id_name]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: sysdiagrams_GetByprincipal_id_name
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records for the given (principal_id, name) passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_GetByprincipal_id_name
(
    @principal_id    int,
    @name    nvarchar(256)
)

AS

BEGIN

    SELECT 
        name,
        principal_id,
        diagram_id,
        version,
        definition
    FROM sysdiagrams
    WHERE
        principal_id = @principal_id
        AND name = @name
END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_GetByprincipal_id]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_GetByprincipal_id]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: sysdiagrams_GetByprincipal_id
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records for the given principal_id passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_GetByprincipal_id
(
    @principal_id    int
)

AS

BEGIN

    SELECT 
        name,
        principal_id,
        diagram_id,
        version,
        definition
    FROM sysdiagrams
    WHERE
        principal_id = @principal_id

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[sysdiagrams_GetByname]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[sysdiagrams_GetByname]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: sysdiagrams_GetByname
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records for the given name passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.sysdiagrams_GetByname
(
    @name    nvarchar(256)
)

AS

BEGIN

    SELECT 
        name,
        principal_id,
        diagram_id,
        version,
        definition
    FROM sysdiagrams
    WHERE
        name = @name

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[VerticalCollectionMethod_Insert]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[VerticalCollectionMethod_Insert]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: VerticalCollectionMethod_Insert
Author: Mike Farris
Date: 11/01/2011
Description:  Inserts a record into the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.VerticalCollectionMethod_Insert(
    @VerticalCollectionMethodID    int,
    @VerticalCollectionMethodName    varchar(50),
    @VerticalCollectionMethodDescription    varchar(255)
)

AS

BEGIN

    INSERT INTOVerticalCollectionMethod
    (
        VerticalCollectionMethodID,
        VerticalCollectionMethodName,
        VerticalCollectionMethodDescription
    )
    VALUES
    (
        @VerticalCollectionMethodID,
        @VerticalCollectionMethodName,
        @VerticalCollectionMethodDescription
    )


END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[VerticalCollectionMethod_Update]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[VerticalCollectionMethod_Update]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: VerticalCollectionMethod_Update
Author: Mike Farris
Date: 11/01/2011
Description:  Updates the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.VerticalCollectionMethod_Update(
    @VerticalCollectionMethodID    int,
    @VerticalCollectionMethodName    varchar(50),
    @VerticalCollectionMethodDescription    varchar(255)
)

AS

BEGIN

    UPDATE VerticalCollectionMethod
    SET 
        VerticalCollectionMethodName = @VerticalCollectionMethodName,
        VerticalCollectionMethodDescription = @VerticalCollectionMethodDescription
    WHERE
        VerticalCollectionMethodID = @VerticalCollectionMethodID


END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[VerticalCollectionMethod_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[VerticalCollectionMethod_Delete]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: VerticalCollectionMethod_Delete
Author: Mike Farris
Date: 11/01/2011
Description:  Deletes the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.VerticalCollectionMethod_Delete(
    @VerticalCollectionMethodID    int
)

AS

BEGIN

    DELETE FROMVerticalCollectionMethod
    WHERE
        VerticalCollectionMethodID = @VerticalCollectionMethodID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[VerticalCollectionMethod_GetByPrimaryKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[VerticalCollectionMethod_GetByPrimaryKey]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: VerticalCollectionMethod_GetByPrimaryKey
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.VerticalCollectionMethod_GetByPrimaryKey(
    @VerticalCollectionMethodID    int
)

AS

BEGIN

    SELECT 
        VerticalCollectionMethodID,
        VerticalCollectionMethodName,
        VerticalCollectionMethodDescription
    FROM VerticalCollectionMethod
    WHERE
        VerticalCollectionMethodID = @VerticalCollectionMethodID

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[VerticalCollectionMethod_GetAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[VerticalCollectionMethod_GetAll]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: VerticalCollectionMethod_GetAll
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records in the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.VerticalCollectionMethod_GetAll
AS

BEGIN

    SELECT 
        VerticalCollectionMethodID,
        VerticalCollectionMethodName,
        VerticalCollectionMethodDescription
    FROM VerticalCollectionMethod

END

RETURN

GO

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

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[VerticalCollectionMethod_GetByLookupName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[VerticalCollectionMethod_GetByLookupName]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: VerticalCollectionMethod_GetByLookupName
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given lookup name passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.VerticalCollectionMethod_GetByLookupName(
    @VerticalCollectionMethodName    varchar(50)
)

AS

BEGIN

    SELECT 
        VerticalCollectionMethodID,
        VerticalCollectionMethodName,
        VerticalCollectionMethodDescription
    FROM VerticalCollectionMethod
    WHERE
        VerticalCollectionMethodName = @VerticalCollectionMethodName

END

RETURN

GO

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

    INSERT INTOVerticalReferenceDatum
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

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[VerticalReferenceDatum_Delete]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[VerticalReferenceDatum_Delete]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: VerticalReferenceDatum_Delete
Author: Mike Farris
Date: 11/01/2011
Description:  Deletes the record with the given primary key passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.VerticalReferenceDatum_Delete(
    @VerticalReferenceDatumID    int
)

AS

BEGIN

    DELETE FROMVerticalReferenceDatum
    WHERE
        VerticalReferenceDatumID = @VerticalReferenceDatumID

END

RETURN

GO

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

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[VerticalReferenceDatum_GetAll]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[VerticalReferenceDatum_GetAll]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: VerticalReferenceDatum_GetAll
Author: Mike Farris
Date: 11/01/2011
Description:  Returns all of the records in the table.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.VerticalReferenceDatum_GetAll
AS

BEGIN

    SELECT 
        VerticalReferenceDatumID,
        VerticalReferenceDatumName,
        DatumAbbreviation
    FROM VerticalReferenceDatum

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[VerticalReferenceDatum_GetLookupTable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[VerticalReferenceDatum_GetLookupTable]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: VerticalReferenceDatum_GetLookupTable
Author: Mike Farris
Date: 11/01/2011
Description:  Returns a lookup table sorted by the name of the field.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.VerticalReferenceDatum_GetLookupTable
AS

BEGIN

    SELECT 
        VerticalReferenceDatumID,
        VerticalReferenceDatumName
    FROM VerticalReferenceDatum
    ORDER BY VerticalReferenceDatumName

END

RETURN

GO

USE Geography

GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[VerticalReferenceDatum_GetByLookupName]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[VerticalReferenceDatum_GetByLookupName]

GO

USE Geography

GO

SET ANSI_NULLS ON
SET QUOTED_IDENTIFIER ON

GO

/************************************************************************************************************************************
Database Name: Geography
Procedure Name: VerticalReferenceDatum_GetByLookupName
Author: Mike Farris
Date: 11/01/2011
Description:  Returns the record for the given lookup name passed in.

Example: EXEC 

===================================================  Code Modifications/Additions  ===================================================
Date/Author                                   Reason
=========================================     ========================================================================================

**************************************************************************************************************************************/

CREATE PROCEDURE dbo.VerticalReferenceDatum_GetByLookupName(
    @VerticalReferenceDatumName    varchar(100)
)

AS

BEGIN

    SELECT 
        VerticalReferenceDatumID,
        VerticalReferenceDatumName,
        DatumAbbreviation
    FROM VerticalReferenceDatum
    WHERE
        VerticalReferenceDatumName = @VerticalReferenceDatumName

END

RETURN

GO

