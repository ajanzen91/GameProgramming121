using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "State")]

public class State : ScriptableObject
{
    [SerializeField] string gameText;
    [SerializeField] State[] otherStates;

    //return game text for that state
    public string GetStateText()
    {
        return gameText;
    }

    public State[] getOtherStates()
    {
        return otherStates;
    }
}
