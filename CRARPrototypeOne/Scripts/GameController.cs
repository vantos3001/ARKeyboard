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

    //private VirtualButtonHandler virtualButtonHandlerLists;
	// Use this for initialization
	void Start () {
        gameDataManager = FindObjectOfType<GameDataManager>();
        outputTextDisplay.text = gameDataManager.GetOutputString();
		ChangePinCodeText ();
		// DON'T FOGGET TO ADD YOUR VIRTUAL BUTTON 
		// TO LIST IN GAME MANAGER!!!
        foreach (GameObject vb in virtualButtonLists)
        {
            VirtualButtonHandler vbt = vb.GetComponent<VirtualButtonHandler>();
            //VirtualButtonBehaviour vbh = vb.GetComponent<VirtualButtonBehaviour>();
            //vb.VirtualButtonHandler.OnButtonPressed(vb.VirtualButtonBehaviour).AddListener(OnGoalChangeText);
            //vbt.OnButtonPressed(vbh).AddListener(OnGoalChangeText);
            //vbt.OnGoalChangeText.AddListener(ChangeText);
            vbt.OnGoalChangeText.AddListener(ChangeText);
        }


    }
	
	// Update is called once per frame
	void Update () {
		
	}


	// DON'T FOGGET TO ADD YOUR VIRTUAL BUTTON 
	// TO LIST IN GAME MANAGER!!!
    void ChangeText()
    {			
        gameDataManager.SubmitNewOutputText(outputTextDisplay);
        outputTextDisplay.text = gameDataManager.GetOutputString();
		ChangePinCodeText ();

    }

	void ChangePinCodeText(){
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
}
