using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    private StateMachine<Player> stateMachine;
    private Animator animator;

    private Vector3 changeMovement;
    private Rigidbody2D myRigidbody;

    private bool isAttacking;

    [SerializeField]
    private float speed = 0;
    
    public Animator Animator { get => animator; set => animator = value; }
    public Vector3 ChangeMovement { get => changeMovement; set => changeMovement = value; }
    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();

        animator.SetFloat("moveX", 0f);
        animator.SetFloat("moveY", -1f);

        isAttacking = false;

        //Setting the State Machine
        stateMachine = new StateMachine<Player>(this);
        stateMachine.currentState = IdleState.Instance();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InputHandler();
    }

    private void InputHandler()
    {
        if (Input.GetButton("Attack") && !isAttacking)
        {
            stateMachine.ChangeState(AttackState.Instance());
        } else 
        {
            GetMovement();
        }

        stateMachine.Update();
    }

    private void GetMovement()
    {
        changeMovement = Vector3.zero;
        changeMovement.x = Input.GetAxisRaw("Horizontal");
        changeMovement.y = Input.GetAxisRaw("Vertical");
    }

    public StateMachine<Player> GetFSM()
    {
        return stateMachine;
    }

    public void MovePlayer()
    {
        changeMovement.Normalize();
        myRigidbody.MovePosition(
                transform.position + changeMovement * speed * Time.deltaTime);

        //Play Animation
        changeMovement.x = Mathf.Round(changeMovement.x);
        changeMovement.y = Mathf.Round(changeMovement.y);
        animator.SetFloat("moveX", changeMovement.x);
        animator.SetFloat("moveY", changeMovement.y);
        animator.SetBool("isMoving", true);
    }

    public void StopPlayer()
    {
        animator.SetBool("isMoving", false);
    }

    public void Attack()
    {
        isAttacking = true;
        StartCoroutine(AttackCo());
        
    }

    private IEnumerator AttackCo()
    {
        animator.SetBool("isAttacking", true);
        yield return null;

        animator.SetBool("isAttacking", false);
        yield return new WaitForSeconds(.2f);
       

        isAttacking = false;

    }
}
