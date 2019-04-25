using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    [SerializeField]
    private float thrust;
    [SerializeField]
    private float knockTime;
    [SerializeField]
    private float damage;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Rigidbody2D hit = other.GetComponent<Rigidbody2D>();
        if (hit != null)
        {

            if (other.gameObject.CompareTag("Enemy") && other.isTrigger)
            {
                if (!other.GetComponent<Enemy>().IsStaggered)
                {
                    other.GetComponent<Enemy>().TakeDamage(damage);
                }
                
            }
            if (other.gameObject.CompareTag("Player") && other.isTrigger)
            {
                if (!other.GetComponent<Player>().IsStaggered)
                {
                    other.GetComponent<Player>().TakeDamage(damage);
                }
                
            }
            
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
