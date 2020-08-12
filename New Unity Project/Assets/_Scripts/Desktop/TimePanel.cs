using AgarPlugin1;
using DarkRift.Client.Unity;
using Michsky.UI.ModernUIPack;
using TMPro;
using UnityEngine;

public class TimePanel : MonoBehaviour
{
    public TMP_Text min;
    public ProgressBar prgBar;
    float totalTime;
    int minuteValue;
    int secondValue;
    public Round round;    

    [SerializeField]
    [Tooltip("The DarkRift client to communicate on.")]
    UnityClient client;

    float totalTimeSaved;
    string minSaved;

    public void DisplayTime(string text)
    {
        string[] splitedText = CommonUtil.SplitTextWithComma(text);
        min.text = splitedText[0] + " : " + splitedText[1];
        minSaved = min.text;
        totalTime = float.Parse(splitedText[0]) * 60 + float.Parse(splitedText[1]);
        totalTimeSaved = totalTime;
    }

    private void Update()
    {
        if (prgBar.isOn)
        {
            if (Round.roundNumber.Equals(0))
            {                
                round.PassRound(1);
                SendMessageToServer.SendToServer(Round.roundNumber.ToString(), Tags.round, client);
            }
            totalTime -= Time.deltaTime;
            secondValue = (int)(totalTime % 60);
            minuteValue = (int)(totalTime / 60);
            min.text = minuteValue.ToString() + " : " + secondValue.ToString();
            prgBar.currentPercent = (totalTime * 100) / (minuteValue * 60 + secondValue);
        }

        if (totalTime <= 0)
        {
            
            prgBar.isOn = false;
            if (Round.roundNumber < 3)
            {
                Round.roundNumber++;
                round.PassRound(Round.roundNumber);
                SendMessageToServer.SendToServer(Round.roundNumber.ToString(), Tags.round, client);
                SendMessageToServer.SendToServer("pause", Tags.pauseGame, client);
                totalTime = totalTimeSaved;
                min.text = minSaved;
            }
            else
            {
                round.MakeAllDefault();
                round.FinishGame();
                SendMessageToServer.SendToServer("finishRound", Tags.finishRound, client);
                SendMessageToServer.SendToServer("pause", Tags.pauseGame, client);
                totalTime = totalTimeSaved;
                min.text = minSaved;
            }
            
        }
    }
   
}
