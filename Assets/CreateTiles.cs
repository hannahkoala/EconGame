using UnityEngine;
using System.Collections;

public class CreateTiles : MonoBehaviour {
	public GameObject tile;
	float sin30 = Mathf.Sin(30 * Mathf.Deg2Rad);
	float cos30 = Mathf.Cos(30 * Mathf.Deg2Rad);

	// Use this for initialization
	void Start () {	
		for (int x = 0; x < 5; x ++) {
			for (int  y= 0; y < 5; y ++) {
				Instantiate (tile, new Vector3(x * 2, 0f, x * 2 * sin30 + y * 2 * cos30), Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
