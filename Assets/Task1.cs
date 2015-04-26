using UnityEngine;
using System.Collections;

public class Task1 : MonoBehaviour {
	public int[] states;
	private bool completed;

	private int selected;
	private ArrayList rend;
	private ArrayList childr;
	private TaskStep step;

	private enum TaskStep
	{
		Step1,
		Step2,
		Step3,
		Step4,
		Step5,
		Finished
	}

	public bool isCompleted() {
		return completed;
	}
	
	void Start () {
		step = TaskStep.Step1;
	}
	
	// Update is called once per frame
	void Update () {
		if(OculusScript.lookAtObject != null)
			OculusScript.lookAtObject.GetComponent<Renderer> ().material.color = Color.red;
	}

	public void NextStep(){
		GameObject obj = OculusScript.lookAtObject;
		if (step == TaskStep.Step1) {
			if(obj.name != "Tube2"){
				OculusScript.lookAtObject.GetComponent<Renderer>().enabled = false;
				step = TaskStep.Step2;
			}
		} else if(step == TaskStep.Step2) {		
			//prefab here
			if(obj.name == "Tube2"){

				step = TaskStep.Step3;
			}
		} else if(step == TaskStep.Step3){
			if(obj.name != "Tube2"){
				OculusScript.lookAtObject.GetComponent<Renderer>().enabled = false;
				step = TaskStep.Step4;
			}		
		} else if (step == TaskStep.Step4) {
			//prefab here
			if(obj.name == "Tube2"){	
				step = TaskStep.Step5;
			}
		} else if (step == TaskStep.Step5) {
			step = TaskStep.Finished;
			//effect
		}
	}
}
