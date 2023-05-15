using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    ParticleSystem gunParticle;
    Light gunLight;
    LineRenderer gunLine;
    int shootableMask;
    void Start()
    {
        gunLine = GetComponent<LineRenderer>();
        //gunLine.SetPosition(1, transform.position);

        gunParticle = GetComponent<ParticleSystem>();
        gunLight = GetComponent<Light>();
        shootableMask = LayerMask.GetMask("Shootable");
    }
    float timer = 0f;
    float timeBetweenBullet = 0.2f;
    float effectsDisplayTime = 0.2f; //끄는 시간%

    Ray ShootRay;//총쏘는 방향위치
    RaycastHit ShootHit; //맞은애
    float range = 100f; //사정거리
    float ShootDamage = 20f;
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetButton("Fire1"))
        {
            if(timer >= timeBetweenBullet)
            {
                ShootRay.origin = transform.position;
                ShootRay.direction = transform.forward;
                gunLine.SetPosition(0, ShootRay.origin);

                if (Physics.Raycast(ShootRay, out ShootHit, range, shootableMask))
                {
                    EnemyHealth health = ShootHit.collider.GetComponent<EnemyHealth>();
                    if(health != null)
                    {
                        health.TakeDamage(ShootDamage, ShootHit.point);
                    }

                    //Destroy(ShootHit.collider.gameObject);
                    gunLine.SetPosition(1, ShootHit.point);
                }
                else
                    gunLine.SetPosition(1, ShootRay.origin + (ShootRay.direction * range));

                gunParticle.Play();
                GetComponent<AudioSource>().Play();
                gunLight.enabled = true;
                gunLine.enabled = true;
                timer = 0f;
            }
        }
        if(timer >= timeBetweenBullet * effectsDisplayTime)
        {
            EffectDisable();
        }
    }
    void EffectDisable()
    {
        gunLight.enabled = false;
        gunLine.enabled = false;
    }
}
