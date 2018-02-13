using UnityEngine;
using System.Collections;
//faceオブジェクト版あたり判定処理
public class bodyCol : MonoBehaviour {
	public GameObject Canvas;
	public GameObject parent;
	EnemyHit OnCol;
	void Start () {
	}
	void Update () {
	}
	void OnCollisionEnter(Collision col){
		Score score = Canvas.GetComponent<Score> ();
		if (col.gameObject.tag == "Player") {
			Destroy (parent);
		}
		if (col.gameObject.tag == "Bullet") {
			score.c10();
			Destroy (parent);
		}
	}
}