using DarkRift;
using UnityEngine;

public class GetMessageFromServer : MonoBehaviour
{
    
    /// <summary>
    /// Get string message from Server
    /// </summary>
    /// <param name="reader"></param>
    /// <returns></returns>
    public static string GetStringMessage(DarkRiftReader reader)
    {
        string txt = reader.ReadString();
        return txt;
    }


    /// <summary>
    /// Get ushort message from Server
    /// </summary>
    /// <param name="reader"></param>
    /// <returns></returns>
    public static ushort GetUshortMessage(DarkRiftReader reader)
    {
        ushort txt = reader.ReadUInt16();
        return txt;
    }

}
