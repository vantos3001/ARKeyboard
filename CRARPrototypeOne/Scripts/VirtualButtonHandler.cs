using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Vuforia;

public class VirtualButtonHandler : MonoBehaviour, IVirtualButtonEventHandler {
    public GameObject virtualButton;
    public Text outputText;
    public char charVirtualButton;

    public UnityEvent OnGoalChangeText;

    // Use this for initialization

    void Start () {

        virtualButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }
	
	public void OnButtonPressed(VirtualButtonBehaviour vb)
    {

        if (outputText.text == "None")
        {
            outputText.text = "Lol";
            OnGoalChangeText.Invoke();
            return;
        }
        else
        {

            outputText.text = outputText.text + charVirtualButton.ToString();
            
        }
        OnGoalChangeText.Invoke(); 
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        

    }
}
