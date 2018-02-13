using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 
public class bulletgo : MonoBehaviour {
	// 弾丸の速度
	private float Espeed;
	void Start () {
		if (SceneManager.GetActiveScene ().name=="game") {
			Espeed = 100f;
		}else if (SceneManager.GetActiveScene ().name=="hard") {
			Espeed = 80f;
		}else if (SceneManager.GetActiveScene ().name=="debug") {
			Espeed = 100f;
		}
		transform.GetComponent<Renderer> ().material.color = Color.red;
		Vector3 Eforce;
		Eforce = this.gameObject.transform.forward * Espeed;
		// Rigidbodyに力を加えて発射
		transform.GetComponent<Rigidbody> ().AddForce (Eforce, ForceMode.VelocityChange);
	}
	void Update () {
	}
}