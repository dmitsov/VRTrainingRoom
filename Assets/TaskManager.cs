using UnityEngine;
using System.Collections;

public class TaskManager : MonoBehaviour {
	public enum TaskState
	{
		Idle,
		Running,
		Finished
	}

	private static TaskState taskStatus;
	private static GameObject activeTask;

	// Use this for initialization
	void Start () {
		StartTask ("Task1");
	}
	
	// Update is called once per frame
	void Update () {
		if (taskStatus == TaskState.Finished)
			taskStatus = TaskState.Idle;
	}

	public static GameObject GetTask(){
		return activeTask;
	}

	public static string GetTaskName(){
		return activeTask.name;
	}

	public static void EndTask(){
		activeTask = null;
		taskStatus = TaskState.Finished;
	}

	public static void StartTask(string name){
		activeTask = GameObject.Instantiate((GameObject)Resources.Load("Tasks/" + name));
		GameObject table = GameObject.Find ("Table");
		activeTask.transform.position = table.transform.position + Vector3.up + Vector3.left*0.75f;
	
		foreach (Transform tr in activeTask.GetComponentsInChildren<Transform>()) {
			if(tr.gameObject.GetComponent<Renderer>() != null)
				tr.gameObject.GetComponent<Renderer>().enabled = true;
		}

		taskStatus = TaskState.Running;
	}


}

