using UnityEngine;
using System.Collections;
using Ovr;

public class EventCameraScript : MonoBehaviour {

	private Transform centerCameraTransform;
	// Use this for initialization
	void Start () {
		centerCameraTransform = GameObject.Find ("CenterEyeAnchor").transform;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = centerCameraTransform.rotation;
	}
}
