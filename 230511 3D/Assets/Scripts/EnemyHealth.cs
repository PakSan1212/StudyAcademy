using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyHealth : MonoBehaviour
{
    float MaxHealth = 100;
    float currentHealth = 100;
    ParticleSystem hitParticle;

    void Start()
    {
        currentHealth = MaxHealth;
        hitParticle = GetComponentInChildren<ParticleSystem>();
    }
    public void TakeDamage(float Damage,Vector3 hitPoint)
    {
        hitParticle.Play();
        currentHealth -= Damage;
        if(currentHealth <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        GetComponent<Animator>().SetTrigger("Dead");
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<UnityEngine.AI.NavMeshAgent>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    void StartSinking()
    {
        StartCoroutine("Skinking");
        Destroy(gameObject, 2f);
    }
    IEnumerator Skinking()
    {
        while(true)
        {
            transform.Translate(Vector3.down * 1f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }


}
