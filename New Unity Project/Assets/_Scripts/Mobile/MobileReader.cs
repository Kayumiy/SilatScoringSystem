using AgarPlugin1;
using DarkRift;
using DarkRift.Client;
using DarkRift.Client.Unity;
using System;
using UnityEngine;
using UnityEngine.UI;

public class MobileReader : MonoBehaviour
{
    const byte SPAWN_TAG = 0;
    public Player player;
    public GameObject juryRaqamPanel;
    public JuryButton[] juryButtons;
    public Image settingPanel;
    public Image connectServer;
    public Round round;
    public FighterScore redFighter;
    public FighterScore blueFighter;


    [SerializeField]
    [Tooltip("The DarkRift client to communicate on.")]
    UnityClient client;    

    void Awake()
    {
        if (client == null)
        {
            Debug.LogError("Client unassigned in PlayerSpawner.");
            Application.Quit();
        }
        client.MessageReceived += SpawnPlayer;
    }


    void SpawnPlayer(object sender, MessageReceivedEventArgs e)
    {
        try
        {
            using (Message message = e.GetMessage())
            using (DarkRiftReader reader = message.GetReader())
            {
                switch (message.Tag)
                {
                    case Tags.connection:
                        ConnectionTag(GetMessageFromServer.GetUshortMessage(reader));
                        break;
                    case Tags.juryNumberOther:
                        JuryNumberOtherTag(GetMessageFromServer.GetUshortMessage(reader), reader);
                        break;
                    case Tags.selectJuryNum:
                        SelectJuryNumTag(GetMessageFromServer.GetStringMessage(reader));
                        break;
                    case Tags.juryNumber:
                        JuryNumberTag(GetMessageFromServer.GetUshortMessage(reader));
                        break;
                    case Tags.playGame:
                        PlayGameTag(GetMessageFromServer.GetStringMessage(reader));
                        break;
                    case Tags.setTime:
                        SetTimeTag(GetMessageFromServer.GetStringMessage(reader));
                        break;
                    case Tags.juryIsOut:
                        JuryIsOutTag(GetMessageFromServer.GetUshortMessage(reader));
                        break;
                    case Tags.pauseGame:
                        PauseGameTag(GetMessageFromServer.GetStringMessage(reader));
                        break;
                    case Tags.round:
                        RoundTag(GetMessageFromServer.GetStringMessage(reader));
                        break;
                    case Tags.finishRound:
                        FinishRoundTag(GetMessageFromServer.GetStringMessage(reader));
                        break;
                    case Tags.deleteGame:
                        DeleteGameTag(GetMessageFromServer.GetStringMessage(reader));
                        break;
                    default:
                        break;
                }
                //if (message.Tag == Tags.score && player.type.Equals("desktop"))
                //{
                //    string txt = reader.ReadString();
                //    // string txt = juryNumber + "," + color + "," + score; string text ni yoyib tegishli joyga display qilish kerak
                //}            
            }
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }

    /// <summary>
    /// Call this method when tag is connection  
    /// </summary>
    /// <param name="reader"></param>
    public void ConnectionTag(ushort number)
    {        
        player.ID = number;
        SendMessageToServer.SendToServer(player.type, Tags.type, client);
    }

    /// <summary>
    /// Call this method when tag is JuryNumberOther
    /// </summary>
    /// <param name="reader"></param>
    public void JuryNumberOtherTag(ushort number, DarkRiftReader reader)
    {
        

        ushort juryButtonIndex = number;
        juryButtonIndex--;
        // Deactivate UI button based on the number coming from Server
        switch (number)
        {
            case 1:
                juryButtons[juryButtonIndex].MakeItGreenOther();
                break;
            case 2:
                juryButtons[juryButtonIndex].MakeItGreenOther();
                break;
            case 3:
                juryButtons[juryButtonIndex].MakeItGreenOther();
                break;
            case 4:
                juryButtons[juryButtonIndex].MakeItGreenOther();
                break;
            case 5:
                juryButtons[juryButtonIndex].MakeItGreenOther();
                break;
            default:
                //
                break;
        }

    }

    /// <summary>
    /// Call this method when tag is selectJuryNum
    /// </summary>
    /// <param name="reader"></param>
    public void SelectJuryNumTag(string text)
    {
        string juryNumSelectionMessage = text;
        // kelgan string ni UI da display qil
        juryRaqamPanel.SetActive(true);
    }

    /// <summary>
    /// Call this method when tag is juryNumber
    /// </summary>
    /// <param name="reader"></param>
    public void JuryNumberTag(ushort number)
    {        
        ushort juryButtonIndex = number;
        juryButtonIndex--;
        // kelgan number bo'yicha UI dagi buttonni diactivate qil
        switch (number)
        {
            case 1:
                juryButtons[juryButtonIndex].MakeItGreen();
                
                break;
            case 2:
                juryButtons[juryButtonIndex].MakeItGreen();
                
                break;
            case 3:
                juryButtons[juryButtonIndex].MakeItGreen();
                
                break;
            case 4:
                juryButtons[juryButtonIndex].MakeItGreen();
                
                break;
            case 5:
                juryButtons[juryButtonIndex].MakeItGreen();
                
                break;
            default:
                //
                break;
        }
    }

    /// <summary>
    /// Call this method when tag is playGame
    /// </summary>
    /// <param name="reader"></param>
    public void PlayGameTag(string text)
    {        
        if (text.Equals("play"))
        {
            settingPanel.gameObject.SetActive(false);
            connectServer.gameObject.SetActive(false);
            
        }
    }

    /// <summary>
    /// Call this method when tag is setTime
    /// </summary>
    /// <param name="reader"></param>
    public void SetTimeTag(string text)
    {        
        //timePanel.DisplayTime(text);
        //loadingBar.fillAmount = 1.0f;
    }

    /// <summary>
    /// Call this method when tag is juryIsOut
    /// </summary>
    /// <param name="reader"></param>
    public void JuryIsOutTag(ushort number)
    {        
        ushort juryButtonIndex = number;
        juryButtonIndex--;
        // kelgan number bo'yicha UI dagi buttonni diactivate qil
        switch (number)
        {
            case 1:
                juryButtons[juryButtonIndex].MakeItRedOther();
                break;
            case 2:
                juryButtons[juryButtonIndex].MakeItRedOther();
                break;
            case 3:
                juryButtons[juryButtonIndex].MakeItRedOther();
                break;
            case 4:
                juryButtons[juryButtonIndex].MakeItRedOther();
                break;
            case 5:
                juryButtons[juryButtonIndex].MakeItRedOther();
                break;
            default:
                //
                break;
        }
        
    }

    /// <summary>
    /// Call this method when tag is pauseGame
    /// </summary>
    /// <param name="reader"></param>
    public void PauseGameTag(string text)
    {
        if (text.Equals("pause"))
        {
            settingPanel.gameObject.SetActive(true);
            connectServer.gameObject.SetActive(false);            
        }
    }

    /// <summary>
    /// Call this method when tag is round
    /// </summary>
    /// <param name=""></param>
    public void RoundTag(string text)
    {        
        int roundNumber = int.Parse(text);
        round.PassRound(roundNumber);        
    }

    public void FinishRoundTag(string text)
    {
        round.MakeAllDefault();
    }

    public void DeleteGameTag(string text)
    {
        if (text.Equals("delete"))
        {
            redFighter.ClearAll();
            blueFighter.ClearAll();            
        }
    }


}
