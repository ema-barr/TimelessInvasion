using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string enemyName;
    
    protected float health;
    
    [SerializeField]
    protected float speed;
    [SerializeField]
    protected float staggerTime;


    private bool isStaggered = false;

    public FloatValue maxHealth;

    public bool IsStaggered { get => isStaggered; set => isStaggered = value; }

    private void Awake()
    {
        health = maxHealth.initialValue;
    }


    public void TakeDamage(float damage)
    {
        IsStaggered = true;
        StartCoroutine(StaggerCo());
       
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
    }

    public virtual void Death()
    {

    }

    private IEnumerator StaggerCo()
    {
        yield return new WaitForSeconds(staggerTime);
        IsStaggered = false;
    }
    
}
