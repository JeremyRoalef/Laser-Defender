using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool boolIsPlayer;
    [SerializeField] int intHealth = 50;
    [SerializeField] ParticleSystem hitEffect;


    Camerashake cameraShake;
    [SerializeField] bool boolApplyCameraShake;

    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<Camerashake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
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
        audioPlayer.PlayTakeDamageClip();

        if (intHealth <= 0)
        {
            Die();
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

    public int PlayerHealth()
    {
        return intHealth;
    }

    void Die()
    {
        if (!boolIsPlayer)
        {
            scoreKeeper.UpdateScore(5);
            Debug.Log(scoreKeeper.GetScore());
        }
        else
        {
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }
}
