using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    UnityEngine.AI.NavMeshAgent nav;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }
    void Update()
    {
        if(nav.enabled)
            nav.SetDestination(player.position);
        //Vector3 dir = player.position - transform.position;
        //dir.Normalize();
        //transform.position += dir * Time.deltaTime * 3f;
        //transform.LookAt(player.position);
    }
    
}
