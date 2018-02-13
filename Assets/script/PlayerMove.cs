using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement; 
//プレイヤーの移動・カメラシステム
public class PlayerMove : MonoBehaviour {
	public AudioClip se;
	Rigidbody rigid;
	private float speed;
	private Vector3 direction;
	private Vector3 was;
	private Vector3 Tpoint;
	void Start () {
		rigid = this.GetComponent<Rigidbody>();
		if (SceneManager.GetActiveScene ().name=="game") {
			speed = 40f;
		}else if (SceneManager.GetActiveScene ().name=="hard") {
			speed=30f;
		}else if (SceneManager.GetActiveScene ().name=="debug") {
			speed =45f;
		}
		was = Vector3.zero;
		Cursor.visible = false;
		Cursor.lockState =CursorLockMode.Locked;
	}
	void Update ()	{
		//移動
		rigid.velocity = Vector3.zero;
		if (Input.GetKey (KeyCode.W)) {
			keyGo (transform.forward);
		}
		if (Input.GetKey (KeyCode.S)) {
			keyGo (transform.forward * -1);
		}
		if (Input.GetKey (KeyCode.D)) {
			keyGo (transform.right);
		}
		if (Input.GetKey (KeyCode.A)) {
			keyGo (transform.right * -1);
		}
		was = transform.position;
		//カメラコントロール
		if (gameObject.transform.localEulerAngles.x >= 280 || gameObject.transform.localEulerAngles.x <= 80) {			
			//object上方向80度以下(240度以上)の向きまたは下方向80度の向き
			gameObject.transform.Rotate (-1f * CrossPlatformInputManager.GetAxis ("Mouse Y") * 3f, 0, 0);		//マウス入力y座標でローカルx座標回転
		}else if(gameObject.transform.localEulerAngles.x < 180){
			if (CrossPlatformInputManager.GetAxis ("Mouse Y") > 0) {		//マウス入力上
				gameObject.transform.Rotate (-1f * CrossPlatformInputManager.GetAxis ("Mouse Y") * 3f, 0, 0);		//マウス入力y座標でローカルx座標回転
			}
		} else if (gameObject.transform.localEulerAngles.x > 180){
			if(CrossPlatformInputManager.GetAxis ("Mouse Y") < 0) {		//マウス入力下
				gameObject.transform.Rotate (-1f * CrossPlatformInputManager.GetAxis ("Mouse Y") * 3f, 0, 0);		//マウス入力y座標でローカルx座標回転
			}
		}
		gameObject.transform.Rotate ( 0,CrossPlatformInputManager.GetAxis("Mouse X")*3f,0,Space.World);	//マウス入力x座標でワールドy座標回転
	}
	void keyGo(Vector3 trans){
		rigid.AddForce (trans* speed, ForceMode.VelocityChange);
		GetComponent<AudioSource> ().PlayOneShot (se);
	}
}