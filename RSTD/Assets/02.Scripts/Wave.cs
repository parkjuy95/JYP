using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public GameObject monster; // 몬스터
    public int count; // 라운드당 최대 마리수
    public float rate; // 몇초후에 한마리씩 나오는가
}
