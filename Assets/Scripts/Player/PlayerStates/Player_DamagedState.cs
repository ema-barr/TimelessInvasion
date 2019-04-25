using UnityEngine;
using System.Collections;

public class Player_DamagedState : State<Player>
{
    private static Player_DamagedState _instance = null;

    public static Player_DamagedState Instance()
    {
        if (_instance == null)
            _instance = new Player_DamagedState();

        return _instance;
    }

    public override void EnterState(Player owner)
    {
        owner.Stagger();
    }


    public override void ExecuteState(Player owner)
    {
    }

    public override void ExitState(Player owner)
    {

    }
}
