using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class tilteCamera : MonoBehaviour {
	private GameObject e41;
	private GameObject e42;
	private GameObject e31;
	private GameObject e32;
	private GameObject e21;
	private GameObject e22;
	private GameObject e11;
	private GameObject e12;
	private GameObject ePL;
	private int target;
	private int was;
	private Vector3 point;
	private bool arrived;
	private int baseSpeed;
	//private int Cspeed;
	void Start () {
		e41 = GameObject.Find ("4-1");
		e42 = GameObject.Find ("4-2");
		e31 = GameObject.Find ("3-1");
		e32 = GameObject.Find ("3-2");
		e21 = GameObject.Find ("2-1");
		e22 = GameObject.Find ("2-2");
		e11 = GameObject.Find ("1-1");
		e12 = GameObject.Find ("1-2");
		ePL = GameObject.Find ("PL");
		target = 0;
		was = target;
		arrived = true;
		baseSpeed = 5;
		//Cspeed = baseSpeed;
	}
	void Update () {
		if (arrived) {
			while (target == was) {
				target = Random.Range (0, 9);
			}
			was = target;
			arrived = false;
		}

		if (target == 0) {
			point = (ePL).GetComponent<Renderer> ().bounds.center;
		} else if (target == 1) {
			point = (e41).GetComponent<Renderer> ().bounds.center;
		} else if (target == 2) {
			point = (e42).GetComponent<Renderer> ().bounds.center;
		} else if (target == 3) {
			point = (e31).GetComponent<Renderer> ().bounds.center;
		} else if (target == 4) {
			point = (e32).GetComponent<Renderer> ().bounds.center;
		} else if (target == 5) {
			point = (e21).GetComponent<Renderer> ().bounds.center;
		} else if (target == 6) {
			point = (e22).GetComponent<Renderer> ().bounds.center;
		} else if (target == 7) {
			point = (e11).GetComponent<Renderer> ().bounds.center;
		} else if (target == 8) {
			point = (e12).GetComponent<Renderer> ().bounds.center;
		}
		point.z = transform.position.z;

		if (Vector3.Distance (transform.position, point) <= 0.1f) {
			arrived = true;
			//Cspeed = baseSpeed;
		}/*else if (Vector3.Distance (transform.position, point) <= 4) {
			Cspeed = baseSpeed / 2;
		}*/
		transform.position += (point - transform.position) / 100 * baseSpeed;
	}
}