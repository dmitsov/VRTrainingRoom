using UnityEngine;
using System.Collections;

public class CharacterAnimation : MonoBehaviour {
	private Animator charAnim;
	private AnimationEvent eventGrab;
	public Transform bone;
	public delegate void OnNextStep ();
	public static OnNextStep nextDelegate;
	// Use this for initialization
	void Start () {
		charAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.E)) {
			Debug.LogWarning ("E pressed");
			charAnim.SetBool ("shouldGrab",true);
		}
	}

	public void OnGrab(){
		foreach (Transform tr in gameObject.GetComponentsInChildren<Transform>()) {
			if(tr.gameObject.name == "Tube1" || tr.gameObject.name == "Tube2"){
				nextDelegate.Invoke ();
			}
		}
		charAnim.SetBool ("shouldGrab",false);
	}
}
