using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public FloatValue playerHealth;

    private void Start()
    {
        InitHealth();
    }

    public void InitHealth()
    {
        float percCurrHealth = playerHealth.currentValue / playerHealth.initialValue;
        healthBar.fillAmount = percCurrHealth;
    }

    public void UpdateHealth()
    {
        float percCurrHealth = playerHealth.currentValue / playerHealth.initialValue;
        healthBar.fillAmount = percCurrHealth;
    }
}
