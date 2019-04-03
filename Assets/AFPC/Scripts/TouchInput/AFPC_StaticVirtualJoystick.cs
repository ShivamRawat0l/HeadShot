using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AFPC_StaticVirtualJoystick : AFPC_VirtualJoystick {
	
	private Vector2 _lastPos = Vector2.zero;
	// Use this for initialization
	new private void Start () {
		background.gameObject.SetActive (true);
	}

	public override void OnDrag(PointerEventData pointerEventData)
	{
		Vector2 directionOfDrag = pointerEventData.position - _lastPos;
		inputVector = (directionOfDrag.magnitude > background.sizeDelta.x / 2f) ? directionOfDrag.normalized : directionOfDrag / (background.sizeDelta.x / 2f);
		handle.anchoredPosition = (inputVector * background.sizeDelta.x / 2f) * handleMaxDistance;
	}

	public override void OnPointerUp(PointerEventData pointerEventData)
	{
		base.OnPointerUp (pointerEventData);
		inputVector = Vector2.zero;
	}

	public override void OnPointerDown(PointerEventData pointerEventData)
	{
		base.OnPointerDown (pointerEventData);
		handle.anchoredPosition = Vector3.zero;
		_lastPos = pointerEventData.position;
		OnDrag (pointerEventData);
	}
}
