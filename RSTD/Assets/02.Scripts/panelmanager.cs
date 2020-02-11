using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panelmanager : MonoBehaviour
{
    private Text skillname;
    private Text skillinfo;

    public void Showskillinfo(skill _skill)
    {
        skillname.text = _skill.skillname;
        skillinfo.text = _skill.skillinfo;
    }
}
