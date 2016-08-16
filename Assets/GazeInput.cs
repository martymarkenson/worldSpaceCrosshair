using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class GazeInput : PointerInputModule {
	public RaycastResult CurrentRaycast;
	private PointerEventData pointerData;
	private GameObject currentInteractable;

	public override void Process(){
		objectLook ();
		objectSelect ();
	}

	//change pointer data to the middle of the screen
	void objectLook() {
		if (pointerData == null) {
			pointerData = new PointerEventData (EventSystem.current);
		}
		pointerData.position = new Vector2(Screen.width*.5f , Screen.height*.5f);
		List<RaycastResult> raycastResults = new List<RaycastResult>();
		EventSystem.current.RaycastAll (pointerData, raycastResults);
		pointerData.pointerCurrentRaycast = FindFirstRaycast(raycastResults);
		ProcessMove (pointerData);
	}

	//if pointer is over a game object and the mouse is clicked execute pointer click on gameobject
	void objectSelect() {
		currentInteractable = pointerData.pointerCurrentRaycast.gameObject;
		if(currentInteractable!=null&&Input.GetMouseButton(0)){
			ExecuteEvents.ExecuteHierarchy(currentInteractable, pointerData, ExecuteEvents.pointerClickHandler);
		}

	}
}
