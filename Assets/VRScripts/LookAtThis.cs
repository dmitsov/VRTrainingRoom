using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class LookAtThis : BaseInputModule{
	public string ButtonsPressed = "A";

	public string ControlAxis = "Horizontal";

	private PointerEventData lookData;

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
		if (Input.GetKey(KeyCode.A)) {
			GameObject gameObj = lookData.pointerCurrentRaycast.gameObject;
			if (gameObj != null) {
				GameObject newPressedObject = ExecuteEvents.ExecuteHierarchy (gameObj, lookData, ExecuteEvents.submitHandler);
				if (newPressedObject == null) {
					newPressedObject = ExecuteEvents.ExecuteHierarchy (gameObj, lookData, ExecuteEvents.selectHandler);
				
				}
				if (newPressedObject != null) {
					eventSystem.SetSelectedGameObject (newPressedObject);
				}
			}
		}

		if (eventSystem.currentSelectedGameObject && ControlAxis != "") {
			float newAxisValue = Input.GetAxis (ControlAxis);
			if(newAxisValue > 0.01f || newAxisValue < -0.01f){
				AxisEventData axisEData = GetAxisEventData (newAxisValue,0.0f,0.0f);
				ExecuteEvents.Execute (eventSystem.currentSelectedGameObject,axisEData,ExecuteEvents.moveHandler);
			}
		}
	}
}
