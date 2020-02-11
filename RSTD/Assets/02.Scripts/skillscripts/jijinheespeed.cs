using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jijinheespeed : MonoBehaviour
{

    public Vector3 targetPosition = Vector3.zero;
    static gamemanager gm;
    public float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("greenora(Clone)"))
        {
            transform.Translate(targetPosition * Time.deltaTime * (speed + greenoramagic.greenoravalue));

            bulletDestroy();
        }
        else
        {
            transform.Translate(targetPosition * Time.deltaTime * speed);

            bulletDestroy();
        }

    }

    public void bulletDestroy()
    {
        float distance = Vector3.Distance(transform.position, transform.parent.position);
        if (distance > 500f)
        {
            Destroy(gameObject);
        }

    }
}
