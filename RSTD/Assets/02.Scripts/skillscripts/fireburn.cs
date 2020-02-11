using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireburn : MonoBehaviour
{
    public float damage;
    public static float fireburndamage;
    public float burntime;
    void Start()
    {
        fireburndamage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        burntime -= Time.deltaTime;
        if (burntime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
