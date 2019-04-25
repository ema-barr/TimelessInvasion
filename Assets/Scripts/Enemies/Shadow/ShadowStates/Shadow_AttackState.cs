using UnityEngine;
using System.Collections;

public class Shadow_AttackState : State<Shadow>
{
    private static Shadow_AttackState _instance = null;

    public static Shadow_AttackState Instance()
    {
        if (_instance == null)
            _instance = new Shadow_AttackState();

        return _instance;
    }

    public override void EnterState(Shadow owner)
    {

    }


    public override void ExecuteState(Shadow owner)
    {



    }

    public override void ExitState(Shadow owner)
    {

    }
}
