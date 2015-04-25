using UnityEngine;
using System.Collections;
using Ovr;


public class OculusScript : MonoBehaviour {
	private OVRCameraRig OculusCamera = null;
	private Transform centreCameraTransform;

	void Awake () {
		OculusCamera = GetComponentsInParent<OVRCameraRig>()[0];
		centreCameraTransform = OculusCamera.centerEyeAnchor.transform;
	}

	void Start(){

	}

	void Update () {
		RaycastHit hitInfo;
		if (Physics.Raycast (centreCameraTransform.position, centreCameraTransform.forward, out hitInfo)) {
			GameObject obj = hitInfo.collider.gameObject;
			Debug.LogWarning (obj);
			if(obj.name.Equals ("Cube1")){
				Debug.LogWarning ("Cube created");
				GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
				cube.transform.position = new Vector3(obj.transform.position.x + 1.0f,obj.transform.position.y, obj.transform.position.z);
			}
		}
	}
}
