using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 
public class BossAI : MonoBehaviour {
	public AudioClip damege;
	public AudioClip death;
	public AudioClip change;
	private int HP;
	private int flame;
	private int flameSave;
	private bool hensin;
	private bool hensin2;
	private GameObject pl;
	private Rigidbody me;
	private Vector3 target;
	private bool arrived;
	private int Ccount;
	void Start () {
		pl = GameObject.FindGameObjectWithTag ("Player");
		if (SceneManager.GetActiveScene ().name=="game") {
			HP = 50;	
		}else if (SceneManager.GetActiveScene ().name=="hard") {
			HP = Random.Range (75, 100);
		}else if (SceneManager.GetActiveScene ().name=="debug") {
			HP = 20;
		}
		this.transform.Find ("4-1").gameObject.SetActive (true);
		this.transform.Find ("4-2").gameObject.SetActive (false);
		me = this.gameObject.GetComponent<Rigidbody> ();
		flame = 0;
		hensin = false;
		hensin2 = false;
		arrived = true;
		flameSave = 0;
		transform.Find ("4-1").gameObject.GetComponent<Renderer> ().material.color = Color.gray;
		transform.Find ("4-2").gameObject.GetComponent<Renderer> ().material.color = Color.gray;
		Ccount = 0;
		GetComponent<AudioSource> ().PlayOneShot (change);
	}
	void Update () {
		if (HP <= 0) {
			GetComponent<AudioSource> ().PlayOneShot (death);
			Destroy (this.gameObject);
		}
		if (SceneManager.GetActiveScene ().name=="game") {
			if (HP <= 30 && !hensin) {
				GetComponent<AudioSource> ().PlayOneShot (change);
				transform.Find ("4-1").gameObject.SetActive (false);
				transform.Find ("4-2").gameObject.SetActive (true);
				hensin = true;
			}
			if (HP <= 10 && !hensin2) {
				GetComponent<AudioSource> ().PlayOneShot (change);
				hensin2 = true;
				flame = 0;
			}
		}else if (SceneManager.GetActiveScene ().name=="hard") {
			if (HP <= 50 && !hensin) {
				GetComponent<AudioSource> ().PlayOneShot (change);
				transform.Find ("4-1").gameObject.SetActive (false);
				transform.Find ("4-2").gameObject.SetActive (true);
				hensin = true;
			}
			if (HP <= 25 && !hensin2) {
				GetComponent<AudioSource> ().PlayOneShot (change);
				hensin2 = true;
				flame = 0;
			}
		}else if (SceneManager.GetActiveScene ().name=="debug") {
			if (HP <= 15 && !hensin) {
				GetComponent<AudioSource> ().PlayOneShot (change);
				transform.Find ("4-1").gameObject.SetActive (false);
				transform.Find ("4-2").gameObject.SetActive (true);
				hensin = true;
			}
			if (HP <= 5 && !hensin2) {
				GetComponent<AudioSource> ().PlayOneShot (change);
				hensin2 = true;
				flame = 0;
			}
		}
		if (hensin2) {
			if (flame % 100 == 0) {
				transform.Find ("4-1").gameObject.SetActive (true);
				transform.Find ("4-2").gameObject.SetActive (false);
			}else if (flame % 50 == 0) {
				transform.Find ("4-1").gameObject.SetActive (false);
				transform.Find ("4-2").gameObject.SetActive (true);
			}
		}
		if (Ccount>=1) {
			if (Ccount / 10 % 2 == 1) {
				transform.Find ("4-1").gameObject.GetComponent<Renderer> ().material.color = Color.gray;
				transform.Find ("4-2").gameObject.GetComponent<Renderer> ().material.color = Color.gray;
			} else if (Ccount / 10 % 2 == 0) {
				transform.Find ("4-1").gameObject.GetComponent<Renderer> ().material.color = Color.red;
				transform.Find ("4-2").gameObject.GetComponent<Renderer> ().material.color = Color.red;
			}
			Ccount++;
		}
		if (Ccount >= 60) {
			Ccount = 0;
		}
		if (flame - flameSave >= 400) {
			arrived = true;
		}
		if (arrived) {
			flameSave = flame;
			int gopos = Random.Range (1, 10);
			if (gopos == 1) {
				target=new Vector3(250,500,250);
				arrived = false;
			}else if (gopos == 2) {
				target=new Vector3(150,650,350);
				arrived = false;
			}else if (gopos == 3) {
				target=new Vector3(350,650,350);
				arrived = false;
			}else if (gopos == 4) {
				target=new Vector3(350,350,350);
				arrived = false;
			}else if (gopos == 5) {
				target=new Vector3(150,350,350);
				arrived = false;
			}else if (gopos == 6) {
				target=new Vector3(150,650,150);
				arrived = false;
			}else if (gopos == 7) {
				target=new Vector3(350,650,150);
				arrived = false;
			}else if (gopos == 8) {
				target=new Vector3(350,350,150);
				arrived = false;
			}else if (gopos == 9) {
				target=new Vector3(150,350,150);
				arrived = false;
			}
		}
		if (Vector3.Distance (target, transform.position)<=50) {
			arrived = true;
		}
		me.AddForce ((target - transform.position).normalized*3, ForceMode.VelocityChange);
		transform.LookAt (pl.transform.position);
		flame++;
	}
	void OnCollisionEnter(Collision col){
		if (col.gameObject.tag == "Player") {
			GetComponent<AudioSource> ().PlayOneShot (damege);
			HP = HP - 2;
			transform.Find("4-1").gameObject.GetComponent<Renderer> ().material.color = Color.red;
			transform.Find("4-2").gameObject.GetComponent<Renderer> ().material.color = Color.red;
			Ccount = 1;
		}
		if (col.gameObject.tag == "Bullet") {
			GetComponent<AudioSource> ().PlayOneShot (damege);
			HP = HP - 1;
			transform.Find("4-1").gameObject.GetComponent<Renderer> ().material.color = Color.red;
			transform.Find("4-2").gameObject.GetComponent<Renderer> ().material.color = Color.red;
			Ccount = 1;
		}
	}
}