using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f,1f)]float fltShootingVolume = 1.0f;

    [Header("Taking Damage")]
    [SerializeField] AudioClip takeDamageClip;
    [SerializeField] [Range(0f,1f)]float fltDamageVolume = 1.0f;

    public void PlayShootingClip()
    {
        if (shootingClip != null)
        {
            AudioSource.PlayClipAtPoint(shootingClip,Camera.main.transform.position, fltShootingVolume);
        }
    }

    public void PlayTakeDamageClip()
    {
        if(takeDamageClip != null)
        {
            AudioSource.PlayClipAtPoint(takeDamageClip,Camera.main.transform.position, fltDamageVolume);
        }
    }
}
