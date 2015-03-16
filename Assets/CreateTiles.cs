using UnityEngine;
using System.Collections;

public class CreateTiles : MonoBehaviour {
	float sin30 = Mathf.Sin(30 * Mathf.Deg2Rad);
	float cos30 = Mathf.Cos(30 * Mathf.Deg2Rad);

	//basic hexagon mesh making
	public Vector3[] vertices;	
	public Vector2[] uv;
	public int[] triangles;

	// Use this for initialization
	void Start () {	
		for (int x = 0; x < 50; x ++) {
			for (int  y= 0; y < 50; y ++) {
				if(x + y > 75 || x + y < 25) {
					continue;
				}
				float size = 1.75f;
				GameObject tile = (GameObject) Instantiate (new GameObject(), new Vector3(y * cos30 * size, 0f, x * size + y * sin30 * size), Quaternion.identity);
				MeshSetup(tile);
				if(x == 25 && y == 25) {
					Debug.Log(new Vector3(y * cos30 * size, 0f, x * size + y * sin30 * size));
				}
				//Instantiate (tile, new Vector3(x * 2, 0f, x * 2 * sin30 + y * 2 * cos30), Quaternion.identity);
			}
		}
	}
	
	void MeshSetup(GameObject gameObject)
	{
		float floorLevel = 0;


		vertices = new Vector3[6];
		for(int i = 0; i < 6; i++)
		{
			vertices[i] = HexCorner(5 - i);
		}

		
		triangles = new int[]
		{
			1,5,0,
			1,4,5,
			1,2,4,
			2,3,4
		};
		
		uv = new Vector2[]
		{
			new Vector2(0,0.25f),
			new Vector2(0,0.75f),
			new Vector2(0.5f,1),
			new Vector2(1,0.75f),
			new Vector2(1,0.25f),
			new Vector2(0.5f,0),
		};
		
		//add a mesh filter to the GO the script is attached to; cache it for later
		MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
		//add a mesh renderer to the GO the script is attached to
		gameObject.AddComponent<MeshRenderer>();
		
		//create a mesh object to pass our data into
		Mesh mesh = new Mesh();
		
		//add our vertices to the mesh
		mesh.vertices = vertices;
		//add our triangles to the mesh
		mesh.triangles = triangles;
		//add out UV coordinates to the mesh
		mesh.uv = uv;
		
		//make it play nicely with lighting
		mesh.RecalculateNormals();
		
		//set the GO's meshFilter's mesh to be the one we just made
		meshFilter.mesh = mesh;
		
		//UV TESTING
		//renderer.material.mainTexture = texture;

		
	}

	Vector3 HexCorner(int i) {
		float size = 1;
		float angle_deg = 60 * i;
		float angle_rad = angle_deg * Mathf.Deg2Rad;
		return new Vector3 (size * Mathf.Cos (angle_rad), 0, size * Mathf.Sin (angle_rad));
	}
}
