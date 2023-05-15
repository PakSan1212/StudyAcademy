using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerHealth : MonoBehaviour
{
    float MaxHealth = 100;
    float currentHealth = 100;

    [SerializeField]
    UnityEngine.UI.Slider HealthSlider;

    [SerializeField]
    UnityEngine.UI.Image DamageImage;
    Color flashColor = new Color(1f, 0f, 0f, 0.2f);

    void Start()
    {
        HealthSlider.maxValue = MaxHealth;
        HealthSlider.value = currentHealth = MaxHealth;


    }
    public void TakeDamage(float Damage)
    {

        DamageImage.color = flashColor;
        currentHealth -= Damage;
        HealthSlider.value = currentHealth;
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    void Death()
    {
        GetComponent<Animator>().SetTrigger("Dead");
        GetComponent<CapsuleCollider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;
    }
    bool damaged;
    private void Update()
    {
            DamageImage.color = Color.Lerp(DamageImage.color, Color.clear, 5f * Time.deltaTime);        
    }


}
