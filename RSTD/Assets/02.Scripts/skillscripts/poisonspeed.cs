using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poisonspeed : MonoBehaviour
{
    public GameObject target;
    public Vector2 targetPosition;
    public float speed;
    public float rotatespeed;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (GameObject.Find("greenora(Clone)"))
        {
            Vector2 direction = targetPosition - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotatespeed;

            rb.velocity = transform.up * (speed + greenoramagic.greenoravalue);

            bulletDestroy();
        }
        else
        {
            Vector2 direction = targetPosition - rb.position;

            direction.Normalize();

            float rotateAmount = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotateAmount * rotatespeed;

            rb.velocity = transform.up * speed;

            bulletDestroy();
        }

    }

    public void bulletDestroy()
    {
        float distance = Vector3.Distance(transform.position, transform.parent.position);
        if (distance > 500f)
        {
            Destroy(gameObject);
        }
        if (target == null)
        {
            Destroy(gameObject);
        }
    }
}
