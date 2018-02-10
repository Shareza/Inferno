using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonHealthManager : MonoBehaviour
{


    public float currentHealth = 1000;
    public float maxHealth = 1000;

    public Image healthImage;
    public GameObject combatText;


    void Update()
    {
        healthImage.fillAmount = (currentHealth / maxHealth);

        if (currentHealth <= 0)
            Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }


}
