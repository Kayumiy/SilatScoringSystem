using AgarPlugin1;
using DarkRift.Client.Unity;
using TMPro;
using UnityEngine;

public class FighterScore : MonoBehaviour
{
    public string color;
    public Player player;

    [SerializeField]
    [Tooltip("The DarkRift client to communicate on.")]
    UnityClient client;

    public int totalValue;
    public int firstRoundValue;
    public int secondRoundValue;
    public int thirdRoundValue;   

    public TMP_Text firstScoreText;
    public TMP_Text secondScoreText;
    public TMP_Text thirdScoreText;

    public TMP_Text firstPinaltyText;
    public TMP_Text secondPinaltyText;
    public TMP_Text thirdPinaltyText;

    public TMP_Text firstRoundText;
    public TMP_Text secondRoundText;
    public TMP_Text thirdRoundText;

    public TMP_Text totalText;


    /// <summary>
    /// Calculate total Score
    /// </summary>
    public void CalculateTotalValue()
    {
        totalValue = firstRoundValue + secondRoundValue + thirdRoundValue;
        totalText.text = totalValue.ToString();

        firstRoundText.text = firstRoundValue.ToString();
        secondRoundText.text = secondRoundValue.ToString();
        thirdRoundText.text = thirdRoundValue.ToString();
    }

    /// <summary>
    /// Clear all text in the Scene
    /// </summary>
    public void ClearAll()
    {
        totalValue = 0;
        firstRoundValue = 0;
        secondRoundValue = 0;
        thirdRoundValue = 0;

        firstScoreText.text = "";
        secondScoreText.text = "";
        thirdScoreText.text = "";

        firstPinaltyText.text = "";
        secondPinaltyText.text = "";
        thirdPinaltyText.text = "";

        firstRoundText.text = "";
        secondRoundText.text = "";
        thirdRoundText.text = "";

        totalText.text = "";
    }

    /// <summary>
    /// Display Score Text
    /// </summary>
    /// <param name="text"></param>
    /// <param name="value"></param>
    /// <param name="isScore"></param>
    public void DisplayScoreText(string text, int value, bool isScore)
    {
        switch (Round.roundNumber)
        {
            case 1:
                if (isScore)
                {
                    firstScoreText.text += text + ",";
                    firstRoundValue += value;
                    string txt = player.juryNumber.ToString() + "," + color + "," + firstRoundValue.ToString();
                    SendMessageToServer.SendToServer(txt, Tags.score, client);
                }
                else
                {
                    firstPinaltyText.text += text + ",";
                    firstRoundValue += value;
                    string txt = player.juryNumber.ToString() + "," + color + "," + firstRoundValue.ToString();
                    SendMessageToServer.SendToServer(txt, Tags.score, client);
                }
                break;
            case 2:
                if (isScore)
                {
                    secondScoreText.text += text + ",";
                    secondRoundValue += value;
                    string txt = player.juryNumber.ToString() + "," + color + "," + secondRoundValue.ToString();
                    SendMessageToServer.SendToServer(txt, Tags.score, client);
                }
                else
                {
                    secondPinaltyText.text += text + ",";
                    secondRoundValue += value;
                    string txt = player.juryNumber.ToString() + "," + color + "," + secondRoundValue.ToString();
                    SendMessageToServer.SendToServer(txt, Tags.score, client);
                }
                break;
            case 3:
                if (isScore)
                {
                    thirdScoreText.text += text + ",";
                    thirdRoundValue += value;
                    string txt = player.juryNumber.ToString() + "," + color + "," + thirdRoundValue.ToString();
                    SendMessageToServer.SendToServer(txt, Tags.score, client);
                }
                else
                {
                    thirdPinaltyText.text += text + ",";
                    thirdRoundValue += value;
                    string txt = player.juryNumber.ToString() + "," + color + "," + thirdRoundValue.ToString();
                    SendMessageToServer.SendToServer(txt, Tags.score, client);
                }
                break;
            default:
                break;
        }
        CalculateTotalValue();
    }



}
