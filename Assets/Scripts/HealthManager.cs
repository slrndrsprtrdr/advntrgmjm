using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public Image healthBar;
    public float healthAmount = 3f;

    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void TakeDamage(float health)
    {
        healthBar.fillAmount = health / 3f;
    }

    public void Heal(float healingAmount)
    {
        healthBar.fillAmount = 1f;
    }
}
