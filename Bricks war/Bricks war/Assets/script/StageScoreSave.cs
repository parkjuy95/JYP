using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class StageScoreSave : MonoBehaviour {
    string[] Stagescore = new string[9] { "score1", "score2", "score3", "score4", "score5", "score6", "score7", "score8", "score9" };
    public void Save3Score()
    {
        for (int i = 0; i < 9; i++)
        {
            if (SceneManager.GetActiveScene().buildIndex == (i + 2))
            {
                if (PlayerPrefs.GetInt(Stagescore[i]) > 2)
                {
                    return;
                }
                PlayerPrefs.SetInt(Stagescore[i], 3);
                break;
            }
        }
    }
    public void Save2Score()
    {
        for (int i = 0; i < 9; i++)
        {
            if (SceneManager.GetActiveScene().buildIndex == (i + 2))
            {
                if (PlayerPrefs.GetInt(Stagescore[i]) > 1)
                {
                    return;
                }
                PlayerPrefs.SetInt(Stagescore[i], 2);
                break;
            }

        }
    }
    public void Save1Score()
    {
        for (int i = 0; i < 9; i++)
        {
            if (SceneManager.GetActiveScene().buildIndex == (i + 2))
            {
                if (PlayerPrefs.GetInt(Stagescore[i]) > 0)
                {
                    return;
                }
                PlayerPrefs.SetInt(Stagescore[i], 1);
                break;
            }
        }
    }
}
