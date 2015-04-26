using UnityEngine;
using System.Collections;

public class VideoChooser : MonoBehaviour {
	public delegate void OnLectureLoad(string name);
	public static OnLectureLoad loadDelegate;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void OnEnter(int i){
		switch (i) {
		case 0:
			loadDelegate("lecture1");
			break;
		case 1:
			loadDelegate("sample");
			break;
		}

	}
}
