using UnityEngine;
using System.Collections;

public class SyncHealth : MonoBehaviour {

	Transform health;
	IHealth agent;

	// Use this for initialization
	void Start () {
		health = GetComponentInChildren<Transform> ();
		agent = GetComponentInParent<IHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		health.localScale = new Vector3 (agent.GetPercentage (), 1, 1);
	}
}

public interface IHealth {
	float GetPercentage ();
}
