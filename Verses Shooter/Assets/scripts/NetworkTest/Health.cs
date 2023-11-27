using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth = 100;

    public Image hpBar;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        hpBar.fillAmount -= damage / maxHealth;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("took " + damage + " damage : " + currentHealth);
    }
}
