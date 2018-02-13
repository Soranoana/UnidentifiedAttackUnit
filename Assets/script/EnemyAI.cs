using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; 
//エネミーＡＩ
public class EnemyAI : MonoBehaviour {
	public AudioClip se;
	private int looktime;
	private int l;
	private GameObject pl;
	private Rigidbody me;
	private int flame;
	private Vector3 run;
	private int speed;
	private int hen;//8の字一辺の長さ
	private int thinkTime;//行先変更時間
	private float tokkou;//特殊攻撃を出す可能性
	private float tokkou2;//特殊攻撃2を出す可能性
	private float plattack;//プレイヤーを狙う可能性
	private GameObject target;
	private Vector3 targetPosition;//モード2用ターゲット位置記憶
	private int mode;//1 通常,2 特攻,3 特攻2
	private int modeChangeFlame;//
	private int modeChangeFlame2;//モード2から変えるまでの時間
	private int modeChangeFlame3;//モード3の持続時間
	private int modeChangeFlame4;//強制モード変更用
	void Start () {
		looktime = 20 + Random.Range (0, 100);
		l = 0;
		pl = GameObject.FindGameObjectWithTag ("Player");
		me = this.GetComponent<Rigidbody> ();
		flame = 0;
		run = Vector3.right*speed + Vector3.up*speed;
		modeChangeFlame2 = 20;
		modeChangeFlame3 = 200;
		mode = 1;
		hen = 100;
		thinkTime = 500;
		if (SceneManager.GetActiveScene ().name=="game") {
			speed = 10;
			tokkou = 10f;
			tokkou2 = 25f;
			plattack = 10f;
		}else if (SceneManager.GetActiveScene ().name=="hard") {
			speed = 20;
			tokkou = 40f;
			tokkou2 = 50f;
			plattack = 100f;
		}else if (SceneManager.GetActiveScene ().name=="debug") {
			speed = 1;
			tokkou = 20f;
			tokkou2 = 20f;
			plattack = 20f;
		}
	}
	void Update () {
		if (mode == 1) {/*通常モード*/
			if (flame % thinkTime == 0) {
				if (Random.Range (0.0f, 100.0f) <= plattack) {
					target = pl;
				} else {
					target = GameObject.FindGameObjectWithTag ("WallObject");
				}
			}
			if (looktime == l) {
				if (target == null) {
					target = pl;
				}
				transform.LookAt (target.transform.position);
				l = 0;
			}
			l++;
			/*通常移動*/
			//移動ベクトル初期化
			if (flame % hen == 0) {
				me.velocity = Vector3.zero;
			}
			//横移動
			if ((flame + hen * 2) % (hen * 4) == 0) {
				run.x *= -1;
			}
			//縦移動
			if ((flame + hen) % (hen * 2) == 0) {
				run.y *= -1;
			}
			me.AddForce (run, ForceMode.Acceleration);
			//目的地移動
			if(target==null){
				target = pl;
			}
			me.AddForce (target.transform.position.normalized*10, ForceMode.Acceleration);
			//モード選択
			if (flame % 100 == 0) {
				if (Random.Range (0.0f, 100.0f) <= tokkou) {/*通常モード以外へ*/
					if (Random.Range (0.0f, 100.0f) >= tokkou2) {/*特攻モードへ*/
						me.velocity = Vector3.zero;
						mode = 2;
						if(target==null){
							target = pl;
						}
						targetPosition = target.transform.position;
						modeChangeFlame4 = flame;
					} else {/*追尾特攻モードへ*/
						me.velocity = Vector3.zero;
						modeChangeFlame = flame;
						mode = 3;
					}
				}
			}
		} else if (mode == 2) {/*特攻モード*/
			if(target==null){
				target = pl;
			}
			//目的地に移動
			me.AddForce ((targetPosition - transform.position).normalized*10, ForceMode.VelocityChange);
			GetComponent<AudioSource> ().PlayOneShot (se);
			if (targetPosition == transform.position) {
				modeChangeFlame = flame;
			}
			if (flame - modeChangeFlame == modeChangeFlame2) {
				mode = 1;
			}
			if (flame - modeChangeFlame4 == 400) {
				mode = 1;
			}
		}else if(mode==3){/*追尾特攻モード*/
			if(target==null){
				target = pl;
			}
			//プレイヤー
			me.AddForce ((targetPosition - transform.position).normalized*10, ForceMode.Acceleration);
			GetComponent<AudioSource> ().PlayOneShot (se);
			if (flame - modeChangeFlame == modeChangeFlame3) {
				mode = 1;
			}
		}
		flame++;
	}
}