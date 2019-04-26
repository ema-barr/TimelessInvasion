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
    [SerializeField]
    private float staggerTime;
    
    public Animator Animator { get => animator; set => animator = value; }
    public Vector3 ChangeMovement { get => changeMovement; set => changeMovement = value; }
    public bool IsAttacking { get => isAttacking; set => isAttacking = value; }
    public bool IsStaggered { get => isStaggered; set => isStaggered = value; }

    public FloatValue currentHealth;
    public Signal playerHealthSignal;

    [SerializeField]
    private Signal gameOverSignal;
    [SerializeField]
    private float gameOverPanelDelay;

    [HideInInspector]
    public bool isDead = false;

    private bool dialogIsActive = false;
    private bool isStaggered = false;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth.currentValue = currentHealth.initialValue;

        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();

        animator.SetFloat("moveX", 0f);
        animator.SetFloat("moveY", -1f);

        isAttacking = false;

        //Setting the State Machine
        stateMachine = new StateMachine<Player>(this);
        stateMachine.currentState = Player_IdleState.Instance();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        InputHandler();
    }

    private void InputHandler()
    {
        if (!isDead)
        {
            if (stateMachine.currentState != Player_InteractionState.Instance())
            {
                if (Input.GetButton("Attack") && !isAttacking)
                {
                    stateMachine.ChangeState(Player_AttackState.Instance());
                }
                else
                {
                    GetMovement();
                    if (changeMovement == Vector3.zero)
                    {
                        stateMachine.ChangeState(Player_IdleState.Instance());
                    }
                    else
                    {
                        stateMachine.ChangeState(Player_WalkingState.Instance());
                    }
                }
            }
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

    public void TakeDamage(float damage)
    {
        currentHealth.currentValue -= damage;
        playerHealthSignal.Raise();

        CheckDeath();

        if (!isDead)
        {
            stateMachine.ChangeState(Player_DamagedState.Instance());
        }
       
    }

    private void CheckDeath()
    {
        if (currentHealth.currentValue <= 0)
        {
            isDead = true;
            stateMachine.ChangeState(Player_DeadState.Instance());
        }
    }

    public void Die()
    {
        animator.SetBool("dead", true);
        BoxCollider2D[] listColliders = GetComponents<BoxCollider2D>();
        foreach (BoxCollider2D collider in listColliders)
        {
            collider.enabled = false;
        }

        StartCoroutine(GameOverCo());
    }

    public IEnumerator GameOverCo()
    {
        yield return new WaitForSeconds(gameOverPanelDelay);
        gameOverSignal.Raise();
    }

    public void Stagger()
    {
        isStaggered = true;
        animator.SetBool("damaged", true);
        StartCoroutine(StaggerCo());
    }

    private IEnumerator StaggerCo()
    {
        yield return null;

        animator.SetBool("damaged", false);

        yield return new WaitForSeconds(staggerTime);
        isStaggered = false;
    }

    public void ActivateDialogState()
    {
        Time.timeScale = 0f;
        stateMachine.ChangeState(Player_InteractionState.Instance());
    }

    public void DeactivateDialogState()
    {
        Time.timeScale = 1f;
        stateMachine.ChangeState(Player_IdleState.Instance());
    }

    public void Heal(float healing)
    {
        float newHealth = currentHealth.currentValue + healing;
        newHealth = Mathf.Min(newHealth, currentHealth.initialValue);
        currentHealth.currentValue = newHealth;
        playerHealthSignal.Raise();
    }
}
