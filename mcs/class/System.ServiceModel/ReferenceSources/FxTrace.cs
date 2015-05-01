//
// bare-bones based implementation based on the references
// from the Microsoft reference source code to get things to build
//
using System.Runtime;
using System.Runtime.Diagnostics;

namespace System.ServiceModel {
	internal static class FxTrace {
		public static EtwDiagnosticTrace Trace {
			get {
				return Fx.Trace;
			}
		}

		public static bool ShouldTraceCritical;
		public static bool ShouldTraceError;
		public static bool ShouldTraceWarning;
		public static bool ShouldTraceInformation;
		public static bool ShouldTraceVerbose;

		public static bool ShouldTraceCriticalToTraceSource;
		public static bool ShouldTraceErrorToTraceSource;
		public static bool ShouldTraceWarningToTraceSource;
		public static bool ShouldTraceInformationToTraceSource;
		public static bool ShouldTraceVerboseToTraceSource;

		static ExceptionTrace exception;
		public static ExceptionTrace Exception {
			get {
				if (exception == null)
					return new ExceptionTrace ("System.Runtime.Serialization", Trace);
				return exception;
			}
		}

		public static bool IsEventEnabled (int index)
		{
			return false;
		}

		public static void UpdateEventDefinitions (EventDescriptor [] ed, ushort [] events) {}
	}
}

