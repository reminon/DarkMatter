using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsApplication2
{
	/// <summary>
	/// Summary description for SelectedMetaInformation.
	/// </summary>
	public class SelectedMetaInformation : System.Windows.Forms.Form
	{
		public System.Windows.Forms.Button metaedit;
		public System.Windows.Forms.CheckBox parseit;
		public System.Windows.Forms.CheckBox recursive;
		public System.Windows.Forms.Button button1;
		public System.Windows.Forms.Button button3;
		public System.Windows.Forms.Panel panel3;
		public System.Windows.Forms.Panel xxxxxxxxxxxxxx;
		public System.Windows.Forms.TextBox offsetControl;
		public System.Windows.Forms.ComboBox tagTypesControl;
		public System.Windows.Forms.Label label4;
		public System.Windows.Forms.Label label8;
		public System.Windows.Forms.Label sizeControl;
		public System.Windows.Forms.Label label5;
		public System.Windows.Forms.Label label6;
		public System.Windows.Forms.TextBox identControl;
		public System.Windows.Forms.Button button2;
		public System.Windows.Forms.Button scanmeta;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public SelectedMetaInformation()
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
			this.metaedit = new System.Windows.Forms.Button();
			this.parseit = new System.Windows.Forms.CheckBox();
			this.recursive = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.panel3 = new System.Windows.Forms.Panel();
			this.scanmeta = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.xxxxxxxxxxxxxx = new System.Windows.Forms.Panel();
			this.offsetControl = new System.Windows.Forms.TextBox();
			this.tagTypesControl = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.sizeControl = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.identControl = new System.Windows.Forms.TextBox();
			this.panel3.SuspendLayout();
			this.xxxxxxxxxxxxxx.SuspendLayout();
			this.SuspendLayout();
			// 
			// metaedit
			// 
			this.metaedit.BackColor = System.Drawing.Color.Gray;
			this.metaedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.metaedit.Location = new System.Drawing.Point(8, 304);
			this.metaedit.Name = "metaedit";
			this.metaedit.Size = new System.Drawing.Size(128, 20);
			this.metaedit.TabIndex = 13;
			this.metaedit.Text = "Meta Editor";
			this.metaedit.Click += new System.EventHandler(this.metaedit_Click);
			// 
			// parseit
			// 
			this.parseit.BackColor = System.Drawing.Color.LightSlateGray;
			this.parseit.Checked = true;
			this.parseit.CheckState = System.Windows.Forms.CheckState.Checked;
			this.parseit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.parseit.Location = new System.Drawing.Point(32, 208);
			this.parseit.Name = "parseit";
			this.parseit.Size = new System.Drawing.Size(88, 16);
			this.parseit.TabIndex = 12;
			this.parseit.Text = "Parsed";
			this.parseit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// recursive
			// 
			this.recursive.BackColor = System.Drawing.Color.LightSlateGray;
			this.recursive.Checked = true;
			this.recursive.CheckState = System.Windows.Forms.CheckState.Checked;
			this.recursive.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.recursive.Location = new System.Drawing.Point(32, 224);
			this.recursive.Name = "recursive";
			this.recursive.Size = new System.Drawing.Size(88, 16);
			this.recursive.TabIndex = 11;
			this.recursive.Text = "Recursive";
			this.recursive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.Gray;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button1.Location = new System.Drawing.Point(8, 240);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(128, 20);
			this.button1.TabIndex = 9;
			this.button1.Text = "Inject\tMeta";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button3
			// 
			this.button3.BackColor = System.Drawing.Color.Gray;
			this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button3.Location = new System.Drawing.Point(8, 188);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(128, 20);
			this.button3.TabIndex = 8;
			this.button3.Text = "Save Meta";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// panel3
			// 
			this.panel3.BackColor = System.Drawing.Color.LightSlateGray;
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel3.Controls.Add(this.scanmeta);
			this.panel3.Controls.Add(this.button2);
			this.panel3.Location = new System.Drawing.Point(4, 184);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(136, 172);
			this.panel3.TabIndex = 7;
			// 
			// scanmeta
			// 
			this.scanmeta.BackColor = System.Drawing.Color.CornflowerBlue;
			this.scanmeta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.scanmeta.Location = new System.Drawing.Point(3, 96);
			this.scanmeta.Name = "scanmeta";
			this.scanmeta.Size = new System.Drawing.Size(128, 20);
			this.scanmeta.TabIndex = 15;
			this.scanmeta.Text = "Scan Meta";
			this.scanmeta.Click += new System.EventHandler(this.button4_Click);
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.Gray;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Location = new System.Drawing.Point(3, 144);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(128, 20);
			this.button2.TabIndex = 14;
			this.button2.Text = "Raw Data Editor";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// xxxxxxxxxxxxxx
			// 
			this.xxxxxxxxxxxxxx.BackColor = System.Drawing.Color.LightSlateGray;
			this.xxxxxxxxxxxxxx.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.xxxxxxxxxxxxxx.Controls.Add(this.metaedit);
			this.xxxxxxxxxxxxxx.Controls.Add(this.offsetControl);
			this.xxxxxxxxxxxxxx.Controls.Add(this.tagTypesControl);
			this.xxxxxxxxxxxxxx.Controls.Add(this.label4);
			this.xxxxxxxxxxxxxx.Controls.Add(this.label8);
			this.xxxxxxxxxxxxxx.Controls.Add(this.sizeControl);
			this.xxxxxxxxxxxxxx.Controls.Add(this.label5);
			this.xxxxxxxxxxxxxx.Controls.Add(this.label6);
			this.xxxxxxxxxxxxxx.Controls.Add(this.identControl);
			this.xxxxxxxxxxxxxx.Controls.Add(this.parseit);
			this.xxxxxxxxxxxxxx.Controls.Add(this.recursive);
			this.xxxxxxxxxxxxxx.Controls.Add(this.button1);
			this.xxxxxxxxxxxxxx.Controls.Add(this.button3);
			this.xxxxxxxxxxxxxx.Controls.Add(this.panel3);
			this.xxxxxxxxxxxxxx.Location = new System.Drawing.Point(0, 0);
			this.xxxxxxxxxxxxxx.Name = "xxxxxxxxxxxxxx";
			this.xxxxxxxxxxxxxx.Size = new System.Drawing.Size(536, 536);
			this.xxxxxxxxxxxxxx.TabIndex = 6;
			this.xxxxxxxxxxxxxx.Paint += new System.Windows.Forms.PaintEventHandler(this.xxxxxxxxxxxxxx_Paint);
			// 
			// offsetControl
			// 
			this.offsetControl.BackColor = System.Drawing.Color.Silver;
			this.offsetControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.offsetControl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.offsetControl.Location = new System.Drawing.Point(4, 24);
			this.offsetControl.Name = "offsetControl";
			this.offsetControl.ReadOnly = true;
			this.offsetControl.Size = new System.Drawing.Size(136, 22);
			this.offsetControl.TabIndex = 21;
			this.offsetControl.Text = "";
			this.offsetControl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.offsetControl.TextChanged += new System.EventHandler(this.offsetControl_TextChanged);
			// 
			// tagTypesControl
			// 
			this.tagTypesControl.BackColor = System.Drawing.Color.Silver;
			this.tagTypesControl.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.tagTypesControl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.tagTypesControl.ImeMode = System.Windows.Forms.ImeMode.Off;
			this.tagTypesControl.ItemHeight = 16;
			this.tagTypesControl.Location = new System.Drawing.Point(4, 156);
			this.tagTypesControl.Name = "tagTypesControl";
			this.tagTypesControl.Size = new System.Drawing.Size(136, 24);
			this.tagTypesControl.TabIndex = 20;
			// 
			// label4
			// 
			this.label4.BackColor = System.Drawing.Color.Gainsboro;
			this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(4, 136);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(136, 20);
			this.label4.TabIndex = 19;
			this.label4.Text = "Tag\tType:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label8
			// 
			this.label8.BackColor = System.Drawing.Color.Gainsboro;
			this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label8.ForeColor = System.Drawing.Color.Black;
			this.label8.Location = new System.Drawing.Point(4, 92);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(136, 20);
			this.label8.TabIndex = 17;
			this.label8.Text = "Ident:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// sizeControl
			// 
			this.sizeControl.BackColor = System.Drawing.Color.Silver;
			this.sizeControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.sizeControl.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.sizeControl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sizeControl.ForeColor = System.Drawing.Color.Black;
			this.sizeControl.Location = new System.Drawing.Point(4, 68);
			this.sizeControl.Name = "sizeControl";
			this.sizeControl.Size = new System.Drawing.Size(136, 20);
			this.sizeControl.TabIndex = 16;
			this.sizeControl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label5
			// 
			this.label5.BackColor = System.Drawing.Color.Gainsboro;
			this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label5.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label5.ForeColor = System.Drawing.Color.Black;
			this.label5.Location = new System.Drawing.Point(4, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(136, 20);
			this.label5.TabIndex = 15;
			this.label5.Text = "Size:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label6
			// 
			this.label6.BackColor = System.Drawing.Color.Gainsboro;
			this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.label6.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label6.ForeColor = System.Drawing.Color.Black;
			this.label6.Location = new System.Drawing.Point(4, 4);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(136, 20);
			this.label6.TabIndex = 14;
			this.label6.Text = "Offset:";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// identControl
			// 
			this.identControl.BackColor = System.Drawing.Color.Silver;
			this.identControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.identControl.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.identControl.Location = new System.Drawing.Point(4, 112);
			this.identControl.Name = "identControl";
			this.identControl.ReadOnly = true;
			this.identControl.Size = new System.Drawing.Size(136, 22);
			this.identControl.TabIndex = 18;
			this.identControl.Text = "";
			this.identControl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// SelectedMetaInformation
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(146, 360);
			this.Controls.Add(this.xxxxxxxxxxxxxx);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "SelectedMetaInformation";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Meta";
			this.Load += new System.EventHandler(this.SelectedMetaInformation_Load);
			this.panel3.ResumeLayout(false);
			this.xxxxxxxxxxxxxx.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void xxxxxxxxxxxxxx_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		private void offsetControl_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void SelectedMetaInformation_Load(object sender, System.EventArgs e)
		{
		
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			Form1 shit = (Form1)this.MdiParent;
			shit.metasaveclick();
		}

		private void metaedit_Click(object sender, System.EventArgs e)
		{
			Form1 shit = (Form1)this.MdiParent;
			shit.plugingo();
			shit.metaedit_Click();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			Form1 shit = (Form1)this.MdiParent;
			shit.addtomap2();
			MessageBox.Show("Done");
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			Form1 shit = (Form1)this.MdiParent;
			shit.rawdataview();
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			if (scanmeta.BackColor==Color.Gray)
			{
				scanmeta.BackColor=Color.CornflowerBlue;
				Form1 shit = (Form1)this.MdiParent;
				shit.remotescanthis();
				
			}
			else
			{
				scanmeta.BackColor=Color.Gray;
			}
		}
	}
}
