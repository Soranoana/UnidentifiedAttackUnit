using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class chagefaceGameOver : MonoBehaviour {
	private int time;
	private int rand;
	void Start () {
		rand = Random.Range (1, 6);
		time = 0;
		if (rand == 1) {
			transform.Find ("1-1").gameObject.SetActive (true);
			transform.Find ("1-2").gameObject.SetActive (false);
			Destroy (transform.Find ("2-1").gameObject);
			Destroy (transform.Find ("2-2").gameObject);
			Destroy (transform.Find ("3-1").gameObject);
			Destroy (transform.Find ("3-2").gameObject);
			Destroy (transform.Find ("4-1").gameObject);
			Destroy (transform.Find ("4-2").gameObject);
		} else if (rand == 2) {
			Destroy (transform.Find ("1-1").gameObject);
			Destroy (transform.Find ("1-2").gameObject);
			transform.Find ("2-1").gameObject.SetActive (true);
			transform.Find ("2-2").gameObject.SetActive (false);
			Destroy (transform.Find ("3-1").gameObject);
			Destroy (transform.Find ("3-2").gameObject);
			Destroy (transform.Find ("4-1").gameObject);
			Destroy (transform.Find ("4-2").gameObject);
		} else if (rand == 3) {
			Destroy (transform.Find ("1-1").gameObject);
			Destroy (transform.Find ("1-2").gameObject);
			Destroy (transform.Find ("2-1").gameObject);
			Destroy (transform.Find ("2-2").gameObject);
			transform.Find ("3-1").gameObject.SetActive (true);
			transform.Find ("3-2").gameObject.SetActive (false);
			Destroy (transform.Find ("4-1").gameObject);
			Destroy (transform.Find ("4-2").gameObject);
		} else if (rand == 4) {
			Destroy (transform.Find ("1-1").gameObject);
			Destroy (transform.Find ("1-2").gameObject);
			Destroy (transform.Find ("2-1").gameObject);
			Destroy (transform.Find ("2-2").gameObject);
			Destroy (transform.Find ("3-1").gameObject);
			Destroy (transform.Find ("3-2").gameObject);
			transform.Find ("4-1").gameObject.SetActive (true);
			Destroy (transform.Find ("4-2").gameObject);
		} else if (rand == 5) {
			Destroy (transform.Find ("1-1").gameObject);
			Destroy (transform.Find ("1-2").gameObject);
			Destroy (transform.Find ("2-1").gameObject);
			Destroy (transform.Find ("2-2").gameObject);
			Destroy (transform.Find ("3-1").gameObject);
			Destroy (transform.Find ("3-2").gameObject);
			Destroy (transform.Find ("4-1").gameObject);
			transform.Find ("4-2").gameObject.SetActive (true);
		}
	}
	void Update () {
		time++;
		if (time % 20 == 0) {
			transform.position = new Vector3 (transform.position.x, transform.position.y + 0.5f, transform.position.z);
		} else if (time % 10 == 0) {
			transform.position = new Vector3 (transform.position.x, transform.position.y - 0.5f, transform.position.z);
		}
		if (time == 60) {
			if (rand == 1) {
				transform.Find ("1-1").gameObject.SetActive (false);
				transform.Find ("1-2").gameObject.SetActive (true);
			} else if (rand == 2) {
				transform.Find ("2-1").gameObject.SetActive (false);
				transform.Find ("2-2").gameObject.SetActive (true);
			} else if (rand == 3) {
				transform.Find ("3-1").gameObject.SetActive (false);
				transform.Find ("3-2").gameObject.SetActive (true);
			}
		}
		if (time == 120) {
			if (rand == 1) {
				transform.Find ("1-2").gameObject.SetActive (false);
				transform.Find ("1-1").gameObject.SetActive (true);
			} else if (rand == 2) {
				transform.Find ("2-2").gameObject.SetActive (false);
				transform.Find ("2-1").gameObject.SetActive (true);
			} else if (rand == 3) {
				transform.Find ("3-2").gameObject.SetActive (false);
				transform.Find ("3-1").gameObject.SetActive (true);
			}
			time = 0;
		}
	}
}