using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingState : State<Player>
{
    private static WalkingState _instance = null;

    public static WalkingState Instance()
    {
        if (_instance == null)
            _instance = new WalkingState();

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
