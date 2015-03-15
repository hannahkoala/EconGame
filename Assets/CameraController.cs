using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public Camera camera;
	public GameObject gameObject;
	Vector3 offset;
	float scale = 1;

	// Use this for initialization
	void Start () {
		offset = camera.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void LateUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = gameObject.transform.rotation * new Vector3 (moveHorizontal, 0.0f, moveVertical);
		gameObject.transform.position = gameObject.transform.position + movement * camera.orthographicSize / 10;

		if (Input.GetMouseButton (1)) {
			float rotateHorizontal = Input.GetAxis ("Mouse X") * 10;
			float rotateVertical = Input.GetAxis ("Mouse Y");
			gameObject.transform.Rotate (0, rotateHorizontal, 0);
		}

		camera.orthographicSize -= Input.GetAxis ("Mouse ScrollWheel") * 10;
		if (camera.orthographicSize < 3) {
			camera.orthographicSize = 3;
		}
		if (camera.orthographicSize > 20) {
			camera.orthographicSize = 20;
		}
	}
}