using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Photon.Pun;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth = 100;
    float fillValue = 1f;

    public Image hpBar;


    [PunRPC]
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        fillValue -= damage / (float)maxHealth;

        hpBar.fillAmount = fillValue;

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        Debug.Log("took " + damage + " damage : " + currentHealth);
        Debug.Log("fillAmount: " + fillValue);
    }
}
