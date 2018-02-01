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

	[SerializeField]
	private VirtualButtonState curStateVirtualButton = VirtualButtonState.ADD;

    public UnityEvent OnGoalChangeText;

	public UnityEvent OnGoalRightPinCode;
	public UnityEvent OnGoalWrongPinCode;



	// maximum length of pin code
	private int maxLengthOutputText = 4;

	#region Properties
	public VirtualButtonState CurStateVirtualButton{

		get {return curStateVirtualButton; }
	}


	#endregion

    // Use this for initialization

    void Start () {

        virtualButton.GetComponent<VirtualButtonBehaviour>().RegisterEventHandler(this);
    }
	
	public void OnButtonPressed(VirtualButtonBehaviour vb)
    {
		// length of current string
		int length = outputText.text.Length;
		switch (curStateVirtualButton) {

		case VirtualButtonState.ADD:
			// check 
			if ( length < maxLengthOutputText) {

				outputText.text = outputText.text + charVirtualButton.ToString ();

			}

			break;
		case VirtualButtonState.DELETE:
			if (length > 0) {
				outputText.text = outputText.text.Substring (0, length - 1);
			}
			Debug.Log ("Invoke in switch");
			break;
		case VirtualButtonState.CHECK:
			if (GameController.Password == outputText.text)
				OnGoalRightPinCode.Invoke();
			else {
			
				OnGoalWrongPinCode.Invoke();
			}
			break;

		}
        // DON'T FOGGET TO ADD YOUR VIRTUAL BUTTON 
		// TO LIST IN GAME MANAGER!!!
        OnGoalChangeText.Invoke();
		Debug.Log ("Invoke after switch");
    }

    public void OnButtonReleased(VirtualButtonBehaviour vb)
    {
        

    }
}
