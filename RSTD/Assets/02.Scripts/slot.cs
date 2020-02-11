using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class slot : MonoBehaviour
{
    public skill skill;
    public Text skillname;
    public Image skillImage;
    public GameObject skillprefab;
    public int SkillLevel;
    public int UpgradeMoney;
    public Text TextSkillLevel;
    public Text TextUpgradeMoney;
    public Text skillinfo;

    public int skillcount;
    public GameObject clone;                // 클론을 받아오기위한 변수
    private panelmanager pm;
    public GameObject PanelSkillLevel;

    private AudioSource sound;
    public AudioClip[] sori;


    void Start()
    {
        this.sound = this.gameObject.AddComponent<AudioSource>();

    }
    private void SetColor(float _alpha) // 스킬 투명도
    {
        Color color = skillImage.color;
        color.a = _alpha;
        skillImage.color = color;
    }

    public void SetRaycasttarget(bool _raycasttarget) // 레이캐스트타겟 온오프
    {
        skillImage.raycastTarget = _raycasttarget;
    }

    public void Addskill(skill _skill, int _count = 1) // 스킬획득
    {
        Debug.Log("첫번째반응");
        skill = _skill;
        skillcount = _count;
        skillImage.sprite = skill.skillimage;
        skillname.text = skill.skillname;
        skillinfo.text = skill.skillinfo;
        SkillLevel = skill.SkillLevel;
        UpgradeMoney = skill.UpgradeMoney;
        TextSkillLevel.text = SkillLevel.ToString();
        TextUpgradeMoney.text = UpgradeMoney.ToString();
        SetRaycasttarget(true);
        skillprefab = skill.skillprefab;
        clone = GameObject.Find(skillprefab.name + "(Clone)");                // 클론을 받아옴 (스킬프리팹 더하기 클론)
        SetColor(1);
        PanelSkillLevel.SetActive(true);
    }

    public void SetSlotCount(int _count) // 공간에 스킬 들어감
    {
        Debug.Log("2번째반응");
        skillcount += _count;

        if (skillcount <= 0)
            ClearSlot();
    }

    private void ClearSlot() // 슬롯 초기화
    {
        SetRaycasttarget(false);
        skill = null;
        skillcount = 0;
        skillImage.sprite = null;
        skillprefab = null;
        skillname.text = null;
        skillinfo.text = null;
        SkillLevel = 1;
        UpgradeMoney = 500;
        Destroy(clone);
        SetColor(0);
        PanelSkillLevel.SetActive(false);
    }
    public void SkillDelete()
    {
        SetSlotCount(-1);
    }
    public void upgrede()
    {
        Debug.Log(gamemanager.money);
        if (gamemanager.money >= 500)
        {
            gamemanager.money -= 500;
            if (skillprefab.gameObject.name == "onetargetskill")
            {
                this.sound.PlayOneShot(sori[0]);
                onetargetsmagic.onetargetsmagicdamage += 50;
            }
            if (skillprefab.gameObject.name == "slowskill")
            {
                this.sound.PlayOneShot(sori[0]);
                slowamagic.slowmagicdamage += 10;
                slowamagic.slowmagicslow += 5;
            }
            if (skillprefab.gameObject.name == "stunskill")
            {
                this.sound.PlayOneShot(sori[0]);
                stunmagic.stunmagicdamage += 10;
                stunmagic.stunmagicstuntime += 0.5f;
            }
            if (skillprefab.gameObject.name == "redora")
            {
                this.sound.PlayOneShot(sori[0]);
                redoramagic.redoravelue += 0.02f;
            }
            if (skillprefab.gameObject.name == "moneystill")
            {
                this.sound.PlayOneShot(sori[0]);
                moneystillmagic.moneystillvelue += 0.05f;
            }
            if (skillprefab.gameObject.name == "soulspirit")
            {
                this.sound.PlayOneShot(sori[0]);
                soulspiritattack.soulspritattackdamage += 5;
                soulspiritattack.soulspeed += 10;
            }
            if (skillprefab.gameObject.name == "jijinskill")
            {
                this.sound.PlayOneShot(sori[0]);
                jijinhee.jijindamage += 5;
            }
            if (skillprefab.gameObject.name == "firepotion")
            {
                this.sound.PlayOneShot(sori[0]);
                fireburn.fireburndamage += 5;
            }
            if (skillprefab.gameObject.name == "greenora")
            {
                this.sound.PlayOneShot(sori[0]);
                greenoramagic.greenoravalue += 5;
            }
            if (skillprefab.gameObject.name == "poisonskill")
            {
                this.sound.PlayOneShot(sori[0]);
                poisonmagic.poisondamage += 5;
            }
            SkillLevel++;
            TextSkillLevel.text = SkillLevel.ToString();


            UpgradeMoney += 100;
            TextUpgradeMoney.text = UpgradeMoney.ToString();
        }
        else
        {
            this.sound.PlayOneShot(sori[1]);
            Debug.Log("강화를 위한 돈이 모자랍니다.");
        }


    }
}