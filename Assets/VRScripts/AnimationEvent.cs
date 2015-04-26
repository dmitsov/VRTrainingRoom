using UnityEngine;
using System.Collections;

public class AnimationEvent : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//Animation grab event
	public static void OnGrab(){
		Debug.LogWarning ("Grabbing mode");
	}
}
