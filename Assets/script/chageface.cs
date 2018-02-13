using UnityEngine;
using System.Collections;
//顔を変える、それに伴いスクリプトの取捨選択
public class chageface : MonoBehaviour {
	private int time;
	private int rand;
	void Start () {
		rand = Random.Range (1, 4);
		time = 0;
		if (rand == 1) {
			transform.Find ("1-1").gameObject.SetActive (true);
			transform.Find ("1-2").gameObject.SetActive (false);
			Destroy (transform.Find ("2-1").gameObject);
			Destroy (transform.Find ("2-2").gameObject);
			Destroy (transform.Find ("3-1").gameObject);
			Destroy (transform.Find ("3-2").gameObject);
		} else if (rand == 2) {
			Destroy (transform.Find ("1-1").gameObject);
			Destroy (transform.Find ("1-2").gameObject);
			transform.Find ("2-1").gameObject.SetActive (true);
			transform.Find ("2-2").gameObject.SetActive (false);
			Destroy (transform.Find ("3-1").gameObject);
			Destroy (transform.Find ("3-2").gameObject);
		} else if (rand == 3) {
			Destroy (transform.Find ("1-1").gameObject);
			Destroy (transform.Find ("1-2").gameObject);
			Destroy (transform.Find ("2-1").gameObject);
			Destroy (transform.Find ("2-2").gameObject);
			transform.Find ("3-1").gameObject.SetActive (true);
			transform.Find ("3-2").gameObject.SetActive (false);
		}
	}
	void Update () {
		time++;
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