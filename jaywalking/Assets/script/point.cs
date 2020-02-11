using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class point : MonoBehaviour
{
    public GameObject car;
    public float coolTime;
    public float countTime;
    // Start is called before the first frame update
    void Start()
    {
        coolTime = Random.Range(1.0f, 6.0f);
    }

    // Update is called once per frame
    void Update()
    {
        carcreate();
    }

    void carcreate()
    {
        if(GameManager.countstop == false)
        {
            countTime += Time.deltaTime;
        }
        
        if (countTime > coolTime)
        {
            GameObject obj = Instantiate(car, this.transform.position, this.transform.rotation);
            coolTime = Random.Range(1.0f, 6.0f);
            countTime = 0.0f;
        }
    }
}
