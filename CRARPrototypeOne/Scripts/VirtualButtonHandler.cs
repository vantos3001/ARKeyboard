using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using Vuforia;

public enum VirtualButtonState { ADD, DELETE, CHECK }

public class VirtualButtonHandler : MonoBehaviour, IVirtualButtonEventHandler {
    public GameObject virtualButton;
    public Text outputText;
    public char charVirtualButton;

    public UnityEvent OnGoalChangeText;

	public VirtualButtonState curStateVirtualButton = VirtualButtonState.ADD;

    // Use this for initialization

    void Start () {

        virtualButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }
	
	public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
		switch (curStateVirtualButton) {

		case VirtualButtonState.ADD:
			if (outputText.text == "None") {
				outputText.text = "Lol";
				OnGoalChangeText.Invoke ();
				return;
			} else {

				outputText.text = outputText.text + charVirtualButton.ToString ();

			}
			break;
		case VirtualButtonState.DELETE:
			int length = outputText.text.Length;
			if (length >0)
				outputText.text = outputText.text.Substring (0, length - 1);
			break;

		}
        
        OnGoalChangeText.Invoke(); 
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        

    }
}
