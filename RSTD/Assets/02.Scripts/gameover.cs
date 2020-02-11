using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameover : MonoBehaviour
{
    public Text 현재몬스터;
    public Text 정해진몬스터;
    private bool Gameover = false;
    public GameObject gameoverpanel;
    public int Gamecount;
    public GameObject[] count;
    public GameObject Pause;
    public ads ads;

    public GameObject adsadsads;
    public GameObject adsbtn;
    void Update()
    {
        ads = GameObject.Find("GameManager").GetComponent<ads>();
        현재몬스터.text = count.Length.ToString();
        정해진몬스터.text = Gamecount.ToString();
        GameoverOn();
        if(GameObject.Find("adsadsads(Clone)"))
        {
            adsbtn.SetActive(false);
        }
    }
    public void GameoverOn()
    {
        count = GameObject.FindGameObjectsWithTag("monster");
        if (count.Length > Gamecount)
        {
            
            if (Pause.gameObject.activeSelf == false)
            {
                gameoverpanel.SetActive(true);
                Time.timeScale = 0;
            }else if(Pause.gameObject.activeSelf == true)
            {
                Time.timeScale = 0;
            }
        }
    }

    public void adsdelete()
    {
        Instantiate(adsadsads, transform.position, Quaternion.identity);
        adsbtn.SetActive(false);
    }

    public void GameoverOff()   // 타임스케일 1로 변경은 startbt 스크립트에 만듬
    {
        if (GameObject.Find("adsadsads(Clone)") == false)
        {
            ads.ShowAd();
        }
        gameoverpanel.SetActive(false);
        SceneManager.LoadScene("Title");
    }
}

