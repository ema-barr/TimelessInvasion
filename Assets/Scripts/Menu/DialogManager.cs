using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private Signal dialogOffSignal;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("NextDialog"))
        {
            dialogOffSignal.Raise();
        }
    }

    public void ActivateDialog()
    {
        panel.SetActive(true);
    }

    public void DeactivateDialog()
    {
        panel.SetActive(false);
    }
}
