using UnityEngine;
using System.Collections;

public class BulletModel : MonoBehaviour {

	public float speed;
	public float damage;
	Rigidbody2D rb;
	// Use this for initialization

	void Awake() {
		rb = GetComponent<Rigidbody2D> ();
	}
		
	void OnTriggerEnter2D(Collider2D col) {
		if (col.tag == "Enemy") {
			IDamage d = (IDamage)col.gameObject.GetComponent (typeof(IDamage));
			d.Hit (damage);
			gameObject.SetActive (false);
			Destroy (gameObject);
		}
	}

	public void RelativeSpeedAdd(float s) {
		rb.velocity = transform.up * (s + speed);
	}
}
