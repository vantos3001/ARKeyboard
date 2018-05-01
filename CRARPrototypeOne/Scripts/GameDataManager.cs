using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameDataManager : MonoBehaviour {

    private PlayerProgress _playerProgress;

	// Use this for initialization
	public void Awake () {
        LoadPlayerProgress();
		
	}

    public void SubmitNewOutputText(Text newOutputText)
    {
        if (newOutputText.text.Length > 18)
        {
            _playerProgress.outputString = "None";
            newOutputText.text = "None";
            SavePlayerProgress();
        }
        if (newOutputText.text != _playerProgress.outputString)
        {
            _playerProgress.outputString = newOutputText.text;
            SavePlayerProgress();
        }
    }
    public string GetOutputString()
    {
        return _playerProgress.outputString;
    }

    private void LoadPlayerProgress()
    {
        _playerProgress = new PlayerProgress();
        
        if (PlayerPrefs.HasKey("outputString"))
        {
            _playerProgress.outputString = PlayerPrefs.GetString("outputString");
        }
    }
    
    private void SavePlayerProgress()
    {
        PlayerPrefs.SetString("outputString", _playerProgress.outputString);
    }

	public static string LoadAssetText(TextAsset textAsset){
		var password = textAsset.text;
		Debug.Log ("password: " + password);

		return password;
	}
}
