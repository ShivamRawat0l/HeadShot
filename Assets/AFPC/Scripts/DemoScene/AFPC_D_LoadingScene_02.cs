using UnityEngine;

public class AFPC_D_LoadingScene_02 : MonoBehaviour {

	public string mobileSceneName, standaloneSceneName;
	public GameObject optionHolder, progressBarHolder;
	public AFPC_D_LoadingScene _loader;

	// Use this for initialization
	void Start () 
	{
		progressBarHolder.SetActive (false);
		optionHolder.SetActive (true);
	}

	public void SwitchControl ()
	{
		optionHolder.SetActive (false);
		progressBarHolder.SetActive (true);

		if (_loader != null) {
			#if UNITY_STANDALONE || UNITY_WEBGL
			_loader.LoadLevel(standaloneSceneName);
			#endif

			#if UNITY_ANDROID || UNITY_IOS
			_loader.LoadLevel (mobileSceneName);
			#endif
		}
	}
}
