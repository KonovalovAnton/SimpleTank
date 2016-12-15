using UnityEngine;
using System.Collections;

public class LifeTime : MonoBehaviour {

	public float lifeTime;
	public bool transparent;
	float t;
	SpriteRenderer drawer;

	// Use this for initialization
	void Start () {
		drawer = GetComponent<SpriteRenderer> ();		
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		if (transparent) {
			drawer.color = new Color (drawer.color.r, drawer.color.g, drawer.color.b, 1 - t / lifeTime);
		} 
		if (t > lifeTime) {
			Destroy (gameObject);
		}
	}
}
