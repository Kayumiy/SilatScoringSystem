using UnityEngine;
using UnityEngine.UI;

public class Round : MonoBehaviour
{
    public static int roundNumber;
    public Color yellow;  
    public Image firstRoundImage;
    public Image secondRoundImage;
    public Image thirdRoundImage;
    public Image totalImage;
    public MonitorScore monitorScore;
    public Player player;


    // Start is called before the first frame update
    void Start()
    {        
        roundNumber = 1;
        PassRound(roundNumber);
    }

    /// <summary>
    /// Call this method when round is changed
    /// </summary>
    /// <param name="number"></param>
    public void PassRound(int number)
    {
        
        switch (number)
        {
            case 1:
                MakeAllDefault();                
                firstRoundImage.color = yellow;
                roundNumber = number;
                break;
            case 2:
                MakeAllDefault();                
                secondRoundImage.color = yellow;
                roundNumber = number;
                DisplayForDesktopOnly();
                break;
            case 3:
                MakeAllDefault();                
                thirdRoundImage.color = yellow;
                roundNumber = number;
                DisplayForDesktopOnly();
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Make all round images White
    /// </summary>
    public void MakeAllDefault()
    {
        roundNumber = 0;
        firstRoundImage.color = Color.white;
        secondRoundImage.color = Color.white;
        thirdRoundImage.color = Color.white;
        //totalImage.color = Color.white;
    }

    public void FinishGame()
    {
        monitorScore.DisplayTotalScore();
    }


    public void DisplayForDesktopOnly()
    {
        if (player.type.Equals("desktop"))
        {
            monitorScore.DisplayTotalScore();
        }
    }
         

}
