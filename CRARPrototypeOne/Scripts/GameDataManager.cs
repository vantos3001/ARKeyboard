using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDataManager : MonoBehaviour {

    private PlayerProgress playerProgress;

	// Use this for initialization
	public void Awake () {
        LoadPlayerProgress();
		
	}

    public void SubmitNewOutputText(Text newOutputText)
    {
		Debug.Log ("submit bigin");
        if (newOutputText.text.Length > 18)
        {
            playerProgress.outputString = "None";
            newOutputText.text = "None";
            SavePlayerProgress();
        }
        if (newOutputText.text != playerProgress.outputString)
        {
            playerProgress.outputString = newOutputText.text;
            SavePlayerProgress();
			Debug.Log ("second submit choice");
        }
    }
    public string GetOutputString()
    {
        return playerProgress.outputString;
    }

    private void LoadPlayerProgress()
    {
        playerProgress = new PlayerProgress();

        if (PlayerPrefs.HasKey("outputString"))
        {
            playerProgress.outputString = PlayerPrefs.GetString("outputString");
        }
        

    }
    private void SavePlayerProgress()
    {
        PlayerPrefs.SetString("outputString", playerProgress.outputString);
    }

	public static string LoadAssetText(TextAsset textAsset){
		string password = null;
		password = textAsset.text;
		Debug.Log ("password: " + password);

		return password;
	}
	
	
}
