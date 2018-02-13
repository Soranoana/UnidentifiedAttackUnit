using UnityEngine;
using System.Collections;
//エネミー弾あたり判定、消滅
public class EBulletHit : MonoBehaviour {
	private int flame; 
	void Start () {
		flame = 1;
	}
	void Update () {
		if (flame >= 1) {
			flame++;
		}
		if (flame >= 20) {
			flame = 0;
		}
	}
	void OnCollisionEnter(Collision col){
		if(col.gameObject.tag == "Player"){
			Destroy (gameObject);
		}
		if(col.gameObject.tag == "Bullet"){
			Destroy (gameObject);
		}
		if(col.gameObject.tag == "FieldWall"){
			Destroy (gameObject);
		}
		if(col.gameObject.tag == "WallObject"){
			Destroy (gameObject);
		}
		if(col.gameObject.tag == "EBullet"){
			Destroy (gameObject);
		}
		if(col.gameObject.tag == "PLbody"){
			Destroy (gameObject);
		}
		if(col.gameObject.tag == "Enemy" && flame>=10){
			Destroy (gameObject);
		}
	}
}