using UnityEngine;
using UnityEditor;

public class AttackState : State<Player>
{
    private static AttackState _instance;
    private bool alreadyAttacked = false;

    public static AttackState Instance()
    {
        if (_instance == null)
            _instance = new AttackState();

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
                owner.GetFSM().ChangeState(IdleState.Instance());
            }

        }
    }

    public override void ExitState(Player owner)
    {
        
    }
}