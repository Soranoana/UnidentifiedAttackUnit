using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class VRmanager : MonoBehaviour {

	void Start () {
        if (SceneManager.GetActiveScene().name=="debug"             ||
            SceneManager.GetActiveScene().name=="game"              ||
            SceneManager.GetActiveScene().name=="hard"              ||
            SceneManager.GetActiveScene().name=="StaffRole"         ||
            SceneManager.GetActiveScene().name=="StaffRoleCreditOnly") {
            XRSettings.enabled=true;
        } else {
            XRSettings.enabled=false;
        }
        if (XRSettings.enabled) {
            InputTracking.Recenter();
            InputTracking.disablePositionalTracking=true;
            XRDevice.SetTrackingSpaceType(TrackingSpaceType.Stationary);
        }
    }

    void Update () {
        this.gameObject.transform.localPosition=Vector3.zero;
    }
}
