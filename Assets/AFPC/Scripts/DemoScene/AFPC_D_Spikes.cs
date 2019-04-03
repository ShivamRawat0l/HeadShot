using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AFPC_D_Spikes : MonoBehaviour {

	public float healthDecreaseDelay = 0.5f;
	public int healthToDecrease = 1;

	private float timeSinceLastCall = 0f;

	private AFPC_PlayerMovement _afpcPlayer;
	private AFPC_HealthManager _healthMngr;
	private bool colliding = false;
	void Update()
	{
		if (_afpcPlayer != null && colliding) 
		{
			timeSinceLastCall += Time.deltaTime;
			_healthMngr = _afpcPlayer.GetComponent<AFPC_HealthManager> ();
			if (timeSinceLastCall > healthDecreaseDelay)
			{
				_healthMngr.DecreaseHealth(healthToDecrease);
				timeSinceLastCall = 0f;
			}
		}
	}

	void OnCollisionExit()
	{
		if (_afpcPlayer != null)
			colliding = false;
	}
	void OnCollisionStay(Collision coll)
	{
		if (coll.collider.gameObject.GetComponent<AFPC_PlayerMovement> ())
		{
			_afpcPlayer = coll.collider.gameObject.GetComponent<AFPC_PlayerMovement> ();
			if(_afpcPlayer.playerType == AFPC_PlayerMovement.PlayerType.rigidBodyPlayer)
				colliding = true; 
		}
	}
}
