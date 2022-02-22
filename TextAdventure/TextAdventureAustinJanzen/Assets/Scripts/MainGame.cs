using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainGame : MonoBehaviour
{
    [SerializeField] Text textElement;
    [SerializeField] State startState;
    State state;

    // Start is called before the first frame update
    void Start()
    {
        state = startState;
        textElement.text = state.GetStateText();
    }

    // Update is called once per frame
    void Update()
    {
        GameMain();
    }

    //update with input scrubbing for screens with less than 4 options
    private void GameMain()
    {
        State[] statesArray = state.getOtherStates();
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            state = statesArray[0];
        }
        else if(Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            state = statesArray[1];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            state = statesArray[2];
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            state = statesArray[3];
        }

        textElement.text = state.GetStateText();

    }

}
