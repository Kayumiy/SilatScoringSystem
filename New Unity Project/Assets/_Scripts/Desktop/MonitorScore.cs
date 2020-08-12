using UnityEngine;

public class MonitorScore : MonoBehaviour
{

    public DesktopFighterScore[] fighterScores;
    public TotalScore[] totalScores;

    public void GetScore(string juryNumber, string color, string score)
    {
        foreach (DesktopFighterScore item in fighterScores)
        {
            if (item.round.Equals(Round.roundNumber))
            {
                if (item.juryNumber.Equals(juryNumber))
                {
                    if (item.color.Equals(color))
                    {
                        item.DisplayScore(score);
                    }                    
                }
            }
        }       
    }

    public void DisplayTotalScore()
    {
        foreach (TotalScore item in totalScores)
        {
            item.CalculateTotalScore(fighterScores);
        }
    }

    public void ClearAll()
    {
        foreach (TotalScore item in totalScores)
        {
            item.totalScore.text = "";
            item.score = 0;
        }

        foreach (DesktopFighterScore item in fighterScores)
        {
            item.scoreText.text = "";
            item.scoreNumber = 0;
        }
    }

}
