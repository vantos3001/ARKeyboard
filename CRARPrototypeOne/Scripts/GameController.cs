using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;



public class GameController : MonoBehaviour {

    public Text outputTextDisplay;
    private GameDataManager gameDataManager;

     public GameObject[] virtualButtonLists;

    //private VirtualButtonHandler virtualButtonHandlerLists;
	// Use this for initialization
	void Start () {
        gameDataManager = FindObjectOfType<GameDataManager>();
        outputTextDisplay.text = gameDataManager.GetOutputString();
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



    void ChangeText()
    {
        gameDataManager.SubmitNewOutputText(outputTextDisplay);
        outputTextDisplay.text = gameDataManager.GetOutputString();
    }
}
