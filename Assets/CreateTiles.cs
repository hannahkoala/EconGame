using UnityEngine;
using System.Collections;

public class CreateTiles : MonoBehaviour {

	//basic hexagon mesh making
	public Vector3[] vertices;	
	public Vector2[] uv;
	public int[] triangles;

	public Material material;

	// Use this for initializationMaterial mat;
	void Start()
	{
		for (int q = 0; q < 50; q ++) {
			for (int  r= 0; r < 50; r ++) {
				if(q + r >= 75 || q + r < 25) {
					continue;
				}
				float size = 1f;
				float x = size * 3f/2 * q;
				float y = size * Mathf.Sqrt(3) * (r + q/2f);
				GameObject tile = (GameObject) Instantiate (new GameObject(), new Vector3(x, 0f, y), Quaternion.identity);
				MeshSetup(tile);
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
			new Vector2(0.25f,    0),
			new Vector2(0.75f,    0),
			new Vector2(    1, 0.5f),
			new Vector2(0.75f,    1),
			new Vector2(0.25f,    1),
			new Vector2(    0, 0.5f),
		};
		
		//add a mesh filter to the GO the script is attached to; cache it for later
		MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
		//add a mesh renderer to the GO the script is attached to
		Renderer renderer = gameObject.AddComponent<MeshRenderer>();
		
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
		renderer.material = material;

		if (Random.value < 0.5) {
			gameObject.transform.localScale = new Vector3(1, 1, -1);
		}
		float rotation = (int)(Random.value * 6) * 60;
		Debug.Log (rotation);
		gameObject.transform.Rotate (new Vector3 (0, rotation, 0));
		
	}

	Vector3 HexCorner(int i) {
		float size = 1.01f;
		float angle_deg = 60 * i;
		float angle_rad = angle_deg * Mathf.Deg2Rad;
		return new Vector3 (size * Mathf.Cos (angle_rad), 0, size * Mathf.Sin (angle_rad));
	}
}
