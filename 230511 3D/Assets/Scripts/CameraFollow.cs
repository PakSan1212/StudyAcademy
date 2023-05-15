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
        //카메라 위치 - 타겟 위치
        offset = transform.position - Target.position;
    }
    void FixedUpdate()
    {
        Vector3 targetCameraPos = Target.position + offset;
        transform.position = Vector3.Lerp(transform.position,
            targetCameraPos, Time.fixedDeltaTime * Speed);
    }
}
