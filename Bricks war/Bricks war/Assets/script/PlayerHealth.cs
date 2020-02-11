using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerHealth : MonoBehaviour
{
    public GameObject HealthBar;
    public float max_Health = 100f;
    public float cur_Health = 0f;
    public GameObject[] panl = new GameObject[2];


    void Start()
    {
        panl[0].SetActive(false);
        panl[1].SetActive(false);
        cur_Health = max_Health;
        SetHealthBar();
    }

    void Update()
    {
        if (cur_Health <= 0)
        {
            EndScore();
            Time.timeScale = 0;
        }
    }

    public void TakeDamage(float amount)
    {
        cur_Health -= amount;
        SetHealthBar();
    }

    public void EndScore()
    {
        panl[0].SetActive(true);
        panl[1].SetActive(true);
        return;
    }

    void SetHealthBar()
    {
        float my_health = cur_Health / max_Health;
        HealthBar.transform.localScale = new Vector3(Mathf.Clamp(my_health, 0f, 1f), HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);
    }
}