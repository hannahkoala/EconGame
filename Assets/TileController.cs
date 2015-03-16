using UnityEngine;
using System.Collections;

public class TileController : MonoBehaviour {
	public GameObject gameObject;
	Vector3[] vertices;	
	Vector2[] uv;
	int[] triangles;
	
	public Material material;

	void Start () {
		MeshSetup();
	}

	void MeshSetup () {
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

		MeshCollider collider = gameObject.AddComponent<MeshCollider> ();
		collider.sharedMesh = mesh;
	}
	
	Vector3 HexCorner(int i) {
		float size = 1.0f;
		float angle_deg = 60 * i;
		float angle_rad = angle_deg * Mathf.Deg2Rad;
		return new Vector3 (size * Mathf.Cos (angle_rad), 0, size * Mathf.Sin (angle_rad));
	}
	void OnMouseDown() {
		Destroy(gameObject);
	}
}
