using DarkRift;
using DarkRift.Client.Unity;
using UnityEngine;

public class SendMessageToServer : MonoBehaviour
{  

    /// <summary>
    /// Sends string message to Server
    /// </summary>
    /// <param name="txt"></param>
    /// <param name="tag"></param>
    public static void SendToServer(string txt, ushort tag, UnityClient client)
    {        
        using (DarkRiftWriter writer = DarkRiftWriter.Create())
        {
            writer.Write(txt);
            using (Message playerMessage = Message.Create(tag, writer))
                client.SendMessage(playerMessage, SendMode.Reliable);
        }
    }


    /// <summary>
    /// Sends ushort message to Server
    /// </summary>
    /// <param name="txt"></param>
    /// <param name="tag"></param>
    public static void SendToServer(ushort number, ushort tag, UnityClient client)
    {
        using (DarkRiftWriter writer = DarkRiftWriter.Create())
        {
            writer.Write(number);
            using (Message playerMessage = Message.Create(tag, writer))
                client.SendMessage(playerMessage, SendMode.Reliable);
        }
    }

}
