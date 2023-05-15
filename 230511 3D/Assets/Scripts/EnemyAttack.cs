using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth playerHealth;
    GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    bool PlayerInRange = false;
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Player")
        {
            PlayerInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PlayerInRange = false;
        }
    }
    [SerializeField]
    float AttackDamage = 20f;
    float timeBetweenAttacks = 0.5f;
    float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;
        if (PlayerInRange)
        {
            if(timer >= timeBetweenAttacks)
            {
                timer = 0f;
                PlayerHealth health = player.GetComponent<PlayerHealth>();
                if (health != null)
                    health.TakeDamage(AttackDamage);
            }
           
        }
    }
}
