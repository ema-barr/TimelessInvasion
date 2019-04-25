using UnityEngine;
using System.Collections;

public class Shadow_IdleState : State<Shadow>
{
    private static Shadow_IdleState _instance = null;

    public static Shadow_IdleState Instance()
    {
        if (_instance == null)
            _instance = new Shadow_IdleState();

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
