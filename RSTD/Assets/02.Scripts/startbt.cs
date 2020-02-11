using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class startbt : MonoBehaviour
{
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextGameScene()
    {
        SceneManager.LoadScene("testscenes");
    }
}
