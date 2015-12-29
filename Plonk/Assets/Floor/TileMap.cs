using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshCollider))]
public class TileMap : MonoBehaviour
{

	public int size_x = 100;
	public int size_z = 100;
	public int tileSize = 1;
	
	// Use this for initialization
	void Start()
	{
		BuildMesh();
	}

	public void BuildMesh()
	{
		//var meshFilters = new List<MeshFilter>();
		
		//meshFilters.Add(drawBlock(0, 0, 0));
		//meshFilters.Add(drawBlock2(0, 0, 0));
		//var combine = new List<CombineInstance>();

		//foreach (var meshFilter in meshFilters)
		//{
		//	var ci = new CombineInstance
		//	{
		//		mesh = meshFilter.sharedMesh,
		//		transform = meshFilter.transform.localToWorldMatrix
		//	};
		//	combine.Add(ci);
		//}


		//mesh_filter.sharedMesh.CombineMeshes(combine.ToArray());

		var m= drawBlock(0, 0, 0);

		// Create a new Mesh and populate with the data
		Mesh mesh = new Mesh();
		mesh.vertices = m.vertices;
		mesh.triangles = m.triangles;
		mesh.normals = m.normals;
		//mesh.uv = uv;

		// Assign our mesh to our filter/renderer/collider
		MeshFilter mesh_filter = GetComponent<MeshFilter>();
		MeshRenderer mesh_renderer = GetComponent<MeshRenderer>();
		MeshCollider mesh_collider = GetComponent<MeshCollider>();

		mesh_filter.mesh = mesh;
		mesh_collider.sharedMesh = mesh;

		Debug.Log("Done Mesh!");


	//	int numTiles = size_x * size_z;
	//	int numTris = numTiles * 2;

	//	int vsize_x = size_x + 1;
	//	int vsize_z = size_z + 1;
	//	int numVerts = vsize_x * vsize_z;

	//	// Generate the mesh data
	//	Vector3[] vertices = new Vector3[numVerts];
	//	Vector3[] normals = new Vector3[numVerts];
	//	Vector2[] uv = new Vector2[numVerts];

	//	int[] triangles = new int[numTris * 3];

	//	int x, z;
	//	for (z = 0; z < vsize_z; z++)
	//	{
	//		for (x = 0; x < vsize_x; x++)
	//		{
	//			vertices[z * vsize_x + x] = new Vector3(x * tileSize, 0, z * tileSize);
	//			normals[z * vsize_x + x] = Vector3.up;
	//			uv[z * vsize_x + x] = new Vector2((float)x / vsize_x, (float)z / vsize_z);
	//		}
	//	}
	//	Debug.Log("Done Verts!");

	//	for (z = 0; z < size_z; z++)
	//	{
	//		for (x = 0; x < size_x; x++)
	//		{
	//			int squareIndex = z * size_x + x;
	//			int triOffset = squareIndex * 6;
	//			triangles[triOffset + 0] = z * vsize_x + x + 0;
	//			triangles[triOffset + 1] = z * vsize_x + x + vsize_x + 0;
	//			triangles[triOffset + 2] = z * vsize_x + x + vsize_x + 1;

	//			triangles[triOffset + 3] = z * vsize_x + x + 0;
	//			triangles[triOffset + 4] = z * vsize_x + x + vsize_x + 1;
	//			triangles[triOffset + 5] = z * vsize_x + x + 1;
	//		}
	//	}

	//	Debug.Log("Done Triangles!");

	}

	Mesh drawBlock(int x, int y, int z)
	{
		// Generate the mesh data
		Vector3[] vertices = new Vector3[8];
		Vector3[] normals = new Vector3[8];
		//Vector2[] uv = new Vector2[4];

		int[] triangles = new int[2 * 3 * 3];

		// draw top
		vertices[0] = new Vector3(0, 0, 0);
		vertices[1] = new Vector3(0 + tileSize, 0, 0);
		vertices[2] = new Vector3(0, 0, 0 - tileSize);
		vertices[3] = new Vector3(0 + tileSize, 0, 0 - tileSize);
		Debug.Log("Done Verts!");

		triangles[0] =0;
		triangles[1] =3;
		triangles[2] =2;
					  
		triangles[3] =0;
		triangles[4] =1;
		triangles[5] =3;

		normals[0] = Vector3.up;
		normals[1] = Vector3.up;
		normals[2] = Vector3.up;
		normals[3] = Vector3.up;

		//uv[0] = new Vector2(0, 1);
		//uv[1] = new Vector2(1, 1);
		//uv[2] = new Vector2(0, 0);
		//uv[3] = new Vector2(1, 0);

		// draw left
		vertices[4] = new Vector3(0, 0 - tileSize -1, 0);
		vertices[5] = new Vector3(0, 0 - tileSize-1, 0 - tileSize);

		triangles[6] =  0;
		triangles[7] =  5;
		triangles[8] =  4;

		triangles[9] = 0;
		triangles[10] = 2;
		triangles[11] = 5;

		normals[4] = Vector3.left;
		normals[5] = Vector3.left;

		// draw right
		vertices[6] = new Vector3(0, 0 - tileSize-1, 0 - tileSize);
		vertices[7] = new Vector3(0 + tileSize, 0 - tileSize-1, 0 - tileSize);

		triangles[12] =  2;
		triangles[13] =  7;
		triangles[14] =  6;

		triangles[15] =  2;
		triangles[16] =  3;
		triangles[17] =  7;

		normals[6] = Vector3.right;
		normals[7] = Vector3.right;


		// Create a new Mesh and populate with the data
		Mesh mesh = new Mesh();
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.normals = normals;
		//mesh.uv = uv;

		return mesh;
	}

	
}
