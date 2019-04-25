using UnityEngine;
using UnityEditor;

public class Monk_WalkingState : State<Monk>
{
    private static Monk_WalkingState _instance = null;

    public static Monk_WalkingState Instance()
    {
        if (_instance == null)
            _instance = new Monk_WalkingState();

        return _instance;
    }

    public override void EnterState(Monk owner)
    {

    }

    public override void ExecuteState(Monk owner)
    {

        owner.Move();

    }

    public override void ExitState(Monk owner)
    {

    }
}