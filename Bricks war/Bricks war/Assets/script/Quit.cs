using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour {
    
    public GameObject QUIT;
    void Start()
    {
        QUIT.SetActive(false);
    }
	void Update () {
        hardQuit();
	}

    void hardQuit()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!QUIT.activeSelf)
            {
                QUIT.SetActive(true);
                Invoke("hideQUIT", 3);
                return;
            }
            else
                Application.Quit();
        }
    }
    void hideQUIT()
    {
        QUIT.SetActive(false);
    }
}
