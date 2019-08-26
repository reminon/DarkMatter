using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using sharedstuff;
using sharedstuff.MetaStuff;
using System.IO;

namespace WindowsApplication2
{
	/// <summary>
	/// Summary description for util.
	/// </summary>
	/// 
	public class util : System.Windows.Forms.Form
	{
		MetaInfo meta;
		Form1 oldform;
		StringsInfo items;
		Reflexive reflex;
		MapHeader map;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox ident;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox list;
		private System.Windows.Forms.TextBox offset;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.RadioButton dec;
		private System.Windows.Forms.RadioButton hex;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox strings;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public util()
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
			this.list = new System.Windows.Forms.ListBox();
			this.ident = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.offset = new System.Windows.Forms.TextBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.strings = new System.Windows.Forms.ComboBox();
			this.hex = new System.Windows.Forms.RadioButton();
			this.dec = new System.Windows.Forms.RadioButton();
			this.label3 = new System.Windows.Forms.Label();
			this.button3 = new System.Windows.Forms.Button();
			this.button4 = new System.Windows.Forms.Button();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// list
			// 
			this.list.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.list.Location = new System.Drawing.Point(4, 92);
			this.list.Name = "list";
			this.list.Size = new System.Drawing.Size(368, 132);
			this.list.TabIndex = 1;
			this.list.SelectedIndexChanged += new System.EventHandler(this.list_SelectedIndexChanged);
			// 
			// ident
			// 
			this.ident.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.ident.Location = new System.Drawing.Point(124, 12);
			this.ident.Name = "ident";
			this.ident.Size = new System.Drawing.Size(80, 20);
			this.ident.TabIndex = 2;
			this.ident.Text = "0";
			this.ident.TextChanged += new System.EventHandler(this.ident_TextChanged);
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Silver;
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Location = new System.Drawing.Point(12, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(108, 20);
			this.label1.TabIndex = 3;
			this.label1.Text = "Find By Ident:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Goldenrod;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(208, 12);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(52, 20);
			this.button1.TabIndex = 4;
			this.button1.Text = "Find";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.Goldenrod;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Location = new System.Drawing.Point(208, 36);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(52, 20);
			this.button2.TabIndex = 7;
			this.button2.Text = "Find";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Silver;
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label2.Location = new System.Drawing.Point(12, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(108, 20);
			this.label2.TabIndex = 6;
			this.label2.Text = "Find By Offset:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// offset
			// 
			this.offset.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.offset.Location = new System.Drawing.Point(124, 36);
			this.offset.Name = "offset";
			this.offset.Size = new System.Drawing.Size(80, 20);
			this.offset.TabIndex = 5;
			this.offset.Text = "0";
			this.offset.TextChanged += new System.EventHandler(this.offset_TextChanged);
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.button4);
			this.panel1.Controls.Add(this.strings);
			this.panel1.Controls.Add(this.hex);
			this.panel1.Controls.Add(this.dec);
			this.panel1.Location = new System.Drawing.Point(4, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(368, 84);
			this.panel1.TabIndex = 12;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// strings
			// 
			this.strings.Location = new System.Drawing.Point(120, 56);
			this.strings.Name = "strings";
			this.strings.Size = new System.Drawing.Size(80, 21);
			this.strings.TabIndex = 3;
			// 
			// hex
			// 
			this.hex.Checked = true;
			this.hex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.hex.Location = new System.Drawing.Point(284, 32);
			this.hex.Name = "hex";
			this.hex.Size = new System.Drawing.Size(76, 16);
			this.hex.TabIndex = 2;
			this.hex.TabStop = true;
			this.hex.Text = "Hex";
			this.hex.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// dec
			// 
			this.dec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.dec.Location = new System.Drawing.Point(284, 12);
			this.dec.Name = "dec";
			this.dec.Size = new System.Drawing.Size(76, 16);
			this.dec.TabIndex = 0;
			this.dec.Text = "Decimal";
			this.dec.CheckedChanged += new System.EventHandler(this.dec_CheckedChanged);
			// 
			// label3
			// 
			this.label3.BackColor = System.Drawing.Color.Silver;
			this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label3.Location = new System.Drawing.Point(12, 60);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(108, 20);
			this.label3.TabIndex = 13;
			this.label3.Text = "Find By String:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.Goldenrod;
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Location = new System.Drawing.Point(208, 60);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(52, 20);
			this.button3.TabIndex = 14;
			this.button3.Text = "Find";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// button4
			// 
			this.button4.BackColor = System.Drawing.Color.Goldenrod;
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button4.Location = new System.Drawing.Point(276, 56);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(52, 20);
			this.button4.TabIndex = 15;
			this.button4.Text = "Find";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// util
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.LightGray;
			this.ClientSize = new System.Drawing.Size(376, 228);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.offset);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.ident);
			this.Controls.Add(this.list);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "util";
			this.Text = "util";
			this.Load += new System.EventHandler(this.util_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void util_Load(object sender, System.EventArgs e)
		{
			int x;
			for (x=1;x<map.scriptReferenceCount;x++)
			{
				strings.Items.Add(items.Names[x]);
			}
			//strings.Sorted=true;
		}
		public void SetMeta(ref MetaInfo mi)
		{
			meta=mi;
		}
		public void SetOldForm(ref Form1 fx)
		{
			oldform=fx;
		}
		public void SetItems(ref StringsInfo fx)
		{
			items=fx;
		}
		public void SetMap(ref MapHeader fx)
		{
			map=fx;
		}

		public void SetReflex(ref Reflexive fx)
		{
			reflex=fx;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			int searchfor;
			if (dec.Checked==true)
			{
				searchfor=Convert.ToInt32(ident.Text);
			}
			else
			{
				searchfor=Convert.ToInt32(ident.Text,16);
			}
			int oi=oldform.findbyid(searchfor);
			if (oi==-1){MessageBox.Show("Not Found");return;}
			string shit=meta.TagType[oi]+" - " + meta.Names[oi];
			list.Items.Clear();
			list.Items.Add(shit);
		}

		

		private void ident_TextChanged(object sender, System.EventArgs e)
		{
			if (ident.Text.Length==0) {ident.Text="0";}
		}

		
		private void button2_Click(object sender, System.EventArgs e)
		{
			int searchfor;
			if (dec.Checked==true)
			{
				searchfor=Convert.ToInt32(offset.Text);
			}
			else
			{
				searchfor=Convert.ToInt32(offset.Text,16);
			}
			int oi=oldform.findbyoffset(searchfor);
			if (oi==-1){MessageBox.Show("This Offset Doesn't Point To Meta");return;}
			string shit=meta.TagType[oi]+" - " + meta.Names[oi];
			list.Items.Clear();
			list.Items.Add(shit);
		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (hex.Checked==true)
			{
				int shit=Convert.ToInt32(offset.Text);
				offset.Text=shit.ToString("X");

				shit=Convert.ToInt32(ident.Text);
				ident.Text=shit.ToString("X");
			}
		}

		private void dec_CheckedChanged(object sender, System.EventArgs e)
		{
			
			if (dec.Checked==true)
			{
				int shit=Convert.ToInt32(offset.Text,16);
				offset.Text=shit.ToString();

				shit=Convert.ToInt32(ident.Text,16);
				ident.Text=shit.ToString();
				
			}
		}

		private void offset_TextChanged(object sender, System.EventArgs e)
		{
				if (offset.Text.Length==0) {offset.Text="0";}
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
            string selected=strings.Text;
			int crack=Array.IndexOf(items.Names,selected);
			if (crack==-1 | crack==0) {return;}
			this.Enabled=false;
			list.Items.Clear();
			FileStream FS=new FileStream(map.filepath,FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
			BinaryReader BR=new BinaryReader(FS);
			int x;
			for (x=0;x<map.metaCount;x++)
			{
				BR.BaseStream.Seek(meta.Offset[x],SeekOrigin.Begin);
				int tempsize=meta.Size[x]/4;
				int j;
				for (j=0;j<tempsize;j++)
				{
					int tempitem=BR.ReadInt16();
					int tempblank=BR.ReadByte();
					int templength=BR.ReadByte();
					
					if (tempitem > 0 && tempitem==crack && tempitem<map.scriptReferenceCount && tempblank==0 && templength==items.LengthOfName[tempitem])
					{
						string cracker=meta.TagType[x]+" - "+meta.Names[x];
						list.Items.Add(cracker);
						break;
					}
				}
			}

			BR.Close();
			FS.Close();
			this.Enabled=true;
			MessageBox.Show("Done");

		}

		private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void list_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			list.Items.Clear();
			int x;
			for (x=0;x<map.metaCount;x++)
			{
				//oldform.scan(map.filepath,meta.Offset[x],meta.Size[x],-1,false,true,-1);
				oldform.SetReflex();
				
				int j;
				for (j=0;j<reflex.Count;j++)
				{
					
					if (reflex.InTag[j]==3)
					{
						string cracker=meta.TagType[x]+" - "+meta.Names[x];
						list.Items.Add(cracker);
						Application.DoEvents();
						break;
					}
				}
			}

			MessageBox.Show("Done");
		}
	}
}
