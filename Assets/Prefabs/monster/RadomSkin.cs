using UnityEngine;
using System.Collections;

public class RadomSkin : MonoBehaviour {

	public Sprite[] skins;
	SpriteRenderer sr;
	void Start () {
		sr = GetComponent<SpriteRenderer> ();
		sr.sprite = skins [Random.Range (0, skins.Length)];
	}

}
