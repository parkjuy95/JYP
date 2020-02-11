using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public static long money;

    public GameObject prefabCoffee;
    public GameObject prefabEmployee;
    public GameObject prefabTextMoney;

    public Sprite[] spriteF;
    public Sprite[] spriteM;

    public Vector2 limitPoint1;
    public Vector2 limitPoint2;

    public Text textMoney;

    public static string familyName
    {
        get
        {
            string[] names = new string[10];

            names[0] = "김";
            names[1] = "이";
            names[2] = "박";
            names[3] = "최";
            names[4] = "정";
            names[5] = "강";
            names[6] = "조";
            names[7] = "윤";
            names[8] = "장";
            names[9] = "임";

            int r = Random.Range(0, names.Length);
            string s = names[r];

            return s;
        }
    }
    public static string name
    {
        get
        {
            string[] names = new string[10];

            names[0] = "기역";
            names[1] = "니은";
            names[2] = "디귿";
            names[3] = "리을";
            names[4] = "미음";
            names[5] = "비읍";
            names[6] = "시옷";
            names[7] = "이응";
            names[8] = "지읒";
            names[9] = "치읓";

            int r = Random.Range(0, names.Length);
            string s = names[r];

            return s;
        }
    }

    public Sprite[] spriteButtonState;
    public Image imgButton;
    public bool isWhip;

    public GameObject panelInfo;

    public List<Employee> emps;

    private string savePath;

    public AudioClip clip;

    private void Awake()
    {
        gm = this;
        savePath = Application.persistentDataPath + "/save.sav";
        
    }
    // Start is called before the first frame update
    void Start()
    {
        emps = new List<Employee>();
        money = 100000;
        if(System.IO.File.Exists(savePath))
        {
            Load();
            foreach(var a in emps)
            {
                InitioalizeEmployee(a);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //EarnMoney();
        if(EventSystem.current.IsPointerOverGameObject() == false)
        {
            if (isWhip == true)
                EarnMoney();
            else
                CreateCoffee();
        }

        if(GameObject.Find("Panel_Option") != null)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.G))
            GetComponent<AudioSource>().PlayOneShot(clip);

        ShowMoneyText();
        ChangeButtonSprite();

    }

    public void EarnMoney()
    {
        if (Input.GetMouseButtonDown(0))
        {
            money += 1;
            Debug.Log(money);
        }
    }

    void CreateCoffee()
    {
        if(Input.GetMouseButtonDown(0)) // 마우스 왼쪽 버튼을 클릭하면
        {
            Vector2 mousePosition = 
                Camera.main.ScreenToWorldPoint(Input.mousePosition);

            //게임 오브젝트 생성
            Instantiate(prefabCoffee, mousePosition, Quaternion.identity);
        }
    }

    void ShowMoneyText()
    {
        textMoney.text = money.ToString("###,###");
    }

    public void ChangeButtonState()
    {
        if (isWhip == true)
            isWhip = false;
        else
            isWhip = true;
    }

    void ChangeButtonSprite()
    {
        if (isWhip == true)
        {
            imgButton.sprite = spriteButtonState[0]; // 채찍
            imgButton.rectTransform.sizeDelta = new Vector2(180, 180);
        }

        else
        { 
            imgButton.sprite = spriteButtonState[1]; //커피
            imgButton.rectTransform.sizeDelta = new Vector2(110, 180);
        }
    }

    public void PanelHireOpen()
    {
        panelInfo.SetActive(true);


        Employee e = RandomCreateEmployee();

        var textName = panelInfo.transform.Find("Text_Name").GetComponent<Text>();
        var imageCharactoer = panelInfo.transform.Find("Image_Character").GetComponent<Image>();
        var textProgramming = panelInfo.transform.Find("Text_Programming").GetComponent<Text>();
        var textDesign = panelInfo.transform.Find("Text_Design").GetComponent<Text>();
        var textSound = panelInfo.transform.Find("Text_Sound").GetComponent<Text>();
        var textArt = panelInfo.transform.Find("Text_Art").GetComponent<Text>();
        var textSalery = panelInfo.transform.Find("Button_Hire/Image_Price/Text").GetComponent<Text>();
        var buttonHire = panelInfo.transform.Find("Button_Hire").GetComponent<Button>();

        textName.text = e.name;
        if(e.gender == Gender.Female)
        {
            imageCharactoer.sprite = spriteF[0];
        }
        else
        {
            imageCharactoer.sprite = spriteM[0];
        }

        textProgramming.text = e.programming.ToString();
        textDesign.text = e.design.ToString();
        textSound.text = e.sound.ToString();
        textArt.text = e.art.ToString();
        textSalery.text = e.salery.ToString();

        buttonHire.onClick.RemoveAllListeners();
        buttonHire.onClick.AddListener(delegate
        {
            Hire((int)e.salery, e);
        });
    }

    Employee RandomCreateEmployee()
    {
        Employee info = new Employee();

        info.name = familyName + name;
        info.hp = 100;

        info.design = Random.Range(0, 101);
        info.programming = Random.Range(0, 101);
        info.sound = Random.Range(0, 101);
        info.art = Random.Range(0, 101);

        info.salery = Random.Range(100, 1001);

        int r = Random.Range(0, 2);
        info.gender = (Gender)r;

        return info;
    }

    void CreateEmployee(Employee e)
    {
        GameObject obj = Instantiate(prefabEmployee, Vector3.zero, Quaternion.identity);
        obj.GetComponent<EmployeeControl>().info = e;
    }

    void InitioalizeEmployee(Employee e)
    {
        GameObject obj = Instantiate(prefabEmployee, Vector3.zero, Quaternion.identity);
        obj.GetComponent<EmployeeControl>().info = e;
    }

    public void Hire(int price, Employee e)
    {
        if(money >= price)
        {
            CreateEmployee(e);
            money -= price;
            emps.Add(e);
        }
    }

    public void Save()
    {
        //PlayerPrefs.SetInt("MONEY", (int)money);
        //PlayerPrefs.SetString("MONEY", money.ToString());
        SaveData sd = new SaveData();
        sd.money = money;
        sd.empList = emps;
        XmlManager.XmlSave<SaveData>(sd, savePath);
    }

    public void Load()
    {
        //money = PlayerPrefs.GetInt("MONEY", 1000);
        //money = long.Parse(PlayerPrefs.GetString("MONEY"));
        SaveData sd = XmlManager.XmlLoad<SaveData>(savePath);
        money = sd.money;
        emps = sd.empList;
    }

    private void OnApplicationQuit()
    {
        Save();
        Application.Quit();
    }
    private void OnDrawGizmos()
    {
        Vector2 limitPoint3 = new Vector2(limitPoint2.x, limitPoint1.y);
        Vector2 limitPoint4 = new Vector2(limitPoint1.x, limitPoint2.y);

        Gizmos.color = Color.red;

        Gizmos.DrawLine(limitPoint1, limitPoint3);
        Gizmos.DrawLine(limitPoint3, limitPoint2);
        Gizmos.DrawLine(limitPoint1, limitPoint4);
        Gizmos.DrawLine(limitPoint4, limitPoint2);

    }

    public void VolumeChange(Slider sl)
    {
        GetComponent<AudioSource>().volume = sl.value;
    }

    public void SaveDelete()
    {
        if(System.IO.File.Exists(savePath))
        {
            System.IO.File.Delete(savePath);
        }
    }
}


public class SaveData
{
    public long money;

    public List<Employee> empList;
}