using UnityEngine;
using System.Collections;

public class VideoControlEvents : MonoBehaviour {
	//delegate types
	public delegate void PlayDelegate();
	public delegate void PauseDelegate();
	public delegate void StopDelegate();


	public static PlayDelegate plDelegate;
	public static PauseDelegate psDelegate;
	public static StopDelegate stopDelegate;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void OnEnter(int i){
		switch (i) {
		case 0:
			plDelegate.Invoke ();
			break;
		case 1:
			psDelegate.Invoke ();
			break;
		case 2:
			stopDelegate.Invoke ();
			break;
		}
		
	}
}
