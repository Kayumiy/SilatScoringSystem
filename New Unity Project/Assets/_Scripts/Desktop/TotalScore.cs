using TMPro;
using UnityEngine;

public class TotalScore : MonoBehaviour
{

    public string juryNumber;
    public string color;
    public TMP_Text totalScore;  
    public int score;

    private void Start()
    {
        score = 0;
    }

    public void CalculateTotalScore(DesktopFighterScore [] fighters)
    {
        foreach (DesktopFighterScore item in fighters)
        {
            if (item.juryNumber.Equals(juryNumber) && item.color.Equals(color))
            {               
                score += item.scoreNumber;
                totalScore.text = score.ToString();

            }
        }
        score = 0;
    } 


   
}
