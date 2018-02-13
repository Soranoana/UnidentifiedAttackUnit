using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//オブジェクトあたり判定、消滅
public class ObjectHit : MonoBehaviour {
	public AudioClip se;
	//配置
	//18
	//9-12
	//0-8
	//13-16
	//17
	private int[] a = {0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0,0,0, 0,0,0};
	void Start () {
	}
	void Update () {
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "EBullet" || col.gameObject.tag=="Enemy") {
			GetComponent<AudioSource> ().PlayOneShot (se);
			for (int i = 1; i <= 19; i++) {
				if (19 <= i) {
					childDestroy (0);
					a [0] = 1;
					Destroy (this.gameObject);
					break;
				}
				if (a [i] == 0) {
					break;
				}
			}
			while (true) {
				if (a [0] == 1) {
					break;
				}
				int Num = Random.Range(1,19);//1~18
				if (a [Num] == 0) {
					a [Num] = 1;
					childDestroy (Num);
					break;
				}
			}
		}
	}
	void childDestroy(int num){
		Destroy (gameObject.transform.Find(""+num).gameObject);
	}
}