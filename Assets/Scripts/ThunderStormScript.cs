using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderStormScript : MonoBehaviour
{


    public float minDamage = 0.00001f;
    public float maxDamage = 0.00002f;
    public float power = 0.00001f;
    private DamageManager damageManager;
    Collision collision;

    void Start()
    {
        damageManager = new DamageManager();
        
    }

    void Update()
    {
        DealDamage(collision);
    }

    public void DealDamage(Collision other)
    {
        float damage = damageManager.GenerateDamage(power, minDamage, maxDamage);
        Collider[] enemiesInRange = Physics.OverlapSphere(transform.position, 5);

        foreach(var enemy in enemiesInRange)
        {
            if(enemy.gameObject.tag == "Enemy")
                enemy.SendMessage("TakeDamage", damage);
        }



    }
}
