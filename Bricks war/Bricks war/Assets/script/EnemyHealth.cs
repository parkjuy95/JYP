using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyHealth : MonoBehaviour
{
    public GameObject HealthBar;
    public float max_Health = 60f;
    public float cur_Health = 0f;
    public GameObject[] star = new GameObject[3] { null, null, null };
    public GameObject[] panl = new GameObject[] { null, null, null, null, null};
    StageScoreSave SSS;



    void Start()
    {
        SSS = gameObject.GetComponent<StageScoreSave>();
        cur_Health = max_Health;
        SetHealthBar();
        for (int i = 0; i < 5; i++)
        {
            panl[i].SetActive(false);
        }
    }

    void Update()
    {
        if (cur_Health <= 0)
        {
            EndScore();
            Time.timeScale = 0;
        }
        Destroy(star[2], 180);
        Destroy(star[1], 240);
        Destroy(star[0], 330);

    }

    public void TakeDamage(float amount)
    {
        cur_Health -= amount;
        SetHealthBar();
    }

    public void EndScore()
    {
        if (star[0] != null && star[1] != null && star[2] != null)
        {
            panl[0].SetActive(true);
            panl[4].SetActive(true);
            SSS.Save3Score();
            return;

        }
        else if (star[0] != null && star[1] != null && star[2] == null)
        {
            panl[1].SetActive(true);
            panl[4].SetActive(true);
            SSS.Save2Score();
            return;
        }
        else if (star[0] != null && star[1] == null && star[2] == null)
        {
            panl[2].SetActive(true);
            panl[4].SetActive(true);
            SSS.Save1Score();
            return;
        }
        else
        {
            panl[3].SetActive(true);
            panl[4].SetActive(true);
            return;
        }
    }
    void SetHealthBar()
    {
        float my_health = cur_Health / max_Health;
        HealthBar.transform.localScale = new Vector3(Mathf.Clamp(my_health, 0f, 1f), HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);
    }
}