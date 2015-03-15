using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public Camera camera;
	public GameObject cameraPoint;
	public GameObject cameraPivot;
	float vertRotation = 0;
	Quaternion pivotRotation;

	// Use this for initialization
	void Start () {
		pivotRotation = cameraPivot.transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void LateUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = cameraPoint.transform.rotation * new Vector3 (moveHorizontal, 0.0f, moveVertical);
		cameraPoint.transform.position = cameraPoint.transform.position + movement * camera.orthographicSize / 10;

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
			Debug.Log(vertRotation);
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