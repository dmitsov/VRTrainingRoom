using UnityEngine;
using System.Collections;
using Ovr;


public class OculusScript : MonoBehaviour{
	private OVRCameraRig OculusCamera = null;
	private Transform centreCameraTransform;

	void Awake () {
		OculusCamera = GetComponentsInParent<OVRCameraRig>()[0];
		centreCameraTransform = OculusCamera.centerEyeAnchor.transform;
	}

	void Start(){

	}

	void Update () {

	}
}
