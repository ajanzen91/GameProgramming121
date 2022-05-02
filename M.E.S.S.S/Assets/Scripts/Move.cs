using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : State
{
    protected MoveData stateData;
    protected bool _atWall;
    protected bool _atLedge;

    public Move(Entity e, FiniteStateMachine f, MoveData wData) : base(e, f)
    {
        stateData = wData;
    }

    public override void Enter()
    {
        base.Enter();
        _entity.SetVelocity(stateData._movementSpeed);
        _atLedge = _entity.CheckLedge();
        _atWall = _entity.CheckWall();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
       
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        _atLedge = _entity.CheckLedge();
        _atWall = _entity.CheckWall();
    }
}
