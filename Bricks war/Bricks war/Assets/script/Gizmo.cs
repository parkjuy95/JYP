using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gizmo : MonoBehaviour
{
    public Color _color = Color.red;
    public float _radius = 0.5f;

    void OnDrawGizmos()
    {
        Gizmos.color = _color; //기즈모 색상 설정
        Gizmos.DrawSphere(transform.position, _radius); //구체 모양의 기즈모를 
        //transform.position 위치에 _radius 크기만큼 생성
    }
}