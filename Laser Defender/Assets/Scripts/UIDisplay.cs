using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] Slider healthSlider;
    [SerializeField] Health playerHealth;

    [SerializeField] TextMeshProUGUI scoreText;
    ScoreKeeper scoreKeeper;

    private void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }

    private void Start()
    {
        healthSlider.maxValue = playerHealth.PlayerHealth();
    }

    private void Update()
    {
        healthSlider.value = playerHealth.PlayerHealth();
        scoreText.text = scoreKeeper.GetScore().ToString("000000000");
    }

}
