using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BottunSE : MonoBehaviour {
	public AudioClip se;
	void Start () {
	}
	void Update () {
	}
	public void OnMouseEnter(){
		GetComponent<AudioSource> ().PlayOneShot (se);
	}
}