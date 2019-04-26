using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ActivateDialog : MonoBehaviour
{
    [SerializeField]
    private Image portraitSlot;
    [SerializeField]
    private Sprite portrait;
    [SerializeField]
    private GameObject panel;
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private string dialog;

    [SerializeField]
    private Signal dialogOnSignal;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            dialogOnSignal.Raise();
            Activate();
        }
    }

    public void Activate()
    {
        portraitSlot.sprite = portrait;
        text.text = dialog;

    }

}
