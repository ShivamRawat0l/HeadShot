using UnityEngine.UI;
using UnityEngine;

public class AFPC_D_NOTFCTN : MonoBehaviour {

	public Text text;
	public string desiredText;

	private AFPC_PlayerMovement _afpcPlayer;
	private AFPC_SpawnManager _spawnMngr;

	// Use this for initialization
	void Start () {
		text.gameObject.SetActive (false);
	}

	void OnCollisionStay(Collision coll)
	{
		if (coll.gameObject.GetComponent<AFPC_PlayerMovement> () && text != null)
		{
			_afpcPlayer = coll.gameObject.GetComponent<AFPC_PlayerMovement> ();
			_spawnMngr = _afpcPlayer.GetComponent<AFPC_SpawnManager> ();
			if (_afpcPlayer.playerType == AFPC_PlayerMovement.PlayerType.rigidBodyPlayer && !_spawnMngr.HasDied) {
				text.gameObject.SetActive (true);
				text.text = desiredText;
			} else if (_afpcPlayer.playerType == AFPC_PlayerMovement.PlayerType.rigidBodyPlayer && _spawnMngr.HasDied) {
				text.gameObject.SetActive (false);
			}
		}
	}

	void OnCollisionExit()
	{
		if (_afpcPlayer != null && text != null)
		{
			if(_afpcPlayer.playerType == AFPC_PlayerMovement.PlayerType.rigidBodyPlayer && !_spawnMngr.HasDied)
				text.gameObject.SetActive (false);
			_afpcPlayer = null;
		}
	}

	void OnTriggerStay(Collider coll)
	{
		if (coll.gameObject.GetComponent<AFPC_PlayerMovement> () && text != null)
		{
			_afpcPlayer = coll.gameObject.GetComponent<AFPC_PlayerMovement> ();
			_spawnMngr = _afpcPlayer.GetComponent<AFPC_SpawnManager> ();
			if (_afpcPlayer.playerType == AFPC_PlayerMovement.PlayerType.rigidBodyPlayer && !_spawnMngr.HasDied) {
				text.gameObject.SetActive (true);
				text.text = desiredText;
			}else if (_afpcPlayer.playerType == AFPC_PlayerMovement.PlayerType.rigidBodyPlayer && _spawnMngr.HasDied) {
				text.gameObject.SetActive (false);
			}
		}
	}

	void OnTriggerExit()
	{
		if (_afpcPlayer != null && text != null)
		{
			if(_afpcPlayer.playerType == AFPC_PlayerMovement.PlayerType.rigidBodyPlayer && !_spawnMngr.HasDied)
				text.gameObject.SetActive (false);
			_afpcPlayer = null;
		}
	}
}
