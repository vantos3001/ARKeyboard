using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;



public class GameController : MonoBehaviour {

    public Text outputTextDisplay;
	// for outpitting '*'
	public Text pinCodeText;
    private GameDataManager gameDataManager;

    public GameObject[] virtualButtonLists;

	public TextAsset textAsset;

	private static string password;

	#region Properties
	public static string Password{
		get { return password;}

	}


	#endregion

    //private VirtualButtonHandler virtualButtonHandlerLists;
	// Use this for initialization
	private void Start () {
        gameDataManager = FindObjectOfType<GameDataManager>();
        outputTextDisplay.text = gameDataManager.GetOutputString();
		ChangePinCodeText ();
		password = GameDataManager.LoadAssetText (textAsset);


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
        gameDataManager.SubmitNewOutputText(outputTextDisplay);
        outputTextDisplay.text = gameDataManager.GetOutputString();
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
		outputTextDisplay.text = "Lol";
		pinCodeText.text = "Lol";
	}
}
