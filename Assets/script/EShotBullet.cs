using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 
//エネミー弾発射システム
public class EShotBullet : MonoBehaviour {
	public AudioClip se;
	public GameObject EBullet; 
	// 弾丸発射点
	public Transform Emuzzle;
	//弾発射間隔
	private int Edelta;
	private int EflameCount;
	void Start () {
		if (SceneManager.GetActiveScene ().name=="game") {
			Edelta = 100;
		}else if (SceneManager.GetActiveScene ().name=="hard") {
			Edelta = 80;
		}else if (SceneManager.GetActiveScene ().name=="debug") {
			Edelta = 100;
		}
		EflameCount = 0;
	}
	void Update () {
		EflameCount++;
		if (EflameCount > Edelta) {
			GetComponent<AudioSource> ().PlayOneShot (se);
			// 弾丸の複製
			Instantiate(EBullet,Emuzzle.transform.position,transform.rotation);
			EflameCount = 0;
		}
	}
}