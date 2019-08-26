using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsApplication2
{
	/// <summary>
	/// Summary description for deplist.
	/// </summary>
	public class deplist : System.Windows.Forms.Form
	{
		public System.Windows.Forms.Button button4;
		public System.Windows.Forms.ComboBox sr;
		public System.Windows.Forms.Button button2;
		public System.Windows.Forms.ComboBox types;
		public System.Windows.Forms.ComboBox names;
		public System.Windows.Forms.TreeView treeView2;
		public System.Windows.Forms.Panel panel4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public deplist()
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
			this.button4 = new System.Windows.Forms.Button();
			this.sr = new System.Windows.Forms.ComboBox();
			this.button2 = new System.Windows.Forms.Button();
			this.types = new System.Windows.Forms.ComboBox();
			this.names = new System.Windows.Forms.ComboBox();
			this.treeView2 = new System.Windows.Forms.TreeView();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel4.SuspendLayout();
			this.SuspendLayout();
			// 
			// button4
			// 
			this.button4.BackColor = System.Drawing.Color.Silver;
			this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button4.Location = new System.Drawing.Point(228, 484);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(92, 22);
			this.button4.TabIndex = 5;
			this.button4.Text = "Swap String";
			this.button4.Click += new System.EventHandler(this.button4_Click);
			// 
			// sr
			// 
			this.sr.ItemHeight = 13;
			this.sr.Location = new System.Drawing.Point(228, 459);
			this.sr.Name = "sr";
			this.sr.Size = new System.Drawing.Size(92, 21);
			this.sr.TabIndex = 4;
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.Silver;
			this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button2.Location = new System.Drawing.Point(4, 484);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(128, 22);
			this.button2.TabIndex = 3;
			this.button2.Text = "Swap Meta Reference";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// types
			// 
			this.types.ItemHeight = 13;
			this.types.Location = new System.Drawing.Point(136, 484);
			this.types.Name = "types";
			this.types.Size = new System.Drawing.Size(88, 21);
			this.types.TabIndex = 2;
			this.types.SelectedIndexChanged += new System.EventHandler(this.types_SelectedIndexChanged);
			// 
			// names
			// 
			this.names.ItemHeight = 13;
			this.names.Location = new System.Drawing.Point(4, 459);
			this.names.Name = "names";
			this.names.Size = new System.Drawing.Size(220, 21);
			this.names.TabIndex = 1;
			// 
			// treeView2
			// 
			this.treeView2.BackColor = System.Drawing.Color.LightSlateGray;
			this.treeView2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.treeView2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
			this.treeView2.ForeColor = System.Drawing.Color.White;
			this.treeView2.ImageIndex = -1;
			this.treeView2.LabelEdit = true;
			this.treeView2.Location = new System.Drawing.Point(4, 4);
			this.treeView2.Name = "treeView2";
			this.treeView2.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																				  new System.Windows.Forms.TreeNode("Dependencies"),
																				  new System.Windows.Forms.TreeNode("Lone ID\'s"),
																				  new System.Windows.Forms.TreeNode("Reflexives"),
																				  new System.Windows.Forms.TreeNode("Strings"),
																				  new System.Windows.Forms.TreeNode("Raw Pointers")});
			this.treeView2.SelectedImageIndex = -1;
			this.treeView2.Size = new System.Drawing.Size(316, 452);
			this.treeView2.TabIndex = 0;
			this.treeView2.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView2_AfterSelect);
			// 
			// panel4
			// 
			this.panel4.BackColor = System.Drawing.Color.Silver;
			this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel4.Controls.Add(this.button4);
			this.panel4.Controls.Add(this.sr);
			this.panel4.Controls.Add(this.button2);
			this.panel4.Controls.Add(this.types);
			this.panel4.Controls.Add(this.names);
			this.panel4.Controls.Add(this.treeView2);
			this.panel4.Location = new System.Drawing.Point(0, 0);
			this.panel4.Name = "panel4";
			this.panel4.Size = new System.Drawing.Size(328, 528);
			this.panel4.TabIndex = 6;
			// 
			// deplist
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(328, 510);
			this.Controls.Add(this.panel4);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "deplist";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Reference Editor";
			this.Resize += new System.EventHandler(this.shit_change);
			this.panel4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void treeView2_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			Form1 shit=(Form1)this.MdiParent;
			shit.treeView2_AfterSelect();
		
		}



		private void shit_change(object sender, System.EventArgs e)
		{
			panel4.Width=this.Width;
			panel4.Height=this.Height;	
			treeView2.Width=this.Width-18;
			treeView2.Height=this.Height-84;
			names.Top=treeView2.Top+treeView2.Height+3;
			names.Width=this.Width-sr.Width-20;
			sr.Left=names.Left+names.Width+2;
			sr.Top=names.Top;
			button4.Left=sr.Left;
			button4.Top=sr.Top+sr.Height+4;
			button2.Top=button4.Top;
			types.Top=button4.Top;
			Application.DoEvents();
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			Form1 shit=(Form1)this.MdiParent;
			shit.swapstuff();
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			Form1 shit=(Form1)this.MdiParent;
			shit.swapstring_Click();
		}

		private void types_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			Form1 shit=(Form1)this.MdiParent;
			shit.typeschanged();
		}
	}
}
