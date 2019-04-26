using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyClaw_IdleState : State<GreyClaw>
{
    private static GreyClaw_IdleState _instance = null;

    public static GreyClaw_IdleState Instance()
    {
        if (_instance == null)
            _instance = new GreyClaw_IdleState();

        return _instance;
    }

    public override void EnterState(GreyClaw owner)
    {

    }


    public override void ExecuteState(GreyClaw owner)
    {

        owner.StopMove();

    }

    public override void ExitState(GreyClaw owner)
    {

    }
}
