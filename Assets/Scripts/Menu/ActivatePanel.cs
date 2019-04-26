using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePanel : MonoBehaviour
{
    [SerializeField]
    private GameObject[] objsToActivate;
    [SerializeField]
    private GameObject[] objsToDeactivate;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            foreach (GameObject panel in objsToActivate)
            {
                panel.SetActive(true);
            }



            foreach (GameObject panel in objsToDeactivate)
            {
                panel.SetActive(false);
            }
        }
    }
}
