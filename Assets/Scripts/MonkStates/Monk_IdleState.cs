using UnityEngine;
using UnityEditor;

public class Monk_IdleState : State<Monk>
{
    private static Monk_IdleState _instance = null;

    public static Monk_IdleState Instance()
    {
        if (_instance == null)
            _instance = new Monk_IdleState();

        return _instance;
    }

    public override void EnterState(Monk owner)
    {

    }


    public override void ExecuteState(Monk owner)
    {

        owner.StopMove();

    }

    public override void ExitState(Monk owner)
    {

    }
}