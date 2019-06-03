using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.SceneManagement;
using UnityEngine.XR;
//プレイヤーの移動・カメラシステム
public class PlayerMove : MonoBehaviour {
	public AudioClip se;
	Rigidbody rigid;
	private float speed;
	private Vector3 direction;
	private Vector3 was;
	private Vector3 Tpoint;

    //OVR対応
    private Vector2 moveVector = Vector2.zero;
    private Vector3 moveVector3 = Vector3.zero;
    private float moveVectorValue = 0.0f;
    private Vector2 cameraDirection = Vector2.zero;
    private float cameraDirectionValue = 0.0f;
    private bool isXr = false;

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
        
        //OVR対応
        isXr = XRSettings.enabled;
	}
	void Update ()	{
        //移動
        if (!isXr) {
            if (Input.GetKey(KeyCode.W)) {
                keyGo(transform.forward);
            }
            if (Input.GetKey(KeyCode.S)) {
                keyGo(transform.forward * -1);
            }
            if (Input.GetKey(KeyCode.D)) {
                keyGo(transform.right);
            }
            if (Input.GetKey(KeyCode.A)) {
                keyGo(transform.right * -1);
            }
        }
        //OVRInput and move
        else {
            getMoveDirection();
            getCameraDirection();
            keyGo(moveVector3 * moveVectorValue);
            moveVector = Vector2.zero;
            moveVector3 = Vector3.zero;
            moveVectorValue = 0.0f;
        }
		was = transform.position;
		
        //カメラコントロール
		if (gameObject.transform.localEulerAngles.x >= 280 || gameObject.transform.localEulerAngles.x <= 80) {
            //object上方向80度以下(240度以上)の向きまたは下方向80度の向き
            if(!isXr)gameObject.transform.Rotate (-1f * CrossPlatformInputManager.GetAxis ("Mouse Y") * 3f, 0, 0);		//マウス入力y座標でローカルx座標回転
            else gameObject.transform.Rotate(-1f * cameraDirection.y * cameraDirectionValue, 0, 0);
		}else if(gameObject.transform.localEulerAngles.x < 180){
            if (!isXr) { 
                if (CrossPlatformInputManager.GetAxis ("Mouse Y") > 0) {		//マウス入力上
				    gameObject.transform.Rotate (-1f * CrossPlatformInputManager.GetAxis ("Mouse Y") * 3f, 0, 0);		//マウス入力y座標でローカルx座標回転
			    }
            }else {
                if (cameraDirection.y > 0) {
                    gameObject.transform.Rotate(-1f * cameraDirection.y * cameraDirectionValue, 0, 0);
                }
            }
		} else if (gameObject.transform.localEulerAngles.x > 180){
            if (!isXr) { 
                if (CrossPlatformInputManager.GetAxis ("Mouse Y") < 0) {		//マウス入力下
				    gameObject.transform.Rotate (-1f * CrossPlatformInputManager.GetAxis ("Mouse Y") * 3f, 0, 0);		//マウス入力y座標でローカルx座標回転
			    }
            }else {
                if (cameraDirection.y < 0) {
                    gameObject.transform.Rotate(-1f * cameraDirection.y * cameraDirectionValue, 0, 0);
                }
            }
		}
        if (!isXr) {
            gameObject.transform.Rotate(0, CrossPlatformInputManager.GetAxis("Mouse X") * 3f, 0, Space.World);  //マウス入力x座標でワールドy座標回転
        } else {
            gameObject.transform.Rotate(0, cameraDirection.y * cameraDirectionValue, 0, Space.World);
        }
	}
	void keyGo(Vector3 trans){
        rigid.velocity = Vector3.zero;
        rigid.AddForce (trans* speed, ForceMode.VelocityChange);
		GetComponent<AudioSource> ().PlayOneShot (se);
	}

    void getMoveDirection() {
        moveVector = OVRInput.Get(OVRInput.RawAxis2D.LThumbstick);
        moveVectorValue = Vector2.Distance(Vector2.zero, moveVector) / Vector2.Distance(Vector2.zero, moveVector.normalized);
        moveVector = moveVector.normalized;
        moveVector3 = new Vector3(moveVector.x, 0, moveVector.y);
    }

    void getCameraDirection() {
        cameraDirection = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick);
        cameraDirectionValue = Vector2.Distance(Vector2.zero, cameraDirection) / Vector2.Distance(Vector2.zero, cameraDirection.normalized);
        cameraDirection = cameraDirection.normalized;
    }
}