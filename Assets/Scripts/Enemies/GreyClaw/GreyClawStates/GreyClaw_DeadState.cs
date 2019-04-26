using UnityEngine;
using UnityEditor;

public class GreyClaw_DeadState : State<GreyClaw>
{
    private static GreyClaw_DeadState _instance = null;

    public static GreyClaw_DeadState Instance()
    {
        if (_instance == null)
            _instance = new GreyClaw_DeadState();

        return _instance;
    }

    public override void EnterState(GreyClaw owner)
    {
        owner.Die();
    }


    public override void ExecuteState(GreyClaw owner)
    {



    }

    public override void ExitState(GreyClaw owner)
    {

    }
}