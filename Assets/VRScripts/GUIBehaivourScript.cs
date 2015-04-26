using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GUIBehaivourScript : MonoBehaviour, IGuiInteractable{
	private RectTransform rectTransformComponent;
	private EventTrigger evTriggerComponent;
	private Vector3 originalScale;
	public int childCount = 0;
	private int counter = 1;

	void Awake(){
		rectTransformComponent = GetComponentInParent<RectTransform> ();
		evTriggerComponent = GetComponentInParent<EventTrigger> ();
	}

	void Start(){
		originalScale = transform.localScale;

		EventTrigger.Entry evEntry = new EventTrigger.Entry();
		evEntry.eventID = EventTriggerType.PointerEnter;
		evEntry.callback.AddListener ((eventData) => {OnEnterGui(eventData);});
		evTriggerComponent.delegates.Add (evEntry);

		evEntry = new EventTrigger.Entry();
		evEntry.eventID = EventTriggerType.PointerExit;
		evEntry.callback.AddListener ((eventData) => {OnLeaveGui(eventData);});
		evTriggerComponent.delegates.Add (evEntry);

	
	}

	public void OnEnterGui(BaseEventData ed){
		LookAtThis.SetCurrenGuiCanvas(this.gameObject);
		LookAtThis.eventHandle += OnHandleEvents;
		transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 1.25f, transform.localScale.z * 1.25f); 
		counter = 0;
		GetComponentInChildren<RectTransform> ().gameObject
			.GetComponentInChildren<RectTransform> ().gameObject.GetComponentInChildren<Text>().color = Color.blue;
	}

	public void OnLeaveGui (BaseEventData ed){
		LookAtThis.NullifyCurrenGuiCanvas();
		LookAtThis.eventHandle -= OnHandleEvents;
		transform.localScale = originalScale;
		counter = 0; 
		PaintBlackEverything();
	}

	public void OnHandleEvents(){
		
		if(Input.GetKeyUp(KeyCode.DownArrow)){
			Debug.LogWarning ("Button down");
			counter = counter >= childCount - 1 ? counter: counter + 1;
			PaintBlackEverything();
			GetComponentsInChildren<Text>()[counter].color = Color.blue;
		
		} else if(Input.GetKeyUp (KeyCode.UpArrow)){
			counter = counter <= 0 ? 0 : counter - 1;
			PaintBlackEverything();
			GetComponentsInChildren<Text>()[counter].color = Color.blue;

		} else if(Input.GetKeyUp(KeyCode.KeypadEnter)){
			if(gameObject.name == "VideoChooser")
				VideoChooser.OnEnter(counter);
			else
				VideoControlEvents.OnEnter(counter);
		}
	}

	private void PaintBlackEverything(){
		foreach (Text t in GetComponentsInChildren<Text>()) {
			t.color = Color.black;
		}
	}
}
