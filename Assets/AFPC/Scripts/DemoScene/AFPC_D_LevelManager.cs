using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class AFPC_D_LevelManager : MonoBehaviour {

	public AFPC_Door door;
	public string loadingSceneName;

	private int i=0;
	
	// Update is called once per frame
	void Update () {
		if (door.doorOpen && i == 0)
		{
			i = 1;
			StartCoroutine (LoadLevel());
		}
	}

	IEnumerator LoadLevel()
	{
		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene (loadingSceneName);
	}
}
