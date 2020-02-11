using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    float stop = 100f;
    public Text timertext;
    private float time;
    public GameObject blackpoint;
    public GameObject blackpoint1;
    public GameObject blackpoint2;
    public GameObject blackpoint3;
    public GameObject blackpoint4;
    public GameObject blackpoint5;
    public GameObject blackpoint6;
    public GameObject blackpoint7;
    public GameObject redpoint;
    public GameObject redpoint1;
    public GameObject redpoint2;
    public GameObject redpoint3;
    public GameObject redpoint4;
    public GameObject redpoint5;
    public GameObject redpoint6;
    public GameObject redpoint7;
    public GameObject yellowpoint;
    public GameObject yellowpoint1;
    public GameObject yellowpoint2;
    public GameObject yellowpoint3;
    public GameObject yellowpoint4;
    public GameObject yellowpoint5;
    public GameObject yellowpoint6;
    public GameObject yellowpoint7;

    public static bool countstop = false;

    public GameObject gameoverpanel;
    public GameObject moneyoverpanel;
    public Text overtext;
    public Text moneytext;
    public static bool gamestop = false;
    private bool adsover = false;
    float minusstop;
    float plusstop;


    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        minusstop = 50f;
        plusstop = 10f;
        itemcontrol();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timertext.text = string.Format("{0:N2}", time);
        stopgauge();
        createpoint();
        gameover();
    }
    public void carstop()
    {
        carmove.speed = 0f;
        carmove.redspeed = 0f;
        carmove.yellspeed = 0f;
        countstop = true;
    }

    public void cargo()
    {
        carmove.speed = 10f;
        carmove.redspeed = 13f;
        carmove.yellspeed = 15f;
        countstop = false;
    }

    void stopgauge()
    {
        Image img = GameObject.Find("stopgauge").GetComponent<Image>();
        img.fillAmount = stop / 100f;
        if (carmove.speed == 0f && carmove.redspeed == 0f && carmove.yellspeed == 0f)
        {
            stop -= Time.deltaTime * minusstop;
        }
        else if (carmove.speed == 10f && carmove.redspeed == 13f && carmove.yellspeed == 15f)
        {
            stop += Time.deltaTime * plusstop;
        }

        if (stop >= 100f)
        {
            stop = 100;
        }
        else if (stop <= 0f)
        {
            stop = 0f;
            countstop = false;
            carmove.speed = 10f;
            carmove.redspeed = 13f;
            carmove.yellspeed = 15f;
        }
    }

    void createpoint()
    {
        if (time >= 40f)
        {
            redpoint.gameObject.SetActive(true);
            blackpoint.gameObject.SetActive(false);
            redpoint1.gameObject.SetActive(true);
            blackpoint1.gameObject.SetActive(false);
        }

        if(time >= 30f)
        {
            redpoint2.gameObject.SetActive(true);
            blackpoint2.gameObject.SetActive(false);
            redpoint3.gameObject.SetActive(true);
            blackpoint3.gameObject.SetActive(false);
        }

        if (time >= 20f)
        {
            redpoint4.gameObject.SetActive(true);
            blackpoint4.gameObject.SetActive(false);
            redpoint5.gameObject.SetActive(true);
            blackpoint5.gameObject.SetActive(false);
        }

        if (time >= 10f)
        {
            redpoint6.gameObject.SetActive(true);
            blackpoint6.gameObject.SetActive(false);
            redpoint7.gameObject.SetActive(true);
            blackpoint7.gameObject.SetActive(false);
        }

        if (time >= 80f)
        {
            yellowpoint.gameObject.SetActive(true);
            redpoint.gameObject.SetActive(false);
            yellowpoint1.gameObject.SetActive(true);
            redpoint1.gameObject.SetActive(false);
        }

        if (time >= 70f)
        {
            yellowpoint2.gameObject.SetActive(true);
            redpoint2.gameObject.SetActive(false);
            yellowpoint3.gameObject.SetActive(true);
            redpoint3.gameObject.SetActive(false);
        }

        if (time >= 60f)
        {
            yellowpoint4.gameObject.SetActive(true);
            redpoint4.gameObject.SetActive(false);
            yellowpoint5.gameObject.SetActive(true);
            redpoint5.gameObject.SetActive(false);
        }

        if (time >= 50f)
        {
            yellowpoint6.gameObject.SetActive(true);
            redpoint6.gameObject.SetActive(false);
            yellowpoint7.gameObject.SetActive(true);
            redpoint7.gameObject.SetActive(false);
        }
    }

    void gameover()
    {
        overtext.text = "현재 당신의 기록은 " + timertext.text.ToString() + " 입니다";
        moneytext.text = "두배로 받을 골드는 " + ((int)time * 2) + " 입니다";
        if (gamestop == true)
        {
            Time.timeScale = 0;
            gamestop = false;
            if (adsover == false)
            {
                gameoverpanel.gameObject.SetActive(true);
            }
            else
            {
                moneyoverpanel.gameObject.SetActive(true);
            }

        }
    }

    public void GameoverOff()
    {
        if (gameoverpanel.gameObject.activeSelf == true)
        {
            gameoverpanel.SetActive(false);
            moneyoverpanel.SetActive(true);
        }
        
    }

    public void MoneyoverOff()
    {
        if (moneyoverpanel.gameObject.activeSelf == true)
        {
            moneyoverpanel.SetActive(false);
        }
        adsover = false;
        menumanager.money = menumanager.money + (int)time;
        Time.timeScale = 1;
        savebestscore();
        SceneManager.LoadScene("MenuScene");
    }
    public void adsOn()
    {
        adsover = true;
        gameoverpanel.SetActive(false);
        Time.timeScale = 1;
        GameObject[] DeathCar = GameObject.FindGameObjectsWithTag("Car");
        foreach (GameObject obj in DeathCar)
        {
            Destroy(obj);
        }
    }

    public void moneyAdsOn()
    {
        adsover = false;
        menumanager.money = menumanager.money + ((int)time * 2);
        Time.timeScale = 1;
        savebestscore();
        SceneManager.LoadScene("MenuScene");
    }
    void itemcontrol()
    {
        if (menumanager.speeditem == true)
        {
            menumanager.speeditem = false;
            Player.speed = 5;
        }
        else
        {
            Player.speed = 3;
        }
        if (menumanager.sizeitem == true)
        {
            menumanager.sizeitem = false;
            GameObject obj = Instantiate(player, transform.position, transform.rotation);
            obj.transform.localScale = new Vector2(0.8f, 0.8f);
        }
        else
        {
            Instantiate(player, transform.position, transform.rotation);
        }
        if (menumanager.stopamountitem == true)
        {
            menumanager.stopamountitem = false;
            minusstop = 25f;
        }
        if (menumanager.stopregainitem == true)
        {
            menumanager.stopregainitem = false;
            plusstop = 20f;
        }
        
    }

    void savebestscore()
    {
        if ( menumanager.bestscore < time)
        {
            menumanager.bestscore = time;
        }
    }
}
