using System.Diagnostics;
using System.Runtime;

namespace System.ServiceModel {

	internal static class DiagnosticUtility {
		internal static bool ShouldTrace;
		internal static bool ShouldTraceError;
		internal static bool ShouldTraceWarning;
		internal static bool ShouldTraceInformation;
		internal static bool ShouldTraceVerbose;
		
		internal static bool ShouldUseActivity;
		internal static int Level;
		internal static EventLog EventLog;

		internal static class DiagnosticTrace {
			internal static void TraceEvent (params object [] args)
			{
			}
			
		}
		
		internal static class ExceptionUtility {
			internal static Exception ThrowHelperError (Exception e)
			{
				return ThrowHelper (e, TraceEventType.Error);
			}

			internal static Exception ThrowHelperCallback (string msg, Exception e)
			{
				return new CallbackException (msg, e);
			}

			internal static Exception ThrowHelperCallback (Exception e)
			{
				return new CallbackException ("Callback exception", e);
			}

			internal static Exception ThrowHelper (Exception e, TraceEventType type)
			{
				return e;
			}

			internal static Exception ThrowHelperArgument (string arg)
			{
				return new ArgumentException (arg);
			}

			internal static Exception ThrowHelperArgument (string arg, string message)
			{
				return new ArgumentException (message, arg);
			}

			internal static Exception ThrowHelperArgumentNull (string arg)
			{
				return new ArgumentNullException (arg);
			}

			internal static Exception ThrowHelperFatal (string msg, Exception e)
			{
				return new FatalException (msg, e);
			}

			internal static Exception ThrowHelperCritical (Exception e)
			{
				return e;
			}

			internal static Exception ThrowHelperWarning (Exception e)
			{
				return e;
			}
		}
		
		internal static class Utility {
			public static byte [] AllocateByteArray (int size)
			{
				return new byte [size];
			}
			public static char [] AllocateCharArray (int size)
			{
				return new char [size];
			}
		}
		
		public static void DebugAssert (bool value, string message)
		{
#if DEBUG
			if (!value)
				throw new SystemException (message);
#endif
		}
		
		public static void TraceHandledException (Exception exception, TraceEventType type)
		{
		}
		
		public static void FailFast (string message)
		{
			throw new Exception (message);
		}
	}
}

