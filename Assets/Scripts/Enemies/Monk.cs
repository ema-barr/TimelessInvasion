﻿using UnityEngine;
using UnityEditor;
using System.Collections;

public class Monk :Enemy
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private float chaseRadius;

    [SerializeField]
    private float attackRadius;

    [SerializeField]
    private float castTime;

    [SerializeField]
    private GameObject spellPrefab;


    private BoxCollider2D hitbox;


    private StateMachine<Monk> stateMachine;

    private Animator anim;

    private Rigidbody2D myRigidbody;

    public bool isCasting;



    private void Start()
    {
        hitbox = GetComponent<BoxCollider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
        anim.SetFloat("moveX", 0f);
        anim.SetFloat("moveY", -1f);

        isCasting = false;
        
        target = GameObject.FindWithTag("Player").transform;

        stateMachine = new StateMachine<Monk>(this);
        
        stateMachine.currentState = Monk_IdleState.Instance();
    }

    private void FixedUpdate()
    {
        if (health > 0)
        {
            CheckDistance();
        } else
        {
            StopAllCoroutines();
            stateMachine.ChangeState(Monk_DeadState.Instance());
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
                    stateMachine.ChangeState(Monk_AttackState.Instance());
                }
                else if (!isCasting)
                {
                    //Chase state
                    stateMachine.ChangeState(Monk_WalkingState.Instance());
                }
            }
            else
            {
                //Idle State
                stateMachine.ChangeState(Monk_IdleState.Instance());
            }
        } else
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

    public StateMachine<Monk> GetFSM()
    {
        return stateMachine;
    }

    public void StartCasting()
    {
        anim.SetBool("isAttacking", true);
        isCasting = true;
        StartCoroutine(CastCo());
    }

    private IEnumerator CastCo()
    {
        yield return new WaitForSeconds(castTime);
        CastSpell();
        isCasting = false;
        anim.SetBool("isAttacking", false);
    }

    private void CastSpell()
    {
        Instantiate(spellPrefab, transform.position, Quaternion.identity);

    }

    public override void Death()
    {
        stateMachine.ChangeState(Monk_DeadState.Instance());
    }

    public void Die()
    {
        anim.SetBool("isDead", true);
        hitbox.enabled = false;
    }
}