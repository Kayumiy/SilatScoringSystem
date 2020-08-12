using UnityEngine;
using UnityEngine.UI;

public class ScoreButton : MonoBehaviour
{
    Button button;
    public string color;
    public int score;    
    public string scoreText;
    public FighterScore fighterScore;
    
    public Round round;
    public bool isScore; 

    private void Awake()
    {
        button = GetComponent<Button>();        
    }

    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(TaskOnClick);
    }

    /// <summary>
    /// Call this method when buttin is clicked
    /// </summary>
    void TaskOnClick()
    {
        fighterScore.DisplayScoreText(scoreText, score, isScore);
    }

}

