using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFPC_D_Valve : MonoBehaviour {

	public Animator anim;
	public KeyCode valveOpenKey = KeyCode.E;
	public AFPC_VirtualButton valveOpenVButton;
	public GameObject handImage;
	public float valveReachDistance;
	public AFPC_PlayerMovement afpcPlayer;

	private Animator _anim;
	private AFPC_D_Valve _valve;
	private bool valveKeyPresed;
	void GetInput()
	{
		#if UNITY_STANDALONE || UNITY_WEBGL
		if(Input.GetKeyDown(valveOpenKey) && !valveKeyPresed)
			valveKeyPresed = true;
		#endif
	
		#if UNITY_ANDROID || UNITY_IOS
		if (valveOpenVButton != null) {
		valveOpenVButton.buttonType = AFPC_VirtualButton.ButtonType.LateTriggerButton;
		valveKeyPresed = valveOpenVButton.value;
		}
		#endif
	}

	void Start()
	{
		_anim = GetComponent<Animator> ();
	}

	private bool CheckForValve()
	{
		bool value = false;
		Ray ray = afpcPlayer.fpsCamera.ViewportPointToRay (new Vector3 (0.5f, 0.5f, 0f));
		RaycastHit hit;
		if (Physics.Raycast (ray.origin, afpcPlayer.fpsCamera.transform.forward, out hit, valveReachDistance,Physics.AllLayers)) {
			if (hit.collider.gameObject.GetComponent<AFPC_D_Valve> ()) 
			{
				_valve = hit.collider.gameObject.GetComponent<AFPC_D_Valve> ();
				value = true;
				if (handImage != null)
					handImage.SetActive (true);
				if (valveOpenVButton != null)
					valveOpenVButton.gameObject.SetActive (true);
			}else
			{
				value = false;
				if(handImage != null)
					handImage.SetActive (false);
				if(valveOpenVButton != null)
					valveOpenVButton.gameObject.SetActive(false);
			}
		} else {
			value = false;
			if(handImage != null)
				handImage.SetActive (false);
			if(valveOpenVButton != null)
				valveOpenVButton.gameObject.SetActive(false);
		}
		return value;		
	}

	// Update is called once per frame
	void Update () {
		if (CheckForValve ()) 
		{
			GetInput ();
			if (valveKeyPresed && _valve != null)
			{
				OpenValve ();
				valveKeyPresed = false;
			}
		}	
	}

	void OpenValve()
	{
		if (_anim & anim != null)
		{
			_anim.SetBool ("OpenValve", true);
			anim.SetBool ("UpBars", true);
		}
	}
}
