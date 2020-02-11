using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{

    public Vector3 targetPosition = Vector3.zero;
    static gamemanager gm;
    public float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(targetPosition * Time.deltaTime * speed);

        bulletDestroy();
    }

    public void bulletDestroy()
    {
        float distance = Vector3.Distance(transform.position, transform.parent.position);
        if (distance > 500f)
        {
            Destroy(gameObject);
        }

    }
}
/*


    public class Lamp : MonoBehaviour
{

    public Vector3 targetPosition = Vector3.zero;
    public float speed;

    public Transform magictransform;
    public Transform targettransform;
    public Vector2 Dir;
    public Quaternion newrotation;
    private Transform bug;

    private Rigidbody2D Rigid;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Targetsetting();
        bulletDestroy();
    }

    public void bulletDestroy()
    {
        float distance = Vector3.Distance(transform.position, transform.parent.position);
        if (distance > 500f)
        {
            Destroy(gameObject);
        }

    }

    public void Targetsetting()
    {
        magictransform = this.gameObject.transform;


        Dir = magictransform.position - targettransform.position;


        Vector3 Axis = Vector3.Cross(Dir, magictransform.forward);


        newrotation = Quaternion.AngleAxis(Time.deltaTime * 45, Axis) * magictransform.rotation;


        magictransform.rotation = Quaternion.Lerp(magictransform.rotation, newrotation, 50 * Time.deltaTime);


        Vector3 Pos = Vector3.forward * Time.deltaTime * 50.0f;


        magictransform.Translate(Pos);
    }
}
*/
