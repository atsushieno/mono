//----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------------------
namespace System.IdentityModel
{
    using System.Diagnostics;
    using System.Reflection;
    using System.Runtime;
    using System.Runtime.CompilerServices;
    using System.Runtime.Diagnostics;
    using System.Threading;
    using System.Security;
    using System.Xml;
    using System.Globalization;
    using System.Collections.Generic;
    using System.IdentityModel.Diagnostics;

    using DiagnosticTrace = System.IdentityModel.Diagnostics.TraceUtility;

    static partial class DiagnosticUtility
    {
		public static class Utility
		{
			public static byte[] AllocateByteArray(int size)
			{
				return System.Runtime.Fx.AllocateByteArray (size);
			}
		}

		// FIXME: implement?
		public static SomeTraceType DiagnosticTrace { get; set; }

		public class SomeTraceType
		{
			public bool ShouldLogPii { get; set; }
			public TraceSource TraceSource { get; set; }
			internal void TraceEvent (params object [] args)
			{
			}
		}

		public static bool ShouldTraceError { get; set; }
		public static bool ShouldTraceWarning { get; set; }
		public static bool ShouldTraceInformation { get; set; }
		public static bool ShouldTraceVerbose { get; set; }

		// FIXME: implement in expected way.
		public static void DebugAssert(string format = null, params object[] parameters)
		{
	#if DEBUG
			throw new Exception (format, parameters);
	#endif
		}
		
		// FIXME: implement in expected way.
		public static void DebugAssert(bool condition, string format = null, params object[] parameters)
		{
	#if DEBUG
			format = format ?? "Runtime error: should not occur at application level";
			if (!condition)
				throw new Exception (format, parameters);
	#endif
		}

			public static bool ShouldTrace(TraceEventLevel level)
			{
				return ShouldTraceToTraceSource(level);
			}

			public static bool ShouldTrace(TraceEventType type)
			{
			// FIXME: implement
			return false;
			}

			public static bool ShouldTraceToTraceSource(TraceEventLevel level)
			{
				return ShouldTrace(TraceLevelHelper.GetTraceEventType(level));
			}


		public static class ExceptionUtility
		{
			internal static Exception ThrowHelperWarning(Exception exception)
			{
			return exception;
			}

		internal static Exception ThrowHelperError(Exception exception)
		{
			return exception;
		}

	/*
			internal static Exception ThrowHelperError(Exception exception, Guid activityId, object source)
			{
				if (DiagnosticUtility.ShouldTraceError)
				{
					DiagnosticTrace.TraceEvent(TraceEventType.Error, TraceCode.ThrowingException, GenerateMsdnTraceCode(TraceCode.ThrowingException),
						TraceSR.GetString(TraceSR.ThrowingException), null, exception, activityId, source);
				}
				return exception;
			}
	*/



			internal static ArgumentException ThrowHelperArgument(string message)
			{
				return new ArgumentException (message);
			}

			internal static ArgumentException ThrowHelperArgument(string paramName, string message)
			{
				return new ArgumentException (message, paramName);
			}

			internal static ArgumentNullException ThrowHelperArgumentNull(string paramName, string message = null)
			{
				return message != null ? new ArgumentNullException (paramName, message) : new ArgumentNullException (paramName);
			}

			internal static ArgumentNullException ThrowHelperArgumentNullOrEmptyString(string paramName)
			{
				return new ArgumentNullException ("Parameter is either null or empty string.", paramName);
			}

			internal static XmlException ThrowHelperXml(XmlReader reader, string message)
			{
				var li = reader as IXmlLineInfo;
				return li != null && li.HasLineInfo () ? new XmlException (message, null, li.LineNumber, li.LinePosition) : new XmlException (message);
			}

			internal static CallbackException ThrowHelperCallback(string message, Exception innerException)
			{
				return new CallbackException (message, innerException);
			}

			internal static Exception ThrowHelper(Exception ex, TraceEventType eventType)
			{
				return ex;
			}
		}

        public static void TraceHandledException(Exception exception, TraceEventType traceEventType)
        {
		throw new NotImplementedException ();
        }
        
        // FIXME: implement correctly(?)
        internal static void FailFast(string message)
        {
			throw new Exception (message);
		}
    }
    
    static class DummyExtensions
    {
		public static bool Contains (this System.Security.Authentication.ExtendedProtection.ServiceNameCollection coll, string searchServiceName)
		{
			foreach (var o in coll)
				if ((o as string) == searchServiceName)
					return true;
			return false;
		}
	}
}
