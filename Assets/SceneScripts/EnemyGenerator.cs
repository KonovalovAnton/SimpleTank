using UnityEngine;
using System.Collections;

public class EnemyGenerator : MonoBehaviour {

	static Bounds b;
	int count = 10;
	public Transform o;
	// Use this for initialization
	void Start () {
		b = GetComponent<Renderer> ().bounds;
		for (int i = 0; i < count; i++) {
			float x = (Random.value * b.size.x + b.min.x) * 0.95f;
			float y = (Random.value * b.size.y + b.min.y) * 0.95f;
			Transform t = Transform.Instantiate (o, new Vector3 (x, y, 0), Quaternion.identity) as Transform;
			EnemyModel m = t.GetComponent<EnemyModel> ();
			m.size = 0.5f + Random.value * 1.5f;
			m.speed = Random.Range (2, 30);
			m.damage = Random.Range (2, 10);
			m.maxHealth = Random.Range (30, 100);
			m.health = m.maxHealth;
			m.armor = 0.5f + Random.value/2;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	public static void Rivive(EnemyModel e) {
		float x = (Random.value * b.size.x + b.min.x) * 0.95f;
		float y = (Random.value * b.size.y + b.min.y) * 0.95f;
		e.transform.position = new Vector3 (x, y, 0);
		e.health = e.maxHealth;
	}
}
