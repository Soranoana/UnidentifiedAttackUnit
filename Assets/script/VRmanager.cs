using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class VRmanager : MonoBehaviour {

    public GameObject[] onVrDestroy;
    public GameObject[] onNonVrDestroy;

	void Start () {
        if (XRSettings.enabled && onVrDestroy != null) { 
            for (int i = 0; i < onVrDestroy.Length; i++) {
                Destroy(onVrDestroy[i]);
                //onVrDestroy[i].gameObject.SetActive(false);
            }
        }else if (!XRSettings.enabled && onNonVrDestroy != null) { 
            for (int i = 0; i < onNonVrDestroy.Length; i++) {
                Destroy(onNonVrDestroy[i]);
                //onNonVrDestroy[i].gameObject.SetActive(false);
            }
        }
    }
}
