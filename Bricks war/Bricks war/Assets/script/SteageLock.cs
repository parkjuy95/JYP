using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SteageLock : MonoBehaviour {

    public GameObject[] Lockpanel = new GameObject[8];
    int i;
    string[] score = new string[9] { "score1", "score2", "score3", "score4", "score5", "score6", "score7", "score8", "score9" };

	void Start () {
        for (i = 0; i < 8; i++)
            Lockpanel[i].SetActive(true);
        for (i = 0; i < 9; i++)
            Unlock(score[i]);
    }

    void Unlock(string score)
    {
        if (PlayerPrefs.GetInt(score) == 1 || PlayerPrefs.GetInt(score) == 2 || PlayerPrefs.GetInt(score) == 3)
        {
            Lockpanel[i].SetActive(false);
        }
    }
}
