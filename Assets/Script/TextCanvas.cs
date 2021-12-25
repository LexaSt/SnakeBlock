using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextCanvas : MonoBehaviour
{
    public Text Text;
    public Text ScoreAllLevel;
    public Text Level;
    public Stage Stage;
    public GameMenu GameMenu;

    // Update is called once per frame
    void Update()
    {
        Text.text = "Current Level: "  + (GameMenu.LevelID+1).ToString();
        ScoreAllLevel.text = "Score: " + GameMenu.AllLevelsScore.ToString();
        Level.text = "Current Level Score: " + Stage.score.ToString();
    }
}
