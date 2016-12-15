using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

	Transform player;
	Bounds bounds;
	Camera cam;
	float height,width;

	void Start () {
		cam = Camera.main;
		height = cam.orthographicSize; 
		width = height * cam.aspect;
		bounds = GameObject.Find ("Plane").GetComponent<MeshRenderer> ().bounds;
	}
	
	// Update is called once per frame
	void Update () {
		if (player != null) {			
			transform.position = new Vector3(
				Mathf.Clamp(player.position.x, bounds.min.x + width, bounds.max.x - width),
				Mathf.Clamp(player.position.y, bounds.min.y + height, bounds.max.y - height),
				transform.position.z);
		}
	}

	public void setPlayer(Transform pl) {
		player = pl;
	}
}
