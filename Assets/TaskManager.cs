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
		activeTask = (GameObject)Resources.Load (name);
		GameObject table = GameObject.Find ("Table");
		activeTask.transform.parent = table.transform;
		activeTask.transform.position = new Vector3 (activeTask.transform.parent.position.x,
		                                            activeTask.transform.parent.position.y + Vector3.up,
		                                            activeTask.transform.parent.position.z);
		taskStatus = TaskState.Running;
	}


}

