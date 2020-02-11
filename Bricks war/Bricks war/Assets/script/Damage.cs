using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage = 5f;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            other.gameObject.GetComponent<PlayerHealth1>().TakeDamage(damage);

        else
            other.gameObject.GetComponent<EnemyHealth1>().TakeDamage(damage);
    }

}
