using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraX : MonoBehaviour
{
    private float playtime = 0f;
    public float speed = 3f;
    RaycastHit hit;

    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            transform.Translate(0, 0, -1f);
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            transform.Translate(0, 0, 1f);
        }
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                if (hit.collider.tag != "land" && hit.collider.tag != "Player")
                {
                    if (Input.GetMouseButton(0))
                    {
                        if (EventSystem.current.IsPointerOverGameObject(0) == false)
                        {
                            if (Input.GetAxis("Mouse X") < 0)
                            {
                                transform.Translate(speed, 0, 0);
                            }
                        }
                    }
                    if (Input.GetMouseButton(0))
                    {
                        if (EventSystem.current.IsPointerOverGameObject(0) == false)
                        {
                            if (Input.GetAxis("Mouse X") > 0)
                            {
                                transform.Translate(-speed, 0, 0);
                            }
                        }
                    }

                    if (Input.GetMouseButton(1))
                    {
                        if (Input.GetAxis("Mouse X") > 0)
                        {
                            transform.Rotate(0, 0, 0, Space.World);
                            transform.Translate(-1f, 0, 0);
                        }
                    }
                    if (Input.GetMouseButton(1))
                    {
                        if (Input.GetAxis("Mouse X") < 0)
                        {
                            transform.Rotate(0, 0f, 0, Space.World);
                            transform.Translate(1f, 0, 0);
                        }
                    }
                }
        }
    }
    void TimeClick()
    {
        playtime += Time.deltaTime;
    }
}