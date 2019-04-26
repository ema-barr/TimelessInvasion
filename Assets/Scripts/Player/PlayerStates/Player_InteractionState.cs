using UnityEngine;
using UnityEditor;

public class Player_InteractionState : State<Player>
{
    private static Player_InteractionState _instance = null;

    public static Player_InteractionState Instance()
    {
        if (_instance == null)
            _instance = new Player_InteractionState();

        return _instance;
    }

    public override void EnterState(Player owner)
    {

    }


    public override void ExecuteState(Player owner)
    {
        
    }

    public override void ExitState(Player owner)
    {

    }
}