using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class summons : MonoBehaviour
{
    //소환을 위한 변수 선언
    public GameObject[] unit = new GameObject[5];
    bool[] x = new bool[5];
    
    //코인을 위한 변수 선언
    public Text CoinText;
    public int Coin = 50;
    public int[] money = new int[] {10,15,25,45,60 };
    RaycastHit hit;

    void Start()
    {
        SetCountText();
        InvokeRepeating("decreasecoin", 3f, 3f);
    }

    void Update()
    {
        for (int i = 0; i < 5; i++)
        {
            if (x[i] == true)
            {
                summons_unit(unit[i], money[i]);
            }
        } 
    }

    public void summons_unit(GameObject unit, int money)
    {
        if (Coin >= money)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit))
                    if (hit.collider.tag == "land")
                    {
                        Instantiate(unit, hit.point, new Quaternion(transform.rotation.x, transform.rotation.y + 1, transform.rotation.z, transform.rotation.w));
                        Coin -= money;
                        SetCountText();
                    }
            }
        }
    }

    public void click1()
    {
        x[0] = true;
        for (int i = 1; i < 5; i++)
            x[i] = false;
    }
    public void click2()
    {
        x[1] = true;
        x[0] = false;
        for (int i = 2; i < 5; i++)
            x[i] = false;
    }
    public void click3()
    {
        x[2] = true;
        for(int i=0;i<2;i++)
            x[i] = false;
        for (int i = 3; i < 5; i++)
            x[i] = false;
    }
    public void click4()
    {
        x[3] = true;
        for (int i = 0; i < 3; i++)
            x[i] = false;
        x[4] = false;
    }
    public void click5()
    {
        x[4] = true;
        for (int i = 3; i >= 0 ; i--)
            x[i] = false;
    }

    void SetCountText()
    {
        CoinText.text = Coin.ToString();
    }
    void decreasecoin()
    {
        Coin += 50;      
        SetCountText();
    }
}
