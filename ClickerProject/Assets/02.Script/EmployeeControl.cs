using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmployeeControl : MonoBehaviour
{
    SpriteRenderer spr;

    public Employee info;

    public float speed;

    public Vector2 prevPosition;
    // Start is called before the first frame update
    void Start()
    {
        spr = GetComponent<SpriteRenderer>();

        if(string.IsNullOrEmpty(info.name))
        {
            SetInfo();
        }
        
        

        StartCoroutine(EanrMoneyAuto());
        StartCoroutine(Move());
        StartCoroutine(HpDecreaseAuto());

    }

    // Update is called once per frame
    void Update()
    {
        SpriteChange();
        ShowInfo();
    }

    IEnumerator EanrMoneyAuto()
    {
        while(true)
        {
            GameManager.money += 2;
            ShowTextMoney(2);
            Debug.Log(GameManager.money);
            yield return new WaitForSeconds(1.0f);
        }
    }

    void ShowTextMoney(int m)
    {
        GameObject obj = Instantiate(GameManager.gm.prefabTextMoney, 
            this.gameObject.transform.Find("Canvas"), false);

        Animator anim = obj.GetComponent<Animator>();
        anim.SetTrigger("Start");

        Text txt = obj.GetComponent<Text>();
        txt.text = "+ " + m.ToString("###,###");

        Destroy(obj, 3f);
    }

    IEnumerator HpDecreaseAuto()
    {
        while (true)
        {
            info.hp -= 1;
            
            yield return new WaitForSeconds(1.0f);
        }
    }
    IEnumerator Move()
    {
        while(true)
        {
            float x = transform.position.x + Random.Range(-2f, 2f);
            float y = transform.position.y + Random.Range(-2f, 2f);

            Vector2 target = new Vector2(x, y);
            target = CheckTarget(target);

            prevPosition = transform.position;

            while(Vector2.Distance(transform.position, target) > 0.01f)
            {
                transform.position = Vector2.MoveTowards(transform.position, target, speed);
                yield return null;
            }
            

            yield return new WaitForSeconds(1.0f);

        }
    }

    Vector2 CheckTarget(Vector2 currentTarget)
    {
        Vector2 temp = currentTarget;

        if(currentTarget.x < GameManager.gm.limitPoint1.x)
        {
            temp = new Vector2(currentTarget.x + 4, temp.y);
        }
        else if(currentTarget.x > GameManager.gm.limitPoint2.x)
        {
            temp = new Vector2(currentTarget.x - 4, temp.y);
        }

        if (currentTarget.y > GameManager.gm.limitPoint1.y)
        {
            temp = new Vector2(temp.x, currentTarget.y - 4);
        }
        else if (currentTarget.y < GameManager.gm.limitPoint2.y)
        {
            temp = new Vector2(temp.x, currentTarget.y + 4);
        }


        return temp;
    }
    void SpriteChange()
    {
        Sprite[] set = null; //0 = 정면, 1 = 후면, 2 = 측면

        if (info.gender == Gender.Female)
        {
            set = GameManager.gm.spriteF;
        }
        else
        {
            set = GameManager.gm.spriteM;
        }
        
        Vector2 abs = (Vector2)transform.position - prevPosition; // 현재 위치값 - 전의 위치값
        

        if(Mathf.Abs(abs.x) > Mathf.Abs(abs.y)) // x값으로 움직인 절대값 > y값으로 움직인 절대값
        {
            spr.sprite = set[2];
            if(transform.position.x > prevPosition.x) // 오른쪽
            {
                spr.flipX = false;
            }
            else if(transform.position.x < prevPosition.x) // 왼쪽
            {
                spr.flipX = true;
            }
        }
        else // 위 또는 아래
        {
            spr.flipX = false;
            if(transform.position.y > prevPosition.y) // 위
            {
                spr.sprite = set[1];
            }
            else if(transform.position.y < prevPosition.y) // 아래
            {
                spr.sprite = set[0];
            }
        }
    }

    void SetInfo()
    {
        info.name = GameManager.familyName + GameManager.name;
        info.hp = 100;

        info.design = Random.Range(0, 101);
        info.programming = Random.Range(0, 101);
        info.sound = Random.Range(0, 101);
        info.art = Random.Range(0, 101);

        info.salery = Random.Range(100, 1001);

        int r = Random.Range(0, 2);
        info.gender = (Gender)r;
    }

    void ShowInfo()
    {
        Text txt = gameObject.transform.Find("Canvas/Text_Name").GetComponent<Text>();
        txt.text = info.name;

        Image img = transform.Find("Canvas/Image/Image_Gauge").GetComponent<Image>();
        img.fillAmount = info.hp / 100f;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Coffee") == true)
        {
            Debug.Log("커피를 마심");
            info.hp = 100;
            Destroy(collision.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Employee") == true)
        {
            Collider2D col1 = this.gameObject.GetComponent<Collider2D>();
            Collider2D col2 = collision.collider;
            Physics2D.IgnoreCollision(col1, col2);
        }
    }
}

public enum Gender
{
    Female = 0,
    Male = 1
}

[System.Serializable]
public class Employee
{
    public string name; //이름
    public Gender gender; // 성별
    public float design; //기획
    public float programming; //프로그래밍
    public float art; //그림
    public float sound; //사운드

    public float hp; //체력

    public long salery; //월급
}