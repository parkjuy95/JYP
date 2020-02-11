using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyHealth1 : MonoBehaviour
{
    public float max_Health = 60f;
    public float cur_Health = 0f;


    void Start()
    {
        cur_Health = max_Health;
    }

    void Update()
    {
        if (cur_Health <= 0)
        {
            Destroy(gameObject);
        }

    }

    public void TakeDamage(float amount)
    {
        cur_Health -= amount;
    }
}