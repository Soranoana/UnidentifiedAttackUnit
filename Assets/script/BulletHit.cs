using UnityEngine;
using System.Collections;
//弾あたり判定、消滅
public class BulletHit : MonoBehaviour {
	void Start () {
	}
	void Update () {
	}
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag!="Muzzle"){
			if (col.gameObject.tag != "Player") {
				if (col.gameObject.tag != "PLbody") {
					Destroy (gameObject);
				}
			}
		}
	}
}