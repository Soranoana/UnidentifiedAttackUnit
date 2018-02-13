using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoadButton : MonoBehaviour {
	public void sceneLoadToNormal(){
		SceneManager.LoadScene ("game");
	}
	public void sceneLoadToHard(){
		SceneManager.LoadScene ("hard");
	}
	public void sceneLoadToDebug(){
		SceneManager.LoadScene ("debug");
	}
	public void sceneLoadToCredits(){
		SceneManager.LoadScene ("StaffRoleCreditOnly");
	}
	public void sceneLoadToYes(){
		SceneManager.LoadScene ("Title");
	}
	public void sceneLoadToNo(){
		Application.Quit();
	}
	public void sceneLoadToTitle(){
		SceneManager.LoadScene ("Title");
	}
	public void sceneLoadToGamend(){
		Application.Quit();
	}
}