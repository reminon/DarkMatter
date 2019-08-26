using System;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using System.IO;
using System.Drawing;
using sharedstuff;
using sharedstuff.RawData;
using sharedstuff.MetaStuff;

using sharedstuff.ImportStuff;
namespace sharedstuff
{
	/// <summary>
	/// Summary description for Variables.
	/// </summary>

			

			public struct spawninfo
			{
				public enum SpawnType
				{
					Null,Collection,Machine,Scenery,AI,Biped,Obstacle,PlayerSpawn,Vehicle,Equipment,KOTH
				}
				public enum RotateType
				{
					RotateZ,RotateYawPitchRoll
				}
				public SpawnType type;
				public RotateType rotate;
				public Vector3 vec;
				public float x;
				public float y;
				public float z;
				public float yaw;
				public float pitch;
				public float roll;
				public int tag;
				public string tagtype;
				public ModelData mode;
				public int where;
			}
		public struct machinfo
		{
			public int totalmachs;
			public int count;
			public Vector3[] vec;
			public float[] x;
			public float[] y;
			public float[] z;
			public float[] yaw;
			public float[] pitch;
			public float[] roll;
			public int[] tag;
			public string[]	tagtype;
			public int where;
			public int chunk;
			public ModelData[] mode;
			public int[] machlist;
		}
		public struct sceninfo
		{
			public int totalscenery;
			public int count;
			public float[] x;
			public float[] y;
			public float[] z;
			public Vector3[] vec;
			public float[] yaw;
			public float[] pitch;
			public float[] roll;
			public int[] tag;
			public string[]	tagtype;
			public int where;
			public int chunk;
			public ModelData[] mode;
			public int[] scenlist;
			public Vector3[] attachpoints;
			public int[] attachoffset;
		}

		public struct aiinfo
		{
			public int totalai;
			public int squadcount;
			public int[] loccount;
			public float[][] x;
			public float[][] y;
			public float[][] z;
			public Vector3[][] vec;
			public float[][] yaw;
			public float[][] pitch;
			public float[][] roll;
			public int[][] tag;
			public int[] where;
			public int chunk;
			public ModelData[] mode;
			public int[] ailist;
		}
		public struct blocinfo
		{
			public int totalbloc;
			public int count;
			public float[] x;
			public float[] y;
			public float[] z;
			public Vector3[] vec;
			public float[] yaw;
			public float[] pitch;
			public float[] roll;
			public int[] tag;
			public string[]	tagtype;
			public int where;
			public int chunk;
			public ModelData[] mode;
			public int[] bloclist;
		}
		public struct bipedinfo
		{
			public int totalbiped;
			public int count;
			public float[] x;
			public float[] y;
			public float[] z;
			public Vector3[] vec;
			public float[] yaw;
			public float[] pitch;
			public float[] roll;
			public int[] tag;
			public string[]	tagtype;
			public int where;
			public int chunk;
			public ModelData[] mode;
			public int[] bipedlist;
		}

		public class bspstuff
		{
			public	int[] tag;
			public	int[] Size;
			public	int[] Magic;
			public	int[] Offset;
			public	int[] offloc;

			public int selected;


			//model	1 
			public short[][] FixedIndices;
			public int Model1TotalFaceCount;
			public int Model1TotalVertCount;
			public int Model1TotalIndiceCount;
			public	int[] Model1Count;
			public	int[][]	Model1Offset;
			public	int[][]	Model1Size;
			public	MemoryStream[][] Model1Raw;
			public	int[][]	Model1Map;
			public	int[][]	Model1Loc;
			public int[][] Model1HeaderSize;
			public int[][] Model1WithoutHeaderSize;
			public int[][][] Model1RawChunkOffset;
			public int[][][] Model1RawChunkTotalSize;
			public int[][][] Model1RawChunkSize;
			public int[][][] Model1RawChunkCount;
			public int[][] Model1RawVerticeCount;
			public int[][] Model1FaceCount;
			public int[][] Model1RawIndiceCount;

			public short[][][] Model1Indices;
			public float[][][] X;
			public float[][][] Y;
			public float[][][] Z;
			public float[][][] U;
			public float[][][] V;
			public ShaderInfo[]	shaders1;

			public int[][] Texture1;
			public int[][] StartOfIndices1;
			public int[][] EndOfIndices1;
			public ModelData[] spawns;
			public ModelData[] machs;
			public ModelData[] scenery;
			public ModelData[][] ai;
			public ModelData[] bloc;
			public ModelData[] biped;
			//model	2

			public	int[] Model2Count;
			public	int[][]	Model2Offset;
			public	int[][]	Model2Size;
			public	byte[][][] Model2Raw;
			public	int[][]	Model2Map;
			public	int[][]	Model2Loc;

			public	int[] Model3Count;
			public	int[][]	Model3Offset;
			public	int[][]	Model3Size;
			public	byte[][][] Model3Raw;
			public	int[][]	Model3Map;
			public	int[][]	Model3Loc;

			public	int[] Model4Count;
			public	int[][]	Model4Offset;
			public	int[][]	Model4Size;
			public	byte[][][] Model4Raw;
			public	int[][]	Model4Map;	
			public	int[][]	Model4Loc;
		}

		public class parsedstuff
		{
			public byte[][]	meta;
			public int count;
			public int pos;
			public int[] newreflexoldtag;
			public int[] newreflexoldtrans;
			public int[] newreflextrans;
			public int[] newreflexloc;
			public int[] metachunknum;
			public int newreflexcount;
			public int[][] refsloc;
			public int[][] refstrans;
			public int[][] refsintag;
			public int[] refscount;
			public int[] refstag;
			public byte[][] refstagmeta;
		}

		namespace ImportStuff
				  {
		public class FilesToImport
		{
			public int[][] lone;
			public int[] lonecount;
			public int[][] deps;
			public int[] depscount;
			public string[]	FileOrder;
			public int[] FileOrderX;
			public int count;
		}
		public class ImportReflexive
		{
			public int Count;
			public int[] Location;
			public int[] ChunkCount;
			public int[] Translation;
			public string[]	TagType;
			public string[]	Name;
		}

		public class ImportDependency
		{
			public int Count;
			public int[] Location;
			public string[]	TagType;
			public string[]	Name;
		}

		public class ImportLoneID
		{
			public int Count;
			public int[] Location;
			public string[]	TagType;
			public string[]	Name;
		}

		public class ImportStringsX
		{
			public int[] Location;
			public string[]	String;
			public int Count;
		}
	}

	namespace RawData
	{
		public class spasData
		{
			public char[] endsin;
		}
		public class PhmoData
		{
			public char[] endsin;
		}
		public class CollData
		{
			public short[] indices;
			public float[] x;
			public float[] y;
			public float[] z;
			public char[] endsin;
		}
		public class ModelData
		{
			public int RawCount2;
			public int[] LocationOfRawPointer2;
			public int[] RawOffset2;
			public int[] RawSize2;
			public int[] ExternalMap2;
			public MemoryStream[] RawData2;

			public int RawCount;
			public int[] LocationOfRawPointer;
			public int[] RawOffset;
			public int[] RawSize;
			public int[] ExternalMap;
			public int[] Type;
			public MemoryStream[] RawData;
			public int[] RawHeaderSize;
			public int[] RawWithoutHeaderSize;
			public int[] RawChunkInfoLoc;
			public int[][] RawChunkOffset;
			public int[][] RawChunkTotalSize;
			public int[][] RawChunkSize;
			public byte[][][] RawChunkData;
			public byte[] HeaderChunkData;
			public int[] RawChunkCount;
			public int[] IndiceChunkNumber;
			public int[][] Texture;
			public int[][] StartOfIndices;
			public int[][] EndOfIndices;
			public int[] StartOfShit;
			public float MinX;
			public float MaxX;
			public float MinY;
			public float MaxY;
			public float MinZ;
			public float MaxZ;
			public float MinU;
			public float MaxU;
			public float MinV;
			public float MaxV;
			public float MinnX;
			public float MaxnX;
			public float MinnY;
			public float MaxnY;
			public float MinnZ;
			public float MaxnZ;
			

			public float[][] X;
			public float[][] Y;
			public float[][] Z;
			public float[][] U;
			public float[][] V;
			public float[][] nX;
			public float[][] nY;
			public float[][] nZ;

			public short[][] Indices;
			public short[][][] FixedIndices;
			public short[][] FixedIndices2;
			public int[] FaceCount;
			public int[] IndiceCount;
			public int[] VerticeCount;
			public int[] InfoBlockCount;
			public int[] Unk1Count;
			public int[] Unk2Count;
			public int[] Unk3Count;

			public int[][][] LOD;
			public int[][] LODCount;
			public string[]	LODName;
			public string[][] LODName2;

			public int startofrawinfometachunks;

			public ShaderInfo[]	shaders;
			public Mesh[][][] mesh;
		}
		public class ShaderInfo
		{
			public Bitmap b;
			public Bitmap b2;
			public Texture t;
			public Texture t2;
			public string stemname;
			public int btag;
			public int tag;
			public BitmData[] BitmInfo;
		}
		public class JmadData
		{
			public int RawCount;
			public int[] LocationOfRawPointer;
			public int[] RawOffset;
			public int[] RawSize;
			public int[] ExternalMap;
			public byte[][]	RawData;
		}
		public class BitmData
		{	
			public int tag;
			public string name;
			public int RawCount;
			public int[] LocationOfRawPointer;
			public int[] RawOffset;
			public int[] RawSize;
			public int[] ExternalMap;
			public byte[][][] RawData;
			public byte[][][] DecodedData;
			public IntPtr[][] ptr;
			public Bitmap[][] bit;
			public IntPtr ptrx;
			public ushort[]	width;
			public ushort[]	height;
			public ushort[]	depth;
			public ushort[]	type;
			public ushort[]	format;
			public ushort[]	flags;
			public ushort[]	regPointX;
			public ushort[]	regPointY;
			public ushort[]	mipMapCount;
			public ushort[]	pixelOffset;

			public ushort[]	subMapCount;
		}
		public class PRTMData
		{
			public int LocationOfRawPointer;
			public int RawOffset;
			public int RawSize;
			public int ExternalMap;
			public byte[] RawData;
		}
		public class DECRData
		{
			public int LocationOfRawPointer;
			public int RawOffset;
			public int RawSize;
			public int ExternalMap;
			public byte[] RawData;
		}
		public class sndData
		{
			public int mainindex;
			public int mainindexcount;

			public int locationofchunk4;
			public int totalcountofchunk4;

			public byte[] chunk4;
			public int[] index4;		
			public int[] index4count;

			public int locationofchunk5;
			public int totalcountofchunk5;

			public byte[][] chunk5;
			public int[][] index5;	
			public int[][] index5count;	


			public int locationofrawdatapointers;
			public int totalcountofrawdatapointers;
			public int[] LocationOfRawPointer;
			public int RawCount;
			public int[] RawOffset;
			public int[] RawSize;
			public int[] ExternalMap;
			public byte[][] RawData;
		}
	}

	namespace MetaStuff
	{
		public class Reflexive
		{
			public int Count;
			public int[] Location;
			public int[] ChunkCount;
			public int[] Translation;
			public int[] InTag;
		}

		public class Dependency
		{
			public int Count;
			public int[] Location;
			public int[] InTag;
			public string[]	TagType;
		}

		public class LoneID
		{
			public int Count;
			public int[] Location;
			public int[] InTag;
			public string[]	TagType;
		}

		public class StringsX
		{
			public int[] Location;
			public int[] StringNum;
			public int Count;

		}

		public class MetaInfo
		{
			public bool	scanned;
			public int SelectedMeta;
			public string[]	Names;
			public int[] LengthOfName;
			public string[]	TagType;
			public int[] Ident;
			public int[] Offset;
			public int[] Size;
			public MemoryStream Meta;
		};

	
	}

	public class StringsInfo
	{
		public string[]	Names;
		public int[] NameOffset;
		public int[] LengthOfName;
	}

	public class MapHeader
	{
		public string selectedtype;
		public bool	pluginitialized;
		public int externalMap;
		public int version;
		public int filesize;
		public int zero;
		public int indexOffset;
		public int metaStart;
		public int metaSize;
		public int combinedSize;
		public int offsetToStrangeFileStrings;
		public int srNames;
		public int scriptReferenceCount;
		public int sizeOfScriptReference;
		public int offsetToScriptReferenceIndex;
		public int offsetToScriptReferenceStrings;
		public string mapName;
		public string scenarioPath;
		public int fileCount;
		public int fileTableOffset;
		public int fileTableSize;
		public int filesIndex;
		public int []fileNameOffset;
		public int signature;
		public int primaryMagic;
		public int secondaryMagic;
		public int metaCount;
		public int tagsOffset;
		public int tagTypeCount;
		public string[]	tagTypes;
		public string filepath;
		public MemoryStream	MS;
		public int lowID;
		public int highID;
	};
}


		
	
