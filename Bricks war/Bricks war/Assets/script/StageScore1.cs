using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageScore1 : MonoBehaviour {

    public GameObject[] panl = new GameObject[9];
    public GameObject[] star = new GameObject[27];
    int i, j;
    string[] score = new string[9] {"score1", "score2", "score3", "score4", "score5", "score6", "score7", "score8", "score9"};

	// Use this for initialization
	void Start () {
        for (i = 0; i < 9; i++)
            panl[i].SetActive(false);
        for (j = 0; j < 27; j++)
            star[i].SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        for (i = 0,j = 0; i < 9; i++)
        {
            FindScore(score[i]);
            j += 3;
        }
    }
    void FindScore(string score) {
        if(PlayerPrefs.GetInt(score) == 3) {
            panl[i].SetActive(true);
            star[j].SetActive(true);
            star[j+1].SetActive(true);
            star[j+2].SetActive(true);
            return;
        }
        else if(PlayerPrefs.GetInt(score) == 2) {
            panl[i].SetActive(true);
            star[j].SetActive(true);
            star[j+1].SetActive(true);
            star[j+2].SetActive(false);
            return;
        }
        else if(PlayerPrefs.GetInt(score) == 1) {
            panl[i].SetActive(true);
            star[j].SetActive(true);
            star[j+1].SetActive(false);
            star[j + 2].SetActive(false);
            return;
        }
    }
}
