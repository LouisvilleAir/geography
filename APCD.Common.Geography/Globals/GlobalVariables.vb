'***********************************************************************************************************************
'Assembly Name: APCD.Common.Geography
'Filename: GlobalVariables.vb
'Author: Mike Farris
'Date: 11/01/2011
'Description: Provides a central point to access global variables used by the class library.
'***********************************************************************************************************************
'----------------------------- Code Modifications/Additions ------------------------------------------------------------
'Date/Author                           Reason
'---------------------------------     ---------------------------------------------------------------------------------

'***********************************************************************************************************************
Namespace APCD.Geography.Globals

    <Serializable()> Public Class GlobalVariables

        Public Sub New()
            MyBase.New()
        End Sub

        '----- Property Variables -----
        Private Shared m_strConnectionString As String

        Public Shared Property ConnectionString() As String
            Get
                Return m_strConnectionString
            End Get
            Set(ByVal Value As String)
                m_strConnectionString = Value
            End Set
        End Property

#Region "----- User Defined Code -----"
#End Region '----- User Defined Code -----

    End Class

End Namespace
