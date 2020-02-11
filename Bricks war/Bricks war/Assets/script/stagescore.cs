using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stagescore : MonoBehaviour {

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

	void Start () {
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (PlayerPrefs.GetInt("score") == 3)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("score") == 2)
        {
            star1.SetActive(true);
            star2.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("score") == 1)
        {
            star1.SetActive(true);
        }

	}
}
