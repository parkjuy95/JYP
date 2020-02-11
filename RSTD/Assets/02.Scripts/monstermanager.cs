using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class monstermanager : MonoBehaviour
{
    public GameObject[] waypoints;
    int current = 0;
    public float speed;
    float Wpradius = 0;
    public float hp;
    public float thespeed;
    public float thetime;
    public float addmoney;
    private float maxhp;
    public GameObject firepotionobj;
    public float dottime;
    private float burndot;

    public float tictac = 0;
    private bool dok = false;
    private float nexttime = 0.0f;

    private AudioSource sound;
    public AudioClip[] sori;
    void Start()
    {
        burndot = dottime;
        maxhp = hp;
        thespeed = speed;
        thetime = 10;
        this.sound = this.gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        thetime -= Time.deltaTime;
        leftright();
        monsterhp();
        way();
        stunmanager();
        dokdok();
    }

    void monsterhp()                        // 변수 hp 랑 필어마운트 이미지랑 연동시킴 
    {
        Image img = transform.Find("Canvas/hp").GetComponent<Image>();
        img.fillAmount = hp / maxhp;
    }

    public void stunmanager()
    {
        if (thetime <= 0)
        {
            speed = thespeed;
            thetime = 10;
        }
        else if (thetime >= stunmagic.stunmagicstuntime)
        {
            thetime = 10;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "firepotionburn(Clone)")
        {
            var green = fireburn.fireburndamage;
            var blue = green;                                                         // 블루는 기존의 데미지값을 저장 왜냐하면 레드오라가 있었다가 없을 수 있기때문에 기존의 값을 알고 있어야함
            var red = green * redoramagic.redoravelue;                                      // 레드는 기존의 데미지값에 레드오라 밸류값을 곱한 값을 넣었다
            burndot -= Time.deltaTime;
            if (GameObject.Find("redora(Clone)"))                                               //if 레드오라가 존재할때
            {
                if (burndot <= 0)
                {
                    green += red;                                                               // 원타겟대미지에 레드값을 더함
                    hp -= green;                                                                // hp에서 원타겟데미지를 뺌
                    burndot = dottime;
                }
            }
            else                                                                               //if 레드오라가 존재하지 않을때
            {
                if (burndot <= 0)
                {
                    green = blue;                                                               // 원타겟데미지에 블루값을 넣음
                    hp -= green;                                                                // hp에서 원타겟데미지를 뺌
                    burndot = dottime;
                }
            }
        }
        death();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "magic") // 태그가 매직일때
        {
            if (collision.gameObject.name == "basicattack(Clone)") //겜오브젝트 이름이 저것일때
            {
                var green = basicattack.basicattackdamage;
                var blue = green;                                                         // 블루는 기존의 데미지값을 저장 왜냐하면 레드오라가 있었다가 없을 수 있기때문에 기존의 값을 알고 있어야함
                var red = green * redoramagic.redoravelue;                                      // 레드는 기존의 데미지값에 레드오라 밸류값을 곱한 값을 넣었다
                if (GameObject.Find("redora(Clone)"))                                               //if 레드오라가 존재할때
                {
                    green += red;                                                               // 원타겟대미지에 레드값을 더함
                    hp -= green;                                                                // hp에서 원타겟데미지를 뺌
                    this.sound.PlayOneShot(sori[0], 0.5f);
                    Destroy(collision.gameObject);                                                                              // 사라짐
                }
                else                                                                               //if 레드오라가 존재하지 않을때
                {
                    green = blue;                                                               // 원타겟데미지에 블루값을 넣음
                    hp -= green;                                                                // hp에서 원타겟데미지를 뺌
                    this.sound.PlayOneShot(sori[0], 0.5f);
                    Destroy(collision.gameObject);
                }
            }

            if (collision.gameObject.name == "onetargetmagic(Clone)") //겜오브젝트 이름이 저것일때
            {
                var green = onetargetsmagic.onetargetsmagicdamage;
                var blue = green;                                                         // 블루는 기존의 데미지값을 저장 왜냐하면 레드오라가 있었다가 없을 수 있기때문에 기존의 값을 알고 있어야함
                var red = green * redoramagic.redoravelue;                                      // 레드는 기존의 데미지값에 레드오라 밸류값을 곱한 값을 넣었다
                if (GameObject.Find("redora(Clone)"))                                               //if 레드오라가 존재할때
                {
                    green += red;                                                               // 원타겟대미지에 레드값을 더함
                    hp -= green;                                                                // hp에서 원타겟데미지를 뺌
                    this.sound.PlayOneShot(sori[1], 0.5f);
                    Destroy(collision.gameObject);                                                                              // 사라짐
                }
                else                                                                               //if 레드오라가 존재하지 않을때
                {
                    green = blue;                                                               // 원타겟데미지에 블루값을 넣음
                    hp -= green;                                                                // hp에서 원타겟데미지를 뺌
                    this.sound.PlayOneShot(sori[1], 0.5f);
                    Destroy(collision.gameObject);
                }
            }

            if (collision.gameObject.name == "slowmagic(Clone)") //겜오브젝트 이름이 저것일때
            {
                var green = slowamagic.slowmagicdamage;
                var blue = green;
                var red = green * redoramagic.redoravelue;
                speed -= slowamagic.slowmagicslow;
                if (speed < 0)
                {
                    speed = 0;
                }
                else if (speed <= 10)
                {
                    speed = 10;
                }
                if (GameObject.Find("redora(Clone)"))
                {
                    green += red;
                    hp -= green;                           // hp 10 감소
                    this.sound.PlayOneShot(sori[2], 0.5f);
                    Destroy(collision.gameObject);          // 사라짐
                }
                else
                {
                    green = blue;
                    hp -= green;                             // hp 10 감소
                    this.sound.PlayOneShot(sori[2], 0.5f);
                    Destroy(collision.gameObject);          // 사라짐
                }
            }

            if (collision.gameObject.name == "stunmagic(Clone)")
            {
                var green = stunmagic.stunmagicdamage;
                var blue = green;
                var red = green * redoramagic.redoravelue;
                thetime = stunmagic.stunmagicstuntime;
                if (speed != 80)
                {
                    thespeed = speed;
                    speed = 0;
                }
                else
                {
                    speed = 0;
                }
                if (GameObject.Find("redora(Clone)"))
                {
                    green += red;
                    hp -= green;                           // hp 10 감소
                    this.sound.PlayOneShot(sori[3], 0.5f);
                    Destroy(collision.gameObject);          // 사라짐
                }
                else
                {
                    green = blue;
                    hp -= green;                             // hp 10 감소
                    this.sound.PlayOneShot(sori[3], 0.5f);
                    Destroy(collision.gameObject);          // 사라짐
                }
            }

            if (collision.gameObject.name == "soulspiritattack(Clone)") //겜오브젝트 이름이 저것일때
            {
                var green = soulspiritattack.soulspritattackdamage;
                var blue = green;                                                         // 블루는 기존의 데미지값을 저장 왜냐하면 레드오라가 있었다가 없을 수 있기때문에 기존의 값을 알고 있어야함
                var red = green * redoramagic.redoravelue;                                      // 레드는 기존의 데미지값에 레드오라 밸류값을 곱한 값을 넣었다
                if (GameObject.Find("redora(Clone)"))                                               //if 레드오라가 존재할때
                {
                    green += red;                                                               // 원타겟대미지에 레드값을 더함
                    hp -= green;                                                                // hp에서 원타겟데미지를 뺌
                    this.sound.PlayOneShot(sori[4], 0.5f);
                    Destroy(collision.gameObject);                                                                              // 사라짐
                }
                else                                                                               //if 레드오라가 존재하지 않을때
                {
                    green = blue;                                                               // 원타겟데미지에 블루값을 넣음
                    hp -= green;                                                                // hp에서 원타겟데미지를 뺌
                    this.sound.PlayOneShot(sori[4], 0.5f);
                    Destroy(collision.gameObject);
                }
            }
        }
        if (collision.gameObject.name == "jijinhee(Clone)") //겜오브젝트 이름이 저것일때
        {
            var green = jijinhee.jijindamage;
            var blue = green;                                                         // 블루는 기존의 데미지값을 저장 왜냐하면 레드오라가 있었다가 없을 수 있기때문에 기존의 값을 알고 있어야함
            var red = green * redoramagic.redoravelue;                                      // 레드는 기존의 데미지값에 레드오라 밸류값을 곱한 값을 넣었다
            if (GameObject.Find("redora(Clone)"))                                               //if 레드오라가 존재할때
            {
                green += red;                                                               // 원타겟대미지에 레드값을 더함
                hp -= green;                                                                // hp에서 원타겟데미지를 뺌
                Destroy(collision.gameObject);                                                                              // 사라짐
            }
            else                                                                               //if 레드오라가 존재하지 않을때
            {
                green = blue;                                                               // 원타겟데미지에 블루값을 넣음
                hp -= green;                                                                // hp에서 원타겟데미지를 뺌
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.name == "firepotionmagic(Clone)")
        {
            var green = firepotion.firepotionmagicdamage;
            var blue = green;                                                         // 블루는 기존의 데미지값을 저장 왜냐하면 레드오라가 있었다가 없을 수 있기때문에 기존의 값을 알고 있어야함
            var red = green * redoramagic.redoravelue;                                      // 레드는 기존의 데미지값에 레드오라 밸류값을 곱한 값을 넣었다
            if (GameObject.Find("redora(Clone)"))                                               //if 레드오라가 존재할때
            {
                green += red;                                                               // 원타겟대미지에 레드값을 더함
                hp -= green;                                                                // hp에서 원타겟데미지를 뺌
                this.sound.PlayOneShot(sori[5], 0.5f);
                Instantiate(firepotionobj, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);                                                                              // 사라짐
            }
            else                                                                               //if 레드오라가 존재하지 않을때
            {
                green = blue;                                                               // 원타겟데미지에 블루값을 넣음
                hp -= green;                                                                // hp에서 원타겟데미지를 뺌
                this.sound.PlayOneShot(sori[5], 0.5f);
                Instantiate(firepotionobj, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
            }
        }
        if (collision.gameObject.name == "poisonmagic(Clone)")
        {
            var green = poisonmagic.meeledamage;
            var blue = green;                                                         // 블루는 기존의 데미지값을 저장 왜냐하면 레드오라가 있었다가 없을 수 있기때문에 기존의 값을 알고 있어야함
            var red = green * redoramagic.redoravelue;                                      // 레드는 기존의 데미지값에 레드오라 밸류값을 곱한 값을 넣었다
            if (GameObject.Find("redora(Clone)"))                                               //if 레드오라가 존재할때
            {
                green += red;                                                               // 원타겟대미지에 레드값을 더함
                hp -= green;                                                                // hp에서 원타겟데미지를 뺌
                dok = true;
                tictac = 0;
                Destroy(collision.gameObject);                                                                              // 사라짐
            }
            else                                                                               //if 레드오라가 존재하지 않을때
            {
                green = blue;                                                               // 원타겟데미지에 블루값을 넣음
                hp -= green;                                                                // hp에서 원타겟데미지를 뺌
                dok = true;
                tictac = 0;
                Destroy(collision.gameObject);
            }
        }
        death();
    }
    void death()
    {
        if (hp <= 0) // 피 0 이하일때 
        {
            var realmoney = addmoney;
            var stillmoney = addmoney * moneystillmagic.moneystillvelue;
            if (GameObject.Find("moneystill(Clone)"))
            {
                realmoney += stillmoney;
                gamemanager.money += realmoney;
                Destroy(gameObject);
            }
            else
            {
                gamemanager.money += addmoney;
                Destroy(gameObject);
            }

        }
    }

    void dokdok()
    {
        if (dok == true)
        {
            var poisongreen = poisonmagic.poisondamage;
            var poisonblue = poisongreen;
            var poisonred = poisongreen * redoramagic.redoravelue;
            var poisontime = poisonmagic.poisontime;
            if (Time.time > nexttime && tictac < 5)
            {
                nexttime = Time.time + poisontime;
                if (GameObject.Find("redora(Clone)"))                                               //if 레드오라가 존재할때
                {
                    poisongreen += poisonred;                                                               // 원타겟대미지에 레드값을 더함
                    hp -= poisongreen;                                                                // hp에서 원타겟데미지를 뺌
                    tictac++;
                }
                else                                                                               //if 레드오라가 존재하지 않을때
                {
                    poisongreen = poisonblue;                                                               // 원타겟데미지에 블루값을 넣음
                    hp -= poisongreen;                                                                // hp에서 원타겟데미지를 뺌
                    tictac++;
                }
            }
            if (tictac >= 5)
            {
                dok = false;
            }
        }
    }

    public void way()
    {
        waypoints[0] = GameObject.Find("startPoint");
        waypoints[1] = GameObject.Find("waypoint1");
        waypoints[2] = GameObject.Find("waypoint2");
        waypoints[3] = GameObject.Find("waypoint3");
        waypoints[4] = GameObject.Find("waypoint4");
        waypoints[5] = GameObject.Find("waypoint5");
        waypoints[6] = GameObject.Find("waypoint6");
        waypoints[7] = GameObject.Find("waypoint7");
        if (Vector2.Distance(waypoints[current].transform.position, transform.position) == Wpradius)
        {
            current++;
            if (current >= waypoints.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[current].transform.position, Time.deltaTime * speed);
    }

    public void leftright()
    {
        if (current == 0 || current == 1 || current == 2 || current == 7)
        {
            transform.localScale = new Vector2(-15, 15);
        }
        else if (current == 3 || current == 4 || current == 5 || current == 6)
        {
            transform.localScale = new Vector2(15, 15);
        }

    }

}
