using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement; 
public class EndingPLroot : MonoBehaviour {
	private float baseSpeed;
	private float goSpeed;
	private int arrived;
	private bool role;
	private Vector3 target;
	private Vector3 current;
	private int rool;	//回転分割数
	private int Crool;	//回転量
	private int ontri;
	void Start () {
		transform.position = new Vector3 (400, 600, -50);		
		baseSpeed = 0.3f;
		goSpeed = baseSpeed;
		arrived = 0;
		//カーソル非表示
		Cursor.visible = false;
		Cursor.lockState =CursorLockMode.Locked;
		role = false;
		rool = 90;
		Crool = 0;
		ontri = 0;
	}
	void Update () {
		if (arrived == 0) {
			this.transform.position += new Vector3 (0, 0, goSpeed);
			if (transform.position.z >= 250) {
				transform.position = new Vector3 (400,600,250);
				arrived++;
			}
		}else if (arrived == 1) {
			this.transform.position += new Vector3 (-1 * goSpeed,0, 0);
			if (transform.position.x<=300) {
				transform.position = new Vector3 (300,600,250);
				arrived++;
			}
		}else if (arrived == 2) {
			this.transform.position += new Vector3 (-1 * goSpeed, -0.5f * goSpeed, 0);
			if (transform.position.x<=100) {
				transform.position = new Vector3 (100,500,250);
				arrived++;
			}
		}else if (arrived == 3) {
			this.transform.position += new Vector3 (0, 0, -1 * goSpeed);
			if (transform.position.z<= 50) {
				transform.position = new Vector3 (100,500,50);
				arrived++;
			}
		}else if (arrived == 4) {
			this.transform.position += new Vector3 (0, 0, goSpeed);
			if (transform.position.z>= 310) {
				transform.position = new Vector3 (100,500,310);
				arrived++;
			}
		}else if (arrived == 5) {
			this.transform.position += new Vector3 (0, -1 * goSpeed, 0.8f * goSpeed);
			if (transform.position.y<= 450) {
				transform.position = new Vector3 (100,450,350);
				arrived++;
			}
		}else if (arrived == 6) {
			this.transform.position += new Vector3 (goSpeed, 0, 0);
			if (transform.position.x>=400) {
				transform.position = new Vector3 (400,450,350);
				arrived++;
			}
		}else if (arrived == 7) {
			this.transform.position += new Vector3 (goSpeed, 0, 0);
			if (transform.position.x>=500) {
				arrived++;
			}
		}else if (arrived == 8) {
			//シーン切り替えタイトルへ
			//カーソル表示
			Cursor.visible = true;
			Cursor.lockState =CursorLockMode.None;
			if (SceneManager.GetActiveScene ().name == "StaffRole") {
				SceneManager.LoadScene ("GamerClear");
			} else if (SceneManager.GetActiveScene ().name == "StaffRoleCreditOnly") {
				SceneManager.LoadScene ("Title");
			}
		}
		//カメラコントロール
		if (gameObject.transform.localEulerAngles.x >= 280 || gameObject.transform.localEulerAngles.x <= 80) {			
			//object上方向80度以下(240度以上)の向きまたは下方向80度の向き
			gameObject.transform.Rotate (-1f * Input.GetAxis ("Mouse Y") * 3f, 0, 0);		//マウス入力y座標でローカルx座標回転
		}else if(gameObject.transform.localEulerAngles.x < 180){
			if (Input.GetAxis ("Mouse Y") > 0) {		//マウス入力上
				gameObject.transform.Rotate (-1f * Input.GetAxis ("Mouse Y") * 3f, 0, 0);		//マウス入力y座標でローカルx座標回転
			}
		} else if (gameObject.transform.localEulerAngles.x > 180){
			if(Input.GetAxis ("Mouse Y") < 0) {		//マウス入力下
				gameObject.transform.Rotate (-1f * Input.GetAxis ("Mouse Y") * 3f, 0, 0);		//マウス入力y座標でローカルx座標回転
			}
		}
		gameObject.transform.Rotate ( 0,Input.GetAxis("Mouse X")*3f,0,Space.World);	//マウス入力x座標でワールドy座標回転
		if (role) {
			Vector3 relativePos = target - transform.position;
			Quaternion rotation = Quaternion.LookRotation (relativePos);
			transform.rotation =rotation;
			if (rool > Crool) {
				Crool++;
			} else {
				role = false;
			}
		}
	}
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "StaffRole") {
			ontri++;
			Crool = 0;
			role = true;
			target = (GameObject.Find (col.transform.name)).GetComponent<Renderer>().bounds.center;
			goSpeed = baseSpeed / 2;
		}
	}
	void OnTriggerExit(Collider col){
		if (col.gameObject.tag == "StaffRole") {
			role = false;
			goSpeed = baseSpeed;
		}
	}
}