using TMPro;
using UnityEngine;

public class DesktopFighterScore : MonoBehaviour
{
    public string color;
    public string juryNumber;
    public int round;
    public TMP_Text scoreText;
    public int scoreNumber;

    public void DisplayScore(string score)
    {
        scoreNumber = int.Parse(score);
        scoreText.text = score;         
    }

}
