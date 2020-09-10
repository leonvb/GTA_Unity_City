using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GTAImgEditor
{
    class Geometry
    {
        //*******************************
        //          PROPERTIES
        //*******************************
        #region PROPERTIES

        // 4 bytes
        public int flags; // Read as UInt16
        public byte numUVs;
        public bool hasNativeGeometry;

        public int numTriangles;
        public int numVertices;
        public int numMorphTargets; // Unused in GTA, default to 1

        // If the version is III (For PC)
        // Lighting Information
        public float ambient;
        public float specular;
        public float diffuse;

        // Color Information
        public List<RGBA> vertColors;

        // UV Information
        public List<UV> uvs;

        // Triangle Information
        public List<Triangle> triangles;

        // Vertices Information
        public List<TVector3> vertices;

        // Normal Information
        public List<TVector3> normals;

        // Only 1 Bounding sphere in GTA
        public Sphere boundingSphere;
        public bool hasVertices; // ??? or HasVertices?
        public bool hasNormals;

        #endregion

        // CHILD SECTIONS
        public MaterialList materialList;

        // EXTENSIONS
        public BinMeshPLG binMeshPLG;
        //public NativeDataPLG nativeDataPLG;
        public SkinPLG skinPLG;
        public Breakable breakable;
        //public ExtraVertColor extraVertColor;
        public MorphPLG morphPLG;
        //public 2DEffect 2dEffect;

        //*******************************
        //          CONSTRUCTOR
        //*******************************
        public Geometry(ref BufferReader reader)
        {
            //*******************************
            //         INITIALIZE
            //*******************************
            vertColors = new List<RGBA>();
            uvs = new List<UV>();
            triangles = new List<Triangle>();
            vertices = new List<TVector3>();
            normals = new List<TVector3>();

            Header header = new Header();

            header.Read(ref reader); // GEOMETRY HEADER
            header.Read(ref reader); // STRUCT HEADER

            //*******************************
            //          GEOMETRY
            //*******************************
            flags = reader.ReadUInt16();
            numUVs = reader.ReadByte();
            if ((flags & (int)GEOMETRY_FLAGS.FLAGS_TEXTURED) != 0)
                numUVs = 1;
            hasNativeGeometry = Convert.ToBoolean(reader.ReadByte());

            numTriangles = reader.ReadInt32();
            numVertices = reader.ReadInt32();
            numMorphTargets = reader.ReadInt32();

            if (header.version < 0x34000)
            {
                ambient = reader.ReadSingle();
                specular = reader.ReadSingle();
                diffuse = reader.ReadSingle();
            }

            if (!hasNativeGeometry)
            {
                // VERTEX COLOR INFO
                if ((flags & (int)GEOMETRY_FLAGS.FLAGS_PRELIT) != 0)
                {
                    for (int i = 0; i < numVertices; i++)
                    {
                        RGBA rgba = new RGBA();

                        rgba.Red = reader.ReadByte();
                        rgba.Green = reader.ReadByte();
                        rgba.Blue = reader.ReadByte();
                        rgba.Alpha = reader.ReadByte();

                        vertColors.Add(rgba);
                    } // endfor
                } // endif

                // UVS / TEXTURED
                if ((flags & (int)GEOMETRY_FLAGS.FLAGS_TEXTURED) != 0)
                {
                    for (int i = 0; i < numVertices; i++)
                    {
                        UV uv = new UV();
                        uv.U = reader.ReadSingle();
                        uv.V = reader.ReadSingle();

                        uvs.Add(uv);
                    } // endfor
                } // endif

                // IF TEXTURED2

                // TRIANGLES
                for (int i = 0; i < numTriangles; i++)
                {
                    Triangle tri = new Triangle();

                    tri.Vertex2 = reader.ReadInt16();
                    tri.Vertex1 = reader.ReadInt16();
                    tri.MaterialId = reader.ReadInt16();
                    tri.Vertex3 = reader.ReadInt16();

                    triangles.Add(tri);
                } // endfor
            }

            // BOUNDING SPHERE - GTA 1 morph target = 1 bounding sphere
            {
                // X, Y, Z, Radius
                boundingSphere = new Sphere(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle());

                hasVertices = Convert.ToBoolean(reader.ReadInt32());
                hasNormals = Convert.ToBoolean(reader.ReadInt32());

                hasVertices = true;
                hasNormals = (flags & (int)GEOMETRY_FLAGS.FLAGS_NORMALS) != 0 ? true : false;

                if (!hasNativeGeometry)
                {
                    if (hasVertices)
                        for (int i = 0; i < numVertices; i++)
                            vertices.Add(new TVector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle()));

                    if (hasNormals)
                        for (int i = 0; i < numVertices; i++)
                            normals.Add(new TVector3(reader.ReadSingle(), reader.ReadSingle(), reader.ReadSingle()));
                } // endif
            } // end bounding sphere


            //*******************************
            //          CHILDREN
            //*******************************
            materialList = new MaterialList(ref reader);

            //*******************************
            //         EXTENSIONS
            //*******************************
            ReadExtensions(ref reader);

        } // Constructor end

        private void ReadExtensions(ref BufferReader reader)
        {
            Header header = new Header();

            header.Read(ref reader); // EXTENSION HEADER

            long end = reader.Position + header.size;

            while (reader.Position < end)
            {
                header.Read(ref reader); // ? EXTENSION HEADER

                switch (header.type)
                {
                    case ((int)CHUNK_TYPE.CHUNK_BINMESH):
                        binMeshPLG = new BinMeshPLG(ref reader);
                        break;

                    case ((int)CHUNK_TYPE.CHUNK_SKIN):
                        skinPLG = new SkinPLG(numVertices, header, ref reader);
                        break;

                    case ((int)CHUNK_TYPE.CHUNK_MORPH):
                        morphPLG = new MorphPLG(ref reader);
                        break;

                    case ((int)CHUNK_TYPE.CHUNK_BREAKABLE):
                        breakable = new Breakable(ref reader);
                        break;
                }
            }

        }
    }
}
