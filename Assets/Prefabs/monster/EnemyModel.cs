using UnityEngine;
using System.Collections;

public class EnemyModel : MonoBehaviour, IHealth, IDamage {

	public float armor;
	public float health;
	public float maxHealth;

	public float speed;
	public float damage;
	public float size;

	void Start() {
		transform.localScale = new Vector3 (size, size, 1);
	}

	public float GetPercentage() {
		return health / maxHealth;
	}

	public bool Hit(float damage) {
		health -= damage * armor;
		GetComponent<Rigidbody2D> ().AddForce (-transform.up * damage * 200);
		if (health <= 0) {
			health = 0;
			EnemyGenerator.Rivive (this);
		}
			
		return health == 0;
	}
}
