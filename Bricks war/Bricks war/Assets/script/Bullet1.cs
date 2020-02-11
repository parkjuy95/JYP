using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : MonoBehaviour
{

    public Transform target;
    public float Damage;
    private Vector3 direction;
    public float speed;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        direction = (target.position - transform.position).normalized;
        this.transform.position = new Vector3(transform.position.x + (direction.x * speed * Time.deltaTime), transform.position.y, transform.position.z + (direction.z * speed * Time.deltaTime));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && other.transform == GameObject.Find("Castle2").transform)
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(Damage);
            Destroy(gameObject);
            return;
        }
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth1>().TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}
