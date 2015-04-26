using UnityEngine;
using System.Collections;

public class Task1 : MonoBehaviour {
	public int[] states;
	private bool completed;

	private int selected;
	private ArrayList rend;
	private ArrayList childr;

	public bool isCompleted() {
		return completed;
	}
	
	void Start () {
		/*
		Task1 states:
			0 -> Tube 1 picked up
			1 -> Tube 2 picked up
			2 -> Tube 1 poured into Tube 3
			3 -> Tube 2 into Tube 3
		*/
		states = new int[]{0, 0, 0, 0};
		completed = false;
		selected = 0;

		childr = new ArrayList();
		int cPos = 0;
		foreach(Transform child in transform) {
			childr.Add(child.gameObject);
			cPos++;
		}

		rend = new ArrayList ();
		foreach(Renderer r in GetComponentsInChildren<Renderer>()) {
			rend.Add(r);
		}
		((Renderer)rend[selected]).material = (Material)Resources.Load ("Materials/Selected");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Horizontal")) {
			((Renderer)rend[selected]).material = (Material)Resources.Load ("Materials/TubeMaterial");
			if(Input.GetAxis ("Horizontal") > 0) {
				selected--;
				if(selected < 0) {
					selected = rend.Count - 1;
				}
			}
			else {
				selected++;
				if(selected > rend.Count - 1){
					selected = 0;
				}
			}

			((Renderer)rend[selected]).material = (Material)Resources.Load ("Materials/Selected");
		}
		else if(Input.GetButtonDown("Jump")) {
			string objectName = ((Renderer)rend[selected]).gameObject.name;

			if(objectName.Equals("Tube1") && states[1] == 0) {
				((Renderer)rend[selected]).material = (Material)Resources.Load ("Materials/TubeMaterial");
				rend.RemoveAt(selected);

				Vector3 tempPos = ((GameObject)childr[selected]).GetComponent<Transform>().position;
				tempPos.y += 0.1f;
				((GameObject)childr[selected]).GetComponent<Transform>().position = tempPos;

				selected++;
				if(selected > rend.Count - 1){
					selected = rend.Count - 1;
				}
				((Renderer)rend[selected]).material = (Material)Resources.Load ("Materials/Selected");
				states[0] = 1;
			}
			else if(objectName.Equals("Tube2") && states[0] == 0) {
				((Renderer)rend[selected]).material = (Material)Resources.Load ("Materials/TubeMaterial");
				rend.RemoveAt(selected);
				
				Vector3 tempPos = ((GameObject)childr[selected]).GetComponent<Transform>().position;
				tempPos.y += 0.1f;
				((GameObject)childr[selected]).GetComponent<Transform>().position = tempPos;
				
				selected++;
				if(selected > rend.Count - 1){
					selected = rend.Count - 1;
				}

				((Renderer)rend[selected]).material = (Material)Resources.Load ("Materials/Selected");
				states[1] = 1;
			}
			else if(objectName.Equals("Tube3")) {
				if(states[0] == 1) {

				}
				else if(states[1] == 1) {

				}
			}
		}
		foreach (Transform tr in GetComponentsInChildren<Transform>()) {
			if(OculusScript.lookAtObject != tr.gameObject){
				tr.position = new Vector3(tr.position.x, transform.position.y,tr.position.z);
			}
		}

	}
}
