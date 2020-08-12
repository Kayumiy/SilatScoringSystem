using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class JuryButton : MonoBehaviour
{
    public ushort number;
    public Button btn;
    public Color green;
    public Color red;
    public GameObject parent;
    public Player player;
    public TMP_Text juryNumberText;

    // Start is called before the first frame update
    void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    /// <summary>
    /// Give a value to the number field of Jury class
    /// </summary>
    void TaskOnClick()
    {
        player.juryNumber = number;
        SetJuryNumber(number.ToString());

    }

    public void MakeItGreen()
    {       
        btn.image.color = green;
        Button[] buttons = parent.GetComponentsInChildren<Button>();
        Debug.Log(buttons.Length);
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].enabled = false;
        }
    }

    public void MakeItGreenOther()
    {
        
        btn.image.color = green;
        btn.enabled = false;
    }

    public void MakeItRedOther()
    {

        btn.image.color = red;
        btn.enabled = false;
    }

    public void SetJuryNumber(string number)
    {
        juryNumberText.text = number;
    }

}
