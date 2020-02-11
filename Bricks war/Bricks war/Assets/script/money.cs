using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class money : MonoBehaviour
{
    public Text CoinText;
    //private int Coin;
    public float Coin = 0f;

    void Start()
    {
        Coin = 0;
        SetCountText();
        InvokeRepeating("decreasecoin", 1f, 1f);
    }

    void decreasecoin()
    {
        Coin += 1f;
        SetCountText();
    }

    //필요없는 함수
    void OnTriggerEnter(Collider other)
    {
        Coin = Coin + 1;
        SetCountText();
    }

    void SetCountText()
    {
        CoinText.text = Coin.ToString();
    }
}