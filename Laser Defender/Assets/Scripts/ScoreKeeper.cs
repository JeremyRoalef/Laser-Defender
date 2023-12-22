using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    private int intScore = 0;


    private void Update()
    {
        Debug.Log(intScore);
    }
    public int GetScore()
    {
        return intScore;
    }

    public void UpdateScore(int intUpdateScore)
    {
        intScore += intUpdateScore;
        Mathf.Clamp(intScore, 0, int.MaxValue);
    }

    public void ResetScore()
    {
        intScore = 0;
    }
}
