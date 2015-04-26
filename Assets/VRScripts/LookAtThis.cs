using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LookAtThis : BaseInputModule{

	public string ControlAxis = "Horizontal";
	private static bool IsLookingAtGui = false;
	private static GameObject currentObj;
	private PointerEventData lookData;
	public delegate void OnEvent();
	public static OnEvent eventHandle;

	//this checks what objec is looked at
	private void GetPointerEventData(){
		Vector3 lookPoint = new Vector3();
		lookPoint.x = Screen.width * 0.5f;
		lookPoint.y = Screen.height * 0.5f;

		if (lookData == null) {
			lookData = new PointerEventData(eventSystem);
		}
		lookData.Reset();
		lookData.delta = Vector3.zero;
		lookData.position = lookPoint;
		lookData.scrollDelta = Vector3.zero;
		eventSystem.RaycastAll (lookData, m_RaycastResultCache);
		lookData.pointerCurrentRaycast = FindFirstRaycast (m_RaycastResultCache);
		m_RaycastResultCache.Clear ();
	}

	private bool SendUpdateEventToSelectedObject(){
		if (eventSystem.currentSelectedGameObject == null)
			return false;

		BaseEventData data = GetBaseEventData();
		ExecuteEvents.Execute (eventSystem.currentSelectedGameObject, data, ExecuteEvents.updateSelectedHandler);
		return data.used;
	}

	public override void Process(){
		SendUpdateEventToSelectedObject ();
		GetPointerEventData ();
		HandlePointerExitAndEnter (lookData, lookData.pointerCurrentRaycast.gameObject);
		if (!IsLookingAtGui)
			return;
		eventSystem.SetSelectedGameObject (lookData.pointerCurrentRaycast.gameObject);
		eventHandle.Invoke();
	}

	public static void SetCurrenGuiCanvas(GameObject canvas){
		currentObj = canvas;
		IsLookingAtGui = true;
	}

	public static void NullifyCurrenGuiCanvas(){
		currentObj = null;
		IsLookingAtGui = false;
	}

	public static bool isLookingAtGui(){
		return IsLookingAtGui;
	}
}