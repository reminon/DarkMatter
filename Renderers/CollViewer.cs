
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Runtime.InteropServices;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using Direct3D = Microsoft.DirectX.Direct3D;
using sharedstuff;
using sharedstuff.RawData;
using sharedstuff.MetaStuff;
using System.IO;






namespace WindowsApplication2
{
	/// <summary>
	/// Summary description for ModelViewer.
	/// </summary>
	public class CollViewer : System.Windows.Forms.Form
	{

		//protected SamplerStates sampleState=SamplerStates();
		
		//protected D3DSettings graphicsSettings = new D3DSettings();
		float xzoom=1.5F;
		Device device = null; // Our rendering device
		CollData coll;
		IndexBuffer ib;
		VertexBuffer  vb;
		Texture tex=null;

MetaInfo meta;
		Form1 oldform;
	
		//PluginX plugin= new PluginX();
		//Define a FVF for our cuboids

		MapHeader map;
		
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button export;
		private System.Windows.Forms.Button import;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		
		public CollViewer()
		{
			
			//arcBall = new GraphicsArcBall(panel1);
			//enumerationSettings.AppUsesDepthBuffer = true;

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
			base.Hide();
		//	base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.export = new System.Windows.Forms.Button();
			this.import = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Black;
			this.panel1.Location = new System.Drawing.Point(4, 4);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(492, 472);
			this.panel1.TabIndex = 0;
			// 
			// export
			// 
			this.export.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.export.Location = new System.Drawing.Point(340, 480);
			this.export.Name = "export";
			this.export.TabIndex = 1;
			this.export.Text = "Export";
			this.export.Click += new System.EventHandler(this.export_Click);
			// 
			// import
			// 
			this.import.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.import.Location = new System.Drawing.Point(420, 480);
			this.import.Name = "import";
			this.import.TabIndex = 2;
			this.import.Text = "Import";
			this.import.Click += new System.EventHandler(this.import_Click);
			// 
			// ModelViewer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.SteelBlue;
			this.ClientSize = new System.Drawing.Size(500, 508);
			this.Controls.Add(this.import);
			this.Controls.Add(this.export);
			this.Controls.Add(this.panel1);
			this.Cursor = System.Windows.Forms.Cursors.SizeAll;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "CollViewer";
			this.Text = "Collision Viewer";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnPrivateKeyDown);
			this.Load += new System.EventHandler(this.CollViewer_Load);
			//	this.panel1.MouseDown+=new System.Windows.Forms.MouseEventHandler(arcBall.OnContainerMouseDown);
	//	this.panel1.MouseMove+=new System.Windows.Forms.MouseEventHandler(arcBall.OnContainerMouseMove);
	//	this.panel1.MouseUp+=new System.Windows.Forms.MouseEventHandler(arcBall.OnContainerMouseUp);

			this.ResumeLayout(false);

		}
		#endregion

	

		private void OnPrivateKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.Tab)
			{
				if (device.RenderState.FillMode==FillMode.WireFrame)
				{
					device.RenderState.FillMode=FillMode.Solid;
				}
				else
				{
					device.RenderState.FillMode=FillMode.WireFrame;
				}
			}
			else if (e.KeyCode == System.Windows.Forms.Keys.W)
            {
				xzoom-=0.1F;
			}
			else if (e.KeyCode == System.Windows.Forms.Keys.S)
			{
				xzoom+=0.1F;
			}
		}



		private void CollViewer_Load(object sender, System.EventArgs e)
		{
		
			using (CollViewer frm = this)
			{
				if (!frm.InitializeGraphics()) // Initialize Direct3D
				{
					MessageBox.Show("Could not initialize Direct3D.  This tutorial will exit.");
					return;
				}
				frm.Show();
				loadmesh();
				

				// While the form is still valid, render and process messages
				while(frm.Created)
				{
					FrameMove();
					frm.Render();
					//device.Present();
					Application.DoEvents();
					
				}
			}
		}


		
		

		public bool InitializeGraphics()
		{
			try	{
			
				// Now let's setup our D3D stuff
                PresentParameters presentParams = new PresentParameters();
				presentParams.Windowed=true;
				presentParams.SwapEffect = SwapEffect.Discard;
				//presentParams.PresentationInterval = PresentInterval.Immediate;
				presentParams.EnableAutoDepthStencil = true; // Turn on a Depth stencil
				presentParams.AutoDepthStencilFormat = DepthFormat.D16; // And the stencil format
				presentParams.BackBufferWidth=this.Width;
				presentParams.BackBufferHeight=this.Height;
				presentParams.BackBufferFormat=Manager.Adapters[0].CurrentDisplayMode.Format;
				presentParams.BackBufferCount=1;
				
				
			
				device = new Device(0, DeviceType.Hardware, panel1, CreateFlags.SoftwareVertexProcessing, presentParams);
				//device.RenderState.Lighting= true;
			//	device.RenderState.ZBufferFunction=ZBufferFunction.
				//device.RenderState.DitherEnable =true;
				
			//	device.RenderState.UseWBuffer=true;
				device.RenderState.ZBufferEnable = true; 
		//		device.RenderState.ZBufferWriteEnable = true; 

			
			//	device.SamplerState[0].MagFilter = TextureFilter.Linear;
			//	device.SamplerState[0].MinFilter = TextureFilter.Linear;
				//device.RenderState.StencilEnable =true;
				
			//	device.RenderState.FillMode = FillMode.WireFrame;
				device.RenderState.CullMode = Cull.CounterClockwise;
				//device.RenderState.VertexBlend=VertexBlend.Disable;//UseWBuffer = true;

				//arcBall.SetWindow( device.PresentationParameters.BackBufferWidth, device.PresentationParameters.BackBufferHeight,0.85f );
				//arcBall.Radius =5;// 300;//objectRadius;

				float fAspect = device.PresentationParameters.BackBufferWidth / (float)device.PresentationParameters.BackBufferHeight;
				device.Transform.Projection = Matrix.PerspectiveFovRH( (float)Math.PI/4, fAspect, 0.1f,400.0f);
//device.RenderState.CullMode = Cull.CounterClockwise;

		
			
				//device.Lights[0].Type = LightType.Point;
				//device.Lights[0].Direction = new Vector3(1, 0, 0);
				//device.Lights[0].Diffuse = Color.White;
				//device.Lights[0].Commit();
				//device.Lights[0].Enabled = true;
			//	
				device.RenderState.Ambient = Color.White;

				
				
				
				
				return true;
			}
			catch (DirectXException)
			{ 
				return false; 
			}
		}

	
		private void loadthemeshmofo(object sender, System.EventArgs e)
		{
			
			loadmesh();
		}
		public void SetRaw(ref CollData raw1,ref MetaInfo mi,ref MapHeader mp,ref Form1 fuck)
		{
			meta=mi;
			coll=raw1;
			map=mp;
			oldform=fuck;
		}



		public void loadmesh()
		{
			
			
			tex=TextureLoader.FromFile(device,Application.StartupPath + "\\moontexture.bmp");
		
	



					PositionNormalTexVertex[] verts=new PositionNormalTexVertex[coll.x.Length];
					int xxx;
					for (xxx=0;xxx<coll.x.Length;xxx++)
					{
						verts[xxx].Position=new Vector3(coll.x[xxx],coll.y[xxx], coll.z[xxx]);
						
					}


					
	vb=new VertexBuffer(typeof(CustomVertex.PositionNormalTextured),verts.Length,device,Usage.Dynamic,PositionNormalTexVertex.FVF,Pool.Default);
		
		}


		public void FrameMove()
		{
			// Setup world matrix
			Matrix matWorld = Matrix.Translation(0,0,0);
			//matWorld.Multiply(arcBall.RotationMatrix);
			//matWorld.Multiply(arcBall.TranslationMatrix);
			device.Transform.World = matWorld;

			// Set up view matrix
			Vector3 vFrom= new Vector3(1, 0,0 );
			Vector3 vAt = new Vector3( 0, 0, 0 );
			Vector3 vUp = new Vector3( 0, 1, 0 );
			device.Transform.View = Matrix.LookAtRH( vFrom, vAt, vUp );


		}

		public void Render()
		{
			if (device == null) 
				return;

			device.Clear(ClearFlags.Target  , System.Drawing.Color.Black, 1.0f, 0);
			device.BeginScene();
			Material shit=new Material();
			shit.Ambient=Color.Wheat;
			//shit.Diffuse=Color.Black;
		
				
			device.RenderState.FillMode=FillMode.WireFrame;
			device.Material=shit;
			//poo.DrawSubset(0);
			device.RenderState.FillMode=FillMode.WireFrame;
			device.VertexFormat = CustomVertex.PositionNormalTextured.Format;
			device.SetStreamSource(0,vb,0);
			device.DrawPrimitives(PrimitiveType.TriangleStrip,0,coll.x.Length);
			device.EndScene();
			device.Present();
		
	}

		private void export_Click(object sender, System.EventArgs e)
		{
			if (folderBrowserDialog1.ShowDialog()==DialogResult.Cancel) {return;}
			

			string pathname=meta.Names[meta.SelectedMeta];
			
			int where=pathname.LastIndexOf("\\");
			string temp=folderBrowserDialog1.SelectedPath;
			string objname=pathname.Substring(where+1,pathname.Length-where-1);
			if (where!=-1){temp=temp+"\\"+objname+".obj\\";}
			System.IO.Directory.CreateDirectory(temp);
			FileStream FSX=new FileStream(temp+objname+".info",FileMode.Create ,FileAccess.ReadWrite,FileShare.ReadWrite);
			StreamWriter SWX=new StreamWriter(FSX);
			SWX.WriteLine("#darkmatter;");

	
		}

		private void import_Click(object sender, System.EventArgs e)
		{
			
			if (folderBrowserDialog1.ShowDialog()==DialogResult.Cancel) {return;}
			string temp=folderBrowserDialog1.SelectedPath;
			string[] split1=temp.Split('\\');
			string[] split2=split1[split1.Length-1].Split('.');
			string objname=split2[0];
			//string imports=null;
			FileStream FS=new FileStream(temp+"\\"+objname+".info",FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
			StreamReader SR=new StreamReader(FS);
		
		}
	}
}
