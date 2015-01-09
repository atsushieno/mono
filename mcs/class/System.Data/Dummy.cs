static class AssemblyRef
{
	public const string SystemDesign = "System.Design";
	public const string SystemDrawing = "System.Drawing";
	public const string MicrosoftVSDesigner = "Mictosoft.VSDesigner";
	public const string EcmaPublicKey = "b77a5c561934e089"; 
	public const string EcmaPublicKeyFull = "00000000000000000400000000000000"; 
}

static class ThisAssembly
{
	public const string Version = "System.Xml";
	public const string InformationalVersion = null;
}

namespace System.Data
{
	class SNINativeMethodWrapper
	{
		public delegate void SqlAsyncCallbackDelegate (IntPtr arg0, IntPtr arg1, uint arg2);

		public class ConsumerInfo
		{
		}
	}
	
	class NativeOledbWrapper
	{
	}
	
	class Win32NativeMethods
	{
	}
	
	class ResCategoryAttribute : Attribute
	{
		public ResCategoryAttribute (string category)
		{
		}
	}
	
	class ResDescriptionAttribute : Attribute
	{
		public ResDescriptionAttribute (string category)
		{
		}
	}
}

namespace System.Data.OleDb
{
}
namespace System.Data.Odbc
{
}
namespace System.Data.Sql
{
}
namespace System.Data.SqlClient
{
}
namespace Microsoft.SqlServer
{
}
namespace Microsoft.SqlServer.Server
{
	#if false
    public enum Format { //: byte
        Unknown                    = 0,
        Native                     = 1,
        UserDefined                = 2,
    }
    #endif
}

#if false
// <copyright file="BidPrivateBase.cs" company="Microsoft">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
partial class Bid
{
    internal enum ApiGroup : uint
    {
        Off         = 0x00000000,

        Default     = 0x00000001,   // Bid.TraceEx (Always ON)
        Trace       = 0x00000002,   // Bid.Trace, Bid.PutStr
        Scope       = 0x00000004,   // Bid.Scope{Enter|Leave|Auto}
        Perf        = 0x00000008,   // TBD..
        Resource    = 0x00000010,   // TBD..
        Memory      = 0x00000020,   // TBD..
        StatusOk    = 0x00000040,   // S_OK, STATUS_SUCCESS, etc.
        Advanced    = 0x00000080,   // Bid.TraceEx

        Pooling     = 0x00001000,
        Dependency  = 0x00002000,
        StateDump   = 0x00004000,
        Correlation = 0x00040000,

        MaskBid     = 0x00000FFF,
        MaskUser    = 0xFFFFF000,
        MaskAll     = 0xFFFFFFFF
    }
}
#endif

