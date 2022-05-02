using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine
{
    public State _currentState;
    public Entity _e;

    public FiniteStateMachine()
    {
        _currentState = new State(_e, this);
    }

    public void Initialize(State startingState)
    {
        _currentState = startingState;
        _currentState.Enter();
    }

    public void ChangeState(State newState)
    {
        _currentState.Exit();
        _currentState = newState;
        _currentState.Enter();
    }
}
