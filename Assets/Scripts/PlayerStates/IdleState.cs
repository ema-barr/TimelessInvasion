﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State<Player>
{
    private static IdleState _instance = null;

    public static IdleState Instance()
    {
        if (_instance == null)
            _instance = new IdleState();

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
