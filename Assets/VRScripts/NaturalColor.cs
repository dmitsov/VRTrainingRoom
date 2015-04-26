using UnityEngine;
using System.Collections;

public class NaturalColor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(OculusScript.lookAtObject != gameObject)
			GetComponent<Renderer> ().material.color = Color.grey;
	}
}
