using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soulspiritattack : MonoBehaviour
{
    public float Range;
    public GameObject Target;
    public GameObject skill = null;
    private float counttime;
    public float cooltime;
    public float damage;
    public static float soulspritattackdamage;

    public GameObject[] soulpoint;
    int current;
    float Wpradius;
    public float speed;
    public static float soulspeed;

    private GameObject[] Monsters;
    private float shortestDistance;
    private GameObject nearestMonster;
    private float DistanceToMonsters;

    // Start is called before the first frame update
    void Start()
    {
        soulspeed = speed;
        soulspritattackdamage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        soulwaypoiont();
        attack();
        UpdataTarget();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Range);
    }
    void UpdataTarget()
    {
        Monsters = GameObject.FindGameObjectsWithTag("monster"); //몬스터스 배열에 태그 몬스터 값을 가진 것들을 넣는다.
        shortestDistance = Mathf.Infinity; //가장짧은거리
        nearestMonster = null; //가장가까운몬스터
        foreach (GameObject Monster in Monsters)
        {
            DistanceToMonsters = Vector3.Distance(transform.position, Monster.transform.position); // 지금 오브젝트거리와 몬스터간의 거리를 넣어줌

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
    void attack()
    {
        counttime += Time.deltaTime;
        if (Target != null && counttime > cooltime)
        {
            counttime = 0.0f;
            var aBullet = Instantiate(skill, transform.position, Quaternion.identity, GameObject.Find("maintower").transform);
            aBullet.GetComponent<soulspiritspeed>().targetPosition = (Target.transform.position - transform.position).normalized;
        }
    }

    void soulwaypoiont()
    {
        soulpoint[0] = GameObject.Find("soulstartpoint");
        soulpoint[1] = GameObject.Find("soulpoint1");
        soulpoint[2] = GameObject.Find("soulpoint2");
        soulpoint[3] = GameObject.Find("soulpoint3");
        soulpoint[4] = GameObject.Find("soulpoint4");
        soulpoint[5] = GameObject.Find("soulpoint5");
        soulpoint[6] = GameObject.Find("soulpoint6");
        soulpoint[7] = GameObject.Find("soulpoint7");
        soulpoint[8] = GameObject.Find("soulpoint8");
        soulpoint[9] = GameObject.Find("soulpoint9");
        soulpoint[10] = GameObject.Find("soulpoint10");
        if (Vector2.Distance(soulpoint[current].transform.position, transform.position) == Wpradius)
        {
            current++;
            if (current >= soulpoint.Length)
            {
                current = 0;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, soulpoint[current].transform.position, Time.deltaTime * soulspeed);
    }
}