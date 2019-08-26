using System;
using System.IO;

namespace WindowsApplication2
{
	/// <summary>
	/// Summary description for ImportRaw.
	/// </summary>
	/// 
	public class MapMeta
	{
		public MemoryStream RawFromBeginningofSndtoEndofMode;
		public MemoryStream RawFromBeginningofDECRtoEndofJmad;
		public MemoryStream RawFromUnicodetoEndofBitmap;
		public MemoryStream RawFromBSP;
		public MemoryStream MetaFromIndexHeaderToEnd;
		public int RawFromBeginningofSndtoEndofModeSize;
		public int RawFromBeginningofDECRtoEndofJmadSize;
		public int RawFromUnicodetoEndofBitmapSize;
		public int RawFromBSPSize;
		public int MetaFromIndexHeaderToEndSize;

		public MemoryStream BSPRaw;
		public int BSPRawSize;
	}
	public class ImportRaw
	{
			public int sndchunk4loc;
			public int sndchunk4size;

			public int[] sndchunk5loc=new int[1000];
			public int[] sndchunk5size=new int[1000];
			public int sndchunk5count;

			public int[]	rawloc=new int[1000];
			public int[]	rawoff=new int[1000];
			public int[]	rawsize=new	int[1000];
			public int[]	rawmap=new int[10000];
			public int[]	rawpad=new int[1000];
			public int rawcount;

			public int[]	sbsprawpad1=new int[1000];
			public int[]	sbsprawpad2=new int[1000];
			public int[]	sbsprawpad3=new int[1000];
			public int[]	sbsprawpad4=new int[1000];
			


		public ImportRaw()
		{
		
		}

		
	}
}
