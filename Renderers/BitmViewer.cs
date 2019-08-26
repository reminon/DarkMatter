using System;
using System.Drawing;
using System.Drawing.Imaging;
//using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using sharedstuff.RawData;
//using System.IO;
using System.Runtime.InteropServices;
using imageshit;


public class Swizzle
{
	public enum SwizzleType : byte
	{
		Swizzle = 0,

		DeSwizzle = 1,

	}

	public int m_MaskX = 0;
	public int m_MaskY = 0;
	public int m_MaskZ = 0;
	public void New(int width, int height, int depth)
	{
		int bit = 1;
		int idx = 1;

		while ((bit < width) | (bit < height) | (bit < depth))
		{
			if (bit < width) 
			{
				m_MaskX = m_MaskX | idx;
				idx <<= 1;
			}

			if (bit < height)
			{
				m_MaskY = m_MaskY | idx;
				idx <<= 1;
			}

			if (bit < depth) 
			{
				m_MaskZ = m_MaskZ | idx;
				idx <<= 1;
			}

			bit <<= 1;
		}
	}

	public Swizzle(int width, int height, int depth)
	{
		m_MaskX = 0;
		m_MaskY = 0;
		m_MaskZ = 0;
		int i = 1;
		int j = 1;
		for (i=1;i < width | i < height | i < depth; i<<=1)
		{
			if (i < width)
			{
				m_MaskX |= j;
				j<<=1;
				}
			if (i < height)
			{
				m_MaskY |= j;
				j<<=1;
				}
			if (i < depth)
			{
				m_MaskZ |= j;
				j<<=11;
				}
		}
	}


	public int Swizzlex(int Sx, int Sy, int Sz)
	{
		int Swizzlexxx = SwizzleAxis(Sx, m_MaskX) | SwizzleAxis(Sy, m_MaskY) | ((Sz != -1)? SwizzleAxis(Sz, m_MaskZ): 0);
		return Swizzlexxx ; 
	}

	   public int SwizzleAxis(int Value, int Mask)
        {
		  int result=0;   
			int bit=1;
          while (bit <= Mask)
		  {
            if ((Mask & bit) != 0)
            {
              result |= Value & bit;
            }
            else
            {
              Value<<=1;
            }
			  bit<<=1;
          }
          return result;
        }

}

namespace imageshit
{
















	public class decode
	{
				

ImageLib il=new ImageLib();

		public byte[] DecodeDXT1(int height, int width, byte[] SourceData)
		{
			byte[] DestData;
			imageshit.ImageLib.RGBA_COLOR_STRUCT[] Color=new imageshit.ImageLib.RGBA_COLOR_STRUCT[5];
			int i;
			int dptr=0;
			imageshit.ImageLib.RGBA_COLOR_STRUCT CColor;
			int CData;
			int ChunksPerHLine = width / 4;
			bool trans;
			imageshit.ImageLib.RGBA_COLOR_STRUCT zeroColor;
			int c1, c2;
			DestData=new byte[((width * height) * 4)];
			if (ChunksPerHLine == 0) { ChunksPerHLine += 1; }
			for (i = 0;i<(width * height);i+=16)
			{
				c1 =(SourceData[dptr + 1] << 8) | (SourceData[dptr]);
				c2 = (SourceData[dptr + 3] << 8) | (SourceData[dptr + 2]);
		
				if (c1 > c2)
				{
					trans = false;
				}
				else
				{
					trans = true;
				}
				Color[0] = il.short_to_rgba(c1);
				Color[1] = il.short_to_rgba(c2);
				if (!trans)
				{
					Color[2] = il.GradientColors(Color[0], Color[1]);
					Color[3] = il.GradientColors(Color[1], Color[0]);
				}
				else
				{
					zeroColor=Color[0];
					Color[2] = il.GradientColorsHalf(Color[0], Color[1]);
					Color[3] = zeroColor;
				}
				CData = (SourceData[dptr + 4] << 0) | (SourceData[dptr + 5] << 8) |(SourceData[dptr + 6] << 16) | (SourceData[dptr + 7] << 24);
				int ChunkNum = i / 16;
				long XPos = ChunkNum % ChunksPerHLine;
				long YPos = (ChunkNum - XPos) / ChunksPerHLine;
				long ttmp;
				long ttmp2;
				int sizeh = height < 4 ? height : 4;
				int sizew = width < 4 ? width : 4;
				int x,y;
				for (x = 0;x<sizeh;x++)
				{
					for (y = 0;y<sizew;y++)
					{
									
						CColor = Color[CData & 3];
						CData >>= 2;
						ttmp = ((YPos * 4 + x) * width + XPos * 4 + y) * 4;
						ttmp2 = il.rgba_to_int(CColor);
						DestData[ttmp] = Convert.ToByte(CColor.b);
						DestData[ttmp + 1] = Convert.ToByte(CColor.g);
						DestData[ttmp + 2] = Convert.ToByte(CColor.r);
						DestData[ttmp + 3] = Convert.ToByte(CColor.a);
					}
				}
				dptr += 8;
			}
			return DestData;
		}

		////////////////////////////
		/// DecodeDXT2/3
		///////////////////////////
		public byte[] DecodeDXT23(int height, int width, byte[] SourceData)
		{
			byte[] DestData;
			imageshit.ImageLib.RGBA_COLOR_STRUCT[] Color=new imageshit.ImageLib.RGBA_COLOR_STRUCT[5];
			int i;
			imageshit.ImageLib.RGBA_COLOR_STRUCT CColor;
			int CData;
			int ChunksPerHLine= width / 4;
			imageshit.ImageLib.RGBA_COLOR_STRUCT zeroColor=new imageshit.ImageLib.RGBA_COLOR_STRUCT();
			imageshit.ImageLib.RGBA_COLOR_STRUCT c1, c2,c3,c4;
			DestData=new byte[((width * height) * 4)];
			if (ChunksPerHLine == 0) {ChunksPerHLine += 1;}
			for (i = 0;i< (width * height);i+=16)
			{
				c1 = il.short_to_rgba((SourceData[i + 8]) | (SourceData[i + 9] << 8));
				c2 =  il.short_to_rgba((SourceData[i + 10]) | (SourceData[i + 11] << 8));
				c3 =il.GradientColors(Color[0], Color[1]);
				c4 =il.GradientColors(Color[1], Color[0]);
				Color[0] =c1;
				Color[1] =c2;
				Color[2] = c3;
				Color[3] = c4;

				CData = (SourceData[i + 12] << 0) | (SourceData[i + 13] << 8) |(SourceData[i + 14] << 16) | (SourceData[i + 15] << 24);

				int ChunkNum = i / 16;
				long XPos = ChunkNum % ChunksPerHLine;
				long YPos = (ChunkNum - XPos) / ChunksPerHLine;
				long ttmp;
				int alpha;
				int sizeh = height < 4 ? height : 4;
				int sizew = width < 4 ? width : 4;
				int x,y;
				for (x = 0;x<sizeh;x++)
				{
					alpha = SourceData[i + (2 * x)] | (SourceData[i + (2 * x) + 1]) << 8;
					for (y = 0;y<sizew;y++)
					{
						CColor = Color[CData & 3];
						CData >>= 2;
						CColor.a = (alpha & 15) * 16;
						alpha >>= 4;
						ttmp = ((YPos * 4 + x) * width + XPos * 4 + y) * 4;

						DestData[ttmp] = (byte)CColor.b;
						DestData[ttmp + 1] = (byte)CColor.g;
						DestData[ttmp + 2] = (byte)CColor.r;
						DestData[ttmp + 3] = (byte)CColor.a;
					}
				}
			}
			return DestData;

		}
				
		
		
		
		//////////////////////////
		// DecodeDXT4/5
		//////////////////////////
		public byte[] DecodeDXT45(int height, int width,byte[] SourceData)
		{
			byte[] DestData;
			imageshit.ImageLib.RGBA_COLOR_STRUCT[] Color=new imageshit.ImageLib.RGBA_COLOR_STRUCT[4];
			int i;
			imageshit.ImageLib.RGBA_COLOR_STRUCT CColor;
			int CData;
			int ChunksPerHLine  = width / 4;
			imageshit.ImageLib.RGBA_COLOR_STRUCT zeroColor= new imageshit.ImageLib.RGBA_COLOR_STRUCT();
			DestData=new byte[(width * height) * 4];

			if (ChunksPerHLine == 0) {ChunksPerHLine += 1; }

			for (i = 0;i<(width * height);i+=16)
			{
				Color[0] = il.short_to_rgba(SourceData[i + 8] | (SourceData[i + 9] << 8));
				Color[1] = il.short_to_rgba(SourceData[i + 10] | (SourceData[i + 11] << 8));
				Color[2] = il.GradientColors(Color[0], Color[1]);
				Color[3] = il.GradientColors(Color[1], Color[0]);

				CData = (SourceData[i + 12] << 0) | (SourceData[i + 13] << 8) | (SourceData[i + 14] << 16) | (SourceData[i + 15] << 24);

				byte[] Alpha=new byte[8];
				Alpha[0] = SourceData[i];
				Alpha[1] = SourceData[i + 1];
				//Do the alphas
				if (Alpha[0] > Alpha[1])
				{
					// 8-alpha block:  derive the other six alphas.
					// Bit code 000 = alpha_0, 001 = alpha_1, others are interpolated.

					Alpha[2] = (byte)((6 * Alpha[0] + 1 * Alpha[1] + 3) / 7); // bit code 010
					Alpha[3] = (byte)((5 * Alpha[0] + 2 * Alpha[1] + 3) / 7); // bit code 011
					Alpha[4] = (byte)((4 * Alpha[0] + 3 * Alpha[1] + 3) / 7); // bit code 100
					Alpha[5] = (byte)((3 * Alpha[0] + 4 * Alpha[1] + 3) / 7); // bit code 101
					Alpha[6] = (byte)((2 * Alpha[0] + 5 * Alpha[1] + 3) / 7); // bit code 110
					Alpha[7] = (byte)((1 * Alpha[0] + 6 * Alpha[1] + 3) / 7); // bit code 111
				}
				else
				{
					// 6-alpha block.
					// Bit code 000 = alpha_0, 001 = alpha_1, others are interpolated.
					Alpha[2] = (byte)((4 * Alpha[0] + 1 * Alpha[1] + 2) / 5); // Bit code 010
					Alpha[3] = (byte)((3 * Alpha[0] + 2 * Alpha[1] + 2) / 5); // Bit code 011
					Alpha[4] = (byte)((2 * Alpha[0] + 3 * Alpha[1] + 2) / 5); // Bit code 100
					Alpha[5] = (byte)((1 * Alpha[0] + 4 * Alpha[1] + 2) / 5); // Bit code 101
					Alpha[6] = 0;            // Bit code 110
					Alpha[7] = 255;          // Bit code 111
				}

				// Byte	Alpha
				// 0	Alpha_0
				// 1	Alpha_1 
				// 2	(0)(2) (2 LSBs), (0)(1), (0)(0)
				// 3	(1)(1) (1 LSB), (1)(0), (0)(3), (0)(2) (1 MSB)
				// 4	(1)(3), (1)(2), (1)(1) (2 MSBs)
				// 5	(2)(2) (2 LSBs), (2)(1), (2)(0)
				// 6	(3)(1) (1 LSB), (3)(0), (2)(3), (2)(2) (1 MSB)
				// 7	(3)(3), (3)(2), (3)(1) (2 MSBs)
				// (0
				// Read an int and a short
				long tmpdword;
				int tmpword;
				long alphaDat;
				tmpword = SourceData[i + 2] | (SourceData[i + 3] << 8);
				tmpdword = SourceData[i + 4] |  (SourceData[i + 5] << 8) | (SourceData[i + 6] << 16) | (SourceData[i + 7] << 24);

				alphaDat = tmpword | (tmpdword << 16);

				int ChunkNum = i / 16;
				long XPos = ChunkNum % ChunksPerHLine;
				long YPos = (ChunkNum - XPos) / ChunksPerHLine;
				long ttmp;
				int sizeh = height < 4 ? height: 4;
				int sizew = width < 4 ? width: 4;
				int x,y;
				for (x=0;x< sizeh;x++)
				{
					for (y=0;y<sizew;y++)
					{
						CColor = Color[CData & 3];
						CData >>= 2;
						CColor.a = Alpha[alphaDat & 7];
						alphaDat >>= 3;
						ttmp = ((YPos * 4 + x) * width + XPos * 4 + y) * 4;
						DestData[ttmp] = (byte)CColor.b;
						DestData[ttmp + 1] = (byte)CColor.g;
						DestData[ttmp + 2] = (byte)CColor.r;
						DestData[ttmp + 3] = (byte)CColor.a;
					}
				}
			}
			return DestData;
		}
						
	}























	public class ImageLib
	{










		public struct RGBA_COLOR_STRUCT
		{
			public int r, g, b, a;
		}
		public RGBA_COLOR_STRUCT short_to_rgba(int color)
		{
			RGBA_COLOR_STRUCT rc;
			color = Convert.ToUInt16(color);
			rc.r = (((color >> 11) & 31) * 255) / 31;
			rc.g = (((color >> 5) & 63) * 255) / 63;
			rc.b = (((color >> 0) & 31) * 255) / 31;
			rc.a = 255;
			return rc;
		}

		public int rgba_to_int(RGBA_COLOR_STRUCT c)
		{
			return (c.a << 24) | (c.r << 16) | (c.g << 8) | c.b;
		}

		public RGBA_COLOR_STRUCT GradientColors(RGBA_COLOR_STRUCT Col1, RGBA_COLOR_STRUCT Col2)
		{
			RGBA_COLOR_STRUCT ret;
			ret.r = ((Col1.r * 2 + Col2.r)) / 3;
			ret.g = ((Col1.g * 2 + Col2.g)) / 3;
			ret.b = ((Col1.b * 2 + Col2.b)) / 3;
			ret.a = 255;
			return ret;
		}

		public RGBA_COLOR_STRUCT GradientColorsHalf(RGBA_COLOR_STRUCT Col1,RGBA_COLOR_STRUCT Col2)
		{
			RGBA_COLOR_STRUCT ret;
			ret.r = (Col1.r / 2 + Col2.r / 2);
			ret.g = (Col1.g / 2 + Col2.g / 2);
			ret.b = (Col1.b / 2 + Col2.b / 2);
			ret.a = 255;
			return ret;
		}

	}
}
namespace WindowsApplication2
{
	/// <summary>
	/// Summary description for BitmViewer.
	/// </summary>
	public class BitmViewer : System.Windows.Forms.Form
	{
		[DllImport("kernel32.dll")]
		static extern void RtlMoveMemory(IntPtr src,byte[] crap, int cb);

		
		BitmData bitm;
		Form1 oldform;
		decode dec=new decode();
		Bitmap b;
		public System.IntPtr ptr;
		public int xsize=0;
		
		public System.Windows.Forms.PictureBox pb;
		private System.Windows.Forms.Label type;
		private System.Windows.Forms.Label name;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.SaveFileDialog saveDDS;
		private System.Windows.Forms.TreeView treeView1;
		private System.Windows.Forms.Panel panel1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public BitmViewer()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pb = new System.Windows.Forms.PictureBox();
			this.type = new System.Windows.Forms.Label();
			this.name = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.saveDDS = new System.Windows.Forms.SaveFileDialog();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.panel1 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// pb
			// 
			this.pb.BackColor = System.Drawing.Color.Black;
			this.pb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pb.Location = new System.Drawing.Point(8, 8);
			this.pb.Name = "pb";
			this.pb.Size = new System.Drawing.Size(256, 256);
			this.pb.TabIndex = 0;
			this.pb.TabStop = false;
			this.pb.Click += new System.EventHandler(this.pb_Click);
			// 
			// type
			// 
			this.type.BackColor = System.Drawing.Color.LightSteelBlue;
			this.type.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.type.Location = new System.Drawing.Point(4, 272);
			this.type.Name = "type";
			this.type.Size = new System.Drawing.Size(264, 16);
			this.type.TabIndex = 1;
			this.type.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// name
			// 
			this.name.BackColor = System.Drawing.Color.LightSteelBlue;
			this.name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.name.Location = new System.Drawing.Point(4, 292);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(264, 16);
			this.name.TabIndex = 2;
			this.name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(4, 312);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(108, 24);
			this.button1.TabIndex = 3;
			this.button1.Text = "Save";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Enabled = false;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Location = new System.Drawing.Point(4, 340);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(108, 24);
			this.button2.TabIndex = 4;
			this.button2.Text = "Inject";
			// 
			// saveDDS
			// 
			this.saveDDS.Filter = "BMP|*.bmp|JPG|*.jpg";
			this.saveDDS.FilterIndex = 2;
			// 
			// treeView1
			// 
			this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.treeView1.ImageIndex = -1;
			this.treeView1.Location = new System.Drawing.Point(116, 312);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = -1;
			this.treeView1.Size = new System.Drawing.Size(152, 52);
			this.treeView1.TabIndex = 5;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.LightCoral;
			this.panel1.Location = new System.Drawing.Point(4, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(264, 264);
			this.panel1.TabIndex = 6;
			// 
			// BitmViewer
			// 
			this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Gainsboro;
			this.ClientSize = new System.Drawing.Size(274, 368);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.name);
			this.Controls.Add(this.type);
			this.Controls.Add(this.pb);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "BitmViewer";
			this.Text = "BitmViewer";
			this.TopMost = true;
			this.Load += new System.EventHandler(this.BitmViewer_Load);
			this.ResumeLayout(false);

		}
		#endregion

		protected override void OnClosing(CancelEventArgs e)
		{
			pb.Dispose();
			  
			try
			{
				Marshal.FreeHGlobal(ptr);
			}
			catch
			{
			}
			//base.OnClosing(e);
		}



		public void BitmViewer_Load(object sender, System.EventArgs e)
		{

			//bitminfo();
			
			//bitmshow();
		}
		public void bitminfo()
		{
			this.treeView1.AfterSelect -= new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			treeView1.Nodes.Clear();
			int u;
			for (u=0;u<bitm.format.Length;u++)
			{
				treeView1.Nodes.Add("Bitmap ["+u.ToString()+"]");
				int i;
				for (i=0;i<bitm.subMapCount[u];i++)
				{
					treeView1.Nodes[u].Nodes.Add("Submap ["+i.ToString()+"]");
				}
			}
			
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			treeView1.SelectedNode=treeView1.Nodes[0];		
			
		}
		public void bitmshow(bool fuck)
		{
			int xxx=0;
			int xxx2=0;
			if (treeView1.SelectedNode.Parent!=null)
			{
				xxx=treeView1.SelectedNode.Parent.Index;
				xxx2=treeView1.SelectedNode.Index;
			}
			else
			{
				xxx=treeView1.SelectedNode.Index;
				xxx2=0;
			}
			
			int width=bitm.width[xxx];
			int height=bitm.height[xxx];
			for (int xxxx=0;xxxx<xxx2;xxxx++)
			{
				width/=2;height/=2;
			}

			if (bitm.DecodedData[xxx][xxx2]==null)
			{
				type.Text=ImageType(bitm.format[xxx]) + " - " + height.ToString()+" X "+width.ToString()+" - Unsupported";
				name.Text=bitm.name;
				pb.Image=null;
							
				return;
			}
			else
			{
				type.Text=ImageType(bitm.format[xxx]) + " - " + height.ToString()+" X "+width.ToString();
				name.Text=bitm.name;
			}


			//try
			//{
		
			//if (pb.Image!=null){pb.Image.Dispose();}
//MessageBox.Show("test");
			try
			{
				//Bitmap.FromStream(bitm.DecodedData[xxx][xxx2])
				//GraphicsStream r=
		//	EmoryStream dx=new MemoryStream(
				//dx.Write(bitm.DecodedData[xxx][xxx2],0,bitm.DecodedData[xxx][xxx2].Length);
				//MessageBox.Show("test");
				//	b.PixelFormat=PixelFormat.Format8bppIndexed;
				//b = Bitmap.FromStream(bitm.DecodedData[xxx][xxx2]);
			//	b.RawFormat= ImageFormat.Jpeg;
			
					//width, height, width * 4, System.Drawing.Imaging.PixelFormat.Format8bppIndexed,bitm.ptr[xxx][xxx2]);//Format32bppArgb, bitm.ptr[xxx][xxx2]);
		//		int stride=width
				
				//b = new System.Drawing.Bitmap(width, height, width * 4, System.Drawing.Imaging.PixelFormat.Format32bppArgb,bitm.ptr[xxx][xxx2]);//Format32bppArgb, bitm.ptr[xxx][xxx2]);
				//MessageBox.Show("test");
				//pb.Image.Dispose();
				pb.Image = bitm.bit[xxx][xxx2];
			}
			catch
			{
				MessageBox.Show("wtf");
			}
			//this.BringToFront();

			//oldform.setmybitmapdata(ref bitm);
	
			


			//this.xsize=bitm.DecodedData[xxx][xxx2].Length;

	

			//}
			//catch
			//{
				
		
				
			//}
		}
	

		public Bitmap DecodeBitmx(byte[] fart,int xxx,int xxxx,int height,int width,int format,int depth)
		{
			byte[] poo=new byte[0];
			IntPtr ptr=new IntPtr();
			int stride=width;
			PixelFormat o=new PixelFormat();
			int poolength;
			byte[] fu;
			switch (format)
			{



				case 14:
					poo=dec.DecodeDXT1(height,width,fart);
					stride*=4;
					o=PixelFormat.Format32bppArgb;
					break;

				case 15:
					poo=dec.DecodeDXT23(height,width,fart);
					stride*=4;
					o=PixelFormat.Format32bppArgb;
					break;

				case 16:
					poo=dec.DecodeDXT45(height,width,fart);
					stride*=4;
					o=PixelFormat.Format32bppArgb;
					break;

				case 11:
					poo = SwizzlePicture(fart,width,height,depth,32, Swizzle.SwizzleType.DeSwizzle);
					stride*=4;
					o=PixelFormat.Format32bppArgb;
					break;
				case 10:
					poo = SwizzlePicture(fart,width,height,depth,32, Swizzle.SwizzleType.DeSwizzle);
					stride*=4;
					o=PixelFormat.Format32bppArgb;
					break;


				case 9:
					poo = SwizzlePicture(fart,width,height,depth,16, Swizzle.SwizzleType.DeSwizzle);
					stride*=2;
					o=PixelFormat.Format16bppRgb565;
					break;



			
		

				case 8:
					poo = SwizzlePicture(fart,width,height,depth,16, Swizzle.SwizzleType.DeSwizzle);
						stride*=2;
					o=PixelFormat.Format16bppRgb565;
					break;
				case 6:
					poo = SwizzlePicture(fart,width,height,depth,16, Swizzle.SwizzleType.DeSwizzle);
						stride*=2;
					o=PixelFormat.Format16bppRgb565;
					break;
				case 3:
					poo = SwizzlePicture(fart,width,height,depth,16, Swizzle.SwizzleType.DeSwizzle);
					o=PixelFormat.Format32bppArgb;
					poolength=poo.Length;
					fu=new byte[poolength*4];
					for (int e=0;e<poolength;e++)
					{
						int r=e*4;
						fu[r+0]=poo[e];
						fu[r+1]=poo[e];
						fu[r+2]=poo[e];
						fu[r+3]=poo[e];
					}
					poo=fu;
					stride*=4;
					break;
	



					case 17:
					poo = SwizzlePicture(fart,width,height,-1,8, Swizzle.SwizzleType.DeSwizzle);
						o=PixelFormat.Format32bppArgb;
						poolength=poo.Length;
						fu=new byte[poolength*4];
						for (int e=0;e<poolength;e++)
						{
							int r=e*4;
							fu[r+0]=poo[e];
							fu[r+1]=poo[e];
							fu[r+2]=poo[e];
							fu[r+3]=255;
						}
						poo=fu;
						stride*=4;
						break;
					
					
					case 0:
					poo = SwizzlePicture(fart,width,height,-1,8, Swizzle.SwizzleType.Swizzle);
						o=PixelFormat.Format32bppArgb;
						poolength=poo.Length;
						fu=new byte[poolength*4];
						for (int e=0;e<poolength;e++)
						{
							int r=e*4;
							fu[r+0]=255;
							fu[r+1]=255;
							fu[r+2]=255;
							fu[r+3]=poo[e];
						}
						poo=fu;
						stride*=4;
						break;
					case 1:
						poo = SwizzlePicture(fart,width,height,-1,8, Swizzle.SwizzleType.Swizzle);
						o=PixelFormat.Format32bppArgb;
						poolength=poo.Length;
						fu=new byte[poolength*4];
						for (int e=0;e<poolength;e++)
						{
							int r=e*4;
							fu[r+0]=poo[e];
							fu[r+1]=poo[e];
							fu[r+2]=poo[e];
							fu[r+3]=255;
						}
						poo=fu;
						stride*=4;
						break;
					case 2:
					poo = SwizzlePicture(fart,width,height,-1,8, Swizzle.SwizzleType.Swizzle);
						
						o=PixelFormat.Format32bppArgb;
						poolength=poo.Length;
						fu=new byte[poolength*4];
						for (int e=0;e<poolength;e++)
						{
							int r=e*4;
							fu[r+0]=poo[e];
							fu[r+1]=poo[e];
							fu[r+2]=poo[e];
							fu[r+3]=poo[e];
						}
						poo=fu;
						stride*=4;
						break;


				default:
					poo=new byte[0];
					break;


			}
				
		
	
			Marshal.FreeHGlobal(ptr);
			ptr = Marshal.AllocHGlobal(poo.Length);

			RtlMoveMemory(ptr,poo,poo.Length);

			Bitmap temp=new System.Drawing.Bitmap(width, height,stride,o, ptr);
			return temp;
	}

		










		public void  DecodeBitm()
		{
			byte[] poo=new byte[0];
			bitm.DecodedData=new byte[bitm.depth.Length][][];
			bitm.ptr=new IntPtr[bitm.depth.Length][];
			bitm.bit=new Bitmap[bitm.depth.Length][];
			int poolength;
			byte[] fu;
			for (int xxx=0;xxx<bitm.depth.Length;xxx++)
			{	int height=bitm.height[xxx];
				int width=bitm.width[xxx];
                bitm.DecodedData[xxx]=new byte[bitm.subMapCount[xxx]][];
				bitm.ptr[xxx]=new IntPtr[bitm.subMapCount[xxx]];
				bitm.bit[xxx]=new Bitmap[bitm.subMapCount[xxx]];
			
				for (int xxxx=0;xxxx<bitm.subMapCount[xxx];xxxx++)
				{
					if (xxxx!=0) { width/=2;height/=2;}
					int shit=bitm.format[xxx];
					int stride=width;
					PixelFormat o=new PixelFormat();
					switch (shit)
					{
						case 14:
							poo=dec.DecodeDXT1(height,width,bitm.RawData[xxx][xxxx]);
							o=PixelFormat.Format32bppArgb;
							stride*=4;
							break;

						case 15:
							poo=dec.DecodeDXT23(height,width,bitm.RawData[xxx][xxxx]);
							o=PixelFormat.Format32bppArgb;
							stride*=4;
							break;

						case 16:
							poo=dec.DecodeDXT45(height,width,bitm.RawData[xxx][xxxx]);
							o=PixelFormat.Format32bppArgb;
							stride*=4;
							break;

						case 10:
							poo = SwizzlePicture(bitm.RawData[xxx][xxxx],width,height,-1,32, Swizzle.SwizzleType.DeSwizzle);
							o=PixelFormat.Format32bppArgb;
							stride*=4;
							break;
						case 11:
							poo = SwizzlePicture(bitm.RawData[xxx][xxxx],width,height,-1,32, Swizzle.SwizzleType.DeSwizzle);
							o=PixelFormat.Format32bppArgb;
							stride*=4;
							break;

						case 8:
							poo = SwizzlePicture(bitm.RawData[xxx][xxxx],width,height,-1,16, Swizzle.SwizzleType.DeSwizzle);
							o=PixelFormat.Format16bppRgb565;
							stride*=2;
							break;
						case 6:
							poo = SwizzlePicture(bitm.RawData[xxx][xxxx],width,height,-1,16, Swizzle.SwizzleType.DeSwizzle);
							o=PixelFormat.Format16bppRgb565;
							stride*=2;
							break;
						case 3:
							poo = SwizzlePicture(bitm.RawData[xxx][xxxx],width,height,-1,16, Swizzle.SwizzleType.DeSwizzle);
							o=PixelFormat.Format32bppArgb;
							poolength=poo.Length;
							fu=new byte[poolength*4];
							for (int e=0;e<poolength;e++)
							{
								int r=e*4;
								fu[r+0]=poo[e];
								fu[r+1]=poo[e];
								fu[r+2]=poo[e];
								fu[r+3]=poo[e];
							}
							poo=fu;
							stride*=4;
							break;
						case 9:
							poo = SwizzlePicture(bitm.RawData[xxx][xxxx],width,height,-1,16, Swizzle.SwizzleType.DeSwizzle);
							o=PixelFormat.Format16bppRgb565;
							stride*=2;
							break;



						case 17:
							poo = SwizzlePicture(bitm.RawData[xxx][xxxx],width,height,-1,8, Swizzle.SwizzleType.DeSwizzle);
                            o=PixelFormat.Format32bppArgb;
							poolength=poo.Length;
							fu=new byte[poolength*4];
							for (int e=0;e<poolength;e++)
							{
								int r=e*4;
								fu[r+0]=poo[e];
								fu[r+1]=poo[e];
								fu[r+2]=poo[e];
								fu[r+3]=255;
							}
							poo=fu;
							stride*=4;
							break;
						case 0:
							poo = SwizzlePicture(bitm.RawData[xxx][xxxx],width,height,-1,8, Swizzle.SwizzleType.DeSwizzle);
							o=PixelFormat.Format32bppArgb;
							poolength=poo.Length;
							fu=new byte[poolength*4];
							for (int e=0;e<poolength;e++)
							{
								int r=e*4;
								fu[r+0]=255;
								fu[r+1]=255;
								fu[r+2]=255;
								fu[r+3]=poo[e];
							}
							poo=fu;
							stride*=4;
							break;
						case 1:
							poo = SwizzlePicture(bitm.RawData[xxx][xxxx],width,height,-1,8, Swizzle.SwizzleType.DeSwizzle);
							o=PixelFormat.Format32bppArgb;
							poolength=poo.Length;
							fu=new byte[poolength*4];
							for (int e=0;e<poolength;e++)
							{
								int r=e*4;
								fu[r+0]=poo[e];
								fu[r+1]=poo[e];
								fu[r+2]=poo[e];
								fu[r+3]=255;
							}
							poo=fu;
							stride*=4;
							break;
						case 2:
							poo = SwizzlePicture(bitm.RawData[xxx][xxxx],width,height,-1,8, Swizzle.SwizzleType.DeSwizzle);
							o=PixelFormat.Format32bppArgb;
							poolength=poo.Length;
							fu=new byte[poolength*4];
							for (int e=0;e<poolength;e++)
							{
								int r=e*4;
								fu[r+0]=poo[e];
								fu[r+1]=poo[e];
								fu[r+2]=poo[e];
								fu[r+3]=poo[e];
							}
							poo=fu;
							stride*=4;
							break;


						default:
							poo=new byte[0];
							bitm.DecodedData[xxx][xxxx]=poo;
							return;
					}



					bitm.DecodedData[xxx][xxxx]=poo;
					Marshal.FreeHGlobal(bitm.ptr[xxx][xxxx]);
					bitm.ptr[xxx][xxxx] = Marshal.AllocHGlobal(bitm.DecodedData[xxx][xxxx].Length);
					RtlMoveMemory(bitm.ptr[xxx][xxxx],bitm.DecodedData[xxx][xxxx],bitm.DecodedData[xxx][xxxx].Length);
					

					
							bitm.bit[xxx][xxxx] = new System.Drawing.Bitmap(width, height, stride, o,bitm.ptr[xxx][xxxx]);
					
		









					}
			}
			
			//oldform.setmybitmapdata(ref bitm);
		}
		public void setbitm(ref BitmData bm, ref Form1 eh)
		{
			bitm=bm;
		
			oldform=eh;
			//DecodeBitm();
		}
		public void setwhore()
		{
			
		}


		public string ImageType(int i)
		{
			string poop;
			switch(i)
			{
				case 0:
					poop = "A8";
					break;
				case 1:
					poop = "Y8";
					break;
				case 2:
					poop = "AY8";
					break;
				case 3:
					poop = "A8Y8";
					break;
				case 6:
					poop = "R5G6B5";
					break;
				case 8:
					poop = "A1R5G5B5";
					break;
				case 9:
					poop = "A4R4G4B4";
					break;
				case 10:
					poop = "X8R8G8B8";
					break;
				case 11:
					poop = "A8R8G8B8";
					break;
				case 14:
					poop = "DXT1";
					break;
				case 15:
					poop = "DXT2/DXT3";
					break;
				case 16:
					poop = "DXT4/DXT5";
					break;
				case 17:
					poop = "P8";
					break;
				default:
					poop = "Unknown";
					break;
			}
			return poop;
			}






																					
		
	
		public byte[] SwizzlePicture(byte[] bin, int width, int height, int depth, int BitCount, Swizzle.SwizzleType Action)
		{
			Swizzle swizzle = new Swizzle(width, height, depth);
			byte[] bs1 = new byte[bin.Length - 1 + 1];
			int j3 = height - 1;
			for (int k1 = 0; k1 <= j3; k1++)
			{
				int i3 = width - 1;
				for (int i2 = 0; i2 <= i3; i2++)
				{
					int i1=0;

					int j1=0;

					switch (Action)
					{
						case Swizzle.SwizzleType.DeSwizzle:
							i1 = (int)Math.Round((double)(k1 * width + i2) * (BitCount / 8.0));
							j1 = (int)Math.Round((double)swizzle.Swizzlex(i2, k1, -1) * (BitCount / 8.0));
							break;

						case Swizzle.SwizzleType.Swizzle:
							j1 = (int)Math.Round((double)(k1 * width + i2) * (BitCount / 8.0));
							i1 = (int)Math.Round((double)swizzle.Swizzlex(i2, k1, -1) * (BitCount / 8.0));
							break;
					}
					int k2 = (int)Math.Round(BitCount / 8.0 - 1.0);
					try 
					{
						for (int j2 = 0; j2 <= k2; j2++)
						{
							bs1[i1 + j2] = bin[j1 + j2];
						}
					}
					catch
					{
					}
				}
			}
			return bs1;
		}



		private void pb_Click(object sender, System.EventArgs e)
		{
			if (pb.SizeMode==PictureBoxSizeMode.Normal)
			{
				pb.SizeMode=PictureBoxSizeMode.StretchImage;
			}
			else
			{
				pb.SizeMode=PictureBoxSizeMode.Normal;
			}
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			string [] Split = bitm.name.Split(new Char [] {'\\'}); 
			string pathname=Split[Split.Length-1];
			saveDDS.FileName=pathname;
			if (saveDDS.ShowDialog()==DialogResult.Cancel){return;}
			if (saveDDS.FilterIndex==1)
			{
				pb.Image.Save(saveDDS.FileName,System.Drawing.Imaging.ImageFormat.Bmp);
			}
			else if (saveDDS.FilterIndex==2)
			{
				pb.Image.Save(saveDDS.FileName,System.Drawing.Imaging.ImageFormat.Jpeg);
			}

		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			//this.Enabled=false;
			bitmshow(false);
			treeView1.Focus();
			//this.Enabled=true;
		}


	
		}
}
