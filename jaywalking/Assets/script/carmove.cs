using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carmove : MonoBehaviour
{
    public static float speed = 10f;
    public static float redspeed = 13f;
    public static float yellspeed = 15f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.name == "LeftCar(Clone)")
        {
            LeftMove();
        }

        if (this.gameObject.name == "RightCar(Clone)")
        {
            RightMove();
        }

        if (this.gameObject.name == "LeftRedCar(Clone)")
        {
            LeftRedMove();
        }

        if (this.gameObject.name == "RightRedCar(Clone)")
        {
            RightRedMove();
        }

        if (this.gameObject.name == "LeftYellCar(Clone)")
        {
            LeftYellMove();
        }

        if (this.gameObject.name == "RightYellCar(Clone)")
        {
            RightYellMove();
        }
    }

    void LeftMove()
    {
        this.gameObject.transform.position = new Vector2(transform.position.x + speed * Time.deltaTime, transform.position.y);
        Destroy(gameObject, 5f);
    }

    void RightMove()
    {
        this.gameObject.transform.position = new Vector2(transform.position.x - speed * Time.deltaTime, transform.position.y);
        Destroy(gameObject, 5f);
    }

    void LeftRedMove()
    {
        this.gameObject.transform.position = new Vector2(transform.position.x + redspeed * Time.deltaTime, transform.position.y);
        Destroy(gameObject, 5f);
    }

    void RightRedMove()
    {
        this.gameObject.transform.position = new Vector2(transform.position.x - redspeed * Time.deltaTime, transform.position.y);
        Destroy(gameObject, 5f);
    }

    void LeftYellMove()
    {
        this.gameObject.transform.position = new Vector2(transform.position.x + yellspeed * Time.deltaTime, transform.position.y);
        Destroy(gameObject, 5f);
    }

    void RightYellMove()
    {
        this.gameObject.transform.position = new Vector2(transform.position.x - yellspeed * Time.deltaTime, transform.position.y);
        Destroy(gameObject, 5f);
    }
}
