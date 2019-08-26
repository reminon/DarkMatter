using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace WindowsApplication2
{
	/// <summary>
	/// Summary description for MapInfo.
	/// </summary>
	public class MapInfo : System.Windows.Forms.Form
	{
		public System.Windows.Forms.Label sig;
		public System.Windows.Forms.Label label7;
		public System.Windows.Forms.Label secondarymagiccontrol;
		public System.Windows.Forms.Label primarymagiccontrol;
		public System.Windows.Forms.Label label2;
		public System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel panel2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MapInfo()
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
			this.sig = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.secondarymagiccontrol = new System.Windows.Forms.Label();
			this.primarymagiccontrol = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// sig
			// 
			this.sig.BackColor = System.Drawing.Color.Silver;
			this.sig.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.sig.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.sig.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.sig.ForeColor = System.Drawing.Color.Black;
			this.sig.Location = new System.Drawing.Point(8, 112);
			this.sig.Name = "sig";
			this.sig.Size = new System.Drawing.Size(128, 20);
			this.sig.TabIndex = 35;
			this.sig.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.Gainsboro;
			this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label7.ForeColor = System.Drawing.Color.Black;
			this.label7.Location = new System.Drawing.Point(8, 92);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(128, 20);
			this.label7.TabIndex = 34;
			this.label7.Text = "Signature:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// secondarymagiccontrol
			// 
			this.secondarymagiccontrol.BackColor = System.Drawing.Color.Silver;
			this.secondarymagiccontrol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.secondarymagiccontrol.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.secondarymagiccontrol.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.secondarymagiccontrol.ForeColor = System.Drawing.Color.Black;
			this.secondarymagiccontrol.Location = new System.Drawing.Point(8, 68);
			this.secondarymagiccontrol.Name = "secondarymagiccontrol";
			this.secondarymagiccontrol.Size = new System.Drawing.Size(128, 20);
			this.secondarymagiccontrol.TabIndex = 33;
			this.secondarymagiccontrol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// primarymagiccontrol
			// 
			this.primarymagiccontrol.BackColor = System.Drawing.Color.Silver;
			this.primarymagiccontrol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.primarymagiccontrol.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.primarymagiccontrol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.primarymagiccontrol.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.primarymagiccontrol.ForeColor = System.Drawing.Color.Black;
			this.primarymagiccontrol.Location = new System.Drawing.Point(8, 24);
			this.primarymagiccontrol.Name = "primarymagiccontrol";
			this.primarymagiccontrol.Size = new System.Drawing.Size(128, 20);
			this.primarymagiccontrol.TabIndex = 32;
			this.primarymagiccontrol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label2
			// 
			this.label2.BackColor = System.Drawing.Color.Gainsboro;
			this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(8, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(128, 20);
			this.label2.TabIndex = 31;
			this.label2.Text = "Secondary Magic:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// label1
			// 
			this.label1.BackColor = System.Drawing.Color.Gainsboro;
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.Black;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(128, 20);
			this.label1.TabIndex = 30;
			this.label1.Text = "Primary\tMagic:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel2.Location = new System.Drawing.Point(4, 4);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(136, 132);
			this.panel2.TabIndex = 36;
			// 
			// MapInfo
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.LightSlateGray;
			this.ClientSize = new System.Drawing.Size(144, 138);
			this.Controls.Add(this.sig);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.secondarymagiccontrol);
			this.Controls.Add(this.primarymagiccontrol);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.panel2);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.Name = "MapInfo";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Map Info";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
