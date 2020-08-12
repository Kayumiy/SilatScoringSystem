using UnityEngine;

public class CommonUtil : MonoBehaviour
{


    /// <summary>
    /// Splits the string text
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string[] SplitTextWithComma(string text)
    {
        char pattern = ',';
        string[] splitedText = text.Split(pattern);
        return splitedText;
    }


}
