using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadHighScore : MonoBehaviour
{

    public TMPro.TextMeshProUGUI highscore;
    public TMPro.TextMeshProUGUI CurrScore;

    // Start is called before the first frame update
    void Start()
    {
        string hey = PlayerPrefs.GetInt("highscore").ToString();
        highscore.text = hey;

        string score = (PlayerPrefs.GetInt("currentScore") - 1).ToString();
        CurrScore.text = score;

    }
}
