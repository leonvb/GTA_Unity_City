using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GTAImgEditor;
using System.IO;

public class GameLoader : MonoBehaviour
{
    IDE IDECollection;
    IPL IPLCollection;
    Dictionary<string, ArchiveFile> ModelCollection = new Dictionary<string, ArchiveFile>();

    List<GameObject> gameObjects = new List<GameObject>();

    List<string> mapAreasToLoad = new List<string>(){
        "littleha",
        "downtown",
        "downtows",
        "docks",
        "washintn",
        "washints",
        "oceandrv",
        "oceandn",
        "golf",
        "bridge",
        "starisl",
        "nbeachbt",
        "nbeach",
        "nbeachw",
        "cisland",
        "airport",
        "airportN",
        "haiti",
        "haitin",
        "islandsf",
        "stadint"
    };

    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("Loading... " + DateTime.Now);

            try
            {
                IDECollection = new IDE();
                IPLCollection = new IPL();
                ModelCollection.Clear();

                CleanUpModels();

                DAT dat = new DAT(Path.Combine(GTASettings.gta_path, GTASettings.gta_dat_path));
                IMG img = new IMG();

                List<string> IDEsToLoad = new List<string>() { "generic.IDE" };
                List<string> IPLsToLoad = new List<string>();

                foreach (string area in mapAreasToLoad)
                {
                    IDEsToLoad.Add(area + ".IDE");
                    IPLsToLoad.Add(area + ".IPL");
                }

                // Load the IDE files required for the IPL and join them into one IDE
                foreach (string ideFilename in IDEsToLoad)
                {
                    string ideFilepath = dat.IDE_paths[ideFilename];
                    IDE ide = new IDE(ideFilepath);
                    IDECollection.Join(ide);
                }

                // Load the IPLs wished to instantiate
                foreach (string iplFilename in IPLsToLoad)
                {
                    string iplFilepath = dat.IPL_paths[iplFilename];
                    IPL ipl = new IPL(iplFilepath);
                    IPLCollection.Join(ipl);
                }

                // Load the models for the IPL to use
                foreach (objs obj in IDECollection.obj_list)
                {
                    if (!ModelCollection.ContainsKey(obj.modelName))
                    {
                        ArchiveFile model = img.GetFileByName(obj.modelName + ".dff");
                        ModelCollection.Add(obj.modelName, model);
                    }
                }

                foreach (tobj tobj in IDECollection.tobj_list)
                {
                    if (!ModelCollection.ContainsKey(tobj.modelName))
                    {
                        ArchiveFile model = img.GetFileByName(tobj.modelName + ".dff");
                        ModelCollection.Add(tobj.modelName, model);
                    }
                }

                Debug.Log(ModelCollection.Count);

                // Instantiate the models
                foreach (inst inst in IPLCollection.inst_list)
                {
                    ArchiveFile model = ModelCollection[inst.modelName];
                    DFF dff = new DFF(model.ByteBuffer);
                    InstantiateModel(dff, inst);
                }
            }
            catch (System.Exception e)
            {
                throw e;
            }

            Debug.Log("Success " + DateTime.Now);
        }
    }

    private void CleanUpModels()
    {
        // Later call a function so the instance clears all its own children then clears all the parents from the list.
        // Because some models, like cars, have more than one geometry
        foreach (GameObject go in gameObjects)
        {
            Destroy(go);
        }

        gameObjects.Clear();
    }

    private void InstantiateModel(DFF dff, inst info)
    {
        GeometryList geoList = dff.Clump.geometryList;

        int numGeometries = Convert.ToInt32(geoList.geometryCount);

        List<Mesh> meshes = new List<Mesh>();

        for (int i = 0; i < numGeometries; i++)
        {
            List<Vector3> vertices = new List<Vector3>();
            List<int> triangles = new List<int>();
            List<Vector2> uvs = new List<Vector2>();

            int numVerts = geoList.geometries[i].numVertices;
            int numTris = geoList.geometries[i].numTriangles;

            // Vertices
            foreach (var vertex in geoList.geometries[i].vertices)
            {
                vertices.Add(new Vector3(vertex.X, vertex.Y, vertex.Z));
            }

            // Triangles
            foreach (var triangle in geoList.geometries[i].triangles)
            {
                List<int> tris = new List<int>();
                tris.Add(triangle.Vertex1);
                tris.Add(triangle.Vertex2);
                tris.Add(triangle.Vertex3);

                triangles.AddRange(tris);
            }

            // UVs
            foreach (var uv in geoList.geometries[i].uvs)
            {
                uvs.Add(new Vector2(uv.U, uv.V));
            }

            // Create the mesh
            Mesh mesh = new Mesh();
            mesh.vertices = vertices.ToArray();
            mesh.triangles = triangles.ToArray();
            mesh.uv = uvs.ToArray();
            mesh.RecalculateNormals();
            mesh.RecalculateBounds();

            meshes.Add(mesh);
        }

        foreach (Mesh mesh in meshes)
        {
            GameObject obj = new GameObject(info.modelName);

            obj.AddComponent<MeshFilter>();
            obj.AddComponent<MeshRenderer>();

            obj.GetComponent<MeshFilter>().mesh = mesh;

            obj.transform.position = new Vector3(info.posX, info.posY, info.posZ);
        }
    }
}
