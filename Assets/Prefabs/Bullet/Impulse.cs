using UnityEngine;
using System.Collections;

public class Impulse : MonoBehaviour {

	public float force;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D> ().AddForce (transform.up * force);
	}
}
