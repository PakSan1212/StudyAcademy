using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    void Update()
    {
        //회사이름.
        transform.rotation =  Camera.main.transform.rotation;
    }
}
