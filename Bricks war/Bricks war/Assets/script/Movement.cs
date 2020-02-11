using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{


    public GameObject soundPrefab;
    public int maxsound;


    public Animator Ani;
    public Transform target;
    public Transform target2;
    public Vector3 direction;

    [Header("Attributes")]

    public float range = 7f;
    public float look = 15;
    private float Bspeed;
    public float speed = 5f;
    public float fireRate = 1f;
    public float fireCountdown = 0f;

    [Header("Unity Setup Fields")]

    public string enemyTag;
    public GameObject bulletPrefab;
    public Transform firePoint;



    void Start()
    {
        Bspeed = speed;
        InvokeRepeating("UpdateTarget", 0f, 0.1f);
        InvokeRepeating("UpdateTarget2", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void UpdateTarget2()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= look)
        {
            target2 = nearestEnemy.transform;
        }
        else
        {
            target2 = null;
        }
    }


    void Update()
    {
        if (Time.timeScale == 0)
        {
            speed = 0f;
            return;
        }
        else
        {
            if (target != null)
            {
                speed = 0f;
                Ani.SetBool("Walk", false);
            }
            else if (target == null)
            {
                speed = Bspeed;
                Ani.SetBool("Walk", true);
                Ani.SetBool("Right Punch Attack", false);
            }
        }


        if (fireCountdown <= 0f)
        {
            Shoot();
            fireCountdown = fireRate / 1f;
            Ani.SetBool("Right Punch Attack", true);
        }

        fireCountdown -= Time.deltaTime;
        if (target2 != null)
        {
            MoveToTarget();
            transform.LookAt(target2.transform.position);
        }
        if (enemyTag == "Enemy")
            Invoke("Move1", 1.1f);
        else if (enemyTag == "Player")
            Invoke("Move2", 1.1f);

    }

    public void MoveToTarget()
    {

        direction = (target2.position - transform.position).normalized;
        this.transform.position = new Vector3(transform.position.x + (direction.x * speed * Time.deltaTime), transform.position.y + (direction.y * speed * Time.deltaTime), transform.position.z + (direction.z * speed * Time.deltaTime));
    }
    void Shoot()
    {
        if (target != null)
        {
            if (enemyTag == "Enemy")
            {
                GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Bullet bullet = bulletGO.GetComponent<Bullet>();

                int soundCount = (int)GameObject.FindGameObjectsWithTag("sound").Length;

                if (soundCount < maxsound)
                {
                    Instantiate(soundPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                }

                if (bullet != null)
                    bullet.Seek(target);
            }
            if (enemyTag == "Player")
            {
                GameObject bulletGO1 = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                Bullet1 bullet1 = bulletGO1.GetComponent<Bullet1>();

                int soundCount = (int)GameObject.FindGameObjectsWithTag("sound").Length;
                if (soundCount < maxsound)
                {
                    Instantiate(soundPrefab, new Vector3(0, 0, 0), Quaternion.identity);
                }

                if (bullet1 != null)
                    bullet1.Seek(target);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, look);
    }

    public void Move1()
    {
        if (target2 == null)
        {
            this.transform.position = new Vector3(transform.position.x + (speed * Time.deltaTime * Time.timeScale), transform.position.y, transform.position.z);
            transform.LookAt(GameObject.Find("Castle1").transform);
            Ani.SetBool("Walk", true);
        }
    }

    public void Move2()
    {
        if (target2 == null)
        {
            this.transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime * Time.timeScale), transform.position.y, transform.position.z);
            transform.LookAt(GameObject.Find("Castle2").transform);
            Ani.SetBool("Walk", true);
        }
    }
}