﻿using UnityEngine;
using System.Collections;

public class CreateTiles : MonoBehaviour {
	public GameObject tileProto;

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
				GameObject tile = (GameObject) Instantiate (tileProto, new Vector3(x, 0f, y), Quaternion.identity);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit, 10f)) {
				Debug.DrawRay (ray.origin, hit.point);

				Debug.Log(hit.collider.gameObject);
			
				Destroy(hit.collider.gameObject);
			}
		}
	}
}
