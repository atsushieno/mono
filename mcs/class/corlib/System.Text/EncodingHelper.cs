using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System.Text
{

internal static class EncodingHelper
{
	//
	// Only internal, to be used by the class libraries: Unmarked and non-input-validating
	//
	internal static Encoding UTF8Unmarked {
		get {
			if (utf8EncodingWithoutMarkers == null) {
				lock (lockobj){
					if (utf8EncodingWithoutMarkers == null){
						utf8EncodingWithoutMarkers = new UTF8Encoding (false, false);
//						utf8EncodingWithoutMarkers.is_readonly = true;
					}
				}
			}

			return utf8EncodingWithoutMarkers;
		}
	}
	
	//
	// Only internal, to be used by the class libraries: Unmarked and non-input-validating
	//
	internal static Encoding UTF8UnmarkedUnsafe {
		get {
			if (utf8EncodingUnsafe == null) {
				lock (lockobj){
					if (utf8EncodingUnsafe == null){
						utf8EncodingUnsafe = new UTF8Encoding (false, false);
						typeof (Encoding).GetField ("m_isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance).SetValue (utf8EncodingUnsafe, false);
						utf8EncodingUnsafe.DecoderFallback = new DecoderReplacementFallback (String.Empty);
						typeof (Encoding).GetField ("m_isReadOnly", BindingFlags.NonPublic | BindingFlags.Instance).SetValue (utf8EncodingUnsafe, true);
					}
				}
			}

			return utf8EncodingUnsafe;
		}
	}

	// Get the standard big-endian UTF-32 encoding object.
	internal static Encoding BigEndianUTF32
	{
		get {
			if (bigEndianUTF32Encoding == null) {
				lock (lockobj) {
					if (bigEndianUTF32Encoding == null) {
						bigEndianUTF32Encoding = new UTF32Encoding (true, true);
//						bigEndianUTF32Encoding.is_readonly = true;
					}
				}
			}

			return bigEndianUTF32Encoding;
		}
	}
	static volatile Encoding utf8EncodingWithoutMarkers;
	static volatile Encoding utf8EncodingUnsafe;
	static volatile Encoding bigEndianUTF32Encoding;
	static readonly object lockobj = new object ();

	[MethodImpl (MethodImplOptions.InternalCall)]
	extern internal static string InternalCodePage (ref int code_page);

	internal static Encoding GetDefaultEncoding ()
	{
		Encoding enc = null;
						// See if the underlying system knows what
						// code page handler we should be using.
						int code_page = 1;
						
						string code_page_name = InternalCodePage (ref code_page);
						try {
							if (code_page == -1)
								enc = Encoding.GetEncoding (code_page_name);
							else {
								// map the codepage from internal to our numbers
								code_page = code_page & 0x0fffffff;
								switch (code_page){
								case 1: code_page = 20127; break; // ASCIIEncoding.ASCII_CODE_PAGE
								case 2: code_page = 65007; break; // UTF7Encoding.UTF7_CODE_PAGE
								case 3: code_page = 65001; break; // UTF8Encoding.UTF8_CODE_PAGE
								case 4: code_page = 1200; break; // UnicodeEncoding.UNICODE_CODE_PAGE
								case 5: code_page = 1201; break; // UnicodeEncoding.BIG_UNICODE_CODE_PAGE
								case 6: code_page = 1252; break; // Latin1Encoding.ISOLATIN_CODE_PAGE
								}
								enc = Encoding.GetEncoding (code_page);
							}
						} catch (NotSupportedException) {
							// code_page is not supported on underlying platform
							enc = EncodingHelper.UTF8Unmarked;
						} catch (ArgumentException) {
							// code_page_name is not a valid code page, or is 
							// not supported by underlying OS
							enc = EncodingHelper.UTF8Unmarked;
						}
		return enc;
	}
}

}