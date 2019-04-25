using UnityEngine;
using UnityEditor;

public class Player_AttackState : State<Player>
{
    private static Player_AttackState _instance;
    private bool alreadyAttacked = false;

    public static Player_AttackState Instance()
    {
        if (_instance == null)
            _instance = new Player_AttackState();

        return _instance;
    }

    public override void EnterState(Player owner)
    {
        
    }

    public override void ExecuteState(Player owner)
    {
        
        if (!owner.IsAttacking)
        {
            owner.Attack();
            alreadyAttacked = true;

            if (alreadyAttacked)
            {
                alreadyAttacked = false;
                owner.GetFSM().ChangeState(Player_IdleState.Instance());
            }

        }
    }

    public override void ExitState(Player owner)
    {
        
    }
}