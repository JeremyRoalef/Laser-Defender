using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int intHealth = 50;
    [SerializeField] ParticleSystem hitEffect;


    Camerashake cameraShake;
    [SerializeField] bool boolApplyCameraShake;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<Camerashake>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            ShakeCamera();
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

    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if (cameraShake != null && boolApplyCameraShake)
        {
            cameraShake.Play();
        }
    }
}
