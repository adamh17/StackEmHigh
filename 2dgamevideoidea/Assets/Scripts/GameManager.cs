using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void GameOver()
    {
        if(PlayerPrefs.GetInt("currentScore") > PlayerPrefs.GetInt("highscore"))
        {
            string highscore = PlayerPrefs.GetInt("currentScore").ToString();
            PlayerPrefs.SetInt("highscore", int.Parse(highscore) - 1);
        }
    }
}
