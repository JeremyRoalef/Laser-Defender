using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int intHealth = 50;

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
        }
    }

    void TakeDamage(int intTakeDamage)
    {
        intHealth -= intTakeDamage;

        if (intHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

}
