using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float fltProjectileSpeed = 10f;
    [SerializeField] float fltProjectileLifetime = 5f;
    [SerializeField] float fltTimeBetweenShots = 0.5f;

    public bool boolIsFiring;
    Coroutine firingCoroutine;


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

            yield return new WaitForSeconds(fltTimeBetweenShots);
        }

    }
}
