using UnityEngine;
using System.Collections;

public class Track : MonoBehaviour {

	Rigidbody2D rigidBody;
	float timer;
	public Transform track;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponentInParent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//if (timer == 0) {
			foreach(Transform o in transform) {
				Transform.Instantiate (track, o.position, o.rotation);
			}
		//}
		//timer += Time.deltaTime;
		//if (timer > 0.001) {
		//	timer = 0;
		//}
	}
}
