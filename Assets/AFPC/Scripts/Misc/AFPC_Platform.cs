using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFPC_Platform : MonoBehaviour {

	private AFPC_PlayerMovement _afpcPlayer;

	void OnCollisionStay(Collision coll)
	{
		if (coll.gameObject.GetComponent<AFPC_PlayerMovement> ())
		{
			_afpcPlayer = coll.gameObject.GetComponent<AFPC_PlayerMovement> ();
			_afpcPlayer.gameObject.transform.SetParent (this.transform, true);
		}
	}

	void OnCollisionExit(Collision coll)
	{
		if (_afpcPlayer != null) 
		{
			_afpcPlayer.transform.SetParent (null, true);
			_afpcPlayer = null;
		}
	}

}
