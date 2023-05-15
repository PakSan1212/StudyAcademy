using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform Target;
    Vector3 offset;
    float Speed = 5f;
    void Start()
    {
        //ī�޶� ��ġ - Ÿ�� ��ġ
        offset = transform.position - Target.position;
    }
    void FixedUpdate()
    {
        Vector3 targetCameraPos = Target.position + offset;
        transform.position = Vector3.Lerp(transform.position,
            targetCameraPos, Time.fixedDeltaTime * Speed);
    }
}
