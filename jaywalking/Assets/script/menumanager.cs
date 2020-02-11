using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menumanager : MonoBehaviour
{
    public static int money = 5000;
    public Text moneytext;
    public Text scoretext;
    public static float bestscore;
    public static bool speeditem = false;
    public static bool sizeitem = false;
    public static bool stopamountitem = false;
    public static bool stopregainitem = false;
    public GameObject[] itempanel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moneytext.text = money.ToString("###,###");
        scoretext.text = bestscore.ToString("###.##");
        Itempanel();
    }

    public void NextScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    void Itempanel()
    {
        if (speeditem == true)
        {
            itempanel[0].SetActive(true);
        }
        else
        {
            itempanel[0].SetActive(false);
        }
        if (sizeitem == true)
        {
            itempanel[1].SetActive(true);
        }
        else
        {
            itempanel[1].SetActive(false);
        }
        if (stopamountitem == true)
        {
            itempanel[2].SetActive(true);
        }
        else
        {
            itempanel[2].SetActive(false);
        }
        if (stopregainitem == true)
        {
            itempanel[3].SetActive(true);
        }
        else
        {
            itempanel[3].SetActive(false);
        }
    }

    public void itembtn1()
    {
        if (menumanager.money >= 100)
        {
            menumanager.money -= 100;
            speeditem = true;
        }
    }
    public void itembtn2()
    {
        if (menumanager.money >= 100)
        {
            menumanager.money -= 100;
            sizeitem = true;
        }
    }
    public void itembtn3()
    {
        if (menumanager.money >= 100)
        {
            menumanager.money -= 100;
            stopamountitem = true;
        }
    }
    public void itembtn4()
    {
        if (menumanager.money >= 100)
        {
            menumanager.money -= 100;
            stopregainitem = true;
        }
    }
}