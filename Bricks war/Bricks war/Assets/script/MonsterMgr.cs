using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMgr : MonoBehaviour
{
    public Transform[] points;
    public GameObject[] monsterPrefab = new GameObject[5];
    float createTime;
    public int maxMonster = 10;
    public bool isGameOver = false;

    void Start()
    {
        points = GameObject.Find("MonsterPoint").GetComponentsInChildren<Transform>();
        if (points.Length > 0)
        {
            StartCoroutine(this.CreateMonster());
        }
    }
    IEnumerator CreateMonster()
    {
        while (!isGameOver)
        {
            int monsterCount = (int)GameObject.FindGameObjectsWithTag("Enemy").Length;
            if (monsterCount < maxMonster)
            {
                    int idx = Random.Range(1, points.Length);
                    int i = Random.Range(0, 5);
                    Instantiate(monsterPrefab[i], points[idx].position, points[idx].rotation);
                    if (i == 0)
                        createTime = 0.5f;
                    else if (i == 1)
                        createTime = 1.0f;
                    else if (i == 2)
                        createTime = 1.5f;
                    else if (i == 3)
                        createTime = 2.5f;
                    else
                        createTime = 3.0f;

                    yield return new WaitForSeconds(createTime);
            }
            else
            {
                yield return null;
            }
        }
    }
}