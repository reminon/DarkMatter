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
using sharedstuff.MetaStuff;
using sharedstuff.RawData;
using System.IO;


namespace WindowsApplication2
{
	/// <summary>
	/// Summary description for BSPViewer.
	/// </summary>
	public class BSPViewer : System.Windows.Forms.Form
	{
		bool render=true;
		Point pt=new Point();
		Quaternion curq=new Quaternion();
	
		Vector3 oldvec =new Vector3();
		
		Matrix[] spawnmatrix=new Matrix[100000];
		Mesh[] spawnsmesh=new Mesh[100000];
		int selectedspawn=-1;
		spawninfo.SpawnType currentspawntype=new sharedstuff.spawninfo.SpawnType();
	
		spawninfo[] spawns=new spawninfo[100000];
		Mesh[][][][] fuckmesh=new Mesh[100000][][][];
		int spawncount;

		
	
		VertexShader shader = null;    // Vertex shader
		VertexDeclaration declaration = null;
		BitmData bitm;
		Device device = null; // Our rendering device
		float oldx;
		float oldy;
		float oldz;
		bspstuff bsp;
		IndexBuffer[] ib;
		VertexBuffer[]  vb;
		IndexBuffer ib2;
		VertexBuffer  vb2;

		
		Material jjj;
		Texture[] tex;
		Texture[] tex2;
	
		public ContextMenu popUpMenu=new ContextMenu();
		
		Material k=new Material();
		Material kk=new Material();
		Material ki=new Material();
		
		MetaInfo meta;
		Bitmap[] m;
		MapHeader map;
		//GraphicsArcBall arcBall = null;//new GraphicsArcBall(this);             // Mouse rotation utility
		ModelData mode;
		Form1 oldform;
		Matrix Rotate;
		Matrix Translate;
		float speed=0.2f;
		Vector3 v3MouseStartPos = new Vector3();
		Vector3 v3MouseNewPos = new Vector3();
		Vector3 v3CurrMeshPos = new Vector3();
		bool dragFlag;


		Quaternion tempq;
		float camx=0;
		float camy=0;
		float camz=15;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem savechanges;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBarPanel objectname;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem wireframe;
		private System.Windows.Forms.MenuItem textured;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		
		public BSPViewer()
		{			

			//arcBall = new GraphicsArcBall(panel1);
			//enumerationSettings.AppUsesDepthBuffer = true;
			Rotate=new Matrix();
			Rotate=Matrix.Identity;
			Translate=new Matrix();
			Translate=Matrix.Identity;
			currentspawntype=spawninfo.SpawnType.PlayerSpawn;
		
			k.Ambient=Color.Yellow;
			k.Diffuse=Color.Yellow;
			k.Ambient=Color.Red;
			kk.Diffuse=Color.Red;
			ki.Ambient=Color.Black;
			ki.Diffuse=Color.Black;

			popUpMenu.MenuItems.Add("Bipeds",new EventHandler(popup));
			popUpMenu.MenuItems.Add("Collections",new EventHandler(popup));
			popUpMenu.MenuItems.Add("Scenery",new EventHandler(popup));
			popUpMenu.MenuItems.Add("AI",new EventHandler(popup));
			popUpMenu.MenuItems.Add("Obstacles",new EventHandler(popup));
			popUpMenu.MenuItems.Add("Player Spawns",new EventHandler(popup));
			popUpMenu.MenuItems.Add("Machine",new EventHandler(popup));
			popUpMenu.MenuItems.Add("Vehicle",new EventHandler(popup));
			popUpMenu.MenuItems.Add("Equipment",new EventHandler(popup));
			popUpMenu.MenuItems.Add("Unknown",new EventHandler(popup));
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}
		private void popup(object sender, EventArgs e) 
		{
			MenuItem miClicked = (MenuItem)sender;
			if (miClicked.Checked==false){miClicked.Checked=true;}
			else {miClicked.Checked=false;}
			return;
			
		}
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			device.Dispose();
			
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Hide();
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel1 = new System.Windows.Forms.Panel();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.savechanges = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.wireframe = new System.Windows.Forms.MenuItem();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.objectname = new System.Windows.Forms.StatusBarPanel();
			this.textured = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			((System.ComponentModel.ISupportInitialize)(this.objectname)).BeginInit();
			this.SuspendLayout();
			// 
			// splitter1
			// 
			this.splitter1.Location = new System.Drawing.Point(0, 0);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 534);
			this.splitter1.TabIndex = 0;
			this.splitter1.TabStop = false;
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Black;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.panel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
			this.panel1.Location = new System.Drawing.Point(0, 0);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(912, 512);
			this.panel1.TabIndex = 9;
			this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem2});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.savechanges,
																					  this.menuItem3,
																					  this.menuItem4});
			this.menuItem1.Text = "File";
			// 
			// savechanges
			// 
			this.savechanges.Index = 0;
			this.savechanges.Text = "Save Changes";
			this.savechanges.Click += new System.EventHandler(this.savechanges_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.wireframe,
																					  this.textured});
			this.menuItem2.Text = "Options";
			// 
			// wireframe
			// 
			this.wireframe.Checked = true;
			this.wireframe.Index = 0;
			this.wireframe.Text = "WireFrame";
			this.wireframe.Click += new System.EventHandler(this.wireframe_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(3, 510);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.objectname});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(909, 24);
			this.statusBar1.TabIndex = 10;
			this.statusBar1.Text = "dfsdfsdfsdfsd";
			// 
			// objectname
			// 
			this.objectname.Width = 1500;
			// 
			// textured
			// 
			this.textured.Checked = true;
			this.textured.Index = 1;
			this.textured.Text = "Textured";
			this.textured.Click += new System.EventHandler(this.textured_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "-";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "Export Mesh";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// BSPViewer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(912, 534);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.splitter1);
			this.Cursor = System.Windows.Forms.Cursors.SizeAll;
			this.Menu = this.mainMenu1;
			this.Name = "BSPViewer";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "BSPViewer";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnPrivateKeyDown);
			this.Load += new System.EventHandler(this.BSPViewer_Load);
			((System.ComponentModel.ISupportInitialize)(this.objectname)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

	
		private Matrix makematrix()
		{
			Matrix o=Matrix.Identity;
			if (spawns[selectedspawn].rotate==spawninfo.RotateType.RotateYawPitchRoll)
			{
				o.Multiply(Matrix.RotationX(-spawns[selectedspawn].yaw));
				o.Multiply(Matrix.RotationY(spawns[selectedspawn].pitch));
				o.Multiply(Matrix.RotationZ(spawns[selectedspawn].roll));
				//o.Multiply(Matrix.RotationYawPitchRoll(spawns[selectedspawn].yaw,spawns[selectedspawn].pitch,spawns[selectedspawn].roll));
			}
			else
			{
				o.Multiply(Matrix.RotationZ(spawns[selectedspawn].yaw));
			}
			o.Multiply(Matrix.Translation(spawns[selectedspawn].vec));
			spawnmatrix[selectedspawn]=o;
			return o;
		}


		private void OnPrivateKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.A)
			{
				Matrix m=new Matrix();
				m.Translate(speed,0,0);
				Translate.Multiply(m);
			
			}
			else if (e.KeyCode == System.Windows.Forms.Keys.D)
			{
				
				Matrix m=new Matrix();
				m.Translate(-speed,0,0);
				Translate.Multiply(m);
			}
			else if (e.KeyCode == System.Windows.Forms.Keys.S)
			{
				Matrix m=new Matrix();
				m.Translate(0,speed,0);
				Translate.Multiply(m);
			}
			else if (e.KeyCode == System.Windows.Forms.Keys.W)
			{
				
				Matrix m=new Matrix();
				m.Translate(0,-speed,0);
				Translate.Multiply(m);
			}
			else if (e.KeyCode == System.Windows.Forms.Keys.Z)
			{
				Matrix m=new Matrix();
				m.Translate(0,0,speed);
				Translate.Multiply(m);
			}
			else if (e.KeyCode == System.Windows.Forms.Keys.X)
			{
				Matrix m=new Matrix();
				m.Translate(0,0,-speed);
				Translate.Multiply(m);
			}
			
			else if (e.KeyCode == System.Windows.Forms.Keys.I)
			{
			Rotate.Multiply(Matrix.RotationX(-0.1f));
			}
			else if (e.KeyCode == System.Windows.Forms.Keys.K)
			{
			Rotate.Multiply(Matrix.RotationX(+0.1f));
			}

			else if (e.KeyCode == System.Windows.Forms.Keys.J)
			{
				Rotate.Multiply(Matrix.RotationZ(-0.1f));
			}
			else if (e.KeyCode == System.Windows.Forms.Keys.L)
			{
				Rotate.Multiply(Matrix.RotationZ(+0.1f));
			}

			else if (e.KeyCode == System.Windows.Forms.Keys.PageUp)
			{
				if (selectedspawn!=-1)
				{
					spawns[selectedspawn].vec.Z-=0.1f;
					spawnmatrix[selectedspawn]=makematrix();
				}
				
			}
			else if (e.KeyCode == System.Windows.Forms.Keys.PageDown)
			{
				if (selectedspawn!=-1)
				{
					spawns[selectedspawn].vec.Z+=0.1f;
					spawnmatrix[selectedspawn]=makematrix();
				}
			
			}
			else if (e.KeyCode == System.Windows.Forms.Keys.Home)
			{
				if (selectedspawn!=-1)
				{
					spawns[selectedspawn].yaw+=0.1f;
					spawnmatrix[selectedspawn]=makematrix();
				}
				
			}
			else if (e.KeyCode == System.Windows.Forms.Keys.End)
			{
				if (selectedspawn!=-1 && spawns[selectedspawn].rotate==spawninfo.RotateType.RotateYawPitchRoll)
				{
					spawns[selectedspawn].pitch+=0.1f;
					spawnmatrix[selectedspawn]=makematrix();
				}
				
		
			}
			else if (e.KeyCode == System.Windows.Forms.Keys.Delete)
			{
				if (selectedspawn!=-1 && spawns[selectedspawn].rotate==spawninfo.RotateType.RotateYawPitchRoll)
				{
					spawns[selectedspawn].roll+=0.1f;
					spawnmatrix[selectedspawn]=makematrix();
				}
				
			}

	
	
		
			else if (e.KeyCode == System.Windows.Forms.Keys.Up)
			{
			
				if (selectedspawn!=-1)
				{
					spawns[selectedspawn].vec.Y+=0.1f;
					spawnmatrix[selectedspawn]=makematrix();
				}
				
			}
			else if (e.KeyCode == System.Windows.Forms.Keys.Down)
			{
				if (selectedspawn!=-1)
				{
					spawns[selectedspawn].vec.Y-=0.1f;
					spawnmatrix[selectedspawn]=makematrix();
				}
			
			}
			else if (e.KeyCode == System.Windows.Forms.Keys.Left)
			{
				if (selectedspawn!=-1)
				{
					spawns[selectedspawn].vec.X-=0.1f;
					spawnmatrix[selectedspawn]=makematrix();
				}
				
			}
			else if (e.KeyCode == System.Windows.Forms.Keys.Right)
			{
				
				if (selectedspawn!=-1)
				{
					spawns[selectedspawn].vec.X+=0.1f;
					spawnmatrix[selectedspawn]=makematrix();
				}
			
			}

			else if (e.KeyCode == System.Windows.Forms.Keys.Oemcomma|e.KeyCode == System.Windows.Forms.Keys.Add)
			{
				speed*=2;
			}
			else if (e.KeyCode == System.Windows.Forms.Keys.OemPeriod|e.KeyCode == System.Windows.Forms.Keys.Subtract)
			{
				speed/=2;
			}
			render=true;

		}



		private void BSPViewer_Load(object sender, System.EventArgs e)
		{
		
			using (BSPViewer frm = this)
			{
				if (!frm.InitializeGraphics()) // Initialize Direct3D
				{
					MessageBox.Show("Could not initialize Direct3D.  This tutorial will exit.");
					return;
				}
				//Translate=Matrix.Translation(scenery.vec[0]);
				frm.Show();
				loadmesh();
				oldvec=spawns[0].vec;
				this.panel1.MouseDown+=new MouseEventHandler(panel_MouseDown);
				this.panel1.MouseMove+=new MouseEventHandler(panel_MouseMove);
				this.panel1.MouseUp+=new MouseEventHandler(panel_MouseUp );
				//this.panel1.MouseDown+=new MouseEventHandler(arcBall.OnContainerMouseDown);
				//this.panel1.MouseMove+=new MouseEventHandler(arcBall.OnContainerMouseMove);
				//this.panel1.MouseUp+=new MouseEventHandler(arcBall.OnContainerMouseUp );
				// While the form is still valid, render and process messages
				while(frm.Created)
				{
					FrameMove();
					frm.Render();
					Application.DoEvents();
					//device.Present();
					
					
				}
				
			}
		}


		public bool InitializeGraphics()
		{
			try	
			{
				// Now let's setup our D3D stuff
				PresentParameters presentParams = new PresentParameters();
				presentParams.Windowed=true;
				presentParams.SwapEffect = SwapEffect.Discard;
				//presentParams.PresentationInterval = PresentInterval.;
				presentParams.EnableAutoDepthStencil = true; // Turn on a Depth stencil
				presentParams.AutoDepthStencilFormat = DepthFormat.D16; // And the stencil format
				presentParams.BackBufferWidth=panel1.Width;
				presentParams.BackBufferHeight=panel1.Height;
				presentParams.BackBufferFormat=Manager.Adapters[0].CurrentDisplayMode.Format;
				presentParams.BackBufferCount=1;

			int adapterOrdinal = Manager.Adapters.Default.Adapter;
			CreateFlags flags = CreateFlags.SoftwareVertexProcessing;
			// Check to see if we can use a pure hardware device
			Caps caps = Manager.GetDeviceCaps(adapterOrdinal, DeviceType.Hardware);
			// Do we support hardware vertex processing?
			if (caps.DeviceCaps.SupportsHardwareTransformAndLight)
				// Replace the software vertex processing
				flags = CreateFlags.SoftwareVertexProcessing;
  
				try
				{

					device = new Device(0, DeviceType.Hardware, panel1, flags, presentParams);

				}
				catch
				{
						device = new Device(0, DeviceType.Software, panel1, flags, presentParams);
				}
				device.RenderState.Lighting= true;
				device.RenderState.ZBufferEnable=true;

				device.SamplerState[0].MagFilter = TextureFilter.Linear;
				device.SamplerState[0].MinFilter = TextureFilter.Linear;
	

				float fAspect = device.PresentationParameters.BackBufferWidth / (float)device.PresentationParameters.BackBufferHeight;
				device.Transform.Projection = Matrix.PerspectiveFovRH( (float)Math.PI/4, fAspect, 0.1f,1000.0f);
			
				if ((device.DeviceCaps.VertexProcessingCaps.SupportsDirectionAllLights) &&
					(device.DeviceCaps.MaxActiveLights > 1))
				{
					// First light
					device.Lights[0].Type = LightType.Directional;
					device.Lights[0].Diffuse = Color.White;
					device.Lights[0].Direction = new Vector3(0, 0, 0);
					device.Lights[0].Commit();
					device.Lights[0].Enabled = true;
					// Second light
					device.Lights[1].Type = LightType.Directional;
					device.Lights[1].Diffuse = Color.White;
					device.Lights[1].Direction = new Vector3(0, 0, 0);
					device.Lights[1].Commit();
					device.Lights[1].Enabled = true;
				}
				else
				{
					// Hmm.. no light support, let's just use
					// ambient light
					device.RenderState.Ambient = Color.White;
				}
			
				device.RenderState.SourceBlend = Blend.SourceAlpha; //set the source to be the source's alpha
				device.RenderState.DestinationBlend = Blend.InvSourceAlpha; //set the destination to be the inverse of the source's alpha
				//device.TextureState[0].ColorArgument1 = TextureArgument.TextureColor;
				//device.TextureState[0].ColorOperation = TextureOperation.AddSmooth;
				//	device.TextureState[0].ColorArgument2 = TextureArgument.TextureColor;
				//device.TextureState[1].ColorArgument1 = TextureArgument.TextureColor;
				//device.TextureState[1].ColorOperation = TextureOperation.DotProduct3;
				//device.TextureState[1].ColorArgument2 = TextureArgument.Diffuse;



				device.TextureState[0].TextureCoordinateIndex = 0;
				device.TextureState[0].ColorOperation = TextureOperation.SelectArg1;
				device.TextureState[0].ColorArgument1 = TextureArgument.TextureColor;
				device.TextureState[0].ColorArgument2 = TextureArgument.Current;
				//device.TextureState[1].TextureCoordinateIndex = 1;
				//device.TextureState[1].ColorOperation = TextureOperation.BumpEnvironmentMap;
				//device.TextureState[1].ColorArgument1 = TextureArgument.TextureColor;
				//device.TextureState[1].ColorArgument2 = TextureArgument.Current;


				//device.TextureState[1].BumpEnvironmentMaterial00 = 0.2F;
				//device.TextureState[1].BumpEnvironmentMaterial01 = 0.2F;
				//device.TextureState[1].BumpEnvironmentMaterial10 = 0.2F;
				//device.TextureState[1].BumpEnvironmentMaterial11 = 0.2F;
			







			
				return true;
			}
			catch (DirectXException)
			{ 
				return false; 
			}
		}

		public void SetRaw(ref bspstuff raw1,ref spawninfo[] s, ref MapHeader mp,ref Form1 fr,ref MetaInfo mi,int spawnnum )
		{
			bsp=raw1;
			spawns=s;
			map=mp;
			oldform=fr;
			meta=mi;
			spawncount=spawnnum;
			
		}
		public void SetMode(ref ModelData mod)
		{
			mode=mod;
		}
	

		public void loadmesh()
		{
	
			jjj=new Material();
			jjj.Ambient=Color.FromArgb(255,255,255,255);

			int g;
		

			tex=new Texture[bsp.shaders1.Length];
			tex2=new Texture[bsp.shaders1.Length];
			m=new Bitmap[bsp.shaders1.Length];
			for (g=0;g<bsp.shaders1.Length;g++)
			{	
			
				try
				{
						
					tex[g]=new Texture(device,bsp.shaders1[g].b,Usage.Dynamic,Pool.Default);

				//	tex2[g]=new Texture(device,bsp.shaders1[g].b2,Usage.Dynamic,Pool.Default);
				}
				catch
				{
				}
		
			}
			vb=new VertexBuffer[bsp.Model1Count[bsp.selected]];
			ib=new IndexBuffer[bsp.Model1Count[bsp.selected]];
	
			for (g=0;g<bsp.Model1Count[bsp.selected];g++)
			{
				Application.DoEvents();
				if (bsp.Model1RawChunkTotalSize[bsp.selected][g].Length==0){continue;}
				vb[g]= new VertexBuffer(typeof(CustomVertex.PositionNormalTextured),bsp.Model1RawVerticeCount[bsp.selected][g], device, Usage.SoftwareProcessing,CustomVertex.PositionNormalTextured.Format, Pool.Managed);
				
			
				CustomVertex.PositionNormalTextured[] verts =(CustomVertex.PositionNormalTextured[]) vb[g].Lock(0,0);//new CustomVertex.PositionNormalTextured[mode.VerticeCount[num]];
				int xxx;
				for (xxx=0;xxx<bsp.Model1RawVerticeCount[bsp.selected][g];xxx++)
				{
					float theta = (float)(2 * Math.PI * xxx) / 49;
					verts[xxx].SetPosition(new Vector3(bsp.X[bsp.selected][g][xxx], bsp.Y[bsp.selected][g][xxx], bsp.Z[bsp.selected][g][xxx]));
					//verts[xxx].SetNormal(new Vector3((float)Math.Sin(theta), 0, (float)Math.Cos(theta)));
					verts[xxx].Tu = bsp.U[bsp.selected][g][xxx];
					verts[xxx].Tv = bsp.V[bsp.selected][g][xxx];
				}


				
				
				vb[g].Unlock();
		

			
			}
			

		
			
			for (g=0;g<bsp.Model1Count[bsp.selected];g++)
			{
				if (bsp.Model1RawChunkTotalSize[bsp.selected][g].Length==0){continue;}
				ib[g]=new IndexBuffer(typeof(short),bsp.Model1RawIndiceCount[bsp.selected][g],device,Usage.SoftwareProcessing, Pool.Managed);
				ib[g].Lock(0,LockFlags.None);
				ib[g].SetData(bsp.Model1Indices[bsp.selected][g],0,LockFlags.None);
			}
			//ib.Unlock();
	
			//bsp.spawns=new ModelData[spawns.count];
			//spawnsmesh=new Mesh[spawns.count];
			//fuckmesh=new Mesh[spawns.count][][][];
			//spawnmatrix=new Matrix[spawns.count];
			int[] taglist=new int[100000];

			for (g=0;g<spawncount;g++)
			{
				if (spawns[g].tag==-1){continue;}
				Application.DoEvents();			

				Matrix o=	Matrix.Identity;
				if (spawns[g].rotate==spawninfo.RotateType.RotateYawPitchRoll)
				{
					o.Multiply(Matrix.RotationYawPitchRoll(spawns[g].pitch,spawns[g].roll,spawns[g].yaw));
				}
				else
				{
					o.Multiply(Matrix.RotationZ(spawns[g].yaw));
				}
				o.Multiply(Matrix.Translation(spawns[g].vec));
				spawnmatrix[g]=o;

				
				int jewunit=Array.IndexOf(taglist,spawns[g].tag);
				taglist[g]=spawns[g].tag;
				if (jewunit==-1)
				{
					
					mode=spawns[g].mode;
					fuckmesh[g]=loadmeshx();
					Mesh f=Mesh.Box(device,mode.MaxX-mode.MinX,mode.MaxY-mode.MinY,mode.MaxZ-mode.MinZ);
					spawnsmesh[g]=f;
				}
				else
				{	
					spawns[g].mode=spawns[jewunit].mode;
					fuckmesh[g]=fuckmesh[jewunit];
					spawnsmesh[g]=spawnsmesh[jewunit];
					continue;
				}
				//	mode.shaders=new ShaderInfo[mode.shaders.Length];	
				for (int u=0;u<mode.shaders.Length;u++)
				{
					try
					{
						mode.shaders[u].t=Texture.FromBitmap(device,mode.shaders[u].b,Usage.Dynamic,Pool.Default);
						///mode.shaders[u].t2=new Texture(device,mode.shaders[u].b2,Usage.Dynamic,Pool.Default);
					}
					catch
					{
					}
				}
				spawns[g].mode=mode;
			}





			


		}

		public Mesh[][][] loadmeshx()
		{
			Mesh[][][] poo;
			poo = new Mesh[mode.LOD.Length][][];
	
			int g;
			for (g=0;g<mode.LOD.Length;g++)
			{
				poo[g] = new Mesh[mode.LODName2[g].Length][];
				
				for (int gg=0;gg<mode.LODName2[g].Length;gg++)
				{
					poo[g][gg] = new Mesh[mode.LOD[g][gg].Length];

					for (int ggg=0;ggg<1;ggg++)//mode.LOD[g][gg].Length;ggg++)
					{
						
			
						int num=mode.LOD[g][gg][ggg];
					



						PositionNormalTexVertex[] verts=new PositionNormalTexVertex[mode.VerticeCount[num]];
						int xxx;
						for (xxx=0;xxx<mode.VerticeCount[num];xxx++)
						{
							float theta = (float)(2 * Math.PI * xxx) / mode.VerticeCount[num];
							verts[xxx].Position=new Vector3(mode.X[num][xxx], mode.Y[num][xxx], mode.Z[num][xxx]);
							verts[xxx].Normal=new Vector3(mode.nX[num][xxx], mode.nY[num][xxx], mode.nZ[num][xxx]);
							verts[xxx].Tu0 = mode.U[num][xxx];
							verts[xxx].Tv0 = mode.V[num][xxx];
						}


					
						poo[g][gg][ggg]=MakeMesh(verts,verts.Length,mode.FixedIndices2[num],mode.FixedIndices2[num].Length);
				

						//int[] Adj=new int[poo[g][gg].NumberFaces*3];
						//poo[g][gg].GenerateAdjacency(0.2f,Adj);		
						//poo[g][gg].ComputeNormals(Adj);

						int[] faceCount=new int[mode.InfoBlockCount[num]];
						int r;
						for (r=0;r<mode.InfoBlockCount[num];r++)
						{
							faceCount[r]=mode.FixedIndices[num][r].Length/3;
							//	fart+=mode.EndOfIndices[num][r]/3;
						}
		
						int[] attribBuf=poo[g][gg][ggg].LockAttributeBuffer(LockFlags.None);
						int numFaces=attribBuf.Length;
						int faceNum=0;
						for (int i=0;i<mode.InfoBlockCount[num];i++) 
						{
							if (faceNum+faceCount[i]>numFaces) 
							{
								int test=numFaces-faceNum;//-faceCount[i];
								for (int j=0;j<test;j++) 
								{
									attribBuf[faceNum]=i;
									faceNum++;
								}
								break;
							}
 
							for (int j=0;j<faceCount[i];j++) 
							{
								attribBuf[faceNum]=i;
								faceNum++;
							}
						}
			
						poo[g][gg][ggg].UnlockAttributeBuffer(attribBuf);

					}
				}
				
		
			}
			return poo;
		}

		public Mesh MakeMesh(PositionNormalTexVertex[] verts,int vertcount,short[] indices,int indicecount)
		{
			Mesh temp=new Mesh(indicecount/3,vertcount,MeshFlags.Managed ,PositionNormalTexVertex.FVF,device);	
			vb2=temp.VertexBuffer;
			vb2.SetData(verts,0,LockFlags.None );
			vb2.Unlock();
		
			ib2=temp.IndexBuffer;
			ib2.SetData(indices,0,LockFlags.None);
			return temp;
				
		}


		public void FrameMove()
		{
			// Set up view matrix
			Vector3 vFrom=new Vector3();
			//vFrom= new Vector3(camx, camy,camz );
			vFrom= new Vector3(0,0,5);
			Vector3 vAt = new Vector3(0,0,0);
			Vector3 vUp = new Vector3( 0,1, 0 );
			Matrix fuck=Matrix.LookAtRH( vFrom, vAt, vUp );
			
			//fuck=new Matrix();
			//fuck=Matrix.Identity;
			fuck.Multiply(Rotate);
			fuck.Multiply(Translate);
			//fuck.Multiply(arcBall.TranslationMatrix);
			//fuck.Multiply(arcBall.RotationMatrix);

			device.Transform.View = fuck;

		

		}

		public void Render()
		{
			if (device == null && render!=false) 
				return;
			render=false;
			device.Clear(ClearFlags.Target|ClearFlags.ZBuffer, System.Drawing.Color.Black, 1.0f,0);
			device.BeginScene();
			//device.RenderState.Fillbsp.spawns[i]=Fillbsp.spawns[i].WireFrame; 
		
			//Set up a material. The material here just has the diffuse and ambient
			//colors set to yellow. Note that only one material can be used at a time.
			
			
			int g;
		
			device.RenderState.CullMode=Cull.None ;

			Matrix matWorld = Matrix.Translation(0,0,0);
			device.Transform.World = matWorld;
device.SetTexture(0,null);
			for (g=0;g<bsp.Model1Count[bsp.selected];g++)
			{
			
				

				if (bsp.Model1RawChunkTotalSize[bsp.selected][g].Length==0){continue;}
		
				device.SetStreamSource(0,vb[g],0);
				device.VertexFormat = CustomVertex.PositionNormalTextured.Format;
				device.Indices=ib[g];
			
						

			
				

				//device.RenderState.DiffuseMaterialSource=ColorSource.Material;
				for (int b=0;b<bsp.StartOfIndices1[g].Length;b++)
				{
					if (textured.Checked==true)
					{
						device.SetTexture(0,tex[bsp.Texture1[g][b]]);
						string tempo=bsp.shaders1[bsp.Texture1[g][b]].stemname;
						if (tempo.IndexOf("alphatest")!=-1)
						{
							device.RenderState.AlphaTestEnable=true;
							device.RenderState.AlphaBlendEnable=false;
						}
						else if (tempo.IndexOf("alpha")!=-1)
						{
							device.RenderState.AlphaTestEnable=false;
							device.RenderState.AlphaBlendEnable=true;
						}
						else if (tempo.IndexOf("water")!=-1)
						{
							device.RenderState.AlphaTestEnable=false;
							device.RenderState.AlphaBlendEnable=true;
						}
						else 
						{
							device.RenderState.AlphaTestEnable=false;
							device.RenderState.AlphaBlendEnable=false;
						}
						//device.SetTexture(1,tex2[bsp.Texture1[g][b]]);
					}
					device.Material = jjj;
					device.RenderState.FillMode=FillMode.Solid;
					device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0,bsp.Model1RawVerticeCount[bsp.selected][g],bsp.StartOfIndices1[g][b],bsp.EndOfIndices1[g][b]/3);
				
					if (wireframe.Checked==true)
					{
						device.RenderState.AlphaTestEnable=false;
						device.RenderState.AlphaBlendEnable=false;
						device.Material = ki;
						device.SetTexture(0,null);
						device.RenderState.FillMode=FillMode.WireFrame;
						device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0,bsp.Model1RawVerticeCount[bsp.selected][g],bsp.StartOfIndices1[g][b],bsp.EndOfIndices1[g][b]/3);
					}
				}

		
				//device.Transform.World = matWorld;
				//device.Material = mtrl;
				//device.RenderState.Fillbsp.spawns[i]=Fillbsp.spawns[i].WireFrame;
				//device.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0,bsp.bsp.spawns[i]l1RawVerticeCount[bsp.selected][g],0,bsp.bsp.spawns[i]l1FaceCount[bsp.selected][g]);
			}
		

			
			device.RenderState.AlphaTestEnable=false;
			device.RenderState.AlphaBlendEnable=false;
			device.RenderState.CullMode=Cull.None ;
			for (int i=0;i<spawncount;i++)
			{
				if (spawns[i].tag==-1){continue;}
			
				bool go=false;
				foreach (MenuItem c in popUpMenu.MenuItems)
				{
					if (c.Checked==false){continue;}
					currentspawntype=spawninfo.SpawnType.Null;
					switch (c.Text)
					{
						case "Bipeds":
							currentspawntype=spawninfo.SpawnType.Biped;
							break;
						case "Collections":
							currentspawntype=spawninfo.SpawnType.Collection;
							break;
						case "Scenery":
							currentspawntype=spawninfo.SpawnType.Scenery;
							break;
						case "AI":
							currentspawntype=spawninfo.SpawnType.AI;
							break;
						case "Obstacles":
							currentspawntype=spawninfo.SpawnType.Obstacle;
							break;
						case "Player Spawns":
							currentspawntype=spawninfo.SpawnType.PlayerSpawn;
							break;
						case "Machine":
							currentspawntype=spawninfo.SpawnType.Machine;
							break;
						case "Vehicle":
							currentspawntype=spawninfo.SpawnType.Vehicle;
							break;	
						case "Equipment":
							currentspawntype=spawninfo.SpawnType.Equipment;
							break;	
						case "Unknown":
							currentspawntype=spawninfo.SpawnType.KOTH;
							break;	
				
					}
					if (spawns[i].type==currentspawntype){go=true;break;}
				}

				if(go==false){continue;}





			
				Vector3 tempV3=spawns[i].vec;
				tempV3.Project(device.Viewport, device.Transform.Projection,device.Transform.View,Matrix.Identity);
				if (tempV3.X<device.Viewport.X-50|tempV3.X>device.Viewport.X+device.Viewport.Width+50){continue;}
				if (tempV3.Y<device.Viewport.Y-50|tempV3.Y>device.Viewport.Y+device.Viewport.Height+50){continue;}
				if (tempV3.Z<device.Viewport.MinZ-50|tempV3.Z>device.Viewport.MaxZ+50){continue;}
				device.Transform.World=spawnmatrix[i];
				if (i==selectedspawn)
				{
					device.RenderState.FillMode=FillMode.WireFrame;
					device.SetTexture(0,null);
					device.Material=kk;
					spawnsmesh[i].DrawSubset(0);
			
				}

				
				

				
		
				for (g=0;g<spawns[i].mode.LOD.Length;g++)
				{
				
					int rr;
					for (rr=0;rr<1;rr++)//bsp.spawns[i].LOD[g].Length;rr++)
					{
						//if (bsp.spawns[i].LODName2[g][rr]!=piecex.Text){if (rr!=0){continue;}}
						int numx;
						int num;
					
						//if (bsp.spawns[i].LODCount[g][rr]>lod.SelectedIndex)
						//{
						//	num=bsp.spawns[i].LOD[g][rr][lod.SelectedIndex];
						//	numx=lod.SelectedIndex;
					
						//}
						//else
						//{
						num=spawns[i].mode.LOD[g][rr][0];
						numx=0;
						//}
						int r;
						for (r=0;r<spawns[i].mode.InfoBlockCount[num];r++)
						{
							//if (textured.BackColor==Color.IndianRed)
							//{
							if (textured.Checked==true)
							{
								device.SetTexture(0,spawns[i].mode.shaders[spawns[i].mode.Texture[num][r]].t);
								string tempo=spawns[i].mode.shaders[spawns[i].mode.Texture[num][r]].stemname;
								if (tempo.IndexOf("alphatest")!=-1)
								{
									device.RenderState.AlphaTestEnable=true;
									device.RenderState.AlphaBlendEnable=false;
								}
								else if (tempo.IndexOf("alpha")!=-1)
								{
									device.RenderState.AlphaTestEnable=false;
									device.RenderState.AlphaBlendEnable=true;
								}
								else if (tempo.IndexOf("water")!=-1)
								{
									device.RenderState.AlphaTestEnable=false;
									device.RenderState.AlphaBlendEnable=true;
								}
								else 
								{
									device.RenderState.AlphaTestEnable=false;
									device.RenderState.AlphaBlendEnable=false;
								}
								//device.SetTexture(1,spawns[i].mode.shaders[spawns[i].mode.Texture[num][r]].t2);
							}
							device.Material=jjj;
							
							if (textured.Checked==false)
							{
								device.Material = ki;
								
							}

							device.RenderState.FillMode=FillMode.Solid;
							fuckmesh[i][g][rr][numx].DrawSubset(r);
					
							device.RenderState.AlphaTestEnable=false;
							device.RenderState.AlphaBlendEnable=false;
						}
					
					}


				}
			



			}

		



	










				device.EndScene();
				device.Present();
	
		}

		private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		


		private bool MeshPick( float x, float y,Mesh mesh,Matrix mat)
		{
			
			Vector3 s = Vector3.Unproject(new Vector3(x, y, 0), 
				device.Viewport,
				device.Transform.Projection,
				device.Transform.View,
				mat);

			Vector3 d = Vector3.Unproject(new Vector3(x, y, 1), 
				device.Viewport,
				device.Transform.Projection,
				device.Transform.View,
				mat); 

			Vector3 rPosition =s;
			Vector3 rDirection = Vector3.Normalize(d-s); 


			if (mesh.Intersect(rPosition, rDirection))
			{
				
				return true;
			}
			else
			{
				return false;
			}
		
			}

		private Vector3 Mark3DCursorPosition(float x, float y,Matrix m)
		{

		Vector3 tempV3=new Vector3();//=spawns.vec[selectedspawn];
          	tempV3.Project(device.Viewport, device.Transform.Projection,device.Transform.View, m);
         
			tempV3.X = x;
			tempV3.Y = y;
			tempV3.Unproject(device.Viewport, device.Transform.Projection,
				device.Transform.View, m);

			

		//	// We now have the vector representing coordinates of the mouse in 3d space
			return tempV3;

		}


		private void panel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button==System.Windows.Forms.MouseButtons.Left)
			{

			
				//MessageBox.Show("terst");
				for (int h=0;h<spawncount;h++)
				{
					if (spawns[h].tag==-1){continue;}
					for (int g=0;g<spawns[h].mode.LOD.Length;g++)
					{
				
						int rr;
						for (rr=0;rr<1;rr++)//bsp.spawns[i].LOD[g].Length;rr++)
						{
							if ( MeshPick(e.X, e.Y,fuckmesh[h][g][rr][0],spawnmatrix[h])==true)
							{
							
								selectedspawn=h;
								statusBar1.Panels[0].Text=meta.Names[spawns[h].tag]+" - "+spawns[h].type.ToString();
								return;
							}
						}
					}
					selectedspawn=-1;
		
				
					
				}
				
			}
			
			if (e.Button==System.Windows.Forms.MouseButtons.Right)
			{
				Point f=new Point(e.X,e.Y);
			popUpMenu.Show(this,f);
				dragFlag=true;
			}
		}

		private void panel_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{


			if (e.Button==System.Windows.Forms.MouseButtons.Middle)
			{
				
				
			
				//Quaternion w=GraphicsUtility.GetRotationFromCursor(this,0.9f);
				//w.W/=2;
				//Rotate.RotateQuaternion(w);
				//tempq=w;

					//tempV3.Unproject(device.Viewport, device.Transform.Projection,
						//device.Transform.View, device.Transform.World );

					//Rotate.Multiply(Matrix.RotationAxis(tempV3,0.5f));
				if (e.X<pt.X)
				{
					Rotate.Multiply(Matrix.RotationX(0.03f));
				}
				if (e.X>pt.X)
				{
					Rotate.Multiply(Matrix.RotationX(-0.03f));
				}
				if (e.Y<pt.Y)
				{
					Rotate.Multiply(Matrix.RotationY(0.03f));
				}
				if (e.Y>pt.Y)
				{
					Rotate.Multiply(Matrix.RotationY(-0.03f));
				}
			Rotate.Multiply(Matrix.RotationZ(e.Delta));
			  
				pt=new Point(e.X,e.Y);
			//Vector3 tempV3=new Vector3();
			//	tempV3.X = e.X;
			//	tempV3.Y = e.Y;
			//	tempV3.Z=e.Delta;
				//Matrix i=Matrix.RotationYawPitchRoll(tempV3.X/100,tempV3.Y/100,tempV3.Z/10000);



			}
			
			
		}

		private void panel_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button==System.Windows.Forms.MouseButtons.Right)
			{
		
				popUpMenu.SourceControl.Hide();
				dragFlag=false;
			}
		}

		private void savechanges_Click(object sender, System.EventArgs e)
		{
			FileStream FS=new FileStream(map.filepath,FileMode.Open);
			BinaryWriter BR=new BinaryWriter(FS);
			int x;
			for (x=0;x<spawncount;x++)
			{
				if (spawns[x].rotate==spawninfo.RotateType.RotateYawPitchRoll)
				{
					BR.BaseStream.Position=spawns[x].where;
					BR.Write(spawns[x].vec.X);
					BR.Write(spawns[x].vec.Y);
					BR.Write(spawns[x].vec.Z);
					BR.Write(spawns[x].yaw);
					BR.Write(spawns[x].pitch);
					BR.Write(spawns[x].roll);
				}
				else if (spawns[x].rotate==spawninfo.RotateType.RotateZ )
				{
					BR.BaseStream.Position=spawns[x].where;
					BR.Write(spawns[x].vec.X);
					BR.Write(spawns[x].vec.Y);
					BR.Write(spawns[x].vec.Z);
					BR.Write(spawns[x].yaw);
				}

			}

			
			BR.Close();
			FS.Close();
		}

		private void wireframe_Click(object sender, System.EventArgs e)
		{
			if (wireframe.Checked==true) {wireframe.Checked=false;}
			else{wireframe.Checked=true;}
		}











		private void textured_Click(object sender, System.EventArgs e)
		{
			if (textured.Checked==true) {textured.Checked=false;}
			else{textured.Checked=true;}
		}






	
		protected override void OnClosing(CancelEventArgs e)
		{
			// TODO:  Add BSPViewer.OnClosing implementation
			base.OnClosing (e);
			Dispose(true);
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{



			if (folderBrowserDialog1.ShowDialog()==DialogResult.Cancel) {return;}
			

			string pathname=meta.Names[bsp.tag[bsp.selected]];
			
			int where=pathname.LastIndexOf("\\");
			string temp=folderBrowserDialog1.SelectedPath;
			string objname=pathname.Substring(where+1,pathname.Length-where-1);
			if (where!=-1){temp=temp+"\\"+objname+".obj\\";}
			System.IO.Directory.CreateDirectory(temp);
			


			
			FileStream FSX=new FileStream(temp+objname+".info",FileMode.Create ,FileAccess.ReadWrite,FileShare.ReadWrite);
			StreamWriter SWX=new StreamWriter(FSX);
			SWX.WriteLine("#darkmatter;");

			

			string mtrllibname=temp+objname+".mtl";
			FSX=new FileStream(mtrllibname,FileMode.Create ,FileAccess.ReadWrite,FileShare.ReadWrite);
			SWX=new StreamWriter(FSX);
			SWX.WriteLine("#darkmatter;");

			string[] names=new string[1000];
			for (int x=0;x<bsp.shaders1.Length;x++)
			{
				string fa=meta.Names[bsp.shaders1[x].btag];
				string[] f=fa.Split('\\');
				if (Array.IndexOf(names,f[f.Length-1])!=-1){continue;}
				names[x]=f[f.Length-1];
				bsp.shaders1[x].b.Save(temp+names[x]+".jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
				SWX.WriteLine("");
				SWX.WriteLine("newmtl "+names[x]);
				SWX.WriteLine("Ka 0.200000 0.200000 0.200000");
				SWX.WriteLine("Kd 0.800000 0.800000 0.800000");
				SWX.WriteLine("Ks 0.000000 0.000000 0.000000");
				SWX.WriteLine("Ns 0.000000");
				SWX.WriteLine("map_Kd .\\"+names[x]+".jpg");
			}

			SWX.Close();
			FSX.Close();





			
			for (int x=0;x<bsp.Model1Count[bsp.selected];x++)
			{
						
						string filet=temp+objname+"."+"["+x.ToString()+"].obj";
						FileStream FS=new FileStream(filet,FileMode.Create ,FileAccess.ReadWrite,FileShare.ReadWrite);
						StreamWriter SW=new StreamWriter(FS);
						SW.WriteLine("# Blah blah blah blah blah blah DM");
						SW.WriteLine("# -----------------------------");
						SW.WriteLine("# "+objname+".obj");
						SW.WriteLine("");
						SW.WriteLine("mtllib "+objname+".mtl");
						SW.WriteLine("");
						
						for (int w=0;w<bsp.Model1RawVerticeCount[bsp.selected][x];w++)
						{
							SW.WriteLine("v "+bsp.X[bsp.selected][x][w]+ " " +bsp.Y[bsp.selected][x][w]+" " +bsp.Z[bsp.selected][x][w]);
						}
						for (int w=0;w<bsp.Model1RawVerticeCount[bsp.selected][x];w++)
						{
							SW.WriteLine("vt "+bsp.U[bsp.selected][x][w]+ " " +bsp.V[bsp.selected][x][w]);
						}
						//for (int w=0;w<mode.VerticeCount[num];w++)
						//{
						//	SW.WriteLine("vn "+mode.nX[num][w]+ " " +mode.nY[num][w]+" " +mode.nZ[num][w]);
						//}
					
						int facenum=0;
						for (int j=0;j<bsp.EndOfIndices1[x].Length;j++)
						{
							SW.WriteLine("");
							SW.WriteLine("g "+objname+"."+x.ToString()+"."+j.ToString());
							SW.WriteLine("usemtl "+names[bsp.Texture1[x][j]]);
							SW.WriteLine("s "+objname+"."+x.ToString()+"."+j.ToString());
							for (int w=bsp.StartOfIndices1[x][j];w<bsp.StartOfIndices1[x][j]+bsp.EndOfIndices1[x][j];w+=3)
							{
								int xtemp=bsp.Model1Indices[bsp.selected][x][w]+1;
								int ytemp=bsp.Model1Indices[bsp.selected][x][w+1]+1;
								int ztemp=bsp.Model1Indices[bsp.selected][x][w+2]+1;
								string tempshit="f "+xtemp.ToString() + "/"+ xtemp.ToString() + "/"+ xtemp.ToString() + " ";
								tempshit+=ytemp.ToString() + "/"+ ytemp.ToString() + "/"+ ytemp.ToString() + " ";
								tempshit+=ztemp.ToString() + "/"+ ztemp.ToString() + "/"+ ztemp.ToString() + " ";
								SW.WriteLine(tempshit);
							}



						}
						SW.Close();
						FS.Close();
						
				
			}

		}
	}
}
