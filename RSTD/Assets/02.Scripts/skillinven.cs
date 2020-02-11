using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillinven : MonoBehaviour
{
    [SerializeField]
    private GameObject go_SlotParent;
    public slot[] slots;

    void Start()
    {
        slots = go_SlotParent.GetComponentsInChildren<slot>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Acquireskill(skill _skill, int _count = 1)
    {
        {
            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].skill == null)
                {
                    slots[i].Addskill(_skill, _count);
                    Debug.Log("얻는반응");
                    return;
                }
            }
        }
    }
}
