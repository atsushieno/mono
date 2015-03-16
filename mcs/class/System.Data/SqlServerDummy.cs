using System;

class StreamDataFeed
{
}
class TextDataFeed
{
}
class ParameterPeekAheadValue
{
}
class TdsParser
{
	public bool TryPlpBytesLeft (object a, object b)
	{
		throw new NotImplementedException ();
	}
}
class TdsParserStateObject
{
	public bool TryReadPlpBytes (ref byte [] arr, int i, int cb, out int cbOut)
	{
		throw new NotImplementedException ();
	}
	public long _longlen, _longlenleft;
}
class SqlMetaDataPriv
{
	public class MetaType
	{
		public bool IsPlp {
			get { throw new NotImplementedException (); }
		}
	}

	internal MetaType metaType = new MetaType (); 
}
