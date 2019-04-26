using UnityEngine;
using UnityEditor;

public class GreyClaw_AttackState : State<GreyClaw>
{
    private static GreyClaw_AttackState _instance;
    private bool alreadyAttacked = false;

    public static GreyClaw_AttackState Instance()
    {
        if (_instance == null)
            _instance = new GreyClaw_AttackState();

        return _instance;
    }

    public override void EnterState(GreyClaw owner)
    {

    }

    public override void ExecuteState(GreyClaw owner)
    {

        if (!owner.isAttacking)
        {
            owner.StartAttacking();
            alreadyAttacked = true;

            if (alreadyAttacked)
            {
                alreadyAttacked = false;
                owner.GetFSM().ChangeState(GreyClaw_IdleState.Instance());
            }

        }
    }

    public override void ExitState(GreyClaw owner)
    {

    }
}