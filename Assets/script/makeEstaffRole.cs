using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class makeEstaffRole : MonoBehaviour {
	private int makes;
	private Vector3 p;
	public GameObject Enemy; 
	private GameObject pl;
	void Start () {
		makes = 50;
		pl = GameObject.FindGameObjectWithTag ("staffRoleSafe");
	}
	void Update () {
		while (makes>0) {
			GameObject Enemys = GameObject.Instantiate (Enemy)as GameObject;
			// 弾丸の位置を調整
			while (true) {
				p.x = Random.Range (100, 400);
				p.y = Random.Range (350, 650);
				p.z = Random.Range (100, 400);
				if (Vector3.Distance (pl.transform.position, p) >= 10)
					break;
			}
			Enemys.transform.position = p;
			//前方に向ける
			Enemys.transform.LookAt (transform.position);
			makes--;
		}
	}
}