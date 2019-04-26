using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("NextDialog"))
        {
            player.GetComponent<Player>().DeactivateDialogState();
        }
    }
}
