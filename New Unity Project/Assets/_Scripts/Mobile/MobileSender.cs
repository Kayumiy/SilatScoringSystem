using AgarPlugin1;
using DarkRift.Client.Unity;
using System;
using UnityEngine;

public class MobileSender : MonoBehaviour
{
    public JuryButton[] juryButtons;
    
    [SerializeField]
    [Tooltip("The DarkRift client to communicate on.")]
    UnityClient client;
    string buttonColor;

    
    /// <summary>
    /// Sends selected juryNumber to the Server
    /// </summary>
    /// <param name="number"></param>
    public void SendJuryNumber(int _number)
    {
        ushort number = Convert.ToUInt16(_number);
        SendMessageToServer.SendToServer(number, Tags.juryNumber, client);
    }

    /// <summary>
    /// Sends score to the Server
    /// </summary>
    /// <param name="score"></param>
    public void SendScore(string score)
    {
        //string txt = Player.juryNumber.ToString() + "," + buttonColor + "," + score;
        //SendMessageToServer.SendToServer(txt, Tags.score, client);
    }

    /// <summary>
    /// Sets button color when sending the score to the Server. This method should be called before SendScore method called 
    /// </summary>
    /// <param name="color"></param>
    public void SetButtonColor(string color)
    {
        buttonColor = color;
    }

}
