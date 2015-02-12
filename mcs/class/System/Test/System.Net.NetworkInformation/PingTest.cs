using NUnit.Framework;
using System;
using System.Net.NetworkInformation;

namespace MonoTests.System.Net.NetworkInformation
{
	[TestFixture]
	public class PingTest
	{
		[Test] 
		public void PingFail()
		{
			var p = new Ping ().Send ("192.0.2.0");
			Assert.AreNotEqual(IPStatus.Success, p.Status);
		}

		[Test] 
		public void PingSuccess()
		{
#if MONOTOUCH
#if XAMCORE_2_0
			if (ObjCRuntime.Runtime.Arch == ObjCRuntime.Arch.SIMULATOR)
#else
			if (MonoTouch.ObjCRuntime.Runtime.Arch == MonoTouch.ObjCRuntime.Arch.SIMULATOR)
#endif
				Assert.Ignore ("dyld: program was built for Mac OS X and cannot be run in simulator");
#endif
			var p = new Ping ().Send ("127.0.0.1");
			Assert.AreEqual(IPStatus.Success, p.Status);
		}		
	}
}

