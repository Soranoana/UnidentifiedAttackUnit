using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class enemySpawnGameClear : MonoBehaviour {
	private int makes;
	private Vector3 p;
	public GameObject Enemy; 
	private Vector3 target;
	private int EnemyCount;
	GameObject[] enemyObjects;
	private GameObject pl;
	void Start () {
		makes = 8;
		pl = GameObject.FindGameObjectWithTag ("MainCamera");
	}
	void Update () {
		//エネミー数カウント
		enemyObjects = GameObject.FindGameObjectsWithTag ("Enemy");
		EnemyCount = enemyObjects.Length;
		if (EnemyCount < makes) {
			GameObject Enemys = GameObject.Instantiate (Enemy)as GameObject;
			// 弾丸の位置を調整
			while (true) {
				p.x = Random.Range (-30, 30);
				p.y = Random.Range (-10, 10);
				p.z = Random.Range (0, 30);
				if (Vector2.Distance(new Vector2(p.x,p.z),new Vector2(pl.transform.position.x,pl.transform.position.z))>5)
					break;
			}
			Enemys.transform.position = pl.transform.position + p;
			//前方に向ける
			target = pl.transform.position;
			target.y = transform.position.y + 1;
			Enemys.transform.LookAt (target);
		}
	}
}