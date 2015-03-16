using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public Camera camera;
	public GameObject cameraPoint;
	public GameObject cameraPivot;
	float vertRotation = 0;
	public Vector3 startPoint;

	// Use this for initialization
	void Start () {
		startPoint = cameraPoint.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void LateUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = cameraPoint.transform.rotation * new Vector3 (moveHorizontal, 0.0f, moveVertical);

		Vector3 position = cameraPoint.transform.position;
		position += movement * camera.orthographicSize / 10;

		float maxDistance = 50;
		float distance = Vector3.Distance (position, startPoint);
		if (distance > maxDistance) {
			position = startPoint + (position - startPoint) * maxDistance / distance;
		}
		cameraPoint.transform.position = position;

		if (Input.GetMouseButton (1)) {
			float rotateHorizontal = Input.GetAxis ("Mouse X") * 5;
			float rotateVertical = Input.GetAxis ("Mouse Y") * -5;
			cameraPoint.transform.Rotate (0, rotateHorizontal, 0);
			vertRotation += rotateVertical;
			if(vertRotation > 45) {
				vertRotation = 45;
			}
			if(vertRotation < -35) {
				vertRotation = -35;
			}
			cameraPivot.transform.localRotation = Quaternion.Euler(new Vector3(vertRotation, 0, 0));
		}

		camera.orthographicSize -= Input.GetAxis ("Mouse ScrollWheel") * 10;
		if (camera.orthographicSize < 1) {
			camera.orthographicSize = 1;
		}
		if (camera.orthographicSize > 20) {
			camera.orthographicSize = 20;
		}
	}
}