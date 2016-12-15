using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour, IDamage {

	const float K = 100;

	public CameraFollow cam;
	public Animator moveAnimator;
	public Animator shooter;
	public GameObject[] guns;
	public Transform[] bullets;

	Rigidbody2D rigidBody;
	TankModel model;

	float gas;
	float rotor;
	int gunIndex;
	public float cooldown;
	float cooltime;

	public bool Hit(float damage) {
		model.health -= damage * model.armor;
		if (model.health < 0) {
			model.health = 0;
		}
		return model.health == 0;
	}

	void Start () {
		cam.setPlayer (this.transform);
		rigidBody = GetComponent<Rigidbody2D> ();
		model = GetComponent<TankModel> ();

		if (guns.Length == 0 || guns.Length != bullets.Length) {
			throw new UnityException ("no weapons on Player or bullets does not match!");
		}
		gunIndex = 0;
	}

	void Update () {
		PlayerInput ();
		ChangeGun ();
		Shoot ();
	}

	void FixedUpdate() {
		PlayerGo ();
		PlayerRotate ();
	}

	private void PlayerInput() {
		gas = Input.GetAxis("Vertical");
		rotor = Input.GetAxis("Horizontal");
	}

	private void Shoot() {
		if (Input.GetKey (KeyCode.X) && cooltime > cooldown) {
			shooter.SetBool ("Shooting", true);
			foreach(Transform o in guns[gunIndex].transform) {
				Transform b = Transform.Instantiate (bullets[gunIndex], o.position, o.rotation) as Transform;
				b.GetComponent<BulletModel> ().RelativeSpeedAdd(rigidBody.velocity.magnitude);
			}
			cooltime = 0;
		}

		if (Input.GetKeyUp (KeyCode.X)) {
			shooter.SetBool ("Shooting", false);
		}

		cooltime += Time.fixedDeltaTime;
	}

	private void PlayerGo() {
		if (gas > 0) {
			rigidBody.AddForce (Time.fixedDeltaTime * K *
				gas * transform.up * model.engineForce);
		} 
		else {
			rigidBody.AddForce (Time.fixedDeltaTime * K * 
				gas * transform.up * model.breakForce);
		}

		moveAnimator.SetFloat ("Velocity", rigidBody.velocity.magnitude / model.maxSpeed);
	}

	private void PlayerRotate() {
		rigidBody.MoveRotation (rigidBody.rotation - rotor * model.rotationSpeed * Time.fixedDeltaTime * K);	
		//transform.Rotate (0, 0, -rotor * model.rotationSpeed);
	}

	private void ChangeGun() {
		if (Input.GetKeyUp (KeyCode.Q)) {
			if (gunIndex == 0)
				gunIndex = guns.Length - 1;
			else
				gunIndex--;
		} else if (Input.GetKeyUp (KeyCode.E)) {
			if (gunIndex == guns.Length - 1) {
				gunIndex = 0;
			} else {
				gunIndex++;
			}
		}

		for (int i = 0; i < guns.Length; i++) {
			if (i == gunIndex) {
				guns [i].SetActive (true);
			} else {
				guns [i].SetActive (false);
			}
		}
	}

}
	
