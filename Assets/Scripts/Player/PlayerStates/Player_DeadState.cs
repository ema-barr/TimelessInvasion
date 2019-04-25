using UnityEngine;
using UnityEditor;

public class Player_DeadState : State<Player>
{
    private static Player_DeadState _instance = null;

    public static Player_DeadState Instance()
    {
        if (_instance == null)
            _instance = new Player_DeadState();

        return _instance;
    }

    public override void EnterState(Player owner)
    {

    }


    public override void ExecuteState(Player owner)
    {

        owner.Die();

    }

    public override void ExitState(Player owner)
    {

    }
}