using UnityEngine;
using System.Collections;
//エネミーあたり判定、消滅
public class EnemyHit : MonoBehaviour {
	public AudioClip se;
	private GameObject pl;
	public GameObject Canvas;
	GameSystem gms;
	void Start () {
	}
	void Update () {
	}
	public void OnCollisionEnter(Collision col){
		Score score = Canvas.GetComponent<Score> ();
		if (col.gameObject.tag == "Player") {
			GetComponent<AudioSource> ().PlayOneShot (se);
			Destroy (this.gameObject);
		}
		if (col.gameObject.tag == "WallObject") {
			GetComponent<AudioSource> ().PlayOneShot (se);
			Destroy (this.gameObject);
		}
		if (col.gameObject.tag == "EBullet") {
		}
		if (col.gameObject.tag == "Bullet") {
			GetComponent<AudioSource> ().PlayOneShot (se);
			score.c10();
			Destroy (this.gameObject);
		}
	}
}