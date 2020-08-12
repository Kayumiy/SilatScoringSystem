using AgarPlugin1;
using DarkRift.Client.Unity;
using UnityEngine;
using UnityEngine.UI;

public class DesktopSender : MonoBehaviour
{
    public TimeInputField timeInputField;
    public Image outline;
    public Image settingWindow;
    public GameObject mainWindow;
    public TimePanel timePanel;
    public MonitorScore monitorScore;
    public Round round;


    [SerializeField]
    [Tooltip("The DarkRift client to communicate on.")]
    UnityClient client;

    /// <summary>
    /// Send time after setting
    /// </summary>
    public void SetTime()
    {
        string txt = timeInputField.min.text + "," + timeInputField.sec.text;
        timePanel.DisplayTime(txt);
        ActivateMainWindow();
        SendMessageToServer.SendToServer(Round.roundNumber.ToString(), Tags.round, client);
    }

    /// <summary>
    /// Refresh Game
    /// </summary>
    public void Refresh()
    {
        if (!timePanel.prgBar.isOn)
        {
            
            SetTime();
        }       
    }

    /// <summary>
    /// Allow to play game
    /// </summary>
    public void PlayGame()
    {
        string txt = "play";
        SendMessageToServer.SendToServer(txt, Tags.playGame, client);

        timePanel.prgBar.isOn = true;

    }

    /// <summary>
    /// Pause game
    /// </summary>
    public void PauseGame()
    {
        string txt = "pause";
        SendMessageToServer.SendToServer(txt, Tags.pauseGame, client);
        timePanel.prgBar.isOn = false;
    }

    /// <summary>
    /// Delete game
    /// </summary>
    public void DeleteGame()
    {
        if (!timePanel.prgBar.isOn)
        {
            string txt = "delete";
            monitorScore.ClearAll();
            SendMessageToServer.SendToServer(txt, Tags.deleteGame, client);
        }       
    }

    /// <summary>
    /// Activates MainWindow after Setting time 
    /// </summary>
    public void ActivateMainWindow()
    {
        outline.gameObject.SetActive(false);
        settingWindow.enabled = false;
        mainWindow.SetActive(true);
        timePanel.min.text = timeInputField.min.text + " : " + timeInputField.sec.text;
    }

    /// <summary>
    /// Call this method when round button is clicked
    /// </summary>
    /// <param name="number"></param>
    public void ChangeRound(int number)
    {
        if (!timePanel.prgBar.isOn)
        {
            round.PassRound(number);
        }
    }



}
