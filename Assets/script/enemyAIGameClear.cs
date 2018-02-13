using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemyAIGameClear : MonoBehaviour {
	private GameObject pl;
	void Start () {
		pl = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	void Update () {
		if (transform.position.y >= pl.transform.position.y + 30) {
			Destroy (this.gameObject);
		}
		transform.position += new Vector3 (0, 0.03f, 0);
	}
}