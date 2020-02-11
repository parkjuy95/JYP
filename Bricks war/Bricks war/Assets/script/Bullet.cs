using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Transform target;
    public float Damage;
    private Vector3 direction;
    public float speed;

    public void Seek(Transform _target)
    {
        target = _target;
    }
	
	void Update () {
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
        if (other.gameObject.CompareTag("Enemy") && other.transform == GameObject.Find("Castle1").transform)
        {
            other.gameObject.GetComponent<EnemyHealth>().TakeDamage(Damage);
            Destroy(gameObject);
            return;
        }
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyHealth1>().TakeDamage(Damage);
            Destroy(gameObject);
        } 
    }
}
