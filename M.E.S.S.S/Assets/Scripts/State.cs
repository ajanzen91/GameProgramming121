using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public FiniteStateMachine _stateMachine;
    public Entity _entity;

    public float _startTime;

    public State(Entity e, FiniteStateMachine f)
    {
        _entity = e;
        _stateMachine = f;
    }

    public virtual void Enter()
    {
        _startTime = Time.time;
    }

    public virtual void Exit()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicsUpdate()
    {

    }
}
