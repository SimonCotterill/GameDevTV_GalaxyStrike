using System.Diagnostics;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] TMP_Text scoreboardText;
    
    int score = 0;

    public void ChangeScore(int amount)
    {
        score = score + amount;
        //or score += amount;
        UnityEngine.Debug.Log(score);
        scoreboardText.text = score.ToString("D5");
    }
}
