using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class gamemanager : MonoBehaviour
{
    public static float money;
    public Text moneytext;
    int n;
    int[] y = new int[10] { 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 };
    public GameObject[] skillcreate;
    public int skillcount = 0;
    private AudioSource sound;
    public AudioClip[] sori;


    [SerializeField]
    private skillinven theskillinven;

    void Start()
    {
        money = 500000;
        this.sound = this.gameObject.AddComponent<AudioSource>();
    }
    void Update()
    {
        moneytext.text = money.ToString("###,###");
    }
    public void skillcreatebutton()
    {
        if (skillcount == 7)
        {
            this.sound.PlayOneShot(sori[1]);
            Debug.Log("스킬이 전부 차있습니다.");
        }
        else if (GameObject.FindGameObjectWithTag("skill"))
        {
            if (GameObject.Find("onetargetskill(Clone)"))
            {
                y[0] = 0;
            }
            else
            {
                y[0] = 11;
            }
            if (GameObject.Find("slowskill(Clone)"))
            {
                y[1] = 1;
            }
            else
            {
                y[1] = 11;
            }
            if (GameObject.Find("stunskill(Clone)"))
            {
                y[2] = 2;
            }
            else
            {
                y[2] = 11;
            }
            if (GameObject.Find("redora(Clone)"))
            {
                y[3] = 3;
            }
            else
            {
                y[3] = 11;
            }
            if (GameObject.Find("moneystill(Clone)"))
            {
                y[4] = 4;
            }
            else
            {
                y[4] = 11;
            }
            if (GameObject.Find("soulspirit(Clone)"))
            {
                y[5] = 5;
            }
            else
            {
                y[5] = 11;
            }
            if (GameObject.Find("firepotion(Clone)"))
            {
                y[6] = 6;
            }
            else
            {
                y[6] = 11;
            }
            if (GameObject.Find("jijinskill(Clone)"))
            {
                y[7] = 7;
            }
            else
            {
                y[7] = 11;
            }
            if (GameObject.Find("greenora(Clone)"))
            {
                y[8] = 8;
            }
            else
            {
                y[8] = 11;
            }
            if (GameObject.Find("poisonskill(Clone)"))
            {
                y[9] = 9;
            }
            else
            {
                y[9] = 11;
            }
            while (true)
            {
                n = Random.Range(0, 11);
                if (n != y[0] && n != y[1] && n != y[2] && n != y[3] && n != y[4] && n != y[5] && n != y[6] && n != y[7] && n != y[8] && n != y[9])
                    break;
            }
            try//에러떠서 예외처리문 만듬 나중에 문제생기면 꼭 확인할것
            {
                if (money >= 100)
                {
                    Instantiate(skillcreate[n]);
                    Debug.Log("기존에 있던 스킬 제외하고 랜덤생성한 결과는 = " + skillcreate[n]);
                    theskillinven.Acquireskill(skillcreate[n].GetComponent<skilladd>().skill);
                    skillcount++;
                    money -= 100;
                    this.sound.PlayOneShot(sori[0]);
                }
                else
                {
                    Debug.Log("돈이 모자랍니다");
                    this.sound.PlayOneShot(sori[1]);
                }
            }
            catch { }                   // 에러떠서 예외처리문 만듬 나중에 문제생기면 꼭 확인할것
        }
        else
        {
            try//에러떠서 예외처리문 만듬 나중에 문제생기면 꼭 확인할것
            {
                if (money >= 100)
                {
                    n = Random.Range(0, 8);
                    Instantiate(skillcreate[n]);
                    Debug.Log("아무것도없으니 랜덤생성한 결과는 = " + skillcreate[n]);
                    theskillinven.Acquireskill(skillcreate[n].GetComponent<skilladd>().skill);
                    skillcount++;
                    money -= 100;
                    this.sound.PlayOneShot(sori[0]);
                }
                else
                {
                    Debug.Log("돈이 모자랍니다");
                    this.sound.PlayOneShot(sori[1]);
                }
            }
            catch { }                            // 에러떠서 예외처리문 만듬 나중에 문제생기면 꼭 확인할것
        }
    }
    public void SkillDelete()
    {
        skillcount -= 1;
        Debug.Log(skillcount + "는 현재 카운트");
        this.sound.PlayOneShot(sori[2]);

    }
}