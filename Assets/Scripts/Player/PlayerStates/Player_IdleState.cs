using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_IdleState : State<Player>
{
    private static Player_IdleState _instance = null;

    public static Player_IdleState Instance()
    {
        if (_instance == null)
            _instance = new Player_IdleState();

        return _instance;
    }

    public override void EnterState(Player owner)
    {
        
    }


    public override void ExecuteState(Player owner)
    {
        
        owner.StopPlayer();
        
    }

    public override void ExitState(Player owner)
    {
        
    }
   
}
