using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	Transform player;
	EnemyModel model;
	Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player").transform;
		model = GetComponent<EnemyModel> ();
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 dir = (Vector2)player.position - (Vector2)transform.position;
		dir = dir.normalized;
		rb.AddForce (dir * model.speed);
		rb.AddTorque (Vector2.Dot (-transform.right, dir) * 20);
		t += Time.deltaTime;
	}

	float t;
	float cooldown = 2;

	void OnTriggerStay2D(Collider2D col) {
		if (col.tag == "Player" && t > cooldown) {
			IDamage d = (IDamage)col.gameObject.GetComponent (typeof(IDamage));
			d.Hit (model.damage);
			t = 0;
		}
	}
}
