using UnityEngine;
using System.Collections;

public class CreateTiles : MonoBehaviour {
	public GameObject tile;

	// Use this for initialization
	void Start () {	
		for (int x = 0; x < 5; x ++) {
			for (int  y= 0; y < 5; y ++) {
				Instantiate (tile, new Vector3(x * 1.5f, 0f, y * 2 + x * 1), Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
