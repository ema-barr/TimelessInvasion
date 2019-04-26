using UnityEngine;
using UnityEditor;

public class GreyClaw_WalkingState : State<GreyClaw>
{
    private static GreyClaw_WalkingState _instance = null;

    public static GreyClaw_WalkingState Instance()
    {
        if (_instance == null)
            _instance = new GreyClaw_WalkingState();

        return _instance;
    }

    public override void EnterState(GreyClaw owner)
    {

    }

    public override void ExecuteState(GreyClaw owner)
    {

        owner.Move();

    }

    public override void ExitState(GreyClaw owner)
    {

    }
}