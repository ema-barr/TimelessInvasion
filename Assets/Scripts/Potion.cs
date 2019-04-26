using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    [SerializeField]
    private float healingQuantity;
    [SerializeField]
    private float delayDestroy;

    private Animator anim;

    private bool alreadyUsed = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("isPickedUp", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !alreadyUsed)
        {
            FloatValue healthPlayer = other.GetComponent<Player>().currentHealth;

            if (healthPlayer.currentValue < healthPlayer.initialValue)
            {
                alreadyUsed = true;
                other.GetComponent<Player>().Heal(healingQuantity);
                StartCoroutine(DestroyPotionCo());
            }
        }
    }

    private IEnumerator DestroyPotionCo()
    {
        anim.SetBool("isPickedUp", true);
        yield return new WaitForSeconds(delayDestroy);
        Destroy(this.gameObject);
    }
}
