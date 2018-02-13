using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//スコアシステム
public class Score : MonoBehaviour {
	public int score;
	private int count20; //一番有名なやつ
	private int count30; //太ってる
	private int countUFO;
	public Text scoreText;
	Text st;
	public string text;
	void Start () {
		score = 0;
		count20 = 0;
		count30 = 0;
		countUFO = 0;
	}
	void OnGUI(){
		text = "score : " + score.ToString();
	}
	void Update () {
		OnGUI ();
        Debug.Log(transform.name);
	}
	public void c10(){
		score += 10;//count10; //* 10 + count20 * 20 + count30 * 30 + countUFO * 300;
		text = "score : " + score.ToString();
	}
	public void c20(){
		count20++;
	}
	public void c30(){
		count30++;
	}
	public void cUFO(){
		countUFO++;
	}
}