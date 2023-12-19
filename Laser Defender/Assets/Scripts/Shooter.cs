using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class Shooter : MonoBehaviour
{
    [Header("General")]

    [SerializeField] GameObject projectile;
    [SerializeField] float fltProjectileSpeed = 10f;
    [SerializeField] float fltProjectileLifetime = 5f;
    [SerializeField] float fltTimeBetweenShots = 0.5f;


    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float fltMinFireRate = 0.1f;
    [SerializeField] float fltMaxFireRate = 4;
    [SerializeField] float fltFiringVariance = 0.3f;

    [HideInInspector]public bool boolIsFiring;

    Coroutine firingCoroutine;
    
    private void Start()
    {
        if (useAI)
        {
            boolIsFiring = true;
        }
    }

    private void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (boolIsFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!boolIsFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;

        }
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject instance = Instantiate(projectile, transform.position, Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * fltProjectileSpeed;
            }

            Destroy(instance, fltProjectileLifetime);


            float fltTimeToNextProjectile = Random.Range(fltTimeBetweenShots - fltFiringVariance, fltTimeBetweenShots + fltFiringVariance);

            fltTimeToNextProjectile = Mathf.Clamp(fltTimeToNextProjectile, fltMinFireRate, float.MaxValue);

            yield return new WaitForSeconds(fltTimeToNextProjectile);
        }

    }


}
