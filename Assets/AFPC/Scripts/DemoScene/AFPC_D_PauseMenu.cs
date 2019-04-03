using UnityEngine.UI;
using UnityEngine;

public class AFPC_D_PauseMenu : MonoBehaviour {

	public AFPC_WaterZone waterZone;
	public KeyCode pauseKey = KeyCode.Escape;
	public AFPC_VirtualButton pauseVButton;
	public GameObject pausePanel;
	public AFPC_PlayerMovement afpcPlayer;
	public Toggle underWaterEffectToggle, invertMouseToggle;
	public RectTransform generalSettingsHolder, controlsHolder;
	public Slider volumeSlider, cameraSenstivitySlider;
	public Dropdown playerTypeDropdown;

	private bool pausePressed;
	private bool gamePaused = false;
	// Use this for initialization
	void Start ()
	{
		pausePanel.SetActive (false);	
		if(pauseVButton != null)
			pauseVButton.buttonType = AFPC_VirtualButton.ButtonType.LateTriggerButton;

		if (underWaterEffectToggle != null && volumeSlider != null && cameraSenstivitySlider != null && playerTypeDropdown != null && invertMouseToggle != null)
		{
			underWaterEffectToggle.isOn = afpcPlayer.fpsCamera.GetComponent<AFPC_Cam> ().useUnderwaterImageEffects;
			invertMouseToggle.isOn = afpcPlayer.fpsCamera.GetComponent<AFPC_Cam> ().invertMouse;
			volumeSlider.value = AudioListener.volume;
			cameraSenstivitySlider.value = afpcPlayer.fpsCamera.GetComponent<AFPC_Cam> ().xlookSenstivity;
			playerTypeDropdown.value = (int)afpcPlayer.playerType;
		}
	}

	public void InvertMouseLook()
	{
		afpcPlayer.fpsCamera.GetComponent<AFPC_Cam> ().invertMouse = invertMouseToggle.isOn;
	}
	public void OpenGeneralSettings()
	{
		if (controlsHolder != null)
			controlsHolder.gameObject.SetActive (false);
		if (generalSettingsHolder != null)
			generalSettingsHolder.gameObject.SetActive (true);
	}

	public void ChangeFogMode(Dropdown underFogModeDropDown)
	{
		waterZone.fogMode = (FogMode)underFogModeDropDown.value;
	}

	public void ChangeFogDensity(Slider fogDensitySlider)
	{
		waterZone.fogDensity = fogDensitySlider.value;	
	}

	public void OpenControls()
	{
		if (generalSettingsHolder != null)
			generalSettingsHolder.gameObject.SetActive (false);
		if (controlsHolder != null)
			controlsHolder.gameObject.SetActive (true);
	}

	public void QuitGame()
	{
		Application.Quit ();	
	}

	public void EnablePostProccessing()
	{
		
		afpcPlayer.fpsCamera.GetComponent<AFPC_Cam> ().useUnderwaterImageEffects = underWaterEffectToggle.isOn;
	}

	public void Back()
	{
		UnPauseGame ();
	}

	public void ChangeCamSenstivity()
	{
		afpcPlayer.fpsCamera.GetComponent<AFPC_Cam> ().xlookSenstivity = cameraSenstivitySlider.value;
		afpcPlayer.fpsCamera.GetComponent<AFPC_Cam> ().ylookSenstivity = cameraSenstivitySlider.value;
	}

	public void ChangePlayerType()
	{
		afpcPlayer.playerType = (AFPC_PlayerMovement.PlayerType)playerTypeDropdown.value;
	}

	public void ChangeGlobalVolume()
	{
		AudioListener.volume = volumeSlider.value;
	}

	void PauseGame()
	{
		gamePaused = true;
		pausePanel.SetActive (true);
		Time.timeScale = 0f;
	}

	void UnPauseGame()
	{
		gamePaused = false;
		pausePanel.SetActive (false);
		Time.timeScale = 1f;
	}

	void GetInput()
	{
		
		#if UNITY_STANDALONE || UNITY_WEBGL
			if(Input.GetKeyDown(pauseKey) && !pausePressed)
				pausePressed = true;
		#endif

		#if UNITY_ANDROID || UNITY_IOS
			if(pauseVButton != null)
				pausePressed = 	pauseVButton.value;
		#endif
	}
	// Update is called once per frame
	void Update () 
	{
		GetInput ();	
		if (pausePressed)
		{
			if (!gamePaused) 
				PauseGame ();
			else
				UnPauseGame ();
			pausePressed = false;
		}
	}
}
