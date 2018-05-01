using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class DownloadManager : MonoBehaviour
{

    private string downloadPassword;

    public string DownloadPassword
    {
        get { return downloadPassword; }
    }
    
    private void Start()
    {
        StartCoroutine(GetText());
    }


    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://pastebin.com/De8YyV7S");
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError|| string.IsNullOrEmpty(www.downloadHandler.text))
        {
            Debug.Log(www.error);
            var parentGameController = GetComponentInParent<GameController>();
            parentGameController.errorTextDisplay.text = "No internet connection or empty file. Check the connection, add password and restart the application";
        }
        else
        {
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
            ParseJsonText(results);
        }
    }

    private void ParseJsonText(byte[] resultes)
    {
        //BAD search substring in the string
        string downloadText = Encoding.UTF8.GetString(resultes);
        
        int startIndex = downloadText.IndexOf("beginarpassword", StringComparison.Ordinal);
        int endIndex = downloadText.IndexOf("endarpassword", StringComparison.Ordinal);
        string subString = downloadText.Substring(startIndex, endIndex - startIndex);
        int startSubIndex = subString.IndexOf('=');
        subString = subString.Substring(startSubIndex + 1);
        subString = subString.Trim();

        downloadPassword = subString;
    }

         
}
