using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : State
{
    ChargeData _data;

    public Charge(Entity e, FiniteStateMachine f, ChargeData d) : base(e, f)
    {
        _data = d;
    }
}
