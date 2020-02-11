using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class buttonmanager : MonoBehaviour
{
    [SerializeField]
    private GameObject go_PanelParent;
    public panelmanager panelmanager;
    private slot slot;
    public GameObject guardpanel;


    // Start is called before the first frame update
    void Start()
    {
        panelmanager = go_PanelParent.GetComponentInChildren<panelmanager>(true);
    }

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject() == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (panelmanager.gameObject.activeSelf == true)
                {
                    panelmanager.gameObject.SetActive(false);
                    guardpanel.SetActive(false);
                }
            }
        }
    }
    public void skillpanelopen()
    {
        if (panelmanager.gameObject.activeSelf == false)
        {
            panelmanager.gameObject.SetActive(true);
            guardpanel.SetActive(true);
        }
        else
        {
            panelmanager.gameObject.SetActive(false);
            guardpanel.SetActive(false);
        }
    }

    public void skillDelete()
    {
        panelmanager.gameObject.SetActive(false);
        guardpanel.SetActive(false);

    }
}
