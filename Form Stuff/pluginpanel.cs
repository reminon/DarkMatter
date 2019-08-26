using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsApplication2
{
	/// <summary>
	/// Summary description for pluginpanel.
	/// </summary>
	public class pluginpanel : System.Windows.Forms.Form
	{
		public System.Windows.Forms.Button button5;
		public System.Windows.Forms.Panel panel1;
		public System.Windows.Forms.TabControl tabControl1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public pluginpanel()
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
			this.button5 = new System.Windows.Forms.Button();
			this.panel1 = new System.Windows.Forms.Panel();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button5
			// 
			this.button5.BackColor = System.Drawing.Color.LightGray;
			this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button5.Location = new System.Drawing.Point(8, 488);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(140, 24);
			this.button5.TabIndex = 14;
			this.button5.Text = "Save Changes";
			this.button5.Click += new System.EventHandler(this.button5_Click);
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.SystemColors.Control;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Controls.Add(this.button5);
			this.panel1.Controls.Add(this.tabControl1);
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(324, 518);
			this.panel1.TabIndex = 8;
			// 
			// tabControl1
			// 
			this.tabControl1.ItemSize = new System.Drawing.Size(0, 18);
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(324, 484);
			this.tabControl1.TabIndex = 0;
			// 
			// pluginpanel
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(324, 518);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "pluginpanel";
			this.Text = "pluginpanel";
			this.Resize += new System.EventHandler(this.panel1_Paint);
			this.Load += new System.EventHandler(this.pluginpanel_Load);
			this.panel1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void pluginpanel_Load(object sender, System.EventArgs e)
		{
		
		}

		private void panel1_Paint(object sender, System.EventArgs e)
		{
			this.panel1.Width=this.Width;
			this.panel1.Height=this.Height;
			this.tabControl1.Width=panel1.Width;
			this.tabControl1.Height=panel1.Height-60;
			button5.Top=tabControl1.Height+tabControl1.Top+4;
			Application.DoEvents();
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			Form1 shit=(Form1)this.MdiParent;
			shit.pluginsave();
		
		}
	}
}
