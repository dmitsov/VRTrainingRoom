using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class GUIBehaivourScript : MonoBehaviour{
	private RectTransform rectTransformComponent;
	private EventTrigger evTriggerComponent;

	void Awake(){
		rectTransformComponent = GetComponentInParent<RectTransform> ();
		evTriggerComponent = GetComponentInParent<EventTrigger> ();
	}

	void Start(){
		EventTrigger.Entry evEntry = new EventTrigger.Entry();
		evEntry.eventID = EventTriggerType.PointerEnter;
		evEntry.callback.AddListener ((eventData) => {ScaleCanvas(eventData);});
		evTriggerComponent.delegates.Add (evEntry);



	}

	public void ScaleCanvas(BaseEventData ed){
		rectTransformComponent.transform.localScale = rectTransformComponent.transform.localScale * 1.5f;
	}
}
