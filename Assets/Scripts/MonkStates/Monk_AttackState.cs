using UnityEngine;
using UnityEditor;

public class Monk_AttackState : State<Monk>
{
    private static Monk_AttackState _instance;
    private bool alreadyAttacked = false;

    public static Monk_AttackState Instance()
    {
        if (_instance == null)
            _instance = new Monk_AttackState();

        return _instance;
    }

    public override void EnterState(Monk owner)
    {

    }

    public override void ExecuteState(Monk owner)
    {

        if (!owner.isCasting)
        {
            owner.StartCasting();
            alreadyAttacked = true;

            if (alreadyAttacked)
            {
                alreadyAttacked = false;
                owner.GetFSM().ChangeState(Monk_IdleState.Instance());
            }

        }
    }

    public override void ExitState(Monk owner)
    {
        
    }
}