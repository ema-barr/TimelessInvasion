using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_WalkingState : State<Player>
{
    private static Player_WalkingState _instance = null;

    public static Player_WalkingState Instance()
    {
        if (_instance == null)
            _instance = new Player_WalkingState();

        return _instance;
    }

    public override void EnterState(Player owner)
    {
        
    }

    public override void ExecuteState(Player owner)
    {
        
         owner.MovePlayer();
        
    }

    public override void ExitState(Player owner)
    {
       
    }
}
