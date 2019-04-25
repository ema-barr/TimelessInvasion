using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCheckSight : MonoBehaviour
{
    [SerializeField]
    private Signal inSightSignal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
            inSightSignal.Raise();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
            inSightSignal.Raise();
    }
}
