using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stunmagic : MonoBehaviour
{
    public GameObject MAGIC;
    public float Range;
    public GameObject Target;
    public GameObject skill = null;
    private float counttime;
    public float cooltime;
    public float damage;
    public float stuntime;
    public static float stunmagicdamage;
    public static float stunmagicstuntime;

    // Start is called before the first frame update
    void Start()
    {
        stunmagicstuntime = stuntime;
        stunmagicdamage = damage;
        InvokeRepeating("UpdataTarget", 0f, 0.2f);
    }
    // Update is called once per frame
    void Update()
    {
        attack();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }

    void UpdataTarget()
    {
        if (Target == null) //타겟이 널일때 == 비어있을때
        {
            GameObject[] Monsters = GameObject.FindGameObjectsWithTag("monster"); //몬스터스 배열에 태그 몬스터 값을 가진 것들을 넣는다.
            float shortestDistance = Mathf.Infinity; //가장짧은거리
            GameObject nearestMonster = null; //가장가까운몬스터
            foreach (GameObject Monster in Monsters)
            {
                float DistanceToMonsters = Vector3.Distance(transform.position, Monster.transform.position); // 지금 오브젝트거리와 몬스터간의 거리를 넣어줌

                if (DistanceToMonsters < shortestDistance)
                {
                    shortestDistance = DistanceToMonsters;  // 무한의 거리가 몬스터와의 거리로 바뀜
                    nearestMonster = Monster;
                }
            }
            if (nearestMonster != null && shortestDistance <= Range) //몬스터값이 생겼을때 그리고 가장가까이있는 몬스터가 범위보다 작을때
            {
                Target = nearestMonster;

            }
            else
            {
                Target = null;
            }

        }
    }
    void attack()
    {
        counttime += Time.deltaTime;
        if (Target != null && counttime > cooltime)
        {
            counttime = 0.0f;
            skill.transform.LookAt(Target.transform);
            MAGIC = Instantiate(skill, transform.position, Quaternion.identity, transform);
            MAGIC.GetComponent<stunspeed>().targetPosition = (Target.transform.position - transform.position).normalized;
           // MAGIC.transform.localScale = new Vector3(50f, 50f);                                                       //크기
                                                                                                                        //Debug.Log("단일대상공격스킬 발동!");
        }

    }
}
