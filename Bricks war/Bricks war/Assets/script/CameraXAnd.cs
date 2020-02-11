using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraXAnd : MonoBehaviour
{
    private Vector2[] Pos = new Vector2[2];
    
    void Update() {
        if (Input.touchCount > 0)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                if (hit.collider.tag == "land" && hit.collider.tag == "player")
                    return;
            if (EventSystem.current.IsPointerOverGameObject(0) == false)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {

                    Pos[0] = Input.GetTouch(0).position;

                }
                else if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    Pos[1] = Input.GetTouch(0).position;
                    if (Pos[0].x - Pos[1].x > 0)
                    {
                        this.transform.position = new Vector3(transform.position.x + (50 * Time.deltaTime), transform.position.y, transform.position.z);
                    }
                    else
                    {
                        this.transform.position = new Vector3(transform.position.x - (50* Time.deltaTime), transform.position.y, transform.position.z);
                    }
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {

                }
            }
            else
                return;
        }
    }
}