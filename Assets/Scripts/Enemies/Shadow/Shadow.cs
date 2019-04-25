using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : Enemy
{
    private Animator anim;
    private StateMachine<Shadow> stateMachine;
    private bool isAttacking = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        stateMachine = new StateMachine<Shadow>(this);
        stateMachine.currentState = Shadow_IdleState.Instance();
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.Update();
    }

    public void SwitchAttack()
    {
        isAttacking = !isAttacking;
        Debug.Log(isAttacking);
        if (isAttacking)
        {
            anim.SetBool("isAttacking", true);
            stateMachine.ChangeState(Shadow_AttackState.Instance());
        } else
        {
            anim.SetBool("isAttacking", false);
            stateMachine.ChangeState(Shadow_IdleState.Instance());
        }
    }
}
