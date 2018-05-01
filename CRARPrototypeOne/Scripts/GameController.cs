using UnityEngine;
using UnityEngine.UI;
using Vuforia;

// Stable version 0.6


public class GameController : MonoBehaviour {

    public Text outputTextDisplay;
	public Text errorTextDisplay;
	// for outpitting '*'
	public Text pinCodeText;
    private GameDataManager _gameDataManager;

    public GameObject[] virtualButtonLists;

	public TextAsset textAsset;

	private static string _password;

	private DownloadManager _downloadManager;

	#region Properties
	public static string Password{
		get { return _password;}

	}


	#endregion

    //private VirtualButtonHandler virtualButtonHandlerLists;
	// Use this for initialization
	private void Start () {
		_downloadManager = FindObjectOfType<DownloadManager>();
        _gameDataManager = FindObjectOfType<GameDataManager>();
        outputTextDisplay.text = _gameDataManager.GetOutputString();
		ChangePinCodeText ();

		Invoke("ChangeToDownloadPassword", 3f);
		
		_password = GameDataManager.LoadAssetText (textAsset);

		// DON'T FOGGET TO ADD YOUR VIRTUAL BUTTON 
		// TO LIST IN GAME MANAGER!!!
        foreach (GameObject vb in virtualButtonLists)
        {
            VirtualButtonHandler vbt = vb.GetComponent<VirtualButtonHandler>();
            vbt.OnGoalChangeText.AddListener(ChangeText);
			if (vbt.CurStateVirtualButton == VirtualButtonState.CHECK) {
				vbt.OnCheckPinCode += CheckPinCode;

			}
        }


    }
	
	// DON'T FOGGET TO ADD YOUR VIRTUAL BUTTON 
	// TO LIST IN GAME MANAGER!!!
    private void ChangeText()
    {			
        _gameDataManager.SubmitNewOutputText(outputTextDisplay);
        outputTextDisplay.text = _gameDataManager.GetOutputString();
		ChangePinCodeText ();

    }

	private void ChangePinCodeText(){
		// pin code string
		int length = outputTextDisplay.text.Length;
		// calculate amount of "*"
		string strStars = "";
		for (int i = 0; i < length; i++) {
			strStars = strStars + "*";
		}
		// output pin code text
		pinCodeText.text = strStars;

	}

	private void CheckPinCode(bool isRightCode)
	{
		outputTextDisplay.text = isRightCode ? "RIGHT!" : "WRONG!";
		Invoke ("ClearOutPutTextDisplay", 1.5f);
	}

	private void ClearOutPutTextDisplay(){
		outputTextDisplay.text = "1234";
		pinCodeText.text = "1234";
	}

	private void ChangeToDownloadPassword()
	{
		var downloadPassword = _downloadManager.DownloadPassword;
		if (string.IsNullOrEmpty(downloadPassword))
		{
			return;
		}
		
		if (CheckCorrectPassword(downloadPassword))
		{
			_password = downloadPassword;
		}
		else
		{
			if(string.IsNullOrEmpty(errorTextDisplay.text))
			{
				errorTextDisplay.text = "Wrong Internet Password. Input default password";
			}
		}
	}
	
	private bool CheckCorrectPassword(string password)
	{
			int fictiveNumber;
			return password.Length == 4 && int.TryParse(password, out fictiveNumber) ;
	}
}
