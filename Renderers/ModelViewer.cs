
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
using sharedstuff.ImportStuff;
using System.IO;




//Define a custom vertex for our cuboids
public struct pieceinfo
{
	public int Piece,LOD;
}
public struct PositionNormalTexVertex
{
	public Vector3 Position;
	public Vector3 Normal;
	public int diffuse;
	public int specular;
	public  float Tu0, Tv0;
	public static readonly VertexFormats FVF = VertexFormats.Position | VertexFormats.Texture1|VertexFormats.Normal| VertexFormats.Diffuse | VertexFormats.Specular ;
}

namespace WindowsApplication2
{
	/// <summary>
	/// Summary description for ModelViewer.
	/// </summary>
	public class ModelViewer : System.Windows.Forms.Form
	{
		float xzoom=5;
		BitmData bitm;
		Device device = null; // Our rendering device
		ModelData mode;
		IndexBuffer ib;
		VertexBuffer  vb;
		Texture[] tex=null;
	Texture[] tex2=null;
Material jjj;
		Mesh[][][] poo;
			Mesh[][][] poo2;
MetaInfo meta;
		Form1 oldform;
		bool dragflag=false;
		Matrix Rotate=new Matrix();
		
		//PluginX plugin= new PluginX();
		//Define a FVF for our cuboids
		private Vector3 v3CurrMeshPos = new Vector3(); //hhmmm... so this is your current position..
		private bool dragFlag = false; // if we are ready to drag the mesh, raise this flag
		private Vector3 v3MouseStartPos; // the mouse position as we press down the mouse button
		private Vector3 v3MouseNewPos; // the new mouse position while dragging the mesh
		MapHeader map;
		
		
		
		//GraphicsUtility. arcBall=new gra gra . gra gra gra GraphicsArcBall(this);             // Mouse rotation utility
		Vector3 objectCenter;        // Center of bounding sphere of object
		float objectRadius = 0.0f;
		Vector3 ominbound ;
		Vector3 omaxbound ;
		Vector3 minbound ;
		Vector3 maxbound ;
		Vector3 v3Min;
		Vector3 v3Max;

		Bitmap[] m;
		
		private Texture customNormalMap = null;
		private Texture fileBasedNormalMap = null;
		private Vector3 lightVector;
	
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button export;
		private System.Windows.Forms.Button import;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox lod;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button wireframe;
		private System.Windows.Forms.Button textured;
		private System.Windows.Forms.ComboBox piecex;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		
		
		public ModelViewer()
		{
			
		//	arcBall = new GraphicsArcBall(panel1);
			//enumerationSettings.AppUsesDepthBuffer = true;
Rotate=Matrix.Identity;
		
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.export = new System.Windows.Forms.Button();
			this.import = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.lod = new System.Windows.Forms.ComboBox();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			this.wireframe = new System.Windows.Forms.Button();
			this.textured = new System.Windows.Forms.Button();
			this.piecex = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.SteelBlue;
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
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
			// label1
			// 
			this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label1.Location = new System.Drawing.Point(4, 480);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 24);
			this.label1.TabIndex = 3;
			this.label1.Text = "LOD:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lod
			// 
			this.lod.Location = new System.Drawing.Point(104, 480);
			this.lod.Name = "lod";
			this.lod.Size = new System.Drawing.Size(48, 21);
			this.lod.TabIndex = 4;
			// 
			// wireframe
			// 
			this.wireframe.BackColor = System.Drawing.Color.IndianRed;
			this.wireframe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.wireframe.Location = new System.Drawing.Point(160, 480);
			this.wireframe.Name = "wireframe";
			this.wireframe.Size = new System.Drawing.Size(24, 24);
			this.wireframe.TabIndex = 5;
			this.wireframe.Text = "W";
			this.wireframe.Click += new System.EventHandler(this.wireframe_Click);
			// 
			// textured
			// 
			this.textured.BackColor = System.Drawing.Color.IndianRed;
			this.textured.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.textured.Location = new System.Drawing.Point(188, 480);
			this.textured.Name = "textured";
			this.textured.Size = new System.Drawing.Size(24, 24);
			this.textured.TabIndex = 6;
			this.textured.Text = "T";
			this.textured.Click += new System.EventHandler(this.textured_Click);
			// 
			// piecex
			// 
			this.piecex.Location = new System.Drawing.Point(216, 484);
			this.piecex.Name = "piecex";
			this.piecex.Size = new System.Drawing.Size(84, 21);
			this.piecex.TabIndex = 7;
			// 
			// ModelViewer
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.SteelBlue;
			this.ClientSize = new System.Drawing.Size(500, 508);
			this.Controls.Add(this.piecex);
			this.Controls.Add(this.textured);
			this.Controls.Add(this.wireframe);
			this.Controls.Add(this.lod);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.import);
			this.Controls.Add(this.export);
			this.Controls.Add(this.panel1);
			this.Cursor = System.Windows.Forms.Cursors.SizeAll;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "ModelViewer";
			this.Text = "ModelViewer";
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnPrivateKeyDown);
			this.Load += new System.EventHandler(this.ModelViewer_Load);
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
			
			}
			else if (e.KeyCode == System.Windows.Forms.Keys.S)
			{
				xzoom+=1.1F;
			}
		}



		private void ModelViewer_Load(object sender, System.EventArgs e)
		{
		
		
			using (ModelViewer frm = this)
			{
				if (!frm.InitializeGraphics()) // Initialize Direct3D
				{
					MessageBox.Show("Could not initialize Direct3D.  This tutorial will exit.");
					return;
				}
				if (!frm.InitializeGraphics2()) // Initialize Direct3D
				{
					MessageBox.Show("you suck");
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
				
					//	MessageBox.Show("Error");
					//	;
					//	frm.Close();
					//	break;
					//}
				}

				//frm.Dispose(true);
			}
		}


		
		

		public bool InitializeGraphics()
		{
		
			
				// Now let's setup our D3D stuff
				PresentParameters presentParams = new PresentParameters();
				presentParams.Windowed=true;
				presentParams.SwapEffect = SwapEffect.Discard;
				presentParams.PresentationInterval = PresentInterval.Immediate;
				presentParams.EnableAutoDepthStencil = true; // Turn on a Depth stencil
				presentParams.AutoDepthStencilFormat = DepthFormat.D16; // And the stencil format
				presentParams.BackBufferWidth=this.Width;
				presentParams.BackBufferHeight=this.Height;
				presentParams.BackBufferFormat=Manager.Adapters[0].CurrentDisplayMode.Format;
				presentParams.BackBufferCount=1;
				
	

			int adapterOrdinal = Manager.Adapters.Default.Adapter;
			CreateFlags flags = CreateFlags.SoftwareVertexProcessing;
			// Check to see if we can use a pure hardware device
			Caps caps = Manager.GetDeviceCaps(adapterOrdinal, DeviceType.Hardware);
			// Do we support hardware vertex processing?
			if (caps.DeviceCaps.SupportsHardwareTransformAndLight)
				// Replace the software vertex processing
				flags = CreateFlags.HardwareVertexProcessing;
  
			// Do we support a pure device?
			if (caps.DeviceCaps.SupportsPureDevice)
				flags |= CreateFlags.PureDevice;
			// Create our device
			try
			{
				try
				{
					device = new Device(adapterOrdinal, DeviceType.Hardware, panel1, flags, presentParams);
				}
				catch
				{
					device = new Device(adapterOrdinal, DeviceType.Software, panel1, flags, presentParams);
				}
			}
			catch
			{
			}

		
		return true;
		}
		public bool InitializeGraphics2()
		{
			try
			{
				device.RenderState.Lighting= true;
			//	device.RenderState.ZBufferFunction=ZBufferFunction.
				device.RenderState.DitherEnable =true;
				
			//	device.RenderState.UseWBuffer=true;
				device.RenderState.ZBufferEnable = true; 
		//		device.RenderState.ZBufferWriteEnable = true; 

			
				device.SamplerState[0].MagFilter = TextureFilter.Linear;
				device.SamplerState[0].MinFilter = TextureFilter.Linear;
				//device.RenderState.StencilEnable =true;
				
			//	device.RenderState.FillMode = FillMode.WireFrame;
				device.RenderState.CullMode = Cull.Clockwise;
				//device.RenderState.VertexBlend=VertexBlend.Disable;
				//device.RenderState.UseWBuffer = true;

				
				float fAspect = device.PresentationParameters.BackBufferWidth / (float)device.PresentationParameters.BackBufferHeight;
				device.Transform.Projection = Matrix.PerspectiveFovRH( (float)Math.PI/4, fAspect, 0.1f,400.0f);
//device.RenderState.CullMode = Cull.CounterClockwise;

			
		
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

				lod.Items.Clear();
				int g;
				for (g=0;g<5;g++)
				{
					lod.Items.Add(g.ToString());
				}
				lod.SelectedIndex=0;
				//lod.SelectedIndexChanged+=new System.EventHandler(this.loadthemeshmofo);

				
				piecex.Items.Clear();
				for (g=0;g<mode.LOD.Length;g++)
				{
						
					for (int gg=1;gg<mode.LODName2[g].Length;gg++)
					{
						string nameof=mode.LODName2[g][gg];
						if (piecex.Items.IndexOf(nameof)==-1)
						{
							piecex.Items.Add(nameof);
						}
					}
				}

			ominbound = new Vector3(mode.MinX,mode.MinY,mode.MinZ);
			omaxbound =new Vector3(mode.MaxX,mode.MaxY,mode.MaxZ);
			minbound = new Vector3(mode.MinX,mode.MinY,mode.MinZ);
			maxbound =new Vector3(mode.MaxX,mode.MaxY,mode.MaxZ);



				this.Enabled=false;

				jjj=new Material();
				jjj.Ambient=Color.FromArgb(255,255,255,255);//c[0],c[1],c[2]);

				
			
		
				tex=new Texture[mode.shaders.Length];
				tex2=new Texture[mode.shaders.Length];
				m=new Bitmap[mode.shaders.Length];
				for (g=0;g<mode.shaders.Length;g++)
				{	
			
					try
					{
						
						tex[g]=new Texture(device,mode.shaders[g].b,Usage.Dynamic,Pool.Default);
						tex2[g]=new Texture(device,mode.shaders[g].b2,Usage.Dynamic,Pool.Default);
						//SurfaceDescription desc = texx.GetLevelDescription(0);
						//tex[g]= new Texture(device, desc.Width, desc.Height, texx.LevelCount, 0, Format.A8R8G8B8, Pool.Managed);
						//TextureLoader.ComputeNormalMap(tex[g], texx, 0, Channel., 1.0f);

					}
					catch
					{
					}
			
				}
		




				v3Min = new Vector3(mode.MinX, mode.MinY, mode.MinZ);
				v3Max = new Vector3(mode.MaxX, mode.MaxY, mode.MaxZ);

		
				device.RenderState.SourceBlend = Blend.SourceAlpha;//InvSourceAlpha; ; //set the source to be the source's alpha
				device.RenderState.DestinationBlend = Blend.InvSourceAlpha; ;//set the destination to be the inverse of the source's alpha
				//device.RenderState.AlphaTestEnable=true;
				//device.TextureState[0].ColorOperation = TextureOperation.SelectArg1;
				//device.TextureState[0].ColorArgument1 = TextureArgument.TextureColor;

	
				device.TextureState[0].TextureCoordinateIndex = 0;
				device.TextureState[0].ColorOperation = TextureOperation.SelectArg1;
				device.TextureState[0].ColorArgument1 = TextureArgument.TextureColor;
				device.TextureState[0].ColorArgument2 = TextureArgument.Current;
			//	device.TextureState[1].TextureCoordinateIndex = 1;
				//device.TextureState[1].ColorOperation = TextureOperation.BumpEnvironmentMap;//BumpEnvironmentMap;
				//device.TextureState[1].ColorArgument1 = TextureArgument.TextureColor;
				//device.TextureState[1].ColorArgument2 = TextureArgument.Current;

				//arcBall.SetWindow( device.PresentationParameters.BackBufferWidth, device.PresentationParameters.BackBufferHeight,0.85f );
				//arcBall.Radius =5;// 300;//objectRadius;
				//this.panel1.MouseDown+=new MouseEventHandler(panel_MouseDown);
				//this.panel1.MouseMove+=new MouseEventHandler(panel_MouseMove);
				//this.panel1.MouseUp+=new MouseEventHandler(panel_MouseUp );
				///this.panel1.MouseDown+=new MouseEventHandler(arcBall.OnContainerMouseDown);
				//this.panel1.MouseMove+=new MouseEventHandler(arcBall.OnContainerMouseMove);
				//this.panel1.MouseUp+=new MouseEventHandler(arcBall.OnContainerMouseUp );
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
		public void SetRaw(ref ModelData raw1,ref BitmData bd,ref MetaInfo mi,ref MapHeader mp,ref Form1 fuck)
		{
			meta=mi;
			mode=raw1;
			bitm=bd;
			map=mp;
			oldform=fuck;
		
		}

		public void SetModel(ref ModelData raw1)
		{
			
			mode=raw1;
			
		}
		public void Setoldform(ref Form1 fuck)
		{
			
			oldform=fuck;
			
		}

		public void loadmesh()
		{
			poo = new Mesh[mode.LOD.Length][][];
	
			int g;
			for (g=0;g<mode.LOD.Length;g++)
			{
				poo[g] = new Mesh[mode.LODName2[g].Length][];
				
				for (int gg=0;gg<mode.LODName2[g].Length;gg++)
				{
					poo[g][gg] = new Mesh[mode.LOD[g][gg].Length];

					for (int ggg=0;ggg<mode.LOD[g][gg].Length;ggg++)
					{
						
						
						int num=mode.LOD[g][gg][ggg];
					



						PositionNormalTexVertex[] verts=new PositionNormalTexVertex[mode.VerticeCount[num]];
						int xxx;
						for (xxx=0;xxx<mode.VerticeCount[num];xxx++)
						{
							float theta = (float)(2 * Math.PI * xxx) / mode.VerticeCount[num];
							verts[xxx].Position=new Vector3(mode.X[num][xxx], mode.Y[num][xxx], mode.Z[num][xxx]);
							//Vector3 v = new Vector3(1,1,1);
							//v.Normalize();
							//verts[xxx].Normal=new Vector3(v);
							//verts[xxx].diffuse = VectorToRgba(v, 1.0f);
							//verts[xxx].specular = 0x40400000;
							verts[xxx].Tu0 = mode.U[num][xxx];
							verts[xxx].Tv0 = mode.V[num][xxx];
						}


					
						//poo[g][gg][ggg]=MakeMesh(verts,verts.Length,mode.FixedIndices2[num],mode.FixedIndices2[num].Length);
						poo[g][gg][ggg]=MakeMesh(verts,verts.Length,mode.FixedIndices2[num],mode.FixedIndices2[num].Length);
				

						//int[] Adj=new int[poo[g][gg][ggg].NumberFaces*3];
						//poo[g][gg][ggg].GenerateAdjacency(0.0f,Adj);		
					//	poo[g][gg][ggg].ComputeNormals(Adj);

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
		this.Enabled=true;
		}

		public Mesh MakeMesh(PositionNormalTexVertex[] verts,int vertcount,short[] indices,int indicecount)
		{
			Mesh temp=new Mesh(indicecount/3,vertcount,MeshFlags.Dynamic ,PositionNormalTexVertex.FVF,device);	
			VertexBuffer vbx=temp.VertexBuffer;
			vbx.SetData(verts,0,LockFlags.None );
			vbx.Unlock();
		
			IndexBuffer ibx=temp.IndexBuffer;
			ibx.SetData(indices,0,LockFlags.None);
			return temp;
				
		}

		public void PassModel()
		{
			mode.mesh=poo;
		
			oldform.setmymodedata(ref mode);
		}
		public void FrameMove()
		{
			if (System.Windows.Forms.Form.ActiveForm == this)
			{
				System.Drawing.Point pt = this.PointToClient(System.Windows.Forms.Cursor.Position);

				lightVector.X = -(((2.0f * pt.X) / device.PresentationParameters.BackBufferWidth) - 1);
				lightVector.Y = -(((2.0f * pt.Y) / device.PresentationParameters.BackBufferHeight) - 1);
				lightVector.Z = 0.0f;

				if (lightVector.Length() > 1.0f)
					lightVector.Normalize();
				else
					lightVector.Z = (float)Math.Sqrt(1.0f - lightVector.X*lightVector.X
						- lightVector.Y*lightVector.Y);
			}


			// Setup world matrixv3CurrMeshPos
			Matrix matWorld = Matrix.Translation(v3CurrMeshPos);
			//matWorld.Multiply(arcBall.TranslationMatrix);
			//matWorld.Multiply(arcBall.RotationMatrix);
			//matWorld.Multiply(arcBall.TranslationMatrix);
			device.Transform.World = matWorld;

			// Set up view matrix
			Vector3 vFrom= new Vector3(0, 0 ,1);
			//vFrom.Add(matWorld);
			Vector3 vAt = new Vector3( 0, 0, 0 );
			Vector3 vUp = new Vector3( 0, 1, 0 );
			Matrix fuck=Matrix.LookAtRH( vFrom, vAt, vUp );
			
			
			device.Transform.View =fuck;


		}

		public void Render()
		{
			if (device == null) 
				return;
			if (lod.SelectedIndex==-1){return;}
			device.Clear(ClearFlags.Target|ClearFlags.ZBuffer , System.Drawing.Color.SteelBlue, 1.0f, 0);
			device.BeginScene();
			Material shit=new Material();
			shit.Ambient=Color.Black;

			
			//device.TextureState[0].ColorArgument1 = TextureArgument.TextureColor;
			//device.TextureState[0].ColorOperation = TextureOperation.AddSmooth;
			//device.TextureState[0].ColorArgument2 = TextureArgument.TextureColor;
			//device.TextureState[1].ColorArgument1 = TextureArgument.TextureColor;
			//device.TextureState[1].ColorOperation = TextureOperation.DotProduct3;
			//device.TextureState[1].ColorArgument2 = TextureArgument.Diffuse;

			int g;
			for (g=0;g<mode.LOD.Length;g++)
			{
				
				int rr;
				for (rr=0;rr<mode.LOD[g].Length;rr++)
				{
					if (mode.LODName2[g][rr]!=piecex.Text){if (rr!=0){continue;}}
					int numx;
					int num;
					
					if (mode.LODCount[g][rr]>lod.SelectedIndex)
					{
						num=mode.LOD[g][rr][lod.SelectedIndex];
						numx=lod.SelectedIndex;
					
					}
					else
					{
						num=mode.LOD[g][rr][2];
						numx=2;
					}
					int r;
					for (r=0;r<mode.InfoBlockCount[num];r++)
					{
						if (textured.BackColor==Color.IndianRed)
						{
							device.SetTexture(0,tex[mode.Texture[num][r]]);
							string tempo=mode.shaders[mode.Texture[num][r]].stemname;
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
						}
						else
						{
							device.SetTexture(0,null);
						}
						//device.SetTexture(1,tex2[mode.Texture[num][r]]);
							device.Material=jjj;
							device.RenderState.FillMode=FillMode.Solid;
							poo[g][rr][numx].DrawSubset(r);
					
						if (wireframe.BackColor==Color.IndianRed)
						{
							device.RenderState.FillMode=FillMode.WireFrame;
							device.Material=shit;
							poo[g][rr][numx].DrawSubset(r);
						}
					}
				}
			}

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

			int[] added=new int[100000];
			int addcount=0;
			for (int x=0;x<mode.LOD.Length;x++)
			{
				for (int y=0;y<mode.LODName2[x].Length;y++)
				{
					for (int z=0;z<mode.LODCount[x][y];z++)
					{
						int num=mode.LOD[x][y][z];
						added[addcount]=num;
						addcount++;
						string temps=mode.LODName[x]+"."+mode.LODName2[x][y];
						SWX.WriteLine(objname+"."+temps+"["+x.ToString()+"]["+y.ToString()+"]["+z.ToString()+"]");
					}
				}
			}
			SWX.Close();
			FSX.Close();

			string mtrllibname=temp+objname+".mtl";
			FSX=new FileStream(mtrllibname,FileMode.Create ,FileAccess.ReadWrite,FileShare.ReadWrite);
			SWX=new StreamWriter(FSX);
			SWX.WriteLine("#darkmatter;");

			string[] names=new string[1000];
			for (int x=0;x<mode.shaders.Length;x++)
			{
				string fa=meta.Names[mode.shaders[x].btag];
				string[] f=fa.Split('\\');
				names[x]=f[f.Length-1];
				mode.shaders[x].b.Save(temp+names[x]+".jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
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





			added=new int[100000];
			addcount=0;
			for (int x=0;x<mode.LOD.Length;x++)
			{
				for (int y=0;y<mode.LODName2[x].Length;y++)
				{	
					for (int z=0;z<mode.LODCount[x][y];z++)
					{
						int num=mode.LOD[x][y][z];
						if (Array.IndexOf(added,num)!=-1 && addcount!=0){addcount++;continue;}
						added[addcount]=num;
						addcount++;
						string temps=mode.LODName[x]+"."+mode.LODName2[x][y];
						string filet=temp+objname+"."+temps+"["+x.ToString()+"]["+y.ToString()+"]["+z.ToString()+"].obj";
						FileStream FS=new FileStream(filet,FileMode.Create ,FileAccess.ReadWrite,FileShare.ReadWrite);
						StreamWriter SW=new StreamWriter(FS);
						SW.WriteLine("# Blah blah blah blah blah blah DM");
						SW.WriteLine("# -----------------------------");
						SW.WriteLine("# "+objname+"."+temps+".obj");
						SW.WriteLine("");
						SW.WriteLine("mtllib "+objname+".mtl");
						SW.WriteLine("");
						
						for (int w=0;w<mode.VerticeCount[num];w++)
						{
							SW.WriteLine("v "+mode.X[num][w]+ " " +mode.Y[num][w]+" " +mode.Z[num][w]);
						}
						for (int w=0;w<mode.VerticeCount[num];w++)
						{
							SW.WriteLine("vt "+mode.U[num][w]+ " " +mode.V[num][w]);
						}
						//for (int w=0;w<mode.VerticeCount[num];w++)
						//{
						//	SW.WriteLine("vn "+mode.nX[num][w]+ " " +mode.nY[num][w]+" " +mode.nZ[num][w]);
						//}
					
						int facenum=0;
						for (int j=0;j<mode.InfoBlockCount[num];j++)
						{
							SW.WriteLine("");
							SW.WriteLine("g "+objname+"."+temps+"."+z.ToString()+"."+j.ToString());
							SW.WriteLine("usemtl "+names[mode.Texture[num][j]]);
							SW.WriteLine("s "+objname+"."+temps+"."+z.ToString()+"."+j.ToString());
							for (int w=0;w<mode.FixedIndices[num][j].Length;w+=3)
							{
								int xtemp=mode.FixedIndices[num][j][w]+1;
								int ytemp=mode.FixedIndices[num][j][w+1]+1;
								int ztemp=mode.FixedIndices[num][j][w+2]+1;
								string tempshit="f "+xtemp.ToString() + "/"+ xtemp.ToString() + "/"+ xtemp.ToString() + " ";
								tempshit+=ytemp.ToString() + "/"+ ytemp.ToString() + "/"+ ytemp.ToString() + " ";
								tempshit+=ztemp.ToString() + "/"+ ztemp.ToString() + "/"+ ztemp.ToString() + " ";
								SW.WriteLine(tempshit);
							}


							facenum+=mode.EndOfIndices[num][j];
						}
						SW.Close();
						FS.Close();
						
					}
				}
				
			}



		}

		private void import_Click(object sender, System.EventArgs e)
		{
			
			if (folderBrowserDialog1.ShowDialog()==DialogResult.Cancel) {return;}
			string temp=folderBrowserDialog1.SelectedPath;
			string[] split1=temp.Split('\\');
			string[] split2=split1[split1.Length-1].Split('.');
			string objname=split2[0];
			string imports=null;
			FileStream FS=new FileStream(temp+"\\"+objname+".info",FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
			StreamReader SR=new StreamReader(FS);
		
			SR.ReadLine();
			int importcount=0;
			int piececount=0;
			int currpeace=0;
			string[] filenames=new string[1000];
			pieceinfo[] pieces=new pieceinfo[1000];
			int[][] pieceloc=new int[1000][];
			do
			{
				imports=SR.ReadLine();
				if (imports==null){break;}
				filenames[importcount]=imports;
				string[] importsplit=imports.Split(new char[]{'\\','[',']'});
				pieces[importcount].Piece=Convert.ToInt32(importsplit[1]);
				pieces[importcount].LOD=Convert.ToInt32(importsplit[3]);
				if (pieces[importcount].Piece!=currpeace){piececount++;currpeace=piececount;}
				pieceloc[piececount]=new int[1000];
				importcount++;
			}
			while (imports!=null);

			Mesh[][] poot=new Mesh [mode.LOD.Length][];

		


			int[] added=new int[100000];
			int addcount=0;
	

			MemoryStream mem2=new MemoryStream(1000000);
			BinaryWriter BW2=new BinaryWriter(mem2);
			BW2.Write(meta.Meta.GetBuffer());
			float minx=100;
			float maxx=-100;
			float miny=100;
			float maxy=-100;
			float minz=100;
			float maxz=-100;
			float minu=100;
			float maxu=-100;
			float minv=100;
			float maxv=-100;

			for (int x=0;x<mode.LOD.Length;x++)
			{
				for (int y=0;y<mode.LODName2[x].Length;y++)
				{
				
					for (int z=0;z<mode.LODCount[x][y];z++)
					{
						int num=mode.LOD[x][y][z];
						if (Array.IndexOf(added,num)!=-1 && addcount!=0){addcount++;continue;}

						string tempxxx=temp+"\\"+filenames[addcount]+".obj";

						added[addcount]=num;
						///MessageBox.Show(tempxxx);
						addcount++;
					
						string now=null;
						Vector3[] tempvector=new Vector3[1000000];
						float[] tempu=new float[1000000];
						float[] tempv=new float[1000000];
						short[] tempi=new short[1000000];
						int vcount=0;
						int icount=0;
						int uvcount=0;
						FS=new FileStream(tempxxx,FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
						SR=new StreamReader(FS);
						do
						{
							now=SR.ReadLine();
					
							if (now==null){break;}
							string[] xsplit=now.Split(new char[]{' ',',','/'});
							if (xsplit[0]=="v")
							{
								float m=Convert.ToSingle(xsplit[1]);
								tempvector[vcount].X=m;
								tempvector[vcount].Y=Convert.ToSingle(xsplit[2]);
								tempvector[vcount].Z=Convert.ToSingle(xsplit[3]);
								if (tempvector[vcount].X<minx){minx=tempvector[vcount].X;}
								if (tempvector[vcount].X>maxx){maxx=tempvector[vcount].X;}
								if (tempvector[vcount].Y<miny){miny=tempvector[vcount].Y;}
								if (tempvector[vcount].Y>maxy){maxy=tempvector[vcount].Y;}
								if (tempvector[vcount].Z<minz){minz=tempvector[vcount].Z;}
								if (tempvector[vcount].Z>maxz){maxz=tempvector[vcount].Z;}
								vcount++;
									
							}
							if (xsplit[0]=="vt")
							{
								tempu[uvcount]=Convert.ToSingle(xsplit[1]);
								tempv[uvcount]=Convert.ToSingle(xsplit[2]);
								if (tempu[uvcount]<minu){minu=tempu[uvcount];}
								if (tempu[uvcount]>maxu){maxu=tempu[uvcount];}
								if (tempv[uvcount]<minv){minv=tempv[uvcount];}
								if (tempv[uvcount]>maxv){maxv=tempv[uvcount];}
								uvcount++;
							}
							if (xsplit[0]=="f")
							{
								int fucknut=1;
								do
								{
									if (xsplit[fucknut]!="") {break;} 
									else { fucknut++;}
								} while (xsplit[0]=="f");

								tempi[icount+0]=Convert.ToInt16(xsplit[fucknut]);
								tempi[icount+1]=Convert.ToInt16(xsplit[fucknut+3]);
								tempi[icount+2]=Convert.ToInt16(xsplit[fucknut+6]);
								tempi[icount+0]-=1;
								tempi[icount+1]-=1;
								tempi[icount+2]-=1;
								icount+=3;
							}
						}
						while (now!=null);
						SR.Close();
						FS.Close();

						PositionNormalTexVertex[] pos=new PositionNormalTexVertex[vcount];
						for (int m=0;m<vcount;m++)
						{
							pos[m].Position=tempvector[m];
							pos[m].Tu0=tempu[m];
							pos[m].Tv0=tempv[m];
						}

					
						short[] poop=new short[icount];
						Array.Copy(tempi,0,poop,0,icount);
						
						///make a mesh
						Mesh tempxx=new Mesh(icount/3,vcount,MeshFlags.Dynamic,PositionNormalTexVertex.FVF,device);	
						vb=tempxx.VertexBuffer;
						vb.SetData(pos,0,LockFlags.None );
						vb.Unlock();
						ib=tempxx.IndexBuffer;
						ib.SetData(poop,0,LockFlags.None);


						///optimize mesh
						int[] adj=new int[tempxx.NumberFaces*3];
						tempxx.GenerateAdjacency(0.0f,adj);
						int[] test;
						int[] test2;
						GraphicsStream oi;
						Mesh oid= tempxx.Optimize(MeshFlags.OptimizeAttrSort, adj,out test,out test2,out oi);
						vb=oid.VertexBuffer;
						
					
	
						ib=oid.IndexBuffer;

			
							poo[x][y][z].Dispose();
							poo[x][y][z]=oid;
			

					}
				}  
			}	
			added=new int[100000];
			addcount=0;
			
					
				for (int x=0;x<mode.LOD.Length;x++)
				{
					for (int y=0;y<mode.LODName2[x].Length;y++)
					{
				
						for (int z=0;z<mode.LODCount[x][y];z++)
						{
							int num=mode.LOD[x][y][z];
							if (Array.IndexOf(added,num)!=-1 && addcount!=0){addcount++;continue;}

							added[addcount]=num;

							addcount++;
					
						ib=poo[x][y][z].IndexBuffer;
						vb=poo[x][y][z].VertexBuffer;
						string path=map.filepath.Substring(0,map.filepath.LastIndexOf("\\"));
						if (mode.ExternalMap[x]==0) {path=map.filepath;}
						if (mode.ExternalMap[x]==1) {path=path+"\\"+"mainmenu.map";}
						if (mode.ExternalMap[x]==2) {path=path+"\\"+"shared.map";}
						if (mode.ExternalMap[x]==3) {path=path+"\\"+"single_player_shared.map";}
//						FileStream FSX=new FileStream(path,FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
						MemoryStream mem=new MemoryStream(1000000);
						BinaryWriter BW=new BinaryWriter(mem);
					
						
						char [] crsr=new char[4]{'c','r','s','r'};
						char [] fklb=new char[4]{'f','k','l','b'};
						BW.BaseStream.Seek(0,SeekOrigin.Begin);
						BW.Write(mode.HeaderChunkData);
						int loc=0;//mode.HeaderChunkData.Length;
			
						unsafe
						{
							int k;
							for (int v=0;v<mode.IndiceChunkNumber[num];v++)
							{
								BW.BaseStream.Seek(mode.StartOfShit[num]+loc,SeekOrigin.Begin);
								//MessageBox.Show("test");
								BW.Write(crsr);
							
								BW.Write(mode.RawChunkData[num][v]);
								mode.RawChunkOffset[num][v]=loc+4;
								loc+=mode.RawChunkData[num][v].Length+4;
							}
						
												
							BW.BaseStream.Seek(mode.StartOfShit[num]+loc,SeekOrigin.Begin);
							BW.Write(crsr);
							int oicount=0;
							ib=Mesh.ConvertMeshSubsetToSingleStrip(poo[x][y][z],0,MeshFlags.OptimizeStripeReorder|MeshFlags.IbManaged,ref oicount);
							GraphicsStream xxxx=ib.Lock(0,0,LockFlags.None);
							short* ind=(short*)xxxx.InternalData.ToPointer();
							BW.BaseStream.Seek(mode.StartOfShit[num]+loc+4,SeekOrigin.Begin);
							short numind=(short)oicount;//mode.IndiceCount[num];//(oid.NumberVertices*3);
						
												
							for (k=0;k<numind;k++)
							{
								BW.Write(ind[k]);
							}
							BW.BaseStream.Seek(40,SeekOrigin.Begin);
							BW.Write(numind);
							mode.RawChunkTotalSize[num][mode.IndiceChunkNumber[num]]=(numind*2);
							mode.RawChunkOffset[num][mode.IndiceChunkNumber[num]]=loc+4;
							loc+=(numind*2)+4;


							BW.BaseStream.Seek(mode.StartOfShit[num]+loc,SeekOrigin.Begin);
							BW.Write(crsr);
							BW.Write(mode.RawChunkData[num][mode.IndiceChunkNumber[num]+1]);
							mode.RawChunkOffset[num][mode.IndiceChunkNumber[num]+1]=loc+4;
							loc+=mode.RawChunkData[num][mode.IndiceChunkNumber[num]+1].Length+4;


							BW.BaseStream.Seek(mode.StartOfShit[num]+loc,SeekOrigin.Begin);
							BW.Write(crsr);
							int vertchunksize=mode.RawChunkTotalSize[num][mode.IndiceChunkNumber[num]+2]/mode.VerticeCount[num];
							xxxx=vb.Lock(0,0,LockFlags.None);
							PositionNormalTexVertex* verts2=(PositionNormalTexVertex*) xxxx.InternalData.ToPointer();
				
							//Vector3 minvec=new Vector3();
							//Vector3 maxvec=new Vector3();
							//Geometry.ComputeBoundingBox(xxxx,tempxx.NumberVertices,PositionNormalTexVertex.FVF,out minvec,out maxvec);
							short numverts=(short)poo[x][y][z].NumberVertices;
					
							mode.RawChunkTotalSize[num][mode.IndiceChunkNumber[num]+2]=(vertchunksize*numverts);
							mode.RawChunkOffset[num][mode.IndiceChunkNumber[num]+2]=loc+4;
					
							for (k=0;k<numverts;k++)
							{
								short tx=(short)CompressVertice(verts2[k].Position.X,minx,maxx);
								short ty=(short)CompressVertice(verts2[k].Position.Y,miny,maxy);
								short tz=(short)CompressVertice(verts2[k].Position.Z,minz,maxz);
								BW.BaseStream.Seek(mode.StartOfShit[num]+loc+4+(k*vertchunksize),SeekOrigin.Begin);
								BW.Write(tx);
								BW.Write(ty);
								BW.Write(tz);
							}
							loc+=(vertchunksize*numverts)+4;

							mode.RawChunkTotalSize[num][mode.IndiceChunkNumber[num]+3]=(4*numverts);
							mode.RawChunkOffset[num][mode.IndiceChunkNumber[num]+3]=loc+4;
							
						
					
							for (k=0;k<numverts;k++)
							{
								short tu=(short)CompressVertice(verts2[k].Tu0,minu,maxu);
								short tv=(short)CompressVertice(verts2[k].Tv0,minv,maxv);
								BW.BaseStream.Seek(mode.StartOfShit[num]+loc+4+(k*4),SeekOrigin.Begin);
								BW.Write(tu);
								BW.Write(tv);
							
							}
							loc+=(4*numverts)+4;

							vb.Unlock();
						
							



							for (int v=mode.IndiceChunkNumber[num]+4;v<mode.RawChunkCount[num];v++)
							{
								BW.BaseStream.Seek(mode.StartOfShit[num]+loc,SeekOrigin.Begin);
								BW.Write(crsr);
								BW.Write(mode.RawChunkData[num][v]);
		
								mode.RawChunkOffset[num][v]=loc+4;
							
								loc+=mode.RawChunkData[num][v].Length+4;
								
							}
							BW.Write(fklb);
							loc+=4;

							mode.RawSize[num]=loc+mode.StartOfShit[num];

							BW.BaseStream.Seek(4,SeekOrigin.Begin);
							BW.Write(mode.RawSize[num]);

							BW.BaseStream.Seek(8,SeekOrigin.Begin);
							int xxxxddd=1;
							BW.Write(xxxxddd);

							BW.BaseStream.Seek(mode.StartOfShit[num]+12,SeekOrigin.Begin);
							BW.Write(numind);
							mem.SetLength(loc+mode.StartOfShit[num]);
							byte[] ft=mem.ToArray();
							mode.RawData[num]=new MemoryStream(loc+mode.StartOfShit[num]);
							mode.RawData[num].Write(ft,0,loc+mode.StartOfShit[num]);
							//Array.Copy(ft,0,mode.RawData[num],0,loc+mode.StartOfShit[num]);
							//BW.Close();
								
							BW2.BaseStream.Seek(mode.startofrawinfometachunks+(num*92)+4,SeekOrigin.Begin);
							BW2.Write(numverts);

							BW2.BaseStream.Seek(mode.startofrawinfometachunks+(num*92)+60,SeekOrigin.Begin);
							BW2.Write(mode.RawSize[num]);
							
							int modecrap=loc-4;
							BW2.BaseStream.Seek(mode.startofrawinfometachunks+(num*92)+68,SeekOrigin.Begin);
							BW2.Write(modecrap);

							
							for (int v=0;v<mode.RawChunkCount[num];v++)
							{
								BW2.BaseStream.Seek(mode.RawChunkInfoLoc[num]+(v*16)+8,SeekOrigin.Begin);
								BW2.Write(mode.RawChunkTotalSize[num][v]);
								BW2.Write(mode.RawChunkOffset[num][v]);
							}
							
							
						}

					}
				}
			}
			BW2.BaseStream.Seek(132,SeekOrigin.Begin);
			BW2.Write(minx);
			BW2.Write(maxx);
			BW2.Write(miny);
			BW2.Write(maxy);
			BW2.Write(minz);
			BW2.Write(maxz);
			BW2.Write(minu);
			BW2.Write(maxu);
			BW2.Write(minv);
			BW2.Write(maxv);
			meta.Meta=mem2;
			oldform.setmymetadata(ref meta);
	
			oldform.setmymodedata(ref mode);
			
			oldform.savemeta(meta.SelectedMeta,true,"");
		
			return;
			
          }
		public float CompressVertice(float input, float min, float max)
		{
			float result = input-min;
			result=(result / (max - min));
			result =result*65535;
			result = result- 32768;
			return result;
		}
		public float DecompressVertice(float input, float min, float max)
		{
			float percent = (input + 32768)/65535;
			float result= (percent * (max - min)) + min;
			return result;
		}

		private void wireframe_Click(object sender, System.EventArgs e)
		{
			if (wireframe.BackColor==Color.IndianRed)
			{
				wireframe.BackColor=Color.SteelBlue;
			}
			else
			{
				wireframe.BackColor=Color.IndianRed;
			}
		}

		private void textured_Click(object sender, System.EventArgs e)
		{
			if (textured.BackColor==Color.IndianRed)
			{
				textured.BackColor=Color.SteelBlue;
			}
			else
			{
				textured.BackColor=Color.IndianRed;
			}
		}



		private bool MeshPick(Mesh mesh, float x, float y)
		{
			// This is the famous pick routine...
			// Thanks to MDX for making this routine so much easier than before...
               



















			Vector3 v3Near = new Vector3(x, y, 0);
			Vector3 v3Far = new Vector3(x, y, 1);
               
			IntersectInformation closestHit=new IntersectInformation();

			v3Near.Unproject(device.Viewport, device.Transform.Projection,
				device.Transform.View, device.Transform.World);
			v3Far.Unproject(device.Viewport, device.Transform.Projection,
				device.Transform.View, device.Transform.World);
			v3Far.Subtract(v3Near);

		
               
			if (Geometry.BoxBoundProbe(v3Min,v3Max,v3Near,v3Far))
			{
			
				return true;
			}
			else
			{
				return false;
			}
          
		}



		private Vector3 Mark3DCursorPosition(float x, float y)
		{
			// Store the current mesh position in 3d space since we dont want to directly manipulate
			// the current mesh position
			Vector3 tempV3 = v3CurrMeshPos;
               
			// Project the current mesh position from 3d space to screen space
			// I use this to retrieve the z coordinate (maybe there is a better way :) than this)
			tempV3.Project(device.Viewport, device.Transform.Projection,
				device.Transform.View, device.Transform.World);
               
			// Assign the mouse current x and y position in screen space to the projected vector
			// After assigning this values we now have a vector representing the current mouse
			// coordinates having the same z as the mesh position in screen space
			tempV3.X = x;
			tempV3.Y = y;

			// We are dealing with 3d space so unproject the resulting vector back to 3d space
			// ( I hope this make sense.. :)
			tempV3.Unproject(device.Viewport, device.Transform.Projection,
				device.Transform.View, device.Transform.World);
               
			// We now have the vector representing coordinates of the mouse in 3d space
			return tempV3;

		}


		private void panel_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{

			if (e.Button==System.Windows.Forms.MouseButtons.Left)
		{
			int g;
			for (g=0;g<mode.LOD.Length;g++)
			{
				
				int rr;
				for (rr=0;rr<mode.LOD[g].Length;rr++)
				{
					int rrr;
					for (rrr=0;rrr<mode.LOD[g][rr].Length;rrr++)
					{
						// Check if we have picked the mesh
						if (MeshPick(poo[g][rr][rrr], e.X, e.Y))
						{
							//MessageBox.Show("Test");
							// If yes, mark the cursor position and raise our drag flag to true;
							v3MouseStartPos = Mark3DCursorPosition(e.X, e.Y);
							dragFlag = true;
							return;
						}
						else
						{
							// else... we picked nothing
							dragFlag = false;
						}
					}
				}
			}
		}
			else if (e.Button==System.Windows.Forms.MouseButtons.Middle)
			{
				Matrix m=new Matrix();
				m.RotateY(0.1f);
			Rotate.Multiply(m);
			}
		}


		private void panel_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (dragFlag)
			{
				if (e.Button==System.Windows.Forms.MouseButtons.Left)
				{
					//	// Mark the new mouse position
					v3MouseNewPos = Mark3DCursorPosition(e.X, e.Y);
					//	// Compute for the offset between the mouse start position and mouse new position
					v3MouseNewPos.Subtract(v3MouseStartPos);
					//	// Move the mesh position by the resulting vector
					v3CurrMeshPos.Add(v3MouseNewPos);
					//	minbound=ominbound;
					//minbound.Subtract(v3MouseNewPos);
				}
			}
		}

		private void panel_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// Had enough...
			dragFlag = false;
		}


	}
}
