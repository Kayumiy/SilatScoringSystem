using AgarPlugin1;
using DarkRift;
using DarkRift.Client;
using DarkRift.Client.Unity;
using Michsky.UI.ModernUIPack;
using System;
using UnityEngine;
using UnityEngine.UI;

public class DesktopReader : MonoBehaviour
{
    public Player player;
    public Image[] juryCollection;
    public Color green;
    public Color red;
    public MonitorScore monitorScore;
    public Image outline;
    public ProgressBar prgBar;


    [SerializeField]
    [Tooltip("The DarkRift client to communicate on.")]
    UnityClient client;

    void Awake()
    {
        if (client == null)
        {
            Debug.LogError("Client unassigned in PlayerSpawner.");
            //Application.Quit();
        }
        client.MessageReceived += DesktopMoitor;
    }

    void DesktopMoitor(object sender, MessageReceivedEventArgs e)
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
                    case Tags.score:
                        ScoreTag(GetMessageFromServer.GetStringMessage(reader));
                        break;
                    case Tags.juryIsOut:
                        JuryIsOutTag(GetMessageFromServer.GetUshortMessage(reader));
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
    /// Call this method when tag is juryNumberOther  
    /// </summary>
    /// <param name="reader"></param>
    public void JuryNumberOtherTag(ushort number, DarkRiftReader reader)
    {
        Debug.Log("Munasa" + number);
        ushort juryButtonIndex = number;
        juryButtonIndex--;
        //Diactivate UI button based on the value of the reader coming from Server
        switch (number)
        {
            case 1:
                juryCollection[juryButtonIndex].color = green;
                CheckActiveJuries();
                break;
            case 2:
                juryCollection[juryButtonIndex].color = green;
                CheckActiveJuries();
                break;
            case 3:
                juryCollection[juryButtonIndex].color = green;
                CheckActiveJuries();
                break;
            case 4:
                juryCollection[juryButtonIndex].color = green;
                CheckActiveJuries();
                break;
            case 5:
                juryCollection[juryButtonIndex].color = green;
                CheckActiveJuries();
                break;
            default:
                //
                break;
        }
    }

    /// <summary>
    /// Call this method when tag is score
    /// </summary>
    /// <param name="reader"></param>
    public void ScoreTag(string text)
    {
        string[] splitedText = CommonUtil.SplitTextWithComma(text);
        monitorScore.GetScore(splitedText[0], splitedText[1], splitedText[2]);
    }

    /// <summary>
    /// Call this method When tag is juryIsOut
    /// </summary>
    /// <param name="number"></param>
    public void JuryIsOutTag(ushort number)
    {        
        ushort juryButtonIndex = number;
        juryButtonIndex--;
        //Diactivate UI button based on the value of the reader coming from Server
        switch (number)
        {
            case 1:
                juryCollection[juryButtonIndex].color = red;
                // Pause game
                break;
            case 2:
                juryCollection[juryButtonIndex].color = red;
                // Pause game
                break;
            case 3:
                juryCollection[juryButtonIndex].color = red;
                // Pause game
                break;
            case 4:
                juryCollection[juryButtonIndex].color = red;
                // Pause game
                break;
            case 5:
                juryCollection[juryButtonIndex].color = red;
                // Pause game
                break;
            default:
                //
                break;
        }
        prgBar.isOn = false;
    }

    public void CheckActiveJuries()
    {
        int juryCollectionIndex = 0;
        for (int i = 0; i < juryCollection.Length; i++)
        {
            if (juryCollection[i].color.Equals(green))
            {
                juryCollectionIndex++;
            }
        }
        //while (juryCollection[juryCollectionIndex].color.Equals(green))
        //{
        //    juryCollectionIndex++;
        //    Debug.Log("index: " + juryCollectionIndex);
        //}

        if (juryCollectionIndex.Equals(5))
        {
            
            outline.gameObject.SetActive(true);
        }        
    }


}
