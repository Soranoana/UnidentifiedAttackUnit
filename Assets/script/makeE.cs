using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 
//エネミー召喚システム
public class makeE : MonoBehaviour {
	public int makes;
	private Vector3 p;
	public GameObject Enemy; 
	private GameObject pl;
	void Awake () {
		if (SceneManager.GetActiveScene ().name=="game") {
			makes = 10;
		}else if (SceneManager.GetActiveScene ().name=="hard") {
			makes =Random.Range(15,21);
		}else if (SceneManager.GetActiveScene ().name=="debug") {
			makes=5;
		}
	}

    private void Start() {
        pl = GameObject.FindGameObjectWithTag("Player");
    }
    void Update () {
		while (makes>0) {
			GameObject Enemys = GameObject.Instantiate (Enemy)as GameObject;
			// 弾丸の位置を調整
			while (true) {
				p.x = Random.Range (100, 400);
				p.y = Random.Range (450, 550);
				p.z = Random.Range (100, 400);
				if (Vector3.Distance (pl.transform.position, p) >= 50)
					break;
			}
			Enemys.transform.position = p;
			//前方に向ける
			Enemys.transform.LookAt (transform.position);
			makes--;
		}
	}
}