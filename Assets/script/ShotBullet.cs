using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 
//弾発射システム
public class ShotBullet : MonoBehaviour {
	public AudioClip se;
	public GameObject Bullet; 
	// 弾丸発射点
	public Transform muzzle;
	// 弾丸の速度
	private float speed;
	//弾発射間隔
	private int delta;
	private int flameCount;
	void Start () {
		if (SceneManager.GetActiveScene ().name=="game") {
			Debug.Log ("game");
			speed = 50;
			delta = 15;
		}else if (SceneManager.GetActiveScene ().name=="hard") {
			speed = 40;
			delta = 20;
		}else if (SceneManager.GetActiveScene ().name=="debug") {
			speed = 70;
			delta = 1;
		}else {
			speed = 50;
			delta = 15;
		}
		flameCount = delta;
	}
	void Update () {
		flameCount++;
		if (flameCount >= delta) {
			// z キーが押された時
			if (Input.GetKeyDown (KeyCode.Space)) {
				GetComponent<AudioSource> ().PlayOneShot (se);
				// 弾丸の複製
				GameObject Bullets = GameObject.Instantiate (Bullet)as GameObject;
				Bullets.GetComponent<Renderer> ().material.color = Color.red;
				// 弾丸の位置を調整
				Bullets.transform.position = muzzle.position;
				//前方に向ける
				Bullets.transform.LookAt (muzzle.position + transform.forward);
				Bullets.name = "Bullet" + flameCount;
				Vector3 force;
				force = this.gameObject.transform.forward * speed;
				// Rigidbodyに力を加えて発射
				Bullets.GetComponent<Rigidbody> ().AddForce (force, ForceMode.VelocityChange);
				flameCount = 0;
			}
			// マウス左クリックされた時
			if (Input.GetButtonDown ("Fire1")) {
				// 弾丸の複製
				GameObject Bullets = GameObject.Instantiate (Bullet)as GameObject;
				Bullets.GetComponent<Renderer> ().material.color = Color.red;
				// 弾丸の位置を調整
				Bullets.transform.position = muzzle.position;
				//前方に向ける
				Bullets.transform.LookAt (muzzle.position + transform.forward);
				Bullets.name = "Bullet" + flameCount;
				Vector3 force;
				force = this.gameObject.transform.forward * speed;
				// Rigidbodyに力を加えて発射
				Bullets.GetComponent<Rigidbody> ().AddForce (force, ForceMode.VelocityChange);
				flameCount = 0;
			}
		}
	}
}