using UnityEngine;
using System.Collections;

public class TankModel : MonoBehaviour, IHealth {

	public float rotationSpeed;
	public float engineForce;
	public float breakForce;
	public float maxSpeed;

	public float maxHealth;
	public float health;
	public float armor;

	public float GetPercentage() {
		return health / maxHealth;
	}
}

public interface IDamage {
	bool Hit (float damage);
}