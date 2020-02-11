using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool pauseOn = false;
    public GameObject pausepanel;
    public GameObject soundoffbtn;

    public void ActivePauseBt()
    {
        pausepanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pausepanel.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void soundoff()
    {
        AudioListener.volume = 0.0f;
        soundoffbtn.SetActive(false);
    }

    public void soundon()
    {
        AudioListener.volume = 1.0f;
        soundoffbtn.SetActive(true);
    }

    public void Exit()
    {
        Debug.Log("이게임을 종료하지");
        SceneManager.LoadScene("Title");
    }
}
