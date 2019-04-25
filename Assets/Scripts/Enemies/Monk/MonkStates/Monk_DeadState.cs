using UnityEngine;
using UnityEditor;

public class Monk_DeadState : State<Monk>
{
    private static Monk_DeadState _instance = null;

    public static Monk_DeadState Instance()
    {
        if (_instance == null)
            _instance = new Monk_DeadState();

        return _instance;
    }

    public override void EnterState(Monk owner)
    {
        owner.Die();
    }


    public override void ExecuteState(Monk owner)
    {

        

    }

    public override void ExitState(Monk owner)
    {

    }
}