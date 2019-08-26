


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using sharedstuff;
using sharedstuff.RawData;
using sharedstuff.MetaStuff;
using sharedstuff.ImportStuff;
using WindowsControlLibrary1;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;











namespace WindowsApplication2
{
	
	///	<summary>
	///	Summary	description	for	Form1.
	///	</summary>
	public class Form1 : System.Windows.Forms.Form
	{
	
	/// <summary>
	/// 
	/// </summary>
	/// 
		pluginpanel plugit;
		SelectedMetaInformation metashitwindow;
		MapInfo mapstuff;
		metalist metatree;
		deplist deptree;
		spawninfo[] spawns;
		public int spawncount;
		public bspstuff	bsp=new	bspstuff();
		util ut=new	util();
		MetaInfo meta=new MetaInfo();
		MapHeader map=new MapHeader();
		StringsInfo	items=new StringsInfo();
		BitmViewer lll=new BitmViewer();
		Helpers functions=new Helpers();
	
		string[] recursivenamelist;
		int recursivecount;
		PluginX.PluginX	plug=new PluginX.PluginX();
		ModelViewer	killmatt;
		BSPViewer killmatt2;
		CollViewer killmatt3;
		FilesToImport importfiles=new FilesToImport();
		ImportReflexive	importrefle=new ImportReflexive();
		ImportStringsX importstring=new	ImportStringsX();
		ImportLoneID importlone=new	ImportLoneID();	

		Reflexive reflex=new Reflexive();
		StringsX strings=new StringsX();
		Dependency dep=new Dependency();
		LoneID lone=new	LoneID();


		BinaryReader BR;
		parsedstuff	parsed=new parsedstuff();
	
PluginX.Metas pmeta;
		PluginX.iteminfo pinfo;
		PluginX.MapInfo	pmap;
		int level=0;
		ModelData mode=new ModelData();
		BitmData bitm=new BitmData();
		JmadData jmad=new JmadData();
		DECRData decr=new DECRData();
		PRTMData prtm=new PRTMData();
		PhmoData phmo=new PhmoData();
		spasData spas=new spasData();
		CollData coll=new CollData();
		sndData snd=new sndData();
		private	System.Windows.Forms.MainMenu mainMenu1;
		private	System.Windows.Forms.MenuItem menuItem1;
		private	System.Windows.Forms.MenuItem loadnewmap;
		private	System.Windows.Forms.OpenFileDialog	openmap;
		private	System.Windows.Forms.SaveFileDialog	savemetadialog;
		private	System.Windows.Forms.MenuItem menuItem2;
		private	System.Windows.Forms.MenuItem signmap;
		private	System.Windows.Forms.FolderBrowserDialog folder;
		private	System.Windows.Forms.MenuItem menuItem3;
		private	System.Windows.Forms.OpenFileDialog	openmeta;
		private	System.Windows.Forms.MenuItem addtomap;
		private	System.Windows.Forms.MenuItem menuItem5;
		private	System.Windows.Forms.MenuItem menuItem6;
		private	System.Windows.Forms.MenuItem menuItem7;
		private	System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.ProgressBar progress;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.SaveFileDialog mapstructure;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		///	<summary>
		///	Required designer variable.
		///	</summary>
		private	System.ComponentModel.Container	components = null;


		

		public Form1()
			
		{
			//
			// Required	for	Windows	Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after	InitializeComponent	call
			//
		
		}

		///	<summary>
		///	Clean up any resources being used.
		///	</summary>
		protected override void	Dispose( bool disposing	)
		{
			if(	disposing )
			{
				if (components != null)	
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing	);
		}

		#region	Windows	Form Designer generated	code
		///	<summary>
		///	Required method	for	Designer support - do not modify
		///	the	contents of	this method	with the code editor.
		///	</summary>
		private	void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Form1));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.loadnewmap = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.signmap = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.addtomap = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.openmap = new System.Windows.Forms.OpenFileDialog();
			this.savemetadialog = new System.Windows.Forms.SaveFileDialog();
			this.folder = new System.Windows.Forms.FolderBrowserDialog();
			this.openmeta = new System.Windows.Forms.OpenFileDialog();
			this.progress = new System.Windows.Forms.ProgressBar();
			this.mapstructure = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem2,
																					  this.menuItem8,
																					  this.menuItem9});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.loadnewmap});
			this.menuItem1.Text = "File";
			// 
			// loadnewmap
			// 
			this.loadnewmap.Index = 0;
			this.loadnewmap.Text = "Open Map";
			this.loadnewmap.Click += new System.EventHandler(this.loadnewmap_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.signmap,
																					  this.menuItem6,
																					  this.menuItem3,
																					  this.addtomap,
																					  this.menuItem7,
																					  this.menuItem5,
																					  this.menuItem4});
			this.menuItem2.Text = "Tools";
			// 
			// signmap
			// 
			this.signmap.Index = 0;
			this.signmap.Text = "Sign";
			this.signmap.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 1;
			this.menuItem6.Text = "-";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "Recursive Extract";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click_1);
			// 
			// addtomap
			// 
			this.addtomap.Index = 3;
			this.addtomap.Text = "Add To Map";
			this.addtomap.Click += new System.EventHandler(this.addtomap_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 4;
			this.menuItem7.Text = "-";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 5;
			this.menuItem5.Text = "Utilites";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 6;
			this.menuItem4.Text = "Map Structure";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click_1);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 2;
			this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem10,
																					  this.menuItem11,
																					  this.menuItem12,
																					  this.menuItem13});
			this.menuItem8.Text = "Windows";
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 0;
			this.menuItem10.Text = "Map Info";
			this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click_1);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 1;
			this.menuItem11.Text = "Meta";
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 2;
			this.menuItem12.Text = "Meta Tree";
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 3;
			this.menuItem13.Text = "Reference Editor";
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 3;
			this.menuItem9.Text = "About";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// openmap
			// 
			this.openmap.Filter = "Map File|*.map|All Files|*.*";
			// 
			// savemetadialog
			// 
			this.savemetadialog.Filter = "Meta Data|*.meta|All Files|*.*";
			// 
			// openmeta
			// 
			this.openmeta.Filter = "Meta Data|*.meta|All Files|*.*";
			// 
			// progress
			// 
			this.progress.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.progress.Location = new System.Drawing.Point(0, 557);
			this.progress.Name = "progress";
			this.progress.Size = new System.Drawing.Size(848, 12);
			this.progress.TabIndex = 11;
			// 
			// mapstructure
			// 
			this.mapstructure.Filter = "Text File *.txt|*.txt";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Gray;
			this.ClientSize = new System.Drawing.Size(848, 569);
			this.Controls.Add(this.progress);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "dark matter";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		///	<summary>
		///	The	main entry point for the application.
		///	</summary>
		[STAThread]
		static void	Main() 
		{
			
		
			Application.Run(new	Form1());
		}

		private	void Form1_Load(object sender, System.EventArgs	e)
		{
		
		meta.SelectedMeta=-1;
	
		



		}
		public void	setupmodelviewer()
		{
		
			Form1 j=this;
			//	killmatt.SetOldForm(ref	j);
			//killmatt.SetRaw(ref mode);
		}





		private void scanthis(int x)
		{
			
			if (x==-1){return;}
			meta.Meta=new MemoryStream(meta.Size[x]);
			FileStream FS=new FileStream(map.filepath,FileMode.Open);
			BinaryReader BR=new BinaryReader(FS);
			BR.BaseStream.Position=meta.Offset[x];
			meta.Meta.Write(BR.ReadBytes(meta.Size[x]),0,meta.Size[x]);
			BR.Close();
			FS.Close();

			int bsptag=-1;
			if (meta.TagType[x]=="sbsp") {bsptag=Array.IndexOf(bsp.tag,x);}
			scan(meta.Meta,meta.Offset[x],meta.Size[x],-1,false,false,bsptag,true,false);
			if (meta.TagType[x]=="stem" |meta.TagType[x]=="spas") { scan(meta.Meta,meta.Offset[x],meta.Size[x],-1,true,false,-1,false,false);}
		}


		public void plugingo()
		{
			if (meta.SelectedMeta==-1){return;}
			initializeplugin();
			map.pluginitialized=true;
//			plug=WindowsControlLibrary1.PluginX.PluginX();
			plug.clearplugin();
						
			pmap.SelectedTag=meta.SelectedMeta;
			plug.setdata(ref pmeta,ref pinfo,ref pmap);
			string pluginpath =	Application.StartupPath	+ "\\plugins\\"	+ meta.TagType[meta.SelectedMeta] +	".txt";
			TabControl ne=plugit.tabControl1;
			plug.Plugin(map.filepath,pluginpath,ref ne);
							
		}

		public	void treeView1_AfterSelect()
		{
			meta.scanned=false;
			string NodeText=metatree.treeView1.SelectedNode.Text;
			int	iscontained=metashitwindow.tagTypesControl.FindString(NodeText);
			if (iscontained	== -1)
			{
				string TempTagType=metatree.treeView1.SelectedNode.Parent.Text;
				int	x;
				for	(x=0;x<map.metaCount;x++)
				{
					if (meta.Names[x]==NodeText	& meta.TagType[x]==TempTagType)
					{
						metatree.treeView1.Enabled=false;
						meta.SelectedMeta=x;
						if (meta.TagType[x]=="sbsp"){bsp.selected=Array.IndexOf(bsp.tag,x);}

						metashitwindow.offsetControl.Text=meta.Offset[x].ToString("X");
						metashitwindow.sizeControl.Text=meta.Size[x].ToString();
						metashitwindow.identControl.Text=meta.Ident[x].ToString("X");
						metashitwindow.tagTypesControl.SelectedIndex=metashitwindow.tagTypesControl.FindString(TempTagType);
						meta.scanned=false;

						if (plugit.Visible==true)
						{
						
							plugingo();

						}
					
						if (metashitwindow.scanmeta.BackColor==Color.CornflowerBlue)
						{
							scanthis(x);
						}
							
		
				

						map.selectedtype=meta.TagType[meta.SelectedMeta];

						scanraw(x);
						show(true,x);

						//rawdataview();
						metatree.treeView1.Enabled=true;
						metatree.treeView1.Focus();
						break;
					}
				}
			}
		}

		public void	setmybitmapdata(ref	BitmData oi)
		{
			bitm=oi;
		}

		public void	setmybspmodedata()
		{
			killmatt2.SetMode(ref mode);
		}
	
		public void	setmymetadata(ref MetaInfo oi)
		{
			meta=oi;
		}
		public void	setmymodedata(ref ModelData	oi)
		{
			mode= oi;
		}

		private	void loadnewmap_Click(object sender, System.EventArgs e)
		{
			if (openmap.ShowDialog() ==	DialogResult.Cancel) {return;}
			map.filepath=openmap.FileName;
			loadmap();
		}
		private	void loadmap()
		{
		
			FileStream FS=new FileStream(openmap.FileName,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
			BR=new BinaryReader(FS);
			map.pluginitialized=false;
			BR.BaseStream.Seek(8,SeekOrigin.Begin);
			map.filesize=BR.ReadInt32();

			BR.BaseStream.Seek(16,SeekOrigin.Begin);
			map.indexOffset=BR.ReadInt32();
			map.metaStart=BR.ReadInt32();
			map.metaSize=BR.ReadInt32();
			map.combinedSize=BR.ReadInt32();

			BR.BaseStream.Seek(344,SeekOrigin.Begin);
			map.offsetToStrangeFileStrings=BR.ReadInt32();
			
			BR.BaseStream.Seek(352,SeekOrigin.Begin);
			map.srNames	= BR.ReadInt32();
			map.scriptReferenceCount = BR.ReadInt32();
			map.sizeOfScriptReference =	BR.ReadInt32();
			map.offsetToScriptReferenceIndex = BR.ReadInt32();
			map.offsetToScriptReferenceStrings = BR.ReadInt32();



			BR.BaseStream.Seek(408,	SeekOrigin.Begin);
			map.mapName	= new string(BR.ReadChars(36));
			this.Text =	"dark matter - " + map.mapName;
			BR.BaseStream.Seek(444,	SeekOrigin.Begin);
			map.scenarioPath = new string(BR.ReadChars(64));
			map.externalMap	= 0;
			if (map.scenarioPath.IndexOf("scenarios\\ui\\mainmenu\\mainmenu")!=-1) {map.externalMap=1;}
			if (map.scenarioPath.IndexOf("scenarios\\shared\\shared")!=-1) {map.externalMap=2;}
			if (map.scenarioPath.IndexOf("scenarios\\shared\\single_player_shared")!=-1) {map.externalMap=3;}
			if (map.externalMap	!= 0) {	this.Text += " - External Map";}
			BR.BaseStream.Seek(704,SeekOrigin.Begin);
			map.fileCount  = BR.ReadInt32();
			map.fileTableOffset	 = BR.ReadInt32();
			map.fileTableSize  = BR.ReadInt32();
			map.filesIndex	= BR.ReadInt32();
			map.signature  = BR.ReadInt32();
		
			BR.BaseStream.Seek(map.indexOffset,	SeekOrigin.Begin);
			map.primaryMagic = BR.ReadInt32() -	(map.indexOffset + 32);
			
			map.tagTypeCount=BR.ReadInt32();
			map.tagsOffset = BR.ReadInt32()	- map.primaryMagic;

			BR.BaseStream.Seek(map.indexOffset + 24, SeekOrigin.Begin);
			map.metaCount =	BR.ReadInt32();	
			BR.BaseStream.Seek(map.tagsOffset +	8, SeekOrigin.Begin);
			map.secondaryMagic = BR.ReadInt32()	- (map.indexOffset + map.metaStart);
			
			
			deptree=new deplist();
			deptree.MdiParent=this;
			

			deptree.sr.Items.Clear();
			
			int	x;
			items.Names=new	string[100000];
			items.NameOffset=new int[100000];
			items.LengthOfName=new int[100000];
			BR.BaseStream.Seek(map.offsetToScriptReferenceIndex,SeekOrigin.Begin);
			for	(x=0;x<map.scriptReferenceCount;x++)
			{
				items.NameOffset[x]=BR.ReadInt32();
			}
			for	(x=0;x<map.scriptReferenceCount;x++)
			{
				int	len=0;
				if (x != map.scriptReferenceCount-1)
				{
					len=items.NameOffset[x+1]-items.NameOffset[x];
				}
				else 
				{ 
					len=map.sizeOfScriptReference -	items.NameOffset[x];
				}
				BR.BaseStream.Seek(map.offsetToScriptReferenceStrings+items.NameOffset[x],SeekOrigin.Begin);
				items.Names[x]=new string(BR.ReadChars(len-1));
				items.LengthOfName[x]=len-1;
				deptree.sr.Items.Add(items.Names[x]);
			}



			/////dim some fucking variables	for	the	meta
		
			meta.TagType=new string[100000];
			meta.Names=new string[100000];
			meta.LengthOfName=new int[100000];
			meta.Offset=new	int[100000];
			meta.Size=new int[100000];
			meta.Ident=new int[100000];


			///	Reads In Lengths Of	Meta Names
			map.fileNameOffset=new int[map.fileCount];
			BR.BaseStream.Seek(map.filesIndex,SeekOrigin.Begin);
			for	(x=0;x<map.fileCount;x++)
			{
				map.fileNameOffset[x]=BR.ReadInt32();
			}

			///	Reads in Meta Names
			for	(x=0;x<map.fileCount;x++)
			{
				int	len=0;
				if (x != map.fileCount-1)
				{
					len=map.fileNameOffset[x+1]-map.fileNameOffset[x];
				}
				else 
				{ 
					len=map.fileTableSize -	map.fileNameOffset[x];
				}
				BR.BaseStream.Seek(map.fileTableOffset + map.fileNameOffset[x],SeekOrigin.Begin);
				meta.LengthOfName[x]=len-1;
				meta.Names[x]=new string(BR.ReadChars(len-1));
			}




	




			
			phmo.endsin=new	char[map.metaCount];
			coll.endsin=new	char[map.metaCount];
			spas.endsin=new	char[map.metaCount];

			metashitwindow=new SelectedMetaInformation();
			metashitwindow.MdiParent=this;

			
			mapstuff=new MapInfo();
			mapstuff.MdiParent=this;
			
			metatree=new metalist();
			metatree.MdiParent=this;

			plugit=new pluginpanel();
			plugit.MdiParent=this;

			mapstuff.secondarymagiccontrol.Text = map.secondaryMagic.ToString("X");
			mapstuff.sig.Text=map.signature.ToString("X");
			mapstuff.primarymagiccontrol.Text=map.primaryMagic.ToString("X");
	

			///Loads Up	treeView1 with Meta	Names And Tag Types
			metatree.treeView1.Nodes.Clear();
			
			metashitwindow.tagTypesControl.Items.Clear();
			deptree.types.Items.Clear();
			BR.BaseStream.Seek(map.tagsOffset,SeekOrigin.Begin);
			int	tagtypecount=0;
			string[] temptagtype=new string[10000];
			map.highID=0;
			for	(x=0;x<map.metaCount;x++)
			{
				char[] tempchar=BR.ReadChars(4);
				Array.Reverse(tempchar);
				meta.TagType[x]=new	string(tempchar);
				meta.Ident[x]=BR.ReadInt32();
				
				if (meta.Ident[x]<map.lowID){map.lowID=meta.Ident[x];}
				if (meta.Ident[x]>map.highID){map.highID=meta.Ident[x];}
				meta.Offset[x]=BR.ReadInt32() -	map.secondaryMagic;
				meta.Size[x]=BR.ReadInt32();
				if (meta.Offset[x]<0){meta.Offset[x]=0;}
				if (Array.IndexOf(temptagtype,meta.TagType[x])==-1)
				{
					temptagtype[tagtypecount]=meta.TagType[x];
					tagtypecount++;
				}
			}

			map.lowID=meta.Ident[0];

			map.tagTypes=new string[tagtypecount];
			Array.Copy(	temptagtype,0,map.tagTypes ,0,tagtypecount);

			Array.Sort(map.tagTypes);
			metatree.treeView1.Sorted=false;
			for	(x=0;x<map.tagTypes.Length;x++)
			{

				metashitwindow.tagTypesControl.Items.Add(map.tagTypes[x]);
				deptree.types.Items.Add(map.tagTypes[x]);
				metatree.treeView1.Nodes.Add(map.tagTypes[x]);
			}
			
			for	(x=0;x<map.metaCount;x++)
			{

					int fart=Array.IndexOf(map.tagTypes,meta.TagType[x]);
					metatree.treeView1.Nodes[fart].Nodes.Add(meta.Names[x]);

			}
			metatree.treeView1.Sorted=true;
			mapstuff.Left=2;
			mapstuff.Top=2;
			mapstuff.Visible=true;

			metashitwindow.Left=2;
			metashitwindow.Top=mapstuff.Top+mapstuff.Height+2;
			metashitwindow.Show();
			
			metatree.Left=metashitwindow.Left+metashitwindow.Width+2;
			metatree.Top=2;
			metatree.Show();
			
			deptree.Top=2;
			deptree.Left=metatree.Left+metatree.Width+2;
			deptree.Show();
			





//ugh stuff


			BR.BaseStream.Seek(meta.Offset[map.metaCount-1] +	32, SeekOrigin.Begin);
			int tempcount =	BR.ReadInt32();
			int tempreflex = BR.ReadInt32()	- map.secondaryMagic-meta.Offset[map.metaCount-1];

			snd.totalcountofchunk4=tempcount;
			snd.locationofchunk4 =tempreflex;

			BR.BaseStream.Seek(meta.Offset[map.metaCount-1] +	40, SeekOrigin.Begin);
			tempcount =	BR.ReadInt32();
			tempreflex = BR.ReadInt32()	- map.secondaryMagic-meta.Offset[map.metaCount-1];

			snd.totalcountofchunk5=tempcount;
			snd.locationofchunk5 =tempreflex;
		


			BR.BaseStream.Seek(meta.Offset[map.metaCount-1] +	64, SeekOrigin.Begin);
			tempcount =	BR.ReadInt32();
			tempreflex = BR.ReadInt32()	- map.secondaryMagic-meta.Offset[map.metaCount-1];

			snd.totalcountofrawdatapointers=tempcount;
			snd.locationofrawdatapointers =tempreflex;











			//startofbspstuff
			BR.BaseStream.Seek(meta.Offset[3] +	528, SeekOrigin.Begin);
			tempcount =	BR.ReadInt32();
			tempreflex = BR.ReadInt32()	- map.secondaryMagic;
			bsp.Magic=new int[tempcount];
			bsp.Offset=new int[tempcount];
			bsp.offloc=new int[tempcount];
			bsp.Size=new int[tempcount];
			bsp.tag=new	int[tempcount];
			bsp.Model1Count=new	int[tempcount];
			bsp.Model1Loc=new int[tempcount][];
			bsp.Model1Map=new int[tempcount][];
			bsp.Model1Offset=new int[tempcount][];
			bsp.Model1Raw=new MemoryStream[tempcount][];
			bsp.Model1Size=new int[tempcount][];
			bsp.Model1WithoutHeaderSize=new	int[tempcount][];
			bsp.Model1HeaderSize=new int[tempcount][];
			bsp.Model1FaceCount=new	int[tempcount][];
			bsp.Model1RawChunkSize=new int[tempcount][][];
			bsp.Model1RawChunkCount=new	int[tempcount][][];
			bsp.Model1RawChunkSize=new int[tempcount][][];
			bsp.Model1RawChunkTotalSize=new	int[tempcount][][];
			bsp.Model1RawChunkOffset=new int[tempcount][][];
			bsp.Model1RawVerticeCount=new int[tempcount][];
			bsp.Model1RawIndiceCount=new int[tempcount][];
			bsp.Model1Indices=new short[tempcount][][];
			bsp.X=new float[tempcount][][];
			bsp.Y=new float[tempcount][][];	
			bsp.Z=new float[tempcount][][];	
			bsp.U=new float[tempcount][][];	
			bsp.V=new float[tempcount][][];	

			bsp.Model2Count=new	int[tempcount];
			bsp.Model2Loc=new int[tempcount][];
			bsp.Model2Map=new int[tempcount][];
			bsp.Model2Offset=new int[tempcount][];
			bsp.Model2Raw=new byte[tempcount][][];
			bsp.Model2Size=new int[tempcount][];
			bsp.Model3Count=new	int[tempcount];
			bsp.Model3Loc=new int[tempcount][];
			bsp.Model3Map=new int[tempcount][];
			bsp.Model3Offset=new int[tempcount][];
			bsp.Model3Raw=new byte[tempcount][][];
			bsp.Model3Size=new int[tempcount][];
			bsp.Model4Count=new	int[tempcount];
			bsp.Model4Loc=new int[tempcount][];
			bsp.Model4Map=new int[tempcount][];
			bsp.Model4Offset=new int[tempcount][];
			bsp.Model4Raw=new byte[tempcount][][];
			bsp.Model4Size=new int[tempcount][];

			
			for	(x=0;x<tempcount;x++)
			{
				BR.BaseStream.Seek(tempreflex +	(x * 68), SeekOrigin.Begin);
				bsp.offloc[x]=tempreflex + (x *	68);
				bsp.Offset[x] =	BR.ReadInt32();
				bsp.Size[x]	= BR.ReadInt32();
				bsp.Magic[x] = BR.ReadInt32() -	bsp.Offset[x];
				BR.BaseStream.Seek(tempreflex +	(x * 68) + 20, SeekOrigin.Begin);
				bsp.tag[x] = findbyid(BR.ReadInt32());
				meta.Offset[bsp.tag[x]]=bsp.Offset[x];
				meta.Size[bsp.tag[x]]=bsp.Size[x];
				
			}
			
			BR.Close();
			FS.Close();

			for	(x=0;x<tempcount;x++)
			{
				parsesbsp(x);
			}


		
		}
		public void	parsesbsp(int x)
		{
			FileStream FS=new FileStream(openmap.FileName,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
			BR=new BinaryReader(FS);
				
			// bsp model 1
			BR.BaseStream.Seek(bsp.Offset[x] + 172,	SeekOrigin.Begin);
			int	tempc =	BR.ReadInt32();
			int	tempr =	BR.ReadInt32() - bsp.Magic[x];
			
			bsp.Model1Count[x]=tempc;
			bsp.Model1Map[x]=new int[tempc];
			bsp.Model1Offset[x]=new	int[tempc];
			bsp.Model1Raw[x]=new MemoryStream[tempc];
			bsp.Model1Size[x]=new int[tempc];
			bsp.Model1Loc[x]=new int[tempc];
				
			bsp.Model1RawChunkOffset[x]=new	int[tempc][];
			bsp.Model1RawChunkSize[x]=new int[tempc][];
			bsp.Model1RawChunkCount[x]=new int[tempc][];
			bsp.Model1RawChunkTotalSize[x]=new int[tempc][];
			bsp.Model1WithoutHeaderSize[x]=new int[tempc];
			bsp.Model1HeaderSize[x]=new	int[tempc];
			bsp.Model1RawVerticeCount[x]=new int[tempc];
			bsp.Model1RawIndiceCount[x]=new	int[tempc];
			bsp.Model1Indices[x]=new short[tempc][];
			bsp.Model1FaceCount[x]=new int[tempc];
			bsp.X[x]=new float[tempc][];
			bsp.Y[x]=new float[tempc][];	
			bsp.Z[x]=new float[tempc][];	
			bsp.U[x]=new float[tempc][];	
			bsp.V[x]=new float[tempc][];	
			bsp.Model1TotalFaceCount=0;
			int	b;
			for	(b=0;b<tempc;b++)
			{

				BR.BaseStream.Seek(tempr + (b *	176), SeekOrigin.Begin);
				bsp.Model1RawVerticeCount[x][b]=BR.ReadUInt16();
				bsp.Model1FaceCount[x][b]=BR.ReadUInt16();
				bsp.Model1TotalFaceCount+=bsp.Model1FaceCount[x][b];
				BR.BaseStream.Seek(tempr + (b *	176) + 40, SeekOrigin.Begin);
				bsp.Model1Loc[x][b]=tempr +	(b * 176) +	40-bsp.Offset[x];
				bsp.Model1Offset[x][b] = BR.ReadInt32();
				functions.ParseRawPointer(ref bsp.Model1Offset[x][b],ref bsp.Model1Map[x][b]);
			
				bsp.Model1Size[x][b] = BR.ReadInt32();
				bsp.Model1HeaderSize[x][b] = BR.ReadInt32()+8;
				bsp.Model1WithoutHeaderSize[x][b] =	BR.ReadInt32();
				BR.BaseStream.Seek(tempr + (b *	176) + 56, SeekOrigin.Begin);
				int	tc=BR.ReadInt32();
				int	tr=BR.ReadInt32();

				tr-=bsp.Magic[x];

				bsp.Model1RawChunkOffset[x][b]=new int[tc];	
				bsp.Model1RawChunkCount[x][b]=new int[tc];
				bsp.Model1RawChunkSize[x][b]=new int[tc];
				bsp.Model1RawChunkTotalSize[x][b]=new int[tc];
				int	r;
				for	(r=0;r<tc;r++)
				{
					BR.BaseStream.Seek(tr +	(r * 16) + 6, SeekOrigin.Begin);

					bsp.Model1RawChunkSize[x][b][r]=BR.ReadUInt16();
					bsp.Model1RawChunkTotalSize[x][b][r]=BR.ReadInt32();;
					bsp.Model1RawChunkOffset[x][b][r]=BR.ReadInt32();
				}


				string path=openmap.FileName;
				int	where=path.LastIndexOf("\\");
				path=path.Substring(0,where);
				if (bsp.Model1Map[x][b]==0)	{path=openmap.FileName;}
				if (bsp.Model1Map[x][b]==1)	{path=path+"\\"+"mainmenu.map";}
				if (bsp.Model1Map[x][b]==2)	{path=path+"\\"+"shared.map";}
				if (bsp.Model1Map[x][b]==3)	{path=path+"\\"+"single_player_shared.map";}
				FileStream FSX=new FileStream(path,FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
				BinaryReader BRX=new BinaryReader(FSX);
				BRX.BaseStream.Seek(bsp.Model1Offset[x][b],SeekOrigin.Begin);
				bsp.Model1Raw[x][b]=new MemoryStream(bsp.Model1Size[x][b]);
				bsp.Model1Raw[x][b].Write(BRX.ReadBytes(bsp.Model1Size[x][b]),0,bsp.Model1Size[x][b]);
				BRX.Close();
				FSX.Close();


			}


			// bsp model 2
			BR.BaseStream.Seek(bsp.Offset[x] + 328,	SeekOrigin.Begin);
			tempc =	BR.ReadInt32();
			tempr =	BR.ReadInt32() - bsp.Magic[x];
			
			bsp.Model2Count[x]=tempc;
			bsp.Model2Map[x]=new int[tempc];
			bsp.Model2Offset[x]=new	int[tempc];
			bsp.Model2Raw[x]=new byte[tempc][];
			bsp.Model2Size[x]=new int[tempc];
			bsp.Model2Loc[x]=new int[tempc];

			for	(b=0;b<tempc;b++)
			{
				BR.BaseStream.Seek(tempr + (b *	200) + 40, SeekOrigin.Begin);
				bsp.Model2Loc[x][b]=tempr +	(b * 200) +	40-bsp.Offset[x];
				bsp.Model2Offset[x][b] = BR.ReadInt32();
				functions.ParseRawPointer(ref bsp.Model2Offset[x][b],ref bsp.Model2Map[x][b]);
				bsp.Model2Size[x][b] = BR.ReadInt32();

				string path=openmap.FileName;
				int	where=path.LastIndexOf("\\");
				path=path.Substring(0,where);
				if (bsp.Model2Map[x][b]==0)	{path=openmap.FileName;}
				if (bsp.Model2Map[x][b]==1)	{path=path+"\\"+"mainmenu.map";}
				if (bsp.Model2Map[x][b]==2)	{path=path+"\\"+"shared.map";}
				if (bsp.Model2Map[x][b]==3)	{path=path+"\\"+"single_player_shared.map";}
				FileStream FSX=new FileStream(path,FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
				BinaryReader BRX=new BinaryReader(FSX);
				BRX.BaseStream.Seek(bsp.Model2Offset[x][b],SeekOrigin.Begin);
				bsp.Model2Raw[x][b]=BRX.ReadBytes(bsp.Model2Size[x][b]);
				BRX.Close();
				FSX.Close();
			}

			// bsp model 3
			BR.BaseStream.Seek(bsp.Offset[x] + 580,	SeekOrigin.Begin);
			tempc =	BR.ReadInt32();
			tempr =	BR.ReadInt32() - bsp.Magic[x];
			BR.BaseStream.Seek(tempr + 16, SeekOrigin.Begin);
			tempc =	BR.ReadInt32();
			tempr =	BR.ReadInt32() - bsp.Magic[x];

			bsp.Model3Count[x]=tempc;
			bsp.Model3Map[x]=new int[tempc];
			bsp.Model3Offset[x]=new	int[tempc];
			bsp.Model3Raw[x]=new byte[tempc][];
			bsp.Model3Size[x]=new int[tempc];
			bsp.Model3Loc[x]=new int[tempc];

			for	(b=0;b<tempc;b++)
			{
				BR.BaseStream.Seek(tempr + (b *	44), SeekOrigin.Begin);
				bsp.Model3Loc[x][b]=tempr +	(b * 44)-bsp.Offset[x];
				bsp.Model3Offset[x][b] = BR.ReadInt32();
				functions.ParseRawPointer(ref bsp.Model3Offset[x][b],ref bsp.Model3Map[x][b]);
				bsp.Model3Size[x][b] = BR.ReadInt32();

				string path=openmap.FileName;
				int	where=path.LastIndexOf("\\");
				path=path.Substring(0,where);
				if (bsp.Model3Map[x][b]==0)	{path=openmap.FileName;}
				if (bsp.Model3Map[x][b]==1)	{path=path+"\\"+"mainmenu.map";}
				if (bsp.Model3Map[x][b]==2)	{path=path+"\\"+"shared.map";}
				if (bsp.Model3Map[x][b]==3)	{path=path+"\\"+"single_player_shared.map";}
				FileStream FSX=new FileStream(path,FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
				BinaryReader BRX=new BinaryReader(FSX);
				BRX.BaseStream.Seek(bsp.Model3Offset[x][b],SeekOrigin.Begin);
				bsp.Model3Raw[x][b]=BRX.ReadBytes(bsp.Model3Size[x][b]);
				BRX.Close();
				FSX.Close();
			}

			// bsp model 4
			BR.BaseStream.Seek(bsp.Offset[x] + 8, SeekOrigin.Begin);
			tempr =	BR.ReadInt32();	
			if (tempr != 0 ) 
			{
				tempr -= bsp.Magic[x];
				BR.BaseStream.Seek(tempr + 128,	SeekOrigin.Begin);
				tempc =	BR.ReadInt32();
				tempr =	BR.ReadInt32() - bsp.Magic[x];

				BR.BaseStream.Seek(tempr + 64, SeekOrigin.Begin);
				tempc =	BR.ReadInt32();
				tempr =	BR.ReadInt32() - bsp.Magic[x];
			} 
			else
			{
				tempc =	0;
			}
						
			bsp.Model4Count[x]=tempc;
			bsp.Model4Map[x]=new int[tempc];
			bsp.Model4Offset[x]=new	int[tempc];
			bsp.Model4Raw[x]=new byte[tempc][];
			bsp.Model4Size[x]=new int[tempc];
			bsp.Model4Loc[x]=new int[tempc];

			for	(b=0;b<tempc;b++)
			{
				BR.BaseStream.Seek(tempr + (b *	56)	+ 12, SeekOrigin.Begin);
				bsp.Model4Loc[x][b]=tempr +	(b * 56) + 12-bsp.Offset[x];
				bsp.Model4Offset[x][b] = BR.ReadInt32();
				functions.ParseRawPointer(ref bsp.Model4Offset[x][b],ref bsp.Model4Map[x][b]);
				bsp.Model4Size[x][b] = BR.ReadInt32();

				string path=openmap.FileName;
				int	where=path.LastIndexOf("\\");
				path=path.Substring(0,where);
				if (bsp.Model4Map[x][b]==0)	{path=openmap.FileName;}
				if (bsp.Model4Map[x][b]==1)	{path=path+"\\"+"mainmenu.map";}
				if (bsp.Model4Map[x][b]==2)	{path=path+"\\"+"shared.map";}
				if (bsp.Model4Map[x][b]==3)	{path=path+"\\"+"single_player_shared.map";}
				FileStream FSX=new FileStream(path,FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
				BinaryReader BRX=new BinaryReader(FSX);
				BRX.BaseStream.Seek(bsp.Model4Offset[x][b],SeekOrigin.Begin);
				bsp.Model4Raw[x][b]=BRX.ReadBytes(bsp.Model4Size[x][b]);
				BRX.Close();
				FSX.Close();
			}
			

			
			


		
		
			BR.Close();
			FS.Close();
		}

		public void	show(bool clear,int	tag)
		{
			if (tag==-1){return;}
			if (clear==true)
			{
				deptree.treeView2.Nodes[0].Nodes.Clear();
				deptree.treeView2.Nodes[1].Nodes.Clear();
				deptree.treeView2.Nodes[2].Nodes.Clear();
				deptree.treeView2.Nodes[3].Nodes.Clear();
				deptree.treeView2.Nodes[4].Nodes.Clear();
			}
			int	x;
			for	(x=0;x<dep.Count;x++)
			{
				if (dep.InTag[x]!=-1)
				{
					string tempstring="• Location: " + dep.Location[x].ToString() +	" • " +	meta.TagType[dep.InTag[x]] + " - " + meta.Names[dep.InTag[x]] +	" •";
					deptree.treeView2.Nodes[0].Nodes.Add(tempstring);
				}
				else
				{
					string tempstring="• Location: " + dep.Location[x].ToString() +	" • " +	dep.TagType[x]+" - "+ "Nulled Out •";
					deptree.treeView2.Nodes[0].Nodes.Add(tempstring);
				}
			}
			for	(x=0;x<lone.Count;x++)
			{
				string tempstring="• Location: " + lone.Location[x].ToString() + " • " + meta.TagType[lone.InTag[x]] + " - " + meta.Names[lone.InTag[x]] + " •";
				deptree.treeView2.Nodes[1].Nodes.Add(tempstring);
			}
			for	(x=0;x<reflex.Count;x++)
			{
				string tempstring;
				tempstring="• Location: " +	reflex.Location[x].ToString() +	" • Translation: " + reflex.Translation[x].ToString() +	" • Chunk Count: " + reflex.ChunkCount[x].ToString()+" • Points	To: "+meta.TagType[reflex.InTag[x]]+" - " +meta.Names[reflex.InTag[x]]+" •";
			
				deptree.treeView2.Nodes[2].Nodes.Add(tempstring);
			}
			for	(x=0;x<strings.Count;x++)
			{
				string tempstring="• Location: " + strings.Location[x].ToString() +	" • String: "+items.Names[strings.StringNum[x]]+" •"; 
				deptree.treeView2.Nodes[3].Nodes.Add(tempstring);
			}
			if (meta.TagType[tag]=="mode")
			{
				deptree.treeView2.Nodes[4].Nodes.Add("Model Raw Type 1:");
				for	(x=0;x<mode.RawCount;x++)
				{
					string tempstring="• Location: " + mode.LocationOfRawPointer[x].ToString() + " • Offset: "+mode.RawOffset[x].ToString("X")+" • External Map: "+mode.ExternalMap[x].ToString()+" •";
					deptree.treeView2.Nodes[4].Nodes[0].Nodes.Add(tempstring);
				}
				deptree.treeView2.Nodes[4].Nodes.Add("Model Raw Type 2:");
				for	(x=0;x<mode.RawCount2;x++)
				{
					string tempstring="• Location: " + mode.LocationOfRawPointer2[x].ToString() + " • Offset: "+mode.RawOffset2[x].ToString("X")+" • External Map: "+mode.ExternalMap2[x].ToString()+" •";
					deptree.treeView2.Nodes[4].Nodes[1].Nodes.Add(tempstring);
				}
			}
			if (meta.TagType[tag]=="jmad")
			{
				for	(x=0;x<jmad.RawCount;x++)
				{
					string tempstring="• Location: " + jmad.LocationOfRawPointer[x].ToString() + " • Offset: "+jmad.RawOffset[x].ToString("X")+" • External	Map: "+jmad.ExternalMap[x].ToString()+"	•";
					deptree.treeView2.Nodes[4].Nodes.Add(tempstring);
				}
			}
			if (meta.TagType[tag]=="snd!")
			{
				for	(x=0;x<snd.RawCount;x++)
				{
					string tempstring="• Location: " + snd.LocationOfRawPointer[x].ToString() + " • Offset: "+snd.RawOffset[x].ToString("X")+" • External	Map: "+snd.ExternalMap[x].ToString()+"	•";
					deptree.treeView2.Nodes[4].Nodes.Add(tempstring);
				}
			}
			if (meta.TagType[tag]=="bitm")
			{
				for	(x=0;x<bitm.RawCount;x++)
				{
					string tempstring="• Location: " + bitm.LocationOfRawPointer[x].ToString() + " • Offset: "+bitm.RawOffset[x].ToString("X")+" • External	Map: "+bitm.ExternalMap[x].ToString()+"	•";
					deptree.treeView2.Nodes[4].Nodes.Add(tempstring);
				}
			}
			if (meta.TagType[tag]=="PRTM")
			{
				string tempstring="• Location: " + prtm.LocationOfRawPointer.ToString()	+ "	• Offset: "+prtm.RawOffset.ToString("X")+" • External Map: "+prtm.ExternalMap.ToString()+" •";
				deptree.treeView2.Nodes[4].Nodes.Add(tempstring);
				
			}
			if (meta.TagType[tag]=="DECR")
			{
				string tempstring="• Location: " + decr.LocationOfRawPointer.ToString()	+ "	• Offset: "+decr.RawOffset.ToString("X")+" • External Map: "+decr.ExternalMap.ToString()+" •";
				deptree.treeView2.Nodes[4].Nodes.Add(tempstring);
				
			}
			if (meta.TagType[tag]=="sbsp")
			{
				deptree.treeView2.Nodes[4].Nodes.Add("BSP Model 1:");

				for (int r=0;r<bsp.Model1Count[bsp.selected];r++)
				{
					string tempstring="• Location: " + bsp.Model1Loc[bsp.selected][r].ToString() + "	• Offset: "+bsp.Model1Offset[bsp.selected][r].ToString("X")+" • External Map: "+bsp.Model1Map[bsp.selected][r].ToString()+" •";
					deptree.treeView2.Nodes[4].Nodes[0].Nodes.Add(tempstring);
				}


				deptree.treeView2.Nodes[4].Nodes.Add("BSP Model 2:");

				for (int r=0;r<bsp.Model2Count[bsp.selected];r++)
				{
					string tempstring="• Location: " + bsp.Model2Loc[bsp.selected][r].ToString() + "	• Offset: "+bsp.Model2Offset[bsp.selected][r].ToString("X")+" • External Map: "+bsp.Model2Map[bsp.selected][r].ToString()+" •";
					deptree.treeView2.Nodes[4].Nodes[1].Nodes.Add(tempstring);
				}

				deptree.treeView2.Nodes[4].Nodes.Add("BSP Model 3:");

				for (int r=0;r<bsp.Model3Count[bsp.selected];r++)
				{
					string tempstring="• Location: " + bsp.Model3Loc[bsp.selected][r].ToString() + "	• Offset: "+bsp.Model3Offset[bsp.selected][r].ToString("X")+" • External Map: "+bsp.Model3Map[bsp.selected][r].ToString()+" •";
					deptree.treeView2.Nodes[4].Nodes[2].Nodes.Add(tempstring);
				}

				deptree.treeView2.Nodes[4].Nodes.Add("BSP Model 4:");

				for (int r=0;r<bsp.Model4Count[bsp.selected];r++)
				{
					string tempstring="• Location: " + bsp.Model4Loc[bsp.selected][r].ToString() + "	• Offset: "+bsp.Model4Offset[bsp.selected][r].ToString("X")+" • External Map: "+bsp.Model4Map[bsp.selected][r].ToString()+" •";
					deptree.treeView2.Nodes[4].Nodes[3].Nodes.Add(tempstring);
				}
				
			}
		}

		public void	scan(Stream str,int offx, int	xsize,int tag,bool weirdoffset,bool	fast,int bspx,bool useprogress,bool fastdep)
		{
			int offset=0;
			if (weirdoffset==false)	
			{
				lone.Count=0;
				lone.InTag=new int[100000];
				lone.Location=new int[100000];
				lone.TagType=new string[100000];

				dep.Count=0;
				dep.InTag=new int[100000];
				dep.Location=new int[100000];
				dep.TagType=new	string[100000];

				reflex.Count=0;
				reflex.InTag=new int[100000];
				reflex.ChunkCount=new int[100000];
				reflex.Location=new	int[100000];
				reflex.Translation=new int[100000];
				strings.Count =0;
				strings.Location=new int[100000];
				strings.StringNum=new int[100000];
				
			}
			else
			{
				
				offset=2;
				
			}

			
			BinaryReader BR=new	BinaryReader(str);
						
		
			
		//MessageBox.Show("test");
	
			int	x;
			int	y=xsize/4;
			if (weirdoffset==true) {y--;};
			if (fast==false) 
			{
				BR.BaseStream.Seek(offset,SeekOrigin.Begin);
				for	(x=0;x<y;x++)
				{
					int	temp=BR.ReadUInt16();
					int	temp1=BR.ReadByte();
					int	temp2=BR.ReadByte();
					if (temp < map.scriptReferenceCount	&& temp>0)
					{
						if (temp2==items.LengthOfName[temp]&&temp1==0)
						{
							strings.Location[strings.Count]=x*4;
							if (weirdoffset==true) {strings.Location[strings.Count]+=2;};
							strings.StringNum[strings.Count]=temp;
							strings.Count++;
						}
					}
				}
			}

			int	xstart=map.indexOffset+map.metaStart;
			int	xend=map.filesize;
			if (bspx!=-1)
			{
				xstart=offx;
				xend=offx+xsize;
			}
			
			int prev=0;
			
			for	(x=0;x<y;x++)
			{
				if (useprogress==true)
				{
					float hk=((float)x/(float)y)*100;
					progress.Value=(int)hk;
				}
				Application.DoEvents();
				BR.BaseStream.Seek(offset+(x*4),SeekOrigin.Begin);
				int temp=BR.ReadInt32();
				int	temp2;
				if (bspx==-1)
				{
					temp2=temp-map.secondaryMagic;
				}
				else
				{
					temp2=temp-bsp.Magic[bspx];
				}
				
				if (temp2>xstart &&	temp2 <	xend)
				{
					int	seekhere=offset+((x-1)*4);
					BR.BaseStream.Seek(seekhere,SeekOrigin.Begin);
					reflex.ChunkCount[reflex.Count]	= BR.ReadUInt16();
					int	tempj=BR.ReadUInt16();
					BR.ReadInt32();
					
					if (tempj==0 &&	reflex.ChunkCount[reflex.Count]>0 && bspx==-1)
					{					
						reflex.InTag[reflex.Count]=findbyoffset(temp2);
						if (reflex.InTag[reflex.Count]==-1){continue;}
						if (tag!=-1) { reflex.InTag[reflex.Count]=tag;}
						reflex.Location[reflex.Count]=x*4-4;
						if (weirdoffset==true) {reflex.Location[reflex.Count]+=2;};
						reflex.Translation[reflex.Count]=temp2-meta.Offset[reflex.InTag[reflex.Count]];//+optionaloffset;;
						reflex.Count++;
					}
					else if	(bspx!=-1)
					{
						reflex.InTag[reflex.Count]=findbyoffset(temp2);
						if (tag!=-1) { reflex.InTag[reflex.Count]=tag;}
						reflex.Location[reflex.Count]=x*4-4;
						reflex.Translation[reflex.Count]=temp2-meta.Offset[reflex.InTag[reflex.Count]];
						
						reflex.Count++;
					}
				}
				else if	(fast==false)// && temp>=map.lowID&&temp<=map.highID)
				{
					
					int	temp3=findbyid(temp);
					
					if (temp3 != -1	| temp==-1)
					{
						string poop="moop";
						if (x!=0 && fastdep==false)
						{
							int	seekhere=offset+((x-1)*4);
							BR.BaseStream.Seek(seekhere,SeekOrigin.Begin);
							char[] ol=BR.ReadChars(4);
							Array.Reverse(ol);
							poop=new string(ol);
						}

						if (fastdep==false)
						{
							int	jjj=Array.IndexOf(meta.TagType,poop);
							if (jjj!=-1)
							{
								dep.InTag[dep.Count]=temp3;
								dep.Location[dep.Count]=x*4;
								if (weirdoffset==true) {dep.Location[dep.Count]+=2;};
								dep.TagType[dep.Count]=poop;
								dep.Count++;
							
								continue;
							}
						}
						
						if (temp!=-1)
						{
							lone.TagType[lone.Count]=meta.TagType[temp3];
							lone.InTag[lone.Count]=temp3;
							lone.Location[lone.Count]=x*4;
							if (weirdoffset==true) {lone.Location[lone.Count]+=2;};
							lone.Count++;
						}
						

					}
				
				}
				//prev=temp;
			}	

			meta.scanned=true;
		}

		public int findbyid(int	id)
		{
			int	result=Array.IndexOf(meta.Ident,id,0,map.metaCount);
			return result;
			
		}

		public bool	savemeta(int tag,bool trim,string path)
		{
		
			string pathname=meta.Names[tag];
			string [] Split	= pathname.Split(new Char [] {'\\'}); 
			if (trim==true)	
			{
				pathname=Split[Split.Length-1];
			}
			pathname=pathname+"["+ meta.TagType[tag] + "]";
			pathname=pathname.Replace("<","{");
			pathname=pathname.Replace(">","}");
			pathname=pathname+".meta";
			recursivenamelist[recursivecount]=pathname;
			recursivecount++;
			if (trim==true)
			{
				savemetadialog.FileName=pathname;
				if (savemetadialog.ShowDialog()	== DialogResult.Cancel)	{return	false;}
				pathname=savemetadialog.FileName;

			}
			else
			{
				int	where=pathname.LastIndexOf("\\");
				string temp=path;
				if (where!=-1){temp=temp+"\\"+pathname.Substring(0,where)+"\\";}

				System.IO.Directory.CreateDirectory(temp);
				pathname=path+"\\"+pathname;
				//MessageBox.Show(temp);
			}
	

	

			int	parsedsize=0;
			int[] rlocx=new	int[10000];
			int	rlocc=0;
			int metasize=meta.Size[tag];
			if (metashitwindow.parseit.Checked==true && meta.TagType[tag]!="sbsp")
			{
				MemoryStream FSD=new MemoryStream(100000);
				BinaryWriter BWD=new BinaryWriter(FSD);
				parsemeta(tag,-1,-1,tag);
			
					int fsize=0;
					int	t;
					for	(t=0;t<parsed.count;t++)
					{
						BWD.BaseStream.Write(parsed.meta[t],0,parsed.meta[t].Length);
						fsize+=parsed.meta[t].Length;
					}
					for	(t=0;t<parsed.newreflexcount;t++)
					{
						if (parsed.newreflextrans[t]!=-1)
						{
							BWD.BaseStream.Seek(parsed.newreflexloc[t]+4,SeekOrigin.Begin);
							int	nref=parsed.newreflextrans[t]+meta.Offset[tag]+map.secondaryMagic;
							BWD.Write(nref);
						}
						else
						{
							rlocx[rlocc]=parsed.newreflexloc[t];
							rlocc++;
						}
					}
					meta.Meta=new MemoryStream(fsize);
					BinaryWriter BWT=new BinaryWriter(meta.Meta);
					BWT.BaseStream.Write(FSD.ToArray(),0,fsize);
			
					scan(meta.Meta,meta.Offset[tag],meta.Size[tag],tag,false,false,-1,true,false);
					if (meta.TagType[tag]=="stem" |meta.TagType[tag]=="spas") { scan(meta.Meta,meta.Offset[tag],meta.Size[tag],tag,true,false,-1,false,false);}
					metasize=fsize;
				
			}

			if (meta.scanned==false)			
			{
				int bsptag=-1;
				if (meta.TagType[tag]=="sbsp") {bsptag=Array.IndexOf(bsp.tag,tag);}
				scan(meta.Meta,meta.Offset[tag],meta.Size[tag],-1,false,false,bsptag,true,true);
				if (meta.TagType[tag]=="stem" |meta.TagType[tag]=="spas") { scan(meta.Meta,meta.Offset[tag],meta.Size[tag],-1,true,false,-1,false,true);}

			
			}



			MemoryStream MS=new MemoryStream(1000000);
			BinaryWriter BW=new	BinaryWriter(MS);
			char[] te=meta.TagType[tag].ToCharArray();
			BW.Write(te);
			BW.Write(metasize);
			BW.BaseStream.Write(meta.Meta.ToArray(),0,metasize);
			

		
			FileStream FS=new FileStream(pathname+".data",FileMode.Create,	FileAccess.ReadWrite,FileShare.ReadWrite);
			StreamWriter SW=new	StreamWriter(FS);
			SW.WriteLine(meta.TagType[tag]+"|"+meta.Names[tag]);
			int	x;
			for	(x=0;x<reflex.Count;x++)
			{
				if (Array.IndexOf(rlocx,reflex.Location[x])==-1)
				{
					string temps="Reflexive|"+reflex.Location[x].ToString()+"|"+reflex.Translation[x].ToString()+"|"+reflex.ChunkCount[x].ToString()+"|"+meta.TagType[reflex.InTag[x]]+"|"+meta.Names[reflex.InTag[x]];
					SW.WriteLine(temps);
				}
				else
				{
					if (reflex.Location[x]==0)
					{
						string temps;
						temps="Reflexive|"+reflex.Location[x].ToString()+"|"+reflex.Translation[x].ToString()+"|"+reflex.ChunkCount[x].ToString()+"|"+meta.TagType[reflex.InTag[x]]+"|"+meta.Names[reflex.InTag[x]];
				
						SW.WriteLine(temps);
					}
				}
			}
			for	(x=0;x<dep.Count;x++)
			{
				if (dep.InTag[x]!=-1)
				{
					string temps="DepReference|"+dep.Location[x].ToString()+"|"+meta.TagType[dep.InTag[x]]+"|"+meta.Names[dep.InTag[x]];
					SW.WriteLine(temps);
				}
			}
			for	(x=0;x<lone.Count;x++)
			{
				string temps="LoneReference|"+lone.Location[x].ToString()+"|"+meta.TagType[lone.InTag[x]]+"|"+meta.Names[lone.InTag[x]];
				SW.WriteLine(temps);
			}
			for	(x=0;x<strings.Count;x++)
			{
				string temps="String|"+strings.Location[x].ToString()+"|"+items.Names[strings.StringNum[x]];
				SW.WriteLine(temps);
			}
			SW.Close();
			FS.Close();
			//raw data stuff
			if (meta.TagType[tag]=="mode")
			{
				FS=new FileStream(pathname+".rawd",FileMode.Create,	FileAccess.ReadWrite,FileShare.ReadWrite);
				SW=new StreamWriter(FS);
				SW.WriteLine("External|"+map.externalMap.ToString());
				for	(x=0;x<mode.RawCount;x++)
				{
					
					string temps=mode.LocationOfRawPointer[x].ToString()+"|"+BW.BaseStream.Position.ToString() + "|"+mode.RawSize[x].ToString()+"|"+mode.ExternalMap[x].ToString();
					SW.WriteLine(temps);
					BW.Write(mode.RawData[x].ToArray());
				}
				for	(x=0;x<mode.RawCount2;x++)
				{
					
					string temps=mode.LocationOfRawPointer2[x].ToString()+"|"+BW.BaseStream.Position.ToString() + "|"+mode.RawSize2[x].ToString()+"|"+mode.ExternalMap2[x].ToString();
					SW.WriteLine(temps);
					BW.Write(mode.RawData2[x].ToArray());
				}
				SW.Close();
				FS.Close();

			
					
				
				
		
			}

			if (meta.TagType[tag]=="jmad")
			{
				FS=new FileStream(pathname+".rawd",FileMode.Create,	FileAccess.ReadWrite,FileShare.ReadWrite);
				SW=new StreamWriter(FS);
				SW.WriteLine("External|"+map.externalMap.ToString());
				for	(x=0;x<jmad.RawCount;x++)
				{
					
					string temps=jmad.LocationOfRawPointer[x].ToString()+"|"+BW.BaseStream.Position.ToString()+"|"+jmad.RawSize[x].ToString()+"|"+jmad.ExternalMap[x].ToString();
					SW.WriteLine(temps);
					BW.BaseStream.Write(jmad.RawData[x],0,jmad.RawData[x].Length);
				}
				SW.Close();
				FS.Close();

				
	
					
			
			
		   
			}
			if (meta.TagType[tag]=="snd!")
			{
				FS=new FileStream(pathname+".rawd",FileMode.Create,	FileAccess.ReadWrite,FileShare.ReadWrite);
				SW=new StreamWriter(FS);
				SW.WriteLine("External|"+map.externalMap.ToString());

				string temps="chunk4|"+BW.BaseStream.Position.ToString()+"|"+snd.chunk4.Length.ToString();
				SW.WriteLine(temps);
				BW.Write(snd.chunk4);	

				for	(x=0;x<snd.mainindexcount;x++)
				{			

					temps="chunk5|"+BW.BaseStream.Position.ToString()+"|"+snd.chunk5[x].Length.ToString();
					SW.WriteLine(temps);
					BW.Write(snd.chunk5[x]);	

				}
				for	(x=0;x<snd.RawCount;x++)
				{			
					temps=snd.LocationOfRawPointer[x].ToString()+"|"+BW.BaseStream.Position.ToString()+"|"+snd.RawSize[x].ToString()+"|"+snd.ExternalMap[x].ToString();
					SW.WriteLine(temps);
					BW.BaseStream.Write(snd.RawData[x],0,snd.RawData[x].Length);
				}
				SW.Close();
				FS.Close();

				
	
					
			
			
		   
			}


			if (meta.TagType[tag]=="bitm")
			{
				FS=new FileStream(pathname+".rawd",FileMode.Create,	FileAccess.ReadWrite,FileShare.ReadWrite);
				SW=new StreamWriter(FS);
				SW.WriteLine("External|"+map.externalMap.ToString());
		
			
				
				int	j=0;
				for	(x=0;x<bitm.RawData.Length;x++)
				{
					int	y;
					for	(y=0;y<bitm.subMapCount[x];y++)
					{
						string temps=bitm.LocationOfRawPointer[j].ToString()+"|"+BW.BaseStream.Position.ToString()+"|"+bitm.RawSize[j].ToString()+"|"+bitm.ExternalMap[j].ToString();
						SW.WriteLine(temps);
						BW.Write(bitm.RawData[x][y]);
					
						j++;
					}
				}
				SW.Close();
				FS.Close();

			}

			if (meta.TagType[tag]=="PRTM")
			{
			
				
				
				FS=new FileStream(pathname+".rawd",FileMode.Create,	FileAccess.ReadWrite,FileShare.ReadWrite);
				SW=new StreamWriter(FS);
				SW.WriteLine("External|"+map.externalMap.ToString());
				string temps=prtm.LocationOfRawPointer.ToString()+"|"+BW.BaseStream.Position.ToString()+"|"+prtm.RawSize.ToString()+"|"+prtm.ExternalMap.ToString();
				SW.WriteLine(temps);
				SW.Close();
				FS.Close();
				BW.BaseStream.Write(prtm.RawData,0,prtm.RawData.Length);
			
			
		   
			}

			
			if (meta.TagType[tag]=="DECR")
			{
			
				
				
				FS=new FileStream(pathname+".rawd",FileMode.Create,	FileAccess.ReadWrite,FileShare.ReadWrite);
				SW=new StreamWriter(FS);
				SW.WriteLine("External|"+map.externalMap.ToString());
				string temps=decr.LocationOfRawPointer.ToString()+"|"+BW.BaseStream.Position.ToString()+"|"+decr.RawSize.ToString()+"|"+decr.ExternalMap.ToString();
				SW.WriteLine(temps);
				SW.Close();
				FS.Close();
			
				BW.BaseStream.Write(decr.RawData,0,decr.RawData.Length);
			
			
		   
			}


			if (meta.TagType[tag]=="phmo")
			{
			
				
				
				FS=new FileStream(pathname+".phmo",FileMode.Create,	FileAccess.ReadWrite,FileShare.ReadWrite);
				SW=new StreamWriter(FS);
				string temps=phmo.endsin[tag].ToString();
				SW.WriteLine(temps);
				SW.Close();
				FS.Close();
				
			
		   
			}


			if (meta.TagType[tag]=="spas")
			{
			
				
				
				FS=new FileStream(pathname+".spas",FileMode.Create,	FileAccess.ReadWrite,FileShare.ReadWrite);
				SW=new StreamWriter(FS);
				string temps=spas.endsin[tag].ToString();
				SW.WriteLine(temps);
				SW.Close();
				FS.Close();
				
			
		   
			}



			if (meta.TagType[tag]=="coll")
			{
			
				
				
				FS=new FileStream(pathname+".coll",FileMode.Create,	FileAccess.ReadWrite,FileShare.ReadWrite);
				SW=new StreamWriter(FS);
				string temps=coll.endsin[tag].ToString();
				SW.WriteLine(temps);
				SW.Close();
				FS.Close();
				
		   
			}


			if (meta.TagType[tag]=="sbsp")
			{
				int	i,l;

				FS=new FileStream(pathname+".rawd",FileMode.Create, FileAccess.ReadWrite,FileShare.ReadWrite);
				SW=new StreamWriter(FS);
				
				//string temps=prtm.LocationOfRawPointer.ToString()	+ "|" +	prtm.RawOffset.ToString()+"|"+prtm.RawSize.ToString()+"|"+prtm.ExternalMap.ToString();
				//SW.WriteLine(temps);
			
			
				

				int	where=pathname.LastIndexOf("\\");
				string temp=pathname.Substring(0,where)+"\\"+Split[Split.Length-1]+"[sbsp]\\";
				string templ=temp+Split[Split.Length-1];
				System.IO.Directory.CreateDirectory(temp);				
				
				
				i=Array.IndexOf(bsp.tag,tag);
				SW.WriteLine(bsp.Magic[i].ToString()+"|"+bsp.Offset[i].ToString());
				SW.WriteLine("BSPmodel|"+bsp.Model1Count[i]);
				for	(l=0;l<bsp.Model1Count[i];l++)
				{
					string temps=bsp.Model1Loc[i][l].ToString()+"|"+BW.BaseStream.Position.ToString() + "|"+bsp.Model1Size[i][l].ToString()+"|"+bsp.Model1Map[i][l].ToString();
					SW.WriteLine(temps);
					BW.Write(bsp.Model1Raw[i][l].ToArray());
			
				}

				SW.WriteLine("BSPmodel|"+bsp.Model2Count[i]);
				for	(l=0;l<bsp.Model2Count[i];l++)
				{
					string temps=bsp.Model2Loc[i][l].ToString()+"|"+BW.BaseStream.Position.ToString() + "|"+bsp.Model2Size[i][l].ToString()+"|"+bsp.Model2Map[i][l].ToString();
					SW.WriteLine(temps);
					BW.Write(bsp.Model2Raw[i][l]);
					
				}

				int[] tempshit=new int[bsp.Model3Count[i]];
				int[] tempshit2=new int[bsp.Model3Count[i]];
				SW.WriteLine("BSPmodel|"+bsp.Model3Count[i]);
				for	(l=0;l<bsp.Model3Count[i];l++)
				{
					int t=Array.IndexOf(bsp.Model3Offset[i],bsp.Model3Offset[i][l]);
					if(t>=l)
					{
						string temps=bsp.Model3Loc[i][l].ToString()+"|"+BW.BaseStream.Position.ToString() + "|"+bsp.Model3Size[i][l].ToString()+"|"+bsp.Model3Map[i][l].ToString();
						SW.WriteLine(temps);
						tempshit[l]=bsp.Model3Offset[i][l];
						tempshit2[l]=(int)BW.BaseStream.Position;
						BW.Write(bsp.Model3Raw[i][l]);
						
					}
					else
					{
						int tt=Array.IndexOf(tempshit,bsp.Model3Offset[i][l]);
						string temps=bsp.Model3Loc[i][l].ToString()+"|"+tempshit2[tt].ToString() + "|"+bsp.Model3Size[i][l].ToString()+"|"+bsp.Model3Map[i][l].ToString();
						SW.WriteLine(temps);
					}
				}

				SW.WriteLine("BSPmodel|"+bsp.Model4Count[i]);
				for	(l=0;l<bsp.Model4Count[i];l++)
				{
					string temps=bsp.Model4Loc[i][l].ToString()+"|"+BW.BaseStream.Position.ToString() + "|"+bsp.Model4Size[i][l].ToString()+"|"+bsp.Model4Map[i][l].ToString();
					SW.WriteLine(temps);
					BW.Write(bsp.Model4Raw[i][l]);
			
				}
				SW.Close();
				FS.Close();
			}


			int qw=(int)BW.BaseStream.Position;

			FS=new FileStream(pathname,FileMode.Create,	FileAccess.ReadWrite,FileShare.ReadWrite);
			BW=new BinaryWriter(FS);
			BW.BaseStream.Write(MS.ToArray(),0,qw);
			BW.Close();
			FS.Close();





			return true;
		}

		public void metasaveclick()
		{
			if (meta.SelectedMeta != -1)
			{
				if (metashitwindow.recursive.Checked==false)
				{
					
					recursivenamelist= new string[100000];
					recursivecount=0;
					bool oi=savemeta(meta.SelectedMeta,true,"");
					FileStream FS=new FileStream("info.data",FileMode.Create);
					StreamWriter SW=new StreamWriter(FS);
					for (int r=0;r<recursivecount;r++)
					{
						SW.WriteLine(recursivenamelist[r]);
					}
					SW.Close();
					FS.Close();
					if (oi==true){MessageBox.Show("Done");}
				}
				else
				{
					if (folder.ShowDialog()==DialogResult.Cancel){return;}
					importfiles.FileOrderX=new int[10000];
					importfiles.count=0;
					importfiles.deps=new int[10000][];
					importfiles.depscount=new int[10000];
					importfiles.lone=new int[10000][];
					importfiles.lonecount=new int[10000];
					recursivenamelist= new string[100000];
					recursivecount=0;
					saverecursive(meta.SelectedMeta,0);
					
					FileStream FS=new FileStream(folder.SelectedPath+"\\info.data",FileMode.Create);
					StreamWriter SW=new StreamWriter(FS);
					for (int r=0;r<recursivecount;r++)
					{
						SW.WriteLine(recursivenamelist[r]);
					}
					SW.Close();
					FS.Close();
					MessageBox.Show("Done");
				}
			}
		}

		private	void saverecursive(int tag,int lev)
		{
			//if (meta.TagType[tag]=="snd!"){return;}
		

			meta.Meta=new MemoryStream(meta.Size[tag]);
			FileStream FS=new FileStream(map.filepath,FileMode.Open);
			BinaryReader BR=new BinaryReader(FS);
			BR.BaseStream.Position=meta.Offset[tag];
			meta.Meta.Write(BR.ReadBytes(meta.Size[tag]),0,meta.Size[tag]);
			BR.Close();
			FS.Close();

	
			scanraw(tag);
			savemeta(tag, false, folder.SelectedPath);
			importfiles.FileOrderX[importfiles.count]=tag;
			importfiles.count++;

			importfiles.deps[lev]=dep.InTag;
			importfiles.depscount[lev]=dep.Count;

			importfiles.lone[lev]=lone.InTag;
			importfiles.lonecount[lev]=lone.Count;


			int	x;
			for	(x=0;x<importfiles.depscount[lev];x++)
			{
				if (importfiles.deps[lev][x]==-1){continue;}
				if (Array.IndexOf(importfiles.FileOrderX,importfiles.deps[lev][x])==-1)
				{
					saverecursive(importfiles.deps[lev][x],lev+1);
				}
			
			}
			for	(x=0;x<importfiles.lonecount[lev];x++)
			{
				if (importfiles.lone[lev][x]==-1){continue;}
				if (Array.IndexOf(importfiles.FileOrderX,importfiles.lone[lev][x])==-1)
				{
					saverecursive(importfiles.lone[lev][x],lev+1);
				}
			
			}

		
		}

		public void	scanraw(int	tag)
		{
			
			if (meta.TagType[tag]=="mode"){GetModelData(tag);}
			if (meta.TagType[tag]=="jmad"){GetJmadData(tag);}
			if (meta.TagType[tag]=="bitm"){GetBitmData(tag);}
			if (meta.TagType[tag]=="PRTM"){GetPRTMData(tag);}
			if (meta.TagType[tag]=="DECR"){GetDECRData(tag);}
			if (meta.TagType[tag]=="phmo"){GetPhmoData(tag);}
			if (meta.TagType[tag]=="spas"){GetspasData(tag);}
			if (meta.TagType[tag]=="coll"){GetCollData(tag);}
			if (meta.TagType[tag]=="snd!"){GetSndData(tag);}
		}

		public void	ParseColl(int tag)
		{
			FileStream FS=new FileStream(openmap.FileName,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
			BinaryReader BR=new	BinaryReader(FS);

			BR.BaseStream.Seek(meta.Offset[tag]+28,SeekOrigin.Begin);
			int	tempc1=BR.ReadInt32();
			int	tempr1=BR.ReadInt32()-map.secondaryMagic;

			BR.BaseStream.Seek(tempr1+4,SeekOrigin.Begin);
			int	tempc2=BR.ReadInt32();
			int	tempr2=BR.ReadInt32()-map.secondaryMagic;

			BR.BaseStream.Seek(tempr2+4,SeekOrigin.Begin);//68 bytes
			int	tempc3=BR.ReadInt32();
			int	tempr3=BR.ReadInt32()-map.secondaryMagic;

			BR.BaseStream.Seek(tempr3+60,SeekOrigin.Begin);///16 bytes
			int	tempc4=BR.ReadInt32();
			int	tempr4=BR.ReadInt32()-map.secondaryMagic;

			coll.x=new float[tempc4];
			coll.y=new float[tempc4];
			coll.z=new float[tempc4];
			for	(int x=0;x<tempc4;x++)
			{
				BR.BaseStream.Seek(tempr4+(x*16),SeekOrigin.Begin);///16 bytes
				coll.x[x]=BR.ReadSingle();
				coll.y[x]=BR.ReadSingle();
				coll.z[x]=BR.ReadSingle();
			}

			BR.BaseStream.Seek(tempr3+20,SeekOrigin.Begin);///16 bytes
			int	tempc5=BR.ReadInt32();
			int	tempr5=BR.ReadInt32()-map.secondaryMagic;

			short[]	indices=new	short[tempc5];
			BR.BaseStream.Seek(tempr5,SeekOrigin.Begin);
			for	(int x=0;x<tempc5;x++)
			{
				BR.ReadInt16();
				indices[x]=BR.ReadInt16();
							
			}

				
				
			short[]	shite=new short[100000];
			int	m=0;
			
			int	s=0;
					
			bool dir=false;
			short tempx;
			short tempy;
			short tempz;
						
			do
			{
				if (m+2>=indices.Length) {break;}
				tempx =	indices[m];
				tempy =	indices[m+1];
				tempz =	indices[m+2];
 
			  
				if (tempx != tempy && tempx	!= tempz &&	tempy != tempz)
				{
					if (dir	== false)
					{
						shite[s] = tempx;
						shite[s+1] = tempy;
						shite[s+2] = tempz;
						s += 3;
						
						dir=true;
					}
					else
					{
						shite[s] = tempx;
						shite[s+1] = tempz;
						shite[s+2] = tempy;
						s += 3;
						dir=false;
					}
					m+=1;
				}
				else
				{
					if (dir	==true)	{ dir =	false; } 
					else {dir =	true;}
							  
					m+=1;
				}
			}
			while (m<indices.Length);
				

			coll.indices=new short[s];
			Array.Copy(shite,0,coll.indices,0,s);
	
		


			BR.Close();
			FS.Close();
		}

		public void	ParseModel(int tag)
		{
		
			FileStream FS=new FileStream(openmap.FileName,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
			BR=new BinaryReader(FS);

			BR.BaseStream.Seek(meta.Offset[tag]+20,SeekOrigin.Begin);
			int	tempc=BR.ReadInt32();
			int	tempr=BR.ReadInt32()-map.secondaryMagic;;

			BR.BaseStream.Seek(tempr,SeekOrigin.Begin);	
			mode.MinX=BR.ReadSingle();
			mode.MaxX=BR.ReadSingle();
			mode.MinY=BR.ReadSingle();
			mode.MaxY=BR.ReadSingle();
			mode.MinZ=BR.ReadSingle();
			mode.MaxZ=BR.ReadSingle();
			mode.MinU=BR.ReadSingle();
			mode.MaxU=BR.ReadSingle();
			mode.MinV=BR.ReadSingle();
			mode.MaxV=BR.ReadSingle();

		
			BR.BaseStream.Seek(meta.Offset[tag]+28,SeekOrigin.Begin);
			tempc=BR.ReadInt32();
			tempr=BR.ReadInt32()-map.secondaryMagic;;

			mode.LOD=new int[tempc][][];
			mode.LODCount=new int[tempc][];
			mode.LODName=new string[tempc];
			mode.LODName2=new string[tempc][];

			
			
			
			
			
			int	x;			
			for	(x=0;x<tempc;x++)
			{

				BR.BaseStream.Seek(tempr + (x *	16), SeekOrigin.Begin);
				int	nametempid = BR.ReadInt16();
				mode.LODName[x]	= items.Names[nametempid];
				BR.ReadInt16();
				BR.ReadInt32();
				int	tempccc=BR.ReadInt32();
				int	tempref	= BR.ReadInt32() - map.secondaryMagic;

				mode.LODName2[x]=new string[tempccc];
				mode.LODCount[x]=new int[tempccc];
				mode.LOD[x]=new	int[tempccc][];
				for(int	y=0;y<tempccc;y++)
				{
					BR.BaseStream.Seek(tempref+(y*16), SeekOrigin.Begin);
					int	nametempidx	= BR.ReadInt16();
				
					mode.LODName2[x][y]	= items.Names[nametempidx];

					BR.ReadInt16();
			
			
		  
					int[] temps=new	int[5];
					int	j;
					for	(j=0;j<5;j++)
					{
						temps[j]=BR.ReadInt16();
					}
				
					if (temps[0] ==	temps[1] &&	temps[0] ==	temps[2] &&	temps[0] ==	temps[3] &&	temps[0] ==	temps[4]){mode.LODCount[x][y] =	3;}	
					else {mode.LODCount[x][y] =	5;}

					mode.LOD[x][y]=new int[mode.LODCount[x][y]];
	
					Array.Copy(temps,0,mode.LOD[x][y],0,mode.LODCount[x][y]);
					
				}
				
			}
  
			
			
			BR.BaseStream.Seek(meta.Offset[tag]+36,SeekOrigin.Begin);
			tempc=BR.ReadInt32();
			tempr=BR.ReadInt32()-map.secondaryMagic;
			mode.startofrawinfometachunks=tempr-meta.Offset[tag];
			mode.Texture=new int[tempc][];
			mode.StartOfIndices=new	int[tempc][];
			mode.EndOfIndices=new int[tempc][];
			mode.RawChunkOffset=new	int[tempc][];
			mode.RawChunkSize=new int[tempc][];
			mode.RawChunkTotalSize=new int[tempc][];
			mode.RawChunkCount=new int[tempc];
			//mode.=new int[tempc];
			
			mode.RawHeaderSize=new int[tempc];
			mode.RawWithoutHeaderSize=new int[tempc];
			mode.VerticeCount=new int[tempc];
			mode.IndiceCount=new int[tempc];
			mode.X=new float[tempc][];
			mode.Y=new float[tempc][];
			mode.Z=new float[tempc][];
			mode.nX=new	float[tempc][];
			mode.nY=new	float[tempc][];
			mode.nZ=new	float[tempc][];
			mode.U=new float[tempc][];
			mode.V=new float[tempc][];
			mode.InfoBlockCount=new	int[tempc];
			mode.Unk1Count=new int[tempc];
			mode.Unk2Count=new int[tempc];
			mode.Unk3Count=new int[tempc];
			mode.Indices=new short[tempc][];
			mode.FixedIndices=new short[tempc][][];
			mode.FixedIndices2=new short[tempc][];
			mode.FaceCount=new int[tempc];
			mode.RawChunkData=new byte[tempc][][];
			mode.IndiceChunkNumber=new int[tempc];
			mode.StartOfShit=new int[tempc];
			mode.RawChunkInfoLoc=new int[tempc];
			for	(x=0;x<tempc;x++)
			{
				//find out verticecount--declare vertices
				BR.BaseStream.Seek(tempr+(x*92)+4,SeekOrigin.Begin);
				mode.VerticeCount[x]=BR.ReadUInt16();
				mode.FaceCount[x]=BR.ReadUInt16();
				mode.X[x]=new float[mode.VerticeCount[x]];
				mode.Y[x]=new float[mode.VerticeCount[x]];
				mode.Z[x]=new float[mode.VerticeCount[x]];
				mode.U[x]=new float[mode.VerticeCount[x]];
				mode.V[x]=new float[mode.VerticeCount[x]];
				mode.nX[x]=new float[mode.VerticeCount[x]];
				mode.nY[x]=new float[mode.VerticeCount[x]];
				mode.nZ[x]=new float[mode.VerticeCount[x]];
				//raw data info	about chunk	sizes and shiznit
				BR.BaseStream.Seek(tempr+(x*92)+68,SeekOrigin.Begin);
				mode.RawWithoutHeaderSize[x]=BR.ReadInt32();
				int	tempcount=BR.ReadInt32();
				int	tempreflex=BR.ReadInt32()-map.secondaryMagic;

				

				mode.RawChunkSize[x]=new int[tempcount];
				mode.RawChunkTotalSize[x]=new int[tempcount];
				mode.RawChunkData[x]=new byte[tempcount][];
				mode.RawChunkOffset[x]=new int[tempcount];
				mode.RawChunkInfoLoc[x]=tempreflex-meta.Offset[meta.SelectedMeta];
				mode.RawChunkCount[x]=tempcount;
				int	j;
				for	(j=0;j<tempcount;j++)
				{
					BR.BaseStream.Seek(tempreflex+(j*16)+6,SeekOrigin.Begin);
					mode.RawChunkSize[x][j]=BR.ReadUInt16();
					mode.RawChunkTotalSize[x][j]=BR.ReadInt32();
					mode.RawChunkOffset[x][j]=BR.ReadInt32();
					
				}
			}

			BR.BaseStream.Seek(meta.Offset[tag]+96,SeekOrigin.Begin);
			int	tempc2=BR.ReadInt32();
			int	tempr2=BR.ReadInt32()-map.secondaryMagic;
		
			mode.shaders=new ShaderInfo[tempc2];
			
			int[] blist=new int[tempc2];
			for	(int j=0;j<tempc2;j++)
			{
				//float	shit=((float)j/(float)tempc2)*100;
				//progress.Value=(int)shit;
					mode.shaders[j]=new ShaderInfo();
				BR.BaseStream.Seek(tempr2+(j*32)+12,SeekOrigin.Begin);
				mode.shaders[j].tag=findbyid(BR.ReadInt32());
				if (mode.shaders[j].tag==-1) {continue;}
				BR.BaseStream.Seek(meta.Offset[mode.shaders[j].tag]+4,SeekOrigin.Begin);
				mode.shaders[j].stemname=meta.Names[findbyid(BR.ReadInt32())];
				BR.BaseStream.Seek(meta.Offset[mode.shaders[j].tag]+12,SeekOrigin.Begin);
				int	tc=BR.ReadInt32();
				int	tr=BR.ReadInt32()-map.secondaryMagic;
				BR.BaseStream.Seek(tr+4,SeekOrigin.Begin);
				int	tempshit=findbyid(BR.ReadInt32());
				if (tempshit==-1)
				{
					BR.BaseStream.Seek(tr,SeekOrigin.Begin);
					tempshit=findbyid(BR.ReadInt32());
				}
				if (tempshit==-1)
				{
					BR.BaseStream.Seek(meta.Offset[mode.shaders[j].tag]+32,SeekOrigin.Begin);
					tc=BR.ReadInt32();
					if (tc>0)
					{
						tr=BR.ReadInt32()-map.secondaryMagic;
						BR.BaseStream.Seek(tr+4,SeekOrigin.Begin);
						int	tcx=BR.ReadInt32();
						int	trx=BR.ReadInt32()-map.secondaryMagic;
						BR.BaseStream.Seek(trx,SeekOrigin.Begin);
						tempshit=findbyid(BR.ReadInt32());
					}
				}
				mode.shaders[j].btag=tempshit;
				if (Array.IndexOf(blist,tempshit)!=-1)
				{
					mode.shaders[j].b=mode.shaders[Array.IndexOf(blist,tempshit)].b;
					mode.shaders[j].b2=mode.shaders[Array.IndexOf(blist,tempshit)].b2;
				}
				blist[j]=tempshit;
				if (tempshit==-1){continue;}
				BR.BaseStream.Seek(meta.Offset[tempshit]+68,SeekOrigin.Begin);
				int	tempcou=BR.ReadInt32();
				int	tempref=BR.ReadInt32()-map.secondaryMagic;

					
				byte[] fuck;
				BR.BaseStream.Seek(tempref + 4,SeekOrigin.Begin);
				int	width=BR.ReadUInt16();
				int	height=BR.ReadUInt16();
				int	depth=BR.ReadUInt16();
				int	type=BR.ReadUInt16();
				int	format=BR.ReadUInt16();
						

				BR.BaseStream.Seek(tempref + 28,SeekOrigin.Begin);
				int	tempint=BR.ReadInt32();
				byte[] test=new	byte[4];
				BitArray crap=new BitArray(new int[] {tempint});
				string oi=""; int yy;
				for	(yy=31;yy>29;yy--)
				{
					if (crap[yy].ToString()=="False"){oi=oi+"0";} 
					else {oi=oi+"1";}
					crap[yy]=false;
				}
				crap.CopyTo(test,0);
				int	rawoffset=BitConverter.ToInt32(test,0);
				BR.BaseStream.Seek(tempref + 52,SeekOrigin.Begin);
				int	rawsize=BR.ReadInt32();
				string path=openmap.FileName.Substring(0,openmap.FileName.LastIndexOf("\\"));
				if (oi=="00"){path=openmap.FileName;}
				if (oi=="01"){path=path+"\\"+"mainmenu.map";}
				if (oi=="10"){path=path+"\\"+"shared.map";}
				if (oi=="11"){path=path+"\\"+"single_player_shared.map";}
				
				
	
				FileStream FSX=new FileStream(path,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
				BinaryReader BRX=new BinaryReader(FSX);
				BRX.BaseStream.Seek(rawoffset,SeekOrigin.Begin);
				fuck=BRX.ReadBytes(rawsize);
				BRX.Close();
				FSX.Close();
				mode.shaders[j].b=lll.DecodeBitmx(fuck,0,0,height,width,format,-1);




				///BR.BaseStream.Seek(meta.Offset[mode.shaders[j].tag]+32,SeekOrigin.Begin);
				///tc=BR.ReadInt32();
				///tr=BR.ReadInt32()-map.secondaryMagic;
				///if (tc==0 |tr+map.secondaryMagic==0)
				///{
				///	continue;
				///}
				///	BR.BaseStream.Seek(tr+4,SeekOrigin.Begin);
				///	tc=BR.ReadInt32();
				///	tr=BR.ReadInt32()-map.secondaryMagic;
				///	if (tc==0 |tr+map.secondaryMagic==0){continue;}
				

				///BR.BaseStream.Seek(tr,SeekOrigin.Begin);
				///tempshit=findbyid(BR.ReadInt32());
				///if (tempshit==-1){continue;}
		
				///BR.BaseStream.Seek(meta.Offset[tempshit]+68,SeekOrigin.Begin);
				///tempcou=BR.ReadInt32();
				///tempref=BR.ReadInt32()-map.secondaryMagic;


				///BR.BaseStream.Seek(tempref + 4,SeekOrigin.Begin);
				///width=BR.ReadUInt16();
				///height=BR.ReadUInt16();
				///depth=BR.ReadUInt16();
				///type=BR.ReadUInt16();
				///format=BR.ReadUInt16();
						

				///BR.BaseStream.Seek(tempref + 28,SeekOrigin.Begin);
				///tempint=BR.ReadInt32();
				///test=new	byte[4];
				/// crap=new BitArray(new int[] {tempint});
				///oi=""; 
				///for	(yy=31;yy>29;yy--)
				///{
				///	if (crap[yy].ToString()=="False"){oi=oi+"0";} 
				///	else {oi=oi+"1";}
				///	crap[yy]=false;
				///}
				///crap.CopyTo(test,0);
				///rawoffset=BitConverter.ToInt32(test,0);
				///BR.BaseStream.Seek(tempref + 52,SeekOrigin.Begin);
				///rawsize=BR.ReadInt32();
				///path=openmap.FileName.Substring(0,openmap.FileName.LastIndexOf("\\"));
				///if (oi=="00"){path=openmap.FileName;}
				///if (oi=="01"){path=path+"\\"+"mainmenu.map";}
				///if (oi=="10"){path=path+"\\"+"shared.map";}
				///if (oi=="11"){path=path+"\\"+"single_player_shared.map";}
				
				
	
				///FS=new FileStream(path,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
				///BRX=new BinaryReader(FS);
				///BRX.BaseStream.Seek(rawoffset,SeekOrigin.Begin);
				///fuck=BRX.ReadBytes(rawsize);
				///BRX.Close();
				///FS.Close();
				///mode.shaders[j].b2=lll.DecodeBitmx(fuck,0,0,height,width,format,-1);
			}

			
			for	(x=0;x<tempc;x++)
			{
				BinaryReader BRX=new BinaryReader(mode.RawData[x]);

				int	temploc=mode.RawSize[x]-mode.RawWithoutHeaderSize[x]-4;
				
				mode.StartOfShit[x]=temploc;
				mode.HeaderChunkData=new byte[temploc];
				BRX.BaseStream.Seek(mode.RawOffset[x],SeekOrigin.Begin);
				mode.HeaderChunkData=BRX.ReadBytes(temploc);

				for	(int v=0;v<mode.RawChunkData[x].Length;v++)
				{
					BRX.BaseStream.Seek(temploc+mode.RawChunkOffset[x][v],SeekOrigin.Begin);
					mode.RawChunkData[x][v]=BRX.ReadBytes(mode.RawChunkTotalSize[x][v]);
				}

				//read in chunk	counts
				BRX.BaseStream.Seek(8,SeekOrigin.Begin);
				mode.InfoBlockCount[x]=BRX.ReadUInt16();
				BRX.BaseStream.Seek(16,SeekOrigin.Begin);
				mode.Unk1Count[x]=BRX.ReadUInt16();
				BRX.BaseStream.Seek(24,SeekOrigin.Begin);
				mode.Unk2Count[x]=BRX.ReadUInt16();
				BRX.BaseStream.Seek(40,SeekOrigin.Begin);
				mode.IndiceCount[x]=BRX.ReadUInt16();
				BRX.BaseStream.Seek(64,SeekOrigin.Begin);
				mode.Unk3Count[x]=BRX.ReadUInt16();

				mode.Texture[x]=new	int[mode.InfoBlockCount[x]];
				mode.StartOfIndices[x]=new int[mode.InfoBlockCount[x]];
				mode.EndOfIndices[x]=new int[mode.InfoBlockCount[x]];

			
				int	j;
				for	(j=0;j<mode.InfoBlockCount[x];j++)
				{
					BRX.BaseStream.Seek(temploc+mode.RawChunkOffset[x][0]+4+(j*72),SeekOrigin.Begin);

					mode.Texture[x][j]=BRX.ReadUInt16();
					mode.StartOfIndices[x][j]=BRX.ReadUInt16();
					mode.EndOfIndices[x][j]=BRX.ReadUInt16();
				}

				//indice shit
				mode.Indices[x]=new	short[mode.IndiceCount[x]];
				int	indicechunk=0;
				int	verticechunk=0;
				int	uvchunk=0;
				
				for	(j=0;j<mode.RawChunkCount[x];j++)
				{
					if (mode.RawChunkSize[x][j]==2)	{indicechunk=j;verticechunk=j+2;uvchunk=verticechunk+1;break;}
				}

				mode.IndiceChunkNumber[x]=indicechunk;

				BRX.BaseStream.Seek(temploc+mode.RawChunkOffset[x][indicechunk],SeekOrigin.Begin);
				for	(j=0;j<mode.IndiceCount[x];j++)
				{
					mode.Indices[x][j]=BRX.ReadInt16();
				}

				mode.FixedIndices[x]=new short[mode.InfoBlockCount[x]][];

				int	t=0;	
				int	indicenum=0;
				for	(j=0;j<mode.InfoBlockCount[x];j++)
				{
					if (mode.FaceCount[x]*3!=mode.IndiceCount[x])
					{
				
						short[]	shite=new short[100000];
						int	m=0;
			
						int	s=0;
					
						bool dir=false;
						short tempx;
						short tempy;
						short tempz;
						
						do
						{
							//if (mode.EndOfIndices[x][j]>m+2){break;}

							tempx =	mode.Indices[x][indicenum+m];
							tempy =	mode.Indices[x][indicenum+m+1];
							tempz =	mode.Indices[x][indicenum+m+2];
 
			  
							if (tempx != tempy && tempx	!= tempz &&	tempy != tempz)
							{
								if (dir	== false)
								{
									shite[s] = tempx;
									shite[s+1] = tempy;
									shite[s+2] = tempz;
									s += 3;
						
									dir=true;
								}
								else
								{
									shite[s] = tempx;
									shite[s+1] = tempz;
									shite[s+2] = tempy;
									s += 3;
									dir=false;
								}
								m+=1;
							}
							else
							{
								if (dir	==true)	{ dir =	false; } 
								else {dir =	true;}
							  
								m+=1;
							}
						}
						while (m<mode.EndOfIndices[x][j]-2);
				

						indicenum+=mode.EndOfIndices[x][j];
						mode.FixedIndices[x][j]=new	short[s];
						t+=s;
						Array.Copy(shite,0,mode.FixedIndices[x][j],0,s);
					}
					else
					{
						mode.FixedIndices[x][j]=new	short[mode.EndOfIndices[x][j]];
						Array.Copy(mode.Indices[x],mode.StartOfIndices[x][j],mode.FixedIndices[x][j],0,mode.EndOfIndices[x][j]);
					}
				}	

			
				if (mode.FaceCount[x]*3!=mode.IndiceCount[x])
				
				{
					short[]	shite2=new short[100000];
					int	m2=0;
					int	s2=0;
					
					bool dir2=false;
					short tempx2;
					short tempy2;
					short tempz2;
					do
					{
						tempx2 = mode.Indices[x][m2];
						tempy2 = mode.Indices[x][m2+1];
						tempz2 = mode.Indices[x][m2+2];
 
			  
						if (tempx2 != tempy2 &&	tempx2 != tempz2 &&	tempy2 != tempz2)
						{
							if (dir2 ==	false)
							{
								shite2[s2] = tempx2;
								shite2[s2+1] = tempy2;
								shite2[s2+2] = tempz2;
								s2 += 3;
						
								dir2=true;
							}
							else
							{
								shite2[s2] = tempx2;
								shite2[s2+1] = tempz2;
								shite2[s2+2] = tempy2;
								s2 += 3;
								dir2=false;
							}
							m2+=1;
						}
						else
						{
							if (dir2 ==true) { dir2	= false; } 
							else {dir2 = true;}
							  
							m2+=1;
						}
					}
					while (m2!=mode.IndiceCount[x]-2);
					mode.FixedIndices2[x]=new short[s2];
					Array.Copy(shite2,0,mode.FixedIndices2[x],0,s2);
			
				}
				else
				{
					mode.FixedIndices2[x]=new short[mode.Indices[x].Length ];
					Array.Copy(mode.Indices[x],0,mode.FixedIndices2[x],0,mode.Indices[x].Length);
				}
					


				int	vertchunksize=mode.RawChunkTotalSize[x][verticechunk]/mode.VerticeCount[x];
				int	vertloc=temploc+mode.RawChunkOffset[x][verticechunk];
				for	(j=0;j<mode.VerticeCount[x];j++)
				{
					BRX.BaseStream.Seek(vertloc+(j*vertchunksize),SeekOrigin.Begin);
					float jjj=Convert.ToSingle(BRX.ReadInt16());
					mode.X[x][j]=DecompressVertice(jjj,mode.MinX,mode.MaxX);
					mode.Y[x][j]=DecompressVertice(Convert.ToSingle(BRX.ReadInt16()),mode.MinY,mode.MaxY);
					mode.Z[x][j]=DecompressVertice(Convert.ToSingle(BRX.ReadInt16()),mode.MinZ,mode.MaxZ);
				}

				int	uvloc=temploc+mode.RawChunkOffset[x][uvchunk];
				for	(j=0;j<mode.VerticeCount[x];j++)
				{
					BRX.BaseStream.Seek(uvloc+(j*4),SeekOrigin.Begin);
					mode.U[x][j]=DecompressVertice(Convert.ToSingle(BRX.ReadInt16()),mode.MinU,mode.MaxU);
					if (mode.U[x][j]>1){mode.U[x][j]=mode.U[x][j]-1;}
					mode.V[x][j]=DecompressVertice(Convert.ToSingle(BRX.ReadInt16()),mode.MinV,mode.MaxV);
					if (mode.V[x][j]>1){mode.V[x][j]=mode.V[x][j]-1;}
				}

				uvloc=temploc+mode.RawChunkOffset[x][uvchunk+1];
				for	(j=0;j<mode.VerticeCount[x];j++)
				{
					BRX.BaseStream.Seek(uvloc+(j*12),SeekOrigin.Begin);
					mode.nX[x][j]=DecompressVertice(Convert.ToSingle(BRX.ReadInt16()),0,1);
					if (mode.nX[x][j]>1){mode.nX[x][j]=mode.nX[x][j]-1;}
					mode.nY[x][j]=DecompressVertice(Convert.ToSingle(BRX.ReadInt16()),0,1);
					if (mode.nY[x][j]>1){mode.nY[x][j]=mode.nY[x][j]-1;}
					mode.nZ[x][j]=DecompressVertice(Convert.ToSingle(BRX.ReadInt16()),0,0);
					if (mode.nZ[x][j]>1){mode.nZ[x][j]=mode.nZ[x][j]-1;}
				}


		
			}
			BR.Close();
			FS.Close();

		

		}

		public void	ParseBSP(int tag)
		{
			


			FileStream FS=new FileStream(openmap.FileName,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
			BinaryReader BR=new	BinaryReader(FS);
			BR.BaseStream.Seek(bsp.Offset[tag] + 180, SeekOrigin.Begin);
			int	tc2=BR.ReadInt32();
			int	tr2=BR.ReadInt32();
			tr2-=bsp.Magic[tag];
		
			bsp.shaders1=new ShaderInfo[tc2];
			int	r;
			for	(r=0;r<tc2;r++)
			{
			bsp.shaders1[r]=new ShaderInfo();
				float hk=((float)r/(float)tc2)*100;
				progress.Value=(int)hk;
				Application.DoEvents();
				BR.BaseStream.Seek(tr2 + (r	* 32) +	12,	SeekOrigin.Begin);

				bsp.shaders1[r].tag=findbyid(BR.ReadInt32());
				if (bsp.shaders1[r].tag==-1	) {continue;}
				BR.BaseStream.Seek(meta.Offset[bsp.shaders1[r].tag]+4,SeekOrigin.Begin);
				bsp.shaders1[r].stemname=meta.Names[findbyid(BR.ReadInt32())];
				BR.BaseStream.Seek(meta.Offset[bsp.shaders1[r].tag]+12,SeekOrigin.Begin);

				int	tc=BR.ReadInt32();
				int	tr=BR.ReadInt32()-map.secondaryMagic;
				BR.BaseStream.Seek(tr+4,SeekOrigin.Begin);
				int	tempshit=findbyid(BR.ReadInt32());
				if (tempshit==-1)
				{
					BR.BaseStream.Seek(tr,SeekOrigin.Begin);
					tempshit=findbyid(BR.ReadInt32());
				}
				if (tempshit==-1)
				{
					BR.BaseStream.Seek(meta.Offset[bsp.shaders1[r].tag]+32,SeekOrigin.Begin);
					tc=BR.ReadInt32();
					if (tc>0)
					{
						tr=BR.ReadInt32()-map.secondaryMagic;
						BR.BaseStream.Seek(tr+4,SeekOrigin.Begin);
						int	tcx=BR.ReadInt32();
						int	trx=BR.ReadInt32()-map.secondaryMagic;
						BR.BaseStream.Seek(trx,SeekOrigin.Begin);
						tempshit=findbyid(BR.ReadInt32());
					}
				}
				bsp.shaders1[r].btag=tempshit;
				if (tempshit==-1 ) {continue;}
				BR.BaseStream.Seek(meta.Offset[tempshit]+68,SeekOrigin.Begin);
				int	tempcou=BR.ReadInt32();
				int	tempref=BR.ReadInt32()-map.secondaryMagic;

					
				byte[] fuck;
				BR.BaseStream.Seek(tempref + 4,SeekOrigin.Begin);
				int	width=BR.ReadUInt16();
				int	height=BR.ReadUInt16();
				int	depth=BR.ReadUInt16();
				int	type=BR.ReadUInt16();
				int	format=BR.ReadUInt16();
						

				BR.BaseStream.Seek(tempref + 28,SeekOrigin.Begin);
				int	tempint=BR.ReadInt32();
				byte[] test=new	byte[4];
				BitArray crap=new BitArray(new int[] {tempint});
				string oi=""; int yy;
				for	(yy=31;yy>29;yy--)
				{
					if (crap[yy].ToString()=="False"){oi=oi+"0";} 
					else {oi=oi+"1";}
					crap[yy]=false;
				}
				crap.CopyTo(test,0);
				int	rawoffset=BitConverter.ToInt32(test,0);
				BR.BaseStream.Seek(tempref + 52,SeekOrigin.Begin);
				int	rawsize=BR.ReadInt32();
				int	external=0;	
				if (oi=="01"){external=1;}
				if (oi=="10"){external=2;}
				if (oi=="11"){external=3;}
				
				string path=openmap.FileName.Substring(0,openmap.FileName.LastIndexOf("\\"));
				if (external==0) {path=openmap.FileName;}
				if (external==1) {path=path+"\\"+"mainmenu.map";}
				if (external==2) {path=path+"\\"+"shared.map";}
				if (external==3) {path=path+"\\"+"single_player_shared.map";}
				FileStream FSX=new FileStream(path,FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
				BinaryReader BRX=new BinaryReader(FSX);
				BRX.BaseStream.Seek(rawoffset,SeekOrigin.Begin);
				fuck=BRX.ReadBytes(rawsize);
				BRX.Close();
				FSX.Close();
				bsp.shaders1[r].b=lll.DecodeBitmx(fuck,0,0,height,width,format,-1);		










				BR.BaseStream.Seek(meta.Offset[bsp.shaders1[r].tag]+32,SeekOrigin.Begin);
				tc=BR.ReadInt32();
				tr=BR.ReadInt32()-map.secondaryMagic;
				if (tc==0 |tr+map.secondaryMagic==0)
				{
					continue;
				}
				BR.BaseStream.Seek(tr+4,SeekOrigin.Begin);
				tc=BR.ReadInt32();
				tr=BR.ReadInt32()-map.secondaryMagic;
				if (tc==0 |tr+map.secondaryMagic==0){continue;}
				

				BR.BaseStream.Seek(tr,SeekOrigin.Begin);
				tempshit=findbyid(BR.ReadInt32());
				if (tempshit==-1){continue;}
		
				BR.BaseStream.Seek(meta.Offset[tempshit]+68,SeekOrigin.Begin);
				tempcou=BR.ReadInt32();
				tempref=BR.ReadInt32()-map.secondaryMagic;


				BR.BaseStream.Seek(tempref + 4,SeekOrigin.Begin);
				width=BR.ReadUInt16();
				height=BR.ReadUInt16();
				depth=BR.ReadUInt16();
				type=BR.ReadUInt16();
				format=BR.ReadUInt16();
						

				BR.BaseStream.Seek(tempref + 28,SeekOrigin.Begin);
				tempint=BR.ReadInt32();
				test=new	byte[4];
				crap=new BitArray(new int[] {tempint});
				oi=""; 
				for	(yy=31;yy>29;yy--)
				{
					if (crap[yy].ToString()=="False"){oi=oi+"0";} 
					else {oi=oi+"1";}
					crap[yy]=false;
				}
				crap.CopyTo(test,0);
				rawoffset=BitConverter.ToInt32(test,0);
				BR.BaseStream.Seek(tempref + 52,SeekOrigin.Begin);
				rawsize=BR.ReadInt32();
				path=openmap.FileName.Substring(0,openmap.FileName.LastIndexOf("\\"));
				if (oi=="00"){path=openmap.FileName;}
				if (oi=="01"){path=path+"\\"+"mainmenu.map";}
				if (oi=="10"){path=path+"\\"+"shared.map";}
				if (oi=="11"){path=path+"\\"+"single_player_shared.map";}
				
				
	
				FSX=new FileStream(path,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
				BRX=new BinaryReader(FSX);
				BRX.BaseStream.Seek(rawoffset,SeekOrigin.Begin);
				fuck=BRX.ReadBytes(rawsize);
				BRX.Close();
				FSX.Close();
				bsp.shaders1[r].b2=lll.DecodeBitmx(fuck,0,0,height,width,format,-1);







			}
	
			BR.Close();
			FS.Close();

			int	tempc=bsp.Model1Count[tag];
			int	b,x;


	

			// bsp model 1
			
			bsp.FixedIndices=new short[bsp.Model1Count[tag]][];
			bsp.Model1TotalIndiceCount=0;
			bsp.Model1TotalVertCount=0;
			bsp.Texture1=new int[bsp.Model1Count[tag]][];
			bsp.StartOfIndices1=new	int[bsp.Model1Count[tag]][];
			bsp.EndOfIndices1=new int[bsp.Model1Count[tag]][];

			for	(x=0;x<tempc;x++)
			{
				float hk=((float)x/(float)tempc)*100;
				progress.Value=(int)hk;
				Application.DoEvents();
		


				BinaryReader BRX=new BinaryReader(bsp.Model1Raw[tag][x]);

				
		
				if (bsp.Model1RawChunkTotalSize[tag][x].Length==0){continue;}
				int	indicechunk=0;
				int	verticechunk=0;
				int	uvchunk=0;
				int	j;
				for	(j=0;j<bsp.Model1RawChunkCount[tag][x].Length;j++)
				{
					if (bsp.Model1RawChunkSize[tag][x][j]==2) {indicechunk=j;break;}
				}


				for	(j=0;j<bsp.Model1RawChunkCount[tag][x].Length;j++)
				{
					if (bsp.Model1RawChunkSize[tag][x][j]==0) {	verticechunk=j;uvchunk=j+1;break;}
				}
				if (verticechunk==0){return;}

				bsp.Model1RawVerticeCount[tag][x]=bsp.Model1RawChunkTotalSize[tag][x][verticechunk]/12;
		
				bsp.X[tag][x]=new float[bsp.Model1RawVerticeCount[tag][x]];
				bsp.Y[tag][x]=new float[bsp.Model1RawVerticeCount[tag][x]];
				bsp.Z[tag][x]=new float[bsp.Model1RawVerticeCount[tag][x]];
				bsp.U[tag][x]=new float[bsp.Model1RawVerticeCount[tag][x]];
				bsp.V[tag][x]=new float[bsp.Model1RawVerticeCount[tag][x]];


				bsp.Model1TotalVertCount+=bsp.Model1RawVerticeCount[tag][x];
				//open the map with	the	raw
					
				
				
				BRX.BaseStream.Seek(40,SeekOrigin.Begin);
				bsp.Model1RawIndiceCount[tag][x]=BRX.ReadUInt16();
				bsp.Model1TotalIndiceCount+=bsp.Model1RawIndiceCount[tag][x];


				BRX.BaseStream.Seek(8,SeekOrigin.Begin);
				int	infoblockcount=BRX.ReadUInt16();

				bsp.Texture1[x]=new	int[infoblockcount];
				bsp.StartOfIndices1[x]=new int[infoblockcount];
				bsp.EndOfIndices1[x]=new int[infoblockcount];

			
				int	temploc=bsp.Model1HeaderSize[tag][x];
				for	(j=0;j<infoblockcount;j++)
				{
					BRX.BaseStream.Seek(temploc+bsp.Model1RawChunkOffset[tag][x][0]+4+(j*72),SeekOrigin.Begin);

					bsp.Texture1[x][j]=BRX.ReadUInt16();
					bsp.StartOfIndices1[x][j]=BRX.ReadUInt16();
					bsp.EndOfIndices1[x][j]=BRX.ReadUInt16();
				}



				//indice shit
				bsp.Model1Indices[tag][x]=new short[bsp.Model1RawIndiceCount[tag][x]];
		
				
				BRX.BaseStream.Seek(temploc+bsp.Model1RawChunkOffset[tag][x][indicechunk],SeekOrigin.Begin);
				for	(j=0;j<bsp.Model1RawIndiceCount[tag][x];j++)
				{
					bsp.Model1Indices[tag][x][j]=BRX.ReadInt16();
				}






			
				int	vertchunksize=12;
				int	vertloc=temploc+bsp.Model1RawChunkOffset[tag][x][verticechunk];
				for	(j=0;j<bsp.Model1RawVerticeCount[tag][x];j++)
				{
					BRX.BaseStream.Seek(vertloc+(j*vertchunksize),SeekOrigin.Begin);
					bsp.X[tag][x][j]=BRX.ReadSingle();//DecompressVertice(Convert.ToSingle(BRX.ReadInt16()),-1,1);
					bsp.Y[tag][x][j]=BRX.ReadSingle();//DecompressVertice(Convert.ToSingle(BRX.ReadInt16()),-1,1);
					bsp.Z[tag][x][j]=BRX.ReadSingle();//DecompressVertice(Convert.ToSingle(BRX.ReadInt16()),-1,1);
				}

				int	uvloc=temploc+bsp.Model1RawChunkOffset[tag][x][uvchunk];
				for	(j=0;j<bsp.Model1RawVerticeCount[tag][x];j++)
				{
					BRX.BaseStream.Seek(uvloc+(j*8),SeekOrigin.Begin);
					bsp.U[tag][x][j]=BRX.ReadSingle();
					if (bsp.U[tag][x][j]>1){bsp.U[tag][x][j]=bsp.U[tag][x][j]-1;}
					bsp.V[tag][x][j]=BRX.ReadSingle();
					if (bsp.V[tag][x][j]>1){bsp.V[tag][x][j]=bsp.V[tag][x][j]-1;}
				}


					
			
			}

		}

		public float DecompressVertice(float input,	float min, float max)
		{
			float percent =	(input + 32768)/65535;
			float result= (percent * (max -	min)) +	min;
			return result;
		}
				
		public float CompressVertice(float input, float	min, float max)
		{
			float result = input-min;
			result=(result / (max -	min));
			result =result*65535;
			result = result- 32768;
			return result;
		}

		public void	GetModelData(int tag)
		{
			FileStream FS=new FileStream(openmap.FileName,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
			BR=new BinaryReader(FS);
			BR.BaseStream.Seek(meta.Offset[tag]+36,SeekOrigin.Begin);
			int	tempcount=BR.ReadInt32();
			int	tempreflex=BR.ReadInt32()-map.secondaryMagic;

			mode.RawCount=tempcount;
			mode.RawOffset=new int[mode.RawCount];
			mode.ExternalMap=new int[mode.RawCount];
			mode.LocationOfRawPointer=new int[mode.RawCount];
			mode.RawSize=new int[mode.RawCount];
			mode.RawData=new MemoryStream[mode.RawCount];

		
			int	x;
			for	(x=0;x<mode.RawCount;x++)
			{
				BR.BaseStream.Seek(tempreflex+(x*92)+56,SeekOrigin.Begin);
				mode.LocationOfRawPointer[x]=tempreflex-meta.Offset[tag]+(x*92)+56;
				mode.RawOffset[x]=BR.ReadInt32();
				byte[] test=new	byte[4];
				BitArray crap=new BitArray(new int[] {mode.RawOffset[x]});
				string oi=""; int y;
				for	(y=31;y>29;y--)
				{
					if (crap[y].ToString()=="False"){oi=oi+"0";} 
					else {oi=oi+"1";}
					crap[y]=false;
				}
				crap.CopyTo(test,0);
				mode.RawOffset[x]=BitConverter.ToInt32(test,0);
				string path=openmap.FileName.Substring(0,openmap.FileName.LastIndexOf("\\"));
				if (oi=="00"){mode.ExternalMap[x]=0;path=openmap.FileName;}
				if (oi=="01"){mode.ExternalMap[x]=1;path=path+"\\"+"mainmenu.map";}
				if (oi=="10"){mode.ExternalMap[x]=2;path=path+"\\"+"shared.map";}
				if (oi=="11"){mode.ExternalMap[x]=3;path=path+"\\"+"single_player_shared.map";}
				mode.RawSize[x]=BR.ReadInt32();
				FileStream FS2=new FileStream(path,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
				BinaryReader BR2=new BinaryReader(FS2);
				mode.RawData[x]=new	MemoryStream(mode.RawSize[x]);
				BR2.BaseStream.Seek(mode.RawOffset[x],SeekOrigin.Begin);
				mode.RawData[x].Write(BR2.ReadBytes(mode.RawSize[x]),0,mode.RawSize[x]);
				BR2.Close();
				FS2.Close();
			}




			BR.BaseStream.Seek(meta.Offset[tag]+116,SeekOrigin.Begin);
			tempcount=BR.ReadInt32();
			tempreflex=BR.ReadInt32()-map.secondaryMagic;

			mode.RawCount2=tempcount;
			if (mode.RawCount2==0) {goto end;}
			mode.RawOffset2=new int[mode.RawCount2];
			mode.ExternalMap2=new int[mode.RawCount2];
			mode.LocationOfRawPointer2=new int[mode.RawCount2];
			mode.RawSize2=new int[mode.RawCount2];
			mode.RawData2=new MemoryStream[mode.RawCount2];

		
			
			for	(x=0;x<mode.RawCount2;x++)
			{
				BR.BaseStream.Seek(tempreflex+(x*88)+52,SeekOrigin.Begin);
				mode.LocationOfRawPointer2[x]=tempreflex-meta.Offset[tag]+(x*92)+52;
				mode.RawOffset2[x]=BR.ReadInt32();
				byte[] test=new	byte[4];
				BitArray crap=new BitArray(new int[] {mode.RawOffset2[x]});
				string oi=""; int y;
				for	(y=31;y>29;y--)
				{
					if (crap[y].ToString()=="False"){oi=oi+"0";} 
					else {oi=oi+"1";}
					crap[y]=false;
				}
				crap.CopyTo(test,0);
				mode.RawOffset2[x]=BitConverter.ToInt32(test,0);
				string path=openmap.FileName.Substring(0,openmap.FileName.LastIndexOf("\\"));
				if (oi=="00"){mode.ExternalMap2[x]=0;path=openmap.FileName;}
				if (oi=="01"){mode.ExternalMap2[x]=1;path=path+"\\"+"mainmenu.map";}
				if (oi=="10"){mode.ExternalMap2[x]=2;path=path+"\\"+"shared.map";}
				if (oi=="11"){mode.ExternalMap2[x]=3;path=path+"\\"+"single_player_shared.map";}
				mode.RawSize2[x]=BR.ReadInt32();
				FileStream FS2=new FileStream(path,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
				BinaryReader BR2=new BinaryReader(FS2);
				mode.RawData2[x]=new	MemoryStream(mode.RawSize2[x]);
				BR2.BaseStream.Seek(mode.RawOffset2[x],SeekOrigin.Begin);
				mode.RawData2[x].Write(BR2.ReadBytes(mode.RawSize2[x]),0,mode.RawSize2[x]);
				BR2.Close();
				FS2.Close();
			}







end:
			BR.Close();
			FS.Close();


		
		}
		private	void GetPRTMData(int tag)
		{
			FileStream FS=new FileStream(openmap.FileName,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
			BinaryReader BR=new	BinaryReader(FS);
			BR.BaseStream.Seek(meta.Offset[tag]+36,SeekOrigin.Begin);
			prtm.RawOffset=new int();
			prtm.ExternalMap=new int();
			prtm.LocationOfRawPointer=new int();
			prtm.RawSize=new int();
			BR.Close();
			FS.Close();

		
			FS=new FileStream(openmap.FileName,FileMode.Open,FileAccess.ReadWrite,FileShare.ReadWrite);
			BR=new BinaryReader(FS);
			BR.BaseStream.Seek(meta.Offset[tag]+160,SeekOrigin.Begin);
			prtm.LocationOfRawPointer=160;
			prtm.RawOffset=BR.ReadInt32();
			byte[] test=new	byte[4];
			BitArray crap=new BitArray(new int[] {prtm.RawOffset});
			string oi=""; int y;
			for	(y=31;y>29;y--)
			{
				if (crap[y].ToString()=="False"){oi=oi+"0";} 
				else {oi=oi+"1";}
				crap[y]=false;
			}
			crap.CopyTo(test,0);
			prtm.RawOffset=BitConverter.ToInt32(test,0);
			if (oi=="00"){prtm.ExternalMap=0;}
			if (oi=="01"){prtm.ExternalMap=1;}
			if (oi=="10"){prtm.ExternalMap=2;}
			if (oi=="11"){prtm.ExternalMap=3;}
			prtm.RawSize=BR.ReadInt32();
			BR.Close();
			FS.Close();
			string path=openmap.FileName.Substring(0,openmap.FileName.LastIndexOf("\\"));
			if (prtm.ExternalMap==0) {path=openmap.FileName;}
			if (prtm.ExternalMap==1) {path=path+"\\"+"mainmenu.map";}
			if (prtm.ExternalMap==2) {path=path+"\\"+"shared.map";}
			if (prtm.ExternalMap==3) {path=path+"\\"+"single_player_shared.map";}
			FS=new FileStream(path,FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
			BR=new BinaryReader(FS);
			BR.BaseStream.Seek(prtm.RawOffset,SeekOrigin.Begin);
			prtm.RawData=BR.ReadBytes(prtm.RawSize);
			BR.Close();
			FS.Close();
		
		}

		private	void GetDECRData(int tag)
		{
			FileStream FS=new FileStream(openmap.FileName,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
			BinaryReader BR=new	BinaryReader(FS);
			BR.BaseStream.Seek(meta.Offset[tag]+36,SeekOrigin.Begin);
			decr.RawOffset=new int();
			decr.ExternalMap=new int();
			decr.LocationOfRawPointer=new int();
			decr.RawSize=new int();
			BR.Close();
			FS.Close();

		
			FS=new FileStream(openmap.FileName,FileMode.Open,FileAccess.ReadWrite,FileShare.ReadWrite);
			BR=new BinaryReader(FS);
			BR.BaseStream.Seek(meta.Offset[tag]+56,SeekOrigin.Begin);
			decr.LocationOfRawPointer=56;
			decr.RawOffset=BR.ReadInt32();
			byte[] test=new	byte[4];
			BitArray crap=new BitArray(new int[] {decr.RawOffset});
			string oi=""; int y;
			for	(y=31;y>29;y--)
			{
				if (crap[y].ToString()=="False"){oi=oi+"0";} 
				else {oi=oi+"1";}
				crap[y]=false;
			}
			crap.CopyTo(test,0);
			decr.RawOffset=BitConverter.ToInt32(test,0);
			if (oi=="00"){decr.ExternalMap=0;}
			if (oi=="01"){decr.ExternalMap=1;}
			if (oi=="10"){decr.ExternalMap=2;}
			if (oi=="11"){decr.ExternalMap=3;}
			decr.RawSize=BR.ReadInt32();
			BR.Close();
			FS.Close();
			string path=openmap.FileName.Substring(0,openmap.FileName.LastIndexOf("\\"));
			if (decr.ExternalMap==0) {path=openmap.FileName;}
			if (decr.ExternalMap==1) {path=path+"\\"+"mainmenu.map";}
			if (decr.ExternalMap==2) {path=path+"\\"+"shared.map";}
			if (decr.ExternalMap==3) {path=path+"\\"+"single_player_shared.map";}
			FS=new FileStream(path,FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
			BR=new BinaryReader(FS);
			BR.BaseStream.Seek(decr.RawOffset,SeekOrigin.Begin);
			decr.RawData=BR.ReadBytes(decr.RawSize);
			BR.Close();
			FS.Close();
		
		}

		private	void GetJmadData(int tag)
		{
			FileStream FS=new FileStream(openmap.FileName,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
			BinaryReader BR=new	BinaryReader(FS);
			BR.BaseStream.Seek(meta.Offset[tag]+172,SeekOrigin.Begin);
			jmad.RawCount=BR.ReadInt32();
			int	tempreflex=BR.ReadInt32()-map.secondaryMagic;

			jmad.RawOffset=new int[jmad.RawCount];
			jmad.ExternalMap=new int[jmad.RawCount];
			jmad.LocationOfRawPointer=new int[jmad.RawCount];
			jmad.RawSize=new int[jmad.RawCount];
			jmad.RawData=new byte[jmad.RawCount][];

		

			int	x;
			for	(x=0;x<jmad.RawCount;x++)
			{
			
				BR.BaseStream.Seek(tempreflex +	(20	* x) + 4,SeekOrigin.Begin);
				jmad.RawSize[x]=BR.ReadInt32();
				jmad.LocationOfRawPointer[x]=tempreflex-meta.Offset[tag]+(20 * x) +	8;
				jmad.RawOffset[x]=BR.ReadInt32();
				byte[] test=new	byte[4];
				BitArray crap=new BitArray(new int[] {jmad.RawOffset[x]});
				string oi=""; int y;
				for	(y=31;y>29;y--)
				{
					if (crap[y].ToString()=="False"){oi=oi+"0";} 
					else {oi=oi+"1";}
					crap[y]=false;
				}
				crap.CopyTo(test,0);
				jmad.RawOffset[x]=BitConverter.ToInt32(test,0);
				if (oi=="00"){jmad.ExternalMap[x]=0;}
				if (oi=="01"){jmad.ExternalMap[x]=1;}
				if (oi=="10"){jmad.ExternalMap[x]=2;}
				if (oi=="11"){jmad.ExternalMap[x]=3;}
		
				BR.Close();
				FS.Close();
				string path=openmap.FileName.Substring(0,openmap.FileName.LastIndexOf("\\"));
				if (jmad.ExternalMap[x]==0)	{path=openmap.FileName;}
				if (jmad.ExternalMap[x]==1)	{path=path+"\\"+"mainmenu.map";}
				if (jmad.ExternalMap[x]==2)	{path=path+"\\"+"shared.map";}
				if (jmad.ExternalMap[x]==3)	{path=path+"\\"+"single_player_shared.map";}
				FileStream FSX=new FileStream(path,FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
				BinaryReader BRX=new BinaryReader(FS);
				BRX.BaseStream.Seek(jmad.RawOffset[x],SeekOrigin.Begin);
				jmad.RawData[x]=BRX.ReadBytes(jmad.RawSize[x]);
				BRX.Close();
				FSX.Close();
			}
			BR.Close();
			FS.Close();
		}





		private	void GetSndData(int tag)
		{
			FileStream FS=new FileStream(openmap.FileName,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
			BinaryReader BR=new	BinaryReader(FS);

			BR.BaseStream.Seek(meta.Offset[tag]+8,SeekOrigin.Begin);
			snd.mainindex=(int)BR.ReadInt16();
			snd.mainindexcount=(int)BR.ReadByte();


			snd.LocationOfRawPointer=new int[100];
			snd.RawData=new byte[100][];
			snd.RawOffset=new int[100];
			snd.RawSize=new int[100];
			snd.ExternalMap=new int[100];
		
			snd.index4=new int[snd.mainindexcount];
			snd.index4count=new int[snd.mainindexcount];
			snd.chunk4=new byte[snd.mainindexcount*12];


			snd.index5=new int[snd.mainindexcount][];
			snd.index5count=new int[snd.mainindexcount][];
			snd.chunk5=new byte[snd.mainindexcount][];


			BR.BaseStream.Seek(meta.Offset[map.metaCount-1]+snd.locationofchunk4+(snd.mainindex*12),SeekOrigin.Begin);
			snd.chunk4=BR.ReadBytes(snd.mainindexcount*12);
			int tempcount=0;
			for (int r=0;r<snd.mainindexcount;r++)
			{
			BR.BaseStream.Seek(meta.Offset[map.metaCount-1]+snd.locationofchunk4+((snd.mainindex+r)*12)+8,SeekOrigin.Begin);
			snd.index4[r]=(int)BR.ReadInt16();
			snd.index4count[r]=(int)BR.ReadByte();


			snd.index5[r]=new int[snd.index4count[r]];
			snd.index5count[r]=new int[snd.index4count[r]];
			snd.chunk5[r]=new byte[snd.index4count[r]*16];
			BR.BaseStream.Seek(meta.Offset[map.metaCount-1]+snd.locationofchunk5+(snd.index4[r]*16),SeekOrigin.Begin);
			snd.chunk5[r]=BR.ReadBytes(snd.index4count[r]*16);

			
			for (int rr=0;rr<snd.index4count[r];rr++)
			{
				BR.BaseStream.Seek(meta.Offset[map.metaCount-1]+snd.locationofchunk5+((snd.index4[r]+rr)*16)+12,SeekOrigin.Begin);
				snd.index5[r][rr]=(int)BR.ReadInt16();
				snd.index5count[r][rr]=(int)BR.ReadByte();
				for (int rrr=0;rrr<snd.index5count[r][rr];rrr++)
				{
					BR.BaseStream.Seek(meta.Offset[map.metaCount-1]+snd.locationofrawdatapointers+((snd.index5[r][rr]+rrr)*12),SeekOrigin.Begin);
					snd.LocationOfRawPointer[tempcount]=snd.locationofrawdatapointers+((snd.index5[r][rr]+rrr)*12);
					snd.RawOffset[tempcount]=BR.ReadInt32();
				snd.RawSize[tempcount]=(int)BR.ReadUInt16();
					byte[] test=new	byte[4];
					BitArray crap=new BitArray(new int[] {snd.RawOffset[tempcount]});
					string oi=""; int y;
					for	(y=31;y>29;y--)
					{
						if (crap[y].ToString()=="False"){oi=oi+"0";} 
						else {oi=oi+"1";}
						crap[y]=false;
					}
					crap.CopyTo(test,0);
					snd.RawOffset[tempcount]=BitConverter.ToInt32(test,0);
					
					if (oi=="00"){snd.ExternalMap[tempcount]=0;}
					if (oi=="01"){snd.ExternalMap[tempcount]=1;}
					if (oi=="10"){snd.ExternalMap[tempcount]=2;}
					if (oi=="11"){snd.ExternalMap[tempcount]=3;}
		
			
					string path=openmap.FileName.Substring(0,openmap.FileName.LastIndexOf("\\"));
					if (snd.ExternalMap[tempcount]==0)	{path=openmap.FileName;}
					if (snd.ExternalMap[tempcount]==1)	{path=path+"\\"+"mainmenu.map";}
					if (snd.ExternalMap[tempcount]==2)	{path=path+"\\"+"shared.map";}
					if (snd.ExternalMap[tempcount]==3)	{path=path+"\\"+"single_player_shared.map";}
					FileStream FSX=new FileStream(path,FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
					BinaryReader BRX=new BinaryReader(FSX);
					BRX.BaseStream.Seek(snd.RawOffset[tempcount],SeekOrigin.Begin);
					snd.RawData[tempcount]=BRX.ReadBytes(snd.RawSize[tempcount]);
					BRX.Close();
					FSX.Close();


	
				

					tempcount++;
				}

			}

			}

			snd.RawCount=tempcount;
			

			BR.Close();
			FS.Close();
		
		}









		private	void GetPhmoData(int tag)
		{
			//MessageBox.Show(meta.TagType[tag-1]+"-"+meta.Names[tag-1]);
			int	shit=meta.Offset[tag];
			string shitty=shit.ToString("X");
			char[] crap=shitty.ToCharArray();
			phmo.endsin[tag]=crap[crap.Length-1];
		
		}

		private	void GetspasData(int tag)
		{
			//MessageBox.Show(meta.TagType[tag-1]+"-"+meta.Names[tag-1]);
			int	shit=meta.Offset[tag];
			string shitty=shit.ToString("X");
			char[] crap=shitty.ToCharArray();
			spas.endsin[tag]=crap[crap.Length-1];
		
		}
	
		private	void GetCollData(int tag)
		{
			//MessageBox.Show(meta.TagType[tag-1]+"-"+meta.Names[tag-1]);
			int	shit=meta.Offset[tag];
			string shitty=shit.ToString("X");
			char[] crap=shitty.ToCharArray();
			coll.endsin[tag]=crap[crap.Length-1];
		
		}

		private	void parsebitm(int tag)
		{

			FileStream FS=new FileStream(openmap.FileName,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
			BinaryReader BR=new	BinaryReader(FS);
			bitm.name=meta.Names[tag];
			BR.BaseStream.Seek(meta.Offset[tag]+68,SeekOrigin.Begin);
			int	tempcount=BR.ReadInt32();
			int	tempreflex=BR.ReadInt32()-map.secondaryMagic;

			bitm.width=new ushort[tempcount];
			bitm.height=new	ushort[tempcount];
			bitm.depth=new ushort[tempcount];
			bitm.type=new ushort[tempcount];
			bitm.format=new	ushort[tempcount];
			bitm.flags=new ushort[tempcount];
			bitm.regPointX=new ushort[tempcount];
			bitm.regPointY=new ushort[tempcount];
			bitm.mipMapCount=new ushort[tempcount];
			
			bitm.pixelOffset=new ushort[tempcount];
	
			

			int	x;
			for	(x=0;x<tempcount;x++)
			{
				BR.BaseStream.Seek(tempreflex+(x*116)+4,SeekOrigin.Begin);
				
				bitm.width[x]=BR.ReadUInt16();
				bitm.height[x]=BR.ReadUInt16();
				bitm.depth[x]=BR.ReadUInt16();
				bitm.type[x]=BR.ReadUInt16();
				bitm.format[x]=BR.ReadUInt16();
				bitm.flags[x]=BR.ReadUInt16();
				bitm.regPointX[x]=BR.ReadUInt16();
				bitm.regPointY[x]=BR.ReadUInt16();
				bitm.mipMapCount[x]=BR.ReadUInt16();
				bitm.pixelOffset[x]=BR.ReadUInt16();
			}
			BR.Close();
			FS.Close();
		}

		private	void GetBitmData(int tag)
		{
			FileStream FS=new FileStream(openmap.FileName,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
			BinaryReader BR=new	BinaryReader(FS);
			bitm.tag=tag;
			BR.BaseStream.Seek(meta.Offset[tag]+68,SeekOrigin.Begin);
			bitm.RawCount=BR.ReadInt32();
			int	tempreflex=BR.ReadInt32()-map.secondaryMagic;

			bitm.RawOffset=new int[1000];
			bitm.ExternalMap=new int[1000];
			bitm.LocationOfRawPointer=new int[1000];
			bitm.RawSize=new int[1000];
			bitm.RawData=new byte[bitm.RawCount][][];

		

			bitm.subMapCount=new ushort[bitm.RawCount];
			int	tempcount=0;
			int	x;
			
		
			int curfsx=0;
			for	(x=0;x<bitm.RawCount;x++)
			{

				bitm.RawData[x]=new	byte[6][];
				int	y;
				for	(y=0;y<6;y++)
				{
				
					
					

					BR.BaseStream.Seek(tempreflex +	(116 * x) +	28 + (y*4),SeekOrigin.Begin);
					int	tempint=BR.ReadInt32();
					if (tempint==-1){bitm.subMapCount[x]=(ushort)y;break;}
					bitm.LocationOfRawPointer[tempcount]=tempreflex-meta.Offset[tag]+(116 *	x) + 28	+ (y*4);
					bitm.RawOffset[tempcount]=tempint;
					functions.ParseRawPointer(ref bitm.RawOffset[tempcount],ref bitm.ExternalMap[tempcount]);
					

					BR.BaseStream.Seek(tempreflex +	(116 * x) +	52 + (y*4),SeekOrigin.Begin);
					bitm.RawSize[tempcount]=BR.ReadInt32();
					
				
					
				
					
					
					if (bitm.ExternalMap[tempcount]!=0)
					{
						string path=openmap.FileName.Substring(0,openmap.FileName.LastIndexOf("\\"));
						if (bitm.ExternalMap[tempcount]==1)	{path=path+"\\"+"mainmenu.map";}
						if (bitm.ExternalMap[tempcount]==2)	{path=path+"\\"+"shared.map";}
						if (bitm.ExternalMap[tempcount]==3)	{path=path+"\\"+"single_player_shared.map";}
						FileStream FSX=new FileStream(path,FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
						BinaryReader BRX=new BinaryReader(FSX);
						BRX.BaseStream.Seek(bitm.RawOffset[tempcount],SeekOrigin.Begin);
						bitm.RawData[x][y]=BRX.ReadBytes(bitm.RawSize[tempcount]);
						BRX.Close();
						FSX.Close();
					}
					else
					{
						BR.BaseStream.Seek(bitm.RawOffset[tempcount],SeekOrigin.Begin);
						bitm.RawData[x][y]=BR.ReadBytes(bitm.RawSize[tempcount]);
					}
					tempcount++;
				}
			}
			bitm.RawCount=tempcount;
			
			BR.Close();
			FS.Close();
		}

		private	bool InsertMeta(string path,int	offset,int withpaddingsize)
		{
			FileStream FS=new FileStream(path,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
			BinaryReader BR=new	BinaryReader(FS);
			BR.BaseStream.Position=4;
			int	sizeofx	=BR.ReadInt32();
			BR.BaseStream.Position=8;
			byte[] tempmeta=BR.ReadBytes(sizeofx);
			int	metasize=sizeofx;
			BR.Close();
			FS.Close();

		
			if (metasize>withpaddingsize &&	withpaddingsize	!= -1) {return false;}
			byte[] pad=new byte[0];
			int	padsize=new	int();
			if (withpaddingsize	!= -1) 
			{
				padsize=withpaddingsize-metasize;
				pad=new	byte[padsize];
			}

			FS=new FileStream(openmap.FileName,FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
			BinaryWriter BW=new	BinaryWriter(FS);			
			BW.BaseStream.Seek(offset,SeekOrigin.Begin);
			BW.BaseStream.Write(tempmeta,0,metasize);
			if (withpaddingsize	!= -1) {BW.BaseStream.Write(pad,0,padsize);}
			
		
			FileStream FSX=new FileStream(path+".data",FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
			StreamReader SR=new	StreamReader(FSX);	
			string yoop=SR.ReadLine();
			string [] splitx = yoop.Split(new Char [] {'|'}); 
			string metatype=splitx[0];
			string metaname=splitx[1];
			string poop="";
			do
			{
				poop=SR.ReadLine();
				if (poop==null){break;}
				string [] Split	= poop.Split(new Char [] {'|'}); 
				if (Split[0]=="DepReference")
				{
					int	loc=Convert.ToInt32(Split[1]);
					int	j;
					int	replacement=-1;

					for	(j=0;j<map.metaCount;j++)
					{
						if (meta.TagType[j]==Split[2] && meta.Names[j]==Split[3])
						{
							BW.BaseStream.Seek(offset+loc,SeekOrigin.Begin);
							BW.Write(meta.Ident[j]);
							break;
						}
						if (meta.TagType[j]==Split[2])// &&	meta.TagType[j]!="snd!"	&& meta.TagType[j]!="lsnd")
						{
							replacement=meta.Ident[j];
						}

						if (j==map.metaCount-1)
						{
							if (Split[2]=="snd!"){replacement=-1;}
							BW.BaseStream.Seek(offset+loc,SeekOrigin.Begin);
							BW.Write(replacement);
							break;
						}
					}
				}


				if (Split[0]=="LoneReference")
				{
					int	loc=Convert.ToInt32(Split[1]);
					int	j;
					int	replacement=-1;

					for	(j=0;j<map.metaCount;j++)
					{
						if (meta.TagType[j]==Split[2] && meta.Names[j]==Split[3])
						{
							BW.BaseStream.Seek(offset+loc,SeekOrigin.Begin);
							BW.Write(meta.Ident[j]);
							break;
						}
						if (meta.TagType[j]==Split[2])// &&	meta.TagType[j]!="snd!"	&& meta.TagType[j]!="lsnd")
						{
							replacement=meta.Ident[j];
						}

						if (j==map.metaCount-1)
						{
							BW.BaseStream.Seek(offset+loc,SeekOrigin.Begin);
							BW.Write(replacement);
							break;
						}
					}
				}

				if (Split[0]=="Reflexive")
				{
					int	loc=Convert.ToInt32(Split[1]);
					int	j=Convert.ToInt32(Split[2])+offset+map.secondaryMagic;
					int	j2=Convert.ToInt32(Split[3]);
					BW.BaseStream.Seek(offset+loc,SeekOrigin.Begin);
					BW.Write(j2);
					BW.Write(j);
				}

				if (Split[0]=="String")
				{
					int	loc=Convert.ToInt32(Split[1]);
					int	j;
					for	(j=0;j<map.scriptReferenceCount;j++)
					{
						if (items.Names[j]==Split[2])
						{
							short h=Convert.ToInt16(j);
							BW.BaseStream.Seek(offset+loc,SeekOrigin.Begin);
							BW.Write(h);
							break;
						}
						if (j==map.scriptReferenceCount-1)
						{
							short h=Convert.ToInt16(1);
							byte h1=0;
							byte h2=7;
							BW.BaseStream.Seek(offset+loc,SeekOrigin.Begin);
							BW.Write(h);
							BW.Write(h1);
							BW.Write(h2);
							break;
						}
					}
			
				}
			} while	(poop!=null);
			SR.Close();
			FSX.Close();
			BW.Close();
			FS.Close();
			return true;
		}

		private	void menuItem3_Click(object	sender,	System.EventArgs e)
		{
			int	size=map.filesize-2048;
			int	times=size/4;
			int	result=0;
			int	x;
			FileStream FS=new FileStream(openmap.FileName,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
			BinaryReader BR=new	BinaryReader(FS);
			BinaryWriter BW=new	BinaryWriter(FS);
			BR.BaseStream.Seek(2048,SeekOrigin.Begin);
			for	(x=0;x<times;x++)
			{
				result=result^BR.ReadInt32();
			}
			BW.BaseStream.Seek(720,SeekOrigin.Begin);
			BW.Write(result);
			BR.Close();
			FS.Close();
			mapstuff.sig.Text=result.ToString("X");
			MessageBox.Show("Done");
		}

		private	void button1_Click(object sender, System.EventArgs e)
		{
			if (metashitwindow.recursive.Checked==false)
			{
				if (openmeta.ShowDialog()==DialogResult.Cancel){return;}
				bool toobig=InsertMeta(openmeta.FileName,meta.Offset[meta.SelectedMeta],meta.Size[meta.SelectedMeta]);
				if (toobig==false) { MessageBox.Show("The meta you are injecting over is not big enough	for	the	meta you are injecting.");return;}
				//	if (meta.TagType[meta.SelectedMeta]=="sbsp") { scan(openmap.FileName,meta.Offset[meta.SelectedMeta],meta.Size[meta.SelectedMeta],-1,false,false,Array.IndexOf(bsp.tag,meta.SelectedMeta));}
				//	else {scan(openmap.FileName,meta.Offset[meta.SelectedMeta],meta.Size[meta.SelectedMeta],-1,false,false,-1);}
				//	if (meta.TagType[meta.SelectedMeta]=="stem") { scan(openmap.FileName,meta.Offset[meta.SelectedMeta],meta.Size[meta.SelectedMeta],-1,true,false,-1);}
				
				scanraw(meta.SelectedMeta);
				show(true,meta.SelectedMeta);
				MessageBox.Show("Done");
			}
			else
			{
				addtomap2();
				MessageBox.Show("Done");
			}
		}

		private	void menuItem3_Click_1(object sender, System.EventArgs e)
		{
			if (folder.ShowDialog()==DialogResult.Cancel){return;}
			int	x;
			for	(x=0;x<map.metaCount;x++)
			{
				int	y=x	/ ((map.metaCount -	1) / 100);
				if (y>100){y=100;}
				progress.Value = y;

				Application.DoEvents();
				//if (meta.TagType[x]=="sbsp") { scan(openmap.FileName,meta.Offset[x],meta.Size[x],-1,false,false,Array.IndexOf(bsp.tag,x));}
				//else {scan(openmap.FileName,meta.Offset[x],meta.Size[x],-1,false,false,-1);}
				//if (meta.TagType[x]=="stem") { scan(openmap.FileName,meta.Offset[x],meta.Size[x],-1,true,false,-1);}
				
				scanraw(x);
				savemeta(x,false,folder.SelectedPath);
			}
			MessageBox.Show("Done");
		}

		private	void addtomap_Click(object sender, System.EventArgs	e)
		{
	
			
		}







	


		

		public	void addtomap2()
		{
	
		
			//show dialog
			if (folder.ShowDialog()	== DialogResult.Cancel){return;}

			int	ughnamelength= meta.Names[map.metaCount-1].Length +	1;

			//padding stuff
			int	oldpad=0;
			int	newpad=0;

	



			////containers for dependencies,reflexives,etc for imported meta
			Reflexive[] ireflex=new Reflexive[25000];
			StringsX[] istrings=new StringsX[25000];
			Dependency[] idep=new Dependency[25000];
			LoneID[] ilone=new	LoneID[25000];

			bool parsedon=false;
			if (metashitwindow.parseit.Checked==true) {parsedon=true; metashitwindow.parseit.Checked=false;}

			//recursively find files
			importfiles.FileOrder=new string[25000];
			importfiles.count =	0;
			recursivenamelist= new string[25000];
			recursivecount=0;


			//reads in file names
			FileStream FSL=new FileStream(folder.SelectedPath+"\\info.data",FileMode.Open);
			StreamReader SRL=new StreamReader(FSL);
			string quart;
			do
			{
				quart=SRL.ReadLine();
				if (quart==null){break;}
				importfiles.FileOrder[importfiles.count]=quart;
				importfiles.count++;
			} while ( quart !=null);
			SRL.Close();
			FSL.Close();


			////scans ugh  and saves it to add again
			MemoryStream ughMeta=new MemoryStream(meta.Size[map.metaCount-1]);
			FileStream FSE=new FileStream(map.filepath,FileMode.Open);
			BinaryReader BRE=new BinaryReader(FSE);
			BRE.BaseStream.Position=meta.Offset[map.metaCount-1];
			ughMeta.Write(BRE.ReadBytes(meta.Size[map.metaCount-1]),0,meta.Size[map.metaCount-1]);
			BRE.Close();
			FSE.Close();
							
			scan(ughMeta,meta.Offset[map.metaCount-1],meta.Size[map.metaCount-1],-1,false,false,-1,false,true);
			meta.Meta=ughMeta;
			savemeta(map.metaCount-1,false,folder.SelectedPath);
			importfiles.FileOrder[importfiles.count]=meta.Names[map.metaCount-1]+"[ugh!].meta";
			importfiles.count++;
	
			int	newsrcount=0;
			string[] newitems=new string[25000];

			MemoryStream[] metas=new MemoryStream[10000];
			int[] metasize=new int[10000];
			string[] metaname=new string[10000];
			string[] metatype=new string[10000];
			int[] metaident=new	int[10000];
			char[] phmo=new	char[10000];
			char[] coll=new	char[10000];
			char[] spas=new	char[10000];
			int	x;
			
			ImportRaw[] raw= new ImportRaw[10000];
			
			
			//Raw Data

				
			importstring.Location=new int[10000];
			importstring.String=new string[10000];
	


			int crappy=0;
			int crappy2=map.filesize;
		
	
			int importmagic=0;
			int importbspoff=0;


			int soundcount=0;
			int[] soundindex=new int[1000];

			int annoying=0;
			for (int g=0;g<bsp.Model1Count[0];g++)
			{
				if (bsp.Model1Offset[0][g]>crappy)
				{
					crappy=bsp.Model1Offset[0][g];
					annoying=bsp.Model1Size[0][g];
				
					
				}
				if (bsp.Model1Offset[0][g]<crappy2)
				{
					crappy2=bsp.Model1Offset[0][g];
	
					
				}

			}
			for (int g=0;g<bsp.Model2Count[0];g++)
			{
				if (bsp.Model2Offset[0][g]>crappy)
				{
					crappy=bsp.Model2Offset[0][g];
					annoying=bsp.Model2Size[0][g];
				}
				if (bsp.Model2Offset[0][g]<crappy2)
				{
					crappy2=bsp.Model2Offset[0][g];
				}
			}
			for (int g=0;g<bsp.Model3Count[0];g++)
			{
				if (bsp.Model3Offset[0][g]>crappy)
				{
					crappy=bsp.Model3Offset[0][g];
					annoying=bsp.Model3Size[0][g];
				}
				if (bsp.Model3Offset[0][g]<crappy2)	{crappy2=bsp.Model3Offset[0][g];}
			}
			for (int g=0;g<bsp.Model4Count[0];g++)
			{
				if (bsp.Model4Offset[0][g]>crappy)
				{
					crappy=bsp.Model4Offset[0][g];
					annoying=bsp.Model4Size[0][g];
				}
				if (bsp.Model4Offset[0][g]<crappy2)
				{
					crappy2=bsp.Model4Offset[0][g];
				}
			}
			int bsprawsize=crappy+annoying-crappy2;
			bsprawsize+=functions.GetPaddingSize(bsprawsize);
	













			int	oldugh=map.metaCount-1;
			int	oldughident=meta.Ident[oldugh];




			////read in map stuff

			FileStream FSZ=new FileStream(openmap.FileName,FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
			BinaryReader BRZ=new BinaryReader(FSZ);
			BinaryWriter BWZ=new BinaryWriter(FSZ);
			int	moderaw=0;
			int	modeloc=crappy2;
			int	bitmraw=0;
			int	bitmloc=map.indexOffset;
			int	jmadraw=0;
			int	jmadloc=bsp.Offset[0];
			int	sndraw=0;
			int	sndloc=2048;
			int	decrraw=0;
			int	decrloc=modeloc+bsprawsize;
			int unicodeloc=map.filesIndex+(map.fileCount*4);
			unicodeloc+=functions.GetPaddingSize(unicodeloc);
			int bsploc=0;
			int bsprawloc=0;
			
			//int	prtmraw=0;
			//int	prtmloc=2048;


			MapMeta mapinfo=new MapMeta();

			mapinfo.RawFromBeginningofSndtoEndofModeSize=modeloc-sndloc;
			mapinfo.RawFromBeginningofSndtoEndofMode=new MemoryStream(mapinfo.RawFromBeginningofSndtoEndofModeSize);
			BRZ.BaseStream.Position=sndloc;
			mapinfo.RawFromBeginningofSndtoEndofMode.Write(BRZ.ReadBytes(mapinfo.RawFromBeginningofSndtoEndofModeSize),0,mapinfo.RawFromBeginningofSndtoEndofModeSize);


			mapinfo.RawFromBeginningofDECRtoEndofJmadSize=jmadloc-decrloc;
			mapinfo.RawFromBeginningofDECRtoEndofJmad=new MemoryStream(mapinfo.RawFromBeginningofDECRtoEndofJmadSize);
			BRZ.BaseStream.Position=decrloc;
			mapinfo.RawFromBeginningofDECRtoEndofJmad.Write(BRZ.ReadBytes(mapinfo.RawFromBeginningofDECRtoEndofJmadSize),0,mapinfo.RawFromBeginningofDECRtoEndofJmadSize);


			mapinfo.RawFromBSPSize=bsp.Size[0];
			mapinfo.RawFromBSP=new MemoryStream(mapinfo.RawFromBSPSize);
			BRZ.BaseStream.Position=bsp.Offset[0];
			mapinfo.RawFromBSP.Write(BRZ.ReadBytes(mapinfo.RawFromBSPSize),0,mapinfo.RawFromBSPSize);


			mapinfo.RawFromUnicodetoEndofBitmapSize=map.indexOffset-unicodeloc;
			mapinfo.RawFromUnicodetoEndofBitmap=new MemoryStream(mapinfo.RawFromUnicodetoEndofBitmapSize);
			BRZ.BaseStream.Position=unicodeloc;
			mapinfo.RawFromUnicodetoEndofBitmap.Write(BRZ.ReadBytes(mapinfo.RawFromUnicodetoEndofBitmapSize),0,mapinfo.RawFromUnicodetoEndofBitmapSize);

		
			mapinfo.MetaFromIndexHeaderToEndSize=map.filesize-map.indexOffset;
			mapinfo.MetaFromIndexHeaderToEnd=new MemoryStream(mapinfo.MetaFromIndexHeaderToEndSize);
			BRZ.BaseStream.Position=map.indexOffset;
			mapinfo.MetaFromIndexHeaderToEnd.Write(BRZ.ReadBytes(mapinfo.MetaFromIndexHeaderToEndSize),0,mapinfo.MetaFromIndexHeaderToEndSize);

			mapinfo.BSPRawSize=bsprawsize;
			mapinfo.BSPRaw=new MemoryStream(mapinfo.BSPRawSize);
			BRZ.BaseStream.Position=modeloc;
			mapinfo.BSPRaw.Write(BRZ.ReadBytes(mapinfo.BSPRawSize),0,mapinfo.BSPRawSize);

			
			int importbsp=-1;
			string tempname="";
			string[][] poops=new string[importfiles.count][];
			int[] poopscount=new int[importfiles.count];
			for	(x=0;x<importfiles.count;x++)
			{
				float hk=((float)x/(float)importfiles.count)*100;
				progress.Value=(int)hk;
				Application.DoEvents();

				ireflex[x]=new Reflexive();
				istrings[x]=new StringsX();
				idep[x]=new Dependency();
				ilone[x]=new LoneID();
		
				idep[x].Location=new int[25000];
				idep[x].InTag=new int[25000];
				idep[x].TagType=new string[25000];
				ireflex[x].Location=new int[25000];
				ireflex[x].Translation=new int[25000];
				ireflex[x].ChunkCount=new int[25000];
				ilone[x].Location=new int[25000];
				ilone[x].InTag=new int[25000];
				ilone[x].TagType=new string[25000];
				istrings[x].Location=new int[25000];
				istrings[x].StringNum=new int[25000];


				FileStream FS=new FileStream(folder.SelectedPath+"\\"+importfiles.FileOrder[x],FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
				BinaryReader BR=new	BinaryReader(FS);	
				int	sizeofx	= Convert.ToInt32(FS.Length);
				metas[x]=new MemoryStream(sizeofx);
				metas[x].Write(BR.ReadBytes(sizeofx),0,sizeofx);
				BR.BaseStream.Position=4;
				metasize[x]=BR.ReadInt32();
				metaident[x]=meta.Ident[map.metaCount-1] + (x *	65537);
				BR.Close();
				FS.Close();
				
				FileStream FSXX=new FileStream(folder.SelectedPath+"\\"+importfiles.FileOrder[x]+".data",FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
				StreamReader SR=new	StreamReader(FSXX);	

				string yoop=SR.ReadLine();
				string [] splitx = yoop.Split(new Char [] {'|'}); 
				metatype[x]=splitx[0];
				metaname[x]=splitx[1];
				tempname=metaname[x];
				
				bool exists=false;
				for (int u=0;u<map.metaCount-1;u++)
				{
					if (tempname==meta.Names[u]&&metatype[x]==meta.TagType[u])
					{
						exists=true;
						break;
					}
				}
				for (int u=0;u<x;u++)
				{
					if (tempname==metaname[u]&&metatype[x]==metatype[u])
					{
						exists=true;
						break;
					}
				}
				if (exists==true){tempname="Copy of "+metaname[x];}
				
				//}

				meta.Ident[(map.metaCount-1)+x]=metaident[x];
				meta.Names[(map.metaCount-1)+x]=tempname;
				meta.TagType[(map.metaCount-1)+x]=metatype[x];


				poops[x]=new string[100000];
				string poop="";
				do
				{
					poops[x][poopscount[x]]=SR.ReadLine();
					if (poops[x][poopscount[x]]==null){break;}
					poopscount[x]++;
				} while (poop!=null);

			
			

				
				SR.Close();
				FSXX.Close();



			

			}



//////ughshit
///
///
///
	


			


	







			for	(x=0;x<importfiles.count;x++)
			{

				string poop="";
				if (metatype[x]=="phmo"	&& (phmo[x]==0))
				{
					FileStream FSD=new FileStream(folder.SelectedPath+"\\"+importfiles.FileOrder[x]+".phmo",FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
					StreamReader SRD=new StreamReader(FSD);	
					char[] blehx=SRD.ReadLine().ToCharArray();
					phmo[x]=blehx[0];
							
				}

				if (metatype[x]=="spas"	&& (spas[x]==0))
				{
					FileStream FSD=new FileStream(folder.SelectedPath+"\\"+importfiles.FileOrder[x]+".spas",FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
					StreamReader SRD=new StreamReader(FSD);	
					char[] blehx=SRD.ReadLine().ToCharArray();
					spas[x]=blehx[0];
							
				}


				if (metatype[x]=="coll"	&& coll[x]==0)
				{
					FileStream FSD=new FileStream(folder.SelectedPath+"\\"+importfiles.FileOrder[x]+".coll",FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
					StreamReader SRD=new StreamReader(FSD);	
					char[] blehx=SRD.ReadLine().ToCharArray();
					coll[x]=blehx[0];
							
				}






				if (metatype[x]=="snd!")
				{
					raw[x]=new ImportRaw();
					soundindex[soundcount]=x;
					soundcount++;
					raw[x].rawloc=new int[10000];
					raw[x].rawoff=new int[10000];
					raw[x].rawsize=new int[10000];
					raw[x].rawmap=new int[10000];
					raw[x].rawpad=new int[10000];
					raw[x].sndchunk5loc=new int[1000];
					raw[x].sndchunk5size=new int[1000];

					FileStream FSX=new FileStream(folder.SelectedPath+"\\"+importfiles.FileOrder[x]+".rawd",FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
					StreamReader SRX=new StreamReader(FSX);
					SRX.ReadLine();
					poop=SRX.ReadLine();
					string [] Split	= poop.Split(new Char [] {'|'}); 
					raw[x].sndchunk4loc=Convert.ToInt32(Split[1]);
					raw[x].sndchunk4size=Convert.ToInt32(Split[2]);
					raw[x].sndchunk5count=0;
					do
					{
						poop=SRX.ReadLine();
						if (poop==null){break;}
						Split	= poop.Split(new Char [] {'|'}); 
						
						if (Split[0]=="chunk5") 
						{
							
						
							raw[x].sndchunk5loc[raw[x].sndchunk5count]=Convert.ToInt32(Split[1]);
							raw[x].sndchunk5size[raw[x].sndchunk5count]=Convert.ToInt32(Split[2]);
							raw[x].sndchunk5count++;
						}
						else
						{
									
							
							raw[x].rawloc[raw[x].rawcount]=Convert.ToInt32(Split[0]);			
							raw[x].rawoff[raw[x].rawcount]=Convert.ToInt32(Split[1]);
							raw[x].rawsize[raw[x].rawcount]=Convert.ToInt32(Split[2]);
							raw[x].rawmap[raw[x].rawcount]=Convert.ToInt32(Split[3]);
							raw[x].rawpad[raw[x].rawcount]=functions.GetPaddingSize(raw[x].rawsize[raw[x].rawcount]);
							raw[x].rawcount++;
						}
				
				
			
					
			
				
					}
					while (poop!=null);
					SRX.Close();
					FSX.Close();



				}





				if (metatype[x]=="mode")
				{
					raw[x]=new ImportRaw();
					raw[x].rawloc=new int[10000];
					raw[x].rawoff=new int[10000];
					raw[x].rawsize=new int[10000];
					raw[x].rawmap=new int[10000];
					raw[x].rawpad=new int[10000];

					FileStream FSX=new FileStream(folder.SelectedPath+"\\"+importfiles.FileOrder[x]+".rawd",FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
					StreamReader SRX=new StreamReader(FSX);
					SRX.ReadLine();
					do
					{
						poop=SRX.ReadLine();
						if (poop==null){break;}
						string [] Split	= poop.Split(new Char [] {'|'}); 
						raw[x].rawloc[raw[x].rawcount]=Convert.ToInt32(Split[0]);			
						raw[x].rawoff[raw[x].rawcount]=Convert.ToInt32(Split[1]);
						raw[x].rawsize[raw[x].rawcount]=Convert.ToInt32(Split[2]);
						raw[x].rawmap[raw[x].rawcount]=Convert.ToInt32(Split[3]);
						raw[x].rawpad[raw[x].rawcount]=functions.GetPaddingSize(raw[x].rawsize[raw[x].rawcount]);
						raw[x].rawcount++;
					}
					while (poop!=null);
					SRX.Close();
					FSX.Close();


					
			

				}







				if (metatype[x]=="jmad")
				{
					raw[x]=new ImportRaw();
					raw[x].rawloc=new int[10000];
					raw[x].rawoff=new int[10000];
					raw[x].rawsize=new int[10000];
					raw[x].rawmap=new int[10000];
					raw[x].rawpad=new int[10000];

					FileStream FSX=new FileStream(folder.SelectedPath+"\\"+importfiles.FileOrder[x]+".rawd",FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
					StreamReader SRX=new StreamReader(FSX);
					SRX.ReadLine();
				
					do
					{
						poop=SRX.ReadLine();
						if (poop==null){break;}
						string [] Split	= poop.Split(new Char [] {'|'}); 
						raw[x].rawloc[raw[x].rawcount]=Convert.ToInt32(Split[0]);			
						raw[x].rawoff[raw[x].rawcount]=Convert.ToInt32(Split[1]);
						raw[x].rawsize[raw[x].rawcount]=Convert.ToInt32(Split[2]);
						raw[x].rawmap[raw[x].rawcount]=Convert.ToInt32(Split[3]);
						raw[x].rawpad[raw[x].rawcount]=functions.GetPaddingSize(raw[x].rawsize[raw[x].rawcount]);
						raw[x].rawcount++;
						
					}
					while (poop!=null);
					SRX.Close();
					FSX.Close();


					



				
			
				}


				if (metatype[x]=="bitm")
				{
					raw[x]=new ImportRaw();
					raw[x].rawloc=new int[10000];
					raw[x].rawoff=new int[10000];
					raw[x].rawsize=new int[10000];
					raw[x].rawmap=new int[10000];
					raw[x].rawpad=new int[10000];

					FileStream FSX=new FileStream(folder.SelectedPath+"\\"+importfiles.FileOrder[x]+".rawd",FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
					StreamReader SRX=new StreamReader(FSX);
					SRX.ReadLine();
					
					do
					{
						poop=SRX.ReadLine();
						if (poop==null){break;}
						string [] Split	= poop.Split(new Char [] {'|'}); 
						raw[x].rawloc[raw[x].rawcount]=Convert.ToInt32(Split[0]);			
						raw[x].rawoff[raw[x].rawcount]=Convert.ToInt32(Split[1]);
						raw[x].rawsize[raw[x].rawcount]=Convert.ToInt32(Split[2]);
						raw[x].rawmap[raw[x].rawcount]=Convert.ToInt32(Split[3]);
						raw[x].rawpad[raw[x].rawcount]=functions.GetPaddingSize(raw[x].rawsize[raw[x].rawcount]);
						raw[x].rawcount++;
					}
					while (poop!=null);
					SRX.Close();
					FSX.Close();


				}
			




				if (metatype[x]=="sbsp")
				{
					raw[x]=new ImportRaw();
					importbsp=x;
	

					FileStream FSX=new FileStream(folder.SelectedPath+"\\"+importfiles.FileOrder[x]+".rawd",FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
					StreamReader SRX=new StreamReader(FSX);
					
					poop=SRX.ReadLine();
						string [] Split	= poop.Split(new Char [] {'|'}); 
						importmagic=Convert.ToInt32(Split[0]);
					importbspoff=Convert.ToInt32(Split[1]);
						poop=SRX.ReadLine();
						Split	= poop.Split(new Char [] {'|'}); 
					
						bsp.Model1Count[0]=Convert.ToInt32(Split[1]);
						bsp.Model1Loc[0]=new int[bsp.Model1Count[0]];
						bsp.Model1Offset[0]=new int[bsp.Model1Count[0]];
						bsp.Model1Size[0]=new int[bsp.Model1Count[0]];
						bsp.Model1Map[0]=new int[bsp.Model1Count[0]];
			//MessageBox.Show("testy");
						for (int r=0;r<bsp.Model1Count[0];r++)
						{
							poop=SRX.ReadLine();
							Split	= poop.Split(new Char [] {'|'}); 
							bsp.Model1Loc[0][r]=Convert.ToInt32(Split[0]);			
							bsp.Model1Offset[0][r]=Convert.ToInt32(Split[1]);
							bsp.Model1Size[0][r]=Convert.ToInt32(Split[2]);
							bsp.Model1Map[0][r]=Convert.ToInt32(Split[3]);
						
						}



					poop=SRX.ReadLine();
					Split	= poop.Split(new Char [] {'|'}); 
					
					bsp.Model2Count[0]=Convert.ToInt32(Split[1]);
					bsp.Model2Loc[0]=new int[bsp.Model2Count[0]];
					bsp.Model2Offset[0]=new int[bsp.Model2Count[0]];
					bsp.Model2Size[0]=new int[bsp.Model2Count[0]];
					bsp.Model2Map[0]=new int[bsp.Model2Count[0]];
						
					for (int r=0;r<bsp.Model2Count[0];r++)
					{
						poop=SRX.ReadLine();
						Split	= poop.Split(new Char [] {'|'}); 
						bsp.Model2Loc[0][r]=Convert.ToInt32(Split[0]);			
						bsp.Model2Offset[0][r]=Convert.ToInt32(Split[1]);
						bsp.Model2Size[0][r]=Convert.ToInt32(Split[2]);
						bsp.Model2Map[0][r]=Convert.ToInt32(Split[3]);
						
					}
						
			


					poop=SRX.ReadLine();
				Split	= poop.Split(new Char [] {'|'}); 
					
					bsp.Model3Count[0]=Convert.ToInt32(Split[1]);
					bsp.Model3Loc[0]=new int[bsp.Model3Count[0]];
					bsp.Model3Offset[0]=new int[bsp.Model3Count[0]];
					bsp.Model3Size[0]=new int[bsp.Model3Count[0]];
					bsp.Model3Map[0]=new int[bsp.Model3Count[0]];
						
					for (int r=0;r<bsp.Model3Count[0];r++)
					{
						poop=SRX.ReadLine();
						Split	= poop.Split(new Char [] {'|'}); 
						bsp.Model3Loc[0][r]=Convert.ToInt32(Split[0]);			
						bsp.Model3Offset[0][r]=Convert.ToInt32(Split[1]);
						bsp.Model3Size[0][r]=Convert.ToInt32(Split[2]);
						bsp.Model3Map[0][r]=Convert.ToInt32(Split[3]);
						
					}


					poop=SRX.ReadLine();
					Split	= poop.Split(new Char [] {'|'}); 
					
					bsp.Model4Count[0]=Convert.ToInt32(Split[1]);
					bsp.Model4Loc[0]=new int[bsp.Model4Count[0]];
					bsp.Model4Offset[0]=new int[bsp.Model4Count[0]];
					bsp.Model4Size[0]=new int[bsp.Model4Count[0]]; 
					bsp.Model4Map[0]=new int[bsp.Model4Count[0]];
						
					for (int r=0;r<bsp.Model4Count[0];r++)
					{
						poop=SRX.ReadLine();
						Split	= poop.Split(new Char [] {'|'}); 
						bsp.Model4Loc[0][r]=Convert.ToInt32(Split[0]);			
						bsp.Model4Offset[0][r]=Convert.ToInt32(Split[1]);
						bsp.Model4Size[0][r]=Convert.ToInt32(Split[2]);
						bsp.Model4Map[0][r]=Convert.ToInt32(Split[3]);
						
					}
					SRX.Close();
					FSX.Close();


					raw[x].sbsprawpad1=new int[bsp.Model1Count[0]];
					for	(int f=0;f<bsp.Model1Count[0];f++)
					{
					raw[x].sbsprawpad1[f]=functions.GetPaddingSize(bsp.Model1Size[0][f]);
					}


					raw[x].sbsprawpad2=new int[bsp.Model2Count[0]];
					for	(int f=0;f<bsp.Model2Count[0];f++)
					{
					raw[x].sbsprawpad2[f]=functions.GetPaddingSize(bsp.Model2Size[0][f]);
					}

					raw[x].sbsprawpad3=new int[bsp.Model3Count[0]];
					for	(int f=0;f<bsp.Model3Count[0];f++)
					{
					raw[x].sbsprawpad3[f]=functions.GetPaddingSize(bsp.Model3Size[0][f]);
					}

					raw[x].sbsprawpad4=new int[bsp.Model4Count[0]];
					for	(int f=0;f<bsp.Model4Count[0];f++)
					{
					raw[x].sbsprawpad4[f]=functions.GetPaddingSize(bsp.Model4Size[0][f]);
					}

				}

			}
	

			

			for	(x=0;x<importfiles.count;x++)
			{
				float hk=((float)x/(float)importfiles.count)*100;
				progress.Value=(int)hk;
				Application.DoEvents();


				for (int h=0;h<poopscount[x];h++)
				{
					string [] Split	= poops[x][h].Split(new Char [] {'|'}); 
	

					if (Split[0]=="String")
					{
						int	loc=Convert.ToInt32(Split[1]);
					
						int tempj=Array.IndexOf(items.Names,Split[2]);
						if (tempj==-1)
						{
							tempj=map.scriptReferenceCount+newsrcount;
							items.Names[map.scriptReferenceCount+newsrcount]=Split[2];
							newitems[newsrcount]=Split[2];
							newsrcount++;
							
							importstring.Location[importstring.Count] =	loc;
							importstring.String[importstring.Count]	= Split[2];
							importstring.Count++;
						}

					}

				}
			}

	


		





			for	(x=0;x<importfiles.count;x++)
			{
				float hk=((float)x/(float)importfiles.count)*100;
				progress.Value=(int)hk;
				Application.DoEvents();


				for (int h=0;h<poopscount[x];h++)
				{
				
					string [] Split	= poops[x][h].Split(new Char [] {'|'}); 
	
					if (Split[0]=="DepReference")
					{
						int	loc=Convert.ToInt32(Split[1]);
						int	j;
						int	replacement=-1;

						for	(j=0;j<map.metaCount-1;j++)
						{
							if (meta.TagType[j]==Split[2])
							{
								replacement=j;
								if (meta.Names[j]==Split[3])
								{
									break;
								}
							}
											
												
						}

					
						for	(j=0;j<importfiles.count;j++)
						{
							if (metatype[j]==Split[2])
							{
								
								if (metaname[j]==Split[3])
								{
									replacement=map.metaCount-1+j;
									break;
								}
								
								
							}
						}

						idep[x].Location[idep[x].Count]=loc;
						idep[x].InTag[idep[x].Count]=replacement;
						idep[x].TagType[idep[x].Count]=Split[2];
						idep[x].Count++;
						//MessageBox.Show("test");
					}


					if (Split[0]=="LoneReference")
					{
						
						int	loc=Convert.ToInt32(Split[1]);
						int	j;
						int	replacement=-1;


						for	(j=0;j<map.metaCount-1;j++)
						{
							if (meta.TagType[j]==Split[2])
							{
								replacement=j;
								if (meta.Names[j]==Split[3])
								{
									break;
								}
							}
												
						}



					
							for	(j=0;j<importfiles.count;j++)
							{
								if (metatype[j]==Split[2])
								{
								
									if (metaname[j]==Split[3])
									{
										replacement=map.metaCount-1+j;
										break;
									}
								}
								
						
						}

						ilone[x].Location[ilone[x].Count]=loc;
						ilone[x].InTag[ilone[x].Count]=replacement;
						ilone[x].TagType[ilone[x].Count]=Split[2];
						ilone[x].Count++;


					}

					if (Split[0]=="Reflexive")
					{
						int	loc=Convert.ToInt32(Split[1]);
						int	j=Convert.ToInt32(Split[2]);
						int	j2=Convert.ToInt32(Split[3]);
						ireflex[x].Location[ireflex[x].Count]=loc;
						ireflex[x].Translation[ireflex[x].Count]=j;
						ireflex[x].ChunkCount[ireflex[x].Count]=j2;
						ireflex[x].Count++;
				
					}

					if (Split[0]=="String")
					{
						int	loc=Convert.ToInt32(Split[1]);
					
					int tempj=Array.IndexOf(items.Names,Split[2]);

						istrings[x].Location[istrings[x].Count]=loc;
						istrings[x].StringNum[istrings[x].Count]=tempj;
						istrings[x].Count++;

					
			
					}
				}
			}


		
				
			int sndpad=0;
			if (soundcount!=0)
			{

				//////write the damn raw
				

				for (int q=0;q<soundcount;q++)
				{
					int w=soundindex[q];
					for (int f=0;f<raw[w].rawcount;f++)
					{
						BWZ.BaseStream.Seek(sndloc+sndraw,SeekOrigin.Begin);
						BWZ.BaseStream.Write(metas[w].ToArray(),raw[w].rawoff[f],raw[w].rawsize[f]);
						byte[] blankpadx=new byte[raw[w].rawpad[f]];
						BWZ.Write(blankpadx);
						sndraw+=raw[w].rawsize[f]+raw[w].rawpad[f];
					}
					
				}
				
				////
				///

				int last=importfiles.count-1;
				////fix ugh
			
				MemoryStream ughtemp=new MemoryStream(100000);
				BinaryReader BRD=new BinaryReader(ughMeta);
				BinaryReader BRDX=new BinaryReader(ughtemp);
				BinaryWriter BWD=new BinaryWriter(ughtemp);
				int endofchunk4=snd.locationofchunk4+(snd.totalcountofchunk4*12);
				BWD.BaseStream.Write(ughMeta.ToArray(),0,endofchunk4);
				for (int q=0;q<soundcount;q++)
				{
					int w=soundindex[q];
					//fix souund meta             
					
					BinaryWriter BWF=new BinaryWriter(metas[w]);
					BWF.BaseStream.Position=16;
					short tempshort=(short)(snd.totalcountofchunk4+q);
					BWF.Write(tempshort);
					
					//write chunk 4
					int wherex=raw[w].sndchunk4loc;
					int sizex=raw[w].sndchunk4size;
					BWD.BaseStream.Write(metas[w].ToArray(),wherex,sizex);
					sndpad+=sizex;
				}
				ireflex[last].ChunkCount[4]+=soundcount;

				int endofchunk5=snd.locationofchunk5+(snd.totalcountofchunk5*16);
				BWD.BaseStream.Write(ughMeta.ToArray(),snd.locationofchunk5,endofchunk5-snd.locationofchunk5);

			
				ireflex[last].Translation[5]+=sndpad;
		
				
				int chunk5count=0;
				int tempc=0;
				int oi=endofchunk5+sndpad;
				int tempchunk4size=0;
				for (int q=0;q<soundcount;q++)
				{
					int w=soundindex[q];
					
					for (int qq=0;qq<raw[w].sndchunk5count;qq++)
					{
						BWD.BaseStream.Seek(endofchunk4+tempchunk4size+(qq*12)+8,SeekOrigin.Begin);
						short tempindex=(short)(snd.totalcountofchunk5+chunk5count);
						BWD.Write(tempindex);
						
						


						BWD.BaseStream.Seek(oi+(chunk5count*16),SeekOrigin.Begin);
						BWD.BaseStream.Write(metas[w].ToArray(),raw[w].sndchunk5loc[qq],raw[w].sndchunk5size[qq]);
						
		

						int cc=raw[w].sndchunk5size[qq]/16;
						for (int qqq=0;qqq<cc;qqq++)
						{
							BWD.BaseStream.Position=oi+(chunk5count*16)+(qqq*16)+12;
							short jf=(short)(snd.totalcountofrawdatapointers+tempc);
							BWD.Write(jf);
							BRDX.BaseStream.Position=oi+(chunk5count*16)+(qqq*16)+14;
							int tempint=(int)BRDX.ReadByte();
							tempc+=tempint;
						}
						chunk5count+=cc;
						sndpad+=raw[w].sndchunk5size[qq];
						tempchunk4size+=raw[w].sndchunk4size;
					}
				}
				ireflex[last].ChunkCount[5]+=chunk5count;
				
				int endofrawpointchunk=snd.locationofrawdatapointers+(snd.totalcountofrawdatapointers*12);
				int endofrawpointchunk2=endofrawpointchunk-endofchunk5;
				BWD.BaseStream.Seek(endofchunk5+sndpad,SeekOrigin.Begin);
				BWD.BaseStream.Write(ughMeta.ToArray(),endofchunk5,endofrawpointchunk2);

				int fuckit=0;
				int translate9=ireflex[last].Translation[9];
				for (int q=6;q<ireflex[last].Count;q++)
				{
					
					if (ireflex[last].Location[q]<translate9){if (q>10){ireflex[last].Location[q]+=sndpad;}}
					if (ireflex[last].Translation[q]<translate9)
					{
					
						ireflex[last].Translation[q]+=sndpad;
					}
				
					
					
					
				}
				//MessageBox.Show("test");
				for (int q=0;q<snd.totalcountofrawdatapointers;q++)
				{
					BRD.BaseStream.Position=snd.locationofrawdatapointers+(q*12);
					int	tempint=BRD.ReadInt32();
					if (tempint==-1){continue;}
					
					byte[] test=new	byte[4];
					BitArray crapr=new BitArray(new int[] {tempint});
					string oix=""; int yy;
					for	(yy=31;yy>29;yy--)
					{
						if (crapr[yy].ToString()=="False"){oix=oix+"0";} 
						else {oix=oix+"1";}
						crapr[yy]=false;
					}
	

						
				
					if (oix=="00")
					{
						int	newtempraw=tempint+sndraw;
						BWD.BaseStream.Position=ireflex[last].Translation[8]+(q*12);
						BWD.Write(newtempraw);
					}
				

				}
			

				int sndraw2=0;
				int ccrap=0;
				for (int q=0;q<soundcount;q++)
				{
					int w=soundindex[q];
				
					for (int f=0;f<raw[w].rawcount;f++)
					{
						BWD.BaseStream.Position=endofrawpointchunk+sndpad+(ccrap*12);
						int fucker=sndloc+sndraw2;
						BWD.Write(fucker);		
						short fucker2=(short)raw[w].rawsize[f];
						BWD.Write(fucker2);
						short fucker3=0;
						int fucker4=-1;
						BWD.Write(fucker3);
						BWD.Write(fucker4);
						sndraw2+=raw[w].rawsize[f]+raw[w].rawpad[f];
						ccrap++;
					}
				}
				sndpad+=(ccrap*12);
				BWD.BaseStream.Position=endofrawpointchunk+sndpad;
				BWD.BaseStream.Write(ughMeta.ToArray(),endofrawpointchunk,meta.Size[map.metaCount-1]-endofrawpointchunk);
				ireflex[last].ChunkCount[8]+=ccrap;
				ireflex[last].Translation[9]+=sndpad;
				ireflex[last].Translation[10]+=sndpad;
				ireflex[last].Translation[11]+=sndpad;
				for (int q=11;q<ireflex[last].Count;q++)
				{

					if (ireflex[last].Location[q]>translate9){ireflex[last].Location[q]+=sndpad;}
					if (ireflex[last].Translation[q]>translate9)
					{
					
						ireflex[last].Translation[q]+=sndpad;
					}
					
					//ireflex[last].Location[q]+=sndpad;
			
					//ireflex[last].Translation[q]+=sndpad;
			
				}

				for (int q=0;q<ilone[last].Count;q++)
				{
					
					ilone[last].Location[q]+=sndpad;
			
					//ireflex[last].Translation[q]+=(ccrap*12);
			
				}

				//BWD.BaseStream.Position=32;
				//int kk=snd.totalcountofchunk4+soundcount;
				//BWD.Write(kk);
				

				//BWD.BaseStream.Position=40;
				//kk=snd.totalcountofchunk5+chunk5count;
				///BWD.Write(kk);

				//BWD.BaseStream.Position=64;
				//kk=snd.totalcountofrawdatapointers+ccrap;
				//BWD.Write(kk);
				metas[importfiles.count-1]=new MemoryStream(metasize[importfiles.count-1]+sndpad+8);
				metas[importfiles.count-1].Position=8;
				metas[importfiles.count-1].Write(ughtemp.ToArray(),0,metasize[importfiles.count-1]+sndpad);
				metasize[importfiles.count-1]=metasize[importfiles.count-1]+sndpad;



			



			}
			newpad+=sndraw;

		



	
			

			
			BWZ.BaseStream.Position=sndloc+sndraw;
			BWZ.BaseStream.Write(mapinfo.RawFromBeginningofSndtoEndofMode.ToArray(),0,mapinfo.RawFromBeginningofSndtoEndofModeSize);
			BWZ.BaseStream.Position=modeloc+newpad;
			
			for	(x=0;x<importfiles.count;x++)
			{
				if (metatype[x]=="mode")
				{
					int	f;
					for	(f=0;f<raw[x].rawcount;f++)
					{
						BWZ.BaseStream.Write(metas[x].ToArray(),raw[x].rawoff[f],raw[x].rawsize[f]);
						byte[] blankpadx=new byte[raw[x].rawpad[f]];
						BWZ.Write(blankpadx);
						moderaw+=raw[x].rawsize[f]+raw[x].rawpad[f];
					}

				}

			}
			newpad+=moderaw;
			BWZ.BaseStream.Position=modeloc+newpad;
			bsprawloc=modeloc+newpad;
			int[] bsp3offset=new int[bsp.Model3Count[0]];
			int bspsize=0;
			if (importbsp==-1)
			{
				BWZ.BaseStream.Write(mapinfo.BSPRaw.ToArray(),0,mapinfo.BSPRawSize);
				bspsize=mapinfo.BSPRawSize;
			}
		
			else
			{


				for (int r=0;r<bsp.Model1Count[0];r++)
				{
					BWZ.BaseStream.Write(metas[importbsp].ToArray(),bsp.Model1Offset[0][r],bsp.Model1Size[0][r]);
					byte[] blankpadx=new byte[raw[importbsp].sbsprawpad1[r]];
					BWZ.Write(blankpadx);
					bspsize+=bsp.Model1Size[0][r]+raw[importbsp].sbsprawpad1[r];
				}

				for (int r=0;r<bsp.Model2Count[0];r++)
				{
					BWZ.BaseStream.Write(metas[importbsp].ToArray(),bsp.Model2Offset[0][r],bsp.Model2Size[0][r]);
					byte[] blankpadx=new byte[raw[importbsp].sbsprawpad2[r]];
					BWZ.Write(blankpadx);
					bspsize+=bsp.Model2Size[0][r]+raw[importbsp].sbsprawpad2[r];
				}

				for (int r=0;r<bsp.Model4Count[0];r++)
				{
				
					BWZ.BaseStream.Write(metas[importbsp].ToArray(),bsp.Model4Offset[0][r],bsp.Model4Size[0][r]);
					byte[] blankpadx=new byte[raw[importbsp].sbsprawpad4[r]];
					BWZ.Write(blankpadx);
					bspsize+=bsp.Model4Size[0][r]+raw[importbsp].sbsprawpad4[r];
				}

				for (int r=0;r<bsp.Model3Count[0];r++)
				{
					int tt=Array.IndexOf(bsp.Model3Offset[0],bsp.Model3Offset[0][r]);
					if (tt==r)
					{
						
						BWZ.BaseStream.Write(metas[importbsp].ToArray(),bsp.Model3Offset[0][r],bsp.Model3Size[0][r]);
						byte[] blankpadx=new byte[raw[importbsp].sbsprawpad3[r]];
						BWZ.Write(blankpadx);
						bspsize+=bsp.Model3Size[0][r]+raw[importbsp].sbsprawpad3[r];
							
					}
				}
				
		
				oldpad+=bsprawsize;
				newpad+=bspsize;
			}

			BWZ.BaseStream.Position=modeloc-oldpad+newpad+bspsize;
			BWZ.BaseStream.Write(mapinfo.RawFromBeginningofDECRtoEndofJmad.ToArray(),0,mapinfo.RawFromBeginningofDECRtoEndofJmadSize);

			jmadloc=jmadloc-oldpad+newpad;
			BWZ.BaseStream.Position=jmadloc;
			for	(x=0;x<importfiles.count;x++)
			{
				if (metatype[x]=="jmad")
				{
	
					int	f;
					for	(f=0;f<raw[x].rawcount;f++)
					{
						BWZ.BaseStream.Write(metas[x].ToArray(),raw[x].rawoff[f],raw[x].rawsize[f]);
						byte[] blankpadx=new byte[raw[x].rawpad[f]];
						BWZ.Write(blankpadx);
						jmadraw+=raw[x].rawsize[f]+raw[x].rawpad[f];
					}

				}

			}
			newpad+=jmadraw;

	
			bsploc=jmadloc+jmadraw;
			if (importbsp!=-1)
			{
				
				oldpad+=bsp.Size[0];
				newpad+=metasize[importbsp];
				BWZ.BaseStream.Write(metas[importbsp].ToArray(),8,metasize[importbsp]);
			}
			else
			{

				BWZ.BaseStream.Write(mapinfo.RawFromBSP.ToArray(),0,mapinfo.RawFromBSPSize);
			}

		
			
	

			byte zerobyte=0;
			////sr names 
			map.srNames	+= -oldpad+newpad;
			BWZ.BaseStream.Seek(352,SeekOrigin.Begin);
			BWZ.Write(map.srNames);
		

			int oldsize=(map.scriptReferenceCount*128);
			int oldtemppad=functions.GetPaddingSize(oldsize);
			oldpad+=oldtemppad;


			BWZ.BaseStream.Position=map.srNames;
			byte[] blankstuff=new byte[(map.scriptReferenceCount +newsrcount)*128];
			BWZ.Write(blankstuff);
			
		
			for	(x=0;x<map.scriptReferenceCount+newsrcount;x++)
			{
				char[] craptt=items.Names[x].ToCharArray(0,items.Names[x].Length);
				int	loct=(x*128);
				BWZ.BaseStream.Seek(map.srNames+loct,SeekOrigin.Begin);
				BWZ.Write(craptt);
			}

			

			int temppad=functions.GetPaddingSize((int)blankstuff.Length);
			newpad+=(newsrcount*128)+temppad;
			blankstuff=new byte[temppad];
			BWZ.BaseStream.Position=map.srNames+oldsize+(newsrcount*128);
			BWZ.Write(blankstuff);
			
			
			map.offsetToScriptReferenceIndex += - oldpad +newpad;
			BWZ.BaseStream.Seek(364,SeekOrigin.Begin);
			BWZ.Write(map.offsetToScriptReferenceIndex);

			

			oldsize=(map.scriptReferenceCount*4);
			oldtemppad=functions.GetPaddingSize(oldsize);
			oldpad+=oldtemppad;

							

			int	locoftext=0;
			BWZ.BaseStream.Seek(map.offsetToScriptReferenceIndex,SeekOrigin.Begin);
			for	(x=0;x<map.scriptReferenceCount+newsrcount;x++)
			{
				BWZ.Write(locoftext);
				locoftext+=items.Names[x].Length+1;

			}
			temppad=functions.GetPaddingSize((map.scriptReferenceCount+newsrcount)*4);
			newpad+=(newsrcount*4)+temppad;
			blankstuff=new byte[temppad];
			BWZ.Write(blankstuff);




			
			///sr names
			map.offsetToScriptReferenceStrings	+= -oldpad+newpad;
			BWZ.BaseStream.Seek(368,SeekOrigin.Begin);
			BWZ.Write(map.offsetToScriptReferenceStrings);
			//if (newsrcount==0){goto	skipsrnames2;}

			oldpad += functions.GetPaddingSize(map.sizeOfScriptReference);;
			

			

			
			BWZ.BaseStream.Position=map.offsetToScriptReferenceStrings;
			

			locoftext=0;
			for	(x=0;x<map.scriptReferenceCount+newsrcount;x++)
			{
				char[] craptt=items.Names[x].ToCharArray(0,items.Names[x].Length);
				
				BWZ.Write(craptt);
				BWZ.Write(zerobyte);
				locoftext+=items.Names[x].Length+1;
			}

	
			temppad=functions.GetPaddingSize(locoftext);
			newpad += temppad + -map.sizeOfScriptReference+locoftext;
			blankstuff=new byte[temppad];
			BWZ.Write(blankstuff);

			

			
			
		


			int	xsrcount=map.scriptReferenceCount +	newsrcount;
			BWZ.BaseStream.Seek(356,SeekOrigin.Begin);
			BWZ.Write(xsrcount);
			int	xsrsize=locoftext;
			BWZ.Write(xsrsize);

		





				///meta	names
				///
				
			map.fileTableOffset	+= -oldpad+newpad;
			
			BWZ.BaseStream.Seek(708,SeekOrigin.Begin);
			BWZ.Write(map.fileTableOffset);
			
	
			oldpad += functions.GetPaddingSize(map.fileTableSize);
			
					
			BWZ.BaseStream.Seek(map.fileTableOffset,SeekOrigin.Begin);
			int	metatextloc=0;
			for	(x=0;x<map.metaCount-1+importfiles.count;x++)
			{
				char[] craptt=meta.Names[x].ToCharArray(0,meta.Names[x].Length);
			
				BWZ.Write(craptt);
				BWZ.Write(zerobyte);
				metatextloc+=meta.Names[x].Length+1;
			}

	
			temppad=functions.GetPaddingSize(metatextloc);
			newpad += temppad -map.fileTableSize+metatextloc;
			blankstuff=new byte[temppad];
			BWZ.Write(blankstuff);
			

			
			
			//files	index
			map.filesIndex +=  -oldpad +newpad;
			BWZ.BaseStream.Seek(716,SeekOrigin.Begin);
			BWZ.Write(map.filesIndex);

		

			oldpad += functions.GetPaddingSize((map.fileCount * 4));
			
	
	
			
	
			BWZ.BaseStream.Seek(map.filesIndex,SeekOrigin.Begin);
			int	locxxx=0;
			for	(x=0;x<map.metaCount-1+importfiles.count;x++)
			{
			
				
				BWZ.Write(locxxx);
				locxxx+=meta.Names[x].Length+1;

			}

			temppad=functions.GetPaddingSize((map.fileCount-1+importfiles.count)*4);
			newpad += temppad +(importfiles.count*4)-4;
			blankstuff=new byte[temppad];
			BWZ.Write(blankstuff);
			BWZ.BaseStream.Write(mapinfo.RawFromUnicodetoEndofBitmap.ToArray(),0,mapinfo.RawFromUnicodetoEndofBitmapSize);
			

			//bitm raw

			bitmloc=map.indexOffset	-oldpad	+ newpad;
			//MessageBox.Show("test");
			
	BWZ.BaseStream.Position=bitmloc;

			for	(x=0;x<importfiles.count;x++)
			{
				if (metatype[x]=="bitm")
				{

					int	f;
					for	(f=0;f<raw[x].rawcount;f++)
					{

						BWZ.BaseStream.Seek(bitmloc+bitmraw,SeekOrigin.Begin);
						BWZ.BaseStream.Write(metas[x].ToArray(),raw[x].rawoff[f],raw[x].rawsize[f]);
						byte[] blankpadx=new byte[raw[x].rawpad[f]];
						BWZ.Write(blankpadx);
						bitmraw+=raw[x].rawsize[f]+raw[x].rawpad[f];
					}

				}

			}

			newpad+=bitmraw;
			BWZ.BaseStream.Write(mapinfo.MetaFromIndexHeaderToEnd.ToArray(),0,mapinfo.MetaFromIndexHeaderToEndSize);
			



		
		
			map.indexOffset+= -oldpad +	newpad;
			BWZ.BaseStream.Seek(16,SeekOrigin.Begin);
			BWZ.Write(map.indexOffset);




		

			int	oit=map.metaCount+importfiles.count-1;
			BWZ.BaseStream.Seek(map.indexOffset+24,SeekOrigin.Begin);
			BWZ.Write(oit);

			oit=map.fileCount+importfiles.count-1;
			BWZ.BaseStream.Seek(704,SeekOrigin.Begin);
			BWZ.Write(oit);

			oit=locxxx;
			BWZ.BaseStream.Seek(712,SeekOrigin.Begin);
			BWZ.Write(oit);

			map.tagsOffset+=-oldpad	+ newpad;

			BRZ.BaseStream.Seek(map.tagsOffset + 8,	SeekOrigin.Begin);
			map.secondaryMagic = BRZ.ReadInt32() - (map.indexOffset	+ map.metaStart);

			int bspshit=0;
			for	(x=0;x<bsp.Magic.Length;x++)
			{
				int wtf=bsp.offloc[x]-oldpad+newpad;
			
				int	temppointer=bsploc;
				BWZ.BaseStream.Seek(wtf,SeekOrigin.Begin);
				BWZ.Write(temppointer);
				if (importbsp!=-1)
				{
					BWZ.Write(metasize[importbsp]);
//bsp.Magic[x] = BR.ReadInt32() -	bsp.Offset[x];
					int fucky=importbspoff+importmagic;
					BWZ.Write(fucky);
					BWZ.BaseStream.Seek(bsp.offloc[x]-oldpad+newpad+20,SeekOrigin.Begin);
					BWZ.Write(metaident[importbsp]);
					//MessageBox.Show("test");

				}
				
				int	n;
				for	(n=0;n<bsp.Model1Count[0];n++)
				{
			
					temppointer=bsprawloc+bspshit;
				

					BWZ.BaseStream.Seek(bsploc+bsp.Model1Loc[x][n],SeekOrigin.Begin);
					BWZ.Write(temppointer);
					BWZ.Write(bsp.Model1Size[0][n]);
				
					bspshit+=bsp.Model1Size[0][n]+functions.GetPaddingSize(bsp.Model1Size[0][n]);
				
				}

				for	(n=0;n<bsp.Model2Count[0];n++)
				{
					temppointer=bsprawloc+bspshit;

					BWZ.BaseStream.Seek(bsploc+bsp.Model2Loc[x][n],SeekOrigin.Begin);
					BWZ.Write(temppointer);
					BWZ.Write(bsp.Model2Size[0][n]);
					bspshit+=bsp.Model2Size[0][n]+functions.GetPaddingSize(bsp.Model2Size[0][n]);
				
				}


				for	(n=0;n<bsp.Model4Count[0];n++)
				{
					temppointer=bsprawloc+bspshit;
					BWZ.BaseStream.Seek(bsploc+bsp.Model4Loc[x][n],SeekOrigin.Begin);
					BWZ.Write(temppointer);
					BWZ.Write(bsp.Model4Size[0][n]);
					bspshit+=bsp.Model4Size[0][n]+functions.GetPaddingSize(bsp.Model4Size[0][n]);
				
				}

				bsp3offset=new int[10000];
				for	(n=0;n<bsp.Model3Count[0];n++)
				{

						





						int tt=Array.IndexOf(bsp.Model3Offset[x],bsp.Model3Offset[x][n]);
						if (tt==n)
						{

							temppointer=bsprawloc+bspshit;
							bspshit+=bsp.Model3Size[0][n]+functions.GetPaddingSize(bsp.Model3Size[0][n]);
							bsp3offset[tt]=temppointer;
							
				
						}
						else
						{
							temppointer=bsp3offset[tt];
						}
				
						BWZ.BaseStream.Seek(bsploc+bsp.Model3Loc[x][n],SeekOrigin.Begin);
						BWZ.Write(temppointer);
						BWZ.Write(bsp.Model3Size[0][n]);
				
				}

	
			}


			for	(x=0;x<map.metaCount-1;x++)
			{
				float hk=((float)x/(float)map.metaCount)*100;
				progress.Value=(int)hk;
				Application.DoEvents();
				if (meta.TagType[x]=="bitm")
				{
					meta.Offset[x]+=-oldpad+newpad;
					

					BRZ.BaseStream.Seek(meta.Offset[x]+68,SeekOrigin.Begin);
					int tempcount=BRZ.ReadInt32();
					int	tempreflex=BRZ.ReadInt32()-map.secondaryMagic;

		
			
		
					for	(int ex=0;ex<tempcount;ex++)
					{

						for	(int ey=0;ey<6;ey++)
						{
				
							BRZ.BaseStream.Seek(tempreflex +	(116 * ex) +	28 + (ey*4),SeekOrigin.Begin);
							int	tempint=BRZ.ReadInt32();
							if (tempint==-1){break;}
							
							byte[] test=new	byte[4];
							BitArray crapr=new BitArray(new int[] {tempint});
							string oi=""; int yy;
							for	(yy=31;yy>29;yy--)
							{
								if (crapr[yy].ToString()=="False"){oi=oi+"0";} 
								else {oi=oi+"1";}
								crapr[yy]=false;
							}
	

						
				
							if (oi=="00")
							{
								int	newtempraw=tempint-oldpad+newpad-bitmraw;
								BWZ.BaseStream.Seek(tempreflex +	(116 * ex) +	28 + (ey*4),SeekOrigin.Begin);
								BWZ.Write(newtempraw);
							}
						}
					}


					//GetBitmData(x);
					//int	j;
					//for	(j=0;j<bitm.RawCount;j++)
					//{
					//	if (bitm.ExternalMap[j]==0)
					//	{
					//		int	newtempraw=bitm.RawOffset[j]-oldpad+newpad-bitmraw;
					//		BWZ.BaseStream.Seek(meta.Offset[x]+bitm.LocationOfRawPointer[j],SeekOrigin.Begin);
					//		BWZ.Write(newtempraw);
					//	}
					//}
				}
				if (meta.TagType[x]=="jmad")
				{
					meta.Offset[x]+=-oldpad+newpad;
					BRZ.BaseStream.Seek(meta.Offset[x]+172,SeekOrigin.Begin);
					int tempcount=BRZ.ReadInt32();
					int	tempreflex=BRZ.ReadInt32()-map.secondaryMagic;

			
		
					for	(int ex=0;ex<tempcount;ex++)
					{

						
				
						BRZ.BaseStream.Seek(tempreflex +	(20 * ex) +	8,SeekOrigin.Begin);
						int	tempint=BRZ.ReadInt32();
						if (tempint==-1){break;}
							
						byte[] test=new	byte[4];
						BitArray crapr=new BitArray(new int[] {tempint});
						string oi=""; int yy;
						for	(yy=31;yy>29;yy--)
						{
							if (crapr[yy].ToString()=="False"){oi=oi+"0";} 
							else {oi=oi+"1";}
							crapr[yy]=false;
						}
	

						
				
						if (oi=="00")
						{
							int	newtempraw=tempint+moderaw+sndraw;
							if (importbsp!=-1){newtempraw+=-bsprawsize+bspsize;}

							BWZ.BaseStream.Seek(tempreflex +	(20 * ex) +	8,SeekOrigin.Begin);
							BWZ.Write(newtempraw);
						}
					}

					
				}



				if (meta.TagType[x]=="mode")
				{
					meta.Offset[x]+=-oldpad+newpad;
					BRZ.BaseStream.Seek(meta.Offset[x]+36,SeekOrigin.Begin);
					int tempcount=BRZ.ReadInt32();
					int	tempreflex=BRZ.ReadInt32()-map.secondaryMagic;

			
		
					for	(int ex=0;ex<tempcount;ex++)
					{

						
				
						BRZ.BaseStream.Seek(tempreflex +	(92 * ex) +	56,SeekOrigin.Begin);
						int	tempint=BRZ.ReadInt32();
						if (tempint==-1){break;}
							
						byte[] test=new	byte[4];
						BitArray crapr=new BitArray(new int[] {tempint});
						string oi=""; int yy;
						for	(yy=31;yy>29;yy--)
						{
							if (crapr[yy].ToString()=="False"){oi=oi+"0";} 
							else {oi=oi+"1";}
							crapr[yy]=false;
						}
	

						
				
						if (oi=="00")
						{
							int	newtempraw=tempint+sndraw;
							

							BWZ.BaseStream.Seek(tempreflex +	(92 * ex) +	56,SeekOrigin.Begin);
							BWZ.Write(newtempraw);
						}
					
					}
					
				}



				if (meta.TagType[x]=="DECR")
				{
					meta.Offset[x]+=-oldpad+newpad;
					GetDECRData(x);
					if (decr.ExternalMap==0)
					{
						int	newtempraw=decr.RawOffset+moderaw+sndraw;
						if (importbsp!=-1){newtempraw+=-bsprawsize+bspsize;}
						BWZ.BaseStream.Seek(meta.Offset[x]+decr.LocationOfRawPointer,SeekOrigin.Begin);
						BWZ.Write(newtempraw);
					}
				}
				
				if (meta.TagType[x]=="PRTM")
				{
					meta.Offset[x]+=-oldpad+newpad;
					GetPRTMData(x);
					if (prtm.ExternalMap==0)
					{
	
						int	newtempraw=prtm.RawOffset+moderaw+sndraw;
						if (importbsp!=-1){newtempraw+=-bsprawsize+bspsize;}
						BWZ.BaseStream.Seek(meta.Offset[x]+prtm.LocationOfRawPointer,SeekOrigin.Begin);
						BWZ.Write(newtempraw);
					}
				}
		
		
			}



			
			map.scriptReferenceCount+=newsrcount;
			map.metaCount+=importfiles.count-1;
		
			int	howfar=0;
			int	modefar=0;
			int	jmadfar=0;
			int	bitmfar=0;
			for	(x=0;x<importfiles.count;x++)
			{
				float hk=((float)x/(float)importfiles.count)*100;
				progress.Value=(int)hk;
				Application.DoEvents();

				char[] poo=metatype[x].ToCharArray();
				Array.Reverse(poo);
				int	identx=metaident[x];
				int	ioff=meta.Offset[oldugh]+howfar-oldpad+newpad;

				if (metatype[x]=="phmo")
				{

					int	oldioff=ioff;
							
					do
					{
					
						string cracka2=ioff.ToString("X");
						char[] shithead=cracka2.ToCharArray();
						int	whynot=shithead.Length;
						
						if (shithead[whynot-1]==phmo[x]) { break; }
						ioff++;
					} while	(phmo[x]!='z');
						


					int	padofpainintheass=ioff-oldioff;
					byte[] shitblankarray=new byte[padofpainintheass];
					BWZ.BaseStream.Seek(oldioff,SeekOrigin.Begin);
					BWZ.Write(shitblankarray);
					howfar+=padofpainintheass;
				}





				if (metatype[x]=="spas")
				{

					int	oldioff=ioff;
							
					do
					{
					
						string cracka2=ioff.ToString("X");
						char[] shithead=cracka2.ToCharArray();
						int	whynot=shithead.Length;
						
						if (shithead[whynot-1]==spas[x]) { break; }
						ioff++;
					} while	(spas[x]!='z');
						


					int	padofpainintheass=ioff-oldioff;
					byte[] shitblankarray=new byte[padofpainintheass];
					BWZ.BaseStream.Seek(oldioff,SeekOrigin.Begin);
					BWZ.Write(shitblankarray);
					howfar+=padofpainintheass;
				}






				







				if (metatype[x]=="coll")
				{

					int	oldioff=ioff;
							
					do
					{
					
						string cracka2=ioff.ToString("X");
						char[] shithead=cracka2.ToCharArray();
						int	whynot=shithead.Length;
						
						if (shithead[whynot-1]==coll[x]) { break; }
						ioff++;
					} while	(coll[x]!='z');
						


					int	padofpainintheass=ioff-oldioff;
					byte[] shitblankarray=new byte[padofpainintheass];
					BWZ.BaseStream.Seek(oldioff,SeekOrigin.Begin);
					BWZ.Write(shitblankarray);
					howfar+=padofpainintheass;
				}





				int	ioffx=ioff+map.secondaryMagic;
				int	isize=metasize[x];
				BWZ.BaseStream.Seek(map.tagsOffset+(oldugh*16)+(x*16),SeekOrigin.Begin);
				BWZ.Write(poo);
				BWZ.Write(identx);
				if (importbsp!=x)
				{
					BWZ.Write(ioffx);
					BWZ.Write(isize);
				}
				else
				{
					BWZ.Write((int)0);
					BWZ.Write((int)0);
				}
				//InsertMeta(folder.SelectedPath+"\\"+importfiles.FileOrder[x],ioff,-1);





				if (metatype[x]!="sbsp")
				{
					BWZ.BaseStream.Seek(ioff,SeekOrigin.Begin);
					
					BWZ.BaseStream.Write(metas[x].ToArray(),8,metasize[x]);
				}
				else
				{
					ioff=jmadloc+jmadraw;

				}
				

		
		
				for (int f=0;f<idep[x].Count;f++)
				{
	
							BWZ.BaseStream.Seek(ioff+idep[x].Location[f],SeekOrigin.Begin);
							int dien=idep[x].InTag[f];
							if (dien!=-1){dien=	meta.Ident[dien];}
							BWZ.Write(dien);
			
				}


				for (int f=0;f<ilone[x].Count;f++)
				{
	
					BWZ.BaseStream.Seek(ioff+ilone[x].Location[f],SeekOrigin.Begin);
					int dien=ilone[x].InTag[f];
					if (dien!=-1){dien=	meta.Ident[dien];}
					BWZ.Write(dien);
				}


				if (x!=importbsp)
				{
						
			
				
					for (int f=0;f<ireflex[x].Count;f++)
					{
	
						BWZ.BaseStream.Seek(ioff+ireflex[x].Location[f],SeekOrigin.Begin);
						int	jj;
						jj=ioff+ireflex[x].Translation[f]+map.secondaryMagic;
				
						BWZ.Write(ireflex[x].ChunkCount[f]);
						BWZ.Write(jj);
		
					}

				}
				for (int f=0;f<istrings[x].Count;f++)
				{
	
					BWZ.BaseStream.Seek(ioff+istrings[x].Location[f],SeekOrigin.Begin);
					short r1=(short)istrings[x].StringNum[f];
					byte r2=0;
					byte r3=(byte)items.Names[r1].Length ;
					BWZ.Write(r1);
					BWZ.Write(r2);
					BWZ.Write(r3);
				}

















				if (metatype[x]=="mode")
				{
					int	f;
					for	(f=0;f<raw[x].rawcount;f++)
					{
		
						int	temprawoff=modeloc+modefar+sndraw;
						BWZ.BaseStream.Seek(ioff+raw[x].rawloc[f],SeekOrigin.Begin);
						BWZ.Write(temprawoff);
						modefar+=raw[x].rawsize[f]+raw[x].rawpad[f];

					}
				}
								

				if (metatype[x]=="jmad")
				{
					int	f;
					for	(f=0;f<raw[x].rawcount;f++)
					{
		
						int	temprawoff=jmadloc+jmadfar;
						BWZ.BaseStream.Seek(ioff+raw[x].rawloc[f],SeekOrigin.Begin);
						BWZ.Write(temprawoff);
						jmadfar+=raw[x].rawsize[f]+raw[x].rawpad[f];
					}
				}

				if (metatype[x]=="bitm")
				{
					int	f;
					for	(f=0;f<raw[x].rawcount;f++)
					{
		
						int	temprawoff=bitmloc+bitmfar;
						BWZ.BaseStream.Seek(ioff+raw[x].rawloc[f],SeekOrigin.Begin);
						BWZ.Write(temprawoff);
						bitmfar+=raw[x].rawsize[f]+raw[x].rawpad[f];

					}
				}

		
				if (metatype[x]!="sbsp")
				{
					howfar+=isize;
				}
			}

			int	locofshit=meta.Offset[0]-oldpad+newpad;

	
			for	(x=0;x<9;x++)
			{
				BRZ.BaseStream.Seek(locofshit +	392	+ (x * 28) + 16, SeekOrigin.Begin);
				int	crapy =	BRZ.ReadInt32()	- oldpad + newpad-bitmraw;
				BWZ.BaseStream.Seek(locofshit +	392	+ (x * 28) + 16, SeekOrigin.Begin);
				BWZ.Write(crapy);

				BRZ.BaseStream.Seek(locofshit +	392	+ (x * 28) + 20, SeekOrigin.Begin);
				crapy =	BRZ.ReadInt32()	- oldpad + newpad-bitmraw;
				BWZ.BaseStream.Seek(locofshit +	392	+ (x * 28) + 20, SeekOrigin.Begin);
				BWZ.Write(crapy);
			}
			
		 
			int	sizeofshit=meta.Size[0]/4;
			BRZ.BaseStream.Seek(locofshit,SeekOrigin.Begin);
			for	(x=0;x<sizeofshit;x++)
			{
				int	hhh=BRZ.ReadInt32();
				if (hhh==oldughident)
				{
					hhh=metaident[importfiles.count-1];
					BWZ.BaseStream.Seek(locofshit+(x*4),SeekOrigin.Begin);
					BWZ.Write(hhh);
					BRZ.BaseStream.Seek(locofshit+((x+1)*4),SeekOrigin.Begin);
				}
			}
			

			int crapx =	map.offsetToStrangeFileStrings	- oldpad + newpad-bitmraw;
			BWZ.BaseStream.Seek(344, SeekOrigin.Begin);
			BWZ.Write(crapx);


			int oldsizex=map.filesize;
			int oldpadx=functions.GetPaddingSize(oldsizex);
			int oldtotalsizex=oldsizex+oldpadx;

			int	newsizex = (int)FSZ.Length;
			int newpaddingx=functions.GetPaddingSize(newsizex);
			int newtotalsizex=newsizex+newpaddingx;


			int totaladded=newtotalsizex-oldtotalsizex;

			BWZ.BaseStream.Position=newsizex;
			byte[] endpad=new byte[newpaddingx];
			BWZ.BaseStream.Seek(Convert.ToInt32(FSZ.Length),SeekOrigin.Begin);
			BWZ.Write(endpad);
		
			crapx =	map.filesize + totaladded;
			BWZ.BaseStream.Seek(8, SeekOrigin.Begin);
			BWZ.Write(crapx);
			crapx =	map.metaSize + totaladded;
			BWZ.BaseStream.Seek(24,	SeekOrigin.Begin);
			BWZ.Write(crapx);
			crapx =	map.combinedSize + totaladded;
			BWZ.BaseStream.Seek(28,	SeekOrigin.Begin);
			BWZ.Write(crapx);
		

		
			BWZ.Close();
			FSZ.Close();
			FileInfo shit=new FileInfo(importfiles.FileOrder[importfiles.count-1]);
			shit.Delete();
			shit=new FileInfo(importfiles.FileOrder[importfiles.count-1]+".data");
			shit.Delete();
			if (parsedon==true)	{metashitwindow.parseit.Checked=true;}
			loadmap();
			//MessageBox.Show("Done");
		}
















		

		public int findbyoffset(int	offset)
		{
			int	result=-1;
			int	x;
			for	(x=0;x<map.metaCount;x++)
			{
				if (offset>=meta.Offset[x] && offset<(meta.Offset[x]+meta.Size[x]))
				{
					result=x;
					break;
				}

			}
			return result;
		}

		public	void parsemeta(int tag,int startofchunk,int	rloc,int starttag)
		{
		





			int	x;
			if (startofchunk==-1)
			{
				parsed.meta=new byte[10000][];
				parsed.refsloc=new int[10000][];
				parsed.refstrans=new int[10000][];
				parsed.refstag=new int[10000];
				parsed.refscount=new int[10000];
				parsed.refsintag=new int[10000][];
				parsed.newreflexoldtag=new int[100000];
				parsed.newreflexoldtrans=new int[100000];
				parsed.newreflextrans=new int[100000];
				parsed.newreflexloc=new	int[100000];
				parsed.metachunknum=new int[100000];
				parsed.newreflexcount=0;
				parsed.refstagmeta=new byte[10000][];
				parsed.pos=0;
				parsed.count=0;
				FileStream FS=new FileStream(openmap.FileName,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
				BR=new	BinaryReader(FS);	
				BR.BaseStream.Seek(meta.Offset[tag],SeekOrigin.Begin);
				parsed.meta[parsed.count]=BR.ReadBytes(meta.Size[tag]);
				parsed.count++;
				parsed.pos+=meta.Size[tag];

		
					
				meta.Meta=new MemoryStream(meta.Size[starttag]);
				BR.BaseStream.Position=meta.Offset[starttag];
				meta.Meta.Write(BR.ReadBytes(meta.Size[starttag]),0,meta.Size[starttag]);
				BR.Close();
				FS.Close();

				level=0;
				scan(meta.Meta,meta.Offset[starttag],meta.Size[starttag],-1,false,true,-1,false,false);
				parsed.refsloc[level]=reflex.Location;
				parsed.refstrans[level]=reflex.Translation;
				parsed.refsintag[level]=reflex.InTag;
				parsed.refstag[level]=starttag;
				parsed.refscount[level]=reflex.Count;
				parsed.refstagmeta[level]=meta.Meta.GetBuffer();
				level++;

				for	(x=0;x<parsed.refscount[0];x++)
				{
					
					if (parsed.refsintag[0][x]!=starttag)
					{
							
						parsemeta(parsed.refsintag[0][x],parsed.refstrans[0][x],parsed.refsloc[0][x],starttag);
						continue;

					}
				}
			return;
			}

			
				



			int ore=Array.IndexOf(parsed.refstag,tag);
		//	MessageBox.Show("teast");
			if (ore==-1)
			{
				
				
				FileStream FS=new FileStream(openmap.FileName,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
				BinaryReader BR=new	BinaryReader(FS);	
				meta.Meta=new MemoryStream(meta.Size[tag]);
				BR.BaseStream.Position=meta.Offset[tag];
				meta.Meta.Write(BR.ReadBytes(meta.Size[tag]),0,meta.Size[tag]);
				BR.Close();
				FS.Close();
				scan(meta.Meta,meta.Offset[tag],meta.Size[tag],-1,false,true,-1,false,false);
				parsed.refsloc[level]=reflex.Location;
				parsed.refstrans[level]=reflex.Translation;
				parsed.refsintag[level]=reflex.InTag;
				parsed.refstagmeta[level]=meta.Meta.GetBuffer();
				parsed.refstag[level]=tag;	
				parsed.refscount[level]=reflex.Count;
				ore=level;
				level++;
			
			}







			//	if (meta.TagType[tag]=="ugh!"){MessageBox.Show("Test");}
			
			


			int	ug=0;
			int	endofchunk=meta.Size[tag];
			for	(x=0;x<parsed.refscount[ore];x++)
			{
				if (parsed.refstrans[ore][x]>startofchunk	&& parsed.refstrans[ore][x]<endofchunk &&	parsed.refsintag[ore][x]==tag)
				{
					endofchunk=parsed.refstrans[ore][x];
					ug=x;
				}
			}

			int	sizeofchunk=endofchunk-startofchunk;
			
			if (sizeofchunk>10000)
			{
				//if (meta.TagType[tag]=="ugh!") {MessageBox.Show("test");}
				parsed.newreflexloc[parsed.newreflexcount]=rloc;
				parsed.newreflextrans[parsed.newreflexcount]=-1;
				parsed.newreflexoldtrans[parsed.newreflexcount]=-1;
				parsed.newreflexoldtag[parsed.newreflexcount]=-1;
				parsed.newreflexcount++;
			
				
			}
			else
			{
				for (int e=0;e<parsed.newreflexcount;e++)
				{
					if (parsed.newreflexoldtrans[e]==startofchunk&&parsed.newreflexoldtag[e]==tag)
					{
						parsed.newreflexloc[parsed.newreflexcount]=rloc;			
						parsed.newreflextrans[parsed.newreflexcount]=parsed.newreflextrans[e];
						parsed.newreflexoldtrans[parsed.newreflexcount]=parsed.newreflexoldtrans[e];
						parsed.newreflexoldtag[parsed.newreflexcount]=parsed.newreflexoldtag[e];
						parsed.metachunknum[parsed.newreflexcount]=parsed.metachunknum[e];
						parsed.newreflexcount++;
						
						return;
					}
				}

				parsed.newreflexloc[parsed.newreflexcount]=rloc;
				parsed.newreflextrans[parsed.newreflexcount]=parsed.pos;
				parsed.newreflexoldtrans[parsed.newreflexcount]=startofchunk;
				parsed.newreflexoldtag[parsed.newreflexcount]=tag;
				parsed.metachunknum[parsed.newreflexcount]=parsed.count;
				parsed.newreflexcount++;
			
				parsed.meta[parsed.count]=new byte[sizeofchunk];

				Array.Copy(parsed.refstagmeta[ore],startofchunk,parsed.meta[parsed.count],0,sizeofchunk);
				parsed.count++;
				parsed.pos+=sizeofchunk;
				
		

				//MessageBox.Show(meta.Names[tag].ToString());
	
				int poot=parsed.pos;
				for	(x=0;x<parsed.refscount[ore];x++)
				{

					if (parsed.refsloc[ore][x]>=startofchunk && parsed.refsloc[ore][x]<=endofchunk)
					{
											
						parsemeta(parsed.refsintag[ore][x],parsed.refstrans[ore][x],(poot-sizeofchunk)+(parsed.refsloc[ore][x]-startofchunk),starttag);
					}
				}
			
			}

		}

		private	void menuItem4_Click(object	sender,	System.EventArgs e)
		{
			FileStream FS=new FileStream("shit.txt",FileMode.Create	,FileAccess.ReadWrite,FileShare.ReadWrite);
			StreamWriter SW=new	StreamWriter(FS);
			int	x;
			int	y;
			for	(x=0;x<bsp.Magic.Length;x++)
			{
				SW.WriteLine("model1");
				for	(y=0;y<bsp.Model1Offset[x].Length;y++)
				{
					SW.WriteLine(bsp.Model1Offset[x][y].ToString()+"|"+bsp.Model1Size[x][y].ToString());
				}
				SW.WriteLine("model2");
				for	(y=0;y<bsp.Model2Offset[x].Length;y++)
				{
					SW.WriteLine(bsp.Model2Offset[x][y].ToString()+"|"+bsp.Model2Size[x][y].ToString());
				}
				SW.WriteLine("model3");
				for	(y=0;y<bsp.Model3Offset[x].Length;y++)
				{
					SW.WriteLine(bsp.Model3Offset[x][y].ToString()+"|"+bsp.Model3Size[x][y].ToString());
				}
				SW.WriteLine("model4");
				for	(y=0;y<bsp.Model4Offset[x].Length;y++)
				{
					SW.WriteLine(bsp.Model4Offset[x][y].ToString()+"|"+bsp.Model4Size[x][y].ToString());
				}
			}
			SW.Close();
			FS.Close();
		}

		private	void menuItem5_Click(object	sender,	System.EventArgs e)
		{
		
			Form1 oi=this;
			ut.SetOldForm(ref oi);
			ut.SetMeta(ref meta);
			ut.SetItems(ref	items);
			ut.SetMap(ref map);
			ut.ShowDialog();
			
		
		}
		public void	SetReflex()
		{
						
			ut.SetReflex(ref reflex);
		}

		public	void typeschanged()
		{
			deptree.names.Items.Clear();
			deptree.names.Sorted=false;
			string crap=deptree.types.Text;
			int	x;

			for	(x=0;x<map.metaCount;x++)
			{
				if (meta.TagType[x]==crap)
				{
					deptree.names.Items.Add(meta.Names[x]);
				}
			}
			deptree.names.Sorted=true;
			deptree.names.Sorted=false;
			deptree.names.Items.Add("Nulled Out");
		}

		public	void treeView2_AfterSelect()
		{
			
			TreeNode mattsmells=deptree.treeView2.SelectedNode.Parent;
			if (mattsmells!=null)
			{
				string parenttext=mattsmells.Text;

				if (parenttext=="Strings")
				{
					int	crap=deptree.treeView2.SelectedNode.Index;
					string shit=items.Names[strings.StringNum[crap]];
					short oix=Convert.ToInt16(Array.IndexOf(items.Names,shit));
					if (oix==-1){return;}
					deptree.sr.SelectedIndex=oix;
				}

				if (parenttext=="Lone ID's")
				{
					int	crap=deptree.treeView2.SelectedNode.Index;
					int	xxx=lone.InTag[crap];
					int	oi=deptree.types.FindString(meta.TagType[xxx]);
					deptree.types.SelectedIndex=oi;
					oi=deptree.names.FindString(meta.Names[xxx]);
					deptree.names.SelectedIndex=oi;
				}

				if (parenttext=="Dependencies")
				{
					int	crap=deptree.treeView2.SelectedNode.Index;
					int	xxx=dep.InTag[crap];
					int	oi=deptree.types.FindString(dep.TagType[crap]);
					deptree.types.SelectedIndex=oi;
					Application.DoEvents();
					string searchname;
					if (dep.InTag[crap]!=-1)
					{
						searchname=meta.Names[xxx];
					}
					else
					{
						searchname="Nulled Out";
					}
					oi=deptree.names.FindString(searchname);
					deptree.names.SelectedIndex=oi;
				}

			}
		}

		public	void swapstuff()
		{
			
			TreeNode mattsmells=deptree.treeView2.SelectedNode.Parent;
			if (mattsmells!=null)
			{
				string parenttext=mattsmells.Text;
				if (parenttext=="Lone ID's")
				{
			
					int	crap=deptree.treeView2.SelectedNode.Index;
					int	fart=-1;
					int	x;
					string selectedname=deptree.names.Text;
					string selectedtype=deptree.types.Text;
					if (selectedname=="Nulled Out"){return;}
					for	(x=0;x<map.metaCount;x++)
					{
						if (meta.TagType[x]==selectedtype && meta.Names[x]==selectedname)
						{
							fart=x;
							break;
						}
					}
			
					if (fart==-1){return;}

					FileStream FS=new FileStream(map.filepath,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
					BinaryWriter BW=new	BinaryWriter(FS);
					int	oi=meta.Offset[meta.SelectedMeta]+lone.Location[crap];
					
					BW.BaseStream.Seek(oi,SeekOrigin.Begin);
					int	tempx=meta.Ident[fart];
					BW.Write(tempx);
					BW.Close();
					FS.Close();
					dep.InTag[crap]=fart;
					string tempstring="• Location: " + lone.Location[crap].ToString() +	" •	" +	meta.TagType[dep.InTag[crap]] +	" - " +	meta.Names[dep.InTag[crap]]	+ " •";
					deptree.treeView2.SelectedNode.Text=tempstring;
				}
			

				if (parenttext=="Dependencies")
				{
					int	crap=deptree.treeView2.SelectedNode.Index;
					int	fart=-1;
				
					int	x;
					string selectedname=deptree.names.Text;
					string selectedtype=deptree.types.Text;

					if (selectedname=="Nulled Out"){goto oioi;}
					for	(x=0;x<map.metaCount;x++)
					{
						if (meta.TagType[x]==selectedtype && meta.Names[x]==selectedname)
						{
							fart=x;
							break;
						}
					}
			
					if (fart==-1){return;}
	
					FileStream FS=new FileStream(map.filepath,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
					BinaryWriter BW=new	BinaryWriter(FS);
					int	oi=meta.Offset[meta.SelectedMeta]+dep.Location[crap]-4;
				
					BW.BaseStream.Seek(oi,SeekOrigin.Begin);
					int	tempx=meta.Ident[fart];
					char[] ee=meta.TagType[fart].ToCharArray();
					Array.Reverse(ee);
					BW.Write(ee);
					BW.Write(tempx);
					BW.Close();
					FS.Close();
					goto oioi2;
		
				oioi:
					FileStream FSX=new FileStream(map.filepath,FileMode.Open ,FileAccess.ReadWrite,FileShare.ReadWrite);
					BinaryWriter BWX=new BinaryWriter(FSX);
					int	oix=meta.Offset[meta.SelectedMeta]+dep.Location[crap]-4;
					BWX.BaseStream.Seek(oix+4,SeekOrigin.Begin);
					BWX.Write(fart);
					BWX.Close();
					FSX.Close();
	
				oioi2:
					dep.InTag[crap]=fart;
					string tempstring="• Location: " + dep.Location[crap].ToString() + " • " + dep.TagType[crap] + " - " + selectedname	+ " •";
					deptree.treeView2.SelectedNode.Text=tempstring;
				
				}
		
			}
		}

		private	void label6_Click(object sender, System.EventArgs e)
		{
		
		}

		

		private	void panel4_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		public	void swapstring_Click()
		{
		

			TreeNode mattsmells=deptree.treeView2.SelectedNode.Parent;
			if (mattsmells!=null)
			{
				string parenttext=mattsmells.Text;
				if (parenttext=="Strings")
				{
					string shit=deptree.sr.Text;
					short oix=Convert.ToInt16(Array.IndexOf(items.Names,shit));
					if (oix==-1){return;}

					int	crap=deptree.treeView2.SelectedNode.Index;
					FileStream FS=new FileStream(map.filepath,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
					BinaryWriter BW=new	BinaryWriter(FS);
					int	oi=meta.Offset[meta.SelectedMeta]+strings.Location[crap];
					BW.BaseStream.Seek(oi,SeekOrigin.Begin);
					BW.Write(oix);
					byte shit1=0;
					byte shit2=Convert.ToByte(shit.Length);
					BW.Write(shit1);
					BW.Write(shit2);
					BW.Close();
					FS.Close();
					
					strings.StringNum[crap]=oix;
					string tempstring="• Location: " + strings.Location[crap].ToString() + " • String: "+items.Names[strings.StringNum[crap]]+"	•";	
					deptree.treeView2.SelectedNode.Text=tempstring;
				}
			}
		}

		public void	menuItem9_Click(object sender, System.EventArgs	e)
		{
			about shit=new about();
			shit.ShowDialog();
		}


		public float radtodegree(float rad)
		{
			float result=rad * (float)(180 / Math.PI);
			return result;

		}


		public void	GetSpawnData()
		{
			machinfo machs=new machinfo();
			sceninfo scenery=new sceninfo();
			blocinfo bloc=new blocinfo();
			bipedinfo biped=new bipedinfo();
			aiinfo ai=new aiinfo();
			spawns=new spawninfo[10000];
			
			spawncount=0;

			FileStream FS=new FileStream(openmap.FileName,FileMode.Open	,FileAccess.ReadWrite,FileShare.ReadWrite);
			BinaryReader BR=new BinaryReader(FS);


			
			int	x;
			BR.BaseStream.Seek(meta.Offset[3]+376,SeekOrigin.Begin);
			int tempc=BR.ReadInt32();
			int tempr=BR.ReadInt32()-map.secondaryMagic;
			int[] ailist=new int[tempc];
			ai.mode=new ModelData[tempc];
			
			for	(x=0;x<tempc;x++)
			{
				
				BR.BaseStream.Seek(tempr+(x*8)+4,SeekOrigin.Begin);
				int fu=findbyid(BR.ReadInt32());
				if (fu==-1){ailist[x]=-1;continue;}
				BR.BaseStream.Seek(meta.Offset[fu]+16,SeekOrigin.Begin);
				fu=findbyid(BR.ReadInt32());
				if (fu==-1){ailist[x]=-1;continue;}
				BR.BaseStream.Seek(meta.Offset[fu]+180,SeekOrigin.Begin);
				int	tc=BR.ReadInt32();
				int	tr=BR.ReadInt32()-map.secondaryMagic;
				if (tc!=0)
				{
					BR.BaseStream.Seek(tr+4,SeekOrigin.Begin);
					ailist[x]=findbyid(BR.ReadInt32());
					GetModelData(ailist[x]);
					ParseModel(ailist[x]);
					ai.mode[x]=mode;
				}
				else
				{
					ai.mode[x]=new ModelData();
					ailist[x]=-1;
				}
				

			}
			ai.ailist=ailist;
			ai.totalai=tempc;

			BR.BaseStream.Seek(meta.Offset[3]+352,SeekOrigin.Begin);
			tempc=BR.ReadInt32();
			tempr=BR.ReadInt32()-map.secondaryMagic;
			for	(x=0;x<tempc;x++)
			{
				BR.BaseStream.Seek(tempr+(x*116)+54,SeekOrigin.Begin);
				int charindexmain=BR.ReadInt16();

				BR.BaseStream.Seek(tempr+(x*116)+72,SeekOrigin.Begin);
				int ec=BR.ReadInt32();
				int er=BR.ReadInt32()-map.secondaryMagic;

				for	(int n=0;n<ec;n++)
				{
					Application.DoEvents();
					spawns[spawncount]=new spawninfo();
					spawns[spawncount].rotate=spawninfo.RotateType.RotateZ;
					spawns[spawncount].type=spawninfo.SpawnType.AI;
					BR.BaseStream.Seek(er+(n*100)+4,SeekOrigin.Begin);
					spawns[spawncount].x=BR.ReadSingle();
					spawns[spawncount].y=BR.ReadSingle();
					spawns[spawncount].z=BR.ReadSingle();
					spawns[spawncount].vec=new Vector3(spawns[spawncount].x,spawns[spawncount].y,spawns[spawncount].z);
					spawns[spawncount].yaw=BR.ReadSingle();
					spawncount+=1;
					BR.BaseStream.Seek(er+(n*100)+32,SeekOrigin.Begin);
					int charindexnested=BR.ReadInt16();
					if (charindexnested!=-1){spawns[spawncount-1].tag=charindexnested;}
					else if (charindexmain!=-1){spawns[spawncount-1].tag=charindexmain;}	
					else {spawns[spawncount-1].tag=-1;continue;}
					spawns[spawncount-1].mode=ai.mode[spawns[spawncount-1].tag];
					spawns[spawncount-1].tag=ailist[spawns[spawncount-1].tag];
					spawns[spawncount-1].where=er+(n*100)+4;
				}
			}



			BR.BaseStream.Seek(meta.Offset[3]+288,SeekOrigin.Begin);
			tempc=BR.ReadInt32();
			tempr=BR.ReadInt32()-map.secondaryMagic;
			
			for	(x=0;x<tempc;x++)
			{
				Application.DoEvents();
				spawns[spawncount]=new spawninfo();
				spawns[spawncount].rotate=spawninfo.RotateType.RotateYawPitchRoll;
				spawns[spawncount].type=spawninfo.SpawnType.Collection;
				BR.BaseStream.Seek(tempr+(x*144)+64,SeekOrigin.Begin);
				spawns[spawncount].x=BR.ReadSingle();
				spawns[spawncount].y=BR.ReadSingle();
				spawns[spawncount].z=BR.ReadSingle();
				spawns[spawncount].vec=new Vector3(spawns[spawncount].x,spawns[spawncount].y,spawns[spawncount].z);
				spawns[spawncount].yaw=BR.ReadSingle();
				spawns[spawncount].pitch=BR.ReadSingle();
				spawns[spawncount].roll=BR.ReadSingle();
				spawns[spawncount].where=tempr+(x*144)+64;
				spawncount++;



				BR.BaseStream.Seek(tempr+(x*144)+92,SeekOrigin.Begin);
				int	fu=findbyid(BR.ReadInt32());
				if (fu==-1)	{spawns[spawncount-1].tag=-1;spawns[spawncount-1].mode=new ModelData();continue;}
				BR.BaseStream.Seek(meta.Offset[fu],SeekOrigin.Begin);
				int	tc=BR.ReadInt32();
				int	tr=BR.ReadInt32()-map.secondaryMagic;
				BR.BaseStream.Seek(tr+8,SeekOrigin.Begin);
				int	dd=findbyid(BR.ReadInt32());
				if (dd==-1)	{spawns[spawncount-1].tag=-1;spawns[spawncount-1].mode=new ModelData();continue;}
				BR.BaseStream.Seek(meta.Offset[dd]+180,SeekOrigin.Begin);
				tc=BR.ReadInt32();
				tr=BR.ReadInt32()-map.secondaryMagic;
				BR.BaseStream.Seek(tr+4,SeekOrigin.Begin);
				int he= findbyid(BR.ReadInt32());
				if (he==-1){spawns[spawncount-1].tag=-1;spawns[spawncount-1].mode=new ModelData();continue;}
				spawns[spawncount-1].tag=he;
				GetModelData(spawns[spawncount-1].tag);
				ParseModel(spawns[spawncount-1].tag);
				spawns[spawncount-1].mode=mode;
				//MessageBox.Show("test");
			}
		
	

			BR.BaseStream.Seek(meta.Offset[3]+176,SeekOrigin.Begin);
			tempc=BR.ReadInt32();
			tempr=BR.ReadInt32()-map.secondaryMagic;
			int [] machlist=new int[tempc];
			machs.mode=new ModelData[tempc];
			for	(x=0;x<tempc;x++)
			{

					BR.BaseStream.Seek(tempr+(x*40)+4,SeekOrigin.Begin);
					machlist[x]=findbyid(BR.ReadInt32());
				if (machlist[x]==-1)
				{
					machs.mode[x]=new ModelData();
					machlist[x]=-1;
					continue;
				}
				BR.BaseStream.Seek(meta.Offset[machlist[x]]+180,SeekOrigin.Begin);
				int	tc=BR.ReadInt32();
				int	tr=BR.ReadInt32()-map.secondaryMagic;
				if (tc!=0)
				{
					BR.BaseStream.Seek(tr+4,SeekOrigin.Begin);
					machlist[x]=findbyid(BR.ReadInt32());
					GetModelData(machlist[x]);
					ParseModel(machlist[x]);
					machs.mode[x]=mode;
				}
				else
				{
					machs.mode[x]=new ModelData();
					machlist[x]=-1;
				}

			}
			machs.totalmachs=tempc;
machs.machlist=machlist;
			BR.BaseStream.Seek(meta.Offset[3]+168,SeekOrigin.Begin);
			tempc=BR.ReadInt32();
			tempr=BR.ReadInt32()-map.secondaryMagic;
			for	(x=0;x<tempc;x++)
			{
				Application.DoEvents();
				spawns[spawncount]=new spawninfo();
				spawns[spawncount].rotate=spawninfo.RotateType.RotateYawPitchRoll;
				spawns[spawncount].type=spawninfo.SpawnType.Machine;
				BR.BaseStream.Seek(tempr+(x*72)+8,SeekOrigin.Begin);
				spawns[spawncount].x=BR.ReadSingle();
				spawns[spawncount].y=BR.ReadSingle();
				spawns[spawncount].z=BR.ReadSingle();
				spawns[spawncount].vec=new Vector3(spawns[spawncount].x,spawns[spawncount].y,spawns[spawncount].z);
				spawns[spawncount].yaw=BR.ReadSingle();
				spawns[spawncount].pitch=BR.ReadSingle();
				spawns[spawncount].roll=BR.ReadSingle();
				spawns[spawncount].where=tempr+(x*72)+8;
				spawncount++;
				BR.BaseStream.Seek(tempr+(x*72),SeekOrigin.Begin);
				int fx=BR.ReadInt16();
				if (fx==-1){spawns[spawncount-1].tag=-1;continue;}
				spawns[spawncount-1].tag=fx;
				if (machlist[fx]==-1){spawns[spawncount-1].tag=-1;continue;}
				spawns[spawncount-1].mode=machs.mode[spawns[spawncount-1].tag];
				spawns[spawncount-1].tag=machlist[spawns[spawncount-1].tag];
			}


			BR.BaseStream.Seek(meta.Offset[3]+88,SeekOrigin.Begin);
			tempc=BR.ReadInt32();
			tempr=BR.ReadInt32()-map.secondaryMagic;
			int [] scenlist=new int[tempc];
			scenery.mode=new ModelData[tempc];
			for	(x=0;x<tempc;x++)
			{
				BR.BaseStream.Seek(tempr+(x*40)+4,SeekOrigin.Begin);
				scenlist[x]=findbyid(BR.ReadInt32());
				if (scenlist[x]==-1){continue;}
				BR.BaseStream.Seek(meta.Offset[scenlist[x]]+180,SeekOrigin.Begin);
				int	tc=BR.ReadInt32();
				int	tr=BR.ReadInt32()-map.secondaryMagic;
				if (tc!=0)
				{
					BR.BaseStream.Seek(tr+4,SeekOrigin.Begin);
					scenlist[x]=findbyid(BR.ReadInt32());
					GetModelData(scenlist[x]);
					ParseModel(scenlist[x]);
					scenery.mode[x]=mode;
				}
				else
				{
					scenery.mode[x]=new ModelData();
					scenlist[x]=-1;
				}

			}
			scenery.totalscenery=tempc;
scenery.scenlist=scenlist;
			BR.BaseStream.Seek(meta.Offset[3]+80,SeekOrigin.Begin);
			tempc=BR.ReadInt32();
			tempr=BR.ReadInt32()-map.secondaryMagic;
			scenery.x=new float[tempc];
			scenery.y=new float[tempc];
			scenery.z=new float[tempc];
			scenery.yaw=new float[tempc];
			scenery.pitch=new float[tempc];
			scenery.roll=new float[tempc];
			scenery.tag=new int[tempc];
			scenery.tagtype=new string[tempc];
			scenery.count=tempc;
			scenery.where=tempr;
			bsp.scenery=new ModelData[tempc];
			scenery.vec=new Vector3[tempc];

			for	(x=0;x<tempc;x++)
			{
				Application.DoEvents();
				spawns[spawncount]=new spawninfo();
				spawns[spawncount].rotate=spawninfo.RotateType.RotateYawPitchRoll;
				spawns[spawncount].type=spawninfo.SpawnType.Scenery;
				BR.BaseStream.Seek(tempr+(x*92)+8,SeekOrigin.Begin);
				spawns[spawncount].x=BR.ReadSingle();
				spawns[spawncount].y=BR.ReadSingle();
				spawns[spawncount].z=BR.ReadSingle();
				spawns[spawncount].vec=new Vector3(spawns[spawncount].x,spawns[spawncount].y,spawns[spawncount].z);
				spawns[spawncount].yaw=BR.ReadSingle();
				spawns[spawncount].pitch=BR.ReadSingle();
				spawns[spawncount].roll=BR.ReadSingle();
				spawns[spawncount].where=tempr+(x*92)+8;
				spawncount++;
				BR.BaseStream.Seek(tempr+(x*92),SeekOrigin.Begin);
				int fx=BR.ReadInt16();
				if (fx==-1){spawns[spawncount-1].tag=-1;continue;}
				if (scenlist[fx]==-1){spawns[spawncount-1].tag=-1;continue;}
				spawns[spawncount-1].tag=fx;
				spawns[spawncount-1].mode=scenery.mode[spawns[spawncount-1].tag];
				spawns[spawncount-1].tag=scenlist[spawns[spawncount-1].tag];
			}



			BR.BaseStream.Seek(meta.Offset[3]+816,SeekOrigin.Begin);
			tempc=BR.ReadInt32();
			tempr=BR.ReadInt32()-map.secondaryMagic;
			int [] bloclist=new int[tempc];
			bloc.mode=new ModelData[tempc];
			for	(x=0;x<tempc;x++)
			{
				BR.BaseStream.Seek(tempr+(x*40)+4,SeekOrigin.Begin);
				bloclist[x]=findbyid(BR.ReadInt32());
				if (bloclist[x]==-1){continue;}
				BR.BaseStream.Seek(meta.Offset[bloclist[x]]+180,SeekOrigin.Begin);
				int	tc=BR.ReadInt32();
				int	tr=BR.ReadInt32()-map.secondaryMagic;
				if (tc!=0)
				{
					BR.BaseStream.Seek(tr+4,SeekOrigin.Begin);
					bloclist[x]=findbyid(BR.ReadInt32());
					GetModelData(bloclist[x]);
					ParseModel(bloclist[x]);
					bloc.mode[x]=mode;
				}
				else
				{
					bloc.mode[x]=new ModelData();
					bloclist[x]=-1;
				}

			}
			bloc.totalbloc=tempc;
			bloc.bloclist=bloclist;

			BR.BaseStream.Seek(meta.Offset[3]+808,SeekOrigin.Begin);
			tempc=BR.ReadInt32();
			tempr=BR.ReadInt32()-map.secondaryMagic;

			for	(x=0;x<tempc;x++)
			{
				Application.DoEvents();
				spawns[spawncount]=new spawninfo();
				spawns[spawncount].rotate=spawninfo.RotateType.RotateYawPitchRoll;
				spawns[spawncount].type=spawninfo.SpawnType.Obstacle;
				BR.BaseStream.Seek(tempr+(x*76)+8,SeekOrigin.Begin);
				spawns[spawncount].x=BR.ReadSingle();
				spawns[spawncount].y=BR.ReadSingle();
				spawns[spawncount].z=BR.ReadSingle();
				spawns[spawncount].vec=new Vector3(spawns[spawncount].x,spawns[spawncount].y,spawns[spawncount].z);
				spawns[spawncount].yaw=BR.ReadSingle();
				spawns[spawncount].pitch=BR.ReadSingle();
				spawns[spawncount].roll=BR.ReadSingle();
				spawns[spawncount].where=tempr+(x*76)+8;

				spawncount++;
				BR.BaseStream.Seek(tempr+(x*76)+0,SeekOrigin.Begin);
				int fx=BR.ReadInt16();
				if (fx==-1){spawns[spawncount-1].tag=-1;continue;}
				if (bloclist[fx]==-1){spawns[spawncount-1].tag=-1;continue;}
				spawns[spawncount-1].tag=fx;
				spawns[spawncount-1].mode=bloc.mode[spawns[spawncount-1].tag];	
				spawns[spawncount-1].tag=bloclist[spawns[spawncount-1].tag];
			}


			BR.BaseStream.Seek(meta.Offset[3]+104,SeekOrigin.Begin);
			tempc=BR.ReadInt32();
			tempr=BR.ReadInt32()-map.secondaryMagic;
			int [] bipedlist=new int[tempc];
			biped.mode=new ModelData[tempc];
			for	(x=0;x<tempc;x++)
			{
				BR.BaseStream.Seek(tempr+(x*40)+4,SeekOrigin.Begin);
				bipedlist[x]=findbyid(BR.ReadInt32());
				if (bipedlist[x]==-1){continue;}
				BR.BaseStream.Seek(meta.Offset[bipedlist[x]]+180,SeekOrigin.Begin);
				int	tc=BR.ReadInt32();
				int	tr=BR.ReadInt32()-map.secondaryMagic;
				if (tc!=0)
				{
					BR.BaseStream.Seek(tr+4,SeekOrigin.Begin);
					bipedlist[x]=findbyid(BR.ReadInt32());
					GetModelData(bipedlist[x]);
					ParseModel(bipedlist[x]);
					biped.mode[x]=mode;
				}
				else
				{
					biped.mode[x]=new ModelData();
					bipedlist[x]=-1;
				}

			}
			biped.totalbiped=tempc;
			biped.bipedlist=bipedlist;

			BR.BaseStream.Seek(meta.Offset[3]+96,SeekOrigin.Begin);
			tempc=BR.ReadInt32();
			tempr=BR.ReadInt32()-map.secondaryMagic;
			for	(x=0;x<tempc;x++)
			{
				Application.DoEvents();
				spawns[spawncount]=new spawninfo();
				spawns[spawncount].rotate=spawninfo.RotateType.RotateZ;
				spawns[spawncount].type=spawninfo.SpawnType.Biped;
				BR.BaseStream.Seek(tempr+(x*84)+8,SeekOrigin.Begin);
				spawns[spawncount].x=BR.ReadSingle();
				spawns[spawncount].y=BR.ReadSingle();
				spawns[spawncount].z=BR.ReadSingle();
				spawns[spawncount].vec=new Vector3(spawns[spawncount].x,spawns[spawncount].y,spawns[spawncount].z);
				spawns[spawncount].yaw=BR.ReadSingle();
				spawns[spawncount].pitch=BR.ReadSingle();
				spawns[spawncount].roll=BR.ReadSingle();
				spawns[spawncount].where=tempr+(x*84)+8;
				spawncount++;

				BR.BaseStream.Seek(tempr+(x*84)+0,SeekOrigin.Begin);
				int fx=BR.ReadInt16();
				if (fx==-1){spawns[spawncount-1].tag=-1;continue;}
				if (bipedlist[fx]==-1){spawns[spawncount-1].tag=-1;continue;}
				spawns[spawncount-1].tag=fx;
			
				spawns[spawncount-1].mode=biped.mode[spawns[spawncount-1].tag];	
	
				spawns[spawncount-1].tag=bipedlist[spawns[spawncount-1].tag];
	
			}


			BR.BaseStream.Seek(meta.Offset[0]+304,SeekOrigin.Begin);
			tempc=BR.ReadInt32();
			tempr=BR.ReadInt32()-map.secondaryMagic;
			BR.BaseStream.Seek(tempr+4,SeekOrigin.Begin);
			int gxt=findbyid(BR.ReadInt32());
			BR.BaseStream.Seek(meta.Offset[gxt]+180,SeekOrigin.Begin);
			int	tc2=BR.ReadInt32();
			int	tr2=BR.ReadInt32()-map.secondaryMagic;
			BR.BaseStream.Seek(tr2+4,SeekOrigin.Begin);
			int gx=findbyid(BR.ReadInt32());



			GetModelData(gx);
			ParseModel(gx);

				
			BR.BaseStream.Seek(meta.Offset[3]+256,SeekOrigin.Begin);
			tempc=BR.ReadInt32();
			tempr=BR.ReadInt32()-map.secondaryMagic;
	
			for	(x=0;x<tempc;x++)
			{
				Application.DoEvents();
				spawns[spawncount]=new spawninfo();
				spawns[spawncount].rotate=spawninfo.RotateType.RotateZ;
				spawns[spawncount].type=spawninfo.SpawnType.PlayerSpawn;
				BR.BaseStream.Seek(tempr+(x*52),SeekOrigin.Begin);
				spawns[spawncount].x=BR.ReadSingle();
				spawns[spawncount].y=BR.ReadSingle();
				spawns[spawncount].z=BR.ReadSingle();
				spawns[spawncount].vec=new Vector3(spawns[spawncount].x,spawns[spawncount].y,spawns[spawncount].z);
				spawns[spawncount].yaw=BR.ReadSingle();
				spawns[spawncount].where=tempr+(x*52);
				spawncount++;

				
				spawns[spawncount-1].tag=gx;
			
				spawns[spawncount-1].mode=mode;	
	
			
			}


			BR.BaseStream.Seek(meta.Offset[3]+280,SeekOrigin.Begin);
			tempc=BR.ReadInt32();
			tempr=BR.ReadInt32()-map.secondaryMagic;
	
			for	(x=0;x<tempc;x++)
			{
				Application.DoEvents();
				spawns[spawncount]=new spawninfo();
				spawns[spawncount].rotate=spawninfo.RotateType.RotateZ;
				spawns[spawncount].type=spawninfo.SpawnType.KOTH;
				BR.BaseStream.Seek(tempr+(x*52),SeekOrigin.Begin);
				spawns[spawncount].x=BR.ReadSingle();
				spawns[spawncount].y=BR.ReadSingle();
				spawns[spawncount].z=BR.ReadSingle();
				spawns[spawncount].vec=new Vector3(spawns[spawncount].x,spawns[spawncount].y,spawns[spawncount].z);
				spawns[spawncount].yaw=0;
				spawns[spawncount].where=tempr+(x*32);
				spawncount++;

				
				spawns[spawncount-1].tag=gx;
			
				spawns[spawncount-1].mode=mode;	
	
			
			}









			BR.BaseStream.Seek(meta.Offset[3]+120,SeekOrigin.Begin);
			tempc=BR.ReadInt32();
			tempr=BR.ReadInt32()-map.secondaryMagic;
			int [] vehilist=new int[tempc];
			ModelData[] vehimode=new ModelData[tempc];
			for	(x=0;x<tempc;x++)
			{
				BR.BaseStream.Seek(tempr+(x*40)+4,SeekOrigin.Begin);
				vehilist[x]=findbyid(BR.ReadInt32());
				if (vehilist[x]==-1){continue;}
				BR.BaseStream.Seek(meta.Offset[vehilist[x]]+180,SeekOrigin.Begin);
				int	tc=BR.ReadInt32();
				int	tr=BR.ReadInt32()-map.secondaryMagic;
				if (tc!=0)
				{
					BR.BaseStream.Seek(tr+4,SeekOrigin.Begin);
					vehilist[x]=findbyid(BR.ReadInt32());
					GetModelData(vehilist[x]);
					ParseModel(vehilist[x]);
					vehimode[x]=mode;
				}
				else
				{
					vehimode[x]=new ModelData();
					vehilist[x]=-1;
				}

			}
			

			BR.BaseStream.Seek(meta.Offset[3]+112,SeekOrigin.Begin);
			tempc=BR.ReadInt32();
			tempr=BR.ReadInt32()-map.secondaryMagic;

			for	(x=0;x<tempc;x++)
			{
				Application.DoEvents();
				spawns[spawncount]=new spawninfo();
				spawns[spawncount].rotate=spawninfo.RotateType.RotateYawPitchRoll;
				spawns[spawncount].type=spawninfo.SpawnType.Vehicle;
				BR.BaseStream.Seek(tempr+(x*84)+8,SeekOrigin.Begin);
				spawns[spawncount].x=BR.ReadSingle();
				spawns[spawncount].y=BR.ReadSingle();
				spawns[spawncount].z=BR.ReadSingle();
				spawns[spawncount].vec=new Vector3(spawns[spawncount].x,spawns[spawncount].y,spawns[spawncount].z);
				spawns[spawncount].yaw=BR.ReadSingle();
				spawns[spawncount].pitch=BR.ReadSingle();
				spawns[spawncount].roll=BR.ReadSingle();
				spawns[spawncount].where=tempr+(x*84)+8;

				spawncount++;
				BR.BaseStream.Seek(tempr+(x*84)+0,SeekOrigin.Begin);
				int fx=BR.ReadInt16();
				if (fx==-1){spawns[spawncount-1].tag=-1;continue;}
				if (vehilist[fx]==-1){spawns[spawncount-1].tag=-1;continue;}
				spawns[spawncount-1].tag=fx;
				spawns[spawncount-1].mode=vehimode[spawns[spawncount-1].tag];	
				spawns[spawncount-1].tag=vehilist[spawns[spawncount-1].tag];
			}





			BR.BaseStream.Seek(meta.Offset[3]+136,SeekOrigin.Begin);
			tempc=BR.ReadInt32();
			tempr=BR.ReadInt32()-map.secondaryMagic;
			int [] equiplist=new int[tempc];
			ModelData[] equipmode=new ModelData[tempc];
			for	(x=0;x<tempc;x++)
			{
				BR.BaseStream.Seek(tempr+(x*40)+4,SeekOrigin.Begin);
				equiplist[x]=findbyid(BR.ReadInt32());
				if (equiplist[x]==-1){continue;}
				BR.BaseStream.Seek(meta.Offset[equiplist[x]]+180,SeekOrigin.Begin);
				int	tc=BR.ReadInt32();
				int	tr=BR.ReadInt32()-map.secondaryMagic;
				if (tc!=0)
				{
					BR.BaseStream.Seek(tr+4,SeekOrigin.Begin);
					equiplist[x]=findbyid(BR.ReadInt32());
					GetModelData(equiplist[x]);
					ParseModel(equiplist[x]);
					equipmode[x]=mode;
				}
				else
				{
					equipmode[x]=new ModelData();
					equiplist[x]=-1;
				}

			}
			

			BR.BaseStream.Seek(meta.Offset[3]+128,SeekOrigin.Begin);
			tempc=BR.ReadInt32();
			tempr=BR.ReadInt32()-map.secondaryMagic;

			for	(x=0;x<tempc;x++)
			{
				Application.DoEvents();
				spawns[spawncount]=new spawninfo();
				spawns[spawncount].rotate=spawninfo.RotateType.RotateYawPitchRoll;
				spawns[spawncount].type=spawninfo.SpawnType.Equipment;
				BR.BaseStream.Seek(tempr+(x*56)+8,SeekOrigin.Begin);
				spawns[spawncount].x=BR.ReadSingle();
				spawns[spawncount].y=BR.ReadSingle();
				spawns[spawncount].z=BR.ReadSingle();
				spawns[spawncount].vec=new Vector3(spawns[spawncount].x,spawns[spawncount].y,spawns[spawncount].z);
				spawns[spawncount].yaw=BR.ReadSingle();
				spawns[spawncount].pitch=BR.ReadSingle();
				spawns[spawncount].roll=BR.ReadSingle();
				spawns[spawncount].where=tempr+(x*56)+8;

				spawncount++;
				BR.BaseStream.Seek(tempr+(x*56)+0,SeekOrigin.Begin);
				int fx=BR.ReadInt16();
				if (fx==-1){spawns[spawncount-1].tag=-1;continue;}
				if (equiplist[fx]==-1){spawns[spawncount-1].tag=-1;continue;}
				spawns[spawncount-1].tag=fx;
				spawns[spawncount-1].mode=equipmode[spawns[spawncount-1].tag];	
				spawns[spawncount-1].tag=equiplist[spawns[spawncount-1].tag];
			}








BR.Close();
			FS.Close();

		}

		private	void menuItem10_Click(object sender, System.EventArgs e)
		{
			
		}

		public	void metaedit_Click()
		{
			
			

			if (plugit.Visible==false)
			{
				plug=new PluginX.PluginX();
				plugit.Visible=true;
				metashitwindow.metaedit.BackColor=Color.White;	
				if (map.pluginitialized==false)
				{
					initializeplugin();
				}
				pmap.SelectedTag=meta.SelectedMeta;
				plug.setdata(ref pmeta,ref pinfo,ref pmap);
				plugit.Show();
			}
			else
			{
				plugit.Visible=false;
				metashitwindow.metaedit.BackColor=Color.Gray;
			}

		}

		private	void initializeplugin()
		{
		
			pmeta=new PluginX.Metas();
			pmeta.Ident=meta.Ident;
			pmeta.Name=meta.Names;
			pmeta.Offset=meta.Offset;
			pmeta.Size=meta.Size;
			pmeta.TagType=meta.TagType;
			pinfo=new PluginX.iteminfo();
			pinfo.itemname=items.Names;
			pmap=new PluginX.MapInfo();
			pmap.ItemCount=map.scriptReferenceCount;
			pmap.SelectedTag=meta.SelectedMeta;
			pmap.MetaCount=map.metaCount;
			pmap.SecondaryMagic=map.secondaryMagic;
			pmap.TagTypes=map.tagTypes;
			pmap.ItemCount=map.scriptReferenceCount;
			
			map.pluginitialized=true;
		}
		public	void pluginsave()
		{
			plug.Plugins(map.filepath);
		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	
		//protected override void OnResize(EventArgs e)
		//{
			//int locx=panel1.Left;
			//int locy=panel1.Top;
			//int formwidth=this.Width;
			//int formheight=this.Height;
			//panel1.Width=formwidth-locx-12;
			//panel1.Height=formheight-locy-70;
			//panel4.Width=formwidth-locx-11;
		//	panel4.Height=formheight-locy-70;
		//	tabControl1.Width=panel1.Width;
		//	tabControl1.Height=panel1.Height-8-button5.Height;
		//	treeView2.Width=formwidth-locx-21;
		//	treeView2.Height=formheight-locy-128;
		//	names.Top=treeView2.Top+treeView2.Height+3;
		//	sr.Top=treeView2.Top+treeView2.Height+3;
		//	button2.Top=names.Top+names.Height+3;
		//	button4.Top=names.Top+names.Height+3;
	//		types.Top=names.Top+names.Height+3;	
	//		metashitwindow.xxxxxxxxxxxxxx.Height=panel1.Height;
	///		metashitwindow.treeView1.Height=panel1.Height-7;
	//		progress.Top=metashitwindow.treeView1.Top+metashitwindow.treeView1.Height-50;
	//		progress.Width=metashitwindow.treeView1.Width;
	//		button5.Top=tabControl1.Height+2;
	//		button5.Left=panel1.Width-button5.Width-4;
	//		Application.DoEvents();
			//treeView2

			// TODO:  Add Form1.OnResize implementation
	//		base.OnResize (e);
	//	}

		private void menuItem4_Click_1(object sender, System.EventArgs e)
		{
			if (mapstructure.ShowDialog()==DialogResult.Cancel){return;}
	
			int minjmad=map.filesize;
			int maxjmad=0;
			int minmode=map.filesize;
			int maxmode=0;
			int minmode2=map.filesize;
			int maxmode2=0;
			int minbitm=map.filesize;
			int maxbitm=0;
			int mindecr=map.filesize;
			int maxdecr=0;
			int minprtm=map.filesize;
			int maxprtm=0;
			int jmadsize=0;
			int x;
			for (x=0;x<map.metaCount;x++)
			{
				scanraw(x);
				if (meta.TagType[x]=="bitm")
				{
					for (int j=0;j<bitm.RawCount;j++)
					{
						if (bitm.ExternalMap[j]==0&&bitm.RawOffset[j]<minbitm){minbitm=bitm.RawOffset[j];}
						if (bitm.ExternalMap[j]==0&&bitm.RawOffset[j]>maxbitm){maxbitm=bitm.RawOffset[j];}
					}
				}

				if (meta.TagType[x]=="mode")
				{
					for (int j=0;j<mode.RawCount;j++)
					{
						if (mode.ExternalMap[j]==0&&mode.RawOffset[j]<minmode){minmode=mode.RawOffset[j];}
						if (mode.ExternalMap[j]==0&&mode.RawOffset[j]>maxmode){maxmode=mode.RawOffset[j];}
					}
					for (int j=0;j<mode.RawCount2;j++)
					{
						if (mode.ExternalMap2[j]==0&&mode.RawOffset2[j]<minmode2){minmode2=mode.RawOffset2[j];}
						if (mode.ExternalMap2[j]==0&&mode.RawOffset2[j]>maxmode2){maxmode2=mode.RawOffset2[j];}
					}
				}


				if (meta.TagType[x]=="jmad")
				{
					for (int j=0;j<jmad.RawCount;j++)
					{
						if (jmad.ExternalMap[j]==0&&jmad.RawOffset[j]<minjmad){minjmad=jmad.RawOffset[j];}
						if (jmad.ExternalMap[j]==0&&jmad.RawOffset[j]>maxjmad){jmadsize=jmad.RawSize[j];maxjmad=jmad.RawOffset[j];}
					}
				}

				if (meta.TagType[x]=="DECR")
				{
				
						if (decr.ExternalMap==0&&decr.RawOffset<mindecr){mindecr=decr.RawOffset;}
					if (decr.ExternalMap==0&&decr.RawOffset>maxdecr){maxdecr=decr.RawOffset;}
			
				}
				if (meta.TagType[x]=="PRTM")
				{
					if (prtm.ExternalMap==0&&prtm.RawOffset<minprtm){minprtm=prtm.RawOffset;}
					if (prtm.ExternalMap==0&&prtm.RawOffset>maxprtm){maxprtm=prtm.RawOffset;}
				}
			}


			int minbsp=map.filesize;
			int maxbsp=0;

			

			FileStream FS=new FileStream(mapstructure.FileName,FileMode.Create);
			StreamWriter SW=new StreamWriter(FS);

			SW.WriteLine("#Dark Matter Map Structure Printer Outer Thing");
			SW.WriteLine("----------------------------------------------");
			SW.WriteLine("Model Raw - First Raw Pointer: " + minmode.ToString()+" - "+"Last Raw Pointer: " + maxmode.ToString());
			SW.WriteLine("Model Raw Type2 - First Raw Pointer: " + minmode2.ToString()+" - "+"Last Raw Pointer: " + maxmode2.ToString());
			int tempsize=0;
			for (x=0;x<bsp.Magic.Length;x++)
			{
				SW.WriteLine("BSP Offset: "+bsp.Offset[x].ToString());
				SW.WriteLine("BSP Size: "+bsp.Size[x].ToString());
				for (int j=0;j<bsp.Model1Count[x];j++)
				{
					SW.WriteLine("BSPModel1 Raw Pointer: " + bsp.Model1Offset[x][j].ToString()+" - "+"BSPModel1 Map: " + bsp.Model1Map[x][j].ToString()+ bsp.Model1Size[x][j].ToString());
				}
				for (int j=0;j<bsp.Model2Count[x];j++)
				{
					SW.WriteLine("BSPModel2 Raw Pointer: " + bsp.Model2Offset[x][j].ToString()+" - "+"BSPModel2 Map: " + bsp.Model2Map[x][j].ToString()+ bsp.Model2Size[x][j].ToString());
				}
				for (int j=0;j<bsp.Model3Count[x];j++)
				{
					SW.WriteLine("BSPModel3 Raw Pointer: " + bsp.Model3Offset[x][j].ToString()+" - "+"BSPModel3 Map: " + bsp.Model3Map[x][j].ToString()+ bsp.Model3Size[x][j].ToString());
				}
				for (int j=0;j<bsp.Model4Count[x];j++)
				{
					SW.WriteLine("BSPModel4 Raw Pointer: " + bsp.Model4Offset[x][j].ToString()+" - "+"BSPModel4 Map: " + bsp.Model4Map[x][j].ToString()+ bsp.Model4Size[x][j].ToString());
				}
			}
			SW.WriteLine("DECR Raw - First Raw Pointer: " + mindecr.ToString()+" - "+"Last Raw Pointer: " + maxdecr.ToString());
			SW.WriteLine("PRTM Raw - First Raw Pointer: " + minprtm.ToString()+" - "+"Last Raw Pointer: " + maxprtm.ToString());
			SW.WriteLine("Jmad Raw - First Raw Pointer: " + minjmad.ToString()+" - "+"Last Raw Pointer: " + maxjmad.ToString());
			SW.WriteLine("Last Jmad Size:"+jmadsize.ToString());
			SW.WriteLine("SR Name Index1: "+map.srNames.ToString());
			SW.WriteLine("SR Offset Index: "+map.offsetToScriptReferenceIndex.ToString());
			SW.WriteLine("SR Name Index2: "+map.offsetToScriptReferenceStrings.ToString());
			SW.WriteLine("SR Name Index2 Size: "+map.sizeOfScriptReference.ToString());
			SW.WriteLine("File Offset Index: "+map.filesIndex.ToString());
			SW.WriteLine("File Name Index: "+map.fileTableOffset.ToString());
			SW.WriteLine("File Name Index Size: "+map.fileTableSize.ToString());
			SW.WriteLine("Strange Index: "+map.offsetToStrangeFileStrings.ToString());
			
			SW.WriteLine("Bitm Raw - First Raw Pointer: " + minbitm.ToString()+" - "+"Last Raw Pointer: " + maxbitm.ToString());


			SW.Close();
			FS.Close();
			MessageBox.Show("Done");
		}

		private void menuItem10_Click_1(object sender, System.EventArgs e)
		{
		
			mapstuff.Visible=true;
		
		}

		public void rawdataview()
		{
			if (meta.SelectedMeta==-1){return;}
			if (meta.TagType[meta.SelectedMeta]=="sbsp")
			{
				GetSpawnData();
				bsp.selected=Array.IndexOf(bsp.tag,meta.SelectedMeta);
				ParseBSP(bsp.selected);
				if (killmatt2!=null) { killmatt2.Dispose();	}
				killmatt2=new BSPViewer();
				Form1 jk=this;
				killmatt2.SetRaw(ref bsp,ref spawns,ref map,ref jk,ref	meta,spawncount);
				killmatt2.Show();
							
				killmatt2.Dispose();
							
			}
			if (meta.TagType[meta.SelectedMeta]=="coll")
			{
				//ParseColl(x);
				//if (killmatt3!=null) { killmatt3.Dispose();	}
				//killmatt3=new CollViewer();
				//Form1 i=this;
				//killmatt3.SetRaw(ref coll,ref meta,ref map,ref i);
				//killmatt3.Show();
			}
			if (meta.TagType[meta.SelectedMeta]=="mode")
			{
				ParseModel(meta.SelectedMeta);
							
				killmatt=new ModelViewer();
				Form1 i=this;
				killmatt.SetRaw(ref	mode,ref bitm,ref meta,ref map,ref i);
				//killmatt.MdiParent=this;
				killmatt.BringToFront();
				killmatt.Show();

				//killmatt.Dispose();
							
			}
			if (meta.TagType[meta.SelectedMeta]=="bitm")
			{
				parsebitm(meta.SelectedMeta);
				Form1 jh=this;
				if (lll.Visible==false){lll=new	BitmViewer();}
				lll.setbitm(ref	bitm,ref jh);
				lll.DecodeBitm();

				lll.MdiParent=this;
				lll.BringToFront();
				if (lll.Visible==false){lll.Show();}
				lll.bitminfo();
								
			}

		}

		public void remotescanthis()
		{
			scanthis(meta.SelectedMeta);
			show(true,meta.SelectedMeta);
		}
	}

}
