using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 
//プレイヤーあたり判定、消滅
public class PlayerHit : MonoBehaviour {
	public AudioClip se;
	private int HP;
	private int Ccount;
	void Start () {
		if (SceneManager.GetActiveScene ().name=="game") {
			HP = 10;
		}else if (SceneManager.GetActiveScene ().name=="hard") {
			HP = 7;
		}else if (SceneManager.GetActiveScene ().name=="debug") {
			HP = 1000000;
		}
		Ccount = 0;
		transform.Find ("PL").gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
	}
	void Update () {
		if (HP <= 0) {
			//カーソル表示
			Cursor.visible = true;
			Cursor.lockState =CursorLockMode.None;
			//ゲームオーバー
			SceneManager.LoadScene ("GameOver");
		}
		if (Ccount>=1) {
			if (Ccount / 10 % 2 == 1) {
				transform.Find ("PL").gameObject.GetComponent<Renderer> ().material.color = Color.yellow;
			} else if (Ccount / 10 % 2 == 0) {
				transform.Find ("PL").gameObject.GetComponent<Renderer> ().material.color = Color.red;
			}
			Ccount++;
		}
		if (Ccount >= 60) {
			Ccount = 0;
		}
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Enemy") {
			GetComponent<AudioSource> ().PlayOneShot (se);
			HP--;
			transform.Find("PL").gameObject.GetComponent<Renderer> ().material.color = Color.red;
			Ccount = 1;
		}
		if (col.gameObject.tag == "EBullet") {
			GetComponent<AudioSource> ().PlayOneShot (se);
			HP--;
			transform.Find("PL").gameObject.GetComponent<Renderer> ().material.color = Color.red;
			Ccount = 1;
		}
		if (col.gameObject.tag == "boss") {
			GetComponent<AudioSource> ().PlayOneShot (se);
			HP--;
			transform.Find("PL").gameObject.GetComponent<Renderer> ().material.color = Color.red;
			Ccount = 1;
		}
	}
}
