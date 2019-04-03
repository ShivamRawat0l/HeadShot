using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class AFPC_D_LoadingScene : MonoBehaviour {
	
	public Text progressText;

	private Slider _slider;

	private void Start()
	{
		_slider = GetComponent<Slider> ();
	}

	public void LoadLevel(string sceneName)
	{
		StartCoroutine (LoadAynsc (sceneName));
	}

	IEnumerator LoadAynsc(string levelName)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync (levelName);

		while (!operation.isDone) 
		{
			float progress = Mathf.Clamp01 (operation.progress / 0.9f);
			_slider.value = progress;

			if(progressText != null)
				progressText.text = ((int)(progress*100)).ToString() + "%";

			yield return null;
		}
	}

}
