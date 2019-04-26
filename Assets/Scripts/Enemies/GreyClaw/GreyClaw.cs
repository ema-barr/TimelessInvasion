using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreyClaw : Enemy
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float chaseRadius;

    [SerializeField]
    private float attackRadius;

    [SerializeField]
    private float attackDelay;

    [SerializeField]
    private float deathDelay;

    private StateMachine<GreyClaw> stateMachine;

    private Animator anim;

    private Rigidbody2D myRigidbody;

    [HideInInspector]
    public bool isAttacking;

    private void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        anim.SetFloat("moveX", 0f);
        anim.SetFloat("moveY", -1f);

        isAttacking = false;

        target = GameObject.FindWithTag("Player").transform;

        stateMachine = new StateMachine<GreyClaw>(this);

        stateMachine.currentState = GreyClaw_IdleState.Instance();
    }

    private void FixedUpdate()
    {
        if (health > 0)
        {
            CheckDistance();
        }
        else if (stateMachine.currentState != GreyClaw_DeadState.Instance())
        {
            StopAllCoroutines();
            stateMachine.ChangeState(GreyClaw_DeadState.Instance());
        }

        stateMachine.Update();
    }

    public void CheckDistance()
    {
        if (!target.GetComponent<Player>().isDead)
        {
            if (Vector3.Distance(target.position, transform.position) <= chaseRadius)
            {
                if (Vector3.Distance(target.position, transform.position) <= attackRadius)
                {
                    //Attack state

                    ChangeAnim(target.position - transform.position);
                    stateMachine.ChangeState(GreyClaw_AttackState.Instance());
                }
                else if (!isAttacking)
                {
                    //Chase state
                    stateMachine.ChangeState(GreyClaw_WalkingState.Instance());
                }
            }
            else
            {
                //Idle State
                stateMachine.ChangeState(GreyClaw_IdleState.Instance());
            }
        }
        else
        {
            //If player is dead
            ChangeAnim(Vector2.down);
            StopAllCoroutines();
        }

    }



    public void Move()
    {
        Vector3 temp = Vector3.MoveTowards(transform.position,
                    target.position,
                    speed * Time.deltaTime);

        ChangeAnim(temp - transform.position);
        myRigidbody.MovePosition(temp);

    }

    public void StopMove()
    {

    }

    private void ChangeAnim(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
        {
            if (direction.x > 0)
            {
                SetAnimFloat(Vector2.right);
            }
            else if (direction.x < 0)
            {
                SetAnimFloat(Vector2.left);
            }
        }
        else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
        {
            if (direction.y > 0)
            {
                SetAnimFloat(Vector2.up);
            }
            else if (direction.y < 0)
            {
                SetAnimFloat(Vector2.down);
            }
        }
    }

    private void SetAnimFloat(Vector2 setVector)
    {
        anim.SetFloat("moveX", setVector.x);
        anim.SetFloat("moveY", setVector.y);
    }

    public void StartAttacking()
    {
        anim.SetBool("isAttacking", true);
        isAttacking = true;
        StartCoroutine(AttackCo());
    }

    private IEnumerator AttackCo()
    {
        yield return null;
        anim.SetBool("isAttacking", false);

        yield return new WaitForSeconds(attackDelay);
        isAttacking = false;
    }

    public StateMachine<GreyClaw> GetFSM()
    {
        return stateMachine;
    }

    public void Die()
    {
        StopAllCoroutines();
        anim.SetBool("isDead", true);
        StartCoroutine(DieCo());
    }

    private IEnumerator DieCo()
    {
        yield return new WaitForSeconds(deathDelay);
        Destroy(this.gameObject);
    }
}
