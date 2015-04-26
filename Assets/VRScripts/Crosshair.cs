using UnityEngine;
using System.Collections;

public class Crosshair : MonoBehaviour {
	public Camera lookAtCamera;
	private Vector3 originScale;

	// Use this for initialization
	void Start () {
		originScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hitInfo;
		float distance;
		if (Physics.Raycast (lookAtCamera.transform.position,lookAtCamera.transform.rotation * Vector3.forward,out hitInfo)) {
			distance = hitInfo.distance;
		} else {
			distance = lookAtCamera.farClipPlane * 0.95f;
		}

		transform.position = lookAtCamera.transform.position + lookAtCamera.transform.rotation * Vector3.forward * distance;
		transform.LookAt (lookAtCamera.transform.position);
		if(distance < 10.0f){
		//	distance *= 1 + 5*Mathf.Exp(-distance);
		}

		transform.localScale = originScale * distance;

		if (LookAtThis.isLookingAtGui ()) {
			GetComponent<Renderer>().enabled = false;
		} else {
			GetComponent<Renderer>().enabled = true;
		}
	}
}
