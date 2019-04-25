using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowCheckSight : MonoBehaviour
{
    [SerializeField]
    private Signal inSightSignalOn;
    [SerializeField]
    private Signal inSightSignalOff;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
            inSightSignalOn.Raise();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
            inSightSignalOff.Raise();
    }

    private void OnDisable()
    {
        inSightSignalOff.Raise();
    }
}
