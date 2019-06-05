using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRUI : MonoBehaviour {

    private Color defoColor = new Color(255, 255, 255, 128);
    private Color selectColor = new Color(255, 255, 255, 255);
    private Color defineColor = new Color(255, 0, 0, 255);
    private Material myMaterial;

	void Start () {
        myMaterial = GetComponent<Material>();
	}
	
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other) {
        //if (other.tag == "UIrazer") {
            //色を濃くする
            myMaterial.color = selectColor;
        //}
    }

    public void OnTriggerExit(Collider other) {
        //if (other.tag == "UIrazer") {
            //色を薄くする
            myMaterial.color = defoColor;
        //}
    }

    public void OnTriggerStay(Collider other) {
        //if (other.tag == "UIrazer") {
            //押されたら色を変更、実行する
            /**if ((OVRInput.GetDown(OVRInput.RawButton.LHandTrigger) && other.name == "UIrazerL") ||
                (OVRInput.GetDown(OVRInput.RawButton.RHandTrigger) && other.name == "UIrazerR")) {
                myMaterial.color = defineColor;
                doOwnEffect();
            }*/
        //}
    }

    private void doOwnEffect() {
        string myName = transform.name;
        if (myName == "CubeUINormal") {
            GetComponent<SceneLoadButton>().sceneLoadToNormal();
        }else if (myName == "CubeUIHard") {
            GetComponent<SceneLoadButton>().sceneLoadToHard();
        }else if (myName == "CubeUIDebug") {
            GetComponent<SceneLoadButton>().sceneLoadToDebug();
        }else if (myName == "CubeUIStaff") {
            GetComponent<SceneLoadButton>().sceneLoadToCredits();
        }else if (myName == "CubeUIExit") {
            GetComponent<SceneLoadButton>().sceneLoadToGamend();
        }else if (myName == "CubeUIGoTitle") {
            GetComponent<SceneLoadButton>().sceneLoadToTitle();
        }else if (myName == "CubeUIYes") {
            GetComponent<SceneLoadButton>().sceneLoadToYes();
        }else if (myName == "CubeUINo") {
            GetComponent<SceneLoadButton>().sceneLoadToNo();
        }else {
            //error
        }
    }
}
