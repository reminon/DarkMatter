using System;
using System.Collections;

namespace WindowsApplication2
{
	/// <summary>
	/// Summary description for Helpers.
	/// </summary>
	public class Helpers
	{
		public Helpers()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		public int GetPaddingSize(int size)
		{
			int oldsize=size;
			decimal crap=decimal.Remainder(oldsize,512);
			int oldpages=oldsize/512;
			if (crap>0){oldpages++;}
			int oldtotalsize=Convert.ToInt32(oldpages)*512;
			int oldpadding=oldtotalsize-oldsize;
			return oldpadding;
		}

		public void ParseRawPointer(ref int pointer, ref int map)
		{
			byte[] test=new	byte[4];
			BitArray crap=new BitArray(new int[] {pointer});
			string oi=""; int yy;
			for	(yy=31;yy>29;yy--)
			{
				if (crap[yy].ToString()=="False"){oi=oi+"0";} 
				else {oi=oi+"1";}
				crap[yy]=false;
			}
			crap.CopyTo(test,0);
			pointer=BitConverter.ToInt32(test,0);

			if (oi=="00"){map=0;}
			if (oi=="01"){map=1;}
			if (oi=="10"){map=2;}
			if (oi=="11"){map=3;}
		}

	}
	
}
