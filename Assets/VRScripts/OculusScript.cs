using UnityEngine;
using System.Collections;
using Ovr;


public class OculusScript : MonoBehaviour{
	private OVRCameraRig OculusCamera = null;
	private Transform centreCameraTransform;
	public static GameObject lookAtObject;
	void Awake () {
		OculusCamera = GetComponentsInParent<OVRCameraRig>()[0];
		centreCameraTransform = OculusCamera.centerEyeAnchor.transform;
	}

	void Start(){

	}

	void Update () {
		RaycastHit hit;
		if (Physics.Raycast (centreCameraTransform.position, 
		                     centreCameraTransform.rotation * Vector3.forward, out hit)) {
			if(hit.collider.gameObject.name == "Tube1" || hit.collider.gameObject.name == "Tube2" 
			   		|| hit.collider.gameObject.name == "Tube3"){
				if(hit.collider.gameObject.GetComponent<Renderer>().enabled){
					lookAtObject = hit.collider.gameObject;
				} else {
					lookAtObject = null;
				}
			} else {
				lookAtObject = null;
			}
		}
	}
}
